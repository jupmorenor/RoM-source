using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;

[Serializable]
public sealed class AssertMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_00242418 : GenericGenerator<Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024164_00242419;

			internal MacroStatement _0024_0024match_0024165_00242420;

			internal Expression _0024condition_00242421;

			internal string _0024src_00242422;

			internal int _0024line_00242423;

			internal string _0024codestr_00242424;

			internal ReferenceExpression _0024msg_00242425;

			internal UnaryExpression _0024_00241181_00242426;

			internal StringLiteralExpression _0024_00241182_00242427;

			internal BinaryExpression _0024_00241183_00242428;

			internal StringLiteralExpression _0024_00241184_00242429;

			internal BinaryExpression _0024_00241185_00242430;

			internal BinaryExpression _0024_00241186_00242431;

			internal StringLiteralExpression _0024_00241187_00242432;

			internal BinaryExpression _0024_00241188_00242433;

			internal BinaryExpression _0024_00241189_00242434;

			internal BinaryExpression _0024_00241190_00242435;

			internal ReferenceExpression _0024_00241191_00242436;

			internal MemberReferenceExpression _0024_00241192_00242437;

			internal MemberReferenceExpression _0024_00241193_00242438;

			internal MethodInvocationExpression _0024_00241194_00242439;

			internal RaiseStatement _0024_00241195_00242440;

			internal Block _0024_00241196_00242441;

			internal IfStatement _0024_00241197_00242442;

			internal IfStatement _0024b_00242443;

			internal MacroStatement _0024_0024match_0024166_00242444;

			internal Expression _0024message_00242445;

			internal UnaryExpression _0024_00241198_00242446;

			internal StringLiteralExpression _0024_00241199_00242447;

			internal BinaryExpression _0024_00241200_00242448;

			internal StringLiteralExpression _0024_00241201_00242449;

			internal BinaryExpression _0024_00241202_00242450;

			internal BinaryExpression _0024_00241203_00242451;

			internal StringLiteralExpression _0024_00241204_00242452;

			internal BinaryExpression _0024_00241205_00242453;

			internal BinaryExpression _0024_00241206_00242454;

			internal StringLiteralExpression _0024_00241207_00242455;

			internal BinaryExpression _0024_00241208_00242456;

			internal BinaryExpression _0024_00241209_00242457;

			internal BinaryExpression _0024_00241210_00242458;

			internal RaiseStatement _0024_00241211_00242459;

			internal Block _0024_00241212_00242460;

			internal IfStatement _0024_00241213_00242461;

			internal MacroStatement _0024assert_00242462;

			internal AssertMacro _0024self__00242463;

			public _0024(MacroStatement assert, AssertMacro self_)
			{
				_0024assert_00242462 = assert;
				_0024self__00242463 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024assert_00242462 == null)
					{
						throw new ArgumentNullException("assert");
					}
					_0024self__00242463.__macro = _0024assert_00242462;
					_0024_0024match_0024164_00242419 = _0024assert_00242462;
					if (_0024_0024match_0024164_00242419 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024165_00242420 = _0024_0024match_0024164_00242419);
						if (true && _0024_0024match_0024165_00242420.Name == "assert" && 1 == ((ICollection)_0024_0024match_0024165_00242420.Arguments).Count)
						{
							Expression expression = (_0024condition_00242421 = _0024_0024match_0024165_00242420.Arguments[0]);
							if (true)
							{
								_0024src_00242422 = Path.GetFileNameWithoutExtension(_0024assert_00242462.LexicalInfo.FileName);
								_0024line_00242423 = _0024assert_00242462.LexicalInfo.Line;
								_0024codestr_00242424 = _0024condition_00242421.ToCodeString();
								_0024msg_00242425 = new ReferenceExpression(_0024self__00242463.Context.GetUniqueName("assert1"));
								IfStatement ifStatement = (_0024_00241197_00242442 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement2 = _0024_00241197_00242442;
								UnaryExpression unaryExpression = (_0024_00241181_00242426 = new UnaryExpression(LexicalInfo.Empty));
								UnaryOperatorType unaryOperatorType2 = (_0024_00241181_00242426.Operator = UnaryOperatorType.LogicalNot);
								Expression expression3 = (_0024_00241181_00242426.Operand = Expression.Lift(_0024condition_00242421));
								Expression expression5 = (ifStatement2.Condition = _0024_00241181_00242426);
								IfStatement ifStatement3 = _0024_00241197_00242442;
								Block block = (_0024_00241196_00242441 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00241196_00242441;
								Statement[] array = new Statement[3];
								BinaryExpression binaryExpression = (_0024_00241190_00242435 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00241190_00242435.Operator = BinaryOperatorType.Assign);
								Expression expression7 = (_0024_00241190_00242435.Left = Expression.Lift(_0024msg_00242425));
								BinaryExpression binaryExpression2 = _0024_00241190_00242435;
								BinaryExpression binaryExpression3 = (_0024_00241189_00242434 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType4 = (_0024_00241189_00242434.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression4 = _0024_00241189_00242434;
								BinaryExpression binaryExpression5 = (_0024_00241188_00242433 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType6 = (_0024_00241188_00242433.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression6 = _0024_00241188_00242433;
								BinaryExpression binaryExpression7 = (_0024_00241186_00242431 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType8 = (_0024_00241186_00242431.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression8 = _0024_00241186_00242431;
								BinaryExpression binaryExpression9 = (_0024_00241185_00242430 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType10 = (_0024_00241185_00242430.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression10 = _0024_00241185_00242430;
								BinaryExpression binaryExpression11 = (_0024_00241183_00242428 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType12 = (_0024_00241183_00242428.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression12 = _0024_00241183_00242428;
								StringLiteralExpression stringLiteralExpression = (_0024_00241182_00242427 = new StringLiteralExpression(LexicalInfo.Empty));
								string text2 = (_0024_00241182_00242427.Value = "ASSERT at ");
								Expression expression9 = (binaryExpression12.Left = _0024_00241182_00242427);
								Expression expression11 = (_0024_00241183_00242428.Right = Expression.Lift(_0024src_00242422));
								Expression expression13 = (binaryExpression10.Left = _0024_00241183_00242428);
								BinaryExpression binaryExpression13 = _0024_00241185_00242430;
								StringLiteralExpression stringLiteralExpression2 = (_0024_00241184_00242429 = new StringLiteralExpression(LexicalInfo.Empty));
								string text4 = (_0024_00241184_00242429.Value = "(");
								Expression expression15 = (binaryExpression13.Right = _0024_00241184_00242429);
								Expression expression17 = (binaryExpression8.Left = _0024_00241185_00242430);
								Expression expression19 = (_0024_00241186_00242431.Right = Expression.Lift(_0024line_00242423));
								Expression expression21 = (binaryExpression6.Left = _0024_00241186_00242431);
								BinaryExpression binaryExpression14 = _0024_00241188_00242433;
								StringLiteralExpression stringLiteralExpression3 = (_0024_00241187_00242432 = new StringLiteralExpression(LexicalInfo.Empty));
								string text6 = (_0024_00241187_00242432.Value = "):");
								Expression expression23 = (binaryExpression14.Right = _0024_00241187_00242432);
								Expression expression25 = (binaryExpression4.Left = _0024_00241188_00242433);
								Expression expression27 = (_0024_00241189_00242434.Right = Expression.Lift(_0024codestr_00242424));
								Expression expression29 = (binaryExpression2.Right = _0024_00241189_00242434);
								array[0] = Statement.Lift(_0024_00241190_00242435);
								MethodInvocationExpression methodInvocationExpression = (_0024_00241194_00242439 = new MethodInvocationExpression(LexicalInfo.Empty));
								MethodInvocationExpression methodInvocationExpression2 = _0024_00241194_00242439;
								MemberReferenceExpression memberReferenceExpression = (_0024_00241193_00242438 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text8 = (_0024_00241193_00242438.Name = "LogError");
								MemberReferenceExpression memberReferenceExpression2 = _0024_00241193_00242438;
								MemberReferenceExpression memberReferenceExpression3 = (_0024_00241192_00242437 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text10 = (_0024_00241192_00242437.Name = "Debug");
								MemberReferenceExpression memberReferenceExpression4 = _0024_00241192_00242437;
								ReferenceExpression referenceExpression = (_0024_00241191_00242436 = new ReferenceExpression(LexicalInfo.Empty));
								string text12 = (_0024_00241191_00242436.Name = "UnityEngine");
								Expression expression31 = (memberReferenceExpression4.Target = _0024_00241191_00242436);
								Expression expression33 = (memberReferenceExpression2.Target = _0024_00241192_00242437);
								Expression expression35 = (methodInvocationExpression2.Target = _0024_00241193_00242438);
								ExpressionCollection expressionCollection2 = (_0024_00241194_00242439.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024msg_00242425)));
								array[1] = Statement.Lift(_0024_00241194_00242439);
								RaiseStatement raiseStatement = (_0024_00241195_00242440 = new RaiseStatement(LexicalInfo.Empty));
								Expression expression37 = (_0024_00241195_00242440.Exception = Expression.Lift(_0024msg_00242425));
								array[2] = Statement.Lift(_0024_00241195_00242440);
								StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
								Block block4 = (ifStatement3.TrueBlock = _0024_00241196_00242441);
								_0024b_00242443 = _0024_00241197_00242442;
								_0024b_00242443.LexicalInfo = _0024assert_00242462.LexicalInfo;
								result = (Yield(2, _0024b_00242443) ? 1 : 0);
								break;
							}
						}
					}
					if (_0024_0024match_0024164_00242419 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_0024166_00242444 = _0024_0024match_0024164_00242419);
						if (true && _0024_0024match_0024166_00242444.Name == "assert" && 2 == ((ICollection)_0024_0024match_0024166_00242444.Arguments).Count)
						{
							Expression expression38 = (_0024condition_00242421 = _0024_0024match_0024166_00242444.Arguments[0]);
							if (true)
							{
								Expression expression39 = (_0024message_00242445 = _0024_0024match_0024166_00242444.Arguments[1]);
								if (true)
								{
									_0024src_00242422 = Path.GetFileNameWithoutExtension(_0024assert_00242462.LexicalInfo.FileName);
									_0024line_00242423 = _0024assert_00242462.LexicalInfo.Line;
									_0024codestr_00242424 = _0024condition_00242421.ToCodeString();
									_0024msg_00242425 = new ReferenceExpression(_0024self__00242463.Context.GetUniqueName("assert2"));
									IfStatement ifStatement4 = (_0024_00241213_00242461 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement5 = _0024_00241213_00242461;
									UnaryExpression unaryExpression2 = (_0024_00241198_00242446 = new UnaryExpression(LexicalInfo.Empty));
									UnaryOperatorType unaryOperatorType4 = (_0024_00241198_00242446.Operator = UnaryOperatorType.LogicalNot);
									Expression expression41 = (_0024_00241198_00242446.Operand = Expression.Lift(_0024condition_00242421));
									Expression expression43 = (ifStatement5.Condition = _0024_00241198_00242446);
									IfStatement ifStatement6 = _0024_00241213_00242461;
									Block block5 = (_0024_00241212_00242460 = new Block(LexicalInfo.Empty));
									Block block6 = _0024_00241212_00242460;
									Statement[] array2 = new Statement[2];
									BinaryExpression binaryExpression15 = (_0024_00241210_00242458 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType14 = (_0024_00241210_00242458.Operator = BinaryOperatorType.Assign);
									Expression expression45 = (_0024_00241210_00242458.Left = Expression.Lift(_0024msg_00242425));
									BinaryExpression binaryExpression16 = _0024_00241210_00242458;
									BinaryExpression binaryExpression17 = (_0024_00241209_00242457 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType16 = (_0024_00241209_00242457.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression18 = _0024_00241209_00242457;
									BinaryExpression binaryExpression19 = (_0024_00241208_00242456 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType18 = (_0024_00241208_00242456.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression20 = _0024_00241208_00242456;
									BinaryExpression binaryExpression21 = (_0024_00241206_00242454 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType20 = (_0024_00241206_00242454.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression22 = _0024_00241206_00242454;
									BinaryExpression binaryExpression23 = (_0024_00241205_00242453 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType22 = (_0024_00241205_00242453.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression24 = _0024_00241205_00242453;
									BinaryExpression binaryExpression25 = (_0024_00241203_00242451 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType24 = (_0024_00241203_00242451.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression26 = _0024_00241203_00242451;
									BinaryExpression binaryExpression27 = (_0024_00241202_00242450 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType26 = (_0024_00241202_00242450.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression28 = _0024_00241202_00242450;
									BinaryExpression binaryExpression29 = (_0024_00241200_00242448 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType28 = (_0024_00241200_00242448.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression30 = _0024_00241200_00242448;
									StringLiteralExpression stringLiteralExpression4 = (_0024_00241199_00242447 = new StringLiteralExpression(LexicalInfo.Empty));
									string text14 = (_0024_00241199_00242447.Value = "ASSERT at ");
									Expression expression47 = (binaryExpression30.Left = _0024_00241199_00242447);
									Expression expression49 = (_0024_00241200_00242448.Right = Expression.Lift(_0024src_00242422));
									Expression expression51 = (binaryExpression28.Left = _0024_00241200_00242448);
									BinaryExpression binaryExpression31 = _0024_00241202_00242450;
									StringLiteralExpression stringLiteralExpression5 = (_0024_00241201_00242449 = new StringLiteralExpression(LexicalInfo.Empty));
									string text16 = (_0024_00241201_00242449.Value = "(");
									Expression expression53 = (binaryExpression31.Right = _0024_00241201_00242449);
									Expression expression55 = (binaryExpression26.Left = _0024_00241202_00242450);
									Expression expression57 = (_0024_00241203_00242451.Right = Expression.Lift(_0024line_00242423));
									Expression expression59 = (binaryExpression24.Left = _0024_00241203_00242451);
									BinaryExpression binaryExpression32 = _0024_00241205_00242453;
									StringLiteralExpression stringLiteralExpression6 = (_0024_00241204_00242452 = new StringLiteralExpression(LexicalInfo.Empty));
									string text18 = (_0024_00241204_00242452.Value = "):");
									Expression expression61 = (binaryExpression32.Right = _0024_00241204_00242452);
									Expression expression63 = (binaryExpression22.Left = _0024_00241205_00242453);
									Expression expression65 = (_0024_00241206_00242454.Right = Expression.Lift(_0024codestr_00242424));
									Expression expression67 = (binaryExpression20.Left = _0024_00241206_00242454);
									BinaryExpression binaryExpression33 = _0024_00241208_00242456;
									StringLiteralExpression stringLiteralExpression7 = (_0024_00241207_00242455 = new StringLiteralExpression(LexicalInfo.Empty));
									string text20 = (_0024_00241207_00242455.Value = " -- message: ");
									Expression expression69 = (binaryExpression33.Right = _0024_00241207_00242455);
									Expression expression71 = (binaryExpression18.Left = _0024_00241208_00242456);
									Expression expression73 = (_0024_00241209_00242457.Right = Expression.Lift(_0024message_00242445));
									Expression expression75 = (binaryExpression16.Right = _0024_00241209_00242457);
									array2[0] = Statement.Lift(_0024_00241210_00242458);
									RaiseStatement raiseStatement2 = (_0024_00241211_00242459 = new RaiseStatement(LexicalInfo.Empty));
									Expression expression77 = (_0024_00241211_00242459.Exception = Expression.Lift(_0024msg_00242425));
									array2[1] = Statement.Lift(_0024_00241211_00242459);
									StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
									Block block8 = (ifStatement6.TrueBlock = _0024_00241212_00242460);
									result = (Yield(3, _0024_00241213_00242461) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`assert` failed to match `").Append(_0024_0024match_0024164_00242419).Append("`").ToString());
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

		internal MacroStatement _0024assert_00242464;

		internal AssertMacro _0024self__00242465;

		public _0024ExpandGeneratorImpl_00242418(MacroStatement assert, AssertMacro self_)
		{
			_0024assert_00242464 = assert;
			_0024self__00242465 = self_;
		}

		public override IEnumerator<Node> GetEnumerator()
		{
			return new _0024(_0024assert_00242464, _0024self__00242465);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public AssertMacro()
	{
	}

	public AssertMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement assert)
	{
		return new _0024ExpandGeneratorImpl_00242418(assert, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement assert)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'assert' is using. Read BOO-1077 for more info.");
	}
}
