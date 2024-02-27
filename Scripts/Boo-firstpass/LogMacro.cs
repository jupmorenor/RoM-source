using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNormalLog) ? expand(mc, "Normal", "Log") : null;
	}
}
