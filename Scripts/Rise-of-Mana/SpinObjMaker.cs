using UnityEngine;

[ExecuteInEditMode]
public class SpinObjMaker : MonoBehaviour
{
	public int step = 3;

	private int lstStep;

	public int split = 5;

	public float gridSize = 0.01f;

	public bool make;

	public bool autoUpdate;

	public bool meshFront = true;

	public Color[] vertexColorH = new Color[0];

	public Color[] vertexColorV = new Color[0];

	public Material material;

	public bool textureScroll;

	private Color[] lstcolrH = new Color[0];

	private Color[] lstcolrV = new Color[0];

	private Transform[] points = new Transform[0];

	private Transform meshObj;

	private Material ptrMat;

	private Transform trash;

	private bool texCopy;

	private void Start()
	{
		make = false;
		autoUpdate = false;
		SetPtrMat();
		lstcolrH = new Color[vertexColorH.Length];
		for (int i = 0; i < vertexColorH.Length; i++)
		{
			ref Color reference = ref lstcolrH[i];
			reference = vertexColorH[i];
		}
		lstcolrV = new Color[vertexColorV.Length];
		for (int i = 0; i < vertexColorV.Length; i++)
		{
			ref Color reference2 = ref lstcolrV[i];
			reference2 = vertexColorH[i];
		}
	}

	private void Update()
	{
		if (step < 2)
		{
			step = 2;
		}
		if (step > 100)
		{
			step = 100;
		}
		if (split < 2)
		{
			split = 2;
		}
		if (step != lstStep)
		{
			MakePointer();
			lstStep = step;
		}
		if (vertexColorH.Length != lstcolrH.Length)
		{
			for (int i = lstcolrH.Length; i < vertexColorH.Length; i++)
			{
				ref Color reference = ref vertexColorH[i];
				reference = Color.white;
			}
			lstcolrH = new Color[vertexColorH.Length];
		}
		if (vertexColorV.Length != lstcolrV.Length)
		{
			for (int i = lstcolrV.Length; i < vertexColorV.Length; i++)
			{
				ref Color reference2 = ref vertexColorV[i];
				reference2 = Color.white;
			}
			lstcolrV = new Color[vertexColorV.Length];
		}
		if (gridSize > 0f)
		{
			for (int i = 0; i < points.Length; i++)
			{
				if (points[i] != null)
				{
					Vector3 localPosition = points[i].localPosition;
					localPosition.x = Mathf.Round(localPosition.x / gridSize) * gridSize;
					localPosition.y = Mathf.Round(localPosition.y / gridSize) * gridSize;
					localPosition.z = Mathf.Round(localPosition.z / gridSize) * gridSize;
					points[i].localPosition = localPosition;
				}
			}
		}
		bool flag = false;
		for (int i = 0; i < vertexColorH.Length; i++)
		{
			if (vertexColorH[i] != lstcolrH[i])
			{
				flag = true;
				ref Color reference3 = ref lstcolrH[i];
				reference3 = vertexColorH[i];
			}
		}
		for (int i = 0; i < vertexColorV.Length; i++)
		{
			if (vertexColorV[i] != lstcolrV[i])
			{
				flag = true;
				ref Color reference4 = ref lstcolrV[i];
				reference4 = vertexColorV[i];
			}
		}
		if (make || autoUpdate)
		{
			flag = true;
			make = false;
		}
		if (flag)
		{
			MakeMesh();
		}
		if ((bool)meshObj)
		{
			meshObj.position = base.transform.position;
			meshObj.rotation = base.transform.rotation;
		}
		if (textureScroll && (bool)material)
		{
			if (!texCopy)
			{
				material = new Material(material);
				texCopy = true;
			}
			material.SetTextureOffset("_MainTex", material.GetTextureOffset("_MainTex") + new Vector2(0.05f, 0.05f));
			textureScroll = false;
		}
	}

