using System;
using UnityEngine;

[Serializable]
public class SM_randomMMoveInBox : Ef_Base_Js
{
	public float xspeed;

	public float yspeed;

	public float zspeed;

	public float speedDeviation;

	public float xDim;

	public float yDim;

	public float zDim;

	public SM_randomMMoveInBox()
	{
		xspeed = 1f;
		yspeed = 1.5f;
		zspeed = 2f;
		xDim = 0.3f;
		yDim = 0.3f;
		zDim = 0.3f;
	}

	public virtual void Start()
	{
		transform.localPosition = new Vector3(0f, 0f, 0f);
		xspeed += (float)UnityEngine.Random.Range(-1, 1) * speedDeviation;
		yspeed += (float)UnityEngine.Random.Range(-1, 1) * speedDeviation;
		zspeed += (float)UnityEngine.Random.Range(-1, 1) * speedDeviation;
	}

	public virtual void Update()
	{
		transform.Translate(new Vector3(xspeed, yspeed, zspeed) * deltaTime);
		if (!(transform.localPosition.x <= xDim))
		{
			xspeed = 0f - Mathf.Abs(xspeed);
		}
		if (!(transform.localPosition.x >= 0f - xDim))
		{
			xspeed = Mathf.Abs(xspeed);
		}
		if (!(transform.localPosition.y <= yDim))
		{
			yspeed = 0f - Mathf.Abs(yspeed);
		}
		if (!(transform.localPosition.y >= 0f - yDim))
		{
			yspeed = Mathf.Abs(yspeed);
		}
		if (!(transform.localPosition.z <= zDim))
		{
			zspeed = 0f - Mathf.Abs(zspeed);
		}
		if (!(transform.localPosition.z >= 0f - zDim))
		{
			zspeed = Mathf.Abs(zspeed);
		}
	}
}
