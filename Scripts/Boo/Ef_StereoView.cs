using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_StereoView : Ef_Base
{
	public bool nearestCam;

	public float distanceX;

	private Transform target;

	private GameObject camObj2;

	private Camera trgCam;

	private Vector3 offsetPos;

	private int fstMask;

	private float wait;

	private bool end;

	public Ef_StereoView()
	{
		distanceX = 1f;
		wait = 1f;
	}

	public void OnActive()
	{
		end = false;
		wait = 1f;
		Attach();
	}

	public void OnDeactive()
	{
		if (trgCam != null)
		{
			trgCam.cullingMask = fstMask;
		}
	}

	public void Start()
	{
		Attach();
	}

	public void Update()
	{
		if (!end)
		{
			wait -= deltaTime;
			if (!(wait > 0f))
			{
				Attach();
				wait = 1f;
			}
		}
	}

	public void Attach()
	{
		object[] targetFromCamera = GetTargetFromCamera();
		object obj = targetFromCamera[0];
		if (!(obj is Transform))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Transform));
		}
		target = (Transform)obj;
		object obj2 = targetFromCamera[1];
		if (!(obj2 is Camera))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Camera));
		}
		trgCam = (Camera)obj2;
		if (target != null && trgCam != null)
		{
			Rect rect = trgCam.rect;
			Camera camera = gameObject.GetComponent<Camera>();
			if (camera == null)
			{
				camera = gameObject.AddComponent<Camera>();
			}
			camera.CopyFrom(trgCam);
			if (camObj2 == null)
			{
				camObj2 = new GameObject(gameObject.name + "2");
			}
			else
			{
				camObj2.SetActive(value: true);
			}
			Camera camera2 = camObj2.GetComponent<Camera>();
			if (camera2 == null)
			{
				camera2 = camObj2.AddComponent<Camera>();
			}
			camera2.CopyFrom(trgCam);
			camera.rect = new Rect(rect.x, rect.y, rect.width / 2f, rect.height);
			camera2.rect = new Rect(rect.x + rect.width / 2f, rect.y, rect.width / 2f, rect.height);
			offsetPos = new Vector3((0f - distanceX) / 2f, 0f, 0f);
			camObj2.transform.parent = transform;
			camObj2.transform.localPosition = new Vector3(distanceX, 0f, 0f);
			camObj2.transform.localRotation = Quaternion.identity;
			fstMask = trgCam.cullingMask;
			trgCam.cullingMask = 0;
			end = true;
		}
	}

	public void LateUpdate()
	{
		if (target != null)
		{
			transform.position = target.position + target.rotation * offsetPos;
		}
	}

	public object[] GetTargetFromCamera()
	{
		Transform transform = null;
		Camera camera = null;
		object result;
		if (!nearestCam)
		{
			if (!Camera.main)
			{
				result = new object[2];
				goto IL_00dd;
			}
			camera = Camera.main;
			transform = camera.transform;
		}
		else
		{
			Camera[] allCameras = Camera.allCameras;
			Vector3 position = this.transform.position;
			float num = float.PositiveInfinity;
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
						camera = array[i];
						transform = array[i].transform;
						num = sqrMagnitude;
					}
				}
			}
		}
		result = new Component[2] { transform, camera };
		goto IL_00dd;
		IL_00dd:
		return (object[])result;
	}

	public void OnDestroy()
	{
		if (trgCam != null)
		{
			trgCam.cullingMask = fstMask;
		}
	}
}
