using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PlayerAutoFlowController : MonoBehaviour, PlayerEventHandlers
{
	private PlayerControl player;

	private bool isAuto;

	private bool changedAuto;

	private float autoFlowSpeed;

	private QuestRouteFinder questRouteFinder;

	private int currentPointIndex;

	private MQuests mappedQuest;

	[NonSerialized]
	private static bool DEBUG_ERRLOG;

	public AbstractEventPoint CurrentPoint => questRouteFinder.getPoint(currentPointIndex);

	private bool IsAutoRunEnabled => questRouteFinder.AutoRunOn;

	public PlayerControl Player => player;

	public bool IsAuto => isAuto;

	public bool ChangedAuto => changedAuto;

	public float AutoFlowSpeed
	{
		get
		{
			return autoFlowSpeed;
		}
		set
		{
			autoFlowSpeed = value;
		}
	}

	public QuestRouteFinder RouteFinder => questRouteFinder;

	public int CurrentPointIndex => currentPointIndex;

	public MQuests MappedQuest => mappedQuest;

	public PlayerAutoFlowController()
	{
		autoFlowSpeed = 1f;
		questRouteFinder = new QuestRouteFinder();
		currentPointIndex = -1;
	}

	public static PlayerAutoFlowController Create(PlayerControl p)
	{
		if (!(p != null))
		{
			throw new AssertionFailedException("p != null");
		}
		if (DEBUG_ERRLOG)
		{
		}
		PlayerAutoFlowController playerAutoFlowController = ExtensionsModule.SetComponent<PlayerAutoFlowController>(p.gameObject);
		playerAutoFlowController.init(p);
		return playerAutoFlowController;
	}

	private void init(PlayerControl p)
	{
		player = p;
		clearFlow();
	}

	public void clearFlow()
	{
		if (DEBUG_ERRLOG)
		{
		}
		questRouteFinder.clearRoute();
		currentPointIndex = -1;
		mappedQuest = null;
	}

	public void Start()
	{
		player = gameObject.GetComponent("PlayerControl") as PlayerControl;
		changedAuto = player.EnableAuto;
	}

	public void Update()
	{
		if (!(player != null) || changedAuto == player.EnableAuto)
		{
			return;
		}
		changedAuto = player.EnableAuto;
		isAuto = IsAutoCondition();
		if (isAuto)
		{
			if (player.IsBattleMode)
			{
				player.AutoBattle.enabled = true;
			}
			else
			{
				ProcessEvent();
			}
		}
		else
		{
			player.AutoBattle.enabled = false;
			player.CharPathFinder.Stop();
		}
	}

	public void OnEnable()
	{
		PlayerEventDispatcher.Add(this);
		SceneChanger.ScenePostChangeEvent += ScenePostChangeEvent;
		QuestLinkRoutine.JumpStartEvent += JumpStartEvent;
		QuestLinkRoutine.JumpEndEvent += JumpEndEvent;
		CutSceneManager.CutScenePlayStartEvent += CutScenePlayStartEvent;
		CutSceneManager.CutScenePlayEndEvent += CutScenePlayEndEvent;
		GameLevelManager.NpcTalkEndEvent += NpcTalkEndEvent;
	}

	public void OnDisable()
	{
		PlayerEventDispatcher.Remove(this);
		SceneChanger.ScenePostChangeEvent -= ScenePostChangeEvent;
		QuestLinkRoutine.JumpStartEvent -= JumpStartEvent;
		QuestLinkRoutine.JumpEndEvent -= JumpEndEvent;
		CutSceneManager.CutScenePlayStartEvent -= CutScenePlayStartEvent;
		CutSceneManager.CutScenePlayEndEvent -= CutScenePlayEndEvent;
		GameLevelManager.NpcTalkEndEvent -= NpcTalkEndEvent;
	}

	public void OnDestroy()
	{
		player = null;
		clearFlow();
	}

	public bool IsAutoCondition()
	{
		return !(QuestManager.Instance == null) && QuestManager.Instance.CurQuest != null && !(QuestLinkRoutine.Instance == null) && !QuestLinkRoutine.Instance.IsJumpingNow && ((!(player == null) && player.EnableAuto) ? true : false);
	}

	public bool IsTutorialScene(int sceneID)
	{
		return (sceneID == 564 || sceneID == 565 || sceneID == 566 || sceneID == 567 || sceneID == 568 || sceneID == 569) ? true : false;
	}

	public void startFlow(MQuests q)
	{
		initFlow(q);
		ProcessEvent();
	}

	private void ScenePostChangeEvent(SceneID sceneID, string sceneName)
	{
		isAuto = IsAutoCondition();
		updateCurrentPoint();
		ProcessEvent();
	}

	private void updateNavigationArrow()
	{
		Vector3 autoTargetPos = GetAutoTargetPos();
		if (autoTargetPos != Vector3.zero)
		{
			SetNevArrowPos(autoTargetPos);
		}
		if (isAuto)
		{
			player.hideNavigationArrow();
			goPlayerTo(autoTargetPos);
		}
		else
		{
			player.showNavigationArrow();
		}
	}

	private void goPlayerTo(Vector3 targetPos)
	{
		if (IsAutoRunEnabled && targetPos != Vector3.zero)
		{
			player.CharPathFinder.Goto(targetPos);
		}
	}

	public void JumpStartEvent(MScenes jumpTo)
	{
		if (player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
	}

	public void JumpEndEvent()
	{
		isAuto = IsAutoCondition();
		CheckStageEvent();
		Vector3 autoTargetPos = GetAutoTargetPos();
		if (autoTargetPos != Vector3.zero)
		{
		}
		if (isAuto)
		{
			player.hideNavigationArrow();
			if (autoTargetPos != Vector3.zero)
			{
				goPlayerTo(autoTargetPos);
			}
		}
		else
		{
			player.showNavigationArrow();
		}
	}

	private void CheckStageEvent()
	{
		if (QuestInitializer.IsInQuest && !RuntimeServices.EqualityOperator(mappedQuest, QuestSession.Quest))
		{
			initFlow(QuestSession.Quest);
		}
		updateCurrentPoint();
	}

	private void initFlow(MQuests q)
	{
		if (DEBUG_ERRLOG)
		{
		}
		clearFlow();
		mappedQuest = q;
		questRouteFinder.setup(q);
		updateCurrentPoint();
	}

	private void updateCurrentPoint()
	{
		AutoFlowEnv autoFlowEnv = new AutoFlowEnv();
		autoFlowEnv.playerPos = player.MYPOS;
		MScenes currentScene = QuestSession.CurrentScene;
		int num = 0;
		int pointNum = questRouteFinder.PointNum;
		if (pointNum < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < pointNum)
		{
			int num2 = num;
			num++;
			AbstractEventPoint point = questRouteFinder.getPoint(num2);
			if (point != null && point.isInScene(currentScene) && !point.isReachedAndSatisfied(autoFlowEnv))
			{
				if (currentPointIndex != num2)
				{
					point.initInScene();
				}
				currentPointIndex = num2;
				return;
			}
		}
		currentPointIndex = -1;
	}

	private Vector3 GetAutoTargetPos()
	{
		return (CurrentPoint == null) ? Vector3.zero : CurrentPoint.position();
	}

	public bool ProcessEvent()
	{
		if (DEBUG_ERRLOG)
		{
		}
		int result;
		if (CutSceneManager.Instance.isBusy)
		{
			result = 0;
		}
		else if (NpcTalkControl.IsBusy)
		{
			result = 0;
		}
		else if (player.IsDead)
		{
			result = 0;
		}
		else
		{
			CheckStageEvent();
			Vector3 autoTargetPos = GetAutoTargetPos();
			if (autoTargetPos != Vector3.zero)
			{
				SetNevArrowPos(autoTargetPos);
			}
			if (!isAuto)
			{
				if (autoTargetPos == Vector3.zero)
				{
					result = 0;
				}
				else
				{
					player.showNavigationArrow();
					result = 0;
				}
			}
			else
			{
				player.hideNavigationArrow();
				if (currentPointIndex < 0 || currentPointIndex >= questRouteFinder.PointNum)
				{
					result = 0;
				}
				else if (QuestSession.IsSessionSucceeded)
				{
					clearFlow();
					result = 0;
				}
				else if (autoTargetPos == Vector3.zero)
				{
					result = 0;
				}
				else
				{
					if (DEBUG_ERRLOG)
					{
					}
					goPlayerTo(autoTargetPos);
					result = 1;
				}
			}
		}
		return (byte)result != 0;
	}

	public void CutScenePlayStartEvent(string cutSceneName)
	{
		if ((bool)player)
		{
			player.hideNavigationArrow();
			if (isAuto && player.CharPathFinder.IsMovement)
			{
				player.CharPathFinder.Stop();
			}
		}
	}

	public void CutScenePlayEndEvent(string cutSceneName)
	{
		ProcessEvent();
		if (!isAuto)
		{
			player.showNavigationArrow();
		}
	}

	public void NpcTalkEndEvent()
	{
		ProcessEvent();
	}

	public void SetNevArrowPos(Vector3 targetPos)
	{
		if (!(targetPos == Vector3.zero))
		{
			MQuests quest = QuestSession.Quest;
			if (quest != null && (quest.Id == 5 || quest.Id == 8 || quest.Id == 11 || quest.Id == 14 || quest.Id == 17 || quest.Id == 20))
			{
				player.setNavigationArrowTarget(new GameObject().transform, targetPos);
			}
		}
	}

	public virtual void eventBattleStart()
	{
		if (player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
		player.hideNavigationArrow();
		if (isAuto)
		{
			player.AutoBattle.enabled = true;
		}
	}

	public virtual void eventBattleEnd()
	{
		if (!isAuto)
		{
			player.showNavigationArrow();
		}
	}

	public virtual void eventBattleComplete()
	{
		if (isAuto)
		{
			player.AutoBattle.enabled = false;
		}
		ProcessEvent();
	}

	public virtual void eventPlayerEnabled(PlayerControl player)
	{
	}

	public virtual void eventPlayerDisabled(PlayerControl player)
	{
	}

	public virtual void eventPoppetSet(PlayerControl player, MerlinActionControl[] poppets)
	{
	}

	public virtual void eventPlayerDamage(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDamage(MerlinActionControl monster)
	{
	}

	public virtual void eventPlayerDown(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDown(MerlinActionControl monster)
	{
	}

	public virtual void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		if (player.CharPathFinder.IsMovement)
		{
			player.CharPathFinder.Stop();
		}
	}

	public virtual void eventRevive(MerlinActionControl poppet)
	{
	}

	public virtual void eventChain(MerlinActionControl poppet)
	{
	}

	public virtual void eventMagicCharge(MerlinActionControl poppet)
	{
	}

	public virtual void eventBossStart(MerlinActionControl boss)
	{
	}

	public virtual void eventBossEnd(MerlinActionControl boss)
	{
	}

	public virtual void eventPoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage)
	{
	}

	public virtual void eventPlayerDead(PlayerControl player)
	{
	}

	public virtual void eventBox()
	{
	}

	public virtual void eventBoxGet()
	{
	}

	public virtual void eventCandy()
	{
	}

	public virtual void eventCandyGet()
	{
	}

	public virtual void eventToDemon()
	{
	}

	public virtual void eventToAngel()
	{
	}

	public virtual void eventResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker)
	{
	}

	public virtual void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
	}

	public virtual void eventQuestStart(PlayerControl player)
	{
	}

	public virtual void eventQuestRestart(PlayerControl player)
	{
	}

	public virtual void eventQuestEnd(PlayerControl player)
	{
	}

	public virtual void eventPause()
	{
	}

	public virtual void eventUnpause()
	{
	}

	public virtual void eventJumpStart()
	{
	}

	public virtual void eventJumpEnd()
	{
	}
}
