using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Define_battle_hudMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	public sealed class GuardMacro : LexicalInfoPreservingGeneratorMacro
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024ExpandGeneratorImpl_002421280 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
			{
				internal ExpressionCollection _0024args_002421281;

				internal int _0024nargs_002421282;

				internal ReferenceExpression _0024_00244977_002421283;

				internal BinaryExpression _0024_00244978_002421284;

				internal StatementModifier _0024_00244979_002421285;

				internal ReturnStatement _0024_00244980_002421286;

				internal ReferenceExpression _0024_00244981_002421287;

				internal ReferenceExpression _0024_00244982_002421288;

				internal BinaryExpression _0024_00244983_002421289;

				internal ReferenceExpression _0024_00244984_002421290;

				internal BinaryExpression _0024_00244985_002421291;

				internal StatementModifier _0024_00244986_002421292;

				internal ReturnStatement _0024_00244987_002421293;

				internal Block _0024_00244988_002421294;

				internal ReferenceExpression _0024_00244989_002421295;

				internal BinaryExpression _0024_00244990_002421296;

				internal StatementModifier _0024_00244991_002421297;

				internal ReturnStatement _0024_00244992_002421298;

				internal int _0024i_002421299;

				internal ReferenceExpression _0024var_002421300;

				internal ReferenceExpression _0024_00244993_002421301;

				internal BinaryExpression _0024_00244994_002421302;

				internal BinaryExpression _0024_00244995_002421303;

				internal StatementModifier _0024_00244996_002421304;

				internal ReturnStatement _0024_00244997_002421305;

				internal Block _0024_00244998_002421306;

				internal int _0024_002410328_002421307;

				internal int _0024_002410329_002421308;

				internal MacroStatement _0024guard_002421309;

				internal GuardMacro _0024self__002421310;

				public _0024(MacroStatement guard, GuardMacro self_)
				{
					_0024guard_002421309 = guard;
					_0024self__002421310 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (_0024guard_002421309 == null)
						{
							throw new ArgumentNullException("guard");
						}
						_0024self__002421310.__macro = _0024guard_002421309;
						_0024args_002421281 = _0024guard_002421309.Arguments;
						_0024nargs_002421282 = ((ICollection)_0024args_002421281).Count;
						if (_0024nargs_002421282 <= 0)
						{
							throw new Exception("no arguments for 'guard' macro");
						}
						if (_0024nargs_002421282 == 1)
						{
							Block block = (_0024_00244988_002421294 = new Block(LexicalInfo.Empty));
							Block block2 = _0024_00244988_002421294;
							Statement[] array = new Statement[3];
							ReturnStatement returnStatement = (_0024_00244980_002421286 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement2 = _0024_00244980_002421286;
							StatementModifier statementModifier = (_0024_00244979_002421285 = new StatementModifier(LexicalInfo.Empty));
							StatementModifierType statementModifierType2 = (_0024_00244979_002421285.Type = StatementModifierType.If);
							StatementModifier statementModifier2 = _0024_00244979_002421285;
							BinaryExpression binaryExpression = (_0024_00244978_002421284 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType2 = (_0024_00244978_002421284.Operator = BinaryOperatorType.Equality);
							BinaryExpression binaryExpression2 = _0024_00244978_002421284;
							ReferenceExpression referenceExpression = (_0024_00244977_002421283 = new ReferenceExpression(LexicalInfo.Empty));
							string text2 = (_0024_00244977_002421283.Name = "CurrentInstance");
							Expression expression2 = (binaryExpression2.Left = _0024_00244977_002421283);
							Expression expression4 = (_0024_00244978_002421284.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression6 = (statementModifier2.Condition = _0024_00244978_002421284);
							StatementModifier statementModifier4 = (returnStatement2.Modifier = _0024_00244979_002421285);
							array[0] = Statement.Lift(_0024_00244980_002421286);
							BinaryExpression binaryExpression3 = (_0024_00244983_002421289 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType4 = (_0024_00244983_002421289.Operator = BinaryOperatorType.Assign);
							BinaryExpression binaryExpression4 = _0024_00244983_002421289;
							ReferenceExpression referenceExpression2 = (_0024_00244981_002421287 = new ReferenceExpression(LexicalInfo.Empty));
							string text4 = (_0024_00244981_002421287.Name = "target");
							Expression expression8 = (binaryExpression4.Left = _0024_00244981_002421287);
							BinaryExpression binaryExpression5 = _0024_00244983_002421289;
							ReferenceExpression referenceExpression3 = (_0024_00244982_002421288 = new ReferenceExpression(LexicalInfo.Empty));
							string text6 = (_0024_00244982_002421288.Name = "CurrentInstance");
							Expression expression10 = (binaryExpression5.Right = new MemberReferenceExpression(_0024_00244982_002421288, CodeSerializer.LiftName((ReferenceExpression)_0024args_002421281[0])));
							array[1] = Statement.Lift(_0024_00244983_002421289);
							ReturnStatement returnStatement3 = (_0024_00244987_002421293 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement4 = _0024_00244987_002421293;
							StatementModifier statementModifier5 = (_0024_00244986_002421292 = new StatementModifier(LexicalInfo.Empty));
							StatementModifierType statementModifierType4 = (_0024_00244986_002421292.Type = StatementModifierType.If);
							StatementModifier statementModifier6 = _0024_00244986_002421292;
							BinaryExpression binaryExpression6 = (_0024_00244985_002421291 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType6 = (_0024_00244985_002421291.Operator = BinaryOperatorType.Equality);
							BinaryExpression binaryExpression7 = _0024_00244985_002421291;
							ReferenceExpression referenceExpression4 = (_0024_00244984_002421290 = new ReferenceExpression(LexicalInfo.Empty));
							string text8 = (_0024_00244984_002421290.Name = "target");
							Expression expression12 = (binaryExpression7.Left = _0024_00244984_002421290);
							Expression expression14 = (_0024_00244985_002421291.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression16 = (statementModifier6.Condition = _0024_00244985_002421291);
							StatementModifier statementModifier8 = (returnStatement4.Modifier = _0024_00244986_002421292);
							array[2] = Statement.Lift(_0024_00244987_002421293);
							StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
							result = (Yield(2, _0024_00244988_002421294) ? 1 : 0);
						}
						else
						{
							ReturnStatement returnStatement5 = (_0024_00244992_002421298 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement6 = _0024_00244992_002421298;
							StatementModifier statementModifier9 = (_0024_00244991_002421297 = new StatementModifier(LexicalInfo.Empty));
							StatementModifierType statementModifierType6 = (_0024_00244991_002421297.Type = StatementModifierType.If);
							StatementModifier statementModifier10 = _0024_00244991_002421297;
							BinaryExpression binaryExpression8 = (_0024_00244990_002421296 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType8 = (_0024_00244990_002421296.Operator = BinaryOperatorType.Equality);
							BinaryExpression binaryExpression9 = _0024_00244990_002421296;
							ReferenceExpression referenceExpression5 = (_0024_00244989_002421295 = new ReferenceExpression(LexicalInfo.Empty));
							string text10 = (_0024_00244989_002421295.Name = "CurrentInstance");
							Expression expression18 = (binaryExpression9.Left = _0024_00244989_002421295);
							Expression expression20 = (_0024_00244990_002421296.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression22 = (statementModifier10.Condition = _0024_00244990_002421296);
							StatementModifier statementModifier12 = (returnStatement6.Modifier = _0024_00244991_002421297);
							result = (Yield(3, _0024_00244992_002421298) ? 1 : 0);
						}
						break;
					case 3:
						_0024_002410328_002421307 = 0;
						_0024_002410329_002421308 = _0024nargs_002421282;
						if (_0024_002410329_002421308 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						goto case 4;
					case 4:
						if (_0024_002410328_002421307 < _0024_002410329_002421308)
						{
							_0024i_002421299 = _0024_002410328_002421307;
							_0024_002410328_002421307++;
							_0024var_002421300 = new ReferenceExpression(new StringBuilder("target").Append((object)checked(_0024i_002421299 + 1)).ToString());
							Block block3 = (_0024_00244998_002421306 = new Block(LexicalInfo.Empty));
							Block block4 = _0024_00244998_002421306;
							Statement[] array2 = new Statement[2];
							BinaryExpression binaryExpression10 = (_0024_00244994_002421302 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType10 = (_0024_00244994_002421302.Operator = BinaryOperatorType.Assign);
							Expression expression24 = (_0024_00244994_002421302.Left = Expression.Lift(_0024var_002421300));
							BinaryExpression binaryExpression11 = _0024_00244994_002421302;
							ReferenceExpression referenceExpression6 = (_0024_00244993_002421301 = new ReferenceExpression(LexicalInfo.Empty));
							string text12 = (_0024_00244993_002421301.Name = "CurrentInstance");
							Expression expression26 = (binaryExpression11.Right = new MemberReferenceExpression(_0024_00244993_002421301, CodeSerializer.LiftName((ReferenceExpression)_0024args_002421281[_0024i_002421299])));
							array2[0] = Statement.Lift(_0024_00244994_002421302);
							ReturnStatement returnStatement7 = (_0024_00244997_002421305 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement8 = _0024_00244997_002421305;
							StatementModifier statementModifier13 = (_0024_00244996_002421304 = new StatementModifier(LexicalInfo.Empty));
							StatementModifierType statementModifierType8 = (_0024_00244996_002421304.Type = StatementModifierType.If);
							StatementModifier statementModifier14 = _0024_00244996_002421304;
							BinaryExpression binaryExpression12 = (_0024_00244995_002421303 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType12 = (_0024_00244995_002421303.Operator = BinaryOperatorType.Equality);
							Expression expression28 = (_0024_00244995_002421303.Left = Expression.Lift(_0024var_002421300));
							Expression expression30 = (_0024_00244995_002421303.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression32 = (statementModifier14.Condition = _0024_00244995_002421303);
							StatementModifier statementModifier16 = (returnStatement8.Modifier = _0024_00244996_002421304);
							array2[1] = Statement.Lift(_0024_00244997_002421305);
							StatementCollection statementCollection4 = (block4.Statements = StatementCollection.FromArray(array2));
							result = (Yield(4, _0024_00244998_002421306) ? 1 : 0);
							break;
						}
						goto case 2;
					case 2:
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal MacroStatement _0024guard_002421311;

			internal GuardMacro _0024self__002421312;

			public _0024ExpandGeneratorImpl_002421280(MacroStatement guard, GuardMacro self_)
			{
				_0024guard_002421311 = guard;
				_0024self__002421312 = self_;
			}

			public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
			{
				return new _0024(_0024guard_002421311, _0024self__002421312);
			}
		}

		[CompilerGenerated]
		private MacroStatement __macro;

		[CompilerGenerated]
		private MacroStatement _0024define_battle_hud;

		[CompilerGenerated]
		private MacroStatement define_battle_hud
		{
			get
			{
				if (_0024define_battle_hud == null)
				{
					_0024define_battle_hud = __macro.GetParentMacroByName("define_battle_hud");
				}
				return _0024define_battle_hud;
			}
		}

		public GuardMacro()
		{
		}

		public GuardMacro(CompilerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			base._002Ector(context);
		}

		protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement guard)
		{
			return new _0024ExpandGeneratorImpl_002421280(guard, this);
		}

		[CompilerGenerated]
		protected override Statement ExpandImpl(MacroStatement guard)
		{
			throw new NotImplementedException("Boo installed version is older than the new macro syntax 'guard' is using. Read BOO-1077 for more info.");
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002421273 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal SimpleTypeReference _0024_00244975_002421274;

			internal ClassDefinition _0024_00244976_002421275;

			internal MacroStatement _0024define_battle_hud_002421276;

			internal Define_battle_hudMacro _0024self__002421277;

			public _0024(MacroStatement define_battle_hud, Define_battle_hudMacro self_)
			{
				_0024define_battle_hud_002421276 = define_battle_hud;
				_0024self__002421277 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024define_battle_hud_002421276 == null)
					{
						throw new ArgumentNullException("define_battle_hud");
					}
					_0024self__002421277.__macro = _0024define_battle_hud_002421276;
					ClassDefinition classDefinition = (_0024_00244976_002421275 = new ClassDefinition(LexicalInfo.Empty));
					string text2 = (_0024_00244976_002421275.Name = "BattleHUD");
					TypeMemberCollection typeMemberCollection2 = (_0024_00244976_002421275.Members = TypeMemberCollection.FromArray(TypeMember.Lift(_0024define_battle_hud_002421276.Body)));
					ClassDefinition classDefinition2 = _0024_00244976_002421275;
					TypeReference[] array = new TypeReference[1];
					SimpleTypeReference simpleTypeReference = (_0024_00244975_002421274 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag2 = (_0024_00244975_002421274.IsPointer = false);
					string text4 = (_0024_00244975_002421274.Name = "MonoBehaviour");
					array[0] = _0024_00244975_002421274;
					TypeReferenceCollection typeReferenceCollection2 = (classDefinition2.BaseTypes = TypeReferenceCollection.FromArray(array));
					result = (Yield(2, _0024_00244976_002421275) ? 1 : 0);
					break;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024define_battle_hud_002421278;

		internal Define_battle_hudMacro _0024self__002421279;

		public _0024ExpandGeneratorImpl_002421273(MacroStatement define_battle_hud, Define_battle_hudMacro self_)
		{
			_0024define_battle_hud_002421278 = define_battle_hud;
			_0024self__002421279 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024define_battle_hud_002421278, _0024self__002421279);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Define_battle_hudMacro()
	{
	}

	public Define_battle_hudMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement define_battle_hud)
	{
		return new _0024ExpandGeneratorImpl_002421273(define_battle_hud, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement define_battle_hud)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'define_battle_hud' is using. Read BOO-1077 for more info.");
	}
}
