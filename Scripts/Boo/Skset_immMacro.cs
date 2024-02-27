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
public sealed class Skset_immMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417171 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002410_002417172;

			internal MacroStatement _0024_0024match_002411_002417173;

			internal Expression _0024var_002417174;

			internal Expression _0024effType_002417175;

			internal Expression _0024val_002417176;

			internal ReferenceExpression _0024_00244302_002417177;

			internal ReferenceExpression _0024_00244303_002417178;

			internal BinaryExpression _0024_00244304_002417179;

			internal BinaryExpression _0024_00244305_002417180;

			internal Block _0024_00244306_002417181;

			internal IfStatement _0024_00244307_002417182;

			internal MacroStatement _0024_0024match_002412_002417183;

			internal Expression _0024cond_002417184;

			internal ReferenceExpression _0024_00244308_002417185;

			internal ReferenceExpression _0024_00244309_002417186;

			internal BinaryExpression _0024_00244310_002417187;

			internal BinaryExpression _0024_00244311_002417188;

			internal BinaryExpression _0024_00244312_002417189;

			internal Block _0024_00244313_002417190;

			internal IfStatement _0024_00244314_002417191;

			internal MacroStatement _0024skset_imm_002417192;

			internal Skset_immMacro _0024self__002417193;

			public _0024(MacroStatement skset_imm, Skset_immMacro self_)
			{
				_0024skset_imm_002417192 = skset_imm;
				_0024self__002417193 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024skset_imm_002417192 == null)
					{
						throw new ArgumentNullException("skset_imm");
					}
					_0024self__002417193.__macro = _0024skset_imm_002417192;
					_0024_0024match_002410_002417172 = _0024skset_imm_002417192;
					if (_0024_0024match_002410_002417172 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002411_002417173 = _0024_0024match_002410_002417172);
						if (true && _0024_0024match_002411_002417173.Name == "skset_imm" && 3 == ((ICollection)_0024_0024match_002411_002417173.Arguments).Count)
						{
							Expression expression = (_0024var_002417174 = _0024_0024match_002411_002417173.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024effType_002417175 = _0024_0024match_002411_002417173.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024val_002417176 = _0024_0024match_002411_002417173.Arguments[2]);
									if (true)
									{
										IfStatement ifStatement = (_0024_00244307_002417182 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement2 = _0024_00244307_002417182;
										BinaryExpression binaryExpression = (_0024_00244304_002417179 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00244304_002417179.Operator = BinaryOperatorType.Equality);
										BinaryExpression binaryExpression2 = _0024_00244304_002417179;
										ReferenceExpression referenceExpression = (_0024_00244302_002417177 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00244302_002417177.Name = "EffectType");
										Expression expression5 = (binaryExpression2.Left = _0024_00244302_002417177);
										BinaryExpression binaryExpression3 = _0024_00244304_002417179;
										ReferenceExpression referenceExpression2 = (_0024_00244303_002417178 = new ReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00244303_002417178.Name = "EnumSkillEffectTypes");
										Expression expression7 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244303_002417178, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417175)));
										Expression expression9 = (ifStatement2.Condition = _0024_00244304_002417179);
										IfStatement ifStatement3 = _0024_00244307_002417182;
										Block block = (_0024_00244306_002417181 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00244306_002417181;
										Statement[] array = new Statement[1];
										BinaryExpression binaryExpression4 = (_0024_00244305_002417180 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00244305_002417180.Operator = BinaryOperatorType.Assign);
										Expression expression11 = (_0024_00244305_002417180.Left = Expression.Lift(_0024var_002417174));
										Expression expression13 = (_0024_00244305_002417180.Right = Expression.Lift(_0024val_002417176));
										array[0] = Statement.Lift(_0024_00244305_002417180);
										StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
										Block block4 = (ifStatement3.TrueBlock = _0024_00244306_002417181);
										result = (Yield(2, _0024_00244307_002417182) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					if (_0024_0024match_002410_002417172 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002412_002417183 = _0024_0024match_002410_002417172);
						if (true && _0024_0024match_002412_002417183.Name == "skset_imm" && 4 == ((ICollection)_0024_0024match_002412_002417183.Arguments).Count)
						{
							Expression expression14 = (_0024var_002417174 = _0024_0024match_002412_002417183.Arguments[0]);
							if (true)
							{
								Expression expression15 = (_0024effType_002417175 = _0024_0024match_002412_002417183.Arguments[1]);
								if (true)
								{
									Expression expression16 = (_0024val_002417176 = _0024_0024match_002412_002417183.Arguments[2]);
									if (true)
									{
										Expression expression17 = (_0024cond_002417184 = _0024_0024match_002412_002417183.Arguments[3]);
										if (true)
										{
											IfStatement ifStatement4 = (_0024_00244314_002417191 = new IfStatement(LexicalInfo.Empty));
											IfStatement ifStatement5 = _0024_00244314_002417191;
											BinaryExpression binaryExpression5 = (_0024_00244311_002417188 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType6 = (_0024_00244311_002417188.Operator = BinaryOperatorType.And);
											BinaryExpression binaryExpression6 = _0024_00244311_002417188;
											BinaryExpression binaryExpression7 = (_0024_00244310_002417187 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType8 = (_0024_00244310_002417187.Operator = BinaryOperatorType.Equality);
											BinaryExpression binaryExpression8 = _0024_00244310_002417187;
											ReferenceExpression referenceExpression3 = (_0024_00244308_002417185 = new ReferenceExpression(LexicalInfo.Empty));
											string text6 = (_0024_00244308_002417185.Name = "EffectType");
											Expression expression19 = (binaryExpression8.Left = _0024_00244308_002417185);
											BinaryExpression binaryExpression9 = _0024_00244310_002417187;
											ReferenceExpression referenceExpression4 = (_0024_00244309_002417186 = new ReferenceExpression(LexicalInfo.Empty));
											string text8 = (_0024_00244309_002417186.Name = "EnumSkillEffectTypes");
											Expression expression21 = (binaryExpression9.Right = new MemberReferenceExpression(_0024_00244309_002417186, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417175)));
											Expression expression23 = (binaryExpression6.Left = _0024_00244310_002417187);
											Expression expression25 = (_0024_00244311_002417188.Right = Expression.Lift(_0024cond_002417184));
											Expression expression27 = (ifStatement5.Condition = _0024_00244311_002417188);
											IfStatement ifStatement6 = _0024_00244314_002417191;
											Block block5 = (_0024_00244313_002417190 = new Block(LexicalInfo.Empty));
											Block block6 = _0024_00244313_002417190;
											Statement[] array2 = new Statement[1];
											BinaryExpression binaryExpression10 = (_0024_00244312_002417189 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType10 = (_0024_00244312_002417189.Operator = BinaryOperatorType.Assign);
											Expression expression29 = (_0024_00244312_002417189.Left = Expression.Lift(_0024var_002417174));
											Expression expression31 = (_0024_00244312_002417189.Right = Expression.Lift(_0024val_002417176));
											array2[0] = Statement.Lift(_0024_00244312_002417189);
											StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
											Block block8 = (ifStatement6.TrueBlock = _0024_00244313_002417190);
											result = (Yield(3, _0024_00244314_002417191) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`skset_imm` failed to match `").Append(_0024_0024match_002410_002417172).Append("`").ToString());
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

		internal MacroStatement _0024skset_imm_002417194;

		internal Skset_immMacro _0024self__002417195;

		public _0024ExpandGeneratorImpl_002417171(MacroStatement skset_imm, Skset_immMacro self_)
		{
			_0024skset_imm_002417194 = skset_imm;
			_0024self__002417195 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024skset_imm_002417194, _0024self__002417195);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Skset_immMacro()
	{
	}

	public Skset_immMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement skset_imm)
	{
		return new _0024ExpandGeneratorImpl_002417171(skset_imm, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement skset_imm)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'skset_imm' is using. Read BOO-1077 for more info.");
	}
}
