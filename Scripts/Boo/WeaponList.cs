using System;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WeaponList : UIListBase
{
	public bool oneSelectToggle;

	public void SetInputWeaponList(RespWeapon[] list)
	{
		if (!isInitFinished)
		{
			SortFuncs.SetWeaponPetListSortFuncs(this);
			Initialize(list, gameObject, autoTween: true);
		}
		else
		{
			UpdateData(list);
		}
	}

	public void Awake()
	{
		hookAutoFocusItem = weponHookAutoFocusItem;
		hookSettingListItem = weponHookSettingListItem;
		hookSort = weponHookSort;
	}

	public override long CreateID(object data)
	{
		RespWeapon respWeapon = data as RespWeapon;
		return respWeapon.Id.Value;
	}

	public bool weponHookAutoFocusItem(ref UIListItem.Data dstData)
	{
		UserData current = UserData.Current;
		dstData = null;
		RespWeapon respWeapon = ((!current.IsValidDeck2) ? current.MainWeapon : current.ActiveWeapon);
		int i = 0;
		UIListItem.Data[] dataList = GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(respWeapon.Id, dataList[i].GetData<RespWeapon>().Id))
			{
				dstData = dataList[i];
				break;
			}
		}
		return false;
	}

	public bool weponHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		if (!(item is WeaponListItem))
		{
			throw new AssertionFailedException("WeaponListItem じゃないUIListItemが渡されました");
		}
		WeaponListItem weaponListItem = (WeaponListItem)item;
		RespWeapon data = item.GetData<RespWeapon>();
		weaponListItem.SetWeapon(data);
		return false;
	}

	public bool weponHookSort(ref string key)
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
