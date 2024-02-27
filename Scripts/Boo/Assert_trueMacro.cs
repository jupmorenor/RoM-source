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
public sealed class Assert_trueMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422394 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002448_002422395;

			internal MacroStatement _0024_0024match_002449_002422396;

			internal Expression _0024req_002422397;

			internal Expression _0024target_002422398;

			internal Expression _0024text_002422399;

			internal ReferenceExpression _0024_00245152_002422400;

			internal MemberReferenceExpression _0024_00245153_002422401;

			internal StringLiteralExpression _0024_00245154_002422402;

			internal StringLiteralExpression _0024_00245155_002422403;

			internal ReferenceExpression _0024_00245156_002422404;

			internal MethodInvocationExpression _0024_00245157_002422405;

			internal StringLiteralExpression _0024_00245158_002422406;

			internal ExpressionInterpolationExpression _0024_00245159_002422407;

			internal MethodInvocationExpression _0024_00245160_002422408;

			internal MethodInvocationExpression _0024z_002422409;

			internal MacroStatement _0024_0024match_002450_002422410;

			internal ReferenceExpression _0024_00245161_002422411;

			internal MemberReferenceExpression _0024_00245162_002422412;

			internal StringLiteralExpression _0024_00245163_002422413;

			internal ReferenceExpression _0024_00245164_002422414;

			internal MethodInvocationExpression _0024_00245165_002422415;

			internal StringLiteralExpression _0024_00245166_002422416;

			internal ExpressionInterpolationExpression _0024_00245167_002422417;

			internal MethodInvocationExpression _0024_00245168_002422418;

			internal MacroStatement _0024assert_true_002422419;

			internal Assert_trueMacro _0024self__002422420;

			public _0024(MacroStatement assert_true, Assert_trueMacro self_)
			{
				_0024assert_true_002422419 = assert_true;
				_0024self__002422420 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024assert_true_002422419 == null)
					{
						throw new ArgumentNullException("assert_true");
					}
					_0024self__002422420.__macro = _0024assert_true_002422419;
					_0024_0024match_002448_002422395 = _0024assert_true_002422419;
					if (_0024_0024match_002448_002422395 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002449_002422396 = _0024_0024match_002448_002422395);
						if (true && _0024_0024match_002449_002422396.Name == "assert_true" && 3 == ((ICollection)_0024_0024match_002449_002422396.Arguments).Count)
						{
							Expression expression = (_0024req_002422397 = _0024_0024match_002449_002422396.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024target_002422398 = _0024_0024match_002449_002422396.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024text_002422399 = _0024_0024match_002449_002422396.Arguments[2]);
									if (true)
									{
										MethodInvocationExpression methodInvocationExpression = (_0024_00245160_002422408 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00245160_002422408;
										MemberReferenceExpression memberReferenceExpression = (_0024_00245153_002422401 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00245153_002422401.Name = "True");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00245153_002422401;
										ReferenceExpression referenceExpression = (_0024_00245152_002422400 = new ReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00245152_002422400.Name = "Assert");
										Expression expression5 = (memberReferenceExpression2.Target = _0024_00245152_002422400);
										Expression expression7 = (methodInvocationExpression2.Target = _0024_00245153_002422401);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00245160_002422408;
										Expression[] obj = new Expression[2]
										{
											Expression.Lift(_0024target_002422398),
											null
										};
										ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00245159_002422407 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
										ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00245159_002422407;
										Expression[] array = new Expression[5];
										StringLiteralExpression stringLiteralExpression = (_0024_00245154_002422402 = new StringLiteralExpression(LexicalInfo.Empty));
										string text5 = (_0024_00245154_002422402.Value = string.Empty);
										array[0] = _0024_00245154_002422402;
										array[1] = Expression.Lift(_0024text_002422399);
										StringLiteralExpression stringLiteralExpression2 = (_0024_00245155_002422403 = new StringLiteralExpression(LexicalInfo.Empty));
										string text7 = (_0024_00245155_002422403.Value = "\n ");
										array[2] = _0024_00245155_002422403;
										MethodInvocationExpression methodInvocationExpression4 = (_0024_00245157_002422405 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression5 = _0024_00245157_002422405;
										ReferenceExpression referenceExpression2 = (_0024_00245156_002422404 = new ReferenceExpression(LexicalInfo.Empty));
										string text9 = (_0024_00245156_002422404.Name = "readResponeString");
										Expression expression9 = (methodInvocationExpression5.Target = _0024_00245156_002422404);
										ExpressionCollection expressionCollection2 = (_0024_00245157_002422405.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422397)));
										array[3] = _0024_00245157_002422405;
										StringLiteralExpression stringLiteralExpression3 = (_0024_00245158_002422406 = new StringLiteralExpression(LexicalInfo.Empty));
										string text10 = (_0024_00245158_002422406.Value = string.Empty);
										array[4] = _0024_00245158_002422406;
										ExpressionCollection expressionCollection4 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array));
										obj[1] = _0024_00245159_002422407;
										ExpressionCollection expressionCollection6 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
										_0024z_002422409 = _0024_00245160_002422408;
										_0024z_002422409.LexicalInfo = _0024assert_true_002422419.LexicalInfo;
										result = (Yield(2, _0024z_002422409) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_002448_002422395 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002450_002422410 = _0024_0024match_002448_002422395);
						if (true && _0024_0024match_002450_002422410.Name == "assert_true" && 2 == ((ICollection)_0024_0024match_002450_002422410.Arguments).Count)
						{
							Expression expression10 = (_0024req_002422397 = _0024_0024match_002450_002422410.Arguments[0]);
							if (true)
							{
								Expression expression11 = (_0024target_002422398 = _0024_0024match_002450_002422410.Arguments[1]);
								if (true)
								{
									MethodInvocationExpression methodInvocationExpression6 = (_0024_00245168_002422418 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression7 = _0024_00245168_002422418;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00245162_002422412 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text12 = (_0024_00245162_002422412.Name = "True");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00245162_002422412;
									ReferenceExpression referenceExpression3 = (_0024_00245161_002422411 = new ReferenceExpression(LexicalInfo.Empty));
									string text14 = (_0024_00245161_002422411.Name = "Assert");
									Expression expression13 = (memberReferenceExpression4.Target = _0024_00245161_002422411);
									Expression expression15 = (methodInvocationExpression7.Target = _0024_00245162_002422412);
									MethodInvocationExpression methodInvocationExpression8 = _0024_00245168_002422418;
									Expression[] obj2 = new Expression[2]
									{
										Expression.Lift(_0024target_002422398),
										null
									};
									ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00245167_002422417 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
									ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00245167_002422417;
									Expression[] array2 = new Expression[3];
									StringLiteralExpression stringLiteralExpression4 = (_0024_00245163_002422413 = new StringLiteralExpression(LexicalInfo.Empty));
									string text15 = (_0024_00245163_002422413.Value = string.Empty);
									array2[0] = _0024_00245163_002422413;
									MethodInvocationExpression methodInvocationExpression9 = (_0024_00245165_002422415 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression10 = _0024_00245165_002422415;
									ReferenceExpression referenceExpression4 = (_0024_00245164_002422414 = new ReferenceExpression(LexicalInfo.Empty));
									string text17 = (_0024_00245164_002422414.Name = "readResponeString");
									Expression expression17 = (methodInvocationExpression10.Target = _0024_00245164_002422414);
									ExpressionCollection expressionCollection8 = (_0024_00245165_002422415.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422397)));
									array2[1] = _0024_00245165_002422415;
									StringLiteralExpression stringLiteralExpression5 = (_0024_00245166_002422416 = new StringLiteralExpression(LexicalInfo.Empty));
									string text18 = (_0024_00245166_002422416.Value = string.Empty);
									array2[2] = _0024_00245166_002422416;
									ExpressionCollection expressionCollection10 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array2));
									obj2[1] = _0024_00245167_002422417;
									ExpressionCollection expressionCollection12 = (methodInvocationExpression8.Arguments = ExpressionCollection.FromArray(obj2));
									_0024z_002422409 = _0024_00245168_002422418;
									_0024z_002422409.LexicalInfo = _0024assert_true_002422419.LexicalInfo;
									result = (Yield(3, _0024z_002422409) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`assert_true` failed to match `").Append(_0024_0024match_002448_002422395).Append("`").ToString());
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

		internal MacroStatement _0024assert_true_002422421;

		internal Assert_trueMacro _0024self__002422422;

		public _0024ExpandGeneratorImpl_002422394(MacroStatement assert_true, Assert_trueMacro self_)
		{
			_0024assert_true_002422421 = assert_true;
			_0024self__002422422 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024assert_true_002422421, _0024self__002422422);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Assert_trueMacro()
	{
	}

	public Assert_trueMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement assert_true)
	{
		return new _0024ExpandGeneratorImpl_002422394(assert_true, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement assert_true)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'assert_true' is using. Read BOO-1077 for more info.");
	}
}
