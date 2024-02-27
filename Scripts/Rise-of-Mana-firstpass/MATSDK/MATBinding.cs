using UnityEngine;

namespace MATSDK;

public class MATBinding : MonoBehaviour
{
	public static void Init(string advertiserId, string conversionKey)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.Init(advertiserId, conversionKey);
		}
	}

	public static void Init(string advertiserId, string conversionKey, string packageName, bool wearable)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.Init(advertiserId, conversionKey);
		}
	}

	public static void CacheInterstitial(string placement)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.CacheInterstitial(placement);
		}
	}

	public static void CacheInterstitial(string placement, MATAdMetadata metadata)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.CacheInterstitial(placement, metadata);
		}
	}

	public static void ShowInterstitial(string placement)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.ShowInterstitial(placement);
		}
	}

	public static void ShowInterstitial(string placement, MATAdMetadata metadata)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.ShowInterstitial(placement, metadata);
		}
	}

	public static void DestroyInterstitial()
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.DestroyInterstitial();
		}
	}

	public static void ShowBanner(string placement)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.ShowBanner(placement);
		}
	}

	public static void ShowBanner(string placement, MATAdMetadata metadata)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.ShowBanner(placement, metadata);
		}
	}

	public static void ShowBanner(string placement, MATAdMetadata metadata, MATBannerPosition position)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.ShowBanner(placement, metadata, position);
		}
	}

	public static void HideBanner()
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.HideBanner();
		}
	}

	public static void LayoutBanner()
	{
		if (Application.isEditor)
		{
		}
	}

	public static void DestroyBanner()
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.DestroyBanner();
		}
	}

	public static void CheckForDeferredDeeplink()
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.CheckForDeferredDeeplink();
		}
	}

	public static void AutomateIapEventMeasurement(bool automate)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetDeepLink(string deepLinkUrl)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetDeepLink(deepLinkUrl);
		}
	}

	public static void MeasureEvent(string eventName)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.MeasureEvent(eventName);
		}
	}

	public static void MeasureEvent(int eventId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.MeasureEvent(eventId);
		}
	}

	public static void MeasureEvent(MATEvent tuneEvent)
	{
		if (!Application.isEditor)
		{
			int num = ((tuneEvent.eventItems != null) ? tuneEvent.eventItems.Length : 0);
			MATAndroid.Instance.MeasureEvent(tuneEvent);
		}
	}

	public static void MeasureSession()
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.MeasureSession();
		}
	}

	public static void SetAge(int age)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAge(age);
		}
	}

	public static void SetAllowDuplicates(bool allow)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAllowDuplicates(allow);
		}
	}

	public static void SetAppAdTracking(bool adTrackingEnabled)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAppAdTracking(adTrackingEnabled);
		}
	}

	public static void SetDebugMode(bool debug)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetDebugMode(debug);
		}
	}

	public static void SetExistingUser(bool isExistingUser)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetExistingUser(isExistingUser);
		}
	}

	public static void SetFacebookEventLogging(bool enable, bool limit)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetFacebookEventLogging(enable, limit);
		}
	}

	public static void SetFacebookUserId(string fbUserId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetFacebookUserId(fbUserId);
		}
	}

	public static void SetGender(int gender)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetGender(gender);
		}
	}

	public static void SetGoogleUserId(string googleUserId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetGoogleUserId(googleUserId);
		}
	}

	public static void SetLocation(double latitude, double longitude, double altitude)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetLocation(latitude, longitude, altitude);
		}
	}

	public static void SetPackageName(string packageName)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetPackageName(packageName);
		}
	}

	public static void SetPayingUser(bool isPayingUser)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetPayingUser(isPayingUser);
		}
	}

	public static void SetPhoneNumber(string phoneNumber)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetPhoneNumber(phoneNumber);
		}
	}

	public static void SetTwitterUserId(string twitterUserId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetTwitterUserId(twitterUserId);
		}
	}

	public static void SetUserEmail(string userEmail)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetUserEmail(userEmail);
		}
	}

	public static void SetUserId(string userId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetUserId(userId);
		}
	}

	public static void SetUserName(string userName)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetUserName(userName);
		}
	}

	public static bool GetIsPayingUser()
	{
		if (!Application.isEditor)
		{
			return MATAndroid.Instance.GetIsPayingUser();
		}
		return true;
	}

	public static string GetMATId()
	{
		if (!Application.isEditor)
		{
			return MATAndroid.Instance.GetMatId();
		}
		return string.Empty;
	}

	public static string GetOpenLogId()
	{
		if (!Application.isEditor)
		{
			return MATAndroid.Instance.GetOpenLogId();
		}
		return string.Empty;
	}

	public static void SetAppleAdvertisingIdentifier(string advertiserIdentifier, bool trackingEnabled)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetAppleVendorIdentifier(string vendorIdentifier)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetJailbroken(bool isJailbroken)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoDetectJailbroken(bool isAutoDetectJailbroken)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoCollectAppleAdvertisingIdentifier(bool shouldAutoCollect)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoCollectDeviceLocation(bool shouldAutoCollect)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetShouldAutoGenerateVendorIdentifier(bool shouldAutoGenerate)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetUseCookieTracking(bool useCookieTracking)
	{
		if (Application.isEditor)
		{
		}
	}

	public static void SetAndroidId(string androidId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAndroidId(androidId);
		}
	}

	public static void SetAndroidIdMd5(string androidIdMd5)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAndroidIdMd5(androidIdMd5);
		}
	}

	public static void SetAndroidIdSha1(string androidIdSha1)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAndroidIdSha1(androidIdSha1);
		}
	}

	public static void SetAndroidIdSha256(string androidIdSha256)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetAndroidIdSha256(androidIdSha256);
		}
	}

	public static void SetDeviceId(string deviceId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetDeviceId(deviceId);
		}
	}

	public static void SetEmailCollection(bool collectEmail)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetEmailCollection(collectEmail);
		}
	}

	public static void SetMacAddress(string macAddress)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetMacAddress(macAddress);
		}
	}

	public static void SetGoogleAdvertisingId(string adId, bool isLATEnabled)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetGoogleAdvertisingId(adId, isLATEnabled);
		}
	}

	public static void SetPreloadedApp(MATPreloadData preloadData)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetPreloadedApp(preloadData);
		}
	}

	public static void SetCurrencyCode(string currencyCode)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetCurrencyCode(currencyCode);
		}
	}

	public static void SetDelegate(bool enable)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetDelegate(enable);
		}
	}

	public static void SetSiteId(string siteId)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetSiteId(siteId);
		}
	}

	public static void SetTRUSTeId(string tpid)
	{
		if (!Application.isEditor)
		{
			MATAndroid.Instance.SetTRUSTeId(tpid);
		}
	}
}