	private void MakePointer()
	{
		points = new Transform[step];
		int num = 0;
		int i;
		for (i = 0; i < step; i++)
		{
			string text = "Pointer";
			if (i < 10)
			{
				text += "0";
			}
			text += i;
			GameObject gameObject = GameObject.Find(text);
			if ((bool)gameObject)
			{
				points[i] = gameObject.transform;
				points[i].parent = base.transform;
				num = i;
				continue;
			}
			points[i] = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
			text = "Pointer";
			if (i < 10)
			{
				text += "0";
			}
			text += i;
			points[i].name = text;
			points[i].parent = base.transform;
			if (num == 0)
			{
				points[i].localPosition = new Vector3(0.5f, (float)i * 0.2f, 0f);
			}
			else
			{
				points[i].localPosition += points[num].localPosition + new Vector3(0f, (float)(i - num) * 0.2f, 0f);
			}
			points[i].localScale = new Vector3(0.01f, 0.01f, 0.01f);
			if (!ptrMat)
			{
				ptrMat = MakePtrMat();
			}
			points[i].renderer.material = ptrMat;
		}
		DeletePointer(i);
	}

	private Material MakePtrMat()
	{
		Material material = new Material(Shader.Find("GUI/Text Shader"));
		material.name = "Pointer";
		material.color = new Color(1f, 0f, 1f);
		return material;
	}

	private void DeletePointer(int start)
	{
		for (int i = start; i < 100; i++)
		{
			string text = "Pointer";
			if (i < 10)
			{
				text += "0";
			}
			text += i;
			GameObject gameObject = GameObject.Find(text);
			if ((bool)gameObject)
			{
				gameObject.transform.parent = TrashObj();
				gameObject.SetActive(value: false);
				i--;
			}
		}
	}

	private void MakeMesh()
	{
		if (!meshObj)
		{
			meshObj = new GameObject("_SpinMeshObject").transform;
		}
		MeshFilter meshFilter = meshObj.GetComponent("MeshFilter") as MeshFilter;
		if (!meshFilter)
		{
			meshFilter = meshObj.gameObject.AddComponent("MeshFilter") as MeshFilter;
		}
		MeshRenderer meshRenderer = meshObj.GetComponent("MeshRenderer") as MeshRenderer;
		if (!meshRenderer)
		{
			meshRenderer = meshObj.gameObject.AddComponent("MeshRenderer") as MeshRenderer;
		}
		Mesh mesh = new Mesh();
		mesh.name = "SpinMesh";
		MakePointer();
		int num = points.Length;
		float num2 = 360f / (float)split;
		Vector3[] array = new Vector3[(split + 1) * num];
		Vector2[] array2 = new Vector2[(split + 1) * num];
		Color[] array3 = new Color[(split + 1) * num];
		int[] array4 = new int[(split + 1) * (num - 1) * 6];
		for (int i = 0; i < split + 1; i++)
		{
			for (int j = 0; j < num; j++)
			{
				ref Vector3 reference = ref array[i * num + j];
				reference = Quaternion.Euler(new Vector3(0f, num2 * (float)i, 0f)) * points[j].localPosition;
				ref Vector2 reference2 = ref array2[i * num + j];
				reference2 = new Vector2(1f / (float)split * (float)i, 1f / (float)(num - 1) * (float)j);
				Color color = Color.white;
				Color color2 = Color.white;
				if (vertexColorH.Length > 0)
				{
					float num3 = (float)vertexColorH.Length / (float)split * (float)i;
					int num4 = Mathf.FloorToInt(num3);
					if (num4 >= vertexColorH.Length)
					{
						num4 = 0;
					}
					int num5 = num4 + 1;
					if (num5 >= vertexColorH.Length)
					{
						num5 = 0;
					}
					color = Color.Lerp(vertexColorH[num4], vertexColorH[num5], num3 % 1f);
				}
				if (vertexColorV.Length > 0)
				{
					float num3 = (float)(vertexColorV.Length - 1) / (float)(num - 1) * (float)j;
					int num4 = Mathf.FloorToInt(num3);
					color2 = ((num4 >= vertexColorV.Length - 1) ? vertexColorV[num4] : Color.Lerp(vertexColorV[num4], vertexColorV[num4 + 1], num3 % 1f));
				}
				Color color3 = color * color2;
				float num6 = color.r;
				if (color.g > num6)
				{
					num6 = color.g;
				}
				if (color.b > num6)
				{
					num6 = color.b;
				}
				if (color2.r > num6)
				{
					num6 = color2.r;
				}
				if (color2.g > num6)
				{
					num6 = color2.g;
				}
				if (color2.b > num6)
				{
					num6 = color2.b;
				}
				color3 /= num6;
				array3[i * num + j] = color3;
			}
		}
		for (int i = 1; i < split + 1; i++)
		{
			for (int j = 0; j < num - 1; j++)
			{
				int num7;
				int num8;
				if (i < split + 1)
				{
					num7 = i - 1;
					num8 = i;
				}
				else
				{
					num7 = i - 1;
					num8 = 0;
				}
				if (meshFront)
				{
					int num9 = 6 * ((i - 1) * (num - 1) + j);
					array4[num9] = num7 * num + j;
					array4[num9 + 1] = num8 * num + j;
					array4[num9 + 2] = num7 * num + j + 1;
					array4[num9 + 3] = num7 * num + j + 1;
					array4[num9 + 4] = num8 * num + j;
					array4[num9 + 5] = num8 * num + j + 1;
				}
				else
				{
					int num9 = 6 * ((i - 1) * (num - 1) + j);
					array4[num9] = num7 * num + j;
					array4[num9 + 1] = num7 * num + j + 1;
					array4[num9 + 2] = num8 * num + j;
					array4[num9 + 3] = num7 * num + j + 1;
					array4[num9 + 4] = num8 * num + j + 1;
					array4[num9 + 5] = num8 * num + j;
				}
			}
		}
		mesh.vertices = array;
		mesh.triangles = array4;
		mesh.uv = array2;
		if (vertexColorH.Length > 0 || vertexColorV.Length > 0)
		{
			mesh.colors = array3;
		}
		mesh.RecalculateNormals();
		Vector3[] normals = mesh.normals;
		for (int k = 0; k < num; k++)
		{
			Vector3 normalized = (normals[k] + normals[split * num + k]).normalized;
			normals[k] = normalized;
			normals[split * num + k] = normalized;
		}
		mesh.normals = normals;
		meshFilter.mesh = mesh;
		if ((bool)material)
		{
			meshRenderer.material = material;
		}
	}

