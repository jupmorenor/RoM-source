using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PerformanceSetting : PerformanceSettingBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002418358 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal bool _0024flag_002418359;

			internal bool _0024read_002418360;

			internal string _0024readPath_002418361;

			internal int _0024i_002418362;

			internal string _0024devName_002418363;

			internal bool _0024bLocal_002418364;

			internal int _0024_00249276_002418365;

			internal int _0024_00249277_002418366;

			internal PerformanceSetting _0024self__002418367;

			public _0024(PerformanceSetting self_)
			{
				_0024self__002418367 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!PerformanceSettingBase.enableDownloadDeviceList)
					{
						goto case 1;
					}
					_0024self__002418367.devicesJson = string.Empty;
					_0024flag_002418359 = false;
					_0024read_002418360 = false;
					_0024readPath_002418361 = null;
					if (string.IsNullOrEmpty(_0024self__002418367.devicesJson))
					{
						_0024_00249276_002418365 = 0;
						_0024_00249277_002418366 = PerformanceSetting.defDeviceFileNames.Length;
						if (_0024_00249277_002418366 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						goto IL_020e;
					}
					goto IL_021f;
				case 2:
					if (!www.isDone && www.error == null)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (www.isDone || !string.IsNullOrEmpty(www.error))
					{
						if (string.IsNullOrEmpty(www.text))
						{
							goto IL_020e;
						}
						_0024self__002418367.devicesJson = www.text;
						_0024read_002418360 = true;
					}
					goto IL_01e2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01e2:
					if (!_0024read_002418360)
					{
						goto IL_020e;
					}
					_0024self__002418367.txtVersion = checked(PerformanceSetting.defDeviceFileNames.Length - _0024i_002418362);
					goto IL_021f;
					IL_021f:
					if (_0024read_002418360)
					{
					}
					if (string.IsNullOrEmpty(_0024self__002418367.devicesJson))
					{
						_0024self__002418367.devicesJson = LoadDeviceCore();
					}
					if (!string.IsNullOrEmpty(_0024self__002418367.devicesJson))
					{
						_0024flag_002418359 = CheckDeviceCore(_0024self__002418367.devicesJson, _0024self__002418367.txtVersion);
					}
					if (!_0024flag_002418359)
					{
						PerformanceSettingBase.SetRezo("large");
						PerformanceSettingBase.SetSpec("lo");
						PerformanceSettingBase.SetRaidPlayerCap(3);
					}
					YieldDefault(1);
					goto case 1;
					IL_020e:
					while (_0024_00249276_002418365 < _0024_00249277_002418366)
					{
						_0024i_002418362 = _0024_00249276_002418365;
						_0024_00249276_002418365++;
						string[] defDeviceFileNames = PerformanceSetting.defDeviceFileNames;
						_0024devName_002418363 = defDeviceFileNames[RuntimeServices.NormalizeArrayIndex(defDeviceFileNames, _0024i_002418362)];
						_0024bLocal_002418364 = default(bool);
						_0024readPath_002418361 = _0024self__002418367.makeDevicesPath(_0024devName_002418363, ref _0024bLocal_002418364);
						if (!_0024bLocal_002418364)
						{
							try
							{
								www = new WWW(_0024readPath_002418361);
							}
							catch (Exception)
							{
								continue;
							}
							goto case 2;
						}
						goto IL_01b5;
					}
					goto IL_021f;
					IL_01b5:
					if (File.Exists(_0024readPath_002418361))
					{
						_0024self__002418367.devicesJson = File.ReadAllText(_0024readPath_002418361);
						_0024read_002418360 = true;
					}
					goto IL_01e2;
				}
				return (byte)result != 0;
			}
		}

		internal PerformanceSetting _0024self__002418368;

		public _0024main_002418358(PerformanceSetting self_)
		{
			_0024self__002418368 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002418368);
		}
	}

	[NonSerialized]
	private static PerformanceSetting __instance;

	[NonSerialized]
	protected static bool quitApp;

	protected SceneID lastSceneId;

	[NonSerialized]
	protected const string deviceFileName = "devices.txt";

	[NonSerialized]
	private const string defLocalDeviceDirName = "";

	private int txtVersion;

	[NonSerialized]
	protected static WWW www;

	protected string devicesJson;

	[NonSerialized]
	protected static bool debug;

	[NonSerialized]
	protected static readonly string[] defDeviceFileNames = new string[3] { "devices3.txt", "devices2.txt", "devices.txt" };

	public static PerformanceSetting Instance
	{
		get
		{
			PerformanceSetting _instance;
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
				__instance = ((PerformanceSetting)UnityEngine.Object.FindObjectOfType(typeof(PerformanceSetting))) as PerformanceSetting;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static PerformanceSetting CurrentInstance => __instance;

	public static bool DebugFlag
	{
		get
		{
			return debug;
		}
		set
		{
			debug = value;
		}
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241644();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static PerformanceSetting _createInstance()
	{
		string text = "__" + "PerformanceSetting" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		PerformanceSetting performanceSetting = ExtensionsModule.SetComponent<PerformanceSetting>(gameObject);
		if ((bool)performanceSetting)
		{
			performanceSetting._createInstance_callback();
		}
		return performanceSetting;
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

	public void _0024singleton_0024appQuit_00241645()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241645();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00241644()
	{
		lastSceneId = SceneChanger.CurrentScene;
		if (debug)
		{
			PerformanceSettingBase.enableDownloadDeviceList = false;
		}
		IEnumerator enumerator = main();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void Update()
	{
		if (lastSceneId != SceneChanger.CurrentScene)
		{
			lastSceneId = SceneChanger.CurrentScene;
			SceneChage();
		}
	}

	public void SceneChage()
	{
		if (PerformanceSettingBase.specLevel != EnumSpecLevel.Lo)
		{
			return;
		}
		SceneLightTable sceneLightTable = ((SceneLightTable)UnityEngine.Object.FindObjectOfType(typeof(SceneLightTable))) as SceneLightTable;
		if ((bool)sceneLightTable)
		{
			UnityEngine.Object.DestroyObject(sceneLightTable.gameObject);
		}
		Light[] array = ((Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light))) as Light[];
		int i = 0;
		Light[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			if ((bool)array2[i] && array2[i].shadows != 0)
			{
				UnityEngine.Object.DestroyObject(array2[i].gameObject);
			}
		}
	}

	public IEnumerator main()
	{
		return new _0024main_002418358(this).GetEnumerator();
	}

	private string makeDevicesPath(string aDevicesName, ref bool aResultLocal)
	{
		string text = null;
		if (string.IsNullOrEmpty(""))
		{
			text = AssetBundlePath.RuntimeDataPath(aDevicesName);
			aResultLocal = false;
		}
		else
		{
			text = "" + aDevicesName;
			aResultLocal = true;
		}
		return text;
	}

	public static bool CheckDeviceCore(string json, int aTxtVersion)
	{
		int result;
		if (!(NGUIJson.jsonDecode(json) is Hashtable hashtable))
		{
			result = 0;
		}
		else
		{
			Hashtable hashtable2 = new Hashtable();
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				hashtable2[text.ToLower()] = hashtable[text];
			}
			string text2 = PerformanceSettingBase.GetDeviceModel();
			if (string.IsNullOrEmpty(text2))
			{
				result = 0;
			}
			else
			{
				bool flag = false;
				string json2 = null;
				switch (aTxtVersion)
				{
				case 1:
				{
					text2 = text2.ToLower();
					string text3 = string.Empty;
					if (hashtable2.ContainsKey(text2))
					{
						object obj2 = hashtable2[text2];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						text3 = (string)obj2;
					}
					if (!string.IsNullOrEmpty(text3))
					{
						string[] array = text3.Split(',');
						if (array.Length == 2)
						{
							PerformanceSettingBase.SetRezo(array[0]);
							PerformanceSettingBase.SetSpec(array[1]);
							json2 = new StringBuilder("{'").Append(text2).Append("':'").Append(array[0])
								.Append(",")
								.Append(array[1])
								.Append("',},")
								.ToString();
							flag = true;
						}
					}
					break;
				}
				case 2:
				{
					string aResultRezo = null;
					string aResultSpec = null;
					int aResultRaidcap = default(int);
					makeDefaultDetail(hashtable2, ref aResultRezo, ref aResultSpec, ref aResultRaidcap);
					makeDetail(hashtable2, text2, ref aResultRezo, ref aResultSpec, ref aResultRaidcap);
					PerformanceSettingBase.SetRezo(aResultRezo);
					PerformanceSettingBase.SetSpec(aResultSpec);
					PerformanceSettingBase.SetRaidPlayerCap(aResultRaidcap);
					json2 = new StringBuilder("{'").Append(text2).Append("':'").Append(aResultRezo)
						.Append(",")
						.Append(aResultSpec)
						.Append(",")
						.Append(PerformanceSettingBase.raidPlayerCapString)
						.Append("',},")
						.ToString();
					flag = true;
					break;
				}
				case 3:
				{
					string aResultKamcord = null;
					string aResultRezo = default(string);
					string aResultSpec = default(string);
					int aResultRaidcap = default(int);
					makeDefaultDetail3(hashtable2, ref aResultRezo, ref aResultSpec, ref aResultRaidcap, ref aResultKamcord);
					makeDetail3(hashtable2, text2, ref aResultRezo, ref aResultSpec, ref aResultRaidcap, ref aResultKamcord);
					PerformanceSettingBase.SetRezo(aResultRezo);
					PerformanceSettingBase.SetSpec(aResultSpec);
					PerformanceSettingBase.SetRaidPlayerCap(aResultRaidcap);
					PerformanceSettingBase.SetKamcord(aResultKamcord);
					json2 = new StringBuilder("{'").Append(text2).Append("':'").Append(aResultRezo)
						.Append(",")
						.Append(aResultSpec)
						.Append(",")
						.Append(PerformanceSettingBase.raidPlayerCapString)
						.Append(",")
						.Append(aResultKamcord)
						.Append("',},")
						.ToString();
					flag = true;
					break;
				}
				}
				if (flag)
				{
					SaveDeviceCore(json2);
				}
				result = (flag ? 1 : 0);
			}
		}
		return (byte)result != 0;
	}

	private static void makeDefaultDetail3(Hashtable aDevTable, ref string aResultRezo, ref string aResultSpec, ref int aResultRaidcap, ref string aResultKamcord)
	{
		aResultRezo = "large";
		aResultSpec = "lo";
		aResultRaidcap = 3;
		aResultKamcord = "true";
		string aDevName = "DEFAULT";
		makeDetail3(aDevTable, aDevName, ref aResultRezo, ref aResultSpec, ref aResultRaidcap, ref aResultKamcord);
	}

	private static void makeDetail3(Hashtable aDevTable, string aDevName, ref string aResultRezo, ref string aResultSpec, ref int aResultRaidcap, ref string aResultKamcord)
	{
		string key = aDevName.ToLower();
		object obj = default(object);
		if (aDevTable.ContainsKey(key))
		{
			obj = aDevTable[key];
		}
		if (obj == null)
		{
			return;
		}
		object obj2 = obj;
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		Hashtable hashtable = makeLowKeyTable((Hashtable)obj2);
		if (hashtable.ContainsKey("rezo"))
		{
			object obj3 = hashtable["rezo"];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			aResultRezo = (string)obj3;
		}
		if (hashtable.ContainsKey("spec"))
		{
			object obj4 = hashtable["spec"];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			aResultSpec = (string)obj4;
		}
		if (hashtable.ContainsKey("raidcap"))
		{
			object obj5 = hashtable["raidcap"];
			object obj6 = obj5;
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			aResultRaidcap = int.Parse((string)obj6);
		}
		if (hashtable.ContainsKey("kamcord"))
		{
			object obj7 = hashtable["kamcord"];
			if (!(obj7 is string))
			{
				obj7 = RuntimeServices.Coerce(obj7, typeof(string));
			}
			aResultKamcord = (string)obj7;
		}
	}

	private static void makeDefaultDetail(Hashtable aDevTable, ref string aResultRezo, ref string aResultSpec, ref int aResultRaidcap)
	{
		aResultRezo = "large";
		aResultSpec = "lo";
		aResultRaidcap = 3;
		string aDevName = "DEFAULT";
		makeDetail(aDevTable, aDevName, ref aResultRezo, ref aResultSpec, ref aResultRaidcap);
	}

	private static void makeDetail(Hashtable aDevTable, string aDevName, ref string aResultRezo, ref string aResultSpec, ref int aResultRaidcap)
	{
		string key = aDevName.ToLower();
		object obj = default(object);
		if (aDevTable.ContainsKey(key))
		{
			obj = aDevTable[key];
		}
		if (obj == null)
		{
			return;
		}
		object obj2 = obj;
		if (!(obj2 is Hashtable))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(Hashtable));
		}
		Hashtable hashtable = makeLowKeyTable((Hashtable)obj2);
		if (hashtable.ContainsKey("rezo"))
		{
			object obj3 = hashtable["rezo"];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			aResultRezo = (string)obj3;
		}
		if (hashtable.ContainsKey("spec"))
		{
			object obj4 = hashtable["spec"];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			aResultSpec = (string)obj4;
		}
		if (hashtable.ContainsKey("raidcap"))
		{
			object obj5 = hashtable["raidcap"];
			object obj6 = obj5;
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			aResultRaidcap = int.Parse((string)obj6);
		}
	}

	private static Hashtable makeLowKeyTable(Hashtable aTable)
	{
		Hashtable hashtable = new Hashtable();
		IEnumerator enumerator = aTable.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			string text = (string)obj;
			hashtable[text.ToLower()] = aTable[text];
		}
		return hashtable;
	}

	public static void SaveDeviceCore(string json)
	{
		try
		{
			PlayerPrefs.SetString("devices.txt", json);
		}
		catch (Exception)
		{
		}
	}

	public static string LoadDeviceCore()
	{
		string empty = string.Empty;
		string @string = default(string);
		try
		{
			@string = PlayerPrefs.GetString("devices.txt", string.Empty);
			return @string;
		}
		catch (Exception)
		{
			PlayerPrefs.SetString("devices.txt", string.Empty);
		}
		return @string;
	}

	public new void OnGUI()
	{
		if (!debug)
		{
			return;
		}
		base.OnGUI();
		if (PerformanceSettingBase.checkSpec && PerformanceSettingBase.checkRezo)
		{
			return;
		}
		GUILayout.Label(PerformanceSettingBase.GetDeviceModel());
		if (GUILayout.Button("DownLoadDeviceList"))
		{
			debug = false;
			PerformanceSettingBase.enableDownloadDeviceList = true;
			IEnumerator enumerator = main();
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}
}
