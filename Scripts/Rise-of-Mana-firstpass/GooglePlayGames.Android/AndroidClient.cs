using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

public class AndroidClient : IPlayGamesClient
{
	private enum AuthState
	{
		NoAuth,
		AuthPending,
		InProgress,
		LoadingAchs,
		Done
	}

	private class OnAchievementsLoadedResultProxy : AndroidJavaProxy
	{
		private AndroidClient mOwner;

		internal OnAchievementsLoadedResultProxy(AndroidClient c)
			: base("com.google.android.gms.common.api.ResultCallback")
		{
			mOwner = c;
		}

		public void onResult(AndroidJavaObject result)
		{
			Logger.d("OnAchievementsLoadedResultProxy invoked");
			Logger.d("    result=" + result);
			int statusCode = JavaUtil.GetStatusCode(result);
			AndroidJavaObject androidJavaObject = JavaUtil.CallNullSafeObjectMethod(result, "getAchievements");
			mOwner.OnAchievementsLoaded(statusCode, androidJavaObject);
			androidJavaObject?.Dispose();
		}
	}

	private class OnInvitationReceivedProxy : AndroidJavaProxy
	{
		private AndroidClient mOwner;

		internal OnInvitationReceivedProxy(AndroidClient owner)
			: base("com.google.android.gms.games.multiplayer.OnInvitationReceivedListener")
		{
			mOwner = owner;
		}

		public void onInvitationReceived(AndroidJavaObject invitationObj)
		{
			Logger.d("OnInvitationReceivedProxy.onInvitationReceived");
			mOwner.OnInvitationReceived(invitationObj);
		}

		public void onInvitationRemoved(string invitationId)
		{
			Logger.d("OnInvitationReceivedProxy.onInvitationRemoved");
			mOwner.OnInvitationRemoved(invitationId);
		}
	}

	private const int RC_UNUSED = 9999;

	private GameHelperManager mGHManager;

	private AuthState mAuthState;

	private bool mSilentAuth;

	private string mUserId;

	private string mUserDisplayName;

	private Action<bool> mAuthCallback;

	private AchievementBank mAchievementBank = new AchievementBank();

	private List<Action> mActionsPendingSignIn = new List<Action>();

	private bool mSignOutInProgress;

	private AndroidRtmpClient mRtmpClient;

	private AndroidTbmpClient mTbmpClient;

	private InvitationReceivedDelegate mInvitationDelegate;

	private bool mRegisteredInvitationListener;

	private Invitation mInvitationFromNotification;

	internal GameHelperManager GHManager => mGHManager;

	public string PlayerId => mUserId;

	public AndroidClient()
	{
		mRtmpClient = new AndroidRtmpClient(this);
		mTbmpClient = new AndroidTbmpClient(this);
		RunOnUiThread(delegate
		{
			Logger.d("Initializing Android Client.");
			Logger.d("Creating GameHelperManager to manage GameHelper.");
			mGHManager = new GameHelperManager(this);
			mGHManager.AddOnStopDelegate(mRtmpClient.OnStop);
		});
	}

	public void Authenticate(Action<bool> callback, bool silent)
	{
		if (mAuthState != 0)
		{
			Logger.w("Authenticate() called while an authentication process was active. " + mAuthState);
			mAuthCallback = callback;
			return;
		}
		Logger.d("Making sure PlayGamesHelperObject is ready.");
		PlayGamesHelperObject.CreateObject();
		Logger.d("PlayGamesHelperObject created.");
		mSilentAuth = silent;
		Logger.d("AUTH: starting auth process, silent=" + mSilentAuth);
		RunOnUiThread(delegate
		{
			switch (mGHManager.State)
			{
			case GameHelperManager.ConnectionState.Connected:
				Logger.d("AUTH: already connected! Proceeding to achievement load phase.");
				mAuthCallback = callback;
				DoInitialAchievementLoad();
				break;
			case GameHelperManager.ConnectionState.Connecting:
				Logger.d("AUTH: connection in progress; auth now pending.");
				mAuthCallback = callback;
				mAuthState = AuthState.AuthPending;
				break;
			default:
				mAuthCallback = callback;
				if (mSilentAuth)
				{
					Logger.d("AUTH: not connected and silent=true, so failing.");
					mAuthState = AuthState.NoAuth;
					InvokeAuthCallback(success: false);
				}
				else
				{
					Logger.d("AUTH: not connected and silent=false, so starting flow.");
					mAuthState = AuthState.InProgress;
					mGHManager.BeginUserInitiatedSignIn();
				}
				break;
			}
		});
	}

