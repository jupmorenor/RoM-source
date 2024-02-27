using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Photon.SocketServer.Security;

namespace ExitGames.Client.Photon;

internal abstract class PeerBase
{
	public enum ConnectionStateValue : byte
	{
		Disconnected = 0,
		Connecting = 1,
		Connected = 3,
		Disconnecting = 4,
		AcknowledgingDisconnect = 5,
		Zombie = 6
	}

	internal enum EgMessageType : byte
	{
		Init = 0,
		InitResponse = 1,
		Operation = 2,
		OperationResponse = 3,
		Event = 4,
		InternalOperationRequest = 6,
		InternalOperationResponse = 7
	}

	internal delegate void MyAction();

	internal const int ENET_PEER_PACKET_LOSS_SCALE = 65536;

	internal const int ENET_PEER_DEFAULT_ROUND_TRIP_TIME = 300;

	internal const int ENET_PEER_PACKET_THROTTLE_INTERVAL = 5000;

	public int ByteCountLastOperation;

	public int ByteCountCurrentDispatch;

	internal int TrafficPackageHeaderSize;

	public TrafficStats TrafficStatsIncoming;

	public TrafficStats TrafficStatsOutgoing;

	public TrafficStatsGameLevel TrafficStatsGameLevel;

	private Stopwatch trafficStatsStopwatch;

	private bool trafficStatsEnabled = false;

	internal ConnectionProtocol usedProtocol;

	internal DebugLevel debugOut = DebugLevel.ERROR;

	internal readonly Queue<MyAction> ActionQueue = new Queue<MyAction>();

	internal PhotonPeer.GetLocalMsTimestampDelegate GetLocalMsTimestamp = () => Environment.TickCount;

	internal short peerID = -1;

	internal ConnectionStateValue peerConnectionState;

	internal int serverTimeOffset;

	internal bool serverTimeOffsetIsAvailable;

	internal int roundTripTime;

	internal int roundTripTimeVariance;

	internal int lastRoundTripTime;

	internal int lowestRoundTripTime;

	internal int lastRoundTripTimeVariance;

	internal int highestRoundTripTimeVariance;

	internal int timestampOfLastReceive;

	internal int packetThrottleInterval;

	internal static short peerCount;

	internal long bytesOut;

	internal long bytesIn;

	internal int commandBufferSize = 100;

	internal int warningSize = 100;

	internal int sentCountAllowance = 5;

	internal int DisconnectTimeout = 10000;

	internal int timePingInterval = 1000;

	internal byte ChannelCount = 2;

	internal int limitOfUnreliableCommands = 0;

	public DiffieHellmanCryptoProvider CryptoProvider;

	private readonly Random lagRandomizer = new Random();

	internal readonly LinkedList<SimulationItem> NetSimListOutgoing = new LinkedList<SimulationItem>();

	internal readonly LinkedList<SimulationItem> NetSimListIncoming = new LinkedList<SimulationItem>();

	private readonly NetworkSimulationSet networkSimulationSettings = new NetworkSimulationSet();

	internal byte[] INIT_BYTES = new byte[41];

	internal int timeBase;

	internal int timeInt;

	internal int timeoutInt;

	internal int timeLastAckReceive;

	internal bool ApplicationIsInitialized;

	internal bool isEncryptionAvailable;

	internal static int outgoingStreamBufferSize = 1200;

	internal int outgoingCommandsInStream = 0;

	internal int mtu = 1200;

	protected MemoryStream SerializeMemStream = new MemoryStream();

	public long TrafficStatsEnabledTime => (trafficStatsStopwatch != null) ? trafficStatsStopwatch.ElapsedMilliseconds : 0;

	public bool TrafficStatsEnabled
	{
		get
		{
			return trafficStatsEnabled;
		}
		set
		{
			trafficStatsEnabled = value;
			if (value)
			{
				if (trafficStatsStopwatch == null)
				{
					InitializeTrafficStats();
				}
				trafficStatsStopwatch.Start();
			}
			else
			{
				trafficStatsStopwatch.Stop();
			}
		}
	}

	internal string ServerAddress { get; set; }

	internal string HttpUrlParameters { get; }

	internal IPhotonPeerListener Listener { get; set; }

	public NetworkSimulationSet NetworkSimulationSettings => networkSimulationSettings;

	internal bool IsSendingOnlyAcks { get; }

	internal void InitOnce()
	{
		networkSimulationSettings.peerBase = this;
		INIT_BYTES[0] = 243;
		INIT_BYTES[1] = 0;
		INIT_BYTES[2] = 1;
		INIT_BYTES[3] = 6;
		INIT_BYTES[4] = 1;
		INIT_BYTES[5] = 3;
		INIT_BYTES[6] = 0;
		INIT_BYTES[7] = 1;
		INIT_BYTES[8] = 7;
	}

