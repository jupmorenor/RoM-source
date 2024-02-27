using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ExitGames.Client.Photon;

internal class HttpBase2 : PeerBase
{
	private List<byte[]> incomingList = new List<byte[]>();

	private string HttpPeerID;

	private string UrlParameters;

	private long lastPingTimeStamp;

	internal static readonly byte[] messageHeader = new byte[2] { 243, 2 };

	private List<WWW> webRequests = new List<WWW>();

	private WWW disconnectRequest;

	internal HttpBase2()
	{
		PeerBase.peerCount++;
		InitOnce();
		usedProtocol = ConnectionProtocol.Http;
	}

	internal override bool Connect(string serverAddress, string appID, byte nodeId)
	{
		if (peerConnectionState != 0)
		{
			base.Listener.DebugReturn(DebugLevel.WARNING, "Connect() called while peerConnectionState != Disconnected. Nothing done.");
			return false;
		}
		peerConnectionState = ConnectionStateValue.Connecting;
		base.ServerAddress = serverAddress;
		HttpPeerID = Guid.Empty.ToString();
		UrlParameters = "?init";
		if (appID == null)
		{
			appID = "Lite";
		}
		for (int i = 0; i < 32; i++)
		{
			INIT_BYTES[i + 9] = (byte)((i < appID.Length) ? ((byte)appID[i]) : 0);
		}
		Request(INIT_BYTES, "?init");
		return true;
	}

	internal override void Disconnect()
	{
		if (peerConnectionState == ConnectionStateValue.Disconnected || peerConnectionState == ConnectionStateValue.Disconnecting)
		{
			return;
		}
		peerConnectionState = ConnectionStateValue.Disconnecting;
		foreach (WWW webRequest in webRequests)
		{
			webRequest.Dispose();
		}
		webRequests = new List<WWW>();
		Request(new byte[1] { 1 }, UrlParameters, isDisconnect: true);
	}

	internal void Disconnected()
	{
		InitPeerBase();
		base.Listener.OnStatusChanged(StatusCode.Disconnect);
	}

	internal override void FetchServerTimestamp()
	{
	}

	internal override bool DispatchIncomingCommands()
	{
		while (CheckResult())
		{
		}
		lock (ActionQueue)
		{
			while (ActionQueue.Count > 0)
			{
				MyAction myAction = ActionQueue.Dequeue();
				myAction();
			}
		}
		byte[] array;
		lock (incomingList)
		{
			if (incomingList.Count <= 0)
			{
				return false;
			}
			array = incomingList[0];
			incomingList.RemoveAt(0);
		}
		ByteCountCurrentDispatch = array.Length + 3;
		DeserializeMessageAndCallback(array);
		return false;
	}

	internal override bool SendOutgoingCommands()
	{
		if (peerConnectionState == ConnectionStateValue.Connected && GetLocalMsTimestamp() - lastPingTimeStamp > timePingInterval)
		{
			lastPingTimeStamp = GetLocalMsTimestamp();
			Request(new byte[1], UrlParameters);
		}
		return false;
	}

	internal override bool EnqueueOperation(Dictionary<byte, object> parameters, byte opCode, bool sendReliable, byte channelId, bool encrypted, EgMessageType messageType)
	{
		if (peerConnectionState != ConnectionStateValue.Connected)
		{
			if ((int)debugOut >= 1)
			{
				base.Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: Not connected. PeerState: " + peerConnectionState);
			}
			base.Listener.OnStatusChanged(StatusCode.SendError);
			return false;
		}
		byte[] array = SerializeOperationToMessage(opCode, parameters, messageType, encrypted);
		if (array == null)
		{
			return false;
		}
		Request(array, UrlParameters);
		return true;
	}

	private void EnqueueErrorDisconnect(StatusCode statusCode)
	{
		lock (this)
		{
			if (peerConnectionState != ConnectionStateValue.Connected && peerConnectionState != ConnectionStateValue.Connecting)
			{
				return;
			}
			peerConnectionState = ConnectionStateValue.Disconnecting;
		}
		EnqueueStatusCallback(statusCode);
		EnqueueActionForDispatch(delegate
		{
			Disconnected();
		});
	}

