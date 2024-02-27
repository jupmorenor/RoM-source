using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumPoppetSetInfo : MonoBehaviour
{
	[Serializable]
	public enum DispMode
	{
		Skill,
		Status
	}

	public int Id;

	protected bool leaderFlag;

	public GameObject poppetIconPrefab;

	public GameObject weaponIconPrefab;

	protected RespPoppet _poppet;

	protected RespPoppet _lastPoppet;

	protected RespWeapon _weapon;

	protected RespWeapon _lastWeapon;

	public GameObject weaponIconParent;

	public GameObject poppetIconParent;

	private GameObject weaponIcon;

	private GameObject poppetIcon;

	public UIDynamicFontLabel petPsvSkill1;

	public UILabel petPsvSkill1Lv;

	public GameObject disablePetPsvSkill1;

	public UIDynamicFontLabel petPsvSkill2;

	public UILabel petPsvSkill2Lv;

	public GameObject disablePetPsvSkill2;

	public UIDynamicFontLabel petCombinationSkillName;

	public UILabel petCombinationSkillLv;

	public GameObject disablePetCombinationSkill;

	public UIDynamicFontLabel wepPsvSkillName;

	public UILabel wepPsvSkillLv;

	public GameObject disableWepPsvSkill;

	public UILabel petCostLabel;

	public UILabel petAtkLabel;

	public UILabel petHpLabel;

	public UILabel petLvLabel;

	public UILabel wepCostLabel;

	public UILabel wepAtkLabel;

	public UILabel wepHpLabel;

	public UILabel wepLvLabel;

	public string petAtkFormat;

	public string petHpFormat;

	public string wepAtkFormat;

	public string wepHpFormat;

	public GameObject leaderIcon;

	public GameObject skillPanel;

	public GameObject statusPanel;

	public string levelFormat;

	public string initSkillString;

	private bool deckCostOver;

	private int[] rarityLimits;

	private int[] styleLimits;

	private int[] elementLimits;

	public bool Leader
	{
		get
		{
			return leaderFlag;
		}
		set
		{
			leaderFlag = value;
			if (null != leaderIcon)
			{
				leaderIcon.SetActive(leaderFlag);
			}
		}
	}

	public RespPoppet Poppet
	{
		get
		{
			return _poppet;
		}
		set
		{
			_lastPoppet = null;
			_poppet = value;
		}
	}

	public bool isPoppetUpdate
	{
		get
		{
			return !RuntimeServices.EqualityOperator(_lastPoppet, _poppet);
		}
		set
		{
			if (!value)
			{
				_lastPoppet = _poppet;
			}
			else
			{
				_lastPoppet = null;
			}
		}
	}

	public RespWeapon Weapon
	{
		get
		{
			return _weapon;
		}
		set
		{
			_lastWeapon = null;
			_weapon = value;
		}
	}

	public bool isWeaponUpdate
	{
		get
		{
			return !RuntimeServices.EqualityOperator(_lastWeapon, _weapon);
		}
		set
		{
			if (!value)
			{
				_lastWeapon = _weapon;
			}
			else
			{
				_lastWeapon = null;
			}
		}
	}

	public GameObject WeaponIcon
	{
		get
		{
			return weaponIcon;
		}
		set
		{
			weaponIcon = value;
		}
	}

	public GameObject PoppetIcon
	{
		get
		{
			return poppetIcon;
		}
		set
		{
			poppetIcon = value;
		}
	}

	public bool DeckCostOver => deckCostOver;

	public int[] RarityLimits => rarityLimits;

	public int[] StyleLimits => styleLimits;

	public int[] ElementLimits => elementLimits;

	public ColosseumPoppetSetInfo()
	{
		petAtkFormat = "{0}";
		petHpFormat = "{0}";
		wepAtkFormat = "({0})";
		wepHpFormat = "({0})";
		levelFormat = "lv{0}";
		initSkillString = "無し";
		rarityLimits = new int[0];
		styleLimits = new int[0];
		elementLimits = new int[0];
	}

	public void Init(int id, DispMode mode)
	{
		if (null != PoppetIcon)
		{
			PoppetIcon.SetActive(value: false);
		}
		if (null != WeaponIcon)
		{
			WeaponIcon.SetActive(value: false);
		}
		if (null != leaderIcon)
		{
			leaderIcon.SetActive(leaderFlag);
		}
		UIBasicUtility.SetLabel(wepPsvSkillName, initSkillString);
		UIBasicUtility.SetLabel(wepPsvSkillLv, string.Empty);
		UIBasicUtility.SetLabel(petPsvSkill1, initSkillString);
		UIBasicUtility.SetLabel(petPsvSkill2, initSkillString);
		UIBasicUtility.SetLabel(petPsvSkill1Lv, string.Empty);
		UIBasicUtility.SetLabel(petPsvSkill2Lv, string.Empty);
		UIBasicUtility.SetLabel(petCombinationSkillName, initSkillString);
		UIBasicUtility.SetLabel(petCombinationSkillLv, string.Empty);
		if (null != petCostLabel)
		{
			UIBasicUtility.SetLabel(petCostLabel, string.Empty);
		}
		if (null != petAtkLabel)
		{
			UIBasicUtility.SetLabel(petAtkLabel, string.Empty);
		}
		if (null != petHpLabel)
		{
			UIBasicUtility.SetLabel(petHpLabel, string.Empty);
		}
		if (null != petLvLabel)
		{
			UIBasicUtility.SetLabel(petLvLabel, string.Empty);
		}
		if (null != wepCostLabel)
		{
			UIBasicUtility.SetLabel(wepCostLabel, string.Empty);
		}
		if (null != wepAtkLabel)
		{
			UIBasicUtility.SetLabel(wepAtkLabel, string.Empty);
		}
		if (null != wepHpLabel)
		{
			UIBasicUtility.SetLabel(wepHpLabel, string.Empty);
		}
		if (null != wepLvLabel)
		{
			UIBasicUtility.SetLabel(wepLvLabel, string.Empty);
		}
		if (null != weaponIconParent)
		{
			UIButtonMessage component = weaponIconParent.GetComponent<UIButtonMessage>();
			if (null != component)
			{
				component.sendMessage = true;
				component.mode = UIButtonMessage.SendMode.Integer;
				component.integer = id;
			}
		}
		if (null != poppetIconParent)
		{
			UIButtonMessage component2 = poppetIconParent.GetComponent<UIButtonMessage>();
			if (null != component2)
			{
				component2.sendMessage = true;
				component2.mode = UIButtonMessage.SendMode.Integer;
				component2.integer = id;
			}
		}
		SetDispMode(mode);
	}

	public void SetDispMode(DispMode mode)
	{
		switch (mode)
		{
		case DispMode.Status:
			if (null != statusPanel)
			{
				statusPanel.SetActive(value: true);
			}
			if (null != skillPanel)
			{
				skillPanel.SetActive(value: false);
			}
			break;
		case DispMode.Skill:
			if (null != statusPanel)
			{
				statusPanel.SetActive(value: false);
			}
			if (null != skillPanel)
			{
				skillPanel.SetActive(value: true);
			}
			break;
		}
	}

	public void SetCostOver(bool over)
	{
		deckCostOver = over;
		isWeaponUpdate = true;
		isPoppetUpdate = true;
	}

	public void SetRarityLimit(int[] limits)
	{
		rarityLimits = limits;
		isWeaponUpdate = true;
		isPoppetUpdate = true;
	}

	public void SetStyleLimit(int[] limits)
	{
		styleLimits = limits;
		isWeaponUpdate = true;
		isPoppetUpdate = true;
	}

	public void SetElementLimit(int[] limits)
	{
		elementLimits = limits;
		isWeaponUpdate = true;
		isPoppetUpdate = true;
	}

	public static bool CheckLimit(int[] limitList, int id)
	{
		int result;
		checked
		{
			if (null == limitList)
			{
				result = 1;
			}
			else if (limitList.Length == 0)
			{
				result = 1;
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int length = limitList.Length;
				while (true)
				{
					if (num2 < length)
					{
						if (limitList[num2] != 0)
						{
							num++;
							if (id == limitList[num2])
							{
								result = 1;
								break;
							}
						}
						num2++;
						continue;
					}
					result = ((num == 0) ? 1 : 0);
					break;
				}
			}
		}
		return (byte)result != 0;
	}

	public bool IsEnableRarity()
	{
		return IsEnableRarity(Poppet.Rare.Id) ? true : false;
	}

	private bool IsEnableRarity(int id)
	{
		return CheckLimit(rarityLimits, id);
	}

	public bool IsEnableElement()
	{
		return IsEnableElement(Poppet.Element.Id) ? true : false;
	}

	private bool IsEnableElement(int id)
	{
		return CheckLimit(elementLimits, id);
	}

	public bool IsEnableStyle()
	{
		return IsEnableStyle(Weapon.Style.Id) ? true : false;
	}

	private bool IsEnableStyle(int id)
	{
		return CheckLimit(styleLimits, id);
	}

	private void UpdateWeapon()
	{
		if (Weapon == null || !isWeaponUpdate)
		{
			return;
		}
		GameObject icon = WeaponIcon;
		WeaponInfo weaponInfo = DeckItemUiBase.setWeaponIcon(ref icon, weaponIconPrefab, weaponIconParent, Weapon);
		WeaponIcon = icon;
		if (null != weaponInfo)
		{
			weaponInfo.SetIconColor(Color.white);
			bool flag = false;
			if (!IsEnableStyle(Weapon.Style.Id))
			{
				flag = true;
			}
			if (flag)
			{
				weaponInfo.SetIconColor(Color.gray);
			}
		}
		if (Weapon.CoverSkill != null)
		{
			UIBasicUtility.SetLabel(wepPsvSkillName, Weapon.CoverSkill.Name.ToString());
			UIBasicUtility.SetLabel(wepPsvSkillLv, UIBasicUtility.SafeFormat(levelFormat, Weapon.CoverSkillLevel));
			if (null != disableWepPsvSkill)
			{
				disableWepPsvSkill.SetActive(Weapon.CoverSkill.DisableColosseum);
			}
		}
		else
		{
			UIBasicUtility.SetLabel(wepPsvSkillName, initSkillString);
			UIBasicUtility.SetLabel(wepPsvSkillLv, string.Empty);
			if (null != disableWepPsvSkill)
			{
				disableWepPsvSkill.SetActive(value: false);
			}
		}
		checked
		{
			int num = (int)DamageCalc.ColosseumPoppetAttackRevise(Poppet, Weapon);
			int num2 = (int)DamageCalc.ColosseumPoppetHPRevise(Poppet, Weapon);
			if (null != wepCostLabel)
			{
				UIBasicUtility.SetLabel(wepCostLabel, Weapon.DeckCost.ToString());
			}
			if (null != wepAtkLabel)
			{
				UIBasicUtility.SetLabel(wepAtkLabel, UIBasicUtility.SafeFormat(wepAtkFormat, num.ToString()));
			}
			if (null != wepHpLabel)
			{
				UIBasicUtility.SetLabel(wepHpLabel, UIBasicUtility.SafeFormat(wepHpFormat, num2.ToString()));
			}
			if (null != wepLvLabel)
			{
				UIBasicUtility.SetLabel(wepLvLabel, Weapon.Level.ToString());
			}
			isWeaponUpdate = false;
		}
	}

	private void UpdagtePoppet()
	{
		if (Poppet == null || !isPoppetUpdate)
		{
			return;
		}
		GameObject icon = PoppetIcon;
		MuppetInfo muppetInfo = DeckItemUiBase.setPoppetIcon(ref icon, poppetIconPrefab, poppetIconParent, Poppet);
		PoppetIcon = icon;
		if (null != muppetInfo)
		{
			muppetInfo.SetIconColor(Color.white);
			bool flag = false;
			if (deckCostOver)
			{
				flag = true;
			}
			if (!IsEnableRarity(Poppet.Rare.Id))
			{
				flag = true;
			}
			if (!IsEnableElement(Poppet.Element.Id))
			{
				flag = true;
			}
			if (flag)
			{
				muppetInfo.SetIconColor(Color.gray);
			}
		}
		if (Poppet.CoverSkill1 != null)
		{
			UIBasicUtility.SetLabel(petPsvSkill1, new StringBuilder().Append(Poppet.CoverSkill1.Name).ToString());
			UIBasicUtility.SetLabel(petPsvSkill1Lv, UIBasicUtility.SafeFormat(levelFormat, Poppet.CoverSkillLevel_1));
			if (null != disablePetPsvSkill1)
			{
				disablePetPsvSkill1.SetActive(Poppet.CoverSkill1.DisableColosseum);
			}
		}
		else
		{
			UIBasicUtility.SetLabel(petPsvSkill1, initSkillString);
			UIBasicUtility.SetLabel(petPsvSkill1Lv, string.Empty);
			if (null != disablePetPsvSkill1)
			{
				disablePetPsvSkill1.SetActive(value: false);
			}
		}
		if (leaderFlag)
		{
			if (Poppet.CoverSkill2 != null)
			{
				UIBasicUtility.SetLabel(petPsvSkill2, new StringBuilder().Append(Poppet.CoverSkill2.Name).ToString());
				UIBasicUtility.SetLabel(petPsvSkill2Lv, UIBasicUtility.SafeFormat(levelFormat, Poppet.CoverSkillLevel_2));
				if (null != disablePetPsvSkill2)
				{
					disablePetPsvSkill2.SetActive(Poppet.CoverSkill2.DisableColosseum);
				}
			}
			else
			{
				UIBasicUtility.SetLabel(petPsvSkill2, initSkillString);
				UIBasicUtility.SetLabel(petPsvSkill2Lv, string.Empty);
				if (null != disablePetPsvSkill2)
				{
					disablePetPsvSkill2.SetActive(value: false);
				}
			}
		}
		else
		{
			if (Poppet.CoverSkill2 != null)
			{
				UIBasicUtility.SetLabel(petPsvSkill2, MTexts.Msg("$COLOSSEUM_LEADER_ONLY"));
			}
			else
			{
				UIBasicUtility.SetLabel(petPsvSkill2, initSkillString);
			}
			UIBasicUtility.SetLabel(petPsvSkill2Lv, string.Empty);
			if (null != disablePetPsvSkill2)
			{
				disablePetPsvSkill2.SetActive(value: false);
			}
		}
		if (Poppet.ChainSkill != null)
		{
			UIBasicUtility.SetLabel(petCombinationSkillName, Poppet.ChainSkill.Name.ToString());
			UIBasicUtility.SetLabel(petCombinationSkillLv, UIBasicUtility.SafeFormat(levelFormat, Poppet.ChainSkillLevel));
			if (null != disablePetCombinationSkill)
			{
				disablePetCombinationSkill.SetActive(Poppet.ChainSkill.DisableColosseum);
			}
		}
		else
		{
			UIBasicUtility.SetLabel(petCombinationSkillName, initSkillString);
			UIBasicUtility.SetLabel(petCombinationSkillLv, string.Empty);
			if (null != disablePetCombinationSkill)
			{
				disablePetCombinationSkill.SetActive(value: false);
			}
		}
		checked
		{
			int num = (int)DamageCalc.ColosseumPoppetAttack(Poppet, Weapon);
			int num2 = (int)DamageCalc.ColosseumPoppetHP(Poppet, Weapon);
			if (null != petCostLabel)
			{
				UIBasicUtility.SetLabel(petCostLabel, Poppet.DeckCost.ToString());
			}
			if (null != petAtkLabel)
			{
				UIBasicUtility.SetLabel(petAtkLabel, UIBasicUtility.SafeFormat(petAtkFormat, num.ToString()));
			}
			if (null != petHpLabel)
			{
				UIBasicUtility.SetLabel(petHpLabel, UIBasicUtility.SafeFormat(petHpFormat, num2.ToString()));
			}
			if (null != petLvLabel)
			{
				UIBasicUtility.SetLabel(petLvLabel, Poppet.Level.ToString());
			}
			isPoppetUpdate = false;
		}
	}

	public void UpdatePetSet()
	{
		UpdateWeapon();
		UpdagtePoppet();
	}
}
