using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MissionListItem : UIListItem
{
	public UILabelBase textDetailLabel;

	public UILabelBase textRewardLabel;

	public GameObject newIcon;

	public GameObject clearIcon;

	public GameObject commonIconObject;

	public GameObject mapetBGObject;

	public GameObject weaponBGObject;

	public GameObject numPanel;

	public UILabelBase textNumLabel;

	public GameObject contentsRoot;

	public MissionListItem childMissionListItem;

	public bool isClear;

	public RespQuestMission mission;
}
