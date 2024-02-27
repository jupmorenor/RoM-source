using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class SwapMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public SwapMacro()
	{
	}

	public SwapMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement swap)
	{
		if (swap == null)
		{
			throw new ArgumentNullException("swap");
		}
		__macro = swap;
		if (swap is MacroStatement)
		{
			MacroStatement macroStatement = swap;
			if (true && macroStatement.Name == "swap" && 2 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is Expression)
			{
				Expression e = macroStatement.Arguments[0];
				if (true && macroStatement.Arguments[1] is Expression)
				{
					Expression e2 = macroStatement.Arguments[1];
					if (true)
					{
						ReferenceExpression e3 = new ReferenceExpression(Context.GetUniqueName("swap"));
						Block block = new Block(LexicalInfo.Empty);
						Statement[] array = new Statement[3];
						BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
						Expression expression2 = (binaryExpression.Left = Expression.Lift(e3));
						Expression expression4 = (binaryExpression.Right = Expression.Lift(e));
						array[0] = Statement.Lift(binaryExpression);
						BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Assign);
						Expression expression6 = (binaryExpression2.Left = Expression.Lift(e));
						Expression expression8 = (binaryExpression2.Right = Expression.Lift(e2));
						array[1] = Statement.Lift(binaryExpression2);
						BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Assign);
						Expression expression10 = (binaryExpression3.Left = Expression.Lift(e2));
						Expression expression12 = (binaryExpression3.Right = Expression.Lift(e3));
						array[2] = Statement.Lift(binaryExpression3);
						StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
						return block;
					}
				}
			}
		}
		throw new Exception("`swap` macro invocation argument(s) did not match definition: `swap(a, b)`");
	}
}
