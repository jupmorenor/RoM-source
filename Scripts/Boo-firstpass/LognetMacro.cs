using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LognetMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetNormalLog) ? expand(mc, "Net", "Log") : null;
	}
}
