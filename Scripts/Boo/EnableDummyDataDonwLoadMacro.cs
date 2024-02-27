using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class EnableDummyDataDonwLoadMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public EnableDummyDataDonwLoadMacro()
	{
	}

	public EnableDummyDataDonwLoadMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement enableDummyDataDonwLoad)
	{
		if (enableDummyDataDonwLoad == null)
		{
			throw new ArgumentNullException("enableDummyDataDonwLoad");
		}
		__macro = enableDummyDataDonwLoad;
		Context.Parameters.Defines.Add("DUMMY_DATA_DOWNLOAD", "1");
		return null;
	}
}
