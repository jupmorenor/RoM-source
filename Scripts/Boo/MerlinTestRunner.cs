using System;
using System.Collections.Generic;
using System.Text;
using SharpUnit;
using UnityEngine;

[Serializable]
public class MerlinTestRunner : Unity3D_TestRunner
{
	[Serializable]
	public class CheckedList
	{
		public bool enable;

		public string name;

		public CheckedList()
		{
			enable = true;
			name = string.Empty;
		}
	}

	private string logString;

	private Vector2 scrollPosition;

	public List<CheckedList> TestComponents;

	public MerlinTestRunner()
	{
		logString = string.Empty;
		scrollPosition = Vector2.zero;
		TestComponents = new List<CheckedList>();
	}

	public void PutLog(string s)
	{
		logString += new StringBuilder().Append(s).Append("\n").ToString();
	}

	public void ClearLog()
	{
		logString = string.Empty;
	}

	public void OnGUI()
	{
		GUILayout.Label(string.Empty);
		GUILayout.BeginArea(new Rect(10f, 80f, 600f, 500f));
		if (GUILayout.Button("Log Clear", GUILayout.Width(80f)))
		{
			logString = string.Empty;
		}
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(400f), GUILayout.Height(300f));
		GUILayout.TextArea(logString);
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	public override void AddComponents(Unity3D_TestSuite suite)
	{
		foreach (CheckedList testComponent in TestComponents)
		{
			if (testComponent.enable && !string.IsNullOrEmpty(testComponent.name))
			{
				UnityTestCase test = gameObject.AddComponent(testComponent.name) as UnityTestCase;
				suite.AddAll(test);
			}
		}
	}
}
