using System;
using UnityEngine;

[Serializable]
public class TerrainFollower : MonoBehaviour
{
	public bool enable;

	private bool lstEna;

	public TerrainFollower()
	{
		enable = true;
		lstEna = true;
	}

	public void Update()
	{
		if (enable)
		{
			object[] terrainHeight = GetTerrainHeight(transform.position);
			object obj = terrainHeight[0];
			object obj2 = terrainHeight[1];
			transform.rotation = Quaternion.FromToRotation(transform.up, (Vector3)obj2) * transform.rotation;
			lstEna = true;
		}
		else if (lstEna)
		{
			transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
			lstEna = false;
		}
	}

	public object[] GetTerrainHeight(Vector3 pos)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		object result;
		if (!activeTerrain || !activeTerrain.terrainData)
		{
			pos.y = 0f;
			result = new object[2]
			{
				0f,
				Vector3.up
			};
		}
		else
		{
			Vector3 vector = pos - activeTerrain.transform.position;
			Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, activeTerrain.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, activeTerrain.terrainData.size.z, vector.z));
			Vector3 interpolatedNormal = activeTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
			float num = activeTerrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + activeTerrain.transform.position.y;
			result = new object[2] { num, interpolatedNormal };
		}
		return (object[])result;
	}
}
