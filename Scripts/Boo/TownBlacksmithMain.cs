using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class TownBlacksmithMain : TownShopTopMain
{
	[Serializable]
	public enum MODE_TOWN_BLACKSMITH
	{
		None = -1,
		TopMenu = 1,
		Max = 2
	}

	public GameObject topMenu;

	protected MODE_TOWN_BLACKSMITH mode;

	protected MODE_TOWN_BLACKSMITH lastMode;

	private UILabelBase topSelif;

	public GameObject campaignPrefab;

	public Transform[] campaignPos;

	public Transform[] evoCampaignPos;

	public MODE_TOWN_BLACKSMITH Mode => mode;

	public TownBlacksmithMain()
	{
		mode = MODE_TOWN_BLACKSMITH.TopMenu;
		lastMode = MODE_TOWN_BLACKSMITH.None;
	}

	public override void StartCore()
	{
		ButtonBackHUD.SetActive(setActive: true);
		FaderCore.Instance.In();
		CampaignsController.InitCampaigns(campaignPos, campaignPrefab, isPowup: true);
		CampaignsController.InitCampaigns(evoCampaignPos, campaignPrefab, isPowup: false);
		int num = 0;
		lastMode = MODE_TOWN_BLACKSMITH.None;
		mode = MODE_TOWN_BLACKSMITH.TopMenu;
		situations = new UISituation[2];
		UISituation[] array = situations;
		array[RuntimeServices.NormalizeArrayIndex(array, 1)] = topMenu.GetComponent<UISituation>();
		UISituation situation = GetSituation(1);
		if (!(situation != null) || !(situation.gameObject != null))
		{
			throw new AssertionFailedException("(topSituation != null) and (topSituation.gameObject != null)");
		}
		GameObject gameObject = ExtensionsModule.FindChild(situation.gameObject, "Selif Text");
		topSelif = gameObject.GetComponent<UILabelBase>();
		initFlag = true;
	}

	public override void SceneUpdate()
	{
		if (initFlag && mode != lastMode)
		{
			if (mode == MODE_TOWN_BLACKSMITH.TopMenu)
			{
				UpdateTopSelif();
			}
			UISituation[] array = situations;
			ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
			lastMode = mode;
		}
	}

	public void UpdateTopSelif()
	{
		UserData current = UserData.Current;
		string text = null;
		if (string.IsNullOrEmpty(text))
		{
			text = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.BlackSmithNormal);
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new AssertionFailedException("工房吹き出しのメッセージが無い");
		}
		topSelif.text = text;
	}

	public override void OnDestroy()
	{
		GameLevelManager instance = GameLevelManager.Instance;
		if ((bool)instance && TownShopTopMain.townModels == null)
		{
			TownShopTopMain.townModels = instance.DontDestroyFromKeepSceneObjectAll();
		}
		if (TownShopTopMain.townModels == null || !destroy3DMode)
		{
			return;
		}
		int i = 0;
		GameObject[] array = TownShopTopMain.townModels;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				UnityEngine.Object.DestroyObject(array[i]);
			}
		}
		TownShopTopMain.townModels = null;
	}

	public void PushEvolution()
	{
		destroy3DMode = false;
		SceneChanger.ChangeTo(SceneID.Ui_BlacksmithEvolution);
	}

	public void PushPowerup()
	{
		destroy3DMode = false;
		SceneChanger.ChangeTo(SceneID.Ui_BlacksmithPowup);
	}

	public void PushPoppetPowerup()
	{
		destroy3DMode = false;
		SceneChanger.ChangeTo(SceneID.Ui_PetPowup);
	}

	public void PushPoppetEvolution()
	{
		destroy3DMode = false;
		SceneChanger.ChangeTo(SceneID.Ui_PetEvolution);
	}

	public void PushSell()
	{
		destroy3DMode = false;
		SceneChanger.ChangeTo(SceneID.Ui_BlacksmithSell);
	}

	public void PushBack()
	{
		BackTown();
	}
}
