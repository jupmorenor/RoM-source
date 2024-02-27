using System;
using UnityEngine;

[Serializable]
public class D540OpeUnary : D540OpeCode
{
	[Serializable]
	public enum EOpe
	{
		MINUS,
		NOT
	}

	private EOpe @operator;

	private D540OpeCode expression;

	public EOpe D540Operator
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
		v.caseOpeUnary(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeCode expre = default(D540OpeCode);
		if (expression != null)
		{
			expre = expression.clone();
		}
		return New(@operator, expre);
	}

	public override void clear()
	{
		@operator = EOpe.MINUS;
		expression = null;
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

	public static D540OpeUnary Minus(D540OpeCode expre)
	{
		return New(EOpe.MINUS, expre);
	}

	public static D540OpeUnary Not(D540OpeCode expre)
	{
		return New(EOpe.NOT, expre);
	}

	public static D540OpeUnary New(EOpe ope, D540OpeCode expre)
	{
		D540OpeUnary d540OpeUnary = (D540OpeUnary)D540OpeCodePool.NewObj(D540OpeCodeId.OpeUnary);
		d540OpeUnary.D540Operator = ope;
		d540OpeUnary.Expression = expre;
		return d540OpeUnary;
	}

	public override string ToString()
	{
		return GetType() + ": " + @operator;
	}
}
