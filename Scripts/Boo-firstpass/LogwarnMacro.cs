using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogwarnMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoWarnLog) ? expand(mc, "Warning", "LogWarning") : null;
	}
}
