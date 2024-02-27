using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromNameObj
{
	public GameObject gameObj;

	public Color mulColor;

	public Ef_SetColorFromNameObj()
	{
		mulColor = new Color(1f, 1f, 1f, 0.5f);
	}
}
