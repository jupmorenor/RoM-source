using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon;

public class PhotonPeer
{
	public delegate int GetLocalMsTimestampDelegate();

	internal static short peerCount;

	internal PeerBase peerBase;

	private readonly object SendOutgoingLockObject = new object();

	private readonly object DispatchLockObject = new object();

	private readonly object EnqueueLock = new object();

	protected IPhotonPeerListener Listener
	{
		set
		{
			peerBase.Listener = value;
		}
	}

	public bool TrafficStatsEnabled
	{
		get
		{
			return peerBase.TrafficStatsEnabled;
		}
		set
		{
			peerBase.TrafficStatsEnabled = value;
		}
	}

	public long TrafficStatsElapsedMs => peerBase.TrafficStatsEnabledTime;

	public TrafficStats TrafficStatsIncoming => peerBase.TrafficStatsIncoming;

	public TrafficStats TrafficStatsOutgoing => peerBase.TrafficStatsOutgoing;

	public TrafficStatsGameLevel TrafficStatsGameLevel => peerBase.TrafficStatsGameLevel;

	public PeerStateValue PeerState
	{
		get
		{
			if (peerBase.peerConnectionState == PeerBase.ConnectionStateValue.Connected && !peerBase.ApplicationIsInitialized)
			{
				return PeerStateValue.InitializingApplication;
			}
			return (PeerStateValue)peerBase.peerConnectionState;
		}
	}

	public int TimePingInterval => peerBase.timePingInterval;

	public int ServerTimeInMilliSeconds => peerBase.serverTimeOffsetIsAvailable ? (peerBase.serverTimeOffset + LocalTimeInMilliSeconds) : 0;

	public int LocalTimeInMilliSeconds => peerBase.GetLocalMsTimestamp();

	public int RoundTripTime => peerBase.roundTripTime;

	public int RoundTripTimeVariance => peerBase.roundTripTimeVariance;

	public ConnectionProtocol UsedProtocol => peerBase.usedProtocol;

	public virtual bool IsSimulationEnabled
	{
		get
		{
			return NetworkSimulationSettings.IsSimulationEnabled;
		}
		set
		{
			if (value == NetworkSimulationSettings.IsSimulationEnabled)
			{
				return;
			}
			lock (SendOutgoingLockObject)
			{
				NetworkSimulationSettings.IsSimulationEnabled = value;
			}
		}
	}

	public NetworkSimulationSet NetworkSimulationSettings => peerBase.NetworkSimulationSettings;

	protected internal PhotonPeer(ConnectionProtocol protocolType)
	{
		switch (protocolType)
		{
		case ConnectionProtocol.Tcp:
			peerBase = new TPeer();
			peerBase.usedProtocol = protocolType;
			break;
		case ConnectionProtocol.Udp:
			peerBase = new EnetPeer();
			peerBase.usedProtocol = protocolType;
			break;
		case ConnectionProtocol.Http:
			peerBase = new HttpBase2();
			peerBase.usedProtocol = protocolType;
			break;
		}
	}

	public PhotonPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
		: this(protocolType)
	{
		if (listener == null)
		{
			throw new SystemException("listener cannot be null");
		}
		Listener = listener;
	}

	[Obsolete("Use the constructor with ConnectionProtocol instead.")]
	public PhotonPeer(IPhotonPeerListener listener, bool useTcp)
		: this(listener, useTcp ? ConnectionProtocol.Tcp : ConnectionProtocol.Udp)
	{
	}

	public void TrafficStatsReset()
	{
		peerBase.InitializeTrafficStats();
		peerBase.TrafficStatsEnabled = true;
	}

	public virtual bool Connect(string serverAddress, string applicationName)
	{
		lock (DispatchLockObject)
		{
			lock (SendOutgoingLockObject)
			{
				return peerBase.Connect(serverAddress, applicationName, 0);
			}
		}
	}

	public virtual void Disconnect()
	{
		lock (DispatchLockObject)
		{
			lock (SendOutgoingLockObject)
			{
				peerBase.Disconnect();
			}
		}
	}

	public virtual void Service()
	{
		while (DispatchIncomingCommands())
		{
		}
		while (SendOutgoingCommands())
		{
		}
	}

	public virtual bool SendOutgoingCommands()
	{
		if (TrafficStatsEnabled)
		{
			TrafficStatsGameLevel.SendOutgoingCommandsCalled();
		}
		lock (SendOutgoingLockObject)
		{
			return peerBase.SendOutgoingCommands();
		}
	}

	public virtual bool DispatchIncomingCommands()
	{
		peerBase.ByteCountCurrentDispatch = 0;
		if (TrafficStatsEnabled)
		{
			TrafficStatsGameLevel.DispatchIncomingCommandsCalled();
		}
		lock (DispatchLockObject)
		{
			return peerBase.DispatchIncomingCommands();
		}
	}

	public virtual bool OpCustom(byte customOpCode, Dictionary<byte, object> customOpParameters, bool sendReliable)
	{
		return OpCustom(customOpCode, customOpParameters, sendReliable, 0);
	}

	public virtual bool OpCustom(byte customOpCode, Dictionary<byte, object> customOpParameters, bool sendReliable, byte channelId)
	{
		lock (EnqueueLock)
		{
			return peerBase.EnqueueOperation(customOpParameters, customOpCode, sendReliable, channelId, encrypted: false);
		}
	}
}
