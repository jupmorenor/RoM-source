using System;

[Serializable]
public class FontManager : FontList
{
	public void Start()
	{
	}

	public void OnEnable()
	{
		SceneChanger.SceneChangeEvent += SceneChangeEvent;
	}

	public void OnDisable()
	{
		SceneChanger.SceneChangeEvent -= SceneChangeEvent;
	}

	public void SceneChangeEvent(SceneID sceneId, string sceneName)
	{
	}
}
