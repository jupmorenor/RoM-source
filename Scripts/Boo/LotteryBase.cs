using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using S540;
using UnityEngine;

[Serializable]
public class LotteryBase : S540Base
{
	[Serializable]
	private class LotterySound
	{
		[NonSerialized]
		public const string bgm = "music_sys/03_sys_lottery_001";

		[NonSerialized]
		public const string roll = "Card_Get_Roll";

		[NonSerialized]
		public const string win_0 = "Card_Get_Normal";

		[NonSerialized]
		public const string win_1 = "Card_Get_Rare";

		[NonSerialized]
		public const string win_2 = "Card_Get_SRare";

		[NonSerialized]
		public const string win_3 = "Card_Get_URare";

		[NonSerialized]
		public const string hanabi_1 = "se_system_lottery_hanabi1";

		[NonSerialized]
		public const string hanabi_2 = "se_system_lottery_hanabi2";

		[NonSerialized]
		public const string kira_1 = "se_system_lottery_kira";

		[NonSerialized]
		public const string kira_2 = "se_system_lottery_prizm";

		[NonSerialized]
		public const float delay = 2f;
	}

	[Serializable]
	internal class _0024LoadResource_0024locals_002414328
	{
		internal string _0024file;

		internal __LotteryBase_LoadResource_0024callable41_00241986_51__ _0024callback;
	}

	[Serializable]
	internal class _0024LoadResource_0024closure_00242947
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002415650 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal object _0024dst_002415651;

				internal RuntimeAssetBundleDB _0024abdb_002415652;

				internal RuntimeAssetBundleDB.Req _0024r_002415653;

				internal _0024LoadResource_0024closure_00242947 _0024self__002415654;

				public _0024(_0024LoadResource_0024closure_00242947 self_)
				{
					_0024self__002415654 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024dst_002415651 = null;
						try
						{
							_0024abdb_002415652 = RuntimeAssetBundleDB.Instance;
							_0024r_002415653 = _0024abdb_002415652.loadAsset(_0024self__002415654._0024_0024locals_002414760._0024file);
						}
						catch (Exception)
						{
							if (_0024self__002415654._0024_0024locals_002414760._0024callback != null)
							{
								_0024self__002415654._0024_0024locals_002414760._0024callback(null);
							}
							goto case 1;
						}
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
					case 3:
						if (!_0024r_002415653.IsEnd)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (_0024r_002415653.IsOk)
						{
							_0024dst_002415651 = _0024r_002415653.Asset;
						}
						if (_0024self__002415654._0024_0024locals_002414760._0024callback != null)
						{
							_0024self__002415654._0024_0024locals_002414760._0024callback(_0024dst_002415651);
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

			internal _0024LoadResource_0024closure_00242947 _0024self__002415655;

			public _0024Invoke_002415650(_0024LoadResource_0024closure_00242947 self_)
			{
				_0024self__002415655 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002415655);
			}
		}

		internal _0024LoadResource_0024locals_002414328 _0024_0024locals_002414760;

		public _0024LoadResource_0024closure_00242947(_0024LoadResource_0024locals_002414328 _0024_0024locals_002414760)
		{
			this._0024_0024locals_002414760 = _0024_0024locals_002414760;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002415650(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WaitNextWebView_002415637 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal LotteryBase _0024self__002415638;

			public _0024(LotteryBase self_)
			{
				_0024self__002415638 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (_0024self__002415638.hokan)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if ((bool)_0024self__002415638.curWebView)
					{
						_0024self__002415638.curWebView.ShortcutOpenIsHide = true;
						_0024self__002415638.curWebView.gameObject.SetActive(value: true);
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

		internal LotteryBase _0024self__002415639;

		public _0024WaitNextWebView_002415637(LotteryBase self_)
		{
			_0024self__002415639 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415639);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024HanabiSoundsPlay_002415640 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024h_002415641;

			internal LotteryBase _0024self__002415642;

			public _0024(Transform h, LotteryBase self_)
			{
				_0024h_002415641 = h;
				_0024self__002415642 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024h_002415641.particleSystem.startDelay)) ? 1 : 0);
					break;
				case 2:
					_0024self__002415642.StartCoroutine("HanabiSounds", _0024h_002415641);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024h_002415643;

		internal LotteryBase _0024self__002415644;

		public _0024HanabiSoundsPlay_002415640(Transform h, LotteryBase self_)
		{
			_0024h_002415643 = h;
			_0024self__002415644 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024h_002415643, _0024self__002415644);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024HanabiSounds_002415645 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ParticleSystem _0024comp_002415646;

			internal float _0024ram_002415647;

			internal Transform _0024h_002415648;

			public _0024(Transform h)
			{
				_0024h_002415648 = h;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024comp_002415646 = _0024h_002415648.particleSystem;
						goto case 2;
					case 2:
						if ((bool)_0024comp_002415646 && _0024comp_002415646.isPlaying && _0024comp_002415646.loop)
						{
							_0024ram_002415647 = UnityEngine.Random.value;
							if (!(_0024ram_002415647 <= 0.3f))
							{
								GameSoundManager.PlaySe("se_system_lottery_hanabi1", (int)(_0024ram_002415647 * 0.1f));
							}
							else
							{
								GameSoundManager.PlaySe("se_system_lottery_hanabi2", (int)(_0024ram_002415647 * 0.1f));
							}
							result = (Yield(2, new WaitForSeconds(_0024comp_002415646.duration)) ? 1 : 0);
							break;
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024h_002415649;

		public _0024HanabiSounds_002415645(Transform h)
		{
			_0024h_002415649 = h;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024h_002415649);
		}
	}

	[NonSerialized]
	protected const int MAX_GACHA_TURN = 11;

	public string selif_greeting;

	public string selif_sel_stone;

	public string selif_sel_raid;

	public string selif_sel_point;

	public string selif_sel_event;

	public string selif_wait_tap;

	public string selif_draw_rare;

	public string selif_draw_blank;

	public string selif_insufficient;

	public Texture faystoneBagTexture;

	public Texture friendPointBagTexture;

	public Texture raidPointBagTexture;

	public int bagMaterialIndex;

	public int przNum;

	public float prizeLerpRate;

	public int gachaMode;

	public bool testMode;

	public int testRare;

	public int testPrzNum;

	public bool[] testHaves;

	public GameObject testBG;

	public Dictionary<int, Texture> bagTexture;

	public Dictionary<int, string> bannerHtml;

	public Dictionary<int, Texture> fpBannerTexture;

	public int[] arrRare;

	public int rare;

	protected string message;

	protected float time;

	protected float alpha;

	protected float alpha_t;

	protected float alpha_b;

	protected float alpha_s;

	protected float alpha_f;

	protected float alpTgt;

	protected float alpTgt_t;

	protected float alpTgt_b;

	protected float alpTgt_s;

	protected float alpTgt_f;

	protected float alpha_bg;

	protected float alpTgt_bg;

	protected float selif_sin;

	protected bool hokan;

	protected float hokanRate;

	protected float hokanRate_t;

	protected float hokanRate_b;

	protected bool hokan_s;

	protected float hokanRate_s;

	protected bool hokan_p;

	protected bool hokan_f;

	protected bool pnlIn;

	protected bool pnlIn_s;

	protected bool skip;

	public Transform solidRoot;

	public GameObject menuPanel;

	public GameObject fayStonePanel;

	public GameObject raidPointPanel;

	public GameObject friendPointPanel;

	public GameObject fayStoneEventPanel;

	public GameObject raidPointEventPanel;

	public GameObject friendPointEventPanel;

	public GameObject infoPanel;

	public Transform friendPointBannner;

	protected UISprite friendPointBannnerSprite;

	private UISprite[] uiSprites;

	private UISlicedSprite[] uiSlicSprs;

	private UIDynamicFontLabel[] uiDFLabels;

	private UISprite[] uiSprites_s;

	private UISlicedSprite[] uiSlicSprs_s;

	private UIDynamicFontLabel[] uiDFLabels_s;

	private Transform uiPnl;

	private Transform uiInPnl;

	private Transform uiOutPnl;

	private Vector3 uiOutPnl_pos;

	private Transform uiPnl_b;

	private Transform uiPnl_s;

	private Transform uiPnl_selif;

	private Transform uiPnl_p;

	private Transform uiPnl_home;

	private Transform uiPnl_faystone;

	private Transform uiPnl_raidpoint;

	private Transform uiPnl_friendpoint;

	private Transform uiPnl_info;

	private Vector3 uiPnl_home_pos;

	private Vector3 uiPnl_faystone_pos;

	private Vector3 uiPnl_raidpoint_pos;

	private Vector3 uiPnl_friendpoint_pos;

	private Vector3 uiPnl_info_pos;

	private Transform uiPnl_d;

	private Transform[] arrDetail;

	private Transform efHndFlare_n;

	private Transform efHndFlare_r;

	private Transform efHndFlare_sr;

	private Transform efHndBugLit;

	private Transform efRareRing_n;

	private Transform efRareRing_r;

	private Transform efRareRing_sr;

	private Transform efRareCircle_sr;

	private Transform efHanabi;

	private Transform efHanabi2;

	private Transform efHanabi3;

	private Transform efHanabi4;

	private Transform efHanabi5;

	private Transform efDrwFlare;

	private Transform efDrwFlare_sr;

	private Transform efBagguSmoke;

	private Transform[] arrItmCover;

	private Transform[] arrItmCover_end;

	private Transform[] arrNameTxt;

	private Transform[] arrAtkTxt;

	private Transform[] arrAtkNumTxt;

	private Transform[] arrHpTxt;

	private Transform[] arrHpNumTxt;

	private Transform[] arrItmLine_n;

	private Transform[] arrItmLine_r;

	private Transform[] arrItmLine_sr;

	private Transform[] arrItmLineFlare_n;

	private Transform[] arrItmLineFlare_r;

	private Transform[] arrItmLineFlare_sr;

	private Transform[] arrItmLineAula_sr;

	private Transform bgObj;

	private Material bgMat;

	private Transform fdObj;

	private Material fdMat;

	private Transform[] arrPrize;

	private bool[] arrPrizeHide;

	private Vector3[] arrPrzTrgPos;

	private UISprite[][] arrPrzSprite;

	private UISlicedSprite[][] arrPrzSSprite;

	private UIDynamicFontLabel[][] arrPrzLabel;

	private float przTime;

	private Transform uiPnl_tap;

	private Transform uiPnl_skp;

	private Transform nikiObj;

	private Ef_Anim2Next nikiAnim;

	private Ef_Anim2Next camAnim;

	private Transform bagObj;

	private Texture bagTextureDictionary_back;

	private string anmIdle;

	private string anmSeek_s;

	private string anmSeek;

	private string anmHand_s;

	private string anmHand;

	private string anmWin;

	private string anmWin_l;

	private string anmLose;

	private string anmLose_l;

	private string anmWalk;

	private string anmLuck;

	private string anmLuck_l;

	private string anmCamHome;

	private string anmCamHome_s;

	private string anmCamSeek;

	private string anmCamSeek_l;

	private string anmCamDraw;

	private string anmCamDraw_l;

	private string anmCamDraw_e;

	[NonSerialized]
	private static string lastUrl;

	[NonSerialized]
	private static string nextUrl;

	private GameObject detailPanel;

	public bool enableWebView;

	private bool isWebView;

	protected MSaleGachas curGacha;

	protected TownShopTopMain townModule;

	protected GameObject webViewPanel;

	protected WebView curWebView;

	public float lerpSmooth;

	public GameObject demoAnimPrefab;

	protected GameObject demoAnim;

	protected int demoAnimItemIndex;

	protected bool enableSkip;

	protected Hashtable lastWeaponPicBookFlags;

	protected Hashtable lastPoppetPicBookFlags;

	protected string curPnlName;

	protected string curWebType;

	protected string lastPnlName;

	protected string lastWebType;

	protected bool isWaitInitialize;

	protected bool endSendLottery;

	public Transform[] ItemDetails => arrDetail;

	public LotteryBase()
	{
		prizeLerpRate = 0.07f;
		gachaMode = -1;
		testRare = 1;
		testPrzNum = 1;
		bagTexture = new Dictionary<int, Texture>();
		bannerHtml = new Dictionary<int, string>();
		fpBannerTexture = new Dictionary<int, Texture>();
		message = string.Empty;
		uiPnl_home_pos = new Vector3(1600f, 0f, 0f);
		uiPnl_faystone_pos = new Vector3(1600f, 0f, 0f);
		uiPnl_raidpoint_pos = new Vector3(1600f, 0f, 0f);
		uiPnl_friendpoint_pos = new Vector3(1600f, 0f, 0f);
		uiPnl_info_pos = new Vector3(0f, -1600f, 0f);
		anmIdle = "c5013_ev_idle";
		anmSeek_s = "c5013_ev_idle2seek";
		anmSeek = "c5013_ev_seek";
		anmHand_s = "c5013_ev_seek2hand";
		anmHand = "c5013_ev_hand";
		anmWin = "c5013_ev_win";
		anmWin_l = "c5013_ev_winloop";
		anmLose = "c5013_ev_lose";
		anmLose_l = "c5013_ev_loseloop";
		anmWalk = "c5013_ev_walk";
		anmLuck = "c5013_ev_luck";
		anmLuck_l = "c5013_ev_luckloop";
		anmCamHome = "Lottery_camra_home";
		anmCamHome_s = "Lottery_camra_home_s";
		anmCamSeek = "Lottery_camra_seek";
		anmCamSeek_l = "Lottery_camra_seek_l";
		anmCamDraw = "Lottery_camra_draw";
		anmCamDraw_l = "Lottery_camra_draw_l";
		anmCamDraw_e = "Lottery_camra_draw_e";
		enableWebView = true;
		lerpSmooth = 10f;
		isWaitInitialize = true;
	}

	public void Log(string text)
	{
	}

	private void Awake()
	{
		TownShopTopMain[] array = (TownShopTopMain[])UnityEngine.Object.FindObjectsOfType(typeof(TownShopTopMain));
		if (2 <= array.Length)
		{
		}
		townModule = array[0];
		townModule.CallbackStartCore = delegate
		{
			MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
				isWaitInitialize = false;
			});
			if (testMode)
			{
				testBG.SetActive(value: true);
			}
			townModule.CallbackStartCore = null;
		};
	}

