using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class WeaponDetailUtil
{
	[NonSerialized]
	private static GameObject weaponDetailPrefab;

	[NonSerialized]
	private static GameObject weaponDetail;

	public static GameObject PrepareWeaponPrefab()
	{
		if (weaponDetailPrefab == null)
		{
			weaponDetailPrefab = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/WeaponDetail", typeof(GameObject));
		}
		return weaponDetailPrefab;
	}

	public static GameObject PrepareWeaponDetail(GameObject parent)
	{
		PrepareWeaponPrefab();
		if (weaponDetail == null)
		{
			weaponDetail = (GameObject)UnityEngine.Object.Instantiate(weaponDetailPrefab);
		}
		weaponDetail.transform.parent = parent.gameObject.transform;
		weaponDetail.transform.localScale = Vector3.one;
		weaponDetail.transform.localPosition = new Vector3(0f, 0f, -300f);
		int i = 0;
		UIAutoTweener[] componentsInChildren = weaponDetail.GetComponentsInChildren<UIAutoTweener>();
		checked
		{
			for (int length = componentsInChildren.Length; i < length; i++)
			{
				componentsInChildren[i].ignoreTimeScale = true;
				if (componentsInChildren[i].GetType().ToString() == "UIAutoTweenerStandAloneEx")
				{
					UIAutoTweenerStandAloneEx uIAutoTweenerStandAloneEx = (UIAutoTweenerStandAloneEx)componentsInChildren[i];
					if ((bool)uIAutoTweenerStandAloneEx)
					{
						uIAutoTweenerStandAloneEx.standAloneHideStart = false;
					}
				}
			}
			int j = 0;
			UITweener[] componentsInChildren2 = weaponDetail.GetComponentsInChildren<UITweener>();
			for (int length2 = componentsInChildren2.Length; j < length2; j++)
			{
				componentsInChildren2[j].ignoreTimeScale = true;
				componentsInChildren2[j].Reset();
			}
			weaponDetail.SetActive(value: false);
			return weaponDetail;
		}
	}

	public static GameObject Open(RespWeapon weapon, GameObject parent)
	{
		return Open(weapon, parent, null);
	}

	public static GameObject Open(RespWeapon weapon, GameObject parent, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler)
	{
		GameObject gameObject;
		if (!IsOpened())
		{
			PrepareWeaponDetail(parent);
			if (!(weaponDetail != null))
			{
				throw new AssertionFailedException("weaponDetail != null");
			}
			gameObject = weaponDetail;
			gameObject.SetActive(value: true);
			int i = 0;
			WeaponInfo[] componentsInChildren = gameObject.GetComponentsInChildren<WeaponInfo>(includeInactive: true);
			for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
			{
				componentsInChildren[i].SetWeapon(weapon);
				componentsInChildren[i].DestroyLevel();
			}
			ExtensionsModule.FindChild(gameObject, "Window").SetActive(value: true);
			ExtensionsModule.FindChild(gameObject, "WeaponIcon").SetActive(value: true);
			PrepareWeaponDetail(parent).SetActive(value: true);
			UIAutoTweenerStandAloneEx.In(PrepareWeaponDetail(parent), inHandler);
		}
		else
		{
			gameObject = weaponDetail;
		}
		return gameObject;
	}

	public static bool IsOpened()
	{
		return (weaponDetail != null && weaponDetail.activeInHierarchy && !weaponDetail.GetComponent<UIAutoTweenerStandAloneEx>().IsOut) ? true : false;
	}

	public static bool Close()
	{
		return Close(null);
	}

	public static bool Close(__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ outHandler)
	{
		int result;
		if (IsOpened())
		{
			UIAutoTweenerStandAloneEx.Out(weaponDetail, outHandler);
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
