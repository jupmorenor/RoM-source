using System;
using System.Collections.Generic;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android;

internal class GameHelperManager
{
	internal enum ConnectionState
	{
		Disconnected,
		Connecting,
		Connected
	}

	private class GameHelperListener : AndroidJavaProxy
	{
		private GameHelperManager mContainer;

		private int mOrigin;

		internal GameHelperListener(GameHelperManager mgr, int origin)
			: base("com.google.example.games.basegameutils.GameHelper$GameHelperListener")
		{
			mContainer = mgr;
			mOrigin = origin;
		}

		private void onSignInFailed()
		{
			Logger.d("GHM/GameHelperListener got onSignInFailed, origin " + mOrigin + ", notifying GHM.");
			mContainer.OnSignInFailed(mOrigin);
		}

		private void onSignInSucceeded()
		{
			Logger.d("GHM/GameHelperListener got onSignInSucceeded, origin " + mOrigin + ", notifying GHM.");
			mContainer.OnSignInSucceeded(mOrigin);
		}
	}

	public delegate void OnStopDelegate();

	private const string SignInHelperManagerClass = "com.google.example.games.pluginsupport.SignInHelperManager";

	private const string BaseGameUtilsPkg = "com.google.example.games.basegameutils";

	private const string GameHelperClass = "com.google.example.games.basegameutils.GameHelper";

	private const string GameHelperListenerClass = "com.google.example.games.basegameutils.GameHelper$GameHelperListener";

	private const int ORIGIN_MAIN_ACTIVITY = 1000;

	private const int ORIGIN_SIGN_IN_HELPER_ACTIVITY = 1001;

	private AndroidJavaObject mGameHelper;

	private AndroidClient mAndroidClient;

	private bool mPaused;

	private List<OnStopDelegate> mOnStopDelegates = new List<OnStopDelegate>();

	internal ConnectionState State
	{
		get
		{
			if (mGameHelper.Call<bool>("isSignedIn", new object[0]))
			{
				return ConnectionState.Connected;
			}
			if (mGameHelper.Call<bool>("isConnecting", new object[0]))
			{
				return ConnectionState.Connecting;
			}
			return ConnectionState.Disconnected;
		}
	}

	internal bool Connecting => mGameHelper.Call<bool>("isConnecting", new object[0]);

	public bool Paused => mPaused;

	internal GameHelperManager(AndroidClient client)
	{
		mAndroidClient = client;
		Logger.d("Setting up GameHelperManager.");
		Logger.d("GHM creating GameHelper.");
		int num = 7;
		Logger.d("GHM calling GameHelper constructor with flags=" + num);
		mGameHelper = new AndroidJavaObject("com.google.example.games.basegameutils.GameHelper", mAndroidClient.GetActivity(), num);
		if (mGameHelper == null)
		{
			throw new Exception("Failed to create GameHelper.");
		}
		Logger.d("GHM setting up GameHelper.");
		mGameHelper.Call("enableDebugLog", Logger.DebugLogEnabled);
		GameHelperListener gameHelperListener = new GameHelperListener(this, 1000);
		Logger.d("GHM Setting GameHelper options.");
		mGameHelper.Call("setMaxAutoSignInAttempts", 0);
		AndroidJavaClass gmsClass = JavaUtil.GetGmsClass("games.Games$GamesOptions");
		AndroidJavaObject androidJavaObject = gmsClass.CallStatic<AndroidJavaObject>("builder", new object[0]);
		AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("setSdkVariant", new object[1] { 37143 });
		AndroidJavaObject androidJavaObject3 = androidJavaObject.Call<AndroidJavaObject>("build", new object[0]);
		mGameHelper.Call("setGamesApiOptions", androidJavaObject3);
		androidJavaObject3.Dispose();
		androidJavaObject3 = null;
		androidJavaObject2.Dispose();
		androidJavaObject2 = null;
		androidJavaObject.Dispose();
		androidJavaObject = null;
		Logger.d("GHM calling GameHelper.setup");
		mGameHelper.Call("setup", gameHelperListener);
		Logger.d("GHM: GameHelper setup done.");
		Logger.d("GHM Setting up lifecycle.");
		PlayGamesHelperObject.SetPauseCallback(delegate(bool paused)
		{
			if (paused)
			{
				OnPause();
			}
			else
			{
				OnResume();
			}
		});
		Logger.d("GHM calling GameHelper.onStart to try initial auth.");
		mGameHelper.Call("onStart", mAndroidClient.GetActivity());
	}

	private void OnResume()
	{
		mPaused = false;
		Logger.d("GHM got OnResume, relaying to GameHelper");
		mGameHelper.Call("onStart", mAndroidClient.GetActivity());
	}

