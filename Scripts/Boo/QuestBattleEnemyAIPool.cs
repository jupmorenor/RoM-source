using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class QuestBattleEnemyAIPool
{
	[Serializable]
	public class PopInfo
	{
		public AIControl ai;

		public EnemyInstantiationData popInfo;

		public bool IsPoppedAtNpcPos
		{
			get
			{
				bool num = popInfo != null;
				if (num)
				{
					num = popInfo.useNPCPos;
				}
				return num;
			}
		}

		public Vector3 PoppedNpcPos => popInfo.pos;

		public bool IsAntiBattleResetMonster => popInfo != null && popInfo.monster != null && (popInfo.monster.StageMonsterMaster?.AntiBattleReset ?? false);

		public PopInfo(AIControl _ai, EnemyInstantiationData _popInfo)
		{
			ai = _ai;
			popInfo = _popInfo;
		}
	}

	[Serializable]
	internal class _0024remove_0024locals_002414409
	{
		internal AIControl _0024ai;
	}

	[Serializable]
	internal class _0024notifyHudAtKilling_0024locals_002414410
	{
		internal RespMonster _0024md;
	}

	[Serializable]
	internal class _0024remove_0024closure_00242989
	{
		internal _0024remove_0024locals_002414409 _0024_0024locals_002414946;

		public _0024remove_0024closure_00242989(_0024remove_0024locals_002414409 _0024_0024locals_002414946)
		{
			this._0024_0024locals_002414946 = _0024_0024locals_002414946;
		}

		public bool Invoke(PopInfo pd)
		{
			return pd.ai == _0024_0024locals_002414946._0024ai;
		}
	}

	[Serializable]
	internal class _0024notifyHudAtKilling_0024closure_00242992
	{
		internal _0024notifyHudAtKilling_0024locals_002414410 _0024_0024locals_002414947;

		public _0024notifyHudAtKilling_0024closure_00242992(_0024notifyHudAtKilling_0024locals_002414410 _0024_0024locals_002414947)
		{
			this._0024_0024locals_002414947 = _0024_0024locals_002414947;
		}

		public void Invoke(int monsterId, int num)
		{
			if (_0024_0024locals_002414947._0024md.MasterId == monsterId)
			{
				int killedMonsterNum = QuestSession.GetKilledMonsterNum(monsterId);
				BattleHUDQuestCondition.dispCondSomeEnemies(monsterId, killedMonsterNum, num);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024instantiateEnemy_002418616 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespMonster _0024respMon_002418617;

			internal MMonsters _0024mstMon_002418618;

			internal CharacterCache _0024chcache_002418619;

			internal GameObject _0024prefab_002418620;

			internal GameObject _0024obj_002418621;

			internal MStageMonsters _0024stgMonMst_002418622;

			internal float _0024scale_002418623;

			internal AIControl _0024ai_002418624;

			internal EnemyInstantiationData _0024ed_002418625;

			internal QuestBattleEnemyAIPool _0024self__002418626;

			public _0024(EnemyInstantiationData ed, QuestBattleEnemyAIPool self_)
			{
				_0024ed_002418625 = ed;
				_0024self__002418626 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024ed_002418625 == null)
					{
						throw new AssertionFailedException("ed != null");
					}
					_0024respMon_002418617 = _0024ed_002418625.monster;
					if (_0024respMon_002418617 == null)
					{
						throw new AssertionFailedException("respMon != null");
					}
					_0024mstMon_002418618 = _0024respMon_002418617.Master;
					if (_0024mstMon_002418618 == null)
					{
						throw new AssertionFailedException("mstMon != null");
					}
					_0024self__002418626.lastPopData = _0024ed_002418625;
					_0024chcache_002418619 = CharacterCache.Instance;
					debuglog(new StringBuilder("popEnemy: ").Append(_0024mstMon_002418618.PrefabName).ToString());
					_0024prefab_002418620 = null;
					goto case 2;
				case 2:
					if (_0024prefab_002418620 == null)
					{
						_0024prefab_002418620 = _0024chcache_002418619.load(_0024mstMon_002418618.PrefabName);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024obj_002418621 = (GameObject)UnityEngine.Object.Instantiate(_0024prefab_002418620, _0024ed_002418625.pos, _0024ed_002418625.rot);
					_0024stgMonMst_002418622 = _0024respMon_002418617.StageMonsterMaster;
					if (_0024stgMonMst_002418622 != null && _0024stgMonMst_002418622.HasScale)
					{
						_0024scale_002418623 = _0024stgMonMst_002418622.PopScale;
						_0024obj_002418621.transform.localScale = new Vector3(_0024scale_002418623, _0024scale_002418623, _0024scale_002418623);
					}
					_0024ai_002418624 = _0024obj_002418621.GetComponent<AIControl>();
					if (!(_0024ai_002418624 != null))
					{
						throw new AssertionFailedException(new StringBuilder().Append(_0024mstMon_002418618.PrefabName).Append("にAIControlが貼られていない！").ToString());
					}
					_0024ai_002418624.deadCallback = _0024self__002418626.markMonsterRewardsAndStopAI;
					_0024ai_002418624.DestroyIfKilled = _0024respMon_002418617.DestroyIfKilled;
					_0024self__002418626.add(_0024ai_002418624, _0024ed_002418625);
					_0024ai_002418624.MonsterData = _0024respMon_002418617;
					if (_0024ed_002418625.withPopEffect)
					{
						QuestAssets.Instance.instantiatePopSmoke(_0024ed_002418625.pos, _0024ed_002418625.rot);
					}
					if (_0024respMon_002418617.IsElite)
					{
						setEnemyElite(_0024ai_002418624.gameObject, _0024mstMon_002418618);
					}
					if (_0024respMon_002418617.IsBoss)
					{
						try
						{
							PlayerEventDispatcher.InvokeBossStart(_0024ai_002418624);
						}
						catch (Exception)
						{
						}
					}
					_0024ed_002418625.resultAI = _0024ai_002418624;
					_0024self__002418626.lastPopData = _0024ed_002418625;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EnemyInstantiationData _0024ed_002418627;

		internal QuestBattleEnemyAIPool _0024self__002418628;

		public _0024instantiateEnemy_002418616(EnemyInstantiationData ed, QuestBattleEnemyAIPool self_)
		{
			_0024ed_002418627 = ed;
			_0024self__002418628 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024ed_002418627, _0024self__002418628);
		}
	}

	[NonSerialized]
	private const string ELITE_SHADER = "Custom/Unlit_Rim";

	private Boo.Lang.List<PopInfo> enemies;

	private HashSet<int> killedMonsterIds;

	private EnemyInstantiationData lastPopData;

	[NonSerialized]
	private static bool DEBUG_LOG;

	public int KillNum => killedMonsterIds.Count;

	public PopInfo[] InfoListCopy => (PopInfo[])Builtins.array(typeof(PopInfo), enemies);

	public int Count => enemies.Count;

	public int AliveCount
	{
		get
		{
			int num = 0;
			IEnumerator<PopInfo> enumerator = enemies.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PopInfo current = enumerator.Current;
					if (current.ai != null && current.ai.IsAlive)
					{
						num = checked(num + 1);
					}
				}
				return num;
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}

	public AIControl LastPopMonster => (lastPopData == null) ? null : lastPopData.resultAI;

	public QuestBattleEnemyAIPool()
	{
		enemies = new Boo.Lang.List<PopInfo>();
		killedMonsterIds = new HashSet<int>();
	}

	public void dispose()
	{
		enemies.Clear();
		killedMonsterIds.Clear();
		lastPopData = null;
	}

	public void cleanupCorpse()
	{
		enemies.RemoveAll(_0024adaptor_0024__QuestBattleEnemyAIPool_0024callable351_002455_28___0024Predicate_0024154.Adapt((PopInfo pd) => pd.ai == null));
		forAllCorpse(markMonsterRewardsAndStopAI);
	}

	public void forAll(__QuestBattleEnemyAIPool_forAll_0024callable74_002458_29__ c)
	{
		if (c == null)
		{
			return;
		}
		IEnumerator<PopInfo> enumerator = enemies.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PopInfo current = enumerator.Current;
				c(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void forAllAlives(__QuestBattleEnemyAIPool_forAll_0024callable74_002458_29__ c)
	{
		if (c == null)
		{
			return;
		}
		IEnumerator<PopInfo> enumerator = enemies.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PopInfo current = enumerator.Current;
				if (!(current.ai == null) && !current.ai.IsDead)
				{
					c(current);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void forAllKilledIds(__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ c)
	{
		if (c == null)
		{
			return;
		}
		foreach (int killedMonsterId in killedMonsterIds)
		{
			c(killedMonsterId);
		}
	}

	public IEnumerator instantiateEnemy(EnemyInstantiationData ed)
	{
		return new _0024instantiateEnemy_002418616(ed, this).GetEnumerator();
	}

	private bool contains(AIControl ai)
	{
		int result;
		bool flag;
		if (ai == null)
		{
			result = 0;
		}
		else
		{
			IEnumerator<PopInfo> enumerator = enemies.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PopInfo current = enumerator.Current;
					if (!(current.ai == ai))
					{
						continue;
					}
					flag = true;
					goto IL_005c;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = 0;
		}
		goto IL_005d;
		IL_005d:
		return (byte)result != 0;
		IL_005c:
		result = (flag ? 1 : 0);
		goto IL_005d;
	}

	private bool remove(AIControl ai)
	{
		_0024remove_0024locals_002414409 _0024remove_0024locals_0024 = new _0024remove_0024locals_002414409();
		_0024remove_0024locals_0024._0024ai = ai;
		enemies.RemoveAll(_0024adaptor_0024__QuestBattleEnemyAIPool_0024callable351_002455_28___0024Predicate_0024154.Adapt(new _0024remove_0024closure_00242989(_0024remove_0024locals_0024).Invoke));
		return false;
	}

	private void add(AIControl ai, EnemyInstantiationData ed)
	{
		if (!(ai == null))
		{
			enemies.Add(new PopInfo(ai, ed));
		}
	}

	private void forAllCorpse(__DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ deadCallback)
	{
		if (!(deadCallback != null))
		{
			return;
		}
		PopInfo[] array = (PopInfo[])Builtins.array(typeof(PopInfo), enemies);
		int i = 0;
		PopInfo[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			AIControl ai = array2[i].ai;
			if (ai != null && !(ai.HitPoint > 0f))
			{
				deadCallback(ai);
			}
		}
	}

	private void markMonsterRewardsAndStopAI(AIControl ai)
	{
		if (!(ai == null) && contains(ai))
		{
			remove(ai);
			RespMonster monsterData = ai.MonsterData;
			if (QuestSession.KillMonster(monsterData))
			{
				notifyHudAtKilling(monsterData);
			}
			QuestSession.GotMonsterExp(monsterData);
			killedMonsterIds.Add(monsterData.MasterId);
			D540ScriptRunner component = ai.gameObject.GetComponent<D540ScriptRunner>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private void notifyHudAtKilling(RespMonster md)
	{
		_0024notifyHudAtKilling_0024locals_002414410 _0024notifyHudAtKilling_0024locals_0024 = new _0024notifyHudAtKilling_0024locals_002414410();
		_0024notifyHudAtKilling_0024locals_0024._0024md = md;
		if (_0024notifyHudAtKilling_0024locals_0024._0024md != null)
		{
			QuestClearConditionChecker instance = QuestClearConditionChecker.Instance;
			if (instance.HasAllEnemies)
			{
				int killedNum = QuestSession.KilledNum;
				int allMonsterNum = QuestSession.AllMonsterNum;
				BattleHUDQuestCondition.dispCondAllEnemies(killedNum, allMonsterNum);
			}
			if (instance.HasSomeEnemies)
			{
				instance.doSomeEnemiesCondition(new _0024notifyHudAtKilling_0024closure_00242992(_0024notifyHudAtKilling_0024locals_0024).Invoke);
			}
		}
	}

	private static void setEnemyElite(GameObject obj, MMonsters mon)
	{
		if (!(obj == null) && mon != null)
		{
			Color color = new Color(mon.EliteColorR, mon.EliteColorG, mon.EliteColorB, mon.EliteColorA);
			setEnemyEliteColor(obj, color);
			setEnemyEliteEffect(obj);
		}
	}

	private static void setEnemyEliteColor(GameObject obj, Color color)
	{
		SkinnedMeshRenderer componentInChildren = obj.GetComponentInChildren<SkinnedMeshRenderer>();
		if ((bool)componentInChildren)
		{
			componentInChildren.material.shader = Shader.Find("Custom/Unlit_Rim");
			componentInChildren.material.SetColor("_Color", color);
			componentInChildren.castShadows = ShadowCheck.RealShadowFlag;
		}
	}

	private static void setEnemyEliteEffect(GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		Transform transform = ExtensionsModule.FindInDescendants(obj.transform, "cog");
		if (transform != null)
		{
			GameObject gameObject = QuestAssets.Instance.instantiateEliteEffect();
			if (gameObject != null)
			{
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.parent = transform;
				gameObject.transform.position = transform.position;
				gameObject.transform.rotation = transform.rotation;
			}
		}
	}

	private static void debuglog(string msg)
	{
		if (!DEBUG_LOG)
		{
		}
	}

	internal bool _0024cleanupCorpse_0024closure_00242988(PopInfo pd)
	{
		return pd.ai == null;
	}
}
