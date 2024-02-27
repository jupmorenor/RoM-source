using System;
using System.Collections;
using System.IO;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumSession : MonoBehaviour
{
	[Serializable]
	public class StartParams : JsonBase
	{
		public bool isNPC;

		public int socialID;

		public RespOpponentWithOrganize friendData;

		public bool execBattle;

		public string nextScene;

		private bool _0024initialized__ColosseumSession_StartParams_0024;

		public bool IsVsFriend => friendData != null;

		public StartParams()
		{
			if (!_0024initialized__ColosseumSession_StartParams_0024)
			{
				execBattle = true;
				nextScene = "Ui_WorldColosseumResult";
				_0024initialized__ColosseumSession_StartParams_0024 = true;
			}
		}

		public StartParams(bool _isNPC, int _socialID)
		{
			if (!_0024initialized__ColosseumSession_StartParams_0024)
			{
				execBattle = true;
				nextScene = "Ui_WorldColosseumResult";
				_0024initialized__ColosseumSession_StartParams_0024 = true;
			}
			isNPC = _isNPC;
			socialID = _socialID;
			friendData = null;
		}

		public StartParams(RespOpponent _opponentData)
		{
			if (!_0024initialized__ColosseumSession_StartParams_0024)
			{
				execBattle = true;
				nextScene = "Ui_WorldColosseumResult";
				_0024initialized__ColosseumSession_StartParams_0024 = true;
			}
			isNPC = _opponentData.IsNPC;
			socialID = _opponentData.TSocialPlayerId;
			friendData = null;
		}

		public StartParams(RespOpponentWithOrganize _friendData)
		{
			if (!_0024initialized__ColosseumSession_StartParams_0024)
			{
				execBattle = true;
				nextScene = "Ui_WorldColosseumResult";
				_0024initialized__ColosseumSession_StartParams_0024 = true;
			}
			friendData = _friendData;
		}

		public override string ToString()
		{
			return (friendData == null) ? new StringBuilder("StartParams(isNPC:").Append(isNPC).Append(" socialID:").Append((object)socialID)
				.Append(")")
				.ToString() : new StringBuilder("StartParams(friend: ").Append((object)friendData.TSocialPlayerId).Append(" ").Append(friendData.Name)
				.Append(")")
				.ToString();
		}
	}

	[Serializable]
	public enum EMode
	{
		None,
		Starting,
		ErrorStarting,
		ReadyToPlay,
		Playing,
		Closing,
		ErrorClosing,
		Closed
	}

	[Serializable]
	public class ISessionState
	{
	}

	[Serializable]
	private class SessionState : ISessionState
	{
		[Serializable]
		internal class _0024deserializeFromJson_0024locals_002414375
		{
			internal Hashtable _0024hash;
		}

		[Serializable]
		internal class _0024deserializeFromJson_0024_val_00243106
		{
			internal _0024deserializeFromJson_0024locals_002414375 _0024_0024locals_002414855;

			public _0024deserializeFromJson_0024_val_00243106(_0024deserializeFromJson_0024locals_002414375 _0024_0024locals_002414855)
			{
				this._0024_0024locals_002414855 = _0024_0024locals_002414855;
			}

			public object Invoke(string key)
			{
				return (!_0024_0024locals_002414855._0024hash.ContainsKey(key)) ? null : _0024_0024locals_002414855._0024hash[key];
			}
		}

		private StartParams startParams;

		private int _mode;

		private string dataKey;

		private ApiColosseumBattleStart.Resp startResponse;

		private RespColosseumBattleResult endResponse;

		private ColosseumBattleResult battleResult;

		private RespOpponentWithOrganize opponentData;

		private int[] dailyPassiveSkills;

		private ApiColosseumBattleStart startRequest;

		private ApiColosseumBattleResult endRequest;

		public EMode mode
		{
			get
			{
				return (EMode)_mode;
			}
			set
			{
				_DebugLog(new StringBuilder("mode ").Append((EMode)_mode).Append(" -> ").Append(value)
					.ToString());
				_mode = (int)value;
			}
		}

		public bool IsPlaying => mode == EMode.Playing;

		public bool IsStarting => mode == EMode.Starting;

		public bool IsReadyToPlay => mode == EMode.ReadyToPlay;

		public bool IsClosing => mode == EMode.Closing;

		public bool IsClosed => mode == EMode.Closed;

		public bool HasError
		{
			get
			{
				bool num = mode == EMode.ErrorStarting;
				if (!num)
				{
					num = mode == EMode.ErrorClosing;
				}
				return num;
			}
		}

		public StartParams Params => startParams;

		public ApiColosseumBattleStart.Resp StartResponse => startResponse;

		public RespColosseumBattleResult EndResponse => endResponse;

		public ColosseumBattleResult BattleResult => battleResult;

		public RespOpponentWithOrganize OpponentData => opponentData;

		public int[] DailyPassiveSkills => dailyPassiveSkills;

		public ApiColosseumBattleStart StartRequest => startRequest;

		public ApiColosseumBattleResult EndRequest => endRequest;

		public SessionState()
		{
			_mode = 0;
			dailyPassiveSkills = new int[0];
			clear();
		}

		public void clear()
		{
			mode = EMode.None;
			startParams = null;
			startRequest = null;
			startResponse = null;
			endRequest = null;
			endResponse = null;
			opponentData = null;
			dailyPassiveSkills = new int[0];
			battleResult = null;
			dataKey = null;
		}

		public void clearAndDeleteSession()
		{
			clear();
			DeleteSaveData();
		}

		public void start(StartParams _params)
		{
			if (_params == null)
			{
				throw new AssertionFailedException("ColosseumSession: StartParams is null");
			}
			_InfoLog(new StringBuilder("start: ").Append(_params).ToString());
			clear();
			startParams = _params;
			tryStartingSession();
			save();
		}

		public void end(ColosseumBattleResult _result)
		{
			if (_result == null)
			{
				throw new AssertionFailedException("_result != null");
			}
			if (mode == EMode.Closed)
			{
				_InfoLog("end: mode = Closed");
				return;
			}
			if (mode != EMode.Playing && mode != EMode.Closing)
			{
				throw new AssertionFailedException(new StringBuilder("開始通信完了せずに終了しようとしてる ").Append(mode).ToString());
			}
			_InfoLog(new StringBuilder("end: result=").Append((object)_result.gameResult).ToString());
			if (battleResult == null)
			{
				battleResult = _result;
			}
			else
			{
				_InfoLog(new StringBuilder("end: result was already set - ").Append((object)battleResult.gameResult).ToString());
			}
			tryClosingSession();
			if (startParams.IsVsFriend)
			{
				DeleteSaveData();
			}
			else
			{
				save();
			}
		}

		public void update(ICallable _gotoBattleProc)
		{
			if (mode == EMode.Starting)
			{
				updateStarting();
			}
			else if (mode == EMode.ReadyToPlay)
			{
				updateReadyToPlay();
				_gotoBattleProc?.Call(new object[0]);
			}
			else if (mode == EMode.Closing)
			{
				updateClosing();
			}
		}

		private void tryStartingSession()
		{
			if (startParams == null)
			{
				throw new AssertionFailedException("startParams != null");
			}
			battleResult = null;
			if (startParams.IsVsFriend)
			{
				setModeReadyToPlay(startParams.friendData, null);
			}
			else
			{
				setModeStarting();
			}
		}

		private void setModeStarting()
		{
			if (startParams == null)
			{
				throw new AssertionFailedException("startParams != null");
			}
			mode = EMode.Starting;
			if (string.IsNullOrEmpty(dataKey))
			{
				dataKey = ServerUtilModule.GenerateUUID();
			}
			dailyPassiveSkills = UserData.Current.userColosseumEvent.DailyPassiveSkills;
		}

		private void updateStarting()
		{
			if (startRequest == null)
			{
				initStartRequest();
			}
			else if (startRequest.IsEnd)
			{
				startReqFin();
			}
		}

		private void initStartRequest()
		{
			ApiColosseumBattleStart apiColosseumBattleStart = new ApiColosseumBattleStart();
			apiColosseumBattleStart.IsNPC = startParams.isNPC;
			apiColosseumBattleStart.Id = startParams.socialID;
			apiColosseumBattleStart.DataKey = dataKey;
			apiColosseumBattleStart.DailyPassiveSkills = currentDailyPassiveSkillIds();
			startRequest = apiColosseumBattleStart;
			MerlinServer.Request(apiColosseumBattleStart);
		}

		private int[] currentDailyPassiveSkillIds()
		{
			return UserData.Current.userColosseumEvent.DailyPassiveSkills;
		}

		private void startReqFin()
		{
			if (startRequest.IsOk)
			{
				ApiColosseumBattleStart.Resp response = startRequest.GetResponse();
				setModeReadyToPlay(response.Opponent, response);
			}
			else
			{
				mode = EMode.ErrorStarting;
			}
		}

		private void setModeReadyToPlay(RespOpponentWithOrganize _oppData, ApiColosseumBattleStart.Resp _resp)
		{
			if (_oppData == null)
			{
				throw new AssertionFailedException("_oppData != null");
			}
			if (_oppData.Organize == null)
			{
				throw new AssertionFailedException("opponent情報(Organize)が正しくない(1)");
			}
			if (_oppData.Organize.Length <= 0)
			{
				throw new AssertionFailedException("opponent情報(Organize)が正しくない(2)");
			}
			mode = EMode.ReadyToPlay;
			startResponse = _resp;
			opponentData = _oppData;
		}

		public void updateReadyToPlay()
		{
			_InfoLog(new StringBuilder("startPlaying: mode=").Append(mode).ToString());
			mode = EMode.Playing;
			save();
		}

		private void tryClosingSession()
		{
			if (startParams == null)
			{
				throw new AssertionFailedException("startParams != null");
			}
			if (startParams.IsVsFriend)
			{
				setModeClosed(createFakeResultRespose(startParams.friendData));
			}
			else
			{
				setModeClosing();
			}
		}

		private void setModeClosing()
		{
			mode = EMode.Closing;
			endRequest = null;
		}

		private void updateClosing()
		{
			if (endRequest == null)
			{
				initEndRequest();
			}
			else if (endRequest.IsEnd)
			{
				endReqFin();
			}
		}

		private void initEndRequest()
		{
			MerlinServer.Request(endRequest = createEndReq(OpponentData.TicketId, battleResult));
		}

		private void setModeClosed(RespColosseumBattleResult _resp)
		{
			if (_resp == null)
			{
				throw new AssertionFailedException("_resp != null");
			}
			mode = EMode.Closed;
			endResponse = _resp;
		}

		private void endReqFin()
		{
			if (endRequest.IsOk)
			{
				_InfoLog("endReqFin: ok");
				setModeClosed(endRequest.GetResponse());
			}
			else
			{
				_InfoLog("endReqFin: fail");
				mode = EMode.ErrorClosing;
			}
			DeleteSaveData();
		}

		private ApiColosseumBattleResult createEndReq(string _ticketId, ColosseumBattleResult _result)
		{
			if (string.IsNullOrEmpty(_ticketId))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(_ticketId)");
			}
			if (_result == null)
			{
				throw new AssertionFailedException("_result != null");
			}
			_InfoLog(new StringBuilder("result=").Append((EnumColosseumBattleResults)_result.gameResult).ToString());
			ApiColosseumBattleResult apiColosseumBattleResult = new ApiColosseumBattleResult();
			apiColosseumBattleResult.TicketId = _ticketId;
			apiColosseumBattleResult.DataKey = dataKey;
			apiColosseumBattleResult.GameResultIs = _result.gameResult;
			apiColosseumBattleResult.Hp = _result.hp;
			apiColosseumBattleResult.OpponentHp = _result.opponentHp;
			apiColosseumBattleResult.MaxGivenDamage = _result.maxGivenDamage;
			apiColosseumBattleResult.TotalGivenDamage = _result.totalGivenDamage;
			apiColosseumBattleResult.MaxDamage = _result.maxDamage;
			apiColosseumBattleResult.TotalDamage = _result.totalDamage;
			return apiColosseumBattleResult;
		}

		private RespColosseumBattleResult createFakeResultRespose(RespOpponentWithOrganize _baseOpponent)
		{
			RespColosseumBattleResult respColosseumBattleResult = new RespColosseumBattleResult();
			respColosseumBattleResult.Breeder = UserData.Current.userBreeder;
			respColosseumBattleResult.PresentBox = new RespPlayerPresentBox[0];
			respColosseumBattleResult.BreederRankPoint = 0L;
			respColosseumBattleResult.BreederRankRewards = "[]";
			respColosseumBattleResult.EventRankRewards = "[]";
			respColosseumBattleResult.Coin = 0;
			respColosseumBattleResult.FriendPoint = 0;
			respColosseumBattleResult.ManaFragment = 0;
			respColosseumBattleResult.PlayerInfo = UserData.Current.userStatus;
			respColosseumBattleResult.ColosseumEvent = null;
			respColosseumBattleResult.ColosseumEventRanking = null;
			respColosseumBattleResult.ColosseumEventTotalRankingPoint = 0.0;
			return respColosseumBattleResult;
		}

		private void setLoseBattleResult()
		{
			_InfoLog("set LOSE");
			ColosseumBattleResult colosseumBattleResult = new ColosseumBattleResult();
			colosseumBattleResult.setResult(_isWin: false);
			battleResult = colosseumBattleResult;
		}

		private void gotoNextScene()
		{
			_DebugLog("gotoNextScene: " + startParams.nextScene);
			if (!string.IsNullOrEmpty(startParams.nextScene))
			{
				SceneChanger.Change(startParams.nextScene);
			}
		}

		private void save()
		{
			try
			{
				string text = serializeToJson();
				_InfoLog("save(): is null=" + string.IsNullOrEmpty(text));
				SaveSessionFile(text);
			}
			catch (Exception)
			{
				DeleteSaveData();
			}
		}

		public static ISessionState Load()
		{
			SessionState sessionState = new SessionState();
			object result;
			if (sessionState.load())
			{
				result = sessionState;
			}
			else
			{
				DeleteSaveData();
				result = null;
			}
			return (ISessionState)result;
		}

		private bool load()
		{
			try
			{
				string text = LoadSessionFile();
				_InfoLog("load(): is null=" + string.IsNullOrEmpty(text));
				return deserializeFromJson(text);
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool restart()
		{
			int result;
			if (mode == EMode.Starting)
			{
				_DebugLog("load() Starting");
				setModeStarting();
				result = 1;
			}
			else if (mode == EMode.ErrorStarting)
			{
				_DebugLog("load() ErrorStarting");
				clear();
				DeleteSaveData();
				result = 0;
			}
			else if (mode == EMode.ReadyToPlay)
			{
				_DebugLog("load() ReadyToPlay");
				setModeStarting();
				result = 1;
			}
			else if (mode == EMode.Playing)
			{
				_DebugLog("load() Playing");
				setLoseBattleResult();
				gotoNextScene();
				result = 1;
			}
			else if (mode == EMode.Closing)
			{
				_DebugLog("load() Closing");
				gotoNextScene();
				result = 1;
			}
			else if (mode == EMode.ErrorClosing)
			{
				_DebugLog("load() ErrorClosing");
				clear();
				DeleteSaveData();
				result = 0;
			}
			else if (mode == EMode.Closed)
			{
				_DebugLog("load() Closed");
				gotoNextScene();
				DeleteSaveData();
				result = 0;
			}
			else
			{
				DeleteSaveData();
				result = 0;
			}
			return (byte)result != 0;
		}

		private static void SaveSessionFile(string content)
		{
			if (!string.IsNullOrEmpty(content))
			{
				byte[] bytes = Encoding.UTF8.GetBytes(content);
				byte[] saveKey = GetSaveKey();
				byte[] bytes2 = Crypt.EncryptColosseum(bytes, saveKey);
				File.WriteAllBytes(SAVE_FILEPATH, bytes2);
				_InfoLog("SaveSessionFile: " + SAVE_FILEPATH);
			}
		}

		private static string LoadSessionFile()
		{
			_InfoLog("LoadSessionFile: " + SAVE_FILEPATH);
			byte[] src = File.ReadAllBytes(SAVE_FILEPATH);
			byte[] saveKey = GetSaveKey();
			byte[] bytes = Crypt.DecryptColosseum(src, saveKey);
			return Encoding.UTF8.GetString(bytes);
		}

		public static void DeleteSaveData()
		{
			try
			{
				_InfoLog("DeleteSaveData()");
				File.Delete(SAVE_FILEPATH);
				RenewSaveKey();
			}
			catch (Exception)
			{
			}
		}

		public static byte[] GetSaveKey()
		{
			CypherKeyGenerator cypherKeyGenerator = CypherKeyGenerator.ForColosseum();
			return cypherKeyGenerator.getSaveKey();
		}

		public static void RenewSaveKey()
		{
			CypherKeyGenerator cypherKeyGenerator = CypherKeyGenerator.ForColosseum();
			cypherKeyGenerator.renewSaveKey();
		}

		private string serializeToJson()
		{
			Hashtable hashtable = new Hashtable();
			hashtable["version"] = 2;
			hashtable["socialId"] = UserData.Current.userStatus.TSocialPlayerId;
			hashtable["mode"] = mode;
			hashtable["startParams"] = startParams;
			hashtable["startResponse"] = startResponse;
			hashtable["endResponse"] = endResponse;
			hashtable["battleResult"] = battleResult;
			hashtable["opponentData"] = opponentData;
			hashtable["dataKey"] = dataKey;
			hashtable["dailyPassiveSkills"] = dailyPassiveSkills;
			return NGUIJson.jsonEncode(RequestBase.ToJsonData(hashtable));
		}

		private bool deserializeFromJson(string jsonStr)
		{
			_0024deserializeFromJson_0024locals_002414375 _0024deserializeFromJson_0024locals_0024 = new _0024deserializeFromJson_0024locals_002414375();
			int result;
			if (string.IsNullOrEmpty(jsonStr))
			{
				clear();
				result = 0;
			}
			else
			{
				object obj = NGUIJson.jsonDecode(jsonStr);
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				_0024deserializeFromJson_0024locals_0024._0024hash = (Hashtable)obj;
				if (_0024deserializeFromJson_0024locals_0024._0024hash == null)
				{
					throw new AssertionFailedException("json error:\n" + jsonStr);
				}
				__SessionState_deserializeFromJson_0024callable135_0024739_17__ _SessionState_deserializeFromJson_0024callable135_0024739_17__ = new _0024deserializeFromJson_0024_val_00243106(_0024deserializeFromJson_0024locals_0024).Invoke;
				int num = RuntimeServices.UnboxInt32(_SessionState_deserializeFromJson_0024callable135_0024739_17__("version"));
				int num2 = RuntimeServices.UnboxInt32(_SessionState_deserializeFromJson_0024callable135_0024739_17__("socialId"));
				if (num2 != UserData.Current.userStatus.TSocialPlayerId)
				{
					result = 0;
				}
				else
				{
					mode = (EMode)RuntimeServices.UnboxInt32(_SessionState_deserializeFromJson_0024callable135_0024739_17__("mode"));
					object obj2 = JsonBase.CreateFromJson(typeof(StartParams), _SessionState_deserializeFromJson_0024callable135_0024739_17__("startParams"));
					if (!(obj2 is StartParams))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(StartParams));
					}
					startParams = (StartParams)obj2;
					object obj3 = JsonBase.CreateFromJson(typeof(ApiColosseumBattleStart.Resp), _SessionState_deserializeFromJson_0024callable135_0024739_17__("startResponse"));
					if (!(obj3 is ApiColosseumBattleStart.Resp))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(ApiColosseumBattleStart.Resp));
					}
					startResponse = (ApiColosseumBattleStart.Resp)obj3;
					object obj4 = JsonBase.CreateFromJson(typeof(RespColosseumBattleResult), _SessionState_deserializeFromJson_0024callable135_0024739_17__("endResponse"));
					if (!(obj4 is RespColosseumBattleResult))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(RespColosseumBattleResult));
					}
					endResponse = (RespColosseumBattleResult)obj4;
					object obj5 = JsonBase.CreateFromJson(typeof(ColosseumBattleResult), _SessionState_deserializeFromJson_0024callable135_0024739_17__("battleResult"));
					if (!(obj5 is ColosseumBattleResult))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(ColosseumBattleResult));
					}
					battleResult = (ColosseumBattleResult)obj5;
					object obj6 = JsonBase.CreateFromJson(typeof(RespOpponentWithOrganize), _SessionState_deserializeFromJson_0024callable135_0024739_17__("opponentData"));
					if (!(obj6 is RespOpponentWithOrganize))
					{
						obj6 = RuntimeServices.Coerce(obj6, typeof(RespOpponentWithOrganize));
					}
					opponentData = (RespOpponentWithOrganize)obj6;
					object obj7 = JsonBase.CreateFromJson(typeof(string), _SessionState_deserializeFromJson_0024callable135_0024739_17__("dataKey"));
					if (!(obj7 is string))
					{
						obj7 = RuntimeServices.Coerce(obj7, typeof(string));
					}
					dataKey = (string)obj7;
					if (num >= 2)
					{
						if (_SessionState_deserializeFromJson_0024callable135_0024739_17__("dailyPassiveSkills") is int[] array)
						{
							dailyPassiveSkills = array;
						}
						else
						{
							dailyPassiveSkills = new int[0];
						}
					}
					result = ((startParams != null) ? 1 : 0);
				}
			}
			return (byte)result != 0;
		}
	}

	[NonSerialized]
	private static ColosseumSession __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private const int CURRENT_SAVEFILE_VERSION = 2;

	[NonSerialized]
	private const int SAVEFILE_VERSION_WITH_DAILY_SKILLS = 2;

	[NonSerialized]
	private const string SAVE_FILENAME = "riseofmana.conc";

	private SessionState sessionState;

	public static ColosseumSession Instance
	{
		get
		{
			ColosseumSession _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((ColosseumSession)UnityEngine.Object.FindObjectOfType(typeof(ColosseumSession))) as ColosseumSession;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static ColosseumSession CurrentInstance => __instance;

	private static string SAVE_FILEPATH => Path.Combine(Application.persistentDataPath, "riseofmana.conc");

	public bool IsPlaying => sessionState.IsPlaying;

	public bool HasError => sessionState.HasError;

	public bool IsPreparing
	{
		get
		{
			bool num = sessionState.IsStarting;
			if (!num)
			{
				num = sessionState.IsReadyToPlay;
			}
			return num;
		}
	}

	public bool IsClosing => sessionState.IsClosing;

	public bool IsClosed => sessionState.IsClosed;

	public RespColosseumBattleResult Result => sessionState.EndResponse;

	public ColosseumBattleResult BattleResult => sessionState.BattleResult;

	public ColosseumSession()
	{
		sessionState = new SessionState();
	}

	public void _0024singleton_0024awake_00241445()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241445();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static ColosseumSession _createInstance()
	{
		string text = "__" + "ColosseumSession" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		ColosseumSession colosseumSession = ExtensionsModule.SetComponent<ColosseumSession>(gameObject);
		if ((bool)colosseumSession)
		{
			colosseumSession._createInstance_callback();
		}
		return colosseumSession;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00241446()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241446();
		quitApp = true;
	}

	private static void _DebugLog(string s)
	{
	}

	private static void _InfoLog(string s)
	{
	}

	public static void DeleteSaveData()
	{
		SessionState.DeleteSaveData();
	}

	public void Start()
	{
	}

	public void Update()
	{
		if (sessionState != null)
		{
			sessionState.update((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				gotoBattle();
			});
		}
	}

	public void OnDestroy()
	{
		sessionState.clear();
	}

	public void startSessionPvP(RespOpponent opponent)
	{
		if (opponent == null)
		{
			throw new AssertionFailedException("opponent != null");
		}
		startSessionCustom(new StartParams(opponent));
	}

	public void startSessionVSFriend(RespOpponentWithOrganize opponentData)
	{
		startSessionCustom(new StartParams(opponentData));
	}

	public void startSessionCustom(StartParams @params)
	{
		sessionState.start(@params);
	}

	public void closeSession()
	{
		ColosseumBattleResult lastBattleResult = ColosseumBattleControl.LastBattleResult;
		sessionState.end(lastBattleResult);
	}

	public ISessionState load()
	{
		return SessionState.Load();
	}

	public void restart(ISessionState state)
	{
		if (!(state is SessionState))
		{
			throw new AssertionFailedException("state isa SessionState");
		}
		sessionState = (SessionState)state;
		sessionState.restart();
	}

	public void clearSession()
	{
		sessionState.clearAndDeleteSession();
	}

	private void gotoBattle()
	{
		if (sessionState.Params.execBattle)
		{
			RespOpponentWithOrganize opponentData = sessionState.OpponentData;
			ColosseumBattleControl colosseumBattleControl = ColosseumBattleControl.Create();
			colosseumBattleControl.init(new string[2]
			{
				UserData.Current.PlayerName,
				opponentData.Name
			});
			colosseumBattleControl.BattleStartResponse = sessionState.StartResponse;
			int teamIndex = 0;
			int opponentIndex = 1;
			setMyTeam(colosseumBattleControl, teamIndex);
			setOpponentTeam(colosseumBattleControl, opponentIndex, opponentData);
			addDailyCoverSkills(colosseumBattleControl, sessionState.DailyPassiveSkills);
			colosseumBattleControl.NextScene = sessionState.Params.nextScene;
			colosseumBattleControl.exec();
		}
	}

	private void setMyTeam(ColosseumBattleControl btlCtrl, int teamIndex)
	{
		if (!(btlCtrl != null))
		{
			throw new AssertionFailedException("btlCtrl != null");
		}
		string playerName = UserData.Current.PlayerName;
		int level = UserData.Current.Level;
		double rankPoint = UserData.Current.userBreeder.BreederRankPoint;
		int breederRankId = UserData.Current.userBreeder.BreederRankId;
		btlCtrl.setTeamInfo(teamIndex, playerName, level, rankPoint, breederRankId);
		addMyMembers(btlCtrl, teamIndex, UserData.Current.CurrentPoppetDeck);
	}

	private void setOpponentTeam(ColosseumBattleControl btlCtrl, int opponentIndex, RespOpponentWithOrganize oppData)
	{
		if (!(btlCtrl != null))
		{
			throw new AssertionFailedException("btlCtrl != null");
		}
		if (oppData == null)
		{
			throw new AssertionFailedException("oppData != null");
		}
		string text = oppData.Name;
		int level = oppData.Level;
		double breederRankPoint = oppData.BreederRankPoint;
		int breederRankId = oppData.BreederRankId;
		btlCtrl.setTeamInfo(opponentIndex, text, level, breederRankPoint, breederRankId);
		addOpponentMembers(btlCtrl, opponentIndex, oppData);
	}

	private void addMyMembers(ColosseumBattleControl btlCtrl, int teamIndex, RespPoppetDeck deck)
	{
		if (!(btlCtrl != null))
		{
			throw new AssertionFailedException("btlCtrl != null");
		}
		if (deck == null)
		{
			throw new AssertionFailedException("deck != null");
		}
		int num = 0;
		int length = deck.PlayerPoppetDecks.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			RespPlayerPoppetDeck[] playerPoppetDecks = deck.PlayerPoppetDecks;
			RespPlayerPoppetDeck respPlayerPoppetDeck = playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, index)];
			if (respPlayerPoppetDeck != null)
			{
				RespPoppet respPoppet = respPlayerPoppetDeck.BoxPoppet;
				RespWeapon boxWeapon = respPlayerPoppetDeck.BoxWeapon;
				if (respPoppet == null)
				{
					respPoppet = new RespPoppet(2);
				}
				btlCtrl.addMember(teamIndex, respPoppet, boxWeapon, respPlayerPoppetDeck.IsLeader);
			}
		}
	}

	private void addOpponentMembers(ColosseumBattleControl btlCtrl, int teamIndex, RespOpponentWithOrganize oppData)
	{
		if (!(btlCtrl != null))
		{
			throw new AssertionFailedException("btlCtrl != null");
		}
		if (oppData == null)
		{
			throw new AssertionFailedException("oppData != null");
		}
		RespColosseumBattlePoppet[] organize = oppData.Organize;
		int num = 0;
		int length = organize.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			RespColosseumBattlePoppet respColosseumBattlePoppet = organize[RuntimeServices.NormalizeArrayIndex(organize, index)];
			RespPoppet respPoppet = respColosseumBattlePoppet.PoppetData;
			RespWeapon weaponData = respColosseumBattlePoppet.WeaponData;
			if (respPoppet == null)
			{
				respPoppet = new RespPoppet(2);
			}
			btlCtrl.addMember(teamIndex, respPoppet, weaponData, respColosseumBattlePoppet.IsLeader);
			UserData.Current.userMiscInfo.poppetBookData.look(respPoppet.Master);
		}
	}

	private void addDailyCoverSkills(ColosseumBattleControl btlCtrl, int[] skillIds)
	{
		if (!(btlCtrl != null))
		{
			throw new AssertionFailedException("btlCtrl != null");
		}
		if (skillIds == null)
		{
			throw new AssertionFailedException("skillIds != null");
		}
		int i = 0;
		for (int length = skillIds.Length; i < length; i = checked(i + 1))
		{
			btlCtrl.addCoverSkill(MCoverSkills.Get(skillIds[i]));
		}
	}

	internal void _0024Update_0024closure_00243107()
	{
		gotoBattle();
	}
}
