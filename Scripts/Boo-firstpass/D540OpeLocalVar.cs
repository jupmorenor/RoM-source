using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540OpeLocalVar : D540OpeCode
{
	private string varName;

	public string VarName
	{
		get
		{
			return varName;
		}
		set
		{
			varName = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeLocalVar(this);
	}

	public override void clear()
	{
		varName = null;
	}

	public override D540OpeCode clone()
	{
		return New(varName);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeLocalVar New(string varName)
	{
		if (string.IsNullOrEmpty(varName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(varName)");
		}
		D540OpeLocalVar d540OpeLocalVar = (D540OpeLocalVar)D540OpeCodePool.NewObj(D540OpeCodeId.OpeLocalVar);
		d540OpeLocalVar.varName = varName;
		return d540OpeLocalVar;
	}

	public override string ToString()
	{
		return GetType() + ": name=" + varName;
	}
}
