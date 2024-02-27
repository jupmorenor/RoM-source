using System;
using System.Collections.Generic;
using System.Reflection;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class D540OpeInvokeMethod : D540OpeCode
{
	private List<D540OpeCode> arguments;

	private string methodName;

	private MethodInfo _method;

	private int receiverIndex;

	private bool isVoid;

	private object[] constantArguments;

	public MethodInfo Method
	{
		get
		{
			return _method;
		}
		set
		{
			_method = value;
			bool num = _method == null;
			if (!num)
			{
				num = RuntimeServices.EqualityOperator(_method.ReturnType, typeof(void));
			}
			isVoid = num;
		}
	}

	public int ArgNum => (constantArguments == null) ? arguments.Count : constantArguments.Length;

	public List<D540OpeCode> Arguments => arguments;

	public string MethodName
	{
		get
		{
			return methodName;
		}
		set
		{
			methodName = value;
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

	public bool IsVoid
	{
		get
		{
			return isVoid;
		}
		set
		{
			isVoid = value;
		}
	}

	public object[] ConstantArguments => constantArguments;

	public D540OpeInvokeMethod()
	{
		arguments = new List<D540OpeCode>();
		receiverIndex = -1;
	}

	public override void apply(D540OpeCodeVisitor v)
	{
		v.caseOpeInvokeMethod(this);
	}

	public override D540OpeCode clone()
	{
		D540OpeInvokeMethod d540OpeInvokeMethod = New(methodName);
		if (arguments != null)
		{
			foreach (D540OpeCode argument in arguments)
			{
				d540OpeInvokeMethod.arguments.Add(argument.clone());
			}
		}
		return d540OpeInvokeMethod;
	}

	public override void clear()
	{
		arguments.Clear();
		methodName = null;
		_method = null;
		receiverIndex = -1;
		isVoid = false;
		constantArguments = null;
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
		if (!(values == null) && ConstantArguments == null)
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

	public static D540OpeInvokeMethod New(string methodName)
	{
		if (string.IsNullOrEmpty(methodName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(methodName)");
		}
		D540OpeInvokeMethod d540OpeInvokeMethod = (D540OpeInvokeMethod)D540OpeCodePool.NewObj(D540OpeCodeId.OpeInvokeMethod);
		d540OpeInvokeMethod.MethodName = methodName;
		return d540OpeInvokeMethod;
	}

	public override string ToString()
	{
		return GetType() + " name=" + methodName + " argNum=" + ArgNum;
	}
}
