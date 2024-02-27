using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class Loading : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024Start_0024closure_00242916_002421381 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal UIPanel[] _0024panels_002421382;

			internal UIPanel _0024p_002421383;

			internal int _0024_002410775_002421384;

			internal UIPanel[] _0024_002410776_002421385;

			internal int _0024_002410777_002421386;

			internal Loading _0024self__002421387;

			public _0024(Loading self_)
			{
				_0024self__002421387 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
						_0024panels_002421382 = _0024self__002421387.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
						_0024_002410775_002421384 = 0;
						_0024_002410776_002421385 = _0024panels_002421382;
						for (_0024_002410777_002421386 = _0024_002410776_002421385.Length; _0024_002410775_002421384 < _0024_002410777_002421386; _0024_002410775_002421384++)
						{
							_0024_002410776_002421385[_0024_002410775_002421384].enabled = true;
						}
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal Loading _0024self__002421388;

		public _0024_0024Start_0024closure_00242916_002421381(Loading self_)
		{
			_0024self__002421388 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421388);
		}
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/Loading/Loading";

	[NonSerialized]
	private static Loading __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	protected static int loadingCount;

	public static Loading Instance
	{
		get
		{
			Loading _instance;
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
				__instance = ((Loading)UnityEngine.Object.FindObjectOfType(typeof(Loading))) as Loading;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static Loading CurrentInstance => __instance;

	public void _0024singleton_0024awake_00242525()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00242525();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static Loading _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/Loading/Loading");
		GameObject gameObject2;
		if (gameObject == null)
		{
			gameObject2 = new GameObject();
		}
		else
		{
			gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject)) as GameObject;
			if (gameObject2 == null)
			{
				gameObject2 = new GameObject();
			}
		}
		gameObject2.name = "__" + "Loading" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		Loading loading = ExtensionsModule.SetComponent<Loading>(gameObject2);
		if ((bool)loading)
		{
			loading._createInstance_callback();
		}
		return loading;
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

	public void _0024singleton_0024appQuit_00242526()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00242526();
		quitApp = true;
	}

	public static void Begin()
	{
		checked
		{
			loadingCount++;
			if (!CurrentInstance)
			{
				End();
				Loading instance = Instance;
				UIPanel[] componentsInChildren = instance.GetComponentsInChildren<UIPanel>(includeInactive: true);
				int i = 0;
				UIPanel[] array = componentsInChildren;
				for (int length = array.Length; i < length; i++)
				{
					array[i].enabled = false;
				}
			}
		}
	}

	public static void End()
	{
		checked
		{
			if (loadingCount > 0)
			{
				loadingCount--;
			}
			if (loadingCount <= 0)
			{
				DestroyInstance();
			}
		}
	}

	public void Start()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024Start_0024closure_00242916_002421381(this).GetEnumerator();
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void Update()
	{
		if (MerlinServer.Instance.IsBusy)
		{
			loadingCount = 0;
			End();
		}
		if (FaderCore.Instance.isOutCompleted)
		{
			loadingCount = 0;
			End();
		}
	}

	internal IEnumerator _0024Start_0024closure_00242916()
	{
		return new _0024_0024Start_0024closure_00242916_002421381(this).GetEnumerator();
	}
}
