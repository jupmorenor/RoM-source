using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class UserAlreadyReadData
{
	[NonSerialized]
	private const string KEY_FRIENDS = "friends";

	[NonSerialized]
	private const string KEY_FRIENDAPPLIES = "friendApplies";

	[NonSerialized]
	private const string KEY_PARTYMEMBER = "partyMember";

	[NonSerialized]
	private const string KEY_PARTYAPPLIES = "partyApplies";

	[NonSerialized]
	private const string KEY_PRESENTS = "presents";

	private HashSet<int> tmpFriends;

	private HashSet<int> tmpFriendApplies;

	private HashSet<int> tmpPartyMember;

	private HashSet<int> tmpPartyApplies;

	private HashSet<int> tmpPresents;

	private HashSet<int> friends;

	private HashSet<int> friendApplies;

	private HashSet<int> partyMember;

	private HashSet<int> partyApplies;

	private HashSet<int> presents;

	private bool init;

	public HashSet<int> Friends => friends;

	public HashSet<int> FriendApplies => friendApplies;

	public HashSet<int> PartyMember => partyMember;

	public HashSet<int> PartyApplies => partyApplies;

	public HashSet<int> Presents => presents;

	public bool Init
	{
		get
		{
			return init;
		}
		set
		{
			init = value;
		}
	}

	public UserAlreadyReadData()
	{
		tmpFriends = new HashSet<int>();
		tmpFriendApplies = new HashSet<int>();
		tmpPartyMember = new HashSet<int>();
		tmpPartyApplies = new HashSet<int>();
		tmpPresents = new HashSet<int>();
		friends = new HashSet<int>();
		friendApplies = new HashSet<int>();
		partyMember = new HashSet<int>();
		partyApplies = new HashSet<int>();
		presents = new HashSet<int>();
	}

	public HashSet<int> MarkFriends(RespFriend[] arr)
	{
		return Mark(ref friends, arr);
	}

	public HashSet<int> MarkMembers(RespFriend[] arr)
	{
		return Mark(ref partyMember, arr);
	}

	public HashSet<int> MarkFriendApplies(RespApplyInfo[] arr)
	{
		return Mark(ref friendApplies, arr);
	}

	public HashSet<int> MarkPartyApplies(RespApplyInfo[] arr)
	{
		return Mark(ref partyApplies, arr);
	}

	public HashSet<int> MarkPresents(RespPlayerPresentBox[] arr)
	{
		return Mark(ref presents, arr);
	}

	public void RemoveFriends(int id)
	{
		friends.Remove(id);
	}

	public void RemoveMembers(int id)
	{
		partyMember.Remove(id);
	}

	public void RemoveFriendApplies(int id)
	{
		friendApplies.Remove(id);
	}

	public void RemovePartyApplies(int id)
	{
		partyApplies.Remove(id);
	}

	public HashSet<int> GetNewFriends(RespFriend[] arr)
	{
		return init ? GetNew(friends, arr) : Mark(ref tmpFriends, arr);
	}

	public HashSet<int> GetNewMembers(RespFriend[] arr)
	{
		return init ? GetNew(partyMember, arr) : Mark(ref tmpPartyMember, arr);
	}

	public HashSet<int> GetNewFriendApplies(RespApplyInfo[] arr)
	{
		return init ? GetNew(friendApplies, arr) : Mark(ref tmpFriendApplies, arr);
	}

	public HashSet<int> GetNewPartyApplies(RespApplyInfo[] arr)
	{
		return init ? GetNew(partyApplies, arr) : Mark(ref tmpPartyApplies, arr);
	}

	public HashSet<int> GetNewPresents(RespPlayerPresentBox[] arr)
	{
		return init ? GetNew(presents, arr) : Mark(ref tmpPresents, arr);
	}

	public void Clear()
	{
		friends.Clear();
		partyMember.Clear();
		friendApplies.Clear();
		partyApplies.Clear();
		presents.Clear();
	}

	public Hashtable ToHash()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["friends"] = friends.ToArray();
		hashtable["friendApplies"] = friendApplies.ToArray();
		hashtable["partyMember"] = partyMember.ToArray();
		hashtable["partyApplies"] = partyApplies.ToArray();
		hashtable["presents"] = presents.ToArray();
		return hashtable;
	}

	public static UserAlreadyReadData FromHash(Hashtable hash)
	{
		__UserAlreadyReadData_FromHash_0024callable155_0024111_13__ _UserAlreadyReadData_FromHash_0024callable155_0024111_13__ = delegate(Hashtable hash, string key)
		{
			HashSet<int> hashSet = new HashSet<int>();
			if (hash.ContainsKey(key))
			{
				ArrayList arrayList = hash[key] as ArrayList;
				int num = 0;
				int count = arrayList.Count;
				if (count < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < count)
				{
					int index = num;
					num++;
					hashSet.Add(RuntimeServices.UnboxInt32(arrayList[index]));
				}
			}
			return hashSet;
		};
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		UserAlreadyReadData result;
		if (hash == null)
		{
			result = alreadyReadData;
		}
		else
		{
			alreadyReadData.friends = _UserAlreadyReadData_FromHash_0024callable155_0024111_13__(hash, "friends");
			alreadyReadData.friendApplies = _UserAlreadyReadData_FromHash_0024callable155_0024111_13__(hash, "friendApplies");
			alreadyReadData.partyMember = _UserAlreadyReadData_FromHash_0024callable155_0024111_13__(hash, "partyMember");
			alreadyReadData.partyApplies = _UserAlreadyReadData_FromHash_0024callable155_0024111_13__(hash, "partyApplies");
			alreadyReadData.presents = _UserAlreadyReadData_FromHash_0024callable155_0024111_13__(hash, "presents");
			if (!alreadyReadData.init)
			{
				UserData.Current.NewFriendData = GetNew(alreadyReadData.friends, alreadyReadData.tmpFriends).Count();
				UserData.Current.NewFriendApplyData = GetNew(alreadyReadData.friendApplies, alreadyReadData.tmpFriendApplies).Count();
				UserData.Current.NewPartyMemberData = GetNew(alreadyReadData.partyMember, alreadyReadData.tmpPartyMember).Count();
				UserData.Current.NewPartyApplyData = GetNew(alreadyReadData.partyApplies, alreadyReadData.tmpPartyApplies).Count();
			}
			alreadyReadData.init = true;
			result = alreadyReadData;
		}
		return result;
	}

	public static HashSet<int> Mark(ref HashSet<int> oldHash, RespFriend[] arr)
	{
		return Mark(ref oldHash, ArrayMapMain.RespsToInts(arr, (RespFriend x) => x.TSocialPlayerId));
	}

	public static HashSet<int> Mark(ref HashSet<int> oldHash, RespApplyInfo[] arr)
	{
		return Mark(ref oldHash, ArrayMapMain.RespsToInts(arr, (RespApplyInfo x) => x.ApplyId));
	}

	public static HashSet<int> Mark(ref HashSet<int> oldHash, RespPlayerPresentBox[] arr)
	{
		return Mark(ref oldHash, ArrayMapMain.RespsToInts(arr, (RespPlayerPresentBox x) => x.Id));
	}

	public static HashSet<int> Mark(ref HashSet<int> oldHash, IEnumerable<int> arr)
	{
		HashSet<int> hashSet = new HashSet<int>();
		IEnumerator<int> enumerator = arr.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				hashSet.Add(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		HashSet<int> hashSet2 = null;
		hashSet2 = ((oldHash == null) ? hashSet : new HashSet<int>(hashSet.Except(oldHash)));
		oldHash = hashSet;
		return hashSet2;
	}

	public static HashSet<int> GetNew(HashSet<int> oldHash, RespFriend[] arr)
	{
		return GetNew(oldHash, ArrayMapMain.RespsToInts(arr, (RespFriend x) => x.TSocialPlayerId));
	}

	public static HashSet<int> GetNew(HashSet<int> oldHash, RespApplyInfo[] arr)
	{
		return GetNew(oldHash, ArrayMapMain.RespsToInts(arr, (RespApplyInfo x) => x.ApplyId));
	}

	public static HashSet<int> GetNew(HashSet<int> oldHash, RespPlayerPresentBox[] arr)
	{
		return GetNew(oldHash, ArrayMapMain.RespsToInts(arr, (RespPlayerPresentBox x) => x.Id));
	}

	public static HashSet<int> GetNew(HashSet<int> oldHash, IEnumerable<int> arr)
	{
		HashSet<int> hashSet = new HashSet<int>();
		IEnumerator<int> enumerator = arr.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				hashSet.Add(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		HashSet<int> hashSet2 = null;
		if (oldHash != null)
		{
			return new HashSet<int>(hashSet.Except(oldHash));
		}
		return hashSet;
	}

	public static HashSet<int> GetNew(HashSet<int> oldHash, HashSet<int> newHash)
	{
		HashSet<int> hashSet = null;
		if (oldHash != null)
		{
			return new HashSet<int>(newHash.Except(oldHash));
		}
		return newHash;
	}

	internal static HashSet<int> _0024FromHash_0024Read_00243241(Hashtable hash, string key)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (hash.ContainsKey(key))
		{
			ArrayList arrayList = hash[key] as ArrayList;
			int num = 0;
			int count = arrayList.Count;
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < count)
			{
				int index = num;
				num++;
				hashSet.Add(RuntimeServices.UnboxInt32(arrayList[index]));
			}
		}
		return hashSet;
	}

	internal static int _0024Mark_0024closure_00243242(RespFriend x)
	{
		return x.TSocialPlayerId;
	}

	internal static int _0024Mark_0024closure_00243243(RespApplyInfo x)
	{
		return x.ApplyId;
	}

	internal static int _0024Mark_0024closure_00243244(RespPlayerPresentBox x)
	{
		return x.Id;
	}

	internal static int _0024GetNew_0024closure_00243245(RespFriend x)
	{
		return x.TSocialPlayerId;
	}

	internal static int _0024GetNew_0024closure_00243246(RespApplyInfo x)
	{
		return x.ApplyId;
	}

	internal static int _0024GetNew_0024closure_00243247(RespPlayerPresentBox x)
	{
		return x.Id;
	}
}
