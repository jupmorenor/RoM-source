using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_MeshStorage_Edit : MonoBehaviour
{
	public bool setMeshOnEditrStart;

	private Ef_MeshStorage ms;

	private bool ready;

	public void Start()
	{
		ms = gameObject.GetComponent<Ef_MeshStorage>();
		if (!(ms == null))
		{
			if (setMeshOnEditrStart)
			{
				ms.SetMesh();
			}
			ready = true;
		}
	}

	public void Update()
	{
		if (ready)
		{
			if (ms.getMesh.getMeshData)
			{
				ms.GetMesh();
				ms.getMesh.getMeshData = false;
			}
			if (ms.getMesh.getMaterial)
			{
				ms.GetMaterial();
				ms.getMesh.getMaterial = false;
			}
			if (ms.getMesh.testSetMesh)
			{
				ms.SetMesh();
				ms.getMesh.testSetMesh = false;
			}
		}
	}
}
