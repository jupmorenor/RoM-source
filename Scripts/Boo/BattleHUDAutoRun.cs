using System;
using UnityEngine;

[Serializable]
public class BattleHUDAutoRun : MonoBehaviour
{
	public GameObject labelRoot;

	public void Update()
	{
		bool isAutoBattleEnabled = UserData.Current.Config.IsAutoBattleEnabled;
		bool num = QuestSession.Quest != null;
		if (num)
		{
			num = QuestSession.Quest.AutoRunOn;
		}
		bool flag = num;
		bool num2 = isAutoBattleEnabled;
		if (num2)
		{
			num2 = flag;
		}
		bool flag2 = num2;
		if (labelRoot != null && labelRoot.activeSelf != flag2)
		{
			labelRoot.SetActive(flag2);
		}
	}
}
