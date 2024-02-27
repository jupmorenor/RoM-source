using System;
using UnityEngine;

[Serializable]
public class Ef_RigClavicle : MonoBehaviour
{
	[Serializable]
	public enum Axis
	{
		X,
		Y,
		Z
	}

	public Transform target;

	public Transform upVector;

	public Transform clavicle;

	public Transform parent;

	public Vector3 clavicleLocalRot;

	public Quaternion invSpineRot;

	public float maxDistanceRange;

	public float minDistanceRange;

	public float maxDistanceAng;

	public float minDistanceAng;

	public Axis distancePivot;

	public float maxPosRangeX;

	public float minPosRangeX;

	public float maxXPosAng;

	public float minXPosAng;

	public Axis xPosPivot;

	public float maxPosRangeY;

	public float minPosRangeY;

	public float maxYPosAng;

	public float minYPosAng;

	public Axis yPosPivot;

	public float maxPosRangeZ;

	public float minPosRangeZ;

	public float maxZposAng;

	public float minZposAng;

	public Axis zPosPivot;

	public float maxUpVectorY;

	public float minUpVectorY;

	public float maxUpVectorYAng;

	public float minUpVectorYAng;

	public Axis minUpVectorYPivot;

	public Quaternion fstParRot;

	private Quaternion fstClavicleRot;

	private float sqrMaxRange;

	private float sqrMinRange;

	public bool onLateUpdate;

	public Ef_RigClavicle()
	{
		maxDistanceRange = 8f;
		minDistanceRange = 1f;
		maxDistanceAng = 20f;
		distancePivot = Axis.Y;
		minPosRangeX = -1f;
		minXPosAng = -30f;
		xPosPivot = Axis.Y;
		maxPosRangeY = 8f;
		minPosRangeY = -5f;
		maxYPosAng = 30f;
		minYPosAng = -10f;
		yPosPivot = Axis.Z;
		maxPosRangeZ = 8f;
		maxZposAng = -30f;
		zPosPivot = Axis.Y;
		maxUpVectorY = 1f;
		minUpVectorY = -1f;
		maxUpVectorYAng = 20f;
		minUpVectorYAng = -20f;
		minUpVectorYPivot = Axis.X;
		onLateUpdate = true;
	}

	public void Start()
	{
		sqrMaxRange = maxDistanceRange * maxDistanceRange;
		sqrMinRange = minDistanceRange * minDistanceRange;
		fstClavicleRot = Quaternion.Euler(clavicleLocalRot);
	}

	public void Initialize()
	{
		if (!clavicle)
		{
			clavicle = transform;
		}
		if (!parent)
		{
			parent = clavicle.parent;
		}
		if ((bool)parent)
		{
			fstParRot = parent.rotation;
			clavicleLocalRot = clavicle.localEulerAngles;
			invSpineRot = Quaternion.Inverse(parent.rotation);
		}
		else
		{
			fstParRot = Quaternion.identity;
		}
	}

	public void Update()
	{
		if (!onLateUpdate)
		{
			UpdateClavicle();
		}
	}

	public void LateUpdate()
	{
		if (onLateUpdate)
		{
			UpdateClavicle();
		}
	}

	public void UpdateClavicle()
	{
		if (!target || !clavicle)
		{
			return;
		}
		Vector3 zero = Vector3.zero;
		Vector3 position = clavicle.position;
		Quaternion quaternion = default(Quaternion);
		quaternion = ((!parent) ? Quaternion.identity : parent.rotation);
		Quaternion quaternion2 = Quaternion.Inverse(invSpineRot * quaternion);
		Vector3 vector = quaternion2 * (target.position - position);
		float num = default(float);
		float num2 = default(float);
		float num3 = default(float);
		float sqrMagnitude = vector.sqrMagnitude;
		if (!(sqrMagnitude <= sqrMaxRange))
		{
			num2 = 1f;
		}
		else if (!(sqrMagnitude >= sqrMinRange))
		{
			num2 = 0f;
		}
		else
		{
			num3 = sqrMaxRange - sqrMinRange;
			num2 = ((num3 == 0f) ? 0f : ((sqrMagnitude - sqrMinRange) / num3));
		}
		num = Mathf.Lerp(maxDistanceAng, minDistanceAng, num2);
		if (distancePivot == Axis.X)
		{
			zero.x += num;
		}
		if (distancePivot == Axis.Y)
		{
			zero.y += num;
		}
		else
		{
			zero.z += num;
		}
		if (!(vector.x <= maxPosRangeX))
		{
			num2 = 1f;
		}
		else if (!(vector.x >= minPosRangeX))
		{
			num2 = 0f;
		}
		else
		{
			num3 = maxPosRangeX - minPosRangeX;
			num2 = ((num3 == 0f) ? 0f : ((vector.x - minPosRangeX) / num3));
		}
		num = Mathf.Lerp(minXPosAng, maxXPosAng, num2);
		if (xPosPivot == Axis.X)
		{
			zero.x += num;
		}
		else if (xPosPivot == Axis.Y)
		{
			zero.y += num;
		}
		else
		{
			zero.z += num;
		}
		if (!(vector.y <= maxPosRangeY))
		{
			num2 = 1f;
		}
		else if (!(vector.y >= minPosRangeY))
		{
			num2 = 0f;
		}
		else
		{
			num3 = maxPosRangeY - minPosRangeY;
			num2 = ((num3 == 0f) ? 0f : ((vector.y - minPosRangeY) / num3));
		}
		num = Mathf.Lerp(minYPosAng, maxYPosAng, num2);
		if (yPosPivot == Axis.X)
		{
			zero.x += num;
		}
		else if (yPosPivot == Axis.Y)
		{
			zero.y += num;
		}
		else
		{
			zero.z += num;
		}
		if (!(vector.z <= maxPosRangeZ))
		{
			num2 = 1f;
		}
		else if (!(vector.z >= minPosRangeZ))
		{
			num2 = 0f;
		}
		else
		{
			num3 = maxPosRangeZ - minPosRangeZ;
			num2 = ((num3 == 0f) ? 0f : ((vector.z - minPosRangeZ) / num3));
		}
		num = Mathf.Lerp(minZposAng, maxZposAng, num2);
		if (zPosPivot == Axis.X)
		{
			zero.x += num;
		}
		else if (zPosPivot == Axis.Y)
		{
			zero.y += num;
		}
		else
		{
			zero.z += num;
		}
		if ((bool)upVector)
		{
			Vector3 vector2 = quaternion2 * (upVector.position - position);
			if (!(vector2.y <= maxUpVectorY))
			{
				num2 = 1f;
			}
			else if (!(vector2.y >= minUpVectorY))
			{
				num2 = 0f;
			}
			else
			{
				num3 = maxUpVectorY - minUpVectorY;
				num2 = ((num3 == 0f) ? 0f : ((vector2.y - minUpVectorY) / num3));
			}
			num = Mathf.Lerp(minUpVectorYAng, maxUpVectorYAng, num2);
			if (minUpVectorYPivot == Axis.X)
			{
				zero.x += num;
			}
			else if (minUpVectorYPivot == Axis.Y)
			{
				zero.y += num;
			}
			else
			{
				zero.z += num;
			}
		}
		clavicle.localRotation = fstClavicleRot * Quaternion.Euler(zero);
	}
}
