using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class AnimationLastFrameSkip : MonoBehaviour
{
	public void Start()
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
			animationState.time = animationState.length;
		}
	}
}
