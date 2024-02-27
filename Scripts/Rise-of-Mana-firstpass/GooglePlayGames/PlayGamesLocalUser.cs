using System;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames;

public class PlayGamesLocalUser : PlayGamesUserProfile, IUserProfile, ILocalUser
{
	private PlayGamesPlatform mPlatform;

	public IUserProfile[] friends => new IUserProfile[0];

	public bool authenticated => mPlatform.IsAuthenticated();

	public bool underage => true;

	public new string userName => (!authenticated) ? string.Empty : mPlatform.GetUserDisplayName();

	public new string id => (!authenticated) ? string.Empty : mPlatform.GetUserId();

	public new bool isFriend => true;

	public new UserState state => UserState.Online;

	internal PlayGamesLocalUser(PlayGamesPlatform plaf)
	{
		mPlatform = plaf;
	}

	public void Authenticate(Action<bool> callback)
	{
		mPlatform.Authenticate(callback);
	}

	public void Authenticate(Action<bool> callback, bool silent)
	{
		mPlatform.Authenticate(callback, silent);
	}

	public void LoadFriends(Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}
}
