using System;

namespace ExitGames.Client.Photon;

public class TrafficStatsGameLevel
{
	private int timeOfLastDispatchCall;

	private int timeOfLastSendCall;

	public int OperationByteCount { get; internal set; }

	public int OperationCount { get; internal set; }

	public int ResultByteCount { get; internal set; }

	public int ResultCount { get; internal set; }

	public int EventByteCount { get; internal set; }

	public int EventCount { get; internal set; }

	public int LongestOpResponseCallback { get; internal set; }

	public byte LongestOpResponseCallbackOpCode { get; internal set; }

	public int LongestEventCallback { get; internal set; }

	public byte LongestEventCallbackCode { get; internal set; }

	public int LongestDeltaBetweenDispatching { get; internal set; }

	public int LongestDeltaBetweenSending { get; internal set; }

	public int DispatchCalls { get; internal set; }

	public int SendOutgoingCommandsCalls { get; internal set; }

	public int TotalMessageCount => OperationCount + ResultCount + EventCount;

	public int TotalIncomingMessageCount => ResultCount + EventCount;

	public int TotalOutgoingMessageCount => OperationCount;

	internal void CountOperation(int operationBytes)
	{
		OperationByteCount += operationBytes;
		OperationCount++;
	}

	internal void CountResult(int resultBytes)
	{
		ResultByteCount += resultBytes;
		ResultCount++;
	}

	internal void CountEvent(int eventBytes)
	{
		EventByteCount += eventBytes;
		EventCount++;
	}

	internal void TimeForResponseCallback(byte code, int time)
	{
		if (time > LongestOpResponseCallback)
		{
			LongestOpResponseCallback = time;
			LongestOpResponseCallbackOpCode = code;
		}
	}

	internal void TimeForEventCallback(byte code, int time)
	{
		if (time > LongestOpResponseCallback)
		{
			LongestEventCallback = time;
			LongestEventCallbackCode = code;
		}
	}

	internal void DispatchIncomingCommandsCalled()
	{
		if (timeOfLastDispatchCall != 0)
		{
			int num = Environment.TickCount - timeOfLastDispatchCall;
			if (num > LongestDeltaBetweenDispatching)
			{
				LongestDeltaBetweenDispatching = num;
			}
		}
		DispatchCalls++;
		timeOfLastDispatchCall = Environment.TickCount;
	}

	internal void SendOutgoingCommandsCalled()
	{
		if (timeOfLastSendCall != 0)
		{
			int num = Environment.TickCount - timeOfLastSendCall;
			if (num > LongestDeltaBetweenSending)
			{
				LongestDeltaBetweenSending = num;
			}
		}
		SendOutgoingCommandsCalls++;
		timeOfLastSendCall = Environment.TickCount;
	}

	public override string ToString()
	{
		return $"OperationByteCount: {OperationByteCount} ResultByteCount: {ResultByteCount} EventByteCount: {EventByteCount}";
	}
}
