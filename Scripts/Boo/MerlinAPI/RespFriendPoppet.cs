using System;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class RespFriendPoppet : RespPoppet
{
	protected string userName;

	protected int friendPoint;

	protected int characterLevel;

	protected RespFriend orgRespFriend;

	protected bool isFriend;

	protected int socialId;

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

	public int FriendPoint
	{
		get
		{
			return friendPoint;
		}
		set
		{
			friendPoint = value;
		}
	}

	public int CharacterLevel
	{
		get
		{
			return characterLevel;
		}
		set
		{
			characterLevel = value;
		}
	}

	public RespFriend RespFriend
	{
		get
		{
			return orgRespFriend;
		}
		set
		{
			orgRespFriend = value;
		}
	}

	public bool IsFriend
	{
		get
		{
			return isFriend;
		}
		set
		{
			isFriend = value;
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

	public RespFriendPoppet()
	{
	}

	public RespFriendPoppet(int mstid)
	{
		init(MPoppets.Get(mstid));
	}

	public RespFriendPoppet(RespFriend respFr)
	{
		if (respFr == null)
		{
			throw new AssertionFailedException("ヌルポ: RespFriendPoppet(null)");
		}
		init(MPoppets.Get(respFr.ItemId));
		if (!string.IsNullOrEmpty(respFr.Name))
		{
			UserName = respFr.Name;
		}
		CharacterLevel = respFr.CharacterLevel;
		Level = respFr.PoppetLevel;
		AttackBonus = respFr.AttackBonus;
		AttackPlusBonus = respFr.AttackPlusBonus;
		CoverSkillLevel_1 = respFr.SkillLevel_1;
		CoverSkillLevel_2 = respFr.SkillLevel_2;
		ChainSkillLevel = respFr.SkillLevel_3;
		HpBonus = respFr.HpBonus;
		HpPlusBonus = respFr.HpPlusBonus;
		orgRespFriend = respFr;
		if (respFr != null && UserData.Current != null)
		{
			isFriend = UserData.Current.findFriend(respFr.TSocialPlayerId) != null;
		}
		socialId = respFr.TSocialPlayerId;
		LimitBreakCount = respFr.PoppetLimitBreakCount;
		TraitId = respFr.PoppetTraitId;
	}
}
