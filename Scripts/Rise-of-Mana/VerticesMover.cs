using UnityEngine;

[ExecuteInEditMode]
public class VerticesMover : MonoBehaviour
{
	public Transform meshObj;

	private MeshFilter meshf;

	private Mesh mesh;

	public bool selVertices;

	private Transform selObj;

	private Transform sizeObj;

	private Material selObjMat;

	private Material sizeObjMat;

	private Material vertObjMat;

	private bool selFlg;

	private bool selVrt;

	private Transform trash;

	private Vector3 selPos = Vector3.zero;

	private float radius;

	private int[] selVerts = new int[0];

	private Transform[] selVerObjs = new Transform[0];

	private Vector3[] lstVerts = new Vector3[0];

	private void Start()
	{
	}

	private void Update()
	{
		if (selVertices)
		{
			DeleteVertObj();
			if (!selObj)
			{
				MakeSelObj();
			}
			selVertices = false;
			selVrt = false;
		}
		if ((bool)selObj && (bool)sizeObj)
		{
			SelObjUpdate();
			selFlg = true;
		}
		else if (selFlg)
		{
			if ((bool)selObj)
			{
				selObj.parent = TrashObj();
				selObj.gameObject.SetActive(value: false);
				selObj = null;
			}
			if ((bool)sizeObj)
			{
				sizeObj.parent = TrashObj();
				sizeObj.gameObject.SetActive(value: false);
				sizeObj = null;
			}
			SelectVertices();
			selFlg = false;
			selVrt = true;
		}
		bool flag = false;
		if (!selVrt || !mesh)
		{
			return;
		}
		for (int i = 0; i < selVerObjs.Length; i++)
		{
			if (selVerObjs[i].position != lstVerts[i])
			{
				flag = true;
				ref Vector3 reference = ref lstVerts[i];
				reference = selVerObjs[i].position;
			}
		}
		if (flag)
		{
			UpdateMesh();
		}
	}

	private void SelObjUpdate()
	{
		Vector3 position = selObj.position;
		Vector3 vector = ((!(position == selPos)) ? (Vector3.right * selObj.localScale.x / 2f) : (sizeObj.position - selObj.position));
		if (vector.x < 0.1f)
		{
			if (position == selPos)
			{
				position.x += vector.x - 0.1f;
			}
			vector.x = 0.1f;
		}
		if (vector.x > 1f)
		{
			if (position == selPos)
			{
				position.x += vector.x - 1f;
			}
			vector.x = 1f;
		}
		position.y += vector.y;
		vector.y = 0f;
		position.z += vector.z;
		vector.z = 0f;
		selPos = position;
		radius = vector.x;
		selObj.position = position;
		sizeObj.position = position + vector;
		selObj.rotation = Quaternion.identity;
		float num = vector.x * 2f;
		selObj.localScale = new Vector3(num, num, num);
	}

	private void MakeSelObj()
	{
		selObj = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
		sizeObj = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
		selObj.parent = base.transform;
		sizeObj.parent = base.transform;
		selObj.name = "SelectArea";
		sizeObj.name = "SelectAreaSize";
		sizeObj.position = selObj.position + new Vector3(-0.5f, 0f, 0f);
		sizeObj.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		selObj.renderer.material = MakeSelMat();
		sizeObj.renderer.material = MakeSizeMat();
	}

	private void SelectVertices()
	{
		if (!meshObj)
		{
			return;
		}
		if (!meshf)
		{
			meshf = meshObj.GetComponent<MeshFilter>();
		}
		if (!meshf)
		{
			return;
		}
		mesh = meshf.sharedMesh;
		selPos -= meshObj.position;
		Vector3[] vertices = mesh.vertices;
		bool[] array = new bool[vertices.Length];
		int num = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			float magnitude = (vertices[i] - selPos).magnitude;
			if (magnitude <= radius)
			{
				array[i] = true;
				num++;
			}
			else
			{
				array[i] = false;
			}
		}
		selVerts = new int[num];
		selVerObjs = new Transform[num];
		lstVerts = new Vector3[num];
		int num2 = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			if (array[i])
			{
				selVerts[num2] = i;
				selVerObjs[num2] = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
				selVerObjs[num2].parent = base.transform;
				string text = "Vertex";
				if (i < 100)
				{
					text += "0";
				}
				if (i < 10)
				{
					text += "0";
				}
				text += i;
				selVerObjs[num2].name = text;
				selVerObjs[num2].localScale = new Vector3(0.02f, 0.02f, 0.02f);
				selVerObjs[num2].renderer.material = MakeVertMat();
				selVerObjs[num2].position = meshObj.position + meshObj.rotation * vertices[i];
				ref Vector3 reference = ref lstVerts[num2];
				reference = selVerObjs[num2].position;
				num2++;
			}
		}
	}

	private void UpdateMesh()
	{
		if ((bool)mesh)
		{
			Vector3[] vertices = mesh.vertices;
			for (int i = 0; i < selVerObjs.Length; i++)
			{
				ref Vector3 reference = ref vertices[selVerts[i]];
				reference = Quaternion.Inverse(meshObj.rotation) * selVerObjs[i].position - meshObj.position;
			}
			mesh.vertices = vertices;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}
	}

	private Material MakeSelMat()
	{
		if ((bool)selObjMat)
		{
			return selObjMat;
		}
		selObjMat = new Material(Shader.Find("Particles/Additive"));
		selObjMat.name = "SelObj";
		selObjMat.SetColor("_TintColor", new Color(0.01f, 0.01f, 0.01f, 1f));
		return selObjMat;
	}

	private Material MakeSizeMat()
	{
		if ((bool)sizeObjMat)
		{
			return sizeObjMat;
		}
		sizeObjMat = new Material(Shader.Find("Diffuse"));
		sizeObjMat.name = "SizeObj";
		sizeObjMat.color = Color.red;
		return sizeObjMat;
	}

	private Material MakeVertMat()
	{
		if ((bool)vertObjMat)
		{
			return vertObjMat;
		}
		vertObjMat = new Material(Shader.Find("Diffuse"));
		vertObjMat.name = "VertObj";
		vertObjMat.color = Color.blue;
		return vertObjMat;
	}

	private void DeleteVertObj()
	{
		for (int i = 0; i < selVerObjs.Length; i++)
		{
			if ((bool)selVerObjs[i])
			{
				selVerObjs[i].parent = TrashObj();
				selVerObjs[i].gameObject.SetActive(value: false);
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
