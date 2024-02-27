using System;
using UnityEngine;

[Serializable]
public class Ef_ScaleFromDistance : MonoBehaviour
{
	[Serializable]
	public enum Axis
	{
		X,
		Y,
		Z,
		XY,
		XZ,
		YZ,
		XYZ
	}

	public Transform scaleObj;

	public Transform distanceObj;

	public Axis distanceAxis;

	public Axis scaleAxis;

	public float scaleRate;

	public bool useFirstScale;

	public bool world;

	public Vector3 maxScale;

	private Vector3 fstScl;

	private bool ready;

	public Ef_ScaleFromDistance()
	{
		distanceAxis = Axis.Z;
		scaleAxis = Axis.Z;
		scaleRate = 1f;
		world = true;
		maxScale = new Vector3(10f, 10f, 10f);
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (scaleObj != null)
		{
			scaleObj.localScale = fstScl;
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if ((bool)scaleObj && (bool)distanceObj)
		{
			fstScl = scaleObj.localScale;
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready || scaleObj == null || distanceObj == null)
		{
			return;
		}
		Vector3 vector = distanceObj.position - transform.position;
		if (!world)
		{
			vector = Quaternion.Inverse(transform.rotation) * vector;
		}
		float num = 0f;
		if (distanceAxis == Axis.XYZ)
		{
			num = vector.magnitude;
		}
		else if (distanceAxis == Axis.X)
		{
			num = vector.x;
		}
		else if (distanceAxis == Axis.Y)
		{
			num = vector.y;
		}
		else if (distanceAxis == Axis.Z)
		{
			num = vector.z;
		}
		else if (distanceAxis == Axis.XY)
		{
			vector.z = 0f;
			num = vector.magnitude;
		}
		else if (distanceAxis == Axis.XZ)
		{
			vector.y = 0f;
			num = vector.magnitude;
		}
		else
		{
			vector.x = 0f;
			num = vector.magnitude;
		}
		Vector3 vector2 = default(Vector3);
		if (scaleAxis == Axis.Z)
		{
			vector2 = scaleObj.localScale;
			if (useFirstScale)
			{
				vector2.z = fstScl.z * num;
			}
			else
			{
				vector2.z = num;
			}
		}
		else if (scaleAxis == Axis.Y)
		{
			vector2 = scaleObj.localScale;
			if (useFirstScale)
			{
				vector2.y = fstScl.y * num;
			}
			else
			{
				vector2.y = num;
			}
		}
		else if (scaleAxis != 0)
		{
			vector2 = ((scaleAxis == Axis.XYZ) ? ((!useFirstScale) ? new Vector3(num, num, num) : (fstScl * num)) : ((scaleAxis == Axis.YZ) ? ((!useFirstScale) ? new Vector3(fstScl.x, num, num) : new Vector3(fstScl.x, fstScl.y * num, fstScl.z * num)) : ((scaleAxis == Axis.XY) ? ((!useFirstScale) ? new Vector3(num, num, fstScl.z) : new Vector3(fstScl.x * num, fstScl.y * num, fstScl.z)) : ((!useFirstScale) ? new Vector3(num, fstScl.y, num) : new Vector3(fstScl.x * num, fstScl.y, fstScl.z * num)))));
		}
		else
		{
			vector2 = scaleObj.localScale;
			if (useFirstScale)
			{
				vector2.x = fstScl.x * num;
			}
			else
			{
				vector2.x = num;
			}
		}
		if (!(vector2.x <= maxScale.x))
		{
			vector2.x = maxScale.x;
		}
		if (!(vector2.y <= maxScale.y))
		{
			vector2.y = maxScale.y;
		}
		if (!(vector2.z <= maxScale.z))
		{
			vector2.z = maxScale.z;
		}
		scaleObj.localScale = vector2;
	}
}
