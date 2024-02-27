using System;
using UnityEngine;

[Serializable]
public class D540OpeSelf : D540OpeCode
{
	private string selfTypeName;

	private int receiverIndex;

	public string SelfTypeName
	{
		get
		{
			return selfTypeName;
		}
		set
		{
			selfTypeName = value;
		}
	}

	public int ReceiverIndex
	{
		get
		{
			return receiverIndex;
		}
		set
		{
			receiverIndex = value;
		}
	}

	public D540OpeSelf()
	{
		receiverIndex = -1;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeSelf(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeSelf d540OpeSelf = New();
		d540OpeSelf.selfTypeName = selfTypeName;
		return d540OpeSelf;
	}

	public override void clear()
	{
		selfTypeName = null;
		receiverIndex = -1;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeSelf New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeSelf) as D540OpeSelf;
	}

	public static D540OpeSelf New(string typeName)
	{
		D540OpeSelf d540OpeSelf = (D540OpeSelf)D540OpeCodePool.NewObj(D540OpeCodeId.OpeSelf);
		d540OpeSelf.SelfTypeName = typeName;
		return d540OpeSelf;
	}

	public override string ToString()
	{
		return GetType().ToString() + " type=" + selfTypeName;
	}
}
