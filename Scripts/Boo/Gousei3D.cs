using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class Gousei3D : MonoBehaviour
{
	[Serializable]
	public enum Mode
	{
		Weapon,
		Poppet,
		WeaponEvolution,
		PoppetEvolution,
		WeaponGet,
		PoppetGet
	}

	[Serializable]
	private class CompositionSound
	{
		[NonSerialized]
		public const string roll = "se_system_composition";

		[NonSerialized]
		public const string win_0 = "se_system_composition_s";

		[NonSerialized]
		public const string win_1 = "se_system_composition_m";

		[NonSerialized]
		public const string win_2 = "se_system_composition_l";

		[NonSerialized]
		public const string win_3 = "se_system_composition_l";

		[NonSerialized]
		public const string jingle = "se_system_composition2";
	}

	[Serializable]
	private class EvolutionSound
	{
		[NonSerialized]
		public const string roll = "se_system_composition";

		[NonSerialized]
		public const string win_0 = "se_system_evolution1";

		[NonSerialized]
		public const string win_1 = "se_system_evolution1";

		[NonSerialized]
		public const string win_2 = "se_system_evolution2";

		[NonSerialized]
		public const string win_3 = "se_system_evolution2";
	}

	[Serializable]
	private class AcquireSound
	{
		[NonSerialized]
		public const string win_0 = "se_system_new_item";

		[NonSerialized]
		public const string win_1 = "se_system_new_item";

		[NonSerialized]
		public const string win_2 = "se_system_new_item2";

		[NonSerialized]
		public const string win_3 = "se_system_new_item2";
	}

	[Serializable]
	private class JingleSound
	{
		[NonSerialized]
		public const string win_0 = "Card_Get_Normal";

		[NonSerialized]
		public const string win_1 = "Card_Get_Rare";

		[NonSerialized]
		public const string win_2 = "Card_Get_SRare";

		[NonSerialized]
		public const string win_3 = "Card_Get_URare";
	}

	[Serializable]
	private class LevelUpSound
	{
		[NonSerialized]
		public const string elevate = "se_system_exp_countup";

		[NonSerialized]
		public const string levelup = "se_system_levelup";

		[NonSerialized]
		public const string skillLevelup = "se_system_skill_levelup";

		[NonSerialized]
		public const string limitbreak = "se_system_limit_break";

		[NonSerialized]
		public const float countInterval = 0.033f;
	}

	[Serializable]
	internal class _0024PutWeapon_0024locals_002414326
	{
		internal string _0024path;
	}

	[Serializable]
	internal class _0024TraitIcon_0024locals_002414327
	{
		internal TweenAlpha _0024tweenA;
	}

	[Serializable]
	internal class _0024PutWeapon_0024closure_00242949
	{
		internal Gousei3D _0024this_002414754;

		internal Vector3 _0024_002412306_002414755;

		internal float _0024_002412305_002414756;

		internal _0024PutWeapon_0024locals_002414326 _0024_0024locals_002414757;

		public _0024PutWeapon_0024closure_00242949(Gousei3D _0024this_002414754, Vector3 _0024_002412306_002414755, float _0024_002412305_002414756, _0024PutWeapon_0024locals_002414326 _0024_0024locals_002414757)
		{
			this._0024this_002414754 = _0024this_002414754;
			this._0024_002412306_002414755 = _0024_002412306_002414755;
			this._0024_002412305_002414756 = _0024_002412305_002414756;
			this._0024_0024locals_002414757 = _0024_0024locals_002414757;
		}

		public void Invoke(GameObject go)
		{
			_0024this_002414754.curModel = go;
			if (_0024this_002414754.curModel == null)
			{
				return;
			}
			int length = _0024_0024locals_002414757._0024path.Length;
			if (length < 11)
			{
				return;
			}
			checked
			{
				if (_0024_0024locals_002414757._0024path.Substring(length - 2, 2) == "_r")
				{
					RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024_0024locals_002414757._0024path.Substring(0, length - 2) + "_l", delegate(GameObject go2)
					{
						if ((bool)go2)
						{
							go2.transform.parent = _0024this_002414754.curModel.transform;
							go2.transform.localPosition = new Vector3(0f, 0.4f, -0.6f);
							go2.transform.localRotation = Quaternion.Euler(300f, 300f, 50f);
							if (_0024this_002414754.gameObject != null)
							{
								NGUITools.SetLayer(go2, _0024this_002414754.gameObject.layer);
							}
						}
					});
				}
				else if (_0024_0024locals_002414757._0024path.Substring(length - 2, 2) == "_l")
				{
					RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024_0024locals_002414757._0024path.Substring(0, length - 2) + "_r", delegate(GameObject go3)
					{
						if ((bool)go3)
						{
							_0024this_002414754.curModel.transform.localRotation = Quaternion.Euler(120f, 300f, 50f);
							go3.transform.parent = _0024this_002414754.curModel.transform;
							go3.transform.localPosition = new Vector3(0f, -0.4f, 0.6f);
							go3.transform.localRotation = Quaternion.Euler(0f, 270f, 270f);
							if (_0024this_002414754.gameObject != null)
							{
								NGUITools.SetLayer(go3, _0024this_002414754.gameObject.layer);
							}
						}
					});
				}
				bool flag = false;
				if (_0024_0024locals_002414757._0024path.Substring(length - 10, 2) == "01")
				{
					flag = true;
					RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024_0024locals_002414757._0024path.Substring(0, length - 11) + "W02_0000_00", delegate(GameObject go4)
					{
						if ((bool)go4)
						{
							go4.transform.parent = _0024this_002414754.curModel.transform;
							go4.transform.localPosition = new Vector3(0.5f, 0.4f, 0f);
							go4.transform.localRotation = Quaternion.Euler(320f, 240f, 130f);
							if (_0024this_002414754.gameObject != null)
							{
								NGUITools.SetLayer(go4, _0024this_002414754.gameObject.layer);
							}
						}
					});
				}
				if (_0024this_002414754.gameObject != null)
				{
					NGUITools.SetLayer(_0024this_002414754.curModel, _0024this_002414754.gameObject.layer);
				}
				_0024this_002414754.curModel.transform.parent = _0024this_002414754.wpnObj;
				if (!flag)
				{
					_0024this_002414754.curModel.transform.localRotation = Quaternion.Euler(-150f, 0f, 0f);
				}
				else
				{
					_0024this_002414754.curModel.transform.localRotation = Quaternion.Euler(30f, 0f, 0f);
				}
				Transform transform = _0024this_002414754.curModel.transform.Find("Bounds");
				if ((bool)transform)
				{
					Vector3 localPosition = transform.localPosition;
					Vector3 localScale = transform.localScale;
					Vector3 vector = default(Vector3);
					vector = (flag ? (Quaternion.Euler(30f, 0f, 0f) * new Vector3(0f, transform.localPosition.y, 0f)) : (Quaternion.Euler(-150f, 0f, 0f) * new Vector3(0f, transform.localPosition.y, 0f)));
					_0024this_002414754.curModel.transform.localPosition = new Vector3(0f - vector.x, transform.localScale.y / 2f + transform.localPosition.y, 0f - vector.z);
					if (!(_0024this_002414754.curModel.transform.localPosition.y >= 0.6f))
					{
						float num = (_0024_002412305_002414756 = 0.6f);
						Vector3 vector2 = (_0024_002412306_002414755 = _0024this_002414754.curModel.transform.localPosition);
						float num2 = (_0024_002412306_002414755.y = _0024_002412305_002414756);
						Vector3 vector4 = (_0024this_002414754.curModel.transform.localPosition = _0024_002412306_002414755);
					}
					_0024this_002414754.camAjstTrg = new Vector3(0f, 0f, 1f - localScale.y / 2f);
					_0024this_002414754.trgAjstTrg = new Vector3(0f, -1.2f + localScale.y / 2f, 0f);
					_0024this_002414754.wpnAnm = true;
				}
			}
		}
	}

	[Serializable]
	internal class _0024TraitIcon_0024closure_00242953
	{
		internal Gousei3D _0024this_002414758;

		internal _0024TraitIcon_0024locals_002414327 _0024_0024locals_002414759;

		public _0024TraitIcon_0024closure_00242953(Gousei3D _0024this_002414758, _0024TraitIcon_0024locals_002414327 _0024_0024locals_002414759)
		{
			this._0024this_002414758 = _0024this_002414758;
			this._0024_0024locals_002414759 = _0024_0024locals_002414759;
		}

		public void Invoke(UITweener tw)
		{
			UnityEngine.Object.Destroy(tw);
			_0024_0024locals_002414759._0024tweenA = _0024this_002414758.trait.gameObject.AddComponent<TweenAlpha>();
			_0024_0024locals_002414759._0024tweenA.method = UITweener.Method.EaseInOut;
			_0024_0024locals_002414759._0024tweenA.alpha = 1f;
			_0024_0024locals_002414759._0024tweenA._from = 1f;
			_0024_0024locals_002414759._0024tweenA.to = 0f;
			_0024_0024locals_002414759._0024tweenA.delay = 2.88f;
			_0024_0024locals_002414759._0024tweenA.duration = 1.2f;
		}
	}

	public RespWeapon[] materialWeapon;

	public RespWeapon baseWeapon;

	public RespWeapon targetWeapon;

	public RespPoppet[] materialPoppet;

	public RespPoppet basePoppet;

	public RespPoppet targetPoppet;

	public Transform cameraAjust;

	public Transform targetAjust;

	private Vector3 camAjstTrg;

	private Vector3 trgAjstTrg;

	public string levelFormat;

	public bool IsLevelUp;

	public bool IsSkillUp;

	public bool IsLimitOver;

	public Mode mode;

	public int startLevel;

	public int elevatedLevel;

	public int startExp;

	public int endExp;

	public int[] maxExps;

	public int elevCount;

	private float barScl;

	private float maxScl;

	public int[] atkValues;

	public int[] hpValues;

	public int seiko;

	public int rare;

	public GameObject endFuncObject;

	public string endFunction;

	public string traitSpriteName;

	public int atkValue;

	public int hpValue;

	public bool skip;

	private GameObject curModel;

	public float timer;

	public float delay;

	private float oldTime;

	private GameObject[] arrWpnIcn;

	private GameObject[] arrMptIcn;

	private Ef_Anim2Next sziAnm;

	private Ef_Anim2Next camAnm;

	private Transform efFlare;

	private Transform efFlarem;

	private Transform efFlareg;

	private Transform efFlareu;

	private Transform efSpark;

	private Transform efSparkLine;

	private Transform efRinbw;

	private Transform efLine;

	private Transform efLineP;

	private Transform efUREvo;

	private Transform efSkUp;

	private Transform efSkUpl;

	private Transform efGktp;

	private Transform efGktpf;

	private GameObject efSzFlare;

	private GameObject[] arrSzFlare;

	private Transform efFader;

	public Material efFadeMat;

	private bool efFade;

	private float efFadeAlp;

	private Transform petObj;

	private Transform wpnObj;

	private bool wpnAnm;

	private Transform dskObj;

	private bool[] arrIcnFlg;

	private Transform expObj;

	private UISlider uiExpGauge;

	private Transform expTxtObj;

	private UIDynamicFontLabel uiExpTxt;

	private Transform lvTxtObj;

	private float lvTxtObjX;

	private UILabel uiLvTxt;

	private Animation mjSk;

	private Animation mjDsk;

	private Animation mjCsk;

	private Animation mjLvUp;

	private Animation mjSkUp;

	private Animation mjGktp;

	private Animation mjRN;

	private Animation mjRNp;

	private Animation mjRR;

	private Animation mjRRp;

	private Animation mjRS;

	private Animation mjRSp;

	private Animation mjUR;

	private Animation mjURp;

	private Animation mjAtk;

	private Animation mjHp;

	private Transform trait;

	private Ef_QuickAnimTransform tnRS;

	private Ef_QuickAnimTransform tnUR;

	private ParticleSystem psRR;

	private ParticleSystem psRRp;

	private ParticleSystem psRS;

	private ParticleSystem psRSp;

	private ParticleSystem psUR;

	private ParticleSystem psURp;

	private ParticleSystem psStarS;

	private ParticleSystem psStarU;

	private Ef_QuickAnimColor clrSk;

	private Ef_QuickAnimColor clrDsk;

	private Ef_QuickAnimColor clrCsk;

	private Ef_QuickAnimColor clrLvUp;

	private Ef_QuickAnimColor clrSkUp;

	private Ef_QuickAnimColor clrGktp;

	private Ef_QuickAnimColor clrRN;

	private Ef_QuickAnimColor clrRNp;

	private Ef_QuickAnimColor clrRR;

	private Ef_QuickAnimColor clrRRp;

	private Ef_QuickAnimColor clrRS;

	private Ef_QuickAnimColor clrRSp;

	private Ef_QuickAnimColor clrUR;

	private Ef_QuickAnimColor clrURp;

	private Ef_QuickAnimColor clrAtk;

	private Ef_QuickAnimColor clrHp;

	public GameObject campaiPrefab;

	public Gousei3DCampaign[] campaiIcons;

	private GameObject[] campaiObjs;

	public Vector3 campaiPos;

	public Vector3 campaiOffset;

	public Vector3 campaiScale;

	public bool testMode;

	public bool testSkillUp;

	public bool testGkToppa;

	public int testStartLevel;

	public int testElevatedLevel;

	public int testStartExp;

	public int testEndExp;

	public int[] testMaxExps;

	public int testSeiko;

	public int testRare;

	public int testTraitId;

	public string testTraitSpriteName;

	public int testAtkValue;

	public int testHpValue;

	public int[] testAtkValues;

	public int[] testHpValues;

	public string testWeaponPath;

	public string testWeaponEvoPath;

	public string testPuppetPath;

	public string testPuppetEvoPath;

	public bool testEff_Sk;

	public bool testEff_Dsk;

	public bool testEff_Csk;

	public bool testEff_LvUp;

	public bool testEff_SkUp;

	public bool testEff_Gktp;

	public bool testEff_RN;

	public bool testEff_RNp;

	public bool testEff_RR;

	public bool testEff_RRp;

	public bool testEff_RS;

	public bool testEff_RSp;

	public bool testEff_UR;

	public bool testEff_URp;

	public bool testEff_Atk;

	public bool testEff_Hp;

	public bool testEff_Trait;

	public Gousei3DCampaign[] testCampaiIcons;

	private float countUpSeElapsedTime;

	public Gousei3D()
	{
		camAjstTrg = Vector3.zero;
		trgAjstTrg = Vector3.zero;
		levelFormat = "Lv.{0:00}";
		mode = Mode.Weapon;
		startLevel = 1;
		atkValue = 9999999;
		hpValue = 9999999;
		campaiPos = new Vector3(-280f, -220f, 0f);
		campaiOffset = new Vector3(-70f, 0f, 0f);
		campaiScale = new Vector3(1.2f, 1.2f, 1.2f);
		testStartLevel = 1;
		testElevatedLevel = 3;
		testStartExp = 40;
		testEndExp = 320;
		testSeiko = 1;
		testRare = 6;
		testTraitSpriteName = "icon_trait_balance";
		testAtkValue = 1234;
		testHpValue = 56789;
		testWeaponPath = "W03_0013_01";
		testWeaponEvoPath = "W03_0018_01";
		testPuppetPath = "P5000_C00_MA_ROOT";
		testPuppetEvoPath = "P5002_C00_MA_ROOT";
	}

	private int seiko2rare(int s)
	{
		return checked(s * 2 + 1);
	}

	public void Awake()
	{
		materialWeapon = new RespWeapon[5];
		materialPoppet = new RespPoppet[5];
	}

	public void Start()
	{
		arrWpnIcn = new GameObject[5];
		arrMptIcn = new GameObject[5];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(5).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					GameObject[] array = arrWpnIcn;
					array[RuntimeServices.NormalizeArrayIndex(array, num)] = UnityEngine.Object.Instantiate(Resources.Load("Prefab/GUI/WeaponIcon")) as GameObject;
					GameObject[] array2 = arrWpnIcn;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].transform.parent = this.transform.Find("GouseiSozai/Sozai0" + (num + 1));
					GameObject[] array3 = arrWpnIcn;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num)].transform.localPosition = Vector3.zero;
					GameObject[] array4 = arrWpnIcn;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num)].transform.localRotation = Quaternion.identity;
					GameObject[] array5 = arrWpnIcn;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)].transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
					GameObject[] array6 = arrWpnIcn;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)].SetActive(value: false);
					GameObject[] array7 = arrMptIcn;
					array7[RuntimeServices.NormalizeArrayIndex(array7, num)] = UnityEngine.Object.Instantiate(Resources.Load("Prefab/GUI/MapetIcon")) as GameObject;
					GameObject[] array8 = arrMptIcn;
					array8[RuntimeServices.NormalizeArrayIndex(array8, num)].transform.parent = this.transform.Find("GouseiSozai/Sozai0" + (num + 1));
					GameObject[] array9 = arrMptIcn;
					array9[RuntimeServices.NormalizeArrayIndex(array9, num)].transform.localPosition = Vector3.zero;
					GameObject[] array10 = arrMptIcn;
					array10[RuntimeServices.NormalizeArrayIndex(array10, num)].transform.localRotation = Quaternion.identity;
					GameObject[] array11 = arrMptIcn;
					array11[RuntimeServices.NormalizeArrayIndex(array11, num)].transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
					GameObject[] array12 = arrMptIcn;
					array12[RuntimeServices.NormalizeArrayIndex(array12, num)].SetActive(value: false);
					if (testMode && mode != Mode.WeaponGet && mode != Mode.PoppetGet)
					{
						GameObject[] array13 = arrWpnIcn;
						array13[RuntimeServices.NormalizeArrayIndex(array13, num)].SetActive(value: true);
						GameObject[] array14 = arrWpnIcn;
						WeaponInfo component = array14[RuntimeServices.NormalizeArrayIndex(array14, num)].GetComponent<WeaponInfo>();
						component.DestroyLevel();
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			sziAnm = this.transform.Find("GouseiSozai").gameObject.AddComponent<Ef_Anim2Next>();
			camAnm = this.transform.Find("GouseiCamera").gameObject.AddComponent<Ef_Anim2Next>();
			mjSk = this.transform.Find("Main Camera/Moji_SK").animation;
			mjDsk = this.transform.Find("Main Camera/Moji_DSK").animation;
			mjCsk = this.transform.Find("Main Camera/Moji_CSK").animation;
			mjLvUp = this.transform.Find("Main Camera/Moji_LvUp").animation;
			mjSkUp = this.transform.Find("Main Camera/Moji_SkUp").animation;
			mjGktp = this.transform.Find("Main Camera/Moji_Gktp").animation;
			mjRN = this.transform.Find("Main Camera/Moji_Rare_N").animation;
			mjRNp = this.transform.Find("Main Camera/Moji_Rare_N+").animation;
			mjRR = this.transform.Find("Main Camera/Moji_Rare_R").animation;
			mjRRp = this.transform.Find("Main Camera/Moji_Rare_R+").animation;
			mjRS = this.transform.Find("Main Camera/Moji_Rare_SR").animation;
			mjRSp = this.transform.Find("Main Camera/Moji_Rare_SR+").animation;
			mjUR = this.transform.Find("Main Camera/Moji_Rare_UR").animation;
			mjAtk = this.transform.Find("Main Camera/Moji_Atk").animation;
			mjHp = this.transform.Find("Main Camera/Moji_Hp").animation;
			trait = this.transform.Find("Main Camera/Trait");
			psRR = this.transform.Find("Main Camera/Moji_Rare_R/Flare").particleSystem;
			psRRp = this.transform.Find("Main Camera/Moji_Rare_R+/Flare").particleSystem;
			psRS = this.transform.Find("Main Camera/Moji_Rare_SR/Flare").particleSystem;
			psRSp = this.transform.Find("Main Camera/Moji_Rare_SR+/Flare").particleSystem;
			psUR = this.transform.Find("Main Camera/Moji_Rare_UR/Flare").particleSystem;
			mjSk.gameObject.SetActive(value: false);
			mjDsk.gameObject.SetActive(value: false);
			mjCsk.gameObject.SetActive(value: false);
			mjLvUp.gameObject.SetActive(value: false);
			mjSkUp.gameObject.SetActive(value: false);
			mjGktp.gameObject.SetActive(value: false);
			mjRN.gameObject.SetActive(value: false);
			mjRNp.gameObject.SetActive(value: false);
			mjRR.gameObject.SetActive(value: false);
			mjRRp.gameObject.SetActive(value: false);
			mjRS.gameObject.SetActive(value: false);
			mjRSp.gameObject.SetActive(value: false);
			mjUR.gameObject.SetActive(value: false);
			mjAtk.gameObject.SetActive(value: false);
			mjHp.gameObject.SetActive(value: false);
			trait.gameObject.SetActive(value: false);
			clrSk = mjSk.GetComponent<Ef_QuickAnimColor>();
			clrDsk = mjDsk.GetComponent<Ef_QuickAnimColor>();
			clrCsk = mjCsk.GetComponent<Ef_QuickAnimColor>();
			clrLvUp = mjLvUp.GetComponent<Ef_QuickAnimColor>();
			clrSkUp = mjSkUp.GetComponent<Ef_QuickAnimColor>();
			clrGktp = mjGktp.GetComponent<Ef_QuickAnimColor>();
			clrRN = mjRN.GetComponent<Ef_QuickAnimColor>();
			clrRNp = mjRNp.GetComponent<Ef_QuickAnimColor>();
			clrRR = mjRR.GetComponent<Ef_QuickAnimColor>();
			clrRRp = mjRRp.GetComponent<Ef_QuickAnimColor>();
			clrRS = mjRS.GetComponent<Ef_QuickAnimColor>();
			clrRSp = mjRSp.GetComponent<Ef_QuickAnimColor>();
			clrUR = mjUR.GetComponent<Ef_QuickAnimColor>();
			clrAtk = mjAtk.GetComponent<Ef_QuickAnimColor>();
			clrAtk.Stop();
			clrAtk.Clear();
			clrHp = mjHp.GetComponent<Ef_QuickAnimColor>();
			clrHp.Stop();
			clrHp.Clear();
			clrHp.Stop();
			clrHp.Clear();
			efFlare = this.transform.Find("Effects/Ef_Flare");
			efFlarem = this.transform.Find("Effects/Ef_Flare_Mini");
			efFlareg = this.transform.Find("Effects/Ef_Flare_Get");
			efFlareu = this.transform.Find("Effects/LookCam/Ef_Flare_UR");
			efSpark = this.transform.Find("Effects/Ef_Spark");
			efSparkLine = this.transform.Find("Effects/Ef_SparkLine");
			efRinbw = this.transform.Find("Effects/Ef_Rainbow");
			efLine = this.transform.Find("Effects/Ef_Line");
			efLineP = this.transform.Find("Effects/Ef_Line_Pet");
			efUREvo = this.transform.Find("Effects/Ef_UREvolution");
			efSkUp = this.transform.Find("Effects/Ef_SkUp");
			efSkUpl = this.transform.Find("Effects/Ef_SkUp/Ef_SkUp_Line");
			efGktp = this.transform.Find("Effects/Ef_Gktp");
			efGktpf = this.transform.Find("Effects/Ef_Gktp/Ef_Gktp_Flare");
			efSzFlare = this.transform.Find("Effects/Ef_Sozai_Flare").gameObject;
			arrSzFlare = new GameObject[5];
			IEnumerator<int> enumerator2 = Builtins.range(5).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array15 = arrSzFlare;
					array15[RuntimeServices.NormalizeArrayIndex(array15, num)] = (GameObject)UnityEngine.Object.Instantiate(efSzFlare);
					GameObject[] array16 = arrSzFlare;
					array16[RuntimeServices.NormalizeArrayIndex(array16, num)].transform.parent = this.transform.Find("GouseiSozai/Sozai0" + (num + 1));
					GameObject[] array17 = arrSzFlare;
					array17[RuntimeServices.NormalizeArrayIndex(array17, num)].transform.localPosition = Vector3.zero;
					GameObject[] array18 = arrSzFlare;
					array18[RuntimeServices.NormalizeArrayIndex(array18, num)].transform.localRotation = Quaternion.identity;
					GameObject[] array19 = arrSzFlare;
					array19[RuntimeServices.NormalizeArrayIndex(array19, num)].transform.localScale = Vector3.one;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			efFader = this.transform.Find("Effects/Ef_BillBoardShade");
			efFadeMat = efFader.renderer.material;
			efFadeMat.color = new Color(1f, 1f, 1f, 0f);
			efFader.gameObject.SetActive(value: false);
			tnRS = this.transform.Find("Effects/LookCam/Ef_Tonnels_SR").GetComponent<Ef_QuickAnimTransform>();
			tnUR = this.transform.Find("Effects/LookCam/Ef_Tonnels_UR").GetComponent<Ef_QuickAnimTransform>();
			psStarS = this.transform.Find("Effects/LookCam/Ef_Star_SR").particleSystem;
			psStarU = this.transform.Find("Effects/LookCam/Ef_Star_UR").particleSystem;
			arrIcnFlg = new bool[5];
			if (testMode)
			{
				if (mode == Mode.Weapon || mode == Mode.WeaponEvolution)
				{
					materialWeapon = new RespWeapon[5];
					PutWeapon(testWeaponPath);
					IEnumerator<int> enumerator3 = Builtins.range(5).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							num = enumerator3.Current;
							bool[] array20 = arrIcnFlg;
							array20[RuntimeServices.NormalizeArrayIndex(array20, num)] = true;
						}
					}
					finally
					{
						enumerator3.Dispose();
					}
				}
				else if (mode == Mode.Poppet || mode == Mode.PoppetEvolution)
				{
					materialPoppet = new RespPoppet[5];
					PutMapet(testPuppetPath);
					IEnumerator<int> enumerator4 = Builtins.range(5).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							num = enumerator4.Current;
							bool[] array21 = arrIcnFlg;
							array21[RuntimeServices.NormalizeArrayIndex(array21, num)] = true;
						}
					}
					finally
					{
						enumerator4.Dispose();
					}
				}
				IsSkillUp = testSkillUp;
				IsLimitOver = testGkToppa;
				startLevel = testStartLevel;
				elevatedLevel = testElevatedLevel;
				startExp = testStartExp;
				endExp = testEndExp;
				maxExps = testMaxExps;
				seiko = testSeiko;
				rare = testRare;
				atkValue = testAtkValue;
				traitSpriteName = testTraitSpriteName;
				hpValue = testHpValue;
				atkValues = testAtkValues;
				hpValues = testHpValues;
				campaiIcons = testCampaiIcons;
			}
			else
			{
				int num2 = 0;
				if (mode == Mode.Weapon || mode == Mode.WeaponEvolution)
				{
					int i = 0;
					RespWeapon[] array22 = materialWeapon;
					for (int length = array22.Length; i < length; i++)
					{
						if (array22[i] != null && array22[i].RefPlayerBox != null && array22[i].MWeaponId != 0 && array22[i].Id.IsValid)
						{
							GameObject[] array23 = arrWpnIcn;
							WeaponInfo component2 = array23[RuntimeServices.NormalizeArrayIndex(array23, num2)].GetComponent<WeaponInfo>();
							if ((bool)component2)
							{
								component2.SetWeapon(array22[i]);
								component2.DestroyLevel();
							}
							GameObject[] array24 = arrWpnIcn;
							array24[RuntimeServices.NormalizeArrayIndex(array24, num2)].SetActive(value: true);
							bool[] array25 = arrIcnFlg;
							array25[RuntimeServices.NormalizeArrayIndex(array25, num2)] = true;
						}
						num2++;
					}
					if (baseWeapon != null)
					{
						PutWeapon(baseWeapon.PrefabPath);
						traitSpriteName = baseWeapon.TraitSpriteName;
					}
				}
				else if (mode == Mode.Poppet || mode == Mode.PoppetEvolution)
				{
					int j = 0;
					RespPoppet[] array26 = materialPoppet;
					for (int length2 = array26.Length; j < length2; j++)
					{
						if (array26[j] != null && array26[j].RefPlayerBox != null && array26[j].MPoppetId != 0 && array26[j].Id.IsValid)
						{
							GameObject[] array27 = arrMptIcn;
							MuppetInfo component3 = array27[RuntimeServices.NormalizeArrayIndex(array27, num2)].GetComponent<MuppetInfo>();
							if ((bool)component3)
							{
								component3.SetMuppet(array26[j]);
								component3.DestroyLevel();
							}
							GameObject[] array28 = arrMptIcn;
							array28[RuntimeServices.NormalizeArrayIndex(array28, num2)].SetActive(value: true);
							bool[] array29 = arrIcnFlg;
							array29[RuntimeServices.NormalizeArrayIndex(array29, num2)] = true;
						}
						num2++;
					}
					if (basePoppet != null)
					{
						PutMapet(basePoppet.PrefabPath);
					}
					traitSpriteName = basePoppet.TraitSpriteName;
				}
			}
			if (elevatedLevel > 0)
			{
				IsLevelUp = true;
			}
			if (maxExps.Length == 0)
			{
				maxExps = new int[1];
				maxExps[0] = 100;
			}
			if (atkValues.Length == 0)
			{
				atkValues = new int[1];
				atkValues[0] = atkValue;
			}
			if (hpValues.Length == 0)
			{
				hpValues = new int[1];
				hpValues[0] = hpValue;
			}
			Transform transform = this.transform.Find("Main Camera/Panel");
			expObj = transform.Find("Progress Bar");
			uiExpGauge = expObj.GetComponent<UISlider>();
			expTxtObj = transform.Find("Exp");
			uiExpTxt = expTxtObj.GetComponent<UIDynamicFontLabel>();
			lvTxtObj = transform.Find("Lv");
			lvTxtObjX = lvTxtObj.localPosition.x;
			uiLvTxt = lvTxtObj.GetComponent<UILabel>();
			expObj.gameObject.SetActive(value: false);
			expTxtObj.gameObject.SetActive(value: false);
			lvTxtObj.gameObject.SetActive(value: false);
			if ((bool)campaiPrefab)
			{
				int length3 = campaiIcons.Length;
				campaiObjs = new GameObject[length3];
				IEnumerator<int> enumerator5 = Builtins.range(length3).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						num = enumerator5.Current;
						GameObject[] array30 = campaiObjs;
						array30[RuntimeServices.NormalizeArrayIndex(array30, num)] = (GameObject)UnityEngine.Object.Instantiate(campaiPrefab, Vector3.zero, Quaternion.identity);
						GameObject[] array31 = campaiObjs;
						array31[RuntimeServices.NormalizeArrayIndex(array31, num)].transform.parent = transform;
						GameObject[] array32 = campaiObjs;
						array32[RuntimeServices.NormalizeArrayIndex(array32, num)].transform.localPosition = campaiPos + campaiOffset * num;
						GameObject[] array33 = campaiObjs;
						array33[RuntimeServices.NormalizeArrayIndex(array33, num)].transform.localRotation = Quaternion.identity;
						GameObject[] array34 = campaiObjs;
						array34[RuntimeServices.NormalizeArrayIndex(array34, num)].transform.localScale = campaiScale;
						GameObject[] array35 = campaiObjs;
						CampaignPanel component4 = array35[RuntimeServices.NormalizeArrayIndex(array35, num)].GetComponent<CampaignPanel>();
						if ((bool)component4)
						{
							Gousei3DCampaign[] array36 = campaiIcons;
							CampaignPanel.CampaignType type = array36[RuntimeServices.NormalizeArrayIndex(array36, num)].type;
							Gousei3DCampaign[] array37 = campaiIcons;
							component4.Init(type, array37[RuntimeServices.NormalizeArrayIndex(array37, num)].text);
						}
						GameObject[] array38 = campaiObjs;
						array38[RuntimeServices.NormalizeArrayIndex(array38, num)].SetActive(value: false);
					}
				}
				finally
				{
					enumerator5.Dispose();
				}
			}
			GouseiStart();
		}
	}

	public void Update()
	{
		if (wpnAnm)
		{
			wpnObj.localRotation = Quaternion.Euler(0f, 40f * Time.deltaTime, 0f) * wpnObj.localRotation;
		}
		bool flag = false;
		bool flag2 = false;
		if (!(timer <= 1f) && skip)
		{
			CameraRightForce();
			GouseiStop();
			flag = true;
			flag2 = true;
			WhiteFadeIn();
			if (this.mode == Mode.Weapon || this.mode == Mode.Poppet)
			{
				if (seiko == 0)
				{
					SeikouSkip();
				}
				else if (seiko == 1)
				{
					DaiSeikouSkip();
				}
				else if (seiko == 2)
				{
					ChoSeikouSkip();
				}
			}
			else if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution)
			{
				if (rare == 1)
				{
					Rare_N_Skip();
				}
				else if (rare == 2)
				{
					Rare_Np_Skip();
				}
				else if (rare == 3)
				{
					Rare_R_Skip();
				}
				else if (rare == 4)
				{
					Rare_Rp_Skip();
				}
				else if (rare == 5)
				{
					Rare_SR_Skip();
				}
				else if (rare == 6)
				{
					Rare_SRp_Skip();
				}
				else if (rare == 7)
				{
					Rare_UR_Skip();
				}
				else if (rare == 8)
				{
					Rare_URp_Skip();
				}
			}
			skip = false;
		}
		checked
		{
			if (!(timer <= 0f))
			{
				oldTime = timer;
				if (!(delay <= 0f))
				{
					delay -= Time.deltaTime;
				}
				else
				{
					timer += Time.deltaTime;
				}
				if (BeyondTime(0.09f) && (this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet))
				{
					if (rare >= 7)
					{
						delay = 2f;
						efFlareu.particleSystem.Play();
					}
					timer = 0.09f;
				}
				if (BeyondTime(0.1f))
				{
					if (this.mode == Mode.Weapon || this.mode == Mode.Poppet || this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution)
					{
						atkValue = atkValues[0];
						hpValue = hpValues[0];
						AtkHpWidth();
						AtkValueFix(atkValue);
						HpValueFix(hpValue);
						timer = 0.1f;
					}
					if (this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet)
					{
						efFlareg.particleSystem.Play();
						timer = 1.5f;
					}
				}
				if (BeyondTime(0.4f))
				{
					if (this.mode == Mode.Weapon || this.mode == Mode.Poppet || this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution)
					{
						GouseiAnimStart();
						GouseiCamStart();
					}
					else
					{
						GouseiCamStart();
					}
					if (this.mode == Mode.Weapon || this.mode == Mode.Poppet)
					{
						GameSoundManager.PlaySeJingle("se_system_composition", 0, resumeBgm: true);
					}
					else if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution)
					{
						GameSoundManager.PlaySeJingle("se_system_composition", 0, resumeBgm: true);
					}
				}
				if (BeyondTime(2f))
				{
					if (this.mode == Mode.Weapon || this.mode == Mode.Poppet)
					{
						if (seiko >= 2)
						{
							psStarS.Play();
						}
						playCompositionSeByRarity(seiko2rare(seiko));
					}
					else if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution || this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet)
					{
						if (rare == 5 || rare == 6)
						{
							psStarS.Play();
						}
						else if (rare >= 7)
						{
							psStarU.Play();
						}
					}
					efFader.gameObject.SetActive(value: true);
					efFadeMat.color = Color.white;
					WhiteFadeIn();
					timer = 2f;
				}
				if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution || this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet)
				{
					if (BeyondTime(2.1f))
					{
						flag2 = true;
						Mode mode = this.mode;
						switch (mode)
						{
						case Mode.WeaponEvolution:
							playEvolutionSeByRarity(rare);
							break;
						case Mode.PoppetEvolution:
							playEvolutionSeByRarity(rare);
							break;
						case Mode.WeaponGet:
							playItemAcquireSeByRarity(rare);
							break;
						case Mode.PoppetGet:
							playItemAcquireSeByRarity(rare);
							break;
						default:
							throw new MatchError(new StringBuilder("`mode` failed to match `").Append(mode).Append("`").ToString());
						}
					}
					if (BeyondTime(2.5f))
					{
						timer = 2.5f;
						efLineP.particleSystem.Play();
						if ((this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution) && rare >= 7)
						{
							efUREvo.particleSystem.Play();
						}
					}
					if (BeyondTime(3f))
					{
						if (rare == 2)
						{
							Rare_Np();
						}
						else if (rare == 3)
						{
							Rare_R();
						}
						else if (rare == 4)
						{
							Rare_Rp();
						}
						else if (rare == 5)
						{
							Rare_SR();
						}
						else if (rare == 6)
						{
							Rare_SRp();
						}
						else if (rare == 7)
						{
							Rare_UR();
						}
						else if (rare == 8)
						{
							Rare_URp();
						}
						else
						{
							Rare_N();
						}
					}
				}
				else if (this.mode == Mode.Weapon || this.mode == Mode.Poppet)
				{
					if (BeyondTime(2.5f))
					{
						flag2 = true;
					}
					if (BeyondTime(3f))
					{
						if (seiko == 0)
						{
							Seikou();
						}
						else if (seiko == 1)
						{
							DaiSeikou();
						}
						else if (seiko == 2)
						{
							ChoSeikou();
						}
					}
					if (BeyondTime(3.2f))
					{
						GameSoundManager.PlaySe("se_system_composition2", 0);
					}
				}
				if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution || this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet)
				{
					if (rare <= 6)
					{
						if (BeyondTime(4f))
						{
							if (atkValues.Length > 1)
							{
								atkValue = atkValues[1];
							}
							if (hpValues.Length > 1)
							{
								hpValue = hpValues[1];
							}
							AtkHpWidth();
							AtkValue(atkValue);
							HpValue(hpValue);
							TraitIcon(traitSpriteName);
						}
						if (BeyondTime(4.3f))
						{
							playJingleByRarity(rare);
						}
					}
					else
					{
						if (BeyondTime(5f))
						{
							if (atkValues.Length > 1)
							{
								atkValue = atkValues[1];
							}
							if (hpValues.Length > 1)
							{
								hpValue = hpValues[1];
							}
							AtkHpWidth();
							AtkValue(atkValue);
							HpValue(hpValue);
							TraitIcon(traitSpriteName);
						}
						if (BeyondTime(5.3f))
						{
							playJingleByRarity(rare);
						}
					}
				}
				if ((this.mode == Mode.Weapon || this.mode == Mode.Poppet) && BeyondTime(5f))
				{
					expTxtObj.gameObject.SetActive(value: true);
					expObj.gameObject.SetActive(value: true);
					CampaignIcon();
					if (IsLevelUp)
					{
						lvTxtObj.gameObject.SetActive(value: true);
						uiLvTxt.text = "lv" + startLevel;
					}
					if (maxExps.Length <= elevatedLevel)
					{
						elevatedLevel = maxExps.Length - 1;
						if (elevatedLevel < 0)
						{
							elevatedLevel = 0;
						}
					}
					elevCount = elevatedLevel;
					barScl = 1f / (float)maxExps[0] * (float)startExp;
					int[] array = maxExps;
					maxScl = 1f / (float)array[RuntimeServices.NormalizeArrayIndex(array, elevatedLevel)] * (float)endExp;
					uiExpGauge.sliderValue = barScl;
				}
				if ((this.mode == Mode.Weapon || this.mode == Mode.Poppet) && !(timer < 5f))
				{
					if (!(timer >= 7f))
					{
						int num = elevatedLevel - elevCount;
						barScl += Time.deltaTime * ((float)num + 2f) / 2f;
						lvTxtObj.localScale = Vector3.Lerp(lvTxtObj.localScale, new Vector3(26f, 26f, 1f), 0.05f);
						float x = Mathf.Lerp(lvTxtObj.localPosition.x, 183f, 0.05f);
						Vector3 localPosition = lvTxtObj.localPosition;
						float num2 = (localPosition.x = x);
						Vector3 vector2 = (lvTxtObj.localPosition = localPosition);
						if (elevCount == 0)
						{
							if (!(barScl < maxScl))
							{
								barScl = maxScl;
							}
						}
						else if (!(barScl < 1f))
						{
							barScl = 1f;
							elevCount--;
							num++;
							if (IsLevelUp)
							{
								LevelUp();
								uiLvTxt.text = "lv" + (startLevel + num);
								if (atkValues.Length > num)
								{
									int[] array2 = atkValues;
									atkValue = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
								}
								if (hpValues.Length > num)
								{
									int[] array3 = hpValues;
									hpValue = array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
								}
								AtkValueUp(atkValue);
								HpValueUp(hpValue);
								TraitIcon(traitSpriteName);
							}
							float num3 = (float)num * 0.2f + 1f;
							if (!(num3 <= 5f))
							{
								num3 = 5f;
							}
							lvTxtObj.localScale = new Vector3(50f, 50f, 1f) * num3;
							float x2 = 183f + 50f * num3;
							Vector3 localPosition2 = lvTxtObj.localPosition;
							float num4 = (localPosition2.x = x2);
							Vector3 vector4 = (lvTxtObj.localPosition = localPosition2);
							barScl = 0f;
							timer = 5f;
						}
						countUpSeElapsedTime += Time.deltaTime;
						if (!(countUpSeElapsedTime <= 0.033f) && uiExpGauge.sliderValue != barScl)
						{
							GameSoundManager.PlaySe("se_system_exp_countup", 0);
							countUpSeElapsedTime = 0f;
						}
						int[] array4 = maxExps;
						int num5 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
						uiExpGauge.sliderValue = barScl;
						int num6 = Mathf.FloorToInt((float)num5 * barScl);
						uiExpTxt.text = num6 + "/" + num5;
					}
					else if (!(timer >= 8f))
					{
						lvTxtObj.localScale = Vector3.Lerp(lvTxtObj.localScale, new Vector3(26f, 26f, 1f), 0.05f);
					}
				}
				if (this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution || this.mode == Mode.WeaponGet || this.mode == Mode.PoppetGet)
				{
					if (rare <= 4)
					{
						if (BeyondTime(8f))
						{
							flag = true;
							timer = 0f;
						}
					}
					else if (rare <= 6)
					{
						if (BeyondTime(11f))
						{
							flag = true;
							timer = 0f;
						}
					}
					else if (BeyondTime(12f))
					{
						flag = true;
						timer = 0f;
					}
				}
				if (this.mode == Mode.Weapon || this.mode == Mode.Poppet)
				{
					if (BeyondTime(8f))
					{
						expObj.gameObject.SetActive(value: false);
						expTxtObj.gameObject.SetActive(value: false);
						lvTxtObj.gameObject.SetActive(value: false);
						CampaignIconEnd();
						if (IsSkillUp)
						{
							SkillUp();
						}
						else if (IsLimitOver)
						{
							GkToppa();
						}
						else
						{
							flag = true;
							timer = 0f;
						}
					}
					if (BeyondTime(11f))
					{
						if (IsLimitOver && IsSkillUp)
						{
							GkToppa();
						}
						else
						{
							flag = true;
							timer = 0f;
						}
					}
					if (!(timer <= 14f))
					{
						flag = true;
						timer = 0f;
					}
				}
			}
			if (flag2)
			{
				PutWeapon(string.Empty);
				PutMapet(string.Empty);
				if (testMode)
				{
					if (this.mode == Mode.Weapon)
					{
						PutWeapon(testWeaponPath);
					}
					else if (this.mode == Mode.Poppet)
					{
						PutMapet(testPuppetPath);
					}
					else if (this.mode == Mode.WeaponEvolution || this.mode == Mode.WeaponGet)
					{
						PutWeapon(testWeaponEvoPath);
					}
					else if (this.mode == Mode.PoppetEvolution || this.mode == Mode.PoppetGet)
					{
						PutMapet(testPuppetEvoPath);
					}
				}
				else if (this.mode == Mode.Weapon)
				{
					if (targetWeapon != null)
					{
						PutWeapon(targetWeapon.PrefabPath);
					}
				}
				else if (this.mode == Mode.Poppet)
				{
					if (targetPoppet != null)
					{
						PutMapet(targetPoppet.PrefabPath);
					}
				}
				else if (this.mode == Mode.WeaponEvolution)
				{
					if (targetWeapon != null)
					{
						PutWeapon(targetWeapon.PrefabPath);
					}
				}
				else if (this.mode == Mode.PoppetEvolution)
				{
					if (targetPoppet != null)
					{
						PutMapet(targetPoppet.PrefabPath);
					}
				}
				else if (this.mode == Mode.WeaponGet)
				{
					if (targetWeapon != null)
					{
						PutWeapon(targetWeapon.PrefabPath);
					}
				}
				else if (this.mode == Mode.PoppetGet && targetPoppet != null)
				{
					PutMapet(targetPoppet.PrefabPath);
				}
			}
			else if ((this.mode == Mode.Poppet || this.mode == Mode.PoppetEvolution || this.mode == Mode.PoppetGet) && curModel != null)
			{
				curModel.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			float a = efFadeMat.color.a;
			if (efFade)
			{
				if (!(a >= 1f))
				{
					if (a == 0f)
					{
						efFader.gameObject.SetActive(value: true);
					}
					a += Time.deltaTime * 5f;
					if (!(a <= 1f))
					{
						a = 1f;
					}
					float a2 = a;
					Color color = efFadeMat.color;
					float num7 = (color.a = a2);
					Color color3 = (efFadeMat.color = color);
				}
			}
			else if (!(a <= 0f))
			{
				a -= Time.deltaTime;
				if (!(a > 0f))
				{
					a = 0f;
					efFader.gameObject.SetActive(value: false);
				}
				float a3 = a;
				Color color4 = efFadeMat.color;
				float num8 = (color4.a = a3);
				Color color6 = (efFadeMat.color = color4);
			}
			cameraAjust.localPosition = Vector3.Lerp(cameraAjust.localPosition, camAjstTrg, 0.02f);
			targetAjust.localPosition = Vector3.Lerp(targetAjust.localPosition, trgAjstTrg, 0.02f);
			if (flag)
			{
				if (this.mode == Mode.Weapon || this.mode == Mode.Poppet || this.mode == Mode.WeaponEvolution || this.mode == Mode.PoppetEvolution)
				{
					CameraRight();
					AtkValueHide();
					HpValueHide();
					TraitIconHide();
				}
				if ((bool)endFuncObject)
				{
					endFuncObject.SendMessage(endFunction, gameObject, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (testEff_Sk)
			{
				Seikou();
				testEff_Sk = false;
			}
			if (testEff_Dsk)
			{
				DaiSeikou();
				testEff_Dsk = false;
			}
			if (testEff_Csk)
			{
				ChoSeikou();
				testEff_Csk = false;
			}
			if (testEff_LvUp)
			{
				LevelUp();
				testEff_LvUp = false;
			}
			if (testEff_SkUp)
			{
				SkillUp();
				testEff_SkUp = false;
			}
			if (testEff_Gktp)
			{
				GkToppa();
				testEff_Gktp = false;
			}
			if (testEff_RN)
			{
				Rare_N();
				testEff_RN = false;
			}
			if (testEff_RNp)
			{
				Rare_Np();
				testEff_RNp = false;
			}
			if (testEff_RR)
			{
				Rare_R();
				testEff_RR = false;
			}
			if (testEff_RRp)
			{
				Rare_Rp();
				testEff_RRp = false;
			}
			if (testEff_RS)
			{
				Rare_SR();
				testEff_RS = false;
			}
			if (testEff_RSp)
			{
				Rare_SRp();
				testEff_RSp = false;
			}
			if (testEff_UR)
			{
				Rare_UR();
				testEff_UR = false;
			}
			if (testEff_URp)
			{
				Rare_URp();
				testEff_URp = false;
			}
			if (testEff_Atk)
			{
				AtkValue();
				testEff_Atk = false;
			}
			if (testEff_Hp)
			{
				HpValue();
				testEff_Hp = false;
			}
			if (testEff_Trait)
			{
				TraitIcon();
				testEff_Trait = false;
			}
		}
	}

	private bool BeyondTime(float t)
	{
		bool num = t > oldTime;
		if (num)
		{
			num = !(t > timer);
		}
		return num;
	}

	private void AtkHpWidth()
	{
		int num = 0;
		int num2 = 0;
		int num3 = default(int);
		int num4 = 1000000;
		IEnumerator<int> enumerator = Builtins.range(6).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num3 = enumerator.Current;
					if (atkValue >= num4)
					{
						num++;
					}
					if (hpValue >= num4)
					{
						num2++;
					}
					num4 = unchecked(num4 / 10);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			float num5 = (float)(-(num + num2)) * 0.1f;
			float num6 = 1f + (float)num * 0.15f;
			float x = num5;
			Vector3 localPosition = mjAtk.transform.localPosition;
			float num7 = (localPosition.x = x);
			Vector3 vector2 = (mjAtk.transform.localPosition = localPosition);
			float x2 = num5 + num6;
			Vector3 localPosition2 = mjHp.transform.localPosition;
			float num8 = (localPosition2.x = x2);
			Vector3 vector4 = (mjHp.transform.localPosition = localPosition2);
		}
	}

	public void GouseiStart()
	{
		timer = 0.02f;
	}

	public void GouseiAnimStart()
	{
		sziAnm.Fade2Next("Gousei_Sozai", "Gousei_Sozai_e", 0f);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(5).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				bool[] array = arrIcnFlg;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					GameObject[] array2 = arrSzFlare;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].particleSystem.Play();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		efSpark.particleSystem.Play();
		if (seiko == 0)
		{
			efFlarem.particleSystem.Play();
		}
		else
		{
			efFlare.particleSystem.Play();
		}
		if (seiko >= 2)
		{
			efRinbw.particleSystem.Play();
		}
	}

	public void GouseiCamStart()
	{
		camAnm.Fade2Next("Gousei_Camera", "Gousei_Camera_l", 0.5f);
	}

	public void GouseiStop()
	{
		sziAnm.Stop();
		camAnm.Stop();
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(5).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = arrWpnIcn;
				array[RuntimeServices.NormalizeArrayIndex(array, num)].SetActive(value: false);
				GameObject[] array2 = arrMptIcn;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)].SetActive(value: false);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		efSpark.particleSystem.Stop();
		efFlare.particleSystem.Stop();
		efFlarem.particleSystem.Stop();
		efFlareg.particleSystem.Stop();
		efRinbw.particleSystem.Stop();
		mjLvUp.Stop();
		efLine.particleSystem.Stop();
		efUREvo.particleSystem.Stop();
		mjSkUp.Stop();
		efSkUp.particleSystem.Stop();
		efSkUpl.particleSystem.Stop();
		mjGktp.Stop();
		efGktp.particleSystem.Stop();
		efGktpf.particleSystem.Stop();
		mjRN.Stop();
		mjRNp.Stop();
		mjRR.Stop();
		mjRRp.Stop();
		mjRS.Stop();
		mjRSp.Stop();
		mjUR.Stop();
		if (!(clrLvUp.life <= 0.5f))
		{
			clrLvUp.life = 0.5f;
		}
		if (!(clrAtk.life <= 0.5f))
		{
			clrAtk.life = 0.5f;
		}
		if (!(clrHp.life <= 0.5f))
		{
			clrHp.life = 0.5f;
		}
		expObj.gameObject.SetActive(value: false);
		expTxtObj.gameObject.SetActive(value: false);
		lvTxtObj.gameObject.SetActive(value: false);
		lvTxtObj.localScale = new Vector3(26f, 26f, 1f);
		timer = 0f;
		delay = 0f;
	}

	public void PutMapet(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		if (curModel != null)
		{
			UnityEngine.Object.DestroyObject(curModel);
		}
		RuntimeAssetBundleDB.Instance.instantiatePrefab(path, delegate(GameObject go)
		{
			curModel = go;
			if (!(curModel == null))
			{
				petObj = curModel.transform;
				petObj.parent = transform;
				petObj.localPosition = new Vector3(0f, 0f, 0f);
				petObj.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
				curModel = petObj.gameObject;
				NGUITools.SetLayer(curModel, gameObject.layer);
				if ((bool)curModel.GetComponent<AIControl>())
				{
					curModel.GetComponent<AIControl>().enabled = false;
				}
			}
		});
	}

	public void PutWeapon(string path)
	{
		_0024PutWeapon_0024locals_002414326 _0024PutWeapon_0024locals_0024 = new _0024PutWeapon_0024locals_002414326();
		_0024PutWeapon_0024locals_0024._0024path = path;
		if (!string.IsNullOrEmpty(_0024PutWeapon_0024locals_0024._0024path))
		{
			if (!wpnObj)
			{
				wpnObj = new GameObject("Weapon Root").transform;
				wpnObj.parent = transform;
				wpnObj.localPosition = Vector3.zero;
			}
			if (curModel != null)
			{
				UnityEngine.Object.DestroyObject(curModel);
			}
			Vector3 _0024_002412306_0024 = default(Vector3);
			float _0024_002412305_0024 = default(float);
			RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024PutWeapon_0024locals_0024._0024path, new _0024PutWeapon_0024closure_00242949(this, _0024_002412306_0024, _0024_002412305_0024, _0024PutWeapon_0024locals_0024).Invoke);
		}
	}

	public void Seikou()
	{
		mjSk.gameObject.SetActive(value: true);
		mjSk["Gousei_Moji"].time = 0f;
		mjSk.Play("Gousei_Moji");
		clrSk.Clear();
		clrSk.Play();
	}

	public void DaiSeikou()
	{
		mjDsk.gameObject.SetActive(value: true);
		mjDsk["Gousei_Moji"].time = 0f;
		mjDsk.Play("Gousei_Moji");
		clrDsk.Clear();
		clrDsk.Play();
	}

	public void ChoSeikou()
	{
		mjCsk.gameObject.SetActive(value: true);
		mjCsk["Gousei_Moji"].time = 0f;
		mjCsk.Play("Gousei_Moji");
		clrCsk.Clear();
		clrCsk.Play();
	}

	public void SeikouSkip()
	{
		if (clrSk.life > 1f)
		{
			mjSk.transform.localPosition = new Vector3(0.9f, 0f, 2.5f);
			mjSk.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			mjSk.gameObject.SetActive(value: true);
			mjSk["Gousei_Moji"].time = 0f;
			mjSk.Play("Gousei_Moji");
			clrSk.Clear();
			clrSk.Play();
		}
	}

	public void DaiSeikouSkip()
	{
		if (clrDsk.life > 1f)
		{
			mjDsk.transform.localPosition = new Vector3(0.75f, 0f, 2.5f);
			mjDsk.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
			mjDsk.gameObject.SetActive(value: true);
			mjDsk["Gousei_Moji"].time = 0f;
			mjDsk.Play("Gousei_Moji");
			clrDsk.Clear();
			clrDsk.Play();
		}
	}

	public void ChoSeikouSkip()
	{
		if (clrCsk.life > 1f)
		{
			mjCsk.transform.localPosition = new Vector3(0.75f, 0f, 2.5f);
			mjCsk.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			mjCsk.gameObject.SetActive(value: true);
			mjCsk["Gousei_Moji"].time = 0f;
			mjCsk.Play("Gousei_Moji");
			clrCsk.Clear();
			clrCsk.Play();
		}
	}

	public void LevelUp()
	{
		GameSoundManager.PlaySe("se_system_levelup", 0);
		efLine.particleSystem.Stop();
		efLine.particleSystem.Clear();
		mjLvUp.gameObject.SetActive(value: true);
		mjLvUp["Gousei_Moji"].time = 0f;
		mjLvUp.Play("Gousei_Moji");
		clrLvUp.Stop();
		clrLvUp.Clear();
		clrLvUp.Play();
		efLine.particleSystem.Play();
	}

	public void SkillUp()
	{
		GameSoundManager.PlaySe("se_system_skill_levelup", 0);
		mjSkUp.gameObject.SetActive(value: true);
		mjSkUp.Play("Gousei_Moji");
		clrSkUp.Clear();
		clrSkUp.Play();
		efSkUp.particleSystem.Play();
		efSkUpl.particleSystem.Play();
	}

	public void GkToppa()
	{
		GameSoundManager.PlaySe("se_system_limit_break", 0);
		mjGktp.gameObject.SetActive(value: true);
		mjGktp.Play("Gousei_Moji");
		clrGktp.Clear();
		clrGktp.Play();
		efGktp.particleSystem.Play();
		efGktpf.particleSystem.Play();
	}

	public void Rare_N()
	{
		mjRN.gameObject.SetActive(value: true);
		mjRN["Gousei_Moji"].time = 0f;
		mjRN.Play("Gousei_Moji");
		clrRN.Clear();
		clrRN.Play();
	}

	public void Rare_Np()
	{
		mjRNp.gameObject.SetActive(value: true);
		mjRNp["Gousei_Moji"].time = 0f;
		mjRNp.Play("Gousei_Moji");
		clrRNp.Clear();
		clrRNp.Play();
	}

	public void Rare_R()
	{
		mjRR.gameObject.SetActive(value: true);
		mjRR["Gousei_Moji"].time = 0f;
		mjRR.Play("Gousei_Moji");
		clrRR.Clear();
		clrRR.Play();
		psRR.Stop();
		psRR.Clear();
		psRR.Play();
	}

	public void Rare_Rp()
	{
		mjRRp.gameObject.SetActive(value: true);
		mjRRp["Gousei_Moji"].time = 0f;
		mjRRp.Play("Gousei_Moji");
		clrRRp.Clear();
		clrRRp.Play();
		psRRp.Stop();
		psRRp.Clear();
		psRRp.Play();
	}

	public void Rare_SR()
	{
		mjRS.gameObject.SetActive(value: true);
		mjRS["Gousei_Moji_SR"].time = 0f;
		mjRS.Play("Gousei_Moji_SR");
		clrRS.Clear();
		clrRS.Play();
		psRS.Stop();
		psRS.Clear();
		psRS.Play();
		tnRS.Clear();
		tnRS.Play();
		int num = 0;
		while (num < 6)
		{
			int num2 = num;
			num++;
			Transform transform = ((Transform)UnityEngine.Object.Instantiate(efSparkLine)).transform;
			transform.parent = mjRS.transform;
			transform.localPosition = new Vector3(-1.8f + 0.6f * (float)num2, 0f, -0.5f);
			transform.particleSystem.startDelay = 0.5f + 0.25f * (float)num2;
			transform.particleSystem.Play();
			transform.gameObject.AddComponent<Ef_DestroyTimer>().life = 5f;
		}
	}

	public void Rare_SRp()
	{
		mjRSp.gameObject.SetActive(value: true);
		mjRSp["Gousei_Moji_SR"].time = 0f;
		mjRSp.Play("Gousei_Moji_SR");
		clrRSp.Clear();
		clrRSp.Play();
		psRSp.Stop();
		psRSp.Clear();
		psRSp.Play();
		tnRS.Clear();
		tnRS.Play();
		int num = 0;
		while (num < 7)
		{
			int num2 = num;
			num++;
			Transform transform = ((Transform)UnityEngine.Object.Instantiate(efSparkLine)).transform;
			transform.parent = mjRSp.transform;
			transform.localPosition = new Vector3(-1.8f + 0.6f * (float)num2, 0f, -0.5f);
			transform.particleSystem.startDelay = 0.5f + 0.25f * (float)num2;
			transform.particleSystem.Play();
			transform.gameObject.AddComponent<Ef_DestroyTimer>().life = 5f;
		}
	}

	public void Rare_UR()
	{
		mjUR.gameObject.SetActive(value: true);
		mjUR["Gousei_Moji_UR"].time = 0f;
		mjUR.Play("Gousei_Moji_UR");
		clrUR.Clear();
		clrUR.Play();
		psUR.Stop();
		psUR.Clear();
		psUR.Play();
		tnUR.Clear();
		tnUR.Play();
		int num = 0;
		while (num < 6)
		{
			int num2 = num;
			num++;
			Transform transform = ((Transform)UnityEngine.Object.Instantiate(efSparkLine)).transform;
			transform.parent = mjUR.transform;
			transform.localPosition = new Vector3(-1.8f + 0.6f * (float)num2, 0f, -0.5f);
			transform.particleSystem.startDelay = 3f + 0.16666f * (float)num2;
			transform.particleSystem.Play();
			transform.gameObject.AddComponent<Ef_DestroyTimer>().life = 5f;
		}
	}

	public void Rare_URp()
	{
	}

	public void Rare_N_Skip()
	{
		if (clrRN.life > 1f)
		{
			mjRN.transform.localPosition = new Vector3(0.78f, 0.1f, 2.5f);
			mjRN.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
			mjRN.gameObject.SetActive(value: true);
			mjRN["Gousei_Moji"].time = 0f;
			mjRN.Play("Gousei_Moji");
			clrRN.Clear();
			clrRN.Play();
		}
	}

	public void Rare_Np_Skip()
	{
		if (clrRNp.life > 1f)
		{
			mjRNp.transform.localPosition = new Vector3(0.73f, 0.1f, 2.5f);
			mjRNp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			mjRNp.gameObject.SetActive(value: true);
			mjRNp["Gousei_Moji"].time = 0f;
			mjRNp.Play("Gousei_Moji");
			clrRNp.Clear();
			clrRNp.Play();
		}
	}

	public void Rare_R_Skip()
	{
		if (clrRR.life > 1f)
		{
			mjRR.transform.localPosition = new Vector3(0.82f, 0.1f, 2.5f);
			mjRR.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
			mjRR.gameObject.SetActive(value: true);
			mjRR["Gousei_Moji"].time = 0f;
			mjRR.Play("Gousei_Moji");
			clrRR.Clear();
			clrRR.Play();
		}
	}

	public void Rare_Rp_Skip()
	{
		if (clrRRp.life > 1f)
		{
			mjRRp.transform.localPosition = new Vector3(0.72f, 0.1f, 2.5f);
			mjRRp.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
			mjRRp.gameObject.SetActive(value: true);
			mjRRp["Gousei_Moji"].time = 0f;
			mjRRp.Play("Gousei_Moji");
			clrRRp.Clear();
			clrRRp.Play();
		}
	}

	public void Rare_SR_Skip()
	{
		if (clrRS.life > 1f)
		{
			mjRS.transform.localPosition = new Vector3(0.85f, 0.1f, 2.5f);
			mjRS.transform.localScale = new Vector3(0.34f, 0.34f, 0.34f);
			mjRS.gameObject.SetActive(value: true);
			mjRS["Gousei_Moji_SR"].time = 0f;
			mjRS.Play("Gousei_Moji_SR");
			clrRS.Clear();
			clrRS.Play();
			tnRS.Play();
		}
	}

	public void Rare_SRp_Skip()
	{
		if (clrRSp.life > 1f)
		{
			mjRSp.transform.localPosition = new Vector3(0.85f, 0.1f, 2.5f);
			mjRSp.transform.localScale = new Vector3(0.36f, 0.36f, 0.4f);
			mjRSp.gameObject.SetActive(value: true);
			mjRSp["Gousei_Moji_SR"].time = 0f;
			mjRSp.Play("Gousei_Moji_SR");
			clrRSp.Clear();
			clrRSp.Play();
			tnRS.Play();
		}
	}

	public void Rare_UR_Skip()
	{
		if (clrUR.life > 1f)
		{
			mjUR.transform.localPosition = new Vector3(0.85f, 0.1f, 2.5f);
			mjUR.transform.localScale = new Vector3(0.36f, 0.36f, 0.4f);
			mjUR.gameObject.SetActive(value: true);
			mjUR["Gousei_Moji_UR"].time = 0f;
			mjUR.Play("Gousei_Moji_UR");
			clrUR.Clear();
			clrUR.Play();
			tnUR.Play();
		}
	}

	public void Rare_URp_Skip()
	{
	}

	public void CampaignIcon()
	{
		int i = 0;
		GameObject[] array = campaiObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].SetActive(value: true);
			}
		}
	}

	public void CampaignIconEnd()
	{
		int i = 0;
		GameObject[] array = campaiObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array[i])
			{
				array[i].SetActive(value: false);
			}
		}
	}

	private void _playJingle(string sename)
	{
		GameSoundManager.PlaySeJingle(sename, 0, resumeBgm: true);
	}

	private void _playSE(string sename)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		GameSoundManager.PlaySe(sename, 0);
	}

	private void playCompositionSeByRarity(int rare)
	{
		if (rare <= 2)
		{
			_playSE("se_system_composition_s");
		}
		else if (rare <= 4)
		{
			_playSE("se_system_composition_m");
		}
		else if (rare <= 6)
		{
			_playSE("se_system_composition_l");
		}
		else if (rare > 6)
		{
			_playSE("se_system_composition_l");
		}
	}

	private void playEvolutionSeByRarity(int rare)
	{
		if (rare <= 2)
		{
			_playSE("se_system_evolution1");
		}
		else if (rare <= 4)
		{
			_playSE("se_system_evolution1");
		}
		else if (rare <= 6)
		{
			_playSE("se_system_evolution2");
		}
		else if (rare > 6)
		{
			_playSE("se_system_evolution2");
		}
	}

	private void playItemAcquireSeByRarity(int rare)
	{
		if (rare <= 2)
		{
			_playJingle("se_system_new_item");
		}
		else if (rare <= 4)
		{
			_playJingle("se_system_new_item");
		}
		else if (rare <= 6)
		{
			_playJingle("se_system_new_item2");
		}
		else if (rare > 6)
		{
			_playJingle("se_system_new_item2");
		}
	}

	private void playJingleByRarity(int rare)
	{
		if (rare <= 2)
		{
			_playJingle("Card_Get_Normal");
		}
		else if (rare <= 4)
		{
			_playJingle("Card_Get_Rare");
		}
		else if (rare <= 6)
		{
			_playJingle("Card_Get_SRare");
		}
		else if (rare > 6)
		{
			_playJingle("Card_Get_URare");
		}
	}

	public void TraitIcon()
	{
		TraitIcon(traitSpriteName);
	}

	public void TraitIcon(string traitSpriteName)
	{
		_0024TraitIcon_0024locals_002414327 _0024TraitIcon_0024locals_0024 = new _0024TraitIcon_0024locals_002414327();
		trait.gameObject.SetActive(value: true);
		UISprite componentInChildren = trait.GetComponentInChildren<UISprite>();
		if (componentInChildren == null)
		{
			trait.gameObject.SetActive(value: false);
			return;
		}
		UIBasicUtility.SetSprite(componentInChildren, traitSpriteName, null, show: true);
		_0024TraitIcon_0024locals_0024._0024tweenA = trait.gameObject.AddComponent<TweenAlpha>();
		_0024TraitIcon_0024locals_0024._0024tweenA.method = UITweener.Method.EaseInOut;
		_0024TraitIcon_0024locals_0024._0024tweenA.alpha = 0f;
		_0024TraitIcon_0024locals_0024._0024tweenA._from = 0f;
		_0024TraitIcon_0024locals_0024._0024tweenA.to = 1f;
		_0024TraitIcon_0024locals_0024._0024tweenA.delay = 0f;
		_0024TraitIcon_0024locals_0024._0024tweenA.duration = 0.6f;
		_0024TraitIcon_0024locals_0024._0024tweenA.onFinished = new _0024TraitIcon_0024closure_00242953(this, _0024TraitIcon_0024locals_0024).Invoke;
		TweenScale tweenScale = trait.gameObject.AddComponent<TweenScale>();
		tweenScale.method = UITweener.Method.BounceOut;
		tweenScale._from = Vector3.zero;
		tweenScale.to = Vector3.one;
		tweenScale.delay = 0f;
		tweenScale.duration = 0.23f;
	}

	public void TraitIconHide()
	{
		TweenAlpha tweenAlpha = trait.gameObject.AddComponent<TweenAlpha>();
		tweenAlpha.method = UITweener.Method.EaseInOut;
		tweenAlpha.alpha = 1f;
		tweenAlpha._from = 1f;
		tweenAlpha.to = 0f;
		tweenAlpha.delay = 0f;
		tweenAlpha.duration = 0.7f;
	}

	public void AtkValue()
	{
		AtkValue(atkValue);
	}

	public void AtkValue(int number)
	{
		PixelToMeshFromNum component = mjAtk.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjAtk.gameObject.SetActive(value: true);
			mjAtk.Play("Gousei_Moji_AtkHp");
			clrAtk.Clear();
			clrAtk.Play();
		}
	}

	public void AtkValueFix()
	{
		AtkValueFix(atkValue);
	}

	public void AtkValueFix(int number)
	{
		PixelToMeshFromNum component = mjAtk.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjAtk.gameObject.SetActive(value: true);
			mjAtk.Play("Gousei_Moji_AtkHp");
			mjAtk["Gousei_Moji_AtkHp"].time = 1f;
			mjAtk.Stop();
			clrAtk.Clear();
			clrAtk.Play();
		}
	}

	public void AtkValueUp()
	{
		AtkValueUp(atkValue);
	}

	public void AtkValueUp(int number)
	{
		PixelToMeshFromNum component = mjAtk.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjAtk.gameObject.SetActive(value: true);
			mjAtk["Gousei_Moji_AtkHp_Up"].time = 0f;
			mjAtk.Play("Gousei_Moji_AtkHp_Up");
			clrAtk.Clear();
			clrAtk.Play();
		}
	}

	public void AtkValueHide()
	{
		clrAtk.life = 0.7f;
	}

	public void HpValue()
	{
		HpValue(hpValue);
	}

	public void HpValue(int number)
	{
		PixelToMeshFromNum component = mjHp.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjHp.gameObject.SetActive(value: true);
			mjHp.Play("Gousei_Moji_AtkHp");
			clrHp.Clear();
			clrHp.Play();
		}
	}

	public void HpValueFix()
	{
		HpValueFix(hpValue);
	}

	public void HpValueFix(int number)
	{
		PixelToMeshFromNum component = mjHp.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjHp.gameObject.SetActive(value: true);
			mjHp.Play("Gousei_Moji_AtkHp");
			mjHp["Gousei_Moji_AtkHp"].time = 1f;
			mjHp.Stop();
			clrHp.Clear();
			clrHp.Play();
		}
	}

	public void HpValueUp()
	{
		HpValueUp(hpValue);
	}

	public void HpValueUp(int number)
	{
		PixelToMeshFromNum component = mjHp.GetComponent<PixelToMeshFromNum>();
		if ((bool)component)
		{
			component.number = number;
			mjHp.gameObject.SetActive(value: true);
			mjHp["Gousei_Moji_AtkHp_Up"].time = 0f;
			mjHp.Play("Gousei_Moji_AtkHp_Up");
			clrHp.Clear();
			clrHp.Play();
		}
	}

	public void HpValueHide()
	{
		clrHp.life = 0.7f;
	}

	public void CameraRight()
	{
		camAnm.Fade2Next("Gousei_Camera_r", "Gousei_Camera_rl", 0.5f);
	}

	public void CameraRightForce()
	{
		camAnm.CrossFade("Gousei_Camera_rl", 1f);
	}

	public void WhiteFadeOut()
	{
		efFade = true;
	}

	public void WhiteFadeIn()
	{
		efFade = false;
	}

	public void OnDestroy()
	{
		if (curModel != null)
		{
			UnityEngine.Object.Destroy(curModel);
		}
		if (wpnObj != null)
		{
			UnityEngine.Object.Destroy(wpnObj.gameObject);
		}
		if (petObj != null)
		{
			UnityEngine.Object.Destroy(petObj.gameObject);
		}
		if (arrSzFlare != null)
		{
			int num = 0;
			int length = arrSzFlare.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				GameObject[] array = arrSzFlare;
				if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != null)
				{
					GameObject[] array2 = arrSzFlare;
					UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
				}
			}
		}
		if (efFadeMat != null)
		{
			UnityEngine.Object.Destroy(efFadeMat);
		}
		if (campaiObjs == null)
		{
			return;
		}
		int num2 = 0;
		int length2 = campaiObjs.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length2)
		{
			int index2 = num2;
			num2++;
			GameObject[] array3 = campaiObjs;
			if (array3[RuntimeServices.NormalizeArrayIndex(array3, index2)] != null)
			{
				GameObject[] array4 = campaiObjs;
				UnityEngine.Object.Destroy(array4[RuntimeServices.NormalizeArrayIndex(array4, index2)]);
			}
		}
	}

	internal void _0024PutMapet_0024closure_00242948(GameObject go)
	{
		curModel = go;
		if (!(curModel == null))
		{
			petObj = curModel.transform;
			petObj.parent = transform;
			petObj.localPosition = new Vector3(0f, 0f, 0f);
			petObj.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
			curModel = petObj.gameObject;
			NGUITools.SetLayer(curModel, gameObject.layer);
			if ((bool)curModel.GetComponent<AIControl>())
			{
				curModel.GetComponent<AIControl>().enabled = false;
			}
		}
	}

	internal void _0024_0024PutWeapon_0024closure_00242949_0024closure_00242950(GameObject go2)
	{
		if ((bool)go2)
		{
			go2.transform.parent = curModel.transform;
			go2.transform.localPosition = new Vector3(0f, 0.4f, -0.6f);
			go2.transform.localRotation = Quaternion.Euler(300f, 300f, 50f);
			if (gameObject != null)
			{
				NGUITools.SetLayer(go2, gameObject.layer);
			}
		}
	}

	internal void _0024_0024PutWeapon_0024closure_00242949_0024closure_00242951(GameObject go3)
	{
		if ((bool)go3)
		{
			curModel.transform.localRotation = Quaternion.Euler(120f, 300f, 50f);
			go3.transform.parent = curModel.transform;
			go3.transform.localPosition = new Vector3(0f, -0.4f, 0.6f);
			go3.transform.localRotation = Quaternion.Euler(0f, 270f, 270f);
			if (gameObject != null)
			{
				NGUITools.SetLayer(go3, gameObject.layer);
			}
		}
	}

	internal void _0024_0024PutWeapon_0024closure_00242949_0024closure_00242952(GameObject go4)
	{
		if ((bool)go4)
		{
			go4.transform.parent = curModel.transform;
			go4.transform.localPosition = new Vector3(0.5f, 0.4f, 0f);
			go4.transform.localRotation = Quaternion.Euler(320f, 240f, 130f);
			if (gameObject != null)
			{
				NGUITools.SetLayer(go4, gameObject.layer);
			}
		}
	}
}
