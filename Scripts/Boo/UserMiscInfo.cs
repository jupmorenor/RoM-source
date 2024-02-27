using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;

[Serializable]
public class UserMiscInfo
{
	[Serializable]
	public enum QuestListArea
	{
		Normal,
		Special,
		Boost,
		Max
	}

	[Serializable]
	public class TreasureData
	{
		protected Hashtable treasure;

		public Hashtable Treasure
		{
			get
			{
				return treasure;
			}
			set
			{
				treasure = value;
			}
		}

		public TreasureData()
		{
			treasure = new Hashtable();
		}

		public string ToJson()
		{
			return NGUIJson.jsonEncodeEx(treasure, ignoreMultibyteCode: true);
		}

		public void FromJson(string json)
		{
			object obj = NGUIJson.jsonDecode(json);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			treasure = (Hashtable)obj;
		}

		public void Clear()
		{
			treasure.Clear();
		}

		public Hashtable get(string questId)
		{
			object result;
			if (string.IsNullOrEmpty(questId))
			{
				result = null;
			}
			else
			{
				object obj = ((!treasure.ContainsKey(questId)) ? null : treasure[questId]);
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				result = (Hashtable)obj;
			}
			return (Hashtable)result;
		}

		public void set(string questId, Hashtable itemGroupChildTable)
		{
			if (string.IsNullOrEmpty(questId) || itemGroupChildTable == null)
			{
				return;
			}
			object obj = treasure[questId];
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable hashtable = (Hashtable)obj;
			if (hashtable == null || RuntimeServices.EqualityOperator(hashtable, itemGroupChildTable))
			{
				treasure[questId] = itemGroupChildTable;
				return;
			}
			IEnumerator enumerator = itemGroupChildTable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string key = (string)obj2;
				int num = 0;
				if (hashtable.ContainsKey(key))
				{
					num = RuntimeServices.UnboxInt32(hashtable[key]);
				}
				int num2 = RuntimeServices.UnboxInt32(itemGroupChildTable[key]);
				hashtable[key] = checked(num + num2);
			}
		}
	}

	[Serializable]
	public class ResultShortcutFlagData : FlagData
	{
		public readonly int Disabled;

		public readonly int Enabled;

		public ResultShortcutFlagData()
		{
			Disabled = 1;
			Enabled = 2;
		}

		public void Enable(string name)
		{
			set(name, Enabled);
		}

		public void Disable(string name)
		{
			set(name, Disabled);
		}

		public bool IsEnabled(string name)
		{
			return getInt(name) == Enabled;
		}
	}

	[Serializable]
	public class FlagData
	{
		protected Hashtable flags;

		protected int conditionNumber;

		public Hashtable Flags
		{
			get
			{
				return flags;
			}
			set
			{
				flags = value;
			}
		}

		public int ConditionNumber => conditionNumber;

		public FlagData()
		{
			flags = new Hashtable();
		}

		public string ToJson()
		{
			return NGUIJson.jsonEncodeEx(flags, ignoreMultibyteCode: true);
		}

		public void FromJson(string json)
		{
			object obj = NGUIJson.jsonDecode(json);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			flags = (Hashtable)obj;
			if (flags == null)
			{
				flags = new Hashtable();
			}
		}

		public int Count()
		{
			return (flags != null) ? flags.Count : 0;
		}

		public int Clear()
		{
			if (flags != null)
			{
				flags.Clear();
			}
			return conditionNumber;
		}

		public object get(string name)
		{
			return string.IsNullOrEmpty(name) ? null : ((flags == null) ? null : ((!flags.ContainsKey(name)) ? null : flags[name]));
		}

		public int getInt(string name)
		{
			return string.IsNullOrEmpty(name) ? (-1) : ((flags == null) ? (-1) : ((!flags.ContainsKey(name)) ? (-1) : RuntimeServices.UnboxInt32(flags[name])));
		}

		public int set(string name, object value)
		{
			int result;
			if (string.IsNullOrEmpty(name))
			{
				result = conditionNumber;
			}
			else
			{
				if (flags == null)
				{
					flags = new Hashtable();
				}
				if (equal(name, value))
				{
					result = conditionNumber;
				}
				else
				{
					flags[name] = value;
					updateCondition();
					result = conditionNumber;
				}
			}
			return result;
		}

		public int look(string name)
		{
			int result;
			if (!string.IsNullOrEmpty(name))
			{
				if (flags == null)
				{
					flags = new Hashtable();
				}
				if (!flags.ContainsKey(name))
				{
					updateCondition();
					flags[name] = 0;
				}
				result = conditionNumber;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int play(string name)
		{
			int result;
			if (!string.IsNullOrEmpty(name))
			{
				if (flags == null)
				{
					flags = new Hashtable();
				}
				if (!flags.ContainsKey(name))
				{
					flags[name] = 0;
				}
				int num = RuntimeServices.UnboxInt32(flags[name]);
				flags[name] = checked(num + 1);
				updateCondition();
				result = conditionNumber;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int delete(string name)
		{
			int result;
			if (string.IsNullOrEmpty(name))
			{
				result = conditionNumber;
			}
			else if (flags == null)
			{
				result = conditionNumber;
			}
			else
			{
				if (flags.ContainsKey(name))
				{
					updateCondition();
					flags.Remove(name);
				}
				result = conditionNumber;
			}
			return result;
		}

		public int deleteAllStartWith(string name)
		{
			int result;
			if (string.IsNullOrEmpty(name))
			{
				result = conditionNumber;
			}
			else if (flags == null)
			{
				result = conditionNumber;
			}
			else
			{
				IEnumerator enumerator = flags.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string text = (string)obj;
					if (text.StartsWith(name))
					{
						flags.Remove(text);
						updateCondition();
					}
				}
				result = conditionNumber;
			}
			return result;
		}

		public int remove(string name)
		{
			return delete(name);
		}

		public bool equal(string name, object value)
		{
			return !string.IsNullOrEmpty(name) && flags != null && flags.ContainsKey(name) && RuntimeServices.EqualityOperator(flags[name], value);
		}

		public bool hasFlag(string name)
		{
			return !string.IsNullOrEmpty(name) && flags != null && flags.ContainsKey(name);
		}

		public bool isTrueOr1(string name)
		{
			int num;
			if (flags == null)
			{
				num = 0;
			}
			else if (flags.ContainsKey(name))
			{
				num = (RuntimeServices.EqualityOperator(flags[name], true) ? 1 : 0);
				if (num == 0)
				{
					num = (RuntimeServices.EqualityOperator(flags[name], 1) ? 1 : 0);
				}
			}
			else
			{
				num = 0;
			}
			return (byte)num != 0;
		}

		public void updateCondition()
		{
			checked
			{
				conditionNumber++;
			}
		}
	}

	[Serializable]
	public class WeponaBookData : FlagData
	{
		public int look(MWeapons weapon)
		{
			return (weapon != null) ? look(weapon.Id.ToString()) : conditionNumber;
		}

		public bool isLook(MWeapons weapon)
		{
			return weapon != null && hasFlag(weapon.Id.ToString());
		}

		public int have(MWeapons weapon)
		{
			return (weapon != null) ? play(weapon.Id.ToString()) : conditionNumber;
		}

		public bool isHave(MWeapons weapon)
		{
			return weapon != null && getInt(weapon.Id.ToString()) > 0;
		}

		public int know(MWeapons weapon)
		{
			return look(weapon);
		}

		public bool isKnow(MWeapons weapon)
		{
			return isLook(weapon);
		}
	}

	[Serializable]
	public class PoppetBookData : FlagData
	{
		public int look(MPoppets poppet)
		{
			return (poppet != null) ? look(poppet.Id.ToString()) : conditionNumber;
		}

		public bool isLook(MPoppets poppet)
		{
			return poppet != null && hasFlag(poppet.Id.ToString());
		}

		public int have(MPoppets poppet)
		{
			return (poppet != null) ? play(poppet.Id.ToString()) : conditionNumber;
		}

		public bool isHave(MPoppets poppet)
		{
			return poppet != null && getInt(poppet.Id.ToString()) > 0;
		}

		public int know(MPoppets poppet)
		{
			return look(poppet);
		}

		public bool isKnow(MPoppets poppet)
		{
			return isLook(poppet);
		}
	}

	[Serializable]
	public class FavoriteData : FlagData
	{
		public int favor(BoxId id)
		{
			return id.IsValid ? look(id.ToString()) : conditionNumber;
		}

		public bool isFavor(BoxId id)
		{
			return id.IsValid && hasFlag(id.ToString());
		}

		public int delete(BoxId id)
		{
			return id.IsValid ? delete(id.ToString()) : conditionNumber;
		}
	}

	[Serializable]
	public class QuestData : FlagData
	{
		[Serializable]
		public enum STATE
		{
			None = -1,
			Discover,
			Look,
			Play,
			Clear
		}

		public int discover(string questId)
		{
			return set(questId, 0);
		}

		public new int look(string questId)
		{
			return set(questId, 1);
		}

		public new int play(string questId)
		{
			return set(questId, 2);
		}

		public int clear(string questId)
		{
			return set(questId, 3);
		}

		public int discover(int questId)
		{
			return set(questId.ToString(), 0);
		}

		public bool isDiscover(int questId)
		{
			return getState(questId) >= STATE.Discover;
		}

		public int look(int questId)
		{
			return set(questId.ToString(), 1);
		}

		public bool isLook(int questId)
		{
			return getState(questId) >= STATE.Look;
		}

		public int play(int questId)
		{
			return set(questId.ToString(), 2);
		}

		public bool isPlay(int questId)
		{
			return getState(questId) >= STATE.Play;
		}

		public int clear(int questId)
		{
			return set(questId.ToString(), 3);
		}

		public bool isClear(int questId)
		{
			return getState(questId) >= STATE.Clear;
		}

		public STATE getState(int questId)
		{
			return (STATE)getInt(questId.ToString());
		}

		public int delete(int questId)
		{
			return delete(questId.ToString());
		}

		public bool hasDiscover()
		{
			IEnumerator enumerator = flags.Keys.GetEnumerator();
			int result;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (RuntimeServices.EqualityOperator(flags[current], 0))
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

		public bool hasNoClear()
		{
			IEnumerator enumerator = flags.Keys.GetEnumerator();
			int result;
			while (true)
			{
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (!RuntimeServices.EqualityOperator(flags[current], 3))
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

	[Serializable]
	public class NewItemData : FlagData
	{
		public bool find(BoxId id)
		{
			return id.IsValid && hasFlag(id.ToString());
		}

		public int look(BoxId id)
		{
			return id.IsValid ? look(id.ToString()) : conditionNumber;
		}

		public int delete(BoxId id)
		{
			return id.IsValid ? delete(id.ToString()) : conditionNumber;
		}

		public string[] GetKeys()
		{
			return (flags != null) ? ((string[])Builtins.array(typeof(string), flags.Keys)) : null;
		}
	}

	[Serializable]
	public class RaidData
	{
		private Hashtable commentTable;

		private string lastDiscoverRaidDiscoverDate;

		private string lastBattleRaidDiscoverDate;

		private int lastRaidCycleId;

		public string LastDiscoverRaidDiscoverDate
		{
			get
			{
				return lastDiscoverRaidDiscoverDate;
			}
			set
			{
				lastDiscoverRaidDiscoverDate = value;
			}
		}

		public string LastBattleRaidDiscoverDate
		{
			get
			{
				return lastBattleRaidDiscoverDate;
			}
			set
			{
				lastBattleRaidDiscoverDate = value;
			}
		}

		public int LastRaidCycleId
		{
			get
			{
				return lastRaidCycleId;
			}
			set
			{
				lastRaidCycleId = value;
			}
		}

		public RaidData()
		{
			commentTable = new Hashtable();
		}

		public Hashtable ToHash()
		{
			Hashtable hashtable = new Hashtable();
			hashtable["commentTable"] = commentTable;
			hashtable["lastDiscoverRaidDiscoverDate"] = lastDiscoverRaidDiscoverDate;
			hashtable["lastBattleRaidDiscoverDate"] = lastBattleRaidDiscoverDate;
			hashtable["lastRaidCycleId"] = lastRaidCycleId;
			return hashtable;
		}

		public static RaidData FromHash(Hashtable srcHash)
		{
			Hashtable hashtable = null;
			RaidData raidData = new RaidData();
			if (srcHash != null)
			{
				if (srcHash.ContainsKey("commentTable"))
				{
					object obj = srcHash["commentTable"];
					if (!(obj is Hashtable))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
					}
					hashtable = (Hashtable)obj;
				}
				if (srcHash.ContainsKey("lastDiscoverRaidDiscoverDate"))
				{
					object obj2 = srcHash["lastDiscoverRaidDiscoverDate"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					raidData.LastDiscoverRaidDiscoverDate = (string)obj2;
				}
				if (srcHash.ContainsKey("lastBattleRaidDiscoverDate"))
				{
					object obj3 = srcHash["lastBattleRaidDiscoverDate"];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					raidData.LastBattleRaidDiscoverDate = (string)obj3;
				}
				if (srcHash.ContainsKey("lastRaidCycleId"))
				{
					raidData.lastRaidCycleId = RuntimeServices.UnboxInt32(srcHash["lastRaidCycleId"]);
				}
			}
			if (hashtable != null)
			{
				IEnumerator enumerator = hashtable.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					if (hashtable[current] is ArrayList arrayList)
					{
						System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
						IEnumerator enumerator2 = arrayList.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							object current2 = enumerator2.Current;
							list.Add(RuntimeServices.UnboxInt32(current2));
						}
						raidData.commentTable[current] = list.ToArray();
					}
				}
			}
			return raidData;
		}

		private void InitializeCommentTable()
		{
			if (commentTable.Count == 0)
			{
				Put(EnumRaidWordTypes.Start, MRaidWords.getWords(EnumRaidWordTypes.Start)[0].Id);
				Put(EnumRaidWordTypes.Skill, MRaidWords.getWords(EnumRaidWordTypes.Skill)[0].Id);
				Put(EnumRaidWordTypes.Damage, MRaidWords.getWords(EnumRaidWordTypes.Damage)[0].Id);
				Put(EnumRaidWordTypes.Dead, MRaidWords.getWords(EnumRaidWordTypes.Dead)[0].Id);
				Put(EnumRaidWordTypes.KillBoss, MRaidWords.getWords(EnumRaidWordTypes.KillBoss)[0].Id);
				Put(EnumRaidWordTypes.Welcome, MRaidWords.getWords(EnumRaidWordTypes.Welcome)[0].Id);
			}
		}

		public void Put(EnumRaidWordTypes key, int id)
		{
			Put(key, new int[1] { id });
		}

		public void Put(EnumRaidWordTypes key, int[] ids)
		{
			commentTable[key.ToString()] = ids;
		}

		public int[] Get(EnumRaidWordTypes key)
		{
			if (commentTable.Count == 0)
			{
				InitializeCommentTable();
			}
			object obj = commentTable[key.ToString()];
			if (!(obj is int[]))
			{
				obj = RuntimeServices.Coerce(obj, typeof(int[]));
			}
			return (int[])obj;
		}
	}

	[Serializable]
	public class DiaryData : FlagData
	{
		public int getDiaryState(MStoryBooks storyBook)
		{
			return (storyBook != null) ? getInt(storyBook.Progname) : (-1);
		}

		public void openDiary(MStoryBooks storyBook)
		{
			if (storyBook != null)
			{
				look(storyBook.Progname);
			}
		}

		public void readDiary(MStoryBooks storyBook)
		{
			if (storyBook != null)
			{
				play(storyBook.Progname);
			}
		}

		public void Convert()
		{
			int i = 0;
			MStoryBooks[] all = MStoryBooks.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (all[i] == null)
				{
					continue;
				}
				string key = all[i].Id.ToString();
				if (flags.ContainsKey(key))
				{
					string progname = all[i].Progname;
					if (!string.IsNullOrEmpty(progname) && !flags.ContainsKey(progname))
					{
						object value = flags[key];
						flags[progname] = value;
						flags.Remove(key);
					}
				}
			}
		}
	}

	public bool bgmLoad;

	public QuestMenuBase.QUEST_INFO_TYPE questInfoType;

	public WorldQuestMain.QUEST_LIST_TYPE[] questListType;

	public bool autoRecColosseum;

	public int tutorialStep;

	public int saveCount;

	[NonSerialized]
	public const int version = 2;

	private bool isAbleToSave;

	public TreasureData treasureData;

	public QuestData questData;

	public FlagData areaData;

	public FlagData flagData;

	public DiaryData diaryData;

	public FlagData storyData;

	public WeponaBookData weaponBookData;

	public PoppetBookData poppetBookData;

	public FavoriteData weaponFavoriteData;

	public FavoriteData poppetFavoriteData;

	public FavoriteData friendFavoriteData;

	public UserAlreadyReadData alreadyReadData;

	public RaidData raidData;

	public UserConfigData configData;

	public UserTeamNotifyData teamNotifyData;

	public NewItemData newItemData;

	public FlagData sortData;

	public ResultShortcutFlagData resultShortcutData;

	[NonSerialized]
	private static __UserMiscInfo_postLoadEvent_0024callable73_00241616_35__ _0024event_0024postLoadEvent;

	public RACE_TYPE playerRace
	{
		get
		{
			return (!flagData.hasFlag("xPlayerIsTensi")) ? RACE_TYPE.Akuma : RACE_TYPE.Tensi;
		}
		set
		{
			if (value == RACE_TYPE.Tensi)
			{
				flagData.set("xPlayerIsTensi", 1);
			}
			else
			{
				flagData.remove("xPlayerIsTensi");
			}
		}
	}

	public bool IsAbleToSave => isAbleToSave;

	public static event __UserMiscInfo_postLoadEvent_0024callable73_00241616_35__ postLoadEvent
	{
		add
		{
			_0024event_0024postLoadEvent = (__UserMiscInfo_postLoadEvent_0024callable73_00241616_35__)Delegate.Combine(_0024event_0024postLoadEvent, value);
		}
		remove
		{
			_0024event_0024postLoadEvent = (__UserMiscInfo_postLoadEvent_0024callable73_00241616_35__)Delegate.Remove(_0024event_0024postLoadEvent, value);
		}
	}

	public UserMiscInfo()
	{
		questInfoType = QuestMenuBase.QUEST_INFO_TYPE.MONSTER;
		questListType = new WorldQuestMain.QUEST_LIST_TYPE[3]
		{
			WorldQuestMain.QUEST_LIST_TYPE.None,
			WorldQuestMain.QUEST_LIST_TYPE.None,
			WorldQuestMain.QUEST_LIST_TYPE.None
		};
		treasureData = new TreasureData();
		questData = new QuestData();
		areaData = new FlagData();
		flagData = new FlagData();
		diaryData = new DiaryData();
		storyData = new FlagData();
		weaponBookData = new WeponaBookData();
		poppetBookData = new PoppetBookData();
		weaponFavoriteData = new FavoriteData();
		poppetFavoriteData = new FavoriteData();
		friendFavoriteData = new FavoriteData();
		alreadyReadData = new UserAlreadyReadData();
		raidData = new RaidData();
		configData = new UserConfigData();
		teamNotifyData = new UserTeamNotifyData();
		newItemData = new NewItemData();
		sortData = new FlagData();
		resultShortcutData = new ResultShortcutFlagData();
	}

	[SpecialName]
	protected internal static void raise_postLoadEvent(UserMiscInfo arg0)
	{
		_0024event_0024postLoadEvent?.Invoke(arg0);
	}

	public void Clear()
	{
		treasureData.Clear();
		questData.Clear();
		areaData.Clear();
		flagData.Clear();
		diaryData.Clear();
		storyData.Clear();
		weaponBookData.Clear();
		poppetBookData.Clear();
		weaponFavoriteData.Clear();
		poppetFavoriteData.Clear();
		friendFavoriteData.Clear();
		alreadyReadData.Clear();
		raidData = new RaidData();
		bgmLoad = false;
		questInfoType = QuestMenuBase.QUEST_INFO_TYPE.MONSTER;
		WorldQuestMain.QUEST_LIST_TYPE[] array = questListType;
		array[RuntimeServices.NormalizeArrayIndex(array, 0)] = WorldQuestMain.QUEST_LIST_TYPE.None;
		WorldQuestMain.QUEST_LIST_TYPE[] array2 = questListType;
		array2[RuntimeServices.NormalizeArrayIndex(array2, 1)] = WorldQuestMain.QUEST_LIST_TYPE.None;
		WorldQuestMain.QUEST_LIST_TYPE[] array3 = questListType;
		array3[RuntimeServices.NormalizeArrayIndex(array3, 2)] = WorldQuestMain.QUEST_LIST_TYPE.None;
		configData = new UserConfigData();
		teamNotifyData = new UserTeamNotifyData();
		autoRecColosseum = false;
		tutorialStep = 0;
		saveCount = 0;
		newItemData.Clear();
		sortData.Clear();
		isAbleToSave = false;
		resultShortcutData.Clear();
	}

	public void AllowToSave()
	{
		isAbleToSave = true;
	}

	public bool Load()
	{
		isAbleToSave = false;
		string text = ObjUtilModule.LoadString("riseofmana.dat");
		int result;
		if (string.IsNullOrEmpty(text))
		{
			result = 0;
		}
		else
		{
			Hashtable ht = cryptedStringToHash(text);
			if (getSavedVersion(ht) == 0)
			{
				result = (LoadFromHashtable(ht) ? 1 : 0);
			}
			else
			{
				string hash = ApiSigner.GetHash(text);
				string text2 = ObjUtilModule.LoadString("riseofmana2.dat");
				if (hash.CompareTo(text2) == 0)
				{
					ObjUtilModule.SaveString("riseofmana.bak", text);
					ObjUtilModule.SaveString("riseofmana2.bak", text2);
					result = (LoadFromHashtable(cryptedStringToHash(text)) ? 1 : 0);
				}
				else
				{
					string text3 = ObjUtilModule.LoadString("riseofmana.bak");
					hash = ApiSigner.GetHash(text3);
					text2 = ObjUtilModule.LoadString("riseofmana2.bak");
					result = ((hash.CompareTo(text2) == 0 && LoadFromHashtable(cryptedStringToHash(text3))) ? 1 : 0);
				}
			}
		}
		return (byte)result != 0;
	}

	public Hashtable cryptedStringToHash(string jsonString)
	{
		string text = Crypt.Decrypt(jsonString);
		object result;
		if (!string.IsNullOrEmpty(text))
		{
			object obj = NGUIJson.jsonDecode(text);
			result = ((!(obj is Hashtable)) ? null : (obj as Hashtable));
		}
		else
		{
			result = null;
		}
		return (Hashtable)result;
	}

	public int getSavedVersion(Hashtable ht)
	{
		int result;
		if (ht == null)
		{
			result = 0;
		}
		else
		{
			int result2 = 0;
			if (ht.ContainsKey("version"))
			{
				object obj = ht["version"];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				int.TryParse((string)obj, out result2);
			}
			result = result2;
		}
		return result;
	}

	public bool LoadFromString(string loadString)
	{
		int result;
		if (string.IsNullOrEmpty(loadString))
		{
			result = 0;
		}
		else
		{
			string json = Crypt.Decrypt(loadString);
			object obj = NGUIJson.jsonDecode(json);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable ht = (Hashtable)obj;
			result = (LoadFromHashtable(ht) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool LoadFromStringWidthMd5(string loadString)
	{
		isAbleToSave = false;
		int result;
		if (string.IsNullOrEmpty(loadString))
		{
			result = 0;
		}
		else
		{
			string json = Crypt.Decrypt(loadString);
			object obj = NGUIJson.jsonDecode(json);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable hashtable = (Hashtable)obj;
			if (hashtable == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				if (hashtable.ContainsKey("version"))
				{
					object obj2 = hashtable["version"];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					num = int.Parse((string)obj2);
				}
				if (num < 1)
				{
					result = (LoadFromHashtable(hashtable) ? 1 : 0);
				}
				else
				{
					string strB = string.Empty;
					if (hashtable.ContainsKey("md5"))
					{
						object obj3 = hashtable["md5"];
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						strB = (string)obj3;
					}
					string text = string.Empty;
					if (hashtable.ContainsKey("data"))
					{
						object obj4 = hashtable["data"];
						if (!(obj4 is string))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(string));
						}
						text = (string)obj4;
					}
					if (string.IsNullOrEmpty(text))
					{
						result = 0;
					}
					else
					{
						string hash = ApiSigner.GetHash(text);
						if (hash.CompareTo(strB) == 0)
						{
							json = Crypt.Decrypt(text);
							object obj5 = NGUIJson.jsonDecode(json);
							if (!(obj5 is Hashtable))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(Hashtable));
							}
							hashtable = (Hashtable)obj5;
							if (hashtable != null)
							{
								result = (LoadFromHashtable(hashtable) ? 1 : 0);
								goto IL_0193;
							}
						}
						result = 0;
					}
				}
			}
		}
		goto IL_0193;
		IL_0193:
		return (byte)result != 0;
	}

	public bool LoadFromHashtable(Hashtable ht)
	{
		int result;
		if (ht == null)
		{
			result = 0;
		}
		else
		{
			if (ht.ContainsKey("treasureData"))
			{
				TreasureData obj = treasureData;
				object obj2 = ht["treasureData"];
				if (!(obj2 is Hashtable))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
				}
				obj.Treasure = (Hashtable)obj2;
			}
			if (ht.ContainsKey("questData"))
			{
				QuestData obj3 = questData;
				object obj4 = ht["questData"];
				if (!(obj4 is Hashtable))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(Hashtable));
				}
				obj3.Flags = (Hashtable)obj4;
			}
			if (ht.ContainsKey("areaData"))
			{
				FlagData obj5 = areaData;
				object obj6 = ht["areaData"];
				if (!(obj6 is Hashtable))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(Hashtable));
				}
				obj5.Flags = (Hashtable)obj6;
			}
			if (ht.ContainsKey("flagData"))
			{
				FlagData obj7 = flagData;
				object obj8 = ht["flagData"];
				if (!(obj8 is Hashtable))
				{
					obj8 = RuntimeServices.Coerce(obj8, typeof(Hashtable));
				}
				obj7.Flags = (Hashtable)obj8;
			}
			if (ht.ContainsKey("diaryData"))
			{
				DiaryData obj9 = diaryData;
				object obj10 = ht["diaryData"];
				if (!(obj10 is Hashtable))
				{
					obj10 = RuntimeServices.Coerce(obj10, typeof(Hashtable));
				}
				obj9.Flags = (Hashtable)obj10;
			}
			if (ht.ContainsKey("storyData"))
			{
				FlagData obj11 = storyData;
				object obj12 = ht["storyData"];
				if (!(obj12 is Hashtable))
				{
					obj12 = RuntimeServices.Coerce(obj12, typeof(Hashtable));
				}
				obj11.Flags = (Hashtable)obj12;
			}
			if (ht.ContainsKey("weaponBookData"))
			{
				WeponaBookData weponaBookData = weaponBookData;
				object obj13 = ht["weaponBookData"];
				if (!(obj13 is Hashtable))
				{
					obj13 = RuntimeServices.Coerce(obj13, typeof(Hashtable));
				}
				weponaBookData.Flags = (Hashtable)obj13;
			}
			if (ht.ContainsKey("poppetBookData"))
			{
				PoppetBookData obj14 = poppetBookData;
				object obj15 = ht["poppetBookData"];
				if (!(obj15 is Hashtable))
				{
					obj15 = RuntimeServices.Coerce(obj15, typeof(Hashtable));
				}
				obj14.Flags = (Hashtable)obj15;
			}
			if (ht.ContainsKey("weaponFavoriteData"))
			{
				FavoriteData favoriteData = weaponFavoriteData;
				object obj16 = ht["weaponFavoriteData"];
				if (!(obj16 is Hashtable))
				{
					obj16 = RuntimeServices.Coerce(obj16, typeof(Hashtable));
				}
				favoriteData.Flags = (Hashtable)obj16;
			}
			if (ht.ContainsKey("poppetFavoriteData"))
			{
				FavoriteData favoriteData2 = poppetFavoriteData;
				object obj17 = ht["poppetFavoriteData"];
				if (!(obj17 is Hashtable))
				{
					obj17 = RuntimeServices.Coerce(obj17, typeof(Hashtable));
				}
				favoriteData2.Flags = (Hashtable)obj17;
			}
			if (ht.ContainsKey("friendFavoriteData"))
			{
				FavoriteData favoriteData3 = friendFavoriteData;
				object obj18 = ht["friendFavoriteData"];
				if (!(obj18 is Hashtable))
				{
					obj18 = RuntimeServices.Coerce(obj18, typeof(Hashtable));
				}
				favoriteData3.Flags = (Hashtable)obj18;
			}
			if (ht.ContainsKey("bgmLoad"))
			{
				object obj19 = ht["bgmLoad"];
				if (!(obj19 is string))
				{
					obj19 = RuntimeServices.Coerce(obj19, typeof(string));
				}
				bgmLoad = bool.Parse((string)obj19);
			}
			if (ht.ContainsKey("questInfoType"))
			{
				Type typeFromHandle = typeof(QuestMenuBase.QUEST_INFO_TYPE);
				object obj20 = ht["questInfoType"];
				if (!(obj20 is string))
				{
					obj20 = RuntimeServices.Coerce(obj20, typeof(string));
				}
				questInfoType = (QuestMenuBase.QUEST_INFO_TYPE)Enum.Parse(typeFromHandle, (string)obj20, ignoreCase: true);
			}
			if (ht.ContainsKey("questListType"))
			{
				WorldQuestMain.QUEST_LIST_TYPE[] array = questListType;
				int num = RuntimeServices.NormalizeArrayIndex(array, 0);
				Type typeFromHandle2 = typeof(WorldQuestMain.QUEST_LIST_TYPE);
				object obj21 = ht["questListType"];
				if (!(obj21 is string))
				{
					obj21 = RuntimeServices.Coerce(obj21, typeof(string));
				}
				array[num] = (WorldQuestMain.QUEST_LIST_TYPE)Enum.Parse(typeFromHandle2, (string)obj21, ignoreCase: true);
			}
			if (ht.ContainsKey("questListTypeSpecial"))
			{
				WorldQuestMain.QUEST_LIST_TYPE[] array2 = questListType;
				int num2 = RuntimeServices.NormalizeArrayIndex(array2, 1);
				Type typeFromHandle3 = typeof(WorldQuestMain.QUEST_LIST_TYPE);
				object obj22 = ht["questListTypeSpecial"];
				if (!(obj22 is string))
				{
					obj22 = RuntimeServices.Coerce(obj22, typeof(string));
				}
				array2[num2] = (WorldQuestMain.QUEST_LIST_TYPE)Enum.Parse(typeFromHandle3, (string)obj22, ignoreCase: true);
			}
			if (ht.ContainsKey("questListTypeBoost"))
			{
				WorldQuestMain.QUEST_LIST_TYPE[] array3 = questListType;
				int num3 = RuntimeServices.NormalizeArrayIndex(array3, 2);
				Type typeFromHandle4 = typeof(WorldQuestMain.QUEST_LIST_TYPE);
				object obj23 = ht["questListTypeBoost"];
				if (!(obj23 is string))
				{
					obj23 = RuntimeServices.Coerce(obj23, typeof(string));
				}
				array3[num3] = (WorldQuestMain.QUEST_LIST_TYPE)Enum.Parse(typeFromHandle4, (string)obj23, ignoreCase: true);
			}
			alreadyReadData = UserAlreadyReadData.FromHash(ht["alreadyReadData"] as Hashtable);
			raidData = RaidData.FromHash(ht["raidData"] as Hashtable);
			if (ht.ContainsKey("configData"))
			{
				configData = UserConfigData.FromHash(ht["configData"] as Hashtable);
			}
			if (ht.ContainsKey("teamNotifyData"))
			{
				teamNotifyData = UserTeamNotifyData.FromHash(ht["teamNotifyData"] as Hashtable);
			}
			if (ht.ContainsKey("autoRecColosseum"))
			{
				object obj24 = ht["autoRecColosseum"];
				if (!(obj24 is string))
				{
					obj24 = RuntimeServices.Coerce(obj24, typeof(string));
				}
				autoRecColosseum = bool.Parse((string)obj24);
			}
			if (ht.ContainsKey("tutorialStep"))
			{
				object obj25 = ht["tutorialStep"];
				if (!(obj25 is string))
				{
					obj25 = RuntimeServices.Coerce(obj25, typeof(string));
				}
				tutorialStep = int.Parse((string)obj25);
			}
			if (ht.ContainsKey("newItemData"))
			{
				NewItemData obj26 = newItemData;
				object obj27 = ht["newItemData"];
				if (!(obj27 is Hashtable))
				{
					obj27 = RuntimeServices.Coerce(obj27, typeof(Hashtable));
				}
				obj26.Flags = (Hashtable)obj27;
			}
			if (ht.ContainsKey("sortData"))
			{
				FlagData obj28 = sortData;
				object obj29 = ht["sortData"];
				if (!(obj29 is Hashtable))
				{
					obj29 = RuntimeServices.Coerce(obj29, typeof(Hashtable));
				}
				obj28.Flags = (Hashtable)obj29;
			}
			if (ht.ContainsKey("saveCount"))
			{
				object obj30 = ht["saveCount"];
				if (!(obj30 is string))
				{
					obj30 = RuntimeServices.Coerce(obj30, typeof(string));
				}
				saveCount = int.Parse((string)obj30);
			}
			if (ht.ContainsKey("resultShortcutData"))
			{
				ResultShortcutFlagData resultShortcutFlagData = resultShortcutData;
				object obj31 = ht["resultShortcutData"];
				if (!(obj31 is Hashtable))
				{
					obj31 = RuntimeServices.Coerce(obj31, typeof(Hashtable));
				}
				resultShortcutFlagData.Flags = (Hashtable)obj31;
			}
			int num4 = 0;
			if (ht.ContainsKey("version"))
			{
				object obj32 = ht["version"];
				if (!(obj32 is string))
				{
					obj32 = RuntimeServices.Coerce(obj32, typeof(string));
				}
				num4 = int.Parse((string)obj32);
			}
			if (num4 < 2)
			{
				diaryData.Convert();
			}
			if (_0024event_0024postLoadEvent != null)
			{
				raise_postLoadEvent(this);
				_0024event_0024postLoadEvent = null;
			}
			isAbleToSave = true;
			result = 1;
		}
		return (byte)result != 0;
	}

	public void Save()
	{
		checked
		{
			if (isAbleToSave)
			{
				saveCount++;
				string text = ToSaveString();
				string hash = ApiSigner.GetHash(text);
				bool flag = ObjUtilModule.SaveString("riseofmana.dat", text);
				bool flag2 = ObjUtilModule.SaveString("riseofmana2.dat", hash);
			}
		}
	}

	public void Backup()
	{
		if (isAbleToSave)
		{
			string text = ToSaveString();
			string hash = ApiSigner.GetHash(text);
			bool flag = ObjUtilModule.SaveString("riseofmana.bak", text);
			bool flag2 = ObjUtilModule.SaveString("riseofmana2.bak", hash);
		}
	}

	public string ToSaveString()
	{
		Hashtable json = ToHashtable(null);
		string src = NGUIJson.jsonEncodeEx(json, ignoreMultibyteCode: true);
		return Crypt.Encrypt(src);
	}

	public string ToSaveStringWithMd5()
	{
		Hashtable json = ToHashtable(null);
		string src = NGUIJson.jsonEncodeEx(json, ignoreMultibyteCode: true);
		src = Crypt.Encrypt(src);
		string hash = ApiSigner.GetHash(src);
		Hashtable hashtable = new Hashtable();
		hashtable["version"] = 2.ToString();
		hashtable["md5"] = hash;
		hashtable["data"] = src;
		src = NGUIJson.jsonEncodeEx(hashtable, ignoreMultibyteCode: true);
		return Crypt.Encrypt(src);
	}

	public Hashtable ToHashtable(string setMd5)
	{
		Hashtable hashtable = new Hashtable();
		hashtable["treasureData"] = treasureData.Treasure;
		hashtable["questData"] = questData.Flags;
		hashtable["areaData"] = areaData.Flags;
		hashtable["flagData"] = flagData.Flags;
		hashtable["diaryData"] = diaryData.Flags;
		hashtable["storyData"] = storyData.Flags;
		hashtable["weaponBookData"] = weaponBookData.Flags;
		hashtable["poppetBookData"] = poppetBookData.Flags;
		hashtable["weaponFavoriteData"] = weaponFavoriteData.Flags;
		hashtable["poppetFavoriteData"] = poppetFavoriteData.Flags;
		hashtable["friendFavoriteData"] = friendFavoriteData.Flags;
		hashtable["bgmLoad"] = bgmLoad.ToString();
		hashtable["questInfoType"] = questInfoType.ToString();
		WorldQuestMain.QUEST_LIST_TYPE[] array = questListType;
		hashtable["questListType"] = array[RuntimeServices.NormalizeArrayIndex(array, 0)].ToString();
		WorldQuestMain.QUEST_LIST_TYPE[] array2 = questListType;
		hashtable["questListTypeSpecial"] = array2[RuntimeServices.NormalizeArrayIndex(array2, 1)].ToString();
		WorldQuestMain.QUEST_LIST_TYPE[] array3 = questListType;
		hashtable["questListTypeBoost"] = array3[RuntimeServices.NormalizeArrayIndex(array3, 2)].ToString();
		hashtable["alreadyReadData"] = alreadyReadData.ToHash();
		hashtable["raidData"] = raidData.ToHash();
		hashtable["configData"] = configData.ToHash();
		hashtable["teamNotifyData"] = teamNotifyData.ToHash();
		hashtable["autoRecColosseum"] = autoRecColosseum.ToString();
		hashtable["tutorialStep"] = tutorialStep.ToString();
		hashtable["newItemData"] = newItemData.Flags;
		hashtable["sortData"] = sortData.Flags;
		hashtable["saveCount"] = saveCount.ToString();
		hashtable["resultShortcutData"] = resultShortcutData.Flags;
		hashtable["version"] = 2.ToString();
		return hashtable;
	}

	public void CheckLocalBgm()
	{
		try
		{
			if (!DownloadMain.IsBgmCached())
			{
				bgmLoad = false;
			}
		}
		catch (Exception)
		{
			bgmLoad = false;
		}
	}
}
