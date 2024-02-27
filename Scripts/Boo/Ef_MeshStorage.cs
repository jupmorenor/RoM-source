using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MeshStorage : MonoBehaviour
{
	public bool setMeshOnStart;

	public GameObject[] setMeshObjs;

	public bool setMaterials;

	public Material[] setMaterialDatas;

	public Ef_MeshStorageGet getMesh;

	public Ef_MeshStorageData meshData;

	private Mesh mesh;

	public Ef_MeshStorage()
	{
		getMesh = new Ef_MeshStorageGet();
		meshData = new Ef_MeshStorageData();
	}

	public void Start()
	{
		Ef_MeshStorage_Edit component = gameObject.GetComponent<Ef_MeshStorage_Edit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		if (setMeshOnStart)
		{
			SetMesh();
		}
	}

	public void GetMesh()
	{
		if (!getMesh.getMeshObj)
		{
			return;
		}
		Mesh mesh = null;
		MeshFilter component = getMesh.getMeshObj.GetComponent<MeshFilter>();
		if ((bool)component)
		{
			mesh = component.sharedMesh;
		}
		else
		{
			SkinnedMeshRenderer component2 = getMesh.getMeshObj.GetComponent<SkinnedMeshRenderer>();
			if (!component2)
			{
				return;
			}
			mesh = component2.sharedMesh;
		}
		meshData = new Ef_MeshStorageData();
		meshData.name = mesh.name;
		meshData.vertices = mesh.vertices;
		meshData.uv = mesh.uv;
		meshData.uv1 = mesh.uv1;
		meshData.uv2 = mesh.uv2;
		meshData.normals = mesh.normals;
		meshData.triangles = mesh.triangles;
		meshData.tangents = mesh.tangents;
		meshData.colors = mesh.colors;
		getMesh.getMeshObj = null;
	}

	public void GetMaterial()
	{
		if ((bool)getMesh.getMeshObj && (bool)getMesh.getMeshObj.renderer)
		{
			setMaterialDatas = getMesh.getMeshObj.renderer.sharedMaterials;
		}
	}

	public void SetMesh()
	{
		mesh = new Mesh();
		mesh.name = meshData.name;
		mesh.vertices = meshData.vertices;
		mesh.uv = meshData.uv;
		mesh.uv1 = meshData.uv1;
		mesh.uv2 = meshData.uv2;
		mesh.normals = meshData.normals;
		mesh.triangles = meshData.triangles;
		mesh.tangents = meshData.tangents;
		mesh.colors = meshData.colors;
		bool num = setMaterials;
		if (num)
		{
			num = setMaterialDatas.Length > 0;
		}
		bool flag = num;
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(setMeshObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num2 = enumerator.Current;
				GameObject[] array = setMeshObjs;
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, num2)];
				if ((bool)gameObject)
				{
					MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
					if (!meshFilter)
					{
						meshFilter = gameObject.AddComponent<MeshFilter>();
					}
					meshFilter.sharedMesh = mesh;
					MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
					if (!meshRenderer)
					{
						meshRenderer = gameObject.AddComponent<MeshRenderer>();
					}
					if (flag)
					{
						meshRenderer.materials = setMaterialDatas;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void OnDestroy()
	{
		if ((bool)mesh)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
