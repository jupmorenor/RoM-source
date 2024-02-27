using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using ObjUtil;
using UnityEngine;

[Serializable]
public class RuntimeAssetBundleDB : MonoBehaviour
{
	[Serializable]
	public class Req
	{
		[Serializable]
		public enum Modes
		{
			Unprocessed,
			Processing,
			Succeeded,
			Failed
		}

		private bool isOk;

		private UnityEngine.Object asset;

		private string bundleName;

		private string assetPath;

		private Type assetType;

		private string error;

		private AssetBundleRequest syncer;

		private int retryNum;

		private Modes mode;

		protected bool withInstantiation;

		private __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ handler;

		private bool silent;

		private __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ gameObjectHandler;

		private __Req_FailHandler_0024callable6_0024440_32__ failHandler;

		private int workingCounter;

		private bool _0024initialized__RuntimeAssetBundleDB_Req_0024;

		public string AssetName => Path.GetFileNameWithoutExtension(AssetPath);

		public string AssetPathInResources
		{
			get
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(assetPath);
				string directoryName = Path.GetDirectoryName(assetPath);
				string text = Path.Combine(directoryName, fileNameWithoutExtension).Replace("\\", "/");
				string text2 = "/Resources/";
				int num = text.IndexOf(text2);
				if (num >= 0)
				{
					string text3 = text;
					text = text3.Substring(RuntimeServices.NormalizeStringIndex(text3, checked(num + text2.Length)));
				}
				return text;
			}
		}

		public string PrefabName => AssetName;

		public GameObject Prefab => asset as GameObject;

		public string AssetTypeName => (assetType == null) ? null : assetType.Name;

		public bool IsEnd
		{
			get
			{
				bool isError = isOk;
				if (!isError)
				{
					isError = IsError;
				}
				return isError;
			}
		}

		public bool IsError => !string.IsNullOrEmpty(error);

		public bool IsValid => !string.IsNullOrEmpty(AssetName);

		public bool IsOk => isOk;

		public UnityEngine.Object Asset => asset;

		public string BundleName => bundleName;

		public string AssetPath => assetPath;

		public Type AssetType => assetType;

		public string Error => error;

		public AssetBundleRequest Syncer
		{
			get
			{
				return syncer;
			}
			set
			{
				syncer = value;
			}
		}

		public int RetryNum => retryNum;

		public Modes Mode => mode;

		public bool WithInstantiation
		{
			get
			{
				return withInstantiation;
			}
			set
			{
				withInstantiation = value;
			}
		}

		public __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ Handler
		{
			get
			{
				return handler;
			}
			set
			{
				handler = value;
			}
		}

		public bool Silent
		{
			get
			{
				return silent;
			}
			set
			{
				silent = value;
			}
		}

		public __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ GameObjectHandler
		{
			get
			{
				return gameObjectHandler;
			}
			set
			{
				gameObjectHandler = value;
			}
		}

		public __Req_FailHandler_0024callable6_0024440_32__ FailHandler
		{
			get
			{
				return failHandler;
			}
			set
			{
				failHandler = value;
			}
		}

		public int WorkingCounter
		{
			get
			{
				return workingCounter;
			}
			set
			{
				workingCounter = value;
			}
		}

