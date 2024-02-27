using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ShadowDistance : Ef_Base
{
	public float shadowDistance;

	public bool calacterDistance;

	public float calacterDistPlus;

	public float maxDist;

	public bool twoOrder;

	public Transform[] characters;

	private float[] mags;

	private bool[] nears;

	private float lstValue;

	private int leng;

	private float retryTimer;

	private int retryCount;

	public Ef_ShadowDistance()
	{
		shadowDistance = 10f;
		calacterDistance = true;
		calacterDistPlus = 5f;
		maxDist = 40f;
		twoOrder = true;
		lstValue = 40f;
		retryTimer = 1f;
		retryCount = 5;
	}

	public void Start()
	{
		lstValue = QualitySettings.shadowDistance;
		QualitySettings.shadowDistance = shadowDistance;
		if (!calacterDistance)
		{
			return;
		}
		characters = new Transform[6];
		mags = new float[6];
		nears = new bool[6];
		AnimationEventHandler[] array = (AnimationEventHandler[])UnityEngine.Object.FindObjectsOfType(typeof(AnimationEventHandler));
		int num = 0;
		int length = array.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)].transform.position.x == 0f)
			{
				if (array[RuntimeServices.NormalizeArrayIndex(array, index)].transform.position.z == 0f)
				{
					continue;
				}
			}
			Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, index)].transform.Find("y_ang");
			if (!transform)
			{
				continue;
			}
			Transform transform2 = transform.Find("cog");
			checked
			{
				if ((bool)transform2)
				{
					Transform[] array2 = characters;
					array2[RuntimeServices.NormalizeArrayIndex(array2, leng)] = transform2;
					leng++;
					if (leng >= 6)
					{
						break;
					}
				}
			}
		}
	}

	public void Update()
	{
		if (!calacterDistance)
		{
			return;
		}
		checked
		{
			if (leng == 0)
			{
				retryTimer -= deltaTime;
				if (!(retryTimer > 0f))
				{
					Start();
					retryCount--;
					if (retryCount == 0)
					{
						UnityEngine.Object.Destroy(gameObject);
					}
					retryTimer = 1f;
				}
				return;
			}
			int num = default(int);
			IEnumerator<int> enumerator = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Transform[] array = characters;
					if (!array[RuntimeServices.NormalizeArrayIndex(array, num)])
					{
						UnityEngine.Object.Destroy(gameObject);
						return;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			Camera main = Camera.main;
			if (!main)
			{
				return;
			}
			Vector3 position = main.transform.position;
			float num2 = shadowDistance;
			float num3 = default(float);
			bool flag = false;
			float num4 = 99f;
			float num5 = 99f;
			IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					float[] array2 = mags;
					int num6 = RuntimeServices.NormalizeArrayIndex(array2, num);
					Transform[] array3 = characters;
					array2[num6] = (array3[RuntimeServices.NormalizeArrayIndex(array3, num)].position - position).magnitude;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			if (twoOrder)
			{
				IEnumerator<int> enumerator3 = Builtins.range(leng).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						num = enumerator3.Current;
						float[] array4 = mags;
						num3 = array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
						if (!(num3 >= num5))
						{
							if (!(num3 >= num4))
							{
								num5 = num4;
								num4 = num3;
							}
							else
							{
								num5 = num3;
							}
							bool[] array5 = nears;
							array5[RuntimeServices.NormalizeArrayIndex(array5, num)] = true;
						}
						else
						{
							bool[] array6 = nears;
							array6[RuntimeServices.NormalizeArrayIndex(array6, num)] = false;
						}
					}
				}
				finally
				{
					enumerator3.Dispose();
				}
			}
			IEnumerator<int> enumerator4 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					num = enumerator4.Current;
					flag = true;
					float[] array7 = mags;
					num3 = array7[RuntimeServices.NormalizeArrayIndex(array7, num)];
					num3 += calacterDistPlus;
					if (twoOrder)
					{
						bool[] array8 = nears;
						if (!array8[RuntimeServices.NormalizeArrayIndex(array8, num)])
						{
							continue;
						}
					}
					if (!(num3 <= num2))
					{
						num2 = num3;
						if (!(num2 <= maxDist))
						{
							num2 = maxDist;
						}
					}
				}
			}
			finally
			{
				enumerator4.Dispose();
			}
			QualitySettings.shadowDistance = num2;
			if (!flag)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnDestroy()
	{
		if (lstValue == 0f)
		{
			lstValue = 40f;
		}
		QualitySettings.shadowDistance = lstValue;
	}

	public void OnDisable()
	{
		if (lstValue == 0f)
		{
			lstValue = 40f;
		}
		QualitySettings.shadowDistance = lstValue;
	}
}
