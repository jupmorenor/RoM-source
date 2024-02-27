using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class NotificationUpdate : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024updateDeviceTokenForAndroid_002423082 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal ApiPlatformUpdateDeviceToken _0024req_002423083;

			internal string _0024token_002423084;

			internal string _0024registrationId_002423085;

			public _0024(string registrationId)
			{
				_0024registrationId_002423085 = registrationId;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024req_002423083 = new ApiPlatformUpdateDeviceToken();
					_0024req_002423083.uuid = CurrentInfo.UUID;
					_0024token_002423084 = _0024registrationId_002423085;
					if (!string.IsNullOrEmpty(_0024token_002423084))
					{
						_0024req_002423083.deviceToken = _0024token_002423084;
						_0024req_002423083.retryCount = 0;
						_0024req_002423083.ignoreAllErrors = true;
						MerlinServer.Request(_0024req_002423083);
						goto case 2;
					}
					goto IL_00d8;
				case 2:
					if (!_0024req_002423083.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024req_002423083.IsOk && _0024req_002423083.GetResponse().Result)
					{
						CurrentInfo.AndroidNotificationDeviceTokenSent = true;
					}
					goto IL_00d8;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00d8:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024registrationId_002423086;

		public _0024updateDeviceTokenForAndroid_002423082(string registrationId)
		{
			_0024registrationId_002423086 = registrationId;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024registrationId_002423086);
		}
	}

	[NonSerialized]
	private static string _SentToken;

	private static bool WasTokenSent => !string.IsNullOrEmpty(_SentToken);

	public static string SentToken => _SentToken;

	public void Awake()
	{
	}

	public void Start()
	{
		if (!CurrentInfo.HasUUID || CurrentInfo.AndroidNotificationDeviceTokenSent)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		IEnumerator enumerator = registNotification();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public static void Regist()
	{
	}

	private IEnumerator registNotification()
	{
		string gcmSenderId = "537118308623";
		GoogleCloudMessagingManager.registrationSucceededEvent += onAndroidRegistrationSucceed;
		GoogleCloudMessaging.register(gcmSenderId);
		return null;
	}

	private void onAndroidRegistrationSucceed(string registrationId)
	{
		IEnumerator enumerator = updateDeviceTokenForAndroid(registrationId);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		UnityEngine.Object.Destroy(this);
	}

	private IEnumerator updateDeviceTokenForAndroid(string registrationId)
	{
		return new _0024updateDeviceTokenForAndroid_002423082(registrationId).GetEnumerator();
	}
}
