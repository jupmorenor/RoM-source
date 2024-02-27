using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MeshUVStretch : MonoBehaviour
{
	public Transform streachObj;

	public GameObject[] meshObjs;

	public Mesh[] meshs;

	public bool evelyFrame;

	public Vector3[] invBoundss;

	private int leng;

	private bool ready;

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		if (!evelyFrame)
		{
			Streach();
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		if (!evelyFrame)
		{
			Streach();
		}
	}

	public void Init()
	{
		if (ready)
		{
			return;
		}
		if (streachObj == null)
		{
			streachObj = transform;
		}
		MeshFilter meshFilter = null;
		leng = 0;
		int num = 0;
		int length = meshObjs.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int num2 = num;
			num++;
			GameObject[] array = meshObjs;
			if (array[RuntimeServices.NormalizeArrayIndex(array, num2)] == null)
			{
				continue;
			}
			GameObject[] array2 = meshObjs;
			meshFilter = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)].GetComponent<MeshFilter>();
			checked
			{
				if (!(meshFilter == null) && !(meshFilter.mesh == null))
				{
					if (num2 != leng)
					{
						GameObject[] array3 = meshObjs;
						int num3 = RuntimeServices.NormalizeArrayIndex(array3, leng);
						GameObject[] array4 = meshObjs;
						array3[num3] = array4[RuntimeServices.NormalizeArrayIndex(array4, num2)];
						GameObject[] array5 = meshObjs;
						_ = array5[RuntimeServices.NormalizeArrayIndex(array5, num2)] == null;
					}
					leng++;
				}
			}
		}
		meshs = new Mesh[leng];
		invBoundss = new Vector3[leng];
		int num4 = 0;
		int num5 = leng;
		if (num5 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num4 < num5)
		{
			int index = num4;
			num4++;
			Mesh[] array6 = meshs;
			int num6 = RuntimeServices.NormalizeArrayIndex(array6, index);
			GameObject[] array7 = meshObjs;
			array6[num6] = array7[RuntimeServices.NormalizeArrayIndex(array7, index)].GetComponent<MeshFilter>().mesh;
			Mesh[] array8 = meshs;
			array8[RuntimeServices.NormalizeArrayIndex(array8, index)].MarkDynamic();
			Mesh[] array9 = meshs;
			array9[RuntimeServices.NormalizeArrayIndex(array9, index)].RecalculateBounds();
			Mesh[] array10 = meshs;
			Vector3 size = array10[RuntimeServices.NormalizeArrayIndex(array10, index)].bounds.size;
			Vector3 vector = default(Vector3);
			if (size.x != 0f)
			{
				vector.x = 1f / size.x;
			}
			else
			{
				vector.x = 0f;
			}
			if (size.y != 0f)
			{
				vector.y = 1f / size.y;
			}
			else
			{
				vector.y = 0f;
			}
			if (size.z != 0f)
			{
				vector.z = 1f / size.z;
			}
			else
			{
				vector.z = 0f;
			}
			Vector3[] array11 = invBoundss;
			array11[RuntimeServices.NormalizeArrayIndex(array11, index)] = vector;
		}
		ready = true;
	}

	public void Update()
	{
		if (ready && evelyFrame)
		{
			Streach();
		}
	}

	public void Streach()
	{
		Vector3 position = streachObj.position;
		Quaternion rotation = streachObj.rotation;
		Quaternion quaternion = Quaternion.Inverse(rotation);
		Vector3 localScale = streachObj.localScale;
		Vector3 b = default(Vector3);
		if (localScale.x != 0f)
		{
			b.x = 1f / localScale.x;
		}
		else
		{
			b.x = 0f;
		}
		if (localScale.y != 0f)
		{
			b.y = 1f / localScale.y;
		}
		else
		{
			b.y = 0f;
		}
		if (localScale.z != 0f)
		{
			b.z = 1f / localScale.z;
		}
		else
		{
			b.z = 0f;
		}
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			Mesh[] array = meshs;
			Vector3[] vertices = array[RuntimeServices.NormalizeArrayIndex(array, index)].vertices;
			int length = vertices.Length;
			Vector2[] array2 = new Vector2[length];
			GameObject[] array3 = meshObjs;
			Vector3 vector = quaternion * (array3[RuntimeServices.NormalizeArrayIndex(array3, index)].transform.position - position);
			GameObject[] array4 = meshObjs;
			Quaternion quaternion2 = quaternion * array4[RuntimeServices.NormalizeArrayIndex(array4, index)].transform.rotation;
			Quaternion quaternion3 = Quaternion.Inverse(quaternion2);
			int num3 = 0;
			int num4 = length;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				Vector3 vector2 = vertices[RuntimeServices.NormalizeArrayIndex(vertices, index2)];
				Vector3 a = vector2;
				Vector3[] array5 = invBoundss;
				vector2 = Vector3.Scale(a, array5[RuntimeServices.NormalizeArrayIndex(array5, index)]);
				vector2 = quaternion2 * vector2;
				vector2 += vector;
				vector2 = Vector3.Scale(vector2, b);
				ref Vector2 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, index2)];
				reference = new Vector2(vector2.x + 0.5f, vector2.y + 0.5f);
			}
			Mesh[] array6 = meshs;
			array6[RuntimeServices.NormalizeArrayIndex(array6, index)].uv = array2;
		}
	}

	public void OnDestroy()
	{
		int i = 0;
		Mesh[] array = meshs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
		}
	}
}
