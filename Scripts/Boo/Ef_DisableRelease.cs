using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(MeshRenderer))]
public class Ef_DisableRelease : Ef_Base
{
	public GameObject[] gameObjs;

	public float life;

	private bool ready;

	public void Start()
	{
		if (!renderer)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Update()
	{
		if (renderer.enabled)
		{
			ready = true;
		}
		if (!renderer.enabled && ready)
		{
			Release();
		}
	}

	public void Release()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(gameObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = gameObjs;
				if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == null)
				{
					continue;
				}
				GameObject[] array2 = gameObjs;
				GameObject gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
				if ((bool)gameObject.particleSystem)
				{
					gameObject.SetActive(value: true);
					gameObject.transform.parent = null;
					Ef_DestroyParticle ef_DestroyParticle = gameObject.AddComponent<Ef_DestroyParticle>();
					if (life == 0f)
					{
						ef_DestroyParticle.life = gameObject.particleSystem.startLifetime;
					}
					else
					{
						ef_DestroyParticle.life = life;
					}
				}
				else if ((bool)gameObject.GetComponent<TrailRenderer>())
				{
					gameObject.SetActive(value: true);
					gameObject.transform.parent = null;
					Ef_DestroyTrail ef_DestroyTrail = gameObject.AddComponent<Ef_DestroyTrail>();
					if (life == 0f)
					{
						ef_DestroyTrail.life = gameObject.GetComponent<TrailRenderer>().time;
					}
					else
					{
						ef_DestroyTrail.life = life;
					}
				}
				else if ((bool)gameObject.renderer)
				{
					gameObject.SetActive(value: true);
					gameObject.transform.parent = null;
					Ef_DestroyAlpha ef_DestroyAlpha = gameObject.AddComponent<Ef_DestroyAlpha>();
					if (life == 0f)
					{
						ef_DestroyAlpha.life = 1f;
					}
					else
					{
						ef_DestroyAlpha.life = life;
					}
				}
				else if ((bool)gameObject.GetComponent<Ef_RingMesh>())
				{
					gameObject.SetActive(value: true);
					gameObject.GetComponent<Ef_RingMesh>().loop = 0;
					gameObject.GetComponent<Ef_RingMesh>().enabled = true;
					gameObject.transform.parent = null;
				}
				else
				{
					gameObject.SetActive(value: true);
					gameObject.transform.parent = null;
					Ef_DestroyTimer ef_DestroyTimer = gameObject.AddComponent<Ef_DestroyTimer>();
					ef_DestroyTimer.life = life;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
