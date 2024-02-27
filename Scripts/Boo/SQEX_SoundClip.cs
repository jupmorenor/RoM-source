using System;
using UnityEngine;

[Serializable]
public class SQEX_SoundClip : MonoBehaviour
{
	public SQEX_SoundPlayer soundPlayer;

	public bool isBgm;

	public int delay;

	public int loop;

	public bool pause;

	public float vol;

	public bool oneShot;

	public string file;

	public bool isEnd;

	protected bool lastPause;

	protected float lastVol;

	protected int bgmId;

	protected int seId;

	protected int request;

	public SQEX_SoundClip()
	{
		loop = -1;
		vol = 0.5f;
		lastVol = 1f;
		bgmId = -1;
		seId = -1;
	}

	public void Awake()
	{
		soundPlayer = SQEX_SoundPlayer.Instance;
	}

	public void Start()
	{
		if (enabled)
		{
			request = 1;
		}
	}

	public void OnEnable()
	{
		request = 1;
	}

	public void Play(int delayMSec)
	{
		Stop(0);
		if (!soundPlayer)
		{
			return;
		}
		if (!string.IsNullOrEmpty(file))
		{
			if (isBgm)
			{
				bgmId = soundPlayer.PlayBgm(file, loop, delayMSec, delayMSec);
			}
			else
			{
				seId = soundPlayer.PlaySe(file, delayMSec, gameObject.GetInstanceID());
			}
		}
		if (bgmId >= 0)
		{
			isEnd = false;
		}
		if (seId >= 0)
		{
			isEnd = false;
		}
		if (oneShot)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}

	public void Update()
	{
		if (!soundPlayer)
		{
			return;
		}
		if (request == 1)
		{
			Play(delay);
			request = 2;
			isEnd = false;
		}
		if (request == 2)
		{
			if (isBgm && bgmId >= 0 && soundPlayer.IsPlayBgm())
			{
				request = 0;
			}
			if (!isBgm && seId >= 0 && soundPlayer.IsPlaySe(seId))
			{
				request = 0;
			}
		}
		if (request == 0)
		{
			if (bgmId >= 0)
			{
				if (lastPause != pause)
				{
					soundPlayer.PauseBgm(pause);
					lastPause = pause;
				}
				if (lastVol != vol)
				{
					SQEX_SoundPlayer.BgmVolume = vol;
					lastVol = vol;
				}
				isEnd = !soundPlayer.IsPlayBgm();
			}
			if (seId >= 0)
			{
				if (lastPause != pause)
				{
					soundPlayer.PauseSe(seId, pause);
					lastPause = pause;
				}
				if (lastVol != vol)
				{
					SQEX_SoundPlayer.SeVolume = vol;
					lastVol = vol;
				}
				isEnd = !soundPlayer.IsPlaySe(seId);
			}
			if (isEnd)
			{
				seId = -1;
				bgmId = -1;
				enabled = false;
			}
		}
		request = 0;
	}

	public void OnDisable()
	{
		if (!oneShot)
		{
			Stop(0);
		}
	}

	public void Stop(int delayMSec)
	{
		if ((bool)soundPlayer)
		{
			if (bgmId >= 0)
			{
				soundPlayer.StopBgm(delayMSec);
				bgmId = -1;
			}
			if (seId >= 0)
			{
				soundPlayer.StopSe(seId, delayMSec);
				seId = -1;
			}
		}
	}
}
