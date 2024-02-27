using System;
using Boo.Lang.Runtime;
using UnityEngine;

namespace MerlinAPI;

[Serializable]
public class CurrentInfo
{
	[NonSerialized]
	private const string UUID_KEY = "MD-UUID";

	[NonSerialized]
	private const string OLD_UUID_KEY = "MD-UUID-OLD";

	[NonSerialized]
	private const string NEED_RESTORE_FLAG_KEY = "MD-NEED-RESTORE-FLAG";

	[NonSerialized]
	private const string CREATEDCHAR_KEY = "MD-CreatedChar";

	[NonSerialized]
	private const string SERVER_VERSION_KEY = "MD-SERVER_VERSION";

	[NonSerialized]
	private const string MASTER_VERSION_KEY = "MD-MASTER_VERSION";

	[NonSerialized]
	private const string DATA_VERSION_KEY = "MD-DATA_VERSION";

	[NonSerialized]
	private const string DOWNLOAD_COMPLETED = "MD-DOWNLOAD_COMPLETED";

	[NonSerialized]
	private const string APPVER_ON_LAST_DOWNLOAD = "MD-APPVER_ON_LAST_DOWNLOAD";

	[NonSerialized]
	private const string ANDROID_NOTIFICATION_DEVICE_TOKEN_SENT = "MD-NOTIFICATION-DEVICE-TOKEN-SENT";

	[NonSerialized]
	private static string _token;

	[NonSerialized]
	private static GameApiResponseBase lastResponse;

	public static string ClientVersion => CurrentBuildableVersion.CLIENT_VERSION.ToString();

	public static string DataVersion
	{
		get
		{
			return PlayerPrefs.GetString("MD-DATA_VERSION", "0");
		}
		set
		{
			WritePrefsString("MD-DATA_VERSION", value);
		}
	}

	public static string MasterVersion
	{
		get
		{
			return PlayerPrefs.GetString("MD-MASTER_VERSION", "0");
		}
		set
		{
			WritePrefsString("MD-MASTER_VERSION", value);
		}
	}

	public static bool HasMasterVersion => !string.IsNullOrEmpty(MasterVersion);

	public static bool DownloadCompleted
	{
		get
		{
			return PlayerPrefs.GetInt("MD-DOWNLOAD_COMPLETED", 0) != 0;
		}
		set
		{
			WritePrefsInt("MD-DOWNLOAD_COMPLETED", value ? 1 : 0);
		}
	}

	public static bool IsAppVerDifferedFromLastDownloading
	{
		get
		{
			int cLIENT_VERSION = CurrentBuildableVersion.CLIENT_VERSION;
			int @int = PlayerPrefs.GetInt("MD-APPVER_ON_LAST_DOWNLOAD", -1);
			return cLIENT_VERSION != @int;
		}
	}

	public static string UUID
	{
		get
		{
			return PlayerPrefs.GetString("MD-UUID", null);
		}
		set
		{
			PlayerPrefs.SetString("MD-UUID", value);
			PlayerPrefs.Save();
		}
	}

	public static string Token
	{
		get
		{
			return _token;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new AssertionFailedException("cound not clear access token");
			}
			_token = value;
		}
	}

	public static bool AlreadyCreatedCharacter
	{
		get
		{
			return PlayerPrefs.GetInt("MD-CreatedChar", 0) != 0;
		}
		set
		{
			PlayerPrefs.SetInt("MD-CreatedChar", value ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public static bool HasUUID => !string.IsNullOrEmpty(UUID);

	public static bool HasToken => !string.IsNullOrEmpty(Token);

	public static bool NotCreatedCharacter
	{
		get
		{
			return !AlreadyCreatedCharacter;
		}
		set
		{
			AlreadyCreatedCharacter = !value;
		}
	}

	public static bool AndroidNotificationDeviceTokenSent
	{
		get
		{
			return PlayerPrefs.GetInt("MD-NOTIFICATION-DEVICE-TOKEN-SENT", 0) != 0;
		}
		set
		{
			PlayerPrefs.SetInt("MD-NOTIFICATION-DEVICE-TOKEN-SENT", value ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public static bool NeedRestore
	{
		get
		{
			return PlayerPrefs.GetInt("MD-NEED-RESTORE-FLAG", 0) != 0;
		}
		set
		{
			int value2 = (value ? 1 : 0);
			PlayerPrefs.SetInt("MD-NEED-RESTORE-FLAG", value2);
			PlayerPrefs.Save();
		}
	}

	public static string OldUUID
	{
		get
		{
			return PlayerPrefs.GetString("MD-UUID-OLD", null);
		}
		set
		{
			PlayerPrefs.SetString("MD-UUID-OLD", value);
			PlayerPrefs.Save();
		}
	}

	public static GameApiResponseBase LastGameResponse
	{
		get
		{
			return lastResponse;
		}
		set
		{
			lastResponse = value;
		}
	}

	public static void SetAppVerOnLastDownloadAsCurrentVer()
	{
		WritePrefsInt("MD-APPVER_ON_LAST_DOWNLOAD", CurrentBuildableVersion.CLIENT_VERSION);
	}

	private static void WritePrefsInt(string key, int val)
	{
		PlayerPrefs.SetInt(key, val);
		PlayerPrefs.Save();
	}

	private static void WritePrefsString(string key, string val)
	{
		PlayerPrefs.SetString(key, val);
		PlayerPrefs.Save();
	}

	public static void Clear()
	{
		_token = null;
		AlreadyCreatedCharacter = false;
	}

	public static void ClearDownloadedData()
	{
		MasterVersion = null;
		DataVersion = null;
		DownloadCompleted = false;
		Caching.CleanCache();
	}

	public static void ClearToken()
	{
		_token = null;
	}
}
