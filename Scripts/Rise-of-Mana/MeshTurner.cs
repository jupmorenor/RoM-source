using UnityEngine;

[ExecuteInEditMode]
public class MeshTurner : MonoBehaviour
{
	public GameObject meshObj;

	public bool turn;

	private void Update()
	{
		if (turn)
		{
			Turn();
			turn = false;
		}
	}

	private void Turn()
	{
		Mesh mesh = null;
		if ((bool)meshObj.GetComponent<MeshFilter>())
		{
			mesh = meshObj.GetComponent<MeshFilter>().sharedMesh;
		}
		else if ((bool)meshObj.GetComponent<SkinnedMeshRenderer>())
		{
			mesh = meshObj.GetComponent<SkinnedMeshRenderer>().sharedMesh;
		}
		int[] triangles = mesh.triangles;
		for (int i = 0; i < triangles.Length / 3; i++)
		{
			int num = i * 3;
			int num2 = triangles[num];
			triangles[num] = triangles[num + 2];
			triangles[num + 2] = num2;
		}
		mesh.triangles = triangles;
	}
}
