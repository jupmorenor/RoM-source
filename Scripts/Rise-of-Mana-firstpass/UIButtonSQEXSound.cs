using UnityEngine;

public class UIButtonSQEXSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease
	}

	public SQEX_SoundPlayerData.SE se_ID = SQEX_SoundPlayerData.SE.cursor;

	public Trigger trigger;

	public float volume = 1f;

	private SQEX_SoundPlayer sndPlayer;

	private void Start()
	{
		sndPlayer = SQEX_SoundPlayer.Instance;
	}

	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut)) && (bool)sndPlayer)
		{
			se_ID = SQEX_SoundPlayerData.SE.cursor;
			int soundID = sndPlayer.PlaySe((int)se_ID);
			sndPlayer.SetSeVoulme(soundID, volume);
		}
	}

	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease)) && (bool)sndPlayer)
		{
			se_ID = SQEX_SoundPlayerData.SE.cursor;
			int soundID = sndPlayer.PlaySe((int)se_ID);
			sndPlayer.SetSeVoulme(soundID, volume);
		}
	}

	private void OnClick()
	{
		if (base.enabled && trigger == Trigger.OnClick && (bool)sndPlayer)
		{
			se_ID = SQEX_SoundPlayerData.SE.cursor;
			int soundID = sndPlayer.PlaySe((int)se_ID);
			sndPlayer.SetSeVoulme(soundID, volume);
		}
	}
}
