using System;
using System.Collections.Generic;
using MATSDK;
using UnityEngine;

public class MATAdSample : MonoBehaviour
{
	private string MAT_ADVERTISER_ID;

	private string MAT_CONVERSION_KEY;

	private string MAT_PACKAGE_NAME;

	private Vector2 scrollPosition = Vector2.zero;

	private int numButtons;

	private int topMargin = 5;

	private int bottomMargin = 5;

	private void Awake()
	{
		MAT_ADVERTISER_ID = "877";
		MAT_CONVERSION_KEY = "40c19f41ef0ec2d433f595f0880d39b9";
		MAT_PACKAGE_NAME = "edu.self.AtomicDodgeBallLite";
		MonoBehaviour.print("Awake called: " + MAT_ADVERTISER_ID + ", " + MAT_CONVERSION_KEY);
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.fontStyle = FontStyle.Bold;
		gUIStyle.fontSize = 50;
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.normal.textColor = Color.white;
		float height = Screen.height / 10;
		GUI.Label(new Rect(10f, topMargin, Screen.width - 20, height), "MAT Unity Test App", gUIStyle);
		GUI.skin.button.fontSize = 40;
		GUI.skin.verticalScrollbar.fixedWidth = (float)Screen.width * 0.05f;
		GUI.skin.verticalScrollbarThumb.fixedWidth = (float)Screen.width * 0.05f;
		float height2 = (float)((double)numButtons * 0.125) * (float)Screen.height;
		scrollPosition = GUI.BeginScrollView(new Rect(0.1f * (float)Screen.width, 0.15f * (float)Screen.height, (float)Screen.width - 0.1f * (float)Screen.width, (float)Screen.height - 0.15f * (float)Screen.height - (float)topMargin - (float)bottomMargin), scrollPosition, new Rect(0.1f * (float)Screen.width, 0.15f * (float)Screen.height, (float)Screen.width - 0.1f * (float)Screen.width, height2));
		int num = 0;
		float top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		Rect position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Start MAT SDK"))
		{
			MonoBehaviour.print("Start MAT SDK clicked");
			MATBinding.Init(MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
			MATBinding.SetPackageName(MAT_PACKAGE_NAME);
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Set Delegate"))
		{
			MonoBehaviour.print("Set Delegate clicked");
			MATBinding.SetDelegate(enable: true);
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Show Banner"))
		{
			MonoBehaviour.print("Show Banner");
			MATBinding.ShowBanner("place1");
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Hide Banner"))
		{
			MonoBehaviour.print("Hide Banner");
			MATBinding.HideBanner();
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Destroy Banner"))
		{
			MonoBehaviour.print("Destroy Banner");
			MATBinding.DestroyBanner();
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Cache Interstitial"))
		{
			MATAdMetadata mATAdMetadata = new MATAdMetadata();
			mATAdMetadata.setBirthDate(DateTime.Today.AddYears(-45));
			mATAdMetadata.setGender(MATAdGender.FEMALE);
			mATAdMetadata.setLocation(120.8f, 234.5f, 579.6f);
			mATAdMetadata.setDebugMode(debugMode: true);
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.Add("pro");
			hashSet.Add("evening");
			mATAdMetadata.setKeywords(hashSet);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("type", "game");
			dictionary.Add("subtype1", "adventure");
			dictionary.Add("subtype2", "action");
			mATAdMetadata.setCustomTargets(dictionary);
			MATBinding.CacheInterstitial("place1", mATAdMetadata);
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Show Interstitial"))
		{
			MonoBehaviour.print("Show Interstitial");
			MATBinding.ShowInterstitial("place1");
		}
		num++;
		top = (float)(0.15000000596046448 + (double)num * 0.125) * (float)Screen.height;
		position = new Rect(0.1f * (float)Screen.width, top, 0.8f * (float)Screen.width, 0.1f * (float)Screen.height);
		if (GUI.Button(position, "Destroy Interstitial"))
		{
			MonoBehaviour.print("Destroy Interstitial");
			MATBinding.DestroyInterstitial();
		}
		GUI.EndScrollView();
		numButtons = num + 1;
		MATBinding.LayoutBanner();
	}
}
