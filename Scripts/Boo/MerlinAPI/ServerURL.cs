using System;
using System.IO;
using System.Text;
using Boo.Lang.Runtime;

namespace MerlinAPI;

[Serializable]
public class ServerURL
{
	[Serializable]
	public class ServerConnectProperty
	{
		public readonly string name;

		public readonly string url;

		public readonly string extHost;

		public readonly bool gzip;

		public readonly bool overSSL;

		private bool _0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024;

		public ServerConnectProperty(string name, string extHost)
		{
			if (!_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024)
			{
				_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024 = true;
			}
			this.name = name;
			url = string.Empty;
			gzip = true;
			this.extHost = extHost;
			overSSL = true;
		}

		public ServerConnectProperty(string name, string url, string extHost, bool gzip)
		{
			if (!_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024)
			{
				_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024 = true;
			}
			this.name = name;
			this.url = url;
			this.gzip = gzip;
			this.extHost = extHost;
		}

		public ServerConnectProperty(string name, string url, string extHost, bool gzip, bool overSSL)
		{
			if (!_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024)
			{
				_0024initialized__MerlinAPI_ServerURL_ServerConnectProperty_0024 = true;
			}
			this.name = name;
			this.url = url;
			this.gzip = gzip;
			this.extHost = extHost;
			this.overSSL = overSSL;
		}
	}

