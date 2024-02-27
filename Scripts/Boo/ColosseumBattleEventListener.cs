using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class ColosseumBattleEventListener : PlayerEventAdapter
{
	private ColosseumTeam[] teams;

	private ColosseumBattleResult result;

	public void setTeams(ColosseumTeam[] _teams)
	{
		if (!(_teams == null) && _teams.Length != 2)
		{
			throw new AssertionFailedException("(_teams == null) or (len(_teams) == 2)");
		}
		teams = _teams;
	}

	public void setUpdateResult(ColosseumBattleResult _result)
	{
		result = _result;
	}

	public override void eventPoppetDamage(MerlinActionControl _atk, MerlinActionControl _dfs, float damage)
	{
		AIControl atk = _atk as AIControl;
		AIControl aIControl = _dfs as AIControl;
		if (!aIControl.IsDead)
		{
			addMagicPointByHit(atk, aIControl, damage);
			updateDamage(atk, damage);
		}
	}

	public override void eventPoppetDown(MerlinActionControl _atk, MerlinActionControl _dfs, float damage)
	{
		AIControl atk = _atk as AIControl;
		AIControl aIControl = _dfs as AIControl;
		if (!aIControl.IsDead)
		{
			addMagicPointByHit(atk, aIControl, damage);
			updateDamage(atk, damage);
		}
	}

	public override void eventPoppetFinish(MerlinActionControl _atk, MerlinActionControl _dfs, float damage)
	{
		AIControl atk = _atk as AIControl;
		AIControl dfs = _dfs as AIControl;
		addMagicPointByKill(dfs, damage);
		updateDamage(atk, damage);
	}

	private void addMagicPointByHit(AIControl atk, AIControl dfs, float damage)
	{
		if (atk != null)
		{
			MagicPointCalc.ColosseumHitToEnemy(atk, dfs, damage);
		}
		if (dfs != null)
		{
			MagicPointCalc.ColosseumHitToMe(atk, dfs, damage);
		}
	}

	private void addMagicPointByKill(AIControl dfs, float damage)
	{
		if (dfs != null)
		{
			eachMember(dfs, delegate(AIControl mem)
			{
				MagicPointCalc.ColosseumTeammateKilled(mem);
			});
		}
	}

	private void eachMember(AIControl m, __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ c)
	{
		if (c == null || m == null)
		{
			return;
		}
		ColosseumTeam team = getTeam(m);
		int num = 0;
		int memberNum = team.MemberNum;
		if (memberNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < memberNum)
		{
			int index = num;
			num++;
			AIControl aiControl = team.getMember(index).aiControl;
			if (aiControl != null)
			{
				c(aiControl);
			}
		}
	}

	private ColosseumTeam getTeam(MerlinActionControl ch)
	{
		object obj;
		if (teams == null)
		{
			obj = null;
		}
		else
		{
			int num = 0;
			int length = teams.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (true)
			{
				if (num < length)
				{
					int index = num;
					num++;
					ColosseumTeam[] array = teams;
					if (array[RuntimeServices.NormalizeArrayIndex(array, index)].contains((AIControl)ch))
					{
						ColosseumTeam[] array2 = teams;
						obj = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
						break;
					}
					continue;
				}
				obj = null;
				break;
			}
		}
		return (ColosseumTeam)obj;
	}

	private void updateDamage(AIControl atk, float damage)
	{
		checked
		{
			if (result != null && !(atk == null))
			{
				if (atk.IsPlayer)
				{
					result.totalGivenDamage = (int)((float)result.totalGivenDamage + damage);
					result.maxGivenDamage = (int)Mathf.Max(damage, result.maxGivenDamage);
				}
				else
				{
					result.totalDamage = (int)((float)result.totalDamage + damage);
					result.maxDamage = (int)Mathf.Max(damage, result.maxDamage);
				}
			}
		}
	}

	internal void _0024addMagicPointByKill_0024closure_00244382(AIControl mem)
	{
		MagicPointCalc.ColosseumTeammateKilled(mem);
	}
}
