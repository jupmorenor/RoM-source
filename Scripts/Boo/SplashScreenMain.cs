using System;
using UnityEngine;

[Serializable]
public class SplashScreenMain : MonoBehaviour
{
	public int count;

	public bool test;

	public void Awake()
	{
		Application.targetFrameRate = 60;
	}

	public void Start()
	{
		count = 0;
	}

	public void Update()
	{
	}
}
