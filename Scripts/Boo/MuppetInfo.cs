using System;
using System.Collections;
using System.Text;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MuppetInfo : UIListItem
{
	[Serializable]
	internal class _0024SetMuppetCore_0024locals_002414476
	{
		internal RespPoppet _0024muppet;
	}

	[Serializable]
	internal class _0024SetMuppetCore_0024closure_00243044
	{
		internal MuppetInfo _0024this_002415050;

		internal _0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415051;

		public _0024SetMuppetCore_0024closure_00243044(MuppetInfo _0024this_002415050, _0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415051)
		{
			this._0024this_002415050 = _0024this_002415050;
			this._0024_0024locals_002415051 = _0024_0024locals_002415051;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024this_002415050.curIconMagicSprite.gameObject;
			bool num = _0024this_002415050.curIconMagicSprite.spriteName == _0024_0024locals_002415051._0024muppet.ChainSkill.Icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415051._0024muppet.ChainSkill.Icon);
			}
			gameObject.SetActive(num);
		}
	}

	[Serializable]
	internal class _0024SetMuppetCore_0024closure_00243045
	{
		internal _0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415052;

		internal MuppetInfo _0024this_002415053;

		public _0024SetMuppetCore_0024closure_00243045(_0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415052, MuppetInfo _0024this_002415053)
		{
			this._0024_0024locals_002415052 = _0024_0024locals_002415052;
			this._0024this_002415053 = _0024this_002415053;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024this_002415053.curIconSkill1Sprite.gameObject;
			bool num = _0024this_002415053.curIconSkill1Sprite.spriteName == _0024_0024locals_002415052._0024muppet.CoverSkill1.Icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415052._0024muppet.CoverSkill1.Icon);
			}
			gameObject.SetActive(num);
		}
	}

	[Serializable]
	internal class _0024SetMuppetCore_0024closure_00243046
	{
		internal _0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415054;

		internal MuppetInfo _0024this_002415055;

		public _0024SetMuppetCore_0024closure_00243046(_0024SetMuppetCore_0024locals_002414476 _0024_0024locals_002415054, MuppetInfo _0024this_002415055)
		{
			this._0024_0024locals_002415054 = _0024_0024locals_002415054;
			this._0024this_002415055 = _0024this_002415055;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024this_002415055.curIconSkill2Sprite.gameObject;
			bool num = _0024this_002415055.curIconSkill2Sprite.spriteName == _0024_0024locals_002415054._0024muppet.CoverSkill2.Icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415054._0024muppet.CoverSkill2.Icon);
			}
			gameObject.SetActive(num);
		}
	}

	public bool deleteIconLevel;

	public GameObject iconPrefab;

	public Transform iconParent;

	public Vector3 iconScale;

	protected MuppetInfo iconInfo;

	public GameObject cur3DModel;

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

	public UISprite curElemSprite;

	public UILabelBase curUseLabel;

	public UILabelBase curTypeLabel;

	public UILabelBase curElemLabel;

	public UISprite curIconSprite;

	public UISprite curIconRankTextSprite;

	public GameObject curIconFramePanel;

	public UISprite curIconNumberSprite;

	public UILabelBase curWeakWeaponNoneLabel;

	public UISprite curWeakWeaponSprite;

	public UISlider curExpGaugeBar;

	public UISprite curIconMagicSprite;

	public UILabelBase curMagicLabel;

	public UILabelBase curMagicLvLabel;

	public UILabelBase curMagicLvLabel2;

	public UILabelBase curMagicExplainLabel;

	public UILabelBase curMagicExplainLabel2;

	public string needMagicPointFormat;

	public UILabelBase curNeedMagicPointLabel;

	public UISprite curIconSkill1Sprite;

	public UILabelBase curSkill1Label;

	public UILabelBase curSkill1LvLabel;

	public UILabelBase curSkill1LvLabel2;

	public UILabelBase curSkill1ExplainLabel;

	public UILabelBase curSkill1ExplainLabel2;

	public UISprite curIconSkill2Sprite;

	public UILabelBase curSkill2Label;

	public UILabelBase curSkill2LvLabel;

	public UILabelBase curSkill2LvLabel2;

	public UILabelBase curSkill2ExplainLabel;

	public UILabelBase curSkill2ExplainLabel2;

	public UILabelBase curAttackPointLabel;

	public UILabelBase curHitPointLabel;

	public UILabelBase curAttackPlusPointLabel;

	public UILabelBase curHitPlusPointLabel;

	public UILabelBase curSumPlusLabel;

	public UILabelBase curBuyPriceLabel;

	public UILabelBase curSellPriceLabel;

	public UILabelBase curAttackPointLabel2;

	public UILabelBase curHitPointLabel2;

	public UILabelBase curAttackPlusPointLabel2;

	public UILabelBase curHitPlusPointLabel2;

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

	private RespPoppet setMuppet;

	private RespPoppet[] setTotalMuppetArray;

	private RespPoppet lastMuppet;

	private RespPoppet[] lastTotalMuppetArray;

	private bool use;

	private bool init;

	private bool initArray;

	public UIItemSupportSwitcher supportInfo;

	public UILabelBase deckCostLabel;

	public UISprite traitSprite;

	private bool isDeletedIconLevel;

	public RespPoppet LastMuppet => lastMuppet;

	public RespPoppet[] LastTotalMuppetArray => lastTotalMuppetArray;

	public bool Use
	{
		get
		{
			return use;
		}
		set
		{
			use = value;
		}
	}

	public bool isSetPoppet
	{
		get
		{
			bool num = setMuppet == null;
			if (num)
			{
				num = lastMuppet != null;
			}
			return num;
		}
	}

	public MuppetInfo IconInfo => iconInfo;

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

	public MuppetInfo()
	{
		iconScale = Vector3.one;
		levelFormat = "Lv.{0:00}";
		levelFormat2 = "{0:00}";
		levelFormat3 = "{0:00}";
		levelFormat4 = "{0:00}/{1:00}";
		needMagicPointFormat = "必要魔力：{0}";
		showParametaDisalbeItem = true;
	}

	public void Init(bool show)
	{
		UIBasicUtility.SetLabel(curNameLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curExplainLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curExplainLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curExpLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curNextExpLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curLevelLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curMaxLevelLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curLevelLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curMaxLevelLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curLevelLabel3, string.Empty, show);
		UIBasicUtility.SetLabel(curMaxLevelLabel3, string.Empty, show);
		UIBasicUtility.SetLabel(curLevelLabel4, string.Empty, show);
		UIBasicUtility.SetLabel(curLimitBreakCountLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curLimitBreakCountLimitLabel, string.Empty, show);
		UIBasicUtility.SetSprite(curElemSprite, string.Empty, null, show);
		UIBasicUtility.SetLabel(curUseLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curTypeLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curElemLabel, string.Empty, show);
		UIBasicUtility.SetSprite(curIconSprite, string.Empty, null, show);
		UIBasicUtility.SetSprite(curIconRankTextSprite, string.Empty, null, show);
		UIBasicUtility.SetSprite(curIconNumberSprite, string.Empty, null, show);
		UIBasicUtility.SetSprite(curWeakWeaponSprite, string.Empty, null, show);
		UIBasicUtility.SetSprite(curIconMagicSprite, string.Empty, null, show);
		UIBasicUtility.SetLabel(curMagicLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curMagicLvLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curMagicLvLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curMagicExplainLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curMagicExplainLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curNeedMagicPointLabel, string.Empty, show);
		UIBasicUtility.SetSprite(curIconSkill1Sprite, string.Empty, null, show);
		UIBasicUtility.SetLabel(curSkill1Label, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill1LvLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill1LvLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill1ExplainLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill1ExplainLabel2, string.Empty, show);
		UIBasicUtility.SetSprite(curIconSkill2Sprite, string.Empty, null, show);
		UIBasicUtility.SetLabel(curSkill2Label, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill2LvLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill2LvLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill2ExplainLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSkill2ExplainLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curAttackPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curHitPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curAttackPlusPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curHitPlusPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSumPlusLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curBuyPriceLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curSellPriceLabel, string.Empty, show);
		UIBasicUtility.SetLabel(curAttackPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curHitPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curAttackPlusPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curHitPlusPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curBuyPriceLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(curSellPriceLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(totalAttackPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(totalHitPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(battleAttackPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(battleHitPointLabel, string.Empty, show);
		UIBasicUtility.SetLabel(totalAttackPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(totalHitPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(battleAttackPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(battleHitPointLabel2, string.Empty, show);
		UIBasicUtility.SetLabel(fireLabel, string.Empty, show);
		UIBasicUtility.SetLabel(waterLabel, string.Empty, show);
		UIBasicUtility.SetLabel(airLabel, string.Empty, show);
		UIBasicUtility.SetLabel(earthLabel, string.Empty, show);
		UIBasicUtility.SetLabel(deckCostLabel, string.Empty, show);
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
				iconInfo = ExtensionsModule.SetComponent<MuppetInfo>(gameObject);
			}
		}
	}

	public void Start()
	{
		if (!init)
		{
			Init(show: true);
			SetMuppet(null);
		}
		if (!initArray)
		{
			SetTotalMuppetStatus(null);
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
			MonoBehaviour.print(new StringBuilder("MuppetInfo(").Append(lastMuppet).Append(")").ToString());
			forDebugCurrentItemPrint = false;
		}
		if (setMuppet != null)
		{
			SetMuppetCore(setMuppet);
			setMuppet = null;
		}
		if (setTotalMuppetArray != null)
		{
			SetTotalMuppetStatusCore(setTotalMuppetArray);
			setTotalMuppetArray = null;
		}
	}

	public void ResetMuppet()
	{
		lastMuppet = null;
		setMuppet = null;
		SetMuppetCore(null);
		SetTotalMuppetStatus(null);
	}

	public void SetLevelLabelColor(RespPoppet pet)
	{
		if (pet != null)
		{
			Color levelColor = pet.LevelColor;
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

	public void SetMuppet(RespPoppet muppet)
	{
		init = true;
		lastMuppet = muppet;
		setMuppet = muppet;
		if (muppet == null)
		{
			SetMuppetCore(null);
		}
		Disable = false;
		Using = false;
	}

	public void SetMuppet(RespPoppet muppet, bool ignoreUnknown)
	{
		IgnoreUnknown = ignoreUnknown;
		if ((bool)iconInfo)
		{
			iconInfo.IgnoreUnknown = ignoreUnknown;
		}
		SetMuppet(muppet);
	}

	private void SetMuppetCoreBase()
	{
		if ((bool)curExpGaugeBar)
		{
			curExpGaugeBar.gameObject.SetActive(value: true);
			curExpGaugeBar.sliderValue = 0f;
		}
	}

	private void SetMuppetCore(RespPoppet muppet)
	{
		_0024SetMuppetCore_0024locals_002414476 _0024SetMuppetCore_0024locals_0024 = new _0024SetMuppetCore_0024locals_002414476();
		_0024SetMuppetCore_0024locals_0024._0024muppet = muppet;
		SetMuppetCoreBase();
		if ((bool)iconInfo)
		{
			iconInfo.SetMuppetCore(_0024SetMuppetCore_0024locals_0024._0024muppet);
		}
		if (_0024SetMuppetCore_0024locals_0024._0024muppet == null)
		{
			return;
		}
		UserData current = UserData.Current;
		if (AutoUsingCheck)
		{
			Using = current.IsUsingPoppet(_0024SetMuppetCore_0024locals_0024._0024muppet);
		}
		if (!_0024SetMuppetCore_0024locals_0024._0024muppet.IsValidMaster)
		{
			return;
		}
		bool flag = true;
		if (!IgnoreUnknown)
		{
			flag = current.userMiscInfo.poppetBookData.isLook(_0024SetMuppetCore_0024locals_0024._0024muppet.Master);
		}
		if (ForceUnknown)
		{
			flag = false;
		}
		UIBasicUtility.SetPoppetIconSpriteEx(curIconSprite, _0024SetMuppetCore_0024locals_0024._0024muppet, show: true, IgnoreUnknown, ForceUnknown);
		ForceUnknown = false;
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
		if ((bool)curNameLabel)
		{
			curNameLabel.text = ((!flag) ? "???" : _0024SetMuppetCore_0024locals_0024._0024muppet.Name);
			curNameLabel.gameObject.SetActive(value: true);
		}
		if (!flag)
		{
			if (showParametaDisalbeItem)
			{
				SetMuppetStatus(_0024SetMuppetCore_0024locals_0024._0024muppet);
			}
			return;
		}
		if ((bool)cur3DModel)
		{
			IEnumerator enumerator = cur3DModel.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj2 = enumerator.Current;
				if (!(obj2 is Transform))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Transform));
				}
				Transform transform = (Transform)obj2;
				UnityEngine.Object.DestroyObject(transform.gameObject);
			}
			PoppetFactory.Instance.createPoppetObj(_0024SetMuppetCore_0024locals_0024._0024muppet, delegate(AIControl ai)
			{
				GameObject gameObject = ai.gameObject;
				if ((bool)ai)
				{
					ai.enabled = false;
				}
				gameObject.transform.parent = cur3DModel.transform;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
				NGUITools.SetLayer(gameObject, cur3DModel.gameObject.layer);
				cur3DModel.gameObject.SetActive(value: true);
			});
		}
		if ((bool)curExplainLabel)
		{
			curExplainLabel.text = _0024SetMuppetCore_0024locals_0024._0024muppet.Detail;
			curExplainLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curExpLabel)
		{
			string text = "Next " + _0024SetMuppetCore_0024locals_0024._0024muppet.LevelExpDist.ToString("#,#,0");
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.IsLevelLimit)
			{
				text = "MAX";
			}
			curExpLabel.text = text;
			curExpLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curNextExpLabel)
		{
			string text2 = "Next " + _0024SetMuppetCore_0024locals_0024._0024muppet.LevelUpNeedExp.ToString("#,#,0");
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.IsLevelLimit)
			{
				text2 = "MAX";
			}
			curNextExpLabel.text = text2;
			curNextExpLabel.gameObject.SetActive(value: true);
		}
		int num2 = _0024SetMuppetCore_0024locals_0024._0024muppet.LevelExpDist;
		int num3 = _0024SetMuppetCore_0024locals_0024._0024muppet.LevelUpExpDist;
		if (_0024SetMuppetCore_0024locals_0024._0024muppet.IsLevelLimit)
		{
			num2 = (num3 = 1);
		}
		UIBasicUtility.SetGauge(curExpGaugeBar, num2, num3, show: true);
		if (_0024SetMuppetCore_0024locals_0024._0024muppet.Level == 0)
		{
		}
		if ((bool)curElemSprite)
		{
			UIBasicUtility.SetElementSprite(curElemSprite, _0024SetMuppetCore_0024locals_0024._0024muppet.Element.Id, light: true, show: true);
		}
		EnumStyles weakStyle = _0024SetMuppetCore_0024locals_0024._0024muppet.Master.Monster.WeakStyle;
		bool flag2 = weakStyle == EnumStyles.None;
		if ((bool)curWeakWeaponNoneLabel)
		{
			curWeakWeaponNoneLabel.gameObject.SetActive(flag2);
		}
		if ((bool)curWeakWeaponSprite)
		{
			UIBasicUtility.SetStyleSprite(curWeakWeaponSprite, (int)weakStyle, light: true, !flag2);
		}
		if ((bool)curUseLabel)
		{
			curUseLabel.gameObject.SetActive(use);
		}
		if ((bool)curTypeLabel)
		{
			curTypeLabel.text = _0024SetMuppetCore_0024locals_0024._0024muppet.Master.MRaceId.Name.ToString();
			curTypeLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curElemLabel)
		{
			curElemLabel.text = _0024SetMuppetCore_0024locals_0024._0024muppet.Element.Name.ToString();
			curElemLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curMagicLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null)
			{
				curMagicLabel.text = _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill.Name.ToString();
			}
			else
			{
				curMagicLabel.text = "無し";
			}
			curMagicLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill1Label)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null)
			{
				curSkill1Label.text = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1.Name.ToString();
			}
			else
			{
				curSkill1Label.text = "無し";
			}
			curSkill1Label.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill2Label)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null)
			{
				curSkill2Label.text = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2.Name.ToString();
			}
			else
			{
				curSkill2Label.text = "無し";
			}
			curSkill2Label.gameObject.SetActive(value: true);
		}
		if ((bool)curMagicExplainLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null)
			{
				curMagicExplainLabel.text = MasterExtensionsModule.MultiDetail(_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill);
			}
			curMagicExplainLabel.gameObject.SetActive(_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null);
		}
		if ((bool)curSkill1ExplainLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null)
			{
				curSkill1ExplainLabel.text = MasterExtensionsModule.MultiDetail(_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_1);
			}
			curSkill1ExplainLabel.gameObject.SetActive(_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null);
		}
		if ((bool)curSkill2ExplainLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null)
			{
				curSkill2ExplainLabel.text = MasterExtensionsModule.MultiDetail(_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_2);
			}
			curSkill2ExplainLabel.gameObject.SetActive(_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null);
		}
		if ((bool)curMagicExplainLabel2)
		{
			curMagicExplainLabel2.text = string.Empty;
			curMagicExplainLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill1ExplainLabel2)
		{
			curSkill1ExplainLabel2.text = string.Empty;
			curSkill1ExplainLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curSkill2ExplainLabel2)
		{
			curSkill2ExplainLabel2.text = string.Empty;
			curSkill2ExplainLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curMagicLvLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null)
			{
				curMagicLvLabel.text = string.Format(levelFormat, _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkillLevel);
			}
			GameObject obj3 = curMagicLvLabel.gameObject;
			bool num4 = _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null;
			if (num4)
			{
				num4 = _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkillLevel > 0;
			}
			obj3.SetActive(num4);
		}
		if ((bool)curSkill1LvLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null)
			{
				curSkill1LvLabel.text = string.Format(levelFormat, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_1);
			}
			GameObject obj4 = curSkill1LvLabel.gameObject;
			bool num5 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null;
			if (num5)
			{
				num5 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_1 > 0;
			}
			obj4.SetActive(num5);
		}
		if ((bool)curSkill2LvLabel)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null)
			{
				curSkill2LvLabel.text = string.Format(levelFormat, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_2);
			}
			GameObject obj5 = curSkill2LvLabel.gameObject;
			bool num6 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null;
			if (num6)
			{
				num6 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_2 > 0;
			}
			obj5.SetActive(num6);
		}
		if ((bool)curMagicLvLabel2)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null)
			{
				curMagicLvLabel2.text = string.Format(levelFormat2, _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkillLevel);
			}
			GameObject obj6 = curMagicLvLabel2.gameObject;
			bool num7 = _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill != null;
			if (num7)
			{
				num7 = _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkillLevel > 0;
			}
			obj6.SetActive(num7);
		}
		if ((bool)curSkill1LvLabel2)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null)
			{
				curSkill1LvLabel2.text = string.Format(levelFormat2, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_1);
			}
			GameObject obj7 = curSkill1LvLabel2.gameObject;
			bool num8 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1 != null;
			if (num8)
			{
				num8 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_1 > 0;
			}
			obj7.SetActive(num8);
		}
		if ((bool)curSkill2LvLabel2)
		{
			if (_0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null)
			{
				curSkill2LvLabel2.text = string.Format(levelFormat2, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_2);
			}
			GameObject obj8 = curSkill2LvLabel2.gameObject;
			bool num9 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2 != null;
			if (num9)
			{
				num9 = _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkillLevel_2 > 0;
			}
			obj8.SetActive(num9);
		}
		if ((bool)curIconRankTextSprite)
		{
			curIconRankTextSprite.spriteName = _0024SetMuppetCore_0024locals_0024._0024muppet.Rare.Icon + "_text";
			GameObject obj9 = curIconRankTextSprite.gameObject;
			bool num10 = curIconRankTextSprite.spriteName == _0024SetMuppetCore_0024locals_0024._0024muppet.Rare.Icon + "_text";
			if (num10)
			{
				num10 = !string.IsNullOrEmpty(_0024SetMuppetCore_0024locals_0024._0024muppet.Rare.Icon);
			}
			obj9.SetActive(num10);
		}
		SetFavorite(_0024SetMuppetCore_0024locals_0024._0024muppet.favorite != 0);
		SetNew(current.IsNewItem(_0024SetMuppetCore_0024locals_0024._0024muppet.RefPlayerBox));
		if ((bool)curIconMagicSprite)
		{
			IconAtlasPool.SetSprite(curIconMagicSprite, _0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkill.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetMuppetCore_0024closure_00243044(this, _0024SetMuppetCore_0024locals_0024).Invoke));
		}
		if ((bool)curIconSkill1Sprite)
		{
			IconAtlasPool.SetSprite(curIconSkill1Sprite, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill1.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetMuppetCore_0024closure_00243045(_0024SetMuppetCore_0024locals_0024, this).Invoke));
		}
		if ((bool)curIconSkill2Sprite)
		{
			IconAtlasPool.SetSprite(curIconSkill2Sprite, _0024SetMuppetCore_0024locals_0024._0024muppet.CoverSkill2.Icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetMuppetCore_0024closure_00243046(_0024SetMuppetCore_0024locals_0024, this).Invoke));
		}
		if ((bool)curNeedMagicPointLabel)
		{
			curNeedMagicPointLabel.text = string.Format(needMagicPointFormat, checked((int)_0024SetMuppetCore_0024locals_0024._0024muppet.ChainSkillValue));
			curNeedMagicPointLabel.gameObject.SetActive(value: true);
		}
		UIBasicUtility.SetLabel(deckCostLabel, _0024SetMuppetCore_0024locals_0024._0024muppet.DeckCost.ToString(), show: true);
		UIBasicUtility.SetSprite(traitSprite, _0024SetMuppetCore_0024locals_0024._0024muppet.TraitSpriteName, null, show: true);
		if ((bool)supportInfo)
		{
			supportInfo.SetInfo(_0024SetMuppetCore_0024locals_0024._0024muppet);
		}
		SetMuppetStatus(_0024SetMuppetCore_0024locals_0024._0024muppet);
	}

	private void SetMuppetStatus(RespPoppet muppet)
	{
		if ((bool)curLevelLabel)
		{
			UIBasicUtility.SetLabel(curLevelLabel, UIBasicUtility.SafeFormat(levelFormat, muppet.Level), 0 < muppet.Level);
		}
		if ((bool)curLevelLabel2)
		{
			UIBasicUtility.SetLabel(curLevelLabel2, UIBasicUtility.SafeFormat(levelFormat2, muppet.Level), 0 < muppet.Level);
		}
		if ((bool)curLevelLabel3)
		{
			UIBasicUtility.SetLabel(curLevelLabel3, UIBasicUtility.SafeFormat(levelFormat3, muppet.Level), 0 < muppet.Level);
		}
		if ((bool)curLevelLabel4)
		{
			UIBasicUtility.SetLabel(curLevelLabel4, UIBasicUtility.SafeFormat(levelFormat4, muppet.Level, muppet.CurrentLevelLimit), 0 < muppet.Level);
		}
		if ((bool)curMaxLevelLabel)
		{
			curMaxLevelLabel.text = string.Format(levelFormat, muppet.CurrentLevelLimit);
			curMaxLevelLabel.gameObject.SetActive(muppet.Level > 0);
		}
		if ((bool)curMaxLevelLabel2)
		{
			curMaxLevelLabel2.text = string.Format(levelFormat2, muppet.CurrentLevelLimit);
			curMaxLevelLabel2.gameObject.SetActive(muppet.Level > 0);
		}
		if ((bool)curMaxLevelLabel3)
		{
			curMaxLevelLabel3.text = string.Format(levelFormat3, muppet.CurrentLevelLimit);
			curMaxLevelLabel3.gameObject.SetActive(muppet.Level > 0);
		}
		if ((bool)curLimitBreakCountLabel)
		{
			UIBasicUtility.SetLabel(curLimitBreakCountLabel, muppet.LimitBreakCount.ToString(), show: true);
		}
		if ((bool)curLimitBreakCountLimitLabel)
		{
			UIBasicUtility.SetLabel(curLimitBreakCountLimitLabel, muppet.LimitBreakCountLimit.ToString(), show: true);
		}
		SetLevelLabelColor(muppet);
		if ((bool)curAttackPointLabel)
		{
			curAttackPointLabel.text = muppet.TotalAttack.ToString();
			curAttackPointLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPointLabel)
		{
			curHitPointLabel.text = muppet.TotalHP.ToString();
			curHitPointLabel.gameObject.SetActive(value: true);
		}
		UIBasicUtility.SetSumPlusBonusLabel(curSumPlusLabel, muppet);
		SetEnableAlphaTargets("PlusText", 0 < muppet.SumPlusBonus);
		UIBasicUtility.SetPlusBonusLabel(curAttackPlusPointLabel, muppet.AttackPlusBonus, muppet.IsAttackPlusBonusMax);
		UIBasicUtility.SetPlusBonusLabel(curHitPlusPointLabel, muppet.HpPlusBonus, muppet.IsHpPlusBonusMax);
		if ((bool)curBuyPriceLabel)
		{
			curBuyPriceLabel.text = muppet.SellPrice.ToString();
			curBuyPriceLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curSellPriceLabel)
		{
			curSellPriceLabel.text = muppet.SellPrice.ToString();
			curSellPriceLabel.gameObject.SetActive(value: true);
		}
		if ((bool)curAttackPointLabel2)
		{
			curAttackPointLabel2.text = muppet.TotalAttack.ToString();
			curAttackPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPointLabel2)
		{
			curHitPointLabel2.text = muppet.TotalHP.ToString();
			curHitPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curAttackPlusPointLabel2)
		{
			curAttackPlusPointLabel2.text = muppet.AttackBonus.ToString();
			curAttackPlusPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curHitPlusPointLabel2)
		{
			curHitPlusPointLabel2.text = muppet.HpBonus.ToString();
			curHitPlusPointLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curBuyPriceLabel2)
		{
			curBuyPriceLabel2.text = muppet.SellPrice.ToString();
			curBuyPriceLabel2.gameObject.SetActive(value: true);
		}
		if ((bool)curSellPriceLabel2)
		{
			curSellPriceLabel2.text = muppet.SellPrice.ToString();
			curSellPriceLabel2.gameObject.SetActive(value: true);
		}
	}

	public void SetTotalMuppetStatus(RespPoppet[] muppet)
	{
		initArray = true;
		lastTotalMuppetArray = muppet;
		setTotalMuppetArray = muppet;
		if (muppet == null)
		{
			SetTotalMuppetStatusCore(null);
		}
	}

	private void SetTotalMuppetStatusCore(RespPoppet[] muppet)
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
		checked
		{
			if (!(muppet == null))
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int i = 0;
				for (int length = muppet.Length; i < length; i++)
				{
					num += muppet[i].Attack;
					num2 += muppet[i].HP;
					num3 += muppet[i].Attack;
					num4 += muppet[i].HP;
					num5 += muppet[i].damageScale(EnumElements.fire);
					num6 += muppet[i].damageScale(EnumElements.water);
					num7 += muppet[i].damageScale(EnumElements.wind);
					num8 += muppet[i].damageScale(EnumElements.earth);
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

	internal void _0024SetMuppetCore_0024closure_00243043(AIControl ai)
	{
		GameObject gameObject = ai.gameObject;
		if ((bool)ai)
		{
			ai.enabled = false;
		}
		gameObject.transform.parent = cur3DModel.transform;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		NGUITools.SetLayer(gameObject, cur3DModel.gameObject.layer);
		cur3DModel.gameObject.SetActive(value: true);
	}
}
