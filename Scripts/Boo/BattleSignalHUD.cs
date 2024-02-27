using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BattleSignalHUD : MonoBehaviour
{
	[Serializable]
	public class Signal
	{
		private GameObject baseObj;

		private UITweener[] tweeners;

		private float showTime;

		public Signal(GameObject go)
		{
			baseObj = go;
			if (go != null)
			{
				tweeners = go.GetComponents<UITweener>();
			}
			else
			{
				tweeners = new UITweener[0];
			}
		}

		public void play()
		{
			if (baseObj == null)
			{
				return;
			}
			baseObj.SetActive(value: true);
			showTime = 0.5f;
			if (tweeners == null)
			{
				return;
			}
			int i = 0;
			UITweener[] array = tweeners;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if (array[i] != null)
				{
					array[i].Play(forward: true);
					array[i].Reset();
				}
			}
		}

		public void update(float dt)
		{
			if (!(showTime <= 0f) && !(baseObj == null))
			{
				showTime -= dt;
				if (!(showTime > 0f))
				{
					baseObj.SetActive(value: false);
				}
			}
		}
	}

	public GameObject 攻撃力アップ;

	public GameObject 体力アップ;

	public GameObject 速さアップ;

	public GameObject 状態異常レジスト;

	private Signal resistSignal;

	[NonSerialized]
	private static Boo.Lang.List<BattleSignalHUD> _InstanceList = new Boo.Lang.List<BattleSignalHUD>();

	public static BattleSignalHUD Instance
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

	public static GameObject AttackUp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__AttackUp;
		}
	}

	public static GameObject HpUp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__HpUp;
		}
	}

	public static GameObject SpeedUp
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__SpeedUp;
		}
	}

	public static GameObject Resist
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__Resist;
		}
	}

	public GameObject __AttackUp => 攻撃力アップ;

	public GameObject __HpUp => 体力アップ;

	public GameObject __SpeedUp => 速さアップ;

	public GameObject __Resist => 状態異常レジスト;

	public void Start()
	{
		resistSignal = new Signal(Resist);
	}

	public void Update()
	{
		float deltaTime = Time.deltaTime;
		resistSignal.update(deltaTime);
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

	public static void resistAbnormalState(EnumAbnormalStates state)
	{
		IEnumerator<BattleSignalHUD> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleSignalHUD current = enumerator.Current;
				current.__resistAbnormalState(state);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __resistAbnormalState(EnumAbnormalStates state)
	{
		resistSignal.play();
	}
}
