using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon;

internal class EnetPeer : PeerBase
{
	private Dictionary<byte, EnetChannel> channels = new Dictionary<byte, EnetChannel>();

	private List<NCommand> sentReliableCommands = new List<NCommand>();

	private Queue<NCommand> outgoingAcknowledgementsList = new Queue<NCommand>();

	internal readonly int windowSize = 128;

	internal int[] unsequencedWindow;

	internal int outgoingUnsequencedGroupNumber;

	internal int incomingUnsequencedGroupNumber;

	private byte udpCommandCount;

	private byte[] udpBuffer;

	private int udpBufferIndex;

	internal int challenge;

	internal int ReliableCommandsRepeated;

	internal int packetLoss;

	internal int ReliableCommandsSent;

	internal int packetLossEpoch;

	internal int packetLossVariance;

	internal int packetThrottleEpoch;

	internal int serverSentTime;

	internal static readonly byte[] udpHeader0xF3 = new byte[2] { 243, 2 };

	internal static readonly byte[] messageHeader = udpHeader0xF3;

	internal NConnect rt;

	internal EnetPeer()
	{
		PeerBase.peerCount++;
		InitOnce();
		TrafficPackageHeaderSize = 12;
	}

	internal override void InitPeerBase()
	{
		base.InitPeerBase();
		peerID = -1;
		challenge = SupportClass.ThreadSafeRandom.Next();
		ReliableCommandsSent = 0;
		ReliableCommandsRepeated = 0;
		packetLoss = 0;
		lock (channels)
		{
			channels = new Dictionary<byte, EnetChannel>();
		}
		lock (channels)
		{
			channels[byte.MaxValue] = new EnetChannel(byte.MaxValue, commandBufferSize);
			for (byte b = 0; b < ChannelCount; b++)
			{
				channels[b] = new EnetChannel(b, commandBufferSize);
			}
		}
		lock (sentReliableCommands)
		{
			sentReliableCommands = new List<NCommand>(commandBufferSize);
		}
		lock (outgoingAcknowledgementsList)
		{
			outgoingAcknowledgementsList = new Queue<NCommand>(commandBufferSize);
		}
	}

