using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using MerlinAPI;

[Serializable]
public class UserTeamNotifyData
{
	[Serializable]
	public class TeamNotifyDataDetail
	{
		public string Name;

		public int Id;

		public TeamNotifyDataDetail(RespFriend member)
		{
			Name = member.Name;
			Id = member.TSocialPlayerId;
		}

		public TeamNotifyDataDetail(int id, string name)
		{
			Name = name;
			Id = id;
		}
	}

	private Hashtable currentMembers;

	public int leaderId;

	public UserTeamNotifyData()
	{
		currentMembers = new Hashtable();
	}

	public static UserTeamNotifyData FromHash(Hashtable table)
	{
		UserTeamNotifyData userTeamNotifyData = new UserTeamNotifyData();
		if (table != null)
		{
			Hashtable hashtable = table["currentMembers"] as Hashtable;
			userTeamNotifyData.currentMembers = new Hashtable();
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				Hashtable hashtable2 = userTeamNotifyData.currentMembers;
				object obj = current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				object key = int.Parse((string)obj);
				object obj2 = hashtable[current];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				hashtable2[key] = Uri.UnescapeDataString((string)obj2);
			}
			userTeamNotifyData.leaderId = RuntimeServices.UnboxInt32(table["leaderId"]);
		}
		return userTeamNotifyData;
	}

	public Hashtable ToHash()
	{
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		IEnumerator enumerator = currentMembers.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			object obj = currentMembers[current];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			hashtable2[current] = Uri.EscapeDataString((string)obj);
		}
		hashtable["currentMembers"] = hashtable2;
		hashtable["leaderId"] = leaderId;
		return hashtable;
	}

	public void Update(RespParty party)
	{
		RespMember[] members = party.Members;
		currentMembers = new Hashtable();
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
			RespMember respMember = members[RuntimeServices.NormalizeArrayIndex(members, index)];
			currentMembers[respMember.TSocialPlayerId] = respMember.Name;
		}
		leaderId = party.GetLeaderId();
	}

	public void Leave(int mySocialId, RespParty original)
	{
		RespParty party = RespParty.MakeSoloParty(mySocialId, original);
		Update(party);
	}

	public TeamNotifyDataDetail GetLeader()
	{
		object result;
		if (currentMembers.ContainsKey(leaderId))
		{
			int id = leaderId;
			object obj = currentMembers[leaderId];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			result = new TeamNotifyDataDetail(id, (string)obj);
		}
		else
		{
			if (leaderId != 0)
			{
				throw new AssertionFailedException("リーダー設定されてるのにパーティ情報の中にリーダーいない");
			}
			result = null;
		}
		return (TeamNotifyDataDetail)result;
	}

	public TeamNotifyDataDetail[] GetLeavers(RespFriend[] members)
	{
		List<TeamNotifyDataDetail> list = new List<TeamNotifyDataDetail>();
		IEnumerator enumerator = currentMembers.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			bool flag = false;
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
				RespFriend respFriend = members[RuntimeServices.NormalizeArrayIndex(members, index)];
				if (RuntimeServices.EqualityOperator(respFriend.TSocialPlayerId, current))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				int id = RuntimeServices.UnboxInt32(current);
				object obj = currentMembers[current];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				list.Add(new TeamNotifyDataDetail(id, (string)obj));
			}
		}
		return list.ToArray();
	}

	public TeamNotifyDataDetail[] GetNewFaces(RespFriend[] members)
	{
		List<TeamNotifyDataDetail> list = new List<TeamNotifyDataDetail>();
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
			RespFriend respFriend = members[RuntimeServices.NormalizeArrayIndex(members, index)];
			if (!currentMembers.ContainsKey(respFriend.TSocialPlayerId))
			{
				list.Add(new TeamNotifyDataDetail(respFriend));
			}
		}
		return list.ToArray();
	}
}
