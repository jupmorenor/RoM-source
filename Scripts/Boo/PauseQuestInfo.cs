using System;
using UnityEngine;

[Serializable]
public class PauseQuestInfo : MonoBehaviour
{
	public UILabelBase エリア名;

	public UILabelBase クエスト名;

	public UILabelBase クエスト説明;

	public UILabelBase クエスト種別;

	private MQuests quest;

	public UILabelBase AreaLabel => エリア名;

	public UILabelBase NameLabel => クエスト名;

	public UILabelBase DetailLabel => クエスト説明;

	public UILabelBase TypeLabel => クエスト種別;

	public void Update()
	{
		if (quest == null)
		{
			quest = QuestSession.Quest;
		}
		if (quest != null)
		{
			MAreas mAreaId = quest.MAreaId;
			if (mAreaId != null)
			{
				UIBasicUtility.SetLabel(AreaLabel, mAreaId.GetName());
			}
			else
			{
				UIBasicUtility.SetLabel(AreaLabel, "?");
			}
			UIBasicUtility.SetLabel(NameLabel, quest.GetName());
			UIBasicUtility.SetLabel(DetailLabel, quest.GetExplain());
			UIBasicUtility.SetLabel(TypeLabel, string.Empty);
		}
	}
}
