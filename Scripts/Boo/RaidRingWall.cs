using System;
using UnityEngine;

[Serializable]
public class RaidRingWall : MonoBehaviour
{
	public float RingRadius;

	private CharacterController charCont;

	public RaidRingWall()
	{
		RingRadius = 19f;
	}

	public static void Constraint(GameObject go)
	{
		if (!(go == null))
		{
			ExtensionsModule.SetComponent<RaidRingWall>(go);
		}
	}

	public static void Constraint(GameObject go, float radius)
	{
		if (!(go == null))
		{
			RaidRingWall raidRingWall = ExtensionsModule.SetComponent<RaidRingWall>(go);
			raidRingWall.RingRadius = radius;
		}
	}

	public void Start()
	{
		charCont = gameObject.GetComponent<CharacterController>();
	}

	public void FixedUpdate()
	{
		Vector3 position = transform.position;
		position.y = 0f;
		Vector3 normalized = position.normalized;
		float magnitude = position.magnitude;
		if (!(magnitude <= RingRadius))
		{
			float num = magnitude - RingRadius;
			Vector3 vector = -normalized * num;
			if (charCont != null)
			{
				charCont.Move(vector);
			}
			else
			{
				transform.position += vector;
			}
		}
	}
}
