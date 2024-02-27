using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ParticleMaxDistance : MonoBehaviour
{
	public GameObject[] particleObjs;

	public float maxDistance;

	public bool clear;

	private int leng;

	private ParticleSystem[] pss;

	private float[] fstRates;

	private Vector3 lstPos;

	private float sqrMax;

	private bool ready;

	private bool emitOn;

	public Ef_ParticleMaxDistance()
	{
		maxDistance = 2f;
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
		fstRates = new float[leng];
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
				float[] array5 = fstRates;
				int num8 = RuntimeServices.NormalizeArrayIndex(array5, num4);
				ParticleSystem[] array6 = pss;
				array5[num8] = array6[RuntimeServices.NormalizeArrayIndex(array6, num4)].emissionRate;
				ParticleSystem[] array7 = pss;
				array7[RuntimeServices.NormalizeArrayIndex(array7, num4)].emissionRate = 0f;
				num4 = checked(num4 + 1);
			}
		}
		emitOn = false;
		sqrMax = maxDistance * maxDistance;
		ready = true;
	}

	public void Update()
	{
		if (!ready)
		{
			return;
		}
		Vector3 position = transform.position;
		Vector3 vector = lstPos - position;
		lstPos = position;
		if (!(vector.sqrMagnitude <= sqrMax))
		{
			if (clear)
			{
				if (emitOn)
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
						array[RuntimeServices.NormalizeArrayIndex(array, index)].Clear();
					}
				}
			}
			else if (emitOn)
			{
				int num3 = 0;
				int num4 = leng;
				if (num4 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num3 < num4)
				{
					int index2 = num3;
					num3++;
					ParticleSystem[] array2 = pss;
					array2[RuntimeServices.NormalizeArrayIndex(array2, index2)].emissionRate = 0f;
				}
				emitOn = false;
			}
		}
		else if (!emitOn)
		{
			int num5 = 0;
			int num6 = leng;
			if (num6 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num5 < num6)
			{
				int index3 = num5;
				num5++;
				ParticleSystem[] array3 = pss;
				ParticleSystem obj = array3[RuntimeServices.NormalizeArrayIndex(array3, index3)];
				float[] array4 = fstRates;
				obj.emissionRate = array4[RuntimeServices.NormalizeArrayIndex(array4, index3)];
			}
			emitOn = true;
		}
	}
}
