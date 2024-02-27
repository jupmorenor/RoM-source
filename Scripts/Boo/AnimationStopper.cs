using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AnimationStopper
{
	[Serializable]
	public struct AnimStopState
	{
		public Animation animation;

		public AnimationState animState;

		public float speed;

		public bool enabled;

		public AnimStopState(Animation _animation, AnimationState _animState)
		{
			animation = _animation;
			animState = _animState;
			speed = animState.speed;
		}

		public void restore()
		{
			if (!(animState == null))
			{
				animState.speed = speed;
			}
		}
	}

	private Boo.Lang.List<AnimStopState> lastStoppedInfo;

	public AnimationStopper()
	{
		lastStoppedInfo = new Boo.Lang.List<AnimStopState>();
	}

	public void stop()
	{
		lastStoppedInfo.Clear();
		int i = 0;
		Animation[] array = (Animation[])UnityEngine.Object.FindObjectsOfType(typeof(Animation));
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] == null)
			{
				continue;
			}
			IEnumerator enumerator = array[i].GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				if (!(animationState == null))
				{
					lastStoppedInfo.Add(new AnimStopState(array[i], animationState));
					animationState.speed = 0f;
				}
			}
		}
	}

	public void restart()
	{
		IEnumerator<AnimStopState> enumerator = lastStoppedInfo.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.restore();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		lastStoppedInfo.Clear();
	}
}
