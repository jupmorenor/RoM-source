using System;
using UnityEngine;

[Serializable]
public class Ef_PlayAnim : MonoBehaviour
{
	public string animName;

	public bool animate;

	public void PlayAnim(string aniName)
	{
		if ((bool)animation)
		{
			animation.Play(aniName);
		}
	}

	public void FadeAnim(string aniName)
	{
		if ((bool)animation)
		{
			animation.CrossFade(aniName, 0.5f);
		}
	}

	public void StopAnim()
	{
		if ((bool)animation)
		{
			animation.Stop();
		}
	}

	public void Update()
	{
		if (animate)
		{
			if (animName.Length > 0)
			{
				PlayAnim(animName);
			}
			else
			{
				StopAnim();
			}
			animate = false;
		}
	}
}
