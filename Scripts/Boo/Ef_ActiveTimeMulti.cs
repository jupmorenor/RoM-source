using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ActiveTimeMulti : Ef_Base
{
	public GameObject[] gameObjs;

	public float delay;

	public float timer;

	public float life;

	public bool rerease;

	private float oneTime;

	private float nextTime;

	private int no;

	private int leng;

	public Ef_ActiveTimeMulti()
	{
		gameObjs = new GameObject[0];
		delay = 1f;
		timer = 1f;
		life = 1f;
	}

	public void Start()
	{
		leng = gameObjs.Length;
		int num = default(int);
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
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].SetActive(value: false);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		oneTime = timer / (float)leng;
		nextTime = timer - oneTime;
	}

	public void Update()
	{
		checked
		{
			if (!(delay <= 0f))
			{
				delay -= deltaTime;
			}
			else if (!(timer <= 0f))
			{
				timer -= deltaTime;
				if (timer >= nextTime)
				{
					return;
				}
				if (no < leng)
				{
					GameObject[] array = gameObjs;
					if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, no)])
					{
						GameObject[] array2 = gameObjs;
						array2[RuntimeServices.NormalizeArrayIndex(array2, no)].SetActive(value: true);
						if (rerease)
						{
							GameObject[] array3 = gameObjs;
							array3[RuntimeServices.NormalizeArrayIndex(array3, no)].transform.parent = null;
						}
					}
					no++;
				}
				nextTime -= oneTime;
			}
			else if (!(life <= 0f))
			{
				life -= deltaTime;
				if (!(life > 0f))
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
	}

	public void OnDestroy()
	{
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject[] array = gameObjs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, index)])
			{
				GameObject[] array2 = gameObjs;
				UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
			}
		}
	}
}
