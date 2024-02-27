using System;
using System.Collections;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MapetListItem : UIListItem
{
	public bool deleteUIPanel;

	public bool enableLabel;

	public bool enableExplainLabel;

	public bool enableLevelMaxLabel;

	public bool enableLevelLabel;

	public bool enableTypeLabel;

	public bool enableMagicLabel;

	public bool enableSkill1Label;

	public bool enableSkill2Label;

	public bool enableMagicLvLabel;

	public bool enableSkill1LvLabel;

	public bool enableSkill2LvLabel;

	public bool enableIconSprite;

	public bool enableIconFavorite;

	public bool enablePanelFrame;

	public bool enableIconNumber;

	public bool enableCautionLabel;

	public bool enableIconElemSprite;

	public bool enableRankSprite;

	public bool enableUserNameLabel;

	public bool enableFriendPointLabel;

	public bool enableFriendPetLevelLabel;

	public bool enableCharLevelLabel;

	public bool enableAtkPlusLabel;

	public bool enableHpPlusLabel;

	public bool enableSumPlusLabel;

	public bool enableIsNPC;

	public bool enableBreederRankId;

	public bool enableBreederRankPoint;

	public bool enableDeckCostLabel;

	public bool enableTraitSprite;

	public string levelForamt;

	public string levelMaxText;

	public string magicLevelForamt;

	public string skillLevelForamt;

	private UILabelBase nameLabel;

	private UILabelBase explainLabel;

	private UILabelBase _levelLabel;

	private UILabelBase levelMaxLabel;

	private UILabelBase typeLabel;

	private UILabelBase magicLabel;

	private UILabelBase skill1Label;

	private UILabelBase skill2Label;

	private UILabelBase magicLvLabel;

	private UILabelBase skill1LvLabel;

	private UILabelBase skill2LvLabel;

	private UILabelBase deckCostLabel;

	private UISprite traitSprite;

	private UISprite iconSprite;

	private UISprite iconNumber;

	private GameObject panelDisable;

	private GameObject panelFrame;

	private UISprite iconElemSprite;

	private UISprite iconRankSprite;

	public UILabelBase userNameLabel;

	public UILabelBase friendPontLabel;

	public UILabelBase friendPetLevelLabel;

	public string friendPetLevelForamt;

	public UILabelBase charLevelLabel;

	public string charLevelForamt;

	public GameObject isNpcIcon;

	public UILabelBase breederRankIdLabel;

	public UISprite breederRankIdIcon;

	public UILabelBase breederRankPointLabel;

	public string breederRankPointFormat;

	public Vector3 iconPos;

	public Vector3 iconScl;

	public GameObject muppetIconPrefab;

	private MuppetInfo dispInfo;

	private RespPoppet _mapetInfo;

	private UILabelBase atkPlusLabel;

	private UILabelBase hpPlusLabel;

	private UILabelBase sumPlusLabel;

	private UIValidController validController;

	private UIValidController validController2;

	public UILabelBase[] extraParamLabel;

	public GameObject[] extraGameObject;

	public UISprite bgPanelSprite;

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

	public RespPoppet mapetInfo
	{
		get
		{
			return _mapetInfo;
		}
		set
		{
			_mapetInfo = value;
		}
	}

	public GameObject Icon => iconInstance;

	public MapetListItem()
	{
		deleteUIPanel = true;
		levelForamt = "{0}";
		levelMaxText = "限界突破";
		magicLevelForamt = "{0}";
		skillLevelForamt = "{0}";
		friendPetLevelForamt = "{0}";
		charLevelForamt = "{0}";
		breederRankPointFormat = "{0}";
		iconPos = Vector3.zero;
		iconScl = Vector3.one;
	}

	public void SetLevelLabelColor(RespPoppet pet)
	{
		if (pet != null)
		{
			if ((bool)levelLabel)
			{
				UIBasicUtility.SetLabelColor(levelLabel, pet.LevelColor);
			}
			if ((bool)levelMaxLabel)
			{
				UIBasicUtility.SetLabelColor(levelMaxLabel, pet.LevelColor);
			}
		}
	}

	public void SetState(bool use, bool disable)
	{
		if (use)
		{
			UserData current = UserData.Current;
			RespPoppet data = GetData<RespPoppet>();
			if (data != null)
			{
				UsingText = UIBasicUtility.GetUseItemString(current.IsUsing(data.Id), weapon: false);
			}
		}
		SetState(use, disable, effect: true);
	}

	public void SetState(bool use, bool disable, bool effect)
	{
		ShowUsingText(use, disable);
		if ((bool)panelDisable)
		{
			panelDisable.gameObject.SetActive(value: false);
		}
		if ((bool)validController)
		{
			validController.validColorIsForceWhite = true;
		}
		if ((bool)validController2)
		{
			validController2.validColorIsForceWhite = true;
		}
		if (!effect)
		{
			if ((bool)validController2)
			{
				validController2.isValidColor = false;
			}
		}
		else
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
		SetLevelLabelColor(mapetInfo);
	}

	public void SetNumber(int num)
	{
		if ((bool)panelFrame)
		{
			panelFrame.gameObject.SetActive(num > 0);
		}
		if (num > 0)
		{
			UISprite sprite = iconNumber;
			string text = $"icon_edit_num{num}";
			bool num2 = enableIconNumber;
			if (num2)
			{
				num2 = num > 0;
			}
			UIBasicUtility.SetSprite(sprite, text, null, num2);
		}
	}

	private void UpdateMapet()
	{
		SetMapet(mapetInfo);
	}

	public GameObject SetMapet(RespPoppet poppet)
	{
		return SetMapet(poppet, ignoreUnknown: false);
	}

	public GameObject SetMapet(RespPoppet poppet, bool ignoreUnknown)
	{
		object result;
		if (poppet == null)
		{
			result = null;
		}
		else
		{
			Reset();
			IgnoreUnknown = ignoreUnknown;
			mapetInfo = poppet;
			UserData current = UserData.Current;
			if (AutoUsingCheck)
			{
				Using = current.IsUsingPoppet(poppet);
			}
			bool flag = true;
			if (!IgnoreUnknown)
			{
				flag = current.userMiscInfo.poppetBookData.isLook(poppet.Master);
			}
			if (ForceUnknown)
			{
				flag = false;
			}
			UIBasicUtility.SetPoppetIconSpriteEx(iconSprite, poppet, show: true, IgnoreUnknown, !flag);
			UIBasicUtility.SetLabel(nameLabel, (!flag) ? "???" : poppet.Name, enableLabel);
			if (flag)
			{
				if (poppet.IsLevelLimit)
				{
					enableLevelLabel = true;
					enableLevelMaxLabel = true;
				}
				else
				{
					enableLevelLabel = true;
					enableLevelMaxLabel = false;
				}
				UIBasicUtility.SetLabel(levelLabel, UIBasicUtility.SafeFormat(levelForamt, poppet.Level), enableLevelLabel);
				UIBasicUtility.SetLabel(levelMaxLabel, levelMaxText, enableLevelMaxLabel);
				UIBasicUtility.SetLabel(explainLabel, poppet.Detail.ToString(), enableExplainLabel);
				UIBasicUtility.SetLabel(typeLabel, poppet.Element.Name.ToString(), enableTypeLabel);
				UIBasicUtility.SetLabel(magicLabel, poppet.ChainSkill.Name.ToString(), enableMagicLabel);
				UIBasicUtility.SetLabel(skill1Label, (poppet.CoverSkill1 == null) ? string.Empty : poppet.CoverSkill1.Name.ToString(), enableSkill1Label);
				UIBasicUtility.SetLabel(skill2Label, (poppet.CoverSkill2 == null) ? string.Empty : poppet.CoverSkill2.Name.ToString(), enableSkill2Label);
				UIBasicUtility.SetLabel(magicLvLabel, string.Format(magicLevelForamt, poppet.ChainSkillLevel), enableMagicLvLabel);
				UIBasicUtility.SetLabel(skill1LvLabel, string.Format(skillLevelForamt, poppet.CoverSkillLevel_1), enableSkill1LvLabel);
				UIBasicUtility.SetLabel(skill2LvLabel, string.Format(skillLevelForamt, poppet.CoverSkillLevel_2), enableSkill2LvLabel);
				UIBasicUtility.SetLabel(deckCostLabel, poppet.DeckCost.ToString(), enableDeckCostLabel);
				UIBasicUtility.SetSprite(traitSprite, poppet.TraitSpriteName, null, enableTraitSprite);
				UIListItem.InitAlphaLoopCtrls(this);
				StartAlphaLoopCtrl();
				if (enableSumPlusLabel)
				{
					UIBasicUtility.SetSumPlusBonusLabel(sumPlusLabel, poppet);
				}
				else
				{
					UIBasicUtility.SetLabel(sumPlusLabel, string.Empty, show: false);
				}
				SetEnableAlphaTargets("PlusText", 0 < poppet.SumPlusBonus);
				ShowUsingText(Using, Disable);
				SetFavorite(current.IsFavorite(poppet.RefPlayerBox));
				canShowNew = true;
				SetNew(current.IsNewItem(poppet.RefPlayerBox));
				SetLevelLabelColor(poppet);
				if (poppet is RespColosseumOpponentPoppet respColosseumOpponentPoppet)
				{
					UIBasicUtility.SetLabel(userNameLabel, respColosseumOpponentPoppet.UserName.ToString(), enableUserNameLabel);
					UIBasicUtility.SetLabel(charLevelLabel, string.Format(charLevelForamt, respColosseumOpponentPoppet.Level), enableCharLevelLabel);
					if (null != isNpcIcon)
					{
						GameObject obj = isNpcIcon;
						bool isNpc = enableIsNPC;
						if (isNpc)
						{
							isNpc = respColosseumOpponentPoppet.IsNpc;
						}
						obj.SetActive(isNpc);
					}
					UIBasicUtility.SetLabel(breederRankIdLabel, MBreederRanks.Get(respColosseumOpponentPoppet.BreederRankId).DisplayName, enableBreederRankId);
					if (respColosseumOpponentPoppet.BreederRankId > 0)
					{
						UISprite sprite = breederRankIdIcon;
						string text = $"breedrank_{MBreederRanks.Get(respColosseumOpponentPoppet.BreederRankId).Progname}";
						bool num = enableBreederRankId;
						if (num)
						{
							num = respColosseumOpponentPoppet.BreederRankId > 0;
						}
						UIBasicUtility.SetSprite(sprite, text, null, num);
					}
					UIBasicUtility.SetLabel(breederRankPointLabel, string.Format(breederRankPointFormat, respColosseumOpponentPoppet.BreederRankPoint), enableBreederRankPoint);
				}
				else if (poppet is RespFriendPoppet respFriendPoppet)
				{
					UIBasicUtility.SetLabel(userNameLabel, respFriendPoppet.UserName.ToString(), enableUserNameLabel);
					UIBasicUtility.SetLabel(friendPontLabel, respFriendPoppet.FriendPoint.ToString(), enableFriendPointLabel);
					UIBasicUtility.SetLabel(friendPetLevelLabel, string.Format(friendPetLevelForamt, respFriendPoppet.Level), enableFriendPetLevelLabel);
					UIBasicUtility.SetLabelColor(friendPetLevelLabel, poppet.LevelColor);
					UIBasicUtility.SetLabel(charLevelLabel, string.Format(charLevelForamt, respFriendPoppet.CharacterLevel), enableCharLevelLabel);
				}
				result = iconInstance;
			}
			else
			{
				result = null;
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
			if (!iconInstance && (bool)muppetIconPrefab)
			{
				if (deleteUIPanel)
				{
					iconInstance = NGUITools.InstantiateWithoutUIPanel(muppetIconPrefab);
				}
				else
				{
					iconInstance = (GameObject)UnityEngine.Object.Instantiate(muppetIconPrefab);
				}
			}
			GameObject gameObject = iconInstance;
			if ((bool)gameObject)
			{
				gameObject.transform.parent = this.transform;
				gameObject.transform.localPosition = iconPos;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = iconScl;
				dispInfo = gameObject.GetComponent<MuppetInfo>();
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
					SetMyComponet(ref explainLabel, dispInfo.curExplainLabel, enableExplainLabel);
					SetMyComponet(ref _levelLabel, dispInfo.curLevelLabel, enableLevelLabel);
					SetMyComponet(ref levelMaxLabel, dispInfo.curMaxLevelLabel, enableLevelLabel);
					SetMyComponet(ref typeLabel, dispInfo.curTypeLabel, enableTypeLabel);
					SetMyComponet(ref magicLabel, dispInfo.curMagicLabel, enableMagicLabel);
					SetMyComponet(ref skill1Label, dispInfo.curSkill1Label, enableSkill1Label);
					SetMyComponet(ref skill2Label, dispInfo.curSkill2Label, enableSkill2Label);
					SetMyComponet(ref magicLvLabel, dispInfo.curMagicLvLabel, enableMagicLvLabel);
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
						if (transform.name == "State")
						{
							component.validEffectTarget = transform.gameObject;
							break;
						}
					}
				}
				validController = component;
				UIValidController uIValidController = this.gameObject.AddComponent<UIValidController>();
				uIValidController.validEffectTarget = this.gameObject;
				uIValidController.invalidColor = new Color(45f / 128f, 45f / 128f, 45f / 128f, 0.625f);
				validController2 = uIValidController;
			}
		}
		UIBasicUtility.SetSpriteByIconAtlasPool(iconSprite, "P_none", show: true);
	}

	private void SetMyComponet<T>(ref T dist, T src, bool enable) where T : MonoBehaviour
	{
		if (dist == null && (bool)src)
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
		if (dist == null && (bool)src)
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

	private void SetExtraParam(string[] @params)
	{
		if (@params == null || extraParamLabel == null)
		{
			return;
		}
		int length = @params.Length;
		if (extraParamLabel.Length < length)
		{
			length = extraParamLabel.Length;
		}
		int num = 0;
		int num2 = length;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			UILabelBase[] array = extraParamLabel;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num3)])
			{
				UILabelBase[] array2 = extraParamLabel;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num3)].text = @params[RuntimeServices.NormalizeArrayIndex(@params, num3)];
			}
		}
	}

	public void SetExtraParam(int index, string param)
	{
		if (extraParamLabel != null && index >= 0 && extraParamLabel.Length > index)
		{
			UILabelBase[] array = extraParamLabel;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				UILabelBase[] array2 = extraParamLabel;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].text = param;
			}
		}
	}

	public void SetExtraGameObject(int index, bool activeFlag)
	{
		if (extraGameObject != null && index >= 0 && extraGameObject.Length > index)
		{
			GameObject[] array = extraGameObject;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = extraGameObject;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SetActive(activeFlag);
			}
		}
	}

	public void SetBgPanelSprite(string spriteName)
	{
		if ((bool)bgPanelSprite && (bool)bgPanelSprite)
		{
			bgPanelSprite.spriteName = spriteName;
		}
	}

	private void Update()
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
