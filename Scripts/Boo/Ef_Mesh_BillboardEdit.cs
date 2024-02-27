using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class Ef_Mesh_BillboardEdit : MonoBehaviour
{
	public float texWidth;

	public float texHeight;

	public float chipSizeX;

	public float chipSizeY;

	public int charNo;

	public int abyss;

	public int offsetX;

	public int offsetY;

	public int depth;

	public bool pixelSize;

	public float spriteSize;

	public float offsetPosX;

	public float offsetPosY;

	public bool updateBillboard;

	public bool autoUpdate;

	private Ef_Mesh emesh;

	private int uvx0;

	private int uvy0;

	private int uvx1;

	private int uvy1;

	private Mesh mesh;

	private float vdep;

	private bool ready;

	public Ef_Mesh_BillboardEdit()
	{
		texWidth = 128f;
		texHeight = 128f;
		chipSizeX = 32f;
		chipSizeY = 32f;
		charNo = -1;
		abyss = 1;
		spriteSize = 1f;
		uvx1 = 9999;
		uvy1 = 9999;
	}

	public void Start()
	{
		emesh = gameObject.GetComponent<Ef_Mesh>();
		if (!(emesh == null))
		{
			emesh.UpdateMesh();
			GetTexture();
			ready = true;
		}
	}

	public void Update()
	{
		if (ready)
		{
			if (updateBillboard || autoUpdate)
			{
				UpdateBillboard();
				updateBillboard = false;
			}
			emesh.UpdateMesh();
		}
	}

	public void GetTexture()
	{
		Material material = emesh.material;
		Texture mainTexture = material.mainTexture;
		if (!(mainTexture == null))
		{
			texWidth = mainTexture.width;
			texHeight = mainTexture.height;
		}
	}

	public void UpdateBillboard()
	{
		GetTexture();
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
			SetMeshState();
		}
	}

	public void SetMeshState()
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
		if (!pixelSize)
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
		Vector2[] uvs = new Vector2[4]
		{
			new Vector2((chipSizeX * (float)uvx0 + (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy0 - (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx1 - (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy0 - (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx0 + (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy1 + (float)abyss + (float)offsetY) / texHeight),
			new Vector2((chipSizeX * (float)uvx1 - (float)abyss + (float)offsetX) / texWidth, (texHeight - chipSizeY * (float)uvy1 + (float)abyss + (float)offsetY) / texHeight)
		};
		int[] triangles = new int[6] { 0, 1, 2, 2, 1, 3 };
		emesh.vertices = array;
		emesh.uvs = uvs;
		emesh.uv2s = new Vector2[0];
		emesh.triangles = triangles;
		emesh.colors = new Color32[0];
		emesh.normals = new Vector3[0];
		emesh.UpdateMesh();
	}
}
