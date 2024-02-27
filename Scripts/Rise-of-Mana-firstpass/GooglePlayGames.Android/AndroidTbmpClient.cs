using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class AndroidTbmpClient : ITurnBasedMultiplayerClient
{
	private class ResultProxy : AndroidJavaProxy
	{
		private AndroidTbmpClient mOwner;

		private string mMethod = "?";

		private Action<bool> mSuccessCallback;

		private Action<bool, TurnBasedMatch> mMatchCallback;

		private List<int> mSuccessCodes = new List<int>();

		internal ResultProxy(AndroidTbmpClient owner, string method)
			: base("com.google.android.gms.common.api.ResultCallback")
		{
			mOwner = owner;
			mSuccessCodes.Add(0);
			mSuccessCodes.Add(5);
			mSuccessCodes.Add(3);
			mMethod = method;
		}

		public void SetSuccessCallback(Action<bool> callback)
		{
			mSuccessCallback = callback;
		}

		public void SetMatchCallback(Action<bool, TurnBasedMatch> callback)
		{
			mMatchCallback = callback;
		}

		public void AddSuccessCodes(params int[] codes)
		{
			foreach (int item in codes)
			{
				mSuccessCodes.Add(item);
			}
		}

		public void onResult(AndroidJavaObject result)
		{
			Logger.d("ResultProxy got result for method: " + mMethod);
			int statusCode = JavaUtil.GetStatusCode(result);
			bool isSuccess = mSuccessCodes.Contains(statusCode);
			TurnBasedMatch match = null;
			if (isSuccess)
			{
				Logger.d("SUCCESS result from method " + mMethod + ": " + statusCode);
				if (mMatchCallback != null)
				{
					Logger.d("Attempting to get match from result of " + mMethod);
					AndroidJavaObject androidJavaObject = JavaUtil.CallNullSafeObjectMethod(result, "getMatch");
					if (androidJavaObject != null)
					{
						Logger.d("Successfully got match from result of " + mMethod);
						match = JavaUtil.ConvertMatch(mOwner.mClient.PlayerId, androidJavaObject);
						androidJavaObject.Dispose();
					}
					else
					{
						Logger.w("Got a NULL match from result of " + mMethod);
					}
				}
			}
			else
			{
				Logger.w("ERROR result from " + mMethod + ": " + statusCode);
			}
			if (mSuccessCallback != null)
			{
				Logger.d("Invoking success callback (success=" + isSuccess + ") for result of method " + mMethod);
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					mSuccessCallback(isSuccess);
				});
			}
			if (mMatchCallback != null)
			{
				Logger.d("Invoking match callback for result of method " + mMethod + ": (success=" + isSuccess + ", match=" + ((match != null) ? match.ToString() : "(null)"));
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					mMatchCallback(isSuccess, match);
				});
			}
		}
	}

	private class SelectOpponentsProxy : AndroidJavaProxy
	{
		private AndroidTbmpClient mOwner;

		private Action<bool, TurnBasedMatch> mCallback;

		private int mVariant;

		internal SelectOpponentsProxy(AndroidTbmpClient owner, Action<bool, TurnBasedMatch> callback, int variant)
			: base("com.google.example.games.pluginsupport.SelectOpponentsHelperActivity$Listener")
		{
			mOwner = owner;
			mCallback = callback;
			mVariant = variant;
		}

		public void onSelectOpponentsResult(bool success, AndroidJavaObject opponents, bool hasAutoMatch, AndroidJavaObject autoMatchCriteria)
		{
			mOwner.OnSelectOpponentsResult(success, opponents, hasAutoMatch, autoMatchCriteria, mCallback, mVariant);
		}
	}

	private class InvitationInboxProxy : AndroidJavaProxy
	{
		private AndroidTbmpClient mOwner;

		private Action<bool, TurnBasedMatch> mCallback;

		internal InvitationInboxProxy(AndroidTbmpClient owner, Action<bool, TurnBasedMatch> callback)
			: base("com.google.example.games.pluginsupport.InvitationInboxHelperActivity$Listener")
		{
			mOwner = owner;
			mCallback = callback;
		}

		public void onInvitationInboxResult(bool success, string invitationId)
		{
			mOwner.OnInvitationInboxResult(success, invitationId, mCallback);
		}

		public void onTurnBasedMatch(AndroidJavaObject match)
		{
			mOwner.OnInvitationInboxTurnBasedMatch(match, mCallback);
		}
	}

	private AndroidClient mClient;

	private int mMaxMatchDataSize;

	private TurnBasedMatch mMatchFromNotification;

	private MatchDelegate mMatchDelegate;

	internal AndroidTbmpClient(AndroidClient client)
	{
		mClient = client;
	}

	public void OnSignInSucceeded()
	{
		Logger.d("AndroidTbmpClient.OnSignInSucceeded");
		Logger.d("Querying for max match data size...");
		mMaxMatchDataSize = mClient.GHManager.CallGmsApi<int>("games.Games", "TurnBasedMultiplayer", "getMaxMatchDataSize", new object[0]);
		Logger.d("Max match data size: " + mMaxMatchDataSize);
	}

	public void CreateQuickMatch(int minOpponents, int maxOpponents, int variant, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d($"AndroidTbmpClient.CreateQuickMatch, opponents {minOpponents}-{maxOpponents}, var {variant}");
		mClient.CallClientApi("tbmp create quick game", delegate
		{
			ResultProxy resultProxy = new ResultProxy(this, "createMatch");
			resultProxy.SetMatchCallback(callback);
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.TbmpUtils");
			using AndroidJavaObject androidJavaObject = @class.CallStatic<AndroidJavaObject>("createQuickMatch", new object[4]
			{
				mClient.GHManager.GetApiClient(),
				minOpponents,
				maxOpponents,
				variant
			});
			androidJavaObject.Call("setResultCallback", resultProxy);
		}, delegate(bool success)
		{
			if (!success)
			{
				Logger.w("Failed to create tbmp quick match: client disconnected.");
				if (callback != null)
				{
					callback(arg1: false, null);
				}
			}
		});
	}

	public void CreateWithInvitationScreen(int minOpponents, int maxOpponents, int variant, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d($"AndroidTbmpClient.CreateWithInvitationScreen, opponents {minOpponents}-{maxOpponents}, variant {variant}");
		mClient.CallClientApi("tbmp launch invitation screen", delegate
		{
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.SelectOpponentsHelperActivity");
			@class.CallStatic("launch", false, mClient.GetActivity(), new SelectOpponentsProxy(this, callback, variant), Logger.DebugLogEnabled, minOpponents, maxOpponents);
		}, delegate(bool success)
		{
			if (!success)
			{
				Logger.w("Failed to create tbmp w/ invite screen: client disconnected.");
				if (callback != null)
				{
					callback(arg1: false, null);
				}
			}
		});
	}

	public void AcceptFromInbox(Action<bool, TurnBasedMatch> callback)
	{
		Logger.d($"AndroidTbmpClient.AcceptFromInbox");
		mClient.CallClientApi("tbmp launch inbox", delegate
		{
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.InvitationInboxHelperActivity");
			@class.CallStatic("launch", false, mClient.GetActivity(), new InvitationInboxProxy(this, callback), Logger.DebugLogEnabled);
		}, delegate(bool success)
		{
			if (!success)
			{
				Logger.w("Failed to accept tbmp w/ inbox: client disconnected.");
				if (callback != null)
				{
					callback(arg1: false, null);
				}
			}
		});
	}

	public void AcceptInvitation(string invitationId, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d("AndroidTbmpClient.AcceptInvitation invitationId=" + invitationId);
		TbmpApiCall("accept invitation", "acceptInvitation", null, callback, invitationId);
	}

	public void DeclineInvitation(string invitationId)
	{
		Logger.d("AndroidTbmpClient.DeclineInvitation, invitationId=" + invitationId);
		TbmpApiCall("decline invitation", "declineInvitation", null, null, invitationId);
	}

	private void TbmpApiCall(string simpleDesc, string methodName, Action<bool> callback, Action<bool, TurnBasedMatch> tbmpCallback, params object[] args)
	{
		mClient.CallClientApi(simpleDesc, delegate
		{
			ResultProxy resultProxy = new ResultProxy(this, methodName);
			if (callback != null)
			{
				resultProxy.SetSuccessCallback(callback);
			}
			if (tbmpCallback != null)
			{
				resultProxy.SetMatchCallback(tbmpCallback);
			}
			mClient.GHManager.CallGmsApiWithResult("games.Games", "TurnBasedMultiplayer", methodName, resultProxy, args);
		}, delegate(bool success)
		{
			if (!success)
			{
				Logger.w("Failed to " + simpleDesc + ": client disconnected.");
				if (callback != null)
				{
					callback(obj: false);
				}
			}
		});
	}

	public void TakeTurn(string matchId, byte[] data, string pendingParticipantId, Action<bool> callback)
	{
		Logger.d(string.Format("AndroidTbmpClient.TakeTurn matchId={0}, data={1}, pending={2}", matchId, (data != null) ? ("[" + data.Length + "bytes]") : "(null)", pendingParticipantId));
		TbmpApiCall("tbmp take turn", "takeTurn", callback, null, matchId, data, pendingParticipantId);
	}

	public int GetMaxMatchDataSize()
	{
		return mMaxMatchDataSize;
	}

	public void Finish(string matchId, byte[] data, MatchOutcome outcome, Action<bool> callback)
	{
		Logger.d(string.Format("AndroidTbmpClient.Finish matchId={0}, data={1} outcome={2}", matchId, (data != null) ? (data.Length + " bytes") : "(null)", outcome));
		Logger.d("Preparing list of participant results as Android ArrayList.");
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.ArrayList");
		if (outcome != null)
		{
			foreach (string participantId in outcome.ParticipantIds)
			{
				Logger.d("Converting participant result to Android object: " + participantId);
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("com.google.android.gms.games.multiplayer.ParticipantResult", participantId, JavaUtil.GetAndroidParticipantResult(outcome.GetResultFor(participantId)), outcome.GetPlacementFor(participantId));
				Logger.d("Adding participant result to Android ArrayList.");
				androidJavaObject.Call<bool>("add", new object[1] { androidJavaObject2 });
				androidJavaObject2.Dispose();
			}
		}
		TbmpApiCall("tbmp finish w/ outcome", "finishMatch", callback, null, matchId, data, androidJavaObject);
	}

	public void AcknowledgeFinished(string matchId, Action<bool> callback)
	{
		Logger.d("AndroidTbmpClient.AcknowledgeFinished, matchId=" + matchId);
		TbmpApiCall("tbmp ack finish", "finishMatch", callback, null, matchId);
	}

	public void Leave(string matchId, Action<bool> callback)
	{
		Logger.d("AndroidTbmpClient.Leave, matchId=" + matchId);
		TbmpApiCall("tbmp leave", "leaveMatch", callback, null, matchId);
	}

	public void LeaveDuringTurn(string matchId, string pendingParticipantId, Action<bool> callback)
	{
		Logger.d("AndroidTbmpClient.LeaveDuringTurn, matchId=" + matchId + ", pending=" + pendingParticipantId);
		TbmpApiCall("tbmp leave during turn", "leaveMatchDuringTurn", callback, null, matchId, pendingParticipantId);
	}

	public void Cancel(string matchId, Action<bool> callback)
	{
		Logger.d("AndroidTbmpClient.Cancel, matchId=" + matchId);
		TbmpApiCall("tbmp cancel", "cancelMatch", callback, null, matchId);
	}

	public void Rematch(string matchId, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d("AndroidTbmpClient.Rematch, matchId=" + matchId);
		TbmpApiCall("tbmp rematch", "rematch", null, callback, matchId);
	}

	public void RegisterMatchDelegate(MatchDelegate deleg)
	{
		Logger.d("AndroidTbmpClient.RegisterMatchDelegate");
		if (deleg == null)
		{
			Logger.w("Can't register a null match delegate.");
			return;
		}
		mMatchDelegate = deleg;
		if (mMatchFromNotification != null)
		{
			Logger.d("Delivering pending match to the newly registered delegate.");
			TurnBasedMatch match = mMatchFromNotification;
			mMatchFromNotification = null;
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				deleg(match, shouldAutoLaunch: true);
			});
		}
	}

	private void OnSelectOpponentsResult(bool success, AndroidJavaObject opponents, bool hasAutoMatch, AndroidJavaObject autoMatchCriteria, Action<bool, TurnBasedMatch> callback, int variant)
	{
		Logger.d("AndroidTbmpClient.OnSelectOpponentsResult, success=" + success + ", hasAutoMatch=" + hasAutoMatch);
		if (!success)
		{
			Logger.w("Tbmp select opponents dialog terminated with failure.");
			if (callback != null)
			{
				Logger.d("Reporting select-opponents dialog failure to callback.");
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					callback(arg1: false, null);
				});
			}
			return;
		}
		Logger.d("Creating TBMP match from opponents received from dialog.");
		mClient.CallClientApi("create match w/ opponents from dialog", delegate
		{
			ResultProxy resultProxy = new ResultProxy(this, "createMatch");
			resultProxy.SetMatchCallback(callback);
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.TbmpUtils");
			using AndroidJavaObject androidJavaObject = @class.CallStatic<AndroidJavaObject>("create", new object[4]
			{
				mClient.GHManager.GetApiClient(),
				opponents,
				variant,
				(!hasAutoMatch) ? null : autoMatchCriteria
			});
			androidJavaObject.Call("setResultCallback", resultProxy);
		}, delegate(bool ok)
		{
			if (!ok)
			{
				Logger.w("Failed to create match w/ opponents from dialog: client disconnected.");
				if (callback != null)
				{
					callback(arg1: false, null);
				}
			}
		});
	}

	private void OnInvitationInboxResult(bool success, string invitationId, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d("AndroidTbmpClient.OnInvitationInboxResult, success=" + success + ", invitationId=" + invitationId);
		if (!success)
		{
			Logger.w("Tbmp invitation inbox returned failure result.");
			if (callback != null)
			{
				Logger.d("Reporting tbmp invitation inbox failure to callback.");
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					callback(arg1: false, null);
				});
			}
		}
		else
		{
			Logger.d("Accepting invite received from inbox: " + invitationId);
			TbmpApiCall("accept invite returned from inbox", "acceptInvitation", null, callback, invitationId);
		}
	}

	private void OnInvitationInboxTurnBasedMatch(AndroidJavaObject matchObj, Action<bool, TurnBasedMatch> callback)
	{
		Logger.d("AndroidTbmpClient.OnInvitationTurnBasedMatch");
		Logger.d("Converting received match to our format...");
		TurnBasedMatch match = JavaUtil.ConvertMatch(mClient.PlayerId, matchObj);
		Logger.d("Resulting match: " + match);
		if (callback != null)
		{
			Logger.d("Invoking match callback w/ success.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				callback(arg1: true, match);
			});
		}
	}

	internal void HandleMatchFromNotification(TurnBasedMatch match)
	{
		Logger.d("AndroidTbmpClient.HandleMatchFromNotification");
		Logger.d("Got match from notification: " + match);
		if (mMatchDelegate != null)
		{
			Logger.d("Delivering match directly to match delegate.");
			MatchDelegate del = mMatchDelegate;
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				del(match, shouldAutoLaunch: true);
			});
		}
		else
		{
			Logger.d("Since we have no match delegate, holding on to the match until we have one.");
			mMatchFromNotification = match;
		}
	}
}
