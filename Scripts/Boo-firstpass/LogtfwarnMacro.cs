using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogtfwarnMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetWarnLog) ? expand(mc, "TestFlight", "LogWarning") : null;
	}
}
