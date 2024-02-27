using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PetEvolutionMain : PowupBase
{
	public UILabelBase evoTopPanelTitle;

	public UILabelBase evoItemPanelTitle;

	public UILabelBase evoResultTitle;

	public override void SceneInit()
	{
		BasicInit();
		baseItemList.HookSettingListItem = hookSettingListItem;
		baseItemList.HookAutoFocusItem = hookAutoFocusItem;
		UIBasicUtility.SetLabel(evoTopPanelTitle, MTexts.Msg("$blk_poppet_evo_base_info_title"), show: true);
		UIBasicUtility.SetLabel(evoItemPanelTitle, MTexts.Msg("$blk_poppet_evo_base_info_title"), show: true);
		UIBasicUtility.SetLabel(evoResultTitle, MTexts.Msg("$blk_poppet_evo_result_info_title"), show: true);
	}

	public override void SetItemEx(UIListItem info, JsonBase respItem, bool otherDisableFlag)
	{
		MapetListItem mapetListItem = (MapetListItem)info;
		RespPoppet respPoppet = respItem as RespPoppet;
		BoxId ppt_box_id = ((respPoppet.RefPlayerBox == null) ? BoxId.InvalidId : respPoppet.Id);
		bool flag = false;
		bool flag2 = otherDisableFlag;
		UserData current = UserData.Current;
		RespPoppet respPoppet2 = current.boxPoppet(ppt_box_id);
		if (respPoppet2 != null)
		{
			flag = current.IsUsingPoppet(respPoppet2);
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
			if (current.IsFavorite(respPoppet2.RefPlayerBox))
			{
				flag2 = true;
			}
		}
		bool flag3 = false;
		if (respPoppet.RefPlayerBox != null)
		{
			flag3 = current.userMiscInfo.poppetBookData.isLook(respPoppet.Master);
		}
		else
		{
			flag2 = false;
		}
		if (flag3)
		{
			mapetListItem.SetMapet(respPoppet);
			SetLevelOnOff(mapetListItem, on: true);
		}
		else
		{
			mapetListItem.Reset();
			flag2 = false;
			SetLevelOnOff(mapetListItem, on: false);
		}
		mapetListItem.SetState(flag, flag2);
		mapetListItem.SetNew(isNew: false);
		mapetListItem.canShowNew = false;
	}

	private bool hookSettingListItem(UIListItem item)
	{
		MapetList mapetList = (MapetList)baseItemList;
		mapetList.poppetHookSettingListItem(item);
		InitBaseItem(item);
		if (!baseItemBoxId.IsValid)
		{
			UserData current = UserData.Current;
			baseItemBoxId = current.CurrentPoppetNewOrOldDeck.Id;
		}
		if (RuntimeServices.EqualityOperator(item.GetData<RespPoppet>().Id, baseItemBoxId))
		{
			baseItemList.SelectItem(item);
		}
		return true;
	}

	private bool hookAutoFocusItem(ref UIListItem.Data data)
	{
		data = baseItemList.Find(UserData.Current.CurrentPoppetNewOrOldDeck.Id.Value);
		RespPoppet data2 = data.GetData<RespPoppet>();
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
			RespPoppet item = current.boxPoppet(resultItemBoxId);
			ShowDetail(detailItemInfoPanel, item);
		}
	}

	private MPoppets GetEvolutionItem(RespPoppet pet, int index)
	{
		return MPoppets.Get(GetEvolutionItemID(pet, index));
	}

	private void PushShowResult()
	{
		ShowResult(0);
	}

	private void PushShowUltResult(int index)
	{
		ShowResult(index);
	}

	private void ShowResult(int index)
	{
		UserData current = UserData.Current;
		RespPoppet respPoppet = current.boxPoppet(baseItemBoxId);
		if (current.userMiscInfo.poppetBookData.isLook(GetEvolutionItem(respPoppet, index)))
		{
			JsonBase preview = GetPreview(respPoppet, index);
			if (preview != null)
			{
				ShowDetail(detailItemInfoPanel, preview);
			}
		}
	}

	public override void SetupList()
	{
		MapetList mapetList = (MapetList)baseItemList;
		mapetList.SetInputMapetList(UserData.Current.BoxPoppets);
	}

	public override ApiCompositionBase GetApi()
	{
		return GetEvoApi();
	}

	public override bool PowupStartCheck()
	{
		UserData current = UserData.Current;
		RespPoppet respPoppet = current.boxPoppet(baseItemBoxId);
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
		ApiPoppetEvolution apiPoppetEvolution = (ApiPoppetEvolution)reqBase;
		if (apiPoppetEvolution == null)
		{
			throw new AssertionFailedException("req != null");
		}
		MonoBehaviour.print("CallBackCreateItem");
		ApiPoppetEvolution.Resp response = apiPoppetEvolution.GetResponse();
		MonoBehaviour.print(new StringBuilder("GetResponse = ").Append(response).ToString());
		if (response == null)
		{
			SceneChanger.Change(errorSceneId);
			return;
		}
		resultItemBoxId = response.Id;
		RespPoppet respPoppet = UserData.Current.boxPoppet(response.Id);
		if (respPoppet == null)
		{
			throw new AssertionFailedException("mainpet != null");
		}
		UserData current = UserData.Current;
		RespPoppet respPoppet2 = (RespPoppet)CurItemInfo(baseItemList);
		if (current.IsFavorite(respPoppet2.RefPlayerBox))
		{
			current.OnFavorite(respPoppet.RefPlayerBox);
		}
		current.SetOld2NewItem(respPoppet2.RefPlayerBox);
		DispResult(levelUp: false, skillUp: false, maxLevelUp: false, evolution: true);
		demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
		Gousei3D component = demoAnim.GetComponent<Gousei3D>();
		component.mode = Gousei3D.Mode.PoppetEvolution;
		component.testMode = false;
		component.seiko = 0;
		component.IsLevelUp = false;
		component.IsSkillUp = false;
		component.IsLimitOver = false;
		component.rare = respPoppet.Master.Rare.Id;
		component.endFuncObject = gameObject;
		component.endFunction = "PushEndDemo";
		component.targetPoppet = respPoppet;
		int i = 0;
		JsonBase[] array = listItemInfo;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(((RespPoppet)array[i]).Id, baseItemBoxId))
				{
					component.basePoppet = (RespPoppet)array[i];
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
					if ((RespPoppet)array3[k] != null && RuntimeServices.EqualityOperator(((RespPoppet)array3[k]).Id, array2[j]))
					{
						RespPoppet[] materialPoppet = component.materialPoppet;
						materialPoppet[RuntimeServices.NormalizeArrayIndex(materialPoppet, num)] = (RespPoppet)array3[k];
						break;
					}
				}
				num++;
			}
			component.atkValues = new int[2];
			component.atkValues[0] = (int)respPoppet2.TotalAttack;
			component.atkValues[1] = (int)respPoppet.TotalAttack;
			component.hpValues = new int[2];
			component.hpValues[0] = (int)respPoppet2.TotalHP;
			component.hpValues[1] = (int)respPoppet.TotalHP;
			Initialize();
			ShowBaseDetail(respPoppet);
		}
	}

	public override void InitMaterialDisplay()
	{
		InitEvoMaterialDisplay(baseItemList.GetFocusData<RespPoppet>());
		SetPowupBaseDetail(baseItemList.focusItem);
	}

	public override void PushResult(GameObject obj)
	{
		mode = POWUP_MODE.PowupTop;
	}
}
