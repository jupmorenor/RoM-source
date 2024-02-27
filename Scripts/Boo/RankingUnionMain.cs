using System;

[Serializable]
public class RankingUnionMain : UIMain
{
	public void PushUserRanking()
	{
		SceneChanger.ChangeTo(SceneID.Ui_RankingUser);
	}

	public void PushBack()
	{
		SceneChanger.ChangeTo(SceneID.Ui_MessageBoard);
	}
}
