using System;
using UnityEngine;

[Serializable]
public class Ef_PushSphereObj : MonoBehaviour
{
	public float radius;

	public Vector3 center;

	public bool nonskid;

	public bool useUpVector;

	public Transform scaleObj;

	public bool useCharcterController;

	private float scale;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstScl;

	private bool useCenter;

	private bool useScale;

	private float sqrRange;

	private float sqrRadius;

	private Quaternion invRot;

	private bool useMov;

	private bool usePos;

	private bool useRot;

	public Ef_PushSphereObj()
	{
		radius = 0.5f;
		center = Vector3.zero;
		useUpVector = true;
	}

	public void Start()
	{
		lstPos = transform.position;
		lstRot = transform.rotation;
		if (scaleObj == null)
		{
			scaleObj = transform;
		}
		Vector3 localScale = scaleObj.localScale;
		scale = localScale.x;
		if (!(localScale.y <= scale))
		{
			scale = localScale.y;
		}
		if (!(localScale.z <= scale))
		{
			scale = localScale.z;
		}
		lstScl = localScale;
		useCenter = center != Vector3.zero;
		ScaleChange();
	}

	public void ScaleChange()
	{
		Vector3 vector = default(Vector3);
		vector = ((!(scaleObj != null)) ? Vector3.one : scaleObj.localScale);
		useScale = vector != Vector3.one;
		scale = vector.x;
		if (!(vector.y <= scale))
		{
			scale = vector.y;
		}
		if (!(vector.z <= scale))
		{
			scale = vector.z;
		}
		lstScl = vector;
		float num = radius * scale;
		sqrRadius = num * num;
		Vector3 vector2 = default(Vector3);
		if (useCenter)
		{
			vector2 = center.normalized * radius + center;
			if (useScale)
			{
				vector2 *= scale;
			}
			sqrRange = vector2.sqrMagnitude;
		}
		else
		{
			sqrRange = sqrRadius;
		}
	}

	public void Update()
	{
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		Vector3 vector = ((!(scaleObj != null)) ? Vector3.one : scaleObj.localScale);
		Vector3 vector2 = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		Vector3 b = default(Vector3);
		useMov = false;
		if (position != lstPos)
		{
			useMov = true;
			vector2 = invRot * (position - lstPos);
			lstPos = position;
		}
		if (rotation != lstRot)
		{
			useMov = true;
			useRot = true;
			quaternion = rotation * Quaternion.Inverse(lstRot);
			lstRot = rotation;
			invRot = Quaternion.Inverse(rotation);
		}
		bool flag = default(bool);
		if (vector != lstScl)
		{
			useMov = true;
			flag = true;
			if (lstScl.x != 0f)
			{
				b.x = vector.x / lstScl.x;
			}
			else
			{
				b.x = 1f;
			}
			if (lstScl.y != 0f)
			{
				b.y = vector.y / lstScl.y;
			}
			else
			{
				b.y = 1f;
			}
			if (lstScl.y != 0f)
			{
				b.y = vector.y / lstScl.y;
			}
			else
			{
				b.y = 1f;
			}
			lstScl = vector;
			ScaleChange();
		}
		BaseControl[] allControls = BaseControl.AllControls;
		int i = 0;
		BaseControl[] array = allControls;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			Vector3 position2 = array[i].transform.position;
			Vector3 vector3 = array[i].transform.position - position;
			float sqrMagnitude = vector3.sqrMagnitude;
			if (!(sqrMagnitude <= sqrRange))
			{
				continue;
			}
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			vector4 = ((!useCenter) ? position : (position + rotation * Vector3.Scale(center, vector)));
			sqrMagnitude = (position2 - vector4).sqrMagnitude;
			if (!(sqrMagnitude <= sqrRadius))
			{
				continue;
			}
			if (useMov)
			{
				if (flag)
				{
					vector3 = Vector3.Scale(vector3, b);
				}
				if (useRot)
				{
					vector3 = quaternion * vector3;
					Quaternion rotation2 = array[i].transform.rotation;
					rotation2 = quaternion * rotation2;
					if (useUpVector)
					{
						rotation2 = Quaternion.FromToRotation(rotation2 * Vector3.up, Vector3.up) * rotation2;
					}
					array[i].transform.rotation = rotation2;
				}
				vector3 += vector2;
			}
			Vector3 vector6 = position + vector3;
			vector5 = (position2 - vector4).normalized * (radius * scale - 0.001f);
			if (nonskid)
			{
				vector6.y = vector4.y + vector5.y;
			}
			else
			{
				vector6 = vector4 + vector5;
			}
			if (useCharcterController)
			{
				MerlinActionControl component = array[i].gameObject.GetComponent<MerlinActionControl>();
				if (component != null)
				{
					component.addVolatileMovement(vector6 - position2);
					float fixedDeltaTime = Time.fixedDeltaTime;
					Time.fixedDeltaTime = 0f;
					component.FixedUpdate();
					Time.fixedDeltaTime = fixedDeltaTime;
				}
			}
			else
			{
				array[i].transform.position = vector6;
			}
		}
		useRot = false;
		flag = false;
		useMov = false;
	}
}
