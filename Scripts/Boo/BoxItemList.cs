using System;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BoxItemList : UIListBase
{
	public bool isLookBox;

	public UIListItemDetail weapnDetail;

	public UIListItemDetail petDetail;

	private void Awake()
	{
		hookSettingListItem = boxHookSettingListItem;
		hookSetDetail = boxHookSetDetail;
		hookSort = boxHookSort;
		UnityEngine.Object.DestroyImmediate(weapnDetail.GetComponent<UIAutoTweener>());
		UnityEngine.Object.DestroyImmediate(petDetail.GetComponent<UIAutoTweener>());
		weapnDetail.gameObject.SetActive(value: false);
		petDetail.gameObject.SetActive(value: false);
	}

	public void SetInputBoxList(RespPlayerBox[] list)
	{
		if (!isInitFinished)
		{
			SortFuncs.SetWeaponPetListSortFuncs(this);
			Initialize(list, gameObject, autoTween: false);
		}
		else
		{
			UpdateData(list);
		}
	}

	public override long CreateID(object data)
	{
		RespPlayerBox respPlayerBox = data as RespPlayerBox;
		return respPlayerBox.Id.Value;
	}

	private bool boxHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		UIButtonMessage component = item.GetComponent<UIButtonMessage>();
		component.target = gameObject;
		component.functionName = "PushSelectItem";
		BoxListItem boxListItem = (BoxListItem)item;
		UserData current = UserData.Current;
		RespPlayerBox data = boxListItem.GetData<RespPlayerBox>();
		bool flag = current.IsUsing(data.Id);
		bool flag2 = current.IsFavorite(data);
		bool num = flag;
		if (!num)
		{
			num = flag2;
		}
		bool flag3 = num;
		boxListItem.SetState(flag, flag3);
		if (flag3)
		{
			RemoveSelect(boxListItem);
		}
		return true;
	}

	private bool boxHookSetDetail(UIListItem.Data data)
	{
		if (data != null)
		{
			RespPlayerBox data2 = data.GetData<RespPlayerBox>();
			if (data2.IsWeapon)
			{
				int num = 0;
				Vector3 localPosition = weapnDetail.transform.localPosition;
				float num2 = (localPosition.z = num);
				Vector3 vector2 = (weapnDetail.transform.localPosition = localPosition);
				int num3 = 100;
				Vector3 localPosition2 = petDetail.transform.localPosition;
				float num4 = (localPosition2.z = num3);
				Vector3 vector4 = (petDetail.transform.localPosition = localPosition2);
				detailWindow = weapnDetail;
			}
			else if (data2.IsPoppet)
			{
				int num5 = 100;
				Vector3 localPosition3 = weapnDetail.transform.localPosition;
				float num6 = (localPosition3.z = num5);
				Vector3 vector6 = (weapnDetail.transform.localPosition = localPosition3);
				int num7 = 0;
				Vector3 localPosition4 = petDetail.transform.localPosition;
				float num8 = (localPosition4.z = num7);
				Vector3 vector8 = (petDetail.transform.localPosition = localPosition4);
				detailWindow = petDetail;
			}
		}
		return false;
	}

	private bool boxHookSort(ref string key)
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
		return false;
	}
}
