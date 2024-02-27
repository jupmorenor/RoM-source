using System;
using UnityEngine;

[Serializable]
public class RaidNamePlate : MonoBehaviour
{
	public UILabelBase[] ラベル;

	private string value;

	public UILabelBase[] Labels => ラベル;

	public void setName(string s)
	{
		if (s == null || Labels == null || !(value != s))
		{
			return;
		}
		value = s;
		int i = 0;
		UILabelBase[] labels = Labels;
		for (int length = labels.Length; i < length; i = checked(i + 1))
		{
			if (labels[i] != null)
			{
				labels[i].text = s;
			}
		}
	}

	public void setColor(Color c)
	{
		if (!(Labels == null) && Labels.Length != 0)
		{
			Labels[0].color = c;
		}
	}
}
