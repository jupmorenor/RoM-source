using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SM_prefabGenerator : Ef_Base_Js
{
	public GameObject[] createThis;

	private float rndNr;

	public int thisManyTimes;

	public float overThisTime;

	public float xWidth;

	public float yWidth;

	public float zWidth;

	public float xRotMax;

	public float yRotMax;

	public float zRotMax;

	public bool allUseSameRotation;

	private bool allRotationDecided;

	public bool detachToWorld;

	private float x_cur;

	private float y_cur;

	private float z_cur;

	private float xRotCur;

	private float yRotCur;

	private float zRotCur;

	private float timeCounter;

	private int effectCounter;

	private float trigger;

	public SM_prefabGenerator()
	{
		thisManyTimes = 3;
		overThisTime = 1f;
		yRotMax = 180f;
		detachToWorld = true;
	}

	public virtual void Start()
	{
		if (thisManyTimes < 1)
		{
			thisManyTimes = 1;
		}
		trigger = overThisTime / (float)thisManyTimes;
	}

	public virtual void Update()
	{
		timeCounter += deltaTime;
		if (!(timeCounter <= trigger) && effectCounter <= thisManyTimes)
		{
			rndNr = Mathf.Floor(UnityEngine.Random.value * (float)Extensions.get_length((Array)createThis));
			x_cur = transform.position.x + UnityEngine.Random.value * xWidth - xWidth * 0.5f;
			y_cur = transform.position.y + UnityEngine.Random.value * yWidth - yWidth * 0.5f;
			z_cur = transform.position.z + UnityEngine.Random.value * zWidth - zWidth * 0.5f;
			if (!allUseSameRotation || !allRotationDecided)
			{
				xRotCur = transform.rotation.x + UnityEngine.Random.value * xRotMax * 2f - xRotMax;
				yRotCur = transform.rotation.y + UnityEngine.Random.value * yRotMax * 2f - yRotMax;
				zRotCur = transform.rotation.z + UnityEngine.Random.value * zRotMax * 2f - zRotMax;
				allRotationDecided = true;
			}
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(createThis[(int)rndNr], new Vector3(x_cur, y_cur, z_cur), transform.rotation);
			gameObject.transform.Rotate(xRotCur, yRotCur, zRotCur);
			if (!detachToWorld)
			{
				gameObject.transform.parent = transform;
			}
			timeCounter -= trigger;
			effectCounter++;
		}
	}
}
