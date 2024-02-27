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
public sealed class Sk_ifMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002417273 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002422_002417274;

			internal MacroStatement _0024_0024match_002423_002417275;

			internal Expression _0024effType_002417276;

			internal ReferenceExpression _0024_00244358_002417277;

			internal ReferenceExpression _0024_00244359_002417278;

			internal BinaryExpression _0024_00244360_002417279;

			internal Block _0024_00244361_002417280;

			internal IfStatement _0024_00244362_002417281;

			internal MacroStatement _0024_0024match_002424_002417282;

			internal Expression _0024cond_002417283;

			internal ReferenceExpression _0024_00244363_002417284;

			internal ReferenceExpression _0024_00244364_002417285;

			internal BinaryExpression _0024_00244365_002417286;

			internal BinaryExpression _0024_00244366_002417287;

			internal Block _0024_00244367_002417288;

			internal IfStatement _0024_00244368_002417289;

			internal MacroStatement _0024sk_if_002417290;

			internal Sk_ifMacro _0024self__002417291;

			public _0024(MacroStatement sk_if, Sk_ifMacro self_)
			{
				_0024sk_if_002417290 = sk_if;
				_0024self__002417291 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024sk_if_002417290 == null)
					{
						throw new ArgumentNullException("sk_if");
					}
					_0024self__002417291.__macro = _0024sk_if_002417290;
					_0024_0024match_002422_002417274 = _0024sk_if_002417290;
					if (_0024_0024match_002422_002417274 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002423_002417275 = _0024_0024match_002422_002417274);
						if (true && _0024_0024match_002423_002417275.Name == "sk_if" && 1 == ((ICollection)_0024_0024match_002423_002417275.Arguments).Count)
						{
							Expression expression = (_0024effType_002417276 = _0024_0024match_002423_002417275.Arguments[0]);
							if (true)
							{
								IfStatement ifStatement = (_0024_00244362_002417281 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement2 = _0024_00244362_002417281;
								BinaryExpression binaryExpression = (_0024_00244360_002417279 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00244360_002417279.Operator = BinaryOperatorType.Equality);
								BinaryExpression binaryExpression2 = _0024_00244360_002417279;
								ReferenceExpression referenceExpression = (_0024_00244358_002417277 = new ReferenceExpression(LexicalInfo.Empty));
								string text2 = (_0024_00244358_002417277.Name = "EffectType");
								Expression expression3 = (binaryExpression2.Left = _0024_00244358_002417277);
								BinaryExpression binaryExpression3 = _0024_00244360_002417279;
								ReferenceExpression referenceExpression2 = (_0024_00244359_002417278 = new ReferenceExpression(LexicalInfo.Empty));
								string text4 = (_0024_00244359_002417278.Name = "EnumSkillEffectTypes");
								Expression expression5 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00244359_002417278, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417276)));
								Expression expression7 = (ifStatement2.Condition = _0024_00244360_002417279);
								IfStatement ifStatement3 = _0024_00244362_002417281;
								Block block = (_0024_00244361_002417280 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection2 = (_0024_00244361_002417280.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024sk_if_002417290.Body))));
								Block block3 = (ifStatement3.TrueBlock = _0024_00244361_002417280);
								result = (Yield(2, _0024_00244362_002417281) ? 1 : 0);
								break;
							}
						}
					}
					if (_0024_0024match_002422_002417274 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002424_002417282 = _0024_0024match_002422_002417274);
						if (true && _0024_0024match_002424_002417282.Name == "sk_if" && 2 == ((ICollection)_0024_0024match_002424_002417282.Arguments).Count)
						{
							Expression expression8 = (_0024effType_002417276 = _0024_0024match_002424_002417282.Arguments[0]);
							if (true)
							{
								Expression expression9 = (_0024cond_002417283 = _0024_0024match_002424_002417282.Arguments[1]);
								if (true)
								{
									IfStatement ifStatement4 = (_0024_00244368_002417289 = new IfStatement(LexicalInfo.Empty));
									IfStatement ifStatement5 = _0024_00244368_002417289;
									BinaryExpression binaryExpression4 = (_0024_00244366_002417287 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType4 = (_0024_00244366_002417287.Operator = BinaryOperatorType.And);
									BinaryExpression binaryExpression5 = _0024_00244366_002417287;
									BinaryExpression binaryExpression6 = (_0024_00244365_002417286 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType6 = (_0024_00244365_002417286.Operator = BinaryOperatorType.Equality);
									BinaryExpression binaryExpression7 = _0024_00244365_002417286;
									ReferenceExpression referenceExpression3 = (_0024_00244363_002417284 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00244363_002417284.Name = "EffectType");
									Expression expression11 = (binaryExpression7.Left = _0024_00244363_002417284);
									BinaryExpression binaryExpression8 = _0024_00244365_002417286;
									ReferenceExpression referenceExpression4 = (_0024_00244364_002417285 = new ReferenceExpression(LexicalInfo.Empty));
									string text8 = (_0024_00244364_002417285.Name = "EnumSkillEffectTypes");
									Expression expression13 = (binaryExpression8.Right = new MemberReferenceExpression(_0024_00244364_002417285, CodeSerializer.LiftName((ReferenceExpression)_0024effType_002417276)));
									Expression expression15 = (binaryExpression5.Left = _0024_00244365_002417286);
									Expression expression17 = (_0024_00244366_002417287.Right = Expression.Lift(_0024cond_002417283));
									Expression expression19 = (ifStatement5.Condition = _0024_00244366_002417287);
									IfStatement ifStatement6 = _0024_00244368_002417289;
									Block block4 = (_0024_00244367_002417288 = new Block(LexicalInfo.Empty));
									StatementCollection statementCollection4 = (_0024_00244367_002417288.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024sk_if_002417290.Body))));
									Block block6 = (ifStatement6.TrueBlock = _0024_00244367_002417288);
									result = (Yield(3, _0024_00244368_002417289) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`sk_if` failed to match `").Append(_0024_0024match_002422_002417274).Append("`").ToString());
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

		internal MacroStatement _0024sk_if_002417292;

		internal Sk_ifMacro _0024self__002417293;

		public _0024ExpandGeneratorImpl_002417273(MacroStatement sk_if, Sk_ifMacro self_)
		{
			_0024sk_if_002417292 = sk_if;
			_0024self__002417293 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024sk_if_002417292, _0024self__002417293);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Sk_ifMacro()
	{
	}

	public Sk_ifMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement sk_if)
	{
		return new _0024ExpandGeneratorImpl_002417273(sk_if, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement sk_if)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'sk_if' is using. Read BOO-1077 for more info.");
	}
}
