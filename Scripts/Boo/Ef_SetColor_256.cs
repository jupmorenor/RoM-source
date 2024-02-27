using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColor_256 : MonoBehaviour
{
	public Ef_SetColor256Obj[] setObjs;

	public void setColor(Color inColor)
	{
		inColor /= 255f;
		int length = setObjs.Length;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetColor256Obj[] array = setObjs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)].gameObj == null)
				{
					continue;
				}
				Ef_SetColor256Obj[] array2 = setObjs;
				GameObject gameObj = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObj;
				Color color = inColor;
				Ef_SetColor256Obj[] array3 = setObjs;
				Color color2 = color * array3[RuntimeServices.NormalizeArrayIndex(array3, num)].mulColor;
				if ((bool)gameObj.particleSystem)
				{
					gameObj.particleSystem.startColor = color2;
				}
				else if ((bool)gameObj.GetComponent<TrailRenderer>())
				{
					if ((bool)gameObj.GetComponent<TrailRenderer>().material && gameObj.GetComponent<TrailRenderer>().material.HasProperty("_Color"))
					{
						gameObj.GetComponent<TrailRenderer>().material.SetColor("_Color", color2);
						gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
					}
				}
				else if ((bool)gameObj.GetComponent<Ef_SwordTrail>())
				{
					gameObj.GetComponent<Ef_SwordTrail>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_RingMesh>())
				{
					gameObj.GetComponent<Ef_RingMesh>().color = color2;
				}
				else if ((bool)gameObj.renderer)
				{
					if ((bool)gameObj.renderer.material && gameObj.renderer.material.HasProperty("_Color"))
					{
						gameObj.renderer.material.SetColor("_Color", color2);
						gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
					}
				}
				else if (gameObj != gameObject)
				{
					gameObj.SendMessage("setColor", inColor);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
