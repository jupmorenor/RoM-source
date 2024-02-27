using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_FindPath : Ef_Base
{
	public Transform target;

	public bool usePuppetName;

	public bool useMMPCRootPath;

	public string[] findNames;

	public string[] paths;

	public Vector3 localPos;

	public Vector3 localRot;

	public bool posOnly;

	public int retryCount;

	private Quaternion rot;

	private bool readyFind;

	private bool ready;

	private float retryWait;

	public Ef_FindPath()
	{
		usePuppetName = true;
		useMMPCRootPath = true;
		localPos = Vector3.zero;
		localRot = Vector3.zero;
		retryWait = 1f;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (usePuppetName)
		{
			findNames = new string[1];
			findNames[0] = mpets.PrefabName;
		}
	}

	public void Start()
	{
		rot = Quaternion.Euler(localRot);
		ready = false;
		Find();
	}

	public void Find()
	{
		rot = Quaternion.Euler(localRot);
		if ((bool)target)
		{
			ready = true;
			return;
		}
		GameObject gameObject = null;
		int num = default(int);
		int num2 = default(int);
		num2 = findNames.Length;
		if (num2 > 0)
		{
			if (findNames[0] == "Player")
			{
				PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
				if (!currentPlayer || !currentPlayer.IsReady)
				{
					return;
				}
				gameObject = ((!currentPlayer.IsTensi) ? currentPlayer.akumaModel : currentPlayer.tensiModel);
			}
			else if (findNames[0] == "MainCamera")
			{
				if ((bool)Camera.main)
				{
					gameObject = Camera.main.gameObject;
					readyFind = true;
				}
			}
			else
			{
				float num3 = default(float);
				float num4 = 999f;
				BaseControl baseControl = null;
				IEnumerator<int> enumerator = Builtins.range(num2).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						string[] array = findNames;
						string text = array[RuntimeServices.NormalizeArrayIndex(array, num)];
						int num5 = default(int);
						int i = 0;
						BaseControl[] allControls = BaseControl.AllControls;
						for (int length = allControls.Length; i < length; i = checked(i + 1))
						{
							if (allControls[i].gameObject.name == text || allControls[i].gameObject.name == text + "(Clone)")
							{
								Vector3 vector = allControls[i].transform.position - transform.position;
								if (vector == Vector3.zero)
								{
									vector = new Vector3(0f, 0f, 0.01f);
								}
								num3 = vector.magnitude;
								if (!(num3 >= num4))
								{
									num4 = num3;
									baseControl = allControls[i];
								}
							}
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				if (baseControl != null)
				{
					gameObject = baseControl.gameObject;
					readyFind = true;
				}
				else
				{
					IEnumerator<int> enumerator2 = Builtins.range(num2).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							num = enumerator2.Current;
							string[] array2 = findNames;
							GameObject gameObject2 = GameObject.Find(array2[RuntimeServices.NormalizeArrayIndex(array2, num)]);
							if ((bool)gameObject2)
							{
								gameObject = gameObject2;
								readyFind = true;
								break;
							}
						}
					}
					finally
					{
						enumerator2.Dispose();
					}
				}
			}
		}
		if (!gameObject)
		{
			readyFind = false;
			return;
		}
		num2 = paths.Length;
		if (num2 > 0)
		{
			if (useMMPCRootPath)
			{
				MerlinMotionPackControl component = gameObject.GetComponent<MerlinMotionPackControl>();
				if (component != null)
				{
					Animation motionTarget = component.motionTarget;
					if ((bool)motionTarget)
					{
						gameObject = motionTarget.gameObject;
					}
				}
			}
			IEnumerator<int> enumerator3 = Builtins.range(num2).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					num = enumerator3.Current;
					Transform obj = gameObject.transform;
					string[] array3 = paths;
					target = obj.Find(array3[RuntimeServices.NormalizeArrayIndex(array3, num)]);
					if ((bool)target)
					{
						break;
					}
				}
			}
			finally
			{
				enumerator3.Dispose();
			}
			if (!target)
			{
				return;
			}
		}
		else
		{
			target = gameObject.transform;
		}
		ready = true;
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
