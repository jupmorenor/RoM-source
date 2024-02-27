using System;
using UnityEngine;

[Serializable]
public class D540OpeExprStatement : D540OpeCode
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
		v.caseOpeExprStatement(this);
	}

	public override void clear()
	{
		expression = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeCode d540OpeCode = default(D540OpeCode);
		if (expression != null)
		{
			d540OpeCode = expression.clone();
		}
		return New(d540OpeCode);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeExprStatement New(D540OpeCode expression)
	{
		D540OpeExprStatement d540OpeExprStatement = (D540OpeExprStatement)D540OpeCodePool.NewObj(D540OpeCodeId.OpeExprStatement);
		d540OpeExprStatement.expression = expression;
		return d540OpeExprStatement;
	}
}
