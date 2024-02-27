using System.Collections;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Message")]
public class UIButtonMessage : MonoBehaviour
{
	public enum SendMode
	{
		Normal,
		Message,
		Integer
	}

	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
		OnDoubleClick
	}

	public delegate void ImmadiateHandler();

	public delegate void CantTouchHandler();

	private const float ScaleTime = 0.1f;

	private static bool allDisable;

	public ImmadiateHandler immadiateHandler;

	public CantTouchHandler cantTouchHandler;

	public GameObject target;

	public string functionName;

	public string longClickFunctionName;

	public Trigger trigger;

	public bool includeChildren;

	public bool sendMessage = true;

	public bool merlinPuwaEnable = true;

	public float merlinPuwaTime = 0.2f;

	public float merlinPuwaScale;

	public bool scaling = true;

	public UpdateManager.EventHandler eventHandler;

	private bool mStarted;

	private bool mHighlighted;

	private Vector3 cachedLocalScale = Vector3.one;

	private float cachedLocalZ;

	private int cachedSpriteDepth;

	private UIWidget[] widgets;

	private int[] widgetDepth;

	public float waitTime = 0.2f;

	public SendMode mode;

	public string message;

	public int integer;

	private Collider m_touch_collider;

	private bool lateFlag;

	public bool showDebug = true;

	public static bool AllDisable
	{
		get
		{
			return allDisable;
		}
		set
		{
			allDisable = value;
		}
	}

	private Vector3 PressedScale
	{
		get
		{
			float num = 1.3f;
			return new Vector3(cachedLocalScale.x * num, cachedLocalScale.y * num, 1f);
		}
	}

	private Vector3 NormalScale => cachedLocalScale;

	private Collider touch_collider
	{
		get
		{
			if (m_touch_collider == null)
			{
				m_touch_collider = base.collider;
			}
			return m_touch_collider;
		}
	}

	public bool isLocked
	{
		get
		{
			if (waitTime <= 0f)
			{
				return false;
			}
			return !touch_collider.enabled;
		}
	}

	private void Start()
	{
		mStarted = true;
		if (merlinPuwaEnable)
		{
			SetMerlinDefault();
			cachedLocalScale = base.transform.localScale;
			cachedLocalZ = base.transform.localPosition.z;
		}
		widgets = GetComponentsInChildren<UIWidget>(includeInactive: true);
		if (widgets != null)
		{
			widgetDepth = new int[widgets.Length];
			for (int i = 0; i < widgets.Length; i++)
			{
				widgetDepth[i] = widgets[i].depth;
			}
		}
	}

	private void SetMerlinDefault()
	{
		UIButtonScale component = GetComponent<UIButtonScale>();
		if (component != null)
		{
			component.hover = new Vector3(1f, 1f, 1f);
			component.duration = 0.1f;
			scaling = false;
		}
		UIButtonOffset component2 = GetComponent<UIButtonOffset>();
		if (component2 != null)
		{
			Object.Destroy(component2);
		}
	}

	private void OnEnable()
	{
		if (mStarted && mHighlighted)
		{
			if (showDebug)
			{
				lateFlag = touch_collider.enabled;
			}
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void OnDisable()
	{
		touch_collider.enabled = true;
	}

	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if ((isOver && trigger == Trigger.OnMouseOver) || (!isOver && trigger == Trigger.OnMouseOut))
			{
				ShowLog("OnHover:" + Time.time + "(f:" + Time.frameCount + ")");
				DoSend();
			}
			mHighlighted = isOver;
		}
	}

	public void Reset()
	{
		OnUpdateFocusEffect(pressed: false);
	}

	private void OnUpdateFocusEffect(bool pressed)
	{
		TweenScale.Begin(base.gameObject, 0.1f, (!pressed) ? NormalScale : PressedScale);
		ShowLog("scaling..." + pressed);
		UISprite uISprite = FindSpriteForMerlinPuwa();
		if (widgets != null && widgetDepth != null)
		{
			for (int i = 0; i < widgets.Length; i++)
			{
				widgets[i].depth = widgetDepth[i];
				if (pressed)
				{
					widgets[i].depth++;
				}
			}
		}
		if (uISprite != null && !(base.gameObject.name == "Skip Button"))
		{
			ShowLog("color..." + pressed);
			float num = 66f / 85f;
			TweenColor.Begin(uISprite.gameObject, 0.1f, (!pressed) ? new Color(1f, 1f, 1f, uISprite.color.a) : new Color(num, num, num, uISprite.color.a));
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (scaling && merlinPuwaEnable)
		{
			OnUpdateFocusEffect(UICamera.currentTouch.current == base.gameObject);
		}
	}

	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (scaling && merlinPuwaEnable)
			{
				OnUpdateFocusEffect(isPressed);
			}
			if ((isPressed && trigger == Trigger.OnPress) || (!isPressed && trigger == Trigger.OnRelease))
			{
				ShowLog("OnPress:" + Time.time + "(f:" + Time.frameCount + ")");
				DoSend();
			}
		}
	}

	private UISprite FindSpriteForMerlinPuwa()
	{
		UISprite[] componentsInChildren = base.gameObject.GetComponentsInChildren<UISprite>();
		foreach (UISprite uISprite in componentsInChildren)
		{
			string text = uISprite.gameObject.name;
			if (text.StartsWith("__puwacopy__"))
			{
				continue;
			}
			switch (text)
			{
			default:
				if (!(uISprite.spriteName == "fukidashi_base"))
				{
					continue;
				}
				break;
			case "bg":
			case "Background":
			case "Base":
				break;
			}
			return uISprite;
		}
		return null;
	}

	private bool SetMerlinPuwaTweener()
	{
		UISprite uISprite = FindSpriteForMerlinPuwa();
		if (uISprite != null)
		{
			GameObject gameObject = uISprite.gameObject;
			GameObject gameObject2 = (GameObject)Object.Instantiate(gameObject);
			gameObject2.transform.parent = base.transform;
			gameObject2.transform.localPosition = gameObject.transform.localPosition;
			gameObject2.transform.localScale = gameObject.transform.localScale;
			gameObject2.name = "__puwacopy__";
			UIPuwa uIPuwa = gameObject2.AddComponent<UIPuwa>();
			uIPuwa.duration = merlinPuwaTime;
			if (merlinPuwaScale > 1f)
			{
				uIPuwa.scaleTo = merlinPuwaScale;
			}
			uIPuwa.baseSprite.depth = uISprite.depth - 1;
		}
		return false;
	}

	private void OnClick()
	{
		if (base.enabled && trigger == Trigger.OnClick)
		{
			ShowLog("OnClick:" + Time.time + "(f:" + Time.frameCount + ")");
			DoSend();
		}
	}

	private void OnDoubleClick()
	{
		if (base.enabled && trigger == Trigger.OnDoubleClick)
		{
			ShowLog("OnDoubleClick:" + Time.time + "(f:" + Time.frameCount + ")");
			DoSend();
		}
	}

	public void DoSend()
	{
		if (!allDisable && sendMessage && (!merlinPuwaEnable || !SetMerlinPuwaTweener()))
		{
			LockTouch();
			if (immadiateHandler != null)
			{
				immadiateHandler();
			}
			UIButtonMessageSend();
		}
	}

	private void UIButtonMessageSend()
	{
		if (target == null)
		{
			target = base.gameObject;
		}
		if (includeChildren)
		{
			Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				UIButtonInvoke(transform.gameObject);
			}
		}
		else
		{
			UIButtonInvoke(target);
		}
	}

	private void LockTouch()
	{
		if (base.gameObject.activeInHierarchy)
		{
			touch_collider.enabled = false;
			StartCoroutine(CantTouchCoroutine());
		}
	}

	private IEnumerator CantTouchCoroutine()
	{
		ShowLog("Start CantTouchCoroutine[wait:$(waitTime)]:" + Time.time + "(f:" + Time.frameCount + ")");
		float time = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < time + waitTime)
		{
			ShowLog("        wait time:" + (Time.realtimeSinceStartup - time) + "(f:" + Time.frameCount + ")");
			yield return null;
		}
		touch_collider.enabled = true;
		if (cantTouchHandler != null)
		{
			cantTouchHandler();
		}
		ShowLog("End CantTouchCoroutine[wait:$(waitTime)]:" + Time.time + "(f:" + Time.frameCount + ")");
	}

	private void Update()
	{
		if (showDebug && base.gameObject.active && touch_collider.enabled != lateFlag)
		{
			lateFlag = touch_collider.enabled;
			ShowLog("switch touch_collider.enabled:" + touch_collider.enabled + "($(Time.time)(f:" + Time.frameCount + "))");
		}
	}

	private void SendMessage(GameObject target, object data)
	{
		if (eventHandler == null)
		{
			UpdateManager.AddButtonEvent(target, functionName, data);
		}
		else
		{
			UpdateManager.AddDelegateEvent(eventHandler, data);
		}
		ShowLog("SendMessage end:" + Time.time + "(f:" + Time.frameCount + ")");
	}

	private void UIButtonInvoke(GameObject target)
	{
		ShowLog("UIButtonInvoke start:" + Time.time + "(f:" + Time.frameCount + ")");
		switch (mode)
		{
		case SendMode.Normal:
			SendMessage(target, base.gameObject);
			break;
		case SendMode.Message:
			SendMessage(target, message);
			break;
		case SendMode.Integer:
			SendMessage(target, integer);
			break;
		default:
			SendMessage(target, base.gameObject);
			break;
		}
	}

	private void ShowLog(string str)
	{
		if (showDebug)
		{
			Debug.Log("[" + base.gameObject.name + "] " + str + "\n");
		}
	}
}
