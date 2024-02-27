using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromRareElement : MonoBehaviour
{
	public Ef_SetColorFromRareElementColor[] rareElemColors;

	public Ef_SetColorFromRareElementObj[] setObjs;

	public bool setNoSetPM;

	public int testRare;

	public int testElem;

	private bool end;

	public Ef_SetColorFromRareElement()
	{
		rareElemColors = new Ef_SetColorFromRareElementColor[1];
		setObjs = new Ef_SetColorFromRareElementObj[1];
		setNoSetPM = true;
	}

	public void Start()
	{
		if (testRare > 0 && testElem > 0)
		{
			SetColor(testRare, testElem);
			setNoSetPM = false;
		}
		if (!end)
		{
			if (setNoSetPM)
			{
				SetColor(0, 0);
				setNoSetPM = false;
			}
			end = true;
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (mpets != null)
		{
			SetColor(mpets.Rare, mpets.MElementId);
		}
	}

	public void SetColor(int rare, int elem)
	{
		int length = setObjs.Length;
		int length2 = rareElemColors.Length;
		if (length == 0 || length2 == 0)
		{
			return;
		}
		Color color = rareElemColors[0].color;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length2).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetColorFromRareElementColor[] array = rareElemColors;
				int rareNo = array[RuntimeServices.NormalizeArrayIndex(array, num)].rareNo;
				Ef_SetColorFromRareElementColor[] array2 = rareElemColors;
				int elementNo = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].elementNo;
				if ((rareNo == rare && elementNo == elem) || (rareNo == 0 && elementNo == elem) || (rareNo == rare && elementNo == 0))
				{
					Ef_SetColorFromRareElementColor[] array3 = rareElemColors;
					color = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].color;
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				Ef_SetColorFromRareElementObj[] array4 = setObjs;
				if (array4[RuntimeServices.NormalizeArrayIndex(array4, num)] == null)
				{
					continue;
				}
				Ef_SetColorFromRareElementObj[] array5 = setObjs;
				GameObject gameObj = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].gameObj;
				if (gameObj == null)
				{
					continue;
				}
				Color color2 = color;
				Ef_SetColorFromRareElementObj[] array6 = setObjs;
				Color color3 = color2 * array6[RuntimeServices.NormalizeArrayIndex(array6, num)].mulColor;
				if ((bool)gameObj.particleSystem)
				{
					gameObj.particleSystem.startColor = color3;
				}
				else if ((bool)gameObj.GetComponent<TrailRenderer>())
				{
					if ((bool)gameObj.GetComponent<TrailRenderer>().material && gameObj.GetComponent<TrailRenderer>().material.HasProperty("_Color"))
					{
						gameObj.GetComponent<TrailRenderer>().material.SetColor("_Color", color3);
						gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
					}
				}
				else if ((bool)gameObj.GetComponent<Ef_SwordTrail>())
				{
					gameObj.GetComponent<Ef_SwordTrail>().color = color3;
				}
				else if ((bool)gameObj.GetComponent<Ef_RingMesh>())
				{
					gameObj.GetComponent<Ef_RingMesh>().color = color3;
				}
				else if ((bool)gameObj.renderer)
				{
					if ((bool)gameObj.renderer.material && gameObj.renderer.material.HasProperty("_Color"))
					{
						gameObj.renderer.material.SetColor("_Color", color3);
						gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
					}
				}
				else
				{
					gameObj.SendMessage("setColor", color);
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		end = true;
	}
}
