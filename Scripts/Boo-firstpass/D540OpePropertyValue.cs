using System;
using System.Reflection;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540OpePropertyValue : D540OpeCode
{
	private string propertyName;

	private PropertyInfo property;

	private int receiverIndex;

	public string PropertyName
	{
		get
		{
			return propertyName;
		}
		set
		{
			propertyName = value;
		}
	}

	public PropertyInfo Property
	{
		get
		{
			return property;
		}
		set
		{
			property = value;
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

	public D540OpePropertyValue()
	{
		receiverIndex = -1;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpePropertyValue(this);
	}

	public override D540OpeCode clone()
	{
		return New(propertyName);
	}

	public override void clear()
	{
		propertyName = null;
		property = null;
		receiverIndex = -1;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpePropertyValue New(string propName)
	{
		if (string.IsNullOrEmpty(propName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(propName)");
		}
		D540OpePropertyValue d540OpePropertyValue = (D540OpePropertyValue)D540OpeCodePool.NewObj(D540OpeCodeId.OpePropertyValue);
		d540OpePropertyValue.PropertyName = propName;
		return d540OpePropertyValue;
	}

	public override string ToString()
	{
		return GetType() + ": name=" + propertyName;
	}
}
