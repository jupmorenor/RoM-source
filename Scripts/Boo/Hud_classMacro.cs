using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class Hud_classMacro : HudMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424108 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal TypeMember _0024___item_002424109;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414233_002424110;

			internal MacroStatement _0024mc_002424111;

			internal Hud_classMacro _0024self__002424112;

			public _0024(MacroStatement mc, Hud_classMacro self_)
			{
				_0024mc_002424111 = mc;
				_0024self__002424112 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (((ICollection)_0024mc_002424111.Arguments).Count != 0)
						{
							throw new AssertionFailedException("len(mc.Arguments) == 0");
						}
						_0024_0024iterator_002414233_002424110 = _0024self__002424112.InstanceManagingCode(_0024mc_002424111).GetEnumerator();
						_state = 2;
						break;
					case 3:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002414233_002424110.MoveNext())
					{
						_0024___item_002424109 = _0024_0024iterator_002414233_002424110.Current;
						flag = Yield(3, _0024___item_002424109);
						goto IL_00bb;
					}
					_state = 1;
					_0024ensure2();
					YieldDefault(1);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_00bc;
				IL_00bb:
				result = (flag ? 1 : 0);
				goto IL_00bc;
				IL_00bc:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414233_002424110.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal MacroStatement _0024mc_002424113;

		internal Hud_classMacro _0024self__002424114;

		public _0024ExpandGeneratorImpl_002424108(MacroStatement mc, Hud_classMacro self_)
		{
			_0024mc_002424113 = mc;
			_0024self__002424114 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424113, _0024self__002424114);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424108(mc, this);
	}
}
