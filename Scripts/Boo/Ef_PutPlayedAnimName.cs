using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_PutPlayedAnimName : MonoBehaviour
{
	private float[] lstTimes;

	public void Start()
	{
		lstTimes = new float[100];
	}

	public void Update()
	{
		if (!animation)
		{
			return;
		}
		string text = string.Empty;
		int num = 0;
		int num2 = 0;
		IEnumerator enumerator = animation.GetEnumerator();
		checked
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				float time = animationState.time;
				float[] array = lstTimes;
				if (time != array[RuntimeServices.NormalizeArrayIndex(array, num2)])
				{
					text += animationState.name + ":" + animationState.time.ToString();
					if (num > 0)
					{
						text += "\n";
					}
					float[] array2 = lstTimes;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num2)] = animationState.time;
				}
				num++;
				num2++;
			}
			Debug.Log(text);
		}
	}
}
