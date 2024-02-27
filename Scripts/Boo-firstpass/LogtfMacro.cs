using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogtfMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetNormalLog) ? expand(mc, "TestFlight", "Log") : null;
	}
}
