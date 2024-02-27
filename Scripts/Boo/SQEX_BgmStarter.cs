using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SQEX_BgmStarter : MonoBehaviour
{
	public SQEX_SoundPlayerData.BGM bgm;

	public int loop;

	public float vol;

	public int fadeMSec;

	public int delayMSec;

	protected int curMsec;

	protected SQEX_SoundPlayer sndmgr;

	public SQEX_BgmStarter()
	{
		bgm = SQEX_SoundPlayerData.BGM.NONE;
		loop = -1;
		vol = 0.5f;
	}

	public void Start()
	{
		sndmgr = SQEX_SoundPlayer.Instance;
	}

	public void Update()
	{
		curMsec = checked((int)((float)curMsec + Time.deltaTime * 1000f));
		if (delayMSec > curMsec)
		{
			return;
		}
		if ((bool)sndmgr)
		{
			if (sndmgr.IsPlayBgm())
			{
				SQEX_SoundPlayer sQEX_SoundPlayer = sndmgr;
				string[] bgmList = SQEX_SoundPlayerData.bgmList;
				if (sQEX_SoundPlayer.IsLastBgm(bgmList[RuntimeServices.NormalizeArrayIndex(bgmList, (int)bgm)]))
				{
					return;
				}
			}
			int num = sndmgr.PlayBgm((int)bgm, loop, fadeMSec, fadeMSec);
			SQEX_SoundPlayer.BgmVolume = vol;
		}
		UnityEngine.Object.DestroyObject(gameObject);
	}
}
