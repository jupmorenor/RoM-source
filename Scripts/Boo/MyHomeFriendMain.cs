using System;
using UnityEngine;

[Serializable]
public class MyHomeFriendMain : MonoBehaviour
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
			if (count >= 100)
			{
				SceneChanger.ChangeTo(SceneID.Ui_CheckUpdate);
			}
		}
	}
}
