using System;
using Boo.Lang.Runtime;
using GameAsset;
using UnityEngine;

[Serializable]
public class PlayerAssets : MonoBehaviour
{
	[NonSerialized]
	private static PlayerAssets _Instance;

	public GameObject タップエフェクト;

	public GameObject ターゲットリング;

	public static PlayerAssets Instance
	{
		get
		{
			if (_Instance == null)
			{
				GameObject gameObject = GameAssetModule.LoadPrefab("Prefab/PlayerAssets") as GameObject;
				if (!(gameObject != null))
				{
					throw new AssertionFailedException("obj != null");
				}
				_Instance = gameObject.GetComponent<PlayerAssets>();
				if (!(_Instance != null))
				{
					throw new AssertionFailedException("_Instance != null");
				}
			}
			return _Instance;
		}
	}

	public static bool Exists => _Instance != null;

	public GameObject instantiateTapEffect()
	{
		if (タップエフェクト != null && string.IsNullOrEmpty("QuestAsset: " + "タップエフェクト" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'タップエフェクト') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(タップエフェクト.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "タップエフェクト" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'タップエフェクト') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateTapEffect(Vector3 position, Quaternion rotation)
	{
		if (タップエフェクト != null && string.IsNullOrEmpty("QuestAsset: " + "タップエフェクト" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'タップエフェクト') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(タップエフェクト.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "タップエフェクト" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'タップエフェクト') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateTargetRing()
	{
		if (ターゲットリング != null && string.IsNullOrEmpty("QuestAsset: " + "ターゲットリング" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ターゲットリング') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ターゲットリング.gameObject);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ターゲットリング" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ターゲットリング') + ' をinstantiateできません'");
		}
		return gameObject;
	}

	public GameObject instantiateTargetRing(Vector3 position, Quaternion rotation)
	{
		if (ターゲットリング != null && string.IsNullOrEmpty("QuestAsset: " + "ターゲットリング" + " がnoneです。"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ターゲットリング') + ' がnoneです。'");
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ターゲットリング.gameObject, position, rotation);
		if (gameObject == null && string.IsNullOrEmpty("QuestAsset: " + "ターゲットリング" + " をinstantiateできません"))
		{
			throw new AssertionFailedException("('QuestAsset: ' + 'ターゲットリング') + ' をinstantiateできません'");
		}
		return gameObject;
	}
}
