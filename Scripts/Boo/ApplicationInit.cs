using System;
using UnityEngine;

[Serializable]
public class ApplicationInit : MonoBehaviour
{
	public void Awake()
	{
		Application.targetFrameRate = 60;
	}
}
