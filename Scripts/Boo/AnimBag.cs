using System;
using System.Text;
using UnityEngine;

[Serializable]
public class AnimBag : MonoBehaviour
{
	public AnimationClip[] anims;

	public void Start()
	{
		int i = 0;
		AnimationClip[] array = anims;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			MonoBehaviour.print(new StringBuilder("anim type=").Append(array[i].GetType()).ToString());
		}
	}
}
