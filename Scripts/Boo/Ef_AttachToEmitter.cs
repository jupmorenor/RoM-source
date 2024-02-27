using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_AttachToEmitter : MonoBehaviour
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

	private bool reserve;

	public Ef_AttachToEmitter()
	{
		offsetPos = Vector3.zero;
		offsetRot = Vector3.zero;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!ready)
		{
			Init();
		}
		reserve = true;
		if (!(emtr == null))
		{
			if (target == null)
			{
				target = GetTargetFromPath(emtr.gameObject);
			}
			if (target != null)
			{
				transform.parent = null;
			}
			end = false;
		}
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		target = fstTrg;
		reserve = false;
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
			if (!reserve)
			{
			}
			end = true;
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

	public Transform GetTargetFromPath(GameObject gameObj)
	{
		Transform transform = null;
		MerlinMotionPackControl component = gameObj.GetComponent<MerlinMotionPackControl>();
		object result;
		if (!component)
		{
			result = null;
		}
		else
		{
			int length = paths.Length;
			if (length == 0)
			{
				result = null;
			}
			else
			{
				Animation motionTarget = component.motionTarget;
				if (!motionTarget)
				{
					result = null;
				}
				else
				{
					GameObject gameObject = motionTarget.gameObject;
					int num = 0;
					int num2 = length;
					if (num2 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					while (num < num2)
					{
						int index = num;
						num++;
						Transform obj = gameObject.transform;
						string[] array = paths;
						transform = obj.Find(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
						if ((bool)transform)
						{
							break;
						}
					}
					result = (transform ? transform : null);
				}
			}
		}
		return (Transform)result;
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
