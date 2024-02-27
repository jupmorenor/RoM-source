using System;

[Serializable]
public class ItemOverflow : UIMain
{
	public override void SceneStart()
	{
		SceneTitleHUD.UpdateTitle("所持数オーバー");
		InfomationBarHUD.UpdateText("倉庫がいっぱいです。なんとかして。");
	}

	public void PushKakuchou()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TownStoneShop);
	}

	public void PushGousei()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TownBlacksmith);
	}

	public void PushBaikyaku()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TownBlacksmith);
	}
}
