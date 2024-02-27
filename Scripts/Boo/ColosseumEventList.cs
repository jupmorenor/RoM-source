using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ColosseumEventList : UIListBase
{
	public bool oneSelectToggle;

	public void SetEvents(RespColosseumEvent[] list)
	{
		if (!isInitFinished)
		{
			Initialize(list, gameObject, autoTween: true);
		}
		else
		{
			UpdateData(list);
		}
	}

	public void Awake()
	{
		hookAutoFocusItem = colosseumEventHookAutoFocusItem;
		hookSettingListItem = colosseumEventHookSettingListItem;
	}

	public override long CreateID(object data)
	{
		RespColosseumEvent respColosseumEvent = data as RespColosseumEvent;
		return respColosseumEvent.Id;
	}

	public bool colosseumEventHookAutoFocusItem(ref UIListItem.Data dstData)
	{
		dstData = null;
		return false;
	}

	public bool colosseumEventHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		ColosseumEventListItem colosseumEventListItem = (ColosseumEventListItem)item;
		RespColosseumEvent data = item.GetData<RespColosseumEvent>();
		colosseumEventListItem.SetEvent(data);
		return false;
	}
}
