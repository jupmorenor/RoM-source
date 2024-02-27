using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
public class AnimationSort : MonoBehaviour
{
	public bool sortAnim;

	public void Update()
	{
		if (!sortAnim || !animation)
		{
			return;
		}
		SortedDictionary<string, AnimationClip> sortedDictionary = new SortedDictionary<string, AnimationClip>();
		AnimationClip animationClip = null;
		IEnumerator enumerator = animation.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			sortedDictionary[animationState.name] = animationState.clip;
		}
		foreach (AnimationClip value in sortedDictionary.Values)
		{
			if ((bool)animation[value.name])
			{
				animation.RemoveClip(value.name);
			}
		}
		foreach (AnimationClip value2 in sortedDictionary.Values)
		{
			if ((bool)animation[value2.name])
			{
				animation.RemoveClip(value2.name);
			}
		}
		foreach (AnimationClip value3 in sortedDictionary.Values)
		{
			if (!animation[value3.name])
			{
				animation.AddClip(value3, value3.name);
			}
		}
		sortAnim = false;
	}
}
