using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_AttachToPlayer : Ef_Base
{
	public Transform target;

	public Vector3 offsetPos;

	public Vector3 offsetRot;

	public bool posOnly;

	public string[] paths;

	public int retryCount;

	private bool ofsPos;

	private bool ofsRot;

	private Quaternion localRot;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private bool ready;

	private float retryWait;

	public Ef_AttachToPlayer()
	{
		offsetPos = Vector3.zero;
		offsetRot = Vector3.zero;
		retryCount = 10;
		retryWait = 1f;
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
		ofsPos = offsetPos != Vector3.zero;
		ofsRot = offsetRot != Vector3.zero;
		if (!posOnly)
		{
			localRot = Quaternion.Euler(offsetRot);
		}
		GameObject gameObject = FindPlayer();
		if ((bool)gameObject)
		{
			target = GetTargetFromPath(gameObject);
		}
		if ((bool)target)
		{
			ready = true;
		}
	}

	public void Update()
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
						GameObject gameObject = FindPlayer();
						if ((bool)gameObject)
						{
							target = GetTargetFromPath(gameObject);
						}
						if ((bool)target)
						{
							ready = true;
						}
						retryWait = 1f;
						retryCount--;
					}
				}
				else
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
				return;
			}
			if (target == null)
			{
				UnityEngine.Object.Destroy(this.gameObject);
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
						GameObject gameObject = FindPlayer();
						if ((bool)gameObject)
						{
							target = GetTargetFromPath(gameObject);
						}
						if ((bool)target)
						{
							ready = true;
						}
						retryWait = 1f;
						retryCount--;
					}
				}
				else
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
				return;
			}
			if (target == null)
			{
				UnityEngine.Object.Destroy(this.gameObject);
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
	}

	public GameObject FindPlayer()
	{
		GameObject gameObject = null;
		PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
		object result;
		if (!currentPlayer || !currentPlayer.IsReady)
		{
			result = null;
		}
		else
		{
			gameObject = ((!currentPlayer.IsTensi) ? currentPlayer.akumaModel : currentPlayer.tensiModel);
			result = gameObject;
		}
		return (GameObject)result;
	}

	public Transform GetTargetFromPath(GameObject gameObj)
	{
		Transform transform = null;
		int length = paths.Length;
		object result;
		if (length == 0)
		{
			result = null;
		}
		else
		{
			int num = default(int);
			IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					Transform obj = gameObj.transform;
					string[] array = paths;
					transform = obj.Find(array[RuntimeServices.NormalizeArrayIndex(array, num)]);
					if ((bool)transform)
					{
						break;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = (transform ? transform : null);
		}
		return (Transform)result;
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
