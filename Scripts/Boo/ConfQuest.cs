using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ConfQuest : DeckSelector
{
	[Serializable]
	private enum WorldType
	{
		Quest,
		Raid,
		Challenge,
		Colosseum,
		Max
	}

	private WorldType _worldType;

	private QuestMenuBase _questMenuBase;

	private List<GameObject> _supportButtonList;

	private GameObject _supportButtonBackground;

	protected bool supportDialogFlag;

	public GameObject supportDialog;

	public GameObject supportButton;

	public GameObject worldButton;

	public GameObject questGoButton;

	public GameObject raidBonus;

	public GameObject raidBonusStyle;

	public GameObject raidBonusElement;

	public GameObject raidStartButton;

	[NonSerialized]
	private static string[] _supportTypeNameArray = new string[4] { null, "atk", "hp", "castum" };

	public new static ConfQuest Current()
	{
		if (!(null != DeckSelector._current))
		{
			throw new AssertionFailedException("null != _current");
		}
		return DeckSelector._current as ConfQuest;
	}

	public new void Start()
	{
		base.Start();
		_updateWorldType();
		_updateWorldGui();
		_buildSupportButtonList();
		_initSupportDialog();
		_updateSupportButtonGui(DeckSelector._currentDeckIndex);
	}

	public new void Close()
	{
		base.Close();
		_hideSupportDialog();
	}

	protected override void _updateDeckGui()
	{
		base._updateDeckGui();
		_updateSupportButtonGui(DeckSelector._currentDeckIndex);
	}

	private void _updateWorldType()
	{
		_worldType = (WorldType)(-1);
		Transform parent = transform.parent;
		GameObject gameObject = null;
		UIMain uIMain = null;
		while (null != parent)
		{
			gameObject = parent.gameObject;
			if (null != gameObject)
			{
				uIMain = gameObject.GetComponent<UIMain>();
			}
			if (null != uIMain)
			{
				break;
			}
			parent = parent.parent;
		}
		_questMenuBase = gameObject.GetComponent<WorldQuestMain>();
		if (null != _questMenuBase)
		{
			_worldType = WorldType.Quest;
		}
		if (null == _questMenuBase)
		{
			_questMenuBase = gameObject.GetComponent<WorldRaidMain>();
			if (null != _questMenuBase)
			{
				_worldType = WorldType.Raid;
			}
		}
		if (null == _questMenuBase)
		{
			_questMenuBase = gameObject.GetComponent<WorldChallengeMain>();
			if (null != _questMenuBase)
			{
				_worldType = WorldType.Challenge;
			}
		}
		if (null == _questMenuBase)
		{
			_questMenuBase = gameObject.GetComponent<WorldColosseumMain>();
			if (null != _questMenuBase)
			{
				_worldType = WorldType.Colosseum;
			}
		}
		if (!(null != _questMenuBase))
		{
			throw new AssertionFailedException("null != _questMenuBase");
		}
	}

	private void _updateWorldGui()
	{
		worldButton.SetActive(value: true);
		if (questGoButton != null)
		{
			questGoButton.SetActive(value: false);
		}
		if ((bool)raidBonus)
		{
			raidBonus.SetActive(value: false);
		}
		switch (_worldType)
		{
		case WorldType.Quest:
			questGoButton.SetActive(value: true);
			break;
		case WorldType.Raid:
		{
			raidBonus.SetActive(value: true);
			raidStartButton.SetActive(value: true);
			UserRaidData userRaidInfo = UserData.Current.userRaidInfo;
			if (userRaidInfo != null)
			{
				RespTCycleRaidBattle raidBattle = userRaidInfo.raidBattle;
				if (raidBattle != null)
				{
					string styleSpriteName = UIBasicUtility.GetStyleSpriteName(raidBattle.StyleId);
					UISprite uISprite = raidBonusStyle.GetComponent<UISprite>() as UISprite;
					uISprite.spriteName = styleSpriteName;
					string elementSpriteName = UIBasicUtility.GetElementSpriteName(raidBattle.ElementId);
					UISprite uISprite2 = raidBonusElement.GetComponent<UISprite>() as UISprite;
					uISprite2.spriteName = elementSpriteName;
				}
			}
			break;
		}
		case WorldType.Challenge:
			questGoButton.SetActive(value: true);
			break;
		}
	}

	public static ApiUpdateDeck2 CreateDeck2Request()
	{
		UserData current = UserData.Current;
		ApplyDeck2Data();
		return current.userDeckData2.createRequest();
	}

	public new static WeaponEquipments[] CreateWeaponEquipmentsArray()
	{
		int num = DeckSelector._current.deckCount;
		WeaponEquipments[] array = new WeaponEquipments[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			DeckItemUi deckItemUi = (DeckItemUi)DeckSelector._current._getDeckItemUi(num4);
			WeaponEquipments weaponEquipments = null;
			if (null != deckItemUi)
			{
				weaponEquipments = deckItemUi.weaponEquipments;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, num4)] = weaponEquipments;
		}
		return array;
	}

	public static PoppetEquipments[] CreatePoppetEquipmentsArray()
	{
		int num = DeckSelector._current.deckCount;
		PoppetEquipments[] array = new PoppetEquipments[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			DeckItemUi deckItemUi = (DeckItemUi)DeckSelector._current._getDeckItemUi(num4);
			PoppetEquipments poppetEquipments = null;
			if (null != deckItemUi)
			{
				poppetEquipments = deckItemUi.poppetEquipments;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, num4)] = poppetEquipments;
		}
		return array;
	}

	public static UserConfigData.DeckTypes[] CreateDeckTypesArray()
	{
		int num = DeckSelector._current.deckCount;
		UserConfigData.DeckTypes[] array = new UserConfigData.DeckTypes[num];
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int num4 = num2;
			num2++;
			DeckItemUi deckItemUi = (DeckItemUi)DeckSelector._current._getDeckItemUi(num4);
			UserConfigData.DeckTypes deckTypes = UserConfigData.DeckTypes.None;
			if (null != deckItemUi)
			{
				deckTypes = deckItemUi.supportType;
			}
			array[RuntimeServices.NormalizeArrayIndex(array, num4)] = deckTypes;
		}
		return array;
	}

	public static void ApplyDeck2Data()
	{
		UserData.Current.userDeckData2.CurrentDeck = DeckSelector.currentDeckIndex;
		UserDeckData2.WepEquips = CreateWeaponEquipmentsArray();
		UserData.Current.userDeckData2.PetEquips = CreatePoppetEquipmentsArray();
		UserData.Current.userDeckData2.DeckTypes = CreateDeckTypesArray();
	}

	private void _buildSupportButtonList()
	{
		_supportButtonList = new List<GameObject>();
		Transform transform = supportButton.transform;
		int num = 0;
		int num2 = 4;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			_supportButtonList.Add(null);
		}
		int num4 = 0;
		int childCount = transform.childCount;
		if (childCount < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < childCount)
		{
			int index = num4;
			num4++;
			Transform child = transform.GetChild(index);
			GameObject gameObject = child.gameObject;
			switch (gameObject.name)
			{
			case "0 AtkPanel":
				_supportButtonList[1] = gameObject;
				break;
			case "1 HpPanel":
				_supportButtonList[2] = gameObject;
				break;
			case "2 CustomPanel":
				_supportButtonList[3] = gameObject;
				break;
			case "Background":
				_supportButtonBackground = gameObject;
				break;
			}
		}
	}

	private void _updateSupportButtonGui(int aDeckIndex)
	{
		if (_supportButtonList == null)
		{
			return;
		}
		DeckItemUiBase deckItemUiBase = _getDeckItemUi(aDeckIndex);
		int supportType = (int)deckItemUiBase.supportType;
		bool flag = true;
		if (supportType != 0)
		{
			int num = 0;
			int num2 = 4;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				GameObject gameObject = _supportButtonList[num3];
				bool flag2 = false;
				if (supportType == num3)
				{
					flag2 = true;
				}
				if (gameObject != null)
				{
					gameObject.SetActive(flag2);
				}
			}
		}
		else if (_supportButtonList != null)
		{
			_supportButtonList[1].SetActive(value: false);
			_supportButtonList[2].SetActive(value: false);
			_supportButtonList[3].SetActive(value: true);
		}
	}

	public void OnClickedSupport()
	{
		if (!_swipePanelComponent.IsDrag)
		{
			_showSupportDialog(aValid: true);
		}
	}

	private void _initSupportDialog()
	{
		if ((bool)supportDialog)
		{
			UIAutoTweenerStandAloneEx.Hide(supportDialog);
		}
		supportDialogFlag = false;
	}

	private void _showSupportDialog(bool aValid)
	{
		if (!_questMenuBase || !supportDialog)
		{
			return;
		}
		if (aValid)
		{
			if (!_questMenuBase.IsShowConfQuestSupportDialog && !supportDialogFlag)
			{
				UIAutoTweenerStandAloneEx.In(supportDialog, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
				{
					supportDialogFlag = true;
				}));
				_questMenuBase.IsShowConfQuestSupportDialog = true;
			}
		}
		else if (_questMenuBase.IsShowConfQuestSupportDialog && supportDialogFlag)
		{
			UIAutoTweenerStandAloneEx.Out(supportDialog, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
			{
				_questMenuBase.IsShowConfQuestSupportDialog = false;
				supportDialogFlag = false;
			}));
		}
	}

	private void _hideSupportDialog()
	{
		if ((bool)_questMenuBase && (bool)supportDialog)
		{
			UIAutoTweenerStandAloneEx.Hide(supportDialog);
			_questMenuBase.IsShowConfQuestSupportDialog = false;
			supportDialogFlag = false;
		}
	}

	public static void ShowSupportDialog(bool aValid)
	{
		Current()._showSupportDialog(aValid);
	}

	public static void HideSupportDialog()
	{
		Current()._hideSupportDialog();
	}

	public void setSupportType(int aDeckIndex, UserConfigData.DeckTypes aType, bool aGui)
	{
		DeckItemUiBase deckItemUiBase = _getDeckItemUi(aDeckIndex);
		deckItemUiBase.setSupportType(aType, aUpdate: true);
		UserConfigData.DeckTypes[] deckTypes = UserData.Current.userDeckData2.DeckTypes;
		deckTypes[RuntimeServices.NormalizeArrayIndex(deckTypes, aDeckIndex)] = aType;
		if (aGui)
		{
			_updateSupportButtonGui(aDeckIndex);
		}
	}

	public void setSupportTypeFromName(string aName, bool aClose)
	{
		int num = 0;
		int length = _supportTypeNameArray.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			string[] supportTypeNameArray = _supportTypeNameArray;
			string text = supportTypeNameArray[RuntimeServices.NormalizeArrayIndex(supportTypeNameArray, num2)];
			if (text != null)
			{
				int num3 = aName.IndexOf(text, StringComparison.OrdinalIgnoreCase);
				if (0 <= num3)
				{
					setSupportType(DeckSelector._currentDeckIndex, (UserConfigData.DeckTypes)num2, aGui: true);
					break;
				}
			}
		}
		if (aClose)
		{
			_showSupportDialog(aValid: false);
		}
	}

	public static void SetSupportTypeFromName(string aName, bool aClose)
	{
		Current().setSupportTypeFromName(aName, aClose);
	}

	internal void _0024_showSupportDialog_0024closure_00243075()
	{
		supportDialogFlag = true;
	}

	internal void _0024_showSupportDialog_0024closure_00243076()
	{
		_questMenuBase.IsShowConfQuestSupportDialog = false;
		supportDialogFlag = false;
	}
}
