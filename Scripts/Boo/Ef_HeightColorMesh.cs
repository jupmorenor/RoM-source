using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightColorMesh : MonoBehaviour
{
	public GameObject meshObj;

	public Transform scaleObj;

	public bool everyFrame;

	public Color color0;

	public float height0;

	public Color color1;

	public float height1;

	public Color color2;

	public float height2;

	public Color color3;

	public float height3;

	public bool useDfaultColor;

	private Vector3 lstPos;

	private Quaternion lstRot;

	private Vector3 lstScl;

	private Mesh mesh;

	private Vector3[] verts;

	private Color32[] colors;

	private Color32[] colors2;

	private float dist01;

	private float dist12;

	private float dist23;

	private int leng;

	private Ef_HeightBuffer hiBuf;

	private bool ready;

	public Ef_HeightColorMesh()
	{
		color0 = new Color(1f, 1f, 1f, 0f);
		height0 = 5f;
		color1 = new Color(1f, 1f, 1f, 1f);
		height1 = 3.5f;
		color2 = new Color(1f, 1f, 1f, 1f);
		height2 = 2f;
		color3 = new Color(1f, 1f, 1f, 0f);
		height3 = 0.5f;
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
		if (component == null)
		{
			return;
		}
		Mesh sharedMesh = component.sharedMesh;
		if (!(sharedMesh == null))
		{
			mesh = new Mesh();
			mesh.name = sharedMesh.name;
			verts = sharedMesh.vertices;
			colors = sharedMesh.colors32;
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
			colors2 = new Color32[leng];
			if (!(height1 < height0))
			{
				height1 = height0 - 0.001f;
			}
			if (!(height2 < height1))
			{
				height2 = height1 - 0.001f;
			}
			if (!(height3 < height2))
			{
				height3 = height2 - 0.001f;
			}
			dist01 = height0 - height1;
			dist12 = height1 - height2;
			dist23 = height2 - height3;
			ready = true;
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
		Vector3 a = -position;
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
			Vector3.Scale(a, b);
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
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			if (flag)
			{
				if (flag2)
				{
					Vector3[] array = verts;
					vector2 = rotation * Vector3.Scale(array[RuntimeServices.NormalizeArrayIndex(array, index)], localScale);
				}
				else
				{
					Vector3[] array2 = verts;
					vector2 = rotation * array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				}
			}
			else if (flag2)
			{
				Vector3[] array3 = verts;
				vector2 = Vector3.Scale(array3[RuntimeServices.NormalizeArrayIndex(array3, index)], localScale);
			}
			else
			{
				Vector3[] array4 = verts;
				vector2 = array4[RuntimeServices.NormalizeArrayIndex(array4, index)];
			}
			float y = vector2.y;
			vector2 += position;
			object[] height = hiBuf.GetHeight(vector2);
			num3 = RuntimeServices.UnboxSingle(height[0]);
			vector = (Vector3)height[1];
			float num4 = vector2.y - num3;
			Color color = ((!(num4 <= height2)) ? ((num4 <= height1) ? Color.Lerp(color2, color1, (num4 - height2) / dist12) : ((num4 <= height0) ? Color.Lerp(color1, color0, (num4 - height1) / dist01) : color0)) : ((num4 <= height3) ? color3 : Color.Lerp(color3, color2, (num4 - height3) / dist23)));
			if (useDfaultColor)
			{
				Color32[] array5 = colors2;
				ref Color32 reference = ref array5[RuntimeServices.NormalizeArrayIndex(array5, index)];
				Color32[] array6 = colors;
				reference = array6[RuntimeServices.NormalizeArrayIndex(array6, index)] * color;
			}
			else
			{
				Color32[] array7 = colors2;
				ref Color32 reference2 = ref array7[RuntimeServices.NormalizeArrayIndex(array7, index)];
				reference2 = color;
			}
		}
		mesh.colors32 = colors2;
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
