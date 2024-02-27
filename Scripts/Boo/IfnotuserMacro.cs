using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class IfnotuserMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424324 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024106_002424325;

			internal MacroStatement _0024_0024match_0024107_002424326;

			internal StringLiteralExpression _0024n_002424327;

			internal string _0024un_002424328;

			internal MacroStatement _0024ifnotuser_002424329;

			internal IfnotuserMacro _0024self__002424330;

			public _0024(MacroStatement ifnotuser, IfnotuserMacro self_)
			{
				_0024ifnotuser_002424329 = ifnotuser;
				_0024self__002424330 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024ifnotuser_002424329 == null)
					{
						throw new ArgumentNullException("ifnotuser");
					}
					_0024self__002424330.__macro = _0024ifnotuser_002424329;
					_0024_0024match_0024106_002424325 = _0024ifnotuser_002424329;
					if (_0024_0024match_0024106_002424325 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024107_002424326 = _0024_0024match_0024106_002424325);
						if (true && _0024_0024match_0024107_002424326.Name == "ifnotuser" && 1 == ((ICollection)_0024_0024match_0024107_002424326.Arguments).Count && _0024_0024match_0024107_002424326.Arguments[0] is StringLiteralExpression)
						{
							StringLiteralExpression stringLiteralExpression = (_0024n_002424327 = (StringLiteralExpression)_0024_0024match_0024107_002424326.Arguments[0]);
							if (true)
							{
								_0024un_002424328 = Environment.GetEnvironmentVariable("USERNAME");
								if (string.IsNullOrEmpty(_0024un_002424328))
								{
									_0024un_002424328 = Environment.GetEnvironmentVariable("USER");
								}
								if (_0024un_002424328 != _0024n_002424327.Value)
								{
									result = (Yield(2, _0024ifnotuser_002424329.Body) ? 1 : 0);
									break;
								}
								goto case 2;
							}
						}
					}
					throw new Exception("`ifnotuser` macro invocation argument(s) did not match definition: `ifnotuser((n as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
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

		internal MacroStatement _0024ifnotuser_002424331;

		internal IfnotuserMacro _0024self__002424332;

		public _0024ExpandGeneratorImpl_002424324(MacroStatement ifnotuser, IfnotuserMacro self_)
		{
			_0024ifnotuser_002424331 = ifnotuser;
			_0024self__002424332 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024ifnotuser_002424331, _0024self__002424332);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public IfnotuserMacro()
	{
	}

	public IfnotuserMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement ifnotuser)
	{
		return new _0024ExpandGeneratorImpl_002424324(ifnotuser, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement ifnotuser)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'ifnotuser' is using. Read BOO-1077 for more info.");
	}
}
