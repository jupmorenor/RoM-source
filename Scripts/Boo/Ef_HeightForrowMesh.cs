using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightForrowMesh : MonoBehaviour
{
	public GameObject meshObj;

	public Transform scaleObj;

	public float upLength;

	public bool everyFrame;

	public bool downFollow;

	public float slopeUp;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstScl;

	private Mesh mesh;

	private Vector3[] verts;

	private Vector3[] verts2;

	private int leng;

	private Ef_HeightBuffer hiBuf;

	private bool ready;

	public Ef_HeightForrowMesh()
	{
		upLength = 0.1f;
		slopeUp = 0.5f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (!everyFrame)
		{
			UpdateMesh();
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		UpdateMesh();
	}

	public void Init()
	{
		hiBuf = Ef_HeightBuffer.Current;
		if (hiBuf == null)
		{
			return;
		}
		if (meshObj == null)
		{
			meshObj = gameObject;
		}
		if (scaleObj == null)
		{
			scaleObj = transform;
		}
		MeshFilter component = meshObj.GetComponent<MeshFilter>();
		if (!(component == null))
		{
			Mesh sharedMesh = component.sharedMesh;
			if (!(sharedMesh == null))
			{
				mesh = new Mesh();
				mesh.name = sharedMesh.name;
				verts = sharedMesh.vertices;
				mesh.MarkDynamic();
				mesh.vertices = verts;
				mesh.uv = sharedMesh.uv;
				mesh.uv1 = sharedMesh.uv1;
				mesh.uv2 = sharedMesh.uv2;
				mesh.triangles = sharedMesh.triangles;
				mesh.colors32 = sharedMesh.colors32;
				mesh.normals = sharedMesh.normals;
				component.sharedMesh = mesh;
				leng = verts.Length;
				verts2 = new Vector3[leng];
				ready = true;
			}
		}
	}

	public void Update()
	{
		if (everyFrame)
		{
			UpdateMesh();
		}
	}

	public void UpdateMesh()
	{
		if (!ready)
		{
			return;
		}
		Vector3 position = meshObj.transform.position;
		Quaternion rotation = meshObj.transform.rotation;
		Vector3 localScale = scaleObj.localScale;
		Quaternion quaternion = Quaternion.Inverse(rotation);
		if (position == lstPos && rotation == lstRot && localScale == lstScl)
		{
			return;
		}
		lstPos = position;
		lstRot = rotation;
		lstScl = localScale;
		bool flag = rotation != Quaternion.identity;
		bool flag2 = localScale != Vector3.one;
		Vector3 b = default(Vector3);
		Vector3 vector = -position;
		if (flag2)
		{
			if (localScale.x != 0f)
			{
				b.x = 1f / localScale.x;
			}
			else
			{
				b.x = 0f;
			}
			if (localScale.y != 0f)
			{
				b.y = 1f / localScale.y;
			}
			else
			{
				b.y = 0f;
			}
			if (localScale.z != 0f)
			{
				b.z = 1f / localScale.z;
			}
			else
			{
				b.z = 0f;
			}
			Vector3.Scale(vector, b);
		}
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			float num3 = default(float);
			Vector3 vector2 = default(Vector3);
			Vector3 vector3 = default(Vector3);
			if (flag)
			{
				if (flag2)
				{
					Vector3[] array = verts;
					vector3 = rotation * Vector3.Scale(array[RuntimeServices.NormalizeArrayIndex(array, index)], localScale);
				}
				else
				{
					Vector3[] array2 = verts;
					vector3 = rotation * array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				}
			}
			else if (flag2)
			{
				Vector3[] array3 = verts;
				vector3 = Vector3.Scale(array3[RuntimeServices.NormalizeArrayIndex(array3, index)], localScale);
			}
			else
			{
				Vector3[] array4 = verts;
				vector3 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
			}
			float y = vector3.y;
			vector3 += position;
			object[] height = hiBuf.GetHeight(vector3);
			num3 = RuntimeServices.UnboxSingle(height[0]);
			vector2 = (Vector3)height[1];
			num3 += upLength;
			if (!(slopeUp <= 0f))
			{
				num3 += Vector3.Angle(vector2, Vector3.up) / 90f * slopeUp;
			}
			if (downFollow)
			{
				vector3.y = num3 + y;
			}
			else if (!(vector3.y >= num3 + y))
			{
				vector3.y = num3 + y;
			}
			vector3 += vector;
			vector3 = quaternion * vector3;
			if (flag2)
			{
				vector3 = Vector3.Scale(vector3, b);
			}
			Vector3[] array5 = verts2;
			array5[RuntimeServices.NormalizeArrayIndex(array5, index)] = vector3;
		}
		mesh.vertices = verts2;
		mesh.RecalculateBounds();
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
