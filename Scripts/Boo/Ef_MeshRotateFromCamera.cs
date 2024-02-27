using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MeshRotateFromCamera : MonoBehaviour
{
	public Transform cameraObj;

	public Camera cameraCom;

	public Mesh sharedMesh;

	public Material sharedMaterial;

	public GameObject[] attachMeshObjs;

	public bool nearestCam;

	public bool evelyFlame;

	public bool horizontal;

	private Mesh mesh;

	private Vector3[] sharedVerts;

	private Vector3[] verts;

	private int vertNum;

	private bool ready;

	public Ef_MeshRotateFromCamera()
	{
		evelyFlame = true;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		LookAt();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		LookAt();
	}

	public void Init()
	{
		if (sharedMesh == null)
		{
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			if (component != null)
			{
				sharedMesh = component.sharedMesh;
			}
			if (sharedMesh == null)
			{
				return;
			}
		}
		if (sharedMaterial == null)
		{
			MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				sharedMaterial = component2.sharedMaterial;
			}
			if (!(sharedMaterial == null))
			{
			}
		}
		sharedVerts = sharedMesh.vertices;
		vertNum = sharedVerts.Length;
		verts = new Vector3[vertNum];
		mesh = new Mesh();
		mesh.MarkDynamic();
		mesh.vertices = sharedVerts;
		mesh.triangles = sharedMesh.triangles;
		mesh.colors32 = sharedMesh.colors32;
		mesh.uv = sharedMesh.uv;
		int i = 0;
		GameObject[] array = attachMeshObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!(array[i] == null))
			{
				MeshFilter meshFilter = array[i].GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = array[i].AddComponent<MeshFilter>();
				}
				meshFilter.sharedMesh = mesh;
				MeshRenderer meshRenderer = array[i].GetComponent<MeshRenderer>();
				if (meshRenderer == null)
				{
					meshRenderer = array[i].AddComponent<MeshRenderer>();
				}
				if (sharedMaterial != null)
				{
					meshRenderer.sharedMaterial = sharedMaterial;
				}
			}
		}
		ready = true;
	}

	public void LateUpdate()
	{
		if (evelyFlame)
		{
			LookAt();
		}
	}

	public void LookAt()
	{
		if (!ready)
		{
			return;
		}
		if (cameraCom != null && !cameraCom.enabled)
		{
			cameraObj = null;
		}
		if (cameraObj != null && !cameraObj.gameObject.activeSelf)
		{
			cameraObj = null;
		}
		if (cameraObj == null)
		{
			FindCamera();
		}
		if (!(cameraObj == null))
		{
			Quaternion quaternion = cameraObj.rotation;
			if (horizontal)
			{
				quaternion = Quaternion.FromToRotation(quaternion * Vector3.up, Vector3.up) * quaternion;
			}
			int num = 0;
			int num2 = vertNum;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int index = num;
				num++;
				Vector3[] array = verts;
				ref Vector3 reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
				Quaternion quaternion2 = quaternion;
				Vector3[] array2 = sharedVerts;
				reference = quaternion2 * array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
			}
			mesh.vertices = verts;
		}
	}

	public void FindCamera()
	{
		if (nearestCam)
		{
			Camera[] allCameras = Camera.allCameras;
			Vector3 position = transform.position;
			float num = 999999f;
			int i = 0;
			Camera[] array = allCameras;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				Vector3 position2 = array[i].transform.position;
				if (!(position2 == Vector3.zero))
				{
					float sqrMagnitude = (position2 - position).sqrMagnitude;
					if (!(sqrMagnitude >= num))
					{
						cameraObj = array[i].transform;
						cameraCom = array[i];
						num = sqrMagnitude;
					}
				}
			}
			if ((bool)cameraObj)
			{
			}
		}
		else if ((bool)Camera.main)
		{
			cameraObj = Camera.main.transform;
			cameraCom = Camera.main;
		}
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
		int i = 0;
		GameObject[] array = attachMeshObjs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
		}
	}
}
