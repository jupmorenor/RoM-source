using System;
using UnityEngine;

[Serializable]
public class ErrorDialogTest : MonoBehaviour
{
	public bool testFlag;

	public void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		if (testFlag && GUILayout.Button("Open Error Dialog"))
		{
			ErrorDialog.FatalError("Test", "Test Error Dialog", jumpBoot: true);
		}
	}
}
