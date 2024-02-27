using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Mac_assertMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002416781 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_00248_002416782;

			internal MacroStatement _0024_0024match_00249_002416783;

			internal Expression _0024condition_002416784;

			internal Expression _0024message_002416785;

			internal string _0024src_002416786;

			internal int _0024line_002416787;

			internal string _0024codestr_002416788;

			internal ReferenceExpression _0024msg_002416789;

			internal UnaryExpression _0024_00244283_002416790;

			internal StringLiteralExpression _0024_00244284_002416791;

			internal BinaryExpression _0024_00244285_002416792;

			internal StringLiteralExpression _0024_00244286_002416793;

			internal BinaryExpression _0024_00244287_002416794;

			internal BinaryExpression _0024_00244288_002416795;

			internal StringLiteralExpression _0024_00244289_002416796;

			internal BinaryExpression _0024_00244290_002416797;

			internal BinaryExpression _0024_00244291_002416798;

			internal StringLiteralExpression _0024_00244292_002416799;

			internal BinaryExpression _0024_00244293_002416800;

			internal BinaryExpression _0024_00244294_002416801;

			internal BinaryExpression _0024_00244295_002416802;

			internal ReferenceExpression _0024_00244296_002416803;

			internal MemberReferenceExpression _0024_00244297_002416804;

			internal MemberReferenceExpression _0024_00244298_002416805;

			internal MethodInvocationExpression _0024_00244299_002416806;

			internal Block _0024_00244300_002416807;

			internal IfStatement _0024_00244301_002416808;

			internal IfStatement _0024b_002416809;

			internal MacroStatement _0024mac_assert_002416810;

			internal Mac_assertMacro _0024self__002416811;

			public _0024(MacroStatement mac_assert, Mac_assertMacro self_)
			{
				_0024mac_assert_002416810 = mac_assert;
				_0024self__002416811 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024mac_assert_002416810 == null)
					{
						throw new ArgumentNullException("mac_assert");
					}
					_0024self__002416811.__macro = _0024mac_assert_002416810;
					_0024_0024match_00248_002416782 = _0024mac_assert_002416810;
					if (_0024_0024match_00248_002416782 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_00249_002416783 = _0024_0024match_00248_002416782);
						if (true && _0024_0024match_00249_002416783.Name == "mac_assert" && 2 == ((ICollection)_0024_0024match_00249_002416783.Arguments).Count && _0024_0024match_00249_002416783.Arguments[0] is Expression)
						{
							Expression expression = (_0024condition_002416784 = _0024_0024match_00249_002416783.Arguments[0]);
							if (true && _0024_0024match_00249_002416783.Arguments[1] is Expression)
							{
								Expression expression2 = (_0024message_002416785 = _0024_0024match_00249_002416783.Arguments[1]);
								if (true)
								{
									_0024src_002416786 = Path.GetFileNameWithoutExtension(_0024mac_assert_002416810.LexicalInfo.FileName);
									_0024line_002416787 = _0024mac_assert_002416810.LexicalInfo.Line;
									_0024codestr_002416788 = _0024condition_002416784.ToCodeString();
									_0024msg_002416789 = new ReferenceExpression(_0024self__002416811.Context.GetUniqueName("mac_assert2"));
									IfStatement ifStatement = (_0024_00244301_002416808 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement2 = _0024_00244301_002416808;
									UnaryExpression unaryExpression = (_0024_00244283_002416790 = new UnaryExpression(LexicalInfo.Empty));
									UnaryOperatorType unaryOperatorType2 = (_0024_00244283_002416790.Operator = UnaryOperatorType.LogicalNot);
									Expression expression4 = (_0024_00244283_002416790.Operand = Expression.Lift(_0024condition_002416784));
									Expression expression6 = (ifStatement2.Condition = _0024_00244283_002416790);
									IfStatement ifStatement3 = _0024_00244301_002416808;
									Block block = (_0024_00244300_002416807 = new Block(LexicalInfo.Empty));
									Block block2 = _0024_00244300_002416807;
									Statement[] array = new Statement[3];
									BinaryExpression binaryExpression = (_0024_00244295_002416802 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00244295_002416802.Operator = BinaryOperatorType.Assign);
									Expression expression8 = (_0024_00244295_002416802.Left = Expression.Lift(_0024msg_002416789));
									BinaryExpression binaryExpression2 = _0024_00244295_002416802;
									BinaryExpression binaryExpression3 = (_0024_00244294_002416801 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00244294_002416801.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression4 = _0024_00244294_002416801;
									BinaryExpression binaryExpression5 = (_0024_00244293_002416800 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType6 = (_0024_00244293_002416800.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression6 = _0024_00244293_002416800;
									BinaryExpression binaryExpression7 = (_0024_00244291_002416798 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType8 = (_0024_00244291_002416798.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression8 = _0024_00244291_002416798;
									BinaryExpression binaryExpression9 = (_0024_00244290_002416797 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType10 = (_0024_00244290_002416797.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression10 = _0024_00244290_002416797;
									BinaryExpression binaryExpression11 = (_0024_00244288_002416795 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType12 = (_0024_00244288_002416795.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression12 = _0024_00244288_002416795;
									BinaryExpression binaryExpression13 = (_0024_00244287_002416794 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType14 = (_0024_00244287_002416794.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression14 = _0024_00244287_002416794;
									BinaryExpression binaryExpression15 = (_0024_00244285_002416792 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType16 = (_0024_00244285_002416792.Operator = BinaryOperatorType.Addition);
									BinaryExpression binaryExpression16 = _0024_00244285_002416792;
									StringLiteralExpression stringLiteralExpression = (_0024_00244284_002416791 = new StringLiteralExpression(LexicalInfo.Empty));
									string text2 = (_0024_00244284_002416791.Value = "MAC_ASSERT at ");
									Expression expression10 = (binaryExpression16.Left = _0024_00244284_002416791);
									Expression expression12 = (_0024_00244285_002416792.Right = Expression.Lift(_0024src_002416786));
									Expression expression14 = (binaryExpression14.Left = _0024_00244285_002416792);
									BinaryExpression binaryExpression17 = _0024_00244287_002416794;
									StringLiteralExpression stringLiteralExpression2 = (_0024_00244286_002416793 = new StringLiteralExpression(LexicalInfo.Empty));
									string text4 = (_0024_00244286_002416793.Value = "(");
									Expression expression16 = (binaryExpression17.Right = _0024_00244286_002416793);
									Expression expression18 = (binaryExpression12.Left = _0024_00244287_002416794);
									Expression expression20 = (_0024_00244288_002416795.Right = Expression.Lift(_0024line_002416787));
									Expression expression22 = (binaryExpression10.Left = _0024_00244288_002416795);
									BinaryExpression binaryExpression18 = _0024_00244290_002416797;
									StringLiteralExpression stringLiteralExpression3 = (_0024_00244289_002416796 = new StringLiteralExpression(LexicalInfo.Empty));
									string text6 = (_0024_00244289_002416796.Value = "):");
									Expression expression24 = (binaryExpression18.Right = _0024_00244289_002416796);
									Expression expression26 = (binaryExpression8.Left = _0024_00244290_002416797);
									Expression expression28 = (_0024_00244291_002416798.Right = Expression.Lift(_0024codestr_002416788));
									Expression expression30 = (binaryExpression6.Left = _0024_00244291_002416798);
									BinaryExpression binaryExpression19 = _0024_00244293_002416800;
									StringLiteralExpression stringLiteralExpression4 = (_0024_00244292_002416799 = new StringLiteralExpression(LexicalInfo.Empty));
									string text8 = (_0024_00244292_002416799.Value = " -- message: ");
									Expression expression32 = (binaryExpression19.Right = _0024_00244292_002416799);
									Expression expression34 = (binaryExpression4.Left = _0024_00244293_002416800);
									Expression expression36 = (_0024_00244294_002416801.Right = Expression.Lift(_0024message_002416785));
									Expression expression38 = (binaryExpression2.Right = _0024_00244294_002416801);
									array[0] = Statement.Lift(_0024_00244295_002416802);
									MethodInvocationExpression methodInvocationExpression = (_0024_00244299_002416806 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression2 = _0024_00244299_002416806;
									MemberReferenceExpression memberReferenceExpression = (_0024_00244298_002416805 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text10 = (_0024_00244298_002416805.Name = "LogError");
									MemberReferenceExpression memberReferenceExpression2 = _0024_00244298_002416805;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00244297_002416804 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text12 = (_0024_00244297_002416804.Name = "Debug");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00244297_002416804;
									ReferenceExpression referenceExpression = (_0024_00244296_002416803 = new ReferenceExpression(LexicalInfo.Empty));
									string text14 = (_0024_00244296_002416803.Name = "UnityEngine");
									Expression expression40 = (memberReferenceExpression4.Target = _0024_00244296_002416803);
									Expression expression42 = (memberReferenceExpression2.Target = _0024_00244297_002416804);
									Expression expression44 = (methodInvocationExpression2.Target = _0024_00244298_002416805);
									ExpressionCollection expressionCollection2 = (_0024_00244299_002416806.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024msg_002416789)));
									array[1] = Statement.Lift(_0024_00244299_002416806);
									array[2] = Statement.Lift(new ReturnStatement(LexicalInfo.Empty));
									StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
									Block block4 = (ifStatement3.TrueBlock = _0024_00244300_002416807);
									_0024b_002416809 = _0024_00244301_002416808;
									_0024b_002416809.LexicalInfo = _0024mac_assert_002416810.LexicalInfo;
									result = (Yield(2, _0024b_002416809) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new Exception("`mac_assert` macro invocation argument(s) did not match definition: `mac_assert(condition, message)`");
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

		internal MacroStatement _0024mac_assert_002416812;

		internal Mac_assertMacro _0024self__002416813;

		public _0024ExpandGeneratorImpl_002416781(MacroStatement mac_assert, Mac_assertMacro self_)
		{
			_0024mac_assert_002416812 = mac_assert;
			_0024self__002416813 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mac_assert_002416812, _0024self__002416813);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Mac_assertMacro()
	{
	}

	public Mac_assertMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mac_assert)
	{
		return new _0024ExpandGeneratorImpl_002416781(mac_assert, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement mac_assert)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'mac_assert' is using. Read BOO-1077 for more info.");
	}
}
