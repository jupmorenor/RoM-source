using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class QuestClearConditionChecker : MonoBehaviour
{
	[Serializable]
	public enum Statuses
	{
		None,
		Cleared,
		Failed,
		TimeOver,
		Stop
	}

	[Serializable]
	internal class _0024checkKilledMonster_0024locals_002414415
	{
		internal int _0024mid;
	}

	[Serializable]
	internal class _0024satisfyTalk_0024locals_002414416
	{
		internal int _0024npcTalkId;
	}

	[Serializable]
	internal class _0024satisfyArrive_0024locals_002414417
	{
		internal GameObject _0024trigger;
	}

	[Serializable]
	internal class _0024satisfyKusamushi_0024locals_002414418
	{
		internal int _0024pickedUpNum;
	}

	[Serializable]
	internal class _0024checkKilledMonster_0024closure_00242864
	{
		internal _0024checkKilledMonster_0024locals_002414415 _0024_0024locals_002414954;

		public _0024checkKilledMonster_0024closure_00242864(_0024checkKilledMonster_0024locals_002414415 _0024_0024locals_002414954)
		{
			this._0024_0024locals_002414954 = _0024_0024locals_002414954;
		}

		public bool Invoke(MQuestClears cc)
		{
			return (cc.Target2 == _0024_0024locals_002414954._0024mid && QuestSession.GetKilledMonsterNum(_0024_0024locals_002414954._0024mid) >= cc.Value) ? true : false;
		}
	}

	[Serializable]
	internal class _0024satisfyTalk_0024closure_00242866
	{
		internal _0024satisfyTalk_0024locals_002414416 _0024_0024locals_002414955;

		public _0024satisfyTalk_0024closure_00242866(_0024satisfyTalk_0024locals_002414416 _0024_0024locals_002414955)
		{
			this._0024_0024locals_002414955 = _0024_0024locals_002414955;
		}

		public bool Invoke(MQuestClears cc)
		{
			bool num = _0024_0024locals_002414955._0024npcTalkId > 0;
			if (num)
			{
				num = _0024_0024locals_002414955._0024npcTalkId == cc.Target2;
			}
			return num;
		}
	}

	[Serializable]
	internal class _0024satisfyArrive_0024closure_00242867
	{
		internal _0024satisfyArrive_0024locals_002414417 _0024_0024locals_002414956;

		public _0024satisfyArrive_0024closure_00242867(_0024satisfyArrive_0024locals_002414417 _0024_0024locals_002414956)
		{
			this._0024_0024locals_002414956 = _0024_0024locals_002414956;
		}

		public bool Invoke(MQuestClears cc)
		{
			return !(_0024_0024locals_002414956._0024trigger == null) && !string.IsNullOrEmpty(cc.Target) && _0024_0024locals_002414956._0024trigger.name.ToLower() == cc.Target.ToLower();
		}
	}

	[Serializable]
	internal class _0024satisfyKusamushi_0024closure_00242868
	{
		internal _0024satisfyKusamushi_0024locals_002414418 _0024_0024locals_002414957;

		public _0024satisfyKusamushi_0024closure_00242868(_0024satisfyKusamushi_0024locals_002414418 _0024_0024locals_002414957)
		{
			this._0024_0024locals_002414957 = _0024_0024locals_002414957;
		}

		public bool Invoke(MQuestClears cc)
		{
			return cc.KusamushiNum <= _0024_0024locals_002414957._0024pickedUpNum;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024forbidPlayerAction_002418715 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024_0024wait_frame_0024temp_00241689_002418716;

			internal int _0024_00243923_002418717;

			internal PlayerControl _0024pl_002418718;

			internal bool _0024toIdle_002418719;

			public _0024(PlayerControl pl, bool toIdle)
			{
				_0024pl_002418718 = pl;
				_0024toIdle_002418719 = toIdle;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024pl_002418718 == null)
					{
						goto case 1;
					}
					_0024pl_002418718.InputActive = false;
					_0024pl_002418718.noHitAttack = true;
					if (_0024toIdle_002418719)
					{
						_0024pl_002418718.forceToIdle();
						_0024_0024wait_frame_0024temp_00241689_002418716 = 2;
						goto case 2;
					}
					goto IL_009a;
				case 2:
				{
					int num = (_0024_0024wait_frame_0024temp_00241689_002418716 = checked((_0024_00243923_002418717 = _0024_0024wait_frame_0024temp_00241689_002418716) - 1));
					if (_0024_00243923_002418717 >= 0)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_009a;
				}
				case 1:
					{
						result = 0;
						break;
					}
					IL_009a:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024pl_002418720;

		internal bool _0024toIdle_002418721;

		public _0024forbidPlayerAction_002418715(PlayerControl pl, bool toIdle)
		{
			_0024pl_002418720 = pl;
			_0024toIdle_002418721 = toIdle;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024pl_002418720, _0024toIdle_002418721);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024questFailedRoutine_002418722 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal PlayerControl _0024pl_002418723;

			internal IEnumerator _0024_0024sco_0024temp_00241690_002418724;

			internal float _0024_0024wait_sec_0024temp_00241691_002418725;

			internal QuestClearConditionChecker _0024self__002418726;

			public _0024(QuestClearConditionChecker self_)
			{
				_0024self__002418726 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					StartButton.ForceDestroy();
					goto case 2;
				case 2:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002418723 = PlayerControl.CurrentPlayer;
					_0024_0024sco_0024temp_00241690_002418724 = _0024self__002418726.forbidPlayerAction(_0024pl_002418723, toIdle: false);
					if (_0024_0024sco_0024temp_00241690_002418724 != null)
					{
						result = (Yield(3, _0024self__002418726.StartCoroutine(_0024_0024sco_0024temp_00241690_002418724)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024_0024wait_sec_0024temp_00241691_002418725 = 1f;
					goto case 4;
				case 4:
					if (_0024_0024wait_sec_0024temp_00241691_002418725 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241691_002418725 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002418726.finishQuest();
					JumpToNextSceneIfNeed();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal QuestClearConditionChecker _0024self__002418727;

		public _0024questFailedRoutine_002418722(QuestClearConditionChecker self_)
		{
			_0024self__002418727 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418727);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024questTimeOverRoutine_002418728 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal PlayerControl _0024pl_002418729;

			internal IEnumerator _0024_0024sco_0024temp_00241692_002418730;

			internal GameObject _0024failLogo_002418731;

			internal float _0024_0024wait_sec_0024temp_00241693_002418732;

			internal QuestClearConditionChecker _0024self__002418733;

			public _0024(QuestClearConditionChecker self_)
			{
				_0024self__002418733 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					StartButton.ForceDestroy();
					goto case 2;
				case 2:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002418729 = PlayerControl.CurrentPlayer;
					_0024_0024sco_0024temp_00241692_002418730 = _0024self__002418733.forbidPlayerAction(_0024pl_002418729, toIdle: true);
					if (_0024_0024sco_0024temp_00241692_002418730 != null)
					{
						result = (Yield(3, _0024self__002418733.StartCoroutine(_0024_0024sco_0024temp_00241692_002418730)) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					_0024failLogo_002418731 = GameAssetModule.InstantiatePrefab("Prefab/GUI/SignTimeOver");
					_0024_0024wait_sec_0024temp_00241693_002418732 = 3.5f;
					goto case 4;
				case 4:
					if (_0024_0024wait_sec_0024temp_00241693_002418732 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241693_002418732 -= Time.deltaTime;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024self__002418733.finishQuest();
					JumpToNextSceneIfNeed();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal QuestClearConditionChecker _0024self__002418734;

		public _0024questTimeOverRoutine_002418728(QuestClearConditionChecker self_)
		{
			_0024self__002418734 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418734);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024questClearRoutine_002418735 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal MQuests _0024q_002418736;

			internal IEnumerator _0024_0024sco_0024temp_00241694_002418737;

			internal string _0024logoPrefab_002418738;

			internal GameObject _0024clearLogo_002418739;

			internal float _0024_0024wait_sec_0024temp_00241695_002418740;

			internal QuestClearConditionChecker _0024self__002418741;

			public _0024(QuestClearConditionChecker self_)
			{
				_0024self__002418741 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024q_002418736 = QuestSession.Quest;
					if (_0024q_002418736 == null)
					{
						throw new AssertionFailedException("えー？おかしなプレイしたんじゃない？プレイ中クエスト（MQuests）データが無いよ？クエストのunityシーンを直起動とかした？");
					}
					StartButton.ForceDestroy();
					_0024_0024sco_0024temp_00241694_002418737 = _0024self__002418741.initPlayerAndPlayClearCutScene(_0024q_002418736);
					if (_0024_0024sco_0024temp_00241694_002418737 != null)
					{
						result = (Yield(2, _0024self__002418741.StartCoroutine(_0024_0024sco_0024temp_00241694_002418737)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (QuestSession.IsPlayingFinalQuest)
					{
						QuestSession.GotoEpilogueFromFinalQuest();
						goto case 1;
					}
					if (QuestSession.NeedEndLogo)
					{
						_0024logoPrefab_002418738 = ((!_0024q_002418736.IsChallenge) ? "Prefab/GUI/SignQuestClear" : "Prefab/GUI/SignChallengeClear");
						_0024clearLogo_002418739 = GameAssetModule.InstantiatePrefab(_0024logoPrefab_002418738);
						string[] bgmList = SQEX_SoundPlayerData.bgmList;
						GameSoundManager.PlayBgmDirect(bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, 23)], 1f, 0f, 0, -1);
						_0024_0024wait_sec_0024temp_00241695_002418740 = 3.5f;
						goto case 3;
					}
					goto IL_012d;
				case 3:
					if (_0024_0024wait_sec_0024temp_00241695_002418740 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241695_002418740 -= Time.deltaTime;
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_012d;
				case 1:
					{
						result = 0;
						break;
					}
					IL_012d:
					_0024self__002418741.finishQuest();
					JumpToNextSceneIfNeed();
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal QuestClearConditionChecker _0024self__002418742;

		public _0024questClearRoutine_002418735(QuestClearConditionChecker self_)
		{
			_0024self__002418742 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002418742);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024initPlayerAndPlayClearCutScene_002418743 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal bool _0024sceneChanged_002418744;

			internal bool _0024hasClearCutScene_002418745;

			internal PlayerControl _0024player_002418746;

			internal IEnumerator _0024_0024sco_0024temp_00241696_002418747;

			internal IEnumerator _0024_0024sco_0024temp_00241697_002418748;

			internal MQuests _0024q_002418749;

			internal QuestClearConditionChecker _0024self__002418750;

			public _0024(MQuests q, QuestClearConditionChecker self_)
			{
				_0024q_002418749 = q;
				_0024self__002418750 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024q_002418749 == null)
					{
						throw new AssertionFailedException("えー？おかしなプレイしたんじゃない？プレイ中クエスト（MQuests）データが無いよ？クエストのunityシーンを直起動とかした？");
					}
					_0024sceneChanged_002418744 = false;
					_0024hasClearCutScene_002418745 = !string.IsNullOrEmpty(_0024q_002418749.ClearCutScene);
					if (_0024hasClearCutScene_002418745)
					{
						FaderCore.Instance.fadeIn();
						goto case 2;
					}
					goto IL_0096;
				case 2:
					if (!FaderCore.Instance.isCompleted)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto IL_0096;
				case 3:
				case 4:
					if (!SceneChanger.isCompletelyReady)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					goto case 5;
				case 5:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					_0024player_002418746 = PlayerControl.CurrentPlayer;
					_0024_0024sco_0024temp_00241696_002418747 = _0024self__002418750.forbidPlayerAction(_0024player_002418746, toIdle: true);
					if (_0024_0024sco_0024temp_00241696_002418747 != null)
					{
						result = (Yield(6, _0024self__002418750.StartCoroutine(_0024_0024sco_0024temp_00241696_002418747)) ? 1 : 0);
						break;
					}
					goto case 6;
				case 6:
					if (!string.IsNullOrEmpty(_0024q_002418749.MScenePlayerPosition))
					{
						GameLevelManager.SetNpcPos(_0024player_002418746.transform, _0024q_002418749.MScenePlayerPosition);
					}
					if (_0024hasClearCutScene_002418745)
					{
						_0024_0024sco_0024temp_00241697_002418748 = QuestCutscenePlayer.Instance.playCutSceneFadeSafe(_0024q_002418749.ClearCutScene);
						if (_0024_0024sco_0024temp_00241697_002418748 != null)
						{
							result = (Yield(7, _0024self__002418750.StartCoroutine(_0024_0024sco_0024temp_00241697_002418748)) ? 1 : 0);
							break;
						}
					}
					goto case 7;
				case 7:
					YieldDefault(1);
					goto case 1;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0096:
					if (_0024q_002418749.MSceneWhenClear != null)
					{
						_0024sceneChanged_002418744 = QuestSession.LoadStageScene(_0024q_002418749.MSceneWhenClear, !_0024hasClearCutScene_002418745);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 5;
				}
				return (byte)result != 0;
			}
		}

		internal MQuests _0024q_002418751;

		internal QuestClearConditionChecker _0024self__002418752;

		public _0024initPlayerAndPlayClearCutScene_002418743(MQuests q, QuestClearConditionChecker self_)
		{
			_0024q_002418751 = q;
			_0024self__002418752 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024q_002418751, _0024self__002418752);
		}
	}

	[NonSerialized]
	private static QuestClearConditionChecker __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private const string QUEST_CLEAR_LOGO = "Prefab/GUI/SignQuestClear";

	[NonSerialized]
	private const string CHALLENGE_CLEAR_LOGO = "Prefab/GUI/SignChallengeClear";

	[NonSerialized]
	public const int COND_NUM = 3;

	private bool[] currentStatus;

	private float elapsedTime;

	private bool paused;

	private Statuses status;

	private bool finished;

	public static QuestClearConditionChecker Instance
	{
		get
		{
			QuestClearConditionChecker _instance;
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
				__instance = ((QuestClearConditionChecker)UnityEngine.Object.FindObjectOfType(typeof(QuestClearConditionChecker))) as QuestClearConditionChecker;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static QuestClearConditionChecker CurrentInstance => __instance;

	public bool HasAllEnemies => hasCondition(EnumQuestClearTypes.AllEnemies);

	public bool HasSomeEnemies => hasCondition(EnumQuestClearTypes.SomeEnemies);

	public bool HasLimitTime => LimitTime > 0;

	public int LimitTime => QuestSession.Quest?.LimitTime ?? 0;

	public MQuestClears[] CurrentConditions
	{
		get
		{
			MQuests quest = QuestSession.Quest;
			return (quest == null) ? new MQuestClears[3] : new MQuestClears[3] { quest.Clear_1, quest.Clear_2, quest.Clear_3 };
		}
	}

	private static string ResultSceneName
	{
		get
		{
			MQuests quest = QuestSession.Quest;
			if (quest == null)
			{
				goto IL_0038;
			}
			object result;
			if (quest.QuestType == EnumQuestTypes.Challenge)
			{
				result = "Ui_WorldChallengeResult";
			}
			else
			{
				if (quest.QuestType != EnumQuestTypes.RaidTutorial)
				{
					goto IL_0038;
				}
				result = "Ui_WorldRaidResult";
			}
			goto IL_003d;
			IL_0038:
			result = "Ui_WorldQuestResult";
			goto IL_003d;
			IL_003d:
			return (string)result;
		}
	}

	public bool[] CurrentStatus => currentStatus;

	public float ElapsedTime => elapsedTime;

	public bool Paused => paused;

	public Statuses Status => status;

	public bool Finished => finished;

	public QuestClearConditionChecker()
	{
		currentStatus = new bool[3];
		status = Statuses.Stop;
	}

	public void _0024singleton_0024awake_00241684()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241684();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static QuestClearConditionChecker _createInstance()
	{
		string text = "__" + "QuestClearConditionChecker" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		QuestClearConditionChecker questClearConditionChecker = ExtensionsModule.SetComponent<QuestClearConditionChecker>(gameObject);
		if ((bool)questClearConditionChecker)
		{
			questClearConditionChecker._createInstance_callback();
		}
		return questClearConditionChecker;
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

	public void _0024singleton_0024appQuit_00241685()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241685();
		quitApp = true;
	}

	public bool hasCondition(EnumQuestClearTypes type)
	{
		int num = 0;
		MQuestClears[] currentConditions = CurrentConditions;
		int length = currentConditions.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (currentConditions[num] != null && currentConditions[num].ClearType == type)
				{
					result = 1;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public void doSomeEnemiesCondition(__QuestClearConditionChecker_doSomeEnemiesCondition_0024callable76_002448_45__ h)
	{
		if (h == null)
		{
			return;
		}
		int i = 0;
		MQuestClears[] currentConditions = CurrentConditions;
		for (int length = currentConditions.Length; i < length; i = checked(i + 1))
		{
			if (currentConditions[i] != null && currentConditions[i].ClearType == EnumQuestClearTypes.SomeEnemies)
			{
				h(currentConditions[i].Target2, currentConditions[i].Value);
			}
		}
	}

	public void clearCondition()
	{
		status = Statuses.None;
		finished = false;
		int num = 0;
		int length = currentStatus.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			bool[] array = currentStatus;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = false;
		}
	}

	public void stop()
	{
		status = Statuses.Stop;
	}

	public void satisfyBoss()
	{
		evaluate(EnumQuestClearTypes.Boss, (MQuestClears cc) => true);
	}

	public void checkKilledMonster(int mid)
	{
		_0024checkKilledMonster_0024locals_002414415 _0024checkKilledMonster_0024locals_0024 = new _0024checkKilledMonster_0024locals_002414415();
		_0024checkKilledMonster_0024locals_0024._0024mid = mid;
		evaluate(EnumQuestClearTypes.SomeEnemies, new _0024checkKilledMonster_0024closure_00242864(_0024checkKilledMonster_0024locals_0024).Invoke);
	}

	public void satisfyAllEnemies()
	{
		evaluate(EnumQuestClearTypes.AllEnemies, (MQuestClears cc) => true);
	}

	public void satisfyTalk(int npcTalkId)
	{
		_0024satisfyTalk_0024locals_002414416 _0024satisfyTalk_0024locals_0024 = new _0024satisfyTalk_0024locals_002414416();
		_0024satisfyTalk_0024locals_0024._0024npcTalkId = npcTalkId;
		evaluate(EnumQuestClearTypes.Talk, new _0024satisfyTalk_0024closure_00242866(_0024satisfyTalk_0024locals_0024).Invoke);
	}

	public void satisfyArrive(GameObject trigger)
	{
		_0024satisfyArrive_0024locals_002414417 _0024satisfyArrive_0024locals_0024 = new _0024satisfyArrive_0024locals_002414417();
		_0024satisfyArrive_0024locals_0024._0024trigger = trigger;
		evaluate(EnumQuestClearTypes.Arrive, new _0024satisfyArrive_0024closure_00242867(_0024satisfyArrive_0024locals_0024).Invoke);
	}

	public void satisfyKusamushi(int pickedUpNum)
	{
		_0024satisfyKusamushi_0024locals_002414418 _0024satisfyKusamushi_0024locals_0024 = new _0024satisfyKusamushi_0024locals_002414418();
		_0024satisfyKusamushi_0024locals_0024._0024pickedUpNum = pickedUpNum;
		evaluate(EnumQuestClearTypes.Kusamushi, new _0024satisfyKusamushi_0024closure_00242868(_0024satisfyKusamushi_0024locals_0024).Invoke);
	}

	public void initTimer()
	{
		elapsedTime = 0f;
		paused = true;
	}

	public void pauseTimer()
	{
		paused = true;
	}

	public void unpauseTimer()
	{
		paused = false;
	}

	public void Update()
	{
		int limitTime = LimitTime;
		if (!paused && limitTime > 0 && status == Statuses.None)
		{
			elapsedTime += Time.deltaTime;
			if (!(elapsedTime < (float)limitTime))
			{
				elapsedTime = limitTime;
				doTimeOver();
			}
		}
	}

	private void evaluate(EnumQuestClearTypes type, __QuestClearConditionChecker_evaluate_0024callable77_0024151_64__ pred)
	{
		if (pred == null || status != 0 || status == Statuses.Stop)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 3;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			MQuestClears[] currentConditions = CurrentConditions;
			MQuestClears mQuestClears = currentConditions[RuntimeServices.NormalizeArrayIndex(currentConditions, index)];
			if (mQuestClears != null)
			{
				num = checked(num + 1);
				if (mQuestClears.ClearType == type && pred(mQuestClears))
				{
					bool[] array = currentStatus;
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = true;
				}
				else if (mQuestClears.ClearType == EnumQuestClearTypes.True)
				{
					bool[] array2 = currentStatus;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = true;
				}
			}
			else
			{
				bool[] array3 = currentStatus;
				array3[RuntimeServices.NormalizeArrayIndex(array3, index)] = true;
			}
		}
		if (num > 0 && currentStatus[0] && currentStatus[1] && currentStatus[2])
		{
			doClear();
		}
	}

	public void doClear()
	{
		if (status == Statuses.None)
		{
			status = Statuses.Cleared;
			PlayerEventDispatcher.InvokeQuestEnd(PlayerControl.CurrentPlayer);
			QuestSession.SetSessionSucceeded();
			IEnumerator enumerator = questClearRoutine();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void doFail()
	{
		if (status == Statuses.None)
		{
			status = Statuses.Failed;
			QuestSession.SetSessionFailed();
			IEnumerator enumerator = questFailedRoutine();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void doTimeOver()
	{
		if (status == Statuses.None)
		{
			status = Statuses.TimeOver;
			QuestSession.SetSessionTimeover();
			IEnumerator enumerator = questTimeOverRoutine();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator forbidPlayerAction(PlayerControl pl, bool toIdle)
	{
		return new _0024forbidPlayerAction_002418715(pl, toIdle).GetEnumerator();
	}

	private IEnumerator questFailedRoutine()
	{
		return new _0024questFailedRoutine_002418722(this).GetEnumerator();
	}

	public static void JumpToNextSceneIfNeed()
	{
		if (QuestSession.NeedResultMode)
		{
			QuestInitializer.ChangeSceneFromQuest(ResultSceneName);
		}
	}

	private IEnumerator questTimeOverRoutine()
	{
		return new _0024questTimeOverRoutine_002418728(this).GetEnumerator();
	}

	private IEnumerator questClearRoutine()
	{
		return new _0024questClearRoutine_002418735(this).GetEnumerator();
	}

	private void finishQuest()
	{
		finished = true;
	}

	private IEnumerator initPlayerAndPlayClearCutScene(MQuests q)
	{
		return new _0024initPlayerAndPlayClearCutScene_002418743(q, this).GetEnumerator();
	}

	public void serialize(QuestSerializer ser)
	{
		ser.serialize(currentStatus);
		ser.serialize(elapsedTime);
		ser.serialize(paused);
	}

	public void deserialize(QuestSerializer ser)
	{
		currentStatus = ser.typedDeserialize<bool[]>();
		elapsedTime = ser.typedDeserialize<float>();
		paused = ser.typedDeserialize<bool>();
	}

	internal bool _0024satisfyBoss_0024closure_00242863(MQuestClears cc)
	{
		return true;
	}

	internal bool _0024satisfyAllEnemies_0024closure_00242865(MQuestClears cc)
	{
		return true;
	}
}
