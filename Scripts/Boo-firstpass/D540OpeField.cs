using System;
using System.Reflection;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540OpeField : D540OpeCode
{
	private string fieldName;

	private FieldInfo field;

	private int receiverIndex;

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

	public int ReceiverIndex
	{
		get
		{
			return receiverIndex;
		}
		set
		{
			receiverIndex = value;
		}
	}

	public D540OpeField()
	{
		receiverIndex = -1;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeField(this);
	}

	public override void clear()
	{
		fieldName = null;
		field = null;
		receiverIndex = -1;
	}

	public override D540OpeCode clone()
	{
		return New(fieldName);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeField New(string fname)
	{
		if (string.IsNullOrEmpty(fname))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(fname)");
		}
		D540OpeField d540OpeField = (D540OpeField)D540OpeCodePool.NewObj(D540OpeCodeId.OpeField);
		d540OpeField.FieldName = fname;
		return d540OpeField;
	}

	public override string ToString()
	{
		return GetType() + ": name=" + fieldName;
	}
}
