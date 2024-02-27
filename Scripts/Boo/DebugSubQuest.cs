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
public class DebugSubQuest : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024291;

		public string _0024act_0024t_0024292;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024293;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024294;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024295;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024296;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024297;

		public __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ _0024act_0024t_0024298;

		public __ActionBase__0024act_0024t_0024299_0024callable17_002425_5__ _0024act_0024t_0024299;

		public IEnumerator _0024act_0024t_0024303;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024291.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassbattleMissionInfoMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassv3ChallengeMaster : ActionBase
	{
		public MChallengeQuestSchedules[] schedules;

		public MQuests[] quests;
	}

	[Serializable]
	public class ActionClassallQuestMasterMode : ActionBase
	{
		public MQuests[] quests;

		public int pageLines;
	}

	[Serializable]
	public class ActionClassallQuestMasterSubMode : ActionBase
	{
		public MQuests q;
	}

	[Serializable]
	public class ActionClassstoryMasterMode : ActionBase
	{
		public MStories story;
	}

	[Serializable]
	public class ActionClassclearSuccMode : ActionBase
	{
		public MQuests quest;

		public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod;

		public MStories story;
	}

	[Serializable]
	public class ActionClassnpcMode : ActionBase
	{
		public MNpcs npc;

		public int nspc;

		public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod;
	}

	[Serializable]
	public class ActionClassmonsterMode : ActionBase
	{
		public MStageMonsters m;

		public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod;

		public MItemGroupChilds[] drops;
	}

	[Serializable]
	public class ActionClassrespMonsterMode : ActionBase
	{
		public RespMonster m;

		public __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod;
	}

	[Serializable]
	public class ActionClassallAreaMasterMode : ActionBase
	{
		public int selArea;
	}

	[Serializable]
	public class ActionClassareaMasterMode : ActionBase
	{
		public MAreas area;

		public int selQuest;

		public MQuests[] quests;
	}

	[Serializable]
	public class ActionClassquestMode : ActionBase
	{
		public MAreas area;

		public MQuests quest;
	}

	[Serializable]
	public class ActionClasssceneMasterMode : ActionBase
	{
		public MScenes scn;

		public MStories story;
	}

	[Serializable]
	public class ActionClasssessionDropMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClasskusamushiMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassmonsterMapMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassbattleInfoMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassopenedQuestListMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassopenedWeekEventsMode : ActionBase
	{
		public DateTime today;

		public DateTime localToday;

		public TimeSpan localNow;

		public int localTodayWeek;

		public Boo.Lang.List<string> data;
	}

	[Serializable]
	public enum ActionEnum
	{
		openedWeekEventsMode,
		openedQuestListMode,
		battleInfoMode,
		monsterMapMode,
		kusamushiMode,
		sessionDropMode,
		sceneMasterMode,
		questMode,
		areaMasterMode,
		allAreaMasterMode,
		respMonsterMode,
		monsterMode,
		npcMode,
		clearSuccMode,
		storyMasterMode,
		allQuestMasterSubMode,
		allQuestMasterMode,
		v3ChallengeMaster,
		battleMissionInfoMode,
		mainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024sortQuestArray_0024locals_002414286
	{
		internal __DebugSubQuest_sortQuestArray_0024callable157_0024348_19__ _0024dpn;
	}

	[Serializable]
	internal class _0024displayQuest_0024locals_002414287
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024backMethod;
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00243037_0024locals_002414288
	{
		internal MStories _0024story;
	}

	[Serializable]
	internal class _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289
	{
		internal MQuests _0024q;

		internal ActionClassallQuestMasterMode _0024_0024act_0024t_0024312;
	}

	[Serializable]
	internal class _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290
	{
		internal ActionClassstoryMasterMode _0024_0024act_0024t_0024318;
	}

	[Serializable]
	internal class _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291
	{
		internal MItemGroups _0024ig;
	}

	[Serializable]
	internal class _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292
	{
		internal ActionClassareaMasterMode _0024_0024act_0024t_0024336;
	}

	[Serializable]
	internal class _0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293
	{
		internal ActionClassquestMode _0024_0024act_0024t_0024339;
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243038
	{
		internal DebugSubQuest _0024this_002414655;

		internal _0024_0024createDatamainMode_0024closure_00243037_0024locals_002414288 _0024_0024locals_002414656;

		public _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243038(DebugSubQuest _0024this_002414655, _0024_0024createDatamainMode_0024closure_00243037_0024locals_002414288 _0024_0024locals_002414656)
		{
			this._0024this_002414655 = _0024this_002414655;
			this._0024_0024locals_002414656 = _0024_0024locals_002414656;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("現storyマスタ") && _0024_0024locals_002414656._0024story != null)
			{
				_0024this_002414655.storyMasterMode(_0024_0024locals_002414656._0024story);
			}
			if (RuntimeDebugModeGuiMixin.button("全areaマスタ"))
			{
				_0024this_002414655.allAreaMasterMode();
			}
		}
	}

	[Serializable]
	internal class _0024createDatamainMode_0024closure_00243037
	{
		internal bool _0024_002414265_002414657;

		internal DebugSubQuest _0024this_002414658;

		public _0024createDatamainMode_0024closure_00243037(bool _0024_002414265_002414657, DebugSubQuest _0024this_002414658)
		{
			this._0024_002414265_002414657 = _0024_002414265_002414657;
			this._0024this_002414658 = _0024this_002414658;
		}

		public void Invoke(ActionClassmainMode _0024act_0024t_0024290)
		{
			_0024_0024createDatamainMode_0024closure_00243037_0024locals_002414288 _0024_0024createDatamainMode_0024closure_00243037_0024locals_0024 = new _0024_0024createDatamainMode_0024closure_00243037_0024locals_002414288();
			_0024_0024createDatamainMode_0024closure_00243037_0024locals_0024._0024story = QuestSession.Story;
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243038(_0024this_002414658, _0024_0024createDatamainMode_0024closure_00243037_0024locals_0024).Invoke));
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("現バトル情報"))
				{
					_0024this_002414658.battleInfoMode();
				}
				if (RuntimeDebugModeGuiMixin.button("獲得ドロップ一覧"))
				{
					_0024this_002414658.sessionDropMode();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("モンスター配備"))
				{
					_0024this_002414658.monsterMapMode();
				}
				if (RuntimeDebugModeGuiMixin.button("草虫一覧"))
				{
					_0024this_002414658.kusamushiMode();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("クエストオープン状況"))
				{
					_0024this_002414658.openedQuestListMode();
				}
				if (RuntimeDebugModeGuiMixin.button("MWeekEventsオープン状況"))
				{
					_0024this_002414658.openedWeekEventsMode();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("新チャレンジマスタ"))
				{
					_0024this_002414658.v3ChallengeMaster();
				}
				if (RuntimeDebugModeGuiMixin.button("battleミッション"))
				{
					_0024this_002414658.battleMissionInfoMode();
				}
			});
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("全クエスト  プレイもここから"))
			{
				_0024this_002414658.allQuestMasterMode();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("ワールドマップ\u3000チャレンジ・レイド切り替え");
			bool flag = QuestManager.debugMode == QuestManager.DebugMode.None;
			bool flag2 = QuestManager.debugMode == QuestManager.DebugMode.Challenge;
			bool flag3 = QuestManager.debugMode == QuestManager.DebugMode.Raid;
			bool flag4 = GUILayout.Toggle(flag, "日付通り");
			bool flag5 = GUILayout.Toggle(flag2, "チャレンジ");
			bool flag6 = GUILayout.Toggle(flag3, "レイド");
			if (flag4 && flag != flag4)
			{
				QuestManager.debugMode = QuestManager.DebugMode.None;
			}
			if (flag5 && flag2 != flag5)
			{
				QuestManager.debugMode = QuestManager.DebugMode.Challenge;
			}
			if (flag6 && flag3 != flag6)
			{
				QuestManager.debugMode = QuestManager.DebugMode.Raid;
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("お宝情報");
			QuestMenuBase.debug_disp_treasure = GUILayout.Toggle(QuestMenuBase.debug_disp_treasure, "お宝情報オープン");
			RuntimeDebugModeGuiMixin.space(10);
			QuestSessionParameters lastSessionParameter = QuestSession.LastSessionParameter;
			MQuests quest = QuestSession.Quest;
			string rhs = ((lastSessionParameter == null || !lastSessionParameter.withServer) ? "通信ナシ" : "通信中");
			RuntimeDebugModeGuiMixin.label("クエストセッション state:" + QuestSession.State + " " + rhs + " IsInQuest:" + QuestInitializer.IsInQuest + " IsInPlay:" + QuestInitializer.IsInPlay);
			RuntimeDebugModeGuiMixin.label("  現MStories : " + _0024_0024createDatamainMode_0024closure_00243037_0024locals_0024._0024story);
			if (quest != null)
			{
				RuntimeDebugModeGuiMixin.slabel("  現MQuests  : " + quest + " - STG:" + QuestSession.Stage);
				RuntimeDebugModeGuiMixin.slabel("     - QuestType " + quest.QuestType);
			}
			RuntimeDebugModeGuiMixin.slabel("  現MScenes  : " + QuestSession.CurrentScene);
			RuntimeDebugModeGuiMixin.slabel("  ジャンプ元MScenes : " + QuestSession.DebugPrevScene);
			RuntimeDebugModeGuiMixin.slabel("  ジャンプ先方向    : " + QuestSession.JumpToDir);
			RuntimeDebugModeGuiMixin.slabel("  最後のStageBattle : " + QuestBattleStarter.LastStartedBattle);
			RuntimeDebugModeGuiMixin.slabel("  訪問済みscn/総scn : " + ((ICollection)QuestSession.VisitedScenes).Count + "/" + QuestSession.AllScenes.Length);
			if (quest != null)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ATK補正 : 倍率=").Append(quest.AttackAdjMult).Append(" 加算=").Append(quest.AttackAdjPlus)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  HP 補正 : 倍率=").Append(quest.HpAdjMult).Append(" 加算=").Append(quest.HpAdjPlus)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  DEF補正 : 倍率=").Append(quest.DefenseAdjMult).Append(" 加算=").Append(quest.DefenseAdjPlus)
					.ToString());
			}
			RespQuestStart lastStartResponse = QuestSession.LastStartResponse;
			if (lastStartResponse == null)
			{
				RuntimeDebugModeGuiMixin.slabel("  QuestStart: <none>");
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("  QuestStart: OK");
			}
			MScenes currentScene = QuestSession.CurrentScene;
			RuntimeDebugModeGuiMixin.label("現在MScenes: " + currentScene);
			checked
			{
				if (currentScene != null)
				{
					__DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__ _DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__ = (object v) => (!RuntimeServices.ToBool(v)) ? string.Empty : "ブロックあり";
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     N  : ").Append(currentScene.N).Append(" dir(").Append(currentScene.DirN)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockN))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     NE : ").Append(currentScene.NE).Append(" dir(").Append(currentScene.DirNE)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockNE))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     E  : ").Append(currentScene.E).Append(" dir(").Append(currentScene.DirE)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockE))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     SE : ").Append(currentScene.SE).Append(" dir(").Append(currentScene.DirSE)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockSE))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     S  : ").Append(currentScene.S).Append(" dir(").Append(currentScene.DirS)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockS))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     SW : ").Append(currentScene.SW).Append(" dir(").Append(currentScene.DirSW)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockSW))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     W  : ").Append(currentScene.W).Append(" dir(").Append(currentScene.DirW)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockW))
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     NW : ").Append(currentScene.NW).Append(" dir(").Append(currentScene.DirNW)
						.Append(") ")
						.Append(_DebugSubQuest__0024createDatamainMode_0024closure_00243037_0024callable156_0024123_24__(currentScene.BlockNW))
						.ToString());
					int i = 0;
					MStageBattles[] allStageBattles = currentScene.AllStageBattles;
					bool flag7 = default(bool);
					for (int length = allStageBattles.Length; i < length; i++)
					{
						flag7 = true;
						_0024_002414265_002414657 = true;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   バトルマスタ:").Append(allStageBattles[i]).ToString());
						int j = 0;
						MStageMonsters[] allStageMonsters = allStageBattles[i].AllStageMonsters;
						for (int length2 = allStageMonsters.Length; j < length2; j++)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("     モンスター ").Append(allStageMonsters[j]).Append(" 率").ToString());
						}
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   カットシーン(前): ").Append(allStageBattles[i].PreBattleCutScene).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   カットシーン(後): ").Append(allStageBattles[i].PostBattleCutScene).ToString());
					}
					if (!flag7 && !_0024_002414265_002414657)
					{
						RuntimeDebugModeGuiMixin.slabel("   <バトルマスタ無し>");
					}
				}
				QuestClearConditionChecker instance = QuestClearConditionChecker.Instance;
				RuntimeDebugModeGuiMixin.label("クリア条件フラグ: " + instance.Status);
				Builtins.ZipEnumerator zipEnumerator = Builtins.zip(instance.CurrentConditions, instance.CurrentStatus, Builtins.range(100));
				try
				{
					while (zipEnumerator.MoveNext())
					{
						object obj = zipEnumerator.Current;
						if (!(obj is object[]))
						{
							obj = RuntimeServices.Coerce(obj, typeof(object[]));
						}
						object[] array = (object[])obj;
						object obj2 = array[0];
						if (!(obj2 is MQuestClears))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(MQuestClears));
						}
						MQuestClears mQuestClears = (MQuestClears)obj2;
						bool flag8 = RuntimeServices.UnboxBoolean(array[1]);
						object value = array[2];
						if (mQuestClears != null)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(value).Append(": ").Append(mQuestClears.ClearType)
								.Append(" = ")
								.Append(flag8)
								.ToString());
						}
						else
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(value).Append(": not specified").ToString());
						}
					}
				}
				finally
				{
					((IDisposable)zipEnumerator).Dispose();
				}
				if (quest != null)
				{
					if (quest.LimitTime > 0)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    LimitTime:  ").Append(instance.ElapsedTime).Append("/").Append((object)quest.LimitTime)
							.Append(" sec")
							.ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel("    LimitTime:  no limit");
					}
				}
				RuntimeDebugModeGuiMixin.label("報酬(通信データ)");
				if (QuestSession.AllQuestRewards != null)
				{
					RuntimeDebugModeGuiMixin.slabel("rewards: " + QuestSession.AllQuestRewards.Length);
					int k = 0;
					RespSimpleReward[] allQuestRewards = QuestSession.AllQuestRewards;
					for (int length3 = allQuestRewards.Length; k < length3; k++)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  * ").Append(allQuestRewards[k]).ToString());
					}
				}
				else
				{
					RuntimeDebugModeGuiMixin.slabel("<none>");
				}
				if (lastSessionParameter != null && lastSessionParameter.withServer)
				{
					RuntimeDebugModeGuiMixin.label("モンスター報酬(通信データ)");
				}
				else
				{
					RuntimeDebugModeGuiMixin.label("モンスター報酬(捏造データ)");
				}
				if (QuestSession.DebugAllQuestMonsters != null)
				{
					RespQuestStart lastStartResponse2 = QuestSession.LastStartResponse;
					if (lastStartResponse2 != null)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsSuccess : ").Append(lastStartResponse2.IsSuccess).Append(" Exp:").Append((object)lastStartResponse2.Exp)
							.Append(" Coin:")
							.Append((object)lastStartResponse2.Coin)
							.ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("DataKey   : ").Append(lastStartResponse2.DataKey).ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel("No Start Response");
					}
					RespMonster[] array2 = (RespMonster[])Builtins.array(typeof(RespMonster), QuestSession.DebugAllQuestMonsters);
					Array.Sort(array2, _0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440.Adapt((RespMonster a, RespMonster b) => a.Id - b.Id));
					RuntimeDebugModeGuiMixin.slabel("monsters: " + array2.Length);
					int l = 0;
					RespMonster[] array3 = array2;
					for (int length4 = array3.Length; l < length4; l++)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  * ").Append(array3[l]).ToString());
						int m = 0;
						RespSimpleReward[] rewards = array3[l].Rewards;
						for (int length5 = rewards.Length; m < length5; m++)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      - ").Append(rewards[m]).ToString());
						}
					}
				}
				else
				{
					RuntimeDebugModeGuiMixin.slabel("<none>");
				}
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("！！！！！！！！！！！！！！");
				RuntimeDebugModeGuiMixin.label("クエストをプレイするときは、");
				RuntimeDebugModeGuiMixin.label("上の「全クエスト」ボタンから！");
				RuntimeDebugModeGuiMixin.label("！！！！！！！！！！！！！！");
				RuntimeDebugModeGuiMixin.space(20);
				if (QuestInitializer.IsInQuest)
				{
					RuntimeDebugModeGuiMixin.space(20);
					RuntimeDebugModeGuiMixin.slabel("強制終了:ときどきうまくいかないことあり");
					RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						RuntimeDebugModeGuiMixin.toggle(ref QuestSession.LastSessionParameter.needResultMode, "結果画面");
						if (RuntimeDebugModeGuiMixin.button("強制成功"))
						{
							QuestClearConditionChecker.Instance.doClear();
							_0024this_002414658.ExitDebugMode();
						}
						else if (RuntimeDebugModeGuiMixin.button("強制失敗"))
						{
							QuestClearConditionChecker.Instance.doFail();
							_0024this_002414658.ExitDebugMode();
						}
						else if (RuntimeDebugModeGuiMixin.button("強制時間切れ"))
						{
							QuestClearConditionChecker.Instance.doTimeOver();
							_0024this_002414658.ExitDebugMode();
						}
					});
					RuntimeDebugModeGuiMixin.space(20);
				}
				RuntimeDebugModeGuiMixin.space(20);
				if (RuntimeDebugModeGuiMixin.button("serialize/deserialize test"))
				{
					QuestSessionParameters lastSessionParameter2 = QuestSession.LastSessionParameter;
					QuestSessionData session = QuestSession.Session;
					QuestGeometricSessionData geomSession = QuestSession.GeomSession;
					QuestSessionDataSerialize questSessionDataSerialize = new QuestSessionDataSerialize();
					byte[] data = questSessionDataSerialize.serialize(lastSessionParameter2, session, geomSession);
					QuestSessionParameters questSessionParameters = null;
					QuestSessionData questSessionData = null;
					QuestGeometricSessionData questGeometricSessionData = null;
					int outVersion = 0;
					object[] array4 = questSessionDataSerialize.deserialize(data, ref outVersion);
					object obj3 = array4[0];
					if (!(obj3 is QuestSessionParameters))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(QuestSessionParameters));
					}
					questSessionParameters = (QuestSessionParameters)obj3;
					object obj4 = array4[1];
					if (!(obj4 is QuestSessionData))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(QuestSessionData));
					}
					questSessionData = (QuestSessionData)obj4;
					object obj5 = array4[2];
					if (!(obj5 is QuestGeometricSessionData))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(QuestGeometricSessionData));
					}
					questGeometricSessionData = (QuestGeometricSessionData)obj5;
					if (questSessionParameters == null)
					{
						throw new AssertionFailedException("pnew != null");
					}
					questSessionParameters.checkIdentity(lastSessionParameter2);
				}
				if (RuntimeDebugModeGuiMixin.button("save"))
				{
					QuestSession.Save();
				}
				if (RuntimeDebugModeGuiMixin.button("load"))
				{
					MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						QuestSession.Load();
					});
					_0024this_002414658.ExitDebugMode();
				}
				if (RuntimeDebugModeGuiMixin.button("delete save data"))
				{
					QuestSession.DeleteSaveData();
				}
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.label("セーブするバージョン");
				RuntimeDebugModeGuiMixin.slabel("現在のセーブバージョン:" + QuestSessionDataSerialize.SAVE_VERSION);
				if (RuntimeDebugModeGuiMixin.button("1.0.5バージョン(5)にする"))
				{
					QuestSessionDataSerialize.SAVE_VERSION = 5;
				}
				if (RuntimeDebugModeGuiMixin.button("2.0.0バージョン(6)にする"))
				{
					QuestSessionDataSerialize.SAVE_VERSION = 6;
				}
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.toggle(ref QuestSession.ENCRYPT_QUEST_SESSION_DATA, "encrypt quest session data");
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243310
	{
		internal _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024locals_002414659;

		public _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243310(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024locals_002414659)
		{
			this._0024_0024locals_002414659 = _0024_0024locals_002414659;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append((object)(pageTop / _0024_0024locals_002414659._0024_0024act_0024t_0024312.pageLines)).Append("ページ").ToString());
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("前ページ"))
				{
					pageTop = Math.Max(0, pageTop - _0024_0024locals_002414659._0024_0024act_0024t_0024312.pageLines);
				}
				if (RuntimeDebugModeGuiMixin.button("次ページ"))
				{
					pageTop = Math.Min(_0024_0024locals_002414659._0024_0024act_0024t_0024312.quests.Length - 1, pageTop + _0024_0024locals_002414659._0024_0024act_0024t_0024312.pageLines);
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243311
	{
		internal _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024locals_002414660;

		internal DebugSubQuest _0024this_002414661;

		public _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243311(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024locals_002414660, DebugSubQuest _0024this_002414661)
		{
			this._0024_0024locals_002414660 = _0024_0024locals_002414660;
			this._0024this_002414661 = _0024this_002414661;
		}

		public void Invoke()
		{
			string text = new StringBuilder().Append((object)_0024_0024locals_002414660._0024q.Id).Append(" ").Append(_0024_0024locals_002414660._0024q.Progname)
				.Append(" ")
				.Append(_0024_0024locals_002414660._0024q.DisplayName)
				.ToString();
			if (_0024_0024locals_002414660._0024q.Deprecated)
			{
				text += " [無効]";
			}
			if (RuntimeDebugModeGuiMixin.button(text))
			{
				int i = 0;
				MStories[] all = MStories.All;
				for (int length = all.Length; i < length; i = checked(i + 1))
				{
					if (RuntimeServices.EqualityOperator(all[i].MQuestId, _0024_0024locals_002414660._0024q))
					{
						_0024this_002414661.playQuest(all[i], withServerId == 0);
						break;
					}
				}
			}
			if (RuntimeDebugModeGuiMixin.button("マスタ確認"))
			{
				_0024this_002414661.allQuestMasterSubMode(_0024_0024locals_002414660._0024q);
			}
		}
	}

	[Serializable]
	internal class _0024sortQuestArray_0024closure_00243308
	{
		internal _0024sortQuestArray_0024locals_002414286 _0024_0024locals_002414662;

		public _0024sortQuestArray_0024closure_00243308(_0024sortQuestArray_0024locals_002414286 _0024_0024locals_002414662)
		{
			this._0024_0024locals_002414662 = _0024_0024locals_002414662;
		}

		public int Invoke(MQuests q1, MQuests q2)
		{
			return checked(_0024_0024locals_002414662._0024dpn(q1) - _0024_0024locals_002414662._0024dpn(q2) + q1.Id - q2.Id);
		}
	}

	[Serializable]
	internal class _0024_0024createDatastoryMasterMode_0024closure_00243316_0024closure_00243317
	{
		internal DebugSubQuest _0024this_002414663;

		internal _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290 _0024_0024locals_002414664;

		public _0024_0024createDatastoryMasterMode_0024closure_00243316_0024closure_00243317(DebugSubQuest _0024this_002414663, _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290 _0024_0024locals_002414664)
		{
			this._0024this_002414663 = _0024this_002414663;
			this._0024_0024locals_002414664 = _0024_0024locals_002414664;
		}

		public void Invoke()
		{
			_0024this_002414663.storyMasterMode(_0024_0024locals_002414664._0024_0024act_0024t_0024318.story);
		}
	}

	[Serializable]
	internal class _0024displayQuest_0024closure_00243324
	{
		internal MNpcs[] _0024_00246931_002414665;

		internal int _0024_00246930_002414666;

		internal DebugSubQuest _0024this_002414667;

		internal _0024displayQuest_0024locals_002414287 _0024_0024locals_002414668;

		public _0024displayQuest_0024closure_00243324(MNpcs[] _0024_00246931_002414665, int _0024_00246930_002414666, DebugSubQuest _0024this_002414667, _0024displayQuest_0024locals_002414287 _0024_0024locals_002414668)
		{
			this._0024_00246931_002414665 = _0024_00246931_002414665;
			this._0024_00246930_002414666 = _0024_00246930_002414666;
			this._0024this_002414667 = _0024this_002414667;
			this._0024_0024locals_002414668 = _0024_0024locals_002414668;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.slabel("  ");
			if (RuntimeDebugModeGuiMixin.sbutton(new StringBuilder().Append(_0024_00246931_002414665[_0024_00246930_002414666]).ToString()))
			{
				_0024this_002414667.npcMode(_0024_00246931_002414665[_0024_00246930_002414666], 2, _0024_0024locals_002414668._0024backMethod);
			}
		}
	}

	[Serializable]
	internal class _0024displayQuest_0024closure_00243325
	{
		internal MStageMonsters[] _0024_00246935_002414669;

		internal int _0024_00246934_002414670;

		internal DebugSubQuest _0024this_002414671;

		internal _0024displayQuest_0024locals_002414287 _0024_0024locals_002414672;

		public _0024displayQuest_0024closure_00243325(MStageMonsters[] _0024_00246935_002414669, int _0024_00246934_002414670, DebugSubQuest _0024this_002414671, _0024displayQuest_0024locals_002414287 _0024_0024locals_002414672)
		{
			this._0024_00246935_002414669 = _0024_00246935_002414669;
			this._0024_00246934_002414670 = _0024_00246934_002414670;
			this._0024this_002414671 = _0024this_002414671;
			this._0024_0024locals_002414672 = _0024_0024locals_002414672;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.slabel("          ");
			if (RuntimeDebugModeGuiMixin.sbutton(new StringBuilder().Append(_0024_00246935_002414669[_0024_00246934_002414670]).ToString()))
			{
				_0024this_002414671.monsterMode(_0024_00246935_002414669[_0024_00246934_002414670], _0024_0024locals_002414672._0024backMethod);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatamonsterMode_0024closure_00243328_0024closure_00243329
	{
		internal _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291 _0024_0024locals_002414673;

		public _0024_0024createDatamonsterMode_0024closure_00243328_0024closure_00243329(_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291 _0024_0024locals_002414673)
		{
			this._0024_0024locals_002414673 = _0024_0024locals_002414673;
		}

		public bool Invoke(MItemGroupChilds item)
		{
			return RuntimeServices.EqualityOperator(item.MItemGroupId, _0024_0024locals_002414673._0024ig);
		}
	}

	[Serializable]
	internal class _0024_0024createDataareaMasterMode_0024closure_00243337_0024closure_00243338
	{
		internal _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292 _0024_0024locals_002414674;

		public _0024_0024createDataareaMasterMode_0024closure_00243337_0024closure_00243338(_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292 _0024_0024locals_002414674)
		{
			this._0024_0024locals_002414674 = _0024_0024locals_002414674;
		}

		public bool Invoke(MQuests q)
		{
			return RuntimeServices.EqualityOperator(q.MAreaId, _0024_0024locals_002414674._0024_0024act_0024t_0024336.area);
		}
	}

	[Serializable]
	internal class _0024_0024createDataquestMode_0024closure_00243342_0024closure_00243343
	{
		internal _0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293 _0024_0024locals_002414675;

		internal DebugSubQuest _0024this_002414676;

		public _0024_0024createDataquestMode_0024closure_00243342_0024closure_00243343(_0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293 _0024_0024locals_002414675, DebugSubQuest _0024this_002414676)
		{
			this._0024_0024locals_002414675 = _0024_0024locals_002414675;
			this._0024this_002414676 = _0024this_002414676;
		}

		public void Invoke()
		{
			_0024this_002414676.questMode(_0024_0024locals_002414675._0024_0024act_0024t_0024339.area, _0024_0024locals_002414675._0024_0024act_0024t_0024339.quest);
		}
	}

	[NonSerialized]
	protected static int currentSelectStory;

	[NonSerialized]
	protected static int withServerId;

	[NonSerialized]
	protected static MScenes lastPochittaMScenes;

	private Dictionary<string, ActionBase> _0024act_0024t_0024300;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024302;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024301;

	public bool actionDebugFlag;

	[NonSerialized]
	private static int pageTop;

	[NonSerialized]
	private static int sortMode;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IsbattleMissionInfoMode => currActionID("$default$") == ActionEnum.battleMissionInfoMode;

	public ActionClassbattleMissionInfoMode battleMissionInfoModeData => currAction("$default$") as ActionClassbattleMissionInfoMode;

	public bool Isv3ChallengeMaster => currActionID("$default$") == ActionEnum.v3ChallengeMaster;

	public ActionClassv3ChallengeMaster v3ChallengeMasterData => currAction("$default$") as ActionClassv3ChallengeMaster;

	public bool IsallQuestMasterMode => currActionID("$default$") == ActionEnum.allQuestMasterMode;

	public ActionClassallQuestMasterMode allQuestMasterModeData => currAction("$default$") as ActionClassallQuestMasterMode;

	public bool IsallQuestMasterSubMode => currActionID("$default$") == ActionEnum.allQuestMasterSubMode;

	public ActionClassallQuestMasterSubMode allQuestMasterSubModeData => currAction("$default$") as ActionClassallQuestMasterSubMode;

	public bool IsstoryMasterMode => currActionID("$default$") == ActionEnum.storyMasterMode;

	public ActionClassstoryMasterMode storyMasterModeData => currAction("$default$") as ActionClassstoryMasterMode;

	public bool IsclearSuccMode => currActionID("$default$") == ActionEnum.clearSuccMode;

	public ActionClassclearSuccMode clearSuccModeData => currAction("$default$") as ActionClassclearSuccMode;

	public bool IsnpcMode => currActionID("$default$") == ActionEnum.npcMode;

	public ActionClassnpcMode npcModeData => currAction("$default$") as ActionClassnpcMode;

	public bool IsmonsterMode => currActionID("$default$") == ActionEnum.monsterMode;

	public ActionClassmonsterMode monsterModeData => currAction("$default$") as ActionClassmonsterMode;

	public bool IsrespMonsterMode => currActionID("$default$") == ActionEnum.respMonsterMode;

	public ActionClassrespMonsterMode respMonsterModeData => currAction("$default$") as ActionClassrespMonsterMode;

	public bool IsallAreaMasterMode => currActionID("$default$") == ActionEnum.allAreaMasterMode;

	public ActionClassallAreaMasterMode allAreaMasterModeData => currAction("$default$") as ActionClassallAreaMasterMode;

	public bool IsareaMasterMode => currActionID("$default$") == ActionEnum.areaMasterMode;

	public ActionClassareaMasterMode areaMasterModeData => currAction("$default$") as ActionClassareaMasterMode;

	public bool IsquestMode => currActionID("$default$") == ActionEnum.questMode;

	public ActionClassquestMode questModeData => currAction("$default$") as ActionClassquestMode;

	public bool IssceneMasterMode => currActionID("$default$") == ActionEnum.sceneMasterMode;

	public ActionClasssceneMasterMode sceneMasterModeData => currAction("$default$") as ActionClasssceneMasterMode;

	public bool IssessionDropMode => currActionID("$default$") == ActionEnum.sessionDropMode;

	public ActionClasssessionDropMode sessionDropModeData => currAction("$default$") as ActionClasssessionDropMode;

	public bool IskusamushiMode => currActionID("$default$") == ActionEnum.kusamushiMode;

	public ActionClasskusamushiMode kusamushiModeData => currAction("$default$") as ActionClasskusamushiMode;

	public bool IsmonsterMapMode => currActionID("$default$") == ActionEnum.monsterMapMode;

	public ActionClassmonsterMapMode monsterMapModeData => currAction("$default$") as ActionClassmonsterMapMode;

	public bool IsbattleInfoMode => currActionID("$default$") == ActionEnum.battleInfoMode;

	public ActionClassbattleInfoMode battleInfoModeData => currAction("$default$") as ActionClassbattleInfoMode;

	public bool IsopenedQuestListMode => currActionID("$default$") == ActionEnum.openedQuestListMode;

	public ActionClassopenedQuestListMode openedQuestListModeData => currAction("$default$") as ActionClassopenedQuestListMode;

	public bool IsopenedWeekEventsMode => currActionID("$default$") == ActionEnum.openedWeekEventsMode;

	public ActionClassopenedWeekEventsMode openedWeekEventsModeData => currAction("$default$") as ActionClassopenedWeekEventsMode;

	public DebugSubQuest()
	{
		_0024act_0024t_0024300 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024302 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override void Init()
	{
		mainMode();
	}

	public override void Update()
	{
		actUpdate();
	}

	public override void LateUpdate()
	{
		actLateUpdate();
	}

	public override void FixedUpdate()
	{
		actFixedUpdate();
	}

	public override void OnGUI()
	{
		actOnGUI();
	}

	public override bool AutoReturn()
	{
		return false;
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024300.ContainsKey(grp)) ? null : _0024act_0024t_0024300[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024302.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024302[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024300.ContainsKey(grp)) ? 0f : _0024act_0024t_0024300[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024300.ContainsKey(grp)) ? 0f : _0024act_0024t_0024300[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024300.ContainsKey(grp)) ? 0f : _0024act_0024t_0024300[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024302.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024292) && _0024act_0024t_0024300.ContainsKey(act._0024act_0024t_0024292) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024300[act._0024act_0024t_0024292]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.openedWeekEventsMode <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_0024292))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$292)");
			}
			_0024act_0024t_0024300[act._0024act_0024t_0024292] = act;
			_0024act_0024t_0024302[act._0024act_0024t_0024292] = act._0024act_0024t_0024291;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024301) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024292);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024292)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024292)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024294 != null)
		{
			actionBase._0024act_0024t_0024294(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024293 != null)
			{
				act._0024act_0024t_0024293(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024299 != null)
			{
				act._0024act_0024t_0024303 = act._0024act_0024t_0024299(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_0024300.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024301 = 0;
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
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024295 != null)
			{
				actionBase._0024act_0024t_0024295(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024303 != null && !actionBase._0024act_0024t_0024303.MoveNext())
			{
				actionBase._0024act_0024t_0024303 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024300.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024301 = 0;
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
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024296 != null)
			{
				actionBase._0024act_0024t_0024296(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024301 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024300.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024300[array2[i]];
				if (actionBase._0024act_0024t_0024297 != null)
				{
					actionBase._0024act_0024t_0024297(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024300.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024292 + " - " + value._0024act_0024t_0024291 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024301 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024300.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024300[array2[i]];
			if (actionBase._0024act_0024t_0024298 != null)
			{
				actionBase._0024act_0024t_0024298(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubQuest" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.battleMissionInfoMode => createDatabattleMissionInfoMode(), 
			ActionEnum.v3ChallengeMaster => createDatav3ChallengeMaster(), 
			ActionEnum.allQuestMasterMode => createDataallQuestMasterMode(), 
			ActionEnum.allQuestMasterSubMode => createDataallQuestMasterSubMode(), 
			ActionEnum.storyMasterMode => createDatastoryMasterMode(), 
			ActionEnum.clearSuccMode => createDataclearSuccMode(), 
			ActionEnum.npcMode => createDatanpcMode(), 
			ActionEnum.monsterMode => createDatamonsterMode(), 
			ActionEnum.respMonsterMode => createDatarespMonsterMode(), 
			ActionEnum.allAreaMasterMode => createDataallAreaMasterMode(), 
			ActionEnum.areaMasterMode => createDataareaMasterMode(), 
			ActionEnum.questMode => createDataquestMode(), 
			ActionEnum.sceneMasterMode => createDatasceneMasterMode(), 
			ActionEnum.sessionDropMode => createDatasessionDropMode(), 
			ActionEnum.kusamushiMode => createDatakusamushiMode(), 
			ActionEnum.monsterMapMode => createDatamonsterMapMode(), 
			ActionEnum.battleInfoMode => createDatabattleInfoMode(), 
			ActionEnum.openedQuestListMode => createDataopenedQuestListMode(), 
			ActionEnum.openedWeekEventsMode => createDataopenedWeekEventsMode(), 
			_ => null, 
		};
	}

	public ActionClassmainMode mainMode()
	{
		ActionClassmainMode actionClassmainMode = createmainMode();
		changeAction(actionClassmainMode);
		return actionClassmainMode;
	}

	public ActionClassmainMode createDatamainMode()
	{
		ActionClassmainMode actionClassmainMode = new ActionClassmainMode();
		actionClassmainMode._0024act_0024t_0024291 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024292 = "$default$";
		bool _0024_002414265_0024 = default(bool);
		actionClassmainMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable209_002425_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002418.Adapt(new _0024createDatamainMode_0024closure_00243037(_0024_002414265_0024, this).Invoke);
		actionClassmainMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable209_002425_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002418.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				KillMe();
			}
		});
		return actionClassmainMode;
	}

	public ActionClassmainMode createmainMode()
	{
		return createDatamainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024300.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024300["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClassbattleMissionInfoMode battleMissionInfoMode()
	{
		ActionClassbattleMissionInfoMode actionClassbattleMissionInfoMode = createbattleMissionInfoMode();
		changeAction(actionClassbattleMissionInfoMode);
		return actionClassbattleMissionInfoMode;
	}

	public ActionClassbattleMissionInfoMode createDatabattleMissionInfoMode()
	{
		ActionClassbattleMissionInfoMode actionClassbattleMissionInfoMode = new ActionClassbattleMissionInfoMode();
		actionClassbattleMissionInfoMode._0024act_0024t_0024291 = ActionEnum.battleMissionInfoMode;
		actionClassbattleMissionInfoMode._0024act_0024t_0024292 = "$default$";
		actionClassbattleMissionInfoMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable210_0024251_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002419.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("バトルミッション情報");
			RuntimeDebugModeGuiMixin.slabel("状態異常罹患数: " + QuestEventHandler.PlayerAbnormalStateCount);
			RuntimeDebugModeGuiMixin.slabel("ダメージ数: " + QuestEventHandler.PlayerDamageCount);
			RuntimeDebugModeGuiMixin.slabel("プレイ時間(s): " + QuestEventHandler.PlayerCurrentPlayTime);
			RuntimeDebugModeGuiMixin.slabel("攻撃力: " + QuestEventHandler.PlayerTotalAttack);
			RuntimeDebugModeGuiMixin.slabel("HP: " + QuestEventHandler.PlayerTotalHP);
			RuntimeDebugModeGuiMixin.slabel("最終HP: " + QuestEventHandler.PlayerLastHP);
		});
		actionClassbattleMissionInfoMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable210_0024251_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002419.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassbattleMissionInfoMode;
	}

	public ActionClassbattleMissionInfoMode createbattleMissionInfoMode()
	{
		return createDatabattleMissionInfoMode();
	}

	public ActionClassv3ChallengeMaster v3ChallengeMaster()
	{
		ActionClassv3ChallengeMaster actionClassv3ChallengeMaster = createv3ChallengeMaster();
		changeAction(actionClassv3ChallengeMaster);
		return actionClassv3ChallengeMaster;
	}

	public ActionClassv3ChallengeMaster createDatav3ChallengeMaster()
	{
		ActionClassv3ChallengeMaster actionClassv3ChallengeMaster = new ActionClassv3ChallengeMaster();
		actionClassv3ChallengeMaster._0024act_0024t_0024291 = ActionEnum.v3ChallengeMaster;
		actionClassv3ChallengeMaster._0024act_0024t_0024292 = "$default$";
		actionClassv3ChallengeMaster._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420.Adapt(delegate(ActionClassv3ChallengeMaster _0024act_0024t_0024309)
		{
			_0024act_0024t_0024309.schedules = MChallengeQuestSchedules.GetOpenSchedules();
			_0024act_0024t_0024309.quests = MChallengeQuestScheduleDetails.GetOpenQuests();
		});
		actionClassv3ChallengeMaster._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420.Adapt(checked(delegate(ActionClassv3ChallengeMaster _0024act_0024t_0024309)
		{
			RuntimeDebugModeGuiMixin.label("challenge schedules:");
			int i = 0;
			MChallengeQuestSchedules[] schedules = _0024act_0024t_0024309.schedules;
			for (int length = schedules.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("id=").Append((object)schedules[i].Id).Append(" ").Append(schedules[i].BeginDate)
					.Append(" ~ ")
					.Append(schedules[i].EndDate)
					.ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("quests:");
			int j = 0;
			MQuests[] quests = _0024act_0024t_0024309.quests;
			for (int length2 = quests.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(quests[j].ToString());
			}
		}));
		actionClassv3ChallengeMaster._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassv3ChallengeMaster;
	}

	public ActionClassv3ChallengeMaster createv3ChallengeMaster()
	{
		return createDatav3ChallengeMaster();
	}

	public ActionClassallQuestMasterMode allQuestMasterMode()
	{
		ActionClassallQuestMasterMode actionClassallQuestMasterMode = createallQuestMasterMode();
		changeAction(actionClassallQuestMasterMode);
		return actionClassallQuestMasterMode;
	}

	public ActionClassallQuestMasterMode createDataallQuestMasterMode()
	{
		ActionClassallQuestMasterMode actionClassallQuestMasterMode = new ActionClassallQuestMasterMode();
		actionClassallQuestMasterMode._0024act_0024t_0024291 = ActionEnum.allQuestMasterMode;
		actionClassallQuestMasterMode._0024act_0024t_0024292 = "$default$";
		checked
		{
			actionClassallQuestMasterMode._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable212_0024285_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002421.Adapt(delegate(ActionClassallQuestMasterMode _0024act_0024t_0024312)
			{
				_0024act_0024t_0024312.quests = ArrayMap.AllMQuests();
				sortQuestArray(_0024act_0024t_0024312.quests, sortMode);
				_0024act_0024t_0024312.pageLines = 50;
				pageTop = Mathf.Clamp(pageTop, 0, _0024act_0024t_0024312.quests.Length);
				pageTop = unchecked(pageTop / _0024act_0024t_0024312.pageLines) * _0024act_0024t_0024312.pageLines;
			});
			actionClassallQuestMasterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable212_0024285_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002421.Adapt(delegate(ActionClassallQuestMasterMode _0024act_0024t_0024312)
			{
				_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024 = new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289();
				_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312 = _0024act_0024t_0024312;
				RuntimeDebugModeGuiMixin.label("クエスト一覧");
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.slabel("クエスト通信選択");
				withServerId = RuntimeDebugModeGuiMixin.grid(withServerId, new string[2] { "あり", "なし" }, 2);
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.slabel("並び順:");
				int num = RuntimeDebugModeGuiMixin.grid(sortMode, new string[3] { "識別名", "ID", "有効/無効" }, 3);
				if (num != sortMode)
				{
					sortMode = num;
					sortQuestArray(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests, sortMode);
				}
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243310(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024).Invoke));
				RuntimeDebugModeGuiMixin.space(10);
				int num2 = 0;
				int pageLines = _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.pageLines;
				if (pageLines < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < pageLines)
				{
					int num3 = num2;
					num2 = unchecked(num2 + 1);
					int num4 = pageTop + num3;
					if (num4 < _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests.Length)
					{
						MQuests[] quests = _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests;
						_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024q = quests[RuntimeServices.NormalizeArrayIndex(quests, num4)];
						RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243311(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024, this).Invoke));
					}
				}
			});
			actionClassallQuestMasterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable212_0024285_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002421.Adapt(delegate
			{
				if (RuntimeDebugModeGuiMixin.InputBack)
				{
					mainMode();
				}
			});
			return actionClassallQuestMasterMode;
		}
	}

	public ActionClassallQuestMasterMode createallQuestMasterMode()
	{
		return createDataallQuestMasterMode();
	}

	private void sortQuestArray(MQuests[] quests, int mode)
	{
		_0024sortQuestArray_0024locals_002414286 _0024sortQuestArray_0024locals_0024 = new _0024sortQuestArray_0024locals_002414286();
		__DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ _DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ = null;
		switch (mode)
		{
		case 0:
			_DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ = (MQuests q1, MQuests q2) => string.Compare(q1.Progname, q2.Progname);
			break;
		case 1:
			_DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ = (MQuests q1, MQuests q2) => checked(q1.Id - q2.Id);
			break;
		default:
			_0024sortQuestArray_0024locals_0024._0024dpn = (MQuests q) => q.Deprecated ? 10000 : 0;
			_DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ = new _0024sortQuestArray_0024closure_00243308(_0024sortQuestArray_0024locals_0024).Invoke;
			break;
		}
		Array.Sort(quests, _0024adaptor_0024__DebugSubQuest_sortQuestArray_0024callable18_0024342_16___0024Comparison_002422.Adapt(_DebugSubQuest_sortQuestArray_0024callable18_0024342_16__));
	}

	public ActionClassallQuestMasterSubMode allQuestMasterSubMode(MQuests q)
	{
		ActionClassallQuestMasterSubMode actionClassallQuestMasterSubMode = createallQuestMasterSubMode(q);
		changeAction(actionClassallQuestMasterSubMode);
		return actionClassallQuestMasterSubMode;
	}

	public ActionClassallQuestMasterSubMode createDataallQuestMasterSubMode()
	{
		ActionClassallQuestMasterSubMode actionClassallQuestMasterSubMode = new ActionClassallQuestMasterSubMode();
		actionClassallQuestMasterSubMode._0024act_0024t_0024291 = ActionEnum.allQuestMasterSubMode;
		actionClassallQuestMasterSubMode._0024act_0024t_0024292 = "$default$";
		actionClassallQuestMasterSubMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable214_0024352_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002423.Adapt(delegate(ActionClassallQuestMasterSubMode _0024act_0024t_0024315)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024315.q).ToString());
			string lhs = "このクエストをプレイ ";
			lhs = ((withServerId != 0) ? (lhs + "(通信ナシ無し)") : (lhs + "(通信あり)"));
			if (RuntimeDebugModeGuiMixin.button(lhs))
			{
				playQuest(_0024act_0024t_0024315.q, withServerId == 0);
			}
			RuntimeDebugModeGuiMixin.space(10);
			displayQuest(_0024act_0024t_0024315.q, null, _0024adaptor_0024__DebugSubModeQuest_0024callable213_0024364_36___0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___002439.Adapt(() => allQuestMasterMode()));
		});
		actionClassallQuestMasterSubMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable214_0024352_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002423.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				allQuestMasterMode();
			}
		});
		return actionClassallQuestMasterSubMode;
	}

	public ActionClassallQuestMasterSubMode createallQuestMasterSubMode(MQuests q)
	{
		ActionClassallQuestMasterSubMode actionClassallQuestMasterSubMode = createDataallQuestMasterSubMode();
		actionClassallQuestMasterSubMode.q = q;
		return actionClassallQuestMasterSubMode;
	}

	public ActionClassstoryMasterMode storyMasterMode(MStories story)
	{
		ActionClassstoryMasterMode actionClassstoryMasterMode = createstoryMasterMode(story);
		changeAction(actionClassstoryMasterMode);
		return actionClassstoryMasterMode;
	}

	public ActionClassstoryMasterMode createDatastoryMasterMode()
	{
		ActionClassstoryMasterMode actionClassstoryMasterMode = new ActionClassstoryMasterMode();
		actionClassstoryMasterMode._0024act_0024t_0024291 = ActionEnum.storyMasterMode;
		actionClassstoryMasterMode._0024act_0024t_0024292 = "$default$";
		actionClassstoryMasterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable215_0024367_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002424.Adapt(delegate(ActionClassstoryMasterMode _0024act_0024t_0024318)
		{
			_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290 _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024 = new _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290();
			_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318 = _0024act_0024t_0024318;
			if (_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story == null)
			{
				mainMode();
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("現ストーリーマスター");
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Group: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.GroupId).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Prev: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.PrevGroupId).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsTutorial: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.IsTutorial).ToString());
				displayQuest(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.MQuestId, _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story, new _0024_0024createDatastoryMasterMode_0024closure_00243316_0024closure_00243317(this, _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024).Invoke);
			}
		});
		actionClassstoryMasterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable215_0024367_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002424.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassstoryMasterMode;
	}

	public ActionClassstoryMasterMode createstoryMasterMode(MStories story)
	{
		ActionClassstoryMasterMode actionClassstoryMasterMode = createDatastoryMasterMode();
		actionClassstoryMasterMode.story = story;
		return actionClassstoryMasterMode;
	}

	public ActionClassclearSuccMode clearSuccMode(MQuests quest, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassclearSuccMode actionClassclearSuccMode = createclearSuccMode(quest, backMethod);
		changeAction(actionClassclearSuccMode);
		return actionClassclearSuccMode;
	}

	public ActionClassclearSuccMode createDataclearSuccMode()
	{
		ActionClassclearSuccMode actionClassclearSuccMode = new ActionClassclearSuccMode();
		actionClassclearSuccMode._0024act_0024t_0024291 = ActionEnum.clearSuccMode;
		actionClassclearSuccMode._0024act_0024t_0024292 = "$default$";
		actionClassclearSuccMode._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable216_0024384_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002425.Adapt(delegate(ActionClassclearSuccMode _0024act_0024t_0024321)
		{
			_0024act_0024t_0024321.story = null;
			int i = 0;
			MStories[] all = MStories.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(all[i].MQuestId, _0024act_0024t_0024321.quest))
				{
					_0024act_0024t_0024321.story = all[i];
					break;
				}
			}
			if (_0024act_0024t_0024321.story != null)
			{
				QuestSession.StartSessionDebug(RuntimeDebugMode.Instance, _0024act_0024t_0024321.story.Id, noSceneLoad: true);
			}
		});
		actionClassclearSuccMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable216_0024384_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002425.Adapt(delegate(ActionClassclearSuccMode _0024act_0024t_0024321)
		{
			if (_0024act_0024t_0024321.story == null && _0024act_0024t_0024321.backMethod != null)
			{
				_0024act_0024t_0024321.backMethod();
			}
			RuntimeDebugModeGuiMixin.label("通信中");
			if (QuestSession.IsInPlay)
			{
				QuestSession.GotAllMonsterDropAll();
				QuestSession.Succeeded();
			}
			else if (QuestSession.CompletelyClosed && RuntimeDebugModeGuiMixin.button("戻る") && _0024act_0024t_0024321.backMethod != null)
			{
				_0024act_0024t_0024321.backMethod();
			}
		});
		actionClassclearSuccMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable216_0024384_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002425.Adapt(delegate(ActionClassclearSuccMode _0024act_0024t_0024321)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				_0024act_0024t_0024321.backMethod();
			}
		});
		return actionClassclearSuccMode;
	}

	public ActionClassclearSuccMode createclearSuccMode(MQuests quest, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassclearSuccMode actionClassclearSuccMode = createDataclearSuccMode();
		actionClassclearSuccMode.quest = quest;
		actionClassclearSuccMode.backMethod = backMethod;
		return actionClassclearSuccMode;
	}

	private void displayQuest(MQuests quest, MStories story, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		_0024displayQuest_0024locals_002414287 _0024displayQuest_0024locals_0024 = new _0024displayQuest_0024locals_002414287();
		_0024displayQuest_0024locals_0024._0024backMethod = backMethod;
		if (quest == null)
		{
			return;
		}
		if (story != null)
		{
			lastPochittaQuestStartButton();
		}
		if (RuntimeDebugModeGuiMixin.button("このクエストを全ドロップ取得クリアする"))
		{
			clearSuccMode(quest, _0024displayQuest_0024locals_0024._0024backMethod);
		}
		string text = ((!quest.AutoRunOn) ? "auto run ON に書き換え" : "auto run OFF に書き換え");
		if (RuntimeDebugModeGuiMixin.button(text))
		{
			quest.setField("AutoRunOn", !quest.AutoRunOn);
		}
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("MQuest: ").Append(quest).Append(" - Stage:").Append(quest.MStageId)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   DEPRECATED: ").Append(quest.Deprecated).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   NeedTicket: ").Append(quest.NeedTicket).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   start scene: ").Append(quest.StartSceneId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   NutRateOfMonsterCandy: ").Append((object)quest.NutRateOfMonsterCandy).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   StageCandyNum: ").Append((object)quest.StageCandyNum).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   clear1: ").Append(quest.Clear_1).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   clear2: ").Append(quest.Clear_2).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   clear3: ").Append(quest.Clear_3).ToString());
		if (quest.LimitTime > 0)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   LimitTime:  ").Append((object)quest.LimitTime).Append(" sec").ToString());
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel("   LimitTime:  no limit");
		}
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   HideFlag: ").Append(quest.HideFlag).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   QuestType: ").Append(quest.QuestType).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   Date: ").Append(quest.BeginDate).Append(" - ").Append(quest.EndDate)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ClearCutScene: ").Append(quest.ClearCutScene).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   MSceneWhenClear: ").Append(quest.MSceneWhenClear).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   MScenePlayerPosition: ").Append(quest.MScenePlayerPosition).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   StageCandyNum: ").Append((object)quest.StageCandyNum).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   NutRateOfMonsterCandy: ").Append((object)quest.NutRateOfMonsterCandy).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   CandyDropNum: ").Append((object)quest.CandyDropNum).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   NutDropNum: ").Append((object)quest.NutDropNum).ToString());
		MScenes startSceneId = quest.StartSceneId;
		if (quest == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.slabel("ストーリー中のシーンリスト:");
		if (story != null)
		{
			RuntimeDebugModeGuiMixin.slabel("(MScenesボタンを押すと詳細)");
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel("(MScenesボタンを押すとそのMSceneを通信無し起動)");
		}
		MScenes[] array = startSceneId.collectAllLinkedScenes();
		checked
		{
			Array.Sort(array, (MScenes a, MScenes b) => a.Id - b.Id);
			int i = 0;
			MScenes[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				string value = ((!RuntimeServices.EqualityOperator(QuestSession.CurrentScene, array2[i])) ? string.Empty : "【現在】");
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(array2[i]).Append(value).ToString()))
				{
					if (story != null)
					{
						sceneMasterMode(array2[i], story);
					}
					else
					{
						jumpToMScene(array2[i]);
					}
				}
				int j = 0;
				MNpcs[] allNpcs = array2[i].AllNpcs;
				for (int length2 = allNpcs.Length; j < length2; j++)
				{
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024displayQuest_0024closure_00243324(allNpcs, j, this, _0024displayQuest_0024locals_0024).Invoke));
				}
				int k = 0;
				MStageBattles[] allStageBattles = array2[i].AllStageBattles;
				for (int length3 = allStageBattles.Length; k < length3; k++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(allStageBattles[k]).ToString());
					int l = 0;
					MStageMonsters[] allStageMonsters = allStageBattles[k].AllStageMonsters;
					for (int length4 = allStageMonsters.Length; l < length4; l++)
					{
						RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024displayQuest_0024closure_00243325(allStageMonsters, l, this, _0024displayQuest_0024locals_0024).Invoke));
					}
				}
			}
			RuntimeDebugModeGuiMixin.space(20);
			UserData current = UserData.Current;
			if (current != null)
			{
				RuntimeDebugModeGuiMixin.label("現在のフラグ状況");
				bool flag = GameLevelManager.CheckCondition(quest.AllConditions, notFlag: false);
				bool flag2 = GameLevelManager.CheckCondition(quest.AllNotConditions, notFlag: true);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Conditions:").Append(flag).Append(" NotConditions:").Append(flag2)
					.ToString());
				RuntimeDebugModeGuiMixin.label("Conditions 詳細:");
				int m = 0;
				MFlags[] allConditions = quest.AllConditions;
				for (int length5 = allConditions.Length; m < length5; m++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allConditions[m].Progname).Append(" : ").Append(current.hasFlag(allConditions[m].Progname))
						.ToString());
				}
				RuntimeDebugModeGuiMixin.label("NotConditions 詳細:");
				int n = 0;
				MFlags[] allNotConditions = quest.AllNotConditions;
				for (int length6 = allNotConditions.Length; n < length6; n++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allNotConditions[n].Progname).Append(" : ").Append(current.hasFlag(allNotConditions[n].Progname))
						.ToString());
				}
			}
		}
	}

	private void playQuest(MQuests q, bool communication)
	{
		int i = 0;
		MStories[] all = MStories.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(all[i].MQuestId, q))
			{
				playQuest(all[i], communication);
				break;
			}
		}
	}

	private void playQuest(MStories story, bool communication)
	{
		RuntimeDebugMode instance = RuntimeDebugMode.Instance;
		int id = story.Id;
		if (story.MQuestId != null)
		{
			story = MStories.Get(id);
			QuestManager.Instance.CurQuest = story.MQuestId;
		}
		if (communication)
		{
			QuestSession.StartSessionDebug(instance, id, noSceneLoad: false);
		}
		else
		{
			QuestSession.StartSessionDebugWithoutServer(instance, id, noSceneLoad: false);
		}
		ExitDebugMode();
	}

	private void jumpToMScene(MScenes s)
	{
		if (s != null)
		{
			QuestSessionParameters questSessionParameters = new QuestSessionParameters();
			questSessionParameters.debugMScenes = s;
			QuestSession.StartSessionDebug(RuntimeDebugMode.Instance, questSessionParameters);
			QuestManager.Instance.CurQuest = s.MQuestId;
			PlayerPrefs.SetInt("Merlin-DebugMode-LastPochittaMScenes", s.Id);
			PlayerPrefs.Save();
			ExitDebugMode();
		}
	}

	public ActionClassnpcMode npcMode(MNpcs npc, int nspc, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassnpcMode actionClassnpcMode = createnpcMode(npc, nspc, backMethod);
		changeAction(actionClassnpcMode);
		return actionClassnpcMode;
	}

	public ActionClassnpcMode createDatanpcMode()
	{
		ActionClassnpcMode actionClassnpcMode = new ActionClassnpcMode();
		actionClassnpcMode._0024act_0024t_0024291 = ActionEnum.npcMode;
		actionClassnpcMode._0024act_0024t_0024292 = "$default$";
		actionClassnpcMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable218_0024537_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002426.Adapt(checked(delegate(ActionClassnpcMode _0024act_0024t_0024324)
		{
			string value = " " * _0024act_0024t_0024324.nspc;
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(value).Append(_0024act_0024t_0024324.npc).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  DisplayName:").ToString() + _0024act_0024t_0024324.npc.DisplayName);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  DisplayName_En:").ToString() + _0024act_0024t_0024324.npc.DisplayName_En);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  PositionObject:").ToString() + _0024act_0024t_0024324.npc.PositionObject);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  Prefab:").ToString() + _0024act_0024t_0024324.npc.Prefab);
			dispConditions(_0024act_0024t_0024324.npc.AllConditions, _0024act_0024t_0024324.nspc + 2, "Conditions");
			dispConditions(_0024act_0024t_0024324.npc.AllConditions, _0024act_0024t_0024324.nspc + 2, "NotConditions");
			int i = 0;
			MNpcTalks[] allNpcTalks = _0024act_0024t_0024324.npc.AllNpcTalks;
			for (int length = allNpcTalks.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("    ").Append(allNpcTalks[i])
					.ToString());
			}
		}));
		actionClassnpcMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable218_0024537_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002426.Adapt(delegate(ActionClassnpcMode _0024act_0024t_0024324)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				_0024act_0024t_0024324.backMethod();
			}
		});
		return actionClassnpcMode;
	}

	public ActionClassnpcMode createnpcMode(MNpcs npc, int nspc, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassnpcMode actionClassnpcMode = createDatanpcMode();
		actionClassnpcMode.npc = npc;
		actionClassnpcMode.nspc = nspc;
		actionClassnpcMode.backMethod = backMethod;
		return actionClassnpcMode;
	}

	public ActionClassmonsterMode monsterMode(MStageMonsters m, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassmonsterMode actionClassmonsterMode = createmonsterMode(m, backMethod);
		changeAction(actionClassmonsterMode);
		return actionClassmonsterMode;
	}

	public ActionClassmonsterMode createDatamonsterMode()
	{
		ActionClassmonsterMode actionClassmonsterMode = new ActionClassmonsterMode();
		actionClassmonsterMode._0024act_0024t_0024291 = ActionEnum.monsterMode;
		actionClassmonsterMode._0024act_0024t_0024292 = "$default$";
		actionClassmonsterMode._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable219_0024553_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002427.Adapt(delegate(ActionClassmonsterMode _0024act_0024t_0024327)
		{
			_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291 _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024 = new _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291();
			_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024._0024ig = _0024act_0024t_0024327.m.MItemGroupId;
			if (_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024._0024ig != null)
			{
				_0024act_0024t_0024327.drops = ArrayMap.FilterMItemGroupChilds(new _0024_0024createDatamonsterMode_0024closure_00243328_0024closure_00243329(_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024).Invoke);
			}
			else
			{
				_0024act_0024t_0024327.drops = new MItemGroupChilds[0];
			}
		});
		actionClassmonsterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable219_0024553_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002427.Adapt(delegate(ActionClassmonsterMode _0024act_0024t_0024327)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024327.m).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MStageId: ").Append((object)_0024act_0024t_0024327.m.MStageId).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MMonsterId: ").Append(_0024act_0024t_0024327.m.MMonsterId).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  CorrespondentNpc: ").Append(_0024act_0024t_0024327.m.CorrespondentNpc).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsBoss: ").Append((object)_0024act_0024t_0024327.m.IsBoss).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LevelMin: ").Append((object)_0024act_0024t_0024327.m.LevelMin).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LevelMax: ").Append((object)_0024act_0024t_0024327.m.LevelMax).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Quantity: ").Append((object)_0024act_0024t_0024327.m.Quantity).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Rate: ").Append((object)_0024act_0024t_0024327.m.Rate).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  PopStep: ").Append((object)_0024act_0024t_0024327.m.PopStep).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  DummyDropLevel: ").Append((object)_0024act_0024t_0024327.m.DummyDropLevel).Append(" DummyCoin: ").Append((object)_0024act_0024t_0024327.m.DummyCoin)
				.ToString());
			RuntimeDebugModeGuiMixin.label("DROPS:");
			int i = 0;
			MItemGroupChilds[] drops = _0024act_0024t_0024327.drops;
			for (int length = drops.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.slabel("  " + drops[i]);
			}
		});
		actionClassmonsterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable219_0024553_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002427.Adapt(delegate(ActionClassmonsterMode _0024act_0024t_0024327)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				_0024act_0024t_0024327.backMethod();
			}
		});
		return actionClassmonsterMode;
	}

	public ActionClassmonsterMode createmonsterMode(MStageMonsters m, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassmonsterMode actionClassmonsterMode = createDatamonsterMode();
		actionClassmonsterMode.m = m;
		actionClassmonsterMode.backMethod = backMethod;
		return actionClassmonsterMode;
	}

	public ActionClassrespMonsterMode respMonsterMode(RespMonster m, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassrespMonsterMode actionClassrespMonsterMode = createrespMonsterMode(m, backMethod);
		changeAction(actionClassrespMonsterMode);
		return actionClassrespMonsterMode;
	}

	public ActionClassrespMonsterMode createDatarespMonsterMode()
	{
		ActionClassrespMonsterMode actionClassrespMonsterMode = new ActionClassrespMonsterMode();
		actionClassrespMonsterMode._0024act_0024t_0024291 = ActionEnum.respMonsterMode;
		actionClassrespMonsterMode._0024act_0024t_0024292 = "$default$";
		actionClassrespMonsterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable220_0024586_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002428.Adapt(delegate(ActionClassrespMonsterMode _0024act_0024t_0024330)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024330.m).ToString());
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("MST:").Append(_0024act_0024t_0024330.m.Master).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Attack:").Append((object)_0024act_0024t_0024330.m.Attack).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Hp:").Append((object)_0024act_0024t_0024330.m.Hp).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Critical:").Append((object)_0024act_0024t_0024330.m.Critical).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("BreakPow:").Append((object)_0024act_0024t_0024330.m.BreakPow).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Resist:").Append((object)_0024act_0024t_0024330.m.Resist).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Defense:").Append((object)_0024act_0024t_0024330.m.Defense).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Exp:").Append((object)_0024act_0024t_0024330.m.Exp).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Coin:").Append((object)_0024act_0024t_0024330.m.Coin).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsKill:").Append(_0024act_0024t_0024330.m.IsKill).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Level:").Append((object)_0024act_0024t_0024330.m.Level).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Element:").Append((object)_0024act_0024t_0024330.m.Element).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Race:").Append((object)_0024act_0024t_0024330.m.Race).ToString());
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("DROPS:");
			int i = 0;
			RespSimpleReward[] rewards = _0024act_0024t_0024330.m.Rewards;
			for (int length = rewards.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.slabel("   " + rewards[i]);
			}
		});
		actionClassrespMonsterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable220_0024586_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002428.Adapt(delegate(ActionClassrespMonsterMode _0024act_0024t_0024330)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				_0024act_0024t_0024330.backMethod();
			}
		});
		return actionClassrespMonsterMode;
	}

	public ActionClassrespMonsterMode createrespMonsterMode(RespMonster m, __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ backMethod)
	{
		ActionClassrespMonsterMode actionClassrespMonsterMode = createDatarespMonsterMode();
		actionClassrespMonsterMode.m = m;
		actionClassrespMonsterMode.backMethod = backMethod;
		return actionClassrespMonsterMode;
	}

	public ActionClassallAreaMasterMode allAreaMasterMode()
	{
		ActionClassallAreaMasterMode actionClassallAreaMasterMode = createallAreaMasterMode();
		changeAction(actionClassallAreaMasterMode);
		return actionClassallAreaMasterMode;
	}

	public ActionClassallAreaMasterMode createDataallAreaMasterMode()
	{
		ActionClassallAreaMasterMode actionClassallAreaMasterMode = new ActionClassallAreaMasterMode();
		actionClassallAreaMasterMode._0024act_0024t_0024291 = ActionEnum.allAreaMasterMode;
		actionClassallAreaMasterMode._0024act_0024t_0024292 = "$default$";
		actionClassallAreaMasterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable222_0024614_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002429.Adapt(delegate(ActionClassallAreaMasterMode _0024act_0024t_0024333)
		{
			RuntimeDebugModeGuiMixin.label("エリア");
			lastPochittaQuestStartButton();
			MAreas[] array = ArrayMap.AllMAreas();
			string[] texts = (string[])RuntimeServices.AddArrays(typeof(string), new string[1] { "無効" }, ArrayMap.AllMAreasToStr((MAreas am) => am.Id + ":" + am.DisplayName));
			int num = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024333.selArea, texts, 2);
			if (num > 0 && num <= array.Length)
			{
				areaMasterMode(array[RuntimeServices.NormalizeArrayIndex(array, checked(num - 1))]);
			}
		});
		actionClassallAreaMasterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable222_0024614_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002429.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassallAreaMasterMode;
	}

	public ActionClassallAreaMasterMode createallAreaMasterMode()
	{
		ActionClassallAreaMasterMode actionClassallAreaMasterMode = createDataallAreaMasterMode();
		actionClassallAreaMasterMode.selArea = 0;
		return actionClassallAreaMasterMode;
	}

	public ActionClassareaMasterMode areaMasterMode(MAreas area)
	{
		ActionClassareaMasterMode actionClassareaMasterMode = createareaMasterMode(area);
		changeAction(actionClassareaMasterMode);
		return actionClassareaMasterMode;
	}

	public ActionClassareaMasterMode createDataareaMasterMode()
	{
		ActionClassareaMasterMode actionClassareaMasterMode = new ActionClassareaMasterMode();
		actionClassareaMasterMode._0024act_0024t_0024291 = ActionEnum.areaMasterMode;
		actionClassareaMasterMode._0024act_0024t_0024292 = "$default$";
		actionClassareaMasterMode._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable223_0024631_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002430.Adapt(delegate(ActionClassareaMasterMode _0024act_0024t_0024336)
		{
			_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292 _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024 = new _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292();
			_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024._0024_0024act_0024t_0024336 = _0024act_0024t_0024336;
			_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024._0024_0024act_0024t_0024336.quests = ArrayMap.FilterMQuests(new _0024_0024createDataareaMasterMode_0024closure_00243337_0024closure_00243338(_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024).Invoke);
		});
		actionClassareaMasterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable223_0024631_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002430.Adapt(delegate(ActionClassareaMasterMode _0024act_0024t_0024336)
		{
			RuntimeDebugModeGuiMixin.label("エリア Id " + _0024act_0024t_0024336.area.Id + " " + _0024act_0024t_0024336.area.DisplayName + " クエストリスト");
			string[] texts = (string[])RuntimeServices.AddArrays(typeof(string), new string[1] { "無効" }, ArrayMap.AllMQuestsToStr((MQuests q) => q.ToString()));
			int num = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024336.selQuest, texts, 2);
			if (num > 0 && num <= _0024act_0024t_0024336.quests.Length)
			{
				MAreas area = _0024act_0024t_0024336.area;
				MQuests[] quests = _0024act_0024t_0024336.quests;
				questMode(area, quests[RuntimeServices.NormalizeArrayIndex(quests, checked(num - 1))]);
			}
		});
		actionClassareaMasterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable223_0024631_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002430.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				allAreaMasterMode();
			}
		});
		return actionClassareaMasterMode;
	}

	public ActionClassareaMasterMode createareaMasterMode(MAreas area)
	{
		ActionClassareaMasterMode actionClassareaMasterMode = createDataareaMasterMode();
		actionClassareaMasterMode.area = area;
		actionClassareaMasterMode.selQuest = 0;
		return actionClassareaMasterMode;
	}

	public ActionClassquestMode questMode(MAreas area, MQuests quest)
	{
		ActionClassquestMode actionClassquestMode = createquestMode(area, quest);
		changeAction(actionClassquestMode);
		return actionClassquestMode;
	}

	public ActionClassquestMode createDataquestMode()
	{
		ActionClassquestMode actionClassquestMode = new ActionClassquestMode();
		actionClassquestMode._0024act_0024t_0024291 = ActionEnum.questMode;
		actionClassquestMode._0024act_0024t_0024292 = "$default$";
		actionClassquestMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable225_0024651_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002431.Adapt(delegate(ActionClassquestMode _0024act_0024t_0024339)
		{
			_0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293 _0024_0024createDataquestMode_0024closure_00243342_0024locals_0024 = new _0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293();
			_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024._0024_0024act_0024t_0024339 = _0024act_0024t_0024339;
			displayQuest(_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024._0024_0024act_0024t_0024339.quest, null, new _0024_0024createDataquestMode_0024closure_00243342_0024closure_00243343(_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024, this).Invoke);
		});
		actionClassquestMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable225_0024651_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002431.Adapt(delegate(ActionClassquestMode _0024act_0024t_0024339)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				areaMasterMode(_0024act_0024t_0024339.area);
			}
		});
		return actionClassquestMode;
	}

	public ActionClassquestMode createquestMode(MAreas area, MQuests quest)
	{
		ActionClassquestMode actionClassquestMode = createDataquestMode();
		actionClassquestMode.area = area;
		actionClassquestMode.quest = quest;
		return actionClassquestMode;
	}

	public ActionClasssceneMasterMode sceneMasterMode(MScenes scn, MStories story)
	{
		ActionClasssceneMasterMode actionClasssceneMasterMode = createsceneMasterMode(scn, story);
		changeAction(actionClasssceneMasterMode);
		return actionClasssceneMasterMode;
	}

	public ActionClasssceneMasterMode createDatasceneMasterMode()
	{
		ActionClasssceneMasterMode actionClasssceneMasterMode = new ActionClasssceneMasterMode();
		actionClasssceneMasterMode._0024act_0024t_0024291 = ActionEnum.sceneMasterMode;
		actionClasssceneMasterMode._0024act_0024t_0024292 = "$default$";
		actionClasssceneMasterMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable226_0024658_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002432.Adapt(checked(delegate(ActionClasssceneMasterMode _0024act_0024t_0024342)
		{
			RuntimeDebugModeGuiMixin.label("現シーンマスター");
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024act_0024t_0024342.scn).ToString());
			if (_0024act_0024t_0024342.scn != null)
			{
				RuntimeDebugModeGuiMixin.slabel("Id:" + _0024act_0024t_0024342.scn.Id);
				RuntimeDebugModeGuiMixin.slabel("Progname:" + _0024act_0024t_0024342.scn.Progname);
				RuntimeDebugModeGuiMixin.slabel("MAreaId:" + _0024act_0024t_0024342.scn.MAreaId);
				RuntimeDebugModeGuiMixin.slabel("MQuestId:" + _0024act_0024t_0024342.scn.MQuestId);
				RuntimeDebugModeGuiMixin.slabel("SceneName:" + _0024act_0024t_0024342.scn.SceneName);
				dispConditions(_0024act_0024t_0024342.scn.AllConditions, 0, "Conditions");
				dispConditions(_0024act_0024t_0024342.scn.AllNotConditions, 0, "NotConditions");
				RuntimeDebugModeGuiMixin.slabel("BeginPeriod:" + _0024act_0024t_0024342.scn.BeginPeriod);
				RuntimeDebugModeGuiMixin.slabel("EndPeriod:" + _0024act_0024t_0024342.scn.EndPeriod);
				RuntimeDebugModeGuiMixin.slabel("TempFlag:" + _0024act_0024t_0024342.scn.TempFlag);
				RuntimeDebugModeGuiMixin.slabel("ExtMScenes:" + _0024act_0024t_0024342.scn.ExtMScenes);
				RuntimeDebugModeGuiMixin.label("Npcs:");
				int i = 0;
				MNpcs[] allNpcs = _0024act_0024t_0024342.scn.AllNpcs;
				for (int length = allNpcs.Length; i < length; i++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allNpcs[i]).ToString());
					RuntimeDebugModeGuiMixin.slabel("  PositionObject:" + allNpcs[i].PositionObject);
					RuntimeDebugModeGuiMixin.slabel("  Prefab:" + allNpcs[i].Prefab);
					RuntimeDebugModeGuiMixin.slabel("  NpcNoDupId:" + allNpcs[i].NpcNoDupId);
					dispConditions(allNpcs[i].AllConditions, 2, "Conditions");
					dispConditions(allNpcs[i].AllNotConditions, 2, "NotConditions");
					RuntimeDebugModeGuiMixin.slabel("  NpcTalkIds:");
					int j = 0;
					MNpcTalks[] allNpcTalks = allNpcs[i].AllNpcTalks;
					for (int length2 = allNpcTalks.Length; j < length2; j++)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(allNpcTalks[j]).ToString());
						RuntimeDebugModeGuiMixin.slabel("      MSceneId:" + allNpcTalks[j].MSceneId);
						RuntimeDebugModeGuiMixin.slabel("      TalkGroupId:" + allNpcTalks[j].TalkGroupId);
						RuntimeDebugModeGuiMixin.slabel("      Rate:" + allNpcTalks[j].Rate);
						RuntimeDebugModeGuiMixin.slabel("      MNpcTextId:" + allNpcTalks[j].MNpcTextId);
						RuntimeDebugModeGuiMixin.slabel("      CutScene:" + allNpcTalks[j].CutScene);
						RuntimeDebugModeGuiMixin.slabel("      NextScene:" + allNpcTalks[j].NextScene);
						RuntimeDebugModeGuiMixin.slabel("      NextSceneKeepObjects:" + allNpcTalks[j].NextSceneKeepObjects);
						RuntimeDebugModeGuiMixin.slabel("      TurnAround:" + allNpcTalks[j].TurnAround);
						RuntimeDebugModeGuiMixin.slabel("      BustShot:" + allNpcTalks[j].BustShot);
						RuntimeDebugModeGuiMixin.slabel("      Icon:" + allNpcTalks[j].Icon);
						RuntimeDebugModeGuiMixin.slabel("      Range:" + allNpcTalks[j].Range);
						RuntimeDebugModeGuiMixin.slabel("      Collision:" + allNpcTalks[j].Collision);
						RuntimeDebugModeGuiMixin.slabel("      TalkCount:" + allNpcTalks[j].TalkCount);
						RuntimeDebugModeGuiMixin.slabel("      WindowType:" + allNpcTalks[j].WindowType);
						RuntimeDebugModeGuiMixin.slabel("      TalkType:" + allNpcTalks[j].TalkType);
						dispConditions(allNpcTalks[j].AllConditions, 6, "Conditions");
						dispConditions(allNpcTalks[j].AllNotConditions, 6, "NotConditions");
						dispConditions(allNpcTalks[j].AllResults, 6, "Results");
						dispConditions(allNpcTalks[j].AllNotResults, 6, "NotResults");
					}
				}
			}
		}));
		actionClasssceneMasterMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable226_0024658_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002432.Adapt(delegate(ActionClasssceneMasterMode _0024act_0024t_0024342)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				storyMasterMode(_0024act_0024t_0024342.story);
			}
		});
		return actionClasssceneMasterMode;
	}

	public ActionClasssceneMasterMode createsceneMasterMode(MScenes scn, MStories story)
	{
		ActionClasssceneMasterMode actionClasssceneMasterMode = createDatasceneMasterMode();
		actionClasssceneMasterMode.scn = scn;
		actionClasssceneMasterMode.story = story;
		return actionClasssceneMasterMode;
	}

	private void dispConditions(MFlags[] conds, int nspc, string title)
	{
		string value = " " * nspc;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append(title).Append(": ")
			.Append((object)conds.Length)
			.Append("個")
			.ToString());
		int i = 0;
		for (int length = conds.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  ").ToString() + conds[i]);
		}
	}

	public ActionClasssessionDropMode sessionDropMode()
	{
		ActionClasssessionDropMode actionClasssessionDropMode = createsessionDropMode();
		changeAction(actionClasssessionDropMode);
		return actionClasssessionDropMode;
	}

	public ActionClasssessionDropMode createDatasessionDropMode()
	{
		ActionClasssessionDropMode actionClasssessionDropMode = new ActionClasssessionDropMode();
		actionClasssessionDropMode._0024act_0024t_0024291 = ActionEnum.sessionDropMode;
		actionClasssessionDropMode._0024act_0024t_0024292 = "$default$";
		actionClasssessionDropMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable227_0024730_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002433.Adapt(checked(delegate
		{
			RuntimeDebugModeGuiMixin.label("獲得ドロップ一覧:");
			int i = 0;
			RespSimpleReward[] array = QuestSession.AllCollectedDrops();
			for (int length = array.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(array[i]).ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("獲得ドロップ一覧(box):");
			int j = 0;
			RespReward[] array2 = QuestSession.ResultCollectedDrops();
			for (int length2 = array2.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(array2[j]).ToString());
			}
		}));
		actionClasssessionDropMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable227_0024730_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002433.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasssessionDropMode;
	}

	public ActionClasssessionDropMode createsessionDropMode()
	{
		return createDatasessionDropMode();
	}

	public ActionClasskusamushiMode kusamushiMode()
	{
		ActionClasskusamushiMode actionClasskusamushiMode = createkusamushiMode();
		changeAction(actionClasskusamushiMode);
		return actionClasskusamushiMode;
	}

	public ActionClasskusamushiMode createDatakusamushiMode()
	{
		ActionClasskusamushiMode actionClasskusamushiMode = new ActionClasskusamushiMode();
		actionClasskusamushiMode._0024act_0024t_0024291 = ActionEnum.kusamushiMode;
		actionClasskusamushiMode._0024act_0024t_0024292 = "$default$";
		actionClasskusamushiMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable228_0024743_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002434.Adapt(delegate
		{
			Dictionary<MScenes, Boo.Lang.List<QuestDropManager.DropData>> kusamushiMapForDebug = QuestSession.GetKusamushiMapForDebug();
			RuntimeDebugModeGuiMixin.label("現クエストステージドロップ一覧");
			RuntimeDebugModeGuiMixin.label("未取得草虫数:" + QuestSession.RemainingKusamushiNum);
			foreach (MScenes key in kusamushiMapForDebug.Keys)
			{
				Boo.Lang.List<QuestDropManager.DropData> list = kusamushiMapForDebug[key];
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).ToString());
				IEnumerator<QuestDropManager.DropData> enumerator2 = list.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						QuestDropManager.DropData current2 = enumerator2.Current;
						RuntimeDebugModeGuiMixin.slabel("  " + current2);
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
			}
		});
		actionClasskusamushiMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable228_0024743_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002434.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasskusamushiMode;
	}

	public ActionClasskusamushiMode createkusamushiMode()
	{
		return createDatakusamushiMode();
	}

	public ActionClassmonsterMapMode monsterMapMode()
	{
		ActionClassmonsterMapMode actionClassmonsterMapMode = createmonsterMapMode();
		changeAction(actionClassmonsterMapMode);
		return actionClassmonsterMapMode;
	}

	public ActionClassmonsterMapMode createDatamonsterMapMode()
	{
		ActionClassmonsterMapMode actionClassmonsterMapMode = new ActionClassmonsterMapMode();
		actionClassmonsterMapMode._0024act_0024t_0024291 = ActionEnum.monsterMapMode;
		actionClassmonsterMapMode._0024act_0024t_0024292 = "$default$";
		actionClassmonsterMapMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable229_0024758_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002435.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("現クエストモンスター配備一覧:");
			Dictionary<MStageBattles, RespMonster[]> monsterMap = QuestSession.MonsterMap;
			foreach (MStageBattles key in monsterMap.Keys)
			{
				if (QuestSession.IsMarkedBattle(key))
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": 済").ToString());
				}
				else
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": 未プレイ").ToString());
				}
				int i = 0;
				RespMonster[] array = monsterMap[key];
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(array[i]).ToString()))
					{
						respMonsterMode(array[i], delegate
						{
							monsterMapMode();
						});
					}
				}
			}
		});
		actionClassmonsterMapMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable229_0024758_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002435.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassmonsterMapMode;
	}

	public ActionClassmonsterMapMode createmonsterMapMode()
	{
		return createDatamonsterMapMode();
	}

	private void lastPochittaQuestStartButton()
	{
		int @int = PlayerPrefs.GetInt("Merlin-DebugMode-LastPochittaMScenes", -1);
		MScenes mScenes = MScenes.Get(@int);
		if (mScenes != null)
		{
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("最後にこの画面でポチったシーン").Append(mScenes.Progname).Append("を開始").ToString()))
			{
				jumpToMScene(MScenes.Get(@int));
			}
			RuntimeDebugModeGuiMixin.space(10);
		}
	}

	public ActionClassbattleInfoMode battleInfoMode()
	{
		ActionClassbattleInfoMode actionClassbattleInfoMode = createbattleInfoMode();
		changeAction(actionClassbattleInfoMode);
		return actionClassbattleInfoMode;
	}

	public ActionClassbattleInfoMode createDatabattleInfoMode()
	{
		ActionClassbattleInfoMode actionClassbattleInfoMode = new ActionClassbattleInfoMode();
		actionClassbattleInfoMode._0024act_0024t_0024291 = ActionEnum.battleInfoMode;
		actionClassbattleInfoMode._0024act_0024t_0024292 = "$default$";
		actionClassbattleInfoMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable230_0024790_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002436.Adapt(delegate
		{
			QuestBattleStarter currentBattle = QuestBattleStarter.CurrentBattle;
			if (currentBattle == null)
			{
				RuntimeDebugModeGuiMixin.label("<no battle>");
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("BATTLE: ").Append(currentBattle.gameObject).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MStageBattle: ").Append(currentBattle.StageBattle).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsPlaying: ").Append(QuestBattleStarter.IsPlaying).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LastStartedBattle: ").Append(QuestBattleStarter.LastStartedBattle).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  InBattleTimeScale: ").Append(currentBattle.InBattleTimeScale).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  WaveCount: ").Append((object)currentBattle.WaveCount).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  HeartBeat: ").Append((object)currentBattle.HeartBeat).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfPoppedEnemies: ").Append((object)currentBattle.NumOfPoppedEnemies).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfQueuedEnemies: ").Append((object)currentBattle.NumOfQueuedEnemies).ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfKilledEnemies: ").Append((object)currentBattle.NumOfKilledEnemies).ToString());
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("EnemyPool:");
				QuestBattleEnemyAIPool enemyPool = currentBattle.EnemyPool;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  cnt:").Append((object)enemyPool.Count).ToString());
				enemyPool.forAll(delegate(QuestBattleEnemyAIPool.PopInfo pd)
				{
					AIControl ai = pd.ai;
					if (ai != null)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).Append(" IsDead:").Append(ai.IsDead)
							.Append(" HP:")
							.Append(ai.HitPoint)
							.ToString());
					}
				});
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("Unpopped");
				foreach (RespMonster item in currentBattle.MonsterQueue)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(item).ToString());
				}
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("AllMonsters:");
				IEnumerator<RespMonster> enumerator2 = currentBattle.AllMonsters.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						RespMonster current2 = enumerator2.Current;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current2).ToString());
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				RuntimeDebugModeGuiMixin.space(20);
				if (RuntimeDebugModeGuiMixin.button("バトルリセット"))
				{
					currentBattle.debugResetBattle();
				}
			}
		});
		actionClassbattleInfoMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable230_0024790_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002436.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassbattleInfoMode;
	}

	public ActionClassbattleInfoMode createbattleInfoMode()
	{
		return createDatabattleInfoMode();
	}

	public ActionClassopenedQuestListMode openedQuestListMode()
	{
		ActionClassopenedQuestListMode actionClassopenedQuestListMode = createopenedQuestListMode();
		changeAction(actionClassopenedQuestListMode);
		return actionClassopenedQuestListMode;
	}

	public ActionClassopenedQuestListMode createDataopenedQuestListMode()
	{
		ActionClassopenedQuestListMode actionClassopenedQuestListMode = new ActionClassopenedQuestListMode();
		actionClassopenedQuestListMode._0024act_0024t_0024291 = ActionEnum.openedQuestListMode;
		actionClassopenedQuestListMode._0024act_0024t_0024292 = "$default$";
		actionClassopenedQuestListMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable231_0024834_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002437.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("Opened Quests");
			int i = 0;
			MQuests[] all = MQuests.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				EnumQuestTypes questType = all[i].QuestType;
				bool flag = QuestManager.IsQuestReady(all[i], questType);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)all[i].Id).Append(" ").Append(all[i].Progname)
					.Append(": ")
					.Append(flag)
					.ToString());
			}
		});
		actionClassopenedQuestListMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable231_0024834_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002437.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassopenedQuestListMode;
	}

	public ActionClassopenedQuestListMode createopenedQuestListMode()
	{
		return createDataopenedQuestListMode();
	}

	public ActionClassopenedWeekEventsMode openedWeekEventsMode()
	{
		ActionClassopenedWeekEventsMode actionClassopenedWeekEventsMode = createopenedWeekEventsMode();
		changeAction(actionClassopenedWeekEventsMode);
		return actionClassopenedWeekEventsMode;
	}

	public ActionClassopenedWeekEventsMode createDataopenedWeekEventsMode()
	{
		ActionClassopenedWeekEventsMode actionClassopenedWeekEventsMode = new ActionClassopenedWeekEventsMode();
		actionClassopenedWeekEventsMode._0024act_0024t_0024291 = ActionEnum.openedWeekEventsMode;
		actionClassopenedWeekEventsMode._0024act_0024t_0024292 = "$default$";
		actionClassopenedWeekEventsMode._0024act_0024t_0024293 = _0024adaptor_0024__DebugSubModeQuest_0024callable232_0024844_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002438.Adapt(delegate(ActionClassopenedWeekEventsMode _0024act_0024t_0024360)
		{
			_0024act_0024t_0024360.today = MerlinDateTime.UtcNow;
			_0024act_0024t_0024360.localToday = MerlinDateTime.Now;
			_0024act_0024t_0024360.localNow = new TimeSpan(_0024act_0024t_0024360.localToday.Hour, _0024act_0024t_0024360.localToday.Minute, _0024act_0024t_0024360.localToday.Second);
			_0024act_0024t_0024360.localTodayWeek = (int)_0024act_0024t_0024360.localToday.DayOfWeek;
			_0024act_0024t_0024360.data = new Boo.Lang.List<string>();
			int i = 0;
			MWeekEvents[] all = MWeekEvents.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				bool flag = QuestManager.IsWeekEventReady(all[i], _0024act_0024t_0024360.today, _0024act_0024t_0024360.localNow, _0024act_0024t_0024360.localTodayWeek);
				_0024act_0024t_0024360.data.Add(new StringBuilder().Append(all[i].MStoryId.Progname).Append(" ").Append(flag)
					.Append(" (")
					.Append((object)all[i].MStoryId.Id)
					.Append(") - w:")
					.Append(all[i].Week)
					.Append(" period:")
					.Append(all[i].BeginDate)
					.Append("~")
					.Append(all[i].EndDate)
					.Append(" grp:")
					.Append((object)all[i].PlayerGroupId)
					.Append(" time:")
					.Append(all[i].BeginTime)
					.Append("~")
					.Append(all[i].EndTime)
					.ToString());
			}
			_0024act_0024t_0024360.data.Sort();
		});
		actionClassopenedWeekEventsMode._0024act_0024t_0024297 = _0024adaptor_0024__DebugSubModeQuest_0024callable232_0024844_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002438.Adapt(delegate(ActionClassopenedWeekEventsMode _0024act_0024t_0024360)
		{
			RuntimeDebugModeGuiMixin.label("Opened MWeekEvents");
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("today: ").Append(_0024act_0024t_0024360.today).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localToday: ").Append(_0024act_0024t_0024360.localToday).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localNow: ").Append(_0024act_0024t_0024360.localNow).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localTodayWeek: ").Append((object)_0024act_0024t_0024360.localTodayWeek).ToString());
			RuntimeDebugModeGuiMixin.space(10);
			IEnumerator<string> enumerator = _0024act_0024t_0024360.data.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					RuntimeDebugModeGuiMixin.slabel(current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		});
		actionClassopenedWeekEventsMode._0024act_0024t_0024295 = _0024adaptor_0024__DebugSubModeQuest_0024callable232_0024844_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002438.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassopenedWeekEventsMode;
	}

	public ActionClassopenedWeekEventsMode createopenedWeekEventsMode()
	{
		return createDataopenedWeekEventsMode();
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243039()
	{
		if (RuntimeDebugModeGuiMixin.button("現バトル情報"))
		{
			battleInfoMode();
		}
		if (RuntimeDebugModeGuiMixin.button("獲得ドロップ一覧"))
		{
			sessionDropMode();
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243040()
	{
		if (RuntimeDebugModeGuiMixin.button("モンスター配備"))
		{
			monsterMapMode();
		}
		if (RuntimeDebugModeGuiMixin.button("草虫一覧"))
		{
			kusamushiMode();
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243041()
	{
		if (RuntimeDebugModeGuiMixin.button("クエストオープン状況"))
		{
			openedQuestListMode();
		}
		if (RuntimeDebugModeGuiMixin.button("MWeekEventsオープン状況"))
		{
			openedWeekEventsMode();
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243042()
	{
		if (RuntimeDebugModeGuiMixin.button("新チャレンジマスタ"))
		{
			v3ChallengeMaster();
		}
		if (RuntimeDebugModeGuiMixin.button("battleミッション"))
		{
			battleMissionInfoMode();
		}
	}

	internal string _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243286(object v)
	{
		return (!RuntimeServices.ToBool(v)) ? string.Empty : "ブロックあり";
	}

	internal int _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243287(RespMonster a, RespMonster b)
	{
		return checked(a.Id - b.Id);
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243288()
	{
		RuntimeDebugModeGuiMixin.toggle(ref QuestSession.LastSessionParameter.needResultMode, "結果画面");
		if (RuntimeDebugModeGuiMixin.button("強制成功"))
		{
			QuestClearConditionChecker.Instance.doClear();
			ExitDebugMode();
		}
		else if (RuntimeDebugModeGuiMixin.button("強制失敗"))
		{
			QuestClearConditionChecker.Instance.doFail();
			ExitDebugMode();
		}
		else if (RuntimeDebugModeGuiMixin.button("強制時間切れ"))
		{
			QuestClearConditionChecker.Instance.doTimeOver();
			ExitDebugMode();
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243037_0024closure_00243297()
	{
		QuestSession.Load();
	}

	internal void _0024createDatamainMode_0024closure_00243298(ActionClassmainMode _0024act_0024t_0024290)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDatabattleMissionInfoMode_0024closure_00243299(ActionClassbattleMissionInfoMode _0024act_0024t_0024306)
	{
		RuntimeDebugModeGuiMixin.label("バトルミッション情報");
		RuntimeDebugModeGuiMixin.slabel("状態異常罹患数: " + QuestEventHandler.PlayerAbnormalStateCount);
		RuntimeDebugModeGuiMixin.slabel("ダメージ数: " + QuestEventHandler.PlayerDamageCount);
		RuntimeDebugModeGuiMixin.slabel("プレイ時間(s): " + QuestEventHandler.PlayerCurrentPlayTime);
		RuntimeDebugModeGuiMixin.slabel("攻撃力: " + QuestEventHandler.PlayerTotalAttack);
		RuntimeDebugModeGuiMixin.slabel("HP: " + QuestEventHandler.PlayerTotalHP);
		RuntimeDebugModeGuiMixin.slabel("最終HP: " + QuestEventHandler.PlayerLastHP);
	}

	internal void _0024createDatabattleMissionInfoMode_0024closure_00243300(ActionClassbattleMissionInfoMode _0024act_0024t_0024306)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatav3ChallengeMaster_0024closure_00243301(ActionClassv3ChallengeMaster _0024act_0024t_0024309)
	{
		_0024act_0024t_0024309.schedules = MChallengeQuestSchedules.GetOpenSchedules();
		_0024act_0024t_0024309.quests = MChallengeQuestScheduleDetails.GetOpenQuests();
	}

	internal void _0024createDatav3ChallengeMaster_0024closure_00243302(ActionClassv3ChallengeMaster _0024act_0024t_0024309)
	{
		RuntimeDebugModeGuiMixin.label("challenge schedules:");
		int i = 0;
		MChallengeQuestSchedules[] schedules = _0024act_0024t_0024309.schedules;
		checked
		{
			for (int length = schedules.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("id=").Append((object)schedules[i].Id).Append(" ").Append(schedules[i].BeginDate)
					.Append(" ~ ")
					.Append(schedules[i].EndDate)
					.ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("quests:");
			int j = 0;
			MQuests[] quests = _0024act_0024t_0024309.quests;
			for (int length2 = quests.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(quests[j].ToString());
			}
		}
	}

	internal void _0024createDatav3ChallengeMaster_0024closure_00243303(ActionClassv3ChallengeMaster _0024act_0024t_0024309)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataallQuestMasterMode_0024closure_00243304(ActionClassallQuestMasterMode _0024act_0024t_0024312)
	{
		_0024act_0024t_0024312.quests = ArrayMap.AllMQuests();
		sortQuestArray(_0024act_0024t_0024312.quests, sortMode);
		_0024act_0024t_0024312.pageLines = 50;
		pageTop = Mathf.Clamp(pageTop, 0, _0024act_0024t_0024312.quests.Length);
		checked
		{
			pageTop = unchecked(pageTop / _0024act_0024t_0024312.pageLines) * _0024act_0024t_0024312.pageLines;
		}
	}

	internal int _0024sortQuestArray_0024closure_00243305(MQuests q1, MQuests q2)
	{
		return string.Compare(q1.Progname, q2.Progname);
	}

	internal int _0024sortQuestArray_0024closure_00243306(MQuests q1, MQuests q2)
	{
		return checked(q1.Id - q2.Id);
	}

	internal int _0024sortQuestArray_0024closure_00243307(MQuests q)
	{
		return q.Deprecated ? 10000 : 0;
	}

	internal void _0024createDataallQuestMasterMode_0024closure_00243309(ActionClassallQuestMasterMode _0024act_0024t_0024312)
	{
		_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289 _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024 = new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_002414289();
		_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312 = _0024act_0024t_0024312;
		RuntimeDebugModeGuiMixin.label("クエスト一覧");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("クエスト通信選択");
		withServerId = RuntimeDebugModeGuiMixin.grid(withServerId, new string[2] { "あり", "なし" }, 2);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("並び順:");
		int num = RuntimeDebugModeGuiMixin.grid(sortMode, new string[3] { "識別名", "ID", "有効/無効" }, 3);
		if (num != sortMode)
		{
			sortMode = num;
			sortQuestArray(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests, sortMode);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243310(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.space(10);
		int num2 = 0;
		int pageLines = _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.pageLines;
		if (pageLines < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < pageLines)
		{
			int num3 = num2;
			num2++;
			int num4 = checked(pageTop + num3);
			if (num4 < _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests.Length)
			{
				MQuests[] quests = _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024_0024act_0024t_0024312.quests;
				_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024._0024q = quests[RuntimeServices.NormalizeArrayIndex(quests, num4)];
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataallQuestMasterMode_0024closure_00243309_0024closure_00243311(_0024_0024createDataallQuestMasterMode_0024closure_00243309_0024locals_0024, this).Invoke));
			}
		}
	}

	internal void _0024createDataallQuestMasterMode_0024closure_00243312(ActionClassallQuestMasterMode _0024act_0024t_0024312)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataallQuestMasterSubMode_0024closure_00243313(ActionClassallQuestMasterSubMode _0024act_0024t_0024315)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024315.q).ToString());
		string lhs = "このクエストをプレイ ";
		lhs = ((withServerId != 0) ? (lhs + "(通信ナシ無し)") : (lhs + "(通信あり)"));
		if (RuntimeDebugModeGuiMixin.button(lhs))
		{
			playQuest(_0024act_0024t_0024315.q, withServerId == 0);
		}
		RuntimeDebugModeGuiMixin.space(10);
		displayQuest(_0024act_0024t_0024315.q, null, _0024adaptor_0024__DebugSubModeQuest_0024callable213_0024364_36___0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___002439.Adapt(() => allQuestMasterMode()));
	}

	internal ActionClassallQuestMasterMode _0024_0024createDataallQuestMasterSubMode_0024closure_00243313_0024closure_00243314()
	{
		return allQuestMasterMode();
	}

	internal void _0024createDataallQuestMasterSubMode_0024closure_00243315(ActionClassallQuestMasterSubMode _0024act_0024t_0024315)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			allQuestMasterMode();
		}
	}

	internal void _0024createDatastoryMasterMode_0024closure_00243316(ActionClassstoryMasterMode _0024act_0024t_0024318)
	{
		_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290 _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024 = new _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_002414290();
		_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318 = _0024act_0024t_0024318;
		if (_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story == null)
		{
			mainMode();
			return;
		}
		RuntimeDebugModeGuiMixin.label("現ストーリーマスター");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Group: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.GroupId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Prev: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.PrevGroupId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsTutorial: ").Append(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.IsTutorial).ToString());
		displayQuest(_0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story.MQuestId, _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024._0024_0024act_0024t_0024318.story, new _0024_0024createDatastoryMasterMode_0024closure_00243316_0024closure_00243317(this, _0024_0024createDatastoryMasterMode_0024closure_00243316_0024locals_0024).Invoke);
	}

	internal void _0024createDatastoryMasterMode_0024closure_00243318(ActionClassstoryMasterMode _0024act_0024t_0024318)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataclearSuccMode_0024closure_00243319(ActionClassclearSuccMode _0024act_0024t_0024321)
	{
		_0024act_0024t_0024321.story = null;
		int i = 0;
		MStories[] all = MStories.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(all[i].MQuestId, _0024act_0024t_0024321.quest))
			{
				_0024act_0024t_0024321.story = all[i];
				break;
			}
		}
		if (_0024act_0024t_0024321.story != null)
		{
			QuestSession.StartSessionDebug(RuntimeDebugMode.Instance, _0024act_0024t_0024321.story.Id, noSceneLoad: true);
		}
	}

	internal void _0024createDataclearSuccMode_0024closure_00243321(ActionClassclearSuccMode _0024act_0024t_0024321)
	{
		if (_0024act_0024t_0024321.story == null && _0024act_0024t_0024321.backMethod != null)
		{
			_0024act_0024t_0024321.backMethod();
		}
		RuntimeDebugModeGuiMixin.label("通信中");
		if (QuestSession.IsInPlay)
		{
			QuestSession.GotAllMonsterDropAll();
			QuestSession.Succeeded();
		}
		else if (QuestSession.CompletelyClosed && RuntimeDebugModeGuiMixin.button("戻る") && _0024act_0024t_0024321.backMethod != null)
		{
			_0024act_0024t_0024321.backMethod();
		}
	}

	internal void _0024createDataclearSuccMode_0024closure_00243322(ActionClassclearSuccMode _0024act_0024t_0024321)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			_0024act_0024t_0024321.backMethod();
		}
	}

	internal int _0024displayQuest_0024closure_00243323(MScenes a, MScenes b)
	{
		return checked(a.Id - b.Id);
	}

	internal void _0024createDatanpcMode_0024closure_00243326(ActionClassnpcMode _0024act_0024t_0024324)
	{
		string value = " " * _0024act_0024t_0024324.nspc;
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(value).Append(_0024act_0024t_0024324.npc).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  DisplayName:").ToString() + _0024act_0024t_0024324.npc.DisplayName);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  DisplayName_En:").ToString() + _0024act_0024t_0024324.npc.DisplayName_En);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  PositionObject:").ToString() + _0024act_0024t_0024324.npc.PositionObject);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("  Prefab:").ToString() + _0024act_0024t_0024324.npc.Prefab);
		checked
		{
			dispConditions(_0024act_0024t_0024324.npc.AllConditions, _0024act_0024t_0024324.nspc + 2, "Conditions");
			dispConditions(_0024act_0024t_0024324.npc.AllConditions, _0024act_0024t_0024324.nspc + 2, "NotConditions");
			int i = 0;
			MNpcTalks[] allNpcTalks = _0024act_0024t_0024324.npc.AllNpcTalks;
			for (int length = allNpcTalks.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(value).Append("    ").Append(allNpcTalks[i])
					.ToString());
			}
		}
	}

	internal void _0024createDatanpcMode_0024closure_00243327(ActionClassnpcMode _0024act_0024t_0024324)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			_0024act_0024t_0024324.backMethod();
		}
	}

	internal void _0024createDatamonsterMode_0024closure_00243328(ActionClassmonsterMode _0024act_0024t_0024327)
	{
		_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291 _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024 = new _0024_0024createDatamonsterMode_0024closure_00243328_0024locals_002414291();
		_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024._0024ig = _0024act_0024t_0024327.m.MItemGroupId;
		if (_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024._0024ig != null)
		{
			_0024act_0024t_0024327.drops = ArrayMap.FilterMItemGroupChilds(new _0024_0024createDatamonsterMode_0024closure_00243328_0024closure_00243329(_0024_0024createDatamonsterMode_0024closure_00243328_0024locals_0024).Invoke);
		}
		else
		{
			_0024act_0024t_0024327.drops = new MItemGroupChilds[0];
		}
	}

	internal void _0024createDatamonsterMode_0024closure_00243330(ActionClassmonsterMode _0024act_0024t_0024327)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024327.m).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MStageId: ").Append((object)_0024act_0024t_0024327.m.MStageId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MMonsterId: ").Append(_0024act_0024t_0024327.m.MMonsterId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  CorrespondentNpc: ").Append(_0024act_0024t_0024327.m.CorrespondentNpc).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsBoss: ").Append((object)_0024act_0024t_0024327.m.IsBoss).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LevelMin: ").Append((object)_0024act_0024t_0024327.m.LevelMin).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LevelMax: ").Append((object)_0024act_0024t_0024327.m.LevelMax).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Quantity: ").Append((object)_0024act_0024t_0024327.m.Quantity).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Rate: ").Append((object)_0024act_0024t_0024327.m.Rate).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  PopStep: ").Append((object)_0024act_0024t_0024327.m.PopStep).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  DummyDropLevel: ").Append((object)_0024act_0024t_0024327.m.DummyDropLevel).Append(" DummyCoin: ").Append((object)_0024act_0024t_0024327.m.DummyCoin)
			.ToString());
		RuntimeDebugModeGuiMixin.label("DROPS:");
		int i = 0;
		MItemGroupChilds[] drops = _0024act_0024t_0024327.drops;
		for (int length = drops.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel("  " + drops[i]);
		}
	}

	internal void _0024createDatamonsterMode_0024closure_00243331(ActionClassmonsterMode _0024act_0024t_0024327)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			_0024act_0024t_0024327.backMethod();
		}
	}

	internal void _0024createDatarespMonsterMode_0024closure_00243332(ActionClassrespMonsterMode _0024act_0024t_0024330)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024330.m).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("MST:").Append(_0024act_0024t_0024330.m.Master).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Attack:").Append((object)_0024act_0024t_0024330.m.Attack).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Hp:").Append((object)_0024act_0024t_0024330.m.Hp).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Critical:").Append((object)_0024act_0024t_0024330.m.Critical).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("BreakPow:").Append((object)_0024act_0024t_0024330.m.BreakPow).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Resist:").Append((object)_0024act_0024t_0024330.m.Resist).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Defense:").Append((object)_0024act_0024t_0024330.m.Defense).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Exp:").Append((object)_0024act_0024t_0024330.m.Exp).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Coin:").Append((object)_0024act_0024t_0024330.m.Coin).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsKill:").Append(_0024act_0024t_0024330.m.IsKill).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Level:").Append((object)_0024act_0024t_0024330.m.Level).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Element:").Append((object)_0024act_0024t_0024330.m.Element).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Race:").Append((object)_0024act_0024t_0024330.m.Race).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("DROPS:");
		int i = 0;
		RespSimpleReward[] rewards = _0024act_0024t_0024330.m.Rewards;
		for (int length = rewards.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel("   " + rewards[i]);
		}
	}

	internal void _0024createDatarespMonsterMode_0024closure_00243333(ActionClassrespMonsterMode _0024act_0024t_0024330)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			_0024act_0024t_0024330.backMethod();
		}
	}

	internal void _0024createDataallAreaMasterMode_0024closure_00243334(ActionClassallAreaMasterMode _0024act_0024t_0024333)
	{
		RuntimeDebugModeGuiMixin.label("エリア");
		lastPochittaQuestStartButton();
		MAreas[] array = ArrayMap.AllMAreas();
		string[] texts = (string[])RuntimeServices.AddArrays(typeof(string), new string[1] { "無効" }, ArrayMap.AllMAreasToStr((MAreas am) => am.Id + ":" + am.DisplayName));
		int num = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024333.selArea, texts, 2);
		if (num > 0 && num <= array.Length)
		{
			areaMasterMode(array[RuntimeServices.NormalizeArrayIndex(array, checked(num - 1))]);
		}
	}

	internal string _0024_0024createDataallAreaMasterMode_0024closure_00243334_0024closure_00243335(MAreas am)
	{
		return am.Id + ":" + am.DisplayName;
	}

	internal void _0024createDataallAreaMasterMode_0024closure_00243336(ActionClassallAreaMasterMode _0024act_0024t_0024333)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataareaMasterMode_0024closure_00243337(ActionClassareaMasterMode _0024act_0024t_0024336)
	{
		_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292 _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024 = new _0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_002414292();
		_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024._0024_0024act_0024t_0024336 = _0024act_0024t_0024336;
		_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024._0024_0024act_0024t_0024336.quests = ArrayMap.FilterMQuests(new _0024_0024createDataareaMasterMode_0024closure_00243337_0024closure_00243338(_0024_0024createDataareaMasterMode_0024closure_00243337_0024locals_0024).Invoke);
	}

	internal void _0024createDataareaMasterMode_0024closure_00243339(ActionClassareaMasterMode _0024act_0024t_0024336)
	{
		RuntimeDebugModeGuiMixin.label("エリア Id " + _0024act_0024t_0024336.area.Id + " " + _0024act_0024t_0024336.area.DisplayName + " クエストリスト");
		string[] texts = (string[])RuntimeServices.AddArrays(typeof(string), new string[1] { "無効" }, ArrayMap.AllMQuestsToStr((MQuests q) => q.ToString()));
		int num = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024336.selQuest, texts, 2);
		if (num > 0 && num <= _0024act_0024t_0024336.quests.Length)
		{
			MAreas area = _0024act_0024t_0024336.area;
			MQuests[] quests = _0024act_0024t_0024336.quests;
			questMode(area, quests[RuntimeServices.NormalizeArrayIndex(quests, checked(num - 1))]);
		}
	}

	internal string _0024_0024createDataareaMasterMode_0024closure_00243339_0024closure_00243340(MQuests q)
	{
		return q.ToString();
	}

	internal void _0024createDataareaMasterMode_0024closure_00243341(ActionClassareaMasterMode _0024act_0024t_0024336)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			allAreaMasterMode();
		}
	}

	internal void _0024createDataquestMode_0024closure_00243342(ActionClassquestMode _0024act_0024t_0024339)
	{
		_0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293 _0024_0024createDataquestMode_0024closure_00243342_0024locals_0024 = new _0024_0024createDataquestMode_0024closure_00243342_0024locals_002414293();
		_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024._0024_0024act_0024t_0024339 = _0024act_0024t_0024339;
		displayQuest(_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024._0024_0024act_0024t_0024339.quest, null, new _0024_0024createDataquestMode_0024closure_00243342_0024closure_00243343(_0024_0024createDataquestMode_0024closure_00243342_0024locals_0024, this).Invoke);
	}

	internal void _0024createDataquestMode_0024closure_00243344(ActionClassquestMode _0024act_0024t_0024339)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			areaMasterMode(_0024act_0024t_0024339.area);
		}
	}

	internal void _0024createDatasceneMasterMode_0024closure_00243345(ActionClasssceneMasterMode _0024act_0024t_0024342)
	{
		RuntimeDebugModeGuiMixin.label("現シーンマスター");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024act_0024t_0024342.scn).ToString());
		if (_0024act_0024t_0024342.scn == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.slabel("Id:" + _0024act_0024t_0024342.scn.Id);
		RuntimeDebugModeGuiMixin.slabel("Progname:" + _0024act_0024t_0024342.scn.Progname);
		RuntimeDebugModeGuiMixin.slabel("MAreaId:" + _0024act_0024t_0024342.scn.MAreaId);
		RuntimeDebugModeGuiMixin.slabel("MQuestId:" + _0024act_0024t_0024342.scn.MQuestId);
		RuntimeDebugModeGuiMixin.slabel("SceneName:" + _0024act_0024t_0024342.scn.SceneName);
		dispConditions(_0024act_0024t_0024342.scn.AllConditions, 0, "Conditions");
		dispConditions(_0024act_0024t_0024342.scn.AllNotConditions, 0, "NotConditions");
		RuntimeDebugModeGuiMixin.slabel("BeginPeriod:" + _0024act_0024t_0024342.scn.BeginPeriod);
		RuntimeDebugModeGuiMixin.slabel("EndPeriod:" + _0024act_0024t_0024342.scn.EndPeriod);
		RuntimeDebugModeGuiMixin.slabel("TempFlag:" + _0024act_0024t_0024342.scn.TempFlag);
		RuntimeDebugModeGuiMixin.slabel("ExtMScenes:" + _0024act_0024t_0024342.scn.ExtMScenes);
		RuntimeDebugModeGuiMixin.label("Npcs:");
		int i = 0;
		MNpcs[] allNpcs = _0024act_0024t_0024342.scn.AllNpcs;
		checked
		{
			for (int length = allNpcs.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allNpcs[i]).ToString());
				RuntimeDebugModeGuiMixin.slabel("  PositionObject:" + allNpcs[i].PositionObject);
				RuntimeDebugModeGuiMixin.slabel("  Prefab:" + allNpcs[i].Prefab);
				RuntimeDebugModeGuiMixin.slabel("  NpcNoDupId:" + allNpcs[i].NpcNoDupId);
				dispConditions(allNpcs[i].AllConditions, 2, "Conditions");
				dispConditions(allNpcs[i].AllNotConditions, 2, "NotConditions");
				RuntimeDebugModeGuiMixin.slabel("  NpcTalkIds:");
				int j = 0;
				MNpcTalks[] allNpcTalks = allNpcs[i].AllNpcTalks;
				for (int length2 = allNpcTalks.Length; j < length2; j++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(allNpcTalks[j]).ToString());
					RuntimeDebugModeGuiMixin.slabel("      MSceneId:" + allNpcTalks[j].MSceneId);
					RuntimeDebugModeGuiMixin.slabel("      TalkGroupId:" + allNpcTalks[j].TalkGroupId);
					RuntimeDebugModeGuiMixin.slabel("      Rate:" + allNpcTalks[j].Rate);
					RuntimeDebugModeGuiMixin.slabel("      MNpcTextId:" + allNpcTalks[j].MNpcTextId);
					RuntimeDebugModeGuiMixin.slabel("      CutScene:" + allNpcTalks[j].CutScene);
					RuntimeDebugModeGuiMixin.slabel("      NextScene:" + allNpcTalks[j].NextScene);
					RuntimeDebugModeGuiMixin.slabel("      NextSceneKeepObjects:" + allNpcTalks[j].NextSceneKeepObjects);
					RuntimeDebugModeGuiMixin.slabel("      TurnAround:" + allNpcTalks[j].TurnAround);
					RuntimeDebugModeGuiMixin.slabel("      BustShot:" + allNpcTalks[j].BustShot);
					RuntimeDebugModeGuiMixin.slabel("      Icon:" + allNpcTalks[j].Icon);
					RuntimeDebugModeGuiMixin.slabel("      Range:" + allNpcTalks[j].Range);
					RuntimeDebugModeGuiMixin.slabel("      Collision:" + allNpcTalks[j].Collision);
					RuntimeDebugModeGuiMixin.slabel("      TalkCount:" + allNpcTalks[j].TalkCount);
					RuntimeDebugModeGuiMixin.slabel("      WindowType:" + allNpcTalks[j].WindowType);
					RuntimeDebugModeGuiMixin.slabel("      TalkType:" + allNpcTalks[j].TalkType);
					dispConditions(allNpcTalks[j].AllConditions, 6, "Conditions");
					dispConditions(allNpcTalks[j].AllNotConditions, 6, "NotConditions");
					dispConditions(allNpcTalks[j].AllResults, 6, "Results");
					dispConditions(allNpcTalks[j].AllNotResults, 6, "NotResults");
				}
			}
		}
	}

	internal void _0024createDatasceneMasterMode_0024closure_00243346(ActionClasssceneMasterMode _0024act_0024t_0024342)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			storyMasterMode(_0024act_0024t_0024342.story);
		}
	}

	internal void _0024createDatasessionDropMode_0024closure_00243347(ActionClasssessionDropMode _0024act_0024t_0024345)
	{
		RuntimeDebugModeGuiMixin.label("獲得ドロップ一覧:");
		int i = 0;
		RespSimpleReward[] array = QuestSession.AllCollectedDrops();
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(array[i]).ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("獲得ドロップ一覧(box):");
			int j = 0;
			RespReward[] array2 = QuestSession.ResultCollectedDrops();
			for (int length2 = array2.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(array2[j]).ToString());
			}
		}
	}

	internal void _0024createDatasessionDropMode_0024closure_00243348(ActionClasssessionDropMode _0024act_0024t_0024345)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatakusamushiMode_0024closure_00243349(ActionClasskusamushiMode _0024act_0024t_0024348)
	{
		Dictionary<MScenes, Boo.Lang.List<QuestDropManager.DropData>> kusamushiMapForDebug = QuestSession.GetKusamushiMapForDebug();
		RuntimeDebugModeGuiMixin.label("現クエストステージドロップ一覧");
		RuntimeDebugModeGuiMixin.label("未取得草虫数:" + QuestSession.RemainingKusamushiNum);
		foreach (MScenes key in kusamushiMapForDebug.Keys)
		{
			Boo.Lang.List<QuestDropManager.DropData> list = kusamushiMapForDebug[key];
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).ToString());
			IEnumerator<QuestDropManager.DropData> enumerator2 = list.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					QuestDropManager.DropData current2 = enumerator2.Current;
					RuntimeDebugModeGuiMixin.slabel("  " + current2);
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	internal void _0024createDatakusamushiMode_0024closure_00243350(ActionClasskusamushiMode _0024act_0024t_0024348)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatamonsterMapMode_0024closure_00243351(ActionClassmonsterMapMode _0024act_0024t_0024351)
	{
		RuntimeDebugModeGuiMixin.label("現クエストモンスター配備一覧:");
		Dictionary<MStageBattles, RespMonster[]> monsterMap = QuestSession.MonsterMap;
		foreach (MStageBattles key in monsterMap.Keys)
		{
			if (QuestSession.IsMarkedBattle(key))
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": 済").ToString());
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": 未プレイ").ToString());
			}
			int i = 0;
			RespMonster[] array = monsterMap[key];
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(array[i]).ToString()))
				{
					respMonsterMode(array[i], delegate
					{
						monsterMapMode();
					});
				}
			}
		}
	}

	internal void _0024_0024createDatamonsterMapMode_0024closure_00243351_0024closure_00243352()
	{
		monsterMapMode();
	}

	internal void _0024createDatamonsterMapMode_0024closure_00243353(ActionClassmonsterMapMode _0024act_0024t_0024351)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatabattleInfoMode_0024closure_00243354(ActionClassbattleInfoMode _0024act_0024t_0024354)
	{
		QuestBattleStarter currentBattle = QuestBattleStarter.CurrentBattle;
		if (currentBattle == null)
		{
			RuntimeDebugModeGuiMixin.label("<no battle>");
			return;
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("BATTLE: ").Append(currentBattle.gameObject).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  MStageBattle: ").Append(currentBattle.StageBattle).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsPlaying: ").Append(QuestBattleStarter.IsPlaying).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  LastStartedBattle: ").Append(QuestBattleStarter.LastStartedBattle).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  InBattleTimeScale: ").Append(currentBattle.InBattleTimeScale).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  WaveCount: ").Append((object)currentBattle.WaveCount).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  HeartBeat: ").Append((object)currentBattle.HeartBeat).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfPoppedEnemies: ").Append((object)currentBattle.NumOfPoppedEnemies).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfQueuedEnemies: ").Append((object)currentBattle.NumOfQueuedEnemies).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  NumOfKilledEnemies: ").Append((object)currentBattle.NumOfKilledEnemies).ToString());
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("EnemyPool:");
		QuestBattleEnemyAIPool enemyPool = currentBattle.EnemyPool;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  cnt:").Append((object)enemyPool.Count).ToString());
		enemyPool.forAll(delegate(QuestBattleEnemyAIPool.PopInfo pd)
		{
			AIControl ai = pd.ai;
			if (ai != null)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).ToString());
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).Append(" IsDead:").Append(ai.IsDead)
					.Append(" HP:")
					.Append(ai.HitPoint)
					.ToString());
			}
		});
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("Unpopped");
		foreach (RespMonster item in currentBattle.MonsterQueue)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(item).ToString());
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("AllMonsters:");
		IEnumerator<RespMonster> enumerator2 = currentBattle.AllMonsters.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				RespMonster current2 = enumerator2.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current2).ToString());
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("バトルリセット"))
		{
			currentBattle.debugResetBattle();
		}
	}

	internal void _0024_0024createDatabattleInfoMode_0024closure_00243354_0024closure_00243355(QuestBattleEnemyAIPool.PopInfo pd)
	{
		AIControl ai = pd.ai;
		if (ai != null)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).ToString());
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(pd.ai).Append(" IsDead:").Append(ai.IsDead)
				.Append(" HP:")
				.Append(ai.HitPoint)
				.ToString());
		}
	}

	internal void _0024createDatabattleInfoMode_0024closure_00243356(ActionClassbattleInfoMode _0024act_0024t_0024354)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataopenedQuestListMode_0024closure_00243357(ActionClassopenedQuestListMode _0024act_0024t_0024357)
	{
		RuntimeDebugModeGuiMixin.label("Opened Quests");
		int i = 0;
		MQuests[] all = MQuests.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			EnumQuestTypes questType = all[i].QuestType;
			bool flag = QuestManager.IsQuestReady(all[i], questType);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)all[i].Id).Append(" ").Append(all[i].Progname)
				.Append(": ")
				.Append(flag)
				.ToString());
		}
	}

	internal void _0024createDataopenedQuestListMode_0024closure_00243358(ActionClassopenedQuestListMode _0024act_0024t_0024357)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataopenedWeekEventsMode_0024closure_00243359(ActionClassopenedWeekEventsMode _0024act_0024t_0024360)
	{
		_0024act_0024t_0024360.today = MerlinDateTime.UtcNow;
		_0024act_0024t_0024360.localToday = MerlinDateTime.Now;
		_0024act_0024t_0024360.localNow = new TimeSpan(_0024act_0024t_0024360.localToday.Hour, _0024act_0024t_0024360.localToday.Minute, _0024act_0024t_0024360.localToday.Second);
		_0024act_0024t_0024360.localTodayWeek = (int)_0024act_0024t_0024360.localToday.DayOfWeek;
		_0024act_0024t_0024360.data = new Boo.Lang.List<string>();
		int i = 0;
		MWeekEvents[] all = MWeekEvents.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			bool flag = QuestManager.IsWeekEventReady(all[i], _0024act_0024t_0024360.today, _0024act_0024t_0024360.localNow, _0024act_0024t_0024360.localTodayWeek);
			_0024act_0024t_0024360.data.Add(new StringBuilder().Append(all[i].MStoryId.Progname).Append(" ").Append(flag)
				.Append(" (")
				.Append((object)all[i].MStoryId.Id)
				.Append(") - w:")
				.Append(all[i].Week)
				.Append(" period:")
				.Append(all[i].BeginDate)
				.Append("~")
				.Append(all[i].EndDate)
				.Append(" grp:")
				.Append((object)all[i].PlayerGroupId)
				.Append(" time:")
				.Append(all[i].BeginTime)
				.Append("~")
				.Append(all[i].EndTime)
				.ToString());
		}
		_0024act_0024t_0024360.data.Sort();
	}

	internal void _0024createDataopenedWeekEventsMode_0024closure_00243360(ActionClassopenedWeekEventsMode _0024act_0024t_0024360)
	{
		RuntimeDebugModeGuiMixin.label("Opened MWeekEvents");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("today: ").Append(_0024act_0024t_0024360.today).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localToday: ").Append(_0024act_0024t_0024360.localToday).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localNow: ").Append(_0024act_0024t_0024360.localNow).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("localTodayWeek: ").Append((object)_0024act_0024t_0024360.localTodayWeek).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		IEnumerator<string> enumerator = _0024act_0024t_0024360.data.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024createDataopenedWeekEventsMode_0024closure_00243361(ActionClassopenedWeekEventsMode _0024act_0024t_0024360)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}
}
