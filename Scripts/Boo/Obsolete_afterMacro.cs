using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Obsolete_afterMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424417 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024136_002424418;

			internal MacroStatement _0024_0024match_0024137_002424419;

			internal StringLiteralExpression _0024_0024match_0024138_002424420;

			internal string _0024d_002424421;

			internal DateTime _0024dd_002424422;

			internal DateTime _0024now_002424423;

			internal MacroStatement _0024obsolete_after_002424424;

			internal Obsolete_afterMacro _0024self__002424425;

			public _0024(MacroStatement obsolete_after, Obsolete_afterMacro self_)
			{
				_0024obsolete_after_002424424 = obsolete_after;
				_0024self__002424425 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024obsolete_after_002424424 == null)
					{
						throw new ArgumentNullException("obsolete_after");
					}
					_0024self__002424425.__macro = _0024obsolete_after_002424424;
					_0024_0024match_0024136_002424418 = _0024obsolete_after_002424424;
					if (_0024_0024match_0024136_002424418 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024137_002424419 = _0024_0024match_0024136_002424418);
						if (true && _0024_0024match_0024137_002424419.Name == "obsolete_after" && 1 == ((ICollection)_0024_0024match_0024137_002424419.Arguments).Count && _0024_0024match_0024137_002424419.Arguments[0] is StringLiteralExpression)
						{
							StringLiteralExpression stringLiteralExpression = (_0024_0024match_0024138_002424420 = (StringLiteralExpression)_0024_0024match_0024137_002424419.Arguments[0]);
							if (true)
							{
								string text = (_0024d_002424421 = _0024_0024match_0024138_002424420.Value);
								if (true)
								{
									_0024dd_002424422 = DateTime.Now;
									try
									{
										_0024dd_002424422 = DateTime.Parse(_0024d_002424421);
									}
									catch (Exception)
									{
										throw new Exception(new StringBuilder("invalid datetime string: ").Append(_0024d_002424421).ToString());
									}
									_0024now_002424423 = DateTime.Now;
									if (_0024now_002424423 <= _0024dd_002424422)
									{
										result = (Yield(2, _0024obsolete_after_002424424.Body) ? 1 : 0);
										break;
									}
									goto case 2;
								}
							}
						}
					}
					throw new Exception("`obsolete_after` macro invocation argument(s) did not match definition: `obsolete_after((d as string))`");
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

		internal MacroStatement _0024obsolete_after_002424426;

		internal Obsolete_afterMacro _0024self__002424427;

		public _0024ExpandGeneratorImpl_002424417(MacroStatement obsolete_after, Obsolete_afterMacro self_)
		{
			_0024obsolete_after_002424426 = obsolete_after;
			_0024self__002424427 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024obsolete_after_002424426, _0024self__002424427);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Obsolete_afterMacro()
	{
	}

	public Obsolete_afterMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement obsolete_after)
	{
		return new _0024ExpandGeneratorImpl_002424417(obsolete_after, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement obsolete_after)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'obsolete_after' is using. Read BOO-1077 for more info.");
	}
}
