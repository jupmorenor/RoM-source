using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class TestAnimationLayer : MonoBehaviour
{
	protected readonly int FACIAL_LAYER_NUM;

	public TestAnimationLayer()
	{
		FACIAL_LAYER_NUM = 10;
	}

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
			if (RuntimeServices.op_Member("_facial", animationState.name))
			{
				setupFacialClip(animationState);
			}
		}
	}

	public void setupFacialClip(AnimationState a)
	{
		a.layer = FACIAL_LAYER_NUM;
		a.wrapMode = WrapMode.Loop;
		a.enabled = false;
		a.weight = 1f;
	}
}
