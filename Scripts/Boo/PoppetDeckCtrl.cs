using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PoppetDeckCtrl : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		None = -1,
		DeckSelect,
		WeaponList,
		PoppetList,
		WeaponDetail,
		PoppetDetail
	}

	[Serializable]
	private class CacheButtonMessage
	{
		public GameObject target;

		public string functionName;
	}

	[Serializable]
	internal class _0024hookSettingWeaponListItem_0024locals_002414478
	{
		internal bool _0024enableItem;

		internal WeaponListItem _0024wepItem;
	}

	[Serializable]
	internal class _0024hookSettingPetListItem_0024locals_002414479
	{
		internal bool _0024enableItem;

		internal MapetListItem _0024petItem;
	}

	[Serializable]
	internal class _0024hookSettingWeaponListItem_0024closure_00243146
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421420 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal UIValidController[] _0024validColors_002421421;

				internal UIValidController _0024vCol_002421422;

				internal int _0024_002410914_002421423;

				internal UIValidController[] _0024_002410915_002421424;

				internal int _0024_002410916_002421425;

				internal _0024hookSettingWeaponListItem_0024closure_00243146 _0024self__002421426;

				public _0024(_0024hookSettingWeaponListItem_0024closure_00243146 self_)
				{
					_0024self__002421426 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							if (null != _0024self__002421426._0024_0024locals_002415058._0024wepItem)
							{
								if (!_0024self__002421426._0024_0024locals_002415058._0024wepItem.gameObject.active || !(null != _0024self__002421426._0024_0024locals_002415058._0024wepItem.Icon))
								{
									result = (YieldDefault(2) ? 1 : 0);
									break;
								}
								_0024validColors_002421421 = _0024self__002421426._0024_0024locals_002415058._0024wepItem.GetComponents<UIValidController>();
								if (_0024validColors_002421421 != null)
								{
									_0024_002410914_002421423 = 0;
									_0024_002410915_002421424 = _0024validColors_002421421;
									for (_0024_002410916_002421425 = _0024_002410915_002421424.Length; _0024_002410914_002421423 < _0024_002410916_002421425; _0024_002410914_002421423++)
									{
										if (_0024_002410915_002421424[_0024_002410914_002421423].validEffectTarget == _0024self__002421426._0024_0024locals_002415058._0024wepItem.gameObject)
										{
											_0024_002410915_002421424[_0024_002410914_002421423].invalidColor = Color.gray;
											_0024_002410915_002421424[_0024_002410914_002421423].isValidColor = _0024self__002421426._0024_0024locals_002415058._0024enableItem;
										}
									}
								}
							}
							YieldDefault(1);
							goto case 1;
						case 1:
							result = 0;
							break;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024hookSettingWeaponListItem_0024closure_00243146 _0024self__002421427;

			public _0024Invoke_002421420(_0024hookSettingWeaponListItem_0024closure_00243146 self_)
			{
				_0024self__002421427 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421427);
			}
		}

		internal _0024hookSettingWeaponListItem_0024locals_002414478 _0024_0024locals_002415058;

		public _0024hookSettingWeaponListItem_0024closure_00243146(_0024hookSettingWeaponListItem_0024locals_002414478 _0024_0024locals_002415058)
		{
			this._0024_0024locals_002415058 = _0024_0024locals_002415058;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421420(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024hookSettingPetListItem_0024closure_00243147
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421428 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal UIValidController[] _0024validColors_002421429;

				internal UIValidController _0024vCol_002421430;

				internal int _0024_002410918_002421431;

				internal UIValidController[] _0024_002410919_002421432;

				internal int _0024_002410920_002421433;

				internal _0024hookSettingPetListItem_0024closure_00243147 _0024self__002421434;

				public _0024(_0024hookSettingPetListItem_0024closure_00243147 self_)
				{
					_0024self__002421434 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							if (null != _0024self__002421434._0024_0024locals_002415059._0024petItem)
							{
								if (!_0024self__002421434._0024_0024locals_002415059._0024petItem.gameObject.active || !(null != _0024self__002421434._0024_0024locals_002415059._0024petItem.Icon))
								{
									result = (YieldDefault(2) ? 1 : 0);
									break;
								}
								_0024validColors_002421429 = _0024self__002421434._0024_0024locals_002415059._0024petItem.GetComponents<UIValidController>();
								if (_0024validColors_002421429 != null)
								{
									_0024_002410918_002421431 = 0;
									_0024_002410919_002421432 = _0024validColors_002421429;
									for (_0024_002410920_002421433 = _0024_002410919_002421432.Length; _0024_002410918_002421431 < _0024_002410920_002421433; _0024_002410918_002421431++)
									{
										if (_0024_002410919_002421432[_0024_002410918_002421431].validEffectTarget == _0024self__002421434._0024_0024locals_002415059._0024petItem.gameObject)
										{
											_0024_002410919_002421432[_0024_002410918_002421431].invalidColor = Color.gray;
											_0024_002410919_002421432[_0024_002410918_002421431].isValidColor = _0024self__002421434._0024_0024locals_002415059._0024enableItem;
										}
									}
								}
							}
							YieldDefault(1);
							goto case 1;
						case 1:
							result = 0;
							break;
						}
					}
					return (byte)result != 0;
				}
			}

			internal _0024hookSettingPetListItem_0024closure_00243147 _0024self__002421435;

			public _0024Invoke_002421428(_0024hookSettingPetListItem_0024closure_00243147 self_)
			{
				_0024self__002421435 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421435);
			}
		}

		internal _0024hookSettingPetListItem_0024locals_002414479 _0024_0024locals_002415059;

		public _0024hookSettingPetListItem_0024closure_00243147(_0024hookSettingPetListItem_0024locals_002414479 _0024_0024locals_002415059)
		{
			this._0024_0024locals_002415059 = _0024_0024locals_002415059;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421428(this).GetEnumerator();
		}
	}

	public BoxInfoController boxCtrl;

	public WeaponList weaponList;

	public MapetList poppetList;

	public WeaponInfo weaponDetailInfo;

	public MuppetInfo poppetDetailInfo;

	public GameObject listButton;

	private Mode mode;

	private Mode lastMode;

	private RespWeapon curWeapon;

	private RespPoppet curPoppet;

	private int curId;

	private CacheButtonMessage btnBackup;

	private bool nowIn;

	private bool nowOut;

	[NonSerialized]
	private static int deckCostMax = -1;

	[NonSerialized]
	private static bool updateCostMax;

	[NonSerialized]
	private static int[] deckRarityLimits = new int[0];

	[NonSerialized]
	private static bool updateRarityLimits;

	[NonSerialized]
	private static int[] deckElementLimits = new int[0];

	[NonSerialized]
	private static bool updateElementLimits;

	[NonSerialized]
	private static int[] deckStyleLimits = new int[0];

	[NonSerialized]
	private static bool updateStyleLimits;

	private bool nowBusy
	{
		get
		{
			bool num = nowIn;
			if (!num)
			{
				num = nowOut;
			}
			return num;
		}
	}

	public static int DeckCostMax
	{
		get
		{
			return deckCostMax;
		}
		set
		{
			deckCostMax = value;
		}
	}

	public static int[] DeckRarityLimits
	{
		get
		{
			return deckRarityLimits;
		}
		set
		{
			deckRarityLimits = value;
		}
	}

	public static int[] DeckElementLimits
	{
		get
		{
			return deckElementLimits;
		}
		set
		{
			deckElementLimits = value;
		}
	}

	public static int[] DeckStyleLimits
	{
		get
		{
			return deckStyleLimits;
		}
		set
		{
			deckStyleLimits = value;
		}
	}

	public PoppetDeckCtrl()
	{
		mode = Mode.None;
		lastMode = Mode.None;
	}

	public void Awake()
	{
		if (null != listButton)
		{
			listButton.gameObject.SetActive(value: true);
		}
		if (null != boxCtrl)
		{
			boxCtrl.ActiveFunc = CustomActiveFunc;
			GameObject[] infoWindows = boxCtrl.infoWindows;
			UIAutoTweenerStandAloneEx.InitUIAutoTweenerToStandAloneEx(infoWindows[RuntimeServices.NormalizeArrayIndex(infoWindows, 1)], hide: true);
			GameObject[] infoWindows2 = boxCtrl.infoWindows;
			UIAutoTweenerStandAloneEx.InitUIAutoTweenerToStandAloneEx(infoWindows2[RuntimeServices.NormalizeArrayIndex(infoWindows2, 2)], hide: true);
		}
	}

	public void Start()
	{
		InitModeWindow();
		mode = Mode.DeckSelect;
		lastMode = Mode.None;
	}

	public void OnEnable()
	{
		mode = Mode.DeckSelect;
		lastMode = Mode.None;
	}

	public void OnDestroy()
	{
		Close();
	}

	public void Update()
	{
		if (!nowBusy)
		{
			if (lastMode != mode)
			{
				lastMode = mode;
				ModeInit();
			}
			ModeUpdate();
		}
	}

	protected void ModeInit()
	{
		int activeIndex = (int)mode;
		boxCtrl.SwitchInfoWindow(activeIndex);
		if (mode == Mode.DeckSelect)
		{
			CreateBackButton(gameObject);
			if (null != listButton && listButton.active)
			{
				UIAutoTweenerStandAloneEx.Out(listButton);
			}
			InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SETUP_DECK"));
			curWeapon = null;
			curPoppet = null;
		}
		else if (mode == Mode.WeaponList)
		{
			WeaponInitialize();
			UIAutoTweenerStandAloneEx.In(listButton);
			InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SELECT_WEAPON"));
		}
		else if (mode == Mode.PoppetList)
		{
			PoppetInitialize();
			UIAutoTweenerStandAloneEx.In(listButton);
			InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_SELECT_POPPET"));
		}
		else if (mode == Mode.WeaponDetail)
		{
			if (null != listButton && listButton.active)
			{
				UIAutoTweenerStandAloneEx.Out(listButton);
			}
			InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_WEAPON_DETAIL"));
		}
		else if (mode == Mode.PoppetDetail)
		{
			if (null != listButton && listButton.active)
			{
				UIAutoTweenerStandAloneEx.Out(listButton);
			}
			InfomationBarHUD.UpdateText(MTexts.Msg("$COLOSSEUM_POPPET_DETAIL"));
		}
	}

	protected void ModeUpdate()
	{
		if (mode == Mode.DeckSelect)
		{
			UpdateDeckLimits();
		}
		else if (mode != Mode.WeaponList && mode != Mode.PoppetList && mode != Mode.WeaponDetail && mode != Mode.PoppetDetail)
		{
		}
	}

	public void PushWeapon(int id)
	{
		if (!DeckSelector.isSwipe && !nowBusy)
		{
			curId = id;
			ChangeMode(Mode.WeaponList);
		}
	}

	public void PushPoppet(int id)
	{
		if (!DeckSelector.isSwipe && !nowBusy)
		{
			curId = id;
			ChangeMode(Mode.PoppetList);
		}
	}

	public void PushBack()
	{
		if (DeckSelector.isSwipe || nowBusy)
		{
			return;
		}
		if (mode == Mode.DeckSelect)
		{
			nowOut = true;
			GameObject[] infoWindows = boxCtrl.infoWindows;
			UIAutoTweenerStandAloneEx.Out(infoWindows[RuntimeServices.NormalizeArrayIndex(infoWindows, (int)mode)], _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				nowOut = false;
				Close();
				UIButtonMessage button = ButtonBackHUD.GetButton();
				if (null != button && null != button.target)
				{
					button.target.SendMessage(button.functionName, button.gameObject);
					gameObject.SetActive(value: false);
				}
			}));
		}
		else if (mode == Mode.WeaponList)
		{
			ChangeMode(Mode.DeckSelect);
		}
		else if (mode == Mode.PoppetList)
		{
			ChangeMode(Mode.DeckSelect);
		}
		else if (mode == Mode.WeaponDetail)
		{
			ChangeMode(Mode.WeaponList);
		}
		else if (mode == Mode.PoppetDetail)
		{
			ChangeMode(Mode.PoppetList);
		}
	}

	public void PushDecide()
	{
		if (!nowBusy)
		{
			if (mode == Mode.WeaponList)
			{
				WeaponDecide();
			}
			else if (mode == Mode.PoppetList)
			{
				PoppetDecide();
			}
			updateCostMax = true;
			updateRarityLimits = true;
			updateElementLimits = true;
			updateStyleLimits = true;
			if (SceneChanger.CurrentScene == SceneID.Ui_WorldColosseum)
			{
				QuestMenuBase.IsEquipChanged = true;
			}
			ChangeMode(Mode.DeckSelect);
		}
	}

	public void PushDetail()
	{
		if (!nowBusy)
		{
			if (mode == Mode.WeaponList)
			{
				ChangeMode(Mode.WeaponDetail);
				WeaponDetail();
			}
			else if (mode == Mode.PoppetList)
			{
				ChangeMode(Mode.PoppetDetail);
				PoppetDetail();
			}
		}
	}

	protected void AtciveModeWindow()
	{
		int activeIndex = (int)mode;
		boxCtrl.SwitchInfoWindow(activeIndex);
	}

	protected void InitModeWindow()
	{
		int i = 0;
		GameObject[] infoWindows = boxCtrl.infoWindows;
		for (int length = infoWindows.Length; i < length; i = checked(i + 1))
		{
			UIAutoTweenerStandAloneEx.Hide(infoWindows[i]);
		}
		UIAutoTweenerStandAloneEx.Hide(listButton);
	}

	protected void CustomActiveFunc(int index, bool active)
	{
		if (active)
		{
			nowIn = true;
			GameObject[] infoWindows = boxCtrl.infoWindows;
			UIAutoTweenerStandAloneEx.In(infoWindows[RuntimeServices.NormalizeArrayIndex(infoWindows, index)], _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				nowIn = false;
			}));
			return;
		}
		GameObject[] infoWindows2 = boxCtrl.infoWindows;
		if (infoWindows2[RuntimeServices.NormalizeArrayIndex(infoWindows2, index)].active)
		{
			nowOut = true;
			GameObject[] infoWindows3 = boxCtrl.infoWindows;
			UIAutoTweenerStandAloneEx.Out(infoWindows3[RuntimeServices.NormalizeArrayIndex(infoWindows3, index)], _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				nowOut = false;
			}));
		}
	}

	protected void ChangeMode(Mode nextMode)
	{
		if (!nowBusy)
		{
			mode = nextMode;
		}
	}

	private bool IsEnableRarity(int id)
	{
		return ColosseumPoppetSetInfo.CheckLimit(deckRarityLimits, id);
	}

	private bool IsEnableElement(int id)
	{
		return ColosseumPoppetSetInfo.CheckLimit(deckElementLimits, id);
	}

	private bool IsEnableStyle(int id)
	{
		return ColosseumPoppetSetInfo.CheckLimit(deckStyleLimits, id);
	}

	private void WeaponInitialize()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		RespWeapon[] boxWeapons = current.BoxWeapons;
		weaponList.HookAutoFocusItem = hookAutoFocusWeaponItem;
		weaponList.HookSettingListItem = hookSettingWeaponListItem;
		weaponList.hookSelectItem = hookWeaponListSelect;
		weaponList.DelegateDecide = PushDecide;
		weaponList.SetInputWeaponList(boxWeapons);
		if ((bool)weaponList.sortButton)
		{
			weaponList.sortButton.CheckCloseFunc = delegate
			{
				bool num = mode == Mode.PoppetList;
				if (!num)
				{
					num = mode == Mode.WeaponList;
				}
				return !num;
			};
		}
		if (curWeapon == null)
		{
			int currentDeckIndex = DeckSelector.currentDeckIndex;
			if (0 > currentDeckIndex || currentDeckIndex >= 5)
			{
				return;
			}
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			ColosseumEquipments colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
			if (colosseumEquipments == null)
			{
				return;
			}
			if (curId == 0)
			{
				if (colosseumEquipments != null)
				{
					weaponList.SelectItemById(colosseumEquipments.MainPoppet.Weapon.Id.Value, canDecide: false);
				}
			}
			else if (1 == curId)
			{
				if (colosseumEquipments != null)
				{
					weaponList.SelectItemById(colosseumEquipments.SubPoppets[0].Weapon.Id.Value, canDecide: false);
				}
			}
			else if (2 == curId && colosseumEquipments != null)
			{
				weaponList.SelectItemById(colosseumEquipments.SubPoppets[1].Weapon.Id.Value, canDecide: false);
			}
		}
		else
		{
			weaponList.SelectItemById(curWeapon.Id.Value, canDecide: false);
		}
	}

	private bool hookAutoFocusWeaponItem(ref UIListItem.Data dstData)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		dstData = null;
		BoxId boxId = BoxId.InvalidId;
		int currentDeckIndex = DeckSelector.currentDeckIndex;
		ColosseumEquipments colosseumEquipments = null;
		if (0 <= currentDeckIndex && currentDeckIndex < 5)
		{
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
		}
		if (curId == 0)
		{
			boxId = colosseumEquipments.MainPoppet.Weapon.Id;
		}
		else if (1 == curId)
		{
			boxId = colosseumEquipments.SubPoppets[0].Weapon.Id;
		}
		else if (2 == curId)
		{
			boxId = colosseumEquipments.SubPoppets[1].Weapon.Id;
		}
		int i = 0;
		UIListItem.Data[] dataList = weaponList.GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(boxId, dataList[i].GetData<RespWeapon>().Id))
			{
				dstData = dataList[i];
				break;
			}
		}
		return true;
	}

	private bool hookSettingWeaponListItem(UIListItem item)
	{
		_0024hookSettingWeaponListItem_0024locals_002414478 _0024hookSettingWeaponListItem_0024locals_0024 = new _0024hookSettingWeaponListItem_0024locals_002414478();
		int result;
		if (!item)
		{
			result = 1;
		}
		else
		{
			RespWeapon data = item.GetData<RespWeapon>();
			if (data != null)
			{
				string value = (item.UsingText = UseText(data.Id));
				item.Using = !string.IsNullOrEmpty(value);
				item.Disable = false;
				_0024hookSettingWeaponListItem_0024locals_0024._0024enableItem = isEnableWeapon(data);
				_0024hookSettingWeaponListItem_0024locals_0024._0024wepItem = (WeaponListItem)item;
				__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024hookSettingWeaponListItem_0024closure_00243146(_0024hookSettingWeaponListItem_0024locals_0024).Invoke;
				IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
				weaponList.weponHookSettingListItem(item);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	protected bool hookWeaponListSelect(UIListItem item)
	{
		WeaponListItem weaponListItem = (WeaponListItem)item;
		curWeapon = item.GetData<RespWeapon>();
		return false;
	}

	private bool isEnableWeapon(RespWeapon weapon)
	{
		return weapon != null && (IsEnableStyle(weapon.Style.Id) ? true : false);
	}

	private void PoppetInitialize()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		RespPoppet[] boxPoppets = current.BoxPoppets;
		poppetList.HookAutoFocusItem = hookAutoFocusPetItem;
		poppetList.hookSelectItem = hookPoppetListSelect;
		poppetList.HookSettingListItem = hookSettingPetListItem;
		poppetList.DelegateDecide = PushDecide;
		poppetList.SetInputMapetList(boxPoppets);
		if ((bool)poppetList.sortButton)
		{
			poppetList.sortButton.CheckCloseFunc = delegate
			{
				bool num = mode == Mode.PoppetList;
				if (!num)
				{
					num = mode == Mode.WeaponList;
				}
				return !num;
			};
		}
		ColosseumEquipments colosseumEquipments = default(ColosseumEquipments);
		if (curPoppet == null)
		{
			int currentDeckIndex = DeckSelector.currentDeckIndex;
			if (0 > currentDeckIndex || currentDeckIndex >= 5)
			{
				return;
			}
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
			if (colosseumEquipments == null)
			{
				return;
			}
			if (curId == 0)
			{
				if (colosseumEquipments != null)
				{
					poppetList.SelectItemById(colosseumEquipments.MainPoppet.Poppet.Id.Value, canDecide: false);
				}
			}
			else if (1 == curId)
			{
				if (colosseumEquipments != null)
				{
					poppetList.SelectItemById(colosseumEquipments.SubPoppets[0].Poppet.Id.Value, canDecide: false);
				}
			}
			else if (2 == curId && colosseumEquipments != null)
			{
				poppetList.SelectItemById(colosseumEquipments.SubPoppets[1].Poppet.Id.Value, canDecide: false);
			}
		}
		else if (colosseumEquipments != null)
		{
			poppetList.SelectItemById(curPoppet.Id.Value, canDecide: false);
		}
	}

	private bool hookAutoFocusPetItem(ref UIListItem.Data dstData)
	{
		UserData current = UserData.Current;
		dstData = null;
		int currentDeckIndex = DeckSelector.currentDeckIndex;
		ColosseumEquipments colosseumEquipments = null;
		if (0 <= currentDeckIndex && currentDeckIndex < 5)
		{
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
		}
		BoxId id = default(BoxId);
		if (curId == 0)
		{
			id = colosseumEquipments.MainPoppet.Poppet.Id;
		}
		else if (1 == curId)
		{
			id = colosseumEquipments.SubPoppets[0].Poppet.Id;
		}
		else if (2 == curId)
		{
			id = colosseumEquipments.SubPoppets[1].Poppet.Id;
		}
		int i = 0;
		UIListItem.Data[] dataList = poppetList.GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(id, dataList[i].GetData<RespPoppet>().Id))
			{
				dstData = dataList[i];
				break;
			}
		}
		return true;
	}

	private bool hookSettingPetListItem(UIListItem item)
	{
		_0024hookSettingPetListItem_0024locals_002414479 _0024hookSettingPetListItem_0024locals_0024 = new _0024hookSettingPetListItem_0024locals_002414479();
		int result;
		if (!item)
		{
			result = 1;
		}
		else
		{
			RespPoppet data = item.GetData<RespPoppet>();
			if (data != null)
			{
				string value = (item.UsingText = UseText(data.Id));
				item.Using = !string.IsNullOrEmpty(value);
				item.Disable = false;
				bool num = isEnablePoppet(data);
				if (num)
				{
					num = isEnablePoppetCost(data);
				}
				_0024hookSettingPetListItem_0024locals_0024._0024enableItem = num;
				_0024hookSettingPetListItem_0024locals_0024._0024petItem = (MapetListItem)item;
				__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024hookSettingPetListItem_0024closure_00243147(_0024hookSettingPetListItem_0024locals_0024).Invoke;
				IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
				if (enumerator != null)
				{
					StartCoroutine(enumerator);
				}
				poppetList.poppetHookSettingListItem(item);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	protected bool hookPoppetListSelect(UIListItem item)
	{
		MapetListItem mapetListItem = (MapetListItem)item;
		curPoppet = item.GetData<RespPoppet>();
		return false;
	}

	private bool isEnablePoppet(RespPoppet poppet)
	{
		return poppet != null && IsEnableRarity(poppet.Rare.Id) && (IsEnableElement(poppet.Element.Id) ? true : false);
	}

	private bool isEnablePoppetCost(RespPoppet poppet)
	{
		int result;
		checked
		{
			if (poppet == null)
			{
				result = 0;
			}
			else if (0 >= deckCostMax)
			{
				result = 1;
			}
			else
			{
				int currentDeckIndex = DeckSelector.currentDeckIndex;
				ColosseumEquipments colosseumEquipments = null;
				RespPoppet respPoppet = null;
				int num = 0;
				int num2 = 0;
				if (0 <= currentDeckIndex && currentDeckIndex < 5)
				{
					ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
					colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
				}
				if (colosseumEquipments != null)
				{
					num2 = colosseumEquipments.GetCost();
					if (RuntimeServices.EqualityOperator(colosseumEquipments.MainPoppet.Poppet, poppet) || RuntimeServices.EqualityOperator(colosseumEquipments.SubPoppets[0].Poppet, poppet) || RuntimeServices.EqualityOperator(colosseumEquipments.SubPoppets[1].Poppet, poppet))
					{
						result = ((num2 <= deckCostMax) ? 1 : 0);
						goto IL_0150;
					}
					if (curId == 0)
					{
						respPoppet = colosseumEquipments.MainPoppet.Poppet;
					}
					else if (1 == curId)
					{
						respPoppet = colosseumEquipments.SubPoppets[0].Poppet;
					}
					else if (2 == curId)
					{
						respPoppet = colosseumEquipments.SubPoppets[1].Poppet;
					}
				}
				if (RuntimeServices.EqualityOperator(poppet, respPoppet))
				{
					result = 1;
				}
				else
				{
					if (respPoppet != null)
					{
						num2 -= respPoppet.DeckCost;
					}
					result = ((poppet.DeckCost + num2 <= deckCostMax) ? 1 : 0);
				}
			}
			goto IL_0150;
		}
		IL_0150:
		return (byte)result != 0;
	}

	private void WeaponDecide()
	{
		UIListItem.Data focusItem = weaponList.focusItem;
		if (focusItem == null)
		{
			return;
		}
		RespWeapon data = focusItem.GetData<RespWeapon>();
		if (data != null)
		{
			int currentDeckIndex = DeckSelector.currentDeckIndex;
			ColosseumEquipments eq = null;
			if (0 <= currentDeckIndex && currentDeckIndex < 5)
			{
				ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
				eq = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
			}
			SetWeaponId(ref eq, data.Id);
			DeckSelector.SetCurEquip();
		}
	}

	private void SetWeaponId(ref ColosseumEquipments eq, BoxId select)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		if (!(null != weaponList))
		{
			throw new AssertionFailedException("null != weaponList");
		}
		if (eq == null)
		{
			throw new AssertionFailedException("null != eq");
		}
		if (eq.MainPoppet == null)
		{
			throw new AssertionFailedException("null != eq.MainPoppet");
		}
		if (eq.SubPoppets == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets");
		}
		if (eq.SubPoppets[0] == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets[0]");
		}
		if (eq.SubPoppets[1] == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets[1]");
		}
		RespWeapon weapon = default(RespWeapon);
		if (curId == 0)
		{
			weapon = eq.MainPoppet.Weapon;
		}
		else if (1 == curId)
		{
			weapon = eq.SubPoppets[0].Weapon;
		}
		else if (2 == curId)
		{
			weapon = eq.SubPoppets[1].Weapon;
		}
		RespWeapon respWeapon = weapon;
		if (RuntimeServices.EqualityOperator(select, eq.MainPoppet.Weapon.Id))
		{
			eq.MainPoppet.Weapon = weapon;
		}
		else if (RuntimeServices.EqualityOperator(select, eq.SubPoppets[0].Weapon.Id))
		{
			eq.SubPoppets[0].Weapon = weapon;
		}
		else if (RuntimeServices.EqualityOperator(select, eq.SubPoppets[1].Weapon.Id))
		{
			eq.SubPoppets[1].Weapon = weapon;
		}
		weapon = current.boxWeapon(select);
		if (curId == 0)
		{
			eq.MainPoppet.Weapon = weapon;
		}
		else if (1 == curId)
		{
			eq.SubPoppets[0].Weapon = weapon;
		}
		else if (2 == curId)
		{
			eq.SubPoppets[1].Weapon = weapon;
		}
		weaponList.ResetListItem(respWeapon.Id.Value);
		weaponList.ResetListItem(weapon.Id.Value);
	}

	private void PoppetDecide()
	{
		UIListItem.Data focusItem = poppetList.focusItem;
		if (focusItem == null)
		{
			return;
		}
		RespPoppet data = focusItem.GetData<RespPoppet>();
		if (data != null)
		{
			int currentDeckIndex = DeckSelector.currentDeckIndex;
			ColosseumEquipments eq = null;
			if (0 <= currentDeckIndex && currentDeckIndex < 5)
			{
				ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
				eq = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
			}
			SetPoppetId(ref eq, data.Id);
			DeckSelector.SetCurEquip();
		}
	}

	private void SetPoppetId(ref ColosseumEquipments eq, BoxId select)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		if (!(null != poppetList))
		{
			throw new AssertionFailedException("null != poppetList");
		}
		if (eq == null)
		{
			throw new AssertionFailedException("null != eq");
		}
		if (eq.MainPoppet == null)
		{
			throw new AssertionFailedException("null != eq.MainPoppet");
		}
		if (eq.SubPoppets == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets");
		}
		if (eq.SubPoppets[0] == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets[0]");
		}
		if (eq.SubPoppets[1] == null)
		{
			throw new AssertionFailedException("null != eq.SubPoppets[1]");
		}
		RespPoppet poppet = default(RespPoppet);
		if (curId == 0)
		{
			poppet = eq.MainPoppet.Poppet;
		}
		else if (1 == curId)
		{
			poppet = eq.SubPoppets[0].Poppet;
		}
		else if (2 == curId)
		{
			poppet = eq.SubPoppets[1].Poppet;
		}
		RespPoppet respPoppet = poppet;
		if (RuntimeServices.EqualityOperator(select, eq.MainPoppet.Poppet.Id))
		{
			eq.MainPoppet.Poppet = poppet;
		}
		else if (RuntimeServices.EqualityOperator(select, eq.SubPoppets[0].Poppet.Id))
		{
			eq.SubPoppets[0].Poppet = poppet;
		}
		else if (RuntimeServices.EqualityOperator(select, eq.SubPoppets[1].Poppet.Id))
		{
			eq.SubPoppets[1].Poppet = poppet;
		}
		poppet = current.boxPoppet(select);
		if (curId == 0)
		{
			eq.MainPoppet.Poppet = poppet;
		}
		else if (1 == curId)
		{
			eq.SubPoppets[0].Poppet = poppet;
		}
		else if (2 == curId)
		{
			eq.SubPoppets[1].Poppet = poppet;
		}
		poppetList.ResetListItem(respPoppet.Id.Value);
		poppetList.ResetListItem(poppet.Id.Value);
	}

	private string UseText(BoxId id)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		int currentDeckIndex = DeckSelector.currentDeckIndex;
		ColosseumEquipments colosseumEquipments = null;
		if (0 <= currentDeckIndex && currentDeckIndex < 5)
		{
			ColosseumEquipments[] colEquips = UserData.Current.userPoppetDeckData.ColEquips;
			colosseumEquipments = colEquips[RuntimeServices.NormalizeArrayIndex(colEquips, currentDeckIndex)];
		}
		string text = "使用中";
		if (colosseumEquipments.MainPoppet == null)
		{
			goto IL_00cf;
		}
		string result;
		if (colosseumEquipments.MainPoppet.Weapon != null && RuntimeServices.EqualityOperator(id, colosseumEquipments.MainPoppet.Weapon.Id))
		{
			result = text;
		}
		else
		{
			if (colosseumEquipments.MainPoppet.Poppet == null || !RuntimeServices.EqualityOperator(id, colosseumEquipments.MainPoppet.Poppet.Id))
			{
				goto IL_00cf;
			}
			result = text;
		}
		goto IL_01ea;
		IL_01e5:
		result = string.Empty;
		goto IL_01ea;
		IL_015a:
		if (colosseumEquipments.SubPoppets[1] == null)
		{
			goto IL_01e5;
		}
		if (colosseumEquipments.SubPoppets[1].Weapon != null && RuntimeServices.EqualityOperator(id, colosseumEquipments.SubPoppets[1].Weapon.Id))
		{
			result = text;
		}
		else
		{
			if (colosseumEquipments.SubPoppets[1].Poppet == null || !RuntimeServices.EqualityOperator(id, colosseumEquipments.SubPoppets[1].Poppet.Id))
			{
				goto IL_01e5;
			}
			result = text;
		}
		goto IL_01ea;
		IL_00cf:
		if (colosseumEquipments.SubPoppets[0] == null)
		{
			goto IL_015a;
		}
		if (colosseumEquipments.SubPoppets[0].Weapon != null && RuntimeServices.EqualityOperator(id, colosseumEquipments.SubPoppets[0].Weapon.Id))
		{
			result = text;
		}
		else
		{
			if (colosseumEquipments.SubPoppets[0].Poppet == null || !RuntimeServices.EqualityOperator(id, colosseumEquipments.SubPoppets[0].Poppet.Id))
			{
				goto IL_015a;
			}
			result = text;
		}
		goto IL_01ea;
		IL_01ea:
		return result;
	}

	public void WeaponDetail()
	{
		if (!weaponDetailInfo)
		{
			throw new AssertionFailedException("weaponDetailInfo");
		}
		RespWeapon focusData = weaponList.GetFocusData<RespWeapon>();
		weaponDetailInfo.SetWeapon(focusData);
		UIAutoTweenerStandAloneEx.In(weaponDetailInfo.gameObject);
	}

	public void PoppetDetail()
	{
		if (!poppetDetailInfo)
		{
			throw new AssertionFailedException("poppetDetailInfo");
		}
		RespPoppet focusData = poppetList.GetFocusData<RespPoppet>();
		poppetDetailInfo.SetMuppet(focusData);
		UIAutoTweenerStandAloneEx.In(poppetDetailInfo.gameObject);
	}

	public UIButtonMessage CreateBackButton(GameObject target)
	{
		object result;
		if (btnBackup == null && !(null == ButtonBackHUD.Instance))
		{
			UIButtonMessage button = ButtonBackHUD.GetButton();
			if (!(button != null))
			{
				throw new AssertionFailedException("BackButtonHUD がありません!!!");
			}
			btnBackup = new CacheButtonMessage();
			btnBackup.target = button.target;
			btnBackup.functionName = button.functionName;
			button.target = target;
			button.functionName = "PushBack";
			button.sendMessage = true;
			result = button;
		}
		else
		{
			result = null;
		}
		return (UIButtonMessage)result;
	}

	public void Close()
	{
		if (btnBackup != null)
		{
			bool flag = false;
			ModalCollider.SetActive(this, active: false);
			if (!(null == ButtonBackHUD.Instance))
			{
				UIButtonMessage button = ButtonBackHUD.GetButton();
				button.target = btnBackup.target;
				button.functionName = btnBackup.functionName;
				btnBackup = null;
			}
		}
	}

	private void UpdateDeckLimits()
	{
		DeckColosseum deckColosseum = DeckColosseum.Current();
		if (!(null != deckColosseum))
		{
			throw new AssertionFailedException("null != deckCol");
		}
		if (deckColosseum.deckCount != 0)
		{
			if (updateCostMax)
			{
				deckColosseum.SetCostMax(deckCostMax);
				updateCostMax = false;
			}
			if (updateRarityLimits)
			{
				deckColosseum.SetRarityLimit(deckRarityLimits);
				updateRarityLimits = false;
			}
			if (updateElementLimits)
			{
				deckColosseum.SetElementLimit(deckElementLimits);
				updateElementLimits = false;
			}
			if (updateStyleLimits)
			{
				deckColosseum.SetStyleLimit(deckStyleLimits);
				updateStyleLimits = false;
			}
		}
	}

	public static void SetCostMax(int costMax)
	{
		deckCostMax = costMax;
		updateCostMax = true;
	}

	public static void SetRarityLimit(int minLimit, int maxLimit)
	{
		deckRarityLimits = new int[0];
		if (minLimit != 0 || maxLimit != 0)
		{
			if (minLimit == 0)
			{
				minLimit = 1;
			}
			if (maxLimit == 0)
			{
				maxLimit = MRares.All.Length;
			}
			if (minLimit <= maxLimit)
			{
				int num = minLimit;
				int num2 = checked(maxLimit + 1);
				int num3 = 1;
				if (num2 < num)
				{
					num3 = -1;
				}
				while (num != num2)
				{
					int num4 = num;
					num += num3;
					deckRarityLimits = (int[])RuntimeServices.AddArrays(typeof(int), deckRarityLimits, new int[1] { num4 });
				}
			}
		}
		updateRarityLimits = true;
	}

	public static void SetElementLimit(int[] limits)
	{
		deckElementLimits = limits;
		updateElementLimits = true;
	}

	public static void SetStyleLimit(int[] limits)
	{
		deckStyleLimits = limits;
		updateStyleLimits = true;
	}

	internal bool _0024WeaponInitialize_0024closure_00243141()
	{
		bool num = mode == Mode.PoppetList;
		if (!num)
		{
			num = mode == Mode.WeaponList;
		}
		return !num;
	}

	internal bool _0024PoppetInitialize_0024closure_00243142()
	{
		bool num = mode == Mode.PoppetList;
		if (!num)
		{
			num = mode == Mode.WeaponList;
		}
		return !num;
	}

	internal void _0024PushBack_0024closure_00243143()
	{
		nowOut = false;
		Close();
		UIButtonMessage button = ButtonBackHUD.GetButton();
		if (null != button && null != button.target)
		{
			button.target.SendMessage(button.functionName, button.gameObject);
			gameObject.SetActive(value: false);
		}
	}

	internal void _0024CustomActiveFunc_0024closure_00243144()
	{
		nowIn = false;
	}

	internal void _0024CustomActiveFunc_0024closure_00243145()
	{
		nowOut = false;
	}
}
