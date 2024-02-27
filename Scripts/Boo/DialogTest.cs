using System;
using UnityEngine;

[Serializable]
public class DialogTest : MonoBehaviour
{
	protected string title;

	protected string text;

	public DialogTest()
	{
		title = "1234512345";
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
		GUILayout.Label("Title");
		title = GUILayout.TextArea(title);
		GUILayout.Label("Text");
		text = GUILayout.TextArea(text);
		if (GUILayout.Button("Dialog Test"))
		{
			DialogManager.Instance.OpenDialog(text, title);
		}
	}
}
