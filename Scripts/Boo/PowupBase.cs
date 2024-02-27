using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public abstract class PowupBase : UIMain
{
	[Serializable]
	public enum POWUP_MODE
	{
		PowupTop,
		PowupItem,
		PowupMaterial,
		PowupConf,
		PowupDemoInit,
		PowupDemo,
		PowupResult,
		PowupUltEvo,
		Max
	}

	[Serializable]
	public enum CompDataType
	{
		Normal,
		UltA,
		UltB,
		Max
	}

	[Serializable]
	public class CompositionDatas
	{
		public string name;

		public CompDataType type;

		public IconCreator[] matIconCreator;

		public UIListItem afterPanel;

		public IconCreator afterIconCreator;

		public UILabelBase costLabel;

		public UIButtonMessage startButton;

		public GameObject campaignPrefab;

		public Transform[] campaignPos;

		private UIListItem[] matPanels;

		private JsonBase[] matInfos;

		private UIBasicUtility.ButtonSet startButtonSet;

		public UIListItem[] panels => matPanels;

		public JsonBase[] infos
		{
			get
			{
				return matInfos;
			}
			set
			{
				matInfos = value;
			}
		}

		public UIBasicUtility.ButtonSet buttonSet => startButtonSet;

		public CompositionDatas()
		{
			name = "Default";
			type = CompDataType.Normal;
			matIconCreator = new IconCreator[5];
			campaignPos = new Transform[3];
			matPanels = new UIListItem[5];
			matInfos = new JsonBase[5];
		}

		public void Init(bool isPowupScene)
		{
			matPanels = CreatePanels(matIconCreator);
			InitAfter(afterPanel, afterIconCreator);
			CampaignsController.InitCampaigns(campaignPos, campaignPrefab, isPowupScene);
			startButtonSet = UIBasicUtility.CreateButtonSet(startButton);
		}

		private UIListItem[] CreatePanels(IconCreator[] creatorList)
		{
			System.Collections.Generic.List<UIListItem> list = new System.Collections.Generic.List<UIListItem>();
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				IconCreator iconCreator = creatorList[RuntimeServices.NormalizeArrayIndex(creatorList, index)];
				if (!(iconCreator == null))
				{
					GameObject gameObject = iconCreator.CreateIcon();
					UIListItem component = gameObject.GetComponent<UIListItem>();
					GameObject levelObject = component.GetLevelObject();
					if (levelObject != null)
					{
						Vector3 localPosition = levelObject.transform.localPosition;
						localPosition.z -= 10f;
						levelObject.transform.localPosition = localPosition;
					}
					list.Add(component);
				}
			}
			return list.ToArray();
		}

		private void InitAfter(UIListItem panel, IconCreator creator)
		{
			if (!(panel == null) && !(creator == null))
			{
				GameObject gameObject = creator.CreateIcon();
				UIListItem component = gameObject.GetComponent<UIListItem>();
				component.enabled = false;
				IconInfoObject component2 = gameObject.GetComponent<IconInfoObject>();
				if (component2 != null)
				{
					component2.CopyOut(panel);
				}
				panel.DestroyLevel();
			}
		}
	}

	[Serializable]
	internal class _0024CheckMaterialIds_0024locals_002414533
	{
		internal RespPlayerBox[] _0024usingList;
	}

	[Serializable]
	internal class _0024SetToMaterialList_0024locals_002414534
	{
		internal RespWeaponPoppet[] _0024ary;
	}

	[Serializable]
	internal class _0024CheckMaterialIds_0024isfound_00244257
	{
		internal _0024CheckMaterialIds_0024locals_002414533 _0024_0024locals_002415191;

		public _0024CheckMaterialIds_0024isfound_00244257(_0024CheckMaterialIds_0024locals_002414533 _0024_0024locals_002415191)
		{
			this._0024_0024locals_002415191 = _0024_0024locals_002415191;
		}

		public bool Invoke(BoxId id)
		{
			if (id.IsValid)
			{
				int num = 0;
				RespPlayerBox[] _0024usingList = _0024_0024locals_002415191._0024usingList;
				int length = _0024usingList.Length;
				while (num < length)
				{
					if (_0024usingList[num] == null || !RuntimeServices.EqualityOperator(_0024usingList[num].Id, id))
					{
						num = checked(num + 1);
						continue;
					}
					goto IL_0054;
				}
			}
			int result = 0;
			goto IL_0066;
			IL_0066:
			return (byte)result != 0;
			IL_0054:
			result = 1;
			goto IL_0066;
		}
	}

	[Serializable]
	internal class _0024SetToMaterialList_0024func_00244260
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421879 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal RespWeaponPoppet _0024a_002421880;

				internal int _0024id_002421881;

				internal int _0024_002411628_002421882;

				internal RespWeaponPoppet[] _0024_002411629_002421883;

				internal int _0024_002411630_002421884;

				internal _0024SetToMaterialList_0024func_00244260 _0024self__002421885;

				public _0024(_0024SetToMaterialList_0024func_00244260 self_)
				{
					_0024self__002421885 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					checked
					{
						switch (_state)
						{
						default:
							_0024self__002421885._0024this_002415193.materialItemList.ClearSelectItems();
							result = (YieldDefault(2) ? 1 : 0);
							break;
						case 2:
							_0024_002411628_002421882 = 0;
							_0024_002411629_002421883 = _0024self__002421885._0024_0024locals_002415192._0024ary;
							for (_0024_002411630_002421884 = _0024_002411629_002421883.Length; _0024_002411628_002421882 < _0024_002411630_002421884; _0024_002411628_002421882++)
							{
								_0024id_002421881 = (int)_0024_002411629_002421883[_0024_002411628_002421882].Id.Value;
								if (!_0024self__002421885._0024this_002415193.materialItemList.ContainsSelect(_0024id_002421881))
								{
									_0024self__002421885._0024this_002415193.materialItemList.SelectItemById(_0024id_002421881);
								}
							}
							result = (YieldDefault(3) ? 1 : 0);
							break;
						case 3:
							_0024self__002421885._0024this_002415193.InitMaterialDisplay();
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

			internal _0024SetToMaterialList_0024func_00244260 _0024self__002421886;

			public _0024Invoke_002421879(_0024SetToMaterialList_0024func_00244260 self_)
			{
				_0024self__002421886 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421886);
			}
		}

		internal _0024SetToMaterialList_0024locals_002414534 _0024_0024locals_002415192;

		internal PowupBase _0024this_002415193;

		public _0024SetToMaterialList_0024func_00244260(_0024SetToMaterialList_0024locals_002414534 _0024_0024locals_002415192, PowupBase _0024this_002415193)
		{
			this._0024_0024locals_002415192 = _0024_0024locals_002415192;
			this._0024this_002415193 = _0024this_002415193;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421879(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024CallBackRequest_0024CallBackRequestCore_00244259_002421874 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiCompositionBase _0024reqBase_002421875;

			internal PowupBase _0024self__002421876;

			public _0024(ApiCompositionBase reqBase, PowupBase self_)
			{
				_0024reqBase_002421875 = reqBase;
				_0024self__002421876 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					StorageHUD.DoUpdateNow();
					_0024self__002421876.mode = POWUP_MODE.PowupDemo;
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					_0024self__002421876.CallBackCreateItem(_0024reqBase_002421875);
					UserData.Current.userDeckData2.updateEquipments();
					UserData.Current.userPoppetDeckData.updateEquipments();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ApiCompositionBase _0024reqBase_002421877;

		internal PowupBase _0024self__002421878;

		public _0024_0024CallBackRequest_0024CallBackRequestCore_00244259_002421874(ApiCompositionBase reqBase, PowupBase self_)
		{
			_0024reqBase_002421877 = reqBase;
			_0024self__002421878 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024reqBase_002421877, _0024self__002421878);
		}
	}

	[NonSerialized]
	public const int SELECT_MAX = 5;

	protected POWUP_MODE mode;

	protected POWUP_MODE lastMode;

	private string[] titleNames;

	protected bool isPowupScene;

	protected bool isWeaponScene;

	public int count;

	public GameObject bgPanel;

	protected GameObject demoAnim;

	public GameObject demoAnimPrefab;

	public GameObject[] rareWarnigLabels;

	public UIDynamicFontLabel combineCheckLabel;

	private string combineCheckText;

	public UISlider newExpGuage;

	public UISlider oldExpGuage;

	public UILabelBase nextExpLabel;

	public UILabelBase resultMessageLabel;

	public string levelUpMessage;

	public string skillUpMessage;

	public string levelMaxUpMessage;

	public string evolutionMessage;

	public UILabelBase sumExpLabel;

	public UILabelBase limitBreakLabel;

	public UILabelBase limitBreakMaxLabel;

	public UIListBase baseItemList;

	public UIListBase materialItemList;

	public UIListItemDetail baseItemDetail;

	public UIListItemDetail resultItemDetail;

	public UIListItem detailItemInfoPanel;

	private CompDataType selectCompDataType;

	public CompositionDatas[] compDatas;

	public UIListItem ultevoBeforeIconPanel;

	public IconCreator ultevoBeforeIconCreator;

	public UIAutoTweener baseItemMoveWindow;

	protected BoxId baseItemBoxId;

	protected BoxId[] materialItemBoxId;

	public BoxId resultItemBoxId;

	public string pouwupTitle;

	public string pouwupItemType;

	public string returnSceneId;

	public string errorSceneId;

	protected UIBasicUtility.ButtonSet decideButtonSet;

	public UILabelBase baseDecideButtoneLabel;

	public UIButtonMessage baseDecideButton;

	private bool isShowDetail;

	public string evoDefResultMesage;

	public string resultNameMessage;

	public UILabelBase resultNameLabel;

	protected string evoBaseItemName;

	protected string evoResultItemName;

	protected JsonBase[] listItemInfo
	{
		get
		{
			JsonBase[] lhs = SelItemInfos(baseItemList);
			return (JsonBase[])RuntimeServices.AddArrays(typeof(JsonBase), lhs, currentCompDatas.infos);
		}
	}

	protected CompositionDatas currentCompDatas
	{
		get
		{
			CompositionDatas[] array = compDatas;
			return array[RuntimeServices.NormalizeArrayIndex(array, (int)selectCompDataType)];
		}
	}

	public POWUP_MODE SequenceMode => mode;

	protected PowupBase()
	{
		titleNames = new string[8];
		isPowupScene = true;
		isWeaponScene = true;
		levelUpMessage = "レベルアップしました。";
		skillUpMessage = "スキルがレベルアップしました。";
		levelMaxUpMessage = "最大レベルがアップしました。";
		evolutionMessage = "進化しました。";
		selectCompDataType = CompDataType.Normal;
		compDatas = new CompositionDatas[1];
		materialItemBoxId = (BoxId[])(new BoxId[1] { BoxId.InvalidId } * 5);
		pouwupTitle = "強化";
		pouwupItemType = "武器";
		returnSceneId = "Ui_TownBlacksmith";
		errorSceneId = "Ui_TownBlacksmith";
		evoDefResultMesage = "{0}";
		resultNameMessage = "{0}";
	}

	public int UltEvoIndex(CompDataType type)
	{
		return Mathf.Max((int)(type - 1), 0);
	}

	protected CompositionDatas GetCompData(int type)
	{
		int num = 0;
		CompositionDatas[] array = compDatas;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num].type == (CompDataType)type)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (CompositionDatas)result;
	}

	private void SetCompDataType(int compType)
	{
		selectCompDataType = (CompDataType)compType;
	}

	private void SetDetailTitle(int mode)
	{
		string[] array = titleNames;
		string text = array[RuntimeServices.NormalizeArrayIndex(array, mode)];
		if (mode == 1 && ((isPowupScene && 0 < materialItemList.selectCount) || !isPowupScene))
		{
			string[] array2 = titleNames;
			text = array2[RuntimeServices.NormalizeArrayIndex(array2, 6)];
		}
		if (!string.IsNullOrEmpty(text))
		{
			SceneTitleHUD.UpdateTitle(text);
		}
	}

	protected void BasicInit()
	{
		decideButtonSet = UIBasicUtility.CreateButtonSet(baseDecideButton);
		baseItemList.selectMax = 1;
		baseItemList.HookSelectItem = delegate(UIListItem item)
		{
			UIBasicUtility.SetButtonValid(decideButtonSet, !item.Disable);
			return false;
		};
		baseItemList.HookSetDetail = delegate(UIListItem.Data data)
		{
			SetPowupBaseDetail(data);
			return false;
		};
		baseItemList.DelegateDecide = delegate
		{
			if (mode == POWUP_MODE.PowupTop)
			{
				PushDecide(null);
			}
		};
		if (baseItemList.sortButton != null)
		{
			baseItemList.sortButton.CheckCloseFunc = () => mode != POWUP_MODE.PowupTop;
		}
		if (!(materialItemList != null))
		{
			return;
		}
		materialItemList.HookSettingListItem = hookSettingMaterialListItem;
		if (materialItemList.sortButton != null)
		{
			materialItemList.sortButton.CheckCloseFunc = () => mode != POWUP_MODE.PowupMaterial;
		}
	}

	private void SwitchEvoDiceidButton(UIListItem.Data @base)
	{
		if (!isPowupScene)
		{
			RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(@base.core as JsonBase);
			if (respWeaponPoppet.CanUltEvolution)
			{
				UIBasicUtility.SetLabel(baseDecideButtoneLabel, "究極進化", show: true);
				float x = 0.9f;
				Vector3 localScale = baseDecideButtoneLabel.transform.localScale;
				float num = (localScale.x = x);
				Vector3 vector2 = (baseDecideButtoneLabel.transform.localScale = localScale);
			}
			else
			{
				UIBasicUtility.SetLabel(baseDecideButtoneLabel, "決定", show: true);
				float x2 = 1.1f;
				Vector3 localScale2 = baseDecideButtoneLabel.transform.localScale;
				float num2 = (localScale2.x = x2);
				Vector3 vector4 = (baseDecideButtoneLabel.transform.localScale = localScale2);
			}
		}
	}

	protected void SetPowupBaseDetail(UIListItem.Data data)
	{
		UIListItem.Data newData = null;
		if (isPowupScene)
		{
			newData = CalcFuture(data, SelItemInfos(materialItemList));
		}
		baseItemDetail.SetPowupDetail(data, newData);
		resultItemDetail.SetPowupDetail(data, null);
	}

	private UIListItem.Data CalcFuture(UIListItem.Data @base, JsonBase[] materials)
	{
		UIListItem.Data data = null;
		checked
		{
			if (@base != null && @base.core != null)
			{
				RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(@base.core as JsonBase);
				if (materials != null && 0 < materials.Length)
				{
					RespWeaponPoppet respWeaponPoppet2 = respWeaponPoppet.Clone();
					int num = respWeaponPoppet.LimitBreakCount;
					int num2 = respWeaponPoppet.AttackPlusBonus;
					int num3 = respWeaponPoppet.HpPlusBonus;
					int i = 0;
					for (int length = materials.Length; i < length; i++)
					{
						if (materials[i] != null)
						{
							RespWeaponPoppet respWeaponPoppet3 = new RespWeaponPoppet(materials[i]);
							if (respWeaponPoppet.canLimitBreak(respWeaponPoppet3))
							{
								num++;
							}
							num2 += respWeaponPoppet3.AttackPlusBonus;
							num3 += respWeaponPoppet3.HpPlusBonus;
						}
					}
					num = Mathf.Clamp(num, respWeaponPoppet.LimitBreakCount, respWeaponPoppet.LimitBreakCountLimit);
					num2 = Mathf.Clamp(num2, respWeaponPoppet.AttackPlusBonus, respWeaponPoppet.PlusBonusMax);
					num3 = Mathf.Clamp(num3, respWeaponPoppet.HpPlusBonus, respWeaponPoppet.PlusBonusMax);
					respWeaponPoppet2.LimitBreakCount = num;
					respWeaponPoppet2.AttackPlusBonus = num2;
					respWeaponPoppet2.HpPlusBonus = num3;
					int[] array = CalcExpAndCost(respWeaponPoppet.data, materials, useCamp: true, 0);
					int num4 = array[0];
					int num5 = array[1];
					num4 += respWeaponPoppet.Exp;
					int value = respWeaponPoppet.exp_to_level(num4);
					value = Mathf.Clamp(value, respWeaponPoppet.Level, respWeaponPoppet2.CurrentLevelLimit);
					respWeaponPoppet2.Exp = num4;
					respWeaponPoppet2.Level = value;
					respWeaponPoppet2.Id = BoxId.InvalidId;
					data = new UIListItem.Data();
					data.core = respWeaponPoppet2.data;
					data.id = 0L;
				}
			}
			return data;
		}
	}

	private bool hookSettingMaterialListItem(UIListItem item)
	{
		if (materialItemList is WeaponList)
		{
			WeaponList weaponList = (WeaponList)materialItemList;
			if ((bool)weaponList)
			{
				weaponList.weponHookSettingListItem(item);
			}
		}
		if (materialItemList is MapetList)
		{
			MapetList mapetList = (MapetList)materialItemList;
			if ((bool)mapetList)
			{
				mapetList.poppetHookSettingListItem(item);
			}
		}
		InitMaterialItem(item);
		return false;
	}

	protected bool CheckDisableByFavorite(BoxId boxId)
	{
		UserData current = UserData.Current;
		int result;
		if (!boxId.IsValid)
		{
			result = 1;
		}
		else
		{
			RespWeapon respWeapon = current.userBoxData.weapon(boxId);
			if (respWeapon != null)
			{
				result = (current.IsFavorite(respWeapon.RefPlayerBox) ? 1 : 0);
			}
			else
			{
				RespPoppet respPoppet = current.userBoxData.poppet(boxId);
				result = ((respPoppet != null && current.IsFavorite(respPoppet.RefPlayerBox)) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	private bool CheckDisableByUsing(BoxId boxId)
	{
		return (!boxId.IsValid && UserData.Current.IsUsing(boxId)) ? true : false;
	}

	protected virtual void SceneInit()
	{
		ButtonBackHUD.SetActive(setActive: true);
		BasicInit();
	}

	protected JsonBase CurItemInfo(UIListBase list)
	{
		JsonBase focusData = list.GetFocusData<JsonBase>();
		return (focusData == null || !Id(focusData).IsValid) ? null : focusData;
	}

	protected JsonBase[] SelItemInfos(UIListBase list)
	{
		return (!isWeaponScene) ? ((JsonBase[])ArrayMapMain.ToRespPoppets(list.GetSelectItemDatas())) : ((JsonBase[])ArrayMapMain.ToRespWeapons(list.GetSelectItemDatas()));
	}

	protected BoxId Id(JsonBase respItem)
	{
		return (respItem == null) ? BoxId.InvalidId : new RespWeaponPoppet(respItem).Id;
	}

	protected void SetItem(UIListItem info, JsonBase respItem)
	{
		SetItem(info, respItem, isUltEvo: false);
	}

	private void SetItem(UIListItem info, JsonBase respItem, bool isUltEvo)
	{
		info.SetNew(isNew: false);
		info.canShowNew = false;
		UILabelBase label = null;
		string text = "hahaha";
		Color c = Color.white;
		if (info is WeaponInfo && respItem is RespWeapon)
		{
			WeaponInfo weaponInfo = (WeaponInfo)info;
			RespWeapon respWeapon = (RespWeapon)respItem;
			if (weaponInfo != null)
			{
				weaponInfo.SetWeapon(respWeapon);
				weaponInfo.Update();
				label = weaponInfo.curNameLabel;
				text = respWeapon.Name;
				c = respWeapon.Element.Color;
			}
		}
		else if (info is MuppetInfo && respItem is RespPoppet)
		{
			MuppetInfo muppetInfo = (MuppetInfo)info;
			RespPoppet respPoppet = (RespPoppet)respItem;
			if (muppetInfo != null)
			{
				muppetInfo.SetMuppet(respPoppet);
				muppetInfo.Update();
				label = muppetInfo.curNameLabel;
				text = respPoppet.Name;
				c = respPoppet.Element.Color;
			}
		}
		if (isUltEvo)
		{
			UIBasicUtility.SetLabel(label, text, show: true);
			UIBasicUtility.SetLabelColor(label, c);
		}
	}

	public virtual void SetupList()
	{
	}

	private void DoListRefreshSort(int idx, UIListBase list)
	{
		if ((bool)list)
		{
			UISituation situation = GetSituation(idx);
			if ((bool)situation)
			{
				situation.gameObject.SetActive(value: true);
				list.RefreshSort();
				situation.gameObject.SetActive(value: false);
			}
		}
	}

	public void RefreshList()
	{
		DoListRefreshSort(0, baseItemList);
		DoListRefreshSort(2, materialItemList);
	}

	protected void InitBaseItem(UIListItem item)
	{
		if (!(item == null))
		{
			object obj = item.GetData().core;
			if (!(obj is JsonBase))
			{
				obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
			}
			RespPlayerBox respPlayerBox = RespPlayerBox.ConvertRespPlayerBox((JsonBase)obj);
			bool use = UserData.Current.IsUsing(respPlayerBox.Id);
			bool disable = !CanCombine(respPlayerBox.Id);
			SetItemState(item, use, disable);
		}
	}

	private void InitMaterialList()
	{
		if (!materialItemList)
		{
			return;
		}
		int i = 0;
		UIListItem[] selectItems = materialItemList.SelectItems;
		checked
		{
			for (int length = selectItems.Length; i < length; i++)
			{
				BoxId boxId = Id(selectItems[i]);
				if (!RuntimeServices.EqualityOperator(boxId, BoxId.InvalidId) && RuntimeServices.EqualityOperator(boxId, baseItemBoxId))
				{
					materialItemList.RemoveSelect(selectItems[i]);
					break;
				}
			}
			int j = 0;
			GameObject[] itemObjectList = materialItemList.GetItemObjectList();
			for (int length2 = itemObjectList.Length; j < length2; j++)
			{
				if ((bool)itemObjectList[j])
				{
					InitMaterialItem(itemObjectList[j].GetComponent<UIListItem>());
				}
			}
		}
	}

	private void InitMaterialItem(UIListItem item)
	{
		UIListItem.Data data = item.GetData();
		if (data == null)
		{
			throw new AssertionFailedException("このアイテムには data がありません");
		}
		BoxId boxId = Id(item);
		UserData current = UserData.Current;
		bool flag = current.IsUsing(boxId);
		bool flag2 = false;
		if (RuntimeServices.EqualityOperator(boxId, baseItemBoxId))
		{
			flag2 = true;
			item.CautionText = MTexts.Msg("$blk_base");
		}
		bool num = flag2;
		if (!num)
		{
			num = flag;
		}
		flag2 = num;
		bool num2 = flag2;
		if (!num2)
		{
			num2 = CheckDisableByFavorite(boxId);
		}
		flag2 = num2;
		SetItemState(item, flag, flag2);
	}

	private RespPlayerBox GetBox(UIListItem.Data data)
	{
		object result;
		if (data != null)
		{
			object obj = data.core;
			if (!(obj is JsonBase))
			{
				obj = RuntimeServices.Coerce(obj, typeof(JsonBase));
			}
			result = RespPlayerBox.ConvertRespPlayerBox((JsonBase)obj);
		}
		else
		{
			result = null;
		}
		return (RespPlayerBox)result;
	}

	private BoxId Id(UIListItem item)
	{
		return (!item) ? BoxId.InvalidId : Id(item.GetData());
	}

	private BoxId Id(UIListItem.Data data)
	{
		return GetBox(data)?.Id ?? BoxId.InvalidId;
	}

	private void SetItemState(UIListItem item, bool use, bool disable)
	{
		if (item is WeaponListItem)
		{
			WeaponListItem weaponListItem = (WeaponListItem)item;
			weaponListItem.SetState(use, disable);
		}
		else if (item is MapetListItem)
		{
			MapetListItem mapetListItem = (MapetListItem)item;
			mapetListItem.SetState(use, disable);
		}
	}

	private void ChangeSelectMaterial(JsonBase[] mats)
	{
		if (mats == null)
		{
			throw new AssertionFailedException("mats is null");
		}
		CompositionDatas compositionDatas = currentCompDatas;
		UIBasicUtility.SetLabel(compositionDatas.costLabel, "0", show: true);
		RespWeaponPoppet wrapper = GetWrapper(baseItemBoxId);
		int[] array = CalcExpAndCost(wrapper.data, mats, useCamp: false, 0);
		int exp = array[0];
		int cost = array[1];
		int levelExpDist = wrapper.LevelExpDist;
		int levelUpExpDist = wrapper.LevelUpExpDist;
		int num = wrapper.LimitBreakCount;
		int limitBreakCountLimit = wrapper.LimitBreakCountLimit;
		int i = 0;
		checked
		{
			for (int length = mats.Length; i < length; i++)
			{
				if (mats[i] != null)
				{
					RespWeaponPoppet item = new RespWeaponPoppet(mats[i]);
					if (wrapper.canLimitBreak(item))
					{
						num++;
					}
				}
			}
			num = Mathf.Min(num, limitBreakCountLimit);
			Color lvColor = StaticLevelColor.NORMAL;
			if (limitBreakCountLimit <= num)
			{
				lvColor = StaticLevelColor.LIMIT_BREAK_MAX;
			}
			else if (0 < num)
			{
				lvColor = StaticLevelColor.LIMIT_BREAK;
			}
			DispPowupInfo(levelExpDist, exp, levelUpExpDist, cost, IsCheckRareItem(mats), num, limitBreakCountLimit, lvColor);
		}
	}

	protected virtual ApiCompositionBase GetApi()
	{
		return null;
	}

	protected virtual bool PowupStartCheck()
	{
		return true;
	}

	protected virtual void CallBackCreateItem(ApiCompositionBase reqBase)
	{
	}

	public static bool IsCheckRareItem(JsonBase[] materialInfos)
	{
		int num = 0;
		int length = materialInfos.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (materialInfos[num] != null)
				{
					RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(materialInfos[num]);
					if (3 <= respWeaponPoppet.Rare)
					{
						result = 1;
						break;
					}
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	protected RespPlayerBox GetRespPlayerBox(BoxId boxId)
	{
		UserData current = UserData.Current;
		object result;
		if (current == null)
		{
			result = null;
		}
		else if (boxId.IsValid)
		{
			RespPlayerBox respPlayerBox = current.userBoxData.get(boxId);
			if (respPlayerBox == null)
			{
			}
			result = respPlayerBox;
		}
		else
		{
			result = current.userBoxData.get(boxId);
		}
		return (RespPlayerBox)result;
	}

	protected RespWeaponPoppet GetWrapper(BoxId boxId)
	{
		RespPlayerBox respPlayerBox = GetRespPlayerBox(boxId);
		return (respPlayerBox == null) ? null : new RespWeaponPoppet(respPlayerBox);
	}

	private void DispPowupInfo(int now, int exp, int next, int cost, bool rare, int limitCnt, int limitMax, Color lvColor)
	{
		CampaignsController.CampaignsRate campaignsRate = CampaignsController.GetCampaignsRate(isPowupScene);
		CompositionDatas compositionDatas = currentCompDatas;
		checked
		{
			int num = (int)((float)cost / campaignsRate.cost);
			UIBasicUtility.SetLabel(compositionDatas.costLabel, num.ToString(), show: true);
			if (!(1f >= campaignsRate.cost))
			{
				Color downColor = CampaignPanel.DownColor;
				UIBasicUtility.SetLabelColor(compositionDatas.costLabel, downColor);
			}
			string text = ((0 >= next - now) ? "MAX" : (next - now).ToString());
			UIBasicUtility.SetLabel(nextExpLabel, text, show: true);
			if (rareWarnigLabels != null)
			{
				int i = 0;
				GameObject[] array = rareWarnigLabels;
				for (int length = array.Length; i < length; i++)
				{
					if ((bool)array[i])
					{
						array[i].SetActive(rare);
					}
				}
			}
			DispCombineCheck(rare);
			int num2 = (int)((float)exp * campaignsRate.exp);
			int num3 = now + num2;
			UIBasicUtility.SetGauge(newExpGuage, num3, next, show: true);
			UIBasicUtility.SetGauge(oldExpGuage, now, next, show: true);
			UIBasicUtility.SetLabel(limitBreakLabel, limitCnt.ToString(), show: true);
			UIBasicUtility.SetLabel(limitBreakMaxLabel, limitMax.ToString(), show: true);
			UIBasicUtility.SetLabelColor(limitBreakMaxLabel, lvColor);
			if (limitMax < limitCnt)
			{
				lvColor = UIBasicUtility.GetColor(255f, 95f, 95f);
			}
			UIBasicUtility.SetLabelColor(limitBreakLabel, lvColor);
			UIBasicUtility.SetLabel(sumExpLabel, num2.ToString(), show: true);
			if (!(1f >= campaignsRate.exp))
			{
				Color downColor = CampaignPanel.UpColor;
				UIBasicUtility.SetLabelColor(sumExpLabel, downColor);
			}
		}
	}

	private void DispCombineCheck(bool rare)
	{
		combineCheckLabel.text = combineCheckText;
		if (rare)
		{
			combineCheckLabel.text += MTexts.Msg("$blk_include_rare");
		}
		combineCheckLabel.text += MTexts.Msg("$blk_powup_conf");
	}

	protected void DispResult(bool levelUp, bool skillUp, bool maxLevelUp, bool evolution)
	{
		if ((bool)resultMessageLabel)
		{
			evolutionMessage = UIBasicUtility.SafeFormat(evoDefResultMesage, evoBaseItemName);
			string text = string.Empty;
			if (levelUp)
			{
				text += levelUpMessage + "\n";
			}
			if (skillUp)
			{
				text += skillUpMessage + "\n";
			}
			if (maxLevelUp)
			{
				text += levelMaxUpMessage + "\n";
			}
			if (evolution)
			{
				text += evolutionMessage;
			}
			resultMessageLabel.text = text;
			string text2 = UIBasicUtility.SafeFormat(resultNameMessage, evoResultItemName);
			UIBasicUtility.SetLabel(resultNameLabel, text2, show: true);
			ClumpResultLabelScaleX(resultNameLabel, text2, 9);
		}
	}

	public override void SceneAwake()
	{
		isPowupScene = !SceneChanger.CurrentSceneName.Contains("Evolution");
		isWeaponScene = !SceneChanger.CurrentSceneName.Contains("Pet");
		string[] array = titleNames;
		array[RuntimeServices.NormalizeArrayIndex(array, 0)] = MTexts.Format("$blk_powup_top_title", pouwupItemType);
		string[] array2 = titleNames;
		array2[RuntimeServices.NormalizeArrayIndex(array2, 1)] = MTexts.Format("$blk_powup_item_title", pouwupItemType);
		string[] array3 = titleNames;
		array3[RuntimeServices.NormalizeArrayIndex(array3, 2)] = MTexts.Format("$blk_powup_item_title", pouwupItemType);
		string[] array4 = titleNames;
		array4[RuntimeServices.NormalizeArrayIndex(array4, 3)] = MTexts.Format("$blk_powup_conf_title", pouwupItemType);
		string[] array5 = titleNames;
		array5[RuntimeServices.NormalizeArrayIndex(array5, 4)] = MTexts.Format("$blk_powup_conf_title", pouwupItemType);
		string[] array6 = titleNames;
		array6[RuntimeServices.NormalizeArrayIndex(array6, 5)] = MTexts.Format("$blk_powup_conf_title", pouwupItemType);
		string[] array7 = titleNames;
		array7[RuntimeServices.NormalizeArrayIndex(array7, 6)] = MTexts.Format("$blk_powup_conf_title", pouwupItemType, pouwupTitle);
		string[] array8 = titleNames;
		array8[RuntimeServices.NormalizeArrayIndex(array8, 7)] = MTexts.Format("$blk_ult_evo_title", pouwupItemType);
		combineCheckLabel.Align = UIDynamicFontLabel.Alignment.Center;
		combineCheckText = MTexts.Format("$blk_powup_check_text", pouwupItemType, pouwupTitle);
		DispCombineCheck(rare: false);
		int i = 0;
		CompositionDatas[] array9 = compDatas;
		for (int length = array9.Length; i < length; i = checked(i + 1))
		{
			if (array9[i] != null)
			{
				array9[i].Init(isPowupScene);
			}
		}
		if (!isPowupScene)
		{
			InitEvolutionPreview(ref ultevoBeforeIconPanel, ultevoBeforeIconCreator);
		}
	}

	private void InitEvolutionPreview(ref UIListItem panel, IconCreator creator)
	{
		if (!(panel == null) && !(creator == null))
		{
			GameObject gameObject = creator.CreateIcon();
			UIListItem component = gameObject.GetComponent<UIListItem>();
			component.enabled = false;
			IconInfoObject component2 = gameObject.GetComponent<IconInfoObject>();
			if (component2 != null)
			{
				component2.CopyOut(panel);
			}
			panel.DestroyLevel();
		}
	}

	public override void SceneStart()
	{
		string arg = ((!isPowupScene) ? MTexts.Msg("$blk_powup_done") : MTexts.Msg("$blk_powup_doing"));
		InfomationBarHUD.UpdateText(MTexts.Format("$blk_powup_select", pouwupTitle, arg, pouwupItemType));
		count = 0;
		mode = POWUP_MODE.PowupTop;
		if ((bool)materialItemList)
		{
			materialItemList.hookAutoFocusItem = delegate
			{
				return false;
			};
		}
		if (detailItemInfoPanel != null)
		{
			detailItemInfoPanel.DestroyLevel();
		}
		SceneInit();
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			Initialize();
			ChangeSituation(GetSituation((int)mode));
			SetDetailTitle((int)mode);
		});
	}

	public override void SceneUpdate()
	{
		checked
		{
			count++;
			if (IsChangingSituation)
			{
				return;
			}
		}
		if (mode != lastMode)
		{
			UISituation[] array = situations;
			ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
		}
		if (mode != lastMode)
		{
			SetDetailTitle((int)mode);
			lastMode = mode;
			if ((bool)baseItemMoveWindow)
			{
				JsonBase jsonBase = CurItemInfo(baseItemList);
			}
			if ((bool)bgPanel)
			{
				bgPanel.SetActive(value: true);
			}
			if (mode == POWUP_MODE.PowupTop)
			{
				BattleHUDShortcut.Show();
				string arg = ((!isPowupScene) ? MTexts.Msg("$blk_powup_done") : MTexts.Msg("$blk_powup_doing"));
				InfomationBarHUD.UpdateText(MTexts.Format("$blk_powup_select", pouwupTitle, arg, pouwupItemType));
				if (demoAnim != null)
				{
					UnityEngine.Object.DestroyObject(demoAnim);
					demoAnim = null;
				}
			}
			else if (mode == POWUP_MODE.PowupItem)
			{
				BattleHUDShortcut.Show();
				string text = ((!isPowupScene) ? MTexts.Format("$blk_powup_evo_start", pouwupItemType) : MTexts.Format("$blk_powup_material_select", pouwupItemType));
				InfomationBarHUD.UpdateText(text);
				InitMaterialDisplay();
			}
			else if (mode == POWUP_MODE.PowupMaterial)
			{
				string text = default(string);
				if (isPowupScene)
				{
					text = MTexts.Format("$blk_powup_start", pouwupItemType, pouwupItemType);
				}
				InfomationBarHUD.UpdateText(text);
				InitMaterialList();
			}
			else if (mode == POWUP_MODE.PowupConf)
			{
				BattleHUDShortcut.Hide();
			}
			else if (mode == POWUP_MODE.PowupDemoInit)
			{
				hudLayer.SetIn(isIn: false);
			}
			else if (mode == POWUP_MODE.PowupDemo)
			{
				if (bgPanel != null)
				{
					bgPanel.SetActive(value: false);
				}
				InfomationBarHUD.UpdateText(MTexts.Msg("$blk_powup_doing_now"));
			}
			else if (mode == POWUP_MODE.PowupResult)
			{
				hudLayer.SetIn(isIn: true);
				if (bgPanel != null)
				{
					bgPanel.SetActive(value: false);
				}
				InfomationBarHUD.UpdateText(MTexts.Format("$blk_powup_success", pouwupTitle));
			}
			else if (mode == POWUP_MODE.PowupUltEvo)
			{
				string text = ((!isWeaponScene) ? MTexts.Msg("$blk_ult_evo_poppet_info") : MTexts.Msg("$blk_ult_evo_weapon_info"));
				InfomationBarHUD.UpdateText(text);
				InitMaterialDisplay();
			}
			SetupAllNullButton();
		}
		if (mode == POWUP_MODE.PowupTop && baseItemMoveWindow != null)
		{
			JsonBase jsonBase = CurItemInfo(baseItemList);
			baseItemMoveWindow.gameObject.SetActive(jsonBase != null);
		}
	}

	protected void Initialize()
	{
		SetupList();
		RefreshList();
		StorageHUD.DoUpdateNow();
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			BoxId[] array = materialItemBoxId;
			ref BoxId reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
			reference = BoxId.InvalidId;
			int i = 0;
			CompositionDatas[] array2 = compDatas;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				UIListItem[] panels = array2[i].panels;
				SetItem(panels[RuntimeServices.NormalizeArrayIndex(panels, index)], null);
			}
		}
	}

	private void PushDecide(GameObject obj)
	{
		if (mode == POWUP_MODE.PowupTop)
		{
			PushItem(obj);
		}
		else if (mode == POWUP_MODE.PowupMaterial)
		{
			PushMaterial(obj);
		}
	}

	private void PushItem(GameObject obj)
	{
		if (!(baseItemList != null))
		{
			throw new AssertionFailedException("baseIteList が有りません！");
		}
		UIListItem.Data focusItem = baseItemList.focusItem;
		baseItemBoxId = Id(focusItem);
		if (baseItemBoxId.IsValid && CanCombine(baseItemBoxId))
		{
			mode = GetModePowupItem();
		}
	}

	protected virtual void PushDetail(GameObject obj)
	{
		JsonBase jsonBase = null;
		if (mode == POWUP_MODE.PowupMaterial)
		{
			if ((bool)materialItemList)
			{
				jsonBase = CurItemInfo(materialItemList);
			}
		}
		else
		{
			jsonBase = CurItemInfo(baseItemList);
		}
		if (jsonBase != null && Id(jsonBase).IsValid)
		{
			ShowDetail(detailItemInfoPanel, jsonBase);
		}
	}

	protected void PushCloseDetail()
	{
		CloseDetail(detailItemInfoPanel);
	}

	protected void ShowDetail(UIListItem detail, JsonBase item)
	{
		if (!(detail == null))
		{
			UIAutoTweenerStandAloneEx.In(detail.gameObject);
			SetItem(detail, item);
			isShowDetail = true;
		}
	}

	protected void CloseDetail(UIListItem detail)
	{
		UIAutoTweenerStandAloneEx.Out(detail.gameObject);
		isShowDetail = false;
	}

	protected void ShowBaseDetail(JsonBase item)
	{
		UIListItem.Data focusItem = baseItemList.Find(Id(item).Value);
		baseItemList.SetFocusItem(focusItem);
	}

	private void PushShowMaterialList(int index)
	{
		PushShowMaterialList(index, CompDataType.Normal);
	}

	private void PushShowMaterialListUltA(int index)
	{
		PushShowMaterialList(index, CompDataType.UltA);
	}

	private void PushShowMaterialListUltB(int index)
	{
		PushShowMaterialList(index, CompDataType.UltB);
	}

	private void PushShowMaterialList(int index, CompDataType compType)
	{
		if (isPowupScene)
		{
			mode = POWUP_MODE.PowupMaterial;
			return;
		}
		CompositionDatas compData = GetCompData((int)compType);
		JsonBase[] infos = compData.infos;
		JsonBase jsonBase = infos[RuntimeServices.NormalizeArrayIndex(infos, index)];
		if (jsonBase != null && RespWeaponPoppet.Know(jsonBase))
		{
			ShowDetail(detailItemInfoPanel, jsonBase);
		}
	}

	protected virtual void PushMaterial(GameObject obj)
	{
		if (materialItemList == null)
		{
			return;
		}
		int i = 0;
		JsonBase[] array = SelItemInfos(materialItemList);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				BoxId boxId = Id(array[i]);
				if (RuntimeServices.EqualityOperator(boxId, baseItemBoxId) || CheckDisableByFavorite(boxId) || CheckDisableByUsing(boxId))
				{
					return;
				}
			}
		}
		mode = POWUP_MODE.PowupItem;
	}

	protected object[] CheckMaterialIds(BoxId baseBoxId, int[] masterIds, RespPlayerBox.EnumItemType type)
	{
		_0024CheckMaterialIds_0024locals_002414533 _0024CheckMaterialIds_0024locals_0024 = new _0024CheckMaterialIds_0024locals_002414533();
		bool[] array = new bool[5];
		UserData current = UserData.Current;
		Dictionary<BoxId, RespPlayerBox> dictionary = new Dictionary<BoxId, RespPlayerBox>();
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			int num3 = masterIds[RuntimeServices.NormalizeArrayIndex(masterIds, index)];
			if (num3 <= 0)
			{
				continue;
			}
			int i = 0;
			RespPlayerBox[] allItems = current.userBoxData.AllItems;
			for (int length = allItems.Length; i < length; i = checked(i + 1))
			{
				if (allItems[i].Id.IsValid && !dictionary.ContainsKey(allItems[i].Id) && (type != RespPlayerBox.EnumItemType.WEAPON || !allItems[i].IsPoppet) && (type != RespPlayerBox.EnumItemType.POPPET || !allItems[i].IsWeapon) && allItems[i].ItemId == num3)
				{
					dictionary[allItems[i].Id] = allItems[i];
				}
			}
		}
		_0024CheckMaterialIds_0024locals_0024._0024usingList = new RespPlayerBox[5];
		__PowupBase_CheckMaterialIds_0024callable183_0024829_13__ _PowupBase_CheckMaterialIds_0024callable183_0024829_13__ = new _0024CheckMaterialIds_0024isfound_00244257(_0024CheckMaterialIds_0024locals_0024).Invoke;
		int num4 = 0;
		int num5 = 5;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int index2 = num4;
			num4++;
			RespPlayerBox[] _0024usingList = _0024CheckMaterialIds_0024locals_0024._0024usingList;
			_0024usingList[RuntimeServices.NormalizeArrayIndex(_0024usingList, index2)] = null;
			int num3 = masterIds[RuntimeServices.NormalizeArrayIndex(masterIds, index2)];
			bool flag = false;
			if (0 < num3)
			{
				foreach (RespPlayerBox value in dictionary.Values)
				{
					if (value == null || RuntimeServices.EqualityOperator(value.Id, baseBoxId) || value.ItemId != num3 || _PowupBase_CheckMaterialIds_0024callable183_0024829_13__(value.Id) || current.IsUsing(value.Id) || current.IsFavorite(value))
					{
						continue;
					}
					flag = true;
					RespPlayerBox[] _0024usingList2 = _0024CheckMaterialIds_0024locals_0024._0024usingList;
					_0024usingList2[RuntimeServices.NormalizeArrayIndex(_0024usingList2, index2)] = value;
					break;
				}
				bool flag2 = false;
				if (flag)
				{
					flag2 = true;
				}
				else
				{
					foreach (RespPlayerBox value2 in dictionary.Values)
					{
						if (value2 == null || value2.ItemId != num3 || _PowupBase_CheckMaterialIds_0024callable183_0024829_13__(value2.Id))
						{
							continue;
						}
						flag2 = true;
						RespPlayerBox[] _0024usingList3 = _0024CheckMaterialIds_0024locals_0024._0024usingList;
						_0024usingList3[RuntimeServices.NormalizeArrayIndex(_0024usingList3, index2)] = value2;
						break;
					}
				}
				if (!flag2)
				{
					RespPlayerBox respPlayerBox = new RespPlayerBox();
					respPlayerBox.Id = BoxId.InvalidId;
					respPlayerBox.ItemId = num3;
					respPlayerBox.ItemType = (int)type;
					respPlayerBox.Level = 1;
					respPlayerBox.LevelMax = 1;
					RespPlayerBox[] _0024usingList4 = _0024CheckMaterialIds_0024locals_0024._0024usingList;
					_0024usingList4[RuntimeServices.NormalizeArrayIndex(_0024usingList4, index2)] = respPlayerBox;
				}
			}
			else
			{
				flag = true;
				RespPlayerBox[] _0024usingList5 = _0024CheckMaterialIds_0024locals_0024._0024usingList;
				_0024usingList5[RuntimeServices.NormalizeArrayIndex(_0024usingList5, index2)] = null;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, index2)] = flag;
		}
		return new object[2] { _0024CheckMaterialIds_0024locals_0024._0024usingList, array };
	}

	protected virtual void InitMaterialDisplay()
	{
		JsonBase[] array = new JsonBase[0];
		if (materialItemList != null)
		{
			array = SelItemInfos(materialItemList);
		}
		CompositionDatas compData = GetCompData(0);
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			JsonBase jsonBase = null;
			if (num3 < array.Length)
			{
				JsonBase[] array2 = array;
				jsonBase = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
			}
			BoxId[] array3 = materialItemBoxId;
			ref BoxId reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num3)];
			reference = Id(jsonBase);
			UIListItem[] panels = compData.panels;
			UIListItem uIListItem = panels[RuntimeServices.NormalizeArrayIndex(panels, num3)];
			uIListItem.gameObject.SetActive(jsonBase != null);
			SetItem(uIListItem, jsonBase);
		}
		ChangeSelectMaterial(array);
		SetPowupBaseDetail(baseItemList.focusItem);
	}

	protected int[] GetExpAndCost(bool useCamp, int compType)
	{
		JsonBase respPlayerBox = GetRespPlayerBox(baseItemBoxId);
		JsonBase[] mats = null;
		if (isPowupScene)
		{
			mats = SelItemInfos(materialItemList);
		}
		return CalcExpAndCost(respPlayerBox, mats, useCamp, compType);
	}

	protected int[] CalcExpAndCost(JsonBase @base, JsonBase[] mats, bool useCamp, int compType)
	{
		int dstNewExp = 0;
		int dstNeedCost = 0;
		RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(@base);
		if (!isPowupScene)
		{
			dstNeedCost = ((!respWeaponPoppet.CanUltEvolution) ? respWeaponPoppet.EvoCost : respWeaponPoppet.UltEvoCost(UltEvoIndex((CompDataType)compType)));
		}
		else
		{
			respWeaponPoppet.LevelUpSimulate(mats, ref dstNewExp, ref dstNeedCost);
			dstNewExp = checked(dstNewExp - respWeaponPoppet.Exp);
		}
		checked
		{
			if (useCamp)
			{
				CampaignsController.CampaignsRate campaignsRate = CampaignsController.GetCampaignsRate(isPowupScene);
				dstNewExp = (int)((float)dstNewExp * campaignsRate.exp);
				dstNeedCost = (int)((float)dstNeedCost / campaignsRate.cost);
			}
			return new int[2] { dstNewExp, dstNeedCost };
		}
	}

	private bool CanCombine(BoxId id)
	{
		RespWeaponPoppet wrapper = GetWrapper(id);
		return wrapper != null && (isPowupScene ? wrapper.CanMorePowup : (wrapper.CanUltEvolution || wrapper.CanEvolution));
	}

	protected void ClumpResultLabelScaleX(UILabelBase label, string rname, int limit)
	{
		if (!(label == null) && limit <= rname.Length)
		{
			Vector3 localScale = label.transform.localScale;
			localScale.x = 1f;
			label.transform.localScale = localScale;
		}
	}

	private void PushStart()
	{
		PushStartComp(0);
	}

	private void PushStartComp(int compType)
	{
		SetCompDataType(compType);
		if (!PowupStartCheck() || !baseItemBoxId.IsValid || !CanCombine(baseItemBoxId))
		{
			return;
		}
		if (!isPowupScene)
		{
			RespWeaponPoppet wrapper = GetWrapper(baseItemBoxId);
			evoBaseItemName = wrapper.Name.ToString();
			if (wrapper.CanUltEvolution)
			{
				RespWeaponPoppet respWeaponPoppet = wrapper.CreateUltEvolution(UltEvoIndex((CompDataType)compType));
				evoResultItemName = respWeaponPoppet.Name;
			}
			else
			{
				evoResultItemName = wrapper.EvolutionName;
			}
		}
		int num = 0;
		int i = 0;
		BoxId[] array = materialItemBoxId;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i].IsValid)
				{
					if (CheckDisableByFavorite(array[i]) || CheckDisableByUsing(array[i]))
					{
						return;
					}
					num++;
				}
			}
			if (num != 0)
			{
				DialogManager instance = DialogManager.Instance;
				UserData current = UserData.Current;
				int[] expAndCost = GetExpAndCost(useCamp: true, compType);
				int num2 = expAndCost[0];
				int num3 = expAndCost[1];
				if (current.Coin - num3 < 0)
				{
					DialogManager.Open(MTexts.Format("$blk_powup_no_ruku", Mathf.Abs(current.Coin - num3)), MTexts.Msg("$blk_powup_no_ruku_title"));
				}
				else
				{
					mode = POWUP_MODE.PowupConf;
				}
			}
		}
	}

	private void PushYes(GameObject obj)
	{
		mode = POWUP_MODE.PowupDemoInit;
		ApiCompositionBase api = GetApi();
		if (api != null)
		{
			api.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				SceneChanger.Change(errorSceneId);
			});
			MerlinServer.Request(api, _0024adaptor_0024__PowupBase_PushYes_0024callable599_00241010_38___0024__MerlinServer_Request_0024callable86_0024160_56___0024205.Adapt(CallBackRequest));
		}
	}

	private void CallBackRequest(ApiCompositionBase reqBase)
	{
		__PowupBase_CallBackRequest_0024callable184_00241013_13__ _PowupBase_CallBackRequest_0024callable184_00241013_13__ = (ApiCompositionBase reqBase) => new _0024_0024CallBackRequest_0024CallBackRequestCore_00244259_002421874(reqBase, this).GetEnumerator();
		StartCoroutine(_PowupBase_CallBackRequest_0024callable184_00241013_13__(reqBase));
	}

	protected virtual void PushClear()
	{
		if ((bool)materialItemList)
		{
			materialItemList.ClearSelectItems();
		}
	}

	protected virtual void PushNo(GameObject obj)
	{
		mode = GetModePowupItem();
	}

	protected virtual void PushSkipDemo(GameObject obj)
	{
		mode = POWUP_MODE.PowupResult;
		if ((bool)demoAnim)
		{
			Gousei3D component = demoAnim.GetComponent<Gousei3D>();
			if ((bool)component)
			{
				component.skip = true;
			}
		}
	}

	protected virtual void PushEndDemo(GameObject obj)
	{
		mode = POWUP_MODE.PowupResult;
	}

	protected virtual void PushResult(GameObject obj)
	{
		SceneChanger.Change(returnSceneId);
	}

	protected virtual void PushBack(GameObject obj)
	{
		if (isShowDetail)
		{
			PushCloseDetail();
		}
		else if (mode == POWUP_MODE.PowupTop)
		{
			SceneChanger.Change(returnSceneId);
		}
		else if (mode == POWUP_MODE.PowupItem)
		{
			mode = POWUP_MODE.PowupTop;
		}
		else if (mode == POWUP_MODE.PowupMaterial)
		{
			mode = POWUP_MODE.PowupItem;
		}
		else if (mode == POWUP_MODE.PowupConf)
		{
			mode = POWUP_MODE.PowupTop;
		}
		else if (mode == POWUP_MODE.PowupResult)
		{
			mode = POWUP_MODE.PowupTop;
		}
		else if (mode == POWUP_MODE.PowupUltEvo)
		{
			mode = POWUP_MODE.PowupTop;
		}
	}

	protected virtual void PushLongBack(GameObject obj)
	{
		if (mode != POWUP_MODE.PowupResult)
		{
			SceneChanger.Change(returnSceneId);
		}
		else
		{
			PushBack(obj);
		}
	}

	protected virtual void PushSort(string key)
	{
		if (mode == POWUP_MODE.PowupTop)
		{
			if ((bool)baseItemList)
			{
				baseItemList.PushSort(key);
			}
		}
		else if (mode == POWUP_MODE.PowupMaterial && (bool)materialItemList)
		{
			materialItemList.PushSort(key);
		}
	}

	private POWUP_MODE GetModePowupItem()
	{
		if (!baseItemBoxId.IsValid)
		{
			throw new AssertionFailedException("baseItemBoxId is invalid");
		}
		mode = POWUP_MODE.PowupItem;
		if (!isPowupScene)
		{
			RespWeaponPoppet wrapper = GetWrapper(baseItemBoxId);
			if (wrapper.CanUltEvolution)
			{
				mode = POWUP_MODE.PowupUltEvo;
			}
		}
		return mode;
	}

	private bool EqualSelectItems(RespWeaponPoppet[] ary)
	{
		int result;
		checked
		{
			if (materialItemList.selectCount <= 0)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int i = 0;
				for (int length = ary.Length; i < length; i++)
				{
					int j = 0;
					UIListItem[] selectItems = materialItemList.SelectItems;
					for (int length2 = selectItems.Length; j < length2; j++)
					{
						RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(selectItems[j].GetData<JsonBase>());
						if (RuntimeServices.EqualityOperator(ary[i].Id, respWeaponPoppet.Id))
						{
							num++;
							break;
						}
					}
				}
				result = ((num == materialItemList.selectCount) ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	private void SetToMaterialList(RespWeaponPoppet[] ary)
	{
		_0024SetToMaterialList_0024locals_002414534 _0024SetToMaterialList_0024locals_0024 = new _0024SetToMaterialList_0024locals_002414534();
		_0024SetToMaterialList_0024locals_0024._0024ary = ary;
		if (materialItemList == null)
		{
			return;
		}
		if (_0024SetToMaterialList_0024locals_0024._0024ary == null || _0024SetToMaterialList_0024locals_0024._0024ary.Length <= 0)
		{
			string text = MTexts.Msg("$blk_powup_no_powup_item_title");
			string message = MTexts.Msg("$blk_powup_no_powup_item_msg");
			DialogManager.Open(message, text);
			return;
		}
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024SetToMaterialList_0024func_00244260(_0024SetToMaterialList_0024locals_0024, this).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private RespWeaponPoppet[] GetItems(UIListBase list)
	{
		return ArrayMapMain.UIListItemDataToRespWeaponPoppet(list.GetDataList());
	}

	private void PushRecommended(GameObject obj)
	{
		if (!isPowupScene)
		{
			return;
		}
		RespWeaponPoppet wrapper = GetWrapper(baseItemBoxId);
		if (wrapper == null)
		{
			return;
		}
		ModalCollider.SetActive(gameObject, active: true);
		if (wrapper.CurrentLevelLimit <= wrapper.Level)
		{
			string text = MTexts.Msg("$blk_powup_recommend_level_max_title");
			string message = MTexts.Msg("$blk_powup_recommend_level_max_msg");
			DialogManager.Open(message, text);
		}
		else
		{
			RespWeaponPoppet[] items = GetItems(materialItemList);
			if (wrapper != null && items != null)
			{
				SetToMaterialList(PowupRecommender.Recommend(wrapper, items, 5, useElem: false));
			}
		}
		ModalCollider.SetActive(gameObject, active: false);
	}

	protected int GetEvolutionItemID(JsonBase @base, int compType)
	{
		RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(@base);
		return (!respWeaponPoppet.CanUltEvolution) ? respWeaponPoppet.EvolutionId : respWeaponPoppet.UltEvoId(UltEvoIndex((CompDataType)compType));
	}

	protected JsonBase GetPreview(JsonBase @base, int compType)
	{
		JsonBase result = null;
		if (@base != null)
		{
			RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(@base);
			RespWeaponPoppet respWeaponPoppet2 = null;
			if (respWeaponPoppet.CanUltEvolution)
			{
				respWeaponPoppet2 = respWeaponPoppet.CreateUltEvolution(UltEvoIndex((CompDataType)compType));
			}
			else if (respWeaponPoppet.CanEvolution)
			{
				respWeaponPoppet2 = respWeaponPoppet.CreateEvolution();
			}
			if (respWeaponPoppet2 == null)
			{
			}
			result = respWeaponPoppet2.data;
		}
		return result;
	}

	protected void SetLevelOnOff(UIListItem panel, bool on)
	{
		GameObject levelObject = panel.GetLevelObject();
		if (levelObject != null)
		{
			levelObject.SetActive(on);
		}
	}

	protected virtual void SetItemEx(UIListItem info, JsonBase respItem, bool otherDisableFlag)
	{
	}

	protected bool[] CheckMaterial(BoxId baseBoxId, ref RespWeaponPoppet[] distList)
	{
		return CheckMaterial(baseBoxId, ref distList, (int)selectCompDataType);
	}

	private bool[] CheckMaterial(BoxId baseBoxId, ref RespWeaponPoppet[] distList, int compType)
	{
		bool[] array = new bool[5];
		UserData current = UserData.Current;
		RespPlayerBox respPlayerBox = current.userBoxData.get(baseBoxId);
		bool[] result;
		System.Collections.Generic.List<int> list;
		if (respPlayerBox == null)
		{
			result = array;
		}
		else
		{
			RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(respPlayerBox);
			list = new System.Collections.Generic.List<int>(5);
			if (respWeaponPoppet.CanUltEvolution)
			{
				MEvolutionInformations[] array2 = MEvolutionInformations.SearchToSourceId(respWeaponPoppet.ItemTypeByInt, respWeaponPoppet.MasterId);
				if (!(array2 == null))
				{
					int[] allMaterialIds = array2[RuntimeServices.NormalizeArrayIndex(array2, UltEvoIndex((CompDataType)compType))].AllMaterialIds;
					int num = 0;
					int num2 = 5;
					if (num2 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num < num2)
					{
						int num3 = num;
						num++;
						System.Collections.Generic.List<int> list2 = list;
						int item;
						if (num3 < allMaterialIds.Length)
						{
							item = allMaterialIds[RuntimeServices.NormalizeArrayIndex(allMaterialIds, num3)];
						}
						else
						{
							item = 0;
						}
						list2.Add(item);
					}
					goto IL_00fc;
				}
				result = array;
			}
			else
			{
				if (respWeaponPoppet.CanEvolution)
				{
					list = respWeaponPoppet.EvolutionMaterialIds.ToList();
					goto IL_00fc;
				}
				result = array;
			}
		}
		goto IL_01bc;
		IL_00fc:
		RespPlayerBox.EnumItemType type = RespPlayerBox.EnumItemType.POPPET;
		if (isWeaponScene)
		{
			type = RespPlayerBox.EnumItemType.WEAPON;
		}
		object[] array3 = CheckMaterialIds(baseBoxId, list.ToArray(), type);
		object enumerable = array3[0];
		object obj = array3[1];
		if (!(obj is bool[]))
		{
			obj = RuntimeServices.Coerce(obj, typeof(bool[]));
		}
		array = (bool[])obj;
		System.Collections.Generic.List<RespWeaponPoppet> list3 = new System.Collections.Generic.List<RespWeaponPoppet>();
		IEnumerator enumerator = RuntimeServices.GetEnumerable(enumerable).GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj2 = enumerator.Current;
			if (!(obj2 is RespPlayerBox))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(RespPlayerBox));
			}
			RespPlayerBox respPlayerBox2 = (RespPlayerBox)obj2;
			list3.Add((respPlayerBox2 == null) ? null : new RespWeaponPoppet(respPlayerBox2));
		}
		distList = list3.ToArray();
		result = array;
		goto IL_01bc;
		IL_01bc:
		return result;
	}

	protected void InitEvoMaterialDisplay(JsonBase json)
	{
		evoResultItemName = string.Empty;
		evoBaseItemName = string.Empty;
		RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(json);
		if (respWeaponPoppet.CanUltEvolution)
		{
			SetItem(ultevoBeforeIconPanel, respWeaponPoppet.data);
		}
		int num = 0;
		int num2 = 3;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int type = num;
			num++;
			CompositionDatas compData = GetCompData(type);
			int num3 = 0;
			int num4 = 5;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index = num3;
				num3++;
				UIListItem[] panels = compData.panels;
				SetItem(panels[RuntimeServices.NormalizeArrayIndex(panels, index)], null);
			}
			UIBasicUtility.SetLabel(compData.costLabel, "0", show: true);
			RespWeaponPoppet[] distList = new RespWeaponPoppet[5];
			bool[] array = CheckMaterial(respWeaponPoppet.Id, ref distList, (int)compData.type);
			SetItem(compData.afterPanel, GetPreview(respWeaponPoppet.data, (int)compData.type), respWeaponPoppet.CanUltEvolution);
			bool e = true;
			int num5 = 0;
			int num6 = 5;
			if (num6 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num5 < num6)
			{
				int index2 = num5;
				num5++;
				UIListItem[] panels2 = compData.panels;
				UIListItem uIListItem = panels2[RuntimeServices.NormalizeArrayIndex(panels2, index2)];
				bool flag = !array[RuntimeServices.NormalizeArrayIndex(array, index2)];
				JsonBase jsonBase = null;
				RespWeaponPoppet[] array2 = distList;
				if (array2[RuntimeServices.NormalizeArrayIndex(array2, index2)] != null)
				{
					RespWeaponPoppet[] array3 = distList;
					jsonBase = array3[RuntimeServices.NormalizeArrayIndex(array3, index2)].data;
					uIListItem.gameObject.SetActive(value: true);
					RespWeaponPoppet[] array4 = distList;
					SetItemEx(uIListItem, array4[RuntimeServices.NormalizeArrayIndex(array4, index2)].data, flag);
					if (flag)
					{
						e = false;
					}
				}
				else
				{
					uIListItem.gameObject.SetActive(value: false);
					SetLevelOnOff(uIListItem, on: false);
				}
				JsonBase[] infos = compData.infos;
				infos[RuntimeServices.NormalizeArrayIndex(infos, index2)] = jsonBase;
			}
			int[] array5 = CalcExpAndCost(respWeaponPoppet.data, null, useCamp: true, (int)compData.type);
			int num7 = array5[0];
			int num8 = array5[1];
			UIBasicUtility.SetLabel(compData.costLabel, num8.ToString(), show: true);
			CampaignsController.CampaignsRate campaignsRate = CampaignsController.GetCampaignsRate(isPowup: false);
			if (!(1f >= campaignsRate.cost))
			{
				Color downColor = CampaignPanel.DownColor;
				UIBasicUtility.SetLabelColor(compData.costLabel, downColor);
			}
			UIBasicUtility.SetButtonValid(compData.buttonSet, e);
		}
	}

	protected virtual void ResetMaterialItem(GameObject obj)
	{
		CompositionDatas compData = GetCompData(0);
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			UIListItem[] panels = compData.panels;
			UIListItem uIListItem = panels[RuntimeServices.NormalizeArrayIndex(panels, index)];
			if (uIListItem.gameObject == obj)
			{
				SetItem(uIListItem, null);
				obj.transform.localPosition = Vector3.zero;
				obj.SetActive(value: false);
				BoxId[] array = materialItemBoxId;
				ref BoxId reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
				reference = BoxId.InvalidId;
				break;
			}
		}
	}

	protected ApiCompositionBase GetEvoApi()
	{
		ApiCompositionBase apiCompositionBase = null;
		apiCompositionBase = ((!isWeaponScene) ? ((ApiCompositionBase)new ApiPoppetEvolution()) : ((ApiCompositionBase)new ApiWeaponEvolution()));
		RespWeaponPoppet[] distList = new RespWeaponPoppet[5];
		CheckMaterial(baseItemBoxId, ref distList);
		BoxId[] array = new BoxId[0];
		int num = 0;
		int num2 = 5;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			RespWeaponPoppet[] array2 = distList;
			RespWeaponPoppet respWeaponPoppet = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			if (respWeaponPoppet != null && respWeaponPoppet.Id.IsValid)
			{
				array = (BoxId[])RuntimeServices.AddArrays(typeof(BoxId), array, new BoxId[1] { respWeaponPoppet.Id });
			}
		}
		int evoinfosId = 0;
		RespWeaponPoppet wrapper = GetWrapper(baseItemBoxId);
		if (wrapper.CanUltEvolution)
		{
			MEvolutionInformations[] array3 = MEvolutionInformations.SearchToSourceId(wrapper.ItemTypeByInt, wrapper.MasterId);
			int index2 = UltEvoIndex(selectCompDataType);
			evoinfosId = array3[RuntimeServices.NormalizeArrayIndex(array3, index2)].Id;
		}
		apiCompositionBase.add(baseItemBoxId, array, evoinfosId);
		return apiCompositionBase;
	}

	internal bool _0024BasicInit_0024closure_00244250(UIListItem item)
	{
		UIBasicUtility.SetButtonValid(decideButtonSet, !item.Disable);
		return false;
	}

	internal bool _0024BasicInit_0024closure_00244251(UIListItem.Data data)
	{
		SetPowupBaseDetail(data);
		return false;
	}

	internal void _0024BasicInit_0024closure_00244252()
	{
		if (mode == POWUP_MODE.PowupTop)
		{
			PushDecide(null);
		}
	}

	internal bool _0024BasicInit_0024closure_00244253()
	{
		return mode != POWUP_MODE.PowupTop;
	}

	internal bool _0024BasicInit_0024closure_00244254()
	{
		return mode != POWUP_MODE.PowupMaterial;
	}

	internal bool _0024SceneStart_0024closure_00244255(ref UIListItem.Data dstData)
	{
		return false;
	}

	internal void _0024SceneStart_0024closure_00244256()
	{
		Initialize();
		ChangeSituation(GetSituation((int)mode));
		SetDetailTitle((int)mode);
	}

	internal void _0024PushYes_0024closure_00244258()
	{
		SceneChanger.Change(errorSceneId);
	}

	internal IEnumerator _0024CallBackRequest_0024CallBackRequestCore_00244259(ApiCompositionBase reqBase)
	{
		return new _0024_0024CallBackRequest_0024CallBackRequestCore_00244259_002421874(reqBase, this).GetEnumerator();
	}
}