	public new void Update()
	{
		if (!isWaitInitialize)
		{
			if (!(time <= 0f))
			{
				time -= Time.deltaTime;
			}
			else
			{
				time = 0f;
			}
			Hokan();
			Hokan_s();
			Hokan_p();
			Hokan_bg();
			Hokan_f();
			string command = WebViewBase.GetCommand();
			CheckUrl(command);
		}
	}

	public void CheckUrl(object url)
	{
		object obj = url;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		nextUrl = (string)obj;
		if (string.IsNullOrEmpty(nextUrl) || !(nextUrl != lastUrl))
		{
			return;
		}
		message = nextUrl;
		lastUrl = nextUrl;
		string[] array = nextUrl.Split('/');
		string text = array[RuntimeServices.NormalizeArrayIndex(array, checked(array.Length - 1))];
		if (text.IndexOf("_detail") >= 0)
		{
			message = "Info";
			return;
		}
		int result = -1;
		if (!int.TryParse(text, out result))
		{
			return;
		}
		curGacha = MSaleGachas.Get(result);
		if (curGacha != null)
		{
			if (curGacha.MGachaId.GachaTyepValue == EnumGachaTypeValues.Normal)
			{
				message = "FriendPoint";
			}
			else if (curGacha.MGachaId.GachaTyepValue == EnumGachaTypeValues.Raid)
			{
				message = "RaidPoint";
			}
			else
			{
				message = "FayStone";
			}
			if (curGacha.TypeForClient == EnumGachaTypesForClient.Event)
			{
				message += "Event";
			}
		}
	}

