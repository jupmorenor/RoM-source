using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames;

public class PlayGamesUserProfile : IUserProfile
{
	public string userName => string.Empty;

	public string id => string.Empty;

	public bool isFriend => false;

	public UserState state => UserState.Online;

	public Texture2D image => null;

	internal PlayGamesUserProfile()
	{
	}
}
