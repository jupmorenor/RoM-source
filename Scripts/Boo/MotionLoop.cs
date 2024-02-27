using System;
using UnityEngine;

[Serializable]
public class MotionLoop : MonoBehaviour
{
	public void Update()
	{
		if (!animation.isPlaying)
		{
			animation.Play();
		}
	}
}
