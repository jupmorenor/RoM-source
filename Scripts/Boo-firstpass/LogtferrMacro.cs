using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogtferrMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetErrorLog) ? expand(mc, "TestFlight", "LogError") : null;
	}
}
