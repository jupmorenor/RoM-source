using System;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DeckItemUi : DeckItemUiBase
{
	protected WeaponEquipments _weaponEquipments;

	protected PoppetEquipments _poppetEquipments;

	protected RespWeapon _selAngelWeapon;

	protected RespWeapon _selDemonWeapon;

	protected RespWeapon _lastAngelWeapon;

	protected RespWeapon _lastDemonWeapon;

	protected RespPoppet _selMapet;

	protected RespFriendPoppet _selFrMapet;

	protected bool _isFriendMapet;

	protected RespWeapon _lastWeapon;

	protected RespWeapon _lastSubWeapon1;

	protected RespWeapon _lastSubWeapon2;

	protected RespPoppet _lastMapet;

	protected RespPoppet _lastFrMapet;

	public WeaponInfo mainWeaponInfo;

	public WeaponInfo subWeapon1Info;

	public WeaponInfo subWeapon2Info;

	public UILabelBase gearLv;

	public UISprite gearIcon;

	public UISprite gearIconElem;

	public UISprite gearIconRare;

	public UISprite gearSkill1;

	public UISprite gearSkill2;

	public UILabelBase gearSkillName1;

	public UILabelBase gearSkillName2;

	public UILabelBase gearSkill1Lv;

	public UILabelBase gearSkill2Lv;

	public UILabelBase gearAttackPointLabel;

	public UILabelBase gearHitPointLabel;

	public UILabelBase gearPsvSkill;

	public UILabelBase gearPsvSkillName;

	public UILabelBase gearPsvSkillLv;

	public UILabelBase gearPsvSkill2;

	public UILabelBase gearPsvSkill2Name;

	public UILabelBase gearPsvSkill2Lv;

	public UILabelBase gearAttackBonus;

	public UILabelBase gearHpBonus;

	public UILabelBase gearAttackPlusBonus;

	public UILabelBase gearHpPlusBonus;

	public UILabelBase gearTotalAttackBonus;

	public UILabelBase gearTotalHpBonus;

	public UILabelBase petLv;

	public UISprite petIcon;

	public UISprite petIconElem;

	public UISprite petIconRank;

	public UILabelBase petPsvSkill1;

	public UILabelBase petPsvSkill2;

	public UILabelBase petPsvSkill1Lv;

	public UILabelBase petPsvSkill2Lv;

	public UILabelBase petCombinationSkill;

	public UILabelBase petCombinationSkillName;

	public UILabelBase petCombinationSkillLv;

	public UILabelBase petAttack;

	public UILabelBase petHP;

	public UILabelBase petAttackBonus;

	public UILabelBase petHpBonus;

	public UILabelBase petAttackPlusBonus;

	public UILabelBase petHpPlusBonus;

	public UILabelBase petTotalAttackBonus;

	public UILabelBase petTotalHpBonus;

	public UILabelBase frPetName;

	public UILabelBase frPetLv;

	public UISprite frPetIcon;

	public UISprite frPetIconElem;

	public UISprite frPetIconRank;

	public GameObject frFriendPetTag;

	public GameObject frFriendPetSkillPanel;

	public UILabelBase frPetPsvSkill1;

	public UILabelBase frPetPsvSkill2;

	public UILabelBase frPetPsvSkill1Lv;

	public UILabelBase frPetPsvSkill2Lv;

	public GameObject frNoFriendPetSkillPanel;

	public UILabelBase frNoFriendPetSkillLabel;

	public string frNoFriendSkillString;

	public UILabelBase frPetCombinationSkill;

	public UILabelBase frPetCombinationSkillName;

	public UILabelBase frPetCombinationSkillLv;

	public UILabelBase frPetAttack;

	public UILabelBase frPetHP;

	public UILabelBase frPetAttackBonus;

	public UILabelBase frPetHpBonus;

	public UILabelBase frPetAttackPlusBonus;

	public UILabelBase frPetHpPlusBonus;

	public UILabelBase frPetTotalAttackBonus;

	public UILabelBase frPetTotalHpBonus;

	public GameObject frPetTag;

	public GameObject friendIcon;

	public GameObject confQuestUser;

	public GameObject confQuestFriend;

	public GameObject confQuestButton;

	public GameObject mainWeaponIconParent;

	public GameObject sub1WeaponIconParent;

	public GameObject sub2WeaponIconParent;

	public GameObject poppetIconParent;

	public GameObject friendPoppetIconParent;

	public GameObject mainWeaponIcon;

	public GameObject sub1WeaponIcon;

	public GameObject sub2WeaponIcon;

	public GameObject poppetIcon;

	public GameObject friendPoppetIcon;

	public WeaponEquipments weaponEquipments => _weaponEquipments;

	public PoppetEquipments poppetEquipments => _poppetEquipments;

	public RespPoppet selMapet
	{
		get
		{
			return _selMapet;
		}
		set
		{
			object obj = null;
			_selMapet = value;
		}
	}

	public RespWeapon lastWeapon
	{
		get
		{
			return _lastWeapon;
		}
		set
		{
			_lastWeapon = value;
		}
	}

	public RespWeapon lastSubWeapon1
	{
		get
		{
			return _lastSubWeapon1;
		}
		set
		{
			_lastSubWeapon1 = value;
		}
	}

	public RespWeapon lastSubWeapon2
	{
		get
		{
			return _lastSubWeapon2;
		}
		set
		{
			_lastSubWeapon2 = value;
		}
	}

	public DeckItemUi()
	{
		frNoFriendSkillString = "フレンドではないため\n援護スキルが\n発動しません";
	}

	protected void _setAngelWeapon(RespWeapon aWeapon)
	{
		_selAngelWeapon = aWeapon;
		_lastAngelWeapon = null;
	}

	protected void _setDemonWeapon(RespWeapon aWeapon)
	{
		_selDemonWeapon = aWeapon;
		_lastDemonWeapon = null;
	}

	public new void Awake()
	{
		InitWapon();
		InitPoppet();
		InitFrMuppet();
		setLabel(playerAttackPointLabel, " ");
		setLabel(playerHitPointLabel, string.Empty);
	}

	public void Start()
	{
	}

	protected override void InitWapon()
	{
		_lastAngelWeapon = null;
		_lastDemonWeapon = null;
		if ((bool)mainWeaponIcon)
		{
			mainWeaponIcon.SetActive(value: false);
		}
		if ((bool)sub1WeaponIcon)
		{
			sub1WeaponIcon.SetActive(value: false);
		}
		if ((bool)sub2WeaponIcon)
		{
			sub2WeaponIcon.SetActive(value: false);
		}
		setLabel(gearLv, string.Empty);
		setGearSprite(gearIcon, string.Empty);
		setSprite(gearIconElem, string.Empty);
		setLabel(gearAttackPointLabel, string.Empty);
		setLabel(gearHitPointLabel, string.Empty);
		setSprite(gearIconRare, string.Empty);
		setSprite(gearSkill1, string.Empty);
		setSprite(gearSkill2, string.Empty);
		setLabel(gearSkill1Lv, string.Empty);
		setLabel(gearSkill2Lv, string.Empty);
		setLabel(gearSkillName1, initSkillString);
		setLabel(gearSkillName2, initSkillString);
		setLabel(gearPsvSkillName, initSkillString);
		setLabel(gearPsvSkill, string.Empty);
		setLabel(gearPsvSkillLv, string.Empty);
		setLabel(gearPsvSkill2Name, initSkillString);
		setLabel(gearPsvSkill2, string.Empty);
		setLabel(gearPsvSkill2Lv, string.Empty);
		setLabel(gearAttackBonus, string.Empty);
		setLabel(gearHpBonus, string.Empty);
		setLabel(gearAttackPlusBonus, string.Empty);
		setLabel(gearHpPlusBonus, string.Empty);
		setLabel(gearTotalAttackBonus, string.Empty);
		setLabel(gearTotalHpBonus, string.Empty);
		UIButtonMessage component = mainWeaponIconParent.GetComponent<UIButtonMessage>();
		component.sendMessage = true;
		UIButtonMessage component2 = sub1WeaponIconParent.GetComponent<UIButtonMessage>();
		component2.sendMessage = true;
	}

	protected override void InitPoppet()
	{
		_lastMapet = null;
		if ((bool)poppetIcon)
		{
			poppetIcon.SetActive(value: false);
		}
		setLabel(petLv, string.Empty);
		setGearSprite(petIcon, string.Empty);
		setSprite(petIconElem, string.Empty);
		setSprite(petIconRank, string.Empty);
		setLabel(petPsvSkill1, initSkillString);
		setLabel(petPsvSkill2, initSkillString);
		setLabel(petPsvSkill1Lv, string.Empty);
		setLabel(petPsvSkill2Lv, string.Empty);
		setLabel(petCombinationSkill, string.Empty);
		setLabel(petCombinationSkillName, initSkillString);
		setLabel(petCombinationSkillLv, string.Empty);
		setLabel(petAttack, string.Empty);
		setLabel(petHP, string.Empty);
		setLabel(petAttackBonus, string.Empty);
		setLabel(petHpBonus, string.Empty);
		setLabel(petAttackPlusBonus, string.Empty);
		setLabel(petHpPlusBonus, string.Empty);
		setLabel(petTotalAttackBonus, string.Empty);
		setLabel(petTotalHpBonus, string.Empty);
		UIButtonMessage component = poppetIconParent.GetComponent<UIButtonMessage>();
		component.sendMessage = true;
	}

	public void InitFrMuppet()
	{
		_lastFrMapet = null;
		if ((bool)friendPoppetIcon)
		{
			friendPoppetIcon.SetActive(value: false);
		}
		setLabel(frPetName, string.Empty);
		setLabel(frPetLv, string.Empty);
		setGearSprite(frPetIcon, string.Empty);
		setSprite(frPetIconElem, string.Empty);
		setSprite(frPetIconRank, string.Empty);
		setLabel(frPetPsvSkill1, initSkillString);
		setLabel(frPetPsvSkill2, initSkillString);
		setLabel(frPetPsvSkill1Lv, string.Empty);
		setLabel(frPetPsvSkill2Lv, string.Empty);
		setLabel(frPetCombinationSkill, string.Empty);
		setLabel(frPetCombinationSkillName, initSkillString);
		setLabel(frPetCombinationSkillLv, string.Empty);
		setLabel(frPetAttack, string.Empty);
		setLabel(frPetHP, string.Empty);
		setLabel(frPetAttackBonus, string.Empty);
		setLabel(frPetHpBonus, string.Empty);
		setLabel(frPetAttackPlusBonus, string.Empty);
		setLabel(frPetHpPlusBonus, string.Empty);
		setLabel(frPetTotalAttackBonus, string.Empty);
		setLabel(frPetTotalHpBonus, string.Empty);
		if (frPetTag != null)
		{
			frPetTag.SetActive(value: false);
		}
		if (friendIcon != null)
		{
			friendIcon.SetActive(value: false);
		}
		UIButtonMessage component = friendPoppetIconParent.GetComponent<UIButtonMessage>();
		component.sendMessage = true;
	}

	public new void Update()
	{
		UserData current = UserData.Current;
		if (!RuntimeServices.EqualityOperator(_lastAngelWeapon, _selAngelWeapon) || !RuntimeServices.EqualityOperator(_lastDemonWeapon, _selDemonWeapon))
		{
			InitWapon();
			if (_selAngelWeapon != null)
			{
				_lastAngelWeapon = _selAngelWeapon;
				if ((bool)mainWeaponInfo)
				{
					mainWeaponInfo.SetWeapon(_lastAngelWeapon, ignoreUnknown: true);
				}
				DeckItemUiBase.setWeaponIcon(ref mainWeaponIcon, weaponIconPrefab, mainWeaponIconParent, _lastAngelWeapon);
				if (_lastAngelWeapon.AngelSkill != null)
				{
					setLabel(gearSkillName1, _lastAngelWeapon.AngelSkill.Name.ToString());
					SetIcon(gearSkill1, _lastAngelWeapon.AngelSkill.Icon);
					setLabel(gearSkill1Lv, UIBasicUtility.SafeFormat(levelFormat, _lastAngelWeapon.AngelSkillLevel));
				}
				if (_lastAngelWeapon.CoverSkill != null)
				{
					setLabel(gearPsvSkillName, _lastAngelWeapon.CoverSkill.Name.ToString());
					setLabel(gearPsvSkillLv, UIBasicUtility.SafeFormat(levelFormat, _lastAngelWeapon.CoverSkillLevel));
				}
			}
			if (_selDemonWeapon != null)
			{
				_lastDemonWeapon = _selDemonWeapon;
				if ((bool)subWeapon1Info)
				{
					subWeapon1Info.SetWeapon(_lastDemonWeapon, ignoreUnknown: true);
				}
				DeckItemUiBase.setWeaponIcon(ref sub1WeaponIcon, weaponIconPrefab, sub1WeaponIconParent, _lastDemonWeapon);
				if (_lastDemonWeapon.DemonSkill != null)
				{
					setLabel(gearSkillName2, _lastDemonWeapon.DemonSkill.Name.ToString());
					SetIcon(gearSkill2, _lastDemonWeapon.DemonSkill.Icon);
					setLabel(gearSkill2Lv, UIBasicUtility.SafeFormat(levelFormat, _lastDemonWeapon.DemonSkillLevel));
				}
				if (_lastDemonWeapon.CoverSkill != null)
				{
					setLabel(gearPsvSkill2Name, _lastDemonWeapon.CoverSkill.Name.ToString());
					setLabel(gearPsvSkill2Lv, UIBasicUtility.SafeFormat(levelFormat, _lastDemonWeapon.CoverSkillLevel));
				}
			}
		}
		if (!RuntimeServices.EqualityOperator(_lastMapet, _selMapet))
		{
			InitPoppet();
			if (_selMapet != null)
			{
				_lastMapet = _selMapet;
				DeckItemUiBase.setPoppetIcon(ref poppetIcon, poppetIconPrefab, poppetIconParent, _lastMapet);
				setLabel(petLv, UIBasicUtility.SafeFormat(levelFormat, _selMapet.Level));
				setGearSprite(petIcon, _selMapet.Icon);
				setSprite(petIconElem, _selMapet.ElementIcon);
				setSprite(petIconRank, _selMapet.Rare.Icon);
				if (_selMapet.CoverSkill1 != null)
				{
					setLabel(petPsvSkill1, new StringBuilder().Append(selMapet.CoverSkill1.Name).ToString());
					setLabel(petPsvSkill1Lv, UIBasicUtility.SafeFormat(levelFormat, _selMapet.CoverSkillLevel_1));
				}
				else
				{
					setLabel(petPsvSkill1, initSkillString);
					setLabel(petPsvSkill1Lv, string.Empty);
				}
				if (_selMapet.CoverSkill2 != null)
				{
					setLabel(petPsvSkill2, new StringBuilder().Append(_selMapet.CoverSkill2.Name).ToString());
					setLabel(petPsvSkill2Lv, UIBasicUtility.SafeFormat(levelFormat, _selMapet.CoverSkillLevel_2));
				}
				else
				{
					setLabel(petPsvSkill2, initSkillString);
					setLabel(petPsvSkill2Lv, string.Empty);
				}
				if (_selMapet.ChainSkill != null)
				{
					setLabel(petCombinationSkill, MasterExtensionsModule.MultiDetail(_selMapet.ChainSkill));
					setLabel(petCombinationSkillName, _selMapet.ChainSkill.Name.ToString());
					setLabel(petCombinationSkillLv, UIBasicUtility.SafeFormat(levelFormat, _selMapet.ChainSkillLevel));
				}
				else
				{
					setLabel(petCombinationSkill, string.Empty);
					setLabel(petCombinationSkillName, initSkillString);
					setLabel(petCombinationSkillLv, string.Empty);
				}
			}
		}
		if (!RuntimeServices.EqualityOperator(_lastFrMapet, _selFrMapet))
		{
			InitFrMuppet();
			if (_selFrMapet != null)
			{
				_lastFrMapet = _selFrMapet;
				DeckItemUiBase.setPoppetIcon(ref friendPoppetIcon, poppetIconPrefab, friendPoppetIconParent, _lastFrMapet);
				setLabel(frPetName, _selFrMapet.UserName);
				setLabel(frPetLv, UIBasicUtility.SafeFormat(levelFormat, _selFrMapet.Level));
				setGearSprite(frPetIcon, _selFrMapet.Icon);
				setSprite(frPetIconElem, _selFrMapet.ElementIcon);
				setSprite(frPetIconRank, _selFrMapet.Rare.Icon);
				if (null != frNoFriendPetSkillPanel)
				{
					frNoFriendPetSkillPanel.SetActive(value: false);
				}
				if (null != frFriendPetSkillPanel)
				{
					frFriendPetSkillPanel.SetActive(value: true);
				}
				if (null != frFriendPetTag)
				{
					frFriendPetTag.SetActive(value: true);
				}
				if (null != frPetTag)
				{
					frPetTag.SetActive(_isFriendMapet);
				}
				if (null != friendIcon)
				{
					friendIcon.SetActive(_isFriendMapet);
				}
				if (_selFrMapet.CoverSkill1 != null)
				{
					setLabel(frPetPsvSkill1, new StringBuilder().Append(_selFrMapet.CoverSkill1.Name).ToString());
					setLabel(frPetPsvSkill1Lv, UIBasicUtility.SafeFormat(levelFormat, _selFrMapet.CoverSkillLevel_1));
				}
				else
				{
					setLabel(frPetPsvSkill1, initSkillString);
					setLabel(frPetPsvSkill1Lv, string.Empty);
				}
				if (_selFrMapet.CoverSkill2 != null)
				{
					setLabel(frPetPsvSkill2, new StringBuilder().Append(_selFrMapet.CoverSkill2.Name).ToString());
					setLabel(frPetPsvSkill2Lv, UIBasicUtility.SafeFormat(levelFormat, _selFrMapet.CoverSkillLevel_2));
				}
				else
				{
					setLabel(frPetPsvSkill2, initSkillString);
					setLabel(frPetPsvSkill2Lv, string.Empty);
				}
				if (_selFrMapet.ChainSkill != null)
				{
					setLabel(frPetCombinationSkill, MasterExtensionsModule.MultiDetail(_selFrMapet.ChainSkill));
					setLabel(frPetCombinationSkillName, _selFrMapet.ChainSkill.Name.ToString());
					setLabel(frPetCombinationSkillLv, UIBasicUtility.SafeFormat(levelFormat, _selFrMapet.ChainSkillLevel));
				}
				else
				{
					setLabel(frPetCombinationSkill, string.Empty);
					setLabel(frPetCombinationSkillName, initSkillString);
					setLabel(frPetCombinationSkillLv, string.Empty);
				}
			}
		}
		if (_updateAtkHpGui)
		{
			_updateAtkHp();
		}
	}

	public override void _updateAtkHp()
	{
		float num = DamageCalc.TotalPlayerAttack(_weaponEquipments, new RespPoppet[2] { _poppetEquipments.MainPoppet, _selFrMapet });
		float num2 = DamageCalc.TotalPlayerHP(_weaponEquipments, new RespPoppet[2] { _poppetEquipments.MainPoppet, _selFrMapet });
		setLabel(playerAttackPointLabel, num.ToString("0"));
		setLabel(playerHitPointLabel, num2.ToString("0"));
		_updateAtkHpGui = false;
	}

	public override void deselect()
	{
		_selAngelWeapon = null;
		_selDemonWeapon = null;
		_selMapet = null;
		selFrMapet(null, aFriend: false);
	}

	public override void initialize(DeckItemState aOwner, int aDeckIndex, bool aEquip, bool aDebugZero)
	{
		_owner = aOwner;
		DeckSelector owner = aOwner.owner;
		if (aDebugZero)
		{
			aDeckIndex = 0;
		}
		_deckIndex = aDeckIndex;
		if (aEquip)
		{
			_setEquipFromDeckIndex(aDeckIndex);
		}
	}

	protected override void _setEquipFromDeckIndex(int aDeckIndex)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("null != ud");
		}
		WeaponEquipments weaponEquipments = null;
		PoppetEquipments poppetEquipments = null;
		if (0 <= aDeckIndex && aDeckIndex < UserDeckData2.WepEquips.Length)
		{
			WeaponEquipments[] wepEquips = UserDeckData2.WepEquips;
			weaponEquipments = wepEquips[RuntimeServices.NormalizeArrayIndex(wepEquips, aDeckIndex)];
		}
		if (0 <= aDeckIndex && aDeckIndex < current.userDeckData2.PetEquips.Length)
		{
			PoppetEquipments[] petEquips = current.userDeckData2.PetEquips;
			poppetEquipments = petEquips[RuntimeServices.NormalizeArrayIndex(petEquips, aDeckIndex)];
		}
		_updateEquip(new EquipmentsBase[2] { weaponEquipments, poppetEquipments }, aDirty: false);
		UserConfigData.DeckTypes aType = UserConfigData.DeckTypes.None;
		if (0 <= aDeckIndex && aDeckIndex < current.userDeckData2.DeckTypes.Length)
		{
			UserConfigData.DeckTypes[] deckTypes = current.userDeckData2.DeckTypes;
			aType = deckTypes[RuntimeServices.NormalizeArrayIndex(deckTypes, aDeckIndex)];
		}
		setSupportType(aType, aUpdate: false);
	}

	protected override void _updateEquip(EquipmentsBase[] equps, bool aDirty)
	{
		WeaponEquipments weaponEquipments = null;
		PoppetEquipments poppetEquipments = null;
		if (2 >= equps.Length)
		{
			weaponEquipments = equps[0] as WeaponEquipments;
			poppetEquipments = equps[1] as PoppetEquipments;
		}
		if (weaponEquipments != null && poppetEquipments != null)
		{
			_weaponEquipments = weaponEquipments;
			_poppetEquipments = poppetEquipments;
			RespWeapon selAngelWeapon = _selAngelWeapon;
			RespWeapon selDemonWeapon = _selDemonWeapon;
			RespPoppet respPoppet = _selMapet;
			_selAngelWeapon = weaponEquipments.getMainWeapon(RACE_TYPE.Tensi);
			_selDemonWeapon = weaponEquipments.getMainWeapon(RACE_TYPE.Akuma);
			_selMapet = poppetEquipments.MainPoppet;
			_isDirty = aDirty;
			updateEquip();
		}
	}

	public override void selFrMapet(RespFriendPoppet aFriendPoppet, bool aFriend)
	{
		_lastFrMapet = null;
		_selFrMapet = aFriendPoppet;
		_isFriendMapet = aFriend;
	}

	public override void setSupportType(UserConfigData.DeckTypes aType, bool aUpdate)
	{
		_supportType = aType;
		if (aUpdate)
		{
			WeaponEquipments weaponEquipments = null;
			switch (aType)
			{
			case UserConfigData.DeckTypes.Atk:
				weaponEquipments = WeaponEquipments.GetBestAtkWeapons(_weaponEquipments, _poppetEquipments);
				break;
			case UserConfigData.DeckTypes.Hp:
				weaponEquipments = WeaponEquipments.GetBestHpWeapons(_weaponEquipments, _poppetEquipments);
				break;
			}
			if (weaponEquipments != null)
			{
				_updateEquip(new EquipmentsBase[2] { weaponEquipments, _poppetEquipments }, aDirty: true);
			}
		}
	}
}
