using System;
using System.Text;
using UnityEngine;

[Serializable]
public class GaugeWithLabels : MonoBehaviour
{
	public GameObject root;

	public UISlider slider;

	public UILabel upperTextLabel;

	public UIDynamicFontLabel lowerTextLabel;

	public string UpperText
	{
		get
		{
			return (!(upperTextLabel != null)) ? string.Empty : upperTextLabel.text;
		}
		set
		{
			if (upperTextLabel != null)
			{
				upperTextLabel.text = value;
			}
		}
	}

	public string LowerText
	{
		get
		{
			return (!(lowerTextLabel != null)) ? string.Empty : lowerTextLabel.m_Text;
		}
		set
		{
			if (lowerTextLabel != null)
			{
				lowerTextLabel.m_Text = value;
			}
		}
	}

	public void setSliderValue(int val, int maximum, bool withText)
	{
		if (maximum > 0)
		{
			UpperText = new StringBuilder().Append((object)val).Append("/").Append((object)maximum)
				.ToString();
			float sliderValue = Mathf.Clamp01((float)val / (float)maximum);
			if (slider != null)
			{
				slider.sliderValue = sliderValue;
			}
		}
	}

	public void activate(bool b)
	{
		if (root != null)
		{
			root.SetActive(b);
		}
		if (slider != null)
		{
			slider.gameObject.SetActive(b);
		}
		if (upperTextLabel != null)
		{
			upperTextLabel.gameObject.SetActive(b);
		}
		if (lowerTextLabel != null)
		{
			lowerTextLabel.gameObject.SetActive(b);
		}
	}
}
