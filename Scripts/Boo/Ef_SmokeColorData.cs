using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SmokeColorData : Ef_Base
{
	[NonSerialized]
	public static GameObject current;

	public Terrain terrain;

	public bool findTerrain;

	public Color[] terrainColors;

	public Color floorColor;

	public Color waterColor;

	public GameObject waterPlane;

	public SceneLightTable lightTable;

	private Vector3 waterMin;

	private Vector3 waterMax;

	private float findTimer;

	private int findCount;

	public Ef_SmokeColorData()
	{
		findTerrain = true;
		terrainColors = new Color[0];
		floorColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
		waterColor = new Color(0.8f, 0.8f, 1f, 0.2f);
		waterMin = Vector3.zero;
		waterMax = Vector3.zero;
		findTimer = 1f;
		findCount = 10;
	}

	public void Start()
	{
		current = gameObject;
		if (!terrain && findTerrain)
		{
			terrain = Terrain.activeTerrain;
		}
		if ((bool)terrain)
		{
			TerrainData terrainData = terrain.terrainData;
			float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, 1, 1);
			if (terrainColors.Length > alphamaps.Length)
			{
				int length = alphamaps.Length;
				Color[] array = new Color[length];
				int num = 0;
				int num2 = length;
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int index = num;
					num++;
					ref Color reference = ref array[RuntimeServices.NormalizeArrayIndex(array, index)];
					Color[] array2 = terrainColors;
					reference = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				}
				terrainColors = array;
			}
		}
		if ((bool)waterPlane)
		{
			waterMin = waterPlane.transform.position + new Vector3(-5f * waterPlane.transform.localScale.x, 0f, -5f * waterPlane.transform.localScale.z);
			waterMax = waterPlane.transform.position + new Vector3(5f * waterPlane.transform.localScale.x, 0f, 5f * waterPlane.transform.localScale.z);
		}
	}

	public void Update()
	{
		checked
		{
			if (!lightTable && findCount > 0)
			{
				findTimer -= deltaTime;
				if (!(findTimer > 0f))
				{
					lightTable = ((SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable))) as SceneLightTable;
					findTimer = 1f;
					findCount--;
				}
			}
		}
	}

	public Vector3 WaterMin()
	{
		return waterMin;
	}

	public Vector3 WaterMax()
	{
		return waterMax;
	}
}
