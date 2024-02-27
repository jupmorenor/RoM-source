using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MyHomeStoryMain : MyhomeSubSceneTopMain
{
	[Serializable]
	public enum MY_HOME_STORY_MAIN
	{
		None,
		Diary,
		Max
	}

	public UILabelBase diaryLabel;

	public GameObject diaryListItemPrefab;

	public UITable diaryListTable;

	public UIScrollBar scroll;

	public GameObject diaryTopPage;

	private MY_HOME_STORY_MAIN mode;

	private MY_HOME_STORY_MAIN lastMode;

	protected DiaryListItem curSelect;

	protected int listCount;

	public MyHomeStoryMain()
	{
		mode = MY_HOME_STORY_MAIN.None;
		lastMode = MY_HOME_STORY_MAIN.None;
	}

	public override void StartCore()
	{
		SetDiary(null);
		mode = MY_HOME_STORY_MAIN.Diary;
	}

	public void InitList()
	{
		DateTime utcNow = MerlinDateTime.UtcNow;
		if (!diaryListItemPrefab || !diaryListTable)
		{
			return;
		}
		int i = 0;
		MStoryBooks[] all = MStoryBooks.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				if (!QuestManager.CheckQuestStoryDiary(all[i], utcNow))
				{
					continue;
				}
				GameObject gameObject = NGUITools.InstantiateWithoutUIPanel(diaryListItemPrefab) as GameObject;
				if ((bool)gameObject)
				{
					listCount++;
					DiaryListItem diaryListItem = ExtensionsModule.SetComponent<DiaryListItem>(gameObject);
					if ((bool)diaryListItem)
					{
						diaryListItem.Init(all[i]);
					}
					gameObject.transform.parent = diaryListTable.transform;
					gameObject.transform.localScale = Vector3.one;
					UIButtonMessage uIButtonMessage = ExtensionsModule.SetComponent<UIButtonMessage>(gameObject);
					if ((bool)uIButtonMessage)
					{
						uIButtonMessage.target = this.gameObject;
						uIButtonMessage.functionName = "PushSelect";
					}
				}
			}
			diaryListTable.Reposition();
		}
	}

	public override void SceneUpdate()
	{
		if (!IsChangingSituation && mode != lastMode)
		{
			lastMode = mode;
			if (mode == MY_HOME_STORY_MAIN.Diary)
			{
				InitList();
			}
		}
	}

	public void SetDiary(MStoryBooks diary)
	{
		diaryLabel.text = string.Empty;
		if (diary == null)
		{
			diaryTopPage.SetActive(value: true);
		}
		else if ((bool)diaryLabel)
		{
			diaryTopPage.SetActive(value: false);
			diaryLabel.text = diary.GetText();
		}
	}

	public int GetIndex(DiaryListItem listItem)
	{
		int result;
		if (!diaryListTable)
		{
			result = -1;
		}
		else if (!listItem)
		{
			result = -1;
		}
		else
		{
			int num = 0;
			IEnumerator enumerator = diaryListTable.transform.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					DiaryListItem component = transform.gameObject.GetComponent<DiaryListItem>();
					if ((bool)component)
					{
						if (RuntimeServices.EqualityOperator(component.storyBook, listItem.storyBook))
						{
							result = num;
							break;
						}
						num = checked(num + 1);
					}
					continue;
				}
				result = -1;
				break;
			}
		}
		return result;
	}

	public DiaryListItem GetDiaryListItem(int index)
	{
		object result;
		if (!diaryListTable)
		{
			result = null;
		}
		else if (index < 0 || listCount <= index)
		{
			result = null;
		}
		else
		{
			int num = 0;
			IEnumerator enumerator = diaryListTable.transform.GetEnumerator();
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					DiaryListItem component = transform.gameObject.GetComponent<DiaryListItem>();
					if ((bool)component)
					{
						if (index == num)
						{
							result = component;
							break;
						}
						num = checked(num + 1);
					}
					continue;
				}
				result = null;
				break;
			}
		}
		return (DiaryListItem)result;
	}

	public void Select(int index)
	{
		if ((bool)scroll && listCount > 0)
		{
			if (listCount > 1)
			{
				float num = (1f + scroll.barSize) / (float)checked(listCount - 1);
				iTween.ValueTo(gameObject, iTween.Hash("from", scroll.scrollValue, "to", num * (float)index, "time", 0.1f, "onupdate", "Scroll"));
			}
			DiaryListItem diaryListItem = GetDiaryListItem(index);
			Select(diaryListItem);
		}
	}

	public void Scroll(float pos)
	{
		if ((bool)scroll)
		{
			scroll.scrollValue = pos;
		}
	}

	public void Select(DiaryListItem nextSelect)
	{
		if (!nextSelect || !(nextSelect != curSelect))
		{
			return;
		}
		if ((bool)curSelect)
		{
			curSelect.Select(select: false);
		}
		curSelect = nextSelect;
		curSelect.Select(select: true);
		SetDiary(curSelect.storyBook);
		if (curSelect.storyBook != null)
		{
			UserData current = UserData.Current;
			if (curSelect.storyBook.Flag != null)
			{
				current?.userMiscInfo.flagData.set(curSelect.storyBook.Flag.Progname, 1);
			}
			if (curSelect.storyBook.NotFlag != null)
			{
				current?.userMiscInfo.flagData.delete(curSelect.storyBook.NotFlag.Progname);
			}
		}
	}

	public void PushNext()
	{
		int index = GetIndex(curSelect);
		checked
		{
			index++;
			if (index >= listCount)
			{
				index = listCount - 1;
			}
			Select(index);
		}
	}

	public void PushPrev()
	{
		int index = GetIndex(curSelect);
		index = checked(index - 1);
		if (index < 0)
		{
			index = 0;
		}
		Select(index);
	}

	public void PushSelect(GameObject obj)
	{
		if ((bool)obj)
		{
			DiaryListItem component = obj.GetComponent<DiaryListItem>();
			Select(component);
		}
	}

	public void PushBack()
	{
		BackMyhome();
	}
}
