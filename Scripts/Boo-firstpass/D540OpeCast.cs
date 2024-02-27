using System;
using UnityEngine;

[Serializable]
public class D540OpeCast : D540OpeCode
{
	[Serializable]
	public enum EOpe
	{
		IntToSingle,
		IntToDouble,
		SingleToInt,
		DoubleToInt,
		SingleToDouble,
		DoubleToSingle
	}

	private EOpe @operator;

	private D540OpeCode expression;

	public EOpe Operator
	{
		get
		{
			return @operator;
		}
		set
		{
			@operator = value;
		}
	}

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
		v.caseOpeCast(this);
	}

	public override void clear()
	{
		@operator = EOpe.IntToSingle;
		expression = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeCode expr = default(D540OpeCode);
		if (expression != null)
		{
			expr = expression.clone();
		}
		return New(@operator, expr);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
		if (expression != null)
		{
			expression.OnGUI();
		}
	}

	public static D540OpeCast IntToSingle(D540OpeCode expr)
	{
		return New(EOpe.IntToSingle, expr);
	}

	public static D540OpeCast IntToDouble(D540OpeCode expr)
	{
		return New(EOpe.IntToDouble, expr);
	}

	public static D540OpeCast SingleToInt(D540OpeCode expr)
	{
		return New(EOpe.SingleToInt, expr);
	}

	public static D540OpeCast DoubleToInt(D540OpeCode expr)
	{
		return New(EOpe.DoubleToInt, expr);
	}

	public static D540OpeCast SingleToDouble(D540OpeCode expr)
	{
		return New(EOpe.SingleToDouble, expr);
	}

	public static D540OpeCast DoubleToSingle(D540OpeCode expr)
	{
		return New(EOpe.DoubleToSingle, expr);
	}

	public static D540OpeCast New(EOpe ope, D540OpeCode expr)
	{
		D540OpeCast d540OpeCast = (D540OpeCast)D540OpeCodePool.NewObj(D540OpeCodeId.OpeCast);
		d540OpeCast.Operator = ope;
		d540OpeCast.Expression = expr;
		return d540OpeCast;
	}

	public override string ToString()
	{
		return GetType().ToString() + " " + @operator;
	}
}
