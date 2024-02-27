using System;
using UnityEngine;

[Serializable]
public class Ef_SetActiveFromRankObjs
{
	public GameObject gameObj;

	public int minRank;

	public int maxRank;

	public Ef_SetActiveFromRankObjs()
	{
		minRank = 2;
		maxRank = 99;
	}
}
