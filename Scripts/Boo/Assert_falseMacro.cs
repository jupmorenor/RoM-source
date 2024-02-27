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
public sealed class Assert_falseMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422423 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002451_002422424;

			internal MacroStatement _0024_0024match_002452_002422425;

			internal Expression _0024req_002422426;

			internal Expression _0024target_002422427;

			internal Expression _0024text_002422428;

			internal ReferenceExpression _0024_00245169_002422429;

			internal MemberReferenceExpression _0024_00245170_002422430;

			internal StringLiteralExpression _0024_00245171_002422431;

			internal StringLiteralExpression _0024_00245172_002422432;

			internal ReferenceExpression _0024_00245173_002422433;

			internal MethodInvocationExpression _0024_00245174_002422434;

			internal StringLiteralExpression _0024_00245175_002422435;

			internal ExpressionInterpolationExpression _0024_00245176_002422436;

			internal MethodInvocationExpression _0024_00245177_002422437;

			internal MethodInvocationExpression _0024z_002422438;

			internal MacroStatement _0024_0024match_002453_002422439;

			internal ReferenceExpression _0024_00245178_002422440;

			internal MemberReferenceExpression _0024_00245179_002422441;

			internal StringLiteralExpression _0024_00245180_002422442;

			internal ReferenceExpression _0024_00245181_002422443;

			internal MethodInvocationExpression _0024_00245182_002422444;

			internal StringLiteralExpression _0024_00245183_002422445;

			internal ExpressionInterpolationExpression _0024_00245184_002422446;

			internal MethodInvocationExpression _0024_00245185_002422447;

			internal MacroStatement _0024assert_false_002422448;

			internal Assert_falseMacro _0024self__002422449;

			public _0024(MacroStatement assert_false, Assert_falseMacro self_)
			{
				_0024assert_false_002422448 = assert_false;
				_0024self__002422449 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024assert_false_002422448 == null)
					{
						throw new ArgumentNullException("assert_false");
					}
					_0024self__002422449.__macro = _0024assert_false_002422448;
					_0024_0024match_002451_002422424 = _0024assert_false_002422448;
					if (_0024_0024match_002451_002422424 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002452_002422425 = _0024_0024match_002451_002422424);
						if (true && _0024_0024match_002452_002422425.Name == "assert_false" && 3 == ((ICollection)_0024_0024match_002452_002422425.Arguments).Count)
						{
							Expression expression = (_0024req_002422426 = _0024_0024match_002452_002422425.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024target_002422427 = _0024_0024match_002452_002422425.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024text_002422428 = _0024_0024match_002452_002422425.Arguments[2]);
									if (true)
									{
										MethodInvocationExpression methodInvocationExpression = (_0024_00245177_002422437 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00245177_002422437;
										MemberReferenceExpression memberReferenceExpression = (_0024_00245170_002422430 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00245170_002422430.Name = "False");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00245170_002422430;
										ReferenceExpression referenceExpression = (_0024_00245169_002422429 = new ReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00245169_002422429.Name = "Assert");
										Expression expression5 = (memberReferenceExpression2.Target = _0024_00245169_002422429);
										Expression expression7 = (methodInvocationExpression2.Target = _0024_00245170_002422430);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00245177_002422437;
										Expression[] obj = new Expression[2]
										{
											Expression.Lift(_0024target_002422427),
											null
										};
										ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00245176_002422436 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
										ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00245176_002422436;
										Expression[] array = new Expression[5];
										StringLiteralExpression stringLiteralExpression = (_0024_00245171_002422431 = new StringLiteralExpression(LexicalInfo.Empty));
										string text5 = (_0024_00245171_002422431.Value = string.Empty);
										array[0] = _0024_00245171_002422431;
										array[1] = Expression.Lift(_0024text_002422428);
										StringLiteralExpression stringLiteralExpression2 = (_0024_00245172_002422432 = new StringLiteralExpression(LexicalInfo.Empty));
										string text7 = (_0024_00245172_002422432.Value = "\n ");
										array[2] = _0024_00245172_002422432;
										MethodInvocationExpression methodInvocationExpression4 = (_0024_00245174_002422434 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression5 = _0024_00245174_002422434;
										ReferenceExpression referenceExpression2 = (_0024_00245173_002422433 = new ReferenceExpression(LexicalInfo.Empty));
										string text9 = (_0024_00245173_002422433.Name = "readResponeString");
										Expression expression9 = (methodInvocationExpression5.Target = _0024_00245173_002422433);
										ExpressionCollection expressionCollection2 = (_0024_00245174_002422434.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422426)));
										array[3] = _0024_00245174_002422434;
										StringLiteralExpression stringLiteralExpression3 = (_0024_00245175_002422435 = new StringLiteralExpression(LexicalInfo.Empty));
										string text10 = (_0024_00245175_002422435.Value = string.Empty);
										array[4] = _0024_00245175_002422435;
										ExpressionCollection expressionCollection4 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array));
										obj[1] = _0024_00245176_002422436;
										ExpressionCollection expressionCollection6 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
										_0024z_002422438 = _0024_00245177_002422437;
										_0024z_002422438.LexicalInfo = _0024assert_false_002422448.LexicalInfo;
										result = (Yield(2, _0024z_002422438) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_002451_002422424 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002453_002422439 = _0024_0024match_002451_002422424);
						if (true && _0024_0024match_002453_002422439.Name == "assert_false" && 2 == ((ICollection)_0024_0024match_002453_002422439.Arguments).Count)
						{
							Expression expression10 = (_0024req_002422426 = _0024_0024match_002453_002422439.Arguments[0]);
							if (true)
							{
								Expression expression11 = (_0024target_002422427 = _0024_0024match_002453_002422439.Arguments[1]);
								if (true)
								{
									MethodInvocationExpression methodInvocationExpression6 = (_0024_00245185_002422447 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression7 = _0024_00245185_002422447;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00245179_002422441 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text12 = (_0024_00245179_002422441.Name = "False");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00245179_002422441;
									ReferenceExpression referenceExpression3 = (_0024_00245178_002422440 = new ReferenceExpression(LexicalInfo.Empty));
									string text14 = (_0024_00245178_002422440.Name = "Assert");
									Expression expression13 = (memberReferenceExpression4.Target = _0024_00245178_002422440);
									Expression expression15 = (methodInvocationExpression7.Target = _0024_00245179_002422441);
									MethodInvocationExpression methodInvocationExpression8 = _0024_00245185_002422447;
									Expression[] obj2 = new Expression[2]
									{
										Expression.Lift(_0024target_002422427),
										null
									};
									ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00245184_002422446 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
									ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00245184_002422446;
									Expression[] array2 = new Expression[3];
									StringLiteralExpression stringLiteralExpression4 = (_0024_00245180_002422442 = new StringLiteralExpression(LexicalInfo.Empty));
									string text15 = (_0024_00245180_002422442.Value = string.Empty);
									array2[0] = _0024_00245180_002422442;
									MethodInvocationExpression methodInvocationExpression9 = (_0024_00245182_002422444 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression10 = _0024_00245182_002422444;
									ReferenceExpression referenceExpression4 = (_0024_00245181_002422443 = new ReferenceExpression(LexicalInfo.Empty));
									string text17 = (_0024_00245181_002422443.Name = "readResponeString");
									Expression expression17 = (methodInvocationExpression10.Target = _0024_00245181_002422443);
									ExpressionCollection expressionCollection8 = (_0024_00245182_002422444.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422426)));
									array2[1] = _0024_00245182_002422444;
									StringLiteralExpression stringLiteralExpression5 = (_0024_00245183_002422445 = new StringLiteralExpression(LexicalInfo.Empty));
									string text18 = (_0024_00245183_002422445.Value = string.Empty);
									array2[2] = _0024_00245183_002422445;
									ExpressionCollection expressionCollection10 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array2));
									obj2[1] = _0024_00245184_002422446;
									ExpressionCollection expressionCollection12 = (methodInvocationExpression8.Arguments = ExpressionCollection.FromArray(obj2));
									_0024z_002422438 = _0024_00245185_002422447;
									_0024z_002422438.LexicalInfo = _0024assert_false_002422448.LexicalInfo;
									result = (Yield(3, _0024z_002422438) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`assert_false` failed to match `").Append(_0024_0024match_002451_002422424).Append("`").ToString());
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

		internal MacroStatement _0024assert_false_002422450;

		internal Assert_falseMacro _0024self__002422451;

		public _0024ExpandGeneratorImpl_002422423(MacroStatement assert_false, Assert_falseMacro self_)
		{
			_0024assert_false_002422450 = assert_false;
			_0024self__002422451 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024assert_false_002422450, _0024self__002422451);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Assert_falseMacro()
	{
	}

	public Assert_falseMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement assert_false)
	{
		return new _0024ExpandGeneratorImpl_002422423(assert_false, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement assert_false)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'assert_false' is using. Read BOO-1077 for more info.");
	}
}
