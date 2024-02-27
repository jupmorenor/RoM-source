using System;
using System.Text;
using UnityEngine;

[Serializable]
public class TestEventWindow : MonoBehaviour
{
	protected float textDurationMSec;

	protected float lineWaitMSec;

	protected float pageWaitMSec;

	protected int windowType;

	protected string text;

	public TestEventWindow()
	{
		textDurationMSec = 100f;
		lineWaitMSec = 100f;
		pageWaitMSec = 100f;
		windowType = 2;
		text = "1234512345123451234512345123451234512345\n1234512345123451234512345123451234512345\n1234512345123451234512345123451234512345";
	}

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		GUILayout.Label(new StringBuilder("Duration=").Append(textDurationMSec).ToString());
		textDurationMSec = GUILayout.HorizontalSlider(textDurationMSec, 0f, 10000f);
		GUILayout.Label(new StringBuilder("LineWait=").Append(lineWaitMSec).ToString());
		lineWaitMSec = GUILayout.HorizontalSlider(lineWaitMSec, 0f, 10000f);
		GUILayout.Label(new StringBuilder("PageWait=").Append(pageWaitMSec).ToString());
		pageWaitMSec = GUILayout.HorizontalSlider(pageWaitMSec, 0f, 10000f);
		GUILayout.Label(new StringBuilder("WindowType=").Append((object)windowType).ToString());
		checked
		{
			windowType = (int)GUILayout.HorizontalSlider(windowType, 0f, EventWindow.Instance.Windows.Length - 1);
			text = GUILayout.TextArea(text);
			if (GUILayout.Button("Event Window Test"))
			{
				string[] message = text.Split('\n', '\0');
				EventWindow.Window window = EventWindow.OpenEventWindow(message, new string[1] { "test" }, null, windowType);
				if (window != null)
				{
					window.TextFinishAutoClose = true;
					window.textDurationMSec = (int)textDurationMSec;
					window.LineWaitMSec = lineWaitMSec;
					window.PageWaitMSec = pageWaitMSec;
				}
			}
			if (GUILayout.Button("Event Window Close"))
			{
				EventWindow.CloseEventWindowAll();
			}
		}
	}
}
