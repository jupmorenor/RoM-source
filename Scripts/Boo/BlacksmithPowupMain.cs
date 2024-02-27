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
public class BlacksmithPowupMain : PowupBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024SceneInit_0024coroutine_00245021_002421529 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal CampaignsController.CampaignsRate _0024campaign_002421530;

			internal int _0024count_002421531;

			internal int _0024exp_002421532;

			internal int _0024cost_002421533;

			internal Color _0024color_002421534;

			internal int[] _0024_002414155_002421535;

			internal BlacksmithPowupMain _0024self__002421536;

			public _0024(BlacksmithPowupMain self_)
			{
				_0024self__002421536 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024campaign_002421530 = CampaignsController.GetCampaignsRate(isPowup: true);
					goto case 3;
				case 3:
					if (_0024self__002421536.mode == POWUP_MODE.PowupMaterial)
					{
						_0024count_002421531 = _0024self__002421536.materialItemList.selectCount;
						_0024_002414155_002421535 = _0024self__002421536.GetExpAndCost(useCamp: true, 0);
						_0024exp_002421532 = _0024_002414155_002421535[0];
						_0024cost_002421533 = _0024_002414155_002421535[1];
						UIBasicUtility.SetLabel(_0024self__002421536.selectCountLabel, _0024count_002421531.ToString(), show: true);
						UIBasicUtility.SetLabel(_0024self__002421536.expSumLabel, _0024exp_002421532.ToString(), show: true);
						if (!(1f >= _0024campaign_002421530.exp))
						{
							_0024color_002421534 = CampaignPanel.UpColor;
							UIBasicUtility.SetLabelColor(_0024self__002421536.expSumLabel, _0024color_002421534);
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

		internal BlacksmithPowupMain _0024self__002421537;

		public _0024_0024SceneInit_0024coroutine_00245021_002421529(BlacksmithPowupMain self_)
		{
			_0024self__002421537 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421537);
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
		baseItemList.HookSettingListItem = hookSettingBaseListItem;
		baseItemList.HookAutoFocusItem = hookAutoFocusItem;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024SceneInit_0024coroutine_00245021_002421529(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	private bool hookSettingBaseListItem(UIListItem item)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		WeaponList weaponList = (WeaponList)baseItemList;
		weaponList.weponHookSettingListItem(item);
		InitBaseItem(item);
		if (!baseItemBoxId.IsValid)
		{
			baseItemBoxId = getMainWeapon.Id;
		}
		if (RuntimeServices.EqualityOperator(item.GetData<RespWeapon>().Id, baseItemBoxId))
		{
			baseItemList.SelectItem(item, canDecide: false);
		}
		return false;
	}

	private bool hookAutoFocusItem(ref UIListItem.Data data)
	{
		data = baseItemList.Find(getMainWeapon.Id.Value);
		return true;
	}

	public override void InitMaterialDisplay()
	{
		CompositionDatas compData = GetCompData(0);
		if (0 < materialItemList.selectCount)
		{
			SceneTitleHUD.UpdateTitle(MTexts.Msg("$blk_weapon_powup_title"));
			UIBasicUtility.SetButtonValid(compData.buttonSet, e: true);
			int i = 0;
			UIListItem[] selectItems = materialItemList.SelectItems;
			for (int length = selectItems.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(selectItems[i].GetData<RespWeapon>().Id, baseItemBoxId))
				{
					materialItemList.RemoveSelect(selectItems[i]);
					break;
				}
			}
		}
		else
		{
			SceneTitleHUD.UpdateTitle(MTexts.Msg("$blk_weapon_material_title"));
			UIBasicUtility.SetButtonValid(compData.buttonSet, e: false);
		}
		base.InitMaterialDisplay();
	}

	public override void SetupList()
	{
		UserData current = UserData.Current;
		WeaponList weaponList = (WeaponList)baseItemList;
		weaponList.SetInputWeaponList(current.BoxWeapons);
		weaponList = (WeaponList)materialItemList;
		weaponList.ClearSelectItems();
		weaponList.SetInputWeaponList(current.BoxWeapons);
	}

	public override ApiCompositionBase GetApi()
	{
		ApiWeaponStrengthening apiWeaponStrengthening = new ApiWeaponStrengthening();
		BoxId[] materialId = ArrayMapMain.RangeToBoxIds(5, delegate(int i)
		{
			BoxId[] array2 = materialItemBoxId;
			return array2[RuntimeServices.NormalizeArrayIndex(array2, i)];
		}, delegate(int i)
		{
			BoxId[] array = materialItemBoxId;
			return array[RuntimeServices.NormalizeArrayIndex(array, i)].IsValid;
		});
		apiWeaponStrengthening.add(baseItemBoxId, materialId);
		CompositionDatas compositionDatas = base.currentCompDatas;
		compositionDatas.infos = SelItemInfos(materialItemList);
		return apiWeaponStrengthening;
	}

	private void DispAfterBreakCount(int limitCnt, int limitMax, Color lvColor, bool show)
	{
		afterBreakCount.SetActive(show);
		if (show)
		{
			UIBasicUtility.SetLabel(afterBreakCountLabel, limitCnt.ToString(), show: true);
			UIBasicUtility.SetLabel(afterBreakCountMaxLabel, limitMax.ToString(), show: true);
			UIBasicUtility.SetLabelColor(afterBreakCountLabel, lvColor);
			UIBasicUtility.SetLabelColor(afterBreakCountMaxLabel, lvColor);
		}
	}

	public override void CallBackCreateItem(ApiCompositionBase reqBase)
	{
		ApiWeaponStrengthening apiWeaponStrengthening = (ApiWeaponStrengthening)reqBase;
		if (apiWeaponStrengthening == null)
		{
			throw new AssertionFailedException("req != null");
		}
		MonoBehaviour.print("CallBackCreateItem");
		ApiWeaponStrengthening.Resp response = apiWeaponStrengthening.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("resp != null");
		}
		UserData current = UserData.Current;
		RespWeapon respWeapon = current.boxWeapon(baseItemBoxId);
		current.SetOld2NewItem(respWeapon.RefPlayerBox);
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer != null)
		{
			currentPlayer.refreshWeaponsCoverSkill();
		}
		RespWeapon respWeapon2 = (RespWeapon)CurItemInfo(baseItemList);
		canMorePowup = false;
		canMorePowup = respWeapon.CanMorePowup;
		bool flag = respWeapon2.Level < respWeapon.Level;
		bool show = true;
		checked
		{
			if (flag)
			{
				resultMessageBorard.SetActive(value: true);
				resultMessageLabel.text = string.Empty;
				beforeLevelLabel.text = respWeapon2.Level.ToString();
				beforeAttackLabel.text = respWeapon2.TotalAttack.ToString();
				beforeHpLabel.text = respWeapon2.TotalHP.ToString();
				afterLevelLabel.text = respWeapon.Level.ToString();
				afterAttackLabel.text = respWeapon.TotalAttack.ToString();
				afterHpLabel.text = respWeapon.TotalHP.ToString();
			}
			else
			{
				resultMessageBorard.SetActive(value: false);
				resultMessageLabel.text = MTexts.Format("$blk_get_exp", Mathf.Max(0, respWeapon.Exp - respWeapon2.Exp), Mathf.Max(0, respWeapon.LevelUpExp - respWeapon.Exp));
				show = respWeapon.LimitBreakCount != respWeapon2.LimitBreakCount;
			}
			DispAfterBreakCount(respWeapon.LimitBreakCount, respWeapon.LimitBreakCountLimit, respWeapon.LevelColor, show);
			demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
			Gousei3D component = demoAnim.GetComponent<Gousei3D>();
			component.mode = Gousei3D.Mode.Weapon;
			component.testMode = false;
			component.seiko = response.CompositionResult - 1;
			MWeapons master = respWeapon2.Master;
			int[] array = new int[0];
			int num = respWeapon2.Level;
			while (true)
			{
				int num2 = (int)(master.exp(num + 1) - master.exp(num));
				array = (int[])RuntimeServices.AddArrays(typeof(int), array, new int[1] { num2 });
				if (respWeapon.Level <= num)
				{
					break;
				}
				num++;
			}
			int num3 = respWeapon.Level - respWeapon2.Level + 1;
			component.atkValues = new int[num3];
			component.hpValues = new int[num3];
			float num4 = respWeapon2.TotalAttack - (float)respWeapon2.Attack;
			float num5 = respWeapon2.TotalHP - (float)respWeapon2.HP;
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
				int level = respWeapon2.Level + num8;
				int[] atkValues = component.atkValues;
				atkValues[RuntimeServices.NormalizeArrayIndex(atkValues, num8)] = (int)(master.attack(level) + num4);
				int[] hpValues = component.hpValues;
				hpValues[RuntimeServices.NormalizeArrayIndex(hpValues, num8)] = (int)(master.hp(level) + num5);
			}
			component.atkValues[0] = (int)respWeapon2.TotalAttack;
			component.hpValues[0] = (int)respWeapon2.TotalHP;
			int[] atkValues2 = component.atkValues;
			atkValues2[RuntimeServices.NormalizeArrayIndex(atkValues2, num3 - 1)] = (int)respWeapon.TotalAttack;
			int[] hpValues2 = component.hpValues;
			hpValues2[RuntimeServices.NormalizeArrayIndex(hpValues2, num3 - 1)] = (int)respWeapon.TotalHP;
			component.startLevel = respWeapon2.Level;
			component.elevatedLevel = respWeapon.Level - respWeapon2.Level;
			component.startExp = respWeapon2.CapExp - respWeapon2.LevelExp;
			component.endExp = respWeapon.CapExp - respWeapon.LevelExp;
			component.maxExps = array;
			component.IsLevelUp = flag;
			component.IsSkillUp = response.IsSkillLevelUp;
			component.IsLimitOver = response.IsRebirth;
			component.endFuncObject = gameObject;
			component.endFunction = "PushEndDemo";
			int i = 0;
			JsonBase[] array2 = listItemInfo;
			for (int length = array2.Length; i < length; i++)
			{
				if (RuntimeServices.EqualityOperator(((RespWeapon)array2[i]).Id, baseItemBoxId))
				{
					component.baseWeapon = (RespWeapon)array2[i];
					component.targetWeapon = (RespWeapon)array2[i];
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
					if ((RespWeapon)array4[k] != null && RuntimeServices.EqualityOperator(((RespWeapon)array4[k]).Id, array3[j]))
					{
						RespWeapon[] materialWeapon = component.materialWeapon;
						materialWeapon[RuntimeServices.NormalizeArrayIndex(materialWeapon, num9)] = (RespWeapon)array4[k];
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

	internal IEnumerator _0024SceneInit_0024coroutine_00245021()
	{
		return new _0024_0024SceneInit_0024coroutine_00245021_002421529(this).GetEnumerator();
	}

	internal BoxId _0024GetApi_0024closure_00245022(int i)
	{
		BoxId[] array = materialItemBoxId;
		return array[RuntimeServices.NormalizeArrayIndex(array, i)];
	}

	internal bool _0024GetApi_0024closure_00245023(int i)
	{
		BoxId[] array = materialItemBoxId;
		return array[RuntimeServices.NormalizeArrayIndex(array, i)].IsValid;
	}
}
