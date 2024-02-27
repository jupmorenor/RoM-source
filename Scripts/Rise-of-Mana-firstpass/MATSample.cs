using System;
using MATSDK;
using UnityEngine;

public class MATSample : MonoBehaviour
{
	private string MAT_ADVERTISER_ID;

	private string MAT_CONVERSION_KEY;

	private string MAT_PACKAGE_NAME;

	private void Awake()
	{
		MAT_ADVERTISER_ID = "877";
		MAT_CONVERSION_KEY = "8c14d6bbe466b65211e781d62e301eec";
		MAT_PACKAGE_NAME = "com.hasoffers.unitytestapp";
		MonoBehaviour.print("Awake called: " + MAT_ADVERTISER_ID + ", " + MAT_CONVERSION_KEY);
	}

	private void OnGUI()
	{
		GUIStyle gUIStyle = new GUIStyle();
		gUIStyle.fontStyle = FontStyle.Bold;
		gUIStyle.fontSize = 50;
		gUIStyle.alignment = TextAnchor.MiddleCenter;
		gUIStyle.normal.textColor = Color.white;
		GUI.Label(new Rect(10f, 5f, Screen.width - 20, Screen.height / 10), "MAT Unity Test App", gUIStyle);
		GUI.skin.button.fontSize = 40;
		if (GUI.Button(new Rect(10f, Screen.height / 10, Screen.width - 20, Screen.height / 10), "Start MAT SDK"))
		{
			MonoBehaviour.print("Start MAT SDK clicked");
			MATBinding.Init(MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);
			MATBinding.SetPackageName(MAT_PACKAGE_NAME);
			MATBinding.SetFacebookEventLogging(enable: true, limit: false);
			MATBinding.CheckForDeferredDeeplink();
			MATBinding.AutomateIapEventMeasurement(automate: true);
		}
		else if (GUI.Button(new Rect(10f, 2 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Set Delegate"))
		{
			MonoBehaviour.print("Set Delegate clicked");
			MATBinding.SetDelegate(enable: true);
		}
		else if (GUI.Button(new Rect(10f, 3 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Enable Debug Mode"))
		{
			MonoBehaviour.print("Enable Debug Mode clicked");
			MATBinding.SetDebugMode(debug: true);
		}
		else if (GUI.Button(new Rect(10f, 4 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Allow Duplicates"))
		{
			MonoBehaviour.print("Allow Duplicates clicked");
			MATBinding.SetAllowDuplicates(allow: true);
		}
		else if (GUI.Button(new Rect(10f, 5 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Session"))
		{
			MonoBehaviour.print("Measure Session clicked");
			MATBinding.MeasureSession();
		}
		else if (GUI.Button(new Rect(10f, 6 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Event"))
		{
			MonoBehaviour.print("Measure Event clicked");
			MATBinding.MeasureEvent("evt11");
		}
		else if (GUI.Button(new Rect(10f, 7 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Measure Event With Event Items"))
		{
			MonoBehaviour.print("Measure Event With Event Items clicked");
			MATItem mATItem = default(MATItem);
			mATItem.name = "subitem1";
			mATItem.unitPrice = 5.0;
			mATItem.quantity = 5;
			mATItem.revenue = 3.0;
			mATItem.attribute2 = "attrValue2";
			mATItem.attribute3 = "attrValue3";
			mATItem.attribute4 = "attrValue4";
			mATItem.attribute5 = "attrValue5";
			MATItem mATItem2 = default(MATItem);
			mATItem2.name = "subitem2";
			mATItem2.unitPrice = 1.0;
			mATItem2.quantity = 3;
			mATItem2.revenue = 1.5;
			mATItem2.attribute1 = "attrValue1";
			mATItem2.attribute3 = "attrValue3";
			MATItem[] eventItems = new MATItem[2] { mATItem, mATItem2 };
			MATEvent tuneEvent = new MATEvent("purchase");
			tuneEvent.revenue = 10.0;
			tuneEvent.currencyCode = "AUD";
			tuneEvent.advertiserRefId = "ref222";
			tuneEvent.attribute1 = "test_attribute1";
			tuneEvent.attribute2 = "test_attribute2";
			tuneEvent.attribute3 = "test_attribute3";
			tuneEvent.attribute4 = "test_attribute4";
			tuneEvent.attribute5 = "test_attribute5";
			tuneEvent.contentType = "test_contentType";
			tuneEvent.contentId = "test_contentId";
			tuneEvent.date1 = DateTime.UtcNow;
			tuneEvent.date2 = DateTime.UtcNow.Add(new TimeSpan(new DateTime(2, 1, 1).Ticks));
			tuneEvent.level = 3;
			tuneEvent.quantity = 2;
			tuneEvent.rating = 4.5;
			tuneEvent.searchString = "test_searchString";
			tuneEvent.eventItems = eventItems;
			tuneEvent.transactionState = 1;
			MATBinding.MeasureEvent(tuneEvent);
		}
		else if (GUI.Button(new Rect(10f, 8 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Test Setter Methods"))
		{
			MonoBehaviour.print("Test Setter Methods clicked");
			MATBinding.SetAge(34);
			MATBinding.SetAllowDuplicates(allow: true);
			MATBinding.SetAppAdTracking(adTrackingEnabled: true);
			MATBinding.SetDebugMode(debug: true);
			MATBinding.SetExistingUser(isExistingUser: false);
			MATBinding.SetFacebookUserId("temp_facebook_user_id");
			MATBinding.SetGender(0);
			MATBinding.SetGoogleUserId("temp_google_user_id");
			MATBinding.SetLocation(111.0, 222.0, 333.0);
			MATBinding.SetPayingUser(isPayingUser: true);
			MATBinding.SetPhoneNumber("111-222-3333");
			MATBinding.SetTwitterUserId("twitter_user_id");
			MATBinding.SetUserId("temp_user_id");
			MATBinding.SetUserName("temp_user_name");
			MATBinding.SetUserEmail("tempuser@tempcompany.com");
			MATBinding.SetDeepLink("myapp://myval1/myval2");
			MATBinding.SetAndroidId("111111111111");
			MATBinding.SetDeviceId("123456789123456");
			MATBinding.SetGoogleAdvertisingId("12345678-1234-1234-1234-123456789012", isLATEnabled: true);
			MATBinding.SetMacAddress("AA:BB:CC:DD:EE:FF");
			MATBinding.SetCurrencyCode("CAD");
			MATBinding.SetTRUSTeId("1234567890");
			MATPreloadData preloadedApp = new MATPreloadData("1122334455");
			preloadedApp.advertiserSubAd = "some_adv_sub_ad_id";
			preloadedApp.publisherSub3 = "some_pub_sub3";
			MATBinding.SetPreloadedApp(preloadedApp);
		}
		else if (GUI.Button(new Rect(10f, 9 * Screen.height / 10, Screen.width - 20, Screen.height / 10), "Test Getter Methods"))
		{
			MonoBehaviour.print("Test Getter Methods clicked");
			MonoBehaviour.print("isPayingUser = " + MATBinding.GetIsPayingUser());
			MonoBehaviour.print("matId     = " + MATBinding.GetMATId());
			MonoBehaviour.print("openLogId = " + MATBinding.GetOpenLogId());
		}
	}

	public static string getSampleiTunesIAPReceipt()
	{
		return "dGhpcyBpcyBhIHNhbXBsZSBpb3MgYXBwIHN0b3JlIHJlY2VpcHQ=";
	}
}
