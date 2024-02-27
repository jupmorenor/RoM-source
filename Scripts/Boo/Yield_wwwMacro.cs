using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Yield_wwwMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Yield_wwwMacro()
	{
	}

	public Yield_wwwMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement yield_www)
	{
		if (yield_www == null)
		{
			throw new ArgumentNullException("yield_www");
		}
		__macro = yield_www;
		if (yield_www is MacroStatement)
		{
			MacroStatement macroStatement = yield_www;
			if (true && macroStatement.Name == "yield_www" && 1 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is Expression)
			{
				Expression e = macroStatement.Arguments[0];
				if (true)
				{
					YieldStatement yieldStatement = new YieldStatement(LexicalInfo.Empty);
					StatementModifier statementModifier = new StatementModifier(LexicalInfo.Empty);
					StatementModifierType statementModifierType2 = (statementModifier.Type = StatementModifierType.While);
					BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.And);
					UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
					UnaryOperatorType unaryOperatorType2 = (unaryExpression.Operator = UnaryOperatorType.LogicalNot);
					MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
					string text2 = (memberReferenceExpression.Name = "isDone");
					Expression expression2 = (memberReferenceExpression.Target = Expression.Lift(e));
					Expression expression4 = (unaryExpression.Operand = memberReferenceExpression);
					Expression expression6 = (binaryExpression.Left = unaryExpression);
					BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Equality);
					MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
					string text4 = (memberReferenceExpression2.Name = "error");
					Expression expression8 = (memberReferenceExpression2.Target = Expression.Lift(e));
					Expression expression10 = (binaryExpression2.Left = memberReferenceExpression2);
					Expression expression12 = (binaryExpression2.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression14 = (binaryExpression.Right = binaryExpression2);
					Expression expression16 = (statementModifier.Condition = binaryExpression);
					StatementModifier statementModifier3 = (yieldStatement.Modifier = statementModifier);
					return yieldStatement;
				}
			}
		}
		throw new Exception("`yield_www` macro invocation argument(s) did not match definition: `yield_www((www as Boo.Lang.Compiler.Ast.Expression))`");
	}
}
