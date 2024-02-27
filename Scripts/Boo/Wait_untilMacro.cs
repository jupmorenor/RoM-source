using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Wait_untilMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424177 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002483_002424178;

			internal MacroStatement _0024_0024match_002484_002424179;

			internal Expression _0024condition_002424180;

			internal UnaryExpression _0024_00246400_002424181;

			internal Block _0024_00246401_002424182;

			internal WhileStatement _0024_00246402_002424183;

			internal MacroStatement _0024_0024match_002485_002424184;

			internal Expression _0024timeout_002424185;

			internal ReferenceExpression _0024t1_002424186;

			internal ReferenceExpression _0024t2_002424187;

			internal SimpleTypeReference _0024_00246403_002424188;

			internal CastExpression _0024_00246404_002424189;

			internal BinaryExpression _0024_00246405_002424190;

			internal ReferenceExpression _0024_00246406_002424191;

			internal MemberReferenceExpression _0024_00246407_002424192;

			internal BinaryExpression _0024_00246408_002424193;

			internal UnaryExpression _0024_00246409_002424194;

			internal ReferenceExpression _0024_00246410_002424195;

			internal MemberReferenceExpression _0024_00246411_002424196;

			internal BinaryExpression _0024_00246412_002424197;

			internal BinaryExpression _0024_00246413_002424198;

			internal BinaryExpression _0024_00246414_002424199;

			internal Block _0024_00246415_002424200;

			internal WhileStatement _0024_00246416_002424201;

			internal Block _0024_00246417_002424202;

			internal MacroStatement _0024wait_until_002424203;

			internal Wait_untilMacro _0024self__002424204;

			public _0024(MacroStatement wait_until, Wait_untilMacro self_)
			{
				_0024wait_until_002424203 = wait_until;
				_0024self__002424204 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024wait_until_002424203 == null)
					{
						throw new ArgumentNullException("wait_until");
					}
					_0024self__002424204.__macro = _0024wait_until_002424203;
					_0024_0024match_002483_002424178 = _0024wait_until_002424203;
					if (_0024_0024match_002483_002424178 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002484_002424179 = _0024_0024match_002483_002424178);
						if (true && _0024_0024match_002484_002424179.Name == "wait_until" && 1 == ((ICollection)_0024_0024match_002484_002424179.Arguments).Count)
						{
							Expression expression = (_0024condition_002424180 = _0024_0024match_002484_002424179.Arguments[0]);
							if (true)
							{
								WhileStatement whileStatement = (_0024_00246402_002424183 = new WhileStatement(LexicalInfo.Empty));
								WhileStatement whileStatement2 = _0024_00246402_002424183;
								UnaryExpression unaryExpression = (_0024_00246400_002424181 = new UnaryExpression(LexicalInfo.Empty));
								UnaryOperatorType unaryOperatorType2 = (_0024_00246400_002424181.Operator = UnaryOperatorType.LogicalNot);
								Expression expression3 = (_0024_00246400_002424181.Operand = Expression.Lift(_0024condition_002424180));
								Expression expression5 = (whileStatement2.Condition = _0024_00246400_002424181);
								WhileStatement whileStatement3 = _0024_00246402_002424183;
								Block block = (_0024_00246401_002424182 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection2 = (_0024_00246401_002424182.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024wait_until_002424203.Body)), Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
								Block block3 = (whileStatement3.Block = _0024_00246401_002424182);
								result = (Yield(2, _0024_00246402_002424183) ? 1 : 0);
								break;
							}
						}
					}
					if (_0024_0024match_002483_002424178 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002485_002424184 = _0024_0024match_002483_002424178);
						if (true && _0024_0024match_002485_002424184.Name == "wait_until" && 2 == ((ICollection)_0024_0024match_002485_002424184.Arguments).Count)
						{
							Expression expression6 = (_0024condition_002424180 = _0024_0024match_002485_002424184.Arguments[0]);
							if (true)
							{
								Expression expression7 = (_0024timeout_002424185 = _0024_0024match_002485_002424184.Arguments[1]);
								if (true)
								{
									_0024t1_002424186 = new ReferenceExpression(_0024self__002424204.Context.GetUniqueName("wait_until", "temp"));
									_0024t2_002424187 = new ReferenceExpression(_0024self__002424204.Context.GetUniqueName("wait_until", "temp"));
									Block block4 = (_0024_00246417_002424202 = new Block(LexicalInfo.Empty));
									Block block5 = _0024_00246417_002424202;
									Statement[] array = new Statement[3];
									BinaryExpression binaryExpression = (_0024_00246405_002424190 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00246405_002424190.Operator = BinaryOperatorType.Assign);
									Expression expression9 = (_0024_00246405_002424190.Left = Expression.Lift(_0024t1_002424186));
									BinaryExpression binaryExpression2 = _0024_00246405_002424190;
									CastExpression castExpression = (_0024_00246404_002424189 = new CastExpression(LexicalInfo.Empty));
									Expression expression11 = (_0024_00246404_002424189.Target = Expression.Lift(_0024timeout_002424185));
									CastExpression castExpression2 = _0024_00246404_002424189;
									SimpleTypeReference simpleTypeReference = (_0024_00246403_002424188 = new SimpleTypeReference(LexicalInfo.Empty));
									bool flag2 = (_0024_00246403_002424188.IsPointer = false);
									string text2 = (_0024_00246403_002424188.Name = "single");
									TypeReference typeReference2 = (castExpression2.Type = _0024_00246403_002424188);
									Expression expression13 = (binaryExpression2.Right = _0024_00246404_002424189);
									array[0] = Statement.Lift(_0024_00246405_002424190);
									BinaryExpression binaryExpression3 = (_0024_00246408_002424193 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00246408_002424193.Operator = BinaryOperatorType.Assign);
									Expression expression15 = (_0024_00246408_002424193.Left = Expression.Lift(_0024t2_002424187));
									BinaryExpression binaryExpression4 = _0024_00246408_002424193;
									MemberReferenceExpression memberReferenceExpression = (_0024_00246407_002424192 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00246407_002424192.Name = "realtimeSinceStartup");
									MemberReferenceExpression memberReferenceExpression2 = _0024_00246407_002424192;
									ReferenceExpression referenceExpression = (_0024_00246406_002424191 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00246406_002424191.Name = "Time");
									Expression expression17 = (memberReferenceExpression2.Target = _0024_00246406_002424191);
									Expression expression19 = (binaryExpression4.Right = _0024_00246407_002424192);
									array[1] = Statement.Lift(_0024_00246408_002424193);
									WhileStatement whileStatement4 = (_0024_00246416_002424201 = new WhileStatement(LexicalInfo.Empty));
									WhileStatement whileStatement5 = _0024_00246416_002424201;
									BinaryExpression binaryExpression5 = (_0024_00246414_002424199 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType6 = (_0024_00246414_002424199.Operator = BinaryOperatorType.And);
									BinaryExpression binaryExpression6 = _0024_00246414_002424199;
									UnaryExpression unaryExpression2 = (_0024_00246409_002424194 = new UnaryExpression(LexicalInfo.Empty));
									UnaryOperatorType unaryOperatorType4 = (_0024_00246409_002424194.Operator = UnaryOperatorType.LogicalNot);
									Expression expression21 = (_0024_00246409_002424194.Operand = Expression.Lift(_0024condition_002424180));
									Expression expression23 = (binaryExpression6.Left = _0024_00246409_002424194);
									BinaryExpression binaryExpression7 = _0024_00246414_002424199;
									BinaryExpression binaryExpression8 = (_0024_00246413_002424198 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType8 = (_0024_00246413_002424198.Operator = BinaryOperatorType.LessThan);
									BinaryExpression binaryExpression9 = _0024_00246413_002424198;
									BinaryExpression binaryExpression10 = (_0024_00246412_002424197 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType10 = (_0024_00246412_002424197.Operator = BinaryOperatorType.Subtraction);
									BinaryExpression binaryExpression11 = _0024_00246412_002424197;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00246411_002424196 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text8 = (_0024_00246411_002424196.Name = "realtimeSinceStartup");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00246411_002424196;
									ReferenceExpression referenceExpression2 = (_0024_00246410_002424195 = new ReferenceExpression(LexicalInfo.Empty));
									string text10 = (_0024_00246410_002424195.Name = "Time");
									Expression expression25 = (memberReferenceExpression4.Target = _0024_00246410_002424195);
									Expression expression27 = (binaryExpression11.Left = _0024_00246411_002424196);
									Expression expression29 = (_0024_00246412_002424197.Right = Expression.Lift(_0024t2_002424187));
									Expression expression31 = (binaryExpression9.Left = _0024_00246412_002424197);
									Expression expression33 = (_0024_00246413_002424198.Right = Expression.Lift(_0024t1_002424186));
									Expression expression35 = (binaryExpression7.Right = _0024_00246413_002424198);
									Expression expression37 = (whileStatement5.Condition = _0024_00246414_002424199);
									WhileStatement whileStatement6 = _0024_00246416_002424201;
									Block block6 = (_0024_00246415_002424200 = new Block(LexicalInfo.Empty));
									StatementCollection statementCollection4 = (_0024_00246415_002424200.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024wait_until_002424203.Body)), Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
									Block block8 = (whileStatement6.Block = _0024_00246415_002424200);
									array[2] = Statement.Lift(_0024_00246416_002424201);
									StatementCollection statementCollection6 = (block5.Statements = StatementCollection.FromArray(array));
									result = (Yield(3, _0024_00246417_002424202) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new Exception("wait_until form error");
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

		internal MacroStatement _0024wait_until_002424205;

		internal Wait_untilMacro _0024self__002424206;

		public _0024ExpandGeneratorImpl_002424177(MacroStatement wait_until, Wait_untilMacro self_)
		{
			_0024wait_until_002424205 = wait_until;
			_0024self__002424206 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024wait_until_002424205, _0024self__002424206);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Wait_untilMacro()
	{
	}

	public Wait_untilMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement wait_until)
	{
		return new _0024ExpandGeneratorImpl_002424177(wait_until, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement wait_until)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'wait_until' is using. Read BOO-1077 for more info.");
	}
}
