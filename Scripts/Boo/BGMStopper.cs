using System;
using UnityEngine;

[Serializable]
public class BGMStopper : MonoBehaviour
{
	public int bgmStopDelay;

	public BGMStopper()
	{
		bgmStopDelay = 2000;
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
		if (SQEX_SoundPlayer.Instance.IsPlayBgm())
		{
			SQEX_SoundPlayer.Instance.StopBgm(bgmStopDelay);
		}
	}
}
