using System;
using System.Text;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;
using UnityEngine;

public class PhotonClient : MonoBehaviour, IPhotonPeerListener
{
	public enum ClientState : byte
	{
		Disconnected,
		Connected,
		InRoom
	}

	public string ServerAddress = "localhost:5055";

	protected string ServerApplication = "Lite";

	public int SendIntervalMs = 100;

	private int NextSendTickCount = Environment.TickCount;

	public ClientState State;

	public int ActorNumber;

	private StringBuilder DebugBuffer = new StringBuilder();

	public bool DebugOutputToConsole = true;

	public string OfflineReason = string.Empty;

	public bool tcpMode;

	public bool enableTrafficStats = true;

	public LitePeer Peer { get; set; }

	public PeerStateValue LitePeerState => Peer.PeerState;

	public string DebugOutput => DebugBuffer.ToString();

	public virtual void Start()
	{
		Peer = new LitePeer(this, tcpMode);
		Peer.TrafficStatsEnabled = enableTrafficStats;
		Connect();
	}

	public virtual void Update()
	{
		if (Environment.TickCount > NextSendTickCount)
		{
			Peer.Service();
			NextSendTickCount = Environment.TickCount + SendIntervalMs;
		}
	}

	public virtual void OnApplicationQuit()
	{
		if (Peer != null)
		{
			Peer.Disconnect();
		}
	}

	protected virtual void Connect()
	{
		OfflineReason = string.Empty;
		Peer.Connect(ServerAddress, ServerApplication);
	}

	public void DebugReturn(DebugLevel level, string message)
	{
		DebugReturn(message);
	}

	public void DebugReturn(string message)
	{
		DebugBuffer.AppendLine(message);
		if (DebugOutputToConsole)
		{
			Debug.Log(message);
		}
	}

	public virtual void OnOperationResponse(OperationResponse operationResponse)
	{
		DebugReturn($"OnOperationResponse: {operationResponse}");
		switch (operationResponse.OperationCode)
		{
		case byte.MaxValue:
			State = ClientState.InRoom;
			ActorNumber = (int)operationResponse[254];
			break;
		case 254:
			State = ClientState.Connected;
			break;
		}
	}

	public virtual void OnStatusChanged(StatusCode statusCode)
	{
		DebugReturn($"OnStatusChanged: {statusCode}");
		switch (statusCode)
		{
		case StatusCode.Connect:
			State = ClientState.Connected;
			break;
		case StatusCode.Disconnect:
			State = ClientState.Disconnected;
			ActorNumber = 0;
			break;
		case StatusCode.ExceptionOnConnect:
			OfflineReason = "Connection failed.\nIs the server online? Firewall open?";
			break;
		case StatusCode.SecurityExceptionOnConnect:
			OfflineReason = "Security Exception on connect.\nMost likely, the policy request failed.\nIs Photon and the Policy App running?";
			break;
		case StatusCode.Exception:
			OfflineReason = "Communication terminated by Exception.\nProbably the server shutdown locally.\nOr the network connection terminated.";
			break;
		case StatusCode.TimeoutDisconnect:
			OfflineReason = "Disconnect due to timeout.\nProbably the server shutdown locally.\nOr the network connection terminated.";
			break;
		case StatusCode.DisconnectByServer:
			OfflineReason = "Timeout Disconnect by server.\nThe server did not get responses in time.";
			break;
		case StatusCode.DisconnectByServerLogic:
			OfflineReason = "Disconnect by server.\nThe servers logic (application) disconnected this client for some reason.";
			break;
		case StatusCode.DisconnectByServerUserLimit:
			OfflineReason = "Server reached it's user limit.\nThe server is currently not accepting connections.\nThe license does not allow it.";
			break;
		default:
			DebugReturn("StatusCode not handled: " + statusCode);
			break;
		}
	}

	public virtual void OnEvent(EventData photonEvent)
	{
		DebugReturn($"OnEvent: {photonEvent}");
	}
}
