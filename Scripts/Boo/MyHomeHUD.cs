using System;
using UnityEngine;

[Serializable]
public class MyHomeHUD : MonoBehaviour
{
	public GameObject button;

	public bool show;

	private bool lastShow;

	[NonSerialized]
	private static MyHomeHUD instance;

	public static void SetShow(bool s)
	{
		MyHomeHUD myHomeHUD = Instance();
		if ((bool)myHomeHUD)
		{
			myHomeHUD.show = true;
		}
	}

	public static MyHomeHUD Instance()
	{
		if (!instance)
		{
			instance = (MyHomeHUD)UnityEngine.Object.FindObjectOfType(typeof(MyHomeHUD));
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

	public void MyHomeShortCut()
	{
		SceneChanger.ChangeTo(SceneID.Myhome);
	}
}
