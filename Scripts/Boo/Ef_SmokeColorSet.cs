using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SmokeColorSet : Ef_Base
{
	public GameObject[] smokeObjs;

	public float terrainUp;

	public float waterUp;

	public bool ignoreAlpha;

	public string planeCollisionTagName;

	public bool evelyFlame;

	public float rapidTime;

	private int cullingMask;

	private int leng;

	private Ef_SmokeColorData colorData;

	private TerrainData terrainData;

	private Vector3 terrainPos;

	private string resultText;

	private float textureIndex1;

	private float textureIndex2;

	private float fstRapid;

	private bool ready;

	public Ef_SmokeColorSet()
	{
		terrainUp = 0.2f;
		waterUp = 0.2f;
		planeCollisionTagName = "Plane";
		rapidTime = 0.2f;
		cullingMask = -33292288;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		Check();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Check();
	}

	public void Init()
	{
		leng = smokeObjs.Length;
		if (leng == 0)
		{
			smokeObjs = new GameObject[1];
			smokeObjs[0] = gameObject;
			leng = 1;
		}
		if (evelyFlame && rapidTime == 0f)
		{
			rapidTime = 0.2f;
		}
		fstRapid = rapidTime;
		cullingMask = ((LayerMask)(1 << LayerMask.NameToLayer(planeCollisionTagName))).value;
		ready = true;
	}

	public void Update()
	{
		if (evelyFlame)
		{
			rapidTime -= deltaTime;
			if (!(rapidTime > 0f))
			{
				Check();
				rapidTime += fstRapid;
			}
		}
	}

	public void Check()
	{
		int num = default(int);
		if (!Ef_SmokeColorData.current)
		{
			EmitOnError();
			return;
		}
		colorData = Ef_SmokeColorData.current.GetComponent<Ef_SmokeColorData>();
		if (!colorData)
		{
			EmitOnError();
			return;
		}
		Vector3 position = transform.position;
		float terrainHeight = GetTerrainHeight(position);
		float planeHeight = GetPlaneHeight(position);
		float waterHeight = GetWaterHeight(position);
		Color color = Color.white;
		if (colorData.lightTable != null)
		{
			color = colorData.lightTable.CheckColor(transform.position);
		}
		checked
		{
			Color startColor = default(Color);
			if (terrainHeight + terrainUp < planeHeight || terrainHeight < waterHeight + waterUp)
			{
				startColor = ((planeHeight < waterHeight) ? (colorData.waterColor * color) : (colorData.floorColor * color));
			}
			else
			{
				Terrain terrain = colorData.terrain;
				if ((bool)terrain)
				{
					terrainData = Terrain.activeTerrain.terrainData;
					terrainPos = Terrain.activeTerrain.transform.position;
					int num2 = Mathf.RoundToInt((transform.position.x - terrainPos.x) / terrainData.size.x * (float)terrainData.alphamapWidth);
					int num3 = Mathf.RoundToInt((transform.position.z - terrainPos.z) / terrainData.size.z * (float)terrainData.alphamapHeight);
					if (num2 >= terrainData.alphamapWidth)
					{
						num2 = terrainData.alphamapWidth - 1;
					}
					else if (num2 < 0)
					{
						num2 = 0;
					}
					if (num3 >= terrainData.alphamapHeight)
					{
						num3 = terrainData.alphamapHeight - 1;
					}
					else if (num3 < 0)
					{
						num3 = 0;
					}
					float[,,] alphamaps = terrainData.GetAlphamaps(num2, num3, 1, 1);
					int index = 0;
					float num4 = 0f;
					IEnumerator<int> enumerator = Builtins.range(colorData.terrainColors.Length).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							num = enumerator.Current;
							float num5 = alphamaps[0, 0, num];
							if (!(num5 < num4))
							{
								index = num;
								num4 = num5;
							}
						}
					}
					finally
					{
						enumerator.Dispose();
					}
					if (!(num4 < 0.5f))
					{
						Color[] terrainColors = colorData.terrainColors;
						startColor = terrainColors[RuntimeServices.NormalizeArrayIndex(terrainColors, index)] * color;
					}
					else
					{
						startColor = colorData.floorColor * color;
					}
				}
			}
			IEnumerator<int> enumerator2 = Builtins.range(leng).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					GameObject[] array = smokeObjs;
					if (array[RuntimeServices.NormalizeArrayIndex(array, num)] == null)
					{
						continue;
					}
					GameObject[] array2 = smokeObjs;
					ParticleSystem particleSystem = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].particleSystem;
					if (particleSystem != null)
					{
						if (!ignoreAlpha)
						{
							particleSystem.startColor = startColor;
						}
						else
						{
							Color startColor2 = particleSystem.startColor;
							startColor2.r = startColor.r;
							startColor2.g = startColor.g;
							startColor2.b = startColor.b;
							particleSystem.startColor = startColor2;
						}
						if (!evelyFlame && !particleSystem.playOnAwake)
						{
							particleSystem.Play();
						}
					}
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	public void EmitOnError()
	{
		int num = 0;
		int num2 = leng;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			GameObject[] array = smokeObjs;
			if (!(array[RuntimeServices.NormalizeArrayIndex(array, index)] == null))
			{
				GameObject[] array2 = smokeObjs;
				ParticleSystem particleSystem = array2[RuntimeServices.NormalizeArrayIndex(array2, index)].particleSystem;
				if (particleSystem != null && !evelyFlame && !particleSystem.playOnAwake)
				{
					particleSystem.Play();
				}
			}
		}
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
