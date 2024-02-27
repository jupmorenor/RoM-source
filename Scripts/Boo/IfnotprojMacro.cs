using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class IfnotprojMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public IfnotprojMacro()
	{
	}

	public IfnotprojMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifnotproj)
	{
		if (ifnotproj == null)
		{
			throw new ArgumentNullException("ifnotproj");
		}
		__macro = ifnotproj;
		if (ifnotproj is MacroStatement)
		{
			MacroStatement macroStatement = ifnotproj;
			if (true && macroStatement.Name == "ifnotproj" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is StringLiteralExpression)
			{
				StringLiteralExpression stringLiteralExpression = (StringLiteralExpression)macroStatement.Arguments[0];
				if (true)
				{
					string currentDirectory = Directory.GetCurrentDirectory();
					string fileName = Path.GetFileName(currentDirectory);
					return (!(stringLiteralExpression.Value != fileName)) ? null : Statement.Lift(ifnotproj.Block);
				}
			}
		}
		throw new Exception("`ifnotproj` macro invocation argument(s) did not match definition: `ifnotproj((n as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
	}
}
