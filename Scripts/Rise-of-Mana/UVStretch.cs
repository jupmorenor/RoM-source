using UnityEngine;

[ExecuteInEditMode]
public class UVStretch : MonoBehaviour
{
	public GameObject meshObj;

	public GameObject makeObj;

	public float multiplyX = 1f;

	public float multiplyY = 1f;

	public float offsetX;

	public float offsetY;

	public float angle;

	public bool stretch;

	public bool widespread;

	public bool resetOffset;

	private bool skin;

	private void Update()
	{
		if (stretch)
		{
			Stretch(wide: false, angle != 0f, angle);
			stretch = false;
		}
		if (widespread)
		{
			Stretch(wide: true, resOfst: false, 0f);
			widespread = false;
		}
		if (resetOffset)
		{
			multiplyX = 1f;
			multiplyY = 1f;
			offsetX = 0f;
			offsetY = 0f;
			angle = 0f;
			Stretch(wide: false, resOfst: true, 0f);
			resetOffset = false;
		}
	}

	private void Stretch(bool wide, bool resOfst, float ang)
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
		if (meshObj != makeObj)
		{
			meshObj.SetActive(value: false);
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
		Vector2[] uv = sharedMesh.uv;
		float num = 99999f;
		float num2 = -99999f;
		float num3 = 99999f;
		float num4 = -99999f;
		if (wide || resOfst)
		{
			Vector2[] uv2 = sharedMesh.uv;
			if (uv2.Length > 0)
			{
				for (int i = 0; i < uv2.Length; i++)
				{
					Vector2 vector = uv2[i];
					if (vector.x < num)
					{
						num = vector.x;
					}
					if (vector.x > num2)
					{
						num2 = vector.x;
					}
					if (vector.y < num3)
					{
						num3 = vector.y;
					}
					if (vector.y > num4)
					{
						num4 = vector.y;
					}
				}
			}
			if (wide)
			{
				multiplyX = 1f / (num2 - num);
				multiplyY = 1f / (num4 - num3);
				offsetX = (0f - num) * multiplyX;
				offsetY = (0f - num3) * multiplyY;
			}
			if (resOfst)
			{
				float num5 = Mathf.Floor(0f - num);
				float num6 = Mathf.Floor(0f - num3);
				for (int i = 0; i < uv.Length; i++)
				{
					Vector2 vector2 = uv[i];
					vector2.x += num5;
					vector2.y += num6;
					uv[i] = vector2;
				}
			}
		}
		if (ang != 0f)
		{
			float f = ang * 0.01745329f;
			float num7 = Mathf.Sin(f);
			float num8 = Mathf.Cos(f);
			for (int i = 0; i < uv.Length; i++)
			{
				float x = uv[i].x;
				float y = uv[i].y;
				uv[i].x = x * num8 - y * num7;
				uv[i].y = x * num7 + y * num8;
			}
		}
		for (int i = 0; i < uv.Length; i++)
		{
			Vector2 vector3 = uv[i];
			vector3.x *= multiplyX;
			vector3.y *= multiplyY;
			vector3.x += offsetX;
			vector3.y += offsetY;
			uv[i] = vector3;
		}
		mesh.uv = uv;
	}
}
