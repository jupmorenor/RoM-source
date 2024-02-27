using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class BuildDateMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424207 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002486_002424208;

			internal MacroStatement _0024_0024match_002487_002424209;

			internal ReferenceExpression _0024varName_002424210;

			internal DateTime _0024now_002424211;

			internal string _0024dts_002424212;

			internal BinaryExpression _0024_00246418_002424213;

			internal MacroStatement _0024BuildDate_002424214;

			internal BuildDateMacro _0024self__002424215;

			public _0024(MacroStatement BuildDate, BuildDateMacro self_)
			{
				_0024BuildDate_002424214 = BuildDate;
				_0024self__002424215 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024BuildDate_002424214 == null)
					{
						throw new ArgumentNullException("BuildDate");
					}
					_0024self__002424215.__macro = _0024BuildDate_002424214;
					_0024_0024match_002486_002424208 = _0024BuildDate_002424214;
					if (_0024_0024match_002486_002424208 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002487_002424209 = _0024_0024match_002486_002424208);
						if (true && _0024_0024match_002487_002424209.Name == "BuildDate" && 1 == ((ICollection)_0024_0024match_002487_002424209.Arguments).Count && _0024_0024match_002487_002424209.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression = (_0024varName_002424210 = (ReferenceExpression)_0024_0024match_002487_002424209.Arguments[0]);
							if (true)
							{
								_0024now_002424211 = DateTime.Now;
								_0024dts_002424212 = $"{_0024now_002424211.Year:00}/{_0024now_002424211.Month:00}/{_0024now_002424211.Day:00} {_0024now_002424211.Hour:00}:{_0024now_002424211.Minute:00}";
								BinaryExpression binaryExpression = (_0024_00246418_002424213 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246418_002424213.Operator = BinaryOperatorType.Assign);
								Expression expression2 = (_0024_00246418_002424213.Left = Expression.Lift(_0024varName_002424210));
								Expression expression4 = (_0024_00246418_002424213.Right = Expression.Lift(_0024dts_002424212));
								result = (Yield(2, _0024_00246418_002424213) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`BuildDate` macro invocation argument(s) did not match definition: `BuildDate((varName as Boo.Lang.Compiler.Ast.ReferenceExpression))`");
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

		internal MacroStatement _0024BuildDate_002424216;

		internal BuildDateMacro _0024self__002424217;

		public _0024ExpandGeneratorImpl_002424207(MacroStatement BuildDate, BuildDateMacro self_)
		{
			_0024BuildDate_002424216 = BuildDate;
			_0024self__002424217 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024BuildDate_002424216, _0024self__002424217);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public BuildDateMacro()
	{
	}

	public BuildDateMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement BuildDate)
	{
		return new _0024ExpandGeneratorImpl_002424207(BuildDate, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement BuildDate)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'BuildDate' is using. Read BOO-1077 for more info.");
	}
}
