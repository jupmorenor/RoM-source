using System;
using Boo.Lang.Runtime;
using S540;
using UnityEngine;

[Serializable]
public class GouseiBase : S540Base
{
	private int numOf;

	private int[] arrID;

	private string[] arrName;

	private string[] arrSprName;

	private int[] arrEle;

	private int[] arrRare;

	private int[] arrLv;

	private bool[] arrFav;

	private int[] arrNo;

	private Transform[] arrWepIcon;

	private int selNo;

	private int[] arrSelNo;

	private Transform selMark;

	private Transform[] arrSelMark;

	private Transform scnRoot;

	private Transform uiRoot;

	private Transform winIcon;

	private UIDynamicFontLabel uiWinName;

	private UIDynamicFontLabel uiWinLvMax;

	private UIDynamicFontLabel uiWinLv;

	private UIDynamicFontLabel uiWinExp;

	private UISlider uiWinExpGauge;

	private UIDynamicFontLabel uiWinATK;

	private UIDynamicFontLabel uiWinHP;

	private Transform winSkillA;

	private UIDynamicFontLabel uiWinSklA;

	private UIDynamicFontLabel uiWinSklALv;

	private UIDynamicFontLabel uiWinSklAName;

	private UISprite uiWinSklAIcn;

	private UISprite uiWinSklAIcnBG;

	private Transform winSkillD;

	private UIDynamicFontLabel uiWinSklD;

	private UIDynamicFontLabel uiWinSklDLv;

	private UIDynamicFontLabel uiWinSklDName;

	private UISprite uiWinSklDIcn;

	private UISprite uiWinSklDIcnBG;

	private Transform winSkillP;

	private UIDynamicFontLabel uiWinSklP;

	private UIDynamicFontLabel uiWinSklPLv;

	private UIDynamicFontLabel uiWinSklPName;

	private bool wepAnim;

	private Transform weaponObj;

	private Transform[] arrSziIcon;

	public GouseiBase()
	{
		numOf = 105;
	}

	public override void Update()
	{
		if (wepAnim)
		{
			weaponObj.transform.localRotation = Quaternion.Euler(0f, 20f * Time.deltaTime, 0f) * weaponObj.transform.localRotation;
		}
	}

	public void Init()
	{
		scnRoot = GameObject.Find("Gousei 3D").transform;
		scnRoot.gameObject.SetActive(value: false);
		uiRoot = GameObject.Find("UI Root (2D)").transform;
		SetTestData();
		SetWepList();
		SetWindowUI(uiRoot.Find("Camera/10 GouseiBaseSelect/Panel/AnchorCenter/Window"));
		InfoWinUpdate();
	}

