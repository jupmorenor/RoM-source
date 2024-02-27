using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;
using UnityEngine;

[Serializable]
public class GimmickIconCap : MonoBehaviour
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_00242495;

		public string _0024act_0024t_00242496;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242497;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242498;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242499;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242500;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242501;

		public __ActionBase__0024act_0024t_00242497_0024callable93_002421_5__ _0024act_0024t_00242502;

		public __ActionBase__0024act_0024t_00242503_0024callable94_002421_5__ _0024act_0024t_00242503;

		public IEnumerator _0024act_0024t_00242507;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_00242495.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassalways : ActionBase
	{
	}

	[Serializable]
	public class ActionClassnearPlayer : ActionBase
	{
	}

	[Serializable]
	public class ActionClassmanual : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		manual,
		nearPlayer,
		always,
		NUM,
		_noaction_
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024createDatanearPlayer_0024closure_00245005_002421345 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024pl_002421346;

			internal GimmickIconCap _0024self__002421347;

			public _0024(GimmickIconCap self_)
			{
				_0024self__002421347 = self_;
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
					_0024pl_002421346 = PlayerControl.CurrentPlayer;
					goto case 3;
				case 3:
					if (ObjUtilModule.Distance(_0024pl_002421346.gameObject, _0024self__002421347.gameObject) >= 3.8f)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if ((bool)_0024self__002421347.icon)
					{
						_0024self__002421347.icon.show();
					}
					goto case 4;
				case 4:
					if (ObjUtilModule.Distance(_0024pl_002421346.gameObject, _0024self__002421347.gameObject) <= 4f)
					{
						result = (YieldDefault(4) ? 1 : 0);
						break;
					}
					if ((bool)_0024self__002421347.icon)
					{
						_0024self__002421347.icon.hide();
					}
					goto case 3;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GimmickIconCap _0024self__002421348;

		public _0024_0024createDatanearPlayer_0024closure_00245005_002421345(GimmickIconCap self_)
		{
			_0024self__002421348 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421348);
		}
	}

	public ActionEnum mode;

	public GimmickIconTypes type;

	private GimmickIcon icon;

	private Dictionary<string, ActionBase> _0024act_0024t_00242504;

	private Dictionary<string, ActionEnum> _0024act_0024t_00242506;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_00242505;

	public bool actionDebugFlag;

	public bool TouchIcon => icon != null && icon.TouchIcon;

	public bool Isalways => currActionID("$default$") == ActionEnum.always;

	public float actionTime => currActionTime("$default$");

	public ActionClassalways alwaysData => currAction("$default$") as ActionClassalways;

	public bool IsnearPlayer => currActionID("$default$") == ActionEnum.nearPlayer;

	public ActionClassnearPlayer nearPlayerData => currAction("$default$") as ActionClassnearPlayer;

	public bool Ismanual => currActionID("$default$") == ActionEnum.manual;

	public ActionClassmanual manualData => currAction("$default$") as ActionClassmanual;

	public GimmickIcon Icon => icon;

	public GimmickIconCap()
	{
		_0024act_0024t_00242504 = new Dictionary<string, ActionBase>();
		_0024act_0024t_00242506 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public void Start()
	{
		GimmickIconSystem instance = GimmickIconSystem.Instance;
		if ((bool)instance)
		{
			icon = instance.getIcon(gameObject, type);
		}
		changeAction(mode);
	}

	public void Update()
	{
		actUpdate();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_00242504.ContainsKey(grp)) ? null : _0024act_0024t_00242504[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_00242506.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_00242506[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_00242504.ContainsKey(grp)) ? 0f : _0024act_0024t_00242504[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_00242504.ContainsKey(grp)) ? 0f : _0024act_0024t_00242504[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_00242504.ContainsKey(grp)) ? 0f : _0024act_0024t_00242504[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_00242506.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_00242496) && _0024act_0024t_00242504.ContainsKey(act._0024act_0024t_00242496) && RuntimeServices.EqualityOperator(act, _0024act_0024t_00242504[act._0024act_0024t_00242496]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.manual <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_00242496))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$2496)");
			}
			_0024act_0024t_00242504[act._0024act_0024t_00242496] = act;
			_0024act_0024t_00242506[act._0024act_0024t_00242496] = act._0024act_0024t_00242495;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_00242505) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_00242496);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				MonoBehaviour.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_00242496)
					.Append(")")
					.ToString());
			}
			else
			{
				MonoBehaviour.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_00242496)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_00242498 != null)
		{
			actionBase._0024act_0024t_00242498(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_00242497 != null)
			{
				act._0024act_0024t_00242497(act);
			}
			if (isExecuting(act) && act._0024act_0024t_00242503 != null)
			{
				act._0024act_0024t_00242507 = act._0024act_0024t_00242503(act);
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
		foreach (ActionBase value in _0024act_0024t_00242504.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_00242505 = 0;
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
			if (actionBase._0024act_0024t_00242499 != null)
			{
				actionBase._0024act_0024t_00242499(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_00242507 != null && !actionBase._0024act_0024t_00242507.MoveNext())
			{
				actionBase._0024act_0024t_00242507 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_00242504.Values)
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
		_0024act_0024t_00242505 = 0;
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
			if (actionBase._0024act_0024t_00242500 != null)
			{
				actionBase._0024act_0024t_00242500(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_00242505 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00242504.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_00242504[array2[i]];
				if (actionBase._0024act_0024t_00242501 != null)
				{
					actionBase._0024act_0024t_00242501(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_00242504.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_00242496 + " - " + value._0024act_0024t_00242495 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_00242505 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_00242504.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_00242504[array2[i]];
			if (actionBase._0024act_0024t_00242502 != null)
			{
				actionBase._0024act_0024t_00242502(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "GimmickIconCap" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.always => createDataalways(), 
			ActionEnum.nearPlayer => createDatanearPlayer(), 
			ActionEnum.manual => createDatamanual(), 
			_ => null, 
		};
	}

	public ActionClassalways always()
	{
		ActionClassalways actionClassalways = createalways();
		changeAction(actionClassalways);
		return actionClassalways;
	}

	public ActionClassalways createDataalways()
	{
		ActionClassalways actionClassalways = new ActionClassalways();
		actionClassalways._0024act_0024t_00242495 = ActionEnum.always;
		actionClassalways._0024act_0024t_00242496 = "$default$";
		actionClassalways._0024act_0024t_00242497 = _0024adaptor_0024__GimmickIconCap_0024callable357_002421_5___0024__ActionBase__0024act_0024t_00242497_0024callable93_002421_5___0024175.Adapt(delegate
		{
			if ((bool)icon)
			{
				icon.show();
			}
		});
		return actionClassalways;
	}

	public ActionClassalways createalways()
	{
		return createDataalways();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_00242504.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_00242504["$default$"];
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

	public ActionClassnearPlayer nearPlayer()
	{
		ActionClassnearPlayer actionClassnearPlayer = createnearPlayer();
		changeAction(actionClassnearPlayer);
		return actionClassnearPlayer;
	}

	public ActionClassnearPlayer createDatanearPlayer()
	{
		ActionClassnearPlayer actionClassnearPlayer = new ActionClassnearPlayer();
		actionClassnearPlayer._0024act_0024t_00242495 = ActionEnum.nearPlayer;
		actionClassnearPlayer._0024act_0024t_00242496 = "$default$";
		actionClassnearPlayer._0024act_0024t_00242503 = _0024adaptor_0024__GimmickIconCap_0024callable358_002425_5___0024__ActionBase__0024act_0024t_00242503_0024callable94_002421_5___0024176.Adapt((ActionClassnearPlayer _0024act_0024t_00242510) => new _0024_0024createDatanearPlayer_0024closure_00245005_002421345(this).GetEnumerator());
		return actionClassnearPlayer;
	}

	public ActionClassnearPlayer createnearPlayer()
	{
		return createDatanearPlayer();
	}

	public ActionClassmanual manual()
	{
		ActionClassmanual actionClassmanual = createmanual();
		changeAction(actionClassmanual);
		return actionClassmanual;
	}

	public ActionClassmanual createDatamanual()
	{
		ActionClassmanual actionClassmanual = new ActionClassmanual();
		actionClassmanual._0024act_0024t_00242495 = ActionEnum.manual;
		actionClassmanual._0024act_0024t_00242496 = "$default$";
		return actionClassmanual;
	}

	public ActionClassmanual createmanual()
	{
		return createDatamanual();
	}

	internal void _0024createDataalways_0024closure_00245004(ActionClassalways _0024act_0024t_00242494)
	{
		if ((bool)icon)
		{
			icon.show();
		}
	}

	internal IEnumerator _0024createDatanearPlayer_0024closure_00245005(ActionClassnearPlayer _0024act_0024t_00242510)
	{
		return new _0024_0024createDatanearPlayer_0024closure_00245005_002421345(this).GetEnumerator();
	}
}
