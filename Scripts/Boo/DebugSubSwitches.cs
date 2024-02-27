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
public class DebugSubSwitches : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024536;

		public string _0024act_0024t_0024537;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024538;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024539;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024540;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024541;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024542;

		public __ActionBase__0024act_0024t_0024538_0024callable31_002437_5__ _0024act_0024t_0024543;

		public __ActionBase__0024act_0024t_0024544_0024callable32_002437_5__ _0024act_0024t_0024544;

		public IEnumerator _0024act_0024t_0024548;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024536.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassselectWeapon : ActionBase
	{
		public bool isTenshi;
	}

	[Serializable]
	public enum ActionEnum
	{
		selectWeapon,
		mainMode,
		NUM,
		_noaction_
	}

	[NonSerialized]
	protected static int currentEquipSortType;

	private RespWeapon tenshiWeapon;

	private RespWeapon akumaWeapon;

	private Dictionary<string, ActionBase> _0024act_0024t_0024545;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024547;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024546;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IsselectWeapon => currActionID("$default$") == ActionEnum.selectWeapon;

	public ActionClassselectWeapon selectWeaponData => currAction("$default$") as ActionClassselectWeapon;

	public DebugSubSwitches()
	{
		_0024act_0024t_0024545 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024547 = new Dictionary<string, ActionEnum>();
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
		currentEquipSortType = 0;
		mainMode();
	}

	public override void Exit()
	{
		GameParameter.Save();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024545.ContainsKey(grp)) ? null : _0024act_0024t_0024545[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024547.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024547[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024545.ContainsKey(grp)) ? 0f : _0024act_0024t_0024545[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024545.ContainsKey(grp)) ? 0f : _0024act_0024t_0024545[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024545.ContainsKey(grp)) ? 0f : _0024act_0024t_0024545[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024547.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024537) && _0024act_0024t_0024545.ContainsKey(act._0024act_0024t_0024537) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024545[act._0024act_0024t_0024537]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.selectWeapon <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024537))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$537)");
			}
			_0024act_0024t_0024545[act._0024act_0024t_0024537] = act;
			_0024act_0024t_0024547[act._0024act_0024t_0024537] = act._0024act_0024t_0024536;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024546) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024537);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024537)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024537)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024539 != null)
		{
			actionBase._0024act_0024t_0024539(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024538 != null)
			{
				act._0024act_0024t_0024538(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024544 != null)
			{
				act._0024act_0024t_0024548 = act._0024act_0024t_0024544(act);
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
		foreach (ActionBase value in _0024act_0024t_0024545.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024546 = 0;
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
			if (actionBase._0024act_0024t_0024540 != null)
			{
				actionBase._0024act_0024t_0024540(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024548 != null && !actionBase._0024act_0024t_0024548.MoveNext())
			{
				actionBase._0024act_0024t_0024548 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024545.Values)
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
		_0024act_0024t_0024546 = 0;
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
			if (actionBase._0024act_0024t_0024541 != null)
			{
				actionBase._0024act_0024t_0024541(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024546 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024545.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024545[array2[i]];
				if (actionBase._0024act_0024t_0024542 != null)
				{
					actionBase._0024act_0024t_0024542(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024545.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024537 + " - " + value._0024act_0024t_0024536 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024546 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024545.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024545[array2[i]];
			if (actionBase._0024act_0024t_0024543 != null)
			{
				actionBase._0024act_0024t_0024543(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubSwitches" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.selectWeapon => createDataselectWeapon(), 
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
		actionClassmainMode._0024act_0024t_0024536 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024537 = "$default$";
		actionClassmainMode._0024act_0024t_0024542 = _0024adaptor_0024__DebugSubSwiches_0024callable282_002437_5___0024__ActionBase__0024act_0024t_0024538_0024callable31_002437_5___002483.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("enable FPS") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
				{
					ExtensionsModule.SetComponent<AppStatusInfo>(RuntimeDebugModeGuiMixin.debugModeObject);
				}
				if (RuntimeDebugModeGuiMixin.button("FPS 2") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
				{
					ExtensionsModule.SetComponent<FPSDisp>(RuntimeDebugModeGuiMixin.debugModeObject);
				}
			});
			RuntimeDebugModeGuiMixin.space(20);
			GameParameter.questFreeRun = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.questFreeRun, "Quest Free Run");
			RuntimeDebugModeGuiMixin.space(10);
			UserConfigData config = UserData.Current.Config;
			if (config != null)
			{
				config.AutoCombinationOn = RuntimeDebugModeGuiMixin.boolButtons(config.AutoCombinationOn, "Auto Combination");
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("auto combination 無理");
			}
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.lockonShader = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.lockonShader, "LockOn Shader");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.notDead = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDead, "Not Dead");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.oneHitKill = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.oneHitKill, "OneHit Kill");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.jisatu = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.jisatu, "Jisatu");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.tutorialSkip = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.tutorialSkip, "Skip Tutorial");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.tooFast = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.tooFast, "Too Fast");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.renkeiFree = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.renkeiFree, "Renkei Free");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.noQuestDiscoveringPop = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noQuestDiscoveringPop, "発見pop不要");
			RuntimeDebugModeGuiMixin.space(10);
			DamageCalc.DebugUseParams = RuntimeDebugModeGuiMixin.boolButtons(DamageCalc.DebugUseParams, "HP/ATK debug(セーブナシ)");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.killPoppetIfBattleOpen = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.killPoppetIfBattleOpen, "バトル即魔ペット殺");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.noSkillCoolDown = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noSkillCoolDown, "武器/転身スキル使い放題");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.soundMute = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.soundMute, "Always Mute");
			RuntimeDebugModeGuiMixin.space(10);
			NpcTalkControl.ShowPadTalkArea = RuntimeDebugModeGuiMixin.boolButtons(NpcTalkControl.ShowPadTalkArea, "パッド使用時の会話発動エリア表示");
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.boolButtons(false, "Npc Talk Reset"))
			{
				NpcTalkControl.TalkReset();
			}
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.itsFriend = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.itsFriend, "みんなトモダチ");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.notDeadPoppet = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDeadPoppet, "魔ペット無敵");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.notDeadMonster = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDeadMonster, "モンスター無敵");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.showMemroyWarning = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.showMemroyWarning, "メモリ不足通知（実機のみ）");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.unloadUnusedAssetsMemroyWarning = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.unloadUnusedAssetsMemroyWarning, "メモリ不足未使用アセット開放（実機のみ）");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.noBattle = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noBattle, "バトル即終了");
			RuntimeDebugModeGuiMixin.space(10);
			UICamera.useMouse = RuntimeDebugModeGuiMixin.boolButtons(UICamera.useMouse, "Enable Mouse");
			RuntimeDebugModeGuiMixin.space(10);
			UICamera.useTouch = RuntimeDebugModeGuiMixin.boolButtons(UICamera.useTouch, "Enable Touch");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.shortenBattleResetTime = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.shortenBattleResetTime, "バトルリセット時間1/10");
			GameParameter.alwaysCritical = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysCritical, "常時クリティカル");
			GameParameter.alwaysGuard = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysGuard, "常時ガード");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.alwaysAbnormalStateAttack = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysAbnormalStateAttack, "常時状態異常攻撃");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.alwaysResistAbnormalStateAttack = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysResistAbnormalStateAttack, "常時状態異常レジスト");
			RuntimeDebugModeGuiMixin.space(10);
			if (GameParameter.alwaysAbnormalStateAttack)
			{
				RuntimeDebugModeGuiMixin.slabel("常時状態異常時のディフォルト異常");
				Array values = Enum.GetValues(typeof(EnumAbnormalStates));
				string[] texts = ArrayMap.AllEnumNames(typeof(EnumAbnormalStates));
				EnumAbnormalStates defaultAbnormalStateType = GameParameter.defaultAbnormalStateType;
				defaultAbnormalStateType = (EnumAbnormalStates)RuntimeDebugModeGuiMixin.grid((int)defaultAbnormalStateType, texts, 5);
				GameParameter.defaultAbnormalStateType = defaultAbnormalStateType;
			}
			if (DamageCalc.DebugUseParams)
			{
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.slabel("ATK:" + DamageCalc.DebugTotalWeaponAttack);
					RuntimeDebugModeGuiMixin.slabel("HP:" + DamageCalc.DebugTotalPlayerHP);
				});
			}
			GameParameter.forceAutoRun = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.forceAutoRun, "master無視オートランon");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.showItemMasterId = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.showItemMasterId, "アイコンのID表示on");
			RuntimeDebugModeGuiMixin.space(10);
			GameParameter.alwaysOpenResultShortcut = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysOpenResultShortcut, "全リザルトショートカットon");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.KabeYoke, "kabe yoke");
				RuntimeDebugModeGuiMixin.toggle(ref PlayerMoveControl.DispDebugInfo, "debug balls");
			});
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.space(20);
			if (PlayerControl.CurrentPlayer == null)
			{
				RuntimeDebugModeGuiMixin.label("プレーヤーキャラがいません");
			}
			else
			{
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.label("天使武器:");
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(tenshiWeapon).ToString()))
					{
						selectWeapon(isTenshi: true);
					}
				});
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.label("悪魔武器:");
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(akumaWeapon).ToString()))
					{
						selectWeapon(isTenshi: false);
					}
				});
			}
		});
		actionClassmainMode._0024act_0024t_0024540 = _0024adaptor_0024__DebugSubSwiches_0024callable282_002437_5___0024__ActionBase__0024act_0024t_0024538_0024callable31_002437_5___002483.Adapt(delegate
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
		if (_0024act_0024t_0024545.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024545["$default$"];
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

	public ActionClassselectWeapon selectWeapon(bool isTenshi)
	{
		ActionClassselectWeapon actionClassselectWeapon = createselectWeapon(isTenshi);
		changeAction(actionClassselectWeapon);
		return actionClassselectWeapon;
	}

	public ActionClassselectWeapon createDataselectWeapon()
	{
		ActionClassselectWeapon actionClassselectWeapon = new ActionClassselectWeapon();
		actionClassselectWeapon._0024act_0024t_0024536 = ActionEnum.selectWeapon;
		actionClassselectWeapon._0024act_0024t_0024537 = "$default$";
		actionClassselectWeapon._0024act_0024t_0024542 = _0024adaptor_0024__DebugSubSwiches_0024callable283_0024165_5___0024__ActionBase__0024act_0024t_0024538_0024callable31_002437_5___002484.Adapt(delegate(ActionClassselectWeapon _0024act_0024t_0024551)
		{
			string[] texts = ArrayMap.AllEnumNames(typeof(EnumStyles));
			RuntimeDebugModeGuiMixin.label("ソートタイプ: 現在値" + currentEquipSortType);
			int num = RuntimeDebugModeGuiMixin.grid(currentEquipSortType, texts, 2);
			if (currentEquipSortType != num)
			{
				currentEquipSortType = num;
			}
			int i = 0;
			MWeapons[] all = MWeapons.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if ((currentEquipSortType == 0 || currentEquipSortType == all[i].StyleId.Id) && RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(all[i]).ToString()))
				{
					if (_0024act_0024t_0024551.isTenshi)
					{
						tenshiWeapon = new RespWeapon(all[i].Id);
					}
					else
					{
						akumaWeapon = new RespWeapon(all[i].Id);
					}
					if (tenshiWeapon != null || akumaWeapon != null)
					{
						WeaponEquipments weaponEquipments = WeaponEquipments.Default();
						if (tenshiWeapon == null)
						{
							tenshiWeapon = akumaWeapon;
						}
						if (akumaWeapon == null)
						{
							akumaWeapon = tenshiWeapon;
						}
						weaponEquipments.MainTenshiWeapon = tenshiWeapon;
						weaponEquipments.MainAkumaWeapon = akumaWeapon;
						PlayerControl.CurrentPlayer.equipWeapons(weaponEquipments);
					}
					mainMode();
				}
			}
		});
		actionClassselectWeapon._0024act_0024t_0024540 = _0024adaptor_0024__DebugSubSwiches_0024callable283_0024165_5___0024__ActionBase__0024act_0024t_0024538_0024callable31_002437_5___002484.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				mainMode();
			}
		});
		return actionClassselectWeapon;
	}

	public ActionClassselectWeapon createselectWeapon(bool isTenshi)
	{
		ActionClassselectWeapon actionClassselectWeapon = createDataselectWeapon();
		actionClassselectWeapon.isTenshi = isTenshi;
		return actionClassselectWeapon;
	}

	internal void _0024createDatamainMode_0024closure_00243022(ActionClassmainMode _0024act_0024t_0024535)
	{
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("enable FPS") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
			{
				ExtensionsModule.SetComponent<AppStatusInfo>(RuntimeDebugModeGuiMixin.debugModeObject);
			}
			if (RuntimeDebugModeGuiMixin.button("FPS 2") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
			{
				ExtensionsModule.SetComponent<FPSDisp>(RuntimeDebugModeGuiMixin.debugModeObject);
			}
		});
		RuntimeDebugModeGuiMixin.space(20);
		GameParameter.questFreeRun = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.questFreeRun, "Quest Free Run");
		RuntimeDebugModeGuiMixin.space(10);
		UserConfigData config = UserData.Current.Config;
		if (config != null)
		{
			config.AutoCombinationOn = RuntimeDebugModeGuiMixin.boolButtons(config.AutoCombinationOn, "Auto Combination");
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel("auto combination 無理");
		}
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.lockonShader = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.lockonShader, "LockOn Shader");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.notDead = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDead, "Not Dead");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.oneHitKill = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.oneHitKill, "OneHit Kill");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.jisatu = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.jisatu, "Jisatu");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.tutorialSkip = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.tutorialSkip, "Skip Tutorial");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.tooFast = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.tooFast, "Too Fast");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.renkeiFree = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.renkeiFree, "Renkei Free");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.noQuestDiscoveringPop = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noQuestDiscoveringPop, "発見pop不要");
		RuntimeDebugModeGuiMixin.space(10);
		DamageCalc.DebugUseParams = RuntimeDebugModeGuiMixin.boolButtons(DamageCalc.DebugUseParams, "HP/ATK debug(セーブナシ)");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.killPoppetIfBattleOpen = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.killPoppetIfBattleOpen, "バトル即魔ペット殺");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.noSkillCoolDown = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noSkillCoolDown, "武器/転身スキル使い放題");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.soundMute = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.soundMute, "Always Mute");
		RuntimeDebugModeGuiMixin.space(10);
		NpcTalkControl.ShowPadTalkArea = RuntimeDebugModeGuiMixin.boolButtons(NpcTalkControl.ShowPadTalkArea, "パッド使用時の会話発動エリア表示");
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.boolButtons(false, "Npc Talk Reset"))
		{
			NpcTalkControl.TalkReset();
		}
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.itsFriend = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.itsFriend, "みんなトモダチ");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.notDeadPoppet = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDeadPoppet, "魔ペット無敵");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.notDeadMonster = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.notDeadMonster, "モンスター無敵");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.showMemroyWarning = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.showMemroyWarning, "メモリ不足通知（実機のみ）");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.unloadUnusedAssetsMemroyWarning = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.unloadUnusedAssetsMemroyWarning, "メモリ不足未使用アセット開放（実機のみ）");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.noBattle = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.noBattle, "バトル即終了");
		RuntimeDebugModeGuiMixin.space(10);
		UICamera.useMouse = RuntimeDebugModeGuiMixin.boolButtons(UICamera.useMouse, "Enable Mouse");
		RuntimeDebugModeGuiMixin.space(10);
		UICamera.useTouch = RuntimeDebugModeGuiMixin.boolButtons(UICamera.useTouch, "Enable Touch");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.shortenBattleResetTime = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.shortenBattleResetTime, "バトルリセット時間1/10");
		GameParameter.alwaysCritical = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysCritical, "常時クリティカル");
		GameParameter.alwaysGuard = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysGuard, "常時ガード");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.alwaysAbnormalStateAttack = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysAbnormalStateAttack, "常時状態異常攻撃");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.alwaysResistAbnormalStateAttack = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysResistAbnormalStateAttack, "常時状態異常レジスト");
		RuntimeDebugModeGuiMixin.space(10);
		if (GameParameter.alwaysAbnormalStateAttack)
		{
			RuntimeDebugModeGuiMixin.slabel("常時状態異常時のディフォルト異常");
			Array values = Enum.GetValues(typeof(EnumAbnormalStates));
			string[] texts = ArrayMap.AllEnumNames(typeof(EnumAbnormalStates));
			EnumAbnormalStates defaultAbnormalStateType = GameParameter.defaultAbnormalStateType;
			defaultAbnormalStateType = (EnumAbnormalStates)RuntimeDebugModeGuiMixin.grid((int)defaultAbnormalStateType, texts, 5);
			GameParameter.defaultAbnormalStateType = defaultAbnormalStateType;
		}
		if (DamageCalc.DebugUseParams)
		{
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RuntimeDebugModeGuiMixin.slabel("ATK:" + DamageCalc.DebugTotalWeaponAttack);
				RuntimeDebugModeGuiMixin.slabel("HP:" + DamageCalc.DebugTotalPlayerHP);
			});
		}
		GameParameter.forceAutoRun = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.forceAutoRun, "master無視オートランon");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.showItemMasterId = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.showItemMasterId, "アイコンのID表示on");
		RuntimeDebugModeGuiMixin.space(10);
		GameParameter.alwaysOpenResultShortcut = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.alwaysOpenResultShortcut, "全リザルトショートカットon");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.KabeYoke, "kabe yoke");
			RuntimeDebugModeGuiMixin.toggle(ref PlayerMoveControl.DispDebugInfo, "debug balls");
		});
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.space(20);
		if (PlayerControl.CurrentPlayer == null)
		{
			RuntimeDebugModeGuiMixin.label("プレーヤーキャラがいません");
			return;
		}
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.label("天使武器:");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(tenshiWeapon).ToString()))
			{
				selectWeapon(isTenshi: true);
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.label("悪魔武器:");
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(akumaWeapon).ToString()))
			{
				selectWeapon(isTenshi: false);
			}
		});
	}

	internal void _0024_0024createDatamainMode_0024closure_00243022_0024closure_00243023()
	{
		if (RuntimeDebugModeGuiMixin.button("enable FPS") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
		{
			ExtensionsModule.SetComponent<AppStatusInfo>(RuntimeDebugModeGuiMixin.debugModeObject);
		}
		if (RuntimeDebugModeGuiMixin.button("FPS 2") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
		{
			ExtensionsModule.SetComponent<FPSDisp>(RuntimeDebugModeGuiMixin.debugModeObject);
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243022_0024closure_00243024()
	{
		RuntimeDebugModeGuiMixin.slabel("ATK:" + DamageCalc.DebugTotalWeaponAttack);
		RuntimeDebugModeGuiMixin.slabel("HP:" + DamageCalc.DebugTotalPlayerHP);
	}

	internal void _0024_0024createDatamainMode_0024closure_00243022_0024closure_00243025()
	{
		RuntimeDebugModeGuiMixin.toggle(ref PlayerControl.KabeYoke, "kabe yoke");
		RuntimeDebugModeGuiMixin.toggle(ref PlayerMoveControl.DispDebugInfo, "debug balls");
	}

	internal void _0024_0024createDatamainMode_0024closure_00243022_0024closure_00243031()
	{
		RuntimeDebugModeGuiMixin.label("天使武器:");
		if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(tenshiWeapon).ToString()))
		{
			selectWeapon(isTenshi: true);
		}
	}

	internal void _0024_0024createDatamainMode_0024closure_00243022_0024closure_00243032()
	{
		RuntimeDebugModeGuiMixin.label("悪魔武器:");
		if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(akumaWeapon).ToString()))
		{
			selectWeapon(isTenshi: false);
		}
	}

	internal void _0024createDatamainMode_0024closure_00243033(ActionClassmainMode _0024act_0024t_0024535)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDataselectWeapon_0024closure_00243034(ActionClassselectWeapon _0024act_0024t_0024551)
	{
		string[] texts = ArrayMap.AllEnumNames(typeof(EnumStyles));
		RuntimeDebugModeGuiMixin.label("ソートタイプ: 現在値" + currentEquipSortType);
		int num = RuntimeDebugModeGuiMixin.grid(currentEquipSortType, texts, 2);
		if (currentEquipSortType != num)
		{
			currentEquipSortType = num;
		}
		int i = 0;
		MWeapons[] all = MWeapons.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if ((currentEquipSortType != 0 && currentEquipSortType != all[i].StyleId.Id) || !RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(all[i]).ToString()))
			{
				continue;
			}
			if (_0024act_0024t_0024551.isTenshi)
			{
				tenshiWeapon = new RespWeapon(all[i].Id);
			}
			else
			{
				akumaWeapon = new RespWeapon(all[i].Id);
			}
			if (tenshiWeapon != null || akumaWeapon != null)
			{
				WeaponEquipments weaponEquipments = WeaponEquipments.Default();
				if (tenshiWeapon == null)
				{
					tenshiWeapon = akumaWeapon;
				}
				if (akumaWeapon == null)
				{
					akumaWeapon = tenshiWeapon;
				}
				weaponEquipments.MainTenshiWeapon = tenshiWeapon;
				weaponEquipments.MainAkumaWeapon = akumaWeapon;
				PlayerControl.CurrentPlayer.equipWeapons(weaponEquipments);
			}
			mainMode();
		}
	}

	internal void _0024createDataselectWeapon_0024closure_00243035(ActionClassselectWeapon _0024act_0024t_0024551)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			mainMode();
		}
	}
}
