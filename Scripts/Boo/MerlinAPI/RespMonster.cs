using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class RespMonster : JsonBase
{
	[Serializable]
	internal class _0024getRewards_0024locals_002414456
	{
		internal EnumMasterTypeValues _0024types;
	}

	[Serializable]
	internal class _0024getRewards_0024closure_00244031
	{
		internal _0024getRewards_0024locals_002414456 _0024_0024locals_002415010;

		public _0024getRewards_0024closure_00244031(_0024getRewards_0024locals_002414456 _0024_0024locals_002415010)
		{
			this._0024_0024locals_002415010 = _0024_0024locals_002415010;
		}

		public bool Invoke(RespSimpleReward r)
		{
			return r.TypeValue == (int)_0024_0024locals_002415010._0024types;
		}
	}

	public int Exp;

	public int Coin;

	public int Id;

	public bool IsKill;

	public int Level;

	public int MonsterId;

	public RespSimpleReward[] Rewards;

	public int No;

	private MElements temporaryElement;

	private float _attackAdjMult;

	private float _attackAdjPlus;

	private float _hpAdjMult;

	private float _hpAdjPlus;

	private float _defenseAdjMult;

	private float _defenseAdjPlus;

	public int[] AllRewardId => (!(Rewards == null)) ? ArrayMapMain.RespsToInts(Rewards, (RespSimpleReward r) => r.Id) : new int[0];

	public int RewardNum => (!(Rewards == null)) ? Rewards.Length : 0;

	public MMonsters Master => MMonsters.Get(MonsterId);

	public int MasterId => Master?.Id ?? 0;

	public MStageMonsters StageMonsterMaster => MStageMonsters.Get(Id);

	public bool DestroyIfKilled
	{
		get
		{
			MStageMonsters stageMonsterMaster = StageMonsterMaster;
			bool num = stageMonsterMaster == null;
			if (!num)
			{
				num = !stageMonsterMaster.DontDestroyIfDead;
			}
			return num;
		}
	}

	public bool IsElite => StageMonsterMaster?.IsElite ?? false;

	public bool IsBoss
	{
		get
		{
			MStageMonsters stageMonsterMaster = StageMonsterMaster;
			bool num = stageMonsterMaster != null;
			if (num)
			{
				num = stageMonsterMaster.IsBoss != 0;
			}
			return num;
		}
	}

	public EnumStyles WeakStyle => Master?.WeakStyle ?? EnumStyles.None;

	public bool HasMaster => Master != null;

	public string Name => (Master == null) ? "<unknown monster>" : new StringBuilder().Append(Master.Name).ToString();

	public MElements Element => (temporaryElement == null) ? Master.MElementId : temporaryElement;

	public string ElementMainIcon => (Element == null) ? string.Empty : Element.MainIcon;

	public MRaces Race => Master.MRaceId;

	public MRares Rare
	{
		get
		{
			int id = Master.Id;
			return MPoppets.Get(id).Rare;
		}
	}

	public int PopStep => StageMonsterMaster?.PopStep ?? 0;

	public int RewardCoinTotal
	{
		get
		{
			int num = 0;
			int i = 0;
			RespSimpleReward[] rewards = getRewards(EnumMasterTypeValues.Coin);
			checked
			{
				for (int length = rewards.Length; i < length; i++)
				{
					num += rewards[i].Quantity;
				}
				return num;
			}
		}
	}

	public RespSimpleReward[] RewardCoins => getRewards(EnumMasterTypeValues.Coin);

	public RespSimpleReward[] RewardExps => getRewards(EnumMasterTypeValues.Exp);

	public bool HasCandy => getRewards(EnumMasterTypeValues.Candy).Length > 0;

	public RespSimpleReward[] RewardWeapons => getRewards(EnumMasterTypeValues.Weapon);

	public RespSimpleReward[] RewardTreasureBoxedDrops => (RespSimpleReward[])RuntimeServices.AddArrays(typeof(RespSimpleReward), RewardWeapons, RewardPoppets);

	public RespSimpleReward[] RewardPoppets => getRewards(EnumMasterTypeValues.Poppet);

	public MWeapons[] RewardWeaponMasters => ArrayMapMain.RewardsToWeapons(RewardWeapons);

	public MPoppets[] RewardPoppetMasters => ArrayMapMain.RewardsToPoppets(RewardPoppets);

	public float LevelUpExp => Master.exp(checked(Level + 1));

	public int Attack
	{
		get
		{
			if (!(_attackAdjMult > 0f))
			{
			}
			return checked((int)((float)Master.attack(Level) * _attackAdjMult + _attackAdjPlus));
		}
	}

	public int Hp
	{
		get
		{
			if (!(_hpAdjMult > 0f))
			{
			}
			return checked((int)((float)Master.hp(Level) * _hpAdjMult + _hpAdjPlus));
		}
	}

	public int Critical => Master.critical(Level);

	public int BreakPow => Master.breakPow(Level);

	public int Resist => (!IsElite) ? Master.resist(Level) : checked((int)Master.eliteResist(Level));

	public int Defense
	{
		get
		{
			if (!(_defenseAdjMult > 0f))
			{
			}
			return checked((int)((float)Master.defense(Level) * _defenseAdjMult + _defenseAdjPlus));
		}
	}

	public float AttackAdjMult
	{
		get
		{
			return _attackAdjMult;
		}
		set
		{
			_attackAdjMult = value;
		}
	}

	public float AttackAdjPlus
	{
		get
		{
			return _attackAdjPlus;
		}
		set
		{
			_attackAdjPlus = value;
		}
	}

	public float HpAdjMult
	{
		get
		{
			return _hpAdjMult;
		}
		set
		{
			_hpAdjMult = value;
		}
	}

	public float HpAdjPlus
	{
		get
		{
			return _hpAdjPlus;
		}
		set
		{
			_hpAdjPlus = value;
		}
	}

	public float DefenseAdjMult
	{
		get
		{
			return _defenseAdjMult;
		}
		set
		{
			_defenseAdjMult = value;
		}
	}

	public float DefenseAdjPlus
	{
		get
		{
			return _defenseAdjPlus;
		}
		set
		{
			_defenseAdjPlus = value;
		}
	}

	public RespMonster()
	{
		Level = 1;
		_attackAdjMult = 1f;
		_hpAdjMult = 1f;
		_defenseAdjMult = 1f;
	}

	public RespReward[] getReward()
	{
		return RespReward.FromSimpleRewardList(Rewards);
	}

	public static RespMonster FromMasterId(int mstId)
	{
		RespMonster respMonster = new RespMonster();
		respMonster.MonsterId = mstId;
		respMonster.Rewards = new RespSimpleReward[0];
		return respMonster;
	}

	public static RespMonster FromMaster(MMonsters mst)
	{
		if (mst == null)
		{
			throw new AssertionFailedException("mst != null");
		}
		RespMonster respMonster = new RespMonster();
		respMonster.MonsterId = mst.Id;
		respMonster.Rewards = new RespSimpleReward[0];
		return respMonster;
	}

	public static RespMonster[] FromStageMonster(MStageMonsters smon)
	{
		System.Collections.Generic.List<RespMonster> list = new System.Collections.Generic.List<RespMonster>();
		int num = 0;
		int quantity = smon.Quantity;
		if (quantity < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < quantity)
		{
			int num2 = num;
			num++;
			list.Add(FromStageMonsterIgnoreQuantity(smon));
		}
		return (RespMonster[])Builtins.array(typeof(RespMonster), list);
	}

	public static RespMonster FromStageMonsterIgnoreQuantity(MStageMonsters smon)
	{
		RespMonster respMonster = new RespMonster();
		respMonster.Id = smon.Id;
		respMonster.MonsterId = smon.MMonsterId.Id;
		respMonster.Exp = 1;
		respMonster.IsKill = false;
		respMonster.Level = UnityEngine.Random.Range(smon.LevelMin, checked(smon.LevelMax + 1));
		respMonster.Rewards = new RespSimpleReward[0];
		return respMonster;
	}

	public void SetTemporaryElement(MElements elm)
	{
		if (elm != null)
		{
			temporaryElement = elm;
		}
	}

	public void ResetTemporaryElement()
	{
		temporaryElement = null;
	}

	public RespSimpleReward[] getRewards(EnumMasterTypeValues types)
	{
		_0024getRewards_0024locals_002414456 _0024getRewards_0024locals_0024 = new _0024getRewards_0024locals_002414456();
		_0024getRewards_0024locals_0024._0024types = types;
		return ArrayMapMain.FilterRewards(Rewards, new _0024getRewards_0024closure_00244031(_0024getRewards_0024locals_0024).Invoke);
	}

	public override string ToString()
	{
		return (StageMonsterMaster == null) ? new StringBuilder("no MStageMonsterId Id:").Append((object)Id).Append("/Lv:").Append((object)Level)
			.Append("/Attack:")
			.Append((object)Attack)
			.Append("/Hp:")
			.Append((object)Hp)
			.Append("/Df:")
			.Append((object)Defense)
			.ToString() : new StringBuilder("Id:").Append((object)Id).Append(" ").Append(Master)
			.Append(" IsKill:")
			.Append(IsKill)
			.Append(" Lv:")
			.Append((object)Level)
			.Append(" E:")
			.Append((object)Exp)
			.Append(" Rwds:")
			.Append((object)RewardNum)
			.Append(" MStageId:")
			.Append((object)StageMonsterMaster.MStageId)
			.ToString();
	}

	internal int _0024get_AllRewardId_0024closure_00244030(RespSimpleReward r)
	{
		return r.Id;
	}
}
