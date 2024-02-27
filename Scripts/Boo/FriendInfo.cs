using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class FriendInfo : UIListItem
{
	public MuppetInfo leaderPetInfo;

	public UILabelBase friendNameLabel;

	public UILabelBase friendLevelLabel;

	public UILabelBase friendTeamNameLabel;

	public string levelFormat;

	public string oldFreiendPointFomart;

	public UILabelBase oldFriendPointLabel;

	public UILabelBase newFriendPointLabel;

	public UILabelBase loginTimeLabel;

	public string[] timeFormat;

	public Transform iconParent;

	public GameObject iconPrefab;

	private RespFriend friendInfo;

	protected bool init;

	public FriendInfo()
	{
		levelFormat = "lv.{0}";
		oldFreiendPointFomart = "{0}(+{1})";
		timeFormat = new string[4] { "1時間以内", "{0}時間前", "{0}日前", "5日以上" };
	}

	public void Start()
	{
		Init();
	}

	public override void Init()
	{
		if (init)
		{
			return;
		}
		init = true;
		if (!leaderPetInfo && (bool)iconPrefab)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(iconPrefab);
			if ((bool)gameObject)
			{
				leaderPetInfo = gameObject.GetComponent<MuppetInfo>();
				gameObject.transform.parent = iconParent;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
			}
		}
		InitInfo();
	}

	public void InitInfo()
	{
		if ((bool)leaderPetInfo)
		{
			leaderPetInfo.DestroyLevel();
			leaderPetInfo.SetMuppet(null);
		}
		if ((bool)friendNameLabel)
		{
			friendNameLabel.text = string.Empty;
		}
		if ((bool)friendLevelLabel)
		{
			friendLevelLabel.text = string.Empty;
		}
		if ((bool)newFriendPointLabel)
		{
			newFriendPointLabel.text = string.Empty;
		}
		if ((bool)oldFriendPointLabel)
		{
			oldFriendPointLabel.text = string.Empty;
		}
		if ((bool)loginTimeLabel)
		{
			loginTimeLabel.text = string.Empty;
		}
		if ((bool)friendTeamNameLabel)
		{
			friendTeamNameLabel.text = "なし";
		}
	}

	public void SetFriend(RespFriend resp)
	{
		Init();
		friendInfo = resp;
		if (resp == null)
		{
			return;
		}
		if ((bool)leaderPetInfo)
		{
			leaderPetInfo.SetMuppet(resp.GetFriendPet(), ignoreUnknown: true);
		}
		if ((bool)friendNameLabel)
		{
			friendNameLabel.text = resp.Name;
		}
		if ((bool)friendLevelLabel)
		{
			friendLevelLabel.text = UIBasicUtility.SafeFormat(levelFormat, resp.CharacterLevel);
		}
		checked
		{
			if ((bool)loginTimeLabel)
			{
				DateTime utcNow = MerlinDateTime.UtcNow;
				TimeSpan timeSpan = utcNow - resp.LastAccessDate;
				if ((int)timeSpan.TotalDays >= 5)
				{
					loginTimeLabel.text = UIBasicUtility.SafeFormat(timeFormat[3], 5);
				}
				else if ((int)timeSpan.TotalDays > 0)
				{
					loginTimeLabel.text = UIBasicUtility.SafeFormat(timeFormat[2], (int)timeSpan.TotalDays);
				}
				else if ((int)timeSpan.TotalHours > 0)
				{
					loginTimeLabel.text = UIBasicUtility.SafeFormat(timeFormat[1], (int)timeSpan.TotalHours);
				}
				else if ((int)timeSpan.TotalMinutes > 0)
				{
					loginTimeLabel.text = UIBasicUtility.SafeFormat(timeFormat[0], (int)timeSpan.TotalMinutes);
				}
			}
		}
	}

	public void SetFriendPoint(int oldPoint, int newPoint)
	{
		if ((bool)newFriendPointLabel)
		{
			newFriendPointLabel.text = newPoint.ToString();
		}
		if ((bool)oldFriendPointLabel)
		{
			oldFriendPointLabel.text = UIBasicUtility.SafeFormat(oldFreiendPointFomart, oldPoint, checked(newPoint - oldPoint));
		}
	}
}
