using UnityEngine;

[ExecuteInEditMode]
public class LiteToVerticesColor : MonoBehaviour
{
	public string lightColorShaderPath = "Custom/AlphaDouble zwrite";

	public GameObject[] meshObjs = new GameObject[0];

	public bool make;

	public bool changeMaterial = true;

	public bool update;

	public bool autoUpdate;

	public bool alphaMode;

	public bool shadow;

	public bool ignoreAmbient;

	public Light[] lights = new Light[0];

	public bool autoFindLights;

	public float multiply = 0.5f;

	private GameObject[] sdwCollis = new GameObject[0];

	private int objNum;

	private Mesh[] meshs = new Mesh[0];

	private Transform trash;

	private int layerMask;

	private void Start()
	{
		layerMask = (layerMask = -2);
		if (autoUpdate && meshs.Length == 0 && meshObjs.Length > 0)
		{
			make = true;
		}
	}

	private void Update()
	{
		if (make)
		{
			MakeMesh();
			UpdateMesh();
			make = false;
		}
		if (update || autoUpdate)
		{
			UpdateMesh();
			update = false;
		}
	}

	private void MakeMesh()
	{
		objNum = meshObjs.Length;
		meshs = new Mesh[objNum];
		sdwCollis = new GameObject[objNum];
		for (int i = 0; i < objNum; i++)
		{
			GameObject gameObject = meshObjs[i];
			if (!gameObject)
			{
				Debug.LogError("No Mesh Obj");
				continue;
			}
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			SkinnedMeshRenderer component2 = gameObject.GetComponent<SkinnedMeshRenderer>();
			Mesh mesh = null;
			if ((bool)component)
			{
				if ((bool)gameObject.GetComponent<MeshFilter>())
				{
					mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
					if (!mesh)
					{
						Debug.LogError("No Base Mesh");
						break;
					}
				}
			}
			else if ((bool)component2)
			{
				mesh = component2.sharedMesh;
				if (!mesh)
				{
					Debug.LogError("No Base Mesh");
					break;
				}
			}
			GameObject gameObject2 = new GameObject(gameObject.name);
			gameObject2.transform.parent = gameObject.transform.parent;
			gameObject2.transform.localPosition = gameObject.transform.localPosition;
			gameObject2.transform.localRotation = gameObject.transform.localRotation;
			gameObject2.transform.localScale = gameObject.transform.localScale;
			MeshRenderer meshRenderer = gameObject2.AddComponent<MeshRenderer>();
			MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
			Mesh mesh2 = new Mesh();
			mesh2.name = mesh.name;
			mesh2.vertices = mesh.vertices;
			mesh2.colors = mesh.colors;
			mesh2.normals = mesh.normals;
			mesh2.uv = mesh.uv;
			mesh2.uv1 = mesh.uv1;
			mesh2.uv2 = mesh.uv2;
			mesh2.triangles = mesh.triangles;
			meshFilter.sharedMesh = mesh2;
			meshs[i] = mesh2;
			if (changeMaterial)
			{
				Material material = new Material(Shader.Find(lightColorShaderPath));
				material.name = "DefaultLiteVertices";
				meshRenderer.sharedMaterial = material;
				if ((bool)component)
				{
					if ((bool)component.sharedMaterial.mainTexture)
					{
						material.mainTexture = component.sharedMaterial.mainTexture;
						material.mainTextureOffset = component.sharedMaterial.mainTextureOffset;
						material.mainTextureScale = component.sharedMaterial.mainTextureScale;
					}
				}
				else if ((bool)component2 && (bool)component2.sharedMaterial.mainTexture)
				{
					material.mainTexture = component2.sharedMaterial.mainTexture;
					material.mainTextureOffset = component2.sharedMaterial.mainTextureOffset;
					material.mainTextureScale = component2.sharedMaterial.mainTextureScale;
				}
			}
			else if ((bool)component)
			{
				meshRenderer.sharedMaterial = component.sharedMaterial;
			}
			else if ((bool)component2)
			{
				meshRenderer.sharedMaterial = component2.sharedMaterial;
			}
			if ((bool)gameObject.GetComponent<MeshCollider>())
			{
				gameObject2.AddComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshCollider>().mesh;
			}
			else if ((bool)gameObject.GetComponent<BoxCollider>())
			{
				BoxCollider boxCollider = gameObject2.AddComponent<BoxCollider>();
				boxCollider.center = gameObject.GetComponent<BoxCollider>().center;
				boxCollider.size = gameObject.GetComponent<BoxCollider>().size;
			}
			else if ((bool)gameObject.GetComponent<SphereCollider>())
			{
				SphereCollider sphereCollider = gameObject2.AddComponent<SphereCollider>();
				sphereCollider.center = gameObject.GetComponent<SphereCollider>().center;
				sphereCollider.radius = gameObject.GetComponent<SphereCollider>().radius;
			}
			else if ((bool)gameObject.GetComponent<CapsuleCollider>())
			{
				CapsuleCollider capsuleCollider = gameObject2.AddComponent<CapsuleCollider>();
				capsuleCollider.center = gameObject.GetComponent<CapsuleCollider>().center;
				capsuleCollider.radius = gameObject.GetComponent<CapsuleCollider>().radius;
				capsuleCollider.height = gameObject.GetComponent<CapsuleCollider>().height;
			}
			gameObject.transform.parent = TrashObj();
			gameObject.SetActive(value: false);
			meshObjs[i] = gameObject2;
			MakeShadowObj(i, mesh2);
		}
	}

