using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class MessageBoard : TownShopTopMain
{
	[Serializable]
	public enum START_MODE
	{
		top = 0,
		union = 9
	}

	[Serializable]
	public enum BBS_MODE
	{
		top,
		friend,
		friendlist,
		friendrequest,
		team,
		teammember,
		teammemberrequest,
		teamsearch,
		snsmenu,
		union,
		union_member,
		rankingunion,
		rankinguser,
		friendsearch,
		friendDetail,
		waitInit
	}

	[Serializable]
	internal class _0024PrepareChange_0024locals_002414503
	{
		internal UserData _0024ud;
	}

	[Serializable]
	internal class _0024PushFriendTeam_0024locals_002414504
	{
		internal string _0024msg;

		internal string _0024title;
	}

	[Serializable]
	internal class _0024PushTeamReject_0024locals_002414505
	{
		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024waitCb;
	}

	[Serializable]
	internal class _0024PushTeamAgree_0024locals_002414506
	{
		internal int _0024requestType;

		internal int _0024id;

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024waitCb;
	}

	[Serializable]
	internal class _0024PushFriendLeave_0024locals_002414507
	{
		internal string _0024body;

		internal ApiFriendRemove _0024req;
	}

	[Serializable]
	internal class _0024PushFriendAgree_0024locals_002414508
	{
		internal ApiFriendAccept _0024req;
	}

	[Serializable]
	internal class _0024PushFriendReject_0024locals_002414509
	{
		internal string _0024body;

		internal ApiFriendReject _0024req;
	}

	[Serializable]
	internal class _0024PushTeamLeave_0024locals_002414510
	{
		internal string _0024body;
	}

	[Serializable]
	internal class _0024PushTeamLeaveMenber_0024locals_002414511
	{
		internal string _0024body;

		internal ApiPartyMemberKick _0024req;
	}

	[Serializable]
	internal class _0024FocusFriend_0024locals_002414512
	{
		internal UserData _0024ud;

		internal RespWeapon _0024friendWeapon;

		internal RespWeapon _0024friendWeaponDemon;

		internal RespPoppet _0024friendMapet;

		internal GameObject _0024poppetGo;

		internal GameObject _0024weaponGo;

		internal GameObject _0024weaponGoDemon;
	}

	[Serializable]
	internal class _0024WaitAnswerRequest_0024locals_002414513
	{
		internal RequestBase _0024ereq;

		internal Action<RequestBase> _0024act;
	}

	[Serializable]
	internal class _0024WaitAnswer_0024locals_002414514
	{
		internal Action _0024act;
	}

	[Serializable]
	internal class _0024Request_0024locals_002414515
	{
		internal RequestBase _0024req;

		internal Action<RequestBase> _0024act;
	}

	[Serializable]
	internal class _0024RequestTeamNotify_0024locals_002414516
	{
		internal System.Collections.Generic.List<UserTeamNotifyData.TeamNotifyDataDetail> _0024leavers;

		internal System.Collections.Generic.List<UserTeamNotifyData.TeamNotifyDataDetail> _0024newfaces;

		internal UserTeamNotifyData.TeamNotifyDataDetail _0024oldLeader;

		internal bool _0024exit;

		internal Action<string, string> _0024openNotify;

		internal __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024runNotify;
	}

	[Serializable]
	internal class _0024_0024PushTeamReject_0024Reject_00243190_0024locals_002414517
	{
		internal ApiPartyReject _0024req;

		internal string _0024msg;

		internal string _0024title;
	}

	[Serializable]
	internal class _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_002414518
	{
		internal ApiPartyLeaderChangeReject _0024req;

		internal string _0024msg;

		internal string _0024title;
	}

	[Serializable]
	internal class _0024_0024PushTeamAgree_0024Accept_00243195_0024locals_002414519
	{
		internal string _0024msg;

		internal string _0024title;
	}

	[Serializable]
	internal class _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_002414520
	{
		internal string _0024msg;

		internal string _0024title;
	}

	[Serializable]
	internal class _0024PrepareChange_0024WaitSituation_00243182
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421711 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024PrepareChange_0024WaitSituation_00243182 _0024self__002421712;

				public _0024(_0024PrepareChange_0024WaitSituation_00243182 self_)
				{
					_0024self__002421712 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
					case 3:
						if (_0024self__002421712._0024this_002415110.IsChangingSituation)
						{
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						_0024self__002421712._0024this_002415110.RequestTeamNotify(_0024self__002421712._0024_0024locals_002415109._0024ud.userMiscInfo.teamNotifyData);
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024PrepareChange_0024WaitSituation_00243182 _0024self__002421713;

			public _0024Invoke_002421711(_0024PrepareChange_0024WaitSituation_00243182 self_)
			{
				_0024self__002421713 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421713);
			}
		}

		internal _0024PrepareChange_0024locals_002414503 _0024_0024locals_002415109;

		internal MessageBoard _0024this_002415110;

		public _0024PrepareChange_0024WaitSituation_00243182(_0024PrepareChange_0024locals_002414503 _0024_0024locals_002415109, MessageBoard _0024this_002415110)
		{
			this._0024_0024locals_002415109 = _0024_0024locals_002415109;
			this._0024this_002415110 = _0024this_002415110;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421711(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024PushFriendTeam_0024f_00243188
	{
		internal _0024PushFriendTeam_0024locals_002414504 _0024_0024locals_002415111;

		internal MessageBoard _0024this_002415112;

		public _0024PushFriendTeam_0024f_00243188(_0024PushFriendTeam_0024locals_002414504 _0024_0024locals_002415111, MessageBoard _0024this_002415112)
		{
			this._0024_0024locals_002415111 = _0024_0024locals_002415111;
			this._0024this_002415112 = _0024this_002415112;
		}

		public void Invoke(RequestBase r)
		{
			_0024this_002415112.OpenDialog(_0024_0024locals_002415111._0024msg, _0024_0024locals_002415111._0024title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415112.OPTION_OK);
		}
	}

	[Serializable]
	internal class _0024_0024PushTeamReject_0024Reject_00243190_0024f_00243191
	{
		internal MessageBoard _0024this_002415113;

		internal _0024_0024PushTeamReject_0024Reject_00243190_0024locals_002414517 _0024_0024locals_002415114;

		internal _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415115;

		public _0024_0024PushTeamReject_0024Reject_00243190_0024f_00243191(MessageBoard _0024this_002415113, _0024_0024PushTeamReject_0024Reject_00243190_0024locals_002414517 _0024_0024locals_002415114, _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415115)
		{
			this._0024this_002415113 = _0024this_002415113;
			this._0024_0024locals_002415114 = _0024_0024locals_002415114;
			this._0024_0024locals_002415115 = _0024_0024locals_002415115;
		}

		public void Invoke(ApiPartyReject r)
		{
			_0024this_002415113.OpenDialog(_0024_0024locals_002415114._0024msg, _0024_0024locals_002415114._0024title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415113.OPTION_OK);
			_0024this_002415113.PartyApplies = r.GetResponse().Applies;
			_0024this_002415113.AlreadyReadData.RemovePartyApplies(_0024_0024locals_002415114._0024req.Id);
			_0024this_002415113.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(_0024_0024locals_002415115._0024waitCb));
		}
	}

	[Serializable]
	internal class _0024PushTeamReject_0024Reject_00243190
	{
		internal MessageBoard _0024this_002415116;

		internal _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415117;

		public _0024PushTeamReject_0024Reject_00243190(MessageBoard _0024this_002415116, _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415117)
		{
			this._0024this_002415116 = _0024this_002415116;
			this._0024_0024locals_002415117 = _0024_0024locals_002415117;
		}

		public void Invoke(string msg, string title)
		{
			_0024_0024PushTeamReject_0024Reject_00243190_0024locals_002414517 _0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024 = new _0024_0024PushTeamReject_0024Reject_00243190_0024locals_002414517();
			_0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024._0024msg = msg;
			_0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024._0024title = title;
			_0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024._0024req = new ApiPartyReject();
			_0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024._0024req.Id = (_0024this_002415116.currentFriend as RespApplyInfo).ApplyId;
			__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17__ from = new _0024_0024PushTeamReject_0024Reject_00243190_0024f_00243191(_0024this_002415116, _0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024, _0024_0024locals_002415117).Invoke;
			_0024this_002415116.Request(_0024_0024PushTeamReject_0024Reject_00243190_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17___0024Action_0024200.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024_0024PushTeamReject_0024RejectLeader_00243192_0024f_00243193
	{
		internal MessageBoard _0024this_002415118;

		internal _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_002414518 _0024_0024locals_002415119;

		internal _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415120;

		public _0024_0024PushTeamReject_0024RejectLeader_00243192_0024f_00243193(MessageBoard _0024this_002415118, _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_002414518 _0024_0024locals_002415119, _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415120)
		{
			this._0024this_002415118 = _0024this_002415118;
			this._0024_0024locals_002415119 = _0024_0024locals_002415119;
			this._0024_0024locals_002415120 = _0024_0024locals_002415120;
		}

		public void Invoke(ApiPartyLeaderChangeReject r)
		{
			_0024this_002415118.OpenDialog(_0024_0024locals_002415119._0024msg, _0024_0024locals_002415119._0024title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415118.OPTION_OK);
			_0024this_002415118.PartyApplies = r.GetResponse().Applies;
			_0024this_002415118.AlreadyReadData.RemovePartyApplies(_0024_0024locals_002415119._0024req.Id);
			_0024this_002415118.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(_0024_0024locals_002415120._0024waitCb));
		}
	}

	[Serializable]
	internal class _0024PushTeamReject_0024RejectLeader_00243192
	{
		internal MessageBoard _0024this_002415121;

		internal _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415122;

		public _0024PushTeamReject_0024RejectLeader_00243192(MessageBoard _0024this_002415121, _0024PushTeamReject_0024locals_002414505 _0024_0024locals_002415122)
		{
			this._0024this_002415121 = _0024this_002415121;
			this._0024_0024locals_002415122 = _0024_0024locals_002415122;
		}

		public void Invoke(string msg, string title)
		{
			_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_002414518 _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024 = new _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_002414518();
			_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024._0024msg = msg;
			_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024._0024title = title;
			_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024._0024req = new ApiPartyLeaderChangeReject();
			_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024._0024req.Id = (_0024this_002415121.currentFriend as RespApplyInfo).ApplyId;
			__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17__ from = new _0024_0024PushTeamReject_0024RejectLeader_00243192_0024f_00243193(_0024this_002415121, _0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024, _0024_0024locals_002415122).Invoke;
			_0024this_002415121.Request(_0024_0024PushTeamReject_0024RejectLeader_00243192_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17___0024Action_0024201.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024PushTeamAgree_0024waitCb_00243194
	{
		internal MessageBoard _0024this_002415123;

		internal _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415124;

		public _0024PushTeamAgree_0024waitCb_00243194(MessageBoard _0024this_002415123, _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415124)
		{
			this._0024this_002415123 = _0024this_002415123;
			this._0024_0024locals_002415124 = _0024_0024locals_002415124;
		}

		public void Invoke()
		{
			_0024this_002415123.teamRequestListUI.RemoveCurrentEntry();
			_0024this_002415123.RefreshMemberNum();
			if (_0024_0024locals_002415124._0024requestType == 2 || _0024_0024locals_002415124._0024requestType == 5 || _0024this_002415123.teamRequestListUI.Empty())
			{
				_0024this_002415123.PushBack();
			}
		}
	}

	[Serializable]
	internal class _0024_0024PushTeamAgree_0024Accept_00243195_0024f_00243196
	{
		internal _0024_0024PushTeamAgree_0024Accept_00243195_0024locals_002414519 _0024_0024locals_002415125;

		internal MessageBoard _0024this_002415126;

		internal _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415127;

		public _0024_0024PushTeamAgree_0024Accept_00243195_0024f_00243196(_0024_0024PushTeamAgree_0024Accept_00243195_0024locals_002414519 _0024_0024locals_002415125, MessageBoard _0024this_002415126, _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415127)
		{
			this._0024_0024locals_002415125 = _0024_0024locals_002415125;
			this._0024this_002415126 = _0024this_002415126;
			this._0024_0024locals_002415127 = _0024_0024locals_002415127;
		}

		public void Invoke(ApiPartyAccept r)
		{
			_0024this_002415126.OpenDialog(_0024_0024locals_002415125._0024msg, _0024_0024locals_002415125._0024title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415126.OPTION_OK);
			_0024this_002415126.PartyApplies = r.GetResponse().Applies;
			_0024this_002415126.PartyMembers = r.GetResponse().Members;
			_0024this_002415126.AlreadyReadData.RemovePartyApplies(_0024_0024locals_002415127._0024id);
			_0024this_002415126.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(_0024_0024locals_002415127._0024waitCb));
		}
	}

	[Serializable]
	internal class _0024PushTeamAgree_0024Accept_00243195
	{
		internal MessageBoard _0024this_002415128;

		internal _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415129;

		public _0024PushTeamAgree_0024Accept_00243195(MessageBoard _0024this_002415128, _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415129)
		{
			this._0024this_002415128 = _0024this_002415128;
			this._0024_0024locals_002415129 = _0024_0024locals_002415129;
		}

		public void Invoke(string msg, string title)
		{
			_0024_0024PushTeamAgree_0024Accept_00243195_0024locals_002414519 _0024_0024PushTeamAgree_0024Accept_00243195_0024locals_0024 = new _0024_0024PushTeamAgree_0024Accept_00243195_0024locals_002414519();
			_0024_0024PushTeamAgree_0024Accept_00243195_0024locals_0024._0024msg = msg;
			_0024_0024PushTeamAgree_0024Accept_00243195_0024locals_0024._0024title = title;
			ApiPartyAccept apiPartyAccept = new ApiPartyAccept();
			apiPartyAccept.Id = _0024_0024locals_002415129._0024id;
			__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17__ from = new _0024_0024PushTeamAgree_0024Accept_00243195_0024f_00243196(_0024_0024PushTeamAgree_0024Accept_00243195_0024locals_0024, _0024this_002415128, _0024_0024locals_002415129).Invoke;
			_0024this_002415128.Request(apiPartyAccept, _0024adaptor_0024__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17___0024Action_0024202.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024f_00243198
	{
		internal MessageBoard _0024this_002415130;

		internal _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_002414520 _0024_0024locals_002415131;

		internal _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415132;

		public _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024f_00243198(MessageBoard _0024this_002415130, _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_002414520 _0024_0024locals_002415131, _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415132)
		{
			this._0024this_002415130 = _0024this_002415130;
			this._0024_0024locals_002415131 = _0024_0024locals_002415131;
			this._0024_0024locals_002415132 = _0024_0024locals_002415132;
		}

		public void Invoke(ApiPartyLeaderChangeAccept r)
		{
			_0024this_002415130.OpenDialog(_0024_0024locals_002415131._0024msg, _0024_0024locals_002415131._0024title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415130.OPTION_OK);
			_0024this_002415130.PartyApplies = r.GetResponse().Applies;
			_0024this_002415130.PartyMembers = r.GetResponse().Members;
			_0024this_002415130.AlreadyReadData.RemovePartyApplies(_0024_0024locals_002415132._0024id);
			_0024this_002415130.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(_0024_0024locals_002415132._0024waitCb));
		}
	}

	[Serializable]
	internal class _0024PushTeamAgree_0024AcceptLeader_00243197
	{
		internal MessageBoard _0024this_002415133;

		internal _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415134;

		public _0024PushTeamAgree_0024AcceptLeader_00243197(MessageBoard _0024this_002415133, _0024PushTeamAgree_0024locals_002414506 _0024_0024locals_002415134)
		{
			this._0024this_002415133 = _0024this_002415133;
			this._0024_0024locals_002415134 = _0024_0024locals_002415134;
		}

		public void Invoke(string msg, string title)
		{
			_0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_002414520 _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_0024 = new _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_002414520();
			_0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_0024._0024msg = msg;
			_0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_0024._0024title = title;
			ApiPartyLeaderChangeAccept apiPartyLeaderChangeAccept = new ApiPartyLeaderChangeAccept();
			apiPartyLeaderChangeAccept.Id = _0024_0024locals_002415134._0024id;
			__MessageBoard__0024PushTeamAgree_0024AcceptLeader_00243197_0024callable144_0024872_17__ from = new _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024f_00243198(_0024this_002415133, _0024_0024PushTeamAgree_0024AcceptLeader_00243197_0024locals_0024, _0024_0024locals_002415134).Invoke;
			_0024this_002415133.Request(apiPartyLeaderChangeAccept, _0024adaptor_0024__MessageBoard__0024PushTeamAgree_0024AcceptLeader_00243197_0024callable144_0024872_17___0024Action_0024203.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024PushFriendLeave_0024callback_00243202
	{
		internal _0024PushFriendLeave_0024locals_002414507 _0024_0024locals_002415135;

		internal MessageBoard _0024this_002415136;

		public _0024PushFriendLeave_0024callback_00243202(_0024PushFriendLeave_0024locals_002414507 _0024_0024locals_002415135, MessageBoard _0024this_002415136)
		{
			this._0024_0024locals_002415135 = _0024_0024locals_002415135;
			this._0024this_002415136 = _0024this_002415136;
		}

		public void Invoke(ApiFriendRemove r)
		{
			_0024this_002415136.title = _0024this_002415136.GetText("d-mboard-friendremove-title");
			_0024_0024locals_002415135._0024body = _0024this_002415136.GetText("d-mboard-friendremove-body", _0024this_002415136.currentFriend.Name);
			_0024this_002415136.OpenDialog(_0024_0024locals_002415135._0024body, _0024this_002415136.title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415136.OPTION_OK);
			_0024this_002415136.Friends = r.GetResponse().Friends;
			_0024this_002415136.AlreadyReadData.RemoveFriends(_0024_0024locals_002415135._0024req.Id);
			_0024this_002415136.friendListUI.RemoveCurrentEntry();
			_0024this_002415136.RefreshMemberNum();
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from = delegate
			{
				if (_0024this_002415136.friendListUI.Empty())
				{
					_0024this_002415136.PushBack();
				}
			};
			_0024this_002415136.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024PushFriendAgree_0024f_00243204
	{
		internal MessageBoard _0024this_002415137;

		internal _0024PushFriendAgree_0024locals_002414508 _0024_0024locals_002415138;

		public _0024PushFriendAgree_0024f_00243204(MessageBoard _0024this_002415137, _0024PushFriendAgree_0024locals_002414508 _0024_0024locals_002415138)
		{
			this._0024this_002415137 = _0024this_002415137;
			this._0024_0024locals_002415138 = _0024_0024locals_002415138;
		}

		public void Invoke(ApiFriendAccept r)
		{
			_0024this_002415137.title = _0024this_002415137.GetText("d-mboard-friendreapply-accept-title");
			string text = _0024this_002415137.GetText("d-mboard-friendreapply-accept-body");
			_0024this_002415137.OpenDialog(text, _0024this_002415137.title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415137.OPTION_OK);
			_0024this_002415137.FriendApplies = r.GetResponse().Applies;
			_0024this_002415137.Friends = r.GetResponse().Friends;
			_0024this_002415137.AlreadyReadData.RemoveFriendApplies(_0024_0024locals_002415138._0024req.Id);
			_0024this_002415137.friendRequestListUI.RemoveCurrentEntry();
			_0024this_002415137.RefreshMemberNum();
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from = delegate
			{
				if (_0024this_002415137.friendRequestListUI.Empty())
				{
					_0024this_002415137.PushBack();
				}
			};
			_0024this_002415137.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024PushFriendReject_0024callback_00243206
	{
		internal MessageBoard _0024this_002415139;

		internal _0024PushFriendReject_0024locals_002414509 _0024_0024locals_002415140;

		public _0024PushFriendReject_0024callback_00243206(MessageBoard _0024this_002415139, _0024PushFriendReject_0024locals_002414509 _0024_0024locals_002415140)
		{
			this._0024this_002415139 = _0024this_002415139;
			this._0024_0024locals_002415140 = _0024_0024locals_002415140;
		}

		public void Invoke(ApiFriendReject r)
		{
			_0024_0024locals_002415140._0024body = _0024this_002415139.GetText("d-mboard-friendreapply-reject-body");
			_0024this_002415139.title = _0024this_002415139.GetText("d-mboard-friendreapply-reject-title");
			_0024this_002415139.OpenDialog(_0024_0024locals_002415140._0024body, _0024this_002415139.title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415139.OPTION_OK);
			_0024this_002415139.FriendApplies = r.GetResponse().Applies;
			_0024this_002415139.AlreadyReadData.RemoveFriendApplies(_0024_0024locals_002415140._0024req.Id);
			_0024this_002415139.friendRequestListUI.RemoveCurrentEntry();
			_0024this_002415139.RefreshMemberNum();
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from = delegate
			{
				if (_0024this_002415139.friendRequestListUI.Empty())
				{
					_0024this_002415139.PushBack();
				}
			};
			_0024this_002415139.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024PushTeamLeave_0024callback_00243208
	{
		internal _0024PushTeamLeave_0024locals_002414510 _0024_0024locals_002415141;

		internal MessageBoard _0024this_002415142;

		public _0024PushTeamLeave_0024callback_00243208(_0024PushTeamLeave_0024locals_002414510 _0024_0024locals_002415141, MessageBoard _0024this_002415142)
		{
			this._0024_0024locals_002415141 = _0024_0024locals_002415141;
			this._0024this_002415142 = _0024this_002415142;
		}

		public void Invoke(ApiPartyRemove x)
		{
			_0024_0024locals_002415141._0024body = _0024this_002415142.GetText("d-mboard-teamremove-body");
			_0024this_002415142.title = _0024this_002415142.GetText("d-mboard-teamremove-title");
			_0024this_002415142.OpenDialog(_0024_0024locals_002415141._0024body, _0024this_002415142.title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415142.OPTION_OK);
			_0024this_002415142.homeData.PartyMember = RespParty.MakeSoloParty(_0024this_002415142.GetMySocialID(), _0024this_002415142.homeData.PartyMember);
			UserData current = UserData.Current;
			current.userMiscInfo.teamNotifyData.Leave(_0024this_002415142.GetMySocialID(), _0024this_002415142.Party);
			_0024this_002415142.PrepareChange(4);
		}
	}

	[Serializable]
	internal class _0024PushTeamLeaveMenber_0024callback_00243209
	{
		internal MessageBoard _0024this_002415143;

		internal _0024PushTeamLeaveMenber_0024locals_002414511 _0024_0024locals_002415144;

		public _0024PushTeamLeaveMenber_0024callback_00243209(MessageBoard _0024this_002415143, _0024PushTeamLeaveMenber_0024locals_002414511 _0024_0024locals_002415144)
		{
			this._0024this_002415143 = _0024this_002415143;
			this._0024_0024locals_002415144 = _0024_0024locals_002415144;
		}

		public void Invoke(ApiPartyMemberKick x)
		{
			_0024_0024locals_002415144._0024body = _0024this_002415143.GetText("d-mboard-teamkick-body", _0024this_002415143.currentFriend.Name);
			_0024this_002415143.title = _0024this_002415143.GetText("d-mboard-teamkick-title");
			_0024this_002415143.OpenDialog(_0024_0024locals_002415144._0024body, _0024this_002415143.title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415143.OPTION_OK);
			_0024this_002415143.PartyMembers = x.GetResponse().Members;
			_0024this_002415143.AlreadyReadData.RemoveMembers(_0024_0024locals_002415144._0024req.Id);
			_0024this_002415143.teamMemberListUI.RemoveCurrentEntry();
			_0024this_002415143.RefreshMemberNum();
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from = delegate
			{
				if (_0024this_002415143.teamMemberListUI.Empty())
				{
					_0024this_002415143.PushBack();
				}
			};
			_0024this_002415143.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(from));
		}
	}

	[Serializable]
	internal class _0024FocusFriend_0024SetSideMapetIcon_00243184
	{
		internal _0024FocusFriend_0024locals_002414512 _0024_0024locals_002415145;

		internal MessageBoard _0024this_002415146;

		public _0024FocusFriend_0024SetSideMapetIcon_00243184(_0024FocusFriend_0024locals_002414512 _0024_0024locals_002415145, MessageBoard _0024this_002415146)
		{
			this._0024_0024locals_002415145 = _0024_0024locals_002415145;
			this._0024this_002415146 = _0024this_002415146;
		}

		public void Invoke()
		{
			GameObject gameObject = _0024this_002415146.FindObject(_0024_0024locals_002415145._0024poppetGo, "mapetIcon".ToLower());
			if (!(gameObject == null))
			{
				if (_0024this_002415146.friendMapetSideIcon == null)
				{
					_0024this_002415146.friendMapetSideIcon = (GameObject)UnityEngine.Object.Instantiate(_0024this_002415146.mapetSideIconPrefab);
				}
				_0024this_002415146.friendMapetSideIcon.transform.parent = gameObject.transform;
				_0024this_002415146.friendMapetSideIcon.transform.localScale = Vector3.one;
				_0024this_002415146.friendMapetSideIcon.transform.localPosition = Vector3.zero;
				UIButtonMessage component = _0024this_002415146.friendMapetSideIcon.GetComponent<UIButtonMessage>();
				component.target = _0024this_002415146.gameObject;
				component.functionName = "DecideFriend";
				MapetListItem component2 = _0024this_002415146.friendMapetSideIcon.GetComponent<MapetListItem>();
				_0024_0024locals_002415145._0024ud.userMiscInfo.poppetBookData.look(_0024_0024locals_002415145._0024friendMapet.Master);
				component2.enableIconSprite = true;
				component2.enableLevelLabel = false;
				component2.enableCharLevelLabel = false;
				GameObject gameObject2 = component2.SetMapet(_0024_0024locals_002415145._0024friendMapet);
				component2.DestroyLevel();
			}
		}
	}

	[Serializable]
	internal class _0024FocusFriend_0024SetSideWeaponIcon_00243185
	{
		internal MessageBoard _0024this_002415147;

		internal _0024FocusFriend_0024locals_002414512 _0024_0024locals_002415148;

		public _0024FocusFriend_0024SetSideWeaponIcon_00243185(MessageBoard _0024this_002415147, _0024FocusFriend_0024locals_002414512 _0024_0024locals_002415148)
		{
			this._0024this_002415147 = _0024this_002415147;
			this._0024_0024locals_002415148 = _0024_0024locals_002415148;
		}

		public void Invoke()
		{
			GameObject aParent = _0024this_002415147.FindObject(_0024_0024locals_002415148._0024weaponGo, "weaponIconAngel");
			_0024this_002415147._setSideWeaponIcon(_0024_0024locals_002415148._0024friendWeapon, aParent, ref _0024this_002415147.friendWeaponSideIcon, "DecideWeapon");
			GameObject aParent2 = _0024this_002415147.FindObject(_0024_0024locals_002415148._0024weaponGoDemon, "weaponIconDemon");
			_0024this_002415147._setSideWeaponIcon(_0024_0024locals_002415148._0024friendWeaponDemon, aParent2, ref _0024this_002415147.friendWeaponSideIconDemon, "DecideWeaponDemon");
		}
	}

	[Serializable]
	internal class _0024WaitAnswerRequest_0024closure_00243213
	{
		internal MessageBoard _0024this_002415149;

		internal _0024WaitAnswerRequest_0024locals_002414513 _0024_0024locals_002415150;

		public _0024WaitAnswerRequest_0024closure_00243213(MessageBoard _0024this_002415149, _0024WaitAnswerRequest_0024locals_002414513 _0024_0024locals_002415150)
		{
			this._0024this_002415149 = _0024this_002415149;
			this._0024_0024locals_002415150 = _0024_0024locals_002415150;
		}

		public void Invoke(int btn)
		{
			if (btn == 2)
			{
				_0024this_002415149.Request(_0024_0024locals_002415150._0024ereq, _0024_0024locals_002415150._0024act);
			}
		}
	}

	[Serializable]
	internal class _0024WaitAnswer_0024closure_00243214
	{
		internal _0024WaitAnswer_0024locals_002414514 _0024_0024locals_002415151;

		public _0024WaitAnswer_0024closure_00243214(_0024WaitAnswer_0024locals_002414514 _0024_0024locals_002415151)
		{
			this._0024_0024locals_002415151 = _0024_0024locals_002415151;
		}

		public void Invoke(int btn)
		{
			_0024_0024locals_002415151._0024act();
		}
	}

	[Serializable]
	internal class _0024Request_0024closure_00243187
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421714 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024Request_0024closure_00243187 _0024self__002421715;

				public _0024(_0024Request_0024closure_00243187 self_)
				{
					_0024self__002421715 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024self__002421715._0024this_002415152.SetErrorHandler(_0024self__002421715._0024_0024locals_002415153._0024req);
						MerlinServer.Request(_0024self__002421715._0024_0024locals_002415153._0024req);
						goto case 2;
					case 2:
						if (!_0024self__002421715._0024_0024locals_002415153._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (_0024self__002421715._0024_0024locals_002415153._0024req.IsOk || _0024self__002421715._0024_0024locals_002415153._0024req.ErrorIgnored)
						{
							_0024self__002421715._0024_0024locals_002415153._0024act(_0024self__002421715._0024_0024locals_002415153._0024req);
						}
						_0024self__002421715._0024this_002415152.calling = false;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal _0024Request_0024closure_00243187 _0024self__002421716;

			public _0024Invoke_002421714(_0024Request_0024closure_00243187 self_)
			{
				_0024self__002421716 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421716);
			}
		}

		internal MessageBoard _0024this_002415152;

		internal _0024Request_0024locals_002414515 _0024_0024locals_002415153;

		public _0024Request_0024closure_00243187(MessageBoard _0024this_002415152, _0024Request_0024locals_002414515 _0024_0024locals_002415153)
		{
			this._0024this_002415152 = _0024this_002415152;
			this._0024_0024locals_002415153 = _0024_0024locals_002415153;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421714(this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024RequestTeamNotify_0024runNotify_00243215
	{
		internal _0024RequestTeamNotify_0024locals_002414516 _0024_0024locals_002415154;

		internal MessageBoard _0024this_002415155;

		public _0024RequestTeamNotify_0024runNotify_00243215(_0024RequestTeamNotify_0024locals_002414516 _0024_0024locals_002415154, MessageBoard _0024this_002415155)
		{
			this._0024_0024locals_002415154 = _0024_0024locals_002415154;
			this._0024this_002415155 = _0024this_002415155;
		}

		public void Invoke()
		{
			if (0 < _0024_0024locals_002415154._0024leavers.Count)
			{
				string text = _0024this_002415155.GetText("d-mboard-team-remove-notify-body", _0024_0024locals_002415154._0024leavers[0].Name);
				_0024this_002415155.title = _0024this_002415155.GetText("d-mboard-team-remove-notify-title");
				_0024_0024locals_002415154._0024openNotify(text, _0024this_002415155.title);
				_0024_0024locals_002415154._0024leavers.RemoveAt(0);
			}
			else if (0 < _0024_0024locals_002415154._0024newfaces.Count && _0024_0024locals_002415154._0024newfaces[0].Id != _0024this_002415155.GetMySocialID())
			{
				string text = _0024this_002415155.GetText("d-mboard-team-join-notify-body", _0024_0024locals_002415154._0024newfaces[0].Name);
				_0024this_002415155.title = _0024this_002415155.GetText("d-mboard-team-join-notify-title");
				_0024_0024locals_002415154._0024openNotify(text, _0024this_002415155.title);
				_0024_0024locals_002415154._0024newfaces.RemoveAt(0);
			}
			else if (!_0024_0024locals_002415154._0024exit && _0024_0024locals_002415154._0024oldLeader != null && _0024this_002415155.GetTeamLeaderID() != _0024_0024locals_002415154._0024oldLeader.Id)
			{
				_0024_0024locals_002415154._0024exit = true;
				string text = _0024this_002415155.GetText("d-mboard-team-leader-notify-body", _0024this_002415155.Party.GetLeader().Name);
				_0024this_002415155.title = _0024this_002415155.GetText("d-mboard-team-leader-notify-title");
				_0024_0024locals_002415154._0024openNotify(text, _0024this_002415155.title);
			}
		}
	}

	[Serializable]
	internal class _0024RequestTeamNotify_0024closure_00243216
	{
		internal MessageBoard _0024this_002415156;

		internal _0024RequestTeamNotify_0024locals_002414516 _0024_0024locals_002415157;

		public _0024RequestTeamNotify_0024closure_00243216(MessageBoard _0024this_002415156, _0024RequestTeamNotify_0024locals_002414516 _0024_0024locals_002415157)
		{
			this._0024this_002415156 = _0024this_002415156;
			this._0024_0024locals_002415157 = _0024_0024locals_002415157;
		}

		public void Invoke(string msg, string title)
		{
			_0024this_002415156.OpenDialog(msg, title, DialogManager.MB_FLAG.MB_ICONHAND, _0024this_002415156.OPTION_OK);
			_0024this_002415156.WaitAnswer(_0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024Action_0024199.Adapt(_0024_0024locals_002415157._0024runNotify));
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowWebHtmlCore_002421702 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RequestBase _0024req_002421703;

			internal MessageBoard _0024self__002421704;

			public _0024(RequestBase req, MessageBoard self_)
			{
				_0024req_002421703 = req;
				_0024self__002421704 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421704.SetErrorHandler(_0024req_002421703);
					MerlinServer.Request(_0024req_002421703);
					if (_0024self__002421704.curWebView == null)
					{
						MessageBoard messageBoard = _0024self__002421704;
						UISituation[] situations = _0024self__002421704.situations;
						messageBoard.curWebView = situations[RuntimeServices.NormalizeArrayIndex(situations, (int)_0024self__002421704.mode)].gameObject.GetComponentsInChildren<WebView>(includeInactive: true).FirstOrDefault();
						if (!(_0024self__002421704.curWebView != null))
						{
							throw new AssertionFailedException("curWebView != null");
						}
					}
					_0024self__002421704.curWebView.Clear();
					goto case 2;
				case 2:
					if (!_0024req_002421703.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024req_002421703.IsOk)
					{
						goto case 1;
					}
					result = (YieldDefault(3) ? 1 : 0);
					break;
				case 3:
					_0024self__002421704.curWebView.OpenHtml(_0024req_002421703.Result, ServerURL.GameServerUrl("/"));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RequestBase _0024req_002421705;

		internal MessageBoard _0024self__002421706;

		public _0024ShowWebHtmlCore_002421702(RequestBase req, MessageBoard self_)
		{
			_0024req_002421705 = req;
			_0024self__002421706 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024req_002421705, _0024self__002421706);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024StartCore_0024closure_00243181_002421707 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiHomeSlim _0024req_002421708;

			internal MessageBoard _0024self__002421709;

			public _0024(MessageBoard self_)
			{
				_0024self__002421709 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002421708 = new ApiHomeSlim();
					MerlinServer.Request(_0024req_002421708);
					goto case 2;
				case 2:
					if (!_0024req_002421708.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024req_002421708.IsOk)
					{
						_0024self__002421709.mode = BBS_MODE.top;
						if (startMode == START_MODE.union)
						{
							_0024self__002421709.mode = BBS_MODE.union;
						}
						SceneChanger.ScenePreChangeEvent += _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(_0024self__002421709.OnScenePreChange);
						_0024self__002421709.homeData = _0024req_002421708.GetResponse();
						UserData.Current.userMiscInfo.flagData.updateCondition();
						BattleHUDShortcut.ClearShortcutIcon(destroy: true);
						_0024self__002421709.PrepareChange((int)_0024self__002421709.mode);
					}
					else
					{
						_0024self__002421709.BackTown();
					}
					_0024self__002421709.calling = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MessageBoard _0024self__002421710;

		public _0024_0024StartCore_0024closure_00243181_002421707(MessageBoard self_)
		{
			_0024self__002421710 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421710);
		}
	}

	[NonSerialized]
	private const string _sideWeaponParentAngel = "weaponAngel";

	[NonSerialized]
	private const string _sideWeaponParentDemon = "weaponDemon";

	[NonSerialized]
	private const string _sideWeaponIconAngel = "weaponIconAngel";

	[NonSerialized]
	private const string _sideWeaponIconDemon = "weaponIconDemon";

	[NonSerialized]
	protected static string bgSpriteName;

	public UISprite bgSprite;

	public GameObject blackBg;

	public GameObject grayBg;

	public UIButtonMessage allButton;

	[NonSerialized]
	private static START_MODE startMode = START_MODE.top;

	private BBS_MODE mode;

	private BBS_MODE lastmode;

	private DialogManager dlgMan;

	public FriendList friendRequestListUI;

	public FriendList friendListUI;

	public FriendList teamRequestListUI;

	public FriendList teamMemberListUI;

	public FriendList friendSearchUI;

	public FriendList unionMemberListUI;

	public GameObject friendListItemPrefab;

	public GameObject teamSearchList;

	public GameObject teamSearchWindow;

	public ApiHomeSlim.Resp homeData;

	public bool Designer_Editting;

	private RespFriend[] cachedUnionMembers;

	private GameObject mapetIconPrefab;

	private GameObject weaponIconPrefab;

	private GameObject mapetSideIconPrefab;

	private GameObject weaponSideIconPrefab;

	public GameObject keyWordSelector;

	private readonly RespApplyInfo[] EMPTY_APPLIES;

	private readonly RespFriend[] EMPTY_FRIENDS;

	public GameObject leaderChangButton;

	private bool searchFromFriendMenu;

	private GameObject teamControlPrefab;

	private string[] OPTION_YES_NO;

	private string[] OPTION_YES_CANCEL;

	private string[] OPTION_BACK;

	private string[] OPTION_OK;

	private ApiFriendPlayerSearch.Resp friendSearchCache;

	private RespFriend currentFriend;

	private GameObject friendMapetSideIcon;

	private GameObject friendWeaponSideIcon;

	private GameObject friendWeaponSideIconDemon;

	private BBS_MODE detailBackTarget;

	private int leaderChangeTarget;

	private bool calling;

	private Dialog dialog;

	private WebView curWebView;

	public static string BgSpriteName
	{
		set
		{
			bgSpriteName = value;
		}
	}

	private RespParty Party => homeData.PartyMember;

	private RespMember[] PartyMembers
	{
		get
		{
			return homeData.PartyMember.Members;
		}
		set
		{
			homeData.PartyMember = RespParty.MakeParty(value);
		}
	}

	private RespApplyInfo[] FriendApplies
	{
		get
		{
			return (homeData.FriendApplies == null) ? EMPTY_APPLIES : homeData.FriendApplies;
		}
		set
		{
			homeData.FriendApplies = value;
		}
	}

	private RespApplyInfo[] PartyApplies
	{
		get
		{
			return (homeData.PartyApplies == null) ? EMPTY_APPLIES : homeData.PartyApplies;
		}
		set
		{
			homeData.PartyApplies = value;
		}
	}

	private RespFriend[] Friends
	{
		get
		{
			return (homeData.Friend == null) ? EMPTY_FRIENDS : homeData.Friend;
		}
		set
		{
			homeData.Friend = value;
		}
	}

	private UserAlreadyReadData AlreadyReadData => UserData.Current.userMiscInfo.alreadyReadData;

	public static START_MODE StartMode
	{
		get
		{
			return startMode;
		}
		set
		{
			startMode = value;
		}
	}

	public MessageBoard()
	{
		EMPTY_APPLIES = new RespApplyInfo[0];
		EMPTY_FRIENDS = new RespFriend[0];
	}

	private void DeleteItemLevel(GameObject prefab)
	{
		if (prefab != null)
		{
			UIListItem component = prefab.GetComponent<UIListItem>();
			if (component != null)
			{
				component.RemoveAlphaTargets("LevelText");
			}
		}
	}

	public override void StartCore()
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
		mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/MapetIcon") as GameObject;
		DeleteItemLevel(mapetIconPrefab);
		weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/WeaponIcon") as GameObject;
		DeleteItemLevel(weaponIconPrefab);
		mapetSideIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/MuppetListItem") as GameObject;
		DeleteItemLevel(mapetSideIconPrefab);
		weaponSideIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/WeaponListItem") as GameObject;
		DeleteItemLevel(weaponSideIconPrefab);
		teamControlPrefab = GameAssetModule.LoadPrefab("Prefab/GUI/TeamControl") as GameObject;
		DeleteItemLevel(teamControlPrefab);
		MapetDetailUtil.PrepareMapetPrefab(friend: true);
		WeaponDetailUtil.PrepareWeaponPrefab();
		MapetDetailUtil.PrepareMapetDetail(this.gameObject);
		WeaponDetailUtil.PrepareWeaponDetail(this.gameObject);
		GameObject gameObject = GameObject.Find("Town");
		if ((bool)gameObject)
		{
			gameObject.SetActive(value: false);
		}
		if ((bool)bgSprite)
		{
			bgSprite.gameObject.SetActive(value: false);
			if (!string.IsNullOrEmpty(bgSpriteName))
			{
				bgSprite.spriteName = bgSpriteName;
				bgSprite.gameObject.SetActive(value: true);
				bgSpriteName = string.Empty;
			}
		}
		if (string.IsNullOrEmpty(TownShopTopMain.backScene))
		{
			if ((bool)bgSprite)
			{
				bgSprite.gameObject.SetActive(value: false);
			}
			if (blackBg != null)
			{
				blackBg.SetActive(value: false);
			}
			if (grayBg != null)
			{
				grayBg.SetActive(value: true);
			}
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: true);
			}
		}
		else
		{
			if ((bool)bgSprite)
			{
				bgSprite.gameObject.SetActive(value: true);
			}
			if (blackBg != null)
			{
				blackBg.SetActive(value: true);
			}
			if (grayBg != null)
			{
				grayBg.SetActive(value: false);
			}
			if ((bool)gameObject)
			{
				gameObject.SetActive(value: false);
			}
		}
		dlgMan = DialogManager.Instance;
		calling = true;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024StartCore_0024closure_00243181_002421707(this).GetEnumerator();
		mode = BBS_MODE.waitInit;
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		startMode = START_MODE.top;
		bgSpriteName = string.Empty;
	}

	public override void SceneUpdate()
	{
		if (mode != lastmode)
		{
			lastmode = mode;
			PrepareChange((int)mode);
			UISituation[] array = situations;
			ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
		}
	}

	public bool IsPartyMember(int id)
	{
		return Party != null && Party.Contains(id);
	}

	public bool IsFriend(RespFriend friend)
	{
		RespFriend[] friends = Friends;
		int num = 0;
		int length = friends.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < length)
			{
				int index = num;
				num++;
				if (friends[RuntimeServices.NormalizeArrayIndex(friends, index)].TSocialPlayerId == friend.TSocialPlayerId)
				{
					result = 1;
					break;
				}
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public bool IsMe(RespFriend friend)
	{
		return friend.TSocialPlayerId == GetMySocialID();
	}

	public int GetTeamLeaderID()
	{
		return (Party == null) ? GetMySocialID() : Party.GetLeaderId();
	}

	public int GetTeamMemberNum()
	{
		return (Party == null) ? 1 : Party.Count();
	}

	public string GetTeamName()
	{
		string text = ((Party == null) ? UserData.Current.PlayerName : Party.GetLeader().Name);
		return UIBasicUtility.SafeFormat(MTexts.Msg("$MD_TEAM_NAME"), text);
	}

	public string GetFormattedFriendNum()
	{
		UserData current = UserData.Current;
		return UIBasicUtility.SafeFormat("{0}/{1}", Friends.Length, current.FriendMax);
	}

	public string GetFormattedFriendApplyNum()
	{
		return UIBasicUtility.SafeFormat("{0}", FriendApplies.Length);
	}

	public string GetFormattedTeamMemberNum()
	{
		MGameParameters mGameParameters = MGameParameters.findByGameParameterId(21);
		int num = default(int);
		num = mGameParameters?.Param ?? 3000;
		return UIBasicUtility.SafeFormat("{0}/{1}", GetTeamMemberNum(), num);
	}

	public string GetFormattedTeamApplyNum()
	{
		return UIBasicUtility.SafeFormat("{0}", PartyApplies.Length);
	}

	public int GetMySocialID()
	{
		UserData current = UserData.Current;
		return current.userStatus.TSocialPlayerId;
	}

	public bool ImLeader()
	{
		UserData current = UserData.Current;
		return GetTeamLeaderID() == current.userStatus.TSocialPlayerId;
	}

	public string GetUnionName()
	{
		object result;
		if (homeData.RaidBattle != null && homeData.RaidBattle.IsEnableRaid && !string.IsNullOrEmpty(homeData.RaidBattle.RoomName))
		{
			int num = int.Parse(homeData.RaidBattle.RoomName);
			result = UIBasicUtility.SafeFormat("第 {0:000000} ユニオン", num);
		}
		else
		{
			result = "------";
		}
		return (string)result;
	}

	public void PrepareChange(int nextSituationIndex)
	{
		_0024PrepareChange_0024locals_002414503 _0024PrepareChange_0024locals_0024 = new _0024PrepareChange_0024locals_002414503();
		if (Designer_Editting)
		{
			return;
		}
		UISituation[] array = situations;
		UISituation uISituation = array[RuntimeServices.NormalizeArrayIndex(array, nextSituationIndex)];
		GameObject gameObject = uISituation.gameObject;
		_0024PrepareChange_0024locals_0024._0024ud = UserData.Current;
		checked
		{
			switch (nextSituationIndex)
			{
			case 0:
			{
				UpdateText(gameObject, "1 Team", "TextTeamNum", GetFormattedTeamMemberNum());
				UpdateText(gameObject, "1 Team", "TextTeam", GetTeamName());
				UpdateText(gameObject, "0 Friend", "TextFriendNum", GetFormattedFriendNum());
				UpdateText(gameObject, "0 Friend", "TextFriendRequestNum", GetFormattedFriendApplyNum());
				bool num = homeData.PlayerRanking != null;
				if (!num)
				{
					num = homeData.QuestRanking != null;
				}
				bool flag = num;
				bool state = homeData.RaidBattle != null;
				if (QuestManager.Instance.ExistRaidBattle() && homeData.PlayerRanking != null)
				{
					UpdateText(gameObject, "2 Ranking", "TextRanking", string.Empty + homeData.PlayerRanking.Ranking);
				}
				if (QuestManager.Instance.ExistChalengeQuest() && homeData.QuestRanking != null)
				{
					UpdateText(gameObject, "2 Ranking", "TextRanking", string.Empty + homeData.QuestRanking.Ranking);
				}
				ButtonStateChange(gameObject, "3 Union", new string[1] { "Button" }, state);
				int num2 = GetNewFriendApplies().Count() + GetNewFriends().Count();
				UpdateNewCount(gameObject, "0 Friend", "TextNewNumber", (0 >= num2) ? string.Empty : num2.ToString());
				int num3 = GetNewPartyApplies().Count() + GetNewMembers().Count();
				UpdateNewCount(gameObject, "1 Team", "TextNewNumber", (0 >= num3) ? string.Empty : num3.ToString());
				UpdateText(gameObject, "3 Union", "TextUnion", GetUnionName());
				break;
			}
			case 4:
			{
				bool state2 = 1 < GetTeamMemberNum();
				bool flag2 = ImLeader();
				ButtonStateChange(gameObject, "0 TeamMemberList", new string[1] { "Button" }, state2);
				ButtonStateChange(gameObject, "2 TeamInviteList", new string[1] { "TeamRequestBotton" }, 0 < PartyApplies.Length);
				ButtonStateChange(gameObject, "4 TeamLeave", new string[1] { "Button" }, state2);
				UpdateText(gameObject, "0 TeamMemberList", "TextTeamMemberNum", GetFormattedTeamMemberNum());
				UpdateText(gameObject, "0 TeamMemberList", "TextTeamName", GetTeamName());
				int num4 = GetNewMembers().Count();
				UpdateNewCount(gameObject, "0 TeamMemberList", "TextNewNumber", (0 >= num4) ? string.Empty : num4.ToString());
				num4 = GetNewPartyApplies().Count();
				UpdateNewCount(gameObject, "2 TeamInviteList", "TextNewNumber", (0 >= num4) ? string.Empty : num4.ToString());
				UpdateText(gameObject, "2 TeamInviteList", "TextNum", PartyApplies.Length.ToString());
				__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PrepareChange_0024WaitSituation_00243182(_0024PrepareChange_0024locals_0024, this).Invoke;
				StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
				break;
			}
			case 1:
			{
				ButtonStateChange(gameObject, "0 FriendList", new string[1] { "Button" }, 0 < Friends.Length);
				ButtonStateChange(gameObject, "2 FriendRequest", new string[1] { "Button" }, 0 < FriendApplies.Length);
				UpdateText(gameObject, "0 FriendList", "TextFriendNum", GetFormattedFriendNum());
				UpdateText(gameObject, "2 FriendRequest", "TextFriendNum", GetFormattedFriendApplyNum());
				UpdateText(gameObject, "4 UserID", "TextUserID", string.Empty + GetMySocialID());
				int num2 = GetNewFriends().Count();
				UpdateNewCount(gameObject, "0 FriendList", "TextNewNumber", (0 >= num2) ? string.Empty : num2.ToString());
				num2 = GetNewFriendApplies().Count();
				UpdateNewCount(gameObject, "2 FriendRequest", "TextNewNumber", (0 >= num2) ? string.Empty : num2.ToString());
				break;
			}
			case 13:
				UpdateText(gameObject, "FriendNum", "TextFriendNumSize", string.Empty + friendSearchCache.Friends.Length);
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				friendSearchUI.listItemPrefab = friendListItemPrefab;
				friendSearchUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = friendSearchUI.SetResponse(friendSearchCache.Friends, null);
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			case 2:
				UpdateText(gameObject, "FriendNum", "TextFriendNumSize", GetFormattedFriendNum());
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				friendListUI.listItemPrefab = friendListItemPrefab;
				friendListUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = friendListUI.SetResponse(Friends, GetNewFriends());
				MarkFriends(Friends);
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			case 3:
				UpdateText(gameObject, "RequestNum", "TextRequestNum", GetFormattedFriendApplyNum());
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				friendRequestListUI.listItemPrefab = friendListItemPrefab;
				friendRequestListUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = friendRequestListUI.SetResponse(FriendApplies, GetNewFriendApplies());
				MarkFriendApplies(FriendApplies);
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			case 6:
				UpdateText(gameObject, "RequestNum", "TextRequestNum", GetFormattedTeamApplyNum());
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				teamRequestListUI.listItemPrefab = friendListItemPrefab;
				teamRequestListUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = teamRequestListUI.SetResponse(PartyApplies, GetNewPartyApplies());
				MarkPartyApplies(PartyApplies);
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			case 5:
				UpdateText(gameObject, "MemberNum", "TextMemberNumSize", GetFormattedTeamMemberNum());
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				teamMemberListUI.listItemPrefab = friendListItemPrefab;
				teamMemberListUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = teamMemberListUI.SetResponse(Party.GetOtherMembers(GetMySocialID()), GetNewMembers());
				MarkMembers(Party.GetOtherMembers(GetMySocialID()));
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			case 9:
			{
				ButtonStateChange(gameObject, "Panel", new string[1] { "MemberList" }, 1 != homeData.GuildPlayer.Count());
				string text = ((homeData.GuildRanking == null) ? "------" : UIBasicUtility.SafeFormat("{0:#,0} ", homeData.GuildRanking.RankingPoint));
				string text2 = ((homeData.GuildRanking == null) ? "---" : UIBasicUtility.SafeFormat("{0}位 ", homeData.GuildRanking.Ranking));
				string text3 = ((homeData.PlayerRanking == null) ? "------" : UIBasicUtility.SafeFormat("{0:#,0} ", homeData.PlayerRanking.RankingPoint));
				string text4 = ((homeData.PlayerRanking == null) ? "---" : UIBasicUtility.SafeFormat("{0}位 ", homeData.PlayerRanking.Ranking));
				UpdateText(gameObject, "Union", "TextPointNum", text);
				UpdateText(gameObject, "User", "TextPointNum", text3);
				UpdateText(gameObject, "Union", "TextRankingNum", text2);
				UpdateText(gameObject, "User", "TextRankingNum", text4);
				UpdateText(gameObject, "Board", "TextTitle", GetUnionName());
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			}
			case 10:
				FindObject(gameObject, "mapetIcon").GetComponent<MapetListItem>().muppetIconPrefab = mapetIconPrefab;
				FindObject(gameObject, "weaponIconAngel").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				FindObject(gameObject, "weaponIconDemon").GetComponent<WeaponListItem>().weaponIconPrefab = weaponIconPrefab;
				unionMemberListUI.listItemPrefab = friendListItemPrefab;
				unionMemberListUI.decideTarget = this.gameObject;
				unionMemberListUI.SetMapetPrefab(mapetIconPrefab);
				currentFriend = unionMemberListUI.SetResponse(cachedUnionMembers, null);
				UpdateText(gameObject, "FriendNum", "TextFriendNumSize", new StringBuilder().Append((object)cachedUnionMembers.Length).ToString());
				if (currentFriend != null)
				{
					FocusFriend(currentFriend);
				}
				break;
			}
			switch (nextSituationIndex)
			{
			case 0:
				uISituation.help = MTexts.Msg("$MD_HELP_MESSAGEBOARD");
				break;
			case 4:
				uISituation.help = MTexts.Msg("$MD_HELP_TEAM");
				break;
			case 1:
				uISituation.help = MTexts.Msg("$MD_HELP_FRIEND");
				break;
			case 13:
				uISituation.help = null;
				break;
			case 2:
				uISituation.help = MTexts.Msg("$MD_HELP_FRIEND_LIST");
				break;
			case 3:
				uISituation.help = MTexts.Msg("$MD_HELP_FRIEND_REQUEST");
				break;
			case 6:
				uISituation.help = MTexts.Msg("$MD_HELP_TEAM_REQUESTc");
				break;
			case 5:
				uISituation.help = MTexts.Msg("$MD_HELP_TEAM_LIST");
				break;
			case 9:
				uISituation.help = MTexts.Msg("$MD_HELP_UNION");
				break;
			case 10:
				uISituation.help = MTexts.Msg("$MD_HELP_UNION_LIST");
				break;
			}
		}
	}

	public void SetMapetIconInstance(GameObject situationRoot, string panelName, string parentName, GameObject prefab, string instanceName)
	{
		GameObject go = FindObject(situationRoot, panelName);
		GameObject gameObject = FindObject(go, parentName).gameObject;
		if (GameObject.Find(instanceName) == null)
		{
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject2.transform.parent = gameObject.transform;
		}
	}

	public void UpdateText(GameObject situationRoot, string panelName, string labelName, string text)
	{
		GameObject go = FindObject(situationRoot, panelName);
		FindObject(go, labelName).GetComponent<UILabelBase>().text = text;
	}

	public void UpdateNewCount(GameObject situationRoot, string panelName, string labelName, string text)
	{
		GameObject go = FindObject(situationRoot, panelName);
		GameObject gameObject = FindObject(go, labelName);
		gameObject.GetComponent<UILabelBase>().text = text;
		UIWidget component = FindObject(gameObject.transform.parent.gameObject, "badge").GetComponent<UIWidget>();
		component.enabled = !string.IsNullOrEmpty(text);
		component.gameObject.SetActive(component.enabled);
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state)
	{
		ButtonStateChange(situationRoot, panelName, buttonNames, state, null);
	}

	public void ButtonStateChange(GameObject situationRoot, string panelName, string[] buttonNames, bool state, string text)
	{
		if (Designer_Editting)
		{
			return;
		}
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
			component.gameObject.collider.enabled = state;
			component.enabled = state;
			GameObject gameObject3 = FindObject(gameObject, "bg");
			gameObject3.GetComponent<UIWidget>().color = color;
			if ((bool)gameObject3.GetComponent<TweenColor>())
			{
				UnityEngine.Object.Destroy(gameObject3.GetComponent<TweenColor>());
			}
			UIButtonSQEXSound component2 = gameObject.GetComponent<UIButtonSQEXSound>();
			if ((bool)component2)
			{
				component2.enabled = state;
			}
		}
	}

	public GameObject FindObject(GameObject go, string objName)
	{
		return ExtensionsModule.FindChild(go, objName);
	}

	public void ModeTopMenu()
	{
		mode = BBS_MODE.top;
	}

	public void ModeFriendMenu()
	{
		mode = BBS_MODE.friend;
	}

	public void ModeFriendSearch()
	{
		mode = BBS_MODE.friendsearch;
	}

	public void ModeFriendList()
	{
		mode = BBS_MODE.friendlist;
	}

	public void ModeFriendRequest()
	{
		mode = BBS_MODE.friendrequest;
	}

	public void ModeTeamMenu()
	{
		mode = BBS_MODE.team;
	}

	public void ModeTeamMember()
	{
		mode = BBS_MODE.teammember;
	}

	public void ModeteamMemberRequest()
	{
		mode = BBS_MODE.teammemberrequest;
	}

	public void ModeTeamSearch()
	{
		PushFriendSearch();
	}

	public void ModeSNSMenu()
	{
		mode = BBS_MODE.snsmenu;
	}

	public void SetErrorHandler(RequestBase req)
	{
		req.ErrorHandler = CommunicationError;
		req.IgnoreErrorCodes = new string[4] { "PaLCh003", "PaInv004", "PaApp004", "FrApp005" };
	}

	public void CommunicationError(RequestBase req)
	{
		MerlinServer.DebugResponseHook = null;
		if (req is ApiHomeSlim)
		{
			UpdateCacheAfterBack();
		}
		else if (req.ResponseObj is GameApiResponseBase { StatusCode: var statusCode })
		{
			switch (statusCode.ToLower())
			{
			case "frapp001":
				UpdateCacheAfterBack();
				break;
			case "frapp002":
				break;
			case "frapp003":
				break;
			case "frapp005":
				break;
			case "fracc001":
				break;
			case "fracc002":
				break;
			case "fracc003":
				break;
			case "fracc004":
				break;
			case "frrej001":
				UpdateCacheAfterBack();
				break;
			case "frrem001":
				break;
			case "painv001":
				UpdateCacheAfterBack();
				break;
			case "painv002":
				UpdateCacheAfterBack();
				break;
			case "painv003":
				currentFriend.IsSolo = false;
				FocusFriend(currentFriend);
				break;
			case "painv004":
				break;
			case "paacc001":
				break;
			case "paacc002":
				break;
			case "paacc003":
				UpdateCacheAfterBack();
				break;
			case "paacc004":
				UpdateCacheAfterBack();
				break;
			case "paacc005":
				UpdateCacheAfterBack();
				break;
			case "paacc006":
				UpdateCacheAfterBack();
				break;
			case "paacc007":
				UpdateCacheAfterBack();
				break;
			case "pakic001":
				UpdateCacheAfterBack();
				break;
			case "pakic002":
				UpdateCacheAfterBack();
				break;
			case "paapp001":
				break;
			case "paapp002":
				UpdateCacheAfterBack();
				break;
			case "paapp003":
				currentFriend.IsSolo = false;
				FocusFriend(currentFriend);
				break;
			case "paapp004":
				break;
			case "palch001":
				UpdateCacheAfterBack();
				break;
			case "palch002":
				UpdateCacheAfterBack();
				break;
			case "palch003":
				break;
			case "palch004":
				break;
			case "palca001":
				UpdateCacheAfterBack();
				break;
			case "palca002":
				UpdateCacheAfterBack();
				break;
			case "palca003":
				UpdateCacheAfterBack();
				break;
			case "palcr001":
				UpdateCacheAfterBack();
				break;
			case "palcr002":
				UpdateCacheAfterBack();
				break;
			case "parem001":
				UpdateCacheAfterBack();
				break;
			}
		}
	}

	public void UpdateCacheAfterBack()
	{
		ApiHomeSlim apiHomeSlim = new ApiHomeSlim();
		SetErrorHandler(apiHomeSlim);
		__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13__ from = delegate(ApiHomeSlim r)
		{
			homeData = r.GetResponse();
			cachedUnionMembers = null;
			UserData.Current.userMiscInfo.flagData.updateCondition();
			BattleHUDShortcut.ClearShortcutIcon(destroy: true);
			PushBack();
		};
		calling = false;
		Request(apiHomeSlim, _0024adaptor_0024__MessageBoard_UpdateCacheAfterBack_0024callable139_0024747_13___0024Action_0024188.Adapt(from));
	}

	public void PushFriendTeam()
	{
		_0024PushFriendTeam_0024locals_002414504 _0024PushFriendTeam_0024locals_0024 = new _0024PushFriendTeam_0024locals_002414504();
		if (!CanRequest())
		{
			return;
		}
		RequestBase requestBase = null;
		_0024PushFriendTeam_0024locals_0024._0024msg = null;
		_0024PushFriendTeam_0024locals_0024._0024title = null;
		if (mode == BBS_MODE.friendlist || mode == BBS_MODE.friendsearch || mode == BBS_MODE.union_member)
		{
			if (currentFriend.TSocialPlayerId == GetMySocialID())
			{
				OpenDialog(GetText("MD_REQUEST_SELF_ERROR"), GetText("MD_REQUEST_ERROR_TITLE"), DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
				return;
			}
			ApiPartyInvite apiPartyInvite = new ApiPartyInvite();
			apiPartyInvite.Id = currentFriend.TSocialPlayerId;
			requestBase = apiPartyInvite;
			_0024PushFriendTeam_0024locals_0024._0024title = GetText("d-mboard-teaminvite-title");
			_0024PushFriendTeam_0024locals_0024._0024msg = GetText("d-mboard-teaminvite-body", currentFriend.Name);
		}
		else if (0 == 0)
		{
			throw new AssertionFailedException("チーム加入申請はないはず･･･");
		}
		__MerlinServer_Request_0024callable86_0024160_56__ from = new _0024PushFriendTeam_0024f_00243188(_0024PushFriendTeam_0024locals_0024, this).Invoke;
		Request(requestBase, _0024adaptor_0024__MerlinServer_Request_0024callable86_0024160_56___0024Action_0024189.Adapt(from));
	}

	public void PushOpenTeamAdmin()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(teamControlPrefab);
		TeamAdminDialog teamAdminDialog = gameObject.AddComponent<TeamAdminDialog>();
		teamAdminDialog.Initialize(this);
	}

	public void PushTeamReject()
	{
		_0024PushTeamReject_0024locals_002414505 _0024PushTeamReject_0024locals_0024 = new _0024PushTeamReject_0024locals_002414505();
		if (!CanRequest())
		{
			return;
		}
		_0024PushTeamReject_0024locals_0024._0024waitCb = delegate
		{
			teamRequestListUI.RemoveCurrentEntry();
			RefreshMemberNum();
			if (teamRequestListUI.Empty())
			{
				PushBack();
			}
		};
		__MessageBoard_PushTeamReject_0024callable141_0024808_13__ _MessageBoard_PushTeamReject_0024callable141_0024808_13__ = new _0024PushTeamReject_0024Reject_00243190(this, _0024PushTeamReject_0024locals_0024).Invoke;
		__MessageBoard_PushTeamReject_0024callable141_0024808_13__ _MessageBoard_PushTeamReject_0024callable141_0024808_13__2 = new _0024PushTeamReject_0024RejectLeader_00243192(this, _0024PushTeamReject_0024locals_0024).Invoke;
		switch ((currentFriend as RespApplyInfo).RequestStatusValue)
		{
		case 1:
		{
			string text = GetText("d-mboard-teamapply-reject-body");
			title = GetText("d-mboard-teamapply-reject-title");
			_MessageBoard_PushTeamReject_0024callable141_0024808_13__(text, title);
			break;
		}
		case 2:
		{
			string text = GetText("d-mboard-teaminvite-reject-body");
			title = GetText("d-mboard-teaminvite-reject-title");
			_MessageBoard_PushTeamReject_0024callable141_0024808_13__(text, title);
			break;
		}
		case 5:
		{
			string text = GetText("d-mboard-teamleaderchange-reject-body");
			title = GetText("d-mboard-teamleaderchange-reject-title");
			_MessageBoard_PushTeamReject_0024callable141_0024808_13__2(text, title);
			break;
		}
		}
	}

	public void PushTeamAgree()
	{
		_0024PushTeamAgree_0024locals_002414506 _0024PushTeamAgree_0024locals_0024 = new _0024PushTeamAgree_0024locals_002414506();
		if (CanRequest())
		{
			_0024PushTeamAgree_0024locals_0024._0024requestType = (currentFriend as RespApplyInfo).RequestStatusValue;
			_0024PushTeamAgree_0024locals_0024._0024id = (currentFriend as RespApplyInfo).ApplyId;
			_0024PushTeamAgree_0024locals_0024._0024waitCb = new _0024PushTeamAgree_0024waitCb_00243194(this, _0024PushTeamAgree_0024locals_0024).Invoke;
			__MessageBoard_PushTeamReject_0024callable141_0024808_13__ _MessageBoard_PushTeamReject_0024callable141_0024808_13__ = new _0024PushTeamAgree_0024Accept_00243195(this, _0024PushTeamAgree_0024locals_0024).Invoke;
			__MessageBoard_PushTeamReject_0024callable141_0024808_13__ _MessageBoard_PushTeamReject_0024callable141_0024808_13__2 = new _0024PushTeamAgree_0024AcceptLeader_00243197(this, _0024PushTeamAgree_0024locals_0024).Invoke;
			switch (_0024PushTeamAgree_0024locals_0024._0024requestType)
			{
			case 1:
			{
				string text = GetText("d-mboard-teamapply-accept-body");
				title = GetText("d-mboard-teamapply-accept-title");
				_MessageBoard_PushTeamReject_0024callable141_0024808_13__(text, title);
				break;
			}
			case 2:
			{
				string text = GetText("d-mboard-teaminvite-accept-body");
				title = GetText("d-mboard-teaminvite-accept-title");
				_MessageBoard_PushTeamReject_0024callable141_0024808_13__(text, title);
				break;
			}
			case 5:
			{
				string text = GetText("d-mboard-teamleaderchange-accept-body");
				title = GetText("d-mboard-teamleaderchange-accept-title");
				_MessageBoard_PushTeamReject_0024callable141_0024808_13__2(text, title);
				break;
			}
			}
		}
	}

	public void PushFriendSearch()
	{
		if (!CanRequest())
		{
			return;
		}
		searchFromFriendMenu = mode == BBS_MODE.friend;
		UISituation[] array = situations;
		GameObject go = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
		GameObject gameObject = FindObject(go, "friendSearchLabel");
		if (!(gameObject != null))
		{
			throw new AssertionFailedException("friendSearchLabelObj != null");
		}
		UILabelBase component = gameObject.GetComponent<UILabelBase>();
		if (!(component != null))
		{
			throw new AssertionFailedException("label != null");
		}
		string text = component.text;
		ApiFriendPlayerSearch apiFriendPlayerSearch = new ApiFriendPlayerSearch();
		apiFriendPlayerSearch.Name = text;
		int result = default(int);
		if (int.TryParse(text, out result))
		{
			apiFriendPlayerSearch.Id = result;
		}
		apiFriendPlayerSearch.Num = 100;
		apiFriendPlayerSearch.IsRecommend = false;
		__MessageBoard_PushFriendSearch_0024callable145_0024918_13__ from = delegate(ApiFriendPlayerSearch r)
		{
			friendSearchCache = r.GetResponse();
			if (0 < friendSearchCache.Friends.Length)
			{
				ModeFriendSearch();
			}
			else
			{
				string text2 = GetText("d-mboard-playersearch-notfound-body");
				title = GetText("d-mboard-playersearch-notfound-title");
				OpenDialog(text2, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
			}
		};
		Request(apiFriendPlayerSearch, _0024adaptor_0024__MessageBoard_PushFriendSearch_0024callable145_0024918_13___0024Action_0024190.Adapt(from));
	}

	public void PushFriendApply()
	{
		if (!CanRequest() || currentFriend == null)
		{
			return;
		}
		if (currentFriend.TSocialPlayerId == GetMySocialID())
		{
			OpenDialog(GetText("MD_REQUEST_SELF_ERROR"), GetText("MD_REQUEST_ERROR_TITLE"), DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
			return;
		}
		UserData current = UserData.Current;
		int length = Friends.Length;
		if (current.FriendMax <= length)
		{
			dialog = DialogManager.Open(GetText("MD_REQUEST_FRIEND_MAX_ERROR"), string.Empty);
			dialog.CloseHandler = (__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
			{
			};
			return;
		}
		ApiFriendApply apiFriendApply = new ApiFriendApply();
		apiFriendApply.Id = currentFriend.TSocialPlayerId;
		__MessageBoard_PushFriendApply_0024callable146_0024950_17__ from = delegate
		{
			string text = GetText("d-mboard-friendreapply-body", currentFriend.Name);
			title = GetText("d-mboard-friendreapply-title");
			OpenDialog(text, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
		};
		Request(apiFriendApply, _0024adaptor_0024__MessageBoard_PushFriendApply_0024callable146_0024950_17___0024Action_0024191.Adapt(from));
	}

	public void PushFriendLeave()
	{
		_0024PushFriendLeave_0024locals_002414507 _0024PushFriendLeave_0024locals_0024 = new _0024PushFriendLeave_0024locals_002414507();
		if (CanRequest())
		{
			_0024PushFriendLeave_0024locals_0024._0024body = GetText("d-mboard-friendremove-ask-body");
			title = GetText("d-mboard-friendremove-ask-title");
			OpenDialog(_0024PushFriendLeave_0024locals_0024._0024body, title, DialogManager.MB_FLAG.MB_ICONQUESTION, OPTION_YES_CANCEL);
			_0024PushFriendLeave_0024locals_0024._0024req = new ApiFriendRemove();
			_0024PushFriendLeave_0024locals_0024._0024req.Id = currentFriend.TSocialPlayerId;
			__MessageBoard_PushFriendLeave_0024callable147_0024968_13__ from = new _0024PushFriendLeave_0024callback_00243202(_0024PushFriendLeave_0024locals_0024, this).Invoke;
			WaitAnswerRequest(_0024PushFriendLeave_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard_PushFriendLeave_0024callable147_0024968_13___0024Action_0024192.Adapt(from));
		}
	}

	public void PushFriendAgree()
	{
		_0024PushFriendAgree_0024locals_002414508 _0024PushFriendAgree_0024locals_0024 = new _0024PushFriendAgree_0024locals_002414508();
		if (CanRequest())
		{
			_0024PushFriendAgree_0024locals_0024._0024req = new ApiFriendAccept();
			_0024PushFriendAgree_0024locals_0024._0024req.Id = (currentFriend as RespApplyInfo).ApplyId;
			__MessageBoard_PushFriendAgree_0024callable148_0024989_13__ from = new _0024PushFriendAgree_0024f_00243204(this, _0024PushFriendAgree_0024locals_0024).Invoke;
			Request(_0024PushFriendAgree_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard_PushFriendAgree_0024callable148_0024989_13___0024Action_0024193.Adapt(from));
		}
	}

	public void PushFriendReject()
	{
		_0024PushFriendReject_0024locals_002414509 _0024PushFriendReject_0024locals_0024 = new _0024PushFriendReject_0024locals_002414509();
		if (CanRequest())
		{
			_0024PushFriendReject_0024locals_0024._0024body = GetText("d-mboard-friendreapply-reject-ask-body");
			title = GetText("d-mboard-friendreapply-reject-ask-title");
			OpenDialog(_0024PushFriendReject_0024locals_0024._0024body, title, DialogManager.MB_FLAG.MB_ICONWARNING, OPTION_YES_CANCEL);
			_0024PushFriendReject_0024locals_0024._0024req = new ApiFriendReject();
			_0024PushFriendReject_0024locals_0024._0024req.Id = (currentFriend as RespApplyInfo).ApplyId;
			__MessageBoard_PushFriendReject_0024callable149_00241014_13__ from = new _0024PushFriendReject_0024callback_00243206(this, _0024PushFriendReject_0024locals_0024).Invoke;
			WaitAnswerRequest(_0024PushFriendReject_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard_PushFriendReject_0024callable149_00241014_13___0024Action_0024194.Adapt(from));
		}
	}

	public void PushTeamLeave()
	{
		_0024PushTeamLeave_0024locals_002414510 _0024PushTeamLeave_0024locals_0024 = new _0024PushTeamLeave_0024locals_002414510();
		if (CanRequest())
		{
			_0024PushTeamLeave_0024locals_0024._0024body = GetText("d-mboard-teamremove-ask-body");
			title = GetText("d-mboard-teamremove-ask-title");
			OpenDialog(_0024PushTeamLeave_0024locals_0024._0024body, title, DialogManager.MB_FLAG.MB_ICONQUESTION, OPTION_YES_CANCEL);
			ApiPartyRemove ereq = new ApiPartyRemove();
			__MessageBoard_PushTeamLeave_0024callable150_00241037_13__ from = new _0024PushTeamLeave_0024callback_00243208(_0024PushTeamLeave_0024locals_0024, this).Invoke;
			WaitAnswerRequest(ereq, _0024adaptor_0024__MessageBoard_PushTeamLeave_0024callable150_00241037_13___0024Action_0024195.Adapt(from));
		}
	}

	public void PushTeamLeaveMenber()
	{
		_0024PushTeamLeaveMenber_0024locals_002414511 _0024PushTeamLeaveMenber_0024locals_0024 = new _0024PushTeamLeaveMenber_0024locals_002414511();
		if (CanRequest())
		{
			_0024PushTeamLeaveMenber_0024locals_0024._0024body = GetText("d-mboard-teamkick-ask-body");
			title = GetText("d-mboard-teamkick-ask-title");
			OpenDialog(_0024PushTeamLeaveMenber_0024locals_0024._0024body, title, DialogManager.MB_FLAG.MB_ICONQUESTION, OPTION_YES_CANCEL);
			_0024PushTeamLeaveMenber_0024locals_0024._0024req = new ApiPartyMemberKick();
			_0024PushTeamLeaveMenber_0024locals_0024._0024req.Id = currentFriend.TSocialPlayerId;
			__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13__ from = new _0024PushTeamLeaveMenber_0024callback_00243209(this, _0024PushTeamLeaveMenber_0024locals_0024).Invoke;
			WaitAnswerRequest(_0024PushTeamLeaveMenber_0024locals_0024._0024req, _0024adaptor_0024__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13___0024Action_0024196.Adapt(from));
		}
	}

	public void PushRanking()
	{
		mode = BBS_MODE.rankinguser;
		ShowWebHtml(new ApiWebRanking());
	}

	public void PushUnion()
	{
		mode = BBS_MODE.union;
	}

	public void PushUnionMember()
	{
		if (!CanRequest())
		{
			return;
		}
		if (cachedUnionMembers == null)
		{
			ApiGuild req = new ApiGuild();
			__MessageBoard_PushUnionMember_0024callable152_00241090_17__ from = delegate(ApiGuild r)
			{
				cachedUnionMembers = r.GetResponse().GuildPlayer;
				mode = BBS_MODE.union_member;
			};
			Request(req, _0024adaptor_0024__MessageBoard_PushUnionMember_0024callable152_00241090_17___0024Action_0024197.Adapt(from));
		}
		else
		{
			mode = BBS_MODE.union_member;
		}
	}

	public void FocusFriend(GameObject obj)
	{
		RespFriend friend = obj.GetComponent<FriendListItem>().friend;
		FocusFriend(friend);
	}

	public void FocusFriend(RespFriend friendData)
	{
		_0024FocusFriend_0024locals_002414512 _0024FocusFriend_0024locals_0024 = new _0024FocusFriend_0024locals_002414512();
		_0024FocusFriend_0024locals_0024._0024ud = UserData.Current;
		UISituation[] array = situations;
		GameObject go2 = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
		_0024FocusFriend_0024locals_0024._0024friendWeapon = friendData.GetFriendWeapon();
		_0024FocusFriend_0024locals_0024._0024friendWeaponDemon = friendData.GetFriendWeapon(RACE_TYPE.Akuma);
		_0024FocusFriend_0024locals_0024._0024friendMapet = friendData.GetFriendPet();
		_0024FocusFriend_0024locals_0024._0024poppetGo = FindObject(go2, "Poppet");
		MPoppets mPoppets = MPoppets.Get(friendData.ItemId);
		if (mPoppets == null)
		{
			throw new AssertionFailedException("mpoppet != null");
		}
		__MessageBoard_FocusFriend_0024callable138_00241127_13__ _MessageBoard_FocusFriend_0024callable138_00241127_13__ = delegate(GameObject go, string objName, string text)
		{
			GameObject gameObject = FindObject(go, objName);
			object result;
			if (!(gameObject == null))
			{
				UILabelBase component = gameObject.GetComponent<UILabelBase>();
				UIBasicUtility.SetLabel(component, text);
				result = component;
			}
			else
			{
				result = null;
			}
			return (UILabelBase)result;
		};
		string text2 = mPoppets.Name.ToString();
		_MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024poppetGo, "TextPoppetName", new StringBuilder().Append(_0024FocusFriend_0024locals_0024._0024friendMapet.Name).ToString());
		UILabelBase label = _MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024poppetGo, "TextPoppetLv", new StringBuilder("lv").Append((object)friendData.PoppetLevel).ToString());
		UIBasicUtility.SetLabelColor(label, _0024FocusFriend_0024locals_0024._0024friendMapet.LevelColor);
		_0024FocusFriend_0024locals_0024._0024weaponGo = FindObject(go2, "weaponAngel");
		_MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024weaponGo, "TextWeaponName", new StringBuilder().Append(_0024FocusFriend_0024locals_0024._0024friendWeapon.Name).ToString());
		label = _MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024weaponGo, "TextWeaponLv", new StringBuilder("lv").Append((object)_0024FocusFriend_0024locals_0024._0024friendWeapon.Level).ToString());
		UIBasicUtility.SetLabelColor(label, _0024FocusFriend_0024locals_0024._0024friendWeapon.LevelColor);
		_0024FocusFriend_0024locals_0024._0024weaponGoDemon = FindObject(go2, "weaponDemon");
		_MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024weaponGoDemon, "TextWeaponName", new StringBuilder().Append(_0024FocusFriend_0024locals_0024._0024friendWeaponDemon.Name).ToString());
		UILabelBase label2 = _MessageBoard_FocusFriend_0024callable138_00241127_13__(_0024FocusFriend_0024locals_0024._0024weaponGoDemon, "TextWeaponLv", new StringBuilder("lv").Append((object)_0024FocusFriend_0024locals_0024._0024friendWeaponDemon.Level).ToString());
		UIBasicUtility.SetLabelColor(label2, _0024FocusFriend_0024locals_0024._0024friendWeaponDemon.LevelColor);
		GameObject go3 = FindObject(go2, "UserInfo");
		if (friendData != null)
		{
			_MessageBoard_FocusFriend_0024callable138_00241127_13__(go3, "TextUserName", new StringBuilder().Append(friendData.Name).ToString());
		}
		currentFriend = friendData;
		switch (mode)
		{
		case BBS_MODE.friendlist:
			if (true)
			{
				if (ImLeader() && friendData.IsSolo)
				{
					ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_INVITE"));
				}
				else
				{
					ChangeInviteButtonState(l: false, GetText("MD_BUTTON_TEAM_INVITE"));
				}
			}
			break;
		case BBS_MODE.friendsearch:
			if (true)
			{
				if (ImLeader() && friendData.IsSolo)
				{
					ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_INVITE"));
				}
				else
				{
					ChangeInviteButtonState(l: false, GetText("MD_BUTTON_TEAM_INVITE"));
				}
			}
			if (IsFriend(friendData))
			{
				ChangeLeaveButtonState(l: false, GetText("MD_BUTTON_FRIEND_ALREADY"));
			}
			else
			{
				ChangeLeaveButtonState(l: true, GetText("MD_BUTTON_FRIEND_INVITE"));
			}
			break;
		case BBS_MODE.teammemberrequest:
			SetMemberRequestButton();
			break;
		case BBS_MODE.teammember:
			leaderChangeTarget = friendData.TSocialPlayerId;
			if (IsFriend(friendData))
			{
				ChangeInviteButtonState(l: false, GetText("MD_BUTTON_FRIEND_ALREADY"));
			}
			else
			{
				ChangeInviteButtonState(l: true, GetText("MD_BUTTON_FRIEND_INVITE"));
			}
			ChangeLeaveButtonState(ImLeader(), null);
			break;
		case BBS_MODE.union_member:
			if (true)
			{
				if (ImLeader() && friendData.IsSolo && !IsMe(friendData))
				{
					ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_INVITE"));
				}
				else
				{
					ChangeInviteButtonState(l: false, GetText("MD_BUTTON_TEAM_INVITE"));
				}
			}
			if (IsMe(friendData))
			{
				ChangeRequestButtonState(l: false, GetText("MD_BUTTON_FRIEND_INVITE"));
			}
			else if (IsFriend(friendData))
			{
				ChangeRequestButtonState(l: false, GetText("MD_BUTTON_FRIEND_ALREADY"));
			}
			else
			{
				ChangeRequestButtonState(l: true, GetText("MD_BUTTON_FRIEND_INVITE"));
			}
			break;
		}
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = new _0024FocusFriend_0024SetSideMapetIcon_00243184(_0024FocusFriend_0024locals_0024, this).Invoke;
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__2 = new _0024FocusFriend_0024SetSideWeaponIcon_00243185(this, _0024FocusFriend_0024locals_0024).Invoke;
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__();
		_ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__2();
	}

	private void _setSideWeaponIcon(RespWeapon aWeapon, GameObject aParent, ref GameObject aIcon, string aFuncName)
	{
		if (aParent != null)
		{
			if (aIcon == null)
			{
				aIcon = (GameObject)UnityEngine.Object.Instantiate(weaponSideIconPrefab);
			}
			aIcon.transform.parent = aParent.transform;
			aIcon.transform.localScale = Vector3.one;
			aIcon.transform.localPosition = Vector3.zero;
			UserData current = UserData.Current;
			current.userMiscInfo.weaponBookData.look(aWeapon.Master);
			WeaponListItem component = aIcon.GetComponent<WeaponListItem>();
			component.enableIconSprite = true;
			component.enableLevelLabel = false;
			component.SetWeapon(aWeapon);
			UIButtonMessage component2 = aIcon.GetComponent<UIButtonMessage>();
			component2.target = gameObject;
			component2.functionName = aFuncName;
			component.DestroyLevel();
		}
	}

	private void SetMemberRequestButton()
	{
		switch ((currentFriend as RespApplyInfo).RequestStatusValue)
		{
		case 1:
			ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_ACCEPT"));
			break;
		case 2:
			ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_JOIN"));
			break;
		case 5:
			ChangeInviteButtonState(l: true, GetText("MD_BUTTON_TEAM_LEADER"));
			break;
		}
	}

	public void ChangeInviteButtonState(bool l)
	{
		ChangeInviteButtonState(l, null);
	}

	public void ChangeInviteButtonState(bool l, string text)
	{
		if (!Designer_Editting)
		{
			UISituation[] array = situations;
			GameObject situationRoot = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
			ButtonStateChange(situationRoot, "Team", new string[1] { "Button" }, l, text);
		}
	}

	public void ChangeLeaveButtonState(bool l, string text)
	{
		if (!Designer_Editting)
		{
			UISituation[] array = situations;
			GameObject situationRoot = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
			ButtonStateChange(situationRoot, "Leave", new string[1] { "Button" }, l, text);
		}
	}

	public void ChangeRequestButtonState(bool l, string text)
	{
		if (!Designer_Editting)
		{
			UISituation[] array = situations;
			GameObject situationRoot = array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)].gameObject;
			ButtonStateChange(situationRoot, "Request", new string[1] { "Button" }, l, text);
		}
	}

	public void PushLeaderChange()
	{
		ApiPartyLeaderChange apiPartyLeaderChange = new ApiPartyLeaderChange();
		apiPartyLeaderChange.Id = leaderChangeTarget;
		__MessageBoard_PushLeaderChange_0024callable153_00241360_20__ from = delegate
		{
			title = GetText("d-mboard-teamleaderchange-title");
			string text = GetText("d-mboard-teamleaderchange-body");
			OpenDialog(text, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
		};
		Request(apiPartyLeaderChange, _0024adaptor_0024__MessageBoard_PushLeaderChange_0024callable153_00241360_20___0024Action_0024198.Adapt(from));
	}

	public void DecideWeapon(GameObject obj)
	{
		detailBackTarget = mode;
		RespFriend respFriend = currentFriend;
		WeaponDetailUtil.Open(respFriend.GetFriendWeapon(), gameObject);
	}

	public void DecideWeaponDemon(GameObject obj)
	{
		detailBackTarget = mode;
		RespFriend respFriend = currentFriend;
		WeaponDetailUtil.Open(respFriend.GetFriendWeapon(RACE_TYPE.Akuma), gameObject);
	}

	public void DecideFriend(GameObject obj)
	{
		detailBackTarget = mode;
		RespFriend respFriend = currentFriend;
		MapetDetailUtil.Open(respFriend.GetFriendPet(), gameObject);
	}

	public void WaitAnswerRequest(RequestBase ereq, Action<RequestBase> act)
	{
		_0024WaitAnswerRequest_0024locals_002414513 _0024WaitAnswerRequest_0024locals_0024 = new _0024WaitAnswerRequest_0024locals_002414513();
		_0024WaitAnswerRequest_0024locals_0024._0024ereq = ereq;
		_0024WaitAnswerRequest_0024locals_0024._0024act = act;
		if (CanRequest())
		{
			dialog.ButtonHandler = new _0024WaitAnswerRequest_0024closure_00243213(this, _0024WaitAnswerRequest_0024locals_0024).Invoke;
		}
	}

	public void WaitAnswer(Action act)
	{
		_0024WaitAnswer_0024locals_002414514 _0024WaitAnswer_0024locals_0024 = new _0024WaitAnswer_0024locals_002414514();
		_0024WaitAnswer_0024locals_0024._0024act = act;
		dialog.ButtonHandler = new _0024WaitAnswer_0024closure_00243214(_0024WaitAnswer_0024locals_0024).Invoke;
	}

	public void Request(RequestBase req, Action<RequestBase> act)
	{
		_0024Request_0024locals_002414515 _0024Request_0024locals_0024 = new _0024Request_0024locals_002414515();
		_0024Request_0024locals_0024._0024req = req;
		_0024Request_0024locals_0024._0024act = act;
		if (calling)
		{
			throw new AssertionFailedException("calling == false");
		}
		calling = true;
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024Request_0024closure_00243187(this, _0024Request_0024locals_0024).Invoke;
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	public bool CanRequest()
	{
		return !calling;
	}

	private void OpenDialog(string msg, string title, DialogManager.MB_FLAG flag, string[] btns)
	{
		CloseDialog();
		dlgMan.OnButton(0);
		dialog = dlgMan.OpenDialog(msg, title, flag, btns).GetComponent<Dialog>();
	}

	private string GetText(string masterKey)
	{
		return GetText(masterKey, string.Empty);
	}

	private string GetText(string masterKey, string arg)
	{
		MTexts mTexts = MTexts.Get("$" + masterKey);
		string format = TextTagCheck.ReplaceMultiLine(mTexts.ToString());
		return UIBasicUtility.SafeFormat(format, arg);
	}

	private void CloseDialog()
	{
		if ((bool)dialog)
		{
			dlgMan.OnButton(0);
			dlgMan.OnClose(dialog);
			dialog = null;
		}
	}

	private void OnScenePreChange()
	{
		SceneChanger.ScenePreChangeEvent -= _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__Req_FailHandler_0024callable6_0024440_32___0024148.Adapt(OnScenePreChange);
		WriteBackToCache();
	}

	private void WriteBackToCache()
	{
		UserData.Current.setFriendList(Friends);
		UserData.Current.setParty(Party);
		UserData.Current.NewFriendData = GetNewFriends().Count();
		UserData.Current.NewFriendApplyData = GetNewFriendApplies().Count();
		UserData.Current.NewPartyMemberData = GetNewMembers().Count();
		UserData.Current.NewPartyApplyData = GetNewPartyApplies().Count();
		ShortcutIcon.UpdateNoticeFlag("MessageBoard_ShortcutSubIcon", 0 < GetAllNewDataNum());
	}

	public void PushBack()
	{
		if (MapetDetailUtil.IsOpened())
		{
			MapetDetailUtil.Close();
		}
		else if (WeaponDetailUtil.IsOpened())
		{
			WeaponDetailUtil.Close();
		}
		else if (mode == BBS_MODE.top)
		{
			WriteBackToCache();
			BackTown();
		}
		else if (mode == BBS_MODE.friend)
		{
			mode = BBS_MODE.top;
		}
		else if (mode == BBS_MODE.friendlist)
		{
			mode = BBS_MODE.friend;
		}
		else if (mode == BBS_MODE.friendrequest)
		{
			mode = BBS_MODE.friend;
		}
		else if (mode == BBS_MODE.friendsearch)
		{
			if (searchFromFriendMenu)
			{
				mode = BBS_MODE.friend;
			}
			else
			{
				mode = BBS_MODE.team;
			}
		}
		else if (mode == BBS_MODE.team)
		{
			mode = BBS_MODE.top;
		}
		else if (mode == BBS_MODE.teammember)
		{
			mode = BBS_MODE.team;
		}
		else if (mode == BBS_MODE.teammemberrequest)
		{
			mode = BBS_MODE.team;
		}
		else if (mode == BBS_MODE.teamsearch)
		{
			mode = BBS_MODE.team;
		}
		else if (mode == BBS_MODE.snsmenu)
		{
			mode = BBS_MODE.top;
		}
		else if (mode == BBS_MODE.union)
		{
			if (!string.IsNullOrEmpty(TownShopTopMain.backScene))
			{
				BackTown();
			}
			else
			{
				mode = BBS_MODE.top;
			}
		}
		else if (mode == BBS_MODE.union_member)
		{
			mode = BBS_MODE.union;
		}
		else if (mode == BBS_MODE.friendDetail)
		{
			mode = detailBackTarget;
		}
		else if (mode == BBS_MODE.rankinguser)
		{
			mode = BBS_MODE.top;
		}
	}

	public void RequestTeamNotify(UserTeamNotifyData notify)
	{
		_0024RequestTeamNotify_0024locals_002414516 _0024RequestTeamNotify_0024locals_0024 = new _0024RequestTeamNotify_0024locals_002414516();
		_0024RequestTeamNotify_0024locals_0024._0024leavers = notify.GetLeavers(Party.Members).ToList();
		_0024RequestTeamNotify_0024locals_0024._0024newfaces = notify.GetNewFaces(Party.Members).ToList();
		_0024RequestTeamNotify_0024locals_0024._0024oldLeader = notify.GetLeader();
		_0024RequestTeamNotify_0024locals_0024._0024exit = false;
		_0024RequestTeamNotify_0024locals_0024._0024openNotify = null;
		_0024RequestTeamNotify_0024locals_0024._0024runNotify = new _0024RequestTeamNotify_0024runNotify_00243215(_0024RequestTeamNotify_0024locals_0024, this).Invoke;
		_0024RequestTeamNotify_0024locals_0024._0024openNotify = new _0024RequestTeamNotify_0024closure_00243216(this, _0024RequestTeamNotify_0024locals_0024).Invoke;
		notify.Update(Party);
		_0024RequestTeamNotify_0024locals_0024._0024runNotify();
	}

	public int GetAllNewDataNum()
	{
		return checked(GetNewFriends().Count() + GetNewFriendApplies().Count() + GetNewMembers().Count() + GetNewPartyApplies().Count());
	}

	public HashSet<int> MarkFriends(RespFriend[] arr)
	{
		UserData.Current.NewFriendData = 0;
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.MarkFriends(arr);
	}

	public HashSet<int> MarkMembers(RespFriend[] arr)
	{
		UserData.Current.NewPartyMemberData = 0;
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.MarkMembers(arr);
	}

	public HashSet<int> MarkFriendApplies(RespApplyInfo[] arr)
	{
		UserData.Current.NewFriendApplyData = 0;
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.MarkFriendApplies(arr);
	}

	public HashSet<int> MarkPartyApplies(RespApplyInfo[] arr)
	{
		UserData.Current.NewPartyApplyData = 0;
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.MarkPartyApplies(arr);
	}

	public HashSet<int> GetNewFriends()
	{
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.GetNewFriends(Friends);
	}

	public HashSet<int> GetNewFriendApplies()
	{
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		HashSet<int> newFriendApplies = alreadyReadData.GetNewFriendApplies(FriendApplies);
		HashSet<int> hashSet = new HashSet<int>();
		RespApplyInfo[] friendApplies = FriendApplies;
		int i = 0;
		RespApplyInfo[] array = friendApplies;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (newFriendApplies.Contains(array[i].ApplyId))
			{
				hashSet.Add(array[i].TSocialPlayerId);
			}
		}
		return hashSet;
	}

	public HashSet<int> GetNewMembers()
	{
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		return alreadyReadData.GetNewMembers(Party.GetOtherMembers(GetMySocialID()));
	}

	public HashSet<int> GetNewPartyApplies()
	{
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		HashSet<int> newPartyApplies = alreadyReadData.GetNewPartyApplies(PartyApplies);
		HashSet<int> hashSet = new HashSet<int>();
		RespApplyInfo[] partyApplies = PartyApplies;
		int i = 0;
		RespApplyInfo[] array = partyApplies;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (newPartyApplies.Contains(array[i].ApplyId))
			{
				hashSet.Add(array[i].TSocialPlayerId);
			}
		}
		return hashSet;
	}

	public void InitPartyNewInfo()
	{
		UserData current = UserData.Current;
	}

	public void ShowWebHtml(RequestBase req)
	{
		StartCoroutine(ShowWebHtmlCore(req));
	}

	public IEnumerator ShowWebHtmlCore(RequestBase req)
	{
		return new _0024ShowWebHtmlCore_002421702(req, this).GetEnumerator();
	}

	public void PushSerial()
	{
		ShowWebHtml(new ApiSerial());
	}

	private void RefreshMemberNum()
	{
		UISituation[] array = situations;
		UISituation uISituation = array[RuntimeServices.NormalizeArrayIndex(array, (int)lastmode)];
		GameObject situationRoot = uISituation.gameObject;
		switch (lastmode)
		{
		case BBS_MODE.friendsearch:
			UpdateText(situationRoot, "FriendNum", "TextFriendNumSize", string.Empty + friendSearchCache.Friends.Length);
			break;
		case BBS_MODE.friendlist:
			UpdateText(situationRoot, "FriendNum", "TextFriendNumSize", GetFormattedFriendNum());
			break;
		case BBS_MODE.friendrequest:
			UpdateText(situationRoot, "RequestNum", "TextRequestNum", GetFormattedFriendApplyNum());
			break;
		case BBS_MODE.teammemberrequest:
			UpdateText(situationRoot, "RequestNum", "TextRequestNum", GetFormattedTeamApplyNum());
			break;
		case BBS_MODE.teammember:
			UpdateText(situationRoot, "MemberNum", "TextMemberNumSize", GetFormattedTeamMemberNum());
			break;
		case BBS_MODE.union_member:
			UpdateText(situationRoot, "FriendNum", "TextFriendNumSize", new StringBuilder().Append((object)cachedUnionMembers.Length).ToString());
			break;
		}
	}

	internal IEnumerator _0024StartCore_0024closure_00243181()
	{
		return new _0024_0024StartCore_0024closure_00243181_002421707(this).GetEnumerator();
	}

	internal UILabelBase _0024FocusFriend_0024findAndSetLabel_00243183(GameObject go, string objName, string text)
	{
		GameObject gameObject = FindObject(go, objName);
		object result;
		if (!(gameObject == null))
		{
			UILabelBase component = gameObject.GetComponent<UILabelBase>();
			UIBasicUtility.SetLabel(component, text);
			result = component;
		}
		else
		{
			result = null;
		}
		return (UILabelBase)result;
	}

	internal void _0024UpdateCacheAfterBack_0024f_00243186(ApiHomeSlim r)
	{
		homeData = r.GetResponse();
		cachedUnionMembers = null;
		UserData.Current.userMiscInfo.flagData.updateCondition();
		BattleHUDShortcut.ClearShortcutIcon(destroy: true);
		PushBack();
	}

	internal void _0024PushTeamReject_0024waitCb_00243189()
	{
		teamRequestListUI.RemoveCurrentEntry();
		RefreshMemberNum();
		if (teamRequestListUI.Empty())
		{
			PushBack();
		}
	}

	internal void _0024PushFriendSearch_0024f_00243199(ApiFriendPlayerSearch r)
	{
		friendSearchCache = r.GetResponse();
		if (0 < friendSearchCache.Friends.Length)
		{
			ModeFriendSearch();
			return;
		}
		string text = GetText("d-mboard-playersearch-notfound-body");
		title = GetText("d-mboard-playersearch-notfound-title");
		OpenDialog(text, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
	}

	internal void _0024PushFriendApply_0024closure_00243200()
	{
	}

	internal void _0024PushFriendApply_0024f_00243201(ApiFriendApply r)
	{
		string text = GetText("d-mboard-friendreapply-body", currentFriend.Name);
		title = GetText("d-mboard-friendreapply-title");
		OpenDialog(text, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
	}

	internal void _0024_0024PushFriendLeave_0024callback_00243202_0024waitCb_00243203()
	{
		if (friendListUI.Empty())
		{
			PushBack();
		}
	}

	internal void _0024_0024PushFriendAgree_0024f_00243204_0024waitCb_00243205()
	{
		if (friendRequestListUI.Empty())
		{
			PushBack();
		}
	}

	internal void _0024_0024PushFriendReject_0024callback_00243206_0024waitCb_00243207()
	{
		if (friendRequestListUI.Empty())
		{
			PushBack();
		}
	}

	internal void _0024_0024PushTeamLeaveMenber_0024callback_00243209_0024waitCb_00243210()
	{
		if (teamMemberListUI.Empty())
		{
			PushBack();
		}
	}

	internal void _0024PushUnionMember_0024closure_00243211(ApiGuild r)
	{
		cachedUnionMembers = r.GetResponse().GuildPlayer;
		mode = BBS_MODE.union_member;
	}

	internal void _0024PushLeaderChange_0024closure_00243212(ApiPartyLeaderChange x)
	{
		title = GetText("d-mboard-teamleaderchange-title");
		string text = GetText("d-mboard-teamleaderchange-body");
		OpenDialog(text, title, DialogManager.MB_FLAG.MB_ICONHAND, OPTION_OK);
	}
}
