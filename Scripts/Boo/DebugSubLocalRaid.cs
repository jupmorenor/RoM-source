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
public class DebugSubLocalRaid : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024247;

		public string _0024act_0024t_0024248;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024249;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024250;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024251;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024252;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024253;

		public __ActionBase__0024act_0024t_0024249_0024callable11_002440_5__ _0024act_0024t_0024254;

		public __ActionBase__0024act_0024t_0024255_0024callable12_002440_5__ _0024act_0024t_0024255;

		public IEnumerator _0024act_0024t_0024259;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024247.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		mainMode,
		NUM,
		_noaction_
	}

	private int MMonsterId;

	private int StyleId;

	private int ElementId;

	private int ComboLevel;

	private int Level;

	private int LevelCorrection;

	private int Hp;

	[NonSerialized]
	protected static int sel_monster;

	private bool hp_range_kilo;

	private bool hp_range_mili;

	private bool hp_range_giga;

	private bool hp_range_tera;

	private bool hp_range_peta;

	private bool hp_range_yotta;

	private Dictionary<string, ActionBase> _0024act_0024t_0024256;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024258;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024257;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public DebugSubLocalRaid()
	{
		StyleId = 1;
		ElementId = 1;
		ComboLevel = 1;
		Level = 1;
		LevelCorrection = 1;
		Hp = 200000;
		hp_range_kilo = true;
		_0024act_0024t_0024256 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024258 = new Dictionary<string, ActionEnum>();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024256.ContainsKey(grp)) ? null : _0024act_0024t_0024256[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024258.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024258[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024256.ContainsKey(grp)) ? 0f : _0024act_0024t_0024256[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024256.ContainsKey(grp)) ? 0f : _0024act_0024t_0024256[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024256.ContainsKey(grp)) ? 0f : _0024act_0024t_0024256[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024258.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024248) && _0024act_0024t_0024256.ContainsKey(act._0024act_0024t_0024248) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024256[act._0024act_0024t_0024248]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.mainMode <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024248))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$248)");
			}
			_0024act_0024t_0024256[act._0024act_0024t_0024248] = act;
			_0024act_0024t_0024258[act._0024act_0024t_0024248] = act._0024act_0024t_0024247;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024257) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024248);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024248)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024248)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024250 != null)
		{
			actionBase._0024act_0024t_0024250(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024249 != null)
			{
				act._0024act_0024t_0024249(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024255 != null)
			{
				act._0024act_0024t_0024259 = act._0024act_0024t_0024255(act);
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
		foreach (ActionBase value in _0024act_0024t_0024256.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024257 = 0;
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
			if (actionBase._0024act_0024t_0024251 != null)
			{
				actionBase._0024act_0024t_0024251(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024259 != null && !actionBase._0024act_0024t_0024259.MoveNext())
			{
				actionBase._0024act_0024t_0024259 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024256.Values)
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
		_0024act_0024t_0024257 = 0;
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
			if (actionBase._0024act_0024t_0024252 != null)
			{
				actionBase._0024act_0024t_0024252(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024257 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024256.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024256[array2[i]];
				if (actionBase._0024act_0024t_0024253 != null)
				{
					actionBase._0024act_0024t_0024253(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024256.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024248 + " - " + value._0024act_0024t_0024247 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024257 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024256.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024256[array2[i]];
			if (actionBase._0024act_0024t_0024254 != null)
			{
				actionBase._0024act_0024t_0024254(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubLocalRaid" + " enum: " + actID);
		}
		return (actID != 0) ? null : createDatamainMode();
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
		actionClassmainMode._0024act_0024t_0024247 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024248 = "$default$";
		checked
		{
			actionClassmainMode._0024act_0024t_0024253 = _0024adaptor_0024__DebugSubLocalRaid_0024callable201_002440_5___0024__ActionBase__0024act_0024t_0024249_0024callable11_002440_5___002411.Adapt(delegate
			{
				if (RuntimeDebugModeGuiMixin.button("execute !!") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
				{
					execute();
				}
				RuntimeDebugModeGuiMixin.label("モンスター選択：MRaidBattles");
				MRaidBattles[] array = ArrayMap.AllMRaidBattles();
				string[] texts = ArrayMap.AllMRaidBattlesToStr((MRaidBattles m) => new StringBuilder().Append((object)m.MMonsterId).Append(": ").Append(getMonsterName(m.MMonsterId))
					.ToString());
				int num = RuntimeDebugModeGuiMixin.grid(sel_monster, texts, 2);
				if (num != sel_monster)
				{
					sel_monster = num;
					MMonsterId = array[RuntimeServices.NormalizeArrayIndex(array, num)].MMonsterId;
				}
				RuntimeDebugModeGuiMixin.label(new StringBuilder("レベル：").Append((object)Level).ToString());
				float num2 = GUILayout.HorizontalSlider(Level, 1f, 3000f);
				if (num2 != (float)Level)
				{
					Level = (int)num2;
				}
				RuntimeDebugModeGuiMixin.label(new StringBuilder("レベル補正： ").Append((object)LevelCorrection).ToString());
				float num3 = GUILayout.HorizontalSlider(LevelCorrection, 1f, 30f);
				if (num3 != (float)LevelCorrection)
				{
					LevelCorrection = (int)num3;
				}
				texts = ArrayMap.AllEnumNames(typeof(EnumStyles));
				float num6;
				unchecked
				{
					RuntimeDebugModeGuiMixin.label(new StringBuilder("ボーナススタイルID：").Append(((EnumStyles)StyleId).ToString()).ToString());
					int num4 = RuntimeDebugModeGuiMixin.grid(StyleId, texts, 2);
					if (num4 != StyleId)
					{
						StyleId = num4;
					}
					texts = ArrayMap.AllEnumNames(typeof(EnumElements));
					RuntimeDebugModeGuiMixin.label(new StringBuilder("ボーナス属性：").Append(((EnumElements)checked(ElementId + 1)).ToString()).ToString());
					int num5 = RuntimeDebugModeGuiMixin.grid(ElementId, texts, 2);
					if (num5 != ElementId)
					{
						ElementId = num5;
					}
					RuntimeDebugModeGuiMixin.label(new StringBuilder("コンボ： ").Append((object)ComboLevel).ToString());
					num6 = GUILayout.HorizontalSlider(ComboLevel, 1f, 20f);
				}
				if (num6 != (float)ComboLevel)
				{
					ComboLevel = (int)num6;
				}
				RuntimeDebugModeGuiMixin.label("HP範囲");
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_kilo, "kilo");
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_mili, "mili");
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_giga, "giga");
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_tera, "tera");
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_peta, "peta");
					RuntimeDebugModeGuiMixin.toggle(ref hp_range_yotta, "yotta");
				});
				RuntimeDebugModeGuiMixin.label(new StringBuilder("HP：").Append(Hp.ToString("#,0")).ToString());
				float num7 = default(float);
				num7 = (hp_range_yotta ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 6.0), (float)Math.Pow(1000.0, 7.0)) : (hp_range_peta ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 5.0), (float)Math.Pow(1000.0, 6.0)) : (hp_range_tera ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 4.0), (float)Math.Pow(1000.0, 5.0)) : (hp_range_giga ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 3.0), (float)Math.Pow(1000.0, 4.0)) : (hp_range_mili ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 2.0), (float)Math.Pow(1000.0, 3.0)) : ((!hp_range_kilo) ? GUILayout.HorizontalSlider(Hp, 1f, 1000f) : GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 1.0), (float)Math.Pow(1000.0, 2.0))))))));
				if (num7 != (float)Hp)
				{
					Hp = (int)num7;
				}
				RuntimeDebugModeGuiMixin.space(20);
				if (RuntimeDebugModeGuiMixin.button("execute !!") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
				{
					execute();
				}
			});
			actionClassmainMode._0024act_0024t_0024251 = _0024adaptor_0024__DebugSubLocalRaid_0024callable201_002440_5___0024__ActionBase__0024act_0024t_0024249_0024callable11_002440_5___002411.Adapt(delegate
			{
				if (RuntimeDebugModeGuiMixin.InputBack)
				{
					KillMe();
				}
			});
			return actionClassmainMode;
		}
	}

	public ActionClassmainMode createmainMode()
	{
		return createDatamainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024256.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024256["$default$"];
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

	private void execute()
	{
		frameup();
		SceneChanger.ChangeTo(SceneID.Ui_WorldRaid);
		Exit();
	}

	private void frameup()
	{
		int i = 0;
		MCycleSchedules[] all = MCycleSchedules.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				try
				{
					typeof(MCycleSchedules).GetField("$var$BeginDate").SetValue(all[i], DateTime.Parse("2001/01/01"));
					typeof(MCycleSchedules).GetField("$var$EndDate").SetValue(all[i], LocalRaidViewer.RAID_END_DATE_REGARD_AS_LOCAL_RAID);
				}
				catch (Exception)
				{
				}
			}
			RespTCycleRaidBattle respTCycleRaidBattle = new RespTCycleRaidBattle();
			respTCycleRaidBattle.Id = 1;
			respTCycleRaidBattle.TCycleId = getCycleIdByMonsterId(MMonsterId);
			respTCycleRaidBattle.StyleId = StyleId;
			respTCycleRaidBattle.ElementId = ElementId + 1;
			respTCycleRaidBattle.ComboStartDate = MerlinDateTime.Now;
			respTCycleRaidBattle.ComboLevel = ComboLevel;
			respTCycleRaidBattle.MMonsterId = MMonsterId;
			respTCycleRaidBattle.NumberOfTimes = 1;
			respTCycleRaidBattle.DiscoverSocialPlayerId = 1;
			respTCycleRaidBattle.DiscoverDate = MerlinDateTime.Now;
			respTCycleRaidBattle.Level = Level;
			respTCycleRaidBattle.LevelCorrection = LevelCorrection;
			respTCycleRaidBattle.InitialHp = Hp;
			respTCycleRaidBattle.Hp = Hp;
			respTCycleRaidBattle.PhotonServer = string.Empty;
			respTCycleRaidBattle.RoomName = string.Empty;
			respTCycleRaidBattle.IsActive = true;
			respTCycleRaidBattle.IsDiscover = true;
			respTCycleRaidBattle.IsDetectionElement = true;
			respTCycleRaidBattle.IsDetectionStyle = true;
			UserData.Current.setRaidBattle(respTCycleRaidBattle);
		}
	}

	public string getMonsterName(int id)
	{
		int num = 0;
		MMonsters[] all = MMonsters.All;
		int length = all.Length;
		string result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].Id == id)
				{
					result = all[num].Name.ToString();
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = string.Empty;
			break;
		}
		return result;
	}

	public int getCycleIdByMonsterId(int id)
	{
		int num = 0;
		MCycleSchedules[] all = MCycleSchedules.All;
		int length = all.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (all[num].RaidBossMonsterId.Id == id)
				{
					result = all[num].CycleId;
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = 1;
			break;
		}
		return result;
	}

	internal void _0024createDatamainMode_0024closure_00243693(ActionClassmainMode _0024act_0024t_0024246)
	{
		if (RuntimeDebugModeGuiMixin.button("execute !!") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
		{
			execute();
		}
		RuntimeDebugModeGuiMixin.label("モンスター選択：MRaidBattles");
		MRaidBattles[] array = ArrayMap.AllMRaidBattles();
		string[] texts = ArrayMap.AllMRaidBattlesToStr((MRaidBattles m) => new StringBuilder().Append((object)m.MMonsterId).Append(": ").Append(getMonsterName(m.MMonsterId))
			.ToString());
		int num = RuntimeDebugModeGuiMixin.grid(sel_monster, texts, 2);
		if (num != sel_monster)
		{
			sel_monster = num;
			MMonsterId = array[RuntimeServices.NormalizeArrayIndex(array, num)].MMonsterId;
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("レベル：").Append((object)Level).ToString());
		float num2 = GUILayout.HorizontalSlider(Level, 1f, 3000f);
		checked
		{
			if (num2 != (float)Level)
			{
				Level = (int)num2;
			}
			RuntimeDebugModeGuiMixin.label(new StringBuilder("レベル補正： ").Append((object)LevelCorrection).ToString());
			float num3 = GUILayout.HorizontalSlider(LevelCorrection, 1f, 30f);
			if (num3 != (float)LevelCorrection)
			{
				LevelCorrection = (int)num3;
			}
			texts = ArrayMap.AllEnumNames(typeof(EnumStyles));
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("ボーナススタイルID：").Append(((EnumStyles)StyleId).ToString()).ToString());
		int num4 = RuntimeDebugModeGuiMixin.grid(StyleId, texts, 2);
		if (num4 != StyleId)
		{
			StyleId = num4;
		}
		texts = ArrayMap.AllEnumNames(typeof(EnumElements));
		RuntimeDebugModeGuiMixin.label(new StringBuilder("ボーナス属性：").Append(((EnumElements)checked(ElementId + 1)).ToString()).ToString());
		int num5 = RuntimeDebugModeGuiMixin.grid(ElementId, texts, 2);
		if (num5 != ElementId)
		{
			ElementId = num5;
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("コンボ： ").Append((object)ComboLevel).ToString());
		float num6 = GUILayout.HorizontalSlider(ComboLevel, 1f, 20f);
		checked
		{
			if (num6 != (float)ComboLevel)
			{
				ComboLevel = (int)num6;
			}
			RuntimeDebugModeGuiMixin.label("HP範囲");
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_kilo, "kilo");
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_mili, "mili");
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_giga, "giga");
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_tera, "tera");
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_peta, "peta");
				RuntimeDebugModeGuiMixin.toggle(ref hp_range_yotta, "yotta");
			});
			RuntimeDebugModeGuiMixin.label(new StringBuilder("HP：").Append(Hp.ToString("#,0")).ToString());
			float num7 = default(float);
			num7 = (hp_range_yotta ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 6.0), (float)Math.Pow(1000.0, 7.0)) : (hp_range_peta ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 5.0), (float)Math.Pow(1000.0, 6.0)) : (hp_range_tera ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 4.0), (float)Math.Pow(1000.0, 5.0)) : (hp_range_giga ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 3.0), (float)Math.Pow(1000.0, 4.0)) : (hp_range_mili ? GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 2.0), (float)Math.Pow(1000.0, 3.0)) : ((!hp_range_kilo) ? GUILayout.HorizontalSlider(Hp, 1f, 1000f) : GUILayout.HorizontalSlider(Hp, (float)Math.Pow(1000.0, 1.0), (float)Math.Pow(1000.0, 2.0))))))));
			if (num7 != (float)Hp)
			{
				Hp = (int)num7;
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("execute !!") && (bool)RuntimeDebugModeGuiMixin.debugModeObject)
			{
				execute();
			}
		}
	}

	internal string _0024_0024createDatamainMode_0024closure_00243693_0024closure_00243694(MRaidBattles m)
	{
		return new StringBuilder().Append((object)m.MMonsterId).Append(": ").Append(getMonsterName(m.MMonsterId))
			.ToString();
	}

	internal void _0024_0024createDatamainMode_0024closure_00243693_0024closure_00243695()
	{
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_kilo, "kilo");
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_mili, "mili");
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_giga, "giga");
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_tera, "tera");
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_peta, "peta");
		RuntimeDebugModeGuiMixin.toggle(ref hp_range_yotta, "yotta");
	}

	internal void _0024createDatamainMode_0024closure_00243696(ActionClassmainMode _0024act_0024t_0024246)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}
}
