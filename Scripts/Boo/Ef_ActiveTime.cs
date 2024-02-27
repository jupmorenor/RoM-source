using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ActiveTime : Ef_Base
{
	public GameObject[] gameObjs;

	public float time;

	public float life;

	public bool rerease;

	public Ef_ActiveTime()
	{
		gameObjs = new GameObject[0];
		time = 1f;
	}

	public void Start()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(gameObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = gameObjs;
				array[RuntimeServices.NormalizeArrayIndex(array, num)].SetActive(value: false);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Update()
	{
		int num = default(int);
		if (!(time <= 0f))
		{
			time -= deltaTime;
			if (time > 0f)
			{
				return;
			}
			IEnumerator<int> enumerator = Builtins.range(gameObjs.Length).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					GameObject[] array = gameObjs;
					if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
					{
						GameObject[] array2 = gameObjs;
						array2[RuntimeServices.NormalizeArrayIndex(array2, num)].SetActive(value: true);
						if (rerease)
						{
							GameObject[] array3 = gameObjs;
							array3[RuntimeServices.NormalizeArrayIndex(array3, num)].transform.parent = null;
						}
					}
				}
				return;
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		if (life <= 0f)
		{
			return;
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		IEnumerator<int> enumerator2 = Builtins.range(gameObjs.Length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				GameObject[] array4 = gameObjs;
				if ((bool)array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
				{
					GameObject[] array5 = gameObjs;
					UnityEngine.Object.Destroy(array5[RuntimeServices.NormalizeArrayIndex(array5, num)]);
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}
}
