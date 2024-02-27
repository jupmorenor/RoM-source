using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class IfdefenvMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424315 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024104_002424316;

			internal MacroStatement _0024_0024match_0024105_002424317;

			internal StringLiteralExpression _0024n_002424318;

			internal string _0024ev_002424319;

			internal MacroStatement _0024ifdefenv_002424320;

			internal IfdefenvMacro _0024self__002424321;

			public _0024(MacroStatement ifdefenv, IfdefenvMacro self_)
			{
				_0024ifdefenv_002424320 = ifdefenv;
				_0024self__002424321 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024ifdefenv_002424320 == null)
					{
						throw new ArgumentNullException("ifdefenv");
					}
					_0024self__002424321.__macro = _0024ifdefenv_002424320;
					_0024_0024match_0024104_002424316 = _0024ifdefenv_002424320;
					if (_0024_0024match_0024104_002424316 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024105_002424317 = _0024_0024match_0024104_002424316);
						if (true && _0024_0024match_0024105_002424317.Name == "ifdefenv" && 1 == ((ICollection)_0024_0024match_0024105_002424317.Arguments).Count && _0024_0024match_0024105_002424317.Arguments[0] is StringLiteralExpression)
						{
							StringLiteralExpression stringLiteralExpression = (_0024n_002424318 = (StringLiteralExpression)_0024_0024match_0024105_002424317.Arguments[0]);
							if (true)
							{
								_0024ev_002424319 = Environment.GetEnvironmentVariable(_0024n_002424318.Value);
								if (!string.IsNullOrEmpty(_0024ev_002424319))
								{
									result = (Yield(2, _0024ifdefenv_002424320.Body) ? 1 : 0);
									break;
								}
								goto case 2;
							}
						}
					}
					throw new Exception("`ifdefenv` macro invocation argument(s) did not match definition: `ifdefenv((n as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
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

		internal MacroStatement _0024ifdefenv_002424322;

		internal IfdefenvMacro _0024self__002424323;

		public _0024ExpandGeneratorImpl_002424315(MacroStatement ifdefenv, IfdefenvMacro self_)
		{
			_0024ifdefenv_002424322 = ifdefenv;
			_0024self__002424323 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024ifdefenv_002424322, _0024self__002424323);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public IfdefenvMacro()
	{
	}

	public IfdefenvMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement ifdefenv)
	{
		return new _0024ExpandGeneratorImpl_002424315(ifdefenv, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement ifdefenv)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'ifdefenv' is using. Read BOO-1077 for more info.");
	}
}
