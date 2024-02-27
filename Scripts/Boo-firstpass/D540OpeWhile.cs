using System;
using UnityEngine;

[Serializable]
public class D540OpeWhile : D540OpeCode
{
	private D540OpeCode condition;

	private D540OpeCode body;

	public D540OpeCode Condition
	{
		get
		{
			return condition;
		}
		set
		{
			condition = value;
		}
	}

	public D540OpeCode Body
	{
		get
		{
			return body;
		}
		set
		{
			body = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeWhile(this);
	}

	public override void clear()
	{
		condition = null;
		body = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeCode d540OpeCode = default(D540OpeCode);
		if (condition != null)
		{
			d540OpeCode = condition.clone();
		}
		D540OpeCode d540OpeCode2 = default(D540OpeCode);
		if (condition != null)
		{
			d540OpeCode2 = body.clone();
		}
		return New(d540OpeCode, d540OpeCode2);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeWhile New(D540OpeCode condition, D540OpeCode body)
	{
		D540OpeWhile d540OpeWhile = (D540OpeWhile)D540OpeCodePool.NewObj(D540OpeCodeId.OpeWhile);
		d540OpeWhile.condition = condition;
		d540OpeWhile.body = body;
		return d540OpeWhile;
	}

	public override string ToString()
	{
		return GetType().ToString();
	}
}
