using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class Scene_path_tbl_propMacro : SceneIDBaseMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002415416 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal string[] _0024paths_002415417;

			internal ArrayLiteralExpression _0024pathArray_002415418;

			internal string _0024p_002415419;

			internal ReturnStatement _0024_00244074_002415420;

			internal Block _0024_00244075_002415421;

			internal Method _0024_00244076_002415422;

			internal SimpleTypeReference _0024_00244077_002415423;

			internal ArrayTypeReference _0024_00244078_002415424;

			internal Property _0024_00244079_002415425;

			internal ReferenceExpression _0024_00244080_002415426;

			internal ReferenceExpression _0024_00244081_002415427;

			internal SimpleTypeReference _0024_00244082_002415428;

			internal GenericReferenceExpression _0024_00244083_002415429;

			internal MethodInvocationExpression _0024_00244084_002415430;

			internal BinaryExpression _0024_00244085_002415431;

			internal Declaration _0024_00244086_002415432;

			internal ReferenceExpression _0024_00244087_002415433;

			internal ReferenceExpression _0024_00244088_002415434;

			internal MemberReferenceExpression _0024_00244089_002415435;

			internal ReferenceExpression _0024_00244090_002415436;

			internal ReferenceExpression _0024_00244091_002415437;

			internal MethodInvocationExpression _0024_00244092_002415438;

			internal MethodInvocationExpression _0024_00244093_002415439;

			internal Block _0024_00244094_002415440;

			internal ForStatement _0024_00244095_002415441;

			internal ReferenceExpression _0024_00244096_002415442;

			internal ReferenceExpression _0024_00244097_002415443;

			internal MethodInvocationExpression _0024_00244098_002415444;

			internal ReturnStatement _0024_00244099_002415445;

			internal Block _0024_00244100_002415446;

			internal Method _0024_00244101_002415447;

			internal SimpleTypeReference _0024_00244102_002415448;

			internal ArrayTypeReference _0024_00244103_002415449;

			internal Property _0024_00244104_002415450;

			internal SimpleTypeReference _0024_00244105_002415451;

			internal ParameterDeclaration _0024_00244106_002415452;

			internal SimpleTypeReference _0024_00244107_002415453;

			internal ReferenceExpression _0024_00244108_002415454;

			internal ReferenceExpression _0024_00244109_002415455;

			internal MethodInvocationExpression _0024_00244110_002415456;

			internal BinaryExpression _0024_00244111_002415457;

			internal ReferenceExpression _0024_00244112_002415458;

			internal MemberReferenceExpression _0024_00244113_002415459;

			internal ReferenceExpression _0024_00244114_002415460;

			internal BinaryExpression _0024_00244115_002415461;

			internal ReferenceExpression _0024_00244116_002415462;

			internal MemberReferenceExpression _0024_00244117_002415463;

			internal BoolLiteralExpression _0024_00244118_002415464;

			internal BinaryExpression _0024_00244119_002415465;

			internal ReferenceExpression _0024_00244120_002415466;

			internal ReturnStatement _0024_00244121_002415467;

			internal Block _0024_00244122_002415468;

			internal Method _0024_00244123_002415469;

			internal int _0024_00248080_002415470;

			internal string[] _0024_00248081_002415471;

			internal int _0024_00248082_002415472;

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						_0024paths_002415417 = SceneIDBaseMacro.ScenePathList(forceUpdate: true);
						_0024pathArray_002415418 = new ArrayLiteralExpression();
						_0024_00248080_002415470 = 0;
						_0024_00248081_002415471 = _0024paths_002415417;
						for (_0024_00248082_002415472 = _0024_00248081_002415471.Length; _0024_00248080_002415470 < _0024_00248082_002415472; _0024_00248080_002415470++)
						{
							_0024pathArray_002415418.Items.Add(new StringLiteralExpression(_0024_00248081_002415471[_0024_00248080_002415470]));
						}
						Property property4 = (_0024_00244079_002415425 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers6 = (_0024_00244079_002415425.Modifiers = TypeMemberModifiers.Static);
						string text54 = (_0024_00244079_002415425.Name = "BuildScenePaths");
						Property property5 = _0024_00244079_002415425;
						Method method9 = (_0024_00244076_002415422 = new Method(LexicalInfo.Empty));
						string text56 = (_0024_00244076_002415422.Name = "get");
						Method method10 = _0024_00244076_002415422;
						Block block13 = (_0024_00244075_002415421 = new Block(LexicalInfo.Empty));
						Block block14 = _0024_00244075_002415421;
						Statement[] array10 = new Statement[1];
						ReturnStatement returnStatement5 = (_0024_00244074_002415420 = new ReturnStatement(LexicalInfo.Empty));
						Expression expression42 = (_0024_00244074_002415420.Expression = Expression.Lift(_0024pathArray_002415418));
						array10[0] = Statement.Lift(_0024_00244074_002415420);
						StatementCollection statementCollection8 = (block14.Statements = StatementCollection.FromArray(array10));
						Block block16 = (method10.Body = _0024_00244075_002415421);
						Method method12 = (property5.Getter = _0024_00244076_002415422);
						Property property6 = _0024_00244079_002415425;
						ArrayTypeReference arrayTypeReference3 = (_0024_00244078_002415424 = new ArrayTypeReference(LexicalInfo.Empty));
						bool flag14 = (_0024_00244078_002415424.IsPointer = false);
						ArrayTypeReference arrayTypeReference4 = _0024_00244078_002415424;
						SimpleTypeReference simpleTypeReference5 = (_0024_00244077_002415423 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag16 = (_0024_00244077_002415423.IsPointer = false);
						string text58 = (_0024_00244077_002415423.Name = "string");
						TypeReference typeReference10 = (arrayTypeReference4.ElementType = _0024_00244077_002415423);
						TypeReference typeReference12 = (property6.Type = _0024_00244078_002415424);
						result = (Yield(2, _0024_00244079_002415425) ? 1 : 0);
						break;
					}
					case 2:
					{
						Property property = (_0024_00244104_002415450 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers4 = (_0024_00244104_002415450.Modifiers = TypeMemberModifiers.Static);
						string text26 = (_0024_00244104_002415450.Name = "BuildScenes");
						Property property2 = _0024_00244104_002415450;
						Method method5 = (_0024_00244101_002415447 = new Method(LexicalInfo.Empty));
						string text28 = (_0024_00244101_002415447.Name = "get");
						Method method6 = _0024_00244101_002415447;
						Block block5 = (_0024_00244100_002415446 = new Block(LexicalInfo.Empty));
						Block block6 = _0024_00244100_002415446;
						Statement[] array3 = new Statement[3];
						BinaryExpression binaryExpression10 = (_0024_00244085_002415431 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType8 = (_0024_00244085_002415431.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression11 = _0024_00244085_002415431;
						ReferenceExpression referenceExpression7 = (_0024_00244080_002415426 = new ReferenceExpression(LexicalInfo.Empty));
						string text30 = (_0024_00244080_002415426.Name = "slist");
						Expression expression22 = (binaryExpression11.Left = _0024_00244080_002415426);
						BinaryExpression binaryExpression12 = _0024_00244085_002415431;
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00244084_002415430 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00244084_002415430;
						GenericReferenceExpression genericReferenceExpression = (_0024_00244083_002415429 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression2 = _0024_00244083_002415429;
						ReferenceExpression referenceExpression8 = (_0024_00244081_002415427 = new ReferenceExpression(LexicalInfo.Empty));
						string text32 = (_0024_00244081_002415427.Name = "List");
						Expression expression24 = (genericReferenceExpression2.Target = _0024_00244081_002415427);
						GenericReferenceExpression genericReferenceExpression3 = _0024_00244083_002415429;
						TypeReference[] array4 = new TypeReference[1];
						SimpleTypeReference simpleTypeReference3 = (_0024_00244082_002415428 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag8 = (_0024_00244082_002415428.IsPointer = false);
						string text34 = (_0024_00244082_002415428.Name = "EditorBuildSettingsScene");
						array4[0] = _0024_00244082_002415428;
						TypeReferenceCollection typeReferenceCollection2 = (genericReferenceExpression3.GenericArguments = TypeReferenceCollection.FromArray(array4));
						Expression expression26 = (methodInvocationExpression4.Target = _0024_00244083_002415429);
						Expression expression28 = (binaryExpression12.Right = _0024_00244084_002415430);
						array3[0] = Statement.Lift(_0024_00244085_002415431);
						ForStatement forStatement = (_0024_00244095_002415441 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement2 = _0024_00244095_002415441;
						Declaration[] array5 = new Declaration[1];
						Declaration declaration = (_0024_00244086_002415432 = new Declaration(LexicalInfo.Empty));
						string text36 = (_0024_00244086_002415432.Name = "path");
						array5[0] = _0024_00244086_002415432;
						DeclarationCollection declarationCollection2 = (forStatement2.Declarations = DeclarationCollection.FromArray(array5));
						ForStatement forStatement3 = _0024_00244095_002415441;
						ReferenceExpression referenceExpression9 = (_0024_00244087_002415433 = new ReferenceExpression(LexicalInfo.Empty));
						string text38 = (_0024_00244087_002415433.Name = "BuildScenePaths");
						Expression expression30 = (forStatement3.Iterator = _0024_00244087_002415433);
						ForStatement forStatement4 = _0024_00244095_002415441;
						Block block7 = (_0024_00244094_002415440 = new Block(LexicalInfo.Empty));
						Block block8 = _0024_00244094_002415440;
						Statement[] array6 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression5 = (_0024_00244093_002415439 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression6 = _0024_00244093_002415439;
						MemberReferenceExpression memberReferenceExpression5 = (_0024_00244089_002415435 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text40 = (_0024_00244089_002415435.Name = "Add");
						MemberReferenceExpression memberReferenceExpression6 = _0024_00244089_002415435;
						ReferenceExpression referenceExpression10 = (_0024_00244088_002415434 = new ReferenceExpression(LexicalInfo.Empty));
						string text42 = (_0024_00244088_002415434.Name = "slist");
						Expression expression32 = (memberReferenceExpression6.Target = _0024_00244088_002415434);
						Expression expression34 = (methodInvocationExpression6.Target = _0024_00244089_002415435);
						MethodInvocationExpression methodInvocationExpression7 = _0024_00244093_002415439;
						Expression[] array7 = new Expression[1];
						MethodInvocationExpression methodInvocationExpression8 = (_0024_00244092_002415438 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression9 = _0024_00244092_002415438;
						ReferenceExpression referenceExpression11 = (_0024_00244090_002415436 = new ReferenceExpression(LexicalInfo.Empty));
						string text44 = (_0024_00244090_002415436.Name = "CreateSceneObj");
						Expression expression36 = (methodInvocationExpression9.Target = _0024_00244090_002415436);
						MethodInvocationExpression methodInvocationExpression10 = _0024_00244092_002415438;
						Expression[] array8 = new Expression[1];
						ReferenceExpression referenceExpression12 = (_0024_00244091_002415437 = new ReferenceExpression(LexicalInfo.Empty));
						string text46 = (_0024_00244091_002415437.Name = "path");
						array8[0] = _0024_00244091_002415437;
						ExpressionCollection expressionCollection2 = (methodInvocationExpression10.Arguments = ExpressionCollection.FromArray(array8));
						array7[0] = _0024_00244092_002415438;
						ExpressionCollection expressionCollection4 = (methodInvocationExpression7.Arguments = ExpressionCollection.FromArray(array7));
						array6[0] = Statement.Lift(_0024_00244093_002415439);
						StatementCollection statementCollection4 = (block8.Statements = StatementCollection.FromArray(array6));
						Block block10 = (forStatement4.Block = _0024_00244094_002415440);
						array3[1] = Statement.Lift(_0024_00244095_002415441);
						ReturnStatement returnStatement3 = (_0024_00244099_002415445 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement4 = _0024_00244099_002415445;
						MethodInvocationExpression methodInvocationExpression11 = (_0024_00244098_002415444 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression12 = _0024_00244098_002415444;
						ReferenceExpression referenceExpression13 = (_0024_00244096_002415442 = new ReferenceExpression(LexicalInfo.Empty));
						string text48 = (_0024_00244096_002415442.Name = "array");
						Expression expression38 = (methodInvocationExpression12.Target = _0024_00244096_002415442);
						MethodInvocationExpression methodInvocationExpression13 = _0024_00244098_002415444;
						Expression[] array9 = new Expression[1];
						ReferenceExpression referenceExpression14 = (_0024_00244097_002415443 = new ReferenceExpression(LexicalInfo.Empty));
						string text50 = (_0024_00244097_002415443.Name = "slist");
						array9[0] = _0024_00244097_002415443;
						ExpressionCollection expressionCollection6 = (methodInvocationExpression13.Arguments = ExpressionCollection.FromArray(array9));
						Expression expression40 = (returnStatement4.Expression = _0024_00244098_002415444);
						array3[2] = Statement.Lift(_0024_00244099_002415445);
						StatementCollection statementCollection6 = (block6.Statements = StatementCollection.FromArray(array3));
						Block block12 = (method6.Body = _0024_00244100_002415446);
						Method method8 = (property2.Getter = _0024_00244101_002415447);
						Property property3 = _0024_00244104_002415450;
						ArrayTypeReference arrayTypeReference = (_0024_00244103_002415449 = new ArrayTypeReference(LexicalInfo.Empty));
						bool flag10 = (_0024_00244103_002415449.IsPointer = false);
						ArrayTypeReference arrayTypeReference2 = _0024_00244103_002415449;
						SimpleTypeReference simpleTypeReference4 = (_0024_00244102_002415448 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag12 = (_0024_00244102_002415448.IsPointer = false);
						string text52 = (_0024_00244102_002415448.Name = "EditorBuildSettingsScene");
						TypeReference typeReference6 = (arrayTypeReference2.ElementType = _0024_00244102_002415448);
						TypeReference typeReference8 = (property3.Type = _0024_00244103_002415449);
						result = (Yield(3, _0024_00244104_002415450) ? 1 : 0);
						break;
					}
					case 3:
					{
						Method method = (_0024_00244123_002415469 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00244123_002415469.Modifiers = TypeMemberModifiers.Static);
						string text2 = (_0024_00244123_002415469.Name = "CreateSceneObj");
						Method method2 = _0024_00244123_002415469;
						ParameterDeclaration[] array = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration = (_0024_00244106_002415452 = new ParameterDeclaration(LexicalInfo.Empty));
						string text4 = (_0024_00244106_002415452.Name = "path");
						ParameterDeclaration parameterDeclaration2 = _0024_00244106_002415452;
						SimpleTypeReference simpleTypeReference = (_0024_00244105_002415451 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag2 = (_0024_00244105_002415451.IsPointer = false);
						string text6 = (_0024_00244105_002415451.Name = "string");
						TypeReference typeReference2 = (parameterDeclaration2.Type = _0024_00244105_002415451);
						array[0] = _0024_00244106_002415452;
						ParameterDeclarationCollection parameterDeclarationCollection2 = (method2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array));
						Method method3 = _0024_00244123_002415469;
						SimpleTypeReference simpleTypeReference2 = (_0024_00244107_002415453 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag4 = (_0024_00244107_002415453.IsPointer = false);
						string text8 = (_0024_00244107_002415453.Name = "EditorBuildSettingsScene");
						TypeReference typeReference4 = (method3.ReturnType = _0024_00244107_002415453);
						Method method4 = _0024_00244123_002415469;
						Block block = (_0024_00244122_002415468 = new Block(LexicalInfo.Empty));
						Block block2 = _0024_00244122_002415468;
						Statement[] array2 = new Statement[4];
						BinaryExpression binaryExpression = (_0024_00244111_002415457 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00244111_002415457.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression2 = _0024_00244111_002415457;
						ReferenceExpression referenceExpression = (_0024_00244108_002415454 = new ReferenceExpression(LexicalInfo.Empty));
						string text10 = (_0024_00244108_002415454.Name = "sobj");
						Expression expression2 = (binaryExpression2.Left = _0024_00244108_002415454);
						BinaryExpression binaryExpression3 = _0024_00244111_002415457;
						MethodInvocationExpression methodInvocationExpression = (_0024_00244110_002415456 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00244110_002415456;
						ReferenceExpression referenceExpression2 = (_0024_00244109_002415455 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00244109_002415455.Name = "EditorBuildSettingsScene");
						Expression expression4 = (methodInvocationExpression2.Target = _0024_00244109_002415455);
						Expression expression6 = (binaryExpression3.Right = _0024_00244110_002415456);
						array2[0] = Statement.Lift(_0024_00244111_002415457);
						BinaryExpression binaryExpression4 = (_0024_00244115_002415461 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00244115_002415461.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression5 = _0024_00244115_002415461;
						MemberReferenceExpression memberReferenceExpression = (_0024_00244113_002415459 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text14 = (_0024_00244113_002415459.Name = "path");
						MemberReferenceExpression memberReferenceExpression2 = _0024_00244113_002415459;
						ReferenceExpression referenceExpression3 = (_0024_00244112_002415458 = new ReferenceExpression(LexicalInfo.Empty));
						string text16 = (_0024_00244112_002415458.Name = "sobj");
						Expression expression8 = (memberReferenceExpression2.Target = _0024_00244112_002415458);
						Expression expression10 = (binaryExpression5.Left = _0024_00244113_002415459);
						BinaryExpression binaryExpression6 = _0024_00244115_002415461;
						ReferenceExpression referenceExpression4 = (_0024_00244114_002415460 = new ReferenceExpression(LexicalInfo.Empty));
						string text18 = (_0024_00244114_002415460.Name = "path");
						Expression expression12 = (binaryExpression6.Right = _0024_00244114_002415460);
						array2[1] = Statement.Lift(_0024_00244115_002415461);
						BinaryExpression binaryExpression7 = (_0024_00244119_002415465 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType6 = (_0024_00244119_002415465.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression8 = _0024_00244119_002415465;
						MemberReferenceExpression memberReferenceExpression3 = (_0024_00244117_002415463 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text20 = (_0024_00244117_002415463.Name = "enabled");
						MemberReferenceExpression memberReferenceExpression4 = _0024_00244117_002415463;
						ReferenceExpression referenceExpression5 = (_0024_00244116_002415462 = new ReferenceExpression(LexicalInfo.Empty));
						string text22 = (_0024_00244116_002415462.Name = "sobj");
						Expression expression14 = (memberReferenceExpression4.Target = _0024_00244116_002415462);
						Expression expression16 = (binaryExpression8.Left = _0024_00244117_002415463);
						BinaryExpression binaryExpression9 = _0024_00244119_002415465;
						BoolLiteralExpression boolLiteralExpression = (_0024_00244118_002415464 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag6 = (_0024_00244118_002415464.Value = true);
						Expression expression18 = (binaryExpression9.Right = _0024_00244118_002415464);
						array2[2] = Statement.Lift(_0024_00244119_002415465);
						ReturnStatement returnStatement = (_0024_00244121_002415467 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00244121_002415467;
						ReferenceExpression referenceExpression6 = (_0024_00244120_002415466 = new ReferenceExpression(LexicalInfo.Empty));
						string text24 = (_0024_00244120_002415466.Name = "sobj");
						Expression expression20 = (returnStatement2.Expression = _0024_00244120_002415466);
						array2[3] = Statement.Lift(_0024_00244121_002415467);
						StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
						Block block4 = (method4.Body = _0024_00244122_002415468);
						result = (Yield(4, _0024_00244123_002415469) ? 1 : 0);
						break;
					}
					case 4:
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			//yield-return decompiler failed: Method not found
			return new _0024();
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002415416();
	}
}
