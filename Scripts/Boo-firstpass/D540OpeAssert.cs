using System;
using UnityEngine;

[Serializable]
public class D540OpeAssert : D540OpeCode
{
	private D540OpeCode expected;

	public D540OpeCode Expected
	{
		get
		{
			return expected;
		}
		set
		{
			expected = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeAssert(this);
	}

	public override void clear()
	{
		expected = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeAssert d540OpeAssert = New();
		if (expected != null)
		{
			d540OpeAssert.Expected = expected.clone();
		}
		return d540OpeAssert;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeAssert New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeAssert) as D540OpeAssert;
	}

	public static D540OpeAssert New(int value)
	{
		D540OpeValueInt d540OpeValueInt = D540OpeValue.NewInt(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueInt;
		return d540OpeAssert;
	}

	public static D540OpeAssert New(float value)
	{
		D540OpeValueSingle d540OpeValueSingle = D540OpeValue.NewSingle(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueSingle;
		return d540OpeAssert;
	}

	public static D540OpeAssert New(string value)
	{
		D540OpeValueString d540OpeValueString = D540OpeValue.NewString(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueString;
		return d540OpeAssert;
	}

	public static D540OpeAssert New(Vector3 value)
	{
		D540OpeValueVector3 d540OpeValueVector = D540OpeValue.New(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueVector;
		return d540OpeAssert;
	}

	public static D540OpeAssert New(Vector2 value)
	{
		D540OpeValueVector2 d540OpeValueVector = D540OpeValue.New(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueVector;
		return d540OpeAssert;
	}

	public static D540OpeAssert New(bool value)
	{
		D540OpeValueBool d540OpeValueBool = D540OpeValue.New(value);
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueBool;
		return d540OpeAssert;
	}

	public static D540OpeAssert NewObject(object value)
	{
		D540OpeValueObject d540OpeValueObject = D540OpeValueObject.New();
		d540OpeValueObject.valueObject = value;
		D540OpeAssert d540OpeAssert = New();
		d540OpeAssert.Expected = d540OpeValueObject;
		return d540OpeAssert;
	}
}
