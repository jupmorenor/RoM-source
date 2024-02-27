using System;
using UnityEngine;

[Serializable]
public class Ef_Drain : Ef_Base
{
	public float life;

	public GameObject emitObj;

	public Transform emitPos;

	public Ef_Drain()
	{
		life = 1f;
	}

	public void Start()
	{
	}

	public void Update()
	{
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void OnDestroy()
	{
		if (!Ef_Base.isShuttingDown && (bool)emitObj && (bool)emitPos)
		{
			UnityEngine.Object.Instantiate(emitObj, emitPos.position, emitPos.rotation);
		}
	}
}
