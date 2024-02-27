using System;
using UnityEngine;

[Serializable]
public class EnemyPop : MonoBehaviour
{
	public void Start()
	{
		if ((bool)Camera.main)
		{
			CameraControl component = Camera.main.GetComponent<CameraControl>();
			if ((bool)component)
			{
				component.battleCameraUpdate();
			}
		}
	}
}
