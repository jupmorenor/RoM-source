using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Get_define_symbol_valueMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424428 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024139_002424429;

			internal MacroStatement _0024_0024match_0024140_002424430;

			internal ReferenceExpression _0024vref_002424431;

			internal StringLiteralExpression _0024_0024match_0024141_002424432;

			internal string _0024symname_002424433;

			internal string _0024val_002424434;

			internal BinaryExpression _0024_00246522_002424435;

			internal StringLiteralExpression _0024_00246523_002424436;

			internal BinaryExpression _0024_00246524_002424437;

			internal MacroStatement _0024get_define_symbol_value_002424438;

			internal Get_define_symbol_valueMacro _0024self__002424439;

			public _0024(MacroStatement get_define_symbol_value, Get_define_symbol_valueMacro self_)
			{
				_0024get_define_symbol_value_002424438 = get_define_symbol_value;
				_0024self__002424439 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024get_define_symbol_value_002424438 == null)
					{
						throw new ArgumentNullException("get_define_symbol_value");
					}
					_0024self__002424439.__macro = _0024get_define_symbol_value_002424438;
					_0024_0024match_0024139_002424429 = _0024get_define_symbol_value_002424438;
					if (_0024_0024match_0024139_002424429 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024140_002424430 = _0024_0024match_0024139_002424429);
						if (true && _0024_0024match_0024140_002424430.Name == "get_define_symbol_value" && 2 == ((ICollection)_0024_0024match_0024140_002424430.Arguments).Count && _0024_0024match_0024140_002424430.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression = (_0024vref_002424431 = (ReferenceExpression)_0024_0024match_0024140_002424430.Arguments[0]);
							if (true && _0024_0024match_0024140_002424430.Arguments[1] is StringLiteralExpression)
							{
								StringLiteralExpression stringLiteralExpression = (_0024_0024match_0024141_002424432 = (StringLiteralExpression)_0024_0024match_0024140_002424430.Arguments[1]);
								if (true)
								{
									string text = (_0024symname_002424433 = _0024_0024match_0024141_002424432.Value);
									if (true)
									{
										if (_0024self__002424439.Context.Parameters.Defines.ContainsKey(_0024symname_002424433))
										{
											_0024val_002424434 = _0024self__002424439.Context.Parameters.Defines[_0024symname_002424433];
											BinaryExpression binaryExpression = (_0024_00246522_002424435 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType2 = (_0024_00246522_002424435.Operator = BinaryOperatorType.Assign);
											Expression expression2 = (_0024_00246522_002424435.Left = Expression.Lift(_0024vref_002424431));
											Expression expression4 = (_0024_00246522_002424435.Right = Expression.Lift(_0024val_002424434));
											result = (Yield(2, _0024_00246522_002424435) ? 1 : 0);
										}
										else
										{
											BinaryExpression binaryExpression2 = (_0024_00246524_002424437 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType4 = (_0024_00246524_002424437.Operator = BinaryOperatorType.Assign);
											Expression expression6 = (_0024_00246524_002424437.Left = Expression.Lift(_0024vref_002424431));
											BinaryExpression binaryExpression3 = _0024_00246524_002424437;
											StringLiteralExpression stringLiteralExpression2 = (_0024_00246523_002424436 = new StringLiteralExpression(LexicalInfo.Empty));
											string text2 = (_0024_00246523_002424436.Value = string.Empty);
											Expression expression8 = (binaryExpression3.Right = _0024_00246523_002424436);
											result = (Yield(3, _0024_00246524_002424437) ? 1 : 0);
										}
										break;
									}
								}
							}
						}
					}
					throw new Exception("`get_define_symbol_value` macro invocation argument(s) did not match definition: `get_define_symbol_value((vref as Boo.Lang.Compiler.Ast.ReferenceExpression), (symname as string))`");
				case 2:
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024get_define_symbol_value_002424440;

		internal Get_define_symbol_valueMacro _0024self__002424441;

		public _0024ExpandGeneratorImpl_002424428(MacroStatement get_define_symbol_value, Get_define_symbol_valueMacro self_)
		{
			_0024get_define_symbol_value_002424440 = get_define_symbol_value;
			_0024self__002424441 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024get_define_symbol_value_002424440, _0024self__002424441);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Get_define_symbol_valueMacro()
	{
	}

	public Get_define_symbol_valueMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement get_define_symbol_value)
	{
		return new _0024ExpandGeneratorImpl_002424428(get_define_symbol_value, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement get_define_symbol_value)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'get_define_symbol_value' is using. Read BOO-1077 for more info.");
	}
}
