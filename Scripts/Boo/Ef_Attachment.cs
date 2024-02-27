using System;
using UnityEngine;

[Serializable]
public class Ef_Attachment : Ef_Base
{
	public Transform target;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public bool posOnly;

	private bool activeMode;

	private bool ofsPos;

	private bool ofsRot;

	private bool usePrnt;

	private Quaternion localRot;

	private Transform fstParent;

	private Vector3 fstPos;

	private Quaternion fstRot;

	private Transform fstTrg;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private bool ready;

	private bool end;

	public Ef_Attachment()
	{
		offsetPos = Vector3.zero;
		offsetRot = Vector3.zero;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		target = fstTrg;
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
		fstPos = transform.localPosition;
		fstRot = transform.localRotation;
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
		fstTrg = target;
		Ef_ActiveOn component = gameObject.GetComponent<Ef_ActiveOn>();
		bool num = component != null;
		if (num)
		{
			num = component.enable;
		}
		activeMode = num;
		ready = true;
	}

	public void Update()
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
		if (target == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		Vector3 position = target.position;
		Quaternion rotation = target.rotation;
		if (position != lstPos)
		{
			if (ofsPos)
			{
				transform.position = position + rotation * offsetPos;
			}
			else
			{
				transform.position = position;
			}
			lstPos = position;
		}
		if (!posOnly && rotation != lstRot)
		{
			if (ofsRot)
			{
				transform.rotation = rotation * localRot;
			}
			else
			{
				transform.rotation = rotation;
			}
			lstRot = rotation;
		}
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
		if (target == null)
		{
			if (activeMode)
			{
				gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
				gameObject.SetActive(value: false);
				return;
			}
			Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
			if (component != null)
			{
				component.Release();
			}
			else
			{
				Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
				if (component2 != null)
				{
					component2.Release();
				}
			}
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		Vector3 position = target.position;
		Quaternion rotation = target.rotation;
		if (position != lstPos)
		{
			if (ofsPos)
			{
				transform.position = position + rotation * offsetPos;
			}
			else
			{
				transform.position = position;
			}
			lstPos = position;
		}
		if (!posOnly && rotation != lstRot)
		{
			if (ofsRot)
			{
				transform.rotation = rotation * localRot;
			}
			else
			{
				transform.rotation = rotation;
			}
			lstRot = rotation;
		}
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
		if (target != null)
		{
			transform.parent = null;
		}
	}
}
