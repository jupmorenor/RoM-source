using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class NPCControl : MonoBehaviour
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00241161;

		public string _0024act_0024t_00241162;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241163;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241164;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241165;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241166;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241167;

		public __ActionBase__0024act_0024t_00241163_0024callable47_0024173_5__ _0024act_0024t_00241168;

		public __ActionBase__0024act_0024t_00241169_0024callable48_0024173_5__ _0024act_0024t_00241169;

		public IEnumerator _0024act_0024t_00241173;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00241161.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassidle : ActionBase
	{
		public float waittime;
	}

	[Serializable]
	public class ActionClasstalk : ActionBase
	{
	}

	[Serializable]
	public class ActionClasswalk : ActionBase
	{
		public float walkingTime;

		public Vector3 preFramePos;

		public float stoppedTime;
	}

	[Serializable]
	public class ActionClassrun : ActionBase
	{
		public float runningTime;

		public Vector3 preFramePos;

		public float stoppedTime;
	}

	[Serializable]
	public class ActionClassmoveTo : ActionBase
	{
		public Vector3 targetPosition;
	}

	[Serializable]
	public enum ActionEnum
	{
		moveTo,
		run,
		walk,
		talk,
		idle,
		NUM,
		_noaction_
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024setGravityRoutine_002416650 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024b_002416651;

			internal NPCControl _0024self__002416652;

			public _0024(bool b, NPCControl self_)
			{
				_0024b_002416651 = b;
				_0024self__002416652 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024b_002416651)
					{
						_0024self__002416652.gameObject.layer = LayerMask.NameToLayer("CHR");
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__002416652._useGravity = _0024b_002416651;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024b_002416653;

		internal NPCControl _0024self__002416654;

		public _0024setGravityRoutine_002416650(bool b, NPCControl self_)
		{
			_0024b_002416653 = b;
			_0024self__002416654 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024b_002416653, _0024self__002416654);
		}
	}

	private MerlinMotionPackControl mpCont;

	public bool isMove;

	public AnimationClip idleAnim;

	public AnimationClip walkAnim;

	public AnimationClip runAnim;

	public AnimationClip talkAnim;

	protected AnimationClip lastAnim;

	protected AnimationClip lastLoopAnim;

	protected float lastLoopAnimTime;

	public int npcID;

	public GimmickIconTypes iconType;

	private CharacterController charControl;

	public float walkSpeed;

	public float runSpeed;

	public float defWalkTime;

	public float defRunTime;

	private bool _useGravity;

	private Vector3 moveVelocity;

	private bool pause;

	protected bool lastIsMove;

	protected float lastWalkSpeed;

	protected float lastRunSpeed;

	protected bool stopMove;

	protected AnimationClip initLoopAnim;

	protected float initLoopAnimTime;

	protected bool initFlag;

	protected float lastRotY;

	private Dictionary<string, ActionBase> _0024act_0024t_00241170;

	private Dictionary<string, ActionEnum> _0024act_0024t_00241172;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00241171;

	public bool actionDebugFlag;

	public bool UseGravity
	{
		get
		{
			return _useGravity;
		}
		set
		{
			IEnumerator enumerator = setGravityRoutine(value);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public bool Pause
	{
		get
		{
			return pause;
		}
		set
		{
			pause = value;
			StopMove = pause;
			if (mpCont == null)
			{
				if ((bool)animation)
				{
					animation.enabled = !pause;
				}
			}
			else
			{
				mpCont.Pause = pause;
			}
		}
	}

	public bool StopMove
	{
		get
		{
			return stopMove;
		}
		set
		{
			if (!stopMove)
			{
				lastIsMove = isMove;
				lastWalkSpeed = walkSpeed;
				lastRunSpeed = runSpeed;
			}
			stopMove = value;
			if (stopMove)
			{
				isMove = false;
				walkSpeed = 0f;
				runSpeed = 0f;
				idle();
			}
			else
			{
				isMove = lastIsMove;
				walkSpeed = lastWalkSpeed;
				runSpeed = lastRunSpeed;
			}
		}
	}

	public float LastRotY => lastRotY;

	public bool Isidle => currActionID("$default$") == ActionEnum.idle;

	public float actionTime => currActionTime("$default$");

	public ActionClassidle idleData => currAction("$default$") as ActionClassidle;

	public bool Istalk => currActionID("$default$") == ActionEnum.talk;

	public ActionClasstalk talkData => currAction("$default$") as ActionClasstalk;

	public bool Iswalk => currActionID("$default$") == ActionEnum.walk;

	public ActionClasswalk walkData => currAction("$default$") as ActionClasswalk;

	public bool Isrun => currActionID("$default$") == ActionEnum.run;

	public ActionClassrun runData => currAction("$default$") as ActionClassrun;

	public bool IsmoveTo => currActionID("$default$") == ActionEnum.moveTo;

	public ActionClassmoveTo moveToData => currAction("$default$") as ActionClassmoveTo;

	public NPCControl()
	{
		isMove = true;
		walkSpeed = 1.1f;
		runSpeed = 1.1f;
		defWalkTime = 4f;
		defRunTime = 4f;
		_0024act_0024t_00241170 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00241172 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	private IEnumerator setGravityRoutine(bool b)
	{
		return new _0024setGravityRoutine_002416650(b, this).GetEnumerator();
	}

	public void UpdateLastRotY()
	{
		lastRotY = transform.localEulerAngles.y;
	}

	public void RestoreLastRotY()
	{
		float y = lastRotY;
		Vector3 localEulerAngles = transform.localEulerAngles;
		float num = (localEulerAngles.y = y);
		Vector3 vector2 = (transform.localEulerAngles = localEulerAngles);
	}

	public void Start()
	{
		initFlag = true;
		charControl = GetComponent<CharacterController>();
		if (charControl == null)
		{
			throw new Exception(new StringBuilder("NPCControlにCharacterControllerが付いてないかenabled=false! ").Append(gameObject).ToString());
		}
		mpCont = GetComponent<MerlinMotionPackControl>();
		if (!initLoopAnim)
		{
			idle();
		}
		else
		{
			playLoop(initLoopAnim, initLoopAnimTime);
		}
	}

	public void OnEnable()
	{
		ShadowSelector.Setup(gameObject);
	}

	public void Update()
	{
		if (!RuntimeDebugMode.Instance.IsInDebugMode)
		{
			moveVelocity = Vector3.zero;
			actUpdate();
			if (UseGravity)
			{
				moveVelocity += new Vector3(0f, -9.8f, 0f) * Time.deltaTime;
			}
			if (!(moveVelocity.magnitude <= 0f) && charControl.enabled)
			{
				charControl.Move(moveVelocity);
			}
		}
	}

	private bool IsEndOfMotion()
	{
		return !(mpCont == null) && mpCont.IsEndOfMotion;
	}

	public void play(AnimationClip clip)
	{
		if (!(clip == null) && !(mpCont == null))
		{
			lastAnim = clip;
			lastLoopAnim = null;
			mpCont.play(clip);
		}
	}

	public void playLoop(AnimationClip clip)
	{
		playLoop(clip, 0f);
	}

	private void playLoop(AnimationClip clip, float timeOfs)
	{
		if (!initFlag)
		{
			initLoopAnim = clip;
			initLoopAnimTime = timeOfs;
		}
		else
		{
			if (clip == null)
			{
				return;
			}
			lastLoopAnim = clip;
			lastLoopAnimTime = timeOfs;
			lastAnim = null;
			if (mpCont == null)
			{
				string text = clip.name;
				AnimationState animationState = animation[text];
				if (animationState != null)
				{
					animationState.wrapMode = WrapMode.Loop;
					animationState.normalizedTime = timeOfs;
					animation.Play(text);
				}
			}
			else
			{
				mpCont.playLoop(clip);
			}
		}
	}

	public void RestartLastAnim()
	{
		if ((bool)lastLoopAnim)
		{
			playLoop(lastLoopAnim, lastLoopAnimTime);
		}
		else if ((bool)lastAnim)
		{
			play(lastAnim);
		}
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00241170.ContainsKey(grp)) ? null : _0024act_0024t_00241170[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00241172.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00241172[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00241170.ContainsKey(grp)) ? 0f : _0024act_0024t_00241170[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00241170.ContainsKey(grp)) ? 0f : _0024act_0024t_00241170[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00241170.ContainsKey(grp)) ? 0f : _0024act_0024t_00241170[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00241172.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00241162) && _0024act_0024t_00241170.ContainsKey(act._0024act_0024t_00241162) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00241170[act._0024act_0024t_00241162]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.moveTo <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_00241162))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$1162)");
			}
			_0024act_0024t_00241170[act._0024act_0024t_00241162] = act;
			_0024act_0024t_00241172[act._0024act_0024t_00241162] = act._0024act_0024t_00241161;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00241171) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00241162);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00241162)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00241162)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00241164 != null)
		{
			actionBase._0024act_0024t_00241164(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00241163 != null)
			{
				act._0024act_0024t_00241163(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00241169 != null)
			{
				act._0024act_0024t_00241173 = act._0024act_0024t_00241169(act);
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
		foreach (ActionBase value in _0024act_0024t_00241170.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00241171 = 0;
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
			if (actionBase._0024act_0024t_00241165 != null)
			{
				actionBase._0024act_0024t_00241165(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00241173 != null && !actionBase._0024act_0024t_00241173.MoveNext())
			{
				actionBase._0024act_0024t_00241173 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00241170.Values)
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
		_0024act_0024t_00241171 = 0;
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
			if (actionBase._0024act_0024t_00241166 != null)
			{
				actionBase._0024act_0024t_00241166(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00241171 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241170.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00241170[array2[i]];
				if (actionBase._0024act_0024t_00241167 != null)
				{
					actionBase._0024act_0024t_00241167(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00241170.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00241162 + " - " + value._0024act_0024t_00241161 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00241171 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00241170.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00241170[array2[i]];
			if (actionBase._0024act_0024t_00241168 != null)
			{
				actionBase._0024act_0024t_00241168(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "NPCControl" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.idle => createDataidle(), 
			ActionEnum.talk => createDatatalk(), 
			ActionEnum.walk => createDatawalk(), 
			ActionEnum.run => createDatarun(), 
			ActionEnum.moveTo => createDatamoveTo(), 
			_ => null, 
		};
	}

	public ActionClassidle idle()
	{
		ActionClassidle actionClassidle = createidle();
		changeAction(actionClassidle);
		return actionClassidle;
	}

	public ActionClassidle createDataidle()
	{
		ActionClassidle actionClassidle = new ActionClassidle();
		actionClassidle._0024act_0024t_00241161 = ActionEnum.idle;
		actionClassidle._0024act_0024t_00241162 = "$default$";
		actionClassidle._0024act_0024t_00241163 = _0024adaptor_0024__NPCControl_0024callable320_0024173_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024122.Adapt(delegate
		{
			playLoop(idleAnim, UnityEngine.Random.Range(0f, 1f));
		});
		actionClassidle._0024act_0024t_00241165 = _0024adaptor_0024__NPCControl_0024callable320_0024173_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024122.Adapt(delegate(ActionClassidle _0024act_0024t_00241160)
		{
			if (!stopMove && !(_0024act_0024t_00241160.actionTime <= _0024act_0024t_00241160.waittime) && isMove)
			{
				transform.eulerAngles = new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f);
				if (UnityEngine.Random.Range(0, 99) < 33)
				{
					run(defRunTime);
				}
				else
				{
					walk(defWalkTime);
				}
			}
		});
		return actionClassidle;
	}

	public ActionClassidle createidle()
	{
		ActionClassidle actionClassidle = createDataidle();
		actionClassidle.waittime = UnityEngine.Random.value * 3f + 3f;
		return actionClassidle;
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00241170.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00241170["$default$"];
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

	public ActionClasstalk talk()
	{
		ActionClasstalk actionClasstalk = createtalk();
		changeAction(actionClasstalk);
		return actionClasstalk;
	}

	public ActionClasstalk createDatatalk()
	{
		ActionClasstalk actionClasstalk = new ActionClasstalk();
		actionClasstalk._0024act_0024t_00241161 = ActionEnum.talk;
		actionClasstalk._0024act_0024t_00241162 = "$default$";
		actionClasstalk._0024act_0024t_00241163 = _0024adaptor_0024__NPCControl_0024callable321_0024191_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024123.Adapt(delegate
		{
			play(talkAnim);
		});
		actionClasstalk._0024act_0024t_00241165 = _0024adaptor_0024__NPCControl_0024callable321_0024191_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024123.Adapt(delegate
		{
			if (IsEndOfMotion())
			{
				idle();
			}
		});
		return actionClasstalk;
	}

	public ActionClasstalk createtalk()
	{
		return createDatatalk();
	}

	public ActionClasswalk walk(float walkingTime)
	{
		ActionClasswalk actionClasswalk = createwalk(walkingTime);
		changeAction(actionClasswalk);
		return actionClasswalk;
	}

	public ActionClasswalk createDatawalk()
	{
		ActionClasswalk actionClasswalk = new ActionClasswalk();
		actionClasswalk._0024act_0024t_00241161 = ActionEnum.walk;
		actionClasswalk._0024act_0024t_00241162 = "$default$";
		actionClasswalk._0024act_0024t_00241163 = _0024adaptor_0024__NPCControl_0024callable322_0024199_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024124.Adapt(delegate(ActionClasswalk _0024act_0024t_00241179)
		{
			playLoop(walkAnim);
			initWalkingDirInfo(ref _0024act_0024t_00241179.preFramePos, ref _0024act_0024t_00241179.stoppedTime);
		});
		actionClasswalk._0024act_0024t_00241165 = _0024adaptor_0024__NPCControl_0024callable322_0024199_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024124.Adapt(delegate(ActionClasswalk _0024act_0024t_00241179)
		{
			if (!stopMove)
			{
				if (!(walkSpeed <= 0f))
				{
					moveVelocity = transform.forward * Time.deltaTime * walkSpeed;
					UseGravity = true;
				}
				if (!(_0024act_0024t_00241179.actionTime <= _0024act_0024t_00241179.walkingTime))
				{
					idle();
				}
				checkWalkingDir(ref _0024act_0024t_00241179.preFramePos, ref _0024act_0024t_00241179.stoppedTime);
			}
		});
		return actionClasswalk;
	}

	public ActionClasswalk createwalk(float walkingTime)
	{
		ActionClasswalk actionClasswalk = createDatawalk();
		actionClasswalk.walkingTime = walkingTime;
		return actionClasswalk;
	}

	public ActionClassrun run(float runningTime)
	{
		ActionClassrun actionClassrun = createrun(runningTime);
		changeAction(actionClassrun);
		return actionClassrun;
	}

	public ActionClassrun createDatarun()
	{
		ActionClassrun actionClassrun = new ActionClassrun();
		actionClassrun._0024act_0024t_00241161 = ActionEnum.run;
		actionClassrun._0024act_0024t_00241162 = "$default$";
		actionClassrun._0024act_0024t_00241163 = _0024adaptor_0024__NPCControl_0024callable323_0024218_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024125.Adapt(delegate(ActionClassrun _0024act_0024t_00241182)
		{
			if ((bool)runAnim)
			{
				playLoop(runAnim);
			}
			else
			{
				playLoop(walkAnim);
			}
			initWalkingDirInfo(ref _0024act_0024t_00241182.preFramePos, ref _0024act_0024t_00241182.stoppedTime);
		});
		actionClassrun._0024act_0024t_00241165 = _0024adaptor_0024__NPCControl_0024callable323_0024218_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024125.Adapt(delegate(ActionClassrun _0024act_0024t_00241182)
		{
			if (!stopMove)
			{
				if (!(runSpeed <= 0f))
				{
					moveVelocity = transform.forward * Time.deltaTime * runSpeed;
					UseGravity = true;
				}
				if (!(_0024act_0024t_00241182.actionTime <= _0024act_0024t_00241182.runningTime))
				{
					idle();
				}
				checkWalkingDir(ref _0024act_0024t_00241182.preFramePos, ref _0024act_0024t_00241182.stoppedTime);
			}
		});
		return actionClassrun;
	}

	public ActionClassrun createrun(float runningTime)
	{
		ActionClassrun actionClassrun = createDatarun();
		actionClassrun.runningTime = runningTime;
		return actionClassrun;
	}

	private void initWalkingDirInfo(ref Vector3 prePos, ref float stoppedTime)
	{
		prePos = transform.position;
		stoppedTime = 0f;
	}

	private void checkWalkingDir(ref Vector3 prePos, ref float stoppedTime)
	{
		if (!((transform.position - prePos).magnitude >= 0.005f))
		{
			stoppedTime += Time.deltaTime;
			if (!(stoppedTime <= 1f))
			{
				stoppedTime = 0f;
				transform.eulerAngles = new Vector3(0f, transform.rotation.eulerAngles.y + 180f, 0f);
			}
		}
		prePos = transform.position;
	}

	public ActionClassmoveTo moveTo(Vector3 targetPosition)
	{
		ActionClassmoveTo actionClassmoveTo = createmoveTo(targetPosition);
		changeAction(actionClassmoveTo);
		return actionClassmoveTo;
	}

	public ActionClassmoveTo createDatamoveTo()
	{
		ActionClassmoveTo actionClassmoveTo = new ActionClassmoveTo();
		actionClassmoveTo._0024act_0024t_00241161 = ActionEnum.moveTo;
		actionClassmoveTo._0024act_0024t_00241162 = "$default$";
		actionClassmoveTo._0024act_0024t_00241163 = _0024adaptor_0024__NPCControl_0024callable324_0024253_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024126.Adapt(delegate
		{
			if ((bool)runAnim)
			{
				playLoop(runAnim);
			}
			else
			{
				playLoop(walkAnim);
			}
		});
		actionClassmoveTo._0024act_0024t_00241165 = _0024adaptor_0024__NPCControl_0024callable324_0024253_5___0024__ActionBase__0024act_0024t_00241163_0024callable47_0024173_5___0024126.Adapt(delegate(ActionClassmoveTo _0024act_0024t_00241185)
		{
			if (!stopMove)
			{
				float num = default(float);
				if (!(runSpeed <= 0f))
				{
					Vector3 forward = _0024act_0024t_00241185.targetPosition - transform.position;
					forward.y = 0f;
					Quaternion to = Quaternion.LookRotation(forward);
					transform.rotation = Quaternion.Slerp(transform.rotation, to, 0.1f);
					_0024act_0024t_00241185.targetPosition.y = transform.position.y;
					num = Vector3.Distance(transform.position, _0024act_0024t_00241185.targetPosition);
					float num2 = Mathf.Min(num, Time.deltaTime * runSpeed);
					moveVelocity = transform.forward * num2;
				}
				if (!(num >= 0.5f))
				{
					idle();
				}
			}
		});
		return actionClassmoveTo;
	}

	public ActionClassmoveTo createmoveTo(Vector3 targetPosition)
	{
		ActionClassmoveTo actionClassmoveTo = createDatamoveTo();
		actionClassmoveTo.targetPosition = targetPosition;
		return actionClassmoveTo;
	}

	internal void _0024createDataidle_0024closure_00243762(ActionClassidle _0024act_0024t_00241160)
	{
		playLoop(idleAnim, UnityEngine.Random.Range(0f, 1f));
	}

	internal void _0024createDataidle_0024closure_00243763(ActionClassidle _0024act_0024t_00241160)
	{
		if (!stopMove && !(_0024act_0024t_00241160.actionTime <= _0024act_0024t_00241160.waittime) && isMove)
		{
			transform.eulerAngles = new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f);
			if (UnityEngine.Random.Range(0, 99) < 33)
			{
				run(defRunTime);
			}
			else
			{
				walk(defWalkTime);
			}
		}
	}

	internal void _0024createDatatalk_0024closure_00243764(ActionClasstalk _0024act_0024t_00241176)
	{
		play(talkAnim);
	}

	internal void _0024createDatatalk_0024closure_00243765(ActionClasstalk _0024act_0024t_00241176)
	{
		if (IsEndOfMotion())
		{
			idle();
		}
	}

	internal void _0024createDatawalk_0024closure_00243766(ActionClasswalk _0024act_0024t_00241179)
	{
		playLoop(walkAnim);
		initWalkingDirInfo(ref _0024act_0024t_00241179.preFramePos, ref _0024act_0024t_00241179.stoppedTime);
	}

	internal void _0024createDatawalk_0024closure_00243767(ActionClasswalk _0024act_0024t_00241179)
	{
		if (!stopMove)
		{
			if (!(walkSpeed <= 0f))
			{
				moveVelocity = transform.forward * Time.deltaTime * walkSpeed;
				UseGravity = true;
			}
			if (!(_0024act_0024t_00241179.actionTime <= _0024act_0024t_00241179.walkingTime))
			{
				idle();
			}
			checkWalkingDir(ref _0024act_0024t_00241179.preFramePos, ref _0024act_0024t_00241179.stoppedTime);
		}
	}

	internal void _0024createDatarun_0024closure_00243768(ActionClassrun _0024act_0024t_00241182)
	{
		if ((bool)runAnim)
		{
			playLoop(runAnim);
		}
		else
		{
			playLoop(walkAnim);
		}
		initWalkingDirInfo(ref _0024act_0024t_00241182.preFramePos, ref _0024act_0024t_00241182.stoppedTime);
	}

	internal void _0024createDatarun_0024closure_00243769(ActionClassrun _0024act_0024t_00241182)
	{
		if (!stopMove)
		{
			if (!(runSpeed <= 0f))
			{
				moveVelocity = transform.forward * Time.deltaTime * runSpeed;
				UseGravity = true;
			}
			if (!(_0024act_0024t_00241182.actionTime <= _0024act_0024t_00241182.runningTime))
			{
				idle();
			}
			checkWalkingDir(ref _0024act_0024t_00241182.preFramePos, ref _0024act_0024t_00241182.stoppedTime);
		}
	}

	internal void _0024createDatamoveTo_0024closure_00243770(ActionClassmoveTo _0024act_0024t_00241185)
	{
		if ((bool)runAnim)
		{
			playLoop(runAnim);
		}
		else
		{
			playLoop(walkAnim);
		}
	}

	internal void _0024createDatamoveTo_0024closure_00243771(ActionClassmoveTo _0024act_0024t_00241185)
	{
		if (!stopMove)
		{
			float num = default(float);
			if (!(runSpeed <= 0f))
			{
				Vector3 forward = _0024act_0024t_00241185.targetPosition - transform.position;
				forward.y = 0f;
				Quaternion to = Quaternion.LookRotation(forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, to, 0.1f);
				_0024act_0024t_00241185.targetPosition.y = transform.position.y;
				num = Vector3.Distance(transform.position, _0024act_0024t_00241185.targetPosition);
				float num2 = Mathf.Min(num, Time.deltaTime * runSpeed);
				moveVelocity = transform.forward * num2;
			}
			if (!(num >= 0.5f))
			{
				idle();
			}
		}
	}
}
