using System;
using UnityEngine;

[Serializable]
public class PicBookInfoWindow : MonoBehaviour
{
	public UILabelBase nameLabel;

	public UISprite itemSprite;

	public UILabelBase levelLabel;

	public UILabelBase attackLabel;

	public UILabelBase hpLabel;

	public UILabelBase supoortAttack;

	public UILabelBase supoortAttackWithBonus;

	public UILabelBase supoortHp;

	public UILabelBase supoortHpWithBonus;

	public UISprite supportElementIconNotMatch;

	public UISprite supportElementIcon;

	public UILabelBase deckCostLabel;

	public UIButtonMessage modelButton;

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
		nameLabel.text = "--------";
		itemSprite.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(itemSprite, "P_none", delegate(UIAtlas atlas)
		{
			itemSprite.gameObject.SetActive(atlas != null);
		});
		levelLabel.text = "--";
		attackLabel.text = "---";
		hpLabel.text = "---";
		supoortAttackWithBonus.text = "---";
		supoortAttack.text = "---";
		supoortHpWithBonus.text = "---";
		supoortHp.text = "---";
		supportElementIconNotMatch.gameObject.SetActive(value: false);
		supportElementIcon.gameObject.SetActive(value: false);
		deckCostLabel.text = "--";
		ButtonsActive(active: false);
	}

	public void SetWeaponItem(PicBookData picBookData)
	{
		MWeapons weapon = picBookData.weapon;
		nameLabel.text = UIBasicUtility.GetItemNameAddID(weapon.Name, weapon.Id);
		itemSprite.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(itemSprite, weapon.Icon, delegate(UIAtlas atlas)
		{
			itemSprite.gameObject.SetActive(atlas != null);
		});
		int levelLimitMax = weapon.LevelLimitMax;
		levelLabel.text = levelLimitMax.ToString();
		DamageCalc.BonusValue bonus = picBookData.GetBonus();
		checked
		{
			int num = picBookData.GetAttack() + bonus.attack;
			int num2 = picBookData.GetHp() + bonus.hp;
			attackLabel.text = num.ToString();
			hpLabel.text = num2.ToString();
			supoortAttackWithBonus.text = DamageCalc.SupportWeaponReviseValue(num, weapon.Cost, styleCoincide: true, elementCoincide: true).ToString();
			supoortAttack.text = DamageCalc.SupportWeaponReviseValue(num, weapon.Cost, styleCoincide: false, elementCoincide: false).ToString();
			supoortHpWithBonus.text = DamageCalc.SupportWeaponReviseValue(num2, weapon.Cost, styleCoincide: true, elementCoincide: true).ToString();
			supoortHp.text = DamageCalc.SupportWeaponReviseValue(num2, weapon.Cost, styleCoincide: false, elementCoincide: false).ToString();
			UIBasicUtility.SetElementSprite(supportElementIconNotMatch, weapon.MElementId.Id, light: false, show: true);
			UIBasicUtility.SetElementSprite(supportElementIcon, weapon.MElementId.Id, light: true, show: true);
			if (deckCostLabel != null)
			{
				deckCostLabel.text = weapon.DeckCost.ToString();
			}
			ButtonsActive(active: true);
			ButtonValid(picBookData.IsHave());
		}
	}

	public void SetPoppetsItem(PicBookData picBookData)
	{
		MPoppets poppet = picBookData.poppet;
		nameLabel.text = UIBasicUtility.GetItemNameAddID(poppet.Name, poppet.Id);
		itemSprite.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(itemSprite, poppet.Icon, delegate(UIAtlas atlas)
		{
			itemSprite.gameObject.SetActive(atlas != null);
		});
		int levelLimitMax = poppet.LevelLimitMax;
		levelLabel.text = levelLimitMax.ToString();
		DamageCalc.BonusValue bonus = picBookData.GetBonus();
		checked
		{
			int num = picBookData.GetAttack() + bonus.attack;
			int num2 = picBookData.GetHp() + bonus.hp;
			attackLabel.text = num.ToString();
			hpLabel.text = num2.ToString();
			supoortAttackWithBonus.text = DamageCalc.PoppetReviceValue(num, poppet.Cost, elementCoincide: true).ToString();
			supoortAttack.text = DamageCalc.PoppetReviceValue(num, poppet.Cost, elementCoincide: false).ToString();
			supoortHpWithBonus.text = DamageCalc.PoppetReviceValue(num2, poppet.Cost, elementCoincide: true).ToString();
			supoortHp.text = DamageCalc.PoppetReviceValue(num2, poppet.Cost, elementCoincide: false).ToString();
			UIBasicUtility.SetElementSprite(supportElementIconNotMatch, poppet.MElementId.Id, light: false, show: true);
			UIBasicUtility.SetElementSprite(supportElementIcon, poppet.MElementId.Id, light: true, show: true);
			if (deckCostLabel != null)
			{
				deckCostLabel.text = poppet.DeckCost.ToString();
			}
			ButtonsActive(active: true);
			ButtonValid(picBookData.IsHave());
		}
	}

	public void ButtonsActive(bool active)
	{
		if (modelButton != null)
		{
			modelButton.gameObject.SetActive(active);
		}
	}

	public void ButtonValid(bool valid)
	{
		if (modelButton != null)
		{
			modelButton.enabled = valid;
			modelButton.SendMessage("SetValidColor", valid);
		}
	}

	internal void _0024SetNoInfo_0024closure_00245070(UIAtlas atlas)
	{
		itemSprite.gameObject.SetActive(atlas != null);
	}

	internal void _0024SetWeaponItem_0024closure_00245071(UIAtlas atlas)
	{
		itemSprite.gameObject.SetActive(atlas != null);
	}

	internal void _0024SetPoppetsItem_0024closure_00245072(UIAtlas atlas)
	{
		itemSprite.gameObject.SetActive(atlas != null);
	}
}
