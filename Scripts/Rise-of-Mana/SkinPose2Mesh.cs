using UnityEngine;

[ExecuteInEditMode]
public class SkinPose2Mesh : MonoBehaviour
{
	public Transform skinnedMeshObj;

	public bool bake;

	private void Update()
	{
		if (bake)
		{
			Bake();
			bake = false;
		}
	}

	private void Bake()
	{
		if (!skinnedMeshObj)
		{
			Debug.LogError("No SkinnedMesh Obj");
			return;
		}
		SkinnedMeshRenderer componentInChildren = skinnedMeshObj.GetComponentInChildren<SkinnedMeshRenderer>();
		if (!componentInChildren)
		{
			Debug.LogError("No SkinnedMeshRenderer");
			return;
		}
		Mesh sharedMesh = componentInChildren.sharedMesh;
		if (!sharedMesh)
		{
			Debug.LogError("No SkinnedMesh");
			return;
		}
		GameObject gameObject = new GameObject("_" + skinnedMeshObj.name);
		gameObject.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		mesh.name = sharedMesh.name;
		componentInChildren.BakeMesh(mesh);
		meshFilter.sharedMesh = mesh;
	}
}
