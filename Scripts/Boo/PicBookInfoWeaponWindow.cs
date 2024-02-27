using System;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class PicBookInfoWeaponWindow : MonoBehaviour
{
	public UILabelBase angelSkillLabel;

	public UILabelBase angelSkillLvLabel;

	public UISprite angelSkillIcon;

	public UILabelBase demonSkillLabel;

	public UILabelBase demonSkillLvLabel;

	public UISprite demonSkillIcon;

	public UILabelBase coverSkillLabel;

	public UILabelBase coverSkillLvLabel;

	public UISprite supportStyleIconNoMatch;

	public UISprite supportStyleIcon;

	public void ShowSelectData(PicBookData data)
	{
		if (data.IsWeapon())
		{
			SetWeaponItem(data);
		}
		else
		{
			SetNoInfo();
		}
	}

	public void SetNoInfo()
	{
		angelSkillLabel.text = "無し";
		angelSkillLvLabel.text = string.Empty;
		angelSkillIcon.gameObject.SetActive(value: false);
		demonSkillLabel.text = "無し";
		demonSkillLvLabel.text = string.Empty;
		demonSkillIcon.gameObject.SetActive(value: false);
		coverSkillLabel.text = "無し";
		coverSkillLvLabel.text = string.Empty;
		supportStyleIconNoMatch.gameObject.SetActive(value: false);
		supportStyleIcon.gameObject.SetActive(value: false);
	}

	public void SetWeaponItem(PicBookData picBookData)
	{
		MWeapons weapon = picBookData.weapon;
		UIBasicUtility.SetStyleSprite(supportStyleIconNoMatch, weapon.MStyleId.Id, light: false, show: true);
		UIBasicUtility.SetStyleSprite(supportStyleIcon, weapon.MStyleId.Id, light: true, show: true);
		angelSkillLabel.text = weapon.AngelSkillId.Name.msg;
		angelSkillLvLabel.text = "lv" + weapon.AngelSkillId.LevelMax;
		angelSkillIcon.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(angelSkillIcon, weapon.AngelSkillId.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(delegate(object atlas)
		{
			angelSkillIcon.gameObject.SetActive(atlas != null);
		}));
		demonSkillLabel.text = weapon.DemonSkillId.Name.msg;
		demonSkillLvLabel.text = "lv" + weapon.DemonSkillId.LevelMax;
		demonSkillIcon.gameObject.SetActive(value: false);
		IconAtlasPool.SetSprite(demonSkillIcon, weapon.DemonSkillId.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(delegate(object atlas)
		{
			demonSkillIcon.gameObject.SetActive(atlas != null);
		}));
		if (weapon.CoverSkillId == null)
		{
			coverSkillLabel.text = "無し";
			coverSkillLvLabel.text = string.Empty;
		}
		else
		{
			coverSkillLabel.text = weapon.CoverSkillId.Name.msg;
			coverSkillLvLabel.text = "lv" + weapon.CoverSkillId.LevelMax;
		}
	}

	internal void _0024SetWeaponItem_0024closure_00245068(object atlas)
	{
		angelSkillIcon.gameObject.SetActive(atlas != null);
	}

	internal void _0024SetWeaponItem_0024closure_00245069(object atlas)
	{
		demonSkillIcon.gameObject.SetActive(atlas != null);
	}
}
