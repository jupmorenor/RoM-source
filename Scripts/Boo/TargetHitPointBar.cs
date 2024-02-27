using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TargetHitPointBar : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024animationLockOnMain_002421466 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024_0024wait_sec_0024temp_00242564_002421467;

			internal TargetHitPointBar _0024self__002421468;

			public _0024(TargetHitPointBar self_)
			{
				_0024self__002421468 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__002421468.hitPointBar.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
					_0024_0024wait_sec_0024temp_00242564_002421467 = 0.3f;
					goto case 2;
				case 2:
					if (_0024_0024wait_sec_0024temp_00242564_002421467 > 0f)
					{
						_0024_0024wait_sec_0024temp_00242564_002421467 -= Time.deltaTime;
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					iTween.ScaleTo(_0024self__002421468.hitPointBar.gameObject, iTween.Hash("x", 1f, "y", 1f, "time", 0.3f));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TargetHitPointBar _0024self__002421469;

		public _0024animationLockOnMain_002421466(TargetHitPointBar self_)
		{
			_0024self__002421469 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421469);
		}
	}

	private GameObject target;

	private BaseControl targetBaseControl;

	public UISlider hitPointBar;

	public RaidNamePlate nameLabel;

	public UILabel zokuseiDamageAdjust;

	public UISprite zokuseiIcon;

	public UISprite zokuseiArrow;

	public UISprite rareIcon;

	public UIButtonMessage targetButton;

	public UISprite targetWeakStyle;

	private bool savedVisibility;

	private bool visibility;

	[NonSerialized]
	private const float LOCKON_ANIMATION_SIZE = 1.2f;

	[NonSerialized]
	private const float LOCKON_ANIMATION_TIME = 0.3f;

	[NonSerialized]
	private static Boo.Lang.List<TargetHitPointBar> _InstanceList = new Boo.Lang.List<TargetHitPointBar>();

	public static TargetHitPointBar Instance
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

	public void Start()
	{
		bool num = hitPointBar != null;
		if (num)
		{
			num = hitPointBar.gameObject.activeSelf;
		}
		visibility = num;
	}

	public void Update()
	{
		if (hitPointBar == null)
		{
			return;
		}
		if (targetBaseControl == null)
		{
			__Hide();
		}
		if (targetBaseControl != null)
		{
			float maxHitPoint = targetBaseControl.MaxHitPoint;
			if (!(maxHitPoint <= 0f))
			{
				hitPointBar.sliderValue = targetBaseControl.HitPoint / maxHitPoint;
			}
			else
			{
				hitPointBar.sliderValue = 0f;
			}
		}
		if (!visibility && hitPointBar.gameObject.activeSelf)
		{
			hitPointBar.gameObject.SetActive(value: false);
		}
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

	public static void SetPlayer(GameObject t)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__SetPlayer(t);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetPlayer(GameObject t)
	{
		if (!(t == null) && !(targetButton == null))
		{
			targetButton.target = t;
		}
	}

	public static void SaveVisibility()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__SaveVisibility();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SaveVisibility()
	{
		savedVisibility = visibility;
	}

	public static void RestoreVisibility()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__RestoreVisibility();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __RestoreVisibility()
	{
		hitPointBar.gameObject.SetActive(savedVisibility);
		visibility = savedVisibility;
	}

	public static void Show()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
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
		hitPointBar.gameObject.SetActive(value: true);
		visibility = true;
	}

	public static void Hide()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
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
		visibility = false;
	}

	public static void SetTarget(GameObject gobj)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__SetTarget(gobj);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetTarget(GameObject gobj)
	{
		if (!(gobj == null) && !(target == gobj))
		{
			updateInfo(gobj);
		}
	}

	public static void ReUpdate()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__ReUpdate();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __ReUpdate()
	{
		updateInfo(target);
	}

	private void updateInfo(GameObject gobj)
	{
		targetBaseControl = gobj.GetComponent<BaseControl>();
		if ((bool)targetBaseControl)
		{
			target = gobj;
			__Show();
			if (nameLabel != null)
			{
				nameLabel.setName(targetBaseControl.CharacterName);
			}
			AIControl aIControl = targetBaseControl as AIControl;
			if (!(aIControl != null) || !aIControl.HasMonsterData)
			{
				return;
			}
			MMonsters master = aIControl.MonsterData.Master;
			if (master != null && targetWeakStyle != null)
			{
				if (master.WeakStyle != 0)
				{
					targetWeakStyle.gameObject.SetActive(value: true);
					UIBasicUtility.SetStyleSprite(targetWeakStyle, (int)master.WeakStyle, light: true, show: true);
				}
				else
				{
					targetWeakStyle.gameObject.SetActive(value: false);
				}
			}
		}
		else
		{
			__Hide();
		}
	}

	public static void SetZokuseiDamageAdjust(string text)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__SetZokuseiDamageAdjust(text);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetZokuseiDamageAdjust(string text)
	{
		if (!(zokuseiDamageAdjust == null))
		{
			zokuseiDamageAdjust.text = text;
		}
	}

	public static void SetZokuseiDamageAdjustColor(Color color)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__SetZokuseiDamageAdjustColor(color);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetZokuseiDamageAdjustColor(Color color)
	{
		if (!(zokuseiDamageAdjust == null))
		{
			zokuseiDamageAdjust.color = color;
		}
	}

	public static void SetZokuseiIcon(string sprite)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
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
		if (!(zokuseiIcon == null))
		{
			zokuseiIcon.spriteName = sprite;
		}
	}

	public static void EnableZokuseiArrow(string sprite)
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__EnableZokuseiArrow(sprite);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableZokuseiArrow(string sprite)
	{
		if (!(zokuseiArrow == null))
		{
			zokuseiArrow.enabled = true;
			zokuseiArrow.spriteName = sprite;
		}
	}

	public static void DisableZokuseiArrow()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__DisableZokuseiArrow();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableZokuseiArrow()
	{
		if (!(zokuseiArrow == null))
		{
			zokuseiArrow.enabled = false;
		}
	}

	public static void EnableEliteIcon()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__EnableEliteIcon();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableEliteIcon()
	{
		if (!(rareIcon == null))
		{
			rareIcon.enabled = true;
		}
	}

	public static void DisableEliteIcon()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__DisableEliteIcon();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableEliteIcon()
	{
		if (!(rareIcon == null))
		{
			rareIcon.enabled = false;
		}
	}

	public static void AnimationLockOn()
	{
		IEnumerator<TargetHitPointBar> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBar current = enumerator.Current;
				current.__AnimationLockOn();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __AnimationLockOn()
	{
		StartCoroutine(animationLockOnMain());
	}

	private IEnumerator animationLockOnMain()
	{
		return new _0024animationLockOnMain_002421466(this).GetEnumerator();
	}
}
