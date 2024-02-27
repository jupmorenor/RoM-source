using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyReleaseV2 : Ef_Base
{
	public GameObject[] releaseObjs;

	public float life;

	public Transform releaseRootObj;

	private int leng;

	private bool useChildPos;

	private bool useChildRot;

	private Vector3 childPos;

	private Quaternion childRot;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private bool ready;

	private bool end;

	public void OnDestroy()
	{
		Release();
		if (releaseRootObj != null)
		{
			UnityEngine.Object.Destroy(releaseRootObj.gameObject);
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		leng = releaseObjs.Length;
		if (releaseRootObj != null)
		{
			childPos = releaseRootObj.localPosition;
			childRot = releaseRootObj.localRotation;
			useChildPos = childPos != Vector3.zero;
			useChildRot = childRot != Quaternion.identity;
			releaseRootObj.parent = null;
		}
		ready = true;
	}

	public void Update()
	{
		if (releaseRootObj == null)
		{
			return;
		}
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		if (position != lstPos)
		{
			if (useChildPos)
			{
				releaseRootObj.position = position + rotation * childPos;
			}
			else
			{
				releaseRootObj.position = position;
			}
			lstPos = position;
		}
		if (rotation != lstRot)
		{
			if (useChildRot)
			{
				releaseRootObj.rotation = rotation * childRot;
			}
			else
			{
				releaseRootObj.rotation = rotation;
			}
			lstRot = rotation;
		}
	}

	public void LateUpdate()
	{
		if (releaseRootObj == null)
		{
			return;
		}
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		if (position != lstPos)
		{
			if (useChildPos)
			{
				releaseRootObj.position = position + rotation * childPos;
			}
			else
			{
				releaseRootObj.position = position;
			}
			lstPos = position;
		}
		if (rotation != lstRot)
		{
			if (useChildRot)
			{
				releaseRootObj.rotation = rotation * childRot;
			}
			else
			{
				releaseRootObj.rotation = rotation;
			}
			lstRot = rotation;
		}
	}

	public void Release()
	{
		if (Ef_Base.isShuttingDown || end || releaseObjs == null)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(releaseObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				GameObject[] array = releaseObjs;
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, num)];
				if (gameObject == null || !gameObject.activeSelf)
				{
					continue;
				}
				ParticleSystem particleSystem = gameObject.particleSystem;
				if (particleSystem != null)
				{
					gameObject.transform.parent = null;
					Ef_ParticleDuration component = gameObject.GetComponent<Ef_ParticleDuration>();
					if (component != null)
					{
						component.delay = 0f;
						component.duration = 0f;
					}
					Ef_DestroyParticle ef_DestroyParticle = gameObject.AddComponent<Ef_DestroyParticle>();
					if (life == 0f)
					{
						ef_DestroyParticle.life = particleSystem.startLifetime;
					}
					else
					{
						ef_DestroyParticle.life = life;
					}
					continue;
				}
				TrailRenderer component2 = gameObject.GetComponent<TrailRenderer>();
				if (component2 != null)
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
					continue;
				}
				Renderer renderer = gameObject.renderer;
				if (renderer != null)
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
					continue;
				}
				Ef_RingMeshV2 component3 = gameObject.GetComponent<Ef_RingMeshV2>();
				if (component3 != null)
				{
					component3.loop = 0;
					component3.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component3.life;
					gameObject.transform.parent = null;
					continue;
				}
				Ef_DomeMeshV2 component4 = gameObject.GetComponent<Ef_DomeMeshV2>();
				if (component4 != null)
				{
					component4.loop = 0;
					component4.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component4.life;
					gameObject.transform.parent = null;
					continue;
				}
				Ef_RandomStart component5 = gameObject.GetComponent<Ef_RandomStart>();
				if (component5 != null)
				{
					component5.loop = 0;
					component5.enabled = true;
					gameObject.transform.parent = null;
					continue;
				}
				Ef_RingMesh component6 = gameObject.GetComponent<Ef_RingMesh>();
				if (component6 != null)
				{
					component6.loop = 0;
					component6.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component6.life;
					gameObject.transform.parent = null;
					continue;
				}
				Ef_DomeMesh component7 = gameObject.GetComponent<Ef_DomeMesh>();
				if (component7 != null)
				{
					component7.loop = 0;
					component7.enabled = true;
					gameObject.AddComponent<Ef_DestroyTimer>().life = component7.life;
					gameObject.transform.parent = null;
					continue;
				}
				if (life == 0f)
				{
					if ((bool)gameObject.GetComponent<Ef_DestroyTimer>())
					{
						gameObject.transform.parent = null;
						continue;
					}
					if ((bool)gameObject.GetComponent<Ef_DestroyAlpha>())
					{
						gameObject.transform.parent = null;
						continue;
					}
					if ((bool)gameObject.GetComponent<Ef_DestroyScale>())
					{
						gameObject.transform.parent = null;
						continue;
					}
				}
				Ef_DestroyTimer ef_DestroyTimer = gameObject.AddComponent<Ef_DestroyTimer>();
				if (life == 0f)
				{
					life = 10f;
				}
				ef_DestroyTimer.life = life;
				gameObject.transform.parent = null;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		end = true;
	}
}
