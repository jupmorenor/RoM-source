using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class AIControl : MerlinActionControl
{
	[Serializable]
	private enum TargetRingTypes
	{
		None,
		QuestPoppet,
		ColosseumPlayer,
		ColosseumOpponent
	}

	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00241129;

		public string _0024act_0024t_00241130;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241131;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241132;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241133;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241134;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241135;

		public __ActionBase__0024act_0024t_00241131_0024callable45_0024524_5__ _0024act_0024t_00241136;

		public __ActionBase__0024act_0024t_00241137_0024callable46_0024524_5__ _0024act_0024t_00241137;

		public IEnumerator _0024act_0024t_00241141;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00241129.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassAIMODE_Wait : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAIMODE_Stop : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAIMODE_Renkei : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAIMODE_ChasePlayer : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAIMODE_Battle : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		AIMODE_Battle,
		AIMODE_ChasePlayer,
		AIMODE_Renkei,
		AIMODE_Stop,
		AIMODE_Wait,
		NUM,
		_noaction_
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024getMasterPlayer_002416629 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pl_002416630;

			internal AIControl _0024self__002416631;

			public _0024(AIControl self_)
			{
				_0024self__002416631 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002416630 = PlayerControl.CurrentPlayer;
					goto case 3;
				case 3:
					if (!_0024pl_002416630.IsReady)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002416631.playerObj = _0024pl_002416630.gameObject;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AIControl _0024self__002416632;

		public _0024getMasterPlayer_002416629(AIControl self_)
		{
			_0024self__002416632 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416632);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024createDataAIMODE_ChasePlayer_0024closure_00243710_002416633 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pl_002416634;

			internal Vector3 _0024r_002416635;

			internal float _0024d_002416636;

			internal Vector3 _0024ppos_002416637;

			internal Vector3 _0024tpos_002416638;

			internal Vector3 _0024v_002416639;

			internal float _0024_0024wait_sec_0024temp_00241150_002416640;

			internal AIControl _0024self__002416641;

			public _0024(AIControl self_)
			{
				_0024self__002416641 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(PlayerControl.CurrentPlayer != null))
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024pl_002416634 = PlayerControl.CurrentPlayer;
					goto IL_0054;
				case 3:
					if (!(_0024d_002416636 <= 3f) && _0024pl_002416634 != null)
					{
						_0024ppos_002416637 = _0024pl_002416634.transform.position;
						_0024tpos_002416638 = _0024ppos_002416637 + _0024r_002416635;
						_0024v_002416639 = _0024tpos_002416638 - _0024self__002416641.transform.position;
						_0024d_002416636 = Mathf.Min(_0024v_002416639.magnitude, (_0024ppos_002416637 - _0024self__002416641.transform.position).magnitude);
						_0024self__002416641.inputMoveToPos(_0024tpos_002416638);
						_0024self__002416641.FaceMovementDirection(_0024v_002416639);
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto case 4;
				case 4:
					if (!(_0024d_002416636 >= 4f) && _0024pl_002416634 != null)
					{
						_0024d_002416636 = (_0024pl_002416634.transform.position - _0024self__002416641.transform.position).magnitude;
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					_0024_0024wait_sec_0024temp_00241150_002416640 = UnityEngine.Random.Range(0.5f, 4f);
					goto case 5;
				case 5:
					if (_0024_0024wait_sec_0024temp_00241150_002416640 > 0f)
					{
						_0024_0024wait_sec_0024temp_00241150_002416640 -= Time.deltaTime;
						result = (YieldDefault(5) ? 1 : 0);
						break;
					}
					goto IL_0054;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0054:
					_0024r_002416635 = _0024self__002416641.RANDXZ * 3f;
					_0024d_002416636 = float.MaxValue;
					goto case 3;
				}
				return (byte)result != 0;
			}
		}

		internal AIControl _0024self__002416642;

		public _0024_0024createDataAIMODE_ChasePlayer_0024closure_00243710_002416633(AIControl self_)
		{
			_0024self__002416642 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002416642);
		}
	}

	[NonSerialized]
	private static readonly string PLAYER_CHAR_TAG = "Player";

	[NonSerialized]
	private static readonly string ENEMY_CHAR_TAG = "Enemy";

	[NonSerialized]
	private static readonly string PLAYER_ATTACK_LAYER = "PlayerAttackColi";

	[NonSerialized]
	private static readonly string ENEMY_ATTACK_LAYER = "EnemyAttackColi";

	[NonSerialized]
	private static readonly string PLAYER_YARARE_LAYER = "PlayerYarareColi";

	[NonSerialized]
	private static readonly string ENEMY_YARARE_LAYER = "EnemyYarareColi";

	private MagicSkill magicSkillComponent;

	public __DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ deadCallback;

	public bool hideLockonBlinkAndRing;

	public float moveSpeed;

	private float atkMoveScale;

	private Vector3 movement;

	private bool forceShowMiniGauge;

	protected GameObject targetPlayer;

	private BaseControl _targetPlayerControl;

	public UISlider hitPointBar;

	public UISlicedSprite hitPointBarColor;

	private Color initHitPointBarColor;

	private bool isPlayer;

	private bool isRaidBoss;

	public Collider coliYarare;

	[NonSerialized]
	protected const float REVIVE_TIME = 20f;

	private float deadTime;

	public float playerAttackRange;

	public float playerRunAttackRange;

	public float rotationSpeed;

	public GameObject stateChangeArea;

	private GameObject playerObj;

	private Transform myTransform;

	private bool deadActionPlayed;

	public Vector3 targetRingScale;

	public bool rareMonster;

	public AttachText rareMonsterExistTime;

	private D540ScriptRunner aiProgram;

	[NonSerialized]
	private static int debugSerialIDSrc = 1;

	public int debugSerialID;

	private AIControlEffectCache chainEffectCache;

	private bool notDead;

	private bool disableFaceMovement;

	private bool destroyIfKilled;

	private bool monsterKillingMode;

	private bool monsterKillingNoDrop;

	private bool monsterKillingNoDestroy;

	private TargetRingStar targetRingStar;

	private TargetRingTypes targetRingType;

	private bool enableTargetRingStar;

	public float attack_length;

	private Dictionary<string, ActionBase> _0024act_0024t_00241138;

	private Dictionary<string, ActionEnum> _0024act_0024t_00241140;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00241139;

	public bool actionDebugFlag;

	private RespWeapon poppetWeapon;

	public override PlayerAnimationTypes AnimationTypeIdle
	{
		get
		{
			PlayerAnimationTypes result = PlayerAnimationTypes.Idle;
			if (!IsAIMODE_Battle)
			{
				PlayerAnimationTypes playerAnimationTypes = PlayerAnimationTypes.EvIdle;
				if (Mmpc != null && Mmpc.hasEntry((int)playerAnimationTypes))
				{
					result = playerAnimationTypes;
				}
			}
			return result;
		}
	}

	public string ElementMainIcon
	{
		get
		{
			RespMonster respMonster = MonsterData;
			return (respMonster == null) ? string.Empty : respMonster.ElementMainIcon;
		}
	}

	public MagicSkill MagicSkillComponent => magicSkillComponent;

	public float AtkMoveScale
	{
		get
		{
			return atkMoveScale;
		}
		set
		{
			atkMoveScale = value;
		}
	}

	public BaseControl targetPlayerControl
	{
		get
		{
			return _targetPlayerControl;
		}
		set
		{
			_targetPlayerControl = value;
			targetPlayer = ((!(value != null)) ? null : value.gameObject);
		}
	}

	public override GameObject TargetChar => targetPlayer;

	public bool IsAIMODE_Wait => currActionID("AIMODE") == ActionEnum.AIMODE_Wait;

	public float actionTimeAIMODE => currActionTime("AIMODE");

	public ActionClassAIMODE_Wait AIMODE_WaitData => currAction("AIMODE") as ActionClassAIMODE_Wait;

	public bool IsAIMODE_Stop => currActionID("AIMODE") == ActionEnum.AIMODE_Stop;

	public ActionClassAIMODE_Stop AIMODE_StopData => currAction("AIMODE") as ActionClassAIMODE_Stop;

	public bool IsAIMODE_Renkei => currActionID("AIMODE") == ActionEnum.AIMODE_Renkei;

	public ActionClassAIMODE_Renkei AIMODE_RenkeiData => currAction("AIMODE") as ActionClassAIMODE_Renkei;

	public bool IsAIMODE_ChasePlayer => currActionID("AIMODE") == ActionEnum.AIMODE_ChasePlayer;

	public ActionClassAIMODE_ChasePlayer AIMODE_ChasePlayerData => currAction("AIMODE") as ActionClassAIMODE_ChasePlayer;

	public bool IsAIMODE_Battle => currActionID("AIMODE") == ActionEnum.AIMODE_Battle;

	public ActionClassAIMODE_Battle AIMODE_BattleData => currAction("AIMODE") as ActionClassAIMODE_Battle;

	public float DIST_TARGET
	{
		get
		{
			float result;
			if (targetPlayerControl == null)
			{
				result = float.MaxValue;
			}
			else
			{
				Vector3 position = targetPlayerControl.transform.position;
				movement = position - myTransform.position;
				movement.y = 0f;
				result = movement.magnitude;
			}
			return result;
		}
	}

	public EnumRares MY_RARE
	{
		get
		{
			int result;
			if (!HasMonsterData)
			{
				result = ((!HasPoppetData) ? 1 : PoppetData.Rare.Id);
			}
			else
			{
				int masterId = MonsterData.MasterId;
				MPoppets mPoppets = MPoppets.Get(masterId);
				result = (int)(EnumRares)((mPoppets == null) ? ((object)EnumRares.normal) : ((object)mPoppets.Rare.Id));
			}
			return (EnumRares)result;
		}
	}

	public bool ForceShowMiniGauge
	{
		get
		{
			return forceShowMiniGauge;
		}
		set
		{
			forceShowMiniGauge = value;
		}
	}

	public override bool IsPlayer => isPlayer;

	public D540ScriptRunner AIProgram => aiProgram;

	public AIControlEffectCache ChainEffectCache => chainEffectCache;

	public bool NotDead
	{
		get
		{
			return notDead;
		}
		set
		{
			notDead = value;
		}
	}

	public bool DisableFaceMovement
	{
		get
		{
			return disableFaceMovement;
		}
		set
		{
			disableFaceMovement = value;
		}
	}

	public bool DestroyIfKilled
	{
		get
		{
			return destroyIfKilled;
		}
		set
		{
			destroyIfKilled = value;
		}
	}

	public bool MonsterKillingMode
	{
		get
		{
			return monsterKillingMode;
		}
		set
		{
			monsterKillingMode = value;
		}
	}

	public bool MonsterKillingNoDrop
	{
		get
		{
			return monsterKillingNoDrop;
		}
		set
		{
			monsterKillingNoDrop = value;
		}
	}

	public bool MonsterKillingHide
	{
		get
		{
			return monsterKillingNoDestroy;
		}
		set
		{
			monsterKillingNoDestroy = value;
		}
	}

	public AIControl()
	{
		moveSpeed = 5f;
		atkMoveScale = 1f;
		playerAttackRange = 2.5f;
		playerRunAttackRange = 5f;
		rotationSpeed = 360f;
		targetRingScale = new Vector3(6f, 6f, 6f);
		destroyIfKilled = true;
		targetRingType = TargetRingTypes.QuestPoppet;
		enableTargetRingStar = true;
		attack_length = 5f;
		_0024act_0024t_00241138 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00241140 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public void disableTargetRingStar()
	{
		if (targetRingStar != null)
		{
			UnityEngine.Object.Destroy(targetRingStar.gameObject);
		}
		enableTargetRingStar = false;
	}

	public void loadTargetRingStar(TargetRingTypes type)
	{
		if ((type == TargetRingTypes.None && targetRingStar == null) || (type == targetRingType && targetRingStar != null) || !enableTargetRingStar)
		{
			return;
		}
		disposeTargetRing();
		string text = string.Empty;
		switch (type)
		{
		case TargetRingTypes.QuestPoppet:
			text = "Prefab/GUI/TargetringStar";
			break;
		case TargetRingTypes.ColosseumPlayer:
			text = "Prefab/GUI/TargetringStarMapet";
			break;
		case TargetRingTypes.ColosseumOpponent:
			text = "Prefab/GUI/TargetringStarEnemy";
			break;
		}
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		GameObject gameObject = GameAssetModule.InstantiatePrefab(text);
		if (gameObject != null)
		{
			TargetRingStar component = default(TargetRingStar);
			if ((bool)gameObject)
			{
				component = gameObject.GetComponent<TargetRingStar>();
			}
			if (component != null)
			{
				component.StartLockOn(this.gameObject);
				targetRingStar = component;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		targetRingType = type;
	}

	private void disposeTargetRing()
	{
		targetRingType = TargetRingTypes.None;
		if (targetRingStar != null)
		{
			UnityEngine.Object.Destroy(targetRingStar.gameObject);
			targetRingStar = null;
		}
	}

	public void aiProgramOn()
	{
		if (aiProgram != null)
		{
			aiProgram.EnabledUpdate = true;
		}
	}

	public void aiProgramOff()
	{
		if (aiProgram != null)
		{
			aiProgram.EnabledUpdate = false;
		}
	}

	public void activateAiProgramComponent(bool b)
	{
		if (aiProgram != null)
		{
			aiProgram.enabled = b;
		}
	}

	public override void Start()
	{
		debugSerialID = checked(++debugSerialIDSrc);
		base.Start();
		if (gameObject.tag == PLAYER_CHAR_TAG)
		{
			IEnumerator masterPlayer = getMasterPlayer();
			if (masterPlayer != null)
			{
				StartCoroutine(masterPlayer);
			}
			loadTargetRingStar(targetRingType);
		}
		IkariLevelChanged += ikariChanged;
		setupSkillEffectControl();
	}

	public override void OnEnable()
	{
		base.OnEnable();
		if (targetRingStar != null)
		{
			targetRingStar.gameObject.SetActive(value: true);
		}
	}

	public override void OnDisable()
	{
		base.OnDisable();
		if (targetRingStar != null)
		{
			targetRingStar.gameObject.SetActive(value: false);
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		disposeTargetRing();
		_targetPlayerControl = null;
		hitPointBar = null;
		hitPointBarColor = null;
		coliYarare = null;
		stateChangeArea = null;
		playerObj = null;
		myTransform = null;
		aiProgram = null;
		chainEffectCache = null;
	}

	public void cacheChainEffect()
	{
		chainEffectCache.startCacheChainEffect();
	}

	private IEnumerator getMasterPlayer()
	{
		return new _0024getMasterPlayer_002416629(this).GetEnumerator();
	}

	private void ikariChanged(MerlinActionControl me, int level)
	{
		MMonsters monsterMaster = MonsterMaster;
		if (monsterMaster != null)
		{
			PlayerAnimationTypes playerAnimationTypes = MerlinActionEnumsModule.YarareTypeToAnimationType(monsterMaster.ikariYarare(level));
			if (playerAnimationTypes >= PlayerAnimationTypes.Idle)
			{
				playAnimation(playerAnimationTypes);
			}
			float num = monsterMaster.ikariMotSpeed(level);
			if (!(num <= 0f))
			{
				MotionSpeedScale = num;
			}
		}
	}

	public override void Awake()
	{
		ActionSettings.defaultRotationSpeed = rotationSpeed;
		base.Awake();
		setSetupTypeMonster();
		aiProgram = GetComponent<D540ScriptRunner>();
		magicSkillComponent = GetComponent<MagicSkill>();
		if (!(DefaultMoveSpeed > 0f))
		{
			DefaultMoveSpeed = moveSpeed;
		}
		setHitPointMax();
		playAnimationByType(PlayerAnimationTypes.Idle);
		if ((bool)hitPointBarColor)
		{
			initHitPointBarColor = hitPointBarColor.color;
		}
		DrawHitPoint();
		if (gameObject.tag == PLAYER_CHAR_TAG)
		{
			isPlayer = true;
		}
		else
		{
			isPlayer = false;
		}
		if (GetComponent<PhotonBoss>() != null)
		{
			isRaidBoss = true;
		}
		else
		{
			isRaidBoss = false;
		}
		myTransform = transform;
		initYarareLayer(isPlayer);
		setAttackSide(isPlayer, force: true);
		EnableIkariMode = true;
		chainEffectCache = ExtensionsModule.SetComponent<AIControlEffectCache>(gameObject);
		if (!(chainEffectCache != null))
		{
			throw new AssertionFailedException("chainEffectCache != null");
		}
		AIMODE_Wait();
	}

	public override void Update()
	{
		if (RuntimeDebugMode.Instance.IsInDebugMode || Pause)
		{
			return;
		}
		base.Update();
		if (enabled)
		{
			try
			{
				actUpdate();
			}
			catch (Exception)
			{
			}
			float deltaTime = Time.deltaTime;
			abnormalStateControl.update(deltaTime);
			updateSkillEffectControl(deltaTime);
			if (IsColosseumSetup)
			{
				updateInAreaState(deltaTime);
			}
		}
	}

	public override void LateUpdate()
	{
		if (!RuntimeDebugMode.Instance.IsInDebugMode && !Pause)
		{
			base.LateUpdate();
			actLateUpdate();
		}
	}

	public override void FixedUpdate()
	{
		if (!RuntimeDebugMode.Instance.IsInDebugMode && !Pause)
		{
			actFixedUpdate();
			base.FixedUpdate();
		}
	}

	private void reviveSub()
	{
		deadActionPlayed = false;
		deadTime = 0f;
		HitPoint = MaxHitPoint;
		if ((bool)hitPointBarColor)
		{
			hitPointBarColor.color = initHitPointBarColor;
		}
		if (Mmpc != null)
		{
			Mmpc.TimeScale = 1f;
			CommandBlockMode = false;
			playAnimationByType(PlayerAnimationTypes.Idle);
			aiProgramOn();
			DrawHitPoint();
			setBodyStartLayer();
			if (isPlayer)
			{
				showHPMiniBar();
			}
			resetAbnormalState();
		}
	}

	public void forceToRevive()
	{
		bool flag = false;
		reviveSub();
	}

	public void Revive()
	{
		bool isDead = IsDead;
		reviveSub();
		if (isDead)
		{
			PlayerEventDispatcher.InvokeRevive(this);
		}
	}

	private void FaceMovementDirection()
	{
		Vector3 vector = movement;
		vector.y = 0f;
		if (!((double)vector.magnitude <= 0.1) && IS_ANIM_RUN)
		{
			FaceMovementDirection(vector.normalized);
		}
	}

	private void FaceMovementDirection(Vector3 dir)
	{
		if (dir.magnitude > 0.001f && !IsMonsterBlindedAbnormalState && !DisableFaceMovement)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
		}
	}

	private void SearchTargetPlayer()
	{
		SearchTargetPlayer(isPlayer);
	}

	private void SearchTargetPlayer(bool is_player)
	{
		BaseControl baseControl = targetPlayerControl;
		string text = TargetCharTag(is_player);
		if (baseControl != null && !(baseControl.HitPoint <= 0f) && baseControl.tag == text)
		{
			return;
		}
		Vector3 position = transform.position;
		BaseControl baseControl2 = null;
		float num = float.MaxValue;
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		for (int length = allControls.Length; i < length; i = checked(i + 1))
		{
			if (!(allControls[i].gameObject.tag != text) && allControls[i].HitPoint > 0f)
			{
				float magnitude = (allControls[i].transform.position - position).magnitude;
				if (!(num <= magnitude))
				{
					num = magnitude;
					baseControl2 = allControls[i];
				}
			}
		}
		targetPlayerControl = baseControl2;
	}

	public override void decHP(float damage)
	{
		if (damage == 0f)
		{
			return;
		}
		HitPoint = Mathf.Max(HitPoint - damage, 0f);
		if (notDead)
		{
			HitPoint = Mathf.Max(1f, HitPoint);
		}
		DrawHitPoint();
		if (GameParameter.notDeadPoppet && isPlayer)
		{
			HitPoint = Mathf.Max(1f, HitPoint);
		}
		if (GameParameter.notDeadMonster && !isPlayer)
		{
			HitPoint = Mathf.Max(1f, HitPoint);
		}
		if (!(HitPoint > 0f))
		{
			if ((bool)rareMonsterExistTime)
			{
				rareMonsterExistTime.hide();
			}
			kill();
		}
	}

	public override void HitAttack(int damage, YarareTypes yarare, GameObject attackChar)
	{
		if ((bool)attackChar)
		{
			attackChar.SendMessage("raidAttackHit", gameObject, SendMessageOptions.DontRequireReceiver);
		}
		if ((bool)attackChar)
		{
			attackChar.SendMessage("raidAttackHitWithDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		if (GameParameter.oneHitKill)
		{
			damage = checked((int)MaxHitPoint);
		}
		decHP(damage);
		if (!isRaidBoss && !hideLockonBlinkAndRing)
		{
			showHPMiniBar();
		}
		if (IsAlive)
		{
			switch (yarare)
			{
			case YarareTypes.Weak:
				playAnimationByType(PlayerAnimationTypes.YarareWeak);
				break;
			default:
				playAnimationByType(PlayerAnimationTypes.YarareDown);
				break;
			case YarareTypes.None:
				break;
			}
			if (attackChar != null)
			{
				targetPlayerControl = attackChar.GetComponent<BaseControl>();
			}
			else
			{
				SearchTargetPlayer();
			}
		}
	}

	public void showHPMiniBar()
	{
		if (!TargetHitPointBarMini.ExistsOne || (!QuestBattleStarter.IsPlaying && !forceShowMiniGauge))
		{
			return;
		}
		if (TutorialEvent.IsRaidTutorialNow())
		{
			string text = gameObject.name.Replace("(Clone)", string.Empty);
			if (text.EndsWith("E5001_E00_MA_ROOT"))
			{
				return;
			}
			int i = 0;
			string[] rAID_PLAYER_NAMES = TutorialEvent.RAID_PLAYER_NAMES;
			for (int length = rAID_PLAYER_NAMES.Length; i < length; i = checked(i + 1))
			{
				if (rAID_PLAYER_NAMES[i].EndsWith(text))
				{
					return;
				}
			}
		}
		if (isPlayer)
		{
			TargetHitPointBarMini.setTargetForPoppet(transform);
		}
		else
		{
			TargetHitPointBarMini.setTarget(transform);
		}
	}

	private void DrawHitPoint()
	{
		if (!(hitPointBar == null))
		{
			if (IS_ANIM_YARARE_DEAD)
			{
				hitPointBar.sliderValue = deadTime / 20f;
			}
			else
			{
				hitPointBar.sliderValue = HitPoint / MaxHitPoint;
			}
		}
	}

	public void activateYarareColi(bool b)
	{
		if (coliYarare != null)
		{
			coliYarare.gameObject.SetActive(!b);
			coliYarare.gameObject.SetActive(b);
		}
		activateMmpcSetColiYarare(b);
	}

	public void kill()
	{
		noDamage = false;
		HitPoint = 0f;
		resetAbnormalState();
		CommandBlockMode = false;
		resetMotionSpeedScale();
		playAnimationByType(PlayerAnimationTypes.YarareDead);
		CommandBlockMode = true;
		aiProgramOff();
	}

	protected override void doForceToIdle()
	{
		aiProgramOn();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00241138.ContainsKey(grp)) ? null : _0024act_0024t_00241138[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00241140.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00241140[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00241138.ContainsKey(grp)) ? 0f : _0024act_0024t_00241138[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00241138.ContainsKey(grp)) ? 0f : _0024act_0024t_00241138[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00241138.ContainsKey(grp)) ? 0f : _0024act_0024t_00241138[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00241140.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00241130) && _0024act_0024t_00241138.ContainsKey(act._0024act_0024t_00241130) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00241138[act._0024act_0024t_00241130]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.AIMODE_Battle <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_00241130))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$1130)");
			}
			_0024act_0024t_00241138[act._0024act_0024t_00241130] = act;
			_0024act_0024t_00241140[act._0024act_0024t_00241130] = act._0024act_0024t_00241129;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00241139) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00241130);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00241130)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00241130)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00241132 != null)
		{
			actionBase._0024act_0024t_00241132(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00241131 != null)
			{
				act._0024act_0024t_00241131(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00241137 != null)
			{
				act._0024act_0024t_00241141 = act._0024act_0024t_00241137(act);
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
		foreach (ActionBase value in _0024act_0024t_00241138.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241139 = 0;
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
			if (actionBase._0024act_0024t_00241133 != null)
			{
				actionBase._0024act_0024t_00241133(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00241141 != null && !actionBase._0024act_0024t_00241141.MoveNext())
			{
				actionBase._0024act_0024t_00241141 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00241138.Values)
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
		_0024act_0024t_00241139 = 0;
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
			if (actionBase._0024act_0024t_00241134 != null)
			{
				actionBase._0024act_0024t_00241134(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00241139 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241138.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00241138[array2[i]];
				if (actionBase._0024act_0024t_00241135 != null)
				{
					actionBase._0024act_0024t_00241135(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00241138.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00241130 + " - " + value._0024act_0024t_00241129 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00241139 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241138.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00241138[array2[i]];
			if (actionBase._0024act_0024t_00241136 != null)
			{
				actionBase._0024act_0024t_00241136(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "AIControl" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.AIMODE_Wait => createDataAIMODE_Wait(), 
			ActionEnum.AIMODE_Stop => createDataAIMODE_Stop(), 
			ActionEnum.AIMODE_Renkei => createDataAIMODE_Renkei(), 
			ActionEnum.AIMODE_ChasePlayer => createDataAIMODE_ChasePlayer(), 
			ActionEnum.AIMODE_Battle => createDataAIMODE_Battle(), 
			_ => null, 
		};
	}

	public ActionClassAIMODE_Wait AIMODE_Wait()
	{
		ActionClassAIMODE_Wait actionClassAIMODE_Wait = createAIMODE_Wait();
		changeAction(actionClassAIMODE_Wait);
		return actionClassAIMODE_Wait;
	}

	public ActionClassAIMODE_Wait createDataAIMODE_Wait()
	{
		ActionClassAIMODE_Wait actionClassAIMODE_Wait = new ActionClassAIMODE_Wait();
		actionClassAIMODE_Wait._0024act_0024t_00241129 = ActionEnum.AIMODE_Wait;
		actionClassAIMODE_Wait._0024act_0024t_00241130 = "AIMODE";
		actionClassAIMODE_Wait._0024act_0024t_00241131 = _0024adaptor_0024__AIControl_0024callable313_0024524_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024116.Adapt(delegate
		{
			enableAllMovementTypes();
			aiProgramOff();
		});
		actionClassAIMODE_Wait._0024act_0024t_00241134 = _0024adaptor_0024__AIControl_0024callable313_0024524_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024116.Adapt(delegate
		{
			FixedUpdateBattle();
		});
		actionClassAIMODE_Wait._0024act_0024t_00241133 = _0024adaptor_0024__AIControl_0024callable313_0024524_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024116.Adapt(delegate(ActionClassAIMODE_Wait _0024act_0024t_00241128)
		{
			if (!(_0024act_0024t_00241128.actionFrame < 45f))
			{
				AIMODE_Battle();
			}
		});
		return actionClassAIMODE_Wait;
	}

	public ActionClassAIMODE_Wait createAIMODE_Wait()
	{
		return createDataAIMODE_Wait();
	}

	public bool IsAIMODEAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00241138.ContainsKey("AIMODE"))
		{
			ActionBase actionBase = _0024act_0024t_00241138["AIMODE"];
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

	public ActionClassAIMODE_Stop AIMODE_Stop()
	{
		ActionClassAIMODE_Stop actionClassAIMODE_Stop = createAIMODE_Stop();
		changeAction(actionClassAIMODE_Stop);
		return actionClassAIMODE_Stop;
	}

	public ActionClassAIMODE_Stop createDataAIMODE_Stop()
	{
		ActionClassAIMODE_Stop actionClassAIMODE_Stop = new ActionClassAIMODE_Stop();
		actionClassAIMODE_Stop._0024act_0024t_00241129 = ActionEnum.AIMODE_Stop;
		actionClassAIMODE_Stop._0024act_0024t_00241130 = "AIMODE";
		actionClassAIMODE_Stop._0024act_0024t_00241131 = _0024adaptor_0024__AIControl_0024callable314_0024534_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024117.Adapt(delegate
		{
			disableAllMovementTypesWithoutMotionMove();
			aiProgramOff();
		});
		actionClassAIMODE_Stop._0024act_0024t_00241133 = _0024adaptor_0024__AIControl_0024callable314_0024534_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024117.Adapt(delegate
		{
			Mmpc.TimeScale = 0f;
		});
		return actionClassAIMODE_Stop;
	}

	public ActionClassAIMODE_Stop createAIMODE_Stop()
	{
		return createDataAIMODE_Stop();
	}

	public ActionClassAIMODE_Renkei AIMODE_Renkei()
	{
		ActionClassAIMODE_Renkei actionClassAIMODE_Renkei = createAIMODE_Renkei();
		changeAction(actionClassAIMODE_Renkei);
		return actionClassAIMODE_Renkei;
	}

	public ActionClassAIMODE_Renkei createDataAIMODE_Renkei()
	{
		ActionClassAIMODE_Renkei actionClassAIMODE_Renkei = new ActionClassAIMODE_Renkei();
		actionClassAIMODE_Renkei._0024act_0024t_00241129 = ActionEnum.AIMODE_Renkei;
		actionClassAIMODE_Renkei._0024act_0024t_00241130 = "AIMODE";
		actionClassAIMODE_Renkei._0024act_0024t_00241131 = _0024adaptor_0024__AIControl_0024callable315_0024543_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024118.Adapt(delegate
		{
			Mmpc.TimeScale = 1f;
			disableAllMovementTypesWithoutMotionMove();
			aiProgramOff();
		});
		actionClassAIMODE_Renkei._0024act_0024t_00241134 = _0024adaptor_0024__AIControl_0024callable315_0024543_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024118.Adapt(delegate
		{
			FixedUpdateRenkei();
		});
		return actionClassAIMODE_Renkei;
	}

	public ActionClassAIMODE_Renkei createAIMODE_Renkei()
	{
		return createDataAIMODE_Renkei();
	}

	public ActionClassAIMODE_ChasePlayer AIMODE_ChasePlayer()
	{
		ActionClassAIMODE_ChasePlayer actionClassAIMODE_ChasePlayer = createAIMODE_ChasePlayer();
		changeAction(actionClassAIMODE_ChasePlayer);
		return actionClassAIMODE_ChasePlayer;
	}

	public ActionClassAIMODE_ChasePlayer createDataAIMODE_ChasePlayer()
	{
		ActionClassAIMODE_ChasePlayer actionClassAIMODE_ChasePlayer = new ActionClassAIMODE_ChasePlayer();
		actionClassAIMODE_ChasePlayer._0024act_0024t_00241129 = ActionEnum.AIMODE_ChasePlayer;
		actionClassAIMODE_ChasePlayer._0024act_0024t_00241130 = "AIMODE";
		actionClassAIMODE_ChasePlayer._0024act_0024t_00241131 = _0024adaptor_0024__AIControl_0024callable316_0024551_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024119.Adapt(delegate
		{
			Mmpc.TimeScale = 1f;
			enableAllMovementTypes();
			aiProgramOff();
		});
		actionClassAIMODE_ChasePlayer._0024act_0024t_00241137 = _0024adaptor_0024__AIControl_0024callable317_0024551_5___0024__ActionBase__0024act_0024t_00241137_0024callable46_0024524_5___0024120.Adapt((ActionClassAIMODE_ChasePlayer _0024act_0024t_00241151) => new _0024_0024createDataAIMODE_ChasePlayer_0024closure_00243710_002416633(this).GetEnumerator());
		return actionClassAIMODE_ChasePlayer;
	}

	public ActionClassAIMODE_ChasePlayer createAIMODE_ChasePlayer()
	{
		return createDataAIMODE_ChasePlayer();
	}

	public ActionClassAIMODE_Battle AIMODE_Battle()
	{
		ActionClassAIMODE_Battle actionClassAIMODE_Battle = createAIMODE_Battle();
		changeAction(actionClassAIMODE_Battle);
		return actionClassAIMODE_Battle;
	}

	public ActionClassAIMODE_Battle createDataAIMODE_Battle()
	{
		ActionClassAIMODE_Battle actionClassAIMODE_Battle = new ActionClassAIMODE_Battle();
		actionClassAIMODE_Battle._0024act_0024t_00241129 = ActionEnum.AIMODE_Battle;
		actionClassAIMODE_Battle._0024act_0024t_00241130 = "AIMODE";
		actionClassAIMODE_Battle._0024act_0024t_00241131 = _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121.Adapt(delegate
		{
			Mmpc.TimeScale = 1f;
			enableAllMovementTypes();
			aiProgramOn();
		});
		actionClassAIMODE_Battle._0024act_0024t_00241134 = _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121.Adapt(delegate
		{
			FixedUpdateBattle();
		});
		actionClassAIMODE_Battle._0024act_0024t_00241133 = _0024adaptor_0024__AIControl_0024callable318_0024582_5___0024__ActionBase__0024act_0024t_00241131_0024callable45_0024524_5___0024121.Adapt(delegate
		{
			try
			{
				SearchTargetPlayer();
			}
			catch (Exception)
			{
			}
			if (IS_ANIM_YARARE_DEAD)
			{
				if ((bool)hitPointBarColor)
				{
					hitPointBarColor.color = Color.gray;
				}
				if (IS_END_OF_MOTION && !deadActionPlayed)
				{
					deadAction();
				}
			}
		});
		return actionClassAIMODE_Battle;
	}

	public ActionClassAIMODE_Battle createAIMODE_Battle()
	{
		return createDataAIMODE_Battle();
	}

	public void instantiateDeadSmoke()
	{
		QuestAssets.Instance.instantiateDeadSmoke(transform.position, transform.rotation);
	}

	private void deadAction()
	{
		deadActionPlayed = true;
		tag = gameObject.tag;
		if (tag == ENEMY_CHAR_TAG || monsterKillingMode)
		{
			if (DestroyIfKilled)
			{
				instantiateDeadSmoke();
			}
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if (instance != null)
			{
				instance.PlaySe(667, 0, gameObject.GetInstanceID());
			}
			if (!monsterKillingNoDrop)
			{
				drop();
			}
			if (deadCallback != null)
			{
				deadCallback(this);
			}
			if (monsterKillingNoDestroy)
			{
				gameObject.SetActive(value: false);
			}
			else if (DestroyIfKilled)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		else if (tag == PLAYER_CHAR_TAG)
		{
			setBodyLayerNoPushOut();
			playSE(SQEX_SoundPlayerData.SE.pet_dead);
		}
		else if (SceneChanger.CurrentSceneName.ToLower().StartsWith("raid"))
		{
			instantiateDeadSmoke();
			if (DestroyIfKilled)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	private void drop()
	{
		RespSimpleReward[] array = MonsterData.Rewards;
		if (array == null)
		{
			array = new RespSimpleReward[0];
		}
		try
		{
			RespSimpleReward[] array2 = Gen_array_macrosModule.GenArray<RespSimpleReward, RespSimpleReward>(array, (__AIControl_0024callable319_0024648_22__)((RespSimpleReward _0024genarray_00241157) => _0024genarray_00241157), (__ArrayMapMain_FilterRewards_0024callable121_002484_75__)((RespSimpleReward _0024genarray_00241157) => _0024genarray_00241157.IsDrop));
			if (array2.Length > 0)
			{
				RespSimpleReward respSimpleReward = array2[RuntimeServices.NormalizeArrayIndex(array2, UnityEngine.Random.Range(0, array2.Length))];
				if (respSimpleReward.IsKeyItem)
				{
					dropKeyItem(respSimpleReward);
				}
				else if (respSimpleReward.IsSpecialRare)
				{
					dropSpecialRare(respSimpleReward);
				}
				else if (respSimpleReward.IsRare)
				{
					dropRare(respSimpleReward);
				}
				else if (respSimpleReward.IsWeapon || respSimpleReward.IsPoppet)
				{
					dropNormal(respSimpleReward);
				}
				else if (respSimpleReward.IsCandy)
				{
					int nutRateOfMonsterCandy = QuestSession.NutRateOfMonsterCandy;
					if (UnityEngine.Random.Range(0, 100) < nutRateOfMonsterCandy)
					{
						dropNut(respSimpleReward);
					}
					else
					{
						dropCandy(respSimpleReward);
					}
				}
			}
			dropCoin(MonsterData);
			MStageMonsters stageMonsterMaster = MonsterData.StageMonsterMaster;
			if (stageMonsterMaster != null)
			{
				if (stageMonsterMaster.DummyDropLevel > 0)
				{
					dropDummyTreasure(stageMonsterMaster.DummyDropLevel);
				}
				if (stageMonsterMaster.DummyCoin > 0)
				{
					dropDummyCoin(stageMonsterMaster.DummyCoin);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void dropCoin(RespMonster monster)
	{
		if (monster != null)
		{
			dropCoin(monster.RewardCoins, monster.Coin);
		}
	}

	public bool dropCoin(RespSimpleReward[] rewardCoins, int monsterCoin)
	{
		int result;
		checked
		{
			if (!(rewardCoins == null) || monsterCoin > 0)
			{
				int num = 0;
				if (rewardCoins != null)
				{
					int i = 0;
					for (int length = rewardCoins.Length; i < length; i++)
					{
						if (rewardCoins[i].IsCoin)
						{
							num += rewardCoins[i].Quantity;
						}
					}
				}
				num += monsterCoin;
				if (num > 0)
				{
					Ef_Coin_Scatter ef_Coin_Scatter = QuestAssets.Instance.instantiateCoin();
					if (!(ef_Coin_Scatter != null))
					{
						throw new AssertionFailedException("coin != null");
					}
					if ((bool)ef_Coin_Scatter)
					{
						ef_Coin_Scatter.transform.position = transform.position;
						ef_Coin_Scatter.transform.rotation = Quaternion.identity;
						if (rewardCoins != null)
						{
							ef_Coin_Scatter.Rewards = (RespSimpleReward[])Builtins.array(typeof(RespSimpleReward), rewardCoins);
						}
						ef_Coin_Scatter.money = num;
						result = 1;
						goto IL_00eb;
					}
				}
			}
			result = 0;
			goto IL_00eb;
		}
		IL_00eb:
		return (byte)result != 0;
	}

	public bool dropSpecialRare(RespSimpleReward r)
	{
		dropTreasure(QuestAssets.Instance.instantiateTreasureHigh(), new Vector3(0f, 0.5f, 0f), r);
		return true;
	}

	public bool dropRare(RespSimpleReward r)
	{
		dropTreasure(QuestAssets.Instance.instantiateTreasureMid(), new Vector3(0f, 0.5f, 0f), r);
		return true;
	}

	public bool dropNormal(RespSimpleReward r)
	{
		dropTreasure(QuestAssets.Instance.instantiateTreasureLow(), new Vector3(0f, 0.5f, 0f), r);
		return true;
	}

	public void dropKeyItem(RespSimpleReward r)
	{
		QuestKeyItem questKeyItem = QuestAssets.Instance.instantiateKeyItem();
		if (questKeyItem == null)
		{
			QuestSession.GotMonsterReward(r);
			return;
		}
		questKeyItem.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
		questKeyItem.transform.rotation = transform.rotation;
		questKeyItem.add(r);
		questKeyItem.Move(flg: true);
	}

	public bool dropCandy(RespSimpleReward r)
	{
		Vector3 position = transform.position + new Vector3(0f, 0.5f, 0f);
		Quaternion rotation = transform.rotation;
		PotionGet potionGet = QuestAssets.Instance.instantiateCandy(position, rotation);
		int result;
		if (potionGet != null)
		{
			potionGet.add(r);
			PlayerEventDispatcher.InvokeCandy();
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public bool dropNut(RespSimpleReward r)
	{
		NutGet nutGet = QuestAssets.Instance.instantiateNut(transform.position, transform.rotation);
		return nutGet != null;
	}

	public bool dropTreasure(TreasureGet obj, Vector3 ofs, RespSimpleReward r)
	{
		if (!(obj != null))
		{
			throw new AssertionFailedException("obj != null");
		}
		int result;
		if (MonsterData == null)
		{
			if (r != null)
			{
				QuestSession.GotMonsterReward(r);
			}
			result = 0;
		}
		else if (obj != null)
		{
			obj.transform.position = transform.position + ofs;
			obj.transform.rotation = Quaternion.identity;
			if (r != null)
			{
				obj.add(r);
			}
			obj.Move(flg: true);
			PlayerEventDispatcher.InvokeBox();
			result = 1;
		}
		else
		{
			if (r != null)
			{
				QuestSession.GotMonsterReward(r);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public void dropDummyTreasure(int level)
	{
		TreasureGet treasureGet = QuestAssets.Instance.instantiateTreasureByLevel(level);
		if (!(treasureGet == null))
		{
			dropTreasure(treasureGet, new Vector3(0f, 0.5f, 0f), null);
		}
	}

	public void dropDummyCoin(int coin)
	{
		dropCoin(new RespSimpleReward[0], coin);
	}

	public void FixedUpdateStop()
	{
	}

	public void FixedUpdateRenkei()
	{
	}

	public void FixedUpdateBattle()
	{
		if (!IS_ANIM_YARARE_DEAD)
		{
			inAreaStateFixedUpdate();
			Vector3 extraMovement = KnockBack * atkMoveScale;
			extraMovement += InAreaStateExtraMovementOfFixedUpdate;
			setExtraMovement(extraMovement);
			if (!(myTransform.position.y >= -40f))
			{
				standGround(myTransform);
			}
			KnockBack *= 0.5f;
			FaceMovementDirection();
		}
	}

	protected override void doMotionChangedAfter()
	{
		base.doMotionChangedAfter();
		float movementSpeedScaleByAreaDamage = getMovementSpeedScaleByAreaDamage();
		MovementScale *= movementSpeedScaleByAreaDamage;
		Mmpc.BaseMovementScale = movementSpeedScaleByAreaDamage;
	}

	public object[] GetTerrainHeight(Vector3 pos)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		object result;
		if (!activeTerrain)
		{
			pos.y = 0f;
			result = new object[3]
			{
				false,
				0f,
				Vector3.up
			};
		}
		else
		{
			Vector3 vector = pos - activeTerrain.transform.position;
			Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, activeTerrain.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, activeTerrain.terrainData.size.z, vector.z));
			Vector3 interpolatedNormal = activeTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
			float num = activeTerrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + activeTerrain.transform.position.y;
			result = new object[3] { true, num, interpolatedNormal };
		}
		return (object[])result;
	}

	public void HITPOINTBAR_GRAY()
	{
		if ((bool)hitPointBarColor)
		{
			hitPointBarColor.color = Color.gray;
		}
	}

	public void WARP(float time)
	{
		ActionTimerJob cmd = new ActionTimerJob(time, (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			warp();
		});
		addCommand(cmd);
	}

	public void warp()
	{
		int size = Trajectory.size;
		if (size > 0)
		{
			Vector3 position = Trajectory[UnityEngine.Random.Range(0, size)];
			transform.position = position;
		}
	}

	public override string ToString()
	{
		return (!(this == null) && !(gameObject == null)) ? new StringBuilder("AIControl(debugID=").Append((object)debugSerialID).Append(",name=").Append(name)
			.Append(")")
			.ToString() : "AIControl(NULL!!)";
	}

	public static string TargetCharTag(bool is_player)
	{
		return (!is_player) ? PLAYER_CHAR_TAG : ENEMY_CHAR_TAG;
	}

	private string myCharTag(bool is_player)
	{
		return TargetCharTag(!is_player);
	}

	private string attackLayer(bool is_player)
	{
		return (!is_player) ? ENEMY_ATTACK_LAYER : PLAYER_ATTACK_LAYER;
	}

	private string yarareLayer(bool is_player)
	{
		return (!is_player) ? ENEMY_YARARE_LAYER : PLAYER_YARARE_LAYER;
	}

	private void initAttackLayer(bool is_player)
	{
		string text = attackLayer(is_player);
		setAttackLayer(text);
	}

	private void initYarareLayer(bool is_player)
	{
		int num = LayerMask.NameToLayer(yarareLayer(is_player));
		if ((bool)coliYarare)
		{
			coliYarare.gameObject.layer = num;
		}
		setMmpcSetColiYarareLayer(num);
	}

	public void setPlayerSide(bool is_player)
	{
		initLayers(is_player);
		setAttackSide(is_player, force: true);
	}

	public void setPlayerSideAndBodyLayer(bool is_player)
	{
		setPlayerSide(is_player);
		if (is_player)
		{
			setBodyLayerPlayer();
		}
		else
		{
			setBodyLayerEnemy();
		}
	}

	private void initLayers(bool is_player)
	{
		initAttackLayer(is_player);
		initYarareLayer(is_player);
	}

	private void initLayers()
	{
		initLayers(isPlayer);
	}

	public void setAttackSide(bool is_player)
	{
		setAttackSide(is_player, force: false);
	}

	private void setAttackSide(bool is_player, bool force)
	{
		if (is_player != isPlayer || force)
		{
			isPlayer = is_player;
			initLayers(is_player);
			SearchTargetPlayer();
			gameObject.tag = myCharTag(is_player);
		}
	}

	public MerlinMotionPackControl.Command playChainSkillAnimation()
	{
		forceToIdle();
		MerlinMotionPackControl.Command result = playAnimationByType(PlayerAnimationTypes.SpSkill);
		Mmpc.setLoopMode(loop: false);
		return result;
	}

	public override bool isEnemy(MerlinActionControl other)
	{
		bool flag = false;
		if (other is AIControl)
		{
			AIControl aIControl = other as AIControl;
			return aIControl.IsPlayer != isPlayer;
		}
		if (other is PlayerControl)
		{
			PlayerControl playerControl = other as PlayerControl;
			return !playerControl.hasPoppet((AIControl)other);
		}
		return false;
	}

	public override RespWeapon getMainWeapon()
	{
		return poppetWeapon;
	}

	private void equipWeaponAndAddCoverSkill(RespWeapon wpn)
	{
		if (wpn == null)
		{
			return;
		}
		poppetWeapon = wpn;
		SkillEffectControl.setWeaponsWithoutSkills(new RespWeapon[1] { wpn });
		if (!wpn.ColosseumCoverDisabled)
		{
			SkillEffector skillEffector = SkillEffector.WeaponCoverSkill(wpn);
			if (skillEffector != null)
			{
				SkillEffectControl.addSkillEffector(skillEffector);
			}
		}
	}

	public void addCoverSkills(RespPoppet poppetData, bool isLeader)
	{
		SkillEffector skillEffector = SkillEffector.PoppetCoverSkill1(poppetData);
		if (skillEffector != null && !poppetData.ColosseumCover1Disabled)
		{
			SkillEffectControl.addSkillEffector(skillEffector);
		}
		if (isLeader)
		{
			SkillEffector skillEffector2 = SkillEffector.PoppetCoverSkill2(poppetData);
			if (skillEffector2 != null && !poppetData.ColosseumCover2Disabled)
			{
				SkillEffectControl.addSkillEffector(skillEffector2);
			}
		}
	}

	public void addCoverSkillForColosseum(MCoverSkills skm, int level)
	{
		if (skm != null && !skm.DisableColosseum)
		{
			SkillEffector skillEffector = SkillEffector.CreateFromCoverSkillMaster(skm, level);
			if (skillEffector != null)
			{
				SkillEffectControl.addSkillEffector(skillEffector);
			}
		}
	}

	public void recalcHpMaxWithWeaponAndSkill()
	{
		SkillEffectControl.recalcAllSkillEffection();
		float num = default(float);
		num = (HasMonsterData ? ((float)MonsterData.Hp) : ((!HasPoppetData) ? 50f : DamageCalc.ColosseumPoppetHP(PoppetData, poppetWeapon)));
		setHitPointAndHitPointMax(calcHpMaxBySkill(num));
	}

	public void setupColosseumMonster(RespPoppet ppt, RespWeapon wpn, bool isPlayerSide)
	{
		if (ppt == null)
		{
			throw new AssertionFailedException("ppt != null");
		}
		PoppetData = ppt;
		setSetupTypeColosseum();
		setPlayerSideAndBodyLayer(isPlayerSide);
		equipWeaponAndAddCoverSkill(wpn);
		magicSkillComponent.setDelegate(new MagicSkillColosseumDelegate());
		magicSkillComponent.MaxMagicPoint = ppt.RequiredMagicPoint;
		ForceShowMiniGauge = true;
		monsterKillingMode = true;
		monsterKillingNoDrop = true;
		monsterKillingNoDestroy = true;
		if (isPlayerSide)
		{
			loadTargetRingStar(TargetRingTypes.ColosseumPlayer);
		}
		else
		{
			loadTargetRingStar(TargetRingTypes.ColosseumOpponent);
		}
		cacheChainEffect();
	}

	public void setupRaidBoss(MMonsters bossMaster, int level, float fieldRadius)
	{
		if (bossMaster == null)
		{
			throw new AssertionFailedException("bossMaster != null");
		}
		setSetupTypeRaidBoss();
		RespMonster respMonster = RespMonster.FromMaster(bossMaster);
		respMonster.Level = level;
		MonsterData = respMonster;
		NotDead = true;
		RaidRingWall.Constraint(gameObject, fieldRadius);
		AttackHitManager component = coliYarare.GetComponent<AttackHitManager>();
		if (component != null)
		{
			component.damagePointLocationType = AttackHitManager.DamagePointLocationType.Contact;
		}
	}

	internal void _0024createDataAIMODE_Wait_0024closure_00243702(ActionClassAIMODE_Wait _0024act_0024t_00241128)
	{
		enableAllMovementTypes();
		aiProgramOff();
	}

	internal void _0024createDataAIMODE_Wait_0024closure_00243703(ActionClassAIMODE_Wait _0024act_0024t_00241128)
	{
		FixedUpdateBattle();
	}

	internal void _0024createDataAIMODE_Wait_0024closure_00243704(ActionClassAIMODE_Wait _0024act_0024t_00241128)
	{
		if (!(_0024act_0024t_00241128.actionFrame < 45f))
		{
			AIMODE_Battle();
		}
	}

	internal void _0024createDataAIMODE_Stop_0024closure_00243705(ActionClassAIMODE_Stop _0024act_0024t_00241144)
	{
		disableAllMovementTypesWithoutMotionMove();
		aiProgramOff();
	}

	internal void _0024createDataAIMODE_Stop_0024closure_00243706(ActionClassAIMODE_Stop _0024act_0024t_00241144)
	{
		Mmpc.TimeScale = 0f;
	}

	internal void _0024createDataAIMODE_Renkei_0024closure_00243707(ActionClassAIMODE_Renkei _0024act_0024t_00241147)
	{
		Mmpc.TimeScale = 1f;
		disableAllMovementTypesWithoutMotionMove();
		aiProgramOff();
	}

	internal void _0024createDataAIMODE_Renkei_0024closure_00243708(ActionClassAIMODE_Renkei _0024act_0024t_00241147)
	{
		FixedUpdateRenkei();
	}

	internal void _0024createDataAIMODE_ChasePlayer_0024closure_00243709(ActionClassAIMODE_ChasePlayer _0024act_0024t_00241151)
	{
		Mmpc.TimeScale = 1f;
		enableAllMovementTypes();
		aiProgramOff();
	}

	internal IEnumerator _0024createDataAIMODE_ChasePlayer_0024closure_00243710(ActionClassAIMODE_ChasePlayer _0024act_0024t_00241151)
	{
		return new _0024_0024createDataAIMODE_ChasePlayer_0024closure_00243710_002416633(this).GetEnumerator();
	}

	internal void _0024createDataAIMODE_Battle_0024closure_00243711(ActionClassAIMODE_Battle _0024act_0024t_00241154)
	{
		Mmpc.TimeScale = 1f;
		enableAllMovementTypes();
		aiProgramOn();
	}

	internal void _0024createDataAIMODE_Battle_0024closure_00243712(ActionClassAIMODE_Battle _0024act_0024t_00241154)
	{
		FixedUpdateBattle();
	}

	internal void _0024createDataAIMODE_Battle_0024closure_00243713(ActionClassAIMODE_Battle _0024act_0024t_00241154)
	{
		try
		{
			SearchTargetPlayer();
		}
		catch (Exception)
		{
		}
		if (IS_ANIM_YARARE_DEAD)
		{
			if ((bool)hitPointBarColor)
			{
				hitPointBarColor.color = Color.gray;
			}
			if (IS_END_OF_MOTION && !deadActionPlayed)
			{
				deadAction();
			}
		}
	}

	internal RespSimpleReward _0024drop_0024closure_00243714(RespSimpleReward _0024genarray_00241157)
	{
		return _0024genarray_00241157;
	}

	internal bool _0024drop_0024closure_00243715(RespSimpleReward _0024genarray_00241157)
	{
		return _0024genarray_00241157.IsDrop;
	}

	internal void _0024WARP_0024closure_00243716()
	{
		warp();
	}
}
