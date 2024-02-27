using System;
using System.Collections.Generic;
using Boo.Lang;

[Serializable]
public class BattleHUDAbnormalState : BattleHUDAbnormalStateBase
{
	[NonSerialized]
	private static Boo.Lang.List<BattleHUDAbnormalState> _InstanceList = new Boo.Lang.List<BattleHUDAbnormalState>();

	public static BattleHUDAbnormalState Instance
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

	public static void SetStates(EnumAbnormalStates[] states)
	{
		IEnumerator<BattleHUDAbnormalState> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDAbnormalState current = enumerator.Current;
				current.__SetStates(states);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetStates(EnumAbnormalStates[] states)
	{
		setStateIcons(states);
	}

	public static void Clear()
	{
		IEnumerator<BattleHUDAbnormalState> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDAbnormalState current = enumerator.Current;
				current.__Clear();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __Clear()
	{
		resetAllIcons();
	}
}
