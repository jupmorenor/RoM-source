using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class EnableSkipBgmDownLaodMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public EnableSkipBgmDownLaodMacro()
	{
	}

	public EnableSkipBgmDownLaodMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement enableSkipBgmDownLaod)
	{
		if (enableSkipBgmDownLaod == null)
		{
			throw new ArgumentNullException("enableSkipBgmDownLaod");
		}
		__macro = enableSkipBgmDownLaod;
		Context.Parameters.Defines.Add("SKIP_BGM_DOWNLOAD", "1");
		return null;
	}
}
