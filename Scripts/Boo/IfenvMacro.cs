using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public sealed class IfenvMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424305 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024102_002424306;

			internal MacroStatement _0024_0024match_0024103_002424307;

			internal StringLiteralExpression _0024n_002424308;

			internal StringLiteralExpression _0024v_002424309;

			internal string _0024ev_002424310;

			internal MacroStatement _0024ifenv_002424311;

			internal IfenvMacro _0024self__002424312;

			public _0024(MacroStatement ifenv, IfenvMacro self_)
			{
				_0024ifenv_002424311 = ifenv;
				_0024self__002424312 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024ifenv_002424311 == null)
					{
						throw new ArgumentNullException("ifenv");
					}
					_0024self__002424312.__macro = _0024ifenv_002424311;
					_0024_0024match_0024102_002424306 = _0024ifenv_002424311;
					if (_0024_0024match_0024102_002424306 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024103_002424307 = _0024_0024match_0024102_002424306);
						if (true && _0024_0024match_0024103_002424307.Name == "ifenv" && 2 == ((ICollection)_0024_0024match_0024103_002424307.Arguments).Count && _0024_0024match_0024103_002424307.Arguments[0] is StringLiteralExpression)
						{
							StringLiteralExpression stringLiteralExpression = (_0024n_002424308 = (StringLiteralExpression)_0024_0024match_0024103_002424307.Arguments[0]);
							if (true && _0024_0024match_0024103_002424307.Arguments[1] is StringLiteralExpression)
							{
								StringLiteralExpression stringLiteralExpression2 = (_0024v_002424309 = (StringLiteralExpression)_0024_0024match_0024103_002424307.Arguments[1]);
								if (true)
								{
									_0024ev_002424310 = Environment.GetEnvironmentVariable(_0024n_002424308.Value);
									if (RuntimeServices.EqualityOperator(_0024ev_002424310, _0024v_002424309))
									{
										result = (Yield(2, _0024ifenv_002424311.Body) ? 1 : 0);
										break;
									}
									goto case 2;
								}
							}
						}
					}
					throw new Exception("`ifenv` macro invocation argument(s) did not match definition: `ifenv((n as Boo.Lang.Compiler.Ast.StringLiteralExpression), (v as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
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

		internal MacroStatement _0024ifenv_002424313;

		internal IfenvMacro _0024self__002424314;

		public _0024ExpandGeneratorImpl_002424305(MacroStatement ifenv, IfenvMacro self_)
		{
			_0024ifenv_002424313 = ifenv;
			_0024self__002424314 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024ifenv_002424313, _0024self__002424314);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public IfenvMacro()
	{
	}

	public IfenvMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement ifenv)
	{
		return new _0024ExpandGeneratorImpl_002424305(ifenv, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement ifenv)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'ifenv' is using. Read BOO-1077 for more info.");
	}
}
