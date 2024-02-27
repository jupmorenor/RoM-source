using System;
using UnityEngine;

[Serializable]
public class PadSettingMenu : MonoBehaviour
{
	public UISprite spriteVirtualPad;

	public UISprite spriteTouchPanel;

	public UISprite spriteAutoCombinationOn;

	public UISprite spriteAutoCombinationOff;

	public UISprite spriteVirtualPadImageOn;

	public UISprite spriteVirtualPadImageOff;

	public UISprite spriteShowAutoBattleButtonOn;

	public UISprite spriteShowAutoBattleButtonOff;

	public Collider colliderVirtualPadImageOn;

	public Collider colliderVirtualPadImageOff;

	private bool virtualPad;

	private bool autoCombination;

	private bool showAutoBattleButton;

	private bool virtualPadImageOn;

	public GameObject helpPanel;

	private PadSettingMenuBoard board;

	public bool VirtualPad
	{
		get
		{
			return virtualPad;
		}
		set
		{
			virtualPad = value;
		}
	}

	public bool AutoCombinationOn
	{
		get
		{
			return autoCombination;
		}
		set
		{
			autoCombination = value;
		}
	}

	public bool ShowAutoBattleButton
	{
		get
		{
			return showAutoBattleButton;
		}
		set
		{
			showAutoBattleButton = value;
		}
	}

	public bool VirtualPadImageOn
	{
		get
		{
			return virtualPadImageOn;
		}
		set
		{
			virtualPadImageOn = value;
		}
	}

	public void Start()
	{
		UpdateDisplays();
		if ((bool)helpPanel)
		{
			UIAutoTweenerStandAloneEx.Hide(helpPanel);
			board = helpPanel.GetComponent<PadSettingMenuBoard>();
		}
	}

	public void OnDisable()
	{
		if ((bool)helpPanel)
		{
			UIAutoTweenerStandAloneEx.Hide(helpPanel);
		}
	}

	public void UpdateDisplays()
	{
		SwitchDisplay(spriteVirtualPad, spriteTouchPanel, VirtualPad);
		SwitchDisplay(spriteAutoCombinationOn, spriteAutoCombinationOff, AutoCombinationOn);
		if (VirtualPad)
		{
			SwitchDisplay(spriteVirtualPadImageOn, spriteVirtualPadImageOff, VirtualPadImageOn);
			SetCollidersActivity(true, colliderVirtualPadImageOn, colliderVirtualPadImageOff);
		}
		else
		{
			SetDisplay(spriteVirtualPadImageOn, on: false);
			SetDisplay(spriteVirtualPadImageOff, on: false);
			SetCollidersActivity(false, colliderVirtualPadImageOn, colliderVirtualPadImageOff);
		}
		SwitchDisplay(spriteShowAutoBattleButtonOn, spriteShowAutoBattleButtonOff, ShowAutoBattleButton);
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

	private void SetCollidersActivity(bool on, params Collider[] colliders)
	{
		int i = 0;
		for (int length = colliders.Length; i < length; i = checked(i + 1))
		{
			if (colliders[i] != null)
			{
				colliders[i].enabled = on;
			}
		}
	}

	public void Update()
	{
	}

	public void PushTouchPanel()
	{
		VirtualPad = false;
		UpdateDisplays();
	}

	public void PushVirtualPad()
	{
		VirtualPad = true;
		UpdateDisplays();
	}

	public void PushAutoCombinationOff()
	{
		AutoCombinationOn = false;
		UpdateDisplays();
	}

	public void PushAutoCombinationOn()
	{
		AutoCombinationOn = true;
		UpdateDisplays();
	}

	public void PushVirtualPadImageOn()
	{
		VirtualPadImageOn = true;
		UpdateDisplays();
	}

	public void PushVirtualPadImageOff()
	{
		VirtualPadImageOn = false;
		UpdateDisplays();
	}

	public void PushShowAutoBattleButtonOn()
	{
		ShowAutoBattleButton = true;
		UpdateDisplays();
	}

	public void PushShowAutoBattleButtonOff()
	{
		ShowAutoBattleButton = false;
		UpdateDisplays();
	}

	public void PushPadHelp()
	{
		if ((bool)helpPanel)
		{
			board.IsTap = false;
			if (!helpPanel.active)
			{
				UIAutoTweenerStandAloneEx.In(helpPanel);
			}
		}
	}

	public void PushPadTapHelp()
	{
		if ((bool)helpPanel)
		{
			board.IsTap = true;
			if (!helpPanel.active)
			{
				UIAutoTweenerStandAloneEx.In(helpPanel);
			}
		}
	}

	public void PushBack()
	{
		if ((bool)helpPanel && helpPanel.active)
		{
			UIAutoTweenerStandAloneEx.Out(helpPanel);
		}
	}
}
