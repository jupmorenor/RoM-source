using System;
using UnityEngine;

[Serializable]
public class Ef_CameraCullingMask : Ef_Base
{
	public string layerName;

	public float life;

	public int backUpMask;

	private bool ready;

	public Ef_CameraCullingMask()
	{
		layerName = "ScreenMask";
		life = 10f;
	}

	public void Start()
	{
		if ((bool)Camera.main)
		{
			backUpMask = Camera.main.cullingMask;
			LayerMask layerMask = 1 << LayerMask.NameToLayer(layerName);
			Camera.main.cullingMask = layerMask.value;
			ready = true;
		}
	}

	public void Update()
	{
		if (ready)
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				Camera.main.cullingMask = backUpMask;
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnDestroy()
	{
		if (ready && !(Camera.main == null))
		{
			Camera.main.cullingMask = backUpMask;
		}
	}
}
