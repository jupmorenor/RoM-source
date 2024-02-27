using System;
using System.Text;

[Serializable]
public abstract class D540DepthFirstTraverser : D540OpeCodeVisitor
{
	public virtual bool defaultIn(D540OpeCode node)
	{
		return true;
	}

	public virtual void defaultOut(D540OpeCode node)
	{
	}

	public virtual void caseOpeNop(D540OpeNop node)
	{
		if (inOpeNop(node))
		{
			outOpeNop(node);
		}
	}

	public virtual bool inOpeNop(D540OpeNop node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeNop(D540OpeNop node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeCode(D540OpeCode node)
	{
		if (inOpeCode(node))
		{
			outOpeCode(node);
		}
	}

	public virtual bool inOpeCode(D540OpeCode node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeCode(D540OpeCode node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeExecBlock(D540OpeExecBlock node)
	{
		if (inOpeExecBlock(node))
		{
			outOpeExecBlock(node);
		}
	}

	public virtual bool inOpeExecBlock(D540OpeExecBlock node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeExecBlock(D540OpeExecBlock node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeCompound(D540OpeCompound node)
	{
		if (!inOpeCompound(node))
		{
			return;
		}
		foreach (D540OpeCode code in node.Codes)
		{
			code.apply(this);
		}
		outOpeCompound(node);
	}

	public virtual bool inOpeCompound(D540OpeCompound node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeCompound(D540OpeCompound node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeEcho(D540OpeEcho node)
	{
		if (inOpeEcho(node))
		{
			outOpeEcho(node);
		}
	}

	public virtual bool inOpeEcho(D540OpeEcho node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeEcho(D540OpeEcho node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeSelf(D540OpeSelf node)
	{
		if (inOpeSelf(node))
		{
			outOpeSelf(node);
		}
	}

	public virtual bool inOpeSelf(D540OpeSelf node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeSelf(D540OpeSelf node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeValue(D540OpeValue node)
	{
		if (inOpeValue(node))
		{
			outOpeValue(node);
		}
	}

	public virtual bool inOpeValue(D540OpeValue node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeValue(D540OpeValue node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeValueInt(D540OpeValueInt node)
	{
		if (inOpeValueInt(node))
		{
			outOpeValueInt(node);
		}
	}

	public virtual bool inOpeValueInt(D540OpeValueInt node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueInt(D540OpeValueInt node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueObject(D540OpeValueObject node)
	{
		if (inOpeValueObject(node))
		{
			outOpeValueObject(node);
		}
	}

	public virtual bool inOpeValueObject(D540OpeValueObject node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueObject(D540OpeValueObject node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueSingle(D540OpeValueSingle node)
	{
		if (inOpeValueSingle(node))
		{
			outOpeValueSingle(node);
		}
	}

	public virtual bool inOpeValueSingle(D540OpeValueSingle node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueSingle(D540OpeValueSingle node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueString(D540OpeValueString node)
	{
		if (inOpeValueString(node))
		{
			outOpeValueString(node);
		}
	}

	public virtual bool inOpeValueString(D540OpeValueString node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueString(D540OpeValueString node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueVector3(D540OpeValueVector3 node)
	{
		if (inOpeValueVector3(node))
		{
			outOpeValueVector3(node);
		}
	}

	public virtual bool inOpeValueVector3(D540OpeValueVector3 node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueVector3(D540OpeValueVector3 node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueVector2(D540OpeValueVector2 node)
	{
		if (inOpeValueVector2(node))
		{
			outOpeValueVector2(node);
		}
	}

	public virtual bool inOpeValueVector2(D540OpeValueVector2 node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueVector2(D540OpeValueVector2 node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpeValueBool(D540OpeValueBool node)
	{
		if (inOpeValueBool(node))
		{
			outOpeValueBool(node);
		}
	}

	public virtual bool inOpeValueBool(D540OpeValueBool node)
	{
		return inOpeValue(node);
	}

	public virtual void outOpeValueBool(D540OpeValueBool node)
	{
		outOpeValue(node);
	}

	public virtual void caseOpePrint(D540OpePrint node)
	{
		if (inOpePrint(node))
		{
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpePrint(node);
		}
	}

	public virtual bool inOpePrint(D540OpePrint node)
	{
		return defaultIn(node);
	}

	public virtual void outOpePrint(D540OpePrint node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeSlicing(D540OpeSlicing node)
	{
		if (inOpeSlicing(node))
		{
			if (node.Target != null)
			{
				node.Target.apply(this);
			}
			if (node.IndexStart != null)
			{
				node.IndexStart.apply(this);
			}
			outOpeSlicing(node);
		}
	}

	public virtual bool inOpeSlicing(D540OpeSlicing node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeSlicing(D540OpeSlicing node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeBinary(D540OpeBinary node)
	{
		if (inOpeBinary(node))
		{
			if (node.Left != null)
			{
				node.Left.apply(this);
			}
			if (node.Right != null)
			{
				node.Right.apply(this);
			}
			outOpeBinary(node);
		}
	}

	public virtual bool inOpeBinary(D540OpeBinary node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeBinary(D540OpeBinary node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeUnary(D540OpeUnary node)
	{
		if (inOpeUnary(node))
		{
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpeUnary(node);
		}
	}

	public virtual bool inOpeUnary(D540OpeUnary node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeUnary(D540OpeUnary node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeDup(D540OpeDup node)
	{
		if (inOpeDup(node))
		{
			outOpeDup(node);
		}
	}

	public virtual bool inOpeDup(D540OpeDup node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeDup(D540OpeDup node)
	{
		defaultOut(node);
	}

	public virtual void caseOpePrefab(D540OpePrefab node)
	{
		if (inOpePrefab(node))
		{
			outOpePrefab(node);
		}
	}

	public virtual bool inOpePrefab(D540OpePrefab node)
	{
		return defaultIn(node);
	}

	public virtual void outOpePrefab(D540OpePrefab node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeAssert(D540OpeAssert node)
	{
		if (inOpeAssert(node))
		{
			if (node.Expected != null)
			{
				node.Expected.apply(this);
			}
			outOpeAssert(node);
		}
	}

	public virtual bool inOpeAssert(D540OpeAssert node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeAssert(D540OpeAssert node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeIfElse(D540OpeIfElse node)
	{
		if (inOpeIfElse(node))
		{
			if (node.Condition != null)
			{
				node.Condition.apply(this);
			}
			if (node.Then != null)
			{
				node.Then.apply(this);
			}
			if (node.Else != null)
			{
				node.Else.apply(this);
			}
			outOpeIfElse(node);
		}
	}

	public virtual bool inOpeIfElse(D540OpeIfElse node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeIfElse(D540OpeIfElse node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeWhile(D540OpeWhile node)
	{
		if (inOpeWhile(node))
		{
			if (node.Condition != null)
			{
				node.Condition.apply(this);
			}
			if (node.Body != null)
			{
				node.Body.apply(this);
			}
			outOpeWhile(node);
		}
	}

	public virtual bool inOpeWhile(D540OpeWhile node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeWhile(D540OpeWhile node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		if (!inOpeInvokeMethod(node))
		{
			return;
		}
		foreach (D540OpeCode argument in node.Arguments)
		{
			if (argument != null)
			{
				argument.apply(this);
				continue;
			}
			throw new Exception(GetType() + new StringBuilder(" D540 visitor error: InvokeMethod argument name=").Append(node.MethodName).ToString());
		}
		outOpeInvokeMethod(node);
	}

	public virtual bool inOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		if (!inOpeInvokeExtMethod(node))
		{
			return;
		}
		if (node.Target != null)
		{
			node.Target.apply(this);
		}
		foreach (D540OpeCode argument in node.Arguments)
		{
			argument.apply(this);
		}
		outOpeInvokeExtMethod(node);
	}

	public virtual bool inOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeArrayLiteral(D540OpeArrayLiteral node)
	{
		if (!inOpeArrayLiteral(node))
		{
			return;
		}
		foreach (D540OpeCode expression in node.Expressions)
		{
			expression.apply(this);
		}
		outOpeArrayLiteral(node);
	}

	public virtual bool inOpeArrayLiteral(D540OpeArrayLiteral node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeArrayLiteral(D540OpeArrayLiteral node)
	{
		defaultOut(node);
	}

	public virtual void caseOpePropertyValue(D540OpePropertyValue node)
	{
		if (inOpePropertyValue(node))
		{
			outOpePropertyValue(node);
		}
	}

	public virtual bool inOpePropertyValue(D540OpePropertyValue node)
	{
		return defaultIn(node);
	}

	public virtual void outOpePropertyValue(D540OpePropertyValue node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeField(D540OpeField node)
	{
		if (inOpeField(node))
		{
			outOpeField(node);
		}
	}

	public virtual bool inOpeField(D540OpeField node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeField(D540OpeField node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeExtField(D540OpeExtField node)
	{
		if (inOpeExtField(node))
		{
			if (node.Target != null)
			{
				node.Target.apply(this);
			}
			outOpeExtField(node);
		}
	}

	public virtual bool inOpeExtField(D540OpeExtField node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeExtField(D540OpeExtField node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeAssignExtField(D540OpeAssignExtField node)
	{
		if (inOpeAssignExtField(node))
		{
			if (node.Target != null)
			{
				node.Target.apply(this);
			}
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpeAssignExtField(node);
		}
	}

	public virtual bool inOpeAssignExtField(D540OpeAssignExtField node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeAssignExtField(D540OpeAssignExtField node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeCast(D540OpeCast node)
	{
		if (inOpeCast(node))
		{
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpeCast(node);
		}
	}

	public virtual bool inOpeCast(D540OpeCast node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeCast(D540OpeCast node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeExprStatement(D540OpeExprStatement node)
	{
		if (inOpeExprStatement(node))
		{
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpeExprStatement(node);
		}
	}

	public virtual bool inOpeExprStatement(D540OpeExprStatement node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeExprStatement(D540OpeExprStatement node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeDeclVar(D540OpeDeclVar node)
	{
		if (inOpeDeclVar(node))
		{
			if (node.Initializer != null)
			{
				node.Initializer.apply(this);
			}
			outOpeDeclVar(node);
		}
	}

	public virtual bool inOpeDeclVar(D540OpeDeclVar node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeDeclVar(D540OpeDeclVar node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeAssign(D540OpeAssign node)
	{
		if (inOpeAssign(node))
		{
			if (node.Expression != null)
			{
				node.Expression.apply(this);
			}
			outOpeAssign(node);
		}
	}

	public virtual bool inOpeAssign(D540OpeAssign node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeAssign(D540OpeAssign node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeLocalVar(D540OpeLocalVar node)
	{
		if (inOpeLocalVar(node))
		{
			outOpeLocalVar(node);
		}
	}

	public virtual bool inOpeLocalVar(D540OpeLocalVar node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeLocalVar(D540OpeLocalVar node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeBuiltinFunc(D540OpeBuiltinFunc node)
	{
		if (inOpeBuiltinFunc(node))
		{
			outOpeBuiltinFunc(node);
		}
	}

	public virtual bool inOpeBuiltinFunc(D540OpeBuiltinFunc node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeBuiltinFunc(D540OpeBuiltinFunc node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeMotionID(D540OpeMotionID node)
	{
		if (inOpeMotionID(node))
		{
			outOpeMotionID(node);
		}
	}

	public virtual bool inOpeMotionID(D540OpeMotionID node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeMotionID(D540OpeMotionID node)
	{
		defaultOut(node);
	}

	public virtual void caseOpeEnumOrString(D540OpeEnumOrString node)
	{
		if (inOpeEnumOrString(node))
		{
			outOpeEnumOrString(node);
		}
	}

	public virtual bool inOpeEnumOrString(D540OpeEnumOrString node)
	{
		return defaultIn(node);
	}

	public virtual void outOpeEnumOrString(D540OpeEnumOrString node)
	{
		defaultOut(node);
	}
}
