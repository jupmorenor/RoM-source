using System;
using UnityEngine;

[Serializable]
public abstract class Pauser : MonoBehaviour
{
	public float pauseTime;

	private bool unpaused;

	public void Update()
	{
		if (!unpaused)
		{
			pauseTime -= Time.deltaTime;
			if (!(pauseTime > 0f))
			{
				unpause();
				unpaused = true;
			}
		}
	}

	public virtual void unpause()
	{
	}
}
