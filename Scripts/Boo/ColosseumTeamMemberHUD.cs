using System;
using UnityEngine;

[Serializable]
public class ColosseumTeamMemberHUD : MonoBehaviour
{
	private ColosseumTeamMember teamMember;

	public SpriteFillGauge hpGauge;

	public MagicGauge magicGauge;

	public UISprite elementIcon;

	public void Init(ColosseumTeamMember setTeamMember)
	{
		teamMember = setTeamMember;
		if (teamMember == null)
		{
			SetNoData();
			return;
		}
		magicGauge.setFaceIcon(teamMember.PoppetData);
		SetElementIcon();
	}

	public void SetNoData()
	{
		gameObject.SetActive(value: false);
	}

	public void Update()
	{
		if (teamMember == null)
		{
			return;
		}
		hpGauge.updateGauge(teamMember.HitPointRate);
		if (teamMember.IsDead)
		{
			magicGauge.flash = MagicGauge.Flash.Dead;
		}
		else if (ChainSkillRoutine.IsPlayingMotion)
		{
			if (ChainSkillRoutine.IsPlayingPoppet(teamMember.aiControl))
			{
				magicGauge.flash = MagicGauge.Flash.None;
			}
			else
			{
				magicGauge.flash = MagicGauge.Flash.Dead;
			}
		}
		else
		{
			magicGauge.flash = MagicGauge.Flash.None;
		}
		checked
		{
			magicGauge.setMagic((int)teamMember.MagicPoint, (int)teamMember.MaxMagicPoint);
		}
	}

	public bool IsIconLoaded()
	{
		return magicGauge.faceIcon.mainTexture != null;
	}

	private void SetElementIcon()
	{
		if (elementIcon != null)
		{
			elementIcon.spriteName = teamMember.PoppetData.ElementMainIcon;
		}
	}
}
