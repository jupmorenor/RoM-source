using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;

[Serializable]
public sealed class Dialog_assertMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424442 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024142_002424443;

			internal MacroStatement _0024_0024match_0024143_002424444;

			internal Expression _0024condition_002424445;

			internal LexicalInfo _0024linfo_002424446;

			internal string _0024lstr_002424447;

			internal ReferenceExpression _0024vmsg_002424448;

			internal UnaryExpression _0024_00246525_002424449;

			internal BinaryExpression _0024_00246526_002424450;

			internal ReferenceExpression _0024_00246527_002424451;

			internal MemberReferenceExpression _0024_00246528_002424452;

			internal StringLiteralExpression _0024_00246529_002424453;

			internal MethodInvocationExpression _0024_00246530_002424454;

			internal ReferenceExpression _0024_00246531_002424455;

			internal MemberReferenceExpression _0024_00246532_002424456;

			internal MemberReferenceExpression _0024_00246533_002424457;

			internal MethodInvocationExpression _0024_00246534_002424458;

			internal ReferenceExpression _0024_00246535_002424459;

			internal MemberReferenceExpression _0024_00246536_002424460;

			internal MethodInvocationExpression _0024_00246537_002424461;

			internal RaiseStatement _0024_00246538_002424462;

			internal Block _0024_00246539_002424463;

			internal IfStatement _0024_00246540_002424464;

			internal MacroStatement _0024_0024match_0024144_002424465;

			internal Expression _0024message_002424466;

			internal UnaryExpression _0024_00246541_002424467;

			internal BinaryExpression _0024_00246542_002424468;

			internal ReferenceExpression _0024_00246543_002424469;

			internal MemberReferenceExpression _0024_00246544_002424470;

			internal StringLiteralExpression _0024_00246545_002424471;

			internal MethodInvocationExpression _0024_00246546_002424472;

			internal ReferenceExpression _0024_00246547_002424473;

			internal MemberReferenceExpression _0024_00246548_002424474;

			internal MemberReferenceExpression _0024_00246549_002424475;

			internal MethodInvocationExpression _0024_00246550_002424476;

			internal ReferenceExpression _0024_00246551_002424477;

			internal MemberReferenceExpression _0024_00246552_002424478;

			internal MethodInvocationExpression _0024_00246553_002424479;

			internal RaiseStatement _0024_00246554_002424480;

			internal Block _0024_00246555_002424481;

			internal IfStatement _0024_00246556_002424482;

			internal MacroStatement _0024dialog_assert_002424483;

			internal Dialog_assertMacro _0024self__002424484;

			public _0024(MacroStatement dialog_assert, Dialog_assertMacro self_)
			{
				_0024dialog_assert_002424483 = dialog_assert;
				_0024self__002424484 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024dialog_assert_002424483 == null)
					{
						throw new ArgumentNullException("dialog_assert");
					}
					_0024self__002424484.__macro = _0024dialog_assert_002424483;
					_0024_0024match_0024142_002424443 = _0024dialog_assert_002424483;
					if (_0024_0024match_0024142_002424443 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024143_002424444 = _0024_0024match_0024142_002424443);
						if (true && _0024_0024match_0024143_002424444.Name == "dialog_assert" && 1 == ((ICollection)_0024_0024match_0024143_002424444.Arguments).Count)
						{
							Expression expression = (_0024condition_002424445 = _0024_0024match_0024143_002424444.Arguments[0]);
							if (true)
							{
								_0024linfo_002424446 = _0024dialog_assert_002424483.LexicalInfo;
								_0024lstr_002424447 = _0024linfo_002424446.FileName + "(" + _0024linfo_002424446.Line + ")";
								_0024vmsg_002424448 = new ReferenceExpression(_0024self__002424484.Context.GetUniqueName("dialog_assert1"));
								IfStatement ifStatement = (_0024_00246540_002424464 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement2 = _0024_00246540_002424464;
								UnaryExpression unaryExpression = (_0024_00246525_002424449 = new UnaryExpression(LexicalInfo.Empty));
								UnaryOperatorType unaryOperatorType2 = (_0024_00246525_002424449.Operator = UnaryOperatorType.LogicalNot);
								Expression expression3 = (_0024_00246525_002424449.Operand = Expression.Lift(_0024condition_002424445));
								Expression expression5 = (ifStatement2.Condition = _0024_00246525_002424449);
								IfStatement ifStatement3 = _0024_00246540_002424464;
								Block block = (_0024_00246539_002424463 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00246539_002424463;
								Statement[] array = new Statement[5];
								BinaryExpression binaryExpression = (_0024_00246526_002424450 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246526_002424450.Operator = BinaryOperatorType.Assign);
								Expression expression7 = (_0024_00246526_002424450.Left = Expression.Lift(_0024vmsg_002424448));
								Expression expression9 = (_0024_00246526_002424450.Right = Expression.Lift(_0024condition_002424445.ToString()));
								array[0] = Statement.Lift(_0024_00246526_002424450);
								MethodInvocationExpression methodInvocationExpression = (_0024_00246530_002424454 = new MethodInvocationExpression(LexicalInfo.Empty));
								MethodInvocationExpression methodInvocationExpression2 = _0024_00246530_002424454;
								MemberReferenceExpression memberReferenceExpression = (_0024_00246528_002424452 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text2 = (_0024_00246528_002424452.Name = "FatalErrorDialog");
								MemberReferenceExpression memberReferenceExpression2 = _0024_00246528_002424452;
								ReferenceExpression referenceExpression = (_0024_00246527_002424451 = new ReferenceExpression(LexicalInfo.Empty));
								string text4 = (_0024_00246527_002424451.Name = "MerlinServer");
								Expression expression11 = (memberReferenceExpression2.Target = _0024_00246527_002424451);
								Expression expression13 = (methodInvocationExpression2.Target = _0024_00246528_002424452);
								MethodInvocationExpression methodInvocationExpression3 = _0024_00246530_002424454;
								Expression[] obj = new Expression[3]
								{
									Expression.Lift(_0024vmsg_002424448),
									Expression.Lift(_0024lstr_002424447),
									null
								};
								StringLiteralExpression stringLiteralExpression = (_0024_00246529_002424453 = new StringLiteralExpression(LexicalInfo.Empty));
								string text5 = (_0024_00246529_002424453.Value = string.Empty);
								obj[2] = _0024_00246529_002424453;
								ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
								array[1] = Statement.Lift(_0024_00246530_002424454);
								MethodInvocationExpression methodInvocationExpression4 = (_0024_00246534_002424458 = new MethodInvocationExpression(LexicalInfo.Empty));
								MethodInvocationExpression methodInvocationExpression5 = _0024_00246534_002424458;
								MemberReferenceExpression memberReferenceExpression3 = (_0024_00246533_002424457 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text7 = (_0024_00246533_002424457.Name = "LogError");
								MemberReferenceExpression memberReferenceExpression4 = _0024_00246533_002424457;
								MemberReferenceExpression memberReferenceExpression5 = (_0024_00246532_002424456 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text9 = (_0024_00246532_002424456.Name = "Debug");
								MemberReferenceExpression memberReferenceExpression6 = _0024_00246532_002424456;
								ReferenceExpression referenceExpression2 = (_0024_00246531_002424455 = new ReferenceExpression(LexicalInfo.Empty));
								string text11 = (_0024_00246531_002424455.Name = "UnityEngine");
								Expression expression15 = (memberReferenceExpression6.Target = _0024_00246531_002424455);
								Expression expression17 = (memberReferenceExpression4.Target = _0024_00246532_002424456);
								Expression expression19 = (methodInvocationExpression5.Target = _0024_00246533_002424457);
								ExpressionCollection expressionCollection4 = (_0024_00246534_002424458.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vmsg_002424448)));
								array[2] = Statement.Lift(_0024_00246534_002424458);
								MethodInvocationExpression methodInvocationExpression6 = (_0024_00246537_002424461 = new MethodInvocationExpression(LexicalInfo.Empty));
								MethodInvocationExpression methodInvocationExpression7 = _0024_00246537_002424461;
								MemberReferenceExpression memberReferenceExpression7 = (_0024_00246536_002424460 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text13 = (_0024_00246536_002424460.Name = "PassCheckpoint");
								MemberReferenceExpression memberReferenceExpression8 = _0024_00246536_002424460;
								ReferenceExpression referenceExpression3 = (_0024_00246535_002424459 = new ReferenceExpression(LexicalInfo.Empty));
								string text15 = (_0024_00246535_002424459.Name = "TestFlightUnity");
								Expression expression21 = (memberReferenceExpression8.Target = _0024_00246535_002424459);
								Expression expression23 = (methodInvocationExpression7.Target = _0024_00246536_002424460);
								ExpressionCollection expressionCollection6 = (_0024_00246537_002424461.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vmsg_002424448)));
								array[3] = Statement.Lift(_0024_00246537_002424461);
								RaiseStatement raiseStatement = (_0024_00246538_002424462 = new RaiseStatement(LexicalInfo.Empty));
								Expression expression25 = (_0024_00246538_002424462.Exception = Expression.Lift(_0024vmsg_002424448));
								array[4] = Statement.Lift(_0024_00246538_002424462);
								StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
								Block block4 = (ifStatement3.TrueBlock = _0024_00246539_002424463);
								result = (Yield(2, _0024_00246540_002424464) ? 1 : 0);
								break;
							}
						}
					}
					if (_0024_0024match_0024142_002424443 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_0024144_002424465 = _0024_0024match_0024142_002424443);
						if (true && _0024_0024match_0024144_002424465.Name == "dialog_assert" && 2 == ((ICollection)_0024_0024match_0024144_002424465.Arguments).Count)
						{
							Expression expression26 = (_0024condition_002424445 = _0024_0024match_0024144_002424465.Arguments[0]);
							if (true)
							{
								Expression expression27 = (_0024message_002424466 = _0024_0024match_0024144_002424465.Arguments[1]);
								if (true)
								{
									_0024linfo_002424446 = _0024dialog_assert_002424483.LexicalInfo;
									_0024lstr_002424447 = _0024linfo_002424446.FileName + "(" + _0024linfo_002424446.Line + ")";
									_0024vmsg_002424448 = new ReferenceExpression(_0024self__002424484.Context.GetUniqueName("dialog_assert1"));
									IfStatement ifStatement4 = (_0024_00246556_002424482 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement5 = _0024_00246556_002424482;
									UnaryExpression unaryExpression2 = (_0024_00246541_002424467 = new UnaryExpression(LexicalInfo.Empty));
									UnaryOperatorType unaryOperatorType4 = (_0024_00246541_002424467.Operator = UnaryOperatorType.LogicalNot);
									Expression expression29 = (_0024_00246541_002424467.Operand = Expression.Lift(_0024condition_002424445));
									Expression expression31 = (ifStatement5.Condition = _0024_00246541_002424467);
									IfStatement ifStatement6 = _0024_00246556_002424482;
									Block block5 = (_0024_00246555_002424481 = new Block(LexicalInfo.Empty));
									Block block6 = _0024_00246555_002424481;
									Statement[] array2 = new Statement[5];
									BinaryExpression binaryExpression2 = (_0024_00246542_002424468 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00246542_002424468.Operator = BinaryOperatorType.Assign);
									Expression expression33 = (_0024_00246542_002424468.Left = Expression.Lift(_0024vmsg_002424448));
									Expression expression35 = (_0024_00246542_002424468.Right = Expression.Lift(_0024message_002424466));
									array2[0] = Statement.Lift(_0024_00246542_002424468);
									MethodInvocationExpression methodInvocationExpression8 = (_0024_00246546_002424472 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression9 = _0024_00246546_002424472;
									MemberReferenceExpression memberReferenceExpression9 = (_0024_00246544_002424470 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text17 = (_0024_00246544_002424470.Name = "FatalErrorDialog");
									MemberReferenceExpression memberReferenceExpression10 = _0024_00246544_002424470;
									ReferenceExpression referenceExpression4 = (_0024_00246543_002424469 = new ReferenceExpression(LexicalInfo.Empty));
									string text19 = (_0024_00246543_002424469.Name = "MerlinServer");
									Expression expression37 = (memberReferenceExpression10.Target = _0024_00246543_002424469);
									Expression expression39 = (methodInvocationExpression9.Target = _0024_00246544_002424470);
									MethodInvocationExpression methodInvocationExpression10 = _0024_00246546_002424472;
									Expression[] obj2 = new Expression[3]
									{
										Expression.Lift(_0024vmsg_002424448),
										Expression.Lift(_0024lstr_002424447),
										null
									};
									StringLiteralExpression stringLiteralExpression2 = (_0024_00246545_002424471 = new StringLiteralExpression(LexicalInfo.Empty));
									string text20 = (_0024_00246545_002424471.Value = string.Empty);
									obj2[2] = _0024_00246545_002424471;
									ExpressionCollection expressionCollection8 = (methodInvocationExpression10.Arguments = ExpressionCollection.FromArray(obj2));
									array2[1] = Statement.Lift(_0024_00246546_002424472);
									MethodInvocationExpression methodInvocationExpression11 = (_0024_00246550_002424476 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression12 = _0024_00246550_002424476;
									MemberReferenceExpression memberReferenceExpression11 = (_0024_00246549_002424475 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text22 = (_0024_00246549_002424475.Name = "LogError");
									MemberReferenceExpression memberReferenceExpression12 = _0024_00246549_002424475;
									MemberReferenceExpression memberReferenceExpression13 = (_0024_00246548_002424474 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text24 = (_0024_00246548_002424474.Name = "Debug");
									MemberReferenceExpression memberReferenceExpression14 = _0024_00246548_002424474;
									ReferenceExpression referenceExpression5 = (_0024_00246547_002424473 = new ReferenceExpression(LexicalInfo.Empty));
									string text26 = (_0024_00246547_002424473.Name = "UnityEngine");
									Expression expression41 = (memberReferenceExpression14.Target = _0024_00246547_002424473);
									Expression expression43 = (memberReferenceExpression12.Target = _0024_00246548_002424474);
									Expression expression45 = (methodInvocationExpression12.Target = _0024_00246549_002424475);
									ExpressionCollection expressionCollection10 = (_0024_00246550_002424476.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vmsg_002424448)));
									array2[2] = Statement.Lift(_0024_00246550_002424476);
									MethodInvocationExpression methodInvocationExpression13 = (_0024_00246553_002424479 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression14 = _0024_00246553_002424479;
									MemberReferenceExpression memberReferenceExpression15 = (_0024_00246552_002424478 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text28 = (_0024_00246552_002424478.Name = "PassCheckpoint");
									MemberReferenceExpression memberReferenceExpression16 = _0024_00246552_002424478;
									ReferenceExpression referenceExpression6 = (_0024_00246551_002424477 = new ReferenceExpression(LexicalInfo.Empty));
									string text30 = (_0024_00246551_002424477.Name = "TestFlightUnity");
									Expression expression47 = (memberReferenceExpression16.Target = _0024_00246551_002424477);
									Expression expression49 = (methodInvocationExpression14.Target = _0024_00246552_002424478);
									ExpressionCollection expressionCollection12 = (_0024_00246553_002424479.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vmsg_002424448)));
									array2[3] = Statement.Lift(_0024_00246553_002424479);
									RaiseStatement raiseStatement2 = (_0024_00246554_002424480 = new RaiseStatement(LexicalInfo.Empty));
									Expression expression51 = (_0024_00246554_002424480.Exception = Expression.Lift(_0024vmsg_002424448));
									array2[4] = Statement.Lift(_0024_00246554_002424480);
									StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
									Block block8 = (ifStatement6.TrueBlock = _0024_00246555_002424481);
									result = (Yield(3, _0024_00246556_002424482) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`dialog_assert` failed to match `").Append(_0024_0024match_0024142_002424443).Append("`").ToString());
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

		internal MacroStatement _0024dialog_assert_002424485;

		internal Dialog_assertMacro _0024self__002424486;

		public _0024ExpandGeneratorImpl_002424442(MacroStatement dialog_assert, Dialog_assertMacro self_)
		{
			_0024dialog_assert_002424485 = dialog_assert;
			_0024self__002424486 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024dialog_assert_002424485, _0024self__002424486);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Dialog_assertMacro()
	{
	}

	public Dialog_assertMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement dialog_assert)
	{
		return new _0024ExpandGeneratorImpl_002424442(dialog_assert, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement dialog_assert)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'dialog_assert' is using. Read BOO-1077 for more info.");
	}
}
