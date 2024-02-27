using UnityEngine;

public class PerformanceSettingBase : MonoBehaviour
{
	public enum EnumSpecLevel
	{
		Default,
		Lo,
		Hi
	}

	public enum EnumRezoLevel
	{
		Default,
		Normal,
		Large,
		Xlarge
	}

	public const int raidPlayerCapMin = 1;

	public const int raidPlayerCapMax = 4;

	public const int raidPlayerCapInitial = 3;

	public static bool enableDownloadDeviceList = false;

	public static string deviceModel;

	public static EnumSpecLevel specLevel = EnumSpecLevel.Default;

	public static bool checkSpec;

	public static string specString;

	public static EnumRezoLevel rezoLevel = EnumRezoLevel.Default;

	private static float[] rezoParam = new float[4] { 0f, 320f, 480f, 720f };

	public static bool checkRezo;

	public static float screenRate = 1f;

	public static string rezoString;

	public static int raidPlayerCap = 3;

	public static string raidPlayerCapString = 3.ToString();

	public static bool checkKamcord;

	public static bool enableKamcord = true;

	public static string kamcordString;

	public static void SetRezo(string rezo)
	{
		rezoString = rezo;
		Debug.Log($"SetRezo rezo={rezo}");
		screenRate = 1f;
		if (rezo.ToLower().CompareTo("xlarge") == 0)
		{
			rezoLevel = EnumRezoLevel.Xlarge;
			checkRezo = true;
			screenRate = rezoParam[(int)rezoLevel] / (float)Screen.height;
			Debug.Log("SetRezo=Xlarge(720)");
		}
		else if (rezo.ToLower().CompareTo("large") == 0)
		{
			rezoLevel = EnumRezoLevel.Large;
			checkRezo = true;
			screenRate = rezoParam[(int)rezoLevel] / (float)Screen.height;
			Debug.Log("SetRezo=Large(480)");
		}
		else if (rezo.ToLower().CompareTo("normal") == 0)
		{
			rezoLevel = EnumRezoLevel.Normal;
			checkRezo = true;
			screenRate = rezoParam[(int)rezoLevel] / (float)Screen.height;
			Debug.Log("SetRezo=Normal(320)");
		}
		else if (rezo.ToLower().CompareTo("default") == 0)
		{
			rezoLevel = EnumRezoLevel.Default;
			checkRezo = true;
			Debug.Log("SetRezo=Default");
		}
		else
		{
			rezoLevel = EnumRezoLevel.Large;
			checkRezo = true;
			screenRate = rezoParam[(int)rezoLevel] / (float)Screen.height;
			Debug.Log("SetRezo=Large(480)(by null param)");
		}
		if (checkRezo)
		{
			float num = (float)Screen.width * screenRate;
			float num2 = (float)Screen.height * screenRate;
			Screen.SetResolution((int)num, (int)num2, fullscreen: true);
		}
		Debug.Log($"SetRezo checkRezo={checkRezo}");
	}

	public static void SetSpec(string spec)
	{
		specString = spec;
		Debug.Log($"SetSpec spec={spec}");
		if (spec.ToLower().CompareTo("lo") == 0)
		{
			specLevel = EnumSpecLevel.Lo;
			Debug.Log("SetSpec=Lo");
		}
		else if (spec.ToLower().CompareTo("default") == 0)
		{
			specLevel = EnumSpecLevel.Default;
			Debug.Log("SetSpec=Default");
		}
		else if (spec.ToLower().CompareTo("hi") == 0)
		{
			specLevel = EnumSpecLevel.Hi;
			Debug.Log("SetSpec=Hi");
		}
		else
		{
			specLevel = EnumSpecLevel.Lo;
			Debug.Log("SetSpec=Lo(by null param)");
		}
		Debug.Log("checkSpec = true");
		checkSpec = true;
	}

	public static void SetRaidPlayerCap(int aRaidPlayerCap)
	{
		raidPlayerCap = aRaidPlayerCap;
		raidPlayerCapString = $"{aRaidPlayerCap}";
	}

	public static void SetRaidPlayerCap(string aRaidPlayerCapStr)
	{
		raidPlayerCap = int.Parse(aRaidPlayerCapStr);
		raidPlayerCapString = aRaidPlayerCapStr;
	}

	public static void SetKamcord(string kamcord)
	{
		kamcordString = kamcord;
		Debug.Log($"SetKamcord kamcord={kamcord}");
		if (kamcord.ToLower().CompareTo("true") == 0)
		{
			enableKamcord = true;
			Debug.Log("SetKamcord=true");
		}
		else
		{
			enableKamcord = false;
			Debug.Log("SetKamcord=false");
		}
		Debug.Log("checkKamcord = true");
		checkKamcord = true;
	}

	public static string GetDeviceModel()
	{
		if (string.IsNullOrEmpty(deviceModel))
		{
			return GetAndroidDeviceModel();
		}
		return deviceModel;
	}

	public static string GetDefaultDeviceModel()
	{
		deviceModel = SystemInfo.deviceModel;
		return deviceModel;
	}

	public static string GetIOSDeviceModel()
	{
		if (string.IsNullOrEmpty(deviceModel))
		{
		}
		return deviceModel;
	}

	public static string GetAndroidDeviceModel()
	{
		if (string.IsNullOrEmpty(deviceModel))
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.os.Build");
			if (androidJavaClass != null)
			{
				deviceModel = androidJavaClass.GetStatic<string>("MODEL");
			}
		}
		return deviceModel;
	}

	protected void OnGUI()
	{
		if (enableDownloadDeviceList || (checkSpec && checkRezo && checkKamcord))
		{
			return;
		}
		GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
		GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (!checkSpec)
		{
			GUILayout.Label("Spec");
			if (GUILayout.Button("Default"))
			{
				SetSpec("Default");
			}
			else if (GUILayout.Button("Lo"))
			{
				SetSpec("Lo");
			}
		}
		else if (!checkRezo)
		{
			GUILayout.Label("Rezo");
			if (GUILayout.Button("Default"))
			{
				SetRezo("Default");
			}
			else if (GUILayout.Button("Xlarge"))
			{
				SetRezo("Xlarge");
			}
			else if (GUILayout.Button("Large"))
			{
				SetRezo("Large");
			}
			else if (GUILayout.Button("Normal"))
			{
				SetRezo("Normal");
			}
		}
		else if (!checkKamcord)
		{
			GUILayout.Label("Kamcord");
			if (GUILayout.Button("true"))
			{
				SetKamcord("true");
			}
			else if (GUILayout.Button("false"))
			{
				SetKamcord("false");
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.EndArea();
	}
}
