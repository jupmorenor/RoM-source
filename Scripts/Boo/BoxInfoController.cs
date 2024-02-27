using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class BoxInfoController : MonoBehaviour
{
	public GameObject[] infoWindows;

	private __PhotonPlayer_SkillEventHandler_0024callable84_002454_34__ actriveFunc;

	public GameObject[] InfoWindows => infoWindows;

	public __PhotonPlayer_SkillEventHandler_0024callable84_002454_34__ ActiveFunc
	{
		get
		{
			return actriveFunc;
		}
		set
		{
			actriveFunc = value;
		}
	}

	public BoxInfoController()
	{
		actriveFunc = DefaultActiveFunc;
	}

	private void DefaultActiveFunc(int index, bool active)
	{
		GameObject[] array = infoWindows;
		array[RuntimeServices.NormalizeArrayIndex(array, index)].SetActive(active);
	}

	public void SwitchInfoWindow(int activeIndex)
	{
		if (null == infoWindows)
		{
			return;
		}
		int num = 0;
		int length = infoWindows.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			GameObject[] array = infoWindows;
			if (!(null == array[RuntimeServices.NormalizeArrayIndex(array, num2)]))
			{
				actriveFunc(num2, num2 == activeIndex);
			}
		}
	}

	public void SetWindowActive(bool on)
	{
		SwitchInfoWindow(-1);
	}
}
