using System;
using UnityEngine;

[Serializable]
public class DiaryListItem : MonoBehaviour
{
	public UILabelBase diaryIndexLabel;

	public UILabelBase diaryTitelLabel;

	public GameObject selectPanel;

	public GameObject newPanel;

	public MStoryBooks storyBook;

	public void Init(MStoryBooks storybook)
	{
		storyBook = storybook;
		diaryTitelLabel.text = storyBook.GetTitle();
		diaryIndexLabel.text = storyBook.Id.ToString();
		UserData current = UserData.Current;
		if (current != null && (bool)newPanel)
		{
			newPanel.SetActive(current.userMiscInfo.diaryData.getDiaryState(storyBook) <= 0);
		}
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void Select(bool select)
	{
		if ((bool)selectPanel)
		{
			selectPanel.SetActive(select);
		}
		UserData current = UserData.Current;
		if (current != null && (bool)newPanel)
		{
			current.userMiscInfo.diaryData.readDiary(storyBook);
			current.userMiscInfo.flagData.updateCondition();
			newPanel.SetActive(value: false);
		}
	}
}
