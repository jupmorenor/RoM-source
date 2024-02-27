using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SinWaveMulti : Ef_Base
{
	public Transform[] waveObjs;

	public float waveScaleX;

	public float waveScaleY;

	public float waveScaleZ;

	public float xSiftScaleX;

	public float xSiftScaleZ;

	public float ySiftScaleX;

	public float ySiftScaleZ;

	public float zSiftScaleX;

	public float zSiftScaleZ;

	public float waveTimeX;

	public float waveTimeY;

	public float waveTimeZ;

	public bool restart;

	private float timer;

	private Transform[] parents;

	private int leng;

	private float piScaleX;

	private float piScaleY;

	private float piScaleZ;

	private float piXSiftX;

	private float piXSiftZ;

	private float piYSiftX;

	private float piYSiftZ;

	private float piZSiftX;

	private float piZSiftZ;

	private bool ready;

	public Ef_SinWaveMulti()
	{
		waveScaleX = 1f;
		waveScaleY = 1f;
		waveScaleZ = 1f;
		xSiftScaleX = 10f;
		xSiftScaleZ = 10f;
		ySiftScaleX = 10f;
		ySiftScaleZ = 10f;
		zSiftScaleX = 10f;
		zSiftScaleZ = 10f;
		waveTimeX = 1f;
		waveTimeY = 1f;
		waveTimeZ = 1f;
	}

	public void Start()
	{
		leng = waveObjs.Length;
		parents = new Transform[leng];
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = waveObjs;
				if (!array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					return;
				}
				Transform[] array2 = parents;
				int num2 = RuntimeServices.NormalizeArrayIndex(array2, num);
				Transform[] array3 = waveObjs;
				array2[num2] = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].parent;
				Transform[] array4 = parents;
				if (!array4[RuntimeServices.NormalizeArrayIndex(array4, num)])
				{
					return;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (!(waveTimeX >= 0.1f))
		{
			waveTimeX = 0.1f;
		}
		if (!(waveTimeY >= 0.1f))
		{
			waveTimeY = 0.1f;
		}
		if (!(waveTimeZ >= 0.1f))
		{
			waveTimeZ = 0.1f;
		}
		piScaleX = (float)Math.PI * 2f / waveTimeX;
		piScaleY = (float)Math.PI * 2f / waveTimeY;
		piScaleZ = (float)Math.PI * 2f / waveTimeZ;
		if (xSiftScaleX != 0f)
		{
			piXSiftX = (float)Math.PI * 2f / xSiftScaleX;
		}
		if (xSiftScaleZ != 0f)
		{
			piXSiftZ = (float)Math.PI * 2f / xSiftScaleZ;
		}
		if (ySiftScaleX != 0f)
		{
			piYSiftX = (float)Math.PI * 2f / ySiftScaleX;
		}
		if (ySiftScaleZ != 0f)
		{
			piYSiftZ = (float)Math.PI * 2f / ySiftScaleZ;
		}
		if (zSiftScaleX != 0f)
		{
			piZSiftX = (float)Math.PI * 2f / zSiftScaleX;
		}
		if (zSiftScaleZ != 0f)
		{
			piZSiftZ = (float)Math.PI * 2f / zSiftScaleZ;
		}
		ready = true;
	}

	public void Update()
	{
		if (restart)
		{
			Start();
			restart = false;
		}
		if (!ready)
		{
			return;
		}
		timer += deltaTime;
		float num = timer * piScaleX;
		float num2 = timer * piScaleY;
		float num3 = timer * piScaleZ;
		int num4 = default(int);
		IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num4 = enumerator.Current;
				Transform[] array = parents;
				Vector3 position = array[RuntimeServices.NormalizeArrayIndex(array, num4)].position;
				float x = position.x;
				float z = position.z;
				float x2 = Mathf.Sin(num + x * piXSiftX + z * piXSiftZ) / 2f * waveScaleX;
				float y = Mathf.Sin(num2 + x * piYSiftX + z * piYSiftZ) / 2f * waveScaleY;
				float z2 = Mathf.Sin(num3 + x * piZSiftX + z * piZSiftZ) / 2f * waveScaleZ;
				Transform[] array2 = waveObjs;
				array2[RuntimeServices.NormalizeArrayIndex(array2, num4)].position = position + new Vector3(x2, y, z2);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
