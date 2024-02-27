using System;
using UnityEngine;

[Serializable]
public class RenderSettingsData : MonoBehaviour
{
	public Color ambientLight;

	public float flareStrength;

	public bool fog;

	public Color fogColor;

	public float fogDensity;

	public float fogEndDistance;

	public FogMode fogMode;

	public float fogStartDistance;

	public float haloStrength;

	public Material skybox;

	public Color oldAmbientLight;

	public float oldFlareStrength;

	public bool oldFog;

	public Color oldFogColor;

	public float oldFogDensity;

	public float oldFogEndDistance;

	public FogMode oldFogMode;

	public float oldFogStartDistance;

	public float oldHaloStrength;

	public Material oldSkybox;

	public bool pushFlag;

	public void Start()
	{
		Push();
	}

	public void OnDestroy()
	{
		if (pushFlag)
		{
			Pop();
		}
	}

	public void Push()
	{
		oldAmbientLight = RenderSettings.ambientLight;
		oldFlareStrength = RenderSettings.flareStrength;
		oldFog = RenderSettings.fog;
		oldFogColor = RenderSettings.fogColor;
		oldFogDensity = RenderSettings.fogDensity;
		oldFogEndDistance = RenderSettings.fogEndDistance;
		oldFogMode = RenderSettings.fogMode;
		oldFogStartDistance = RenderSettings.fogStartDistance;
		oldHaloStrength = RenderSettings.haloStrength;
		oldSkybox = RenderSettings.skybox;
		RenderSettings.ambientLight = ambientLight;
		RenderSettings.flareStrength = flareStrength;
		RenderSettings.fog = fog;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.fogEndDistance = fogEndDistance;
		RenderSettings.fogMode = fogMode;
		RenderSettings.fogStartDistance = fogStartDistance;
		RenderSettings.haloStrength = haloStrength;
		RenderSettings.skybox = skybox;
		pushFlag = true;
	}

	public void Pop()
	{
		RenderSettings.ambientLight = oldAmbientLight;
		RenderSettings.flareStrength = oldFlareStrength;
		RenderSettings.fog = oldFog;
		RenderSettings.fogColor = oldFogColor;
		RenderSettings.fogDensity = oldFogDensity;
		RenderSettings.fogEndDistance = oldFogEndDistance;
		RenderSettings.fogMode = oldFogMode;
		RenderSettings.fogStartDistance = oldFogStartDistance;
		RenderSettings.haloStrength = oldHaloStrength;
		RenderSettings.skybox = oldSkybox;
	}
}
