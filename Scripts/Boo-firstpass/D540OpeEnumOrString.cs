using System;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpeEnumOrString : D540OpeCode
{
	private string stringValue;

	private bool isEnum;

	private string enumTypeName;

	private string enumOrStringValueTypeName;

	private object value;

	public override bool IsValueNode => true;

	public override object Value => value;

	public string StringValue
	{
		get
		{
			return stringValue;
		}
		set
		{
			stringValue = value;
		}
	}

	public bool IsEnum
	{
		get
		{
			return isEnum;
		}
		set
		{
			isEnum = value;
		}
	}

	public string EnumTypeName
	{
		get
		{
			return enumTypeName;
		}
		set
		{
			enumTypeName = value;
		}
	}

	public string EnumOrStringValueTypeName
	{
		get
		{
			return enumOrStringValueTypeName;
		}
		set
		{
			enumOrStringValueTypeName = value;
		}
	}

	public void setValue(object val)
	{
		value = val;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeEnumOrString(this);
	}

	public override void clear()
	{
		stringValue = null;
		isEnum = false;
		enumTypeName = null;
		enumOrStringValueTypeName = null;
		value = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeEnumOrString d540OpeEnumOrString = New();
		d540OpeEnumOrString.stringValue = stringValue;
		d540OpeEnumOrString.isEnum = isEnum;
		d540OpeEnumOrString.enumTypeName = enumTypeName;
		d540OpeEnumOrString.enumOrStringValueTypeName = enumOrStringValueTypeName;
		return d540OpeEnumOrString;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeEnumOrString New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeEnumOrString) as D540OpeEnumOrString;
	}

	public static D540OpeEnumOrString NewByString(string stringValue, string _enumOrStringTypeName)
	{
		D540OpeEnumOrString d540OpeEnumOrString = New();
		d540OpeEnumOrString.stringValue = stringValue;
		d540OpeEnumOrString.enumOrStringValueTypeName = _enumOrStringTypeName;
		d540OpeEnumOrString.isEnum = false;
		return d540OpeEnumOrString;
	}

	public static D540OpeEnumOrString NewByEnumType(string stringValue, string _enumName, string _enumOrStringTypeName)
	{
		D540OpeEnumOrString d540OpeEnumOrString = New();
		d540OpeEnumOrString.stringValue = stringValue;
		d540OpeEnumOrString.enumTypeName = _enumName;
		d540OpeEnumOrString.enumOrStringValueTypeName = _enumOrStringTypeName;
		d540OpeEnumOrString.isEnum = true;
		return d540OpeEnumOrString;
	}

	public override string ToString()
	{
		return GetType().ToString() + new StringBuilder(" strval=").Append(stringValue).Append(" isenum=").Append(isEnum)
			.Append(" etype=")
			.Append(enumTypeName)
			.Append(" eorsname=")
			.Append(enumOrStringValueTypeName)
			.ToString();
	}
}
