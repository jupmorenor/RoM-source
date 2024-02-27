using System;
using UnityEngine;

[Serializable]
public class Ef_Laser : Ef_Base
{
	public Transform tgtObj;

	public Transform smkObj;

	public Transform spkObj;

	public Transform mltObj;

	public Transform flrObj;

	public float laserWidth;

	public float life;

	public float endTime;

	public Transform parentObj;

	public int mask;

	private bool end;

	private LineRenderer line;

	private bool parentFlg;

	private Vector3 fstPos;

	private bool fstTerCol;

	public Ef_Laser()
	{
		laserWidth = 2f;
		life = 5f;
		endTime = 1f;
		mask = -33284096;
		fstPos = Vector3.zero;
	}

	public void Start()
	{
		if (!tgtObj)
		{
			tgtObj = transform.Find("Ef_Laser_Target");
		}
		if (!smkObj)
		{
			smkObj = transform.Find("Ef_Laser_Smoke");
		}
		if (!spkObj)
		{
			spkObj = transform.Find("Ef_Laser_Spark");
		}
		if (!mltObj)
		{
			mltObj = transform.Find("Ef_Laser_Melt");
		}
		if (!flrObj)
		{
			flrObj = transform.Find("Ef_Laser_Flare");
		}
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
		}
		transform.parent = null;
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
		if (!end)
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
			endTime -= deltaTime;
			if (!(endTime >= 0f))
			{
				endTime = 0f;
			}
			line.SetWidth(laserWidth * endTime, laserWidth * endTime);
			if (endTime == 0f)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		line.SetPosition(0, transform.position);
		line.SetPosition(1, vector);
		if ((bool)activeTerrain)
		{
			activeTerrain.collider.enabled = fstTerCol;
			activeTerrain.gameObject.layer = layer;
		}
		life -= deltaTime;
		if (!(life > 0f))
		{
			End();
		}
	}

	public void End()
	{
		end = true;
	}
}
