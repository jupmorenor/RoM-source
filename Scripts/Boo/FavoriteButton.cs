using System;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class FavoriteButton : MonoBehaviour
{
	public UIListItemDetail detail;

	public UIListBase listBase;

	public GameObject favoriteObject;

	private UserData ud;

	private RespPlayerBox lastBox;

	public void Start()
	{
		if (!(detail != null))
		{
			throw new AssertionFailedException("このボタンに UIListItemDetail が設定されていません!!!");
		}
		ud = UserData.Current;
	}

	public void Update()
	{
		RespPlayerBox box = GetBox();
		if (box != null && lastBox == null)
		{
			lastBox = box;
		}
		if (box != null && lastBox != null && !RuntimeServices.EqualityOperator(box.Id, lastBox.Id))
		{
			lastBox = box;
			UpdateIcon(box);
		}
	}

	public void PushFavorite(GameObject obj)
	{
		RespPlayerBox box = GetBox();
		ud.SwitchFavorite(box);
		UpdateIcon(box);
		if ((bool)listBase && (bool)detail)
		{
			listBase.ReceiveChangeItemData(detail.GetDetail());
		}
	}

	private RespPlayerBox GetBox()
	{
		UIListItem.Data data = detail.GetDetail();
		return (data != null) ? RespPlayerBox.ConvertRespPlayerBox(data.GetData<JsonBase>()) : null;
	}

	private void UpdateIcon(RespPlayerBox box)
	{
		if ((bool)favoriteObject)
		{
			favoriteObject.SetActive(ud.IsFavorite(box));
		}
	}
}
