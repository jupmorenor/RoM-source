using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class ShadowReceiver : MonoBehaviour
{
	protected Hashtable originalShader;

	protected Boo.Lang.List<Material> materials;

	protected SceneLightTable lightTable;

	protected string sceneName;

	protected Renderer shadowCastRenderer;

	protected Renderer shadowObjectRenderer;

	public float intensity;

	public Renderer ShadowCastRenderer
	{
		get
		{
			return shadowCastRenderer;
		}
		set
		{
			shadowCastRenderer = value;
		}
	}

	public Renderer ShadowObjectRenderer
	{
		get
		{
			return shadowObjectRenderer;
		}
		set
		{
			shadowObjectRenderer = value;
		}
	}

	public ShadowReceiver()
	{
		originalShader = new Hashtable();
		materials = new Boo.Lang.List<Material>();
		intensity = 0.5f;
	}

	public void Start()
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		sceneName = SceneChanger.CurrentSceneName;
		if (!lightTable)
		{
			lightTable = ((SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable))) as SceneLightTable;
		}
	}

	public void OnEnable()
	{
		if (PerformanceSettingBase.specLevel != PerformanceSettingBase.EnumSpecLevel.Lo && !lightTable)
		{
			lightTable = ((SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable))) as SceneLightTable;
		}
	}

	public void Update()
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			return;
		}
		if (sceneName != SceneChanger.CurrentSceneName)
		{
			sceneName = SceneChanger.CurrentSceneName;
			if (!lightTable)
			{
				lightTable = ((SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable))) as SceneLightTable;
			}
		}
		if (materials != null)
		{
			Color color = new Color(1f, 1f, 1f);
			if ((bool)lightTable)
			{
				color = lightTable.CheckColor(transform.position);
			}
			IEnumerator<Material> enumerator = materials.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Material current = enumerator.Current;
					current.SetColor("_Color", color * intensity);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
		if ((bool)shadowObjectRenderer && (bool)shadowCastRenderer && shadowObjectRenderer.gameObject.active)
		{
			shadowObjectRenderer.enabled = shadowCastRenderer.enabled;
		}
	}

	public void SetShadowShader(Material material, string newShaderName)
	{
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo || !material)
		{
			return;
		}
		if (!RuntimeServices.ToBool(originalShader[material.GetInstanceID()]))
		{
			materials.Add(material);
			if (newShaderName != material.shader.name)
			{
				originalShader[material.GetInstanceID()] = material.shader.name;
			}
		}
		material.shader = Shader.Find(newShaderName);
	}

	public void SetOriginalShader(Material material)
	{
		if (PerformanceSettingBase.specLevel != PerformanceSettingBase.EnumSpecLevel.Lo && (bool)material)
		{
			object obj = originalShader[material.GetInstanceID()];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string value = (string)obj;
			if (!string.IsNullOrEmpty(value))
			{
				material.shader = Shader.Find(value);
			}
			else
			{
				material.shader = Shader.Find("Mobile/Unlit (Supports Lightmap)");
			}
		}
	}
}
