using System;
using UnityEngine;

[Serializable]
public class TownMain : MonoBehaviour
{
	public void Start()
	{
		if (!(SceneChanger.CurrentSceneName != "Town"))
		{
			GameLevelManager instance = GameLevelManager.Instance;
			QuestManager instance2 = QuestManager.Instance;
			ExtensionsModule.SetComponent<NotificationUpdate>(gameObject);
			WebBannerTown.InitTownWebBanner();
		}
	}

	public void Update()
	{
		if (!(SceneChanger.CurrentSceneName != "Town"))
		{
			DailyTask.UpdateCheckDailyTask(gameObject);
		}
	}
}
