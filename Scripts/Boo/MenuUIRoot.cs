using System;
using UnityEngine;

[Serializable]
public class MenuUIRoot : UIRoot
{
	public Transform shortCutHudParent;

	public BattleHUDShortcut shortCutHud;

	public bool showShortcut;

	protected bool quitApp;

	public MenuUIRoot()
	{
		showShortcut = true;
	}

	public void OnApplicationQuit()
	{
		quitApp = true;
	}

	public new void Update()
	{
		ShortCutHudCtrl();
		base.Update();
	}

	public void ShortCutHudCtrl()
	{
		if (!Application.isPlaying || shortCutHudParent == null || quitApp || (bool)shortCutHud)
		{
			return;
		}
		shortCutHud = BattleHUDShortcut.Instance;
		if ((bool)shortCutHud && (bool)shortCutHud.transform)
		{
			Vector3 localPosition = shortCutHud.transform.localPosition;
			Vector3 localScale = shortCutHud.transform.localScale;
			shortCutHud.transform.parent = shortCutHudParent;
			shortCutHud.transform.localPosition = localPosition;
			shortCutHud.transform.localScale = localScale;
			if (showShortcut)
			{
				BattleHUDShortcut.Show();
			}
		}
	}
}
