using System;
using UnityEngine;

[Serializable]
public class SceneTitleHUD : MonoBehaviour
{
	public UILabelBase titleLabel;

	[NonSerialized]
	private static SceneTitleHUD instance;

	public string title
	{
		get
		{
			return titleLabel.text;
		}
		set
		{
			titleLabel.text = value;
		}
	}

	public static void SetActive(bool a)
	{
		SceneTitleHUD sceneTitleHUD = Instance();
		if ((bool)sceneTitleHUD)
		{
			sceneTitleHUD.gameObject.SetActive(a);
		}
	}

	public static SceneTitleHUD Instance()
	{
		if (!instance)
		{
			instance = (SceneTitleHUD)UnityEngine.Object.FindObjectOfType(typeof(SceneTitleHUD));
		}
		return instance;
	}

	public static void UpdateTitle(string text)
	{
		if ((bool)Instance())
		{
			Instance().title = text;
		}
	}
}
