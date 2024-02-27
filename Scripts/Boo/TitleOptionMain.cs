using System;
using UnityEngine;

[Serializable]
public class TitleOptionMain : MonoBehaviour
{
	public void Start()
	{
	}

	public void Update()
	{
	}

	public void PushOk()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
	}

	public void PushBack()
	{
		SceneChanger.ChangeTo(SceneID.Ui_TitleLogo);
	}
}
