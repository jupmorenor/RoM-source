using System;
using UnityEngine;

[Serializable]
public class ItemIconsOption : UIIconsOptionBase
{
	[Serializable]
	public enum LayerObject
	{
		Frame,
		Focus,
		Favorite,
		Use,
		New
	}

	public GameObject framePrefab;

	public GameObject focusPrefab;

	public GameObject favoritePrefab;

	public GameObject usePrefab;

	public GameObject newPrefab;

	public override GameObject GetObject(int layout)
	{
		GameObject gameObject = null;
		switch (layout)
		{
		case 0:
			gameObject = framePrefab;
			break;
		case 1:
			gameObject = focusPrefab;
			break;
		case 2:
			gameObject = favoritePrefab;
			break;
		case 3:
			gameObject = usePrefab;
			break;
		case 4:
			gameObject = newPrefab;
			break;
		}
		GameObject gameObject2 = NGUITools.InstantiateWithoutUIPanel(gameObject);
		gameObject2.transform.parent = transform;
		gameObject2.transform.localPosition = gameObject.transform.localPosition;
		gameObject2.transform.localRotation = Quaternion.identity;
		gameObject2.transform.localScale = Vector3.one;
		return gameObject2;
	}
}
