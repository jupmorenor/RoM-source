using System;
using UnityEngine;

[Serializable]
public class PicBookDetailWeaponWindow : MonoBehaviour
{
	public UISprite styleIcon;

	public UILabelBase angelSkillDetailLabel;

	public UILabelBase angelSkillCooldownLabel;

	public UILabelBase demonSkillDetailLabel;

	public UILabelBase demonSkillCooldownLabel;

	public UILabelBase coverSkillDetailLabel;

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
		styleIcon.gameObject.SetActive(value: false);
		angelSkillDetailLabel.text = string.Empty;
		angelSkillCooldownLabel.text = string.Empty;
		demonSkillCooldownLabel.text = string.Empty;
		coverSkillDetailLabel.text = string.Empty;
	}

	public void SetWeaponItem(PicBookData picBookData)
	{
		MWeapons weapon = picBookData.weapon;
		UIBasicUtility.SetStyleSprite(styleIcon, weapon.MStyleId.Id, light: true, show: true);
		angelSkillDetailLabel.text = MasterExtensionsModule.MultiDetail(weapon.AngelSkillId);
		angelSkillCooldownLabel.text = $"クールダウン：{weapon.AngelSkillId.CurrentCoolDown(weapon.AngelSkillId.LevelMax):F1}秒";
		demonSkillDetailLabel.text = MasterExtensionsModule.MultiDetail(weapon.DemonSkillId);
		demonSkillCooldownLabel.text = $"クールダウン：{weapon.DemonSkillId.CurrentCoolDown(weapon.DemonSkillId.LevelMax):F1}秒";
		if (weapon.CoverSkillId == null)
		{
			coverSkillDetailLabel.text = string.Empty;
		}
		else
		{
			coverSkillDetailLabel.text = MasterExtensionsModule.MultiDetail(weapon.CoverSkillId, weapon.CoverSkillId.LevelMax);
		}
	}
}
