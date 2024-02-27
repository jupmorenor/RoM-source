using System;
using System.Collections.Generic;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class D540BinaryToCodeTree : D540BinaryVisitor
{
	[Serializable]
	internal class _0024outOpeCompound_0024locals_00242306
	{
		internal D540OpeCompound _0024compo;
	}

	[Serializable]
	internal class _0024doOpeInvokeMethod_0024locals_00242307
	{
		internal D540OpeInvokeMethod _0024code;
	}

	[Serializable]
	internal class _0024doOpeInvokeExtMethod_0024locals_00242308
	{
		internal D540OpeInvokeExtMethod _0024code;
	}

	[Serializable]
	internal class _0024doOpeArrayLiteral_0024locals_00242309
	{
		internal D540OpeArrayLiteral _0024code;
	}

	[Serializable]
	internal class _0024outOpeCompound_0024closure_00241046
	{
		internal _0024outOpeCompound_0024locals_00242306 _0024_0024locals_00242315;

		public _0024outOpeCompound_0024closure_00241046(_0024outOpeCompound_0024locals_00242306 _0024_0024locals_00242315)
		{
			this._0024_0024locals_00242315 = _0024_0024locals_00242315;
		}

		public void Invoke(D540OpeCode c)
		{
			if (c == null)
			{
				throw new AssertionFailedException("c != null");
			}
			_0024_0024locals_00242315._0024compo.Codes.Add(c);
		}
	}

	[Serializable]
	internal class _0024doOpeInvokeMethod_0024closure_00241047
	{
		internal _0024doOpeInvokeMethod_0024locals_00242307 _0024_0024locals_00242316;

		public _0024doOpeInvokeMethod_0024closure_00241047(_0024doOpeInvokeMethod_0024locals_00242307 _0024_0024locals_00242316)
		{
			this._0024_0024locals_00242316 = _0024_0024locals_00242316;
		}

		public void Invoke(D540OpeCode c)
		{
			_0024_0024locals_00242316._0024code.Arguments.Add(c);
		}
	}

	[Serializable]
	internal class _0024doOpeInvokeExtMethod_0024closure_00241048
	{
		internal _0024doOpeInvokeExtMethod_0024locals_00242308 _0024_0024locals_00242317;

		public _0024doOpeInvokeExtMethod_0024closure_00241048(_0024doOpeInvokeExtMethod_0024locals_00242308 _0024_0024locals_00242317)
		{
			this._0024_0024locals_00242317 = _0024_0024locals_00242317;
		}

		public void Invoke(D540OpeCode c)
		{
			_0024_0024locals_00242317._0024code.Arguments.Add(c);
		}
	}

	[Serializable]
	internal class _0024doOpeArrayLiteral_0024closure_00241049
	{
		internal _0024doOpeArrayLiteral_0024locals_00242309 _0024_0024locals_00242318;

		public _0024doOpeArrayLiteral_0024closure_00241049(_0024doOpeArrayLiteral_0024locals_00242309 _0024_0024locals_00242318)
		{
			this._0024_0024locals_00242318 = _0024_0024locals_00242318;
		}

		public void Invoke(D540OpeCode c)
		{
			_0024_0024locals_00242318._0024code.Expressions.Add(c);
		}
	}

	private Stack<D540OpeCode> codeStack;

	public bool HasResult => codeStack.Count > 0;

	public D540OpeCode Result => codeStack.Peek();

	public D540BinaryToCodeTree()
	{
		codeStack = new Stack<D540OpeCode>();
	}

	public static D540OpeCode BuildTree(byte[] byteCode)
	{
		object result;
		if (byteCode != null && byteCode.Length > 0)
		{
			D540BinaryToCodeTree d540BinaryToCodeTree = new D540BinaryToCodeTree();
			d540BinaryToCodeTree.traverse(byteCode);
			result = d540BinaryToCodeTree.Result;
		}
		else
		{
			result = null;
		}
		return (D540OpeCode)result;
	}

	public void clear()
	{
		codeStack.Clear();
	}

	private void push(D540OpeCode c)
	{
		if (c == null)
		{
			throw new AssertionFailedException("c != null");
		}
		codeStack.Push(c);
	}

	private D540OpeCode pop()
	{
		return codeStack.Pop();
	}

	private void reversePop(int n, __D540BinaryToCodeTree_reversePop_0024callable18_002436_47__ func)
	{
		if (n > 0)
		{
			D540OpeCode arg = pop();
			reversePop(checked(n - 1), func);
			if (func != null)
			{
				func(arg);
			}
		}
	}

	protected override void doHeader(int version)
	{
	}

	protected override void doStringTable(string[] tbl)
	{
	}

	protected override void doOpeCode()
	{
	}

	protected override void doOpeNop()
	{
		push(D540OpeNop.New());
	}

	protected override void doOpeExecBlock()
	{
	}

	protected override void inOpeCompound()
	{
	}

	protected override void outOpeCompound(int codeNum)
	{
		_0024outOpeCompound_0024locals_00242306 _0024outOpeCompound_0024locals_0024 = new _0024outOpeCompound_0024locals_00242306();
		_0024outOpeCompound_0024locals_0024._0024compo = D540OpeCompound.New();
		reversePop(codeNum, new _0024outOpeCompound_0024closure_00241046(_0024outOpeCompound_0024locals_0024).Invoke);
		push(_0024outOpeCompound_0024locals_0024._0024compo);
	}

	protected override void doOpeEcho(string msg)
	{
		push(D540OpeEcho.New(msg));
	}

	protected override void doOpeSelf(string selfTypeName)
	{
		push(D540OpeSelf.New(selfTypeName));
	}

	protected override void doOpePrint()
	{
		D540OpeCode expr = pop();
		push(D540OpePrint.New(expr));
	}

	protected override void doOpeSlicing()
	{
		D540OpeCode idxs = pop();
		D540OpeCode target = pop();
		push(D540OpeSlicing.New(target, idxs));
	}

	protected override void doOpeBinary(D540OpeBinary.EOpe @operator)
	{
		D540OpeCode right = pop();
		D540OpeCode left = pop();
		push(D540OpeBinary.New(@operator, left, right));
	}

	protected override void doOpeUnary(D540OpeUnary.EOpe @operator)
	{
		D540OpeCode expre = pop();
		push(D540OpeUnary.New(@operator, expre));
	}

	protected override void doOpeDup()
	{
		push(D540OpeDup.New());
	}

	protected override void doOpePrefab(string prefabName)
	{
		push(D540OpePrefab.New(prefabName));
	}

	protected override void doOpeIfElse()
	{
		D540OpeCode elseCode = pop();
		D540OpeCode thenCode = pop();
		D540OpeCode cond = pop();
		push(D540OpeIfElse.New(cond, thenCode, elseCode));
	}

	protected override void doOpeInvokeMethod(string methodName, int argNum)
	{
		_0024doOpeInvokeMethod_0024locals_00242307 _0024doOpeInvokeMethod_0024locals_0024 = new _0024doOpeInvokeMethod_0024locals_00242307();
		_0024doOpeInvokeMethod_0024locals_0024._0024code = D540OpeInvokeMethod.New(methodName);
		reversePop(argNum, new _0024doOpeInvokeMethod_0024closure_00241047(_0024doOpeInvokeMethod_0024locals_0024).Invoke);
		push(_0024doOpeInvokeMethod_0024locals_0024._0024code);
	}

	protected override void doOpeInvokeExtMethod(string methodSignature, string declType, int argNum, bool withTarget)
	{
		_0024doOpeInvokeExtMethod_0024locals_00242308 _0024doOpeInvokeExtMethod_0024locals_0024 = new _0024doOpeInvokeExtMethod_0024locals_00242308();
		_0024doOpeInvokeExtMethod_0024locals_0024._0024code = D540OpeInvokeExtMethod.New();
		_0024doOpeInvokeExtMethod_0024locals_0024._0024code.MethodSignature = methodSignature;
		_0024doOpeInvokeExtMethod_0024locals_0024._0024code.DeclaringTypeName = declType;
		reversePop(argNum, new _0024doOpeInvokeExtMethod_0024closure_00241048(_0024doOpeInvokeExtMethod_0024locals_0024).Invoke);
		if (withTarget)
		{
			_0024doOpeInvokeExtMethod_0024locals_0024._0024code.Target = pop();
		}
		push(_0024doOpeInvokeExtMethod_0024locals_0024._0024code);
	}

	protected override void doOpeArrayLiteral(int elmNum)
	{
		_0024doOpeArrayLiteral_0024locals_00242309 _0024doOpeArrayLiteral_0024locals_0024 = new _0024doOpeArrayLiteral_0024locals_00242309();
		_0024doOpeArrayLiteral_0024locals_0024._0024code = D540OpeArrayLiteral.New();
		reversePop(elmNum, new _0024doOpeArrayLiteral_0024closure_00241049(_0024doOpeArrayLiteral_0024locals_0024).Invoke);
		push(_0024doOpeArrayLiteral_0024locals_0024._0024code);
	}

	protected override void doOpePropertyValue(string propertyName)
	{
		push(D540OpePropertyValue.New(propertyName));
	}

	protected override void doOpeField(string fieldName)
	{
		push(D540OpeField.New(fieldName));
	}

	protected override void doOpeExtField(string fieldName, string declType)
	{
		push(D540OpeExtField.New(fieldName, declType));
	}

	protected override void doOpeAssignExtField(string fieldName, string declType)
	{
		D540OpeCode expression = pop();
		D540OpeCode target = pop();
		D540OpeAssignExtField d540OpeAssignExtField = D540OpeAssignExtField.New(fieldName, declType);
		d540OpeAssignExtField.Target = target;
		d540OpeAssignExtField.Expression = expression;
		push(d540OpeAssignExtField);
	}

	protected override void doOpeCast(D540OpeCast.EOpe ope)
	{
		D540OpeCode expr = pop();
		push(D540OpeCast.New(ope, expr));
	}

	protected override void doOpeExprStatement()
	{
		D540OpeCode expression = pop();
		push(D540OpeExprStatement.New(expression));
	}

	protected override void doOpeWhile()
	{
		D540OpeCode body = pop();
		D540OpeCode condition = pop();
		push(D540OpeWhile.New(condition, body));
	}

	protected override void doOpeDeclVar(string varName)
	{
		D540OpeCode initializer = pop();
		push(D540OpeDeclVar.New(varName, initializer));
	}

	protected override void doOpeAssign(D540OpeAssign.ELeftType leftType, string varName)
	{
		D540OpeCode expression = pop();
		push(D540OpeAssign.New(leftType, varName, expression));
	}

	protected override void doOpeLocalVar(string varName)
	{
		push(D540OpeLocalVar.New(varName));
	}

	protected override void doOpeBuiltinFunc(string typeName)
	{
		push(D540OpeBuiltinFunc.New(typeName));
	}

	protected override void doOpeMotionID(string motName, bool hasMotionName, string motionTypeName)
	{
		D540OpeMotionID d540OpeMotionID = D540OpeMotionID.New();
		d540OpeMotionID.Name = motName;
		d540OpeMotionID.HasMotionName = hasMotionName;
		d540OpeMotionID.MotionTypeName = motionTypeName;
		push(d540OpeMotionID);
	}

	protected override void doOpeEnumOrString(string stringValue, bool isEnum, string enumTypeName, string enumOrStringValueTypeName)
	{
		D540OpeEnumOrString d540OpeEnumOrString = D540OpeEnumOrString.New();
		d540OpeEnumOrString.StringValue = stringValue;
		d540OpeEnumOrString.IsEnum = isEnum;
		d540OpeEnumOrString.EnumTypeName = enumTypeName;
		d540OpeEnumOrString.EnumOrStringValueTypeName = enumOrStringValueTypeName;
		push(d540OpeEnumOrString);
	}

	protected override void doOpeValue()
	{
		push(D540OpeValue.NewNull());
	}

	protected override void doOpeValueInt(int value)
	{
		push(D540OpeValue.NewInt(value));
	}

	protected override void doOpeValueObject(object value)
	{
		push(D540OpeValue.NewNull());
	}

	protected override void doOpeValueSingle(float value)
	{
		push(D540OpeValue.NewSingle(value));
	}

	protected override void doOpeValueString(string value)
	{
		push(D540OpeValue.NewString(value));
	}

	protected override void doOpeValueVector2(Vector2 value)
	{
		push(D540OpeValue.New(value));
	}

	protected override void doOpeValueVector3(Vector3 value)
	{
		push(D540OpeValue.New(value));
	}

	protected override void doOpeValueBool(bool value)
	{
		push(D540OpeValue.New(value));
	}

	protected override void doOpeAssert()
	{
		D540OpeAssert d540OpeAssert = D540OpeAssert.New();
		d540OpeAssert.Expected = pop();
		push(d540OpeAssert);
	}
}
