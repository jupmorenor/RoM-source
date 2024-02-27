using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MyHomeEquipMain : MyhomeSubSceneTopMain
{
	[Serializable]
	public enum MY_HOME_EQUIP_START_MODE
	{
		None,
		MainWeaponList,
		Sub1WeaponList,
		Sub2WeaponList,
		PoppetList,
		Support
	}

	[Serializable]
	public enum MY_HOME_EQUIP_MAIN
	{
		Equip,
		WeaponList,
		PoppetList,
		Support,
		SupportWeaponList,
		SupportPoppetList,
		Max
	}

	[Serializable]
	public enum Select
	{
		Main,
		Sub1,
		Sub2,
		MainAngel,
		SubAngel1,
		SubAngel2,
		SubAngel3,
		PetAngel,
		MainDevil,
		SubDevil1,
		SubDevil2,
		SubDevil3,
		PetDevil,
		Pet
	}

	[Serializable]
	public enum BOX_INFO
	{
		WEAPON,
		POPPET
	}

	[Serializable]
	public enum SupportNo
	{
		Main,
		Sub1,
		Sub2,
		Pet,
		Max
	}

	[Serializable]
	public class SupportSet
	{
		public UILabelBase hpLabel;

		public UILabelBase atkLabel;

		public UISprite elemSprite;

		public UISprite styleSprite;

		public void ShowData(int atk, int hp, int elem, bool elemLight, int style, bool styleLight)
		{
			UIBasicUtility.SetLabel(atkLabel, atk.ToString("0"), show: true);
			UIBasicUtility.SetLabel(hpLabel, hp.ToString("0"), show: true);
			UIBasicUtility.SetElementSprite(elemSprite, elem, elemLight, show: true);
			UIBasicUtility.SetStyleSprite(styleSprite, style, styleLight, show: true);
		}
	}

	[Serializable]
	public class SupportButtonIconPanel
	{
		public GameObject supportButtonAtk;

		public GameObject supportButtonHp;

		public GameObject supportButtonCustom;

		public void SwitchButton(int index)
		{
			if ((bool)supportButtonAtk)
			{
				supportButtonAtk.SetActive(index == 1);
			}
			if ((bool)supportButtonHp)
			{
				supportButtonHp.SetActive(index == 2);
			}
			if ((bool)supportButtonCustom)
			{
				GameObject gameObject = supportButtonCustom;
				bool num = index == 3;
				if (!num)
				{
					num = index == 0;
				}
				gameObject.SetActive(num);
			}
		}
	}

	[Serializable]
	internal class _0024UpdateDeckPanel_0024locals_002414521
	{
		internal BoxDeckPanel _0024lastBoxDeckPanel;
	}

	[Serializable]
	internal class _0024SendOldEquipCore_0024locals_002414522
	{
		internal ApiUpdateDeck _0024req;
	}

	[Serializable]
	internal class _0024SendDeck2EquipCore_0024locals_002414523
	{
		internal ApiUpdateDeck2 _0024req;
	}

	[Serializable]
	internal class _0024UpdateDeckPanel_0024closure_00243270
	{
		internal _0024UpdateDeckPanel_0024locals_002414521 _0024_0024locals_002415158;

		public _0024UpdateDeckPanel_0024closure_00243270(_0024UpdateDeckPanel_0024locals_002414521 _0024_0024locals_002415158)
		{
			this._0024_0024locals_002415158 = _0024_0024locals_002415158;
		}

		public void Invoke(UITweener tween)
		{
			_0024_0024locals_002415158._0024lastBoxDeckPanel.gameObject.SetActive(value: false);
		}
	}

	[Serializable]
	internal class _0024UpdateDeckPanel_0024closure_00243271
	{
		internal _0024UpdateDeckPanel_0024locals_002414521 _0024_0024locals_002415159;

		public _0024UpdateDeckPanel_0024closure_00243271(_0024UpdateDeckPanel_0024locals_002414521 _0024_0024locals_002415159)
		{
			this._0024_0024locals_002415159 = _0024_0024locals_002415159;
		}

		public void Invoke(UITweener tween)
		{
			_0024_0024locals_002415159._0024lastBoxDeckPanel.gameObject.SetActive(value: false);
		}
	}

	[Serializable]
	internal class _0024SendOldEquipCore_0024closure_00243276
	{
		internal _0024SendOldEquipCore_0024locals_002414522 _0024_0024locals_002415160;

		internal MyHomeEquipMain _0024this_002415161;

		public _0024SendOldEquipCore_0024closure_00243276(_0024SendOldEquipCore_0024locals_002414522 _0024_0024locals_002415160, MyHomeEquipMain _0024this_002415161)
		{
			this._0024_0024locals_002415160 = _0024_0024locals_002415160;
			this._0024this_002415161 = _0024this_002415161;
		}

		public void Invoke(RequestBase r)
		{
			if (!_0024_0024locals_002415160._0024req.HasMasterVersionError && !_0024_0024locals_002415160._0024req.HasDataVersionError && !_0024_0024locals_002415160._0024req.HasClientVersionError && !_0024_0024locals_002415160._0024req.GotoBootError && !_0024_0024locals_002415160._0024req.Is500Error && !_0024_0024locals_002415160._0024req.Is400Error)
			{
				SceneChanger.Cancel();
				_0024this_002415161.sendResult = true;
				_0024this_002415161.sendError = true;
			}
			else
			{
				_0024this_002415161.sendResult = true;
			}
		}
	}

	[Serializable]
	internal class _0024SendDeck2EquipCore_0024closure_00243280
	{
		internal _0024SendDeck2EquipCore_0024locals_002414523 _0024_0024locals_002415162;

		internal MyHomeEquipMain _0024this_002415163;

		public _0024SendDeck2EquipCore_0024closure_00243280(_0024SendDeck2EquipCore_0024locals_002414523 _0024_0024locals_002415162, MyHomeEquipMain _0024this_002415163)
		{
			this._0024_0024locals_002415162 = _0024_0024locals_002415162;
			this._0024this_002415163 = _0024this_002415163;
		}

		public void Invoke(RequestBase r)
		{
			if (!_0024_0024locals_002415162._0024req.HasMasterVersionError && !_0024_0024locals_002415162._0024req.HasDataVersionError && !_0024_0024locals_002415162._0024req.HasClientVersionError && !_0024_0024locals_002415162._0024req.GotoBootError && !_0024_0024locals_002415162._0024req.Is500Error && !_0024_0024locals_002415162._0024req.Is400Error)
			{
				SceneChanger.Cancel();
				_0024this_002415163.sendResult = true;
				_0024this_002415163.sendError = true;
			}
			else
			{
				_0024this_002415163.sendResult = true;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SendOldEquipCore_002421720 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002421721;

			internal UserDeckData _0024udecks_002421722;

			internal RespDeck _0024d_002421723;

			internal BoxId[] _0024ids_002421724;

			internal bool _0024isCurrent_002421725;

			internal int _0024_002411374_002421726;

			internal RespDeck[] _0024_002411375_002421727;

			internal int _0024_002411376_002421728;

			internal _0024SendOldEquipCore_0024locals_002414522 _0024_0024locals_002421729;

			internal MyHomeEquipMain _0024self__002421730;

			public _0024(MyHomeEquipMain self_)
			{
				_0024self__002421730 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024_0024locals_002421729 = new _0024SendOldEquipCore_0024locals_002414522();
						_0024ud_002421721 = UserData.Current;
						if (_0024ud_002421721 == null)
						{
							throw new AssertionFailedException("ud");
						}
						_0024udecks_002421722 = _0024ud_002421721.userDeckData;
						_0024_0024locals_002421729._0024req = new ApiUpdateDeck();
						_0024_002411374_002421726 = 0;
						_0024_002411375_002421727 = _0024udecks_002421722.all();
						for (_0024_002411376_002421728 = _0024_002411375_002421727.Length; _0024_002411374_002421726 < _0024_002411376_002421728; _0024_002411374_002421726++)
						{
							_0024ids_002421724 = _0024_002411375_002421727[_0024_002411374_002421726].ToApiBoxIdArray;
							_0024isCurrent_002421725 = false;
							if (_0024_002411375_002421727[_0024_002411374_002421726].No == _0024ud_002421721.CurrentDeck.No)
							{
								_0024isCurrent_002421725 = true;
							}
							ref BoxId reference = ref _0024ids_002421724[0];
							reference = _0024self__002421730.curWeaponBoxId;
							ref BoxId reference2 = ref _0024ids_002421724[1];
							reference2 = _0024self__002421730.curSubWeapon1BoxId;
							ref BoxId reference3 = ref _0024ids_002421724[2];
							reference3 = _0024self__002421730.curSubWeapon2BoxId;
							ref BoxId reference4 = ref _0024ids_002421724[3];
							reference4 = _0024self__002421730.curMainMuppetBoxId;
							_0024_0024locals_002421729._0024req.add(_0024_002411375_002421727[_0024_002411374_002421726].No, _0024ids_002421724, _0024isCurrent_002421725);
						}
						_0024_0024locals_002421729._0024req.ErrorHandler = new _0024SendOldEquipCore_0024closure_00243276(_0024_0024locals_002421729, _0024self__002421730).Invoke;
						MerlinServer.Request(_0024_0024locals_002421729._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
						{
							startMode = MY_HOME_EQUIP_START_MODE.None;
							_0024self__002421730.sendResult = true;
						}));
						goto case 2;
					case 2:
						if (!_0024self__002421730.sendResult)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002421730.sendError)
						{
							goto case 3;
						}
						goto IL_024d;
					case 3:
						if (SceneChanger.Hook != null)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002421730.InitSendHook();
						goto IL_024d;
					case 1:
						{
							result = 0;
							break;
						}
						IL_024d:
						YieldDefault(1);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeEquipMain _0024self__002421731;

		public _0024SendOldEquipCore_002421720(MyHomeEquipMain self_)
		{
			_0024self__002421731 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421731);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SendDeck2EquipCore_002421732 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UserData _0024ud_002421733;

			internal RespDeck2[] _0024decks2_002421734;

			internal RespDeck2[] _0024respDecks_002421735;

			internal int _0024i_002421736;

			internal RespDeck2 _0024deck_002421737;

			internal int _0024_002411378_002421738;

			internal int _0024_002411379_002421739;

			internal _0024SendDeck2EquipCore_0024locals_002414523 _0024_0024locals_002421740;

			internal MyHomeEquipMain _0024self__002421741;

			public _0024(MyHomeEquipMain self_)
			{
				_0024self__002421741 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024locals_002421740 = new _0024SendDeck2EquipCore_0024locals_002414523();
					_0024ud_002421733 = UserData.Current;
					if (_0024ud_002421733 == null)
					{
						throw new AssertionFailedException("ud");
					}
					_0024decks2_002421734 = _0024ud_002421733.userDeckData2.Decks2;
					_0024respDecks_002421735 = new RespDeck2[0];
					_0024_002411378_002421738 = 0;
					_0024_002411379_002421739 = 5;
					if (_0024_002411379_002421739 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (_0024_002411378_002421738 < _0024_002411379_002421739)
					{
						_0024i_002421736 = _0024_002411378_002421738;
						_0024_002411378_002421738++;
						_0024deck_002421737 = new RespDeck2();
						RespDeck2 respDeck = _0024deck_002421737;
						RespDeck2[] array = _0024decks2_002421734;
						RespDeck2 templDecks = array[RuntimeServices.NormalizeArrayIndex(array, _0024i_002421736)];
						WeaponEquipments[] wepEquips = _0024self__002421741.wepEquips;
						WeaponEquipments wep = wepEquips[RuntimeServices.NormalizeArrayIndex(wepEquips, _0024i_002421736)];
						PoppetEquipments[] petEquips = _0024self__002421741.petEquips;
						respDeck.fromEquipments(templDecks, wep, petEquips[RuntimeServices.NormalizeArrayIndex(petEquips, _0024i_002421736)]);
						_0024respDecks_002421735 = (RespDeck2[])RuntimeServices.AddArrays(typeof(RespDeck2), _0024respDecks_002421735, new RespDeck2[1] { _0024deck_002421737 });
					}
					_0024_0024locals_002421740._0024req = ApiUpdateDeck2.FromDecks(_0024respDecks_002421735, checked(_0024self__002421741.curDeckIndex + 1));
					_0024_0024locals_002421740._0024req.ErrorHandler = new _0024SendDeck2EquipCore_0024closure_00243280(_0024_0024locals_002421740, _0024self__002421741).Invoke;
					MerlinServer.Request(_0024_0024locals_002421740._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
					{
						startMode = MY_HOME_EQUIP_START_MODE.None;
						_0024self__002421741.sendResult = true;
					}));
					goto case 2;
				case 2:
					if (!_0024self__002421741.sendResult)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__002421741.sendError)
					{
						goto case 3;
					}
					goto IL_0215;
				case 3:
					if (SceneChanger.Hook != null)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002421741.InitSendHook();
					goto IL_0215;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0215:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MyHomeEquipMain _0024self__002421742;

		public _0024SendDeck2EquipCore_002421732(MyHomeEquipMain self_)
		{
			_0024self__002421742 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421742);
		}
	}

	[NonSerialized]
	private static MY_HOME_EQUIP_START_MODE startMode;

	[NonSerialized]
	private static int startDeck = -1;

	[NonSerialized]
	private static bool delaySendEquipments;

	private MY_HOME_EQUIP_MAIN mode;

	private MY_HOME_EQUIP_MAIN lastMode;

	[NonSerialized]
	protected static readonly Color[] deckNumberColors = new Color[5]
	{
		new Color(1f, 0.7921569f, 0.7921569f),
		new Color(46f / 51f, 1f, 0.80784315f),
		new Color(0.85490197f, 0.9098039f, 1f),
		new Color(0.9372549f, 1f, 0.8235294f),
		new Color(0.9843137f, 14f / 15f, 40f / 51f)
	};

	[NonSerialized]
	protected static readonly Color[] deckColors = new Color[5]
	{
		new Color(0.95686275f, 33f / 85f, 33f / 85f),
		new Color(19f / 85f, 83f / 85f, 0.6039216f),
		new Color(3f / 85f, 0.6392157f, 83f / 85f),
		new Color(84f / 85f, 1f, 0.10980392f),
		new Color(0.99215686f, 0.69803923f, 0.21960784f)
	};

	[NonSerialized]
	protected static readonly Color[] atkHpColors = new Color[2]
	{
		new Color(1f, 0.4862745f, 0.2509804f),
		new Color(0.5882353f, 0.8980392f, 0.2627451f)
	};

	protected int selectType;

	public int count;

	public WeaponInfo mainWeaponInfo;

	public WeaponInfo sub1WeaponInfo;

	public WeaponInfo sub2WeaponInfo;

	public WeaponInfo detailInfo;

	public WeaponList weaponList;

	public UISprite bgSprite;

	public GameObject blackBg;

	public GameObject grayBg;

	[NonSerialized]
	protected static string bgSpriteName;

	[NonSerialized]
	protected static RespWeapon lastWeaponInfo;

	[NonSerialized]
	protected static RespWeapon lastWeaponInfo2;

	private RespWeapon[] listWeaponInfo;

	private BoxId curWeaponBoxId;

	private BoxId curSubWeapon1BoxId;

	private BoxId curSubWeapon2BoxId;

	private BoxId lastWeaponBoxId;

	private BoxId lastSubWeapon1BoxId;

	private BoxId lastSubWeapon2BoxId;

	private RespPoppet[] listMuppetInfo;

	public MuppetInfo muppetInfo;

	public MuppetInfo muppetDetailInfo;

	public MapetList mapetList;

	public BoxInfoController boxInfoController;

	[NonSerialized]
	protected static RespPoppet lastMapetInfo;

	private BoxId curMainMuppetBoxId;

	private BoxId lastMainMuppetBoxId;

	private bool showWeaponDetail;

	private bool showMuppetDetail;

	public UILabelBase playerHpLabel;

	public UILabelBase playerAtkLabel;

	public SupportSet[] supSets;

	protected bool sendEquipFlag;

	protected bool sendError;

	protected bool sendResult;

	public SupportButtonIconPanel supportButtonPanel;

	public GameObject supportButtonDialog;

	public SupportEquipInfo supprtEquipInfo;

	protected UIAutoTweener[] supportEquipAnims;

	protected int lastDeckIndex;

	public DeckButton deckButton;

	public DeckButton supportDeckButton;

	protected WeaponEquipments tmpWepEq;

	protected PoppetEquipments tmpPetEq;

	public BoxDeckPanel[] boxDeckPanels;

	protected int curBoxDeckPanel;

	protected BoxDeckPanel dummyBoxDeckPanel;

	public UIDraggablePanel draggablePanel;

	public SpringPanel dragSpring;

	public float springStartSpeed;

	public float springStrength;

	public float springDelay;

	public float springNextMinX;

	protected float springCurDelay;

	public float swipeSpeedScale;

	public float swipeMoment;

	public bool swipeSmoothStart;

	public int swipeMin;

	public int swipeMax;

	public bool swipeLoop;

	public EquipSupportMagicCircle magicCircle;

	public SwipePanel swipePanel;

	private bool showSupport;

	public GameObject skillWindow;

	public GameObject supportWindow;

	public static string BackScene
	{
		set
		{
			MyhomeSubSceneTopMain.backScene = value;
		}
	}

	public static string BgSpriteName
	{
		set
		{
			bgSpriteName = value;
		}
	}

	public static RespWeapon LastWeaponInfo => lastWeaponInfo;

	public static RespWeapon LastWeaponInfo2 => lastWeaponInfo2;

	public static RespPoppet LastMapetInfo => lastMapetInfo;

	private int curDeckIndex
	{
		get
		{
			return UserData.Current.userDeckData2.CurrentDeck;
		}
		set
		{
			UserData.Current.userDeckData2.CurrentDeck = value;
		}
	}

	private WeaponEquipments[] wepEquips
	{
		get
		{
			return UserDeckData2.WepEquips;
		}
		set
		{
			UserDeckData2.WepEquips = value;
		}
	}

	private PoppetEquipments[] petEquips
	{
		get
		{
			return UserData.Current.userDeckData2.PetEquips;
		}
		set
		{
			UserData.Current.userDeckData2.PetEquips = value;
		}
	}

	private UserConfigData.DeckTypes[] deckTypes
	{
		get
		{
			return UserData.Current.userDeckData2.DeckTypes;
		}
		set
		{
			UserData.Current.userDeckData2.DeckTypes = value;
		}
	}

	public static MY_HOME_EQUIP_START_MODE StartMode
	{
		get
		{
			return startMode;
		}
		set
		{
			startMode = value;
		}
	}

	public static bool DelaySendEquipments => delaySendEquipments;

	public MY_HOME_EQUIP_MAIN Mode => mode;

	public static Color[] DeckNumberColors => deckNumberColors;

	public static Color[] DeckColors => deckColors;

	public static Color[] AtkHpColors => atkHpColors;

	public MyHomeEquipMain()
	{
		supSets = new SupportSet[4];
		lastDeckIndex = -1;
		springStartSpeed = 1f;
		springStrength = 10f;
		springDelay = 0.25f;
		springNextMinX = 240f;
		springCurDelay = -1f;
		swipeSpeedScale = 5f;
		swipeMoment = 30f;
		swipeMax = 5;
	}

	public static void StartOtherDeck(int startCurrentDeck)
	{
		startDeck = startCurrentDeck;
	}

	private void InitDetailWindow(GameObject go)
	{
		UIAutoTweenerStandAloneEx component = go.GetComponent<UIAutoTweenerStandAloneEx>();
		component.Start();
		UIAutoTweenerStandAloneEx.Hide(go);
	}

	public override void StartCore()
	{
		if ((bool)detailInfo)
		{
			Transform parent = detailInfo.gameObject.transform.parent;
			if ((bool)parent)
			{
				parent.gameObject.SetActive(value: true);
			}
		}
		if ((bool)supprtEquipInfo)
		{
			supportEquipAnims = supprtEquipInfo.GetComponentsInChildren<UIAutoTweener>(includeInactive: true);
		}
		if ((bool)supportButtonDialog)
		{
			UIAutoTweenerStandAloneEx.Hide(supportButtonDialog);
		}
		sendEquipFlag = false;
		StartInit();
	}

	public void InitDeck()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		int currentDeck = current.userDeckData2.CurrentDeck;
		if (startDeck >= 0)
		{
			currentDeck = startDeck;
			startDeck = -1;
			delaySendEquipments = true;
		}
		else
		{
			delaySendEquipments = false;
		}
		SetupDeck(currentDeck, loop: false, updateInfo: false);
		UpdateDeckPanel(curDeckIndex);
		RestoreCurDeck();
		SetSupportInfo(tmpWepEq, tmpPetEq);
		InitSwipePanel();
	}

	private void StartInit()
	{
		InitBoxDeckPanel();
		BoxDeckPanel[] array = boxDeckPanels;
		BoxDeckPanel boxDeckPanel = array[RuntimeServices.NormalizeArrayIndex(array, curBoxDeckPanel)];
		if ((bool)boxDeckPanel)
		{
			boxDeckPanel.gameObject.SetActive(value: true);
			if ((bool)boxDeckPanel.mainWeaponInfo)
			{
				mainWeaponInfo = boxDeckPanel.mainWeaponInfo;
			}
			if ((bool)boxDeckPanel.sub1WeaponInfo)
			{
				sub1WeaponInfo = boxDeckPanel.sub1WeaponInfo;
			}
			if ((bool)boxDeckPanel.sub2WeaponInfo)
			{
				sub2WeaponInfo = boxDeckPanel.sub2WeaponInfo;
			}
			if ((bool)boxDeckPanel.muppetInfo)
			{
				muppetInfo = boxDeckPanel.muppetInfo;
			}
			if ((bool)boxDeckPanel.playerHpLabel)
			{
				playerHpLabel = boxDeckPanel.playerHpLabel;
			}
			if ((bool)boxDeckPanel.playerAtkLabel)
			{
				playerAtkLabel = boxDeckPanel.playerAtkLabel;
			}
		}
		detailInfo.DestroyLevel();
		muppetDetailInfo.DestroyLevel();
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			InitDeck();
			mode = MY_HOME_EQUIP_MAIN.Equip;
			lastMode = mode;
			if (startMode == MY_HOME_EQUIP_START_MODE.MainWeaponList)
			{
				mode = MY_HOME_EQUIP_MAIN.WeaponList;
				lastMode = mode;
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Sub1WeaponList)
			{
				mode = MY_HOME_EQUIP_MAIN.WeaponList;
				lastMode = mode;
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Sub2WeaponList)
			{
				mode = MY_HOME_EQUIP_MAIN.WeaponList;
				lastMode = mode;
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.PoppetList)
			{
				mode = MY_HOME_EQUIP_MAIN.PoppetList;
				lastMode = mode;
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Support)
			{
				mode = MY_HOME_EQUIP_MAIN.Support;
			}
			lastMode = mode;
			ChangeSituation(GetSituation((int)mode));
			if (startMode == MY_HOME_EQUIP_START_MODE.MainWeaponList)
			{
				lastMode = MY_HOME_EQUIP_MAIN.Max;
				ShowListMainWeapon(null);
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Sub1WeaponList)
			{
				lastMode = MY_HOME_EQUIP_MAIN.Max;
				ShowListSub1Weapon(null);
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Sub2WeaponList)
			{
				lastMode = MY_HOME_EQUIP_MAIN.Max;
				ShowListSub2Weapon(null);
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.PoppetList)
			{
				lastMode = MY_HOME_EQUIP_MAIN.Max;
				ShowListMainMuppet(null);
			}
			else if (startMode == MY_HOME_EQUIP_START_MODE.Support)
			{
				lastMode = MY_HOME_EQUIP_MAIN.Max;
				PushCustomSupport(null);
			}
			else if ((bool)weaponList)
			{
				UserData current = UserData.Current;
				if (!current.IsValidDeck2 && current.MainWeapon != null)
				{
					weaponList.SetFocusItem(current.MainWeapon.Id.Value);
				}
			}
			StorageHUD.DoUpdateNow();
		});
		count = 0;
		GameObject gameObject = GameObject.Find("Myhome");
		if ((bool)gameObject)
		{
			gameObject.SetActive(value: false);
		}
		if ((bool)bgSprite)
		{
			bgSprite.gameObject.SetActive(value: false);
			if (!string.IsNullOrEmpty(bgSpriteName))
			{
				bgSprite.spriteName = bgSpriteName;
				bgSprite.gameObject.SetActive(value: true);
				bgSpriteName = string.Empty;
			}
		}
		if (string.IsNullOrEmpty(MyhomeSubSceneTopMain.backScene))
		{
			if ((bool)bgSprite)
			{
				bgSprite.gameObject.SetActive(value: false);
			}
			if (blackBg != null)
			{
				blackBg.SetActive(value: false);
			}
			if (grayBg != null)
			{
				grayBg.SetActive(value: true);
			}
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: true);
			}
		}
		else
		{
			if ((bool)bgSprite)
			{
				bgSprite.gameObject.SetActive(value: true);
			}
			if (blackBg != null)
			{
				blackBg.SetActive(value: true);
			}
			if (grayBg != null)
			{
				grayBg.SetActive(value: false);
			}
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		if (null != boxInfoController)
		{
			boxInfoController.SetWindowActive(on: false);
		}
		showSupport = false;
		ShowSupport(showSupport);
		InitSendHook();
	}

	public override void OnDestroy()
	{
		startMode = MY_HOME_EQUIP_START_MODE.None;
		base.OnDestroy();
	}

	public override void SceneUpdate()
	{
		checked
		{
			count++;
			if (IsChangingSituation)
			{
				return;
			}
		}
		if (mode != lastMode)
		{
			lastMode = mode;
			if (mode == MY_HOME_EQUIP_MAIN.WeaponList || mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
			{
				if (null != boxInfoController)
				{
					boxInfoController.SwitchInfoWindow(0);
				}
			}
			else if ((mode == MY_HOME_EQUIP_MAIN.PoppetList || mode == MY_HOME_EQUIP_MAIN.SupportPoppetList) && null != boxInfoController)
			{
				boxInfoController.SwitchInfoWindow(1);
			}
			ChangeSituation(GetSituation((int)mode));
			if (mode == MY_HOME_EQUIP_MAIN.WeaponList || mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
			{
				InfomationBarHUD.UpdateText(MTexts.Msg("$MHE_HELP_SELECT_SUPPORT_WEAPON"));
			}
			else if (mode == MY_HOME_EQUIP_MAIN.PoppetList || mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
			{
				InfomationBarHUD.UpdateText(MTexts.Msg("$MHE_HELP_SELECT_POPPET"));
			}
			else if (mode == MY_HOME_EQUIP_MAIN.Equip)
			{
				InfomationBarHUD.UpdateText(MTexts.Msg("$MHE_HELP_SELECT_EQUIP"));
				if ((bool)swipePanel)
				{
					swipePanel.Reset();
				}
			}
			else if (mode == MY_HOME_EQUIP_MAIN.Support)
			{
				InfomationBarHUD.UpdateText(MTexts.Msg("$MHE_HELP_SELECT_EQUIP"));
				InitTmpEquipments();
				SupportEquipInfo supportEquipInfo = supprtEquipInfo;
				int deckIndex = curDeckIndex;
				UserConfigData.DeckTypes[] array = deckTypes;
				supportEquipInfo.Init(deckIndex, array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)], tmpWepEq, tmpPetEq);
			}
		}
		if (mode == MY_HOME_EQUIP_MAIN.Equip)
		{
			UpdateSwipePanel();
		}
	}

	public void InitTmpEquipments()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (current.IsValidDeck2)
		{
			WeaponEquipments[] array = wepEquips;
			WeaponEquipments weaponEquipments = array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)];
			tmpWepEq = weaponEquipments;
			PoppetEquipments[] array2 = petEquips;
			PoppetEquipments poppetEquipments = array2[RuntimeServices.NormalizeArrayIndex(array2, curDeckIndex)];
			tmpPetEq = poppetEquipments;
		}
	}

	public void InitBoxDeckPanel()
	{
		if (boxDeckPanels == null)
		{
			return;
		}
		BoxDeckPanel[] array = boxDeckPanels;
		BoxDeckPanel boxDeckPanel = array[RuntimeServices.NormalizeArrayIndex(array, curBoxDeckPanel)];
		if ((bool)boxDeckPanel)
		{
			boxDeckPanel.gameObject.SetActive(value: true);
			int num = 0;
			Vector3 localPosition = boxDeckPanel.gameObject.transform.localPosition;
			float num2 = (localPosition.x = num);
			Vector3 vector2 = (boxDeckPanel.gameObject.transform.localPosition = localPosition);
			boxDeckPanel.DeckIndex = curDeckIndex;
			if ((bool)boxDeckPanel.mainWeaponInfo)
			{
				mainWeaponInfo = boxDeckPanel.mainWeaponInfo;
			}
			if ((bool)boxDeckPanel.sub1WeaponInfo)
			{
				sub1WeaponInfo = boxDeckPanel.sub1WeaponInfo;
			}
			if ((bool)boxDeckPanel.sub2WeaponInfo)
			{
				sub2WeaponInfo = boxDeckPanel.sub2WeaponInfo;
			}
			if ((bool)boxDeckPanel.muppetInfo)
			{
				muppetInfo = boxDeckPanel.muppetInfo;
			}
			if ((bool)boxDeckPanel.playerHpLabel)
			{
				playerHpLabel = boxDeckPanel.playerHpLabel;
			}
			if ((bool)boxDeckPanel.playerAtkLabel)
			{
				playerAtkLabel = boxDeckPanel.playerAtkLabel;
			}
		}
		BoxDeckPanel[] array2 = boxDeckPanels;
		BoxDeckPanel boxDeckPanel2 = array2[RuntimeServices.NormalizeArrayIndex(array2, checked(1 - curBoxDeckPanel))];
		if ((bool)boxDeckPanel2)
		{
			boxDeckPanel2.gameObject.SetActive(value: true);
			int num3 = 100000;
			Vector3 localPosition2 = boxDeckPanel2.gameObject.transform.localPosition;
			float num4 = (localPosition2.x = num3);
			Vector3 vector4 = (boxDeckPanel2.gameObject.transform.localPosition = localPosition2);
		}
	}

	public void SetupDeck(int index, bool loop, bool updateInfo)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (loop)
		{
			if (index < 0)
			{
				index = 4;
			}
			if (index >= 5)
			{
				index = 0;
			}
		}
		else
		{
			if (index < 0)
			{
				index = 0;
			}
			if (index >= 5)
			{
				index = 4;
			}
		}
		curDeckIndex = index;
		if (lastDeckIndex != curDeckIndex)
		{
			UpdateDeckButton(curDeckIndex);
			UpdateDeck(lastDeckIndex);
			if (updateInfo)
			{
				UpdateDeckPanel(lastDeckIndex);
			}
		}
		if (mode == MY_HOME_EQUIP_MAIN.Equip)
		{
			RestoreCurDeck();
			if (updateInfo)
			{
				SetSupportInfo(tmpWepEq, tmpPetEq);
			}
		}
		else if (mode == MY_HOME_EQUIP_MAIN.Support)
		{
			InitTmpEquipments();
			SupportEquipInfo supportEquipInfo = supprtEquipInfo;
			int deckIndex = curDeckIndex;
			UserConfigData.DeckTypes[] array = deckTypes;
			supportEquipInfo.Init(deckIndex, array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)], tmpWepEq, tmpPetEq);
		}
		lastDeckIndex = curDeckIndex;
	}

	public void UpdateDeckButton(int index)
	{
		UserConfigData.DeckTypes[] array = deckTypes;
		UserConfigData.DeckTypes index2 = array[RuntimeServices.NormalizeArrayIndex(array, index)];
		if (supportButtonPanel != null)
		{
			supportButtonPanel.SwitchButton((int)index2);
		}
		deckButton.UpdateDeckButton(index);
		supportDeckButton.UpdateDeckButton(index);
	}

	public void UpdateDeck(int index)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (current.IsValidDeck2 && index >= 0 && index < 5)
		{
			if (tmpWepEq != null)
			{
				curWeaponBoxId = tmpWepEq.MainTenshiWeapon.Id;
				curSubWeapon1BoxId = tmpWepEq.MainAkumaWeapon.Id;
				WeaponEquipments[] array = wepEquips;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = tmpWepEq;
			}
			if (tmpPetEq != null)
			{
				curMainMuppetBoxId = tmpPetEq.MainPoppet.Id;
				PoppetEquipments[] array2 = petEquips;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = tmpPetEq;
			}
		}
	}

	public void UpdateDeckPanel(int index)
	{
		_0024UpdateDeckPanel_0024locals_002414521 _0024UpdateDeckPanel_0024locals_0024 = new _0024UpdateDeckPanel_0024locals_002414521();
		dragSpring.enabled = false;
		if (curDeckIndex != index)
		{
			BoxDeckPanel[] array = boxDeckPanels;
			_0024UpdateDeckPanel_0024locals_0024._0024lastBoxDeckPanel = array[RuntimeServices.NormalizeArrayIndex(array, curBoxDeckPanel)];
			if (curBoxDeckPanel == 0)
			{
				curBoxDeckPanel = 1;
			}
			else
			{
				curBoxDeckPanel = 0;
			}
		}
		BoxDeckPanel[] array2 = boxDeckPanels;
		BoxDeckPanel boxDeckPanel = array2[RuntimeServices.NormalizeArrayIndex(array2, curBoxDeckPanel)];
		if ((bool)boxDeckPanel)
		{
			boxDeckPanel.DeckIndex = curDeckIndex;
			if ((bool)boxDeckPanel.mainWeaponInfo)
			{
				mainWeaponInfo = boxDeckPanel.mainWeaponInfo;
			}
			if ((bool)boxDeckPanel.sub1WeaponInfo)
			{
				sub1WeaponInfo = boxDeckPanel.sub1WeaponInfo;
			}
			if ((bool)boxDeckPanel.sub2WeaponInfo)
			{
				sub2WeaponInfo = boxDeckPanel.sub2WeaponInfo;
			}
			if ((bool)boxDeckPanel.muppetInfo)
			{
				muppetInfo = boxDeckPanel.muppetInfo;
			}
			if ((bool)boxDeckPanel.playerHpLabel)
			{
				playerHpLabel = boxDeckPanel.playerHpLabel;
			}
			if ((bool)boxDeckPanel.playerAtkLabel)
			{
				playerAtkLabel = boxDeckPanel.playerAtkLabel;
			}
		}
		if (mode != 0)
		{
			return;
		}
		checked
		{
			if (curDeckIndex - index == 1 || curDeckIndex - index == -4)
			{
				if ((bool)_0024UpdateDeckPanel_0024locals_0024._0024lastBoxDeckPanel)
				{
					TweenPosition tweenPosition = TweenPosition.Begin(_0024UpdateDeckPanel_0024locals_0024._0024lastBoxDeckPanel.gameObject, 0.2f, new Vector3(-2000f, 0f, 0f));
					tweenPosition.onFinished = new _0024UpdateDeckPanel_0024closure_00243270(_0024UpdateDeckPanel_0024locals_0024).Invoke;
				}
				if ((bool)boxDeckPanel)
				{
					TweenPosition tweenPosition = TweenPosition.Begin(boxDeckPanel.gameObject, 0.2f, new Vector3(0f, 0f, 0f));
					if (swipePanel.LastDragX == 0f)
					{
						tweenPosition.From = new Vector3(2000f, 0f, 0f);
					}
					boxDeckPanel.gameObject.SetActive(value: true);
				}
			}
			else if (curDeckIndex - index == -1 || curDeckIndex - index == 4)
			{
				if ((bool)_0024UpdateDeckPanel_0024locals_0024._0024lastBoxDeckPanel)
				{
					TweenPosition tweenPosition = TweenPosition.Begin(_0024UpdateDeckPanel_0024locals_0024._0024lastBoxDeckPanel.gameObject, 0.2f, new Vector3(2000f, 0f, 0f));
					tweenPosition.onFinished = new _0024UpdateDeckPanel_0024closure_00243271(_0024UpdateDeckPanel_0024locals_0024).Invoke;
				}
				if ((bool)boxDeckPanel)
				{
					TweenPosition tweenPosition = TweenPosition.Begin(boxDeckPanel.gameObject, 0.2f, new Vector3(0f, 0f, 0f));
					tweenPosition.From = new Vector3(-2000f, 0f, 0f);
					boxDeckPanel.gameObject.SetActive(value: true);
				}
			}
		}
	}

	public void RestoreCurDeck()
	{
		InitTmpEquipments();
		WeaponInitialize();
		MuppetInitialize();
	}

	private void WeaponInitialize()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		curWeaponBoxId = BoxId.InvalidId;
		curSubWeapon1BoxId = BoxId.InvalidId;
		curSubWeapon2BoxId = BoxId.InvalidId;
		if (current.IsValidDeck2)
		{
			WeaponEquipments[] array = wepEquips;
			WeaponEquipments weaponEquipments = array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)];
			if (weaponEquipments != null)
			{
				tmpWepEq = weaponEquipments;
				RespWeapon mainWeapon = weaponEquipments.getMainWeapon(RACE_TYPE.Tensi);
				RespWeapon mainWeapon2 = weaponEquipments.getMainWeapon(RACE_TYPE.Akuma);
				if (mainWeapon != null)
				{
					curWeaponBoxId = mainWeapon.Id;
				}
				if (mainWeapon2 != null)
				{
					curSubWeapon1BoxId = mainWeapon2.Id;
				}
			}
		}
		else
		{
			if (current.MainWeapon != null)
			{
				curWeaponBoxId = current.MainWeapon.Id;
			}
			if (current.SubWeapon1 != null)
			{
				curSubWeapon1BoxId = current.SubWeapon1.Id;
			}
			if (current.SubWeapon2 != null)
			{
				curSubWeapon2BoxId = current.SubWeapon2.Id;
			}
		}
		lastWeaponBoxId = curWeaponBoxId;
		lastSubWeapon1BoxId = curSubWeapon1BoxId;
		lastSubWeapon2BoxId = curSubWeapon2BoxId;
		listWeaponInfo = current.BoxWeapons;
		weaponList.HookAutoFocusItem = hookAutoFocusWeaponItem;
		weaponList.HookSettingListItem = hookSettingWeaponListItem;
		weaponList.DelegateDecide = delegate
		{
			PushDecide(null);
		};
		weaponList.SetInputWeaponList(listWeaponInfo);
		if (!weaponList.sortButton)
		{
			return;
		}
		weaponList.sortButton.CheckCloseFunc = delegate
		{
			bool num = mode == MY_HOME_EQUIP_MAIN.WeaponList;
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.SupportWeaponList;
			}
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.PoppetList;
			}
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.SupportPoppetList;
			}
			return !num;
		};
	}

	private RespWeapon[] GetEquipWeapons()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		RespWeapon[] array = null;
		if (!current.IsValidDeck2)
		{
			array = new RespWeapon[3];
			int i = 0;
			RespWeapon[] array2 = listWeaponInfo;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(array2[i].Id, curWeaponBoxId))
				{
					array[0] = array2[i];
				}
				if (RuntimeServices.EqualityOperator(array2[i].Id, curSubWeapon1BoxId))
				{
					array[1] = array2[i];
				}
				if (RuntimeServices.EqualityOperator(array2[i].Id, curSubWeapon2BoxId))
				{
					array[2] = array2[i];
				}
			}
		}
		return array;
	}

	private RespPoppet GetEquipPet()
	{
		if (listMuppetInfo == null)
		{
			listMuppetInfo = UserData.Current.BoxPoppets;
		}
		int num = 0;
		RespPoppet[] array = listMuppetInfo;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (RuntimeServices.EqualityOperator(array[num].Id, curMainMuppetBoxId))
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (RespPoppet)result;
	}

	private void SetSupportInfo(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		SetWeaponInfo(wepEq, petEq);
		SetMuppetInfo(wepEq, petEq);
		SetTotalInfo(wepEq, petEq);
	}

	private void SetWeaponInfo(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (!current.IsValidDeck2)
		{
			RespWeapon[] equipWeapons = GetEquipWeapons();
			int i = 0;
			RespWeapon[] array = listWeaponInfo;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(array[i].Id, curWeaponBoxId))
				{
					if ((bool)mainWeaponInfo)
					{
						mainWeaponInfo.SetWeapon(array[i]);
					}
					equipWeapons[0] = array[i];
				}
				if (RuntimeServices.EqualityOperator(array[i].Id, curSubWeapon1BoxId))
				{
					if ((bool)sub1WeaponInfo)
					{
						sub1WeaponInfo.SetWeapon(array[i]);
					}
					equipWeapons[1] = array[i];
				}
				if (RuntimeServices.EqualityOperator(array[i].Id, curSubWeapon2BoxId))
				{
					if ((bool)sub2WeaponInfo)
					{
						sub2WeaponInfo.SetWeapon(array[i]);
					}
					equipWeapons[2] = array[i];
				}
			}
			mainWeaponInfo.SetTotalWeaponStatus(equipWeapons);
			RespWeapon respWeapon = equipWeapons[0];
			int num = 0;
			int num2 = 2 + 1;
			int num3 = 1;
			if (num2 < num)
			{
				num3 = -1;
			}
			while (num != num2)
			{
				int num4 = num;
				num += num3;
				RespWeapon respWeapon2 = equipWeapons[RuntimeServices.NormalizeArrayIndex(equipWeapons, num4)];
				float num5;
				float num6;
				if (num4 == 0)
				{
					num5 = respWeapon.TotalAttack;
					num6 = respWeapon.TotalHP;
				}
				else
				{
					num5 = DamageCalc.SupportWeaponAttackRevise(equipWeapons[RuntimeServices.NormalizeArrayIndex(equipWeapons, num4)], respWeapon);
					num6 = DamageCalc.SupportWeaponHpRevise(equipWeapons[RuntimeServices.NormalizeArrayIndex(equipWeapons, num4)], respWeapon);
				}
				SupportSet[] array2 = supSets;
				_ = checked(array2[RuntimeServices.NormalizeArrayIndex(array2, num4)]?.ShowData((int)num5, (int)num6, respWeapon2.Element.Id, respWeapon2.Element.Id == respWeapon.Element.Id, respWeapon2.Style.Id, respWeapon2.Style.Id == respWeapon.Style.Id));
			}
		}
		else
		{
			if ((bool)mainWeaponInfo)
			{
				mainWeaponInfo.SetWeapon(wepEq.MainTenshiWeapon);
			}
			if ((bool)mainWeaponInfo)
			{
				sub1WeaponInfo.SetWeapon(wepEq.MainAkumaWeapon);
			}
		}
	}

	private void SetMuppetInfo(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		checked
		{
			RespPoppet equipPet;
			if (!current.IsValidDeck2)
			{
				equipPet = GetEquipPet();
				if (equipPet != null)
				{
					muppetInfo.SetMuppet(equipPet);
					RespWeapon[] equipWeapons = GetEquipWeapons();
					RespWeapon respWeapon = equipWeapons[0];
					float num = DamageCalc.PoppetAttackRevice(equipPet, respWeapon);
					float num2 = DamageCalc.PoppetHpRevice(equipPet, respWeapon);
					SupportSet[] array = supSets;
					array[RuntimeServices.NormalizeArrayIndex(array, 3)]?.ShowData((int)num, (int)num2, equipPet.Element.Id, equipPet.Element.Id == respWeapon.Element.Id, -1, styleLight: false);
				}
				return;
			}
			equipPet = petEq.MainPoppet;
			if (equipPet != null)
			{
				if ((bool)muppetInfo)
				{
					muppetInfo.SetMuppet(equipPet);
				}
				float num = DamageCalc.PoppetAttackRevice(wepEq, equipPet);
				float num2 = DamageCalc.PoppetHpRevice(wepEq, equipPet);
				SupportSet[] array2 = supSets;
				array2[RuntimeServices.NormalizeArrayIndex(array2, 3)]?.ShowData((int)num, (int)num2, equipPet.Element.Id, elemLight: false, -1, styleLight: false);
			}
		}
	}

	private void SetTotalInfo(WeaponEquipments wepEq, PoppetEquipments petEq)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		int num = default(int);
		int num2 = default(int);
		checked
		{
			if (!current.IsValidDeck2)
			{
				RespWeapon[] equipWeapons = GetEquipWeapons();
				RespPoppet equipPet = GetEquipPet();
				if (equipWeapons != null && equipPet != null)
				{
					num = (int)DamageCalc.TotalPlayerAttack(equipWeapons, new RespPoppet[1] { equipPet });
					num2 = (int)DamageCalc.TotalPlayerHP(equipWeapons, new RespPoppet[1] { equipPet });
					UIBasicUtility.SetLabel(playerAtkLabel, num.ToString("#,0"), show: true);
					UIBasicUtility.SetLabel(playerHpLabel, num2.ToString("#,0"), show: true);
				}
			}
			else
			{
				RespPoppet mainPoppet = default(RespPoppet);
				if (petEq != null)
				{
					mainPoppet = petEq.MainPoppet;
				}
				num = (int)DamageCalc.TotalPlayerAttack(wepEq, new RespPoppet[1] { mainPoppet });
				num2 = (int)DamageCalc.TotalPlayerHP(wepEq, new RespPoppet[1] { mainPoppet });
				UIBasicUtility.SetLabel(playerAtkLabel, num.ToString("#,0"), show: true);
				UIBasicUtility.SetLabel(playerHpLabel, num2.ToString("#,0"), show: true);
			}
		}
	}

	private bool hookAutoFocusWeaponItem(ref UIListItem.Data dstData)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		dstData = null;
		BoxId invalidId = BoxId.InvalidId;
		if (!current.IsValidDeck2 && current.MainWeapon != null)
		{
			invalidId = current.MainWeapon.Id;
		}
		int result;
		if (startMode == MY_HOME_EQUIP_START_MODE.MainWeaponList)
		{
			invalidId = curWeaponBoxId;
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Sub1WeaponList)
		{
			invalidId = curSubWeapon1BoxId;
		}
		else
		{
			if (startMode != MY_HOME_EQUIP_START_MODE.Sub2WeaponList)
			{
				result = 0;
				goto IL_00eb;
			}
			invalidId = curSubWeapon2BoxId;
		}
		int i = 0;
		UIListItem.Data[] dataList = weaponList.GetDataList();
		for (int length = dataList.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeServices.EqualityOperator(invalidId, dataList[i].GetData<RespWeapon>().Id))
			{
				dstData = dataList[i];
				break;
			}
		}
		result = 1;
		goto IL_00eb;
		IL_00eb:
		return (byte)result != 0;
	}

	private bool hookSettingWeaponListItem(UIListItem item)
	{
		int result;
		if (!item)
		{
			result = 1;
		}
		else
		{
			RespWeapon data = item.GetData<RespWeapon>();
			if (data != null)
			{
				string value = (item.UsingText = UseText(data.Id));
				item.Using = !string.IsNullOrEmpty(value);
				item.Disable = false;
				weaponList.weponHookSettingListItem(item);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private void MuppetInitialize()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		curMainMuppetBoxId = BoxId.InvalidId;
		if (current.IsValidDeck2)
		{
			PoppetEquipments[] array = petEquips;
			PoppetEquipments poppetEquipments = array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)];
			if (poppetEquipments != null)
			{
				if (poppetEquipments.MainPoppet != null)
				{
					curMainMuppetBoxId = poppetEquipments.MainPoppet.Id;
				}
				tmpPetEq = poppetEquipments;
			}
		}
		else if (current.CurrentPoppetNewOrOldDeck != null)
		{
			curMainMuppetBoxId = current.CurrentPoppetNewOrOldDeck.Id;
		}
		lastMainMuppetBoxId = curMainMuppetBoxId;
		listMuppetInfo = current.BoxPoppets;
		mapetList.HookAutoFocusItem = hookAutoFocusPetItem;
		mapetList.HookSettingListItem = hookSettingPetListItem;
		mapetList.DelegateDecide = delegate
		{
			PushDecide(null);
		};
		mapetList.SetInputMapetList(listMuppetInfo);
		if (!mapetList.sortButton)
		{
			return;
		}
		mapetList.sortButton.CheckCloseFunc = delegate
		{
			bool num = mode == MY_HOME_EQUIP_MAIN.WeaponList;
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.SupportWeaponList;
			}
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.PoppetList;
			}
			if (!num)
			{
				num = mode == MY_HOME_EQUIP_MAIN.SupportPoppetList;
			}
			return !num;
		};
	}

	private bool hookAutoFocusPetItem(ref UIListItem.Data dstData)
	{
		int result;
		if (startMode != MY_HOME_EQUIP_START_MODE.PoppetList)
		{
			result = 0;
		}
		else
		{
			UserData current = UserData.Current;
			dstData = null;
			int i = 0;
			UIListItem.Data[] dataList = mapetList.GetDataList();
			for (int length = dataList.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeServices.EqualityOperator(curMainMuppetBoxId, dataList[i].GetData<RespPoppet>().Id))
				{
					dstData = dataList[i];
					break;
				}
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private bool hookSettingPetListItem(UIListItem item)
	{
		int result;
		if (!item)
		{
			result = 1;
		}
		else
		{
			RespPoppet data = item.GetData<RespPoppet>();
			if (data != null)
			{
				string value = (item.UsingText = UseText(data.Id));
				item.Using = !string.IsNullOrEmpty(value);
				item.Disable = false;
				mapetList.poppetHookSettingListItem(item);
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public void PushBack()
	{
		if (showWeaponDetail)
		{
			showWeaponDetail = false;
			UIAutoTweenerStandAloneEx.Out(detailInfo.gameObject);
		}
		else if (showMuppetDetail)
		{
			showMuppetDetail = false;
			UIAutoTweenerStandAloneEx.Out(muppetDetailInfo.gameObject);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.Equip)
		{
			if (!swipePanel.IsDrag)
			{
				if ((bool)supportButtonDialog && supportButtonDialog.active)
				{
					UIAutoTweenerStandAloneEx.Out(supportButtonDialog);
				}
				else
				{
					CallBackSetCurWep();
				}
			}
		}
		else if (mode == MY_HOME_EQUIP_MAIN.WeaponList)
		{
			if (startMode != 0)
			{
				CallBackSetCurWep();
			}
			else
			{
				mode = MY_HOME_EQUIP_MAIN.Equip;
			}
		}
		else if (mode == MY_HOME_EQUIP_MAIN.PoppetList)
		{
			if (startMode != 0)
			{
				CallBackSetCurWep();
			}
			else
			{
				mode = MY_HOME_EQUIP_MAIN.Equip;
			}
		}
		else if (mode == MY_HOME_EQUIP_MAIN.Support)
		{
			PushDecide(null);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.SupportWeaponList || mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
		{
			mode = MY_HOME_EQUIP_MAIN.Support;
		}
	}

	public void PushDecide(GameObject obj)
	{
		if (mode == MY_HOME_EQUIP_MAIN.Equip)
		{
			return;
		}
		if (mode == MY_HOME_EQUIP_MAIN.WeaponList)
		{
			InitBoxDeckPanel();
			WeaponDecide();
			UpdateDeck(curDeckIndex);
			if (startMode != 0)
			{
				CallBackSetCurWep();
			}
			else
			{
				mode = MY_HOME_EQUIP_MAIN.Equip;
			}
			SetSupportInfo(tmpWepEq, tmpPetEq);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.PoppetList)
		{
			InitBoxDeckPanel();
			MuppetDecide();
			UpdateDeck(curDeckIndex);
			if (startMode != 0)
			{
				CallBackSetCurWep();
			}
			else
			{
				mode = MY_HOME_EQUIP_MAIN.Equip;
			}
			SetSupportInfo(tmpWepEq, tmpPetEq);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.Support)
		{
			PushSupportDecide(obj);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
		{
			PushSupportDecide(obj);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
		{
			PushSupportDecide(obj);
		}
	}

	public void PushSupportDecide(GameObject obj)
	{
		if (mode == MY_HOME_EQUIP_MAIN.Support)
		{
			if (startMode != 0)
			{
				CallBackSetCurWep();
			}
			else
			{
				mode = MY_HOME_EQUIP_MAIN.Equip;
			}
			InitBoxDeckPanel();
			UpdateDeckType(supprtEquipInfo.DeckType, update: false);
			UpdateDeck(curDeckIndex);
			RestoreCurDeck();
			SetSupportInfo(tmpWepEq, tmpPetEq);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
		{
			UserConfigData.DeckTypes[] array = deckTypes;
			array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)] = UserConfigData.DeckTypes.Custom;
			WeaponDecide();
			SupportEquipInfo supportEquipInfo = supprtEquipInfo;
			int deckIndex = curDeckIndex;
			UserConfigData.DeckTypes[] array2 = deckTypes;
			supportEquipInfo.Init(deckIndex, array2[RuntimeServices.NormalizeArrayIndex(array2, curDeckIndex)], tmpWepEq, tmpPetEq);
			WeaponInitialize();
			mode = MY_HOME_EQUIP_MAIN.Support;
		}
		else if (mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
		{
			UserConfigData.DeckTypes[] array3 = deckTypes;
			array3[RuntimeServices.NormalizeArrayIndex(array3, curDeckIndex)] = UserConfigData.DeckTypes.Custom;
			MuppetDecide();
			SupportEquipInfo supportEquipInfo2 = supprtEquipInfo;
			int deckIndex2 = curDeckIndex;
			UserConfigData.DeckTypes[] array4 = deckTypes;
			supportEquipInfo2.Init(deckIndex2, array4[RuntimeServices.NormalizeArrayIndex(array4, curDeckIndex)], tmpWepEq, tmpPetEq);
			MuppetInitialize();
			mode = MY_HOME_EQUIP_MAIN.Support;
		}
		SetSupportInfo(tmpWepEq, tmpPetEq);
	}

	private void WeaponDecide()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		UIListItem.Data focusItem = weaponList.focusItem;
		if (focusItem == null)
		{
			return;
		}
		RespWeapon data = focusItem.GetData<RespWeapon>();
		if (data != null)
		{
			lastWeaponInfo = data;
			if (current.IsValidDeck2)
			{
				SetWeaponIdDeck2(ref tmpWepEq, data.Id);
			}
			else if (selectType == 0 || selectType == 3)
			{
				SetWeaponId(ref curWeaponBoxId, data.Id);
			}
			else if (selectType == 1 || selectType == 8)
			{
				SetWeaponId(ref curSubWeapon1BoxId, data.Id);
			}
			else
			{
				SetWeaponId(ref curSubWeapon2BoxId, data.Id);
			}
		}
	}

	private void SetWeaponId(ref BoxId target, BoxId select)
	{
		BoxId boxId = target;
		if (RuntimeServices.EqualityOperator(select, curWeaponBoxId))
		{
			curWeaponBoxId = target;
		}
		else if (RuntimeServices.EqualityOperator(select, curSubWeapon1BoxId))
		{
			curSubWeapon1BoxId = target;
		}
		else if (RuntimeServices.EqualityOperator(select, curSubWeapon2BoxId))
		{
			curSubWeapon2BoxId = target;
		}
		target = select;
		weaponList.ResetListItem(boxId.Value);
		weaponList.ResetListItem(target.Value);
	}

	private void SetWeaponIdDeck2(ref WeaponEquipments wepEq, BoxId select)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		RespWeapon respWeapon = default(RespWeapon);
		if (selectType == 0 || selectType == 3)
		{
			respWeapon = wepEq.MainTenshiWeapon;
		}
		else if (selectType == 4)
		{
			respWeapon = wepEq.SubTenshiWeapons[0];
		}
		else if (selectType == 5)
		{
			respWeapon = wepEq.SubTenshiWeapons[1];
		}
		else if (selectType == 6)
		{
			respWeapon = wepEq.SubTenshiWeapons[2];
		}
		else if (selectType == 1 || selectType == 8)
		{
			respWeapon = wepEq.MainAkumaWeapon;
		}
		else if (selectType == 9)
		{
			respWeapon = wepEq.SubAkumaWeapons[0];
		}
		else if (selectType == 10)
		{
			respWeapon = wepEq.SubAkumaWeapons[1];
		}
		else if (selectType == 11)
		{
			respWeapon = wepEq.SubAkumaWeapons[2];
		}
		RespWeapon respWeapon2 = respWeapon;
		if (RuntimeServices.EqualityOperator(select, wepEq.MainTenshiWeapon.Id))
		{
			wepEq.MainTenshiWeapon = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubTenshiWeapons[0].Id))
		{
			wepEq.SubTenshiWeapons[0] = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubTenshiWeapons[1].Id))
		{
			wepEq.SubTenshiWeapons[1] = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubTenshiWeapons[2].Id))
		{
			wepEq.SubTenshiWeapons[2] = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.MainAkumaWeapon.Id))
		{
			wepEq.MainAkumaWeapon = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubAkumaWeapons[0].Id))
		{
			wepEq.SubAkumaWeapons[0] = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubAkumaWeapons[1].Id))
		{
			wepEq.SubAkumaWeapons[1] = respWeapon;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubAkumaWeapons[2].Id))
		{
			wepEq.SubAkumaWeapons[2] = respWeapon;
		}
		respWeapon = current.boxWeapon(select);
		if (selectType == 0 || selectType == 3)
		{
			wepEq.MainTenshiWeapon = respWeapon;
		}
		else if (selectType == 4)
		{
			wepEq.SubTenshiWeapons[0] = respWeapon;
		}
		else if (selectType == 5)
		{
			wepEq.SubTenshiWeapons[1] = respWeapon;
		}
		else if (selectType == 6)
		{
			wepEq.SubTenshiWeapons[2] = respWeapon;
		}
		else if (selectType == 1 || selectType == 8)
		{
			wepEq.MainAkumaWeapon = respWeapon;
		}
		else if (selectType == 9)
		{
			wepEq.SubAkumaWeapons[0] = respWeapon;
		}
		else if (selectType == 10)
		{
			wepEq.SubAkumaWeapons[1] = respWeapon;
		}
		else if (selectType == 11)
		{
			wepEq.SubAkumaWeapons[2] = respWeapon;
		}
		weaponList.ResetListItem(respWeapon2.Id.Value);
		weaponList.ResetListItem(respWeapon.Id.Value);
	}

	private string UseText(BoxId id)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		object result;
		if (!current.IsValidDeck2)
		{
			result = (RuntimeServices.EqualityOperator(id, curWeaponBoxId) ? "装備中" : (RuntimeServices.EqualityOperator(id, curSubWeapon1BoxId) ? "サポート1" : (RuntimeServices.EqualityOperator(id, curSubWeapon2BoxId) ? "サポート2" : ((!RuntimeServices.EqualityOperator(id, curMainMuppetBoxId)) ? string.Empty : "使用中"))));
		}
		else
		{
			bool ignoreSupport = false;
			result = UIBasicUtility.GetMainSupportString(tmpWepEq, tmpPetEq, id, equipOnly: false, ignoreSupport, ignoreRace: true);
		}
		return (string)result;
	}

	private void MuppetDecide()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		UIListItem.Data focusItem = mapetList.focusItem;
		if (focusItem == null)
		{
			return;
		}
		RespPoppet data = focusItem.GetData<RespPoppet>();
		if (data != null)
		{
			if (current.IsValidDeck2)
			{
				SetPoppetIdDeck2(ref tmpWepEq, ref tmpPetEq, data.Id);
			}
			else if (!RuntimeServices.EqualityOperator(data.Id, curMainMuppetBoxId))
			{
				RespPoppet respPoppet = data;
				BoxId boxId = curMainMuppetBoxId;
				curMainMuppetBoxId = data.Id;
				mapetList.ResetListItem(boxId.Value);
				mapetList.ResetListItem(data.Id.Value);
			}
		}
	}

	private BoxId SetPoppetIdDeck2(ref WeaponEquipments wepEq, ref PoppetEquipments petEq, BoxId select)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		RespPoppet respPoppet = ((selectType == 13) ? petEq.MainPoppet : ((selectType == 7) ? wepEq.SubTenshiPoppets[0] : ((selectType != 12) ? petEq.MainPoppet : wepEq.SubAkumaPoppets[0])));
		RespPoppet respPoppet2 = respPoppet;
		if (RuntimeServices.EqualityOperator(select, petEq.MainPoppet.Id))
		{
			petEq.MainPoppet = respPoppet;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubTenshiPoppets[0].Id))
		{
			wepEq.SubTenshiPoppets[0] = respPoppet;
		}
		else if (RuntimeServices.EqualityOperator(select, wepEq.SubAkumaPoppets[0].Id))
		{
			wepEq.SubAkumaPoppets[0] = respPoppet;
		}
		respPoppet = current.boxPoppet(select);
		if (selectType == 13)
		{
			petEq.MainPoppet = respPoppet;
		}
		else if (selectType == 7)
		{
			wepEq.SubTenshiPoppets[0] = respPoppet;
		}
		else if (selectType == 12)
		{
			wepEq.SubAkumaPoppets[0] = respPoppet;
		}
		else
		{
			petEq.MainPoppet = respPoppet;
		}
		mapetList.ResetListItem(respPoppet2.Id.Value);
		mapetList.ResetListItem(respPoppet.Id.Value);
		return respPoppet.Id;
	}

	public void PushEnd(GameObject obj)
	{
	}

	private void CallBackSetCurWep()
	{
		BackMyhome();
	}

	private void InitSendHook()
	{
		SceneChanger.Hook = SendEquip;
		sendEquipFlag = false;
		sendError = false;
		sendResult = false;
	}

	public bool SendEquip(SceneID sceneId, string sceneName)
	{
		int result;
		if (delaySendEquipments)
		{
			delaySendEquipments = false;
			InitSendHook();
			result = 0;
		}
		else
		{
			if (!sendEquipFlag)
			{
				UpdateDeck(curDeckIndex);
				sendError = false;
				sendResult = false;
				sendEquipFlag = true;
				UserData current = UserData.Current;
				if (current == null)
				{
					throw new AssertionFailedException("ud");
				}
				int num = 0;
				int num2 = 5;
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int index = num;
					num++;
					UserConfigData.DeckTypes[] array = current.userDeckData2.DeckTypes;
					int num3 = RuntimeServices.NormalizeArrayIndex(array, index);
					UserConfigData.DeckTypes[] array2 = deckTypes;
					array[num3] = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				}
				if (current.IsValidDeck2)
				{
					IEnumerator enumerator = SendDeck2EquipCore(sceneName);
					if (enumerator != null)
					{
						StartCoroutine(enumerator);
					}
				}
				else
				{
					IEnumerator enumerator2 = SendOldEquipCore(sceneName);
					if (enumerator2 != null)
					{
						StartCoroutine(enumerator2);
					}
				}
			}
			result = (sendResult ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public IEnumerator SendOldEquipCore(string str)
	{
		return new _0024SendOldEquipCore_002421720(this).GetEnumerator();
	}

	public IEnumerator SendDeck2EquipCore(string str)
	{
		return new _0024SendDeck2EquipCore_002421732(this).GetEnumerator();
	}

	private void ShowList(BoxId id, Select sel)
	{
		if (!swipePanel.IsDrag)
		{
			mode = MY_HOME_EQUIP_MAIN.WeaponList;
			InitBoxDeckPanel();
			weaponList.SelectItemById(id.Value, canDecide: false);
			selectType = (int)sel;
		}
	}

	private void ShowListMainWeapon(GameObject obj)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (current.IsValidDeck2)
		{
			InitTmpEquipments();
			ShowList(tmpWepEq.MainTenshiWeapon.Id, Select.Main);
		}
		else
		{
			ShowList(curWeaponBoxId, Select.Main);
		}
	}

	private void ShowListSub1Weapon(GameObject obj)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (current.IsValidDeck2)
		{
			InitTmpEquipments();
			ShowList(tmpWepEq.MainAkumaWeapon.Id, Select.Sub1);
		}
		else
		{
			ShowList(curSubWeapon1BoxId, Select.Sub1);
		}
	}

	private void ShowListSub2Weapon(GameObject obj)
	{
		ShowList(curSubWeapon2BoxId, Select.Sub2);
	}

	private void ShowListMainMuppet(GameObject obj)
	{
		if (!swipePanel.IsDrag)
		{
			UserData current = UserData.Current;
			if (current == null)
			{
				throw new AssertionFailedException("ud");
			}
			mode = MY_HOME_EQUIP_MAIN.PoppetList;
			if (current.IsValidDeck2)
			{
				InitTmpEquipments();
				mapetList.SelectItemById(tmpPetEq.MainPoppet.Id.Value, canDecide: false);
			}
			else
			{
				mapetList.SelectItemById(curMainMuppetBoxId.Value, canDecide: false);
			}
		}
	}

	private void ShowSupportList(BoxId id, Select sel)
	{
		selectType = (int)sel;
		if (sel == Select.PetAngel || sel == Select.PetDevil || sel == Select.Pet)
		{
			mode = MY_HOME_EQUIP_MAIN.SupportPoppetList;
			MuppetInitialize();
			mapetList.SelectItemById(id.Value, canDecide: false);
		}
		else
		{
			mode = MY_HOME_EQUIP_MAIN.SupportWeaponList;
			WeaponInitialize();
			weaponList.SelectItemById(id.Value, canDecide: false);
		}
	}

	public void PushDetail(GameObject obj)
	{
		if (mode == MY_HOME_EQUIP_MAIN.WeaponList || mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
		{
			WeaponDetail();
		}
		else if (mode == MY_HOME_EQUIP_MAIN.PoppetList || mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
		{
			MuppetDetail();
		}
	}

	public void WeaponDetail()
	{
		if (!detailInfo)
		{
			throw new AssertionFailedException("detailInfo");
		}
		RespWeapon focusData = weaponList.GetFocusData<RespWeapon>();
		detailInfo.SetWeapon(focusData);
		UIAutoTweenerStandAloneEx.In(detailInfo.gameObject);
		showWeaponDetail = true;
	}

	public void MuppetDetail()
	{
		if (!muppetDetailInfo)
		{
			throw new AssertionFailedException("muppetDetailInfo");
		}
		RespPoppet focusData = mapetList.GetFocusData<RespPoppet>();
		muppetDetailInfo.SetMuppet(focusData);
		UIAutoTweenerStandAloneEx.In(muppetDetailInfo.gameObject);
		showMuppetDetail = true;
	}

	public void PushSort(string key)
	{
		if (mode == MY_HOME_EQUIP_MAIN.WeaponList || mode == MY_HOME_EQUIP_MAIN.SupportWeaponList)
		{
			weaponList.PushSort(key);
		}
		else if (mode == MY_HOME_EQUIP_MAIN.PoppetList || mode == MY_HOME_EQUIP_MAIN.SupportPoppetList)
		{
			mapetList.PushSort(key);
		}
	}

	public void PushInfoWindow(GameObject obj)
	{
		showSupport = !showSupport;
		ShowSupport(showSupport);
	}

	private void ShowSupport(bool show)
	{
		if ((bool)skillWindow && (bool)supportWindow)
		{
			Vector3 zero = Vector3.zero;
			Vector3 vector = new Vector3(-2000f, 0f, 0f);
			skillWindow.transform.localPosition = (show ? vector : zero);
			supportWindow.transform.localPosition = ((!show) ? vector : zero);
		}
	}

	public void MessageFromSuppotEquip(string button)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (current.IsValidDeck2)
		{
			switch (button)
			{
			case "AngelMain":
				ShowSupportList(tmpWepEq.MainTenshiWeapon.Id, Select.MainAngel);
				break;
			case "AngelSub1":
				ShowSupportList(tmpWepEq.SubTenshiWeapons[0].Id, Select.SubAngel1);
				break;
			case "AngelSub2":
				ShowSupportList(tmpWepEq.SubTenshiWeapons[1].Id, Select.SubAngel2);
				break;
			case "AngelSub3":
				ShowSupportList(tmpWepEq.SubTenshiWeapons[2].Id, Select.SubAngel3);
				break;
			case "AngelPet":
				ShowSupportList(tmpWepEq.SubTenshiPoppets[0].Id, Select.PetAngel);
				break;
			case "DevilMain":
				ShowSupportList(tmpWepEq.MainAkumaWeapon.Id, Select.MainDevil);
				break;
			case "DevilSub1":
				ShowSupportList(tmpWepEq.SubAkumaWeapons[0].Id, Select.SubDevil1);
				break;
			case "DevilSub2":
				ShowSupportList(tmpWepEq.SubAkumaWeapons[1].Id, Select.SubDevil2);
				break;
			case "DevilSub3":
				ShowSupportList(tmpWepEq.SubAkumaWeapons[2].Id, Select.SubDevil3);
				break;
			case "DevilPet":
				ShowSupportList(tmpWepEq.SubAkumaPoppets[0].Id, Select.PetDevil);
				break;
			case "PetMain":
				ShowSupportList(tmpPetEq.MainPoppet.Id, Select.Pet);
				break;
			case "Decide":
				PushSupportDecide(null);
				break;
			case "AtkMax":
			{
				WeaponEquipments bestHpWeapons = WeaponEquipments.GetBestAtkWeapons(tmpWepEq, tmpPetEq);
				bestHpWeapons.Copy(ref tmpWepEq);
				UpdateDeckType(UserConfigData.DeckTypes.Atk, update: false);
				SupportEquipInfo supportEquipInfo2 = supprtEquipInfo;
				int deckIndex2 = curDeckIndex;
				UserConfigData.DeckTypes[] array2 = deckTypes;
				supportEquipInfo2.Init(deckIndex2, array2[RuntimeServices.NormalizeArrayIndex(array2, curDeckIndex)], tmpWepEq, tmpPetEq);
				break;
			}
			case "HpMax":
			{
				WeaponEquipments bestHpWeapons = WeaponEquipments.GetBestHpWeapons(tmpWepEq, tmpPetEq);
				bestHpWeapons.Copy(ref tmpWepEq);
				UpdateDeckType(UserConfigData.DeckTypes.Hp, update: false);
				SupportEquipInfo supportEquipInfo = supprtEquipInfo;
				int deckIndex = curDeckIndex;
				UserConfigData.DeckTypes[] array = deckTypes;
				supportEquipInfo.Init(deckIndex, array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)], tmpWepEq, tmpPetEq);
				break;
			}
			default:
				throw new MatchError(new StringBuilder("`button` failed to match `").Append(button).Append("`").ToString());
			}
		}
		else
		{
			switch (button)
			{
			case "AngelMain":
				ShowListMainWeapon(null);
				break;
			case "AngelSub1":
				ShowListSub2Weapon(null);
				break;
			case "AngelSub2":
				ShowListSub2Weapon(null);
				break;
			case "AngelSub3":
				ShowListSub2Weapon(null);
				break;
			case "AngelPet":
				ShowListMainMuppet(null);
				break;
			case "DevilMain":
				ShowListSub1Weapon(null);
				break;
			case "DevilSub1":
				ShowListSub2Weapon(null);
				break;
			case "DevilSub2":
				ShowListSub2Weapon(null);
				break;
			case "DevilSub3":
				ShowListSub2Weapon(null);
				break;
			case "DevilPet":
				ShowListMainMuppet(null);
				break;
			case "PetMain":
				ShowListMainMuppet(null);
				break;
			case "Decide":
				PushDecide(null);
				break;
			default:
				throw new MatchError(new StringBuilder("`button` failed to match `").Append(button).Append("`").ToString());
			}
		}
	}

	public void UpdateDeckType(UserConfigData.DeckTypes type, bool update)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		UserConfigData.DeckTypes[] array = deckTypes;
		array[RuntimeServices.NormalizeArrayIndex(array, curDeckIndex)] = type;
		if (supportButtonPanel != null)
		{
			supportButtonPanel.SwitchButton((int)type);
		}
		if (update && current.IsValidDeck2)
		{
			switch (type)
			{
			case UserConfigData.DeckTypes.Atk:
			{
				WeaponEquipments bestHpWeapons = WeaponEquipments.GetBestAtkWeapons(tmpWepEq, tmpPetEq);
				bestHpWeapons.Copy(ref tmpWepEq);
				break;
			}
			case UserConfigData.DeckTypes.Hp:
			{
				WeaponEquipments bestHpWeapons = WeaponEquipments.GetBestHpWeapons(tmpWepEq, tmpPetEq);
				bestHpWeapons.Copy(ref tmpWepEq);
				break;
			}
			}
			UpdateDeck(curDeckIndex);
			RestoreCurDeck();
			SetSupportInfo(tmpWepEq, tmpPetEq);
		}
	}

	public void PushSetupSuppotEquip(GameObject obj)
	{
		if (!swipePanel.IsDrag && mode == MY_HOME_EQUIP_MAIN.Equip && (bool)supportButtonDialog)
		{
			UIAutoTweenerStandAloneEx.In(supportButtonDialog);
		}
	}

	public void PushAtkSupport(GameObject obj)
	{
		if (!swipePanel.IsDrag && (mode == MY_HOME_EQUIP_MAIN.Equip || mode == MY_HOME_EQUIP_MAIN.Support))
		{
			if ((bool)supportButtonDialog)
			{
				UIAutoTweenerStandAloneEx.Out(supportButtonDialog);
			}
			UpdateDeckType(UserConfigData.DeckTypes.Atk, update: true);
		}
	}

	public void PushHpSupport(GameObject obj)
	{
		if (!swipePanel.IsDrag && (mode == MY_HOME_EQUIP_MAIN.Equip || mode == MY_HOME_EQUIP_MAIN.Support))
		{
			if ((bool)supportButtonDialog)
			{
				UIAutoTweenerStandAloneEx.Out(supportButtonDialog);
			}
			UpdateDeckType(UserConfigData.DeckTypes.Hp, update: true);
		}
	}

	public void PushCustomSupport(GameObject obj)
	{
		if (!swipePanel.IsDrag)
		{
			if ((bool)supportButtonDialog)
			{
				UIAutoTweenerStandAloneEx.Out(supportButtonDialog);
			}
			if (!supprtEquipInfo)
			{
				throw new AssertionFailedException("supprtEquipInfo");
			}
			if (mode == MY_HOME_EQUIP_MAIN.Equip)
			{
				mode = MY_HOME_EQUIP_MAIN.Support;
			}
		}
	}

	public void PushDeckLeft(GameObject obj)
	{
		if (mode != 0 && mode != MY_HOME_EQUIP_MAIN.Support)
		{
			return;
		}
		int num = curDeckIndex;
		checked
		{
			if (!dragSpring.enabled || !swipePanel.IsDrag)
			{
				SetupDeck(curDeckIndex - 1, loop: false, updateInfo: true);
			}
			if (num == curDeckIndex || mode != MY_HOME_EQUIP_MAIN.Support || supportEquipAnims == null)
			{
				return;
			}
			int i = 0;
			UIAutoTweener[] array = supportEquipAnims;
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].PlayForceAnimation(forward: true);
				}
			}
		}
	}

	public void PushDeckRight(GameObject obj)
	{
		if (mode != 0 && mode != MY_HOME_EQUIP_MAIN.Support)
		{
			return;
		}
		int num = curDeckIndex;
		checked
		{
			if (!dragSpring.enabled || !swipePanel.IsDrag)
			{
				SetupDeck(curDeckIndex + 1, loop: false, updateInfo: true);
			}
			if (num == curDeckIndex || mode != MY_HOME_EQUIP_MAIN.Support || supportEquipAnims == null)
			{
				return;
			}
			int i = 0;
			UIAutoTweener[] array = supportEquipAnims;
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].PlayForceAnimation(forward: true);
				}
			}
		}
	}

	public void PushDeckSelect(GameObject obj)
	{
		if (mode != 0 && mode != MY_HOME_EQUIP_MAIN.Support)
		{
			return;
		}
		int num = curDeckIndex;
		checked
		{
			if (!dragSpring.enabled || !swipePanel.IsDrag)
			{
				SetupDeck(curDeckIndex + 1, loop: true, updateInfo: true);
			}
			if (num == curDeckIndex || mode != MY_HOME_EQUIP_MAIN.Support || supportEquipAnims == null)
			{
				return;
			}
			int i = 0;
			UIAutoTweener[] array = supportEquipAnims;
			for (int length = array.Length; i < length; i++)
			{
				if ((bool)array[i])
				{
					array[i].PlayForceAnimation(forward: true);
				}
			}
		}
	}

	public void InitSwipePanel()
	{
		if (!swipePanel)
		{
			return;
		}
		__SwipePanel_updatePanelFunc_0024callable102_002481_24__ panelFunc = delegate(GameObject go, int index)
		{
			BoxDeckPanel boxDeckPanel = null;
			if ((bool)go)
			{
				boxDeckPanel = go.GetComponent<BoxDeckPanel>();
			}
			if ((bool)boxDeckPanel)
			{
				if (index < 0)
				{
					index = 4;
				}
				if (index >= 5)
				{
					index = 0;
				}
				boxDeckPanel.DeckIndex = index;
				if ((bool)boxDeckPanel.mainWeaponInfo)
				{
					mainWeaponInfo = boxDeckPanel.mainWeaponInfo;
				}
				if ((bool)boxDeckPanel.sub1WeaponInfo)
				{
					sub1WeaponInfo = boxDeckPanel.sub1WeaponInfo;
				}
				if ((bool)boxDeckPanel.sub2WeaponInfo)
				{
					sub2WeaponInfo = boxDeckPanel.sub2WeaponInfo;
				}
				if ((bool)boxDeckPanel.muppetInfo)
				{
					muppetInfo = boxDeckPanel.muppetInfo;
				}
				if ((bool)boxDeckPanel.playerHpLabel)
				{
					playerHpLabel = boxDeckPanel.playerHpLabel;
				}
				if ((bool)boxDeckPanel.playerAtkLabel)
				{
					playerAtkLabel = boxDeckPanel.playerAtkLabel;
				}
				WeaponEquipments[] array = wepEquips;
				WeaponEquipments wepEq = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				PoppetEquipments[] array2 = petEquips;
				PoppetEquipments petEq = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				SetSupportInfo(wepEq, petEq);
				if ((bool)mainWeaponInfo)
				{
					mainWeaponInfo.Update();
				}
				if ((bool)sub1WeaponInfo)
				{
					sub1WeaponInfo.Update();
				}
				if ((bool)sub2WeaponInfo)
				{
					sub2WeaponInfo.Update();
				}
				if ((bool)muppetInfo)
				{
					muppetInfo.Update();
				}
			}
		};
		__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ indexFunc = delegate(int index)
		{
			SetupDeck(index, loop: true, updateInfo: false);
		};
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ endFunc = delegate
		{
			InitBoxDeckPanel();
		};
		swipePanel.Init(null, 5, panelFunc, indexFunc, endFunc);
	}

	public void UpdateSwipePanel()
	{
		if ((bool)swipePanel && mode == MY_HOME_EQUIP_MAIN.Equip)
		{
			swipePanel.SwipeCtrl(curDeckIndex, curBoxDeckPanel);
		}
	}

	internal void _0024StartInit_0024closure_00243269()
	{
		InitDeck();
		mode = MY_HOME_EQUIP_MAIN.Equip;
		lastMode = mode;
		if (startMode == MY_HOME_EQUIP_START_MODE.MainWeaponList)
		{
			mode = MY_HOME_EQUIP_MAIN.WeaponList;
			lastMode = mode;
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Sub1WeaponList)
		{
			mode = MY_HOME_EQUIP_MAIN.WeaponList;
			lastMode = mode;
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Sub2WeaponList)
		{
			mode = MY_HOME_EQUIP_MAIN.WeaponList;
			lastMode = mode;
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.PoppetList)
		{
			mode = MY_HOME_EQUIP_MAIN.PoppetList;
			lastMode = mode;
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Support)
		{
			mode = MY_HOME_EQUIP_MAIN.Support;
		}
		lastMode = mode;
		ChangeSituation(GetSituation((int)mode));
		if (startMode == MY_HOME_EQUIP_START_MODE.MainWeaponList)
		{
			lastMode = MY_HOME_EQUIP_MAIN.Max;
			ShowListMainWeapon(null);
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Sub1WeaponList)
		{
			lastMode = MY_HOME_EQUIP_MAIN.Max;
			ShowListSub1Weapon(null);
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Sub2WeaponList)
		{
			lastMode = MY_HOME_EQUIP_MAIN.Max;
			ShowListSub2Weapon(null);
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.PoppetList)
		{
			lastMode = MY_HOME_EQUIP_MAIN.Max;
			ShowListMainMuppet(null);
		}
		else if (startMode == MY_HOME_EQUIP_START_MODE.Support)
		{
			lastMode = MY_HOME_EQUIP_MAIN.Max;
			PushCustomSupport(null);
		}
		else if ((bool)weaponList)
		{
			UserData current = UserData.Current;
			if (!current.IsValidDeck2 && current.MainWeapon != null)
			{
				weaponList.SetFocusItem(current.MainWeapon.Id.Value);
			}
		}
		StorageHUD.DoUpdateNow();
	}

	internal void _0024WeaponInitialize_0024closure_00243272()
	{
		PushDecide(null);
	}

	internal bool _0024WeaponInitialize_0024closure_00243273()
	{
		bool num = mode == MY_HOME_EQUIP_MAIN.WeaponList;
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.SupportWeaponList;
		}
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.PoppetList;
		}
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.SupportPoppetList;
		}
		return !num;
	}

	internal void _0024MuppetInitialize_0024closure_00243274()
	{
		PushDecide(null);
	}

	internal bool _0024MuppetInitialize_0024closure_00243275()
	{
		bool num = mode == MY_HOME_EQUIP_MAIN.WeaponList;
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.SupportWeaponList;
		}
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.PoppetList;
		}
		if (!num)
		{
			num = mode == MY_HOME_EQUIP_MAIN.SupportPoppetList;
		}
		return !num;
	}

	internal void _0024SendOldEquipCore_0024closure_00243277()
	{
		startMode = MY_HOME_EQUIP_START_MODE.None;
		sendResult = true;
	}

	internal void _0024SendDeck2EquipCore_0024closure_00243281()
	{
		startMode = MY_HOME_EQUIP_START_MODE.None;
		sendResult = true;
	}

	internal void _0024InitSwipePanel_0024closure_00243282(GameObject go, int index)
	{
		BoxDeckPanel boxDeckPanel = null;
		if ((bool)go)
		{
			boxDeckPanel = go.GetComponent<BoxDeckPanel>();
		}
		if ((bool)boxDeckPanel)
		{
			if (index < 0)
			{
				index = 4;
			}
			if (index >= 5)
			{
				index = 0;
			}
			boxDeckPanel.DeckIndex = index;
			if ((bool)boxDeckPanel.mainWeaponInfo)
			{
				mainWeaponInfo = boxDeckPanel.mainWeaponInfo;
			}
			if ((bool)boxDeckPanel.sub1WeaponInfo)
			{
				sub1WeaponInfo = boxDeckPanel.sub1WeaponInfo;
			}
			if ((bool)boxDeckPanel.sub2WeaponInfo)
			{
				sub2WeaponInfo = boxDeckPanel.sub2WeaponInfo;
			}
			if ((bool)boxDeckPanel.muppetInfo)
			{
				muppetInfo = boxDeckPanel.muppetInfo;
			}
			if ((bool)boxDeckPanel.playerHpLabel)
			{
				playerHpLabel = boxDeckPanel.playerHpLabel;
			}
			if ((bool)boxDeckPanel.playerAtkLabel)
			{
				playerAtkLabel = boxDeckPanel.playerAtkLabel;
			}
			WeaponEquipments[] array = wepEquips;
			WeaponEquipments wepEq = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			PoppetEquipments[] array2 = petEquips;
			PoppetEquipments petEq = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			SetSupportInfo(wepEq, petEq);
			if ((bool)mainWeaponInfo)
			{
				mainWeaponInfo.Update();
			}
			if ((bool)sub1WeaponInfo)
			{
				sub1WeaponInfo.Update();
			}
			if ((bool)sub2WeaponInfo)
			{
				sub2WeaponInfo.Update();
			}
			if ((bool)muppetInfo)
			{
				muppetInfo.Update();
			}
		}
	}

	internal void _0024InitSwipePanel_0024closure_00243283(int index)
	{
		SetupDeck(index, loop: true, updateInfo: false);
	}

	internal void _0024InitSwipePanel_0024closure_00243284()
	{
		InitBoxDeckPanel();
	}
}
