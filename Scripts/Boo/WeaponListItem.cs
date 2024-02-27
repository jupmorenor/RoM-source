using System;
using System.Collections;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WeaponListItem : UIListItem
{
	public bool enableLabel;

	public bool enableLevelLabel;

	public bool enableLevelMaxLabel;

	public bool enableTypeLabel;

	public bool enableSkill1Label;

	public bool enableSkill2Label;

	public bool enableSkill3Label;

	public bool enableSkill1LvLabel;

	public bool enableSkill2LvLabel;

	public bool enableSkill3LvLabel;

	public bool enableIconSprite;

	public bool enableIconFavorite;

	public bool enablePanelFrame;

	public bool enableIconNumber;

	public bool enableCautionLabel;

	public bool enableIconElemSprite;

	public bool enableRankSprite;

	public bool enableDeckCostLabel;

	public bool enableTraitSprite;

	public bool enableAtkPlusLabel;

	public bool enableHpPlusLabel;

	public bool enableSumPlusLabel;

	public string levelFormat;

	public string levelMaxText;

	private UILabelBase nameLabel;

	private UILabelBase _levelLabel;

	private UILabelBase levelMaxLabel;

	private UILabelBase typeLabel;

	private UILabelBase skill1Label;

	private UILabelBase skill2Label;

	private UILabelBase skill1LvLabel;

	private UILabelBase skill2LvLabel;

	private UILabelBase deckCostLabel;

	private UISprite traitSprite;

	private UISprite iconSprite;

	private UISprite iconNumber;

	private GameObject panelFrame;

	private UISprite iconElemSprite;

	private UISprite iconRankSprite;

	public GameObject weaponIconPrefab;

	private WeaponInfo dispInfo;

	private RespWeapon _weaponInfo;

	private UILabelBase atkPlusLabel;

	private UILabelBase hpPlusLabel;

	private UILabelBase sumPlusLabel;

	private UIValidController validController;

	private UIValidController validController2;

	public bool deleteIconLevel;

	private bool isDeletedIconLevel;

	private GameObject iconInstance;

	private bool lastFavo;

	public UILabelBase levelLabel
	{
		get
		{
			return _levelLabel;
		}
		set
		{
			_levelLabel = value;
		}
	}

	public UISprite elemSprite
	{
		get
		{
			return iconElemSprite;
		}
		set
		{
			iconElemSprite = value;
		}
	}

	public UISprite rankSprite
	{
		get
		{
			return iconRankSprite;
		}
		set
		{
			iconRankSprite = value;
		}
	}

	public RespWeapon weaponInfo
	{
		get
		{
			return _weaponInfo;
		}
		set
		{
			_weaponInfo = value;
		}
	}

	public GameObject Icon => iconInstance;

	public WeaponListItem()
	{
		levelFormat = "lv.{0}";
		levelMaxText = "限界突破";
	}

	public void SetLevelLabelColor(RespWeapon weapon)
	{
		if (weapon != null)
		{
			if ((bool)levelLabel)
			{
				UIBasicUtility.SetLabelColor(levelLabel, weapon.LevelColor);
			}
			if ((bool)levelMaxLabel)
			{
				UIBasicUtility.SetLabelColor(levelMaxLabel, weapon.LevelColor);
			}
		}
	}

	public void SetState(bool use, bool disable)
	{
		if (use)
		{
			UserData current = UserData.Current;
			RespWeapon data = GetData<RespWeapon>();
			if (data != null)
			{
				UsingText = UIBasicUtility.GetUseItemString(current.IsUsingWeapon(data.Id), weapon: true);
			}
		}
		SetState(use, disable, effect: true);
	}

	public void SetState(bool use, bool disable, bool effect)
	{
		ShowUsingText(use, disable);
		if ((bool)validController)
		{
			validController.validColorIsForceWhite = true;
		}
		if ((bool)validController2)
		{
			validController2.validColorIsForceWhite = true;
		}
		if (effect)
		{
			if ((bool)validController2)
			{
				validController2.isValidColor = true;
			}
			if ((bool)validController)
			{
				validController.isValidColor = !disable;
			}
		}
		else if ((bool)validController2)
		{
			validController2.isValidColor = false;
		}
		SetLevelLabelColor(weaponInfo);
	}

	public void SetNumber(int num)
	{
		Number = num;
		if ((bool)panelFrame)
		{
			panelFrame.gameObject.SetActive(Number > 0);
		}
		if (Number > 0)
		{
			UIBasicUtility.SetSprite(iconNumber, UIBasicUtility.SafeFormat("icon_edit_num{0}", Number), null, enableIconNumber);
		}
	}

	public GameObject SetWeapon(RespWeapon weapon)
	{
		return SetWeapon(weapon, ignoreUnknown: false);
	}

	public GameObject SetWeapon(RespWeapon weapon, bool ignoreUnknown)
	{
		object result;
		if (weapon == null)
		{
			result = null;
		}
		else
		{
			Reset();
			IgnoreUnknown = ignoreUnknown;
			weaponInfo = weapon;
			UserData current = UserData.Current;
			if (AutoUsingCheck)
			{
				Using = current.IsUsingWeapon(weapon);
			}
			bool flag = true;
			if (!IgnoreUnknown)
			{
				flag = current.userMiscInfo.weaponBookData.isLook(weapon.Master);
			}
			if (ForceUnknown)
			{
				flag = false;
			}
			UIBasicUtility.SetWeaponIconSpriteEx(iconSprite, weapon, show: true, IgnoreUnknown, !flag);
			ForceUnknown = false;
			UIBasicUtility.SetLabel(nameLabel, (!flag) ? "???" : weapon.Name, enableLabel);
			if (!flag)
			{
				result = null;
			}
			else
			{
				if (weapon.IsLevelLimit)
				{
					enableLevelLabel = true;
					enableLevelMaxLabel = true;
				}
				else
				{
					enableLevelLabel = true;
					enableLevelMaxLabel = false;
				}
				UIBasicUtility.SetLabel(levelLabel, UIBasicUtility.SafeFormat(levelFormat, weapon.Level), enableLevelLabel);
				UIBasicUtility.SetLabel(levelMaxLabel, levelMaxText, enableLevelMaxLabel);
				UIBasicUtility.SetLabel(typeLabel, weapon.Style.Name.ToString(), enableTypeLabel);
				UIBasicUtility.SetLabel(skill1Label, (weapon.AngelSkill == null) ? "無し" : weapon.AngelSkill.Name.ToString(), enableSkill1Label);
				UIBasicUtility.SetLabel(skill2Label, (weapon.DemonSkill == null) ? "無し" : weapon.DemonSkill.Name.ToString(), enableSkill2Label);
				UIBasicUtility.SetLabel(skill1LvLabel, UIBasicUtility.SafeFormat(levelFormat, weapon.AngelSkillLevel), enableSkill1LvLabel);
				UIBasicUtility.SetLabel(skill2LvLabel, UIBasicUtility.SafeFormat(levelFormat, weapon.DemonSkillLevel), enableSkill2LvLabel);
				UIBasicUtility.SetLabel(deckCostLabel, weapon.DeckCost.ToString(), enableDeckCostLabel);
				UIBasicUtility.SetSprite(traitSprite, weapon.TraitSpriteName, null, enableTraitSprite);
				UIListItem.InitAlphaLoopCtrls(this);
				StartAlphaLoopCtrl();
				if (enableSumPlusLabel)
				{
					UIBasicUtility.SetSumPlusBonusLabel(sumPlusLabel, weapon);
				}
				else
				{
					UIBasicUtility.SetLabel(sumPlusLabel, string.Empty, show: false);
				}
				SetEnableAlphaTargets("PlusText", 0 < weapon.SumPlusBonus);
				SetFavorite(current.IsFavorite(weapon.RefPlayerBox));
				canShowNew = true;
				SetNew(current.IsNewItem(weapon.RefPlayerBox));
				if ((bool)panelFrame)
				{
					panelFrame.gameObject.SetActive(Number > 0);
				}
				ShowUsingText(Using, Disable);
				SetLevelLabelColor(weapon);
				result = iconInstance;
			}
		}
		return (GameObject)result;
	}

	public override void DestroyLevel()
	{
		if ((bool)dispInfo)
		{
			dispInfo.DestroyLevel();
		}
	}

	public void Reset()
	{
		if (!dispInfo)
		{
			if (!iconInstance && (bool)weaponIconPrefab)
			{
				iconInstance = NGUITools.InstantiateWithoutUIPanel(weaponIconPrefab);
			}
			GameObject gameObject = iconInstance;
			if ((bool)gameObject)
			{
				gameObject.transform.parent = this.transform;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = Vector3.one;
				dispInfo = gameObject.GetComponent<WeaponInfo>();
				if ((bool)dispInfo)
				{
					if (deleteIconLevel && !isDeletedIconLevel)
					{
						isDeletedIconLevel = true;
						DestroyLevel();
					}
					dispInfo.SetData(GetData());
					copyState.copyUsingFlag = false;
					copyState.copyDisableFlag = false;
					copyState.copyFavoriteFlag = false;
					copyState.copyCautionText = false;
					copyState.copyUsingText = false;
					copyState.copyAlphaTarget = true;
					Copy(dispInfo);
					dispInfo.enabled = false;
					iconOption = dispInfo.iconOption;
					SetMyComponet(ref nameLabel, dispInfo.curNameLabel, enableLabel);
					SetMyComponet(ref _levelLabel, dispInfo.curLevelLabel, enableLevelLabel);
					SetMyComponet(ref levelMaxLabel, dispInfo.curMaxLevelLabel, enableLevelLabel);
					SetMyComponet(ref typeLabel, dispInfo.curTypeLabel, enableTypeLabel);
					SetMyComponet(ref skill1Label, dispInfo.curSkill1Label, enableSkill1Label);
					SetMyComponet(ref skill2Label, dispInfo.curSkill2Label, enableSkill2Label);
					SetMyComponet(ref skill1LvLabel, dispInfo.curSkill1LvLabel, enableSkill1LvLabel);
					SetMyComponet(ref skill2LvLabel, dispInfo.curSkill2LvLabel, enableSkill2LvLabel);
					SetMyComponet(ref iconSprite, dispInfo.curIconSprite, enableIconSprite);
					SetMyComponet(ref iconNumber, dispInfo.curIconNumberSprite, enableIconNumber);
					SetMyGameObject(ref panelFrame, dispInfo.curIconFramePanel, enableIconNumber);
					SetMyComponet(ref deckCostLabel, dispInfo.deckCostLabel, enableDeckCostLabel);
					SetMyComponet(ref traitSprite, dispInfo.traitSprite, enableTraitSprite);
					SetMyComponet(ref sumPlusLabel, dispInfo.curSumPlusLabel, enableSumPlusLabel);
				}
				UIValidController component = this.gameObject.GetComponent<UIValidController>();
				if ((bool)component)
				{
					IEnumerator enumerator = gameObject.transform.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (!(obj is Transform))
						{
							obj = RuntimeServices.Coerce(obj, typeof(Transform));
						}
						Transform transform = (Transform)obj;
						if (transform != null && transform.name == "State")
						{
							component.validEffectTarget = transform.gameObject;
							break;
						}
					}
				}
				validController = component;
				UIValidController uIValidController = this.gameObject.AddComponent<UIValidController>();
				uIValidController.validEffectTarget = this.gameObject;
				uIValidController.invalidColor = UIBasicUtility.GetColor(90f, 90f, 90f, 160f);
				validController2 = uIValidController;
			}
		}
		UIBasicUtility.SetSpriteByIconAtlasPool(iconSprite, "W_none", show: true);
	}

	private void SetMyComponet<T>(ref T dist, T src, bool enable) where T : MonoBehaviour
	{
		if (dist == null && src != null)
		{
			if (enable)
			{
				dist = src;
			}
			else
			{
				src.gameObject.SetActive(value: false);
			}
		}
	}

	private void SetMyGameObject(ref GameObject dist, GameObject src, bool enable)
	{
		if (dist == null && src != null)
		{
			if (enable)
			{
				dist = src;
			}
			else
			{
				src.SetActive(value: false);
			}
		}
	}

	public void Update()
	{
		UpdateAlphaLoopCtrl();
		if (enableIconFavorite)
		{
			RespPlayerBox respPlayerBox = RespPlayerBox.ConvertRespPlayerBox(GetData<JsonBase>());
			if (respPlayerBox != null && UserData.Current.IsFavorite(respPlayerBox) != lastFavo)
			{
				lastFavo = !lastFavo;
				SetFavorite(lastFavo);
			}
		}
	}
}
