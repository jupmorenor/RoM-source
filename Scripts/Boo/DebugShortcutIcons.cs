using System;
using UnityEngine;

[Serializable]
public class DebugShortcutIcons : MonoBehaviour
{
	protected bool show;

	public void Start()
	{
	}

	public void Update()
	{
	}

	public void OnGUI()
	{
		GUILayout.BeginArea(new Rect(100f, 100f, 200f, 200f));
		if (!show && GUILayout.Button("Show ShortCut", GUILayout.MinHeight(80f)))
		{
			BattleHUD battleHUD = (BattleHUD)UnityEngine.Object.FindObjectOfType(typeof(BattleHUD));
			battleHUD.debug = true;
			battleHUD.SetupShortcutIcon();
		}
		GUILayout.EndArea();
	}
}
