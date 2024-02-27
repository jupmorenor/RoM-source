using System;
using System.Collections;
using System.Linq;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PetInfoDetail : UIListItemDetail
{
	[Serializable]
	private class SkillData : UIListItemDetail.SkillDataBase
	{
		private MChainSkills chain;

		private MCoverSkills cover;

		private int level;

		public override bool IsValid => true;

		public override int lv => level;

		public override int lvMax => (chain != null) ? chain.LevelMax : ((cover == null) ? (-1) : cover.LevelMax);

		public override string lvStr => (lvMax < 0) ? string.Empty : ((lvMax > lv) ? level.ToString() : "mx");

		public override string name => (chain != null) ? chain.Name.ToString() : ((cover == null) ? "無し" : cover.Name.ToString());

		public override string detail => (chain != null) ? MasterExtensionsModule.MultiDetail(chain) : ((cover == null) ? string.Empty : MasterExtensionsModule.MultiDetail(cover, level));

		public override string iconName => (chain != null) ? chain.Icon : ((cover == null) ? string.Empty : cover.Icon);

		public SkillData(MChainSkills c, int lv)
		{
			SetMaster(c, null, lv);
		}

		public SkillData(MCoverSkills c, int lv)
		{
			SetMaster(null, c, lv);
		}

		private void SetMaster(MChainSkills ch, MCoverSkills co, int lv)
		{
			chain = ch;
			cover = co;
			level = lv;
		}
	}

	[Serializable]
	internal class _0024SetMuppetCore_0024locals_002414477
	{
		internal bool _0024show;
	}

	[Serializable]
	internal class _0024SetMuppetCore_0024closure_00245008
	{
		internal _0024SetMuppetCore_0024locals_002414477 _0024_0024locals_002415056;

		internal PetInfoDetail _0024this_002415057;

		public _0024SetMuppetCore_0024closure_00245008(_0024SetMuppetCore_0024locals_002414477 _0024_0024locals_002415056, PetInfoDetail _0024this_002415057)
		{
			this._0024_0024locals_002415056 = _0024_0024locals_002415056;
			this._0024this_002415057 = _0024this_002415057;
		}

		public void Invoke(AIControl ai)
		{
			ai.enabled = false;
			GameObject gameObject = ai.gameObject;
			gameObject.transform.parent = _0024this_002415057.model.transform;
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			NGUITools.SetLayer(gameObject, _0024this_002415057.model.gameObject.layer);
			_0024this_002415057.model.gameObject.SetActive(_0024_0024locals_002415056._0024show);
		}
	}

	public GameObject model;

	public ProfileInfo[] profileInfo;

	public ExpInfo[] expInfo;

	public IconInfo[] iconInfo;

	public ForceInfo[] baseForceInfo;

	public ForceInfo[] plusForceInfo;

	public PriceInfo[] priceInfo;

	public SkillInfo[] chainSkillInfo;

	public SkillInfo[] coverSkill1Info;

	public SkillInfo[] coverSkill2Info;

	public UIItemSupportSwitcher supportInfo;

	public TotalInfo[] totalInfo;

	private RespPoppet[] lastTotalWeaponArray;

	protected RespPoppet nowMuppet;

	protected RespPoppet lastMuppet;

	protected RespPoppet newMuppet;

	protected RespPoppet lastNewMuppet;

	public IconCreator iconCreator;

	protected RespPoppet[] lastTotalMuppetArray;

	private bool lastFavo;

	private UIListItem.Data cacheData;

	public RespPoppet[] LastTotalWeaponArray => lastTotalWeaponArray;

	public RespPoppet LastMuppet => lastMuppet;

	public RespPoppet[] LastTotalMuppetArray => lastTotalMuppetArray;

	public void Awake()
	{
		if ((bool)iconCreator && (iconInfo.Count() <= 0 || iconInfo[0] == null || iconInfo[0].IsEmpty))
		{
			if (iconInfo.Count() <= 0 || iconInfo[0] == null)
			{
				iconInfo = new IconInfo[1]
				{
					new IconInfo()
				};
			}
			GameObject gameObject = iconCreator.CreateIcon();
			IconInfoObject component = gameObject.GetComponent<IconInfoObject>();
			component.CopyOut(iconInfo[0]);
			MuppetInfo component2 = gameObject.GetComponent<MuppetInfo>();
			component2.enabled = false;
		}
	}

	public void Reset()
	{
		lastMuppet = null;
		nowMuppet = null;
		newMuppet = null;
		lastNewMuppet = null;
		SetMuppetCore(null, null);
		SetTotalStatusCore(null);
	}

	public void LateUpdate()
	{
		if (!RuntimeServices.EqualityOperator(nowMuppet, lastMuppet) || !RuntimeServices.EqualityOperator(newMuppet, lastNewMuppet))
		{
			SetMuppetCore(nowMuppet, newMuppet);
			lastMuppet = nowMuppet;
			lastNewMuppet = newMuppet;
		}
		if (lastMuppet == null)
		{
			return;
		}
		RespPlayerBox refPlayerBox = lastMuppet.RefPlayerBox;
		if (UserData.Current.IsFavorite(lastMuppet.RefPlayerBox) == lastFavo)
		{
			return;
		}
		lastFavo = !lastFavo;
		int i = 0;
		IconInfo[] array = iconInfo;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && (bool)array[i].icon)
			{
				array[i].icon.SetFavorite(lastFavo);
			}
		}
	}

	public override UIListItem.Data GetDetail()
	{
		return cacheData;
	}

	private RespPoppet GetRespPoppet(UIListItem.Data data)
	{
		RespPoppet result = null;
		if (data != null)
		{
			if (data.IsData<RespPlayerBox>())
			{
				RespPlayerBox data2 = data.GetData<RespPlayerBox>();
				result = data2.toRespPoppet();
			}
			else
			{
				result = data.GetData<RespPoppet>();
			}
		}
		return result;
	}

	public override void SetPowupDetail(UIListItem.Data data, UIListItem.Data newData)
	{
		if (data != null)
		{
			SetMuppet(GetRespPoppet(data), GetRespPoppet(newData));
		}
		else
		{
			SetMuppetCore(null, null);
		}
		cacheData = data;
	}

	public void SetMuppet(RespPoppet muppet, RespPoppet newPet)
	{
		if (muppet != null && muppet.IsValidMaster)
		{
			nowMuppet = muppet;
			newMuppet = newPet;
		}
	}

	private void SetMuppetCore(RespPoppet muppet, RespPoppet newPet)
	{
		_0024SetMuppetCore_0024locals_002414477 _0024SetMuppetCore_0024locals_0024 = new _0024SetMuppetCore_0024locals_002414477();
		_0024SetMuppetCore_0024locals_0024._0024show = true;
		if (muppet == null)
		{
			muppet = new RespPoppet(1);
		}
		bool flag = true;
		UserData current = UserData.Current;
		if (current != null)
		{
			flag = current.userMiscInfo.poppetBookData.isLook(muppet.Master);
		}
		checked
		{
			if (!flag)
			{
				if (profileInfo != null)
				{
					int i = 0;
					ProfileInfo[] array = profileInfo;
					for (int length = array.Length; i < length; i++)
					{
						UIListItemDetail.SetLevelLabel(array[i].levelInfo, muppet.Level, muppet.CurrentLevelLimit, _0024SetMuppetCore_0024locals_0024._0024show, muppet.LevelColor, muppet.LevelColor);
						UIBasicUtility.SetLabel(array[i].nameLabel, muppet.Name, _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array[i].explainLabel, muppet.Detail, _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array[i].typeLabel, muppet.Detail, _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array[i].elementLabel, muppet.Element.Name.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array[i].deckCostLabel, muppet.DeckCost.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetSprite(array[i].traitSprite, muppet.TraitSpriteName, null, _0024SetMuppetCore_0024locals_0024._0024show);
					}
				}
				if (iconInfo != null)
				{
					int j = 0;
					IconInfo[] array2 = iconInfo;
					for (int length2 = array2.Length; j < length2; j++)
					{
						UIBasicUtility.SetPoppetIconSprite(array2[j].sprite, muppet, _0024SetMuppetCore_0024locals_0024._0024show);
					}
				}
				if (baseForceInfo != null)
				{
					int k = 0;
					ForceInfo[] array3 = baseForceInfo;
					for (int length3 = array3.Length; k < length3; k++)
					{
						UIBasicUtility.SetLabel(array3[k].attackLabel, muppet.TotalAttack.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array3[k].hpLabel, muppet.TotalHP.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					}
				}
				if (plusForceInfo != null)
				{
					int l = 0;
					ForceInfo[] array4 = plusForceInfo;
					for (int length4 = array4.Length; l < length4; l++)
					{
						UIBasicUtility.SetLabel(array4[l].attackLabel, muppet.AttackBonus.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
						UIBasicUtility.SetLabel(array4[l].hpLabel, muppet.HpBonus.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					}
				}
				return;
			}
			if ((bool)model)
			{
				IEnumerator enumerator = model.transform.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform = (Transform)obj;
					UnityEngine.Object.DestroyObject(transform.gameObject);
				}
				PoppetFactory.Instance.createPoppetObj(muppet, new _0024SetMuppetCore_0024closure_00245008(_0024SetMuppetCore_0024locals_0024, this).Invoke);
			}
			if (profileInfo != null)
			{
				RespPoppet respPoppet = muppet;
				Color lvColor = respPoppet.LevelColor;
				if (newPet != null)
				{
					respPoppet = newPet;
					if (muppet.Level < newPet.Level)
					{
						lvColor = new Color(1f, 19f / 51f, 19f / 51f);
					}
				}
				int m = 0;
				ProfileInfo[] array5 = profileInfo;
				for (int length5 = array5.Length; m < length5; m++)
				{
					UIListItemDetail.SetLevelLabel(array5[m].levelInfo, respPoppet.Level, respPoppet.CurrentLevelLimit, _0024SetMuppetCore_0024locals_0024._0024show, lvColor, respPoppet.LevelColor);
					UIBasicUtility.SetLabel(array5[m].nameLabel, respPoppet.Name, _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array5[m].explainLabel, respPoppet.Detail, _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array5[m].typeLabel, respPoppet.Detail, _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array5[m].elementLabel, respPoppet.Element.Name.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array5[m].deckCostLabel, respPoppet.DeckCost.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetSprite(array5[m].traitSprite, respPoppet.TraitSpriteName, null, _0024SetMuppetCore_0024locals_0024._0024show);
				}
			}
			UIListItemDetail.SetExp(expInfo, muppet.LevelExpDist, muppet.LevelUpExpDist, muppet.Level, muppet.CurrentLevelLimit, _0024SetMuppetCore_0024locals_0024._0024show);
			UIListItemDetail.SetSkill(chainSkillInfo, new SkillData(muppet.ChainSkill, muppet.ChainSkillLevel), _0024SetMuppetCore_0024locals_0024._0024show);
			UIListItemDetail.SetSkill(coverSkill1Info, new SkillData(muppet.CoverSkill1, muppet.CoverSkillLevel_1), _0024SetMuppetCore_0024locals_0024._0024show);
			UIListItemDetail.SetSkill(coverSkill2Info, new SkillData(muppet.CoverSkill2, muppet.CoverSkillLevel_2), _0024SetMuppetCore_0024locals_0024._0024show);
			if ((bool)supportInfo)
			{
				RespPoppet respPoppet = muppet;
				if (newPet != null)
				{
					respPoppet = muppet;
				}
				supportInfo.SetInfo(respPoppet);
			}
			if (iconInfo != null)
			{
				int n = 0;
				IconInfo[] array6 = iconInfo;
				for (int length6 = array6.Length; n < length6; n++)
				{
					UIBasicUtility.SetPoppetIconSprite(array6[n].sprite, muppet, _0024SetMuppetCore_0024locals_0024._0024show);
					if ((bool)array6[n].icon)
					{
						array6[n].icon.SetFavorite(current.userMiscInfo.poppetFavoriteData.isFavor(muppet.Id));
					}
					array6[n].icon.DestroyLevel();
					GameObject plusObject = array6[n].icon.GetPlusObject();
					if (plusObject != null)
					{
						RespPoppet respPoppet = muppet;
						if (newPet != null)
						{
							respPoppet = newPet;
						}
						UIBasicUtility.SetSumPlusBonusLabel(plusObject.GetComponent<UILabelBase>(), respPoppet);
						array6[n].icon.SetEnableAlphaTargets("PlusText", 0 < respPoppet.SumPlusBonus);
					}
				}
			}
			if (baseForceInfo != null)
			{
				RespPoppet respPoppet = muppet;
				Color c = new Color(14f / 15f, 36f / 85f, 16f / 85f);
				Color c2 = new Color(0.5882353f, 0.8980392f, 0.2627451f);
				if (newPet != null)
				{
					respPoppet = newPet;
					if (muppet.Level < newPet.Level)
					{
						c = new Color(1f, 19f / 51f, 19f / 51f);
						c2 = new Color(1f, 19f / 51f, 19f / 51f);
					}
				}
				int num = 0;
				ForceInfo[] array7 = baseForceInfo;
				for (int length7 = array7.Length; num < length7; num++)
				{
					UIBasicUtility.SetLabel(array7[num].attackLabel, respPoppet.TotalAttack.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array7[num].hpLabel, respPoppet.TotalHP.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabelColor(array7[num].attackLabel, c);
					UIBasicUtility.SetLabelColor(array7[num].hpLabel, c2);
				}
			}
			if (plusForceInfo != null)
			{
				RespPoppet respPoppet = muppet;
				if (newPet != null)
				{
					respPoppet = newPet;
				}
				int num2 = 0;
				ForceInfo[] array8 = plusForceInfo;
				for (int length8 = array8.Length; num2 < length8; num2++)
				{
					UIBasicUtility.SetLabel(array8[num2].attackLabel, respPoppet.AttackBonus.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array8[num2].hpLabel, respPoppet.HpBonus.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
				}
			}
			if (priceInfo != null)
			{
				int num3 = 0;
				PriceInfo[] array9 = priceInfo;
				for (int length9 = array9.Length; num3 < length9; num3++)
				{
					UIBasicUtility.SetLabel(array9[num3].buyLabel, muppet.SellPrice.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
					UIBasicUtility.SetLabel(array9[num3].sellLabel, muppet.SellPrice.ToString(), _0024SetMuppetCore_0024locals_0024._0024show);
				}
			}
		}
	}

	public void SetTotalStatus(RespPoppet[] muppetList)
	{
		if (muppetList != null && muppetList.Length > 0)
		{
			SetTotalStatusCore(muppetList);
		}
	}

	public void SetTotalStatusCore(RespPoppet[] muppetList)
	{
		if (totalInfo == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		checked
		{
			if (muppetList != null)
			{
				int i = 0;
				for (int length = muppetList.Length; i < length; i++)
				{
					num += muppetList[i].Attack;
					num2 += muppetList[i].HP;
					num3 += muppetList[i].damageScale(EnumElements.fire);
					num4 += muppetList[i].damageScale(EnumElements.water);
					num5 += muppetList[i].damageScale(EnumElements.wind);
					num6 += muppetList[i].damageScale(EnumElements.earth);
				}
			}
			bool show = muppetList != null;
			UIListItemDetail.SetTotal(totalInfo, num, num2, num3, num4, num5, num6, show);
		}
	}
}
