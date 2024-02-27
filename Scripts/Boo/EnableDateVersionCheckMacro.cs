using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class EnableDateVersionCheckMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public EnableDateVersionCheckMacro()
	{
	}

	public EnableDateVersionCheckMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement enableDateVersionCheck)
	{
		if (enableDateVersionCheck == null)
		{
			throw new ArgumentNullException("enableDateVersionCheck");
		}
		__macro = enableDateVersionCheck;
		Context.Parameters.Defines.Add("WITH_DATA_VERSION_CHECK", "1");
		return null;
	}
}
