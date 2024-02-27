using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MyHomeUI : MonoBehaviour
{
	public UIButtonMessage[] buttons;

	public UIButtonMessage[] AllButtons
	{
		get
		{
			List<UIButtonMessage> list = new List<UIButtonMessage>();
			int i = 0;
			UIButtonMessage[] array = buttons;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] != null)
				{
					list.Add(array[i]);
				}
			}
			return list.ToArray();
		}
	}

	public GameObject[] AllButtonObjects
	{
		get
		{
			List<GameObject> list = new List<GameObject>();
			int i = 0;
			UIButtonMessage[] array = buttons;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] != null)
				{
					list.Add(array[i].gameObject);
				}
			}
			return list.ToArray();
		}
	}

	public void show(bool b)
	{
		int i = 0;
		GameObject[] allButtonObjects = AllButtonObjects;
		for (int length = allButtonObjects.Length; i < length; i = checked(i + 1))
		{
			allButtonObjects[i].SetActive(b);
		}
	}
}
