using System;
using UnityEngine;

[Serializable]
public class Ef_DeactiveScale : Ef_Base
{
	public bool sleep;

	public Transform scaleObj;

	public float life;

	public float fadeTime;

	public Transform releaseParent;

	private float fstLife;

	private Vector3 fstScale;

	private Vector3 fstPos;

	private Quaternion fstRot;

	private bool ready;

	private int timeZero;

	public Ef_DeactiveScale()
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
			if (fadeTime == 0f)
			{
				fadeTime = life;
			}
			if (!scaleObj)
			{
				scaleObj = transform;
			}
			fstScale = scaleObj.localScale;
			if ((bool)releaseParent)
			{
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
		if (!(life <= 0f))
		{
			if (!(life >= fadeTime))
			{
				float num = life / fadeTime;
				scaleObj.localScale = fstScale * num;
			}
		}
		else
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
		scaleObj.localScale = fstScale;
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
