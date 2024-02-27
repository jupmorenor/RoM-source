using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DeactiveRelease : Ef_Base
{
	public GameObject[] gameObjs;

	public float setLife;

	public void OnActive()
	{
		if (Ef_Base.isShuttingDown)
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
				if (!(array[RuntimeServices.NormalizeArrayIndex(array, num)] == null))
				{
					GameObject[] array2 = gameObjs;
					if (!(array2[RuntimeServices.NormalizeArrayIndex(array2, num)] == gameObject))
					{
						GameObject[] array3 = gameObjs;
						array3[RuntimeServices.NormalizeArrayIndex(array3, num)].SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDeactive()
	{
		if (Ef_Base.isShuttingDown)
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
					Ef_DeactiveParticle ef_DeactiveParticle = gameObject.GetComponent<Ef_DeactiveParticle>();
					if ((bool)ef_DeactiveParticle)
					{
						ef_DeactiveParticle.sleep = false;
					}
					else
					{
						ef_DeactiveParticle = gameObject.AddComponent<Ef_DeactiveParticle>();
						if (setLife == 0f)
						{
							ef_DeactiveParticle.life = gameObject.particleSystem.startLifetime;
						}
						else
						{
							ef_DeactiveParticle.life = setLife;
						}
					}
					ef_DeactiveParticle.releaseParent = gameObject.transform.parent;
					ef_DeactiveParticle.Initialize();
					gameObject.transform.parent = null;
					continue;
				}
				TrailRenderer component = gameObject.GetComponent<TrailRenderer>();
				if ((bool)component)
				{
					Ef_DeactiveTrail ef_DeactiveTrail = gameObject.GetComponent<Ef_DeactiveTrail>();
					if ((bool)ef_DeactiveTrail)
					{
						ef_DeactiveTrail.sleep = false;
					}
					else
					{
						ef_DeactiveTrail = gameObject.AddComponent<Ef_DeactiveTrail>();
						if (setLife == 0f)
						{
							ef_DeactiveTrail.life = component.time;
						}
						else
						{
							ef_DeactiveTrail.life = setLife;
						}
					}
					ef_DeactiveTrail.releaseParent = gameObject.transform.parent;
					ef_DeactiveTrail.Initialize();
					gameObject.transform.parent = null;
					continue;
				}
				if ((bool)gameObject.renderer)
				{
					Ef_DeactiveAlpha component2 = gameObject.GetComponent<Ef_DeactiveAlpha>();
					if ((bool)component2)
					{
						component2.sleep = false;
					}
					else
					{
						Ef_DeactiveAlpha ef_DeactiveAlpha = gameObject.AddComponent<Ef_DeactiveAlpha>();
						if (setLife == 0f)
						{
							component2.life = 1f;
						}
						else
						{
							component2.life = setLife;
						}
					}
					component2.releaseParent = gameObject.transform.parent;
					component2.Initialize();
					gameObject.transform.parent = null;
					continue;
				}
				Ef_RingMeshV2 component3 = gameObject.GetComponent<Ef_RingMeshV2>();
				if ((bool)component3)
				{
					component3.loop = 0;
					continue;
				}
				Ef_DomeMeshV2 component4 = gameObject.GetComponent<Ef_DomeMeshV2>();
				if ((bool)component4)
				{
					component4.loop = 0;
					continue;
				}
				Ef_DeactiveTimer ef_DeactiveTimer = gameObject.GetComponent<Ef_DeactiveTimer>();
				if ((bool)ef_DeactiveTimer)
				{
					ef_DeactiveTimer.sleep = false;
				}
				else
				{
					ef_DeactiveTimer = gameObject.AddComponent<Ef_DeactiveTimer>();
					if (setLife != 0f)
					{
						ef_DeactiveTimer.life = setLife;
					}
				}
				ef_DeactiveTimer.releaseParent = gameObject.transform.parent;
				ef_DeactiveTimer.Initialize();
				gameObject.transform.parent = null;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		int i = 0;
		GameObject[] array = gameObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
		}
	}
}
