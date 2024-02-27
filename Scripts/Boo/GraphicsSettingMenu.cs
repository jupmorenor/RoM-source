using System;
using UnityEngine;

[Serializable]
public class GraphicsSettingMenu : MonoBehaviour
{
	public UISprite spriteShadowReal;

	public UISprite spriteShadowSimple;

	public UISprite spriteLightOn;

	public UISprite spriteLightOff;

	private bool realShadow;

	private bool lightOn;

	public bool RealShadow
	{
		get
		{
			return realShadow;
		}
		set
		{
			realShadow = value;
		}
	}

	public bool LightOn
	{
		get
		{
			return lightOn;
		}
		set
		{
			lightOn = value;
		}
	}

	public void Start()
	{
		UpdateDisplays();
	}

	public void UpdateDisplays()
	{
		bool flag = true;
		if (PerformanceSettingBase.specLevel == PerformanceSettingBase.EnumSpecLevel.Lo)
		{
			flag = false;
		}
		if (flag)
		{
			SwitchDisplay(spriteShadowReal, spriteShadowSimple, RealShadow);
			SwitchDisplay(spriteLightOn, spriteLightOff, LightOn);
		}
		else
		{
			DisableDisplay(spriteShadowReal, spriteShadowSimple);
			DisableDisplay(spriteLightOn, spriteLightOff);
		}
	}

	private void SwitchDisplay(UISprite onSprite, UISprite offSprite, bool on)
	{
		onSprite.color = ((!on) ? Color.grey : Color.white);
		offSprite.color = ((!on) ? Color.white : Color.grey);
	}

	private void DisableDisplay(UISprite onSprite, UISprite offSprite)
	{
		onSprite.color = Color.grey;
		offSprite.color = Color.grey;
	}

	public void Update()
	{
	}

	public void PushShadowSimple()
	{
		RealShadow = false;
		UpdateDisplays();
	}

	public void PushShadowReal()
	{
		RealShadow = true;
		UpdateDisplays();
	}

	public void PushLightOff()
	{
		LightOn = false;
		UpdateDisplays();
	}

	public void PushLightOn()
	{
		LightOn = true;
		UpdateDisplays();
	}
}
