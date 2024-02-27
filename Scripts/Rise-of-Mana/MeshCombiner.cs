using UnityEngine;

[ExecuteInEditMode]
public class MeshCombiner : MonoBehaviour
{
	public Transform[] meshObjs = new Transform[2];

	public Material material;

	public bool conbine;

	private MeshFilter[] meshfs;

	private void Update()
	{
		if (conbine)
		{
			Conbine();
			conbine = false;
		}
	}

	private void Conbine()
	{
		int num = 0;
		MeshFilter meshFilter = null;
		for (int i = 0; i < meshObjs.Length; i++)
		{
			if ((bool)meshObjs[i])
			{
				meshFilter = meshObjs[i].GetComponent<MeshFilter>();
				if ((bool)meshFilter)
				{
					num++;
				}
			}
		}
		meshfs = new MeshFilter[num];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			meshFilter = meshObjs[i].GetComponent<MeshFilter>();
			if ((bool)meshFilter)
			{
				meshfs[num2] = meshFilter;
				num2++;
			}
		}
		GameObject gameObject = new GameObject("_ConbineMesh");
		gameObject.AddComponent("MeshRenderer");
		MeshFilter meshFilter2 = gameObject.AddComponent("MeshFilter") as MeshFilter;
		CombineInstance[] array = new CombineInstance[meshfs.Length];
		for (int i = 0; i < meshfs.Length; i++)
		{
			array[i].mesh = meshfs[i].sharedMesh;
			array[i].transform = gameObject.transform.worldToLocalMatrix * meshfs[i].transform.localToWorldMatrix;
			meshfs[i].gameObject.SetActive(value: false);
		}
		Mesh mesh = new Mesh();
		mesh.name = "NewMesh";
		mesh.CombineMeshes(array);
		meshFilter2.sharedMesh = mesh;
		if ((bool)material)
		{
			meshFilter2.renderer.material = material;
		}
	}
}
