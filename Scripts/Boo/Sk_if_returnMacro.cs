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
public sealed class Sk_if_returnMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417294 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002425_002417295;

			internal MacroStatement _0024_0024match_002426_002417296;

			internal Expression _0024effType_002417297;

			internal Expression _0024expr_002417298;

			internal ReferenceExpression _0024_00244369_002417299;

			internal ReferenceExpression _0024_00244370_002417300;

			internal BinaryExpression _0024_00244371_002417301;

			internal ReturnStatement _0024_00244372_002417302;

			internal Block _0024_00244373_002417303;

			internal IfStatement _0024_00244374_002417304;

			internal MacroStatement _0024_0024match_002427_002417305;

			internal Expression _0024cond_002417306;

			internal ReferenceExpression _0024_00244375_002417307;

			internal ReferenceExpression _0024_00244376_002417308;

			internal BinaryExpression _0024_00244377_002417309;

			internal BinaryExpression _0024_00244378_002417310;

			internal ReturnStatement _0024_00244379_002417311;

			internal Block _0024_00244380_002417312;

			internal IfStatement _0024_00244381_002417313;

			internal MacroStatement _0024sk_if_return_002417314;

			internal Sk_if_returnMacro _0024self__002417315;

			public _0024(MacroStatement sk_if_return, Sk_if_returnMacro self_)
			{
				_0024sk_if_return_002417314 = sk_if_return;
				_0024self__002417315 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024sk_if_return_002417314 == null)
					{
						throw new ArgumentNullException("sk_if_return");
					}
					_0024self__002417315.__macro = _0024sk_if_return_002417314;
					_0024_0024match_002425_002417295 = _0024sk_if_return_002417314;
					if (_0024_0024match_002425_002417295 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002426_002417296 = _0024_0024match_002425_002417295);
						if (true && _0024_0024match_002426_002417296.Name == "sk_if_return" && 2 == ((ICollection)_0024_0024match_002426_002417296.Arguments).Count)
						{
							Expression expression = (_0024effType_002417297 = _0024_0024match_002426_002417296.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024expr_002417298 = _0024_0024match_002426_002417296.Arguments[1]);
								if (true)
								{
									IfStatement ifStatement = (_0024_00244374_002417304 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement2 = _0024_00244374_002417304;
									BinaryExpression binaryExpression = (_0024_00244371_002417301 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00244371_002417301.Operator = BinaryOperatorType.Equality);
									BinaryExpression binaryExpression2 = _0024_00244371_002417301;
									ReferenceExpression referenceExpression = (_0024_00244369_002417299 = new ReferenceExpression(LexicalInfo.Empty));
									string text2 = (_0024_00244369_002417299.Name = "EffectType");
									Expression expression4 = (binaryExpression2.Left = _0024_00244369_002417299);
									BinaryExpression binaryExpression3 = _0024_00244371_002417301;
									ReferenceExpression referenceExpression2 = (_0024_00244370_002417300 = new ReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00244370_002417300.Name = "EnumSkillEffectTypes");
									Expression expression6 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244370_002417300, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417297)));
									Expression expression8 = (ifStatement2.Condition = _0024_00244371_002417301);
									IfStatement ifStatement3 = _0024_00244374_002417304;
									Block block = (_0024_00244373_002417303 = new Block(LexicalInfo.Empty));
									Block block2 = _0024_00244373_002417303;
									Statement[] array = new Statement[1];
									ReturnStatement returnStatement = (_0024_00244372_002417302 = new ReturnStatement(LexicalInfo.Empty));
									Expression expression10 = (_0024_00244372_002417302.Expression = Expression.Lift(_0024expr_002417298));
									array[0] = Statement.Lift(_0024_00244372_002417302);
									StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
									Block block4 = (ifStatement3.TrueBlock = _0024_00244373_002417303);
									result = (Yield(2, _0024_00244374_002417304) ? 1 : 0);
									break;
								}
							}
						}
					}
					if (_0024_0024match_002425_002417295 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002427_002417305 = _0024_0024match_002425_002417295);
						if (true && _0024_0024match_002427_002417305.Name == "sk_if_return" && 3 == ((ICollection)_0024_0024match_002427_002417305.Arguments).Count)
						{
							Expression expression11 = (_0024effType_002417297 = _0024_0024match_002427_002417305.Arguments[0]);
							if (true)
							{
								Expression expression12 = (_0024cond_002417306 = _0024_0024match_002427_002417305.Arguments[1]);
								if (true)
								{
									Expression expression13 = (_0024expr_002417298 = _0024_0024match_002427_002417305.Arguments[2]);
									if (true)
									{
										IfStatement ifStatement4 = (_0024_00244381_002417313 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement5 = _0024_00244381_002417313;
										BinaryExpression binaryExpression4 = (_0024_00244378_002417310 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00244378_002417310.Operator = BinaryOperatorType.And);
										BinaryExpression binaryExpression5 = _0024_00244378_002417310;
										BinaryExpression binaryExpression6 = (_0024_00244377_002417309 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType6 = (_0024_00244377_002417309.Operator = BinaryOperatorType.Equality);
										BinaryExpression binaryExpression7 = _0024_00244377_002417309;
										ReferenceExpression referenceExpression3 = (_0024_00244375_002417307 = new ReferenceExpression(LexicalInfo.Empty));
										string text6 = (_0024_00244375_002417307.Name = "EffectType");
										Expression expression15 = (binaryExpression7.Left = _0024_00244375_002417307);
										BinaryExpression binaryExpression8 = _0024_00244377_002417309;
										ReferenceExpression referenceExpression4 = (_0024_00244376_002417308 = new ReferenceExpression(LexicalInfo.Empty));
										string text8 = (_0024_00244376_002417308.Name = "EnumSkillEffectTypes");
										Expression expression17 = (binaryExpression8.Right = new MemberReferenceExpression(_0024_00244376_002417308, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417297)));
										Expression expression19 = (binaryExpression5.Left = _0024_00244377_002417309);
										Expression expression21 = (_0024_00244378_002417310.Right = Expression.Lift(_0024cond_002417306));
										Expression expression23 = (ifStatement5.Condition = _0024_00244378_002417310);
										IfStatement ifStatement6 = _0024_00244381_002417313;
										Block block5 = (_0024_00244380_002417312 = new Block(LexicalInfo.Empty));
										Block block6 = _0024_00244380_002417312;
										Statement[] array2 = new Statement[1];
										ReturnStatement returnStatement2 = (_0024_00244379_002417311 = new ReturnStatement(LexicalInfo.Empty));
										Expression expression25 = (_0024_00244379_002417311.Expression = Expression.Lift(_0024expr_002417298));
										array2[0] = Statement.Lift(_0024_00244379_002417311);
										StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
										Block block8 = (ifStatement6.TrueBlock = _0024_00244380_002417312);
										result = (Yield(3, _0024_00244381_002417313) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`sk_if_return` failed to match `").Append(_0024_0024match_002425_002417295).Append("`").ToString());
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

		internal MacroStatement _0024sk_if_return_002417316;

		internal Sk_if_returnMacro _0024self__002417317;

		public _0024ExpandGeneratorImpl_002417294(MacroStatement sk_if_return, Sk_if_returnMacro self_)
		{
			_0024sk_if_return_002417316 = sk_if_return;
			_0024self__002417317 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024sk_if_return_002417316, _0024self__002417317);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Sk_if_returnMacro()
	{
	}

	public Sk_if_returnMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement sk_if_return)
	{
		return new _0024ExpandGeneratorImpl_002417294(sk_if_return, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement sk_if_return)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'sk_if_return' is using. Read BOO-1077 for more info.");
	}
}
