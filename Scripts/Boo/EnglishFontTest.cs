using System;
using System.Text;
using UnityEngine;

[Serializable]
public class EnglishFontTest : MonoBehaviour
{
	public GameObject Depot;

	public GameObject Fukidashi;

	public EventWindow eventWindow;

	public AttachMapetSpeak attachMapetSpeak;

	public MapetSpeakEnglish mapetSpeak;

	public bool eventWindowFlag;

	protected string lastString;

	public void Start()
	{
	}

	public void Update()
	{
		if (eventWindowFlag && (bool)mapetSpeak && lastString != mapetSpeak.curText)
		{
			lastString = mapetSpeak.curText;
			EventWindow.OpenEventWindow(lastString, string.Empty);
		}
	}

	public void OnGUI()
	{
		if (GUILayout.Button("倉庫"))
		{
			if ((bool)Depot)
			{
				Depot.SetActive(value: true);
			}
			if ((bool)Fukidashi)
			{
				Fukidashi.SetActive(value: false);
			}
			eventWindowFlag = false;
			if ((bool)eventWindow)
			{
				eventWindow.gameObject.SetActive(value: false);
			}
		}
		if (GUILayout.Button("ペット吹き出し"))
		{
			if ((bool)Depot)
			{
				Depot.SetActive(value: false);
			}
			if ((bool)Fukidashi)
			{
				Fukidashi.SetActive(value: true);
			}
			eventWindowFlag = false;
			if ((bool)eventWindow)
			{
				eventWindow.gameObject.SetActive(value: false);
			}
		}
		if (GUILayout.Button("ウィンドウ"))
		{
			if ((bool)Depot)
			{
				Depot.SetActive(value: false);
			}
			if ((bool)Fukidashi)
			{
				Fukidashi.SetActive(value: false);
			}
			eventWindowFlag = true;
			if ((bool)eventWindow)
			{
				eventWindow.gameObject.SetActive(value: true);
			}
		}
		GUILayout.Label(new StringBuilder("Font Size = ").Append((object)UIDynamicFontLabel.debugFontSize).ToString());
		UIDynamicFontLabel.debugFontSize = checked((int)GUILayout.HorizontalSlider(UIDynamicFontLabel.debugFontSize, 12f, 30f));
	}
}
