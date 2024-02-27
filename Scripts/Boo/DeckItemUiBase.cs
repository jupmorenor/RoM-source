using System;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public abstract class DeckItemUiBase : MonoBehaviour
{
	[Serializable]
	internal class _0024SetIcon_0024locals_002414468
	{
		internal UISprite _0024sprite;

		internal string _0024icon;
	}

	[Serializable]
	internal class _0024SetIcon_0024closure_00243137
	{
		internal _0024SetIcon_0024locals_002414468 _0024_0024locals_002415032;

		public _0024SetIcon_0024closure_00243137(_0024SetIcon_0024locals_002414468 _0024_0024locals_002415032)
		{
			this._0024_0024locals_002415032 = _0024_0024locals_002415032;
		}

		public void Invoke(object atlas)
		{
			GameObject gameObject = _0024_0024locals_002415032._0024sprite.gameObject;
			bool num = _0024_0024locals_002415032._0024sprite.spriteName == _0024_0024locals_002415032._0024icon;
			if (num)
			{
				num = !string.IsNullOrEmpty(_0024_0024locals_002415032._0024icon);
			}
			gameObject.SetActive(num);
		}
	}

	protected DeckItemState _owner;

	protected DeckSelector _ownerDeckSelector;

	protected int _deckIndex;

	protected UserConfigData.DeckTypes _supportType;

	protected bool _updateAtkHpGui;

	public string levelFormat;

	public UILabelBase playerAttackPointLabel;

	public UILabelBase playerHitPointLabel;

	protected bool _isDirty;

	public GameObject weaponIconPrefab;

	public GameObject poppetIconPrefab;

	public string initSkillString;

	public int deckIndex => _deckIndex;

	public UserConfigData.DeckTypes supportType => _supportType;

	public bool isDirty => _isDirty;

	protected DeckItemUiBase()
	{
		_supportType = UserConfigData.DeckTypes.None;
		levelFormat = "lv{0}";
		initSkillString = "無し";
	}

	public void Awake()
	{
		InitWapon();
		InitPoppet();
		setLabel(playerAttackPointLabel, " ");
		setLabel(playerHitPointLabel, string.Empty);
	}

	protected void setSprite(UISprite sp, string name)
	{
		if (!(sp == null) && !(name == null) && sp.spriteName != name)
		{
			IconAtlasPoolModule.SetGearIcon(sp, name);
			sp.gameObject.SetActive(!string.IsNullOrEmpty(name));
		}
	}

	protected void setGearSprite(UISprite sp, string name)
	{
		if (!(sp == null) && !(name == null) && sp.spriteName != name)
		{
			IconAtlasPoolModule.SetGearIcon(sp, name);
			sp.gameObject.SetActive(!string.IsNullOrEmpty(name));
		}
	}

	protected void setLabel(UILabelBase label, string text)
	{
		if (!(text == null) && !(label == null) && label.text != text)
		{
			label.text = text;
			label.gameObject.SetActive(!string.IsNullOrEmpty(name));
		}
	}

	public static WeaponInfo setWeaponIcon(ref GameObject icon, GameObject iconPrefab, GameObject iconPrarnet, RespWeapon weapon)
	{
		WeaponInfo weaponInfo = null;
		if (null == icon)
		{
			icon = (GameObject)UnityEngine.Object.Instantiate(iconPrefab);
		}
		if (null != icon)
		{
			icon.transform.parent = iconPrarnet.transform;
			icon.transform.localPosition = Vector3.zero;
			icon.transform.localScale = Vector3.one;
			weaponInfo = ExtensionsModule.SetComponent<WeaponInfo>(icon);
			if ((bool)weaponInfo)
			{
				weaponInfo.SetWeapon(weapon);
			}
			icon.SetActive(value: true);
		}
		return weaponInfo;
	}

	public static MuppetInfo setPoppetIcon(ref GameObject icon, GameObject iconPrefab, GameObject iconPrarnet, RespPoppet poppet)
	{
		MuppetInfo muppetInfo = null;
		if (null == icon)
		{
			icon = (GameObject)UnityEngine.Object.Instantiate(iconPrefab);
		}
		if (null != icon)
		{
			icon.transform.parent = iconPrarnet.transform;
			icon.transform.localPosition = Vector3.zero;
			icon.transform.localScale = Vector3.one;
			muppetInfo = ExtensionsModule.SetComponent<MuppetInfo>(icon);
			muppetInfo.IgnoreUnknown = true;
			if ((bool)muppetInfo)
			{
				muppetInfo.SetMuppet(poppet);
			}
			icon.SetActive(value: true);
		}
		return muppetInfo;
	}

	protected void SetIcon(UISprite sprite, string icon)
	{
		_0024SetIcon_0024locals_002414468 _0024SetIcon_0024locals_0024 = new _0024SetIcon_0024locals_002414468();
		_0024SetIcon_0024locals_0024._0024sprite = sprite;
		_0024SetIcon_0024locals_0024._0024icon = icon;
		IconAtlasPool.SetSprite(_0024SetIcon_0024locals_0024._0024sprite, _0024SetIcon_0024locals_0024._0024icon, _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__IconAtlasPool_SetSprite_0024callable96_0024190_88___0024173.Adapt(new _0024SetIcon_0024closure_00243137(_0024SetIcon_0024locals_0024).Invoke));
	}

	protected virtual void InitWapon()
	{
	}

	protected virtual void InitPoppet()
	{
	}

	public void Update()
	{
		if (_updateAtkHpGui)
		{
			_updateAtkHp();
		}
	}

	public virtual void _updateAtkHp()
	{
		_updateAtkHpGui = false;
	}

	public virtual void deselect()
	{
	}

	public virtual void initialize(DeckItemState aOwner, int aDeckIndex, bool aEquip, bool aDebugZero)
	{
		_owner = aOwner;
		_ownerDeckSelector = aOwner.owner;
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

	protected virtual void _setEquipFromDeckIndex(int aDeckIndex)
	{
		EquipmentsBase equipmentsBase = null;
		EquipmentsBase equipmentsBase2 = null;
		_updateEquip(new EquipmentsBase[2] { equipmentsBase, equipmentsBase2 }, aDirty: false);
	}

	protected virtual void _updateEquip(EquipmentsBase[] equps, bool aDirty)
	{
		_isDirty = aDirty;
		updateEquip();
	}

	public virtual void selFrMapet(RespFriendPoppet aFriendPoppet, bool aFriend)
	{
	}

	public virtual void setSupportType(UserConfigData.DeckTypes aType, bool aUpdate)
	{
	}

	public void setCurEquip()
	{
		_setEquipFromDeckIndex(_deckIndex);
	}

	public void updateEquip()
	{
		_updateAtkHpGui = true;
	}

	public void onSent()
	{
		_isDirty = false;
	}
}
