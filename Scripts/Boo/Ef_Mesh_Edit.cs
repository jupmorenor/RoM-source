using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_Mesh_Edit : MonoBehaviour
{
	public bool updateMesh;

	public bool getMeshState;

	private Ef_Mesh emesh;

	private bool ready;

	public void Start()
	{
		emesh = gameObject.GetComponent<Ef_Mesh>();
		if (!(emesh == null))
		{
			emesh.UpdateMesh();
			ready = true;
		}
	}

	public void Update()
	{
		if (ready)
		{
			if (updateMesh)
			{
				emesh.UpdateMesh();
				updateMesh = false;
			}
			if (getMeshState)
			{
				emesh.GetMeshState();
				getMeshState = false;
			}
		}
	}
}