	internal override bool Connect(string ipport, string appID, byte nodeId)
	{
		if (peerConnectionState != 0)
		{
			base.Listener.DebugReturn(DebugLevel.WARNING, "Connect() can't be called if peer is not Disconnected. Not connecting.");
			return false;
		}
		if ((int)debugOut >= 5)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, "Connect()");
		}
		base.ServerAddress = ipport;
		InitPeerBase();
		if (appID == null)
		{
			appID = "Lite";
		}
		for (int i = 0; i < 32; i++)
		{
			INIT_BYTES[i + 9] = (byte)((i < appID.Length) ? ((byte)appID[i]) : 0);
		}
		rt = new NConnect(this, base.ServerAddress);
		if (rt.StartConnection())
		{
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsOutgoing.ControlCommandBytes += 44;
				TrafficStatsOutgoing.ControlCommandCount++;
			}
			peerConnectionState = ConnectionStateValue.Connecting;
			return true;
		}
		return false;
	}

	internal override void Disconnect()
	{
		if (peerConnectionState == ConnectionStateValue.Disconnected || peerConnectionState == ConnectionStateValue.Disconnecting)
		{
			return;
		}
		if ((int)debugOut >= 3)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "Disconnect()");
		}
		if (outgoingAcknowledgementsList != null)
		{
			lock (outgoingAcknowledgementsList)
			{
				outgoingAcknowledgementsList.Clear();
			}
		}
		if (sentReliableCommands != null)
		{
			lock (sentReliableCommands)
			{
				sentReliableCommands.Clear();
			}
		}
		lock (channels)
		{
			foreach (EnetChannel value in channels.Values)
			{
				value.clearAll();
			}
		}
		if (peerConnectionState == ConnectionStateValue.Connected)
		{
			NCommand nCommand = new NCommand(this, 4, null, byte.MaxValue);
			QueueOutgoingReliableCommand(nCommand);
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsOutgoing.CountControlCommand(nCommand.Size);
			}
			SendOutgoingCommands();
			peerConnectionState = ConnectionStateValue.Disconnecting;
		}
		else
		{
			rt.StopConnection();
		}
	}

	internal void Disconnected()
	{
		InitPeerBase();
		base.Listener.OnStatusChanged(StatusCode.Disconnect);
	}

	internal override void FetchServerTimestamp()
	{
		if (peerConnectionState != ConnectionStateValue.Connected)
		{
			if ((int)debugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "FetchServerTimestamp() was skipped, as the client is not connected. Current ConnectionState: " + peerConnectionState);
			}
			base.Listener.OnStatusChanged(StatusCode.SendError);
		}
		else
		{
			CreateAndEnqueueCommand(12, new byte[0], byte.MaxValue);
		}
	}

	internal override bool DispatchIncomingCommands()
	{
		while (true)
		{
			bool flag = true;
			MyAction myAction;
			lock (ActionQueue)
			{
				if (ActionQueue.Count <= 0)
				{
					break;
				}
				myAction = ActionQueue.Dequeue();
				goto IL_0043;
			}
			IL_0043:
			myAction();
		}
		NCommand value = null;
		HashSet<int> hashSet = new HashSet<int>();
		lock (channels)
		{
			foreach (EnetChannel value2 in channels.Values)
			{
				if (value2.incomingUnreliableCommandsList.Count > 0)
				{
					int num = int.MaxValue;
					foreach (int key in value2.incomingUnreliableCommandsList.Keys)
					{
						NCommand nCommand = value2.incomingUnreliableCommandsList[key];
						if (key < value2.incomingUnreliableSequenceNumber || nCommand.reliableSequenceNumber < value2.incomingReliableSequenceNumber)
						{
							hashSet.Add(key);
						}
						else if (limitOfUnreliableCommands > 0 && value2.incomingUnreliableCommandsList.Count > limitOfUnreliableCommands)
						{
							hashSet.Add(key);
						}
						else if (key < num && nCommand.reliableSequenceNumber <= value2.incomingReliableSequenceNumber)
						{
							num = key;
						}
					}
					foreach (int item in hashSet)
					{
						value2.incomingUnreliableCommandsList.Remove(item);
					}
					if (num < int.MaxValue)
					{
						value = value2.incomingUnreliableCommandsList[num];
					}
					if (value != null)
					{
						value2.incomingUnreliableCommandsList.Remove(value.unreliableSequenceNumber);
						value2.incomingUnreliableSequenceNumber = value.unreliableSequenceNumber;
						break;
					}
				}
				if (value != null || value2.incomingReliableCommandsList.Count <= 0)
				{
					continue;
				}
				value2.incomingReliableCommandsList.TryGetValue(value2.incomingReliableSequenceNumber + 1, out value);
				if (value == null)
				{
					continue;
				}
				if (value.commandType != 8)
				{
					value2.incomingReliableSequenceNumber = value.reliableSequenceNumber;
					value2.incomingReliableCommandsList.Remove(value.reliableSequenceNumber);
					break;
				}
				if (value.fragmentsRemaining > 0)
				{
					value = null;
					break;
				}
				byte[] array = new byte[value.totalLength];
				for (int i = value.startSequenceNumber; i < value.startSequenceNumber + value.fragmentCount; i++)
				{
					if (value2.ContainsReliableSequenceNumber(i))
					{
						NCommand nCommand2 = value2.FetchReliableSequenceNumber(i);
						Buffer.BlockCopy(nCommand2.Payload, 0, array, nCommand2.fragmentOffset, nCommand2.Payload.Length);
						value2.incomingReliableCommandsList.Remove(nCommand2.reliableSequenceNumber);
						continue;
					}
					throw new Exception("command.fragmentsRemaining was 0, but not all fragments are found to be combined!");
				}
				if ((int)debugOut >= 5)
				{
					base.Listener.DebugReturn(DebugLevel.ALL, "assembled fragmented payload from " + value.fragmentCount + " parts. Dispatching now.");
				}
				value.Payload = array;
				value.Size = 12 * value.fragmentCount + value.totalLength;
				value2.incomingReliableSequenceNumber = value.reliableSequenceNumber + value.fragmentCount - 1;
				break;
			}
		}
		if (value != null && value.Payload != null)
		{
			ByteCountCurrentDispatch = value.Size;
			if (DeserializeMessageAndCallback(value.Payload))
			{
				return true;
			}
		}
		return false;
	}

	internal override bool SendOutgoingCommands()
	{
		if (peerConnectionState == ConnectionStateValue.Disconnected)
		{
			return false;
		}
		if (!rt.isRunning)
		{
			return false;
		}
		int num = 0;
		udpBuffer = new byte[mtu];
		udpBufferIndex = 12;
		udpCommandCount = 0;
		timeInt = GetLocalMsTimestamp() - timeBase;
		lock (outgoingAcknowledgementsList)
		{
			if (outgoingAcknowledgementsList.Count > 0)
			{
				num = SerializeToBuffer(outgoingAcknowledgementsList);
			}
		}
		if (!base.IsSendingOnlyAcks && timeInt > timeoutInt && sentReliableCommands.Count > 0)
		{
			lock (sentReliableCommands)
			{
				NCommand[] array = new NCommand[sentReliableCommands.Count];
				sentReliableCommands.CopyTo(array);
				NCommand[] array2 = array;
				foreach (NCommand nCommand in array2)
				{
					if (nCommand == null || timeInt - nCommand.commandSentTime <= nCommand.roundTripTimeout)
					{
						continue;
					}
					if (nCommand.commandSentCount > sentCountAllowance || timeInt > nCommand.timeoutTime)
					{
						if ((int)debugOut >= 3)
						{
							base.Listener.DebugReturn(DebugLevel.INFO, string.Concat("Timeout-disconnect! Command: ", nCommand, " now: ", timeInt, " challenge: ", Convert.ToString(challenge, 16)));
						}
						base.Listener.OnStatusChanged(StatusCode.TimeoutDisconnect);
						Disconnected();
						return false;
					}
					QueueOutgoingReliableCommand(nCommand);
					sentReliableCommands.Remove(nCommand);
					ReliableCommandsRepeated++;
					if ((int)debugOut >= 3)
					{
						base.Listener.DebugReturn(DebugLevel.INFO, string.Concat("resending command! ", nCommand, " Now=", timeInt, " Rtt/RttV=", roundTripTime, "/", roundTripTimeVariance, "  command.roundTriptimeOut = ", nCommand.roundTripTimeout, "  lastRoundTripTime=", lastRoundTripTime));
					}
				}
			}
		}
		if (!base.IsSendingOnlyAcks && peerConnectionState == ConnectionStateValue.Connected && sentReliableCommands.Count == 0 && timePingInterval > 0 && timeInt - timeLastAckReceive > timePingInterval && udpBufferIndex + 12 < udpBuffer.Length)
		{
			NCommand nCommand = new NCommand(this, 5, null, byte.MaxValue);
			QueueOutgoingReliableCommand(nCommand);
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsOutgoing.CountControlCommand(nCommand.Size);
			}
		}
		if (!base.IsSendingOnlyAcks)
		{
			lock (channels)
			{
				foreach (EnetChannel value in channels.Values)
				{
					num += SerializeToBuffer(value.outgoingReliableCommandsList);
					num += SerializeToBuffer(value.outgoingUnreliableCommandsList);
				}
			}
		}
		if (udpCommandCount <= 0)
		{
			return false;
		}
		if (base.TrafficStatsEnabled)
		{
			TrafficStatsOutgoing.TotalPacketCount++;
			TrafficStatsOutgoing.TotalCommandsInPackets += udpCommandCount;
		}
		SendData(udpBuffer, udpBufferIndex);
		return num > 0;
	}

	internal override bool EnqueueOperation(Dictionary<byte, object> parameters, byte opCode, bool sendReliable, byte channelId, bool encrypt, EgMessageType messageType)
	{
		if (peerConnectionState != ConnectionStateValue.Connected)
		{
			if ((int)debugOut >= 1)
			{
				base.Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: " + opCode + " Not connected. PeerState: " + peerConnectionState);
			}
			base.Listener.OnStatusChanged(StatusCode.SendError);
			return false;
		}
		if (channelId >= ChannelCount)
		{
			if ((int)debugOut >= 1)
			{
				base.Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: Selected channel (" + channelId + ")>= channelCount (" + ChannelCount + ").");
			}
			base.Listener.OnStatusChanged(StatusCode.SendError);
			return false;
		}
		byte[] payload = SerializeOperationToMessage(opCode, parameters, messageType, encrypt);
		return CreateAndEnqueueCommand((byte)(sendReliable ? 6 : 7), payload, channelId);
	}

	internal bool CreateAndEnqueueCommand(byte commandType, byte[] payload, byte channelNumber)
	{
		if (payload == null)
		{
			return false;
		}
		EnetChannel enetChannel = channels[channelNumber];
		ByteCountLastOperation = 0;
		int num = mtu - 12 - 32;
		if (payload.Length > num)
		{
			int fragmentCount = (payload.Length + num - 1) / num;
			int startSequenceNumber = enetChannel.outgoingReliableSequenceNumber + 1;
			int num2 = 0;
			for (int i = 0; i < payload.Length; i += num)
			{
				if (payload.Length - i < num)
				{
					num = payload.Length - i;
				}
				byte[] array = new byte[num];
				Buffer.BlockCopy(payload, i, array, 0, num);
				NCommand nCommand = new NCommand(this, 8, array, enetChannel.ChannelNumber);
				nCommand.fragmentNumber = num2;
				nCommand.startSequenceNumber = startSequenceNumber;
				nCommand.fragmentCount = fragmentCount;
				nCommand.totalLength = payload.Length;
				nCommand.fragmentOffset = i;
				QueueOutgoingReliableCommand(nCommand);
				ByteCountLastOperation += nCommand.Size;
				if (base.TrafficStatsEnabled)
				{
					TrafficStatsOutgoing.CountFragmentOpCommand(nCommand.Size);
					TrafficStatsGameLevel.CountOperation(nCommand.Size);
				}
				num2++;
			}
		}
		else
		{
			NCommand nCommand = new NCommand(this, commandType, payload, enetChannel.ChannelNumber);
			if (nCommand.commandFlags == 1)
			{
				QueueOutgoingReliableCommand(nCommand);
				ByteCountLastOperation = nCommand.Size;
				if (base.TrafficStatsEnabled)
				{
					TrafficStatsOutgoing.CountReliableOpCommand(nCommand.Size);
					TrafficStatsGameLevel.CountOperation(nCommand.Size);
				}
			}
			else
			{
				QueueOutgoingUnreliableCommand(nCommand);
				ByteCountLastOperation = nCommand.Size;
				if (base.TrafficStatsEnabled)
				{
					TrafficStatsOutgoing.CountUnreliableOpCommand(nCommand.Size);
					TrafficStatsGameLevel.CountOperation(nCommand.Size);
				}
			}
		}
		return true;
	}

	internal override byte[] SerializeOperationToMessage(byte opc, Dictionary<byte, object> parameters, EgMessageType messageType, bool encrypt)
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
			Protocol.SerializeOperationRequest(SerializeMemStream, opc, parameters, setType: false);
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

	internal int SerializeToBuffer(Queue<NCommand> commandList)
	{
		while (commandList.Count > 0)
		{
			NCommand nCommand = commandList.Peek();
			if (nCommand == null)
			{
				commandList.Dequeue();
				continue;
			}
			if (udpBufferIndex + nCommand.Size > udpBuffer.Length)
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "UDP package is full. Commands in Package: " + udpCommandCount + ". Commands left in queue: " + commandList.Count);
				}
				break;
			}
			Buffer.BlockCopy(nCommand.Serialize(), 0, udpBuffer, udpBufferIndex, nCommand.Size);
			udpBufferIndex += nCommand.Size;
			udpCommandCount++;
			if ((nCommand.commandFlags & 1) > 0)
			{
				QueueSentCommand(nCommand);
			}
			commandList.Dequeue();
		}
		return commandList.Count;
	}

	internal void SendData(byte[] data, int length)
	{
		try
		{
			int targetOffset = 0;
			Protocol.Serialize(peerID, data, ref targetOffset);
			data[2] = 0;
			data[3] = udpCommandCount;
			targetOffset = 4;
			Protocol.Serialize(timeInt, data, ref targetOffset);
			Protocol.Serialize(challenge, data, ref targetOffset);
			bytesOut += length;
			if (base.NetworkSimulationSettings.IsSimulationEnabled)
			{
				SendNetworkSimulated(delegate
				{
					rt.SendUdpPackage(data, length);
				});
			}
			else
			{
				rt.SendUdpPackage(data, length);
			}
		}
		catch (Exception ex)
		{
			if ((int)debugOut >= 1)
			{
				base.Listener.DebugReturn(DebugLevel.ERROR, ex.ToString());
			}
			SupportClass.WriteStackTrace(ex, Console.Error);
		}
	}

	internal void QueueSentCommand(NCommand command)
	{
		command.commandSentTime = timeInt;
		command.commandSentCount++;
		if (command.roundTripTimeout == 0)
		{
			command.roundTripTimeout = roundTripTime + 4 * roundTripTimeVariance;
			command.timeoutTime = timeInt + DisconnectTimeout;
		}
		else
		{
			command.roundTripTimeout *= 2;
		}
		lock (sentReliableCommands)
		{
			if (sentReliableCommands.Count == 0)
			{
				timeoutInt = command.commandSentTime + command.roundTripTimeout;
			}
			ReliableCommandsSent++;
			sentReliableCommands.Add(command);
		}
		if (sentReliableCommands.Count >= warningSize && sentReliableCommands.Count % warningSize == 0)
		{
			base.Listener.OnStatusChanged(StatusCode.QueueSentWarning);
		}
	}

	internal void QueueOutgoingReliableCommand(NCommand command)
	{
		EnetChannel enetChannel = channels[command.commandChannelID];
		lock (enetChannel)
		{
			Queue<NCommand> outgoingReliableCommandsList = enetChannel.outgoingReliableCommandsList;
			if (outgoingReliableCommandsList.Count >= warningSize && outgoingReliableCommandsList.Count % warningSize == 0)
			{
				base.Listener.OnStatusChanged(StatusCode.QueueOutgoingReliableWarning);
			}
			if (command.reliableSequenceNumber == 0)
			{
				command.reliableSequenceNumber = ++enetChannel.outgoingReliableSequenceNumber;
			}
			outgoingReliableCommandsList.Enqueue(command);
		}
	}

	internal void QueueOutgoingUnreliableCommand(NCommand command)
	{
		Queue<NCommand> outgoingUnreliableCommandsList = channels[command.commandChannelID].outgoingUnreliableCommandsList;
		if (outgoingUnreliableCommandsList.Count >= warningSize && outgoingUnreliableCommandsList.Count % warningSize == 0)
		{
			base.Listener.OnStatusChanged(StatusCode.QueueOutgoingUnreliableWarning);
		}
		EnetChannel enetChannel = channels[command.commandChannelID];
		command.reliableSequenceNumber = enetChannel.outgoingReliableSequenceNumber;
		command.unreliableSequenceNumber = ++enetChannel.outgoingUnreliableSequenceNumber;
		outgoingUnreliableCommandsList.Enqueue(command);
	}

	internal void QueueOutgoingAcknowledgement(NCommand command)
	{
		lock (outgoingAcknowledgementsList)
		{
			if (outgoingAcknowledgementsList.Count >= warningSize && outgoingAcknowledgementsList.Count % warningSize == 0)
			{
				base.Listener.OnStatusChanged(StatusCode.QueueOutgoingAcksWarning);
			}
			outgoingAcknowledgementsList.Enqueue(command);
		}
	}

	internal override void ReceiveIncomingCommands(byte[] inBuff)
	{
		timestampOfLastReceive = GetLocalMsTimestamp();
		try
		{
			int offset = 0;
			Protocol.Deserialize(out short _, inBuff, ref offset);
			byte b = inBuff[offset++];
			byte b2 = inBuff[offset++];
			Protocol.Deserialize(out serverSentTime, inBuff, ref offset);
			Protocol.Deserialize(out int value2, inBuff, ref offset);
			bytesIn += 12L;
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.TotalPacketCount++;
				TrafficStatsIncoming.TotalCommandsInPackets += b2;
			}
			if (b2 > commandBufferSize)
			{
				EnqueueDebugReturn(DebugLevel.ALL, "too many incoming commands in packet: " + b2 + " > " + commandBufferSize);
			}
			if (value2 != challenge)
			{
				if (peerConnectionState != 0 && (int)debugOut >= 5)
				{
					EnqueueDebugReturn(DebugLevel.ALL, "Info: received package with wrong challenge. challenge in/out:" + value2 + "!=" + challenge + " Commands in it: " + b2);
				}
				return;
			}
			timeInt = GetLocalMsTimestamp() - timeBase;
			for (int i = 0; i < b2; i++)
			{
				NCommand readCommand = new NCommand(this, inBuff, ref offset);
				if (readCommand.commandType != 1)
				{
					EnqueueActionForDispatch(delegate
					{
						ExecuteCommand(readCommand);
					});
				}
				else
				{
					ExecuteCommand(readCommand);
				}
				if ((readCommand.commandFlags & 1) > 0)
				{
					NCommand nCommand = NCommand.CreateAck(this, readCommand, serverSentTime);
					QueueOutgoingAcknowledgement(nCommand);
					if (base.TrafficStatsEnabled)
					{
						TrafficStatsOutgoing.CountControlCommand(nCommand.Size);
					}
				}
			}
		}
		catch (Exception ex)
		{
			if ((int)debugOut >= 1)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, $"Exception while reading commands from incoming data: {ex}");
			}
			SupportClass.WriteStackTrace(ex, Console.Error);
		}
	}

	internal bool ExecuteCommand(NCommand command)
	{
		bool flag = true;
		switch (command.commandType)
		{
		case 2:
		case 5:
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountControlCommand(command.Size);
			}
			break;
		case 4:
		{
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountControlCommand(command.Size);
			}
			StatusCode statusCode = StatusCode.DisconnectByServer;
			if (command.reservedByte == 1)
			{
				statusCode = StatusCode.DisconnectByServerLogic;
			}
			else if (command.reservedByte == 3)
			{
				statusCode = StatusCode.DisconnectByServerUserLimit;
			}
			if ((int)debugOut >= 3)
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "Server sent disconnect. PeerId: " + peerID + " RTT/Variance:" + roundTripTime + "/" + roundTripTimeVariance);
			}
			peerConnectionState = ConnectionStateValue.Disconnecting;
			base.Listener.OnStatusChanged(statusCode);
			rt.StopConnection();
			break;
		}
		case 1:
		{
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountControlCommand(command.Size);
			}
			timeLastAckReceive = timeInt;
			lastRoundTripTime = timeInt - command.ackReceivedSentTime;
			NCommand nCommand = RemoveSentReliableCommand(command.ackReceivedReliableSequenceNumber, command.commandChannelID);
			if (nCommand == null)
			{
				break;
			}
			if (nCommand.commandType == 12)
			{
				if (lastRoundTripTime <= roundTripTime)
				{
					serverTimeOffset = serverSentTime + (lastRoundTripTime >> 1) - GetLocalMsTimestamp();
					serverTimeOffsetIsAvailable = true;
				}
				else
				{
					FetchServerTimestamp();
				}
				break;
			}
			UpdateRoundTripTimeAndVariance(lastRoundTripTime);
			if (nCommand.commandType == 4 && peerConnectionState == ConnectionStateValue.Disconnecting)
			{
				if ((int)debugOut >= 3)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Received disconnect ACK by server");
				}
				EnqueueActionForDispatch(delegate
				{
					rt.StopConnection();
				});
			}
			else if (nCommand.commandType == 2)
			{
				roundTripTime = lastRoundTripTime;
			}
			break;
		}
		case 6:
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountReliableOpCommand(command.Size);
			}
			if (peerConnectionState == ConnectionStateValue.Connected)
			{
				flag = QueueIncomingCommand(command);
			}
			break;
		case 7:
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountUnreliableOpCommand(command.Size);
			}
			if (peerConnectionState == ConnectionStateValue.Connected)
			{
				flag = QueueIncomingCommand(command);
			}
			break;
		case 8:
		{
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountFragmentOpCommand(command.Size);
			}
			if (peerConnectionState != ConnectionStateValue.Connected)
			{
				break;
			}
			if (command.fragmentNumber > command.fragmentCount || command.fragmentOffset >= command.totalLength || command.fragmentOffset + command.Payload.Length > command.totalLength)
			{
				if ((int)debugOut >= 1)
				{
					base.Listener.DebugReturn(DebugLevel.ERROR, "Received fragment has bad size: " + command);
				}
				break;
			}
			flag = QueueIncomingCommand(command);
			if (!flag)
			{
				break;
			}
			EnetChannel enetChannel = channels[command.commandChannelID];
			if (command.reliableSequenceNumber == command.startSequenceNumber)
			{
				command.fragmentsRemaining--;
				int num = command.startSequenceNumber + 1;
				while (command.fragmentsRemaining > 0 && num < command.startSequenceNumber + command.fragmentCount)
				{
					if (enetChannel.ContainsReliableSequenceNumber(num++))
					{
						command.fragmentsRemaining--;
					}
				}
			}
			else if (enetChannel.ContainsReliableSequenceNumber(command.startSequenceNumber))
			{
				NCommand nCommand2 = enetChannel.FetchReliableSequenceNumber(command.startSequenceNumber);
				nCommand2.fragmentsRemaining--;
			}
			break;
		}
		case 3:
			if (base.TrafficStatsEnabled)
			{
				TrafficStatsIncoming.CountControlCommand(command.Size);
			}
			if (peerConnectionState == ConnectionStateValue.Connecting)
			{
				command = new NCommand(this, 6, INIT_BYTES, 0);
				QueueOutgoingReliableCommand(command);
				if (base.TrafficStatsEnabled)
				{
					TrafficStatsOutgoing.CountControlCommand(command.Size);
				}
				peerConnectionState = ConnectionStateValue.Connected;
			}
			break;
		}
		return flag;
	}

	internal bool QueueIncomingCommand(NCommand command)
	{
		EnetChannel value = null;
		channels.TryGetValue(command.commandChannelID, out value);
		if (value == null)
		{
			if ((int)debugOut >= 1)
			{
				base.Listener.DebugReturn(DebugLevel.ERROR, "Received command for non-existing channel: " + command.commandChannelID);
			}
			return false;
		}
		if ((int)debugOut >= 5)
		{
			base.Listener.DebugReturn(DebugLevel.ALL, string.Concat("queueIncomingCommand( ", command, " )  -  incomingReliableSequenceNumber: ", value.incomingReliableSequenceNumber));
		}
		if (command.commandFlags == 1)
		{
			if (command.reliableSequenceNumber <= value.incomingReliableSequenceNumber)
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "incoming command " + command.ToString() + " is old (not saving it). Dispatched incomingReliableSequenceNumber: " + value.incomingReliableSequenceNumber);
				}
				return false;
			}
			if (value.ContainsReliableSequenceNumber(command.reliableSequenceNumber))
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, string.Concat("Info: command was received before! Old/New: ", value.FetchReliableSequenceNumber(command.reliableSequenceNumber), "/", command, " inReliableSeq#: ", value.incomingReliableSequenceNumber));
				}
				return false;
			}
			if (value.incomingReliableCommandsList.Count >= warningSize && value.incomingReliableCommandsList.Count % warningSize == 0)
			{
				base.Listener.OnStatusChanged(StatusCode.QueueIncomingReliableWarning);
			}
			value.incomingReliableCommandsList.Add(command.reliableSequenceNumber, command);
			return true;
		}
		if (command.commandFlags == 0)
		{
			if ((int)debugOut >= 5)
			{
				base.Listener.DebugReturn(DebugLevel.ALL, "unreliable. local: " + value.incomingReliableSequenceNumber + "/" + value.incomingUnreliableSequenceNumber + " incoming: " + command.reliableSequenceNumber + "/" + command.unreliableSequenceNumber);
			}
			if (command.reliableSequenceNumber < value.incomingReliableSequenceNumber)
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "incoming reliable-seq# < Dispatched-rel-seq#. not saved.");
				}
				return true;
			}
			if (command.unreliableSequenceNumber <= value.incomingUnreliableSequenceNumber)
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "incoming unreliable-seq# < Dispatched-unrel-seq#. not saved.");
				}
				return true;
			}
			if (value.ContainsUnreliableSequenceNumber(command.unreliableSequenceNumber))
			{
				if ((int)debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, string.Concat("command was received before! Old/New: ", value.incomingUnreliableCommandsList[command.unreliableSequenceNumber], "/", command));
				}
				return false;
			}
			if (value.incomingUnreliableCommandsList.Count >= warningSize && value.incomingUnreliableCommandsList.Count % warningSize == 0)
			{
				base.Listener.OnStatusChanged(StatusCode.QueueIncomingUnreliableWarning);
			}
			value.incomingUnreliableCommandsList.Add(command.unreliableSequenceNumber, command);
			return true;
		}
		return false;
	}

	internal NCommand RemoveSentReliableCommand(int ackReceivedReliableSequenceNumber, int ackReceivedChannel)
	{
		NCommand nCommand = null;
		lock (sentReliableCommands)
		{
			foreach (NCommand sentReliableCommand in sentReliableCommands)
			{
				if (sentReliableCommand != null && sentReliableCommand.reliableSequenceNumber == ackReceivedReliableSequenceNumber && sentReliableCommand.commandChannelID == ackReceivedChannel)
				{
					nCommand = sentReliableCommand;
					break;
				}
			}
			if (nCommand != null)
			{
				sentReliableCommands.Remove(nCommand);
				if (sentReliableCommands.Count > 0)
				{
					timeoutInt = sentReliableCommands[0].commandSentTime + sentReliableCommands[0].roundTripTimeout;
				}
			}
			else if ((int)debugOut >= 5 && peerConnectionState != ConnectionStateValue.Connected && peerConnectionState != ConnectionStateValue.Disconnecting)
			{
				base.Listener.DebugReturn(DebugLevel.ALL, $"No sent command for ACK (Ch: {ackReceivedReliableSequenceNumber} Sq#: {ackReceivedChannel}). PeerState: {peerConnectionState}.");
			}
		}
		return nCommand;
	}
}
