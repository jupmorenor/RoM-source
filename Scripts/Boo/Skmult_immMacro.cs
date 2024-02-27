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
public sealed class Skmult_immMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417196 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002413_002417197;

			internal MacroStatement _0024_0024match_002414_002417198;

			internal Expression _0024var_002417199;

			internal Expression _0024effType_002417200;

			internal Expression _0024mult_002417201;

			internal ReferenceExpression _0024_00244315_002417202;

			internal ReferenceExpression _0024_00244316_002417203;

			internal BinaryExpression _0024_00244317_002417204;

			internal BinaryExpression _0024_00244318_002417205;

			internal Block _0024_00244319_002417206;

			internal IfStatement _0024_00244320_002417207;

			internal MacroStatement _0024_0024match_002415_002417208;

			internal Expression _0024cond_002417209;

			internal ReferenceExpression _0024_00244321_002417210;

			internal ReferenceExpression _0024_00244322_002417211;

			internal BinaryExpression _0024_00244323_002417212;

			internal BinaryExpression _0024_00244324_002417213;

			internal BinaryExpression _0024_00244325_002417214;

			internal Block _0024_00244326_002417215;

			internal IfStatement _0024_00244327_002417216;

			internal MacroStatement _0024skmult_imm_002417217;

			internal Skmult_immMacro _0024self__002417218;

			public _0024(MacroStatement skmult_imm, Skmult_immMacro self_)
			{
				_0024skmult_imm_002417217 = skmult_imm;
				_0024self__002417218 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024skmult_imm_002417217 == null)
					{
						throw new ArgumentNullException("skmult_imm");
					}
					_0024self__002417218.__macro = _0024skmult_imm_002417217;
					_0024_0024match_002413_002417197 = _0024skmult_imm_002417217;
					if (_0024_0024match_002413_002417197 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002414_002417198 = _0024_0024match_002413_002417197);
						if (true && _0024_0024match_002414_002417198.Name == "skmult_imm" && 3 == ((ICollection)_0024_0024match_002414_002417198.Arguments).Count)
						{
							Expression expression = (_0024var_002417199 = _0024_0024match_002414_002417198.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024effType_002417200 = _0024_0024match_002414_002417198.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024mult_002417201 = _0024_0024match_002414_002417198.Arguments[2]);
									if (true)
									{
										IfStatement ifStatement = (_0024_00244320_002417207 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement2 = _0024_00244320_002417207;
										BinaryExpression binaryExpression = (_0024_00244317_002417204 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00244317_002417204.Operator = BinaryOperatorType.Equality);
										BinaryExpression binaryExpression2 = _0024_00244317_002417204;
										ReferenceExpression referenceExpression = (_0024_00244315_002417202 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00244315_002417202.Name = "EffectType");
										Expression expression5 = (binaryExpression2.Left = _0024_00244315_002417202);
										BinaryExpression binaryExpression3 = _0024_00244317_002417204;
										ReferenceExpression referenceExpression2 = (_0024_00244316_002417203 = new ReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00244316_002417203.Name = "EnumSkillEffectTypes");
										Expression expression7 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244316_002417203, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417200)));
										Expression expression9 = (ifStatement2.Condition = _0024_00244317_002417204);
										IfStatement ifStatement3 = _0024_00244320_002417207;
										Block block = (_0024_00244319_002417206 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00244319_002417206;
										Statement[] array = new Statement[1];
										BinaryExpression binaryExpression4 = (_0024_00244318_002417205 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00244318_002417205.Operator = BinaryOperatorType.InPlaceMultiply);
										Expression expression11 = (_0024_00244318_002417205.Left = Expression.Lift(_0024var_002417199));
										Expression expression13 = (_0024_00244318_002417205.Right = Expression.Lift(_0024mult_002417201));
										array[0] = Statement.Lift(_0024_00244318_002417205);
										StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
										Block block4 = (ifStatement3.TrueBlock = _0024_00244319_002417206);
										result = (Yield(2, _0024_00244320_002417207) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_002413_002417197 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002415_002417208 = _0024_0024match_002413_002417197);
						if (true && _0024_0024match_002415_002417208.Name == "skmult_imm" && 4 == ((ICollection)_0024_0024match_002415_002417208.Arguments).Count)
						{
							Expression expression14 = (_0024var_002417199 = _0024_0024match_002415_002417208.Arguments[0]);
							if (true)
							{
								Expression expression15 = (_0024effType_002417200 = _0024_0024match_002415_002417208.Arguments[1]);
								if (true)
								{
									Expression expression16 = (_0024mult_002417201 = _0024_0024match_002415_002417208.Arguments[2]);
									if (true)
									{
										Expression expression17 = (_0024cond_002417209 = _0024_0024match_002415_002417208.Arguments[3]);
										if (true)
										{
											IfStatement ifStatement4 = (_0024_00244327_002417216 = new IfStatement(LexicalInfo.Empty));
											IfStatement ifStatement5 = _0024_00244327_002417216;
											BinaryExpression binaryExpression5 = (_0024_00244324_002417213 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType6 = (_0024_00244324_002417213.Operator = BinaryOperatorType.And);
											BinaryExpression binaryExpression6 = _0024_00244324_002417213;
											BinaryExpression binaryExpression7 = (_0024_00244323_002417212 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType8 = (_0024_00244323_002417212.Operator = BinaryOperatorType.Equality);
											BinaryExpression binaryExpression8 = _0024_00244323_002417212;
											ReferenceExpression referenceExpression3 = (_0024_00244321_002417210 = new ReferenceExpression(LexicalInfo.Empty));
											string text6 = (_0024_00244321_002417210.Name = "EffectType");
											Expression expression19 = (binaryExpression8.Left = _0024_00244321_002417210);
											BinaryExpression binaryExpression9 = _0024_00244323_002417212;
											ReferenceExpression referenceExpression4 = (_0024_00244322_002417211 = new ReferenceExpression(LexicalInfo.Empty));
											string text8 = (_0024_00244322_002417211.Name = "EnumSkillEffectTypes");
											Expression expression21 = (binaryExpression9.Right = new MemberReferenceExpression(_0024_00244322_002417211, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417200)));
											Expression expression23 = (binaryExpression6.Left = _0024_00244323_002417212);
											Expression expression25 = (_0024_00244324_002417213.Right = Expression.Lift(_0024cond_002417209));
											Expression expression27 = (ifStatement5.Condition = _0024_00244324_002417213);
											IfStatement ifStatement6 = _0024_00244327_002417216;
											Block block5 = (_0024_00244326_002417215 = new Block(LexicalInfo.Empty));
											Block block6 = _0024_00244326_002417215;
											Statement[] array2 = new Statement[1];
											BinaryExpression binaryExpression10 = (_0024_00244325_002417214 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType10 = (_0024_00244325_002417214.Operator = BinaryOperatorType.InPlaceMultiply);
											Expression expression29 = (_0024_00244325_002417214.Left = Expression.Lift(_0024var_002417199));
											Expression expression31 = (_0024_00244325_002417214.Right = Expression.Lift(_0024mult_002417201));
											array2[0] = Statement.Lift(_0024_00244325_002417214);
											StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
											Block block8 = (ifStatement6.TrueBlock = _0024_00244326_002417215);
											result = (Yield(3, _0024_00244327_002417216) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`skmult_imm` failed to match `").Append(_0024_0024match_002413_002417197).Append("`").ToString());
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

		internal MacroStatement _0024skmult_imm_002417219;

		internal Skmult_immMacro _0024self__002417220;

		public _0024ExpandGeneratorImpl_002417196(MacroStatement skmult_imm, Skmult_immMacro self_)
		{
			_0024skmult_imm_002417219 = skmult_imm;
			_0024self__002417220 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024skmult_imm_002417219, _0024self__002417220);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Skmult_immMacro()
	{
	}

	public Skmult_immMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement skmult_imm)
	{
		return new _0024ExpandGeneratorImpl_002417196(skmult_imm, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement skmult_imm)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'skmult_imm' is using. Read BOO-1077 for more info.");
	}
}
