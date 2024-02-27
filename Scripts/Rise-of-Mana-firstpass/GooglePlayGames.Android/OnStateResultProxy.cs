using GooglePlayGames.BasicApi;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class OnStateResultProxy : AndroidJavaProxy
{
	private OnStateLoadedListener mListener;

	private AndroidClient mAndroidClient;

	internal OnStateResultProxy(AndroidClient androidClient, OnStateLoadedListener listener)
		: base("com.google.android.gms.common.api.ResultCallback")
	{
		mListener = listener;
		mAndroidClient = androidClient;
	}

	private void OnStateConflict(int stateKey, string resolvedVersion, byte[] localData, byte[] serverData)
	{
		Logger.d("OnStateResultProxy.onStateConflict called, stateKey=" + stateKey + ", resolvedVersion=" + resolvedVersion);
		debugLogData("localData", localData);
		debugLogData("serverData", serverData);
		if (mListener != null)
		{
			Logger.d("OnStateResultProxy.onStateConflict invoking conflict callback.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				byte[] resolvedData = mListener.OnStateConflict(stateKey, localData, serverData);
				mAndroidClient.ResolveState(stateKey, resolvedVersion, resolvedData, mListener);
			});
		}
		else
		{
			Logger.w("No conflict callback specified! Cannot resolve cloud save conflict.");
		}
	}

	private void OnStateLoaded(int statusCode, int stateKey, byte[] localData)
	{
		Logger.d("OnStateResultProxy.onStateLoaded called, status " + statusCode + ", stateKey=" + stateKey);
		debugLogData("localData", localData);
		bool success = false;
		switch (statusCode)
		{
		case 0:
			Logger.d("Status is OK, so success.");
			success = true;
			break;
		case 4:
			Logger.d("Status is NO DATA (no network?), so it's a failure.");
			success = false;
			localData = null;
			break;
		case 3:
			Logger.d("Status is STALE DATA, so considering as success.");
			success = true;
			break;
		case 2002:
			Logger.d("Status is KEY NOT FOUND, which is a success, but with no data.");
			success = true;
			localData = null;
			break;
		default:
			Logger.e("Cloud load failed with status code " + statusCode);
			success = false;
			localData = null;
			break;
		}
		if (mListener != null)
		{
			Logger.d("OnStateResultProxy.onStateLoaded invoking load callback.");
			PlayGamesHelperObject.RunOnGameThread(delegate
			{
				mListener.OnStateLoaded(success, stateKey, localData);
			});
		}
		else
		{
			Logger.w("No load callback specified!");
		}
	}

	private void debugLogData(string tag, byte[] data)
	{
		Logger.d("   " + tag + ": " + Logger.describe(data));
	}

	public void onResult(AndroidJavaObject result)
	{
		Logger.d("OnStateResultProxy.onResult, result=" + result);
		int statusCode = JavaUtil.GetStatusCode(result);
		Logger.d("OnStateResultProxy: status code is " + statusCode);
		if (result == null)
		{
			Logger.e("OnStateResultProxy: result is null.");
			return;
		}
		Logger.d("OnstateResultProxy: retrieving result objects...");
		AndroidJavaObject androidJavaObject = JavaUtil.CallNullSafeObjectMethod(result, "getLoadedResult");
		AndroidJavaObject androidJavaObject2 = JavaUtil.CallNullSafeObjectMethod(result, "getConflictResult");
		Logger.d("Got result objects.");
		Logger.d("loadedResult = " + androidJavaObject);
		Logger.d("conflictResult = " + androidJavaObject2);
		if (androidJavaObject2 != null)
		{
			Logger.d("OnStateResultProxy: processing conflict.");
			int stateKey = androidJavaObject2.Call<int>("getStateKey", new object[0]);
			string resolvedVersion = androidJavaObject2.Call<string>("getResolvedVersion", new object[0]);
			byte[] localData = JavaUtil.ConvertByteArray(JavaUtil.CallNullSafeObjectMethod(androidJavaObject2, "getLocalData"));
			byte[] serverData = JavaUtil.ConvertByteArray(JavaUtil.CallNullSafeObjectMethod(androidJavaObject2, "getServerData"));
			Logger.d("OnStateResultProxy: conflict args parsed, calling.");
			OnStateConflict(stateKey, resolvedVersion, localData, serverData);
		}
		else if (androidJavaObject != null)
		{
			Logger.d("OnStateResultProxy: processing normal load.");
			int stateKey2 = androidJavaObject.Call<int>("getStateKey", new object[0]);
			byte[] localData2 = JavaUtil.ConvertByteArray(JavaUtil.CallNullSafeObjectMethod(androidJavaObject, "getLocalData"));
			Logger.d("OnStateResultProxy: loaded args parsed, calling.");
			OnStateLoaded(statusCode, stateKey2, localData2);
		}
		else
		{
			Logger.e("OnStateResultProxy: both loadedResult and conflictResult are null!");
		}
	}
}
