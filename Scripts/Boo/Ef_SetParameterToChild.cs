using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetParameterToChild : MonoBehaviour
{
	public GameObject[] gameObjs;

	public void setColor(Color color)
	{
		int num = 0;
		int length = gameObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SendMessage("setColor", color, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void setTime(float time)
	{
		int num = 0;
		int length = gameObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SendMessage("setTime", time, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void setRank(int rank)
	{
		int num = 0;
		int length = gameObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SendMessage("setRank", rank, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		int num = 0;
		int length = gameObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SendMessage("emitEffectMessage", emtr, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		int num = 0;
		int length = gameObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, index)].SendMessage("setPoppetMaster", mpets, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
