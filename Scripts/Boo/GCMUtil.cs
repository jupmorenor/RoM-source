using System;
using System.Collections.Generic;
using Prime31;
using UnityEngine;

[Serializable]
public class GCMUtil : MonoBehaviour
{
	[NonSerialized]
	private static GCMUtil __instance;

	[NonSerialized]
	protected static bool quitApp;

	public static GCMUtil Instance
	{
		get
		{
			GCMUtil _instance;
			if (quitApp)
			{
				_instance = __instance;
			}
			else if (__instance != null)
			{
				_instance = __instance;
			}
			else
			{
				__instance = ((GCMUtil)UnityEngine.Object.FindObjectOfType(typeof(GCMUtil))) as GCMUtil;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static GCMUtil CurrentInstance => __instance;

	public void _0024singleton_0024awake_00242717()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242717();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static GCMUtil _createInstance()
	{
		string text = "__" + "GCMUtil" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		GCMUtil gCMUtil = ExtensionsModule.SetComponent<GCMUtil>(gameObject);
		if ((bool)gCMUtil)
		{
			gCMUtil._createInstance_callback();
		}
		return gCMUtil;
	}

	public void _createInstance_callback()
	{
	}

	public static void DestroyInstance()
	{
		if ((bool)__instance)
		{
			UnityEngine.Object.DestroyObject(__instance.gameObject);
		}
		__instance = null;
	}

	public void _0024singleton_0024appQuit_00242718()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242718();
		quitApp = true;
	}

	private void OnEnable()
	{
		GoogleCloudMessagingManager.notificationReceivedEvent += notificationReceivedEvent;
		GoogleCloudMessagingManager.registrationSucceededEvent += registrationSucceededEvent;
		GoogleCloudMessagingManager.unregistrationFailedEvent += unregistrationFailedEvent;
		GoogleCloudMessagingManager.registrationFailedEvent += registrationFailedEvent;
		GoogleCloudMessagingManager.unregistrationSucceededEvent += unregistrationSucceededEvent;
	}

	private void OnDisable()
	{
		GoogleCloudMessagingManager.notificationReceivedEvent -= notificationReceivedEvent;
		GoogleCloudMessagingManager.registrationSucceededEvent -= registrationSucceededEvent;
		GoogleCloudMessagingManager.unregistrationFailedEvent -= unregistrationFailedEvent;
		GoogleCloudMessagingManager.registrationFailedEvent -= registrationFailedEvent;
		GoogleCloudMessagingManager.unregistrationSucceededEvent -= unregistrationSucceededEvent;
	}

	private void notificationReceivedEvent(Dictionary<string, object> dict)
	{
		Utils.logObject(dict);
	}

	private void registrationSucceededEvent(string registrationId)
	{
	}

	private void unregistrationFailedEvent(string error)
	{
	}

	private void registrationFailedEvent(string error)
	{
	}

	private void unregistrationSucceededEvent()
	{
	}
}
