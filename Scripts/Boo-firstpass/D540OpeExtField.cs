using System;
using System.Reflection;
using UnityEngine;

[Serializable]
public class D540OpeExtField : D540OpeCode
{
	private D540OpeCode target;

	private string fieldName;

	private string declaringTypeName;

	private FieldInfo field;

	public D540OpeCode Target
	{
		get
		{
			return target;
		}
		set
		{
			target = value;
		}
	}

	public string FieldName
	{
		get
		{
			return fieldName;
		}
		set
		{
			fieldName = value;
		}
	}

	public string DeclaringTypeName
	{
		get
		{
			return declaringTypeName;
		}
		set
		{
			declaringTypeName = value;
		}
	}

	public FieldInfo Field
	{
		get
		{
			return field;
		}
		set
		{
			field = value;
		}
	}

	public override void clear()
	{
		target = null;
		fieldName = null;
		declaringTypeName = null;
		field = null;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeExtField(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeExtField d540OpeExtField = New();
		if (target != null)
		{
			d540OpeExtField.target = target.clone();
		}
		d540OpeExtField.fieldName = fieldName;
		d540OpeExtField.declaringTypeName = declaringTypeName;
		return d540OpeExtField;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeExtField New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeExtField) as D540OpeExtField;
	}

	public static D540OpeExtField New(string fieldName, string declaringTypeName)
	{
		D540OpeExtField d540OpeExtField = New();
		d540OpeExtField.fieldName = fieldName;
		d540OpeExtField.declaringTypeName = declaringTypeName;
		return d540OpeExtField;
	}

	public override string ToString()
	{
		return GetType() + " fieldName=" + fieldName + " type=" + declaringTypeName;
	}
}