	public void SetTestData()
	{
		arrID = new int[200];
		string empty = string.Empty;
		arrName = new string[200]
		{
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty
		};
		arrSprName = new string[200]
		{
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty,
			empty, empty, empty, empty, empty, empty, empty, empty, empty, empty
		};
		arrEle = new int[200];
		arrRare = new int[200];
		arrLv = new int[200];
		bool flag = false;
		arrFav = new bool[200]
		{
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag,
			flag, flag, flag, flag, flag, flag, flag, flag, flag, flag
		};
		arrNo = new int[200];
		GameObject gameObject = new GameObject();
		Transform transform = gameObject.transform;
		arrWepIcon = new Transform[200]
		{
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform,
			transform, transform, transform, transform, transform, transform, transform, transform, transform, transform
		};
		arrSziIcon = new Transform[5] { transform, transform, transform, transform, transform };
		UnityEngine.Object.Destroy(gameObject);
		Transform transform2 = uiRoot.Find("Camera/10 GouseiBaseSelect/Panel/AnchorCenter/ScrollList/Table");
		int num = 0;
		int num2 = numOf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			int[] array = arrID;
			array[RuntimeServices.NormalizeArrayIndex(array, num3)] = UnityEngine.Random.Range(0, 3);
			string[] array2 = arrName;
			int num4 = RuntimeServices.NormalizeArrayIndex(array2, num3);
			int[] array3 = arrID;
			array2[num4] = Name(array3[RuntimeServices.NormalizeArrayIndex(array3, num3)]);
			string[] array4 = arrSprName;
			int num5 = RuntimeServices.NormalizeArrayIndex(array4, num3);
			int[] array5 = arrID;
			array4[num5] = SprName(array5[RuntimeServices.NormalizeArrayIndex(array5, num3)]);
			int[] array6 = arrEle;
			array6[RuntimeServices.NormalizeArrayIndex(array6, num3)] = UnityEngine.Random.Range(0, 4);
			int[] array7 = arrRare;
			array7[RuntimeServices.NormalizeArrayIndex(array7, num3)] = UnityEngine.Random.Range(0, 6);
			int[] array8 = arrLv;
			array8[RuntimeServices.NormalizeArrayIndex(array8, num3)] = UnityEngine.Random.Range(0, 101);
			bool[] array9 = arrFav;
			ref bool reference = ref array9[RuntimeServices.NormalizeArrayIndex(array9, num3)];
			reference = UnityEngine.Random.Range(0, 3) > 1;
			int[] array10 = arrNo;
			array10[RuntimeServices.NormalizeArrayIndex(array10, num3)] = num3;
		}
	}

	public string Name(int id)
	{
		return id switch
		{
			0 => "武器の名前01", 
			1 => "武器の名前02", 
			2 => "武器の名前03", 
			3 => "武器の名前04", 
			4 => "武器の名前05", 
			5 => "武器の名前06", 
			6 => "武器の名前07", 
			7 => "武器の名前08", 
			_ => null, 
		};
	}

	public string SprName(int id)
	{
		return id switch
		{
			0 => "W00_0002", 
			1 => "W00_0003", 
			2 => "W01_0002", 
			3 => "w01_0003", 
			4 => "W03_0002", 
			5 => "W03_0003", 
			6 => "W04_0002", 
			7 => "W04_0003", 
			_ => null, 
		};
	}

	public string MsgName(int no)
	{
		string lhs = "W";
		if (no < 100)
		{
			lhs += "0";
		}
		if (no < 10)
		{
			lhs += "0";
		}
		return lhs + no;
	}

	public void SetWindowUI(Transform window)
	{
		winIcon = window.Find("WeaponIcon/WeaponIcon");
		uiWinName = window.Find("WeaponName/TextWeaponName").GetComponent<UIDynamicFontLabel>();
		uiWinLvMax = window.Find("WeaponInfo/TextWeaponLvMax").GetComponent<UIDynamicFontLabel>();
		uiWinLv = window.Find("WeaponInfo/TextWeaponLvNum").GetComponent<UIDynamicFontLabel>();
		uiWinExp = window.Find("WeaponInfo/TextWeaponExpNum").GetComponent<UIDynamicFontLabel>();
		uiWinExpGauge = window.Find("WeaponInfo/WeaponExpBar").GetComponent<UISlider>();
		uiWinATK = window.Find("WeaponInfo/TextWeaponAtkNum").GetComponent<UIDynamicFontLabel>();
		uiWinHP = window.Find("WeaponInfo/TextWeaponHpNum").GetComponent<UIDynamicFontLabel>();
		winSkillA = window.Find("WeaponSkillA");
		uiWinSklA = winSkillA.Find("TextIndexWeaponSkillA").GetComponent<UIDynamicFontLabel>();
		uiWinSklALv = winSkillA.Find("TextWeaponSkillALv").GetComponent<UIDynamicFontLabel>();
		uiWinSklAName = winSkillA.Find("TextWeaponSkillAName").GetComponent<UIDynamicFontLabel>();
		uiWinSklAIcn = winSkillA.Find("WeaponSkillAIcon").GetComponent<UISprite>();
		uiWinSklAIcnBG = winSkillA.Find("WeaponSkillAIconBG").GetComponent<UISprite>();
		winSkillD = window.Find("WeaponSkillD");
		uiWinSklD = winSkillD.Find("TextIndexWeaponSkillD").GetComponent<UIDynamicFontLabel>();
		uiWinSklDLv = winSkillD.Find("TextWeaponSkillDLv").GetComponent<UIDynamicFontLabel>();
		uiWinSklDName = winSkillD.Find("TextWeaponSkillDName").GetComponent<UIDynamicFontLabel>();
		uiWinSklDIcn = winSkillD.Find("WeaponSkillDIcon").GetComponent<UISprite>();
		uiWinSklDIcnBG = winSkillD.Find("WeaponSkillDIconBG").GetComponent<UISprite>();
		winSkillP = window.Find("WeaponSkillP");
		uiWinSklP = winSkillP.Find("TextIndexWeaponSkillP").GetComponent<UIDynamicFontLabel>();
		uiWinSklPLv = winSkillP.Find("TextWeaponSkillPLv").GetComponent<UIDynamicFontLabel>();
		uiWinSklPName = winSkillP.Find("TextWeaponSkillPName").GetComponent<UIDynamicFontLabel>();
	}

	public void InfoWinUpdate()
	{
		if (selNo != -1)
		{
			Transform wepIcon = winIcon;
			string[] array = arrSprName;
			string spName = array[RuntimeServices.NormalizeArrayIndex(array, selNo)];
			int[] array2 = arrEle;
			int el = array2[RuntimeServices.NormalizeArrayIndex(array2, selNo)];
			int[] array3 = arrRare;
			int rare = array3[RuntimeServices.NormalizeArrayIndex(array3, selNo)];
			bool[] array4 = arrFav;
			WpnIcnUpdate(wepIcon, spName, el, rare, -1, array4[RuntimeServices.NormalizeArrayIndex(array4, selNo)]);
			UIDynamicFontLabel uIDynamicFontLabel = uiWinName;
			string[] array5 = arrName;
			uIDynamicFontLabel.text = array5[RuntimeServices.NormalizeArrayIndex(array5, selNo)];
			uiWinLvMax.text = "/120";
			UIDynamicFontLabel uIDynamicFontLabel2 = uiWinLv;
			string empty = string.Empty;
			int[] array6 = arrLv;
			uIDynamicFontLabel2.text = empty + array6[RuntimeServices.NormalizeArrayIndex(array6, selNo)];
			uiWinExp.text = "9999999";
			uiWinExpGauge.sliderValue = 0.5f;
			uiWinATK.text = "99999";
			uiWinHP.text = "99999";
			winSkillA.gameObject.SetActive(value: true);
			uiWinSklA.text = "天";
			uiWinSklALv.text = "Lv.10";
			uiWinSklAName.text = "フレイムセイバー";
			winSkillD.gameObject.SetActive(value: true);
			uiWinSklD.text = "魔";
			uiWinSklDLv.text = "Lv.10";
			uiWinSklDName.text = "フレイムセイバー";
			winSkillP.gameObject.SetActive(value: true);
			uiWinSklP.text = "援護";
			uiWinSklPLv.text = "Lv.10";
			uiWinSklPName.text = "ラスボス強打";
		}
		else
		{
			WpnIcnUpdate(winIcon, string.Empty, -1, -1, -1, fav: false);
			uiWinName.text = string.Empty;
			uiWinLvMax.text = string.Empty;
			uiWinLv.text = string.Empty;
			uiWinExp.text = string.Empty;
			uiWinExpGauge.sliderValue = 0f;
			uiWinATK.text = string.Empty;
			uiWinHP.text = string.Empty;
			uiWinSklA.text = string.Empty;
			uiWinSklALv.text = string.Empty;
			uiWinSklAName.text = string.Empty;
			winSkillA.gameObject.SetActive(value: false);
			winSkillD.gameObject.SetActive(value: false);
			winSkillP.gameObject.SetActive(value: false);
		}
	}

	public void SetWepList()
	{
		Transform transform = uiRoot.Find("Camera/10 GouseiBaseSelect/Panel/AnchorCenter/ScrollList");
		Transform transform2 = transform.Find("Table");
		GameObject gameObject = transform2.Find("ListContents").gameObject;
		GameObject gameObject2 = transform2.Find("SelectMain").gameObject;
		GameObject gameObject3 = transform2.Find("SelectSub").gameObject;
		int num = 0;
		int num2 = numOf;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(gameObject);
			gameObject4.transform.parent = transform2;
			gameObject4.transform.localScale = Vector3.one;
			Transform[] array = arrWepIcon;
			int num4 = RuntimeServices.NormalizeArrayIndex(array, num3);
			string[] array2 = arrSprName;
			string spName = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
			int[] array3 = arrEle;
			int el = array3[RuntimeServices.NormalizeArrayIndex(array3, num3)];
			int[] array4 = arrRare;
			int rare = array4[RuntimeServices.NormalizeArrayIndex(array4, num3)];
			int[] array5 = arrLv;
			int lv = array5[RuntimeServices.NormalizeArrayIndex(array5, num3)];
			bool[] array6 = arrFav;
			array[num4] = GetWeaponIcon(spName, el, rare, lv, array6[RuntimeServices.NormalizeArrayIndex(array6, num3)], Vector3.zero, 0.7f, gameObject4.transform);
			if (!(MsgName(num3) == string.Empty))
			{
				gameObject4.AddComponent<UIButtonMessage>();
				UIButtonMessage component = gameObject4.GetComponent<UIButtonMessage>();
				component.target = this.gameObject;
				component.functionName = MsgName(num3);
			}
			gameObject4.name = MsgName(num3);
		}
		UITable component2 = transform2.GetComponent<UITable>();
		component2.padding = new Vector2(2f, 2f);
		component2.repositionNow = true;
		UIDraggablePanel component3 = transform.GetComponent<UIDraggablePanel>();
		component3.repositionClipping = true;
		selNo = -1;
		arrSelNo = new int[5] { -1, -1, -1, -1, -1 };
		selMark = ((GameObject)UnityEngine.Object.Instantiate(gameObject2)).transform;
		arrSelMark = new Transform[5]
		{
			((GameObject)UnityEngine.Object.Instantiate(gameObject3)).transform,
			((GameObject)UnityEngine.Object.Instantiate(gameObject3)).transform,
			((GameObject)UnityEngine.Object.Instantiate(gameObject3)).transform,
			((GameObject)UnityEngine.Object.Instantiate(gameObject3)).transform,
			((GameObject)UnityEngine.Object.Instantiate(gameObject3)).transform
		};
		int num5 = 0;
		while (num5 < 5)
		{
			int index = num5;
			num5++;
			Transform[] array7 = arrSelMark;
			array7[RuntimeServices.NormalizeArrayIndex(array7, index)].gameObject.SetActive(value: false);
		}
		gameObject.SetActive(value: false);
		gameObject2.SetActive(value: false);
		gameObject3.SetActive(value: false);
	}

	public Transform GetWeaponIcon(string spName, int el, int rare, int lv, bool fav, Vector3 pos, float size, Transform parent)
	{
		Transform transform = ((GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("Prefab/GUI/WeaponIcon", typeof(GameObject)))).transform;
		WpnIcnUpdate(transform, spName, el, rare, lv, fav);
		transform.parent = parent;
		transform.localPosition = pos;
		transform.localScale = new Vector3(size, size, size);
		return transform;
	}

	public void WpnIcnUpdate(Transform wepIcon, string spName, int el, int rare, int lv, bool fav)
	{
		Transform transform = wepIcon.Find("WeaponIcon/Weapon");
		UISprite component = transform.GetComponent<UISprite>();
		if (!(spName == string.Empty))
		{
			transform.gameObject.SetActive(value: true);
			component.spriteName = spName;
		}
		else
		{
			transform.gameObject.SetActive(value: false);
		}
		Transform transform2 = wepIcon.Find("WeaponIcon/Weapon_Element");
		UISprite component2 = transform2.GetComponent<UISprite>();
		switch (el)
		{
		case 0:
			transform2.gameObject.SetActive(value: true);
			component2.spriteName = "weapon_bg_earth";
			break;
		case 1:
			transform2.gameObject.SetActive(value: true);
			component2.spriteName = "weapon_bg_water";
			break;
		case 2:
			transform2.gameObject.SetActive(value: true);
			component2.spriteName = "weapon_bg_fire";
			break;
		case 3:
			transform2.gameObject.SetActive(value: true);
			component2.spriteName = "weapon_bg_wind";
			break;
		case 4:
			transform2.gameObject.SetActive(value: true);
			component2.spriteName = "weapon_bg_custom";
			break;
		default:
			transform2.gameObject.SetActive(value: false);
			break;
		}
		Transform transform3 = wepIcon.Find("WeaponIcon/Weapon_Rank");
		UISprite component3 = transform3.GetComponent<UISprite>();
		switch (rare)
		{
		case 0:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_n";
			break;
		case 1:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_n_plus";
			break;
		case 2:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_r";
			break;
		case 3:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_r_plus";
			break;
		case 4:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_sr";
			break;
		case 5:
			transform3.gameObject.SetActive(value: true);
			component3.spriteName = "rank_sr_plus";
			break;
		default:
			transform3.gameObject.SetActive(value: false);
			break;
		}
		UIDynamicFontLabel component4 = wepIcon.Find("WeaponIcon/Level/Label").GetComponent<UIDynamicFontLabel>();
		if (lv > 0)
		{
			string lhs = "Lv.";
			if (lv < 100)
			{
				lhs += "0";
			}
			if (lv < 10)
			{
				lhs += "0";
			}
			lhs += lv;
			component4.text = lhs;
		}
		else
		{
			component4.text = string.Empty;
		}
		wepIcon.Find("WeaponIcon/Favorite").gameObject.SetActive(fav);
	}

	public void SelWepon(int no)
	{
		if (selNo == no)
		{
			selNo = -1;
			selMark.gameObject.SetActive(value: false);
			int num = 0;
			while (num < 5)
			{
				int index = num;
				num++;
				int[] array = arrSelNo;
				array[RuntimeServices.NormalizeArrayIndex(array, index)] = -1;
				Transform[] array2 = arrSelMark;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].gameObject.SetActive(value: false);
			}
			InfoWinUpdate();
			return;
		}
		if (selNo == -1)
		{
			selNo = no;
			selMark.gameObject.SetActive(value: true);
			Transform obj = selMark;
			Transform[] array3 = arrWepIcon;
			obj.parent = array3[RuntimeServices.NormalizeArrayIndex(array3, no)];
			selMark.localPosition = new Vector3(0f, 0f, -100f);
			selMark.localScale = new Vector3(200f, 200f, 200f);
			InfoWinUpdate();
			return;
		}
		bool flag = false;
		int num2 = 0;
		while (num2 < 5)
		{
			int index2 = num2;
			num2++;
			int[] array4 = arrSelNo;
			if (array4[RuntimeServices.NormalizeArrayIndex(array4, index2)] == no)
			{
				int[] array5 = arrSelNo;
				array5[RuntimeServices.NormalizeArrayIndex(array5, index2)] = -1;
				Transform[] array6 = arrSelMark;
				array6[RuntimeServices.NormalizeArrayIndex(array6, index2)].gameObject.SetActive(value: false);
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		int num3 = 0;
		while (num3 < 5)
		{
			int index3 = num3;
			num3++;
			int[] array7 = arrSelNo;
			if (array7[RuntimeServices.NormalizeArrayIndex(array7, index3)] == -1 && !flag)
			{
				int[] array8 = arrSelNo;
				array8[RuntimeServices.NormalizeArrayIndex(array8, index3)] = no;
				Transform[] array9 = arrSelMark;
				array9[RuntimeServices.NormalizeArrayIndex(array9, index3)].gameObject.SetActive(value: true);
				Transform[] array10 = arrSelMark;
				Transform obj2 = array10[RuntimeServices.NormalizeArrayIndex(array10, index3)];
				Transform[] array11 = arrWepIcon;
				obj2.parent = array11[RuntimeServices.NormalizeArrayIndex(array11, no)];
				Transform[] array12 = arrSelMark;
				array12[RuntimeServices.NormalizeArrayIndex(array12, index3)].localPosition = new Vector3(0f, 0f, -100f);
				Transform[] array13 = arrSelMark;
				array13[RuntimeServices.NormalizeArrayIndex(array13, index3)].localScale = new Vector3(200f, 200f, 200f);
				flag = true;
			}
		}
	}

	public void GouseiSozai()
	{
		Transform transform = uiRoot.Find("Camera/20 GouseiStart/Panel/AnchorCenter/GouseiSozai/SozaiIcon");
		Transform transform2 = transform.Find("Weapon11/WeaponIcon");
		Transform transform3 = transform.Find("Weapon12/WeaponIcon");
		Transform transform4 = transform.Find("Weapon13/WeaponIcon");
		Transform transform5 = transform.Find("Weapon14/WeaponIcon");
		Transform transform6 = transform.Find("Weapon15/WeaponIcon");
		Transform[] array = new Transform[5] { transform2, transform3, transform4, transform5, transform6 };
		int num = 0;
		while (num < 5)
		{
			int index = num;
			num++;
			int[] array2 = arrSelNo;
			if (array2[RuntimeServices.NormalizeArrayIndex(array2, index)] != -1)
			{
				array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObject.SetActive(value: true);
				int[] array3 = arrSelNo;
				int index2 = array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
				Transform wepIcon = array[RuntimeServices.NormalizeArrayIndex(array, index)];
				string[] array4 = arrSprName;
				string spName = array4[RuntimeServices.NormalizeArrayIndex(array4, index2)];
				int[] array5 = arrEle;
				int el = array5[RuntimeServices.NormalizeArrayIndex(array5, index2)];
				int[] array6 = arrRare;
				int rare = array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
				bool[] array7 = arrFav;
				WpnIcnUpdate(wepIcon, spName, el, rare, -1, array7[RuntimeServices.NormalizeArrayIndex(array7, index2)]);
			}
			else
			{
				array[RuntimeServices.NormalizeArrayIndex(array, index)].gameObject.SetActive(value: false);
			}
		}
	}

	public void GouseiScene()
	{
		scnRoot.gameObject.SetActive(value: true);
		Transform transform = scnRoot.Find("GouseiCamera");
		Transform transform2 = scnRoot.Find("GouseiSozai");
		Transform transform3 = scnRoot.Find("Effects/Ef_Spark");
		Transform transform4 = scnRoot.Find("Effects/Ef_Rainbow");
		string[] array = arrSprName;
		string rhs = array[RuntimeServices.NormalizeArrayIndex(array, selNo)] + "_model";
		weaponObj = new GameObject("Weapon Root").transform;
		weaponObj.parent = scnRoot;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("Prefab/Weapons/" + rhs, typeof(GameObject)));
		if (gameObject == null)
		{
			return;
		}
		gameObject.transform.parent = weaponObj;
		gameObject.transform.localPosition = new Vector3(0f, 1.5f, 0.2f);
		gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-150f, 0f, 0f));
		wepAnim = true;
		Transform[] array2 = new Transform[5]
		{
			transform2.Find("Sozai01"),
			transform2.Find("Sozai02"),
			transform2.Find("Sozai03"),
			transform2.Find("Sozai04"),
			transform2.Find("Sozai05")
		};
		int num = 0;
		int num2 = 0;
		while (num2 < 5)
		{
			int index = num2;
			num2++;
			int[] array3 = arrSelNo;
			if (array3[RuntimeServices.NormalizeArrayIndex(array3, index)] != -1)
			{
				int[] array4 = arrSelNo;
				int index2 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
				Transform[] array5 = arrSziIcon;
				int num3 = RuntimeServices.NormalizeArrayIndex(array5, num);
				string[] array6 = arrSprName;
				string spName = array6[RuntimeServices.NormalizeArrayIndex(array6, index2)];
				int[] array7 = arrEle;
				int el = array7[RuntimeServices.NormalizeArrayIndex(array7, index2)];
				int[] array8 = arrRare;
				int rare = array8[RuntimeServices.NormalizeArrayIndex(array8, index2)];
				int[] array9 = arrLv;
				int lv = array9[RuntimeServices.NormalizeArrayIndex(array9, index2)];
				bool[] array10 = arrFav;
				array5[num3] = GetWeaponIcon(spName, el, rare, lv, array10[RuntimeServices.NormalizeArrayIndex(array10, index2)], Vector3.zero, 0.01f, array2[RuntimeServices.NormalizeArrayIndex(array2, num)]);
				num = checked(num + 1);
			}
		}
		transform2.animation.Play("Gousei_Sozai");
		transform.animation.Play("Gousei_Camera");
		transform.animation.PlayQueued("Gousei_Camera_l", QueueMode.CompleteOthers);
		transform3.particleSystem.Play();
		transform4.particleSystem.Play();
	}

	public void GouseiSceneEnd()
	{
		int num = 0;
		while (num < 5)
		{
			int index = num;
			num++;
			Transform[] array = arrSziIcon;
			if (!(array[RuntimeServices.NormalizeArrayIndex(array, index)] == null))
			{
				Transform[] array2 = arrSziIcon;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)].gameObject);
			}
		}
		wepAnim = false;
	}

	public void GouseiStart()
	{
		uiRoot.Find("Camera/10 GouseiBaseSelect").gameObject.SetActive(value: false);
		uiRoot.Find("Camera/20 GouseiStart").gameObject.SetActive(value: true);
		SetWindowUI(uiRoot.Find("Camera/20 GouseiStart/Panel/AnchorCenter/Window"));
		InfoWinUpdate();
		GouseiSozai();
	}

	public void Gousei()
	{
		uiRoot.Find("Camera/20 GouseiStart").gameObject.SetActive(value: false);
		uiRoot.Find("Camera/30 Gousei").gameObject.SetActive(value: true);
		GouseiScene();
	}

	public void W000()
	{
		SelWepon(0);
	}

	public void W001()
	{
		SelWepon(1);
	}

	public void W002()
	{
		SelWepon(2);
	}

	public void W003()
	{
		SelWepon(3);
	}

	public void W004()
	{
		SelWepon(4);
	}

	public void W005()
	{
		SelWepon(5);
	}

	public void W006()
	{
		SelWepon(6);
	}

	public void W007()
	{
		SelWepon(7);
	}

	public void W008()
	{
		SelWepon(8);
	}

	public void W009()
	{
		SelWepon(9);
	}

	public void W010()
	{
		SelWepon(10);
	}

	public void W011()
	{
		SelWepon(11);
	}

	public void W012()
	{
		SelWepon(12);
	}

	public void W013()
	{
		SelWepon(13);
	}

	public void W014()
	{
		SelWepon(14);
	}

	public void W015()
	{
		SelWepon(15);
	}

	public void W016()
	{
		SelWepon(16);
	}

	public void W017()
	{
		SelWepon(17);
	}

	public void W018()
	{
		SelWepon(18);
	}

	public void W019()
	{
		SelWepon(19);
	}

	public void W020()
	{
		SelWepon(20);
	}

	public void W021()
	{
		SelWepon(21);
	}

	public void W022()
	{
		SelWepon(22);
	}

	public void W023()
	{
		SelWepon(23);
	}

	public void W024()
	{
		SelWepon(24);
	}

	public void W025()
	{
		SelWepon(25);
	}

	public void W026()
	{
		SelWepon(26);
	}

	public void W027()
	{
		SelWepon(27);
	}

	public void W028()
	{
		SelWepon(28);
	}

	public void W029()
	{
		SelWepon(29);
	}

	public void W030()
	{
		SelWepon(30);
	}

	public void W031()
	{
		SelWepon(31);
	}

	public void W032()
	{
		SelWepon(32);
	}

	public void W033()
	{
		SelWepon(33);
	}

	public void W034()
	{
		SelWepon(34);
	}

	public void W035()
	{
		SelWepon(35);
	}

	public void W036()
	{
		SelWepon(36);
	}

	public void W037()
	{
		SelWepon(37);
	}

	public void W038()
	{
		SelWepon(38);
	}

	public void W039()
	{
		SelWepon(39);
	}

	public void W040()
	{
		SelWepon(40);
	}

	public void W041()
	{
		SelWepon(41);
	}

	public void W042()
	{
		SelWepon(42);
	}

	public void W043()
	{
		SelWepon(43);
	}

	public void W044()
	{
		SelWepon(44);
	}

	public void W045()
	{
		SelWepon(45);
	}

	public void W046()
	{
		SelWepon(46);
	}

	public void W047()
	{
		SelWepon(47);
	}

	public void W048()
	{
		SelWepon(48);
	}

	public void W049()
	{
		SelWepon(49);
	}

	public void W050()
	{
		SelWepon(50);
	}

	public void W051()
	{
		SelWepon(51);
	}

	public void W052()
	{
		SelWepon(52);
	}

	public void W053()
	{
		SelWepon(53);
	}

	public void W054()
	{
		SelWepon(54);
	}

	public void W055()
	{
		SelWepon(55);
	}

	public void W056()
	{
		SelWepon(56);
	}

	public void W057()
	{
		SelWepon(57);
	}

	public void W058()
	{
		SelWepon(58);
	}

	public void W059()
	{
		SelWepon(59);
	}

	public void W060()
	{
		SelWepon(60);
	}

	public void W061()
	{
		SelWepon(61);
	}

	public void W062()
	{
		SelWepon(62);
	}

	public void W063()
	{
		SelWepon(63);
	}

	public void W064()
	{
		SelWepon(64);
	}

	public void W065()
	{
		SelWepon(65);
	}

	public void W066()
	{
		SelWepon(66);
	}

	public void W067()
	{
		SelWepon(67);
	}

	public void W068()
	{
		SelWepon(68);
	}

	public void W069()
	{
		SelWepon(69);
	}

	public void W070()
	{
		SelWepon(70);
	}

	public void W071()
	{
		SelWepon(71);
	}

	public void W072()
	{
		SelWepon(72);
	}

	public void W073()
	{
		SelWepon(73);
	}

	public void W074()
	{
		SelWepon(74);
	}

	public void W075()
	{
		SelWepon(75);
	}

	public void W076()
	{
		SelWepon(76);
	}

	public void W077()
	{
		SelWepon(77);
	}

	public void W078()
	{
		SelWepon(78);
	}

	public void W079()
	{
		SelWepon(79);
	}

	public void W080()
	{
		SelWepon(80);
	}

	public void W081()
	{
		SelWepon(81);
	}

	public void W082()
	{
		SelWepon(82);
	}

	public void W083()
	{
		SelWepon(83);
	}

	public void W084()
	{
		SelWepon(84);
	}

	public void W085()
	{
		SelWepon(85);
	}

	public void W086()
	{
		SelWepon(86);
	}

	public void W087()
	{
		SelWepon(87);
	}

	public void W088()
	{
		SelWepon(88);
	}

	public void W089()
	{
		SelWepon(89);
	}

	public void W090()
	{
		SelWepon(90);
	}

	public void W091()
	{
		SelWepon(91);
	}

	public void W092()
	{
		SelWepon(92);
	}

	public void W093()
	{
		SelWepon(93);
	}

	public void W094()
	{
		SelWepon(94);
	}

	public void W095()
	{
		SelWepon(95);
	}

	public void W096()
	{
		SelWepon(96);
	}

	public void W097()
	{
		SelWepon(97);
	}

	public void W098()
	{
		SelWepon(98);
	}

	public void W099()
	{
		SelWepon(99);
	}

	public void W100()
	{
		SelWepon(100);
	}

	public void W101()
	{
		SelWepon(101);
	}

	public void W102()
	{
		SelWepon(102);
	}

	public void W103()
	{
		SelWepon(103);
	}

	public void W104()
	{
		SelWepon(104);
	}

	public void W105()
	{
		SelWepon(105);
	}

	public void W106()
	{
		SelWepon(106);
	}

	public void W107()
	{
		SelWepon(107);
	}

	public void W108()
	{
		SelWepon(108);
	}

	public void W109()
	{
		SelWepon(109);
	}

	public void W110()
	{
		SelWepon(110);
	}

	public void W111()
	{
		SelWepon(111);
	}

	public void W112()
	{
		SelWepon(112);
	}

	public void W113()
	{
		SelWepon(113);
	}

	public void W114()
	{
		SelWepon(114);
	}

	public void W115()
	{
		SelWepon(115);
	}

	public void W116()
	{
		SelWepon(116);
	}

	public void W117()
	{
		SelWepon(117);
	}

	public void W118()
	{
		SelWepon(118);
	}

	public void W119()
	{
		SelWepon(119);
	}

	public void W120()
	{
		SelWepon(120);
	}

	public void W121()
	{
		SelWepon(121);
	}

	public void W122()
	{
		SelWepon(122);
	}

	public void W123()
	{
		SelWepon(123);
	}

	public void W124()
	{
		SelWepon(124);
	}

	public void W125()
	{
		SelWepon(125);
	}

	public void W126()
	{
		SelWepon(126);
	}

	public void W127()
	{
		SelWepon(127);
	}

	public void W128()
	{
		SelWepon(128);
	}

	public void W129()
	{
		SelWepon(129);
	}

	public void W130()
	{
		SelWepon(130);
	}

	public void W131()
	{
		SelWepon(131);
	}

	public void W132()
	{
		SelWepon(132);
	}

	public void W133()
	{
		SelWepon(133);
	}

	public void W134()
	{
		SelWepon(134);
	}

	public void W135()
	{
		SelWepon(135);
	}

	public void W136()
	{
		SelWepon(136);
	}

	public void W137()
	{
		SelWepon(137);
	}

	public void W138()
	{
		SelWepon(138);
	}

	public void W139()
	{
		SelWepon(139);
	}

	public void W140()
	{
		SelWepon(140);
	}

	public void W141()
	{
		SelWepon(141);
	}

	public void W142()
	{
		SelWepon(142);
	}

	public void W143()
	{
		SelWepon(143);
	}

	public void W144()
	{
		SelWepon(144);
	}

	public void W145()
	{
		SelWepon(145);
	}

	public void W146()
	{
		SelWepon(146);
	}

	public void W147()
	{
		SelWepon(147);
	}

	public void W148()
	{
		SelWepon(148);
	}

	public void W149()
	{
		SelWepon(149);
	}

	public void W150()
	{
		SelWepon(150);
	}

	public void W151()
	{
		SelWepon(151);
	}

	public void W152()
	{
		SelWepon(152);
	}

	public void W153()
	{
		SelWepon(153);
	}

	public void W154()
	{
		SelWepon(154);
	}

	public void W155()
	{
		SelWepon(155);
	}

	public void W156()
	{
		SelWepon(156);
	}

	public void W157()
	{
		SelWepon(157);
	}

	public void W158()
	{
		SelWepon(158);
	}

	public void W159()
	{
		SelWepon(159);
	}

	public void W160()
	{
		SelWepon(160);
	}

	public void W161()
	{
		SelWepon(161);
	}

	public void W162()
	{
		SelWepon(162);
	}

	public void W163()
	{
		SelWepon(163);
	}

	public void W164()
	{
		SelWepon(164);
	}

	public void W165()
	{
		SelWepon(165);
	}

	public void W166()
	{
		SelWepon(166);
	}

	public void W167()
	{
		SelWepon(167);
	}

	public void W168()
	{
		SelWepon(168);
	}

	public void W169()
	{
		SelWepon(169);
	}

	public void W170()
	{
		SelWepon(170);
	}

	public void W171()
	{
		SelWepon(171);
	}

	public void W172()
	{
		SelWepon(172);
	}

	public void W173()
	{
		SelWepon(173);
	}

	public void W174()
	{
		SelWepon(174);
	}

	public void W175()
	{
		SelWepon(175);
	}

	public void W176()
	{
		SelWepon(176);
	}

	public void W177()
	{
		SelWepon(177);
	}

	public void W178()
	{
		SelWepon(178);
	}

	public void W179()
	{
		SelWepon(179);
	}

	public void W180()
	{
		SelWepon(180);
	}

	public void W181()
	{
		SelWepon(181);
	}

	public void W182()
	{
		SelWepon(182);
	}

	public void W183()
	{
		SelWepon(183);
	}

	public void W184()
	{
		SelWepon(184);
	}

	public void W185()
	{
		SelWepon(185);
	}

	public void W186()
	{
		SelWepon(186);
	}

	public void W187()
	{
		SelWepon(187);
	}

	public void W188()
	{
		SelWepon(188);
	}

	public void W189()
	{
		SelWepon(189);
	}

	public void W190()
	{
		SelWepon(190);
	}

	public void W191()
	{
		SelWepon(191);
	}

	public void W192()
	{
		SelWepon(192);
	}

	public void W193()
	{
		SelWepon(193);
	}

	public void W194()
	{
		SelWepon(194);
	}

	public void W195()
	{
		SelWepon(195);
	}

	public void W196()
	{
		SelWepon(196);
	}

	public void W197()
	{
		SelWepon(197);
	}

	public void W198()
	{
		SelWepon(198);
	}

	public void W199()
	{
		SelWepon(199);
	}

	public void W200()
	{
		SelWepon(200);
	}
}
