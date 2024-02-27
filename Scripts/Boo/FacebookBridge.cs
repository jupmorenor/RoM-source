using System;
using UnityEngine;

[Serializable]
public class FacebookBridge
{
	[NonSerialized]
	private static bool enabled;

	public static bool Enabled => enabled;

	public static void Init()
	{
		FB.Init(OnInit, OnHideUnity);
		Debug.Log("FB.Init");
	}

	public static void ActivateApp()
	{
		string key = "FB-lastOpen";
		string @string = PlayerPrefs.GetString(key, "0");
		DateTime dateTime = DateTime.FromBinary(Convert.ToInt64(@string));
		DateTime dateTime2 = DateTime.Now.AddDays(-1.0);
		if (dateTime < dateTime2)
		{
			FB.ActivateApp();
			PlayerPrefs.SetString(key, DateTime.Now.ToBinary().ToString());
			PlayerPrefs.Save();
			Debug.Log("FB.ActivateApp");
		}
	}

	public static void PurchaseByJPY(float yen)
	{
		FB.AppEvents.LogPurchase(yen, "JPY");
		Debug.Log("LogPurchase");
	}

	public static void CompletedTutorial()
	{
		string logEvent = "fb_mobile_tutorial_completion";
		FB.AppEvents.LogEvent(logEvent);
	}

	private static void OnInit()
	{
		enabled = true;
	}

	private static void OnHideUnity(bool isGameShown)
	{
	}
}
