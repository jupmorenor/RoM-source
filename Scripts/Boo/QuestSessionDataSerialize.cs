using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestSessionDataSerialize : QuestSerializer
{
	[Serializable]
	public class SerializedPoppedMonster : JsonBase
	{
		[Serializable]
		internal class _0024Convert_0024locals_002414436
		{
			internal QuestBattleSessionData.PoppedMonster _0024m;
		}

		[Serializable]
		internal class _0024Convert_0024closure_00243289
		{
			internal _0024Convert_0024locals_002414436 _0024_0024locals_002414986;

			public _0024Convert_0024closure_00243289(_0024Convert_0024locals_002414436 _0024_0024locals_002414986)
			{
				this._0024_0024locals_002414986 = _0024_0024locals_002414986;
			}

			public bool Invoke(RespMonster d)
			{
				return RuntimeServices.EqualityOperator(d, _0024_0024locals_002414986._0024m.data);
			}
		}

		public int monIndex;

		public float hp;

		public float x;

		public float y;

		public float z;

		public static SerializedPoppedMonster Convert(QuestBattleSessionData.PoppedMonster m, RespMonster[] monsterArray)
		{
			_0024Convert_0024locals_002414436 _0024Convert_0024locals_0024 = new _0024Convert_0024locals_002414436();
			_0024Convert_0024locals_0024._0024m = m;
			if (_0024Convert_0024locals_0024._0024m == null || monsterArray == null)
			{
				throw new AssertionFailedException("(m != null) and (monsterArray != null)");
			}
			SerializedPoppedMonster serializedPoppedMonster = new SerializedPoppedMonster();
			serializedPoppedMonster.monIndex = Array.FindIndex(monsterArray, _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159.Adapt(new _0024Convert_0024closure_00243289(_0024Convert_0024locals_0024).Invoke));
			serializedPoppedMonster.hp = _0024Convert_0024locals_0024._0024m.hp;
			serializedPoppedMonster.x = _0024Convert_0024locals_0024._0024m.pos.x;
			serializedPoppedMonster.y = _0024Convert_0024locals_0024._0024m.pos.y;
			serializedPoppedMonster.z = _0024Convert_0024locals_0024._0024m.pos.z;
			return serializedPoppedMonster;
		}

		public static QuestBattleSessionData.PoppedMonster Convert(SerializedPoppedMonster d, RespMonster[] monsterArray)
		{
			if (d == null || monsterArray == null)
			{
				throw new AssertionFailedException("(d != null) and (monsterArray != null)");
			}
			int num = d.monIndex;
			object result;
			if (num < 0 || num >= monsterArray.Length)
			{
				result = null;
			}
			else
			{
				QuestBattleSessionData.PoppedMonster poppedMonster = new QuestBattleSessionData.PoppedMonster();
				poppedMonster.data = monsterArray[RuntimeServices.NormalizeArrayIndex(monsterArray, num)];
				poppedMonster.hp = d.hp;
				poppedMonster.pos = new Vector3(d.x, d.y, d.z);
				result = poppedMonster;
			}
			return (QuestBattleSessionData.PoppedMonster)result;
		}
	}

	[Serializable]
	public class BattleMonsterData : JsonBase
	{
		[Serializable]
		public class Entry : JsonBase
		{
			public int battleId;

			public int[] monsters;
		}

		public Entry[] entries;
	}

	[Serializable]
	public class IdList : JsonBase
	{
		public int[] ids;
	}

	[Serializable]
	public class SerializableFriendPoppet : JsonBase
	{
		public long Id;

		public int TPlayerId;

		public int ItemType;

		public int ItemId;

		public int Exp;

		public int Level;

		public int LevelMax;

		public int LimitBreakCount;

		public int HpPlusBonus;

		public int AttackPlusBonus;

		public int HpBonus;

		public int AttackBonus;

		public int SkillLevel_1;

		public int SkillLevel_2;

		public int SkillLevel_3;

		public string userName;

		public int friendPoint;

		public int characterLevel;

		public RespFriend orgRespFriend;

		public bool isFriend;

		public int socialId;

		public SerializableFriendPoppet()
		{
		}

		public SerializableFriendPoppet(RespFriendPoppet p)
		{
			if (p.RefPlayerBox == null)
			{
				p.RefPlayerBox = new RespPlayerBox();
			}
			Id = p.RefPlayerBox.Id.Value;
			TPlayerId = p.RefPlayerBox.TPlayerId;
			ItemType = p.RefPlayerBox.ItemType;
			ItemId = p.RefPlayerBox.ItemId;
			Exp = p.RefPlayerBox.Exp;
			Level = p.RefPlayerBox.Level;
			LevelMax = p.RefPlayerBox.LevelMax;
			LimitBreakCount = p.RefPlayerBox.LimitBreakCount;
			HpPlusBonus = p.RefPlayerBox.HpPlusBonus;
			AttackPlusBonus = p.RefPlayerBox.AttackPlusBonus;
			HpBonus = p.RefPlayerBox.HpBonus;
			AttackBonus = p.RefPlayerBox.AttackBonus;
			SkillLevel_1 = p.RefPlayerBox.SkillLevel_1;
			SkillLevel_2 = p.RefPlayerBox.SkillLevel_2;
			SkillLevel_3 = p.RefPlayerBox.SkillLevel_3;
			userName = p.UserName;
			friendPoint = p.FriendPoint;
			characterLevel = p.CharacterLevel;
			orgRespFriend = p.RespFriend;
			isFriend = p.IsFriend;
			socialId = p.SocialId;
		}

		public RespFriendPoppet toRespFriendPoppet()
		{
			RespFriendPoppet respFriendPoppet = new RespFriendPoppet();
			RespPlayerBox respPlayerBox2 = (respFriendPoppet.RefPlayerBox = new RespPlayerBox());
			respPlayerBox2.Id = new BoxId(Id);
			respPlayerBox2.TPlayerId = TPlayerId;
			respPlayerBox2.ItemType = ItemType;
			respPlayerBox2.ItemId = ItemId;
			respPlayerBox2.Exp = Exp;
			respPlayerBox2.Level = Level;
			respPlayerBox2.LevelMax = LevelMax;
			respPlayerBox2.LimitBreakCount = LimitBreakCount;
			respPlayerBox2.HpPlusBonus = HpPlusBonus;
			respPlayerBox2.AttackPlusBonus = AttackPlusBonus;
			respPlayerBox2.HpBonus = HpBonus;
			respPlayerBox2.AttackBonus = AttackBonus;
			respPlayerBox2.SkillLevel_1 = SkillLevel_1;
			respPlayerBox2.SkillLevel_2 = SkillLevel_2;
			respPlayerBox2.SkillLevel_3 = SkillLevel_3;
			respFriendPoppet.UserName = userName;
			respFriendPoppet.FriendPoint = friendPoint;
			respFriendPoppet.CharacterLevel = characterLevel;
			respFriendPoppet.RespFriend = orgRespFriend;
			respFriendPoppet.IsFriend = isFriend;
			respFriendPoppet.SocialId = socialId;
			return respFriendPoppet;
		}
	}

	[Serializable]
	internal class _0024monsterListToIds_0024locals_002414437
	{
		internal RespMonster[] _0024data;
	}

	[Serializable]
	internal class _0024monsterListToIds_0024closure_00243292
	{
		internal _0024monsterListToIds_0024locals_002414437 _0024_0024locals_002414987;

		internal int _0024i_002414988;

		public _0024monsterListToIds_0024closure_00243292(_0024monsterListToIds_0024locals_002414437 _0024_0024locals_002414987, int _0024i_002414988)
		{
			this._0024_0024locals_002414987 = _0024_0024locals_002414987;
			this._0024i_002414988 = _0024i_002414988;
		}

		public bool Invoke(RespMonster d)
		{
			RespMonster[] _0024data = _0024_0024locals_002414987._0024data;
			return RuntimeServices.EqualityOperator(d, _0024data[RuntimeServices.NormalizeArrayIndex(_0024data, _0024i_002414988)]);
		}
	}

	[NonSerialized]
	public static int SAVE_VERSION = 8;

	[NonSerialized]
	public static int INVALID_VERSION = 5;

	private ArrayList jsonData;

	private void writeInitialize()
	{
		jsonData = new ArrayList();
	}

	public override void serialize(object val)
	{
		jsonData.Add(val);
	}

	private byte[] finializeWrite()
	{
		object json = RequestBase.ToJsonData(jsonData);
		string s = NGUIJson.jsonEncodeEx(json, ignoreMultibyteCode: true);
		return Encoding.Unicode.GetBytes(s);
	}

	private void readInitialize(byte[] data)
	{
		string @string = Encoding.Unicode.GetString(data);
		object obj = NGUIJson.jsonDecode(@string);
		if (!(obj is ArrayList))
		{
			throw new AssertionFailedException("クエスト中断用jsonがおかしい\n" + @string);
		}
		jsonData = obj as ArrayList;
	}

	public override object deserialize()
	{
		if (jsonData == null || ((ICollection)jsonData).Count <= 0)
		{
			throw new AssertionFailedException("(jsonData != null) and (len(jsonData) > 0)");
		}
		object result = jsonData[0];
		jsonData.RemoveAt(0);
		return result;
	}

	public override object typedDeserialize(Type type)
	{
		object data = deserialize();
		return JsonBase.CreateFromJson(type, data);
	}

	private void finalizeRead()
	{
	}

	public byte[] serialize(QuestSessionParameters @params, QuestSessionData session, QuestGeometricSessionData geom)
	{
		if (session == null || geom == null)
		{
			throw new AssertionFailedException("(session != null) and (geom != null)");
		}
		byte[] array;
		try
		{
			writeInitialize();
			serialize(SAVE_VERSION);
			serializeParams(@params);
			serializeSession(session);
			serializeGeom(geom);
			QuestClearConditionChecker.Instance.serialize(this);
			array = finializeWrite();
		}
		catch (Exception)
		{
			goto IL_0064;
		}
		object result = array;
		goto IL_0068;
		IL_0064:
		result = null;
		goto IL_0068;
		IL_0068:
		return (byte[])result;
	}

	public object[] deserialize(byte[] data, ref int outVersion)
	{
		if (data == null)
		{
			throw new AssertionFailedException("data != null");
		}
		object[] array;
		try
		{
			readInitialize(data);
			int num = (outVersion = typedDeserialize<int>());
			QuestSessionParameters questSessionParameters = deserializeParams(num);
			QuestSessionData questSessionData = deserializeSession(num);
			QuestGeometricSessionData questGeometricSessionData = deserializeGeom(num);
			QuestClearConditionChecker.Instance.deserialize(this);
			finalizeRead();
			normalizeReferences(questSessionData);
			array = new object[3] { questSessionParameters, questSessionData, questGeometricSessionData };
		}
		catch (Exception)
		{
			goto IL_007c;
		}
		object[] result = array;
		goto IL_0086;
		IL_0086:
		return result;
		IL_007c:
		result = new object[3];
		goto IL_0086;
	}

	private void normalizeReferences(QuestSessionData session)
	{
		if (session.startResponse != null)
		{
			session.startResponse.Monsters = session.monsterData;
		}
	}

	private void serializeParams(QuestSessionParameters @params)
	{
		if (@params == null)
		{
			serialize(false);
			return;
		}
		serialize(true);
		serialize(@params.withServer);
		serialize(@params.storyId);
		if (@params.helper != null)
		{
			serialize(true);
			SerializableFriendPoppet val = new SerializableFriendPoppet(@params.helper);
			serialize(val);
		}
		else
		{
			serialize(false);
		}
		serialize(@params.noSceneLoad);
		serialize(@params.withSceneFade);
		serialize(@params.needEndLogo);
		serialize(@params.needResultMode);
		serialize((@params.debugMScenes != null) ? @params.debugMScenes.Id : 0);
		serialize(@params.startApiKey);
		serialize(@params.lastDataKey);
		serialize(@params.option);
	}

	private QuestSessionParameters deserializeParams(int version)
	{
		object result;
		if (!typedDeserialize<bool>())
		{
			result = null;
		}
		else
		{
			QuestSessionParameters questSessionParameters = new QuestSessionParameters();
			questSessionParameters.withServer = typedDeserialize<bool>();
			questSessionParameters.storyId = typedDeserialize<int>();
			if (typedDeserialize<bool>())
			{
				SerializableFriendPoppet serializableFriendPoppet = typedDeserialize<SerializableFriendPoppet>();
				questSessionParameters.helper = serializableFriendPoppet.toRespFriendPoppet();
			}
			questSessionParameters.noSceneLoad = typedDeserialize<bool>();
			questSessionParameters.withSceneFade = typedDeserialize<bool>();
			questSessionParameters.needEndLogo = typedDeserialize<bool>();
			questSessionParameters.needResultMode = typedDeserialize<bool>();
			questSessionParameters.debugMScenes = MScenes.Get(typedDeserialize<int>());
			questSessionParameters.startApiKey = typedDeserialize<string>();
			questSessionParameters.lastDataKey = typedDeserialize<string>();
			if (version >= 7)
			{
				questSessionParameters.option = typedDeserialize<int>();
			}
			result = questSessionParameters;
		}
		return (QuestSessionParameters)result;
	}

	private void serializeSession(QuestSessionData session)
	{
		if (session == null)
		{
			throw new AssertionFailedException("session != null");
		}
		serializeRespQuestStart(session.startResponse);
		serialize(session.monsterData);
		serialize(sceneListToSceneIds(session.visitedScenes));
		serialize(monsterMapToMonsterIndexMap(session.monsterMap, session.monsterData));
		serialize(stageBattlesToIds(session.existBattles));
		session.stageDropManager.serialize(this);
		serialize(session.keyItemPoint);
		int num = 0;
		if (session.currentScene != null)
		{
			num = session.currentScene.Id;
		}
		serialize(num);
		serialize(stageBattlesToIds(session.markedBattles));
		serialize(sceneListToSceneIds(session.allScenes));
		serialize(session.playedOpeningCutScene ? 1 : 0);
		serialize(session.finStartCommunication ? 1 : 0);
		serialize(session.ended ? 1 : 0);
		serialize(session.endStatus);
		serialize(session.endCommunicationApiKey);
		QuestBattleSessionData battleSession = session.battleSession;
		if (battleSession == null)
		{
			throw new AssertionFailedException("bsd != null");
		}
		serialize(battleSession.stopped);
		serialize(battleSession.wave);
		serialize(battleSession.afterContinue);
		serialize(battleSession.stageBattleId);
		SerializedPoppedMonster[] array = new SerializedPoppedMonster[((ICollection)battleSession.pops).Count];
		int num2 = 0;
		int count = ((ICollection)battleSession.pops).Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < count)
		{
			int index = num2;
			num2++;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = SerializedPoppedMonster.Convert(battleSession.pops[index], session.monsterData);
		}
		serialize(array);
		serialize(battleSession.continueApiKey);
		serialize(QuestEventHandler.SerializeToJson());
	}

	private QuestSessionData deserializeSession(int version)
	{
		QuestSessionData questSessionData = new QuestSessionData();
		questSessionData.startResponse = deserializeRespQuestStart();
		questSessionData.monsterData = typedDeserialize<RespMonster[]>();
		questSessionData.visitedScenes = idsToSceneList(typedDeserialize<IdList>());
		BattleMonsterData bmdata = typedDeserialize<BattleMonsterData>();
		questSessionData.monsterMap = monsterIndexMapToMonsterMap(bmdata, questSessionData.monsterData);
		questSessionData.existBattles = idsToStageBattles(typedDeserialize<IdList>());
		questSessionData.stageDropManager.deserialize(this);
		questSessionData.keyItemPoint = typedDeserialize<int>();
		int id = typedDeserialize<int>();
		questSessionData.currentScene = MScenes.Get(id);
		questSessionData.markedBattles = idsToStageBattles(typedDeserialize<IdList>());
		questSessionData.allScenes = idsToSceneArray(typedDeserialize<IdList>());
		if (version >= 2)
		{
			bool flag = typedDeserialize<int>() != 0;
			questSessionData.playedOpeningCutScene = false;
		}
		if (version >= 3)
		{
			questSessionData.finStartCommunication = typedDeserialize<int>() != 0;
		}
		if (version >= 5)
		{
			questSessionData.ended = typedDeserialize<int>() != 0;
			questSessionData.endStatus = typedDeserialize<int>();
			questSessionData.endCommunicationApiKey = typedDeserialize<string>();
		}
		QuestBattleSessionData battleSession = questSessionData.battleSession;
		if (battleSession == null)
		{
			throw new AssertionFailedException("bsd != null");
		}
		battleSession.clear();
		battleSession.stopped = typedDeserialize<bool>();
		battleSession.wave = typedDeserialize<int>();
		battleSession.afterContinue = typedDeserialize<bool>();
		battleSession.stageBattleId = typedDeserialize<int>();
		SerializedPoppedMonster[] array = typedDeserialize<SerializedPoppedMonster[]>();
		int i = 0;
		SerializedPoppedMonster[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			QuestBattleSessionData.PoppedMonster poppedMonster = SerializedPoppedMonster.Convert(array2[i], questSessionData.monsterData);
			if (poppedMonster != null)
			{
				battleSession.pops.Add(poppedMonster);
			}
		}
		if (version >= 4)
		{
			battleSession.continueApiKey = typedDeserialize<string>();
		}
		if (version >= 8)
		{
			string json = typedDeserialize<string>();
			QuestBattleStatistics questBattleStatistics = QuestEventHandler.DeserializeFromJson(json);
			if (questBattleStatistics != null)
			{
				questSessionData.questBattleStatistics = questBattleStatistics;
			}
		}
		return questSessionData;
	}

	private void serializeGeom(QuestGeometricSessionData geom)
	{
		serializeVector3(geom.playerPosition);
		serialize(geom.playerYAngle);
		serialize(geom.playerHP);
		serialize(geom.playerSkillCooldown);
		serialize(geom.playerChangeCooldown);
		serialize(geom.playerMagicPoint);
		serialize(geom.poppetPositions.Length);
		int i = 0;
		Vector3[] poppetPositions = geom.poppetPositions;
		for (int length = poppetPositions.Length; i < length; i = checked(i + 1))
		{
			serializeVector3(poppetPositions[i]);
		}
	}

	private QuestGeometricSessionData deserializeGeom(object ver)
	{
		QuestGeometricSessionData questGeometricSessionData = new QuestGeometricSessionData();
		questGeometricSessionData.playerPosition = deserializeVector3();
		questGeometricSessionData.playerYAngle = typedDeserialize<float>();
		questGeometricSessionData.playerHP = typedDeserialize<float>();
		questGeometricSessionData.playerSkillCooldown = typedDeserialize<float>();
		questGeometricSessionData.playerChangeCooldown = typedDeserialize<float>();
		questGeometricSessionData.playerMagicPoint = typedDeserialize<float[]>();
		int num = typedDeserialize<int>();
		questGeometricSessionData.poppetPositions = new Vector3[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			Vector3[] poppetPositions = questGeometricSessionData.poppetPositions;
			ref Vector3 reference = ref poppetPositions[RuntimeServices.NormalizeArrayIndex(poppetPositions, index)];
			reference = deserializeVector3();
		}
		return questGeometricSessionData;
	}

	private void serializeRespQuestStart(RespQuestStart resp)
	{
		serialize(resp != null);
		if (resp != null)
		{
			serialize(resp);
		}
	}

	private RespQuestStart deserializeRespQuestStart()
	{
		object result;
		if (!typedDeserialize<bool>())
		{
			result = null;
		}
		else
		{
			RespQuestStart respQuestStart = typedDeserialize<RespQuestStart>();
			if (!(respQuestStart is RespQuestStart))
			{
				throw new AssertionFailedException("RespQuestStart が deserialize できなかった。");
			}
			result = respQuestStart as RespQuestStart;
		}
		return (RespQuestStart)result;
	}

	private IdList sceneListToSceneIds(Boo.Lang.List<MScenes> scenes)
	{
		if (scenes == null)
		{
			throw new AssertionFailedException("scenes != null");
		}
		Boo.Lang.List<int> list = new Boo.Lang.List<int>();
		IEnumerator<MScenes> enumerator = scenes.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MScenes current = enumerator.Current;
				list.Add(current.Id);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IdList idList = new IdList();
		int[] array = (idList.ids = (int[])Builtins.array(typeof(int), list));
		return idList;
	}

	private Boo.Lang.List<MScenes> idsToSceneList(IdList ids)
	{
		if (ids == null)
		{
			throw new AssertionFailedException("ids != null");
		}
		Boo.Lang.List<MScenes> list = new Boo.Lang.List<MScenes>();
		int i = 0;
		int[] ids2 = ids.ids;
		for (int length = ids2.Length; i < length; i = checked(i + 1))
		{
			list.Add(MScenes.Get(ids2[i]));
		}
		return list;
	}

	private MScenes[] idsToSceneArray(IdList ids)
	{
		if (ids == null)
		{
			throw new AssertionFailedException("ids != null");
		}
		return (MScenes[])Builtins.array(typeof(MScenes), idsToSceneList(ids));
	}

	private IdList sceneListToSceneIds(MScenes[] scenes)
	{
		if (scenes == null)
		{
			throw new AssertionFailedException("scenes != null");
		}
		Boo.Lang.List<int> list = new Boo.Lang.List<int>();
		int i = 0;
		for (int length = scenes.Length; i < length; i = checked(i + 1))
		{
			list.Add(scenes[i].Id);
		}
		IdList idList = new IdList();
		int[] array = (idList.ids = (int[])Builtins.array(typeof(int), list));
		return idList;
	}

	private IdList monsterListToIds(RespMonster[] data, RespMonster[] monsterArray)
	{
		_0024monsterListToIds_0024locals_002414437 _0024monsterListToIds_0024locals_0024 = new _0024monsterListToIds_0024locals_002414437();
		_0024monsterListToIds_0024locals_0024._0024data = data;
		if (_0024monsterListToIds_0024locals_0024._0024data == null || monsterArray == null)
		{
			throw new AssertionFailedException("(data != null) and (monsterArray != null)");
		}
		int[] array = new int[_0024monsterListToIds_0024locals_0024._0024data.Length];
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			array[RuntimeServices.NormalizeArrayIndex(array, num2)] = Array.FindIndex(monsterArray, _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159.Adapt(new _0024monsterListToIds_0024closure_00243292(_0024monsterListToIds_0024locals_0024, num2).Invoke));
		}
		IdList idList = new IdList();
		int[] array2 = (idList.ids = array);
		return idList;
	}

	private RespMonster[] idsToMonsterList(IdList idlist, RespMonster[] monsterArray)
	{
		if (idlist == null || monsterArray == null)
		{
			throw new AssertionFailedException("(idlist != null) and (monsterArray != null)");
		}
		RespMonster[] array = new RespMonster[idlist.ids.Length];
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			int[] ids = idlist.ids;
			int num2 = ids[RuntimeServices.NormalizeArrayIndex(ids, index)];
			if (num2 >= 0 && num2 < monsterArray.Length)
			{
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = monsterArray[RuntimeServices.NormalizeArrayIndex(monsterArray, num2)];
			}
		}
		return array;
	}

	private BattleMonsterData monsterMapToMonsterIndexMap(Dictionary<MStageBattles, RespMonster[]> monsterMap, RespMonster[] monsterArray)
	{
		if (monsterMap == null || monsterArray == null)
		{
			throw new AssertionFailedException("(monsterMap != null) and (monsterArray != null)");
		}
		Hashtable hashtable = new Hashtable();
		Boo.Lang.List<BattleMonsterData.Entry> list = new Boo.Lang.List<BattleMonsterData.Entry>();
		foreach (MStageBattles key in monsterMap.Keys)
		{
			Boo.Lang.List<int> list2 = new Boo.Lang.List<int>();
			int i = 0;
			RespMonster[] array = monsterMap[key];
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				list2.Add(findIndex(array[i], monsterArray));
			}
			BattleMonsterData.Entry entry = new BattleMonsterData.Entry();
			int num = (entry.battleId = key.Id);
			int[] array2 = (entry.monsters = (int[])Builtins.array(typeof(int), list2));
			list.Add(entry);
		}
		BattleMonsterData battleMonsterData = new BattleMonsterData();
		BattleMonsterData.Entry[] array3 = (battleMonsterData.entries = (BattleMonsterData.Entry[])Builtins.array(typeof(BattleMonsterData.Entry), list));
		return battleMonsterData;
	}

	private Dictionary<MStageBattles, RespMonster[]> monsterIndexMapToMonsterMap(BattleMonsterData bmdata, RespMonster[] monsterArray)
	{
		if (bmdata == null || monsterArray == null)
		{
			throw new AssertionFailedException("(bmdata != null) and (monsterArray != null)");
		}
		Dictionary<MStageBattles, RespMonster[]> dictionary = new Dictionary<MStageBattles, RespMonster[]>();
		int i = 0;
		BattleMonsterData.Entry[] entries = bmdata.entries;
		checked
		{
			for (int length = entries.Length; i < length; i++)
			{
				MStageBattles mStageBattles = MStageBattles.Get(entries[i].battleId);
				if (mStageBattles == null)
				{
					throw new AssertionFailedException(new StringBuilder("no MStageBattles for id=").Append((object)entries[i].battleId).ToString());
				}
				Boo.Lang.List<RespMonster> list = new Boo.Lang.List<RespMonster>();
				int j = 0;
				int[] monsters = entries[i].monsters;
				for (int length2 = monsters.Length; j < length2; j++)
				{
					RespMonster item = monsterArray[RuntimeServices.NormalizeArrayIndex(monsterArray, monsters[j])];
					list.Add(item);
				}
				dictionary[mStageBattles] = (RespMonster[])Builtins.array(typeof(RespMonster), list);
			}
			return dictionary;
		}
	}

	private int findIndex(RespMonster m, RespMonster[] monsterArray)
	{
		if (m == null || monsterArray == null)
		{
			throw new AssertionFailedException("(m != null) and (monsterArray != null)");
		}
		int num = 0;
		int length = monsterArray.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < length)
			{
				int num2 = num;
				num++;
				if (RuntimeServices.EqualityOperator(m, monsterArray[RuntimeServices.NormalizeArrayIndex(monsterArray, num2)]))
				{
					result = num2;
					break;
				}
				continue;
			}
			if (string.IsNullOrEmpty(new StringBuilder("西森へ報告！").Append(m).Append("がモンスター配列の中にない！").ToString()))
			{
				throw new AssertionFailedException("\"西森へ報告！$mがモンスター配列の中にない！\"");
			}
			result = 0;
			break;
		}
		return result;
	}

	private IdList stageBattlesToIds(HashSet<MStageBattles> battles)
	{
		if (battles == null)
		{
			throw new AssertionFailedException("battles != null");
		}
		Boo.Lang.List<int> list = new Boo.Lang.List<int>();
		foreach (MStageBattles battle in battles)
		{
			list.Add(battle.Id);
		}
		IdList idList = new IdList();
		int[] array = (idList.ids = (int[])Builtins.array(typeof(int), list));
		return idList;
	}

	private HashSet<MStageBattles> idsToStageBattles(IdList ids)
	{
		if (ids == null)
		{
			throw new AssertionFailedException("ids != null");
		}
		HashSet<MStageBattles> hashSet = new HashSet<MStageBattles>();
		int i = 0;
		int[] ids2 = ids.ids;
		for (int length = ids2.Length; i < length; i = checked(i + 1))
		{
			hashSet.Add(MStageBattles.Get(ids2[i]));
		}
		return hashSet;
	}
}
