using System;
using System.Text;

[Serializable]
public class D540OpeValueBool : D540OpeValue
{
	public bool valueBool;

	public override object Value => valueBool;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueBool(this);
	}

	public override void clear()
	{
		valueBool = false;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueBool d540OpeValueBool = (D540OpeValueBool)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueBool);
		d540OpeValueBool.valueBool = valueBool;
		return d540OpeValueBool;
	}

	public new static D540OpeValueBool New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueBool) as D540OpeValueBool;
	}

	public override string ToString()
	{
		return new StringBuilder("D540OpeValueBool ").Append(valueBool).ToString();
	}
}
