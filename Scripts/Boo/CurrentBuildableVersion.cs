using System;
using System.Collections;
using System.Text;

[Serializable]
public class CurrentBuildableVersion
{
	[NonSerialized]
	private const string VERSION_DEFINITION_FILE = "./BuildableVersion.json";

	[NonSerialized]
	private const int DVMV_CV_OFFSET = 100000;

	[NonSerialized]
	private static Hashtable cachedJson;

	[NonSerialized]
	private static string prefClientVersion;

	[NonSerialized]
	private static string prefDataVersion;

	[NonSerialized]
	private static string prefMasterVersion;

	public static int CLIENT_VERSION => GetClientVersion();

	public static int DATA_VERSION => GetDataVersion();

	public static int MASTER_VERSION => GetMasterVersion();

	public static void ClearVersionDefinitionCache()
	{
		cachedJson = null;
	}

	public static int GetClientVersion()
	{
		return GetClientVersion(MerlinPlatformModule.CurrentMerlinPlatform());
	}

	public static int GetClientVersion(MerlinPlatform platform)
	{
		string defSymValue = "74";
		return GetVersionNumber(prefClientVersion, defSymValue, "CLIENT_VERSION", platform);
	}

	public static int GetDataVersion()
	{
		return GetDataVersion(MerlinPlatformModule.CurrentMerlinPlatform());
	}

	public static int GetDataVersion(MerlinPlatform platform)
	{
		int rawDataVersion = GetRawDataVersion(platform);
		return (rawDataVersion > 0) ? checked(rawDataVersion + 100000 * GetClientVersion(platform)) : 0;
	}

	public static int GetMasterVersion()
	{
		return GetMasterVersion(MerlinPlatformModule.CurrentMerlinPlatform());
	}

	public static int GetMasterVersion(MerlinPlatform platform)
	{
		int rawMasterVersion = GetRawMasterVersion(platform);
		return (rawMasterVersion > 0) ? checked(rawMasterVersion + 100000 * GetClientVersion(platform)) : 0;
	}

	public static void SetPrefClientVersion(string ver)
	{
		prefClientVersion = ver;
	}

	public static void SetPrefDataVersion(string ver)
	{
		prefDataVersion = ver;
	}

	public static void SetPrefMasterVersion(string ver)
	{
		prefMasterVersion = ver;
	}

	private static int GetRawDataVersion(MerlinPlatform platform)
	{
		string defSymValue = "7400491";
		return GetVersionNumber(prefDataVersion, defSymValue, "DATA_VERSION", platform);
	}

	private static int GetRawMasterVersion(MerlinPlatform platform)
	{
		string defSymValue = "7400490";
		return GetVersionNumber(prefMasterVersion, defSymValue, "MASTER_VERSION", platform);
	}

	private static int GetVersionNumber(string prefVersion, string defSymValue, string keyName, MerlinPlatform platform)
	{
		string empty = string.Empty;
		empty = ((!string.IsNullOrEmpty(prefVersion)) ? prefVersion : (string.IsNullOrEmpty(defSymValue) ? GetVersionFromJson(keyName, platform) : defSymValue));
		int result = 0;
		return (!int.TryParse(empty, out result)) ? result : result;
	}

	private static string GetVersionFromJson(string keyName, MerlinPlatform platform)
	{
		LoadJsonIfNotCached();
		string key = platform.ToString();
		object result;
		if (cachedJson.ContainsKey(key) && cachedJson[key] is Hashtable)
		{
			Hashtable hashtable = cachedJson[key] as Hashtable;
			result = ((!hashtable.ContainsKey(keyName)) ? "0" : new StringBuilder().Append(hashtable[keyName]).ToString());
		}
		else
		{
			result = "0";
		}
		return (string)result;
	}

	private static void LoadJsonIfNotCached()
	{
		if (cachedJson == null)
		{
			cachedJson = new Hashtable();
		}
	}
}
