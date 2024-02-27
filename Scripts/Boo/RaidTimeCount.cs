using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class RaidTimeCount : MonoBehaviour
{
	private float raidLeftTime;

	public UIDynamicFontLabel timeLabel;

	[NonSerialized]
	private static Boo.Lang.List<RaidTimeCount> _InstanceList = new Boo.Lang.List<RaidTimeCount>();

	public static RaidTimeCount Instance
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

	public RaidTimeCount()
	{
		raidLeftTime = 60f;
	}

	public void Update()
	{
		raidLeftTime -= Time.deltaTime;
		if (timeLabel != null)
		{
			timeLabel.m_Text = "Time:" + Mathf.CeilToInt(raidLeftTime).ToString();
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

	public static void show()
	{
		IEnumerator<RaidTimeCount> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RaidTimeCount current = enumerator.Current;
				current.__show();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __show()
	{
		gameObject.SetActive(value: true);
		if (timeLabel != null)
		{
			timeLabel.gameObject.SetActive(value: true);
		}
	}

	public static void hide()
	{
		IEnumerator<RaidTimeCount> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RaidTimeCount current = enumerator.Current;
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
		gameObject.SetActive(value: false);
		if (timeLabel != null)
		{
			timeLabel.gameObject.SetActive(value: false);
		}
	}
}
