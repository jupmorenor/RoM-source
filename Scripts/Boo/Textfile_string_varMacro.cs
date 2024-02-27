using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Textfile_string_varMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Textfile_string_varMacro()
	{
	}

	public Textfile_string_varMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement textfile_string_var)
	{
		if (textfile_string_var == null)
		{
			throw new ArgumentNullException("textfile_string_var");
		}
		__macro = textfile_string_var;
		if (textfile_string_var is MacroStatement)
		{
			MacroStatement macroStatement = textfile_string_var;
			if (true && macroStatement.Name == "textfile_string_var" && 2 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is ReferenceExpression)
			{
				ReferenceExpression referenceExpression = (ReferenceExpression)macroStatement.Arguments[0];
				if (true && macroStatement.Arguments[1] is StringLiteralExpression)
				{
					StringLiteralExpression stringLiteralExpression = (StringLiteralExpression)macroStatement.Arguments[1];
					if (true)
					{
						string value = stringLiteralExpression.Value;
						Declaration declaration = new Declaration();
						string text = (declaration.Name = referenceExpression.Name);
						TypeReference typeReference2 = (declaration.Type = new SimpleTypeReference("string"));
						Declaration declaration2 = declaration;
						StringLiteralExpression initializer = new StringLiteralExpression("???");
						if (File.Exists(value))
						{
							StreamReader streamReader;
							IDisposable disposable = (streamReader = new StreamReader(value)) as IDisposable;
							try
							{
								initializer = new StringLiteralExpression(streamReader.ReadToEnd());
							}
							finally
							{
								if (disposable != null)
								{
									disposable.Dispose();
									disposable = null;
								}
							}
						}
						return new DeclarationStatement(declaration2, initializer);
					}
				}
			}
		}
		throw new Exception("`textfile_string_var` macro invocation argument(s) did not match definition: `textfile_string_var((varName as Boo.Lang.Compiler.Ast.ReferenceExpression), (pathName as Boo.Lang.Compiler.Ast.StringLiteralExpression))`");
	}
}
