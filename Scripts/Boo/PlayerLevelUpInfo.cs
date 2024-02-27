using System;
using UnityEngine;

[Serializable]
public class PlayerLevelUpInfo : MonoBehaviour
{
	public UILabelBase oldLevelLabel;

	public UILabelBase newLevelLabel;

	public UILabelBase newlevelMessageLabel;

	public UILabelBase newStatusMessageLabel;

	public UILabelBase oldStatusLabel;

	public UILabelBase newStatusLabel;

	public int oldLevel
	{
		set
		{
			if ((bool)oldLevelLabel)
			{
				oldLevelLabel.text = "lv" + value.ToString();
			}
		}
	}

	public int newLevel
	{
		set
		{
			if ((bool)newLevelLabel)
			{
				newLevelLabel.text = "lv" + value.ToString();
			}
		}
	}

	public string newLevelMessage
	{
		set
		{
			if ((bool)newlevelMessageLabel)
			{
				newlevelMessageLabel.text = value;
			}
		}
	}

	public string newStatusMessage
	{
		set
		{
			if ((bool)newStatusMessageLabel)
			{
				newStatusMessageLabel.text = value;
			}
		}
	}

	public int oldStatus
	{
		set
		{
			if ((bool)oldStatusLabel)
			{
				oldStatusLabel.text = value.ToString();
			}
		}
	}

	public int newStatus
	{
		set
		{
			if ((bool)newStatusLabel)
			{
				newStatusLabel.text = value.ToString();
			}
		}
	}

	public void Init()
	{
		if ((bool)oldLevelLabel)
		{
			oldLevelLabel.text = string.Empty;
		}
		if ((bool)newLevelLabel)
		{
			newLevelLabel.text = string.Empty;
		}
		if ((bool)newStatusMessageLabel)
		{
			newStatusMessageLabel.text = string.Empty;
		}
		if ((bool)oldStatusLabel)
		{
			oldStatusLabel.text = string.Empty;
		}
		if ((bool)newStatusLabel)
		{
			newStatusLabel.text = string.Empty;
		}
	}

	public void Start()
	{
	}

	public void Update()
	{
	}
}
