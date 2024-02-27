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
public sealed class Skmult_rateMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417221 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002416_002417222;

			internal MacroStatement _0024_0024match_002417_002417223;

			internal Expression _0024var_002417224;

			internal Expression _0024effType_002417225;

			internal ReferenceExpression _0024_00244328_002417226;

			internal ReferenceExpression _0024_00244329_002417227;

			internal BinaryExpression _0024_00244330_002417228;

			internal ReferenceExpression _0024_00244331_002417229;

			internal BinaryExpression _0024_00244332_002417230;

			internal Block _0024_00244333_002417231;

			internal IfStatement _0024_00244334_002417232;

			internal MacroStatement _0024_0024match_002418_002417233;

			internal Expression _0024cond_002417234;

			internal ReferenceExpression _0024_00244335_002417235;

			internal ReferenceExpression _0024_00244336_002417236;

			internal BinaryExpression _0024_00244337_002417237;

			internal BinaryExpression _0024_00244338_002417238;

			internal ReferenceExpression _0024_00244339_002417239;

			internal BinaryExpression _0024_00244340_002417240;

			internal Block _0024_00244341_002417241;

			internal IfStatement _0024_00244342_002417242;

			internal MacroStatement _0024skmult_rate_002417243;

			internal Skmult_rateMacro _0024self__002417244;

			public _0024(MacroStatement skmult_rate, Skmult_rateMacro self_)
			{
				_0024skmult_rate_002417243 = skmult_rate;
				_0024self__002417244 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024skmult_rate_002417243 == null)
					{
						throw new ArgumentNullException("skmult_rate");
					}
					_0024self__002417244.__macro = _0024skmult_rate_002417243;
					_0024_0024match_002416_002417222 = _0024skmult_rate_002417243;
					if (_0024_0024match_002416_002417222 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002417_002417223 = _0024_0024match_002416_002417222);
						if (true && _0024_0024match_002417_002417223.Name == "skmult_rate" && 2 == ((ICollection)_0024_0024match_002417_002417223.Arguments).Count)
						{
							Expression expression = (_0024var_002417224 = _0024_0024match_002417_002417223.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024effType_002417225 = _0024_0024match_002417_002417223.Arguments[1]);
								if (true)
								{
									IfStatement ifStatement = (_0024_00244334_002417232 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement2 = _0024_00244334_002417232;
									BinaryExpression binaryExpression = (_0024_00244330_002417228 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00244330_002417228.Operator = BinaryOperatorType.Equality);
									BinaryExpression binaryExpression2 = _0024_00244330_002417228;
									ReferenceExpression referenceExpression = (_0024_00244328_002417226 = new ReferenceExpression(LexicalInfo.Empty));
									string text2 = (_0024_00244328_002417226.Name = "EffectType");
									Expression expression4 = (binaryExpression2.Left = _0024_00244328_002417226);
									BinaryExpression binaryExpression3 = _0024_00244330_002417228;
									ReferenceExpression referenceExpression2 = (_0024_00244329_002417227 = new ReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00244329_002417227.Name = "EnumSkillEffectTypes");
									Expression expression6 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244329_002417227, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417225)));
									Expression expression8 = (ifStatement2.Condition = _0024_00244330_002417228);
									IfStatement ifStatement3 = _0024_00244334_002417232;
									Block block = (_0024_00244333_002417231 = new Block(LexicalInfo.Empty));
									Block block2 = _0024_00244333_002417231;
									Statement[] array = new Statement[1];
									BinaryExpression binaryExpression4 = (_0024_00244332_002417230 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00244332_002417230.Operator = BinaryOperatorType.InPlaceMultiply);
									Expression expression10 = (_0024_00244332_002417230.Left = Expression.Lift(_0024var_002417224));
									BinaryExpression binaryExpression5 = _0024_00244332_002417230;
									ReferenceExpression referenceExpression3 = (_0024_00244331_002417229 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00244331_002417229.Name = "EffValueAsRate");
									Expression expression12 = (binaryExpression5.Right = _0024_00244331_002417229);
									array[0] = Statement.Lift(_0024_00244332_002417230);
									StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
									Block block4 = (ifStatement3.TrueBlock = _0024_00244333_002417231);
									result = (Yield(2, _0024_00244334_002417232) ? 1 : 0);
									break;
								}
							}
						}
					}
					if (_0024_0024match_002416_002417222 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002418_002417233 = _0024_0024match_002416_002417222);
						if (true && _0024_0024match_002418_002417233.Name == "skmult_rate" && 3 == ((ICollection)_0024_0024match_002418_002417233.Arguments).Count)
						{
							Expression expression13 = (_0024var_002417224 = _0024_0024match_002418_002417233.Arguments[0]);
							if (true)
							{
								Expression expression14 = (_0024effType_002417225 = _0024_0024match_002418_002417233.Arguments[1]);
								if (true)
								{
									Expression expression15 = (_0024cond_002417234 = _0024_0024match_002418_002417233.Arguments[2]);
									if (true)
									{
										IfStatement ifStatement4 = (_0024_00244342_002417242 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement5 = _0024_00244342_002417242;
										BinaryExpression binaryExpression6 = (_0024_00244338_002417238 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType6 = (_0024_00244338_002417238.Operator = BinaryOperatorType.And);
										BinaryExpression binaryExpression7 = _0024_00244338_002417238;
										BinaryExpression binaryExpression8 = (_0024_00244337_002417237 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType8 = (_0024_00244337_002417237.Operator = BinaryOperatorType.Equality);
										BinaryExpression binaryExpression9 = _0024_00244337_002417237;
										ReferenceExpression referenceExpression4 = (_0024_00244335_002417235 = new ReferenceExpression(LexicalInfo.Empty));
										string text8 = (_0024_00244335_002417235.Name = "EffectType");
										Expression expression17 = (binaryExpression9.Left = _0024_00244335_002417235);
										BinaryExpression binaryExpression10 = _0024_00244337_002417237;
										ReferenceExpression referenceExpression5 = (_0024_00244336_002417236 = new ReferenceExpression(LexicalInfo.Empty));
										string text10 = (_0024_00244336_002417236.Name = "EnumSkillEffectTypes");
										Expression expression19 = (binaryExpression10.Right = new MemberReferenceExpression(_0024_00244336_002417236, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417225)));
										Expression expression21 = (binaryExpression7.Left = _0024_00244337_002417237);
										Expression expression23 = (_0024_00244338_002417238.Right = Expression.Lift(_0024cond_002417234));
										Expression expression25 = (ifStatement5.Condition = _0024_00244338_002417238);
										IfStatement ifStatement6 = _0024_00244342_002417242;
										Block block5 = (_0024_00244341_002417241 = new Block(LexicalInfo.Empty));
										Block block6 = _0024_00244341_002417241;
										Statement[] array2 = new Statement[1];
										BinaryExpression binaryExpression11 = (_0024_00244340_002417240 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType10 = (_0024_00244340_002417240.Operator = BinaryOperatorType.InPlaceMultiply);
										Expression expression27 = (_0024_00244340_002417240.Left = Expression.Lift(_0024var_002417224));
										BinaryExpression binaryExpression12 = _0024_00244340_002417240;
										ReferenceExpression referenceExpression6 = (_0024_00244339_002417239 = new ReferenceExpression(LexicalInfo.Empty));
										string text12 = (_0024_00244339_002417239.Name = "EffValueAsRate");
										Expression expression29 = (binaryExpression12.Right = _0024_00244339_002417239);
										array2[0] = Statement.Lift(_0024_00244340_002417240);
										StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
										Block block8 = (ifStatement6.TrueBlock = _0024_00244341_002417241);
										result = (Yield(3, _0024_00244342_002417242) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`skmult_rate` failed to match `").Append(_0024_0024match_002416_002417222).Append("`").ToString());
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

		internal MacroStatement _0024skmult_rate_002417245;

		internal Skmult_rateMacro _0024self__002417246;

		public _0024ExpandGeneratorImpl_002417221(MacroStatement skmult_rate, Skmult_rateMacro self_)
		{
			_0024skmult_rate_002417245 = skmult_rate;
			_0024self__002417246 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024skmult_rate_002417245, _0024self__002417246);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Skmult_rateMacro()
	{
	}

	public Skmult_rateMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement skmult_rate)
	{
		return new _0024ExpandGeneratorImpl_002417221(skmult_rate, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement skmult_rate)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'skmult_rate' is using. Read BOO-1077 for more info.");
	}
}
