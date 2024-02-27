using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class ServerConfigurationTableMacro : ServerConfigurationMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424684 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_002424685;

			internal int _0024nargs_002424686;

			internal ReferenceExpression _0024tblName_002424687;

			internal Expression _0024exprTmpl_002424688;

			internal Expander _0024expander_002424689;

			internal ArrayLiteralExpression _0024ary_002424690;

			internal Setting _0024s_002424691;

			internal Expression _0024expr_002424692;

			internal Field _0024_00246576_002424693;

			internal Field _0024code_002424694;

			internal IEnumerator<Setting> _0024_0024iterator_002414262_002424695;

			internal MacroStatement _0024mc_002424696;

			public _0024(MacroStatement mc)
			{
				_0024mc_002424696 = mc;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024args_002424685 = _0024mc_002424696.Arguments;
					_0024nargs_002424686 = ((ICollection)_0024args_002424685).Count;
					if (_0024nargs_002424686 != 2)
					{
						throw new AssertionFailedException("nargs == 2");
					}
					_0024tblName_002424687 = _0024args_002424685[0] as ReferenceExpression;
					if (_0024tblName_002424687 == null)
					{
						throw new AssertionFailedException("tblName != null");
					}
					_0024exprTmpl_002424688 = _0024args_002424685[1] as Expression;
					if (_0024exprTmpl_002424688 == null)
					{
						throw new AssertionFailedException("exprTmpl != null");
					}
					_0024expander_002424689 = new Expander();
					_0024ary_002424690 = new ArrayLiteralExpression();
					_0024_0024iterator_002414262_002424695 = ServerConfigurationMacroBase.SettingList.GetEnumerator();
					try
					{
						while (_0024_0024iterator_002414262_002424695.MoveNext())
						{
							_0024s_002424691 = _0024_0024iterator_002414262_002424695.Current;
							_0024expr_002424692 = _0024exprTmpl_002424688.CloneNode() as Expression;
							if (_0024expr_002424692 == null)
							{
								throw new AssertionFailedException("expr != null");
							}
							_0024expander_002424689.init(_0024s_002424691);
							_0024expander_002424689.Visit(_0024expr_002424692);
							_0024ary_002424690.Items.Add(_0024expr_002424692);
						}
					}
					finally
					{
						_0024_0024iterator_002414262_002424695.Dispose();
					}
					Field field = (_0024_00246576_002424693 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers2 = (_0024_00246576_002424693.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
					string text2 = (_0024_00246576_002424693.Name = "$");
					Expression expression2 = (_0024_00246576_002424693.Initializer = Expression.Lift(_0024ary_002424690));
					bool flag2 = (_0024_00246576_002424693.IsVolatile = false);
					string text4 = (_0024_00246576_002424693.Name = CodeSerializer.LiftName(_0024tblName_002424687));
					_0024code_002424694 = _0024_00246576_002424693;
					result = (Yield(2, _0024code_002424694) ? 1 : 0);
					break;
				}
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

		internal MacroStatement _0024mc_002424697;

		public _0024ExpandGeneratorImpl_002424684(MacroStatement mc)
		{
			_0024mc_002424697 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424697);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424684(mc);
	}
}
