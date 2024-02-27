using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class DebugSubSound : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public enum ListMode
	{
		BGM,
		SE
	}

	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024517;

		public string _0024act_0024t_0024518;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024519;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024520;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024521;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024522;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024523;

		public __ActionBase__0024act_0024t_0024519_0024callable29_002458_5__ _0024act_0024t_0024524;

		public __ActionBase__0024act_0024t_0024525_0024callable30_002458_5__ _0024act_0024t_0024525;

		public IEnumerator _0024act_0024t_0024529;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024517.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassMainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassCheckLoadSeMode : ActionBase
	{
	}

	[Serializable]
	public enum ActionEnum
	{
		CheckLoadSeMode,
		MainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024filterSeList_002415343 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			protected IEnumerator<string> _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator()
			{
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<string>)SQEX_SoundPlayerData.seList).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					string current = _0024_0024enumerator.Current;
					_0024_0024current = current;
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator();
		}
	}

	protected int select;

	protected Vector2 scroll;

	protected int loop;

	protected bool pauseSe;

	protected bool pauseBgm;

	protected int loopBgm;

	protected float volBgm;

	protected float volSe;

	protected float volMaster;

	protected float fadeStartMSec;

	protected float fadeEndMSec;

	protected SQEX_SoundPlayer sndMan;

	protected GameSoundManager gameSndMan;

	[NonSerialized]
	protected static int currentBgm = -1;

	[NonSerialized]
	protected static int currentSe = -1;

	[NonSerialized]
	protected static List seList;

	[NonSerialized]
	protected static readonly string[][] se_filter = new string[8][]
	{
		new string[2]
		{
			"全",
			string.Empty
		},
		new string[2] { "図", "_map_" },
		new string[2] { "E", "_event_" },
		new string[2] { "戦", "_battle_" },
		new string[2] { "シ", "_system_" },
		new string[2] { "自", "_skill_" },
		new string[2] { "敵", "_boss_|_mon_" },
		new string[2] { "声", "voice_" }
	};

	[NonSerialized]
	private static ListMode mode = ListMode.BGM;

	private Dictionary<string, ActionBase> _0024act_0024t_0024526;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024528;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024527;

	public bool actionDebugFlag;

	public bool IsMainMode => currActionID("$default$") == ActionEnum.MainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassMainMode MainModeData => currAction("$default$") as ActionClassMainMode;

	public bool IsCheckLoadSeMode => currActionID("$default$") == ActionEnum.CheckLoadSeMode;

	public ActionClassCheckLoadSeMode CheckLoadSeModeData => currAction("$default$") as ActionClassCheckLoadSeMode;

	public DebugSubSound()
	{
		scroll = Vector2.zero;
		loop = -1;
		loopBgm = -1;
		volBgm = 1f;
		volSe = 1f;
		volMaster = 1f;
		_0024act_0024t_0024526 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024528 = new Dictionary<string, ActionEnum>();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024526.ContainsKey(grp)) ? null : _0024act_0024t_0024526[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024528.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024528[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024526.ContainsKey(grp)) ? 0f : _0024act_0024t_0024526[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024526.ContainsKey(grp)) ? 0f : _0024act_0024t_0024526[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024526.ContainsKey(grp)) ? 0f : _0024act_0024t_0024526[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024528.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024518) && _0024act_0024t_0024526.ContainsKey(act._0024act_0024t_0024518) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024526[act._0024act_0024t_0024518]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.CheckLoadSeMode <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024518))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$518)");
			}
			_0024act_0024t_0024526[act._0024act_0024t_0024518] = act;
			_0024act_0024t_0024528[act._0024act_0024t_0024518] = act._0024act_0024t_0024517;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024527) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024518);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024518)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024518)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024520 != null)
		{
			actionBase._0024act_0024t_0024520(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024519 != null)
			{
				act._0024act_0024t_0024519(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024525 != null)
			{
				act._0024act_0024t_0024529 = act._0024act_0024t_0024525(act);
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
		foreach (ActionBase value in _0024act_0024t_0024526.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024527 = 0;
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
			if (actionBase._0024act_0024t_0024521 != null)
			{
				actionBase._0024act_0024t_0024521(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024529 != null && !actionBase._0024act_0024t_0024529.MoveNext())
			{
				actionBase._0024act_0024t_0024529 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024526.Values)
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
		_0024act_0024t_0024527 = 0;
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
			if (actionBase._0024act_0024t_0024522 != null)
			{
				actionBase._0024act_0024t_0024522(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024527 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024526.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024526[array2[i]];
				if (actionBase._0024act_0024t_0024523 != null)
				{
					actionBase._0024act_0024t_0024523(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024526.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024518 + " - " + value._0024act_0024t_0024517 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024527 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024526.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024526[array2[i]];
			if (actionBase._0024act_0024t_0024524 != null)
			{
				actionBase._0024act_0024t_0024524(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubSound" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.MainMode => createDataMainMode(), 
			ActionEnum.CheckLoadSeMode => createDataCheckLoadSeMode(), 
			_ => null, 
		};
	}

	public ActionClassMainMode MainMode()
	{
		ActionClassMainMode actionClassMainMode = createMainMode();
		changeAction(actionClassMainMode);
		return actionClassMainMode;
	}

	public ActionClassMainMode createDataMainMode()
	{
		ActionClassMainMode actionClassMainMode = new ActionClassMainMode();
		actionClassMainMode._0024act_0024t_0024517 = ActionEnum.MainMode;
		actionClassMainMode._0024act_0024t_0024518 = "$default$";
		actionClassMainMode._0024act_0024t_0024523 = _0024adaptor_0024__DebugSubSound_0024callable280_002458_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002481.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.button("Check Loaded SE"))
			{
				CheckLoadSeMode();
			}
			title = "Sound";
			GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
			if ((bool)sndMan)
			{
				if (RuntimeDebugModeGuiMixin.button("Load All SE"))
				{
					int num = 0;
					int num2 = SQEX_SoundPlayerData.seTypes.Count();
					if (num2 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num < num2)
					{
						int seType = num;
						num++;
						gameSndMan.LoadSeType(seType);
					}
				}
				if (RuntimeDebugModeGuiMixin.button("UnLoad All SE"))
				{
					int num3 = 0;
					int num4 = SQEX_SoundPlayerData.seTypes.Count();
					if (num4 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num3 < num4)
					{
						int seType2 = num3;
						num3++;
						sndMan.UnloadSeType(seType2);
					}
				}
				checked
				{
					if (RuntimeDebugModeGuiMixin.button("Stop SE"))
					{
						sndMan.StopAllSe((int)fadeEndMSec);
					}
					if (RuntimeDebugModeGuiMixin.button("Stop BGM"))
					{
						sndMan.StopBgm((int)fadeEndMSec);
					}
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Pause SE = ").Append(pauseSe).ToString()))
					{
						pauseSe = !pauseSe;
						sndMan.PauseAllSe(pauseSe);
					}
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Pause BGM = ").Append(pauseBgm).ToString()))
					{
						pauseBgm = !pauseBgm;
						sndMan.PauseBgm(pauseBgm);
					}
					RuntimeDebugModeGuiMixin.label("BGM Vol:" + volBgm);
					float num5 = GUILayout.HorizontalSlider(volBgm, 0f, 1f, GUILayout.MaxWidth(200f));
					if (num5 != volBgm)
					{
						SQEX_SoundPlayer.BgmVolume = num5;
						volBgm = num5;
					}
					RuntimeDebugModeGuiMixin.label("SE Vol:" + volSe);
					float num6 = GUILayout.HorizontalSlider(volSe, 0f, 1f, GUILayout.MaxWidth(200f));
					if (num6 != volSe)
					{
						SQEX_SoundPlayer.SeVolume = num6;
						volSe = num6;
					}
					RuntimeDebugModeGuiMixin.label("Mute");
					GameParameter.soundMute = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.soundMute, "Mute(一時)");
					if (sndMan.IsMute != GameParameter.soundMute)
					{
						sndMan.IsMute = GameParameter.soundMute;
						GameParameter.Save();
					}
					volMaster = SQEX_SoundPlayer.MasterVolume;
					bool isMute = sndMan.IsMute;
					RuntimeDebugModeGuiMixin.label("Master Vol:" + volMaster + ((!isMute) ? string.Empty : "(mute)"));
					float num7 = GUILayout.HorizontalSlider(volMaster, 0f, 1f, GUILayout.MaxWidth(200f));
					if (!isMute && num7 != volMaster)
					{
						volMaster = num7;
					}
					if (SQEX_SoundPlayer.MasterVolume != volMaster)
					{
						SQEX_SoundPlayer.MasterVolume = volMaster;
					}
					RuntimeDebugModeGuiMixin.label("Fade Start Sec:" + fadeStartMSec * 0.001f);
					fadeStartMSec = GUILayout.HorizontalSlider(fadeStartMSec, 0f, 10000f, GUILayout.MaxWidth(200f));
					RuntimeDebugModeGuiMixin.label("Fade End Sec:" + fadeEndMSec * 0.001f);
					fadeEndMSec = GUILayout.HorizontalSlider(fadeEndMSec, 0f, 10000f, GUILayout.MaxWidth(200f));
					RuntimeDebugModeGuiMixin.label("Loop count:" + loopBgm);
					loopBgm = (int)GUILayout.HorizontalSlider(loopBgm, -1f, 100f, GUILayout.MaxWidth(200f));
					RuntimeDebugModeGuiMixin.space(30);
					RuntimeDebugModeGuiMixin.vertical((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
					{
						if (RuntimeDebugModeGuiMixin.button("BGM:"))
						{
							mode = ListMode.BGM;
						}
						if (RuntimeDebugModeGuiMixin.button("SE:"))
						{
							mode = ListMode.SE;
						}
					});
					if (mode == ListMode.BGM)
					{
						int num8 = currentBgm;
						currentBgm = RuntimeDebugModeGuiMixin.grid(currentBgm, SQEX_SoundPlayerData.bgmList, 1);
						if (num8 != currentBgm && currentBgm >= 0)
						{
							sndMan.StopBgm((int)fadeEndMSec);
							string[] bgmList = SQEX_SoundPlayerData.bgmList;
							GameSoundManager.PlayBgmDirect(bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, currentBgm)], 1f, 1f, (int)fadeStartMSec, loopBgm);
							currentBgm = -1;
							pauseBgm = false;
						}
					}
					if (mode == ListMode.SE)
					{
						RuntimeDebugModeGuiMixin.listWithFilter(se_filter, new __Req_FailHandler_0024callable6_0024440_32__(filterSeList));
						int num9 = currentSe;
						currentSe = RuntimeDebugModeGuiMixin.grid(currentSe, seList, 2);
						if (num9 != currentSe)
						{
							sndMan.PlaySe(new StringBuilder().Append(seList[currentSe]).ToString(), (int)fadeStartMSec, currentSe);
							currentSe = -1;
							pauseSe = false;
						}
					}
				}
			}
		});
		actionClassMainMode._0024act_0024t_0024521 = _0024adaptor_0024__DebugSubSound_0024callable280_002458_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002481.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				KillMe();
			}
		});
		return actionClassMainMode;
	}

	public ActionClassMainMode createMainMode()
	{
		return createDataMainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024526.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024526["$default$"];
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

	public ActionClassCheckLoadSeMode CheckLoadSeMode()
	{
		ActionClassCheckLoadSeMode actionClassCheckLoadSeMode = createCheckLoadSeMode();
		changeAction(actionClassCheckLoadSeMode);
		return actionClassCheckLoadSeMode;
	}

	public ActionClassCheckLoadSeMode createDataCheckLoadSeMode()
	{
		ActionClassCheckLoadSeMode actionClassCheckLoadSeMode = new ActionClassCheckLoadSeMode();
		actionClassCheckLoadSeMode._0024act_0024t_0024517 = ActionEnum.CheckLoadSeMode;
		actionClassCheckLoadSeMode._0024act_0024t_0024518 = "$default$";
		actionClassCheckLoadSeMode._0024act_0024t_0024523 = _0024adaptor_0024__DebugSubSound_0024callable281_0024177_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002482.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.slabel("<Error SE>");
			foreach (int key in sndMan.seSeError.Keys)
			{
				int num = sndMan.seSeError[key];
				StringBuilder stringBuilder = new StringBuilder("    (").Append((object)key).Append(")");
				string[] array = SQEX_SoundPlayerData.seList;
				RuntimeDebugModeGuiMixin.slabel(stringBuilder.Append(array[RuntimeServices.NormalizeArrayIndex(array, key)]).Append(" : se error counts = ").Append((object)num)
					.ToString());
			}
			RuntimeDebugModeGuiMixin.slabel("<Loaded SE>");
			foreach (int key2 in sndMan.seBankList.Keys)
			{
				int num2 = 0;
				SQEX_SoundPlayer.SoundBank soundBank = sndMan.seBankList[key2];
				if (soundBank != null)
				{
					num2 = soundBank.referenceCount;
				}
				StringBuilder stringBuilder2 = new StringBuilder("    (").Append((object)key2).Append(")");
				string[] array2 = SQEX_SoundPlayerData.seList;
				RuntimeDebugModeGuiMixin.slabel(stringBuilder2.Append(array2[RuntimeServices.NormalizeArrayIndex(array2, key2)]).Append(" : load references = ").Append((object)num2)
					.ToString());
			}
		});
		actionClassCheckLoadSeMode._0024act_0024t_0024521 = _0024adaptor_0024__DebugSubSound_0024callable281_0024177_5___0024__ActionBase__0024act_0024t_0024519_0024callable29_002458_5___002482.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
			if ((bool)gameSndMan && (bool)sndMan)
			{
			}
		});
		return actionClassCheckLoadSeMode;
	}

	public ActionClassCheckLoadSeMode createCheckLoadSeMode()
	{
		return createDataCheckLoadSeMode();
	}

	public void ToggleDownLoadBgm()
	{
		UserData.Current.userMiscInfo.bgmLoad = !UserData.Current.userMiscInfo.bgmLoad;
	}

	public void filterSeList(string filter)
	{
		seList = RuntimeDebugModeGuiMixin.listFilter(new List(new _0024filterSeList_002415343()), filter);
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
		sndMan = SQEX_SoundPlayer.Instance;
		gameSndMan = GameSoundManager.Instance;
		seList = new List();
		volMaster = SQEX_SoundPlayer.MasterVolume;
		MainMode();
	}

	public override void Exit()
	{
		GameParameter.Save();
	}

	internal void _0024createDataMainMode_0024closure_00243462(ActionClassMainMode _0024act_0024t_0024516)
	{
		if (RuntimeDebugModeGuiMixin.button("Check Loaded SE"))
		{
			CheckLoadSeMode();
		}
		title = "Sound";
		GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
		if (!sndMan)
		{
			return;
		}
		if (RuntimeDebugModeGuiMixin.button("Load All SE"))
		{
			int num = 0;
			int num2 = SQEX_SoundPlayerData.seTypes.Count();
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int seType = num;
				num++;
				gameSndMan.LoadSeType(seType);
			}
		}
		if (RuntimeDebugModeGuiMixin.button("UnLoad All SE"))
		{
			int num3 = 0;
			int num4 = SQEX_SoundPlayerData.seTypes.Count();
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int seType2 = num3;
				num3++;
				sndMan.UnloadSeType(seType2);
			}
		}
		checked
		{
			if (RuntimeDebugModeGuiMixin.button("Stop SE"))
			{
				sndMan.StopAllSe((int)fadeEndMSec);
			}
			if (RuntimeDebugModeGuiMixin.button("Stop BGM"))
			{
				sndMan.StopBgm((int)fadeEndMSec);
			}
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Pause SE = ").Append(pauseSe).ToString()))
			{
				pauseSe = !pauseSe;
				sndMan.PauseAllSe(pauseSe);
			}
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Pause BGM = ").Append(pauseBgm).ToString()))
			{
				pauseBgm = !pauseBgm;
				sndMan.PauseBgm(pauseBgm);
			}
			RuntimeDebugModeGuiMixin.label("BGM Vol:" + volBgm);
			float num5 = GUILayout.HorizontalSlider(volBgm, 0f, 1f, GUILayout.MaxWidth(200f));
			if (num5 != volBgm)
			{
				SQEX_SoundPlayer.BgmVolume = num5;
				volBgm = num5;
			}
			RuntimeDebugModeGuiMixin.label("SE Vol:" + volSe);
			float num6 = GUILayout.HorizontalSlider(volSe, 0f, 1f, GUILayout.MaxWidth(200f));
			if (num6 != volSe)
			{
				SQEX_SoundPlayer.SeVolume = num6;
				volSe = num6;
			}
			RuntimeDebugModeGuiMixin.label("Mute");
			GameParameter.soundMute = RuntimeDebugModeGuiMixin.boolButtons(GameParameter.soundMute, "Mute(一時)");
			if (sndMan.IsMute != GameParameter.soundMute)
			{
				sndMan.IsMute = GameParameter.soundMute;
				GameParameter.Save();
			}
			volMaster = SQEX_SoundPlayer.MasterVolume;
			bool isMute = sndMan.IsMute;
			RuntimeDebugModeGuiMixin.label("Master Vol:" + volMaster + ((!isMute) ? string.Empty : "(mute)"));
			float num7 = GUILayout.HorizontalSlider(volMaster, 0f, 1f, GUILayout.MaxWidth(200f));
			if (!isMute && num7 != volMaster)
			{
				volMaster = num7;
			}
			if (SQEX_SoundPlayer.MasterVolume != volMaster)
			{
				SQEX_SoundPlayer.MasterVolume = volMaster;
			}
			RuntimeDebugModeGuiMixin.label("Fade Start Sec:" + fadeStartMSec * 0.001f);
			fadeStartMSec = GUILayout.HorizontalSlider(fadeStartMSec, 0f, 10000f, GUILayout.MaxWidth(200f));
			RuntimeDebugModeGuiMixin.label("Fade End Sec:" + fadeEndMSec * 0.001f);
			fadeEndMSec = GUILayout.HorizontalSlider(fadeEndMSec, 0f, 10000f, GUILayout.MaxWidth(200f));
			RuntimeDebugModeGuiMixin.label("Loop count:" + loopBgm);
			loopBgm = (int)GUILayout.HorizontalSlider(loopBgm, -1f, 100f, GUILayout.MaxWidth(200f));
			RuntimeDebugModeGuiMixin.space(30);
			RuntimeDebugModeGuiMixin.vertical((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("BGM:"))
				{
					mode = ListMode.BGM;
				}
				if (RuntimeDebugModeGuiMixin.button("SE:"))
				{
					mode = ListMode.SE;
				}
			});
			if (mode == ListMode.BGM)
			{
				int num8 = currentBgm;
				currentBgm = RuntimeDebugModeGuiMixin.grid(currentBgm, SQEX_SoundPlayerData.bgmList, 1);
				if (num8 != currentBgm && currentBgm >= 0)
				{
					sndMan.StopBgm((int)fadeEndMSec);
					string[] bgmList = SQEX_SoundPlayerData.bgmList;
					GameSoundManager.PlayBgmDirect(bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, currentBgm)], 1f, 1f, (int)fadeStartMSec, loopBgm);
					currentBgm = -1;
					pauseBgm = false;
				}
			}
			if (mode == ListMode.SE)
			{
				RuntimeDebugModeGuiMixin.listWithFilter(se_filter, new __Req_FailHandler_0024callable6_0024440_32__(filterSeList));
				int num9 = currentSe;
				currentSe = RuntimeDebugModeGuiMixin.grid(currentSe, seList, 2);
				if (num9 != currentSe)
				{
					sndMan.PlaySe(new StringBuilder().Append(seList[currentSe]).ToString(), (int)fadeStartMSec, currentSe);
					currentSe = -1;
					pauseSe = false;
				}
			}
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243462_0024closure_00243463()
	{
		if (RuntimeDebugModeGuiMixin.button("BGM:"))
		{
			mode = ListMode.BGM;
		}
		if (RuntimeDebugModeGuiMixin.button("SE:"))
		{
			mode = ListMode.SE;
		}
	}

	internal void _0024createDataMainMode_0024closure_00243464(ActionClassMainMode _0024act_0024t_0024516)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDataCheckLoadSeMode_0024closure_00243465(ActionClassCheckLoadSeMode _0024act_0024t_0024532)
	{
		RuntimeDebugModeGuiMixin.slabel("<Error SE>");
		foreach (int key in sndMan.seSeError.Keys)
		{
			int num = sndMan.seSeError[key];
			StringBuilder stringBuilder = new StringBuilder("    (").Append((object)key).Append(")");
			string[] array = SQEX_SoundPlayerData.seList;
			RuntimeDebugModeGuiMixin.slabel(stringBuilder.Append(array[RuntimeServices.NormalizeArrayIndex(array, key)]).Append(" : se error counts = ").Append((object)num)
				.ToString());
		}
		RuntimeDebugModeGuiMixin.slabel("<Loaded SE>");
		foreach (int key2 in sndMan.seBankList.Keys)
		{
			int num2 = 0;
			SQEX_SoundPlayer.SoundBank soundBank = sndMan.seBankList[key2];
			if (soundBank != null)
			{
				num2 = soundBank.referenceCount;
			}
			StringBuilder stringBuilder2 = new StringBuilder("    (").Append((object)key2).Append(")");
			string[] array2 = SQEX_SoundPlayerData.seList;
			RuntimeDebugModeGuiMixin.slabel(stringBuilder2.Append(array2[RuntimeServices.NormalizeArrayIndex(array2, key2)]).Append(" : load references = ").Append((object)num2)
				.ToString());
		}
	}

	internal void _0024createDataCheckLoadSeMode_0024closure_00243466(ActionClassCheckLoadSeMode _0024act_0024t_0024532)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
		if ((bool)gameSndMan && (bool)sndMan)
		{
		}
	}
}
