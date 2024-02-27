using System;
using UnityEngine;

[Serializable]
public class D540OpeIfElse : D540OpeCode
{
	private D540OpeCode condition;

	private D540OpeCode thenCode;

	private D540OpeCode elseCode;

	public D540OpeCode Condition
	{
		get
		{
			return condition;
		}
		set
		{
			condition = value;
		}
	}

	public D540OpeCode Then
	{
		get
		{
			return thenCode;
		}
		set
		{
			thenCode = value;
		}
	}

	public D540OpeCode Else
	{
		get
		{
			return elseCode;
		}
		set
		{
			elseCode = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeIfElse(this);
	}

	public override void clear()
	{
		condition = null;
		thenCode = null;
		elseCode = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeCode cond = default(D540OpeCode);
		if (condition != null)
		{
			cond = condition.clone();
		}
		D540OpeCode d540OpeCode = default(D540OpeCode);
		if (thenCode != null)
		{
			d540OpeCode = thenCode.clone();
		}
		D540OpeCode d540OpeCode2 = default(D540OpeCode);
		if (elseCode != null)
		{
			d540OpeCode2 = elseCode.clone();
		}
		return New(cond, d540OpeCode, d540OpeCode2);
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
		if (condition != null)
		{
			condition.OnGUI();
		}
		if (thenCode != null)
		{
			thenCode.OnGUI();
		}
		if (elseCode != null)
		{
			elseCode.OnGUI();
		}
	}

	public static D540OpeIfElse New(D540OpeCode cond, D540OpeCode _thenCode, D540OpeCode _elseCode)
	{
		D540OpeIfElse d540OpeIfElse = (D540OpeIfElse)D540OpeCodePool.NewObj(D540OpeCodeId.OpeIfElse);
		d540OpeIfElse.Condition = cond;
		d540OpeIfElse.Then = _thenCode;
		d540OpeIfElse.Else = _elseCode;
		return d540OpeIfElse;
	}
}
