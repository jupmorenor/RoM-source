using System;
using UnityEngine;

[Serializable]
public class Ef_DeactiveTimer : Ef_Base
{
	public bool sleep;

	public float life;

	public Transform releaseParent;

	private Vector3 fstPos;

	private Quaternion fstRot;

	private float fstLife;

	private bool ready;

	private bool child;

	public Ef_DeactiveTimer()
	{
		life = 1f;
	}

	public void SetLife(float inLife)
	{
		life = inLife;
		fstLife = inLife;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		EndAndNext();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Initialize()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (!ready)
		{
			fstLife = life;
			if ((bool)releaseParent)
			{
				child = true;
				fstPos = transform.localPosition;
				fstRot = transform.localRotation;
			}
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		if (sleep)
		{
			return;
		}
		if (!(life > 0f))
		{
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			EndAndNext();
			if (!releaseParent)
			{
				gameObject.SetActive(value: false);
			}
		}
		life -= deltaTime;
	}

	public void EndAndNext()
	{
		if ((bool)releaseParent)
		{
			transform.parent = releaseParent;
			transform.localPosition = fstPos;
			transform.localRotation = fstRot;
			sleep = true;
		}
		life = fstLife;
	}
}
