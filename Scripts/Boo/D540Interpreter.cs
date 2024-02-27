using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class D540Interpreter : D540DepthFirstTraverser
{
	private Component[] receivers;

	private __D540Interpreter_PrefabLoader_0024callable0_002412_29__ prefabLoader;

	private Dictionary<string, object> localVars;

	private Stack<object> stack;

	private bool _0024initialized__D540Interpreter_0024;

	public int StackDepth => stack.Count;

	public bool IsStackEmpty => stack.Count <= 0;

	public Component[] Receivers
	{
		get
		{
			return receivers;
		}
		set
		{
			receivers = value;
		}
	}

	public __D540Interpreter_PrefabLoader_0024callable0_002412_29__ PrefabLoader
	{
		get
		{
			return prefabLoader;
		}
		set
		{
			prefabLoader = value;
		}
	}

	public D540Interpreter()
	{
		if (!_0024initialized__D540Interpreter_0024)
		{
			localVars = new Dictionary<string, object>();
			stack = new Stack<object>();
			_0024initialized__D540Interpreter_0024 = true;
		}
	}

	public D540Interpreter(GameObject receiver)
	{
		if (!_0024initialized__D540Interpreter_0024)
		{
			localVars = new Dictionary<string, object>();
			stack = new Stack<object>();
			_0024initialized__D540Interpreter_0024 = true;
		}
		if (!(receiver != null))
		{
			throw new AssertionFailedException("receiver != null");
		}
		Component[] components = receiver.GetComponents<Component>();
		init(components);
	}

	public D540Interpreter(Component[] components)
	{
		if (!_0024initialized__D540Interpreter_0024)
		{
			localVars = new Dictionary<string, object>();
			stack = new Stack<object>();
			_0024initialized__D540Interpreter_0024 = true;
		}
		init(components);
	}

	private void init(Component[] _receivers)
	{
		receivers = _receivers;
	}

	public void execute(D540OpeCode[] codes)
	{
		if (!(codes == null) && codes.Length > 0)
		{
			int i = 0;
			for (int length = codes.Length; i < length; i = checked(i + 1))
			{
				execute(codes[i]);
			}
		}
	}

	public void execute(D540OpeCode code)
	{
		code?.apply(this);
	}

	public void clearStack()
	{
		stack.Clear();
	}

	private void push(object v)
	{
		stack.Push(v);
	}

	[DuckTyped]
	public object pop()
	{
		return stack.Pop();
	}

	[DuckTyped]
	private object peek()
	{
		return stack.Peek();
	}

	private object[] popForArguments(int n)
	{
		if (stack.Count < n)
		{
			throw new AssertionFailedException(new StringBuilder("stack count=").Append((object)stack.Count).Append(" n=").Append((object)n)
				.ToString());
		}
		Boo.Lang.List<object> list = new Boo.Lang.List<object>();
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int num2 = num;
			num++;
			list.Add(stack.Pop());
		}
		return list.ToArray();
	}

	private object[] popForArgumentsToBuff(int n, object[] buff)
	{
		if (stack.Count < n)
		{
			throw new AssertionFailedException(new StringBuilder("stack count=").Append((object)stack.Count).Append(" n=").Append((object)n)
				.ToString());
		}
		int num = 0;
		if (n < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < n)
		{
			int index = num;
			num++;
			buff[RuntimeServices.NormalizeArrayIndex(buff, index)] = stack.Pop();
		}
		return buff;
	}

	private object receiverObject(int index)
	{
		object result;
		if (receivers == null || index < 0 || index >= receivers.Length)
		{
			result = null;
		}
		else
		{
			Component[] array = receivers;
			result = array[RuntimeServices.NormalizeArrayIndex(array, index)];
		}
		return result;
	}

	public override void caseOpeEcho(D540OpeEcho node)
	{
	}

	public override void caseOpeSelf(D540OpeSelf node)
	{
		object v = receiverObject(node.ReceiverIndex);
		push(v);
	}

	public override void caseOpeValue(D540OpeValue node)
	{
		push(node.Value);
	}

	public override void caseOpeValueInt(D540OpeValueInt node)
	{
		push(node.valueInt);
	}

	public override void caseOpeValueObject(D540OpeValueObject node)
	{
		push(node.valueObject);
	}

	public override void caseOpeValueSingle(D540OpeValueSingle node)
	{
		push(node.valueSingle);
	}

	public override void caseOpeValueString(D540OpeValueString node)
	{
		push(node.valueString);
	}

	public override void caseOpeValueVector2(D540OpeValueVector2 node)
	{
		push(node.valueVector2);
	}

	public override void caseOpeValueVector3(D540OpeValueVector3 node)
	{
		push(node.valueVector3);
	}

	public override void caseOpeValueBool(D540OpeValueBool node)
	{
		push(node.valueBool);
	}

	public override void outOpePrint(D540OpePrint node)
	{
		if (node.Expression == null)
		{
		}
	}

	public override void caseOpeSlicing(D540OpeSlicing node)
	{
		if (node.Target == null || node.IndexStart == null)
		{
			throw new AssertionFailedException("(node.Target != null) and (node.IndexStart != null)");
		}
		node.IndexStart.apply(this);
		object value = pop();
		node.Target.apply(this);
		object obj = pop();
		if (!(obj is object[] array))
		{
			throw new AssertionFailedException(new StringBuilder("slicing target error: ").Append(obj).Append(" ").Append((obj == null) ? ((object)"<null>") : ((object)obj.GetType()))
				.ToString());
		}
		push(array[RuntimeServices.NormalizeArrayIndex(array, RuntimeServices.UnboxInt32(value))]);
	}

	public override void caseOpeBinary(D540OpeBinary node)
	{
		if (node.Right == null || node.Left == null)
		{
			throw new AssertionFailedException("(node.Right != null) and (node.Left != null)");
		}
		D540OpeBinary.EOpe d540Operator = node.D540Operator;
		switch (d540Operator)
		{
		case D540OpeBinary.EOpe.ADD:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_Addition", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.SUB:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_Subtraction", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.MULT:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_Multiply", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.DIV:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_Division", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.MOD:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_Modulus", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.EQ:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.EqualityOperator(lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.NE:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(!RuntimeServices.EqualityOperator(lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.GT:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_GreaterThan", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.GE:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_GreaterThanOrEqual", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.LT:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_LessThan", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.LE:
		{
			object lhs = evaluate(node.Left);
			object rhs = evaluate(node.Right);
			push(RuntimeServices.InvokeBinaryOperator("op_LessThanOrEqual", lhs, rhs));
			break;
		}
		case D540OpeBinary.EOpe.AND:
			if (RuntimeServices.ToBool(evaluate(node.Left)) && RuntimeServices.ToBool(evaluate(node.Right)))
			{
				push(true);
			}
			else
			{
				push(false);
			}
			break;
		case D540OpeBinary.EOpe.OR:
			if (RuntimeServices.ToBool(evaluate(node.Left)) || RuntimeServices.ToBool(evaluate(node.Right)))
			{
				push(true);
			}
			else
			{
				push(false);
			}
			break;
		default:
			throw new Exception(new StringBuilder("D540OpeBinary: unknown operator ").Append(d540Operator).ToString());
		}
	}

	[DuckTyped]
	private object evaluate(D540OpeCode node)
	{
		if (node == null)
		{
			throw new AssertionFailedException("node != null");
		}
		node.apply(this);
		return pop();
	}

	public override void outOpeUnary(D540OpeUnary node)
	{
		if (node.Expression == null)
		{
			throw new AssertionFailedException("node.Expression != null");
		}
		D540OpeUnary.EOpe d540Operator = node.D540Operator;
		object obj = pop();
		switch (d540Operator)
		{
		case D540OpeUnary.EOpe.MINUS:
			push(RuntimeServices.InvokeUnaryOperator("op_UnaryNegation", obj));
			break;
		case D540OpeUnary.EOpe.NOT:
			push(!RuntimeServices.ToBool(obj));
			break;
		default:
			throw new Exception(new StringBuilder("D540OpeUnary: unknown operator ").Append(d540Operator).ToString());
		}
	}

	public override void caseOpeDup(D540OpeDup node)
	{
		if (IsStackEmpty)
		{
			throw new AssertionFailedException("not IsStackEmpty");
		}
		push(peek());
	}

	public override void caseOpePrefab(D540OpePrefab node)
	{
		string prefabName = node.PrefabName;
		if (!string.IsNullOrEmpty(prefabName) && prefabLoader != null)
		{
			push(prefabLoader(prefabName));
		}
		else
		{
			push(null);
		}
	}

	public override void outOpeAssert(D540OpeAssert node)
	{
		if (stack.Count < 2)
		{
			throw new AssertionFailedException("D540OpeAssert!: stack depth < 2");
		}
		if (node.Expected == null)
		{
			throw new AssertionFailedException("D540OpeAssert!: expected = null");
		}
		object obj = pop();
		object obj2 = peek();
		if (RuntimeServices.EqualityOperator(obj2, obj))
		{
			return;
		}
		throw new Exception(new StringBuilder("D540OpeAssert!: ").Append(obj2).Append(" != ").Append(obj)
			.Append("(expected)")
			.ToString());
	}

	public override void caseOpeExecBlock(D540OpeExecBlock node)
	{
		if (node.Block != null)
		{
			node.Block.Call(new object[0]);
		}
	}

	public override void caseOpeIfElse(D540OpeIfElse node)
	{
		if (node.Condition == null)
		{
			return;
		}
		node.Condition.apply(this);
		object value = pop();
		if (RuntimeServices.ToBool(value))
		{
			if (node.Then != null)
			{
				node.Then.apply(this);
			}
		}
		else if (node.Else != null)
		{
			node.Else.apply(this);
		}
	}

	public override void caseOpeWhile(D540OpeWhile node)
	{
		if (node.Condition == null)
		{
			return;
		}
		while (true)
		{
			node.Condition.apply(this);
			object value = pop();
			if (!RuntimeServices.ToBool(value))
			{
				break;
			}
			if (node.Body != null)
			{
				node.Body.apply(this);
			}
		}
	}

	public override void caseOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		object[] constantArguments = node.ConstantArguments;
		if (constantArguments != null)
		{
			outOpeInvokeMethod(node);
		}
		else
		{
			base.caseOpeInvokeMethod(node);
		}
	}

	public override void outOpeInvokeMethod(D540OpeInvokeMethod node)
	{
		MethodInfo method = node.Method;
		if (method == null)
		{
			throw new AssertionFailedException(new StringBuilder("'").Append(node.MethodName).Append("'メソッドが未解決です。未定義かもしれません。").ToString());
		}
		if (node.ArgNum != method.GetParameters().Length)
		{
			throw new AssertionFailedException(new StringBuilder().Append(node.MethodName).Append("の引数の数があっていません(node.ArgNum=").Append((object)node.ArgNum)
				.Append(" method=")
				.Append(method)
				.Append(" GetParameters()=")
				.Append((object)method.GetParameters().Length)
				.ToString());
		}
		object[] array = node.ConstantArguments;
		if (array == null)
		{
			array = popForArguments(node.ArgNum);
		}
		object obj = receiverObject(node.ReceiverIndex);
		string name = method.Name;
		bool flag = true;
		object v = null;
		if (obj is MerlinActionControl)
		{
			try
			{
				MerlinActionControl merlinActionControl = obj as MerlinActionControl;
				switch (name)
				{
				case "SOUND":
					merlinActionControl.SOUND(RuntimeServices.UnboxSingle(array[0]), array[1] as string);
					break;
				case "EFFECT":
				{
					GameObject prefab = array[0] as GameObject;
					float emitTime = RuntimeServices.UnboxSingle(array[1]);
					object obj3 = array[2];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					merlinActionControl.EFFECT(prefab, emitTime, (string)obj3, (ActionCommandEffect.TransformMode)array[3], (ActionCommandEffect.TransformMode)array[4], RuntimeServices.UnboxSingle(array[5]), RuntimeServices.UnboxSingle(array[6]), RuntimeServices.UnboxSingle(array[7]), RuntimeServices.UnboxSingle(array[8]), RuntimeServices.UnboxSingle(array[9]), RuntimeServices.UnboxSingle(array[10]));
					break;
				}
				case "MOVE":
					merlinActionControl.MOVE((ActionDirections)array[0], RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]), RuntimeServices.UnboxSingle(array[3]));
					break;
				case "JUST_DODGE":
					(merlinActionControl as PlayerControl).JUST_DODGE(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]));
					break;
				case "ATTACK":
					merlinActionControl.ATTACK((EnumOrStringValue<AttackPartTypes>)array[0], RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]), RuntimeServices.UnboxBoolean(array[3]), RuntimeServices.UnboxInt32(array[4]), (YarareTypes)array[5], RuntimeServices.UnboxSingle(array[6]));
					break;
				case "ATK_SE":
					merlinActionControl.ATK_SE(array[0] as string);
					break;
				case "ATK_LIMITCOUNT":
					merlinActionControl.ATK_LIMITCOUNT(RuntimeServices.UnboxInt32(array[0]));
					break;
				case "TARGET":
					merlinActionControl.TARGET(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]));
					break;
				case "EFF_ATTACK":
					merlinActionControl.EFF_ATTACK(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxBoolean(array[2]), RuntimeServices.UnboxInt32(array[3]), (YarareTypes)array[4], RuntimeServices.UnboxSingle(array[5]));
					break;
				case "EFF_MOV":
					merlinActionControl.EFF_MOV(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]), RuntimeServices.UnboxSingle(array[3]), RuntimeServices.UnboxSingle(array[4]), RuntimeServices.UnboxSingle(array[5]), RuntimeServices.UnboxSingle(array[6]), RuntimeServices.UnboxSingle(array[7]), RuntimeServices.UnboxSingle(array[8]), RuntimeServices.UnboxSingle(array[9]), RuntimeServices.UnboxBoolean(array[10]));
					break;
				case "EFF_KILLTIME":
					merlinActionControl.EFF_KILLTIME(RuntimeServices.UnboxSingle(array[0]), array[1] as GameObject);
					break;
				case "EFF_COLOR4":
					merlinActionControl.EFF_COLOR4(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]), RuntimeServices.UnboxSingle(array[3]));
					break;
				case "EFF_TIME":
					merlinActionControl.EFF_TIME(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "NEXT":
					merlinActionControl.NEXT((MotionID)array[0]);
					break;
				case "CANCEL":
					merlinActionControl.CANCEL(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "KAIHI":
					(merlinActionControl as PlayerControl).KAIHI(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]));
					break;
				case "ATK_INTERVAL":
					merlinActionControl.ATK_INTERVAL(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "NOUTOU":
					(merlinActionControl as PlayerControl).NOUTOU(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "HITPOINTBAR_GRAY":
					(merlinActionControl as AIControl).HITPOINTBAR_GRAY();
					break;
				case "SHIFT_ATK1":
					merlinActionControl.SHIFT_ATK1((MotionID)array[0], RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]));
					break;
				case "SUPERARMOR":
					merlinActionControl.SUPERARMOR(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]));
					break;
				case "BATTOU":
					(merlinActionControl as PlayerControl).BATTOU(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "ATK_ABST":
					merlinActionControl.ATK_ABST((EnumAbnormalStates)array[0], RuntimeServices.UnboxInt32(array[1]));
					break;
				case "NOHIT":
					merlinActionControl.NOHIT(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]));
					break;
				case "SPEED":
					merlinActionControl.SPEED(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "ATK_NAGE":
				{
					object obj2 = array[0];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					merlinActionControl.ATK_NAGE((string)obj2, RuntimeServices.UnboxSingle(array[1]), (MotionID)array[2], RuntimeServices.UnboxSingle(array[3]), (MotionID)array[4], RuntimeServices.UnboxSingle(array[5]));
					break;
				}
				case "ATK_NAGE_OFS":
					merlinActionControl.ATK_NAGE_OFS(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]), RuntimeServices.UnboxSingle(array[3]), RuntimeServices.UnboxSingle(array[4]), RuntimeServices.UnboxSingle(array[5]));
					break;
				case "ATK_NAGE_KNOCKBACK":
					merlinActionControl.ATK_NAGE_KNOCKBACK(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "ATK_NAGE_SHIFT":
					merlinActionControl.ATK_NAGE_SHIFT((MotionID)array[0], RuntimeServices.UnboxSingle(array[1]));
					break;
				case "MOTMOV_SCALE":
					merlinActionControl.MOTMOV_SCALE(RuntimeServices.UnboxSingle(array[0]), RuntimeServices.UnboxSingle(array[1]), RuntimeServices.UnboxSingle(array[2]));
					break;
				case "ATK_INVSUPARM":
					merlinActionControl.ATK_INVSUPARM();
					break;
				case "EFF_AREA_SNARE":
					merlinActionControl.EFF_AREA_SNARE(RuntimeServices.UnboxSingle(array[0]));
					break;
				case "EFF_DANGLE":
					merlinActionControl.EFF_DANGLE();
					break;
				case "EFF_HOMING_Y":
					merlinActionControl.EFF_HOMING_Y();
					break;
				default:
					flag = false;
					break;
				}
			}
			catch (Exception)
			{
				flag = false;
			}
		}
		else
		{
			flag = false;
		}
		if (!flag)
		{
			v = method.Invoke(obj, (object[])RuntimeServices.GetRange2(array, 0, node.ArgNum));
		}
		if (!node.IsVoid)
		{
			push(v);
		}
	}

	public override void outOpeExtField(D540OpeExtField node)
	{
		object obj = ((node.Target == null) ? null : pop());
		object value = node.Field.GetValue(obj);
		push(value);
	}

	public override void caseOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		object[] constantArguments = node.ConstantArguments;
		if (constantArguments != null)
		{
			if (node.Target != null)
			{
				node.Target.apply(this);
			}
			outOpeInvokeExtMethod(node);
		}
		else
		{
			base.caseOpeInvokeExtMethod(node);
		}
	}

	public override void outOpeInvokeExtMethod(D540OpeInvokeExtMethod node)
	{
		MethodInfo method = node.Method;
		if (method == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(node.DeclaringTypeName).Append(" の ").Append(node.MethodSignature)
				.Append(" メソッドが未解決です。")
				.ToString());
		}
		object[] array = node.ConstantArguments;
		if (array == null)
		{
			array = popForArguments(node.ArgNum);
		}
		object obj = ((node.Target == null) ? null : pop());
		object v = null;
		bool flag = false;
		string name = method.Name;
		if (name == "GetComponent")
		{
			v = ((!(obj is GameObject)) ? (obj as Component).GetComponent(array[0] as string) : (obj as GameObject).GetComponent(array[0] as string));
		}
		else if (name == "set_enabled")
		{
			(obj as MonoBehaviour).enabled = RuntimeServices.UnboxBoolean(array[0]);
		}
		else if (obj is MerlinActionControl)
		{
			MerlinActionControl merlinActionControl = obj as MerlinActionControl;
			switch (name)
			{
			case "get_IS_ANIM_IDLE":
				v = merlinActionControl.IS_ANIM_IDLE;
				break;
			case "get_IS_ANIM_RUN":
				v = merlinActionControl.IS_ANIM_RUN;
				break;
			case "inputRandomAttack":
				v = merlinActionControl.inputRandomAttack();
				break;
			case "inputMoveTo":
				merlinActionControl.inputMoveTo(array[0] as GameObject);
				break;
			case "randRange":
				v = merlinActionControl.randRange(RuntimeServices.UnboxInt32(array[0]), RuntimeServices.UnboxInt32(array[1]));
				break;
			case "get_RAND100":
				v = merlinActionControl.RAND100;
				break;
			case "RARE6_RAND100":
				v = merlinActionControl.RARE6_RAND100(RuntimeServices.UnboxInt32(array[0]), RuntimeServices.UnboxInt32(array[1]), RuntimeServices.UnboxInt32(array[2]), RuntimeServices.UnboxInt32(array[3]), RuntimeServices.UnboxInt32(array[4]), RuntimeServices.UnboxInt32(array[5]));
				break;
			case "RARE3_RAND100":
				v = merlinActionControl.RARE3_RAND100(RuntimeServices.UnboxInt32(array[0]), RuntimeServices.UnboxInt32(array[1]), RuntimeServices.UnboxInt32(array[2]));
				break;
			case "get_ActionParameters":
				v = merlinActionControl.ActionParameters;
				break;
			case "getPoppet":
				v = (obj as PlayerControl).getPoppet(RuntimeServices.UnboxInt32(array[0]));
				break;
			case "get_RAND":
				v = merlinActionControl.RAND;
				break;
			case "get_RARITY":
				v = merlinActionControl.RARITY;
				break;
			case "get_IsBusyToChange":
				v = merlinActionControl.IsBusyToChange;
				break;
			case "get_MOTIONTIME":
				v = merlinActionControl.MOTIONTIME;
				break;
			case "get_VAR":
				v = merlinActionControl.VAR;
				break;
			default:
				if (obj is AIControl)
				{
					if (name == "get_DIST_TARGET")
					{
						v = (obj as AIControl).DIST_TARGET;
					}
					else if (name == "inputAttack")
					{
						(obj as AIControl).inputAttack(RuntimeServices.UnboxInt32(array[0]));
					}
					else
					{
						v = method.Invoke(obj, array);
					}
				}
				else
				{
					v = method.Invoke(obj, array);
				}
				break;
			}
		}
		else if (!(name == "resetNoAttackHit"))
		{
			v = ((!(name == "op_Inequality")) ? method.Invoke(obj, array) : ((object)(!RuntimeServices.EqualityOperator(obj, array[0]))));
		}
		else
		{
			(obj as MerlinActionParameters).resetNoAttackHit();
		}
		if (!node.IsVoid)
		{
			push(v);
		}
	}

	public override void outOpeArrayLiteral(D540OpeArrayLiteral node)
	{
		object[] v = popForArguments(node.ExpressionNum);
		push(v);
	}

	public override void outOpePropertyValue(D540OpePropertyValue node)
	{
		if (node.Property == null)
		{
			throw new AssertionFailedException(new StringBuilder("a property '").Append(node.PropertyName).Append("' had not been resolved").ToString());
		}
		object obj = receiverObject(node.ReceiverIndex);
		push(node.Property.GetValue(obj, null));
	}

	public override void caseOpeField(D540OpeField node)
	{
		if (node.Field == null)
		{
			throw new AssertionFailedException(new StringBuilder("a field '").Append(node.FieldName).Append("' had not been resolved").ToString());
		}
		object obj = receiverObject(node.ReceiverIndex);
		push(node.Field.GetValue(obj));
	}

	public override void outOpeCast(D540OpeCast node)
	{
		if (node.Expression == null)
		{
			throw new AssertionFailedException("an expression is null for cast");
		}
		D540OpeCast.EOpe @operator = node.Operator;
		object value = pop();
		switch (@operator)
		{
		case D540OpeCast.EOpe.IntToSingle:
			push(RuntimeServices.UnboxSingle(value));
			break;
		case D540OpeCast.EOpe.SingleToInt:
			push(RuntimeServices.UnboxInt32(value));
			break;
		case D540OpeCast.EOpe.DoubleToInt:
			push(RuntimeServices.UnboxInt32(value));
			break;
		case D540OpeCast.EOpe.IntToDouble:
			push(RuntimeServices.UnboxDouble(value));
			break;
		case D540OpeCast.EOpe.SingleToDouble:
			push(RuntimeServices.UnboxDouble(value));
			break;
		case D540OpeCast.EOpe.DoubleToSingle:
			push(RuntimeServices.UnboxSingle(value));
			break;
		default:
			throw new Exception(new StringBuilder("unknown D540OpeCast operator: ").Append(@operator).ToString());
		}
	}

	public override void outOpeExprStatement(D540OpeExprStatement node)
	{
		if (node.Expression != null)
		{
			pop();
		}
	}

	public override void outOpeDeclVar(D540OpeDeclVar node)
	{
		string varName = node.VarName;
		if (localVars.ContainsKey(varName))
		{
			push(localVars[varName]);
			return;
		}
		if (node.Initializer == null)
		{
			throw new AssertionFailedException("node.Initializer != null");
		}
		localVars[varName] = pop();
	}

	public override void outOpeAssign(D540OpeAssign node)
	{
		D540OpeAssign.ELeftType leftType = node.LeftType;
		object value = pop();
		switch (leftType)
		{
		case D540OpeAssign.ELeftType.LOCAL:
			localVars[node.LeftVarName] = value;
			break;
		case D540OpeAssign.ELeftType.FIELD:
		{
			FieldInfo field = node.Field;
			object obj = receiverObject(node.ReceiverIndex);
			field.SetValue(obj, value);
			break;
		}
		case D540OpeAssign.ELeftType.PROPERTY:
		{
			PropertyInfo property = node.Property;
			object obj = receiverObject(node.ReceiverIndex);
			property.SetValue(obj, value, null);
			break;
		}
		default:
			throw new Exception(new StringBuilder("unknown lefttype ").Append(leftType).Append(" of OpeAssign").ToString());
		}
	}

	public override void caseOpeAssignExtField(D540OpeAssignExtField node)
	{
		if (node.Target == null)
		{
			throw new AssertionFailedException(new StringBuilder("target of field '").Append(node.FieldName).Append("' is null").ToString());
		}
		if (node.Field == null)
		{
			throw new AssertionFailedException(new StringBuilder("field ").Append(node.FieldName).Append(" was not resolved").ToString());
		}
		object obj = evaluate(node.Target);
		object value = evaluate(node.Expression);
		node.Field.SetValue(obj, value);
	}

	public override void outOpeLocalVar(D540OpeLocalVar node)
	{
		string varName = node.VarName;
		if (localVars.ContainsKey(varName))
		{
			push(localVars[varName]);
			return;
		}
		throw new Exception(new StringBuilder("undefined local variable named '").Append(varName).Append("'").ToString());
	}

	public override void caseOpeBuiltinFunc(D540OpeBuiltinFunc node)
	{
		if (node.Type == null)
		{
			throw new AssertionFailedException("BuiltinFunc type is null");
		}
		push(Activator.CreateInstance(node.Type));
	}

	public override void caseOpeMotionID(D540OpeMotionID node)
	{
		push(node.MotionID);
	}

	public override void caseOpeEnumOrString(D540OpeEnumOrString node)
	{
		push(node.Value);
	}
}
