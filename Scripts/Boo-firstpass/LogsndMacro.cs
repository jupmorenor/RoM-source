using System;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogsndMacro : LogMacroBase
{
	protected override Statement ExpandImpl(MacroStatement mc)
	{
		return (!NoNormalLog) ? expand(mc, "Sound", "Log") : null;
	}
}
