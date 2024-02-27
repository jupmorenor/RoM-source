using System;
using UnityEngine;

[Serializable]
public class PixelToMeshBoo : MonoBehaviour
{
	public Material material;

	public Texture texture;

	public float texWidth;

	public float texHeight;

	public float chipSizeX;

	public float chipSizeY;

	public int charNo;

	public int abyss;

	public int offsetX;

	public int offsetY;

	public int depth;

	public float spriteSize;

	public float offsetPosX;

	public float offsetPosY;

	public bool update;

	public bool autoUpdate;

	private Material mat;

	private int uvx0;

	private int uvy0;

	private int uvx1;

	private int uvy1;

	private Mesh mesh;

	private float vdep;

	private bool ready;

	public PixelToMeshBoo()
	{
		texWidth = 128f;
		texHeight = 128f;
		chipSizeX = 32f;
		chipSizeY = 32f;
		charNo = -1;
		abyss = 1;
		spriteSize = -1f;
		uvx1 = 9999;
		uvy1 = 9999;
	}

	public void Awake()
	{
		PixelToMeshBoo_Edit component = gameObject.GetComponent<PixelToMeshBoo_Edit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		if (!ready && !autoUpdate)
		{
			UpdateMesh();
			ready = true;
		}
	}

	public void OnDeactive()
	{
		PixelToMeshBoo_Edit component = gameObject.GetComponent<PixelToMeshBoo_Edit>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		if (!ready && !autoUpdate)
		{
			UpdateMesh();
			ready = true;
		}
	}

	public void LateUpdate()
	{
		if (update || autoUpdate)
		{
			UpdateMesh();
			update = false;
		}
	}

	public void UpdateMesh()
	{
		if (material == null)
		{
			return;
		}
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = gameObject.AddComponent<MeshFilter>();
		}
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.name = gameObject.name;
			meshFilter.sharedMesh = mesh;
		}
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		if (component == null)
		{
			component = gameObject.AddComponent<MeshRenderer>();
			component.material = material;
		}
		checked
		{
			if (depth != 0)
			{
				if (depth > 10)
				{
					depth = 10;
				}
				if (depth < -10)
				{
					depth = -10;
				}
				if (spriteSize == -1f)
				{
					vdep = -depth;
				}
				else
				{
					vdep = 0.005f * (float)(-depth);
				}
			}
			if (texture == null)
			{
				texture = material.GetTexture("_MainTex");
				if (texture == null)
				{
					return;
				}
			}
			texWidth = texture.width;
			texHeight = texture.height;
			if (charNo != -1)
			{
				int num = Mathf.FloorToInt(texWidth / chipSizeX);
				unchecked
				{
					uvx0 = Mathf.FloorToInt(charNo % num);
					uvy0 = Mathf.FloorToInt(charNo / num);
				}
				uvx1 = uvx0 + 1;
				uvy1 = uvy0 + 1;
			}
			else
			{
				uvx0 = -1;
				uvy0 = -1;
				uvx1 = 0;
				uvy1 = 0;
			}
			MakeMesh();
		}
	}

	public void MakeMesh()
	{
		Vector3[] array = new Vector3[4];
		float num = chipSizeX * (float)uvx0;
		float num2 = texHeight - chipSizeY * (float)uvy0;
		float num3 = chipSizeX * (float)uvx1;
		float num4 = texHeight - chipSizeY * (float)uvy1;
		if (charNo != -1)
		{
			num += (float)abyss;
			num2 -= (float)abyss;
			num3 -= (float)abyss;
			num4 += (float)abyss;
		}
		float num5 = (num + num3) / 2f;
		float num6 = (num2 + num4) / 2f;
		num -= num5;
		num2 -= num6;
		num3 -= num5;
		num4 -= num6;
		if (!(spriteSize <= -1f))
		{
			float num7 = default(float);
			num7 = ((num3 - num <= num4 - num2) ? (num3 - num) : (num2 - num4));
			num = num / num7 * spriteSize;
			num3 = num3 / num7 * spriteSize;
			num2 = num2 / num7 * spriteSize;
			num4 = num4 / num7 * spriteSize;
		}
		ref Vector3 reference = ref array[0];
		reference = new Vector3(num + offsetPosX, num2 + offsetPosY, vdep);
		ref Vector3 reference2 = ref array[1];
		reference2 = new Vector3(num3 + offsetPosX, num2 + offsetPosY, vdep);
		ref Vector3 reference3 = ref array[2];
		reference3 = new Vector3(num + offsetPosX, num4 + offsetPosY, vdep);
		ref Vector3 reference4 = ref array[3];
		reference4 = new Vector3(num3 + offsetPosX, num4 + offsetPosY, vdep);
		Vector2[] uv = new Vector2[4]
		{
			new Vector2((chipSizeX * (float)uvx0 + (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy0 - (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx1 - (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy0 - (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx0 + (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy1 + (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx1 - (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy1 + (float)abyss + (float)offsetY) / texHeight)
		};
		int[] triangles = new int[6] { 0, 1, 2, 2, 1, 3 };
		mesh.vertices = array;
		mesh.uv = uv;
		mesh.triangles = triangles;
	}

	public void OnDestroy()
	{
		if (mesh != null)
		{
			UnityEngine.Object.Destroy(mesh);
		}
	}
}
