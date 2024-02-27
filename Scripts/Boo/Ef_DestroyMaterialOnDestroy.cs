using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyMaterialOnDestroy : MonoBehaviour
{
	public GameObject[] rendererObjs;

	public void OnDestroy()
	{
		if (rendererObjs == null || rendererObjs.Length == 0)
		{
			rendererObjs = new GameObject[1];
			rendererObjs[0] = this.gameObject;
		}
		int num = 0;
		int length = rendererObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			GameObject[] array = rendererObjs;
			GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (!gameObject || !gameObject.renderer)
			{
				continue;
			}
			int i = 0;
			Material[] materials = gameObject.renderer.materials;
			for (int length2 = materials.Length; i < length2; i = checked(i + 1))
			{
				if ((bool)materials[i])
				{
					UnityEngine.Object.Destroy(materials[i]);
				}
			}
		}
	}
}
