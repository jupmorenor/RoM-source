using System;
using UnityEngine;

[Serializable]
public class D540OpeAssignExtField : D540OpeExtField
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
		v.caseOpeAssignExtField(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeAssignExtField d540OpeAssignExtField = New();
		if (Target != null)
		{
			d540OpeAssignExtField.Target = Target.clone();
		}
		if (Expression != null)
		{
			d540OpeAssignExtField.Expression = Expression.clone();
		}
		d540OpeAssignExtField.FieldName = FieldName;
		d540OpeAssignExtField.DeclaringTypeName = DeclaringTypeName;
		return d540OpeAssignExtField;
	}

	public override void clear()
	{
		base.clear();
		expression = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeAssignExtField New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeAssignExtField) as D540OpeAssignExtField;
	}

	public new static D540OpeAssignExtField New(string fieldName, string declaringTypeName)
	{
		D540OpeAssignExtField d540OpeAssignExtField = New();
		d540OpeAssignExtField.FieldName = fieldName;
		d540OpeAssignExtField.DeclaringTypeName = declaringTypeName;
		return d540OpeAssignExtField;
	}

	public override string ToString()
	{
		return GetType() + " fieldName=" + FieldName + " type=" + DeclaringTypeName;
	}
}
