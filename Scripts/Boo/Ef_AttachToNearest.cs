using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_AttachToNearest : MonoBehaviour
{
	public Transform target;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public bool posOnly;

	public string[] paths;

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

	public Ef_AttachToNearest()
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

	public void Attach()
	{
		if (target == null)
		{
			target = FindNear();
		}
		if (target != null)
		{
			transform.parent = null;
		}
		end = false;
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

	public Transform FindNear()
	{
		Vector3 position = this.transform.position;
		Transform transform = null;
		float num = default(float);
		float num2 = 99999f;
		BaseControl baseControl = null;
		GameObject gameObject = null;
		int i = 0;
		BaseControl[] allControls = BaseControl.AllControls;
		for (int length = allControls.Length; i < length; i = checked(i + 1))
		{
			if (allControls[i] != null && allControls[i].IsAlive)
			{
				Vector3 vector = allControls[i].transform.position - position;
				if (vector == Vector3.zero)
				{
					vector = new Vector3(0f, 0f, 0.001f);
				}
				num = vector.sqrMagnitude;
				if (!(num >= num2))
				{
					baseControl = allControls[i];
					num2 = num;
				}
			}
		}
		object result;
		if (baseControl != null)
		{
			gameObject = baseControl.gameObject;
			MerlinMotionPackControl component = gameObject.GetComponent<MerlinMotionPackControl>();
			if (component == null)
			{
				result = null;
			}
			else
			{
				int length2 = paths.Length;
				if (length2 == 0)
				{
					result = null;
				}
				else
				{
					Animation motionTarget = component.motionTarget;
					if (motionTarget == null)
					{
						result = null;
					}
					else
					{
						GameObject gameObject2 = motionTarget.gameObject;
						int num3 = 0;
						int num4 = length2;
						if (num4 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (num3 < num4)
						{
							int index = num3;
							num3++;
							Transform obj = gameObject2.transform;
							string[] array = paths;
							transform = obj.Find(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
							if (transform != null)
							{
								break;
							}
						}
						result = ((!(transform == null)) ? transform : null);
					}
				}
			}
		}
		else
		{
			result = null;
		}
		return (Transform)result;
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
