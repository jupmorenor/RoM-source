using System;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpeValueVector3 : D540OpeValue
{
	public Vector3 valueVector3;

	public override object Value => valueVector3;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueVector3(this);
	}

	public override void clear()
	{
		valueVector3 = Vector3.zero;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueVector3 d540OpeValueVector = (D540OpeValueVector3)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueVector3);
		d540OpeValueVector.valueVector3 = valueVector3;
		return d540OpeValueVector;
	}

	public new static D540OpeValueVector3 New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueVector3) as D540OpeValueVector3;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpeValueVector3 ").Append(valueVector3).ToString();
	}
}
