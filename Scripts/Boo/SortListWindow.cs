using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class SortListWindow : MonoBehaviour
{
	public UILabelBase titleLabel;

	public Transform[] buttons;

	private SortListButton activeButton;

	private Dictionary<string, SortListButton> dict;

	public SortListWindow()
	{
		dict = new Dictionary<string, SortListButton>();
	}

	public Transform GetButtonTrans(object i)
	{
		Transform[] array = buttons;
		return array[RuntimeServices.NormalizeArrayIndex(array, RuntimeServices.UnboxInt32(i))];
	}

	public void AddButton(string key, SortListButton btn)
	{
		if (dict.ContainsKey(key))
		{
		}
		dict[key] = btn;
	}

	public SortListButton SelectButton(string key)
	{
		if (dict.ContainsKey(key))
		{
			if ((bool)activeButton)
			{
				activeButton.Select(select: false);
			}
			activeButton = dict[key];
			activeButton.Select(select: true);
		}
		return null;
	}

	public void Awake()
	{
		UIBasicUtility.SetLabel(titleLabel, MTexts.Get("sort_window_title").msg, show: true);
	}
}
