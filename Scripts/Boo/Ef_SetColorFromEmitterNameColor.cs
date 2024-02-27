using System;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromEmitterNameColor
{
	public string name;

	public Color color;

	public Ef_SetColorFromEmitterNameColor()
	{
		name = string.Empty;
		color = Color.white;
	}
}
