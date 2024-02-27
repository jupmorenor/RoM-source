using System;
using System.Reflection;
using UnityEngine;

public class Ef_WindZoneInterface : MonoBehaviour
{
	private Component wz;

	private Type wType;

	private bool ready;

	private object[] m_WindZoneArgs = new object[1];

	public float radius
	{
		get
		{
			return (float)GetWindZoneValue("get_radius");
		}
		set
		{
			m_WindZoneArgs[0] = value;
			SetWindZoneValue("set_radius", m_WindZoneArgs);
		}
	}

	public float windMain
	{
		get
		{
			return (float)GetWindZoneValue("get_windMain");
		}
		set
		{
			m_WindZoneArgs[0] = value;
			SetWindZoneValue("set_windMain", m_WindZoneArgs);
		}
	}

	public float windTurbulence
	{
		get
		{
			return (float)GetWindZoneValue("get_windTurbulence");
		}
		set
		{
			m_WindZoneArgs[0] = value;
			SetWindZoneValue("set_windTurbulence", m_WindZoneArgs);
		}
	}

	public float windPulseMagnitude
	{
		get
		{
			return (float)GetWindZoneValue("get_windPulseMagnitude");
		}
		set
		{
			m_WindZoneArgs[0] = value;
			SetWindZoneValue("set_windPulseMagnitude", m_WindZoneArgs);
		}
	}

	public float windPulseFrequency
	{
		get
		{
			return (float)GetWindZoneValue("get_windPulseFrequency");
		}
		set
		{
			m_WindZoneArgs[0] = value;
			SetWindZoneValue("set_windPulseFrequency", m_WindZoneArgs);
		}
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		wz = GetComponent("WindZone");
		if (wz == null)
		{
			Debug.LogError("Could not find a wind zone to link to: " + this);
			base.enabled = false;
		}
		else
		{
			wType = wz.GetType();
			ready = true;
		}
	}

	private void SetWindZoneValue(string MemberName, object[] args)
	{
		wType.InvokeMember(MemberName, BindingFlags.Instance | BindingFlags.InvokeMethod, null, wz, args);
	}

	private object GetWindZoneValue(string MemberName)
	{
		return wType.InvokeMember(MemberName, BindingFlags.Instance | BindingFlags.InvokeMethod, null, wz, null);
	}

	private void WindZoneScale(float scale)
	{
		if (!ready)
		{
			Init();
		}
		radius *= scale;
		windMain *= scale;
	}
}
