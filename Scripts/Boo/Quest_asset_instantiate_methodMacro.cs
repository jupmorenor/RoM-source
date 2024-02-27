using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public sealed class Quest_asset_instantiate_methodMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002418440 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_002418441;

			internal int _0024nargs_002418442;

			internal ReferenceExpression _0024name_002418443;

			internal ReferenceExpression _0024methodName_002418444;

			internal Method _0024b_002418445;

			internal ReferenceExpression _0024compoType_002418446;

			internal Field _0024_00244416_002418447;

			internal BinaryExpression _0024_00244417_002418448;

			internal StringLiteralExpression _0024_00244418_002418449;

			internal BinaryExpression _0024_00244419_002418450;

			internal StringLiteralExpression _0024_00244420_002418451;

			internal BinaryExpression _0024_00244421_002418452;

			internal MacroStatement _0024_00244422_002418453;

			internal Block _0024_00244423_002418454;

			internal IfStatement _0024_00244424_002418455;

			internal SimpleTypeReference _0024_00244425_002418456;

			internal Declaration _0024_00244426_002418457;

			internal ReferenceExpression _0024_00244427_002418458;

			internal MemberReferenceExpression _0024_00244428_002418459;

			internal MethodInvocationExpression _0024_00244429_002418460;

			internal DeclarationStatement _0024_00244430_002418461;

			internal ReferenceExpression _0024_00244431_002418462;

			internal BinaryExpression _0024_00244432_002418463;

			internal StringLiteralExpression _0024_00244433_002418464;

			internal BinaryExpression _0024_00244434_002418465;

			internal StringLiteralExpression _0024_00244435_002418466;

			internal BinaryExpression _0024_00244436_002418467;

			internal MacroStatement _0024_00244437_002418468;

			internal Block _0024_00244438_002418469;

			internal IfStatement _0024_00244439_002418470;

			internal ReferenceExpression _0024_00244440_002418471;

			internal ReferenceExpression _0024_00244441_002418472;

			internal MemberReferenceExpression _0024_00244442_002418473;

			internal GenericReferenceExpression _0024_00244443_002418474;

			internal MethodInvocationExpression _0024_00244444_002418475;

			internal BinaryExpression _0024_00244445_002418476;

			internal ReferenceExpression _0024_00244446_002418477;

			internal BinaryExpression _0024_00244447_002418478;

			internal StringLiteralExpression _0024_00244448_002418479;

			internal BinaryExpression _0024_00244449_002418480;

			internal StringLiteralExpression _0024_00244450_002418481;

			internal BinaryExpression _0024_00244451_002418482;

			internal BinaryExpression _0024_00244452_002418483;

			internal StringLiteralExpression _0024_00244453_002418484;

			internal BinaryExpression _0024_00244454_002418485;

			internal MacroStatement _0024_00244455_002418486;

			internal Block _0024_00244456_002418487;

			internal IfStatement _0024_00244457_002418488;

			internal ReferenceExpression _0024_00244458_002418489;

			internal ReturnStatement _0024_00244459_002418490;

			internal Block _0024_00244460_002418491;

			internal Method _0024_00244461_002418492;

			internal Method _0024m1_002418493;

			internal SimpleTypeReference _0024_00244462_002418494;

			internal ParameterDeclaration _0024_00244463_002418495;

			internal SimpleTypeReference _0024_00244464_002418496;

			internal ParameterDeclaration _0024_00244465_002418497;

			internal BinaryExpression _0024_00244466_002418498;

			internal StringLiteralExpression _0024_00244467_002418499;

			internal BinaryExpression _0024_00244468_002418500;

			internal StringLiteralExpression _0024_00244469_002418501;

			internal BinaryExpression _0024_00244470_002418502;

			internal MacroStatement _0024_00244471_002418503;

			internal Block _0024_00244472_002418504;

			internal IfStatement _0024_00244473_002418505;

			internal SimpleTypeReference _0024_00244474_002418506;

			internal Declaration _0024_00244475_002418507;

			internal ReferenceExpression _0024_00244476_002418508;

			internal MemberReferenceExpression _0024_00244477_002418509;

			internal ReferenceExpression _0024_00244478_002418510;

			internal ReferenceExpression _0024_00244479_002418511;

			internal MethodInvocationExpression _0024_00244480_002418512;

			internal DeclarationStatement _0024_00244481_002418513;

			internal ReferenceExpression _0024_00244482_002418514;

			internal BinaryExpression _0024_00244483_002418515;

			internal StringLiteralExpression _0024_00244484_002418516;

			internal BinaryExpression _0024_00244485_002418517;

			internal StringLiteralExpression _0024_00244486_002418518;

			internal BinaryExpression _0024_00244487_002418519;

			internal MacroStatement _0024_00244488_002418520;

			internal Block _0024_00244489_002418521;

			internal IfStatement _0024_00244490_002418522;

			internal ReferenceExpression _0024_00244491_002418523;

			internal ReferenceExpression _0024_00244492_002418524;

			internal MemberReferenceExpression _0024_00244493_002418525;

			internal GenericReferenceExpression _0024_00244494_002418526;

			internal MethodInvocationExpression _0024_00244495_002418527;

			internal BinaryExpression _0024_00244496_002418528;

			internal ReferenceExpression _0024_00244497_002418529;

			internal BinaryExpression _0024_00244498_002418530;

			internal StringLiteralExpression _0024_00244499_002418531;

			internal BinaryExpression _0024_00244500_002418532;

			internal StringLiteralExpression _0024_00244501_002418533;

			internal BinaryExpression _0024_00244502_002418534;

			internal BinaryExpression _0024_00244503_002418535;

			internal StringLiteralExpression _0024_00244504_002418536;

			internal BinaryExpression _0024_00244505_002418537;

			internal MacroStatement _0024_00244506_002418538;

			internal Block _0024_00244507_002418539;

			internal IfStatement _0024_00244508_002418540;

			internal ReferenceExpression _0024_00244509_002418541;

			internal ReturnStatement _0024_00244510_002418542;

			internal Block _0024_00244511_002418543;

			internal Method _0024_00244512_002418544;

			internal Method _0024m2_002418545;

			internal SimpleTypeReference _0024_00244513_002418546;

			internal Field _0024_00244514_002418547;

			internal SimpleTypeReference _0024_00244515_002418548;

			internal BinaryExpression _0024_00244516_002418549;

			internal StringLiteralExpression _0024_00244517_002418550;

			internal BinaryExpression _0024_00244518_002418551;

			internal StringLiteralExpression _0024_00244519_002418552;

			internal BinaryExpression _0024_00244520_002418553;

			internal MacroStatement _0024_00244521_002418554;

			internal Block _0024_00244522_002418555;

			internal IfStatement _0024_00244523_002418556;

			internal SimpleTypeReference _0024_00244524_002418557;

			internal Declaration _0024_00244525_002418558;

			internal ReferenceExpression _0024_00244526_002418559;

			internal MemberReferenceExpression _0024_00244527_002418560;

			internal MethodInvocationExpression _0024_00244528_002418561;

			internal DeclarationStatement _0024_00244529_002418562;

			internal ReferenceExpression _0024_00244530_002418563;

			internal BinaryExpression _0024_00244531_002418564;

			internal StringLiteralExpression _0024_00244532_002418565;

			internal BinaryExpression _0024_00244533_002418566;

			internal StringLiteralExpression _0024_00244534_002418567;

			internal BinaryExpression _0024_00244535_002418568;

			internal MacroStatement _0024_00244536_002418569;

			internal Block _0024_00244537_002418570;

			internal IfStatement _0024_00244538_002418571;

			internal ReferenceExpression _0024_00244539_002418572;

			internal ReturnStatement _0024_00244540_002418573;

			internal Block _0024_00244541_002418574;

			internal Method _0024_00244542_002418575;

			internal Method _0024m3_002418576;

			internal SimpleTypeReference _0024_00244543_002418577;

			internal ParameterDeclaration _0024_00244544_002418578;

			internal SimpleTypeReference _0024_00244545_002418579;

			internal ParameterDeclaration _0024_00244546_002418580;

			internal SimpleTypeReference _0024_00244547_002418581;

			internal BinaryExpression _0024_00244548_002418582;

			internal StringLiteralExpression _0024_00244549_002418583;

			internal BinaryExpression _0024_00244550_002418584;

			internal StringLiteralExpression _0024_00244551_002418585;

			internal BinaryExpression _0024_00244552_002418586;

			internal MacroStatement _0024_00244553_002418587;

			internal Block _0024_00244554_002418588;

			internal IfStatement _0024_00244555_002418589;

			internal SimpleTypeReference _0024_00244556_002418590;

			internal Declaration _0024_00244557_002418591;

			internal ReferenceExpression _0024_00244558_002418592;

			internal MemberReferenceExpression _0024_00244559_002418593;

			internal ReferenceExpression _0024_00244560_002418594;

			internal ReferenceExpression _0024_00244561_002418595;

			internal MethodInvocationExpression _0024_00244562_002418596;

			internal DeclarationStatement _0024_00244563_002418597;

			internal ReferenceExpression _0024_00244564_002418598;

			internal BinaryExpression _0024_00244565_002418599;

			internal StringLiteralExpression _0024_00244566_002418600;

			internal BinaryExpression _0024_00244567_002418601;

			internal StringLiteralExpression _0024_00244568_002418602;

			internal BinaryExpression _0024_00244569_002418603;

			internal MacroStatement _0024_00244570_002418604;

			internal Block _0024_00244571_002418605;

			internal IfStatement _0024_00244572_002418606;

			internal ReferenceExpression _0024_00244573_002418607;

			internal ReturnStatement _0024_00244574_002418608;

			internal Block _0024_00244575_002418609;

			internal Method _0024_00244576_002418610;

			internal Method _0024m4_002418611;

			internal MacroStatement _0024quest_asset_instantiate_method_002418612;

			internal Quest_asset_instantiate_methodMacro _0024self__002418613;

			public _0024(MacroStatement quest_asset_instantiate_method, Quest_asset_instantiate_methodMacro self_)
			{
				_0024quest_asset_instantiate_method_002418612 = quest_asset_instantiate_method;
				_0024self__002418613 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024quest_asset_instantiate_method_002418612 == null)
					{
						throw new ArgumentNullException("quest_asset_instantiate_method");
					}
					_0024self__002418613.__macro = _0024quest_asset_instantiate_method_002418612;
					_0024args_002418441 = _0024quest_asset_instantiate_method_002418612.Arguments;
					_0024nargs_002418442 = ((ICollection)_0024args_002418441).Count;
					if (_0024nargs_002418442 < 2)
					{
						throw new AssertionFailedException("nargs >= 2");
					}
					_0024name_002418443 = _0024args_002418441[0] as ReferenceExpression;
					_0024methodName_002418444 = _0024args_002418441[1] as ReferenceExpression;
					_0024b_002418445 = null;
					if (_0024nargs_002418442 >= 3)
					{
						_0024compoType_002418446 = _0024args_002418441[2] as ReferenceExpression;
						Field field = (_0024_00244416_002418447 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers10 = (_0024_00244416_002418447.Modifiers = TypeMemberModifiers.Public);
						string text166 = (_0024_00244416_002418447.Name = "$");
						TypeReference typeReference26 = (_0024_00244416_002418447.Type = TypeReference.Lift(_0024compoType_002418446));
						bool flag22 = (_0024_00244416_002418447.IsVolatile = false);
						string text168 = (_0024_00244416_002418447.Name = CodeSerializer.LiftName(_0024name_002418443));
						result = (Yield(2, _0024_00244416_002418447) ? 1 : 0);
					}
					else
					{
						Field field2 = (_0024_00244514_002418547 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers12 = (_0024_00244514_002418547.Modifiers = TypeMemberModifiers.Public);
						string text170 = (_0024_00244514_002418547.Name = "$");
						Field field3 = _0024_00244514_002418547;
						SimpleTypeReference simpleTypeReference11 = (_0024_00244513_002418546 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag24 = (_0024_00244513_002418546.IsPointer = false);
						string text172 = (_0024_00244513_002418546.Name = "GameObject");
						TypeReference typeReference28 = (field3.Type = _0024_00244513_002418546);
						bool flag26 = (_0024_00244514_002418547.IsVolatile = false);
						string text174 = (_0024_00244514_002418547.Name = CodeSerializer.LiftName(_0024name_002418443));
						result = (Yield(5, _0024_00244514_002418547) ? 1 : 0);
					}
					break;
				case 2:
				{
					Method method11 = (_0024_00244461_002418492 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers8 = (_0024_00244461_002418492.Modifiers = TypeMemberModifiers.Public);
					string text124 = (_0024_00244461_002418492.Name = "foo");
					TypeReference typeReference22 = (_0024_00244461_002418492.ReturnType = TypeReference.Lift(_0024compoType_002418446));
					Method method12 = _0024_00244461_002418492;
					Block block55 = (_0024_00244460_002418491 = new Block(LexicalInfo.Empty));
					Block block56 = _0024_00244460_002418491;
					Statement[] array23 = new Statement[6];
					IfStatement ifStatement22 = (_0024_00244424_002418455 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement23 = _0024_00244424_002418455;
					BinaryExpression binaryExpression55 = (_0024_00244417_002418448 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType50 = (_0024_00244417_002418448.Operator = BinaryOperatorType.Inequality);
					Expression expression142 = (_0024_00244417_002418448.Left = Expression.Lift(_0024name_002418443));
					Expression expression144 = (_0024_00244417_002418448.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression146 = (ifStatement23.Condition = _0024_00244417_002418448);
					IfStatement ifStatement24 = _0024_00244424_002418455;
					Block block57 = (_0024_00244423_002418454 = new Block(LexicalInfo.Empty));
					Block block58 = _0024_00244423_002418454;
					Statement[] array24 = new Statement[1];
					MacroStatement macroStatement15 = (_0024_00244422_002418453 = new MacroStatement(LexicalInfo.Empty));
					string text126 = (_0024_00244422_002418453.Name = "assert");
					MacroStatement macroStatement16 = _0024_00244422_002418453;
					Expression[] array25 = new Expression[1];
					BinaryExpression binaryExpression56 = (_0024_00244421_002418452 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType52 = (_0024_00244421_002418452.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression57 = _0024_00244421_002418452;
					BinaryExpression binaryExpression58 = (_0024_00244419_002418450 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType54 = (_0024_00244419_002418450.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression59 = _0024_00244419_002418450;
					StringLiteralExpression stringLiteralExpression16 = (_0024_00244418_002418449 = new StringLiteralExpression(LexicalInfo.Empty));
					string text128 = (_0024_00244418_002418449.Value = "QuestAsset: ");
					Expression expression148 = (binaryExpression59.Left = _0024_00244418_002418449);
					Expression expression150 = (_0024_00244419_002418450.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression152 = (binaryExpression57.Left = _0024_00244419_002418450);
					BinaryExpression binaryExpression60 = _0024_00244421_002418452;
					StringLiteralExpression stringLiteralExpression17 = (_0024_00244420_002418451 = new StringLiteralExpression(LexicalInfo.Empty));
					string text130 = (_0024_00244420_002418451.Value = " がnoneです。");
					Expression expression154 = (binaryExpression60.Right = _0024_00244420_002418451);
					array25[0] = _0024_00244421_002418452;
					ExpressionCollection expressionCollection22 = (macroStatement16.Arguments = ExpressionCollection.FromArray(array25));
					Block block60 = (_0024_00244422_002418453.Body = new Block(LexicalInfo.Empty));
					array24[0] = Statement.Lift(_0024_00244422_002418453);
					StatementCollection statementCollection22 = (block58.Statements = StatementCollection.FromArray(array24));
					Block block62 = (ifStatement24.TrueBlock = _0024_00244423_002418454);
					array23[0] = Statement.Lift(_0024_00244424_002418455);
					DeclarationStatement declarationStatement10 = (_0024_00244430_002418461 = new DeclarationStatement(LexicalInfo.Empty));
					DeclarationStatement declarationStatement11 = _0024_00244430_002418461;
					Declaration declaration13 = (_0024_00244426_002418457 = new Declaration(LexicalInfo.Empty));
					string text132 = (_0024_00244426_002418457.Name = "obj");
					Declaration declaration14 = _0024_00244426_002418457;
					SimpleTypeReference simpleTypeReference10 = (_0024_00244425_002418456 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag20 = (_0024_00244425_002418456.IsPointer = false);
					string text134 = (_0024_00244425_002418456.Name = "GameObject");
					TypeReference typeReference24 = (declaration14.Type = _0024_00244425_002418456);
					Declaration declaration16 = (declarationStatement11.Declaration = _0024_00244426_002418457);
					DeclarationStatement declarationStatement12 = _0024_00244430_002418461;
					MethodInvocationExpression methodInvocationExpression12 = (_0024_00244429_002418460 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression13 = _0024_00244429_002418460;
					ReferenceExpression referenceExpression17 = (_0024_00244427_002418458 = new ReferenceExpression(LexicalInfo.Empty));
					string text136 = (_0024_00244427_002418458.Name = "Instantiate");
					Expression expression156 = (methodInvocationExpression13.Target = _0024_00244427_002418458);
					MethodInvocationExpression methodInvocationExpression14 = _0024_00244429_002418460;
					Expression[] array26 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression6 = (_0024_00244428_002418459 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text138 = (_0024_00244428_002418459.Name = "gameObject");
					Expression expression158 = (_0024_00244428_002418459.Target = Expression.Lift(_0024name_002418443));
					array26[0] = _0024_00244428_002418459;
					ExpressionCollection expressionCollection24 = (methodInvocationExpression14.Arguments = ExpressionCollection.FromArray(array26));
					Expression expression160 = (declarationStatement12.Initializer = _0024_00244429_002418460);
					array23[1] = Statement.Lift(_0024_00244430_002418461);
					IfStatement ifStatement25 = (_0024_00244439_002418470 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement26 = _0024_00244439_002418470;
					BinaryExpression binaryExpression61 = (_0024_00244432_002418463 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType56 = (_0024_00244432_002418463.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression62 = _0024_00244432_002418463;
					ReferenceExpression referenceExpression18 = (_0024_00244431_002418462 = new ReferenceExpression(LexicalInfo.Empty));
					string text140 = (_0024_00244431_002418462.Name = "obj");
					Expression expression162 = (binaryExpression62.Left = _0024_00244431_002418462);
					Expression expression164 = (_0024_00244432_002418463.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression166 = (ifStatement26.Condition = _0024_00244432_002418463);
					IfStatement ifStatement27 = _0024_00244439_002418470;
					Block block63 = (_0024_00244438_002418469 = new Block(LexicalInfo.Empty));
					Block block64 = _0024_00244438_002418469;
					Statement[] array27 = new Statement[1];
					MacroStatement macroStatement17 = (_0024_00244437_002418468 = new MacroStatement(LexicalInfo.Empty));
					string text142 = (_0024_00244437_002418468.Name = "assert");
					MacroStatement macroStatement18 = _0024_00244437_002418468;
					Expression[] array28 = new Expression[1];
					BinaryExpression binaryExpression63 = (_0024_00244436_002418467 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType58 = (_0024_00244436_002418467.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression64 = _0024_00244436_002418467;
					BinaryExpression binaryExpression65 = (_0024_00244434_002418465 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType60 = (_0024_00244434_002418465.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression66 = _0024_00244434_002418465;
					StringLiteralExpression stringLiteralExpression18 = (_0024_00244433_002418464 = new StringLiteralExpression(LexicalInfo.Empty));
					string text144 = (_0024_00244433_002418464.Value = "QuestAsset: ");
					Expression expression168 = (binaryExpression66.Left = _0024_00244433_002418464);
					Expression expression170 = (_0024_00244434_002418465.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression172 = (binaryExpression64.Left = _0024_00244434_002418465);
					BinaryExpression binaryExpression67 = _0024_00244436_002418467;
					StringLiteralExpression stringLiteralExpression19 = (_0024_00244435_002418466 = new StringLiteralExpression(LexicalInfo.Empty));
					string text146 = (_0024_00244435_002418466.Value = " をinstantiateできません");
					Expression expression174 = (binaryExpression67.Right = _0024_00244435_002418466);
					array28[0] = _0024_00244436_002418467;
					ExpressionCollection expressionCollection26 = (macroStatement18.Arguments = ExpressionCollection.FromArray(array28));
					Block block66 = (_0024_00244437_002418468.Body = new Block(LexicalInfo.Empty));
					array27[0] = Statement.Lift(_0024_00244437_002418468);
					StatementCollection statementCollection24 = (block64.Statements = StatementCollection.FromArray(array27));
					Block block68 = (ifStatement27.TrueBlock = _0024_00244438_002418469);
					array23[2] = Statement.Lift(_0024_00244439_002418470);
					BinaryExpression binaryExpression68 = (_0024_00244445_002418476 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType62 = (_0024_00244445_002418476.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression69 = _0024_00244445_002418476;
					ReferenceExpression referenceExpression19 = (_0024_00244440_002418471 = new ReferenceExpression(LexicalInfo.Empty));
					string text148 = (_0024_00244440_002418471.Name = "c");
					Expression expression176 = (binaryExpression69.Left = _0024_00244440_002418471);
					BinaryExpression binaryExpression70 = _0024_00244445_002418476;
					MethodInvocationExpression methodInvocationExpression15 = (_0024_00244444_002418475 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression16 = _0024_00244444_002418475;
					GenericReferenceExpression genericReferenceExpression3 = (_0024_00244443_002418474 = new GenericReferenceExpression(LexicalInfo.Empty));
					GenericReferenceExpression genericReferenceExpression4 = _0024_00244443_002418474;
					MemberReferenceExpression memberReferenceExpression7 = (_0024_00244442_002418473 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text150 = (_0024_00244442_002418473.Name = "SetComponent");
					MemberReferenceExpression memberReferenceExpression8 = _0024_00244442_002418473;
					ReferenceExpression referenceExpression20 = (_0024_00244441_002418472 = new ReferenceExpression(LexicalInfo.Empty));
					string text152 = (_0024_00244441_002418472.Name = "obj");
					Expression expression178 = (memberReferenceExpression8.Target = _0024_00244441_002418472);
					Expression expression180 = (genericReferenceExpression4.Target = _0024_00244442_002418473);
					TypeReferenceCollection typeReferenceCollection4 = (_0024_00244443_002418474.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024compoType_002418446)));
					Expression expression182 = (methodInvocationExpression16.Target = _0024_00244443_002418474);
					Expression expression184 = (binaryExpression70.Right = _0024_00244444_002418475);
					array23[3] = Statement.Lift(_0024_00244445_002418476);
					IfStatement ifStatement28 = (_0024_00244457_002418488 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement29 = _0024_00244457_002418488;
					BinaryExpression binaryExpression71 = (_0024_00244447_002418478 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType64 = (_0024_00244447_002418478.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression72 = _0024_00244447_002418478;
					ReferenceExpression referenceExpression21 = (_0024_00244446_002418477 = new ReferenceExpression(LexicalInfo.Empty));
					string text154 = (_0024_00244446_002418477.Name = "c");
					Expression expression186 = (binaryExpression72.Left = _0024_00244446_002418477);
					Expression expression188 = (_0024_00244447_002418478.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression190 = (ifStatement29.Condition = _0024_00244447_002418478);
					IfStatement ifStatement30 = _0024_00244457_002418488;
					Block block69 = (_0024_00244456_002418487 = new Block(LexicalInfo.Empty));
					Block block70 = _0024_00244456_002418487;
					Statement[] array29 = new Statement[1];
					MacroStatement macroStatement19 = (_0024_00244455_002418486 = new MacroStatement(LexicalInfo.Empty));
					string text156 = (_0024_00244455_002418486.Name = "assert");
					MacroStatement macroStatement20 = _0024_00244455_002418486;
					Expression[] array30 = new Expression[1];
					BinaryExpression binaryExpression73 = (_0024_00244454_002418485 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType66 = (_0024_00244454_002418485.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression74 = _0024_00244454_002418485;
					BinaryExpression binaryExpression75 = (_0024_00244452_002418483 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType68 = (_0024_00244452_002418483.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression76 = _0024_00244452_002418483;
					BinaryExpression binaryExpression77 = (_0024_00244451_002418482 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType70 = (_0024_00244451_002418482.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression78 = _0024_00244451_002418482;
					BinaryExpression binaryExpression79 = (_0024_00244449_002418480 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType72 = (_0024_00244449_002418480.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression80 = _0024_00244449_002418480;
					StringLiteralExpression stringLiteralExpression20 = (_0024_00244448_002418479 = new StringLiteralExpression(LexicalInfo.Empty));
					string text158 = (_0024_00244448_002418479.Value = "QuestAsset: ");
					Expression expression192 = (binaryExpression80.Left = _0024_00244448_002418479);
					Expression expression194 = (_0024_00244449_002418480.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression196 = (binaryExpression78.Left = _0024_00244449_002418480);
					BinaryExpression binaryExpression81 = _0024_00244451_002418482;
					StringLiteralExpression stringLiteralExpression21 = (_0024_00244450_002418481 = new StringLiteralExpression(LexicalInfo.Empty));
					string text160 = (_0024_00244450_002418481.Value = " に");
					Expression expression198 = (binaryExpression81.Right = _0024_00244450_002418481);
					Expression expression200 = (binaryExpression76.Left = _0024_00244451_002418482);
					Expression expression202 = (_0024_00244452_002418483.Right = Expression.Lift(_0024compoType_002418446.Name));
					Expression expression204 = (binaryExpression74.Left = _0024_00244452_002418483);
					BinaryExpression binaryExpression82 = _0024_00244454_002418485;
					StringLiteralExpression stringLiteralExpression22 = (_0024_00244453_002418484 = new StringLiteralExpression(LexicalInfo.Empty));
					string text162 = (_0024_00244453_002418484.Value = "を貼れません");
					Expression expression206 = (binaryExpression82.Right = _0024_00244453_002418484);
					array30[0] = _0024_00244454_002418485;
					ExpressionCollection expressionCollection28 = (macroStatement20.Arguments = ExpressionCollection.FromArray(array30));
					Block block72 = (_0024_00244455_002418486.Body = new Block(LexicalInfo.Empty));
					array29[0] = Statement.Lift(_0024_00244455_002418486);
					StatementCollection statementCollection26 = (block70.Statements = StatementCollection.FromArray(array29));
					Block block74 = (ifStatement30.TrueBlock = _0024_00244456_002418487);
					array23[4] = Statement.Lift(_0024_00244457_002418488);
					ReturnStatement returnStatement7 = (_0024_00244459_002418490 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement8 = _0024_00244459_002418490;
					ReferenceExpression referenceExpression22 = (_0024_00244458_002418489 = new ReferenceExpression(LexicalInfo.Empty));
					string text164 = (_0024_00244458_002418489.Name = "c");
					Expression expression208 = (returnStatement8.Expression = _0024_00244458_002418489);
					array23[5] = Statement.Lift(_0024_00244459_002418490);
					StatementCollection statementCollection28 = (block56.Statements = StatementCollection.FromArray(array23));
					Block block76 = (method12.Body = _0024_00244460_002418491);
					_0024m1_002418493 = _0024_00244461_002418492;
					_0024m1_002418493.Name = _0024methodName_002418444.Name;
					result = (Yield(3, _0024m1_002418493) ? 1 : 0);
					break;
				}
				case 3:
				{
					Method method8 = (_0024_00244512_002418544 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers6 = (_0024_00244512_002418544.Modifiers = TypeMemberModifiers.Public);
					string text70 = (_0024_00244512_002418544.Name = "foo");
					Method method9 = _0024_00244512_002418544;
					ParameterDeclaration[] array14 = new ParameterDeclaration[2];
					ParameterDeclaration parameterDeclaration5 = (_0024_00244463_002418495 = new ParameterDeclaration(LexicalInfo.Empty));
					string text72 = (_0024_00244463_002418495.Name = "position");
					ParameterDeclaration parameterDeclaration6 = _0024_00244463_002418495;
					SimpleTypeReference simpleTypeReference7 = (_0024_00244462_002418494 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag14 = (_0024_00244462_002418494.IsPointer = false);
					string text74 = (_0024_00244462_002418494.Name = "Vector3");
					TypeReference typeReference14 = (parameterDeclaration6.Type = _0024_00244462_002418494);
					array14[0] = _0024_00244463_002418495;
					ParameterDeclaration parameterDeclaration7 = (_0024_00244465_002418497 = new ParameterDeclaration(LexicalInfo.Empty));
					string text76 = (_0024_00244465_002418497.Name = "rotation");
					ParameterDeclaration parameterDeclaration8 = _0024_00244465_002418497;
					SimpleTypeReference simpleTypeReference8 = (_0024_00244464_002418496 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag16 = (_0024_00244464_002418496.IsPointer = false);
					string text78 = (_0024_00244464_002418496.Name = "Quaternion");
					TypeReference typeReference16 = (parameterDeclaration8.Type = _0024_00244464_002418496);
					array14[1] = _0024_00244465_002418497;
					ParameterDeclarationCollection parameterDeclarationCollection4 = (method9.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array14));
					TypeReference typeReference18 = (_0024_00244512_002418544.ReturnType = TypeReference.Lift(_0024compoType_002418446));
					Method method10 = _0024_00244512_002418544;
					Block block33 = (_0024_00244511_002418543 = new Block(LexicalInfo.Empty));
					Block block34 = _0024_00244511_002418543;
					Statement[] array15 = new Statement[6];
					IfStatement ifStatement13 = (_0024_00244473_002418505 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement14 = _0024_00244473_002418505;
					BinaryExpression binaryExpression27 = (_0024_00244466_002418498 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType26 = (_0024_00244466_002418498.Operator = BinaryOperatorType.Inequality);
					Expression expression74 = (_0024_00244466_002418498.Left = Expression.Lift(_0024name_002418443));
					Expression expression76 = (_0024_00244466_002418498.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression78 = (ifStatement14.Condition = _0024_00244466_002418498);
					IfStatement ifStatement15 = _0024_00244473_002418505;
					Block block35 = (_0024_00244472_002418504 = new Block(LexicalInfo.Empty));
					Block block36 = _0024_00244472_002418504;
					Statement[] array16 = new Statement[1];
					MacroStatement macroStatement9 = (_0024_00244471_002418503 = new MacroStatement(LexicalInfo.Empty));
					string text80 = (_0024_00244471_002418503.Name = "assert");
					MacroStatement macroStatement10 = _0024_00244471_002418503;
					Expression[] array17 = new Expression[1];
					BinaryExpression binaryExpression28 = (_0024_00244470_002418502 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType28 = (_0024_00244470_002418502.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression29 = _0024_00244470_002418502;
					BinaryExpression binaryExpression30 = (_0024_00244468_002418500 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType30 = (_0024_00244468_002418500.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression31 = _0024_00244468_002418500;
					StringLiteralExpression stringLiteralExpression9 = (_0024_00244467_002418499 = new StringLiteralExpression(LexicalInfo.Empty));
					string text82 = (_0024_00244467_002418499.Value = "QuestAsset: ");
					Expression expression80 = (binaryExpression31.Left = _0024_00244467_002418499);
					Expression expression82 = (_0024_00244468_002418500.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression84 = (binaryExpression29.Left = _0024_00244468_002418500);
					BinaryExpression binaryExpression32 = _0024_00244470_002418502;
					StringLiteralExpression stringLiteralExpression10 = (_0024_00244469_002418501 = new StringLiteralExpression(LexicalInfo.Empty));
					string text84 = (_0024_00244469_002418501.Value = " がnoneです。");
					Expression expression86 = (binaryExpression32.Right = _0024_00244469_002418501);
					array17[0] = _0024_00244470_002418502;
					ExpressionCollection expressionCollection14 = (macroStatement10.Arguments = ExpressionCollection.FromArray(array17));
					Block block38 = (_0024_00244471_002418503.Body = new Block(LexicalInfo.Empty));
					array16[0] = Statement.Lift(_0024_00244471_002418503);
					StatementCollection statementCollection14 = (block36.Statements = StatementCollection.FromArray(array16));
					Block block40 = (ifStatement15.TrueBlock = _0024_00244472_002418504);
					array15[0] = Statement.Lift(_0024_00244473_002418505);
					DeclarationStatement declarationStatement7 = (_0024_00244481_002418513 = new DeclarationStatement(LexicalInfo.Empty));
					DeclarationStatement declarationStatement8 = _0024_00244481_002418513;
					Declaration declaration9 = (_0024_00244475_002418507 = new Declaration(LexicalInfo.Empty));
					string text86 = (_0024_00244475_002418507.Name = "obj");
					Declaration declaration10 = _0024_00244475_002418507;
					SimpleTypeReference simpleTypeReference9 = (_0024_00244474_002418506 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag18 = (_0024_00244474_002418506.IsPointer = false);
					string text88 = (_0024_00244474_002418506.Name = "GameObject");
					TypeReference typeReference20 = (declaration10.Type = _0024_00244474_002418506);
					Declaration declaration12 = (declarationStatement8.Declaration = _0024_00244475_002418507);
					DeclarationStatement declarationStatement9 = _0024_00244481_002418513;
					MethodInvocationExpression methodInvocationExpression7 = (_0024_00244480_002418512 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression8 = _0024_00244480_002418512;
					ReferenceExpression referenceExpression9 = (_0024_00244476_002418508 = new ReferenceExpression(LexicalInfo.Empty));
					string text90 = (_0024_00244476_002418508.Name = "Instantiate");
					Expression expression88 = (methodInvocationExpression8.Target = _0024_00244476_002418508);
					MethodInvocationExpression methodInvocationExpression9 = _0024_00244480_002418512;
					Expression[] array18 = new Expression[3];
					MemberReferenceExpression memberReferenceExpression3 = (_0024_00244477_002418509 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text92 = (_0024_00244477_002418509.Name = "gameObject");
					Expression expression90 = (_0024_00244477_002418509.Target = Expression.Lift(_0024name_002418443));
					array18[0] = _0024_00244477_002418509;
					ReferenceExpression referenceExpression10 = (_0024_00244478_002418510 = new ReferenceExpression(LexicalInfo.Empty));
					string text94 = (_0024_00244478_002418510.Name = "position");
					array18[1] = _0024_00244478_002418510;
					ReferenceExpression referenceExpression11 = (_0024_00244479_002418511 = new ReferenceExpression(LexicalInfo.Empty));
					string text96 = (_0024_00244479_002418511.Name = "rotation");
					array18[2] = _0024_00244479_002418511;
					ExpressionCollection expressionCollection16 = (methodInvocationExpression9.Arguments = ExpressionCollection.FromArray(array18));
					Expression expression92 = (declarationStatement9.Initializer = _0024_00244480_002418512);
					array15[1] = Statement.Lift(_0024_00244481_002418513);
					IfStatement ifStatement16 = (_0024_00244490_002418522 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement17 = _0024_00244490_002418522;
					BinaryExpression binaryExpression33 = (_0024_00244483_002418515 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType32 = (_0024_00244483_002418515.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression34 = _0024_00244483_002418515;
					ReferenceExpression referenceExpression12 = (_0024_00244482_002418514 = new ReferenceExpression(LexicalInfo.Empty));
					string text98 = (_0024_00244482_002418514.Name = "obj");
					Expression expression94 = (binaryExpression34.Left = _0024_00244482_002418514);
					Expression expression96 = (_0024_00244483_002418515.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression98 = (ifStatement17.Condition = _0024_00244483_002418515);
					IfStatement ifStatement18 = _0024_00244490_002418522;
					Block block41 = (_0024_00244489_002418521 = new Block(LexicalInfo.Empty));
					Block block42 = _0024_00244489_002418521;
					Statement[] array19 = new Statement[1];
					MacroStatement macroStatement11 = (_0024_00244488_002418520 = new MacroStatement(LexicalInfo.Empty));
					string text100 = (_0024_00244488_002418520.Name = "assert");
					MacroStatement macroStatement12 = _0024_00244488_002418520;
					Expression[] array20 = new Expression[1];
					BinaryExpression binaryExpression35 = (_0024_00244487_002418519 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType34 = (_0024_00244487_002418519.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression36 = _0024_00244487_002418519;
					BinaryExpression binaryExpression37 = (_0024_00244485_002418517 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType36 = (_0024_00244485_002418517.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression38 = _0024_00244485_002418517;
					StringLiteralExpression stringLiteralExpression11 = (_0024_00244484_002418516 = new StringLiteralExpression(LexicalInfo.Empty));
					string text102 = (_0024_00244484_002418516.Value = "QuestAsset: ");
					Expression expression100 = (binaryExpression38.Left = _0024_00244484_002418516);
					Expression expression102 = (_0024_00244485_002418517.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression104 = (binaryExpression36.Left = _0024_00244485_002418517);
					BinaryExpression binaryExpression39 = _0024_00244487_002418519;
					StringLiteralExpression stringLiteralExpression12 = (_0024_00244486_002418518 = new StringLiteralExpression(LexicalInfo.Empty));
					string text104 = (_0024_00244486_002418518.Value = " をinstantiateできません");
					Expression expression106 = (binaryExpression39.Right = _0024_00244486_002418518);
					array20[0] = _0024_00244487_002418519;
					ExpressionCollection expressionCollection18 = (macroStatement12.Arguments = ExpressionCollection.FromArray(array20));
					Block block44 = (_0024_00244488_002418520.Body = new Block(LexicalInfo.Empty));
					array19[0] = Statement.Lift(_0024_00244488_002418520);
					StatementCollection statementCollection16 = (block42.Statements = StatementCollection.FromArray(array19));
					Block block46 = (ifStatement18.TrueBlock = _0024_00244489_002418521);
					array15[2] = Statement.Lift(_0024_00244490_002418522);
					BinaryExpression binaryExpression40 = (_0024_00244496_002418528 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType38 = (_0024_00244496_002418528.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression41 = _0024_00244496_002418528;
					ReferenceExpression referenceExpression13 = (_0024_00244491_002418523 = new ReferenceExpression(LexicalInfo.Empty));
					string text106 = (_0024_00244491_002418523.Name = "c");
					Expression expression108 = (binaryExpression41.Left = _0024_00244491_002418523);
					BinaryExpression binaryExpression42 = _0024_00244496_002418528;
					MethodInvocationExpression methodInvocationExpression10 = (_0024_00244495_002418527 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression11 = _0024_00244495_002418527;
					GenericReferenceExpression genericReferenceExpression = (_0024_00244494_002418526 = new GenericReferenceExpression(LexicalInfo.Empty));
					GenericReferenceExpression genericReferenceExpression2 = _0024_00244494_002418526;
					MemberReferenceExpression memberReferenceExpression4 = (_0024_00244493_002418525 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text108 = (_0024_00244493_002418525.Name = "SetComponent");
					MemberReferenceExpression memberReferenceExpression5 = _0024_00244493_002418525;
					ReferenceExpression referenceExpression14 = (_0024_00244492_002418524 = new ReferenceExpression(LexicalInfo.Empty));
					string text110 = (_0024_00244492_002418524.Name = "obj");
					Expression expression110 = (memberReferenceExpression5.Target = _0024_00244492_002418524);
					Expression expression112 = (genericReferenceExpression2.Target = _0024_00244493_002418525);
					TypeReferenceCollection typeReferenceCollection2 = (_0024_00244494_002418526.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024compoType_002418446)));
					Expression expression114 = (methodInvocationExpression11.Target = _0024_00244494_002418526);
					Expression expression116 = (binaryExpression42.Right = _0024_00244495_002418527);
					array15[3] = Statement.Lift(_0024_00244496_002418528);
					IfStatement ifStatement19 = (_0024_00244508_002418540 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement20 = _0024_00244508_002418540;
					BinaryExpression binaryExpression43 = (_0024_00244498_002418530 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType40 = (_0024_00244498_002418530.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression44 = _0024_00244498_002418530;
					ReferenceExpression referenceExpression15 = (_0024_00244497_002418529 = new ReferenceExpression(LexicalInfo.Empty));
					string text112 = (_0024_00244497_002418529.Name = "c");
					Expression expression118 = (binaryExpression44.Left = _0024_00244497_002418529);
					Expression expression120 = (_0024_00244498_002418530.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression122 = (ifStatement20.Condition = _0024_00244498_002418530);
					IfStatement ifStatement21 = _0024_00244508_002418540;
					Block block47 = (_0024_00244507_002418539 = new Block(LexicalInfo.Empty));
					Block block48 = _0024_00244507_002418539;
					Statement[] array21 = new Statement[1];
					MacroStatement macroStatement13 = (_0024_00244506_002418538 = new MacroStatement(LexicalInfo.Empty));
					string text114 = (_0024_00244506_002418538.Name = "assert");
					MacroStatement macroStatement14 = _0024_00244506_002418538;
					Expression[] array22 = new Expression[1];
					BinaryExpression binaryExpression45 = (_0024_00244505_002418537 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType42 = (_0024_00244505_002418537.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression46 = _0024_00244505_002418537;
					BinaryExpression binaryExpression47 = (_0024_00244503_002418535 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType44 = (_0024_00244503_002418535.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression48 = _0024_00244503_002418535;
					BinaryExpression binaryExpression49 = (_0024_00244502_002418534 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType46 = (_0024_00244502_002418534.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression50 = _0024_00244502_002418534;
					BinaryExpression binaryExpression51 = (_0024_00244500_002418532 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType48 = (_0024_00244500_002418532.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression52 = _0024_00244500_002418532;
					StringLiteralExpression stringLiteralExpression13 = (_0024_00244499_002418531 = new StringLiteralExpression(LexicalInfo.Empty));
					string text116 = (_0024_00244499_002418531.Value = "QuestAsset: ");
					Expression expression124 = (binaryExpression52.Left = _0024_00244499_002418531);
					Expression expression126 = (_0024_00244500_002418532.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression128 = (binaryExpression50.Left = _0024_00244500_002418532);
					BinaryExpression binaryExpression53 = _0024_00244502_002418534;
					StringLiteralExpression stringLiteralExpression14 = (_0024_00244501_002418533 = new StringLiteralExpression(LexicalInfo.Empty));
					string text118 = (_0024_00244501_002418533.Value = " に");
					Expression expression130 = (binaryExpression53.Right = _0024_00244501_002418533);
					Expression expression132 = (binaryExpression48.Left = _0024_00244502_002418534);
					Expression expression134 = (_0024_00244503_002418535.Right = Expression.Lift(_0024compoType_002418446.Name));
					Expression expression136 = (binaryExpression46.Left = _0024_00244503_002418535);
					BinaryExpression binaryExpression54 = _0024_00244505_002418537;
					StringLiteralExpression stringLiteralExpression15 = (_0024_00244504_002418536 = new StringLiteralExpression(LexicalInfo.Empty));
					string text120 = (_0024_00244504_002418536.Value = "を貼れません");
					Expression expression138 = (binaryExpression54.Right = _0024_00244504_002418536);
					array22[0] = _0024_00244505_002418537;
					ExpressionCollection expressionCollection20 = (macroStatement14.Arguments = ExpressionCollection.FromArray(array22));
					Block block50 = (_0024_00244506_002418538.Body = new Block(LexicalInfo.Empty));
					array21[0] = Statement.Lift(_0024_00244506_002418538);
					StatementCollection statementCollection18 = (block48.Statements = StatementCollection.FromArray(array21));
					Block block52 = (ifStatement21.TrueBlock = _0024_00244507_002418539);
					array15[4] = Statement.Lift(_0024_00244508_002418540);
					ReturnStatement returnStatement5 = (_0024_00244510_002418542 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement6 = _0024_00244510_002418542;
					ReferenceExpression referenceExpression16 = (_0024_00244509_002418541 = new ReferenceExpression(LexicalInfo.Empty));
					string text122 = (_0024_00244509_002418541.Name = "c");
					Expression expression140 = (returnStatement6.Expression = _0024_00244509_002418541);
					array15[5] = Statement.Lift(_0024_00244510_002418542);
					StatementCollection statementCollection20 = (block34.Statements = StatementCollection.FromArray(array15));
					Block block54 = (method10.Body = _0024_00244511_002418543);
					_0024m2_002418545 = _0024_00244512_002418544;
					_0024m2_002418545.Name = _0024methodName_002418444.Name;
					result = (Yield(4, _0024m2_002418545) ? 1 : 0);
					break;
				}
				case 5:
				{
					Method method5 = (_0024_00244542_002418575 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers4 = (_0024_00244542_002418575.Modifiers = TypeMemberModifiers.Public);
					string text42 = (_0024_00244542_002418575.Name = "foo");
					Method method6 = _0024_00244542_002418575;
					SimpleTypeReference simpleTypeReference5 = (_0024_00244515_002418548 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag10 = (_0024_00244515_002418548.IsPointer = false);
					string text44 = (_0024_00244515_002418548.Name = "GameObject");
					TypeReference typeReference10 = (method6.ReturnType = _0024_00244515_002418548);
					Method method7 = _0024_00244542_002418575;
					Block block17 = (_0024_00244541_002418574 = new Block(LexicalInfo.Empty));
					Block block18 = _0024_00244541_002418574;
					Statement[] array8 = new Statement[4];
					IfStatement ifStatement7 = (_0024_00244523_002418556 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement8 = _0024_00244523_002418556;
					BinaryExpression binaryExpression14 = (_0024_00244516_002418549 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType14 = (_0024_00244516_002418549.Operator = BinaryOperatorType.Inequality);
					Expression expression38 = (_0024_00244516_002418549.Left = Expression.Lift(_0024name_002418443));
					Expression expression40 = (_0024_00244516_002418549.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression42 = (ifStatement8.Condition = _0024_00244516_002418549);
					IfStatement ifStatement9 = _0024_00244523_002418556;
					Block block19 = (_0024_00244522_002418555 = new Block(LexicalInfo.Empty));
					Block block20 = _0024_00244522_002418555;
					Statement[] array9 = new Statement[1];
					MacroStatement macroStatement5 = (_0024_00244521_002418554 = new MacroStatement(LexicalInfo.Empty));
					string text46 = (_0024_00244521_002418554.Name = "assert");
					MacroStatement macroStatement6 = _0024_00244521_002418554;
					Expression[] array10 = new Expression[1];
					BinaryExpression binaryExpression15 = (_0024_00244520_002418553 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType16 = (_0024_00244520_002418553.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression16 = _0024_00244520_002418553;
					BinaryExpression binaryExpression17 = (_0024_00244518_002418551 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType18 = (_0024_00244518_002418551.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression18 = _0024_00244518_002418551;
					StringLiteralExpression stringLiteralExpression5 = (_0024_00244517_002418550 = new StringLiteralExpression(LexicalInfo.Empty));
					string text48 = (_0024_00244517_002418550.Value = "QuestAsset: ");
					Expression expression44 = (binaryExpression18.Left = _0024_00244517_002418550);
					Expression expression46 = (_0024_00244518_002418551.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression48 = (binaryExpression16.Left = _0024_00244518_002418551);
					BinaryExpression binaryExpression19 = _0024_00244520_002418553;
					StringLiteralExpression stringLiteralExpression6 = (_0024_00244519_002418552 = new StringLiteralExpression(LexicalInfo.Empty));
					string text50 = (_0024_00244519_002418552.Value = " がnoneです。");
					Expression expression50 = (binaryExpression19.Right = _0024_00244519_002418552);
					array10[0] = _0024_00244520_002418553;
					ExpressionCollection expressionCollection8 = (macroStatement6.Arguments = ExpressionCollection.FromArray(array10));
					Block block22 = (_0024_00244521_002418554.Body = new Block(LexicalInfo.Empty));
					array9[0] = Statement.Lift(_0024_00244521_002418554);
					StatementCollection statementCollection8 = (block20.Statements = StatementCollection.FromArray(array9));
					Block block24 = (ifStatement9.TrueBlock = _0024_00244522_002418555);
					array8[0] = Statement.Lift(_0024_00244523_002418556);
					DeclarationStatement declarationStatement4 = (_0024_00244529_002418562 = new DeclarationStatement(LexicalInfo.Empty));
					DeclarationStatement declarationStatement5 = _0024_00244529_002418562;
					Declaration declaration5 = (_0024_00244525_002418558 = new Declaration(LexicalInfo.Empty));
					string text52 = (_0024_00244525_002418558.Name = "obj");
					Declaration declaration6 = _0024_00244525_002418558;
					SimpleTypeReference simpleTypeReference6 = (_0024_00244524_002418557 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag12 = (_0024_00244524_002418557.IsPointer = false);
					string text54 = (_0024_00244524_002418557.Name = "GameObject");
					TypeReference typeReference12 = (declaration6.Type = _0024_00244524_002418557);
					Declaration declaration8 = (declarationStatement5.Declaration = _0024_00244525_002418558);
					DeclarationStatement declarationStatement6 = _0024_00244529_002418562;
					MethodInvocationExpression methodInvocationExpression4 = (_0024_00244528_002418561 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression5 = _0024_00244528_002418561;
					ReferenceExpression referenceExpression6 = (_0024_00244526_002418559 = new ReferenceExpression(LexicalInfo.Empty));
					string text56 = (_0024_00244526_002418559.Name = "Instantiate");
					Expression expression52 = (methodInvocationExpression5.Target = _0024_00244526_002418559);
					MethodInvocationExpression methodInvocationExpression6 = _0024_00244528_002418561;
					Expression[] array11 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression2 = (_0024_00244527_002418560 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text58 = (_0024_00244527_002418560.Name = "gameObject");
					Expression expression54 = (_0024_00244527_002418560.Target = Expression.Lift(_0024name_002418443));
					array11[0] = _0024_00244527_002418560;
					ExpressionCollection expressionCollection10 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array11));
					Expression expression56 = (declarationStatement6.Initializer = _0024_00244528_002418561);
					array8[1] = Statement.Lift(_0024_00244529_002418562);
					IfStatement ifStatement10 = (_0024_00244538_002418571 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement11 = _0024_00244538_002418571;
					BinaryExpression binaryExpression20 = (_0024_00244531_002418564 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType20 = (_0024_00244531_002418564.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression21 = _0024_00244531_002418564;
					ReferenceExpression referenceExpression7 = (_0024_00244530_002418563 = new ReferenceExpression(LexicalInfo.Empty));
					string text60 = (_0024_00244530_002418563.Name = "obj");
					Expression expression58 = (binaryExpression21.Left = _0024_00244530_002418563);
					Expression expression60 = (_0024_00244531_002418564.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression62 = (ifStatement11.Condition = _0024_00244531_002418564);
					IfStatement ifStatement12 = _0024_00244538_002418571;
					Block block25 = (_0024_00244537_002418570 = new Block(LexicalInfo.Empty));
					Block block26 = _0024_00244537_002418570;
					Statement[] array12 = new Statement[1];
					MacroStatement macroStatement7 = (_0024_00244536_002418569 = new MacroStatement(LexicalInfo.Empty));
					string text62 = (_0024_00244536_002418569.Name = "assert");
					MacroStatement macroStatement8 = _0024_00244536_002418569;
					Expression[] array13 = new Expression[1];
					BinaryExpression binaryExpression22 = (_0024_00244535_002418568 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType22 = (_0024_00244535_002418568.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression23 = _0024_00244535_002418568;
					BinaryExpression binaryExpression24 = (_0024_00244533_002418566 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType24 = (_0024_00244533_002418566.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression25 = _0024_00244533_002418566;
					StringLiteralExpression stringLiteralExpression7 = (_0024_00244532_002418565 = new StringLiteralExpression(LexicalInfo.Empty));
					string text64 = (_0024_00244532_002418565.Value = "QuestAsset: ");
					Expression expression64 = (binaryExpression25.Left = _0024_00244532_002418565);
					Expression expression66 = (_0024_00244533_002418566.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression68 = (binaryExpression23.Left = _0024_00244533_002418566);
					BinaryExpression binaryExpression26 = _0024_00244535_002418568;
					StringLiteralExpression stringLiteralExpression8 = (_0024_00244534_002418567 = new StringLiteralExpression(LexicalInfo.Empty));
					string text66 = (_0024_00244534_002418567.Value = " をinstantiateできません");
					Expression expression70 = (binaryExpression26.Right = _0024_00244534_002418567);
					array13[0] = _0024_00244535_002418568;
					ExpressionCollection expressionCollection12 = (macroStatement8.Arguments = ExpressionCollection.FromArray(array13));
					Block block28 = (_0024_00244536_002418569.Body = new Block(LexicalInfo.Empty));
					array12[0] = Statement.Lift(_0024_00244536_002418569);
					StatementCollection statementCollection10 = (block26.Statements = StatementCollection.FromArray(array12));
					Block block30 = (ifStatement12.TrueBlock = _0024_00244537_002418570);
					array8[2] = Statement.Lift(_0024_00244538_002418571);
					ReturnStatement returnStatement3 = (_0024_00244540_002418573 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement4 = _0024_00244540_002418573;
					ReferenceExpression referenceExpression8 = (_0024_00244539_002418572 = new ReferenceExpression(LexicalInfo.Empty));
					string text68 = (_0024_00244539_002418572.Name = "obj");
					Expression expression72 = (returnStatement4.Expression = _0024_00244539_002418572);
					array8[3] = Statement.Lift(_0024_00244540_002418573);
					StatementCollection statementCollection12 = (block18.Statements = StatementCollection.FromArray(array8));
					Block block32 = (method7.Body = _0024_00244541_002418574);
					_0024m3_002418576 = _0024_00244542_002418575;
					_0024m3_002418576.Name = _0024methodName_002418444.Name;
					result = (Yield(6, _0024m3_002418576) ? 1 : 0);
					break;
				}
				case 6:
				{
					Method method = (_0024_00244576_002418610 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers2 = (_0024_00244576_002418610.Modifiers = TypeMemberModifiers.Public);
					string text2 = (_0024_00244576_002418610.Name = "foo");
					Method method2 = _0024_00244576_002418610;
					ParameterDeclaration[] array = new ParameterDeclaration[2];
					ParameterDeclaration parameterDeclaration = (_0024_00244544_002418578 = new ParameterDeclaration(LexicalInfo.Empty));
					string text4 = (_0024_00244544_002418578.Name = "position");
					ParameterDeclaration parameterDeclaration2 = _0024_00244544_002418578;
					SimpleTypeReference simpleTypeReference = (_0024_00244543_002418577 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag2 = (_0024_00244543_002418577.IsPointer = false);
					string text6 = (_0024_00244543_002418577.Name = "Vector3");
					TypeReference typeReference2 = (parameterDeclaration2.Type = _0024_00244543_002418577);
					array[0] = _0024_00244544_002418578;
					ParameterDeclaration parameterDeclaration3 = (_0024_00244546_002418580 = new ParameterDeclaration(LexicalInfo.Empty));
					string text8 = (_0024_00244546_002418580.Name = "rotation");
					ParameterDeclaration parameterDeclaration4 = _0024_00244546_002418580;
					SimpleTypeReference simpleTypeReference2 = (_0024_00244545_002418579 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag4 = (_0024_00244545_002418579.IsPointer = false);
					string text10 = (_0024_00244545_002418579.Name = "Quaternion");
					TypeReference typeReference4 = (parameterDeclaration4.Type = _0024_00244545_002418579);
					array[1] = _0024_00244546_002418580;
					ParameterDeclarationCollection parameterDeclarationCollection2 = (method2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array));
					Method method3 = _0024_00244576_002418610;
					SimpleTypeReference simpleTypeReference3 = (_0024_00244547_002418581 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag6 = (_0024_00244547_002418581.IsPointer = false);
					string text12 = (_0024_00244547_002418581.Name = "GameObject");
					TypeReference typeReference6 = (method3.ReturnType = _0024_00244547_002418581);
					Method method4 = _0024_00244576_002418610;
					Block block = (_0024_00244575_002418609 = new Block(LexicalInfo.Empty));
					Block block2 = _0024_00244575_002418609;
					Statement[] array2 = new Statement[4];
					IfStatement ifStatement = (_0024_00244555_002418589 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement2 = _0024_00244555_002418589;
					BinaryExpression binaryExpression = (_0024_00244548_002418582 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType2 = (_0024_00244548_002418582.Operator = BinaryOperatorType.Inequality);
					Expression expression2 = (_0024_00244548_002418582.Left = Expression.Lift(_0024name_002418443));
					Expression expression4 = (_0024_00244548_002418582.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression6 = (ifStatement2.Condition = _0024_00244548_002418582);
					IfStatement ifStatement3 = _0024_00244555_002418589;
					Block block3 = (_0024_00244554_002418588 = new Block(LexicalInfo.Empty));
					Block block4 = _0024_00244554_002418588;
					Statement[] array3 = new Statement[1];
					MacroStatement macroStatement = (_0024_00244553_002418587 = new MacroStatement(LexicalInfo.Empty));
					string text14 = (_0024_00244553_002418587.Name = "assert");
					MacroStatement macroStatement2 = _0024_00244553_002418587;
					Expression[] array4 = new Expression[1];
					BinaryExpression binaryExpression2 = (_0024_00244552_002418586 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType4 = (_0024_00244552_002418586.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression3 = _0024_00244552_002418586;
					BinaryExpression binaryExpression4 = (_0024_00244550_002418584 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType6 = (_0024_00244550_002418584.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression5 = _0024_00244550_002418584;
					StringLiteralExpression stringLiteralExpression = (_0024_00244549_002418583 = new StringLiteralExpression(LexicalInfo.Empty));
					string text16 = (_0024_00244549_002418583.Value = "QuestAsset: ");
					Expression expression8 = (binaryExpression5.Left = _0024_00244549_002418583);
					Expression expression10 = (_0024_00244550_002418584.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression12 = (binaryExpression3.Left = _0024_00244550_002418584);
					BinaryExpression binaryExpression6 = _0024_00244552_002418586;
					StringLiteralExpression stringLiteralExpression2 = (_0024_00244551_002418585 = new StringLiteralExpression(LexicalInfo.Empty));
					string text18 = (_0024_00244551_002418585.Value = " がnoneです。");
					Expression expression14 = (binaryExpression6.Right = _0024_00244551_002418585);
					array4[0] = _0024_00244552_002418586;
					ExpressionCollection expressionCollection2 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array4));
					Block block6 = (_0024_00244553_002418587.Body = new Block(LexicalInfo.Empty));
					array3[0] = Statement.Lift(_0024_00244553_002418587);
					StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array3));
					Block block8 = (ifStatement3.TrueBlock = _0024_00244554_002418588);
					array2[0] = Statement.Lift(_0024_00244555_002418589);
					DeclarationStatement declarationStatement = (_0024_00244563_002418597 = new DeclarationStatement(LexicalInfo.Empty));
					DeclarationStatement declarationStatement2 = _0024_00244563_002418597;
					Declaration declaration = (_0024_00244557_002418591 = new Declaration(LexicalInfo.Empty));
					string text20 = (_0024_00244557_002418591.Name = "obj");
					Declaration declaration2 = _0024_00244557_002418591;
					SimpleTypeReference simpleTypeReference4 = (_0024_00244556_002418590 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag8 = (_0024_00244556_002418590.IsPointer = false);
					string text22 = (_0024_00244556_002418590.Name = "GameObject");
					TypeReference typeReference8 = (declaration2.Type = _0024_00244556_002418590);
					Declaration declaration4 = (declarationStatement2.Declaration = _0024_00244557_002418591);
					DeclarationStatement declarationStatement3 = _0024_00244563_002418597;
					MethodInvocationExpression methodInvocationExpression = (_0024_00244562_002418596 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression2 = _0024_00244562_002418596;
					ReferenceExpression referenceExpression = (_0024_00244558_002418592 = new ReferenceExpression(LexicalInfo.Empty));
					string text24 = (_0024_00244558_002418592.Name = "Instantiate");
					Expression expression16 = (methodInvocationExpression2.Target = _0024_00244558_002418592);
					MethodInvocationExpression methodInvocationExpression3 = _0024_00244562_002418596;
					Expression[] array5 = new Expression[3];
					MemberReferenceExpression memberReferenceExpression = (_0024_00244559_002418593 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text26 = (_0024_00244559_002418593.Name = "gameObject");
					Expression expression18 = (_0024_00244559_002418593.Target = Expression.Lift(_0024name_002418443));
					array5[0] = _0024_00244559_002418593;
					ReferenceExpression referenceExpression2 = (_0024_00244560_002418594 = new ReferenceExpression(LexicalInfo.Empty));
					string text28 = (_0024_00244560_002418594.Name = "position");
					array5[1] = _0024_00244560_002418594;
					ReferenceExpression referenceExpression3 = (_0024_00244561_002418595 = new ReferenceExpression(LexicalInfo.Empty));
					string text30 = (_0024_00244561_002418595.Name = "rotation");
					array5[2] = _0024_00244561_002418595;
					ExpressionCollection expressionCollection4 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array5));
					Expression expression20 = (declarationStatement3.Initializer = _0024_00244562_002418596);
					array2[1] = Statement.Lift(_0024_00244563_002418597);
					IfStatement ifStatement4 = (_0024_00244572_002418606 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement5 = _0024_00244572_002418606;
					BinaryExpression binaryExpression7 = (_0024_00244565_002418599 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00244565_002418599.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression8 = _0024_00244565_002418599;
					ReferenceExpression referenceExpression4 = (_0024_00244564_002418598 = new ReferenceExpression(LexicalInfo.Empty));
					string text32 = (_0024_00244564_002418598.Name = "obj");
					Expression expression22 = (binaryExpression8.Left = _0024_00244564_002418598);
					Expression expression24 = (_0024_00244565_002418599.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression26 = (ifStatement5.Condition = _0024_00244565_002418599);
					IfStatement ifStatement6 = _0024_00244572_002418606;
					Block block9 = (_0024_00244571_002418605 = new Block(LexicalInfo.Empty));
					Block block10 = _0024_00244571_002418605;
					Statement[] array6 = new Statement[1];
					MacroStatement macroStatement3 = (_0024_00244570_002418604 = new MacroStatement(LexicalInfo.Empty));
					string text34 = (_0024_00244570_002418604.Name = "assert");
					MacroStatement macroStatement4 = _0024_00244570_002418604;
					Expression[] array7 = new Expression[1];
					BinaryExpression binaryExpression9 = (_0024_00244569_002418603 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00244569_002418603.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression10 = _0024_00244569_002418603;
					BinaryExpression binaryExpression11 = (_0024_00244567_002418601 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType12 = (_0024_00244567_002418601.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression12 = _0024_00244567_002418601;
					StringLiteralExpression stringLiteralExpression3 = (_0024_00244566_002418600 = new StringLiteralExpression(LexicalInfo.Empty));
					string text36 = (_0024_00244566_002418600.Value = "QuestAsset: ");
					Expression expression28 = (binaryExpression12.Left = _0024_00244566_002418600);
					Expression expression30 = (_0024_00244567_002418601.Right = Expression.Lift(_0024name_002418443.Name));
					Expression expression32 = (binaryExpression10.Left = _0024_00244567_002418601);
					BinaryExpression binaryExpression13 = _0024_00244569_002418603;
					StringLiteralExpression stringLiteralExpression4 = (_0024_00244568_002418602 = new StringLiteralExpression(LexicalInfo.Empty));
					string text38 = (_0024_00244568_002418602.Value = " をinstantiateできません");
					Expression expression34 = (binaryExpression13.Right = _0024_00244568_002418602);
					array7[0] = _0024_00244569_002418603;
					ExpressionCollection expressionCollection6 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array7));
					Block block12 = (_0024_00244570_002418604.Body = new Block(LexicalInfo.Empty));
					array6[0] = Statement.Lift(_0024_00244570_002418604);
					StatementCollection statementCollection4 = (block10.Statements = StatementCollection.FromArray(array6));
					Block block14 = (ifStatement6.TrueBlock = _0024_00244571_002418605);
					array2[2] = Statement.Lift(_0024_00244572_002418606);
					ReturnStatement returnStatement = (_0024_00244574_002418608 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement2 = _0024_00244574_002418608;
					ReferenceExpression referenceExpression5 = (_0024_00244573_002418607 = new ReferenceExpression(LexicalInfo.Empty));
					string text40 = (_0024_00244573_002418607.Name = "obj");
					Expression expression36 = (returnStatement2.Expression = _0024_00244573_002418607);
					array2[3] = Statement.Lift(_0024_00244574_002418608);
					StatementCollection statementCollection6 = (block2.Statements = StatementCollection.FromArray(array2));
					Block block16 = (method4.Body = _0024_00244575_002418609);
					_0024m4_002418611 = _0024_00244576_002418610;
					_0024m4_002418611.Name = _0024methodName_002418444.Name;
					result = (Yield(7, _0024m4_002418611) ? 1 : 0);
					break;
				}
				case 4:
				case 7:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024quest_asset_instantiate_method_002418614;

		internal Quest_asset_instantiate_methodMacro _0024self__002418615;

		public _0024ExpandGeneratorImpl_002418440(MacroStatement quest_asset_instantiate_method, Quest_asset_instantiate_methodMacro self_)
		{
			_0024quest_asset_instantiate_method_002418614 = quest_asset_instantiate_method;
			_0024self__002418615 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024quest_asset_instantiate_method_002418614, _0024self__002418615);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Quest_asset_instantiate_methodMacro()
	{
	}

	public Quest_asset_instantiate_methodMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement quest_asset_instantiate_method)
	{
		return new _0024ExpandGeneratorImpl_002418440(quest_asset_instantiate_method, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement quest_asset_instantiate_method)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'quest_asset_instantiate_method' is using. Read BOO-1077 for more info.");
	}
}
