using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HUDHappaTimer : MonoBehaviour
{
	public UISprite[] 葉っぱ;

	private Queue<UISprite> leafQ;

	private int dropNum;

	private bool shown;

	private bool isAutoTimer;

	private float autoTime;

	private float autoTimeLimit;

	[NonSerialized]
	private static List<HUDHappaTimer> _InstanceList = new List<HUDHappaTimer>();

	public static float CurrentAutoTime => Instance.autoTime;

	public static HUDHappaTimer Instance
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0];
		}
	}

	public static int EnabledInstanceNum => _InstanceList.Count;

	public static bool Exists => _InstanceList.Count > 0;

	public static bool ExistsOne => _InstanceList.Count == 1;

	public static UISprite[] Leaves
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__Leaves;
		}
	}

	public UISprite[] __Leaves => 葉っぱ;

	public HUDHappaTimer()
	{
		leafQ = new Queue<UISprite>();
	}

	public void _0024hud_0024OnEnable()
	{
	}

	public void _0024hud_0024OnDisable()
	{
	}

	public void OnEnable()
	{
		if (_InstanceList.Count > 2)
		{
		}
		_InstanceList.Add(this);
		_0024hud_0024OnEnable();
	}

	public void OnDisable()
	{
		_0024hud_0024OnDisable();
		_InstanceList.Remove(this);
	}

	public static void SetTime(float time, float maxTime)
	{
		foreach (HUDHappaTimer instance in _InstanceList)
		{
			instance.__SetTime(time, maxTime);
		}
	}

	protected void __SetTime(float time, float maxTime)
	{
		int num = Mathf.CeilToInt(time / maxTime * (float)Leaves.Length);
		dropNum = checked(leafQ.Count - num);
		Show();
	}

	public static void Show()
	{
		foreach (HUDHappaTimer instance in _InstanceList)
		{
			instance.__Show();
		}
	}

	protected void __Show()
	{
		if (!shown)
		{
			int i = 0;
			GameObject[] array = ExtensionsModule.Children(gameObject);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].SetActive(value: true);
			}
			shown = true;
		}
	}

	public static void ShowAutoTimer(float startTime)
	{
		foreach (HUDHappaTimer instance in _InstanceList)
		{
			instance.__ShowAutoTimer(startTime);
		}
	}

	protected void __ShowAutoTimer(float startTime)
	{
		isAutoTimer = true;
		autoTimeLimit = startTime;
		autoTime = startTime;
		Show();
	}

	public static void SetAutoTimer(bool b)
	{
		foreach (HUDHappaTimer instance in _InstanceList)
		{
			instance.__SetAutoTimer(b);
		}
	}

	protected void __SetAutoTimer(bool b)
	{
		isAutoTimer = b;
	}

	public static void Hide()
	{
		foreach (HUDHappaTimer instance in _InstanceList)
		{
			instance.__Hide();
		}
	}

	protected void __Hide()
	{
		if (shown)
		{
			int i = 0;
			GameObject[] array = ExtensionsModule.Children(gameObject);
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				array[i].SetActive(value: false);
			}
		}
	}

	public void Start()
	{
		int i = 0;
		UISprite[] leaves = Leaves;
		for (int length = leaves.Length; i < length; i = checked(i + 1))
		{
			leafQ.Enqueue(leaves[i]);
			activateUITweeners(leaves[i], b: false);
		}
		Hide();
		shown = false;
	}

	public void Update()
	{
		if (!shown || leafQ.Count <= 0)
		{
			return;
		}
		if (dropNum > 0)
		{
			int i = 0;
			for (int num = Mathf.Min(dropNum, leafQ.Count); i < num; i = checked(i + 1))
			{
				activateUITweeners(leafQ.Dequeue(), b: true);
			}
			dropNum = 0;
		}
		if (isAutoTimer)
		{
			autoTime -= Time.deltaTime;
			autoTime = Mathf.Max(autoTime, 0f);
			SetTime(autoTime, autoTimeLimit);
		}
	}

	private void activateUITweeners(UISprite spr, bool b)
	{
		if (!(spr == null))
		{
			int i = 0;
			UITweener[] components = spr.gameObject.GetComponents<UITweener>();
			for (int length = components.Length; i < length; i = checked(i + 1))
			{
				components[i].enabled = b;
			}
		}
	}
}
