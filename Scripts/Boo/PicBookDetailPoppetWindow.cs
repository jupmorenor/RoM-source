using System;
using UnityEngine;

[Serializable]
public class PicBookDetailPoppetWindow : MonoBehaviour
{
	public UILabelBase raceLabel;

	public UISprite weakStyleIcon;

	public UILabelBase weakStyleNoneLabel;

	public UILabelBase chainSkillDetailLabel;

	public UILabelBase chainSkillValueLabel;

	public UILabelBase coverSkill1DetailLabel;

	public UILabelBase coverSkill2DetailLabel;

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
		raceLabel.text = "-----";
		weakStyleNoneLabel.gameObject.SetActive(value: false);
		weakStyleIcon.gameObject.SetActive(value: false);
		chainSkillDetailLabel.text = string.Empty;
		coverSkill1DetailLabel.text = string.Empty;
		coverSkill2DetailLabel.text = string.Empty;
	}

	public void SetPoppetsItem(PicBookData picBookData)
	{
		MPoppets poppet = picBookData.poppet;
		raceLabel.text = poppet.MRaceId.Name.msg;
		EnumStyles weakStyle = poppet.Monster.WeakStyle;
		bool flag = weakStyle == EnumStyles.None;
		weakStyleNoneLabel.gameObject.SetActive(flag);
		UIBasicUtility.SetStyleSprite(weakStyleIcon, (int)weakStyle, light: true, !flag);
		chainSkillDetailLabel.text = MasterExtensionsModule.MultiDetail(poppet.ChainSkillId);
		chainSkillValueLabel.text = $"必要魔力：{checked((int)poppet.ChainSkillId.getEffectValue(poppet.ChainSkillId.LevelMax))}";
		if (poppet.CoverSkillId_1 == null)
		{
			coverSkill1DetailLabel.text = string.Empty;
		}
		else
		{
			coverSkill1DetailLabel.text = MasterExtensionsModule.MultiDetail(poppet.CoverSkillId_1, poppet.CoverSkillId_1.LevelMax);
		}
		if (poppet.CoverSkillId_2 == null)
		{
			coverSkill2DetailLabel.text = string.Empty;
		}
		else
		{
			coverSkill2DetailLabel.text = MasterExtensionsModule.MultiDetail(poppet.CoverSkillId_2, poppet.CoverSkillId_2.LevelMax);
		}
	}
}
