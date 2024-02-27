using System;
using UnityEngine;

[Serializable]
public class HUDNum : MonoBehaviour
{
	protected int number;

	public UILabel label;

	public override int Num
	{
		get
		{
			return number;
		}
		set
		{
			if (number != value)
			{
				number = value;
				if (label != null)
				{
					label.text = number.ToString();
				}
			}
		}
	}

	public void show()
	{
		gameObject.SetActive(value: true);
	}

	public void hide()
	{
		gameObject.SetActive(value: false);
	}
}
