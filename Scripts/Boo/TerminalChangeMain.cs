using System;
using UnityEngine;

[Serializable]
public class TerminalChangeMain : MonoBehaviour
{
	public void Start()
	{
		SceneTitleHUD.UpdateTitle(MTexts.Msg("$TC_DATA_INHERITING_TITLE"));
		InfomationBarHUD.UpdateText(MTexts.Msg("$TC_DATA_INHERITING_INFO"));
	}

	public void Update()
	{
	}

	public void CheckInputData()
	{
		SceneChanger.ChangeTo(SceneID.Myhome);
	}

	public void PushBack(GameObject obj)
	{
		if (SceneChanger.LastSceneName == "Ui_CreateUserID")
		{
			SceneChanger.ChangeTo(SceneID.Ui_CreateUserID);
		}
		else
		{
			SceneChanger.ChangeTo(SceneID.Boot);
		}
	}
}
