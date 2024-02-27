using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class __warn_offMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public __warn_offMacro()
	{
	}

	public __warn_offMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement __warn_off)
	{
		if (__warn_off == null)
		{
			throw new ArgumentNullException("__warn_off");
		}
		__macro = __warn_off;
		if (__warn_off is MacroStatement)
		{
			MacroStatement macroStatement = __warn_off;
			if (true && macroStatement.Name == "__warn_off" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is ReferenceExpression)
			{
				ReferenceExpression referenceExpression = (ReferenceExpression)macroStatement.Arguments[0];
				if (true)
				{
					Context.Parameters.DisableWarning(referenceExpression.Name);
					return null;
				}
			}
		}
		throw new Exception("`__warn_off` macro invocation argument(s) did not match definition: `__warn_off((warnname as Boo.Lang.Compiler.Ast.ReferenceExpression))`");
	}
}
