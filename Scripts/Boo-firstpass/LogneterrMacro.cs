using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogneterrMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNetErrorLog) ? expand(mc, "Net", "LogError") : null;
	}
}
