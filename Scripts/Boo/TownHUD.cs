using System;
using UnityEngine;

[Serializable]
public class TownHUD : MonoBehaviour
{
	public GameObject button;

	public bool show;

	private bool lastShow;

	[NonSerialized]
	private static TownHUD instance;

	public static void SetShow(bool s)
	{
		TownHUD townHUD = Instance();
		if ((bool)townHUD)
		{
			townHUD.show = true;
		}
	}

	public static TownHUD Instance()
	{
		if (!instance)
		{
			instance = (TownHUD)UnityEngine.Object.FindObjectOfType(typeof(TownHUD));
		}
		return instance;
	}

	public void Awake()
	{
		button.SetActive(show);
	}

	public void Update()
	{
		if (show != lastShow)
		{
			lastShow = show;
			button.SetActive(show);
		}
	}

	public void TownShortCut()
	{
		SceneChanger.ChangeTo(SceneID.Town);
	}
}
