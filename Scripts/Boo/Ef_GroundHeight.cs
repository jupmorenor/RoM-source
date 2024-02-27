using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_GroundHeight : Ef_Base
{
	public float terrainUp;

	public string planeCollisionTagName;

	private int cullingMask;

	public Ef_GroundHeight()
	{
		terrainUp = 0.3f;
		planeCollisionTagName = "Plane";
		cullingMask = -33292288;
	}

	public virtual void Start()
	{
		cullingMask = ((LayerMask)(1 << LayerMask.NameToLayer(planeCollisionTagName))).value;
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
		return (flag && !flag2) ? new object[3] { true, num, vector } : ((!flag && flag2) ? new object[3] { true, num2, vector2 } : ((flag && flag2) ? ((!(num2 <= num + terrainUp)) ? new object[3] { true, num2, vector2 } : new object[3] { true, num, vector }) : new object[3]
		{
			false,
			pos.y,
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
				Vector3 interpolatedNormal = activeTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
				float num = activeTerrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + activeTerrain.transform.position.y;
				result = new object[3] { true, num, interpolatedNormal };
			}
		}
		return (object[])result;
	}

	public object[] GetPlaneHeight(Vector3 pos)
	{
		RaycastHit hitInfo = default(RaycastHit);
		object result;
		if (!Physics.Raycast(pos + new Vector3(0f, 50f, 0f), Vector3.down, out hitInfo, 100f, cullingMask))
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
			Vector3 normal = hitInfo.normal;
			float y = hitInfo.point.y;
			result = new object[3] { true, y, normal };
		}
		return (object[])result;
	}
}
