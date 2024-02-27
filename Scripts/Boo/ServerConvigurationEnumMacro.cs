using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class ServerConvigurationEnumMacro : ServerConfigurationMacroBase
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424673 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_002424674;

			internal ReferenceExpression _0024en_002424675;

			internal int _0024nargs_002424676;

			internal EnumDefinition _0024_00246574_002424677;

			internal EnumDefinition _0024edef_002424678;

			internal Setting _0024s_002424679;

			internal EnumMember _0024_00246575_002424680;

			internal IEnumerator<Setting> _0024_0024iterator_002414261_002424681;

			internal MacroStatement _0024mc_002424682;

			public _0024(MacroStatement mc)
			{
				_0024mc_002424682 = mc;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024args_002424674 = _0024mc_002424682.Arguments;
					if (((ICollection)_0024args_002424674).Count != 1)
					{
						throw new AssertionFailedException("ServerConvigurationEnum macro takes 1 argument as Enum name.");
					}
					if (!(_0024args_002424674[0] is ReferenceExpression))
					{
						throw new AssertionFailedException("An argument of ServerConvigurationEnum must be ReferenceExpression.");
					}
					_0024en_002424675 = _0024args_002424674[0] as ReferenceExpression;
					_0024nargs_002424676 = ((ICollection)_0024args_002424674).Count;
					EnumDefinition enumDefinition = (_0024_00246574_002424677 = new EnumDefinition());
					string text = (_0024_00246574_002424677.Name = _0024en_002424675.Name);
					_0024edef_002424678 = _0024_00246574_002424677;
					_0024_0024iterator_002414261_002424681 = ServerConfigurationMacroBase.SettingList.GetEnumerator();
					try
					{
						while (_0024_0024iterator_002414261_002424681.MoveNext())
						{
							_0024s_002424679 = _0024_0024iterator_002414261_002424681.Current;
							TypeMemberCollection members = _0024edef_002424678.Members;
							EnumMember enumMember = (_0024_00246575_002424680 = new EnumMember(new IntegerLiteralExpression(_0024s_002424679.index)));
							string text2 = (_0024_00246575_002424680.Name = _0024s_002424679.defName);
							members.Add(_0024_00246575_002424680);
						}
					}
					finally
					{
						_0024_0024iterator_002414261_002424681.Dispose();
					}
					result = (Yield(2, _0024edef_002424678) ? 1 : 0);
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

		internal MacroStatement _0024mc_002424683;

		public _0024ExpandGeneratorImpl_002424673(MacroStatement mc)
		{
			_0024mc_002424683 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002424683);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002424673(mc);
	}
}
