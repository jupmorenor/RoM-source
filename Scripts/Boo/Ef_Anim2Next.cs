using System;
using UnityEngine;

[Serializable]
public class Ef_Anim2Next : MonoBehaviour
{
	public string startAnim;

	public string nextAnim;

	public bool ready;

	public AnimationState Anim(string name)
	{
		return animation[name];
	}

	public void Fade2Next(string start, string next, float fadeTime)
	{
		startAnim = start;
		nextAnim = next;
		if (animation.isPlaying && !(fadeTime <= 0f))
		{
			animation[startAnim].time = 0f;
			animation[nextAnim].time = 0f;
			animation.CrossFade(startAnim, fadeTime);
		}
		else
		{
			animation.Play(startAnim);
		}
		animation[startAnim].wrapMode = WrapMode.ClampForever;
		ready = true;
	}

	public void Update()
	{
		if (ready && !(animation[startAnim].time < animation[startAnim].length))
		{
			animation.Play(nextAnim);
			ready = false;
		}
	}

	public void Play(string anim)
	{
		animation.Play(anim);
	}

	public void CrossFade(string anim, float fadeTime)
	{
		animation.CrossFade(anim, fadeTime);
	}

	public void Stop()
	{
		animation.Stop();
	}

	public void Speed(string anim, float spd)
	{
		if ((bool)animation[anim])
		{
			animation[anim].speed = spd;
		}
	}

	public bool IsPlaying(string name)
	{
		return animation.IsPlaying(name);
	}
}