	[NonSerialized]
	public static readonly ServerConnectProperty[] Servers = new ServerConnectProperty[16]
	{
		new ServerConnectProperty("本番A", "pr-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("本番B", "back-pr-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("本番審査", "app-exam-pr-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA01", "01-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA02", "02-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA03", "03-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA04", "04-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA05", "05-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発01", "01-eval-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発02", "02-eval-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発03", "03-eval-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発04", "04-eval-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発05", "05-eval-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("QA00", "00-stg-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("OT環境C面", "app-exam-pr-svc-pfm-meln.riseofmana.com"),
		new ServerConnectProperty("開発06", "06-eval-svc-pfm-meln.riseofmana.com")
	};

	[NonSerialized]
	private static bool currentServerIndexLoaded;

	[NonSerialized]
	public static string PLATFORM_SRV_URL = "01.eval.api.pfm.meln.cloud-config.jp";

	[NonSerialized]
	private static string PLATFORM_SRV_API_BASE = string.Empty;

	[NonSerialized]
	public static string EXAM_VER_SRV_URL = "examversion.riseofmana.com";

	[NonSerialized]
	public const string PLATFORM_EXAM_URL = "review-pr-svc-pfm-meln.riseofmana.com";

	[NonSerialized]
	public static object PLATFORM_URL_BY_EXAMVER;

	[NonSerialized]
	public static string ENTRY_SRV_URL = "entrygamesv.merlindev.cloud-config.jp";

	[NonSerialized]
	private static string ENTRY_SRV_API_BASE = string.Empty;

	[NonSerialized]
	public static string GAME_SRV_URL = "entrygamesv.merlindev.cloud-config.jp";

	[NonSerialized]
	private static string GAME_SRV_API_BASE = "/API";

	[NonSerialized]
	public static string ASSET_SRV_URL = string.Empty;

	[NonSerialized]
	private static readonly int DEFAULT_SERVER_INDEX = 0;

	public static bool IsSSLMode
	{
		get
		{
			ServerConnectProperty[] servers = Servers;
			return servers[RuntimeServices.NormalizeArrayIndex(servers, CurrentServerIndex)].overSSL;
		}
	}

	public static string CurrentServerName
	{
		get
		{
			int currentServerIndex = CurrentServerIndex;
			object result;
			if (0 <= currentServerIndex && currentServerIndex < Servers.Length)
			{
				ServerConnectProperty[] servers = Servers;
				result = servers[RuntimeServices.NormalizeArrayIndex(servers, currentServerIndex)].name;
			}
			else
			{
				result = "??";
			}
			return (string)result;
		}
	}

	private static string SCHEME => (!IsSSLMode) ? "http://" : "https://";

	public static string PLATFORM_AB_URL
	{
		get
		{
			ServerConnectProperty[] servers = Servers;
			return servers[RuntimeServices.NormalizeArrayIndex(servers, 0)].extHost;
		}
	}

	public static bool HasAssetSrvURL => !string.IsNullOrEmpty(ASSET_SRV_URL);

	public static int CurrentServerIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public static string UrlFilter(string url)
	{
		ServerConnectProperty[] servers = Servers;
		ServerConnectProperty serverConnectProperty = servers[RuntimeServices.NormalizeArrayIndex(servers, CurrentServerIndex)];
		if (url.IndexOf("Merlin/ExtServer") < 0 && !string.IsNullOrEmpty(serverConnectProperty.url))
		{
			url = url.Replace("01.", serverConnectProperty.url + ".");
		}
		return url;
	}

	public static string ServerUrl(ServerType type, string path)
	{
		return type switch
		{
			ServerType.ExamVer => ExamVerSrvUrl(path), 
			ServerType.Platform => PlatformApiUrl(path), 
			ServerType.Entry => EntryApiUrl(path), 
			ServerType.Game => GameApiUrl(path), 
			_ => throw new Exception(new StringBuilder("unknown ServerType: ").Append(type).ToString()), 
		};
	}

	public static string AssetSrvUrl(string path)
	{
		if (string.IsNullOrEmpty(ASSET_SRV_URL))
		{
			throw new AssertionFailedException("Merlin/ExtServer 無しにasset serverへのアクセスはできないよ！");
		}
		if (string.IsNullOrEmpty(path))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(path)");
		}
		if (path[0] == '/')
		{
			path = path.Substring(1);
		}
		string aSSET_SRV_URL = ASSET_SRV_URL;
		string rhs = default(string);
		if (aSSET_SRV_URL.Substring(RuntimeServices.NormalizeStringIndex(aSSET_SRV_URL, -1)) != "/")
		{
			rhs = ASSET_SRV_URL + "/";
		}
		return SCHEME + rhs + path;
	}

	public static string ExamVerSrvUrl(string path)
	{
		string eXAM_VER_SRV_URL = EXAM_VER_SRV_URL;
		return (path[0] != '/') ? (SCHEME + eXAM_VER_SRV_URL + "/" + path) : (SCHEME + eXAM_VER_SRV_URL + path);
	}

	public static string PlatformApiUrl(string path)
	{
		string rhs = PLATFORM_SRV_URL;
		object obj = PLATFORM_URL_BY_EXAMVER;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		if (!string.IsNullOrEmpty((string)obj))
		{
			object obj2 = PLATFORM_URL_BY_EXAMVER;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			rhs = (string)obj2;
		}
		else
		{
			ServerConnectProperty[] servers = Servers;
			if (!string.IsNullOrEmpty(servers[RuntimeServices.NormalizeArrayIndex(servers, CurrentServerIndex)].extHost))
			{
				ServerConnectProperty[] servers2 = Servers;
				rhs = servers2[RuntimeServices.NormalizeArrayIndex(servers2, CurrentServerIndex)].extHost;
			}
		}
		return (path[0] != '/') ? (SCHEME + rhs + PLATFORM_SRV_API_BASE + "/" + path) : (SCHEME + rhs + PLATFORM_SRV_API_BASE + path);
	}

	public static string EntryApiUrl(string path)
	{
		string eNTRY_SRV_URL = ENTRY_SRV_URL;
		return (path[0] != '/') ? UrlFilter(SCHEME + eNTRY_SRV_URL + ENTRY_SRV_API_BASE + "/" + path) : UrlFilter(SCHEME + eNTRY_SRV_URL + ENTRY_SRV_API_BASE + path);
	}

	public static string GameApiUrl(string path)
	{
		return GameServerUrl(Path.Combine(GAME_SRV_API_BASE, path));
	}

	public static string GameServerUrl(string path)
	{
		string gAME_SRV_URL = GAME_SRV_URL;
		return string.IsNullOrEmpty(path) ? UrlFilter(SCHEME + gAME_SRV_URL + "/") : ((path[0] != '/') ? UrlFilter(SCHEME + gAME_SRV_URL + "/" + path) : UrlFilter(SCHEME + gAME_SRV_URL + path));
	}
}
