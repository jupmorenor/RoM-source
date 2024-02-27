using System;
using UnityEngine;

[Serializable]
public class OtherSettingMenu : MonoBehaviour
{
	public UISprite resultShortcutOn;

	public UISprite resultShortcutOff;

	private bool resultShortcut;

	public bool ResultShortcut
	{
		get
		{
			return resultShortcut;
		}
		set
		{
			bool flag = value;
			if (GameParameter.alwaysOpenResultShortcut && !flag)
			{
				flag = true;
			}
			resultShortcut = flag;
		}
	}

	private void Start()
	{
		if (GameParameter.alwaysOpenResultShortcut)
		{
			resultShortcut = true;
		}
		UpdateDisplays();
	}

	public void UpdateDisplays()
	{
		SwitchDisplay(resultShortcutOn, resultShortcutOff, ResultShortcut);
	}

	private void SwitchDisplay(UISprite onSprite, UISprite offSprite, bool on)
	{
		SetDisplay(onSprite, on);
		SetDisplay(offSprite, !on);
	}

	private void SetDisplay(UISprite spr, bool on)
	{
		if (spr != null)
		{
			spr.color = ((!on) ? Color.grey : Color.white);
		}
	}

	public void PushReusltShortcutOn()
	{
		ResultShortcut = true;
		UpdateDisplays();
	}

	public void PushReusltShortcutOff()
	{
		ResultShortcut = false;
		UpdateDisplays();
	}
}
