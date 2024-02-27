using System;
using UnityEngine;

[Serializable]
public class RaidBossTerritory : MonoBehaviour
{
	public float territoryRadius;

	public Transform target;

	private CharacterController charCont;

	public RaidBossTerritory()
	{
		territoryRadius = 19f;
	}

	public static void Constraint(GameObject go, GameObject target, float radius)
	{
		if (!(go == null))
		{
			RaidBossTerritory raidBossTerritory = go.AddComponent<RaidBossTerritory>();
			raidBossTerritory.territoryRadius = radius;
			if (target != null)
			{
				raidBossTerritory.target = target.transform;
			}
		}
	}

	public void Start()
	{
		charCont = gameObject.GetComponent<CharacterController>();
	}

	public void FixedUpdate()
	{
		if (target == null)
		{
			return;
		}
		Vector3 vector = transform.position - target.position;
		vector.y = 0f;
		float magnitude = vector.magnitude;
		vector = vector.normalized;
		if (!(magnitude >= territoryRadius))
		{
			float num = territoryRadius - magnitude;
			Vector3 vector2 = vector * num;
			if (charCont != null)
			{
				charCont.Move(vector2);
			}
			else
			{
				transform.position += vector2;
			}
		}
	}
}