		public Req(string assetPath)
		{
			if (!_0024initialized__RuntimeAssetBundleDB_Req_0024)
			{
				mode = Modes.Unprocessed;
				_0024initialized__RuntimeAssetBundleDB_Req_0024 = true;
			}
			if (string.IsNullOrEmpty(assetPath))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(assetPath)");
			}
			this.assetPath = assetPath;
		}

		public Req(string assetPath, Type assetType)
		{
			if (!_0024initialized__RuntimeAssetBundleDB_Req_0024)
			{
				mode = Modes.Unprocessed;
				_0024initialized__RuntimeAssetBundleDB_Req_0024 = true;
			}
			if (string.IsNullOrEmpty(assetPath))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(assetPath)");
			}
			this.assetPath = assetPath;
			this.assetType = assetType;
		}

		public override string ToString()
		{
			string result;
			if (syncer == null)
			{
				result = new StringBuilder("(").Append(AssetName).Append(": bundle:").Append(bundleName)
					.Append(" ")
					.Append(mode)
					.Append(" ok:")
					.Append(isOk)
					.Append(" err:")
					.Append(Error)
					.Append(" retry:")
					.Append((object)retryNum)
					.Append(" wcnt:")
					.Append((object)workingCounter)
					.Append(")")
					.ToString();
			}
			else
			{
				float progress = syncer.progress;
				result = new StringBuilder("(").Append(AssetName).Append(": bundle:").Append(bundleName)
					.Append(" ")
					.Append(mode)
					.Append(" ok:")
					.Append(isOk)
					.Append(" err:")
					.Append(Error)
					.Append(" prg:")
					.Append(progress)
					.Append(" retry:")
					.Append((object)retryNum)
					.Append(" wcnt:")
					.Append((object)workingCounter)
					.Append(")")
					.ToString();
			}
			return result;
		}

		public void setError(string msg)
		{
			if (string.IsNullOrEmpty(msg))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(msg)");
			}
			error = msg;
		}

		public void setRetry()
		{
			mode = Modes.Unprocessed;
			syncer = null;
			checked
			{
				retryNum++;
				workingCounter = 0;
			}
		}

		public void setProcessing()
		{
			mode = Modes.Processing;
		}

		public void fail()
		{
			mode = Modes.Failed;
			try
			{
				if (failHandler != null)
				{
					failHandler(assetPath);
				}
			}
			catch (Exception)
			{
			}
		}

		public void setOk(UnityEngine.Object obj)
		{
			if (!(obj != null))
			{
				throw new AssertionFailedException("obj != null");
			}
			isOk = true;
			asset = obj;
			mode = Modes.Succeeded;
			if (withInstantiation)
			{
				UnityEngine.Object @object = UnityEngine.Object.Instantiate(obj);
				if (!(@object != null))
				{
					throw new AssertionFailedException(new StringBuilder().Append(assetPath).Append("をInstantiateできなかった。元obj:").Append(obj)
						.ToString());
				}
				asset = @object;
			}
			try
			{
				if (handler != null)
				{
					handler(this, asset);
				}
			}
			catch (Exception)
			{
			}
			try
			{
				if (asset is GameObject && gameObjectHandler != null)
				{
					gameObjectHandler(asset as GameObject);
				}
			}
			catch (Exception)
			{
			}
		}

		public void setBundleName(string bname)
		{
			if (string.IsNullOrEmpty(bname))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(bname)");
			}
			bundleName = bname;
		}
	}

	[Serializable]
	internal class _0024getValues_0024locals_002414272
	{
		internal Boo.Lang.List<string> _0024r;
	}

	[Serializable]
	internal class _0024SafeInstantiatePrefab_0024locals_002414273
	{
		internal MonoBehaviour _0024selfBh;

		internal __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ _0024handler;
	}

	[Serializable]
	internal class _0024getValues_0024addArrayValues_00243997
	{
		internal _0024getValues_0024locals_002414272 _0024_0024locals_002414593;

		public _0024getValues_0024addArrayValues_00243997(_0024getValues_0024locals_002414272 _0024_0024locals_002414593)
		{
			this._0024_0024locals_002414593 = _0024_0024locals_002414593;
		}

		public void Invoke(Hashtable ah, object k)
		{
			if (ah == null || !ah.ContainsKey(k) || !(ah[k] is ArrayList arrayList))
			{
				return;
			}
			IEnumerator enumerator = arrayList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (!string.IsNullOrEmpty(text))
				{
					_0024_0024locals_002414593._0024r.Add(text);
				}
			}
		}
	}

	[Serializable]
	internal class _0024SafeInstantiatePrefab_0024closure_00243998
	{
		internal _0024SafeInstantiatePrefab_0024locals_002414273 _0024_0024locals_002414594;

		public _0024SafeInstantiatePrefab_0024closure_00243998(_0024SafeInstantiatePrefab_0024locals_002414273 _0024_0024locals_002414594)
		{
			this._0024_0024locals_002414594 = _0024_0024locals_002414594;
		}

		public void Invoke(GameObject go)
		{
			if (_0024_0024locals_002414594._0024selfBh != null && _0024_0024locals_002414594._0024handler != null)
			{
				_0024_0024locals_002414594._0024handler(go);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024mainRoutine_002415303 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal Req _0024r_002415304;

			internal IEnumerator _0024_0024sco_0024temp_0024197_002415305;

			internal IEnumerator _0024_0024sco_0024temp_0024198_002415306;

			internal RuntimeAssetBundleDB _0024self__002415307;

			public _0024(RuntimeAssetBundleDB self_)
			{
				_0024self__002415307 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				int result;
				checked
				{
					try
					{
						switch (_state)
						{
						default:
							_state = 2;
							goto case 3;
						case 3:
							while (true)
							{
								if (_0024self__002415307.workingQ.Count <= 0)
								{
									_0024self__002415307.waitingCounter++;
									flag = YieldDefault(3);
									goto IL_012a;
								}
								_0024r_002415304 = _0024self__002415307.workingQ.Dequeue();
								if (_0024r_002415304 == null)
								{
									continue;
								}
								break;
							}
							goto case 4;
						case 4:
							if (_0024self__002415307.CurNumOfProcessReqs >= 20)
							{
								_0024self__002415307.waitingCounter++;
								flag = YieldDefault(4);
								goto IL_012a;
							}
							_0024_0024sco_0024temp_0024197_002415305 = _0024self__002415307.processReq(_0024r_002415304);
							if (_0024_0024sco_0024temp_0024197_002415305 != null)
							{
								_0024self__002415307.StartCoroutine(_0024_0024sco_0024temp_0024197_002415305);
							}
							goto case 3;
						case 1:
						case 2:
							break;
						}
					}
					catch
					{
						//try-fault
						Dispose();
						throw;
					}
					result = 0;
					goto IL_012b;
				}
				IL_012b:
				return (byte)result != 0;
				IL_012a:
				result = (flag ? 1 : 0);
				goto IL_012b;
			}

			private void _0024ensure2()
			{
				_0024_0024sco_0024temp_0024198_002415306 = _0024self__002415307.mainRoutine();
				if (_0024_0024sco_0024temp_0024198_002415306 != null)
				{
					_0024self__002415307.StartCoroutine(_0024_0024sco_0024temp_0024198_002415306);
				}
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
				case 4:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal RuntimeAssetBundleDB _0024self__002415308;

		public _0024mainRoutine_002415303(RuntimeAssetBundleDB self_)
		{
			_0024self__002415308 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002415308);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024processReq_002415309 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024errMsg_002415310;

			internal string _0024bname_002415311;

			internal UnityEngine.Object _0024obj_002415312;

			internal string _0024assetPathInProject_002415313;

			internal string _0024rpath_002415314;

			internal AssetBundleLoader.Request _0024abr_002415315;

			internal float _0024_0024wait_until_0024temp_0024199_002415316;

			internal float _0024_0024wait_until_0024temp_0024200_002415317;

			internal Type _0024atype_002415318;

			internal AssetBundleRequest _0024syncer_002415319;

			internal GameObject _0024go_002415320;

			internal Req _0024r_002415321;

			internal RuntimeAssetBundleDB _0024self__002415322;

			public _0024(Req r, RuntimeAssetBundleDB self_)
			{
				_0024r_002415321 = r;
				_0024self__002415322 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024r_002415321 == null)
						{
							throw new AssertionFailedException("r != null");
						}
						if (false)
						{
						}
						_0024self__002415322.currentProcessingReqs.Add(_0024r_002415321);
						_0024self__002415322.totalProcessedReqNum++;
						goto IL_0066;
					case 2:
						if (!_0024abr_002415315.isEndOfLoad && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_0024200_002415317 < _0024_0024wait_until_0024temp_0024199_002415316)
						{
							_0024r_002415321.WorkingCounter += 1;
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024abr_002415315.ok)
						{
							_0024errMsg_002415310 = new StringBuilder("asset bundle ").Append(_0024bname_002415311).Append(" could not be loaded").ToString();
						}
						else
						{
							_0024atype_002415318 = ((_0024r_002415321.AssetType == null) ? typeof(UnityEngine.Object) : _0024r_002415321.AssetType);
							_0024r_002415321.WorkingCounter = 200000;
							if (1 == 0)
							{
								_0024r_002415321.WorkingCounter = 400000;
								_0024obj_002415312 = _0024abr_002415315.load(_0024r_002415321.AssetName, _0024atype_002415318);
								goto IL_040c;
							}
							_0024syncer_002415319 = _0024abr_002415315.loadAsync(_0024r_002415321.AssetName, _0024atype_002415318);
							_0024r_002415321.Syncer = _0024syncer_002415319;
							if (_0024syncer_002415319 != null)
							{
								goto case 3;
							}
							_0024errMsg_002415310 = "asset bundle req error: syncer == null";
						}
						goto IL_0529;
					case 3:
						if (!_0024syncer_002415319.isDone)
						{
							_0024r_002415321.WorkingCounter += 1;
							result = (YieldDefault(3) ? 1 : 0);
							break;
						}
						if (_0024abr_002415315.ok)
						{
							_0024obj_002415312 = _0024syncer_002415319.asset;
							goto IL_040c;
						}
						_0024errMsg_002415310 = new StringBuilder("asset bundle req error: invalid req ").Append(_0024abr_002415315).ToString();
						goto IL_0529;
					case 1:
						{
							result = 0;
							break;
						}
						IL_040c:
						_0024r_002415321.WorkingCounter = 500000;
						_0024go_002415320 = _0024obj_002415312 as GameObject;
						if (_0024go_002415320 != null && false)
						{
							AssetBundleLoader.ReloadShader(_0024go_002415320);
						}
						goto IL_044f;
						IL_0066:
						_0024r_002415321.setProcessing();
						_0024errMsg_002415310 = string.Empty;
						if (!_0024r_002415321.IsValid)
						{
							_0024r_002415321.setError("RuntimeAssetBundleDB: invalid request: null or empty prefab name");
							_0024errMsg_002415310 = "prefab name is not valid";
							goto IL_0598;
						}
						_0024bname_002415311 = _0024self__002415322.bundleNameOf(_0024r_002415321.AssetName, _0024r_002415321.AssetTypeName);
						_0024obj_002415312 = null;
						_0024assetPathInProject_002415313 = null;
						if (string.IsNullOrEmpty(_0024bname_002415311))
						{
							_0024r_002415321.WorkingCounter = 800000;
							_0024rpath_002415314 = _0024r_002415321.AssetPathInResources;
							_0024obj_002415312 = Resources.Load(_0024rpath_002415314);
							if (_0024obj_002415312 == null)
							{
								_0024errMsg_002415310 = new StringBuilder().Append(_0024r_002415321.AssetName).Append(" is not contained in any asset bundles and could not loaded from Resources/").ToString();
							}
						}
						else
						{
							if (string.IsNullOrEmpty(_0024assetPathInProject_002415313))
							{
								_0024r_002415321.setBundleName(_0024bname_002415311);
								_0024abr_002415315 = AssetBundleLoader.ReqBundle(_0024bname_002415311);
								_0024r_002415321.WorkingCounter = 100000;
								_0024_0024wait_until_0024temp_0024199_002415316 = 30f;
								_0024_0024wait_until_0024temp_0024200_002415317 = Time.realtimeSinceStartup;
								goto case 2;
							}
							_0024r_002415321.WorkingCounter = 700000;
							_0024obj_002415312 = Resources.LoadAssetAtPath(_0024assetPathInProject_002415313, typeof(UnityEngine.Object));
							if (_0024obj_002415312 == null)
							{
								throw new Exception(new StringBuilder("アセットバンドルに ").Append(_0024r_002415321.AssetName).Append(" が登録されていません！").ToString());
							}
						}
						goto IL_044f;
						IL_0598:
						if (!_0024r_002415321.Silent || (false ? true : false))
						{
						}
						_0024r_002415321.WorkingCounter = 900000;
						_0024self__002415322.errorReqNum++;
						_0024r_002415321.fail();
						_0024self__002415322.currentProcessingReqs.Remove(_0024r_002415321);
						YieldDefault(1);
						goto case 1;
						IL_0529:
						_0024self__002415322.errorReqNum++;
						if (_0024r_002415321.RetryNum < 4)
						{
							if (false)
							{
							}
							_0024r_002415321.setRetry();
							if (_0024self__002415322.workingQ.Contains(_0024r_002415321))
							{
								throw new AssertionFailedException("not workingQ.Contains(r)");
							}
							goto IL_0066;
						}
						goto IL_0598;
						IL_044f:
						if (_0024obj_002415312 == null)
						{
							_0024r_002415321.WorkingCounter = 610000;
							_0024r_002415321.setError(new StringBuilder("RuntimeAssetBundleDB: could not load ").Append(_0024r_002415321.AssetPath).Append("\nPath in Resources: ").Append(_0024r_002415321.AssetPathInResources)
								.ToString());
							_0024errMsg_002415310 = "the specified asset could not be loaded";
							goto IL_0598;
						}
						_0024r_002415321.WorkingCounter = 620000;
						_0024r_002415321.setOk(_0024obj_002415312);
						if (false)
						{
						}
						_0024r_002415321.WorkingCounter = -_0024r_002415321.WorkingCounter;
						_0024self__002415322.currentProcessingReqs.Remove(_0024r_002415321);
						goto case 1;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Req _0024r_002415323;

		internal RuntimeAssetBundleDB _0024self__002415324;

		public _0024processReq_002415309(Req r, RuntimeAssetBundleDB self_)
		{
			_0024r_002415323 = r;
			_0024self__002415324 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024r_002415323, _0024self__002415324);
		}
	}

	[NonSerialized]
	private const bool RELOAD_SHADER = false;

	[NonSerialized]
	private const string DB_FILENAME = "abdb.dat";

	[NonSerialized]
	private const bool ASYNC_MODE = true;

	[NonSerialized]
	private const int CONCURRENT_REQ_LIMIT = 20;

	[NonSerialized]
	private const int RETRY_LIMIT = 4;

	[NonSerialized]
	public const string DB_EDITOR_ASSET_PATH_KEY = "$Path$";

	[NonSerialized]
	private const bool DISABLE_SILENT_FLAG = false;

	[NonSerialized]
	private const bool VERBOSE = false;

	[NonSerialized]
	private static RuntimeAssetBundleDB _instance;

	private Hashtable db;

	private Queue<Req> workingQ;

	private int totalProcessedReqNum;

	private int errorReqNum;

	private int waitingCounter;

	private Boo.Lang.List<Req> currentProcessingReqs;

	public static RuntimeAssetBundleDB Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject component = AssetBundleLoader.Instance.gameObject;
				_instance = ExtensionsModule.SetComponent<RuntimeAssetBundleDB>(component);
				if (!(_instance != null))
				{
					throw new AssertionFailedException("_instance != null");
				}
			}
			return _instance;
		}
	}

	public bool HasSavedData
	{
		get
		{
			string value = ObjUtilModule.LoadString("abdb.dat");
			return !string.IsNullOrEmpty(value);
		}
	}

	public int CurNumOfProcessReqs => currentProcessingReqs.Count;

	public Queue<Req> WorkingQueue => workingQ;

	public int TotalProcessedReqNum => totalProcessedReqNum;

	public int ErrorReqNum => errorReqNum;

	public int WaitingCounter => waitingCounter;

	public Boo.Lang.List<Req> CurrentProcessingReqs => currentProcessingReqs;

	public RuntimeAssetBundleDB()
	{
		db = new Hashtable();
		workingQ = new Queue<Req>();
		currentProcessingReqs = new Boo.Lang.List<Req>();
	}

	public static void Kill()
	{
		if (_instance != null)
		{
			UnityEngine.Object.Destroy(_instance);
			_instance = null;
		}
	}

	public void Awake()
	{
	}

	public void Start()
	{
		StartCoroutine(mainRoutine());
	}

	private void loadOnFileSystem()
	{
		string path = AssetBundlePath.Current.JsonDBPathInProjectDir();
		try
		{
			string dbJson = File.ReadAllText(path);
			initialize(dbJson);
		}
		catch (Exception)
		{
		}
	}

	public void initialize(string dbJson)
	{
		if (string.IsNullOrEmpty(dbJson))
		{
			throw new AssertionFailedException("RuntimeAssetBundleDB:dbJsonがnull/empty");
		}
		object obj = NGUIJson.jsonDecode(dbJson);
		if (obj == null || !(obj is Hashtable))
		{
			throw new AssertionFailedException("(jobj != null) and (jobj isa Hashtable)");
		}
		object obj2 = obj;
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		db = (Hashtable)obj2;
		ObjUtilModule.SaveString("abdb.dat", dbJson);
	}

	public void initializeFromSavedData()
	{
		try
		{
			string text = ObjUtilModule.LoadString("abdb.dat");
			if (!string.IsNullOrEmpty(text))
			{
				initialize(text);
			}
		}
		catch (Exception)
		{
		}
	}

	public void clearCurrentSavedData()
	{
		ObjUtilModule.SaveString("abdb.dat", string.Empty);
	}

	private void checkEditor()
	{
		if (((ICollection)db).Count > 0)
		{
		}
	}

	public string[] allBundleNamesOf(string assetName, Type type)
	{
		return (type == null) ? allBundleNamesOf(assetName, string.Empty) : allBundleNamesOf(assetName, type.Name);
	}

	public string[] allBundleNamesOf(string assetName, string typeName)
	{
		checkEditor();
		if (string.IsNullOrEmpty(assetName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(assetName)");
		}
		string[] array = new string[0];
		Hashtable dbEntry = getDbEntry(assetName);
		string[] result;
		if (dbEntry != null)
		{
			string[] values = getValues(dbEntry, typeName);
			result = values;
		}
		else
		{
			result = array;
		}
		return result;
	}

	private Hashtable getDbEntry(string assetName)
	{
		Hashtable result = null;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(assetName);
		if (db.ContainsKey(fileNameWithoutExtension))
		{
			result = db[fileNameWithoutExtension] as Hashtable;
		}
		else if (db.ContainsKey(assetName))
		{
			result = db[assetName] as Hashtable;
		}
		return result;
	}

	private string getAssetPathInProject(string assetName)
	{
		object result;
		if (string.IsNullOrEmpty(assetName))
		{
			result = null;
		}
		else
		{
			Hashtable dbEntry = getDbEntry(assetName);
			result = ((dbEntry == null || !dbEntry.ContainsKey("$Path$")) ? null : (dbEntry["$Path$"] as string));
		}
		return (string)result;
	}

	public string[] allAssetNamesPrefixedBy(string prefix)
	{
		Boo.Lang.List<string> list = new Boo.Lang.List<string>();
		IEnumerator enumerator = db.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			if (!string.IsNullOrEmpty(text) && text.StartsWith(prefix))
			{
				list.Add(text);
			}
		}
		return (string[])Builtins.array(typeof(string), list);
	}

	private string[] getValues(Hashtable h, string key)
	{
		_0024getValues_0024locals_002414272 _0024getValues_0024locals_0024 = new _0024getValues_0024locals_002414272();
		_0024getValues_0024locals_0024._0024r = new Boo.Lang.List<string>();
		__RuntimeAssetBundleDB_getValues_0024callable177_0024177_13__ _RuntimeAssetBundleDB_getValues_0024callable177_0024177_13__ = new _0024getValues_0024addArrayValues_00243997(_0024getValues_0024locals_0024).Invoke;
		if (string.IsNullOrEmpty(key))
		{
			IEnumerator enumerator = h.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (!RuntimeServices.EqualityOperator(current, "$Path$"))
				{
					_RuntimeAssetBundleDB_getValues_0024callable177_0024177_13__(h, current);
				}
			}
		}
		else if (h.ContainsKey(key))
		{
			_RuntimeAssetBundleDB_getValues_0024callable177_0024177_13__(h, key);
		}
		return (string[])Builtins.array(typeof(string), _0024getValues_0024locals_0024._0024r);
	}

	public string[] allBundleNamesOf(string prefabName)
	{
		checkEditor();
		return allBundleNamesOf(prefabName, "GameObject");
	}

	public string bundleNameOf(string assetName, Type type)
	{
		return (type == null) ? bundleNameOf(assetName, string.Empty) : bundleNameOf(assetName, type.Name);
	}

	public string bundleNameOf(string assetName, string typeName)
	{
		string[] array = allBundleNamesOf(assetName, typeName);
		return (array.Length <= 0) ? null : array[0];
	}

	public string bundleNameOf(string prefabName)
	{
		string[] array = allBundleNamesOf(prefabName);
		return (array.Length <= 0) ? null : array[0];
	}

	public Req loadPrefab(string prefabName)
	{
		return loadPrefab(prefabName, instantiate: false, null);
	}

	public Req loadPrefab(string prefabName, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ handler)
	{
		return loadPrefab(prefabName, instantiate: false, handler);
	}

	public Req instantiatePrefab(string prefabName)
	{
		return loadPrefab(prefabName, instantiate: true, null);
	}

	public Req instantiatePrefab(string prefabName, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ handler)
	{
		return loadPrefab(prefabName, instantiate: true, handler);
	}

	public static Req SafeInstantiatePrefab(MonoBehaviour selfBh, string prefabName, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ handler)
	{
		_0024SafeInstantiatePrefab_0024locals_002414273 _0024SafeInstantiatePrefab_0024locals_0024 = new _0024SafeInstantiatePrefab_0024locals_002414273();
		_0024SafeInstantiatePrefab_0024locals_0024._0024selfBh = selfBh;
		_0024SafeInstantiatePrefab_0024locals_0024._0024handler = handler;
		if (!(_0024SafeInstantiatePrefab_0024locals_0024._0024selfBh == null))
		{
			Instance.instantiatePrefab(prefabName, new _0024SafeInstantiatePrefab_0024closure_00243998(_0024SafeInstantiatePrefab_0024locals_0024).Invoke);
		}
		return null;
	}

	public Req loadPrefab(string prefabName, bool instantiate, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ handler)
	{
		if (string.IsNullOrEmpty(prefabName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(prefabName)");
		}
		Req req = new Req(prefabName, typeof(GameObject));
		req.GameObjectHandler = handler;
		req.WithInstantiation = instantiate;
		workingQ.Enqueue(req);
		if (false)
		{
		}
		return req;
	}

	public Req loadAsset(string assetName)
	{
		return loadAsset(assetName, null, instantiate: false, null);
	}

	public Req loadAsset(string assetName, __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ handler)
	{
		return loadAsset(assetName, null, instantiate: false, handler);
	}

	public Req loadAsset(string assetName, Type type)
	{
		return loadAsset(assetName, type, instantiate: false, null);
	}

	public Req loadAsset(string assetName, Type type, __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ handler)
	{
		return loadAsset(assetName, type, instantiate: false, handler);
	}

	public Req loadAsset(string assetName, bool instantiate)
	{
		return loadAsset(assetName, null, instantiate, null);
	}

	public Req loadAsset(string assetName, bool instantiate, __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ handler)
	{
		return loadAsset(assetName, null, instantiate, handler);
	}

	public Req loadAsset(string assetName, Type type, bool instantiate, __RuntimeAssetBundleDB_loadAsset_0024callable5_0024275_59__ handler)
	{
		if (string.IsNullOrEmpty(assetName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(assetName)");
		}
		Req req = new Req(assetName, type);
		req.Handler = handler;
		req.WithInstantiation = instantiate;
		workingQ.Enqueue(req);
		if (false)
		{
		}
		return req;
	}

	public Req loadPackedScenePrefab(string sceneName)
	{
		object result;
		if (string.IsNullOrEmpty(sceneName))
		{
			result = null;
		}
		else
		{
			string prefabName = ScenePackerMixin.PrefabName(sceneName);
			result = ((!(bundleNameOf(prefabName) == null)) ? loadPrefab(prefabName) : null);
		}
		return (Req)result;
	}

	public bool isPackedSceneName(string sceneName)
	{
		int result;
		if (string.IsNullOrEmpty(sceneName))
		{
			result = 0;
		}
		else
		{
			string prefabName = ScenePackerMixin.PrefabName(sceneName);
			result = ((!string.IsNullOrEmpty(bundleNameOf(prefabName))) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public void unloadAll()
	{
		if (false)
		{
		}
		AssetBundleLoader.UnloadBundleAll();
	}

	private IEnumerator mainRoutine()
	{
		return new _0024mainRoutine_002415303(this).GetEnumerator();
	}

	private IEnumerator processReq(Req r)
	{
		return new _0024processReq_002415309(r, this).GetEnumerator();
	}

	public void dump()
	{
		string lhs = "RuntimeAssetBundleDB.dump()\n";
		IEnumerator enumerator = db.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object current = enumerator.Current;
			if (db[current] is Hashtable hashtable)
			{
				lhs += new StringBuilder().Append(current).Append(":\n").ToString();
				IEnumerator enumerator2 = hashtable.Keys.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object current2 = enumerator2.Current;
					lhs = ((!(hashtable[current2] is ArrayList enumerable)) ? (lhs + new StringBuilder("   ").Append(current2).Append(": not array list but ").Append(hashtable[current2])
						.ToString()) : (lhs + (new StringBuilder("   ").Append(current2).Append(": ").ToString() + Builtins.join(enumerable) + "\n")));
				}
			}
			else
			{
				lhs += new StringBuilder().Append(current).Append(": ERROR!!\n").ToString();
			}
		}
	}
}