	private void MakeShadowObj(int id, Mesh mesh)
	{
		string text = "shadowObj" + id;
		Transform transform = TrashObj().FindChild(text);
		GameObject gameObject = ((!transform) ? new GameObject(text) : transform.gameObject);
		GameObject gameObject2 = meshObjs[id];
		gameObject.transform.parent = TrashObj();
		gameObject.transform.position = gameObject2.transform.position;
		gameObject.transform.rotation = gameObject2.transform.rotation;
		gameObject.transform.localScale = gameObject2.transform.localScale;
		MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
		if (!meshCollider)
		{
			meshCollider = gameObject.AddComponent<MeshCollider>();
		}
		meshCollider.sharedMesh = mesh;
		gameObject.layer = 31;
		sdwCollis[id] = gameObject;
	}

	private void UpdateMesh()
	{
		for (int i = 0; i < objNum; i++)
		{
			GameObject gameObject = meshObjs[i];
			if (!gameObject || !gameObject.activeSelf)
			{
				if ((bool)sdwCollis[i])
				{
					sdwCollis[i].SetActive(value: false);
					sdwCollis[i] = null;
				}
				continue;
			}
			Mesh mesh = meshs[i];
			if (!mesh)
			{
				continue;
			}
			if (shadow)
			{
				if (!sdwCollis[i])
				{
					MakeShadowObj(i, mesh);
				}
				sdwCollis[i].transform.position = gameObject.transform.position;
				sdwCollis[i].transform.rotation = gameObject.transform.rotation;
				sdwCollis[i].transform.localScale = gameObject.transform.localScale;
				sdwCollis[i].collider.enabled = false;
			}
			if (autoFindLights)
			{
				lights = Object.FindObjectsOfType<Light>();
			}
			int num = lights.Length;
			Vector3[] vertices = mesh.vertices;
			int num2 = vertices.Length;
			Vector3[] normals = mesh.normals;
			if (normals == null || normals.Length == 0)
			{
				mesh.RecalculateNormals();
				normals = mesh.normals;
			}
			Color[] array = new Color[num2];
			Vector3 position = gameObject.transform.position;
			Quaternion rotation = gameObject.transform.rotation;
			Vector3 localScale = gameObject.transform.localScale;
			float num3 = 0.01745329f;
			float num4 = 1.570796f;
			for (int j = 0; j < num2; j++)
			{
				Color color = Color.black;
				if (!ignoreAmbient)
				{
					color = RenderSettings.ambientLight;
				}
				if (alphaMode)
				{
					color.a = 0f;
				}
				for (int k = 0; k < num; k++)
				{
					float num5 = 0f;
					if (!lights[k].gameObject.activeInHierarchy)
					{
						continue;
					}
					if (lights[k].type == LightType.Directional)
					{
						Vector3 vector = lights[k].transform.rotation * Vector3.back;
						float num6 = Vector3.Angle(rotation * normals[j], vector);
						bool flag = false;
						if (shadow)
						{
							Vector3 vector2 = vertices[j];
							vector2.x *= localScale.x;
							vector2.y *= localScale.y;
							vector2.z *= localScale.z;
							vector2 = rotation * vector2;
							vector2 += position;
							flag = Physics.Raycast(vector2, vector, 1000f, layerMask);
							if (!flag)
							{
								flag = Physics.Raycast(vector2 + vector.normalized * 1000f, -vector, 1000f, layerMask);
							}
						}
						if (num6 < 90f && !flag)
						{
							num5 = Mathf.Cos(num6 * num3) * 2f;
						}
					}
					else if (lights[k].type == LightType.Point)
					{
						Vector3 vector3 = vertices[j];
						vector3.x *= localScale.x;
						vector3.y *= localScale.y;
						vector3.z *= localScale.z;
						vector3 = rotation * vector3;
						vector3 += position;
						Vector3 vector4 = lights[k].transform.position - vector3;
						float magnitude = vector4.magnitude;
						float num6 = Vector3.Angle(rotation * normals[j], vector4);
						bool flag2 = false;
						if (shadow)
						{
							flag2 = Physics.Raycast(vector3, vector4, magnitude, layerMask);
							if (!flag2)
							{
								flag2 = Physics.Raycast(vector3 + vector4.normalized * magnitude, -vector4, magnitude, layerMask);
							}
						}
						if (num6 < 90f && magnitude < lights[k].range && !flag2)
						{
							float num7 = 1f / lights[k].range * magnitude;
							num5 = Mathf.Cos(num4 * num7) / num7 / 4f;
							num5 *= Mathf.Cos(num6 * num3);
						}
					}
					else if (lights[k].type == LightType.Spot)
					{
						Vector3 vector5 = vertices[j];
						vector5.x *= localScale.x;
						vector5.y *= localScale.y;
						vector5.z *= localScale.z;
						vector5 = rotation * vector5;
						vector5 += position;
						Vector3 vector6 = lights[k].transform.position - vector5;
						float magnitude = vector6.magnitude;
						float num6 = Vector3.Angle(rotation * normals[j], vector6);
						float num8 = Vector3.Angle(lights[k].transform.rotation * Vector3.back, vector6);
						bool flag3 = false;
						if (shadow)
						{
							flag3 = Physics.Raycast(vector5, vector6, magnitude, layerMask);
							if (!flag3)
							{
								flag3 = Physics.Raycast(vector5 + vector6.normalized * magnitude, -vector6, magnitude, layerMask);
							}
						}
						if (num6 < 90f && magnitude < lights[k].range && num8 < lights[k].spotAngle && !flag3)
						{
							float num9 = 1f / lights[k].range * magnitude;
							num5 = Mathf.Cos(num4 * num9) / num9 / 4f;
							num5 *= Mathf.Cos(num4 * num8 / lights[k].spotAngle);
							num5 *= Mathf.Cos(num6 * num3);
						}
					}
					if (lights[k].name.Substring(1, 4) != "inus")
					{
						color += lights[k].color * lights[k].intensity * num5;
					}
					else
					{
						color += (lights[k].color - Color.white) * lights[k].intensity * num5;
					}
				}
				ref Color reference = ref array[j];
				reference = color * multiply;
				if (!alphaMode)
				{
					array[j].a = color.a;
				}
			}
			mesh.colors = array;
			if (shadow)
			{
				sdwCollis[i].collider.enabled = true;
			}
		}
	}

	private Transform TrashObj()
	{
		GameObject gameObject = GameObject.Find("Trash");
		if ((bool)gameObject)
		{
			return gameObject.transform;
		}
		return new GameObject("Trash").transform;
	}
}
