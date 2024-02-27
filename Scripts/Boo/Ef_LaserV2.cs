using System;
using UnityEngine;

[Serializable]
public class Ef_LaserV2 : Ef_Base
{
	public Transform tgtObj;

	public Transform smkObj;

	public Transform spkObj;

	public Transform mltObj;

	public Transform flrObj;

	public float laserWidth;

	public float life;

	public float fadeTime;

	public Transform parentObj;

	public int mask;

	private bool activeMode;

	private LineRenderer line;

	private bool parentFlg;

	private Vector3 fstPos;

	private bool fstTerCol;

	private float fstLife;

	private bool ready;

	public Ef_LaserV2()
	{
		laserWidth = 2f;
		life = 5f;
		fadeTime = 1f;
		mask = -33284096;
		fstPos = Vector3.zero;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		life = fstLife;
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
		fstLife = life;
		if ((bool)tgtObj && (bool)smkObj && (bool)spkObj && (bool)mltObj && (bool)flrObj)
		{
			line = gameObject.GetComponent<LineRenderer>() as LineRenderer;
			line.SetWidth(laserWidth, laserWidth);
			if (!parentObj)
			{
				parentObj = transform.parent;
			}
			if ((bool)parentObj)
			{
				parentFlg = true;
				fstPos = transform.localPosition;
				transform.parent = null;
			}
			Ef_ActiveOn component = gameObject.GetComponent<Ef_ActiveOn>();
			bool num = component != null;
			if (num)
			{
				num = component.enable;
			}
			activeMode = num;
			ready = true;
		}
	}

	public void Update()
	{
		if ((bool)parentObj)
		{
			Vector3 position = parentObj.position;
			Quaternion rotation = parentObj.rotation;
			transform.position = position + rotation * fstPos;
			transform.rotation = rotation;
		}
		else if (parentFlg)
		{
			life = 0f;
			parentFlg = false;
		}
		Terrain activeTerrain = Terrain.activeTerrain;
		int layer = 0;
		if ((bool)activeTerrain)
		{
			fstTerCol = activeTerrain.collider.enabled;
			activeTerrain.collider.enabled = true;
			layer = activeTerrain.gameObject.layer;
			activeTerrain.gameObject.layer = 18;
		}
		Vector3 vector = tgtObj.position;
		Vector3 direction = vector - transform.position;
		float distance = 100f;
		RaycastHit hitInfo = default(RaycastHit);
		Rigidbody rigidbody = null;
		Ray ray = new Ray(transform.position, direction);
		bool flag = Physics.Raycast(ray, out hitInfo, distance, mask);
		if (!(life <= fadeTime))
		{
			if (flag)
			{
				vector = hitInfo.point;
				smkObj.position = vector;
				spkObj.position = vector;
				mltObj.position = vector;
				if (!smkObj.particleSystem.isPlaying)
				{
					smkObj.particleSystem.Play();
				}
				if (!spkObj.particleSystem.isPlaying)
				{
					spkObj.particleSystem.Play();
				}
				if (!mltObj.particleSystem.isPlaying)
				{
					mltObj.particleSystem.Play();
				}
			}
			else
			{
				if (smkObj.particleSystem.isPlaying)
				{
					smkObj.particleSystem.Stop();
				}
				if (spkObj.particleSystem.isPlaying)
				{
					spkObj.particleSystem.Stop();
				}
				if (mltObj.particleSystem.isPlaying)
				{
					mltObj.particleSystem.Stop();
				}
			}
		}
		else
		{
			if (flag)
			{
				vector = hitInfo.point;
				smkObj.position = vector;
				spkObj.position = vector;
				mltObj.position = vector;
			}
			if (smkObj.particleSystem.isPlaying)
			{
				smkObj.particleSystem.Stop();
			}
			if (spkObj.particleSystem.isPlaying)
			{
				spkObj.particleSystem.Stop();
			}
			if (mltObj.particleSystem.isPlaying)
			{
				mltObj.particleSystem.Stop();
			}
			if (flrObj.particleSystem.isPlaying)
			{
				flrObj.particleSystem.Stop();
			}
			float num = life / fadeTime;
			line.SetWidth(laserWidth * num, laserWidth * num);
		}
		line.SetPosition(0, transform.position);
		line.SetPosition(1, vector);
		if ((bool)activeTerrain)
		{
			activeTerrain.collider.enabled = fstTerCol;
			activeTerrain.gameObject.layer = layer;
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		if (activeMode)
		{
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(value: false);
			return;
		}
		Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public void End()
	{
		if (!(life <= fadeTime))
		{
			life = fadeTime;
		}
	}
}
