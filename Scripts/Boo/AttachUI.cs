using System;
using ObjUtil;
using UnityEngine;

[Serializable]
public class AttachUI : MonoBehaviour
{
	public Transform target;

	protected readonly float DRAW_OFFSET_X;

	protected readonly float DRAW_OFFSET_Y;

	public float offsetX;

	public float offsetY;

	public float offsetZ;

	public Vector3 offset3D;

	public Vector3 Offset
	{
		get
		{
			return new Vector3(offsetX, offsetY, offsetZ);
		}
		set
		{
			offsetX = value.x;
			offsetY = value.y;
			offsetZ = value.z;
		}
	}

	public AttachUI()
	{
		DRAW_OFFSET_X = -50f;
	}

	public void Awake()
	{
		offsetX = DRAW_OFFSET_X;
		offsetY = DRAW_OFFSET_Y;
		offset3D = Vector3.zero;
	}

	public void LateUpdate()
	{
		if (!(target == null) && !(Camera.main == null))
		{
			Vector3 pos = target.position + offset3D;
			pos = ObjUtilModule.GetScreenPostion(transform, pos, Camera.main);
			pos.x -= offsetX;
			pos.y -= offsetY;
			pos.z = 0f - target.position.z - offsetZ;
			transform.localPosition = pos;
		}
	}

	public void setOffsetXY(float x, float y, float z)
	{
		offsetX = x;
		offsetY = y;
		offsetZ = z;
	}
}
