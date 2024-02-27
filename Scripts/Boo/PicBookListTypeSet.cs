using System;
using UnityEngine;

[Serializable]
public class PicBookListTypeSet : MonoBehaviour
{
	public UIMain uiMain;

	public PicBookList listObject;

	public PicBookDetailWindow detailWindow;

	public PicBookModelWindow showModelWindow;

	public PicBookData selectedData;

	public void SelectData(PicBookData selectData)
	{
		selectedData = selectData;
	}

	public void ShowDetail()
	{
		if (selectedData != null)
		{
			detailWindow.SetSelectedData(selectedData);
			ChangeSituation(PIC_BOOK_MAIN.Detail);
		}
	}

	public void ShowModel()
	{
		if (selectedData != null && selectedData.IsHave())
		{
			showModelWindow.SetSelectedData(selectedData);
			ChangeSituation(PIC_BOOK_MAIN.Model);
		}
	}

	public void ChangeSituation(PIC_BOOK_MAIN mainMode)
	{
		if (uiMain != null)
		{
			uiMain.SendMessage("SetSituation", mainMode);
		}
	}

	public void Show()
	{
		ObjectsSetActive(active: true);
	}

	public void Hide()
	{
		ObjectsSetActive(active: false);
	}

	public void ObjectsSetActive(bool active)
	{
		listObject.gameObject.SetActive(active);
		detailWindow.gameObject.SetActive(active);
		showModelWindow.gameObject.SetActive(active);
	}
}
