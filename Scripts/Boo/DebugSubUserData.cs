using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubUserData : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024561;

		public string _0024act_0024t_0024562;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024563;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024564;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024565;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024566;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024567;

		public __ActionBase__0024act_0024t_0024563_0024callable33_0024179_5__ _0024act_0024t_0024568;

		public __ActionBase__0024act_0024t_0024569_0024callable34_0024179_5__ _0024act_0024t_0024569;

		public IEnumerator _0024act_0024t_0024573;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024561.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassMainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassWeaponBoxMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassPoppetBoxMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassDeckMode : ActionBase
	{
		public int curDeckIdx;

		public int curPoppetDeckIdx;
	}

	[Serializable]
	public class ActionClassFlagMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassEtcFlagMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassCurrentUserDataMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassDiaryMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassCreatedUserHistoryMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassSaveUserDataMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassLoadUserDataMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassChangeUUIDMode : ActionBase
	{
		public string newUUID;
	}

	[Serializable]
	public class ActionClasssetTutorialCleared : ActionBase
	{
		public ApiUpdateTutorial r1;

		public ApiUpdateTutorial r2;
	}

	[Serializable]
	public class ActionClassuserDataUpDownLoadTest : ActionBase
	{
	}

	[Serializable]
	public class ActionClassuserDataUpload : ActionBase
	{
		public ApiLocalDataUpload req;
	}

	[Serializable]
	public class ActionClassuserDataLoadMain : ActionBase
	{
		public string f;

		public string resultText;
	}

	[Serializable]
	public class ActionClassuserDataLoadMain2 : ActionBase
	{
		public string f;

		public string resultText;
	}

	[Serializable]
	public class ActionClassfileSelectMode : ActionBase
	{
		public string dir;

		public string ptn;

		public __Req_FailHandler_0024callable6_0024440_32__ select;

		public ICallable back;

		public string[] files;

		public string baseDir;
	}

	[Serializable]
	public class ActionClassquestMissionViewMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClasscolloseumEventViewMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassquestTicketViewMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClassplayByThisTicket : ActionBase
	{
		public RespQuestTicket t;

		public Boo.Lang.List<MQuests> quests;
	}

	[Serializable]
	public class ActionClassuseTicketMode : ActionBase
	{
		public int ticketId;

		public ApiQuestUseTicket req;
	}

	[Serializable]
	public enum ActionEnum
	{
		useTicketMode,
		playByThisTicket,
		questTicketViewMode,
		colloseumEventViewMode,
		questMissionViewMode,
		fileSelectMode,
		userDataLoadMain2,
		userDataLoadMain,
		userDataUpload,
		userDataUpDownLoadTest,
		setTutorialCleared,
		ChangeUUIDMode,
		LoadUserDataMode,
		SaveUserDataMode,
		CreatedUserHistoryMode,
		DiaryMode,
		CurrentUserDataMode,
		EtcFlagMode,
		FlagMode,
		DeckMode,
		PoppetBoxMode,
		WeaponBoxMode,
		MainMode,
		NUM,
		_noaction_
	}

	[Serializable]
	internal class _0024snamevaluetoggle_0024locals_002414310
	{
		internal GUILayoutOption[] _0024targs;

		internal GUILayoutOption[] _0024hargs;

		internal string _0024title;

		internal bool _0024value;

		internal ICallable _0024func;

		internal GUILayoutOption[] _0024args;
	}

	[Serializable]
	internal class _0024applyFilterToFlags_0024locals_002414311
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024applyFilterToFlags_0024locals_002414312
	{
		internal Regex _0024r;
	}

	[Serializable]
	internal class _0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313
	{
		internal UserData _0024ud;
	}

	[Serializable]
	internal class _0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314
	{
		internal UserMiscInfo.FlagData _0024flagData;
	}

	[Serializable]
	internal class _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315
	{
		internal UserMiscInfo.FlagData _0024storyData;
	}

	[Serializable]
	internal class _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316
	{
		internal UserMiscInfo.FlagData _0024flagData;

		internal UserMiscInfo.FlagData _0024storyData;
	}

	[Serializable]
	internal class _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317
	{
		internal ActionClassChangeUUIDMode _0024_0024act_0024t_0024606;
	}

	[Serializable]
	internal class _0024snamevaluetoggle_0024closure_00242804
	{
		internal _0024snamevaluetoggle_0024locals_002414310 _0024_0024locals_002414723;

		public _0024snamevaluetoggle_0024closure_00242804(_0024snamevaluetoggle_0024locals_002414310 _0024_0024locals_002414723)
		{
			this._0024_0024locals_002414723 = _0024_0024locals_002414723;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.toggle(ref _0024_0024locals_002414723._0024value, _0024_0024locals_002414723._0024title, _0024_0024locals_002414723._0024hargs);
			RuntimeDebugModeGuiMixin.slabel(_0024_0024locals_002414723._0024title + ": ", _0024_0024locals_002414723._0024targs);
			RuntimeDebugModeGuiMixin.slabel(_0024_0024locals_002414723._0024value.ToString(), _0024_0024locals_002414723._0024args);
			if (RuntimeDebugModeGuiMixin.sbutton("フラグ設定", _0024_0024locals_002414723._0024args))
			{
				_0024_0024locals_002414723._0024func.Call(new object[2] { _0024_0024locals_002414723._0024title, true });
			}
			if (RuntimeDebugModeGuiMixin.sbutton("フラグ削除", _0024_0024locals_002414723._0024args))
			{
				_0024_0024locals_002414723._0024func.Call(new object[2] { _0024_0024locals_002414723._0024title, false });
			}
		}
	}

	[Serializable]
	internal class _0024applyFilterToFlags_0024closure_00242805
	{
		internal _0024applyFilterToFlags_0024locals_002414311 _0024_0024locals_002414724;

		public _0024applyFilterToFlags_0024closure_00242805(_0024applyFilterToFlags_0024locals_002414311 _0024_0024locals_002414724)
		{
			this._0024_0024locals_002414724 = _0024_0024locals_002414724;
		}

		public bool Invoke(MFlags x)
		{
			return _0024_0024locals_002414724._0024r.Match(x.Progname).Success;
		}
	}

	[Serializable]
	internal class _0024applyFilterToFlags_0024closure_00242806
	{
		internal _0024applyFilterToFlags_0024locals_002414312 _0024_0024locals_002414725;

		public _0024applyFilterToFlags_0024closure_00242806(_0024applyFilterToFlags_0024locals_002414312 _0024_0024locals_002414725)
		{
			this._0024_0024locals_002414725 = _0024_0024locals_002414725;
		}

		public bool Invoke(MFlags x)
		{
			return _0024_0024locals_002414725._0024r.Match(x.Progname).Success;
		}
	}

	[Serializable]
	internal class _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242809
	{
		internal _0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024locals_002414726;

		internal DebugSubUserData _0024this_002414727;

		public _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242809(_0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024locals_002414726, DebugSubUserData _0024this_002414727)
		{
			this._0024_0024locals_002414726 = _0024_0024locals_002414726;
			this._0024this_002414727 = _0024this_002414727;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("weapon box"))
			{
				_0024this_002414727.WeaponBoxMode();
			}
			if (RuntimeDebugModeGuiMixin.button("poppet box"))
			{
				_0024this_002414727.PoppetBoxMode();
			}
			if (_0024_0024locals_002414726._0024ud.IsValidDeck2)
			{
				if (RuntimeDebugModeGuiMixin.button("NEW DECK"))
				{
					_0024this_002414727.DeckMode();
				}
			}
			else if (RuntimeDebugModeGuiMixin.button("OLD DECK"))
			{
				_0024this_002414727.DeckMode();
			}
			if (RuntimeDebugModeGuiMixin.button("flags"))
			{
				detail = false;
				_0024this_002414727.FlagMode();
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242813
	{
		internal _0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024locals_002414728;

		public _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242813(_0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024locals_002414728)
		{
			this._0024_0024locals_002414728 = _0024_0024locals_002414728;
		}

		public void Invoke(ApiHome req)
		{
			StorageHUD.DoUpdateNow();
			RespPlayerLogin[] playerLogin = req.GetResponse().PlayerLogin;
			if (playerLogin != null)
			{
				RespPlayerLogin[] array = playerLogin;
				int length = array.Length;
				int num = 0;
				while (num < length)
				{
					RespPlayerLogin respPlayerLogin = array[RuntimeServices.NormalizeArrayIndex(array, checked(num++))];
					respPlayerLogin.IsLoginBonus = true;
				}
				_0024_0024locals_002414728._0024ud.setLoginBonus(playerLogin);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242826
	{
		internal _0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314 _0024_0024locals_002414729;

		public _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242826(_0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314 _0024_0024locals_002414729)
		{
			this._0024_0024locals_002414729 = _0024_0024locals_002414729;
		}

		public void Invoke(string k, bool v)
		{
			if (v)
			{
				_0024_0024locals_002414729._0024flagData.set(k, 1);
			}
			if (!v)
			{
				_0024_0024locals_002414729._0024flagData.delete(k);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataEtcFlagMode_0024closure_00242830_0024closure_00242831
	{
		internal _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315 _0024_0024locals_002414730;

		public _0024_0024createDataEtcFlagMode_0024closure_00242830_0024closure_00242831(_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315 _0024_0024locals_002414730)
		{
			this._0024_0024locals_002414730 = _0024_0024locals_002414730;
		}

		public void Invoke(string k, bool v)
		{
			if (v)
			{
				_0024_0024locals_002414730._0024storyData.set(k, 1);
			}
			if (!v)
			{
				_0024_0024locals_002414730._0024storyData.delete(k);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242836
	{
		internal _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024locals_002414731;

		public _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242836(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024locals_002414731)
		{
			this._0024_0024locals_002414731 = _0024_0024locals_002414731;
		}

		public void Invoke(string k, bool v)
		{
			if (v)
			{
				_0024_0024locals_002414731._0024flagData.set(k, 1);
			}
			if (!v)
			{
				_0024_0024locals_002414731._0024flagData.delete(k);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242837
	{
		internal _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024locals_002414732;

		public _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242837(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024locals_002414732)
		{
			this._0024_0024locals_002414732 = _0024_0024locals_002414732;
		}

		public void Invoke(string k, bool v)
		{
			if (v)
			{
				_0024_0024locals_002414732._0024storyData.set(k, 1);
			}
			if (!v)
			{
				_0024_0024locals_002414732._0024storyData.delete(k);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849
	{
		internal _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317 _0024_0024locals_002414733;

		internal DebugSubUserData _0024this_002414734;

		public _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849(_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317 _0024_0024locals_002414733, DebugSubUserData _0024this_002414734)
		{
			this._0024_0024locals_002414733 = _0024_0024locals_002414733;
			this._0024this_002414734 = _0024this_002414734;
		}

		public void Invoke()
		{
			ClearData.ClearAllWithoutDownloadedData();
			CurrentInfo.UUID = _0024_0024locals_002414733._0024_0024act_0024t_0024606.newUUID;
			CurrentInfo.AlreadyCreatedCharacter = true;
			MerlinServer.ExRequest(new ApiHome(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				StorageHUD.DoUpdateNow();
			}));
			MerlinServer.ExRequest(new ApiLocalDataDownload(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				_0024this_002414734.CreatedUserHistoryMode();
			}));
		}
	}

	[Serializable]
	internal class _0024_0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959_0024closure_00243960
	{
		internal RespQuestTicket[] _0024_00247356_002414735;

		internal int _0024_00247355_002414736;

		internal DebugSubUserData _0024this_002414737;

		public _0024_0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959_0024closure_00243960(RespQuestTicket[] _0024_00247356_002414735, int _0024_00247355_002414736, DebugSubUserData _0024this_002414737)
		{
			this._0024_00247356_002414735 = _0024_00247356_002414735;
			this._0024_00247355_002414736 = _0024_00247355_002414736;
			this._0024this_002414737 = _0024this_002414737;
		}

		public void Invoke()
		{
			if (RuntimeDebugModeGuiMixin.button("このチケット使う"))
			{
				_0024this_002414737.useTicketMode(_0024_00247356_002414735[_0024_00247355_002414736].Id);
			}
			if (RuntimeDebugModeGuiMixin.button("クエストプレイ"))
			{
				_0024this_002414737.playByThisTicket(_0024_00247356_002414735[_0024_00247355_002414736]);
			}
		}
	}

	[Serializable]
	internal class _0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959
	{
		internal RespQuestTicket[] _0024_00247356_002414738;

		internal int _0024_00247355_002414739;

		internal DebugSubUserData _0024this_002414740;

		public _0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959(RespQuestTicket[] _0024_00247356_002414738, int _0024_00247355_002414739, DebugSubUserData _0024this_002414740)
		{
			this._0024_00247356_002414738 = _0024_00247356_002414738;
			this._0024_00247355_002414739 = _0024_00247355_002414739;
			this._0024this_002414740 = _0024this_002414740;
		}

		public void Invoke(RespQuestTicket _t)
		{
			RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959_0024closure_00243960(_0024_00247356_002414738, _0024_00247355_002414739, _0024this_002414740).Invoke));
		}
	}

	[NonSerialized]
	protected static List flags = getAllFlags();

	[NonSerialized]
	protected static string[][] flag_toggle_label = new string[25][]
	{
		new string[2] { "全", ".*" },
		new string[2] { "01話", "(([sS]|Story|Main)01[^0-9]|([sS]|Story|Main)001)" },
		new string[2] { "02話", "(([sS]|Story|Main)02[^0-9]|([sS]|Story|Main)002)" },
		new string[2] { "03話", "(([sS]|Story|Main)03[^0-9]|([sS]|Story|Main)003)" },
		new string[2] { "04話", "(([sS]|Story|Main)04[^0-9]|([sS]|Story|Main)004)" },
		new string[2] { "05話", "(([sS]|Story|Main)05[^0-9]|([sS]|Story|Main)005)" },
		new string[2] { "06話", "(([sS]|Story|Main)06[^0-9]|([sS]|Story|Main)006)" },
		new string[2] { "07話", "(([sS]|Story|Main)07[^0-9]|([sS]|Story|Main)007)" },
		new string[2] { "08話", "(([sS]|Story|Main)08[^0-9]|([sS]|Story|Main)008)" },
		new string[2] { "09話", "(([sS]|Story|Main)09[^0-9]|([sS]|Story|Main)009)" },
		new string[2] { "10話", "(([sS]|Story|Main)10[^0-9]|([sS]|Story|Main)010)" },
		new string[2] { "11話", "(([sS]|Story|Main)11[^0-9]|([sS]|Story|Main)011)" },
		new string[2] { "12話", "(([sS]|Story|Main)12[^0-9]|([sS]|Story|Main)012)" },
		new string[2] { "13話", "(([sS]|Story|Main)13[^0-9]|([sS]|Story|Main)013)" },
		new string[2] { "14話", "(([sS]|Story|Main)14[^0-9]|([sS]|Story|Main)014)" },
		new string[2] { "15話", "(([sS]|Story|Main)15[^0-9]|([sS]|Story|Main)015)" },
		new string[2] { "16話", "(([sS]|Story|Main)16[^0-9]|([sS]|Story|Main)016)" },
		new string[2] { "17話", "(([sS]|Story|Main)17[^0-9]|([sS]|Story|Main)017)" },
		new string[2] { "18話", "(([sS]|Story|Main)18[^0-9]|([sS]|Story|Main)018)" },
		new string[2] { "19話", "(([sS]|Story|Main)19[^0-9]|([sS]|Story|Main)019)" },
		new string[2] { "20話", "(([sS]|Story|Main)20[^0-9]|([sS]|Story|Main)020)" },
		new string[2] { "Q", "^[qQ].*" },
		new string[2] { "T", "^[tT].*" },
		new string[2] { "X", "^[xX].*" },
		new string[2] { "V", "^[vV].*" }
	};

	[NonSerialized]
	public static string currentFlagFilter = string.Empty;

	[NonSerialized]
	protected static string[][] flag_filter_label = new string[6][]
	{
		new string[2]
		{
			"全",
			string.Empty
		},
		new string[2] { "S", "^[sS]" },
		new string[2] { "Q", "^[qQ].*" },
		new string[2] { "T", "^[tT].*" },
		new string[2] { "X", "^[xX].*" },
		new string[2] { "V", "^[vV].*" }
	};

	[NonSerialized]
	public static string currentStoryFilter = string.Empty;

	[NonSerialized]
	protected static string[][] story_filter_label = new string[35][]
	{
		new string[2]
		{
			"全",
			string.Empty
		},
		new string[2] { "S01-09", "(([sS]|Story|Main)0[0-9][^0-9]|([sS]|Story|Main)00[0-9])" },
		new string[2] { "S10-19", "(([sS]|Story|Main)1[0-9][^0-9]|([sS]|Story|Main)01[0-9])" },
		new string[2] { "S20-", "(([sS]|Story|Main)[2-9][0-9][^0-9]|([sS]|Story|Main)0[2-9][0-9])" },
		new string[2]
		{
			"dummy",
			string.Empty
		},
		new string[2] { "01話", "(([sS]|Story|Main)01[^0-9]|([sS]|Story|Main)001)" },
		new string[2] { "02話", "(([sS]|Story|Main)02[^0-9]|([sS]|Story|Main)002)" },
		new string[2] { "03話", "(([sS]|Story|Main)03[^0-9]|([sS]|Story|Main)003)" },
		new string[2] { "04話", "(([sS]|Story|Main)04[^0-9]|([sS]|Story|Main)004)" },
		new string[2] { "05話", "(([sS]|Story|Main)05[^0-9]|([sS]|Story|Main)005)" },
		new string[2] { "06話", "(([sS]|Story|Main)06[^0-9]|([sS]|Story|Main)006)" },
		new string[2] { "07話", "(([sS]|Story|Main)07[^0-9]|([sS]|Story|Main)007)" },
		new string[2] { "08話", "(([sS]|Story|Main)08[^0-9]|([sS]|Story|Main)008)" },
		new string[2] { "09話", "(([sS]|Story|Main)09[^0-9]|([sS]|Story|Main)009)" },
		new string[2] { "10話", "(([sS]|Story|Main)10[^0-9]|([sS]|Story|Main)010)" },
		new string[2] { "11話", "(([sS]|Story|Main)11[^0-9]|([sS]|Story|Main)011)" },
		new string[2] { "12話", "(([sS]|Story|Main)12[^0-9]|([sS]|Story|Main)012)" },
		new string[2] { "13話", "(([sS]|Story|Main)13[^0-9]|([sS]|Story|Main)013)" },
		new string[2] { "14話", "(([sS]|Story|Main)14[^0-9]|([sS]|Story|Main)014)" },
		new string[2] { "15話", "(([sS]|Story|Main)15[^0-9]|([sS]|Story|Main)015)" },
		new string[2] { "16話", "(([sS]|Story|Main)16[^0-9]|([sS]|Story|Main)016)" },
		new string[2] { "17話", "(([sS]|Story|Main)17[^0-9]|([sS]|Story|Main)017)" },
		new string[2] { "18話", "(([sS]|Story|Main)18[^0-9]|([sS]|Story|Main)018)" },
		new string[2] { "19話", "(([sS]|Story|Main)19[^0-9]|([sS]|Story|Main)019)" },
		new string[2] { "20話", "(([sS]|Story|Main)20[^0-9]|([sS]|Story|Main)020)" },
		new string[2] { "21話", "(([sS]|Story|Main)21[^0-9]|([sS]|Story|Main)021)" },
		new string[2] { "22話", "(([sS]|Story|Main)22[^0-9]|([sS]|Story|Main)022)" },
		new string[2] { "23話", "(([sS]|Story|Main)23[^0-9]|([sS]|Story|Main)023)" },
		new string[2] { "24話", "(([sS]|Story|Main)24[^0-9]|([sS]|Story|Main)024)" },
		new string[2] { "25話", "(([sS]|Story|Main)25[^0-9]|([sS]|Story|Main)025)" },
		new string[2] { "26話", "(([sS]|Story|Main)26[^0-9]|([sS]|Story|Main)026)" },
		new string[2] { "27話", "(([sS]|Story|Main)27[^0-9]|([sS]|Story|Main)027)" },
		new string[2] { "28話", "(([sS]|Story|Main)28[^0-9]|([sS]|Story|Main)028)" },
		new string[2] { "29話", "(([sS]|Story|Main)29[^0-9]|([sS]|Story|Main)029)" },
		new string[2] { "30話", "(([sS]|Story|Main)30[^0-9]|([sS]|Story|Main)030)" }
	};

	[NonSerialized]
	protected static string flagFilterName = "全";

	[NonSerialized]
	protected static string storyFilterName = "全";

	[NonSerialized]
	protected static bool detail;

	[NonSerialized]
	protected static bool ticketDebug;

	[NonSerialized]
	protected static string ticketIcon = string.Empty;

	[NonSerialized]
	protected static string ticketExplain = string.Empty;

	private Dictionary<string, ActionBase> _0024act_0024t_0024570;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024572;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024571;

	public bool actionDebugFlag;

	[NonSerialized]
	internal static Regex _0024re_002424718 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424719 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424720 = new Regex(" ");

	[NonSerialized]
	internal static Regex _0024re_002424721 = new Regex(" ");

	public bool IsMainMode => currActionID("$default$") == ActionEnum.MainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassMainMode MainModeData => currAction("$default$") as ActionClassMainMode;

	public bool IsWeaponBoxMode => currActionID("$default$") == ActionEnum.WeaponBoxMode;

	public ActionClassWeaponBoxMode WeaponBoxModeData => currAction("$default$") as ActionClassWeaponBoxMode;

	public bool IsPoppetBoxMode => currActionID("$default$") == ActionEnum.PoppetBoxMode;

	public ActionClassPoppetBoxMode PoppetBoxModeData => currAction("$default$") as ActionClassPoppetBoxMode;

	public bool IsDeckMode => currActionID("$default$") == ActionEnum.DeckMode;

	public ActionClassDeckMode DeckModeData => currAction("$default$") as ActionClassDeckMode;

	public bool IsFlagMode => currActionID("$default$") == ActionEnum.FlagMode;

	public ActionClassFlagMode FlagModeData => currAction("$default$") as ActionClassFlagMode;

	public bool IsEtcFlagMode => currActionID("$default$") == ActionEnum.EtcFlagMode;

	public ActionClassEtcFlagMode EtcFlagModeData => currAction("$default$") as ActionClassEtcFlagMode;

	public bool IsCurrentUserDataMode => currActionID("$default$") == ActionEnum.CurrentUserDataMode;

	public ActionClassCurrentUserDataMode CurrentUserDataModeData => currAction("$default$") as ActionClassCurrentUserDataMode;

	public bool IsDiaryMode => currActionID("$default$") == ActionEnum.DiaryMode;

	public ActionClassDiaryMode DiaryModeData => currAction("$default$") as ActionClassDiaryMode;

	public bool IsCreatedUserHistoryMode => currActionID("$default$") == ActionEnum.CreatedUserHistoryMode;

	public ActionClassCreatedUserHistoryMode CreatedUserHistoryModeData => currAction("$default$") as ActionClassCreatedUserHistoryMode;

	public bool IsSaveUserDataMode => currActionID("$default$") == ActionEnum.SaveUserDataMode;

	public ActionClassSaveUserDataMode SaveUserDataModeData => currAction("$default$") as ActionClassSaveUserDataMode;

	public bool IsLoadUserDataMode => currActionID("$default$") == ActionEnum.LoadUserDataMode;

	public ActionClassLoadUserDataMode LoadUserDataModeData => currAction("$default$") as ActionClassLoadUserDataMode;

	public bool IsChangeUUIDMode => currActionID("$default$") == ActionEnum.ChangeUUIDMode;

	public ActionClassChangeUUIDMode ChangeUUIDModeData => currAction("$default$") as ActionClassChangeUUIDMode;

	public bool IssetTutorialCleared => currActionID("$default$") == ActionEnum.setTutorialCleared;

	public ActionClasssetTutorialCleared setTutorialClearedData => currAction("$default$") as ActionClasssetTutorialCleared;

	public bool IsuserDataUpDownLoadTest => currActionID("$default$") == ActionEnum.userDataUpDownLoadTest;

	public ActionClassuserDataUpDownLoadTest userDataUpDownLoadTestData => currAction("$default$") as ActionClassuserDataUpDownLoadTest;

	public bool IsuserDataUpload => currActionID("$default$") == ActionEnum.userDataUpload;

	public ActionClassuserDataUpload userDataUploadData => currAction("$default$") as ActionClassuserDataUpload;

	public bool IsuserDataLoadMain => currActionID("$default$") == ActionEnum.userDataLoadMain;

	public ActionClassuserDataLoadMain userDataLoadMainData => currAction("$default$") as ActionClassuserDataLoadMain;

	public bool IsuserDataLoadMain2 => currActionID("$default$") == ActionEnum.userDataLoadMain2;

	public ActionClassuserDataLoadMain2 userDataLoadMain2Data => currAction("$default$") as ActionClassuserDataLoadMain2;

	public bool IsfileSelectMode => currActionID("$default$") == ActionEnum.fileSelectMode;

	public ActionClassfileSelectMode fileSelectModeData => currAction("$default$") as ActionClassfileSelectMode;

	public bool IsquestMissionViewMode => currActionID("$default$") == ActionEnum.questMissionViewMode;

	public ActionClassquestMissionViewMode questMissionViewModeData => currAction("$default$") as ActionClassquestMissionViewMode;

	public bool IscolloseumEventViewMode => currActionID("$default$") == ActionEnum.colloseumEventViewMode;

	public ActionClasscolloseumEventViewMode colloseumEventViewModeData => currAction("$default$") as ActionClasscolloseumEventViewMode;

	public bool IsquestTicketViewMode => currActionID("$default$") == ActionEnum.questTicketViewMode;

	public ActionClassquestTicketViewMode questTicketViewModeData => currAction("$default$") as ActionClassquestTicketViewMode;

	public bool IsplayByThisTicket => currActionID("$default$") == ActionEnum.playByThisTicket;

	public ActionClassplayByThisTicket playByThisTicketData => currAction("$default$") as ActionClassplayByThisTicket;

	public bool IsuseTicketMode => currActionID("$default$") == ActionEnum.useTicketMode;

	public ActionClassuseTicketMode useTicketModeData => currAction("$default$") as ActionClassuseTicketMode;

	public static bool TicketDebug => ticketDebug;

	public static string TicketIcon => ticketIcon;

	public static string TicketExplain => ticketExplain;

	public DebugSubUserData()
	{
		_0024act_0024t_0024570 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024572 = new Dictionary<string, ActionEnum>();
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

	public static void snamevaluetoggle(string title, bool value, int titleWidth, ICallable func, params GUILayoutOption[] args)
	{
		_0024snamevaluetoggle_0024locals_002414310 _0024snamevaluetoggle_0024locals_0024 = new _0024snamevaluetoggle_0024locals_002414310();
		_0024snamevaluetoggle_0024locals_0024._0024title = title;
		_0024snamevaluetoggle_0024locals_0024._0024value = value;
		_0024snamevaluetoggle_0024locals_0024._0024func = func;
		_0024snamevaluetoggle_0024locals_0024._0024args = args;
		_0024snamevaluetoggle_0024locals_0024._0024targs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024snamevaluetoggle_0024locals_0024._0024args, new GUILayoutOption[1] { RuntimeDebugModeGuiMixin.optWidth(titleWidth) });
		_0024snamevaluetoggle_0024locals_0024._0024hargs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024snamevaluetoggle_0024locals_0024._0024args, new GUILayoutOption[1] { RuntimeDebugModeGuiMixin.optWidth(125) });
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024snamevaluetoggle_0024closure_00242804(_0024snamevaluetoggle_0024locals_0024).Invoke));
	}

	public static List getAllFlags()
	{
		return ArrayMap.AllMFlagBooList();
	}

	public static void applyFilterToFlags(string f)
	{
		_0024applyFilterToFlags_0024locals_002414311 _0024applyFilterToFlags_0024locals_0024 = new _0024applyFilterToFlags_0024locals_002414311();
		List list = getAllFlags();
		int i = 0;
		string[] array = _0024re_002424718.Split(f);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024applyFilterToFlags_0024locals_0024._0024r = new Regex(array[i] + currentStoryFilter, RegexOptions.IgnoreCase);
			list = ArrayMap.FilterMFlagBooList(new _0024applyFilterToFlags_0024closure_00242805(_0024applyFilterToFlags_0024locals_0024).Invoke);
		}
		flags = ((list != null) ? list : flags);
	}

	public static void applyFilterToFlags(string flagType, string story)
	{
		_0024applyFilterToFlags_0024locals_002414312 _0024applyFilterToFlags_0024locals_0024 = new _0024applyFilterToFlags_0024locals_002414312();
		List list = getAllFlags();
		int i = 0;
		string[] array = _0024re_002424719.Split(flagType);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			_0024applyFilterToFlags_0024locals_0024._0024r = new Regex(array[i] + story, RegexOptions.IgnoreCase);
			list = ArrayMap.FilterMFlagBooList(new _0024applyFilterToFlags_0024closure_00242806(_0024applyFilterToFlags_0024locals_0024).Invoke);
		}
		flags = ((list != null) ? list : flags);
	}

	public static void bulkSetFlag(string f)
	{
		UserMiscInfo.FlagData flagData = UserData.Current.userMiscInfo.flagData;
		int i = 0;
		string[] array = _0024re_002424720.Split(f);
		checked
		{
			bool flag = default(bool);
			for (int length = array.Length; i < length; i++)
			{
				Regex regex = new Regex(array[i], RegexOptions.IgnoreCase);
				int num = 0;
				IEnumerator<object> enumerator = getAllFlags().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (!(obj is MFlags))
						{
							obj = RuntimeServices.Coerce(obj, typeof(MFlags));
						}
						MFlags mFlags = (MFlags)obj;
						if (regex.Match(mFlags.Progname).Success)
						{
							if (num == 0)
							{
								flag = flagData.getInt(mFlags.Progname) > 0;
							}
							if (!flag)
							{
								flagData.set(mFlags.Progname, 1);
							}
							if (flag)
							{
								flagData.delete(mFlags.Progname);
							}
							num++;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
		}
	}

	public static void bulkSetFlag(string f, bool b)
	{
		UserMiscInfo.FlagData flagData = UserData.Current.userMiscInfo.flagData;
		int i = 0;
		string[] array = _0024re_002424721.Split(f);
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				Regex regex = new Regex(array[i], RegexOptions.IgnoreCase);
				int num = 0;
				IEnumerator<object> enumerator = getAllFlags().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (!(obj is MFlags))
						{
							obj = RuntimeServices.Coerce(obj, typeof(MFlags));
						}
						MFlags mFlags = (MFlags)obj;
						if (regex.Match(mFlags.Progname).Success)
						{
							if (b)
							{
								flagData.set(mFlags.Progname, 1);
							}
							if (!b)
							{
								flagData.delete(mFlags.Progname);
							}
							num++;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
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
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024570.ContainsKey(grp)) ? null : _0024act_0024t_0024570[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024572.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024572[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024570.ContainsKey(grp)) ? 0f : _0024act_0024t_0024570[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024570.ContainsKey(grp)) ? 0f : _0024act_0024t_0024570[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024570.ContainsKey(grp)) ? 0f : _0024act_0024t_0024570[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024572.Values)
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
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024562) && _0024act_0024t_0024570.ContainsKey(act._0024act_0024t_0024562) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024570[act._0024act_0024t_0024562]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.useTicketMode <= aid;
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
			if (string.IsNullOrEmpty(act._0024act_0024t_0024562))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$562)");
			}
			_0024act_0024t_0024570[act._0024act_0024t_0024562] = act;
			_0024act_0024t_0024572[act._0024act_0024t_0024562] = act._0024act_0024t_0024561;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024571) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024562);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024562)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024562)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024564 != null)
		{
			actionBase._0024act_0024t_0024564(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024563 != null)
			{
				act._0024act_0024t_0024563(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024569 != null)
			{
				act._0024act_0024t_0024573 = act._0024act_0024t_0024569(act);
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
		foreach (ActionBase value in _0024act_0024t_0024570.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024571 = 0;
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
			if (actionBase._0024act_0024t_0024565 != null)
			{
				actionBase._0024act_0024t_0024565(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024573 != null && !actionBase._0024act_0024t_0024573.MoveNext())
			{
				actionBase._0024act_0024t_0024573 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024570.Values)
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
		_0024act_0024t_0024571 = 0;
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
			if (actionBase._0024act_0024t_0024566 != null)
			{
				actionBase._0024act_0024t_0024566(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024571 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024570.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024570[array2[i]];
				if (actionBase._0024act_0024t_0024567 != null)
				{
					actionBase._0024act_0024t_0024567(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024570.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024562 + " - " + value._0024act_0024t_0024561 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024571 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024570.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024570[array2[i]];
			if (actionBase._0024act_0024t_0024568 != null)
			{
				actionBase._0024act_0024t_0024568(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubUserData" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.MainMode => createDataMainMode(), 
			ActionEnum.WeaponBoxMode => createDataWeaponBoxMode(), 
			ActionEnum.PoppetBoxMode => createDataPoppetBoxMode(), 
			ActionEnum.DeckMode => createDataDeckMode(), 
			ActionEnum.FlagMode => createDataFlagMode(), 
			ActionEnum.EtcFlagMode => createDataEtcFlagMode(), 
			ActionEnum.CurrentUserDataMode => createDataCurrentUserDataMode(), 
			ActionEnum.DiaryMode => createDataDiaryMode(), 
			ActionEnum.CreatedUserHistoryMode => createDataCreatedUserHistoryMode(), 
			ActionEnum.SaveUserDataMode => createDataSaveUserDataMode(), 
			ActionEnum.LoadUserDataMode => createDataLoadUserDataMode(), 
			ActionEnum.ChangeUUIDMode => createDataChangeUUIDMode(), 
			ActionEnum.setTutorialCleared => createDatasetTutorialCleared(), 
			ActionEnum.userDataUpDownLoadTest => createDatauserDataUpDownLoadTest(), 
			ActionEnum.userDataUpload => createDatauserDataUpload(), 
			ActionEnum.userDataLoadMain => createDatauserDataLoadMain(), 
			ActionEnum.userDataLoadMain2 => createDatauserDataLoadMain2(), 
			ActionEnum.fileSelectMode => createDatafileSelectMode(), 
			ActionEnum.questMissionViewMode => createDataquestMissionViewMode(), 
			ActionEnum.colloseumEventViewMode => createDatacolloseumEventViewMode(), 
			ActionEnum.questTicketViewMode => createDataquestTicketViewMode(), 
			ActionEnum.playByThisTicket => createDataplayByThisTicket(), 
			ActionEnum.useTicketMode => createDatauseTicketMode(), 
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
		actionClassMainMode._0024act_0024t_0024561 = ActionEnum.MainMode;
		actionClassMainMode._0024act_0024t_0024562 = "$default$";
		actionClassMainMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable284_0024179_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002485.Adapt(delegate
		{
			_0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024 = new _0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313();
			_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud = UserData.Current;
			if (_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242809(_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024, this).Invoke));
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					if (RuntimeDebugModeGuiMixin.button("Etcflags"))
					{
						EtcFlagMode();
					}
					if (RuntimeDebugModeGuiMixin.button("diary"))
					{
						DiaryMode();
					}
					if (RuntimeDebugModeGuiMixin.button("UserData misc data"))
					{
						CurrentUserDataMode();
					}
				});
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					if (RuntimeDebugModeGuiMixin.button("作成ユーザー履歴"))
					{
						CreatedUserHistoryMode();
					}
					if (RuntimeDebugModeGuiMixin.button("今セーブ"))
					{
						UserData.Current.userMiscInfo.AllowToSave();
						UserData.Current.userMiscInfo.Save();
					}
					if (RuntimeDebugModeGuiMixin.button("今ロード"))
					{
						UserData.Current.userMiscInfo.Load();
					}
				});
				RuntimeDebugModeGuiMixin.space(10);
				if (RuntimeDebugModeGuiMixin.button("QuestTickets"))
				{
					questTicketViewMode();
				}
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					if (RuntimeDebugModeGuiMixin.button("ColosseumEvent"))
					{
						colloseumEventViewMode();
					}
					if (RuntimeDebugModeGuiMixin.button("QuestMission"))
					{
						questMissionViewMode();
					}
				});
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.slabel("weapon num: " + _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.BoxWeaponNum);
				RuntimeDebugModeGuiMixin.slabel("poppet num: " + _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.BoxPoppetNum);
				RuntimeDebugModeGuiMixin.space(30);
				int titleWidth = 250;
				RespPlayerInfo userStatus = _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.userStatus;
				RuntimeDebugModeGuiMixin.snamevalue("Id", userStatus.Id, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Exp", userStatus.Exp, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Level", userStatus.Level, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Ap", userStatus.Ap, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Rp", userStatus.Rp, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Fp", userStatus.Fp, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("AngelGender", userStatus.AngelGender, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("AngelName", userStatus.AngelName, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("BeforeApRecoveryDateTime", userStatus.BeforeApRecoveryDateTime, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("BeforeRpRecoveryDateTime", userStatus.BeforeRpRecoveryDateTime, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("BoxExtensionCount", userStatus.BoxExtensionCount, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("BoxSize", userStatus.BoxSize, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Coin", userStatus.Coin, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("DemonGender", userStatus.DemonGender, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("DemonName", userStatus.DemonName, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("FayStone", userStatus.FayStone, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("FriendLimit", userStatus.FriendLimit, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("IsTutorialFin", userStatus.IsTutorialFin, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("PoppetName", userStatus.PoppetName, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("Rgp", userStatus.Rgp, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TGuildCd", userStatus.TGuildCd, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TPartyId", userStatus.TPartyId, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TPlayerDeckNo", userStatus.TPlayerDeckNo, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TPlayerId", userStatus.TPlayerId, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TSocialPlayerId", userStatus.TSocialPlayerId, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("TutorialStep", userStatus.TutorialStep, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("WeaponCostLimit", userStatus.WeaponCostLimit, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("ManaFragment", userStatus.ManaFragment, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("CreateDate", userStatus.CreateDate, titleWidth);
				RuntimeDebugModeGuiMixin.space(20);
				RuntimeDebugModeGuiMixin.snamevalue("EndApRecoveryDateTime", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.EndApRecoveryDateTime, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("EndRpRecoveryDateTime", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.EndRpRecoveryDateTime, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("UserData.AP", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.Ap, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("UserData.RP", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.Rp, titleWidth);
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.snamevalue("bgmLoad", UserData.Current.userMiscInfo.bgmLoad, titleWidth);
				RuntimeDebugModeGuiMixin.snamevalue("xDisplayedNewFeatureId", UserData.Current.getIntFlag("xDisplayedNewFeatureId", 0), titleWidth);
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("RaidBattle as RespTCycleRaidBattles: ");
				RespTCycleRaidBattle raidBattle = _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.userRaidInfo.raidBattle;
				if (raidBattle == null)
				{
					RuntimeDebugModeGuiMixin.slabel("<no raid battle data>");
				}
				else
				{
					RuntimeDebugModeGuiMixin.snamevalue("Id", raidBattle.Id, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("TCycleId", raidBattle.TCycleId, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("StyleId", raidBattle.StyleId, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("ElementId", raidBattle.ElementId, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("ComboStartDate", raidBattle.ComboStartDate, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("ComboLevel", raidBattle.ComboLevel, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("MMonsterId", raidBattle.MMonsterId, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("NumberOfTimes", raidBattle.NumberOfTimes, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("DiscoverSocialPlayerId", raidBattle.DiscoverSocialPlayerId, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("DiscoverDate", raidBattle.DiscoverDate, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("Level", raidBattle.Level, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("LevelCorrection", raidBattle.LevelCorrection, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("InitialHp", raidBattle.InitialHp, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("Hp", raidBattle.Hp, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("PhotonServer", raidBattle.PhotonServer, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("RoomName", raidBattle.RoomName, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("IsActive", raidBattle.IsActive, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("IsDetectionElement", raidBattle.IsDetectionElement, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("IsDetectionStyle", raidBattle.IsDetectionStyle, titleWidth);
					RuntimeDebugModeGuiMixin.snamevalue("IsDescover", raidBattle.IsDiscover, titleWidth);
				}
				RuntimeDebugModeGuiMixin.slabel("LastRaidCycleId = " + UserData.Current.userMiscInfo.raidData.LastRaidCycleId);
				if (RuntimeDebugModeGuiMixin.button("delete LastRaidCycleId"))
				{
					UserData.Current.userMiscInfo.raidData.LastRaidCycleId = -1;
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("other information: ");
				RuntimeDebugModeGuiMixin.snamevalue("inviteCode", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.inviteCode, titleWidth);
				if (RuntimeDebugModeGuiMixin.button("loginBonusもらったフリをする"))
				{
					MerlinServer.ExRequest(new ApiHome(), _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108.Adapt(new _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242813(_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024).Invoke));
				}
			}
		});
		actionClassMainMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable284_0024179_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002485.Adapt(delegate
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
		if (_0024act_0024t_0024570.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024570["$default$"];
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

	public ActionClassWeaponBoxMode WeaponBoxMode()
	{
		ActionClassWeaponBoxMode actionClassWeaponBoxMode = createWeaponBoxMode();
		changeAction(actionClassWeaponBoxMode);
		return actionClassWeaponBoxMode;
	}

	public ActionClassWeaponBoxMode createDataWeaponBoxMode()
	{
		ActionClassWeaponBoxMode actionClassWeaponBoxMode = new ActionClassWeaponBoxMode();
		actionClassWeaponBoxMode._0024act_0024t_0024561 = ActionEnum.WeaponBoxMode;
		actionClassWeaponBoxMode._0024act_0024t_0024562 = "$default$";
		actionClassWeaponBoxMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable285_0024323_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002486.Adapt(delegate
		{
			UserData current = UserData.Current;
			if (current == null || current.BoxWeapons == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				int i = 0;
				RespWeapon[] boxWeapons = current.BoxWeapons;
				for (int length = boxWeapons.Length; i < length; i = checked(i + 1))
				{
					int attackPlusBonus = boxWeapons[i].RefPlayerBox.AttackPlusBonus;
					int hpPlusBonus = boxWeapons[i].RefPlayerBox.HpPlusBonus;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(boxWeapons[i].Id).Append(": ").Append(boxWeapons[i].Name)
						.Append(" L=")
						.Append((object)boxWeapons[i].Level)
						.Append("/")
						.Append((object)boxWeapons[i].LevelMax)
						.Append(" E=")
						.Append((object)boxWeapons[i].Exp)
						.Append(" M=")
						.Append((object)boxWeapons[i].MWeaponId)
						.Append(" ICON=")
						.Append(boxWeapons[i].Icon)
						.Append(" Exp=")
						.Append((object)boxWeapons[i].Exp)
						.Append(" LR:")
						.Append((object)boxWeapons[i].LevelLimitMin)
						.Append("-")
						.Append((object)boxWeapons[i].LevelLimitMax)
						.Append(" LvBr=")
						.Append((object)boxWeapons[i].LimitBreakCount)
						.Append(" SL=")
						.Append((object)boxWeapons[i].AngelSkillLevel)
						.Append(" ")
						.Append((object)boxWeapons[i].DemonSkillLevel)
						.Append(" T=")
						.Append((object)boxWeapons[i].TraitId)
						.Append(" P=")
						.Append((object)attackPlusBonus)
						.Append("/")
						.Append((object)hpPlusBonus)
						.ToString());
				}
			}
		});
		actionClassWeaponBoxMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable285_0024323_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002486.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassWeaponBoxMode;
	}

	public ActionClassWeaponBoxMode createWeaponBoxMode()
	{
		return createDataWeaponBoxMode();
	}

	public ActionClassPoppetBoxMode PoppetBoxMode()
	{
		ActionClassPoppetBoxMode actionClassPoppetBoxMode = createPoppetBoxMode();
		changeAction(actionClassPoppetBoxMode);
		return actionClassPoppetBoxMode;
	}

	public ActionClassPoppetBoxMode createDataPoppetBoxMode()
	{
		ActionClassPoppetBoxMode actionClassPoppetBoxMode = new ActionClassPoppetBoxMode();
		actionClassPoppetBoxMode._0024act_0024t_0024561 = ActionEnum.PoppetBoxMode;
		actionClassPoppetBoxMode._0024act_0024t_0024562 = "$default$";
		actionClassPoppetBoxMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable286_0024338_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002487.Adapt(delegate
		{
			UserData current = UserData.Current;
			if (current == null || current.BoxPoppets == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				int i = 0;
				RespPoppet[] boxPoppets = current.BoxPoppets;
				for (int length = boxPoppets.Length; i < length; i = checked(i + 1))
				{
					int attackPlusBonus = boxPoppets[i].RefPlayerBox.AttackPlusBonus;
					int hpPlusBonus = boxPoppets[i].RefPlayerBox.HpPlusBonus;
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(boxPoppets[i].Id).Append(": ").Append(boxPoppets[i].Name)
						.Append(" L=")
						.Append((object)boxPoppets[i].Level)
						.Append("/")
						.Append((object)boxPoppets[i].LevelMax)
						.Append(" E=")
						.Append((object)boxPoppets[i].Exp)
						.Append(" M=")
						.Append((object)boxPoppets[i].MPoppetId)
						.Append(" ICON=")
						.Append(boxPoppets[i].Icon)
						.Append(" Exp=")
						.Append((object)boxPoppets[i].Exp)
						.Append(" SL=")
						.Append((object)boxPoppets[i].CoverSkillLevel_1)
						.Append(" ")
						.Append((object)boxPoppets[i].CoverSkillLevel_2)
						.Append(" ")
						.Append((object)boxPoppets[i].ChainSkillLevel)
						.Append(" T=")
						.Append((object)boxPoppets[i].TraitId)
						.Append(" P=")
						.Append((object)attackPlusBonus)
						.Append("/")
						.Append((object)hpPlusBonus)
						.ToString());
				}
			}
		});
		actionClassPoppetBoxMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable286_0024338_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002487.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassPoppetBoxMode;
	}

	public ActionClassPoppetBoxMode createPoppetBoxMode()
	{
		return createDataPoppetBoxMode();
	}

	public ActionClassDeckMode DeckMode()
	{
		ActionClassDeckMode actionClassDeckMode = createDeckMode();
		changeAction(actionClassDeckMode);
		return actionClassDeckMode;
	}

	public ActionClassDeckMode createDataDeckMode()
	{
		ActionClassDeckMode actionClassDeckMode = new ActionClassDeckMode();
		actionClassDeckMode._0024act_0024t_0024561 = ActionEnum.DeckMode;
		actionClassDeckMode._0024act_0024t_0024562 = "$default$";
		actionClassDeckMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable287_0024353_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002488.Adapt(delegate(ActionClassDeckMode _0024act_0024t_0024582)
		{
			UserData current = UserData.Current;
			int num;
			if (current.IsValidDeck2)
			{
				UserDeckData2 userDeckData = UserData.Current.userDeckData2;
				num = userDeckData.deckNum();
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.label("新デッキモードユーザー!");
				RuntimeDebugModeGuiMixin.label("デッキ数: " + num);
				RuntimeDebugModeGuiMixin.space(10);
				string[] texts = ArrayMap.RangeToStr(num, (int i) => new StringBuilder().Append((object)i).ToString());
				_0024act_0024t_0024582.curDeckIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024582.curDeckIdx, texts, 5);
				RuntimeDebugModeGuiMixin.space(10);
				if (_0024act_0024t_0024582.curDeckIdx < num)
				{
					RespDeck2[] all = userDeckData.All;
					newDeckView(all[RuntimeServices.NormalizeArrayIndex(all, _0024act_0024t_0024582.curDeckIdx)], new StringBuilder("DECK ").Append((object)_0024act_0024t_0024582.curDeckIdx).ToString());
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.space(10);
				RuntimeDebugModeGuiMixin.label("旧デッキモードユーザー");
				RuntimeDebugModeGuiMixin.space(10);
				oldDeckMode();
			}
			RuntimeDebugModeGuiMixin.space(20);
			RuntimeDebugModeGuiMixin.label("(闘技場)魔ペットデッキ");
			UserPoppetDeckData userPoppetDeckData = UserData.Current.userPoppetDeckData;
			num = userPoppetDeckData.deckNum();
			if (num > 0)
			{
				string[] texts2 = ArrayMap.RangeToStr(num, (int i) => new StringBuilder().Append((object)i).ToString());
				_0024act_0024t_0024582.curPoppetDeckIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024582.curPoppetDeckIdx, texts2, num);
				RuntimeDebugModeGuiMixin.space(10);
				if (_0024act_0024t_0024582.curPoppetDeckIdx < num)
				{
					RespPoppetDeck[] all2 = userPoppetDeckData.All;
					poppetDeckView(all2[RuntimeServices.NormalizeArrayIndex(all2, _0024act_0024t_0024582.curPoppetDeckIdx)], new StringBuilder("DECK ").Append((object)_0024act_0024t_0024582.curPoppetDeckIdx).ToString());
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("   魔ペットデッキデータなし");
			}
		});
		actionClassDeckMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable287_0024353_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002488.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassDeckMode;
	}

	public ActionClassDeckMode createDeckMode()
	{
		return createDataDeckMode();
	}

	private void poppetDeckView(RespPoppetDeck d, string title)
	{
		RuntimeDebugModeGuiMixin.label(title);
		if (d == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.label("IsEquip:" + d.IsEquip);
		RuntimeDebugModeGuiMixin.label("No:" + d.No);
		int num = 0;
		int length = d.PlayerPoppetDecks.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			RespPlayerPoppetDeck[] playerPoppetDecks = d.PlayerPoppetDecks;
			RespPlayerPoppetDeck respPlayerPoppetDeck = playerPoppetDecks[RuntimeServices.NormalizeArrayIndex(playerPoppetDecks, num2)];
			if (respPlayerPoppetDeck != null)
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("[").Append((object)num2).Append("] BoxId=").Append(respPlayerPoppetDeck.PoppetBoxId)
					.Append(" weapon BoxId=")
					.Append(respPlayerPoppetDeck.WeaponBoxId)
					.ToString());
				RuntimeDebugModeGuiMixin.slabel("   isLeader: " + respPlayerPoppetDeck.IsLeader);
				RuntimeDebugModeGuiMixin.slabel("   poppet: " + respPlayerPoppetDeck.BoxPoppet);
				RuntimeDebugModeGuiMixin.slabel("   weapon: " + respPlayerPoppetDeck.BoxWeapon);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("[").Append((object)num2).Append("] <null>").ToString());
			}
		}
	}

	private void newDeckView(RespDeck2 d, string title)
	{
		RuntimeDebugModeGuiMixin.label(title);
		if (d == null)
		{
			return;
		}
		RuntimeDebugModeGuiMixin.label("No: " + d.No);
		RuntimeDebugModeGuiMixin.label("天使武器: " + d.AngelWeapon + " BoxId:" + d.AngelBoxId);
		RuntimeDebugModeGuiMixin.label("悪魔武器: " + d.DevilWeapon + " BoxId:" + d.DevilBoxId);
		RuntimeDebugModeGuiMixin.label("魔ペット: " + d.MainPoppet + " BoxId:" + d.PoppetBoxId);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("サポート武器:");
		int i = 0;
		RespDeck2Support[] orderedSupports = d.OrderedSupports;
		for (int length = orderedSupports.Length; i < length; i = checked(i + 1))
		{
			string value = ((!orderedSupports[i].IsTenshiSupport) ? "悪魔" : "天使");
			if (orderedSupports[i].IsWeapon)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(value).Append("武器     No:").Append((object)orderedSupports[i].No)
					.Append(" :")
					.ToString() + orderedSupports[i].BoxWeapon);
			}
			else if (orderedSupports[i].IsPoppet)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(value).Append("魔ペット No:").Append((object)orderedSupports[i].No)
					.Append(" :")
					.ToString() + orderedSupports[i].BoxPoppet);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("  ").Append(value).Append("？？？？ No:").Append((object)orderedSupports[i].No)
					.ToString());
			}
		}
	}

	private void oldDeckMode()
	{
		UserData current = UserData.Current;
		if (current == null || current.userDeckData == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		UserDeckData userDeckData = current.userDeckData;
		int i = 0;
		RespDeck[] array = current.userDeckData.all();
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("== DECK ").Append((object)array[i].No).Append(" ==").ToString());
			Boo.Lang.List<RespWeapon> list = new Boo.Lang.List<RespWeapon>();
			Builtins.ZipEnumerator zipEnumerator = Builtins.zip(Builtins.range(3), array[i].ToApiBoxIdArray);
			try
			{
				while (zipEnumerator.MoveNext())
				{
					object obj = zipEnumerator.Current;
					if (!(obj is object[]))
					{
						obj = RuntimeServices.Coerce(obj, typeof(object[]));
					}
					object[] array2 = (object[])obj;
					object value = array2[0];
					object obj2 = array2[1];
					RespWeapon respWeapon = current.boxWeapon((BoxId)obj2);
					if (respWeapon != null)
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("WEAPON ").Append(value).Append(": ").Append(respWeapon.Id)
							.Append(" ")
							.Append(respWeapon.Name)
							.Append(" M=")
							.Append((object)respWeapon.MWeaponId)
							.ToString());
						list.Add(respWeapon);
					}
					else
					{
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("WEAPON ").Append(value).Append(": ???").ToString());
					}
				}
			}
			finally
			{
				((IDisposable)zipEnumerator).Dispose();
			}
			float num = DamageCalc.TotalWeaponAttack((RespWeapon[])Builtins.array(typeof(RespWeapon), list));
			float num2 = DamageCalc.TotalWeaponHP((RespWeapon[])Builtins.array(typeof(RespWeapon), list));
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Weapon Attack:").Append(num).Append(" HP:").Append(num2)
				.ToString());
			RespPoppet respPoppet = current.boxPoppet(array[i].TPoppetBoxId);
			if (respPoppet == null)
			{
				RuntimeDebugModeGuiMixin.slabel("POPPET: ???");
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("POPPET: ").Append(respPoppet.Id).Append(" ").Append(respPoppet.Name)
					.Append(" M=")
					.Append((object)respPoppet.MPoppetId)
					.ToString());
			}
			RuntimeDebugModeGuiMixin.space(10);
			num = DamageCalc.TotalPlayerAttack((RespWeapon[])Builtins.array(typeof(RespWeapon), list), new RespPoppet[1] { respPoppet });
			num2 = DamageCalc.TotalPlayerHP((RespWeapon[])Builtins.array(typeof(RespWeapon), list), new RespPoppet[1] { respPoppet });
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Total Attack:").Append(num).Append(" HP:").Append(num2)
				.ToString());
			RuntimeDebugModeGuiMixin.space(30);
		}
	}

	public ActionClassFlagMode FlagMode()
	{
		ActionClassFlagMode actionClassFlagMode = createFlagMode();
		changeAction(actionClassFlagMode);
		return actionClassFlagMode;
	}

	public ActionClassFlagMode createDataFlagMode()
	{
		ActionClassFlagMode actionClassFlagMode = new ActionClassFlagMode();
		actionClassFlagMode._0024act_0024t_0024561 = ActionEnum.FlagMode;
		actionClassFlagMode._0024act_0024t_0024562 = "$default$";
		actionClassFlagMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable288_0024466_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002489.Adapt(delegate
		{
			_0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314 _0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024 = new _0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314();
			int titleWidth = 250;
			UserData current = UserData.Current;
			if (current == null || current.userDeckData == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("Player flags");
				_0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024._0024flagData = current.userMiscInfo.flagData;
				__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242826(_0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024).Invoke;
				TutorialSwitch();
				RuntimeDebugModeGuiMixin.space(5);
				GUIStyle gUIStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
				gUIStyle.fontSize = 14;
				gUIStyle.alignment = TextAnchor.LowerLeft;
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("[").Append(flagFilterName).Append("]+[").Append(storyFilterName)
						.Append("]のフラグ一括設定")
						.ToString());
					if (RuntimeDebugModeGuiMixin.button("一括ON"))
					{
						bulkSetFlag(currentFlagFilter + currentStoryFilter, b: true);
					}
					if (RuntimeDebugModeGuiMixin.button("一括OFF"))
					{
						bulkSetFlag(currentFlagFilter + currentStoryFilter, b: false);
					}
				});
				RuntimeDebugModeGuiMixin.slabel("フラグタイプ表示フィルタ");
				listWithFilter(flag_filter_label, new __Req_FailHandler_0024callable6_0024440_32__(applyFilterToFlags), ref currentFlagFilter);
				RuntimeDebugModeGuiMixin.slabel("話数表示フィルタ ↑と組み合わせて使う");
				GUILayout.BeginHorizontal();
				IEnumerator<object[]> enumerator = Builtins.enumerate(story_filter_label).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object[] current2 = enumerator.Current;
						int num = RuntimeServices.UnboxInt32(current2[0]);
						object obj = current2[1];
						if (!(obj is string[]))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string[]));
						}
						string[] array = (string[])obj;
						if (num % 8 == 0 && num > 0)
						{
							GUILayout.EndHorizontal();
							GUILayout.BeginHorizontal();
						}
						if (GUILayout.Button(array[0] as string))
						{
							storyFilterName = array[0];
							currentStoryFilter = array[1] as string;
							applyFilterToFlags(currentFlagFilter, currentStoryFilter);
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				GUILayout.EndHorizontal();
				RuntimeDebugModeGuiMixin.space(5);
				RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
				{
					RuntimeDebugModeGuiMixin.slabel("S: シナリオ進行");
					RuntimeDebugModeGuiMixin.slabel("q: クエスト開放");
					RuntimeDebugModeGuiMixin.slabel("t: クエストギミック");
					RuntimeDebugModeGuiMixin.slabel("x: 謎");
					RuntimeDebugModeGuiMixin.slabel("v: シーン visit");
				});
				if (RuntimeDebugModeGuiMixin.button("詳細"))
				{
					detail = !detail;
				}
				if (detail)
				{
					IEnumerator<object> enumerator2 = flags.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							if (!(obj2 is MFlags))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(MFlags));
							}
							MFlags mFlags = (MFlags)obj2;
							bool value = _0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024._0024flagData.getInt(mFlags.Progname) > 0;
							snamevaluetoggle(mFlags.Progname, value, titleWidth, func);
						}
					}
					finally
					{
						enumerator2.Dispose();
					}
				}
			}
		});
		actionClassFlagMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable288_0024466_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002489.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassFlagMode;
	}

	public ActionClassFlagMode createFlagMode()
	{
		return createDataFlagMode();
	}

	public ActionClassEtcFlagMode EtcFlagMode()
	{
		ActionClassEtcFlagMode actionClassEtcFlagMode = createEtcFlagMode();
		changeAction(actionClassEtcFlagMode);
		return actionClassEtcFlagMode;
	}

	public ActionClassEtcFlagMode createDataEtcFlagMode()
	{
		ActionClassEtcFlagMode actionClassEtcFlagMode = new ActionClassEtcFlagMode();
		actionClassEtcFlagMode._0024act_0024t_0024561 = ActionEnum.EtcFlagMode;
		actionClassEtcFlagMode._0024act_0024t_0024562 = "$default$";
		actionClassEtcFlagMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable289_0024530_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002490.Adapt(checked(delegate
		{
			_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315 _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024 = new _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315();
			int titleWidth = 250;
			UserData current = UserData.Current;
			if (current == null || current.userDeckData == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Player quests");
				Hashtable hashtable = current.userMiscInfo.questData.Flags;
				if (hashtable == null || hashtable.Count == 0)
				{
					RuntimeDebugModeGuiMixin.slabel("<no quests>");
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("All Clear"))
					{
						hashtable.Clear();
					}
					IEnumerator enumerator = hashtable.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current2 = enumerator.Current;
						int result = 0;
						MQuests mQuests = null;
						object obj = current2;
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						if (int.TryParse((string)obj, out result))
						{
							mQuests = MQuests.Get(result);
						}
						if (mQuests != null)
						{
							RuntimeDebugModeGuiMixin.snamevalue("    " + current2, mQuests.GetName(), titleWidth);
						}
						else
						{
							RuntimeDebugModeGuiMixin.snamevalue("    " + current2, "No MQuests", titleWidth);
						}
					}
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Player areas");
				Hashtable hashtable2 = current.userMiscInfo.areaData.Flags;
				if (hashtable2 == null || hashtable2.Count == 0)
				{
					RuntimeDebugModeGuiMixin.slabel("<no areas>");
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("All Clear"))
					{
						hashtable2.Clear();
					}
					IEnumerator enumerator2 = hashtable2.Keys.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object current3 = enumerator2.Current;
						object obj2 = current3;
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						MAreas mAreas = MAreas.Get(int.Parse((string)obj2));
						RuntimeDebugModeGuiMixin.snamevalue("    " + current3, mAreas.GetName(), titleWidth);
					}
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Player treasure");
				Hashtable treasure = current.userMiscInfo.treasureData.Treasure;
				if (treasure == null || treasure.Count == 0)
				{
					RuntimeDebugModeGuiMixin.slabel("<no treasures>");
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("All Clear"))
					{
						treasure.Clear();
					}
					IEnumerator enumerator3 = treasure.Keys.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						object obj3 = enumerator3.Current;
						if (!(obj3 is string))
						{
							obj3 = RuntimeServices.Coerce(obj3, typeof(string));
						}
						string text = (string)obj3;
						MQuests mQuests2 = MQuests.Get(int.Parse(text));
						object obj4 = treasure[text];
						if (!(obj4 is Hashtable))
						{
							obj4 = RuntimeServices.Coerce(obj4, typeof(Hashtable));
						}
						Hashtable hashtable3 = (Hashtable)obj4;
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(mQuests2.GetName()).Append("(QuestId:").Append(text)
							.Append(")")
							.ToString());
						IEnumerator enumerator4 = hashtable3.Keys.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							object obj5 = enumerator4.Current;
							if (!(obj5 is string))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(string));
							}
							string text2 = (string)obj5;
							if (text2.StartsWith("w"))
							{
								MWeapons mWeapons = MWeapons.Get(int.Parse(text2.Substring(1)));
								RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mWeapons.Name).Append("(ItemId:").Append(text2)
									.Append("):")
									.Append(hashtable3[text2])
									.ToString());
							}
							else if (text2.StartsWith("p"))
							{
								MPoppets mPoppets = MPoppets.Get(int.Parse(text2.Substring(1)));
								RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mPoppets.Name).Append("(ItemId:").Append(text2)
									.Append("):")
									.Append(hashtable3[text2])
									.ToString());
							}
						}
					}
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Player Weapon PicBook");
				Hashtable hashtable4 = current.userMiscInfo.weaponBookData.Flags;
				if (hashtable4 == null || hashtable4.Count == 0)
				{
					RuntimeDebugModeGuiMixin.slabel("<no Weapon>");
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("All Clear"))
					{
						hashtable4.Clear();
					}
					IEnumerator enumerator5 = hashtable4.Keys.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						object current4 = enumerator5.Current;
						object obj6 = current4;
						if (!(obj6 is string))
						{
							obj6 = RuntimeServices.Coerce(obj6, typeof(string));
						}
						MWeapons mWeapons2 = MWeapons.Get(int.Parse((string)obj6));
						if (mWeapons2 != null)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mWeapons2.Name).ToString());
						}
					}
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Player Poppet PicBook");
				Hashtable hashtable5 = current.userMiscInfo.poppetBookData.Flags;
				if (hashtable5 == null || hashtable5.Count == 0)
				{
					RuntimeDebugModeGuiMixin.slabel("<no Poppet>");
				}
				else
				{
					if (RuntimeDebugModeGuiMixin.button("All Clear"))
					{
						hashtable5.Clear();
					}
					IEnumerator enumerator6 = hashtable5.Keys.GetEnumerator();
					while (enumerator6.MoveNext())
					{
						object current5 = enumerator6.Current;
						object obj7 = current5;
						if (!(obj7 is string))
						{
							obj7 = RuntimeServices.Coerce(obj7, typeof(string));
						}
						MPoppets mPoppets2 = MPoppets.Get(int.Parse((string)obj7));
						if (mPoppets2 != null)
						{
							RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mPoppets2.Name).ToString());
						}
					}
				}
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("Story");
				_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData = current.userMiscInfo.storyData;
				if (RuntimeDebugModeGuiMixin.button("All"))
				{
					int i = 0;
					MStories[] all = MStories.All;
					for (int length = all.Length; i < length; i++)
					{
						bool flag = _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.getInt(all[i].Progname) > 0;
						if (!flag)
						{
							_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.set(all[i].Progname, 1);
						}
						if (flag)
						{
							_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.delete(all[i].Progname);
						}
					}
				}
				__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataEtcFlagMode_0024closure_00242830_0024closure_00242831(_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024).Invoke;
				int j = 0;
				MStories[] all2 = MStories.All;
				for (int length2 = all2.Length; j < length2; j++)
				{
					bool flag = _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.getInt(all2[j].Progname) > 0;
					snamevaluetoggle(all2[j].Progname, flag, titleWidth, func);
				}
			}
		}));
		actionClassEtcFlagMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable289_0024530_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002490.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassEtcFlagMode;
	}

	public ActionClassEtcFlagMode createEtcFlagMode()
	{
		return createDataEtcFlagMode();
	}

	public ActionClassCurrentUserDataMode CurrentUserDataMode()
	{
		ActionClassCurrentUserDataMode actionClassCurrentUserDataMode = createCurrentUserDataMode();
		changeAction(actionClassCurrentUserDataMode);
		return actionClassCurrentUserDataMode;
	}

	public ActionClassCurrentUserDataMode createDataCurrentUserDataMode()
	{
		ActionClassCurrentUserDataMode actionClassCurrentUserDataMode = new ActionClassCurrentUserDataMode();
		actionClassCurrentUserDataMode._0024act_0024t_0024561 = ActionEnum.CurrentUserDataMode;
		actionClassCurrentUserDataMode._0024act_0024t_0024562 = "$default$";
		actionClassCurrentUserDataMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable290_0024630_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002491.Adapt(delegate
		{
			UserData current = UserData.Current;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("ApRecoverySec: ").Append(UserData.ApRecoverySec).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("RpRecoverySec: ").Append(UserData.RpRecoverySec).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EndApRecoveryDateTime: ").Append(current.EndApRecoveryDateTime).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EndRpRecoveryDateTime: ").Append(current.EndRpRecoveryDateTime).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.Ap: ").Append((object)current.userStatus.Ap).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.Rp: ").Append((object)current.userStatus.Rp).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.BeforeApRecoveryDateTime: ").Append(current.userStatus.BeforeApRecoveryDateTime).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.BeforeRpRecoveryDateTime: ").Append(current.userStatus.BeforeRpRecoveryDateTime).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Ap: ").Append((object)current.Ap).ToString());
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Rp: ").Append((object)current.Rp).ToString());
		});
		actionClassCurrentUserDataMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable290_0024630_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002491.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassCurrentUserDataMode;
	}

	public ActionClassCurrentUserDataMode createCurrentUserDataMode()
	{
		return createDataCurrentUserDataMode();
	}

	public ActionClassDiaryMode DiaryMode()
	{
		ActionClassDiaryMode actionClassDiaryMode = createDiaryMode();
		changeAction(actionClassDiaryMode);
		return actionClassDiaryMode;
	}

	public ActionClassDiaryMode createDataDiaryMode()
	{
		ActionClassDiaryMode actionClassDiaryMode = new ActionClassDiaryMode();
		actionClassDiaryMode._0024act_0024t_0024561 = ActionEnum.DiaryMode;
		actionClassDiaryMode._0024act_0024t_0024562 = "$default$";
		actionClassDiaryMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable291_0024645_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002492.Adapt(checked(delegate
		{
			_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024 = new _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316();
			int titleWidth = 250;
			UserData current = UserData.Current;
			if (current == null || current.userDeckData == null)
			{
				RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			}
			else
			{
				_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData = current.userMiscInfo.flagData;
				_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData = current.userMiscInfo.storyData;
				__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242836(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024).Invoke;
				__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func2 = new _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242837(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024).Invoke;
				RuntimeDebugModeGuiMixin.space(30);
				RuntimeDebugModeGuiMixin.slabel("<Saboten Diary>");
				int i = 0;
				MStoryBooks[] all = MStoryBooks.All;
				for (int length = all.Length; i < length; i++)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("■ ").Append(all[i].Progname).Append(":").Append(all[i].GetTitle())
						.ToString());
					bool flag = true;
					RuntimeDebugModeGuiMixin.slabel("・ストーリー：");
					MStories mStoryId = all[i].MStoryId;
					bool flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.getInt(mStoryId.Progname) > 0;
					bool num = flag;
					if (num)
					{
						num = flag2;
					}
					flag = num;
					snamevaluetoggle(mStoryId.Progname, flag2, titleWidth, func2);
					RuntimeDebugModeGuiMixin.slabel("・必須フラグ：");
					int j = 0;
					MFlags[] allConditions = all[i].AllConditions;
					for (int length2 = allConditions.Length; j < length2; j++)
					{
						flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.getInt(allConditions[j].Progname) > 0;
						bool num2 = flag;
						if (num2)
						{
							num2 = flag2;
						}
						flag = num2;
						snamevaluetoggle(allConditions[j].Progname, flag2, titleWidth, func);
					}
					RuntimeDebugModeGuiMixin.slabel("・不要フラグ：");
					int k = 0;
					MFlags[] allNotConditions = all[i].AllNotConditions;
					for (int length3 = allNotConditions.Length; k < length3; k++)
					{
						flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.getInt(allNotConditions[k].Progname) > 0;
						bool num3 = flag;
						if (num3)
						{
							num3 = flag2;
						}
						flag = num3;
						snamevaluetoggle(allNotConditions[k].Progname, !flag2, titleWidth, func);
					}
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(flag).ToString()))
					{
						mStoryId = all[i].MStoryId;
						flag2 = flag;
						if (!flag2)
						{
							_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.set(mStoryId.Progname, 1);
						}
						if (flag2)
						{
							_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.delete(mStoryId.Progname);
						}
						int l = 0;
						MFlags[] allConditions2 = all[i].AllConditions;
						for (int length4 = allConditions2.Length; l < length4; l++)
						{
							if (!flag2)
							{
								_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.set(allConditions2[l].Progname, 1);
							}
							if (flag2)
							{
								_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.delete(allConditions2[l].Progname);
							}
						}
						int m = 0;
						MFlags[] allNotConditions2 = all[i].AllNotConditions;
						for (int length5 = allNotConditions2.Length; m < length5; m++)
						{
							if (flag2)
							{
								_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.set(allNotConditions2[m].Progname, 1);
							}
							if (!flag2)
							{
								_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.delete(allNotConditions2[m].Progname);
							}
						}
					}
				}
			}
		}));
		actionClassDiaryMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable291_0024645_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002492.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassDiaryMode;
	}

	public ActionClassDiaryMode createDiaryMode()
	{
		return createDataDiaryMode();
	}

	public ActionClassCreatedUserHistoryMode CreatedUserHistoryMode()
	{
		ActionClassCreatedUserHistoryMode actionClassCreatedUserHistoryMode = createCreatedUserHistoryMode();
		changeAction(actionClassCreatedUserHistoryMode);
		return actionClassCreatedUserHistoryMode;
	}

	public ActionClassCreatedUserHistoryMode createDataCreatedUserHistoryMode()
	{
		ActionClassCreatedUserHistoryMode actionClassCreatedUserHistoryMode = new ActionClassCreatedUserHistoryMode();
		actionClassCreatedUserHistoryMode._0024act_0024t_0024561 = ActionEnum.CreatedUserHistoryMode;
		actionClassCreatedUserHistoryMode._0024act_0024t_0024562 = "$default$";
		actionClassCreatedUserHistoryMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable292_0024699_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002493.Adapt(delegate
		{
			UUIDHistory.Load();
		});
		actionClassCreatedUserHistoryMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable292_0024699_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002493.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("現UUID: " + CurrentInfo.UUID);
			RuntimeDebugModeGuiMixin.slabel("履歴数: " + UUIDHistory.Count);
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("履歴クリア"))
			{
				UUIDHistory.Clear();
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("現ユーザーデータをサーバーへ保存"))
			{
				SaveUserDataMode();
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("現ユーザーデータをサーバーからロード"))
			{
				LoadUserDataMode();
			}
			RuntimeDebugModeGuiMixin.label("ユーザー変更後は再起動してください。");
			RuntimeDebugModeGuiMixin.space(10);
			int i = 0;
			UUIDHistory.Entry[] allEntries = UUIDHistory.AllEntries;
			for (int length = allEntries.Length; i < length; i = checked(i + 1))
			{
				string text = allEntries[i].ToString();
				if (allEntries[i].uuid == CurrentInfo.UUID)
				{
					text += " [現在]";
				}
				if (RuntimeDebugModeGuiMixin.button(text))
				{
					ChangeUUIDMode(allEntries[i].uuid);
				}
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("Resources/Misc/UUIDHistory.txt読む"))
			{
				LoadUUIDsFromResources();
			}
		});
		actionClassCreatedUserHistoryMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable292_0024699_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002493.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassCreatedUserHistoryMode;
	}

	public ActionClassCreatedUserHistoryMode createCreatedUserHistoryMode()
	{
		return createDataCreatedUserHistoryMode();
	}

	public ActionClassSaveUserDataMode SaveUserDataMode()
	{
		ActionClassSaveUserDataMode actionClassSaveUserDataMode = createSaveUserDataMode();
		changeAction(actionClassSaveUserDataMode);
		return actionClassSaveUserDataMode;
	}

	public ActionClassSaveUserDataMode createDataSaveUserDataMode()
	{
		ActionClassSaveUserDataMode actionClassSaveUserDataMode = new ActionClassSaveUserDataMode();
		actionClassSaveUserDataMode._0024act_0024t_0024561 = ActionEnum.SaveUserDataMode;
		actionClassSaveUserDataMode._0024act_0024t_0024562 = "$default$";
		actionClassSaveUserDataMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable293_0024732_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002494.Adapt(delegate
		{
			MerlinServer.ExRequest(ApiLocalDataUpload.WithUserData(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				UserData.Current.userMiscInfo.Save();
				CreatedUserHistoryMode();
			}));
		});
		actionClassSaveUserDataMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable293_0024732_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002494.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("通信中");
			RuntimeDebugModeGuiMixin.slabel("ユーザーデータの保存中");
		});
		return actionClassSaveUserDataMode;
	}

	public ActionClassSaveUserDataMode createSaveUserDataMode()
	{
		return createDataSaveUserDataMode();
	}

	public ActionClassLoadUserDataMode LoadUserDataMode()
	{
		ActionClassLoadUserDataMode actionClassLoadUserDataMode = createLoadUserDataMode();
		changeAction(actionClassLoadUserDataMode);
		return actionClassLoadUserDataMode;
	}

	public ActionClassLoadUserDataMode createDataLoadUserDataMode()
	{
		ActionClassLoadUserDataMode actionClassLoadUserDataMode = new ActionClassLoadUserDataMode();
		actionClassLoadUserDataMode._0024act_0024t_0024561 = ActionEnum.LoadUserDataMode;
		actionClassLoadUserDataMode._0024act_0024t_0024562 = "$default$";
		actionClassLoadUserDataMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable294_0024742_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002495.Adapt(delegate
		{
			MerlinServer.ExRequest(new ApiLocalDataDownload(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				CreatedUserHistoryMode();
			}));
		});
		actionClassLoadUserDataMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable294_0024742_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002495.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("通信中");
			RuntimeDebugModeGuiMixin.slabel("ユーザーデータのdownload中");
		});
		return actionClassLoadUserDataMode;
	}

	public ActionClassLoadUserDataMode createLoadUserDataMode()
	{
		return createDataLoadUserDataMode();
	}

	public ActionClassChangeUUIDMode ChangeUUIDMode(string newUUID)
	{
		ActionClassChangeUUIDMode actionClassChangeUUIDMode = createChangeUUIDMode(newUUID);
		changeAction(actionClassChangeUUIDMode);
		return actionClassChangeUUIDMode;
	}

	public ActionClassChangeUUIDMode createDataChangeUUIDMode()
	{
		ActionClassChangeUUIDMode actionClassChangeUUIDMode = new ActionClassChangeUUIDMode();
		actionClassChangeUUIDMode._0024act_0024t_0024561 = ActionEnum.ChangeUUIDMode;
		actionClassChangeUUIDMode._0024act_0024t_0024562 = "$default$";
		actionClassChangeUUIDMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable295_0024752_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002496.Adapt(delegate(ActionClassChangeUUIDMode _0024act_0024t_0024606)
		{
			_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317 _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024 = new _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317();
			_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024._0024_0024act_0024t_0024606 = _0024act_0024t_0024606;
			MerlinServer.ExRequest(ApiLocalDataUpload.WithUserData(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849(_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024, this).Invoke));
		});
		actionClassChangeUUIDMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable295_0024752_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002496.Adapt(delegate
		{
			RuntimeDebugModeGuiMixin.label("通信中");
			RuntimeDebugModeGuiMixin.slabel("ユーザーデータの保存と切り換えをしています。");
			RuntimeDebugModeGuiMixin.slabel("切り換え後はアプリ再起動、または、");
			RuntimeDebugModeGuiMixin.slabel("unity再生しなおしをしてください。");
		});
		return actionClassChangeUUIDMode;
	}

	public ActionClassChangeUUIDMode createChangeUUIDMode(string newUUID)
	{
		ActionClassChangeUUIDMode actionClassChangeUUIDMode = createDataChangeUUIDMode();
		actionClassChangeUUIDMode.newUUID = newUUID;
		return actionClassChangeUUIDMode;
	}

	public void TutorialSwitch()
	{
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("tutorialProgress: ").Append(TutorialFlowControl.Progress).ToString());
			if (RuntimeDebugModeGuiMixin.button("強制チュートリアルクリア"))
			{
				setTutorialCleared();
			}
		});
	}

	public ActionClasssetTutorialCleared setTutorialCleared()
	{
		ActionClasssetTutorialCleared actionClasssetTutorialCleared = createsetTutorialCleared();
		changeAction(actionClasssetTutorialCleared);
		return actionClasssetTutorialCleared;
	}

	public ActionClasssetTutorialCleared createDatasetTutorialCleared()
	{
		ActionClasssetTutorialCleared actionClasssetTutorialCleared = new ActionClasssetTutorialCleared();
		actionClasssetTutorialCleared._0024act_0024t_0024561 = ActionEnum.setTutorialCleared;
		actionClasssetTutorialCleared._0024act_0024t_0024562 = "$default$";
		actionClasssetTutorialCleared._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable296_0024787_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002497.Adapt(delegate(ActionClasssetTutorialCleared _0024act_0024t_0024609)
		{
			_0024act_0024t_0024609.r1 = ApiUpdateTutorial.PresentBoxOpened();
			_0024act_0024t_0024609.r2 = ApiUpdateTutorial.RaidOpened();
			MerlinServer.Request(_0024act_0024t_0024609.r1);
			MerlinServer.Request(_0024act_0024t_0024609.r2);
			TutorialFlowControl.SetProgressFinished();
			TutorialFlowControl.Kill();
			QuestSession.DeleteSaveData();
		});
		actionClasssetTutorialCleared._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable296_0024787_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002497.Adapt(delegate(ActionClasssetTutorialCleared _0024act_0024t_0024609)
		{
			RuntimeDebugModeGuiMixin.label("通信中");
			if (_0024act_0024t_0024609.r1.IsOk && _0024act_0024t_0024609.r2.IsOk)
			{
				FlagMode();
			}
			else if (_0024act_0024t_0024609.r1.IsEnd && _0024act_0024t_0024609.r2.IsEnd)
			{
				RuntimeDebugModeGuiMixin.label("通信エラーになっちゃった");
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					FlagMode();
				}
			}
		});
		return actionClasssetTutorialCleared;
	}

	public ActionClasssetTutorialCleared createsetTutorialCleared()
	{
		return createDatasetTutorialCleared();
	}

	public static void listWithFilter(string[][] buttons, ICallable filterFunc, ref string flag)
	{
		GUILayout.BeginHorizontal();
		int i = 0;
		for (int length = buttons.Length; i < length; i = checked(i + 1))
		{
			if (GUILayout.Button(buttons[i][0] as string))
			{
				flagFilterName = buttons[i][0];
				filterFunc.Call(new object[1] { buttons[i][1] as string });
				flag = buttons[i][1];
			}
		}
		GUILayout.EndHorizontal();
	}

	private static void LoadUUIDsFromResources()
	{
		string path = "Misc/UUIDHistory";
		TextAsset textAsset = ((TextAsset)Resources.Load(path, typeof(TextAsset))) as TextAsset;
		if (!(textAsset != null) || !(NGUIJson.jsonDecode(textAsset.text) is ArrayList arrayList))
		{
			return;
		}
		IEnumerator enumerator = arrayList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (current is string)
			{
				UUIDHistory.Add(current as string, "捏造");
			}
			else if (current is ArrayList)
			{
				ArrayList arrayList2 = current as ArrayList;
				string text = arrayList2[0] as string;
				string text2 = arrayList2[1] as string;
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					UUIDHistory.Add(text, text2);
				}
			}
		}
	}

	public ActionClassuserDataUpDownLoadTest userDataUpDownLoadTest()
	{
		ActionClassuserDataUpDownLoadTest actionClassuserDataUpDownLoadTest = createuserDataUpDownLoadTest();
		changeAction(actionClassuserDataUpDownLoadTest);
		return actionClassuserDataUpDownLoadTest;
	}

	public ActionClassuserDataUpDownLoadTest createDatauserDataUpDownLoadTest()
	{
		ActionClassuserDataUpDownLoadTest actionClassuserDataUpDownLoadTest = new ActionClassuserDataUpDownLoadTest();
		actionClassuserDataUpDownLoadTest._0024act_0024t_0024561 = ActionEnum.userDataUpDownLoadTest;
		actionClassuserDataUpDownLoadTest._0024act_0024t_0024562 = "$default$";
		actionClassuserDataUpDownLoadTest._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable297_0024839_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002498.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.button("jsonファイルからロード"))
			{
				fileSelectMode("../upload_userdata", "*.txt", _0024adaptor_0024__DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable490_0024844_64___0024__Req_FailHandler_0024callable6_0024440_32___0024109.Adapt(userDataLoadMain), new __DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable492_0024844_82__(userDataUpDownLoadTest));
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("書き書きしたファイルからロード"))
			{
				fileSelectMode("../upload_userdata", "*.txt", _0024adaptor_0024__DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable493_0024847_64___0024__Req_FailHandler_0024callable6_0024440_32___0024110.Adapt(userDataLoadMain2), new __DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable492_0024844_82__(userDataUpDownLoadTest));
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("現在user dataをuploadする"))
			{
				userDataUpload();
			}
		});
		actionClassuserDataUpDownLoadTest._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable297_0024839_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002498.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassuserDataUpDownLoadTest;
	}

	public ActionClassuserDataUpDownLoadTest createuserDataUpDownLoadTest()
	{
		return createDatauserDataUpDownLoadTest();
	}

	public ActionClassuserDataUpload userDataUpload()
	{
		ActionClassuserDataUpload actionClassuserDataUpload = createuserDataUpload();
		changeAction(actionClassuserDataUpload);
		return actionClassuserDataUpload;
	}

	public ActionClassuserDataUpload createDatauserDataUpload()
	{
		ActionClassuserDataUpload actionClassuserDataUpload = new ActionClassuserDataUpload();
		actionClassuserDataUpload._0024act_0024t_0024561 = ActionEnum.userDataUpload;
		actionClassuserDataUpload._0024act_0024t_0024562 = "$default$";
		actionClassuserDataUpload._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable298_0024852_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002499.Adapt(delegate(ActionClassuserDataUpload _0024act_0024t_0024615)
		{
			_0024act_0024t_0024615.req = ApiLocalDataUpload.WithUserData();
			MerlinServer.ExRequest(_0024act_0024t_0024615.req);
		});
		actionClassuserDataUpload._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable298_0024852_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002499.Adapt(delegate(ActionClassuserDataUpload _0024act_0024t_0024615)
		{
			if (_0024act_0024t_0024615.req.IsOk)
			{
				RuntimeDebugModeGuiMixin.label("upload 完了");
				RuntimeDebugModeGuiMixin.slabel("system info で social id をちゃんと確認してね");
			}
			else if (_0024act_0024t_0024615.req.IsEnd)
			{
				RuntimeDebugModeGuiMixin.label("upload 失敗");
				RuntimeDebugModeGuiMixin.slabel("通信エラーでした");
				RuntimeDebugModeGuiMixin.textArea("エラー:\n" + _0024act_0024t_0024615.req.Error);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("upload 中...");
			}
		});
		actionClassuserDataUpload._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable298_0024852_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___002499.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				userDataUpDownLoadTest();
			}
		});
		return actionClassuserDataUpload;
	}

	public ActionClassuserDataUpload createuserDataUpload()
	{
		return createDatauserDataUpload();
	}

	public ActionClassuserDataLoadMain userDataLoadMain(string f)
	{
		ActionClassuserDataLoadMain actionClassuserDataLoadMain = createuserDataLoadMain(f);
		changeAction(actionClassuserDataLoadMain);
		return actionClassuserDataLoadMain;
	}

	public ActionClassuserDataLoadMain createDatauserDataLoadMain()
	{
		ActionClassuserDataLoadMain actionClassuserDataLoadMain = new ActionClassuserDataLoadMain();
		actionClassuserDataLoadMain._0024act_0024t_0024561 = ActionEnum.userDataLoadMain;
		actionClassuserDataLoadMain._0024act_0024t_0024562 = "$default$";
		actionClassuserDataLoadMain._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100.Adapt(delegate(ActionClassuserDataLoadMain _0024act_0024t_0024619)
		{
			string text = null;
			try
			{
				StreamReader streamReader;
				IDisposable disposable = (streamReader = new StreamReader(_0024act_0024t_0024619.f)) as IDisposable;
				try
				{
					text = streamReader.ReadToEnd();
				}
				finally
				{
					if (disposable != null)
					{
						disposable.Dispose();
						disposable = null;
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception("ファイルが空な無い");
				}
				string text2 = Crypt.Encrypt(text);
				if (string.IsNullOrEmpty(text2))
				{
					throw new Exception("ファイルが壊れている");
				}
				if (!UserData.Current.userMiscInfo.LoadFromStringWidthMd5(text2))
				{
					throw new Exception("jsonが間違っている");
				}
				_0024act_0024t_0024619.resultText = "多分ロードできた";
			}
			catch (Exception rhs)
			{
				string rhs2 = new StringBuilder("ファイル ").Append(_0024act_0024t_0024619.f).Append(" を読めませんでした。:\n").ToString() + rhs;
				_0024act_0024t_0024619.resultText = "ロード失敗。ログも見て。\n" + rhs2;
			}
		});
		actionClassuserDataLoadMain._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100.Adapt(delegate(ActionClassuserDataLoadMain _0024act_0024t_0024619)
		{
			RuntimeDebugModeGuiMixin.label("ロード結果:");
			RuntimeDebugModeGuiMixin.slabel(_0024act_0024t_0024619.resultText);
		});
		actionClassuserDataLoadMain._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable299_0024874_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024100.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				userDataUpDownLoadTest();
			}
		});
		return actionClassuserDataLoadMain;
	}

	public ActionClassuserDataLoadMain createuserDataLoadMain(string f)
	{
		ActionClassuserDataLoadMain actionClassuserDataLoadMain = createDatauserDataLoadMain();
		actionClassuserDataLoadMain.f = f;
		return actionClassuserDataLoadMain;
	}

	public ActionClassuserDataLoadMain2 userDataLoadMain2(string f)
	{
		ActionClassuserDataLoadMain2 actionClassuserDataLoadMain = createuserDataLoadMain2(f);
		changeAction(actionClassuserDataLoadMain);
		return actionClassuserDataLoadMain;
	}

	public ActionClassuserDataLoadMain2 createDatauserDataLoadMain2()
	{
		ActionClassuserDataLoadMain2 actionClassuserDataLoadMain = new ActionClassuserDataLoadMain2();
		actionClassuserDataLoadMain._0024act_0024t_0024561 = ActionEnum.userDataLoadMain2;
		actionClassuserDataLoadMain._0024act_0024t_0024562 = "$default$";
		actionClassuserDataLoadMain._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable300_0024906_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024101.Adapt(delegate(ActionClassuserDataLoadMain2 _0024act_0024t_0024623)
		{
			string text = null;
			try
			{
				StreamReader streamReader;
				IDisposable disposable = (streamReader = new StreamReader(_0024act_0024t_0024623.f)) as IDisposable;
				try
				{
					text = streamReader.ReadToEnd();
				}
				finally
				{
					if (disposable != null)
					{
						disposable.Dispose();
						disposable = null;
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					throw new Exception("ファイルが空な無い");
				}
				object obj = NGUIJson.jsonDecode(text);
				if (!(obj is Hashtable))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
				}
				Hashtable hashtable = (Hashtable)obj;
				if (hashtable == null)
				{
					throw new Exception("jsonが間違っている");
				}
				if (!UserData.Current.userMiscInfo.LoadFromHashtable(hashtable))
				{
					throw new Exception("なんかうまくロードできなかった");
				}
				_0024act_0024t_0024623.resultText = "多分ロードできた";
			}
			catch (Exception rhs)
			{
				string rhs2 = new StringBuilder("ファイル ").Append(_0024act_0024t_0024623.f).Append(" を読めませんでした。:\n").ToString() + rhs;
				_0024act_0024t_0024623.resultText = "ロード失敗。ログも見て。\n" + rhs2;
			}
		});
		actionClassuserDataLoadMain._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable300_0024906_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024101.Adapt(delegate(ActionClassuserDataLoadMain2 _0024act_0024t_0024623)
		{
			RuntimeDebugModeGuiMixin.label("ロード結果:");
			RuntimeDebugModeGuiMixin.slabel(_0024act_0024t_0024623.resultText);
		});
		actionClassuserDataLoadMain._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable300_0024906_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024101.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				userDataUpDownLoadTest();
			}
		});
		return actionClassuserDataLoadMain;
	}

	public ActionClassuserDataLoadMain2 createuserDataLoadMain2(string f)
	{
		ActionClassuserDataLoadMain2 actionClassuserDataLoadMain = createDatauserDataLoadMain2();
		actionClassuserDataLoadMain.f = f;
		return actionClassuserDataLoadMain;
	}

	public ActionClassfileSelectMode fileSelectMode(string dir, string ptn, __Req_FailHandler_0024callable6_0024440_32__ select, ICallable back)
	{
		ActionClassfileSelectMode actionClassfileSelectMode = createfileSelectMode(dir, ptn, select, back);
		changeAction(actionClassfileSelectMode);
		return actionClassfileSelectMode;
	}

	public ActionClassfileSelectMode createDatafileSelectMode()
	{
		ActionClassfileSelectMode actionClassfileSelectMode = new ActionClassfileSelectMode();
		actionClassfileSelectMode._0024act_0024t_0024561 = ActionEnum.fileSelectMode;
		actionClassfileSelectMode._0024act_0024t_0024562 = "$default$";
		actionClassfileSelectMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable301_0024937_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024102.Adapt(delegate(ActionClassfileSelectMode _0024act_0024t_0024626)
		{
			_0024act_0024t_0024626.baseDir = _0024act_0024t_0024626.dir;
		});
		actionClassfileSelectMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable301_0024937_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024102.Adapt(delegate(ActionClassfileSelectMode _0024act_0024t_0024626)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024626.baseDir).Append("/").Append(_0024act_0024t_0024626.ptn)
				.Append("からファイル選択")
				.ToString());
			if (_0024act_0024t_0024626.files == null)
			{
				RuntimeDebugModeGuiMixin.label("upload するファイル無いです");
			}
			else
			{
				int i = 0;
				string[] files = _0024act_0024t_0024626.files;
				for (int length = files.Length; i < length; i = checked(i + 1))
				{
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(files[i]).ToString()) && _0024act_0024t_0024626.select != null)
					{
						_0024act_0024t_0024626.select(files[i]);
					}
				}
			}
		});
		actionClassfileSelectMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable301_0024937_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024102.Adapt(delegate(ActionClassfileSelectMode _0024act_0024t_0024626)
		{
			if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024626.back != null)
			{
				_0024act_0024t_0024626.back.Call(new object[0]);
			}
		});
		return actionClassfileSelectMode;
	}

	public ActionClassfileSelectMode createfileSelectMode(string dir, string ptn, __Req_FailHandler_0024callable6_0024440_32__ select, ICallable back)
	{
		ActionClassfileSelectMode actionClassfileSelectMode = createDatafileSelectMode();
		actionClassfileSelectMode.dir = dir;
		actionClassfileSelectMode.ptn = ptn;
		actionClassfileSelectMode.select = select;
		actionClassfileSelectMode.back = back;
		return actionClassfileSelectMode;
	}

	public ActionClassquestMissionViewMode questMissionViewMode()
	{
		ActionClassquestMissionViewMode actionClassquestMissionViewMode = createquestMissionViewMode();
		changeAction(actionClassquestMissionViewMode);
		return actionClassquestMissionViewMode;
	}

	public ActionClassquestMissionViewMode createDataquestMissionViewMode()
	{
		ActionClassquestMissionViewMode actionClassquestMissionViewMode = new ActionClassquestMissionViewMode();
		actionClassquestMissionViewMode._0024act_0024t_0024561 = ActionEnum.questMissionViewMode;
		actionClassquestMissionViewMode._0024act_0024t_0024562 = "$default$";
		actionClassquestMissionViewMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable302_0024960_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024103.Adapt(checked(delegate
		{
			RuntimeDebugModeGuiMixin.label("Quest Missions");
			UserQuestMission userQuestMission = UserData.Current.userQuestMission;
			RuntimeDebugModeGuiMixin.slabel("NewQuestMissionIds:");
			RuntimeDebugModeGuiMixin.slabel("  " + Builtins.join(userQuestMission.NewQuestMissionIds, " "));
			RuntimeDebugModeGuiMixin.slabel("IsHasNewMission: " + userQuestMission.IsHasNewMission);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("QuestMissions: ");
			int i = 0;
			RespQuestMission[] questMissions = userQuestMission.QuestMissions;
			for (int length = questMissions.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("========== Id=").Append((object)questMissions[i].Id).Append(" ===========").ToString());
				RuntimeDebugModeGuiMixin.slabel("MQuestId: " + questMissions[i].MQuestId);
				RuntimeDebugModeGuiMixin.slabel("   Quest=" + MQuests.Get(questMissions[i].MQuestId));
				RuntimeDebugModeGuiMixin.slabel("Number: " + questMissions[i].Number);
				RuntimeDebugModeGuiMixin.slabel("MissionTypeValue: " + questMissions[i].MissionTypeValue);
				RuntimeDebugModeGuiMixin.slabel("BeginDate: " + questMissions[i].BeginDate);
				RuntimeDebugModeGuiMixin.slabel("EndDate: " + questMissions[i].EndDate);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue1: " + questMissions[i].ConditionTypeValue1);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter1: " + questMissions[i].ConditionParameter1);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue2: " + questMissions[i].ConditionTypeValue2);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter2: " + questMissions[i].ConditionParameter2);
				RuntimeDebugModeGuiMixin.slabel("Detail: " + questMissions[i].Detail);
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("ClearQuestMissions: ");
			int j = 0;
			RespQuestMission[] clearQuestMissions = userQuestMission.ClearQuestMissions;
			for (int length2 = clearQuestMissions.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("========== Id=").Append((object)clearQuestMissions[j].Id).Append(" ===========").ToString());
				RuntimeDebugModeGuiMixin.slabel("MQuestId: " + clearQuestMissions[j].MQuestId);
				RuntimeDebugModeGuiMixin.slabel("   Quest=" + MQuests.Get(clearQuestMissions[j].MQuestId));
				RuntimeDebugModeGuiMixin.slabel("Number: " + clearQuestMissions[j].Number);
				RuntimeDebugModeGuiMixin.slabel("MissionTypeValue: " + clearQuestMissions[j].MissionTypeValue);
				RuntimeDebugModeGuiMixin.slabel("BeginDate: " + clearQuestMissions[j].BeginDate);
				RuntimeDebugModeGuiMixin.slabel("EndDate: " + clearQuestMissions[j].EndDate);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue1: " + clearQuestMissions[j].ConditionTypeValue1);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter1: " + clearQuestMissions[j].ConditionParameter1);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue2: " + clearQuestMissions[j].ConditionTypeValue2);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter2: " + clearQuestMissions[j].ConditionParameter2);
				RuntimeDebugModeGuiMixin.slabel("Detail: " + clearQuestMissions[j].Detail);
			}
		}));
		actionClassquestMissionViewMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable302_0024960_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024103.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassquestMissionViewMode;
	}

	public ActionClassquestMissionViewMode createquestMissionViewMode()
	{
		return createDataquestMissionViewMode();
	}

	public ActionClasscolloseumEventViewMode colloseumEventViewMode()
	{
		ActionClasscolloseumEventViewMode actionClasscolloseumEventViewMode = createcolloseumEventViewMode();
		changeAction(actionClasscolloseumEventViewMode);
		return actionClasscolloseumEventViewMode;
	}

	public ActionClasscolloseumEventViewMode createDatacolloseumEventViewMode()
	{
		ActionClasscolloseumEventViewMode actionClasscolloseumEventViewMode = new ActionClasscolloseumEventViewMode();
		actionClasscolloseumEventViewMode._0024act_0024t_0024561 = ActionEnum.colloseumEventViewMode;
		actionClasscolloseumEventViewMode._0024act_0024t_0024562 = "$default$";
		actionClasscolloseumEventViewMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable303_00241000_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024104.Adapt(checked(delegate
		{
			UserData current = UserData.Current;
			RuntimeDebugModeGuiMixin.label("闘技場情報");
			RuntimeDebugModeGuiMixin.space(10);
			if (current.userBreeder != null)
			{
				RespBreeder userBreeder = current.userBreeder;
				RuntimeDebugModeGuiMixin.slabel("ブリーダーランク情報:");
				RuntimeDebugModeGuiMixin.slabel("Loss             : " + userBreeder.Loss);
				RuntimeDebugModeGuiMixin.slabel("Win              : " + userBreeder.Win);
				RuntimeDebugModeGuiMixin.slabel("BreederRankPoint : " + userBreeder.BreederRankPoint);
				RuntimeDebugModeGuiMixin.slabel("BreederRankId    : " + userBreeder.BreederRankId);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("ブリーダーランク情報無し");
			}
			UserColosseumEvent userColosseumEvent = current.userColosseumEvent;
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("イベント total ranking point: " + userColosseumEvent.ColosseumEventTotalRankingPoint);
			RuntimeDebugModeGuiMixin.space(10);
			if (userColosseumEvent.ColosseumEvent.Length > 0)
			{
				RespColosseumEvent[] colosseumEvent = userColosseumEvent.ColosseumEvent;
				int i = 0;
				RespColosseumEvent[] array = colosseumEvent;
				for (int length = array.Length; i < length; i++)
				{
					RuntimeDebugModeGuiMixin.label("イベント情報:");
					RuntimeDebugModeGuiMixin.slabel("Id                  : " + array[i].Id);
					RuntimeDebugModeGuiMixin.slabel("IsRankingEvent      : " + array[i].IsRankingEvent);
					RuntimeDebugModeGuiMixin.slabel("IsFriendCompetition : " + array[i].IsFriendCompetition);
					RuntimeDebugModeGuiMixin.slabel("FriendPoint         : " + array[i].FriendPoint);
					RuntimeDebugModeGuiMixin.slabel("Coin                : " + array[i].Coin);
					RuntimeDebugModeGuiMixin.slabel("BpCost              : " + array[i].BpCost);
					RuntimeDebugModeGuiMixin.slabel("BeginDate           : " + array[i].BeginDate);
					RuntimeDebugModeGuiMixin.slabel("EndDate             : " + array[i].EndDate);
					RuntimeDebugModeGuiMixin.slabel("ManaFragment        : " + array[i].ManaFragment);
					RuntimeDebugModeGuiMixin.slabel("IsCostLimit         : " + array[i].IsCostLimit);
					RuntimeDebugModeGuiMixin.slabel("CostLimit           : " + array[i].CostLimit);
					RuntimeDebugModeGuiMixin.slabel("IsElementLimit      : " + array[i].IsElementLimit);
					RuntimeDebugModeGuiMixin.slabel("ElementLimit        : " + array[i].ElementLimit);
					RuntimeDebugModeGuiMixin.slabel("IsStyleLimit        : " + array[i].IsStyleLimit);
					RuntimeDebugModeGuiMixin.slabel("StyleLimit          : " + array[i].StyleLimit);
					RuntimeDebugModeGuiMixin.slabel("IsMinRarityLimit    : " + array[i].IsMinRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("MinRarityLimit      : " + array[i].MinRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("IsMaxRarityLimit    : " + array[i].IsMaxRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("MaxRarityLimit      : " + array[i].MaxRarityLimit);
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("イベント情報無し");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (userColosseumEvent.ColosseumEventRanking != null)
			{
				RespColosseumEventRanking colosseumEventRanking = userColosseumEvent.ColosseumEventRanking;
				RuntimeDebugModeGuiMixin.slabel("イベントランキング情報:");
				RuntimeDebugModeGuiMixin.slabel("MColosseumEventId : " + colosseumEventRanking.MColosseumEventId);
				RuntimeDebugModeGuiMixin.slabel("TSocialPlayerId   : " + colosseumEventRanking.TSocialPlayerId);
				RuntimeDebugModeGuiMixin.slabel("Ranking           : " + colosseumEventRanking.Ranking);
				RuntimeDebugModeGuiMixin.slabel("RankingPoint      : " + colosseumEventRanking.RankingPoint);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("イベントランキング情報無し");
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("デイリー援護スキル");
			int j = 0;
			int[] dailyPassiveSkills = userColosseumEvent.DailyPassiveSkills;
			for (int length2 = dailyPassiveSkills.Length; j < length2; j++)
			{
				MCoverSkills rhs = MCoverSkills.Get(dailyPassiveSkills[j]);
				RuntimeDebugModeGuiMixin.slabel("  " + rhs);
			}
		}));
		actionClasscolloseumEventViewMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable303_00241000_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024104.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClasscolloseumEventViewMode;
	}

	public ActionClasscolloseumEventViewMode createcolloseumEventViewMode()
	{
		return createDatacolloseumEventViewMode();
	}

	public ActionClassquestTicketViewMode questTicketViewMode()
	{
		ActionClassquestTicketViewMode actionClassquestTicketViewMode = createquestTicketViewMode();
		changeAction(actionClassquestTicketViewMode);
		return actionClassquestTicketViewMode;
	}

	public ActionClassquestTicketViewMode createDataquestTicketViewMode()
	{
		ActionClassquestTicketViewMode actionClassquestTicketViewMode = new ActionClassquestTicketViewMode();
		actionClassquestTicketViewMode._0024act_0024t_0024561 = ActionEnum.questTicketViewMode;
		actionClassquestTicketViewMode._0024act_0024t_0024562 = "$default$";
		actionClassquestTicketViewMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable304_00241066_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024105.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Debug Tickets : ").Append(ticketDebug).ToString()))
			{
				ticketDebug = !ticketDebug;
			}
			if (ticketDebug)
			{
				RuntimeDebugModeGuiMixin.label(new StringBuilder("Icon:").Append(ticketIcon).ToString());
				ticketIcon = GUILayout.TextField(ticketIcon);
				RuntimeDebugModeGuiMixin.label(new StringBuilder("Explain:").Append(ticketExplain).ToString());
				ticketExplain = GUILayout.TextField(ticketExplain);
			}
			RuntimeDebugModeGuiMixin.label("チケット一覧");
			RuntimeDebugModeGuiMixin.space(10);
			RespPlayer userBasicInfo = UserData.Current.userBasicInfo;
			if (userBasicInfo != null)
			{
				RuntimeDebugModeGuiMixin.label("最終付与日: " + userBasicInfo.BeforeQuestTicketIssueDate);
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("最終付与日: 不明");
			}
			RespQuestTicket[] questTickets = UserData.Current.questTickets;
			if (questTickets != null)
			{
				RuntimeDebugModeGuiMixin.label("ticket num: " + questTickets.Length);
				int i = 0;
				RespQuestTicket[] array = questTickets;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					RuntimeDebugModeGuiMixin.space(10);
					showTicketInfo(array[i], new _0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959(array, i, this).Invoke);
				}
			}
		});
		actionClassquestTicketViewMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable304_00241066_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024105.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				MainMode();
			}
		});
		return actionClassquestTicketViewMode;
	}

	public ActionClassquestTicketViewMode createquestTicketViewMode()
	{
		return createDataquestTicketViewMode();
	}

	private void showTicketInfo(RespQuestTicket t, __DebugSubUserData_showTicketInfo_0024callable35_00241100_63__ ctrl)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("--- ticket Id:").Append((object)t.Id).Append(" -----").ToString());
		if (ctrl != null)
		{
			ctrl(t);
		}
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsAvailable: ").Append(t.IsAvailable).Append(" IsOpened: ").Append(t.IsOpened)
			.ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("IsUsed: ").Append(t.IsUsed).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("StartDate: ").Append(t.StartDate).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EndDate: ").Append(t.EndDate).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EffectiveTime: ").Append(t.EffectiveTime).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("ExpirationDate: ").Append(t.ExpirationDate).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("QuestIdList: ").Append(t.QuestIdList).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("MQuestTicketId: ").Append((object)t.MQuestTicketId).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Icon: ").Append(t.GetIcon()).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Expalin: ").Append(t.GetExplain()).ToString());
	}

	public ActionClassplayByThisTicket playByThisTicket(RespQuestTicket t)
	{
		ActionClassplayByThisTicket actionClassplayByThisTicket = createplayByThisTicket(t);
		changeAction(actionClassplayByThisTicket);
		return actionClassplayByThisTicket;
	}

	public ActionClassplayByThisTicket createDataplayByThisTicket()
	{
		ActionClassplayByThisTicket actionClassplayByThisTicket = new ActionClassplayByThisTicket();
		actionClassplayByThisTicket._0024act_0024t_0024561 = ActionEnum.playByThisTicket;
		actionClassplayByThisTicket._0024act_0024t_0024562 = "$default$";
		actionClassplayByThisTicket._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable305_00241114_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024106.Adapt(delegate(ActionClassplayByThisTicket _0024act_0024t_0024638)
		{
			_0024act_0024t_0024638.quests = new Boo.Lang.List<MQuests>();
			int i = 0;
			int[] questIds = _0024act_0024t_0024638.t.QuestIds;
			for (int length = questIds.Length; i < length; i = checked(i + 1))
			{
				MQuests mQuests = MQuests.Get(questIds[i]);
				if (mQuests != null)
				{
					_0024act_0024t_0024638.quests.Add(mQuests);
				}
			}
		});
		actionClassplayByThisTicket._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable305_00241114_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024106.Adapt(delegate(ActionClassplayByThisTicket _0024act_0024t_0024638)
		{
			showTicketInfo(_0024act_0024t_0024638.t, null);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("プレイするクエストを選択");
			IEnumerator<MQuests> enumerator = _0024act_0024t_0024638.quests.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					MQuests current = enumerator.Current;
					if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(current).ToString()))
					{
						MStories mStories = MQuests.FindStory(current);
						if (mStories != null)
						{
							QuestSession.StartSessionDebug(RuntimeDebugMode.Instance, mStories.Id, noSceneLoad: false);
							ExitDebugMode();
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		});
		actionClassplayByThisTicket._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable305_00241114_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024106.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				questTicketViewMode();
			}
		});
		return actionClassplayByThisTicket;
	}

	public ActionClassplayByThisTicket createplayByThisTicket(RespQuestTicket t)
	{
		ActionClassplayByThisTicket actionClassplayByThisTicket = createDataplayByThisTicket();
		actionClassplayByThisTicket.t = t;
		return actionClassplayByThisTicket;
	}

	public ActionClassuseTicketMode useTicketMode(int ticketId)
	{
		ActionClassuseTicketMode actionClassuseTicketMode = createuseTicketMode(ticketId);
		changeAction(actionClassuseTicketMode);
		return actionClassuseTicketMode;
	}

	public ActionClassuseTicketMode createDatauseTicketMode()
	{
		ActionClassuseTicketMode actionClassuseTicketMode = new ActionClassuseTicketMode();
		actionClassuseTicketMode._0024act_0024t_0024561 = ActionEnum.useTicketMode;
		actionClassuseTicketMode._0024act_0024t_0024562 = "$default$";
		actionClassuseTicketMode._0024act_0024t_0024563 = _0024adaptor_0024__DebugSubUserData_0024callable306_00241138_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024107.Adapt(delegate(ActionClassuseTicketMode _0024act_0024t_0024641)
		{
			_0024act_0024t_0024641.req = new ApiQuestUseTicket(_0024act_0024t_0024641.ticketId);
			MerlinServer.Request(_0024act_0024t_0024641.req);
		});
		actionClassuseTicketMode._0024act_0024t_0024567 = _0024adaptor_0024__DebugSubUserData_0024callable306_00241138_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024107.Adapt(delegate(ActionClassuseTicketMode _0024act_0024t_0024641)
		{
			if (_0024act_0024t_0024641.req.IsOk)
			{
				RuntimeDebugModeGuiMixin.label("使いました");
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					questTicketViewMode();
				}
			}
			else if (_0024act_0024t_0024641.req.IsEnd)
			{
				RuntimeDebugModeGuiMixin.label("なんかエラーでちゃった - " + _0024act_0024t_0024641.req.GameServerResponseStatusCode);
				RuntimeDebugModeGuiMixin.slabel("Error: " + _0024act_0024t_0024641.req.Error);
				if (RuntimeDebugModeGuiMixin.button("戻る"))
				{
					questTicketViewMode();
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("通信中...");
			}
		});
		actionClassuseTicketMode._0024act_0024t_0024565 = _0024adaptor_0024__DebugSubUserData_0024callable306_00241138_5___0024__ActionBase__0024act_0024t_0024563_0024callable33_0024179_5___0024107.Adapt(delegate
		{
			if (RuntimeDebugModeGuiMixin.InputBack)
			{
				questTicketViewMode();
			}
		});
		return actionClassuseTicketMode;
	}

	public ActionClassuseTicketMode createuseTicketMode(int ticketId)
	{
		ActionClassuseTicketMode actionClassuseTicketMode = createDatauseTicketMode();
		actionClassuseTicketMode.ticketId = ticketId;
		return actionClassuseTicketMode;
	}

	internal void _0024createDataMainMode_0024closure_00242808(ActionClassMainMode _0024act_0024t_0024560)
	{
		_0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313 _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024 = new _0024_0024createDataMainMode_0024closure_00242808_0024locals_002414313();
		_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud = UserData.Current;
		if (_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242809(_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024, this).Invoke));
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("Etcflags"))
			{
				EtcFlagMode();
			}
			if (RuntimeDebugModeGuiMixin.button("diary"))
			{
				DiaryMode();
			}
			if (RuntimeDebugModeGuiMixin.button("UserData misc data"))
			{
				CurrentUserDataMode();
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("作成ユーザー履歴"))
			{
				CreatedUserHistoryMode();
			}
			if (RuntimeDebugModeGuiMixin.button("今セーブ"))
			{
				UserData.Current.userMiscInfo.AllowToSave();
				UserData.Current.userMiscInfo.Save();
			}
			if (RuntimeDebugModeGuiMixin.button("今ロード"))
			{
				UserData.Current.userMiscInfo.Load();
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("QuestTickets"))
		{
			questTicketViewMode();
		}
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			if (RuntimeDebugModeGuiMixin.button("ColosseumEvent"))
			{
				colloseumEventViewMode();
			}
			if (RuntimeDebugModeGuiMixin.button("QuestMission"))
			{
				questMissionViewMode();
			}
		});
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("weapon num: " + _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.BoxWeaponNum);
		RuntimeDebugModeGuiMixin.slabel("poppet num: " + _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.BoxPoppetNum);
		RuntimeDebugModeGuiMixin.space(30);
		int titleWidth = 250;
		RespPlayerInfo userStatus = _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.userStatus;
		RuntimeDebugModeGuiMixin.snamevalue("Id", userStatus.Id, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Exp", userStatus.Exp, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Level", userStatus.Level, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Ap", userStatus.Ap, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Rp", userStatus.Rp, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Fp", userStatus.Fp, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("AngelGender", userStatus.AngelGender, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("AngelName", userStatus.AngelName, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("BeforeApRecoveryDateTime", userStatus.BeforeApRecoveryDateTime, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("BeforeRpRecoveryDateTime", userStatus.BeforeRpRecoveryDateTime, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("BoxExtensionCount", userStatus.BoxExtensionCount, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("BoxSize", userStatus.BoxSize, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Coin", userStatus.Coin, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("DemonGender", userStatus.DemonGender, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("DemonName", userStatus.DemonName, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("FayStone", userStatus.FayStone, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("FriendLimit", userStatus.FriendLimit, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("IsTutorialFin", userStatus.IsTutorialFin, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("PoppetName", userStatus.PoppetName, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("Rgp", userStatus.Rgp, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TGuildCd", userStatus.TGuildCd, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TPartyId", userStatus.TPartyId, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TPlayerDeckNo", userStatus.TPlayerDeckNo, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TPlayerId", userStatus.TPlayerId, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TSocialPlayerId", userStatus.TSocialPlayerId, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("TutorialStep", userStatus.TutorialStep, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("WeaponCostLimit", userStatus.WeaponCostLimit, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("ManaFragment", userStatus.ManaFragment, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("CreateDate", userStatus.CreateDate, titleWidth);
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.snamevalue("EndApRecoveryDateTime", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.EndApRecoveryDateTime, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("EndRpRecoveryDateTime", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.EndRpRecoveryDateTime, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("UserData.AP", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.Ap, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("UserData.RP", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.Rp, titleWidth);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.snamevalue("bgmLoad", UserData.Current.userMiscInfo.bgmLoad, titleWidth);
		RuntimeDebugModeGuiMixin.snamevalue("xDisplayedNewFeatureId", UserData.Current.getIntFlag("xDisplayedNewFeatureId", 0), titleWidth);
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("RaidBattle as RespTCycleRaidBattles: ");
		RespTCycleRaidBattle raidBattle = _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.userRaidInfo.raidBattle;
		if (raidBattle == null)
		{
			RuntimeDebugModeGuiMixin.slabel("<no raid battle data>");
		}
		else
		{
			RuntimeDebugModeGuiMixin.snamevalue("Id", raidBattle.Id, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("TCycleId", raidBattle.TCycleId, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("StyleId", raidBattle.StyleId, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("ElementId", raidBattle.ElementId, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("ComboStartDate", raidBattle.ComboStartDate, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("ComboLevel", raidBattle.ComboLevel, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("MMonsterId", raidBattle.MMonsterId, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("NumberOfTimes", raidBattle.NumberOfTimes, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("DiscoverSocialPlayerId", raidBattle.DiscoverSocialPlayerId, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("DiscoverDate", raidBattle.DiscoverDate, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("Level", raidBattle.Level, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("LevelCorrection", raidBattle.LevelCorrection, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("InitialHp", raidBattle.InitialHp, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("Hp", raidBattle.Hp, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("PhotonServer", raidBattle.PhotonServer, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("RoomName", raidBattle.RoomName, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("IsActive", raidBattle.IsActive, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("IsDetectionElement", raidBattle.IsDetectionElement, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("IsDetectionStyle", raidBattle.IsDetectionStyle, titleWidth);
			RuntimeDebugModeGuiMixin.snamevalue("IsDescover", raidBattle.IsDiscover, titleWidth);
		}
		RuntimeDebugModeGuiMixin.slabel("LastRaidCycleId = " + UserData.Current.userMiscInfo.raidData.LastRaidCycleId);
		if (RuntimeDebugModeGuiMixin.button("delete LastRaidCycleId"))
		{
			UserData.Current.userMiscInfo.raidData.LastRaidCycleId = -1;
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("other information: ");
		RuntimeDebugModeGuiMixin.snamevalue("inviteCode", _0024_0024createDataMainMode_0024closure_00242808_0024locals_0024._0024ud.inviteCode, titleWidth);
		if (RuntimeDebugModeGuiMixin.button("loginBonusもらったフリをする"))
		{
			MerlinServer.ExRequest(new ApiHome(), _0024adaptor_0024__MerlinServer_Home_0024callable87_0024671_34___0024__MerlinServer_Request_0024callable86_0024160_56___0024108.Adapt(new _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242813(_0024_0024createDataMainMode_0024closure_00242808_0024locals_0024).Invoke));
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242810()
	{
		if (RuntimeDebugModeGuiMixin.button("Etcflags"))
		{
			EtcFlagMode();
		}
		if (RuntimeDebugModeGuiMixin.button("diary"))
		{
			DiaryMode();
		}
		if (RuntimeDebugModeGuiMixin.button("UserData misc data"))
		{
			CurrentUserDataMode();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242811()
	{
		if (RuntimeDebugModeGuiMixin.button("作成ユーザー履歴"))
		{
			CreatedUserHistoryMode();
		}
		if (RuntimeDebugModeGuiMixin.button("今セーブ"))
		{
			UserData.Current.userMiscInfo.AllowToSave();
			UserData.Current.userMiscInfo.Save();
		}
		if (RuntimeDebugModeGuiMixin.button("今ロード"))
		{
			UserData.Current.userMiscInfo.Load();
		}
	}

	internal void _0024_0024createDataMainMode_0024closure_00242808_0024closure_00242812()
	{
		if (RuntimeDebugModeGuiMixin.button("ColosseumEvent"))
		{
			colloseumEventViewMode();
		}
		if (RuntimeDebugModeGuiMixin.button("QuestMission"))
		{
			questMissionViewMode();
		}
	}

	internal void _0024createDataMainMode_0024closure_00242815(ActionClassMainMode _0024act_0024t_0024560)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			KillMe();
		}
	}

	internal void _0024createDataWeaponBoxMode_0024closure_00242816(ActionClassWeaponBoxMode _0024act_0024t_0024576)
	{
		UserData current = UserData.Current;
		if (current == null || current.BoxWeapons == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		int i = 0;
		RespWeapon[] boxWeapons = current.BoxWeapons;
		for (int length = boxWeapons.Length; i < length; i = checked(i + 1))
		{
			int attackPlusBonus = boxWeapons[i].RefPlayerBox.AttackPlusBonus;
			int hpPlusBonus = boxWeapons[i].RefPlayerBox.HpPlusBonus;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(boxWeapons[i].Id).Append(": ").Append(boxWeapons[i].Name)
				.Append(" L=")
				.Append((object)boxWeapons[i].Level)
				.Append("/")
				.Append((object)boxWeapons[i].LevelMax)
				.Append(" E=")
				.Append((object)boxWeapons[i].Exp)
				.Append(" M=")
				.Append((object)boxWeapons[i].MWeaponId)
				.Append(" ICON=")
				.Append(boxWeapons[i].Icon)
				.Append(" Exp=")
				.Append((object)boxWeapons[i].Exp)
				.Append(" LR:")
				.Append((object)boxWeapons[i].LevelLimitMin)
				.Append("-")
				.Append((object)boxWeapons[i].LevelLimitMax)
				.Append(" LvBr=")
				.Append((object)boxWeapons[i].LimitBreakCount)
				.Append(" SL=")
				.Append((object)boxWeapons[i].AngelSkillLevel)
				.Append(" ")
				.Append((object)boxWeapons[i].DemonSkillLevel)
				.Append(" T=")
				.Append((object)boxWeapons[i].TraitId)
				.Append(" P=")
				.Append((object)attackPlusBonus)
				.Append("/")
				.Append((object)hpPlusBonus)
				.ToString());
		}
	}

	internal void _0024createDataWeaponBoxMode_0024closure_00242817(ActionClassWeaponBoxMode _0024act_0024t_0024576)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataPoppetBoxMode_0024closure_00242818(ActionClassPoppetBoxMode _0024act_0024t_0024579)
	{
		UserData current = UserData.Current;
		if (current == null || current.BoxPoppets == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		int i = 0;
		RespPoppet[] boxPoppets = current.BoxPoppets;
		for (int length = boxPoppets.Length; i < length; i = checked(i + 1))
		{
			int attackPlusBonus = boxPoppets[i].RefPlayerBox.AttackPlusBonus;
			int hpPlusBonus = boxPoppets[i].RefPlayerBox.HpPlusBonus;
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder().Append(boxPoppets[i].Id).Append(": ").Append(boxPoppets[i].Name)
				.Append(" L=")
				.Append((object)boxPoppets[i].Level)
				.Append("/")
				.Append((object)boxPoppets[i].LevelMax)
				.Append(" E=")
				.Append((object)boxPoppets[i].Exp)
				.Append(" M=")
				.Append((object)boxPoppets[i].MPoppetId)
				.Append(" ICON=")
				.Append(boxPoppets[i].Icon)
				.Append(" Exp=")
				.Append((object)boxPoppets[i].Exp)
				.Append(" SL=")
				.Append((object)boxPoppets[i].CoverSkillLevel_1)
				.Append(" ")
				.Append((object)boxPoppets[i].CoverSkillLevel_2)
				.Append(" ")
				.Append((object)boxPoppets[i].ChainSkillLevel)
				.Append(" T=")
				.Append((object)boxPoppets[i].TraitId)
				.Append(" P=")
				.Append((object)attackPlusBonus)
				.Append("/")
				.Append((object)hpPlusBonus)
				.ToString());
		}
	}

	internal void _0024createDataPoppetBoxMode_0024closure_00242819(ActionClassPoppetBoxMode _0024act_0024t_0024579)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataDeckMode_0024closure_00242820(ActionClassDeckMode _0024act_0024t_0024582)
	{
		UserData current = UserData.Current;
		int num;
		if (current.IsValidDeck2)
		{
			UserDeckData2 userDeckData = UserData.Current.userDeckData2;
			num = userDeckData.deckNum();
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("新デッキモードユーザー!");
			RuntimeDebugModeGuiMixin.label("デッキ数: " + num);
			RuntimeDebugModeGuiMixin.space(10);
			string[] texts = ArrayMap.RangeToStr(num, (int i) => new StringBuilder().Append((object)i).ToString());
			_0024act_0024t_0024582.curDeckIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024582.curDeckIdx, texts, 5);
			RuntimeDebugModeGuiMixin.space(10);
			if (_0024act_0024t_0024582.curDeckIdx < num)
			{
				RespDeck2[] all = userDeckData.All;
				newDeckView(all[RuntimeServices.NormalizeArrayIndex(all, _0024act_0024t_0024582.curDeckIdx)], new StringBuilder("DECK ").Append((object)_0024act_0024t_0024582.curDeckIdx).ToString());
			}
		}
		else
		{
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("旧デッキモードユーザー");
			RuntimeDebugModeGuiMixin.space(10);
			oldDeckMode();
		}
		RuntimeDebugModeGuiMixin.space(20);
		RuntimeDebugModeGuiMixin.label("(闘技場)魔ペットデッキ");
		UserPoppetDeckData userPoppetDeckData = UserData.Current.userPoppetDeckData;
		num = userPoppetDeckData.deckNum();
		if (num > 0)
		{
			string[] texts2 = ArrayMap.RangeToStr(num, (int i) => new StringBuilder().Append((object)i).ToString());
			_0024act_0024t_0024582.curPoppetDeckIdx = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024582.curPoppetDeckIdx, texts2, num);
			RuntimeDebugModeGuiMixin.space(10);
			if (_0024act_0024t_0024582.curPoppetDeckIdx < num)
			{
				RespPoppetDeck[] all2 = userPoppetDeckData.All;
				poppetDeckView(all2[RuntimeServices.NormalizeArrayIndex(all2, _0024act_0024t_0024582.curPoppetDeckIdx)], new StringBuilder("DECK ").Append((object)_0024act_0024t_0024582.curPoppetDeckIdx).ToString());
			}
		}
		else
		{
			RuntimeDebugModeGuiMixin.label("   魔ペットデッキデータなし");
		}
	}

	internal string _0024_0024createDataDeckMode_0024closure_00242820_0024closure_00242821(int i)
	{
		return new StringBuilder().Append((object)i).ToString();
	}

	internal string _0024_0024createDataDeckMode_0024closure_00242820_0024closure_00242822(int i)
	{
		return new StringBuilder().Append((object)i).ToString();
	}

	internal void _0024createDataDeckMode_0024closure_00242823(ActionClassDeckMode _0024act_0024t_0024582)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataFlagMode_0024closure_00242825(ActionClassFlagMode _0024act_0024t_0024585)
	{
		_0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314 _0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024 = new _0024_0024createDataFlagMode_0024closure_00242825_0024locals_002414314();
		int titleWidth = 250;
		UserData current = UserData.Current;
		if (current == null || current.userDeckData == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		RuntimeDebugModeGuiMixin.slabel("Player flags");
		_0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024._0024flagData = current.userMiscInfo.flagData;
		__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242826(_0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024).Invoke;
		TutorialSwitch();
		RuntimeDebugModeGuiMixin.space(5);
		GUIStyle gUIStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
		gUIStyle.fontSize = 14;
		gUIStyle.alignment = TextAnchor.LowerLeft;
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.slabel(new StringBuilder("[").Append(flagFilterName).Append("]+[").Append(storyFilterName)
				.Append("]のフラグ一括設定")
				.ToString());
			if (RuntimeDebugModeGuiMixin.button("一括ON"))
			{
				bulkSetFlag(currentFlagFilter + currentStoryFilter, b: true);
			}
			if (RuntimeDebugModeGuiMixin.button("一括OFF"))
			{
				bulkSetFlag(currentFlagFilter + currentStoryFilter, b: false);
			}
		});
		RuntimeDebugModeGuiMixin.slabel("フラグタイプ表示フィルタ");
		listWithFilter(flag_filter_label, new __Req_FailHandler_0024callable6_0024440_32__(applyFilterToFlags), ref currentFlagFilter);
		RuntimeDebugModeGuiMixin.slabel("話数表示フィルタ ↑と組み合わせて使う");
		GUILayout.BeginHorizontal();
		IEnumerator<object[]> enumerator = Builtins.enumerate(story_filter_label).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object[] current2 = enumerator.Current;
				int num = RuntimeServices.UnboxInt32(current2[0]);
				object obj = current2[1];
				if (!(obj is string[]))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string[]));
				}
				string[] array = (string[])obj;
				if (num % 8 == 0 && num > 0)
				{
					GUILayout.EndHorizontal();
					GUILayout.BeginHorizontal();
				}
				if (GUILayout.Button(array[0] as string))
				{
					storyFilterName = array[0];
					currentStoryFilter = array[1] as string;
					applyFilterToFlags(currentFlagFilter, currentStoryFilter);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		GUILayout.EndHorizontal();
		RuntimeDebugModeGuiMixin.space(5);
		RuntimeDebugModeGuiMixin.horizontal((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			RuntimeDebugModeGuiMixin.slabel("S: シナリオ進行");
			RuntimeDebugModeGuiMixin.slabel("q: クエスト開放");
			RuntimeDebugModeGuiMixin.slabel("t: クエストギミック");
			RuntimeDebugModeGuiMixin.slabel("x: 謎");
			RuntimeDebugModeGuiMixin.slabel("v: シーン visit");
		});
		if (RuntimeDebugModeGuiMixin.button("詳細"))
		{
			detail = !detail;
		}
		if (!detail)
		{
			return;
		}
		IEnumerator<object> enumerator2 = flags.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is MFlags))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(MFlags));
				}
				MFlags mFlags = (MFlags)obj2;
				bool value = _0024_0024createDataFlagMode_0024closure_00242825_0024locals_0024._0024flagData.getInt(mFlags.Progname) > 0;
				snamevaluetoggle(mFlags.Progname, value, titleWidth, func);
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}

	internal void _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242827()
	{
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("[").Append(flagFilterName).Append("]+[").Append(storyFilterName)
			.Append("]のフラグ一括設定")
			.ToString());
		if (RuntimeDebugModeGuiMixin.button("一括ON"))
		{
			bulkSetFlag(currentFlagFilter + currentStoryFilter, b: true);
		}
		if (RuntimeDebugModeGuiMixin.button("一括OFF"))
		{
			bulkSetFlag(currentFlagFilter + currentStoryFilter, b: false);
		}
	}

	internal void _0024_0024createDataFlagMode_0024closure_00242825_0024closure_00242828()
	{
		RuntimeDebugModeGuiMixin.slabel("S: シナリオ進行");
		RuntimeDebugModeGuiMixin.slabel("q: クエスト開放");
		RuntimeDebugModeGuiMixin.slabel("t: クエストギミック");
		RuntimeDebugModeGuiMixin.slabel("x: 謎");
		RuntimeDebugModeGuiMixin.slabel("v: シーン visit");
	}

	internal void _0024createDataFlagMode_0024closure_00242829(ActionClassFlagMode _0024act_0024t_0024585)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataEtcFlagMode_0024closure_00242830(ActionClassEtcFlagMode _0024act_0024t_0024588)
	{
		_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315 _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024 = new _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_002414315();
		int titleWidth = 250;
		UserData current = UserData.Current;
		if (current == null || current.userDeckData == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Player quests");
		Hashtable hashtable = current.userMiscInfo.questData.Flags;
		if (hashtable == null || hashtable.Count == 0)
		{
			RuntimeDebugModeGuiMixin.slabel("<no quests>");
		}
		else
		{
			if (RuntimeDebugModeGuiMixin.button("All Clear"))
			{
				hashtable.Clear();
			}
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current2 = enumerator.Current;
				int result = 0;
				MQuests mQuests = null;
				object obj = current2;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				if (int.TryParse((string)obj, out result))
				{
					mQuests = MQuests.Get(result);
				}
				if (mQuests != null)
				{
					RuntimeDebugModeGuiMixin.snamevalue("    " + current2, mQuests.GetName(), titleWidth);
				}
				else
				{
					RuntimeDebugModeGuiMixin.snamevalue("    " + current2, "No MQuests", titleWidth);
				}
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Player areas");
		Hashtable hashtable2 = current.userMiscInfo.areaData.Flags;
		if (hashtable2 == null || hashtable2.Count == 0)
		{
			RuntimeDebugModeGuiMixin.slabel("<no areas>");
		}
		else
		{
			if (RuntimeDebugModeGuiMixin.button("All Clear"))
			{
				hashtable2.Clear();
			}
			IEnumerator enumerator2 = hashtable2.Keys.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object current3 = enumerator2.Current;
				object obj2 = current3;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				MAreas mAreas = MAreas.Get(int.Parse((string)obj2));
				RuntimeDebugModeGuiMixin.snamevalue("    " + current3, mAreas.GetName(), titleWidth);
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Player treasure");
		Hashtable treasure = current.userMiscInfo.treasureData.Treasure;
		if (treasure == null || treasure.Count == 0)
		{
			RuntimeDebugModeGuiMixin.slabel("<no treasures>");
		}
		else
		{
			if (RuntimeDebugModeGuiMixin.button("All Clear"))
			{
				treasure.Clear();
			}
			IEnumerator enumerator3 = treasure.Keys.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				object obj3 = enumerator3.Current;
				if (!(obj3 is string))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(string));
				}
				string text = (string)obj3;
				MQuests mQuests2 = MQuests.Get(int.Parse(text));
				object obj4 = treasure[text];
				if (!(obj4 is Hashtable))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(Hashtable));
				}
				Hashtable hashtable3 = (Hashtable)obj4;
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("    ").Append(mQuests2.GetName()).Append("(QuestId:").Append(text)
					.Append(")")
					.ToString());
				IEnumerator enumerator4 = hashtable3.Keys.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					object obj5 = enumerator4.Current;
					if (!(obj5 is string))
					{
						obj5 = RuntimeServices.Coerce(obj5, typeof(string));
					}
					string text2 = (string)obj5;
					if (text2.StartsWith("w"))
					{
						MWeapons mWeapons = MWeapons.Get(int.Parse(text2.Substring(1)));
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mWeapons.Name).Append("(ItemId:").Append(text2)
							.Append("):")
							.Append(hashtable3[text2])
							.ToString());
					}
					else if (text2.StartsWith("p"))
					{
						MPoppets mPoppets = MPoppets.Get(int.Parse(text2.Substring(1)));
						RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mPoppets.Name).Append("(ItemId:").Append(text2)
							.Append("):")
							.Append(hashtable3[text2])
							.ToString());
					}
				}
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Player Weapon PicBook");
		Hashtable hashtable4 = current.userMiscInfo.weaponBookData.Flags;
		if (hashtable4 == null || hashtable4.Count == 0)
		{
			RuntimeDebugModeGuiMixin.slabel("<no Weapon>");
		}
		else
		{
			if (RuntimeDebugModeGuiMixin.button("All Clear"))
			{
				hashtable4.Clear();
			}
			IEnumerator enumerator5 = hashtable4.Keys.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				object current4 = enumerator5.Current;
				object obj6 = current4;
				if (!(obj6 is string))
				{
					obj6 = RuntimeServices.Coerce(obj6, typeof(string));
				}
				MWeapons mWeapons2 = MWeapons.Get(int.Parse((string)obj6));
				if (mWeapons2 != null)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mWeapons2.Name).ToString());
				}
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Player Poppet PicBook");
		Hashtable hashtable5 = current.userMiscInfo.poppetBookData.Flags;
		if (hashtable5 == null || hashtable5.Count == 0)
		{
			RuntimeDebugModeGuiMixin.slabel("<no Poppet>");
		}
		else
		{
			if (RuntimeDebugModeGuiMixin.button("All Clear"))
			{
				hashtable5.Clear();
			}
			IEnumerator enumerator6 = hashtable5.Keys.GetEnumerator();
			while (enumerator6.MoveNext())
			{
				object current5 = enumerator6.Current;
				object obj7 = current5;
				if (!(obj7 is string))
				{
					obj7 = RuntimeServices.Coerce(obj7, typeof(string));
				}
				MPoppets mPoppets2 = MPoppets.Get(int.Parse((string)obj7));
				if (mPoppets2 != null)
				{
					RuntimeDebugModeGuiMixin.slabel(new StringBuilder("      ").Append(mPoppets2.Name).ToString());
				}
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("Story");
		_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData = current.userMiscInfo.storyData;
		checked
		{
			if (RuntimeDebugModeGuiMixin.button("All"))
			{
				int i = 0;
				MStories[] all = MStories.All;
				for (int length = all.Length; i < length; i++)
				{
					bool flag = _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.getInt(all[i].Progname) > 0;
					if (!flag)
					{
						_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.set(all[i].Progname, 1);
					}
					if (flag)
					{
						_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.delete(all[i].Progname);
					}
				}
			}
			__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataEtcFlagMode_0024closure_00242830_0024closure_00242831(_0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024).Invoke;
			int j = 0;
			MStories[] all2 = MStories.All;
			for (int length2 = all2.Length; j < length2; j++)
			{
				bool flag = _0024_0024createDataEtcFlagMode_0024closure_00242830_0024locals_0024._0024storyData.getInt(all2[j].Progname) > 0;
				snamevaluetoggle(all2[j].Progname, flag, titleWidth, func);
			}
		}
	}

	internal void _0024createDataEtcFlagMode_0024closure_00242832(ActionClassEtcFlagMode _0024act_0024t_0024588)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataCurrentUserDataMode_0024closure_00242833(ActionClassCurrentUserDataMode _0024act_0024t_0024591)
	{
		UserData current = UserData.Current;
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("ApRecoverySec: ").Append(UserData.ApRecoverySec).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("RpRecoverySec: ").Append(UserData.RpRecoverySec).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EndApRecoveryDateTime: ").Append(current.EndApRecoveryDateTime).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("EndRpRecoveryDateTime: ").Append(current.EndRpRecoveryDateTime).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.Ap: ").Append((object)current.userStatus.Ap).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.Rp: ").Append((object)current.userStatus.Rp).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.BeforeApRecoveryDateTime: ").Append(current.userStatus.BeforeApRecoveryDateTime).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("userStatus.BeforeRpRecoveryDateTime: ").Append(current.userStatus.BeforeRpRecoveryDateTime).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Ap: ").Append((object)current.Ap).ToString());
		RuntimeDebugModeGuiMixin.slabel(new StringBuilder("Rp: ").Append((object)current.Rp).ToString());
	}

	internal void _0024createDataCurrentUserDataMode_0024closure_00242834(ActionClassCurrentUserDataMode _0024act_0024t_0024591)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataDiaryMode_0024closure_00242835(ActionClassDiaryMode _0024act_0024t_0024594)
	{
		_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316 _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024 = new _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_002414316();
		int titleWidth = 250;
		UserData current = UserData.Current;
		if (current == null || current.userDeckData == null)
		{
			RuntimeDebugModeGuiMixin.slabel("UserData is not available?");
			return;
		}
		_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData = current.userMiscInfo.flagData;
		_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData = current.userMiscInfo.storyData;
		__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func = new _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242836(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024).Invoke;
		__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ func2 = new _0024_0024createDataDiaryMode_0024closure_00242835_0024closure_00242837(_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024).Invoke;
		RuntimeDebugModeGuiMixin.space(30);
		RuntimeDebugModeGuiMixin.slabel("<Saboten Diary>");
		int i = 0;
		MStoryBooks[] all = MStoryBooks.All;
		checked
		{
			for (int length = all.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("■ ").Append(all[i].Progname).Append(":").Append(all[i].GetTitle())
					.ToString());
				bool flag = true;
				RuntimeDebugModeGuiMixin.slabel("・ストーリー：");
				MStories mStoryId = all[i].MStoryId;
				bool flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.getInt(mStoryId.Progname) > 0;
				bool num = flag;
				if (num)
				{
					num = flag2;
				}
				flag = num;
				snamevaluetoggle(mStoryId.Progname, flag2, titleWidth, func2);
				RuntimeDebugModeGuiMixin.slabel("・必須フラグ：");
				int j = 0;
				MFlags[] allConditions = all[i].AllConditions;
				for (int length2 = allConditions.Length; j < length2; j++)
				{
					flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.getInt(allConditions[j].Progname) > 0;
					bool num2 = flag;
					if (num2)
					{
						num2 = flag2;
					}
					flag = num2;
					snamevaluetoggle(allConditions[j].Progname, flag2, titleWidth, func);
				}
				RuntimeDebugModeGuiMixin.slabel("・不要フラグ：");
				int k = 0;
				MFlags[] allNotConditions = all[i].AllNotConditions;
				for (int length3 = allNotConditions.Length; k < length3; k++)
				{
					flag2 = _0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.getInt(allNotConditions[k].Progname) > 0;
					bool num3 = flag;
					if (num3)
					{
						num3 = flag2;
					}
					flag = num3;
					snamevaluetoggle(allNotConditions[k].Progname, !flag2, titleWidth, func);
				}
				if (!RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(flag).ToString()))
				{
					continue;
				}
				mStoryId = all[i].MStoryId;
				flag2 = flag;
				if (!flag2)
				{
					_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.set(mStoryId.Progname, 1);
				}
				if (flag2)
				{
					_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024storyData.delete(mStoryId.Progname);
				}
				int l = 0;
				MFlags[] allConditions2 = all[i].AllConditions;
				for (int length4 = allConditions2.Length; l < length4; l++)
				{
					if (!flag2)
					{
						_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.set(allConditions2[l].Progname, 1);
					}
					if (flag2)
					{
						_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.delete(allConditions2[l].Progname);
					}
				}
				int m = 0;
				MFlags[] allNotConditions2 = all[i].AllNotConditions;
				for (int length5 = allNotConditions2.Length; m < length5; m++)
				{
					if (flag2)
					{
						_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.set(allNotConditions2[m].Progname, 1);
					}
					if (!flag2)
					{
						_0024_0024createDataDiaryMode_0024closure_00242835_0024locals_0024._0024flagData.delete(allNotConditions2[m].Progname);
					}
				}
			}
		}
	}

	internal void _0024createDataDiaryMode_0024closure_00242838(ActionClassDiaryMode _0024act_0024t_0024594)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataCreatedUserHistoryMode_0024closure_00242839(ActionClassCreatedUserHistoryMode _0024act_0024t_0024597)
	{
		UUIDHistory.Load();
	}

	internal void _0024createDataCreatedUserHistoryMode_0024closure_00242840(ActionClassCreatedUserHistoryMode _0024act_0024t_0024597)
	{
		RuntimeDebugModeGuiMixin.label("現UUID: " + CurrentInfo.UUID);
		RuntimeDebugModeGuiMixin.slabel("履歴数: " + UUIDHistory.Count);
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("履歴クリア"))
		{
			UUIDHistory.Clear();
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("現ユーザーデータをサーバーへ保存"))
		{
			SaveUserDataMode();
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("現ユーザーデータをサーバーからロード"))
		{
			LoadUserDataMode();
		}
		RuntimeDebugModeGuiMixin.label("ユーザー変更後は再起動してください。");
		RuntimeDebugModeGuiMixin.space(10);
		int i = 0;
		UUIDHistory.Entry[] allEntries = UUIDHistory.AllEntries;
		for (int length = allEntries.Length; i < length; i = checked(i + 1))
		{
			string text = allEntries[i].ToString();
			if (allEntries[i].uuid == CurrentInfo.UUID)
			{
				text += " [現在]";
			}
			if (RuntimeDebugModeGuiMixin.button(text))
			{
				ChangeUUIDMode(allEntries[i].uuid);
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("Resources/Misc/UUIDHistory.txt読む"))
		{
			LoadUUIDsFromResources();
		}
	}

	internal void _0024createDataCreatedUserHistoryMode_0024closure_00242841(ActionClassCreatedUserHistoryMode _0024act_0024t_0024597)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataSaveUserDataMode_0024closure_00242842(ActionClassSaveUserDataMode _0024act_0024t_0024600)
	{
		MerlinServer.ExRequest(ApiLocalDataUpload.WithUserData(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			UserData.Current.userMiscInfo.Save();
			CreatedUserHistoryMode();
		}));
	}

	internal void _0024_0024createDataSaveUserDataMode_0024closure_00242842_0024closure_00242843()
	{
		UserData.Current.userMiscInfo.Save();
		CreatedUserHistoryMode();
	}

	internal void _0024createDataSaveUserDataMode_0024closure_00242844(ActionClassSaveUserDataMode _0024act_0024t_0024600)
	{
		RuntimeDebugModeGuiMixin.label("通信中");
		RuntimeDebugModeGuiMixin.slabel("ユーザーデータの保存中");
	}

	internal void _0024createDataLoadUserDataMode_0024closure_00242845(ActionClassLoadUserDataMode _0024act_0024t_0024603)
	{
		MerlinServer.ExRequest(new ApiLocalDataDownload(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			CreatedUserHistoryMode();
		}));
	}

	internal void _0024_0024createDataLoadUserDataMode_0024closure_00242845_0024closure_00242846()
	{
		CreatedUserHistoryMode();
	}

	internal void _0024createDataLoadUserDataMode_0024closure_00242847(ActionClassLoadUserDataMode _0024act_0024t_0024603)
	{
		RuntimeDebugModeGuiMixin.label("通信中");
		RuntimeDebugModeGuiMixin.slabel("ユーザーデータのdownload中");
	}

	internal void _0024createDataChangeUUIDMode_0024closure_00242848(ActionClassChangeUUIDMode _0024act_0024t_0024606)
	{
		_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317 _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024 = new _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_002414317();
		_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024._0024_0024act_0024t_0024606 = _0024act_0024t_0024606;
		MerlinServer.ExRequest(ApiLocalDataUpload.WithUserData(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849(_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024locals_0024, this).Invoke));
	}

	internal void _0024_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849_0024closure_00243934()
	{
		StorageHUD.DoUpdateNow();
	}

	internal void _0024_0024_0024createDataChangeUUIDMode_0024closure_00242848_0024closure_00242849_0024closure_00243935()
	{
		CreatedUserHistoryMode();
	}

	internal void _0024createDataChangeUUIDMode_0024closure_00243936(ActionClassChangeUUIDMode _0024act_0024t_0024606)
	{
		RuntimeDebugModeGuiMixin.label("通信中");
		RuntimeDebugModeGuiMixin.slabel("ユーザーデータの保存と切り換えをしています。");
		RuntimeDebugModeGuiMixin.slabel("切り換え後はアプリ再起動、または、");
		RuntimeDebugModeGuiMixin.slabel("unity再生しなおしをしてください。");
	}

	internal void _0024TutorialSwitch_0024closure_00243937()
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder("tutorialProgress: ").Append(TutorialFlowControl.Progress).ToString());
		if (RuntimeDebugModeGuiMixin.button("強制チュートリアルクリア"))
		{
			setTutorialCleared();
		}
	}

	internal void _0024createDatasetTutorialCleared_0024closure_00243938(ActionClasssetTutorialCleared _0024act_0024t_0024609)
	{
		_0024act_0024t_0024609.r1 = ApiUpdateTutorial.PresentBoxOpened();
		_0024act_0024t_0024609.r2 = ApiUpdateTutorial.RaidOpened();
		MerlinServer.Request(_0024act_0024t_0024609.r1);
		MerlinServer.Request(_0024act_0024t_0024609.r2);
		TutorialFlowControl.SetProgressFinished();
		TutorialFlowControl.Kill();
		QuestSession.DeleteSaveData();
	}

	internal void _0024createDatasetTutorialCleared_0024closure_00243939(ActionClasssetTutorialCleared _0024act_0024t_0024609)
	{
		RuntimeDebugModeGuiMixin.label("通信中");
		if (_0024act_0024t_0024609.r1.IsOk && _0024act_0024t_0024609.r2.IsOk)
		{
			FlagMode();
		}
		else if (_0024act_0024t_0024609.r1.IsEnd && _0024act_0024t_0024609.r2.IsEnd)
		{
			RuntimeDebugModeGuiMixin.label("通信エラーになっちゃった");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				FlagMode();
			}
		}
	}

	internal void _0024createDatauserDataUpDownLoadTest_0024closure_00243940(ActionClassuserDataUpDownLoadTest _0024act_0024t_0024612)
	{
		if (RuntimeDebugModeGuiMixin.button("jsonファイルからロード"))
		{
			fileSelectMode("../upload_userdata", "*.txt", _0024adaptor_0024__DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable490_0024844_64___0024__Req_FailHandler_0024callable6_0024440_32___0024109.Adapt(userDataLoadMain), new __DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable492_0024844_82__(userDataUpDownLoadTest));
		}
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("書き書きしたファイルからロード"))
		{
			fileSelectMode("../upload_userdata", "*.txt", _0024adaptor_0024__DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable493_0024847_64___0024__Req_FailHandler_0024callable6_0024440_32___0024110.Adapt(userDataLoadMain2), new __DebugSubUserData__0024createDatauserDataUpDownLoadTest_0024closure_00243940_0024callable492_0024844_82__(userDataUpDownLoadTest));
		}
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("現在user dataをuploadする"))
		{
			userDataUpload();
		}
	}

	internal void _0024createDatauserDataUpDownLoadTest_0024closure_00243941(ActionClassuserDataUpDownLoadTest _0024act_0024t_0024612)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatauserDataUpload_0024closure_00243942(ActionClassuserDataUpload _0024act_0024t_0024615)
	{
		_0024act_0024t_0024615.req = ApiLocalDataUpload.WithUserData();
		MerlinServer.ExRequest(_0024act_0024t_0024615.req);
	}

	internal void _0024createDatauserDataUpload_0024closure_00243943(ActionClassuserDataUpload _0024act_0024t_0024615)
	{
		if (_0024act_0024t_0024615.req.IsOk)
		{
			RuntimeDebugModeGuiMixin.label("upload 完了");
			RuntimeDebugModeGuiMixin.slabel("system info で social id をちゃんと確認してね");
		}
		else if (_0024act_0024t_0024615.req.IsEnd)
		{
			RuntimeDebugModeGuiMixin.label("upload 失敗");
			RuntimeDebugModeGuiMixin.slabel("通信エラーでした");
			RuntimeDebugModeGuiMixin.textArea("エラー:\n" + _0024act_0024t_0024615.req.Error);
		}
		else
		{
			RuntimeDebugModeGuiMixin.label("upload 中...");
		}
	}

	internal void _0024createDatauserDataUpload_0024closure_00243944(ActionClassuserDataUpload _0024act_0024t_0024615)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			userDataUpDownLoadTest();
		}
	}

	internal void _0024createDatauserDataLoadMain_0024closure_00243945(ActionClassuserDataLoadMain _0024act_0024t_0024619)
	{
		string text = null;
		try
		{
			StreamReader streamReader;
			IDisposable disposable = (streamReader = new StreamReader(_0024act_0024t_0024619.f)) as IDisposable;
			try
			{
				text = streamReader.ReadToEnd();
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("ファイルが空な無い");
			}
			string text2 = Crypt.Encrypt(text);
			if (string.IsNullOrEmpty(text2))
			{
				throw new Exception("ファイルが壊れている");
			}
			if (!UserData.Current.userMiscInfo.LoadFromStringWidthMd5(text2))
			{
				throw new Exception("jsonが間違っている");
			}
			_0024act_0024t_0024619.resultText = "多分ロードできた";
		}
		catch (Exception rhs)
		{
			string rhs2 = new StringBuilder("ファイル ").Append(_0024act_0024t_0024619.f).Append(" を読めませんでした。:\n").ToString() + rhs;
			_0024act_0024t_0024619.resultText = "ロード失敗。ログも見て。\n" + rhs2;
		}
	}

	internal void _0024createDatauserDataLoadMain_0024closure_00243946(ActionClassuserDataLoadMain _0024act_0024t_0024619)
	{
		RuntimeDebugModeGuiMixin.label("ロード結果:");
		RuntimeDebugModeGuiMixin.slabel(_0024act_0024t_0024619.resultText);
	}

	internal void _0024createDatauserDataLoadMain_0024closure_00243947(ActionClassuserDataLoadMain _0024act_0024t_0024619)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			userDataUpDownLoadTest();
		}
	}

	internal void _0024createDatauserDataLoadMain2_0024closure_00243948(ActionClassuserDataLoadMain2 _0024act_0024t_0024623)
	{
		string text = null;
		try
		{
			StreamReader streamReader;
			IDisposable disposable = (streamReader = new StreamReader(_0024act_0024t_0024623.f)) as IDisposable;
			try
			{
				text = streamReader.ReadToEnd();
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				throw new Exception("ファイルが空な無い");
			}
			object obj = NGUIJson.jsonDecode(text);
			if (!(obj is Hashtable))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Hashtable));
			}
			Hashtable hashtable = (Hashtable)obj;
			if (hashtable == null)
			{
				throw new Exception("jsonが間違っている");
			}
			if (!UserData.Current.userMiscInfo.LoadFromHashtable(hashtable))
			{
				throw new Exception("なんかうまくロードできなかった");
			}
			_0024act_0024t_0024623.resultText = "多分ロードできた";
		}
		catch (Exception rhs)
		{
			string rhs2 = new StringBuilder("ファイル ").Append(_0024act_0024t_0024623.f).Append(" を読めませんでした。:\n").ToString() + rhs;
			_0024act_0024t_0024623.resultText = "ロード失敗。ログも見て。\n" + rhs2;
		}
	}

	internal void _0024createDatauserDataLoadMain2_0024closure_00243949(ActionClassuserDataLoadMain2 _0024act_0024t_0024623)
	{
		RuntimeDebugModeGuiMixin.label("ロード結果:");
		RuntimeDebugModeGuiMixin.slabel(_0024act_0024t_0024623.resultText);
	}

	internal void _0024createDatauserDataLoadMain2_0024closure_00243950(ActionClassuserDataLoadMain2 _0024act_0024t_0024623)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			userDataUpDownLoadTest();
		}
	}

	internal void _0024createDatafileSelectMode_0024closure_00243951(ActionClassfileSelectMode _0024act_0024t_0024626)
	{
		_0024act_0024t_0024626.baseDir = _0024act_0024t_0024626.dir;
	}

	internal void _0024createDatafileSelectMode_0024closure_00243952(ActionClassfileSelectMode _0024act_0024t_0024626)
	{
		RuntimeDebugModeGuiMixin.label(new StringBuilder().Append(_0024act_0024t_0024626.baseDir).Append("/").Append(_0024act_0024t_0024626.ptn)
			.Append("からファイル選択")
			.ToString());
		if (_0024act_0024t_0024626.files == null)
		{
			RuntimeDebugModeGuiMixin.label("upload するファイル無いです");
			return;
		}
		int i = 0;
		string[] files = _0024act_0024t_0024626.files;
		for (int length = files.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(files[i]).ToString()) && _0024act_0024t_0024626.select != null)
			{
				_0024act_0024t_0024626.select(files[i]);
			}
		}
	}

	internal void _0024createDatafileSelectMode_0024closure_00243953(ActionClassfileSelectMode _0024act_0024t_0024626)
	{
		if (RuntimeDebugModeGuiMixin.InputBack && _0024act_0024t_0024626.back != null)
		{
			_0024act_0024t_0024626.back.Call(new object[0]);
		}
	}

	internal void _0024createDataquestMissionViewMode_0024closure_00243954(ActionClassquestMissionViewMode _0024act_0024t_0024629)
	{
		RuntimeDebugModeGuiMixin.label("Quest Missions");
		UserQuestMission userQuestMission = UserData.Current.userQuestMission;
		RuntimeDebugModeGuiMixin.slabel("NewQuestMissionIds:");
		RuntimeDebugModeGuiMixin.slabel("  " + Builtins.join(userQuestMission.NewQuestMissionIds, " "));
		RuntimeDebugModeGuiMixin.slabel("IsHasNewMission: " + userQuestMission.IsHasNewMission);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("QuestMissions: ");
		int i = 0;
		RespQuestMission[] questMissions = userQuestMission.QuestMissions;
		checked
		{
			for (int length = questMissions.Length; i < length; i++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("========== Id=").Append((object)questMissions[i].Id).Append(" ===========").ToString());
				RuntimeDebugModeGuiMixin.slabel("MQuestId: " + questMissions[i].MQuestId);
				RuntimeDebugModeGuiMixin.slabel("   Quest=" + MQuests.Get(questMissions[i].MQuestId));
				RuntimeDebugModeGuiMixin.slabel("Number: " + questMissions[i].Number);
				RuntimeDebugModeGuiMixin.slabel("MissionTypeValue: " + questMissions[i].MissionTypeValue);
				RuntimeDebugModeGuiMixin.slabel("BeginDate: " + questMissions[i].BeginDate);
				RuntimeDebugModeGuiMixin.slabel("EndDate: " + questMissions[i].EndDate);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue1: " + questMissions[i].ConditionTypeValue1);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter1: " + questMissions[i].ConditionParameter1);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue2: " + questMissions[i].ConditionTypeValue2);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter2: " + questMissions[i].ConditionParameter2);
				RuntimeDebugModeGuiMixin.slabel("Detail: " + questMissions[i].Detail);
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.slabel("ClearQuestMissions: ");
			int j = 0;
			RespQuestMission[] clearQuestMissions = userQuestMission.ClearQuestMissions;
			for (int length2 = clearQuestMissions.Length; j < length2; j++)
			{
				RuntimeDebugModeGuiMixin.slabel(new StringBuilder("========== Id=").Append((object)clearQuestMissions[j].Id).Append(" ===========").ToString());
				RuntimeDebugModeGuiMixin.slabel("MQuestId: " + clearQuestMissions[j].MQuestId);
				RuntimeDebugModeGuiMixin.slabel("   Quest=" + MQuests.Get(clearQuestMissions[j].MQuestId));
				RuntimeDebugModeGuiMixin.slabel("Number: " + clearQuestMissions[j].Number);
				RuntimeDebugModeGuiMixin.slabel("MissionTypeValue: " + clearQuestMissions[j].MissionTypeValue);
				RuntimeDebugModeGuiMixin.slabel("BeginDate: " + clearQuestMissions[j].BeginDate);
				RuntimeDebugModeGuiMixin.slabel("EndDate: " + clearQuestMissions[j].EndDate);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue1: " + clearQuestMissions[j].ConditionTypeValue1);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter1: " + clearQuestMissions[j].ConditionParameter1);
				RuntimeDebugModeGuiMixin.slabel("ConditionTypeValue2: " + clearQuestMissions[j].ConditionTypeValue2);
				RuntimeDebugModeGuiMixin.slabel("ConditionParameter2: " + clearQuestMissions[j].ConditionParameter2);
				RuntimeDebugModeGuiMixin.slabel("Detail: " + clearQuestMissions[j].Detail);
			}
		}
	}

	internal void _0024createDataquestMissionViewMode_0024closure_00243955(ActionClassquestMissionViewMode _0024act_0024t_0024629)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDatacolloseumEventViewMode_0024closure_00243956(ActionClasscolloseumEventViewMode _0024act_0024t_0024632)
	{
		UserData current = UserData.Current;
		RuntimeDebugModeGuiMixin.label("闘技場情報");
		RuntimeDebugModeGuiMixin.space(10);
		if (current.userBreeder != null)
		{
			RespBreeder userBreeder = current.userBreeder;
			RuntimeDebugModeGuiMixin.slabel("ブリーダーランク情報:");
			RuntimeDebugModeGuiMixin.slabel("Loss             : " + userBreeder.Loss);
			RuntimeDebugModeGuiMixin.slabel("Win              : " + userBreeder.Win);
			RuntimeDebugModeGuiMixin.slabel("BreederRankPoint : " + userBreeder.BreederRankPoint);
			RuntimeDebugModeGuiMixin.slabel("BreederRankId    : " + userBreeder.BreederRankId);
		}
		else
		{
			RuntimeDebugModeGuiMixin.slabel("ブリーダーランク情報無し");
		}
		UserColosseumEvent userColosseumEvent = current.userColosseumEvent;
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.slabel("イベント total ranking point: " + userColosseumEvent.ColosseumEventTotalRankingPoint);
		RuntimeDebugModeGuiMixin.space(10);
		checked
		{
			if (userColosseumEvent.ColosseumEvent.Length > 0)
			{
				RespColosseumEvent[] colosseumEvent = userColosseumEvent.ColosseumEvent;
				int i = 0;
				RespColosseumEvent[] array = colosseumEvent;
				for (int length = array.Length; i < length; i++)
				{
					RuntimeDebugModeGuiMixin.label("イベント情報:");
					RuntimeDebugModeGuiMixin.slabel("Id                  : " + array[i].Id);
					RuntimeDebugModeGuiMixin.slabel("IsRankingEvent      : " + array[i].IsRankingEvent);
					RuntimeDebugModeGuiMixin.slabel("IsFriendCompetition : " + array[i].IsFriendCompetition);
					RuntimeDebugModeGuiMixin.slabel("FriendPoint         : " + array[i].FriendPoint);
					RuntimeDebugModeGuiMixin.slabel("Coin                : " + array[i].Coin);
					RuntimeDebugModeGuiMixin.slabel("BpCost              : " + array[i].BpCost);
					RuntimeDebugModeGuiMixin.slabel("BeginDate           : " + array[i].BeginDate);
					RuntimeDebugModeGuiMixin.slabel("EndDate             : " + array[i].EndDate);
					RuntimeDebugModeGuiMixin.slabel("ManaFragment        : " + array[i].ManaFragment);
					RuntimeDebugModeGuiMixin.slabel("IsCostLimit         : " + array[i].IsCostLimit);
					RuntimeDebugModeGuiMixin.slabel("CostLimit           : " + array[i].CostLimit);
					RuntimeDebugModeGuiMixin.slabel("IsElementLimit      : " + array[i].IsElementLimit);
					RuntimeDebugModeGuiMixin.slabel("ElementLimit        : " + array[i].ElementLimit);
					RuntimeDebugModeGuiMixin.slabel("IsStyleLimit        : " + array[i].IsStyleLimit);
					RuntimeDebugModeGuiMixin.slabel("StyleLimit          : " + array[i].StyleLimit);
					RuntimeDebugModeGuiMixin.slabel("IsMinRarityLimit    : " + array[i].IsMinRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("MinRarityLimit      : " + array[i].MinRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("IsMaxRarityLimit    : " + array[i].IsMaxRarityLimit);
					RuntimeDebugModeGuiMixin.slabel("MaxRarityLimit      : " + array[i].MaxRarityLimit);
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("イベント情報無し");
			}
			RuntimeDebugModeGuiMixin.space(10);
			if (userColosseumEvent.ColosseumEventRanking != null)
			{
				RespColosseumEventRanking colosseumEventRanking = userColosseumEvent.ColosseumEventRanking;
				RuntimeDebugModeGuiMixin.slabel("イベントランキング情報:");
				RuntimeDebugModeGuiMixin.slabel("MColosseumEventId : " + colosseumEventRanking.MColosseumEventId);
				RuntimeDebugModeGuiMixin.slabel("TSocialPlayerId   : " + colosseumEventRanking.TSocialPlayerId);
				RuntimeDebugModeGuiMixin.slabel("Ranking           : " + colosseumEventRanking.Ranking);
				RuntimeDebugModeGuiMixin.slabel("RankingPoint      : " + colosseumEventRanking.RankingPoint);
			}
			else
			{
				RuntimeDebugModeGuiMixin.slabel("イベントランキング情報無し");
			}
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("デイリー援護スキル");
			int j = 0;
			int[] dailyPassiveSkills = userColosseumEvent.DailyPassiveSkills;
			for (int length2 = dailyPassiveSkills.Length; j < length2; j++)
			{
				MCoverSkills rhs = MCoverSkills.Get(dailyPassiveSkills[j]);
				RuntimeDebugModeGuiMixin.slabel("  " + rhs);
			}
		}
	}

	internal void _0024createDatacolloseumEventViewMode_0024closure_00243957(ActionClasscolloseumEventViewMode _0024act_0024t_0024632)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataquestTicketViewMode_0024closure_00243958(ActionClassquestTicketViewMode _0024act_0024t_0024635)
	{
		if (RuntimeDebugModeGuiMixin.button(new StringBuilder("Debug Tickets : ").Append(ticketDebug).ToString()))
		{
			ticketDebug = !ticketDebug;
		}
		if (ticketDebug)
		{
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Icon:").Append(ticketIcon).ToString());
			ticketIcon = GUILayout.TextField(ticketIcon);
			RuntimeDebugModeGuiMixin.label(new StringBuilder("Explain:").Append(ticketExplain).ToString());
			ticketExplain = GUILayout.TextField(ticketExplain);
		}
		RuntimeDebugModeGuiMixin.label("チケット一覧");
		RuntimeDebugModeGuiMixin.space(10);
		RespPlayer userBasicInfo = UserData.Current.userBasicInfo;
		if (userBasicInfo != null)
		{
			RuntimeDebugModeGuiMixin.label("最終付与日: " + userBasicInfo.BeforeQuestTicketIssueDate);
		}
		else
		{
			RuntimeDebugModeGuiMixin.label("最終付与日: 不明");
		}
		RespQuestTicket[] questTickets = UserData.Current.questTickets;
		if (questTickets != null)
		{
			RuntimeDebugModeGuiMixin.label("ticket num: " + questTickets.Length);
			int i = 0;
			RespQuestTicket[] array = questTickets;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				RuntimeDebugModeGuiMixin.space(10);
				showTicketInfo(array[i], new _0024_0024createDataquestTicketViewMode_0024closure_00243958_0024closure_00243959(array, i, this).Invoke);
			}
		}
	}

	internal void _0024createDataquestTicketViewMode_0024closure_00243961(ActionClassquestTicketViewMode _0024act_0024t_0024635)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			MainMode();
		}
	}

	internal void _0024createDataplayByThisTicket_0024closure_00243962(ActionClassplayByThisTicket _0024act_0024t_0024638)
	{
		_0024act_0024t_0024638.quests = new Boo.Lang.List<MQuests>();
		int i = 0;
		int[] questIds = _0024act_0024t_0024638.t.QuestIds;
		for (int length = questIds.Length; i < length; i = checked(i + 1))
		{
			MQuests mQuests = MQuests.Get(questIds[i]);
			if (mQuests != null)
			{
				_0024act_0024t_0024638.quests.Add(mQuests);
			}
		}
	}

	internal void _0024createDataplayByThisTicket_0024closure_00243963(ActionClassplayByThisTicket _0024act_0024t_0024638)
	{
		showTicketInfo(_0024act_0024t_0024638.t, null);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("プレイするクエストを選択");
		IEnumerator<MQuests> enumerator = _0024act_0024t_0024638.quests.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				MQuests current = enumerator.Current;
				if (RuntimeDebugModeGuiMixin.button(new StringBuilder().Append(current).ToString()))
				{
					MStories mStories = MQuests.FindStory(current);
					if (mStories != null)
					{
						QuestSession.StartSessionDebug(RuntimeDebugMode.Instance, mStories.Id, noSceneLoad: false);
						ExitDebugMode();
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	internal void _0024createDataplayByThisTicket_0024closure_00243964(ActionClassplayByThisTicket _0024act_0024t_0024638)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			questTicketViewMode();
		}
	}

	internal void _0024createDatauseTicketMode_0024closure_00243965(ActionClassuseTicketMode _0024act_0024t_0024641)
	{
		_0024act_0024t_0024641.req = new ApiQuestUseTicket(_0024act_0024t_0024641.ticketId);
		MerlinServer.Request(_0024act_0024t_0024641.req);
	}

	internal void _0024createDatauseTicketMode_0024closure_00243966(ActionClassuseTicketMode _0024act_0024t_0024641)
	{
		if (_0024act_0024t_0024641.req.IsOk)
		{
			RuntimeDebugModeGuiMixin.label("使いました");
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				questTicketViewMode();
			}
		}
		else if (_0024act_0024t_0024641.req.IsEnd)
		{
			RuntimeDebugModeGuiMixin.label("なんかエラーでちゃった - " + _0024act_0024t_0024641.req.GameServerResponseStatusCode);
			RuntimeDebugModeGuiMixin.slabel("Error: " + _0024act_0024t_0024641.req.Error);
			if (RuntimeDebugModeGuiMixin.button("戻る"))
			{
				questTicketViewMode();
			}
		}
		else
		{
			RuntimeDebugModeGuiMixin.label("通信中...");
		}
	}

	internal void _0024createDatauseTicketMode_0024closure_00243967(ActionClassuseTicketMode _0024act_0024t_0024641)
	{
		if (RuntimeDebugModeGuiMixin.InputBack)
		{
			questTicketViewMode();
		}
	}
}
