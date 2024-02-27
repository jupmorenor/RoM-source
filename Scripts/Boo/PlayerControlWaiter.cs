using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PlayerControlWaiter : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024main_002417163 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal PlayerControl _0024p_002417164;

			internal ICallable _0024c_002417165;

			public _0024(ICallable c)
			{
				_0024c_002417165 = c;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024p_002417164 = null;
					goto case 2;
				case 2:
					_0024p_002417164 = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
					if (_0024p_002417164 != null)
					{
						goto case 3;
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 3:
					if (!_0024p_002417164.IsReady)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					if (_0024c_002417165 != null)
					{
						_0024c_002417165.Call(new object[0]);
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal ICallable _0024c_002417166;

		public _0024main_002417163(ICallable c)
		{
			_0024c_002417166 = c;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024c_002417166);
		}
	}

	[NonSerialized]
	private static PlayerControlWaiter __instance;

	[NonSerialized]
	protected static bool quitApp;

	public static PlayerControlWaiter Instance
	{
		get
		{
			PlayerControlWaiter _instance;
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
				__instance = ((PlayerControlWaiter)UnityEngine.Object.FindObjectOfType(typeof(PlayerControlWaiter))) as PlayerControlWaiter;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static PlayerControlWaiter CurrentInstance => __instance;

	public void _0024singleton_0024awake_00241398()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241398();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static PlayerControlWaiter _createInstance()
	{
		string text = "__" + "PlayerControlWaiter" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		PlayerControlWaiter playerControlWaiter = ExtensionsModule.SetComponent<PlayerControlWaiter>(gameObject);
		if ((bool)playerControlWaiter)
		{
			playerControlWaiter._createInstance_callback();
		}
		return playerControlWaiter;
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

	public void _0024singleton_0024appQuit_00241399()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241399();
		quitApp = true;
	}

	public void entryJob(ICallable c)
	{
		StartCoroutine(main(c));
	}

	private IEnumerator main(ICallable c)
	{
		return new _0024main_002417163(c).GetEnumerator();
	}
}
