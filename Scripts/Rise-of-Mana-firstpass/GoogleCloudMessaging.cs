using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleCloudMessaging
{
	private static AndroidJavaObject _plugin;

	static GoogleCloudMessaging()
	{
		if (Application.platform != RuntimePlatform.Android)
		{
			return;
		}
		using AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.prime31.GoogleCloudMessagingPlugin");
		_plugin = androidJavaClass.CallStatic<AndroidJavaObject>("instance", new object[0]);
	}

	public static void checkForNotifications()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_plugin.Call("checkForNotifications");
		}
	}

	public static void register(string gcmSenderId)
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_plugin.Call("register", gcmSenderId);
		}
	}

	public static void unRegister()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_plugin.Call("unRegister");
		}
	}

	public static void cancelAll()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			_plugin.Call("cancelAll");
		}
	}

	public static IEnumerator registerDeviceWithPushIO(string deviceId, string pushIOApiKey, List<string> pushIOCategories, Action<bool, string> completionHandler)
	{
		string url = $"https://api.push.io/r/{pushIOApiKey}?di={SystemInfo.deviceUniqueIdentifier}&dt={deviceId}";
		if (pushIOCategories != null && pushIOCategories.Count > 0)
		{
			url = url + "&c=" + string.Join(",", pushIOCategories.ToArray());
		}
		using WWW www = new WWW(url);
		yield return www;
		if (completionHandler != null)
		{
			if (www.text.StartsWith("ok"))
			{
				completionHandler(arg1: true, null);
			}
			else
			{
				completionHandler(arg1: false, www.error);
			}
		}
	}
}
