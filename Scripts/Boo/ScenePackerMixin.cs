using System;
using System.IO;
using Boo.Lang.Runtime;

[Serializable]
public class ScenePackerMixin
{
	[NonSerialized]
	public const string BASE_PATH = "Assets/ScenePacker";

	[NonSerialized]
	public static readonly string SOURCE_PATH = "Assets/ScenePacker" + "/SourceScenes";

	[NonSerialized]
	public static readonly string PREFAB_PATH = "Assets/ScenePacker" + "/Prefabs";

	[NonSerialized]
	public static readonly string LISTING_FILE_DIR = "Assets/ScenePacker" + "/Listings";

	[NonSerialized]
	public const string PACKAGE_NAME_FMT = "PKSCN_{0}";

	[NonSerialized]
	public const string PREFAB_NAME_FMT = "PKSCN_PFB_{0}";

	[NonSerialized]
	public const string SCENE_PACK_NAME = "PKSCN_{0}";

	[NonSerialized]
	public static readonly string MAP_FILE_PATH = LISTING_FILE_DIR + "/pkscn.map";

	public static string ScenePackNamePrefix => ScenePackName(string.Empty);

	public static string PrefabName(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(sceneName)");
		}
		return UIBasicUtility.SafeFormat("PKSCN_PFB_{0}", sceneName);
	}

	public static string ScenePackName(string dirName)
	{
		return UIBasicUtility.SafeFormat("PKSCN_{0}", dirName);
	}

	public static string ScenePackListingPath(string dirName)
	{
		string path = ScenePackName(dirName) + ".lst";
		return Path.Combine(LISTING_FILE_DIR, path);
	}

	public static string ScenePackPrefabDir(string dirName)
	{
		string path = ScenePackName(dirName);
		AssetBundlePath assetBundlePath = new AssetBundlePath();
		return Path.Combine(assetBundlePath.AUTOBUILD_PACKEDBASE, path);
	}
}
