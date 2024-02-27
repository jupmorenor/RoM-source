using System;
using System.Collections.Generic;
using MerlinAPI;

[Serializable]
public class UserFriendListData
{
	public List<RespFriend> friends;

	public UserFriendListData()
	{
		friends = new List<RespFriend>();
	}

	public void set(RespFriend[] data)
	{
		if (data == null)
		{
			return;
		}
		friends.Clear();
		int i = 0;
		for (int length = data.Length; i < length; i = checked(i + 1))
		{
			if (data[i] != null)
			{
				friends.Add(data[i]);
			}
		}
	}

	public RespFriend find(int socialId)
	{
		RespFriend respFriend;
		foreach (RespFriend friend in friends)
		{
			if (friend.TSocialPlayerId != socialId)
			{
				continue;
			}
			respFriend = friend;
			goto IL_004c;
		}
		object result = null;
		goto IL_004d;
		IL_004c:
		result = respFriend;
		goto IL_004d;
		IL_004d:
		return (RespFriend)result;
	}
}
