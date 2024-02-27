using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class ServerConfigurationBlockMacro : ServerConfigurationMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424710 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal Expander _0024expander_002424711;

			internal Setting _0024s_002424712;

			internal Block _0024body_002424713;

			internal IEnumerator<Setting> _0024_0024iterator_002414264_002424714;

			internal MacroStatement _0024mc_002424715;

			public _0024(MacroStatement mc)
			{
				_0024mc_002424715 = mc;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024expander_002424711 = new Expander();
						_0024_0024iterator_002414264_002424714 = ServerConfigurationMacroBase.SettingList.GetEnumerator();
						_state = 2;
						break;
					case 3:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002414264_002424714.MoveNext())
					{
						_0024s_002424712 = _0024_0024iterator_002414264_002424714.Current;
						_0024body_002424713 = _0024mc_002424715.Body.CloneNode();
						_0024expander_002424711.init(_0024s_002424712);
						_0024expander_002424711.Visit(_0024body_002424713);
						flag = Yield(3, _0024body_002424713);
						goto IL_00d3;
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
				goto IL_00d4;
				IL_00d3:
				result = (flag ? 1 : 0);
				goto IL_00d4;
				IL_00d4:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414264_002424714.Dispose();
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

		internal MacroStatement _0024mc_002424716;

		public _0024ExpandGeneratorImpl_002424710(MacroStatement mc)
		{
			_0024mc_002424716 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424716);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424710(mc);
	}
}
