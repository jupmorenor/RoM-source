using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MacroUtil
{
	[Serializable]
	public enum LogType
	{
		All,
		Normal,
		Warning,
		Error,
		Sound,
		Net,
		TestFlight
	}

	[Serializable]
	public class LogEntry
	{
		public LogType type;

		public string message;
	}

	[NonSerialized]
	private static Hash TypeLogs = new Hash();

	[NonSerialized]
	private static readonly int MAXIMUM_MESSAGE_LENGTH = 32768;

	private static void AddLog(LogType type, string msg)
	{
		LogEntry logEntry = new LogEntry();
		LogType logType = (logEntry.type = type);
		string text = (logEntry.message = msg);
		LogEntry log = logEntry;
		AddLog(GetQueue(LogType.All), log);
		AddLog(GetQueue(type), log);
	}

	public static Queue<LogEntry> GetQueue(LogType type)
	{
		Queue<LogEntry> queue;
		if (TypeLogs.Contains(type))
		{
			queue = TypeLogs[type] as Queue<LogEntry>;
		}
		else
		{
			queue = new Queue<LogEntry>();
			TypeLogs[type] = queue;
		}
		return queue;
	}

	private static void AddLog(Queue<LogEntry> q, LogEntry log)
	{
		if (q != null && log != null)
		{
			q.Enqueue(log);
			while (q.Count > 200)
			{
				q.Dequeue();
			}
		}
	}

	public static string truncate(string mes)
	{
		return string.IsNullOrEmpty(mes) ? mes : ((mes.Length > MAXIMUM_MESSAGE_LENGTH) ? mes.Substring(0, MAXIMUM_MESSAGE_LENGTH) : mes);
	}

	public static void Log(LogType type, string src, int line, string msg, object ctxt)
	{
		string lhs = DateStr();
		string text = lhs + " log(" + src + ":" + line + ") :" + msg;
		string message = truncate(text);
		object obj = ctxt;
		if (!(obj is UnityEngine.Object))
		{
			obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
		}
		Debug.Log(message, (UnityEngine.Object)obj);
		AddLog(type, text);
	}

	public static void LogWarning(LogType type, string src, int line, string msg, object ctxt)
	{
		string lhs = DateStr();
		string text = lhs + " logwarn(" + src + ":" + line + ") :" + msg;
		string message = truncate(text);
		object obj = ctxt;
		if (!(obj is UnityEngine.Object))
		{
			obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
		}
		Debug.LogWarning(message, (UnityEngine.Object)obj);
		AddLog(type, text);
	}

	public static void LogError(LogType type, string src, int line, string msg, object ctxt)
	{
		string lhs = DateStr();
		string text = lhs + " logerr(" + src + ":" + line + ") :" + msg;
		string message = truncate(text);
		object obj = ctxt;
		if (!(obj is UnityEngine.Object))
		{
			obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
		}
		Debug.LogError(message, (UnityEngine.Object)obj);
		AddLog(type, text);
	}

	public static string DateStr()
	{
		DateTime now = DateTime.Now;
		return $"{Time.frameCount:00} {now.Hour:00}:{now.Minute:00}:{now.Second:00}";
	}
}
