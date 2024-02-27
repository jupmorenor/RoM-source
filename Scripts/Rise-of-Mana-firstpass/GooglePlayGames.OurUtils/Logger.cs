using UnityEngine;

namespace GooglePlayGames.OurUtils;

public class Logger
{
	private static string LOG_PREF = "[Play Games Plugin DLL] ";

	private static bool debugLogEnabled;

	public static bool DebugLogEnabled
	{
		get
		{
			return debugLogEnabled;
		}
		set
		{
			debugLogEnabled = value;
		}
	}

	public static void d(string msg)
	{
		if (debugLogEnabled)
		{
			Debug.Log(LOG_PREF + msg);
		}
	}

	public static void w(string msg)
	{
		Debug.LogWarning("!!! " + LOG_PREF + " WARNING: " + msg);
	}

	public static void e(string msg)
	{
		Debug.LogWarning("*** " + LOG_PREF + " ERROR: " + msg);
	}

	public static string describe(byte[] b)
	{
		return (b != null) ? ("byte[" + b.Length + "]") : "(null)";
	}
}
