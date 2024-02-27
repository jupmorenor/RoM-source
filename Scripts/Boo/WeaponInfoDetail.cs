using System;
using System.Linq;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WeaponInfoDetail : UIListItemDetail
{
	[Serializable]
	private class SkillData : UIListItemDetail.SkillDataBase
	{
		private MCoverSkills cover;

		private MWeaponSkills weapon;

		private int level;

		public override bool IsValid => true;

		public override int lv => level;

		public override int lvMax => (cover != null) ? cover.LevelMax : ((weapon == null) ? (-1) : weapon.LevelMax);

		public override string lvStr => (lvMax < 0) ? null : ((lvMax > lv) ? level.ToString() : "mx");

		public override string name => (cover != null) ? cover.Name.ToString() : ((weapon == null) ? "無し" : weapon.Name.ToString());

		public override string detail => (cover != null) ? MasterExtensionsModule.MultiDetail(cover, level) : ((weapon == null) ? string.Empty : MasterExtensionsModule.MultiDetail(weapon));

		public override string iconName => (cover != null) ? cover.Icon : ((weapon == null) ? string.Empty : weapon.Icon);

		public SkillData(MCoverSkills c, int lv)
		{
			SetMaster(c, null, lv);
		}

		public SkillData(MWeaponSkills w, int lv)
		{
			SetMaster(null, w, lv);
		}

		private void SetMaster(MCoverSkills c, MWeaponSkills w, int lv)
		{
			cover = c;
			weapon = w;
			level = lv;
		}
	}

	public UILabelBase infoTitleLabel;

	public ProfileInfo[] profileInfo;

	public ExpInfo[] expInfo;

	public IconInfo[] iconInfo;

	public ForceInfo[] baseForceInfo;

	public ForceInfo[] plusForceInfo;

	public PriceInfo[] priceInfo;

	public SkillInfo[] coverSkillInfo;

	public SkillInfo[] angleSkillInfo;

	public SkillInfo[] demonSkillInfo;

	public UIItemSupportSwitcher supportInfo;

	private RespWeapon nowWeapon;

	private RespWeapon lastWeapon;

	private RespWeapon newWeapon;

	private RespWeapon lastNewWeapon;

	public TotalInfo[] totalInfo;

	private RespWeapon[] lastTotalWeaponArray;

	public IconCreator iconCreator;

	private bool lastFavo;

	private UIListItem.Data cacheData;

	private bool dbgShowId;

	public RespWeapon LastWeapon => lastWeapon;

	public RespWeapon[] LastTotalWeaponArray => lastTotalWeaponArray;

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
			WeaponInfo component2 = gameObject.GetComponent<WeaponInfo>();
			component2.enabled = false;
		}
	}

	public void Reset()
	{
		nowWeapon = null;
		lastWeapon = null;
		newWeapon = null;
		lastNewWeapon = null;
		SetWeaponCore(null, null);
		SetTotalStatusCore(null);
	}

	public void LateUpdate()
	{
		if (!RuntimeServices.EqualityOperator(nowWeapon, lastWeapon) || !RuntimeServices.EqualityOperator(newWeapon, lastNewWeapon))
		{
			SetWeaponCore(nowWeapon, newWeapon);
			lastWeapon = nowWeapon;
			lastNewWeapon = newWeapon;
		}
		if (lastWeapon == null)
		{
			return;
		}
		RespPlayerBox refPlayerBox = lastWeapon.RefPlayerBox;
		if (UserData.Current.IsFavorite(refPlayerBox) == lastFavo)
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

	private RespWeapon GetRespWeapon(UIListItem.Data data)
	{
		RespWeapon result = null;
		if (data != null)
		{
			if (data.IsData<RespPlayerBox>())
			{
				RespPlayerBox data2 = data.GetData<RespPlayerBox>();
				result = data2.toRespWeapon();
			}
			else
			{
				result = data.GetData<RespWeapon>();
			}
		}
		return result;
	}

	public override void SetPowupDetail(UIListItem.Data data, UIListItem.Data newData)
	{
		if (data != null)
		{
			SetWeapon(GetRespWeapon(data), GetRespWeapon(newData));
		}
		else
		{
			SetWeaponCore(null, null);
		}
		cacheData = data;
	}

	public void SetWeapon(RespWeapon weapon, RespWeapon newWep)
	{
		if (weapon != null && weapon.IsValidMaster)
		{
			nowWeapon = weapon;
			newWeapon = newWep;
		}
	}

	private void SetWeaponCore(RespWeapon weapon, RespWeapon newWep)
	{
		bool show = true;
		if (weapon == null)
		{
			weapon = new RespWeapon(1);
		}
		UserData current = UserData.Current;
		bool flag = current.userMiscInfo.weaponBookData.isLook(weapon.Master);
		lastFavo = UserData.Current.IsFavorite(weapon.RefPlayerBox);
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
						UIListItemDetail.SetLevelLabel(array[i].levelInfo, weapon.Level, weapon.CurrentLevelLimit, show, weapon.LevelColor, weapon.LevelColor);
						UIBasicUtility.SetLabel(array[i].nameLabel, "???", show);
					}
				}
				if (iconInfo != null)
				{
					int j = 0;
					IconInfo[] array2 = iconInfo;
					for (int length2 = array2.Length; j < length2; j++)
					{
						UIBasicUtility.SetWeaponIconSprite(array2[j].sprite, weapon, show);
					}
				}
				if (baseForceInfo != null)
				{
					int k = 0;
					ForceInfo[] array3 = baseForceInfo;
					for (int length3 = array3.Length; k < length3; k++)
					{
						UIBasicUtility.SetLabel(array3[k].attackLabel, weapon.Attack.ToString(), show);
						UIBasicUtility.SetLabel(array3[k].hpLabel, weapon.HP.ToString(), show);
					}
				}
				if (plusForceInfo != null)
				{
					int l = 0;
					ForceInfo[] array4 = plusForceInfo;
					for (int length4 = array4.Length; l < length4; l++)
					{
						UIBasicUtility.SetLabel(array4[l].attackLabel, "( +" + weapon.AttackBonus.ToString() + " )", show);
						UIBasicUtility.SetLabel(array4[l].hpLabel, "( +" + weapon.HpBonus.ToString() + " )", show);
					}
				}
				return;
			}
			if (profileInfo != null)
			{
				RespWeapon respWeapon = weapon;
				Color lvColor = weapon.LevelColor;
				if (newWep != null)
				{
					respWeapon = newWep;
					if (weapon.Level < newWep.Level)
					{
						lvColor = new Color(1f, 19f / 51f, 19f / 51f);
					}
				}
				int m = 0;
				ProfileInfo[] array5 = profileInfo;
				for (int length5 = array5.Length; m < length5; m++)
				{
					UIListItemDetail.SetLevelLabel(array5[m].levelInfo, respWeapon.Level, respWeapon.CurrentLevelLimit, show, lvColor, respWeapon.LevelColor);
					UIBasicUtility.SetLabel(array5[m].nameLabel, (!dbgShowId) ? respWeapon.Name : respWeapon.Id.ToString(), show);
					UIBasicUtility.SetLabel(array5[m].explainLabel, respWeapon.Detail, show);
					UIBasicUtility.SetLabel(array5[m].typeLabel, respWeapon.Detail, show);
					UIBasicUtility.SetLabel(array5[m].elementLabel, respWeapon.Element.Name.ToString(), show);
					UIBasicUtility.SetLabel(array5[m].deckCostLabel, respWeapon.DeckCost.ToString(), show);
					UIBasicUtility.SetSprite(array5[m].traitSprite, respWeapon.TraitSpriteName, null, show);
				}
			}
			UIListItemDetail.SetExp(expInfo, weapon.LevelExpDist, weapon.LevelUpExpDist, weapon.Level, weapon.CurrentLevelLimit, show);
			UIListItemDetail.SetSkill(coverSkillInfo, new SkillData(weapon.CoverSkill, weapon.CoverSkillLevel), show);
			UIListItemDetail.SetSkill(angleSkillInfo, new SkillData(weapon.AngelSkill, weapon.AngelSkillLevel), show);
			UIListItemDetail.SetSkill(demonSkillInfo, new SkillData(weapon.DemonSkill, weapon.DemonSkillLevel), show);
			if ((bool)supportInfo)
			{
				RespWeapon respWeapon = weapon;
				if (newWep != null)
				{
					respWeapon = newWep;
				}
				supportInfo.SetInfo(respWeapon);
			}
			if (iconInfo != null)
			{
				int n = 0;
				IconInfo[] array6 = iconInfo;
				for (int length6 = array6.Length; n < length6; n++)
				{
					UIBasicUtility.SetWeaponIconSprite(array6[n].sprite, weapon, show);
					if ((bool)array6[n].icon)
					{
						array6[n].icon.SetFavorite(lastFavo);
					}
					array6[n].icon.DestroyLevel();
					GameObject plusObject = array6[n].icon.GetPlusObject();
					if (plusObject != null)
					{
						RespWeapon respWeapon = weapon;
						if (newWep != null)
						{
							respWeapon = newWep;
						}
						UIBasicUtility.SetSumPlusBonusLabel(plusObject.GetComponent<UILabelBase>(), respWeapon);
						array6[n].icon.SetEnableAlphaTargets("PlusText", 0 < respWeapon.SumPlusBonus);
					}
				}
			}
			if (baseForceInfo != null)
			{
				RespWeapon respWeapon = weapon;
				Color c = new Color(14f / 15f, 36f / 85f, 16f / 85f);
				Color c2 = new Color(0.5882353f, 0.8980392f, 0.2627451f);
				if (newWep != null)
				{
					respWeapon = newWep;
					if (weapon.Level < newWep.Level)
					{
						c = new Color(1f, 19f / 51f, 19f / 51f);
						c2 = new Color(1f, 19f / 51f, 19f / 51f);
					}
				}
				int num = 0;
				ForceInfo[] array7 = baseForceInfo;
				for (int length7 = array7.Length; num < length7; num++)
				{
					UIBasicUtility.SetLabel(array7[num].attackLabel, respWeapon.TotalAttack.ToString(), show);
					UIBasicUtility.SetLabel(array7[num].hpLabel, respWeapon.TotalHP.ToString(), show);
					UIBasicUtility.SetLabelColor(array7[num].attackLabel, c);
					UIBasicUtility.SetLabelColor(array7[num].hpLabel, c2);
				}
			}
			if (plusForceInfo != null)
			{
				RespWeapon respWeapon = weapon;
				if (newWep != null)
				{
					respWeapon = newWep;
				}
				int num2 = 0;
				ForceInfo[] array8 = plusForceInfo;
				for (int length8 = array8.Length; num2 < length8; num2++)
				{
					UIBasicUtility.SetLabel(array8[num2].attackLabel, respWeapon.AttackBonus.ToString(), show);
					UIBasicUtility.SetLabel(array8[num2].hpLabel, respWeapon.HpBonus.ToString(), show);
				}
			}
			if (priceInfo != null)
			{
				int num3 = 0;
				PriceInfo[] array9 = priceInfo;
				for (int length9 = array9.Length; num3 < length9; num3++)
				{
					UIBasicUtility.SetLabel(array9[num3].buyLabel, weapon.SellPrice.ToString(), show);
					UIBasicUtility.SetLabel(array9[num3].sellLabel, weapon.SellPrice.ToString(), show);
				}
			}
		}
	}

	public void SetTotalStatus(RespWeapon[] weaponList)
	{
		if (weaponList != null && weaponList.Length > 0)
		{
			SetTotalStatusCore(weaponList);
		}
	}

	public void SetTotalStatusCore(RespWeapon[] weaponList)
	{
		checked
		{
			if (totalInfo != null)
			{
				int tap = 0;
				int thp = 0;
				int fp = 0;
				int wp = 0;
				int ap = 0;
				int ep = 0;
				if (weaponList != null)
				{
					tap = (int)DamageCalc.TotalWeaponAttack(weaponList);
					thp = (int)DamageCalc.TotalWeaponHP(weaponList);
					RespWeapon respWeapon = weaponList[0];
					fp = (int)(respWeapon.damageScale(EnumElements.fire) * 100f);
					wp = (int)(respWeapon.damageScale(EnumElements.water) * 100f);
					ap = (int)(respWeapon.damageScale(EnumElements.wind) * 100f);
					ep = (int)(respWeapon.damageScale(EnumElements.earth) * 100f);
				}
				bool show = weaponList != null;
				UIListItemDetail.SetTotal(totalInfo, tap, thp, fp, wp, ap, ep, show);
			}
		}
	}
}
