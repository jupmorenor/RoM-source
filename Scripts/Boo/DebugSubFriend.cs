using System;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubFriend : RuntimeDebugModeGuiMixin
{
	[Serializable]
	internal class _0024snamevaluetoggle_0024locals_002414275
	{
		internal GUILayoutOption[] _0024targs;

		internal GUILayoutOption[] _0024hargs;

		internal string _0024title;

		internal object _0024param;

		internal bool _0024value;

		internal string[] _0024buttonString;

		internal ICallable _0024func;

		internal GUILayoutOption[] _0024args;
	}

	[Serializable]
	internal class _0024reqFriendsList_0024locals_002414276
	{
		internal ApiFriendPlayerSearch _0024r;
	}

	[Serializable]
	internal class _0024reqAppliesList_0024locals_002414277
	{
		internal ApiFriendApplyList _0024r;
	}

	[Serializable]
	internal class _0024snamevaluetoggle_0024closure_00243454
	{
		internal _0024snamevaluetoggle_0024locals_002414275 _0024_0024locals_002414612;

		public _0024snamevaluetoggle_0024closure_00243454(_0024snamevaluetoggle_0024locals_002414275 _0024_0024locals_002414612)
		{
			this._0024_0024locals_002414612 = _0024_0024locals_002414612;
		}

		public void Invoke()
		{
			RuntimeDebugModeGuiMixin.toggle(ref _0024_0024locals_002414612._0024value, _0024_0024locals_002414612._0024title, _0024_0024locals_002414612._0024hargs);
			RuntimeDebugModeGuiMixin.slabel(_0024_0024locals_002414612._0024title + ": ", _0024_0024locals_002414612._0024targs);
			RuntimeDebugModeGuiMixin.slabel(_0024_0024locals_002414612._0024value.ToString(), _0024_0024locals_002414612._0024args);
			if (RuntimeDebugModeGuiMixin.sbutton(_0024_0024locals_002414612._0024buttonString[0], _0024_0024locals_002414612._0024args))
			{
				_0024_0024locals_002414612._0024func.Call(new object[2] { _0024_0024locals_002414612._0024param, true });
			}
			if (RuntimeDebugModeGuiMixin.sbutton(_0024_0024locals_002414612._0024buttonString[1], _0024_0024locals_002414612._0024args))
			{
				_0024_0024locals_002414612._0024func.Call(new object[2] { _0024_0024locals_002414612._0024param, false });
			}
		}
	}

	[Serializable]
	internal class _0024reqFriendsList_0024closure_00243455
	{
		internal DebugSubFriend _0024this_002414613;

		internal _0024reqFriendsList_0024locals_002414276 _0024_0024locals_002414614;

		public _0024reqFriendsList_0024closure_00243455(DebugSubFriend _0024this_002414613, _0024reqFriendsList_0024locals_002414276 _0024_0024locals_002414614)
		{
			this._0024this_002414613 = _0024this_002414613;
			this._0024_0024locals_002414614 = _0024_0024locals_002414614;
		}

		public void Invoke()
		{
			ApiFriendPlayerSearch.Resp response = _0024_0024locals_002414614._0024r.GetResponse();
			if (response != null)
			{
				_0024this_002414613.respFriends = response.Friends;
			}
		}
	}

	[Serializable]
	internal class _0024reqAppliesList_0024closure_00243456
	{
		internal DebugSubFriend _0024this_002414615;

		internal _0024reqAppliesList_0024locals_002414277 _0024_0024locals_002414616;

		public _0024reqAppliesList_0024closure_00243456(DebugSubFriend _0024this_002414615, _0024reqAppliesList_0024locals_002414277 _0024_0024locals_002414616)
		{
			this._0024this_002414615 = _0024this_002414615;
			this._0024_0024locals_002414616 = _0024_0024locals_002414616;
		}

		public void Invoke()
		{
			ApiFriendApplyList.Resp response = _0024_0024locals_002414616._0024r.GetResponse();
			if (response != null)
			{
				_0024this_002414615.applies = response.Applies;
			}
		}
	}

	protected int select;

	protected bool busy;

	protected RespFriend[] respFriends;

	protected RespApplyInfo[] applies;

	public static void snamevaluetoggle(string title, object param, bool value, string[] buttonString, int titleWidth, ICallable func, params GUILayoutOption[] args)
	{
		_0024snamevaluetoggle_0024locals_002414275 _0024snamevaluetoggle_0024locals_0024 = new _0024snamevaluetoggle_0024locals_002414275();
		_0024snamevaluetoggle_0024locals_0024._0024title = title;
		_0024snamevaluetoggle_0024locals_0024._0024param = param;
		_0024snamevaluetoggle_0024locals_0024._0024value = value;
		_0024snamevaluetoggle_0024locals_0024._0024buttonString = buttonString;
		_0024snamevaluetoggle_0024locals_0024._0024func = func;
		_0024snamevaluetoggle_0024locals_0024._0024args = args;
		_0024snamevaluetoggle_0024locals_0024._0024targs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024snamevaluetoggle_0024locals_0024._0024args, new GUILayoutOption[1] { RuntimeDebugModeGuiMixin.optWidth(titleWidth) });
		_0024snamevaluetoggle_0024locals_0024._0024hargs = (GUILayoutOption[])RuntimeServices.AddArrays(typeof(GUILayoutOption), _0024snamevaluetoggle_0024locals_0024._0024args, new GUILayoutOption[1] { RuntimeDebugModeGuiMixin.optWidth(125) });
		RuntimeDebugModeGuiMixin.horizontal(new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024snamevaluetoggle_0024closure_00243454(_0024snamevaluetoggle_0024locals_0024).Invoke));
	}

	public override void OnGUI()
	{
		int titleWidth = 250;
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		if (RuntimeDebugModeGuiMixin.button("New 冒険者＆フレンド List"))
		{
			reqFriendsList();
			reqAppliesList();
		}
		RuntimeDebugModeGuiMixin.label("ランダム 冒険者＆フレンド");
		checked
		{
			if (respFriends != null)
			{
				int i = 0;
				RespFriend[] array = respFriends;
				for (int length = array.Length; i < length; i++)
				{
					bool value = current.userFriendListData.find(array[i].TSocialPlayerId) != null;
					snamevaluetoggle(new StringBuilder().Append(array[i].Name).Append("(id=").Append((object)array[i].TSocialPlayerId)
						.Append(")")
						.ToString(), array[i], value, new string[2] { "申請", "解除" }, titleWidth, new __DebugSubFriend_OnGUI_0024callable379_002446_101__(funcFrList));
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("    <NO 冒険者＆フレンド>");
			}
			RuntimeDebugModeGuiMixin.label("フレンド申請");
			if (applies != null)
			{
				int j = 0;
				RespApplyInfo[] array2 = applies;
				for (int length2 = array2.Length; j < length2; j++)
				{
					bool value = false;
					snamevaluetoggle(new StringBuilder().Append(array2[j].Name).Append("(id=").Append((object)array2[j].TSocialPlayerId)
						.Append(")")
						.ToString(), array2[j], value, new string[2] { "許諾", "拒否" }, titleWidth, new __DebugSubFriend_OnGUI_0024callable379_002446_101__(funcFrApply));
				}
			}
			else
			{
				RuntimeDebugModeGuiMixin.label("    <NO フレンド申請>");
			}
			RuntimeDebugModeGuiMixin.label("フレンド");
			if (applies != null)
			{
				foreach (RespFriend friend in current.userFriendListData.friends)
				{
					bool value = false;
					snamevaluetoggle(new StringBuilder().Append(friend.Name).Append("(id=").Append((object)friend.TSocialPlayerId)
						.Append(")")
						.ToString(), friend, value, new string[2]
					{
						string.Empty,
						"解除"
					}, titleWidth, new __DebugSubFriend_OnGUI_0024callable379_002446_101__(funcFrList));
				}
				return;
			}
			RuntimeDebugModeGuiMixin.label("    <NO フレンド>");
		}
	}

	public void reqFriendsList()
	{
		_0024reqFriendsList_0024locals_002414276 _0024reqFriendsList_0024locals_0024 = new _0024reqFriendsList_0024locals_002414276();
		UserData current = UserData.Current;
		if (current != null)
		{
			respFriends = null;
			_0024reqFriendsList_0024locals_0024._0024r = new ApiFriendPlayerSearch();
			_0024reqFriendsList_0024locals_0024._0024r.IsRecommend = true;
			_0024reqFriendsList_0024locals_0024._0024r.Num = current.FriendMax;
			MerlinServer.Request(_0024reqFriendsList_0024locals_0024._0024r, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024reqFriendsList_0024closure_00243455(this, _0024reqFriendsList_0024locals_0024).Invoke));
		}
	}

	public void reqAppliesList()
	{
		_0024reqAppliesList_0024locals_002414277 _0024reqAppliesList_0024locals_0024 = new _0024reqAppliesList_0024locals_002414277();
		applies = null;
		_0024reqAppliesList_0024locals_0024._0024r = new ApiFriendApplyList();
		MerlinServer.Request(_0024reqAppliesList_0024locals_0024._0024r, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024reqAppliesList_0024closure_00243456(this, _0024reqAppliesList_0024locals_0024).Invoke));
	}

	public void funcFrList(object param, bool v)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		object obj = param;
		if (!(obj is RespFriend))
		{
			obj = RuntimeServices.Coerce(obj, typeof(RespFriend));
		}
		RespFriend respFriend = (RespFriend)obj;
		if (respFriend == null || busy)
		{
			return;
		}
		if (v)
		{
			if (current.userFriendListData.find(respFriend.TSocialPlayerId) == null)
			{
				busy = true;
				ApiFriendApply apiFriendApply = new ApiFriendApply();
				apiFriendApply.Id = respFriend.TSocialPlayerId;
				MerlinServer.Request(apiFriendApply, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
				{
					busy = false;
				}));
			}
		}
		else if (current.userFriendListData.find(respFriend.TSocialPlayerId) != null)
		{
			busy = true;
			ApiFriendRemove apiFriendRemove = new ApiFriendRemove();
			apiFriendRemove.Id = respFriend.TSocialPlayerId;
			MerlinServer.Request(apiFriendRemove, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				busy = false;
			}));
		}
	}

	public void funcFrApply(object param, bool v)
	{
		UserData current = UserData.Current;
		if (current == null || busy)
		{
			return;
		}
		object obj = param;
		if (!(obj is RespApplyInfo))
		{
			obj = RuntimeServices.Coerce(obj, typeof(RespApplyInfo));
		}
		RespApplyInfo respApplyInfo = (RespApplyInfo)obj;
		if (respApplyInfo == null)
		{
			return;
		}
		if (v)
		{
			busy = true;
			ApiFriendAccept apiFriendAccept = new ApiFriendAccept();
			apiFriendAccept.Id = respApplyInfo.ApplyId;
			MerlinServer.Request(apiFriendAccept, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				busy = false;
			}));
			reqAppliesList();
		}
		else
		{
			ApiFriendReject apiFriendReject = new ApiFriendReject();
			apiFriendReject.Id = respApplyInfo.ApplyId;
			MerlinServer.Request(apiFriendReject, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(delegate
			{
				busy = false;
			}));
			reqAppliesList();
		}
	}

	public override void Update()
	{
	}

	public override void HideModeUpdate()
	{
	}

	public override void HideModeOnGUI()
	{
	}

	public override void Init()
	{
		reqFriendsList();
		reqAppliesList();
	}

	public override void Exit()
	{
	}

	internal void _0024funcFrList_0024closure_00243457()
	{
		busy = false;
	}

	internal void _0024funcFrList_0024closure_00243458()
	{
		busy = false;
	}

	internal void _0024funcFrApply_0024closure_00243459()
	{
		busy = false;
	}

	internal void _0024funcFrApply_0024closure_00243460()
	{
		busy = false;
	}
}
