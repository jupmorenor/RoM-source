using System;
using Boo.Lang;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class LogMessageList : UIListBase
{
	public void SetLogMessageList(RespBattleLogs[] list)
	{
		if (!isInitFinished)
		{
			ResetSortFunc();
			SetSortFunc("new", sortFunc);
			SetSortTypeName(new string[1] { "new" }, 0);
			Initialize(list, gameObject, autoTween: true);
		}
		else
		{
			UpdateData(list);
			SimpleSort("new");
		}
	}

	private void Awake()
	{
		hookSettingListItem = logHookSettingListItem;
	}

	private List<Container> sortFunc(List<Container> container)
	{
		__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24__ from = delegate(Container a, Container b)
		{
			long id = a.data.id;
			long id2 = b.data.id;
			return (id != id2) ? ((id2 >= id) ? 1 : (-1)) : 0;
		};
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(from)));
	}

	public override long CreateID(object data)
	{
		RespBattleLogs respBattleLogs = data as RespBattleLogs;
		DateTime logTime = respBattleLogs.LogTime;
		return logTime.Ticks;
	}

	private bool logHookSettingListItem(UIListItem item)
	{
		item.Select = false;
		float z = -2f;
		Vector3 localPosition = item.transform.localPosition;
		float num = (localPosition.z = z);
		Vector3 vector2 = (item.transform.localPosition = localPosition);
		LogMessageListItem logMessageListItem = (LogMessageListItem)item;
		logMessageListItem.SetInfo(item.GetData<RespBattleLogs>());
		NGUITools.DestroyAllSameComponent<UIPanel>(item.gameObject);
		return false;
	}

	internal int _0024sortFunc_0024newList_00245007(Container a, Container b)
	{
		long id = a.data.id;
		long id2 = b.data.id;
		return (id != id2) ? ((id2 >= id) ? 1 : (-1)) : 0;
	}
}
