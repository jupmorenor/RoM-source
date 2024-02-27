using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_ParticleEmitFromMesh : MonoBehaviour
{
	public Mesh mesh;

	public float startPos;

	public bool setParticle;

	public bool testEmit;

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
		SetParticle();
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
		if (!mesh)
		{
			return;
		}
		Ef_ParticleEmit component = gameObject.GetComponent<Ef_ParticleEmit>();
		if (!component)
		{
			return;
		}
		component.vecs = mesh.vertices;
		int length = component.vecs.Length;
		int num = default(int);
		checked
		{
			if (mesh.colors.Length == length)
			{
				Color32[] array = null;
				array = new Color32[mesh.colors.Length];
				IEnumerator<int> enumerator = Builtins.range(mesh.colors.Length).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						Color32[] array2 = array;
						ref Color32 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
						Color[] colors = mesh.colors;
						byte r = (byte)Mathf.CeilToInt(colors[RuntimeServices.NormalizeArrayIndex(colors, num)].r * 255f);
						Color[] colors2 = mesh.colors;
						byte g = (byte)Mathf.CeilToInt(colors2[RuntimeServices.NormalizeArrayIndex(colors2, num)].g * 255f);
						Color[] colors3 = mesh.colors;
						byte b = (byte)Mathf.CeilToInt(colors3[RuntimeServices.NormalizeArrayIndex(colors3, num)].b * 255f);
						Color[] colors4 = mesh.colors;
						reference = new Color32(r, g, b, (byte)Mathf.CeilToInt(colors4[RuntimeServices.NormalizeArrayIndex(colors4, num)].a * 255f));
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				component.colors = array;
			}
			if (startPos <= 0f)
			{
				return;
			}
			Vector3[] array3 = new Vector3[length];
			IEnumerator<int> enumerator2 = Builtins.range(length).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					ref Vector3 reference2 = ref array3[RuntimeServices.NormalizeArrayIndex(array3, num)];
					Vector3[] vecs = component.vecs;
					reference2 = vecs[RuntimeServices.NormalizeArrayIndex(vecs, num)] * startPos;
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			component.positions = array3;
		}
	}
}
