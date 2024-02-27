using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SmokeColorEmit : MonoBehaviour
{
	public GameObject smokeObj;

	public GameObject waterObj;

	public float terrainUp;

	public float waterUp;

	public string planeCollisionTagName;

	private int cullingMask;

	private Ef_SmokeColorData colorData;

	private TerrainData terrainData;

	private Vector3 terrainPos;

	private string resultText;

	private float textureIndex1;

	private float textureIndex2;

	public Ef_SmokeColorEmit()
	{
		terrainUp = 0.2f;
		waterUp = 0.2f;
		planeCollisionTagName = "Plane";
		cullingMask = -33292288;
	}

	public void Start()
	{
		if (!Ef_SmokeColorData.current)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		colorData = Ef_SmokeColorData.current.GetComponent<Ef_SmokeColorData>();
		if (!colorData)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		cullingMask = ((LayerMask)(1 << LayerMask.NameToLayer(planeCollisionTagName))).value;
		Vector3 position = transform.position;
		float terrainHeight = GetTerrainHeight(position);
		float planeHeight = GetPlaneHeight(position);
		float waterHeight = GetWaterHeight(position);
		Color color = Color.white;
		if ((bool)colorData.lightTable)
		{
			color = colorData.lightTable.CheckColor(transform.position);
		}
		checked
		{
			if (!(terrainHeight + terrainUp < planeHeight) && !(terrainHeight < waterHeight + waterUp))
			{
				Terrain terrain = colorData.terrain;
				if ((bool)terrain)
				{
					terrainData = terrain.terrainData;
					terrainPos = terrain.transform.position;
					int num = Mathf.RoundToInt((transform.position.x - terrainPos.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
					int num2 = Mathf.RoundToInt((transform.position.z - terrainPos.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
					if (num >= terrainData.alphamapWidth)
					{
						num = terrainData.alphamapWidth - 1;
					}
					else if (num < 0)
					{
						num = 0;
					}
					if (num2 >= terrainData.alphamapHeight)
					{
						num2 = terrainData.alphamapHeight - 1;
					}
					else if (num2 < 0)
					{
						num2 = 0;
					}
					float[,,] alphamaps = terrainData.GetAlphamaps(num, num2, 1, 1);
					int index = 0;
					float num3 = 0f;
					int num4 = default(int);
					IEnumerator<int> enumerator = Builtins.range(colorData.terrainColors.Length).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							num4 = enumerator.Current;
							float num5 = alphamaps[0, 0, num4];
							if (!(num5 < num3))
							{
								index = num4;
								num3 = num5;
							}
						}
					}
					finally
					{
						enumerator.Dispose();
					}
					Color color2;
					if (!(num3 < 0.5f))
					{
						Color[] terrainColors = colorData.terrainColors;
						color2 = terrainColors[RuntimeServices.NormalizeArrayIndex(terrainColors, index)] * color;
					}
					else
					{
						color2 = colorData.floorColor * color;
					}
					Smoke(color2);
				}
			}
			else if (!(planeHeight < waterHeight))
			{
				Color color2 = colorData.floorColor * color;
				Smoke(color2);
			}
			else
			{
				Color color2 = colorData.waterColor * color;
				Water(color2, waterHeight);
			}
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public void Smoke(Color color)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(smokeObj, transform.position, Quaternion.identity);
		gameObject.SendMessage("setColor", color, SendMessageOptions.DontRequireReceiver);
	}

	public void Water(Color color, float waterHeight)
	{
		Vector3 position = transform.position;
		position.y = waterHeight;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(waterObj, position, Quaternion.identity);
		gameObject.SendMessage("setColor", color, SendMessageOptions.DontRequireReceiver);
	}

	public float GetTerrainHeight(Vector3 pos)
	{
		Terrain terrain = colorData.terrain;
		float result;
		if (!terrain || !terrain.terrainData)
		{
			result = -999f;
		}
		else
		{
			Vector3 vector = pos - terrain.transform.position;
			Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, terrain.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, terrain.terrainData.size.z, vector.z));
			float num = terrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + terrain.transform.position.y;
			result = num;
		}
		return result;
	}

	public float GetPlaneHeight(Vector3 pos)
	{
		RaycastHit hitInfo = default(RaycastHit);
		Rigidbody rigidbody = null;
		float result;
		if (Physics.Raycast(pos + new Vector3(0f, 50f, 0f), Vector3.down, out hitInfo, 100f, cullingMask))
		{
			pos = hitInfo.point;
			result = pos.y;
		}
		else
		{
			result = -998f;
		}
		return result;
	}

	public float GetWaterHeight(Vector3 pos)
	{
		Vector3 vector = colorData.WaterMin();
		Vector3 vector2 = colorData.WaterMax();
		float result;
		if (vector == Vector3.zero)
		{
			result = -999f;
		}
		else if (vector2 == Vector3.zero)
		{
			result = -999f;
		}
		else
		{
			bool flag = default(bool);
			if (!(pos.x < vector.x) && !(pos.x > vector2.x) && !(pos.z < vector.z) && !(pos.z > vector2.z))
			{
				flag = true;
			}
			result = ((!flag) ? (-999f) : colorData.waterPlane.transform.position.y);
		}
		return result;
	}
}
