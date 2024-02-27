using System;
using System.Text;

[Serializable]
public class D540OpeValueString : D540OpeValue
{
	public string valueString;

	public override object Value => valueString;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueString(this);
	}

	public override void clear()
	{
		valueString = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueString d540OpeValueString = (D540OpeValueString)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueString);
		d540OpeValueString.valueString = valueString;
		return d540OpeValueString;
	}

	public new static D540OpeValueString New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueString) as D540OpeValueString;
	}

	public override string ToString()
	{
		return new StringBuilder().Append(GetType()).Append("('").ToString() + Value + "')";
	}
}
