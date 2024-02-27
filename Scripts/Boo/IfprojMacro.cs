using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class IfprojMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public IfprojMacro()
	{
	}

	public IfprojMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifproj)
	{
		if (ifproj == null)
		{
			throw new ArgumentNullException("ifproj");
		}
		__macro = ifproj;
		if (ifproj is MacroStatement)
		{
			MacroStatement macroStatement = ifproj;
			if (true && macroStatement.Name == "ifproj" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is StringLiteralExpression)
			{
				StringLiteralExpression stringLiteralExpression = (StringLiteralExpression)macroStatement.Arguments[0];
				if (true)
				{
					string currentDirectory = Directory.GetCurrentDirectory();
					string fileName = Path.GetFileName(currentDirectory);
					return (!(stringLiteralExpression.Value == fileName)) ? null : Statement.Lift(ifproj.Block);
				}
			}
		}
		throw new Exception("`ifproj` macro invocation argument(s) did not match definition: `ifproj((n as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
	}
}
