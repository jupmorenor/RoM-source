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
public class DebugSubNewEquipSystem : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024483;

		public string _0024act_0024t_0024484;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024485;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024486;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024487;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024488;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024489;

		public __ActionBase__0024act_0024t_0024485_0024callable25_002426_5__ _0024act_0024t_0024490;

		public __ActionBase__0024act_0024t_0024491_0024callable26_002426_5__ _0024act_0024t_0024491;

		public IEnumerator _0024act_0024t_0024495;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024483.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClasssetAndSendDeckToServer : ActionBase
	{
		public ApiUpdateDeck2 req;
	}

	[Serializable]
	public class ActionClasschangeMainWeapon : ActionBase
	{
		public RACE_TYPE race;
	}

	[Serializable]
	public class ActionClasschangeSubWeapon : ActionBase
	{
		public RACE_TYPE race;

		public int index;
	}

	[Serializable]
	public class ActionClasschangeMainPoppet : ActionBase
	{
	}

	[Serializable]
	public class ActionClasschangeSubPoppet : ActionBase
	{
		public RACE_TYPE race;

		public int index;
	}

	[Serializable]
	public class ActionClasshelp : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		help,
		changeSubPoppet,
		changeMainPoppet,
		changeSubWeapon,
		changeMainWeapon,
		setAndSendDeckToServer,
		mainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024selectWeapon_0024locals_002414301
	{
		internal RespWeapon[] _0024wpns;

		internal int _0024wnum;

		internal int _0024idx;

		internal __DebugSubNewEquipSystem_selectWeapon_0024callable27_0024237_55__ _0024c;
	}

	[Serializable]
	internal class _0024selectPoppet_0024locals_002414302
	{
		internal RespPoppet[] _0024ppts;

		internal int _0024pnum;

		internal int _0024idx;

		internal __DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__ _0024c;
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303
	{
		internal WeaponEquipments _0024weq;

		internal RespWeapon[] _0024subWpns;

		internal RespPoppet[] _0024subPpts;
	}

	[Serializable]
	internal class _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304
	{
		internal ActionClasschangeMainWeapon _0024_0024act_0024t_0024501;
	}

	[Serializable]
	internal class _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305
	{
		internal RespWeapon[] _0024wpns;

		internal ActionClasschangeSubWeapon _0024_0024act_0024t_0024504;
	}

	[Serializable]
	internal class _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306
	{
		internal RespPoppet[] _0024ppts;

		internal ActionClasschangeSubPoppet _0024_0024act_0024t_0024510;
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244037
	{
		internal RACE_TYPE[] _0024_00247197_002414695;

		internal int _0024_00247196_002414696;

		internal DebugSubNewEquipSystem _0024this_002414697;

		internal _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414698;

		public _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244037(RACE_TYPE[] _0024_00247197_002414695, int _0024_00247196_002414696, DebugSubNewEquipSystem _0024this_002414697, _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414698)
		{
			this._0024_00247197_002414695 = _0024_00247197_002414695;
			this._0024_00247196_002414696 = _0024_00247196_002414696;
			this._0024this_002414697 = _0024this_002414697;
			this._0024_0024locals_002414698 = _0024_0024locals_002414698;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label("メイン武器:");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(_0024_0024locals_002414698._0024weq.getMainWeapon(_0024_00247197_002414695[_0024_00247196_002414696])).ToString()))
			{
				_0024this_002414697.changeMainWeapon(_0024_00247197_002414695[_0024_00247196_002414696]);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244038
	{
		internal int _0024i_002414699;

		internal DebugSubNewEquipSystem _0024this_002414700;

		internal int _0024_00247196_002414701;

		internal _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414702;

		internal RACE_TYPE[] _0024_00247197_002414703;

		public _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244038(int _0024i_002414699, DebugSubNewEquipSystem _0024this_002414700, int _0024_00247196_002414701, _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414702, RACE_TYPE[] _0024_00247197_002414703)
		{
			this._0024i_002414699 = _0024i_002414699;
			this._0024this_002414700 = _0024this_002414700;
			this._0024_00247196_002414701 = _0024_00247196_002414701;
			this._0024_0024locals_002414702 = _0024_0024locals_002414702;
			this._0024_00247197_002414703 = _0024_00247197_002414703;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("  ").Append((object)_0024i_002414699).Append(":").ToString());
			StringBuilder stringBuilder = new StringBuilder();
			RespWeapon[] _0024subWpns = _0024_0024locals_002414702._0024subWpns;
			if (RuntimeDebugModeGuiMixin.button(stringBuilder.Append(_0024subWpns[RuntimeServices.NormalizeArrayIndex(_0024subWpns, _0024i_002414699)]).ToString()))
			{
				_0024this_002414700.changeSubWeapon(_0024_00247197_002414703[_0024_00247196_002414701], _0024i_002414699);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244039
	{
		internal int _0024_00247196_002414704;

		internal RACE_TYPE[] _0024_00247197_002414705;

		internal _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414706;

		internal DebugSubNewEquipSystem _0024this_002414707;

		internal int _0024i_002414708;

		public _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244039(int _0024_00247196_002414704, RACE_TYPE[] _0024_00247197_002414705, _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024locals_002414706, DebugSubNewEquipSystem _0024this_002414707, int _0024i_002414708)
		{
			this._0024_00247196_002414704 = _0024_00247196_002414704;
			this._0024_00247197_002414705 = _0024_00247197_002414705;
			this._0024_0024locals_002414706 = _0024_0024locals_002414706;
			this._0024this_002414707 = _0024this_002414707;
			this._0024i_002414708 = _0024i_002414708;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("  ").Append((object)_0024i_002414708).Append(":").ToString());
			StringBuilder stringBuilder = new StringBuilder();
			RespPoppet[] _0024subPpts = _0024_0024locals_002414706._0024subPpts;
			if (RuntimeDebugModeGuiMixin.button(stringBuilder.Append(_0024subPpts[RuntimeServices.NormalizeArrayIndex(_0024subPpts, _0024i_002414708)]).ToString()))
			{
				_0024this_002414707.changeSubPoppet(_0024_00247197_002414705[_0024_00247196_002414704], _0024i_002414708);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024closure_00244045
	{
		internal _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304 _0024_0024locals_002414709;

		public _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024closure_00244045(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304 _0024_0024locals_002414709)
		{
			this._0024_0024locals_002414709 = _0024_0024locals_002414709;
		}

		public void Invoke(RespWeapon w)
		{
			weaponEquipments.setMainWeapon(_0024_0024locals_002414709._0024_0024act_0024t_0024501.race, w);
		}
	}

	[Serializable]
	internal class _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024closure_00244048
	{
		internal _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305 _0024_0024locals_002414710;

		public _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024closure_00244048(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305 _0024_0024locals_002414710)
		{
			this._0024_0024locals_002414710 = _0024_0024locals_002414710;
		}

		public void Invoke(RespWeapon w)
		{
			RespWeapon[] _0024wpns = _0024_0024locals_002414710._0024wpns;
			_0024wpns[RuntimeServices.NormalizeArrayIndex(_0024wpns, _0024_0024locals_002414710._0024_0024act_0024t_0024504.index)] = w;
			weaponEquipments.setSubWeapons(_0024_0024locals_002414710._0024_0024act_0024t_0024504.race, _0024_0024locals_002414710._0024wpns);
		}
	}

	[Serializable]
	internal class _0024selectWeapon_0024closure_00244050
	{
		internal _0024selectWeapon_0024locals_002414301 _0024_0024locals_002414711;

		internal DebugSubNewEquipSystem _0024this_002414712;

		public _0024selectWeapon_0024closure_00244050(_0024selectWeapon_0024locals_002414301 _0024_0024locals_002414711, DebugSubNewEquipSystem _0024this_002414712)
		{
			this._0024_0024locals_002414711 = _0024_0024locals_002414711;
			this._0024this_002414712 = _0024this_002414712;
		}

		public void Invoke()
		{
			int num = Math.Min(checked(_0024_0024locals_002414711._0024idx + _0024this_002414712.WEAPON_POPPET_SELECT_COLUMNS), _0024_0024locals_002414711._0024wnum);
			int num2 = _0024_0024locals_002414711._0024idx;
			int num3 = num;
			int num4 = 1;
			if (num3 < num2)
			{
				num4 = -1;
			}
			while (num2 != num3)
			{
				int index = num2;
				num2 += num4;
				StringBuilder stringBuilder = new StringBuilder();
				RespWeapon[] _0024wpns = _0024_0024locals_002414711._0024wpns;
				if (RuntimeDebugModeGuiMixin.button(stringBuilder.Append(_0024wpns[RuntimeServices.NormalizeArrayIndex(_0024wpns, index)]).ToString()) && _0024_0024locals_002414711._0024c != null)
				{
					__DebugSubNewEquipSystem_selectWeapon_0024callable27_0024237_55__ _0024c = _0024_0024locals_002414711._0024c;
					RespWeapon[] _0024wpns2 = _0024_0024locals_002414711._0024wpns;
					_0024c(_0024wpns2[RuntimeServices.NormalizeArrayIndex(_0024wpns2, index)]);
				}
			}
			_0024_0024locals_002414711._0024idx = num;
		}
	}

	[Serializable]
	internal class _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024closure_00244055
	{
		internal _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306 _0024_0024locals_002414713;

		public _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024closure_00244055(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306 _0024_0024locals_002414713)
		{
			this._0024_0024locals_002414713 = _0024_0024locals_002414713;
		}

		public void Invoke(RespPoppet p)
		{
			RespPoppet[] _0024ppts = _0024_0024locals_002414713._0024ppts;
			_0024ppts[RuntimeServices.NormalizeArrayIndex(_0024ppts, _0024_0024locals_002414713._0024_0024act_0024t_0024510.index)] = p;
			weaponEquipments.setSubPoppets(_0024_0024locals_002414713._0024_0024act_0024t_0024510.race, _0024_0024locals_002414713._0024ppts);
		}
	}

	[Serializable]
	internal class _0024selectPoppet_0024closure_00244057
	{
		internal _0024selectPoppet_0024locals_002414302 _0024_0024locals_002414714;

		internal DebugSubNewEquipSystem _0024this_002414715;

		public _0024selectPoppet_0024closure_00244057(_0024selectPoppet_0024locals_002414302 _0024_0024locals_002414714, DebugSubNewEquipSystem _0024this_002414715)
		{
			this._0024_0024locals_002414714 = _0024_0024locals_002414714;
			this._0024this_002414715 = _0024this_002414715;
		}

		public void Invoke()
		{
			int num = Math.Min(checked(_0024_0024locals_002414714._0024idx + _0024this_002414715.WEAPON_POPPET_SELECT_COLUMNS), _0024_0024locals_002414714._0024pnum);
			int num2 = _0024_0024locals_002414714._0024idx;
			int num3 = num;
			int num4 = 1;
			if (num3 < num2)
			{
				num4 = -1;
			}
			while (num2 != num3)
			{
				int index = num2;
				num2 += num4;
				StringBuilder stringBuilder = new StringBuilder();
				RespPoppet[] _0024ppts = _0024_0024locals_002414714._0024ppts;
				if (RuntimeDebugModeGuiMixin.button(stringBuilder.Append(_0024ppts[RuntimeServices.NormalizeArrayIndex(_0024ppts, index)]).ToString()) && _0024_0024locals_002414714._0024c != null)
				{
					__DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__ _0024c = _0024_0024locals_002414714._0024c;
					RespPoppet[] _0024ppts2 = _0024_0024locals_002414714._0024ppts;
					_0024c(_0024ppts2[RuntimeServices.NormalizeArrayIndex(_0024ppts2, index)]);
				}
			}
			_0024_0024locals_002414714._0024idx = num;
		}
	}

	private int WEAPON_POPPET_SELECT_COLUMNS;

	[NonSerialized]
	private static WeaponEquipments weaponEquipments;

	private RespPoppet currentSelectedPoppet;

	private Dictionary<string, ActionBase> _0024act_0024t_0024492;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024494;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024493;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IssetAndSendDeckToServer => currActionID("$default$") == ActionEnum.setAndSendDeckToServer;

	public ActionClasssetAndSendDeckToServer setAndSendDeckToServerData => currAction("$default$") as ActionClasssetAndSendDeckToServer;

	public bool IschangeMainWeapon => currActionID("$default$") == ActionEnum.changeMainWeapon;

	public ActionClasschangeMainWeapon changeMainWeaponData => currAction("$default$") as ActionClasschangeMainWeapon;

	public bool IschangeSubWeapon => currActionID("$default$") == ActionEnum.changeSubWeapon;

	public ActionClasschangeSubWeapon changeSubWeaponData => currAction("$default$") as ActionClasschangeSubWeapon;

	public bool IschangeMainPoppet => currActionID("$default$") == ActionEnum.changeMainPoppet;

	public ActionClasschangeMainPoppet changeMainPoppetData => currAction("$default$") as ActionClasschangeMainPoppet;

	public bool IschangeSubPoppet => currActionID("$default$") == ActionEnum.changeSubPoppet;

	public ActionClasschangeSubPoppet changeSubPoppetData => currAction("$default$") as ActionClasschangeSubPoppet;

	public bool Ishelp => currActionID("$default$") == ActionEnum.help;

	public ActionClasshelp helpData => currAction("$default$") as ActionClasshelp;

	public DebugSubNewEquipSystem()
	{
		WEAPON_POPPET_SELECT_COLUMNS = 1;
		_0024act_0024t_0024492 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024494 = new Dictionary<string, ActionEnum>();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024492.ContainsKey(grp)) ? null : _0024act_0024t_0024492[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024494.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024494[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024492.ContainsKey(grp)) ? 0f : _0024act_0024t_0024492[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024492.ContainsKey(grp)) ? 0f : _0024act_0024t_0024492[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024492.ContainsKey(grp)) ? 0f : _0024act_0024t_0024492[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024494.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024484) && _0024act_0024t_0024492.ContainsKey(act._0024act_0024t_0024484) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024492[act._0024act_0024t_0024484]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.help <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024484))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$484)");
			}
			_0024act_0024t_0024492[act._0024act_0024t_0024484] = act;
			_0024act_0024t_0024494[act._0024act_0024t_0024484] = act._0024act_0024t_0024483;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024493) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024484);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024484)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024484)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024486 != null)
		{
			actionBase._0024act_0024t_0024486(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024485 != null)
			{
				act._0024act_0024t_0024485(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024491 != null)
			{
				act._0024act_0024t_0024495 = act._0024act_0024t_0024491(act);
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
		foreach (ActionBase value in _0024act_0024t_0024492.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024493 = 0;
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
			if (actionBase._0024act_0024t_0024487 != null)
			{
				actionBase._0024act_0024t_0024487(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024495 != null && !actionBase._0024act_0024t_0024495.MoveNext())
			{
				actionBase._0024act_0024t_0024495 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024492.Values)
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
		_0024act_0024t_0024493 = 0;
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
			if (actionBase._0024act_0024t_0024488 != null)
			{
				actionBase._0024act_0024t_0024488(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024493 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024492.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024492[array2[i]];
				if (actionBase._0024act_0024t_0024489 != null)
				{
					actionBase._0024act_0024t_0024489(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024492.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024484 + " - " + value._0024act_0024t_0024483 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024493 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024492.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024492[array2[i]];
			if (actionBase._0024act_0024t_0024490 != null)
			{
				actionBase._0024act_0024t_0024490(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubNewEquipSystem" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.setAndSendDeckToServer => createDatasetAndSendDeckToServer(), 
			ActionEnum.changeMainWeapon => createDatachangeMainWeapon(), 
			ActionEnum.changeSubWeapon => createDatachangeSubWeapon(), 
			ActionEnum.changeMainPoppet => createDatachangeMainPoppet(), 
			ActionEnum.changeSubPoppet => createDatachangeSubPoppet(), 
			ActionEnum.help => createDatahelp(), 
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
		actionClassmainMode._0024act_0024t_0024483 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024484 = "$default$";
		actionClassmainMode._0024act_0024t_0024485 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable271_002426_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002474.Adapt(delegate
		{
			if (weaponEquipments == null)
			{
				weaponEquipments = WeaponEquipments.Default();
			}
			if (!weaponEquipments.IsStrictlyValid)
			{
				weaponEquipments = WeaponEquipments.FromUserData();
			}
			if (currentSelectedPoppet == null)
			{
				UserData current2 = UserData.Current;
				if (current2.IsValidDeck2)
				{
					currentSelectedPoppet = current2.CurrentDeck2.MainPoppet;
				}
			}
			if (currentSelectedPoppet == null)
			{
				currentSelectedPoppet = new RespPoppet(1);
			}
		});
		actionClassmainMode._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable271_002426_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002474.Adapt(delegate
		{
			_0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024 = new _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303();
			RuntimeDebugModeGuiMixin.label("新装備システムテストモード");
			if (RuntimeDebugModeGuiMixin.button("このモードの説明を読む"))
			{
				help();
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("設定クリア"))
			{
				weaponEquipments = WeaponEquipments.Default();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("設定を反映しサーバーに送る(現在QA02のみ)"))
				{
					setAndSendDeckToServer();
				}
			});
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("ATK MAX 自動装備"))
			{
				weaponEquipments = WeaponEquipments.GetBestAtkWeapons();
			}
			_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq = weaponEquipments;
			int i = 0;
			RACE_TYPE[] array = new RACE_TYPE[2]
			{
				RACE_TYPE.Tensi,
				RACE_TYPE.Akuma
			};
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.label("装備:" + array[i] + "*******");
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244037(array, i, this, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024).Invoke));
				RuntimeDebugModeGuiMixin.label("サポート武器:");
				_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subWpns = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq.getSubWeapons(array[i]);
				int num = 0;
				int length2 = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subWpns.Length;
				if (length2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length2)
				{
					int _0024i_0024 = num;
					num++;
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244038(_0024i_0024, this, i, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024, array).Invoke));
				}
				RuntimeDebugModeGuiMixin.label("サポート魔ペット:");
				_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subPpts = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq.getSubPoppets(array[i]);
				int num2 = 0;
				int length3 = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subPpts.Length;
				if (length3 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < length3)
				{
					int _0024i_00242 = num2;
					num2++;
					RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244039(i, array, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024, this, _0024i_00242).Invoke));
				}
				RuntimeDebugModeGuiMixin.space(20);
				UserData current = UserData.Current;
				if (current != null)
				{
					RuntimeDebugModeGuiMixin.slabel("UserData.IsValid2:" + current.IsValidDeck2);
				}
				RuntimeDebugModeGuiMixin.space(20);
				current = UserData.Current;
				if (current != null)
				{
					RuntimeDebugModeGuiMixin.slabel("UserData.IsValid2:" + current.IsValidDeck2);
				}
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("メイン魔ペット:");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(currentSelectedPoppet).ToString()))
			{
				changeMainPoppet();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Box Swipe:");
			RuntimeDebugModeGuiMixin.label("    Swipe Smooth Start:" + SwipePanel.SwipeSmoothStart);
			RuntimeDebugModeGuiMixin.slabel("ドラッグ開始がゆるやかになります。");
			SwipePanel.SwipeSmoothStart = GUILayout.Toggle(SwipePanel.SwipeSmoothStart, string.Empty);
			RuntimeDebugModeGuiMixin.label("    Swipe X Speed Scale:" + SwipePanel.SwipeSpeedScale);
			RuntimeDebugModeGuiMixin.slabel("指を動かすスピードに対するスワイプの移動量の倍率です。");
			SwipePanel.SwipeSpeedScale = GUILayout.HorizontalSlider(SwipePanel.SwipeSpeedScale, 0f, 50f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.label("    Swipe Moment:" + SwipePanel.SwipeMoment);
			RuntimeDebugModeGuiMixin.slabel("指を離した後の、動き続けようとする慣性の値です。");
			SwipePanel.SwipeMoment = GUILayout.HorizontalSlider(SwipePanel.SwipeMoment, 0f, 200f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.label("    Spring Next MinX:" + SwipePanel.SpringNextMinX);
			RuntimeDebugModeGuiMixin.slabel("次のパネルに強制的に移動する、最小のドラッグ値です。");
			SwipePanel.SpringNextMinX = GUILayout.HorizontalSlider(SwipePanel.SpringNextMinX, 1f, SwipePanel.SwipeWidth * 0.5f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.label("    Spring Strength:" + SwipePanel.SpringStrength);
			RuntimeDebugModeGuiMixin.slabel("指を離した後、効いてくるバネの強さです。");
			SwipePanel.SpringStrength = GUILayout.HorizontalSlider(SwipePanel.SpringStrength, 0f, 100f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.label("    Spring Start Speed:" + SwipePanel.SpringStartSpeed);
			RuntimeDebugModeGuiMixin.slabel("指を離した後、それ以下でバネが効きはじめる移動スピードです。");
			SwipePanel.SpringStartSpeed = GUILayout.HorizontalSlider(SwipePanel.SpringStartSpeed, 0f, 100f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.label("    Spring Start Delay:" + SwipePanel.SpringDelay);
			RuntimeDebugModeGuiMixin.slabel("指を離した後、バネが効きはじめる遅延時間（秒）です。");
			SwipePanel.SpringDelay = GUILayout.HorizontalSlider(SwipePanel.SpringDelay, 0f, 2f, GUILayout.MaxWidth(500f));
			RuntimeDebugModeGuiMixin.space(100);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Box Swipe For Programing:");
			RuntimeDebugModeGuiMixin.label("    Unified Swipe Func:" + SwipePanel.UnifiedSwipeFunc);
			SwipePanel.UnifiedSwipeFunc = GUILayout.Toggle(SwipePanel.UnifiedSwipeFunc, string.Empty);
		});
		actionClassmainMode._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable271_002426_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002474.Adapt(delegate
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
		if (_0024act_0024t_0024492.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024492["$default$"];
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

	private RespDeck2[] generateDecks2()
	{
		WeaponEquipments weaponEquipments = DebugSubNewEquipSystem.weaponEquipments;
		RespDeck2 respDeck = new RespDeck2();
		respDeck.No = 1;
		respDeck.AngelBoxId = weaponEquipments.MainTenshiWeapon.Id;
		respDeck.DevilBoxId = weaponEquipments.MainAkumaWeapon.Id;
		if (currentSelectedPoppet != null)
		{
			respDeck.PoppetBoxId = currentSelectedPoppet.Id;
		}
		Boo.Lang.List<RespDeck2Support> list = new Boo.Lang.List<RespDeck2Support>();
		int i = 0;
		RespWeapon[] subTenshiWeapons = weaponEquipments.SubTenshiWeapons;
		checked
		{
			for (int length = subTenshiWeapons.Length; i < length; i++)
			{
				RespDeck2Support item = RespDeck2Support.FromWeaponBoxIdOfAngel(subTenshiWeapons[i].Id);
				list.Add(item);
			}
			int j = 0;
			RespWeapon[] subAkumaWeapons = weaponEquipments.SubAkumaWeapons;
			for (int length2 = subAkumaWeapons.Length; j < length2; j++)
			{
				RespDeck2Support item = RespDeck2Support.FromWeaponBoxIdOfDevil(subAkumaWeapons[j].Id);
				list.Add(item);
			}
			int k = 0;
			RespPoppet[] subTenshiPoppets = weaponEquipments.SubTenshiPoppets;
			for (int length3 = subTenshiPoppets.Length; k < length3; k++)
			{
				RespDeck2Support item = RespDeck2Support.FromPoppetBoxIdOfAngel(subTenshiPoppets[k].Id);
				list.Add(item);
			}
			int l = 0;
			RespPoppet[] subAkumaPoppets = weaponEquipments.SubAkumaPoppets;
			for (int length4 = subAkumaPoppets.Length; l < length4; l++)
			{
				RespDeck2Support item = RespDeck2Support.FromPoppetBoxIdOfDevil(subAkumaPoppets[l].Id);
				list.Add(item);
			}
			respDeck.Supports = (RespDeck2Support[])Builtins.array(typeof(RespDeck2Support), list);
			RespDeck2[] array = new RespDeck2[5];
			int num = 0;
			int num2 = 5;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num = unchecked(num + 1);
				array[RuntimeServices.NormalizeArrayIndex(array, num3)] = respDeck.clone();
				array[RuntimeServices.NormalizeArrayIndex(array, num3)].No = num3 + 1;
			}
			return array;
		}
	}

	public ActionClasssetAndSendDeckToServer setAndSendDeckToServer()
	{
		ActionClasssetAndSendDeckToServer actionClasssetAndSendDeckToServer = createsetAndSendDeckToServer();
		changeAction(actionClasssetAndSendDeckToServer);
		return actionClasssetAndSendDeckToServer;
	}

	public ActionClasssetAndSendDeckToServer createDatasetAndSendDeckToServer()
	{
		ActionClasssetAndSendDeckToServer actionClasssetAndSendDeckToServer = new ActionClasssetAndSendDeckToServer();
		actionClasssetAndSendDeckToServer._0024act_0024t_0024483 = ActionEnum.setAndSendDeckToServer;
		actionClasssetAndSendDeckToServer._0024act_0024t_0024484 = "$default$";
		actionClasssetAndSendDeckToServer._0024act_0024t_0024485 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable272_0024191_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002475.Adapt(delegate(ActionClasssetAndSendDeckToServer _0024act_0024t_0024498)
		{
			RespDeck2[] array = generateDecks2();
			UserData.Current.setDeck2(array);
			_0024act_0024t_0024498.req = ApiUpdateDeck2.FromDecks(array, 1);
			MerlinServer.Request(_0024act_0024t_0024498.req);
		});
		actionClasssetAndSendDeckToServer._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable272_0024191_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002475.Adapt(delegate(ActionClasssetAndSendDeckToServer _0024act_0024t_0024498)
		{
			if (!_0024act_0024t_0024498.req.IsEnd)
			{
				RuntimeDebugModeGuiMixin.label("通信中");
			}
			else
			{
				if (_0024act_0024t_0024498.req.IsOk)
				{
					RuntimeDebugModeGuiMixin.label("通信成功！");
				}
				else
				{
					RuntimeDebugModeGuiMixin.label("通信エラーが出ました...");
				}
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					mainMode();
				}
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("通信成功すれば、デッキは更新されます。");
			RuntimeDebugModeGuiMixin.slabel("。その際はサーバーには正しく設定は送信されていません。");
			RuntimeDebugModeGuiMixin.slabel("通信成功すると、メイン魔ペットも正しく設定されます。");
		});
		actionClasssetAndSendDeckToServer._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable272_0024191_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002475.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasssetAndSendDeckToServer;
	}

	public ActionClasssetAndSendDeckToServer createsetAndSendDeckToServer()
	{
		return createDatasetAndSendDeckToServer();
	}

	public ActionClasschangeMainWeapon changeMainWeapon(RACE_TYPE race)
	{
		ActionClasschangeMainWeapon actionClasschangeMainWeapon = createchangeMainWeapon(race);
		changeAction(actionClasschangeMainWeapon);
		return actionClasschangeMainWeapon;
	}

	public ActionClasschangeMainWeapon createDatachangeMainWeapon()
	{
		ActionClasschangeMainWeapon actionClasschangeMainWeapon = new ActionClasschangeMainWeapon();
		actionClasschangeMainWeapon._0024act_0024t_0024483 = ActionEnum.changeMainWeapon;
		actionClasschangeMainWeapon._0024act_0024t_0024484 = "$default$";
		actionClasschangeMainWeapon._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable273_0024218_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002476.Adapt(delegate(ActionClasschangeMainWeapon _0024act_0024t_0024501)
		{
			_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304 _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024 = new _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304();
			_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501 = _0024act_0024t_0024501;
			RuntimeDebugModeGuiMixin.label(new StringBuilder("メイン武器 ").Append(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501.race).ToString());
			RespWeapon mainWeapon = weaponEquipments.getMainWeapon(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501.race);
			RuntimeDebugModeGuiMixin.label(new StringBuilder("  ").Append(mainWeapon).ToString());
			selectWeapon(mainWeapon, new _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024closure_00244045(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024).Invoke);
		});
		actionClasschangeMainWeapon._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable273_0024218_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002476.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasschangeMainWeapon;
	}

	public ActionClasschangeMainWeapon createchangeMainWeapon(RACE_TYPE race)
	{
		ActionClasschangeMainWeapon actionClasschangeMainWeapon = createDatachangeMainWeapon();
		actionClasschangeMainWeapon.race = race;
		return actionClasschangeMainWeapon;
	}

	public ActionClasschangeSubWeapon changeSubWeapon(RACE_TYPE race, int index)
	{
		ActionClasschangeSubWeapon actionClasschangeSubWeapon = createchangeSubWeapon(race, index);
		changeAction(actionClasschangeSubWeapon);
		return actionClasschangeSubWeapon;
	}

	public ActionClasschangeSubWeapon createDatachangeSubWeapon()
	{
		ActionClasschangeSubWeapon actionClasschangeSubWeapon = new ActionClasschangeSubWeapon();
		actionClasschangeSubWeapon._0024act_0024t_0024483 = ActionEnum.changeSubWeapon;
		actionClasschangeSubWeapon._0024act_0024t_0024484 = "$default$";
		actionClasschangeSubWeapon._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable274_0024227_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002477.Adapt(delegate(ActionClasschangeSubWeapon _0024act_0024t_0024504)
		{
			_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305 _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024 = new _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305();
			_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504 = _0024act_0024t_0024504;
			RuntimeDebugModeGuiMixin.label(new StringBuilder("サポート武器 ").Append(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.race).Append(":").Append((object)_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)
				.ToString());
			_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns = weaponEquipments.getSubWeapons(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.race);
			StringBuilder stringBuilder = new StringBuilder("  ");
			RespWeapon[] _0024wpns = _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns;
			RuntimeDebugModeGuiMixin.label(stringBuilder.Append(_0024wpns[RuntimeServices.NormalizeArrayIndex(_0024wpns, _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)]).ToString());
			RespWeapon[] _0024wpns2 = _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns;
			selectWeapon(_0024wpns2[RuntimeServices.NormalizeArrayIndex(_0024wpns2, _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)], new _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024closure_00244048(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024).Invoke);
		});
		actionClasschangeSubWeapon._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable274_0024227_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002477.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasschangeSubWeapon;
	}

	public ActionClasschangeSubWeapon createchangeSubWeapon(RACE_TYPE race, int index)
	{
		ActionClasschangeSubWeapon actionClasschangeSubWeapon = createDatachangeSubWeapon();
		actionClasschangeSubWeapon.race = race;
		actionClasschangeSubWeapon.index = index;
		return actionClasschangeSubWeapon;
	}

	private void selectWeapon(RespWeapon src, __DebugSubNewEquipSystem_selectWeapon_0024callable27_0024237_55__ c)
	{
		_0024selectWeapon_0024locals_002414301 _0024selectWeapon_0024locals_0024 = new _0024selectWeapon_0024locals_002414301();
		_0024selectWeapon_0024locals_0024._0024c = c;
		UserBoxData userBoxData = UserData.Current.userBoxData;
		_0024selectWeapon_0024locals_0024._0024wpns = userBoxData.Weapons;
		_0024selectWeapon_0024locals_0024._0024wnum = _0024selectWeapon_0024locals_0024._0024wpns.Length;
		_0024selectWeapon_0024locals_0024._0024idx = 0;
		while (_0024selectWeapon_0024locals_0024._0024idx < _0024selectWeapon_0024locals_0024._0024wnum)
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024selectWeapon_0024closure_00244050(_0024selectWeapon_0024locals_0024, this).Invoke));
		}
	}

	public ActionClasschangeMainPoppet changeMainPoppet()
	{
		ActionClasschangeMainPoppet actionClasschangeMainPoppet = createchangeMainPoppet();
		changeAction(actionClasschangeMainPoppet);
		return actionClasschangeMainPoppet;
	}

	public ActionClasschangeMainPoppet createDatachangeMainPoppet()
	{
		ActionClasschangeMainPoppet actionClasschangeMainPoppet = new ActionClasschangeMainPoppet();
		actionClasschangeMainPoppet._0024act_0024t_0024483 = ActionEnum.changeMainPoppet;
		actionClasschangeMainPoppet._0024act_0024t_0024484 = "$default$";
		actionClasschangeMainPoppet._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable275_0024250_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002478.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("メイン魔ペット ").Append(currentSelectedPoppet).ToString());
			selectPoppet(currentSelectedPoppet, delegate(RespPoppet p)
			{
				currentSelectedPoppet = p;
			});
		});
		actionClasschangeMainPoppet._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable275_0024250_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002478.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasschangeMainPoppet;
	}

	public ActionClasschangeMainPoppet createchangeMainPoppet()
	{
		return createDatachangeMainPoppet();
	}

	public ActionClasschangeSubPoppet changeSubPoppet(RACE_TYPE race, int index)
	{
		ActionClasschangeSubPoppet actionClasschangeSubPoppet = createchangeSubPoppet(race, index);
		changeAction(actionClasschangeSubPoppet);
		return actionClasschangeSubPoppet;
	}

	public ActionClasschangeSubPoppet createDatachangeSubPoppet()
	{
		ActionClasschangeSubPoppet actionClasschangeSubPoppet = new ActionClasschangeSubPoppet();
		actionClasschangeSubPoppet._0024act_0024t_0024483 = ActionEnum.changeSubPoppet;
		actionClasschangeSubPoppet._0024act_0024t_0024484 = "$default$";
		actionClasschangeSubPoppet._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable276_0024257_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002479.Adapt(delegate(ActionClasschangeSubPoppet _0024act_0024t_0024510)
		{
			_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306 _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024 = new _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306();
			_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510 = _0024act_0024t_0024510;
			RuntimeDebugModeGuiMixin.label(new StringBuilder("サポート魔ペット ").Append(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.race).Append(":").Append((object)_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)
				.ToString());
			_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts = weaponEquipments.getSubPoppets(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.race);
			StringBuilder stringBuilder = new StringBuilder("   ");
			RespPoppet[] _0024ppts = _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts;
			RuntimeDebugModeGuiMixin.label(stringBuilder.Append(_0024ppts[RuntimeServices.NormalizeArrayIndex(_0024ppts, _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)]).ToString());
			RespPoppet[] _0024ppts2 = _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts;
			selectPoppet(_0024ppts2[RuntimeServices.NormalizeArrayIndex(_0024ppts2, _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)], new _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024closure_00244055(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024).Invoke);
		});
		actionClasschangeSubPoppet._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable276_0024257_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002479.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasschangeSubPoppet;
	}

	public ActionClasschangeSubPoppet createchangeSubPoppet(RACE_TYPE race, int index)
	{
		ActionClasschangeSubPoppet actionClasschangeSubPoppet = createDatachangeSubPoppet();
		actionClasschangeSubPoppet.race = race;
		actionClasschangeSubPoppet.index = index;
		return actionClasschangeSubPoppet;
	}

	private void selectPoppet(RespPoppet src, __DebugSubNewEquipSystem_selectPoppet_0024callable28_0024267_55__ c)
	{
		_0024selectPoppet_0024locals_002414302 _0024selectPoppet_0024locals_0024 = new _0024selectPoppet_0024locals_002414302();
		_0024selectPoppet_0024locals_0024._0024c = c;
		UserBoxData userBoxData = UserData.Current.userBoxData;
		_0024selectPoppet_0024locals_0024._0024ppts = userBoxData.Muppets;
		_0024selectPoppet_0024locals_0024._0024pnum = _0024selectPoppet_0024locals_0024._0024ppts.Length;
		_0024selectPoppet_0024locals_0024._0024idx = 0;
		while (_0024selectPoppet_0024locals_0024._0024idx < _0024selectPoppet_0024locals_0024._0024pnum)
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024selectPoppet_0024closure_00244057(_0024selectPoppet_0024locals_0024, this).Invoke));
		}
	}

	public ActionClasshelp help()
	{
		ActionClasshelp actionClasshelp = createhelp();
		changeAction(actionClasshelp);
		return actionClasshelp;
	}

	public ActionClasshelp createDatahelp()
	{
		ActionClasshelp actionClasshelp = new ActionClasshelp();
		actionClasshelp._0024act_0024t_0024483 = ActionEnum.help;
		actionClasshelp._0024act_0024t_0024484 = "$default$";
		actionClasshelp._0024act_0024t_0024489 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable277_0024280_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002480.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("このモードの説明");
			RuntimeDebugModeGuiMixin.slabel("このモードは正規の「新」装備用画面ができるまでの仮です。");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("適当に選択して「設定を反映する」ボタンを押すと、次に入るクエストから設定が反映されます（通信無し）");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("注意点:");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("このモードでは、フレンド魔ペット装備は設定できません。");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("新装備画面の代替機能なので、ボックスに無いものは装備できません。");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("重複装備すると「設定を反映」では問題ありませんが、「設定を反映しサーバーに送る」は通信エラーがでます。");
			RuntimeDebugModeGuiMixin.slabel("「設定クリア」のまま「..サーバーに送る」をした場合もボックスにないものを装備しようとするので同様です。");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				mainMode();
			}
		});
		actionClasshelp._0024act_0024t_0024487 = _0024adaptor_0024__DebugSubNewEquipSystem_0024callable277_0024280_5___0024__ActionBase__0024act_0024t_0024485_0024callable25_002426_5___002480.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClasshelp;
	}

	public ActionClasshelp createhelp()
	{
		return createDatahelp();
	}

	internal void _0024createDatamainMode_0024closure_00244034(ActionClassmainMode _0024act_0024t_0024482)
	{
		if (weaponEquipments == null)
		{
			weaponEquipments = WeaponEquipments.Default();
		}
		if (!weaponEquipments.IsStrictlyValid)
		{
			weaponEquipments = WeaponEquipments.FromUserData();
		}
		if (currentSelectedPoppet == null)
		{
			UserData current = UserData.Current;
			if (current.IsValidDeck2)
			{
				currentSelectedPoppet = current.CurrentDeck2.MainPoppet;
			}
		}
		if (currentSelectedPoppet == null)
		{
			currentSelectedPoppet = new RespPoppet(1);
		}
	}

	internal void _0024createDatamainMode_0024closure_00244035(ActionClassmainMode _0024act_0024t_0024482)
	{
		_0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303 _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024 = new _0024_0024createDatamainMode_0024closure_00244035_0024locals_002414303();
		RuntimeDebugModeGuiMixin.label("新装備システムテストモード");
		if (RuntimeDebugModeGuiMixin.button("このモードの説明を読む"))
		{
			help();
		}
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("設定クリア"))
		{
			weaponEquipments = WeaponEquipments.Default();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("設定を反映しサーバーに送る(現在QA02のみ)"))
			{
				setAndSendDeckToServer();
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("ATK MAX 自動装備"))
		{
			weaponEquipments = WeaponEquipments.GetBestAtkWeapons();
		}
		_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq = weaponEquipments;
		int i = 0;
		RACE_TYPE[] array = new RACE_TYPE[2]
		{
			RACE_TYPE.Tensi,
			RACE_TYPE.Akuma
		};
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("装備:" + array[i] + "*******");
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244037(array, i, this, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024).Invoke));
			RuntimeDebugModeGuiMixin.label("サポート武器:");
			_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subWpns = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq.getSubWeapons(array[i]);
			int num = 0;
			int length2 = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subWpns.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length2)
			{
				int _0024i_0024 = num;
				num++;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244038(_0024i_0024, this, i, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024, array).Invoke));
			}
			RuntimeDebugModeGuiMixin.label("サポート魔ペット:");
			_0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subPpts = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024weq.getSubPoppets(array[i]);
			int num2 = 0;
			int length3 = _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024._0024subPpts.Length;
			if (length3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < length3)
			{
				int _0024i_00242 = num2;
				num2++;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244039(i, array, _0024_0024createDatamainMode_0024closure_00244035_0024locals_0024, this, _0024i_00242).Invoke));
			}
			RuntimeDebugModeGuiMixin.space(20);
			UserData current = UserData.Current;
			if (current != null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData.IsValid2:" + current.IsValidDeck2);
			}
			RuntimeDebugModeGuiMixin.space(20);
			current = UserData.Current;
			if (current != null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData.IsValid2:" + current.IsValidDeck2);
			}
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("メイン魔ペット:");
		if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(currentSelectedPoppet).ToString()))
		{
			changeMainPoppet();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Box Swipe:");
		RuntimeDebugModeGuiMixin.label("    Swipe Smooth Start:" + SwipePanel.SwipeSmoothStart);
		RuntimeDebugModeGuiMixin.slabel("ドラッグ開始がゆるやかになります。");
		SwipePanel.SwipeSmoothStart = GUILayout.Toggle(SwipePanel.SwipeSmoothStart, string.Empty);
		RuntimeDebugModeGuiMixin.label("    Swipe X Speed Scale:" + SwipePanel.SwipeSpeedScale);
		RuntimeDebugModeGuiMixin.slabel("指を動かすスピードに対するスワイプの移動量の倍率です。");
		SwipePanel.SwipeSpeedScale = GUILayout.HorizontalSlider(SwipePanel.SwipeSpeedScale, 0f, 50f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.label("    Swipe Moment:" + SwipePanel.SwipeMoment);
		RuntimeDebugModeGuiMixin.slabel("指を離した後の、動き続けようとする慣性の値です。");
		SwipePanel.SwipeMoment = GUILayout.HorizontalSlider(SwipePanel.SwipeMoment, 0f, 200f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.label("    Spring Next MinX:" + SwipePanel.SpringNextMinX);
		RuntimeDebugModeGuiMixin.slabel("次のパネルに強制的に移動する、最小のドラッグ値です。");
		SwipePanel.SpringNextMinX = GUILayout.HorizontalSlider(SwipePanel.SpringNextMinX, 1f, SwipePanel.SwipeWidth * 0.5f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.label("    Spring Strength:" + SwipePanel.SpringStrength);
		RuntimeDebugModeGuiMixin.slabel("指を離した後、効いてくるバネの強さです。");
		SwipePanel.SpringStrength = GUILayout.HorizontalSlider(SwipePanel.SpringStrength, 0f, 100f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.label("    Spring Start Speed:" + SwipePanel.SpringStartSpeed);
		RuntimeDebugModeGuiMixin.slabel("指を離した後、それ以下でバネが効きはじめる移動スピードです。");
		SwipePanel.SpringStartSpeed = GUILayout.HorizontalSlider(SwipePanel.SpringStartSpeed, 0f, 100f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.label("    Spring Start Delay:" + SwipePanel.SpringDelay);
		RuntimeDebugModeGuiMixin.slabel("指を離した後、バネが効きはじめる遅延時間（秒）です。");
		SwipePanel.SpringDelay = GUILayout.HorizontalSlider(SwipePanel.SpringDelay, 0f, 2f, GUILayout.MaxWidth(500f));
		RuntimeDebugModeGuiMixin.space(100);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Box Swipe For Programing:");
		RuntimeDebugModeGuiMixin.label("    Unified Swipe Func:" + SwipePanel.UnifiedSwipeFunc);
		SwipePanel.UnifiedSwipeFunc = GUILayout.Toggle(SwipePanel.UnifiedSwipeFunc, string.Empty);
	}

	internal void _0024_0024createDatamainMode_0024closure_00244035_0024closure_00244036()
	{
		if (RuntimeDebugModeGuiMixin.button("設定を反映しサーバーに送る(現在QA02のみ)"))
		{
			setAndSendDeckToServer();
		}
	}

	internal void _0024createDatamainMode_0024closure_00244040(ActionClassmainMode _0024act_0024t_0024482)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDatasetAndSendDeckToServer_0024closure_00244041(ActionClasssetAndSendDeckToServer _0024act_0024t_0024498)
	{
		RespDeck2[] array = generateDecks2();
		UserData.Current.setDeck2(array);
		_0024act_0024t_0024498.req = ApiUpdateDeck2.FromDecks(array, 1);
		MerlinServer.Request(_0024act_0024t_0024498.req);
	}

	internal void _0024createDatasetAndSendDeckToServer_0024closure_00244042(ActionClasssetAndSendDeckToServer _0024act_0024t_0024498)
	{
		if (!_0024act_0024t_0024498.req.IsEnd)
		{
			RuntimeDebugModeGuiMixin.label("通信中");
		}
		else
		{
			if (_0024act_0024t_0024498.req.IsOk)
			{
				RuntimeDebugModeGuiMixin.label("通信成功！");
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("通信エラーが出ました...");
			}
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				mainMode();
			}
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("通信成功すれば、デッキは更新されます。");
		RuntimeDebugModeGuiMixin.slabel("。その際はサーバーには正しく設定は送信されていません。");
		RuntimeDebugModeGuiMixin.slabel("通信成功すると、メイン魔ペットも正しく設定されます。");
	}

	internal void _0024createDatasetAndSendDeckToServer_0024closure_00244043(ActionClasssetAndSendDeckToServer _0024act_0024t_0024498)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatachangeMainWeapon_0024closure_00244044(ActionClasschangeMainWeapon _0024act_0024t_0024501)
	{
		_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304 _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024 = new _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_002414304();
		_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501 = _0024act_0024t_0024501;
		RuntimeDebugModeGuiMixin.label(new StringBuilder("メイン武器 ").Append(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501.race).ToString());
		RespWeapon mainWeapon = weaponEquipments.getMainWeapon(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024._0024_0024act_0024t_0024501.race);
		RuntimeDebugModeGuiMixin.label(new StringBuilder("  ").Append(mainWeapon).ToString());
		selectWeapon(mainWeapon, new _0024_0024createDatachangeMainWeapon_0024closure_00244044_0024closure_00244045(_0024_0024createDatachangeMainWeapon_0024closure_00244044_0024locals_0024).Invoke);
	}

	internal void _0024createDatachangeMainWeapon_0024closure_00244046(ActionClasschangeMainWeapon _0024act_0024t_0024501)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatachangeSubWeapon_0024closure_00244047(ActionClasschangeSubWeapon _0024act_0024t_0024504)
	{
		_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305 _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024 = new _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_002414305();
		_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504 = _0024act_0024t_0024504;
		RuntimeDebugModeGuiMixin.label(new StringBuilder("サポート武器 ").Append(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.race).Append(":").Append((object)_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)
			.ToString());
		_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns = weaponEquipments.getSubWeapons(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.race);
		StringBuilder stringBuilder = new StringBuilder("  ");
		RespWeapon[] _0024wpns = _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns;
		RuntimeDebugModeGuiMixin.label(stringBuilder.Append(_0024wpns[RuntimeServices.NormalizeArrayIndex(_0024wpns, _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)]).ToString());
		RespWeapon[] _0024wpns2 = _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024wpns;
		selectWeapon(_0024wpns2[RuntimeServices.NormalizeArrayIndex(_0024wpns2, _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024._0024_0024act_0024t_0024504.index)], new _0024_0024createDatachangeSubWeapon_0024closure_00244047_0024closure_00244048(_0024_0024createDatachangeSubWeapon_0024closure_00244047_0024locals_0024).Invoke);
	}

	internal void _0024createDatachangeSubWeapon_0024closure_00244049(ActionClasschangeSubWeapon _0024act_0024t_0024504)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatachangeMainPoppet_0024closure_00244051(ActionClasschangeMainPoppet _0024act_0024t_0024507)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("メイン魔ペット ").Append(currentSelectedPoppet).ToString());
		selectPoppet(currentSelectedPoppet, delegate(RespPoppet p)
		{
			currentSelectedPoppet = p;
		});
	}

	internal void _0024_0024createDatachangeMainPoppet_0024closure_00244051_0024closure_00244052(RespPoppet p)
	{
		currentSelectedPoppet = p;
	}

	internal void _0024createDatachangeMainPoppet_0024closure_00244053(ActionClasschangeMainPoppet _0024act_0024t_0024507)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatachangeSubPoppet_0024closure_00244054(ActionClasschangeSubPoppet _0024act_0024t_0024510)
	{
		_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306 _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024 = new _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_002414306();
		_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510 = _0024act_0024t_0024510;
		RuntimeDebugModeGuiMixin.label(new StringBuilder("サポート魔ペット ").Append(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.race).Append(":").Append((object)_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)
			.ToString());
		_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts = weaponEquipments.getSubPoppets(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.race);
		StringBuilder stringBuilder = new StringBuilder("   ");
		RespPoppet[] _0024ppts = _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts;
		RuntimeDebugModeGuiMixin.label(stringBuilder.Append(_0024ppts[RuntimeServices.NormalizeArrayIndex(_0024ppts, _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)]).ToString());
		RespPoppet[] _0024ppts2 = _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024ppts;
		selectPoppet(_0024ppts2[RuntimeServices.NormalizeArrayIndex(_0024ppts2, _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024._0024_0024act_0024t_0024510.index)], new _0024_0024createDatachangeSubPoppet_0024closure_00244054_0024closure_00244055(_0024_0024createDatachangeSubPoppet_0024closure_00244054_0024locals_0024).Invoke);
	}

	internal void _0024createDatachangeSubPoppet_0024closure_00244056(ActionClasschangeSubPoppet _0024act_0024t_0024510)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}

	internal void _0024createDatahelp_0024closure_00244058(ActionClasshelp _0024act_0024t_0024513)
	{
		RuntimeDebugModeGuiMixin.label("このモードの説明");
		RuntimeDebugModeGuiMixin.slabel("このモードは正規の「新」装備用画面ができるまでの仮です。");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("適当に選択して「設定を反映する」ボタンを押すと、次に入るクエストから設定が反映されます（通信無し）");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("注意点:");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("このモードでは、フレンド魔ペット装備は設定できません。");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("新装備画面の代替機能なので、ボックスに無いものは装備できません。");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("重複装備すると「設定を反映」では問題ありませんが、「設定を反映しサーバーに送る」は通信エラーがでます。");
		RuntimeDebugModeGuiMixin.slabel("「設定クリア」のまま「..サーバーに送る」をした場合もボックスにないものを装備しようとするので同様です。");
		if (RuntimeDebugModeGuiMixin.button("戻る"))
		{
			mainMode();
		}
	}

	internal void _0024createDatahelp_0024closure_00244059(ActionClasshelp _0024act_0024t_0024513)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}
}
