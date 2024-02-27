using System;
using System.Reflection;
using System.Text;
using UnityEngine;

[Serializable]
public class D540OpeAssign : D540OpeCode
{
	[Serializable]
	public enum ELeftType
	{
		LOCAL,
		FIELD,
		PROPERTY
	}

	private ELeftType leftType;

	private string leftVarName;

	private D540OpeCode expression;

	private FieldInfo field;

	private PropertyInfo property;

	private int receiverIndex;

	public ELeftType LeftType
	{
		get
		{
			return leftType;
		}
		set
		{
			leftType = value;
		}
	}

	public string LeftVarName
	{
		get
		{
			return leftVarName;
		}
		set
		{
			leftVarName = value;
		}
	}

	public D540OpeCode Expression
	{
		get
		{
			return expression;
		}
		set
		{
			expression = value;
		}
	}

	public FieldInfo Field
	{
		get
		{
			return field;
		}
		set
		{
			field = value;
		}
	}

	public PropertyInfo Property
	{
		get
		{
			return property;
		}
		set
		{
			property = value;
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

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeAssign(this);
	}

	public override void clear()
	{
		leftType = ELeftType.LOCAL;
		leftVarName = null;
		expression = null;
		field = null;
		property = null;
		receiverIndex = 0;
	}

	public override D540OpeCode clone()
	{
		return New(leftType, leftVarName, expression.clone());
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
	}

	public override void OnGUI()
	{
	}

	public override string ToString()
	{
		return GetType() + new StringBuilder(" ").Append(leftVarName).Append(" of ").Append(leftType)
			.ToString();
	}

	public static D540OpeAssign New(ELeftType leftType, string leftVarName, D540OpeCode expression)
	{
		D540OpeAssign d540OpeAssign = (D540OpeAssign)D540OpeCodePool.NewObj(D540OpeCodeId.OpeAssign);
		d540OpeAssign.leftType = leftType;
		d540OpeAssign.leftVarName = leftVarName;
		d540OpeAssign.expression = expression;
		return d540OpeAssign;
	}

	public static D540OpeAssign NewLocal(string leftVarName, D540OpeCode expression)
	{
		return New(ELeftType.LOCAL, leftVarName, expression);
	}

	public static D540OpeAssign NewField(string leftVarName, D540OpeCode expression)
	{
		return New(ELeftType.FIELD, leftVarName, expression);
	}

	public static D540OpeAssign NewProperty(string leftVarName, D540OpeCode expression)
	{
		return New(ELeftType.PROPERTY, leftVarName, expression);
	}
}
