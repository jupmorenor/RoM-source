using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BlacksmithEvolutionMain : PowupBase
{
	public UILabelBase evoTopPanelTitle;

	public UILabelBase evoItemPanelTitle;

	public UILabelBase evoResultTitle;

	private RespWeapon getMainWeapon
	{
		get
		{
			object obj = null;
			UserData current = UserData.Current;
			if (current == null)
			{
				throw new AssertionFailedException("ud != null");
			}
			obj = ((!current.IsValidDeck2) ? current.MainWeapon : current.ActiveWeapon);
			object obj2 = obj;
			if (!(obj2 is RespWeapon))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(RespWeapon));
			}
			return (RespWeapon)obj2;
		}
	}

	public override void SceneInit()
	{
		BasicInit();
		baseItemList.HookSettingListItem = hookSettingListItem;
		baseItemList.HookAutoFocusItem = hookAutoFocusItem;
		if ((bool)evoTopPanelTitle)
		{
			evoTopPanelTitle.text = MTexts.Msg("$blk_base_weapon_info");
		}
		if ((bool)evoItemPanelTitle)
		{
			evoItemPanelTitle.text = MTexts.Msg("$blk_base_weapon_info");
		}
		if ((bool)evoResultTitle)
		{
			evoResultTitle.text = MTexts.Msg("$blk_evo_weapon_info");
		}
	}

	public override void SetItemEx(UIListItem info, JsonBase respItem, bool otherDisableFlag)
	{
		WeaponListItem weaponListItem = (WeaponListItem)info;
		RespWeapon respWeapon = respItem as RespWeapon;
		BoxId wpn_box_id = ((respWeapon.RefPlayerBox == null) ? BoxId.InvalidId : respWeapon.Id);
		bool flag = false;
		bool flag2 = otherDisableFlag;
		UserData current = UserData.Current;
		RespWeapon respWeapon2 = current.boxWeapon(wpn_box_id);
		if (respWeapon2 != null)
		{
			flag = current.IsUsingWeapon(respWeapon2);
		}
		else
		{
			flag2 = true;
		}
		if (!flag2)
		{
			if (flag)
			{
				flag2 = true;
			}
			if (current.IsFavorite(respWeapon2.RefPlayerBox))
			{
				flag2 = true;
			}
		}
		bool flag3 = false;
		if (respWeapon.RefPlayerBox != null)
		{
			flag3 = current.userMiscInfo.weaponBookData.isLook(respWeapon.Master);
		}
		else
		{
			flag2 = false;
		}
		if (flag3)
		{
			weaponListItem.SetWeapon(respWeapon);
			SetLevelOnOff(weaponListItem, on: true);
		}
		else
		{
			weaponListItem.Reset();
			flag2 = false;
			SetLevelOnOff(weaponListItem, on: false);
		}
		weaponListItem.SetState(flag, flag2);
		weaponListItem.SetNew(isNew: false);
		weaponListItem.canShowNew = false;
	}

	private bool hookSettingListItem(UIListItem item)
	{
		WeaponList weaponList = (WeaponList)baseItemList;
		weaponList.weponHookSettingListItem(item);
		InitBaseItem(item);
		if (!baseItemBoxId.IsValid)
		{
			baseItemBoxId = getMainWeapon.Id;
		}
		if (RuntimeServices.EqualityOperator(item.GetData<RespWeapon>().Id, baseItemBoxId))
		{
			baseItemList.SelectItem(item);
		}
		return true;
	}

	private bool hookAutoFocusItem(ref UIListItem.Data data)
	{
		data = baseItemList.Find(getMainWeapon.Id.Value);
		RespWeapon data2 = data.GetData<RespWeapon>();
		UIBasicUtility.ButtonSet bset = decideButtonSet;
		bool num = data2.CanEvolution;
		if (!num)
		{
			num = data2.CanUltEvolution;
		}
		UIBasicUtility.SetButtonValid(bset, num);
		return true;
	}

	public override void PushDetail(GameObject obj)
	{
		if (mode == POWUP_MODE.PowupTop)
		{
			base.PushDetail(obj);
		}
		else if (mode == POWUP_MODE.PowupItem || 7u != 0)
		{
			if (baseItemList != null)
			{
				JsonBase jsonBase = CurItemInfo(baseItemList);
				baseItemBoxId = Id(jsonBase);
				if (baseItemBoxId.IsValid)
				{
					ShowDetail(detailItemInfoPanel, jsonBase);
				}
			}
		}
		else if (mode == POWUP_MODE.PowupResult && resultItemBoxId.IsValid)
		{
			UserData current = UserData.Current;
			RespWeapon item = current.boxWeapon(resultItemBoxId);
			ShowDetail(detailItemInfoPanel, item);
		}
	}

	private MWeapons GetEvolutionItem(RespWeapon wep, int compType)
	{
		return MWeapons.Get(GetEvolutionItemID(wep, compType));
	}

	private void PushShowResult()
	{
		ShowResult(0);
	}

	private void PushShowUltResult(int compType)
	{
		ShowResult(compType);
	}

	private void ShowResult(int compType)
	{
		UserData current = UserData.Current;
		RespWeapon respWeapon = current.boxWeapon(baseItemBoxId);
		if (current.userMiscInfo.weaponBookData.isLook(GetEvolutionItem(respWeapon, compType)))
		{
			JsonBase preview = GetPreview(respWeapon, compType);
			if (preview != null)
			{
				ShowDetail(detailItemInfoPanel, preview);
			}
		}
	}

	public override void SetupList()
	{
		WeaponList weaponList = (WeaponList)baseItemList;
		weaponList.SetInputWeaponList(UserData.Current.BoxWeapons);
	}

	public override ApiCompositionBase GetApi()
	{
		return GetEvoApi();
	}

	public override bool PowupStartCheck()
	{
		UserData current = UserData.Current;
		RespWeapon respWeapon = current.boxWeapon(baseItemBoxId);
		CompositionDatas compositionDatas = base.currentCompDatas;
		int result;
		if (!compositionDatas.buttonSet.validControl.isValidColor)
		{
			result = 0;
		}
		else
		{
			DialogManager instance = DialogManager.Instance;
			RespWeaponPoppet[] distList = new RespWeaponPoppet[5];
			bool[] array = CheckMaterial(baseItemBoxId, ref distList);
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < num2)
				{
					int index = num;
					num++;
					RespWeaponPoppet[] array2 = distList;
					RespWeaponPoppet respWeaponPoppet = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
					if (respWeaponPoppet != null && respWeaponPoppet.RefPlayerBox != null)
					{
						if (CheckDisableByFavorite(respWeaponPoppet.Id))
						{
							instance.OpenDialog(MTexts.Msg("$blk_include_faivor"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
							result = 0;
							break;
						}
						if (current.IsUsing(respWeaponPoppet.Id))
						{
							instance.OpenDialog(MTexts.Msg("$blk_include_use"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { "OK" });
							result = 0;
							break;
						}
						BoxId[] array3 = materialItemBoxId;
						ref BoxId reference = ref array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
						reference = respWeaponPoppet.Id;
					}
					if (!array[RuntimeServices.NormalizeArrayIndex(array, index)])
					{
						result = 0;
						break;
					}
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	public override void CallBackCreateItem(ApiCompositionBase reqBase)
	{
		ApiWeaponEvolution apiWeaponEvolution = (ApiWeaponEvolution)reqBase;
		if (apiWeaponEvolution == null)
		{
			throw new AssertionFailedException("req != null");
		}
		MonoBehaviour.print("CallBackCreateItem");
		ApiWeaponEvolution.Resp response = apiWeaponEvolution.GetResponse();
		MonoBehaviour.print(new StringBuilder("GetResponse = ").Append(response).ToString());
		if (response == null)
		{
			SceneChanger.Change(errorSceneId);
			return;
		}
		resultItemBoxId = response.Id;
		RespWeapon respWeapon = UserData.Current.boxWeapon(resultItemBoxId);
		if (respWeapon == null)
		{
			throw new AssertionFailedException("mainwpn != null");
		}
		UserData current = UserData.Current;
		RespWeapon respWeapon2 = (RespWeapon)CurItemInfo(baseItemList);
		if (current.IsFavorite(respWeapon2.RefPlayerBox))
		{
			current.OnFavorite(respWeapon.RefPlayerBox);
		}
		current.SetOld2NewItem(respWeapon.RefPlayerBox);
		DispResult(levelUp: false, skillUp: false, maxLevelUp: false, evolution: true);
		demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
		Gousei3D component = demoAnim.GetComponent<Gousei3D>();
		component.mode = Gousei3D.Mode.WeaponEvolution;
		component.testMode = false;
		component.seiko = 0;
		component.IsLevelUp = false;
		component.IsSkillUp = false;
		component.IsLimitOver = false;
		component.rare = respWeapon.Master.Rare.Id;
		component.endFuncObject = gameObject;
		component.endFunction = "PushEndDemo";
		component.targetWeapon = respWeapon;
		int i = 0;
		JsonBase[] array = listItemInfo;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(((RespWeapon)array[i]).Id, baseItemBoxId))
				{
					component.baseWeapon = (RespWeapon)array[i];
					break;
				}
			}
			int num = 0;
			int j = 0;
			BoxId[] array2 = materialItemBoxId;
			for (int length2 = array2.Length; j < length2; j++)
			{
				int k = 0;
				JsonBase[] array3 = listItemInfo;
				for (int length3 = array3.Length; k < length3; k++)
				{
					if ((RespWeapon)array3[k] != null && RuntimeServices.EqualityOperator(((RespWeapon)array3[k]).Id, array2[j]))
					{
						RespWeapon[] materialWeapon = component.materialWeapon;
						materialWeapon[RuntimeServices.NormalizeArrayIndex(materialWeapon, num)] = (RespWeapon)array3[k];
						break;
					}
				}
				num++;
			}
			component.atkValues = new int[2];
			component.atkValues[0] = (int)respWeapon2.TotalAttack;
			component.atkValues[1] = (int)respWeapon.TotalAttack;
			component.hpValues = new int[2];
			component.hpValues[0] = (int)respWeapon2.TotalHP;
			component.hpValues[1] = (int)respWeapon.TotalHP;
			Initialize();
			ShowBaseDetail(respWeapon);
		}
	}

	public override void InitMaterialDisplay()
	{
		InitEvoMaterialDisplay(baseItemList.GetFocusData<RespWeapon>());
		SetPowupBaseDetail(baseItemList.focusItem);
	}

	public override void PushResult(GameObject obj)
	{
		mode = POWUP_MODE.PowupTop;
	}
}
