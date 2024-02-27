using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class RepeatMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424248 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002494_002424249;

			internal MacroStatement _0024_0024match_002495_002424250;

			internal BinaryExpression _0024_0024match_002496_002424251;

			internal ReferenceExpression _0024_0024match_002497_002424252;

			internal string _0024lvar_002424253;

			internal Expression _0024expr_002424254;

			internal ReferenceExpression _0024t1_002424255;

			internal ReferenceExpression _0024t2_002424256;

			internal IntegerLiteralExpression _0024_00246424_002424257;

			internal BinaryExpression _0024_00246425_002424258;

			internal BinaryExpression _0024_00246426_002424259;

			internal BinaryExpression _0024_00246427_002424260;

			internal UnaryExpression _0024_00246428_002424261;

			internal Block _0024_00246429_002424262;

			internal WhileStatement _0024_00246430_002424263;

			internal Block _0024_00246431_002424264;

			internal Block _0024b_002424265;

			internal IntegerLiteralExpression _0024_00246432_002424266;

			internal BinaryExpression _0024_00246433_002424267;

			internal BoolLiteralExpression _0024_00246434_002424268;

			internal UnaryExpression _0024_00246435_002424269;

			internal IntegerLiteralExpression _0024_00246436_002424270;

			internal BinaryExpression _0024_00246437_002424271;

			internal StringLiteralExpression _0024_00246438_002424272;

			internal MacroStatement _0024_00246439_002424273;

			internal Block _0024_00246440_002424274;

			internal WhileStatement _0024_00246441_002424275;

			internal Block _0024_00246442_002424276;

			internal MacroStatement _0024repeat_002424277;

			internal RepeatMacro _0024self__002424278;

			public _0024(MacroStatement repeat, RepeatMacro self_)
			{
				_0024repeat_002424277 = repeat;
				_0024self__002424278 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024repeat_002424277 == null)
					{
						throw new ArgumentNullException("repeat");
					}
					_0024self__002424278.__macro = _0024repeat_002424277;
					_0024_0024match_002494_002424249 = _0024repeat_002424277;
					if (_0024_0024match_002494_002424249 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002495_002424250 = _0024_0024match_002494_002424249);
						if (true && _0024_0024match_002495_002424250.Name == "repeat" && 1 == ((ICollection)_0024_0024match_002495_002424250.Arguments).Count && _0024_0024match_002495_002424250.Arguments[0] is BinaryExpression)
						{
							BinaryExpression binaryExpression = (_0024_0024match_002496_002424251 = (BinaryExpression)_0024_0024match_002495_002424250.Arguments[0]);
							if (true && _0024_0024match_002496_002424251.Operator == BinaryOperatorType.Assign && _0024_0024match_002496_002424251.Left is ReferenceExpression)
							{
								ReferenceExpression referenceExpression = (_0024_0024match_002497_002424252 = (ReferenceExpression)_0024_0024match_002496_002424251.Left);
								if (true)
								{
									string text = (_0024lvar_002424253 = _0024_0024match_002497_002424252.Name);
									if (true)
									{
										Expression expression = (_0024expr_002424254 = _0024_0024match_002496_002424251.Right);
										if (true)
										{
											_0024t1_002424255 = new ReferenceExpression(_0024lvar_002424253);
											_0024t2_002424256 = new ReferenceExpression(_0024self__002424278.Context.GetUniqueName("macro", "repeat"));
											Block block = (_0024_00246431_002424264 = new Block(LexicalInfo.Empty));
											Block block2 = _0024_00246431_002424264;
											Statement[] array = new Statement[3];
											BinaryExpression binaryExpression2 = (_0024_00246425_002424258 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType2 = (_0024_00246425_002424258.Operator = BinaryOperatorType.Assign);
											Expression expression3 = (_0024_00246425_002424258.Left = Expression.Lift(_0024t1_002424255));
											BinaryExpression binaryExpression3 = _0024_00246425_002424258;
											IntegerLiteralExpression integerLiteralExpression = (_0024_00246424_002424257 = new IntegerLiteralExpression(LexicalInfo.Empty));
											long num2 = (_0024_00246424_002424257.Value = 0L);
											bool flag2 = (_0024_00246424_002424257.IsLong = false);
											Expression expression5 = (binaryExpression3.Right = _0024_00246424_002424257);
											array[0] = Statement.Lift(_0024_00246425_002424258);
											BinaryExpression binaryExpression4 = (_0024_00246426_002424259 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType4 = (_0024_00246426_002424259.Operator = BinaryOperatorType.Assign);
											Expression expression7 = (_0024_00246426_002424259.Left = Expression.Lift(_0024t2_002424256));
											Expression expression9 = (_0024_00246426_002424259.Right = Expression.Lift(_0024expr_002424254));
											array[1] = Statement.Lift(_0024_00246426_002424259);
											WhileStatement whileStatement = (_0024_00246430_002424263 = new WhileStatement(LexicalInfo.Empty));
											WhileStatement whileStatement2 = _0024_00246430_002424263;
											BinaryExpression binaryExpression5 = (_0024_00246427_002424260 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType6 = (_0024_00246427_002424260.Operator = BinaryOperatorType.LessThan);
											Expression expression11 = (_0024_00246427_002424260.Left = Expression.Lift(_0024t1_002424255));
											Expression expression13 = (_0024_00246427_002424260.Right = Expression.Lift(_0024t2_002424256));
											Expression expression15 = (whileStatement2.Condition = _0024_00246427_002424260);
											WhileStatement whileStatement3 = _0024_00246430_002424263;
											Block block3 = (_0024_00246429_002424262 = new Block(LexicalInfo.Empty));
											Block block4 = _0024_00246429_002424262;
											Statement[] obj = new Statement[2]
											{
												Statement.Lift(Statement.Lift(_0024repeat_002424277.Body)),
												null
											};
											UnaryExpression unaryExpression = (_0024_00246428_002424261 = new UnaryExpression(LexicalInfo.Empty));
											UnaryOperatorType unaryOperatorType2 = (_0024_00246428_002424261.Operator = UnaryOperatorType.Increment);
											Expression expression17 = (_0024_00246428_002424261.Operand = Expression.Lift(_0024t1_002424255));
											obj[1] = Statement.Lift(_0024_00246428_002424261);
											StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(obj));
											Block block6 = (whileStatement3.Block = _0024_00246429_002424262);
											array[2] = Statement.Lift(_0024_00246430_002424263);
											StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
											_0024b_002424265 = _0024_00246431_002424264;
											_0024b_002424265.LexicalInfo = _0024repeat_002424277.LexicalInfo;
											result = (Yield(2, _0024b_002424265) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
					}
					_0024t1_002424255 = new ReferenceExpression(_0024self__002424278.Context.GetUniqueName("macro", "repeat"));
					Block block7 = (_0024_00246442_002424276 = new Block(LexicalInfo.Empty));
					Block block8 = _0024_00246442_002424276;
					Statement[] array2 = new Statement[2];
					BinaryExpression binaryExpression6 = (_0024_00246433_002424267 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00246433_002424267.Operator = BinaryOperatorType.Assign);
					Expression expression19 = (_0024_00246433_002424267.Left = Expression.Lift(_0024t1_002424255));
					BinaryExpression binaryExpression7 = _0024_00246433_002424267;
					IntegerLiteralExpression integerLiteralExpression2 = (_0024_00246432_002424266 = new IntegerLiteralExpression(LexicalInfo.Empty));
					long num4 = (_0024_00246432_002424266.Value = 0L);
					bool flag4 = (_0024_00246432_002424266.IsLong = false);
					Expression expression21 = (binaryExpression7.Right = _0024_00246432_002424266);
					array2[0] = Statement.Lift(_0024_00246433_002424267);
					WhileStatement whileStatement4 = (_0024_00246441_002424275 = new WhileStatement(LexicalInfo.Empty));
					WhileStatement whileStatement5 = _0024_00246441_002424275;
					BoolLiteralExpression boolLiteralExpression = (_0024_00246434_002424268 = new BoolLiteralExpression(LexicalInfo.Empty));
					bool flag6 = (_0024_00246434_002424268.Value = true);
					Expression expression23 = (whileStatement5.Condition = _0024_00246434_002424268);
					WhileStatement whileStatement6 = _0024_00246441_002424275;
					Block block9 = (_0024_00246440_002424274 = new Block(LexicalInfo.Empty));
					Block block10 = _0024_00246440_002424274;
					Statement[] obj2 = new Statement[2]
					{
						Statement.Lift(Statement.Lift(_0024repeat_002424277.Body)),
						null
					};
					MacroStatement macroStatement2 = (_0024_00246439_002424273 = new MacroStatement(LexicalInfo.Empty));
					string text3 = (_0024_00246439_002424273.Name = "assert");
					MacroStatement macroStatement3 = _0024_00246439_002424273;
					Expression[] array3 = new Expression[2];
					BinaryExpression binaryExpression8 = (_0024_00246437_002424271 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00246437_002424271.Operator = BinaryOperatorType.LessThan);
					BinaryExpression binaryExpression9 = _0024_00246437_002424271;
					UnaryExpression unaryExpression2 = (_0024_00246435_002424269 = new UnaryExpression(LexicalInfo.Empty));
					UnaryOperatorType unaryOperatorType4 = (_0024_00246435_002424269.Operator = UnaryOperatorType.Increment);
					Expression expression25 = (_0024_00246435_002424269.Operand = Expression.Lift(_0024t1_002424255));
					Expression expression27 = (binaryExpression9.Left = _0024_00246435_002424269);
					BinaryExpression binaryExpression10 = _0024_00246437_002424271;
					IntegerLiteralExpression integerLiteralExpression3 = (_0024_00246436_002424270 = new IntegerLiteralExpression(LexicalInfo.Empty));
					long num6 = (_0024_00246436_002424270.Value = 100000L);
					bool flag8 = (_0024_00246436_002424270.IsLong = false);
					Expression expression29 = (binaryExpression10.Right = _0024_00246436_002424270);
					array3[0] = _0024_00246437_002424271;
					StringLiteralExpression stringLiteralExpression = (_0024_00246438_002424272 = new StringLiteralExpression(LexicalInfo.Empty));
					string text5 = (_0024_00246438_002424272.Value = "無限ループじゃね？");
					array3[1] = _0024_00246438_002424272;
					ExpressionCollection expressionCollection2 = (macroStatement3.Arguments = ExpressionCollection.FromArray(array3));
					Block block12 = (_0024_00246439_002424273.Body = new Block(LexicalInfo.Empty));
					obj2[1] = Statement.Lift(_0024_00246439_002424273);
					StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(obj2));
					Block block14 = (whileStatement6.Block = _0024_00246440_002424274);
					array2[1] = Statement.Lift(_0024_00246441_002424275);
					StatementCollection statementCollection8 = (block8.Statements = StatementCollection.FromArray(array2));
					_0024b_002424265 = _0024_00246442_002424276;
					_0024b_002424265.LexicalInfo = _0024repeat_002424277.LexicalInfo;
					result = (Yield(3, _0024b_002424265) ? 1 : 0);
					break;
				}
				case 2:
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024repeat_002424279;

		internal RepeatMacro _0024self__002424280;

		public _0024ExpandGeneratorImpl_002424248(MacroStatement repeat, RepeatMacro self_)
		{
			_0024repeat_002424279 = repeat;
			_0024self__002424280 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024repeat_002424279, _0024self__002424280);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public RepeatMacro()
	{
	}

	public RepeatMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement repeat)
	{
		return new _0024ExpandGeneratorImpl_002424248(repeat, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement repeat)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'repeat' is using. Read BOO-1077 for more info.");
	}
}
