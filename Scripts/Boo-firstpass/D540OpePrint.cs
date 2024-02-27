using System;
using UnityEngine;

[Serializable]
public class D540OpePrint : D540OpeCode
{
	private D540OpeCode expression;

	public D540OpeCode Expression
	{
		get
		{
			return expression;
		}
		set
		{
			expression = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpePrint(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeCode expr = default(D540OpeCode);
		if (expression != null)
		{
			expr = expression.clone();
		}
		return New(expr);
	}

	public override void clear()
	{
		expression = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpePrint New(D540OpeCode expr)
	{
		D540OpePrint d540OpePrint = (D540OpePrint)D540OpeCodePool.NewObj(D540OpeCodeId.OpePrint);
		d540OpePrint.Expression = expr;
		return d540OpePrint;
	}
}
