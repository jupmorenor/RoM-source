using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_FindPuppet : Ef_Base
{
	public Transform target;

	public bool findSpine;

	public Vector3 localPos;

	public Vector3 localRot;

	public bool posOnly;

	public int retryCount;

	private Quaternion rot;

	private bool readyFind;

	private bool ready;

	private float retryWait;

	public Ef_FindPuppet()
	{
		findSpine = true;
		localPos = Vector3.zero;
		localRot = Vector3.zero;
		retryWait = 1f;
	}

	public void Start()
	{
		rot = Quaternion.Euler(localRot);
		ready = false;
		Find();
	}

	public void Find()
	{
		if ((bool)target)
		{
			ready = true;
			return;
		}
		GameObject[] array = null;
		array = GameObject.FindGameObjectsWithTag("Player");
		float num = 999f;
		int num2 = -1;
		int num3 = default(int);
		IEnumerator<int> enumerator = Builtins.range(array.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num3 = enumerator.Current;
				GameObject[] array2 = array;
				string text = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)].name.Substring(0, 1);
				if (text == "P" || text == "F")
				{
					GameObject[] array3 = array;
					float magnitude = (array3[RuntimeServices.NormalizeArrayIndex(array3, num3)].transform.position - this.transform.position).magnitude;
					if (!(magnitude >= num))
					{
						num2 = num3;
						num = magnitude;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (num2 != -1)
		{
			GameObject[] array4 = array;
			target = array4[RuntimeServices.NormalizeArrayIndex(array4, num2)].transform;
			if (findSpine)
			{
				MerlinMotionPackControl component = target.GetComponent<MerlinMotionPackControl>();
				if ((bool)component)
				{
					Animation motionTarget = component.motionTarget;
					if ((bool)motionTarget)
					{
						Transform transform = motionTarget.transform;
						if ((bool)transform)
						{
							target = transform;
							Transform transform2 = transform.Find("y_ang");
							if ((bool)transform2)
							{
								target = transform2;
								Transform transform3 = transform2.Find("cog");
								if ((bool)transform3)
								{
									target = transform3;
									Transform transform4 = transform3.Find("c_spine_a");
									if ((bool)transform4)
									{
										target = transform4;
									}
								}
							}
						}
					}
				}
			}
			ready = true;
		}
		else
		{
			Debug.Log("Not Root");
			readyFind = false;
		}
	}

	public void LateUpdate()
	{
		checked
		{
			if (!ready)
			{
				if (retryCount > 0)
				{
					retryWait -= deltaTime;
					if (!(retryWait > 0f))
					{
						Find();
						retryWait = 1f;
						retryCount--;
					}
				}
				else
				{
					if (!readyFind)
					{
					}
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			else if (!target)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			else
			{
				transform.position = target.position + target.rotation * localPos;
				if (!posOnly)
				{
					transform.rotation = target.rotation * rot;
				}
			}
		}
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
