using System;
using UnityEngine;

[Serializable]
public class Ef_PushBoxObj : MonoBehaviour
{
	public Vector3 size;

	public Vector3 center;

	public bool useUpVector;

	public Transform scaleObj;

	public bool useCharcterController;

	private float left;

	private float right;

	private float top;

	private float bottom;

	private float front;

	private float back;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstScl;

	private float sqrRange;

	private Quaternion invRot;

	private bool useMov;

	private bool useRot;

	private bool useScl;

	public Ef_PushBoxObj()
	{
		size = Vector3.one;
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
		lstScl = scaleObj.localScale;
		ScaleChange();
	}

	public void ScaleChange()
	{
		Vector3 vector = default(Vector3);
		vector = ((!(scaleObj != null)) ? Vector3.one : scaleObj.localScale);
		left = (center.x - size.x / 2f) * vector.x;
		right = (center.x + size.x / 2f) * vector.x;
		top = (center.y + size.y / 2f) * vector.y;
		bottom = (center.y - size.y / 2f) * vector.y;
		front = (center.z + size.z / 2f) * vector.z;
		back = (center.z - size.z / 2f) * vector.z;
		float num = (Mathf.Abs(center.x) + size.x / 2f) * vector.x;
		float num2 = (Mathf.Abs(center.y) + size.y / 2f) * vector.y;
		float num3 = (Mathf.Abs(center.z) + size.z / 2f) * vector.z;
		sqrRange = num * num + num2 * num2 + num3 * num3;
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
		if (vector != lstScl)
		{
			useMov = true;
			useScl = true;
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
			Vector3 vector3 = position2 - position;
			float sqrMagnitude = vector3.sqrMagnitude;
			if (!(sqrMagnitude <= sqrRange))
			{
				continue;
			}
			vector3 = invRot * vector3;
			if (vector3.x < left || vector3.x > right || vector3.y > top || vector3.y < bottom || vector3.z > front || !(vector3.z >= back))
			{
				continue;
			}
			if (useMov)
			{
				if (useScl)
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
			float num = 9999999f;
			int num2 = 0;
			float num3 = default(float);
			num3 = vector3.x - left;
			if (!(num3 >= num))
			{
				num2 = 0;
				num = num3;
			}
			num3 = right - vector3.x;
			if (!(num3 >= num))
			{
				num2 = 1;
				num = num3;
			}
			num3 = top - vector3.y;
			if (!(num3 >= num))
			{
				num2 = 2;
				num = num3;
			}
			num3 = vector3.y - bottom;
			if (!(num3 >= num))
			{
				num2 = 3;
				num = num3;
			}
			num3 = front - vector3.z;
			if (!(num3 >= num))
			{
				num2 = 4;
				num = num3;
			}
			num3 = vector3.z - back;
			if (!(num3 >= num))
			{
				num2 = 5;
				num = num3;
			}
			switch (num2)
			{
			case 0:
				vector3.x = left - 0.001f;
				break;
			case 1:
				vector3.x = right + 0.001f;
				break;
			case 2:
				vector3.y = top - 0.002f;
				break;
			case 3:
				vector3.y = bottom - 0.001f;
				break;
			case 4:
				vector3.z = front - 0.001f;
				break;
			default:
				vector3.z = back + 0.001f;
				break;
			}
			vector3 = rotation * vector3;
			if (useCharcterController)
			{
				MerlinActionControl component = array[i].gameObject.GetComponent<MerlinActionControl>();
				CharacterController component2 = array[i].gameObject.GetComponent<CharacterController>();
				if (component2 != null && component2.enabled)
				{
					component2.Move(position + vector3 - position2);
				}
			}
			else
			{
				array[i].transform.position = position + vector3;
			}
		}
		useRot = false;
		useScl = false;
		useMov = false;
	}
}
