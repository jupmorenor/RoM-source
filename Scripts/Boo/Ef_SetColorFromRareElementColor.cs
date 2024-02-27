using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromRareElementColor
{
	public int rareNo;

	public int elementNo;

	public Color color;

	public Ef_SetColorFromRareElementColor()
	{
		color = Color.white;
	}
}
