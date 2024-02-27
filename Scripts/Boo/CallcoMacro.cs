using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class CallcoMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424281 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002498_002424282;

			internal MacroStatement _0024_0024match_002499_002424283;

			internal Expression _0024expression_002424284;

			internal ReferenceExpression _0024t1_002424285;

			internal BinaryExpression _0024_00246443_002424286;

			internal BinaryExpression _0024_00246444_002424287;

			internal MacroStatement _0024_00246445_002424288;

			internal Block _0024_00246446_002424289;

			internal IfStatement _0024_00246447_002424290;

			internal Block _0024_00246448_002424291;

			internal MacroStatement _0024callco_002424292;

			internal CallcoMacro _0024self__002424293;

			public _0024(MacroStatement callco, CallcoMacro self_)
			{
				_0024callco_002424292 = callco;
				_0024self__002424293 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024callco_002424292 == null)
					{
						throw new ArgumentNullException("callco");
					}
					_0024self__002424293.__macro = _0024callco_002424292;
					_0024_0024match_002498_002424282 = _0024callco_002424292;
					if (_0024_0024match_002498_002424282 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002499_002424283 = _0024_0024match_002498_002424282);
						if (true && _0024_0024match_002499_002424283.Name == "callco" && 1 == ((ICollection)_0024_0024match_002499_002424283.Arguments).Count && _0024_0024match_002499_002424283.Arguments[0] is Expression)
						{
							Expression expression = (_0024expression_002424284 = _0024_0024match_002499_002424283.Arguments[0]);
							if (true)
							{
								_0024t1_002424285 = new ReferenceExpression(_0024self__002424293.Context.GetUniqueName("macro", "callco"));
								Block block = (_0024_00246448_002424291 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00246448_002424291;
								Statement[] array = new Statement[2];
								BinaryExpression binaryExpression = (_0024_00246443_002424286 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246443_002424286.Operator = BinaryOperatorType.Assign);
								Expression expression3 = (_0024_00246443_002424286.Left = Expression.Lift(_0024t1_002424285));
								Expression expression5 = (_0024_00246443_002424286.Right = Expression.Lift(_0024expression_002424284));
								array[0] = Statement.Lift(_0024_00246443_002424286);
								IfStatement ifStatement = (_0024_00246447_002424290 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement2 = _0024_00246447_002424290;
								BinaryExpression binaryExpression2 = (_0024_00246444_002424287 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType4 = (_0024_00246444_002424287.Operator = BinaryOperatorType.Inequality);
								Expression expression7 = (_0024_00246444_002424287.Left = Expression.Lift(_0024t1_002424285));
								Expression expression9 = (_0024_00246444_002424287.Right = new NullLiteralExpression(LexicalInfo.Empty));
								Expression expression11 = (ifStatement2.Condition = _0024_00246444_002424287);
								IfStatement ifStatement3 = _0024_00246447_002424290;
								Block block3 = (_0024_00246446_002424289 = new Block(LexicalInfo.Empty));
								Block block4 = _0024_00246446_002424289;
								Statement[] array2 = new Statement[1];
								MacroStatement macroStatement2 = (_0024_00246445_002424288 = new MacroStatement(LexicalInfo.Empty));
								string text2 = (_0024_00246445_002424288.Name = "yieldAll");
								ExpressionCollection expressionCollection2 = (_0024_00246445_002424288.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024t1_002424285)));
								Block block6 = (_0024_00246445_002424288.Body = new Block(LexicalInfo.Empty));
								array2[0] = Statement.Lift(_0024_00246445_002424288);
								StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
								Block block8 = (ifStatement3.TrueBlock = _0024_00246446_002424289);
								array[1] = Statement.Lift(_0024_00246447_002424290);
								StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
								result = (Yield(2, _0024_00246448_002424291) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`callco` macro invocation argument(s) did not match definition: `callco(expression)`");
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024callco_002424294;

		internal CallcoMacro _0024self__002424295;

		public _0024ExpandGeneratorImpl_002424281(MacroStatement callco, CallcoMacro self_)
		{
			_0024callco_002424294 = callco;
			_0024self__002424295 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024callco_002424294, _0024self__002424295);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public CallcoMacro()
	{
	}

	public CallcoMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement callco)
	{
		return new _0024ExpandGeneratorImpl_002424281(callco, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement callco)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'callco' is using. Read BOO-1077 for more info.");
	}
}