	private int[] TriangleSort(int[] tris, Vector3[] vrts)
	{
		float[] array = new float[tris.Length / 3];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (vrts[tris[i * 3]].z + vrts[tris[i * 3 + 1]].z + vrts[tris[i * 3 + 2]].z) / 3f;
		}
		int[] array2 = new int[0];
		float[] fs = new float[0];
		for (int i = 0; i < array.Length; i++)
		{
			int p = Comparison(fs, array[i]);
			fs = SandWichF(fs, p, array[i]);
			array2 = SandWichI(array2, p, i);
		}
		int[] array3 = new int[tris.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array3[i * 3] = tris[array2[i] * 3];
			array3[i * 3 + 1] = tris[array2[i] * 3 + 1];
			array3[i * 3 + 2] = tris[array2[i] * 3 + 2];
		}
		tris = array3;
		return tris;
	}

	private int Comparison(float[] fs, float f)
	{
		int num = -1;
		int i;
		for (i = 0; i < fs.Length; i++)
		{
			if (f < fs[i])
			{
				num = i;
				i = fs.Length;
			}
		}
		if (num == -1)
		{
			num = i;
		}
		return num;
	}

	private float[] SandWichF(float[] fs, int p, float f)
	{
		float[] array = new float[fs.Length + 1];
		for (int i = 0; i < p; i++)
		{
			array[i] = fs[i];
		}
		array[p] = f;
		for (int i = p; i < fs.Length; i++)
		{
			array[i + 1] = fs[i];
		}
		return array;
	}

	private int[] SandWichI(int[] ints, int p, int n)
	{
		int[] array = new int[ints.Length + 1];
		for (int i = 0; i < p; i++)
		{
			array[i] = ints[i];
		}
		array[p] = n;
		for (int i = p; i < ints.Length; i++)
		{
			array[i + 1] = ints[i];
		}
		return array;
	}

	private void SetPtrMat()
	{
		if (!ptrMat)
		{
			ptrMat = MakePtrMat();
		}
		for (int i = 0; i < step; i++)
		{
			string text = "Pointer";
			if (i < 10)
			{
				text += "0";
			}
			text += i;
			GameObject gameObject = GameObject.Find(text);
			if ((bool)gameObject)
			{
				gameObject.renderer.material = ptrMat;
			}
		}
	}

	private Transform TrashObj()
	{
		if ((bool)trash)
		{
			return trash;
		}
		GameObject gameObject = GameObject.Find("Trash");
		if ((bool)gameObject)
		{
			trash = gameObject.transform;
		}
		else
		{
			trash = new GameObject("Trash").transform;
		}
		return trash;
	}
}
