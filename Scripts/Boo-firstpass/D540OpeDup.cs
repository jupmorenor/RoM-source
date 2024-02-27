using System;
using UnityEngine;

[Serializable]
public class D540OpeDup : D540OpeCode
{
	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeDup(this);
	}

	public override D540OpeCode clone()
	{
		return New();
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeDup New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeDup) as D540OpeDup;
	}
}
