using System;
using UnityEngine;

[Serializable]
public class D540OpeBuiltinFunc : D540OpeCode
{
	private string typeName;

	private Type type;

	public string TypeName
	{
		get
		{
			return typeName;
		}
		set
		{
			typeName = value;
		}
	}

	public Type Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeBuiltinFunc(this);
	}

	public override void clear()
	{
		typeName = null;
		type = null;
	}

	public override D540OpeCode clone()
	{
		return New(typeName);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeBuiltinFunc New(string n)
	{
		D540OpeBuiltinFunc d540OpeBuiltinFunc = (D540OpeBuiltinFunc)D540OpeCodePool.NewObj(D540OpeCodeId.OpeBuiltinFunc);
		d540OpeBuiltinFunc.typeName = n;
		return d540OpeBuiltinFunc;
	}

	public override string ToString()
	{
		return GetType().ToString() + " type=" + typeName;
	}
}
