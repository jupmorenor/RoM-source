using System;
using UnityEngine;

[Serializable]
public class Ef_NotifyHitCancelObj
{
	public GameObject gameObj;

	public bool destroy;

	public bool setColor;

	public Color color;

	public bool setScale;

	public float scale;

	public bool particle;

	public bool quickAnim;

	public Ef_NotifyHitCancelObj()
	{
		color = Color.white;
		scale = 1f;
	}
}
