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
public class PetPowupMain : PowupBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SceneInit_0024coroutine_00245065_002421860 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CampaignsController.CampaignsRate _0024campaign_002421861;

			internal int _0024count_002421862;

			internal int _0024exp_002421863;

			internal int _0024cost_002421864;

			internal Color _0024color_002421865;

			internal int[] _0024_002414171_002421866;

			internal PetPowupMain _0024self__002421867;

			public _0024(PetPowupMain self_)
			{
				_0024self__002421867 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024campaign_002421861 = CampaignsController.GetCampaignsRate(isPowup: true);
					goto case 3;
				case 3:
					if (_0024self__002421867.mode == POWUP_MODE.PowupMaterial)
					{
						_0024count_002421862 = _0024self__002421867.materialItemList.selectCount;
						_0024_002414171_002421866 = _0024self__002421867.GetExpAndCost(useCamp: true, 0);
						_0024exp_002421863 = _0024_002414171_002421866[0];
						_0024cost_002421864 = _0024_002414171_002421866[1];
						UIBasicUtility.SetLabel(_0024self__002421867.selectCountLabel, _0024count_002421862.ToString(), show: true);
						UIBasicUtility.SetLabel(_0024self__002421867.expSumLabel, _0024exp_002421863.ToString(), show: true);
						if (!(1f >= _0024campaign_002421861.exp))
						{
							_0024color_002421865 = CampaignPanel.UpColor;
							UIBasicUtility.SetLabelColor(_0024self__002421867.expSumLabel, _0024color_002421865);
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PetPowupMain _0024self__002421868;

		public _0024_0024SceneInit_0024coroutine_00245065_002421860(PetPowupMain self_)
		{
			_0024self__002421868 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421868);
		}
	}

	public GameObject resultMessageBorard;

	public UILabelBase beforeLevelLabel;

	public UILabelBase beforeAttackLabel;

	public UILabelBase beforeHpLabel;

	public UILabelBase afterLevelLabel;

	public UILabelBase afterAttackLabel;

	public UILabelBase afterHpLabel;

	public UILabelBase afterBreakCountLabel;

	public UILabelBase afterBreakCountMaxLabel;

	public GameObject afterBreakCount;

	public UILabelBase selectCountLabel;

	public UILabelBase expSumLabel;

	private bool canMorePowup;

	public override void SceneInit()
	{
		BasicInit();
		baseItemList.HookSettingListItem = hookSettingBaseListItem;
		baseItemList.HookAutoFocusItem = hookAutoFocusItem;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024SceneInit_0024coroutine_00245065_002421860(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	private bool hookSettingBaseListItem(UIListItem item)
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
			baseItemList.SelectItem(item, canDecide: false);
		}
		return false;
	}

	private bool hookAutoFocusItem(ref UIListItem.Data data)
	{
		data = baseItemList.Find(UserData.Current.CurrentPoppetNewOrOldDeck.Id.Value);
		return true;
	}

	public override void InitMaterialDisplay()
	{
		CompositionDatas compData = GetCompData(0);
		if (0 < materialItemList.SelectItems.Count())
		{
			SceneTitleHUD.UpdateTitle(MTexts.Msg("$blk_poppet_powup_title"));
			UIBasicUtility.SetButtonValid(compData.buttonSet, e: true);
			int i = 0;
			UIListItem[] selectItems = materialItemList.SelectItems;
			for (int length = selectItems.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(selectItems[i].GetData<RespPoppet>().Id, baseItemBoxId))
				{
					materialItemList.RemoveSelect(selectItems[i]);
					break;
				}
			}
		}
		else
		{
			SceneTitleHUD.UpdateTitle(MTexts.Msg("$blk_poppet_material_title"));
			UIBasicUtility.SetButtonValid(compData.buttonSet, e: false);
		}
		base.InitMaterialDisplay();
	}

	public override void SetupList()
	{
		UserData current = UserData.Current;
		if (current != null)
		{
			MapetList mapetList = (MapetList)baseItemList;
			mapetList.SetInputMapetList(current.BoxPoppets);
			mapetList = (MapetList)materialItemList;
			mapetList.SetInputMapetList(current.BoxPoppets);
		}
	}

	public override ApiCompositionBase GetApi()
	{
		ApiPoppetStrengthening apiPoppetStrengthening = new ApiPoppetStrengthening();
		BoxId[] materialId = ArrayMapMain.RangeToBoxIds(5, delegate(int i)
		{
			BoxId[] array2 = materialItemBoxId;
			return array2[RuntimeServices.NormalizeArrayIndex(array2, i)];
		}, delegate(int i)
		{
			BoxId[] array = materialItemBoxId;
			return array[RuntimeServices.NormalizeArrayIndex(array, i)].IsValid;
		});
		apiPoppetStrengthening.add(baseItemBoxId, materialId);
		CompositionDatas compositionDatas = base.currentCompDatas;
		compositionDatas.infos = SelItemInfos(materialItemList);
		return apiPoppetStrengthening;
	}

	private void DispAfterBreakCount(int limitCnt, int limitMax, Color lvColor, bool show)
	{
		afterBreakCount.SetActive(show);
		if (show)
		{
			UIBasicUtility.SetLabel(afterBreakCountLabel, limitCnt.ToString());
			UIBasicUtility.SetLabel(afterBreakCountMaxLabel, limitMax.ToString());
			UIBasicUtility.SetLabelColor(afterBreakCountLabel, lvColor);
			UIBasicUtility.SetLabelColor(afterBreakCountMaxLabel, lvColor);
		}
	}

	public override void CallBackCreateItem(ApiCompositionBase reqBase)
	{
		ApiPoppetStrengthening apiPoppetStrengthening = (ApiPoppetStrengthening)reqBase;
		if (apiPoppetStrengthening == null)
		{
			throw new AssertionFailedException("req != null");
		}
		MonoBehaviour.print("CallBackCreateItem");
		ApiPoppetStrengthening.Resp response = apiPoppetStrengthening.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		UserData current = UserData.Current;
		RespPoppet respPoppet = current.boxPoppet(baseItemBoxId);
		current.SetOld2NewItem(respPoppet.RefPlayerBox);
		RespPoppet respPoppet2 = (RespPoppet)CurItemInfo(baseItemList);
		canMorePowup = false;
		canMorePowup = respPoppet.CanMorePowup;
		bool flag = respPoppet2.Level < respPoppet.Level;
		bool show = true;
		checked
		{
			if (flag)
			{
				resultMessageBorard.SetActive(value: true);
				resultMessageLabel.text = string.Empty;
				beforeLevelLabel.text = respPoppet2.Level.ToString();
				beforeAttackLabel.text = respPoppet2.TotalAttack.ToString();
				beforeHpLabel.text = respPoppet2.TotalHP.ToString();
				afterLevelLabel.text = respPoppet.Level.ToString();
				afterAttackLabel.text = respPoppet.TotalAttack.ToString();
				afterHpLabel.text = respPoppet.TotalHP.ToString();
			}
			else
			{
				resultMessageBorard.SetActive(value: false);
				resultMessageLabel.text = MTexts.Format("$blk_get_exp", Mathf.Max(0, respPoppet.Exp - respPoppet2.Exp), Mathf.Max(0, respPoppet.LevelUpExp - respPoppet.Exp));
				show = respPoppet.LimitBreakCount != respPoppet2.LimitBreakCount;
			}
			DispAfterBreakCount(respPoppet.LimitBreakCount, respPoppet.LimitBreakCountLimit, respPoppet.LevelColor, show);
			demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
			Gousei3D component = demoAnim.GetComponent<Gousei3D>();
			component.mode = Gousei3D.Mode.Poppet;
			component.testMode = false;
			component.seiko = response.CompositionResult - 1;
			MPoppets master = respPoppet2.Master;
			int[] array = new int[0];
			int num = respPoppet2.Level;
			while (true)
			{
				int num2 = master.exp(num + 1) - master.exp(num);
				array = (int[])RuntimeServices.AddArrays(typeof(int), array, new int[1] { num2 });
				if (respPoppet.Level <= num)
				{
					break;
				}
				num++;
			}
			int num3 = respPoppet.Level - respPoppet2.Level + 1;
			component.atkValues = new int[num3];
			component.hpValues = new int[num3];
			float num4 = respPoppet2.TotalAttack - (float)respPoppet2.Attack;
			float num5 = respPoppet.TotalHP - (float)respPoppet2.HP;
			int num6 = 0;
			int num7 = num3 - 1;
			if (num7 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num6 < num7)
			{
				int num8 = num6;
				num6 = unchecked(num6 + 1);
				int level = respPoppet2.Level + num8;
				int[] atkValues = component.atkValues;
				atkValues[RuntimeServices.NormalizeArrayIndex(atkValues, num8)] = (int)((float)master.attack(level) + num4);
				int[] hpValues = component.hpValues;
				hpValues[RuntimeServices.NormalizeArrayIndex(hpValues, num8)] = (int)((float)master.hp(level) + num5);
			}
			component.atkValues[0] = (int)respPoppet2.TotalAttack;
			component.hpValues[0] = (int)respPoppet2.TotalHP;
			int[] atkValues2 = component.atkValues;
			atkValues2[RuntimeServices.NormalizeArrayIndex(atkValues2, num3 - 1)] = (int)respPoppet.TotalAttack;
			int[] hpValues2 = component.hpValues;
			hpValues2[RuntimeServices.NormalizeArrayIndex(hpValues2, num3 - 1)] = (int)respPoppet.TotalHP;
			component.startLevel = respPoppet2.Level;
			component.elevatedLevel = respPoppet.Level - respPoppet2.Level;
			component.startExp = respPoppet2.CapExp - respPoppet2.LevelExp;
			component.endExp = respPoppet.CapExp - respPoppet.LevelExp;
			component.maxExps = array;
			component.IsLevelUp = respPoppet.Level > respPoppet2.Level;
			component.IsSkillUp = response.IsSkillLevelUp;
			component.IsLimitOver = response.IsRebirth;
			component.endFuncObject = gameObject;
			component.endFunction = "PushEndDemo";
			int i = 0;
			JsonBase[] array2 = listItemInfo;
			for (int length = array2.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(((RespPoppet)array2[i]).Id, baseItemBoxId))
				{
					component.basePoppet = (RespPoppet)array2[i];
					component.targetPoppet = (RespPoppet)array2[i];
					break;
				}
			}
			int num9 = 0;
			int j = 0;
			BoxId[] array3 = materialItemBoxId;
			for (int length2 = array3.Length; j < length2; j++)
			{
				int k = 0;
				JsonBase[] array4 = listItemInfo;
				for (int length3 = array4.Length; k < length3; k++)
				{
					if ((RespPoppet)array4[k] != null && RuntimeServices.EqualityOperator(((RespPoppet)array4[k]).Id, array3[j]))
					{
						RespPoppet[] materialPoppet = component.materialPoppet;
						materialPoppet[RuntimeServices.NormalizeArrayIndex(materialPoppet, num9)] = (RespPoppet)array4[k];
						break;
					}
				}
				num9++;
			}
			Initialize();
			if ((bool)newExpGuage)
			{
				newExpGuage.sliderValue = 0f;
			}
			if ((bool)oldExpGuage)
			{
				oldExpGuage.sliderValue = 0f;
			}
		}
	}

	public override void PushResult(GameObject obj)
	{
		if (canMorePowup)
		{
			mode = POWUP_MODE.PowupItem;
		}
		else
		{
			baseItemList.SetDefaultFocus();
			mode = POWUP_MODE.PowupTop;
		}
		UnityEngine.Object.Destroy(demoAnim);
	}

	internal IEnumerator _0024SceneInit_0024coroutine_00245065()
	{
		return new _0024_0024SceneInit_0024coroutine_00245065_002421860(this).GetEnumerator();
	}

	internal BoxId _0024GetApi_0024closure_00245066(int i)
	{
		BoxId[] array = materialItemBoxId;
		return array[RuntimeServices.NormalizeArrayIndex(array, i)];
	}

	internal bool _0024GetApi_0024closure_00245067(int i)
	{
		BoxId[] array = materialItemBoxId;
		return array[RuntimeServices.NormalizeArrayIndex(array, i)].IsValid;
	}
}
