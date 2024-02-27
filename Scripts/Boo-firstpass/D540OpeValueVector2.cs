using System;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpeValueVector2 : D540OpeValue
{
	public Vector2 valueVector2;

	public override object Value => valueVector2;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueVector2(this);
	}

	public override void clear()
	{
		valueVector2 = Vector2.zero;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueVector2 d540OpeValueVector = (D540OpeValueVector2)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueVector2);
		d540OpeValueVector.valueVector2 = valueVector2;
		return d540OpeValueVector;
	}

	public new static D540OpeValueVector2 New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueVector2) as D540OpeValueVector2;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpeValueVector2 ").Append(valueVector2).ToString();
	}
}
