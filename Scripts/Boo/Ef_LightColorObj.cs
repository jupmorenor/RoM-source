using System;
using UnityEngine;

[Serializable]
public class Ef_LightColorObj
{
	public GameObject gameObj;

	public Color mulColor;

	public bool changeShader;

	public Ef_LightColorObj()
	{
		mulColor = Color.gray;
	}
}
