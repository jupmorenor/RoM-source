using System;
using UnityEngine;

[Serializable]
public class PicBookInfoPoppetWindow : MonoBehaviour
{
	public UILabelBase chainSkillLabel;

	public UILabelBase chainSkillLvLabel;

	public UILabelBase coverSkill1Label;

	public UILabelBase coverSkill1LvLabel;

	public UILabelBase coverSkill2Label;

	public UILabelBase coverSkill2LvLabel;

	public void ShowSelectData(PicBookData data)
	{
		if (data.IsPoppet())
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
		chainSkillLabel.text = "無し";
		chainSkillLvLabel.text = string.Empty;
		coverSkill1Label.text = "無し";
		coverSkill1LvLabel.text = string.Empty;
		coverSkill2Label.text = "無し";
		coverSkill2LvLabel.text = string.Empty;
	}

	public void SetPoppetsItem(PicBookData picBookData)
	{
		MPoppets poppet = picBookData.poppet;
		chainSkillLabel.text = poppet.ChainSkillId.Name.msg;
		chainSkillLvLabel.text = "lv" + poppet.ChainSkillId.LevelMax;
		if (poppet.CoverSkillId_1 == null)
		{
			coverSkill1Label.text = "無し";
			coverSkill1LvLabel.text = string.Empty;
		}
		else
		{
			coverSkill1Label.text = poppet.CoverSkillId_1.Name.msg;
			coverSkill1LvLabel.text = "lv" + poppet.CoverSkillId_1.LevelMax;
		}
		if (poppet.CoverSkillId_2 == null)
		{
			coverSkill2Label.text = "無し";
			coverSkill2LvLabel.text = string.Empty;
		}
		else
		{
			coverSkill2Label.text = poppet.CoverSkillId_2.Name.msg;
			coverSkill2LvLabel.text = "lv" + poppet.CoverSkillId_2.LevelMax;
		}
	}
}
