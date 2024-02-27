using UnityEngine;

[ExecuteInEditMode]
public class MeshSorter : MonoBehaviour
{
	public GameObject meshObj;

	public bool cullingMode = true;

	public bool sort;

	public bool autoUpdate;

	private Mesh mesh;

	private GameObject lstObj;

	private void Update()
	{
		if (meshObj != lstObj)
		{
			mesh = null;
			lstObj = meshObj;
		}
		if (sort || autoUpdate)
		{
			SortMesh();
			sort = false;
		}
	}

	private void GetMesh()
	{
		if (!meshObj)
		{
			return;
		}
		MeshFilter component = meshObj.GetComponent<MeshFilter>();
		if ((bool)component)
		{
			mesh = component.sharedMesh;
			return;
		}
		SkinnedMeshRenderer component2 = meshObj.GetComponent<SkinnedMeshRenderer>();
		if ((bool)component2)
		{
			mesh = component2.sharedMesh;
		}
	}

	private void SortMesh()
	{
		if (!mesh)
		{
			GetMesh();
		}
		if (!mesh)
		{
			return;
		}
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		int num = triangles.Length / 3;
		float[] array = new float[num];
		mesh.RecalculateBounds();
		Vector3 center = mesh.bounds.center;
		float num2 = 99999f;
		float num3 = -99999f;
		float num4 = 99999f;
		float num5 = -99999f;
		float num6 = 99999f;
		float num7 = -99999f;
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vector = vertices[i];
			if (vector[0] > num2)
			{
				num2 = vector[0];
			}
			if (vector[0] < num3)
			{
				num3 = vector[0];
			}
			if (vector[1] > num4)
			{
				num4 = vector[1];
			}
			if (vector[1] < num5)
			{
				num5 = vector[1];
			}
			if (vector[2] > num6)
			{
				num6 = vector[2];
			}
			if (vector[2] < num7)
			{
				num7 = vector[2];
			}
		}
		float num8 = (num2 + num3) / 2f;
		float num9 = (num4 + num5) / 2f;
		float num10 = (num6 + num7) / 2f;
		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vector = vertices[i];
			ref Vector3 reference = ref vertices[i];
			reference = new Vector3(vector[0] - num8, vector[1] - num9, vector[2] - num10);
		}
		if (meshObj.transform.rotation != Quaternion.identity || base.transform.rotation != Quaternion.identity)
		{
			Quaternion quaternion = Quaternion.Inverse(base.transform.rotation) * meshObj.transform.rotation;
			for (int i = 0; i < vertices.Length; i++)
			{
				ref Vector3 reference2 = ref vertices[i];
				reference2 = quaternion * vertices[i];
			}
		}
		for (int i = 0; i < num; i++)
		{
			Vector3 vector2 = vertices[triangles[i * 3]];
			Vector3 vector3 = vertices[triangles[i * 3 + 1]];
			Vector3 vector4 = vertices[triangles[i * 3 + 2]];
			array[i] = (vector2[2] + vector3[2] + vector4[2]) / 3f;
			if (cullingMode)
			{
				Vector3 vector5 = vector3 - vector2;
				Vector3 vector6 = vector4 - vector2;
				if (vector5.x * vector6.y - vector5.y * vector6.x > 0f)
				{
					array[i] *= -1f;
				}
			}
		}
		int[] array2 = new int[num];
		bool[] array3 = new bool[num];
		for (int i = 0; i < num; i++)
		{
			float num11 = -99999f;
			for (int j = 0; j < num; j++)
			{
				if (!array3[j] && array[j] > num11)
				{
					array2[i] = j;
					num11 = array[j];
				}
			}
			array3[array2[i]] = true;
		}
		int[] array4 = new int[triangles.Length];
		for (int i = 0; i < num; i++)
		{
			array4[i * 3] = triangles[array2[i] * 3];
			array4[i * 3 + 1] = triangles[array2[i] * 3 + 1];
			array4[i * 3 + 2] = triangles[array2[i] * 3 + 2];
		}
		mesh.triangles = array4;
	}
}
