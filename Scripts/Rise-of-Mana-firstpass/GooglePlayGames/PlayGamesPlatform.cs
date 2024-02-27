using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames;

public class PlayGamesPlatform : ISocialPlatform
{
	private static PlayGamesPlatform sInstance;

	private PlayGamesLocalUser mLocalUser;

	private IPlayGamesClient mClient;

	private string mDefaultLbUi;

	private Dictionary<string, string> mIdMap = new Dictionary<string, string>();

	public static PlayGamesPlatform Instance
	{
		get
		{
			if (sInstance == null)
			{
				sInstance = new PlayGamesPlatform();
			}
			return sInstance;
		}
	}

	public static bool DebugLogEnabled
	{
		get
		{
			return Logger.DebugLogEnabled;
		}
		set
		{
			Logger.DebugLogEnabled = value;
		}
	}

	public IRealTimeMultiplayerClient RealTime => mClient.GetRtmpClient();

	public ITurnBasedMultiplayerClient TurnBased => mClient.GetTbmpClient();

	public ILocalUser localUser => mLocalUser;

	private PlayGamesPlatform()
	{
		mLocalUser = new PlayGamesLocalUser(this);
	}

	public static PlayGamesPlatform Activate()
	{
		Logger.d("Activating PlayGamesPlatform.");
		Social.Active = Instance;
		Logger.d("PlayGamesPlatform activated: " + Social.Active);
		return Instance;
	}

	public void AddIdMapping(string fromId, string toId)
	{
		mIdMap[fromId] = toId;
	}

	public void Authenticate(Action<bool> callback)
	{
		Authenticate(callback, silent: false);
	}

	public void Authenticate(Action<bool> callback, bool silent)
	{
		if (mClient == null)
		{
			Logger.d("Creating platform-specific Play Games client.");
			mClient = PlayGamesClientFactory.GetPlatformPlayGamesClient();
		}
		mClient.Authenticate(callback, silent);
	}

	public void Authenticate(ILocalUser unused, Action<bool> callback)
	{
		Authenticate(callback, silent: false);
	}

	public bool IsAuthenticated()
	{
		return mClient != null && mClient.IsAuthenticated();
	}

	public void SignOut()
	{
		if (mClient != null)
		{
			mClient.SignOut();
		}
	}

	public void LoadUsers(string[] userIDs, Action<IUserProfile[]> callback)
	{
		Logger.w("PlayGamesPlatform.LoadUsers is not implemented.");
		callback?.Invoke(new IUserProfile[0]);
	}

	public string GetUserId()
	{
		if (!IsAuthenticated())
		{
			Logger.e("GetUserId() can only be called after authentication.");
			return "0";
		}
		return mClient.GetUserId();
	}

	public string GetUserDisplayName()
	{
		if (!IsAuthenticated())
		{
			Logger.e("GetUserDisplayName can only be called after authentication.");
			return string.Empty;
		}
		return mClient.GetUserDisplayName();
	}

	public void ReportProgress(string achievementID, double progress, Action<bool> callback)
	{
		if (!IsAuthenticated())
		{
			Logger.e("ReportProgress can only be called after authentication.");
			callback?.Invoke(obj: false);
			return;
		}
		Logger.d("ReportProgress, " + achievementID + ", " + progress);
		achievementID = MapId(achievementID);
		if (progress < 1E-06)
		{
			Logger.d("Progress 0.00 interpreted as request to reveal.");
			mClient.RevealAchievement(achievementID, callback);
			return;
		}
		bool flag = false;
		int num = 0;
		int num2 = 0;
		Achievement achievement = mClient.GetAchievement(achievementID);
		if (achievement == null)
		{
			Logger.w("Unable to locate achievement " + achievementID);
			Logger.w("As a quick fix, assuming it's standard.");
			flag = false;
		}
		else
		{
			flag = achievement.IsIncremental;
			num = achievement.CurrentSteps;
			num2 = achievement.TotalSteps;
			Logger.d("Achievement is " + ((!flag) ? "STANDARD" : "INCREMENTAL"));
			if (flag)
			{
				Logger.d("Current steps: " + num + "/" + num2);
			}
		}
		if (flag)
		{
			Logger.d("Progress " + progress + " interpreted as incremental target (approximate).");
			int num3 = (int)(progress * (double)num2);
			int num4 = num3 - num;
			Logger.d("Target steps: " + num3 + ", cur steps:" + num);
			Logger.d("Steps to increment: " + num4);
			if (num4 > 0)
			{
				mClient.IncrementAchievement(achievementID, num4, callback);
			}
		}
		else
		{
			Logger.d("Progress " + progress + " interpreted as UNLOCK.");
			mClient.UnlockAchievement(achievementID, callback);
		}
	}

