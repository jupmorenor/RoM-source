using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class D540OpeArrayLiteral : D540OpeCode
{
	private List<D540OpeCode> expressions;

	public int ExpressionNum => expressions.Count;

	public List<D540OpeCode> Expressions => expressions;

	public D540OpeArrayLiteral()
	{
		expressions = new List<D540OpeCode>();
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeArrayLiteral(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeArrayLiteral d540OpeArrayLiteral = New();
		if (expressions != null)
		{
			foreach (D540OpeCode expression in expressions)
			{
				d540OpeArrayLiteral.expressions.Add(expression.clone());
			}
		}
		return d540OpeArrayLiteral;
	}

	public override void clear()
	{
		expressions.Clear();
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
		if (expressions == null)
		{
			expressions = new List<D540OpeCode>();
		}
	}

	public void addExpression(D540OpeCode ope)
	{
		OnEnable();
		expressions.Add(ope);
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeArrayLiteral New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeArrayLiteral) as D540OpeArrayLiteral;
	}

	public override string ToString()
	{
		return GetType() + " len=" + ((ICollection)expressions).Count;
	}
}
