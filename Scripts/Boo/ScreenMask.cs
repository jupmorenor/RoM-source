using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class ScreenMask : MonoBehaviour
{
	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/ScreenMask";

	[NonSerialized]
	private static ScreenMask __instance;

	[NonSerialized]
	protected static bool quitApp;

	public UISprite フェードスプライト;

	private float alpha;

	private float targetAlpha;

	private float lastAlpha;

	[NonSerialized]
	private static readonly float FADE_SPEED = 3.3333333f;

	public static ScreenMask Instance
	{
		get
		{
			ScreenMask _instance;
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
				__instance = ((ScreenMask)UnityEngine.Object.FindObjectOfType(typeof(ScreenMask))) as ScreenMask;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static ScreenMask CurrentInstance => __instance;

	public UISprite FadeSprite => フェードスプライト;

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241827();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static ScreenMask _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/ScreenMask");
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
		gameObject2.name = "__" + "ScreenMask" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		ScreenMask screenMask = ExtensionsModule.SetComponent<ScreenMask>(gameObject2);
		if ((bool)screenMask)
		{
			screenMask._createInstance_callback();
		}
		return screenMask;
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

	public void _0024singleton_0024appQuit_00241828()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241828();
		quitApp = true;
	}

	public void _0024singleton_0024awake_00241827()
	{
		deactivate();
	}

	public void activate()
	{
		if ((bool)FadeSprite)
		{
			lastAlpha = FadeSprite.color.a;
		}
		fade(0.5f);
	}

	public void activate(float targetAlpha)
	{
		if ((bool)FadeSprite)
		{
			lastAlpha = FadeSprite.color.a;
		}
		fade(targetAlpha);
	}

	public static void deactivate()
	{
		if ((bool)CurrentInstance)
		{
			if ((bool)CurrentInstance.FadeSprite)
			{
				CurrentInstance.lastAlpha = CurrentInstance.FadeSprite.color.a;
			}
			CurrentInstance.fade(0f);
		}
	}

	private void fade(float targetAlpha)
	{
		this.targetAlpha = targetAlpha;
	}

	public void Update()
	{
		float num = FADE_SPEED * Time.deltaTime;
		if (!(targetAlpha <= alpha))
		{
			alpha = Mathf.Min(alpha + num, targetAlpha);
			FadeSprite.color = new Color(0f, 0f, 0f, alpha);
		}
		else if (!(targetAlpha >= alpha))
		{
			alpha = Mathf.Max(alpha - num, targetAlpha);
			FadeSprite.color = new Color(0f, 0f, 0f, alpha);
		}
		else if (lastAlpha != alpha)
		{
			FadeSprite.color = new Color(0f, 0f, 0f, alpha);
			lastAlpha = alpha;
		}
	}
}
