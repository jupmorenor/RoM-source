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
public class MagicGauge : MonoBehaviour
{
	[Serializable]
	public enum Flash
	{
		None,
		MagicUsing,
		Dead
	}

	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00242530;

		public string _0024act_0024t_00242531;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242532;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242533;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242534;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242535;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242536;

		public __ActionBase__0024act_0024t_00242532_0024callable98_0024110_5__ _0024act_0024t_00242537;

		public __ActionBase__0024act_0024t_00242538_0024callable99_0024110_5__ _0024act_0024t_00242538;

		public IEnumerator _0024act_0024t_00242542;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00242530.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassMagicPointDisplayMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassRemainingTimeDisplayMode : ActionBase
	{
		public int cntr;
	}

	[Serializable]
	public enum ActionEnum
	{
		RemainingTimeDisplayMode,
		MagicPointDisplayMode,
		NUM,
		_noaction_
	}

	public Color defaultColor;

	public Color hideColor;

	public SpriteFillGauge spriteFillGauge;

	public UISprite @base;

	public UITexture faceIcon;

	public UISprite frame;

	public RaidNamePlate nameLabel;

	public GameObject fullEffect;

	public Color magicBackColor;

	public Color[] timerColors;

	public Color timerBackColor;

	private Color[] defaultColors;

	private float blinkCount;

	private Color baseColor;

	private Color faceIconInitColor;

	private Color frameInitColor;

	private int currentMagicPoint;

	private int maxMagicPoint;

	private float currentRemainingTime;

	private float maxRemainingTime;

	private Flash _flash;

	private Dictionary<string, ActionBase> _0024act_0024t_00242539;

	private Dictionary<string, ActionEnum> _0024act_0024t_00242541;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00242540;

	public bool actionDebugFlag;

	public Flash flash
	{
		get
		{
			return _flash;
		}
		set
		{
			if (_flash == value)
			{
				return;
			}
			if (value == Flash.None && (bool)@base)
			{
				@base.color = baseColor;
			}
			if ((bool)faceIcon)
			{
				if (value == Flash.Dead)
				{
					faceIcon.color = new Color(0.333f, 0.333f, 0.333f, 1f);
					frame.color = new Color(0.333f, 0.333f, 0.333f, 1f);
				}
				else
				{
					faceIcon.color = faceIconInitColor;
					frame.color = frameInitColor;
					actUpdate();
				}
			}
			_flash = value;
		}
	}

	public bool IsMagicPointDisplayMode => currActionID("$default$") == ActionEnum.MagicPointDisplayMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassMagicPointDisplayMode MagicPointDisplayModeData => currAction("$default$") as ActionClassMagicPointDisplayMode;

	public bool IsRemainingTimeDisplayMode => currActionID("$default$") == ActionEnum.RemainingTimeDisplayMode;

	public ActionClassRemainingTimeDisplayMode RemainingTimeDisplayModeData => currAction("$default$") as ActionClassRemainingTimeDisplayMode;

