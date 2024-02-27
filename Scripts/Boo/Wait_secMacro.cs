using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Wait_secMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Wait_secMacro()
	{
	}

	public Wait_secMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement wait_sec)
	{
		if (wait_sec == null)
		{
			throw new ArgumentNullException("wait_sec");
		}
		__macro = wait_sec;
		Block result;
		if (wait_sec is MacroStatement)
		{
			MacroStatement macroStatement = wait_sec;
			if (true && macroStatement.Name == "wait_sec" && 1 == ((ICollection)macroStatement.Arguments).Count)
			{
				Expression e = macroStatement.Arguments[0];
				if (true)
				{
					ReferenceExpression e2 = new ReferenceExpression(Context.GetUniqueName("wait_sec", "temp"));
					Block block = new Block(LexicalInfo.Empty);
					Statement[] array = new Statement[2];
					BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
					Expression expression2 = (binaryExpression.Left = Expression.Lift(e2));
					CastExpression castExpression = new CastExpression(LexicalInfo.Empty);
					Expression expression4 = (castExpression.Target = Expression.Lift(e));
					SimpleTypeReference simpleTypeReference = new SimpleTypeReference(LexicalInfo.Empty);
					bool flag2 = (simpleTypeReference.IsPointer = false);
					string text2 = (simpleTypeReference.Name = "single");
					TypeReference typeReference2 = (castExpression.Type = simpleTypeReference);
					Expression expression6 = (binaryExpression.Right = castExpression);
					array[0] = Statement.Lift(binaryExpression);
					WhileStatement whileStatement = new WhileStatement(LexicalInfo.Empty);
					BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.GreaterThan);
					Expression expression8 = (binaryExpression2.Left = Expression.Lift(e2));
					IntegerLiteralExpression integerLiteralExpression = new IntegerLiteralExpression(LexicalInfo.Empty);
					long num2 = (integerLiteralExpression.Value = 0L);
					bool flag4 = (integerLiteralExpression.IsLong = false);
					Expression expression10 = (binaryExpression2.Right = integerLiteralExpression);
					Expression expression12 = (whileStatement.Condition = binaryExpression2);
					Block block2 = new Block(LexicalInfo.Empty);
					Statement[] array2 = new Statement[2];
					BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.InPlaceSubtraction);
					Expression expression14 = (binaryExpression3.Left = Expression.Lift(e2));
					MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
					string text4 = (memberReferenceExpression.Name = "deltaTime");
					ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
					string text6 = (referenceExpression.Name = "Time");
					Expression expression16 = (memberReferenceExpression.Target = referenceExpression);
					Expression expression18 = (binaryExpression3.Right = memberReferenceExpression);
					array2[0] = Statement.Lift(binaryExpression3);
					array2[1] = Statement.Lift(new YieldStatement(LexicalInfo.Empty));
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
					Block block4 = (whileStatement.Block = block2);
					array[1] = Statement.Lift(whileStatement);
					StatementCollection statementCollection4 = (block.Statements = StatementCollection.FromArray(array));
					result = block;
					goto IL_05f5;
				}
			}
		}
		if (wait_sec is MacroStatement)
		{
			MacroStatement macroStatement2 = wait_sec;
			if (true && macroStatement2.Name == "wait_sec" && 2 == ((ICollection)macroStatement2.Arguments).Count)
			{
				Expression e = macroStatement2.Arguments[0];
				if (true)
				{
					Expression e3 = macroStatement2.Arguments[1];
					if (true)
					{
						ReferenceExpression e2 = new ReferenceExpression(Context.GetUniqueName("wait_sec", "temp"));
						Block block5 = new Block(LexicalInfo.Empty);
						Statement[] array3 = new Statement[2];
						BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Assign);
						Expression expression20 = (binaryExpression4.Left = Expression.Lift(e2));
						CastExpression castExpression2 = new CastExpression(LexicalInfo.Empty);
						Expression expression22 = (castExpression2.Target = Expression.Lift(e));
						SimpleTypeReference simpleTypeReference2 = new SimpleTypeReference(LexicalInfo.Empty);
						bool flag6 = (simpleTypeReference2.IsPointer = false);
						string text8 = (simpleTypeReference2.Name = "single");
						TypeReference typeReference4 = (castExpression2.Type = simpleTypeReference2);
						Expression expression24 = (binaryExpression4.Right = castExpression2);
						array3[0] = Statement.Lift(binaryExpression4);
						WhileStatement whileStatement2 = new WhileStatement(LexicalInfo.Empty);
						BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.GreaterThan);
						Expression expression26 = (binaryExpression5.Left = Expression.Lift(e2));
						IntegerLiteralExpression integerLiteralExpression2 = new IntegerLiteralExpression(LexicalInfo.Empty);
						long num4 = (integerLiteralExpression2.Value = 0L);
						bool flag8 = (integerLiteralExpression2.IsLong = false);
						Expression expression28 = (binaryExpression5.Right = integerLiteralExpression2);
						Expression expression30 = (whileStatement2.Condition = binaryExpression5);
						Block block6 = new Block(LexicalInfo.Empty);
						Statement[] array4 = new Statement[2];
						BinaryExpression binaryExpression6 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType12 = (binaryExpression6.Operator = BinaryOperatorType.InPlaceSubtraction);
						Expression expression32 = (binaryExpression6.Left = Expression.Lift(e2));
						BinaryExpression binaryExpression7 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType14 = (binaryExpression7.Operator = BinaryOperatorType.Multiply);
						MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text10 = (memberReferenceExpression2.Name = "deltaTime");
						ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
						string text12 = (referenceExpression2.Name = "Time");
						Expression expression34 = (memberReferenceExpression2.Target = referenceExpression2);
						Expression expression36 = (binaryExpression7.Left = memberReferenceExpression2);
						Expression expression38 = (binaryExpression7.Right = Expression.Lift(e3));
						Expression expression40 = (binaryExpression6.Right = binaryExpression7);
						array4[0] = Statement.Lift(binaryExpression6);
						array4[1] = Statement.Lift(new YieldStatement(LexicalInfo.Empty));
						StatementCollection statementCollection6 = (block6.Statements = StatementCollection.FromArray(array4));
						Block block8 = (whileStatement2.Block = block6);
						array3[1] = Statement.Lift(whileStatement2);
						StatementCollection statementCollection8 = (block5.Statements = StatementCollection.FromArray(array3));
						result = block5;
						goto IL_05f5;
					}
				}
			}
		}
		throw new Exception("wait_sec macro argument error");
		IL_05f5:
		return result;
	}
}
