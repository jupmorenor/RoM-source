using System;
using System.Collections.Generic;
using Boo.Lang;

[Serializable]
public class BattleHUDTargetAbnormalState : BattleHUDAbnormalStateBase
{
	private MerlinActionControl targetChar;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDTargetAbnormalState> _InstanceList = new Boo.Lang.List<BattleHUDTargetAbnormalState>();

	public static BattleHUDTargetAbnormalState Instance
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

	public void Update()
	{
		updateStates();
	}

	private void updateStates()
	{
		if (targetChar != null)
		{
			setStateIcons(targetChar.AbnormalStateControl.CurrentStates);
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

	public static void SetTargetChar(MerlinActionControl ch)
	{
		IEnumerator<BattleHUDTargetAbnormalState> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDTargetAbnormalState current = enumerator.Current;
				current.__SetTargetChar(ch);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __SetTargetChar(MerlinActionControl ch)
	{
		targetChar = ch;
		if (ch != null)
		{
			updateStates();
		}
		else
		{
			resetAllIcons();
		}
	}

	public static void Clear()
	{
		IEnumerator<BattleHUDTargetAbnormalState> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDTargetAbnormalState current = enumerator.Current;
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
