using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyParticle : Ef_Base
{
	public GameObject[] gameObjs;

	public float life;

	public float fadeDelay;

	private int leng;

	private bool stop;

	private float fadeTime;

	public Ef_DestroyParticle()
	{
		gameObjs = new GameObject[0];
		life = 1f;
	}

	public void Start()
	{
		leng = gameObjs.Length;
		if (leng == 0)
		{
			gameObjs = new GameObject[1];
			gameObjs[0] = gameObject;
			leng = 1;
		}
		fadeTime = life - fadeDelay;
	}

	public void Update()
	{
		life -= deltaTime;
		int num = default(int);
		if (!(life <= 0f))
		{
			if (stop || life > fadeTime)
			{
				return;
			}
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					GameObject[] array = gameObjs;
					GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, num)];
					if ((bool)gameObject && (bool)gameObject.particleSystem)
					{
						if (!(gameObject.particleSystem.emissionRate <= 0f))
						{
							gameObject.particleSystem.emissionRate = 0f;
						}
						if (gameObject.particleSystem.loop)
						{
							gameObject.particleSystem.loop = false;
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			stop = true;
			return;
		}
		IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num = enumerator2.Current;
				GameObject[] array2 = gameObjs;
				Ef_DestroyReleaseV2 component = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].GetComponent<Ef_DestroyReleaseV2>();
				if (component != null)
				{
					component.Release();
				}
				else
				{
					GameObject[] array3 = gameObjs;
					Ef_DestroyRelease component2 = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].GetComponent<Ef_DestroyRelease>();
					if (component2 != null)
					{
						component2.Release();
					}
				}
				GameObject[] array4 = gameObjs;
				UnityEngine.Object.Destroy(array4[RuntimeServices.NormalizeArrayIndex(array4, num)]);
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}
}
