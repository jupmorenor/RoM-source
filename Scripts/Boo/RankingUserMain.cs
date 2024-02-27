using System;

[Serializable]
public class RankingUserMain : UIMain
{
	public void PushUnionRanking()
	{
		SceneChanger.ChangeTo(SceneID.Ui_RankingUnion);
	}

	public void PushBack()
	{
		SceneChanger.ChangeTo(SceneID.Ui_MessageBoard);
	}
}
