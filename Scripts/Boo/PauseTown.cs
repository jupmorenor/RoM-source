using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PauseTown : PauseBase
{
	[Serializable]
	public enum MODE_PAUSETOWN
	{
		top,
		profile,
		news,
		gameCenter,
		help,
		support,
		credit,
		graphicsSetting,
		soundSetting,
		terminal,
		padSetting,
		friendInvite,
		autoWordMenu,
		myMapet,
		myWeapon,
		exit,
		serial,
		soundDownload,
		OtherSetting
	}

	[Serializable]
	public enum DetailShowStatus
	{
		Closed,
		Show,
		Shown,
		Close
	}

	[Serializable]
	internal class _0024SceneAwake_0024locals_002414402
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024init;
	}

	[Serializable]
	internal class _0024PrepareChange_0024locals_002414403
	{
		internal UserData _0024ud;

		internal GameObject _0024situationRoot;
	}

	[Serializable]
	internal class _0024ShowWebHtml_0024locals_002414404
	{
		internal bool _0024buttonExit;
	}

	[Serializable]
	internal class _0024UpdateCommentCallback_0024locals_002414405
	{
		internal System.Collections.Generic.List<string> _0024lines;
	}

	[Serializable]
	internal class _0024LoadComments_0024locals_002414406
	{
		internal UserMiscInfo.RaidData _0024raidData;
	}

	[Serializable]
	internal class _0024_0024PushDownloadBGM_0024closure_00243747_0024locals_002414407
	{
		internal int _0024downLoadType;

		internal Dialog _0024dlg;
	}

	[Serializable]
	internal class _0024SceneAwake_0024closure_00242934
	{
		internal _0024SceneAwake_0024locals_002414402 _0024_0024locals_002414930;

		public _0024SceneAwake_0024closure_00242934(_0024SceneAwake_0024locals_002414402 _0024_0024locals_002414930)
		{
			this._0024_0024locals_002414930 = _0024_0024locals_002414930;
		}

		public void Invoke()
		{
			_0024_0024locals_002414930._0024init();
		}
	}

	[Serializable]
	internal class _0024_0024PrepareChange_0024closure_00243727_0024SetSideWeaponIcon_00243728
	{
		internal PauseTown _0024this_002414931;

		internal _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414932;

		public _0024_0024PrepareChange_0024closure_00243727_0024SetSideWeaponIcon_00243728(PauseTown _0024this_002414931, _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414932)
		{
			this._0024this_002414931 = _0024this_002414931;
			this._0024_0024locals_002414932 = _0024_0024locals_002414932;
		}

		public void Invoke(string suffix, GameObject weaponIcon, RespWeapon data)
		{
			GameObject gameObject = ExtensionsModule.FindChild(ExtensionsModule.FindChild(_0024_0024locals_002414932._0024situationRoot, "2 WeaponName"), "WeaponIcon" + suffix);
			if (weaponIcon == null)
			{
				weaponIcon = (GameObject)UnityEngine.Object.Instantiate(_0024this_002414931.weaponIconPrefab);
			}
			weaponIcon.transform.parent = gameObject.transform;
			weaponIcon.transform.localScale = Vector3.one;
			weaponIcon.transform.localPosition = Vector3.zero;
			WeaponListItem component = weaponIcon.GetComponent<WeaponListItem>();
			component.enableIconSprite = true;
			component.enableLevelLabel = false;
			component.enableIconFavorite = false;
			component.SetWeapon(data);
			UIButtonMessage component2 = weaponIcon.GetComponent<UIButtonMessage>();
			component2.target = _0024this_002414931.gameObject;
			component2.functionName = "PushMyWeapon";
			component.DestroyLevel();
		}
	}

	[Serializable]
	internal class _0024_0024PrepareChange_0024closure_00243727_0024SetSideMapetIcon_00243729
	{
		internal PauseTown _0024this_002414933;

		internal _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414934;

		public _0024_0024PrepareChange_0024closure_00243727_0024SetSideMapetIcon_00243729(PauseTown _0024this_002414933, _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414934)
		{
			this._0024this_002414933 = _0024this_002414933;
			this._0024_0024locals_002414934 = _0024_0024locals_002414934;
		}

		public void Invoke()
		{
			GameObject gameObject = ExtensionsModule.FindChild(ExtensionsModule.FindChild(_0024_0024locals_002414934._0024situationRoot, "3 PoppetName"), "PoppetIcon");
			if (_0024this_002414933.mapetIcon == null)
			{
				_0024this_002414933.mapetIcon = (GameObject)UnityEngine.Object.Instantiate(_0024this_002414933.mapetIconPrefab);
			}
			_0024this_002414933.mapetIcon.transform.parent = gameObject.transform;
			_0024this_002414933.mapetIcon.transform.localScale = Vector3.one;
			_0024this_002414933.mapetIcon.transform.localPosition = Vector3.zero;
			UIButtonMessage component = _0024this_002414933.mapetIcon.GetComponent<UIButtonMessage>();
			component.target = _0024this_002414933.gameObject;
			component.functionName = "PushMyMapet";
			MapetListItem component2 = _0024this_002414933.mapetIcon.GetComponent<MapetListItem>();
			component2.enableIconSprite = true;
			component2.enableLevelLabel = false;
			component2.enableCharLevelLabel = false;
			component2.enableIconFavorite = false;
			GameObject gameObject2 = component2.SetMapet(_0024_0024locals_002414934._0024ud.CurrentPoppetNewOrOldDeck);
			component2.DestroyLevel();
		}
	}

	[Serializable]
	internal class _0024PrepareChange_0024closure_00243727
	{
		internal PauseTown _0024this_002414935;

		internal _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414936;

		public _0024PrepareChange_0024closure_00243727(PauseTown _0024this_002414935, _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414936)
		{
			this._0024this_002414935 = _0024this_002414935;
			this._0024_0024locals_002414936 = _0024_0024locals_002414936;
		}

		public void Invoke()
		{
			_0024this_002414935.openMyWeapon = DetailShowStatus.Closed;
			_0024this_002414935.openMyMapet = DetailShowStatus.Closed;
			__PauseTown__0024PrepareChange_0024closure_00243727_0024callable161_0024231_25__ _PauseTown__0024PrepareChange_0024closure_00243727_0024callable161_0024231_25__ = new _0024_0024PrepareChange_0024closure_00243727_0024SetSideWeaponIcon_00243728(_0024this_002414935, _0024_0024locals_002414936).Invoke;
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024_0024PrepareChange_0024closure_00243727_0024SetSideMapetIcon_00243729(_0024this_002414935, _0024_0024locals_002414936).Invoke;
			if (_0024this_002414935.oldDeck)
			{
				_PauseTown__0024PrepareChange_0024closure_00243727_0024callable161_0024231_25__(string.Empty, _0024this_002414935.weaponIconAn, _0024_0024locals_002414936._0024ud.MainWeapon);
			}
			else
			{
				_PauseTown__0024PrepareChange_0024closure_00243727_0024callable161_0024231_25__("An", _0024this_002414935.weaponIconAn, _0024_0024locals_002414936._0024ud.AngelWeapon);
				_PauseTown__0024PrepareChange_0024closure_00243727_0024callable161_0024231_25__("De", _0024this_002414935.weaponIconDe, _0024_0024locals_002414936._0024ud.DevilWeapon);
			}
			_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "0 UserName", "TextUserName", _0024_0024locals_002414936._0024ud.PlayerName);
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "0 UserName", "TextUserLevel", "lv" + _0024_0024locals_002414936._0024ud.Level);
			if (_0024this_002414935.oldDeck)
			{
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponName", _0024_0024locals_002414936._0024ud.MainWeapon.Name);
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponLevel", "lv" + _0024_0024locals_002414936._0024ud.MainWeapon.Level, _0024_0024locals_002414936._0024ud.SubWeapon1.LevelColor);
			}
			else
			{
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponNameAn", _0024_0024locals_002414936._0024ud.AngelWeapon.Name);
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponNameDe", _0024_0024locals_002414936._0024ud.DevilWeapon.Name);
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponLevelAn", "lv" + _0024_0024locals_002414936._0024ud.AngelWeapon.Level, _0024_0024locals_002414936._0024ud.AngelWeapon.LevelColor);
				_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "2 WeaponName", "TextWeaponLevelDe", "lv" + _0024_0024locals_002414936._0024ud.DevilWeapon.Level, _0024_0024locals_002414936._0024ud.DevilWeapon.LevelColor);
			}
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "3 PoppetName", "TextPoppetName", _0024_0024locals_002414936._0024ud.CurrentPoppetNewOrOldDeck.Name);
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "3 PoppetName", "TextPoppetLevel", "lv" + _0024_0024locals_002414936._0024ud.CurrentPoppetNewOrOldDeck.Level, _0024_0024locals_002414936._0024ud.CurrentPoppetNewOrOldDeck.LevelColor);
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "1 TeamName", "TextTeamName", _0024this_002414935.GetTeamName());
			string text = UIBasicUtility.SafeFormat("{0}/10", _0024_0024locals_002414936._0024ud.userParty.Count());
			_0024this_002414935.UpdateLabel(_0024_0024locals_002414936._0024situationRoot, "1 TeamName", "TextTeamMember", text);
			MapetDetailUtil.PrepareMapetPrefab(friend: false);
			WeaponDetailUtil.PrepareWeaponPrefab();
			GameObject gameObject = MapetDetailUtil.PrepareMapetDetail(_0024this_002414935.gameObject);
			GameObject gameObject2 = WeaponDetailUtil.PrepareWeaponDetail(_0024this_002414935.gameObject);
			if ((bool)gameObject)
			{
				NGUITools.SetLayer(gameObject, _0024this_002414935.gameObject.layer);
				gameObject.SetActive(value: false);
			}
			if ((bool)gameObject2)
			{
				NGUITools.SetLayer(gameObject2, _0024this_002414935.gameObject.layer);
				gameObject2.SetActive(value: false);
			}
		}
	}

	[Serializable]
	internal class _0024PrepareChange_0024closure_00243731
	{
		internal _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414937;

		public _0024PrepareChange_0024closure_00243731(_0024PrepareChange_0024locals_002414403 _0024_0024locals_002414937)
		{
			this._0024_0024locals_002414937 = _0024_0024locals_002414937;
		}

		public void Invoke()
		{
			int i = 0;
			WeaponInfo[] componentsInChildren = _0024_0024locals_002414937._0024situationRoot.GetComponentsInChildren<WeaponInfo>();
			for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
			{
				componentsInChildren[i].SetWeapon(_0024_0024locals_002414937._0024ud.MainWeapon);
				componentsInChildren[i].DestroyLevel();
			}
		}
	}

	[Serializable]
	internal class _0024PrepareChange_0024closure_00243732
	{
		internal _0024PrepareChange_0024locals_002414403 _0024_0024locals_002414938;

		public _0024PrepareChange_0024closure_00243732(_0024PrepareChange_0024locals_002414403 _0024_0024locals_002414938)
		{
			this._0024_0024locals_002414938 = _0024_0024locals_002414938;
		}

		public void Invoke()
		{
			int i = 0;
			MuppetInfo[] componentsInChildren = _0024_0024locals_002414938._0024situationRoot.GetComponentsInChildren<MuppetInfo>();
			for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
			{
				componentsInChildren[i].SetMuppet(_0024_0024locals_002414938._0024ud.CurrentPoppetNewOrOldDeck);
				componentsInChildren[i].DestroyLevel();
			}
		}
	}

	[Serializable]
	internal class _0024ShowWebHtml_0024closure_00243733
	{
		internal _0024ShowWebHtml_0024locals_002414404 _0024_0024locals_002414939;

		public _0024ShowWebHtml_0024closure_00243733(_0024ShowWebHtml_0024locals_002414404 _0024_0024locals_002414939)
		{
			this._0024_0024locals_002414939 = _0024_0024locals_002414939;
		}

		public void Invoke(object go)
		{
			_0024_0024locals_002414939._0024buttonExit = true;
		}
	}

	[Serializable]
	internal class _0024_0024PushDownloadBGM_0024closure_00243747_0024closure_00243748
	{
		internal _0024_0024PushDownloadBGM_0024closure_00243747_0024locals_002414407 _0024_0024locals_002414940;

		public _0024_0024PushDownloadBGM_0024closure_00243747_0024closure_00243748(_0024_0024PushDownloadBGM_0024closure_00243747_0024locals_002414407 _0024_0024locals_002414940)
		{
			this._0024_0024locals_002414940 = _0024_0024locals_002414940;
		}

		public void Invoke(int btn)
		{
			_0024_0024locals_002414940._0024downLoadType = btn;
			_0024_0024locals_002414940._0024dlg = null;
		}
	}

	[Serializable]
	internal class _0024UpdateCommentCallback_0024ToIds_00243751
	{
		internal _0024UpdateCommentCallback_0024locals_002414405 _0024_0024locals_002414941;

		internal PauseTown _0024this_002414942;

		public _0024UpdateCommentCallback_0024ToIds_00243751(_0024UpdateCommentCallback_0024locals_002414405 _0024_0024locals_002414941, PauseTown _0024this_002414942)
		{
			this._0024_0024locals_002414941 = _0024_0024locals_002414941;
			this._0024this_002414942 = _0024this_002414942;
		}

		public int[] Invoke()
		{
			MRaidWords[] masterWords = _0024this_002414942.GetMasterWords(_0024this_002414942.currentWordType);
			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
			int num = 0;
			int length = masterWords.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				MRaidWords mRaidWords = masterWords[RuntimeServices.NormalizeArrayIndex(masterWords, index)];
				if (_0024_0024locals_002414941._0024lines.Contains(mRaidWords.Name.ToString()))
				{
					list.Add(mRaidWords.Id);
				}
			}
			return list.ToArray();
		}
	}

	[Serializable]
	internal class _0024LoadComments_0024load_00243730
	{
		internal _0024LoadComments_0024locals_002414406 _0024_0024locals_002414943;

		public _0024LoadComments_0024load_00243730(_0024LoadComments_0024locals_002414406 _0024_0024locals_002414943)
		{
			this._0024_0024locals_002414943 = _0024_0024locals_002414943;
		}

		public string Invoke(EnumRaidWordTypes type)
		{
			int[] array = _0024_0024locals_002414943._0024raidData.Get(type);
			string text = string.Empty;
			int num = 0;
			int length = array.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				text += MRaidWords.Get(array[RuntimeServices.NormalizeArrayIndex(array, index)]).Name.ToString() + "\n";
			}
			return text;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024PushDownloadBGM_0024closure_00243747_002418351 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024wifi_002418352;

			internal int _0024threeG_002418353;

			internal DialogManager _0024dlgMan_002418354;

			internal _0024_0024PushDownloadBGM_0024closure_00243747_0024locals_002414407 _0024_0024locals_002418355;

			internal PauseTown _0024self__002418356;

			public _0024(PauseTown self_)
			{
				_0024self__002418356 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002418355 = new _0024_0024PushDownloadBGM_0024closure_00243747_0024locals_002414407();
					_0024wifi_002418352 = 1;
					_0024threeG_002418353 = 2;
					_0024dlgMan_002418354 = DialogManager.Instance;
					_0024_0024locals_002418355._0024downLoadType = 0;
					_0024dlgMan_002418354.OnButton(0);
					_0024_0024locals_002418355._0024dlg = _0024dlgMan_002418354.OpenCustomDialog(new StringBuilder("BGM・SEデータをダウンロードしますか？\nなお、ダウンロードには時間がかかるため\nWi-Fi環境を推奨します。\n \n【推定所要時間\u3000Wi-Fi：").Append((object)_0024wifi_002418352).Append("分\u30003G：").Append((object)_0024threeG_002418353)
						.Append("分】\n<RED>※au回線（3G）では\nダウンロードに支障をきたす可能性があります。<COLOR_INIT>")
						.ToString(), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[2] { "いいえ", "はい" }, 2);
					_0024_0024locals_002418355._0024dlg.ButtonHandler = new _0024_0024PushDownloadBGM_0024closure_00243747_0024closure_00243748(_0024_0024locals_002418355).Invoke;
					goto case 2;
				case 2:
					if ((bool)_0024_0024locals_002418355._0024dlg)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024_0024locals_002418355._0024downLoadType == 2)
					{
						TimeScaleUtil.One();
						_0024self__002418356.gotoBgmFlag = true;
						DownloadMain.ChangeToBGMDownloadMode(SceneChanger.CurrentScene);
						SceneChanger.ChangeTo(SceneID.Ui_Download);
					}
					else
					{
						_0024self__002418356.mode = MODE_PAUSETOWN.soundSetting;
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PauseTown _0024self__002418357;

		public _0024_0024PushDownloadBGM_0024closure_00243747_002418351(PauseTown self_)
		{
			_0024self__002418357 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418357);
		}
	}

	public bool oldDeck;

	public UILabelBase textDate;

	public bool debugSerial;

	public GameObject objSerial;

	public bool debugInvite;

	public GameObject objInvite;

	public GameObject buttonsParent;

	public Transform hudParent;

	public GameObject commentSelect;

	public UILabelBase gameCenterButtonLabel;

	protected WebView curWebView;

	protected string checkUrl;

	public WeaponInfo weaponInfoAn;

	public WeaponInfo weaponInfoDe;

	public MuppetInfo mapetInfo;

	public GameObject inviteButton;

	private Dictionary<string, UILabelBase> commentLabelDictionary;

	private MODE_PAUSETOWN mode;

	private int lastMode;

	private MODE_PAUSETOWN nextMode;

	private MODE_PAUSETOWN errorMode;

	private GameObject mapetIconPrefab;

	private GameObject weaponIconPrefab;

	private GameObject weaponIconAn;

	private GameObject weaponIconDe;

	private GameObject mapetIcon;

	private bool gotoTitleFlag;

	private bool gotoBgmFlag;

	private bool extraWebViewCommandFlag;

	private bool closeFlag;

	private bool initFlag;

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_START = "0 BattleStart";

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_SKILL = "1 ButtonSkill";

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_DAMAGE = "2 ButtonDamage";

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_HP0 = "3 ButtonHP0";

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_WIN = "4 ButtonWin";

	[NonSerialized]
	private const string COMMENT_OBJ_NAME_JOIN = "5 ButtonJoint";

	private DetailShowStatus openMyWeapon;

	private DetailShowStatus openMyMapet;

	private UILabelBase commentUpdateTarget;

	private EnumRaidWordTypes currentWordType;

	public PauseTown()
	{
		oldDeck = true;
		debugSerial = true;
		debugInvite = true;
		errorMode = MODE_PAUSETOWN.top;
		openMyWeapon = DetailShowStatus.Closed;
		openMyMapet = DetailShowStatus.Closed;
	}

	public override void SceneAwake()
	{
		_0024SceneAwake_0024locals_002414402 _0024SceneAwake_0024locals_0024 = new _0024SceneAwake_0024locals_002414402();
		_0024SceneAwake_0024locals_0024._0024init = delegate
		{
			if (!debugSerial)
			{
				objSerial.SetActive(value: false);
			}
			if (!debugInvite)
			{
				objInvite.SetActive(value: false);
			}
			textDate.text = MerlinDateTime.Now.ToString("HH:mm");
			mode = MODE_PAUSETOWN.top;
			lastMode = -1;
			mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/MuppetListItem") as GameObject;
			weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/WeaponListItem") as GameObject;
			initFlag = true;
			closeFlag = false;
			if (inviteButton != null)
			{
				inviteButton.gameObject.SetActive(!ApiExamVer.IsExamVer);
			}
			if ((bool)gameCenterButtonLabel)
			{
				gameCenterButtonLabel.text = "Google\nplay games";
			}
		};
		MerlinServer.EditorCommunicationInitialize(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024SceneAwake_0024closure_00242934(_0024SceneAwake_0024locals_0024).Invoke));
	}

	public void OnDestroy()
	{
		RestoreVolume();
		RestoreGraphic();
		RestorePad();
		curWebView = null;
		WebViewBase.EndWebView();
		if (gotoTitleFlag || gotoBgmFlag || extraWebViewCommandFlag)
		{
			TheWorld.RestartWorldForPause();
			TheWorld.Init();
		}
		IPauseWindow.isPaused = false;
	}

	public override void SceneStart()
	{
		buttonsParent.SetActive(value: true);
		IPauseWindow.isPaused = false;
	}

	public override void SceneUpdate()
	{
		textDate.text = MerlinDateTime.Now.ToString("HH:mm");
		if (!initFlag || !SceneChanger.isCompletelyReady || IsChangingSituation)
		{
			return;
		}
		if (mode != (MODE_PAUSETOWN)lastMode)
		{
			lastMode = (int)mode;
			ChangeSituation(GetSituation((int)mode));
			PrepareChange((int)mode);
		}
		switch (mode)
		{
		case MODE_PAUSETOWN.top:
			IPauseWindow.isPaused = true;
			break;
		case MODE_PAUSETOWN.news:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.help:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.support:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.credit:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.soundSetting:
			seSlider.ForceUpdate();
			break;
		case MODE_PAUSETOWN.terminal:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.serial:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.friendInvite:
			CheckUrl();
			break;
		case MODE_PAUSETOWN.exit:
			if (!IsChangingSituation)
			{
				StartButton startButton = ((StartButton)UnityEngine.Object.FindObjectOfType(typeof(StartButton))) as StartButton;
				startButton.ClosePause();
				IPauseWindow.isPaused = false;
				IconAtlasPool.UnloadAll();
			}
			break;
		}
	}

	public void PrepareChange(int mode)
	{
		_0024PrepareChange_0024locals_002414403 _0024PrepareChange_0024locals_0024 = new _0024PrepareChange_0024locals_002414403();
		RestoreVolume();
		_0024PrepareChange_0024locals_0024._0024ud = UserData.Current;
		_0024PrepareChange_0024locals_0024._0024situationRoot = GetSituation(mode).gameObject;
		switch (mode)
		{
		case 0:
			closeFlag = false;
			if ((bool)ButtonBackHUD.Instance)
			{
				GameObject gameObject2 = ButtonBackHUD.Instance.gameObject;
				if (gameObject2.GetComponentsInChildren<UIAutoTweenerStandAloneEx>(includeInactive: true).FirstOrDefault().IsOut)
				{
					UIAutoTweenerStandAloneEx.In(gameObject2);
				}
			}
			break;
		case 8:
			InitSoundSetting(_0024PrepareChange_0024locals_0024._0024situationRoot);
			break;
		case 7:
			RestoreGraphic();
			break;
		case 10:
			RestorePad();
			break;
		case 1:
			TryPrepare(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PrepareChange_0024closure_00243727(this, _0024PrepareChange_0024locals_0024).Invoke));
			break;
		case 12:
		{
			GameObject gameObject = ExtensionsModule.FindChild(_0024PrepareChange_0024locals_0024._0024situationRoot, "Table");
			if (!(gameObject != null))
			{
				throw new AssertionFailedException("tableGo != null");
			}
			gameObject.GetComponent<UITable>().repositionNow = true;
			string objName = "BattleStartTex";
			commentLabelDictionary = new Dictionary<string, UILabelBase>();
			commentLabelDictionary["0 BattleStart"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "0 BattleStart"), objName).GetComponent<UILabelBase>();
			commentLabelDictionary["1 ButtonSkill"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "1 ButtonSkill"), objName).GetComponent<UILabelBase>();
			commentLabelDictionary["2 ButtonDamage"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "2 ButtonDamage"), objName).GetComponent<UILabelBase>();
			commentLabelDictionary["3 ButtonHP0"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "3 ButtonHP0"), objName).GetComponent<UILabelBase>();
			commentLabelDictionary["4 ButtonWin"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "4 ButtonWin"), objName).GetComponent<UILabelBase>();
			commentLabelDictionary["5 ButtonJoint"] = ExtensionsModule.FindChild(ExtensionsModule.FindChild(gameObject, "5 ButtonJoint"), objName).GetComponent<UILabelBase>();
			LoadComments(commentLabelDictionary);
			break;
		}
		case 14:
			TryPrepare(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PrepareChange_0024closure_00243731(_0024PrepareChange_0024locals_0024).Invoke));
			break;
		case 13:
			TryPrepare(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PrepareChange_0024closure_00243732(_0024PrepareChange_0024locals_0024).Invoke));
			break;
		case 18:
		{
			RestoreOtherSetting();
			UpdateLabel(_0024PrepareChange_0024locals_0024._0024situationRoot, "1 ResultShortcut", "TextTitle", MTexts.Get("$RESULT_SHORTCUT_OPTION_TITLE").ToString());
			string text = MTexts.Get("$RESULT_SHORTCUT_OPTION_MESSAGE").ToString();
			Color color = Color.white;
			if (GameParameter.alwaysOpenResultShortcut)
			{
				text = "※現在、全リザルトショートカットon";
				color = Color.red;
			}
			UpdateLabel(_0024PrepareChange_0024locals_0024._0024situationRoot, "ResultShortcutMenu", "InfoText", text, color);
			break;
		}
		}
	}

	public void CheckUrl()
	{
		if ((bool)curWebView && !string.IsNullOrEmpty(checkUrl))
		{
			string nextUrl = default(string);
			if ((bool)curWebView)
			{
				nextUrl = WebViewBase.GetNextUrl();
			}
			if (!string.IsNullOrEmpty(nextUrl) && !(checkUrl != nextUrl))
			{
			}
		}
	}

	public void HtmlRequest(RequestBase req)
	{
		if ((bool)curWebView)
		{
			curWebView.Clear();
			curWebView.Close();
		}
		curWebView = null;
		MerlinServer.Request(req, CallBackHtmlRequest);
	}

	public void CallBackHtmlRequest(RequestBase req)
	{
		if (req == null)
		{
			mode = MODE_PAUSETOWN.top;
			GameObject gameObject = ButtonBackHUD.Instance.gameObject;
			if (gameObject.GetComponentsInChildren<UIAutoTweenerStandAloneEx>(includeInactive: true).FirstOrDefault().IsOut)
			{
				UIAutoTweenerStandAloneEx.In(gameObject);
			}
		}
		else
		{
			StartCoroutine("ShowWebHtml", req);
		}
	}

	public IEnumerator ShowWebHtml(RequestBase req)
	{
		_0024ShowWebHtml_0024locals_002414404 _0024ShowWebHtml_0024locals_0024 = new _0024ShowWebHtml_0024locals_002414404();
		if ((bool)curWebView)
		{
			curWebView.Clear();
			curWebView.Close();
		}
		curWebView = null;
		checkUrl = string.Empty;
		if (req.IsOk)
		{
			mode = nextMode;
			UISituation[] array = situations;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, (int)nextMode)])
			{
				UISituation[] array2 = situations;
				curWebView = array2[RuntimeServices.NormalizeArrayIndex(array2, (int)nextMode)].GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
				curWebView.gameObject.SetActive(value: false);
			}
			_0024ShowWebHtml_0024locals_0024._0024buttonExit = false;
			UIAutoTweenerStandAloneEx.Out(ButtonBackHUD.Instance.gameObject.transform.parent.gameObject, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024153.Adapt(new _0024ShowWebHtml_0024closure_00243733(_0024ShowWebHtml_0024locals_0024).Invoke));
			if ((bool)curWebView)
			{
				if (!curWebView.gameObject.activeSelf)
				{
					curWebView.gameObject.SetActive(value: true);
				}
				curWebView.Clear();
				curWebView.OpenHtml(req.Result, ServerURL.GameServerUrl("/"));
				curWebView.commandLinkHandler = webViewCommandHandler;
				checkUrl = WebViewBase.GetNextUrl();
			}
			else
			{
				mode = errorMode;
			}
		}
		else
		{
			mode = errorMode;
		}
		return null;
	}

	private bool webViewCommandHandler(string command)
	{
		int result;
		if (null == curWebView)
		{
			result = 0;
		}
		else if (string.IsNullOrEmpty(command))
		{
			result = 0;
		}
		else
		{
			extraWebViewCommandFlag = curWebView.extraSceneChangeCommand(command);
			if (extraWebViewCommandFlag)
			{
				StartButton instance = StartButton.Instance;
				if (null != instance)
				{
					instance.PauseRelease();
				}
				TimeScaleUtil.One();
			}
			result = (extraWebViewCommandFlag ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void PushProfile()
	{
		if (!IsChangingSituation)
		{
			mode = MODE_PAUSETOWN.profile;
		}
	}

	public void PushGameCenter()
	{
		if (IsChangingSituation)
		{
			return;
		}
		MerlinGameCenter.Instance.Auth(delegate(MerlinGameCenter gc)
		{
			if (gc.Authenticated)
			{
				gc.ShowAchievements();
			}
		});
	}

	public void PushMyWeapon(GameObject obj)
	{
		if (IsChangingSituation || MapetDetailUtil.IsOpened() || openMyWeapon != 0)
		{
			return;
		}
		__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler = delegate
		{
			openMyWeapon = DetailShowStatus.Shown;
		};
		openMyWeapon = DetailShowStatus.Show;
		UserData current = UserData.Current;
		object obj2 = null;
		if (oldDeck)
		{
			obj2 = current.MainWeapon;
		}
		else
		{
			obj2 = current.AngelWeapon;
			if (obj.name == "WeaponIconDe")
			{
				obj2 = current.DevilWeapon;
			}
		}
		object obj3 = obj2;
		if (!(obj3 is RespWeapon))
		{
			obj3 = RuntimeServices.Coerce(obj3, typeof(RespWeapon));
		}
		GameObject gameObject = WeaponDetailUtil.Open((RespWeapon)obj3, this.gameObject, inHandler);
		float z = -1100f;
		Vector3 localPosition = gameObject.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
		ExtensionsModule.FindChild(GetSituation(1).gameObject, "Default").SetActive(value: false);
	}

	public void PushMyMapet()
	{
		if (!IsChangingSituation && !WeaponDetailUtil.IsOpened() && openMyMapet == DetailShowStatus.Closed)
		{
			__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler = delegate
			{
				openMyMapet = DetailShowStatus.Shown;
			};
			openMyMapet = DetailShowStatus.Show;
			UserData current = UserData.Current;
			GameObject gameObject = MapetDetailUtil.Open(current.CurrentPoppetNewOrOldDeck, this.gameObject, inHandler);
			float z = -1100f;
			Vector3 localPosition = gameObject.transform.localPosition;
			float num = (localPosition.z = z);
			Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
			ExtensionsModule.FindChild(GetSituation(1).gameObject, "Default").SetActive(value: false);
		}
	}

	public void PushNews()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.news;
			errorMode = MODE_PAUSETOWN.top;
			ApiInfo apiInfo = new ApiInfo();
			apiInfo.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			HtmlRequest(apiInfo);
		}
	}

	public void PushHelp()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.help;
			errorMode = MODE_PAUSETOWN.top;
			ApiHelp apiHelp = new ApiHelp();
			apiHelp.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			HtmlRequest(apiHelp);
		}
	}

	public void PushSupport()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.support;
			errorMode = MODE_PAUSETOWN.top;
			ApiWebContact apiWebContact = new ApiWebContact();
			apiWebContact.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			MerlinServer.Request(apiWebContact, CallBackHtmlRequest);
		}
	}

	public void PushCredit()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.credit;
			errorMode = MODE_PAUSETOWN.top;
			ApiWebStaffCredit apiWebStaffCredit = new ApiWebStaffCredit();
			apiWebStaffCredit.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			MerlinServer.Request(apiWebStaffCredit, CallBackHtmlRequest);
		}
	}

	public void PushGraphicsSetting()
	{
		if (!IsChangingSituation)
		{
			mode = MODE_PAUSETOWN.graphicsSetting;
		}
	}

	public void PushSoundSetting()
	{
		if (!IsChangingSituation)
		{
			mode = MODE_PAUSETOWN.soundSetting;
		}
	}

	public void PushPadSetting()
	{
		if (!IsChangingSituation)
		{
			mode = MODE_PAUSETOWN.padSetting;
		}
	}

	public void PushTerminal()
	{
		if (IsChangingSituation)
		{
			return;
		}
		MerlinServer.Request(ApiLocalDataUpload.WithUserData(), delegate
		{
			nextMode = MODE_PAUSETOWN.terminal;
			errorMode = MODE_PAUSETOWN.top;
			ApiEntryAuthData apiEntryAuthData = new ApiEntryAuthData();
			apiEntryAuthData.token = CurrentInfo.Token;
			apiEntryAuthData.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			MerlinServer.Request(apiEntryAuthData, CallBackHtmlRequest);
		});
	}

	public void PushSerial()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.serial;
			errorMode = MODE_PAUSETOWN.top;
			ApiSerial apiSerial = new ApiSerial();
			apiSerial.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			HtmlRequest(apiSerial);
		}
	}

	public void PushInvite()
	{
		if (!IsChangingSituation)
		{
			nextMode = MODE_PAUSETOWN.friendInvite;
			errorMode = MODE_PAUSETOWN.top;
			ApiFriendInvite apiFriendInvite = new ApiFriendInvite();
			apiFriendInvite.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				mode = errorMode;
			});
			HtmlRequest(apiFriendInvite);
		}
	}

	private void PushOtherSetting()
	{
		if (!IsChangingSituation)
		{
			mode = MODE_PAUSETOWN.OtherSetting;
		}
	}

	public void PushGoTitle()
	{
		if (!IsChangingSituation)
		{
			TimeScaleUtil.One();
			gotoTitleFlag = true;
			SceneChanger.ChangeTo(SceneID.Boot);
		}
	}

	public void PushBack()
	{
		if (IsChangingSituation || closeFlag)
		{
			return;
		}
		if (openMyMapet == DetailShowStatus.Shown)
		{
			openMyMapet = DetailShowStatus.Close;
			__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler = delegate
			{
				ExtensionsModule.FindChild(GetSituation(1).gameObject, "default").SetActive(value: true);
				openMyMapet = DetailShowStatus.Closed;
			};
			MapetDetailUtil.Close(outHandler);
			return;
		}
		if (openMyWeapon == DetailShowStatus.Shown)
		{
			openMyWeapon = DetailShowStatus.Close;
			__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler2 = delegate
			{
				openMyWeapon = DetailShowStatus.Closed;
				ExtensionsModule.FindChild(GetSituation(1).gameObject, "default").SetActive(value: true);
			};
			WeaponDetailUtil.Close(outHandler2);
			return;
		}
		switch (mode)
		{
		case MODE_PAUSETOWN.top:
			base.startButton.pushStartButton();
			closeFlag = true;
			break;
		case MODE_PAUSETOWN.myWeapon:
			mode = MODE_PAUSETOWN.profile;
			break;
		case MODE_PAUSETOWN.myMapet:
			mode = MODE_PAUSETOWN.profile;
			break;
		case MODE_PAUSETOWN.autoWordMenu:
			mode = MODE_PAUSETOWN.profile;
			break;
		case MODE_PAUSETOWN.soundSetting:
			SaveVolume();
			mode = MODE_PAUSETOWN.top;
			break;
		case MODE_PAUSETOWN.padSetting:
			SavePad();
			mode = MODE_PAUSETOWN.top;
			break;
		case MODE_PAUSETOWN.graphicsSetting:
			SaveGraphic();
			mode = MODE_PAUSETOWN.top;
			break;
		case MODE_PAUSETOWN.OtherSetting:
			SaveOtherSetting();
			mode = MODE_PAUSETOWN.top;
			break;
		default:
			mode = MODE_PAUSETOWN.top;
			break;
		case MODE_PAUSETOWN.soundDownload:
			break;
		}
		if ((bool)curWebView)
		{
			curWebView.Clear();
			curWebView.Close();
			curWebView = null;
		}
	}

	public void PushDownloadBGM()
	{
		if (!UserData.Current.userMiscInfo.bgmLoad)
		{
			mode = MODE_PAUSETOWN.soundDownload;
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024PushDownloadBGM_0024closure_00243747_002418351(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void PushAutoWordMenu()
	{
		mode = MODE_PAUSETOWN.autoWordMenu;
	}

	private void CodeCopy()
	{
		Type typeFromHandle = typeof(GUIUtility);
		PropertyInfo property = typeFromHandle.GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.NonPublic);
		property.SetValue(null, "bla bla", null);
	}

	private EnumRaidWordTypes GetWordType(string typeString)
	{
		EnumRaidWordTypes result = EnumRaidWordTypes.Start;
		if (typeString == "0 BattleStart")
		{
			result = EnumRaidWordTypes.Start;
		}
		if (typeString == "1 ButtonSkill")
		{
			result = EnumRaidWordTypes.Skill;
		}
		if (typeString == "2 ButtonDamage")
		{
			result = EnumRaidWordTypes.Damage;
		}
		if (typeString == "3 ButtonHP0")
		{
			result = EnumRaidWordTypes.Dead;
		}
		if (typeString == "4 ButtonWin")
		{
			result = EnumRaidWordTypes.KillBoss;
		}
		if (typeString == "5 ButtonJoint")
		{
			result = EnumRaidWordTypes.Welcome;
		}
		return result;
	}

	private MRaidWords[] GetMasterWords(string typeString)
	{
		EnumRaidWordTypes wordType = GetWordType(typeString);
		return MRaidWords.getWords(wordType);
	}

	private MRaidWords[] GetMasterWords(EnumRaidWordTypes type)
	{
		return MRaidWords.getWords(type);
	}

	private void Comment(GameObject sender)
	{
		checked
		{
			if (!CommentSelectDialog.IsRunning)
			{
				GameObject gameObject = ((GameObject)UnityEngine.Object.Instantiate(commentSelect)) as GameObject;
				CommentSelectDialog component = gameObject.GetComponent<CommentSelectDialog>();
				string text = sender.transform.parent.name;
				if (!commentLabelDictionary.ContainsKey(text))
				{
					throw new AssertionFailedException(text);
				}
				if (!(ExtensionsModule.FindChild(sender, "TextButtonTitle") != null))
				{
					throw new AssertionFailedException("sender.FindChild('TextButtonTitle') != null");
				}
				if (!(ExtensionsModule.FindChild(sender, "TextButtonTitle").GetComponent<UILabelBase>() != null))
				{
					throw new AssertionFailedException("sender.FindChild('TextButtonTitle').GetComponent[of UILabelBase]() != null");
				}
				commentUpdateTarget = commentLabelDictionary[text];
				component = gameObject.GetComponent<CommentSelectDialog>();
				component.UpdateCommentCallback = UpdateCommentCallback;
				component.titleLabel.text = ExtensionsModule.FindChild(sender, "TextButtonTitle").GetComponent<UILabelBase>().text;
				currentWordType = GetWordType(text);
				string[] array = ArrayMap.MRaidWordsToStr(GetMasterWords(text), (MRaidWords m) => m.Name.ToString());
				int num = 0;
				int i = 0;
				string[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					num += array2[i].Length;
				}
				component.Initialize(array, commentUpdateTarget.text);
			}
		}
	}

	private void UpdateCommentCallback(System.Collections.Generic.List<string> lines)
	{
		_0024UpdateCommentCallback_0024locals_002414405 _0024UpdateCommentCallback_0024locals_0024 = new _0024UpdateCommentCallback_0024locals_002414405();
		_0024UpdateCommentCallback_0024locals_0024._0024lines = lines;
		commentUpdateTarget.text = string.Join("\n", _0024UpdateCommentCallback_0024locals_0024._0024lines.ToArray());
		UserData current = UserData.Current;
		__PauseTown_UpdateCommentCallback_0024callable164_0024815_13__ _PauseTown_UpdateCommentCallback_0024callable164_0024815_13__ = new _0024UpdateCommentCallback_0024ToIds_00243751(_0024UpdateCommentCallback_0024locals_0024, this).Invoke;
		UserMiscInfo.RaidData raidData = current.userMiscInfo.raidData;
		raidData.Put(currentWordType, _PauseTown_UpdateCommentCallback_0024callable164_0024815_13__());
	}

	private void LoadComments(Dictionary<string, UILabelBase> dict)
	{
		_0024LoadComments_0024locals_002414406 _0024LoadComments_0024locals_0024 = new _0024LoadComments_0024locals_002414406();
		UserData current = UserData.Current;
		_0024LoadComments_0024locals_0024._0024raidData = current.userMiscInfo.raidData;
		__PauseTown_LoadComments_0024callable162_0024840_13__ _PauseTown_LoadComments_0024callable162_0024840_13__ = new _0024LoadComments_0024load_00243730(_0024LoadComments_0024locals_0024).Invoke;
		dict["0 BattleStart"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.Start);
		dict["1 ButtonSkill"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.Skill);
		dict["2 ButtonDamage"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.Damage);
		dict["3 ButtonHP0"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.Dead);
		dict["4 ButtonWin"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.KillBoss);
		dict["5 ButtonJoint"].text = _PauseTown_LoadComments_0024callable162_0024840_13__(EnumRaidWordTypes.Welcome);
	}

	public int GetMySocialID()
	{
		UserData current = UserData.Current;
		return current.userStatus.TSocialPlayerId;
	}

	public string GetTeamName()
	{
		UserData current = UserData.Current;
		string text = current.userParty.GetLeader().Name;
		return UIBasicUtility.SafeFormat("{0}チーム", text);
	}

	public override void ReqExit()
	{
		if (mode == MODE_PAUSETOWN.soundSetting)
		{
			SaveVolume();
		}
		if (mode == MODE_PAUSETOWN.graphicsSetting)
		{
			SaveGraphic();
		}
		if (mode == MODE_PAUSETOWN.padSetting && !gotoTitleFlag)
		{
			SavePad();
		}
		if (mode == MODE_PAUSETOWN.OtherSetting)
		{
			SaveOtherSetting();
		}
		if (MapetDetailUtil.IsOpened())
		{
			MapetDetailUtil.Close();
		}
		if (WeaponDetailUtil.IsOpened())
		{
			WeaponDetailUtil.Close();
		}
		mode = MODE_PAUSETOWN.exit;
		BattleHUD.ShowForTown();
		curWebView = null;
		WebViewBase.EndWebView();
	}

	public override void ReqStart()
	{
		BattleHUD.ShowForPauseTown();
		if (initFlag)
		{
			mode = MODE_PAUSETOWN.top;
			textDate.text = MerlinDateTime.Now.ToString("HH:mm");
			lastMode = -1;
			closeFlag = false;
		}
	}

	public override bool CanExit()
	{
		return !IsChangingSituation && mode == MODE_PAUSETOWN.exit;
	}

	public MODE_PAUSETOWN GetMode()
	{
		return mode;
	}

	internal void _0024SceneAwake_0024closure_00242933()
	{
		if (!debugSerial)
		{
			objSerial.SetActive(value: false);
		}
		if (!debugInvite)
		{
			objInvite.SetActive(value: false);
		}
		textDate.text = MerlinDateTime.Now.ToString("HH:mm");
		mode = MODE_PAUSETOWN.top;
		lastMode = -1;
		mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/MuppetListItem") as GameObject;
		weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/WeaponListItem") as GameObject;
		initFlag = true;
		closeFlag = false;
		if (inviteButton != null)
		{
			inviteButton.gameObject.SetActive(!ApiExamVer.IsExamVer);
		}
		if ((bool)gameCenterButtonLabel)
		{
			gameCenterButtonLabel.text = "Google\nplay games";
		}
	}

	internal void _0024PushGameCenter_0024closure_00243734(MerlinGameCenter gc)
	{
		if (gc.Authenticated)
		{
			gc.ShowAchievements();
		}
	}

	internal void _0024PushMyWeapon_0024cb_00243735(GameObject go)
	{
		openMyWeapon = DetailShowStatus.Shown;
	}

	internal void _0024PushMyMapet_0024cb_00243736(GameObject go)
	{
		openMyMapet = DetailShowStatus.Shown;
	}

	internal void _0024PushNews_0024closure_00243737()
	{
		mode = errorMode;
	}

	internal void _0024PushHelp_0024closure_00243738()
	{
		mode = errorMode;
	}

	internal void _0024PushSupport_0024closure_00243739()
	{
		mode = errorMode;
	}

	internal void _0024PushCredit_0024closure_00243740()
	{
		mode = errorMode;
	}

	internal void _0024PushTerminal_0024closure_00243741(RequestBase r)
	{
		nextMode = MODE_PAUSETOWN.terminal;
		errorMode = MODE_PAUSETOWN.top;
		ApiEntryAuthData apiEntryAuthData = new ApiEntryAuthData();
		apiEntryAuthData.token = CurrentInfo.Token;
		apiEntryAuthData.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
		{
			mode = errorMode;
		});
		MerlinServer.Request(apiEntryAuthData, CallBackHtmlRequest);
	}

	internal void _0024_0024PushTerminal_0024closure_00243741_0024closure_00243742()
	{
		mode = errorMode;
	}

	internal void _0024PushSerial_0024closure_00243743()
	{
		mode = errorMode;
	}

	internal void _0024PushInvite_0024closure_00243744()
	{
		mode = errorMode;
	}

	internal void _0024PushBack_0024cb_00243745(GameObject go)
	{
		ExtensionsModule.FindChild(GetSituation(1).gameObject, "default").SetActive(value: true);
		openMyMapet = DetailShowStatus.Closed;
	}

	internal void _0024PushBack_0024cb2_00243746(GameObject go)
	{
		openMyWeapon = DetailShowStatus.Closed;
		ExtensionsModule.FindChild(GetSituation(1).gameObject, "default").SetActive(value: true);
	}

	internal IEnumerator _0024PushDownloadBGM_0024closure_00243747()
	{
		return new _0024_0024PushDownloadBGM_0024closure_00243747_002418351(this).GetEnumerator();
	}

	internal string _0024Comment_0024closure_00243752(MRaidWords m)
	{
		return m.Name.ToString();
	}
}
