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
public class DebugSubSkill : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024364;

		public string _0024act_0024t_0024365;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024366;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024367;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024368;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024369;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024370;

		public __ActionBase__0024act_0024t_0024366_0024callable20_002438_5__ _0024act_0024t_0024371;

		public __ActionBase__0024act_0024t_0024372_0024callable21_002438_5__ _0024act_0024t_0024372;

		public IEnumerator _0024act_0024t_0024376;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024364.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
		public PlayerControl[] players;
	}

	[Serializable]
	public class ActionClassviewDamageLogs : ActionBase
	{
		public int index;

		public string[] logs;
	}

	[Serializable]
	public class ActionClasseditPlayer : ActionBase
	{
		public PlayerControl pl;

		public int vpadMoveThIndex;

		public int speedIndex;

		public int distIndex;

		public int hudUpdateCountIndex;
	}

	[Serializable]
	public class ActionClassmotionPackView : ActionBase
	{
		public PlayerControl pl;
	}

	[Serializable]
	public class ActionClassviewSkills : ActionBase
	{
		public MerlinActionControl ch;

		public ICallable back;
	}

	[Serializable]
	public class ActionClassviewDamageCharData : ActionBase
	{
		public MerlinActionControl ch;

		public ICallable back;
	}

	[Serializable]
	public class ActionClassskillEditMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassviewMotPackList : ActionBase
	{
		public MerlinMotionPack[] motPacks;
	}

	[Serializable]
	public class ActionClassviewMotPackControl : ActionBase
	{
		public MerlinMotionPackControl mmpc;

		public ICallable back;
	}

	[Serializable]
	public class ActionClassviewMotPack : ActionBase
	{
		public MerlinMotionPack mp;
	}

	[Serializable]
	public class ActionClassviewPlayerPoppetCacheInfo : ActionBase
	{
	}

	[Serializable]
	public class ActionClassviewAllAIControls : ActionBase
	{
	}

	[Serializable]
	public class ActionClassviewAIControl : ActionBase
	{
		public AIControl ai;

		public ICallable back;
	}

	[Serializable]
	public class ActionClassviewPoppets : ActionBase
	{
	}

	[Serializable]
	public class ActionClassviewPathfinderInfo : ActionBase
	{
		public ICallable back;
	}

	[Serializable]
	public class GUICharacterStatus : MonoBehaviour
	{
		public void OnGUI()
		{
			Rect position = new Rect(50f, 100f, 500f, 32f);
			int i = 0;
			BaseControl[] allControls = BaseControl.AllControls;
			for (int length = allControls.Length; i < length; i = checked(i + 1))
			{
				GameObject gameObject = allControls[i].gameObject;
				GUI.Label(position, new StringBuilder().Append(gameObject.name).Append(": HP ").Append(allControls[i].HitPoint)
					.Append("/")
					.Append(allControls[i].MaxHitPoint)
					.ToString());
				position.y += 32f;
			}
		}
	}

	[Serializable]
	public enum ActionEnum
	{
		viewPathfinderInfo,
		viewPoppets,
		viewAIControl,
		viewAllAIControls,
		viewPlayerPoppetCacheInfo,
		viewMotPack,
		viewMotPackControl,
		viewMotPackList,
		skillEditMode,
		viewDamageCharData,
		viewSkills,
		motionPackView,
		editPlayer,
		viewDamageLogs,
		mainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024_showAIData_0024locals_002414294
	{
		internal AIControl _0024p;
	}

	[Serializable]
	internal class _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295
	{
		internal ActionClassviewDamageLogs _0024_0024act_0024t_0024379;
	}

	[Serializable]
	internal class _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296
	{
		internal PlayerAutoBattle _0024auto;

		internal ActionClasseditPlayer _0024_0024act_0024t_0024382;
	}

	[Serializable]
	internal class _0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297
	{
		internal ActionClassviewSkills _0024_0024act_0024t_0024388;
	}

	[Serializable]
	internal class _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298
	{
		internal ActionClassviewAIControl _0024_0024act_0024t_0024412;
	}

	[Serializable]
	internal class _0024_0024createDataviewDamageLogs_0024closure_00243482_0024closure_00243483
	{
		internal _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295 _0024_0024locals_002414677;

		public _0024_0024createDataviewDamageLogs_0024closure_00243482_0024closure_00243483(_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295 _0024_0024locals_002414677)
		{
			this._0024_0024locals_002414677 = _0024_0024locals_002414677;
		}

		public void Invoke()
		{
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("前へ") && _0024_0024locals_002414677._0024_0024act_0024t_0024379.index > 0)
				{
					_0024_0024locals_002414677._0024_0024act_0024t_0024379.index = _0024_0024locals_002414677._0024_0024act_0024t_0024379.index - 1;
				}
				if (RuntimeDebugModeGuiMixin.button("後へ") && _0024_0024locals_002414677._0024_0024act_0024t_0024379.index < _0024_0024locals_002414677._0024_0024act_0024t_0024379.logs.Length - 1)
				{
					_0024_0024locals_002414677._0024_0024act_0024t_0024379.index = _0024_0024locals_002414677._0024_0024act_0024t_0024379.index + 1;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243487
	{
		internal DebugSubSkill _0024this_002414678;

		internal _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024locals_002414679;

		public _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243487(DebugSubSkill _0024this_002414678, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024locals_002414679)
		{
			this._0024this_002414678 = _0024this_002414678;
			this._0024_0024locals_002414679 = _0024_0024locals_002414679;
		}

		public ActionClasseditPlayer Invoke()
		{
			return _0024this_002414678.editPlayer(_0024_0024locals_002414679._0024_0024act_0024t_0024382.pl);
		}
	}

	[Serializable]
	internal class _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243491
	{
		internal _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024locals_002414680;

		public _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243491(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024locals_002414680)
		{
			this._0024_0024locals_002414680 = _0024_0024locals_002414680;
		}

		public void Invoke()
		{
			bool enableAuto = _0024_0024locals_002414680._0024_0024act_0024t_0024382.pl.EnableAuto;
			string value = ((!enableAuto) ? "on" : "off");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("autobattle ").Append(value).Append(" にする").ToString()))
			{
				_0024_0024locals_002414680._0024_0024act_0024t_0024382.pl.EnableAuto = !enableAuto;
			}
			bool autoSkillMode = _0024_0024locals_002414680._0024auto.AutoSkillMode;
			value = ((!autoSkillMode) ? "on" : "off");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("autoskill ").Append(value).Append(" にする").ToString()))
			{
				_0024_0024locals_002414680._0024auto.AutoSkillMode = !autoSkillMode;
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataviewSkills_0024closure_00243497_0024closure_00243498
	{
		internal DebugSubSkill _0024this_002414681;

		internal _0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297 _0024_0024locals_002414682;

		public _0024_0024createDataviewSkills_0024closure_00243497_0024closure_00243498(DebugSubSkill _0024this_002414681, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297 _0024_0024locals_002414682)
		{
			this._0024this_002414681 = _0024this_002414681;
			this._0024_0024locals_002414682 = _0024_0024locals_002414682;
		}

		public void Invoke()
		{
			_0024this_002414681.viewSkills(_0024_0024locals_002414682._0024_0024act_0024t_0024388.ch, _0024_0024locals_002414682._0024_0024act_0024t_0024388.back);
		}
	}

	[Serializable]
	internal class _0024_0024createDataviewAIControl_0024closure_00243520_0024closure_00243521
	{
		internal _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298 _0024_0024locals_002414683;

		internal DebugSubSkill _0024this_002414684;

		public _0024_0024createDataviewAIControl_0024closure_00243520_0024closure_00243521(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298 _0024_0024locals_002414683, DebugSubSkill _0024this_002414684)
		{
			this._0024_0024locals_002414683 = _0024_0024locals_002414683;
			this._0024this_002414684 = _0024this_002414684;
		}

		public void Invoke()
		{
			_0024this_002414684.viewAIControl(_0024_0024locals_002414683._0024_0024act_0024t_0024412.ai, _0024_0024locals_002414683._0024_0024act_0024t_0024412.back);
		}
	}

	[Serializable]
	internal class _0024_showAIData_0024closure_00243525
	{
		internal _0024_showAIData_0024locals_002414294 _0024_0024locals_002414685;

		public _0024_showAIData_0024closure_00243525(_0024_showAIData_0024locals_002414294 _0024_0024locals_002414685)
		{
			this._0024_0024locals_002414685 = _0024_0024locals_002414685;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("HP最大にする"))
			{
				_0024_0024locals_002414685._0024p.HitPoint = _0024_0024locals_002414685._0024p.MaxHitPoint;
			}
			string text = ((!_0024_0024locals_002414685._0024p.NotDead) ? "不死にする" : "不死やめる");
			if (RuntimeDebugModeGuiMixin.button(text))
			{
				_0024_0024locals_002414685._0024p.NotDead = !_0024_0024locals_002414685._0024p.NotDead;
			}
		}
	}

	[Serializable]
	internal class _0024_showAIData_0024closure_00243526
	{
		internal _0024_showAIData_0024locals_002414294 _0024_0024locals_002414686;

		public _0024_showAIData_0024closure_00243526(_0024_showAIData_0024locals_002414294 _0024_0024locals_002414686)
		{
			this._0024_0024locals_002414686 = _0024_0024locals_002414686;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("HP1にする"))
			{
				_0024_0024locals_002414686._0024p.HitPoint = 1f;
			}
			if (RuntimeDebugModeGuiMixin.button("動かない"))
			{
				_0024_0024locals_002414686._0024p.aiProgramOff();
			}
		}
	}

	[Serializable]
	internal class _0024_showAIData_0024closure_00243527
	{
		internal _0024_showAIData_0024locals_002414294 _0024_0024locals_002414687;

		public _0024_showAIData_0024closure_00243527(_0024_showAIData_0024locals_002414294 _0024_0024locals_002414687)
		{
			this._0024_0024locals_002414687 = _0024_0024locals_002414687;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("HP90%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.9f;
			}
			if (RuntimeDebugModeGuiMixin.button("HP85%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.85f;
			}
			if (RuntimeDebugModeGuiMixin.button("HP70%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.7f;
			}
			if (RuntimeDebugModeGuiMixin.button("HP50%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.5f;
			}
			if (RuntimeDebugModeGuiMixin.button("HP30%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.3f;
			}
			if (RuntimeDebugModeGuiMixin.button("HP10%"))
			{
				_0024_0024locals_002414687._0024p.HitPoint = _0024_0024locals_002414687._0024p.MaxHitPoint * 0.1f;
			}
		}
	}

	[NonSerialized]
	protected static int skillIndex;

	[NonSerialized]
	protected static int valueMin = 1;

	[NonSerialized]
	protected static int valueMax = 1;

	[NonSerialized]
	protected static float valueExp = 1f;

	[NonSerialized]
	protected static int elementIndex;

	[NonSerialized]
	protected static int element1Index;

	[NonSerialized]
	protected static int element2Index;

	[NonSerialized]
	protected static int styleIndex;

	[NonSerialized]
	protected static int raceIndex;

	[NonSerialized]
	protected static int level = 1;

	[NonSerialized]
	protected static int levelMax = 1;

	[NonSerialized]
	protected static float powerBase = 10f;

	[NonSerialized]
	protected static float expirationTime = 10f;

	[NonSerialized]
	protected static int underHP = 30;

	[NonSerialized]
	protected static int count = 4;

	[NonSerialized]
	protected static int rate = 100;

	[NonSerialized]
	protected static int abnormalStateIndex;

	[NonSerialized]
	protected static bool showCharacterStatus;

	private Dictionary<string, ActionBase> _0024act_0024t_0024373;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024375;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024374;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IsviewDamageLogs => currActionID("$default$") == ActionEnum.viewDamageLogs;

	public ActionClassviewDamageLogs viewDamageLogsData => currAction("$default$") as ActionClassviewDamageLogs;

	public bool IseditPlayer => currActionID("$default$") == ActionEnum.editPlayer;

	public ActionClasseditPlayer editPlayerData => currAction("$default$") as ActionClasseditPlayer;

	public bool IsmotionPackView => currActionID("$default$") == ActionEnum.motionPackView;

	public ActionClassmotionPackView motionPackViewData => currAction("$default$") as ActionClassmotionPackView;

	public bool IsviewSkills => currActionID("$default$") == ActionEnum.viewSkills;

	public ActionClassviewSkills viewSkillsData => currAction("$default$") as ActionClassviewSkills;

	public bool IsviewDamageCharData => currActionID("$default$") == ActionEnum.viewDamageCharData;

	public ActionClassviewDamageCharData viewDamageCharDataData => currAction("$default$") as ActionClassviewDamageCharData;

	public bool IsskillEditMode => currActionID("$default$") == ActionEnum.skillEditMode;

	public ActionClassskillEditMode skillEditModeData => currAction("$default$") as ActionClassskillEditMode;

	public bool IsviewMotPackList => currActionID("$default$") == ActionEnum.viewMotPackList;

	public ActionClassviewMotPackList viewMotPackListData => currAction("$default$") as ActionClassviewMotPackList;

	public bool IsviewMotPackControl => currActionID("$default$") == ActionEnum.viewMotPackControl;

	public ActionClassviewMotPackControl viewMotPackControlData => currAction("$default$") as ActionClassviewMotPackControl;

	public bool IsviewMotPack => currActionID("$default$") == ActionEnum.viewMotPack;

	public ActionClassviewMotPack viewMotPackData => currAction("$default$") as ActionClassviewMotPack;

	public bool IsviewPlayerPoppetCacheInfo => currActionID("$default$") == ActionEnum.viewPlayerPoppetCacheInfo;

	public ActionClassviewPlayerPoppetCacheInfo viewPlayerPoppetCacheInfoData => currAction("$default$") as ActionClassviewPlayerPoppetCacheInfo;

	public bool IsviewAllAIControls => currActionID("$default$") == ActionEnum.viewAllAIControls;

	public ActionClassviewAllAIControls viewAllAIControlsData => currAction("$default$") as ActionClassviewAllAIControls;

	public bool IsviewAIControl => currActionID("$default$") == ActionEnum.viewAIControl;

	public ActionClassviewAIControl viewAIControlData => currAction("$default$") as ActionClassviewAIControl;

	public bool IsviewPoppets => currActionID("$default$") == ActionEnum.viewPoppets;

	public ActionClassviewPoppets viewPoppetsData => currAction("$default$") as ActionClassviewPoppets;

	public bool IsviewPathfinderInfo => currActionID("$default$") == ActionEnum.viewPathfinderInfo;

	public ActionClassviewPathfinderInfo viewPathfinderInfoData => currAction("$default$") as ActionClassviewPathfinderInfo;

	public DebugSubSkill()
	{
		_0024act_0024t_0024373 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024375 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
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

	public override void Init()
	{
		mainMode();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024373.ContainsKey(grp)) ? null : _0024act_0024t_0024373[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024375.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024375[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024373.ContainsKey(grp)) ? 0f : _0024act_0024t_0024373[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024373.ContainsKey(grp)) ? 0f : _0024act_0024t_0024373[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024373.ContainsKey(grp)) ? 0f : _0024act_0024t_0024373[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024375.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024365) && _0024act_0024t_0024373.ContainsKey(act._0024act_0024t_0024365) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024373[act._0024act_0024t_0024365]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.viewPathfinderInfo <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024365))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$365)");
			}
			_0024act_0024t_0024373[act._0024act_0024t_0024365] = act;
			_0024act_0024t_0024375[act._0024act_0024t_0024365] = act._0024act_0024t_0024364;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024374) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024365);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024365)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024365)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024367 != null)
		{
			actionBase._0024act_0024t_0024367(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024366 != null)
			{
				act._0024act_0024t_0024366(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024372 != null)
			{
				act._0024act_0024t_0024376 = act._0024act_0024t_0024372(act);
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
		foreach (ActionBase value in _0024act_0024t_0024373.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024374 = 0;
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
			if (actionBase._0024act_0024t_0024368 != null)
			{
				actionBase._0024act_0024t_0024368(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024376 != null && !actionBase._0024act_0024t_0024376.MoveNext())
			{
				actionBase._0024act_0024t_0024376 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024373.Values)
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
		_0024act_0024t_0024374 = 0;
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
			if (actionBase._0024act_0024t_0024369 != null)
			{
				actionBase._0024act_0024t_0024369(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024374 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024373.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024373[array2[i]];
				if (actionBase._0024act_0024t_0024370 != null)
				{
					actionBase._0024act_0024t_0024370(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024373.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024365 + " - " + value._0024act_0024t_0024364 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024374 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024373.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024373[array2[i]];
			if (actionBase._0024act_0024t_0024371 != null)
			{
				actionBase._0024act_0024t_0024371(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubSkill" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.viewDamageLogs => createDataviewDamageLogs(), 
			ActionEnum.editPlayer => createDataeditPlayer(), 
			ActionEnum.motionPackView => createDatamotionPackView(), 
			ActionEnum.viewSkills => createDataviewSkills(), 
			ActionEnum.viewDamageCharData => createDataviewDamageCharData(), 
			ActionEnum.skillEditMode => createDataskillEditMode(), 
			ActionEnum.viewMotPackList => createDataviewMotPackList(), 
			ActionEnum.viewMotPackControl => createDataviewMotPackControl(), 
			ActionEnum.viewMotPack => createDataviewMotPack(), 
			ActionEnum.viewPlayerPoppetCacheInfo => createDataviewPlayerPoppetCacheInfo(), 
			ActionEnum.viewAllAIControls => createDataviewAllAIControls(), 
			ActionEnum.viewAIControl => createDataviewAIControl(), 
			ActionEnum.viewPoppets => createDataviewPoppets(), 
			ActionEnum.viewPathfinderInfo => createDataviewPathfinderInfo(), 
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
		actionClassmainMode._0024act_0024t_0024364 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024365 = "$default$";
		actionClassmainMode._0024act_0024t_0024366 = _0024adaptor_0024__DebugSubModeSkill_0024callable233_002438_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002441.Adapt(delegate(ActionClassmainMode _0024act_0024t_0024363)
		{
			_0024act_0024t_0024363.players = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
		});
		actionClassmainMode._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable233_002438_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002441.Adapt(checked(delegate(ActionClassmainMode _0024act_0024t_0024363)
		{
			RuntimeDebugModeGuiMixin.label("スキルデバッグ");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("skill用プレイ日時 : " + SkillEffector.PlayDateTime());
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("スキル追加"))
			{
				skillEditMode();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("現在のスキル");
			if (_0024act_0024t_0024363.players.Length > 0)
			{
				int i = 0;
				PlayerControl[] players = _0024act_0024t_0024363.players;
				for (int length = players.Length; i < length; i++)
				{
					if (RuntimeDebugModeGuiMixin.button(players[i].gameObject.name))
					{
						viewSkills(players[i], new __DebugSubSkill__0024createDatamainMode_0024closure_00243478_0024callable434_002460_41__(mainMode));
					}
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("プレーヤーがいません");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("ダメージログ"))
			{
				viewDamageLogs();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("その他プレーヤー情報/設定");
			if (_0024act_0024t_0024363.players.Length > 0)
			{
				int j = 0;
				PlayerControl[] players2 = _0024act_0024t_0024363.players;
				for (int length2 = players2.Length; j < length2; j++)
				{
					if (RuntimeDebugModeGuiMixin.button(players2[j].gameObject.name))
					{
						editPlayer(players2[j]);
					}
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("プレーヤーがいません");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("全AIControl情報"))
			{
				viewAllAIControls();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("MotPacks"))
			{
				viewMotPackList();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("PlayerPoppetCache"))
			{
				viewPlayerPoppetCacheInfo();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("Pathfinder"))
			{
				viewPathfinderInfo((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					mainMode();
				});
			}
			RuntimeDebugModeGuiMixin.space(10);
			showCharacterStatus = RuntimeDebugModeGuiMixin.boolButtons(showCharacterStatus, "BaseControl-HP表示");
			RuntimeDebugMode instance = RuntimeDebugMode.Instance;
			GUICharacterStatus component = instance.gameObject.GetComponent<GUICharacterStatus>();
			if (showCharacterStatus && component == null)
			{
				ExtensionsModule.SetComponent<GUICharacterStatus>(instance.gameObject);
			}
			if (!showCharacterStatus && component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
		}));
		actionClassmainMode._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable233_002438_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002441.Adapt(delegate
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
		if (_0024act_0024t_0024373.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024373["$default$"];
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

	public ActionClassviewDamageLogs viewDamageLogs()
	{
		ActionClassviewDamageLogs actionClassviewDamageLogs = createviewDamageLogs();
		changeAction(actionClassviewDamageLogs);
		return actionClassviewDamageLogs;
	}

	public ActionClassviewDamageLogs createDataviewDamageLogs()
	{
		ActionClassviewDamageLogs actionClassviewDamageLogs = new ActionClassviewDamageLogs();
		actionClassviewDamageLogs._0024act_0024t_0024364 = ActionEnum.viewDamageLogs;
		actionClassviewDamageLogs._0024act_0024t_0024365 = "$default$";
		checked
		{
			actionClassviewDamageLogs._0024act_0024t_0024366 = _0024adaptor_0024__DebugSubModeSkill_0024callable234_0024105_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002442.Adapt(delegate(ActionClassviewDamageLogs _0024act_0024t_0024379)
			{
				_0024act_0024t_0024379.logs = (string[])Builtins.array(typeof(string), DamageCalc.LogHistory);
				_0024act_0024t_0024379.index = _0024act_0024t_0024379.logs.Length - 1;
			});
			actionClassviewDamageLogs._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable234_0024105_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002442.Adapt(delegate(ActionClassviewDamageLogs _0024act_0024t_0024379)
			{
				_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295 _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024 = new _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295();
				_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379 = _0024act_0024t_0024379;
				if (_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index < 0 || _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index >= _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length)
				{
					RuntimeDebugModeGuiMixin.label("ダメージログがありません");
				}
				else
				{
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewDamageLogs_0024closure_00243482_0024closure_00243483(_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024).Invoke));
					RuntimeDebugModeGuiMixin.space(10);
					if (_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index == _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length - 1)
					{
						RuntimeDebugModeGuiMixin.label(new StringBuilder("最新ダメージ計算ログ (番号:").Append((object)_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index).Append(")").ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.label(new StringBuilder().Append((object)(_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length - _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index - 1)).Append("つ前のダメージ計算ログ (番号:").Append((object)_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index)
							.Append(")")
							.ToString());
					}
					string[] logs = _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs;
					RuntimeDebugModeGuiMixin.textArea(logs[RuntimeServices.NormalizeArrayIndex(logs, _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index)]);
				}
			});
			actionClassviewDamageLogs._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable234_0024105_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002442.Adapt(delegate
			{
				if (RuntimeDebugModeGuiMixin.InputBack)
				{
					mainMode();
				}
			});
			return actionClassviewDamageLogs;
		}
	}

	public ActionClassviewDamageLogs createviewDamageLogs()
	{
		return createDataviewDamageLogs();
	}

	public ActionClasseditPlayer editPlayer(PlayerControl pl)
	{
		ActionClasseditPlayer actionClasseditPlayer = createeditPlayer(pl);
		changeAction(actionClasseditPlayer);
		return actionClasseditPlayer;
	}

	public ActionClasseditPlayer createDataeditPlayer()
	{
		ActionClasseditPlayer actionClasseditPlayer = new ActionClasseditPlayer();
		actionClasseditPlayer._0024act_0024t_0024364 = ActionEnum.editPlayer;
		actionClasseditPlayer._0024act_0024t_0024365 = "$default$";
		actionClasseditPlayer._0024act_0024t_0024366 = _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443.Adapt(delegate(ActionClasseditPlayer _0024act_0024t_0024382)
		{
			_0024act_0024t_0024382.vpadMoveThIndex = 0;
			_0024act_0024t_0024382.speedIndex = 0;
			_0024act_0024t_0024382.distIndex = 0;
			PlayerInputControlByVirtualPad.MoveStartDistThreashold = 15f;
		});
		actionClasseditPlayer._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443.Adapt(delegate(ActionClasseditPlayer _0024act_0024t_0024382)
		{
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024 = new _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296();
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382 = _0024act_0024t_0024382;
			if (!(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl == null))
			{
				if (RuntimeDebugModeGuiMixin.button("今スグ死ぬ"))
				{
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.HitAttack(9999999, YarareTypes.Down, null);
				}
				if (RuntimeDebugModeGuiMixin.button("りば〜いぶ"))
				{
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.reviveForContinue();
				}
				if (RuntimeDebugModeGuiMixin.button("試しでdestroy"))
				{
					UnityEngine.Object.Destroy(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
					mainMode();
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl = null;
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("全MotionPack.Entry情報"))
					{
						viewMotPackControl(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Mmpc, new __DebugSubSkill__0024createDataeditPlayer_0024closure_00243486_0024callable435_0024160_35__(new _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243487(this, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024).Invoke));
					}
					RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillBeforeChangeMethod, "転身処理直前に死ぬ");
						RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillInChangeMethod, "転身処理中に死ぬ");
						RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillAfterChangeMethod, "転身直後死");
					});
					RuntimeDebugModeGuiMixin.label("PLAYER: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.gameObject.name);
					RuntimeDebugModeGuiMixin.slabel("POS: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MYPOS);
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("HP: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.HitPoint).Append("/").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MaxHitPoint)
						.ToString());
					RuntimeDebugModeGuiMixin.slabel("SetupType: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SetupType);
					RuntimeDebugModeGuiMixin.slabel("EQUIPS:");
					RuntimeDebugModeGuiMixin.slabel("  Tenshi:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsTensi + " Akuma:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsAkuma);
					RuntimeDebugModeGuiMixin.slabel("  Main: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.getMainWeapon());
					RespWeapon[] subWeapons = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SubWeapons;
					int i = 0;
					RespWeapon[] subWeapons2 = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SubWeapons;
					checked
					{
						for (int length = subWeapons2.Length; i < length; i++)
						{
							RuntimeDebugModeGuiMixin.slabel("  Sub: " + subWeapons2[i]);
						}
						WeaponEquipments weaponEquipments = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.weaponEquipments;
						RuntimeDebugModeGuiMixin.space(10);
						RuntimeDebugModeGuiMixin.label("WeaponEquipments:");
						RuntimeDebugModeGuiMixin.slabel("  Current Race: " + weaponEquipments.Race);
						int j = 0;
						RACE_TYPE[] array = new RACE_TYPE[2]
						{
							RACE_TYPE.Tensi,
							RACE_TYPE.Akuma
						};
						for (int length2 = array.Length; j < length2; j++)
						{
							RuntimeDebugModeGuiMixin.slabel("   *" + array[j] + " equipments");
							RespWeapon mainWeapon = weaponEquipments.getMainWeapon(array[j]);
							RuntimeDebugModeGuiMixin.slabel("     wpn HP: " + weaponEquipments.weaponHP(array[j]) + "  ATK: " + weaponEquipments.weaponAtk(array[j]));
							RuntimeDebugModeGuiMixin.slabel("     ppt HP: " + weaponEquipments.supportPoppetHP(array[j]) + "  ATK: " + weaponEquipments.supportPoppetAttack(array[j]));
							RuntimeDebugModeGuiMixin.slabel("     Main: " + mainWeapon);
							subWeapons = weaponEquipments.getSubWeapons(array[j]);
							int k = 0;
							RespWeapon[] array2 = subWeapons;
							for (int length3 = array2.Length; k < length3; k++)
							{
								RuntimeDebugModeGuiMixin.slabel("     Sub: " + array2[k]);
							}
							RespPoppet[] subPoppets = weaponEquipments.getSubPoppets(array[j]);
							int l = 0;
							RespPoppet[] array3 = subPoppets;
							for (int length4 = array3.Length; l < length4; l++)
							{
								RuntimeDebugModeGuiMixin.slabel("     Sub Poppet: " + array3[l]);
							}
						}
						RuntimeDebugModeGuiMixin.space(10);
						if (RuntimeDebugModeGuiMixin.button(new StringBuilder("バトルモード切り換え: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.battleMode).ToString()))
						{
							_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ToggleBattleMode();
						}
						RuntimeDebugModeGuiMixin.space(10);
					}
					int num = RuntimeDebugModeGuiMixin.grid((int)PlayerControl.ForceToSetInputType, new string[4] { "ディフォルト", "タッチ", "コントローラー", "バーチャルパッド" }, 2);
					if (num != (int)PlayerControl.ForceToSetInputType)
					{
						PlayerControl.ForceToSetInputType = (PlayerInputControlType)num;
					}
					RuntimeDebugModeGuiMixin.space(10);
					string[] array4 = new string[12]
					{
						"10", "15", "20", "25", "30", "40", "50", "60", "70", "80",
						"90", "100"
					};
					int[] array5 = new int[12]
					{
						10, 15, 20, 25, 30, 40, 50, 60, 70, 80,
						90, 100
					};
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex, new string[12]
					{
						"10", "15", "20", "25", "30", "40", "50", "60", "70", "80",
						"90", "100"
					}, 5);
					PlayerInputControlByVirtualPad.MoveStartDistThreashold = array5[RuntimeServices.NormalizeArrayIndex(array5, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex)];
					RuntimeDebugModeGuiMixin.space(10);
					string[] array6 = new string[10] { "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000" };
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = Array.FindIndex(array6, (string v) => v == InputSwipeRecognizer.MIN_VELOCITY.ToString());
					if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex < 0)
					{
						_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = 0;
					}
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex, array6, 5);
					InputSwipeRecognizer.MIN_VELOCITY = int.Parse(array6[RuntimeServices.NormalizeArrayIndex(array6, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex)]);
					RuntimeDebugModeGuiMixin.space(10);
					string[] array7 = new string[10] { "20", "30", "40", "50", "60", "70", "80", "90", "100", "110" };
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = Array.FindIndex(array7, (string v) => v == InputSwipeRecognizer.MIN_DISTANCE.ToString());
					if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex < 0)
					{
						_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = 0;
					}
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex, array7, 5);
					InputSwipeRecognizer.MIN_DISTANCE = int.Parse(array7[RuntimeServices.NormalizeArrayIndex(array7, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex)]);
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("スキルクールダウン");
					CooldownValue[] cooldowns = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Cooldowns;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  武器スキル: ready:").Append(cooldowns[0].IsReady).Append(" curr:").Append(cooldowns[0].Current)
						.Append(" heattim:")
						.Append(cooldowns[0].HeatTime)
						.Append(" scale:")
						.Append(cooldowns[0].DecreaseScale)
						.ToString());
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  転身: ready:").Append(cooldowns[2].IsReady).Append(" curr:").Append(cooldowns[2].Current)
						.Append(" heattim:")
						.Append(cooldowns[2].HeatTime)
						.Append(" scale:")
						.Append(cooldowns[2].DecreaseScale)
						.ToString());
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("コントローラ:" + DeviceController.Instance.IsPlugged);
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  接続済み入力:").Append((object)DeviceController.Instance.JoyNames.Length).Append("個").ToString());
					RuntimeDebugModeGuiMixin.slabel("  on:" + DeviceController.Instance.On);
					RuntimeDebugModeGuiMixin.slabel("  up:" + DeviceController.Instance.Up);
					RuntimeDebugModeGuiMixin.slabel("  down:" + DeviceController.Instance.Down);
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("入力管理:");
					PlayerInputControl inputControl = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl;
					if (inputControl is PlayerInputControlByTouch)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [タッチ入力モード] working:").Append(inputControl.Working).ToString());
					}
					else if (inputControl is PlayerInputControlByController)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [コントローラ入力モード] working:").Append(inputControl.Working).ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [不明入力:").Append(inputControl).Append("] working:").Append(inputControl.Working)
							.ToString());
					}
					PlayerInputControlByTouch playerInputControlByTouch = inputControl as PlayerInputControlByTouch;
					if (playerInputControlByTouch != null)
					{
						TouchMarker marker = playerInputControlByTouch.Marker;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  marker: ").Append(marker.IsMarked).Append(" ").Append(marker.MarkedPos)
							.ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ctouch: ").Append(playerInputControlByTouch.CurTouch).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ptouch: ").Append(playerInputControlByTouch.PreTouch).ToString());
						TouchRayInfo curRayInfo = playerInputControlByTouch.CurRayInfo;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray any   : ").Append(curRayInfo.Any).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray plane : ").Append(curRayInfo.Plane).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray enemy : ").Append(curRayInfo.Enemy).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray poppet: ").Append(curRayInfo.Poppet).ToString());
						ConditionalTimer runStopTimer = playerInputControlByTouch.RunStopTimer;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  run stop: ").Append(runStopTimer.Enabled).Append(" ").Append(runStopTimer.Timer)
							.Append(" ")
							.ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  dispacement: ").Append(playerInputControlByTouch.DisplacementMeasure.length).ToString());
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(inputControl).ToString());
					}
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("ロックオン:");
					PlayerLockOnControl lockOnControl = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.LockOnControl;
					if (lockOnControl != null)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsLockedOn: ").Append(lockOnControl.IsLockedOn).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Player: ").Append(lockOnControl.Player).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Target: ").Append(lockOnControl.Target).ToString());
					}
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("マーカー(タッチコントロールのみ)");
					if (playerInputControlByTouch != null)
					{
						TouchMarker marker = playerInputControlByTouch.Marker;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsMarked: ").Append(marker.IsMarked).ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Pos: ").Append(marker.MarkedPos).ToString());
					}
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("ActionInput:");
					MerlinActionInput actionInput = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput.CurrentInput).ToString());
					RuntimeDebugModeGuiMixin.space(10);
					showAbnormalStateInfo(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
					RuntimeDebugModeGuiMixin.space(10);
					showAreaDamageInfo(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
					RuntimeDebugModeGuiMixin.space(20);
					if (RuntimeDebugModeGuiMixin.button("モーションパック状況"))
					{
						motionPackView(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
					}
					RuntimeDebugModeGuiMixin.space(20);
					RuntimeDebugModeGuiMixin.label("色々フラグ等");
					RuntimeDebugModeGuiMixin.slabel("IsReady: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsReady);
					RuntimeDebugModeGuiMixin.slabel("IsDead: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsDead);
					RuntimeDebugModeGuiMixin.slabel("Pause: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Pause);
					RuntimeDebugModeGuiMixin.slabel("UpdateDeltaTime: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.UpdateDeltaTime);
					RuntimeDebugModeGuiMixin.slabel("FixedUpdateDeltaTime: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.FixedUpdateDeltaTime);
					RuntimeDebugModeGuiMixin.slabel("IsJustDodge: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsJustDodge);
					RuntimeDebugModeGuiMixin.slabel("DisableFaceMovement: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.DisableFaceMovement);
					RuntimeDebugModeGuiMixin.slabel("MovementScale: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MovementScale);
					RuntimeDebugModeGuiMixin.slabel("MoveSpeed: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MoveSpeed);
					MerlinCharParameters charParameters = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.CharParameters;
					RuntimeDebugModeGuiMixin.slabel("CharParameters:");
					RuntimeDebugModeGuiMixin.slabel("   NoKnockBack: " + charParameters.NoKnockBack);
					RuntimeDebugModeGuiMixin.slabel("   NoThrow: " + charParameters.NoThrow);
					RuntimeDebugModeGuiMixin.slabel("   NoBaseMode: " + charParameters.NoBaseMode);
					MerlinActionParameters actionParameters = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionParameters;
					RuntimeDebugModeGuiMixin.slabel("ActionParameters:");
					RuntimeDebugModeGuiMixin.slabel("   guard: " + actionParameters.guard);
					RuntimeDebugModeGuiMixin.slabel("   noAttackHit: " + actionParameters.noAttackHit);
					RuntimeDebugModeGuiMixin.slabel("   HitCancelCount: " + actionParameters.HitCancelCount);
					RuntimeDebugModeGuiMixin.space(10);
					PlayerControl.KaihiTimeInfo kaihiTime = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.KaihiTime;
					RuntimeDebugModeGuiMixin.slabel("KaihiTime:");
					RuntimeDebugModeGuiMixin.slabel("   enabled: " + kaihiTime.enabled);
					RuntimeDebugModeGuiMixin.slabel("   start: " + kaihiTime.start);
					RuntimeDebugModeGuiMixin.slabel("   end: " + kaihiTime.end);
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.slabel("MoveCommandSpeedScale: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MoveCommandSpeedScale);
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.slabel("InputActive: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputActive);
					RuntimeDebugModeGuiMixin.slabel("InputControl: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl);
					RuntimeDebugModeGuiMixin.slabel("ActionInput: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput);
					if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl != null)
					{
						RuntimeDebugModeGuiMixin.slabel("   InputControl GetType: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.GetType());
						RuntimeDebugModeGuiMixin.slabel("   InputControl.ActionInput: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.ActionInput);
						RuntimeDebugModeGuiMixin.slabel("   InputControl.Working: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.Working);
						RuntimeDebugModeGuiMixin.slabel("   InputControl.Type: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.Type);
					}
					RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DispPlayerInputControlInfo, "DispPlayerInputControlInfo");
					RuntimeDebugModeGuiMixin.space(20);
					RuntimeDebugModeGuiMixin.label("HUD更新フレーム間隔");
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex, new string[20]
					{
						"1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
						"11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
					}, 5);
					PlayerControl.HudUpdateStep = checked(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex + 1);
					RuntimeDebugModeGuiMixin.space(20);
					RuntimeDebugModeGuiMixin.label("auto battle/run");
					_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoBattle;
					RuntimeDebugModeGuiMixin.slabel("Player.EnableAuto: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.EnableAuto + " / AutoBattle.enabled: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.enabled);
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("AutoSkillMode: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.AutoSkillMode).Append(" AutoBattleSpeed: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.AutoBattleSpeed)
						.ToString());
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243491(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024).Invoke));
					RuntimeDebugModeGuiMixin.slabel("IsReadyPlayerChange: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyPlayerChange());
					RuntimeDebugModeGuiMixin.slabel("IsReadyChainSklilforQueuing: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyChainSklilforQueuing());
					RuntimeDebugModeGuiMixin.slabel("GetReadyChainSkill: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetReadyChainSkill());
					RuntimeDebugModeGuiMixin.slabel("IsReadyWeaponSkill: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyWeaponSkill());
					RuntimeDebugModeGuiMixin.slabel("IsSetupWeaponSkillCondition: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsSetupWeaponSkillCondition());
					RuntimeDebugModeGuiMixin.slabel("IsSetupWeaponSkillCondition(alt): " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsSetupWeaponSkillCondition(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AltWeaponSkill));
					int num2 = 0;
					while (num2 < 2)
					{
						int num3 = num2;
						num2++;
						MChainSkills mChainSkills = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetMChainSkills(num3);
						RuntimeDebugModeGuiMixin.slabel("chainskill: " + mChainSkills);
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("chainskill ").Append((object)num3).Append(" enemy cond: ").ToString() + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsChainSkillEnemyConditionOk(mChainSkills));
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("chainskill ").Append((object)num3).Append(" status cond: ").ToString() + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsChainSkillStatusConditionOk(mChainSkills, num3));
					}
					MWeaponSkills mWeaponSkills = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetMWeaponSkills();
					RuntimeDebugModeGuiMixin.slabel("weaponskill: " + mWeaponSkills);
					RuntimeDebugModeGuiMixin.slabel("weaponskill enemy cond: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsWeaponSkillEnemyConditionOk(mWeaponSkills));
					RuntimeDebugModeGuiMixin.slabel("weaponskill status cond: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsWeaponSkillStatusConditionOk(mWeaponSkills));
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.slabel("current action:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.CurrentAction);
					RuntimeDebugModeGuiMixin.slabel("actionQueue:");
					foreach (AutoBattleAction item in _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.ActionAutoBattleQueue)
					{
						RuntimeDebugModeGuiMixin.slabel("   " + item);
					}
					RuntimeDebugModeGuiMixin.space(10);
					RuntimeDebugModeGuiMixin.label("PlayerAutoFlowController");
					PlayerAutoFlowController autoFlowController = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoFlowController;
					if (autoFlowController != null)
					{
						RuntimeDebugModeGuiMixin.slabel("  enabled=" + autoFlowController.enabled + " HasPlayer=" + (autoFlowController.Player != null));
						RuntimeDebugModeGuiMixin.slabel("  IsAuto=" + autoFlowController.IsAuto + " ChangedAuto=" + autoFlowController.ChangedAuto);
						RuntimeDebugModeGuiMixin.slabel("  IsAutoCondition=" + autoFlowController.IsAutoCondition());
						RuntimeDebugModeGuiMixin.slabel("  MappedQuest=" + autoFlowController.MappedQuest);
						RuntimeDebugModeGuiMixin.slabel("  CurrentPoint=" + autoFlowController.CurrentPointIndex);
						if (RuntimeDebugModeGuiMixin.button("ProcessEvent()"))
						{
							autoFlowController.ProcessEvent();
						}
					}
					RuntimeDebugModeGuiMixin.space(10);
					CharacterPathFinder charPathFinder = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.CharPathFinder;
					RuntimeDebugModeGuiMixin.slabel("charPathFinder");
					RuntimeDebugModeGuiMixin.slabel("  isMovement:" + charPathFinder.IsMovement);
					RuntimeDebugModeGuiMixin.slabel("  path length:" + charPathFinder.PathLength);
					RuntimeDebugModeGuiMixin.slabel("  cal path length:" + charPathFinder.CalPathLength);
					RuntimeDebugModeGuiMixin.slabel("  fVerifyLength:" + charPathFinder.fVerifyLength);
					RuntimeDebugModeGuiMixin.slabel("  PathModify:" + charPathFinder.PathModify);
					RuntimeDebugModeGuiMixin.slabel("  MoreModify:" + charPathFinder.MoreModify);
					RuntimeDebugModeGuiMixin.slabel("  DebugLine:" + charPathFinder.DebugLine);
					RuntimeDebugModeGuiMixin.slabel("  RemoveNodeList:" + charPathFinder.RemoveNodeList.Count);
					RuntimeDebugModeGuiMixin.slabel("  fVerifyLength:" + charPathFinder.fVerifyLength);
					if (RuntimeDebugModeGuiMixin.button("draw path toggle"))
					{
						charPathFinder.DebugLine = !charPathFinder.DebugLine;
					}
					RuntimeDebugModeGuiMixin.space(10);
					QuestRouteFinder routeFinder = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoFlowController.RouteFinder;
					RuntimeDebugModeGuiMixin.slabel("QuestRouteFinder");
					RuntimeDebugModeGuiMixin.slabel("  quest:" + routeFinder.Quest);
					RuntimeDebugModeGuiMixin.slabel("  AutoRunOn:" + routeFinder.AutoRunOn);
					int num4 = 0;
					foreach (AbstractEventPoint item2 in routeFinder.Route)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   [").Append((object)num4).Append("] ").ToString() + item2);
						num4 = checked(num4 + 1);
					}
					RuntimeDebugModeGuiMixin.space(10);
					Pathfinder instance = Pathfinder.Instance;
					RuntimeDebugModeGuiMixin.slabel("Pathfinder:");
					if (instance != null)
					{
						RuntimeDebugModeGuiMixin.slabel("  base object: " + instance.gameObject);
						RuntimeDebugModeGuiMixin.slabel("  queue count: " + instance.QueueNum);
						instance.enumerateQueue(delegate(QueuePath qp)
						{
							RuntimeDebugModeGuiMixin.slabel("     " + qp);
						});
						Node tileNode = instance.GetTileNode(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MYPOS);
						RuntimeDebugModeGuiMixin.slabel("現在の場所のNode: " + tileNode);
						RuntimeDebugModeGuiMixin.slabel("  parent:" + ((tileNode.parent == null) ? "<null>" : ((object)tileNode.parent.ID)));
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  F:").Append((object)tileNode.F).Append(" H:").Append((object)tileNode.H)
							.Append(" G:")
							.Append((object)tileNode.G)
							.ToString());
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  sortedIndex:").Append((object)tileNode.sortedIndex).ToString());
						if (RuntimeDebugModeGuiMixin.button("現在の場所のyを設定する"))
						{
							tileNode.yCoord = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.transform.position.y;
						}
						if (RuntimeDebugModeGuiMixin.button("現在の場所をwalkableにする"))
						{
							tileNode.walkable = true;
						}
						if (RuntimeDebugModeGuiMixin.button("現在の場所をun-walkableにする"))
						{
							tileNode.walkable = false;
						}
						if (RuntimeDebugModeGuiMixin.button("現在のtileを保存"))
						{
							instance.SaveTileFileAsCurrentSceneData();
						}
					}
				}
			}
		});
		actionClasseditPlayer._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable235_0024135_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002443.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasseditPlayer;
	}

	public ActionClasseditPlayer createeditPlayer(PlayerControl pl)
	{
		ActionClasseditPlayer actionClasseditPlayer = createDataeditPlayer();
		actionClasseditPlayer.pl = pl;
		actionClasseditPlayer.hudUpdateCountIndex = 0;
		return actionClasseditPlayer;
	}

	public ActionClassmotionPackView motionPackView(PlayerControl pl)
	{
		ActionClassmotionPackView actionClassmotionPackView = createmotionPackView(pl);
		changeAction(actionClassmotionPackView);
		return actionClassmotionPackView;
	}

	public ActionClassmotionPackView createDatamotionPackView()
	{
		ActionClassmotionPackView actionClassmotionPackView = new ActionClassmotionPackView();
		actionClassmotionPackView._0024act_0024t_0024364 = ActionEnum.motionPackView;
		actionClassmotionPackView._0024act_0024t_0024365 = "$default$";
		actionClassmotionPackView._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable236_0024453_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002444.Adapt(checked(delegate(ActionClassmotionPackView _0024act_0024t_0024385)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024385.pl).ToString());
			MerlinMotionPackControl mmpc = _0024act_0024t_0024385.pl.Mmpc;
			if (mmpc == null)
			{
				RuntimeDebugModeGuiMixin.label("no MMPC");
			}
			else
			{
				MerlinMotionPack[] allPacks = mmpc.AllPacks;
				RuntimeDebugModeGuiMixin.label("Packs: num=" + allPacks.Length);
				int num = 0;
				int i = 0;
				MerlinMotionPack[] array = allPacks;
				for (int length = array.Length; i < length; i++)
				{
					if (!(array[i] == null))
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("[").Append((object)num++).Append("]  pack ").Append(array[i])
							.Append(" entries=")
							.ToString() + array[i].entries.Length);
						int j = 0;
						MerlinMotionPack.Entry[] entries = array[i].entries;
						for (int length2 = entries.Length; j < length2; j++)
						{
							string text = string.Empty;
							int k = 0;
							string[] keywords = entries[j].keywords;
							for (int length3 = keywords.Length; k < length3; k++)
							{
								text += keywords[k] + " ";
							}
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(entries[j].name).Append(" clip:").Append(entries[j].clip)
								.Append(" -- ")
								.Append(text)
								.ToString());
						}
					}
				}
			}
		}));
		actionClassmotionPackView._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable236_0024453_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002444.Adapt(delegate(ActionClassmotionPackView _0024act_0024t_0024385)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				editPlayer(_0024act_0024t_0024385.pl);
			}
		});
		return actionClassmotionPackView;
	}

	public ActionClassmotionPackView createmotionPackView(PlayerControl pl)
	{
		ActionClassmotionPackView actionClassmotionPackView = createDatamotionPackView();
		actionClassmotionPackView.pl = pl;
		return actionClassmotionPackView;
	}

	public ActionClassviewSkills viewSkills(MerlinActionControl ch, ICallable back)
	{
		ActionClassviewSkills actionClassviewSkills = createviewSkills(ch, back);
		changeAction(actionClassviewSkills);
		return actionClassviewSkills;
	}

	public ActionClassviewSkills createDataviewSkills()
	{
		ActionClassviewSkills actionClassviewSkills = new ActionClassviewSkills();
		actionClassviewSkills._0024act_0024t_0024364 = ActionEnum.viewSkills;
		actionClassviewSkills._0024act_0024t_0024365 = "$default$";
		actionClassviewSkills._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable237_0024476_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002445.Adapt(delegate(ActionClassviewSkills _0024act_0024t_0024388)
		{
			_0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297 _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024 = new _0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297();
			_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388 = _0024act_0024t_0024388;
			PlayerSkillEffectControl skillEffectControl = _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.SkillEffectControl;
			SkillEffectData currentData = skillEffectControl.CurrentData;
			PlayerControl playerControl = _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch as PlayerControl;
			RuntimeDebugModeGuiMixin.label("CHARACTER: " + _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.gameObject.name);
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("ダメージ計算機用パラメータ"))
			{
				viewDamageCharData(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewSkills_0024closure_00243497_0024closure_00243498(this, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024).Invoke));
			}
			else
			{
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.label("非攻撃系スキル効果状態");
				RuntimeDebugModeGuiMixin.slabel("  スキルクールダウン率: " + currentData.skillCoolDownRate);
				RuntimeDebugModeGuiMixin.slabel("  回避成功時クールダウン回復秒: " + currentData.kaihiSkillCoolDownVal);
				RuntimeDebugModeGuiMixin.slabel("  candyのHP回復率: " + currentData.candyRecoveryRate);
				RuntimeDebugModeGuiMixin.slabel("  candyの魔力回復量: " + currentData.candyMagicRecoveryValue);
				RuntimeDebugModeGuiMixin.slabel("  dodge時間加算: " + currentData.justDodgeTimeBonus);
				RuntimeDebugModeGuiMixin.slabel("  移動速度倍率: " + currentData.speedMult);
				RuntimeDebugModeGuiMixin.slabel("  MOVEコマンド移動倍率: " + currentData.moveCommandSpeedMult);
				RuntimeDebugModeGuiMixin.slabel("  初期HP倍率: " + currentData.hpMult);
				RuntimeDebugModeGuiMixin.slabel("  初期HP加算: " + currentData.hpAdd);
				RuntimeDebugModeGuiMixin.slabel("  ダメージエリア無効化: " + currentData.invalidateDamageArea);
				RuntimeDebugModeGuiMixin.slabel("  足おそエリア無効化: " + currentData.invalidateSlowArea);
				RuntimeDebugModeGuiMixin.slabel("  引力エリア無効化: " + currentData.invalidateGravityArea);
				RuntimeDebugModeGuiMixin.slabel("  ダメージ時の魔力回復倍率: " + currentData.mpRecoveryRateWhenDamaged);
				RuntimeDebugModeGuiMixin.slabel("  回避成功時の魔力回復量: " + currentData.mpRecoveryValueWhenKaihi);
				RuntimeDebugModeGuiMixin.slabel("  攻撃成功時の魔力回復倍率: " + currentData.mpRecoveryRateWhenAttack);
				RuntimeDebugModeGuiMixin.slabel("  敵抹殺時HP回復量: " + currentData.hpRecoveryValueWhenKilled);
				RuntimeDebugModeGuiMixin.slabel("  転身クールダウン短縮秒: " + currentData.changeCoolDownDecTime);
				RuntimeDebugModeGuiMixin.slabel("  フルガードモード: " + currentData.fullGuard);
				RuntimeDebugModeGuiMixin.slabel("  スタンド「ザワールド」的能力: " + currentData.stopWorld);
				RuntimeDebugModeGuiMixin.space(10);
				Boo.Lang.List<SkillEffector> allSkills = skillEffectControl.AllSkills;
				RuntimeDebugModeGuiMixin.label("エフェクタリスト");
				RuntimeDebugModeGuiMixin.slabel("※表示不能:ダメージ乗算補正,(敵)防御補正,攻撃成功時HP回復");
				if (((ICollection)allSkills).Count > 0)
				{
					IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							SkillEffector current = enumerator.Current;
							SkillEffectParameters skileff = current.skileff;
							RuntimeDebugModeGuiMixin.label("==================");
							RuntimeDebugModeGuiMixin.slabel("スキル効果: " + skileff.MSkillEffectTypeId.Progname);
							RuntimeDebugModeGuiMixin.slabel("origin:" + current.Origin);
							if (current.HasExpiration)
							{
								RuntimeDebugModeGuiMixin.slabel("  残り時間: " + current.ExpirationTime);
							}
							else
							{
								RuntimeDebugModeGuiMixin.slabel("  残り時間: 恒久的");
							}
							RuntimeDebugModeGuiMixin.slabel("  効果値: " + current.EffValue);
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  level/max: ").Append((object)current.level).Append("/").Append((object)current.levelMax)
								.ToString());
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  min/max/exp: ").Append((object)skileff.ValueMin).Append("/").Append((object)skileff.ValueMax)
								.Append("/")
								.Append(skileff.ValueExp)
								.ToString());
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  powerBase: ").Append(current.powerBase).ToString());
							RuntimeDebugModeGuiMixin.slabel("  対象属性: " + skileff.Element);
							RuntimeDebugModeGuiMixin.slabel("  対象スタイル: " + skileff.Style);
							RuntimeDebugModeGuiMixin.slabel("  対象種族: " + skileff.Race);
							RuntimeDebugModeGuiMixin.slabel("  上限HP: " + skileff.UnderHP);
							RuntimeDebugModeGuiMixin.slabel("  状態異常: " + skileff.AbnormalState);
							RuntimeDebugModeGuiMixin.slabel("  個数: " + skileff.Count);
							RuntimeDebugModeGuiMixin.slabel("  率: " + skileff.Rate);
							RuntimeDebugModeGuiMixin.slabel("  対象属性(2): " + skileff.ElementPrm1 + " " + skileff.ElementPrm2);
							RuntimeDebugModeGuiMixin.slabel("  クリティカル乗算: " + current.criticalRateMult(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.HitPointRate, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.IsTensi, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.IsAkuma));
							RuntimeDebugModeGuiMixin.slabel("  クリティカル率(連携)強制設定): " + current.maximumChainCriticalRate());
							if (playerControl != null)
							{
								RuntimeDebugModeGuiMixin.slabel("  攻撃力乗算(playerのみ): " + current.attackMult(playerControl.HasAnyAbnormalState, playerControl.getMainWeapon().Style));
								RuntimeDebugModeGuiMixin.slabel("  攻撃力加算(playerのみ): " + current.attackPlus(playerControl.HasAnyAbnormalState, playerControl.getMainWeapon().Style, playerControl.getMainWeapon().Element));
							}
							RuntimeDebugModeGuiMixin.slabel("  崩しスキル補正: " + current.yarareResistPlus());
							RuntimeDebugModeGuiMixin.slabel("  モンスター防御力乗算: " + current.enemyDefenseMult());
							RuntimeDebugModeGuiMixin.slabel("  ダメージ補正値(damage 100時): " + current.finalDamageAdjust(100f, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.HitPoint));
							Boo.Lang.List<EnumAbnormalStates> list = new Boo.Lang.List<EnumAbnormalStates>();
							IEnumerator enumerator2 = Enum.GetValues(typeof(EnumAbnormalStates)).GetEnumerator();
							while (enumerator2.MoveNext())
							{
								EnumAbnormalStates enumAbnormalStates = (EnumAbnormalStates)enumerator2.Current;
								if (current.canResistAbnormalState(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch, enumAbnormalStates))
								{
									list.Add(enumAbnormalStates);
								}
							}
							RuntimeDebugModeGuiMixin.slabel("  レジスト可能状態異常: " + Builtins.join(list));
							RuntimeDebugModeGuiMixin.space(10);
							int i = 0;
							EnumElements[] array = new EnumElements[4]
							{
								EnumElements.fire,
								EnumElements.water,
								EnumElements.wind,
								EnumElements.earth
							};
							for (int length = array.Length; i < length; i = checked(i + 1))
							{
								float num = current.attackDamageMult(playerControl, array[i], EnumRaces.beast, enGuard: false, enElite: false, isCritical: false, null);
								RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ダメージ倍率(").Append(array[i]).Append("/beast/!guard/!elite/!critical: ").ToString() + num);
							}
						}
						return;
					}
					finally
					{
						enumerator.Dispose();
					}
				}
				RuntimeDebugModeGuiMixin.label("エフェクタ無し");
			}
		});
		actionClassviewSkills._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable237_0024476_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002445.Adapt(delegate(ActionClassviewSkills _0024act_0024t_0024388)
		{
			if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024388.back != null)
			{
				_0024act_0024t_0024388.back.Call(new object[0]);
			}
		});
		return actionClassviewSkills;
	}

	public ActionClassviewSkills createviewSkills(MerlinActionControl ch, ICallable back)
	{
		ActionClassviewSkills actionClassviewSkills = createDataviewSkills();
		actionClassviewSkills.ch = ch;
		actionClassviewSkills.back = back;
		return actionClassviewSkills;
	}

	public ActionClassviewDamageCharData viewDamageCharData(MerlinActionControl ch, ICallable back)
	{
		ActionClassviewDamageCharData actionClassviewDamageCharData = createviewDamageCharData(ch, back);
		changeAction(actionClassviewDamageCharData);
		return actionClassviewDamageCharData;
	}

	public ActionClassviewDamageCharData createDataviewDamageCharData()
	{
		ActionClassviewDamageCharData actionClassviewDamageCharData = new ActionClassviewDamageCharData();
		actionClassviewDamageCharData._0024act_0024t_0024364 = ActionEnum.viewDamageCharData;
		actionClassviewDamageCharData._0024act_0024t_0024365 = "$default$";
		actionClassviewDamageCharData._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable238_0024558_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002446.Adapt(delegate(ActionClassviewDamageCharData _0024act_0024t_0024391)
		{
			if (_0024act_0024t_0024391.ch.HasPoppetData)
			{
				RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ(ppt): " + _0024act_0024t_0024391.ch.PoppetData);
			}
			else if (_0024act_0024t_0024391.ch.HasMonsterData)
			{
				RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ(mon): " + _0024act_0024t_0024391.ch.MonsterData);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ:" + _0024act_0024t_0024391.ch.gameObject);
			}
			IDamageCalcCharData damageCalcCharData = _0024act_0024t_0024391.ch.DamageCalcCharData;
			RuntimeDebugModeGuiMixin.slabel("element: " + damageCalcCharData.element());
			RuntimeDebugModeGuiMixin.slabel("style: " + damageCalcCharData.style());
			RuntimeDebugModeGuiMixin.slabel("race: " + damageCalcCharData.race());
			RuntimeDebugModeGuiMixin.slabel("weakStyle: " + damageCalcCharData.weakStyle());
			RuntimeDebugModeGuiMixin.slabel("hitPoint: " + damageCalcCharData.hitPoint());
			RuntimeDebugModeGuiMixin.slabel("maxHitPoint: " + damageCalcCharData.maxHitPoint());
			RuntimeDebugModeGuiMixin.slabel("hitPointRate: " + damageCalcCharData.hitPointRate());
			RuntimeDebugModeGuiMixin.slabel("isPlayer: " + damageCalcCharData.isPlayer());
			RuntimeDebugModeGuiMixin.slabel("isTensi: " + damageCalcCharData.isTensi());
			RuntimeDebugModeGuiMixin.slabel("isAkuma: " + damageCalcCharData.isAkuma());
			RuntimeDebugModeGuiMixin.slabel("isInJustDodge: " + damageCalcCharData.isInJustDodge());
			RuntimeDebugModeGuiMixin.slabel("isGuarding: " + damageCalcCharData.isGuarding());
			RuntimeDebugModeGuiMixin.slabel("isElite: " + damageCalcCharData.isElite());
			RuntimeDebugModeGuiMixin.slabel("isDead: " + damageCalcCharData.isDead());
			RuntimeDebugModeGuiMixin.slabel("attack: " + damageCalcCharData.attack());
			RuntimeDebugModeGuiMixin.slabel("resist: " + damageCalcCharData.resist());
			RuntimeDebugModeGuiMixin.slabel("defense: " + damageCalcCharData.defense());
			RuntimeDebugModeGuiMixin.slabel("breakPow: " + damageCalcCharData.breakPow());
			RuntimeDebugModeGuiMixin.slabel("critical: " + damageCalcCharData.critical());
			RuntimeDebugModeGuiMixin.slabel("needQuestPoppetRevice: " + damageCalcCharData.needQuestPoppetRevice());
			RuntimeDebugModeGuiMixin.slabel("needColosseumPoppetRevice: " + damageCalcCharData.needColosseumPoppetRevice());
			RuntimeDebugModeGuiMixin.slabel("hasAbnormalState: " + damageCalcCharData.hasAbnormalState());
			RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.isRaid: " + damageCalcCharData.getRaidBonusData().isRaid);
			RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.bonusWeaponElement: " + damageCalcCharData.getRaidBonusData().bonusWeaponElement);
			RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.bonusWeaponStyle: " + damageCalcCharData.getRaidBonusData().bonusWeaponStyle);
			RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.comboBonus: " + damageCalcCharData.getRaidBonusData().comboBonus);
		});
		actionClassviewDamageCharData._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable238_0024558_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002446.Adapt(delegate(ActionClassviewDamageCharData _0024act_0024t_0024391)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				if (_0024act_0024t_0024391.back != null)
				{
					_0024act_0024t_0024391.back.Call(new object[0]);
				}
				else
				{
					mainMode();
				}
			}
		});
		return actionClassviewDamageCharData;
	}

	public ActionClassviewDamageCharData createviewDamageCharData(MerlinActionControl ch, ICallable back)
	{
		ActionClassviewDamageCharData actionClassviewDamageCharData = createDataviewDamageCharData();
		actionClassviewDamageCharData.ch = ch;
		actionClassviewDamageCharData.back = back;
		return actionClassviewDamageCharData;
	}

	public ActionClassskillEditMode skillEditMode()
	{
		ActionClassskillEditMode actionClassskillEditMode = createskillEditMode();
		changeAction(actionClassskillEditMode);
		return actionClassskillEditMode;
	}

	public ActionClassskillEditMode createDataskillEditMode()
	{
		ActionClassskillEditMode actionClassskillEditMode = new ActionClassskillEditMode();
		actionClassskillEditMode._0024act_0024t_0024364 = ActionEnum.skillEditMode;
		actionClassskillEditMode._0024act_0024t_0024365 = "$default$";
		actionClassskillEditMode._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable240_0024600_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002447.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("スキル効果強制追加");
			if (RuntimeDebugModeGuiMixin.button("以下の設定でスキル効果追加"))
			{
				emit();
			}
			RuntimeDebugModeGuiMixin.space(20);
			intSelect(ref valueMin, "ValueMin(連携系は魔力なので無意味)", new int[10] { 1, 2, 5, 10, 20, 50, 80, 100, 150, 200 });
			intSelect(ref valueMax, "ValueMax(連携系は魔力なので無意味)", new int[10] { 1, 2, 5, 10, 20, 50, 80, 100, 150, 200 });
			floatSelect(ref valueExp, "ValueExp(連携系は魔力なので無意味)", new float[5] { 0.5f, 0.8f, 1f, 1.2f, 1.5f });
			select(ref elementIndex, "属性", ArrayMap.AllEnumNames(typeof(EnumElements)));
			select(ref styleIndex, "スタイル", ArrayMap.AllEnumNames(typeof(EnumStyles)));
			select(ref raceIndex, "種族", ArrayMap.AllEnumNames(typeof(EnumRaces)));
			intSelect(ref level, "level", new int[5] { 1, 2, 4, 8, 16 });
			intSelect(ref levelMax, "levelMax", new int[5] { 1, 2, 4, 8, 16 });
			floatSelect(ref powerBase, "powerBase", new float[5] { 1f, 10f, 100f, 500f, 1000f });
			floatSelect(ref expirationTime, "expirationTime", new float[5] { 0f, 5f, 10f, 15f, 20f });
			intSelect(ref underHP, "UnderHP", new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 });
			intSelect(ref count, "Count", new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
			intSelect(ref rate, "Rate", new int[5] { 0, 25, 50, 75, 100 });
			select(ref elementIndex, "属性セット1", ArrayMap.AllEnumNames(typeof(EnumElements)));
			select(ref elementIndex, "属性セット2", ArrayMap.AllEnumNames(typeof(EnumElements)));
			RuntimeDebugModeGuiMixin.space(10);
			select(ref skillIndex, "スキル効果", ArrayMap.AllMSkillEffectTypesToStr((MSkillEffectTypes m) => new StringBuilder().Append((object)m.Id).ToString() + m.Progname), 1);
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("上記の設定でスキル効果追加"))
			{
				emit();
			}
		});
		actionClassskillEditMode._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable240_0024600_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002447.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassskillEditMode;
	}

	public ActionClassskillEditMode createskillEditMode()
	{
		return createDataskillEditMode();
	}

	private void emit()
	{
		PlayerControl playerControl = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
		if (!(playerControl == null))
		{
			SkillEffectParameters skillEffectParameters = new SkillEffectParameters();
			MSkillEffectTypes[] obj = (MSkillEffectTypes[])Builtins.array(typeof(MSkillEffectTypes), MSkillEffectTypes.All);
			skillEffectParameters.setField("MSkillEffectTypeId", obj[RuntimeServices.NormalizeArrayIndex(obj, skillIndex)].Id);
			skillEffectParameters.setField("ValueMin", valueMin);
			skillEffectParameters.setField("ValueMax", valueMax);
			skillEffectParameters.setField("ValueExp", valueExp);
			MElements[] obj2 = (MElements[])Builtins.array(typeof(MElements), MElements.All);
			skillEffectParameters.setField("MElementId", obj2[RuntimeServices.NormalizeArrayIndex(obj2, elementIndex)].Id);
			MStyles[] obj3 = (MStyles[])Builtins.array(typeof(MStyles), MStyles.All);
			skillEffectParameters.setField("MStyleId", obj3[RuntimeServices.NormalizeArrayIndex(obj3, styleIndex)].Id);
			MRaces[] obj4 = (MRaces[])Builtins.array(typeof(MRaces), MRaces.All);
			skillEffectParameters.setField("MRaceId", obj4[RuntimeServices.NormalizeArrayIndex(obj4, raceIndex)].Id);
			skillEffectParameters.setField("UnderHP", underHP);
			MAbnormalStates[] obj5 = (MAbnormalStates[])Builtins.array(typeof(MAbnormalStates), MAbnormalStates.All);
			skillEffectParameters.setField("MAbnormalStateId", obj5[RuntimeServices.NormalizeArrayIndex(obj5, abnormalStateIndex)].Id);
			skillEffectParameters.setField("Count", count);
			skillEffectParameters.setField("Rate", rate);
			PlayerSkillEffectControl skillEffectControl = playerControl.SkillEffectControl;
			SkillEffector skillEffector = skillEffectControl.createForDebug(skillEffectParameters, level, levelMax, powerBase, expirationTime);
			skillEffector.effectAtSkillEmission(null, playerControl);
			playerControl.recalcParametersFromWeaponsAndPoppets();
		}
	}

	private void intSelect(ref int var, string title, int[] valList)
	{
		RuntimeDebugModeGuiMixin.slabel(title);
		int length = valList.Length;
		int selected = 0;
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			if (valList[RuntimeServices.NormalizeArrayIndex(valList, num3)] == var)
			{
				selected = num3;
			}
		}
		selected = RuntimeDebugModeGuiMixin.grid(selected, ArrayMap.IntToStr(valList, (int v) => new StringBuilder().Append((object)v).ToString()), 5);
		RuntimeDebugModeGuiMixin.space(10);
		var = valList[RuntimeServices.NormalizeArrayIndex(valList, selected)];
	}

	private void floatSelect(ref float val, string title, float[] valList)
	{
		RuntimeDebugModeGuiMixin.slabel(title);
		int length = valList.Length;
		int selected = 0;
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			if (valList[RuntimeServices.NormalizeArrayIndex(valList, num3)] == val)
			{
				selected = num3;
			}
		}
		selected = RuntimeDebugModeGuiMixin.grid(selected, ArrayMap.SingleToStr(valList, _0024adaptor_0024__DeckColosseum_SetLimitIcon_0024callable92_0024194_113___0024__ArrayMap_SingleToStr_0024callable7_002488_59___002448.Adapt((int v) => new StringBuilder().Append((object)v).ToString())), 5);
		RuntimeDebugModeGuiMixin.space(10);
		val = valList[RuntimeServices.NormalizeArrayIndex(valList, selected)];
	}

	private void select(ref int index, string title, string[] vals)
	{
		select(ref index, title, vals, 4);
	}

	private void select(ref int index, string title, string[] vals, int hnum)
	{
		RuntimeDebugModeGuiMixin.slabel(title);
		index = RuntimeDebugModeGuiMixin.grid(index, vals, hnum);
	}

	public ActionClassviewMotPackList viewMotPackList()
	{
		ActionClassviewMotPackList actionClassviewMotPackList = createviewMotPackList();
		changeAction(actionClassviewMotPackList);
		return actionClassviewMotPackList;
	}

	public ActionClassviewMotPackList createDataviewMotPackList()
	{
		ActionClassviewMotPackList actionClassviewMotPackList = new ActionClassviewMotPackList();
		actionClassviewMotPackList._0024act_0024t_0024364 = ActionEnum.viewMotPackList;
		actionClassviewMotPackList._0024act_0024t_0024365 = "$default$";
		actionClassviewMotPackList._0024act_0024t_0024366 = _0024adaptor_0024__DebugSubModeSkill_0024callable241_0024697_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002449.Adapt(delegate(ActionClassviewMotPackList _0024act_0024t_0024397)
		{
			_0024act_0024t_0024397.motPacks = Resources.FindObjectsOfTypeAll<MerlinMotionPack>();
		});
		actionClassviewMotPackList._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable241_0024697_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002449.Adapt(delegate(ActionClassviewMotPackList _0024act_0024t_0024397)
		{
			RuntimeDebugModeGuiMixin.label("Motion Packs");
			int i = 0;
			MerlinMotionPack[] motPacks = _0024act_0024t_0024397.motPacks;
			for (int length = motPacks.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(motPacks[i]).Append(" - guid:").Append(ExtensionsModule.GetMyID(motPacks[i]))
					.ToString()))
				{
					viewMotPack(motPacks[i]);
				}
			}
		});
		actionClassviewMotPackList._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable241_0024697_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002449.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassviewMotPackList;
	}

	public ActionClassviewMotPackList createviewMotPackList()
	{
		return createDataviewMotPackList();
	}

	public ActionClassviewMotPackControl viewMotPackControl(MerlinMotionPackControl mmpc, ICallable back)
	{
		ActionClassviewMotPackControl actionClassviewMotPackControl = createviewMotPackControl(mmpc, back);
		changeAction(actionClassviewMotPackControl);
		return actionClassviewMotPackControl;
	}

	public ActionClassviewMotPackControl createDataviewMotPackControl()
	{
		ActionClassviewMotPackControl actionClassviewMotPackControl = new ActionClassviewMotPackControl();
		actionClassviewMotPackControl._0024act_0024t_0024364 = ActionEnum.viewMotPackControl;
		actionClassviewMotPackControl._0024act_0024t_0024365 = "$default$";
		actionClassviewMotPackControl._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable242_0024709_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002450.Adapt(delegate(ActionClassviewMotPackControl _0024act_0024t_0024400)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Motion Pack Control: ").Append(_0024act_0024t_0024400.mmpc).ToString());
			if (_0024act_0024t_0024400.mmpc == null)
			{
				return;
			}
			foreach (MerlinMotionPackControl.PackInfo packInfo in _0024act_0024t_0024400.mmpc.PackInfos)
			{
				RuntimeDebugModeGuiMixin.slabel("pack: " + packInfo.pack);
				RuntimeDebugModeGuiMixin.slabel("enabled: " + packInfo.enabled);
				RuntimeDebugModeGuiMixin.slabel("executer: " + packInfo.executer);
				MerlinMotionPack.Executer executer = packInfo.executer;
				if (executer != null)
				{
					RuntimeDebugModeGuiMixin.label("entries:");
					foreach (string key in executer.EntryDict.Keys)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key).Append(":").ToString());
						IEnumerator<MerlinMotionPack.Entry> enumerator3 = executer.EntryDict[key].GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								MerlinMotionPack.Entry current3 = enumerator3.Current;
								RuntimeDebugModeGuiMixin.slabel("      clip=" + current3.clip + " HasD540:" + current3.HasD540 + " asset=" + current3.assetPath + " kwd:" + Builtins.join(current3.keywords));
							}
						}
						finally
						{
							enumerator3.Dispose();
						}
					}
					RuntimeDebugModeGuiMixin.label("loaded sound:");
					D540RuntimeAssetResolver seLoader = executer.SeLoader;
					if (seLoader != null)
					{
						D540RuntimeAssetResolver.SEPool sePool = seLoader.SePool;
						if (sePool != null)
						{
							foreach (string key2 in sePool.loadedSEs.Keys)
							{
								int num = sePool.loadedSEID(key2);
								RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key2).Append(": seId=").Append((object)num)
									.ToString());
							}
						}
					}
				}
			}
		});
		actionClassviewMotPackControl._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable242_0024709_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002450.Adapt(delegate(ActionClassviewMotPackControl _0024act_0024t_0024400)
		{
			if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024400.back != null)
			{
				_0024act_0024t_0024400.back.Call(new object[0]);
			}
		});
		return actionClassviewMotPackControl;
	}

	public ActionClassviewMotPackControl createviewMotPackControl(MerlinMotionPackControl mmpc, ICallable back)
	{
		ActionClassviewMotPackControl actionClassviewMotPackControl = createDataviewMotPackControl();
		actionClassviewMotPackControl.mmpc = mmpc;
		actionClassviewMotPackControl.back = back;
		return actionClassviewMotPackControl;
	}

	public ActionClassviewMotPack viewMotPack(MerlinMotionPack mp)
	{
		ActionClassviewMotPack actionClassviewMotPack = createviewMotPack(mp);
		changeAction(actionClassviewMotPack);
		return actionClassviewMotPack;
	}

	public ActionClassviewMotPack createDataviewMotPack()
	{
		ActionClassviewMotPack actionClassviewMotPack = new ActionClassviewMotPack();
		actionClassviewMotPack._0024act_0024t_0024364 = ActionEnum.viewMotPack;
		actionClassviewMotPack._0024act_0024t_0024365 = "$default$";
		actionClassviewMotPack._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable243_0024735_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002451.Adapt(delegate(ActionClassviewMotPack _0024act_0024t_0024403)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Motion Pack: ").Append(_0024act_0024t_0024403.mp).ToString());
			if (!(_0024act_0024t_0024403.mp == null))
			{
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("loaded entries:");
				int i = 0;
				MerlinMotionPack.Entry[] entries = _0024act_0024t_0024403.mp.entries;
				for (int length = entries.Length; i < length; i = checked(i + 1))
				{
					if (!(entries[i].clip == null))
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(entries[i].name).Append(" kw:").Append(Builtins.join(entries[i].keywords))
							.Append(" HasClip:")
							.Append(entries[i].HasClip)
							.Append("} HasD540:")
							.Append(entries[i].HasD540)
							.ToString());
					}
				}
			}
		});
		actionClassviewMotPack._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable243_0024735_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002451.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				viewMotPackList();
			}
		});
		return actionClassviewMotPack;
	}

	public ActionClassviewMotPack createviewMotPack(MerlinMotionPack mp)
	{
		ActionClassviewMotPack actionClassviewMotPack = createDataviewMotPack();
		actionClassviewMotPack.mp = mp;
		return actionClassviewMotPack;
	}

	public ActionClassviewPlayerPoppetCacheInfo viewPlayerPoppetCacheInfo()
	{
		ActionClassviewPlayerPoppetCacheInfo actionClassviewPlayerPoppetCacheInfo = createviewPlayerPoppetCacheInfo();
		changeAction(actionClassviewPlayerPoppetCacheInfo);
		return actionClassviewPlayerPoppetCacheInfo;
	}

	public ActionClassviewPlayerPoppetCacheInfo createDataviewPlayerPoppetCacheInfo()
	{
		ActionClassviewPlayerPoppetCacheInfo actionClassviewPlayerPoppetCacheInfo = new ActionClassviewPlayerPoppetCacheInfo();
		actionClassviewPlayerPoppetCacheInfo._0024act_0024t_0024364 = ActionEnum.viewPlayerPoppetCacheInfo;
		actionClassviewPlayerPoppetCacheInfo._0024act_0024t_0024365 = "$default$";
		actionClassviewPlayerPoppetCacheInfo._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable244_0024749_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002452.Adapt(delegate
		{
			PlayerPoppetCache instance = PlayerPoppetCache.Instance;
			RuntimeDebugModeGuiMixin.label("Player Poppet Cache");
			RuntimeDebugModeGuiMixin.slabel("hide when scene changing: " + instance.HideWhenSceneChanging);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Player:");
			PlayerPoppetCache.CachePlayer playerCacher = instance.PlayerCacher;
			RuntimeDebugModeGuiMixin.slabel("cached player: " + playerCacher.CachedPlayerControl);
			if (playerCacher.CachedPlayerControl != null)
			{
				RuntimeDebugModeGuiMixin.slabel("   gameObject: " + playerCacher.CachedPlayerControl.gameObject);
				RuntimeDebugModeGuiMixin.slabel("    activated: " + playerCacher.CachedPlayerControl.gameObject.active);
			}
			RuntimeDebugModeGuiMixin.slabel("condition: " + playerCacher.CachedCondition);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Poppet:");
			PlayerPoppetCache.CachePoppet poppetCacher = instance.PoppetCacher;
			RuntimeDebugModeGuiMixin.slabel("cached poppet: " + poppetCacher.CachedPoppet);
			if (poppetCacher.CachedPoppet != null)
			{
				RuntimeDebugModeGuiMixin.slabel("   gameObject: " + poppetCacher.CachedPoppet.gameObject);
				RuntimeDebugModeGuiMixin.slabel("    activated: " + poppetCacher.CachedPoppet.gameObject.active);
			}
			RuntimeDebugModeGuiMixin.slabel("condition: " + poppetCacher.CachedCondition);
			RuntimeDebugModeGuiMixin.slabel("abreq: " + poppetCacher.AbReq);
		});
		actionClassviewPlayerPoppetCacheInfo._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable244_0024749_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002452.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassviewPlayerPoppetCacheInfo;
	}

	public ActionClassviewPlayerPoppetCacheInfo createviewPlayerPoppetCacheInfo()
	{
		return createDataviewPlayerPoppetCacheInfo();
	}

	public ActionClassviewAllAIControls viewAllAIControls()
	{
		ActionClassviewAllAIControls actionClassviewAllAIControls = createviewAllAIControls();
		changeAction(actionClassviewAllAIControls);
		return actionClassviewAllAIControls;
	}

	public ActionClassviewAllAIControls createDataviewAllAIControls()
	{
		ActionClassviewAllAIControls actionClassviewAllAIControls = new ActionClassviewAllAIControls();
		actionClassviewAllAIControls._0024act_0024t_0024364 = ActionEnum.viewAllAIControls;
		actionClassviewAllAIControls._0024act_0024t_0024365 = "$default$";
		actionClassviewAllAIControls._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable245_0024778_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002453.Adapt(delegate
		{
			enumerateAllAI(delegate(AIControl _ai)
			{
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(_ai.gameObject.name).Append(" ").Append(_ai.CharacterName)
					.ToString()))
				{
					viewAIControl(_ai, new __DebugSubSkill__0024_0024createDataviewAllAIControls_0024closure_00243516_0024closure_00243517_0024callable436_0024783_41__(viewAllAIControls));
				}
			});
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("全員勝手に動かない"))
			{
				enumerateAllAI(delegate(AIControl _ai)
				{
					UnityEngine.Object.Destroy(_ai.AIProgram);
				});
			}
		});
		actionClassviewAllAIControls._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable245_0024778_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002453.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassviewAllAIControls;
	}

	public ActionClassviewAllAIControls createviewAllAIControls()
	{
		return createDataviewAllAIControls();
	}

	public ActionClassviewAIControl viewAIControl(AIControl ai, ICallable back)
	{
		ActionClassviewAIControl actionClassviewAIControl = createviewAIControl(ai, back);
		changeAction(actionClassviewAIControl);
		return actionClassviewAIControl;
	}

	public ActionClassviewAIControl createDataviewAIControl()
	{
		ActionClassviewAIControl actionClassviewAIControl = new ActionClassviewAIControl();
		actionClassviewAIControl._0024act_0024t_0024364 = ActionEnum.viewAIControl;
		actionClassviewAIControl._0024act_0024t_0024365 = "$default$";
		actionClassviewAIControl._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable246_0024789_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002454.Adapt(delegate(ActionClassviewAIControl _0024act_0024t_0024412)
		{
			_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298 _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024 = new _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298();
			_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412 = _0024act_0024t_0024412;
			_showAIData(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("装備武器: " + _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai.getMainWeapon());
			if (RuntimeDebugModeGuiMixin.button("スキル状態見る"))
			{
				viewSkills(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewAIControl_0024closure_00243520_0024closure_00243521(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024, this).Invoke));
			}
		});
		actionClassviewAIControl._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable246_0024789_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002454.Adapt(delegate(ActionClassviewAIControl _0024act_0024t_0024412)
		{
			if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024412.back != null)
			{
				_0024act_0024t_0024412.back.Call(new object[0]);
			}
		});
		return actionClassviewAIControl;
	}

	public ActionClassviewAIControl createviewAIControl(AIControl ai, ICallable back)
	{
		ActionClassviewAIControl actionClassviewAIControl = createDataviewAIControl();
		actionClassviewAIControl.ai = ai;
		actionClassviewAIControl.back = back;
		return actionClassviewAIControl;
	}

	public ActionClassviewPoppets viewPoppets()
	{
		ActionClassviewPoppets actionClassviewPoppets = createviewPoppets();
		changeAction(actionClassviewPoppets);
		return actionClassviewPoppets;
	}

	public ActionClassviewPoppets createDataviewPoppets()
	{
		ActionClassviewPoppets actionClassviewPoppets = new ActionClassviewPoppets();
		actionClassviewPoppets._0024act_0024t_0024364 = ActionEnum.viewPoppets;
		actionClassviewPoppets._0024act_0024t_0024365 = "$default$";
		actionClassviewPoppets._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable247_0024799_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002455.Adapt(delegate
		{
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if (currentPlayer == null || currentPlayer.Poppets == null)
			{
				RuntimeDebugModeGuiMixin.slabel("連れ魔ペットはなぜかいません");
			}
			else
			{
				int i = 0;
				AIControl[] poppets = currentPlayer.Poppets;
				for (int length = poppets.Length; i < length; i = checked(i + 1))
				{
					if (!(poppets[i] == null))
					{
						viewAIControl(poppets[i], new __DebugSubSkill__0024createDataviewPoppets_0024closure_00243523_0024callable437_0024808_40__(viewPoppets));
					}
				}
			}
		});
		actionClassviewPoppets._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable247_0024799_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002455.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassviewPoppets;
	}

	public ActionClassviewPoppets createviewPoppets()
	{
		return createDataviewPoppets();
	}

	private void _showAIData(AIControl p)
	{
		_0024_showAIData_0024locals_002414294 _0024_showAIData_0024locals_0024 = new _0024_showAIData_0024locals_002414294();
		_0024_showAIData_0024locals_0024._0024p = p;
		if (_0024_showAIData_0024locals_0024._0024p == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("**** ").Append(_0024_showAIData_0024locals_0024._0024p.gameObject).Append(" ****").ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(_0024_showAIData_0024locals_0024._0024p).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("HasPoppeData:").Append(_0024_showAIData_0024locals_0024._0024p.HasPoppetData).Append(" HasMonsterData:").Append(_0024_showAIData_0024locals_0024._0024p.HasMonsterData)
			.ToString());
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_showAIData_0024closure_00243525(_0024_showAIData_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_showAIData_0024closure_00243526(_0024_showAIData_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_showAIData_0024closure_00243527(_0024_showAIData_0024locals_0024).Invoke));
		if (_0024_showAIData_0024locals_0024._0024p.HasPoppetData && RuntimeDebugModeGuiMixin.button("今闘技場連携出す"))
		{
			ChainSkillRoutine.Instance.execSkill(_0024_showAIData_0024locals_0024._0024p);
		}
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("HP: ").Append(_0024_showAIData_0024locals_0024._0024p.HitPoint).Append("/").Append(_0024_showAIData_0024locals_0024._0024p.MaxHitPoint)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel("SetupType: " + _0024_showAIData_0024locals_0024._0024p.SetupType);
		IDamageCalcCharData damageCalcCharData = _0024_showAIData_0024locals_0024._0024p.DamageCalcCharData;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("dmgc attack:").Append(damageCalcCharData.attack()).Append(" maxHitPoint:").Append(damageCalcCharData.maxHitPoint())
			.ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("HP rate: " + _0024_showAIData_0024locals_0024._0024p.HitPointRate);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsDead: ").Append(_0024_showAIData_0024locals_0024._0024p.IsDead).Append(" IsAlive: ").Append(_0024_showAIData_0024locals_0024._0024p.IsAlive)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("NotDead: ").Append(_0024_showAIData_0024locals_0024._0024p.NotDead).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Pause: ").Append(_0024_showAIData_0024locals_0024._0024p.Pause).ToString());
		MerlinActionParameters actionParameters = _0024_showAIData_0024locals_0024._0024p.ActionParameters;
		RuntimeDebugModeGuiMixin.slabel("guard: " + actionParameters.guard);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("noDamage: ").Append(_0024_showAIData_0024locals_0024._0024p.noDamage).Append(" noAttackHit: ").Append(actionParameters.noAttackHit)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("dontMove: ").Append(_0024_showAIData_0024locals_0024._0024p.dontMove).Append(" movementMode: ").Append(_0024_showAIData_0024locals_0024._0024p.movementMode)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel("MoveSpeed: " + _0024_showAIData_0024locals_0024._0024p.MoveSpeed + " MovementScale: " + _0024_showAIData_0024locals_0024._0024p.MovementScale);
		RuntimeDebugModeGuiMixin.slabel("MMPC.BaseMovementScale: " + _0024_showAIData_0024locals_0024._0024p.Mmpc.BaseMovementScale);
		RuntimeDebugModeGuiMixin.slabel("DisablePositionalMovement: " + _0024_showAIData_0024locals_0024._0024p.DisablePositionalMovement);
		RuntimeDebugModeGuiMixin.slabel("MoveDir: " + _0024_showAIData_0024locals_0024._0024p.MoveDir + " Gravity: " + _0024_showAIData_0024locals_0024._0024p.Gravity);
		RuntimeDebugModeGuiMixin.slabel("ExtraMovement: " + _0024_showAIData_0024locals_0024._0024p.ExtraMovement);
		RuntimeDebugModeGuiMixin.slabel("CharVolatileMovement: " + _0024_showAIData_0024locals_0024._0024p.CharVolatileMovement);
		InAreaStates inAreaStateControl = _0024_showAIData_0024locals_0024._0024p.InAreaStateControl;
		RuntimeDebugModeGuiMixin.slabel("InAreaStateControl:");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  dmg:").Append(inAreaStateControl.damage).Append(" yarareIntvl:").Append(inAreaStateControl.yarareIntervalVar)
			.Append(" speedRate:")
			.Append(inAreaStateControl.speedRate)
			.Append(" grav:")
			.Append(inAreaStateControl.gravMov)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("InAreaData ").Append((object)_0024_showAIData_0024locals_0024._0024p.LastInAreaData.size).Append(":").ToString());
		IEnumerator<StateChangeAreaData> enumerator = _0024_showAIData_0024locals_0024._0024p.LastInAreaData.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				StateChangeAreaData current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(current.ToString()).ToString());
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("Weapon: " + _0024_showAIData_0024locals_0024._0024p.getMainWeapon());
		RuntimeDebugModeGuiMixin.space(10);
		showAbnormalStateInfo(_0024_showAIData_0024locals_0024._0024p);
		RuntimeDebugModeGuiMixin.space(10);
		showAreaDamageInfo(_0024_showAIData_0024locals_0024._0024p);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("ChainEffectCache:" + _0024_showAIData_0024locals_0024._0024p.ChainEffectCache);
		if (_0024_showAIData_0024locals_0024._0024p.ChainEffectCache != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  Caching: " + _0024_showAIData_0024locals_0024._0024p.ChainEffectCache.IsStartedCaching);
			RuntimeDebugModeGuiMixin.slabel("  ChainEffect: " + _0024_showAIData_0024locals_0024._0024p.ChainEffectCache.ChainEffect);
			RuntimeDebugModeGuiMixin.slabel("  HealHitEffect: " + _0024_showAIData_0024locals_0024._0024p.ChainEffectCache.HealHitEffect);
		}
		RuntimeDebugModeGuiMixin.space(10);
		MagicSkill magicSkillComponent = _0024_showAIData_0024locals_0024._0024p.MagicSkillComponent;
		if (magicSkillComponent != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  MagicPoint: " + magicSkillComponent.MagicPoint);
			RuntimeDebugModeGuiMixin.slabel("  MaxMagicPoint: " + magicSkillComponent.MaxMagicPoint);
		}
	}

	private void showAbnormalStateInfo(MerlinActionControl m)
	{
		PlayerAbnormalStateControl abnormalStateControl = m.AbnormalStateControl;
		RuntimeDebugModeGuiMixin.label("罹患状態異常: " + Builtins.join(abnormalStateControl.CurrentStates));
		RuntimeDebugModeGuiMixin.label("状態異常:");
		PlayerAbnormalStateControl.StateParams abnormalStateParams = m.AbnormalStateParams;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  speed:").Append(abnormalStateParams.speed).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  decLife:").Append(abnormalStateParams.decLife).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  attack:").Append(abnormalStateParams.attack).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  damage:").Append(abnormalStateParams.damage).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  size:").Append(abnormalStateParams.size).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  motionSpeed:").Append(abnormalStateParams.motionSpeed).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  disableMove:").Append(abnormalStateParams.disableMove).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  disableAttack:").Append(abnormalStateParams.disableAttack).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  disableChain:").Append(abnormalStateParams.disableChain).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  disableSkill:").Append(abnormalStateParams.disableSkill).ToString());
		RuntimeDebugModeGuiMixin.slabel("状態異常耐性: ");
		AbnormalStateLimitter abnormalStateLimitter = m.AbnormalStateLimitter;
		int num = 0;
		int num2 = 10;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append((EnumAbnormalStates)num3).Append(": ").Append(abnormalStateLimitter.getDebugInfo((EnumAbnormalStates)num3))
				.ToString());
		}
		RuntimeDebugModeGuiMixin.slabel("MAbnormalStateParameters:");
		int num4 = 0;
		int num5 = 10;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int num6 = num4;
			num4++;
			EnumAbnormalStates enumAbnormalStates = (EnumAbnormalStates)num6;
			MAbnormalStateParameters rhs = MAbnormalStateParameters.Find(enumAbnormalStates, (int)m.SetupType);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(enumAbnormalStates).Append(": ").ToString() + rhs);
		}
	}

	private void showAreaDamageInfo(MerlinActionControl m)
	{
		RuntimeDebugModeGuiMixin.label("エリアダメージ");
		InAreaStates inAreaStateControl = m.InAreaStateControl;
		RuntimeDebugModeGuiMixin.slabel("  damage: " + inAreaStateControl.damage);
		RuntimeDebugModeGuiMixin.slabel("  speedRate: " + inAreaStateControl.speedRate);
		RuntimeDebugModeGuiMixin.slabel("  gravMov: " + inAreaStateControl.gravMov);
		RuntimeDebugModeGuiMixin.slabel("  yarareInterval: " + inAreaStateControl.yarareInterval);
		RuntimeDebugModeGuiMixin.slabel("エリアダメージデータ");
		IEnumerator<StateChangeAreaData> enumerator = m.LastInAreaData.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				StateChangeAreaData current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel("  type: " + current.Type);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  val: ").Append(current.Value).Append(" val2: ").Append(current.Value2)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel("  origin: " + current.Origin);
				RuntimeDebugModeGuiMixin.slabel("  position: " + current.Position);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		RuntimeDebugModeGuiMixin.slabel("最後のstay area obj:");
		Collider lastStayingAreaObject = m.LastStayingAreaObject;
		StateChangeAreaData lastStayingAreaObjectData = m.LastStayingAreaObjectData;
		if (lastStayingAreaObject != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  " + lastStayingAreaObject);
			RuntimeDebugModeGuiMixin.slabel("  " + lastStayingAreaObjectData);
		}
	}

	public ActionClassviewPathfinderInfo viewPathfinderInfo(ICallable back)
	{
		ActionClassviewPathfinderInfo actionClassviewPathfinderInfo = createviewPathfinderInfo(back);
		changeAction(actionClassviewPathfinderInfo);
		return actionClassviewPathfinderInfo;
	}

	public ActionClassviewPathfinderInfo createDataviewPathfinderInfo()
	{
		ActionClassviewPathfinderInfo actionClassviewPathfinderInfo = new ActionClassviewPathfinderInfo();
		actionClassviewPathfinderInfo._0024act_0024t_0024364 = ActionEnum.viewPathfinderInfo;
		actionClassviewPathfinderInfo._0024act_0024t_0024365 = "$default$";
		actionClassviewPathfinderInfo._0024act_0024t_0024370 = _0024adaptor_0024__DebugSubModeSkill_0024callable248_0024937_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002456.Adapt(delegate
		{
			QuestMapper current = QuestMapper.Current;
			RuntimeDebugModeGuiMixin.label("QuestMapper: " + current);
			if (current != null)
			{
				RuntimeDebugModeGuiMixin.slabel("  initialized: " + current.Initialized);
				RuntimeDebugModeGuiMixin.slabel("  Pathfinder: " + current.Pathfinder);
			}
			Pathfinder instance = Pathfinder.Instance;
			RuntimeDebugModeGuiMixin.label("PathFinder: " + instance);
			if (instance != null)
			{
				Node[,] array = instance.DebugGetMap();
				RuntimeDebugModeGuiMixin.slabel("Map: " + array);
				if (array != null)
				{
					RuntimeDebugModeGuiMixin.slabel("  size: " + array.GetLength(0) + "/" + array.GetLength(1));
				}
				TDManager tDManager = instance.DebugGetTDManager();
				RuntimeDebugModeGuiMixin.slabel("TDManager: " + tDManager);
				if (tDManager != null)
				{
					RuntimeDebugModeGuiMixin.slabel("  tower: " + tDManager.DebugGetTower());
					RuntimeDebugModeGuiMixin.slabel("  tower num: " + tDManager.DebugGetTowerNum());
				}
			}
		});
		actionClassviewPathfinderInfo._0024act_0024t_0024368 = _0024adaptor_0024__DebugSubModeSkill_0024callable248_0024937_5___0024__ActionBase__0024act_0024t_0024366_0024callable20_002438_5___002456.Adapt(delegate(ActionClassviewPathfinderInfo _0024act_0024t_0024418)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				if (_0024act_0024t_0024418.back != null)
				{
					_0024act_0024t_0024418.back.Call(new object[0]);
				}
			}
			else
			{
				mainMode();
			}
		});
		return actionClassviewPathfinderInfo;
	}

	public ActionClassviewPathfinderInfo createviewPathfinderInfo(ICallable back)
	{
		ActionClassviewPathfinderInfo actionClassviewPathfinderInfo = createDataviewPathfinderInfo();
		actionClassviewPathfinderInfo.back = back;
		return actionClassviewPathfinderInfo;
	}

	private void enumerateAllAI(__DebugSubSkill_enumerateAllAI_0024callable22_0024963_38__ c)
	{
		if (c == null)
		{
			return;
		}
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		for (int length = allControls.Length; i < length; i = checked(i + 1))
		{
			AIControl aIControl = allControls[i] as AIControl;
			if (aIControl != null)
			{
				c(aIControl);
			}
		}
	}

	internal void _0024createDatamainMode_0024closure_00243477(ActionClassmainMode _0024act_0024t_0024363)
	{
		_0024act_0024t_0024363.players = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
	}

	internal void _0024createDatamainMode_0024closure_00243478(ActionClassmainMode _0024act_0024t_0024363)
	{
		RuntimeDebugModeGuiMixin.label("スキルデバッグ");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("skill用プレイ日時 : " + SkillEffector.PlayDateTime());
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("スキル追加"))
		{
			skillEditMode();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("現在のスキル");
		checked
		{
			if (_0024act_0024t_0024363.players.Length > 0)
			{
				int i = 0;
				PlayerControl[] players = _0024act_0024t_0024363.players;
				for (int length = players.Length; i < length; i++)
				{
					if (RuntimeDebugModeGuiMixin.button(players[i].gameObject.name))
					{
						viewSkills(players[i], new __DebugSubSkill__0024createDatamainMode_0024closure_00243478_0024callable434_002460_41__(mainMode));
					}
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("プレーヤーがいません");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("ダメージログ"))
			{
				viewDamageLogs();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("その他プレーヤー情報/設定");
			if (_0024act_0024t_0024363.players.Length > 0)
			{
				int j = 0;
				PlayerControl[] players2 = _0024act_0024t_0024363.players;
				for (int length2 = players2.Length; j < length2; j++)
				{
					if (RuntimeDebugModeGuiMixin.button(players2[j].gameObject.name))
					{
						editPlayer(players2[j]);
					}
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("プレーヤーがいません");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("全AIControl情報"))
			{
				viewAllAIControls();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("MotPacks"))
			{
				viewMotPackList();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("PlayerPoppetCache"))
			{
				viewPlayerPoppetCacheInfo();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("Pathfinder"))
			{
				viewPathfinderInfo((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					mainMode();
				});
			}
			RuntimeDebugModeGuiMixin.space(10);
			showCharacterStatus = RuntimeDebugModeGuiMixin.boolButtons(showCharacterStatus, "BaseControl-HP表示");
			RuntimeDebugMode instance = RuntimeDebugMode.Instance;
			GUICharacterStatus component = instance.gameObject.GetComponent<GUICharacterStatus>();
			if (showCharacterStatus && component == null)
			{
				ExtensionsModule.SetComponent<GUICharacterStatus>(instance.gameObject);
			}
			if (!showCharacterStatus && component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243478_0024closure_00243479()
	{
		mainMode();
	}

	internal void _0024createDatamainMode_0024closure_00243480(ActionClassmainMode _0024act_0024t_0024363)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDataviewDamageLogs_0024closure_00243481(ActionClassviewDamageLogs _0024act_0024t_0024379)
	{
		_0024act_0024t_0024379.logs = (string[])Builtins.array(typeof(string), DamageCalc.LogHistory);
		_0024act_0024t_0024379.index = checked(_0024act_0024t_0024379.logs.Length - 1);
	}

	internal void _0024createDataviewDamageLogs_0024closure_00243482(ActionClassviewDamageLogs _0024act_0024t_0024379)
	{
		_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295 _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024 = new _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_002414295();
		_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379 = _0024act_0024t_0024379;
		if (_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index < 0 || _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index >= _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length)
		{
			RuntimeDebugModeGuiMixin.label("ダメージログがありません");
			return;
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewDamageLogs_0024closure_00243482_0024closure_00243483(_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.space(10);
		checked
		{
			if (_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index == _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length - 1)
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("最新ダメージ計算ログ (番号:").Append((object)_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index).Append(")").ToString());
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder().Append((object)(_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs.Length - _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index - 1)).Append("つ前のダメージ計算ログ (番号:").Append((object)_0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index)
					.Append(")")
					.ToString());
			}
			string[] logs = _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.logs;
			RuntimeDebugModeGuiMixin.textArea(logs[RuntimeServices.NormalizeArrayIndex(logs, _0024_0024createDataviewDamageLogs_0024closure_00243482_0024locals_0024._0024_0024act_0024t_0024379.index)]);
		}
	}

	internal void _0024createDataviewDamageLogs_0024closure_00243484(ActionClassviewDamageLogs _0024act_0024t_0024379)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataeditPlayer_0024closure_00243485(ActionClasseditPlayer _0024act_0024t_0024382)
	{
		_0024act_0024t_0024382.vpadMoveThIndex = 0;
		_0024act_0024t_0024382.speedIndex = 0;
		_0024act_0024t_0024382.distIndex = 0;
		PlayerInputControlByVirtualPad.MoveStartDistThreashold = 15f;
	}

	internal void _0024createDataeditPlayer_0024closure_00243486(ActionClasseditPlayer _0024act_0024t_0024382)
	{
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296 _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024 = new _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_002414296();
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382 = _0024act_0024t_0024382;
		if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl == null)
		{
			return;
		}
		if (RuntimeDebugModeGuiMixin.button("今スグ死ぬ"))
		{
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.HitAttack(9999999, YarareTypes.Down, null);
		}
		if (RuntimeDebugModeGuiMixin.button("りば〜いぶ"))
		{
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.reviveForContinue();
		}
		if (RuntimeDebugModeGuiMixin.button("試しでdestroy"))
		{
			UnityEngine.Object.Destroy(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
			mainMode();
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl = null;
			return;
		}
		if (RuntimeDebugModeGuiMixin.button("全MotionPack.Entry情報"))
		{
			viewMotPackControl(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Mmpc, new __DebugSubSkill__0024createDataeditPlayer_0024closure_00243486_0024callable435_0024160_35__(new _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243487(this, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024).Invoke));
		}
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillBeforeChangeMethod, "転身処理直前に死ぬ");
			RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillInChangeMethod, "転身処理中に死ぬ");
			RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillAfterChangeMethod, "転身直後死");
		});
		RuntimeDebugModeGuiMixin.label("PLAYER: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.gameObject.name);
		RuntimeDebugModeGuiMixin.slabel("POS: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MYPOS);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("HP: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.HitPoint).Append("/").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MaxHitPoint)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel("SetupType: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SetupType);
		RuntimeDebugModeGuiMixin.slabel("EQUIPS:");
		RuntimeDebugModeGuiMixin.slabel("  Tenshi:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsTensi + " Akuma:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsAkuma);
		RuntimeDebugModeGuiMixin.slabel("  Main: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.getMainWeapon());
		RespWeapon[] subWeapons = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SubWeapons;
		int i = 0;
		RespWeapon[] subWeapons2 = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.SubWeapons;
		checked
		{
			for (int length = subWeapons2.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel("  Sub: " + subWeapons2[i]);
			}
			WeaponEquipments weaponEquipments = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.weaponEquipments;
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("WeaponEquipments:");
			RuntimeDebugModeGuiMixin.slabel("  Current Race: " + weaponEquipments.Race);
			int j = 0;
			RACE_TYPE[] array = new RACE_TYPE[2]
			{
				RACE_TYPE.Tensi,
				RACE_TYPE.Akuma
			};
			for (int length2 = array.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel("   *" + array[j] + " equipments");
				RespWeapon mainWeapon = weaponEquipments.getMainWeapon(array[j]);
				RuntimeDebugModeGuiMixin.slabel("     wpn HP: " + weaponEquipments.weaponHP(array[j]) + "  ATK: " + weaponEquipments.weaponAtk(array[j]));
				RuntimeDebugModeGuiMixin.slabel("     ppt HP: " + weaponEquipments.supportPoppetHP(array[j]) + "  ATK: " + weaponEquipments.supportPoppetAttack(array[j]));
				RuntimeDebugModeGuiMixin.slabel("     Main: " + mainWeapon);
				subWeapons = weaponEquipments.getSubWeapons(array[j]);
				int k = 0;
				RespWeapon[] array2 = subWeapons;
				for (int length3 = array2.Length; k < length3; k++)
				{
					RuntimeDebugModeGuiMixin.slabel("     Sub: " + array2[k]);
				}
				RespPoppet[] subPoppets = weaponEquipments.getSubPoppets(array[j]);
				int l = 0;
				RespPoppet[] array3 = subPoppets;
				for (int length4 = array3.Length; l < length4; l++)
				{
					RuntimeDebugModeGuiMixin.slabel("     Sub Poppet: " + array3[l]);
				}
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("バトルモード切り換え: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.battleMode).ToString()))
			{
				_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ToggleBattleMode();
			}
			RuntimeDebugModeGuiMixin.space(10);
		}
		int num = RuntimeDebugModeGuiMixin.grid((int)PlayerControl.ForceToSetInputType, new string[4] { "ディフォルト", "タッチ", "コントローラー", "バーチャルパッド" }, 2);
		if (num != (int)PlayerControl.ForceToSetInputType)
		{
			PlayerControl.ForceToSetInputType = (PlayerInputControlType)num;
		}
		RuntimeDebugModeGuiMixin.space(10);
		string[] array4 = new string[12]
		{
			"10", "15", "20", "25", "30", "40", "50", "60", "70", "80",
			"90", "100"
		};
		int[] array5 = new int[12]
		{
			10, 15, 20, 25, 30, 40, 50, 60, 70, 80,
			90, 100
		};
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex, new string[12]
		{
			"10", "15", "20", "25", "30", "40", "50", "60", "70", "80",
			"90", "100"
		}, 5);
		PlayerInputControlByVirtualPad.MoveStartDistThreashold = array5[RuntimeServices.NormalizeArrayIndex(array5, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.vpadMoveThIndex)];
		RuntimeDebugModeGuiMixin.space(10);
		string[] array6 = new string[10] { "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000" };
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = Array.FindIndex(array6, (string v) => v == InputSwipeRecognizer.MIN_VELOCITY.ToString());
		if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex < 0)
		{
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = 0;
		}
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex, array6, 5);
		InputSwipeRecognizer.MIN_VELOCITY = int.Parse(array6[RuntimeServices.NormalizeArrayIndex(array6, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.speedIndex)]);
		RuntimeDebugModeGuiMixin.space(10);
		string[] array7 = new string[10] { "20", "30", "40", "50", "60", "70", "80", "90", "100", "110" };
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = Array.FindIndex(array7, (string v) => v == InputSwipeRecognizer.MIN_DISTANCE.ToString());
		if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex < 0)
		{
			_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = 0;
		}
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex, array7, 5);
		InputSwipeRecognizer.MIN_DISTANCE = int.Parse(array7[RuntimeServices.NormalizeArrayIndex(array7, _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.distIndex)]);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("スキルクールダウン");
		CooldownValue[] cooldowns = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Cooldowns;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  武器スキル: ready:").Append(cooldowns[0].IsReady).Append(" curr:").Append(cooldowns[0].Current)
			.Append(" heattim:")
			.Append(cooldowns[0].HeatTime)
			.Append(" scale:")
			.Append(cooldowns[0].DecreaseScale)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  転身: ready:").Append(cooldowns[2].IsReady).Append(" curr:").Append(cooldowns[2].Current)
			.Append(" heattim:")
			.Append(cooldowns[2].HeatTime)
			.Append(" scale:")
			.Append(cooldowns[2].DecreaseScale)
			.ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("コントローラ:" + DeviceController.Instance.IsPlugged);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  接続済み入力:").Append((object)DeviceController.Instance.JoyNames.Length).Append("個").ToString());
		RuntimeDebugModeGuiMixin.slabel("  on:" + DeviceController.Instance.On);
		RuntimeDebugModeGuiMixin.slabel("  up:" + DeviceController.Instance.Up);
		RuntimeDebugModeGuiMixin.slabel("  down:" + DeviceController.Instance.Down);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("入力管理:");
		PlayerInputControl inputControl = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl;
		if (inputControl is PlayerInputControlByTouch)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [タッチ入力モード] working:").Append(inputControl.Working).ToString());
		}
		else if (inputControl is PlayerInputControlByController)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [コントローラ入力モード] working:").Append(inputControl.Working).ToString());
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  [不明入力:").Append(inputControl).Append("] working:").Append(inputControl.Working)
				.ToString());
		}
		PlayerInputControlByTouch playerInputControlByTouch = inputControl as PlayerInputControlByTouch;
		if (playerInputControlByTouch != null)
		{
			TouchMarker marker = playerInputControlByTouch.Marker;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  marker: ").Append(marker.IsMarked).Append(" ").Append(marker.MarkedPos)
				.ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ctouch: ").Append(playerInputControlByTouch.CurTouch).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ptouch: ").Append(playerInputControlByTouch.PreTouch).ToString());
			TouchRayInfo curRayInfo = playerInputControlByTouch.CurRayInfo;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray any   : ").Append(curRayInfo.Any).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray plane : ").Append(curRayInfo.Plane).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray enemy : ").Append(curRayInfo.Enemy).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ray poppet: ").Append(curRayInfo.Poppet).ToString());
			ConditionalTimer runStopTimer = playerInputControlByTouch.RunStopTimer;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  run stop: ").Append(runStopTimer.Enabled).Append(" ").Append(runStopTimer.Timer)
				.Append(" ")
				.ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  dispacement: ").Append(playerInputControlByTouch.DisplacementMeasure.length).ToString());
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(inputControl).ToString());
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("ロックオン:");
		PlayerLockOnControl lockOnControl = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.LockOnControl;
		if (lockOnControl != null)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsLockedOn: ").Append(lockOnControl.IsLockedOn).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Player: ").Append(lockOnControl.Player).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Target: ").Append(lockOnControl.Target).ToString());
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("マーカー(タッチコントロールのみ)");
		if (playerInputControlByTouch != null)
		{
			TouchMarker marker = playerInputControlByTouch.Marker;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  IsMarked: ").Append(marker.IsMarked).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  Pos: ").Append(marker.MarkedPos).ToString());
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("ActionInput:");
		MerlinActionInput actionInput = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput.CurrentInput).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		showAbnormalStateInfo(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
		RuntimeDebugModeGuiMixin.space(10);
		showAreaDamageInfo(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("モーションパック状況"))
		{
			motionPackView(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("色々フラグ等");
		RuntimeDebugModeGuiMixin.slabel("IsReady: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsReady);
		RuntimeDebugModeGuiMixin.slabel("IsDead: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsDead);
		RuntimeDebugModeGuiMixin.slabel("Pause: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.Pause);
		RuntimeDebugModeGuiMixin.slabel("UpdateDeltaTime: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.UpdateDeltaTime);
		RuntimeDebugModeGuiMixin.slabel("FixedUpdateDeltaTime: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.FixedUpdateDeltaTime);
		RuntimeDebugModeGuiMixin.slabel("IsJustDodge: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.IsJustDodge);
		RuntimeDebugModeGuiMixin.slabel("DisableFaceMovement: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.DisableFaceMovement);
		RuntimeDebugModeGuiMixin.slabel("MovementScale: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MovementScale);
		RuntimeDebugModeGuiMixin.slabel("MoveSpeed: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MoveSpeed);
		MerlinCharParameters charParameters = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.CharParameters;
		RuntimeDebugModeGuiMixin.slabel("CharParameters:");
		RuntimeDebugModeGuiMixin.slabel("   NoKnockBack: " + charParameters.NoKnockBack);
		RuntimeDebugModeGuiMixin.slabel("   NoThrow: " + charParameters.NoThrow);
		RuntimeDebugModeGuiMixin.slabel("   NoBaseMode: " + charParameters.NoBaseMode);
		MerlinActionParameters actionParameters = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionParameters;
		RuntimeDebugModeGuiMixin.slabel("ActionParameters:");
		RuntimeDebugModeGuiMixin.slabel("   guard: " + actionParameters.guard);
		RuntimeDebugModeGuiMixin.slabel("   noAttackHit: " + actionParameters.noAttackHit);
		RuntimeDebugModeGuiMixin.slabel("   HitCancelCount: " + actionParameters.HitCancelCount);
		RuntimeDebugModeGuiMixin.space(10);
		PlayerControl.KaihiTimeInfo kaihiTime = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.KaihiTime;
		RuntimeDebugModeGuiMixin.slabel("KaihiTime:");
		RuntimeDebugModeGuiMixin.slabel("   enabled: " + kaihiTime.enabled);
		RuntimeDebugModeGuiMixin.slabel("   start: " + kaihiTime.start);
		RuntimeDebugModeGuiMixin.slabel("   end: " + kaihiTime.end);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("MoveCommandSpeedScale: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MoveCommandSpeedScale);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("InputActive: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputActive);
		RuntimeDebugModeGuiMixin.slabel("InputControl: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl);
		RuntimeDebugModeGuiMixin.slabel("ActionInput: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.ActionInput);
		if (_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl != null)
		{
			RuntimeDebugModeGuiMixin.slabel("   InputControl GetType: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.GetType());
			RuntimeDebugModeGuiMixin.slabel("   InputControl.ActionInput: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.ActionInput);
			RuntimeDebugModeGuiMixin.slabel("   InputControl.Working: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.Working);
			RuntimeDebugModeGuiMixin.slabel("   InputControl.Type: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.InputControl.Type);
		}
		RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DispPlayerInputControlInfo, "DispPlayerInputControlInfo");
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("HUD更新フレーム間隔");
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex, new string[20]
		{
			"1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
			"11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
		}, 5);
		PlayerControl.HudUpdateStep = checked(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.hudUpdateCountIndex + 1);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("auto battle/run");
		_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoBattle;
		RuntimeDebugModeGuiMixin.slabel("Player.EnableAuto: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.EnableAuto + " / AutoBattle.enabled: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.enabled);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("AutoSkillMode: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.AutoSkillMode).Append(" AutoBattleSpeed: ").Append(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.AutoBattleSpeed)
			.ToString());
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243491(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024).Invoke));
		RuntimeDebugModeGuiMixin.slabel("IsReadyPlayerChange: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyPlayerChange());
		RuntimeDebugModeGuiMixin.slabel("IsReadyChainSklilforQueuing: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyChainSklilforQueuing());
		RuntimeDebugModeGuiMixin.slabel("GetReadyChainSkill: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetReadyChainSkill());
		RuntimeDebugModeGuiMixin.slabel("IsReadyWeaponSkill: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsReadyWeaponSkill());
		RuntimeDebugModeGuiMixin.slabel("IsSetupWeaponSkillCondition: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsSetupWeaponSkillCondition());
		RuntimeDebugModeGuiMixin.slabel("IsSetupWeaponSkillCondition(alt): " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsSetupWeaponSkillCondition(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AltWeaponSkill));
		int num2 = 0;
		while (num2 < 2)
		{
			int num3 = num2;
			num2++;
			MChainSkills mChainSkills = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetMChainSkills(num3);
			RuntimeDebugModeGuiMixin.slabel("chainskill: " + mChainSkills);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("chainskill ").Append((object)num3).Append(" enemy cond: ").ToString() + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsChainSkillEnemyConditionOk(mChainSkills));
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("chainskill ").Append((object)num3).Append(" status cond: ").ToString() + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsChainSkillStatusConditionOk(mChainSkills, num3));
		}
		MWeaponSkills mWeaponSkills = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.GetMWeaponSkills();
		RuntimeDebugModeGuiMixin.slabel("weaponskill: " + mWeaponSkills);
		RuntimeDebugModeGuiMixin.slabel("weaponskill enemy cond: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsWeaponSkillEnemyConditionOk(mWeaponSkills));
		RuntimeDebugModeGuiMixin.slabel("weaponskill status cond: " + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.IsWeaponSkillStatusConditionOk(mWeaponSkills));
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("current action:" + _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.CurrentAction);
		RuntimeDebugModeGuiMixin.slabel("actionQueue:");
		foreach (AutoBattleAction item in _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024auto.ActionAutoBattleQueue)
		{
			RuntimeDebugModeGuiMixin.slabel("   " + item);
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("PlayerAutoFlowController");
		PlayerAutoFlowController autoFlowController = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoFlowController;
		if (autoFlowController != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  enabled=" + autoFlowController.enabled + " HasPlayer=" + (autoFlowController.Player != null));
			RuntimeDebugModeGuiMixin.slabel("  IsAuto=" + autoFlowController.IsAuto + " ChangedAuto=" + autoFlowController.ChangedAuto);
			RuntimeDebugModeGuiMixin.slabel("  IsAutoCondition=" + autoFlowController.IsAutoCondition());
			RuntimeDebugModeGuiMixin.slabel("  MappedQuest=" + autoFlowController.MappedQuest);
			RuntimeDebugModeGuiMixin.slabel("  CurrentPoint=" + autoFlowController.CurrentPointIndex);
			if (RuntimeDebugModeGuiMixin.button("ProcessEvent()"))
			{
				autoFlowController.ProcessEvent();
			}
		}
		RuntimeDebugModeGuiMixin.space(10);
		CharacterPathFinder charPathFinder = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.CharPathFinder;
		RuntimeDebugModeGuiMixin.slabel("charPathFinder");
		RuntimeDebugModeGuiMixin.slabel("  isMovement:" + charPathFinder.IsMovement);
		RuntimeDebugModeGuiMixin.slabel("  path length:" + charPathFinder.PathLength);
		RuntimeDebugModeGuiMixin.slabel("  cal path length:" + charPathFinder.CalPathLength);
		RuntimeDebugModeGuiMixin.slabel("  fVerifyLength:" + charPathFinder.fVerifyLength);
		RuntimeDebugModeGuiMixin.slabel("  PathModify:" + charPathFinder.PathModify);
		RuntimeDebugModeGuiMixin.slabel("  MoreModify:" + charPathFinder.MoreModify);
		RuntimeDebugModeGuiMixin.slabel("  DebugLine:" + charPathFinder.DebugLine);
		RuntimeDebugModeGuiMixin.slabel("  RemoveNodeList:" + charPathFinder.RemoveNodeList.Count);
		RuntimeDebugModeGuiMixin.slabel("  fVerifyLength:" + charPathFinder.fVerifyLength);
		if (RuntimeDebugModeGuiMixin.button("draw path toggle"))
		{
			charPathFinder.DebugLine = !charPathFinder.DebugLine;
		}
		RuntimeDebugModeGuiMixin.space(10);
		QuestRouteFinder routeFinder = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.AutoFlowController.RouteFinder;
		RuntimeDebugModeGuiMixin.slabel("QuestRouteFinder");
		RuntimeDebugModeGuiMixin.slabel("  quest:" + routeFinder.Quest);
		RuntimeDebugModeGuiMixin.slabel("  AutoRunOn:" + routeFinder.AutoRunOn);
		int num4 = 0;
		foreach (AbstractEventPoint item2 in routeFinder.Route)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   [").Append((object)num4).Append("] ").ToString() + item2);
			num4 = checked(num4 + 1);
		}
		RuntimeDebugModeGuiMixin.space(10);
		Pathfinder instance = Pathfinder.Instance;
		RuntimeDebugModeGuiMixin.slabel("Pathfinder:");
		if (instance != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  base object: " + instance.gameObject);
			RuntimeDebugModeGuiMixin.slabel("  queue count: " + instance.QueueNum);
			instance.enumerateQueue(delegate(QueuePath qp)
			{
				RuntimeDebugModeGuiMixin.slabel("     " + qp);
			});
			Node tileNode = instance.GetTileNode(_0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.MYPOS);
			RuntimeDebugModeGuiMixin.slabel("現在の場所のNode: " + tileNode);
			RuntimeDebugModeGuiMixin.slabel("  parent:" + ((tileNode.parent == null) ? "<null>" : ((object)tileNode.parent.ID)));
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  F:").Append((object)tileNode.F).Append(" H:").Append((object)tileNode.H)
				.Append(" G:")
				.Append((object)tileNode.G)
				.ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  sortedIndex:").Append((object)tileNode.sortedIndex).ToString());
			if (RuntimeDebugModeGuiMixin.button("現在の場所のyを設定する"))
			{
				tileNode.yCoord = _0024_0024createDataeditPlayer_0024closure_00243486_0024locals_0024._0024_0024act_0024t_0024382.pl.transform.position.y;
			}
			if (RuntimeDebugModeGuiMixin.button("現在の場所をwalkableにする"))
			{
				tileNode.walkable = true;
			}
			if (RuntimeDebugModeGuiMixin.button("現在の場所をun-walkableにする"))
			{
				tileNode.walkable = false;
			}
			if (RuntimeDebugModeGuiMixin.button("現在のtileを保存"))
			{
				instance.SaveTileFileAsCurrentSceneData();
			}
		}
	}

	internal void _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243488()
	{
		RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillBeforeChangeMethod, "転身処理直前に死ぬ");
		RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillInChangeMethod, "転身処理中に死ぬ");
		RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.DebugKillAfterChangeMethod, "転身直後死");
	}

	internal bool _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243489(string v)
	{
		return v == InputSwipeRecognizer.MIN_VELOCITY.ToString();
	}

	internal bool _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243490(string v)
	{
		return v == InputSwipeRecognizer.MIN_DISTANCE.ToString();
	}

	internal void _0024_0024createDataeditPlayer_0024closure_00243486_0024closure_00243492(QueuePath qp)
	{
		RuntimeDebugModeGuiMixin.slabel("     " + qp);
	}

	internal void _0024createDataeditPlayer_0024closure_00243493(ActionClasseditPlayer _0024act_0024t_0024382)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatamotionPackView_0024closure_00243494(ActionClassmotionPackView _0024act_0024t_0024385)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024385.pl).ToString());
		MerlinMotionPackControl mmpc = _0024act_0024t_0024385.pl.Mmpc;
		if (mmpc == null)
		{
			RuntimeDebugModeGuiMixin.label("no MMPC");
			return;
		}
		MerlinMotionPack[] allPacks = mmpc.AllPacks;
		RuntimeDebugModeGuiMixin.label("Packs: num=" + allPacks.Length);
		int num = 0;
		int i = 0;
		MerlinMotionPack[] array = allPacks;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] == null)
				{
					continue;
				}
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("[").Append((object)num++).Append("]  pack ").Append(array[i])
					.Append(" entries=")
					.ToString() + array[i].entries.Length);
				int j = 0;
				MerlinMotionPack.Entry[] entries = array[i].entries;
				for (int length2 = entries.Length; j < length2; j++)
				{
					string text = string.Empty;
					int k = 0;
					string[] keywords = entries[j].keywords;
					for (int length3 = keywords.Length; k < length3; k++)
					{
						text += keywords[k] + " ";
					}
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(entries[j].name).Append(" clip:").Append(entries[j].clip)
						.Append(" -- ")
						.Append(text)
						.ToString());
				}
			}
		}
	}

	internal void _0024createDatamotionPackView_0024closure_00243496(ActionClassmotionPackView _0024act_0024t_0024385)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			editPlayer(_0024act_0024t_0024385.pl);
		}
	}

	internal void _0024createDataviewSkills_0024closure_00243497(ActionClassviewSkills _0024act_0024t_0024388)
	{
		_0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297 _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024 = new _0024_0024createDataviewSkills_0024closure_00243497_0024locals_002414297();
		_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388 = _0024act_0024t_0024388;
		PlayerSkillEffectControl skillEffectControl = _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.SkillEffectControl;
		SkillEffectData currentData = skillEffectControl.CurrentData;
		PlayerControl playerControl = _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch as PlayerControl;
		RuntimeDebugModeGuiMixin.label("CHARACTER: " + _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.gameObject.name);
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("ダメージ計算機用パラメータ"))
		{
			viewDamageCharData(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewSkills_0024closure_00243497_0024closure_00243498(this, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024).Invoke));
			return;
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("非攻撃系スキル効果状態");
		RuntimeDebugModeGuiMixin.slabel("  スキルクールダウン率: " + currentData.skillCoolDownRate);
		RuntimeDebugModeGuiMixin.slabel("  回避成功時クールダウン回復秒: " + currentData.kaihiSkillCoolDownVal);
		RuntimeDebugModeGuiMixin.slabel("  candyのHP回復率: " + currentData.candyRecoveryRate);
		RuntimeDebugModeGuiMixin.slabel("  candyの魔力回復量: " + currentData.candyMagicRecoveryValue);
		RuntimeDebugModeGuiMixin.slabel("  dodge時間加算: " + currentData.justDodgeTimeBonus);
		RuntimeDebugModeGuiMixin.slabel("  移動速度倍率: " + currentData.speedMult);
		RuntimeDebugModeGuiMixin.slabel("  MOVEコマンド移動倍率: " + currentData.moveCommandSpeedMult);
		RuntimeDebugModeGuiMixin.slabel("  初期HP倍率: " + currentData.hpMult);
		RuntimeDebugModeGuiMixin.slabel("  初期HP加算: " + currentData.hpAdd);
		RuntimeDebugModeGuiMixin.slabel("  ダメージエリア無効化: " + currentData.invalidateDamageArea);
		RuntimeDebugModeGuiMixin.slabel("  足おそエリア無効化: " + currentData.invalidateSlowArea);
		RuntimeDebugModeGuiMixin.slabel("  引力エリア無効化: " + currentData.invalidateGravityArea);
		RuntimeDebugModeGuiMixin.slabel("  ダメージ時の魔力回復倍率: " + currentData.mpRecoveryRateWhenDamaged);
		RuntimeDebugModeGuiMixin.slabel("  回避成功時の魔力回復量: " + currentData.mpRecoveryValueWhenKaihi);
		RuntimeDebugModeGuiMixin.slabel("  攻撃成功時の魔力回復倍率: " + currentData.mpRecoveryRateWhenAttack);
		RuntimeDebugModeGuiMixin.slabel("  敵抹殺時HP回復量: " + currentData.hpRecoveryValueWhenKilled);
		RuntimeDebugModeGuiMixin.slabel("  転身クールダウン短縮秒: " + currentData.changeCoolDownDecTime);
		RuntimeDebugModeGuiMixin.slabel("  フルガードモード: " + currentData.fullGuard);
		RuntimeDebugModeGuiMixin.slabel("  スタンド「ザワールド」的能力: " + currentData.stopWorld);
		RuntimeDebugModeGuiMixin.space(10);
		Boo.Lang.List<SkillEffector> allSkills = skillEffectControl.AllSkills;
		RuntimeDebugModeGuiMixin.label("エフェクタリスト");
		RuntimeDebugModeGuiMixin.slabel("※表示不能:ダメージ乗算補正,(敵)防御補正,攻撃成功時HP回復");
		if (((ICollection)allSkills).Count <= 0)
		{
			RuntimeDebugModeGuiMixin.label("エフェクタ無し");
			return;
		}
		IEnumerator<SkillEffector> enumerator = allSkills.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SkillEffector current = enumerator.Current;
				SkillEffectParameters skileff = current.skileff;
				RuntimeDebugModeGuiMixin.label("==================");
				RuntimeDebugModeGuiMixin.slabel("スキル効果: " + skileff.MSkillEffectTypeId.Progname);
				RuntimeDebugModeGuiMixin.slabel("origin:" + current.Origin);
				if (current.HasExpiration)
				{
					RuntimeDebugModeGuiMixin.slabel("  残り時間: " + current.ExpirationTime);
				}
				else
				{
					RuntimeDebugModeGuiMixin.slabel("  残り時間: 恒久的");
				}
				RuntimeDebugModeGuiMixin.slabel("  効果値: " + current.EffValue);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  level/max: ").Append((object)current.level).Append("/").Append((object)current.levelMax)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  min/max/exp: ").Append((object)skileff.ValueMin).Append("/").Append((object)skileff.ValueMax)
					.Append("/")
					.Append(skileff.ValueExp)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  powerBase: ").Append(current.powerBase).ToString());
				RuntimeDebugModeGuiMixin.slabel("  対象属性: " + skileff.Element);
				RuntimeDebugModeGuiMixin.slabel("  対象スタイル: " + skileff.Style);
				RuntimeDebugModeGuiMixin.slabel("  対象種族: " + skileff.Race);
				RuntimeDebugModeGuiMixin.slabel("  上限HP: " + skileff.UnderHP);
				RuntimeDebugModeGuiMixin.slabel("  状態異常: " + skileff.AbnormalState);
				RuntimeDebugModeGuiMixin.slabel("  個数: " + skileff.Count);
				RuntimeDebugModeGuiMixin.slabel("  率: " + skileff.Rate);
				RuntimeDebugModeGuiMixin.slabel("  対象属性(2): " + skileff.ElementPrm1 + " " + skileff.ElementPrm2);
				RuntimeDebugModeGuiMixin.slabel("  クリティカル乗算: " + current.criticalRateMult(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.HitPointRate, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.IsTensi, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.IsAkuma));
				RuntimeDebugModeGuiMixin.slabel("  クリティカル率(連携)強制設定): " + current.maximumChainCriticalRate());
				if (playerControl != null)
				{
					RuntimeDebugModeGuiMixin.slabel("  攻撃力乗算(playerのみ): " + current.attackMult(playerControl.HasAnyAbnormalState, playerControl.getMainWeapon().Style));
					RuntimeDebugModeGuiMixin.slabel("  攻撃力加算(playerのみ): " + current.attackPlus(playerControl.HasAnyAbnormalState, playerControl.getMainWeapon().Style, playerControl.getMainWeapon().Element));
				}
				RuntimeDebugModeGuiMixin.slabel("  崩しスキル補正: " + current.yarareResistPlus());
				RuntimeDebugModeGuiMixin.slabel("  モンスター防御力乗算: " + current.enemyDefenseMult());
				RuntimeDebugModeGuiMixin.slabel("  ダメージ補正値(damage 100時): " + current.finalDamageAdjust(100f, _0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch.HitPoint));
				Boo.Lang.List<EnumAbnormalStates> list = new Boo.Lang.List<EnumAbnormalStates>();
				IEnumerator enumerator2 = Enum.GetValues(typeof(EnumAbnormalStates)).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					EnumAbnormalStates enumAbnormalStates = (EnumAbnormalStates)enumerator2.Current;
					if (current.canResistAbnormalState(_0024_0024createDataviewSkills_0024closure_00243497_0024locals_0024._0024_0024act_0024t_0024388.ch, enumAbnormalStates))
					{
						list.Add(enumAbnormalStates);
					}
				}
				RuntimeDebugModeGuiMixin.slabel("  レジスト可能状態異常: " + Builtins.join(list));
				RuntimeDebugModeGuiMixin.space(10);
				int i = 0;
				EnumElements[] array = new EnumElements[4]
				{
					EnumElements.fire,
					EnumElements.water,
					EnumElements.wind,
					EnumElements.earth
				};
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					float num = current.attackDamageMult(playerControl, array[i], EnumRaces.beast, enGuard: false, enElite: false, isCritical: false, null);
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ダメージ倍率(").Append(array[i]).Append("/beast/!guard/!elite/!critical: ").ToString() + num);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024createDataviewSkills_0024closure_00243499(ActionClassviewSkills _0024act_0024t_0024388)
	{
		if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024388.back != null)
		{
			_0024act_0024t_0024388.back.Call(new object[0]);
		}
	}

	internal void _0024createDataviewDamageCharData_0024closure_00243500(ActionClassviewDamageCharData _0024act_0024t_0024391)
	{
		if (_0024act_0024t_0024391.ch.HasPoppetData)
		{
			RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ(ppt): " + _0024act_0024t_0024391.ch.PoppetData);
		}
		else if (_0024act_0024t_0024391.ch.HasMonsterData)
		{
			RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ(mon): " + _0024act_0024t_0024391.ch.MonsterData);
		}
		else
		{
			RuntimeDebugModeGuiMixin.label("ダメージ計算機用パラメータ:" + _0024act_0024t_0024391.ch.gameObject);
		}
		IDamageCalcCharData damageCalcCharData = _0024act_0024t_0024391.ch.DamageCalcCharData;
		RuntimeDebugModeGuiMixin.slabel("element: " + damageCalcCharData.element());
		RuntimeDebugModeGuiMixin.slabel("style: " + damageCalcCharData.style());
		RuntimeDebugModeGuiMixin.slabel("race: " + damageCalcCharData.race());
		RuntimeDebugModeGuiMixin.slabel("weakStyle: " + damageCalcCharData.weakStyle());
		RuntimeDebugModeGuiMixin.slabel("hitPoint: " + damageCalcCharData.hitPoint());
		RuntimeDebugModeGuiMixin.slabel("maxHitPoint: " + damageCalcCharData.maxHitPoint());
		RuntimeDebugModeGuiMixin.slabel("hitPointRate: " + damageCalcCharData.hitPointRate());
		RuntimeDebugModeGuiMixin.slabel("isPlayer: " + damageCalcCharData.isPlayer());
		RuntimeDebugModeGuiMixin.slabel("isTensi: " + damageCalcCharData.isTensi());
		RuntimeDebugModeGuiMixin.slabel("isAkuma: " + damageCalcCharData.isAkuma());
		RuntimeDebugModeGuiMixin.slabel("isInJustDodge: " + damageCalcCharData.isInJustDodge());
		RuntimeDebugModeGuiMixin.slabel("isGuarding: " + damageCalcCharData.isGuarding());
		RuntimeDebugModeGuiMixin.slabel("isElite: " + damageCalcCharData.isElite());
		RuntimeDebugModeGuiMixin.slabel("isDead: " + damageCalcCharData.isDead());
		RuntimeDebugModeGuiMixin.slabel("attack: " + damageCalcCharData.attack());
		RuntimeDebugModeGuiMixin.slabel("resist: " + damageCalcCharData.resist());
		RuntimeDebugModeGuiMixin.slabel("defense: " + damageCalcCharData.defense());
		RuntimeDebugModeGuiMixin.slabel("breakPow: " + damageCalcCharData.breakPow());
		RuntimeDebugModeGuiMixin.slabel("critical: " + damageCalcCharData.critical());
		RuntimeDebugModeGuiMixin.slabel("needQuestPoppetRevice: " + damageCalcCharData.needQuestPoppetRevice());
		RuntimeDebugModeGuiMixin.slabel("needColosseumPoppetRevice: " + damageCalcCharData.needColosseumPoppetRevice());
		RuntimeDebugModeGuiMixin.slabel("hasAbnormalState: " + damageCalcCharData.hasAbnormalState());
		RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.isRaid: " + damageCalcCharData.getRaidBonusData().isRaid);
		RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.bonusWeaponElement: " + damageCalcCharData.getRaidBonusData().bonusWeaponElement);
		RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.bonusWeaponStyle: " + damageCalcCharData.getRaidBonusData().bonusWeaponStyle);
		RuntimeDebugModeGuiMixin.slabel("getRaidBonusData.comboBonus: " + damageCalcCharData.getRaidBonusData().comboBonus);
	}

	internal void _0024createDataviewDamageCharData_0024closure_00243501(ActionClassviewDamageCharData _0024act_0024t_0024391)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			if (_0024act_0024t_0024391.back != null)
			{
				_0024act_0024t_0024391.back.Call(new object[0]);
			}
			else
			{
				mainMode();
			}
		}
	}

	internal void _0024createDataskillEditMode_0024closure_00243502(ActionClassskillEditMode _0024act_0024t_0024394)
	{
		RuntimeDebugModeGuiMixin.label("スキル効果強制追加");
		if (RuntimeDebugModeGuiMixin.button("以下の設定でスキル効果追加"))
		{
			emit();
		}
		RuntimeDebugModeGuiMixin.space(20);
		intSelect(ref valueMin, "ValueMin(連携系は魔力なので無意味)", new int[10] { 1, 2, 5, 10, 20, 50, 80, 100, 150, 200 });
		intSelect(ref valueMax, "ValueMax(連携系は魔力なので無意味)", new int[10] { 1, 2, 5, 10, 20, 50, 80, 100, 150, 200 });
		floatSelect(ref valueExp, "ValueExp(連携系は魔力なので無意味)", new float[5] { 0.5f, 0.8f, 1f, 1.2f, 1.5f });
		select(ref elementIndex, "属性", ArrayMap.AllEnumNames(typeof(EnumElements)));
		select(ref styleIndex, "スタイル", ArrayMap.AllEnumNames(typeof(EnumStyles)));
		select(ref raceIndex, "種族", ArrayMap.AllEnumNames(typeof(EnumRaces)));
		intSelect(ref level, "level", new int[5] { 1, 2, 4, 8, 16 });
		intSelect(ref levelMax, "levelMax", new int[5] { 1, 2, 4, 8, 16 });
		floatSelect(ref powerBase, "powerBase", new float[5] { 1f, 10f, 100f, 500f, 1000f });
		floatSelect(ref expirationTime, "expirationTime", new float[5] { 0f, 5f, 10f, 15f, 20f });
		intSelect(ref underHP, "UnderHP", new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 });
		intSelect(ref count, "Count", new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
		intSelect(ref rate, "Rate", new int[5] { 0, 25, 50, 75, 100 });
		select(ref elementIndex, "属性セット1", ArrayMap.AllEnumNames(typeof(EnumElements)));
		select(ref elementIndex, "属性セット2", ArrayMap.AllEnumNames(typeof(EnumElements)));
		RuntimeDebugModeGuiMixin.space(10);
		select(ref skillIndex, "スキル効果", ArrayMap.AllMSkillEffectTypesToStr((MSkillEffectTypes m) => new StringBuilder().Append((object)m.Id).ToString() + m.Progname), 1);
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("上記の設定でスキル効果追加"))
		{
			emit();
		}
	}

	internal string _0024_0024createDataskillEditMode_0024closure_00243502_0024closure_00243503(MSkillEffectTypes m)
	{
		return new StringBuilder().Append((object)m.Id).ToString() + m.Progname;
	}

	internal void _0024createDataskillEditMode_0024closure_00243504(ActionClassskillEditMode _0024act_0024t_0024394)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal string _0024intSelect_0024closure_00243505(int v)
	{
		return new StringBuilder().Append((object)v).ToString();
	}

	internal string _0024floatSelect_0024closure_00243506(int v)
	{
		return new StringBuilder().Append((object)v).ToString();
	}

	internal void _0024createDataviewMotPackList_0024closure_00243507(ActionClassviewMotPackList _0024act_0024t_0024397)
	{
		_0024act_0024t_0024397.motPacks = Resources.FindObjectsOfTypeAll<MerlinMotionPack>();
	}

	internal void _0024createDataviewMotPackList_0024closure_00243508(ActionClassviewMotPackList _0024act_0024t_0024397)
	{
		RuntimeDebugModeGuiMixin.label("Motion Packs");
		int i = 0;
		MerlinMotionPack[] motPacks = _0024act_0024t_0024397.motPacks;
		for (int length = motPacks.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(motPacks[i]).Append(" - guid:").Append(ExtensionsModule.GetMyID(motPacks[i]))
				.ToString()))
			{
				viewMotPack(motPacks[i]);
			}
		}
	}

	internal void _0024createDataviewMotPackList_0024closure_00243509(ActionClassviewMotPackList _0024act_0024t_0024397)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataviewMotPackControl_0024closure_00243510(ActionClassviewMotPackControl _0024act_0024t_0024400)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("Motion Pack Control: ").Append(_0024act_0024t_0024400.mmpc).ToString());
		if (_0024act_0024t_0024400.mmpc == null)
		{
			return;
		}
		foreach (MerlinMotionPackControl.PackInfo packInfo in _0024act_0024t_0024400.mmpc.PackInfos)
		{
			RuntimeDebugModeGuiMixin.slabel("pack: " + packInfo.pack);
			RuntimeDebugModeGuiMixin.slabel("enabled: " + packInfo.enabled);
			RuntimeDebugModeGuiMixin.slabel("executer: " + packInfo.executer);
			MerlinMotionPack.Executer executer = packInfo.executer;
			if (executer == null)
			{
				continue;
			}
			RuntimeDebugModeGuiMixin.label("entries:");
			foreach (string key in executer.EntryDict.Keys)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key).Append(":").ToString());
				IEnumerator<MerlinMotionPack.Entry> enumerator3 = executer.EntryDict[key].GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						MerlinMotionPack.Entry current3 = enumerator3.Current;
						RuntimeDebugModeGuiMixin.slabel("      clip=" + current3.clip + " HasD540:" + current3.HasD540 + " asset=" + current3.assetPath + " kwd:" + Builtins.join(current3.keywords));
					}
				}
				finally
				{
					enumerator3.Dispose();
				}
			}
			RuntimeDebugModeGuiMixin.label("loaded sound:");
			D540RuntimeAssetResolver seLoader = executer.SeLoader;
			if (seLoader == null)
			{
				continue;
			}
			D540RuntimeAssetResolver.SEPool sePool = seLoader.SePool;
			if (sePool == null)
			{
				continue;
			}
			foreach (string key2 in sePool.loadedSEs.Keys)
			{
				int num = sePool.loadedSEID(key2);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key2).Append(": seId=").Append((object)num)
					.ToString());
			}
		}
	}

	internal void _0024createDataviewMotPackControl_0024closure_00243511(ActionClassviewMotPackControl _0024act_0024t_0024400)
	{
		if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024400.back != null)
		{
			_0024act_0024t_0024400.back.Call(new object[0]);
		}
	}

	internal void _0024createDataviewMotPack_0024closure_00243512(ActionClassviewMotPack _0024act_0024t_0024403)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("Motion Pack: ").Append(_0024act_0024t_0024403.mp).ToString());
		if (_0024act_0024t_0024403.mp == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("loaded entries:");
		int i = 0;
		MerlinMotionPack.Entry[] entries = _0024act_0024t_0024403.mp.entries;
		for (int length = entries.Length; i < length; i = checked(i + 1))
		{
			if (!(entries[i].clip == null))
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(entries[i].name).Append(" kw:").Append(Builtins.join(entries[i].keywords))
					.Append(" HasClip:")
					.Append(entries[i].HasClip)
					.Append("} HasD540:")
					.Append(entries[i].HasD540)
					.ToString());
			}
		}
	}

	internal void _0024createDataviewMotPack_0024closure_00243513(ActionClassviewMotPack _0024act_0024t_0024403)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			viewMotPackList();
		}
	}

	internal void _0024createDataviewPlayerPoppetCacheInfo_0024closure_00243514(ActionClassviewPlayerPoppetCacheInfo _0024act_0024t_0024406)
	{
		PlayerPoppetCache instance = PlayerPoppetCache.Instance;
		RuntimeDebugModeGuiMixin.label("Player Poppet Cache");
		RuntimeDebugModeGuiMixin.slabel("hide when scene changing: " + instance.HideWhenSceneChanging);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Player:");
		PlayerPoppetCache.CachePlayer playerCacher = instance.PlayerCacher;
		RuntimeDebugModeGuiMixin.slabel("cached player: " + playerCacher.CachedPlayerControl);
		if (playerCacher.CachedPlayerControl != null)
		{
			RuntimeDebugModeGuiMixin.slabel("   gameObject: " + playerCacher.CachedPlayerControl.gameObject);
			RuntimeDebugModeGuiMixin.slabel("    activated: " + playerCacher.CachedPlayerControl.gameObject.active);
		}
		RuntimeDebugModeGuiMixin.slabel("condition: " + playerCacher.CachedCondition);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Poppet:");
		PlayerPoppetCache.CachePoppet poppetCacher = instance.PoppetCacher;
		RuntimeDebugModeGuiMixin.slabel("cached poppet: " + poppetCacher.CachedPoppet);
		if (poppetCacher.CachedPoppet != null)
		{
			RuntimeDebugModeGuiMixin.slabel("   gameObject: " + poppetCacher.CachedPoppet.gameObject);
			RuntimeDebugModeGuiMixin.slabel("    activated: " + poppetCacher.CachedPoppet.gameObject.active);
		}
		RuntimeDebugModeGuiMixin.slabel("condition: " + poppetCacher.CachedCondition);
		RuntimeDebugModeGuiMixin.slabel("abreq: " + poppetCacher.AbReq);
	}

	internal void _0024createDataviewPlayerPoppetCacheInfo_0024closure_00243515(ActionClassviewPlayerPoppetCacheInfo _0024act_0024t_0024406)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataviewAllAIControls_0024closure_00243516(ActionClassviewAllAIControls _0024act_0024t_0024409)
	{
		enumerateAllAI(delegate(AIControl _ai)
		{
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(_ai.gameObject.name).Append(" ").Append(_ai.CharacterName)
				.ToString()))
			{
				viewAIControl(_ai, new __DebugSubSkill__0024_0024createDataviewAllAIControls_0024closure_00243516_0024closure_00243517_0024callable436_0024783_41__(viewAllAIControls));
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("全員勝手に動かない"))
		{
			enumerateAllAI(delegate(AIControl _ai)
			{
				UnityEngine.Object.Destroy(_ai.AIProgram);
			});
		}
	}

	internal void _0024_0024createDataviewAllAIControls_0024closure_00243516_0024closure_00243517(AIControl _ai)
	{
		if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(_ai.gameObject.name).Append(" ").Append(_ai.CharacterName)
			.ToString()))
		{
			viewAIControl(_ai, new __DebugSubSkill__0024_0024createDataviewAllAIControls_0024closure_00243516_0024closure_00243517_0024callable436_0024783_41__(viewAllAIControls));
		}
	}

	internal void _0024_0024createDataviewAllAIControls_0024closure_00243516_0024closure_00243518(AIControl _ai)
	{
		UnityEngine.Object.Destroy(_ai.AIProgram);
	}

	internal void _0024createDataviewAllAIControls_0024closure_00243519(ActionClassviewAllAIControls _0024act_0024t_0024409)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataviewAIControl_0024closure_00243520(ActionClassviewAIControl _0024act_0024t_0024412)
	{
		_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298 _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024 = new _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_002414298();
		_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412 = _0024act_0024t_0024412;
		_showAIData(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("装備武器: " + _0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai.getMainWeapon());
		if (RuntimeDebugModeGuiMixin.button("スキル状態見る"))
		{
			viewSkills(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024._0024_0024act_0024t_0024412.ai, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataviewAIControl_0024closure_00243520_0024closure_00243521(_0024_0024createDataviewAIControl_0024closure_00243520_0024locals_0024, this).Invoke));
		}
	}

	internal void _0024createDataviewAIControl_0024closure_00243522(ActionClassviewAIControl _0024act_0024t_0024412)
	{
		if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024412.back != null)
		{
			_0024act_0024t_0024412.back.Call(new object[0]);
		}
	}

	internal void _0024createDataviewPoppets_0024closure_00243523(ActionClassviewPoppets _0024act_0024t_0024415)
	{
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		if (currentPlayer == null || currentPlayer.Poppets == null)
		{
			RuntimeDebugModeGuiMixin.slabel("連れ魔ペットはなぜかいません");
			return;
		}
		int i = 0;
		AIControl[] poppets = currentPlayer.Poppets;
		for (int length = poppets.Length; i < length; i = checked(i + 1))
		{
			if (!(poppets[i] == null))
			{
				viewAIControl(poppets[i], new __DebugSubSkill__0024createDataviewPoppets_0024closure_00243523_0024callable437_0024808_40__(viewPoppets));
			}
		}
	}

	internal void _0024createDataviewPoppets_0024closure_00243524(ActionClassviewPoppets _0024act_0024t_0024415)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDataviewPathfinderInfo_0024closure_00243528(ActionClassviewPathfinderInfo _0024act_0024t_0024418)
	{
		QuestMapper current = QuestMapper.Current;
		RuntimeDebugModeGuiMixin.label("QuestMapper: " + current);
		if (current != null)
		{
			RuntimeDebugModeGuiMixin.slabel("  initialized: " + current.Initialized);
			RuntimeDebugModeGuiMixin.slabel("  Pathfinder: " + current.Pathfinder);
		}
		Pathfinder instance = Pathfinder.Instance;
		RuntimeDebugModeGuiMixin.label("PathFinder: " + instance);
		if (instance != null)
		{
			Node[,] array = instance.DebugGetMap();
			RuntimeDebugModeGuiMixin.slabel("Map: " + array);
			if (array != null)
			{
				RuntimeDebugModeGuiMixin.slabel("  size: " + array.GetLength(0) + "/" + array.GetLength(1));
			}
			TDManager tDManager = instance.DebugGetTDManager();
			RuntimeDebugModeGuiMixin.slabel("TDManager: " + tDManager);
			if (tDManager != null)
			{
				RuntimeDebugModeGuiMixin.slabel("  tower: " + tDManager.DebugGetTower());
				RuntimeDebugModeGuiMixin.slabel("  tower num: " + tDManager.DebugGetTowerNum());
			}
		}
	}

	internal void _0024createDataviewPathfinderInfo_0024closure_00243529(ActionClassviewPathfinderInfo _0024act_0024t_0024418)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			if (_0024act_0024t_0024418.back != null)
			{
				_0024act_0024t_0024418.back.Call(new object[0]);
			}
		}
		else
		{
			mainMode();
		}
	}
}
