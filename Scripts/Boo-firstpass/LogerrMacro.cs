using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogerrMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoErrorLog) ? expand(mc, "Error", "LogError") : null;
	}
}
