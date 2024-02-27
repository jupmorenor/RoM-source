using System;
using UnityEngine;

[Serializable]
public class Ef_AttachToCamera : Ef_Base
{
	public Transform target;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public bool posOnly;

	public bool nearestCam;

	public int retryCount;

	private float retryWait;

	private bool ofsPos;

	private bool ofsRot;

	private bool usePrnt;

	private Quaternion localRot;

	private Transform fstParent;

	private Vector3 fstPos;

	private Quaternion fstRot;

	private int fstRetCount;

	private bool ready;

	private bool end;

	public Ef_AttachToCamera()
	{
		offsetPos = Vector3.zero;
		offsetRot = Vector3.zero;
		retryCount = 10;
		retryWait = 1f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		target = null;
		retryCount = fstRetCount;
		retryWait = 1f;
		Attach();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Attach();
	}

	public void Init()
	{
		fstPos = transform.localPosition;
		fstRot = transform.localRotation;
		fstRetCount = retryCount;
		ofsPos = offsetPos != Vector3.zero;
		ofsRot = offsetRot != Vector3.zero;
		Transform parent = transform.parent;
		if (parent != null)
		{
			fstParent = parent;
			usePrnt = true;
		}
		if (!posOnly)
		{
			localRot = Quaternion.Euler(offsetRot);
		}
		ready = true;
	}

	public void Attach()
	{
		if (target == null)
		{
			target = GetTargetFromCamera();
		}
		if (target != null)
		{
			transform.parent = null;
		}
		end = false;
	}

	public Transform GetTargetFromCamera()
	{
		Transform transform = null;
		object result;
		if (!nearestCam)
		{
			if (!Camera.main)
			{
				result = null;
				goto IL_00be;
			}
			transform = Camera.main.transform;
		}
		else
		{
			Camera[] allCameras = Camera.allCameras;
			Vector3 position = this.transform.position;
			float num = 999999f;
			int i = 0;
			Camera[] array = allCameras;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				Vector3 position2 = array[i].transform.position;
				if (position2 != Vector3.zero)
				{
					float sqrMagnitude = (position2 - position).sqrMagnitude;
					if (!(sqrMagnitude >= num))
					{
						transform = array[i].transform;
						num = sqrMagnitude;
					}
				}
			}
		}
		result = transform;
		goto IL_00be;
		IL_00be:
		return (Transform)result;
	}

	public void LateUpdate()
	{
		if (usePrnt)
		{
			if (fstParent == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			if (!end && !fstParent.gameObject.activeInHierarchy)
			{
				target = null;
				transform.parent = fstParent;
				transform.localPosition = fstPos;
				transform.localRotation = fstRot;
				end = true;
				return;
			}
		}
		if (end)
		{
			return;
		}
		checked
		{
			if (target == null)
			{
				if (retryCount <= 0)
				{
					end = true;
					return;
				}
				retryWait -= deltaTime;
				if (retryWait > 0f)
				{
					return;
				}
				target = GetTargetFromCamera();
				if (!(target != null))
				{
					retryWait = 1f;
					retryCount--;
					return;
				}
				transform.parent = null;
			}
			if (ofsPos)
			{
				transform.position = target.position + target.rotation * offsetPos;
			}
			else
			{
				transform.position = target.position;
			}
			if (!posOnly)
			{
				if (ofsRot)
				{
					transform.rotation = target.rotation * localRot;
				}
				else
				{
					transform.rotation = target.rotation;
				}
			}
		}
	}
}
