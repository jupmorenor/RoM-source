using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;

[Serializable]
public sealed class Start_yield_coroutineMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Start_yield_coroutineMacro()
	{
	}

	public Start_yield_coroutineMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement start_yield_coroutine)
	{
		if (start_yield_coroutine == null)
		{
			throw new ArgumentNullException("start_yield_coroutine");
		}
		__macro = start_yield_coroutine;
		Block result;
		if (start_yield_coroutine is MacroStatement)
		{
			MacroStatement macroStatement = start_yield_coroutine;
			if (true && macroStatement.Name == "start_yield_coroutine" && 1 == ((ICollection)macroStatement.Arguments).Count)
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
					YieldStatement yieldStatement = new YieldStatement(LexicalInfo.Empty);
					MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
					ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
					string text2 = (referenceExpression.Name = "StartCoroutine");
					Expression expression12 = (methodInvocationExpression.Target = referenceExpression);
					ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(Expression.Lift(e2)));
					Expression expression14 = (yieldStatement.Expression = methodInvocationExpression);
					array2[0] = Statement.Lift(yieldStatement);
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
					Block block4 = (ifStatement.TrueBlock = block2);
					array[1] = Statement.Lift(ifStatement);
					StatementCollection statementCollection4 = (block.Statements = StatementCollection.FromArray(array));
					result = block;
					goto IL_0498;
				}
			}
		}
		if (start_yield_coroutine is MacroStatement)
		{
			MacroStatement macroStatement2 = start_yield_coroutine;
			if (true && macroStatement2.Name == "start_yield_coroutine" && 2 == ((ICollection)macroStatement2.Arguments).Count)
			{
				Expression e3 = macroStatement2.Arguments[0];
				if (true)
				{
					Expression e4 = macroStatement2.Arguments[1];
					if (true)
					{
						ReferenceExpression e2 = new ReferenceExpression(Context.GetUniqueName("sco", "temp"));
						Block block5 = new Block(LexicalInfo.Empty);
						Statement[] array3 = new Statement[2];
						BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Assign);
						Expression expression16 = (binaryExpression3.Left = Expression.Lift(e2));
						MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
						ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
						string text4 = (referenceExpression2.Name = "StartCoroutine");
						Expression expression18 = (methodInvocationExpression2.Target = referenceExpression2);
						ExpressionCollection expressionCollection4 = (methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(Expression.Lift(e3), Expression.Lift(e4)));
						Expression expression20 = (binaryExpression3.Right = methodInvocationExpression2);
						array3[0] = Statement.Lift(binaryExpression3);
						IfStatement ifStatement2 = new IfStatement(LexicalInfo.Empty);
						BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Inequality);
						Expression expression22 = (binaryExpression4.Left = Expression.Lift(e2));
						Expression expression24 = (binaryExpression4.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression26 = (ifStatement2.Condition = binaryExpression4);
						Block block6 = new Block(LexicalInfo.Empty);
						Statement[] array4 = new Statement[1];
						YieldStatement yieldStatement2 = new YieldStatement(LexicalInfo.Empty);
						Expression expression28 = (yieldStatement2.Expression = Expression.Lift(e2));
						array4[0] = Statement.Lift(yieldStatement2);
						StatementCollection statementCollection6 = (block6.Statements = StatementCollection.FromArray(array4));
						Block block8 = (ifStatement2.TrueBlock = block6);
						array3[1] = Statement.Lift(ifStatement2);
						StatementCollection statementCollection8 = (block5.Statements = StatementCollection.FromArray(array3));
						result = block5;
						goto IL_0498;
					}
				}
			}
		}
		throw new MatchError(new StringBuilder("`start_yield_coroutine` failed to match `").Append(start_yield_coroutine).Append("`").ToString());
		IL_0498:
		return result;
	}
}
