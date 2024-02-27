using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class Hud_methodMacro : HudMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424115 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MethodInvocationExpression _0024mdef_002424116;

			internal TypeMember _0024___item_002424117;

			internal string _0024smname_002424118;

			internal ExpressionCollection _0024fmls_002424119;

			internal string _0024imname_002424120;

			internal MethodInvocationExpression _0024iminv_002424121;

			internal Method _0024smdef_002424122;

			internal ReferenceExpression _0024_00246334_002424123;

			internal MemberReferenceExpression _0024_00246335_002424124;

			internal IntegerLiteralExpression _0024_00246336_002424125;

			internal BinaryExpression _0024_00246337_002424126;

			internal StringLiteralExpression _0024_00246338_002424127;

			internal BinaryExpression _0024_00246339_002424128;

			internal StringLiteralExpression _0024_00246340_002424129;

			internal BinaryExpression _0024_00246341_002424130;

			internal ReferenceExpression _0024_00246342_002424131;

			internal MemberReferenceExpression _0024_00246343_002424132;

			internal BinaryExpression _0024_00246344_002424133;

			internal StringLiteralExpression _0024_00246345_002424134;

			internal BinaryExpression _0024_00246346_002424135;

			internal BinaryExpression _0024_00246347_002424136;

			internal StringLiteralExpression _0024_00246348_002424137;

			internal BinaryExpression _0024_00246349_002424138;

			internal MacroStatement _0024_00246350_002424139;

			internal Block _0024_00246351_002424140;

			internal IfStatement _0024_00246352_002424141;

			internal IfStatement _0024warnstmt_002424142;

			internal Declaration _0024_00246353_002424143;

			internal ReferenceExpression _0024_00246354_002424144;

			internal Block _0024_00246355_002424145;

			internal ForStatement _0024_00246356_002424146;

			internal ForStatement _0024invokestmt_002424147;

			internal Method _0024imdef_002424148;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414234_002424149;

			internal MacroStatement _0024mc_002424150;

			internal Hud_methodMacro _0024self__002424151;

			public _0024(MacroStatement mc, Hud_methodMacro self_)
			{
				_0024mc_002424150 = mc;
				_0024self__002424151 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (((ICollection)_0024mc_002424150.Arguments).Count != 1)
						{
							throw new AssertionFailedException("len(mc.Arguments) == 1");
						}
						_0024mdef_002424116 = _0024mc_002424150.Arguments[0] as MethodInvocationExpression;
						if (_0024mdef_002424116 == null)
						{
							throw new AssertionFailedException("mdef != null");
						}
						_0024_0024iterator_002414234_002424149 = _0024self__002424151.InstanceManagingCode(_0024mdef_002424116).GetEnumerator();
						_state = 2;
						goto case 3;
					case 3:
						if (_0024_0024iterator_002414234_002424149.MoveNext())
						{
							_0024___item_002424117 = _0024_0024iterator_002414234_002424149.Current;
							flag = Yield(3, _0024___item_002424117);
						}
						else
						{
							_state = 1;
							_0024ensure2();
							_0024smname_002424118 = (_0024mdef_002424116.Target as ReferenceExpression).Name;
							_0024fmls_002424119 = _0024mdef_002424116.Arguments;
							_0024imname_002424120 = "__" + _0024smname_002424118;
							_0024iminv_002424121 = new MethodInvocationExpression();
							_0024iminv_002424121.Target = ReferenceExpression.Lift(new StringBuilder("ins.").Append(_0024imname_002424120).ToString());
							_0024iminv_002424121.Arguments = FormalToArgs(_0024fmls_002424119);
							_0024smdef_002424122 = new Method(_0024smname_002424118);
							_0024smdef_002424122.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static;
							_0024smdef_002424122.Parameters = ExpressionsToParameters(_0024fmls_002424119);
							if (false)
							{
								IfStatement ifStatement = (_0024_00246352_002424141 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement2 = _0024_00246352_002424141;
								BinaryExpression binaryExpression = (_0024_00246337_002424126 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246337_002424126.Operator = BinaryOperatorType.Inequality);
								BinaryExpression binaryExpression2 = _0024_00246337_002424126;
								MemberReferenceExpression memberReferenceExpression = (_0024_00246335_002424124 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text2 = (_0024_00246335_002424124.Name = "Count");
								MemberReferenceExpression memberReferenceExpression2 = _0024_00246335_002424124;
								ReferenceExpression referenceExpression = (_0024_00246334_002424123 = new ReferenceExpression(LexicalInfo.Empty));
								string text4 = (_0024_00246334_002424123.Name = "_InstanceList");
								Expression expression2 = (memberReferenceExpression2.Target = _0024_00246334_002424123);
								Expression expression4 = (binaryExpression2.Left = _0024_00246335_002424124);
								BinaryExpression binaryExpression3 = _0024_00246337_002424126;
								IntegerLiteralExpression integerLiteralExpression = (_0024_00246336_002424125 = new IntegerLiteralExpression(LexicalInfo.Empty));
								long num2 = (_0024_00246336_002424125.Value = 1L);
								bool flag3 = (_0024_00246336_002424125.IsLong = false);
								Expression expression6 = (binaryExpression3.Right = _0024_00246336_002424125);
								Expression expression8 = (ifStatement2.Condition = _0024_00246337_002424126);
								IfStatement ifStatement3 = _0024_00246352_002424141;
								Block block = (_0024_00246351_002424140 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00246351_002424140;
								Statement[] array = new Statement[1];
								MacroStatement macroStatement = (_0024_00246350_002424139 = new MacroStatement(LexicalInfo.Empty));
								string text6 = (_0024_00246350_002424139.Name = "logwarn");
								MacroStatement macroStatement2 = _0024_00246350_002424139;
								Expression[] array2 = new Expression[1];
								BinaryExpression binaryExpression4 = (_0024_00246349_002424138 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType4 = (_0024_00246349_002424138.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression5 = _0024_00246349_002424138;
								BinaryExpression binaryExpression6 = (_0024_00246347_002424136 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType6 = (_0024_00246347_002424136.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression7 = _0024_00246347_002424136;
								BinaryExpression binaryExpression8 = (_0024_00246346_002424135 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType8 = (_0024_00246346_002424135.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression9 = _0024_00246346_002424135;
								BinaryExpression binaryExpression10 = (_0024_00246344_002424133 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType10 = (_0024_00246344_002424133.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression11 = _0024_00246344_002424133;
								BinaryExpression binaryExpression12 = (_0024_00246341_002424130 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType12 = (_0024_00246341_002424130.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression13 = _0024_00246341_002424130;
								BinaryExpression binaryExpression14 = (_0024_00246339_002424128 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType14 = (_0024_00246339_002424128.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression15 = _0024_00246339_002424128;
								StringLiteralExpression stringLiteralExpression = (_0024_00246338_002424127 = new StringLiteralExpression(LexicalInfo.Empty));
								string text8 = (_0024_00246338_002424127.Value = "HUDM4:");
								Expression expression10 = (binaryExpression15.Left = _0024_00246338_002424127);
								Expression expression12 = (_0024_00246339_002424128.Right = Expression.Lift(_0024self__002424151.parentClass.Name));
								Expression expression14 = (binaryExpression13.Left = _0024_00246339_002424128);
								BinaryExpression binaryExpression16 = _0024_00246341_002424130;
								StringLiteralExpression stringLiteralExpression2 = (_0024_00246340_002424129 = new StringLiteralExpression(LexicalInfo.Empty));
								string text10 = (_0024_00246340_002424129.Value = "が");
								Expression expression16 = (binaryExpression16.Right = _0024_00246340_002424129);
								Expression expression18 = (binaryExpression11.Left = _0024_00246341_002424130);
								BinaryExpression binaryExpression17 = _0024_00246344_002424133;
								MemberReferenceExpression memberReferenceExpression3 = (_0024_00246343_002424132 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text12 = (_0024_00246343_002424132.Name = "Count");
								MemberReferenceExpression memberReferenceExpression4 = _0024_00246343_002424132;
								ReferenceExpression referenceExpression2 = (_0024_00246342_002424131 = new ReferenceExpression(LexicalInfo.Empty));
								string text14 = (_0024_00246342_002424131.Name = "_InstanceList");
								Expression expression20 = (memberReferenceExpression4.Target = _0024_00246342_002424131);
								Expression expression22 = (binaryExpression17.Right = _0024_00246343_002424132);
								Expression expression24 = (binaryExpression9.Left = _0024_00246344_002424133);
								BinaryExpression binaryExpression18 = _0024_00246346_002424135;
								StringLiteralExpression stringLiteralExpression3 = (_0024_00246345_002424134 = new StringLiteralExpression(LexicalInfo.Empty));
								string text16 = (_0024_00246345_002424134.Value = "個ある(1個でない)！ -- ");
								Expression expression26 = (binaryExpression18.Right = _0024_00246345_002424134);
								Expression expression28 = (binaryExpression7.Left = _0024_00246346_002424135);
								Expression expression30 = (_0024_00246347_002424136.Right = Expression.Lift(_0024smname_002424118));
								Expression expression32 = (binaryExpression5.Left = _0024_00246347_002424136);
								BinaryExpression binaryExpression19 = _0024_00246349_002424138;
								StringLiteralExpression stringLiteralExpression4 = (_0024_00246348_002424137 = new StringLiteralExpression(LexicalInfo.Empty));
								string text18 = (_0024_00246348_002424137.Value = "メソッド起動時");
								Expression expression34 = (binaryExpression19.Right = _0024_00246348_002424137);
								array2[0] = _0024_00246349_002424138;
								ExpressionCollection expressionCollection2 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array2));
								Block block4 = (_0024_00246350_002424139.Body = new Block(LexicalInfo.Empty));
								array[0] = Statement.Lift(_0024_00246350_002424139);
								StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
								Block block6 = (ifStatement3.TrueBlock = _0024_00246351_002424140);
								_0024warnstmt_002424142 = _0024_00246352_002424141;
								_0024smdef_002424122.Body.Add(_0024warnstmt_002424142);
							}
							ForStatement forStatement = (_0024_00246356_002424146 = new ForStatement(LexicalInfo.Empty));
							ForStatement forStatement2 = _0024_00246356_002424146;
							Declaration[] array3 = new Declaration[1];
							Declaration declaration = (_0024_00246353_002424143 = new Declaration(LexicalInfo.Empty));
							string text20 = (_0024_00246353_002424143.Name = "ins");
							array3[0] = _0024_00246353_002424143;
							DeclarationCollection declarationCollection2 = (forStatement2.Declarations = DeclarationCollection.FromArray(array3));
							ForStatement forStatement3 = _0024_00246356_002424146;
							ReferenceExpression referenceExpression3 = (_0024_00246354_002424144 = new ReferenceExpression(LexicalInfo.Empty));
							string text22 = (_0024_00246354_002424144.Name = "_InstanceList");
							Expression expression36 = (forStatement3.Iterator = _0024_00246354_002424144);
							ForStatement forStatement4 = _0024_00246356_002424146;
							Block block7 = (_0024_00246355_002424145 = new Block(LexicalInfo.Empty));
							StatementCollection statementCollection4 = (_0024_00246355_002424145.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024iminv_002424121))));
							Block block9 = (forStatement4.Block = _0024_00246355_002424145);
							_0024invokestmt_002424147 = _0024_00246356_002424146;
							_0024smdef_002424122.Body.Add(_0024invokestmt_002424147);
							flag = Yield(4, _0024smdef_002424122);
						}
						goto IL_0898;
					case 4:
						_0024imdef_002424148 = new Method(_0024imname_002424120);
						_0024imdef_002424148.Modifiers = TypeMemberModifiers.Protected;
						_0024imdef_002424148.Parameters = ExpressionsToParameters(_0024fmls_002424119);
						_0024imdef_002424148.Body = _0024mc_002424150.Body;
						flag = Yield(5, _0024imdef_002424148);
						goto IL_0898;
					case 5:
						YieldDefault(1);
						break;
					case 1:
					case 2:
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0899;
				IL_0899:
				return (byte)result != 0;
				IL_0898:
				result = (flag ? 1 : 0);
				goto IL_0899;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414234_002424149.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal MacroStatement _0024mc_002424152;

		internal Hud_methodMacro _0024self__002424153;

		public _0024ExpandGeneratorImpl_002424115(MacroStatement mc, Hud_methodMacro self_)
		{
			_0024mc_002424152 = mc;
			_0024self__002424153 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424152, _0024self__002424153);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424115(mc, this);
	}

	public static ExpressionCollection FormalToArgs(ExpressionCollection fmls)
	{
		ExpressionCollection expressionCollection = new ExpressionCollection();
		IEnumerator<Expression> enumerator = fmls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Expression current = enumerator.Current;
				Expression expression = current;
				if (expression is TryCastExpression)
				{
					TryCastExpression tryCastExpression = (TryCastExpression)expression;
					if (true)
					{
						Expression target = tryCastExpression.Target;
						if (true)
						{
							object obj = target.Clone();
							if (!(obj is Expression))
							{
								obj = RuntimeServices.Coerce(obj, typeof(Expression));
							}
							expressionCollection.Add((Expression)obj);
							continue;
						}
					}
				}
				object obj2 = current.Clone();
				if (!(obj2 is Expression))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Expression));
				}
				expressionCollection.Add((Expression)obj2);
			}
			return expressionCollection;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static ParameterDeclarationCollection ExpressionsToParameters(ExpressionCollection fmls)
	{
		ParameterDeclarationCollection parameterDeclarationCollection = new ParameterDeclarationCollection();
		IEnumerator<Expression> enumerator = fmls.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Expression current = enumerator.Current;
				Expression expression = current;
				if (expression is TryCastExpression)
				{
					TryCastExpression tryCastExpression = (TryCastExpression)expression;
					if (true)
					{
						Expression target = tryCastExpression.Target;
						if (true)
						{
							TypeReference type = tryCastExpression.Type;
							if (true)
							{
								parameterDeclarationCollection.Add(new ParameterDeclaration(target.ToCodeString(), type));
								continue;
							}
						}
					}
				}
				parameterDeclarationCollection.Add(new ParameterDeclaration(current.ToCodeString(), null));
			}
			return parameterDeclarationCollection;
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
