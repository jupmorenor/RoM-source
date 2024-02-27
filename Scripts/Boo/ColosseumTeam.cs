using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumTeam
{
	[Serializable]
	internal class _0024contains_0024locals_002414376
	{
		internal AIControl _0024ai;
	}

	[Serializable]
	internal class _0024contains_0024closure_00243109
	{
		internal _0024contains_0024locals_002414376 _0024_0024locals_002414856;

		public _0024contains_0024closure_00243109(_0024contains_0024locals_002414376 _0024_0024locals_002414856)
		{
			this._0024_0024locals_002414856 = _0024_0024locals_002414856;
		}

		public bool Invoke(ColosseumTeamMember m)
		{
			return m.isMe(_0024_0024locals_002414856._0024ai);
		}
	}

	[Serializable]
	internal class _0024updateBattle_0024closure_00243110
	{
		internal ColosseumTeam _0024this_002414857;

		internal ColosseumTeamMember _0024member_002414858;

		public _0024updateBattle_0024closure_00243110(ColosseumTeam _0024this_002414857, ColosseumTeamMember _0024member_002414858)
		{
			this._0024this_002414857 = _0024this_002414857;
			this._0024member_002414858 = _0024member_002414858;
		}

		public void Invoke(ColosseumTeamMember _m)
		{
			checked
			{
				int num = (int)_0024member_002414858.DeckCost;
				_0024this_002414857.subForce(num);
				DamageDisplay.DisplayColosseumForceChange(-num, _0024this_002414857.isPlayerSide);
			}
		}
	}

	private string teamName;

	private bool isPlayerSide;

	private ColosseumTeamInfo teamInfo;

	private Boo.Lang.List<ColosseumTeamMember> memberList;

	private float force;

	private float maxForce;

	public int MemberNum => memberList.Count;

	public RespPoppet[] PoppetDataArray
	{
		get
		{
			RespPoppet[] array = new RespPoppet[memberList.Count];
			int num = 0;
			int count = memberList.Count;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < count)
			{
				int index = num;
				num++;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = memberList[index].PoppetData;
			}
			return array;
		}
	}

	public bool IsEndOfInstantiation
	{
		get
		{
			IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
			bool flag;
			try
			{
				while (enumerator.MoveNext())
				{
					ColosseumTeamMember current = enumerator.Current;
					if (current.IsPopped)
					{
						continue;
					}
					flag = false;
					goto IL_0044;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			int result = 1;
			goto IL_0045;
			IL_0044:
			result = (flag ? 1 : 0);
			goto IL_0045;
			IL_0045:
			return (byte)result != 0;
		}
	}

	public bool HasNoForce => !(force > 0f);

	public string TeamName => teamName;

	public bool IsPlayerSide => isPlayerSide;

	public ColosseumTeamInfo TeamInfo => teamInfo;

	public Boo.Lang.List<ColosseumTeamMember> MemberList => memberList;

	public float Force => force;

	public float MaxForce => maxForce;

	public ColosseumTeam(string _teamName, bool _isPlayerSide)
	{
		teamInfo = new ColosseumTeamInfo();
		memberList = new Boo.Lang.List<ColosseumTeamMember>();
		teamName = _teamName;
		isPlayerSide = _isPlayerSide;
		initForce(100f);
	}

	private void subForce(float d)
	{
		force -= d;
		if (!(force >= 0f))
		{
			force = 0f;
		}
	}

	private void chargeForce()
	{
		force = maxForce;
	}

	public void initForce(float max)
	{
		if (!(max > 0f))
		{
			throw new AssertionFailedException("max > 0.0F");
		}
		maxForce = max;
		force = maxForce;
	}

	public void dispose()
	{
		destroyAllChars();
		memberList.Clear();
	}

	private void destroyAllChars()
	{
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				current.destroyChar();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void add(RespPoppet ppt, RespWeapon wpn, Vector3 pos, bool isLeader)
	{
		if (ppt != null)
		{
			ColosseumTeamMember item = new ColosseumTeamMember(ppt, wpn, isPlayerSide, pos, isLeader);
			memberList.Add(item);
		}
	}

	public ColosseumTeamMember getMember(int index)
	{
		return (0 > index || index >= memberList.Count) ? null : memberList[index];
	}

	public bool contains(AIControl ai)
	{
		_0024contains_0024locals_002414376 _0024contains_0024locals_0024 = new _0024contains_0024locals_002414376();
		_0024contains_0024locals_0024._0024ai = ai;
		return memberList.Contains(_0024adaptor_0024__ColosseumTeam_contains_0024callable525_0024105_35___0024Predicate_0024138.Adapt(new _0024contains_0024closure_00243109(_0024contains_0024locals_0024).Invoke));
	}

	public void eachMember(__ColosseumTeam_eachMember_0024callable70_0024107_33__ c)
	{
		if (c == null)
		{
			return;
		}
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				c(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void startSetup()
	{
		chargeForce();
		startInstantiation();
	}

	public void initSkill(MCoverSkills[] additionalSkills)
	{
		if (!IsEndOfInstantiation)
		{
			throw new AssertionFailedException("IsEndOfInstantiation");
		}
		int num = 0;
		int memberNum = MemberNum;
		if (memberNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < memberNum)
		{
			int index = num;
			num++;
			bool isLeader = memberList[index].IsLeader;
			RespPoppet poppetData = memberList[index].PoppetData;
			int num2 = 0;
			int memberNum2 = MemberNum;
			if (memberNum2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < memberNum2)
			{
				int index2 = num2;
				num2++;
				memberList[index2].addCoverSkills(poppetData, isLeader);
			}
		}
		if (additionalSkills != null)
		{
			int i = 0;
			for (int length = additionalSkills.Length; i < length; i = checked(i + 1))
			{
				int num3 = 0;
				int memberNum3 = MemberNum;
				if (memberNum3 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num3 < memberNum3)
				{
					int index3 = num3;
					num3++;
					memberList[index3].addCoverSkillFromMaster(additionalSkills[i], additionalSkills[i].LevelMax);
				}
			}
		}
		int num4 = 0;
		int memberNum4 = MemberNum;
		if (memberNum4 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < memberNum4)
		{
			int index4 = num4;
			num4++;
			memberList[index4].initHP();
		}
	}

	public void startBattle()
	{
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				current.startBattle();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void updateBattle(float dt)
	{
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				current.update(dt, new __ColosseumTeam_eachMember_0024callable70_0024107_33__(new _0024updateBattle_0024closure_00243110(this, current).Invoke));
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (force <= 0f)
		{
			return;
		}
		IEnumerator<ColosseumTeamMember> enumerator2 = memberList.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				ColosseumTeamMember current2 = enumerator2.Current;
				current2.lateUpdate();
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	public void stopBattle()
	{
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				current.stopBattle();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private void startInstantiation()
	{
		IEnumerator<ColosseumTeamMember> enumerator = memberList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ColosseumTeamMember current = enumerator.Current;
				current.pop(stop: true);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
