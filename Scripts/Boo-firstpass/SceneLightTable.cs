using System;
using System.Text;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class SceneLightTable : MonoBehaviour
{
	[NonSerialized]
	public static bool EnableLightTable = true;

	public Color[] lightTable;

	public float x;

	public float y;

	public float z;

	public float distance;

	public float offsetY;

	public bool addAmbient;

	public bool minIsAmbient;

	[HideInInspector]
	public float scaleRate;

	[HideInInspector]
	public Color min;

	[HideInInspector]
	public Color intensity;

	[HideInInspector]
	public Color max;

	protected float[] rgb3;

	public float width;

	public float length;

	public bool alwaysShowGizmo;

	public bool showLightColorGizmo;

	public bool adjustColorGizmo;

	public float lightColorGizmoScale;

	public int currentSelectLightColorGizmo;

	protected int gizmoCount;

	protected LightProbes lightProbes;

	protected Terrain tera;

	protected TerrainData teraData;

	public SceneLightTable()
	{
		offsetY = 1f;
		minIsAmbient = true;
		scaleRate = 1f;
		min = new Color(0f, 0f, 0f);
		intensity = new Color(1f, 1f, 1f);
		max = new Color(1f, 1f, 1f);
		rgb3 = new float[27];
		showLightColorGizmo = true;
		adjustColorGizmo = true;
		lightColorGizmoScale = 1f;
		currentSelectLightColorGizmo = -1;
	}

	public void Start()
	{
		LightmapSettings lightmapSettings = (LightmapSettings)UnityEngine.Object.FindObjectOfType(typeof(LightmapSettings));
		if ((bool)lightmapSettings)
		{
			lightProbes = LightmapSettings.lightProbes;
		}
	}

	public void Update()
	{
		int num = 0;
		while (num < 3)
		{
			int index = num;
			num++;
			if (!(max[index] >= min[index]))
			{
				min[index] = max[index];
			}
		}
		if (minIsAmbient)
		{
			addAmbient = false;
		}
		if (minIsAmbient)
		{
			minIsAmbient = false;
			if (!(scaleRate <= 0f))
			{
				min.r = RenderSettings.ambientLight.r / scaleRate;
				min.g = RenderSettings.ambientLight.g / scaleRate;
				min.b = RenderSettings.ambientLight.b / scaleRate;
			}
		}
	}

	public void FixedUpdate()
	{
		checked
		{
			gizmoCount++;
		}
	}

	public void OnGUI_()
	{
	}

	public void OnDrawGizmos()
	{
		if (alwaysShowGizmo)
		{
			DrawCustomGizmo();
		}
	}

	public void OnDrawGizmosSelected()
	{
		DrawCustomGizmo();
	}

	public void DrawCustomGizmo()
	{
		if (lightTable == null || !showLightColorGizmo || !enabled)
		{
			return;
		}
		Terrain terrain = (Terrain)UnityEngine.Object.FindObjectOfType(typeof(Terrain));
		TerrainData terrainData = default(TerrainData);
		if ((bool)terrain)
		{
			terrainData = terrain.terrainData;
		}
		checked
		{
			int num = 1 + (int)(width / distance);
			int num2 = 1 + (int)(length / distance);
			int num3 = 0;
			double num4 = 0.0;
			int i = 0;
			int num5 = 0;
			for (; i < num; i++)
			{
				double num6 = 0.0;
				for (num5 = 0; num5 < num2; num5++)
				{
					int num7 = 0;
					if ((bool)terrainData)
					{
						num7 = (int)terrainData.GetInterpolatedHeight((float)(num4 / (double)terrainData.size.x), (float)(num6 / (double)terrainData.size.z));
					}
					Vector3 center = new Vector3((float)((double)x + num4), y + (float)num7 + lightColorGizmoScale + offsetY, (float)((double)z + num6));
					Color[] array = lightTable;
					Color color = array[RuntimeServices.NormalizeArrayIndex(array, num3)];
					if (adjustColorGizmo)
					{
						color = CorrectColor(color);
					}
					if (num3 == currentSelectLightColorGizmo)
					{
						Gizmos.color = Color.red;
						Gizmos.DrawWireSphere(center, (float)((double)lightColorGizmoScale * 1.2));
					}
					Gizmos.color = color;
					Gizmos.DrawSphere(center, lightColorGizmoScale);
					num3++;
					num6 += (double)distance;
				}
				num4 += (double)distance;
			}
		}
	}

	public void CreateLightTable()
	{
		if (distance == 0f)
		{
			Debug.Log(new StringBuilder("ERROR: Create Light Table, distance = ").Append(distance).ToString());
			return;
		}
		LightmapSettings lightmapSettings = (LightmapSettings)UnityEngine.Object.FindObjectOfType(typeof(LightmapSettings));
		if ((bool)lightmapSettings)
		{
			lightProbes = LightmapSettings.lightProbes;
		}
		if (!lightProbes)
		{
			Debug.Log(new StringBuilder("ERROR: Create Light Table, lightProbes = ").Append(lightProbes).ToString());
			return;
		}
		bool flag = false;
		tera = (Terrain)UnityEngine.Object.FindObjectOfType(typeof(Terrain));
		if ((bool)tera)
		{
			teraData = tera.terrainData;
		}
		checked
		{
			int num = 1 + (int)(width / distance);
			int num2 = 1 + (int)(length / distance);
			lightTable = new Color[num * num2];
			int num3 = 0;
			double num4 = 0.0;
			int i = 0;
			int num5 = 0;
			for (; i < num; i++)
			{
				double num6 = 0.0;
				for (num5 = 0; num5 < num2; num5++)
				{
					int num7 = 0;
					if ((bool)teraData)
					{
						num7 = (int)teraData.GetInterpolatedHeight((float)(num4 / (double)teraData.size.x), (float)(num6 / (double)teraData.size.z));
					}
					Debug.Log(new StringBuilder("tmpw, tmpl = ").Append(num4).Append(", ").Append(num6)
						.ToString());
					Debug.Log(new StringBuilder("pos = ( ").Append((double)x + num4).Append(", ").Append((double)z + num6)
						.Append(" )")
						.ToString());
					Vector3 position = new Vector3((float)((double)x + num4), y + (float)num7 + offsetY, (float)((double)z + num6));
					lightProbes.GetInterpolatedLightProbe(position, null, rgb3);
					Color[] array = lightTable;
					ref Color reference = ref array[RuntimeServices.NormalizeArrayIndex(array, num3)];
					reference = CalcColorFromCoeffs(new Vector3(0f, 1f, 0f), rgb3);
					StringBuilder stringBuilder = new StringBuilder("LightTable Create (").Append((object)i).Append(",").Append((object)num5)
						.Append(")=");
					Color[] array2 = lightTable;
					Debug.Log(stringBuilder.Append(array2[RuntimeServices.NormalizeArrayIndex(array2, num3)]).ToString());
					num3++;
					num6 += (double)distance;
				}
				num4 += (double)distance;
			}
			Debug.Log("SUCCESS : Create Light Table ");
		}
	}

	public Color CalcColorFromCoeffs(Vector3 direction, float[] coeffs)
	{
		float num = 0.2820948f;
		float num2 = 0.48860252f;
		float num3 = 1.0925485f;
		float num4 = 0.9461747f;
		float num5 = 0.54627424f;
		float num6 = 1f / 3f;
		float[] array = new float[9]
		{
			num,
			(0f - direction.y) * num2,
			direction.z * num2,
			(0f - direction.x) * num2,
			direction.x * direction.y * num3,
			(0f - direction.y) * direction.z * num3,
			(direction.z * direction.z - num6) * num4,
			(0f - direction.x) * direction.z * num3,
			(direction.x * direction.x - direction.y * direction.y) * num5
		};
		float num7 = 2.956793f;
		float num8 = default(float);
		float num9 = default(float);
		float num10 = default(float);
		checked
		{
			for (int i = 0; i < 9; i++)
			{
				float num11 = array[RuntimeServices.NormalizeArrayIndex(array, i)];
				num8 += coeffs[RuntimeServices.NormalizeArrayIndex(coeffs, 3 * i + 0)] * num11;
				num9 += coeffs[RuntimeServices.NormalizeArrayIndex(coeffs, 3 * i + 1)] * num11;
				num10 += coeffs[RuntimeServices.NormalizeArrayIndex(coeffs, 3 * i + 2)] * num11;
			}
			return new Color(num8, num9, num10);
		}
	}

	public Color CheckColor(Vector3 pos)
	{
		checked
		{
			Color result;
			if (!EnableLightTable)
			{
				result = new Color(1f, 1f, 1f);
			}
			else if (distance == 0f)
			{
				result = new Color(1f, 1f, 1f);
			}
			else if (lightTable == null)
			{
				result = new Color(1f, 1f, 1f);
			}
			else
			{
				float num = 1f / distance;
				int num2 = 1 + (int)(width * num);
				int num3 = 1 + (int)(length * num);
				int num4 = (int)((pos.x - x) * num);
				int num5 = (int)((pos.z - z) * num);
				if (0 > num4)
				{
					num4 = 0;
				}
				if (0 > num5)
				{
					num5 = 0;
				}
				if (num2 <= num4)
				{
					num4 = num2 - 1;
				}
				if (num3 <= num5)
				{
					num5 = num3 - 1;
				}
				int num6 = num4 + 1;
				int num7 = num5 + 1;
				if (num2 <= num6)
				{
					num6 = num2 - 1;
				}
				if (num3 <= num7)
				{
					num7 = num3 - 1;
				}
				float num8 = (pos.x - x - distance * (float)num4) * num;
				float num9 = (pos.z - z - distance * (float)num5) * num;
				float magnitude = new Vector2(num8, num9).magnitude;
				float magnitude2 = new Vector2((float)(1.0 - (double)num8), num9).magnitude;
				float magnitude3 = new Vector2(num8, (float)(1.0 - (double)num9)).magnitude;
				float magnitude4 = new Vector2((float)(1.0 - (double)num8), (float)(1.0 - (double)num9)).magnitude;
				float num10 = magnitude + magnitude2 + magnitude3 + magnitude4;
				Color c = new Color(0.5f, 0.5f, 0.5f);
				if (!(num10 <= 0f))
				{
					if (magnitude == 0f)
					{
						magnitude = 1f;
						magnitude2 = 0f;
						magnitude3 = 0f;
						magnitude4 = 0f;
					}
					else if (magnitude2 == 0f)
					{
						magnitude = 0f;
						magnitude2 = 1f;
						magnitude3 = 0f;
						magnitude4 = 0f;
					}
					else if (magnitude3 == 0f)
					{
						magnitude = 0f;
						magnitude2 = 0f;
						magnitude3 = 1f;
						magnitude4 = 0f;
					}
					else if (magnitude4 == 0f)
					{
						magnitude = 0f;
						magnitude2 = 0f;
						magnitude3 = 0f;
						magnitude4 = 1f;
					}
					else
					{
						magnitude = num10 / magnitude;
						magnitude2 = num10 / magnitude2;
						magnitude3 = num10 / magnitude3;
						magnitude4 = num10 / magnitude4;
						num10 = magnitude + magnitude2 + magnitude3 + magnitude4;
						magnitude /= num10;
						magnitude2 /= num10;
						magnitude3 /= num10;
						magnitude4 /= num10;
					}
					Color[] array = lightTable;
					Color color = array[RuntimeServices.NormalizeArrayIndex(array, num4 * num3 + num5)] * magnitude;
					Color[] array2 = lightTable;
					Color color2 = color + array2[RuntimeServices.NormalizeArrayIndex(array2, num6 * num3 + num5)] * magnitude2;
					Color[] array3 = lightTable;
					Color color3 = color2 + array3[RuntimeServices.NormalizeArrayIndex(array3, num4 * num3 + num7)] * magnitude3;
					Color[] array4 = lightTable;
					c = color3 + array4[RuntimeServices.NormalizeArrayIndex(array4, num6 * num3 + num7)] * magnitude4;
				}
				result = CorrectColor(c);
			}
			return result;
		}
	}

	public Color CorrectColor(Color c)
	{
		int num = 0;
		while (num < 3)
		{
			int index = num;
			num++;
			c[index] *= intensity[index] * scaleRate;
			if (!(c[index] >= min[index] * scaleRate))
			{
				c[index] = min[index] * scaleRate;
			}
			if (!(c[index] <= max[index] * scaleRate))
			{
				c[index] = max[index] * scaleRate;
			}
		}
		if (addAmbient)
		{
			c += RenderSettings.ambientLight;
		}
		return c;
	}
}