	public void Init()
	{
		if (!solidRoot)
		{
			solidRoot = GameObject.Find("3D").transform;
		}
		Transform transform = this.transform;
		uiPnl = transform.Find("10 LotteryMenu/Center Anchor/Panel Root");
		uiPnl_s = transform.Find("10 LotteryMenu/Center Anchor/Selif Panel");
		uiPnl_p = transform.Find("10 LotteryMenu/Center Anchor/Prize Panel");
		uiPnl_d = transform.Find("10 LotteryMenu/Center Anchor/Detail Panel");
		bgObj = solidRoot.Find("Lottery BG");
		bgMat = bgObj.renderer.material;
		bgObj.gameObject.SetActive(value: false);
		fdObj = transform.Find("10 LotteryMenu/Center Anchor/Prize Panel/Fade Board");
		fdObj.localScale = new Vector3((float)Screen.width * 0.2f, 1f, (float)Screen.height * 0.2f);
		fdMat = fdObj.renderer.material;
		fdObj.gameObject.SetActive(value: false);
		uiPnl_selif = uiPnl_s.Find("Selif Root");
		uiPnl_home = uiPnl.Find("01 Home Panel");
		uiPnl_faystone = uiPnl.Find("02 FayStone Panel");
		uiPnl_raidpoint = uiPnl.Find("03 RaidPoint Panel");
		uiPnl_friendpoint = uiPnl.Find("04 FriendPoint Panel");
		uiPnl_info = uiPnl.Find("05 Info Panel");
		if (enableWebView)
		{
			if ((bool)menuPanel)
			{
				IEnumerator enumerator = uiPnl_home.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is Transform))
					{
						obj = RuntimeServices.Coerce(obj, typeof(Transform));
					}
					Transform transform2 = (Transform)obj;
					UnityEngine.Object.DestroyObject(transform2.gameObject);
				}
				menuPanel.transform.parent = uiPnl_home;
				float x = menuPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition = menuPanel.transform.localPosition;
				float num = (localPosition.x = x);
				Vector3 vector2 = (menuPanel.transform.localPosition = localPosition);
			}
			IEnumerator enumerator2 = uiPnl_faystone.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				if (!(obj2 is Transform))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
				}
				Transform transform3 = (Transform)obj2;
				UnityEngine.Object.DestroyObject(transform3.gameObject);
			}
			IEnumerator enumerator3 = uiPnl_raidpoint.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				object obj3 = enumerator3.Current;
				if (!(obj3 is Transform))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Transform));
				}
				Transform transform4 = (Transform)obj3;
				UnityEngine.Object.DestroyObject(transform4.gameObject);
			}
			IEnumerator enumerator4 = uiPnl_friendpoint.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				object obj4 = enumerator4.Current;
				if (!(obj4 is Transform))
				{
					obj4 = RuntimeServices.Coerce(obj4, typeof(Transform));
				}
				Transform transform5 = (Transform)obj4;
				UnityEngine.Object.DestroyObject(transform5.gameObject);
			}
			IEnumerator enumerator5 = uiPnl_info.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				object obj5 = enumerator5.Current;
				if (!(obj5 is Transform))
				{
					obj5 = RuntimeServices.Coerce(obj5, typeof(Transform));
				}
				Transform transform6 = (Transform)obj5;
				UnityEngine.Object.DestroyObject(transform6.gameObject);
			}
			if ((bool)fayStonePanel)
			{
				fayStonePanel.transform.parent = uiPnl_faystone;
				float x2 = fayStonePanel.transform.localPosition.x + 1000f;
				Vector3 localPosition2 = fayStonePanel.transform.localPosition;
				float num2 = (localPosition2.x = x2);
				Vector3 vector4 = (fayStonePanel.transform.localPosition = localPosition2);
			}
			if ((bool)fayStoneEventPanel)
			{
				fayStoneEventPanel.transform.parent = uiPnl_faystone;
				float x3 = fayStoneEventPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition3 = fayStoneEventPanel.transform.localPosition;
				float num3 = (localPosition3.x = x3);
				Vector3 vector6 = (fayStoneEventPanel.transform.localPosition = localPosition3);
			}
			if ((bool)raidPointPanel)
			{
				raidPointPanel.transform.parent = uiPnl_raidpoint;
				float x4 = raidPointPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition4 = raidPointPanel.transform.localPosition;
				float num4 = (localPosition4.x = x4);
				Vector3 vector8 = (raidPointPanel.transform.localPosition = localPosition4);
			}
			if ((bool)raidPointEventPanel)
			{
				raidPointEventPanel.transform.parent = uiPnl_raidpoint;
				float x5 = raidPointEventPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition5 = raidPointEventPanel.transform.localPosition;
				float num5 = (localPosition5.x = x5);
				Vector3 vector10 = (raidPointEventPanel.transform.localPosition = localPosition5);
			}
			if ((bool)friendPointPanel)
			{
				friendPointPanel.transform.parent = uiPnl_friendpoint;
				float x6 = friendPointPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition6 = friendPointPanel.transform.localPosition;
				float num6 = (localPosition6.x = x6);
				Vector3 vector12 = (friendPointPanel.transform.localPosition = localPosition6);
			}
			if ((bool)friendPointEventPanel)
			{
				friendPointEventPanel.transform.parent = uiPnl_friendpoint;
				float x7 = friendPointEventPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition7 = friendPointEventPanel.transform.localPosition;
				float num7 = (localPosition7.x = x7);
				Vector3 vector14 = (friendPointEventPanel.transform.localPosition = localPosition7);
			}
			if ((bool)infoPanel)
			{
				infoPanel.transform.parent = uiPnl_info;
				float x8 = infoPanel.transform.localPosition.x + 1000f;
				Vector3 localPosition8 = infoPanel.transform.localPosition;
				float num8 = (localPosition8.x = x8);
				Vector3 vector16 = (infoPanel.transform.localPosition = localPosition8);
			}
		}
		arrPrize = new Transform[11];
		arrPrizeHide = new bool[11];
		arrNameTxt = new Transform[11];
		arrAtkTxt = new Transform[11];
		arrAtkNumTxt = new Transform[11];
		arrHpTxt = new Transform[11];
		arrHpNumTxt = new Transform[11];
		int num9 = 0;
		int num10 = 11;
		if (num10 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num9 < num10)
		{
			int num11 = num9;
			num9++;
			Transform[] array = arrPrize;
			array[RuntimeServices.NormalizeArrayIndex(array, num11)] = uiPnl_p.Find($"Prize{checked(num11 + 1):00}");
			Transform[] array2 = arrNameTxt;
			int num12 = RuntimeServices.NormalizeArrayIndex(array2, num11);
			Transform[] array3 = arrPrize;
			array2[num12] = array3[RuntimeServices.NormalizeArrayIndex(array3, num11)].Find("Name").transform;
			Transform[] array4 = arrAtkTxt;
			int num13 = RuntimeServices.NormalizeArrayIndex(array4, num11);
			Transform[] array5 = arrPrize;
			array4[num13] = array5[RuntimeServices.NormalizeArrayIndex(array5, num11)].Find("Atk").transform;
			Transform[] array6 = arrAtkNumTxt;
			int num14 = RuntimeServices.NormalizeArrayIndex(array6, num11);
			Transform[] array7 = arrPrize;
			array6[num14] = array7[RuntimeServices.NormalizeArrayIndex(array7, num11)].Find("AtkNum").transform;
			Transform[] array8 = arrHpTxt;
			int num15 = RuntimeServices.NormalizeArrayIndex(array8, num11);
			Transform[] array9 = arrPrize;
			array8[num15] = array9[RuntimeServices.NormalizeArrayIndex(array9, num11)].Find("Hp").transform;
			Transform[] array10 = arrHpNumTxt;
			int num16 = RuntimeServices.NormalizeArrayIndex(array10, num11);
			Transform[] array11 = arrPrize;
			array10[num16] = array11[RuntimeServices.NormalizeArrayIndex(array11, num11)].Find("HpNum").transform;
		}
		uiPnl_tap = transform.Find("10 LotteryMenu/Center Anchor/Tap Panel");
		uiPnl_skp = transform.Find("10 LotteryMenu/Center Anchor/Skip Panel");
		nikiObj = solidRoot.Find("c5013_000_ma_Lottery");
		nikiAnim = nikiObj.gameObject.AddComponent<Ef_Anim2Next>();
		camAnim = solidRoot.gameObject.AddComponent<Ef_Anim2Next>();
		bagObj = nikiObj.Find("poly/c5013_000_all");
		Material[] materials = bagObj.renderer.materials;
		bagTextureDictionary_back = materials[RuntimeServices.NormalizeArrayIndex(materials, bagMaterialIndex)].mainTexture;
		if ((bool)friendPointBannner)
		{
			friendPointBannnerSprite = friendPointBannner.GetComponent<UISprite>();
		}
		efDrwFlare = solidRoot.Find("Effects/Ef_Draw_Flare");
		efDrwFlare_sr = solidRoot.Find("Effects/Ef_Draw_Flare_sr");
		efBagguSmoke = solidRoot.Find("Effects/Ef_Baggu_Smoke");
		efHndFlare_n = solidRoot.Find("Effects/Ef_Hand_Flare");
		efHndFlare_n.parent = nikiObj.Find("y_ang/cog/c_spine_a/c_spine_b/r_clavicre/r_upperarm/r_forearm/r_hand");
		efHndFlare_n.localPosition = new Vector3(0.2f, 0.1f, 0f);
		efHndFlare_r = solidRoot.Find("Effects/Ef_Hand_Flare_r");
		efHndFlare_r.parent = nikiObj.Find("y_ang/cog/c_spine_a/c_spine_b/r_clavicre/r_upperarm/r_forearm/r_hand");
		efHndFlare_r.localPosition = new Vector3(0.2f, 0.1f, 0f);
		efHndFlare_sr = solidRoot.Find("Effects/Ef_Hand_Flare_sr");
		efHndFlare_sr.parent = nikiObj.Find("y_ang/cog/c_spine_a/c_spine_b/r_clavicre/r_upperarm/r_forearm/r_hand");
		efHndFlare_sr.localPosition = new Vector3(0.2f, 0.1f, 0f);
		efHndBugLit = solidRoot.Find("Effects/Ef_Hand_BugLit");
		efHndBugLit.parent = nikiObj.Find("y_ang/cog/c_spine_a/c_spine_b/c_bag_a/c_bag_b");
		efHndBugLit.localPosition = new Vector3(-0.3f, 0.05f, 0f);
		efHndBugLit.localRotation = Quaternion.identity;
		efRareRing_n = solidRoot.Find("Effects/Ef_Rare_Ring");
		efRareRing_r = solidRoot.Find("Effects/Ef_Rare_Ring_r");
		efRareRing_sr = solidRoot.Find("Effects/Ef_Rare_Ring_sr");
		efRareCircle_sr = solidRoot.Find("Effects/Ef_Rare_Circle_sr");
		efHanabi = solidRoot.Find("Effects/Ef_Hanabi");
		efHanabi2 = efHanabi.Find("Hanabi2");
		efHanabi3 = efHanabi.Find("Hanabi3");
		efHanabi4 = efHanabi.Find("Hanabi4");
		efHanabi5 = efHanabi.Find("Hanabi5");
		Transform original = solidRoot.Find("Effects/Ef_Item_Cover");
		Transform original2 = solidRoot.Find("Effects/Ef_Item_Cover_end");
		Transform original3 = solidRoot.Find("Effects/Ef_Item_Line");
		Transform original4 = solidRoot.Find("Effects/Ef_Item_Line_r");
		Transform original5 = solidRoot.Find("Effects/Ef_Item_Line_sr");
		arrItmCover = new Transform[11];
		arrItmCover_end = new Transform[11];
		arrItmLine_n = new Transform[11];
		arrItmLine_r = new Transform[11];
		arrItmLine_sr = new Transform[11];
		arrItmLineFlare_n = new Transform[11];
		arrItmLineFlare_r = new Transform[11];
		arrItmLineFlare_sr = new Transform[11];
		arrItmLineAula_sr = new Transform[11];
		int num17 = 0;
		int num18 = 11;
		if (num18 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num17 < num18)
		{
			int index = num17;
			num17++;
			Transform[] array12 = arrItmCover;
			array12[RuntimeServices.NormalizeArrayIndex(array12, index)] = ((Transform)UnityEngine.Object.Instantiate(original)).transform;
			Transform[] array13 = arrItmCover;
			Transform obj6 = array13[RuntimeServices.NormalizeArrayIndex(array13, index)];
			Transform[] array14 = arrPrize;
			obj6.parent = array14[RuntimeServices.NormalizeArrayIndex(array14, index)];
			Transform[] array15 = arrItmCover;
			array15[RuntimeServices.NormalizeArrayIndex(array15, index)].localPosition = Vector3.back;
			Transform[] array16 = arrItmCover;
			array16[RuntimeServices.NormalizeArrayIndex(array16, index)].localScale = new Vector3(165f, 165f, 1f);
			Transform[] array17 = arrItmCover;
			array17[RuntimeServices.NormalizeArrayIndex(array17, index)].renderer.enabled = false;
			Transform[] array18 = arrItmCover_end;
			array18[RuntimeServices.NormalizeArrayIndex(array18, index)] = ((Transform)UnityEngine.Object.Instantiate(original2)).transform;
			Transform[] array19 = arrItmCover_end;
			Transform obj7 = array19[RuntimeServices.NormalizeArrayIndex(array19, index)];
			Transform[] array20 = arrPrize;
			obj7.parent = array20[RuntimeServices.NormalizeArrayIndex(array20, index)];
			Transform[] array21 = arrItmCover_end;
			array21[RuntimeServices.NormalizeArrayIndex(array21, index)].localPosition = Vector3.back;
			Transform[] array22 = arrItmCover_end;
			array22[RuntimeServices.NormalizeArrayIndex(array22, index)].localScale = Vector3.one;
			Transform[] array23 = arrItmLine_n;
			array23[RuntimeServices.NormalizeArrayIndex(array23, index)] = ((Transform)UnityEngine.Object.Instantiate(original3)).transform;
			Transform[] array24 = arrItmLine_n;
			Transform obj8 = array24[RuntimeServices.NormalizeArrayIndex(array24, index)];
			Transform[] array25 = arrPrize;
			obj8.parent = array25[RuntimeServices.NormalizeArrayIndex(array25, index)];
			Transform[] array26 = arrItmLine_n;
			array26[RuntimeServices.NormalizeArrayIndex(array26, index)].localPosition = new Vector3(0f, 0f, 10f);
			Transform[] array27 = arrItmLine_n;
			array27[RuntimeServices.NormalizeArrayIndex(array27, index)].localScale = Vector3.one;
			Transform[] array28 = arrItmLineFlare_n;
			int num19 = RuntimeServices.NormalizeArrayIndex(array28, index);
			Transform[] array29 = arrItmLine_n;
			array28[num19] = array29[RuntimeServices.NormalizeArrayIndex(array29, index)].Find("Ef_Item_LineFlare");
			Transform[] array30 = arrItmLine_r;
			array30[RuntimeServices.NormalizeArrayIndex(array30, index)] = ((Transform)UnityEngine.Object.Instantiate(original4)).transform;
			Transform[] array31 = arrItmLine_r;
			Transform obj9 = array31[RuntimeServices.NormalizeArrayIndex(array31, index)];
			Transform[] array32 = arrPrize;
			obj9.parent = array32[RuntimeServices.NormalizeArrayIndex(array32, index)];
			Transform[] array33 = arrItmLine_r;
			array33[RuntimeServices.NormalizeArrayIndex(array33, index)].localPosition = new Vector3(0f, 0f, 10f);
			Transform[] array34 = arrItmLine_r;
			array34[RuntimeServices.NormalizeArrayIndex(array34, index)].localScale = Vector3.one;
			Transform[] array35 = arrItmLineFlare_r;
			int num20 = RuntimeServices.NormalizeArrayIndex(array35, index);
			Transform[] array36 = arrItmLine_r;
			array35[num20] = array36[RuntimeServices.NormalizeArrayIndex(array36, index)].Find("Ef_Item_LineFlare");
			Transform[] array37 = arrItmLine_sr;
			array37[RuntimeServices.NormalizeArrayIndex(array37, index)] = ((Transform)UnityEngine.Object.Instantiate(original5)).transform;
			Transform[] array38 = arrItmLine_sr;
			Transform obj10 = array38[RuntimeServices.NormalizeArrayIndex(array38, index)];
			Transform[] array39 = arrPrize;
			obj10.parent = array39[RuntimeServices.NormalizeArrayIndex(array39, index)];
			Transform[] array40 = arrItmLine_sr;
			array40[RuntimeServices.NormalizeArrayIndex(array40, index)].localPosition = new Vector3(0f, 0f, 10f);
			Transform[] array41 = arrItmLine_sr;
			array41[RuntimeServices.NormalizeArrayIndex(array41, index)].localScale = Vector3.one;
			Transform[] array42 = arrItmLineFlare_sr;
			int num21 = RuntimeServices.NormalizeArrayIndex(array42, index);
			Transform[] array43 = arrItmLine_sr;
			array42[num21] = array43[RuntimeServices.NormalizeArrayIndex(array43, index)].Find("Ef_Item_LineFlare");
			Transform[] array44 = arrItmLineAula_sr;
			int num22 = RuntimeServices.NormalizeArrayIndex(array44, index);
			Transform[] array45 = arrItmLine_sr;
			array44[num22] = array45[RuntimeServices.NormalizeArrayIndex(array45, index)].Find("Ef_Item_Aula");
		}
		uiSprites = uiPnl.GetComponentsInChildren<UISprite>();
		uiSlicSprs = uiPnl.GetComponentsInChildren<UISlicedSprite>();
		uiDFLabels = uiPnl.GetComponentsInChildren<UIDynamicFontLabel>();
		uiSprites_s = uiPnl_s.GetComponentsInChildren<UISprite>();
		uiSlicSprs_s = uiPnl_s.GetComponentsInChildren<UISlicedSprite>();
		uiDFLabels_s = uiPnl_s.GetComponentsInChildren<UIDynamicFontLabel>();
		arrPrzTrgPos = new Vector3[11]
		{
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero,
			Vector3.zero
		};
		arrPrzSprite = Gen_array_macrosModule.GenArray<UISprite[], Transform>(arrPrize, (__LotteryBase_0024callable310_0024296_11__)((Transform _0024genarray_0024691) => _0024genarray_0024691.GetComponentsInChildren<UISprite>()));
		arrPrzSSprite = Gen_array_macrosModule.GenArray<UISlicedSprite[], Transform>(arrPrize, (__LotteryBase_0024callable311_0024296_11__)((Transform _0024genarray_0024692) => _0024genarray_0024692.GetComponentsInChildren<UISlicedSprite>()));
		arrPrzLabel = Gen_array_macrosModule.GenArray<UIDynamicFontLabel[], Transform>(arrPrize, (__LotteryBase_0024callable312_0024296_11__)((Transform _0024genarray_0024693) => _0024genarray_0024693.GetComponentsInChildren<UIDynamicFontLabel>()));
		arrDetail = new Transform[2]
		{
			uiPnl_d.Find("Weapon/WeaponDetail"),
			uiPnl_d.Find("Muppet/MuppetDetail")
		};
		nikiAnim.Anim(anmIdle).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmSeek_s).wrapMode = WrapMode.Once;
		nikiAnim.Anim(anmSeek).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmHand_s).wrapMode = WrapMode.Once;
		nikiAnim.Anim(anmHand).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmWin).wrapMode = WrapMode.Once;
		nikiAnim.Anim(anmWin_l).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmLose).wrapMode = WrapMode.Once;
		nikiAnim.Anim(anmLose_l).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmLuck).wrapMode = WrapMode.Once;
		nikiAnim.Anim(anmLuck_l).wrapMode = WrapMode.Loop;
		nikiAnim.Anim(anmWalk).wrapMode = WrapMode.Once;
		camAnim.Anim(anmCamHome).wrapMode = WrapMode.Loop;
		camAnim.Anim(anmCamHome_s).wrapMode = WrapMode.Once;
		camAnim.Anim(anmCamSeek).wrapMode = WrapMode.Once;
		camAnim.Anim(anmCamSeek_l).wrapMode = WrapMode.Loop;
		camAnim.Anim(anmCamDraw).wrapMode = WrapMode.Once;
		camAnim.Anim(anmCamDraw_l).wrapMode = WrapMode.Loop;
		camAnim.Anim(anmCamDraw_e).wrapMode = WrapMode.Once;
		Transform transform7 = solidRoot.Find("CameraTarget/CameraTarget");
		if (!(ScreenAspect() > 1.5f))
		{
			transform7.localScale = new Vector3(0f, 0f, -0.5f);
		}
		selif_greeting = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryNormal);
		if (string.IsNullOrEmpty(selif_greeting))
		{
			selif_greeting = "くじびきをひいて\n武器や魔ペットを\n当てるにゃ！";
		}
		selif_sel_stone = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryFaystone);
		if (string.IsNullOrEmpty(selif_sel_stone))
		{
			selif_sel_stone = "精霊石を５個使って\n１回ひける\nハッピーくじにゃ！";
		}
		selif_sel_raid = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryFaystone);
		if (string.IsNullOrEmpty(selif_sel_raid))
		{
			selif_sel_raid = "精霊石を５個使って\n１回ひける\nハッピーくじにゃ！";
		}
		selif_sel_point = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryFriendpoint);
		if (string.IsNullOrEmpty(selif_sel_point))
		{
			selif_sel_point = "フレンドポイントを使っ\nてひけるおトクな\n無料くじにゃ！";
		}
		selif_sel_event = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryEvent);
		if (string.IsNullOrEmpty(selif_sel_event))
		{
			selif_sel_event = "精霊石を５個使って\n１回ひける\nワンダホーくじにゃ！！";
		}
		selif_wait_tap = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryStart);
		if (string.IsNullOrEmpty(selif_wait_tap))
		{
			selif_wait_tap = "画面をタップしてにゃ";
		}
		selif_draw_rare = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryResult03);
		if (string.IsNullOrEmpty(selif_draw_rare))
		{
			selif_draw_rare = "大当たり～！\nお客さんついてるにゃ";
		}
		selif_insufficient = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryFaystoneNeed);
		if (string.IsNullOrEmpty(selif_insufficient))
		{
			selif_insufficient = "精霊石が足りないにゃ\nここで買うか？";
		}
		selif_draw_blank = MShopMessageUtil.GetRandomMessage(EnumShopMessageTypes.LotteryResult02);
		if (string.IsNullOrEmpty(selif_draw_blank))
		{
			selif_draw_blank = "にゃふふ\nいいのがでたにゃ";
		}
		uiPnl_p.gameObject.SetActive(value: false);
		uiPnl_tap.gameObject.SetActive(value: false);
		uiPnl_skp.gameObject.SetActive(value: false);
		arrRare = new int[11];
		rare = 0;
	}

	public void OnDestroy()
	{
		GameObject gameObject = GameObject.Find("Terrain");
		GameObject gameObject2 = GameObject.Find("Town");
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject.gameObject);
		}
		if ((bool)gameObject2)
		{
			UnityEngine.Object.DestroyObject(gameObject2.gameObject);
		}
		WebViewBase.EndWebView();
		StopSE();
		ScreenMask.deactivate();
	}

	private void Hokan()
	{
		if (!hokan)
		{
			return;
		}
		bool flag = false;
		if (!(alpha >= alpTgt))
		{
			alpha += 4f * Time.deltaTime;
			if (!(alpha <= alpTgt))
			{
				alpha = alpTgt;
			}
			flag = true;
		}
		if (!(alpha_t >= alpTgt_t))
		{
			alpha_t += 4f * Time.deltaTime;
			if (!(alpha_t <= alpTgt_t))
			{
				alpha_t = alpTgt_t;
			}
			flag = true;
		}
		if (!(alpha_b >= alpTgt_b))
		{
			alpha_b += 4f * Time.deltaTime;
			if (!(alpha_b <= alpTgt_b))
			{
				alpha_b = alpTgt_b;
			}
			flag = true;
		}
		else if (!(alpha <= alpTgt))
		{
			alpha -= 4f * Time.deltaTime;
			if (!(alpha >= alpTgt))
			{
				alpha = alpTgt;
			}
			flag = true;
		}
		else if (!(alpha_t <= alpTgt_t))
		{
			alpha_t -= 4f * Time.deltaTime;
			if (!(alpha_t >= alpTgt_t))
			{
				alpha_t = alpTgt_t;
			}
			flag = true;
		}
		else if (!(alpha_b <= alpTgt_b))
		{
			alpha_b -= 4f * Time.deltaTime;
			if (!(alpha_b >= alpTgt_b))
			{
				alpha_b = alpTgt_b;
			}
			flag = true;
		}
		if (flag)
		{
			PnlAlpUpdate();
		}
		uiPnl.localPosition = Vector3.zero;
		if (pnlIn)
		{
			if ((bool)uiInPnl && uiInPnl.localPosition != Vector3.zero)
			{
				uiInPnl.localPosition = Vector3.Lerp(uiInPnl.localPosition, Vector3.zero, lerpSmooth * Time.deltaTime);
				if (!(uiInPnl.localPosition.magnitude >= 0.05f))
				{
					uiInPnl.localPosition = Vector3.zero;
				}
				flag = true;
			}
		}
		else if ((bool)uiOutPnl && uiOutPnl.localPosition != uiOutPnl_pos)
		{
			uiInPnl.localPosition = Vector3.Lerp(uiOutPnl_pos, uiInPnl.localPosition, 1f - lerpSmooth * Time.deltaTime);
			Vector3 vector = Vector3.zero - uiOutPnl_pos;
			if (!((uiInPnl.localPosition - uiOutPnl_pos).magnitude >= 1f))
			{
				uiOutPnl.localPosition = uiOutPnl_pos;
				uiOutPnl = null;
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			hokan = false;
		}
	}

	private void Hokan_s()
	{
		Vector3 localPosition = uiPnl_selif.localPosition;
		selif_sin += 0.05f;
		float num = Mathf.Sin(selif_sin);
		localPosition.y = Mathf.Round(localPosition.y / 10f) * 10f + 5f * num;
		uiPnl_selif.localPosition = localPosition;
		uiPnl_selif.localScale = Vector3.one * (float)(1.0 + 0.01 * (double)num);
		if (!hokan_s)
		{
			return;
		}
		bool flag = false;
		if (!(alpha_s >= alpTgt_s))
		{
			alpha_s += 6f * Time.deltaTime;
			if (!(alpha_s <= alpTgt_s))
			{
				alpha_s = alpTgt_s;
			}
			flag = true;
		}
		else if (!(alpha_s <= alpTgt_s))
		{
			alpha_s -= 6f * Time.deltaTime;
			if (!(alpha_s >= alpTgt_s))
			{
				alpha_s = alpTgt_s;
			}
			flag = true;
		}
		if (flag)
		{
			PnlAlpUpdate_s();
		}
		if (pnlIn_s)
		{
			if (uiPnl_s.localPosition != new Vector3(0f, 0f, 1f))
			{
				uiPnl_s.localPosition = Vector3.Lerp(uiPnl_s.localPosition, new Vector3(0f, 0f, 1.5f), 20f * Time.deltaTime);
				if (!((uiPnl_s.localPosition - new Vector3(0f, 0f, 1f)).magnitude >= 0.05f))
				{
					uiPnl_s.localPosition = new Vector3(0f, 0f, 1f);
				}
				flag = true;
			}
		}
		else if (!(uiPnl_s.localPosition.y >= 250f))
		{
			hokanRate_s += 12000f * Time.deltaTime;
			uiPnl_s.localPosition += new Vector3(0f, hokanRate_s * Time.deltaTime, 0f);
			if (!(uiPnl_s.localPosition.y <= 250f))
			{
				uiPnl_s.localPosition = new Vector3(0f, 250f, 0f);
			}
			flag = true;
		}
		if (!flag)
		{
			hokan_s = false;
		}
	}

	private void Hokan_p()
	{
		if (!hokan_p)
		{
			return;
		}
		float num = przTime;
		przTime += Time.deltaTime;
		float num2 = 1f - 0.025f * (float)przNum;
		if (przNum == 1)
		{
			num2 = 2f;
		}
		Vector3 vector = new Vector3(num2, num2, 1f);
		if (skip)
		{
			Hokan_p_Skip();
			return;
		}
		int num3 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		bool flag = false;
		int num6 = 0;
		int num7 = przNum;
		if (num7 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num6 < num7)
		{
			int num8 = num6;
			num6++;
			alpha = przTime * 2f - (float)checked(przNum - num8 + 1) * 0.15f;
			if (!(alpha >= -0.5f))
			{
				alpha = 0f;
			}
			else
			{
				if (!(alpha >= 0f))
				{
					alpha = 0f;
				}
				Transform[] array = arrPrize;
				Transform obj = array[RuntimeServices.NormalizeArrayIndex(array, num8)];
				Transform[] array2 = arrPrize;
				Vector3 localPosition = array2[RuntimeServices.NormalizeArrayIndex(array2, num8)].localPosition;
				Vector3[] array3 = arrPrzTrgPos;
				obj.localPosition = Vector3.Lerp(localPosition, array3[RuntimeServices.NormalizeArrayIndex(array3, num8)], prizeLerpRate);
				Transform[] array4 = arrPrize;
				Transform obj2 = array4[RuntimeServices.NormalizeArrayIndex(array4, num8)];
				Transform[] array5 = arrPrize;
				obj2.localScale = Vector3.Lerp(array5[RuntimeServices.NormalizeArrayIndex(array5, num8)].localScale, vector, prizeLerpRate);
				if (!(alpha <= 0f))
				{
					bool[] array6 = arrPrizeHide;
					if (array6[RuntimeServices.NormalizeArrayIndex(array6, num8)])
					{
						int[] array7 = arrRare;
						if (array7[RuntimeServices.NormalizeArrayIndex(array7, num8)] <= 2)
						{
							Transform[] array8 = arrItmLine_n;
							array8[RuntimeServices.NormalizeArrayIndex(array8, num8)].particleSystem.startSize = 0.05f * num2;
							Transform[] array9 = arrItmLineFlare_n;
							array9[RuntimeServices.NormalizeArrayIndex(array9, num8)].particleSystem.startSize = 0.8f * num2;
							Transform[] array10 = arrItmLine_n;
							array10[RuntimeServices.NormalizeArrayIndex(array10, num8)].particleSystem.Play();
							Transform[] array11 = arrItmLineFlare_n;
							array11[RuntimeServices.NormalizeArrayIndex(array11, num8)].particleSystem.Play();
						}
						else
						{
							int[] array12 = arrRare;
							if (array12[RuntimeServices.NormalizeArrayIndex(array12, num8)] <= 4)
							{
								Transform[] array13 = arrItmLine_r;
								array13[RuntimeServices.NormalizeArrayIndex(array13, num8)].particleSystem.startSize = 0.08f * num2;
								Transform[] array14 = arrItmLineFlare_r;
								array14[RuntimeServices.NormalizeArrayIndex(array14, num8)].particleSystem.startSize = 0.8f * num2;
								Transform[] array15 = arrItmLine_r;
								array15[RuntimeServices.NormalizeArrayIndex(array15, num8)].particleSystem.Play();
								Transform[] array16 = arrItmLineFlare_r;
								array16[RuntimeServices.NormalizeArrayIndex(array16, num8)].particleSystem.Play();
							}
							else
							{
								Transform[] array17 = arrItmLine_sr;
								array17[RuntimeServices.NormalizeArrayIndex(array17, num8)].particleSystem.startSize = 0.1f * num2;
								Transform[] array18 = arrItmLineFlare_sr;
								array18[RuntimeServices.NormalizeArrayIndex(array18, num8)].particleSystem.startSize = 1f * num2;
								Transform[] array19 = arrItmLineAula_sr;
								array19[RuntimeServices.NormalizeArrayIndex(array19, num8)].particleSystem.startSize = 2f * num2;
								Transform[] array20 = arrItmLine_sr;
								array20[RuntimeServices.NormalizeArrayIndex(array20, num8)].particleSystem.Play();
								Transform[] array21 = arrItmLineFlare_sr;
								array21[RuntimeServices.NormalizeArrayIndex(array21, num8)].particleSystem.Play();
								Transform[] array22 = arrItmLineAula_sr;
								array22[RuntimeServices.NormalizeArrayIndex(array22, num8)].particleSystem.Play();
							}
						}
						bool[] array23 = arrPrizeHide;
						array23[RuntimeServices.NormalizeArrayIndex(array23, num8)] = false;
					}
				}
			}
			if (!(alpha <= 1f))
			{
				alpha = 1f;
			}
			else
			{
				flag = true;
			}
			if (RuntimeServices.EqualityOperator(typeof(int), 0))
			{
				UISprite[][] array24 = arrPrzSprite;
				num3 = array24[RuntimeServices.NormalizeArrayIndex(array24, num8)].Length;
				UISlicedSprite[][] array25 = arrPrzSSprite;
				num4 = array25[RuntimeServices.NormalizeArrayIndex(array25, num8)].Length;
				UIDynamicFontLabel[][] array26 = arrPrzLabel;
				num5 = array26[RuntimeServices.NormalizeArrayIndex(array26, num8)].Length;
			}
			int num9 = 0;
			int num10 = num3;
			if (num10 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num9 < num10)
			{
				int index = num9;
				num9++;
				UISprite[][] array27 = arrPrzSprite;
				UISprite[] obj3 = array27[RuntimeServices.NormalizeArrayIndex(array27, num8)];
				Color color = obj3[RuntimeServices.NormalizeArrayIndex(obj3, index)].color;
				color.a = alpha;
				UISprite[][] array28 = arrPrzSprite;
				UISprite[] obj4 = array28[RuntimeServices.NormalizeArrayIndex(array28, num8)];
				obj4[RuntimeServices.NormalizeArrayIndex(obj4, index)].color = color;
			}
			int num11 = 0;
			int num12 = num4;
			if (num12 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num11 < num12)
			{
				int index2 = num11;
				num11++;
				UISlicedSprite[][] array29 = arrPrzSSprite;
				UISlicedSprite[] obj5 = array29[RuntimeServices.NormalizeArrayIndex(array29, num8)];
				Color color = obj5[RuntimeServices.NormalizeArrayIndex(obj5, index2)].color;
				color.a = alpha;
				UISlicedSprite[][] array30 = arrPrzSSprite;
				UISlicedSprite[] obj6 = array30[RuntimeServices.NormalizeArrayIndex(array30, num8)];
				obj6[RuntimeServices.NormalizeArrayIndex(obj6, index2)].color = color;
			}
			int num13 = 0;
			int num14 = num5;
			if (num14 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num13 < num14)
			{
				int index3 = num13;
				num13++;
				UIDynamicFontLabel[][] array31 = arrPrzLabel;
				UIDynamicFontLabel[] obj7 = array31[RuntimeServices.NormalizeArrayIndex(array31, num8)];
				Color color = obj7[RuntimeServices.NormalizeArrayIndex(obj7, index3)].color;
				color.a = alpha;
				UIDynamicFontLabel[][] array32 = arrPrzLabel;
				UIDynamicFontLabel[] obj8 = array32[RuntimeServices.NormalizeArrayIndex(array32, num8)];
				obj8[RuntimeServices.NormalizeArrayIndex(obj8, index3)].color = color;
			}
			Vector3[] array33 = arrPrzTrgPos;
			Vector3 vector2 = array33[RuntimeServices.NormalizeArrayIndex(array33, num8)];
			Transform[] array34 = arrPrize;
			if (!((vector2 - array34[RuntimeServices.NormalizeArrayIndex(array34, num8)].localPosition).magnitude >= 1f))
			{
				Transform[] array35 = arrPrize;
				Transform obj9 = array35[RuntimeServices.NormalizeArrayIndex(array35, num8)];
				Vector3[] array36 = arrPrzTrgPos;
				obj9.localPosition = array36[RuntimeServices.NormalizeArrayIndex(array36, num8)];
				Transform[] array37 = arrPrize;
				array37[RuntimeServices.NormalizeArrayIndex(array37, num8)].localScale = vector;
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			hokan_p = false;
		}
	}

	private void Hokan_p_Skip()
	{
		efRareRing_n.particleSystem.Stop();
		efRareRing_n.particleSystem.Clear();
		efRareRing_r.particleSystem.Stop();
		efRareRing_r.particleSystem.Clear();
		efRareRing_sr.particleSystem.Stop();
		efRareRing_sr.particleSystem.Clear();
		efRareCircle_sr.GetComponent<Ef_QuickAnimTransform>().Stop();
		efRareCircle_sr.GetComponent<Ef_QuickAnimTransform>().Clear();
		efHndFlare_n.particleSystem.Stop();
		efHndFlare_n.particleSystem.Clear();
		efHndFlare_r.particleSystem.Stop();
		efHndFlare_r.particleSystem.Clear();
		efHndFlare_sr.particleSystem.Stop();
		efHndFlare_sr.particleSystem.Clear();
		efHndBugLit.particleSystem.Stop();
		efHndBugLit.particleSystem.Clear();
		efDrwFlare.particleSystem.Stop();
		efDrwFlare.particleSystem.Clear();
		efDrwFlare_sr.particleSystem.Stop();
		efDrwFlare_sr.particleSystem.Clear();
		efBagguSmoke.particleSystem.Stop();
		efBagguSmoke.particleSystem.Clear();
		float num = 1f - 0.025f * (float)przNum;
		if (przNum == 1)
		{
			num = 2f;
		}
		Vector3 localScale = new Vector3(num, num, 1f);
		int num2 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		int num5 = 0;
		int num6 = przNum;
		if (num6 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num5 < num6)
		{
			int num7 = num5;
			num5++;
			int[] array = arrRare;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num7)] <= 2)
			{
				Transform[] array2 = arrItmLine_n;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num7)].particleSystem.startSize = 0.05f * num;
				Transform[] array3 = arrItmLineFlare_n;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num7)].particleSystem.startSize = 0.8f * num;
				Transform[] array4 = arrItmLine_n;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num7)].particleSystem.Play();
				Transform[] array5 = arrItmLineFlare_n;
				array5[RuntimeServices.NormalizeArrayIndex(array5, num7)].particleSystem.Play();
			}
			else
			{
				int[] array6 = arrRare;
				if (array6[RuntimeServices.NormalizeArrayIndex(array6, num7)] <= 4)
				{
					Transform[] array7 = arrItmLine_r;
					array7[RuntimeServices.NormalizeArrayIndex(array7, num7)].particleSystem.startSize = 0.08f * num;
					Transform[] array8 = arrItmLineFlare_r;
					array8[RuntimeServices.NormalizeArrayIndex(array8, num7)].particleSystem.startSize = 0.8f * num;
					Transform[] array9 = arrItmLine_r;
					array9[RuntimeServices.NormalizeArrayIndex(array9, num7)].particleSystem.Play();
					Transform[] array10 = arrItmLineFlare_r;
					array10[RuntimeServices.NormalizeArrayIndex(array10, num7)].particleSystem.Play();
				}
				else
				{
					Transform[] array11 = arrItmLine_sr;
					array11[RuntimeServices.NormalizeArrayIndex(array11, num7)].particleSystem.startSize = 0.1f * num;
					Transform[] array12 = arrItmLineFlare_sr;
					array12[RuntimeServices.NormalizeArrayIndex(array12, num7)].particleSystem.startSize = 1f * num;
					Transform[] array13 = arrItmLineAula_sr;
					array13[RuntimeServices.NormalizeArrayIndex(array13, num7)].particleSystem.startSize = 2f * num;
					Transform[] array14 = arrItmLine_sr;
					array14[RuntimeServices.NormalizeArrayIndex(array14, num7)].particleSystem.Play();
					Transform[] array15 = arrItmLineFlare_sr;
					array15[RuntimeServices.NormalizeArrayIndex(array15, num7)].particleSystem.Play();
					Transform[] array16 = arrItmLineAula_sr;
					array16[RuntimeServices.NormalizeArrayIndex(array16, num7)].particleSystem.Play();
				}
			}
			if (RuntimeServices.EqualityOperator(typeof(int), 0))
			{
				UISprite[][] array17 = arrPrzSprite;
				num2 = array17[RuntimeServices.NormalizeArrayIndex(array17, num7)].Length;
				UISlicedSprite[][] array18 = arrPrzSSprite;
				num3 = array18[RuntimeServices.NormalizeArrayIndex(array18, num7)].Length;
				UIDynamicFontLabel[][] array19 = arrPrzLabel;
				num4 = array19[RuntimeServices.NormalizeArrayIndex(array19, num7)].Length;
			}
			int num8 = 0;
			int num9 = num2;
			if (num9 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num8 < num9)
			{
				int index = num8;
				num8++;
				UISprite[][] array20 = arrPrzSprite;
				UISprite[] obj = array20[RuntimeServices.NormalizeArrayIndex(array20, num7)];
				obj[RuntimeServices.NormalizeArrayIndex(obj, index)].color = Color.white;
			}
			int num10 = 0;
			int num11 = num3;
			if (num11 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num10 < num11)
			{
				int index2 = num10;
				num10++;
				UISlicedSprite[][] array21 = arrPrzSSprite;
				UISlicedSprite[] obj2 = array21[RuntimeServices.NormalizeArrayIndex(array21, num7)];
				obj2[RuntimeServices.NormalizeArrayIndex(obj2, index2)].color = Color.white;
			}
			int num12 = 0;
			int num13 = num4;
			if (num13 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num12 < num13)
			{
				int index3 = num12;
				num12++;
				UIDynamicFontLabel[][] array22 = arrPrzLabel;
				UIDynamicFontLabel[] obj3 = array22[RuntimeServices.NormalizeArrayIndex(array22, num7)];
				obj3[RuntimeServices.NormalizeArrayIndex(obj3, index3)].color = Color.white;
			}
			CoverOff(num7);
			Transform[] array23 = arrPrize;
			Transform obj4 = array23[RuntimeServices.NormalizeArrayIndex(array23, num7)];
			Vector3[] array24 = arrPrzTrgPos;
			obj4.localPosition = array24[RuntimeServices.NormalizeArrayIndex(array24, num7)];
			Transform[] array25 = arrPrize;
			array25[RuntimeServices.NormalizeArrayIndex(array25, num7)].localScale = localScale;
			CamSkipDraw();
		}
		hokan_p = false;
	}

	private void Hokan_bg()
	{
		bool flag = false;
		if (!(alpha_bg >= alpTgt_bg))
		{
			alpha_bg += 0.01f;
			if (!(alpha_bg <= alpTgt_bg))
			{
				alpha_bg = alpTgt_bg;
			}
			flag = true;
		}
		else if (!(alpha_bg <= alpTgt_bg))
		{
			alpha_bg -= 0.01f;
			if (!(alpha_bg >= alpTgt_bg))
			{
				alpha_bg = alpTgt_bg;
			}
			flag = true;
		}
		if (flag)
		{
			Color color = bgMat.color;
			float num = 1f - alpha_bg;
			color = new Color(num, num, num, 0f);
			bgMat.color = color;
			if (!(alpha_bg <= 0f))
			{
				bgObj.gameObject.SetActive(value: true);
			}
			else
			{
				bgObj.gameObject.SetActive(value: false);
			}
		}
	}

	private void Hokan_f()
	{
		bool flag = false;
		if (!(alpha_f >= alpTgt_f))
		{
			alpha_f += 0.1f;
			if (!(alpha_f <= alpTgt_f))
			{
				alpha_f = alpTgt_f;
			}
			flag = true;
		}
		else if (!(alpha_f <= alpTgt_f))
		{
			alpha_f -= 0.1f;
			if (!(alpha_f >= alpTgt_f))
			{
				alpha_f = alpTgt_f;
			}
			flag = true;
		}
		if (flag)
		{
			Color color = fdMat.color;
			color.a = alpha_f;
			fdMat.color = color;
			if (!(alpha_f <= 0f))
			{
				fdObj.gameObject.SetActive(value: true);
			}
			else
			{
				fdObj.gameObject.SetActive(value: false);
			}
		}
		if (!flag)
		{
			hokan_f = false;
		}
	}

	private void PnlAlpUpdate()
	{
		int i = 0;
		UISprite[] array = uiSprites;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				float a = alpha;
				Color color = array[i].color;
				float num = (color.a = a);
				Color color3 = (array[i].color = color);
			}
			int j = 0;
			UISlicedSprite[] array2 = uiSlicSprs;
			for (int length2 = array2.Length; j < length2; j++)
			{
				float a2 = alpha;
				Color color4 = array2[j].color;
				float num2 = (color4.a = a2);
				Color color6 = (array2[j].color = color4);
			}
			int k = 0;
			UIDynamicFontLabel[] array3 = uiDFLabels;
			for (int length3 = array3.Length; k < length3; k++)
			{
				float a3 = alpha;
				Color color7 = array3[k].color;
				float num3 = (color7.a = a3);
				Color color9 = (array3[k].color = color7);
			}
		}
	}

	private void PnlAlpUpdate_s()
	{
		int i = 0;
		UISprite[] array = uiSprites_s;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				float a = alpha_s;
				Color color = array[i].color;
				float num = (color.a = a);
				Color color3 = (array[i].color = color);
			}
			int j = 0;
			UISlicedSprite[] array2 = uiSlicSprs_s;
			for (int length2 = array2.Length; j < length2; j++)
			{
				float a2 = alpha_s;
				Color color4 = array2[j].color;
				float num2 = (color4.a = a2);
				Color color6 = (array2[j].color = color4);
			}
			int k = 0;
			UIDynamicFontLabel[] array3 = uiDFLabels_s;
			for (int length3 = array3.Length; k < length3; k++)
			{
				float a3 = alpha_s;
				Color color7 = array3[k].color;
				float num3 = (color7.a = a3);
				Color color9 = (array3[k].color = color7);
			}
		}
	}

	public void LastPanelActive()
	{
		PanelActive(lastPnlName, lastWebType);
	}

	public void PanelActive(string pnlName, string webType)
	{
		webViewPanel = null;
		if ((bool)curWebView)
		{
			curWebView.gameObject.SetActive(value: false);
			curWebView = null;
		}
		WebView[] array = null;
		uiOutPnl = uiInPnl;
		lastPnlName = curPnlName;
		lastWebType = curWebType;
		curPnlName = pnlName;
		curWebType = webType;
		switch (pnlName)
		{
		case "Home":
			uiPnl_home.gameObject.SetActive(value: true);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			ButtonBackHUD.SetActive(setActive: true);
			PlayerParameter.SetActive(a: true);
			InfomationBarHUD.SetActive(a: true);
			SceneTitleHUD.SetActive(a: true);
			webViewPanel = uiPnl_home.gameObject;
			uiInPnl = uiPnl_home;
			uiPnl_home.localPosition = uiPnl_home_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "FayStone":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: true);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			fayStonePanel.SetActive(value: true);
			fayStoneEventPanel.gameObject.SetActive(value: false);
			isWebView = false;
			webViewPanel = fayStonePanel;
			uiInPnl = uiPnl_faystone;
			uiPnl_faystone.localPosition = uiPnl_faystone_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "FayStoneEvent":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: true);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			fayStonePanel.SetActive(value: false);
			fayStoneEventPanel.SetActive(value: true);
			isWebView = false;
			webViewPanel = fayStoneEventPanel;
			uiInPnl = uiPnl_faystone;
			uiPnl_faystone.localPosition = uiPnl_faystone_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "RaidPoint":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: true);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			raidPointPanel.SetActive(value: true);
			raidPointEventPanel.SetActive(value: false);
			isWebView = false;
			webViewPanel = raidPointPanel;
			uiInPnl = uiPnl_raidpoint;
			uiPnl_raidpoint.localPosition = uiPnl_raidpoint_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "RaidPointEvent":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: true);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			raidPointPanel.SetActive(value: false);
			raidPointEventPanel.SetActive(value: true);
			isWebView = false;
			webViewPanel = raidPointEventPanel;
			uiInPnl = uiPnl_raidpoint;
			uiPnl_raidpoint.localPosition = uiPnl_raidpoint_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "FriendPoint":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: true);
			uiPnl_info.gameObject.SetActive(value: false);
			friendPointPanel.SetActive(value: true);
			friendPointEventPanel.SetActive(value: false);
			isWebView = false;
			webViewPanel = friendPointPanel;
			uiInPnl = uiPnl_friendpoint;
			uiPnl_friendpoint.localPosition = uiPnl_friendpoint_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "FriendPointEvent":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: true);
			uiPnl_info.gameObject.SetActive(value: false);
			friendPointPanel.SetActive(value: false);
			friendPointEventPanel.SetActive(value: true);
			isWebView = false;
			webViewPanel = friendPointEventPanel;
			uiInPnl = uiPnl_friendpoint;
			uiPnl_friendpoint.localPosition = uiPnl_friendpoint_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "Tap":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			isWebView = false;
			uiInPnl = null;
			break;
		case "Skip":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			isWebView = false;
			uiInPnl = null;
			break;
		case "Info":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: true);
			SceneTitleHUD.SetActive(a: false);
			webViewPanel = uiPnl_info.gameObject;
			uiInPnl = uiPnl_info;
			uiPnl_info.localPosition = uiPnl_info_pos;
			array = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			break;
		case "StoneList":
			uiPnl_home.gameObject.SetActive(value: false);
			uiPnl_faystone.gameObject.SetActive(value: false);
			uiPnl_raidpoint.gameObject.SetActive(value: false);
			uiPnl_friendpoint.gameObject.SetActive(value: false);
			uiPnl_info.gameObject.SetActive(value: false);
			uiInPnl = null;
			isWebView = false;
			break;
		default:
			if (pnlName == string.Empty)
			{
				uiPnl_home.gameObject.SetActive(value: false);
				uiPnl_faystone.gameObject.SetActive(value: false);
				uiPnl_raidpoint.gameObject.SetActive(value: false);
				uiPnl_friendpoint.gameObject.SetActive(value: false);
				uiPnl_info.gameObject.SetActive(value: false);
				ButtonBackHUD.SetActive(setActive: false);
				isWebView = false;
				uiInPnl = null;
			}
			break;
		}
		uiOutPnl_pos = Vector3.zero;
		if ((bool)uiInPnl)
		{
			uiOutPnl_pos = uiInPnl.localPosition;
		}
		if (array != null && array.Length > 0)
		{
			curWebView = array[0];
		}
		if (!enableWebView)
		{
			curWebView = null;
		}
		if ((bool)curWebView)
		{
			curWebView.gameObject.SetActive(value: false);
			WebViewBase.Visible(flag: false);
			curWebView.Clear();
			StartCoroutine(WaitNextWebView());
			if (webType == "GachaMenu")
			{
				RequestGachaMenu();
			}
			else if (webType == "GachaDetail")
			{
				RequestGachaDetail();
			}
			else
			{
				RequestGachaBanner();
			}
		}
	}

	public IEnumerator WaitNextWebView()
	{
		return new _0024WaitNextWebView_002415637(this).GetEnumerator();
	}

	public void Prize()
	{
		GameSoundManager.PlaySe("se_system_lottery_kira", 0);
		uiPnl_p.localPosition = Vector3.zero;
		Vector3 vector = new Vector3(-150f, 30f, 0f);
		Vector3 vector2 = new Vector3(-1f, 0f, 0f) * (Mathf.Sin(0.15708f * (float)przNum) * 255f);
		if (przNum == 2)
		{
			vector2 *= 1.5f;
		}
		float num = 360f / (float)przNum;
		uiPnl_p.gameObject.SetActive(value: true);
		int num2 = 0;
		int num3 = 11;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			if (num4 < przNum)
			{
				int num5 = checked(przNum - num4 - 1);
				Transform[] array = arrPrize;
				array[RuntimeServices.NormalizeArrayIndex(array, num5)].gameObject.SetActive(value: true);
				Vector3 vector3 = Quaternion.Euler(new Vector3(0f, 0f, num * (float)num5)) * vector2;
				Vector3[] array2 = arrPrzTrgPos;
				ref Vector3 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num5)];
				reference = vector + vector3;
				Transform[] array3 = arrPrize;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num5)].localPosition = new Vector3(-120f, 100f, 0f);
				Transform[] array4 = arrPrize;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num5)].localScale = new Vector3(0.01f, 0.01f, 0.01f);
				CoverUp(num5);
			}
			else
			{
				Transform[] array5 = arrPrize;
				array5[RuntimeServices.NormalizeArrayIndex(array5, num4)].gameObject.SetActive(value: false);
			}
			bool[] array6 = arrPrizeHide;
			array6[RuntimeServices.NormalizeArrayIndex(array6, num4)] = true;
		}
		przTime = 0f;
		demoAnimItemIndex = 0;
	}

	public void EnablePrizeButton(bool enable)
	{
		int num = 0;
		int num2 = przNum;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform[] array = arrPrize;
			GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObject;
			if (!gameObject)
			{
				continue;
			}
			BoxCollider[] componentsInChildren = gameObject.GetComponentsInChildren<BoxCollider>(includeInactive: true);
			if (componentsInChildren == null)
			{
				continue;
			}
			int i = 0;
			BoxCollider[] array2 = componentsInChildren;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				if ((bool)array2[i])
				{
					array2[i].enabled = enable;
				}
			}
		}
	}

	public void RareRand(int num)
	{
		rare = 0;
		int num2 = 0;
		int num3 = 11;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			int num5 = UnityEngine.Random.Range(0, 100);
			if (num5 < 20 || num4 >= num)
			{
				int[] array = arrRare;
				array[RuntimeServices.NormalizeArrayIndex(array, num4)] = 1;
			}
			else if (num5 < 40)
			{
				int[] array2 = arrRare;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num4)] = 2;
			}
			else if (num5 < 70)
			{
				int[] array3 = arrRare;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num4)] = 3;
			}
			else if (num5 < 90)
			{
				int[] array4 = arrRare;
				array4[RuntimeServices.NormalizeArrayIndex(array4, num4)] = 4;
			}
			else if (num5 < 98)
			{
				int[] array5 = arrRare;
				array5[RuntimeServices.NormalizeArrayIndex(array5, num4)] = 5;
			}
			else
			{
				int[] array6 = arrRare;
				array6[RuntimeServices.NormalizeArrayIndex(array6, num4)] = 6;
			}
			int num6 = rare;
			int[] array7 = arrRare;
			if (num6 < array7[RuntimeServices.NormalizeArrayIndex(array7, num4)])
			{
				int[] array8 = arrRare;
				rare = array8[RuntimeServices.NormalizeArrayIndex(array8, num4)];
			}
		}
	}

	public void RareUpdate()
	{
		rare = 0;
		if (!testMode)
		{
			int num = 0;
			int num2 = przNum;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				Transform[] array = arrPrize;
				Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				WeaponInfo component = transform.Find("WeaponIcon").GetComponent<WeaponInfo>();
				MuppetInfo component2 = transform.Find("MapetIcon").GetComponent<MuppetInfo>();
				UserData userData = null;
				if ((bool)component && component.enabled)
				{
					RespWeapon lastWeapon = component.LastWeapon;
					if (lastWeapon == null)
					{
						continue;
					}
					int[] array2 = arrRare;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index)] = lastWeapon.Master.Rare.Id;
				}
				if ((bool)component2 && component2.enabled)
				{
					RespPoppet lastMuppet = component2.LastMuppet;
					if (lastMuppet == null)
					{
						continue;
					}
					int[] array3 = arrRare;
					array3[RuntimeServices.NormalizeArrayIndex(array3, index)] = lastMuppet.Master.Rare.Id;
				}
				int[] array4 = arrRare;
				if (array4[RuntimeServices.NormalizeArrayIndex(array4, index)] > rare)
				{
					int[] array5 = arrRare;
					rare = array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
				}
			}
			return;
		}
		int num3 = 0;
		int num4 = przNum;
		if (num4 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num3 < num4)
		{
			int num5 = num3;
			num3++;
			int[] array6 = arrRare;
			array6[RuntimeServices.NormalizeArrayIndex(array6, num5)] = Mathf.FloorToInt(UnityEngine.Random.Range(0f, (float)testRare + 0.99999f));
			if (num5 == 0)
			{
				int[] array7 = arrRare;
				array7[RuntimeServices.NormalizeArrayIndex(array7, num5)] = testRare;
			}
			int[] array8 = arrRare;
			if (array8[RuntimeServices.NormalizeArrayIndex(array8, num5)] > rare)
			{
				int[] array9 = arrRare;
				rare = array9[RuntimeServices.NormalizeArrayIndex(array9, num5)];
			}
		}
	}

	public void PrizeHide()
	{
		int num = 0;
		int num2 = 11;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Transform[] array = arrItmLine_n;
			array[RuntimeServices.NormalizeArrayIndex(array, index)].particleSystem.Stop();
			Transform[] array2 = arrItmLine_n;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index)].particleSystem.Clear();
			Transform[] array3 = arrItmLine_r;
			array3[RuntimeServices.NormalizeArrayIndex(array3, index)].particleSystem.Stop();
			Transform[] array4 = arrItmLine_r;
			array4[RuntimeServices.NormalizeArrayIndex(array4, index)].particleSystem.Clear();
			Transform[] array5 = arrItmLine_sr;
			array5[RuntimeServices.NormalizeArrayIndex(array5, index)].particleSystem.Stop();
			Transform[] array6 = arrItmLine_sr;
			array6[RuntimeServices.NormalizeArrayIndex(array6, index)].particleSystem.Clear();
			Transform[] array7 = arrItmLineFlare_n;
			array7[RuntimeServices.NormalizeArrayIndex(array7, index)].particleSystem.Stop();
			Transform[] array8 = arrItmLineFlare_n;
			array8[RuntimeServices.NormalizeArrayIndex(array8, index)].particleSystem.Clear();
			Transform[] array9 = arrItmLineFlare_r;
			array9[RuntimeServices.NormalizeArrayIndex(array9, index)].particleSystem.Stop();
			Transform[] array10 = arrItmLineFlare_r;
			array10[RuntimeServices.NormalizeArrayIndex(array10, index)].particleSystem.Clear();
			Transform[] array11 = arrItmLineFlare_sr;
			array11[RuntimeServices.NormalizeArrayIndex(array11, index)].particleSystem.Stop();
			Transform[] array12 = arrItmLineFlare_sr;
			array12[RuntimeServices.NormalizeArrayIndex(array12, index)].particleSystem.Clear();
			Transform[] array13 = arrItmLineAula_sr;
			array13[RuntimeServices.NormalizeArrayIndex(array13, index)].particleSystem.Stop();
			Transform[] array14 = arrItmLineAula_sr;
			array14[RuntimeServices.NormalizeArrayIndex(array14, index)].particleSystem.Clear();
		}
		uiPnl_p.localPosition = new Vector3(2000f, 0f, 0f);
		uiPnl_p.gameObject.SetActive(value: false);
	}

	public void CoverUp(int no)
	{
		Transform[] array = arrItmCover;
		array[RuntimeServices.NormalizeArrayIndex(array, no)].renderer.enabled = true;
		Transform[] array2 = arrNameTxt;
		array2[RuntimeServices.NormalizeArrayIndex(array2, no)].localScale = Vector3.zero;
		Transform[] array3 = arrAtkTxt;
		array3[RuntimeServices.NormalizeArrayIndex(array3, no)].localScale = Vector3.zero;
		Transform[] array4 = arrAtkNumTxt;
		array4[RuntimeServices.NormalizeArrayIndex(array4, no)].localScale = Vector3.zero;
		Transform[] array5 = arrHpTxt;
		array5[RuntimeServices.NormalizeArrayIndex(array5, no)].localScale = Vector3.zero;
		Transform[] array6 = arrHpNumTxt;
		array6[RuntimeServices.NormalizeArrayIndex(array6, no)].localScale = Vector3.zero;
	}

	public void CoverOff()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(11).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				CoverOff(num);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void CoverOff(int no)
	{
		Transform[] array = arrItmCover;
		array[RuntimeServices.NormalizeArrayIndex(array, no)].renderer.enabled = false;
		Transform[] array2 = arrItmCover_end;
		array2[RuntimeServices.NormalizeArrayIndex(array2, no)].particleSystem.Play();
		int num = default(int);
		int num2 = default(int);
		UILabel uILabel = null;
		int num3 = 1;
		Transform[] array3 = arrAtkNumTxt;
		uILabel = array3[RuntimeServices.NormalizeArrayIndex(array3, no)].GetComponent<UILabel>();
		if ((bool)uILabel)
		{
			num3 = uILabel.text.Length;
		}
		int num4 = 1;
		Transform[] array4 = arrHpNumTxt;
		uILabel = array4[RuntimeServices.NormalizeArrayIndex(array4, no)].GetComponent<UILabel>();
		if ((bool)uILabel)
		{
			num4 = uILabel.text.Length;
		}
		if (przNum == 1)
		{
			Transform[] array5 = arrNameTxt;
			array5[RuntimeServices.NormalizeArrayIndex(array5, no)].localScale = new Vector3(1f, 1f, 1f);
		}
		checked
		{
			if (przNum == 1 || num3 + num4 <= 7)
			{
				num = -144 + (14 - num3 - num4) * 8;
				num2 = num + 170 - (7 - num3) * 16;
				Transform[] array6 = arrAtkTxt;
				array6[RuntimeServices.NormalizeArrayIndex(array6, no)].localPosition = new Vector3(num, -90f, -30f);
				Transform[] array7 = arrAtkNumTxt;
				array7[RuntimeServices.NormalizeArrayIndex(array7, no)].localPosition = new Vector3(num + 24, -90f, -30f);
				Transform[] array8 = arrHpTxt;
				array8[RuntimeServices.NormalizeArrayIndex(array8, no)].localPosition = new Vector3(num2, -90f, -30f);
				Transform[] array9 = arrHpNumTxt;
				array9[RuntimeServices.NormalizeArrayIndex(array9, no)].localPosition = new Vector3(num2 + 20, -90f, -30f);
			}
			else
			{
				num = ((num3 <= num4) ? (24 - num4 * 8) : (24 - num3 * 8));
				num2 = num + 10;
				Transform[] array10 = arrAtkTxt;
				array10[RuntimeServices.NormalizeArrayIndex(array10, no)].localPosition = new Vector3(num - 24, -90f, -30f);
				Transform[] array11 = arrAtkNumTxt;
				array11[RuntimeServices.NormalizeArrayIndex(array11, no)].localPosition = new Vector3(num, -90f, -30f);
				Transform[] array12 = arrHpTxt;
				array12[RuntimeServices.NormalizeArrayIndex(array12, no)].localPosition = new Vector3(num - 20, -120f, -30f);
				Transform[] array13 = arrHpNumTxt;
				array13[RuntimeServices.NormalizeArrayIndex(array13, no)].localPosition = new Vector3(num, -120f, -30f);
			}
			Transform[] array14 = arrAtkTxt;
			array14[RuntimeServices.NormalizeArrayIndex(array14, no)].localScale = new Vector3(48f, 24f, 1f);
			Transform[] array15 = arrAtkNumTxt;
			array15[RuntimeServices.NormalizeArrayIndex(array15, no)].localScale = new Vector3(16f, 18f, 1f);
			Transform[] array16 = arrHpTxt;
			array16[RuntimeServices.NormalizeArrayIndex(array16, no)].localScale = new Vector3(40f, 24f, 1f);
			Transform[] array17 = arrHpNumTxt;
			array17[RuntimeServices.NormalizeArrayIndex(array17, no)].localScale = new Vector3(16f, 18f, 1f);
		}
	}

	public void ChangeBagTexture(int id)
	{
		if (bagTexture.ContainsKey(id) && (bool)bagTexture[id])
		{
			Material[] materials = bagObj.renderer.materials;
			materials[RuntimeServices.NormalizeArrayIndex(materials, bagMaterialIndex)].mainTexture = bagTexture[id];
			bagObj.renderer.materials = materials;
			efBagguSmoke.particleSystem.Play();
		}
	}

	public void RestoreBagTexture(int id)
	{
		if (bagTexture.ContainsKey(id) && null != bagTexture[id])
		{
			Material[] materials = bagObj.renderer.materials;
			materials[RuntimeServices.NormalizeArrayIndex(materials, bagMaterialIndex)].mainTexture = bagTextureDictionary_back;
			bagObj.renderer.materials = materials;
			efBagguSmoke.particleSystem.Play();
		}
	}

	public void ChangeFpBannerTexture(int id)
	{
		if (fpBannerTexture.ContainsKey(id) && null != fpBannerTexture[id])
		{
			friendPointBannner.renderer.material.mainTexture = fpBannerTexture[id];
			friendPointBannner.renderer.enabled = true;
			friendPointBannnerSprite.enabled = false;
		}
	}

	public void RestoreFpBannerTexture(int id)
	{
		if (fpBannerTexture.ContainsKey(id) && null != fpBannerTexture[id])
		{
			friendPointBannnerSprite.enabled = true;
			friendPointBannner.renderer.enabled = false;
		}
	}

	public void TapDisplay()
	{
		uiPnl_tap.gameObject.SetActive(value: true);
	}

	public void TapHide()
	{
		uiPnl_tap.gameObject.SetActive(value: false);
	}

	public void SkipDisplay()
	{
		uiPnl_skp.gameObject.SetActive(value: true);
		skip = false;
		enableSkip = true;
	}

	public void SkipHide()
	{
		uiPnl_skp.gameObject.SetActive(value: false);
		skip = false;
		enableSkip = false;
	}

	public void Black()
	{
		alpTgt_bg = 0.4f;
	}

	public void BlackHalf()
	{
		alpTgt_bg = 0.2f;
	}

	public void BlackOff()
	{
		alpTgt_bg = 0f;
	}

	public void Fade()
	{
		fdMat.color = Color.black;
		alpTgt_f = 1f;
	}

	public void FadeOff()
	{
		alpTgt_f = 0f;
	}

	public void White()
	{
		fdMat.color = Color.white;
		alpTgt_f = 1f;
	}

	public void WhiteOff()
	{
		alpTgt_f = 0f;
	}

	public void NikiSelif(string msg, float x, float y, float rot)
	{
		uiDFLabels_s[0].text = msg;
		uiPnl_selif.localPosition = new Vector3(x, y, 1f);
		uiPnl_selif.localRotation = Quaternion.Euler(0f, 0f, rot);
	}

	public void NikiIdle()
	{
		nikiAnim.CrossFade(anmIdle, 0.8f);
	}

	public void NikiSeek()
	{
		nikiAnim.Fade2Next(anmSeek_s, anmSeek, 0.4f);
	}

	public void NikiSeekLight()
	{
		if (rare >= 5)
		{
			efHndBugLit.particleSystem.emissionRate = 10f;
			efHndBugLit.particleSystem.Play();
		}
	}

	public void NikiHand()
	{
		nikiAnim.Fade2Next(anmHand_s, anmHand, 0.4f);
		if (rare <= 2)
		{
			efHndFlare_n.particleSystem.Play();
			efRareRing_n.particleSystem.Play();
			efDrwFlare.particleSystem.Play();
			nikiAnim.Speed(anmHand_s, 1f);
		}
		else if (rare <= 4)
		{
			efHndFlare_r.particleSystem.Play();
			efRareRing_r.particleSystem.Play();
			efDrwFlare.particleSystem.Play();
			nikiAnim.Speed(anmHand_s, 1f);
		}
		else
		{
			efHndFlare_sr.particleSystem.Play();
			efRareRing_sr.particleSystem.Play();
			efRareCircle_sr.GetComponent<Ef_QuickAnimTransform>().Play();
			efDrwFlare_sr.particleSystem.Play();
			efHndBugLit.particleSystem.emissionRate = 0f;
			nikiAnim.Speed(anmHand_s, 0.5f);
		}
	}

	public void NikiHandPause()
	{
		nikiAnim.Anim(anmHand_s).speed = 0f;
		if (rare == 0)
		{
			efHndFlare_n.particleSystem.Pause();
			efRareRing_n.particleSystem.Pause();
			efDrwFlare.particleSystem.Pause();
		}
		else if (rare == 1)
		{
			efHndFlare_r.particleSystem.Pause();
			efRareRing_r.particleSystem.Pause();
			efDrwFlare.particleSystem.Pause();
		}
		else
		{
			efHndFlare_sr.particleSystem.Pause();
			efRareRing_sr.particleSystem.Pause();
			efDrwFlare_sr.particleSystem.Pause();
		}
	}

	public void NikiHandPlay()
	{
		nikiAnim.Anim(anmHand_s).speed = 1f;
		if (rare == 0)
		{
			efHndFlare_n.particleSystem.Play();
			efRareRing_n.particleSystem.Play();
			efDrwFlare.particleSystem.Play();
		}
		else if (rare == 1)
		{
			efHndFlare_r.particleSystem.Play();
			efRareRing_r.particleSystem.Play();
			efDrwFlare.particleSystem.Play();
		}
		else
		{
			efHndFlare_sr.particleSystem.Play();
			efRareRing_sr.particleSystem.Play();
			efDrwFlare_sr.particleSystem.Play();
		}
	}

	public void NikiWin()
	{
		nikiAnim.Fade2Next(anmWin, anmWin_l, 0.2f);
	}

	public void NikiLose()
	{
		nikiAnim.Fade2Next(anmLose, anmLose_l, 0.2f);
	}

	public void NikiLuck()
	{
		nikiAnim.Fade2Next(anmLuck, anmLuck_l, 0.2f);
	}

	public void NikiWalk()
	{
		nikiAnim.CrossFade(anmWalk, 0.4f);
	}

	public void NikiHandSkip()
	{
		nikiAnim.Anim(anmHand_s).time = 1.3f;
		camAnim.Anim(anmCamDraw).time = 1.3f;
		efHndFlare_n.particleSystem.Stop();
		efHndFlare_n.particleSystem.Clear();
		efDrwFlare.particleSystem.Stop();
		efDrwFlare.particleSystem.Clear();
		efHndFlare_r.particleSystem.Stop();
		efHndFlare_r.particleSystem.Clear();
		efHndFlare_sr.particleSystem.Stop();
		efHndFlare_sr.particleSystem.Clear();
		efDrwFlare_sr.particleSystem.Stop();
		efDrwFlare_sr.particleSystem.Clear();
		efHndBugLit.particleSystem.emissionRate = 0f;
	}

	public void Hanabi()
	{
		efHanabi.particleSystem.loop = true;
		efHanabi.particleSystem.Play();
		efHanabi2.particleSystem.loop = true;
		efHanabi2.particleSystem.Play();
		efHanabi3.particleSystem.loop = true;
		efHanabi3.particleSystem.Play();
		efHanabi4.particleSystem.loop = true;
		efHanabi4.particleSystem.Play();
		efHanabi5.GetComponent<Ef_ParticleEmit>().pause = false;
		IEnumerator enumerator = HanabiSoundsPlay(efHanabi2);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		IEnumerator enumerator2 = HanabiSoundsPlay(efHanabi3);
		if (enumerator2 != null)
		{
			StartCoroutine(enumerator2);
		}
		IEnumerator enumerator3 = HanabiSoundsPlay(efHanabi4);
		if (enumerator3 != null)
		{
			StartCoroutine(enumerator3);
		}
	}

	public void HanabiOff()
	{
		efHanabi.particleSystem.loop = false;
		efHanabi2.particleSystem.loop = false;
		efHanabi3.particleSystem.loop = false;
		efHanabi4.particleSystem.loop = false;
		efHanabi5.GetComponent<Ef_ParticleEmit>().pause = true;
		IEnumerator enumerator = HanabiSoundsStop();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	private IEnumerator HanabiSoundsPlay(Transform h)
	{
		return new _0024HanabiSoundsPlay_002415640(h, this).GetEnumerator();
	}

	private IEnumerator HanabiSoundsStop()
	{
		StopCoroutine("HanabiSounds");
		return null;
	}

	private IEnumerator HanabiSounds(Transform h)
	{
		return new _0024HanabiSounds_002415645(h).GetEnumerator();
	}

	public void CamStart()
	{
		camAnim.Fade2Next(anmCamHome_s, anmCamHome, 0f);
	}

	public void CamHome()
	{
		if (!camAnim.IsPlaying(anmCamHome_s) && !camAnim.IsPlaying(anmCamHome) && !camAnim.IsPlaying(anmCamDraw_e))
		{
			camAnim.CrossFade(anmCamHome, 1f);
		}
	}

	public void CamSeek()
	{
		camAnim.Fade2Next(anmCamSeek, anmCamSeek_l, 0.5f);
	}

	public void CamDraw()
	{
		if (rare <= 4)
		{
			camAnim.Speed(anmCamDraw, 1f);
		}
		else
		{
			camAnim.Speed(anmCamDraw, 0.5f);
		}
		camAnim.Fade2Next(anmCamDraw, anmCamDraw_l, 0.5f);
	}

	public void CamSkipDraw()
	{
		camAnim.Play(anmCamDraw_l);
	}

	public void CamDraw_e()
	{
		camAnim.Fade2Next(anmCamDraw_e, anmCamHome, 0.5f);
	}

	public virtual void EndLottery()
	{
	}

	public void FayStone()
	{
		message = "FayStone";
	}

	public void RaidPoint()
	{
		message = "RaidPoint";
	}

	public void FriendPoint()
	{
		message = "FriendPoint";
	}

	public void FayStoneEvent()
	{
		message = "FayStoneEvent";
	}

	public void RaidPointEvent()
	{
		message = "RaidPointEvent";
	}

	public void FriendPointEvent()
	{
		message = "FriendPointEvent";
	}

	public void Info()
	{
		message = "Info";
	}

	public virtual void PushBack()
	{
		message = "PushBack";
		HideDetail();
	}

	public void Back()
	{
		message = "Back";
		HideDetail();
	}

	public void Single()
	{
		message = "Single";
	}

	public void Multi()
	{
		message = "Multi";
	}

	public void Tap()
	{
		message = "Tap";
	}

	public void Skip()
	{
		if (enableSkip)
		{
			message = "Skip";
			enableSkip = false;
			skip = true;
		}
	}

	public void Prize01()
	{
		Log("Message : Prize01");
		message = "Prize01";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(0);
	}

	public void Prize02()
	{
		Log("Message : Prize02");
		message = "Prize02";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(1);
	}

	public void Prize03()
	{
		Log("Message : Prize03");
		message = "Prize03";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(2);
	}

	public void Prize04()
	{
		Log("Message : Prize04");
		message = "Prize04";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(3);
	}

	public void Prize05()
	{
		Log("Message : Prize05");
		message = "Prize05";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(4);
	}

	public void Prize06()
	{
		Log("Message : Prize06");
		message = "Prize06";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(5);
	}

	public void Prize07()
	{
		Log("Message : Prize07");
		message = "Prize07";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(6);
	}

	public void Prize08()
	{
		Log("Message : Prize08");
		message = "Prize08";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(7);
	}

	public void Prize09()
	{
		Log("Message : Prize09");
		message = "Prize09";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(8);
	}

	public void Prize10()
	{
		Log("Message : Prize10");
		message = "Prize10";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(9);
	}

	public void Prize11()
	{
		Log("Message : Prize11");
		message = "Prize11";
		uiPnl_p.gameObject.SetActive(value: false);
		ShowDetail(10);
	}

	public void Close()
	{
		uiPnl_p.gameObject.SetActive(value: true);
	}

	public void GachaWebError()
	{
		WebViewBase.EndWebView();
		Dialog dialog = DialogManager.Open("データが取得できませんでした。", "通信エラー");
		dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			EndLottery();
		};
	}

	public void RequestGachaMenu()
	{
		ApiGacha apiGacha = new ApiGacha();
		apiGacha.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(GachaWebError);
		MerlinServer.Request(apiGacha, CallBackGachaWeb);
	}

	public void RequestGachaDetail()
	{
		if (curGacha == null)
		{
			GachaWebError();
			return;
		}
		ApiGachaDetails apiGachaDetails = new ApiGachaDetails();
		apiGachaDetails.SaleGachaId = curGacha.Id;
		apiGachaDetails.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(GachaWebError);
		MerlinServer.Request(apiGachaDetails, CallBackGachaWeb);
	}

	public void RequestGachaBanner()
	{
		if (curGacha == null)
		{
			GachaWebError();
			return;
		}
		ApiWebGachaDirecting apiWebGachaDirecting = new ApiWebGachaDirecting(curGacha.Id);
		apiWebGachaDirecting.ErrorHandler = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(GachaWebError);
		MerlinServer.Request(apiWebGachaDirecting, CallBackGachaWeb);
	}

	public void CallBackGachaWeb(RequestBase req)
	{
		if (req == null)
		{
			throw new AssertionFailedException(new StringBuilder("req=").Append(req.GetType()).ToString());
		}
		if (!curWebView)
		{
			if (!webViewPanel)
			{
				return;
			}
			WebView[] componentsInChildren = webViewPanel.GetComponentsInChildren<WebView>(includeInactive: true);
			if (componentsInChildren == null)
			{
				return;
			}
			if (componentsInChildren.Length > 0)
			{
				curWebView = componentsInChildren[0];
			}
		}
		if ((bool)curWebView)
		{
			curWebView.Clear();
			lastUrl = string.Empty;
			curWebView.OpenHtml(req.Result, ServerURL.GameServerUrl("/"));
		}
	}

	public bool CallBackLottery2(ApiGachaExec req)
	{
		if (req == null)
		{
			throw new AssertionFailedException(new StringBuilder("req=").Append(req.GetType()).ToString());
		}
		ApiGachaExec.Resp response = req.GetResponse();
		if (response == null)
		{
			throw new AssertionFailedException("r != null");
		}
		endSendLottery = true;
		BoxId[] boxIdList = response.BoxIdList;
		WeaponInfo weaponInfo = null;
		MuppetInfo muppetInfo = null;
		IEnumerator enumerator = arrPrize.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			weaponInfo = transform.Find("WeaponIcon").GetComponent<WeaponInfo>();
			if ((bool)weaponInfo)
			{
				weaponInfo.SetWeapon(null);
				weaponInfo.enabled = false;
				weaponInfo.gameObject.SetActive(value: false);
			}
			muppetInfo = transform.Find("MapetIcon").GetComponent<MuppetInfo>();
			if ((bool)muppetInfo)
			{
				muppetInfo.SetMuppet(null);
				muppetInfo.enabled = false;
				muppetInfo.gameObject.SetActive(value: false);
			}
		}
		UserData current = UserData.Current;
		int num = 0;
		string[] array = new string[0];
		int i = 0;
		BoxId[] array2 = boxIdList;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (num >= arrPrize.Length)
				{
					continue;
				}
				Transform[] array3 = arrPrize;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)] == null)
				{
					continue;
				}
				Transform[] array4 = arrPrize;
				Transform transform2 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
				RespWeapon respWeapon = current.boxWeapon(array2[i]);
				RespPoppet respPoppet = current.boxPoppet(array2[i]);
				weaponInfo = transform2.Find("WeaponIcon").GetComponent<WeaponInfo>();
				MuppetInfo component = transform2.Find("MapetIcon").GetComponent<MuppetInfo>();
				if (respWeapon != null && weaponInfo != null)
				{
					if (!current.userMiscInfo.weaponBookData.isHave(respWeapon.Master))
					{
						weaponInfo.ForceUnknown = true;
					}
					weaponInfo.SetWeapon(respWeapon);
					weaponInfo.enabled = true;
					weaponInfo.gameObject.SetActive(value: true);
					array = (string[])RuntimeServices.AddArrays(typeof(string), array, new string[1] { respWeapon.Icon });
					num++;
				}
				else if (respPoppet != null && component != null)
				{
					if (!current.userMiscInfo.poppetBookData.isHave(respPoppet.Master))
					{
						component.ForceUnknown = true;
					}
					component.SetMuppet(respPoppet);
					component.enabled = true;
					component.gameObject.SetActive(value: true);
					array = (string[])RuntimeServices.AddArrays(typeof(string), array, new string[1] { respPoppet.Icon });
					num++;
				}
			}
			IconAtlasPool.PreLoadAtlasesOfSprites(array);
			return true;
		}
	}

	public bool CheckLotteryResult()
	{
		return endSendLottery;
	}

	public void ShowDetail(int indexPrz)
	{
		if (hokan_p || alpha_f == 1f || demoAnimItemIndex > 0)
		{
			return;
		}
		uiPnl_d.localPosition = Vector3.zero;
		Transform[] array = arrPrize;
		Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, indexPrz)];
		WeaponInfo component = transform.Find("WeaponIcon").GetComponent<WeaponInfo>();
		MuppetInfo component2 = transform.Find("MapetIcon").GetComponent<MuppetInfo>();
		object obj = null;
		object obj2 = null;
		if ((bool)component && component.enabled)
		{
			obj = component.LastWeapon;
		}
		if ((bool)component2 && component2.enabled)
		{
			obj2 = component2.LastMuppet;
		}
		if (RuntimeServices.ToBool(obj))
		{
			obj2 = null;
		}
		if (RuntimeServices.ToBool(obj2))
		{
			obj = null;
		}
		WeaponInfo component3 = arrDetail[0].GetComponent<WeaponInfo>();
		MuppetInfo component4 = arrDetail[1].GetComponent<MuppetInfo>();
		detailPanel = null;
		if ((bool)component3)
		{
			component3.gameObject.SetActive(obj != null);
			object obj3 = obj;
			if (!(obj3 is RespWeapon))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(RespWeapon));
			}
			component3.SetWeapon((RespWeapon)obj3);
			if (obj != null)
			{
				UIAutoTweenerStandAloneEx.In(component3.gameObject);
				detailPanel = component3.gameObject;
			}
		}
		if ((bool)component4)
		{
			component4.gameObject.SetActive(obj2 != null);
			object obj4 = obj2;
			if (!(obj4 is RespPoppet))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(RespPoppet));
			}
			component4.SetMuppet((RespPoppet)obj4);
			if (obj2 != null)
			{
				UIAutoTweenerStandAloneEx.In(component4.gameObject);
				detailPanel = component4.gameObject;
			}
		}
	}

	public void HideDetail()
	{
		if ((bool)detailPanel)
		{
			UIAutoTweenerStandAloneEx.Out(detailPanel, HideDetailEnd);
		}
		detailPanel = null;
	}

	public void HideDetailEnd(GameObject obj)
	{
		uiPnl_p.gameObject.SetActive(value: true);
	}

	protected void ShowHUD(bool show)
	{
		ButtonBackHUD.SetActive(show);
		PlayerParameter.SetActive(show);
		InfomationBarHUD.SetActive(show);
		SceneTitleHUD.SetActive(show);
	}

	protected void PlaySeByRarity()
	{
		StopSE();
		if (rare <= 2)
		{
			PlayJingle("Card_Get_Normal", resumeBgm: true);
		}
		else if (rare <= 4)
		{
			PlayJingle("Card_Get_Rare", resumeBgm: true);
		}
		else if (rare <= 6)
		{
			PlayJingle("Card_Get_SRare", resumeBgm: true);
		}
		else if (rare > 6)
		{
			PlayJingle("Card_Get_URare", resumeBgm: true);
		}
	}

	public void LoadResource(string file, __LotteryBase_LoadResource_0024callable41_00241986_51__ callback)
	{
		_0024LoadResource_0024locals_002414328 _0024LoadResource_0024locals_0024 = new _0024LoadResource_0024locals_002414328();
		_0024LoadResource_0024locals_0024._0024file = file;
		_0024LoadResource_0024locals_0024._0024callback = callback;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024LoadResource_0024closure_00242947(_0024LoadResource_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void PushSkipDemo(GameObject obj)
	{
		if (demoAnim != null)
		{
			Gousei3D component = demoAnim.GetComponent<Gousei3D>();
			if (component != null)
			{
				component.skip = true;
			}
		}
		PushEndDemo(null);
	}

	public void PushEndDemo(GameObject obj)
	{
		bool flag = false;
		if (demoAnim != null)
		{
			UnityEngine.Object.DestroyObject(demoAnim);
		}
		demoAnim = null;
		uiPnl_p.gameObject.SetActive(value: true);
	}

	public bool GetNewItemDemo(int index)
	{
		Transform[] array = arrPrize;
		Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, index)];
		WeaponInfo weaponInfo = transform.GetComponentsInChildren<WeaponInfo>(includeInactive: true).FirstOrDefault();
		weaponInfo.DestroyLevel();
		MuppetInfo muppetInfo = transform.GetComponentsInChildren<MuppetInfo>(includeInactive: true).FirstOrDefault();
		muppetInfo.DestroyLevel();
		object obj = null;
		object obj2 = null;
		if ((bool)weaponInfo && weaponInfo.enabled)
		{
			obj = weaponInfo.LastWeapon;
			object obj3 = obj;
			if (!(obj3 is RespWeapon))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(RespWeapon));
			}
			weaponInfo.SetWeapon((RespWeapon)obj3);
		}
		if ((bool)muppetInfo && muppetInfo.enabled)
		{
			obj2 = muppetInfo.LastMuppet;
			object obj4 = obj2;
			if (!(obj4 is RespPoppet))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(RespPoppet));
			}
			muppetInfo.SetMuppet((RespPoppet)obj4);
		}
		object obj5 = obj;
		if (!(obj5 is RespWeapon))
		{
			obj5 = RuntimeServices.Coerce(obj5, typeof(RespWeapon));
		}
		RespWeapon respWep = (RespWeapon)obj5;
		object obj6 = obj2;
		if (!(obj6 is RespPoppet))
		{
			obj6 = RuntimeServices.Coerce(obj6, typeof(RespPoppet));
		}
		return GetNewItemDemoCore(respWep, (RespPoppet)obj6);
	}

	public bool GetNewItemDemoCore(RespWeapon respWep, RespPoppet respPet)
	{
		enableSkip = true;
		bool flag = false;
		int result;
		if (!testMode)
		{
			UserData current = UserData.Current;
			if (current != null)
			{
				if (respWep != null)
				{
					if (lastWeaponPicBookFlags != null && respWep.Master != null)
					{
						if (lastWeaponPicBookFlags.ContainsKey(respWep.Master.Id.ToString()))
						{
							flag = RuntimeServices.UnboxInt32(lastWeaponPicBookFlags[respWep.Master.Id.ToString()]) > 0;
						}
						if (respWep.Master.Rare.Id >= 5)
						{
							enableSkip = false;
						}
					}
				}
				else
				{
					if (respPet == null)
					{
						result = 0;
						goto IL_0438;
					}
					if (lastPoppetPicBookFlags != null && respPet.Master != null)
					{
						if (lastPoppetPicBookFlags.ContainsKey(respPet.Master.Id.ToString()))
						{
							flag = RuntimeServices.UnboxInt32(lastPoppetPicBookFlags[respPet.Master.Id.ToString()]) > 0;
						}
						if (respPet.Master.Rare.Id >= 5)
						{
							enableSkip = false;
						}
					}
				}
				goto IL_019c;
			}
			result = 0;
		}
		else
		{
			if (testHaves.Length >= demoAnimItemIndex)
			{
				bool[] array = testHaves;
				flag = array[RuntimeServices.NormalizeArrayIndex(array, checked(testHaves.Length - demoAnimItemIndex))];
			}
			if (!flag)
			{
				goto IL_019c;
			}
			result = 0;
		}
		goto IL_0438;
		IL_0438:
		return (byte)result != 0;
		IL_019c:
		checked
		{
			if (flag && gachaMode != 0 && gachaMode != 3 && przNum > 1)
			{
				result = 0;
			}
			else
			{
				if ((bool)demoAnim)
				{
					UnityEngine.Object.DestroyObject(demoAnim);
				}
				demoAnim = null;
				if ((bool)demoAnimPrefab)
				{
					demoAnim = (GameObject)UnityEngine.Object.Instantiate(demoAnimPrefab);
				}
				demoAnim.SetActive(value: false);
				Gousei3D component = demoAnim.GetComponent<Gousei3D>();
				if (respWep != null)
				{
					component.mode = Gousei3D.Mode.WeaponGet;
					component.atkValue = (int)respWep.TotalAttack;
					component.hpValue = (int)respWep.TotalHP;
					component.targetWeapon = respWep;
					component.baseWeapon = null;
					component.rare = respWep.Master.Rare.Id;
					component.traitSpriteName = respWep.TraitSpriteName;
					int num = 0;
					int length = component.materialWeapon.Length;
					if (length < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num < length)
					{
						int index = num;
						num = unchecked(num + 1);
						RespWeapon[] materialWeapon = component.materialWeapon;
						materialWeapon[RuntimeServices.NormalizeArrayIndex(materialWeapon, index)] = null;
					}
				}
				else if (respPet != null)
				{
					component.mode = Gousei3D.Mode.PoppetGet;
					component.atkValue = (int)respPet.TotalAttack;
					component.hpValue = (int)respPet.TotalHP;
					component.targetPoppet = respPet;
					component.basePoppet = null;
					component.rare = respPet.Master.Rare.Id;
					component.traitSpriteName = respPet.TraitSpriteName;
					int num2 = 0;
					int length2 = component.materialPoppet.Length;
					if (length2 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num2 < length2)
					{
						int index2 = num2;
						num2 = unchecked(num2 + 1);
						RespPoppet[] materialPoppet = component.materialPoppet;
						materialPoppet[RuntimeServices.NormalizeArrayIndex(materialPoppet, index2)] = null;
					}
				}
				else if (testMode)
				{
					component.testMode = true;
					component.mode = Gousei3D.Mode.WeaponGet;
					if (testHaves.Length >= demoAnimItemIndex)
					{
						int[] array2 = arrRare;
						component.testRare = array2[RuntimeServices.NormalizeArrayIndex(array2, testHaves.Length - demoAnimItemIndex)];
					}
				}
				if (!testMode)
				{
					component.testMode = false;
				}
				component.seiko = 0;
				component.IsLevelUp = false;
				component.IsSkillUp = false;
				component.IsLimitOver = false;
				component.elevatedLevel = 0;
				component.endFuncObject = gameObject;
				component.endFunction = "PushEndDemo";
				demoAnim.SetActive(value: true);
				bool flag2 = true;
				uiPnl_p.gameObject.SetActive(value: false);
				result = 1;
			}
			goto IL_0438;
		}
	}

	public float ScreenAspect()
	{
		return 1f * (float)Screen.width / (float)Screen.height;
	}

	internal void _0024Awake_0024closure_00242937()
	{
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			isWaitInitialize = false;
		});
		if (testMode)
		{
			testBG.SetActive(value: true);
		}
		townModule.CallbackStartCore = null;
	}

	internal void _0024_0024Awake_0024closure_00242937_0024closure_00242938()
	{
		isWaitInitialize = false;
	}

	internal UISprite[] _0024Init_0024closure_00242939(Transform _0024genarray_0024691)
	{
		return _0024genarray_0024691.GetComponentsInChildren<UISprite>();
	}

	internal UISlicedSprite[] _0024Init_0024closure_00242940(Transform _0024genarray_0024692)
	{
		return _0024genarray_0024692.GetComponentsInChildren<UISlicedSprite>();
	}

	internal UIDynamicFontLabel[] _0024Init_0024closure_00242941(Transform _0024genarray_0024693)
	{
		return _0024genarray_0024693.GetComponentsInChildren<UIDynamicFontLabel>();
	}

	internal void _0024GachaWebError_0024closure_00242946()
	{
		EndLottery();
	}
}
