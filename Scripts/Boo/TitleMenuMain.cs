using System;
using UnityEngine;

[Serializable]
public class TitleMenuMain : MonoBehaviour
{
	public int count;

	public void Start()
	{
		count = 0;
	}

	public void Update()
	{
		checked
		{
			count++;
			if (count >= 1000)
			{
				SceneChanger.ChangeTo(SceneID.Prologue);
			}
		}
	}

	public void TouchStart()
	{
		SceneChanger.ChangeTo(SceneID.Myhome);
	}

	public void TouchContinue()
	{
		SceneChanger.ChangeTo(SceneID.Myhome);
	}

	public void TouchPreference()
	{
		SceneChanger.ChangeTo(SceneID.Myhome);
	}
}
