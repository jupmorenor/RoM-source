using System;
using System.Collections;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class AliasMacro : AbstractAstMacro
{
	[NonSerialized]
	protected const string Usage = "Usage: alias <expression> as <name>";

	public override Statement Expand(MacroStatement macro)
	{
		object result;
		if (!CheckUsage(macro))
		{
			Errors.Add(CompilerErrorFactory.CustomError(macro.LexicalInfo, "Usage: alias <expression> as <name>"));
			result = null;
		}
		else
		{
			TryCastExpression tryCastExpression = (TryCastExpression)macro.Arguments[0];
			ReferenceExpression referenceExpression = new ReferenceExpression();
			string text2 = (referenceExpression.Name = tryCastExpression.Type.ToString());
			ReferenceExpression pattern = referenceExpression;
			macro.ParentNode.ReplaceNodes(pattern, tryCastExpression.Target);
			result = null;
		}
		return (Statement)result;
	}

	public bool CheckUsage(MacroStatement macro)
	{
		return ((ICollection)macro.Body.Statements).Count <= 0 && ((ICollection)macro.Arguments).Count == 1 && macro.Arguments[0] is TryCastExpression tryCastExpression && tryCastExpression.Type is SimpleTypeReference;
	}
}
