using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class While_updateMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424238 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002492_002424239;

			internal MacroStatement _0024_0024match_002493_002424240;

			internal Expression _0024expression_002424241;

			internal Block _0024_00246422_002424242;

			internal WhileStatement _0024_00246423_002424243;

			internal MacroStatement _0024while_update_002424244;

			internal While_updateMacro _0024self__002424245;

			public _0024(MacroStatement while_update, While_updateMacro self_)
			{
				_0024while_update_002424244 = while_update;
				_0024self__002424245 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024while_update_002424244 == null)
					{
						throw new ArgumentNullException("while_update");
					}
					_0024self__002424245.__macro = _0024while_update_002424244;
					_0024_0024match_002492_002424239 = _0024while_update_002424244;
					if (_0024_0024match_002492_002424239 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002493_002424240 = _0024_0024match_002492_002424239);
						if (true && _0024_0024match_002493_002424240.Name == "while_update" && 1 == ((ICollection)_0024_0024match_002493_002424240.Arguments).Count && _0024_0024match_002493_002424240.Arguments[0] is Expression)
						{
							Expression expression = (_0024expression_002424241 = _0024_0024match_002493_002424240.Arguments[0]);
							if (true)
							{
								WhileStatement whileStatement = (_0024_00246423_002424243 = new WhileStatement(LexicalInfo.Empty));
								Expression expression3 = (_0024_00246423_002424243.Condition = Expression.Lift(_0024expression_002424241));
								WhileStatement whileStatement2 = _0024_00246423_002424243;
								Block block = (_0024_00246422_002424242 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection2 = (_0024_00246422_002424242.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024while_update_002424244.Body)), Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
								Block block3 = (whileStatement2.Block = _0024_00246422_002424242);
								result = (Yield(2, _0024_00246423_002424243) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`while_update` macro invocation argument(s) did not match definition: `while_update((expression as Boo.Lang.Compiler.Ast.Expression))`");
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

		internal MacroStatement _0024while_update_002424246;

		internal While_updateMacro _0024self__002424247;

		public _0024ExpandGeneratorImpl_002424238(MacroStatement while_update, While_updateMacro self_)
		{
			_0024while_update_002424246 = while_update;
			_0024self__002424247 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024while_update_002424246, _0024self__002424247);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public While_updateMacro()
	{
	}

	public While_updateMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement while_update)
	{
		return new _0024ExpandGeneratorImpl_002424238(while_update, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement while_update)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'while_update' is using. Read BOO-1077 for more info.");
	}
}