	public void IncrementAchievement(string achievementID, int steps, Action<bool> callback)
	{
		if (!IsAuthenticated())
		{
			Logger.e("IncrementAchievement can only be called after authentication.");
			callback?.Invoke(obj: false);
			return;
		}
		Logger.d("IncrementAchievement: " + achievementID + ", steps " + steps);
		achievementID = MapId(achievementID);
		mClient.IncrementAchievement(achievementID, steps, callback);
	}

	public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
	{
		Logger.w("PlayGamesPlatform.LoadAchievementDescriptions is not implemented.");
		callback?.Invoke(new IAchievementDescription[0]);
	}

	public void LoadAchievements(Action<IAchievement[]> callback)
	{
		Logger.w("PlayGamesPlatform.LoadAchievements is not implemented.");
		callback?.Invoke(new IAchievement[0]);
	}

	public IAchievement CreateAchievement()
	{
		return new PlayGamesAchievement();
	}

	public void ReportScore(long score, string board, Action<bool> callback)
	{
		if (!IsAuthenticated())
		{
			Logger.e("ReportScore can only be called after authentication.");
			callback?.Invoke(obj: false);
			return;
		}
		Logger.d("ReportScore: score=" + score + ", board=" + board);
		string lbId = MapId(board);
		mClient.SubmitScore(lbId, score, callback);
	}

	public void LoadScores(string leaderboardID, Action<IScore[]> callback)
	{
		Logger.w("PlayGamesPlatform.LoadScores not implemented.");
		callback?.Invoke(new IScore[0]);
	}

	public ILeaderboard CreateLeaderboard()
	{
		Logger.w("PlayGamesPlatform.CreateLeaderboard not implemented. Returning null.");
		return null;
	}

	public void ShowAchievementsUI()
	{
		if (!IsAuthenticated())
		{
			Logger.e("ShowAchievementsUI can only be called after authentication.");
			return;
		}
		Logger.d("ShowAchievementsUI");
		mClient.ShowAchievementsUI();
	}

	public void ShowLeaderboardUI()
	{
		if (!IsAuthenticated())
		{
			Logger.e("ShowLeaderboardUI can only be called after authentication.");
			return;
		}
		Logger.d("ShowLeaderboardUI");
		mClient.ShowLeaderboardUI(MapId(mDefaultLbUi));
	}

	public void ShowLeaderboardUI(string lbId)
	{
		if (!IsAuthenticated())
		{
			Logger.e("ShowLeaderboardUI can only be called after authentication.");
			return;
		}
		Logger.d("ShowLeaderboardUI, lbId=" + lbId);
		if (lbId != null)
		{
			lbId = MapId(lbId);
		}
		mClient.ShowLeaderboardUI(lbId);
	}

	public void SetDefaultLeaderboardForUI(string lbid)
	{
		Logger.d("SetDefaultLeaderboardForUI: " + lbid);
		if (lbid != null)
		{
			lbid = MapId(lbid);
		}
		mDefaultLbUi = lbid;
	}

	public void LoadFriends(ILocalUser user, Action<bool> callback)
	{
		Logger.w("PlayGamesPlatform.LoadFriends not implemented.");
		callback?.Invoke(obj: false);
	}

	public void LoadScores(ILeaderboard board, Action<bool> callback)
	{
		Logger.w("PlayGamesPlatform.LoadScores not implemented.");
		callback?.Invoke(obj: false);
	}

	public bool GetLoading(ILeaderboard board)
	{
		return false;
	}

	public void SetCloudCacheEncrypter(BufferEncrypter encrypter)
	{
		mClient.SetCloudCacheEncrypter(encrypter);
	}

	public void LoadState(int slot, OnStateLoadedListener listener)
	{
		if (!IsAuthenticated())
		{
			Logger.e("LoadState can only be called after authentication.");
			listener?.OnStateLoaded(success: false, slot, null);
		}
		else
		{
			mClient.LoadState(slot, listener);
		}
	}

	public void UpdateState(int slot, byte[] data, OnStateLoadedListener listener)
	{
		if (!IsAuthenticated())
		{
			Logger.e("UpdateState can only be called after authentication.");
			listener?.OnStateSaved(success: false, slot);
		}
		else
		{
			mClient.UpdateState(slot, data, listener);
		}
	}

	public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg)
	{
		mClient.RegisterInvitationDelegate(deleg);
	}

	private string MapId(string id)
	{
		if (id == null)
		{
			return null;
		}
		if (mIdMap.ContainsKey(id))
		{
			string text = mIdMap[id];
			Logger.d("Mapping alias " + id + " to ID " + text);
			return text;
		}
		return id;
	}
}
