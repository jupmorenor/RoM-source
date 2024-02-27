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
public sealed class Assert_equalMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422452 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002454_002422453;

			internal MacroStatement _0024_0024match_002455_002422454;

			internal Expression _0024req_002422455;

			internal Expression _0024src_002422456;

			internal Expression _0024dst_002422457;

			internal Expression _0024text_002422458;

			internal ReferenceExpression _0024_00245186_002422459;

			internal MemberReferenceExpression _0024_00245187_002422460;

			internal StringLiteralExpression _0024_00245188_002422461;

			internal StringLiteralExpression _0024_00245189_002422462;

			internal ReferenceExpression _0024_00245190_002422463;

			internal MethodInvocationExpression _0024_00245191_002422464;

			internal StringLiteralExpression _0024_00245192_002422465;

			internal ExpressionInterpolationExpression _0024_00245193_002422466;

			internal MethodInvocationExpression _0024_00245194_002422467;

			internal MethodInvocationExpression _0024z_002422468;

			internal MacroStatement _0024_0024match_002456_002422469;

			internal ReferenceExpression _0024_00245195_002422470;

			internal MemberReferenceExpression _0024_00245196_002422471;

			internal StringLiteralExpression _0024_00245197_002422472;

			internal ReferenceExpression _0024_00245198_002422473;

			internal MethodInvocationExpression _0024_00245199_002422474;

			internal StringLiteralExpression _0024_00245200_002422475;

			internal ExpressionInterpolationExpression _0024_00245201_002422476;

			internal MethodInvocationExpression _0024_00245202_002422477;

			internal MacroStatement _0024assert_equal_002422478;

			internal Assert_equalMacro _0024self__002422479;

			public _0024(MacroStatement assert_equal, Assert_equalMacro self_)
			{
				_0024assert_equal_002422478 = assert_equal;
				_0024self__002422479 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024assert_equal_002422478 == null)
					{
						throw new ArgumentNullException("assert_equal");
					}
					_0024self__002422479.__macro = _0024assert_equal_002422478;
					_0024_0024match_002454_002422453 = _0024assert_equal_002422478;
					if (_0024_0024match_002454_002422453 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002455_002422454 = _0024_0024match_002454_002422453);
						if (true && _0024_0024match_002455_002422454.Name == "assert_equal" && 4 == ((ICollection)_0024_0024match_002455_002422454.Arguments).Count)
						{
							Expression expression = (_0024req_002422455 = _0024_0024match_002455_002422454.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024src_002422456 = _0024_0024match_002455_002422454.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024dst_002422457 = _0024_0024match_002455_002422454.Arguments[2]);
									if (true)
									{
										Expression expression4 = (_0024text_002422458 = _0024_0024match_002455_002422454.Arguments[3]);
										if (true)
										{
											MethodInvocationExpression methodInvocationExpression = (_0024_00245194_002422467 = new MethodInvocationExpression(LexicalInfo.Empty));
											MethodInvocationExpression methodInvocationExpression2 = _0024_00245194_002422467;
											MemberReferenceExpression memberReferenceExpression = (_0024_00245187_002422460 = new MemberReferenceExpression(LexicalInfo.Empty));
											string text2 = (_0024_00245187_002422460.Name = "Equal");
											MemberReferenceExpression memberReferenceExpression2 = _0024_00245187_002422460;
											ReferenceExpression referenceExpression = (_0024_00245186_002422459 = new ReferenceExpression(LexicalInfo.Empty));
											string text4 = (_0024_00245186_002422459.Name = "Assert");
											Expression expression6 = (memberReferenceExpression2.Target = _0024_00245186_002422459);
											Expression expression8 = (methodInvocationExpression2.Target = _0024_00245187_002422460);
											MethodInvocationExpression methodInvocationExpression3 = _0024_00245194_002422467;
											Expression[] obj = new Expression[3]
											{
												Expression.Lift(_0024src_002422456),
												Expression.Lift(_0024dst_002422457),
												null
											};
											ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00245193_002422466 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
											ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00245193_002422466;
											Expression[] array = new Expression[5];
											StringLiteralExpression stringLiteralExpression = (_0024_00245188_002422461 = new StringLiteralExpression(LexicalInfo.Empty));
											string text5 = (_0024_00245188_002422461.Value = string.Empty);
											array[0] = _0024_00245188_002422461;
											array[1] = Expression.Lift(_0024text_002422458);
											StringLiteralExpression stringLiteralExpression2 = (_0024_00245189_002422462 = new StringLiteralExpression(LexicalInfo.Empty));
											string text7 = (_0024_00245189_002422462.Value = "\n ");
											array[2] = _0024_00245189_002422462;
											MethodInvocationExpression methodInvocationExpression4 = (_0024_00245191_002422464 = new MethodInvocationExpression(LexicalInfo.Empty));
											MethodInvocationExpression methodInvocationExpression5 = _0024_00245191_002422464;
											ReferenceExpression referenceExpression2 = (_0024_00245190_002422463 = new ReferenceExpression(LexicalInfo.Empty));
											string text9 = (_0024_00245190_002422463.Name = "readResponeString");
											Expression expression10 = (methodInvocationExpression5.Target = _0024_00245190_002422463);
											ExpressionCollection expressionCollection2 = (_0024_00245191_002422464.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422455)));
											array[3] = _0024_00245191_002422464;
											StringLiteralExpression stringLiteralExpression3 = (_0024_00245192_002422465 = new StringLiteralExpression(LexicalInfo.Empty));
											string text10 = (_0024_00245192_002422465.Value = string.Empty);
											array[4] = _0024_00245192_002422465;
											ExpressionCollection expressionCollection4 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array));
											obj[2] = _0024_00245193_002422466;
											ExpressionCollection expressionCollection6 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
											_0024z_002422468 = _0024_00245194_002422467;
											_0024z_002422468.LexicalInfo = _0024assert_equal_002422478.LexicalInfo;
											result = (Yield(2, _0024z_002422468) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
					}
					if (_0024_0024match_002454_002422453 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002456_002422469 = _0024_0024match_002454_002422453);
						if (true && _0024_0024match_002456_002422469.Name == "assert_equal" && 3 == ((ICollection)_0024_0024match_002456_002422469.Arguments).Count)
						{
							Expression expression11 = (_0024req_002422455 = _0024_0024match_002456_002422469.Arguments[0]);
							if (true)
							{
								Expression expression12 = (_0024src_002422456 = _0024_0024match_002456_002422469.Arguments[1]);
								if (true)
								{
									Expression expression13 = (_0024dst_002422457 = _0024_0024match_002456_002422469.Arguments[2]);
									if (true)
									{
										MethodInvocationExpression methodInvocationExpression6 = (_0024_00245202_002422477 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression7 = _0024_00245202_002422477;
										MemberReferenceExpression memberReferenceExpression3 = (_0024_00245196_002422471 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text12 = (_0024_00245196_002422471.Name = "Equal");
										MemberReferenceExpression memberReferenceExpression4 = _0024_00245196_002422471;
										ReferenceExpression referenceExpression3 = (_0024_00245195_002422470 = new ReferenceExpression(LexicalInfo.Empty));
										string text14 = (_0024_00245195_002422470.Name = "Assert");
										Expression expression15 = (memberReferenceExpression4.Target = _0024_00245195_002422470);
										Expression expression17 = (methodInvocationExpression7.Target = _0024_00245196_002422471);
										MethodInvocationExpression methodInvocationExpression8 = _0024_00245202_002422477;
										Expression[] obj2 = new Expression[3]
										{
											Expression.Lift(_0024src_002422456),
											Expression.Lift(_0024dst_002422457),
											null
										};
										ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00245201_002422476 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
										ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00245201_002422476;
										Expression[] array2 = new Expression[3];
										StringLiteralExpression stringLiteralExpression4 = (_0024_00245197_002422472 = new StringLiteralExpression(LexicalInfo.Empty));
										string text15 = (_0024_00245197_002422472.Value = string.Empty);
										array2[0] = _0024_00245197_002422472;
										MethodInvocationExpression methodInvocationExpression9 = (_0024_00245199_002422474 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression10 = _0024_00245199_002422474;
										ReferenceExpression referenceExpression4 = (_0024_00245198_002422473 = new ReferenceExpression(LexicalInfo.Empty));
										string text17 = (_0024_00245198_002422473.Name = "readResponeString");
										Expression expression19 = (methodInvocationExpression10.Target = _0024_00245198_002422473);
										ExpressionCollection expressionCollection8 = (_0024_00245199_002422474.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422455)));
										array2[1] = _0024_00245199_002422474;
										StringLiteralExpression stringLiteralExpression5 = (_0024_00245200_002422475 = new StringLiteralExpression(LexicalInfo.Empty));
										string text18 = (_0024_00245200_002422475.Value = string.Empty);
										array2[2] = _0024_00245200_002422475;
										ExpressionCollection expressionCollection10 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array2));
										obj2[2] = _0024_00245201_002422476;
										ExpressionCollection expressionCollection12 = (methodInvocationExpression8.Arguments = ExpressionCollection.FromArray(obj2));
										_0024z_002422468 = _0024_00245202_002422477;
										_0024z_002422468.LexicalInfo = _0024assert_equal_002422478.LexicalInfo;
										result = (Yield(3, _0024z_002422468) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`assert_equal` failed to match `").Append(_0024_0024match_002454_002422453).Append("`").ToString());
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

		internal MacroStatement _0024assert_equal_002422480;

		internal Assert_equalMacro _0024self__002422481;

		public _0024ExpandGeneratorImpl_002422452(MacroStatement assert_equal, Assert_equalMacro self_)
		{
			_0024assert_equal_002422480 = assert_equal;
			_0024self__002422481 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024assert_equal_002422480, _0024self__002422481);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Assert_equalMacro()
	{
	}

	public Assert_equalMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement assert_equal)
	{
		return new _0024ExpandGeneratorImpl_002422452(assert_equal, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement assert_equal)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'assert_equal' is using. Read BOO-1077 for more info.");
	}
}
