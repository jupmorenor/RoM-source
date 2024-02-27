using System;
using UnityEngine;

[Serializable]
public class Ef_MeshStorageData
{
	public string name;

	public Vector3[] vertices;

	public Vector2[] uv;

	public Vector2[] uv1;

	public Vector2[] uv2;

	public Vector3[] normals;

	public int[] triangles;

	public Vector4[] tangents;

	public Color[] colors;

	public Ef_MeshStorageData()
	{
		name = string.Empty;
		vertices = new Vector3[0];
		uv = new Vector2[0];
		uv1 = new Vector2[0];
		uv2 = new Vector2[0];
		normals = new Vector3[0];
		triangles = new int[0];
		tangents = new Vector4[0];
		colors = new Color[0];
	}
}
