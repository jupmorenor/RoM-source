using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromNameColor
{
	public string name;

	public Color color;

	public Ef_SetColorFromNameColor()
	{
		name = string.Empty;
		color = Color.white;
	}
}
