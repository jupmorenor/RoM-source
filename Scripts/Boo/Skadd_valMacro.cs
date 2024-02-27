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
public sealed class Skadd_valMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417247 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002419_002417248;

			internal MacroStatement _0024_0024match_002420_002417249;

			internal Expression _0024var_002417250;

			internal Expression _0024effType_002417251;

			internal ReferenceExpression _0024_00244343_002417252;

			internal ReferenceExpression _0024_00244344_002417253;

			internal BinaryExpression _0024_00244345_002417254;

			internal ReferenceExpression _0024_00244346_002417255;

			internal BinaryExpression _0024_00244347_002417256;

			internal Block _0024_00244348_002417257;

			internal IfStatement _0024_00244349_002417258;

			internal MacroStatement _0024_0024match_002421_002417259;

			internal Expression _0024cond_002417260;

			internal ReferenceExpression _0024_00244350_002417261;

			internal ReferenceExpression _0024_00244351_002417262;

			internal BinaryExpression _0024_00244352_002417263;

			internal BinaryExpression _0024_00244353_002417264;

			internal ReferenceExpression _0024_00244354_002417265;

			internal BinaryExpression _0024_00244355_002417266;

			internal Block _0024_00244356_002417267;

			internal IfStatement _0024_00244357_002417268;

			internal MacroStatement _0024skadd_val_002417269;

			internal Skadd_valMacro _0024self__002417270;

			public _0024(MacroStatement skadd_val, Skadd_valMacro self_)
			{
				_0024skadd_val_002417269 = skadd_val;
				_0024self__002417270 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024skadd_val_002417269 == null)
					{
						throw new ArgumentNullException("skadd_val");
					}
					_0024self__002417270.__macro = _0024skadd_val_002417269;
					_0024_0024match_002419_002417248 = _0024skadd_val_002417269;
					if (_0024_0024match_002419_002417248 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002420_002417249 = _0024_0024match_002419_002417248);
						if (true && _0024_0024match_002420_002417249.Name == "skadd_val" && 2 == ((ICollection)_0024_0024match_002420_002417249.Arguments).Count)
						{
							Expression expression = (_0024var_002417250 = _0024_0024match_002420_002417249.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024effType_002417251 = _0024_0024match_002420_002417249.Arguments[1]);
								if (true)
								{
									IfStatement ifStatement = (_0024_00244349_002417258 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement2 = _0024_00244349_002417258;
									BinaryExpression binaryExpression = (_0024_00244345_002417254 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00244345_002417254.Operator = BinaryOperatorType.Equality);
									BinaryExpression binaryExpression2 = _0024_00244345_002417254;
									ReferenceExpression referenceExpression = (_0024_00244343_002417252 = new ReferenceExpression(LexicalInfo.Empty));
									string text2 = (_0024_00244343_002417252.Name = "EffectType");
									Expression expression4 = (binaryExpression2.Left = _0024_00244343_002417252);
									BinaryExpression binaryExpression3 = _0024_00244345_002417254;
									ReferenceExpression referenceExpression2 = (_0024_00244344_002417253 = new ReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00244344_002417253.Name = "EnumSkillEffectTypes");
									Expression expression6 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244344_002417253, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417251)));
									Expression expression8 = (ifStatement2.Condition = _0024_00244345_002417254);
									IfStatement ifStatement3 = _0024_00244349_002417258;
									Block block = (_0024_00244348_002417257 = new Block(LexicalInfo.Empty));
									Block block2 = _0024_00244348_002417257;
									Statement[] array = new Statement[1];
									BinaryExpression binaryExpression4 = (_0024_00244347_002417256 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00244347_002417256.Operator = BinaryOperatorType.InPlaceAddition);
									Expression expression10 = (_0024_00244347_002417256.Left = Expression.Lift(_0024var_002417250));
									BinaryExpression binaryExpression5 = _0024_00244347_002417256;
									ReferenceExpression referenceExpression3 = (_0024_00244346_002417255 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00244346_002417255.Name = "EffValue");
									Expression expression12 = (binaryExpression5.Right = _0024_00244346_002417255);
									array[0] = Statement.Lift(_0024_00244347_002417256);
									StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
									Block block4 = (ifStatement3.TrueBlock = _0024_00244348_002417257);
									result = (Yield(2, _0024_00244349_002417258) ? 1 : 0);
									break;
								}
							}
						}
					}
					if (_0024_0024match_002419_002417248 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002421_002417259 = _0024_0024match_002419_002417248);
						if (true && _0024_0024match_002421_002417259.Name == "skadd_val" && 3 == ((ICollection)_0024_0024match_002421_002417259.Arguments).Count)
						{
							Expression expression13 = (_0024var_002417250 = _0024_0024match_002421_002417259.Arguments[0]);
							if (true)
							{
								Expression expression14 = (_0024effType_002417251 = _0024_0024match_002421_002417259.Arguments[1]);
								if (true)
								{
									Expression expression15 = (_0024cond_002417260 = _0024_0024match_002421_002417259.Arguments[2]);
									if (true)
									{
										IfStatement ifStatement4 = (_0024_00244357_002417268 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement5 = _0024_00244357_002417268;
										BinaryExpression binaryExpression6 = (_0024_00244353_002417264 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType6 = (_0024_00244353_002417264.Operator = BinaryOperatorType.And);
										BinaryExpression binaryExpression7 = _0024_00244353_002417264;
										BinaryExpression binaryExpression8 = (_0024_00244352_002417263 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType8 = (_0024_00244352_002417263.Operator = BinaryOperatorType.Equality);
										BinaryExpression binaryExpression9 = _0024_00244352_002417263;
										ReferenceExpression referenceExpression4 = (_0024_00244350_002417261 = new ReferenceExpression(LexicalInfo.Empty));
										string text8 = (_0024_00244350_002417261.Name = "EffectType");
										Expression expression17 = (binaryExpression9.Left = _0024_00244350_002417261);
										BinaryExpression binaryExpression10 = _0024_00244352_002417263;
										ReferenceExpression referenceExpression5 = (_0024_00244351_002417262 = new ReferenceExpression(LexicalInfo.Empty));
										string text10 = (_0024_00244351_002417262.Name = "EnumSkillEffectTypes");
										Expression expression19 = (binaryExpression10.Right = new MemberReferenceExpression(_0024_00244351_002417262, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417251)));
										Expression expression21 = (binaryExpression7.Left = _0024_00244352_002417263);
										Expression expression23 = (_0024_00244353_002417264.Right = Expression.Lift(_0024cond_002417260));
										Expression expression25 = (ifStatement5.Condition = _0024_00244353_002417264);
										IfStatement ifStatement6 = _0024_00244357_002417268;
										Block block5 = (_0024_00244356_002417267 = new Block(LexicalInfo.Empty));
										Block block6 = _0024_00244356_002417267;
										Statement[] array2 = new Statement[1];
										BinaryExpression binaryExpression11 = (_0024_00244355_002417266 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType10 = (_0024_00244355_002417266.Operator = BinaryOperatorType.InPlaceAddition);
										Expression expression27 = (_0024_00244355_002417266.Left = Expression.Lift(_0024var_002417250));
										BinaryExpression binaryExpression12 = _0024_00244355_002417266;
										ReferenceExpression referenceExpression6 = (_0024_00244354_002417265 = new ReferenceExpression(LexicalInfo.Empty));
										string text12 = (_0024_00244354_002417265.Name = "EffValue");
										Expression expression29 = (binaryExpression12.Right = _0024_00244354_002417265);
										array2[0] = Statement.Lift(_0024_00244355_002417266);
										StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
										Block block8 = (ifStatement6.TrueBlock = _0024_00244356_002417267);
										result = (Yield(3, _0024_00244357_002417268) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`skadd_val` failed to match `").Append(_0024_0024match_002419_002417248).Append("`").ToString());
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

		internal MacroStatement _0024skadd_val_002417271;

		internal Skadd_valMacro _0024self__002417272;

		public _0024ExpandGeneratorImpl_002417247(MacroStatement skadd_val, Skadd_valMacro self_)
		{
			_0024skadd_val_002417271 = skadd_val;
			_0024self__002417272 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024skadd_val_002417271, _0024self__002417272);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Skadd_valMacro()
	{
	}

	public Skadd_valMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement skadd_val)
	{
		return new _0024ExpandGeneratorImpl_002417247(skadd_val, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement skadd_val)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'skadd_val' is using. Read BOO-1077 for more info.");
	}
}
