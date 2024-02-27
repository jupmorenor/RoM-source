using System;
using Boo.Lang.Runtime;
using CompilerGenerated;

namespace MerlinAPI;

[Serializable]
public class RespQuestStart : GameApiResponseBase
{
	[Serializable]
	internal class _0024GetReward_0024locals_002414450
	{
		internal int _0024questRewardId;
	}

	[Serializable]
	internal class _0024GetReward_0024closure_00244973
	{
		internal _0024GetReward_0024locals_002414450 _0024_0024locals_002415002;

		public _0024GetReward_0024closure_00244973(_0024GetReward_0024locals_002414450 _0024_0024locals_002415002)
		{
			this._0024_0024locals_002415002 = _0024_0024locals_002415002;
		}

		public bool Invoke(RespSimpleReward v)
		{
			return RuntimeServices.EqualityOperator(v, _0024_0024locals_002415002._0024questRewardId);
		}
	}

	public string DataKey;

	public bool IsSuccess;

	public int Exp;

	public int Coin;

	public RespSimpleReward[] QuestRewards;

	public RespMonster[] Monsters;

	public RespFriend Fellow;

	public int FriendPoint;

	public int[] AllQuestMonsterId => ArrayMapMain.RespsToInts(Monsters, (RespMonster m) => m.Id);

	public RespReward[] getQuestRewards()
	{
		return RespReward.FromSimpleRewardList(QuestRewards);
	}

	public RespSimpleReward GetReward(int questRewardId)
	{
		_0024GetReward_0024locals_002414450 _0024GetReward_0024locals_0024 = new _0024GetReward_0024locals_002414450();
		_0024GetReward_0024locals_0024._0024questRewardId = questRewardId;
		return (!(Monsters == null)) ? (Array.Find(QuestRewards, _0024adaptor_0024__ArrayMapMain_FilterRewards_0024callable121_002484_75___0024Predicate_0024167.Adapt(new _0024GetReward_0024closure_00244973(_0024GetReward_0024locals_0024).Invoke)) as RespSimpleReward) : null;
	}

	internal int _0024get_AllQuestMonsterId_0024closure_00244974(RespMonster m)
	{
		return m.Id;
	}
}
