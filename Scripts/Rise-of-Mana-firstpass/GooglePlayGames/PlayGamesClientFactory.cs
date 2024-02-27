using GooglePlayGames.Android;
using GooglePlayGames.BasicApi;
using UnityEngine;

namespace GooglePlayGames;

internal class PlayGamesClientFactory
{
	internal static IPlayGamesClient GetPlatformPlayGamesClient()
	{
		if (Application.isEditor)
		{
			return new DummyClient();
		}
		return new AndroidClient();
	}
}
