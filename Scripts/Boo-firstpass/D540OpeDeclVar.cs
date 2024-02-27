using System;
using UnityEngine;

[Serializable]
public class D540OpeDeclVar : D540OpeCode
{
	private string varName;

	private D540OpeCode initializer;

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

	public D540OpeCode Initializer
	{
		get
		{
			return initializer;
		}
		set
		{
			initializer = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeDeclVar(this);
	}

	public override void clear()
	{
		varName = null;
		initializer = null;
	}

	public override D540OpeCode clone()
	{
		return (initializer == null) ? New(varName, null) : New(varName, initializer.clone());
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeDeclVar New(string varName, D540OpeCode initializer)
	{
		D540OpeDeclVar d540OpeDeclVar = (D540OpeDeclVar)D540OpeCodePool.NewObj(D540OpeCodeId.OpeDeclVar);
		d540OpeDeclVar.varName = varName;
		d540OpeDeclVar.initializer = initializer;
		return d540OpeDeclVar;
	}

	public override string ToString()
	{
		return GetType().ToString() + "('" + varName + "')";
	}
}
