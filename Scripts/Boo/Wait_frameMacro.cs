using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Wait_frameMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Wait_frameMacro()
	{
	}

	public Wait_frameMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement wait_frame)
	{
		if (wait_frame == null)
		{
			throw new ArgumentNullException("wait_frame");
		}
		__macro = wait_frame;
		if (wait_frame is MacroStatement)
		{
			MacroStatement macroStatement = wait_frame;
			if (true && macroStatement.Name == "wait_frame" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is Expression)
			{
				Expression e = macroStatement.Arguments[0];
				if (true)
				{
					ReferenceExpression e2 = new ReferenceExpression(Context.GetUniqueName("wait_frame", "temp"));
					Block block = new Block(LexicalInfo.Empty);
					Statement[] array = new Statement[2];
					BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
					Expression expression2 = (binaryExpression.Left = Expression.Lift(e2));
					Expression expression4 = (binaryExpression.Right = Expression.Lift(e));
					array[0] = Statement.Lift(binaryExpression);
					WhileStatement whileStatement = new WhileStatement(LexicalInfo.Empty);
					BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.GreaterThanOrEqual);
					UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
					UnaryOperatorType unaryOperatorType2 = (unaryExpression.Operator = UnaryOperatorType.PostDecrement);
					Expression expression6 = (unaryExpression.Operand = Expression.Lift(e2));
					Expression expression8 = (binaryExpression2.Left = unaryExpression);
					IntegerLiteralExpression integerLiteralExpression = new IntegerLiteralExpression(LexicalInfo.Empty);
					long num2 = (integerLiteralExpression.Value = 0L);
					bool flag2 = (integerLiteralExpression.IsLong = false);
					Expression expression10 = (binaryExpression2.Right = integerLiteralExpression);
					Expression expression12 = (whileStatement.Condition = binaryExpression2);
					Block block2 = new Block(LexicalInfo.Empty);
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
					Block block4 = (whileStatement.Block = block2);
					array[1] = Statement.Lift(whileStatement);
					StatementCollection statementCollection4 = (block.Statements = StatementCollection.FromArray(array));
					return block;
				}
			}
		}
		throw new Exception("`wait_frame` macro invocation argument(s) did not match definition: `wait_frame((frameNum as Boo.Lang.Compiler.Ast.Expression))`");
	}
}
