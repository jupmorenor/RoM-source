using System;
using UnityEngine;

[Serializable]
public class ShigetaListMain : UIMain
{
	public int num;

	public GameObject target;

	public ShigetaList list;

	public ShigetaListMain()
	{
		num = 10;
	}

	public override void SceneStart()
	{
		list.Initialize(new object[num], target, list);
	}
}
