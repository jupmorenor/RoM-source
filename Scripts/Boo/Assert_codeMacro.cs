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
public sealed class Assert_codeMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422482 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002457_002422483;

			internal MacroStatement _0024_0024match_002458_002422484;

			internal Expression _0024req_002422485;

			internal Expression _0024statuscode_002422486;

			internal Expression _0024text_002422487;

			internal ReferenceExpression _0024_00245203_002422488;

			internal MemberReferenceExpression _0024_00245204_002422489;

			internal ReferenceExpression _0024_00245205_002422490;

			internal MethodInvocationExpression _0024_00245206_002422491;

			internal StringLiteralExpression _0024_00245207_002422492;

			internal StringLiteralExpression _0024_00245208_002422493;

			internal ReferenceExpression _0024_00245209_002422494;

			internal MethodInvocationExpression _0024_00245210_002422495;

			internal StringLiteralExpression _0024_00245211_002422496;

			internal ExpressionInterpolationExpression _0024_00245212_002422497;

			internal MethodInvocationExpression _0024_00245213_002422498;

			internal MethodInvocationExpression _0024z_002422499;

			internal MacroStatement _0024_0024match_002459_002422500;

			internal ReferenceExpression _0024_00245214_002422501;

			internal MemberReferenceExpression _0024_00245215_002422502;

			internal ReferenceExpression _0024_00245216_002422503;

			internal MethodInvocationExpression _0024_00245217_002422504;

			internal StringLiteralExpression _0024_00245218_002422505;

			internal ReferenceExpression _0024_00245219_002422506;

			internal MethodInvocationExpression _0024_00245220_002422507;

			internal StringLiteralExpression _0024_00245221_002422508;

			internal ExpressionInterpolationExpression _0024_00245222_002422509;

			internal MethodInvocationExpression _0024_00245223_002422510;

			internal MacroStatement _0024assert_code_002422511;

			internal Assert_codeMacro _0024self__002422512;

			public _0024(MacroStatement assert_code, Assert_codeMacro self_)
			{
				_0024assert_code_002422511 = assert_code;
				_0024self__002422512 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024assert_code_002422511 == null)
					{
						throw new ArgumentNullException("assert_code");
					}
					_0024self__002422512.__macro = _0024assert_code_002422511;
					_0024_0024match_002457_002422483 = _0024assert_code_002422511;
					if (_0024_0024match_002457_002422483 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002458_002422484 = _0024_0024match_002457_002422483);
						if (true && _0024_0024match_002458_002422484.Name == "assert_code" && 3 == ((ICollection)_0024_0024match_002458_002422484.Arguments).Count)
						{
							Expression expression = (_0024req_002422485 = _0024_0024match_002458_002422484.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024statuscode_002422486 = _0024_0024match_002458_002422484.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024text_002422487 = _0024_0024match_002458_002422484.Arguments[2]);
									if (true)
									{
										MethodInvocationExpression methodInvocationExpression = (_0024_00245213_002422498 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00245213_002422498;
										MemberReferenceExpression memberReferenceExpression = (_0024_00245204_002422489 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00245204_002422489.Name = "Equal");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00245204_002422489;
										ReferenceExpression referenceExpression = (_0024_00245203_002422488 = new ReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00245203_002422488.Name = "Assert");
										Expression expression5 = (memberReferenceExpression2.Target = _0024_00245203_002422488);
										Expression expression7 = (methodInvocationExpression2.Target = _0024_00245204_002422489);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00245213_002422498;
										Expression[] array = new Expression[3];
										MethodInvocationExpression methodInvocationExpression4 = (_0024_00245206_002422491 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression5 = _0024_00245206_002422491;
										ReferenceExpression referenceExpression2 = (_0024_00245205_002422490 = new ReferenceExpression(LexicalInfo.Empty));
										string text6 = (_0024_00245205_002422490.Name = "lookStatusCodeInReq");
										Expression expression9 = (methodInvocationExpression5.Target = _0024_00245205_002422490);
										ExpressionCollection expressionCollection2 = (_0024_00245206_002422491.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422485)));
										array[0] = _0024_00245206_002422491;
										array[1] = Expression.Lift(_0024statuscode_002422486);
										ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00245212_002422497 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
										ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00245212_002422497;
										Expression[] array2 = new Expression[5];
										StringLiteralExpression stringLiteralExpression = (_0024_00245207_002422492 = new StringLiteralExpression(LexicalInfo.Empty));
										string text7 = (_0024_00245207_002422492.Value = string.Empty);
										array2[0] = _0024_00245207_002422492;
										array2[1] = Expression.Lift(_0024text_002422487);
										StringLiteralExpression stringLiteralExpression2 = (_0024_00245208_002422493 = new StringLiteralExpression(LexicalInfo.Empty));
										string text9 = (_0024_00245208_002422493.Value = "\n ");
										array2[2] = _0024_00245208_002422493;
										MethodInvocationExpression methodInvocationExpression6 = (_0024_00245210_002422495 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression7 = _0024_00245210_002422495;
										ReferenceExpression referenceExpression3 = (_0024_00245209_002422494 = new ReferenceExpression(LexicalInfo.Empty));
										string text11 = (_0024_00245209_002422494.Name = "readResponeString");
										Expression expression11 = (methodInvocationExpression7.Target = _0024_00245209_002422494);
										ExpressionCollection expressionCollection4 = (_0024_00245210_002422495.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422485)));
										array2[3] = _0024_00245210_002422495;
										StringLiteralExpression stringLiteralExpression3 = (_0024_00245211_002422496 = new StringLiteralExpression(LexicalInfo.Empty));
										string text12 = (_0024_00245211_002422496.Value = string.Empty);
										array2[4] = _0024_00245211_002422496;
										ExpressionCollection expressionCollection6 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array2));
										array[2] = _0024_00245212_002422497;
										ExpressionCollection expressionCollection8 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array));
										_0024z_002422499 = _0024_00245213_002422498;
										_0024z_002422499.LexicalInfo = _0024assert_code_002422511.LexicalInfo;
										result = (Yield(2, _0024z_002422499) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_002457_002422483 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002459_002422500 = _0024_0024match_002457_002422483);
						if (true && _0024_0024match_002459_002422500.Name == "assert_code" && 2 == ((ICollection)_0024_0024match_002459_002422500.Arguments).Count)
						{
							Expression expression12 = (_0024req_002422485 = _0024_0024match_002459_002422500.Arguments[0]);
							if (true)
							{
								Expression expression13 = (_0024statuscode_002422486 = _0024_0024match_002459_002422500.Arguments[1]);
								if (true)
								{
									MethodInvocationExpression methodInvocationExpression8 = (_0024_00245223_002422510 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression9 = _0024_00245223_002422510;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00245215_002422502 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text14 = (_0024_00245215_002422502.Name = "Equal");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00245215_002422502;
									ReferenceExpression referenceExpression4 = (_0024_00245214_002422501 = new ReferenceExpression(LexicalInfo.Empty));
									string text16 = (_0024_00245214_002422501.Name = "Assert");
									Expression expression15 = (memberReferenceExpression4.Target = _0024_00245214_002422501);
									Expression expression17 = (methodInvocationExpression9.Target = _0024_00245215_002422502);
									MethodInvocationExpression methodInvocationExpression10 = _0024_00245223_002422510;
									Expression[] array3 = new Expression[3];
									MethodInvocationExpression methodInvocationExpression11 = (_0024_00245217_002422504 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression12 = _0024_00245217_002422504;
									ReferenceExpression referenceExpression5 = (_0024_00245216_002422503 = new ReferenceExpression(LexicalInfo.Empty));
									string text18 = (_0024_00245216_002422503.Name = "lookStatusCodeInReq");
									Expression expression19 = (methodInvocationExpression12.Target = _0024_00245216_002422503);
									ExpressionCollection expressionCollection10 = (_0024_00245217_002422504.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422485)));
									array3[0] = _0024_00245217_002422504;
									array3[1] = Expression.Lift(_0024statuscode_002422486);
									ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00245222_002422509 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
									ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00245222_002422509;
									Expression[] array4 = new Expression[3];
									StringLiteralExpression stringLiteralExpression4 = (_0024_00245218_002422505 = new StringLiteralExpression(LexicalInfo.Empty));
									string text19 = (_0024_00245218_002422505.Value = string.Empty);
									array4[0] = _0024_00245218_002422505;
									MethodInvocationExpression methodInvocationExpression13 = (_0024_00245220_002422507 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression14 = _0024_00245220_002422507;
									ReferenceExpression referenceExpression6 = (_0024_00245219_002422506 = new ReferenceExpression(LexicalInfo.Empty));
									string text21 = (_0024_00245219_002422506.Name = "readResponeString");
									Expression expression21 = (methodInvocationExpression14.Target = _0024_00245219_002422506);
									ExpressionCollection expressionCollection12 = (_0024_00245220_002422507.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024req_002422485)));
									array4[1] = _0024_00245220_002422507;
									StringLiteralExpression stringLiteralExpression5 = (_0024_00245221_002422508 = new StringLiteralExpression(LexicalInfo.Empty));
									string text22 = (_0024_00245221_002422508.Value = string.Empty);
									array4[2] = _0024_00245221_002422508;
									ExpressionCollection expressionCollection14 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array4));
									array3[2] = _0024_00245222_002422509;
									ExpressionCollection expressionCollection16 = (methodInvocationExpression10.Arguments = ExpressionCollection.FromArray(array3));
									_0024z_002422499 = _0024_00245223_002422510;
									_0024z_002422499.LexicalInfo = _0024assert_code_002422511.LexicalInfo;
									result = (Yield(3, _0024z_002422499) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`assert_code` failed to match `").Append(_0024_0024match_002457_002422483).Append("`").ToString());
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

		internal MacroStatement _0024assert_code_002422513;

		internal Assert_codeMacro _0024self__002422514;

		public _0024ExpandGeneratorImpl_002422482(MacroStatement assert_code, Assert_codeMacro self_)
		{
			_0024assert_code_002422513 = assert_code;
			_0024self__002422514 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024assert_code_002422513, _0024self__002422514);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Assert_codeMacro()
	{
	}

	public Assert_codeMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement assert_code)
	{
		return new _0024ExpandGeneratorImpl_002422482(assert_code, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement assert_code)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'assert_code' is using. Read BOO-1077 for more info.");
	}
}
