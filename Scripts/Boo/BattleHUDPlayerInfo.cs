using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDPlayerInfo : MonoBehaviour
{
	public UISlider HitPointBar;

	public UILabel HitPointNum;

	public GameObject RecoveryDamageBar;

	public UISprite ZokuseiIcon;

	public GameObject ZokuseiDeco;

	public TweenColor[] HitPointNumTweenColor;

	public UISprite[] SignalIcon;

	[NonSerialized]
	private const float DAMAGE_BAR_SCALE = 262f;

	private Color initHitPointNumColor;

	private UIDisplayMode dispMode;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDPlayerInfo> _InstanceList = new Boo.Lang.List<BattleHUDPlayerInfo>();

	public static BattleHUDPlayerInfo Instance
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

	public BattleHUDPlayerInfo()
	{
		dispMode = UIDisplayMode.None;
	}

	public void Start()
	{
		if (HitPointNum != null)
		{
			initHitPointNumColor = HitPointNum.color;
		}
	}

	public void _0024hud_0024OnEnable()
	{
		dispMode = UIDisplayMode.None;
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

	public static void Activate(bool b)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__Activate(b);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Activate(bool b)
	{
		if (HitPointBar != null)
		{
			HitPointBar.gameObject.SetActive(b);
		}
		if (ZokuseiIcon != null)
		{
			ZokuseiIcon.gameObject.SetActive(b);
		}
		if (!b)
		{
			int num = 0;
			int length = SignalIcon.Length;
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < length)
			{
				int index = num;
				num++;
				HideSignal(index);
			}
		}
	}

	public static void Show()
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__Show();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Show()
	{
		if (dispMode != UIDisplayMode.Showing)
		{
			Activate(b: true);
			dispMode = UIDisplayMode.Showing;
		}
	}

	public static void Hide()
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__Hide();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Hide()
	{
		if (dispMode != UIDisplayMode.Hiding)
		{
			Activate(b: false);
			dispMode = UIDisplayMode.Hiding;
		}
	}

	public static void SetHitPointBarValue(float value, float maximum)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__SetHitPointBarValue(value, maximum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetHitPointBarValue(float value, float maximum)
	{
		if (HitPointBar != null)
		{
			HitPointBar.sliderValue = value / maximum;
		}
	}

	public static void SetHitPointNum(int val)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__SetHitPointNum(val);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetHitPointNum(int val)
	{
		HitPointNum.text = val.ToString();
	}

	public static void SetZokuseiIcon(string sprite)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__SetZokuseiIcon(sprite);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetZokuseiIcon(string sprite)
	{
		if (ZokuseiIcon != null)
		{
			ZokuseiIcon.spriteName = sprite;
		}
	}

	public static void SetZokuseiDecoTween(Hashtable tweenData)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__SetZokuseiDecoTween(tweenData);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetZokuseiDecoTween(Hashtable tweenData)
	{
		if (!(ZokuseiDeco == null) && tweenData != null)
		{
			iTween.RotateTo(ZokuseiDeco, tweenData);
		}
	}

	public static void SetRecoverDamageBar(float hitPoint, float maxHitPoint, float recoveryDamage)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__SetRecoverDamageBar(hitPoint, maxHitPoint, recoveryDamage);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetRecoverDamageBar(float hitPoint, float maxHitPoint, float recoveryDamage)
	{
		if (!(RecoveryDamageBar == null))
		{
			float a = (hitPoint + recoveryDamage) * 262f / maxHitPoint;
			float b = 262f;
			float x = Mathf.Min(a, b);
			Vector3 localScale = RecoveryDamageBar.transform.localScale;
			float num = (localScale.x = x);
			Vector3 vector2 = (RecoveryDamageBar.transform.localScale = localScale);
		}
	}

	public static void EnableNearDeathTween()
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__EnableNearDeathTween();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableNearDeathTween()
	{
		if (!(HitPointNumTweenColor == null))
		{
			int i = 0;
			TweenColor[] hitPointNumTweenColor = HitPointNumTweenColor;
			for (int length = hitPointNumTweenColor.Length; i < length; i = checked(i + 1))
			{
				hitPointNumTweenColor[i].enabled = true;
			}
		}
	}

	public static void DisableNearDeathTween()
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__DisableNearDeathTween();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableNearDeathTween()
	{
		if (!(HitPointNumTweenColor == null) && !(HitPointNum == null))
		{
			int i = 0;
			TweenColor[] hitPointNumTweenColor = HitPointNumTweenColor;
			for (int length = hitPointNumTweenColor.Length; i < length; i = checked(i + 1))
			{
				hitPointNumTweenColor[i].enabled = false;
			}
			HitPointNum.color = initHitPointNumColor;
		}
	}

	public static void ShowSignal(int index, string sprite)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__ShowSignal(index, sprite);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ShowSignal(int index, string sprite)
	{
		if (SignalIcon.Length > index)
		{
			UISprite[] signalIcon = SignalIcon;
			if ((bool)signalIcon[RuntimeServices.NormalizeArrayIndex(signalIcon, index)])
			{
				UISprite[] signalIcon2 = SignalIcon;
				signalIcon2[RuntimeServices.NormalizeArrayIndex(signalIcon2, index)].enabled = true;
				UISprite[] signalIcon3 = SignalIcon;
				signalIcon3[RuntimeServices.NormalizeArrayIndex(signalIcon3, index)].spriteName = sprite;
			}
		}
	}

	public static void HideSignal(int index)
	{
		IEnumerator<BattleHUDPlayerInfo> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDPlayerInfo current = enumerator.Current;
				current.__HideSignal(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __HideSignal(int index)
	{
		if (SignalIcon.Length > index)
		{
			UISprite[] signalIcon = SignalIcon;
			if ((bool)signalIcon[RuntimeServices.NormalizeArrayIndex(signalIcon, index)])
			{
				UISprite[] signalIcon2 = SignalIcon;
				signalIcon2[RuntimeServices.NormalizeArrayIndex(signalIcon2, index)].enabled = false;
			}
		}
	}
}
