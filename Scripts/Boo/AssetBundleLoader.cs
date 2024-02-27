using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class AssetBundleLoader : MonoBehaviour
{
	[Serializable]
	public abstract class Request
	{
		public override bool ok => false;

		public override UnityEngine.Object asset => null;

		public override bool isError => false;

		public override bool isEndOfLoad => false;

		public override AssetPack packList => null;

		public override string bundleName => null;

		public virtual UnityEngine.Object load(string name, Type type)
		{
			return null;
		}

		public virtual AssetBundleRequest loadAsync(string name, Type type)
		{
			return null;
		}

		public virtual UnityEngine.Object[] loadAll()
		{
			return null;
		}

		public virtual GameObject instantiatePrefab()
		{
			return null;
		}

		public void unload()
		{
			UnloadBundle(bundleName);
		}
	}

	[Serializable]
	public class Entry : Request
	{
		[Serializable]
		public enum LoadMode
		{
			None,
			InFileSystem,
			OnWWW,
			InResources,
			Finished,
			Error
		}

		public string name;

		public AssetBundle bundle;

		public bool forCache;

		public WWW www;

		public AssetBundleCreateRequest memReq;

		private bool error;

		private int retryCount;

		private LoadMode loadMode;

		public override bool ok
		{
			get
			{
				bool num = bundle != null;
				if (num)
				{
					num = loadMode == LoadMode.Finished;
				}
				return num;
			}
		}

		public override UnityEngine.Object asset => (!(bundle != null)) ? null : bundle.mainAsset;

		public override bool isEndOfLoad
		{
			get
			{
				bool num = ok;
				if (!num)
				{
					num = error;
				}
				if (!num)
				{
					num = loadMode == LoadMode.Finished;
				}
				return num;
			}
		}

		public override AssetPack packList
		{
			get
			{
				object result;
				if (bundle == null || bundle.mainAsset == null)
				{
					result = null;
				}
				else
				{
					GameObject gameObject = bundle.mainAsset as GameObject;
					result = ((!(gameObject == null)) ? gameObject.GetComponent<AssetPack>() : null);
				}
				return (AssetPack)result;
			}
		}

		public override string bundleName => name;

		public bool isFinished => loadMode == LoadMode.Finished;

		public override bool isError => error;

		public Entry(string name)
		{
			loadMode = LoadMode.None;
			if (string.IsNullOrEmpty(name))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(name)");
			}
			this.name = name;
		}

		public override UnityEngine.Object load(string name, Type type)
		{
			object result;
			if (bundle == null)
			{
				AssetBundleLoadError(new StringBuilder("バンドルが無い try to load ").Append(name).ToString());
				result = null;
			}
			else
			{
				UnityEngine.Object @object = bundle.Load(name, type);
				if (@object == null)
				{
				}
				result = @object;
			}
			return (UnityEngine.Object)result;
		}

		public override AssetBundleRequest loadAsync(string name, Type type)
		{
			object result;
			if (bundle == null)
			{
				AssetBundleLoadError(new StringBuilder("バンドルが無い try to load ").Append(name).ToString());
				result = null;
			}
			else
			{
				result = bundle.LoadAsync(name, type);
			}
			return (AssetBundleRequest)result;
		}

		public override UnityEngine.Object[] loadAll()
		{
			object result;
			if (bundle == null)
			{
				AssetBundleLoadError("バンドルが無い try to loadAll()");
				result = null;
			}
			else
			{
				System.Collections.Generic.List<UnityEngine.Object> list = new System.Collections.Generic.List<UnityEngine.Object>();
				int i = 0;
				UnityEngine.Object[] array = bundle.LoadAll();
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					if (array[i] != null)
					{
						list.Add(array[i]);
					}
				}
				result = (UnityEngine.Object[])Builtins.array(typeof(UnityEngine.Object), list);
			}
			return (UnityEngine.Object[])result;
		}

		public override GameObject instantiatePrefab()
		{
			if (!(asset != null))
			{
				throw new AssertionFailedException("asset != null");
			}
			GameObject gameObject = load(asset.name, typeof(GameObject)) as GameObject;
			return (!(gameObject != null)) ? null : (((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject);
		}

		public override string ToString()
		{
			return new StringBuilder().Append(name).Append(": mode=").Append(loadMode)
				.Append(" bundle=")
				.Append(bundle != null)
				.Append(" ")
				.ToString();
		}

		public void startLoad()
		{
			loadViaWWW();
		}

		private void loadOnFileSystem()
		{
			loadMode = LoadMode.InFileSystem;
		}

		private void loadViaWWW()
		{
			string text = BundleURL(name);
			Hashtable resourceHash = DownloadMain.ResourceHash;
			int assetBundleVersion = DownloadUtil.GetAssetBundleVersion(resourceHash, text);
			if (!Caching.IsVersionCached(text, assetBundleVersion))
			{
			}
			www = WWW.LoadFromCacheOrDownload(text, assetBundleVersion);
			loadMode = LoadMode.OnWWW;
		}

		private void loadInResourceBundle()
		{
			loadMode = LoadMode.InResources;
		}

		public void update()
		{
			if (this.loadMode == LoadMode.None || this.loadMode >= LoadMode.Finished)
			{
				return;
			}
			LoadMode loadMode = this.loadMode;
			switch (loadMode)
			{
			case LoadMode.OnWWW:
				if (www != null)
				{
					if (www.isDone)
					{
						bundle = www.assetBundle;
						www = null;
						if (bundle != null)
						{
							this.loadMode = LoadMode.Finished;
							break;
						}
						setError();
						AssetBundleLoadError(new StringBuilder("www cannot load ").Append(name).Append(" bundle").ToString());
					}
					else if (www.error != null)
					{
						string rhs = www.error;
						www = null;
						this.loadMode = LoadMode.Error;
						if (checked(++retryCount) < 3)
						{
							startLoad();
							break;
						}
						setError();
						AssetBundleLoadError("www.error=" + rhs);
					}
				}
				else
				{
					setError();
					AssetBundleLoadError(new StringBuilder("unknown error: ").Append(this.loadMode).ToString());
				}
				break;
			case LoadMode.InFileSystem:
			{
				string text2 = AssetBundlePath.Current.BundlPathInProjectDir(name);
				loadFromFile(text2);
				break;
			}
			case LoadMode.InResources:
			{
				string text = AssetBundlePath.Current.ResourceBundleName(name);
				TextAsset textAsset = Resources.Load(text) as TextAsset;
				if (!(textAsset != null))
				{
					throw new AssertionFailedException(new StringBuilder("name=").Append(name).Append(", path=").Append(text)
						.ToString());
				}
				string text2 = Application.temporaryCachePath + "/" + name;
				if (writeFile(text2, textAsset.bytes))
				{
					loadFromFile(text2);
					break;
				}
				setError();
				AssetBundleLoadError(new StringBuilder("cannot write ").Append(text2).ToString());
				break;
			}
			default:
				setError();
				AssetBundleLoadError(new StringBuilder("unknown error: ").Append(loadMode).ToString());
				break;
			}
		}

		public void setError()
		{
			loadMode = LoadMode.Error;
		}

		private bool writeFile(string fpath, byte[] data)
		{
			if (data == null)
			{
				throw new AssertionFailedException("data != null");
			}
			FileStream fileStream;
			IDisposable disposable = (fileStream = new FileStream(fpath, FileMode.Create, FileAccess.Write)) as IDisposable;
			try
			{
				fileStream.Write(data, 0, data.Length);
				return true;
			}
			finally
			{
				if (disposable != null)
				{
					disposable.Dispose();
					disposable = null;
				}
			}
		}

		private void loadFromFile(string fpath)
		{
			if (string.IsNullOrEmpty(fpath))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(fpath)");
			}
			bundle = AssetBundle.CreateFromFile(fpath);
			if (bundle != null)
			{
				loadMode = LoadMode.Finished;
				return;
			}
			loadMode = LoadMode.Error;
			AssetBundleLoadError(new StringBuilder("FileStream cannot build bundle ").Append(name).Append(" path:").Append(fpath)
				.ToString());
		}

		public void destroy()
		{
			if (bundle != null)
			{
				bundle.Unload(unloadAllLoadedObjects: true);
			}
			bundle = null;
			stopLoad();
		}

		public new void unload()
		{
			if (bundle != null)
			{
				bundle.Unload(unloadAllLoadedObjects: false);
			}
			bundle = null;
			stopLoad();
		}

		private void stopLoad()
		{
			bool flag = false;
			loadMode = LoadMode.Error;
			if (www != null)
			{
				try
				{
					www.Dispose();
				}
				catch (Exception)
				{
				}
			}
			if (memReq != null)
			{
				memReq = null;
			}
		}
	}

	[NonSerialized]
	private static AssetBundleLoader __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private const int CONCURRENT_LOAD_LIMIT = 3;

	[NonSerialized]
	private const int WWW_RETRY_COUNT = 3;

	private Dictionary<string, Entry> bundles;

	private System.Collections.Generic.List<Entry> waitingQueue;

	private System.Collections.Generic.List<Entry> loadings;

	private HashSet<string> cachedBundles;

	public string[] debWaitingNames;

	public string[] debLoadingNames;

	public string[] debCachedNames;

	public string[] debCurrentNames;

	public static AssetBundleLoader Instance
	{
		get
		{
			AssetBundleLoader _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((AssetBundleLoader)UnityEngine.Object.FindObjectOfType(typeof(AssetBundleLoader))) as AssetBundleLoader;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static AssetBundleLoader CurrentInstance => __instance;

	public static string[] OpenedBundleNames => (string[])Builtins.array(typeof(string), Instance.onBundles);

	public static float CachingProgress => Instance.cachingProgress;

	public float cachingProgress => 0f;

	public string[] onBundles => (string[])Builtins.array(typeof(string), bundles.Keys);

	private static string CacheFlagPrefKey => MerlinPlatformModule.CurrentMerlinPlatform() + "/asset-bundle-cache-list";

	public Dictionary<string, Entry> Bundles => bundles;

	public System.Collections.Generic.List<Entry> WaitingQueue => waitingQueue;

	public System.Collections.Generic.List<Entry> Loadings => loadings;

	public AssetBundleLoader()
	{
		bundles = new Dictionary<string, Entry>();
		waitingQueue = new System.Collections.Generic.List<Entry>();
		loadings = new System.Collections.Generic.List<Entry>();
		cachedBundles = new HashSet<string>();
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_0024194();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static AssetBundleLoader _createInstance()
	{
		string text = "__" + "AssetBundleLoader" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		AssetBundleLoader assetBundleLoader = ExtensionsModule.SetComponent<AssetBundleLoader>(gameObject);
		if ((bool)assetBundleLoader)
		{
			assetBundleLoader._createInstance_callback();
		}
		return assetBundleLoader;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_0024195()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_0024195();
		quitApp = true;
	}

	public static string BundleURL(string bundleName)
	{
		if (string.IsNullOrEmpty(Path.GetExtension(bundleName)))
		{
			bundleName += ".unity3d";
		}
		return AssetBundlePath.RuntimeAssetBundleURL(bundleName, CurrentInfo.DataVersion);
	}

	public static bool CacheBundle(string bundleName)
	{
		return Instance.cacheBundle(bundleName) != null;
	}

	public static bool LoadBundle(string bundleName)
	{
		return Instance.loadBundle(bundleName) != null;
	}

	public static Request ReqBundle(string bundleName)
	{
		return Instance.reqBundle(bundleName);
	}

	public static bool IsBundleLoading(string bundleName)
	{
		return Instance.isBundleLoading(bundleName);
	}

	public static bool IsBundleCached(string bundleName)
	{
		return Instance.isBundleCached(bundleName);
	}

	public static bool IsBundleOnMemory(string bundleName)
	{
		return Instance.isBundleOnMemory(bundleName);
	}

	public static AssetBundle GetAssetBundle(string bundleName)
	{
		return Instance.getAssetBundle(bundleName);
	}

	public static void UnloadBundle(string bundleName)
	{
		Instance.unloadBundle(bundleName);
	}

	public static void UnloadBundleAll()
	{
		Instance.unloadBundleAll();
	}

	public static void DestroyAll()
	{
		Instance.destroyBundleAll();
	}

	public Entry cacheBundle(string bundleName)
	{
		Entry entry = findEntry(bundleName);
		Entry result;
		if (entry != null)
		{
			result = entry;
		}
		else
		{
			entry = createEntry(bundleName);
			entry.forCache = true;
			waitingQueue.Add(entry);
			result = entry;
		}
		return result;
	}

	public Entry loadBundle(string bundleName)
	{
		Entry entry = findEntry(bundleName);
		Entry result;
		if (entry != null)
		{
			result = entry;
		}
		else
		{
			entry = createEntry(bundleName);
			waitingQueue.Add(entry);
			result = entry;
		}
		return result;
	}

	public Entry reqBundle(string bundleName)
	{
		return loadBundle(bundleName);
	}

	public bool isBundleLoading(string bundleName)
	{
		Entry entry = findEntry(bundleName);
		bool num = entry != null;
		if (num)
		{
			num = !entry.isFinished;
		}
		return num;
	}

	public bool isBundleCached(string bundleName)
	{
		return cachedBundles.Contains(bundleName);
	}

	public bool isBundleOnMemory(string bundleName)
	{
		Entry entry = findEntry(bundleName);
		bool num = entry != null;
		if (num)
		{
			num = entry.bundle != null;
		}
		return num;
	}

	public AssetBundle getAssetBundle(string bundleName)
	{
		return findEntry(bundleName)?.bundle;
	}

	public void unloadBundle(string bundleName)
	{
		Entry entry = findEntry(bundleName);
		if (entry != null)
		{
			entry.unload();
			removeEntry(entry);
		}
	}

	public void unloadBundleAll()
	{
		int i = 0;
		Entry[] array = (Entry[])Builtins.array(typeof(Entry), bundles.Values);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].unload();
			removeEntry(array[i]);
		}
	}

	private void destroyBundleAll()
	{
		int i = 0;
		Entry[] array = (Entry[])Builtins.array(typeof(Entry), bundles.Values);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].destroy();
			removeEntry(array[i]);
		}
	}

	private void updateDebugInfo()
	{
		debWaitingNames = new string[((ICollection)waitingQueue).Count];
		int num = 0;
		int count = ((ICollection)waitingQueue).Count;
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < count)
		{
			int index = num;
			num++;
			string[] array = debWaitingNames;
			array[RuntimeServices.NormalizeArrayIndex(array, index)] = waitingQueue[index].name;
		}
		debLoadingNames = new string[((ICollection)loadings).Count];
		int num2 = 0;
		int count2 = ((ICollection)loadings).Count;
		if (count2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < count2)
		{
			int index2 = num2;
			num2++;
			string[] array2 = debLoadingNames;
			array2[RuntimeServices.NormalizeArrayIndex(array2, index2)] = loadings[index2].name;
		}
		debCachedNames = (string[])Builtins.array(typeof(string), cachedBundles);
		debCurrentNames = (string[])Builtins.array(typeof(string), bundles.Keys);
	}

	public void _0024singleton_0024awake_0024194()
	{
		clearCacheFlags();
	}

	public void Update()
	{
		Entry[] array = (Entry[])Builtins.array(typeof(Entry), loadings);
		IEnumerator enumerator = array.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Entry))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Entry));
			}
			Entry entry = (Entry)obj;
			entry.update();
			if (!entry.isFinished)
			{
				continue;
			}
			loadings.Remove(entry);
			if (!entry.isError)
			{
				markAsCached(entry.name);
				if (entry.forCache)
				{
					entry.destroy();
					bundles.Remove(entry.name);
				}
			}
			updateDebugInfo();
		}
		int count = loadings.Count;
		int count2 = waitingQueue.Count;
		if (count < 3 && count2 > 0)
		{
			int num = 0;
			int num2 = Mathf.Min(checked(3 - count), count2);
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				Entry entry2 = waitingQueue[0];
				waitingQueue.RemoveAt(0);
				loadings.Add(entry2);
				entry2.startLoad();
			}
			updateDebugInfo();
		}
	}

	private void clearCacheFlags()
	{
		cachedBundles.Clear();
		PlayerPrefs.SetString(CacheFlagPrefKey, string.Empty);
		updateDebugInfo();
	}

	private void loadCacheFlags()
	{
		string @string = PlayerPrefs.GetString(CacheFlagPrefKey, string.Empty);
		int i = 0;
		string[] array = @string.Split(',');
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			cachedBundles.Add(array[i]);
		}
		updateDebugInfo();
	}

	private void markAsCached(string bundleName)
	{
		if (!cachedBundles.Contains(bundleName))
		{
			cachedBundles.Add(bundleName);
		}
		string value = Builtins.join(cachedBundles, ",");
		PlayerPrefs.SetString(CacheFlagPrefKey, value);
		updateDebugInfo();
	}

	private Entry createEntry(string assetBundleName)
	{
		Entry entry = findEntry(assetBundleName);
		Entry result;
		if (entry != null)
		{
			result = entry;
		}
		else
		{
			entry = new Entry(assetBundleName);
			bundles[assetBundleName] = entry;
			updateDebugInfo();
			result = entry;
		}
		return result;
	}

	private Entry findEntry(string assetBundleName)
	{
		return string.IsNullOrEmpty(assetBundleName) ? null : ((!bundles.ContainsKey(assetBundleName)) ? null : bundles[assetBundleName]);
	}

	private void removeEntry(Entry e)
	{
		if (e != null)
		{
			bundles.Remove(e.name);
			loadings.Remove(e);
			waitingQueue.Remove(e);
			updateDebugInfo();
			if (!e.ok)
			{
				e.setError();
			}
		}
	}

	private static void AssetBundleLoadError(string msg)
	{
		DestroyAll();
		RuntimeAssetBundleDB.Kill();
		Application.LoadLevel("Empty");
		ClearData.ClearDownloadedData();
		MerlinServer.Instance.disposeRequests();
		ErrorDialog.FatalError("データが壊れています。", "ダウンロードデータエラー", jumpBoot: true, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___00242.Adapt(delegate
		{
			ClearData.ClearDownloadedData();
			Application.LoadLevel(30);
		}));
	}

	public static void ReloadShader(GameObject o)
	{
		if (o == null || !Application.isEditor)
		{
			return;
		}
		int i = 0;
		Renderer[] componentsInChildren = o.GetComponentsInChildren<Renderer>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			Material[] materials = componentsInChildren[i].materials;
			int num = 0;
			int length2 = materials.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length2)
			{
				int index = num;
				num++;
				Material material = materials[RuntimeServices.NormalizeArrayIndex(materials, index)];
				if (!(material == null) && !(material.shader == null))
				{
					material.shader = Shader.Find(material.shader.name);
				}
			}
		}
	}

	internal static void _0024AssetBundleLoadError_0024closure_00243996()
	{
		ClearData.ClearDownloadedData();
		Application.LoadLevel(30);
	}
}
