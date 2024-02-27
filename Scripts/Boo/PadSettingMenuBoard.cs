using System;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class PadSettingMenuBoard : MonoBehaviour
{
	private bool isTap;

	[NonSerialized]
	private const string BOARD_SPRITE_PATH = "Prefab/GUI/PadSettingMenuBoardSprite";

	[NonSerialized]
	private const string BOARD_TAP_SPRITE_PATH = "Prefab/GUI/PadSettingMenuBoardSpriteTap";

	private GameObject obj;

	public bool IsTap
	{
		get
		{
			return isTap;
		}
		set
		{
			isTap = value;
		}
	}

	private GameObject Load()
	{
		string path = "Prefab/GUI/PadSettingMenuBoardSprite";
		if (isTap)
		{
			path = "Prefab/GUI/PadSettingMenuBoardSpriteTap";
		}
		return (GameObject)GameAssetModule.LoadPrefab(path);
	}

	public void OnEnable()
	{
		GameObject gameObject = Load() as GameObject;
		if (gameObject != null)
		{
			obj = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (!(obj != null))
			{
				throw new AssertionFailedException("obj != null");
			}
			Vector3 localScale = obj.transform.localScale;
			obj.transform.parent = transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = localScale;
		}
	}

	public void OnDisable()
	{
		UnityEngine.Object.Destroy(obj);
		UnloadResource.UnloadUnusedAssets();
	}
}
