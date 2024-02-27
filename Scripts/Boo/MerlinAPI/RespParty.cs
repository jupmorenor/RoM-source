using System;
using System.Linq;
using Boo.Lang.Runtime;
using CompilerGenerated;

namespace MerlinAPI;

[Serializable]
public class RespParty : JsonBase
{
	[Serializable]
	internal class _0024GetOtherMembers_0024locals_002414451
	{
		internal int _0024mySocialId;
	}

	[Serializable]
	internal class _0024Contains_0024locals_002414452
	{
		internal int _0024id;
	}

	[Serializable]
	internal class _0024MakeSoloParty_0024locals_002414453
	{
		internal int _0024mySocialId;
	}

	[Serializable]
	internal class _0024GetOtherMembers_0024closure_00243177
	{
		internal _0024GetOtherMembers_0024locals_002414451 _0024_0024locals_002415003;

		public _0024GetOtherMembers_0024closure_00243177(_0024GetOtherMembers_0024locals_002414451 _0024_0024locals_002415003)
		{
			this._0024_0024locals_002415003 = _0024_0024locals_002415003;
		}

		public bool Invoke(RespMember m)
		{
			return m.TSocialPlayerId != _0024_0024locals_002415003._0024mySocialId;
		}
	}

	[Serializable]
	internal class _0024Contains_0024closure_00243178
	{
		internal _0024Contains_0024locals_002414452 _0024_0024locals_002415004;

		public _0024Contains_0024closure_00243178(_0024Contains_0024locals_002414452 _0024_0024locals_002415004)
		{
			this._0024_0024locals_002415004 = _0024_0024locals_002415004;
		}

		public bool Invoke(RespMember x)
		{
			return x.TSocialPlayerId == _0024_0024locals_002415004._0024id;
		}
	}

	[Serializable]
	internal class _0024MakeSoloParty_0024closure_00243180
	{
		internal _0024MakeSoloParty_0024locals_002414453 _0024_0024locals_002415005;

		public _0024MakeSoloParty_0024closure_00243180(_0024MakeSoloParty_0024locals_002414453 _0024_0024locals_002415005)
		{
			this._0024_0024locals_002415005 = _0024_0024locals_002415005;
		}

		public bool Invoke(RespMember x)
		{
			return x.TSocialPlayerId == _0024_0024locals_002415005._0024mySocialId;
		}
	}

	public int Id;

	public RespMember[] Members;

	private RespMember[] _cached;

	public RespMember[] GetOtherMembers(int mySocialId)
	{
		_0024GetOtherMembers_0024locals_002414451 _0024GetOtherMembers_0024locals_0024 = new _0024GetOtherMembers_0024locals_002414451();
		_0024GetOtherMembers_0024locals_0024._0024mySocialId = mySocialId;
		if (_cached == null)
		{
			_cached = ArrayMapMain.FilterResps(Members, new _0024GetOtherMembers_0024closure_00243177(_0024GetOtherMembers_0024locals_0024).Invoke);
		}
		return _cached;
	}

	public bool Contains(int id)
	{
		_0024Contains_0024locals_002414452 _0024Contains_0024locals_0024 = new _0024Contains_0024locals_002414452();
		_0024Contains_0024locals_0024._0024id = id;
		return Members.Any(_0024adaptor_0024__ArrayMapMain_FilterResps_0024callable116_002441_67___0024Func_0024168.Adapt(new _0024Contains_0024closure_00243178(_0024Contains_0024locals_0024).Invoke));
	}

	public int GetLeaderId()
	{
		int index;
		if (0 < Members.Length)
		{
			int num = 0;
			int length = Members.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				index = num;
				num++;
				RespMember[] members = Members;
				if (!members[RuntimeServices.NormalizeArrayIndex(members, index)].IsLeader)
				{
					continue;
				}
				goto IL_0054;
			}
		}
		int result = 0;
		goto IL_0074;
		IL_0054:
		RespMember[] members2 = Members;
		result = members2[RuntimeServices.NormalizeArrayIndex(members2, index)].TSocialPlayerId;
		goto IL_0074;
		IL_0074:
		return result;
	}

	public int Count()
	{
		return Members.Length;
	}

	public RespMember GetLeader()
	{
		RespMember[] array = ArrayMapMain.FilterResps(Members, (RespMember x) => x.IsLeader);
		return array[0];
	}

	public static RespParty MakeSoloParty(int mySocialId, RespParty original)
	{
		_0024MakeSoloParty_0024locals_002414453 _0024MakeSoloParty_0024locals_0024 = new _0024MakeSoloParty_0024locals_002414453();
		_0024MakeSoloParty_0024locals_0024._0024mySocialId = mySocialId;
		RespParty respParty = new RespParty();
		respParty.Id = _0024MakeSoloParty_0024locals_0024._0024mySocialId;
		respParty.Members = ArrayMapMain.FilterResps(original.Members, new _0024MakeSoloParty_0024closure_00243180(_0024MakeSoloParty_0024locals_0024).Invoke);
		respParty.Members[0].IsLeader = true;
		return respParty;
	}

	public static RespParty MakeParty(RespMember[] members)
	{
		RespParty respParty = new RespParty();
		respParty.Members = members;
		int num = 0;
		int length = members.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (members[RuntimeServices.NormalizeArrayIndex(members, index)].IsLeader)
			{
				respParty.Id = members[RuntimeServices.NormalizeArrayIndex(members, index)].TSocialPlayerId;
			}
		}
		return respParty;
	}

	internal bool _0024GetLeader_0024closure_00243179(RespMember x)
	{
		return x.IsLeader;
	}
}
