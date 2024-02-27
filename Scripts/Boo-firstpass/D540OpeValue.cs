using System;
using UnityEngine;

[Serializable]
public class D540OpeValue : D540OpeCode
{
	public override object Value => null;

	public override bool IsValueNode => true;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValue(this);
	}

	public override D540OpeCode clone()
	{
		return NewNull();
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeValue NewNull()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValue) as D540OpeValue;
	}

	public static D540OpeValueInt NewInt(int value)
	{
		D540OpeValueInt d540OpeValueInt = D540OpeValueInt.New();
		d540OpeValueInt.valueInt = value;
		return d540OpeValueInt;
	}

	public static D540OpeValueSingle NewSingle(float value)
	{
		D540OpeValueSingle d540OpeValueSingle = D540OpeValueSingle.New();
		d540OpeValueSingle.valueSingle = value;
		return d540OpeValueSingle;
	}

	public static D540OpeValueString NewString(string value)
	{
		D540OpeValueString d540OpeValueString = D540OpeValueString.New();
		d540OpeValueString.valueString = value;
		return d540OpeValueString;
	}

	public static D540OpeValueVector3 New(Vector3 value)
	{
		D540OpeValueVector3 d540OpeValueVector = D540OpeValueVector3.New();
		d540OpeValueVector.valueVector3 = value;
		return d540OpeValueVector;
	}

	public static D540OpeValueVector2 New(Vector2 value)
	{
		D540OpeValueVector2 d540OpeValueVector = D540OpeValueVector2.New();
		d540OpeValueVector.valueVector2 = value;
		return d540OpeValueVector;
	}

	public static D540OpeValueBool New(bool value)
	{
		D540OpeValueBool d540OpeValueBool = D540OpeValueBool.New();
		d540OpeValueBool.valueBool = value;
		return d540OpeValueBool;
	}
}
