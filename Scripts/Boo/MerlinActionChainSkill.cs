using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MerlinActionChainSkill : MerlinActionSkillCommandBase
{
	private float timeStep;

	private bool enabled;

	private float timer;

	public float TimeStep
	{
		get
		{
			return timeStep;
		}
		set
		{
			timeStep = value;
		}
	}

	public MerlinActionChainSkill(RespPoppet poppet)
	{
		if (poppet != null && poppet.ChainSkill != null)
		{
			MChainSkills chainSkill = poppet.ChainSkill;
			base._002Ector(chainSkill.SkillEffect, poppet.ChainSkillLevel, chainSkill.LevelMax);
			enabled = true;
		}
	}

	public override bool doStart()
	{
		if (!enabled)
		{
		}
		return false;
	}

	public override void doUpdateInTime()
	{
		int num = skillEffect.MSkillEffectTypeId.Id;
		timer += Time.deltaTime;
		bool flag = timer > timeStep;
		if (flag)
		{
			timer = 0f;
		}
		if (num == 61)
		{
			updateDamageToAllEnemies(flag);
		}
	}

	public override bool doEnd()
	{
		if (!enabled)
		{
		}
		return false;
	}

	private void updateDamageToAllEnemies(bool ticked)
	{
		if (!ticked)
		{
			return;
		}
		float num = effectValue();
		int i = 0;
		AIControl[] array = (AIControl[])UnityEngine.Object.FindObjectsOfType(typeof(AIControl));
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (!(array[i].HitPoint <= 0f) && !(array[i].tag != "Enemy"))
				{
					array[i].HitAttack((int)num, YarareTypes.Down, ParentGameObject);
					DamageDisplay.DrawByType(array[i].transform.position, (int)num, DamageDisplay.Type.Critical);
				}
			}
		}
	}
}
