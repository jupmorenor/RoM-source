using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Wait_until_appearsMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424333 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024115_002424334;

			internal MacroStatement _0024_0024match_0024116_002424335;

			internal TryCastExpression _0024_0024match_0024117_002424336;

			internal Expression _0024v_002424337;

			internal TypeReference _0024t_002424338;

			internal Declaration _0024_00246450_002424339;

			internal Declaration _0024declvar_002424340;

			internal DeclarationStatement _0024_00246451_002424341;

			internal DeclarationStatement _0024declstmt_002424342;

			internal BoolLiteralExpression _0024_00246452_002424343;

			internal ReferenceExpression _0024_00246453_002424344;

			internal MemberReferenceExpression _0024_00246454_002424345;

			internal MemberReferenceExpression _0024_00246455_002424346;

			internal TypeofExpression _0024_00246456_002424347;

			internal MethodInvocationExpression _0024_00246457_002424348;

			internal BinaryExpression _0024_00246458_002424349;

			internal BinaryExpression _0024_00246459_002424350;

			internal StatementModifier _0024_00246460_002424351;

			internal BreakStatement _0024_00246461_002424352;

			internal Block _0024_00246462_002424353;

			internal WhileStatement _0024_00246463_002424354;

			internal WhileStatement _0024whilestmt_002424355;

			internal Block _0024blk_002424356;

			internal MacroStatement _0024_0024match_0024118_002424357;

			internal ReferenceExpression _0024_0024match_0024119_002424358;

			internal string _0024n_002424359;

			internal ReferenceExpression _0024tr_002424360;

			internal ReferenceExpression _0024_00246464_002424361;

			internal MemberReferenceExpression _0024_00246465_002424362;

			internal MemberReferenceExpression _0024_00246466_002424363;

			internal TypeofExpression _0024_00246467_002424364;

			internal MethodInvocationExpression _0024_00246468_002424365;

			internal BinaryExpression _0024_00246469_002424366;

			internal MacroStatement _0024_00246470_002424367;

			internal MacroStatement _0024wait_until_appears_002424368;

			internal Wait_until_appearsMacro _0024self__002424369;

			public _0024(MacroStatement wait_until_appears, Wait_until_appearsMacro self_)
			{
				_0024wait_until_appears_002424368 = wait_until_appears;
				_0024self__002424369 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024wait_until_appears_002424368 == null)
					{
						throw new ArgumentNullException("wait_until_appears");
					}
					_0024self__002424369.__macro = _0024wait_until_appears_002424368;
					_0024_0024match_0024115_002424334 = _0024wait_until_appears_002424368;
					if (_0024_0024match_0024115_002424334 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024116_002424335 = _0024_0024match_0024115_002424334);
						if (true && _0024_0024match_0024116_002424335.Name == "wait_until_appears" && 1 == ((ICollection)_0024_0024match_0024116_002424335.Arguments).Count && _0024_0024match_0024116_002424335.Arguments[0] is TryCastExpression)
						{
							TryCastExpression tryCastExpression = (_0024_0024match_0024117_002424336 = (TryCastExpression)_0024_0024match_0024116_002424335.Arguments[0]);
							if (true)
							{
								Expression expression = (_0024v_002424337 = _0024_0024match_0024117_002424336.Target);
								if (true)
								{
									TypeReference typeReference = (_0024t_002424338 = _0024_0024match_0024117_002424336.Type);
									if (true)
									{
										Declaration declaration = (_0024_00246450_002424339 = new Declaration());
										string text2 = (_0024_00246450_002424339.Name = _0024v_002424337.ToCodeString());
										TypeReference typeReference3 = (_0024_00246450_002424339.Type = _0024t_002424338);
										_0024declvar_002424340 = _0024_00246450_002424339;
										DeclarationStatement declarationStatement = (_0024_00246451_002424341 = new DeclarationStatement());
										Declaration declaration3 = (_0024_00246451_002424341.Declaration = _0024declvar_002424340);
										_0024declstmt_002424342 = _0024_00246451_002424341;
										WhileStatement whileStatement = (_0024_00246463_002424354 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement2 = _0024_00246463_002424354;
										BoolLiteralExpression boolLiteralExpression = (_0024_00246452_002424343 = new BoolLiteralExpression(LexicalInfo.Empty));
										bool flag2 = (_0024_00246452_002424343.Value = true);
										Expression expression3 = (whileStatement2.Condition = _0024_00246452_002424343);
										WhileStatement whileStatement3 = _0024_00246463_002424354;
										Block block = (_0024_00246462_002424353 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00246462_002424353;
										Statement[] array = new Statement[3];
										BinaryExpression binaryExpression = (_0024_00246458_002424349 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00246458_002424349.Operator = BinaryOperatorType.Assign);
										Expression expression5 = (_0024_00246458_002424349.Left = Expression.Lift(_0024v_002424337));
										BinaryExpression binaryExpression2 = _0024_00246458_002424349;
										MethodInvocationExpression methodInvocationExpression = (_0024_00246457_002424348 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00246457_002424348;
										MemberReferenceExpression memberReferenceExpression = (_0024_00246455_002424346 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00246455_002424346.Name = "FindObjectOfType");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00246455_002424346;
										MemberReferenceExpression memberReferenceExpression3 = (_0024_00246454_002424345 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text6 = (_0024_00246454_002424345.Name = "Object");
										MemberReferenceExpression memberReferenceExpression4 = _0024_00246454_002424345;
										ReferenceExpression referenceExpression = (_0024_00246453_002424344 = new ReferenceExpression(LexicalInfo.Empty));
										string text8 = (_0024_00246453_002424344.Name = "UnityEngine");
										Expression expression7 = (memberReferenceExpression4.Target = _0024_00246453_002424344);
										Expression expression9 = (memberReferenceExpression2.Target = _0024_00246454_002424345);
										Expression expression11 = (methodInvocationExpression2.Target = _0024_00246455_002424346);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00246457_002424348;
										Expression[] array2 = new Expression[1];
										TypeofExpression typeofExpression = (_0024_00246456_002424347 = new TypeofExpression(LexicalInfo.Empty));
										TypeReference typeReference5 = (_0024_00246456_002424347.Type = TypeReference.Lift(_0024t_002424338));
										array2[0] = _0024_00246456_002424347;
										ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array2));
										Expression expression13 = (binaryExpression2.Right = _0024_00246457_002424348);
										array[0] = Statement.Lift(_0024_00246458_002424349);
										BreakStatement breakStatement = (_0024_00246461_002424352 = new BreakStatement(LexicalInfo.Empty));
										BreakStatement breakStatement2 = _0024_00246461_002424352;
										StatementModifier statementModifier = (_0024_00246460_002424351 = new StatementModifier(LexicalInfo.Empty));
										StatementModifierType statementModifierType2 = (_0024_00246460_002424351.Type = StatementModifierType.If);
										StatementModifier statementModifier2 = _0024_00246460_002424351;
										BinaryExpression binaryExpression3 = (_0024_00246459_002424350 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00246459_002424350.Operator = BinaryOperatorType.Inequality);
										Expression expression15 = (_0024_00246459_002424350.Left = Expression.Lift(_0024v_002424337));
										Expression expression17 = (_0024_00246459_002424350.Right = new NullLiteralExpression(LexicalInfo.Empty));
										Expression expression19 = (statementModifier2.Condition = _0024_00246459_002424350);
										StatementModifier statementModifier4 = (breakStatement2.Modifier = _0024_00246460_002424351);
										array[1] = Statement.Lift(_0024_00246461_002424352);
										array[2] = Statement.Lift(new YieldStatement(LexicalInfo.Empty));
										StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
										Block block4 = (whileStatement3.Block = _0024_00246462_002424353);
										_0024whilestmt_002424355 = _0024_00246463_002424354;
										_0024blk_002424356 = new Block();
										_0024blk_002424356.Add(_0024declstmt_002424342);
										_0024blk_002424356.Add(_0024whilestmt_002424355);
										result = (Yield(2, _0024blk_002424356) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_0024115_002424334 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_0024118_002424357 = _0024_0024match_0024115_002424334);
						if (true && _0024_0024match_0024118_002424357.Name == "wait_until_appears" && 1 == ((ICollection)_0024_0024match_0024118_002424357.Arguments).Count && _0024_0024match_0024118_002424357.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression2 = (_0024_0024match_0024119_002424358 = (ReferenceExpression)_0024_0024match_0024118_002424357.Arguments[0]);
							if (true)
							{
								string text9 = (_0024n_002424359 = _0024_0024match_0024119_002424358.Name);
								if (true)
								{
									_0024tr_002424360 = new ReferenceExpression(_0024n_002424359);
									MacroStatement macroStatement3 = (_0024_00246470_002424367 = new MacroStatement(LexicalInfo.Empty));
									string text11 = (_0024_00246470_002424367.Name = "wait_until");
									MacroStatement macroStatement4 = _0024_00246470_002424367;
									Expression[] array3 = new Expression[1];
									BinaryExpression binaryExpression4 = (_0024_00246469_002424366 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType6 = (_0024_00246469_002424366.Operator = BinaryOperatorType.Inequality);
									BinaryExpression binaryExpression5 = _0024_00246469_002424366;
									MethodInvocationExpression methodInvocationExpression4 = (_0024_00246468_002424365 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression5 = _0024_00246468_002424365;
									MemberReferenceExpression memberReferenceExpression5 = (_0024_00246466_002424363 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text13 = (_0024_00246466_002424363.Name = "FindObjectOfType");
									MemberReferenceExpression memberReferenceExpression6 = _0024_00246466_002424363;
									MemberReferenceExpression memberReferenceExpression7 = (_0024_00246465_002424362 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text15 = (_0024_00246465_002424362.Name = "Object");
									MemberReferenceExpression memberReferenceExpression8 = _0024_00246465_002424362;
									ReferenceExpression referenceExpression3 = (_0024_00246464_002424361 = new ReferenceExpression(LexicalInfo.Empty));
									string text17 = (_0024_00246464_002424361.Name = "UnityEngine");
									Expression expression21 = (memberReferenceExpression8.Target = _0024_00246464_002424361);
									Expression expression23 = (memberReferenceExpression6.Target = _0024_00246465_002424362);
									Expression expression25 = (methodInvocationExpression5.Target = _0024_00246466_002424363);
									MethodInvocationExpression methodInvocationExpression6 = _0024_00246468_002424365;
									Expression[] array4 = new Expression[1];
									TypeofExpression typeofExpression2 = (_0024_00246467_002424364 = new TypeofExpression(LexicalInfo.Empty));
									TypeReference typeReference7 = (_0024_00246467_002424364.Type = TypeReference.Lift(_0024tr_002424360));
									array4[0] = _0024_00246467_002424364;
									ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array4));
									Expression expression27 = (binaryExpression5.Left = _0024_00246468_002424365);
									Expression expression29 = (_0024_00246469_002424366.Right = new NullLiteralExpression(LexicalInfo.Empty));
									array3[0] = _0024_00246469_002424366;
									ExpressionCollection expressionCollection6 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array3));
									Block block6 = (_0024_00246470_002424367.Body = new Block(LexicalInfo.Empty));
									result = (Yield(3, _0024_00246470_002424367) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new Exception("wait_until_appears macro error: must be a form \"wait_until_appears var as type\"");
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

		internal MacroStatement _0024wait_until_appears_002424370;

		internal Wait_until_appearsMacro _0024self__002424371;

		public _0024ExpandGeneratorImpl_002424333(MacroStatement wait_until_appears, Wait_until_appearsMacro self_)
		{
			_0024wait_until_appears_002424370 = wait_until_appears;
			_0024self__002424371 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024wait_until_appears_002424370, _0024self__002424371);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Wait_until_appearsMacro()
	{
	}

	public Wait_until_appearsMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement wait_until_appears)
	{
		return new _0024ExpandGeneratorImpl_002424333(wait_until_appears, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement wait_until_appears)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'wait_until_appears' is using. Read BOO-1077 for more info.");
	}
}
