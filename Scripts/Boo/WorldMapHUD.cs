using System;
using UnityEngine;

[Serializable]
public class WorldMapHUD : MonoBehaviour
{
	public GameObject button;

	public bool show;

	private bool lastShow;

	[NonSerialized]
	private static WorldMapHUD instance;

	public static void SetShow(bool s)
	{
		WorldMapHUD worldMapHUD = Instance();
		if ((bool)worldMapHUD)
		{
			worldMapHUD.show = true;
		}
	}

	public static WorldMapHUD Instance()
	{
		if (!instance)
		{
			instance = (WorldMapHUD)UnityEngine.Object.FindObjectOfType(typeof(WorldMapHUD));
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

	public void WorldMapShortCut()
	{
		SceneChanger.ChangeTo(SceneID.Ui_World);
	}
}
