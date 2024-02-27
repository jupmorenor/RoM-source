using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class FriendListItem : MapetListItem
{
	public UILabel userLvLabel;

	public UILabelBase lastLoginLabel;

	public UILabelBase lastLoginDateLabel;

	public RespFriend friend;

	public GameObject focusedMarker;

	public UIWidget newIcon;

	public bool Focused
	{
		set
		{
			focusedMarker.SetActive(value);
			ExtensionsModule.FindChild(focusedMarker, "Cursor").SetActive(value);
		}
	}

	public void SetFriend(RespFriend friend)
	{
		checked
		{
			if (friend is RespGuildPlayer respGuildPlayer)
			{
				lastLoginLabel.text = "貢献度";
				SetFriend(respGuildPlayer, $"{(long)respGuildPlayer.RankingPoint}Pt");
				return;
			}
			string text = "friend";
			TimeSpan timeSpan = MerlinDateTime.UtcNow - friend.LastAccessDate;
			int num = (int)timeSpan.TotalDays;
			if (num >= 5)
			{
				text = $"5日以上";
			}
			else if (0 >= num)
			{
				text = ((0 >= (int)timeSpan.TotalHours) ? "1時間以内" : $"{timeSpan.Hours}時間前");
			}
			else
			{
				string arg = num.ToString();
				text = $"{arg}日前";
			}
			lastLoginLabel.text = "最終ログイン";
			SetFriend(friend, text);
		}
	}

	private void SetFriend(RespFriend f, string loginText)
	{
		friend = f;
		enableUserNameLabel = true;
		enableIconSprite = true;
		enableIconElemSprite = true;
		enableRankSprite = true;
		RespPoppet friendPet = friend.GetFriendPet();
		GameObject gameObject = SetMapet(friendPet);
		iconOption = null;
		UILabelBase component = ExtensionsModule.FindChild(gameObject, "LevelText").GetComponent<UILabelBase>();
		component.text = "lv" + friendPet.Level;
		UIBasicUtility.SetLabelColor(component, friendPet.LevelColor);
		if ((bool)focusAreaBase)
		{
			UnityEngine.Object.Destroy(focusAreaBase);
		}
		userLvLabel.text = "lv" + friend.CharacterLevel;
		userNameLabel.text = friend.Name;
		lastLoginDateLabel.text = loginText;
		gameObject.transform.parent = ExtensionsModule.FindChild(this.gameObject, "PoppetBG").transform;
		gameObject.transform.localScale = Vector3.one;
	}

	public new void SetNew(bool b)
	{
		newIcon.enabled = b;
	}
}
