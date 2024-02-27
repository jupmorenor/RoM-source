using System;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WeaponInfo : UIListItem
{
	[Serializable]
	internal class _0024SetWeaponCore_0024locals_002414493
	{
		internal MWeaponSkills _0024angelSkill;

		internal MWeaponSkills _0024demonSkill;
	}

	[Serializable]
	internal class _0024SetWeaponCore_0024closure_00245019
	{
		internal WeaponInfo _0024this_002415081;

		internal _0024SetWeaponCore_0024locals_002414493 _0024_0024locals_002415082;

		public _0024SetWeaponCore_0024closure_00245019(WeaponInfo _0024this_002415081, _0024SetWeaponCore_0024locals_002414493 _0024_0024locals_002415082)
		{
			this._0024this_002415081 = _0024this_002415081;
			this._0024_0024locals_002415082 = _0024_0024locals_002415082;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024this_002415081.curIconSkill1Sprite.gameObject;
			bool num = _0024this_002415081.curIconSkill1Sprite.spriteName == _0024_0024locals_002415082._0024angelSkill.Icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415082._0024angelSkill.Icon);
			}
			gameObject.SetActive(num);
		}
	}

	[Serializable]
	internal class _0024SetWeaponCore_0024closure_00245020
	{
		internal _0024SetWeaponCore_0024locals_002414493 _0024_0024locals_002415083;

		internal WeaponInfo _0024this_002415084;

		public _0024SetWeaponCore_0024closure_00245020(_0024SetWeaponCore_0024locals_002414493 _0024_0024locals_002415083, WeaponInfo _0024this_002415084)
		{
			this._0024_0024locals_002415083 = _0024_0024locals_002415083;
			this._0024this_002415084 = _0024this_002415084;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024this_002415084.curIconSkill2Sprite.gameObject;
			bool num = _0024this_002415084.curIconSkill2Sprite.spriteName == _0024_0024locals_002415083._0024demonSkill.Icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415083._0024demonSkill.Icon);
			}
			gameObject.SetActive(num);
		}
	}

	public bool deleteIconLevel;

	public GameObject iconPrefab;

	public Transform iconParent;

	public Vector3 iconScale;

	protected WeaponInfo iconInfo;

	public UILabelBase curNameLabel;

	public UILabelBase curExplainLabel;

	public UILabelBase curExplainLabel2;

	public UILabelBase curExpLabel;

	public UILabelBase curNextExpLabel;

	public string levelFormat;

	public UILabelBase curLevelLabel;

	public UILabelBase curMaxLevelLabel;

	public string levelFormat2;

	public UILabelBase curLevelLabel2;

	public UILabelBase curMaxLevelLabel2;

	public string levelFormat3;

	public UILabelBase curLevelLabel3;

	public UILabelBase curMaxLevelLabel3;

	public string levelFormat4;

	public UILabelBase curLevelLabel4;

	public UILabelBase curLimitBreakCountLabel;

	public UILabelBase curLimitBreakCountLimitLabel;

	public UISprite curStyleSprite;

	public UISprite curElemSprite;

	public UILabelBase curTypeLabel;

	public UILabelBase curElemLabel;

	public UISprite curIconSprite;

	public UISprite curIconRankTextSprite;

	public GameObject curIconFramePanel;

	public UISprite curIconNumberSprite;

	public UISlider curExpGaugeBar;

	public UISprite curIconSkillPsvSprite;

	public UILabelBase curSkillPsvLabel;

	public UILabelBase curSkillPsvLvLabel;

	public UILabelBase curSkillPsvLvLabel2;

	public UILabelBase curSkillPsvExplainLabel;

	public UILabelBase curSkillPsvExplainLabel2;

	public UISprite curIconSkill1Sprite;

	public UILabelBase curSkill1Label;

	public UILabelBase curSkill1LvLabel;

	public UILabelBase curSkill1LvLabel2;

	public UILabelBase curSkill1ExplainLabel;

	public UILabelBase curSkill1ExplainLabel2;

	public string cooldownFormat1;

	public UILabelBase curSkill1CoolDownLabel;

	public UISprite curIconSkill2Sprite;

	public UILabelBase curSkill2Label;

	public UILabelBase curSkill2LvLabel;

	public UILabelBase curSkill2LvLabel2;

	public UILabelBase curSkill2ExplainLabel;

	public UILabelBase curSkill2ExplainLabel2;

	public string cooldownFormat2;

	public UILabelBase curSkill2CoolDownLabel;

	public UILabelBase curAttackPointLabel;

	public UILabelBase curHitPointLabel;

	public UILabelBase curAttackPointPlusLabel;

	public UILabelBase curHitPointPlusLabel;

	public UILabelBase curSumPlusLabel;

	public UILabelBase curBuyPriceLabel;

	public UILabelBase curSellPriceLabel;

	public UILabelBase curAttackPointLabel2;

	public UILabelBase curHitPointLabel2;

	public UILabelBase curAttackPointPlusLabel2;

	public UILabelBase curHitPointPlusLabel2;

	public UILabelBase curBuyPriceLabel2;

	public UILabelBase curSellPriceLabel2;

	public UILabelBase totalAttackPointLabel;

	public UILabelBase totalHitPointLabel;

	public UILabelBase battleAttackPointLabel;

	public UILabelBase battleHitPointLabel;

	public UILabelBase totalAttackPointLabel2;

	public UILabelBase totalHitPointLabel2;

	public UILabelBase battleAttackPointLabel2;

	public UILabelBase battleHitPointLabel2;

	public UILabelBase fireLabel;

	public UILabelBase waterLabel;

	public UILabelBase airLabel;

	public UILabelBase earthLabel;

	public bool showParametaDisalbeItem;

	private RespWeapon setWeapon;

	private RespWeapon[] setTotalWeaponArray2;

	private RespWeapon lastWeapon;

	private RespWeapon[] lastTotalWeaponArray;

	private bool init;

	private bool initArray;

	public UIItemSupportSwitcher supportInfo;

	public UILabelBase deckCostLabel;

	public UISprite traitSprite;

	private bool isDeletedIconLevel;

	public RespWeapon LastWeapon => lastWeapon;

	public RespWeapon[] LastTotalWeaponArray => lastTotalWeaponArray;

	public bool isSetWeapon
	{
		get
		{
			bool num = setWeapon == null;
			if (num)
			{
				num = lastWeapon != null;
			}
			return num;
		}
	}

	public WeaponInfo IconInfo => iconInfo;

	public bool ShowParametaDisalbeItem
	{
		get
		{
			return showParametaDisalbeItem;
		}
		set
		{
			showParametaDisalbeItem = value;
		}
	}

	public WeaponInfo()
	{
		iconScale = Vector3.one;
		levelFormat = "{0:00}";
		levelFormat2 = "{0:00}";
		levelFormat3 = "{0:00}";
		levelFormat4 = "{0}/{1}";
		cooldownFormat1 = "クールダウン：{0:F1}秒";
		cooldownFormat2 = "クールダウン：{0:F1}秒";
		showParametaDisalbeItem = true;
	}

	private void Awake()
	{
		copyState.copyAlphaTarget = true;
		UIListItem.InitAlphaLoopCtrls(this);
		StartAlphaLoopCtrl();
		if ((bool)iconPrefab && iconInfo == null)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(iconPrefab);
			if ((bool)gameObject)
			{
				gameObject.transform.parent = iconParent;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = iconScale;
				iconInfo = ExtensionsModule.SetComponent<WeaponInfo>(gameObject);
			}
		}
	}

	public void Start()
	{
		if (!init)
		{
			SetWeaponCore(null);
		}
		if (!initArray)
		{
			object obj = null;
			object obj2 = obj;
			if (!(obj2 is RespWeapon[]))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(RespWeapon[]));
			}
			SetTotalWeaponStatusCore((RespWeapon[])obj2);
		}
		if (deleteIconLevel && (bool)iconInfo && !isDeletedIconLevel)
		{
			isDeletedIconLevel = true;
			iconInfo.DestroyLevel();
		}
	}

	public void Update()
	{
		UpdateAlphaLoopCtrl();
		if (forDebugCurrentItemPrint)
		{
			MonoBehaviour.print(new StringBuilder("WeaponInfo(").Append(lastWeapon).Append(")").ToString());
			forDebugCurrentItemPrint = false;
		}
		if (setWeapon != null)
		{
			SetWeaponCore(setWeapon);
			setWeapon = null;
		}
	}

	public void ResetWeapon()
	{
		setWeapon = null;
		SetWeaponCore(null);
		SetTotalWeaponStatusCore(null);
	}

	public void SetLevelLabelColor(RespWeapon weapon)
	{
		if (weapon != null)
		{
			Color levelColor = weapon.LevelColor;
			UIBasicUtility.SetLabelColor(curLevelLabel, levelColor);
			UIBasicUtility.SetLabelColor(curLevelLabel2, levelColor);
			UIBasicUtility.SetLabelColor(curLevelLabel3, levelColor);
			UIBasicUtility.SetLabelColor(curLevelLabel4, levelColor);
			UIBasicUtility.SetLabelColor(curMaxLevelLabel, levelColor);
			UIBasicUtility.SetLabelColor(curMaxLevelLabel2, levelColor);
			UIBasicUtility.SetLabelColor(curMaxLevelLabel3, levelColor);
			UIBasicUtility.SetLabelColor(curLimitBreakCountLabel, levelColor);
			UIBasicUtility.SetLabelColor(curLimitBreakCountLimitLabel, levelColor);
		}
	}

	public void SetIconColor(Color color)
	{
		if (null != curIconSprite)
		{
			curIconSprite.color = color;
		}
	}

	public void SetWeapon(RespWeapon weapon)
	{
		init = true;
		lastWeapon = weapon;
		setWeapon = weapon;
		if (weapon == null)
		{
			SetWeaponCore(null);
		}
		Disable = false;
		Using = false;
	}

	public void SetWeapon(RespWeapon weapon, bool ignoreUnknown)
	{
		IgnoreUnknown = ignoreUnknown;
		if ((bool)iconInfo)
		{
			iconInfo.IgnoreUnknown = ignoreUnknown;
		}
		SetWeapon(weapon);
	}

	private void SetWeaponCoreBase()
	{
		if ((bool)curExpGaugeBar)
		{
			curExpGaugeBar.gameObject.SetActive(value: true);
			curExpGaugeBar.sliderValue = 0f;
		}
	}

	private void SetWeaponCore(RespWeapon weapon)
	{
		_0024SetWeaponCore_0024locals_002414493 _0024SetWeaponCore_0024locals_0024 = new _0024SetWeaponCore_0024locals_002414493();
		SetWeaponCoreBase();
		if ((bool)iconInfo)
		{
			iconInfo.SetWeaponCore(weapon);
		}
		if (weapon == null || !weapon.IsValidMaster)
		{
			return;
		}
		bool flag = true;
		UserData current = UserData.Current;
		if (!IgnoreUnknown)
		{
			flag = current.userMiscInfo.weaponBookData.isLook(weapon.Master);
		}
		if (ForceUnknown)
		{
			flag = false;
		}
		UIBasicUtility.SetWeaponIconSpriteEx(curIconSprite, weapon, show: true, IgnoreUnknown, ForceUnknown);
		ForceUnknown = false;
		if ((bool)curNameLabel)
		{
			curNameLabel.text = ((!flag) ? "???" : weapon.Name);
			curNameLabel.gameObject.SetActive(value: true);
		}
		if (!flag)
		{
			if (showParametaDisalbeItem)
			{
				SetWeaponStatus(weapon);
			}
			return;
		}
		if (AutoUsingCheck)
		{
			current = UserData.Current;
			Using = current.IsUsingWeapon(weapon);
		}
		if ((bool)curIconCautionLabel)
		{
			curIconCautionLabel.text = ((!Using) ? CautionText : UsingText);
			GameObject obj = curIconCautionLabel.gameObject;
			bool num = Using;
			if (!num)
			{
				num = Disable;
			}
			obj.SetActive(num);
		}
		if ((bool)curExplainLabel)
		{
			curExplainLabel.text = weapon.Detail;
			curExplainLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curExpLabel)
		{
			string text = "Next " + weapon.LevelExpDist.ToString("#,#,0");
			if (weapon.IsLevelLimit)
			{
				text = "MAX";
			}
			curExpLabel.text = text;
			curExpLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curNextExpLabel)
		{
			string text2 = "Next " + weapon.LevelUpNeedExp.ToString("#,#,0");
			if (weapon.IsLevelLimit)
			{
				text2 = "MAX";
			}
			curNextExpLabel.text = text2;
			curNextExpLabel.gameObject.SetActive(value: true);
		}
		int num2 = weapon.LevelExpDist;
		int num3 = weapon.LevelUpExpDist;
		if (weapon.IsLevelLimit)
		{
			num2 = (num3 = 1);
		}
		UIBasicUtility.SetGauge(curExpGaugeBar, num2, num3, show: true);
		if ((bool)curStyleSprite)
		{
			UIBasicUtility.SetStyleSprite(curStyleSprite, weapon.Style.Id, light: true, show: true);
		}
		if ((bool)curElemSprite)
		{
			UIBasicUtility.SetElementSprite(curElemSprite, weapon.Element.Id, light: true, show: true);
		}
		if ((bool)curTypeLabel)
		{
			curTypeLabel.text = weapon.Style.Name.ToString();
			curTypeLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curElemLabel)
		{
			curElemLabel.text = weapon.Element.Name.ToString();
			curElemLabel.gameObject.SetActive(value: true);
		}
		_0024SetWeaponCore_0024locals_0024._0024angelSkill = weapon.AngelSkill;
		_0024SetWeaponCore_0024locals_0024._0024demonSkill = weapon.DemonSkill;
		MCoverSkills coverSkill = weapon.CoverSkill;
		if ((bool)curSkillPsvLabel)
		{
			if (coverSkill != null)
			{
				curSkillPsvLabel.text = coverSkill.Name.ToString();
			}
			else
			{
				curSkillPsvLabel.text = "無し";
			}
			curSkillPsvLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill1Label)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
			{
				curSkill1Label.text = _0024SetWeaponCore_0024locals_0024._0024angelSkill.Name.ToString();
			}
			else
			{
				curSkill1Label.text = "無し";
			}
			curSkill1Label.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill2Label)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
			{
				curSkill2Label.text = _0024SetWeaponCore_0024locals_0024._0024demonSkill.Name.ToString();
			}
			else
			{
				curSkill2Label.text = "無し";
			}
			curSkill2Label.gameObject.SetActive(value: true);
		}
		if ((bool)curSkillPsvExplainLabel)
		{
			if (coverSkill != null)
			{
				curSkillPsvExplainLabel.text = MasterExtensionsModule.MultiDetail(coverSkill, weapon.CoverSkillLevel);
			}
			curSkillPsvExplainLabel.gameObject.SetActive(coverSkill != null);
		}
		if ((bool)curSkill1ExplainLabel)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
			{
				curSkill1ExplainLabel.text = MasterExtensionsModule.MultiDetail(_0024SetWeaponCore_0024locals_0024._0024angelSkill);
			}
			curSkill1ExplainLabel.gameObject.SetActive(_0024SetWeaponCore_0024locals_0024._0024angelSkill != null);
		}
		if ((bool)curSkill2ExplainLabel)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
			{
				curSkill2ExplainLabel.text = MasterExtensionsModule.MultiDetail(_0024SetWeaponCore_0024locals_0024._0024demonSkill);
			}
			curSkill2ExplainLabel.gameObject.SetActive(_0024SetWeaponCore_0024locals_0024._0024demonSkill != null);
		}
		if ((bool)curSkillPsvExplainLabel2)
		{
			if (coverSkill != null)
			{
				curSkillPsvExplainLabel2.text = MasterExtensionsModule.MultiDetail(coverSkill, weapon.CoverSkillLevel);
			}
			curSkillPsvExplainLabel2.gameObject.SetActive(coverSkill != null);
		}
		if ((bool)curSkill1ExplainLabel2)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
			{
				curSkill1ExplainLabel2.text = MasterExtensionsModule.MultiDetail(_0024SetWeaponCore_0024locals_0024._0024angelSkill);
			}
			curSkill1ExplainLabel2.gameObject.SetActive(_0024SetWeaponCore_0024locals_0024._0024angelSkill != null);
		}
		if ((bool)curSkill2ExplainLabel2)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
			{
				curSkill2ExplainLabel2.text = MasterExtensionsModule.MultiDetail(_0024SetWeaponCore_0024locals_0024._0024demonSkill);
			}
			curSkill2ExplainLabel2.gameObject.SetActive(_0024SetWeaponCore_0024locals_0024._0024demonSkill != null);
		}
		if ((bool)curSkillPsvLvLabel)
		{
			if (coverSkill != null)
			{
				curSkillPsvLvLabel.text = string.Format(levelFormat, weapon.CoverSkillLevel);
			}
			GameObject obj2 = curSkillPsvLvLabel.gameObject;
			bool num4 = coverSkill != null;
			if (num4)
			{
				num4 = weapon.CoverSkillLevel > 0;
			}
			obj2.SetActive(num4);
		}
		if ((bool)curSkill1LvLabel)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
			{
				curSkill1LvLabel.text = string.Format(levelFormat, weapon.AngelSkillLevel);
			}
			GameObject obj3 = curSkill1LvLabel.gameObject;
			bool num5 = _0024SetWeaponCore_0024locals_0024._0024angelSkill != null;
			if (num5)
			{
				num5 = weapon.AngelSkillLevel > 0;
			}
			obj3.SetActive(num5);
		}
		if ((bool)curSkill2LvLabel)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
			{
				curSkill2LvLabel.text = string.Format(levelFormat, weapon.DemonSkillLevel);
			}
			GameObject obj4 = curSkill2LvLabel.gameObject;
			bool num6 = _0024SetWeaponCore_0024locals_0024._0024demonSkill != null;
			if (num6)
			{
				num6 = weapon.DemonSkillLevel > 0;
			}
			obj4.SetActive(num6);
		}
		if ((bool)curSkillPsvLvLabel2)
		{
			if (coverSkill != null)
			{
				curSkillPsvLvLabel2.text = string.Format(levelFormat2, weapon.CoverSkillLevel);
			}
			GameObject obj5 = curSkillPsvLvLabel2.gameObject;
			bool num7 = coverSkill != null;
			if (num7)
			{
				num7 = weapon.CoverSkillLevel > 0;
			}
			obj5.SetActive(num7);
		}
		if ((bool)curSkill1LvLabel2)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
			{
				curSkill1LvLabel2.text = string.Format(levelFormat2, weapon.AngelSkillLevel);
			}
			GameObject obj6 = curSkill1LvLabel2.gameObject;
			bool num8 = _0024SetWeaponCore_0024locals_0024._0024angelSkill != null;
			if (num8)
			{
				num8 = weapon.AngelSkillLevel > 0;
			}
			obj6.SetActive(num8);
		}
		if ((bool)curSkill2LvLabel2)
		{
			if (_0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
			{
				curSkill2LvLabel2.text = string.Format(levelFormat2, weapon.DemonSkillLevel);
			}
			GameObject obj7 = curSkill2LvLabel2.gameObject;
			bool num9 = _0024SetWeaponCore_0024locals_0024._0024demonSkill != null;
			if (num9)
			{
				num9 = weapon.DemonSkillLevel > 0;
			}
			obj7.SetActive(num9);
		}
		if ((bool)curSkill1CoolDownLabel)
		{
			curSkill1CoolDownLabel.text = string.Format(cooldownFormat1, weapon.AngelSkillCoolDown);
			curSkill1CoolDownLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill2CoolDownLabel)
		{
			curSkill2CoolDownLabel.text = string.Format(cooldownFormat2, weapon.DemonSkillCoolDown);
			curSkill2CoolDownLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curIconRankTextSprite)
		{
			if (weapon.Rare == null)
			{
			}
			curIconRankTextSprite.spriteName = weapon.Rare.Icon + "_text";
			GameObject obj8 = curIconRankTextSprite.gameObject;
			bool num10 = curIconRankTextSprite.spriteName == weapon.Rare.Icon + "_text";
			if (num10)
			{
				num10 = !string.IsNullOrEmpty(weapon.Rare.Icon);
			}
			obj8.SetActive(num10);
		}
		SetFavorite(weapon.favorite != 0);
		SetNew(current.IsNewItem(weapon.RefPlayerBox));
		if ((bool)curIconSkillPsvSprite && coverSkill != null)
		{
			IconAtlasPool.SetSprite(curIconSkillPsvSprite, coverSkill.Icon);
			GameObject obj9 = curIconSkillPsvSprite.gameObject;
			bool num11 = curIconSkillPsvSprite.spriteName == coverSkill.Icon;
			if (num11)
			{
				num11 = !string.IsNullOrEmpty(coverSkill.Icon);
			}
			obj9.SetActive(num11);
		}
		if ((bool)curIconSkill1Sprite && _0024SetWeaponCore_0024locals_0024._0024angelSkill != null)
		{
			IconAtlasPool.SetSprite(curIconSkill1Sprite, _0024SetWeaponCore_0024locals_0024._0024angelSkill.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetWeaponCore_0024closure_00245019(this, _0024SetWeaponCore_0024locals_0024).Invoke));
		}
		if ((bool)curIconSkill2Sprite && _0024SetWeaponCore_0024locals_0024._0024demonSkill != null)
		{
			IconAtlasPool.SetSprite(curIconSkill2Sprite, _0024SetWeaponCore_0024locals_0024._0024demonSkill.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetWeaponCore_0024closure_00245020(_0024SetWeaponCore_0024locals_0024, this).Invoke));
		}
		UIBasicUtility.SetLabel(deckCostLabel, weapon.DeckCost.ToString(), show: true);
		UIBasicUtility.SetSprite(traitSprite, weapon.TraitSpriteName, null, show: true);
		if ((bool)supportInfo)
		{
			supportInfo.SetInfo(weapon);
		}
		SetWeaponStatus(weapon);
	}

	private void SetWeaponStatus(RespWeapon weapon)
	{
		if (weapon.Level == 0)
		{
		}
		if ((bool)curLevelLabel)
		{
			UIBasicUtility.SetLabel(curLevelLabel, UIBasicUtility.SafeFormat(levelFormat, weapon.Level), 0 < weapon.Level);
		}
		if ((bool)curLevelLabel2)
		{
			UIBasicUtility.SetLabel(curLevelLabel2, UIBasicUtility.SafeFormat(levelFormat2, weapon.Level), 0 < weapon.Level);
		}
		if ((bool)curLevelLabel3)
		{
			UIBasicUtility.SetLabel(curLevelLabel3, UIBasicUtility.SafeFormat(levelFormat3, weapon.Level), 0 < weapon.Level);
		}
		if ((bool)curLevelLabel4)
		{
			UIBasicUtility.SetLabel(curLevelLabel4, UIBasicUtility.SafeFormat(levelFormat4, weapon.Level, weapon.CurrentLevelLimit), 0 < weapon.Level);
		}
		if ((bool)curMaxLevelLabel)
		{
			UIBasicUtility.SetLabel(curMaxLevelLabel, UIBasicUtility.SafeFormat(levelFormat, weapon.CurrentLevelLimit), 0 < weapon.Level);
		}
		if ((bool)curMaxLevelLabel2)
		{
			UIBasicUtility.SetLabel(curMaxLevelLabel2, UIBasicUtility.SafeFormat(levelFormat2, weapon.CurrentLevelLimit), 0 < weapon.Level);
		}
		if ((bool)curMaxLevelLabel3)
		{
			UIBasicUtility.SetLabel(curMaxLevelLabel3, UIBasicUtility.SafeFormat(levelFormat3, weapon.CurrentLevelLimit), 0 < weapon.Level);
		}
		if ((bool)curLimitBreakCountLabel)
		{
			UIBasicUtility.SetLabel(curLimitBreakCountLabel, weapon.LimitBreakCount.ToString(), show: true);
		}
		if ((bool)curLimitBreakCountLimitLabel)
		{
			UIBasicUtility.SetLabel(curLimitBreakCountLimitLabel, weapon.LimitBreakCountLimit.ToString(), show: true);
		}
		SetLevelLabelColor(weapon);
		if ((bool)curAttackPointLabel)
		{
			curAttackPointLabel.text = weapon.TotalAttack.ToString();
			curAttackPointLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPointLabel)
		{
			curHitPointLabel.text = weapon.TotalHP.ToString();
			curHitPointLabel.gameObject.SetActive(value: true);
		}
		UIBasicUtility.SetSumPlusBonusLabel(curSumPlusLabel, weapon);
		SetEnableAlphaTargets("PlusText", 0 < weapon.SumPlusBonus);
		UIBasicUtility.SetPlusBonusLabel(curAttackPointPlusLabel, weapon.AttackPlusBonus, weapon.IsAttackPlusBonusMax);
		UIBasicUtility.SetPlusBonusLabel(curHitPointPlusLabel, weapon.HpPlusBonus, weapon.IsHpPlusBonusMax);
		if ((bool)curBuyPriceLabel)
		{
			curBuyPriceLabel.text = weapon.SellPrice.ToString();
			curBuyPriceLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curSellPriceLabel)
		{
			curSellPriceLabel.text = weapon.SellPrice.ToString();
			curSellPriceLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curAttackPointLabel2)
		{
			curAttackPointLabel2.text = weapon.TotalAttack.ToString();
			curAttackPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPointLabel2)
		{
			curHitPointLabel2.text = weapon.TotalHP.ToString();
			curHitPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curAttackPointPlusLabel2)
		{
			curAttackPointPlusLabel2.text = weapon.AttackBonus.ToString();
			curAttackPointPlusLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPointPlusLabel2)
		{
			curHitPointPlusLabel2.text = weapon.HpBonus.ToString();
			curHitPointPlusLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curBuyPriceLabel2)
		{
			curBuyPriceLabel2.text = weapon.SellPrice.ToString();
			curBuyPriceLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curSellPriceLabel2)
		{
			curSellPriceLabel2.text = weapon.SellPrice.ToString();
			curSellPriceLabel2.gameObject.SetActive(value: true);
		}
	}

	public void SetTotalWeaponStatus(RespWeapon[] weapon)
	{
		initArray = true;
		SetTotalWeaponStatusCore(weapon);
	}

	private void SetTotalWeaponStatusCoreBase()
	{
		if ((bool)totalAttackPointLabel)
		{
			totalAttackPointLabel.gameObject.SetActive(value: false);
		}
		if ((bool)totalHitPointLabel)
		{
			totalHitPointLabel.gameObject.SetActive(value: false);
		}
		if ((bool)battleAttackPointLabel)
		{
			battleAttackPointLabel.gameObject.SetActive(value: false);
		}
		if ((bool)battleHitPointLabel)
		{
			battleHitPointLabel.gameObject.SetActive(value: false);
		}
		if ((bool)fireLabel)
		{
			fireLabel.gameObject.SetActive(value: false);
		}
		if ((bool)waterLabel)
		{
			waterLabel.gameObject.SetActive(value: false);
		}
		if ((bool)airLabel)
		{
			airLabel.gameObject.SetActive(value: false);
		}
		if ((bool)earthLabel)
		{
			earthLabel.gameObject.SetActive(value: false);
		}
		if ((bool)totalAttackPointLabel2)
		{
			totalAttackPointLabel2.gameObject.SetActive(value: false);
		}
		if ((bool)totalHitPointLabel2)
		{
			totalHitPointLabel2.gameObject.SetActive(value: false);
		}
		if ((bool)battleAttackPointLabel2)
		{
			battleAttackPointLabel2.gameObject.SetActive(value: false);
		}
		if ((bool)battleHitPointLabel2)
		{
			battleHitPointLabel2.gameObject.SetActive(value: false);
		}
	}

	private void SetTotalWeaponStatusCore(RespWeapon[] weapon)
	{
		SetTotalWeaponStatusCoreBase();
		if (weapon == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 1;
		int num6 = 1;
		int num7 = 1;
		int num8 = 1;
		checked
		{
			num = (int)DamageCalc.TotalWeaponAttack(weapon);
			num2 = (int)DamageCalc.TotalWeaponHP(weapon);
			num3 = num;
			num4 = num2;
			int num9 = 0;
			int i = 0;
			for (int length = weapon.Length; i < length; i++)
			{
				if (weapon[i] != null)
				{
					num9++;
				}
			}
			if (num9 > 0)
			{
				RespWeapon respWeapon = weapon[0];
				num5 = (int)(respWeapon.damageScale(EnumElements.fire) * 100f);
				num6 = (int)(respWeapon.damageScale(EnumElements.water) * 100f);
				num7 = (int)(respWeapon.damageScale(EnumElements.wind) * 100f);
				num8 = (int)(respWeapon.damageScale(EnumElements.earth) * 100f);
			}
			if ((bool)totalAttackPointLabel)
			{
				totalAttackPointLabel.text = num.ToString();
				totalAttackPointLabel.gameObject.SetActive(value: true);
			}
			if ((bool)totalHitPointLabel)
			{
				totalHitPointLabel.text = num2.ToString();
				totalHitPointLabel.gameObject.SetActive(value: true);
			}
			if ((bool)battleAttackPointLabel)
			{
				battleAttackPointLabel.text = num3.ToString();
				battleAttackPointLabel.gameObject.SetActive(value: true);
			}
			if ((bool)battleHitPointLabel)
			{
				battleHitPointLabel.text = num4.ToString();
				battleHitPointLabel.gameObject.SetActive(value: true);
			}
			if ((bool)totalAttackPointLabel2)
			{
				totalAttackPointLabel2.text = num.ToString();
				totalAttackPointLabel2.gameObject.SetActive(value: true);
			}
			if ((bool)totalHitPointLabel2)
			{
				totalHitPointLabel2.text = num2.ToString();
				totalHitPointLabel2.gameObject.SetActive(value: true);
			}
			if ((bool)battleAttackPointLabel2)
			{
				battleAttackPointLabel2.text = num3.ToString();
				battleAttackPointLabel2.gameObject.SetActive(value: true);
			}
			if ((bool)battleHitPointLabel2)
			{
				battleHitPointLabel2.text = num4.ToString();
				battleHitPointLabel2.gameObject.SetActive(value: true);
			}
			if ((bool)fireLabel)
			{
				fireLabel.text = $"{num5:00}%";
				fireLabel.gameObject.SetActive(value: true);
			}
			if ((bool)waterLabel)
			{
				waterLabel.text = $"{num6:00}%";
				waterLabel.gameObject.SetActive(value: true);
			}
			if ((bool)airLabel)
			{
				airLabel.text = $"{num7:00}%";
				airLabel.gameObject.SetActive(value: true);
			}
			if ((bool)earthLabel)
			{
				earthLabel.text = $"{num8:00}%";
				earthLabel.gameObject.SetActive(value: true);
			}
		}
	}
}
