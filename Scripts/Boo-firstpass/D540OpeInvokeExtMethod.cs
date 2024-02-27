using System;
using System.Collections.Generic;
using System.Reflection;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540OpeInvokeExtMethod : D540OpeCode
{
	private D540OpeCode target;

	private List<D540OpeCode> arguments;

	private string methodSignature;

	private string declaringTypeName;

	private MethodInfo method;

	private object[] constantArguments;

	private bool isVoid;

	public MethodInfo Method
	{
		get
		{
			return method;
		}
		set
		{
			method = value;
			bool num = method == null;
			if (!num)
			{
				num = RuntimeServices.EqualityOperator(method.ReturnType, typeof(void));
			}
			isVoid = num;
		}
	}

	public int ArgNum => (constantArguments == null) ? arguments.Count : constantArguments.Length;

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

	public List<D540OpeCode> Arguments => arguments;

	public string MethodSignature
	{
		get
		{
			return methodSignature;
		}
		set
		{
			methodSignature = value;
		}
	}

	public string DeclaringTypeName
	{
		get
		{
			return declaringTypeName;
		}
		set
		{
			declaringTypeName = value;
		}
	}

	public object[] ConstantArguments
	{
		get
		{
			return constantArguments;
		}
		set
		{
			constantArguments = value;
		}
	}

	public bool IsVoid => isVoid;

	public D540OpeInvokeExtMethod()
	{
		arguments = new List<D540OpeCode>();
	}

	public override void clear()
	{
		target = null;
		arguments.Clear();
		methodSignature = null;
		declaringTypeName = null;
		method = null;
		isVoid = false;
		constantArguments = null;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeInvokeExtMethod(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeInvokeExtMethod d540OpeInvokeExtMethod = New();
		if (target != null)
		{
			d540OpeInvokeExtMethod.target = target.clone();
		}
		d540OpeInvokeExtMethod.methodSignature = methodSignature;
		d540OpeInvokeExtMethod.declaringTypeName = declaringTypeName;
		if (arguments != null)
		{
			foreach (D540OpeCode argument in arguments)
			{
				d540OpeInvokeExtMethod.arguments.Add(argument.clone());
			}
		}
		return d540OpeInvokeExtMethod;
	}

	public override void OnEnable()
	{
		HideFlags dEFAULT_HIDE_FLAG = D540OpeCode.DEFAULT_HIDE_FLAG;
		if (arguments == null)
		{
			arguments = new List<D540OpeCode>();
		}
	}

	public void addArgument(D540OpeCode ope)
	{
		OnEnable();
		arguments.Add(ope);
	}

	public void setConstantValueArguments(object[] values)
	{
		if (!(values == null) && constantArguments == null)
		{
			if (values.Length != arguments.Count)
			{
				throw new AssertionFailedException("len(values) == arguments.Count");
			}
			constantArguments = values;
			disposeArgumentNodes();
		}
	}

	private void disposeArgumentNodes()
	{
		foreach (D540OpeCode argument in arguments)
		{
			D540OpeCodePool.Instance.dispose(argument);
		}
		arguments.Clear();
	}

	public override void OnGUI()
	{
	}

	public new static D540OpeInvokeExtMethod New()
	{
		return D540OpeCodePool.NewObj(D540OpeCodeId.OpeInvokeExtMethod) as D540OpeInvokeExtMethod;
	}

	public override string ToString()
	{
		return GetType() + " methodSignature=" + methodSignature + " type=" + declaringTypeName + " argNum=" + ArgNum;
	}
}
