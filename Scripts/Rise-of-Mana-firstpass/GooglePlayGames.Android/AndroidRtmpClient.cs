using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class AndroidRtmpClient : IRealTimeMultiplayerClient
{
	private class RoomUpdateProxy : AndroidJavaProxy
	{
		private AndroidRtmpClient mOwner;

		internal RoomUpdateProxy(AndroidRtmpClient owner)
			: base("com.google.android.gms.games.multiplayer.realtime.RoomUpdateListener")
		{
			mOwner = owner;
		}

		public void onJoinedRoom(int statusCode, AndroidJavaObject room)
		{
			mOwner.OnJoinedRoom(statusCode, room);
		}

		public void onLeftRoom(int statusCode, AndroidJavaObject room)
		{
			mOwner.OnLeftRoom(statusCode, room);
		}

		public void onRoomConnected(int statusCode, AndroidJavaObject room)
		{
			mOwner.OnRoomConnected(statusCode, room);
		}

		public void onRoomCreated(int statusCode, AndroidJavaObject room)
		{
			mOwner.OnRoomCreated(statusCode, room);
		}
	}

	private class RoomStatusUpdateProxy : AndroidJavaProxy
	{
		private AndroidRtmpClient mOwner;

		internal RoomStatusUpdateProxy(AndroidRtmpClient owner)
			: base("com.google.android.gms.games.multiplayer.realtime.RoomStatusUpdateListener")
		{
			mOwner = owner;
		}

		public void onConnectedToRoom(AndroidJavaObject room)
		{
			mOwner.OnConnectedToRoom(room);
		}

		public void onDisconnectedFromRoom(AndroidJavaObject room)
		{
			mOwner.OnDisconnectedFromRoom(room);
		}

		public void onP2PConnected(string participantId)
		{
			mOwner.OnP2PConnected(participantId);
		}

		public void onP2PDisconnected(string participantId)
		{
			mOwner.OnP2PDisconnected(participantId);
		}

		public void onPeerDeclined(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeerDeclined(room, participantIds);
		}

		public void onPeerInvitedToRoom(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeerInvitedToRoom(room, participantIds);
		}

		public void onPeerJoined(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeerJoined(room, participantIds);
		}

		public void onPeerLeft(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeerLeft(room, participantIds);
		}

		public void onPeersConnected(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeersConnected(room, participantIds);
		}

		public void onPeersDisconnected(AndroidJavaObject room, AndroidJavaObject participantIds)
		{
			mOwner.OnPeersDisconnected(room, participantIds);
		}

		public void onRoomAutoMatching(AndroidJavaObject room)
		{
			mOwner.OnRoomAutoMatching(room);
		}

		public void onRoomConnecting(AndroidJavaObject room)
		{
			mOwner.OnRoomConnecting(room);
		}
	}

	private class RealTimeMessageReceivedProxy : AndroidJavaProxy
	{
		private AndroidRtmpClient mOwner;

		internal RealTimeMessageReceivedProxy(AndroidRtmpClient owner)
			: base("com.google.android.gms.games.multiplayer.realtime.RealTimeMessageReceivedListener")
		{
			mOwner = owner;
		}

		public void onRealTimeMessageReceived(AndroidJavaObject message)
		{
			mOwner.OnRealTimeMessageReceived(message);
		}
	}

	private class SelectOpponentsProxy : AndroidJavaProxy
	{
		private AndroidRtmpClient mOwner;

		internal SelectOpponentsProxy(AndroidRtmpClient owner)
			: base("com.google.example.games.pluginsupport.SelectOpponentsHelperActivity$Listener")
		{
			mOwner = owner;
		}

		public void onSelectOpponentsResult(bool success, AndroidJavaObject opponents, bool hasAutoMatch, AndroidJavaObject autoMatchCriteria)
		{
			mOwner.OnSelectOpponentsResult(success, opponents, hasAutoMatch, autoMatchCriteria);
		}
	}

	private class InvitationInboxProxy : AndroidJavaProxy
	{
		private AndroidRtmpClient mOwner;

		internal InvitationInboxProxy(AndroidRtmpClient owner)
			: base("com.google.example.games.pluginsupport.InvitationInboxHelperActivity$Listener")
		{
			mOwner = owner;
		}

		public void onInvitationInboxResult(bool success, string invitationId)
		{
			mOwner.OnInvitationInboxResult(success, invitationId);
		}

		public void onTurnBasedMatch(AndroidJavaObject match)
		{
			Logger.e("Bug: RTMP proxy got onTurnBasedMatch(). Shouldn't happen. Ignoring.");
		}
	}

	private AndroidClient mClient;

	private AndroidJavaObject mRoom;

	private RealTimeMultiplayerListener mRtmpListener;

	private bool mRtmpActive;

	private bool mLaunchedExternalActivity;

	private bool mDeliveredRoomConnected;

	private bool mLeaveRoomRequested;

	private int mVariant;

	private object mParticipantListsLock = new object();

	private List<Participant> mConnectedParticipants = new List<Participant>();

	private List<Participant> mAllParticipants = new List<Participant>();

	private Participant mSelf;

	private float mAccumulatedProgress;

	private float mLastReportedProgress;

	public AndroidRtmpClient(AndroidClient client)
	{
		mClient = client;
	}

	public void CreateQuickGame(int minOpponents, int maxOpponents, int variant, RealTimeMultiplayerListener listener)
	{
		Logger.d($"AndroidRtmpClient.CreateQuickGame, opponents={minOpponents}-{maxOpponents}, variant={variant}");
		if (!PrepareToCreateRoom("CreateQuickGame", listener))
		{
			return;
		}
		mRtmpListener = listener;
		mVariant = variant;
		mClient.CallClientApi("rtmp create quick game", delegate
		{
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.RtmpUtils");
			@class.CallStatic("createQuickGame", mClient.GHManager.GetApiClient(), minOpponents, maxOpponents, variant, new RoomUpdateProxy(this), new RoomStatusUpdateProxy(this), new RealTimeMessageReceivedProxy(this));
		}, delegate(bool success)
		{
			if (!success)
			{
				FailRoomSetup("Failed to create game because GoogleApiClient was disconnected");
			}
		});
	}

	public void CreateWithInvitationScreen(int minOpponents, int maxOpponents, int variant, RealTimeMultiplayerListener listener)
	{
		Logger.d($"AndroidRtmpClient.CreateWithInvitationScreen, opponents={minOpponents}-{maxOpponents}, variant={variant}");
		if (!PrepareToCreateRoom("CreateWithInvitationScreen", listener))
		{
			return;
		}
		mRtmpListener = listener;
		mVariant = variant;
		mClient.CallClientApi("rtmp create with invitation screen", delegate
		{
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.SelectOpponentsHelperActivity");
			mLaunchedExternalActivity = true;
			@class.CallStatic("launch", true, mClient.GetActivity(), new SelectOpponentsProxy(this), Logger.DebugLogEnabled, minOpponents, maxOpponents);
		}, delegate(bool success)
		{
			if (!success)
			{
				FailRoomSetup("Failed to create game because GoogleApiClient was disconnected");
			}
		});
	}

	public void AcceptFromInbox(RealTimeMultiplayerListener listener)
	{
		Logger.d("AndroidRtmpClient.AcceptFromInbox.");
		if (!PrepareToCreateRoom("AcceptFromInbox", listener))
		{
			return;
		}
		mRtmpListener = listener;
		mClient.CallClientApi("rtmp accept with inbox screen", delegate
		{
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.InvitationInboxHelperActivity");
			mLaunchedExternalActivity = true;
			@class.CallStatic("launch", true, mClient.GetActivity(), new InvitationInboxProxy(this), Logger.DebugLogEnabled);
		}, delegate(bool success)
		{
			if (!success)
			{
				FailRoomSetup("Failed to accept from inbox because GoogleApiClient was disconnected");
			}
		});
	}

	public void AcceptInvitation(string invitationId, RealTimeMultiplayerListener listener)
	{
		Logger.d("AndroidRtmpClient.AcceptInvitation " + invitationId);
		if (!PrepareToCreateRoom("AcceptInvitation", listener))
		{
			return;
		}
		mRtmpListener = listener;
		mClient.ClearInvitationIfFromNotification(invitationId);
		mClient.CallClientApi("rtmp accept invitation", delegate
		{
			Logger.d("Accepting invite via support lib.");
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.RtmpUtils");
			@class.CallStatic("accept", mClient.GHManager.GetApiClient(), invitationId, new RoomUpdateProxy(this), new RoomStatusUpdateProxy(this), new RealTimeMessageReceivedProxy(this));
		}, delegate(bool success)
		{
			if (!success)
			{
				FailRoomSetup("Failed to accept invitation because GoogleApiClient was disconnected");
			}
		});
	}

	public void SendMessage(bool reliable, string participantId, byte[] data)
	{
		SendMessage(reliable, participantId, data, 0, data.Length);
	}

	public void SendMessageToAll(bool reliable, byte[] data)
	{
		SendMessage(reliable, null, data, 0, data.Length);
	}

	public void SendMessageToAll(bool reliable, byte[] data, int offset, int length)
	{
		SendMessage(reliable, null, data, offset, length);
	}

	public void SendMessage(bool reliable, string participantId, byte[] data, int offset, int length)
	{
		Logger.d($"AndroidRtmpClient.SendMessage, reliable={reliable}, participantId={participantId}, data[]={data.Length} bytes, offset={offset}, length={length}");
		if (!CheckConnectedRoom("SendMessage"))
		{
			return;
		}
		if (mSelf != null && mSelf.ParticipantId.Equals(participantId))
		{
			Logger.d("Ignoring request to send message to self, " + participantId);
			return;
		}
		byte[] dataToSend = Misc.GetSubsetBytes(data, offset, length);
		if (participantId == null)
		{
			List<Participant> connectedParticipants = GetConnectedParticipants();
			{
				foreach (Participant item in connectedParticipants)
				{
					if (item.ParticipantId != null && !item.Equals(mSelf))
					{
						SendMessage(reliable, item.ParticipantId, dataToSend, 0, dataToSend.Length);
					}
				}
				return;
			}
		}
		mClient.CallClientApi("send message to " + participantId, delegate
		{
			if (mRoom != null)
			{
				string text = mRoom.Call<string>("getRoomId", new object[0]);
				if (reliable)
				{
					mClient.GHManager.CallGmsApi<int>("games.Games", "RealTimeMultiplayer", "sendReliableMessage", new object[4] { null, dataToSend, text, participantId });
				}
				else
				{
					mClient.GHManager.CallGmsApi<int>("games.Games", "RealTimeMultiplayer", "sendUnreliableMessage", new object[3] { dataToSend, text, participantId });
				}
			}
			else
			{
				Logger.w("Not sending message because real-time room was torn down.");
			}
		}, null);
	}

	public List<Participant> GetConnectedParticipants()
	{
		Logger.d("AndroidRtmpClient.GetConnectedParticipants");
		if (!CheckConnectedRoom("GetConnectedParticipants"))
		{
			return null;
		}
		lock (mParticipantListsLock)
		{
			return mConnectedParticipants;
		}
	}

	public Participant GetParticipant(string id)
	{
		Logger.d("AndroidRtmpClient.GetParticipant: " + id);
		if (!CheckConnectedRoom("GetParticipant"))
		{
			return null;
		}
		List<Participant> list;
		lock (mParticipantListsLock)
		{
			list = mAllParticipants;
		}
		if (list == null)
		{
			Logger.e("RtmpGetParticipant called without a valid room!");
			return null;
		}
		foreach (Participant item in list)
		{
			if (item.ParticipantId.Equals(id))
			{
				return item;
			}
		}
		Logger.e("Participant not found in room! id: " + id);
		return null;
	}

	public Participant GetSelf()
	{
		Logger.d("AndroidRtmpClient.GetSelf");
		if (!CheckConnectedRoom("GetSelf"))
		{
			return null;
		}
		Participant participant;
		lock (mParticipantListsLock)
		{
			participant = mSelf;
		}
		if (participant == null)
		{
			Logger.e("Call to RtmpGetSelf() can only be made when in a room. Returning null.");
		}
		return participant;
	}

	public void LeaveRoom()
	{
		Logger.d("AndroidRtmpClient.LeaveRoom");
		if (mRtmpActive && mRoom == null)
		{
			Logger.w("AndroidRtmpClient.LeaveRoom: waiting for room; deferring leave request.");
			mLeaveRoomRequested = true;
		}
		else
		{
			mClient.CallClientApi("leave room", delegate
			{
				Clear("LeaveRoom called");
			}, null);
		}
	}

	public void OnStop()
	{
		if (mLaunchedExternalActivity)
		{
			Logger.d("OnStop: EXTERNAL ACTIVITY is pending, so not clearing RTMP.");
		}
		else
		{
			Clear("leaving room because game is stopping.");
		}
	}

	public bool IsRoomConnected()
	{
		return mRoom != null && mDeliveredRoomConnected;
	}

	public void DeclineInvitation(string invitationId)
	{
		Logger.d("AndroidRtmpClient.DeclineInvitation " + invitationId);
		mClient.ClearInvitationIfFromNotification(invitationId);
		mClient.CallClientApi("rtmp decline invitation", delegate
		{
			mClient.GHManager.CallGmsApi("games.Games", "RealTimeMultiplayer", "declineInvitation", invitationId);
		}, delegate(bool success)
		{
			if (!success)
			{
				Logger.w("Failed to decline invitation. GoogleApiClient was disconnected");
			}
		});
	}

	private bool PrepareToCreateRoom(string method, RealTimeMultiplayerListener listener)
	{
		if (mRtmpActive)
		{
			Logger.e("Cannot call " + method + " while a real-time game is active.");
			if (listener != null)
			{
				Logger.d("Notifying listener of failure to create room.");
				listener.OnRoomConnected(success: false);
			}
			return false;
		}
		mAccumulatedProgress = 0f;
		mLastReportedProgress = 0f;
		mRtmpListener = listener;
		mRtmpActive = true;
		return true;
	}

	private bool CheckConnectedRoom(string method)
	{
		if (mRoom == null || !mDeliveredRoomConnected)
		{
			Logger.e("Method " + method + " called without a connected room. You must create or join a room AND wait until you get the OnRoomConnected(true) callback.");
			return false;
		}
		return true;
	}

	private void Clear(string reason)
	{
		Logger.d("RtmpClear: clearing RTMP (reason: " + reason + ").");
		if (mRoom != null)
		{
			Logger.d("RtmpClear: Room still active, so leaving room.");
			string text = mRoom.Call<string>("getRoomId", new object[0]);
			Logger.d("RtmpClear: room id to leave is " + text);
			mClient.GHManager.CallGmsApi("games.Games", "RealTimeMultiplayer", "leave", new NoopProxy("com.google.android.gms.games.multiplayer.realtime.RoomUpdateListener"), text);
			Logger.d("RtmpClear: left room.");
			mRoom = null;
		}
		else
		{
			Logger.d("RtmpClear: no room active.");
		}
		if (mDeliveredRoomConnected)
		{
			Logger.d("RtmpClear: looks like we must call the OnLeftRoom() callback.");
			RealTimeMultiplayerListener listener = mRtmpListener;
			if (listener != null)
			{
				Logger.d("Calling OnLeftRoom() callback.");
				PlayGamesHelperObject.RunOnGameThread(delegate
				{
					listener.OnLeftRoom();
				});
			}
		}
		else
		{
			Logger.d("RtmpClear: no need to call OnLeftRoom() callback.");
		}
		mLeaveRoomRequested = false;
		mDeliveredRoomConnected = false;
		mRoom = null;
		mConnectedParticipants = null;
		mAllParticipants = null;
		mSelf = null;
		mRtmpListener = null;
		mVariant = 0;
		mRtmpActive = false;
		mAccumulatedProgress = 0f;
		mLastReportedProgress = 0f;
		mLaunchedExternalActivity = false;
		Logger.d("RtmpClear: RTMP cleared.");
	}

	private string[] SubtractParticipants(List<Participant> a, List<Participant> b)
	{
		List<string> list = new List<string>();
		if (a != null)
		{
			foreach (Participant item in a)
			{
				list.Add(item.ParticipantId);
			}
		}
		if (b != null)
		{
			foreach (Participant item2 in b)
			{
				if (list.Contains(item2.ParticipantId))
				{
					list.Remove(item2.ParticipantId);
				}
			}
		}
		return list.ToArray();
	}

	private void UpdateRoom()
	{
		List<AndroidJavaObject> list = new List<AndroidJavaObject>();
		Logger.d("UpdateRoom: Updating our cached data about the room.");
		string text = mRoom.Call<string>("getRoomId", new object[0]);
		Logger.d("UpdateRoom: room id: " + text);
		Logger.d("UpdateRoom: querying for my player ID.");
		string text2 = mClient.GHManager.CallGmsApi<string>("games.Games", "Players", "getCurrentPlayerId", new object[0]);
		Logger.d("UpdateRoom: my player ID is: " + text2);
		Logger.d("UpdateRoom: querying for my participant ID in the room.");
		string text3 = mRoom.Call<string>("getParticipantId", new object[1] { text2 });
		Logger.d("UpdateRoom: my participant ID is: " + text3);
		AndroidJavaObject androidJavaObject = mRoom.Call<AndroidJavaObject>("getParticipantIds", new object[0]);
		list.Add(androidJavaObject);
		int num = androidJavaObject.Call<int>("size", new object[0]);
		Logger.d("UpdateRoom: # participants: " + num);
		List<Participant> list2 = new List<Participant>();
		List<Participant> list3 = new List<Participant>();
		mSelf = null;
		for (int i = 0; i < num; i++)
		{
			Logger.d("UpdateRoom: querying participant #" + i);
			string text4 = androidJavaObject.Call<string>("get", new object[1] { i });
			Logger.d("UpdateRoom: participant #" + i + " has id: " + text4);
			AndroidJavaObject androidJavaObject2 = mRoom.Call<AndroidJavaObject>("getParticipant", new object[1] { text4 });
			list.Add(androidJavaObject2);
			Participant participant = JavaUtil.ConvertParticipant(androidJavaObject2);
			list3.Add(participant);
			if (participant.ParticipantId.Equals(text3))
			{
				Logger.d("Participant is SELF.");
				mSelf = participant;
			}
			if (participant.IsConnectedToRoom)
			{
				list2.Add(participant);
			}
		}
		if (mSelf == null)
		{
			Logger.e("List of room participants did not include self,  participant id: " + text3 + ", player id: " + text2);
			mSelf = new Participant("?", text3, Participant.ParticipantStatus.Unknown, new Player("?", text2), connectedToRoom: false);
		}
		list2.Sort();
		list3.Sort();
		string[] array;
		string[] array2;
		lock (mParticipantListsLock)
		{
			array = SubtractParticipants(list2, mConnectedParticipants);
			array2 = SubtractParticipants(mConnectedParticipants, list2);
			mConnectedParticipants = list2;
			mAllParticipants = list3;
			Logger.d("UpdateRoom: participant list now has " + mConnectedParticipants.Count + " participants.");
		}
		Logger.d("UpdateRoom: cleanup.");
		foreach (AndroidJavaObject item in list)
		{
			item.Dispose();
		}
		Logger.d("UpdateRoom: newly connected participants: " + array.Length);
		Logger.d("UpdateRoom: newly disconnected participants: " + array2.Length);
		if (mDeliveredRoomConnected)
		{
			if (array.Length > 0 && mRtmpListener != null)
			{
				Logger.d("UpdateRoom: calling OnPeersConnected callback");
				mRtmpListener.OnPeersConnected(array);
			}
			if (array2.Length > 0 && mRtmpListener != null)
			{
				Logger.d("UpdateRoom: calling OnPeersDisconnected callback");
				mRtmpListener.OnPeersDisconnected(array2);
			}
		}
		if (mLeaveRoomRequested)
		{
			Clear("deferred leave-room request");
		}
		if (!mDeliveredRoomConnected)
		{
			DeliverRoomSetupProgressUpdate();
		}
	}

	private void FailRoomSetup(string reason)
	{
		Logger.d("Failing room setup: " + reason);
		RealTimeMultiplayerListener listener = mRtmpListener;
		Clear("Room setup failed: " + reason);
		if (listener != null)
		{
			Logger.d("Invoking callback OnRoomConnected(false) to signal failure.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				listener.OnRoomConnected(success: false);
			});
		}
	}

	private bool CheckRtmpActive(string method)
	{
		if (!mRtmpActive)
		{
			Logger.d("Got call to " + method + " with RTMP inactive. Ignoring.");
			return false;
		}
		return true;
	}

	private void OnJoinedRoom(int statusCode, AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnJoinedRoom, status " + statusCode);
		if (CheckRtmpActive("OnJoinedRoom"))
		{
			mRoom = room;
			mAccumulatedProgress += 20f;
			if (statusCode != 0)
			{
				FailRoomSetup("OnJoinedRoom error code " + statusCode);
			}
		}
	}

	private void OnLeftRoom(int statusCode, AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnLeftRoom, status " + statusCode);
		if (CheckRtmpActive("OnLeftRoom"))
		{
			Clear("Got OnLeftRoom " + statusCode);
		}
	}

	private void OnRoomConnected(int statusCode, AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnRoomConnected, status " + statusCode);
		if (!CheckRtmpActive("OnRoomConnected"))
		{
			return;
		}
		mRoom = room;
		UpdateRoom();
		if (statusCode != 0)
		{
			FailRoomSetup("OnRoomConnected error code " + statusCode);
			return;
		}
		Logger.d("AndroidClient.OnRoomConnected: room setup succeeded!");
		RealTimeMultiplayerListener listener = mRtmpListener;
		if (listener != null)
		{
			Logger.d("Invoking callback OnRoomConnected(true) to report success.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				mDeliveredRoomConnected = true;
				listener.OnRoomConnected(success: true);
			});
		}
	}

	private void OnRoomCreated(int statusCode, AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnRoomCreated, status " + statusCode);
		if (CheckRtmpActive("OnRoomCreated"))
		{
			mRoom = room;
			mAccumulatedProgress += 20f;
			if (statusCode != 0)
			{
				FailRoomSetup("OnRoomCreated error code " + statusCode);
			}
			UpdateRoom();
		}
	}

	private void OnConnectedToRoom(AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnConnectedToRoom");
		if (CheckRtmpActive("OnConnectedToRoom"))
		{
			mAccumulatedProgress += 10f;
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnDisconnectedFromRoom(AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnDisconnectedFromRoom");
		if (CheckRtmpActive("OnDisconnectedFromRoom"))
		{
			Clear("Got OnDisconnectedFromRoom");
		}
	}

	private void OnP2PConnected(string participantId)
	{
		Logger.d("AndroidClient.OnP2PConnected: " + participantId);
		if (CheckRtmpActive("OnP2PConnected"))
		{
			UpdateRoom();
		}
	}

	private void OnP2PDisconnected(string participantId)
	{
		Logger.d("AndroidClient.OnP2PDisconnected: " + participantId);
		if (CheckRtmpActive("OnP2PDisconnected"))
		{
			UpdateRoom();
		}
	}

	private void OnPeerDeclined(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeerDeclined");
		if (CheckRtmpActive("OnPeerDeclined"))
		{
			mRoom = room;
			UpdateRoom();
			if (!mDeliveredRoomConnected)
			{
				FailRoomSetup("OnPeerDeclined received during setup");
			}
		}
	}

	private void OnPeerInvitedToRoom(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeerInvitedToRoom");
		if (CheckRtmpActive("OnPeerInvitedToRoom"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnPeerJoined(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeerJoined");
		if (CheckRtmpActive("OnPeerJoined"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnPeerLeft(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeerLeft");
		if (CheckRtmpActive("OnPeerLeft"))
		{
			mRoom = room;
			UpdateRoom();
			if (!mDeliveredRoomConnected)
			{
				FailRoomSetup("OnPeerLeft received during setup");
			}
		}
	}

	private void OnPeersConnected(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeersConnected");
		if (CheckRtmpActive("OnPeersConnected"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnPeersDisconnected(AndroidJavaObject room, AndroidJavaObject participantIds)
	{
		Logger.d("AndroidClient.OnPeersDisconnected.");
		if (CheckRtmpActive("OnPeersDisconnected"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnRoomAutoMatching(AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnRoomAutoMatching");
		if (CheckRtmpActive("OnRoomAutomatching"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnRoomConnecting(AndroidJavaObject room)
	{
		Logger.d("AndroidClient.OnRoomConnecting.");
		if (CheckRtmpActive("OnRoomConnecting"))
		{
			mRoom = room;
			UpdateRoom();
		}
	}

	private void OnRealTimeMessageReceived(AndroidJavaObject message)
	{
		Logger.d("AndroidClient.OnRealTimeMessageReceived.");
		if (!CheckRtmpActive("OnRealTimeMessageReceived"))
		{
			return;
		}
		RealTimeMultiplayerListener listener = mRtmpListener;
		if (listener != null)
		{
			byte[] messageData;
			using (AndroidJavaObject byteArrayObj = message.Call<AndroidJavaObject>("getMessageData", new object[0]))
			{
				messageData = JavaUtil.ConvertByteArray(byteArrayObj);
			}
			bool isReliable = message.Call<bool>("isReliable", new object[0]);
			string senderId = message.Call<string>("getSenderParticipantId", new object[0]);
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				listener.OnRealTimeMessageReceived(isReliable, senderId, messageData);
			});
		}
		message.Dispose();
	}

	private void OnSelectOpponentsResult(bool success, AndroidJavaObject opponents, bool hasAutoMatch, AndroidJavaObject autoMatchCriteria)
	{
		Logger.d("AndroidRtmpClient.OnSelectOpponentsResult, success=" + success);
		if (!CheckRtmpActive("OnSelectOpponentsResult"))
		{
			return;
		}
		mLaunchedExternalActivity = false;
		if (!success)
		{
			Logger.w("Room setup failed because select-opponents UI failed.");
			FailRoomSetup("Select opponents UI failed.");
			return;
		}
		mClient.CallClientApi("creating room w/ select-opponents result", delegate
		{
			Logger.d("Creating room via support lib's RtmpUtil.");
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.RtmpUtils");
			@class.CallStatic("create", mClient.GHManager.GetApiClient(), opponents, mVariant, (!hasAutoMatch) ? null : autoMatchCriteria, new RoomUpdateProxy(this), new RoomStatusUpdateProxy(this), new RealTimeMessageReceivedProxy(this));
		}, delegate(bool ok)
		{
			if (!ok)
			{
				FailRoomSetup("GoogleApiClient lost connection");
			}
		});
	}

	private void OnInvitationInboxResult(bool success, string invitationId)
	{
		Logger.d("AndroidRtmpClient.OnInvitationInboxResult, success=" + success + ", invitationId=" + invitationId);
		if (!CheckRtmpActive("OnInvitationInboxResult"))
		{
			return;
		}
		mLaunchedExternalActivity = false;
		if (!success || invitationId == null || invitationId.Length == 0)
		{
			Logger.w("Failed to setup room because invitation inbox UI failed.");
			FailRoomSetup("Invitation inbox UI failed.");
			return;
		}
		mClient.ClearInvitationIfFromNotification(invitationId);
		mClient.CallClientApi("accept invite from inbox", delegate
		{
			Logger.d("Accepting invite from inbox via support lib.");
			AndroidJavaClass @class = JavaUtil.GetClass("com.google.example.games.pluginsupport.RtmpUtils");
			@class.CallStatic("accept", mClient.GHManager.GetApiClient(), invitationId, new RoomUpdateProxy(this), new RoomStatusUpdateProxy(this), new RealTimeMessageReceivedProxy(this));
		}, delegate(bool ok)
		{
			if (!ok)
			{
				FailRoomSetup("GoogleApiClient lost connection.");
			}
		});
	}

	private void DeliverRoomSetupProgressUpdate()
	{
		Logger.d("AndroidRtmpClient: DeliverRoomSetupProgressUpdate");
		if (!mRtmpActive || mRoom == null || mDeliveredRoomConnected)
		{
			return;
		}
		float progress = CalcRoomSetupPercentage();
		if (progress < mLastReportedProgress)
		{
			progress = mLastReportedProgress;
		}
		else
		{
			mLastReportedProgress = progress;
		}
		Logger.d("room setup progress: " + progress + "%");
		if (mRtmpListener != null)
		{
			Logger.d("Delivering progress to callback.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				mRtmpListener.OnRoomSetupProgress(progress);
			});
		}
	}

	private float CalcRoomSetupPercentage()
	{
		if (!mRtmpActive || mRoom == null)
		{
			return 0f;
		}
		if (mDeliveredRoomConnected)
		{
			return 100f;
		}
		float num = mAccumulatedProgress;
		if (num > 50f)
		{
			num = 50f;
		}
		float num2 = 100f - num;
		int num3 = ((mAllParticipants != null) ? mAllParticipants.Count : 0);
		int num4 = ((mConnectedParticipants != null) ? mConnectedParticipants.Count : 0);
		if (num3 == 0)
		{
			return num;
		}
		return num + num2 * ((float)num4 / (float)num3);
	}

	internal void OnSignInSucceeded()
	{
	}
}
