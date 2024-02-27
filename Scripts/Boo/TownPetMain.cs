using System;
using UnityEngine;

[Serializable]
public class TownPetMain : UIMain
{
	[NonSerialized]
	public static GameObject townModel;

	[NonSerialized]
	public static GameObject npcModel;

	public override void SceneStart()
	{
		SceneTitleHUD.UpdateTitle("ぬいぐるみ屋");
		InfomationBarHUD.UpdateText("魔ペットの強化、進化、売却ができます。");
		if ((bool)townModel)
		{
			townModel.SetActive(value: true);
		}
		if ((bool)npcModel)
		{
			npcModel.SetActive(value: true);
		}
	}

	public void PushBack()
	{
		SceneChanger.ChangeTo(SceneID.Town);
		if ((bool)townModel)
		{
			UnityEngine.Object.DestroyObject(townModel);
		}
		townModel = null;
		if ((bool)npcModel)
		{
			UnityEngine.Object.DestroyObject(npcModel);
		}
		npcModel = null;
	}

	public void PushPowerup()
	{
		SceneChanger.ChangeTo(SceneID.Ui_PetPowup);
		if ((bool)townModel)
		{
			townModel.SetActive(value: false);
		}
		if ((bool)npcModel)
		{
			npcModel.SetActive(value: false);
		}
	}

	public void PushEvolution()
	{
		if ((bool)townModel)
		{
			townModel.SetActive(value: false);
		}
		if ((bool)npcModel)
		{
			npcModel.SetActive(value: false);
		}
	}

	public void PushSell()
	{
		if ((bool)townModel)
		{
			townModel.SetActive(value: false);
		}
		if ((bool)npcModel)
		{
			npcModel.SetActive(value: false);
		}
	}
}
