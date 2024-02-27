using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetColor : MonoBehaviour
{
	public Ef_SetColorObj[] setObjs;

	public void setColor(Color inColor)
	{
		if (inColor[0] > 1f || inColor[1] > 1f || inColor[2] > 1f || !(inColor[3] <= 1f))
		{
			inColor /= 255f;
		}
		int length = setObjs.Length;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_SetColorObj[] array = setObjs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)].gameObj == null)
				{
					continue;
				}
				Ef_SetColorObj[] array2 = setObjs;
				GameObject gameObj = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObj;
				Color color = inColor;
				Ef_SetColorObj[] array3 = setObjs;
				Color color2 = color * array3[RuntimeServices.NormalizeArrayIndex(array3, num)].mulColor;
				if ((bool)gameObj.particleSystem)
				{
					gameObj.particleSystem.startColor = color2;
				}
				else if ((bool)gameObj.GetComponent<TrailRenderer>())
				{
					TrailRenderer component = gameObj.GetComponent<TrailRenderer>();
					if ((bool)component.material && component.material.HasProperty("_Color"))
					{
						component.material.SetColor("_Color", color2);
					}
					gameObj.AddComponent<Ef_DestroyMaterialOnDestroy>();
				}
				else if ((bool)gameObj.GetComponent<Ef_SwordTrailV2>())
				{
					gameObj.GetComponent<Ef_SwordTrailV2>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_RingMeshV2>())
				{
					gameObj.GetComponent<Ef_RingMeshV2>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_DomeMeshV2>())
				{
					gameObj.GetComponent<Ef_DomeMeshV2>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_SwordTrail>())
				{
					gameObj.GetComponent<Ef_SwordTrail>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_RingMesh>())
				{
					gameObj.GetComponent<Ef_RingMesh>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_DomeMesh>())
				{
					gameObj.GetComponent<Ef_DomeMesh>().color = color2;
				}
				else if ((bool)gameObj.GetComponent<Ef_QuickAnimColor>())
				{
					gameObj.GetComponent<Ef_QuickAnimColor>().color = color2;
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