	internal abstract bool Connect(string serverAddress, string appID, byte nodeId);

	internal abstract void Disconnect();

	internal abstract void FetchServerTimestamp();

	internal bool EnqueueOperation(Dictionary<byte, object> parameters, byte opCode, bool sendReliable, byte channelId, bool encrypted)
	{
		return EnqueueOperation(parameters, opCode, sendReliable, channelId, encrypted, EgMessageType.Operation);
	}

	internal abstract bool EnqueueOperation(Dictionary<byte, object> parameters, byte opCode, bool sendReliable, byte channelId, bool encrypted, EgMessageType messageType);

	internal abstract bool DispatchIncomingCommands();

	internal abstract bool SendOutgoingCommands();

	internal abstract byte[] SerializeOperationToMessage(byte opCode, Dictionary<byte, object> parameters, EgMessageType messageType, bool encrypt);

	internal abstract void ReceiveIncomingCommands(byte[] inBuff);

	internal void InitCallback()
	{
		if (peerConnectionState == ConnectionStateValue.Connecting)
		{
			peerConnectionState = ConnectionStateValue.Connected;
		}
		ApplicationIsInitialized = true;
		FetchServerTimestamp();
		Listener.OnStatusChanged(StatusCode.Connect);
	}

	internal void DeriveSharedKey(OperationResponse operationResponse)
	{
		if (operationResponse.ReturnCode != 0)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "Establishing encryption keys failed. " + operationResponse.ToStringFull());
			EnqueueStatusCallback(StatusCode.EncryptionFailedToEstablish);
			return;
		}
		byte[] array = (byte[])operationResponse[PhotonCodes.ServerKey];
		if (array == null || array.Length == 0)
		{
			EnqueueDebugReturn(DebugLevel.ERROR, "Establishing encryption keys failed. Server's public key is null or empty. " + operationResponse.ToStringFull());
			EnqueueStatusCallback(StatusCode.EncryptionFailedToEstablish);
		}
		else
		{
			CryptoProvider.DeriveSharedKey(array);
			isEncryptionAvailable = true;
			EnqueueStatusCallback(StatusCode.EncryptionEstablished);
		}
	}

	internal void EnqueueActionForDispatch(MyAction action)
	{
		lock (ActionQueue)
		{
			ActionQueue.Enqueue(action);
		}
	}

	internal void EnqueueDebugReturn(DebugLevel level, string debugReturn)
	{
		lock (ActionQueue)
		{
			ActionQueue.Enqueue(delegate
			{
				Listener.DebugReturn(level, debugReturn);
			});
		}
	}

	internal void EnqueueStatusCallback(StatusCode statusValue)
	{
		lock (ActionQueue)
		{
			ActionQueue.Enqueue(delegate
			{
				Listener.OnStatusChanged(statusValue);
			});
		}
	}

	internal virtual void InitPeerBase()
	{
		TrafficStatsIncoming = new TrafficStats(TrafficPackageHeaderSize);
		TrafficStatsOutgoing = new TrafficStats(TrafficPackageHeaderSize);
		TrafficStatsGameLevel = new TrafficStatsGameLevel();
		ByteCountLastOperation = 0;
		ByteCountCurrentDispatch = 0;
		bytesIn = 0L;
		bytesOut = 0L;
		networkSimulationSettings.LostPackagesIn = 0;
		networkSimulationSettings.LostPackagesOut = 0;
		lock (NetSimListOutgoing)
		{
			NetSimListOutgoing.Clear();
		}
		lock (NetSimListIncoming)
		{
			NetSimListIncoming.Clear();
		}
		peerConnectionState = ConnectionStateValue.Disconnected;
		timeBase = GetLocalMsTimestamp();
		isEncryptionAvailable = false;
		ApplicationIsInitialized = false;
		roundTripTime = 300;
		roundTripTimeVariance = 0;
		packetThrottleInterval = 5000;
		serverTimeOffsetIsAvailable = false;
		serverTimeOffset = 0;
	}

	internal virtual bool DeserializeMessageAndCallback(byte[] inBuff)
	{
		if (inBuff.Length < 2)
		{
			if ((int)debugOut >= 1)
			{
				Listener.DebugReturn(DebugLevel.ERROR, "Incoming UDP data too short! " + inBuff.Length);
			}
			return false;
		}
		if (inBuff[0] != 243 && inBuff[0] != 253)
		{
			if ((int)debugOut >= 1)
			{
				Listener.DebugReturn(DebugLevel.ALL, "No regular operation UDP message: " + inBuff[0]);
			}
			return false;
		}
		byte b = (byte)(inBuff[1] & 0x7Fu);
		bool flag = (inBuff[1] & 0x80) > 0;
		MemoryStream memoryStream = null;
		if (b != 1)
		{
			try
			{
				if (flag)
				{
					inBuff = CryptoProvider.Decrypt(inBuff, 2, inBuff.Length - 2);
					memoryStream = new MemoryStream(inBuff);
				}
				else
				{
					memoryStream = new MemoryStream(inBuff);
					memoryStream.Seek(2L, SeekOrigin.Begin);
				}
			}
			catch (Exception ex)
			{
				if ((int)debugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, ex.ToString());
				}
				SupportClass.WriteStackTrace(ex);
				return false;
			}
		}
		int num = 0;
		switch (b)
		{
		case 3:
		{
			OperationResponse operationResponse = Protocol.DeserializeOperationResponse(memoryStream);
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.CountResult(ByteCountCurrentDispatch);
				num = GetLocalMsTimestamp();
			}
			Listener.OnOperationResponse(operationResponse);
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.TimeForResponseCallback(operationResponse.OperationCode, GetLocalMsTimestamp() - num);
			}
			break;
		}
		case 4:
		{
			EventData eventData = Protocol.DeserializeEventData(memoryStream);
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.CountEvent(ByteCountCurrentDispatch);
				num = GetLocalMsTimestamp();
			}
			Listener.OnEvent(eventData);
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.TimeForEventCallback(eventData.Code, GetLocalMsTimestamp() - num);
			}
			break;
		}
		case 1:
			InitCallback();
			break;
		case 7:
		{
			OperationResponse operationResponse = Protocol.DeserializeOperationResponse(memoryStream);
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.CountResult(ByteCountCurrentDispatch);
				num = GetLocalMsTimestamp();
			}
			if (operationResponse.OperationCode == PhotonCodes.InitEncryption)
			{
				DeriveSharedKey(operationResponse);
			}
			else
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "Received unknown internal operation. " + operationResponse.ToStringFull());
			}
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.TimeForResponseCallback(operationResponse.OperationCode, GetLocalMsTimestamp() - num);
			}
			break;
		}
		default:
			EnqueueDebugReturn(DebugLevel.ERROR, "unexpected msgType " + b);
			break;
		}
		return true;
	}

	internal void SendNetworkSimulated(MyAction sendAction)
	{
		if (!NetworkSimulationSettings.IsSimulationEnabled)
		{
			sendAction();
			return;
		}
		if (usedProtocol == ConnectionProtocol.Udp && NetworkSimulationSettings.OutgoingLossPercentage > 0 && lagRandomizer.Next(101) < NetworkSimulationSettings.OutgoingLossPercentage)
		{
			networkSimulationSettings.LostPackagesOut++;
			return;
		}
		int num = ((networkSimulationSettings.OutgoingJitter > 0) ? (lagRandomizer.Next(networkSimulationSettings.OutgoingJitter * 2) - networkSimulationSettings.OutgoingJitter) : 0);
		int num2 = networkSimulationSettings.OutgoingLag + num;
		int num3 = Environment.TickCount + num2;
		SimulationItem simulationItem = new SimulationItem();
		simulationItem.ActionToExecute = sendAction;
		simulationItem.TimeToExecute = num3;
		simulationItem.Delay = num2;
		SimulationItem value = simulationItem;
		lock (NetSimListOutgoing)
		{
			if (NetSimListOutgoing.Count == 0 || usedProtocol == ConnectionProtocol.Tcp)
			{
				NetSimListOutgoing.AddLast(value);
				return;
			}
			LinkedListNode<SimulationItem> linkedListNode = NetSimListOutgoing.First;
			while (linkedListNode != null && linkedListNode.Value.TimeToExecute < num3)
			{
				linkedListNode = linkedListNode.Next;
			}
			if (linkedListNode == null)
			{
				NetSimListOutgoing.AddLast(value);
			}
			else
			{
				NetSimListOutgoing.AddBefore(linkedListNode, value);
			}
		}
	}

	internal void ReceiveNetworkSimulated(MyAction receiveAction)
	{
		if (!networkSimulationSettings.IsSimulationEnabled)
		{
			receiveAction();
			return;
		}
		if (usedProtocol == ConnectionProtocol.Udp && networkSimulationSettings.IncomingLossPercentage > 0 && lagRandomizer.Next(101) < networkSimulationSettings.IncomingLossPercentage)
		{
			networkSimulationSettings.LostPackagesIn++;
			return;
		}
		int num = ((networkSimulationSettings.IncomingJitter > 0) ? (lagRandomizer.Next(networkSimulationSettings.IncomingJitter * 2) - networkSimulationSettings.IncomingJitter) : 0);
		int num2 = networkSimulationSettings.IncomingLag + num;
		int num3 = Environment.TickCount + num2;
		SimulationItem simulationItem = new SimulationItem();
		simulationItem.ActionToExecute = receiveAction;
		simulationItem.TimeToExecute = num3;
		simulationItem.Delay = num2;
		SimulationItem value = simulationItem;
		lock (NetSimListIncoming)
		{
			if (NetSimListIncoming.Count == 0 || usedProtocol == ConnectionProtocol.Tcp)
			{
				NetSimListIncoming.AddLast(value);
				return;
			}
			LinkedListNode<SimulationItem> linkedListNode = NetSimListIncoming.First;
			while (linkedListNode != null && linkedListNode.Value.TimeToExecute < num3)
			{
				linkedListNode = linkedListNode.Next;
			}
			if (linkedListNode == null)
			{
				NetSimListIncoming.AddLast(value);
			}
			else
			{
				NetSimListIncoming.AddBefore(linkedListNode, value);
			}
		}
	}

	protected internal void NetworkSimRun()
	{
		while (true)
		{
			bool flag = true;
			bool flag2 = false;
			lock (networkSimulationSettings.NetSimManualResetEvent)
			{
				flag2 = networkSimulationSettings.IsSimulationEnabled;
			}
			if (!flag2)
			{
				networkSimulationSettings.NetSimManualResetEvent.WaitOne();
				continue;
			}
			lock (NetSimListIncoming)
			{
				SimulationItem simulationItem = null;
				while (NetSimListIncoming.First != null)
				{
					simulationItem = NetSimListIncoming.First.Value;
					if (simulationItem.stopw.ElapsedMilliseconds < simulationItem.Delay)
					{
						break;
					}
					simulationItem.ActionToExecute();
					NetSimListIncoming.RemoveFirst();
				}
			}
			lock (NetSimListOutgoing)
			{
				SimulationItem simulationItem = null;
				while (NetSimListOutgoing.First != null)
				{
					simulationItem = NetSimListOutgoing.First.Value;
					if (simulationItem.stopw.ElapsedMilliseconds < simulationItem.Delay)
					{
						break;
					}
					simulationItem.ActionToExecute();
					NetSimListOutgoing.RemoveFirst();
				}
			}
			Thread.Sleep(0);
		}
	}

	internal void UpdateRoundTripTimeAndVariance(int lastRoundtripTime)
	{
		if (lastRoundtripTime >= 0)
		{
			roundTripTimeVariance -= roundTripTimeVariance / 4;
			if (lastRoundtripTime >= roundTripTime)
			{
				roundTripTime += (lastRoundtripTime - roundTripTime) / 8;
				roundTripTimeVariance += (lastRoundtripTime - roundTripTime) / 4;
			}
			else
			{
				roundTripTime += (lastRoundtripTime - roundTripTime) / 8;
				roundTripTimeVariance -= (lastRoundtripTime - roundTripTime) / 4;
			}
			if (roundTripTime < lowestRoundTripTime)
			{
				lowestRoundTripTime = roundTripTime;
			}
			if (roundTripTimeVariance > highestRoundTripTimeVariance)
			{
				highestRoundTripTimeVariance = roundTripTimeVariance;
			}
		}
	}

	internal void InitializeTrafficStats()
	{
		TrafficStatsIncoming = new TrafficStats(TrafficPackageHeaderSize);
		TrafficStatsOutgoing = new TrafficStats(TrafficPackageHeaderSize);
		TrafficStatsGameLevel = new TrafficStatsGameLevel();
		trafficStatsStopwatch = new Stopwatch();
	}

	internal static EndPoint GetEndpoint(string addressAndPort)
	{
		if (string.IsNullOrEmpty(addressAndPort))
		{
			return null;
		}
		int num = addressAndPort.IndexOf(':');
		if (num < 0)
		{
			return null;
		}
		string hostNameOrAddress = addressAndPort.Substring(0, num);
		int port = short.Parse(addressAndPort.Substring(num + 1));
		IPAddress[] hostAddresses = Dns.GetHostAddresses(hostNameOrAddress);
		IPAddress[] array = hostAddresses;
		foreach (IPAddress iPAddress in array)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				return new IPEndPoint(iPAddress, port);
			}
		}
		return null;
	}
}
