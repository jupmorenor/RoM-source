using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Master_load_method_initMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Master_load_method_initMacro()
	{
	}

	public Master_load_method_initMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement master_load_method_init)
	{
		if (master_load_method_init == null)
		{
			throw new ArgumentNullException("master_load_method_init");
		}
		__macro = master_load_method_init;
		if (master_load_method_init is MacroStatement)
		{
			MacroStatement macroStatement = master_load_method_init;
			if (true && macroStatement.Name == "master_load_method_init" && 2 == ((ICollection)macroStatement.Arguments).Count && macroStatement.Arguments[0] is ReferenceExpression)
			{
				ReferenceExpression e = (ReferenceExpression)macroStatement.Arguments[0];
				if (true && macroStatement.Arguments[1] is ReferenceExpression)
				{
					ReferenceExpression referenceExpression = (ReferenceExpression)macroStatement.Arguments[1];
					if (true)
					{
						Block block = new Block(LexicalInfo.Empty);
						Statement[] array = new Statement[8];
						BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
						ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
						string text2 = (referenceExpression2.Name = "d");
						Expression expression2 = (binaryExpression.Left = referenceExpression2);
						MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
						ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
						string text4 = (referenceExpression3.Name = "MasterLoadMethodEntry");
						Expression expression4 = (methodInvocationExpression.Target = referenceExpression3);
						Expression expression6 = (binaryExpression.Right = methodInvocationExpression);
						array[0] = Statement.Lift(binaryExpression);
						BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Assign);
						SlicingExpression slicingExpression = new SlicingExpression(LexicalInfo.Empty);
						Expression expression8 = (slicingExpression.Target = Expression.Lift(e));
						Slice[] array2 = new Slice[1];
						Slice slice = new Slice(LexicalInfo.Empty);
						Expression expression10 = (slice.Begin = Expression.Lift(referenceExpression.Name));
						array2[0] = slice;
						SliceCollection sliceCollection2 = (slicingExpression.Indices = SliceCollection.FromArray(array2));
						Expression expression12 = (binaryExpression2.Left = slicingExpression);
						ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
						string text6 = (referenceExpression4.Name = "d");
						Expression expression14 = (binaryExpression2.Right = referenceExpression4);
						array[1] = Statement.Lift(binaryExpression2);
						BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
						string text8 = (memberReferenceExpression.Name = "masterType");
						ReferenceExpression referenceExpression5 = new ReferenceExpression(LexicalInfo.Empty);
						string text10 = (referenceExpression5.Name = "d");
						Expression expression16 = (memberReferenceExpression.Target = referenceExpression5);
						Expression expression18 = (binaryExpression3.Left = memberReferenceExpression);
						TypeofExpression typeofExpression = new TypeofExpression(LexicalInfo.Empty);
						TypeReference typeReference2 = (typeofExpression.Type = TypeReference.Lift(referenceExpression));
						Expression expression20 = (binaryExpression3.Right = typeofExpression);
						array[2] = Statement.Lift(binaryExpression3);
						BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text12 = (memberReferenceExpression2.Name = "unload");
						ReferenceExpression referenceExpression6 = new ReferenceExpression(LexicalInfo.Empty);
						string text14 = (referenceExpression6.Name = "d");
						Expression expression22 = (memberReferenceExpression2.Target = referenceExpression6);
						Expression expression24 = (binaryExpression4.Left = memberReferenceExpression2);
						BlockExpression blockExpression = new BlockExpression(LexicalInfo.Empty);
						Block block2 = new Block(LexicalInfo.Empty);
						Statement[] array3 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
						MemberReferenceExpression memberReferenceExpression3 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text16 = (memberReferenceExpression3.Name = "Unload");
						Expression expression26 = (memberReferenceExpression3.Target = Expression.Lift(referenceExpression));
						Expression expression28 = (methodInvocationExpression2.Target = memberReferenceExpression3);
						array3[0] = Statement.Lift(methodInvocationExpression2);
						StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array3));
						Block block4 = (blockExpression.Body = block2);
						Expression expression30 = (binaryExpression4.Right = blockExpression);
						array[3] = Statement.Lift(binaryExpression4);
						BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression4 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text18 = (memberReferenceExpression4.Name = "createInst");
						ReferenceExpression referenceExpression7 = new ReferenceExpression(LexicalInfo.Empty);
						string text20 = (referenceExpression7.Name = "d");
						Expression expression32 = (memberReferenceExpression4.Target = referenceExpression7);
						Expression expression34 = (binaryExpression5.Left = memberReferenceExpression4);
						BlockExpression blockExpression2 = new BlockExpression(LexicalInfo.Empty);
						Block block5 = new Block(LexicalInfo.Empty);
						Statement[] array4 = new Statement[1];
						ReturnStatement returnStatement = new ReturnStatement(LexicalInfo.Empty);
						MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression(LexicalInfo.Empty);
						Expression expression36 = (methodInvocationExpression3.Target = Expression.Lift(referenceExpression));
						Expression expression38 = (returnStatement.Expression = methodInvocationExpression3);
						array4[0] = Statement.Lift(returnStatement);
						StatementCollection statementCollection4 = (block5.Statements = StatementCollection.FromArray(array4));
						Block block7 = (blockExpression2.Body = block5);
						Expression expression40 = (binaryExpression5.Right = blockExpression2);
						array[4] = Statement.Lift(binaryExpression5);
						BinaryExpression binaryExpression6 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType12 = (binaryExpression6.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression5 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text22 = (memberReferenceExpression5.Name = "keyNameList");
						ReferenceExpression referenceExpression8 = new ReferenceExpression(LexicalInfo.Empty);
						string text24 = (referenceExpression8.Name = "d");
						Expression expression42 = (memberReferenceExpression5.Target = referenceExpression8);
						Expression expression44 = (binaryExpression6.Left = memberReferenceExpression5);
						BlockExpression blockExpression3 = new BlockExpression(LexicalInfo.Empty);
						Block block8 = new Block(LexicalInfo.Empty);
						Statement[] array5 = new Statement[1];
						ReturnStatement returnStatement2 = new ReturnStatement(LexicalInfo.Empty);
						MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression(LexicalInfo.Empty);
						MemberReferenceExpression memberReferenceExpression6 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text26 = (memberReferenceExpression6.Name = "KeyNameList");
						Expression expression46 = (memberReferenceExpression6.Target = Expression.Lift(referenceExpression));
						Expression expression48 = (methodInvocationExpression4.Target = memberReferenceExpression6);
						Expression expression50 = (returnStatement2.Expression = methodInvocationExpression4);
						array5[0] = Statement.Lift(returnStatement2);
						StatementCollection statementCollection6 = (block8.Statements = StatementCollection.FromArray(array5));
						Block block10 = (blockExpression3.Body = block8);
						Expression expression52 = (binaryExpression6.Right = blockExpression3);
						array[5] = Statement.Lift(binaryExpression6);
						BinaryExpression binaryExpression7 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType14 = (binaryExpression7.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression7 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text28 = (memberReferenceExpression7.Name = "setStringValues");
						ReferenceExpression referenceExpression9 = new ReferenceExpression(LexicalInfo.Empty);
						string text30 = (referenceExpression9.Name = "d");
						Expression expression54 = (memberReferenceExpression7.Target = referenceExpression9);
						Expression expression56 = (binaryExpression7.Left = memberReferenceExpression7);
						BlockExpression blockExpression4 = new BlockExpression(LexicalInfo.Empty);
						ParameterDeclaration[] array6 = new ParameterDeclaration[2];
						ParameterDeclaration parameterDeclaration = new ParameterDeclaration(LexicalInfo.Empty);
						string text32 = (parameterDeclaration.Name = "m");
						SimpleTypeReference simpleTypeReference = new SimpleTypeReference(LexicalInfo.Empty);
						bool flag2 = (simpleTypeReference.IsPointer = false);
						string text34 = (simpleTypeReference.Name = "MerlinMaster");
						TypeReference typeReference4 = (parameterDeclaration.Type = simpleTypeReference);
						array6[0] = parameterDeclaration;
						ParameterDeclaration parameterDeclaration2 = new ParameterDeclaration(LexicalInfo.Empty);
						string text36 = (parameterDeclaration2.Name = "strs");
						ArrayTypeReference arrayTypeReference = new ArrayTypeReference(LexicalInfo.Empty);
						bool flag4 = (arrayTypeReference.IsPointer = false);
						SimpleTypeReference simpleTypeReference2 = new SimpleTypeReference(LexicalInfo.Empty);
						bool flag6 = (simpleTypeReference2.IsPointer = false);
						string text38 = (simpleTypeReference2.Name = "string");
						TypeReference typeReference6 = (arrayTypeReference.ElementType = simpleTypeReference2);
						TypeReference typeReference8 = (parameterDeclaration2.Type = arrayTypeReference);
						array6[1] = parameterDeclaration2;
						ParameterDeclarationCollection parameterDeclarationCollection2 = (blockExpression4.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array6));
						Block block11 = new Block(LexicalInfo.Empty);
						Statement[] array7 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression5 = new MethodInvocationExpression(LexicalInfo.Empty);
						MemberReferenceExpression memberReferenceExpression8 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text40 = (memberReferenceExpression8.Name = "setStringValues");
						TryCastExpression tryCastExpression = new TryCastExpression(LexicalInfo.Empty);
						ReferenceExpression referenceExpression10 = new ReferenceExpression(LexicalInfo.Empty);
						string text42 = (referenceExpression10.Name = "m");
						Expression expression58 = (tryCastExpression.Target = referenceExpression10);
						TypeReference typeReference10 = (tryCastExpression.Type = TypeReference.Lift(referenceExpression));
						Expression expression60 = (memberReferenceExpression8.Target = tryCastExpression);
						Expression expression62 = (methodInvocationExpression5.Target = memberReferenceExpression8);
						Expression[] array8 = new Expression[1];
						ReferenceExpression referenceExpression11 = new ReferenceExpression(LexicalInfo.Empty);
						string text44 = (referenceExpression11.Name = "strs");
						array8[0] = referenceExpression11;
						ExpressionCollection expressionCollection2 = (methodInvocationExpression5.Arguments = ExpressionCollection.FromArray(array8));
						array7[0] = Statement.Lift(methodInvocationExpression5);
						StatementCollection statementCollection8 = (block11.Statements = StatementCollection.FromArray(array7));
						Block block13 = (blockExpression4.Body = block11);
						Expression expression64 = (binaryExpression7.Right = blockExpression4);
						array[6] = Statement.Lift(binaryExpression7);
						BinaryExpression binaryExpression8 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType16 = (binaryExpression8.Operator = BinaryOperatorType.Assign);
						MemberReferenceExpression memberReferenceExpression9 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text46 = (memberReferenceExpression9.Name = "addMst");
						ReferenceExpression referenceExpression12 = new ReferenceExpression(LexicalInfo.Empty);
						string text48 = (referenceExpression12.Name = "d");
						Expression expression66 = (memberReferenceExpression9.Target = referenceExpression12);
						Expression expression68 = (binaryExpression8.Left = memberReferenceExpression9);
						BlockExpression blockExpression5 = new BlockExpression(LexicalInfo.Empty);
						ParameterDeclaration[] array9 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration3 = new ParameterDeclaration(LexicalInfo.Empty);
						string text50 = (parameterDeclaration3.Name = "m");
						SimpleTypeReference simpleTypeReference3 = new SimpleTypeReference(LexicalInfo.Empty);
						bool flag8 = (simpleTypeReference3.IsPointer = false);
						string text52 = (simpleTypeReference3.Name = "MerlinMaster");
						TypeReference typeReference12 = (parameterDeclaration3.Type = simpleTypeReference3);
						array9[0] = parameterDeclaration3;
						ParameterDeclarationCollection parameterDeclarationCollection4 = (blockExpression5.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array9));
						Block block14 = new Block(LexicalInfo.Empty);
						Statement[] array10 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression6 = new MethodInvocationExpression(LexicalInfo.Empty);
						MemberReferenceExpression memberReferenceExpression10 = new MemberReferenceExpression(LexicalInfo.Empty);
						string text54 = (memberReferenceExpression10.Name = "AddMst");
						Expression expression70 = (memberReferenceExpression10.Target = Expression.Lift(referenceExpression));
						Expression expression72 = (methodInvocationExpression6.Target = memberReferenceExpression10);
						Expression[] array11 = new Expression[1];
						TryCastExpression tryCastExpression2 = new TryCastExpression(LexicalInfo.Empty);
						ReferenceExpression referenceExpression13 = new ReferenceExpression(LexicalInfo.Empty);
						string text56 = (referenceExpression13.Name = "m");
						Expression expression74 = (tryCastExpression2.Target = referenceExpression13);
						TypeReference typeReference14 = (tryCastExpression2.Type = TypeReference.Lift(referenceExpression));
						array11[0] = tryCastExpression2;
						ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array11));
						array10[0] = Statement.Lift(methodInvocationExpression6);
						StatementCollection statementCollection10 = (block14.Statements = StatementCollection.FromArray(array10));
						Block block16 = (blockExpression5.Body = block14);
						Expression expression76 = (binaryExpression8.Right = blockExpression5);
						array[7] = Statement.Lift(binaryExpression8);
						StatementCollection statementCollection12 = (block.Statements = StatementCollection.FromArray(array));
						return block;
					}
				}
			}
		}
		throw new Exception("`master_load_method_init` macro invocation argument(s) did not match definition: `master_load_method_init((dictName as Boo.Lang.Compiler.Ast.ReferenceExpression), (n as Boo.Lang.Compiler.Ast.ReferenceExpression))`");
	}
}
