using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromRareElementObj
{
	public GameObject gameObj;

	public Color mulColor;

	public Ef_SetColorFromRareElementObj()
	{
		mulColor = new Color(1f, 1f, 1f, 0.5f);
	}
}
