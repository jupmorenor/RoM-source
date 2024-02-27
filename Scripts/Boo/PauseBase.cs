using System;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PauseBase : IPauseWindow
{
	[Serializable]
	internal class _0024InitSoundSetting_0024locals_002414401
	{
		internal GameObject _0024situationRoot;
	}

	[Serializable]
	internal class _0024InitSoundSetting_0024closure_00242932
	{
		internal _0024InitSoundSetting_0024locals_002414401 _0024_0024locals_002414928;

		internal PauseBase _0024this_002414929;

		public _0024InitSoundSetting_0024closure_00242932(_0024InitSoundSetting_0024locals_002414401 _0024_0024locals_002414928, PauseBase _0024this_002414929)
		{
			this._0024_0024locals_002414928 = _0024_0024locals_002414928;
			this._0024this_002414929 = _0024this_002414929;
		}

		public void Invoke()
		{
			GameSoundManager instance = GameSoundManager.Instance;
			if ((bool)instance)
			{
				_0024this_002414929.curBgm = GameSoundManager.CurBgmFile;
			}
			_0024this_002414929.bgmSlider = ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "1 BGM").GetComponentInChildren<UISlider>();
			if (!(_0024this_002414929.bgmSlider != null))
			{
				throw new AssertionFailedException("bgmSlider != null");
			}
			_0024this_002414929.bgmSlider.eventReceiver = _0024this_002414929.gameObject;
			_0024this_002414929.bgmSlider.functionName = "OnBGMSliderChange";
			_0024this_002414929.seSlider = ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "3 SE").GetComponentInChildren<UISlider>();
			if (!(_0024this_002414929.seSlider != null))
			{
				throw new AssertionFailedException("seSlider != null");
			}
			_0024this_002414929.seSlider.eventReceiver = _0024this_002414929.gameObject;
			_0024this_002414929.seSlider.functionName = "OnSESliderChange";
			_0024this_002414929.RestoreVolumeCore(init: true);
			UIButtonMessage componentInChildren = ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "2 Init").GetComponentInChildren<UIButtonMessage>();
			componentInChildren.target = _0024this_002414929.gameObject;
			componentInChildren.functionName = "ResetVolume";
			_0024this_002414929.bgmDownloadLabel = ExtensionsModule.FindChild(ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "5 Download"), "TextState").GetComponent<UIDynamicFontLabel>();
			_0024this_002414929.bgmDownloadLabel.Text = ((!UserData.Current.userMiscInfo.bgmLoad) ? "未ダウンロード" : "ダウンロード済");
			_0024this_002414929.ButtonStateChange(_0024_0024locals_002414928._0024situationRoot, "5 Download", new string[1] { "Button" }, !UserData.Current.userMiscInfo.bgmLoad);
			if (!CurrentInfo.LastGameResponse.IsPublished)
			{
				ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "41 Serial").SetActive(value: false);
				ExtensionsModule.FindChild(_0024_0024locals_002414928._0024situationRoot, "42 Invite").SetActive(value: false);
			}
		}
	}

	protected UISlider seSlider;

	protected UISlider bgmSlider;

	protected int soundId;

	protected bool waitInitSESlider;

	protected string curBgm;

	private UIDynamicFontLabel bgmDownloadLabel;

	public PauseBase()
	{
		soundId = -1;
		waitInitSESlider = true;
	}

	public void OnBGMSliderChange(float val)
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		GameSoundManager instance2 = GameSoundManager.Instance;
		if (!instance)
		{
			return;
		}
		SQEX_SoundPlayer.MasterBgmVolume = val;
		if (!(val > 0f))
		{
			sndmgr.StopBgm();
		}
		else if (!instance.IsPlayBgm(checkPause: true) && !(val <= 0f) && (bool)instance2)
		{
			instance.PauseBgm(pause: false);
			if (!string.IsNullOrEmpty(curBgm))
			{
				GameSoundManager.PlayBgmDirect(curBgm, 1f, 0f, 0, instance.lastBgmLoop);
			}
			instance2.Update();
		}
	}

	public void OnSESliderChange(float val)
	{
		if (waitInitSESlider)
		{
			waitInitSESlider = false;
			return;
		}
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if (SQEX_SoundPlayer.MasterSeVolume != val)
		{
			SQEX_SoundPlayer.MasterSeVolume = val;
			SQEX_SoundPlayerData.SE seIndex = SQEX_SoundPlayerData.SE.levelup;
			if (soundId < 0 || !instance.IsPlaySe(soundId))
			{
				soundId = instance.PlaySe((int)seIndex);
			}
		}
	}

	public void InitSoundSetting(GameObject situationRoot)
	{
		_0024InitSoundSetting_0024locals_002414401 _0024InitSoundSetting_0024locals_0024 = new _0024InitSoundSetting_0024locals_002414401();
		_0024InitSoundSetting_0024locals_0024._0024situationRoot = situationRoot;
		TryPrepare(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024InitSoundSetting_0024closure_00242932(_0024InitSoundSetting_0024locals_0024, this).Invoke));
	}

	public void SaveVolume()
	{
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		UserData.Current.Config.SEVolume = SQEX_SoundPlayer.MasterSeVolume;
		UserData.Current.Config.BGMVolume = SQEX_SoundPlayer.MasterBgmVolume;
	}

	public void ResetVolume()
	{
		UserData.Current.Config.SEVolume = 0.8f;
		UserData.Current.Config.BGMVolume = 0.8f;
		RestoreVolumeCore(init: false);
	}

	public void RestoreVolume()
	{
		RestoreVolumeCore(init: false);
	}

	public void RestoreVolumeCore(bool init)
	{
		if (!init)
		{
			SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
			if ((bool)instance)
			{
				SQEX_SoundPlayer.MasterSeVolume = UserData.Current.Config.SEVolume;
				SQEX_SoundPlayer.MasterBgmVolume = UserData.Current.Config.BGMVolume;
				if (!(SQEX_SoundPlayer.MasterBgmVolume > 0f))
				{
					sndmgr.StopBgm();
				}
				else if (!instance.IsPlayBgm())
				{
					GameSoundManager instance2 = GameSoundManager.Instance;
					if ((bool)instance2)
					{
						if (!string.IsNullOrEmpty(curBgm))
						{
							GameSoundManager.PlayBgmDirect(curBgm, 1f, 0f, 0, instance.lastBgmLoop);
						}
						instance2.Update();
					}
				}
			}
		}
		if ((bool)bgmSlider)
		{
			bgmSlider.sliderValue = UserData.Current.Config.BGMVolume;
		}
		if ((bool)seSlider)
		{
			waitInitSESlider = true;
			seSlider.sliderValue = UserData.Current.Config.SEVolume;
			waitInitSESlider = true;
		}
	}

	public void SaveGraphic()
	{
		GraphicsSettingMenu componentInChildren = GetComponentInChildren<GraphicsSettingMenu>();
		UserData.Current.Config.RealShadow = componentInChildren.RealShadow;
		UserData.Current.Config.LightOn = componentInChildren.LightOn;
		UserData.Current.Config.GraphicApply();
	}

	public void ResetGraphic()
	{
		UserData.Current.Config.RealShadow = UserData.Current.Config.DefaultRealShadow;
		UserData.Current.Config.LightOn = UserData.Current.Config.DefaultLightOn;
		RestoreGraphic();
	}

	public void RestoreGraphic()
	{
		GraphicsSettingMenu componentInChildren = GetComponentInChildren<GraphicsSettingMenu>();
		if ((bool)componentInChildren)
		{
			componentInChildren.RealShadow = UserData.Current.Config.RealShadow;
			componentInChildren.LightOn = UserData.Current.Config.LightOn;
			componentInChildren.UpdateDisplays();
		}
	}

	public void SavePad()
	{
		PadSettingMenu componentInChildren = GetComponentInChildren<PadSettingMenu>();
		UserData.Current.Config.VirtualPad = componentInChildren.VirtualPad;
		UserData.Current.Config.AutoCombinationOn = componentInChildren.AutoCombinationOn;
		UserData.Current.Config.VirtualPadImageOn = componentInChildren.VirtualPadImageOn;
		UserData.Current.Config.ShowAutoBattleButton = componentInChildren.ShowAutoBattleButton;
		UserData.Current.Config.PadApply();
	}

	public void ResetPad()
	{
		UserData.Current.Config.VirtualPad = UserData.Current.Config.DefaultVirtualPad;
		UserData.Current.Config.AutoCombinationOn = UserData.Current.Config.DefaultAutoCombinationOn;
		UserData.Current.Config.VirtualPadImageOn = UserData.Current.Config.DefaultVirtualPadImageOn;
		UserData.Current.Config.ShowAutoBattleButton = UserData.Current.Config.DefaultAutoBattleButtonOn;
		RestorePad();
	}

	public void RestorePad()
	{
		PadSettingMenu componentInChildren = GetComponentInChildren<PadSettingMenu>();
		if ((bool)componentInChildren)
		{
			componentInChildren.VirtualPad = UserData.Current.Config.VirtualPad;
			componentInChildren.AutoCombinationOn = UserData.Current.Config.AutoCombinationOn;
			componentInChildren.VirtualPadImageOn = UserData.Current.Config.VirtualPadImageOn;
			componentInChildren.ShowAutoBattleButton = UserData.Current.Config.ShowAutoBattleButton;
			componentInChildren.UpdateDisplays();
		}
	}

	protected void SaveOtherSetting()
	{
		OtherSettingMenu componentInChildren = GetComponentInChildren<OtherSettingMenu>();
		ResultShortcut.SetEnable(ResultShortcut.IntoScene.Limited, componentInChildren.ResultShortcut);
		ResultShortcut.SetEnable(ResultShortcut.IntoScene.Grow, componentInChildren.ResultShortcut);
		ResultShortcut.SetEnable(ResultShortcut.IntoScene.Challenge, componentInChildren.ResultShortcut);
	}

	protected void RestoreOtherSetting()
	{
		OtherSettingMenu componentInChildren = GetComponentInChildren<OtherSettingMenu>();
		componentInChildren.ResultShortcut = ResultShortcut.HasEnabled();
		componentInChildren.UpdateDisplays();
	}

	public void UpdateLabel(GameObject situationRoot, string panelName, string labelName, string text, Color color)
	{
		GameObject go = UpdateLabel(situationRoot, panelName, labelName, text);
		UIBasicUtility.SetColor(go, color);
	}

	public GameObject UpdateLabel(GameObject situationRoot, string panelName, string labelName, string text)
	{
		GameObject gameObject = ExtensionsModule.FindChild(ExtensionsModule.FindChild(situationRoot, panelName), labelName);
		UIBasicUtility.SetLabel(gameObject.GetComponent<UILabelBase>(), text);
		return gameObject;
	}

	public void TryPrepare(ICallable act)
	{
		try
		{
			act.Call(new object[0]);
		}
		catch (Exception)
		{
		}
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state)
	{
		GameObject go = FindObject(situationRoot, panelName);
		Color color = ((!state) ? Color.grey : Color.white);
		int i = 0;
		for (int length = buttonNames.Length; i < length; i = checked(i + 1))
		{
			GameObject gameObject = FindObject(go, buttonNames[i]);
			UIButtonMessage component = gameObject.GetComponent<UIButtonMessage>();
			component.merlinPuwaEnable = state;
			component.sendMessage = state;
			component.enabled = state;
			component.gameObject.collider.enabled = state;
			GameObject gameObject2 = FindObject(gameObject, "Text");
			gameObject2.GetComponent<UIWidget>().color = color;
			FindObject(gameObject, "Background").GetComponent<UIWidget>().color = color;
			UIButtonSQEXSound component2 = gameObject.GetComponent<UIButtonSQEXSound>();
			if ((bool)component2)
			{
				component2.enabled = state;
			}
		}
	}

	public GameObject FindObject(GameObject go, string objName)
	{
		return ExtensionsModule.FindChild(go, objName);
	}
}
