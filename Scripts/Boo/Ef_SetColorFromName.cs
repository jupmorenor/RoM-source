using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromName : MonoBehaviour
{
	public Ef_SetColorFromNameColor[] nameColors;

	public Ef_SetColorFromNameObj[] setObjs;

	public bool ignoreEP;

	public bool setNoSetPM;

	private bool end;

	public Ef_SetColorFromName()
	{
		nameColors = new Ef_SetColorFromNameColor[1];
		setObjs = new Ef_SetColorFromNameObj[1];
		setNoSetPM = true;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			SetColor(emtr.gameObject.name);
		}
	}

	public void Start()
	{
		if (!end && setNoSetPM)
		{
			SetColor(string.Empty);
		}
	}

	public void SetColor(string pName)
	{
		int length = setObjs.Length;
		int length2 = nameColors.Length;
		if (length == 0 || length2 == 0)
		{
			return;
		}
		Color color = nameColors[0].color;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length2).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetColorFromNameColor[] array = nameColors;
				string text = array[RuntimeServices.NormalizeArrayIndex(array, num)].name;
				int length3 = text.Length;
				if (length3 != 0)
				{
					if (length3 < pName.Length)
					{
						pName = ((!ignoreEP) ? pName.Substring(0, length3) : pName.Substring(1, checked(length3 - 1)));
					}
					if (text == pName || pName == string.Empty)
					{
						Ef_SetColorFromNameColor[] array2 = nameColors;
						color = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].color;
						break;
					}
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
				Ef_SetColorFromNameObj[] array3 = setObjs;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)] == null)
				{
					continue;
				}
				Ef_SetColorFromNameObj[] array4 = setObjs;
				GameObject gameObj = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].gameObj;
				if (gameObj == null)
				{
					continue;
				}
				Color color2 = color;
				Ef_SetColorFromNameObj[] array5 = setObjs;
				Color color3 = color2 * array5[RuntimeServices.NormalizeArrayIndex(array5, num)].mulColor;
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
