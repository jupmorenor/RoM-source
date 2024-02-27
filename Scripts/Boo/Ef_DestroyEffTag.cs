using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyEffTag : MonoBehaviour
{
	public string effTag;

	public float distance;

	private Ef_TagDatas tagDats;

	private bool end;

	public Ef_DestroyEffTag()
	{
		distance = 1f;
	}

	public void Start()
	{
		if (transform.position != Vector3.zero)
		{
			CheckAndDestroy();
		}
	}

	public void Update()
	{
		if (!end)
		{
			CheckAndDestroy();
			end = true;
		}
	}

	public void CheckAndDestroy()
	{
		if (effTag.Length == 0)
		{
			return;
		}
		tagDats = Ef_TagDatas.Current;
		if (tagDats == null)
		{
			Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
			if (component != null)
			{
				component.Release();
			}
			else
			{
				Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
				if (component2 != null)
				{
					component2.Release();
				}
			}
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		GameObject[] array = tagDats.SearchTag(effTag);
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(array.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)] != gameObject)
				{
					if (!((array[RuntimeServices.NormalizeArrayIndex(array, num)].transform.position - transform.position).sqrMagnitude >= distance * distance))
					{
						array[RuntimeServices.NormalizeArrayIndex(array, num)].transform.position = new Vector3(0f, -9999f, 0f);
						UnityEngine.Object.Destroy(array[RuntimeServices.NormalizeArrayIndex(array, num)]);
						end = true;
						break;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
