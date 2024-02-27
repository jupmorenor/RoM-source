using System;
using System.Text.RegularExpressions;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class FogManager : MonoBehaviour
{
	[NonSerialized]
	private static FogManager _instance;

	public static FogManager Instance()
	{
		if (_instance == null)
		{
			GameObject gameObject = new GameObject("__FogManager__");
			FogManager fogManager = ExtensionsModule.SetComponent<FogManager>(gameObject);
			if (!(fogManager != null))
			{
				throw new AssertionFailedException("c != null");
			}
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_instance = fogManager;
		}
		return _instance;
	}

	public static void setFog()
	{
		Instance().setFogSub();
	}

	private void setFogSub()
	{
		string currentSceneName = SceneChanger.CurrentSceneName;
		Color color = default(Color);
		float fogDensity = 0.01f;
		float fogStartDistance = 0f;
		float num = 0f;
		if (currentSceneName == "mountain_000")
		{
			color = new Color(1f, 1f, 1f, 1f);
			fogStartDistance = 10f;
			num = 80f;
			fogDensity = 0.02f;
		}
		else
		{
			if (Regex.IsMatch(currentSceneName, "forest_*."))
			{
				return;
			}
			if (Regex.IsMatch(currentSceneName, "cave_*."))
			{
				color = new Color(0f, 0f, 0f, 1f);
				num = 100f;
			}
			else
			{
				if (Regex.IsMatch(currentSceneName, "coast_*."))
				{
					return;
				}
				if (Regex.IsMatch(currentSceneName, "temple_*."))
				{
					color = new Color(0f, 0f, 0f, 1f);
					num = 100f;
				}
				else
				{
					if (!Regex.IsMatch(currentSceneName, "desert_*."))
					{
						return;
					}
					color = new Color(1f, 0.9372549f, 0.7607843f, 1f);
					num = 50f;
				}
			}
		}
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogColor = color;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.fogStartDistance = fogStartDistance;
		RenderSettings.fogEndDistance = num;
	}
}
