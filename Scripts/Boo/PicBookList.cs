using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PicBookList : UIListBase
{
	[Serializable]
	internal class _0024GetWeaponsList_0024locals_002414529
	{
		internal UserMiscInfo.WeponaBookData _0024weaponBookData;
	}

	[Serializable]
	internal class _0024GetPoppetsList_0024locals_002414530
	{
		internal UserMiscInfo.PoppetBookData _0024poppetBookData;
	}

	[Serializable]
	internal class _0024GetWeaponsList_0024closure_00245079
	{
		internal _0024GetWeaponsList_0024locals_002414529 _0024_0024locals_002415181;

		public _0024GetWeaponsList_0024closure_00245079(_0024GetWeaponsList_0024locals_002414529 _0024_0024locals_002415181)
		{
			this._0024_0024locals_002415181 = _0024_0024locals_002415181;
		}

		public bool Invoke(MWeapons m)
		{
			bool num = _0024_0024locals_002415181._0024weaponBookData.isHave(m);
			if (num)
			{
				num = m.Id != 1;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024GetWeaponsList_0024closure_00245080
	{
		internal _0024GetWeaponsList_0024locals_002414529 _0024_0024locals_002415182;

		public _0024GetWeaponsList_0024closure_00245080(_0024GetWeaponsList_0024locals_002414529 _0024_0024locals_002415182)
		{
			this._0024_0024locals_002415182 = _0024_0024locals_002415182;
		}

		public bool Invoke(MWeapons m)
		{
			bool num = _0024_0024locals_002415182._0024weaponBookData.isLook(m);
			if (num)
			{
				num = m.Id != 1;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024GetPoppetsList_0024closure_00245082
	{
		internal _0024GetPoppetsList_0024locals_002414530 _0024_0024locals_002415183;

		public _0024GetPoppetsList_0024closure_00245082(_0024GetPoppetsList_0024locals_002414530 _0024_0024locals_002415183)
		{
			this._0024_0024locals_002415183 = _0024_0024locals_002415183;
		}

		public bool Invoke(MPoppets m)
		{
			bool num = _0024_0024locals_002415183._0024poppetBookData.isHave(m);
			if (num)
			{
				num = m.Id != 1;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024GetPoppetsList_0024closure_00245083
	{
		internal _0024GetPoppetsList_0024locals_002414530 _0024_0024locals_002415184;

		public _0024GetPoppetsList_0024closure_00245083(_0024GetPoppetsList_0024locals_002414530 _0024_0024locals_002415184)
		{
			this._0024_0024locals_002415184 = _0024_0024locals_002415184;
		}

		public bool Invoke(MPoppets m)
		{
			bool num = _0024_0024locals_002415184._0024poppetBookData.isLook(m);
			if (num)
			{
				num = m.Id != 1;
			}
			return num;
		}
	}

	public GameObject selectMessageTarget;

	public GameObject infoWindow;

	public PIC_BOOK_LIST_TYPE type;

	public PIC_BOOK_LIST_MODE mode;

	private UIMain uiMain;

	public void Awake()
	{
		hookSettingListItem = PicBookSettingListItem;
		hookSort = PicBookHookSort;
		if (mode == PIC_BOOK_LIST_MODE.ALL)
		{
			mode = PIC_BOOK_LIST_MODE.HAVE_OR_LOOK;
		}
	}

	public void Start()
	{
		Init(type);
	}

	public void Init(PIC_BOOK_LIST_TYPE listType)
	{
		uiMain = NGUITools.FindInParents<UIMain>(gameObject);
		PicBookSortFuncs.SetPicBookListSortFuncs(this);
		PicBookData[] picBookList = GetPicBookList(listType);
		if (picBookList.Length > 0)
		{
			SelectData(picBookList[0]);
		}
		else
		{
			infoWindow.SendMessage("SetNoInfo");
		}
		Initialize(picBookList, gameObject, autoTween: true);
	}

	public PicBookData[] GetPicBookList(PIC_BOOK_LIST_TYPE listType)
	{
		PicBookData[] array = null;
		array = listType switch
		{
			PIC_BOOK_LIST_TYPE.Weapon => GetWeaponsList(), 
			PIC_BOOK_LIST_TYPE.Poppet => GetPoppetsList(), 
			_ => new PicBookData[0], 
		};
		if (mode == PIC_BOOK_LIST_MODE.ALL)
		{
			int i = 0;
			PicBookData[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				array2[i].isHaveDebug = true;
			}
		}
		return array;
	}

	public PicBookData[] GetWeaponsList()
	{
		_0024GetWeaponsList_0024locals_002414529 _0024GetWeaponsList_0024locals_0024 = new _0024GetWeaponsList_0024locals_002414529();
		MWeapons[] array = null;
		switch (mode)
		{
		case PIC_BOOK_LIST_MODE.ALL:
			array = (MWeapons[])Builtins.array(typeof(MWeapons), MWeapons.All);
			break;
		case PIC_BOOK_LIST_MODE.HAVE_ONLY:
			_0024GetWeaponsList_0024locals_0024._0024weaponBookData = UserData.Current.userMiscInfo.weaponBookData;
			array = ArrayMap.FilterAllMWeapons(new _0024GetWeaponsList_0024closure_00245079(_0024GetWeaponsList_0024locals_0024).Invoke);
			break;
		case PIC_BOOK_LIST_MODE.HAVE_OR_LOOK:
			_0024GetWeaponsList_0024locals_0024._0024weaponBookData = UserData.Current.userMiscInfo.weaponBookData;
			array = ArrayMap.FilterAllMWeapons(new _0024GetWeaponsList_0024closure_00245080(_0024GetWeaponsList_0024locals_0024).Invoke);
			break;
		case PIC_BOOK_LIST_MODE.NOHAVE_IS_NONEICON:
			array = ArrayMap.FilterAllMWeapons((MWeapons m) => m.IsAvailable);
			break;
		default:
			array = new MWeapons[0];
			break;
		}
		PicBookData[] array2 = new PicBookData[array.Length];
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			int num2 = RuntimeServices.NormalizeArrayIndex(array2, index);
			MWeapons[] array3 = array;
			array2[num2] = new PicBookData(array3[RuntimeServices.NormalizeArrayIndex(array3, index)]);
		}
		return array2;
	}

	public PicBookData[] GetPoppetsList()
	{
		_0024GetPoppetsList_0024locals_002414530 _0024GetPoppetsList_0024locals_0024 = new _0024GetPoppetsList_0024locals_002414530();
		MPoppets[] array = null;
		switch (mode)
		{
		case PIC_BOOK_LIST_MODE.ALL:
			array = (MPoppets[])Builtins.array(typeof(MPoppets), MPoppets.All);
			break;
		case PIC_BOOK_LIST_MODE.HAVE_ONLY:
			_0024GetPoppetsList_0024locals_0024._0024poppetBookData = UserData.Current.userMiscInfo.poppetBookData;
			array = ArrayMap.FilterAllMPoppets(new _0024GetPoppetsList_0024closure_00245082(_0024GetPoppetsList_0024locals_0024).Invoke);
			break;
		case PIC_BOOK_LIST_MODE.HAVE_OR_LOOK:
			_0024GetPoppetsList_0024locals_0024._0024poppetBookData = UserData.Current.userMiscInfo.poppetBookData;
			array = ArrayMap.FilterAllMPoppets(new _0024GetPoppetsList_0024closure_00245083(_0024GetPoppetsList_0024locals_0024).Invoke);
			break;
		case PIC_BOOK_LIST_MODE.NOHAVE_IS_NONEICON:
			array = ArrayMap.FilterAllMPoppets((MPoppets m) => m.IsAvailable);
			break;
		default:
			array = new MPoppets[0];
			break;
		}
		PicBookData[] array2 = new PicBookData[array.Length];
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			int num2 = RuntimeServices.NormalizeArrayIndex(array2, index);
			MPoppets[] array3 = array;
			array2[num2] = new PicBookData(array3[RuntimeServices.NormalizeArrayIndex(array3, index)]);
		}
		return array2;
	}

	public bool PicBookSettingListItem(UIListItem item)
	{
		item.gameObject.SendMessage("SetPicBookItem", mode);
		return false;
	}

	public bool PicBookHookSort(ref string key)
	{
		SimpleSort(key);
		if (focusItem != null)
		{
			ScrollToTarget(focusItem);
		}
		return true;
	}

	public override long CreateID(object obj)
	{
		object obj2 = obj;
		if (!(obj2 is PicBookData))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(PicBookData));
		}
		PicBookData picBookData = (PicBookData)obj2;
		return checked(picBookData.IsWeapon() ? ((long)picBookData.weapon.Id) : ((!picBookData.IsPoppet()) ? 0 : ((long)picBookData.poppet.Id)));
	}

	public new void PushSelectItem(GameObject selectItem)
	{
		if (!IsChangingSituation())
		{
			UIListItem.Data data = selectItem.GetComponent<UIListItem>().GetData();
			PicBookData data2 = data.GetData<PicBookData>();
			if (RuntimeServices.EqualityOperator(focusItem, data))
			{
				PushDetail();
				return;
			}
			SetFocusItem(data);
			SelectData(data2);
		}
	}

	public void SelectData(PicBookData data)
	{
		infoWindow.SendMessage("ShowSelectData", data);
		SendMessageTarget("SelectData", data);
	}

	public void PushDetail()
	{
		if (!IsChangingSituation())
		{
			SendMessageTarget("ShowDetail", null);
		}
	}

	public void PushModel()
	{
		if (!IsChangingSituation())
		{
			SendMessageTarget("ShowModel", null);
		}
	}

	public void SendMessageTarget(string msg, object obj)
	{
		if (selectMessageTarget != null)
		{
			selectMessageTarget.SendMessage(msg, obj);
		}
	}

	public bool IsChangingSituation()
	{
		bool num = uiMain != null;
		if (num)
		{
			num = uiMain.IsChangingSituation;
		}
		return num;
	}

	internal bool _0024GetWeaponsList_0024closure_00245081(MWeapons m)
	{
		return m.IsAvailable;
	}

	internal bool _0024GetPoppetsList_0024closure_00245084(MPoppets m)
	{
		return m.IsAvailable;
	}
}
