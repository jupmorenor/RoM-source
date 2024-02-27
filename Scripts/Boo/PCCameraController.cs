using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[AddComponentMenu("Camera-Control/PC Camera Control")]
public class PCCameraController : BasicCamera
{
	public string optionalTagForSelection;

	public float BaseDist;

	public Vector3 BasePos;

	public float 回転速度;

	public float 移動速度;

	public float ズーム速度;

	private Material materialForSelection;

	private List selectedObjects;

	private List selectedObjectsMaterial;

	private GameObject orbitVector;

	private float distToOrbit;

	private float x;

	private float y;

	public float orbitSpeed
	{
		get
		{
			return 回転速度;
		}
		set
		{
			回転速度 = value;
		}
	}

	public float panSpeed
	{
		get
		{
			return 移動速度;
		}
		set
		{
			移動速度 = value;
		}
	}

	public float zoomSpeed
	{
		get
		{
			return ズーム速度;
		}
		set
		{
			ズーム速度 = value;
		}
	}

	public PCCameraController()
	{
		optionalTagForSelection = "entity";
		BaseDist = 5f;
		BasePos = new Vector3(0f, 2.5f, 7.5f);
		回転速度 = 10f;
		移動速度 = 5f;
		ズーム速度 = 5f;
		selectedObjects = new List();
		selectedObjectsMaterial = new List();
	}

	public void Start()
	{
		orbitVector = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		orbitVector.renderer.enabled = false;
		orbitVector.name = "Camera LookAt (Dammy)";
		resetCamera();
		materialForSelection = new Material(Shader.Find("Transparent/Specular"));
		materialForSelection.color = new Color(0f, 0.25f, 0.25f, 0.3f);
	}

