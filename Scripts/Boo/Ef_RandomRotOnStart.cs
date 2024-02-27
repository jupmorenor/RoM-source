using System;
using UnityEngine;

[Serializable]
public class Ef_RandomRotOnStart : MonoBehaviour
{
	public Transform[] rotObjs;

	public float maxX;

	public float minX;

	public float maxY;

	public float minY;

	public float maxZ;

	public float minZ;

	public bool offsetRot;

	public bool worldRot;

	private bool ready;

	public Ef_RandomRotOnStart()
	{
		offsetRot = true;
		worldRot = true;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		Rotation();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Rotation();
	}

	public void Init()
	{
		if (rotObjs.Length == 0)
		{
			rotObjs = new Transform[1];
			rotObjs[0] = transform;
		}
		ready = true;
	}

	public void Rotation()
	{
		int i = 0;
		Transform[] array = rotObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				Quaternion quaternion = Quaternion.Euler(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), UnityEngine.Random.Range(minZ, maxZ));
				if (offsetRot)
				{
					quaternion = ((!worldRot) ? (array[i].localRotation * quaternion) : (array[i].rotation * quaternion));
				}
				if (worldRot)
				{
					array[i].rotation = quaternion;
				}
				else
				{
					array[i].localRotation = quaternion;
				}
			}
		}
	}
}
