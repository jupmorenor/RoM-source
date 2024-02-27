using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HidePuppetRing : Ef_Base
{
	public Transform target;

	public float life;

	public bool destroy;

	private Transform[] ringObjs;

	private Transform[] starObjs;

	private int leng;

	public Ef_HidePuppetRing()
	{
		life = 1f;
		destroy = true;
	}

	public void Start()
	{
		TargetRingStar[] array = (TargetRingStar[])UnityEngine.Object.FindObjectsOfType(typeof(TargetRingStar));
		leng = array.Length;
		ringObjs = new Transform[leng];
		starObjs = new Transform[leng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array2 = ringObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num)] = array[RuntimeServices.NormalizeArrayIndex(array, num)].transform.Find("Ring");
				Transform[] array3 = starObjs;
				array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = array[RuntimeServices.NormalizeArrayIndex(array, num)].transform.Find("Star");
				Transform[] array4 = ringObjs;
				if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
				{
					Transform[] array5 = ringObjs;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)].gameObject.SetActive(value: false);
				}
				Transform[] array6 = starObjs;
				if ((bool)array6[RuntimeServices.NormalizeArrayIndex(array6, num)])
				{
					Transform[] array7 = starObjs;
					array7[RuntimeServices.NormalizeArrayIndex(array7, num)].gameObject.SetActive(value: false);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Update()
	{
		if (life <= 0f)
		{
			return;
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = ringObjs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Transform[] array2 = ringObjs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObject.SetActive(value: true);
				}
				Transform[] array3 = starObjs;
				if ((bool)array3[RuntimeServices.NormalizeArrayIndex(array3, num)])
				{
					Transform[] array4 = starObjs;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num)].gameObject.SetActive(value: true);
				}
				if (destroy)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		if (destroy)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = ringObjs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Transform[] array2 = ringObjs;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObject.SetActive(value: true);
				}
				Transform[] array3 = starObjs;
				if ((bool)array3[RuntimeServices.NormalizeArrayIndex(array3, num)])
				{
					Transform[] array4 = starObjs;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num)].gameObject.SetActive(value: true);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
