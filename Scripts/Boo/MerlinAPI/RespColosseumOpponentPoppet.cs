using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespColosseumOpponentPoppet : RespPoppet
{
	protected string userName;

	protected int socialId;

	private RespOpponent orgRespOpponent;

	private RespOpponentWithOrganize orgRespOpponentWithOrganize;

	private bool isNpc;

	private double breederRankPoint;

	private int breederRankId;

	public string UserName
	{
		get
		{
			return userName;
		}
		set
		{
			userName = value;
		}
	}

	public int SocialId
	{
		get
		{
			return socialId;
		}
		set
		{
			socialId = value;
		}
	}

	public RespOpponent RespOpponent
	{
		get
		{
			return orgRespOpponent;
		}
		set
		{
			orgRespOpponent = value;
		}
	}

	public RespOpponentWithOrganize RespOpponentWithOrganize
	{
		get
		{
			return orgRespOpponentWithOrganize;
		}
		set
		{
			orgRespOpponentWithOrganize = value;
		}
	}

	public bool IsNpc
	{
		get
		{
			return isNpc;
		}
		set
		{
			isNpc = value;
		}
	}

	public double BreederRankPoint
	{
		get
		{
			return breederRankPoint;
		}
		set
		{
			breederRankPoint = value;
		}
	}

	public int BreederRankId
	{
		get
		{
			return breederRankId;
		}
		set
		{
			breederRankId = value;
		}
	}

	public RespColosseumOpponentPoppet()
	{
	}

	public RespColosseumOpponentPoppet(RespOpponent respOp)
	{
		if (respOp == null)
		{
			throw new AssertionFailedException("ヌルポ: RespColosseumPoppet(null)");
		}
		init(MPoppets.Get(1));
		orgRespOpponent = respOp;
		IsNpc = respOp.IsNPC;
		socialId = respOp.TSocialPlayerId;
		if (null != respOp.Name)
		{
			UserName = respOp.Name;
		}
		Level = respOp.Level;
		BreederRankId = respOp.BreederRankId;
		BreederRankPoint = respOp.BreederRankPoint;
		bool flag = UserData.Current.findFriend(respOp.TSocialPlayerId) != null;
	}

	public RespColosseumOpponentPoppet(RespOpponentWithOrganize respOp)
	{
		if (respOp == null)
		{
			throw new AssertionFailedException("ヌルポ: RespColosseumPoppet(null)");
		}
		init(MPoppets.Get(1));
		orgRespOpponentWithOrganize = respOp;
		IsNpc = respOp.IsNPC;
		socialId = respOp.TSocialPlayerId;
		if (null != respOp.Name)
		{
			UserName = respOp.Name;
		}
		Level = respOp.Level;
		BreederRankId = respOp.BreederRankId;
		BreederRankPoint = respOp.BreederRankPoint;
		bool flag = UserData.Current.findFriend(respOp.TSocialPlayerId) != null;
	}
}
