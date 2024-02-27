using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ParticlePlayDistance : MonoBehaviour
{
	public GameObject[] particleObjs;

	public float distance;

	public bool clear;

	private int leng;

	private Vector3 lstPos;

	private float distCount;

	private bool ready;

	private ParticleSystem[] pss;

	public Ef_ParticlePlayDistance()
	{
		distance = 2f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		distCount = 0f;
	}

	public void Start()
	{
		Init();
	}

	public void Init()
	{
		int num = particleObjs.Length;
		if (num == 0)
		{
			particleObjs = new GameObject[1];
			particleObjs[0] = gameObject;
			num = 1;
		}
		leng = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			GameObject[] array = particleObjs;
			checked
			{
				if (array[RuntimeServices.NormalizeArrayIndex(array, index)].particleSystem != null)
				{
					leng++;
				}
			}
		}
		if (leng == 0)
		{
			return;
		}
		pss = new ParticleSystem[leng];
		int num4 = 0;
		int num5 = 0;
		int num6 = num;
		if (num6 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num5 < num6)
		{
			int index2 = num5;
			num5++;
			GameObject[] array2 = particleObjs;
			if (array2[RuntimeServices.NormalizeArrayIndex(array2, index2)].particleSystem != null)
			{
				ParticleSystem[] array3 = pss;
				int num7 = RuntimeServices.NormalizeArrayIndex(array3, num4);
				GameObject[] array4 = particleObjs;
				array3[num7] = array4[RuntimeServices.NormalizeArrayIndex(array4, index2)].particleSystem;
				num4 = checked(num4 + 1);
			}
		}
		distCount = 0f;
		ready = true;
	}

	public void Update()
	{
		if (!ready)
		{
			return;
		}
		Vector3 position = transform.position;
		Vector3 vector = position - lstPos;
		lstPos = position;
		distCount += vector.magnitude;
		if (!(distCount < distance))
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
				ParticleSystem[] array = pss;
				array[RuntimeServices.NormalizeArrayIndex(array, index)].Play();
			}
			distCount = 0f;
		}
	}
}
