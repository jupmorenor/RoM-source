using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using ObjUtil;
using UnityEngine;

[Serializable]
public class TargetHitPointBarMini : MonoBehaviour
{
	[Serializable]
	private class TargetInfo
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024drawRoutine_002421470 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal Vector3 _0024pos_002421471;

				internal TargetInfo _0024self__002421472;

				public _0024(TargetInfo self_)
				{
					_0024self__002421472 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024self__002421472.hitPointSlider.gameObject.SetActive(value: true);
						goto case 2;
					case 2:
						if (_0024self__002421472.IsNotDeleted && !((double)_0024self__002421472.currentDrawTime <= 0.0) && (bool)_0024self__002421472.target && _0024self__002421472.baseControl.HitPoint > 0f)
						{
							_0024self__002421472.currentDrawTime -= Time.deltaTime;
							_0024self__002421472.hitPointSlider.sliderValue = _0024self__002421472.baseControl.HitPoint / _0024self__002421472.baseControl.MaxHitPoint;
							if ((bool)Camera.main)
							{
								_0024pos_002421471 = ObjUtilModule.GetScreenPostion(_0024self__002421472.hitPointSlider.transform, _0024self__002421472.target.gameObject, Camera.main);
								_0024self__002421472.hitPointSlider.transform.localPosition = _0024pos_002421471 + offsetPos;
							}
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if ((bool)_0024self__002421472.hitPointSlider)
						{
							_0024self__002421472.hitPointSlider.gameObject.SetActive(value: false);
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

			internal TargetInfo _0024self__002421473;

			public _0024drawRoutine_002421470(TargetInfo self_)
			{
				_0024self__002421473 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421473);
			}
		}

		private Transform target;

		private BaseControl baseControl;

		private float drawTime;

		private float currentDrawTime;

		private UISlider hitPointSlider;

		public bool IsNotDeleted
		{
			get
			{
				bool num = baseControl != null;
				if (num)
				{
					num = hitPointSlider != null;
				}
				return num;
			}
		}

		public bool IsNotActive
		{
			get
			{
				bool num = hitPointSlider != null;
				if (num)
				{
					num = !hitPointSlider.gameObject.activeSelf;
				}
				return num;
			}
		}

		public TargetInfo(UISlider sliderBar)
		{
			target = null;
			baseControl = null;
			hitPointSlider = sliderBar;
			currentDrawTime = 0f;
		}

		public bool isPopped(Transform _target)
		{
			bool num = target == _target;
			if (num)
			{
				num = hitPointSlider.gameObject.activeSelf;
			}
			return num;
		}

		public void start(Transform _target, MonoBehaviour behaviour, float _drawTime)
		{
			target = _target;
			baseControl = _target.GetComponent<BaseControl>();
			currentDrawTime = _drawTime;
			drawTime = _drawTime;
			behaviour.StartCoroutine(drawRoutine());
		}

		public void restart()
		{
			currentDrawTime = drawTime;
		}

		private IEnumerator drawRoutine()
		{
			return new _0024drawRoutine_002421470(this).GetEnumerator();
		}
	}

	private readonly float DEFAULT_DRAWTIME_HIT_POINT_BAR_MINI;

	private float drawTime;

	public UISlider[] hitPointSlider;

	public UISlider[] poppetHitPointSlider;

	[NonSerialized]
	private static Vector3 offsetPos = new Vector3(-40f, 100f, 0f);

	private Boo.Lang.List<TargetInfo> targetInfos;

	private Boo.Lang.List<TargetInfo> poppetTargetInfos;

	[NonSerialized]
	private static Boo.Lang.List<TargetHitPointBarMini> _InstanceList = new Boo.Lang.List<TargetHitPointBarMini>();

	public static TargetHitPointBarMini Instance
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

	public TargetHitPointBarMini()
	{
		DEFAULT_DRAWTIME_HIT_POINT_BAR_MINI = 3f;
		drawTime = DEFAULT_DRAWTIME_HIT_POINT_BAR_MINI;
		targetInfos = new Boo.Lang.List<TargetInfo>();
		poppetTargetInfos = new Boo.Lang.List<TargetInfo>();
	}

	public void Start()
	{
		int i = 0;
		UISlider[] array = hitPointSlider;
		checked
		{
			for (int length = array.Length; i < length; i++)
			{
				if (array[i] != null)
				{
					targetInfos.Add(new TargetInfo(array[i]));
				}
			}
			int j = 0;
			UISlider[] array2 = poppetHitPointSlider;
			for (int length2 = array2.Length; j < length2; j++)
			{
				if (array2[j] != null)
				{
					poppetTargetInfos.Add(new TargetInfo(array2[j]));
				}
			}
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

	public static void setTarget(Transform _target)
	{
		IEnumerator<TargetHitPointBarMini> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBarMini current = enumerator.Current;
				current.__setTarget(_target);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setTarget(Transform _target)
	{
		setTargetSub(_target, targetInfos);
	}

	public static void setTargetForPoppet(Transform _target)
	{
		IEnumerator<TargetHitPointBarMini> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBarMini current = enumerator.Current;
				current.__setTargetForPoppet(_target);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setTargetForPoppet(Transform _target)
	{
		setTargetSub(_target, poppetTargetInfos);
	}

	public static void setDrawTime(float _drawTime)
	{
		IEnumerator<TargetHitPointBarMini> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetHitPointBarMini current = enumerator.Current;
				current.__setDrawTime(_drawTime);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __setDrawTime(float _drawTime)
	{
		drawTime = _drawTime;
	}

	private void setTargetSub(Transform _target, Boo.Lang.List<TargetInfo> useList)
	{
		if (_target == null || useList == null)
		{
			return;
		}
		IEnumerator<TargetInfo> enumerator = useList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TargetInfo current = enumerator.Current;
				if (current.isPopped(_target))
				{
					current.restart();
					return;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		IEnumerator<TargetInfo> enumerator2 = useList.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				TargetInfo current2 = enumerator2.Current;
				if (current2.IsNotActive)
				{
					current2.start(_target, this, drawTime);
					break;
				}
			}
		}
		finally
		{
			enumerator2.Dispose();
		}
	}
}
