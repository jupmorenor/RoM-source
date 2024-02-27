using System;
using System.Collections;
using System.IO;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class LogMacroBase : LexicalInfoPreservingMacro
{
	public bool NoNormalLog => Context.Parameters.Defines.ContainsKey("NO_NORMAL_LOG");

	public bool NoWarnLog => Context.Parameters.Defines.ContainsKey("NO_WARN_LOG");

	public bool NoErrorLog => Context.Parameters.Defines.ContainsKey("NO_ERROR_LOG");

	public bool NoNetNormalLog => Context.Parameters.Defines.ContainsKey("NO_NET_NORMAL_LOG");

	public bool NoNetWarnLog => Context.Parameters.Defines.ContainsKey("NO_NET_WARN_LOG");

	public bool NoNetErrorLog => Context.Parameters.Defines.ContainsKey("NO_NET_ERROR_LOG");

	protected Block expand(MacroStatement mc, string logType, string logMethod)
	{
		LexicalInfo lexicalInfo = mc.LexicalInfo;
		ExpressionCollection arguments = mc.Arguments;
		int count = ((ICollection)arguments).Count;
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(lexicalInfo.FileName);
		int line = lexicalInfo.Line;
		ReferenceExpression referenceExpression = new ReferenceExpression();
		string text2 = (referenceExpression.Name = logType);
		ReferenceExpression node = referenceExpression;
		ReferenceExpression referenceExpression2 = new ReferenceExpression();
		string text4 = (referenceExpression2.Name = logMethod);
		ReferenceExpression node2 = referenceExpression2;
		Block block4;
		switch (count)
		{
		case 0:
		{
			MacroStatement macroStatement3 = new MacroStatement(LexicalInfo.Empty);
			string text22 = (macroStatement3.Name = "b");
			Block block8 = new Block(LexicalInfo.Empty);
			Statement[] array5 = new Statement[1];
			MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression(LexicalInfo.Empty);
			ReferenceExpression referenceExpression7 = new ReferenceExpression(LexicalInfo.Empty);
			string text24 = (referenceExpression7.Name = "MacroUtil");
			Expression expression10 = (methodInvocationExpression3.Target = new MemberReferenceExpression(referenceExpression7, CodeSerializer.LiftName(node2)));
			Expression[] array6 = new Expression[5];
			MemberReferenceExpression memberReferenceExpression3 = new MemberReferenceExpression(LexicalInfo.Empty);
			string text26 = (memberReferenceExpression3.Name = "LogType");
			ReferenceExpression referenceExpression8 = new ReferenceExpression(LexicalInfo.Empty);
			string text28 = (referenceExpression8.Name = "MacroUtil");
			Expression expression12 = (memberReferenceExpression3.Target = referenceExpression8);
			array6[0] = new MemberReferenceExpression(memberReferenceExpression3, CodeSerializer.LiftName(node));
			array6[1] = Expression.Lift(fileNameWithoutExtension);
			array6[2] = Expression.Lift(line);
			StringLiteralExpression stringLiteralExpression = new StringLiteralExpression(LexicalInfo.Empty);
			string text30 = (stringLiteralExpression.Value = "<empty>");
			array6[3] = stringLiteralExpression;
			array6[4] = new NullLiteralExpression(LexicalInfo.Empty);
			ExpressionCollection expressionCollection6 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array6));
			array5[0] = Statement.Lift(methodInvocationExpression3);
			StatementCollection statementCollection6 = (block8.Statements = StatementCollection.FromArray(array5));
			Block block10 = (macroStatement3.Body = block8);
			block4 = macroStatement3.Block;
			break;
		}
		case 1:
		{
			Expression e = arguments[0] as Expression;
			MacroStatement macroStatement2 = new MacroStatement(LexicalInfo.Empty);
			string text14 = (macroStatement2.Name = "b");
			Block block5 = new Block(LexicalInfo.Empty);
			Statement[] array3 = new Statement[1];
			MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
			ReferenceExpression referenceExpression5 = new ReferenceExpression(LexicalInfo.Empty);
			string text16 = (referenceExpression5.Name = "MacroUtil");
			Expression expression6 = (methodInvocationExpression2.Target = new MemberReferenceExpression(referenceExpression5, CodeSerializer.LiftName(node2)));
			Expression[] array4 = new Expression[5];
			MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
			string text18 = (memberReferenceExpression2.Name = "LogType");
			ReferenceExpression referenceExpression6 = new ReferenceExpression(LexicalInfo.Empty);
			string text20 = (referenceExpression6.Name = "MacroUtil");
			Expression expression8 = (memberReferenceExpression2.Target = referenceExpression6);
			array4[0] = new MemberReferenceExpression(memberReferenceExpression2, CodeSerializer.LiftName(node));
			array4[1] = Expression.Lift(fileNameWithoutExtension);
			array4[2] = Expression.Lift(line);
			array4[3] = Expression.Lift(e);
			array4[4] = new NullLiteralExpression(LexicalInfo.Empty);
			ExpressionCollection expressionCollection4 = (methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(array4));
			array3[0] = Statement.Lift(methodInvocationExpression2);
			StatementCollection statementCollection4 = (block5.Statements = StatementCollection.FromArray(array3));
			Block block7 = (macroStatement2.Body = block5);
			block4 = macroStatement2.Block;
			break;
		}
		default:
		{
			Expression e = arguments[0] as Expression;
			Expression e2 = arguments[1] as Expression;
			MacroStatement macroStatement = new MacroStatement(LexicalInfo.Empty);
			string text6 = (macroStatement.Name = "b");
			Block block = new Block(LexicalInfo.Empty);
			Statement[] array = new Statement[1];
			MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
			ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
			string text8 = (referenceExpression3.Name = "MacroUtil");
			Expression expression2 = (methodInvocationExpression.Target = new MemberReferenceExpression(referenceExpression3, CodeSerializer.LiftName(node2)));
			Expression[] array2 = new Expression[5];
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
			string text10 = (memberReferenceExpression.Name = "LogType");
			ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
			string text12 = (referenceExpression4.Name = "MacroUtil");
			Expression expression4 = (memberReferenceExpression.Target = referenceExpression4);
			array2[0] = new MemberReferenceExpression(memberReferenceExpression, CodeSerializer.LiftName(node));
			array2[1] = Expression.Lift(fileNameWithoutExtension);
			array2[2] = Expression.Lift(line);
			array2[3] = Expression.Lift(e);
			array2[4] = Expression.Lift(e2);
			ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(array2));
			array[0] = Statement.Lift(methodInvocationExpression);
			StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
			Block block3 = (macroStatement.Body = block);
			block4 = macroStatement.Block;
			break;
		}
		}
		return block4;
	}

	protected override Statement ExpandImpl(MacroStatement macro)
	{
		throw new NotImplementedException();
	}
}
