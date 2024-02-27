using System;

[Serializable]
public class D540OpeValueObject : D540OpeValue
{
	public object valueObject;

	public override object Value => valueObject;

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeValueObject(this);
	}

	public override void clear()
	{
		valueObject = null;
	}

	public override D540OpeCode clone()
	{
		D540OpeValueObject d540OpeValueObject = (D540OpeValueObject)D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueObject);
		d540OpeValueObject.valueObject = valueObject;
		return d540OpeValueObject;
	}

	public new static D540OpeValueObject New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeValueObject) as D540OpeValueObject;
	}
}
