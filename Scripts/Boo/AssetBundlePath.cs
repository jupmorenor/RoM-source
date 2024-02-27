using System;
using System.IO;
using System.Text;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class AssetBundlePath
{
	[NonSerialized]
	private const string BLOB_CONTAINER = "sva";

	[NonSerialized]
	private static readonly string BLOB_DATA_PATH = new StringBuilder().Append("sva").Append("/data/").ToString();

	[NonSerialized]
	public static string CLIENT_MASTER_FILENAME_PREFIX = "master-";

	[NonSerialized]
	private static string CLIENT_MASTER_FILENAME_FMT = CLIENT_MASTER_FILENAME_PREFIX + "m{0}.zip";

	[NonSerialized]
	private static string ASSET_BUNDLE_ROUTING_FILE_NAME_FMT = "resourceHash_{0}";

	[NonSerialized]
	public static string ASSETBUNDLE_SIZE_FILENAME = "datasize.txt";

	[NonSerialized]
	public static string VERSIONNUMBER_FILENAME = "version.txt";

	[NonSerialized]
	public static string PROJECT_ASSETBUNDLE_BASEDIR = "Assets/AssetBundles/";

	public string AUTOBUILD_BASEDIR;

	[NonSerialized]
	public const string DB_FILENAME = "ABDB_AssetBundleDB.db";

	[NonSerialized]
	public const string DB_JSON_FILENAME = "ABDB_RuntimeAsetBundleDBJson.txt";

	private string _AUTOBUILD_BUNDLEDIR;

	private string _AUTOBUILD_COMPRESSED_BUNDLEDIR;

	[NonSerialized]
	public static string PACKEDBASE_DIR = "assetpack/";

	[NonSerialized]
	public static string PROJECT_PACKBUNDLE_BASEDIR = PROJECT_ASSETBUNDLE_BASEDIR + PACKEDBASE_DIR;

	public string ASSET_BUNDLE_FILE_LIST_PATH;

	public string ASSET_BUNDLE_FILE_LIST_RESOURCE_PATH;

	[NonSerialized]
	private static AssetBundlePath _Current = new AssetBundlePath();

	[NonSerialized]
	public static object BLOB_USER_NAME;

	private static string BLOB_COMMON_RESOURCE_PATH_FMT
	{
		get
		{
			string text = "jenkins";
			object obj = BLOB_USER_NAME;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			if (!string.IsNullOrEmpty((string)obj))
			{
				object obj2 = BLOB_USER_NAME;
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				text = (string)obj2;
			}
			text = text.Replace(" ", "_").Replace(".", "_").Replace("/", "_");
			return new StringBuilder().Append("sva").Append("/assets-{0}/cmn-").Append(text)
				.ToString();
		}
	}

	private static string PLATFORM_NAME
	{
		get
		{
			MerlinPlatform merlinPlatform = MerlinPlatformModule.ToMerlinPlatform(Application.platform);
			return merlinPlatform.ToString().ToLower();
		}
	}

	public static string UploadRoutingFilePath
	{
		get
		{
			string fileName = UIBasicUtility.SafeFormat(ASSET_BUNDLE_ROUTING_FILE_NAME_FMT, CurrentBuildableVersion.DATA_VERSION.ToString());
			return UploadCommonResourcePath(fileName);
		}
	}

	public static string UploadMasterZipPath
	{
		get
		{
			string fileName = UIBasicUtility.SafeFormat(CLIENT_MASTER_FILENAME_FMT, CurrentBuildableVersion.MASTER_VERSION.ToString());
			return UploadCommonResourcePath(fileName);
		}
	}

	public static string UploadAssetBundleSizePath => UploadCommonResourcePath(ASSETBUNDLE_SIZE_FILENAME);

	public string AUTOBUILD_BUNDLEDIR
	{
		get
		{
			return _AUTOBUILD_BUNDLEDIR;
		}
		set
		{
			_AUTOBUILD_BUNDLEDIR = normalizeDirectoryPath(value);
		}
	}

	public string AUTOBUILD_COMPRESSED_BUNDLEDIR
	{
		get
		{
			return _AUTOBUILD_COMPRESSED_BUNDLEDIR;
		}
		set
		{
			_AUTOBUILD_COMPRESSED_BUNDLEDIR = normalizeDirectoryPath(value);
		}
	}

	public string AUTOBUILD_ASSETDIR => AUTOBUILD_BASEDIR + "asset/";

	public string AUTOBUILD_PACKEDBASE => AUTOBUILD_BASEDIR + PACKEDBASE_DIR;

	public string AUTOBUILD_PACK_LIST_BASE => AUTOBUILD_BASEDIR + "packlist/";

	public static AssetBundlePath Current
	{
		get
		{
			return _Current;
		}
		set
		{
			if (value == null)
			{
				throw new AssertionFailedException("value != null");
			}
			_Current = value;
		}
	}

	public string AssetBundleResourceDir => AUTOBUILD_BUNDLEDIR + "DontCommitAnythingInThisDirectory/Resources";

	public AssetBundlePath()
	{
		AUTOBUILD_BASEDIR = PROJECT_ASSETBUNDLE_BASEDIR;
		_AUTOBUILD_BUNDLEDIR = AUTOBUILD_BASEDIR + "bundle/";
		_AUTOBUILD_COMPRESSED_BUNDLEDIR = AUTOBUILD_BASEDIR + "compressed_bundle/";
		ASSET_BUNDLE_FILE_LIST_PATH = AUTOBUILD_BASEDIR + "Resources/AssetBundleFileInfo.txt";
		ASSET_BUNDLE_FILE_LIST_RESOURCE_PATH = "AssetBundleFileInfo";
	}

	private static string BlobAssetBundlePath(string platformName, string dataVersion, string fileName)
	{
		string text = "jenkins";
		text = text.Replace(" ", "_").Replace(".", "_").Replace("/", "_");
		object obj = BLOB_USER_NAME;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		if (!string.IsNullOrEmpty((string)obj))
		{
			object obj2 = BLOB_USER_NAME;
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			text = (string)obj2;
		}
		return "sva" + "/assets-" + platformName + "/d" + dataVersion + "-" + text + "/" + fileName;
	}

	public static string RuntimeAssetBundlePath(string fileName, string dataVersion)
	{
		MerlinPlatform merlinPlatform = MerlinPlatformModule.ToMerlinPlatform(Application.platform);
		return BlobAssetBundlePath(PLATFORM_NAME, dataVersion, fileName);
	}

	public static string RuntimeAssetBundleURL(string fileName, string dataVersion)
	{
		string path = RuntimeAssetBundlePath(fileName, dataVersion);
		return ServerURL.AssetSrvUrl(path);
	}

	private static string RuntimeCommonResourcePath(string fileName)
	{
		string text = UIBasicUtility.SafeFormat(BLOB_COMMON_RESOURCE_PATH_FMT, PLATFORM_NAME);
		if (!text.EndsWith("/"))
		{
			text += "/";
		}
		if (fileName.StartsWith("/"))
		{
			fileName = fileName.Substring(1);
		}
		return text + fileName;
	}

	private static string RuntimeCommonResourceURL(string fileName)
	{
		string path = RuntimeCommonResourcePath(fileName);
		return ServerURL.AssetSrvUrl(path);
	}

	public static string RuntimeRoutingFileURL(string dataVersion)
	{
		string fileName = UIBasicUtility.SafeFormat(ASSET_BUNDLE_ROUTING_FILE_NAME_FMT, dataVersion);
		return RuntimeCommonResourceURL(fileName);
	}

	public static string RuntimeMasterZipURL(string masterVersion)
	{
		string fileName = UIBasicUtility.SafeFormat(CLIENT_MASTER_FILENAME_FMT, masterVersion);
		return RuntimeCommonResourceURL(fileName);
	}

	public static string RuntimeAssetBundleDBJsonURL(string dataVersion)
	{
		return RuntimeAssetBundleURL("ABDB_RuntimeAsetBundleDBJson.txt", dataVersion);
	}

	public static string RuntimeDataPath(string fileName)
	{
		return ServerURL.AssetSrvUrl(BLOB_DATA_PATH + fileName);
	}

	public static string UploadAssetBundlePath(string fileName)
	{
		string dataVersion = CurrentBuildableVersion.DATA_VERSION.ToString();
		return AppendSlashIfNot(RuntimeAssetBundlePath(fileName, dataVersion));
	}

	public static string UploadCommonResourcePath(string fileName)
	{
		return AppendSlashIfNot(RuntimeCommonResourcePath(fileName));
	}

	public static string UploadDataFilePath(string fileName)
	{
		return AppendSlashIfNot(BLOB_DATA_PATH + fileName);
	}

	private static string AppendSlashIfNot(string path)
	{
		if (!RuntimeServices.EqualityOperator(path[0], "/"))
		{
			path = "/" + path;
		}
		return path;
	}

	public static void ResetCurrent()
	{
		_Current = new AssetBundlePath();
	}

	public string ResourceBundleName(string bundleName)
	{
		return UIBasicUtility.SafeFormat("RESBUNDLE_{0}", bundleName);
	}

	public string ResourceBundleFilename(string bundleName)
	{
		return ResourceBundleName(bundleName) + ".bytes";
	}

	public string ResourceBundleDir(MerlinPlatform rp)
	{
		return AUTOBUILD_BUNDLEDIR + rp.ToString() + "/";
	}

	public string ResourceBundleDir()
	{
		MerlinPlatform rp = MerlinPlatformModule.ToMerlinPlatform(Application.platform);
		return ResourceBundleDir(rp);
	}

	public string ResourceBundleFullPath(string bundleName)
	{
		return ResourceBundleDir() + ResourceBundleFilename(bundleName);
	}

	public string BuildPath(string filename, bool compressed)
	{
		if (string.IsNullOrEmpty(filename))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(filename)");
		}
		return Path.Combine(BuildDirectory(compressed), filename);
	}

	public string BuildDBPath(bool compressed)
	{
		return Path.Combine(BuildDirectory(compressed), "ABDB_AssetBundleDB.db");
	}

	public string BuildDBJsonPath(bool compressed)
	{
		return Path.Combine(BuildDirectory(compressed), "ABDB_RuntimeAsetBundleDBJson.txt");
	}

	public string BuildDirectory(bool compressed)
	{
		return BuildDirectory(MerlinPlatformModule.CurrentMerlinPlatform(), compressed);
	}

	public string BuildDirectory(MerlinPlatform target, bool compressed)
	{
		return BuildDirectoryBase(compressed) + target.ToString();
	}

	public string BuildDirectoryBase(bool compressed)
	{
		return (!compressed) ? AUTOBUILD_BUNDLEDIR : AUTOBUILD_COMPRESSED_BUNDLEDIR;
	}

	public string BundlPathInProjectDir(string bundleName)
	{
		return ResourceBundleDir() + bundleName + ".unity3d";
	}

	public string JsonDBPathInProjectDir()
	{
		return ResourceBundleDir() + "ABDB_RuntimeAsetBundleDBJson.txt";
	}

	public string PackListDirectory(MerlinPlatform target)
	{
		return AUTOBUILD_PACK_LIST_BASE + target.ToString();
	}

	private static string normalizeDirectoryPath(string path)
	{
		if (!string.IsNullOrEmpty(path) && path.Length > 0)
		{
			string text = path;
			if (text.Substring(RuntimeServices.NormalizeStringIndex(text, -1)) != "/")
			{
				path += "/";
			}
		}
		return path;
	}
}
