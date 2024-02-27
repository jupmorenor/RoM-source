using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BattleHUDMappetIdentifier : MonoBehaviour
{
	public AttachMapetIdentify[] Markers;

	[NonSerialized]
	private static Boo.Lang.List<BattleHUDMappetIdentifier> _InstanceList = new Boo.Lang.List<BattleHUDMappetIdentifier>();

	public static BattleHUDMappetIdentifier Instance
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

	public BattleHUDMappetIdentifier()
	{
		Markers = new AttachMapetIdentify[0];
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

	public static void EnableIdentifier(int index, GameObject target)
	{
		IEnumerator<BattleHUDMappetIdentifier> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappetIdentifier current = enumerator.Current;
				current.__EnableIdentifier(index, target);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __EnableIdentifier(int index, GameObject target)
	{
		if (index < 0 || index >= Markers.Length)
		{
			return;
		}
		AttachMapetIdentify[] markers = Markers;
		if (!(markers[RuntimeServices.NormalizeArrayIndex(markers, index)] == null))
		{
			AttachMapetIdentify[] markers2 = Markers;
			AttachMapetIdentify attachMapetIdentify = markers2[RuntimeServices.NormalizeArrayIndex(markers2, index)];
			if (target == null)
			{
				attachMapetIdentify.hide();
			}
			else if (attachMapetIdentify.target != target)
			{
				attachMapetIdentify.target = target;
				AttachMapetIdentify[] markers3 = Markers;
				markers3[RuntimeServices.NormalizeArrayIndex(markers3, index)].show();
			}
		}
	}

	public static void DisableIdentifier(int index)
	{
		IEnumerator<BattleHUDMappetIdentifier> enumerator = _InstanceList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				BattleHUDMappetIdentifier current = enumerator.Current;
				current.__DisableIdentifier(index);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	protected void __DisableIdentifier(int index)
	{
		EnableIdentifier(index, null);
	}
}