	private void OnPause()
	{
		Logger.d("GHM got OnPause, relaying to GameHelper");
		mPaused = true;
		foreach (OnStopDelegate mOnStopDelegate in mOnStopDelegates)
		{
			mOnStopDelegate();
		}
		mGameHelper.Call("onStop");
	}

	private void OnSignInFailed(int origin)
	{
		Logger.d("GHM got onSignInFailed, origin " + origin + ", notifying AndroidClient.");
		if (origin == 1001)
		{
			Logger.d("GHM got onSignInFailed from Sign In Helper. Showing error message.");
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.example.games.pluginsupport.SignInHelperManager"))
			{
				androidJavaClass.CallStatic("showErrorDialog", mAndroidClient.GetActivity());
			}
			Logger.d("Error message shown.");
		}
		mAndroidClient.OnSignInFailed();
	}

	private void OnSignInSucceeded(int origin)
	{
		Logger.d("GHM got onSignInSucceeded, origin " + origin + ", notifying AndroidClient.");
		switch (origin)
		{
		case 1000:
			mAndroidClient.OnSignInSucceeded();
			break;
		case 1001:
			Logger.d("GHM got helper's OnSignInSucceeded.");
			break;
		}
	}

	internal void BeginUserInitiatedSignIn()
	{
		Logger.d("GHM Starting user-initiated sign in.");
		Logger.d("Forcing GameHelper's connect-on-start flag to true.");
		mGameHelper.Call("setConnectOnStart", true);
		Logger.d("GHM launching sign-in Activity via SignInHelperManager.launchSignIn");
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.example.games.pluginsupport.SignInHelperManager");
		androidJavaClass.CallStatic("launchSignIn", mAndroidClient.GetActivity(), new GameHelperListener(this, 1001), Logger.DebugLogEnabled);
	}

	public AndroidJavaObject GetApiClient()
	{
		return mGameHelper.Call<AndroidJavaObject>("getApiClient", new object[0]);
	}

	public AndroidJavaObject GetInvitation()
	{
		if (mGameHelper.Call<bool>("hasInvitation", new object[0]))
		{
			return mGameHelper.Call<AndroidJavaObject>("getInvitation", new object[0]);
		}
		return null;
	}

	public AndroidJavaObject GetTurnBasedMatch()
	{
		if (mGameHelper.Call<bool>("hasTurnBasedMatch", new object[0]))
		{
			return mGameHelper.Call<AndroidJavaObject>("getTurnBasedMatch", new object[0]);
		}
		return null;
	}

	public void ClearInvitationAndTurnBasedMatch()
	{
		Logger.d("GHM clearing invitation and turn-based match on GameHelper.");
		mGameHelper.Call("clearInvitation");
		mGameHelper.Call("clearTurnBasedMatch");
	}

	public bool IsConnected()
	{
		return mGameHelper.Call<bool>("isSignedIn", new object[0]);
	}

	public void SignOut()
	{
		Logger.d("GHM SignOut");
		mGameHelper.Call("signOut");
	}

	public void AddOnStopDelegate(OnStopDelegate del)
	{
		mOnStopDelegates.Add(del);
	}

	private object[] makeGmsCallArgs(object[] args)
	{
		object[] array = new object[args.Length + 1];
		array[0] = GetApiClient();
		for (int i = 1; i < array.Length; i++)
		{
			array[i] = args[i - 1];
		}
		return array;
	}

	public ReturnType CallGmsApi<ReturnType>(string className, string fieldName, string methodName, params object[] args)
	{
		object[] args2 = makeGmsCallArgs(args);
		if (fieldName != null)
		{
			return JavaUtil.GetGmsField(className, fieldName).Call<ReturnType>(methodName, args2);
		}
		return JavaUtil.GetGmsClass(className).CallStatic<ReturnType>(methodName, args2);
	}

	public void CallGmsApi(string className, string fieldName, string methodName, params object[] args)
	{
		object[] args2 = makeGmsCallArgs(args);
		if (fieldName != null)
		{
			JavaUtil.GetGmsField(className, fieldName).Call(methodName, args2);
		}
		else
		{
			JavaUtil.GetGmsClass(className).CallStatic(methodName, args2);
		}
	}

	public void CallGmsApiWithResult(string className, string fieldName, string methodName, AndroidJavaProxy callbackProxy, params object[] args)
	{
		using AndroidJavaObject androidJavaObject = CallGmsApi<AndroidJavaObject>(className, fieldName, methodName, args);
		androidJavaObject.Call("setResultCallback", callbackProxy);
	}
}
