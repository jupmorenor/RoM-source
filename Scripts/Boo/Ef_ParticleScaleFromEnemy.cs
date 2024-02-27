using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_ParticleScaleFromEnemy : MonoBehaviour
{
	public string targetTag;

	public GameObject[] particleObjs;

	public float testScale;

	public Mesh mesh;

	public Ef_ParticleScaleFromEnemy()
	{
		targetTag = "Enemy";
		testScale = 1f;
	}

	public void Start()
	{
		FindTarget();
	}

	public void FindTarget()
	{
		float num = default(float);
		if (testScale == 0f)
		{
			Transform transform = null;
			GameObject[] array = GameObject.FindGameObjectsWithTag(targetTag);
			float num2 = 999f;
			int i = 0;
			GameObject[] array2 = array;
			for (int length = array2.Length; i < length; i = checked(i + 1))
			{
				BaseControl component = array2[i].GetComponent<BaseControl>();
				if ((bool)component)
				{
					float magnitude = (array2[i].transform.position - this.transform.position).magnitude;
					if (!(magnitude >= num2))
					{
						transform = array2[i].transform;
						num2 = magnitude;
					}
				}
			}
			if (DebugLogWraning(!transform, "No " + targetTag + " Object"))
			{
				return;
			}
			MerlinMotionPackControl component2 = transform.GetComponent<MerlinMotionPackControl>();
			if (DebugLogWraning(!component2, "No MMPC Component"))
			{
				return;
			}
			AIControl component3 = transform.GetComponent<AIControl>();
			if (DebugLogWraning(!component3, "No AIC Component"))
			{
				return;
			}
			Animation motionTarget = component2.motionTarget;
			if (DebugLogWraning(!motionTarget, "No Motion Target"))
			{
				return;
			}
			Transform transform2 = motionTarget.transform.Find("poly");
			if (DebugLogWraning(!transform2, "No Motion Target"))
			{
				return;
			}
			SkinnedMeshRenderer[] array3 = (SkinnedMeshRenderer[])UnityEngine.Object.FindObjectsOfType(typeof(SkinnedMeshRenderer));
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			IEnumerator<int> enumerator = Builtins.range(array3.Length).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					if (array3[RuntimeServices.NormalizeArrayIndex(array3, current)].transform.parent == transform2)
					{
						skinnedMeshRenderer = array3[RuntimeServices.NormalizeArrayIndex(array3, current)];
						break;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			if (DebugLogWraning(!skinnedMeshRenderer, "No SkinnedMeshRenderer"))
			{
				return;
			}
			mesh = skinnedMeshRenderer.sharedMesh;
			if (DebugLogWraning(!mesh, "No Mesh"))
			{
				return;
			}
			Bounds bounds = mesh.bounds;
			Vector3 size = bounds.size;
			if (!(size.x <= size.y))
			{
				size.x /= 2f;
			}
			if (!(size.z <= size.y))
			{
				size.z /= 2f;
			}
			num = (bounds.size.x + bounds.size.y + bounds.size.z) / 3f;
		}
		else
		{
			num = testScale;
		}
		if (!(num <= 1f))
		{
			float num3 = 0f;
			float num4 = 1f;
			float num5 = 0.1f;
			int num6 = default(int);
			IEnumerator<int> enumerator2 = Builtins.range(Mathf.FloorToInt(num)).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num6 = enumerator2.Current;
					num3 += num4;
					num4 -= num5;
					if (!(num4 > 0f))
					{
						break;
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
			num3 += num4 * (num % 1f);
			num = num3;
		}
		IEnumerator<int> enumerator3 = Builtins.range(particleObjs.Length).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				int num6 = enumerator3.Current;
				GameObject[] array4 = particleObjs;
				ParticleSystem particleSystem = array4[RuntimeServices.NormalizeArrayIndex(array4, num6)].particleSystem;
				GameObject[] array5 = particleObjs;
				Component component4 = array5[RuntimeServices.NormalizeArrayIndex(array5, num6)].GetComponent("WindZone");
				if ((bool)particleSystem)
				{
					particleSystem.startSize *= num;
					particleSystem.startSpeed *= num;
					particleSystem.transform.localPosition = particleSystem.transform.localPosition * num;
					particleSystem.transform.localScale = particleSystem.transform.localScale * num;
				}
				if ((bool)component4)
				{
					component4.transform.localPosition = component4.transform.localPosition * num;
					component4.SendMessage("WindZoneScale", num, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		finally
		{
			enumerator3.Dispose();
		}
	}

	public bool DebugLogWraning(bool flg, string errTxt)
	{
		if (flg)
		{
		}
		return flg;
	}
}
