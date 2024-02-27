using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class IfuserMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424296 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024100_002424297;

			internal MacroStatement _0024_0024match_0024101_002424298;

			internal StringLiteralExpression _0024n_002424299;

			internal string _0024un_002424300;

			internal MacroStatement _0024ifuser_002424301;

			internal IfuserMacro _0024self__002424302;

			public _0024(MacroStatement ifuser, IfuserMacro self_)
			{
				_0024ifuser_002424301 = ifuser;
				_0024self__002424302 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024ifuser_002424301 == null)
					{
						throw new ArgumentNullException("ifuser");
					}
					_0024self__002424302.__macro = _0024ifuser_002424301;
					_0024_0024match_0024100_002424297 = _0024ifuser_002424301;
					if (_0024_0024match_0024100_002424297 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024101_002424298 = _0024_0024match_0024100_002424297);
						if (true && _0024_0024match_0024101_002424298.Name == "ifuser" && 1 == ((ICollection)_0024_0024match_0024101_002424298.Arguments).Count && _0024_0024match_0024101_002424298.Arguments[0] is StringLiteralExpression)
						{
							StringLiteralExpression stringLiteralExpression = (_0024n_002424299 = (StringLiteralExpression)_0024_0024match_0024101_002424298.Arguments[0]);
							if (true)
							{
								_0024un_002424300 = Environment.GetEnvironmentVariable("USERNAME");
								if (string.IsNullOrEmpty(_0024un_002424300))
								{
									_0024un_002424300 = Environment.GetEnvironmentVariable("USER");
								}
								if (_0024un_002424300 == _0024n_002424299.Value)
								{
									result = (Yield(2, _0024ifuser_002424301.Body) ? 1 : 0);
									break;
								}
								goto case 2;
							}
						}
					}
					throw new Exception("`ifuser` macro invocation argument(s) did not match definition: `ifuser((n as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
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

		internal MacroStatement _0024ifuser_002424303;

		internal IfuserMacro _0024self__002424304;

		public _0024ExpandGeneratorImpl_002424296(MacroStatement ifuser, IfuserMacro self_)
		{
			_0024ifuser_002424303 = ifuser;
			_0024self__002424304 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024ifuser_002424303, _0024self__002424304);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public IfuserMacro()
	{
	}

	public IfuserMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement ifuser)
	{
		return new _0024ExpandGeneratorImpl_002424296(ifuser, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement ifuser)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'ifuser' is using. Read BOO-1077 for more info.");
	}
}
