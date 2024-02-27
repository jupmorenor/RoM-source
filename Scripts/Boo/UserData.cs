using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class UserData
{
	[Serializable]
	internal class _0024setLoginBonus_0024locals_002414397
	{
		internal RespPlayerLogin _0024entry;
	}

	[Serializable]
	internal class _0024setLoginBonus_0024pred_00242799
	{
		internal _0024setLoginBonus_0024locals_002414397 _0024_0024locals_002414921;

		public _0024setLoginBonus_0024pred_00242799(_0024setLoginBonus_0024locals_002414397 _0024_0024locals_002414921)
		{
			this._0024_0024locals_002414921 = _0024_0024locals_002414921;
		}

		public bool Invoke(RespPlayerLogin x)
		{
			return _0024_0024locals_002414921._0024entry.Id == x.Id;
		}
	}

	[NonSerialized]
	public const string SAVE_FILE_NAME = "riseofmana.dat";

	[NonSerialized]
	public const string MD5_SAVE_FILE_NAME = "riseofmana2.dat";

	[NonSerialized]
	public const string SAVE_BACKUP_NAME = "riseofmana.bak";

	[NonSerialized]
	public const string MD5_SAVE_BACKUP_NAME = "riseofmana2.bak";

	[NonSerialized]
	private static float apRecoverySec = -1f;

	[NonSerialized]
	private static float rpRecoverySec = -1f;

	[NonSerialized]
	private static float bpRecoverySec = -1f;

	[NonSerialized]
	private static UserData _current;

	public RespPlayer userBasicInfo;

	public RespPlayerInfo userStatus;

	public RespPlayerLogin[] userLoginBonuses;

	public UserDeckData userDeckData;

	public UserDeckData2 userDeckData2;

	public UserPoppetDeckData userPoppetDeckData;

	public UserBoxData userBoxData;

	public UserFriendListData userFriendListData;

	public UserPresentBoxData userPresentBoxData;

	public UserRaidData userRaidInfo;

	public UserChallengeData userChallengeInfo;

	public UserMiscInfo userMiscInfo;

	public RespParty userParty;

	public RespBreeder userBreeder;

	public RespQuestTicket[] questTickets;

	public string inviteCode;

	public UserColosseumEvent userColosseumEvent;

	public UserQuestMission userQuestMission;

	private DateTime endApTime;

	private DateTime endRpTime;

	private DateTime endBpTime;

	private int newPresentData;

	private int newFriendData;

	private int newFriendApplyData;

	private int newPartyMemberData;

	private int newPartyApplyData;

	public static float ApRecoverySec
	{
		get
		{
			if (!(apRecoverySec >= 0f))
			{
				apRecoverySec = MGameParameters.findByGameParameterId(19).Param;
			}
			return apRecoverySec;
		}
	}

	public static float RpRecoverySec
	{
		get
		{
			if (!(rpRecoverySec >= 0f))
			{
				rpRecoverySec = MGameParameters.findByGameParameterId(20).Param;
			}
			return rpRecoverySec;
		}
	}

	public static float BpRecoverySec
	{
		get
		{
			if (!(bpRecoverySec >= 0f))
			{
				bpRecoverySec = MGameParameters.findByGameParameterId(53).Param;
			}
			return bpRecoverySec;
		}
	}

	public static UserData Current
	{
		get
		{
			if (_current == null)
			{
				_current = new UserData();
			}
			return _current;
		}
	}

	public RACE_TYPE PlayerRace
	{
		get
		{
			return userMiscInfo.playerRace;
		}
		set
		{
			userMiscInfo.playerRace = value;
		}
	}

	public int PlayerId => userBasicInfo.Id;

	public int TSocialPlayerId => userStatus.TSocialPlayerId;

	public string PlayerName => userBasicInfo.Name;

	public int Coin => userStatus.Coin;

	public int FayStone => userStatus.FayStone;

	public int Level => userStatus.Level;

	public int Exp => userStatus.Exp;

	public int CurrentLevelExp => GetLevelExp(Level);

	public int NextLevelExp => GetLevelExp(checked(Level + 1));

	public int Ap => CalcApRpBp(userStatus.Ap, MaxAp, BeforeApRecoveryDateTime, ApRecoverySec, "Ap");

	public int Rp => CalcApRpBp(userStatus.Rp, MaxRp, BeforeRpRecoveryDateTime, RpRecoverySec, "Rp");

	public int Bp => CalcApRpBp(userStatus.Bp, MaxBp, BeforeBpRecoveryDateTime, BpRecoverySec, "Bp");

	public int MaxAp => MPlayerParameters.Get(Level)?.Ap ?? 1;

	public int MaxRp => MGameParameters.findByGameParameterId(3)?.Param ?? 1;

	public int MaxBp => MGameParameters.findByGameParameterId(52)?.Param ?? 1;

	public int Fp => userStatus.Fp;

	public int BoxExtendLimit => MGameParameters.findByGameParameterId(4).Param;

	public int BoxMax => checked(userStatus.BoxSize + BoxExtendLimit * 5);

	public int BoxCapacity => checked(userStatus.BoxSize + userStatus.BoxExtensionCount * 5);

	public int FriendMax => userStatus.FriendLimit;

	public int AngelGender => userStatus.AngelGender;

	public int DemonGender => userStatus.DemonGender;

	public DateTime BeforeApRecoveryDateTime => userStatus.BeforeApRecoveryDateTime.ToUniversalTime();

	public DateTime BeforeRpRecoveryDateTime => userStatus.BeforeRpRecoveryDateTime.ToUniversalTime();

	public DateTime BeforeBpRecoveryDateTime => userStatus.BeforeBpRecoveryDateTime.ToUniversalTime();

	public DateTime EndApRecoveryDateTime
	{
		get
		{
			CalcEndTime();
			return endApTime;
		}
	}

	public DateTime EndRpRecoveryDateTime
	{
		get
		{
			CalcEndTime();
			return endRpTime;
		}
	}

	public DateTime EndBpRecoveryDateTime
	{
		get
		{
			CalcEndTime();
			return endBpTime;
		}
	}

	public RespPlayerLogin[] Login => userLoginBonuses;

	public bool HasLoginBonus
	{
		get
		{
			int num = 0;
			int length = userLoginBonuses.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			int result;
			while (true)
			{
				if (num < length)
				{
					int index = num;
					num++;
					RespPlayerLogin[] array = userLoginBonuses;
					if (array[RuntimeServices.NormalizeArrayIndex(array, index)].IsLoginBonus)
					{
						result = 1;
						break;
					}
					continue;
				}
				result = 0;
				break;
			}
			return (byte)result != 0;
		}
	}

	public UserConfigData Config => userMiscInfo.configData;

	public int PlayerGroupId
	{
		get
		{
			int num = userBasicInfo.Id % 10;
			int num2 = 0;
			MPlayerGroups[] all = MPlayerGroups.All;
			int length = all.Length;
			int result;
			while (true)
			{
				if (num2 < length)
				{
					if (all[num2].Digit == num)
					{
						result = all[num2].PlayerGroupId;
						break;
					}
					num2 = checked(num2 + 1);
					continue;
				}
				result = 0;
				break;
			}
			return result;
		}
	}

	public bool IsValidDeck2 => userDeckData2.IsValid;

	public RespDeck2 CurrentDeck2
	{
		get
		{
			RespDeck2 respDeck = userDeckData2.get(userStatus.TPlayerDeckNo);
			if (respDeck == null)
			{
				if (userDeckData2.deckNum() <= 0)
				{
					throw new AssertionFailedException("userDeckData2.deckNum() > 0");
				}
				respDeck = userDeckData2.Decks2[0];
				if (respDeck == null)
				{
					throw new AssertionFailedException(new StringBuilder("Deck数は").Append(userDeckData2).Append("あるのに、[0]がnullってどうすればいいんだってばよ！").ToString());
				}
			}
			return respDeck;
		}
	}

	public RespWeapon AngelWeapon => CurrentDeck2.AngelWeapon;

	public RespWeapon DevilWeapon => CurrentDeck2.DevilWeapon;

	public RespWeapon ActiveWeapon => PlayerRace switch
	{
		RACE_TYPE.Tensi => AngelWeapon, 
		RACE_TYPE.Akuma => DevilWeapon, 
		_ => null, 
	};

	public RespPoppet CurrentPoppetNewOrOldDeck => (!IsValidDeck2) ? CurrentPoppet : CurrentDeck2.MainPoppet;

	public RespDeck CurrentDeck => userDeckData.get(1);

	public RespWeapon[] CurrentWeapons
	{
		get
		{
			BoxId[] weaponIds = CurrentDeck.WeaponIds;
			RespWeapon[] array = new RespWeapon[weaponIds.Length];
			int num = 0;
			int length = weaponIds.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int num2 = num;
				num++;
				if (!weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, num2)].IsValid)
				{
					throw new AssertionFailedException("boxIds[i].IsValid == true");
				}
				array[RuntimeServices.NormalizeArrayIndex(array, num2)] = boxWeapon(weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, num2)]);
				if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == null)
				{
					throw new AssertionFailedException(new StringBuilder("BoxID:").Append(weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, num2)]).Append("で探したら、ary[").Append((object)num2)
						.Append("]がnullです")
						.ToString());
				}
			}
			return array;
		}
	}

	public bool IsValidOldCurrentWeapons
	{
		get
		{
			BoxId[] weaponIds = CurrentDeck.WeaponIds;
			RespWeapon[] array = new RespWeapon[weaponIds.Length];
			int num = 0;
			int length = weaponIds.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			int result;
			while (true)
			{
				if (num < length)
				{
					int index = num;
					num++;
					if (!weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, index)].IsValid)
					{
						result = 0;
						break;
					}
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = boxWeapon(weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, index)]);
					if (array[RuntimeServices.NormalizeArrayIndex(array, index)] == null)
					{
						result = 0;
						break;
					}
					continue;
				}
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsValidCurrentDeck
	{
		get
		{
			int result;
			if (CurrentDeck == null)
			{
				result = 0;
			}
			else
			{
				BoxId[] weaponIds = CurrentDeck.WeaponIds;
				RespWeapon[] array = new RespWeapon[weaponIds.Length];
				int num = 0;
				int length = weaponIds.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (true)
				{
					if (num < length)
					{
						int index = num;
						num++;
						if (weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, index)].IsValid)
						{
							if (boxWeapon(weaponIds[RuntimeServices.NormalizeArrayIndex(weaponIds, index)]) != null)
							{
								continue;
							}
						}
						result = 0;
					}
					else
					{
						result = 1;
					}
					break;
				}
			}
			return (byte)result != 0;
		}
	}

	public RespWeapon MainWeapon => GetWeapons(0);

	public RespWeapon SubWeapon1 => GetWeapons(1);

	public RespWeapon SubWeapon2 => GetWeapons(2);

	public RespPoppet CurrentPoppet
	{
		get
		{
			RespDeck currentDeck = CurrentDeck;
			if (currentDeck == null)
			{
				throw new AssertionFailedException("デッキデータがないよー！");
			}
			RespPoppet respPoppet = boxPoppet(currentDeck.TPoppetBoxId);
			if (respPoppet == null)
			{
				throw new AssertionFailedException(new StringBuilder("ID=").Append(currentDeck.TPoppetBoxId).Append("の魔ペットマスターないよ！").ToString());
			}
			return respPoppet;
		}
	}

	public bool IsCurrentPoppetValid
	{
		get
		{
			RespDeck currentDeck = CurrentDeck;
			return (currentDeck != null && currentDeck.TPoppetBoxId.IsValid) ? true : false;
		}
	}

	public RespPoppetDeck CurrentPoppetDeck
	{
		get
		{
			RespPoppetDeck respPoppetDeck = userPoppetDeckData.get(userStatus.TPlayerPoppetDeckNo);
			if (respPoppetDeck == null)
			{
				if (userPoppetDeckData.deckNum() <= 0)
				{
					throw new AssertionFailedException("userPoppetDeckData.deckNum() > 0");
				}
				respPoppetDeck = userPoppetDeckData.get(0);
				if (respPoppetDeck == null)
				{
					throw new AssertionFailedException(new StringBuilder("Deck数は").Append(userPoppetDeckData).Append("あるのに、[0]がnullってどうすればいいんだってばよ！").ToString());
				}
			}
			return respPoppetDeck;
		}
	}

	public int BoxCount => checked(BoxWeaponNum + BoxPoppetNum);

	public int BoxWeaponNum => userBoxData.Weapons.Length;

	public int BoxPoppetNum => userBoxData.Muppets.Length;

	public RespWeapon[] BoxWeapons => (RespWeapon[])Builtins.array(typeof(RespWeapon), userBoxData.Weapons);

	public RespPoppet[] BoxPoppets => (RespPoppet[])Builtins.array(typeof(RespPoppet), userBoxData.Muppets);

	public bool HasNewPresent => newPresentData > 0;

	public int NewPresentData
	{
		get
		{
			return newPresentData;
		}
		set
		{
			newPresentData = value;
		}
	}

	public int NewFriendData
	{
		get
		{
			return newFriendData;
		}
		set
		{
			newFriendData = value;
		}
	}

	public int NewFriendApplyData
	{
		get
		{
			return newFriendApplyData;
		}
		set
		{
			newFriendApplyData = value;
		}
	}

	public int NewPartyMemberData
	{
		get
		{
			return newPartyMemberData;
		}
		set
		{
			newPartyMemberData = value;
		}
	}

	public int NewPartyApplyData
	{
		get
		{
			return newPartyApplyData;
		}
		set
		{
			newPartyApplyData = value;
		}
	}

	public UserData()
	{
		userBasicInfo = new RespPlayer();
		userStatus = new RespPlayerInfo();
		userLoginBonuses = new RespPlayerLogin[0];
		userDeckData = new UserDeckData();
		userDeckData2 = new UserDeckData2();
		userPoppetDeckData = new UserPoppetDeckData();
		userBoxData = new UserBoxData();
		userFriendListData = new UserFriendListData();
		userPresentBoxData = new UserPresentBoxData();
		userRaidInfo = new UserRaidData();
		userChallengeInfo = new UserChallengeData();
		userMiscInfo = new UserMiscInfo();
		userParty = new RespParty();
		userBreeder = new RespBreeder();
		questTickets = new RespQuestTicket[0];
		inviteCode = string.Empty;
		userColosseumEvent = new UserColosseumEvent();
		userQuestMission = new UserQuestMission();
	}

	public static void ClearCurrent()
	{
		if (_current != null)
		{
			_current.userMiscInfo.Clear();
		}
		_current = new UserData();
		_current.userMiscInfo.AllowToSave();
		_current.userMiscInfo.Save();
	}

	public void setPlayerBasicInfo(RespPlayer d)
	{
		if (d != null)
		{
			userBasicInfo = d;
		}
	}

	public void setPlayerStatus(RespPlayerInfo d)
	{
		if (d != null)
		{
			userStatus = d;
		}
	}

	public void setBox(RespPlayerBox[] box)
	{
		if (!(box == null))
		{
			userBoxData.setBox(box);
		}
	}

	public void setWeaponBox(RespWeapon[] box)
	{
		if (!(box == null))
		{
			userBoxData.setWeaponBox(box);
		}
	}

	public void setPoppetBox(RespPoppet[] box)
	{
		if (!(box == null))
		{
			userBoxData.setPoppetBox(box);
		}
	}

	public void setDeck(RespDeck[] decks)
	{
		if (!(decks == null))
		{
			userDeckData.set(decks);
		}
	}

	public void setDeck2(RespDeck2[] decks2)
	{
		if (!(decks2 == null))
		{
			userDeckData2.set(decks2);
		}
	}

	public void setPoppetDeck(RespPoppetDeck[] _poppetDecks)
	{
		if (!(_poppetDecks == null))
		{
			userPoppetDeckData.set(_poppetDecks);
		}
	}

	public void setFriendList(RespFriend[] friends)
	{
		if (!(friends == null))
		{
			userFriendListData.set(friends);
		}
	}

	public void setGuildPlayerRanking(RespCycleGuildPlayerRanking d)
	{
		if (d != null)
		{
			userRaidInfo.setGuildPlayerRanking(d);
		}
	}

	public void setGuildRanking(RespCycleGuildRanking d)
	{
		if (d != null)
		{
			userRaidInfo.setGuildRanking(d);
		}
	}

	public void setGuildPlayers(RespFriend[] d)
	{
		if (!(d == null))
		{
			userRaidInfo.setGuildPlayers(d);
		}
	}

	public void setRaidBattle(RespTCycleRaidBattle d)
	{
		if (d != null)
		{
			userRaidInfo.setRaidBattle(d);
		}
	}

	public void setChallengeQuestRanking(RespChallengeQuestRankings d)
	{
		if (d != null)
		{
			userChallengeInfo.setChallengeQuestRanking(d);
		}
	}

	public void setParty(RespParty d)
	{
		if (d != null)
		{
			userParty = d;
		}
	}

	public void setLoginBonus(RespPlayerLogin[] d)
	{
		_0024setLoginBonus_0024locals_002414397 _0024setLoginBonus_0024locals_0024 = new _0024setLoginBonus_0024locals_002414397();
		if (d == null)
		{
			return;
		}
		System.Collections.Generic.List<RespPlayerLogin> list = new System.Collections.Generic.List<RespPlayerLogin>();
		int num = 0;
		int length = d.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (d[RuntimeServices.NormalizeArrayIndex(d, index)].IsLoginBonus)
			{
				list.Add(d[RuntimeServices.NormalizeArrayIndex(d, index)]);
			}
		}
		int num2 = 0;
		int length2 = userLoginBonuses.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length2)
		{
			int index2 = num2;
			num2++;
			RespPlayerLogin[] array = userLoginBonuses;
			_0024setLoginBonus_0024locals_0024._0024entry = array[RuntimeServices.NormalizeArrayIndex(array, index2)];
			__UserData_setLoginBonus_0024callable128_0024157_17__ from = new _0024setLoginBonus_0024pred_00242799(_0024setLoginBonus_0024locals_0024).Invoke;
			if (list.Find(_0024adaptor_0024__UserData_setLoginBonus_0024callable128_0024157_17___0024Predicate_0024149.Adapt(from)) == null)
			{
				list.Add(_0024setLoginBonus_0024locals_0024._0024entry);
			}
		}
		userLoginBonuses = list.ToArray();
	}

	public void resetLoginBonusFlag()
	{
		userLoginBonuses = new RespPlayerLogin[0];
	}

	public int GetLevelExp(int lv)
	{
		return MPlayerParameters.GetLevelParam(lv).Experience;
	}

	private int CalcApRpBp(int now, int max, DateTime lastCalcTime, float sec, string log)
	{
		checked
		{
			int result;
			if (max <= now)
			{
				result = now;
			}
			else
			{
				DateTime utcNow = MerlinDateTime.UtcNow;
				int num = (int)((utcNow - lastCalcTime).TotalSeconds / (double)sec);
				if (num < 0)
				{
					num = 0;
				}
				int num2 = Mathf.Clamp(now + num, 0, max);
				result = num2;
			}
			return result;
		}
	}

	private void CalcEndTime()
	{
		checked
		{
			endApTime = BeforeApRecoveryDateTime.AddSeconds(ApRecoverySec * (float)(MaxAp - userStatus.Ap));
			endRpTime = BeforeRpRecoveryDateTime.AddSeconds(RpRecoverySec * (float)(MaxRp - userStatus.Rp));
			endBpTime = BeforeBpRecoveryDateTime.AddSeconds(BpRecoverySec * (float)(MaxBp - userStatus.Bp));
		}
	}

	private RespWeapon GetWeapons(int index)
	{
		RespWeapon[] currentWeapons = CurrentWeapons;
		if (currentWeapons == null || currentWeapons.Length <= index)
		{
			throw new AssertionFailedException("(wpns != null) and (len(wpns) > index)");
		}
		return currentWeapons[RuntimeServices.NormalizeArrayIndex(currentWeapons, index)];
	}

	private bool IsUsing(BoxId id, BoxId[] boxIds, bool doAssert)
	{
		int result;
		if (!id.IsValid)
		{
			result = 0;
		}
		else
		{
			if (boxIds != null)
			{
				int num = 0;
				int length = boxIds.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int num2 = num;
					num++;
					BoxId boxId = boxIds[RuntimeServices.NormalizeArrayIndex(boxIds, num2)];
					if (doAssert && !boxId.IsValid)
					{
						throw new AssertionFailedException(new StringBuilder("デッキの中身がnullです(").Append((object)num2).Append("/").Append((object)boxIds.Count())
							.Append(")")
							.ToString());
					}
					if (!RuntimeServices.EqualityOperator(id, boxId))
					{
						continue;
					}
					goto IL_00c2;
				}
			}
			result = 0;
		}
		goto IL_00d0;
		IL_00d0:
		return (byte)result != 0;
		IL_00c2:
		result = 1;
		goto IL_00d0;
	}

	public bool IsUsing(BoxId id)
	{
		BoxId[] array = new BoxId[0];
		array = ((!IsValidDeck2) ? CurrentDeck.ToApiBoxIdArray : userDeckData2.allBoxIds());
		int result;
		if (IsUsing(id, array, !IsValidDeck2))
		{
			result = 1;
		}
		else
		{
			array = userPoppetDeckData.allBoxIds();
			result = (IsUsing(id, array, doAssert: false) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool IsUsingWeapon(RespWeapon w)
	{
		if (w == null)
		{
			throw new AssertionFailedException("w が null です");
		}
		return IsUsingWeapon(w.Id);
	}

	public bool IsUsingWeapon(BoxId id)
	{
		return IsUsing(id);
	}

	public bool IsUsingPoppet(RespPoppet p)
	{
		return p != null && IsUsingPoppet(p.Id);
	}

	public bool IsUsingPoppet(BoxId id)
	{
		return IsUsing(id);
	}

	public bool IsFavorite(RespPlayerBox box)
	{
		if (!box.Id.IsValid)
		{
			goto IL_0064;
		}
		int result;
		if (box.IsWeapon)
		{
			result = (Current.userMiscInfo.weaponFavoriteData.isFavor(box.Id) ? 1 : 0);
		}
		else
		{
			if (!box.IsPoppet)
			{
				goto IL_0064;
			}
			result = (Current.userMiscInfo.poppetFavoriteData.isFavor(box.Id) ? 1 : 0);
		}
		goto IL_0065;
		IL_0064:
		result = 0;
		goto IL_0065;
		IL_0065:
		return (byte)result != 0;
	}

	public void SwitchFavorite(RespPlayerBox box)
	{
		if (IsFavorite(box))
		{
			OffFavorite(box);
		}
		else
		{
			OnFavorite(box);
		}
	}

	public void OnFavorite(RespPlayerBox box)
	{
		if (box.Id.IsValid)
		{
			if (box.IsWeapon)
			{
				Current.userMiscInfo.weaponFavoriteData.favor(box.Id);
			}
			if (box.IsPoppet)
			{
				Current.userMiscInfo.poppetFavoriteData.favor(box.Id);
			}
		}
	}

	public void OffFavorite(RespPlayerBox box)
	{
		if (box.Id.IsValid)
		{
			if (box.IsWeapon)
			{
				Current.userMiscInfo.weaponFavoriteData.delete(box.Id);
			}
			if (box.IsPoppet)
			{
				Current.userMiscInfo.poppetFavoriteData.delete(box.Id);
			}
			SetOld2NewItem(box);
		}
	}

	public bool IsNewItem(RespPlayerBox box)
	{
		UserData current = Current;
		if (!box.Id.IsValid)
		{
			goto IL_00a4;
		}
		int result;
		if (current.IsUsing(box.Id))
		{
			SetOld2NewItem(box);
			result = 0;
		}
		else
		{
			bool flag = current.userBoxData.haveItem(box.Id);
			bool flag2 = current.userMiscInfo.newItemData.find(box.Id);
			if (flag && !flag2)
			{
				result = 1;
			}
			else
			{
				if (!flag || !flag2)
				{
					if (!flag && flag2)
					{
						current.userMiscInfo.newItemData.delete(box.Id);
					}
					goto IL_00a4;
				}
				result = 0;
			}
		}
		goto IL_00a5;
		IL_00a4:
		result = 0;
		goto IL_00a5;
		IL_00a5:
		return (byte)result != 0;
	}

	public void SetOld2NewItem(RespPlayerBox box)
	{
		if (box.Id.IsValid)
		{
			Current.userMiscInfo.newItemData.look(box.Id);
		}
	}

	public void SetOld2AllNewItem()
	{
		int i = 0;
		RespPlayerBox[] allItems = Current.userBoxData.AllItems;
		for (int length = allItems.Length; i < length; i = checked(i + 1))
		{
			SetOld2NewItem(allItems[i]);
		}
	}

	public void RefreshNewItem()
	{
		UserData current = Current;
		string[] keys = current.userMiscInfo.newItemData.GetKeys();
		if (keys == null)
		{
			return;
		}
		System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
		int i = 0;
		string[] array = keys;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				bool flag = false;
				int j = 0;
				RespPlayerBox[] allItems = current.userBoxData.AllItems;
				for (int length2 = allItems.Length; j < length2; j++)
				{
					if (!(array[i] != allItems[j].Id.ToString()))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					list.Add(array[i]);
				}
			}
			foreach (string item in list)
			{
				current.userMiscInfo.newItemData.delete(item);
			}
		}
	}

	public bool haveWeapon(BoxId wpn_box_id)
	{
		return userBoxData.haveWeapon(wpn_box_id);
	}

	public bool havePoppet(BoxId ppt_box_id)
	{
		return userBoxData.havePoppet(ppt_box_id);
	}

	public bool haveMWeapon(MWeapons mstWep)
	{
		return userBoxData.haveMWeapon(mstWep);
	}

	public bool haveMPoppet(MPoppets mstPet)
	{
		return userBoxData.haveMPoppet(mstPet);
	}

	public RespWeapon boxWeapon(BoxId wpn_box_id)
	{
		return userBoxData.weapon(wpn_box_id);
	}

	public RespPoppet boxPoppet(BoxId ppt_box_id)
	{
		return userBoxData.poppet(ppt_box_id);
	}

	public RespWeapon boxMWeapon(MWeapons mstWep)
	{
		return userBoxData.boxMWeapon(mstWep);
	}

	public RespPoppet boxMPoppet(MPoppets mstPet)
	{
		return userBoxData.boxMPoppet(mstPet);
	}

	public RespFriend findFriend(int socialId)
	{
		return userFriendListData.find(socialId);
	}

	public void setFlag(string _n, int val)
	{
		string text = _n.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			userMiscInfo.flagData.set(text, val);
		}
	}

	public int getIntFlag(string _n, int @default)
	{
		int result;
		if (hasFlag(_n))
		{
			int num;
			try
			{
				num = RuntimeServices.UnboxInt32(userMiscInfo.flagData.get(_n));
			}
			catch (Exception)
			{
				num = @default;
			}
			result = num;
		}
		else
		{
			result = @default;
		}
		return result;
	}

	public void incFlag(string _n)
	{
		string text = _n.Trim();
		if (hasFlag(text))
		{
			try
			{
				int num = RuntimeServices.UnboxInt32(userMiscInfo.flagData.get(text));
				userMiscInfo.flagData.set(text, checked(num + 1));
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		userMiscInfo.flagData.set(text, 1);
	}

	public bool isFirstVisitScene(string sname)
	{
		string n = MFlagsUtil.SceneVisitFlagName(sname);
		return getIntFlag(n, 0) == 1;
	}

	public void setFlag(string _n)
	{
		string text = _n.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			userMiscInfo.flagData.set(text, 1);
		}
	}

	public void setFlag(MFlags f)
	{
		if (f != null)
		{
			setFlag(f.Progname);
		}
	}

	public void deleteFlag(string _n)
	{
		string text = _n.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			userMiscInfo.flagData.delete(text);
		}
	}

	public bool hasFlag(string _n)
	{
		string text = _n.Trim();
		return !string.IsNullOrEmpty(text) && userMiscInfo.flagData.hasFlag(text);
	}

	public void UpdateActPoint()
	{
	}

	public void UpdateRaidPoint()
	{
	}

	public int GetFriendGachaCount()
	{
		int num = 0;
		MSaleGachas[] all = MSaleGachas.All;
		int length = all.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				MGachas mGachaId = all[num].MGachaId;
				int price = all[num].Price;
				if (price > 0 && mGachaId != null && mGachaId.GachaTyepValue == EnumGachaTypeValues.Normal)
				{
					result = Fp / price;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return result;
	}
}
