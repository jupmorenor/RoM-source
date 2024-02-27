using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using UnityEngine;

[Serializable]
public class FaderCore : IgnoreTimeScale
{
	[Serializable]
	public enum Mode
	{
		FADE_IN,
		FADE_OUT
	}

	[NonSerialized]
	public const string DEFAULT_PREFAB_PATH = "Prefab/GUI/FaderCore";

	[NonSerialized]
	private static FaderCore __instance;

	[NonSerialized]
	protected static bool quitApp;

	[NonSerialized]
	private const float DEFAULT_TIME = 0.5f;

	public UISprite フェードするスプライト;

	private float fadeTime;

	public float _red;

	public float _green;

	public float _blue;

	private float alpha;

	private Mode mode;

	public Mode 現在のモード;

	public float 現在のアルファ;

	private bool pause;

	private float pauseTime;

	private int compCount;

	private bool ignoreTimeScale;

	private EventHandler _0024event_0024redChanged;

	private EventHandler _0024event_0024greenChanged;

	private EventHandler _0024event_0024blueChanged;

	public static FaderCore Instance
	{
		get
		{
			FaderCore _instance;
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
				__instance = ((FaderCore)UnityEngine.Object.FindObjectOfType(typeof(FaderCore))) as FaderCore;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static FaderCore CurrentInstance => __instance;

	public bool Pause
	{
		get
		{
			return pause;
		}
		set
		{
			if (value && !pause)
			{
				pauseTime = 0f;
			}
			pause = value;
		}
	}

	public bool isCompleted
	{
		get
		{
			bool num = isInCompleted;
			if (!num)
			{
				num = isOutCompleted;
			}
			return num;
		}
	}

	public bool isInCompleted
	{
		get
		{
			bool num = mode == Mode.FADE_IN;
			if (num)
			{
				num = !(alpha < 1f);
			}
			if (num)
			{
				num = compCount > 0;
			}
			return num;
		}
	}

	public bool isOutCompleted
	{
		get
		{
			bool num = mode == Mode.FADE_OUT;
			if (num)
			{
				num = !(alpha > 0f);
			}
			if (num)
			{
				num = compCount > 0;
			}
			return num;
		}
	}

	public bool isIn => mode == Mode.FADE_IN;

	public bool isOut => mode == Mode.FADE_OUT;

	public UISprite fadeSprite => フェードするスプライト;

	public float red
	{
		get
		{
			return _red;
		}
		set
		{
			_red = value;
			raise_redChanged(this, EventArgs.Empty);
		}
	}

	public float green
	{
		get
		{
			return _green;
		}
		set
		{
			_green = value;
			raise_greenChanged(this, EventArgs.Empty);
		}
	}

	public float blue
	{
		get
		{
			return _blue;
		}
		set
		{
			_blue = value;
			raise_blueChanged(this, EventArgs.Empty);
		}
	}

	public Mode curMode
	{
		get
		{
			return 現在のモード;
		}
		set
		{
			現在のモード = value;
		}
	}

	public float curAlpha
	{
		get
		{
			return 現在のアルファ;
		}
		set
		{
			現在のアルファ = value;
		}
	}

	public bool IgnoreTimeScale
	{
		get
		{
			return ignoreTimeScale;
		}
		set
		{
			ignoreTimeScale = value;
		}
	}

	public event EventHandler redChanged
	{
		add
		{
			_0024event_0024redChanged = (EventHandler)Delegate.Combine(_0024event_0024redChanged, value);
		}
		remove
		{
			_0024event_0024redChanged = (EventHandler)Delegate.Remove(_0024event_0024redChanged, value);
		}
	}

	public event EventHandler greenChanged
	{
		add
		{
			_0024event_0024greenChanged = (EventHandler)Delegate.Combine(_0024event_0024greenChanged, value);
		}
		remove
		{
			_0024event_0024greenChanged = (EventHandler)Delegate.Remove(_0024event_0024greenChanged, value);
		}
	}

	public event EventHandler blueChanged
	{
		add
		{
			_0024event_0024blueChanged = (EventHandler)Delegate.Combine(_0024event_0024blueChanged, value);
		}
		remove
		{
			_0024event_0024blueChanged = (EventHandler)Delegate.Remove(_0024event_0024blueChanged, value);
		}
	}

	public FaderCore()
	{
		fadeTime = 1f;
		mode = Mode.FADE_OUT;
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_0024680();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static FaderCore _createInstance()
	{
		GameObject gameObject = (GameObject)GameAssetModule.LoadPrefab("Prefab/GUI/FaderCore");
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
		gameObject2.name = "__" + "FaderCore" + "__";
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject2);
		FaderCore faderCore = ExtensionsModule.SetComponent<FaderCore>(gameObject2);
		if ((bool)faderCore)
		{
			faderCore._createInstance_callback();
		}
		return faderCore;
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

	public void _0024singleton_0024appQuit_0024681()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_0024681();
		quitApp = true;
	}

	public void fadeIn()
	{
		fadeIn(ignoreTScale: false);
	}

	public void fadeIn(bool ignoreTScale)
	{
		fadeInMain(ignoreTScale, 0.5f);
	}

	public void fadeOut()
	{
		fadeOut(ignoreTScale: false);
	}

	public void fadeOut(bool ignoreTScale)
	{
		fadeOutMain(ignoreTScale, 0.5f);
	}

	public void fadeInEx(float r, float g, float b, float speed)
	{
		if (!(speed > 0f))
		{
			throw new AssertionFailedException("speed > 0.0F");
		}
		_red = r;
		_green = g;
		_blue = b;
		fadeInMain(ignoreTScale: false, speed);
	}

	public void fadeOutEx(float r, float g, float b, float speed)
	{
		if (!(speed > 0f))
		{
			throw new AssertionFailedException("speed > 0.0F");
		}
		_red = r;
		_green = g;
		_blue = b;
		fadeOutMain(ignoreTScale: false, speed);
	}

	public void fadeInEx(float r, float g, float b, float speed, bool ignoreTScale)
	{
		if (!(speed > 0f))
		{
			throw new AssertionFailedException("speed > 0.0F");
		}
		_red = r;
		_red = r;
		_green = g;
		_blue = b;
		fadeInMain(ignoreTScale, speed);
	}

	public void fadeOutEx(float r, float g, float b, float speed, bool ignoreTScale)
	{
		if (!(speed > 0f))
		{
			throw new AssertionFailedException("speed > 0.0F");
		}
		_red = r;
		_green = g;
		_blue = b;
		fadeOutMain(ignoreTScale, speed);
	}

	public void Out()
	{
		mode = Mode.FADE_OUT;
		alpha = 0f;
		fadeSprite.color = new Color(_red, _green, _blue, alpha);
		activateSprite(b: true);
	}

	public void In()
	{
		mode = Mode.FADE_IN;
		alpha = 1f;
		fadeSprite.color = new Color(_red, _green, _blue, alpha);
		activateSprite(b: true);
	}

	public void fadeInFromOut()
	{
		Out();
		fadeIn();
	}

	public void fadeOutFromIn()
	{
		In();
		fadeOut();
	}

	public void fadeInFromOut(bool ignoreTScale)
	{
		Out();
		fadeIn(ignoreTScale);
	}

	public void fadeOutFromIn(bool ignoreTScale)
	{
		In();
		fadeOut(ignoreTScale);
	}

	private void fadeInMain(bool ignoreTScale, float tm)
	{
		mode = Mode.FADE_IN;
		pause = false;
		activateSprite(b: true);
		ignoreTimeScale = ignoreTScale;
		fadeTime = tm;
	}

	private void fadeOutMain(bool ignoreTScale, float tm)
	{
		mode = Mode.FADE_OUT;
		pause = false;
		activateSprite(b: true);
		ignoreTimeScale = ignoreTScale;
		fadeTime = tm;
	}

	public void _0024singleton_0024awake_0024680()
	{
		activateSprite(b: false);
		mode = Mode.FADE_OUT;
		redChanged += _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113.Adapt(delegate
		{
		});
		greenChanged += _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113.Adapt(delegate
		{
		});
		blueChanged += _0024adaptor_0024__FaderCore_0024callable309_0024175_23___0024EventHandler_0024113.Adapt(delegate
		{
		});
	}

	private void activateSprite(bool b)
	{
		if (fadeSprite != null)
		{
			fadeSprite.gameObject.SetActive(b);
		}
	}

	public void Update()
	{
		UpdateRealTimeDelta();
		curMode = mode;
		curAlpha = alpha;
		float num = ((!ignoreTimeScale) ? Time.deltaTime : realTimeDelta);
		float num2 = Mathf.Clamp(num / fadeTime, 0.0001f, 1f);
		if (pause)
		{
			pauseTime += num;
			if (!(pauseTime < 60f))
			{
				pause = false;
			}
		}
		while (num2 >= 0.5f)
		{
			num2 *= 0.5f;
		}
		checked
		{
			if (mode == Mode.FADE_IN)
			{
				alpha = Mathf.Clamp(alpha + num2, 0f, 1f);
				if (!(alpha <= 0f))
				{
					activateSprite(b: true);
				}
				if (!(alpha < 1f))
				{
					compCount++;
				}
				else
				{
					compCount = 0;
				}
			}
			else if (mode == Mode.FADE_OUT && !pause)
			{
				alpha = Mathf.Clamp(alpha - num2, 0f, 1f);
				if (!(alpha > 0f))
				{
					activateSprite(b: false);
					compCount++;
				}
				else
				{
					compCount = 0;
				}
			}
			fadeSprite.color = new Color(red, green, blue, alpha);
		}
	}

	public void fatalErrorReset()
	{
		fadeTime = 1f;
		_red = 0f;
		_green = 0f;
		_blue = 0f;
		alpha = 0f;
		if (fadeSprite != null)
		{
			fadeSprite.color = new Color(_red, _green, _blue, alpha);
		}
	}

	[SpecialName]
	protected internal void raise_redChanged(object sender, EventArgs e)
	{
		_0024event_0024redChanged?.Invoke(sender, e);
	}

	[SpecialName]
	protected internal void raise_greenChanged(object sender, EventArgs e)
	{
		_0024event_0024greenChanged?.Invoke(sender, e);
	}

	[SpecialName]
	protected internal void raise_blueChanged(object sender, EventArgs e)
	{
		_0024event_0024blueChanged?.Invoke(sender, e);
	}

	internal void _0024_0024singleton_0024awake_0024680_0024closure_00242917(FaderCore @this)
	{
	}

	internal void _0024_0024singleton_0024awake_0024680_0024closure_00242918(FaderCore @this)
	{
	}

	internal void _0024_0024singleton_0024awake_0024680_0024closure_00242919(FaderCore @this)
	{
	}
}