	private void DoInitialAchievementLoad()
	{
		Logger.d("AUTH: Now performing initial achievement load...");
		mAuthState = AuthState.LoadingAchs;
		mGHManager.CallGmsApiWithResult("games.Games", "Achievements", "load", new OnAchievementsLoadedResultProxy(this), false);
		Logger.d("AUTH: Initial achievement load call made.");
	}

	private void OnAchievementsLoaded(int statusCode, AndroidJavaObject buffer)
	{
		if (mAuthState == AuthState.LoadingAchs)
		{
			Logger.d("AUTH: Initial achievement load finished.");
			if (statusCode == 0 || statusCode == 3 || statusCode == 5)
			{
				Logger.d("Processing achievement buffer.");
				mAchievementBank.ProcessBuffer(buffer);
				Logger.d("Closing achievement buffer.");
				buffer.Call("close");
				Logger.d("AUTH: Auth process complete!");
				mAuthState = AuthState.Done;
				InvokeAuthCallback(success: true);
				CheckForConnectionExtras();
				mRtmpClient.OnSignInSucceeded();
				mTbmpClient.OnSignInSucceeded();
			}
			else
			{
				Logger.w("AUTH: Failed to load achievements, status code " + statusCode);
				mAuthState = AuthState.NoAuth;
				InvokeAuthCallback(success: false);
			}
		}
		else
		{
			Logger.w("OnAchievementsLoaded called unexpectedly in auth state " + mAuthState);
		}
	}

