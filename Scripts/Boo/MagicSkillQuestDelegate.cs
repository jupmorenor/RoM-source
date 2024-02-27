using System;

[Serializable]
public class MagicSkillQuestDelegate : MagicSkillDelegate
{
	private int mapetNum;

	private PlayerControl playerControl => PlayerControl.CurrentPlayer;

	public MagicSkillQuestDelegate()
	{
		mapetNum = -1;
	}

	public override bool canUseSkill(MagicSkill magicSkill)
	{
		int num;
		if (NageManager.Instance.isEntried(magicSkill.PoppetAI))
		{
			num = 0;
		}
		else if (playerControl != null && playerControl.IsChainDisabledByAbnormalState)
		{
			num = 0;
		}
		else
		{
			num = (GameParameter.renkeiFree ? 1 : 0);
			if (num == 0)
			{
				num = (magicSkill.IsFullCharge ? 1 : 0);
			}
		}
		return (byte)num != 0;
	}

	public override void useSkill(MagicSkill magicSkill)
	{
		if (mapetNum >= 0 && playerControl != null)
		{
			if (mapetNum == 0)
			{
				playerControl.ActionInput.chainMySkill();
			}
			else
			{
				playerControl.ActionInput.chainFriendSkill();
			}
		}
	}

	public override void setPoppetIndexOfPlayer(MagicSkill magicSkill, int index)
	{
		mapetNum = index;
	}

	public override void magicPointChanged(MagicSkill magicSkill)
	{
		updateMagicGauge(magicSkill);
	}

	public override void magicPointFullCharged(MagicSkill magicSkill)
	{
		fullChargeAnimAndSound();
	}

	public override void start(MagicSkill magicSkill)
	{
		updateMagicGauge(magicSkill);
	}

	public override void update(MagicSkill magicSkill)
	{
		updateMagicGauge(magicSkill);
		updateMagicGaugeAnim(magicSkill);
	}

	private void updateMagicGauge(MagicSkill magicSkill)
	{
		float magicPoint = magicSkill.MagicPoint;
		float maxMagicPoint = magicSkill.MaxMagicPoint;
		MagicGauge magicGauge = BattleHUD.GetMagicGauge(mapetNum);
		checked
		{
			if (magicGauge != null && magicGauge != null)
			{
				magicGauge.setMagic((int)magicPoint, (int)maxMagicPoint);
			}
		}
	}

	private void updateMagicGaugeAnim(MagicSkill magicSkill)
	{
		float magicPoint = magicSkill.MagicPoint;
		float maxMagicPoint = magicSkill.MaxMagicPoint;
		MagicGauge magicGauge = BattleHUD.GetMagicGauge(mapetNum);
		if (magicGauge != null)
		{
			if (!(magicSkill.PoppetAI.HitPoint > 0f))
			{
				magicGauge.flash = MagicGauge.Flash.Dead;
			}
			else
			{
				magicGauge.flash = MagicGauge.Flash.None;
			}
			magicGauge.setFullMode(!(magicPoint < maxMagicPoint));
		}
	}

	private void fullChargeAnimAndSound()
	{
		BattleHUDMappet.RechargeGaugeAnimation(mapetNum);
		if (playerControl != null)
		{
			playerControl.playSE(SQEX_SoundPlayerData.SE.combination_ready);
		}
	}
}
