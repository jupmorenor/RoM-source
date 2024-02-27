using System;
using System.Text;

[Serializable]
public class D540OpeValueSingle : D540OpeValue
{
	public float valueSingle;

	public override object Value => valueSingle;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueSingle(this);
	}

	public override void clear()
	{
		valueSingle = 0f;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueSingle d540OpeValueSingle = (D540OpeValueSingle)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueSingle);
		d540OpeValueSingle.valueSingle = valueSingle;
		return d540OpeValueSingle;
	}

	public new static D540OpeValueSingle New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueSingle) as D540OpeValueSingle;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpeValueSingle ").Append(valueSingle).ToString();
	}
}
