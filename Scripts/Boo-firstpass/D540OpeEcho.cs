using System;
using UnityEngine;

[Serializable]
public class D540OpeEcho : D540OpeCode
{
	private string msg;

	public string Message
	{
		get
		{
			return msg;
		}
		set
		{
			msg = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeEcho(this);
	}

	public override D540OpeCode clone()
	{
		return New(msg);
	}

	public override void clear()
	{
		msg = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeEcho New(string m)
	{
		D540OpeEcho d540OpeEcho = (D540OpeEcho)D540OpeCodePool.NewObj(D540OpeCodeId.OpeEcho);
		d540OpeEcho.Message = m;
		return d540OpeEcho;
	}

	public override string ToString()
	{
		return GetType().ToString() + "('" + msg + "')";
	}
}
