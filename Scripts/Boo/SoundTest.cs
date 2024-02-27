using System;
using UnityEngine;

[Serializable]
public class SoundTest : MonoBehaviour
{
	public SQEX_SoundPlayer soundPlayer;

	public int delay;

	public int loop;

	public bool pauseSe;

	public bool pauseBgm;

	public float volBgm;

	public float volSe;

	public float volMaster;

	public SQEX_SoundPlayerData.BGM bgm1;

	public SQEX_SoundPlayerData.BGM bgm2;

	public SQEX_SoundPlayerData.SE se1;

	public SQEX_SoundPlayerData.SE se2;

	public SQEX_SoundPlayerData.SE se3;

	public SQEX_SoundPlayerData.SE se4;

	public SoundTest()
	{
		loop = -1;
		volBgm = 1f;
		volSe = 1f;
		volMaster = 1f;
	}

	public void Start()
	{
		soundPlayer = SQEX_SoundPlayer.Instance;
	}

	public void OnGUI()
	{
		int num = 10;
		int num2 = 200;
		int num3 = checked(num + num2 + 40);
		int num4 = 5;
		int num5 = 50;
		if (GUI.Button(new Rect(num, num4, num2, num5), "BGM1 Start"))
		{
			soundPlayer.PlayBgm((int)bgm1, loop, delay, delay);
		}
		if (GUI.Button(new Rect(num3, num4, num2, num5), "BGM2 Start"))
		{
			soundPlayer.PlayBgm((int)bgm2, loop, delay, delay);
		}
		num4 = checked(num4 + (num5 + 10));
		if (GUI.Button(new Rect(num, num4, num2, num5), "SE1"))
		{
			soundPlayer.PlaySe((int)se1, delay, gameObject.GetInstanceID());
		}
		if (GUI.Button(new Rect(num3, num4, num2, num5), "SE2"))
		{
			soundPlayer.PlaySe((int)se2, delay, gameObject.GetInstanceID());
		}
		num4 = checked(num4 + (num5 + 10));
		if (GUI.Button(new Rect(num, num4, num2, num5), "SE3"))
		{
			soundPlayer.PlaySe((int)se3, delay, gameObject.GetInstanceID());
		}
		if (GUI.Button(new Rect(num3, num4, num2, num5), "SE4"))
		{
			soundPlayer.PlaySe((int)se4, delay, gameObject.GetInstanceID());
		}
		checked
		{
			num4 += num5 + 10;
			if (GUI.Button(new Rect(num, num4, num2, num5), "Stop SE"))
			{
				soundPlayer.StopAllSe(delay);
			}
			if (GUI.Button(new Rect(num3, num4, num2, num5), "Stop BGM"))
			{
				soundPlayer.StopBgm(delay);
			}
			num4 += num5 + 10;
			if (GUI.Button(new Rect(num, num4, num2, num5), "Pause SE"))
			{
				pauseSe = !pauseSe;
				soundPlayer.PauseAllSe(pauseSe);
			}
			if (GUI.Button(new Rect(num3, num4, num2, num5), "Pause BGM"))
			{
				pauseBgm = !pauseBgm;
				soundPlayer.PauseBgm(pauseBgm);
			}
			num4 += num5 + 5;
			GUI.Label(new Rect(num, num4, num2, num5), "BGM Vol:" + volBgm);
			float num6 = GUI.HorizontalSlider(new Rect(num3, num4, num2, num5), volBgm, 0f, 1f);
			if (num6 != volBgm)
			{
				SQEX_SoundPlayer.BgmVolume = num6;
				volBgm = num6;
			}
			num4 += num5 + 5;
			GUI.Label(new Rect(num, num4, num2, num5), "SE Vol:" + volSe);
			float num7 = GUI.HorizontalSlider(new Rect(num3, num4, num2, num5), volSe, 0f, 1f);
			if (num7 != volSe)
			{
				SQEX_SoundPlayer.SeVolume = num7;
				volSe = num7;
			}
			num4 += num5 + 5;
			GUI.Label(new Rect(num, num4, num2, num5), "Master Vol:" + volMaster);
			float num8 = GUI.HorizontalSlider(new Rect(num3, num4, num2, num5), volMaster, 0f, 1f);
			if (num8 != volMaster)
			{
				SQEX_SoundPlayer.MasterVolume = num8;
				volMaster = num8;
			}
			num4 += num5 + 5;
			GUI.Label(new Rect(num, num4, num2, num5), "Delay:" + delay);
			float num9 = GUI.HorizontalSlider(new Rect(num3, num4, num2, num5), (float)delay * 0.001f, 0f, 10f) * 1000f;
			if (num9 != (float)delay)
			{
				delay = (int)num9;
			}
			num4 += num5 + 5;
			GUI.Label(new Rect(num, num4, num2, num5), "Loop:" + loop);
			float num10 = GUI.HorizontalSlider(new Rect(num3, num4, num2, num5), loop, -1f, 10f);
			if (num10 != (float)loop)
			{
				loop = (int)num10;
			}
		}
	}
}
