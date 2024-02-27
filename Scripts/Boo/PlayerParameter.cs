using System;
using UnityEngine;

[Serializable]
public class PlayerParameter : MonoBehaviour
{
	[NonSerialized]
	private static PlayerParameter instance;

	public static void SetActive(bool a)
	{
		if ((bool)Instance())
		{
			Instance().gameObject.SetActive(a);
		}
	}

	public static PlayerParameter Instance()
	{
		if (!instance)
		{
			instance = (PlayerParameter)UnityEngine.Object.FindObjectOfType(typeof(PlayerParameter));
		}
		return instance;
	}
}
