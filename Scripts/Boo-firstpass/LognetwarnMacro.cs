using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LognetwarnMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetWarnLog) ? expand(mc, "Net", "LogWarning") : null;
	}
}
