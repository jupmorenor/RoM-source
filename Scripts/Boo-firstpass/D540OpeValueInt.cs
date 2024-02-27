using System;
using System.Text;

[Serializable]
public class D540OpeValueInt : D540OpeValue
{
	public int valueInt;

	public override object Value => valueInt;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueInt(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeValueInt d540OpeValueInt = (D540OpeValueInt)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueInt);
		d540OpeValueInt.valueInt = valueInt;
		return d540OpeValueInt;
	}

	public override void clear()
	{
		valueInt = 0;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpeValueInt ").Append((object)valueInt).ToString();
	}

	public new static D540OpeValueInt New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueInt) as D540OpeValueInt;
	}
}
