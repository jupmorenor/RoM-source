using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetActiveFromRareElement : MonoBehaviour
{
	[Serializable]
	public class Ef_SetActiveFromRareElementObjs
	{
		public GameObject gameObj;

		public int rareNo;

		public bool elemFire;

		public bool elemWater;

		public bool elemWind;

		public bool elemEarth;

		public bool elemMoon;

		public Ef_SetActiveFromRareElementObjs()
		{
			elemFire = true;
			elemWater = true;
			elemWind = true;
			elemEarth = true;
			elemMoon = true;
		}
	}

	public Ef_SetActiveFromRareElementObjs[] setObjs;

	public bool setNoSetPM;

	public int testRare;

	public int testElem;

	private bool end;

	public Ef_SetActiveFromRareElement()
	{
		setObjs = new Ef_SetActiveFromRareElementObjs[1];
		setNoSetPM = true;
	}

	public void Start()
	{
		if (testRare > 0 && testElem > 0)
		{
			SetObjActive(testRare, testElem);
			setNoSetPM = false;
		}
		if (!end)
		{
			if (setNoSetPM)
			{
				SetObjActive(0, 0);
				setNoSetPM = false;
			}
			end = true;
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (mpets != null)
		{
			SetObjActive(mpets.Rare, mpets.MElementId);
		}
	}

	public void SetObjActive(int rare, int elem)
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(setObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetActiveFromRareElementObjs[] array = setObjs;
				Ef_SetActiveFromRareElementObjs ef_SetActiveFromRareElementObjs = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				bool flag = false;
				if (rare >= ef_SetActiveFromRareElementObjs.rareNo || rare == 0)
				{
					flag = true;
				}
				bool flag2 = false;
				switch (elem)
				{
				case 0:
					flag2 = true;
					break;
				case 1:
					if (ef_SetActiveFromRareElementObjs.elemFire)
					{
						flag2 = true;
					}
					break;
				case 2:
					if (ef_SetActiveFromRareElementObjs.elemWater)
					{
						flag2 = true;
					}
					break;
				case 3:
					if (ef_SetActiveFromRareElementObjs.elemWind)
					{
						flag2 = true;
					}
					break;
				case 4:
					if (ef_SetActiveFromRareElementObjs.elemEarth)
					{
						flag2 = true;
					}
					break;
				case 5:
					if (ef_SetActiveFromRareElementObjs.elemMoon)
					{
						flag2 = true;
					}
					break;
				}
				if (ef_SetActiveFromRareElementObjs.gameObj != null)
				{
					GameObject gameObj = ef_SetActiveFromRareElementObjs.gameObj;
					bool num2 = flag;
					if (num2)
					{
						num2 = flag2;
					}
					gameObj.SetActive(num2);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		end = true;
	}
}
