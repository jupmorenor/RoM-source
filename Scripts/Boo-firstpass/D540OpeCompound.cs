using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class D540OpeCompound : D540OpeCode
{
	private List<D540OpeCode> codes;

	public List<D540OpeCode> Codes
	{
		get
		{
			return codes;
		}
		set
		{
			codes = value;
		}
	}

	public D540OpeCompound()
	{
		codes = new List<D540OpeCode>();
	}

	public void add(D540OpeCode ope)
	{
		codes.Add(ope);
	}

	public override void clear()
	{
		codes.Clear();
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeCompound(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeCompound d540OpeCompound = New();
		if (d540OpeCompound.codes == null)
		{
			d540OpeCompound.codes = new List<D540OpeCode>();
		}
		foreach (D540OpeCode code in codes)
		{
			d540OpeCompound.codes.Add(code.clone());
		}
		return d540OpeCompound;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
		if (codes == null)
		{
			codes = new List<D540OpeCode>();
		}
	}

	public override void OnGUI()
	{
		foreach (D540OpeCode code in codes)
		{
			code.OnGUI();
		}
	}

	public new static D540OpeCompound New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeCompound) as D540OpeCompound;
	}
}
