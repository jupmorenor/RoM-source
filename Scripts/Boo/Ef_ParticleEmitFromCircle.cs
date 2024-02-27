using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_ParticleEmitFromCircle : MonoBehaviour
{
	public int numberOfParticle;

	public float startPos;

	public bool setParticle;

	public bool testEmit;

	public Ef_ParticleEmitFromCircle()
	{
		numberOfParticle = 20;
	}

	public void Start()
	{
		Ef_ParticleEmit component = gameObject.GetComponent<Ef_ParticleEmit>();
		if (!component)
		{
			gameObject.AddComponent<Ef_ParticleEmit>();
		}
		if (!particleSystem)
		{
			gameObject.AddComponent<ParticleSystem>();
		}
		particleSystem.enableEmission = false;
	}

	public void Update()
	{
		if (setParticle)
		{
			SetParticle();
			setParticle = false;
		}
		if (!testEmit)
		{
			return;
		}
		Ef_ParticleEmit component = gameObject.GetComponent<Ef_ParticleEmit>();
		if ((bool)component)
		{
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;
			int num = 0;
			int length = component.vecs.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int pt = num;
				num++;
				component.Emit(pt, position, rotation);
			}
		}
		testEmit = false;
	}

	public void SetParticle()
	{
		Ef_ParticleEmit component = gameObject.GetComponent<Ef_ParticleEmit>();
		if (!component)
		{
			return;
		}
		Vector3[] array = new Vector3[numberOfParticle];
		float num = 360f / (float)numberOfParticle;
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(numberOfParticle).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num2 = enumerator.Current;
				ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num2)];
				reference = Quaternion.Euler(0f, 0f, num * (float)num2) * new Vector3(0f, 1f, 0f);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		component.vecs = array;
		int length = component.vecs.Length;
		if (startPos <= 0f)
		{
			return;
		}
		Vector3[] array2 = new Vector3[length];
		IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				num2 = enumerator2.Current;
				ref Vector3 reference2 = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num2)];
				Vector3[] vecs = component.vecs;
				reference2 = vecs[RuntimeServices.NormalizeArrayIndex(vecs, num2)] * startPos;
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
		component.positions = array2;
	}
}
