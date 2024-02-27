using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class QuestRouteFinder
{
	[Serializable]
	internal class _0024SearchSimpleRoute_0024locals_002414425
	{
		internal System.Collections.Generic.List<EPJumpPoint> _0024jumps;
	}

	[Serializable]
	internal class _0024setupNpcRoute_0024locals_002414426
	{
		internal System.Collections.Generic.List<AbstractEventPoint> _0024_route;
	}

	[Serializable]
	internal class _0024SearchRoute_0024locals_002414427
	{
		internal Dictionary<MScenes, bool> _0024marks;

		internal System.Collections.Generic.List<EnumMapLinkDir> _0024waystack;

		internal MScenes _0024goal;
	}

	[Serializable]
	internal class _0024SearchSimpleRoute_0024_contains_00243887
	{
		internal _0024SearchSimpleRoute_0024locals_002414425 _0024_0024locals_002414973;

		public _0024SearchSimpleRoute_0024_contains_00243887(_0024SearchSimpleRoute_0024locals_002414425 _0024_0024locals_002414973)
		{
			this._0024_0024locals_002414973 = _0024_0024locals_002414973;
		}

		public bool Invoke(MScenes scn)
		{
			bool flag;
			foreach (EPJumpPoint _0024jump in _0024_0024locals_002414973._0024jumps)
			{
				if (!RuntimeServices.EqualityOperator(_0024jump.scene, scn))
				{
					continue;
				}
				flag = true;
				goto IL_0056;
			}
			int result = 0;
			goto IL_0057;
			IL_0056:
			result = (flag ? 1 : 0);
			goto IL_0057;
			IL_0057:
			return (byte)result != 0;
		}
	}

	[Serializable]
	internal class _0024SearchSimpleRoute_0024_add_point_00243888
	{
		internal _0024SearchSimpleRoute_0024locals_002414425 _0024_0024locals_002414974;

		public _0024SearchSimpleRoute_0024_add_point_00243888(_0024SearchSimpleRoute_0024locals_002414425 _0024_0024locals_002414974)
		{
			this._0024_0024locals_002414974 = _0024_0024locals_002414974;
		}

		public void Invoke(EPJumpPoint n)
		{
			if (n != null)
			{
				_0024_0024locals_002414974._0024jumps.Add(n);
			}
		}
	}

	[Serializable]
	internal class _0024setupNpcRoute_0024closure_00243889
	{
		internal _0024setupNpcRoute_0024locals_002414426 _0024_0024locals_002414975;

		public _0024setupNpcRoute_0024closure_00243889(_0024setupNpcRoute_0024locals_002414426 _0024_0024locals_002414975)
		{
			this._0024_0024locals_002414975 = _0024_0024locals_002414975;
		}

		public void Invoke(EPJumpPoint jmp)
		{
			_0024_0024locals_002414975._0024_route.Add(jmp);
		}
	}

	[Serializable]
	internal class _0024SearchRoute_0024_find_00243890
	{
		internal _0024SearchRoute_0024locals_002414427 _0024_0024locals_002414976;

		public _0024SearchRoute_0024_find_00243890(_0024SearchRoute_0024locals_002414427 _0024_0024locals_002414976)
		{
			this._0024_0024locals_002414976 = _0024_0024locals_002414976;
		}

		public bool Invoke(MScenes _scn)
		{
			int result;
			if (RuntimeServices.EqualityOperator(_scn, _0024_0024locals_002414976._0024goal))
			{
				result = 1;
			}
			else
			{
				_0024_0024locals_002414976._0024marks[_scn] = true;
				IEnumerator enumerator = Enum.GetValues(typeof(EnumMapLinkDir)).GetEnumerator();
				while (true)
				{
					if (enumerator.MoveNext())
					{
						EnumMapLinkDir enumMapLinkDir = (EnumMapLinkDir)enumerator.Current;
						MScenes linkTo = GetLinkTo(_scn, enumMapLinkDir);
						if (linkTo != null && !_0024_0024locals_002414976._0024marks[linkTo])
						{
							_0024_0024locals_002414976._0024waystack.Add(enumMapLinkDir);
							if (Invoke(linkTo))
							{
								result = 1;
								break;
							}
							_0024_0024locals_002414976._0024waystack.RemoveAt(checked(_0024_0024locals_002414976._0024waystack.Count - 1));
						}
						continue;
					}
					_0024_0024locals_002414976._0024marks[_scn] = false;
					result = 0;
					break;
				}
			}
			return (byte)result != 0;
		}
	}

	private MQuests quest;

	private System.Collections.Generic.List<AbstractEventPoint> route;

	[NonSerialized]
	private static bool DEBUG_ERRLOG;

	public bool AutoRunOn
	{
		get
		{
			bool num = quest != null;
			if (num)
			{
				num = quest.AutoRunOn;
				if (!num)
				{
					num = GameParameter.forceAutoRun;
				}
			}
			return num;
		}
	}

	public bool HasRoute => route.Count > 0;

	public int PointNum => route.Count;

	public MQuests Quest => quest;

	public System.Collections.Generic.List<AbstractEventPoint> Route => route;

	public QuestRouteFinder()
	{
		route = new System.Collections.Generic.List<AbstractEventPoint>();
		clearRoute();
	}

	public AbstractEventPoint getPoint(int index)
	{
		return (0 > index || index >= route.Count) ? null : route[index];
	}

	public void clearRoute()
	{
		if (DEBUG_ERRLOG)
		{
		}
		quest = null;
		route.Clear();
	}

	public void setup(MQuests q)
	{
		if (DEBUG_ERRLOG)
		{
		}
		clearRoute();
		quest = q;
		if (q == null)
		{
			return;
		}
		MAutoFlowPoint[] allFlowPoints = MAutoFlowPoint.GetAllFlowPoints(q);
		if (allFlowPoints != null && allFlowPoints.Length > 0)
		{
			if (!setupMasterFlow(q, allFlowPoints))
			{
				clearRoute();
			}
		}
		else
		{
			setupAutomaticaly(q);
		}
	}

	private bool setupMasterFlow(MQuests q, MAutoFlowPoint[] mpnts)
	{
		MScenes startSceneId = q.StartSceneId;
		int num = 0;
		int length = mpnts.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (mpnts[num] == null)
				{
					result = 0;
					break;
				}
				MScenes sceneId = mpnts[num].SceneId;
				bool flag = GenerateJumpPoints(q, startSceneId, sceneId, delegate(EPJumpPoint jmp)
				{
					route.Add(jmp);
				});
				AbstractEventPoint abstractEventPoint = pointMasterToEventPoint(mpnts[num]);
				if (abstractEventPoint != null)
				{
					route.Add(abstractEventPoint);
					if (!flag)
					{
						result = 0;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 0;
				break;
			}
			if (DEBUG_ERRLOG)
			{
			}
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	private AbstractEventPoint pointMasterToEventPoint(MAutoFlowPoint mpnt)
	{
		object result;
		if (mpnt.Type != 0)
		{
			result = ((mpnt.Type == AutoFlowPointTypes.FlagAndPos) ? new EPFlagPoint(mpnt.SceneId, mpnt.FlagAndPos_Name, mpnt.FlagAndPos_PosInfo) : ((mpnt.Type == AutoFlowPointTypes.Object) ? ((AbstractEventPoint)new EPObjectPoint(mpnt.SceneId, mpnt.Object_GameObjectName)) : ((AbstractEventPoint)((mpnt.Type != AutoFlowPointTypes.Pos) ? null : new EPPositionPoint(mpnt.SceneId, mpnt.Pos_PositionInfo)))));
		}
		else
		{
			MNpcTalks talk_NpcTalks = mpnt.Talk_NpcTalks;
			result = ((talk_NpcTalks != null) ? new EPNpcPoint(mpnt.Talk_NpcTalks) : null);
		}
		return (AbstractEventPoint)result;
	}

	private void setupAutomaticaly(MQuests q)
	{
		MQuestClears mQuestClears = MasterUtil.FindClearCondition(q, EnumQuestClearTypes.Talk);
		if (mQuestClears != null)
		{
			MNpcs npc = MasterUtil.FindNpcByTalk(mQuestClears.NpcTalk);
			MScenes end = MasterUtil.FindSceneByNpc(npc);
			if (GenerateJumpPoints(q, q.StartSceneId, end, delegate(EPJumpPoint jmp)
			{
				route.Add(jmp);
			}))
			{
				route.Add(new EPNpcPoint(mQuestClears.NpcTalk));
			}
		}
		else
		{
			setupSimpleRoute(q);
		}
		if (!DEBUG_ERRLOG)
		{
		}
	}

	private void setupSimpleRoute(MQuests q)
	{
		__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ _QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ = delegate(MScenes _scn)
		{
			if (_scn != null)
			{
				int i = 0;
				MStageBattles[] allStageBattles = _scn.AllStageBattles;
				for (int length = allStageBattles.Length; i < length; i = checked(i + 1))
				{
					route.Add(new EPBattlePoint(_scn, allStageBattles[i]));
				}
			}
		};
		System.Collections.Generic.List<EPJumpPoint> list = new System.Collections.Generic.List<EPJumpPoint>();
		if (!SearchSimpleRoute(q.StartSceneId, list) || list.Count <= 0)
		{
			return;
		}
		_QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__(list[0].scene);
		foreach (EPJumpPoint item in list)
		{
			route.Add(item);
			_QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__(item.jumpTo);
		}
	}

	private static bool SearchSimpleRoute(MScenes cur, System.Collections.Generic.List<EPJumpPoint> jumps)
	{
		_0024SearchSimpleRoute_0024locals_002414425 _0024SearchSimpleRoute_0024locals_0024 = new _0024SearchSimpleRoute_0024locals_002414425();
		_0024SearchSimpleRoute_0024locals_0024._0024jumps = jumps;
		EPJumpPoint[] linkNodes = GetLinkNodes(cur);
		__QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__ _QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__ = new _0024SearchSimpleRoute_0024_contains_00243887(_0024SearchSimpleRoute_0024locals_0024).Invoke;
		__QuestRouteFinder_GenerateJumpPoints_0024callable79_0024231_97__ _QuestRouteFinder_GenerateJumpPoints_0024callable79_0024231_97__ = new _0024SearchSimpleRoute_0024_add_point_00243888(_0024SearchSimpleRoute_0024locals_0024).Invoke;
		int result;
		if (linkNodes.Length == 0)
		{
			_QuestRouteFinder_GenerateJumpPoints_0024callable79_0024231_97__(new EPJumpPoint(cur));
			result = 1;
		}
		else
		{
			int num = 0;
			EPJumpPoint[] array = linkNodes;
			int length = array.Length;
			while (true)
			{
				if (num < length)
				{
					if (!_QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__(array[num].jumpTo))
					{
						_QuestRouteFinder_GenerateJumpPoints_0024callable79_0024231_97__(array[num]);
						result = (SearchSimpleRoute(array[num].jumpTo, _0024SearchSimpleRoute_0024locals_0024._0024jumps) ? 1 : 0);
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 1;
				break;
			}
		}
		return (byte)result != 0;
	}

	private bool setupNpcRoute(MQuests q, MNpcTalks[] talks)
	{
		_0024setupNpcRoute_0024locals_002414426 _0024setupNpcRoute_0024locals_0024 = new _0024setupNpcRoute_0024locals_002414426();
		int result;
		if (talks == null || talks.Length <= 0)
		{
			result = 0;
		}
		else
		{
			_0024setupNpcRoute_0024locals_0024._0024_route = new System.Collections.Generic.List<AbstractEventPoint>();
			MScenes mScenes = q.StartSceneId;
			if (mScenes == null)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				int length = talks.Length;
				while (true)
				{
					if (num < length)
					{
						MScenes mScenes2 = MasterUtil.FindSceneByNpc(MasterUtil.FindNpcByTalk(talks[num]));
						if (mScenes2 == null)
						{
							result = 0;
							break;
						}
						if (!GenerateJumpPoints(q, mScenes, mScenes2, new _0024setupNpcRoute_0024closure_00243889(_0024setupNpcRoute_0024locals_0024).Invoke))
						{
							result = 0;
							break;
						}
						_0024setupNpcRoute_0024locals_0024._0024_route.Add(new EPNpcPoint(talks[num]));
						mScenes = mScenes2;
						num = checked(num + 1);
						continue;
					}
					foreach (AbstractEventPoint item in _0024setupNpcRoute_0024locals_0024._0024_route)
					{
						route.Add(item);
					}
					result = 1;
					break;
				}
			}
		}
		return (byte)result != 0;
	}

	private static bool GenerateJumpPoints(MQuests q, MScenes start, MScenes end, __QuestRouteFinder_GenerateJumpPoints_0024callable79_0024231_97__ c)
	{
		EnumMapLinkDir[] array = SearchRoute(q, start, end);
		int result;
		if (array == null)
		{
			result = 0;
		}
		else
		{
			MScenes mScenes = start;
			int num = 0;
			EnumMapLinkDir[] array2 = array;
			int length = array2.Length;
			while (true)
			{
				if (num < length)
				{
					MScenes linkTo = GetLinkTo(mScenes, array2[num]);
					if (linkTo == null)
					{
						result = 0;
						break;
					}
					if (c != null)
					{
						c(new EPJumpPoint(mScenes, linkTo, array2[num]));
					}
					mScenes = linkTo;
					num = checked(num + 1);
					continue;
				}
				result = (RuntimeServices.EqualityOperator(mScenes, end) ? 1 : 0);
				break;
			}
		}
		return (byte)result != 0;
	}

	private static EnumMapLinkDir[] SearchRoute(MQuests q, MScenes start, MScenes goal)
	{
		_0024SearchRoute_0024locals_002414427 _0024SearchRoute_0024locals_0024 = new _0024SearchRoute_0024locals_002414427();
		_0024SearchRoute_0024locals_0024._0024goal = goal;
		_0024SearchRoute_0024locals_0024._0024marks = new Dictionary<MScenes, bool>();
		_0024SearchRoute_0024locals_0024._0024waystack = new System.Collections.Generic.List<EnumMapLinkDir>();
		__QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__ _QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__ = new _0024SearchRoute_0024_find_00243890(_0024SearchRoute_0024locals_0024).Invoke;
		MScenes[] array = q.StartSceneId.collectAllLinkedScenes();
		int i = 0;
		MScenes[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			_0024SearchRoute_0024locals_0024._0024marks[array2[i]] = false;
		}
		return (start != null && _0024SearchRoute_0024locals_0024._0024goal != null) ? ((!_QuestRouteFinder_SearchSimpleRoute_0024callable171_0024168_13__(start)) ? null : _0024SearchRoute_0024locals_0024._0024waystack.ToArray()) : null;
	}

	private static EPJumpPoint[] GetLinkNodes(MScenes scene)
	{
		object result;
		if (scene == null)
		{
			result = new EPJumpPoint[0];
		}
		else
		{
			System.Collections.Generic.List<EPJumpPoint> list = new System.Collections.Generic.List<EPJumpPoint>();
			IEnumerator enumerator = Enum.GetValues(typeof(EnumMapLinkDir)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				EnumMapLinkDir dir = (EnumMapLinkDir)enumerator.Current;
				MScenes linkTo = GetLinkTo(scene, dir);
				if (linkTo != null)
				{
					list.Add(new EPJumpPoint(scene, linkTo, dir));
				}
			}
			result = (EPJumpPoint[])Builtins.array(typeof(EPJumpPoint), list);
		}
		return (EPJumpPoint[])result;
	}

	private static MScenes GetLinkTo(MScenes scene, EnumMapLinkDir dir)
	{
		return (scene == null || scene.isBlocked(dir)) ? null : scene.linkTo(dir);
	}

	internal void _0024setupMasterFlow_0024closure_00243884(EPJumpPoint jmp)
	{
		route.Add(jmp);
	}

	internal void _0024setupAutomaticaly_0024closure_00243885(EPJumpPoint jmp)
	{
		route.Add(jmp);
	}

	internal void _0024setupSimpleRoute_0024_add_battles_00243886(MScenes _scn)
	{
		if (_scn != null)
		{
			int i = 0;
			MStageBattles[] allStageBattles = _scn.AllStageBattles;
			for (int length = allStageBattles.Length; i < length; i = checked(i + 1))
			{
				route.Add(new EPBattlePoint(_scn, allStageBattles[i]));
			}
		}
	}
}
