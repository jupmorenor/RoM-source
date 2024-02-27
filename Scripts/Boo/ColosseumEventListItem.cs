using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumEventListItem : UIListItem
{
	public UILabelBase nameLabel;

	public UILabelBase costLabel;

	public GameObject costIcon;

	public GameObject freeIcon;

	private RespColosseumEvent mevent;

	private UIValidController validCtlr;

	public bool enableHideCostIsZero;

	public bool enableDispFreeIsZero;

	public ColosseumEventListItem()
	{
		enableDispFreeIsZero = true;
	}

	public void Update()
	{
		UpdateCost();
	}

	private void UpdateCost()
	{
		if (mevent == null)
		{
			return;
		}
		if (null == validCtlr)
		{
			validCtlr = ExtensionsModule.SetComponent<UIValidController>(gameObject);
		}
		if (!(null == validCtlr))
		{
			if (mevent.BpCost > 0)
			{
				validCtlr.isValidColor = UserData.Current.Bp >= mevent.BpCost;
			}
			else
			{
				validCtlr.isValidColor = true;
			}
		}
	}

	public void SetEvent(RespColosseumEvent ev)
	{
		if (ev == null)
		{
			return;
		}
		mevent = ev;
		if (null != nameLabel)
		{
			nameLabel.text = ev.Name;
		}
		if (null != costLabel)
		{
			costLabel.text = ev.BpCost.ToString();
		}
		UpdateCost();
		if (ev.BpCost > 0)
		{
			if (null != costLabel)
			{
				costLabel.gameObject.SetActive(value: true);
			}
			if (null != costIcon)
			{
				costIcon.SetActive(value: true);
			}
			if (null != freeIcon)
			{
				freeIcon.SetActive(value: false);
			}
		}
		else
		{
			if (null != costLabel)
			{
				costLabel.gameObject.SetActive(!enableHideCostIsZero);
			}
			if (null != costIcon)
			{
				costIcon.SetActive(!enableHideCostIsZero);
			}
			if (null != freeIcon)
			{
				freeIcon.SetActive(enableDispFreeIsZero);
			}
		}
	}
}
