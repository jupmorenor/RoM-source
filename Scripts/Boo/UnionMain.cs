using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class UnionMain : UIMain
{
	[Serializable]
	public enum UNION_MAIN
	{
		TopMenu,
		MemberList,
		Max
	}

	[Serializable]
	internal class _0024PushFriendTeam_0024locals_002414549
	{
		internal string _0024msg;
	}

	[Serializable]
	internal class _0024Request_0024locals_002414550
	{
		internal RequestBase _0024req;

		internal Action<RequestBase> _0024act;
	}

	[Serializable]
	internal class _0024PushFriendTeam_0024closure_00245126
	{
		internal _0024PushFriendTeam_0024locals_002414549 _0024_0024locals_002415222;

		internal UnionMain _0024this_002415223;

		public _0024PushFriendTeam_0024closure_00245126(_0024PushFriendTeam_0024locals_002414549 _0024_0024locals_002415222, UnionMain _0024this_002415223)
		{
			this._0024_0024locals_002415222 = _0024_0024locals_002415222;
			this._0024this_002415223 = _0024this_002415223;
		}

		public void Invoke(RequestBase r)
		{
			_0024this_002415223.OpenDialog(_0024_0024locals_002415222._0024msg, _0024this_002415223.DEFAULT_DIALOG_BODY, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415223.OPTION_OK);
		}
	}

	[Serializable]
	internal class _0024Request_0024closure_00245125
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002422064 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024Request_0024closure_00245125 _0024self__002422065;

				public _0024(_0024Request_0024closure_00245125 self_)
				{
					_0024self__002422065 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						MerlinServer.Request(_0024self__002422065._0024_0024locals_002415224._0024req);
						goto case 2;
					case 2:
						if (!_0024self__002422065._0024_0024locals_002415224._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002422065._0024_0024locals_002415224._0024req.IsOk || _0024self__002422065._0024_0024locals_002415224._0024req.ErrorIgnored)
						{
							_0024self__002422065._0024_0024locals_002415224._0024act(_0024self__002422065._0024_0024locals_002415224._0024req);
						}
						_0024self__002422065._0024this_002415225.calling = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024Request_0024closure_00245125 _0024self__002422066;

			public _0024Invoke_002422064(_0024Request_0024closure_00245125 self_)
			{
				_0024self__002422066 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002422066);
			}
		}

		internal _0024Request_0024locals_002414550 _0024_0024locals_002415224;

		internal UnionMain _0024this_002415225;

		public _0024Request_0024closure_00245125(_0024Request_0024locals_002414550 _0024_0024locals_002415224, UnionMain _0024this_002415225)
		{
			this._0024_0024locals_002415224 = _0024_0024locals_002415224;
			this._0024this_002415225 = _0024this_002415225;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002422064(this).GetEnumerator();
		}
	}

	private UNION_MAIN mode;

	private UNION_MAIN lastMode;

	public GameObject friendListItemPrefab;

	public FriendList unionMemberListUI;

	private GameObject mapetIconPrefab;

	private GameObject weaponIconPrefab;

	private DialogManager dlgMan;

	private string[] OPTION_YES_NO;

	private string[] OPTION_YES_CANCEL;

	private string[] OPTION_BACK;

	private string[] OPTION_OK;

	private string DEFAULT_DIALOG_BODY;

	private RespFriend currentFriend;

	private bool calling;

	private RespCycleGuildPlayerRanking PlayerRanking => UserData.Current.userRaidInfo.guildPlayerRanking;

	private RespCycleGuildPlayerRanking GuildRanking => UserData.Current.userRaidInfo.guildPlayerRanking;

	private RespParty Party => UserData.Current.userParty;

	public override void SceneStart()
	{
		OPTION_YES_NO = new string[2]
		{
			MTexts.Msg("exp_no"),
			MTexts.Msg("exp_yes")
		};
		OPTION_YES_CANCEL = new string[2]
		{
			MTexts.Msg("exp_cancel"),
			MTexts.Msg("exp_yes")
		};
		OPTION_BACK = new string[1] { MTexts.Msg("exp_back") };
		OPTION_OK = new string[1] { MTexts.Msg("exp_ok") };
		DEFAULT_DIALOG_BODY = MTexts.Msg("$U_DEFAULT_TITLE");
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/MapetIcon") as GameObject;
			weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/WeaponIcon") as GameObject;
			dlgMan = DialogManager.Instance;
			mode = (lastMode = UNION_MAIN.TopMenu);
			PrepareChange((int)mode);
			UISituation[] array = situations;
			ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
		});
	}

	public override void SceneUpdate()
	{
		if (mode != lastMode)
		{
			lastMode = mode;
			PrepareChange((int)mode);
			UISituation[] array = situations;
			ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
		}
	}

	public bool IsFriend(RespFriend friend)
	{
		UserData current = UserData.Current;
		return current.userFriendListData.find(friend.TSocialPlayerId) != null;
	}

	public bool ImLeader()
	{
		UserData current = UserData.Current;
		return GetTeamLeaderID() == current.userStatus.TSocialPlayerId;
	}

	public int GetTeamLeaderID()
	{
		UserData current = UserData.Current;
		return (Party == null) ? current.userStatus.TSocialPlayerId : Party.GetLeaderId();
	}

	public string GetUnionName()
	{
		object result;
		if (UserData.Current.userRaidInfo.raidBattle != null && UserData.Current.userRaidInfo.raidBattle.IsEnableRaid && !string.IsNullOrEmpty(UserData.Current.userRaidInfo.raidBattle.RoomName))
		{
			int num = int.Parse(UserData.Current.userRaidInfo.raidBattle.RoomName);
			result = UIBasicUtility.SafeFormat(MTexts.Msg("$U_UNION_NAME"), num);
		}
		else
		{
			result = "------";
		}
		return (string)result;
	}

	public void PushFriendApply()
	{
		if (CanRequest())
		{
			ApiFriendApply apiFriendApply = new ApiFriendApply();
			apiFriendApply.Id = currentFriend.TSocialPlayerId;
			__MessageBoard_PushFriendApply_0024callable146_0024950_17__ from = delegate
			{
				OpenDialog(UIBasicUtility.SafeFormat(MTexts.Msg("$U_UNION_FRIEND_REQUEST"), currentFriend.Name), DEFAULT_DIALOG_BODY, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
			};
			Request(apiFriendApply, _0024adaptor_0024__MessageBoard_PushFriendApply_0024callable146_0024950_17___0024Action_0024191.Adapt(from));
		}
	}

	public void PushFriendTeam()
	{
		_0024PushFriendTeam_0024locals_002414549 _0024PushFriendTeam_0024locals_0024 = new _0024PushFriendTeam_0024locals_002414549();
		if (CanRequest())
		{
			RequestBase requestBase = null;
			_0024PushFriendTeam_0024locals_0024._0024msg = null;
			ApiPartyInvite apiPartyInvite = new ApiPartyInvite();
			apiPartyInvite.IgnoreErrorCodes = ApiPartyInvite.DefIgnoreErrorCodes;
			apiPartyInvite.Id = currentFriend.TSocialPlayerId;
			requestBase = apiPartyInvite;
			_0024PushFriendTeam_0024locals_0024._0024msg = UIBasicUtility.SafeFormat(MTexts.Msg("$U_UNION_TEAM_INVITE"), currentFriend.Name);
			__MerlinServer_Request_0024callable86_0024160_56__ from = new _0024PushFriendTeam_0024closure_00245126(_0024PushFriendTeam_0024locals_0024, this).Invoke;
			Request(requestBase, _0024adaptor_0024__MerlinServer_Request_0024callable86_0024160_56___0024Action_0024189.Adapt(from));
		}
	}

	public void FocusFriend(GameObject obj)
	{
		UISituation[] array = situations;
		GameObject go = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
		RespFriend friend = obj.GetComponent<FriendListItem>().friend;
		GameObject go2 = FindObject(go, "Poppet");
		FindObject(go2, "TextPoppetName").GetComponent<UILabelBase>().text = friend.PoppetName;
		FindObject(go2, "TextPoppetLv").GetComponent<UILabelBase>().text = "lv" + friend.PoppetLevel;
		GameObject go3 = FindObject(go, "Weapon");
		FindObject(go3, "TextWeaponName").GetComponent<UILabelBase>().text = "マッチ棒";
		FindObject(go3, "TextWeaponLv").GetComponent<UILabelBase>().text = "lv1";
		GameObject go4 = FindObject(go, "UserInfo");
		FindObject(go4, "TextUserName").GetComponent<UILabelBase>().text = friend.Name;
		FindObject(go4, "TextTeam").GetComponent<UILabelBase>().text = "XXチーム";
		currentFriend = friend;
		if (IsFriend(friend))
		{
			ChangeInviteButtonState(l: false);
		}
		ChangeLeaveButtonState(ImLeader());
		MapetListItem component = FindObject(go2, "mapetIcon".ToLower()).GetComponent<MapetListItem>();
		RespPoppet friendPet = friend.GetFriendPet();
		component.enableIconSprite = true;
		GameObject go5 = component.SetMapet(friendPet);
		ExtensionsModule.FindChild(go5, "LevelText").GetComponent<UILabelBase>().text = "lv" + friendPet.Level;
		FindObject(go3, "weaponIcon".ToLower()).GetComponent<WeaponListItem>().SetWeapon(new RespWeapon(1));
	}

	public void Request(RequestBase req, Action<RequestBase> act)
	{
		_0024Request_0024locals_002414550 _0024Request_0024locals_0024 = new _0024Request_0024locals_002414550();
		_0024Request_0024locals_0024._0024req = req;
		_0024Request_0024locals_0024._0024act = act;
		if (calling)
		{
			throw new AssertionFailedException("calling == false");
		}
		calling = true;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024Request_0024closure_00245125(_0024Request_0024locals_0024, this).Invoke;
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	public bool CanRequest()
	{
		return !calling;
	}

	private void OpenDialog(string msg, string title, DialogManager.MB_FLAG flag, string[] btns)
	{
		dlgMan.OnButton(0);
		Dialog component = dlgMan.OpenDialog(msg, title, flag, btns).GetComponent<Dialog>();
	}

	private void PrepareChange(int mode)
	{
		UISituation[] array = situations;
		GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, mode)].gameObject;
		switch (mode)
		{
		case 0:
		{
			string text = ((GuildRanking == null) ? "------" : UIBasicUtility.SafeFormat("{0:#,0} ", GuildRanking.RankingPoint));
			string text2 = ((GuildRanking == null) ? "---" : UIBasicUtility.SafeFormat(MTexts.Msg("exp_rank") + " ", GuildRanking.Ranking));
			string text3 = ((PlayerRanking == null) ? "------" : UIBasicUtility.SafeFormat("{0:#,0} ", PlayerRanking.RankingPoint));
			string text4 = ((PlayerRanking == null) ? "---" : UIBasicUtility.SafeFormat(MTexts.Msg("exp_rank") + " ", PlayerRanking.Ranking));
			UpdateText(gameObject, "Union", "TextPointNum", text);
			UpdateText(gameObject, "User", "TextPointNum", text3);
			UpdateText(gameObject, "Union", "TextRankingNum", text2);
			UpdateText(gameObject, "User", "TextRankingNum", text4);
			UpdateText(gameObject, "Board", "TextTitle", GetUnionName());
			break;
		}
		case 1:
			ExtensionsModule.FindChild(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
			ExtensionsModule.FindChild(gameObject, "weaponIcon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
			unionMemberListUI.listItemPrefab = friendListItemPrefab;
			unionMemberListUI.decideTarget = this.gameObject;
			unionMemberListUI.SetMapetPrefab(mapetIconPrefab);
			unionMemberListUI.SetResponse(UserData.Current.userRaidInfo.guildPlayers, null);
			break;
		default:
			throw new MatchError(new StringBuilder("`mode` failed to match `").Append((object)mode).Append("`").ToString());
		}
	}

	public GameObject FindObject(GameObject go, string objName)
	{
		return ExtensionsModule.FindChild(go, objName);
	}

	public void UpdateText(GameObject situationRoot, string panelName, string labelName, string text)
	{
		GameObject go = ExtensionsModule.FindChild(situationRoot, panelName);
		ExtensionsModule.FindChild(go, labelName).GetComponent<UILabelBase>().text = text;
	}

	public void ChangeInviteButtonState(bool l)
	{
		ChangeInviteButtonState(l, null);
	}

	public void ChangeInviteButtonState(bool l, string text)
	{
		UISituation[] array = situations;
		GameObject situationRoot = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
		ButtonStateChange(situationRoot, "Team", new string[1] { "Button" }, l, text);
	}

	public void ChangeLeaveButtonState(bool l)
	{
		ChangeLeaveButtonState(l, null);
	}

	public void ChangeLeaveButtonState(bool l, string text)
	{
		UISituation[] array = situations;
		GameObject situationRoot = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
		ButtonStateChange(situationRoot, "Request", new string[1] { "Button" }, l, text);
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state)
	{
		ButtonStateChange(situationRoot, panelName, buttonNames, state, null);
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state, string text)
	{
		GameObject go = FindObject(situationRoot, panelName);
		Color color = ((!state) ? Color.grey : Color.white);
		int i = 0;
		for (int length = buttonNames.Length; i < length; i = checked(i + 1))
		{
			GameObject gameObject = FindObject(go, buttonNames[i]);
			GameObject gameObject2 = FindObject(gameObject, "Text");
			gameObject2.GetComponent<UIWidget>().color = color;
			if (text != null)
			{
				gameObject2.GetComponent<UILabelBase>().text = text;
			}
			UIButtonMessage component = gameObject.GetComponent<UIButtonMessage>();
			component.merlinPuwaEnable = state;
			component.sendMessage = state;
			FindObject(gameObject, "bg").GetComponent<UIWidget>().color = color;
		}
	}

	public void PushMemberList()
	{
		mode = UNION_MAIN.MemberList;
	}

	public void PushBack()
	{
		if (mode == UNION_MAIN.TopMenu)
		{
			SceneChanger.ChangeTo(SceneChanger.LastScene);
		}
		else
		{
			mode = UNION_MAIN.TopMenu;
		}
	}

	internal void _0024SceneStart_0024closure_00245123()
	{
		mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/MapetIcon") as GameObject;
		weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/WeaponIcon") as GameObject;
		dlgMan = DialogManager.Instance;
		mode = (lastMode = UNION_MAIN.TopMenu);
		PrepareChange((int)mode);
		UISituation[] array = situations;
		ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
	}

	internal void _0024PushFriendApply_0024closure_00245124(ApiFriendApply r)
	{
		OpenDialog(UIBasicUtility.SafeFormat(MTexts.Msg("$U_UNION_FRIEND_REQUEST"), currentFriend.Name), DEFAULT_DIALOG_BODY, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
	}
}
