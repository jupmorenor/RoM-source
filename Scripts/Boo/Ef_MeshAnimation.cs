using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MeshAnimation : Ef_Base
{
	public Mesh[] animMeshs;

	public float animSpd;

	public float minFps;

	public float maxFps;

	private int meshNum;

	private float animCount;

	private MeshFilter meshF;

	private Vector2 lstPos;

	private bool ready;

	public Ef_MeshAnimation()
	{
		animSpd = 1f;
		minFps = 3f;
		maxFps = 15f;
	}

	public void Start()
	{
		meshF = gameObject.GetComponent<MeshFilter>();
		if ((bool)meshF)
		{
			meshNum = animMeshs.Length;
			if (meshNum != 0)
			{
				Vector3 position = transform.position;
				lstPos = new Vector2(position[0], position[2]);
				ready = true;
			}
		}
	}

	public void Update()
	{
		if (!ready)
		{
			return;
		}
		float num;
		if (minFps != maxFps)
		{
			Vector3 position = transform.position;
			Vector2 vector = new Vector2(position[0], position[2]);
			float magnitude = (vector - lstPos).magnitude;
			lstPos = vector;
			num = animSpd * magnitude / deltaTime;
			if (!(num >= minFps))
			{
				num = minFps;
			}
			if (!(num <= maxFps))
			{
				num = maxFps;
			}
		}
		else
		{
			num = minFps;
		}
		animCount += num * deltaTime;
		MeshFilter meshFilter = meshF;
		Mesh[] array = animMeshs;
		meshFilter.sharedMesh = array[RuntimeServices.NormalizeArrayIndex(array, Mathf.FloorToInt(animCount % (float)meshNum))];
	}
}
