using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Start_coroutineMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Start_coroutineMacro()
	{
	}

	public Start_coroutineMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement start_coroutine)
	{
		if (start_coroutine == null)
		{
			throw new ArgumentNullException("start_coroutine");
		}
		__macro = start_coroutine;
		if (start_coroutine is MacroStatement)
		{
			MacroStatement macroStatement = start_coroutine;
			if (true && macroStatement.Name == "start_coroutine" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is Expression)
			{
				Expression e = macroStatement.Arguments[0];
				if (true)
				{
					ReferenceExpression e2 = new ReferenceExpression(Context.GetUniqueName("sco", "temp"));
					Block block = new Block(LexicalInfo.Empty);
					Statement[] array = new Statement[2];
					BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
					Expression expression2 = (binaryExpression.Left = Expression.Lift(e2));
					Expression expression4 = (binaryExpression.Right = Expression.Lift(e));
					array[0] = Statement.Lift(binaryExpression);
					IfStatement ifStatement = new IfStatement(LexicalInfo.Empty);
					BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Inequality);
					Expression expression6 = (binaryExpression2.Left = Expression.Lift(e2));
					Expression expression8 = (binaryExpression2.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression10 = (ifStatement.Condition = binaryExpression2);
					Block block2 = new Block(LexicalInfo.Empty);
					Statement[] array2 = new Statement[1];
					MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
					ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
					string text2 = (referenceExpression.Name = "StartCoroutine");
					Expression expression12 = (methodInvocationExpression.Target = referenceExpression);
					ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(Expression.Lift(e2)));
					array2[0] = Statement.Lift(methodInvocationExpression);
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
					Block block4 = (ifStatement.TrueBlock = block2);
					array[1] = Statement.Lift(ifStatement);
					StatementCollection statementCollection4 = (block.Statements = StatementCollection.FromArray(array));
					return block;
				}
			}
		}
		throw new Exception("`start_coroutine` macro invocation argument(s) did not match definition: `start_coroutine((expr as Boo.Lang.Compiler.Ast.Expression))`");
	}
}