	internal override byte[] SerializeOperationToMessage(byte opCode, Dictionary<byte, object> parameters, EgMessageType messageType, bool encrypt)
	{
		byte[] array;
		lock (SerializeMemStream)
		{
			SerializeMemStream.Position = 0L;
			SerializeMemStream.SetLength(0L);
			if (!encrypt)
			{
				SerializeMemStream.Write(messageHeader, 0, messageHeader.Length);
			}
			Protocol.SerializeOperationRequest(SerializeMemStream, opCode, parameters, setType: false);
			if (encrypt)
			{
				byte[] data = SerializeMemStream.ToArray();
				data = CryptoProvider.Encrypt(data);
				SerializeMemStream.Position = 0L;
				SerializeMemStream.SetLength(0L);
				SerializeMemStream.Write(messageHeader, 0, messageHeader.Length);
				SerializeMemStream.Write(data, 0, data.Length);
			}
			array = SerializeMemStream.ToArray();
		}
		if (messageType != EgMessageType.Operation)
		{
			array[messageHeader.Length - 1] = (byte)messageType;
		}
		if (encrypt)
		{
			array[messageHeader.Length - 1] = (byte)(array[messageHeader.Length - 1] | 0x80u);
		}
		return array;
	}

	internal override void ReceiveIncomingCommands(byte[] inBuff)
	{
		if (peerConnectionState == ConnectionStateValue.Connecting)
		{
			byte[] array = new byte[16];
			Buffer.BlockCopy(inBuff, 0, array, 0, 16);
			HttpPeerID = new Guid(array).ToString();
			UrlParameters = "?pid=" + HttpPeerID;
			peerConnectionState = ConnectionStateValue.Connected;
			EnqueueActionForDispatch(base.InitCallback);
			return;
		}
		timestampOfLastReceive = GetLocalMsTimestamp();
		bytesIn += inBuff.Length + 7;
		if (base.TrafficStatsEnabled)
		{
			TrafficStatsIncoming.TotalPacketCount++;
			TrafficStatsIncoming.TotalCommandsInPackets++;
		}
		if (peerConnectionState == ConnectionStateValue.Disconnecting)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "Received while Disconnecting: " + SupportClass.ByteArrayToString(inBuff));
		}
		if (inBuff.Length <= 0)
		{
			return;
		}
		if (inBuff[0] == 243 || inBuff[0] == 244)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "receiveIncomingCommands() found magic number instead of count. using complete reply as message.");
			incomingList.Add(inBuff);
			return;
		}
		MemoryStream input = new MemoryStream(inBuff);
		using BinaryReader binaryReader = new BinaryReader(input);
		short num = binaryReader.ReadInt16();
		for (int i = 0; i < num; i++)
		{
			int count = binaryReader.ReadInt32();
			byte[] array2 = binaryReader.ReadBytes(count);
			if (array2[0] == 243 || array2[0] == 244)
			{
				lock (incomingList)
				{
					incomingList.Add(array2);
					if (incomingList.Count % warningSize == 0)
					{
						EnqueueStatusCallback(StatusCode.QueueIncomingReliableWarning);
					}
				}
			}
			else if (array2[0] != 240 && (int)debugOut >= 1)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "receiveIncomingCommands() MagicNumber should be 0xF0, 0xF3 or 0xF4. Is: " + inBuff[0]);
			}
		}
	}

	internal void Request(byte[] data, string urlParamter)
	{
		Request(data, urlParamter, isDisconnect: false);
	}

	internal void Request(byte[] data, string urlParamter, bool isDisconnect)
	{
		string text = base.ServerAddress + urlParamter + base.HttpUrlParameters;
		if ((int)debugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "Request() " + text + ". data.Length: " + ((data != null) ? data.Length : 0));
		}
		try
		{
			lastPingTimeStamp = GetLocalMsTimestamp();
			WWW item = new WWW(text, data);
			webRequests.Add(item);
			if (isDisconnect)
			{
				disconnectRequest = item;
			}
		}
		catch (Exception throwable)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "Exception Url: " + text);
			SupportClass.WriteStackTrace(throwable, Console.Out);
			EnqueueErrorDisconnect(StatusCode.Exception);
		}
	}

	internal bool CheckResult()
	{
		if (webRequests == null || webRequests.Count == 0 || !webRequests[0].isDone)
		{
			return false;
		}
		WWW wWW = webRequests[0];
		webRequests.RemoveAt(0);
		if (wWW.error != null)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "WWW request error: " + wWW.error + " URL: " + wWW.url);
			EnqueueErrorDisconnect(StatusCode.Exception);
		}
		else if (wWW == disconnectRequest)
		{
			disconnectRequest = null;
			EnqueueActionForDispatch(delegate
			{
				Disconnected();
			});
		}
		else
		{
			ReceiveIncomingCommands(wWW.bytes);
		}
		return true;
	}
}
