using System;
using UnityEngine;

[Serializable]
public class Ef_QuickAnimMatFloatObj
{
	public GameObject materialObj;

	public Ef_QuickAnimMatFloatElem[] parameters;

	private Material privMat;

	private int privNum;

	public Material material
	{
		get
		{
			return privMat;
		}
		set
		{
			privMat = value;
		}
	}

	public int number
	{
		get
		{
			return privNum;
		}
		set
		{
			privNum = value;
		}
	}
}
