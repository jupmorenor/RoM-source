using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Update_whileMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424228 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002490_002424229;

			internal MacroStatement _0024_0024match_002491_002424230;

			internal Expression _0024expression_002424231;

			internal Block _0024_00246420_002424232;

			internal WhileStatement _0024_00246421_002424233;

			internal MacroStatement _0024update_while_002424234;

			internal Update_whileMacro _0024self__002424235;

			public _0024(MacroStatement update_while, Update_whileMacro self_)
			{
				_0024update_while_002424234 = update_while;
				_0024self__002424235 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024update_while_002424234 == null)
					{
						throw new ArgumentNullException("update_while");
					}
					_0024self__002424235.__macro = _0024update_while_002424234;
					_0024_0024match_002490_002424229 = _0024update_while_002424234;
					if (_0024_0024match_002490_002424229 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002491_002424230 = _0024_0024match_002490_002424229);
						if (true && _0024_0024match_002491_002424230.Name == "update_while" && 1 == ((ICollection)_0024_0024match_002491_002424230.Arguments).Count && _0024_0024match_002491_002424230.Arguments[0] is Expression)
						{
							Expression expression = (_0024expression_002424231 = _0024_0024match_002491_002424230.Arguments[0]);
							if (true)
							{
								WhileStatement whileStatement = (_0024_00246421_002424233 = new WhileStatement(LexicalInfo.Empty));
								Expression expression3 = (_0024_00246421_002424233.Condition = Expression.Lift(_0024expression_002424231));
								WhileStatement whileStatement2 = _0024_00246421_002424233;
								Block block = (_0024_00246420_002424232 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection2 = (_0024_00246420_002424232.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024update_while_002424234.Body)), Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
								Block block3 = (whileStatement2.Block = _0024_00246420_002424232);
								result = (Yield(2, _0024_00246421_002424233) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`update_while` macro invocation argument(s) did not match definition: `update_while((expression as Boo.Lang.Compiler.Ast.Expression))`");
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

		internal MacroStatement _0024update_while_002424236;

		internal Update_whileMacro _0024self__002424237;

		public _0024ExpandGeneratorImpl_002424228(MacroStatement update_while, Update_whileMacro self_)
		{
			_0024update_while_002424236 = update_while;
			_0024self__002424237 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024update_while_002424236, _0024self__002424237);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Update_whileMacro()
	{
	}

	public Update_whileMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement update_while)
	{
		return new _0024ExpandGeneratorImpl_002424228(update_while, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement update_while)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'update_while' is using. Read BOO-1077 for more info.");
	}
}
