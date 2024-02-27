using System;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Threading;

namespace ExitGames.Client.Photon;

internal class NConnect
{
	private IPAddress serverIpAddress = null;

	private int serverPort;

	internal bool obsolete;

	internal bool isRunning;

	internal EnetPeer peer;

	private Socket sock;

	private object syncer = new object();

	internal NConnect(EnetPeer npeer, string ipPort)
	{
		if ((int)npeer.debugOut >= 5)
		{
			npeer.Listener.DebugReturn(DebugLevel.ALL, "new NConnect UDP.");
		}
		peer = npeer;
		int num = ipPort.IndexOf(':');
		string text = ipPort.Substring(0, num);
		serverPort = short.Parse(ipPort.Substring(num + 1));
		if ((int)npeer.debugOut >= 3)
		{
			peer.Listener.DebugReturn(DebugLevel.INFO, "Remote IP: " + text + ":" + serverPort);
		}
		sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		try
		{
			serverIpAddress = IPAddress.Parse(text);
		}
		catch (FormatException)
		{
		}
		if (serverIpAddress != null)
		{
			return;
		}
		try
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(text);
			IPAddress[] addressList = hostEntry.AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					serverIpAddress = iPAddress;
					break;
				}
			}
		}
		catch (Exception ex2)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, "Dns.GetHostEntry(" + text + ") failed: " + ex2.ToString());
			}
		}
	}

	internal bool StartConnection()
	{
		if (isRunning)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, "StartConnection() failed: connection still open.");
			}
			return false;
		}
		try
		{
			lock (syncer)
			{
				sock.Connect(serverIpAddress, serverPort);
			}
		}
		catch (SecurityException ex)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, "Connect() failed: " + ex.ToString());
			}
			peer.Listener.OnStatusChanged(StatusCode.SecurityExceptionOnConnect);
			peer.Listener.OnStatusChanged(StatusCode.Disconnect);
			return false;
		}
		catch (Exception ex2)
		{
			if ((int)peer.debugOut >= 1)
			{
				peer.Listener.DebugReturn(DebugLevel.ERROR, "Connect() failed: " + ex2.ToString());
			}
			peer.Listener.OnStatusChanged(StatusCode.ExceptionOnConnect);
			peer.Listener.OnStatusChanged(StatusCode.Disconnect);
			return false;
		}
		obsolete = false;
		new Thread(Run).Start();
		return true;
	}

	internal void StopConnection()
	{
		if ((int)peer.debugOut >= 3)
		{
			peer.Listener.DebugReturn(DebugLevel.INFO, "StopConnection()");
		}
		lock (syncer)
		{
			obsolete = true;
			sock.Close();
		}
	}

	internal void SendUdpPackage(byte[] data, int length)
	{
		lock (syncer)
		{
			if (!sock.Connected)
			{
				return;
			}
			try
			{
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch
			{
				try
				{
					sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					sock.Connect(serverIpAddress, serverPort);
				}
				catch
				{
					peer.EnqueueDebugReturn(DebugLevel.ERROR, "Cannot send or create replacement socket. Connection will terminate.");
					return;
				}
				peer.EnqueueDebugReturn(DebugLevel.WARNING, "Successfully created replacement socket cause send failed once.");
				sock.Send(data, 0, length, SocketFlags.None);
			}
		}
	}

	public void Run()
	{
		peer.QueueOutgoingReliableCommand(new NCommand(peer, 2, null, byte.MaxValue));
		isRunning = true;
		while (!obsolete)
		{
			try
			{
				while (sock.Available <= 0)
				{
					Thread.Sleep(1);
				}
				byte[] inBuffer;
				lock (syncer)
				{
					inBuffer = new byte[sock.Available];
					sock.Receive(inBuffer);
				}
				if (peer.NetworkSimulationSettings.IsSimulationEnabled)
				{
					peer.ReceiveNetworkSimulated(delegate
					{
						peer.ReceiveIncomingCommands(inBuffer);
					});
				}
				else
				{
					peer.ReceiveIncomingCommands(inBuffer);
				}
			}
			catch (Exception ex)
			{
				if (!obsolete)
				{
					if ((int)peer.debugOut >= 1)
					{
						peer.EnqueueDebugReturn(DebugLevel.ERROR, "Error trying to receive. Exception: " + ex);
					}
					peer.EnqueueStatusCallback(StatusCode.Exception);
				}
				obsolete = true;
			}
		}
		if (sock != null)
		{
			lock (syncer)
			{
				sock.Close();
			}
		}
		isRunning = false;
		obsolete = true;
		peer.EnqueueActionForDispatch(delegate
		{
			peer.Disconnected();
		});
	}
}
