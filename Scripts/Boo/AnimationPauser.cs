using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AnimationPauser : Pauser
{
	public void Start()
	{
		setSpeed(0f);
	}

	public override void unpause()
	{
		setSpeed(1f);
	}

	private void setSpeed(float spd)
	{
		IEnumerator enumerator = animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			animationState.speed = spd;
		}
	}
}
