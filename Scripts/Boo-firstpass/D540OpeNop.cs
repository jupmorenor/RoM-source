using System;
using UnityEngine;

[Serializable]
public class D540OpeNop : D540OpeCode
{
	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeNop(this);
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

	public new static D540OpeNop New()
	{
		return (D540OpeNop)D540OpeCodePool.NewObj(D540OpeCodeId.OpeNop);
	}

	public override string ToString()
	{
		return GetType().ToString();
	}
}
