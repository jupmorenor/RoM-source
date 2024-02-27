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
public class DebugSubSystemInfo : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024422;

		public string _0024act_0024t_0024423;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024424;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024425;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024426;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024427;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024428;

		public __ActionBase__0024act_0024t_0024424_0024callable23_002424_5__ _0024act_0024t_0024429;

		public __ActionBase__0024act_0024t_0024430_0024callable24_002424_5__ _0024act_0024t_0024430;

		public IEnumerator _0024act_0024t_0024434;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024422.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassMainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassD540OpeCodePoolInfo : ActionBase
	{
	}

	[Serializable]
	public class ActionClassServerClockMode : ActionBase
	{
		public int idx;

		public int[] table;

		public string[] names;
	}

	[Serializable]
	public class ActionClassServerClockMode2 : ActionBase
	{
		public int dayIdx;

		public int hourIdx;

		public int[] days;

		public int[] hours;

		public string[] dayNames;

		public string[] hourNames;
	}

	[Serializable]
	public class ActionClassSetClockMode : ActionBase
	{
		public int hour;

		public ICallable back;

		public WWW www;
	}

	[Serializable]
	public class ActionClassDownloadDataMode : ActionBase
	{
		public bool rsrcSaved;

		public string[] abNames;

		public bool[] abLoaded;

		public int[] abVers;
	}

	[Serializable]
	public class ActionClassIconAtlasMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAssetBundleRequestViewMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassAllAtlasViewMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassfontStatusView : ActionBase
	{
	}

	[Serializable]
	public class ActionClassdontDestroyView : ActionBase
	{
	}

	[Serializable]
	public class ActionClassmiscInfoView : ActionBase
	{
	}

	[Serializable]
	public class ActionClassViewMasters : ActionBase
	{
	}

	[Serializable]
	public class ActionClassViewCommunications : ActionBase
	{
	}

	[Serializable]
	public class ActionClasspyxisTest : ActionBase
	{
	}

	[Serializable]
	public class ActionClassprofilerView : ActionBase
	{
		public int mode;

		public int pagetop;

		public Boo.Lang.List<UnityEngine.Object[]> objLists;

		public Boo.Lang.List<int[]> sizLists;

		public int currentIndex;

		public string[] selection;
	}

	[Serializable]
	public enum ActionEnum
	{
		profilerView,
		pyxisTest,
		ViewCommunications,
		ViewMasters,
		miscInfoView,
		dontDestroyView,
		fontStatusView,
		AllAtlasViewMode,
		AssetBundleRequestViewMode,
		IconAtlasMode,
		DownloadDataMode,
		SetClockMode,
		ServerClockMode2,
		ServerClockMode,
		D540OpeCodePoolInfo,
		MainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299
	{
		internal UnityEngine.Object[] _0024curData;

		internal int[] _0024curSize;

		internal int _0024pageLines;

		internal ActionClassprofilerView _0024_0024act_0024t_0024479;
	}

	[Serializable]
	internal class _0024_0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449_0024closure_00243450
	{
		internal _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414688;

		public _0024_0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449_0024closure_00243450(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414688)
		{
			this._0024_0024locals_002414688 = _0024_0024locals_002414688;
		}

		public void Invoke()
		{
			checked
			{
				if (RuntimeDebugModeGuiMixin.button("prev") && _0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop > 0)
				{
					_0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop = Math.Max(0, _0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop - _0024_0024locals_002414688._0024pageLines);
				}
				if (RuntimeDebugModeGuiMixin.button("next") && _0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop < _0024_0024locals_002414688._0024curData.Length - _0024_0024locals_002414688._0024pageLines)
				{
					_0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop = _0024_0024locals_002414688._0024_0024act_0024t_0024479.pagetop + _0024_0024locals_002414688._0024pageLines;
				}
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449
	{
		internal _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414689;

		public _0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414689)
		{
			this._0024_0024locals_002414689 = _0024_0024locals_002414689;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449_0024closure_00243450(_0024_0024locals_002414689).Invoke));
		}
	}

	[Serializable]
	internal class _0024_0024createDataprofilerView_0024closure_00243448_0024closure_00243451
	{
		internal _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414690;

		internal int _0024i_002414691;

		public _0024_0024createDataprofilerView_0024closure_00243448_0024closure_00243451(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024locals_002414690, int _0024i_002414691)
		{
			this._0024_0024locals_002414690 = _0024_0024locals_002414690;
			this._0024i_002414691 = _0024i_002414691;
		}

		public void Invoke()
		{
			UnityEngine.Object[] _0024curData = _0024_0024locals_002414690._0024curData;
			if (_0024curData[RuntimeServices.NormalizeArrayIndex(_0024curData, _0024i_002414691)] != null)
			{
				UnityEngine.Object[] _0024curData2 = _0024_0024locals_002414690._0024curData;
				string lhs = objectName(_0024curData2[RuntimeServices.NormalizeArrayIndex(_0024curData2, _0024i_002414691)]) + " -- ";
				int[] _0024curSize = _0024_0024locals_002414690._0024curSize;
				RuntimeDebugModeGuiMixin.slabel(lhs + _0024curSize[RuntimeServices.NormalizeArrayIndex(_0024curSize, _0024i_002414691)] + " bytes");
				if (RuntimeDebugModeGuiMixin.button("unload"))
				{
					UnityEngine.Object[] _0024curData3 = _0024_0024locals_002414690._0024curData;
					Resources.UnloadAsset(_0024curData3[RuntimeServices.NormalizeArrayIndex(_0024curData3, _0024i_002414691)]);
					UnityEngine.Object[] _0024curData4 = _0024_0024locals_002414690._0024curData;
					_0024curData4[RuntimeServices.NormalizeArrayIndex(_0024curData4, _0024i_002414691)] = null;
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("maybe unloaded...");
			}
		}
	}

	private string guildBatLabel;

	private string rankBatLabel;

	private int currentClientVersion;

	[NonSerialized]
	private static int RaidBossLevelIndex = 5;

	[NonSerialized]
	private static int[] RAID_BOSS_LEVEL_TABLE = new int[6] { 1, 10, 20, 30, 40, 50 };

	private Dictionary<string, ActionBase> _0024act_0024t_0024431;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024433;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024432;

	public bool actionDebugFlag;

	[NonSerialized]
	private static readonly Type[] PROFILER_VIEW_TYPES = new Type[7]
	{
		typeof(Material),
		typeof(Texture),
		typeof(Animation),
		typeof(UIAtlas),
		typeof(PlayerControl),
		typeof(GameObject),
		typeof(Shader)
	};

	public bool IsMainMode => currActionID("$default$") == ActionEnum.MainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassMainMode MainModeData => currAction("$default$") as ActionClassMainMode;

	public bool IsD540OpeCodePoolInfo => currActionID("$default$") == ActionEnum.D540OpeCodePoolInfo;

	public ActionClassD540OpeCodePoolInfo D540OpeCodePoolInfoData => currAction("$default$") as ActionClassD540OpeCodePoolInfo;

	public bool IsServerClockMode => currActionID("$default$") == ActionEnum.ServerClockMode;

	public ActionClassServerClockMode ServerClockModeData => currAction("$default$") as ActionClassServerClockMode;

	public bool IsServerClockMode2 => currActionID("$default$") == ActionEnum.ServerClockMode2;

	public ActionClassServerClockMode2 ServerClockMode2Data => currAction("$default$") as ActionClassServerClockMode2;

	public bool IsSetClockMode => currActionID("$default$") == ActionEnum.SetClockMode;

	public ActionClassSetClockMode SetClockModeData => currAction("$default$") as ActionClassSetClockMode;

	public bool IsDownloadDataMode => currActionID("$default$") == ActionEnum.DownloadDataMode;

	public ActionClassDownloadDataMode DownloadDataModeData => currAction("$default$") as ActionClassDownloadDataMode;

	public bool IsIconAtlasMode => currActionID("$default$") == ActionEnum.IconAtlasMode;

	public ActionClassIconAtlasMode IconAtlasModeData => currAction("$default$") as ActionClassIconAtlasMode;

	public bool IsAssetBundleRequestViewMode => currActionID("$default$") == ActionEnum.AssetBundleRequestViewMode;

	public ActionClassAssetBundleRequestViewMode AssetBundleRequestViewModeData => currAction("$default$") as ActionClassAssetBundleRequestViewMode;

	public bool IsAllAtlasViewMode => currActionID("$default$") == ActionEnum.AllAtlasViewMode;

	public ActionClassAllAtlasViewMode AllAtlasViewModeData => currAction("$default$") as ActionClassAllAtlasViewMode;

	public bool IsfontStatusView => currActionID("$default$") == ActionEnum.fontStatusView;

	public ActionClassfontStatusView fontStatusViewData => currAction("$default$") as ActionClassfontStatusView;

	public bool IsdontDestroyView => currActionID("$default$") == ActionEnum.dontDestroyView;

	public ActionClassdontDestroyView dontDestroyViewData => currAction("$default$") as ActionClassdontDestroyView;

	public bool IsmiscInfoView => currActionID("$default$") == ActionEnum.miscInfoView;

	public ActionClassmiscInfoView miscInfoViewData => currAction("$default$") as ActionClassmiscInfoView;

	public bool IsViewMasters => currActionID("$default$") == ActionEnum.ViewMasters;

	public ActionClassViewMasters ViewMastersData => currAction("$default$") as ActionClassViewMasters;

	public bool IsViewCommunications => currActionID("$default$") == ActionEnum.ViewCommunications;

	public ActionClassViewCommunications ViewCommunicationsData => currAction("$default$") as ActionClassViewCommunications;

	public bool IspyxisTest => currActionID("$default$") == ActionEnum.pyxisTest;

	public ActionClasspyxisTest pyxisTestData => currAction("$default$") as ActionClasspyxisTest;

	public bool IsprofilerView => currActionID("$default$") == ActionEnum.profilerView;

	public ActionClassprofilerView profilerViewData => currAction("$default$") as ActionClassprofilerView;

	public DebugSubSystemInfo()
	{
		guildBatLabel = string.Empty;
		rankBatLabel = string.Empty;
		currentClientVersion = CurrentBuildableVersion.CLIENT_VERSION;
		_0024act_0024t_0024431 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024433 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override void Init()
	{
		MainMode();
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024431.ContainsKey(grp)) ? null : _0024act_0024t_0024431[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024433.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024433[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024431.ContainsKey(grp)) ? 0f : _0024act_0024t_0024431[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024431.ContainsKey(grp)) ? 0f : _0024act_0024t_0024431[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024431.ContainsKey(grp)) ? 0f : _0024act_0024t_0024431[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024433.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024423) && _0024act_0024t_0024431.ContainsKey(act._0024act_0024t_0024423) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024431[act._0024act_0024t_0024423]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.profilerView <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024423))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$423)");
			}
			_0024act_0024t_0024431[act._0024act_0024t_0024423] = act;
			_0024act_0024t_0024433[act._0024act_0024t_0024423] = act._0024act_0024t_0024422;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024432) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024423);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024423)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024423)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024425 != null)
		{
			actionBase._0024act_0024t_0024425(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024424 != null)
			{
				act._0024act_0024t_0024424(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024430 != null)
			{
				act._0024act_0024t_0024434 = act._0024act_0024t_0024430(act);
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
		foreach (ActionBase value in _0024act_0024t_0024431.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024432 = 0;
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
			if (actionBase._0024act_0024t_0024426 != null)
			{
				actionBase._0024act_0024t_0024426(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024434 != null && !actionBase._0024act_0024t_0024434.MoveNext())
			{
				actionBase._0024act_0024t_0024434 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024431.Values)
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
		_0024act_0024t_0024432 = 0;
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
			if (actionBase._0024act_0024t_0024427 != null)
			{
				actionBase._0024act_0024t_0024427(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024432 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024431.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024431[array2[i]];
				if (actionBase._0024act_0024t_0024428 != null)
				{
					actionBase._0024act_0024t_0024428(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024431.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024423 + " - " + value._0024act_0024t_0024422 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024432 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024431.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024431[array2[i]];
			if (actionBase._0024act_0024t_0024429 != null)
			{
				actionBase._0024act_0024t_0024429(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubSystemInfo" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.MainMode => createDataMainMode(), 
			ActionEnum.D540OpeCodePoolInfo => createDataD540OpeCodePoolInfo(), 
			ActionEnum.ServerClockMode => createDataServerClockMode(), 
			ActionEnum.ServerClockMode2 => createDataServerClockMode2(), 
			ActionEnum.SetClockMode => createDataSetClockMode(), 
			ActionEnum.DownloadDataMode => createDataDownloadDataMode(), 
			ActionEnum.IconAtlasMode => createDataIconAtlasMode(), 
			ActionEnum.AssetBundleRequestViewMode => createDataAssetBundleRequestViewMode(), 
			ActionEnum.AllAtlasViewMode => createDataAllAtlasViewMode(), 
			ActionEnum.fontStatusView => createDatafontStatusView(), 
			ActionEnum.dontDestroyView => createDatadontDestroyView(), 
			ActionEnum.miscInfoView => createDatamiscInfoView(), 
			ActionEnum.ViewMasters => createDataViewMasters(), 
			ActionEnum.ViewCommunications => createDataViewCommunications(), 
			ActionEnum.pyxisTest => createDatapyxisTest(), 
			ActionEnum.profilerView => createDataprofilerView(), 
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
		actionClassMainMode._0024act_0024t_0024422 = ActionEnum.MainMode;
		actionClassMainMode._0024act_0024t_0024423 = "$default$";
		actionClassMainMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable249_002424_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002457.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("SERVER");
			int titleWidth = 200;
			RuntimeDebugModeGuiMixin.snamevalue("EXAM-VER", ServerURL.ExamVerSrvUrl("/"), titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("SERV-Platform", ServerURL.PlatformApiUrl("/"), titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("SERV-Entry", ServerURL.EntryApiUrl("/"), titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("SERV-Game", ServerURL.GameApiUrl("/"), titleWidth);
			if (ServerURL.HasAssetSrvURL)
			{
				RuntimeDebugModeGuiMixin.snamevalue("SERV-AssetSrv", ServerURL.AssetSrvUrl("/"), titleWidth);
			}
			else
			{
				RuntimeDebugModeGuiMixin.snamevalue("SERV-AssetSrv", "<none>", titleWidth);
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("SESSION");
			RuntimeDebugModeGuiMixin.slabel("UUID:" + CurrentInfo.UUID);
			RuntimeDebugModeGuiMixin.slabel("Token:" + CurrentInfo.Token);
			RuntimeDebugModeGuiMixin.slabel("CreatedCharacter:" + CurrentInfo.AlreadyCreatedCharacter);
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("PLAYER");
			RuntimeDebugModeGuiMixin.label("ソーシャルID: " + UserData.Current.userStatus.TSocialPlayerId);
			RuntimeDebugModeGuiMixin.slabel("PLAYER-ID:" + UserData.Current.userBasicInfo.Id);
			RuntimeDebugModeGuiMixin.slabel("PLAYER-NAME:" + UserData.Current.userBasicInfo.Name);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label(new StringBuilder("DEVICE:").Append(PerformanceSettingBase.GetAndroidDeviceModel()).ToString());
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.operatingSystem:" + SystemInfo.operatingSystem);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceUniqueIdentifier:" + SystemInfo.deviceUniqueIdentifier);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceModel:" + SystemInfo.deviceModel);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceName:" + SystemInfo.deviceName);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsDeviceName:" + SystemInfo.graphicsDeviceName);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsDeviceVendor:" + SystemInfo.graphicsDeviceVendor);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.processorType:" + SystemInfo.processorType);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsMemorySize:" + SystemInfo.graphicsMemorySize);
			RuntimeDebugModeGuiMixin.slabel("SystemInfo.systemMemorySize:" + SystemInfo.systemMemorySize);
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("CLEAR ALL DATA"))
			{
				ClearData.ClearAllData();
			}
			if (RuntimeDebugModeGuiMixin.button("CLEAR DOWNLOADED DATA"))
			{
				ClearData.ClearDownloadedData();
			}
			RuntimeDebugModeGuiMixin.space(20);
			int currentServerIndex = ServerURL.CurrentServerIndex;
			RuntimeDebugModeGuiMixin.label("接続先変更:" + currentServerIndex);
			RuntimeDebugModeGuiMixin.slabel("変更するとclear all data");
			Boo.Lang.List<string> list = new Boo.Lang.List<string>();
			int i = 0;
			ServerURL.ServerConnectProperty[] servers = ServerURL.Servers;
			for (int length = servers.Length; i < length; i = checked(i + 1))
			{
				list.Add(servers[i].name);
			}
			string[] texts = list.ToArray();
			int num = RuntimeDebugModeGuiMixin.grid(currentServerIndex, texts, 3);
			if (currentServerIndex != num && num != 0 && num != 1 && num != 2)
			{
				ServerURL.CurrentServerIndex = num;
				ClearData.ClearAllData();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("サーバー時計変更"))
				{
					ServerClockMode();
				}
				if (RuntimeDebugModeGuiMixin.button("サーバー時計変更2"))
				{
					ServerClockMode2();
				}
			});
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("現在ゲーム内時刻");
			RuntimeDebugModeGuiMixin.slabel("Now: " + MerlinDateTime.Now);
			RuntimeDebugModeGuiMixin.slabel("UtcNow: " + MerlinDateTime.UtcNow);
			TimeSpan timeOffset = MerlinDateTime.TimeOffset;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("srv補正: + ").Append((object)timeOffset.Days).Append("days ").Append((object)timeOffset.Hours)
				.Append(":")
				.Append((object)timeOffset.Minutes)
				.Append(":")
				.Append((object)timeOffset.Seconds)
				.ToString());
			RuntimeDebugModeGuiMixin.slabel("DateTime.Now: " + DateTime.Now);
			RuntimeDebugModeGuiMixin.slabel("DateTime.UtcNow: " + DateTime.UtcNow);
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("日次再ログイン用に１日前プレイ状態にする(要再起動)"))
			{
				DailyTask.DebugSaveYesterday();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("ダウンロード状況"))
				{
					DownloadDataMode();
				}
				if (RuntimeDebugModeGuiMixin.button("アイコンアトラス状況"))
				{
					IconAtlasMode();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("asset bundle requests"))
				{
					AssetBundleRequestViewMode();
				}
				if (RuntimeDebugModeGuiMixin.button("all atlases"))
				{
					AllAtlasViewMode();
				}
				if (RuntimeDebugModeGuiMixin.button("communication"))
				{
					ViewCommunications();
				}
			});
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("masters"))
				{
					ViewMasters();
				}
			});
			RuntimeDebugModeGuiMixin.space(20);
			versionEdit();
			RuntimeDebugModeGuiMixin.label("Google Cloud Messaging 情報");
			if (RuntimeDebugModeGuiMixin.button("register"))
			{
				string gcmSenderId = "537118308623";
				__Req_FailHandler_0024callable6_0024440_32__ from = delegate
				{
				};
				GoogleCloudMessagingManager.registrationSucceededEvent += _0024adaptor_0024__Req_FailHandler_0024callable6_0024440_32___0024Action_002473.Adapt(from);
				GoogleCloudMessaging.register(gcmSenderId);
			}
			if (RuntimeDebugModeGuiMixin.button("unregister"))
			{
				GoogleCloudMessaging.unRegister();
			}
			if (RuntimeDebugModeGuiMixin.button("check notifications"))
			{
				GoogleCloudMessaging.checkForNotifications();
			}
			if (RuntimeDebugModeGuiMixin.button("cancel notification"))
			{
				GoogleCloudMessaging.cancelAll();
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("clear all dataだけど外部化データ残す"))
			{
				ClearData.ClearAllWithoutDownloadedData();
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("/Homeする"))
			{
				MerlinServer.Request(new ApiHome(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
				{
					StorageHUD.DoUpdateNow();
				}));
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("/Home/Slim する"))
			{
				MerlinServer.Request(new ApiHomeSlim(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
				{
					StorageHUD.DoUpdateNow();
				}));
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("ランキング報酬配布バッチ"))
			{
				MerlinServer.Request(new ApiRankingBat());
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("レイド情報取得 /Build/RaidBattle - 似非push通知用"))
			{
				MerlinServer.Request(new ApiGuildRaidBattle(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
				{
				}));
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("おしらせ"))
			{
				ExitDebugMode();
				GameObject gameObject = null;
				Component component = (MyHomeMain)UnityEngine.Object.FindObjectOfType(typeof(MyHomeMain));
				if (!component)
				{
					component = (TownMain)UnityEngine.Object.FindObjectOfType(typeof(TownMain));
				}
				if ((bool)component)
				{
					gameObject = component.gameObject;
				}
				if ((bool)gameObject)
				{
					DailyTask.Delay = 1f;
					DailyTask.DebugSaveYesterday();
					gameObject.AddComponent<DailyTask>();
				}
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("font使用量(参考値):"))
			{
				fontStatusView();
			}
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("DontDestroys"))
				{
					dontDestroyView();
				}
				if (RuntimeDebugModeGuiMixin.button("miscInfoView"))
				{
					miscInfoView();
				}
			});
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				if (RuntimeDebugModeGuiMixin.button("profiles"))
				{
					profilerView();
				}
			});
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("Pyxis"))
			{
				pyxisTest();
			}
			RuntimeDebugModeGuiMixin.space(20);
			bool examVerMode = RuntimeDebugModeGuiMixin.boolButtons(ApiExamVer.IsExamVer, "ExamVer");
			ApiExamVer.SetExamVerMode(examVerMode);
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("D540OpeCodePool info"))
			{
				D540OpeCodePoolInfo();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.slabel("realtimeSinceStartup: " + Time.realtimeSinceStartup);
			RuntimeDebugModeGuiMixin.slabel("Time.timeScale: " + Time.timeScale);
			RuntimeDebugModeGuiMixin.space(20);
			if (Camera.main != null)
			{
				RuntimeDebugModeGuiMixin.slabel("Camera.main: " + Camera.main.gameObject);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("Camera.main = null");
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("レイド残りプレイ時間(s):" + PhotonClientMain.LastRemainingTime);
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.slabel("URLScheme");
			RuntimeDebugModeGuiMixin.textArea("URI:\n" + URLScheme.GetLastRequestURI());
		});
		actionClassMainMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable249_002424_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002457.Adapt(delegate
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
		if (_0024act_0024t_0024431.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024431["$default$"];
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

	private void versionEdit()
	{
		RuntimeDebugModeGuiMixin.label("バージョン情報");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("curr Client: ").Append(CurrentInfo.ClientVersion).ToString());
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)checked(delegate
		{
			int num = 0;
			if (RuntimeDebugModeGuiMixin.button("down") && currentClientVersion > 0)
			{
				num = -1;
			}
			if (RuntimeDebugModeGuiMixin.button("up"))
			{
				num = 1;
			}
			if (num != 0)
			{
				currentClientVersion += num;
				CurrentBuildableVersion.SetPrefClientVersion(new StringBuilder().Append((object)currentClientVersion).ToString());
			}
		}));
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("curr Data:   ").Append(CurrentInfo.DataVersion).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("curr Master: ").Append(CurrentInfo.MasterVersion).ToString());
	}

	public ActionClassD540OpeCodePoolInfo D540OpeCodePoolInfo()
	{
		ActionClassD540OpeCodePoolInfo actionClassD540OpeCodePoolInfo = createD540OpeCodePoolInfo();
		changeAction(actionClassD540OpeCodePoolInfo);
		return actionClassD540OpeCodePoolInfo;
	}

	public ActionClassD540OpeCodePoolInfo createDataD540OpeCodePoolInfo()
	{
		ActionClassD540OpeCodePoolInfo actionClassD540OpeCodePoolInfo = new ActionClassD540OpeCodePoolInfo();
		actionClassD540OpeCodePoolInfo._0024act_0024t_0024422 = ActionEnum.D540OpeCodePoolInfo;
		actionClassD540OpeCodePoolInfo._0024act_0024t_0024423 = "$default$";
		actionClassD540OpeCodePoolInfo._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable250_0024283_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002458.Adapt(delegate
		{
			D540OpeCodePool instance = D540OpeCodePool.Instance;
			RuntimeDebugModeGuiMixin.label("D540OpeCodePool info");
			RuntimeDebugModeGuiMixin.space(20);
			int num = 0;
			int num2 = 0;
			int num3 = 37;
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num2 < num3)
			{
				int num4 = num2;
				num2++;
				int poolingNum = instance.getPoolingNum((D540OpeCodeId)num4);
				num = checked(num + poolingNum);
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((D540OpeCodeId)num4).Append(": ").ToString() + poolingNum);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.slabel("total allocation count: " + instance.TotalAllocationCount);
			RuntimeDebugModeGuiMixin.slabel("total deallocation count: " + instance.TotalDeallocationCount);
			RuntimeDebugModeGuiMixin.slabel("pooling count: " + num);
			RuntimeDebugModeGuiMixin.slabel("expected allocation count: " + instance.ExpectedCurrentAllocationCount);
		});
		return actionClassD540OpeCodePoolInfo;
	}

	public ActionClassD540OpeCodePoolInfo createD540OpeCodePoolInfo()
	{
		return createDataD540OpeCodePoolInfo();
	}

	public ActionClassServerClockMode ServerClockMode()
	{
		ActionClassServerClockMode actionClassServerClockMode = createServerClockMode();
		changeAction(actionClassServerClockMode);
		return actionClassServerClockMode;
	}

	public ActionClassServerClockMode createDataServerClockMode()
	{
		ActionClassServerClockMode actionClassServerClockMode = new ActionClassServerClockMode();
		actionClassServerClockMode._0024act_0024t_0024422 = ActionEnum.ServerClockMode;
		actionClassServerClockMode._0024act_0024t_0024423 = "$default$";
		actionClassServerClockMode._0024act_0024t_0024424 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable251_0024300_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002459.Adapt(checked(delegate(ActionClassServerClockMode _0024act_0024t_0024440)
		{
			_0024act_0024t_0024440.idx = 0;
			int[] array = ArrayMap.Range(24);
			int[] rhs = ArrayMap.Range(31, (int n) => 24 * (n + 1));
			_0024act_0024t_0024440.table = (int[])RuntimeServices.AddArrays(typeof(int), array, rhs);
			_0024act_0024t_0024440.names = ArrayMap.IntToStr(array, (int n) => new StringBuilder("今+").Append((object)n).Append("時").ToString());
			_0024act_0024t_0024440.names = (string[])RuntimeServices.AddArrays(typeof(string), _0024act_0024t_0024440.names, ArrayMap.RangeToStr(31, (int n) => new StringBuilder("今+").Append((object)(n + 1)).Append("日後").ToString()));
		}));
		actionClassServerClockMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable251_0024300_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002459.Adapt(delegate(ActionClassServerClockMode _0024act_0024t_0024440)
		{
			if (RuntimeDebugModeGuiMixin.button("下の値で設定"))
			{
				int[] table = _0024act_0024t_0024440.table;
				SetClockMode(table[RuntimeServices.NormalizeArrayIndex(table, _0024act_0024t_0024440.idx)], (__DebugSubModeSystemInfo_0024callable252_0024320_43__)(() => ServerClockMode()));
			}
			_0024act_0024t_0024440.idx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024440.idx, _0024act_0024t_0024440.names, 5);
		});
		actionClassServerClockMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable251_0024300_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002459.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassServerClockMode;
	}

	public ActionClassServerClockMode createServerClockMode()
	{
		return createDataServerClockMode();
	}

	public ActionClassServerClockMode2 ServerClockMode2()
	{
		ActionClassServerClockMode2 actionClassServerClockMode = createServerClockMode2();
		changeAction(actionClassServerClockMode);
		return actionClassServerClockMode;
	}

	public ActionClassServerClockMode2 createDataServerClockMode2()
	{
		ActionClassServerClockMode2 actionClassServerClockMode = new ActionClassServerClockMode2();
		actionClassServerClockMode._0024act_0024t_0024422 = ActionEnum.ServerClockMode2;
		actionClassServerClockMode._0024act_0024t_0024423 = "$default$";
		actionClassServerClockMode._0024act_0024t_0024424 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460.Adapt(delegate(ActionClassServerClockMode2 _0024act_0024t_0024443)
		{
			_0024act_0024t_0024443.days = ArrayMap.Range(24);
			_0024act_0024t_0024443.hours = ArrayMap.Range(40);
			_0024act_0024t_0024443.hourNames = ArrayMap.RangeToStr(24, (int n) => new StringBuilder("+").Append((object)n).Append("時").ToString());
			_0024act_0024t_0024443.dayNames = ArrayMap.RangeToStr(40, (int n) => new StringBuilder("+").Append((object)n).Append("日").ToString());
		});
		actionClassServerClockMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460.Adapt(delegate(ActionClassServerClockMode2 _0024act_0024t_0024443)
		{
			if (RuntimeDebugModeGuiMixin.button("サーバー時計リセット(+0日時)"))
			{
				SetClockMode(0, (__DebugSubModeSystemInfo_0024callable254_0024344_34__)(() => ServerClockMode2()));
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("下の時間＋日で設定"))
			{
				int[] days = _0024act_0024t_0024443.days;
				int num = days[RuntimeServices.NormalizeArrayIndex(days, _0024act_0024t_0024443.dayIdx)];
				int[] hours = _0024act_0024t_0024443.hours;
				int num2 = hours[RuntimeServices.NormalizeArrayIndex(hours, _0024act_0024t_0024443.hourIdx)];
				SetClockMode(checked(num * 24 + num2), (__DebugSubModeSystemInfo_0024callable254_0024344_34__)(() => ServerClockMode2()));
			}
			RuntimeDebugModeGuiMixin.slabel("+時");
			_0024act_0024t_0024443.hourIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024443.hourIdx, _0024act_0024t_0024443.hourNames, 5);
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.slabel("+日");
			_0024act_0024t_0024443.dayIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024443.dayIdx, _0024act_0024t_0024443.dayNames, 5);
		});
		actionClassServerClockMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable253_0024323_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002460.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassServerClockMode;
	}

	public ActionClassServerClockMode2 createServerClockMode2()
	{
		return createDataServerClockMode2();
	}

	public ActionClassSetClockMode SetClockMode(int hour, ICallable back)
	{
		ActionClassSetClockMode actionClassSetClockMode = createSetClockMode(hour, back);
		changeAction(actionClassSetClockMode);
		return actionClassSetClockMode;
	}

	public ActionClassSetClockMode createDataSetClockMode()
	{
		ActionClassSetClockMode actionClassSetClockMode = new ActionClassSetClockMode();
		actionClassSetClockMode._0024act_0024t_0024422 = ActionEnum.SetClockMode;
		actionClassSetClockMode._0024act_0024t_0024423 = "$default$";
		actionClassSetClockMode._0024act_0024t_0024424 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable255_0024358_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002461.Adapt(delegate(ActionClassSetClockMode _0024act_0024t_0024446)
		{
			string url = ServerURL.GameApiUrl(new StringBuilder("/DateDebug/Set?offsetTime=").Append((object)_0024act_0024t_0024446.hour).ToString());
			_0024act_0024t_0024446.www = new WWW(url);
		});
		actionClassSetClockMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable255_0024358_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002461.Adapt(delegate(ActionClassSetClockMode _0024act_0024t_0024446)
		{
			RuntimeDebugModeGuiMixin.label("設定中");
			if (_0024act_0024t_0024446.www.isDone)
			{
				RuntimeDebugModeGuiMixin.label("終了");
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					ServerClockMode();
				}
				string rhs = (string.IsNullOrEmpty(_0024act_0024t_0024446.www.error) ? "<no-error>" : _0024act_0024t_0024446.www.error);
				RuntimeDebugModeGuiMixin.slabel("WWW.error: " + rhs);
			}
		});
		actionClassSetClockMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable255_0024358_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002461.Adapt(delegate(ActionClassSetClockMode _0024act_0024t_0024446)
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				if (_0024act_0024t_0024446.back != null)
				{
					_0024act_0024t_0024446.back.Call(new object[0]);
				}
				else
				{
					MainMode();
				}
			}
		});
		return actionClassSetClockMode;
	}

	public ActionClassSetClockMode createSetClockMode(int hour, ICallable back)
	{
		ActionClassSetClockMode actionClassSetClockMode = createDataSetClockMode();
		actionClassSetClockMode.hour = hour;
		actionClassSetClockMode.back = back;
		return actionClassSetClockMode;
	}

	public ActionClassDownloadDataMode DownloadDataMode()
	{
		ActionClassDownloadDataMode actionClassDownloadDataMode = createDownloadDataMode();
		changeAction(actionClassDownloadDataMode);
		return actionClassDownloadDataMode;
	}

	public ActionClassDownloadDataMode createDataDownloadDataMode()
	{
		ActionClassDownloadDataMode actionClassDownloadDataMode = new ActionClassDownloadDataMode();
		actionClassDownloadDataMode._0024act_0024t_0024422 = ActionEnum.DownloadDataMode;
		actionClassDownloadDataMode._0024act_0024t_0024423 = "$default$";
		actionClassDownloadDataMode._0024act_0024t_0024424 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable257_0024387_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002462.Adapt(delegate(ActionClassDownloadDataMode _0024act_0024t_0024449)
		{
			Hashtable resourceHash2 = DownloadMain.ResourceHash;
			if (resourceHash2 != null)
			{
				Boo.Lang.List<string> list = new Boo.Lang.List<string>();
				IEnumerator enumerator = resourceHash2.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					string item = (string)obj;
					list.Add(item);
				}
				_0024act_0024t_0024449.abNames = (string[])Builtins.array(typeof(string), list);
				Array.Sort(_0024act_0024t_0024449.abNames, (string a, string b) => string.Compare(a, b));
				_0024act_0024t_0024449.abLoaded = new bool[_0024act_0024t_0024449.abNames.Length];
				_0024act_0024t_0024449.abVers = new int[_0024act_0024t_0024449.abNames.Length];
				int num2 = 0;
				int length2 = _0024act_0024t_0024449.abNames.Length;
				if (length2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num2 < length2)
				{
					int index2 = num2;
					num2++;
					string[] abNames2 = _0024act_0024t_0024449.abNames;
					string bundleName = abNames2[RuntimeServices.NormalizeArrayIndex(abNames2, index2)];
					string text3 = AssetBundleLoader.BundleURL(bundleName);
					int assetBundleVersion = DownloadUtil.GetAssetBundleVersion(resourceHash2, text3);
					bool[] abLoaded2 = _0024act_0024t_0024449.abLoaded;
					ref bool reference = ref abLoaded2[RuntimeServices.NormalizeArrayIndex(abLoaded2, index2)];
					reference = Caching.IsVersionCached(text3, assetBundleVersion);
					int[] abVers2 = _0024act_0024t_0024449.abVers;
					abVers2[RuntimeServices.NormalizeArrayIndex(abVers2, index2)] = assetBundleVersion;
				}
			}
			else
			{
				_0024act_0024t_0024449.abNames = new string[0];
				_0024act_0024t_0024449.abLoaded = new bool[0];
				_0024act_0024t_0024449.abVers = new int[0];
			}
		});
		actionClassDownloadDataMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable257_0024387_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002462.Adapt(delegate(ActionClassDownloadDataMode _0024act_0024t_0024449)
		{
			RuntimeDebugModeGuiMixin.label("データダウンロード状況");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("バージョン情報");
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Client: ").Append(CurrentInfo.ClientVersion).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Data:   ").Append(CurrentInfo.DataVersion).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Master: ").Append(CurrentInfo.MasterVersion).ToString());
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("RsrcSaved: ").Append(_0024act_0024t_0024449.rsrcSaved).ToString());
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("アセットバンドルリスト");
			Hashtable resourceHash = DownloadMain.ResourceHash;
			if (resourceHash == null)
			{
				RuntimeDebugModeGuiMixin.label("resourceHashがロードできていない");
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("resourceHash: エントリ数 ").Append((object)((ICollection)resourceHash).Count).ToString());
				int num = 0;
				int length = _0024act_0024t_0024449.abNames.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < length)
				{
					int index = num;
					num++;
					string[] abNames = _0024act_0024t_0024449.abNames;
					string text = abNames[RuntimeServices.NormalizeArrayIndex(abNames, index)];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = AssetBundleLoader.BundleURL(text);
						StringBuilder stringBuilder = new StringBuilder().Append(text).Append(" - ver:");
						int[] abVers = _0024act_0024t_0024449.abVers;
						StringBuilder stringBuilder2 = stringBuilder.Append((object)abVers[RuntimeServices.NormalizeArrayIndex(abVers, index)]).Append(" cached:");
						bool[] abLoaded = _0024act_0024t_0024449.abLoaded;
						RuntimeDebugModeGuiMixin.slabel(stringBuilder2.Append(abLoaded[RuntimeServices.NormalizeArrayIndex(abLoaded, index)]).ToString());
					}
				}
			}
		});
		actionClassDownloadDataMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable257_0024387_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002462.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassDownloadDataMode;
	}

	public ActionClassDownloadDataMode createDownloadDataMode()
	{
		return createDataDownloadDataMode();
	}

	public ActionClassIconAtlasMode IconAtlasMode()
	{
		ActionClassIconAtlasMode actionClassIconAtlasMode = createIconAtlasMode();
		changeAction(actionClassIconAtlasMode);
		return actionClassIconAtlasMode;
	}

	public ActionClassIconAtlasMode createDataIconAtlasMode()
	{
		ActionClassIconAtlasMode actionClassIconAtlasMode = new ActionClassIconAtlasMode();
		actionClassIconAtlasMode._0024act_0024t_0024422 = ActionEnum.IconAtlasMode;
		actionClassIconAtlasMode._0024act_0024t_0024423 = "$default$";
		actionClassIconAtlasMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable258_0024446_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002463.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("アイコンatlas");
			RuntimeDebugModeGuiMixin.slabel("武器/魔ペット: " + IconAtlasPool.Instance.IsWeaponPoppetLoaded);
			RuntimeDebugModeGuiMixin.slabel("スキル: " + IconAtlasPool.Instance.IsSkillLoaded);
			RuntimeDebugModeGuiMixin.slabel("DB load: " + IconAtlasPool.IsLoading);
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("武器/魔ペット/スキルアイコン廃棄"))
			{
				IconAtlasPool.UnloadAll();
			}
			RuntimeDebugModeGuiMixin.space(20);
			Boo.Lang.List<IconAtlasPool.Req> requests = IconAtlasPool.Instance.Requests;
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Sprite requests: ").Append((object)((ICollection)requests).Count).ToString());
			IEnumerator<IconAtlasPool.Req> enumerator = requests.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					IconAtlasPool.Req current = enumerator.Current;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(current).ToString());
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("IconAtlasPool:");
			int i = 0;
			IconAtlasPool.Atlas[] allAtlasData = IconAtlasPool.AllAtlasData;
			for (int length = allAtlasData.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(allAtlasData[i].Name).Append(": ").Append(allAtlasData[i].Mode)
					.Append(" loadReq:")
					.Append(allAtlasData[i].LoadReq)
					.ToString());
			}
		});
		actionClassIconAtlasMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable258_0024446_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002463.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassIconAtlasMode;
	}

	public ActionClassIconAtlasMode createIconAtlasMode()
	{
		return createDataIconAtlasMode();
	}

	public ActionClassAssetBundleRequestViewMode AssetBundleRequestViewMode()
	{
		ActionClassAssetBundleRequestViewMode actionClassAssetBundleRequestViewMode = createAssetBundleRequestViewMode();
		changeAction(actionClassAssetBundleRequestViewMode);
		return actionClassAssetBundleRequestViewMode;
	}

	public ActionClassAssetBundleRequestViewMode createDataAssetBundleRequestViewMode()
	{
		ActionClassAssetBundleRequestViewMode actionClassAssetBundleRequestViewMode = new ActionClassAssetBundleRequestViewMode();
		actionClassAssetBundleRequestViewMode._0024act_0024t_0024422 = ActionEnum.AssetBundleRequestViewMode;
		actionClassAssetBundleRequestViewMode._0024act_0024t_0024423 = "$default$";
		actionClassAssetBundleRequestViewMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable259_0024473_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002464.Adapt(delegate
		{
			RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
			RuntimeDebugModeGuiMixin.label("RuntimeAssetBundle");
			RuntimeDebugModeGuiMixin.slabel("  processed req num: " + instance.TotalProcessedReqNum);
			RuntimeDebugModeGuiMixin.slabel("  error req num: " + instance.ErrorReqNum);
			RuntimeDebugModeGuiMixin.slabel("  waiting counter: " + instance.WaitingCounter);
			RuntimeDebugModeGuiMixin.slabel("  current processing req num: " + instance.CurNumOfProcessReqs);
			RuntimeDebugModeGuiMixin.space(20);
			Boo.Lang.List<RuntimeAssetBundleDB.Req> currentProcessingReqs = RuntimeAssetBundleDB.Instance.CurrentProcessingReqs;
			RuntimeDebugModeGuiMixin.label("current processings: " + currentProcessingReqs.Count);
			IEnumerator<RuntimeAssetBundleDB.Req> enumerator = currentProcessingReqs.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					RuntimeAssetBundleDB.Req current = enumerator.Current;
					RuntimeDebugModeGuiMixin.slabel("   " + current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			RuntimeDebugModeGuiMixin.space(20);
			Queue<RuntimeAssetBundleDB.Req> workingQueue = RuntimeAssetBundleDB.Instance.WorkingQueue;
			RuntimeDebugModeGuiMixin.label("requests: " + workingQueue.Count);
			foreach (RuntimeAssetBundleDB.Req item in workingQueue)
			{
				RuntimeDebugModeGuiMixin.slabel("   " + item);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("AssetBundleLoader:");
			Dictionary<string, AssetBundleLoader.Entry> bundles = AssetBundleLoader.Instance.Bundles;
			foreach (string key in bundles.Keys)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key).Append(": ").Append(bundles[key])
					.ToString());
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("waiting queueu:");
			foreach (AssetBundleLoader.Entry item2 in AssetBundleLoader.Instance.WaitingQueue)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(item2).ToString());
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("loading queueu:");
			foreach (AssetBundleLoader.Entry loading in AssetBundleLoader.Instance.Loadings)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(loading).ToString());
			}
		});
		actionClassAssetBundleRequestViewMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable259_0024473_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002464.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassAssetBundleRequestViewMode;
	}

	public ActionClassAssetBundleRequestViewMode createAssetBundleRequestViewMode()
	{
		return createDataAssetBundleRequestViewMode();
	}

	public ActionClassAllAtlasViewMode AllAtlasViewMode()
	{
		ActionClassAllAtlasViewMode actionClassAllAtlasViewMode = createAllAtlasViewMode();
		changeAction(actionClassAllAtlasViewMode);
		return actionClassAllAtlasViewMode;
	}

	public ActionClassAllAtlasViewMode createDataAllAtlasViewMode()
	{
		ActionClassAllAtlasViewMode actionClassAllAtlasViewMode = new ActionClassAllAtlasViewMode();
		actionClassAllAtlasViewMode._0024act_0024t_0024422 = ActionEnum.AllAtlasViewMode;
		actionClassAllAtlasViewMode._0024act_0024t_0024423 = "$default$";
		actionClassAllAtlasViewMode._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable260_0024513_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002465.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("All Awaked ATLASES: N=" + UIAtlas.AllAtlases.Count);
			foreach (UIAtlas allAtlase in UIAtlas.AllAtlases)
			{
				if (!(allAtlase == null))
				{
					int num = allAtlase.spriteList?.Count ?? 0;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allAtlase.name).Append(" - mat:").Append(materialInfo(allAtlase.spriteMaterial))
						.Append(" nspr:")
						.Append((object)num)
						.ToString());
				}
			}
		});
		actionClassAllAtlasViewMode._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable260_0024513_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002465.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassAllAtlasViewMode;
	}

	public ActionClassAllAtlasViewMode createAllAtlasViewMode()
	{
		return createDataAllAtlasViewMode();
	}

	private static string materialInfo(Material mat)
	{
		return (mat == null) ? "<no material>" : ((!mat.HasProperty("_MainTex")) ? new StringBuilder().Append(mat.name).Append("(no maintex) ").ToString() : new StringBuilder().Append(mat.name).Append("( ").Append(textureInfo(mat.mainTexture))
			.Append(" ) ")
			.ToString());
	}

	private static string textureInfo(Texture tex)
	{
		return (!(tex == null)) ? new StringBuilder().Append(tex.name).Append(" ").Append((object)tex.width)
			.Append(" x ")
			.Append((object)tex.height)
			.ToString() : "<no texture>";
	}

	public ActionClassfontStatusView fontStatusView()
	{
		ActionClassfontStatusView actionClassfontStatusView = createfontStatusView();
		changeAction(actionClassfontStatusView);
		return actionClassfontStatusView;
	}

	public ActionClassfontStatusView createDatafontStatusView()
	{
		ActionClassfontStatusView actionClassfontStatusView = new ActionClassfontStatusView();
		actionClassfontStatusView._0024act_0024t_0024422 = ActionEnum.fontStatusView;
		actionClassfontStatusView._0024act_0024t_0024423 = "$default$";
		actionClassfontStatusView._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable261_0024539_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002466.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("font情報(参考値)");
			Hashtable fontHash = UIDynamicFontLabel.FontHash;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("num:").Append((object)((ICollection)fontHash).Count).ToString());
			IEnumerator enumerator = fontHash.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Font))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Font));
				}
				Font font = (Font)obj;
				if (!(font == null))
				{
					Material material = font.material;
					if (material == null)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": no material for ").Append(font)
							.ToString());
					}
					else
					{
						Texture mainTexture = material.mainTexture;
						if (mainTexture != null)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": wh=").Append((object)mainTexture.width)
								.Append(" x ")
								.Append((object)mainTexture.height)
								.ToString());
						}
						else
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": no texture for material ").Append(material)
								.ToString());
						}
					}
				}
			}
		});
		actionClassfontStatusView._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable261_0024539_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002466.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassfontStatusView;
	}

	public ActionClassfontStatusView createfontStatusView()
	{
		return createDatafontStatusView();
	}

	public ActionClassdontDestroyView dontDestroyView()
	{
		ActionClassdontDestroyView actionClassdontDestroyView = createdontDestroyView();
		changeAction(actionClassdontDestroyView);
		return actionClassdontDestroyView;
	}

	public ActionClassdontDestroyView createDatadontDestroyView()
	{
		ActionClassdontDestroyView actionClassdontDestroyView = new ActionClassdontDestroyView();
		actionClassdontDestroyView._0024act_0024t_0024422 = ActionEnum.dontDestroyView;
		actionClassdontDestroyView._0024act_0024t_0024423 = "$default$";
		actionClassdontDestroyView._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable262_0024557_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002467.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("SceneDontDestroyObject:");
			Hashtable dontDestroyList = SceneDontDestroyObject.DontDestroyList;
			IEnumerator enumerator = dontDestroyList.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(current).Append(": ").Append(dontDestroyList[current])
					.ToString());
			}
			RuntimeDebugModeGuiMixin.space(30);
			RuntimeDebugModeGuiMixin.label("NonQuestDontDestroyObjects:");
			Dictionary<int, UnityEngine.Object> registrations = NonQuestDontDestroyObjects.Registrations;
			foreach (int key in registrations.Keys)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)key).Append(": ").Append(registrations[key])
					.ToString());
			}
		});
		actionClassdontDestroyView._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable262_0024557_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002467.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassdontDestroyView;
	}

	public ActionClassdontDestroyView createdontDestroyView()
	{
		return createDatadontDestroyView();
	}

	public ActionClassmiscInfoView miscInfoView()
	{
		ActionClassmiscInfoView actionClassmiscInfoView = createmiscInfoView();
		changeAction(actionClassmiscInfoView);
		return actionClassmiscInfoView;
	}

	public ActionClassmiscInfoView createDatamiscInfoView()
	{
		ActionClassmiscInfoView actionClassmiscInfoView = new ActionClassmiscInfoView();
		actionClassmiscInfoView._0024act_0024t_0024422 = ActionEnum.miscInfoView;
		actionClassmiscInfoView._0024act_0024t_0024423 = "$default$";
		actionClassmiscInfoView._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable263_0024571_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002468.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("Misc Info View");
			RuntimeDebugModeGuiMixin.slabel("ClientMasterArchive.IsReadingMasterArchive:" + ClientMasterArchive.IsReadingMasterArchive());
			RuntimeDebugModeGuiMixin.label("MStories:");
			int i = 0;
			MStories[] all = MStories.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(all[i]).ToString());
			}
			RuntimeDebugModeGuiMixin.label("QuestAssets/PlayerAssets");
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("QuestAssets: Exists:").Append(QuestAssets.Exists).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("PlayerAssets: Exists:").Append(PlayerAssets.Exists).ToString());
		});
		actionClassmiscInfoView._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable263_0024571_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002468.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassmiscInfoView;
	}

	public ActionClassmiscInfoView createmiscInfoView()
	{
		return createDatamiscInfoView();
	}

	public ActionClassViewMasters ViewMasters()
	{
		ActionClassViewMasters actionClassViewMasters = createViewMasters();
		changeAction(actionClassViewMasters);
		return actionClassViewMasters;
	}

	public ActionClassViewMasters createDataViewMasters()
	{
		ActionClassViewMasters actionClassViewMasters = new ActionClassViewMasters();
		actionClassViewMasters._0024act_0024t_0024422 = ActionEnum.ViewMasters;
		actionClassViewMasters._0024act_0024t_0024423 = "$default$";
		actionClassViewMasters._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable264_0024587_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002469.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("ClientMasterArchive:");
			RuntimeDebugModeGuiMixin.slabel("HasCache:" + ClientMasterArchive.HasCache);
			RuntimeDebugModeGuiMixin.slabel("IsReadingMasterArchive:" + ClientMasterArchive.IsReadingMasterArchive());
			RuntimeDebugModeGuiMixin.slabel("LoadingMasterInfo:" + ClientMasterArchive.LoadingMasterInfo);
			RuntimeDebugModeGuiMixin.slabel("ReadMasterArchiveCacheASyncCount:" + ClientMasterArchive.ReadMasterArchiveCacheASyncCount);
			RuntimeDebugModeGuiMixin.slabel("ReadMasterArchiveCacheASyncEndCount:" + ClientMasterArchive.ReadMasterArchiveCacheASyncEndCount);
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("ClientMasterArchive load info");
			Dictionary<string, string> lastLoadedMasterInfo = ClientMasterArchive.LastLoadedMasterInfo;
			foreach (string key in lastLoadedMasterInfo.Keys)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": ").ToString() + lastLoadedMasterInfo[key]);
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("MerlinMaster.LoadedMasters:");
			IEnumerator enumerator2 = MerlinMaster.DebugLoadedMasters.Keys.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object current2 = enumerator2.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(current2).ToString());
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("ClientMasterArchive: prepared");
			IEnumerator<string> enumerator3 = ClientMasterArchive.PreparedMasters.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					string current3 = enumerator3.Current;
					RuntimeDebugModeGuiMixin.slabel(current3);
				}
			}
			finally
			{
				enumerator3.Dispose();
			}
		});
		actionClassViewMasters._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable264_0024587_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002469.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassViewMasters;
	}

	public ActionClassViewMasters createViewMasters()
	{
		return createDataViewMasters();
	}

	public ActionClassViewCommunications ViewCommunications()
	{
		ActionClassViewCommunications actionClassViewCommunications = createViewCommunications();
		changeAction(actionClassViewCommunications);
		return actionClassViewCommunications;
	}

	public ActionClassViewCommunications createDataViewCommunications()
	{
		ActionClassViewCommunications actionClassViewCommunications = new ActionClassViewCommunications();
		actionClassViewCommunications._0024act_0024t_0024422 = ActionEnum.ViewCommunications;
		actionClassViewCommunications._0024act_0024t_0024423 = "$default$";
		actionClassViewCommunications._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable265_0024615_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002470.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("通信状況");
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Working Requets:");
			IEnumerator<RequestBase> enumerator = MerlinServer.Instance.WorkingReqs.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					RequestBase current = enumerator.Current;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current.shortDescription()).ToString());
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Queued Requets:");
			IEnumerator<RequestBase> enumerator2 = MerlinServer.Instance.QueuedReqs.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					RequestBase current2 = enumerator2.Current;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current2.shortDescription()).ToString());
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		});
		actionClassViewCommunications._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable265_0024615_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002470.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassViewCommunications;
	}

	public ActionClassViewCommunications createViewCommunications()
	{
		return createDataViewCommunications();
	}

	public ActionClasspyxisTest pyxisTest()
	{
		ActionClasspyxisTest actionClasspyxisTest = createpyxisTest();
		changeAction(actionClasspyxisTest);
		return actionClasspyxisTest;
	}

	public ActionClasspyxisTest createDatapyxisTest()
	{
		ActionClasspyxisTest actionClasspyxisTest = new ActionClasspyxisTest();
		actionClasspyxisTest._0024act_0024t_0024422 = ActionEnum.pyxisTest;
		actionClasspyxisTest._0024act_0024t_0024423 = "$default$";
		actionClasspyxisTest._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable266_0024629_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002471.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("エセなpyxisテスト");
			if (RuntimeDebugModeGuiMixin.button("100円石買ったよ通知"))
			{
				PyxisBridge.SendPaymentInfoToFuckPyxisService(100.0, 1);
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("500円石買ったよ通知"))
			{
				PyxisBridge.SendPaymentInfoToFuckPyxisService(500.0, 1);
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("1000円石買ったよ通知"))
			{
				PyxisBridge.SendPaymentInfoToFuckPyxisService(1000.0, 1);
			}
			RuntimeDebugModeGuiMixin.space(20);
			if (RuntimeDebugModeGuiMixin.button("チュートリアルクリアしたよ通知"))
			{
				PyxisBridge.SendTutorialFinishingToFuckPyxisService();
			}
		});
		actionClasspyxisTest._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable266_0024629_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002471.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClasspyxisTest;
	}

	public ActionClasspyxisTest createpyxisTest()
	{
		return createDatapyxisTest();
	}

	public ActionClassprofilerView profilerView()
	{
		ActionClassprofilerView actionClassprofilerView = createprofilerView();
		changeAction(actionClassprofilerView);
		return actionClassprofilerView;
	}

	public ActionClassprofilerView createDataprofilerView()
	{
		ActionClassprofilerView actionClassprofilerView = new ActionClassprofilerView();
		actionClassprofilerView._0024act_0024t_0024422 = ActionEnum.profilerView;
		actionClassprofilerView._0024act_0024t_0024423 = "$default$";
		actionClassprofilerView._0024act_0024t_0024424 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable267_0024646_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002472.Adapt(delegate(ActionClassprofilerView _0024act_0024t_0024479)
		{
			_0024act_0024t_0024479.objLists = new Boo.Lang.List<UnityEngine.Object[]>();
			_0024act_0024t_0024479.sizLists = new Boo.Lang.List<int[]>();
			int i = 0;
			Type[] pROFILER_VIEW_TYPES2 = PROFILER_VIEW_TYPES;
			for (int length = pROFILER_VIEW_TYPES2.Length; i < length; i = checked(i + 1))
			{
				UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(pROFILER_VIEW_TYPES2[i]);
				sortProfileObjs(array);
				int[] array2 = new int[array.Length];
				int num5 = 0;
				int length2 = array.Length;
				if (length2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num5 < length2)
				{
					int index = num5;
					num5++;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = Profiler.GetRuntimeMemorySize(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
				}
				_0024act_0024t_0024479.objLists.Add(array);
				_0024act_0024t_0024479.sizLists.Add(array2);
			}
			_0024act_0024t_0024479.currentIndex = 0;
			_0024act_0024t_0024479.selection = new string[PROFILER_VIEW_TYPES.Length];
			int num6 = 0;
			int length3 = PROFILER_VIEW_TYPES.Length;
			if (length3 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num6 < length3)
			{
				int index2 = num6;
				num6++;
				string[] selection = _0024act_0024t_0024479.selection;
				int num7 = RuntimeServices.NormalizeArrayIndex(selection, index2);
				Type[] pROFILER_VIEW_TYPES3 = PROFILER_VIEW_TYPES;
				selection[num7] = pROFILER_VIEW_TYPES3[RuntimeServices.NormalizeArrayIndex(pROFILER_VIEW_TYPES3, index2)].Name;
			}
		});
		actionClassprofilerView._0024act_0024t_0024425 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable267_0024646_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002472.Adapt(delegate(ActionClassprofilerView _0024act_0024t_0024479)
		{
			_0024act_0024t_0024479.mode = 0;
			_0024act_0024t_0024479.pagetop = 0;
			_0024act_0024t_0024479.objLists = null;
			_0024act_0024t_0024479.sizLists = null;
			_0024act_0024t_0024479.currentIndex = 0;
			_0024act_0024t_0024479.selection = null;
		});
		actionClassprofilerView._0024act_0024t_0024428 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable267_0024646_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002472.Adapt(delegate(ActionClassprofilerView _0024act_0024t_0024479)
		{
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024 = new _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299();
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479 = _0024act_0024t_0024479;
			if (RuntimeDebugModeGuiMixin.button("unload unsed assets"))
			{
				UnloadResource.UnloadUnusedAssets();
			}
			RuntimeDebugModeGuiMixin.space(20);
			int num = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex, _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.selection, 3);
			if (num != _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex)
			{
				_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex = num;
				_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop = 0;
			}
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.objLists[_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex];
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curSize = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.sizLists[_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex];
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024pageLines = 100;
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024).Invoke;
			_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
			StringBuilder stringBuilder = new StringBuilder();
			Type[] pROFILER_VIEW_TYPES = PROFILER_VIEW_TYPES;
			RuntimeDebugModeGuiMixin.label(stringBuilder.Append(pROFILER_VIEW_TYPES[RuntimeServices.NormalizeArrayIndex(pROFILER_VIEW_TYPES, _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex)]).Append(": ").Append((object)_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop)
				.Append("/")
				.Append((object)_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData.Length)
				.ToString());
			int num2 = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop;
			int num3 = Math.Min(checked(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop + 50), _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData.Length);
			int num4 = 1;
			if (num3 < num2)
			{
				num4 = -1;
			}
			while (num2 != num3)
			{
				int _0024i_0024 = num2;
				num2 += num4;
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataprofilerView_0024closure_00243448_0024closure_00243451(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024, _0024i_0024).Invoke));
			}
			_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
		});
		actionClassprofilerView._0024act_0024t_0024426 = _0024adaptor_0024__DebugSubModeSystemInfo_0024callable267_0024646_5___0024__ActionBase__0024act_0024t_0024424_0024callable23_002424_5___002472.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassprofilerView;
	}

	public ActionClassprofilerView createprofilerView()
	{
		return createDataprofilerView();
	}

	private static void sortProfileObjs(UnityEngine.Object[] objs)
	{
		Array.Sort(objs, (UnityEngine.Object o1, UnityEngine.Object o2) => string.Compare(objectName(o1), objectName(o2)));
	}

	private static string objectName(UnityEngine.Object o)
	{
		string empty = string.Empty;
		empty = ((o == null) ? "<null>" : ((o is Animation) ? (o as Animation).name : ((o is Texture) ? (textureInfo(o as Texture) + " - GUID:" + ExtensionsModule.GetMyID(o)) : ((o is UIAtlas) ? (o as UIAtlas).name : ((o is Material) ? (materialInfo(o as Material) + " - GUID:" + ExtensionsModule.GetMyID(o)) : ((!(o is GameObject)) ? new StringBuilder().Append(o).Append(" of ").Append(o.GetType())
			.ToString() : new StringBuilder("GameObjec(").Append(o).Append(") - GUID:").Append(ExtensionsModule.GetMyID(o))
			.ToString()))))));
		return (!string.IsNullOrEmpty(empty)) ? empty : new StringBuilder("<unknown> of ").Append(o.GetType()).ToString();
	}

	internal void _0024createDataMainMode_0024closure_00243393(ActionClassMainMode _0024act_0024t_0024421)
	{
		RuntimeDebugModeGuiMixin.label("SERVER");
		int titleWidth = 200;
		RuntimeDebugModeGuiMixin.snamevalue("EXAM-VER", ServerURL.ExamVerSrvUrl("/"), titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("SERV-Platform", ServerURL.PlatformApiUrl("/"), titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("SERV-Entry", ServerURL.EntryApiUrl("/"), titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("SERV-Game", ServerURL.GameApiUrl("/"), titleWidth);
		if (ServerURL.HasAssetSrvURL)
		{
			RuntimeDebugModeGuiMixin.snamevalue("SERV-AssetSrv", ServerURL.AssetSrvUrl("/"), titleWidth);
		}
		else
		{
			RuntimeDebugModeGuiMixin.snamevalue("SERV-AssetSrv", "<none>", titleWidth);
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("SESSION");
		RuntimeDebugModeGuiMixin.slabel("UUID:" + CurrentInfo.UUID);
		RuntimeDebugModeGuiMixin.slabel("Token:" + CurrentInfo.Token);
		RuntimeDebugModeGuiMixin.slabel("CreatedCharacter:" + CurrentInfo.AlreadyCreatedCharacter);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("PLAYER");
		RuntimeDebugModeGuiMixin.label("ソーシャルID: " + UserData.Current.userStatus.TSocialPlayerId);
		RuntimeDebugModeGuiMixin.slabel("PLAYER-ID:" + UserData.Current.userBasicInfo.Id);
		RuntimeDebugModeGuiMixin.slabel("PLAYER-NAME:" + UserData.Current.userBasicInfo.Name);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label(new StringBuilder("DEVICE:").Append(PerformanceSettingBase.GetAndroidDeviceModel()).ToString());
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.operatingSystem:" + SystemInfo.operatingSystem);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceUniqueIdentifier:" + SystemInfo.deviceUniqueIdentifier);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceModel:" + SystemInfo.deviceModel);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.deviceName:" + SystemInfo.deviceName);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsDeviceName:" + SystemInfo.graphicsDeviceName);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsDeviceVendor:" + SystemInfo.graphicsDeviceVendor);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.processorType:" + SystemInfo.processorType);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.graphicsMemorySize:" + SystemInfo.graphicsMemorySize);
		RuntimeDebugModeGuiMixin.slabel("SystemInfo.systemMemorySize:" + SystemInfo.systemMemorySize);
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("CLEAR ALL DATA"))
		{
			ClearData.ClearAllData();
		}
		if (RuntimeDebugModeGuiMixin.button("CLEAR DOWNLOADED DATA"))
		{
			ClearData.ClearDownloadedData();
		}
		RuntimeDebugModeGuiMixin.space(20);
		int currentServerIndex = ServerURL.CurrentServerIndex;
		RuntimeDebugModeGuiMixin.label("接続先変更:" + currentServerIndex);
		RuntimeDebugModeGuiMixin.slabel("変更するとclear all data");
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		int i = 0;
		ServerURL.ServerConnectProperty[] servers = ServerURL.Servers;
		for (int length = servers.Length; i < length; i = checked(i + 1))
		{
			list.Add(servers[i].name);
		}
		string[] texts = list.ToArray();
		int num = RuntimeDebugModeGuiMixin.grid(currentServerIndex, texts, 3);
		if (currentServerIndex != num && num != 0 && num != 1 && num != 2)
		{
			ServerURL.CurrentServerIndex = num;
			ClearData.ClearAllData();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("サーバー時計変更"))
			{
				ServerClockMode();
			}
			if (RuntimeDebugModeGuiMixin.button("サーバー時計変更2"))
			{
				ServerClockMode2();
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("現在ゲーム内時刻");
		RuntimeDebugModeGuiMixin.slabel("Now: " + MerlinDateTime.Now);
		RuntimeDebugModeGuiMixin.slabel("UtcNow: " + MerlinDateTime.UtcNow);
		TimeSpan timeOffset = MerlinDateTime.TimeOffset;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("srv補正: + ").Append((object)timeOffset.Days).Append("days ").Append((object)timeOffset.Hours)
			.Append(":")
			.Append((object)timeOffset.Minutes)
			.Append(":")
			.Append((object)timeOffset.Seconds)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel("DateTime.Now: " + DateTime.Now);
		RuntimeDebugModeGuiMixin.slabel("DateTime.UtcNow: " + DateTime.UtcNow);
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("日次再ログイン用に１日前プレイ状態にする(要再起動)"))
		{
			DailyTask.DebugSaveYesterday();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("ダウンロード状況"))
			{
				DownloadDataMode();
			}
			if (RuntimeDebugModeGuiMixin.button("アイコンアトラス状況"))
			{
				IconAtlasMode();
			}
		});
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("asset bundle requests"))
			{
				AssetBundleRequestViewMode();
			}
			if (RuntimeDebugModeGuiMixin.button("all atlases"))
			{
				AllAtlasViewMode();
			}
			if (RuntimeDebugModeGuiMixin.button("communication"))
			{
				ViewCommunications();
			}
		});
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("masters"))
			{
				ViewMasters();
			}
		});
		RuntimeDebugModeGuiMixin.space(20);
		versionEdit();
		RuntimeDebugModeGuiMixin.label("Google Cloud Messaging 情報");
		if (RuntimeDebugModeGuiMixin.button("register"))
		{
			string gcmSenderId = "537118308623";
			__Req_FailHandler_0024callable6_0024440_32__ from = delegate
			{
			};
			GoogleCloudMessagingManager.registrationSucceededEvent += _0024adaptor_0024__Req_FailHandler_0024callable6_0024440_32___0024Action_002473.Adapt(from);
			GoogleCloudMessaging.register(gcmSenderId);
		}
		if (RuntimeDebugModeGuiMixin.button("unregister"))
		{
			GoogleCloudMessaging.unRegister();
		}
		if (RuntimeDebugModeGuiMixin.button("check notifications"))
		{
			GoogleCloudMessaging.checkForNotifications();
		}
		if (RuntimeDebugModeGuiMixin.button("cancel notification"))
		{
			GoogleCloudMessaging.cancelAll();
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("clear all dataだけど外部化データ残す"))
		{
			ClearData.ClearAllWithoutDownloadedData();
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("/Homeする"))
		{
			MerlinServer.Request(new ApiHome(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				StorageHUD.DoUpdateNow();
			}));
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("/Home/Slim する"))
		{
			MerlinServer.Request(new ApiHomeSlim(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				StorageHUD.DoUpdateNow();
			}));
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("ランキング報酬配布バッチ"))
		{
			MerlinServer.Request(new ApiRankingBat());
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("レイド情報取得 /Build/RaidBattle - 似非push通知用"))
		{
			MerlinServer.Request(new ApiGuildRaidBattle(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
			}));
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("おしらせ"))
		{
			ExitDebugMode();
			GameObject gameObject = null;
			Component component = (MyHomeMain)UnityEngine.Object.FindObjectOfType(typeof(MyHomeMain));
			if (!component)
			{
				component = (TownMain)UnityEngine.Object.FindObjectOfType(typeof(TownMain));
			}
			if ((bool)component)
			{
				gameObject = component.gameObject;
			}
			if ((bool)gameObject)
			{
				DailyTask.Delay = 1f;
				DailyTask.DebugSaveYesterday();
				gameObject.AddComponent<DailyTask>();
			}
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("font使用量(参考値):"))
		{
			fontStatusView();
		}
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("DontDestroys"))
			{
				dontDestroyView();
			}
			if (RuntimeDebugModeGuiMixin.button("miscInfoView"))
			{
				miscInfoView();
			}
		});
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("profiles"))
			{
				profilerView();
			}
		});
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("Pyxis"))
		{
			pyxisTest();
		}
		RuntimeDebugModeGuiMixin.space(20);
		bool examVerMode = RuntimeDebugModeGuiMixin.boolButtons(ApiExamVer.IsExamVer, "ExamVer");
		ApiExamVer.SetExamVerMode(examVerMode);
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("D540OpeCodePool info"))
		{
			D540OpeCodePoolInfo();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.slabel("realtimeSinceStartup: " + Time.realtimeSinceStartup);
		RuntimeDebugModeGuiMixin.slabel("Time.timeScale: " + Time.timeScale);
		RuntimeDebugModeGuiMixin.space(20);
		if (Camera.main != null)
		{
			RuntimeDebugModeGuiMixin.slabel("Camera.main: " + Camera.main.gameObject);
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel("Camera.main = null");
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("レイド残りプレイ時間(s):" + PhotonClientMain.LastRemainingTime);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.slabel("URLScheme");
		RuntimeDebugModeGuiMixin.textArea("URI:\n" + URLScheme.GetLastRequestURI());
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243394()
	{
		if (RuntimeDebugModeGuiMixin.button("サーバー時計変更"))
		{
			ServerClockMode();
		}
		if (RuntimeDebugModeGuiMixin.button("サーバー時計変更2"))
		{
			ServerClockMode2();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243395()
	{
		if (RuntimeDebugModeGuiMixin.button("ダウンロード状況"))
		{
			DownloadDataMode();
		}
		if (RuntimeDebugModeGuiMixin.button("アイコンアトラス状況"))
		{
			IconAtlasMode();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243396()
	{
		if (RuntimeDebugModeGuiMixin.button("asset bundle requests"))
		{
			AssetBundleRequestViewMode();
		}
		if (RuntimeDebugModeGuiMixin.button("all atlases"))
		{
			AllAtlasViewMode();
		}
		if (RuntimeDebugModeGuiMixin.button("communication"))
		{
			ViewCommunications();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243397()
	{
		if (RuntimeDebugModeGuiMixin.button("masters"))
		{
			ViewMasters();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243398(string registrationId)
	{
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243399()
	{
		StorageHUD.DoUpdateNow();
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243400()
	{
		StorageHUD.DoUpdateNow();
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243401()
	{
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243402()
	{
		if (RuntimeDebugModeGuiMixin.button("DontDestroys"))
		{
			dontDestroyView();
		}
		if (RuntimeDebugModeGuiMixin.button("miscInfoView"))
		{
			miscInfoView();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00243393_0024closure_00243403()
	{
		if (RuntimeDebugModeGuiMixin.button("profiles"))
		{
			profilerView();
		}
	}

	internal void _0024createDataMainMode_0024closure_00243404(ActionClassMainMode _0024act_0024t_0024421)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024versionEdit_0024closure_00243405()
	{
		int num = 0;
		if (RuntimeDebugModeGuiMixin.button("down") && currentClientVersion > 0)
		{
			num = -1;
		}
		if (RuntimeDebugModeGuiMixin.button("up"))
		{
			num = 1;
		}
		checked
		{
			if (num != 0)
			{
				currentClientVersion += num;
				CurrentBuildableVersion.SetPrefClientVersion(new StringBuilder().Append((object)currentClientVersion).ToString());
			}
		}
	}

	internal void _0024createDataD540OpeCodePoolInfo_0024closure_00243406(ActionClassD540OpeCodePoolInfo _0024act_0024t_0024437)
	{
		D540OpeCodePool instance = D540OpeCodePool.Instance;
		RuntimeDebugModeGuiMixin.label("D540OpeCodePool info");
		RuntimeDebugModeGuiMixin.space(20);
		int num = 0;
		int num2 = 0;
		int num3 = 37;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			int poolingNum = instance.getPoolingNum((D540OpeCodeId)num4);
			num = checked(num + poolingNum);
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((D540OpeCodeId)num4).Append(": ").ToString() + poolingNum);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.slabel("total allocation count: " + instance.TotalAllocationCount);
		RuntimeDebugModeGuiMixin.slabel("total deallocation count: " + instance.TotalDeallocationCount);
		RuntimeDebugModeGuiMixin.slabel("pooling count: " + num);
		RuntimeDebugModeGuiMixin.slabel("expected allocation count: " + instance.ExpectedCurrentAllocationCount);
	}

	internal void _0024createDataServerClockMode_0024closure_00243407(ActionClassServerClockMode _0024act_0024t_0024440)
	{
		_0024act_0024t_0024440.idx = 0;
		int[] array = ArrayMap.Range(24);
		checked
		{
			int[] rhs = ArrayMap.Range(31, (int n) => 24 * (n + 1));
			_0024act_0024t_0024440.table = (int[])RuntimeServices.AddArrays(typeof(int), array, rhs);
			_0024act_0024t_0024440.names = ArrayMap.IntToStr(array, (int n) => new StringBuilder("今+").Append((object)n).Append("時").ToString());
			_0024act_0024t_0024440.names = (string[])RuntimeServices.AddArrays(typeof(string), _0024act_0024t_0024440.names, ArrayMap.RangeToStr(31, (int n) => new StringBuilder("今+").Append((object)(n + 1)).Append("日後").ToString()));
		}
	}

	internal int _0024_0024createDataServerClockMode_0024closure_00243407_0024closure_00243408(int n)
	{
		return checked(24 * (n + 1));
	}

	internal string _0024_0024createDataServerClockMode_0024closure_00243407_0024closure_00243409(int n)
	{
		return new StringBuilder("今+").Append((object)n).Append("時").ToString();
	}

	internal string _0024_0024createDataServerClockMode_0024closure_00243407_0024closure_00243410(int n)
	{
		return new StringBuilder("今+").Append((object)checked(n + 1)).Append("日後").ToString();
	}

	internal void _0024createDataServerClockMode_0024closure_00243411(ActionClassServerClockMode _0024act_0024t_0024440)
	{
		if (RuntimeDebugModeGuiMixin.button("下の値で設定"))
		{
			int[] table = _0024act_0024t_0024440.table;
			SetClockMode(table[RuntimeServices.NormalizeArrayIndex(table, _0024act_0024t_0024440.idx)], (__DebugSubModeSystemInfo_0024callable252_0024320_43__)(() => ServerClockMode()));
		}
		_0024act_0024t_0024440.idx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024440.idx, _0024act_0024t_0024440.names, 5);
	}

	internal ActionClassServerClockMode _0024_0024createDataServerClockMode_0024closure_00243411_0024closure_00243412()
	{
		return ServerClockMode();
	}

	internal void _0024createDataServerClockMode_0024closure_00243413(ActionClassServerClockMode _0024act_0024t_0024440)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataServerClockMode2_0024closure_00243414(ActionClassServerClockMode2 _0024act_0024t_0024443)
	{
		_0024act_0024t_0024443.days = ArrayMap.Range(24);
		_0024act_0024t_0024443.hours = ArrayMap.Range(40);
		_0024act_0024t_0024443.hourNames = ArrayMap.RangeToStr(24, (int n) => new StringBuilder("+").Append((object)n).Append("時").ToString());
		_0024act_0024t_0024443.dayNames = ArrayMap.RangeToStr(40, (int n) => new StringBuilder("+").Append((object)n).Append("日").ToString());
	}

	internal string _0024_0024createDataServerClockMode2_0024closure_00243414_0024closure_00243415(int n)
	{
		return new StringBuilder("+").Append((object)n).Append("時").ToString();
	}

	internal string _0024_0024createDataServerClockMode2_0024closure_00243414_0024closure_00243416(int n)
	{
		return new StringBuilder("+").Append((object)n).Append("日").ToString();
	}

	internal void _0024createDataServerClockMode2_0024closure_00243417(ActionClassServerClockMode2 _0024act_0024t_0024443)
	{
		if (RuntimeDebugModeGuiMixin.button("サーバー時計リセット(+0日時)"))
		{
			SetClockMode(0, (__DebugSubModeSystemInfo_0024callable254_0024344_34__)(() => ServerClockMode2()));
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("下の時間＋日で設定"))
		{
			int[] days = _0024act_0024t_0024443.days;
			int num = days[RuntimeServices.NormalizeArrayIndex(days, _0024act_0024t_0024443.dayIdx)];
			int[] hours = _0024act_0024t_0024443.hours;
			int num2 = hours[RuntimeServices.NormalizeArrayIndex(hours, _0024act_0024t_0024443.hourIdx)];
			SetClockMode(checked(num * 24 + num2), (__DebugSubModeSystemInfo_0024callable254_0024344_34__)(() => ServerClockMode2()));
		}
		RuntimeDebugModeGuiMixin.slabel("+時");
		_0024act_0024t_0024443.hourIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024443.hourIdx, _0024act_0024t_0024443.hourNames, 5);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.slabel("+日");
		_0024act_0024t_0024443.dayIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024443.dayIdx, _0024act_0024t_0024443.dayNames, 5);
	}

	internal ActionClassServerClockMode2 _0024_0024createDataServerClockMode2_0024closure_00243417_0024closure_00243418()
	{
		return ServerClockMode2();
	}

	internal ActionClassServerClockMode2 _0024_0024createDataServerClockMode2_0024closure_00243417_0024closure_00243419()
	{
		return ServerClockMode2();
	}

	internal void _0024createDataServerClockMode2_0024closure_00243420(ActionClassServerClockMode2 _0024act_0024t_0024443)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataSetClockMode_0024closure_00243421(ActionClassSetClockMode _0024act_0024t_0024446)
	{
		string url = ServerURL.GameApiUrl(new StringBuilder("/DateDebug/Set?offsetTime=").Append((object)_0024act_0024t_0024446.hour).ToString());
		_0024act_0024t_0024446.www = new WWW(url);
	}

	internal void _0024createDataSetClockMode_0024closure_00243422(ActionClassSetClockMode _0024act_0024t_0024446)
	{
		RuntimeDebugModeGuiMixin.label("設定中");
		if (_0024act_0024t_0024446.www.isDone)
		{
			RuntimeDebugModeGuiMixin.label("終了");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				ServerClockMode();
			}
			string rhs = (string.IsNullOrEmpty(_0024act_0024t_0024446.www.error) ? "<no-error>" : _0024act_0024t_0024446.www.error);
			RuntimeDebugModeGuiMixin.slabel("WWW.error: " + rhs);
		}
	}

	internal void _0024createDataSetClockMode_0024closure_00243423(ActionClassSetClockMode _0024act_0024t_0024446)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			if (_0024act_0024t_0024446.back != null)
			{
				_0024act_0024t_0024446.back.Call(new object[0]);
			}
			else
			{
				MainMode();
			}
		}
	}

	internal void _0024createDataDownloadDataMode_0024closure_00243424(ActionClassDownloadDataMode _0024act_0024t_0024449)
	{
		Hashtable resourceHash = DownloadMain.ResourceHash;
		if (resourceHash != null)
		{
			Boo.Lang.List<string> list = new Boo.Lang.List<string>();
			IEnumerator enumerator = resourceHash.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string item = (string)obj;
				list.Add(item);
			}
			_0024act_0024t_0024449.abNames = (string[])Builtins.array(typeof(string), list);
			Array.Sort(_0024act_0024t_0024449.abNames, (string a, string b) => string.Compare(a, b));
			_0024act_0024t_0024449.abLoaded = new bool[_0024act_0024t_0024449.abNames.Length];
			_0024act_0024t_0024449.abVers = new int[_0024act_0024t_0024449.abNames.Length];
			int num = 0;
			int length = _0024act_0024t_0024449.abNames.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				string[] abNames = _0024act_0024t_0024449.abNames;
				string bundleName = abNames[RuntimeServices.NormalizeArrayIndex(abNames, index)];
				string text = AssetBundleLoader.BundleURL(bundleName);
				int assetBundleVersion = DownloadUtil.GetAssetBundleVersion(resourceHash, text);
				bool[] abLoaded = _0024act_0024t_0024449.abLoaded;
				ref bool reference = ref abLoaded[RuntimeServices.NormalizeArrayIndex(abLoaded, index)];
				reference = Caching.IsVersionCached(text, assetBundleVersion);
				int[] abVers = _0024act_0024t_0024449.abVers;
				abVers[RuntimeServices.NormalizeArrayIndex(abVers, index)] = assetBundleVersion;
			}
		}
		else
		{
			_0024act_0024t_0024449.abNames = new string[0];
			_0024act_0024t_0024449.abLoaded = new bool[0];
			_0024act_0024t_0024449.abVers = new int[0];
		}
	}

	internal int _0024_0024createDataDownloadDataMode_0024closure_00243424_0024closure_00243425(string a, string b)
	{
		return string.Compare(a, b);
	}

	internal void _0024createDataDownloadDataMode_0024closure_00243426(ActionClassDownloadDataMode _0024act_0024t_0024449)
	{
		RuntimeDebugModeGuiMixin.label("データダウンロード状況");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("バージョン情報");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Client: ").Append(CurrentInfo.ClientVersion).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Data:   ").Append(CurrentInfo.DataVersion).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Master: ").Append(CurrentInfo.MasterVersion).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("RsrcSaved: ").Append(_0024act_0024t_0024449.rsrcSaved).ToString());
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("アセットバンドルリスト");
		Hashtable resourceHash = DownloadMain.ResourceHash;
		if (resourceHash == null)
		{
			RuntimeDebugModeGuiMixin.label("resourceHashがロードできていない");
			return;
		}
		RuntimeDebugModeGuiMixin.label(new StringBuilder("resourceHash: エントリ数 ").Append((object)((ICollection)resourceHash).Count).ToString());
		int num = 0;
		int length = _0024act_0024t_0024449.abNames.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			string[] abNames = _0024act_0024t_0024449.abNames;
			string text = abNames[RuntimeServices.NormalizeArrayIndex(abNames, index)];
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = AssetBundleLoader.BundleURL(text);
				StringBuilder stringBuilder = new StringBuilder().Append(text).Append(" - ver:");
				int[] abVers = _0024act_0024t_0024449.abVers;
				StringBuilder stringBuilder2 = stringBuilder.Append((object)abVers[RuntimeServices.NormalizeArrayIndex(abVers, index)]).Append(" cached:");
				bool[] abLoaded = _0024act_0024t_0024449.abLoaded;
				RuntimeDebugModeGuiMixin.slabel(stringBuilder2.Append(abLoaded[RuntimeServices.NormalizeArrayIndex(abLoaded, index)]).ToString());
			}
		}
	}

	internal void _0024createDataDownloadDataMode_0024closure_00243427(ActionClassDownloadDataMode _0024act_0024t_0024449)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataIconAtlasMode_0024closure_00243428(ActionClassIconAtlasMode _0024act_0024t_0024452)
	{
		RuntimeDebugModeGuiMixin.label("アイコンatlas");
		RuntimeDebugModeGuiMixin.slabel("武器/魔ペット: " + IconAtlasPool.Instance.IsWeaponPoppetLoaded);
		RuntimeDebugModeGuiMixin.slabel("スキル: " + IconAtlasPool.Instance.IsSkillLoaded);
		RuntimeDebugModeGuiMixin.slabel("DB load: " + IconAtlasPool.IsLoading);
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("武器/魔ペット/スキルアイコン廃棄"))
		{
			IconAtlasPool.UnloadAll();
		}
		RuntimeDebugModeGuiMixin.space(20);
		Boo.Lang.List<IconAtlasPool.Req> requests = IconAtlasPool.Instance.Requests;
		RuntimeDebugModeGuiMixin.label(new StringBuilder("Sprite requests: ").Append((object)((ICollection)requests).Count).ToString());
		IEnumerator<IconAtlasPool.Req> enumerator = requests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				IconAtlasPool.Req current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(current).ToString());
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("IconAtlasPool:");
		int i = 0;
		IconAtlasPool.Atlas[] allAtlasData = IconAtlasPool.AllAtlasData;
		for (int length = allAtlasData.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(allAtlasData[i].Name).Append(": ").Append(allAtlasData[i].Mode)
				.Append(" loadReq:")
				.Append(allAtlasData[i].LoadReq)
				.ToString());
		}
	}

	internal void _0024createDataIconAtlasMode_0024closure_00243429(ActionClassIconAtlasMode _0024act_0024t_0024452)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataAssetBundleRequestViewMode_0024closure_00243430(ActionClassAssetBundleRequestViewMode _0024act_0024t_0024455)
	{
		RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
		RuntimeDebugModeGuiMixin.label("RuntimeAssetBundle");
		RuntimeDebugModeGuiMixin.slabel("  processed req num: " + instance.TotalProcessedReqNum);
		RuntimeDebugModeGuiMixin.slabel("  error req num: " + instance.ErrorReqNum);
		RuntimeDebugModeGuiMixin.slabel("  waiting counter: " + instance.WaitingCounter);
		RuntimeDebugModeGuiMixin.slabel("  current processing req num: " + instance.CurNumOfProcessReqs);
		RuntimeDebugModeGuiMixin.space(20);
		Boo.Lang.List<RuntimeAssetBundleDB.Req> currentProcessingReqs = RuntimeAssetBundleDB.Instance.CurrentProcessingReqs;
		RuntimeDebugModeGuiMixin.label("current processings: " + currentProcessingReqs.Count);
		IEnumerator<RuntimeAssetBundleDB.Req> enumerator = currentProcessingReqs.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RuntimeAssetBundleDB.Req current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel("   " + current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		RuntimeDebugModeGuiMixin.space(20);
		Queue<RuntimeAssetBundleDB.Req> workingQueue = RuntimeAssetBundleDB.Instance.WorkingQueue;
		RuntimeDebugModeGuiMixin.label("requests: " + workingQueue.Count);
		foreach (RuntimeAssetBundleDB.Req item in workingQueue)
		{
			RuntimeDebugModeGuiMixin.slabel("   " + item);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("AssetBundleLoader:");
		Dictionary<string, AssetBundleLoader.Entry> bundles = AssetBundleLoader.Instance.Bundles;
		foreach (string key in bundles.Keys)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(key).Append(": ").Append(bundles[key])
				.ToString());
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("waiting queueu:");
		foreach (AssetBundleLoader.Entry item2 in AssetBundleLoader.Instance.WaitingQueue)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(item2).ToString());
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("loading queueu:");
		foreach (AssetBundleLoader.Entry loading in AssetBundleLoader.Instance.Loadings)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("   ").Append(loading).ToString());
		}
	}

	internal void _0024createDataAssetBundleRequestViewMode_0024closure_00243431(ActionClassAssetBundleRequestViewMode _0024act_0024t_0024455)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataAllAtlasViewMode_0024closure_00243432(ActionClassAllAtlasViewMode _0024act_0024t_0024458)
	{
		RuntimeDebugModeGuiMixin.label("All Awaked ATLASES: N=" + UIAtlas.AllAtlases.Count);
		foreach (UIAtlas allAtlase in UIAtlas.AllAtlases)
		{
			if (!(allAtlase == null))
			{
				int num = allAtlase.spriteList?.Count ?? 0;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(allAtlase.name).Append(" - mat:").Append(materialInfo(allAtlase.spriteMaterial))
					.Append(" nspr:")
					.Append((object)num)
					.ToString());
			}
		}
	}

	internal void _0024createDataAllAtlasViewMode_0024closure_00243433(ActionClassAllAtlasViewMode _0024act_0024t_0024458)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatafontStatusView_0024closure_00243434(ActionClassfontStatusView _0024act_0024t_0024461)
	{
		RuntimeDebugModeGuiMixin.label("font情報(参考値)");
		Hashtable fontHash = UIDynamicFontLabel.FontHash;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("num:").Append((object)((ICollection)fontHash).Count).ToString());
		IEnumerator enumerator = fontHash.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Font))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Font));
			}
			Font font = (Font)obj;
			if (font == null)
			{
				continue;
			}
			Material material = font.material;
			if (material == null)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": no material for ").Append(font)
					.ToString());
				continue;
			}
			Texture mainTexture = material.mainTexture;
			if (mainTexture != null)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": wh=").Append((object)mainTexture.width)
					.Append(" x ")
					.Append((object)mainTexture.height)
					.ToString());
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(font.name).Append(": no texture for material ").Append(material)
					.ToString());
			}
		}
	}

	internal void _0024createDatafontStatusView_0024closure_00243435(ActionClassfontStatusView _0024act_0024t_0024461)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatadontDestroyView_0024closure_00243436(ActionClassdontDestroyView _0024act_0024t_0024464)
	{
		RuntimeDebugModeGuiMixin.label("SceneDontDestroyObject:");
		Hashtable dontDestroyList = SceneDontDestroyObject.DontDestroyList;
		IEnumerator enumerator = dontDestroyList.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(current).Append(": ").Append(dontDestroyList[current])
				.ToString());
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.label("NonQuestDontDestroyObjects:");
		Dictionary<int, UnityEngine.Object> registrations = NonQuestDontDestroyObjects.Registrations;
		foreach (int key in registrations.Keys)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append((object)key).Append(": ").Append(registrations[key])
				.ToString());
		}
	}

	internal void _0024createDatadontDestroyView_0024closure_00243437(ActionClassdontDestroyView _0024act_0024t_0024464)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatamiscInfoView_0024closure_00243438(ActionClassmiscInfoView _0024act_0024t_0024467)
	{
		RuntimeDebugModeGuiMixin.label("Misc Info View");
		RuntimeDebugModeGuiMixin.slabel("ClientMasterArchive.IsReadingMasterArchive:" + ClientMasterArchive.IsReadingMasterArchive());
		RuntimeDebugModeGuiMixin.label("MStories:");
		int i = 0;
		MStories[] all = MStories.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(all[i]).ToString());
		}
		RuntimeDebugModeGuiMixin.label("QuestAssets/PlayerAssets");
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("QuestAssets: Exists:").Append(QuestAssets.Exists).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("PlayerAssets: Exists:").Append(PlayerAssets.Exists).ToString());
	}

	internal void _0024createDatamiscInfoView_0024closure_00243439(ActionClassmiscInfoView _0024act_0024t_0024467)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataViewMasters_0024closure_00243440(ActionClassViewMasters _0024act_0024t_0024470)
	{
		RuntimeDebugModeGuiMixin.label("ClientMasterArchive:");
		RuntimeDebugModeGuiMixin.slabel("HasCache:" + ClientMasterArchive.HasCache);
		RuntimeDebugModeGuiMixin.slabel("IsReadingMasterArchive:" + ClientMasterArchive.IsReadingMasterArchive());
		RuntimeDebugModeGuiMixin.slabel("LoadingMasterInfo:" + ClientMasterArchive.LoadingMasterInfo);
		RuntimeDebugModeGuiMixin.slabel("ReadMasterArchiveCacheASyncCount:" + ClientMasterArchive.ReadMasterArchiveCacheASyncCount);
		RuntimeDebugModeGuiMixin.slabel("ReadMasterArchiveCacheASyncEndCount:" + ClientMasterArchive.ReadMasterArchiveCacheASyncEndCount);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("ClientMasterArchive load info");
		Dictionary<string, string> lastLoadedMasterInfo = ClientMasterArchive.LastLoadedMasterInfo;
		foreach (string key in lastLoadedMasterInfo.Keys)
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(key).Append(": ").ToString() + lastLoadedMasterInfo[key]);
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("MerlinMaster.LoadedMasters:");
		IEnumerator enumerator2 = MerlinMaster.DebugLoadedMasters.Keys.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			object current2 = enumerator2.Current;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(current2).ToString());
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("ClientMasterArchive: prepared");
		IEnumerator<string> enumerator3 = ClientMasterArchive.PreparedMasters.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				string current3 = enumerator3.Current;
				RuntimeDebugModeGuiMixin.slabel(current3);
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
	}

	internal void _0024createDataViewMasters_0024closure_00243441(ActionClassViewMasters _0024act_0024t_0024470)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataViewCommunications_0024closure_00243442(ActionClassViewCommunications _0024act_0024t_0024473)
	{
		RuntimeDebugModeGuiMixin.label("通信状況");
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Working Requets:");
		IEnumerator<RequestBase> enumerator = MerlinServer.Instance.WorkingReqs.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RequestBase current = enumerator.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current.shortDescription()).ToString());
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Queued Requets:");
		IEnumerator<RequestBase> enumerator2 = MerlinServer.Instance.QueuedReqs.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				RequestBase current2 = enumerator2.Current;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(current2.shortDescription()).ToString());
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	internal void _0024createDataViewCommunications_0024closure_00243443(ActionClassViewCommunications _0024act_0024t_0024473)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatapyxisTest_0024closure_00243444(ActionClasspyxisTest _0024act_0024t_0024476)
	{
		RuntimeDebugModeGuiMixin.label("エセなpyxisテスト");
		if (RuntimeDebugModeGuiMixin.button("100円石買ったよ通知"))
		{
			PyxisBridge.SendPaymentInfoToFuckPyxisService(100.0, 1);
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("500円石買ったよ通知"))
		{
			PyxisBridge.SendPaymentInfoToFuckPyxisService(500.0, 1);
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("1000円石買ったよ通知"))
		{
			PyxisBridge.SendPaymentInfoToFuckPyxisService(1000.0, 1);
		}
		RuntimeDebugModeGuiMixin.space(20);
		if (RuntimeDebugModeGuiMixin.button("チュートリアルクリアしたよ通知"))
		{
			PyxisBridge.SendTutorialFinishingToFuckPyxisService();
		}
	}

	internal void _0024createDatapyxisTest_0024closure_00243445(ActionClasspyxisTest _0024act_0024t_0024476)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataprofilerView_0024closure_00243446(ActionClassprofilerView _0024act_0024t_0024479)
	{
		_0024act_0024t_0024479.objLists = new Boo.Lang.List<UnityEngine.Object[]>();
		_0024act_0024t_0024479.sizLists = new Boo.Lang.List<int[]>();
		int i = 0;
		Type[] pROFILER_VIEW_TYPES = PROFILER_VIEW_TYPES;
		for (int length = pROFILER_VIEW_TYPES.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(pROFILER_VIEW_TYPES[i]);
			sortProfileObjs(array);
			int[] array2 = new int[array.Length];
			int num = 0;
			int length2 = array.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length2)
			{
				int index = num;
				num++;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = Profiler.GetRuntimeMemorySize(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			}
			_0024act_0024t_0024479.objLists.Add(array);
			_0024act_0024t_0024479.sizLists.Add(array2);
		}
		_0024act_0024t_0024479.currentIndex = 0;
		_0024act_0024t_0024479.selection = new string[PROFILER_VIEW_TYPES.Length];
		int num2 = 0;
		int length3 = PROFILER_VIEW_TYPES.Length;
		if (length3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length3)
		{
			int index2 = num2;
			num2++;
			string[] selection = _0024act_0024t_0024479.selection;
			int num3 = RuntimeServices.NormalizeArrayIndex(selection, index2);
			Type[] pROFILER_VIEW_TYPES2 = PROFILER_VIEW_TYPES;
			selection[num3] = pROFILER_VIEW_TYPES2[RuntimeServices.NormalizeArrayIndex(pROFILER_VIEW_TYPES2, index2)].Name;
		}
	}

	internal void _0024createDataprofilerView_0024closure_00243447(ActionClassprofilerView _0024act_0024t_0024479)
	{
		_0024act_0024t_0024479.mode = 0;
		_0024act_0024t_0024479.pagetop = 0;
		_0024act_0024t_0024479.objLists = null;
		_0024act_0024t_0024479.sizLists = null;
		_0024act_0024t_0024479.currentIndex = 0;
		_0024act_0024t_0024479.selection = null;
	}

	internal void _0024createDataprofilerView_0024closure_00243448(ActionClassprofilerView _0024act_0024t_0024479)
	{
		_0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299 _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024 = new _0024_0024createDataprofilerView_0024closure_00243448_0024locals_002414299();
		_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479 = _0024act_0024t_0024479;
		if (RuntimeDebugModeGuiMixin.button("unload unsed assets"))
		{
			UnloadResource.UnloadUnusedAssets();
		}
		RuntimeDebugModeGuiMixin.space(20);
		int num = RuntimeDebugModeGuiMixin.grid(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex, _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.selection, 3);
		if (num != _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex)
		{
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex = num;
			_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop = 0;
		}
		_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.objLists[_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex];
		_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curSize = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.sizLists[_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex];
		_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024pageLines = 100;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024_0024createDataprofilerView_0024closure_00243448_0024prevNext_00243449(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024).Invoke;
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
		StringBuilder stringBuilder = new StringBuilder();
		Type[] pROFILER_VIEW_TYPES = PROFILER_VIEW_TYPES;
		RuntimeDebugModeGuiMixin.label(stringBuilder.Append(pROFILER_VIEW_TYPES[RuntimeServices.NormalizeArrayIndex(pROFILER_VIEW_TYPES, _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.currentIndex)]).Append(": ").Append((object)_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop)
			.Append("/")
			.Append((object)_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData.Length)
			.ToString());
		int num2 = _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop;
		int num3 = Math.Min(checked(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024_0024act_0024t_0024479.pagetop + 50), _0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024._0024curData.Length);
		int num4 = 1;
		if (num3 < num2)
		{
			num4 = -1;
		}
		while (num2 != num3)
		{
			int _0024i_0024 = num2;
			num2 += num4;
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataprofilerView_0024closure_00243448_0024closure_00243451(_0024_0024createDataprofilerView_0024closure_00243448_0024locals_0024, _0024i_0024).Invoke));
		}
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
	}

	internal void _0024createDataprofilerView_0024closure_00243452(ActionClassprofilerView _0024act_0024t_0024479)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal static int _0024sortProfileObjs_0024closure_00243453(UnityEngine.Object o1, UnityEngine.Object o2)
	{
		return string.Compare(objectName(o1), objectName(o2));
	}
}
