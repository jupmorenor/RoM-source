using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class FolonClockController : MonoBehaviour
{
	[Serializable]
	public class BonesReference
	{
		public GameObject folon;

		public Transform yang;

		public Transform cog;

		public Transform head;

		public Transform clockRoot;

		public Transform largeGear;

		public Transform smallGear;

		public Transform dial;

		public Transform shortHand;

		public Transform minuteHand;

		public BonesReference(GameObject g)
		{
			folon = g;
			IEnumerator enumerator = g.transform.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is Transform))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Transform));
				}
				Transform transform = (Transform)obj;
				if (!(clockRoot != null))
				{
					yang = transform.Find("y_ang");
					cog = transform.Find("y_ang/cog");
					head = transform.Find("y_ang/cog/c_spine_a/c_spine_b/c_spine_c/c_neck/c_head");
					clockRoot = transform.Find("y_ang/c_clock");
					largeGear = transform.Find("y_ang/c_clock/l_gear_01");
					smallGear = transform.Find("y_ang/c_clock/l_gear_02");
					dial = transform.Find("y_ang/c_clock/c_gear_01");
					shortHand = transform.Find("y_ang/c_clock/c_short_hand");
					minuteHand = transform.Find("y_ang/c_clock/c_Minute_hand");
				}
			}
			if (!(folon != null))
			{
				throw new AssertionFailedException("folon != null");
			}
			if (!(yang != null))
			{
				throw new AssertionFailedException("yang != null");
			}
			if (!(cog != null))
			{
				throw new AssertionFailedException("cog != null");
			}
			if (!(head != null))
			{
				throw new AssertionFailedException("head != null");
			}
			if (!(clockRoot != null))
			{
				throw new AssertionFailedException("clockRoot != null");
			}
			if (!(largeGear != null))
			{
				throw new AssertionFailedException("largeGear != null");
			}
			if (!(smallGear != null))
			{
				throw new AssertionFailedException("smallGear != null");
			}
			if (!(dial != null))
			{
				throw new AssertionFailedException("dial != null");
			}
			if (!(shortHand != null))
			{
				throw new AssertionFailedException("shortHand != null");
			}
			if (!(minuteHand != null))
			{
				throw new AssertionFailedException("minuteHand != null");
			}
		}
	}

	[NonSerialized]
	private static FolonClockController __instance;

	[NonSerialized]
	protected static bool quitApp;

	private MerlinMotionPackControl _mmpc;

	public float _globalSpeedRate;

	public BonesReference _bones;

	public static FolonClockController Instance
	{
		get
		{
			FolonClockController _instance;
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
				__instance = ((FolonClockController)UnityEngine.Object.FindObjectOfType(typeof(FolonClockController))) as FolonClockController;
				if (__instance == null)
				{
					__instance = _createInstance();
				}
				_instance = __instance;
			}
			return _instance;
		}
	}

	public static FolonClockController CurrentInstance => __instance;

	private MerlinMotionPackControl mmpc
	{
		get
		{
			object result;
			if (_mmpc == null)
			{
				_mmpc = gameObject.GetComponentInChildren<MerlinMotionPackControl>();
				result = ((!(_mmpc != null)) ? null : _mmpc);
			}
			else
			{
				result = _mmpc;
			}
			return (MerlinMotionPackControl)result;
		}
	}

	public float GlobalSpeedRate
	{
		get
		{
			float num = default(float);
			num = ((!(mmpc != null)) ? _globalSpeedRate : (mmpc.TimeScale * _globalSpeedRate));
			return ((double)num >= 0.0) ? num : 0f;
		}
	}

	public BonesReference bones
	{
		get
		{
			BonesReference result;
			if (_bones == null)
			{
				_bones = new BonesReference(gameObject);
				result = _bones;
			}
			else
			{
				result = _bones;
			}
			return result;
		}
	}

	public FolonClockController()
	{
		_globalSpeedRate = 1f;
	}

	public void _0024singleton_0024awake_00241630()
	{
	}

	public void Awake()
	{
		if (__instance == null || __instance == this)
		{
			__instance = this;
			SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
			_0024singleton_0024awake_00241630();
			return;
		}
		if ((bool)gameObject)
		{
			UnityEngine.Object.DestroyObject(gameObject);
		}
		UnityEngine.Object.Destroy(this);
	}

	private static FolonClockController _createInstance()
	{
		string text = "__" + "FolonClockController" + "__";
		GameObject gameObject = new GameObject(text);
		SceneDontDestroyObject.dontDestroyOnLoad(gameObject);
		FolonClockController folonClockController = ExtensionsModule.SetComponent<FolonClockController>(gameObject);
		if ((bool)folonClockController)
		{
			folonClockController._createInstance_callback();
		}
		return folonClockController;
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

	public void _0024singleton_0024appQuit_00241631()
	{
	}

	public void OnApplicationQuit()
	{
		_0024singleton_0024appQuit_00241631();
		quitApp = true;
	}

	public virtual void init()
	{
	}

	public void Start()
	{
		searchBones();
		int i = 0;
		FolonClockSub[] componentsInChildren = gameObject.GetComponentsInChildren<FolonClockSub>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			componentsInChildren[i].StartMove();
		}
	}

	public void FixedUpdate()
	{
	}

	public void searchBones()
	{
		_bones = new BonesReference(gameObject);
	}

	public int[] getTime()
	{
		if (bones == null)
		{
		}
		int hour = getHour();
		int minute = getMinute();
		return new int[2] { hour, minute };
	}

	public int getHour()
	{
		return checked((int)Math.Floor(bones.shortHand.transform.eulerAngles.z)) / 30;
	}

	public int getMinute()
	{
		return checked((int)Math.Floor(bones.minuteHand.transform.eulerAngles.z)) / 6;
	}

	public void setTimeImmediately(int h, int m)
	{
		setMinuteImmediately(m);
		setHourImmediately(h);
	}

	public void setHourImmediately(int h)
	{
		int hour = getHour();
		int minute = getMinute();
		checked
		{
			int num = ((h >= 12) ? (h - 12) : h);
			num = (int)((double)num + (double)(float)minute / 60.0);
			int num2 = num;
			Vector3 localEulerAngles = bones.shortHand.localEulerAngles;
			float num3 = (localEulerAngles.z = num2);
			Vector3 vector2 = (bones.shortHand.localEulerAngles = localEulerAngles);
		}
	}

	public IEnumerator setMinuteImmediately(int m)
	{
		int minute = getMinute();
		int num = ((m >= 60) ? checked(m - 60) : m);
		int num2 = num;
		Vector3 localEulerAngles = bones.minuteHand.localEulerAngles;
		float num3 = (localEulerAngles.z = num2);
		Vector3 vector2 = (bones.minuteHand.localEulerAngles = localEulerAngles);
		return null;
	}

	public void hideClock()
	{
		setMeshVisibility("_clock", b: false);
	}

	public void showClock()
	{
		setMeshVisibility("_clock", b: true);
	}

	private void setMeshVisibility(string name, bool b)
	{
		int i = 0;
		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		for (int length = componentsInChildren.Length; i < length; i = checked(i + 1))
		{
			if (componentsInChildren[i].gameObject.name.ToLower().EndsWith("_clock"))
			{
				componentsInChildren[i].enabled = b;
			}
		}
	}
}
