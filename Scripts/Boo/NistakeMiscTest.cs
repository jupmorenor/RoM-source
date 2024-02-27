using System;
using UnityEngine;

[Serializable]
public class NistakeMiscTest : MonoBehaviour
{
	public UnityEngine.Object[] objs;

	public NistakeMiscTest()
	{
		objs = new UnityEngine.Object[0];
	}

	public void Start()
	{
		int i = 0;
		UnityEngine.Object[] array = objs;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
		}
	}
}
