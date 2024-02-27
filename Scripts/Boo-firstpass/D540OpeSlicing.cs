using System;
using UnityEngine;

[Serializable]
public class D540OpeSlicing : D540OpeCode
{
	private D540OpeCode target;

	private D540OpeCode indexStart;

	public D540OpeCode Target
	{
		get
		{
			return target;
		}
		set
		{
			target = value;
		}
	}

	public D540OpeCode IndexStart
	{
		get
		{
			return indexStart;
		}
		set
		{
			indexStart = value;
		}
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeSlicing(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeCode d540OpeCode = default(D540OpeCode);
		if (target != null)
		{
			d540OpeCode = target.clone();
		}
		D540OpeCode idxs = default(D540OpeCode);
		if (indexStart != null)
		{
			idxs = indexStart.clone();
		}
		return New(d540OpeCode, idxs);
	}

	public override void clear()
	{
		target = null;
		indexStart = null;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public static D540OpeSlicing New(D540OpeCode target, D540OpeCode idxs)
	{
		D540OpeSlicing d540OpeSlicing = (D540OpeSlicing)D540OpeCodePool.NewObj(D540OpeCodeId.OpeSlicing);
		d540OpeSlicing.target = target;
		d540OpeSlicing.indexStart = idxs;
		return d540OpeSlicing;
	}
}
