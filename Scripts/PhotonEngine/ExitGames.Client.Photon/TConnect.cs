using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Threading;

namespace ExitGames.Client.Photon;

internal class TConnect
{
	internal const int TCP_HEADER_BYTES = 7;

	private const int MSG_HEADER_BYTES = 2;

	private const int ALL_HEADER_BYTES = 9;

	private EndPoint serverEndPoint;

	internal bool obsolete;

	internal bool isRunning;

	internal TPeer peer;

	private Socket socketConnection;

	internal TConnect(TPeer npeer, string ipPort)
	{
		if ((int)npeer.debugOut >= 5)
		{
			npeer.Listener.DebugReturn(DebugLevel.ALL, "new TConnect()");
		}
		peer = npeer;
	}

	internal bool StartConnection()
	{
		if (isRunning)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, "startConnectionThread() failed: connection thread still running.");
			}
			return false;
		}
		socketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socketConnection.NoDelay = true;
		new Thread(Run).Start();
		return true;
	}

	internal void StopConnection()
	{
		if ((int)peer.debugOut >= 5)
		{
			peer.Listener.DebugReturn(DebugLevel.ALL, "StopConnection()");
		}
		obsolete = true;
		if (socketConnection != null)
		{
			socketConnection.Close();
		}
	}

	public void sendTcp(byte[] opData)
	{
		if (obsolete)
		{
			if ((int)peer.debugOut >= 3)
			{
				peer.Listener.DebugReturn(DebugLevel.INFO, "Sending was skipped because connection is obsolete. " + Environment.StackTrace);
			}
			return;
		}
		try
		{
			socketConnection.Send(opData);
		}
		catch (NullReferenceException ex)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, ex.Message);
			}
		}
		catch (SocketException ex2)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, ex2.Message);
			}
		}
	}

	public void Run()
	{
		try
		{
			serverEndPoint = PeerBase.GetEndpoint(peer.ServerAddress);
			if (serverEndPoint == null)
			{
				if ((int)peer.debugOut >= 1)
				{
					peer.Listener.DebugReturn(DebugLevel.ERROR, "StartConnection() failed. Address must be 'address:port'. Is: " + peer.ServerAddress);
				}
				return;
			}
			socketConnection.Connect(serverEndPoint);
		}
		catch (SecurityException ex)
		{
			if ((int)peer.debugOut >= 3)
			{
				peer.Listener.DebugReturn(DebugLevel.INFO, "Connect() failed: " + ex.ToString());
			}
			if (socketConnection != null)
			{
				socketConnection.Close();
			}
			isRunning = false;
			obsolete = true;
			peer.EnqueueStatusCallback(StatusCode.ExceptionOnConnect);
			peer.EnqueueActionForDispatch(delegate
			{
				peer.Disconnected();
			});
			return;
		}
		catch (SocketException ex2)
		{
			if ((int)peer.debugOut >= 3)
			{
				peer.Listener.DebugReturn(DebugLevel.INFO, "Connect() failed: " + ex2.ToString());
			}
			if (socketConnection != null)
			{
				socketConnection.Close();
			}
			isRunning = false;
			obsolete = true;
			peer.EnqueueStatusCallback(StatusCode.ExceptionOnConnect);
			peer.EnqueueActionForDispatch(delegate
			{
				peer.Disconnected();
			});
			return;
		}
		obsolete = false;
		byte[] array = null;
		if (peer.ProxyNodeId > 0)
		{
			int i = 0;
			byte[] array2;
			for (array2 = new byte[2]; i < 2; i += socketConnection.Receive(array2, i, 2 - i, SocketFlags.None))
			{
			}
			if (array2[0] == 241)
			{
				peer.ReceiveProxyResponse(array2[1]);
			}
			else
			{
				if ((int)peer.debugOut >= 1)
				{
					peer.EnqueueDebugReturn(DebugLevel.ERROR, string.Format("Routing response did not start with: {0:x} but with: {1:x}" + 241, array2[1]));
				}
				array = array2;
			}
		}
		isRunning = true;
		while (!obsolete)
		{
			MemoryStream opCollectionStream = new MemoryStream(256);
			try
			{
				int i = 0;
				byte[] inBuff = new byte[9];
				if (array != null)
				{
					i = 2;
					inBuff[0] = array[0];
					inBuff[1] = array[1];
					array = null;
				}
				while (i < 9)
				{
					i += socketConnection.Receive(inBuff, i, 9 - i, SocketFlags.None);
					if (i == 0)
					{
						peer.SendPing();
						Thread.Sleep(100);
					}
				}
				if (inBuff[0] == 240)
				{
					if (peer.TrafficStatsEnabled)
					{
						peer.TrafficStatsIncoming.CountControlCommand(inBuff.Length);
					}
					if (peer.NetworkSimulationSettings.IsSimulationEnabled)
					{
						peer.ReceiveNetworkSimulated(delegate
						{
							peer.ReceiveIncomingCommands(inBuff);
						});
					}
					else
					{
						peer.ReceiveIncomingCommands(inBuff);
					}
					continue;
				}
				int num = (inBuff[1] << 24) | (inBuff[2] << 16) | (inBuff[3] << 8) | inBuff[4];
				if (peer.TrafficStatsEnabled)
				{
					if (inBuff[5] == 0)
					{
						peer.TrafficStatsIncoming.CountReliableOpCommand(num);
					}
					else
					{
						peer.TrafficStatsIncoming.CountUnreliableOpCommand(num);
					}
				}
				if ((int)peer.debugOut >= 5)
				{
					peer.EnqueueDebugReturn(DebugLevel.ALL, "message length: " + num);
				}
				opCollectionStream.Write(inBuff, 7, i - 7);
				i = 0;
				num -= 9;
				for (inBuff = new byte[num]; i < num; i += socketConnection.Receive(inBuff, i, num - i, SocketFlags.None))
				{
				}
				opCollectionStream.Write(inBuff, 0, i);
				if (opCollectionStream.Length > 0)
				{
					if (peer.NetworkSimulationSettings.IsSimulationEnabled)
					{
						peer.ReceiveNetworkSimulated(delegate
						{
							peer.ReceiveIncomingCommands(opCollectionStream.ToArray());
						});
					}
					else
					{
						peer.ReceiveIncomingCommands(opCollectionStream.ToArray());
					}
				}
				if ((int)peer.debugOut >= 5)
				{
					peer.EnqueueDebugReturn(DebugLevel.ALL, "TCP < " + opCollectionStream.Length);
				}
			}
			catch (SocketException ex3)
			{
				if (!obsolete)
				{
					obsolete = true;
					if ((int)peer.debugOut >= 1)
					{
						peer.EnqueueDebugReturn(DebugLevel.ERROR, "Receiving failed. SocketException: " + ex3.SocketErrorCode);
					}
					switch (ex3.SocketErrorCode)
					{
					case SocketError.ConnectionAborted:
					case SocketError.ConnectionReset:
						peer.EnqueueStatusCallback(StatusCode.DisconnectByServer);
						break;
					default:
						peer.EnqueueStatusCallback(StatusCode.Exception);
						break;
					}
				}
			}
			catch (Exception ex4)
			{
				if (!obsolete && (int)peer.debugOut >= 1)
				{
					peer.EnqueueDebugReturn(DebugLevel.ERROR, "Receiving failed. Exception: " + ex4.ToString());
				}
			}
		}
		if (socketConnection != null)
		{
			socketConnection.Close();
		}
		isRunning = false;
		obsolete = true;
		peer.EnqueueActionForDispatch(delegate
		{
			peer.Disconnected();
		});
	}
}
