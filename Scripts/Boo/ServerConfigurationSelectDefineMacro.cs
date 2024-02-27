using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class ServerConfigurationSelectDefineMacro : ServerConfigurationMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424698 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_002424699;

			internal int _0024nargs_002424700;

			internal string _0024defPrefix_002424701;

			internal Dictionary<string, string> _0024defines_002424702;

			internal Setting _0024useStng_002424703;

			internal Setting _0024s_002424704;

			internal Block _0024body_002424705;

			internal Expander _0024expander_002424706;

			internal IEnumerator<Setting> _0024_0024iterator_002414263_002424707;

			internal MacroStatement _0024mc_002424708;

			public _0024(MacroStatement mc)
			{
				_0024mc_002424708 = mc;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024args_002424699 = _0024mc_002424708.Arguments;
					_0024nargs_002424700 = ((ICollection)_0024args_002424699).Count;
					if (_0024nargs_002424700 != 1 || !(_0024args_002424699[0] is ReferenceExpression))
					{
						throw new AssertionFailedException("(nargs == 1) and (args[0] isa ReferenceExpression)");
					}
					_0024defPrefix_002424701 = (_0024args_002424699[0] as ReferenceExpression).Name;
					_0024defines_002424702 = CompilerContext.Current.Parameters.Defines;
					_0024useStng_002424703 = ServerConfigurationMacroBase.FindSetting("Dev05");
					if (_0024useStng_002424703 == null)
					{
						_0024useStng_002424703 = ServerConfigurationMacroBase.SettingList[0];
					}
					_0024_0024iterator_002414263_002424707 = ServerConfigurationMacroBase.SettingList.GetEnumerator();
					try
					{
						while (_0024_0024iterator_002414263_002424707.MoveNext())
						{
							_0024s_002424704 = _0024_0024iterator_002414263_002424707.Current;
							if (_0024defines_002424702.ContainsKey(_0024defPrefix_002424701 + _0024s_002424704.defName))
							{
								_0024useStng_002424703 = _0024s_002424704;
								break;
							}
						}
					}
					finally
					{
						_0024_0024iterator_002414263_002424707.Dispose();
					}
					_0024body_002424705 = _0024mc_002424708.Body;
					_0024expander_002424706 = new Expander();
					_0024expander_002424706.init(_0024useStng_002424703);
					_0024expander_002424706.Visit(_0024body_002424705);
					result = (Yield(2, _0024body_002424705) ? 1 : 0);
					break;
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

		internal MacroStatement _0024mc_002424709;

		public _0024ExpandGeneratorImpl_002424698(MacroStatement mc)
		{
			_0024mc_002424709 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424709);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424698(mc);
	}
}
