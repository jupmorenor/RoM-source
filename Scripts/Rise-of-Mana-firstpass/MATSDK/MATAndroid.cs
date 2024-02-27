using System;
using System.Collections.Generic;
using UnityEngine;

namespace MATSDK;

public class MATAndroid
{
	private static MATAndroid instance;

	private AndroidJavaClass ajcMAT;

	public AndroidJavaObject ajcInstance;

	private AndroidJavaClass ajcUnityPlayer;

	private AndroidJavaObject ajcCurrentActivity;

	private AndroidJavaObject ajcAlliances;

	public static MATAndroid Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new MATAndroid();
			}
			return instance;
		}
	}

	private MATAndroid()
	{
	}

	public void Init(string advertiserId, string conversionKey)
	{
		if (ajcMAT == null)
		{
			ajcMAT = new AndroidJavaClass("com.mobileapptracker.MobileAppTracker");
			ajcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			ajcCurrentActivity = ajcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			ajcInstance = ajcMAT.CallStatic<AndroidJavaObject>("init", new object[3] { ajcCurrentActivity, advertiserId, conversionKey });
			ajcInstance.Call("setPluginName", "unity");
			ajcAlliances = new AndroidJavaObject("com.tune.unityutils.CrossPromoUnityPlugin");
		}
	}

	public void ShowBanner(string placement)
	{
		ajcAlliances.Call("showBanner", placement);
	}

	public void ShowBanner(string placement, MATAdMetadata metadata)
	{
		AndroidJavaObject adMetadataJavaObject = GetAdMetadataJavaObject(metadata);
		ajcAlliances.Call("showBanner", placement, adMetadataJavaObject);
	}

	public void ShowBanner(string placement, MATAdMetadata metadata, MATBannerPosition position)
	{
		AndroidJavaObject adMetadataJavaObject = GetAdMetadataJavaObject(metadata);
		AndroidJavaObject androidJavaObject = ((position != MATBannerPosition.TOP_CENTER) ? new AndroidJavaClass("com.tune.crosspromo.TuneBannerPosition").GetStatic<AndroidJavaObject>("BOTTOM_CENTER") : new AndroidJavaClass("com.tune.crosspromo.TuneBannerPosition").GetStatic<AndroidJavaObject>("TOP_CENTER"));
		ajcAlliances.Call("showBanner", placement, adMetadataJavaObject, androidJavaObject);
	}

	public void HideBanner()
	{
		ajcAlliances.Call("hideBanner");
	}

	public void DestroyBanner()
	{
		ajcAlliances.Call("destroyBanner");
	}

	public void CacheInterstitial(string placement)
	{
		ajcAlliances.Call("cacheInterstitial", placement);
	}

	public void CacheInterstitial(string placement, MATAdMetadata metadata)
	{
		AndroidJavaObject adMetadataJavaObject = GetAdMetadataJavaObject(metadata);
		ajcAlliances.Call("cacheInterstitial", placement, adMetadataJavaObject);
	}

	public void ShowInterstitial(string placement)
	{
		ajcAlliances.Call("showInterstitial", placement);
	}

	public void ShowInterstitial(string placement, MATAdMetadata metadata)
	{
		AndroidJavaObject adMetadataJavaObject = GetAdMetadataJavaObject(metadata);
		ajcAlliances.Call("showInterstitial", placement, adMetadataJavaObject);
	}

	public void DestroyInterstitial()
	{
		ajcAlliances.Call("destroyInterstitial");
	}

	public void MeasureSession()
	{
		ajcInstance.Call("setReferralSources", ajcCurrentActivity);
		ajcInstance.Call("measureSession");
	}

	public void MeasureEvent(string eventName)
	{
		ajcInstance.Call("measureEvent", eventName);
	}

	public void MeasureEvent(int eventId)
	{
		ajcInstance.Call("measureEvent", eventId);
	}

	public void MeasureEvent(MATEvent tuneEvent)
	{
		AndroidJavaObject tuneEventJavaObject = GetTuneEventJavaObject(tuneEvent);
		ajcInstance.Call("measureEvent", tuneEventJavaObject);
	}

	public void CheckForDeferredDeeplink()
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TUNEUnityDeeplinkListener");
		ajcInstance.Call("checkForDeferredDeeplink", androidJavaObject);
	}

	public bool GetIsPayingUser()
	{
		return ajcInstance.Call<bool>("getIsPayingUser", new object[0]);
	}

	public string GetMatId()
	{
		return ajcInstance.Call<string>("getMatId", new object[0]);
	}

	public string GetOpenLogId()
	{
		return ajcInstance.Call<string>("getOpenLogId", new object[0]);
	}

	public void SetAge(int age)
	{
		ajcInstance.Call("setAge", age);
	}

	public void SetAllowDuplicates(bool allow)
	{
		ajcInstance.Call("setAllowDuplicates", allow);
	}

	public void SetAndroidId(string androidId)
	{
		ajcInstance.Call("setAndroidId", androidId);
	}

	public void SetAndroidIdMd5(string androidIdMd5)
	{
		ajcInstance.Call("setAndroidIdMd5", androidIdMd5);
	}

	public void SetAndroidIdSha1(string androidIdSha1)
	{
		ajcInstance.Call("setAndroidIdSha1", androidIdSha1);
	}

	public void SetAndroidIdSha256(string androidIdSha256)
	{
		ajcInstance.Call("setAndroidIdSha256", androidIdSha256);
	}

	public void SetAppAdTracking(bool adTrackingEnabled)
	{
		ajcInstance.Call("setAppAdTrackingEnabled", adTrackingEnabled);
	}

	public void SetCurrencyCode(string currencyCode)
	{
		ajcInstance.Call("setCurrencyCode", currencyCode);
	}

	public void SetDeepLink(string deepLinkUrl)
	{
		ajcInstance.Call("setReferralUrl", deepLinkUrl);
	}

	public void SetDebugMode(bool debugMode)
	{
		ajcInstance.Call("setDebugMode", debugMode);
	}

	public void SetDeviceId(string deviceId)
	{
		ajcInstance.Call("setDeviceId", deviceId);
	}

	public void SetDelegate(bool enable)
	{
		if (enable)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TUNEUnityListener");
			ajcInstance.Call("setMATResponse", androidJavaObject);
		}
	}

	public void SetEmailCollection(bool collectEmail)
	{
		ajcInstance.Call("setEmailCollection", collectEmail);
	}

	public void SetExistingUser(bool isExistingUser)
	{
		ajcInstance.Call("setExistingUser", isExistingUser);
	}

	public void SetFacebookEventLogging(bool fbEventLogging, bool limitEventAndDataUsage)
	{
		ajcInstance.Call("setFacebookEventLogging", fbEventLogging, ajcCurrentActivity, limitEventAndDataUsage);
	}

	public void SetFacebookUserId(string facebookUserId)
	{
		ajcInstance.Call("setFacebookUserId", facebookUserId);
	}

	public void SetGender(int gender)
	{
		ajcInstance.Call("setGender", gender);
	}

	public void SetGoogleAdvertisingId(string googleAid, bool isLATEnabled)
	{
		ajcInstance.Call("setGoogleAdvertisingId", googleAid, isLATEnabled);
	}

	public void SetGoogleUserId(string googleUserId)
	{
		ajcInstance.Call("setGoogleUserId", googleUserId);
	}

	public void SetLocation(double latitude, double longitude, double altitude)
	{
		ajcInstance.Call("setLatitude", latitude);
		ajcInstance.Call("setLongitude", longitude);
		ajcInstance.Call("setAltitude", altitude);
	}

	public void SetMacAddress(string macAddress)
	{
		ajcInstance.Call("setMacAddress", macAddress);
	}

	public void SetPackageName(string packageName)
	{
		ajcInstance.Call("setPackageName", packageName);
	}

	public void SetPayingUser(bool isPayingUser)
	{
		ajcInstance.Call("setIsPayingUser", isPayingUser);
	}

	public void SetPhoneNumber(string phoneNumber)
	{
		ajcInstance.Call("setPhoneNumber", phoneNumber);
	}

	public void SetSiteId(string siteId)
	{
		ajcInstance.Call("setSiteId", siteId);
	}

	public void SetTRUSTeId(string tpid)
	{
		ajcInstance.Call("setTRUSTeId", tpid);
	}

	public void SetTwitterUserId(string twitterUserId)
	{
		ajcInstance.Call("setTwitterUserId", twitterUserId);
	}

	public void SetUserEmail(string userEmail)
	{
		ajcInstance.Call("setUserEmail", userEmail);
	}

	public void SetUserId(string userId)
	{
		ajcInstance.Call("setUserId", userId);
	}

	public void SetUserName(string userName)
	{
		ajcInstance.Call("setUserName", userName);
	}

	public void SetPreloadedApp(MATPreloadData preloadData)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.mobileapptracker.MATPreloadData", preloadData.publisherId);
		if (preloadData.offerId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withOfferId", new object[1] { preloadData.offerId });
		}
		if (preloadData.agencyId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAgencyId", new object[1] { preloadData.agencyId });
		}
		if (preloadData.publisherReferenceId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherReferenceId", new object[1] { preloadData.publisherReferenceId });
		}
		if (preloadData.publisherSub1 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub1", new object[1] { preloadData.publisherSub1 });
		}
		if (preloadData.publisherSub2 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub2", new object[1] { preloadData.publisherSub2 });
		}
		if (preloadData.publisherSub3 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub3", new object[1] { preloadData.publisherSub3 });
		}
		if (preloadData.publisherSub4 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub4", new object[1] { preloadData.publisherSub4 });
		}
		if (preloadData.publisherSub5 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub5", new object[1] { preloadData.publisherSub5 });
		}
		if (preloadData.publisherSubAd != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAd", new object[1] { preloadData.publisherSubAd });
		}
		if (preloadData.publisherSubAdgroup != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAdgroup", new object[1] { preloadData.publisherSubAdgroup });
		}
		if (preloadData.publisherSubCampaign != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubCampaign", new object[1] { preloadData.publisherSubCampaign });
		}
		if (preloadData.publisherSubKeyword != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubKeyword", new object[1] { preloadData.publisherSubKeyword });
		}
		if (preloadData.publisherSubPublisher != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubPublisher", new object[1] { preloadData.publisherSubPublisher });
		}
		if (preloadData.publisherSubSite != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubSite", new object[1] { preloadData.publisherSubSite });
		}
		if (preloadData.advertiserSubAd != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAd", new object[1] { preloadData.advertiserSubAd });
		}
		if (preloadData.advertiserSubAdgroup != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAdgroup", new object[1] { preloadData.advertiserSubAdgroup });
		}
		if (preloadData.advertiserSubCampaign != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubCampaign", new object[1] { preloadData.advertiserSubCampaign });
		}
		if (preloadData.advertiserSubKeyword != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubKeyword", new object[1] { preloadData.advertiserSubKeyword });
		}
		if (preloadData.advertiserSubPublisher != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubPublisher", new object[1] { preloadData.advertiserSubPublisher });
		}
		if (preloadData.advertiserSubSite != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubSite", new object[1] { preloadData.advertiserSubSite });
		}
		ajcInstance.Call("setPreloadedApp", androidJavaObject);
	}

	private AndroidJavaObject GetTuneEventJavaObject(MATEvent tuneEvent)
	{
		AndroidJavaObject androidJavaObject = ((tuneEvent.name != null) ? new AndroidJavaObject("com.mobileapptracker.MATEvent", tuneEvent.name) : new AndroidJavaObject("com.mobileapptracker.MATEvent", tuneEvent.id));
		double? revenue = tuneEvent.revenue;
		if (revenue.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withRevenue", new object[1] { tuneEvent.revenue });
		}
		if (tuneEvent.currencyCode != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withCurrencyCode", new object[1] { tuneEvent.currencyCode });
		}
		if (tuneEvent.advertiserRefId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserRefId", new object[1] { tuneEvent.advertiserRefId });
		}
		if (tuneEvent.eventItems != null)
		{
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.ArrayList");
			MATItem[] eventItems = tuneEvent.eventItems;
			for (int i = 0; i < eventItems.Length; i++)
			{
				MATItem mATItem = eventItems[i];
				AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("com.mobileapptracker.MATEventItem", mATItem.name);
				int? quantity = mATItem.quantity;
				if (quantity.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withQuantity", new object[1] { mATItem.quantity });
				}
				double? unitPrice = mATItem.unitPrice;
				if (unitPrice.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withUnitPrice", new object[1] { mATItem.unitPrice });
				}
				double? revenue2 = mATItem.revenue;
				if (revenue2.HasValue)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withRevenue", new object[1] { mATItem.revenue });
				}
				if (mATItem.attribute1 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute1", new object[1] { mATItem.attribute1 });
				}
				if (mATItem.attribute2 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute2", new object[1] { mATItem.attribute2 });
				}
				if (mATItem.attribute3 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute3", new object[1] { mATItem.attribute3 });
				}
				if (mATItem.attribute4 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute4", new object[1] { mATItem.attribute4 });
				}
				if (mATItem.attribute5 != null)
				{
					androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute5", new object[1] { mATItem.attribute5 });
				}
				androidJavaObject2.Call<bool>("add", new object[1] { androidJavaObject3 });
			}
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withEventItems", new object[1] { androidJavaObject2 });
		}
		if (tuneEvent.receipt != null && tuneEvent.receiptSignature != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withReceipt", new object[2] { tuneEvent.receipt, tuneEvent.receiptSignature });
		}
		if (tuneEvent.contentType != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentType", new object[1] { tuneEvent.contentType });
		}
		if (tuneEvent.contentId != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentId", new object[1] { tuneEvent.contentId });
		}
		int? level = tuneEvent.level;
		if (level.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withLevel", new object[1] { tuneEvent.level });
		}
		int? quantity2 = tuneEvent.quantity;
		if (quantity2.HasValue)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withQuantity", new object[1] { tuneEvent.quantity });
		}
		if (tuneEvent.searchString != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withSearchString", new object[1] { tuneEvent.searchString });
		}
		DateTime? date = tuneEvent.date1;
		if (date.HasValue)
		{
			DateTime? date2 = tuneEvent.date1;
			TimeSpan timeSpan = new TimeSpan(date2.Value.Ticks);
			double totalMilliseconds = timeSpan.TotalMilliseconds;
			double num = totalMilliseconds - new TimeSpan(new DateTime(1970, 1, 1).Ticks).TotalMilliseconds;
			AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("java.lang.Double", num);
			long num2 = androidJavaObject4.Call<long>("longValue", new object[0]);
			AndroidJavaObject androidJavaObject5 = new AndroidJavaObject("java.util.Date", num2);
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate1", new object[1] { androidJavaObject5 });
		}
		DateTime? date3 = tuneEvent.date2;
		if (date3.HasValue)
		{
			DateTime? date4 = tuneEvent.date2;
			TimeSpan timeSpan2 = new TimeSpan(date4.Value.Ticks);
			double totalMilliseconds2 = timeSpan2.TotalMilliseconds;
			double num3 = totalMilliseconds2 - new TimeSpan(new DateTime(1970, 1, 1).Ticks).TotalMilliseconds;
			AndroidJavaObject androidJavaObject6 = new AndroidJavaObject("java.lang.Double", num3);
			long num4 = androidJavaObject6.Call<long>("longValue", new object[0]);
			AndroidJavaObject androidJavaObject7 = new AndroidJavaObject("java.util.Date", num4);
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate2", new object[1] { androidJavaObject7 });
		}
		if (tuneEvent.attribute1 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute1", new object[1] { tuneEvent.attribute1 });
		}
		if (tuneEvent.attribute2 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute2", new object[1] { tuneEvent.attribute2 });
		}
		if (tuneEvent.attribute3 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute3", new object[1] { tuneEvent.attribute3 });
		}
		if (tuneEvent.attribute4 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute4", new object[1] { tuneEvent.attribute4 });
		}
		if (tuneEvent.attribute5 != null)
		{
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute5", new object[1] { tuneEvent.attribute5 });
		}
		return androidJavaObject;
	}

	private AndroidJavaObject GetAdMetadataJavaObject(MATAdMetadata metadata)
	{
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.crosspromo.TuneAdMetadata");
		androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDebugMode", new object[1] { metadata.getDebugMode() });
		AndroidJavaObject androidJavaObject2 = ((metadata.getGender() == MATAdGender.MALE) ? new AndroidJavaClass("com.mobileapptracker.MATGender").GetStatic<AndroidJavaObject>("MALE") : ((metadata.getGender() != MATAdGender.FEMALE) ? new AndroidJavaClass("com.mobileapptracker.MATGender").GetStatic<AndroidJavaObject>("UNKNOWN") : new AndroidJavaClass("com.mobileapptracker.MATGender").GetStatic<AndroidJavaObject>("FEMALE")));
		androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withGender", new object[1] { androidJavaObject2 });
		if ((double)metadata.getLatitude() != 0.0 && (double)metadata.getLongitude() != 0.0)
		{
			double num = Convert.ToDouble(metadata.getLatitude());
			double num2 = Convert.ToDouble(metadata.getLongitude());
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withLocation", new object[2] { num, num2 });
		}
		if (metadata.getBirthDate().HasValue)
		{
			DateTime valueOrDefault = metadata.getBirthDate().GetValueOrDefault();
			int year = valueOrDefault.Year;
			int month = valueOrDefault.Month;
			int day = valueOrDefault.Day;
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withBirthDate", new object[3] { year, month, day });
		}
		if (metadata.getCustomTargets().Count != 0)
		{
			AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.util.HashMap");
			IntPtr methodID = AndroidJNIHelper.GetMethodID(androidJavaObject3.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			object[] array = new object[2];
			foreach (KeyValuePair<string, string> customTarget in metadata.getCustomTargets())
			{
				AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("java.lang.String", customTarget.Key + string.Empty);
				AndroidJavaObject androidJavaObject5 = new AndroidJavaObject("java.lang.String", customTarget.Value + string.Empty);
				array[0] = androidJavaObject4;
				array[1] = androidJavaObject5;
				AndroidJNI.CallObjectMethod(androidJavaObject3.GetRawObject(), methodID, AndroidJNIHelper.CreateJNIArgArray(array));
			}
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withCustomTargets", new object[1] { androidJavaObject3 });
		}
		if (metadata.getKeywords().Count != 0)
		{
			AndroidJavaObject androidJavaObject6 = new AndroidJavaObject("java.util.HashSet");
			foreach (string keyword in metadata.getKeywords())
			{
				androidJavaObject6.Call<bool>("add", new object[1] { keyword });
			}
			androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withKeywords", new object[1] { androidJavaObject6 });
		}
		return androidJavaObject;
	}
}
