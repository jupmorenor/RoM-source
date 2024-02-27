using System;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class TreasureBoxIcon : MonoBehaviour
{
	[Serializable]
	public enum BOX_ICON_TYPE
	{
		None,
		SuperRarePlus,
		SuperRare,
		RarePlus,
		Rare,
		NormalPlus,
		Normal,
		Weapon,
		Poppet
	}

	protected bool ignoreUnknown;

	public UISprite noneIcon;

	public TreasureInfo treasureInfo;

	public UISprite weaponBase;

	public UISprite poppetBase;

	public string treasurePrefabPath;

	public string weaponIconPrefabPath;

	public string poppetIconPrefabPath;

	protected WeaponInfo weaponIcon;

	protected MuppetInfo poppetIcon;

	protected bool init;

	public bool IgnoreUnknown
	{
		get
		{
			return ignoreUnknown;
		}
		set
		{
			ignoreUnknown = value;
		}
	}

	public TreasureBoxIcon()
	{
		treasurePrefabPath = "Prefab/GUI/TreasureIcon";
		weaponIconPrefabPath = "Prefab/GUI/WeaponIcon";
		poppetIconPrefabPath = "Prefab/GUI/MapetIcon";
	}

	public void Aake()
	{
		if (!init)
		{
			Init();
		}
	}

	public void Init()
	{
		init = true;
		if ((bool)noneIcon)
		{
			noneIcon.gameObject.SetActive(value: true);
		}
		UnityEngine.Object @object = GameAssetModule.LoadPrefab(treasurePrefabPath);
		if ((bool)@object)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
			if ((bool)gameObject)
			{
				treasureInfo = gameObject.GetComponent<TreasureInfo>();
			}
		}
		if ((bool)treasureInfo)
		{
			treasureInfo.gameObject.SetActive(value: false);
			treasureInfo.transform.parent = transform;
			treasureInfo.transform.localScale = Vector3.one;
			treasureInfo.transform.localPosition = new Vector3(50f, -50f, 0f);
		}
		if ((bool)weaponBase)
		{
			weaponBase.gameObject.SetActive(value: false);
		}
		if ((bool)poppetBase)
		{
			poppetBase.gameObject.SetActive(value: false);
		}
		UnityEngine.Object object2 = GameAssetModule.LoadPrefab(weaponIconPrefabPath);
		if ((bool)object2)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(object2) as GameObject;
			if ((bool)gameObject)
			{
				weaponIcon = gameObject.GetComponent<WeaponInfo>();
			}
			weaponIcon.ResetWeapon();
			weaponIcon.Start();
		}
		UnityEngine.Object object3 = GameAssetModule.LoadPrefab(poppetIconPrefabPath);
		if ((bool)object3)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(object3) as GameObject;
			if ((bool)gameObject)
			{
				poppetIcon = gameObject.GetComponent<MuppetInfo>();
			}
			poppetIcon.ResetMuppet();
			poppetIcon.Start();
		}
		if ((bool)weaponIcon)
		{
			weaponIcon.gameObject.SetActive(value: false);
			if ((bool)weaponBase)
			{
				weaponIcon.transform.parent = weaponBase.transform.parent;
				float x = weaponBase.transform.localScale.x / 128f;
				Vector3 localScale = weaponIcon.transform.localScale;
				float num = (localScale.x = x);
				Vector3 vector2 = (weaponIcon.transform.localScale = localScale);
				float y = weaponBase.transform.localScale.y / 128f;
				Vector3 localScale2 = weaponIcon.transform.localScale;
				float num2 = (localScale2.y = y);
				Vector3 vector4 = (weaponIcon.transform.localScale = localScale2);
				int num3 = 1;
				Vector3 localScale3 = weaponIcon.transform.localScale;
				float num4 = (localScale3.z = num3);
				Vector3 vector6 = (weaponIcon.transform.localScale = localScale3);
				weaponIcon.transform.localPosition = weaponBase.transform.localPosition;
				weaponIcon.DestroyLevel();
			}
		}
		if ((bool)poppetIcon)
		{
			poppetIcon.gameObject.SetActive(value: false);
			if ((bool)poppetBase)
			{
				poppetIcon.transform.parent = poppetBase.transform.parent;
				float x2 = poppetBase.transform.localScale.x / 128f;
				Vector3 localScale4 = poppetIcon.transform.localScale;
				float num5 = (localScale4.x = x2);
				Vector3 vector8 = (poppetIcon.transform.localScale = localScale4);
				float y2 = poppetBase.transform.localScale.y / 128f;
				Vector3 localScale5 = poppetIcon.transform.localScale;
				float num6 = (localScale5.y = y2);
				Vector3 vector10 = (poppetIcon.transform.localScale = localScale5);
				int num7 = 1;
				Vector3 localScale6 = poppetIcon.transform.localScale;
				float num8 = (localScale6.z = num7);
				Vector3 vector12 = (poppetIcon.transform.localScale = localScale6);
				poppetIcon.transform.localPosition = poppetBase.transform.localPosition;
				poppetIcon.DestroyLevel();
			}
		}
	}

	public void Update()
	{
	}

	public void SetIcon(BOX_ICON_TYPE iconType, int param)
	{
		if (!init)
		{
			Init();
		}
		SetIconCore(iconType, param);
	}

	public void SetIconCore(BOX_ICON_TYPE iconType, int param)
	{
		if ((bool)noneIcon)
		{
			noneIcon.gameObject.SetActive(value: true);
		}
		if ((bool)treasureInfo)
		{
			treasureInfo.gameObject.SetActive(value: false);
		}
		if ((bool)weaponIcon)
		{
			weaponIcon.gameObject.SetActive(value: false);
		}
		if ((bool)poppetIcon)
		{
			poppetIcon.gameObject.SetActive(value: false);
		}
		if ((bool)weaponBase)
		{
			weaponBase.gameObject.SetActive(value: false);
		}
		if ((bool)poppetBase)
		{
			poppetBase.gameObject.SetActive(value: false);
		}
		if ((bool)weaponIcon)
		{
			weaponIcon.gameObject.SetActive(value: false);
		}
		if ((bool)poppetIcon)
		{
			poppetIcon.gameObject.SetActive(value: false);
		}
		switch (iconType)
		{
		case BOX_ICON_TYPE.None:
			if ((bool)noneIcon)
			{
				noneIcon.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.SuperRarePlus:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(6);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.SuperRare:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(5);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.RarePlus:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(4);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.Rare:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(3);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.NormalPlus:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(2);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.Normal:
			if ((bool)treasureInfo)
			{
				treasureInfo.SetState(1);
			}
			if ((bool)treasureInfo)
			{
				treasureInfo.gameObject.SetActive(value: true);
			}
			break;
		case BOX_ICON_TYPE.Weapon:
			if ((bool)weaponIcon)
			{
				RespWeapon respWeapon = new RespWeapon(param);
				if (respWeapon != null)
				{
					weaponIcon.SetWeapon(respWeapon, ignoreUnknown);
					weaponIcon.Update();
					weaponIcon.gameObject.SetActive(value: true);
				}
			}
			break;
		case BOX_ICON_TYPE.Poppet:
			if ((bool)poppetIcon)
			{
				RespPoppet respPoppet = new RespPoppet(param);
				if (respPoppet != null)
				{
					poppetIcon.SetMuppet(respPoppet, ignoreUnknown);
					poppetIcon.Update();
					poppetIcon.gameObject.SetActive(value: true);
				}
			}
			break;
		}
	}
}