	public MagicGauge()
	{
		defaultColor = Color.white;
		hideColor = Color.black;
		magicBackColor = new Color(0f, 0.23529412f, 0.3529412f, 1f);
		timerColors = new Color[2]
		{
			Color.green,
			Color.yellow
		};
		timerBackColor = Color.red;
		currentMagicPoint = 1;
		maxMagicPoint = 1;
		currentRemainingTime = 1f;
		maxRemainingTime = 1f;
		_0024act_0024t_00242539 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00242541 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public void Awake()
	{
		MagicPointDisplayMode();
		if ((bool)@base)
		{
			baseColor = @base.color;
		}
		if ((bool)faceIcon)
		{
			faceIconInitColor = faceIcon.color;
		}
		if ((bool)frame)
		{
			frameInitColor = frame.color;
		}
	}

	public void Start()
	{
	}

	public void Update()
	{
		actUpdate();
	}

	public void setFaceIcon(RespPoppet ppt)
	{
		if (!(faceIcon == null) && ppt != null && gameObject.activeSelf && enabled && faceIcon.enabled && faceIcon.gameObject.activeInHierarchy)
		{
			UIBasicUtility.SetPoppetIconTextureCoroutine(this, faceIcon, ppt, show: true);
		}
	}

	public void setName(string mapetName)
	{
		if (!(nameLabel != null))
		{
			return;
		}
		if (!string.IsNullOrEmpty(mapetName))
		{
			if (!nameLabel.gameObject.activeSelf)
			{
				nameLabel.gameObject.SetActive(value: true);
			}
			nameLabel.setName(mapetName);
		}
		else
		{
			nameLabel.setName(string.Empty);
			if (nameLabel.gameObject.activeSelf)
			{
				nameLabel.gameObject.SetActive(value: false);
			}
		}
	}

	public void setMagic(int val, int limit)
	{
		if (limit <= 0)
		{
			throw new AssertionFailedException("limit > 0");
		}
		currentMagicPoint = Mathf.Clamp(val, 0, limit);
		maxMagicPoint = limit;
	}

	public void setRemainingTime(float time, float maxTime)
	{
		if (!(maxRemainingTime > 0f))
		{
			throw new AssertionFailedException(string.Empty);
		}
		currentRemainingTime = Mathf.Clamp(time, 0f, maxTime);
		maxRemainingTime = maxTime;
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00242539.ContainsKey(grp)) ? null : _0024act_0024t_00242539[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00242541.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00242541[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00242539.ContainsKey(grp)) ? 0f : _0024act_0024t_00242539[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00242539.ContainsKey(grp)) ? 0f : _0024act_0024t_00242539[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00242539.ContainsKey(grp)) ? 0f : _0024act_0024t_00242539[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00242541.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00242531) && _0024act_0024t_00242539.ContainsKey(act._0024act_0024t_00242531) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00242539[act._0024act_0024t_00242531]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.RemainingTimeDisplayMode <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_00242531))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$2531)");
			}
			_0024act_0024t_00242539[act._0024act_0024t_00242531] = act;
			_0024act_0024t_00242541[act._0024act_0024t_00242531] = act._0024act_0024t_00242530;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00242540) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00242531);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00242531)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00242531)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00242533 != null)
		{
			actionBase._0024act_0024t_00242533(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00242532 != null)
			{
				act._0024act_0024t_00242532(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00242538 != null)
			{
				act._0024act_0024t_00242542 = act._0024act_0024t_00242538(act);
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
		foreach (ActionBase value in _0024act_0024t_00242539.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00242540 = 0;
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
			if (actionBase._0024act_0024t_00242534 != null)
			{
				actionBase._0024act_0024t_00242534(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00242542 != null && !actionBase._0024act_0024t_00242542.MoveNext())
			{
				actionBase._0024act_0024t_00242542 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00242539.Values)
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
		_0024act_0024t_00242540 = 0;
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
			if (actionBase._0024act_0024t_00242535 != null)
			{
				actionBase._0024act_0024t_00242535(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00242540 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00242539.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00242539[array2[i]];
				if (actionBase._0024act_0024t_00242536 != null)
				{
					actionBase._0024act_0024t_00242536(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00242539.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00242531 + " - " + value._0024act_0024t_00242530 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00242540 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00242539.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00242539[array2[i]];
			if (actionBase._0024act_0024t_00242537 != null)
			{
				actionBase._0024act_0024t_00242537(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "MagicGauge" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.MagicPointDisplayMode => createDataMagicPointDisplayMode(), 
			ActionEnum.RemainingTimeDisplayMode => createDataRemainingTimeDisplayMode(), 
			_ => null, 
		};
	}

	public ActionClassMagicPointDisplayMode MagicPointDisplayMode()
	{
		ActionClassMagicPointDisplayMode actionClassMagicPointDisplayMode = createMagicPointDisplayMode();
		changeAction(actionClassMagicPointDisplayMode);
		return actionClassMagicPointDisplayMode;
	}

	public ActionClassMagicPointDisplayMode createDataMagicPointDisplayMode()
	{
		ActionClassMagicPointDisplayMode actionClassMagicPointDisplayMode = new ActionClassMagicPointDisplayMode();
		actionClassMagicPointDisplayMode._0024act_0024t_00242530 = ActionEnum.MagicPointDisplayMode;
		actionClassMagicPointDisplayMode._0024act_0024t_00242531 = "$default$";
		actionClassMagicPointDisplayMode._0024act_0024t_00242532 = _0024adaptor_0024__MagicGauge_0024callable360_0024110_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024181.Adapt(delegate
		{
			if (@base != null)
			{
				@base.color = magicBackColor;
			}
		});
		actionClassMagicPointDisplayMode._0024act_0024t_00242534 = _0024adaptor_0024__MagicGauge_0024callable360_0024110_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024181.Adapt(delegate
		{
			updateFlash();
			updateGauge(currentMagicPoint, maxMagicPoint, getDefaultColor());
		});
		return actionClassMagicPointDisplayMode;
	}

	public ActionClassMagicPointDisplayMode createMagicPointDisplayMode()
	{
		return createDataMagicPointDisplayMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00242539.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00242539["$default$"];
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

	public ActionClassRemainingTimeDisplayMode RemainingTimeDisplayMode()
	{
		ActionClassRemainingTimeDisplayMode actionClassRemainingTimeDisplayMode = createRemainingTimeDisplayMode();
		changeAction(actionClassRemainingTimeDisplayMode);
		return actionClassRemainingTimeDisplayMode;
	}

	public ActionClassRemainingTimeDisplayMode createDataRemainingTimeDisplayMode()
	{
		ActionClassRemainingTimeDisplayMode actionClassRemainingTimeDisplayMode = new ActionClassRemainingTimeDisplayMode();
		actionClassRemainingTimeDisplayMode._0024act_0024t_00242530 = ActionEnum.RemainingTimeDisplayMode;
		actionClassRemainingTimeDisplayMode._0024act_0024t_00242531 = "$default$";
		actionClassRemainingTimeDisplayMode._0024act_0024t_00242532 = _0024adaptor_0024__MagicGauge_0024callable361_0024118_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024182.Adapt(delegate(ActionClassRemainingTimeDisplayMode _0024act_0024t_00242545)
		{
			_0024act_0024t_00242545.cntr = 0;
			if (@base != null)
			{
				@base.color = timerBackColor;
			}
		});
		actionClassRemainingTimeDisplayMode._0024act_0024t_00242534 = _0024adaptor_0024__MagicGauge_0024callable361_0024118_5___0024__ActionBase__0024act_0024t_00242532_0024callable98_0024110_5___0024182.Adapt(delegate(ActionClassRemainingTimeDisplayMode _0024act_0024t_00242545)
		{
			updateFlash();
			float val;
			float limit;
			Color[] array;
			checked
			{
				_0024act_0024t_00242545.cntr++;
				val = Mathf.CeilToInt(currentRemainingTime);
				limit = maxRemainingTime;
				array = timerColors;
			}
			updateGauge(val, limit, array[RuntimeServices.NormalizeArrayIndex(array, _0024act_0024t_00242545.cntr % timerColors.Length)]);
		});
		return actionClassRemainingTimeDisplayMode;
	}

	public ActionClassRemainingTimeDisplayMode createRemainingTimeDisplayMode()
	{
		return createDataRemainingTimeDisplayMode();
	}

	private void updateFlash()
	{
		if (!(@base == null) && flash == Flash.MagicUsing)
		{
			float a = Mathf.PingPong(Time.time, 1f);
			@base.color = new Color(1f, 1f, 0f, a);
		}
	}

	private void updateGauge(float val, float limit, Color setColor)
	{
		spriteFillGauge.updateGauge(val / limit, setColor);
	}

	public void setFullMode(bool b)
	{
		if (fullEffect != null && fullEffect.activeSelf != b)
		{
			fullEffect.SetActive(b);
		}
	}

	private Color getDefaultColor()
	{
		return defaultColor;
	}

	private static void ResetTween(GameObject go)
	{
		if (!(go == null))
		{
			int i = 0;
			UITweener[] components = go.GetComponents<UITweener>();
			for (int length = components.Length; i < length; i = checked(i + 1))
			{
				components[i].Play(forward: true);
				components[i].Reset();
			}
		}
	}

	internal void _0024createDataMagicPointDisplayMode_0024closure_00244279(ActionClassMagicPointDisplayMode _0024act_0024t_00242529)
	{
		if (@base != null)
		{
			@base.color = magicBackColor;
		}
	}

	internal void _0024createDataMagicPointDisplayMode_0024closure_00244280(ActionClassMagicPointDisplayMode _0024act_0024t_00242529)
	{
		updateFlash();
		updateGauge(currentMagicPoint, maxMagicPoint, getDefaultColor());
	}

	internal void _0024createDataRemainingTimeDisplayMode_0024closure_00244281(ActionClassRemainingTimeDisplayMode _0024act_0024t_00242545)
	{
		_0024act_0024t_00242545.cntr = 0;
		if (@base != null)
		{
			@base.color = timerBackColor;
		}
	}

	internal void _0024createDataRemainingTimeDisplayMode_0024closure_00244282(ActionClassRemainingTimeDisplayMode _0024act_0024t_00242545)
	{
		updateFlash();
		float val;
		float limit;
		Color[] array;
		checked
		{
			_0024act_0024t_00242545.cntr++;
			val = Mathf.CeilToInt(currentRemainingTime);
			limit = maxRemainingTime;
			array = timerColors;
		}
		updateGauge(val, limit, array[RuntimeServices.NormalizeArrayIndex(array, _0024act_0024t_00242545.cntr % timerColors.Length)]);
	}
}
