using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class IconCreator : MonoBehaviour
{
	public Transform iconParent;

	public GameObject iconPrefab;

	public GameObject CreateIcon()
	{
		object result;
		if (iconParent != null && iconPrefab != null)
		{
			GameObject gameObject = GameAssetModule.Instantiate(iconPrefab);
			gameObject.transform.parent = iconParent;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			result = gameObject;
		}
		else
		{
			result = null;
		}
		return (GameObject)result;
	}
}
