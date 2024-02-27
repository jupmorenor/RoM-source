using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class SkipButtonHUD : MonoBehaviour
{
	[Serializable]
	internal class _0024SetShowButton_0024locals_002414481
	{
		internal bool _0024show;
	}

	[Serializable]
	internal class _0024SetShowButton_0024closure_00244412
	{
		internal SkipButtonHUD _0024this_002415063;

		internal _0024SetShowButton_0024locals_002414481 _0024_0024locals_002415064;

		public _0024SetShowButton_0024closure_00244412(SkipButtonHUD _0024this_002415063, _0024SetShowButton_0024locals_002414481 _0024_0024locals_002415064)
		{
			this._0024this_002415063 = _0024this_002415063;
			this._0024_0024locals_002415064 = _0024_0024locals_002415064;
		}

		public void Invoke()
		{
			if (_0024_0024locals_002415064._0024show)
			{
				_0024this_002415063.skipButtonCollider.enabled = true;
			}
			if (_0024this_002415063.useTouchScreen)
			{
				_0024this_002415063.touchScreenCollider.enabled = !_0024_0024locals_002415064._0024show;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024TouchEnabledSkip_0024coroutine_00244413_002421456 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242562_002421457;

			internal SkipButtonHUD _0024self__002421458;

			public _0024(SkipButtonHUD self_)
			{
				_0024self__002421458 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421458.SetShowButton(show: true);
					if (!(0f >= _0024self__002421458.hideTime))
					{
						_0024_0024wait_sec_0024temp_00242562_002421457 = _0024self__002421458.hideTime;
						goto case 2;
					}
					goto IL_0097;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242562_002421457 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242562_002421457 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__002421458.isSkip)
					{
						goto case 1;
					}
					_0024self__002421458.SetShowButton(show: false);
					goto IL_0097;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0097:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal SkipButtonHUD _0024self__002421459;

		public _0024_0024TouchEnabledSkip_0024coroutine_00244413_002421456(SkipButtonHUD self_)
		{
			_0024self__002421459 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421459);
		}
	}

	[NonSerialized]
	private static SkipButtonHUD instance;

	public bool hideStart;

	protected bool useTouchScreen;

	public float hideTime;

	public GameObject touchScreen;

	public GameObject skipButton;

	private UIButtonMessage touchScreenButton;

	private Collider touchScreenCollider;

	private Collider skipButtonCollider;

	private UITweener skipButtonAnim;

	private bool isSkip;

	public bool UseTouchScreen
	{
		set
		{
			useTouchScreen = value;
			if (useTouchScreen)
			{
				touchScreenCollider = touchScreen.GetComponent<Collider>();
				UIButtonMessage component = touchScreen.GetComponent<UIButtonMessage>();
				component.target = gameObject;
				component.functionName = "TouchEnabledSkip";
				touchScreenButton = component;
				touchScreen.SetActive(value: true);
			}
			else
			{
				touchScreen.SetActive(value: false);
			}
		}
	}

	public SkipButtonHUD()
	{
		hideTime = 100f;
	}

	public static SkipButtonHUD Instance()
	{
		if (!instance)
		{
			instance = (SkipButtonHUD)UnityEngine.Object.FindObjectOfType(typeof(SkipButtonHUD));
		}
		return instance;
	}

	public static void SetActive(bool a)
	{
		SkipButtonHUD skipButtonHUD = Instance();
		if ((bool)skipButtonHUD)
		{
			skipButtonHUD.gameObject.SetActive(a);
		}
	}

	public static void SetShow(bool show)
	{
		SkipButtonHUD skipButtonHUD = Instance();
		if ((bool)skipButtonHUD)
		{
			skipButtonHUD.SetShowButton(show);
		}
	}

	public static bool CanSkip()
	{
		SkipButtonHUD skipButtonHUD = Instance();
		return (bool)skipButtonHUD && skipButtonHUD.isSkip;
	}

	public static void Reset()
	{
		SkipButtonHUD skipButtonHUD = Instance();
		if ((bool)skipButtonHUD)
		{
			skipButtonHUD.isSkip = false;
		}
	}

	public void Awake()
	{
		isSkip = false;
		if (hideStart)
		{
			useTouchScreen = true;
		}
		UseTouchScreen = useTouchScreen;
		skipButtonCollider = skipButton.GetComponent<Collider>();
		skipButtonCollider.enabled = !hideStart;
		skipButtonAnim = skipButton.GetComponent<TweenAlpha>();
		skipButtonAnim.enabled = false;
		UIButtonMessage component = skipButton.GetComponent<UIButtonMessage>();
		component.target = gameObject;
		component.functionName = "TouchScreen";
	}

	public void Start()
	{
		skipButtonAnim.Sample((!hideStart) ? 1 : 0, isFinished: true);
	}

	private void SetShowButton(bool show)
	{
		_0024SetShowButton_0024locals_002414481 _0024SetShowButton_0024locals_0024 = new _0024SetShowButton_0024locals_002414481();
		_0024SetShowButton_0024locals_0024._0024show = show;
		if (!_0024SetShowButton_0024locals_0024._0024show)
		{
			skipButtonCollider.enabled = false;
		}
		if (useTouchScreen)
		{
			touchScreenCollider.enabled = false;
		}
		skipButtonAnim.Play(_0024SetShowButton_0024locals_0024._0024show);
		skipButtonAnim.Reset();
		skipButtonAnim.onFinished = _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024OnFinished_0024157.Adapt(new _0024SetShowButton_0024closure_00244412(this, _0024SetShowButton_0024locals_0024).Invoke);
	}

	public void TouchEnabledSkip()
	{
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024TouchEnabledSkip_0024coroutine_00244413_002421456(this).GetEnumerator();
		StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
	}

	public void TouchScreen()
	{
		isSkip = true;
	}

	internal IEnumerator _0024TouchEnabledSkip_0024coroutine_00244413()
	{
		return new _0024_0024TouchEnabledSkip_0024coroutine_00244413_002421456(this).GetEnumerator();
	}
}
