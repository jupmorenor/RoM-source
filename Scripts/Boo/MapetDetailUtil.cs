using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MapetDetailUtil
{
	[NonSerialized]
	private static GameObject mapetDetailPrefab;

	[NonSerialized]
	private static GameObject mapetDetail;

	public static GameObject Get()
	{
		return mapetDetail;
	}

	public static GameObject PrepareMapetPrefab(bool friend)
	{
		if (mapetDetailPrefab == null)
		{
			if (friend)
			{
				mapetDetailPrefab = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/FriendPetDetail", typeof(GameObject));
			}
			else
			{
				mapetDetailPrefab = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/MuppetDetail", typeof(GameObject));
			}
		}
		return mapetDetailPrefab;
	}

	public static GameObject PrepareMapetDetail(GameObject parent)
	{
		checked
		{
			GameObject result;
			if ((bool)mapetDetail)
			{
				result = mapetDetail;
			}
			else
			{
				if (!(mapetDetailPrefab != null))
				{
					throw new AssertionFailedException("mapetDetailPrefab != null");
				}
				if (mapetDetail == null)
				{
					mapetDetail = (GameObject)UnityEngine.Object.Instantiate(mapetDetailPrefab);
				}
				int i = 0;
				UIAutoTweener[] componentsInChildren = mapetDetail.GetComponentsInChildren<UIAutoTweener>();
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
				UITweener[] componentsInChildren2 = mapetDetail.GetComponentsInChildren<UITweener>();
				for (int length2 = componentsInChildren2.Length; j < length2; j++)
				{
					componentsInChildren2[j].ignoreTimeScale = true;
					componentsInChildren2[j].Reset();
				}
				mapetDetail.SetActive(value: false);
				result = mapetDetail;
			}
			return result;
		}
	}

	public static GameObject Open(RespPoppet mapet, GameObject parent)
	{
		return Open(mapet, parent, null);
	}

	public static GameObject Open(RespPoppet mapet, GameObject parent, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ inHandler)
	{
		GameObject gameObject;
		if (!IsOpened())
		{
			PrepareMapetDetail(parent);
			if (!(mapetDetail != null))
			{
				throw new AssertionFailedException("mapetDetail != null");
			}
			gameObject = mapetDetail;
			gameObject.SetActive(value: true);
			gameObject.transform.parent = parent.gameObject.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = new Vector3(0f, 0f, -200f);
			int i = 0;
			MuppetInfo[] componentsInChildren = gameObject.GetComponentsInChildren<MuppetInfo>(includeInactive: true);
			for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
			{
				componentsInChildren[i].SetMuppet(mapet);
				componentsInChildren[i].DestroyLevel();
			}
			ExtensionsModule.FindChild(gameObject, "Window").GetComponent<UIButtonMessage>().target = parent;
			ExtensionsModule.FindChild(gameObject, "Window").SetActive(value: true);
			ExtensionsModule.FindChild(gameObject, "MapetIcon").SetActive(value: true);
			PrepareMapetDetail(parent).SetActive(value: true);
			UIAutoTweenerStandAloneEx.In(PrepareMapetDetail(parent), inHandler);
		}
		else
		{
			gameObject = mapetDetail;
		}
		return gameObject;
	}

	public static bool IsOpened()
	{
		return (mapetDetail != null && mapetDetail.activeInHierarchy && !mapetDetail.GetComponent<UIAutoTweenerStandAloneEx>().IsOut) ? true : false;
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
			UIAutoTweenerStandAloneEx.Out(mapetDetail, outHandler);
			result = 1;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}
}
