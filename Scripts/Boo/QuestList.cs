using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class QuestList : UIListBase
{
	protected MAreas area;

	private string initQuestName;

	public bool oneSelectToggle;

	protected int index;

	public UILabelBase noListItemLabel;

	protected MCampaigns[] mcampaigns;

	protected string[] listItemSpriteName;

	public MQuests CurInfo
	{
		get
		{
			UIListItem[] selectItems = SelectItems;
			return (selectItems == null) ? null : ((selectItems.Length > 0) ? selectItems[0].GetData<MQuests>() : null);
		}
	}

	public QuestList()
	{
		mcampaigns = new MCampaigns[0];
		listItemSpriteName = new string[5] { "subwindow_a04", "subwindow_a04", "subwindow_a02", "subwindow_a06", "subwindow_a07" };
	}

	public void SetInputQuestList(MQuests[] list, MAreas area)
	{
		this.area = area;
		index = 0;
		if (!isInitFinished)
		{
			if (list != null)
			{
				Initialize(list, gameObject, autoTween: false);
			}
		}
		else
		{
			UpdateData(list);
		}
		if (Count() <= 0)
		{
			if (null != noListItemLabel)
			{
				noListItemLabel.gameObject.SetActive(value: true);
			}
		}
		else if (null != noListItemLabel)
		{
			noListItemLabel.gameObject.SetActive(value: false);
		}
	}

	public void Awake()
	{
		hookAutoFocusItem = questHookAutoFocusItem;
		hookSettingListItem = questHookSettingListItem;
		hookSort = questHookSort;
		mcampaigns = new MCampaigns[0];
		mcampaigns = (MCampaigns[])RuntimeServices.AddArrays(typeof(MCampaigns), mcampaigns, MCampaignsUtil.GetCurrentQuestCampaign(null));
		if (null != noListItemLabel)
		{
			noListItemLabel.gameObject.SetActive(value: false);
		}
	}

	public void InitList(string name)
	{
		bool flag = true;
		object obj = null;
		initQuestName = name;
	}

	public override long CreateID(object data)
	{
		MQuests mQuests = data as MQuests;
		return mQuests.Id;
	}

	public bool questHookAutoFocusItem(ref UIListItem.Data dstData)
	{
		dstData = null;
		object obj = null;
		int i = 0;
		UIListItem.Data[] dataList = GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (!RuntimeServices.ToBool(obj))
			{
				obj = dataList[i];
			}
			if (initQuestName == dataList[i].GetData<MQuests>().GetName())
			{
				dstData = dataList[i];
			}
		}
		if (dstData == null)
		{
			object obj2 = obj;
			if (!(obj2 is UIListItem.Data))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(UIListItem.Data));
			}
			dstData = (UIListItem.Data)obj2;
		}
		return true;
	}

	public bool questHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		if (!(item is QuestListItem))
		{
			throw new AssertionFailedException("QuestListItem じゃないUIListItemが渡されました");
		}
		QuestListItem questListItem = (QuestListItem)item;
		MQuests data = item.GetData<MQuests>();
		questListItem.SetQuest(index, data, area, mcampaigns);
		if (data.Rank >= listItemSpriteName.Length)
		{
			throw new AssertionFailedException("quest.Rank < listItemSpriteName.Length");
		}
		string[] array = listItemSpriteName;
		string bgPanelSprite = array[RuntimeServices.NormalizeArrayIndex(array, data.Rank)];
		questListItem.SetBgPanelSprite(bgPanelSprite);
		checked
		{
			index++;
			return true;
		}
	}

	public bool questHookSort(ref string key)
	{
		return true;
	}
}
