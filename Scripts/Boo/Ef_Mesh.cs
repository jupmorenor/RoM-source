using System;
using UnityEngine;

[Serializable]
public class Ef_Mesh : MonoBehaviour
{
	public GameObject meshObj;

	public Material material;

	public Vector3[] vertices;

	public Vector2[] uvs;

	public Vector2[] uv2s;

	public int[] triangles;

	public Color32[] colors;

	public Vector3[] normals;

	public bool calculateNormals;

	private Mesh mesh;

	private int lstLeng;

	public void Start()
	{
		Ef_Mesh_BillboardEdit component = gameObject.GetComponent<Ef_Mesh_BillboardEdit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		UpdateMesh();
	}

	public void UpdateMesh()
	{
		if (material == null)
		{
			return;
		}
		MeshFilter meshFilter = meshObj.GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = meshObj.AddComponent<MeshFilter>();
		}
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.name = meshObj.name;
			meshFilter.sharedMesh = mesh;
		}
		MeshRenderer meshRenderer = meshObj.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			meshRenderer = meshObj.AddComponent<MeshRenderer>();
		}
		meshRenderer.material = material;
		int length = vertices.Length;
		if (length > lstLeng)
		{
			mesh.vertices = vertices;
			if (uv2s.Length > 0)
			{
				mesh.uv1 = uvs;
				mesh.uv2 = uv2s;
			}
			else
			{
				mesh.uv = uvs;
			}
			mesh.triangles = triangles;
			mesh.colors32 = colors;
		}
		else
		{
			mesh.colors32 = colors;
			mesh.triangles = triangles;
			mesh.vertices = vertices;
			if (uv2s.Length > 0)
			{
				mesh.uv1 = uvs;
				mesh.uv2 = uv2s;
			}
			else
			{
				mesh.uv = uvs;
			}
		}
		lstLeng = length;
		if (calculateNormals)
		{
			mesh.RecalculateNormals();
			calculateNormals = false;
		}
		else
		{
			mesh.normals = normals;
		}
		mesh.RecalculateBounds();
	}

	public void GetMeshState()
	{
		MeshFilter component = meshObj.GetComponent<MeshFilter>();
		if (component == null)
		{
			return;
		}
		mesh = component.sharedMesh;
		if (!(mesh == null))
		{
			vertices = mesh.vertices;
			uv2s = mesh.uv2;
			if (uv2s.Length > 0)
			{
				uvs = mesh.uv1;
			}
			else
			{
				uvs = mesh.uv;
			}
			triangles = mesh.triangles;
			colors = mesh.colors32;
			normals = mesh.normals;
			mesh = null;
			component.sharedMesh = null;
			UpdateMesh();
		}
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
