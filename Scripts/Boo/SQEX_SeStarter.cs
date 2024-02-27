using System;
using UnityEngine;

[Serializable]
public class SQEX_SeStarter : MonoBehaviour
{
	public SQEX_SoundPlayerData.SE se;

	public float vol;

	public float pan;

	public int fadeMSec;

	public int delayMSec;

	protected int curMsec;

	protected SQEX_SoundPlayer sndmgr;

	public SQEX_SeStarter()
	{
		se = SQEX_SoundPlayerData.SE.NONE;
		vol = 0.5f;
	}

	public void Start()
	{
		sndmgr = SQEX_SoundPlayer.Instance;
	}

	public void Update()
	{
		curMsec = checked((int)((float)curMsec + Time.deltaTime * 1000f));
		if (delayMSec <= curMsec)
		{
			if ((bool)sndmgr)
			{
				int soundID = sndmgr.PlaySe((int)se, fadeMSec, gameObject.GetInstanceID());
				sndmgr.SetSeVoulme(soundID, vol);
			}
			UnityEngine.Object.DestroyObject(gameObject);
		}
	}
}
