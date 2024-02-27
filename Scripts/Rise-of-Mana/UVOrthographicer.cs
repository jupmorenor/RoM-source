using UnityEngine;

[ExecuteInEditMode]
public class UVOrthographicer : MonoBehaviour
{
	public enum Axis
	{
		XY,
		XZ,
		ZY
	}

	public Transform meshObj;

	public GameObject makeObj;

	public Axis axis;

	public bool stretch = true;

	public bool make;

	public bool autoUpdate;

	private bool skin;

	private void Update()
	{
		if (make || autoUpdate)
		{
			MakeUV();
			make = false;
			makeObj.transform.position = meshObj.position;
			makeObj.transform.rotation = meshObj.rotation;
		}
	}

	private void MakeUV()
	{
		if (!meshObj)
		{
			return;
		}
		MeshFilter component = meshObj.GetComponent<MeshFilter>();
		SkinnedMeshRenderer skinnedMeshRenderer = null;
		MeshRenderer meshRenderer = null;
		Mesh sharedMesh;
		if (!component)
		{
			skinnedMeshRenderer = meshObj.GetComponent<SkinnedMeshRenderer>();
			if (!skinnedMeshRenderer)
			{
				return;
			}
			sharedMesh = skinnedMeshRenderer.sharedMesh;
			if (!sharedMesh)
			{
				return;
			}
			skin = true;
		}
		else
		{
			meshRenderer = meshObj.GetComponent<MeshRenderer>();
			if (!meshRenderer)
			{
				return;
			}
			sharedMesh = component.sharedMesh;
			if (!sharedMesh)
			{
				return;
			}
		}
		if (!makeObj)
		{
			makeObj = new GameObject("_" + meshObj.name);
		}
		SkinnedMeshRenderer skinnedMeshRenderer2 = null;
		MeshRenderer meshRenderer2 = null;
		MeshFilter meshFilter = null;
		Mesh mesh;
		if (skin)
		{
			skinnedMeshRenderer2 = makeObj.GetComponent<SkinnedMeshRenderer>();
			if (!skinnedMeshRenderer2)
			{
				skinnedMeshRenderer2 = makeObj.AddComponent<SkinnedMeshRenderer>();
			}
			mesh = skinnedMeshRenderer2.sharedMesh;
		}
		else
		{
			meshRenderer2 = makeObj.GetComponent<MeshRenderer>();
			if (!meshRenderer2)
			{
				meshRenderer2 = makeObj.AddComponent<MeshRenderer>();
			}
			meshFilter = makeObj.GetComponent<MeshFilter>();
			if (!meshFilter)
			{
				meshFilter = makeObj.AddComponent<MeshFilter>();
			}
			mesh = meshFilter.sharedMesh;
		}
		if (!mesh)
		{
			mesh = new Mesh();
			mesh.name = sharedMesh.name;
			mesh.vertices = sharedMesh.vertices;
			mesh.uv = sharedMesh.uv;
			mesh.triangles = sharedMesh.triangles;
			mesh.normals = sharedMesh.normals;
			mesh.tangents = sharedMesh.tangents;
			mesh.colors = sharedMesh.colors;
			mesh.boneWeights = sharedMesh.boneWeights;
			mesh.bindposes = sharedMesh.bindposes;
			if (skin)
			{
				skinnedMeshRenderer2.bones = skinnedMeshRenderer.bones;
				skinnedMeshRenderer2.sharedMesh = mesh;
				skinnedMeshRenderer2.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
			}
			else
			{
				meshFilter.sharedMesh = mesh;
				meshRenderer2.sharedMaterials = meshRenderer.sharedMaterials;
			}
		}
		Vector3[] vertices = mesh.vertices;
		int num = vertices.Length;
		Vector2[] array = new Vector2[num];
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = meshObj.rotation * vertices[i];
			if (axis == Axis.XY)
			{
				ref Vector2 reference = ref array[i];
				reference = new Vector2(vector.x, vector.y);
				if (vector.x > num2)
				{
					num2 = vector.x;
				}
				if (vector.x < num3)
				{
					num3 = vector.x;
				}
				if (vector.y > num4)
				{
					num4 = vector.y;
				}
				if (vector.y < num5)
				{
					num5 = vector.y;
				}
			}
			else if (axis == Axis.XZ)
			{
				ref Vector2 reference2 = ref array[i];
				reference2 = new Vector2(vector.x, vector.z);
				if (vector.x > num2)
				{
					num2 = vector.x;
				}
				if (vector.x < num3)
				{
					num3 = vector.x;
				}
				if (vector.z > num4)
				{
					num4 = vector.z;
				}
				if (vector.z < num5)
				{
					num5 = vector.z;
				}
			}
			else if (axis == Axis.ZY)
			{
				ref Vector2 reference3 = ref array[i];
				reference3 = new Vector2(vector.z, vector.y);
				if (vector.z > num2)
				{
					num2 = vector.z;
				}
				if (vector.z < num3)
				{
					num3 = vector.z;
				}
				if (vector.y > num4)
				{
					num4 = vector.y;
				}
				if (vector.y < num5)
				{
					num5 = vector.y;
				}
			}
		}
		float num6 = num2 - num3;
		float num7 = num4 - num5;
		float num8;
		float num9;
		if (stretch)
		{
			num8 = 1f / num6;
			num9 = 1f / num7;
		}
		else if (num6 >= num7)
		{
			num8 = 1f / num6;
			num9 = 1f / num6;
		}
		else
		{
			num8 = 1f / num7;
			num9 = 1f / num7;
		}
		for (int i = 0; i < num; i++)
		{
			array[i].x = (array[i].x - num3) * num8;
			array[i].y = (array[i].y - num5) * num9;
			Debug.Log(string.Concat(array[i], " ", num3, " ", num8));
		}
		mesh.uv = array;
	}
}
