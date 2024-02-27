using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class OSUsernameMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424218 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002488_002424219;

			internal MacroStatement _0024_0024match_002489_002424220;

			internal ReferenceExpression _0024varName_002424221;

			internal string _0024un_002424222;

			internal BinaryExpression _0024_00246419_002424223;

			internal MacroStatement _0024OSUsername_002424224;

			internal OSUsernameMacro _0024self__002424225;

			public _0024(MacroStatement OSUsername, OSUsernameMacro self_)
			{
				_0024OSUsername_002424224 = OSUsername;
				_0024self__002424225 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024OSUsername_002424224 == null)
					{
						throw new ArgumentNullException("OSUsername");
					}
					_0024self__002424225.__macro = _0024OSUsername_002424224;
					_0024_0024match_002488_002424219 = _0024OSUsername_002424224;
					if (_0024_0024match_002488_002424219 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002489_002424220 = _0024_0024match_002488_002424219);
						if (true && _0024_0024match_002489_002424220.Name == "OSUsername" && 1 == ((ICollection)_0024_0024match_002489_002424220.Arguments).Count && _0024_0024match_002489_002424220.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression = (_0024varName_002424221 = (ReferenceExpression)_0024_0024match_002489_002424220.Arguments[0]);
							if (true)
							{
								_0024un_002424222 = Environment.GetEnvironmentVariable("USERNAME");
								if (string.IsNullOrEmpty(_0024un_002424222))
								{
									_0024un_002424222 = Environment.GetEnvironmentVariable("USER");
								}
								BinaryExpression binaryExpression = (_0024_00246419_002424223 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246419_002424223.Operator = BinaryOperatorType.Assign);
								Expression expression2 = (_0024_00246419_002424223.Left = Expression.Lift(_0024varName_002424221));
								Expression expression4 = (_0024_00246419_002424223.Right = Expression.Lift(_0024un_002424222));
								result = (Yield(2, _0024_00246419_002424223) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`OSUsername` macro invocation argument(s) did not match definition: `OSUsername((varName as Boo.Lang.Compiler.Ast.ReferenceExpression))`");
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

		internal MacroStatement _0024OSUsername_002424226;

		internal OSUsernameMacro _0024self__002424227;

		public _0024ExpandGeneratorImpl_002424218(MacroStatement OSUsername, OSUsernameMacro self_)
		{
			_0024OSUsername_002424226 = OSUsername;
			_0024self__002424227 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024OSUsername_002424226, _0024self__002424227);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public OSUsernameMacro()
	{
	}

	public OSUsernameMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement OSUsername)
	{
		return new _0024ExpandGeneratorImpl_002424218(OSUsername, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement OSUsername)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'OSUsername' is using. Read BOO-1077 for more info.");
	}
}
