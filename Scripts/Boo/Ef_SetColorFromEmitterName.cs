using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColorFromEmitterName : MonoBehaviour
{
	public Ef_SetColorFromEmitterNameColor[] nameColors;

	public Ef_SetColorFromEmitterNameObj[] setObjs;

	public bool ignoreEP;

	public bool setNoSetPM;

	private bool end;

	public Ef_SetColorFromEmitterName()
	{
		nameColors = new Ef_SetColorFromEmitterNameColor[1];
		setObjs = new Ef_SetColorFromEmitterNameObj[1];
		ignoreEP = true;
		setNoSetPM = true;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (emtr == null)
		{
			return;
		}
		MerlinMotionPackControl component = emtr.GetComponent<MerlinMotionPackControl>();
		if (component == null)
		{
			return;
		}
		GameObject gameObject = component.motionTarget.gameObject;
		if (!(gameObject == null))
		{
			if ((bool)gameObject.transform.parent)
			{
				SetColor(gameObject.transform.parent.name);
			}
			else
			{
				SetColor(gameObject.name);
			}
			end = true;
		}
	}

	public void Start()
	{
		if (!end && setNoSetPM)
		{
			SetColor(string.Empty);
		}
	}

	public void SetColor(string name)
	{
		int length = name.Length;
		int length2 = setObjs.Length;
		int length3 = nameColors.Length;
		if (length2 == 0 || length3 == 0)
		{
			return;
		}
		Color color = nameColors[0].color;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length3).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetColorFromEmitterNameColor[] array = nameColors;
				string text = array[RuntimeServices.NormalizeArrayIndex(array, num)].name;
				string text2 = string.Empty;
				int length4 = text.Length;
				if (length4 < length)
				{
					text2 = ((!ignoreEP) ? name.Substring(0, length4) : name.Substring(1, length4));
				}
				if (text == text2 || length == 0)
				{
					Ef_SetColorFromEmitterNameColor[] array2 = nameColors;
					color = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].color;
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<int> enumerator2 = Builtins.range(length2).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				Ef_SetColorFromEmitterNameObj[] array3 = setObjs;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)] == null)
				{
					continue;
				}
				Ef_SetColorFromEmitterNameObj[] array4 = setObjs;
				GameObject gameObj = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].gameObj;
				if (gameObj == null)
				{
					continue;
				}
				Color color2 = color;
				Ef_SetColorFromEmitterNameObj[] array5 = setObjs;
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
	}
}
