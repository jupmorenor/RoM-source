using System;
using System.Collections.Generic;

[Serializable]
public class UserPresentBoxData
{
	public List<UserPresentData> present;

	public UserPresentBoxData()
	{
		present = new List<UserPresentData>();
	}
}
