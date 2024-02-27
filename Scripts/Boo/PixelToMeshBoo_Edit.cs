using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class PixelToMeshBoo_Edit : MonoBehaviour
{
	private PixelToMeshBoo ptm;

	private bool ready;

	public void Awake()
	{
		ptm = gameObject.GetComponent<PixelToMeshBoo>();
		if (!(ptm == null))
		{
			ptm.UpdateMesh();
			ready = true;
		}
	}

	public void LateUpdate()
	{
		if (ready)
		{
			ptm.LateUpdate();
		}
	}
}
