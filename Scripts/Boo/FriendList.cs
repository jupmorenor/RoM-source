using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class FriendList : UIListBase
{
	public UIDraggablePanel scrollPanel;

	public GameObject decideTarget;

	public string decideFunction;

	public string focusFunction;

	public Color color;

	public Color loginTitleColor;

	public Color innerIconColor;

	public bool forceRebuild;

	private RespFriend[] sourceDatas;

	private bool initialized;

	private GameObject mapetIconPrefab;

	private HashSet<int> newFriendsHash;

	private GameObject focusedTarget;

	public bool Initialized => initialized;

	public FriendList()
	{
		color = new Color(0.7372549f, 73f / 85f, 1f);
		loginTitleColor = new Color(35f / 51f, 1f, 1f);
		innerIconColor = new Color(0.47843137f, 0.38039216f, 2f / 51f, 0.3372549f);
		sourceDatas = new RespFriend[0];
	}

	public void SetMapetPrefab(GameObject prefab)
	{
		mapetIconPrefab = prefab;
	}

	public RespFriend SetResponse(RespFriend[] arr, HashSet<int> newFriendIds)
	{
		newFriendsHash = newFriendIds;
		object result;
		if (!RuntimeServices.EqualityOperator(arr, sourceDatas) || forceRebuild || Count() == 0)
		{
			focusedTarget = null;
			Reset();
			sourceDatas = arr;
			UserData current = UserData.Current;
			int num = 0;
			int length = sourceDatas.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				UserMiscInfo.PoppetBookData poppetBookData = current.userMiscInfo.poppetBookData;
				RespFriend[] array = sourceDatas;
				poppetBookData.look(array[RuntimeServices.NormalizeArrayIndex(array, index)].GetFriendPet().Master);
			}
			Initialize(arr, this.gameObject, autoTween: true);
			initialized = true;
			result = ((!(null != focusedTarget)) ? null : focusedTarget.GetComponent<FriendListItem>().friend);
		}
		else
		{
			FriendListItem friendListItem = null;
			int num2 = 0;
			int num3 = Count();
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int index2 = num2;
				num2++;
				GameObject gameObject = At(index2);
				if ((bool)gameObject)
				{
					FriendListItem component = gameObject.GetComponent<FriendListItem>();
					if (null == friendListItem)
					{
						friendListItem = component;
					}
					component.SetNew(b: false);
				}
			}
			if (null == focusedTarget && friendListItem != null)
			{
				PushSelectItem(friendListItem.gameObject);
			}
			result = ((!(null != focusedTarget)) ? null : focusedTarget.GetComponent<FriendListItem>().friend);
		}
		return (RespFriend)result;
	}

	public bool IsNewFriend(RespFriend friend)
	{
		return newFriendsHash != null && newFriendsHash.Contains(friend.TSocialPlayerId);
	}

	private bool hookFriendConvertDataList(object[] list, ref Boo.Lang.List<UIListItem.Data> dstList)
	{
		int result;
		if (list == null)
		{
			dstList = new Boo.Lang.List<UIListItem.Data>();
			result = 0;
		}
		else
		{
			__ArrayMapMain_RespsToInts_0024callable111_00249_64__ _ArrayMapMain_RespsToInts_0024callable111_00249_64__ = (RespFriend x) => (!IsNewFriend(x)) ? 1 : 0;
			__FriendList_hookFriendConvertDataList_0024callable185_002467_13__ _FriendList_hookFriendConvertDataList_0024callable185_002467_13__ = (RespFriend x) => x.Name;
			__RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ _RespWeapon_CalcAddPlusBonusCost_0024callable180_0024358_13__ = (int n) => (n != 0) ? ((n > 0) ? 1 : (-1)) : 0;
			object[] array = Builtins.array(list);
			Array.Sort(array, _0024adaptor_0024__FriendList_0024callable356_002474_34___0024Comparison_0024174.Adapt((RespFriend a, RespFriend b) => b.LastAccessDate.CompareTo(a.LastAccessDate)));
			result = 0;
		}
		return (byte)result != 0;
	}

	private bool hookFriendSettingListItem(UIListItem item)
	{
		item.Select = false;
		item.transform.localScale = Vector3.one;
		FriendListItem friendListItem = (FriendListItem)item;
		friendListItem.muppetIconPrefab = mapetIconPrefab;
		RespFriend data = item.GetData<RespFriend>();
		friendListItem.SetFriend(data);
		friendListItem.SetNew(IsNewFriend(data));
		GameObject gameObject = ExtensionsModule.FindInChildrenIgnoreCase(friendListItem.gameObject, "Background");
		GameObject gameObject2 = ExtensionsModule.FindChild(friendListItem.gameObject, "TextLastLogin");
		GameObject gameObject3 = ExtensionsModule.FindChild(friendListItem.gameObject, "inner");
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("bg != null");
		}
		if (!(gameObject2 != null))
		{
			throw new AssertionFailedException("loginText != null");
		}
		if (!(gameObject3 != null))
		{
			throw new AssertionFailedException("inner != null");
		}
		gameObject.GetComponent<UIWidget>().color = color;
		gameObject2.GetComponent<UIWidget>().color = loginTitleColor;
		gameObject3.GetComponent<UIWidget>().color = innerIconColor;
		if (focusedTarget == null)
		{
			PushSelectItem(item.gameObject);
		}
		return false;
	}

	public void RemoveCurrentEntry()
	{
		int num = checked(GetIndex(focusedTarget) - 1);
		DeleteItem(focusedTarget);
		if (Count() != 0)
		{
			if (num < 0)
			{
				num = 0;
			}
			PushSelectItem(At(num));
		}
	}

	public new void PushSelectItem(GameObject obj)
	{
		if (!(decideTarget == null) && focusedTarget != obj)
		{
			if (focusedTarget != null)
			{
				focusedTarget.GetComponent<FriendListItem>().Focused = false;
			}
			focusedTarget = obj;
			focusedTarget.GetComponent<FriendListItem>().Focused = true;
			if (!string.IsNullOrEmpty(focusFunction))
			{
				decideTarget.SendMessage(focusFunction, obj, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void Awake()
	{
		base.HookSettingListItem = hookFriendSettingListItem;
		base.HookConvertDataList = hookFriendConvertDataList;
	}

	internal int _0024hookFriendConvertDataList_0024sortFunc_00244999(RespFriend x)
	{
		return (!IsNewFriend(x)) ? 1 : 0;
	}

	internal string _0024hookFriendConvertDataList_0024sortSubFunc_00245000(RespFriend x)
	{
		return x.Name;
	}

	internal int _0024hookFriendConvertDataList_0024sign_00245001(int n)
	{
		return (n != 0) ? ((n > 0) ? 1 : (-1)) : 0;
	}

	internal int _0024hookFriendConvertDataList_0024closure_00245002(RespFriend a, RespFriend b)
	{
		return b.LastAccessDate.CompareTo(a.LastAccessDate);
	}
}
