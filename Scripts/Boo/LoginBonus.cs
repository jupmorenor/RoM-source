using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class LoginBonus : MonoBehaviour
{
	[Serializable]
	internal class _0024RequestBonusDialog_0024WeaponCB_00245045
	{
		internal MLoginBonusItems.Item[] _0024_002411304_002415102;

		internal int _0024_002411303_002415103;

		internal LoginBonus _0024this_002415104;

		public _0024RequestBonusDialog_0024WeaponCB_00245045(MLoginBonusItems.Item[] _0024_002411304_002415102, int _0024_002411303_002415103, LoginBonus _0024this_002415104)
		{
			this._0024_002411304_002415102 = _0024_002411304_002415102;
			this._0024_002411303_002415103 = _0024_002411303_002415103;
			this._0024this_002415104 = _0024this_002415104;
		}

		public void Invoke(GameObject parent)
		{
			_0024this_002415104.CreateWeaponIcon(_0024this_002415104.weaponIconPrefab, parent, new RespWeapon(_0024_002411304_002415102[_0024_002411303_002415103].ItemId));
		}
	}

	[Serializable]
	internal class _0024RequestBonusDialog_0024MapetCB_00245046
	{
		internal MLoginBonusItems.Item[] _0024_002411304_002415105;

		internal LoginBonus _0024this_002415106;

		internal int _0024_002411303_002415107;

		public _0024RequestBonusDialog_0024MapetCB_00245046(MLoginBonusItems.Item[] _0024_002411304_002415105, LoginBonus _0024this_002415106, int _0024_002411303_002415107)
		{
			this._0024_002411304_002415105 = _0024_002411304_002415105;
			this._0024this_002415106 = _0024this_002415106;
			this._0024_002411303_002415107 = _0024_002411303_002415107;
		}

		public void Invoke(GameObject parent)
		{
			_0024this_002415106.CreateMapetIcon(_0024this_002415106.mapetIconPrefab, parent, new RespPoppet(_0024_002411304_002415105[_0024_002411303_002415107].ItemId));
		}
	}

	[Serializable]
	internal class _0024InitBonusTable_0024closure_00245048
	{
		internal int _0024i_002415108;

		public _0024InitBonusTable_0024closure_00245048(int _0024i_002415108)
		{
			this._0024i_002415108 = _0024i_002415108;
		}

		public bool Invoke(MLoginRewards r)
		{
			return r.Num == checked(_0024i_002415108 + 1);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RequestBonusDialog_002421674 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespPlayerLogin _0024top_002421675;

			internal int _0024loginBonusID_002421676;

			internal MLoginBonuses _0024master_002421677;

			internal MLoginRewards[] _0024rewards_002421678;

			internal int[] _0024rewardIds_002421679;

			internal int _0024loginNum_002421680;

			internal MLoginBonusItems _0024bonusItem_002421681;

			internal int _0024rewardIndex_002421682;

			internal MLoginBonusItems.Item _0024item_002421683;

			internal string _0024bonusName_002421684;

			internal EnumMasterTypeValues _0024_0024match_00242607_002421685;

			internal __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _0024WeaponCB_002421686;

			internal __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _0024MapetCB_002421687;

			internal int _0024_002411303_002421688;

			internal MLoginBonusItems.Item[] _0024_002411304_002421689;

			internal int _0024_002411305_002421690;

			internal int _0024_002411307_002421691;

			internal MLoginBonusItems[] _0024_002411308_002421692;

			internal int _0024_002411309_002421693;

			internal LoginBonus _0024self__002421694;

			public _0024(LoginBonus self_)
			{
				_0024self__002421694 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					case 2:
						if (LoginBonusDialog.IsOpened)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024_002411303_002421688++;
						goto IL_0406;
					default:
						if (0 < _0024self__002421694.loginInfoList.Count)
						{
							_0024top_002421675 = _0024self__002421694.loginInfoList[0];
							_0024loginBonusID_002421676 = _0024top_002421675.MLoginBonusId;
							_0024master_002421677 = MLoginBonuses.Get(_0024loginBonusID_002421676);
							_0024rewards_002421678 = _0024master_002421677.Rewards;
							_0024rewardIds_002421679 = ArrayMap.MastersToIds(_0024rewards_002421678);
							_0024loginNum_002421680 = _0024top_002421675.LoginNum;
							_0024_002411307_002421691 = 0;
							_0024_002411308_002421692 = MLoginBonusItems.All;
							_0024_002411309_002421693 = _0024_002411308_002421692.Length;
							goto IL_0425;
						}
						_0024self__002421694.Exit();
						YieldDefault(1);
						goto case 1;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0406:
						if (_0024_002411303_002421688 < _0024_002411305_002421690)
						{
							_0024bonusName_002421684 = MTexts.Msg("$LB_NAME_ERROR");
							_0024_0024match_00242607_002421685 = _0024_002411304_002421689[_0024_002411303_002421688].ItemType;
							if (_0024_0024match_00242607_002421685 == EnumMasterTypeValues.FayStone)
							{
								_0024bonusName_002421684 = UIBasicUtility.SafeFormat(MTexts.Format("$LB_FAYSTONE", _0024_002411304_002421689[_0024_002411303_002421688].Quantity));
							}
							else if (_0024_0024match_00242607_002421685 == EnumMasterTypeValues.Coin)
							{
								_0024bonusName_002421684 = UIBasicUtility.SafeFormat(MTexts.Format("$LB_RUKU", _0024_002411304_002421689[_0024_002411303_002421688].Quantity));
							}
							else if (_0024_0024match_00242607_002421685 == EnumMasterTypeValues.FriendPoint)
							{
								_0024bonusName_002421684 = UIBasicUtility.SafeFormat(MTexts.Format("$LB_FRIENDPOINT", _0024_002411304_002421689[_0024_002411303_002421688].Quantity));
							}
							else if (_0024_0024match_00242607_002421685 == EnumMasterTypeValues.Weapon)
							{
								_0024bonusName_002421684 = new RespWeapon(_0024_002411304_002421689[_0024_002411303_002421688].ItemId).Name;
							}
							else if (_0024_0024match_00242607_002421685 == EnumMasterTypeValues.Poppet)
							{
								_0024bonusName_002421684 = new RespPoppet(_0024_002411304_002421689[_0024_002411303_002421688].ItemId).Name;
							}
							else if (0 == 0)
							{
								throw new AssertionFailedException("表示非対応な種類のログインボーナス.配ってはいけないものを配っている？ itemType = " + _0024_002411304_002421689[_0024_002411303_002421688].ItemType);
							}
							_0024self__002421694.receiveMessage = MTexts.Format("$LB_RECEIVE_TITLE", _0024bonusName_002421684);
							_0024self__002421694.receiveTitle = MTexts.Format("$LB_RECEIVE", _0024self__002421694.todayIconIndex + 1);
							if (_0024self__002421694.dialog == null)
							{
								_0024self__002421694.dialog = ((GameObject)UnityEngine.Object.Instantiate(_0024self__002421694.dialogPrefab)).GetComponent<LoginBonusDialog>();
							}
							_0024WeaponCB_002421686 = new _0024RequestBonusDialog_0024WeaponCB_00245045(_0024_002411304_002421689, _0024_002411303_002421688, _0024self__002421694).Invoke;
							_0024MapetCB_002421687 = new _0024RequestBonusDialog_0024MapetCB_00245046(_0024_002411304_002421689, _0024self__002421694, _0024_002411303_002421688).Invoke;
							_0024self__002421694.dialog.Open(_0024_002411304_002421689[_0024_002411303_002421688].ItemType, _0024self__002421694.receiveTitle, _0024self__002421694.receiveMessage, _0024WeaponCB_002421686, _0024MapetCB_002421687);
							goto case 2;
						}
						goto IL_0417;
						IL_0417:
						_0024_002411307_002421691++;
						goto IL_0425;
						IL_0425:
						if (_0024_002411307_002421691 < _0024_002411309_002421693)
						{
							_0024rewardIndex_002421682 = Array.IndexOf(_0024rewardIds_002421679, _0024_002411308_002421692[_0024_002411307_002421691].Id);
							if (0 <= _0024rewardIndex_002421682)
							{
								MLoginRewards[] array = _0024rewards_002421678;
								if (array[RuntimeServices.NormalizeArrayIndex(array, _0024rewardIndex_002421682)].Num == _0024loginNum_002421680 || _0024master_002421677.LoginBonusTypeValue == EnumLoginBonusTypeValues.FixedBonus)
								{
									_0024_002411303_002421688 = 0;
									_0024_002411304_002421689 = _0024_002411308_002421692[_0024_002411307_002421691].AllItems;
									_0024_002411305_002421690 = _0024_002411304_002421689.Length;
									goto IL_0406;
								}
							}
							goto IL_0417;
						}
						_0024self__002421694.loginInfoList.RemoveAt(0);
						goto default;
					}
				}
				return (byte)result != 0;
			}
		}

		internal LoginBonus _0024self__002421695;

		public _0024RequestBonusDialog_002421674(LoginBonus self_)
		{
			_0024self__002421695 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421695);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002421696 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LoginBonus _0024self__002421697;

			public _0024(LoginBonus self_)
			{
				_0024self__002421697 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					TimeScaleUtil.One();
					goto case 3;
				case 3:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					if ((bool)_0024self__002421697.dialog && LoginBonusDialog.IsOpened)
					{
						goto case 3;
					}
					result = (Yield(3, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoginBonus _0024self__002421698;

		public _0024main_002421696(LoginBonus self_)
		{
			_0024self__002421698 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002421698);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024TouchScreen_0024closure_00245050_002421699 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal LoginBonus _0024self__002421700;

			public _0024(LoginBonus self_)
			{
				_0024self__002421700 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002421700.todayIconIndex < _0024self__002421700.SumiIcon.Length)
					{
						GameObject[] sumiIcon = _0024self__002421700.SumiIcon;
						ExtensionsModule.FindChild(sumiIcon[RuntimeServices.NormalizeArrayIndex(sumiIcon, _0024self__002421700.todayIconIndex)], "Sumiicon").SetActive(value: true);
						result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__002421700.StartCoroutine(_0024self__002421700.RequestBonusDialog());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal LoginBonus _0024self__002421701;

		public _0024_0024TouchScreen_0024closure_00245050_002421699(LoginBonus self_)
		{
			_0024self__002421701 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002421701);
		}
	}

	public int DebugDays;

	public bool EnableDebugDays;

	public GameObject[] SumiIcon;

	public bool dialogTest;

	private bool Stamp;

	private bool waitExit;

	private string receiveMessage;

	private string receiveTitle;

	private int days;

	private bool showDialog;

	private Boo.Lang.List<RespPlayerLogin> loginInfoList;

	private LoginBonusDialog dialog;

	private GameObject dialogPrefab;

	private GameObject weaponIconPrefab;

	private GameObject mapetIconPrefab;

	[NonSerialized]
	private const string SpriteNameStone = "Stone";

	[NonSerialized]
	private const string SpriteNameCoin = "Coin";

	[NonSerialized]
	private const string SpriteNameFriendPoint = "FriendPoint";

	[NonSerialized]
	private const string SpriteNameTreasure = "Treasure";

	[NonSerialized]
	private const string SpriteNameWeapon = "Weapon";

	[NonSerialized]
	private const string SpriteNameMapet = "Mapet";

	[NonSerialized]
	private const int FIRST_RELEASE_MONTH_BONUS_NUM = 20;

	[NonSerialized]
	private const int FIRST_RELEASE_YEAR = 2014;

	[NonSerialized]
	private const int FIRST_RELEASE_MONTH = 3;

	private bool requested;

	private int todayIconIndex => checked(days - 1);

	public bool WaitExit => waitExit;

	private int CreateLoginBonusInfoList()
	{
		loginInfoList = new Boo.Lang.List<RespPlayerLogin>();
		RespPlayerLogin[] login = UserData.Current.Login;
		int result = 0;
		DateTime dateTime = DateTime.MinValue;
		MLoginBonuses mLoginBonuses = null;
		int num = 0;
		int length = login.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (!login[RuntimeServices.NormalizeArrayIndex(login, index)].IsLoginBonus)
			{
				continue;
			}
			loginInfoList.Add(login[RuntimeServices.NormalizeArrayIndex(login, index)]);
			MLoginBonuses mLoginBonuses2 = MLoginBonuses.Get(login[RuntimeServices.NormalizeArrayIndex(login, index)].MLoginBonusId);
			if (mLoginBonuses2.LoginBonusTypeValue == EnumLoginBonusTypeValues.TermTotalNumBonus)
			{
				if (dateTime < login[RuntimeServices.NormalizeArrayIndex(login, index)].LastGetDate)
				{
					dateTime = login[RuntimeServices.NormalizeArrayIndex(login, index)].LastGetDate;
					result = login[RuntimeServices.NormalizeArrayIndex(login, index)].LoginNum;
				}
			}
		}
		return result;
	}

	private IEnumerator RequestBonusDialog()
	{
		return new _0024RequestBonusDialog_002421674(this).GetEnumerator();
	}

	public void Start()
	{
		dialogPrefab = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/MessageBoxLogin");
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			days = CreateLoginBonusInfoList();
			if (SumiIcon == null)
			{
				throw new AssertionFailedException("シーンの設定がおかしい。SumiIcon == null");
			}
			int num = 0;
			int length = SumiIcon.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				GameObject[] sumiIcon = SumiIcon;
				GameObject gameObject = sumiIcon[RuntimeServices.NormalizeArrayIndex(sumiIcon, num2)];
				if ((bool)gameObject)
				{
					gameObject.SetActive(value: false);
					if (num2 < todayIconIndex)
					{
						gameObject.SetActive(value: true);
						int i = 0;
						UITweener[] components = gameObject.GetComponents<UITweener>();
						for (int length2 = components.Length; i < length2; i = checked(i + 1))
						{
							UnityEngine.Object.DestroyImmediate(components[i]);
						}
					}
				}
			}
			try
			{
				UserData.Current.resetLoginBonusFlag();
				InitBonusTable();
				StartCoroutine(main());
			}
			catch (Exception)
			{
				waitExit = true;
			}
		});
	}

	public IEnumerator main()
	{
		return new _0024main_002421696(this).GetEnumerator();
	}

	private void CreateWeaponIcon(GameObject weaponIconPrefab, GameObject weaponIconParent, RespWeapon weapon)
	{
		weaponIconParent.SetActive(value: true);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(weaponIconPrefab);
		gameObject.transform.parent = weaponIconParent.transform;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		WeaponListItem component = gameObject.GetComponent<WeaponListItem>();
		component.enableIconSprite = true;
		component.enableLevelLabel = false;
		component.enableIconFavorite = false;
		component.SetWeapon(weapon, ignoreUnknown: true);
		UIButtonMessage component2 = gameObject.GetComponent<UIButtonMessage>();
		component2.target = null;
		component2.functionName = null;
		component.DestroyLevel();
	}

	private void CreateMapetIcon(GameObject mapetIconPrefab, GameObject mapetIconParent, RespPoppet mapet)
	{
		mapetIconParent.SetActive(value: true);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(mapetIconPrefab);
		gameObject.transform.parent = mapetIconParent.transform;
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		UIButtonMessage component = gameObject.GetComponent<UIButtonMessage>();
		component.target = null;
		component.functionName = null;
		MapetListItem component2 = gameObject.GetComponent<MapetListItem>();
		component2.enableIconSprite = true;
		component2.enableLevelLabel = false;
		component2.enableCharLevelLabel = false;
		component2.enableIconFavorite = false;
		GameObject gameObject2 = component2.SetMapet(mapet, ignoreUnknown: true);
		component2.DestroyLevel();
	}

	private string ProcessBonusIcon(MLoginBonusItems bonusItem, GameObject go, bool @fixed)
	{
		string result = null;
		int i = 0;
		MLoginBonusItems.Item[] allItems = bonusItem.AllItems;
		for (int length = allItems.Length; i < length; i = checked(i + 1))
		{
			switch (allItems[i].ItemType)
			{
			case EnumMasterTypeValues.FayStone:
				result = "Stone";
				continue;
			case EnumMasterTypeValues.Coin:
				result = "Coin";
				continue;
			case EnumMasterTypeValues.FriendPoint:
				result = "FriendPoint";
				continue;
			case EnumMasterTypeValues.Weapon:
				result = "Weapon";
				CreateWeaponIcon(weaponIconPrefab, ExtensionsModule.FindChild(go, "Icon"), new RespWeapon(allItems[i].ItemId));
				break;
			case EnumMasterTypeValues.Poppet:
				result = "Mapet";
				CreateMapetIcon(mapetIconPrefab, ExtensionsModule.FindChild(go, "Icon"), new RespPoppet(allItems[i].ItemId));
				break;
			default:
				continue;
			}
			break;
		}
		return result;
	}

	private void InitBonusTable()
	{
		DateTime now = MerlinDateTime.Now;
		DateTime dateTime = new DateTime(now.Year, now.Month, 1);
		ExtensionsModule.FindChild(ExtensionsModule.FindChild(this.gameObject, "Background"), "TextTitle").GetComponent<UILabelBase>().text = UIBasicUtility.SafeFormat("{0}月ログインボーナス", now.Month);
		MLoginBonuses mLoginBonuses = AnalysisLoginBonusWithDay(now);
		weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/WeaponListItem") as GameObject;
		mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/MuppetListItem") as GameObject;
		MLoginRewards[] rewards = mLoginBonuses.Rewards;
		Boo.Lang.List<GameObject> list = new Boo.Lang.List<GameObject>();
		int num = 0;
		int length = SumiIcon.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			GameObject[] sumiIcon = SumiIcon;
			GameObject gameObject = sumiIcon[RuntimeServices.NormalizeArrayIndex(sumiIcon, num2)].transform.parent.gameObject;
			if (20 <= num2 && now.Year == 2014 && now.Month == 3)
			{
				UnityEngine.Object.Destroy(gameObject);
				continue;
			}
			if (DateTime.DaysInMonth(now.Year, now.Month) <= num2)
			{
				UnityEngine.Object.Destroy(gameObject);
				continue;
			}
			MLoginRewards mLoginRewards = Array.Find(rewards, new _0024InitBonusTable_0024closure_00245048(num2).Invoke);
			string text = null;
			if (mLoginRewards != null)
			{
				MLoginBonusItems mLoginBonusItems = MLoginBonusItems.Get(mLoginRewards.Id);
				if (mLoginBonusItems != null)
				{
					MLoginBonusItems.Item[] allItems = mLoginBonusItems.AllItems;
					if (0 < allItems.Length)
					{
						MLoginBonusItems.Item[] array = Array.FindAll(allItems, delegate(MLoginBonusItems.Item r)
						{
							bool num3 = r.ItemType == EnumMasterTypeValues.Weapon;
							if (!num3)
							{
								num3 = r.ItemType == EnumMasterTypeValues.Poppet;
							}
							if (!num3)
							{
								num3 = r.ItemType == EnumMasterTypeValues.FayStone;
							}
							return num3;
						});
						bool flag = false;
						if (0 < array.Length)
						{
							MLoginBonusItems.Item item = array[0];
							int i = 0;
							MLoginBonusItems.Item[] array2 = array;
							for (int length2 = array2.Length; i < length2; i = checked(i + 1))
							{
								if (!RuntimeServices.EqualityOperator(array2[i], item) && (array2[i].ItemType != item.ItemType || array2[i].ItemId != item.ItemId))
								{
									flag = true;
									break;
								}
							}
						}
						text = (flag ? "Treasure" : ProcessBonusIcon(mLoginBonusItems, gameObject, @fixed: false));
					}
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				MLoginBonuses mLoginBonuses2 = AnalysisLoginBonusWithDayFixed(dateTime + TimeSpan.FromDays(num2));
				if (mLoginBonuses2 != null)
				{
					MLoginRewards[] rewards2 = mLoginBonuses2.Rewards;
					if (0 < rewards2.Length)
					{
						MLoginBonusItems mLoginBonusItems = MLoginBonusItems.Get(rewards2[0].Id);
						if (mLoginBonusItems != null)
						{
							text = ProcessBonusIcon(mLoginBonusItems, gameObject, @fixed: true);
						}
					}
				}
			}
			ExtensionsModule.FindChild(gameObject, "Stone").SetActive(text == "Stone");
			ExtensionsModule.FindChild(gameObject, "Coin").SetActive(text == "Coin");
			ExtensionsModule.FindChild(gameObject, "FriendPoint").SetActive(text == "FriendPoint");
			ExtensionsModule.FindChild(gameObject, "Treasure").SetActive(text == "Treasure");
			if (string.IsNullOrEmpty(text))
			{
				GameObject[] sumiIcon2 = SumiIcon;
				if (sumiIcon2[RuntimeServices.NormalizeArrayIndex(sumiIcon2, num2)].GetComponent<UISprite>().spriteName != "icon_stamp")
				{
					GameObject[] sumiIcon3 = SumiIcon;
					sumiIcon3[RuntimeServices.NormalizeArrayIndex(sumiIcon3, num2)].GetComponent<UISprite>().spriteName = "icon_stamp";
				}
			}
			list.Add(gameObject);
		}
		SumiIcon = list.ToArray();
	}

	private MLoginBonuses AnalysisLoginBonusWithDay(DateTime now)
	{
		int num = 0;
		MLoginBonuses[] all = MLoginBonuses.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].LoginBonusTypeValue == EnumLoginBonusTypeValues.TermTotalNumBonus && all[num].StartDate <= now + all[num].GrantTime && now + all[num].GrantTime <= all[num].EndDate)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MLoginBonuses)result;
	}

	private MLoginBonuses AnalysisLoginBonusWithDayFixed(DateTime now)
	{
		int num = 0;
		MLoginBonuses[] all = MLoginBonuses.All;
		int length = all.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].LoginBonusTypeValue == EnumLoginBonusTypeValues.FixedBonus && all[num].StartDate <= now + all[num].GrantTime && now + all[num].GrantTime <= all[num].EndDate)
				{
					result = all[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (MLoginBonuses)result;
	}

	public void Update()
	{
	}

	public void Exit()
	{
		if (!waitExit)
		{
			waitExit = true;
			if (SceneChanger.CurrentScene == SceneID.Ui_LoginBonus)
			{
				SceneChanger.ChangeTo(SceneID.Myhome);
			}
		}
	}

	public void TouchScreen()
	{
		if (!waitExit && !requested)
		{
			requested = true;
			ExtensionsModule.PostStartCoroutine(this, () => new _0024_0024TouchScreen_0024closure_00245050_002421699(this).GetEnumerator());
		}
	}

	public void Check()
	{
	}

	internal void _0024Start_0024closure_00245047()
	{
		days = CreateLoginBonusInfoList();
		if (SumiIcon == null)
		{
			throw new AssertionFailedException("シーンの設定がおかしい。SumiIcon == null");
		}
		int num = 0;
		int length = SumiIcon.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			GameObject[] sumiIcon = SumiIcon;
			GameObject gameObject = sumiIcon[RuntimeServices.NormalizeArrayIndex(sumiIcon, num2)];
			if (!gameObject)
			{
				continue;
			}
			gameObject.SetActive(value: false);
			if (num2 < todayIconIndex)
			{
				gameObject.SetActive(value: true);
				int i = 0;
				UITweener[] components = gameObject.GetComponents<UITweener>();
				for (int length2 = components.Length; i < length2; i = checked(i + 1))
				{
					UnityEngine.Object.DestroyImmediate(components[i]);
				}
			}
		}
		try
		{
			UserData.Current.resetLoginBonusFlag();
			InitBonusTable();
			StartCoroutine(main());
		}
		catch (Exception)
		{
			waitExit = true;
		}
	}

	internal bool _0024InitBonusTable_0024closure_00245049(MLoginBonusItems.Item r)
	{
		bool num = r.ItemType == EnumMasterTypeValues.Weapon;
		if (!num)
		{
			num = r.ItemType == EnumMasterTypeValues.Poppet;
		}
		if (!num)
		{
			num = r.ItemType == EnumMasterTypeValues.FayStone;
		}
		return num;
	}

	internal IEnumerator _0024TouchScreen_0024closure_00245050()
	{
		return new _0024_0024TouchScreen_0024closure_00245050_002421699(this).GetEnumerator();
	}
}
