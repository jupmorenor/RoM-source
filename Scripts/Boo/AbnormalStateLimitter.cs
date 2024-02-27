using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class AbnormalStateLimitter
{
	[Serializable]
	public class Infection
	{
		private float cumulation;

		private float tolerance;

		public bool IsIll => !(cumulation < tolerance);

		public float Cumulation => cumulation;

		public float Tolerance
		{
			get
			{
				return tolerance;
			}
			set
			{
				tolerance = value;
			}
		}

		public void reset()
		{
			cumulation = 0f;
		}

		public void accumulate(float power)
		{
			cumulation += power;
		}

		public void infectAndReset()
		{
			cumulation = 0f;
			tolerance *= 1.5f;
			tolerance = Mathf.Floor(tolerance);
		}

		public void restore(float dt)
		{
			cumulation -= dt * 0f;
			if (!(cumulation >= 0f))
			{
				cumulation = 0f;
			}
		}
	}

	private MMonsters monsterMaster;

	private Infection[] infections;

	public AbnormalStateLimitter()
	{
		infections = new Infection[10];
		int num = 0;
		int length = infections.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Infection[] array = infections;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = new Infection();
		}
	}

	private void resetByMonsterMaster(MMonsters _monsterMaster)
	{
		int num = 0;
		int length = infections.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Infection[] array = infections;
			array[RuntimeServices.NormalizeArrayIndex(array, index)].reset();
		}
		monsterMaster = _monsterMaster;
		if (monsterMaster != null)
		{
			Infection[] array2 = infections;
			array2[RuntimeServices.NormalizeArrayIndex(array2, 0)].Tolerance = 0f;
			Infection[] array3 = infections;
			array3[RuntimeServices.NormalizeArrayIndex(array3, 1)].Tolerance = monsterMaster.Poison;
			Infection[] array4 = infections;
			array4[RuntimeServices.NormalizeArrayIndex(array4, 2)].Tolerance = monsterMaster.Conflict;
			Infection[] array5 = infections;
			array5[RuntimeServices.NormalizeArrayIndex(array5, 3)].Tolerance = monsterMaster.Stun;
			Infection[] array6 = infections;
			array6[RuntimeServices.NormalizeArrayIndex(array6, 4)].Tolerance = monsterMaster.Slow;
			Infection[] array7 = infections;
			array7[RuntimeServices.NormalizeArrayIndex(array7, 5)].Tolerance = monsterMaster.Blind;
			Infection[] array8 = infections;
			array8[RuntimeServices.NormalizeArrayIndex(array8, 6)].Tolerance = monsterMaster.Burn;
			Infection[] array9 = infections;
			array9[RuntimeServices.NormalizeArrayIndex(array9, 7)].Tolerance = monsterMaster.Hate;
			Infection[] array10 = infections;
			array10[RuntimeServices.NormalizeArrayIndex(array10, 8)].Tolerance = monsterMaster.Small;
			Infection[] array11 = infections;
			array11[RuntimeServices.NormalizeArrayIndex(array11, 9)].Tolerance = monsterMaster.Freeze;
		}
	}

	public void reset()
	{
		resetByMonsterMaster(monsterMaster);
	}

	public void reset(MMonsters _monsterMaster)
	{
		resetByMonsterMaster(_monsterMaster);
	}

	public void reset(RespPoppet poppet)
	{
		if (poppet != null)
		{
			resetByMonsterMaster(poppet.MonsterMaster);
		}
		else
		{
			resetByMonsterMaster(null);
		}
	}

	public void reset(RespMonster monster)
	{
		if (monster != null)
		{
			resetByMonsterMaster(monster.Master);
		}
		else
		{
			resetByMonsterMaster(null);
		}
	}

	public void update(float dt)
	{
		int num = 0;
		int length = infections.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			Infection[] array = infections;
			array[RuntimeServices.NormalizeArrayIndex(array, index)].restore(dt);
		}
	}

	public void updateInfection(EnumAbnormalStates e, int infectionPower)
	{
		if (EnumAbnormalStates.None <= e && (int)e < infections.Length)
		{
			Infection[] array = infections;
			array[RuntimeServices.NormalizeArrayIndex(array, (int)e)].accumulate(infectionPower);
		}
	}

	public bool isIll(EnumAbnormalStates e)
	{
		int result;
		if (EnumAbnormalStates.None <= e && (int)e < infections.Length)
		{
			Infection[] array = infections;
			result = (array[RuntimeServices.NormalizeArrayIndex(array, (int)e)].IsIll ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public void infectAndReset(EnumAbnormalStates e)
	{
		if (EnumAbnormalStates.None <= e && (int)e < infections.Length)
		{
			Infection[] array = infections;
			array[RuntimeServices.NormalizeArrayIndex(array, (int)e)].infectAndReset();
		}
	}

	public string getDebugInfo(EnumAbnormalStates e)
	{
		string result;
		if (EnumAbnormalStates.None <= e && (int)e < infections.Length)
		{
			Infection[] array = infections;
			Infection infection = array[RuntimeServices.NormalizeArrayIndex(array, (int)e)];
			result = new StringBuilder().Append(e).Append(": ").Append(infection.Cumulation)
				.Append("/")
				.Append(infection.Tolerance)
				.ToString();
		}
		else
		{
			result = new StringBuilder("unknown abnormal state: ").Append(e).ToString();
		}
		return result;
	}
}
