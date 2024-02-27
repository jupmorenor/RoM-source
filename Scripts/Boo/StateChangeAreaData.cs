using System;
using System.Text;
using UnityEngine;

[Serializable]
public class StateChangeAreaData
{
	[Serializable]
	public enum EnumAreaType
	{
		NoEffect,
		Damage,
		Snare,
		Gravity,
		DamageHpMaxRel
	}

	private EnumAreaType type;

	private float value;

	private float value2;

	private MerlinActionControl origin;

	private Vector3 position;

	private bool _0024initialized__StateChangeAreaData_0024;

	public bool IsDamage => type == EnumAreaType.Damage;

	public bool IsDamageHpMaxRel => type == EnumAreaType.DamageHpMaxRel;

	public bool IsSnare => type == EnumAreaType.Snare;

	public bool IsGravity => type == EnumAreaType.Gravity;

	public float DamageYarareInterval => value2;

	public float SpeedScale => (!IsSnare) ? 1f : value;

	public EnumAreaType Type => type;

	public float Value => value;

	public float Value2 => value2;

	public MerlinActionControl Origin
	{
		get
		{
			return origin;
		}
		set
		{
			origin = value;
		}
	}

	public Vector3 Position
	{
		get
		{
			return position;
		}
		set
		{
			position = value;
		}
	}

	private StateChangeAreaData(EnumAreaType type, float value)
	{
		if (!_0024initialized__StateChangeAreaData_0024)
		{
			this.type = EnumAreaType.NoEffect;
			position = Vector3.zero;
			_0024initialized__StateChangeAreaData_0024 = true;
		}
		this.type = type;
		this.value = value;
	}

	private StateChangeAreaData(EnumAreaType type, float value, float value2)
	{
		if (!_0024initialized__StateChangeAreaData_0024)
		{
			this.type = EnumAreaType.NoEffect;
			position = Vector3.zero;
			_0024initialized__StateChangeAreaData_0024 = true;
		}
		this.type = type;
		this.value = value;
		this.value2 = value;
	}

	public static StateChangeAreaData Damage(float damagePerSec)
	{
		return new StateChangeAreaData(EnumAreaType.Damage, damagePerSec, 10f);
	}

	public static StateChangeAreaData DamageHpMaxRel(float damageRatePerSec)
	{
		return new StateChangeAreaData(EnumAreaType.DamageHpMaxRel, damageRatePerSec, 10f);
	}

	public static StateChangeAreaData Snare(float speedScale)
	{
		return new StateChangeAreaData(EnumAreaType.Snare, speedScale);
	}

	public static StateChangeAreaData Gravity(float gravityVel)
	{
		return new StateChangeAreaData(EnumAreaType.Gravity, gravityVel);
	}

	public float damagePerSec(float hitPointMax)
	{
		return IsDamage ? value : ((!IsDamageHpMaxRel) ? 0f : (hitPointMax * value));
	}

	public Vector3 gravityVel(Vector3 pos)
	{
		Vector3 result;
		if (IsGravity)
		{
			Vector3 vector = position;
			vector.y = 0f;
			pos.y = 0f;
			result = (vector - pos).normalized * value;
		}
		else
		{
			result = Vector3.zero;
		}
		return result;
	}

	public override string ToString()
	{
		return new StringBuilder("StateChangeArea(").Append(type).Append(" v=").Append(value)
			.Append(" v2=")
			.Append(value2)
			.Append(") org=")
			.Append(origin.CharacterName)
			.Append(")")
			.ToString();
	}
}
