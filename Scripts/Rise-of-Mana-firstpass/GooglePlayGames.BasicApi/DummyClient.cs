using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;

namespace GooglePlayGames.BasicApi;

public class DummyClient : IPlayGamesClient
{
	public void Authenticate(Action<bool> callback, bool silent)
	{
		callback?.Invoke(obj: false);
	}

	public bool IsAuthenticated()
	{
		return false;
	}

	public void SignOut()
	{
	}

	public string GetUserId()
	{
		return "DummyID";
	}

	public string GetUserDisplayName()
	{
		return "Player";
	}

	public List<Achievement> GetAchievements()
	{
		return new List<Achievement>();
	}

	public Achievement GetAchievement(string achId)
	{
		return null;
	}

	public void UnlockAchievement(string achId, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public void RevealAchievement(string achId, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public void IncrementAchievement(string achId, int steps, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public void ShowAchievementsUI()
	{
	}

	public void ShowLeaderboardUI(string lbId)
	{
	}

	public void SubmitScore(string lbId, long score, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public void LoadState(int slot, OnStateLoadedListener listener)
	{
		listener?.OnStateLoaded(success: false, slot, null);
	}

	public void UpdateState(int slot, byte[] data, OnStateLoadedListener listener)
	{
	}

	public void SetCloudCacheEncrypter(BufferEncrypter encrypter)
	{
	}

	public IRealTimeMultiplayerClient GetRtmpClient()
	{
		return null;
	}

	public ITurnBasedMultiplayerClient GetTbmpClient()
	{
		return null;
	}

	public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg)
	{
	}

	public Invitation GetInvitationFromNotification()
	{
		return null;
	}

	public bool HasInvitationFromNotification()
	{
		return false;
	}
}
