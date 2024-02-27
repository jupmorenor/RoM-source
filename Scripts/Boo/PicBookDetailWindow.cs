using System;
using UnityEngine;

[Serializable]
public class PicBookDetailWindow : MonoBehaviour
{
	private int _LimitBrakeAddLevel;

	public UISprite iconRankTextSprite;

	public UISprite elementSprite;

	public UILabelBase sellPriceLabel;

	public UILabelBase limitBrakeLabel;

	private PicBookData selectedData;

	public UILabelBase attackPlusBonusLabel;

	public UILabelBase hpPlusBonusLabel;

	private int LimitBrakeAddLevel
	{
		get
		{
			if (_LimitBrakeAddLevel == -1)
			{
				_LimitBrakeAddLevel = MGameParameters.findByGameParameterId(9).Param;
			}
			return _LimitBrakeAddLevel;
		}
	}

	public PicBookDetailWindow()
	{
		_LimitBrakeAddLevel = -1;
	}

	public void SetSelectedData(PicBookData selectData)
	{
		selectedData = selectData;
	}

	public void ShowSelectData(PicBookData data)
	{
		if (data.IsWeapon())
		{
			SetWeaponItem(data);
		}
		else if (data.IsPoppet())
		{
			SetPoppetsItem(data);
		}
		else
		{
			SetNoInfo();
		}
	}

	public void SetNoInfo()
	{
		iconRankTextSprite.spriteName = string.Empty;
		sellPriceLabel.text = "------";
	}

	public void SetWeaponItem(PicBookData picBookData)
	{
		MWeapons weapon = picBookData.weapon;
		iconRankTextSprite.spriteName = weapon.Rare.Icon + "_text";
		sellPriceLabel.text = weapon.price(weapon.LevelLimitMax).ToString();
		limitBrakeLabel.text = (checked(weapon.LevelLimitMax - weapon.LevelLimitMin) / LimitBrakeAddLevel).ToString();
		if (weapon.CanPowup())
		{
			attackPlusBonusLabel.text = "( +" + DamageCalc.AttackPlusValue((EnumRares)weapon.Rare.Id, MGameParameters.findByGameParameterId(61).Param) + " )";
			hpPlusBonusLabel.text = "( +" + DamageCalc.HpPlusValue((EnumRares)weapon.Rare.Id, MGameParameters.findByGameParameterId(61).Param) + " )";
		}
		else
		{
			attackPlusBonusLabel.text = string.Empty;
			hpPlusBonusLabel.text = string.Empty;
		}
		UIBasicUtility.SetElementSprite(elementSprite, weapon.MElementId.Id, light: true, show: true);
	}

	public void SetPoppetsItem(PicBookData picBookData)
	{
		MPoppets poppet = picBookData.poppet;
		iconRankTextSprite.spriteName = poppet.Rare.Icon + "_text";
		sellPriceLabel.text = poppet.price(poppet.LevelLimitMax).ToString();
		limitBrakeLabel.text = (checked(poppet.LevelLimitMax - poppet.LevelLimitMin) / LimitBrakeAddLevel).ToString();
		if (poppet.CanPowup())
		{
			attackPlusBonusLabel.text = "( +" + DamageCalc.AttackPlusValue((EnumRares)poppet.Rare.Id, MGameParameters.findByGameParameterId(61).Param) + " )";
			hpPlusBonusLabel.text = "( +" + DamageCalc.HpPlusValue((EnumRares)poppet.Rare.Id, MGameParameters.findByGameParameterId(61).Param) + " )";
		}
		else
		{
			attackPlusBonusLabel.text = string.Empty;
			hpPlusBonusLabel.text = string.Empty;
		}
		UIBasicUtility.SetElementSprite(elementSprite, poppet.MElementId.Id, light: true, show: true);
	}

	public void OnEnable()
	{
		if (selectedData != null)
		{
			SendMessage("ShowSelectData", selectedData);
		}
	}
}
