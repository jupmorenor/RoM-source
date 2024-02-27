using System;
using UnityEngine;

[Serializable]
public class D540OpeBinary : D540OpeCode
{
	[Serializable]
	public enum EOpe
	{
		ADD,
		SUB,
		MULT,
		DIV,
		MOD,
		EQ,
		NE,
		GT,
		GE,
		LT,
		LE,
		AND,
		OR,
		ASSIGN
	}

	private EOpe @operator;

	private D540OpeCode leftExpr;

	private D540OpeCode rightExpr;

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

	public D540OpeCode Left
	{
		get
		{
			return leftExpr;
		}
		set
		{
			leftExpr = value;
		}
	}

	public D540OpeCode Right
	{
		get
		{
			return rightExpr;
		}
		set
		{
			rightExpr = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeBinary(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeBinary d540OpeBinary = (D540OpeBinary)D540OpeCodePool.NewObj(D540OpeCodeId.OpeBinary);
		d540OpeBinary.@operator = @operator;
		if (leftExpr != null)
		{
			d540OpeBinary.leftExpr = leftExpr.clone();
		}
		if (rightExpr != null)
		{
			d540OpeBinary.rightExpr = rightExpr.clone();
		}
		return d540OpeBinary;
	}

	public override void clear()
	{
		@operator = EOpe.ADD;
		leftExpr = null;
		rightExpr = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
		if (leftExpr != null)
		{
			leftExpr.OnGUI();
		}
		if (rightExpr != null)
		{
			rightExpr.OnGUI();
		}
	}

	public static D540OpeBinary Add(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.ADD, left, right);
	}

	public static D540OpeBinary Sub(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.SUB, left, right);
	}

	public static D540OpeBinary Mult(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.MULT, left, right);
	}

	public static D540OpeBinary Div(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.DIV, left, right);
	}

	public static D540OpeBinary Mod(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.MOD, left, right);
	}

	public static D540OpeBinary Eq(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.EQ, left, right);
	}

	public static D540OpeBinary Ne(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.NE, left, right);
	}

	public static D540OpeBinary Gt(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.GT, left, right);
	}

	public static D540OpeBinary Ge(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.GE, left, right);
	}

	public static D540OpeBinary Lt(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.LT, left, right);
	}

	public static D540OpeBinary Le(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.LE, left, right);
	}

	public static D540OpeBinary And(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.AND, left, right);
	}

	public static D540OpeBinary Or(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.OR, left, right);
	}

	public static D540OpeBinary Assign(D540OpeCode left, D540OpeCode right)
	{
		return New(EOpe.ASSIGN, left, right);
	}

	public static D540OpeBinary New(EOpe ope, D540OpeCode left, D540OpeCode right)
	{
		D540OpeBinary d540OpeBinary = (D540OpeBinary)D540OpeCodePool.NewObj(D540OpeCodeId.OpeBinary);
		d540OpeBinary.D540Operator = ope;
		d540OpeBinary.Left = left;
		d540OpeBinary.Right = right;
		return d540OpeBinary;
	}

	public override string ToString()
	{
		return GetType() + ": " + D540Operator;
	}
}
