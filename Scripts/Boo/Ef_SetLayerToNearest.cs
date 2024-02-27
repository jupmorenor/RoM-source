using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetLayerToNearest : MonoBehaviour
{
	public Transform target;

	public string[] paths;

	public string layerName;

	public bool restoreOnEnd;

	private int fstLayer;

	public Ef_SetLayerToNearest()
	{
		layerName = "CHR";
		restoreOnEnd = true;
	}

	public void OnActive()
	{
		target = null;
		SetLayer();
	}

	public void OnDeactive()
	{
		if (restoreOnEnd && target != null)
		{
			target.gameObject.layer = fstLayer;
		}
	}

	public void Start()
	{
		SetLayer();
	}

	public void SetLayer()
	{
		if (target == null)
		{
			target = FindNear();
		}
		if (!(target == null))
		{
			fstLayer = target.gameObject.layer;
			target.gameObject.layer = LayerMask.NameToLayer(layerName);
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
							string[] array = paths;
							if (array[RuntimeServices.NormalizeArrayIndex(array, index)] != "POLY")
							{
								Transform obj = gameObject2.transform;
								string[] array2 = paths;
								transform = obj.Find(array2[RuntimeServices.NormalizeArrayIndex(array2, index)]);
							}
							else
							{
								transform = gameObject2.transform.Find("y_ang/poly");
								if (transform != null)
								{
									int childCount = transform.childCount;
									if (childCount > 0)
									{
										transform = transform.GetChild(0);
									}
								}
							}
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

	public void OnDestroy()
	{
		if (restoreOnEnd && target != null)
		{
			target.gameObject.layer = fstLayer;
		}
	}
}
