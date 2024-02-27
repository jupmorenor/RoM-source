using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class IconAtlasPool : MonoBehaviour
{
	[Serializable]
	public enum Timings
	{
		Enter = 1,
		EnterFadeout
	}

	[Serializable]
	public enum Operations
	{
		LoadAll = 1,
		LoadBox,
		Dispose
	}

	[Serializable]
	public struct LoadInfo
	{
		public string sceneName;

		public Timings timing;

		public Operations operation;

		public LoadInfo(string _sceneName, Timings _timing, Operations _operation)
		{
			if (string.IsNullOrEmpty(_sceneName))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(_sceneName)");
			}
			sceneName = _sceneName.ToLower();
			timing = _timing;
			operation = _operation;
		}

		public bool matches(string name, Timings reqTiming)
		{
			int num;
			if (string.IsNullOrEmpty(name))
			{
				num = 0;
			}
			else
			{
				num = ((name.ToLower() == sceneName) ? 1 : 0);
				if (num != 0)
				{
					num = ((timing == reqTiming) ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	[Serializable]
	public class Atlas
	{
		[Serializable]
		public enum Modes
		{
			Loading,
			OnMemory,
			Disposed
		}

		private string name;

		private UIAtlas atlas;

		private HashSet<string> sprites;

		private Modes mode;

		private RuntimeAssetBundleDB.Req loadReq;

		private GameObject prefab;

		public bool IsDisposed => mode == Modes.Disposed;

		public bool IsActive
		{
			get
			{
				bool num = mode == Modes.OnMemory;
				if (num)
				{
					num = atlas != null;
				}
				return num;
			}
		}

		public bool IsActiveOrLoading
		{
			get
			{
				bool num = mode == Modes.Loading;
				if (!num)
				{
					num = IsActive;
				}
				return num;
			}
		}

		public string Name => name;

		public UIAtlas Atlas => atlas;

		public HashSet<string> Sprites => sprites;

		public Modes Mode => mode;

		public RuntimeAssetBundleDB.Req LoadReq => loadReq;

		public Atlas(string atlasPathOrName)
		{
			sprites = new HashSet<string>();
			mode = Modes.Loading;
			if (string.IsNullOrEmpty(atlasPathOrName))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(atlasPathOrName)");
			}
			name = AtlasName(atlasPathOrName);
		}

		public static string AtlasName(string atlasPathOrName)
		{
			if (string.IsNullOrEmpty(atlasPathOrName))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(atlasPathOrName)");
			}
			return Path.GetFileNameWithoutExtension(atlasPathOrName);
		}

		public override string ToString()
		{
			return new StringBuilder("Atlas(").Append(name).Append(" atlas:").Append(atlas)
				.Append(" sprites:")
				.Append((object)sprites.Count)
				.Append(" mode:")
				.Append(mode)
				.Append(")")
				.ToString();
		}

		public bool isMe(string atlasPathOrName)
		{
			return !(atlasPathOrName == name) && name == Path.GetFileNameWithoutExtension(atlasPathOrName);
		}

		public void update()
		{
			if (atlas != null)
			{
				return;
			}
			if (mode == Modes.Loading)
			{
				RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
				if (loadReq == null)
				{
					loadReq = instance.loadPrefab(name);
				}
				if (loadReq.IsOk)
				{
					UIAtlas component = loadReq.Prefab.GetComponent<UIAtlas>();
					if (component == null)
					{
					}
					atlas = component;
					initializeNameDict(atlas);
					if (atlas != null)
					{
						mode = Modes.OnMemory;
						return;
					}
					UnityEngine.Object.Destroy(loadReq.Prefab);
					mode = Modes.Disposed;
				}
				else if (loadReq.IsEnd)
				{
					mode = Modes.Disposed;
					loadReq = null;
				}
			}
			else if (mode == Modes.OnMemory && atlas == null)
			{
				dispose();
			}
		}

		public bool contains(string spriteName)
		{
			bool num = IsActive;
			if (num)
			{
				num = sprites.Contains(spriteName);
			}
			return num;
		}

		private void initializeNameDict(UIAtlas _atlas)
		{
			sprites.Clear();
			if (_atlas == null)
			{
				return;
			}
			IEnumerator<string> enumerator = _atlas.GetListOfSprites().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (!string.IsNullOrEmpty(current) && !sprites.Contains(current))
					{
						sprites.Add(current);
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}

		public void dispose()
		{
			if (atlas != null)
			{
				_log(new StringBuilder("IconAtlasPool: dispose atlas ").Append(atlas).ToString());
			}
			_log(new StringBuilder("icon atlas disposed: ").Append(Name).ToString());
			atlas = null;
			sprites.Clear();
			mode = Modes.Disposed;
		}
	}

	[Serializable]
	public class Req
	{
		[Serializable]
		public enum DebugStatus
		{
			init,
			requestingAtlas,
			waitingAtlas,
			finished,
			couldNotFoundInDB
		}

		public UISprite sprite;

		public string spriteName;

		public __IconAtlasPool_SetSprite_0024callable96_0024190_88__ callback;

		public string atlasName;

		public Atlas reqAtlas;

		public DebugStatus status;

		public Req(UISprite _sprite, string _spriteName)
		{
			status = DebugStatus.init;
			sprite = _sprite;
			spriteName = _spriteName;
		}

		public override string ToString()
		{
			return new StringBuilder().Append(spriteName).Append("->").Append(sprite)
				.Append(": status=")
				.Append(status)
				.Append(" atlasName=")
				.Append(atlasName)
				.Append(" reqAtlas=")
				.Append(reqAtlas)
				.ToString();
		}
	}

	[Serializable]
	internal class _0024removeReqsBySprite_0024locals_002414472
	{
		internal UISprite _0024sprite;
	}

	[Serializable]
	internal class _0024removeReqsBySprite_0024closure_00244002
	{
		internal _0024removeReqsBySprite_0024locals_002414472 _0024_0024locals_002415043;

		public _0024removeReqsBySprite_0024closure_00244002(_0024removeReqsBySprite_0024locals_002414472 _0024_0024locals_002415043)
		{
			this._0024_0024locals_002415043 = _0024_0024locals_002415043;
		}

		public bool Invoke(Req r)
		{
			return r.sprite == _0024_0024locals_002415043._0024sprite;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024loadIconDB_0024loadAndInit_00242795_002421378 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal IconAtlasPool _0024self__002421379;

			public _0024(IconAtlasPool self_)
			{
				_0024self__002421379 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_log("IconAtlasPool.loadAndInit");
						_0024self__002421379.loadingDBCount++;
						_0024self__002421379.iconDb.loadDB();
						goto case 2;
					case 2:
						if (_0024self__002421379.iconDb.IsBusy)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						_0024self__002421379.loadingDBCount--;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal IconAtlasPool _0024self__002421380;

		public _0024_0024loadIconDB_0024loadAndInit_00242795_002421378(IconAtlasPool self_)
		{
			_0024self__002421380 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421380);
		}
	}

	[NonSerialized]
	private static IconAtlasPool __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private static readonly LoadInfo[] ICON_LOAD_INFO_TABLE = new LoadInfo[3]
	{
		new LoadInfo("Town", Timings.Enter, Operations.Dispose),
		new LoadInfo("Ui_MyHomeEquip", Timings.Enter, Operations.LoadBox),
		new LoadInfo("Ui_TownBlacksmith", Timings.EnterFadeout, Operations.LoadBox)
	};

	[NonSerialized]
	private const string ICON_ATLAS_ASSET_BUNDLE_NAME = "IconAtlas";

	private IconAtlasDB iconDb;

	private int loadingDBCount;

	[NonSerialized]
	private const string WEAPON_ATLAS_PREFIX = "IconWeaponW";

	[NonSerialized]
	private const string POPPET_ATLAS_PREFIX = "IconPoppet";

	[NonSerialized]
	private const string SKILL_ATLAS_PREFIX = "IconSkill";

	private bool isWeaponPoppetLoaded;

	private bool isSkillLoaded;

	private string[] _weaponAtlasNames;

	private string[] _poppetAtlasNames;

	private string[] _skillAtlasNames;

	private Boo.Lang.List<Atlas> atlasList;

	private Boo.Lang.List<Req> reqs;

	public static IconAtlasPool Instance
	{
		get
		{
			IconAtlasPool _instance;
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
				__instance = ((IconAtlasPool)UnityEngine.Object.FindObjectOfType(typeof(IconAtlasPool))) as IconAtlasPool;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static IconAtlasPool CurrentInstance => __instance;

	public static bool IsLoading => Instance.IsLoadingIconDb;

	protected bool IsLoadingIconDb => loadingDBCount > 0;

	protected string[] weaponAtlasNames
	{
		get
		{
			if (_weaponAtlasNames == null)
			{
				RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
				_weaponAtlasNames = instance.allAssetNamesPrefixedBy("IconWeaponW");
			}
			return _weaponAtlasNames;
		}
	}

	protected string[] poppetAtlasNames
	{
		get
		{
			if (_poppetAtlasNames == null)
			{
				RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
				_poppetAtlasNames = instance.allAssetNamesPrefixedBy("IconPoppet");
			}
			return _poppetAtlasNames;
		}
	}

	protected string[] skillAtlasNames
	{
		get
		{
			if (_skillAtlasNames == null)
			{
				RuntimeAssetBundleDB instance = RuntimeAssetBundleDB.Instance;
				_skillAtlasNames = instance.allAssetNamesPrefixedBy("IconSkill");
			}
			return _skillAtlasNames;
		}
	}

	public static Atlas[] AllAtlasData => (Atlas[])Builtins.array(typeof(Atlas), Instance.atlasList);

	public bool IsWeaponPoppetLoaded => isWeaponPoppetLoaded;

	public bool IsSkillLoaded => isSkillLoaded;

	public Boo.Lang.List<Req> Requests => reqs;

	public IconAtlasPool()
	{
		atlasList = new Boo.Lang.List<Atlas>();
		reqs = new Boo.Lang.List<Req>();
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242520();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static IconAtlasPool _createInstance()
	{
		string text = "__" + "IconAtlasPool" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		IconAtlasPool iconAtlasPool = ExtensionsModule.SetComponent<IconAtlasPool>(gameObject);
		if ((bool)iconAtlasPool)
		{
			iconAtlasPool._createInstance_callback();
		}
		return iconAtlasPool;
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

	public void _0024singleton_0024appQuit_00242521()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242521();
		quitApp = true;
	}

	public static void InitFromAssetbundles()
	{
		_log("IconAtlasPool.InitFromAssetbundles");
		Instance.loadIconDB();
		Instance.invalidateTypeAtlasNameCache();
	}

	public static void PreLoadAll()
	{
		Instance.preLoadWeaponPoppet();
		Instance.preLoadSkill();
	}

	public static void PreLoadBoxItemAtlases()
	{
		Instance.reqLoadBoxItemAtlases();
	}

	public static void PreLoadAtlasesOfSprites(string[] spriteNames)
	{
		Instance.preLoadAtlasesOfSprites(spriteNames);
	}

	public static void UnloadAll()
	{
		Instance.unloadAll();
	}

	public static void UnloadWeaponPoppet()
	{
		_log("IconAtlasPool.UnloadWeaponPoppet");
		Instance.unloadWeaponPoppet();
	}

	public static void PreLoadSkill()
	{
		Instance.preLoadSkill();
	}

	public static bool IsAllLoaded()
	{
		IconAtlasPool currentInstance = CurrentInstance;
		return currentInstance.isAllAtlasActive();
	}

	public static void ReqLoadBySpriteName(string spriteName)
	{
		Instance.reqLoadBySpriteName(spriteName);
	}

	public static void ReqLoadByEquipments()
	{
		Instance.reqLoadByEquipments();
	}

	public static bool SetSprite(UISprite sprite, string spriteName)
	{
		return SetSprite(sprite, spriteName, null);
	}

	public static bool SetSprite(UISprite sprite, string spriteName, __IconAtlasPool_SetSprite_0024callable96_0024190_88__ callback)
	{
		return Instance.setSprite(sprite, spriteName, callback);
	}

	public void _0024singleton_0024awake_00242520()
	{
		iconDb = ExtensionsModule.SetComponent<IconAtlasDB>(gameObject);
		if (!(iconDb != null))
		{
			throw new AssertionFailedException("iconDb != null");
		}
	}

	public void Start()
	{
	}

	private void loadIconDB()
	{
		if (!IsLoadingIconDb)
		{
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024loadIconDB_0024loadAndInit_00242795_002421378(this).GetEnumerator();
			IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public void OnEnable()
	{
		SceneChanger.ScenePreChangeEvent += Instance.sceneChangeEventHandler;
		SceneChanger.SceneChangeEventAtFadeout += Instance.sceneChangeEventFadeoutHandler;
	}

	public void OnDisable()
	{
		SceneChanger.ScenePreChangeEvent -= Instance.sceneChangeEventHandler;
		SceneChanger.SceneChangeEventAtFadeout -= Instance.sceneChangeEventFadeoutHandler;
	}

	private void sceneChangeEventFadeoutHandler(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			return;
		}
		string text = sceneName.ToLower();
		int i = 0;
		LoadInfo[] iCON_LOAD_INFO_TABLE = ICON_LOAD_INFO_TABLE;
		for (int length = iCON_LOAD_INFO_TABLE.Length; i < length; i = checked(i + 1))
		{
			if (iCON_LOAD_INFO_TABLE[i].matches(text, Timings.EnterFadeout))
			{
				sceneChangeOperation(iCON_LOAD_INFO_TABLE[i]);
				break;
			}
		}
	}

	private void sceneChangeEventHandler(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			return;
		}
		string text = sceneName.ToLower();
		int i = 0;
		LoadInfo[] iCON_LOAD_INFO_TABLE = ICON_LOAD_INFO_TABLE;
		for (int length = iCON_LOAD_INFO_TABLE.Length; i < length; i = checked(i + 1))
		{
			if (iCON_LOAD_INFO_TABLE[i].matches(text, Timings.Enter))
			{
				sceneChangeOperation(iCON_LOAD_INFO_TABLE[i]);
				break;
			}
		}
	}

	private void sceneChangeOperation(LoadInfo li)
	{
		if (li.operation == Operations.LoadAll)
		{
			PreLoadAll();
		}
		else if (li.operation == Operations.LoadBox)
		{
			reqLoadBoxItemAtlases();
		}
		else if (li.operation == Operations.Dispose)
		{
			unloadAll();
		}
	}

	private void reqLoadByEquipments()
	{
		UserData current = UserData.Current;
		__IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__ _IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__ = delegate(JsonBase resp)
		{
			if (resp != null)
			{
				if (resp is RespWeapon)
				{
					reqLoadBySpriteName(((RespWeapon)resp).Icon);
				}
				if (resp is RespPoppet)
				{
					reqLoadBySpriteName(((RespPoppet)resp).Icon);
				}
			}
		};
		if (current.IsValidDeck2)
		{
			_IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__(current.AngelWeapon);
			_IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__(current.DevilWeapon);
			_IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__(current.CurrentPoppetNewOrOldDeck);
		}
		else if (current.IsValidCurrentDeck)
		{
			_IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__(current.MainWeapon);
			_IconAtlasPool_reqLoadByEquipments_0024callable178_0024360_13__(current.CurrentPoppet);
		}
	}

	private void reqLoadBoxItemAtlases()
	{
		reqLoadBoxItemAtlases(loadWeapons: true, loadPoppets: true);
	}

	private void reqLoadBoxItemAtlases(bool loadWeapons, bool loadPoppets)
	{
		_log(new StringBuilder("reqLoadBoxItemAtlases w:").Append(loadWeapons).Append(" p:").Append(loadPoppets)
			.ToString());
		HashSet<string> hash2 = new HashSet<string>();
		UserData current = UserData.Current;
		__IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__ _IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__ = delegate(JsonBase resp, ref HashSet<string> hash, bool load)
		{
			if (load && resp != null)
			{
				if (resp is RespWeapon)
				{
					hash.Add(((RespWeapon)resp).Icon);
				}
				if (resp is RespPoppet)
				{
					hash.Add(((RespPoppet)resp).Icon);
				}
			}
		};
		if (current.IsValidDeck2)
		{
			_IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__(current.AngelWeapon, ref hash2, loadWeapons);
			_IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__(current.DevilWeapon, ref hash2, loadWeapons);
			_IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__(current.CurrentPoppetNewOrOldDeck, ref hash2, loadPoppets);
		}
		else if (current.IsValidCurrentDeck)
		{
			_IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__(current.MainWeapon, ref hash2, loadWeapons);
			_IconAtlasPool_reqLoadBoxItemAtlases_0024callable179_0024394_13__(current.CurrentPoppet, ref hash2, loadPoppets);
		}
		preLoadAtlasesOfSprites((string[])Builtins.array(typeof(string), hash2));
		hash2.Clear();
		UserBoxData userBoxData = UserData.Current.userBoxData;
		checked
		{
			if (loadWeapons)
			{
				int i = 0;
				RespWeapon[] weapons = userBoxData.Weapons;
				for (int length = weapons.Length; i < length; i++)
				{
					hash2.Add(weapons[i].Icon);
				}
			}
			if (loadPoppets)
			{
				int j = 0;
				RespPoppet[] muppets = userBoxData.Muppets;
				for (int length2 = muppets.Length; j < length2; j++)
				{
					hash2.Add(muppets[j].Icon);
				}
			}
			preLoadAtlasesOfSprites((string[])Builtins.array(typeof(string), hash2));
		}
	}

	private void invalidateTypeAtlasNameCache()
	{
		_weaponAtlasNames = null;
		_poppetAtlasNames = null;
		_skillAtlasNames = null;
	}

	private void preLoadWeaponPoppet()
	{
		_log("preLoadWeaponPoppet");
		preLoad(weaponAtlasNames);
		preLoad(poppetAtlasNames);
	}

	private void preLoadSkill()
	{
		_log("preLoadSkill");
		preLoad(skillAtlasNames);
	}

	private void preLoadAtlasesOfSprites(string[] spriteNames)
	{
		if (!(iconDb == null))
		{
			string[] array = iconDb.atlasNamesOfSprites(spriteNames);
			if (array != null && array.Length > 0)
			{
				preLoad(array);
			}
		}
	}

	private void unloadWeaponPoppet()
	{
		unloadByPrefix("IconWeaponW");
		unloadByPrefix("IconPoppet");
	}

	private void preLoad(string atlasPathOrName)
	{
		if (string.IsNullOrEmpty(atlasPathOrName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(atlasPathOrName)");
		}
		reqLoad(atlasPathOrName);
	}

	private void preLoad(string[] atlasPathOrNameList)
	{
		if (atlasPathOrNameList == null || atlasPathOrNameList.Length <= 0)
		{
			throw new AssertionFailedException("(atlasPathOrNameList != null) and (len(atlasPathOrNameList) > 0)");
		}
		int i = 0;
		for (int length = atlasPathOrNameList.Length; i < length; i = checked(i + 1))
		{
			reqLoad(atlasPathOrNameList[i]);
		}
	}

	private void unloadAll()
	{
		disposeAllRequests();
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				current.dispose();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		removeDisposedAlasesFromList();
	}

	private void unload(string atlasPathOrName)
	{
		Atlas atlas = find(atlasPathOrName);
		if (atlas != null)
		{
			atlas.dispose();
			removeDisposedAlasesFromList();
		}
	}

	private void unloadByPrefix(string atlasPrefix)
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (current.Name.StartsWith(atlasPrefix))
				{
					current.dispose();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		removeDisposedAlasesFromList();
	}

	private bool isLoaded(object atlasPathOrName)
	{
		object obj = atlasPathOrName;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		string text = Atlas.AtlasName((string)obj);
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (!(current.Name == text) || !current.IsActive)
				{
					continue;
				}
				flag = true;
				goto IL_007b;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 0;
		goto IL_007c;
		IL_007c:
		return (byte)result != 0;
		IL_007b:
		result = (flag ? 1 : 0);
		goto IL_007c;
	}

	public bool setSprite(UISprite sprite, string spriteName)
	{
		return setSprite(sprite, spriteName, null);
	}

	public bool setSprite(UISprite sprite, string spriteName, __IconAtlasPool_SetSprite_0024callable96_0024190_88__ callback)
	{
		int result;
		if (string.IsNullOrEmpty(spriteName))
		{
			result = 0;
		}
		else
		{
			removeReqsBySprite(sprite);
			Req req = new Req(sprite, spriteName);
			req.callback = callback;
			if (setSpriteByReq(req))
			{
				result = 1;
			}
			else
			{
				reqs.Add(req);
				result = 0;
			}
		}
		return (byte)result != 0;
	}

	private bool isAllAtlasActive()
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		bool flag;
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (current.IsActive)
				{
					continue;
				}
				flag = false;
				goto IL_0044;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		int result = 1;
		goto IL_0045;
		IL_0044:
		result = (flag ? 1 : 0);
		goto IL_0045;
		IL_0045:
		return (byte)result != 0;
	}

	private Atlas reqLoad(string atlasPathOrName)
	{
		object result;
		if (string.IsNullOrEmpty(atlasPathOrName))
		{
			result = null;
		}
		else
		{
			Atlas atlas = find(atlasPathOrName);
			if (atlas == null || !atlas.IsActiveOrLoading)
			{
				if (atlas != null)
				{
					atlasList.Remove(atlas);
				}
				_log(new StringBuilder("IconAtlasPool: preLoad ").Append(atlasPathOrName).ToString());
				atlas = new Atlas(atlasPathOrName);
				atlasList.Add(atlas);
			}
			result = atlas;
		}
		return (Atlas)result;
	}

	private Atlas find(string atlasPathOrName)
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		Atlas atlas;
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (!current.isMe(atlasPathOrName))
				{
					continue;
				}
				atlas = current;
				goto IL_0045;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_0046;
		IL_0045:
		result = atlas;
		goto IL_0046;
		IL_0046:
		return (Atlas)result;
	}

	private Atlas getAtlasBySpriteName(string spriteName)
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		Atlas atlas;
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (!current.contains(spriteName))
				{
					continue;
				}
				atlas = current;
				goto IL_0045;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_0046;
		IL_0045:
		result = atlas;
		goto IL_0046;
		IL_0046:
		return (Atlas)result;
	}

	private Atlas findAtlasByName(string atlasName)
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		Atlas atlas;
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (!(current.Name == atlasName))
				{
					continue;
				}
				atlas = current;
				goto IL_004a;
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		object result = null;
		goto IL_004b;
		IL_004a:
		result = atlas;
		goto IL_004b;
		IL_004b:
		return (Atlas)result;
	}

	private void dispose(string atlasPathOrName)
	{
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				if (current.isMe(atlasPathOrName))
				{
					current.dispose();
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		removeDisposedAlasesFromList();
	}

	private void execLoad()
	{
		bool flag = false;
		IEnumerator<Atlas> enumerator = atlasList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Atlas current = enumerator.Current;
				current.update();
				if (current.IsDisposed)
				{
					flag = true;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (flag)
		{
			removeDisposedAlasesFromList();
		}
	}

	private void removeDisposedAlasesFromList()
	{
		atlasList.RemoveAll(_0024adaptor_0024__IconAtlasPool_0024callable359_0024643_30___0024Predicate_0024177.Adapt((Atlas ad) => ad.IsDisposed));
	}

	private void removeReqsBySprite(UISprite sprite)
	{
		_0024removeReqsBySprite_0024locals_002414472 _0024removeReqsBySprite_0024locals_0024 = new _0024removeReqsBySprite_0024locals_002414472();
		_0024removeReqsBySprite_0024locals_0024._0024sprite = sprite;
		if (!(_0024removeReqsBySprite_0024locals_0024._0024sprite == null))
		{
			reqs.RemoveAll(_0024adaptor_0024__IconAtlasPool_removeReqsBySprite_0024callable570_0024783_23___0024Predicate_0024178.Adapt(new _0024removeReqsBySprite_0024closure_00244002(_0024removeReqsBySprite_0024locals_0024).Invoke));
		}
	}

	public void Update()
	{
		if (!iconDb.IsBusy)
		{
			execLoad();
			execReqs();
		}
	}

	private void disposeAllRequests()
	{
		_log("IconAtlasPool dispose all setSprite requests");
		reqs.Clear();
	}

	private void execReqs()
	{
		if (reqs.Count <= 0)
		{
			return;
		}
		int num = 0;
		while (num < reqs.Count)
		{
			Req req = reqs[num];
			setSpriteByReq(req);
			switch (req.status)
			{
			case Req.DebugStatus.finished:
				reqs.RemoveAt(num);
				break;
			case Req.DebugStatus.couldNotFoundInDB:
				reqs.RemoveAt(num);
				break;
			default:
				num = checked(num + 1);
				break;
			}
		}
	}

	private void reqLoadBySpriteName(string spriteName)
	{
		Req spriteByReq = new Req(null, spriteName);
		setSpriteByReq(spriteByReq);
	}

	private bool setSpriteByReq(Req r)
	{
		int result;
		if (IsLoadingIconDb)
		{
			result = 0;
		}
		else
		{
			if (r.atlasName == null)
			{
				r.atlasName = iconDb.atlasNameOfSprite(r.spriteName);
				if (r.atlasName == null)
				{
					r.status = Req.DebugStatus.couldNotFoundInDB;
					result = 0;
					goto IL_00fe;
				}
			}
			Atlas atlas = r.reqAtlas;
			if (atlas == null)
			{
				atlas = findAtlasByName(r.atlasName);
				if (atlas == null)
				{
					r.status = Req.DebugStatus.requestingAtlas;
					atlas = reqLoad(r.atlasName);
					if (atlas == null)
					{
						result = 0;
						goto IL_00fe;
					}
				}
				r.reqAtlas = atlas;
			}
			if (!atlas.IsActive)
			{
				r.status = Req.DebugStatus.waitingAtlas;
				result = 0;
			}
			else
			{
				if (r.sprite != null)
				{
					r.sprite.atlas = atlas.Atlas;
					r.sprite.spriteName = r.spriteName;
				}
				r.status = Req.DebugStatus.finished;
				setSpriteFinish(r, atlas.Atlas);
				result = 1;
			}
		}
		goto IL_00fe;
		IL_00fe:
		return (byte)result != 0;
	}

	private void setSpriteFinish(Req r, UIAtlas atlas)
	{
		if (atlas == null)
		{
		}
		if (r == null || null == r.sprite || r.callback == null)
		{
			return;
		}
		try
		{
			r.callback(atlas);
		}
		catch (Exception)
		{
		}
	}

	private UIAtlas getAtlas(string spriteName)
	{
		return null;
	}

	private static void _log(string s)
	{
	}

	internal IEnumerator _0024loadIconDB_0024loadAndInit_00242795()
	{
		return new _0024_0024loadIconDB_0024loadAndInit_00242795_002421378(this).GetEnumerator();
	}

	internal void _0024reqLoadByEquipments_0024reqLoad_00243999(JsonBase resp)
	{
		if (resp != null)
		{
			if (resp is RespWeapon)
			{
				reqLoadBySpriteName(((RespWeapon)resp).Icon);
			}
			if (resp is RespPoppet)
			{
				reqLoadBySpriteName(((RespPoppet)resp).Icon);
			}
		}
	}

	internal void _0024reqLoadBoxItemAtlases_0024addSprite_00244000(JsonBase resp, ref HashSet<string> hash, bool load)
	{
		if (load && resp != null)
		{
			if (resp is RespWeapon)
			{
				hash.Add(((RespWeapon)resp).Icon);
			}
			if (resp is RespPoppet)
			{
				hash.Add(((RespPoppet)resp).Icon);
			}
		}
	}

	internal bool _0024removeDisposedAlasesFromList_0024closure_00244001(Atlas ad)
	{
		return ad.IsDisposed;
	}
}
