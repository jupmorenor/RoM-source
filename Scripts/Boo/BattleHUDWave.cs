using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BattleHUDWave : MonoBehaviour
{
	public GameObject ウェーブ根元;

	public UILabelBase ウェーブ数;

	private UITweener[] tweeners;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDWave> _InstanceList = new Boo.Lang.List<BattleHUDWave>();

	public static BattleHUDWave Instance
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

	public static GameObject Root
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__Root;
		}
	}

	public static UILabelBase WaveNumLabel
	{
		get
		{
			int count = _InstanceList.Count;
			if (count != 1)
			{
			}
			return _InstanceList[0].__WaveNumLabel;
		}
	}

	public GameObject __Root => ウェーブ根元;

	public UILabelBase __WaveNumLabel => ウェーブ数;

	public void Start()
	{
		if (!(Root == null))
		{
			tweeners = Root.GetComponents<UITweener>();
			Root.SetActive(value: false);
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

	public static void dispWave(int waveNum)
	{
		IEnumerator<BattleHUDWave> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDWave current = enumerator.Current;
				current.__dispWave(waveNum);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __dispWave(int waveNum)
	{
		if (!(Root == null))
		{
			Root.SetActive(value: true);
			resetTweeners();
			if (WaveNumLabel != null)
			{
				WaveNumLabel.text = new StringBuilder().Append((object)waveNum).ToString();
			}
		}
	}

	public static void hide()
	{
		IEnumerator<BattleHUDWave> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDWave current = enumerator.Current;
				current.__hide();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __hide()
	{
		Root.SetActive(value: false);
	}

	private void resetTweeners()
	{
		int i = 0;
		UITweener[] array = tweeners;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].Play(forward: true);
			array[i].Reset();
		}
		if ((bool)Root)
		{
			int num = -2000;
			Vector3 localPosition = Root.transform.localPosition;
			float num2 = (localPosition.x = num);
			Vector3 vector2 = (Root.transform.localPosition = localPosition);
		}
	}
}
