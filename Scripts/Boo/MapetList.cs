using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MapetList : UIListBase
{
	public bool deleteUIPanel;

	public __MapetList_DefaultSortFunc_0024callable100_00248_31__ defaultSortFunc;

	public bool oneSelectToggle;

	public bool iconScaleAnim;

	public __MapetList_DefaultSortFunc_0024callable100_00248_31__ DefaultSortFunc
	{
		get
		{
			return defaultSortFunc;
		}
		set
		{
			defaultSortFunc = value;
		}
	}

	public MapetList()
	{
		defaultSortFunc = SortFuncs.SetWeaponPetListSortFuncs;
		iconScaleAnim = true;
	}

	public void SetInputMapetList(RespPoppet[] list)
	{
		if (!isInitFinished)
		{
			if (null != defaultSortFunc)
			{
				defaultSortFunc(this);
			}
			Initialize(list, gameObject, autoTween: true);
		}
		else
		{
			UpdateData(list);
		}
	}

	public void Awake()
	{
		hookAutoFocusItem = poppetHookAutoFocusItem;
		hookSettingListItem = poppetHookSettingListItem;
		hookSort = poppetHookSort;
	}

	public override long CreateID(object data)
	{
		RespPoppet respPoppet = data as RespPoppet;
		return respPoppet.Id.Value;
	}

	public bool poppetHookAutoFocusItem(ref UIListItem.Data dstData)
	{
		UserData current = UserData.Current;
		dstData = null;
		RespPoppet currentPoppetNewOrOldDeck = current.CurrentPoppetNewOrOldDeck;
		int i = 0;
		UIListItem.Data[] dataList = GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(currentPoppetNewOrOldDeck.Id, dataList[i].GetData<RespPoppet>().Id))
			{
				dstData = dataList[i];
				break;
			}
		}
		return true;
	}

	public bool poppetHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		if (!(item is MapetListItem))
		{
			throw new AssertionFailedException("MapetListItem じゃないUIListItemが渡されました");
		}
		MapetListItem mapetListItem = (MapetListItem)item;
		RespPoppet data = item.GetData<RespPoppet>();
		mapetListItem.deleteUIPanel = deleteUIPanel;
		mapetListItem.SetMapet(data);
		return false;
	}

	public bool poppetHookSort(ref string key)
	{
		if (sortTypeName != null)
		{
			int num = 0;
			int length = sortTypeName.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				string[] array = sortTypeName;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == key)
				{
					int index = checked(num2 + 1) % sortTypeName.Length;
					string[] array2 = sortTypeName;
					key = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					break;
				}
			}
		}
		return false;
	}
}
