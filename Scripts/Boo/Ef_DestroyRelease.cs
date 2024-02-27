using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyRelease : Ef_Base
{
	public GameObject[] gameObjs;

	public float life;

	public SQEX_SoundPlayerData.SE destroySE;

	private bool end;

	public Ef_DestroyRelease()
	{
		destroySE = SQEX_SoundPlayerData.SE.NONE;
	}

	public void OnDestroy()
	{
		Release();
	}

	public void Release()
	{
		if (Ef_Base.isShuttingDown || end)
		{
			return;
		}
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
				if (!gameObject.activeSelf)
				{
					continue;
				}
				if ((bool)gameObject.particleSystem)
				{
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
				else if ((bool)gameObject.GetComponent<Ef_RingMeshV2>())
				{
					Ef_RingMeshV2 component = gameObject.GetComponent<Ef_RingMeshV2>();
					component.loop = 0;
					component.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component.life;
					gameObject.transform.parent = null;
				}
				else if ((bool)gameObject.GetComponent<Ef_DomeMeshV2>())
				{
					Ef_DomeMeshV2 component2 = gameObject.GetComponent<Ef_DomeMeshV2>();
					component2.loop = 0;
					component2.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component2.life;
					gameObject.transform.parent = null;
				}
				else if ((bool)gameObject.GetComponent<Ef_RandomStart>())
				{
					Ef_RandomStart component3 = gameObject.GetComponent<Ef_RandomStart>();
					component3.loop = 0;
					component3.enabled = true;
					gameObject.transform.parent = null;
				}
				else if ((bool)gameObject.GetComponent<Ef_RingMesh>())
				{
					Ef_RingMesh component4 = gameObject.GetComponent<Ef_RingMesh>();
					component4.loop = 0;
					component4.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component4.life;
					gameObject.transform.parent = null;
				}
				else if ((bool)gameObject.GetComponent<Ef_DomeMesh>())
				{
					Ef_DomeMesh component5 = gameObject.GetComponent<Ef_DomeMesh>();
					component5.loop = 0;
					component5.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component5.life;
					gameObject.transform.parent = null;
				}
				else
				{
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
		end = true;
		if (destroySE != SQEX_SoundPlayerData.SE.NONE)
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if ((bool)instance)
			{
				instance.PlaySe((int)destroySE, 0, this.gameObject.GetInstanceID());
			}
		}
	}
}