	public void LateUpdate()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");
		if (modifierKeyPressed())
		{
			distToOrbit = Vector3.Distance(transform.position, orbitVector.transform.position);
			if (zoomKeyPressed())
			{
				zoom(distToOrbit);
			}
			else if (orbitKeyPressed())
			{
				orbit(distToOrbit);
			}
			else if (panKeyPressed())
			{
				pan(distToOrbit);
			}
		}
		else if (selectPressed())
		{
			select();
		}
		else if (frameSelectionPressed())
		{
			frameSelection();
		}
		else if (resetPressed())
		{
			resetCamera();
		}
	}

	public void zoom(float distToOrbit)
	{
		float num = Mathf.Clamp(zoomSpeed * (distToOrbit / 100f), 0.1f, 2f);
		transform.Translate(Vector3.forward * (x * num));
		if (!(Vector3.Distance(transform.position, orbitVector.transform.position) >= 3f))
		{
			orbitVector.transform.Translate(Vector3.forward, transform);
		}
	}

	public void orbit(float distToOrbit)
	{
		float num = Mathf.Clamp(orbitSpeed * (Mathf.Log(distToOrbit + 15f, 3f) / 5f), 1f, orbitSpeed);
		transform.parent = orbitVector.transform;
		orbitVector.transform.Rotate(Vector3.right * (y * num));
		orbitVector.transform.Rotate(Vector3.up * (x * num), Space.World);
		transform.parent = null;
	}

	public void pan(float distToOrbit)
	{
		float num = Mathf.Clamp(panSpeed * (distToOrbit / 100f), 0.1f, 2f);
		Vector3 translation = Vector3.right * (x * num) * -1f;
		Vector3 translation2 = Vector3.up * (y * num) * -1f;
		transform.Translate(translation);
		transform.Translate(translation2);
		orbitVector.transform.Translate(translation, transform);
		orbitVector.transform.Translate(translation2, transform);
	}

	public void resetCamera()
	{
		orbitVector.transform.position = Vector3.zero;
		orbitVector.transform.rotation = Quaternion.identity;
		transform.position = BasePos;
		transform.LookAt(orbitVector.transform.position, Vector3.up);
	}

	public void frameSelection()
	{
		Vector3 translation = new Vector3(0f, 0f, (0f - BaseDist) / 3f);
		GameObject gameObject = null;
		if (selectedObjects.Count == 1)
		{
			object obj = selectedObjects[0];
			if (!(obj is GameObject))
			{
				obj = RuntimeServices.Coerce(obj, typeof(GameObject));
			}
			gameObject = (GameObject)obj;
			orbitVector.transform.position = gameObject.transform.position;
			transform.position = gameObject.transform.position;
			transform.Translate(translation);
		}
		else
		{
			if (selectedObjects.Count <= 1)
			{
				return;
			}
			Vector3 zero = Vector3.zero;
			IEnumerator<object> enumerator = selectedObjects.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj2 = enumerator.Current;
					if (!(obj2 is GameObject))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(GameObject));
					}
					gameObject = (GameObject)obj2;
					zero += gameObject.transform.position;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			zero /= (float)selectedObjects.Count;
			orbitVector.transform.position = zero;
			transform.position = zero;
			transform.Translate(translation);
		}
	}

	public void select()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		bool flag = selectModifierKeyPressed();
		if (Physics.Raycast(ray, out hitInfo, camera.farClipPlane))
		{
			Transform transform = hitInfo.transform;
			if (!flag)
			{
				deselectAll();
			}
			if (transform.renderer.sharedMaterial != materialForSelection)
			{
				selectedObjects.Add(transform.gameObject);
				selectedObjectsMaterial.Add(transform.gameObject.renderer.sharedMaterial);
				transform.gameObject.renderer.sharedMaterial = materialForSelection;
				return;
			}
			int num = selectedObjects.IndexOf(transform.gameObject);
			if (num == -1)
			{
				Renderer obj = transform.gameObject.renderer;
				object obj2 = selectedObjectsMaterial[num];
				if (!(obj2 is Material))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Material));
				}
				obj.sharedMaterial = (Material)obj2;
				selectedObjects.RemoveAt(num);
				selectedObjectsMaterial.RemoveAt(num);
			}
		}
		else if (!flag)
		{
			deselectAll();
		}
	}

	public void deselectAll()
	{
		if (selectedObjects == null)
		{
			return;
		}
		IEnumerator<object[]> enumerator = Builtins.enumerate(selectedObjects).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object[] current = enumerator.Current;
				object value = current[0];
				object obj = current[1];
				if (!(obj is GameObject))
				{
					obj = RuntimeServices.Coerce(obj, typeof(GameObject));
				}
				GameObject gameObject = (GameObject)obj;
				Renderer obj2 = gameObject.renderer;
				object obj3 = selectedObjectsMaterial[RuntimeServices.UnboxInt32(value)];
				if (!(obj3 is Material))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(Material));
				}
				obj2.sharedMaterial = (Material)obj3;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		selectedObjects.Clear();
		selectedObjectsMaterial.Clear();
	}

	public bool modifierKeyPressed()
	{
		bool key = Input.GetKey(KeyCode.RightAlt);
		if (!key)
		{
			key = Input.GetKey(KeyCode.LeftAlt);
		}
		return key;
	}

	public bool zoomKeyPressed()
	{
		return Input.GetMouseButton(1);
	}

	public bool orbitKeyPressed()
	{
		return Input.GetMouseButton(0);
	}

	public bool panKeyPressed()
	{
		return Input.GetMouseButton(2);
	}

	public bool selectModifierKeyPressed()
	{
		bool key = Input.GetKey(KeyCode.RightShift);
		if (!key)
		{
			key = Input.GetKey(KeyCode.LeftShift);
		}
		if (!key)
		{
			key = Input.GetKey(KeyCode.RightControl);
		}
		if (!key)
		{
			key = Input.GetKey(KeyCode.LeftControl);
		}
		return key;
	}

	public bool selectPressed()
	{
		return Input.GetMouseButtonDown(0);
	}

	public bool frameSelectionPressed()
	{
		return Input.GetKeyDown("f");
	}

	public bool resetPressed()
	{
		return Input.GetKeyDown("r");
	}
}
