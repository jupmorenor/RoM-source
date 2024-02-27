using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromEmitterNameObj
{
	public GameObject gameObj;

	public Color mulColor;

	public Ef_SetColorFromEmitterNameObj()
	{
		mulColor = new Color(1f, 1f, 1f, 0.5f);
	}
}
