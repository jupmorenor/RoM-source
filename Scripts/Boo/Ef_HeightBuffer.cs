using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightBuffer : MonoBehaviour
{
	[NonSerialized]
	private static Ef_HeightBuffer current;

	[NonSerialized]
	private const int rootBufferSize = 80;

	private int[] indexBuffer;

	private float[] heightBuffer;

	private Vector3[] normalBuffer;

	[NonSerialized]
	private const float terrainUp = 0.3f;

	[NonSerialized]
	private const string planeCollisionTagName = "Plane";

	private int cullingMask;

	private bool ready;

	private bool useTerrain;

	private bool usePlane;

	private GameObject terrainObj;

	private GameObject planeObj;

	public static Ef_HeightBuffer Current
	{
		get
		{
			if (current == null)
			{
				Ef_HeightBuffer ef_HeightBuffer = new GameObject("Ef_HeightBuffer").AddComponent<Ef_HeightBuffer>();
				ef_HeightBuffer.Initialize();
				current = ef_HeightBuffer;
			}
			return current;
		}
	}

	public Ef_HeightBuffer()
	{
		cullingMask = -33292288;
	}

	public void Initialize()
	{
		int num = 6400;
		indexBuffer = new int[num];
		heightBuffer = new float[num];
		normalBuffer = new Vector3[num];
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(num).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num2 = enumerator.Current;
				int[] array = indexBuffer;
				array[RuntimeServices.NormalizeArrayIndex(array, num2)] = 99999999;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		cullingMask = ((LayerMask)(1 << LayerMask.NameToLayer("Plane"))).value;
		ready = true;
	}

	public object[] GetHeight(Vector3 pos)
	{
		checked
		{
			object result;
			if (!ready)
			{
				UnityEngine.Object.Destroy(gameObject);
				result = null;
			}
			else
			{
				float num = pos[0];
				float num2 = pos[2];
				int num3 = Mathf.FloorToInt(num);
				int num4 = Mathf.FloorToInt(num2);
				float num5 = num % 1f;
				float num6 = num2 % 1f;
				if (!(num5 >= 0f))
				{
					num5 += 1f;
				}
				if (!(num6 >= 0f))
				{
					num6 += 1f;
				}
				float num7 = (1f - num6) * (1f - num5);
				float num8 = (1f - num6) * num5;
				float num9 = num6 * (1f - num5);
				float num10 = num6 * num5;
				object[] mapHight = GetMapHight(num3, num4);
				float num11 = RuntimeServices.UnboxSingle(mapHight[0]);
				Vector3 vector = (Vector3)mapHight[1];
				object[] mapHight2 = GetMapHight(num3 + 1, num4);
				float num12 = RuntimeServices.UnboxSingle(mapHight2[0]);
				Vector3 vector2 = (Vector3)mapHight2[1];
				object[] mapHight3 = GetMapHight(num3, num4 + 1);
				float num13 = RuntimeServices.UnboxSingle(mapHight3[0]);
				Vector3 vector3 = (Vector3)mapHight3[1];
				object[] mapHight4 = GetMapHight(num3 + 1, num4 + 1);
				float num14 = RuntimeServices.UnboxSingle(mapHight4[0]);
				Vector3 vector4 = (Vector3)mapHight4[1];
				float num15 = num11 * num7 + num12 * num8 + num13 * num9 + num14 * num10;
				Vector3 vector5 = vector * num7 + vector2 * num8 + vector3 * num9 + vector4 * num10;
				result = new object[2] { num15, vector5 };
			}
			return (object[])result;
		}
	}

	public object[] GetMapHight(int mapX, int mapY)
	{
		int num = checked((mapY + 1024) * 1024 + (mapX + 1024));
		int num2 = mapX % 80;
		int num3 = mapY % 80;
		checked
		{
			if (num2 < 0)
			{
				num2 += 80;
			}
			if (num3 < 0)
			{
				num3 += 80;
			}
			int index = num2 + num3 * 80;
			int[] array = indexBuffer;
			object obj;
			if (array[RuntimeServices.NormalizeArrayIndex(array, index)] == num)
			{
				obj = new object[2];
				object obj2 = obj;
				float[] array2 = heightBuffer;
				((object[])obj2)[0] = array2[RuntimeServices.NormalizeArrayIndex(array2, index)];
				object obj3 = obj;
				Vector3[] array3 = normalBuffer;
				((object[])obj3)[1] = array3[RuntimeServices.NormalizeArrayIndex(array3, index)];
			}
			else
			{
				object[] groundHeight = GetGroundHeight(new Vector3(mapX, 0f, mapY));
				float num4 = RuntimeServices.UnboxSingle(groundHeight[0]);
				Vector3 vector = (Vector3)groundHeight[1];
				float[] array4 = heightBuffer;
				array4[RuntimeServices.NormalizeArrayIndex(array4, index)] = num4;
				Vector3[] array5 = normalBuffer;
				array5[RuntimeServices.NormalizeArrayIndex(array5, index)] = vector;
				int[] array6 = indexBuffer;
				array6[RuntimeServices.NormalizeArrayIndex(array6, index)] = num;
				obj = new object[2] { num4, vector };
			}
			return (object[])obj;
		}
	}

	public object[] GetGroundHeight(Vector3 pos)
	{
		object[] terrainHeight = GetTerrainHeight(pos);
		bool flag = RuntimeServices.UnboxBoolean(terrainHeight[0]);
		float num = RuntimeServices.UnboxSingle(terrainHeight[1]);
		Vector3 vector = (Vector3)terrainHeight[2];
		object[] planeHeight = GetPlaneHeight(pos);
		bool flag2 = RuntimeServices.UnboxBoolean(planeHeight[0]);
		float num2 = RuntimeServices.UnboxSingle(planeHeight[1]);
		Vector3 vector2 = (Vector3)planeHeight[2];
		return (flag && !flag2) ? new object[2] { num, vector } : ((!flag && flag2) ? new object[2] { num2, vector2 } : ((flag && flag2) ? ((!(num + 0.3f <= num2)) ? new object[2] { num, vector } : new object[2] { num2, vector2 }) : new object[2]
		{
			0f,
			Vector3.up
		}));
	}

	public object[] GetTerrainHeight(Vector3 pos)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		object result;
		if (!activeTerrain || !activeTerrain.terrainData)
		{
			result = new object[3]
			{
				false,
				0f,
				Vector3.up
			};
		}
		else
		{
			if (!terrainObj)
			{
				terrainObj = activeTerrain.gameObject;
				useTerrain = true;
			}
			Vector3 position = activeTerrain.transform.position;
			Vector3 size = activeTerrain.terrainData.size;
			if (pos.x < position.x || pos.x > position.x + size.x || pos.z < position.z || !(pos.z <= position.z + size.z))
			{
				result = new object[3]
				{
					false,
					0f,
					Vector3.up
				};
			}
			else
			{
				Vector3 vector = pos - activeTerrain.transform.position;
				Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, size.x, vector.x), Mathf.InverseLerp(0f, size.z, vector.z));
				float num = activeTerrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + activeTerrain.transform.position.y;
				Vector3 interpolatedNormal = activeTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
				result = new object[3] { true, num, interpolatedNormal };
			}
		}
		return (object[])result;
	}

	public object[] GetPlaneHeight(Vector3 pos)
	{
		RaycastHit hitInfo = default(RaycastHit);
		object result;
		if (!Physics.Raycast(pos + new Vector3(0f, 100f, 0f), Vector3.down, out hitInfo, 200f, cullingMask))
		{
			result = new object[3]
			{
				false,
				0f,
				Vector3.up
			};
		}
		else
		{
			if (!planeObj)
			{
				planeObj = hitInfo.collider.gameObject;
				usePlane = true;
			}
			result = new object[3]
			{
				true,
				hitInfo.point.y,
				hitInfo.normal
			};
		}
		return (object[])result;
	}

	public void Update()
	{
		if ((useTerrain && !terrainObj) || (usePlane && !planeObj))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