	private void InvokeAuthCallback(bool success)
	{
		if (mAuthCallback != null)
		{
			Logger.d("AUTH: Calling auth callback: success=" + success);
			Action<bool> cb = mAuthCallback;
			mAuthCallback = null;
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				cb(success);
			});
		}
	}

	private void RetrieveUserInfo()
	{
		Logger.d("Attempting to retrieve player info.");
		using AndroidJavaObject androidJavaObject = mGHManager.CallGmsApi<AndroidJavaObject>("games.Games", "Players", "getCurrentPlayer", new object[0]);
		if (mUserId == null)
		{
			mUserId = androidJavaObject.Call<string>("getPlayerId", new object[0]);
			Logger.d("Player ID: " + mUserId);
		}
		if (mUserDisplayName == null)
		{
			mUserDisplayName = androidJavaObject.Call<string>("getDisplayName", new object[0]);
			Logger.d("Player display name: " + mUserDisplayName);
		}
	}

	internal void OnSignInSucceeded()
	{
		Logger.d("AndroidClient got OnSignInSucceeded.");
		RetrieveUserInfo();
		if (mAuthState == AuthState.AuthPending || mAuthState == AuthState.InProgress)
		{
			Logger.d("AUTH: Auth succeeded. Proceeding to achievement loading.");
			DoInitialAchievementLoad();
		}
		else if (mAuthState == AuthState.LoadingAchs)
		{
			Logger.w("AUTH: Got OnSignInSucceeded() while in achievement loading phase (unexpected).");
			Logger.w("AUTH: Trying to fix by issuing a new achievement load call.");
			DoInitialAchievementLoad();
		}
		else
		{
			Logger.d("Normal lifecycle OnSignInSucceeded received.");
			RunPendingActions();
			CheckForConnectionExtras();
			mRtmpClient.OnSignInSucceeded();
			mTbmpClient.OnSignInSucceeded();
		}
	}

	internal void OnSignInFailed()
	{
		Logger.d("AndroidClient got OnSignInFailed.");
		if (mAuthState == AuthState.AuthPending)
		{
			if (mSilentAuth)
			{
				Logger.d("AUTH: Auth flow was pending, but silent=true, so failing.");
				mAuthState = AuthState.NoAuth;
				InvokeAuthCallback(success: false);
			}
			else
			{
				Logger.d("AUTH: Auth flow was pending and silent=false, so doing noisy auth.");
				mAuthState = AuthState.InProgress;
				mGHManager.BeginUserInitiatedSignIn();
			}
		}
		else if (mAuthState == AuthState.InProgress)
		{
			Logger.d("AUTH: FAILED!");
			mAuthState = AuthState.NoAuth;
			InvokeAuthCallback(success: false);
		}
		else if (mAuthState == AuthState.LoadingAchs)
		{
			Logger.d("AUTH: FAILED (while loading achievements).");
			mAuthState = AuthState.NoAuth;
			InvokeAuthCallback(success: false);
		}
		else if (mAuthState == AuthState.NoAuth)
		{
			Logger.d("Normal OnSignInFailed received.");
		}
		else if (mAuthState == AuthState.Done)
		{
			Logger.e("Authentication has been lost!");
			mAuthState = AuthState.NoAuth;
		}
	}

	private void RunPendingActions()
	{
		if (mActionsPendingSignIn.Count > 0)
		{
			Logger.d("Running pending actions on the UI thread.");
			while (mActionsPendingSignIn.Count > 0)
			{
				Action action = mActionsPendingSignIn[0];
				mActionsPendingSignIn.RemoveAt(0);
				action();
			}
			Logger.d("Done running pending actions on the UI thread.");
		}
		else
		{
			Logger.d("No pending actions to run on UI thread.");
		}
	}

	public bool IsAuthenticated()
	{
		return mAuthState == AuthState.Done && !mSignOutInProgress;
	}

	public void SignOut()
	{
		Logger.d("AndroidClient.SignOut");
		mSignOutInProgress = true;
		RunWhenConnectionStable(delegate
		{
			Logger.d("Calling GHM.SignOut");
			mGHManager.SignOut();
			mAuthState = AuthState.NoAuth;
			mSignOutInProgress = false;
			Logger.d("Now signed out.");
		});
	}

	internal AndroidJavaObject GetActivity()
	{
		using AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		return androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
	}

	internal void RunOnUiThread(Action action)
	{
		using AndroidJavaObject androidJavaObject = GetActivity();
		androidJavaObject.Call("runOnUiThread", new AndroidJavaRunnable(action.Invoke));
	}

	private void RunWhenConnectionStable(Action a)
	{
		RunOnUiThread(delegate
		{
			if (mGHManager.Paused || mGHManager.Connecting)
			{
				Logger.d("Action scheduled for later (connection currently in progress).");
				mActionsPendingSignIn.Add(a);
			}
			else
			{
				a();
			}
		});
	}

	internal void CallClientApi(string desc, Action call, Action<bool> callback)
	{
		Logger.d("Requesting API call: " + desc);
		RunWhenConnectionStable(delegate
		{
			if (mGHManager.IsConnected())
			{
				Logger.d("Connected! Calling API: " + desc);
				call();
				if (callback != null)
				{
					PlayGamesHelperObject.RunOnGameThread(delegate
					{
						callback(obj: true);
					});
				}
			}
			else
			{
				Logger.w("Not connected! Failed to call API :" + desc);
				if (callback != null)
				{
					PlayGamesHelperObject.RunOnGameThread(delegate
					{
						callback(obj: false);
					});
				}
			}
		});
	}

	public string GetUserId()
	{
		return mUserId;
	}

	public string GetUserDisplayName()
	{
		return mUserDisplayName;
	}

	public void UnlockAchievement(string achId, Action<bool> callback)
	{
		Logger.d("AndroidClient.UnlockAchievement: " + achId);
		Achievement achievement = GetAchievement(achId);
		if (achievement != null && achievement.IsUnlocked)
		{
			Logger.d("...was already unlocked, so no-op.");
			callback?.Invoke(obj: true);
			return;
		}
		CallClientApi("unlock ach " + achId, delegate
		{
			mGHManager.CallGmsApi("games.Games", "Achievements", "unlock", achId);
		}, callback);
		achievement = GetAchievement(achId);
		if (achievement != null)
		{
			achievement.IsUnlocked = (achievement.IsRevealed = true);
		}
	}

	public void RevealAchievement(string achId, Action<bool> callback)
	{
		Logger.d("AndroidClient.RevealAchievement: " + achId);
		Achievement achievement = GetAchievement(achId);
		if (achievement != null && achievement.IsRevealed)
		{
			Logger.d("...was already revealed, so no-op.");
			callback?.Invoke(obj: true);
			return;
		}
		CallClientApi("reveal ach " + achId, delegate
		{
			mGHManager.CallGmsApi("games.Games", "Achievements", "reveal", achId);
		}, callback);
		achievement = GetAchievement(achId);
		if (achievement != null)
		{
			achievement.IsRevealed = true;
		}
	}

	public void IncrementAchievement(string achId, int steps, Action<bool> callback)
	{
		Logger.d("AndroidClient.IncrementAchievement: " + achId + ", steps " + steps);
		CallClientApi("increment ach " + achId, delegate
		{
			mGHManager.CallGmsApi("games.Games", "Achievements", "increment", achId, steps);
		}, callback);
		Achievement achievement = GetAchievement(achId);
		if (achievement != null)
		{
			achievement.CurrentSteps += steps;
			if (achievement.CurrentSteps >= achievement.TotalSteps)
			{
				achievement.CurrentSteps = achievement.TotalSteps;
			}
		}
	}

	public List<Achievement> GetAchievements()
	{
		return mAchievementBank.GetAchievements();
	}

	public Achievement GetAchievement(string achId)
	{
		return mAchievementBank.GetAchievement(achId);
	}

	public void ShowAchievementsUI()
	{
		Logger.d("AndroidClient.ShowAchievementsUI.");
		CallClientApi("show achievements ui", delegate
		{
			using AndroidJavaObject androidJavaObject = mGHManager.CallGmsApi<AndroidJavaObject>("games.Games", "Achievements", "getAchievementsIntent", new object[0]);
			using AndroidJavaObject androidJavaObject2 = GetActivity();
			Logger.d(string.Concat("About to show achievements UI with intent ", androidJavaObject, ", activity ", androidJavaObject2));
			if (androidJavaObject != null)
			{
				androidJavaObject2?.Call("startActivityForResult", androidJavaObject, 9999);
			}
		}, null);
	}

	private AndroidJavaObject GetLeaderboardIntent(string lbId)
	{
		return (lbId != null) ? mGHManager.CallGmsApi<AndroidJavaObject>("games.Games", "Leaderboards", "getLeaderboardIntent", new object[1] { lbId }) : mGHManager.CallGmsApi<AndroidJavaObject>("games.Games", "Leaderboards", "getAllLeaderboardsIntent", new object[0]);
	}

	public void ShowLeaderboardUI(string lbId)
	{
		Logger.d("AndroidClient.ShowLeaderboardUI, lb=" + ((lbId != null) ? lbId : "(all)"));
		CallClientApi("show LB ui", delegate
		{
			using AndroidJavaObject androidJavaObject = GetLeaderboardIntent(lbId);
			using AndroidJavaObject androidJavaObject2 = GetActivity();
			Logger.d(string.Concat("About to show LB UI with intent ", androidJavaObject, ", activity ", androidJavaObject2));
			if (androidJavaObject != null)
			{
				androidJavaObject2?.Call("startActivityForResult", androidJavaObject, 9999);
			}
		}, null);
	}

	public void SubmitScore(string lbId, long score, Action<bool> callback)
	{
		Logger.d("AndroidClient.SubmitScore, lb=" + lbId + ", score=" + score);
		CallClientApi("submit score " + score + ", lb " + lbId, delegate
		{
			mGHManager.CallGmsApi("games.Games", "Leaderboards", "submitScore", lbId, score);
		}, callback);
	}

	public void LoadState(int slot, OnStateLoadedListener listener)
	{
		Logger.d("AndroidClient.LoadState, slot=" + slot);
		CallClientApi("load state slot=" + slot, delegate
		{
			OnStateResultProxy callbackProxy = new OnStateResultProxy(this, listener);
			mGHManager.CallGmsApiWithResult("appstate.AppStateManager", null, "load", callbackProxy, slot);
		}, null);
	}

	internal void ResolveState(int slot, string resolvedVersion, byte[] resolvedData, OnStateLoadedListener listener)
	{
		Logger.d($"AndroidClient.ResolveState, slot={slot}, ver={resolvedVersion}, data={resolvedData}");
		CallClientApi("resolve state slot=" + slot, delegate
		{
			mGHManager.CallGmsApiWithResult("appstate.AppStateManager", null, "resolve", new OnStateResultProxy(this, listener), slot, resolvedVersion, resolvedData);
		}, null);
	}

	public void UpdateState(int slot, byte[] data, OnStateLoadedListener listener)
	{
		Logger.d($"AndroidClient.UpdateState, slot={slot}, data={Logger.describe(data)}");
		CallClientApi("update state, slot=" + slot, delegate
		{
			mGHManager.CallGmsApi("appstate.AppStateManager", null, "update", slot, data);
		}, null);
		listener.OnStateSaved(success: true, slot);
	}

	public void SetCloudCacheEncrypter(BufferEncrypter encrypter)
	{
		Logger.d("Ignoring cloud cache encrypter (not used in Android)");
	}

	public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg)
	{
		Logger.d("AndroidClient.RegisterInvitationDelegate");
		if (deleg == null)
		{
			Logger.w("AndroidClient.RegisterInvitationDelegate called w/ null argument.");
			return;
		}
		mInvitationDelegate = deleg;
		if (!mRegisteredInvitationListener)
		{
			Logger.d("Registering an invitation listener.");
			RegisterInvitationListener();
		}
		if (mInvitationFromNotification == null)
		{
			return;
		}
		Logger.d("Delivering pending invitation from notification now.");
		Invitation inv = mInvitationFromNotification;
		mInvitationFromNotification = null;
		PlayGamesHelperObject.RunOnGameThread(delegate
		{
			if (mInvitationDelegate != null)
			{
				mInvitationDelegate(inv, shouldAutoAccept: true);
			}
		});
	}

	public Invitation GetInvitationFromNotification()
	{
		Logger.d("AndroidClient.GetInvitationFromNotification");
		Logger.d("Returning invitation: " + ((mInvitationFromNotification != null) ? mInvitationFromNotification.ToString() : "(null)"));
		return mInvitationFromNotification;
	}

	public bool HasInvitationFromNotification()
	{
		bool flag = mInvitationFromNotification != null;
		Logger.d("AndroidClient.HasInvitationFromNotification, returning " + flag);
		return flag;
	}

	private void RegisterInvitationListener()
	{
		Logger.d("AndroidClient.RegisterInvitationListener");
		CallClientApi("register invitation listener", delegate
		{
			mGHManager.CallGmsApi("games.Games", "Invitations", "registerInvitationListener", new OnInvitationReceivedProxy(this));
		}, null);
		mRegisteredInvitationListener = true;
	}

	public IRealTimeMultiplayerClient GetRtmpClient()
	{
		return mRtmpClient;
	}

	public ITurnBasedMultiplayerClient GetTbmpClient()
	{
		return mTbmpClient;
	}

	internal void ClearInvitationIfFromNotification(string invitationId)
	{
		Logger.d("AndroidClient.ClearInvitationIfFromNotification: " + invitationId);
		if (mInvitationFromNotification != null && mInvitationFromNotification.InvitationId.Equals(invitationId))
		{
			Logger.d("Clearing invitation from notification: " + invitationId);
			mInvitationFromNotification = null;
		}
	}

	private void CheckForConnectionExtras()
	{
		Logger.d("AndroidClient: CheckInvitationFromNotification.");
		Logger.d("AndroidClient: looking for invitation in our GameHelper.");
		Invitation invFromNotif = null;
		AndroidJavaObject invitation = mGHManager.GetInvitation();
		AndroidJavaObject turnBasedMatch = mGHManager.GetTurnBasedMatch();
		mGHManager.ClearInvitationAndTurnBasedMatch();
		if (invitation != null)
		{
			Logger.d("Found invitation in GameHelper. Converting.");
			invFromNotif = ConvertInvitation(invitation);
			Logger.d("Found invitation in our GameHelper: " + invFromNotif);
		}
		else
		{
			Logger.d("No invitation in our GameHelper. Trying SignInHelperManager.");
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.SignInHelperManager");
			using AndroidJavaObject androidJavaObject = @class.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
			if (androidJavaObject.Call<bool>("hasInvitation", new object[0]))
			{
				invFromNotif = ConvertInvitation(androidJavaObject.Call<AndroidJavaObject>("getInvitation", new object[0]));
				Logger.d("Found invitation in SignInHelperManager: " + invFromNotif);
				androidJavaObject.Call("forgetInvitation");
			}
			else
			{
				Logger.d("No invitation in SignInHelperManager either.");
			}
		}
		TurnBasedMatch turnBasedMatch2 = null;
		if (turnBasedMatch != null)
		{
			Logger.d("Found match in GameHelper. Converting.");
			turnBasedMatch2 = JavaUtil.ConvertMatch(mUserId, turnBasedMatch);
			Logger.d("Match from GameHelper: " + turnBasedMatch2);
		}
		else
		{
			Logger.d("No match in our GameHelper. Trying SignInHelperManager.");
			AndroidJavaClass class2 = JavaUtil.GetClass("com.google.example.games.pluginsupport.SignInHelperManager");
			using AndroidJavaObject androidJavaObject2 = class2.CallStatic<AndroidJavaObject>("getInstance", new object[0]);
			if (androidJavaObject2.Call<bool>("hasTurnBasedMatch", new object[0]))
			{
				turnBasedMatch2 = JavaUtil.ConvertMatch(mUserId, androidJavaObject2.Call<AndroidJavaObject>("getTurnBasedMatch", new object[0]));
				Logger.d("Found match in SignInHelperManager: " + turnBasedMatch2);
				androidJavaObject2.Call("forgetTurnBasedMatch");
			}
			else
			{
				Logger.d("No match in SignInHelperManager either.");
			}
		}
		if (invFromNotif != null)
		{
			if (mInvitationDelegate != null)
			{
				Logger.d("Invoking invitation received delegate to deal with invitation  from notification.");
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					if (mInvitationDelegate != null)
					{
						mInvitationDelegate(invFromNotif, shouldAutoAccept: true);
					}
				});
			}
			else
			{
				Logger.d("No delegate to handle invitation from notification; queueing.");
				mInvitationFromNotification = invFromNotif;
			}
		}
		if (turnBasedMatch2 != null)
		{
			mTbmpClient.HandleMatchFromNotification(turnBasedMatch2);
		}
	}

	private Invitation ConvertInvitation(AndroidJavaObject invObj)
	{
		Logger.d("Converting Android invitation to our Invitation object.");
		string invId = invObj.Call<string>("getInvitationId", new object[0]);
		int num = invObj.Call<int>("getInvitationType", new object[0]);
		Participant inviter;
		using (AndroidJavaObject participant = invObj.Call<AndroidJavaObject>("getInviter", new object[0]))
		{
			inviter = JavaUtil.ConvertParticipant(participant);
		}
		int variant = invObj.Call<int>("getVariant", new object[0]);
		Invitation.InvType invType;
		switch (num)
		{
		case 0:
			invType = Invitation.InvType.RealTime;
			break;
		case 1:
			invType = Invitation.InvType.TurnBased;
			break;
		default:
			Logger.e("Unknown invitation type " + num);
			invType = Invitation.InvType.Unknown;
			break;
		}
		Invitation invitation = new Invitation(invType, invId, inviter, variant);
		Logger.d("Converted invitation: " + invitation.ToString());
		return invitation;
	}

	private void OnInvitationReceived(AndroidJavaObject invitationObj)
	{
		Logger.d("AndroidClient.OnInvitationReceived. Converting invitation...");
		Invitation inv = ConvertInvitation(invitationObj);
		Logger.d("Invitation: " + inv.ToString());
		if (mInvitationDelegate != null)
		{
			Logger.d("Delivering invitation to invitation received delegate.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				if (mInvitationDelegate != null)
				{
					mInvitationDelegate(inv, shouldAutoAccept: false);
				}
			});
		}
		else
		{
			Logger.w("AndroidClient.OnInvitationReceived discarding invitation because  delegate is null.");
		}
	}

	private void OnInvitationRemoved(string invitationId)
	{
		Logger.d("AndroidClient.OnInvitationRemoved: " + invitationId);
		ClearInvitationIfFromNotification(invitationId);
	}
}
