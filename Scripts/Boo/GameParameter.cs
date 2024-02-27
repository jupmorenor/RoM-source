using System;
using System.Collections;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class GameParameter : MonoBehaviour
{
	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GameParameter/GameParameter";

	[NonSerialized]
	private static GameParameter __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	public static bool questFreeRun;

	[NonSerialized]
	public static bool lockonShader;

	[NonSerialized]
	public static bool notDead;

	[NonSerialized]
	public static bool oneHitKill;

	[NonSerialized]
	public static bool jisatu;

	[NonSerialized]
	public static bool tutorialSkip;

	[NonSerialized]
	public static bool tooFast;

	[NonSerialized]
	public static bool renkeiFree;

	[NonSerialized]
	public static bool noQuestDiscoveringPop;

	[NonSerialized]
	public static bool killPoppetIfBattleOpen;

	[NonSerialized]
	public static bool noSkillCoolDown;

	[NonSerialized]
	public static bool soundMute;

	[NonSerialized]
	public static bool itsFriend;

	[NonSerialized]
	public static bool notDeadPoppet;

	[NonSerialized]
	public static bool notDeadMonster;

	[NonSerialized]
	public static bool showMemroyWarning;

	[NonSerialized]
	public static bool unloadUnusedAssetsMemroyWarning;

	[NonSerialized]
	public static bool noBattle;

	[NonSerialized]
	public static bool enableCollisionEnter = true;

	[NonSerialized]
	public static bool shortenBattleResetTime;

	[NonSerialized]
	public static bool alwaysCritical;

	[NonSerialized]
	public static bool alwaysGuard;

	[NonSerialized]
	public static bool alwaysAbnormalStateAttack;

	[NonSerialized]
	public static bool alwaysResistAbnormalStateAttack;

	[NonSerialized]
	public static EnumAbnormalStates defaultAbnormalStateType = EnumAbnormalStates.Poison;

	[NonSerialized]
	public static bool forceAutoRun;

	[NonSerialized]
	public static bool showItemMasterId;

	[NonSerialized]
	public static bool alwaysOpenResultShortcut;

	public static GameParameter Instance
	{
		get
		{
			GameParameter _instance;
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
				__instance = ((GameParameter)UnityEngine.Object.FindObjectOfType(typeof(GameParameter))) as GameParameter;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static GameParameter CurrentInstance => __instance;

	public void _0024singleton_0024awake_00241607()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241607();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static GameParameter _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GameParameter/GameParameter");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "GameParameter" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		GameParameter gameParameter = ExtensionsModule.SetComponent<GameParameter>(gameObject2);
		if ((bool)gameParameter)
		{
			gameParameter._createInstance_callback();
		}
		return gameParameter;
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

	public void _0024singleton_0024appQuit_00241608()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241608();
		quitApp = true;
	}

	public static string serialize()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["questFreeRun"] = questFreeRun;
		hashtable["lockonShader"] = lockonShader;
		hashtable["notDead"] = notDead;
		hashtable["oneHitKill"] = oneHitKill;
		hashtable["jisatu"] = jisatu;
		hashtable["tutorialSkip"] = tutorialSkip;
		hashtable["tooFast"] = tooFast;
		hashtable["renkeiFree"] = renkeiFree;
		hashtable["noQuestDiscoveringPop"] = noQuestDiscoveringPop;
		hashtable["killPoppetIfBattleOpen"] = killPoppetIfBattleOpen;
		hashtable["noSkillCoolDown"] = noSkillCoolDown;
		hashtable["soundMute"] = soundMute;
		hashtable["itsFriend"] = itsFriend;
		hashtable["notDeadPoppet"] = notDeadPoppet;
		hashtable["notDeadMonster"] = notDeadMonster;
		hashtable["showMemroyWarning"] = showMemroyWarning;
		hashtable["unloadUnusedAssetsMemroyWarning"] = unloadUnusedAssetsMemroyWarning;
		hashtable["noBattle"] = noBattle;
		hashtable["enableCollisionEnter"] = enableCollisionEnter;
		hashtable["shortenBattleResetTime"] = shortenBattleResetTime;
		hashtable["alwaysCritical"] = alwaysCritical;
		hashtable["alwaysGuard"] = alwaysGuard;
		hashtable["alwaysAbnormalStateAttack"] = alwaysAbnormalStateAttack;
		hashtable["alwaysResistAbnormalStateAttack"] = alwaysResistAbnormalStateAttack;
		hashtable["defaultAbnormalStateType"] = (int)defaultAbnormalStateType;
		hashtable["forceAutoRun"] = forceAutoRun;
		hashtable["showItemMasterId"] = showItemMasterId;
		hashtable["alwaysOpenResultShortcut"] = alwaysOpenResultShortcut;
		return NGUIJson.jsonEncode(hashtable);
	}

	public static void deserialize(string data)
	{
		if (!string.IsNullOrEmpty(data) && NGUIJson.jsonDecode(data) is Hashtable hashtable)
		{
			if (hashtable.ContainsKey("questFreeRun"))
			{
				questFreeRun = RuntimeServices.UnboxBoolean(hashtable["questFreeRun"]);
			}
			if (hashtable.ContainsKey("lockonShader"))
			{
				lockonShader = RuntimeServices.UnboxBoolean(hashtable["lockonShader"]);
			}
			if (hashtable.ContainsKey("notDead"))
			{
				notDead = RuntimeServices.UnboxBoolean(hashtable["notDead"]);
			}
			if (hashtable.ContainsKey("oneHitKill"))
			{
				oneHitKill = RuntimeServices.UnboxBoolean(hashtable["oneHitKill"]);
			}
			if (hashtable.ContainsKey("jisatu"))
			{
				jisatu = RuntimeServices.UnboxBoolean(hashtable["jisatu"]);
			}
			if (hashtable.ContainsKey("tutorialSkip"))
			{
				tutorialSkip = RuntimeServices.UnboxBoolean(hashtable["tutorialSkip"]);
			}
			if (hashtable.ContainsKey("tooFast"))
			{
				tooFast = RuntimeServices.UnboxBoolean(hashtable["tooFast"]);
			}
			if (hashtable.ContainsKey("renkeiFree"))
			{
				renkeiFree = RuntimeServices.UnboxBoolean(hashtable["renkeiFree"]);
			}
			if (hashtable.ContainsKey("noQuestDiscoveringPop"))
			{
				noQuestDiscoveringPop = RuntimeServices.UnboxBoolean(hashtable["noQuestDiscoveringPop"]);
			}
			if (hashtable.ContainsKey("killPoppetIfBattleOpen"))
			{
				killPoppetIfBattleOpen = RuntimeServices.UnboxBoolean(hashtable["killPoppetIfBattleOpen"]);
			}
			if (hashtable.ContainsKey("noSkillCoolDown"))
			{
				noSkillCoolDown = RuntimeServices.UnboxBoolean(hashtable["noSkillCoolDown"]);
			}
			if (hashtable.ContainsKey("soundMute"))
			{
				soundMute = RuntimeServices.UnboxBoolean(hashtable["soundMute"]);
			}
			if (hashtable.ContainsKey("itsFriend"))
			{
				itsFriend = RuntimeServices.UnboxBoolean(hashtable["itsFriend"]);
			}
			if (hashtable.ContainsKey("notDeadPoppet"))
			{
				notDeadPoppet = RuntimeServices.UnboxBoolean(hashtable["notDeadPoppet"]);
			}
			if (hashtable.ContainsKey("notDeadMonster"))
			{
				notDeadMonster = RuntimeServices.UnboxBoolean(hashtable["notDeadMonster"]);
			}
			if (hashtable.ContainsKey("showMemroyWarning"))
			{
				showMemroyWarning = RuntimeServices.UnboxBoolean(hashtable["showMemroyWarning"]);
			}
			if (hashtable.ContainsKey("unloadUnusedAssetsMemroyWarning"))
			{
				unloadUnusedAssetsMemroyWarning = RuntimeServices.UnboxBoolean(hashtable["unloadUnusedAssetsMemroyWarning"]);
			}
			if (hashtable.ContainsKey("noBattle"))
			{
				noBattle = RuntimeServices.UnboxBoolean(hashtable["noBattle"]);
			}
			if (hashtable.ContainsKey("enableCollisionEnter"))
			{
				enableCollisionEnter = RuntimeServices.UnboxBoolean(hashtable["enableCollisionEnter"]);
			}
			if (hashtable.ContainsKey("shortenBattleResetTime"))
			{
				shortenBattleResetTime = RuntimeServices.UnboxBoolean(hashtable["shortenBattleResetTime"]);
			}
			if (hashtable.ContainsKey("alwaysCritical"))
			{
				alwaysCritical = RuntimeServices.UnboxBoolean(hashtable["alwaysCritical"]);
			}
			if (hashtable.ContainsKey("alwaysGuard"))
			{
				alwaysGuard = RuntimeServices.UnboxBoolean(hashtable["alwaysGuard"]);
			}
			if (hashtable.ContainsKey("alwaysAbnormalStateAttack"))
			{
				alwaysAbnormalStateAttack = RuntimeServices.UnboxBoolean(hashtable["alwaysAbnormalStateAttack"]);
			}
			if (hashtable.ContainsKey("alwaysResistAbnormalStateAttack"))
			{
				alwaysResistAbnormalStateAttack = RuntimeServices.UnboxBoolean(hashtable["alwaysResistAbnormalStateAttack"]);
			}
			if (hashtable.ContainsKey("defaultAbnormalStateType"))
			{
				defaultAbnormalStateType = (EnumAbnormalStates)RuntimeServices.UnboxInt32(hashtable["defaultAbnormalStateType"]);
			}
			if (hashtable.ContainsKey("forceAutoRun"))
			{
				forceAutoRun = RuntimeServices.UnboxBoolean(hashtable["forceAutoRun"]);
			}
			if (hashtable.ContainsKey("showItemMasterId"))
			{
				showItemMasterId = RuntimeServices.UnboxBoolean(hashtable["showItemMasterId"]);
			}
			if (hashtable.ContainsKey("alwaysOpenResultShortcut"))
			{
				alwaysOpenResultShortcut = RuntimeServices.UnboxBoolean(hashtable["alwaysOpenResultShortcut"]);
			}
		}
	}

	public static void Save()
	{
	}

	public static void Load()
	{
	}

	public void Update()
	{
		UserData current = UserData.Current;
		if (current != null)
		{
			current.UpdateActPoint();
			current.UpdateRaidPoint();
		}
	}
}
