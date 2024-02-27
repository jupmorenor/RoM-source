using System;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class RespTCycleRaidBattle : JsonBase
{
	public int Id;

	public int TCycleId;

	public int StyleId;

	public int ElementId;

	public DateTime ComboStartDate;

	public int ComboLevel;

	public int MMonsterId;

	public int NumberOfTimes;

	public int DiscoverSocialPlayerId;

	public DateTime DiscoverDate;

	public int Level;

	public int LevelCorrection;

	public int InitialHp;

	public int Hp;

	public string PhotonServer;

	public string RoomName;

	public bool IsActive;

	public bool IsDiscover;

	public bool IsDetectionElement;

	public bool IsDetectionStyle;

	public int CurrentLevel => checked((int)Mathf.Max(1f, Level + LevelCorrection));

	public DateTime BeginDate => MCycleSchedules.Get(TCycleId)?.BeginDate ?? DateTime.Parse("2001/01/01");

	public DateTime EndDate => MCycleSchedules.Get(TCycleId)?.EndDate ?? DateTime.Parse("2099/01/01");

	public bool IsEnableRaid
	{
		get
		{
			bool num = BeginDate <= MerlinDateTime.UtcNow;
			if (num)
			{
				num = MerlinDateTime.UtcNow < EndDate;
			}
			return num;
		}
	}

	public int GetCorrectLevel()
	{
		return checked(Level + LevelCorrection);
	}
}
