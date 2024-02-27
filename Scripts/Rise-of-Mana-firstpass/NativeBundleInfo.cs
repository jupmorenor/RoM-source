using UnityEngine;

public class NativeBundleInfo
{
	private static string _VersionStr;

	public static string Version
	{
		get
		{
			if (_VersionStr == null)
			{
				_VersionStr = _NativeBundleInfoGetVersion();
			}
			return _VersionStr;
		}
	}

	private static string _NativeBundleInfoGetVersion()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getApplicationContext", new object[0]);
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getPackageInfo", new object[2]
		{
			androidJavaObject.Call<string>("getPackageName", new object[0]),
			androidJavaObject2.GetStatic<int>("GET_ACTIVITIES")
		});
		string text = androidJavaObject3.Get<string>("versionName");
		return text + "(" + androidJavaObject3.Get<int>("versionCode") + ")";
	}
}
