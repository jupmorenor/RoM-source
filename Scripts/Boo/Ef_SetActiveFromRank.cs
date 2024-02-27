using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetActiveFromRank : MonoBehaviour
{
	public Ef_SetActiveFromRankObjs[] rankObjs;

	private int rank;

	[NonSerialized]
	public static bool rank2test;

	public Ef_SetActiveFromRank()
	{
		rankObjs = new Ef_SetActiveFromRankObjs[1];
		rank = 1;
	}

	public void setRank(int inRank)
	{
		rank = inRank;
		if (rank2test)
		{
			rank = 2;
		}
	}

	public void Start()
	{
		int length = rankObjs.Length;
		if (length == 0)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetActiveFromRankObjs[] array = rankObjs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == null)
				{
					continue;
				}
				Ef_SetActiveFromRankObjs[] array2 = rankObjs;
				if (!(array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObj == null))
				{
					Ef_SetActiveFromRankObjs[] array3 = rankObjs;
					GameObject gameObj = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].gameObj;
					int num2 = rank;
					Ef_SetActiveFromRankObjs[] array4 = rankObjs;
					bool num3 = num2 >= array4[RuntimeServices.NormalizeArrayIndex(array4, num)].minRank;
					if (num3)
					{
						int num4 = rank;
						Ef_SetActiveFromRankObjs[] array5 = rankObjs;
						num3 = num4 <= array5[RuntimeServices.NormalizeArrayIndex(array5, num)].maxRank;
					}
					gameObj.SetActive(num3);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
