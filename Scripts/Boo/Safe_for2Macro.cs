using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Safe_for2Macro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422826 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002466_002422827;

			internal MacroStatement _0024_0024match_002467_002422828;

			internal BinaryExpression _0024_0024match_002468_002422829;

			internal TryCastExpression _0024_0024match_002469_002422830;

			internal Expression _0024v_002422831;

			internal TypeReference _0024t_002422832;

			internal Expression _0024enumerable_002422833;

			internal UnaryExpression _0024_00245278_002422834;

			internal StatementModifier _0024_00245279_002422835;

			internal ReturnStatement _0024_00245280_002422836;

			internal SimpleTypeReference _0024_00245281_002422837;

			internal Declaration _0024_00245282_002422838;

			internal MemberReferenceExpression _0024_00245283_002422839;

			internal MethodInvocationExpression _0024_00245284_002422840;

			internal MemberReferenceExpression _0024_00245285_002422841;

			internal MethodInvocationExpression _0024_00245286_002422842;

			internal MemberReferenceExpression _0024_00245287_002422843;

			internal ParameterDeclaration _0024_00245288_002422844;

			internal ReferenceExpression _0024_00245289_002422845;

			internal MemberReferenceExpression _0024_00245290_002422846;

			internal UnaryExpression _0024_00245291_002422847;

			internal ReferenceExpression _0024_00245292_002422848;

			internal SimpleTypeReference _0024_00245293_002422849;

			internal TypeofExpression _0024_00245294_002422850;

			internal BinaryExpression _0024_00245295_002422851;

			internal BinaryExpression _0024_00245296_002422852;

			internal ReturnStatement _0024_00245297_002422853;

			internal Block _0024_00245298_002422854;

			internal BlockExpression _0024_00245299_002422855;

			internal MethodInvocationExpression _0024_00245300_002422856;

			internal DeclarationStatement _0024_00245301_002422857;

			internal ReferenceExpression _0024_00245302_002422858;

			internal UnaryExpression _0024_00245303_002422859;

			internal ReferenceExpression _0024_00245304_002422860;

			internal StringLiteralExpression _0024_00245305_002422861;

			internal StringLiteralExpression _0024_00245306_002422862;

			internal MethodInvocationExpression _0024_00245307_002422863;

			internal RaiseStatement _0024_00245308_002422864;

			internal Block _0024_00245309_002422865;

			internal IfStatement _0024_00245310_002422866;

			internal SimpleTypeReference _0024_00245311_002422867;

			internal Declaration _0024_00245312_002422868;

			internal ReferenceExpression _0024_00245313_002422869;

			internal MemberReferenceExpression _0024_00245314_002422870;

			internal StringLiteralExpression _0024_00245315_002422871;

			internal MethodInvocationExpression _0024_00245316_002422872;

			internal DeclarationStatement _0024_00245317_002422873;

			internal ReferenceExpression _0024_00245318_002422874;

			internal UnaryExpression _0024_00245319_002422875;

			internal ReferenceExpression _0024_00245320_002422876;

			internal StringLiteralExpression _0024_00245321_002422877;

			internal MethodInvocationExpression _0024_00245322_002422878;

			internal RaiseStatement _0024_00245323_002422879;

			internal Block _0024_00245324_002422880;

			internal IfStatement _0024_00245325_002422881;

			internal SimpleTypeReference _0024_00245326_002422882;

			internal Declaration _0024_00245327_002422883;

			internal DeclarationStatement _0024_00245328_002422884;

			internal ReferenceExpression _0024_00245329_002422885;

			internal ReferenceExpression _0024_00245330_002422886;

			internal MemberReferenceExpression _0024_00245331_002422887;

			internal MethodInvocationExpression _0024_00245332_002422888;

			internal SimpleTypeReference _0024_00245333_002422889;

			internal CastExpression _0024_00245334_002422890;

			internal BinaryExpression _0024_00245335_002422891;

			internal ReferenceExpression _0024_00245336_002422892;

			internal ParameterDeclaration _0024_00245337_002422893;

			internal MethodInvocationExpression _0024_00245338_002422894;

			internal Block _0024_00245339_002422895;

			internal BlockExpression _0024_00245340_002422896;

			internal BinaryExpression _0024_00245341_002422897;

			internal ReferenceExpression _0024_00245342_002422898;

			internal SimpleTypeReference _0024_00245343_002422899;

			internal TypeofExpression _0024_00245344_002422900;

			internal BinaryExpression _0024_00245345_002422901;

			internal ReferenceExpression _0024_00245346_002422902;

			internal MemberReferenceExpression _0024_00245347_002422903;

			internal MethodInvocationExpression _0024_00245348_002422904;

			internal ReferenceExpression _0024_00245349_002422905;

			internal ReferenceExpression _0024_00245350_002422906;

			internal MemberReferenceExpression _0024_00245351_002422907;

			internal MethodInvocationExpression _0024_00245352_002422908;

			internal Block _0024_00245353_002422909;

			internal WhileStatement _0024_00245354_002422910;

			internal Block _0024_00245355_002422911;

			internal ReferenceExpression _0024_00245356_002422912;

			internal MemberReferenceExpression _0024_00245357_002422913;

			internal MemberReferenceExpression _0024_00245358_002422914;

			internal ReferenceExpression _0024_00245359_002422915;

			internal MemberReferenceExpression _0024_00245360_002422916;

			internal StringLiteralExpression _0024_00245361_002422917;

			internal MemberReferenceExpression _0024_00245362_002422918;

			internal MethodInvocationExpression _0024_00245363_002422919;

			internal ReferenceExpression _0024_00245364_002422920;

			internal MemberReferenceExpression _0024_00245365_002422921;

			internal MethodInvocationExpression _0024_00245366_002422922;

			internal MemberReferenceExpression _0024_00245367_002422923;

			internal MethodInvocationExpression _0024_00245368_002422924;

			internal MethodInvocationExpression _0024_00245369_002422925;

			internal Block _0024_00245370_002422926;

			internal IfStatement _0024_00245371_002422927;

			internal Block _0024_00245372_002422928;

			internal SimpleTypeReference _0024_00245373_002422929;

			internal Declaration _0024_00245374_002422930;

			internal ReferenceExpression _0024_00245375_002422931;

			internal SimpleTypeReference _0024_00245376_002422932;

			internal TryCastExpression _0024_00245377_002422933;

			internal DeclarationStatement _0024_00245378_002422934;

			internal ReferenceExpression _0024_00245379_002422935;

			internal ReferenceExpression _0024_00245380_002422936;

			internal MemberReferenceExpression _0024_00245381_002422937;

			internal MethodInvocationExpression _0024_00245382_002422938;

			internal Block _0024_00245383_002422939;

			internal IfStatement _0024_00245384_002422940;

			internal Block _0024_00245385_002422941;

			internal TryStatement _0024_00245386_002422942;

			internal Block _0024_00245387_002422943;

			internal Block _0024z_002422944;

			internal MacroStatement _0024_0024match_002470_002422945;

			internal BinaryExpression _0024_0024match_002471_002422946;

			internal Expression _0024x_002422947;

			internal UnaryExpression _0024_00245388_002422948;

			internal StatementModifier _0024_00245389_002422949;

			internal ReturnStatement _0024_00245390_002422950;

			internal SimpleTypeReference _0024_00245391_002422951;

			internal Declaration _0024_00245392_002422952;

			internal MemberReferenceExpression _0024_00245393_002422953;

			internal MethodInvocationExpression _0024_00245394_002422954;

			internal MemberReferenceExpression _0024_00245395_002422955;

			internal MethodInvocationExpression _0024_00245396_002422956;

			internal MemberReferenceExpression _0024_00245397_002422957;

			internal ParameterDeclaration _0024_00245398_002422958;

			internal ReferenceExpression _0024_00245399_002422959;

			internal MemberReferenceExpression _0024_00245400_002422960;

			internal UnaryExpression _0024_00245401_002422961;

			internal ReferenceExpression _0024_00245402_002422962;

			internal SimpleTypeReference _0024_00245403_002422963;

			internal TypeofExpression _0024_00245404_002422964;

			internal BinaryExpression _0024_00245405_002422965;

			internal BinaryExpression _0024_00245406_002422966;

			internal ReturnStatement _0024_00245407_002422967;

			internal Block _0024_00245408_002422968;

			internal BlockExpression _0024_00245409_002422969;

			internal MethodInvocationExpression _0024_00245410_002422970;

			internal DeclarationStatement _0024_00245411_002422971;

			internal ReferenceExpression _0024_00245412_002422972;

			internal UnaryExpression _0024_00245413_002422973;

			internal ReferenceExpression _0024_00245414_002422974;

			internal StringLiteralExpression _0024_00245415_002422975;

			internal StringLiteralExpression _0024_00245416_002422976;

			internal MethodInvocationExpression _0024_00245417_002422977;

			internal RaiseStatement _0024_00245418_002422978;

			internal Block _0024_00245419_002422979;

			internal IfStatement _0024_00245420_002422980;

			internal SimpleTypeReference _0024_00245421_002422981;

			internal Declaration _0024_00245422_002422982;

			internal ReferenceExpression _0024_00245423_002422983;

			internal MemberReferenceExpression _0024_00245424_002422984;

			internal StringLiteralExpression _0024_00245425_002422985;

			internal MethodInvocationExpression _0024_00245426_002422986;

			internal DeclarationStatement _0024_00245427_002422987;

			internal ReferenceExpression _0024_00245428_002422988;

			internal UnaryExpression _0024_00245429_002422989;

			internal ReferenceExpression _0024_00245430_002422990;

			internal StringLiteralExpression _0024_00245431_002422991;

			internal MethodInvocationExpression _0024_00245432_002422992;

			internal RaiseStatement _0024_00245433_002422993;

			internal Block _0024_00245434_002422994;

			internal IfStatement _0024_00245435_002422995;

			internal SimpleTypeReference _0024_00245436_002422996;

			internal Declaration _0024_00245437_002422997;

			internal DeclarationStatement _0024_00245438_002422998;

			internal ReferenceExpression _0024_00245439_002422999;

			internal ReferenceExpression _0024_00245440_002423000;

			internal MemberReferenceExpression _0024_00245441_002423001;

			internal MethodInvocationExpression _0024_00245442_002423002;

			internal SimpleTypeReference _0024_00245443_002423003;

			internal CastExpression _0024_00245444_002423004;

			internal BinaryExpression _0024_00245445_002423005;

			internal Declaration _0024_00245446_002423006;

			internal ParameterDeclaration _0024_00245447_002423007;

			internal MethodInvocationExpression _0024_00245448_002423008;

			internal Block _0024_00245449_002423009;

			internal BlockExpression _0024_00245450_002423010;

			internal DeclarationStatement _0024_00245451_002423011;

			internal ReferenceExpression _0024_00245452_002423012;

			internal ReferenceExpression _0024_00245453_002423013;

			internal MethodInvocationExpression _0024_00245454_002423014;

			internal MemberReferenceExpression _0024_00245455_002423015;

			internal ReferenceExpression _0024_00245456_002423016;

			internal SimpleTypeReference _0024_00245457_002423017;

			internal TypeofExpression _0024_00245458_002423018;

			internal BinaryExpression _0024_00245459_002423019;

			internal ReferenceExpression _0024_00245460_002423020;

			internal MemberReferenceExpression _0024_00245461_002423021;

			internal MethodInvocationExpression _0024_00245462_002423022;

			internal ReferenceExpression _0024_00245463_002423023;

			internal ReferenceExpression _0024_00245464_002423024;

			internal MemberReferenceExpression _0024_00245465_002423025;

			internal MethodInvocationExpression _0024_00245466_002423026;

			internal Block _0024_00245467_002423027;

			internal WhileStatement _0024_00245468_002423028;

			internal Block _0024_00245469_002423029;

			internal ReferenceExpression _0024_00245470_002423030;

			internal MemberReferenceExpression _0024_00245471_002423031;

			internal MemberReferenceExpression _0024_00245472_002423032;

			internal ReferenceExpression _0024_00245473_002423033;

			internal MemberReferenceExpression _0024_00245474_002423034;

			internal StringLiteralExpression _0024_00245475_002423035;

			internal MemberReferenceExpression _0024_00245476_002423036;

			internal MethodInvocationExpression _0024_00245477_002423037;

			internal ReferenceExpression _0024_00245478_002423038;

			internal MemberReferenceExpression _0024_00245479_002423039;

			internal MethodInvocationExpression _0024_00245480_002423040;

			internal MemberReferenceExpression _0024_00245481_002423041;

			internal MethodInvocationExpression _0024_00245482_002423042;

			internal MethodInvocationExpression _0024_00245483_002423043;

			internal Block _0024_00245484_002423044;

			internal IfStatement _0024_00245485_002423045;

			internal Block _0024_00245486_002423046;

			internal SimpleTypeReference _0024_00245487_002423047;

			internal Declaration _0024_00245488_002423048;

			internal ReferenceExpression _0024_00245489_002423049;

			internal SimpleTypeReference _0024_00245490_002423050;

			internal TryCastExpression _0024_00245491_002423051;

			internal DeclarationStatement _0024_00245492_002423052;

			internal ReferenceExpression _0024_00245493_002423053;

			internal ReferenceExpression _0024_00245494_002423054;

			internal MemberReferenceExpression _0024_00245495_002423055;

			internal MethodInvocationExpression _0024_00245496_002423056;

			internal Block _0024_00245497_002423057;

			internal IfStatement _0024_00245498_002423058;

			internal Block _0024_00245499_002423059;

			internal TryStatement _0024_00245500_002423060;

			internal Block _0024_00245501_002423061;

			internal MacroStatement _0024safe_for2_002423062;

			internal Safe_for2Macro _0024self__002423063;

			public _0024(MacroStatement safe_for2, Safe_for2Macro self_)
			{
				_0024safe_for2_002423062 = safe_for2;
				_0024self__002423063 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024safe_for2_002423062 == null)
					{
						throw new ArgumentNullException("safe_for2");
					}
					_0024self__002423063.__macro = _0024safe_for2_002423062;
					_0024_0024match_002466_002422827 = _0024safe_for2_002423062;
					if (_0024_0024match_002466_002422827 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002467_002422828 = _0024_0024match_002466_002422827);
						if (true && _0024_0024match_002467_002422828.Name == "safe_for2" && 1 == ((ICollection)_0024_0024match_002467_002422828.Arguments).Count && _0024_0024match_002467_002422828.Arguments[0] is BinaryExpression)
						{
							BinaryExpression binaryExpression = (_0024_0024match_002468_002422829 = (BinaryExpression)_0024_0024match_002467_002422828.Arguments[0]);
							if (true && _0024_0024match_002468_002422829.Operator == BinaryOperatorType.Member && _0024_0024match_002468_002422829.Left is TryCastExpression)
							{
								TryCastExpression tryCastExpression = (_0024_0024match_002469_002422830 = (TryCastExpression)_0024_0024match_002468_002422829.Left);
								if (true)
								{
									Expression expression = (_0024v_002422831 = _0024_0024match_002469_002422830.Target);
									if (true)
									{
										TypeReference typeReference = (_0024t_002422832 = _0024_0024match_002469_002422830.Type);
										if (true)
										{
											Expression expression2 = (_0024enumerable_002422833 = _0024_0024match_002468_002422829.Right);
											if (true)
											{
												Block block = (_0024_00245387_002422943 = new Block(LexicalInfo.Empty));
												Block block2 = _0024_00245387_002422943;
												Statement[] array = new Statement[7];
												ReturnStatement returnStatement = (_0024_00245280_002422836 = new ReturnStatement(LexicalInfo.Empty));
												ReturnStatement returnStatement2 = _0024_00245280_002422836;
												StatementModifier statementModifier = (_0024_00245279_002422835 = new StatementModifier(LexicalInfo.Empty));
												StatementModifierType statementModifierType2 = (_0024_00245279_002422835.Type = StatementModifierType.If);
												StatementModifier statementModifier2 = _0024_00245279_002422835;
												UnaryExpression unaryExpression = (_0024_00245278_002422834 = new UnaryExpression(LexicalInfo.Empty));
												UnaryOperatorType unaryOperatorType2 = (_0024_00245278_002422834.Operator = UnaryOperatorType.LogicalNot);
												Expression expression4 = (_0024_00245278_002422834.Operand = Expression.Lift(_0024enumerable_002422833));
												Expression expression6 = (statementModifier2.Condition = _0024_00245278_002422834);
												StatementModifier statementModifier4 = (returnStatement2.Modifier = _0024_00245279_002422835);
												array[0] = Statement.Lift(_0024_00245280_002422836);
												DeclarationStatement declarationStatement = (_0024_00245301_002422857 = new DeclarationStatement(LexicalInfo.Empty));
												DeclarationStatement declarationStatement2 = _0024_00245301_002422857;
												Declaration declaration = (_0024_00245282_002422838 = new Declaration(LexicalInfo.Empty));
												string text2 = (_0024_00245282_002422838.Name = "listType");
												Declaration declaration2 = _0024_00245282_002422838;
												SimpleTypeReference simpleTypeReference = (_0024_00245281_002422837 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag2 = (_0024_00245281_002422837.IsPointer = false);
												string text4 = (_0024_00245281_002422837.Name = "Type");
												TypeReference typeReference3 = (declaration2.Type = _0024_00245281_002422837);
												Declaration declaration4 = (declarationStatement2.Declaration = _0024_00245282_002422838);
												DeclarationStatement declarationStatement3 = _0024_00245301_002422857;
												MethodInvocationExpression methodInvocationExpression = (_0024_00245300_002422856 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression2 = _0024_00245300_002422856;
												MemberReferenceExpression memberReferenceExpression = (_0024_00245287_002422843 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text6 = (_0024_00245287_002422843.Name = "First");
												MemberReferenceExpression memberReferenceExpression2 = _0024_00245287_002422843;
												MethodInvocationExpression methodInvocationExpression3 = (_0024_00245286_002422842 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression4 = _0024_00245286_002422842;
												MemberReferenceExpression memberReferenceExpression3 = (_0024_00245285_002422841 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text8 = (_0024_00245285_002422841.Name = "GetInterfaces");
												MemberReferenceExpression memberReferenceExpression4 = _0024_00245285_002422841;
												MethodInvocationExpression methodInvocationExpression5 = (_0024_00245284_002422840 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression6 = _0024_00245284_002422840;
												MemberReferenceExpression memberReferenceExpression5 = (_0024_00245283_002422839 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text10 = (_0024_00245283_002422839.Name = "GetType");
												Expression expression8 = (_0024_00245283_002422839.Target = Expression.Lift(_0024enumerable_002422833));
												Expression expression10 = (methodInvocationExpression6.Target = _0024_00245283_002422839);
												Expression expression12 = (memberReferenceExpression4.Target = _0024_00245284_002422840);
												Expression expression14 = (methodInvocationExpression4.Target = _0024_00245285_002422841);
												Expression expression16 = (memberReferenceExpression2.Target = _0024_00245286_002422842);
												Expression expression18 = (methodInvocationExpression2.Target = _0024_00245287_002422843);
												MethodInvocationExpression methodInvocationExpression7 = _0024_00245300_002422856;
												Expression[] array2 = new Expression[1];
												BlockExpression blockExpression = (_0024_00245299_002422855 = new BlockExpression(LexicalInfo.Empty));
												BlockExpression blockExpression2 = _0024_00245299_002422855;
												ParameterDeclaration[] array3 = new ParameterDeclaration[1];
												ParameterDeclaration parameterDeclaration = (_0024_00245288_002422844 = new ParameterDeclaration(LexicalInfo.Empty));
												string text12 = (_0024_00245288_002422844.Name = "x");
												array3[0] = _0024_00245288_002422844;
												ParameterDeclarationCollection parameterDeclarationCollection2 = (blockExpression2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array3));
												BlockExpression blockExpression3 = _0024_00245299_002422855;
												Block block3 = (_0024_00245298_002422854 = new Block(LexicalInfo.Empty));
												Block block4 = _0024_00245298_002422854;
												Statement[] array4 = new Statement[1];
												ReturnStatement returnStatement3 = (_0024_00245297_002422853 = new ReturnStatement(LexicalInfo.Empty));
												ReturnStatement returnStatement4 = _0024_00245297_002422853;
												BinaryExpression binaryExpression2 = (_0024_00245296_002422852 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType2 = (_0024_00245296_002422852.Operator = BinaryOperatorType.And);
												BinaryExpression binaryExpression3 = _0024_00245296_002422852;
												UnaryExpression unaryExpression2 = (_0024_00245291_002422847 = new UnaryExpression(LexicalInfo.Empty));
												UnaryOperatorType unaryOperatorType4 = (_0024_00245291_002422847.Operator = UnaryOperatorType.LogicalNot);
												UnaryExpression unaryExpression3 = _0024_00245291_002422847;
												MemberReferenceExpression memberReferenceExpression6 = (_0024_00245290_002422846 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text14 = (_0024_00245290_002422846.Name = "IsGenericType");
												MemberReferenceExpression memberReferenceExpression7 = _0024_00245290_002422846;
												ReferenceExpression referenceExpression = (_0024_00245289_002422845 = new ReferenceExpression(LexicalInfo.Empty));
												string text16 = (_0024_00245289_002422845.Name = "x");
												Expression expression20 = (memberReferenceExpression7.Target = _0024_00245289_002422845);
												Expression expression22 = (unaryExpression3.Operand = _0024_00245290_002422846);
												Expression expression24 = (binaryExpression3.Left = _0024_00245291_002422847);
												BinaryExpression binaryExpression4 = _0024_00245296_002422852;
												BinaryExpression binaryExpression5 = (_0024_00245295_002422851 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType4 = (_0024_00245295_002422851.Operator = BinaryOperatorType.ReferenceEquality);
												BinaryExpression binaryExpression6 = _0024_00245295_002422851;
												ReferenceExpression referenceExpression2 = (_0024_00245292_002422848 = new ReferenceExpression(LexicalInfo.Empty));
												string text18 = (_0024_00245292_002422848.Name = "x");
												Expression expression26 = (binaryExpression6.Left = _0024_00245292_002422848);
												BinaryExpression binaryExpression7 = _0024_00245295_002422851;
												TypeofExpression typeofExpression = (_0024_00245294_002422850 = new TypeofExpression(LexicalInfo.Empty));
												TypeofExpression typeofExpression2 = _0024_00245294_002422850;
												SimpleTypeReference simpleTypeReference2 = (_0024_00245293_002422849 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag4 = (_0024_00245293_002422849.IsPointer = false);
												string text20 = (_0024_00245293_002422849.Name = "IEnumerable");
												TypeReference typeReference5 = (typeofExpression2.Type = _0024_00245293_002422849);
												Expression expression28 = (binaryExpression7.Right = _0024_00245294_002422850);
												Expression expression30 = (binaryExpression4.Right = _0024_00245295_002422851);
												Expression expression32 = (returnStatement4.Expression = _0024_00245296_002422852);
												array4[0] = Statement.Lift(_0024_00245297_002422853);
												StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array4));
												Block block6 = (blockExpression3.Body = _0024_00245298_002422854);
												array2[0] = _0024_00245299_002422855;
												ExpressionCollection expressionCollection2 = (methodInvocationExpression7.Arguments = ExpressionCollection.FromArray(array2));
												Expression expression34 = (declarationStatement3.Initializer = _0024_00245300_002422856);
												array[1] = Statement.Lift(_0024_00245301_002422857);
												IfStatement ifStatement = (_0024_00245310_002422866 = new IfStatement(LexicalInfo.Empty));
												IfStatement ifStatement2 = _0024_00245310_002422866;
												UnaryExpression unaryExpression4 = (_0024_00245303_002422859 = new UnaryExpression(LexicalInfo.Empty));
												UnaryOperatorType unaryOperatorType6 = (_0024_00245303_002422859.Operator = UnaryOperatorType.LogicalNot);
												UnaryExpression unaryExpression5 = _0024_00245303_002422859;
												ReferenceExpression referenceExpression3 = (_0024_00245302_002422858 = new ReferenceExpression(LexicalInfo.Empty));
												string text22 = (_0024_00245302_002422858.Name = "listType");
												Expression expression36 = (unaryExpression5.Operand = _0024_00245302_002422858);
												Expression expression38 = (ifStatement2.Condition = _0024_00245303_002422859);
												IfStatement ifStatement3 = _0024_00245310_002422866;
												Block block7 = (_0024_00245309_002422865 = new Block(LexicalInfo.Empty));
												Block block8 = _0024_00245309_002422865;
												Statement[] array5 = new Statement[1];
												RaiseStatement raiseStatement = (_0024_00245308_002422864 = new RaiseStatement(LexicalInfo.Empty));
												RaiseStatement raiseStatement2 = _0024_00245308_002422864;
												MethodInvocationExpression methodInvocationExpression8 = (_0024_00245307_002422863 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression9 = _0024_00245307_002422863;
												ReferenceExpression referenceExpression4 = (_0024_00245304_002422860 = new ReferenceExpression(LexicalInfo.Empty));
												string text24 = (_0024_00245304_002422860.Name = "ArgumentException");
												Expression expression40 = (methodInvocationExpression9.Target = _0024_00245304_002422860);
												MethodInvocationExpression methodInvocationExpression10 = _0024_00245307_002422863;
												Expression[] array6 = new Expression[2];
												StringLiteralExpression stringLiteralExpression = (_0024_00245305_002422861 = new StringLiteralExpression(LexicalInfo.Empty));
												string text26 = (_0024_00245305_002422861.Value = "Object does not implement IEnumerableinterface");
												array6[0] = _0024_00245305_002422861;
												StringLiteralExpression stringLiteralExpression2 = (_0024_00245306_002422862 = new StringLiteralExpression(LexicalInfo.Empty));
												string text28 = (_0024_00245306_002422862.Value = "enumerable");
												array6[1] = _0024_00245306_002422862;
												ExpressionCollection expressionCollection4 = (methodInvocationExpression10.Arguments = ExpressionCollection.FromArray(array6));
												Expression expression42 = (raiseStatement2.Exception = _0024_00245307_002422863);
												array5[0] = Statement.Lift(_0024_00245308_002422864);
												StatementCollection statementCollection4 = (block8.Statements = StatementCollection.FromArray(array5));
												Block block10 = (ifStatement3.TrueBlock = _0024_00245309_002422865);
												array[2] = Statement.Lift(_0024_00245310_002422866);
												DeclarationStatement declarationStatement4 = (_0024_00245317_002422873 = new DeclarationStatement(LexicalInfo.Empty));
												DeclarationStatement declarationStatement5 = _0024_00245317_002422873;
												Declaration declaration5 = (_0024_00245312_002422868 = new Declaration(LexicalInfo.Empty));
												string text30 = (_0024_00245312_002422868.Name = "method");
												Declaration declaration6 = _0024_00245312_002422868;
												SimpleTypeReference simpleTypeReference3 = (_0024_00245311_002422867 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag6 = (_0024_00245311_002422867.IsPointer = false);
												string text32 = (_0024_00245311_002422867.Name = "MethodInfo");
												TypeReference typeReference7 = (declaration6.Type = _0024_00245311_002422867);
												Declaration declaration8 = (declarationStatement5.Declaration = _0024_00245312_002422868);
												DeclarationStatement declarationStatement6 = _0024_00245317_002422873;
												MethodInvocationExpression methodInvocationExpression11 = (_0024_00245316_002422872 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression12 = _0024_00245316_002422872;
												MemberReferenceExpression memberReferenceExpression8 = (_0024_00245314_002422870 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text34 = (_0024_00245314_002422870.Name = "GetMethod");
												MemberReferenceExpression memberReferenceExpression9 = _0024_00245314_002422870;
												ReferenceExpression referenceExpression5 = (_0024_00245313_002422869 = new ReferenceExpression(LexicalInfo.Empty));
												string text36 = (_0024_00245313_002422869.Name = "listType");
												Expression expression44 = (memberReferenceExpression9.Target = _0024_00245313_002422869);
												Expression expression46 = (methodInvocationExpression12.Target = _0024_00245314_002422870);
												MethodInvocationExpression methodInvocationExpression13 = _0024_00245316_002422872;
												Expression[] array7 = new Expression[1];
												StringLiteralExpression stringLiteralExpression3 = (_0024_00245315_002422871 = new StringLiteralExpression(LexicalInfo.Empty));
												string text38 = (_0024_00245315_002422871.Value = "GetEnumerator");
												array7[0] = _0024_00245315_002422871;
												ExpressionCollection expressionCollection6 = (methodInvocationExpression13.Arguments = ExpressionCollection.FromArray(array7));
												Expression expression48 = (declarationStatement6.Initializer = _0024_00245316_002422872);
												array[3] = Statement.Lift(_0024_00245317_002422873);
												IfStatement ifStatement4 = (_0024_00245325_002422881 = new IfStatement(LexicalInfo.Empty));
												IfStatement ifStatement5 = _0024_00245325_002422881;
												UnaryExpression unaryExpression6 = (_0024_00245319_002422875 = new UnaryExpression(LexicalInfo.Empty));
												UnaryOperatorType unaryOperatorType8 = (_0024_00245319_002422875.Operator = UnaryOperatorType.LogicalNot);
												UnaryExpression unaryExpression7 = _0024_00245319_002422875;
												ReferenceExpression referenceExpression6 = (_0024_00245318_002422874 = new ReferenceExpression(LexicalInfo.Empty));
												string text40 = (_0024_00245318_002422874.Name = "method");
												Expression expression50 = (unaryExpression7.Operand = _0024_00245318_002422874);
												Expression expression52 = (ifStatement5.Condition = _0024_00245319_002422875);
												IfStatement ifStatement6 = _0024_00245325_002422881;
												Block block11 = (_0024_00245324_002422880 = new Block(LexicalInfo.Empty));
												Block block12 = _0024_00245324_002422880;
												Statement[] array8 = new Statement[1];
												RaiseStatement raiseStatement3 = (_0024_00245323_002422879 = new RaiseStatement(LexicalInfo.Empty));
												RaiseStatement raiseStatement4 = _0024_00245323_002422879;
												MethodInvocationExpression methodInvocationExpression14 = (_0024_00245322_002422878 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression15 = _0024_00245322_002422878;
												ReferenceExpression referenceExpression7 = (_0024_00245320_002422876 = new ReferenceExpression(LexicalInfo.Empty));
												string text42 = (_0024_00245320_002422876.Name = "InvalidOperationException");
												Expression expression54 = (methodInvocationExpression15.Target = _0024_00245320_002422876);
												MethodInvocationExpression methodInvocationExpression16 = _0024_00245322_002422878;
												Expression[] array9 = new Expression[1];
												StringLiteralExpression stringLiteralExpression4 = (_0024_00245321_002422877 = new StringLiteralExpression(LexicalInfo.Empty));
												string text44 = (_0024_00245321_002422877.Value = "Failed to get 'GetEnumberator()'method info from IEnumerable type");
												array9[0] = _0024_00245321_002422877;
												ExpressionCollection expressionCollection8 = (methodInvocationExpression16.Arguments = ExpressionCollection.FromArray(array9));
												Expression expression56 = (raiseStatement4.Exception = _0024_00245322_002422878);
												array8[0] = Statement.Lift(_0024_00245323_002422879);
												StatementCollection statementCollection6 = (block12.Statements = StatementCollection.FromArray(array8));
												Block block14 = (ifStatement6.TrueBlock = _0024_00245324_002422880);
												array[4] = Statement.Lift(_0024_00245325_002422881);
												DeclarationStatement declarationStatement7 = (_0024_00245328_002422884 = new DeclarationStatement(LexicalInfo.Empty));
												DeclarationStatement declarationStatement8 = _0024_00245328_002422884;
												Declaration declaration9 = (_0024_00245327_002422883 = new Declaration(LexicalInfo.Empty));
												string text46 = (_0024_00245327_002422883.Name = "enumerator");
												Declaration declaration10 = _0024_00245327_002422883;
												SimpleTypeReference simpleTypeReference4 = (_0024_00245326_002422882 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag8 = (_0024_00245326_002422882.IsPointer = false);
												string text48 = (_0024_00245326_002422882.Name = "IEnumerator");
												TypeReference typeReference9 = (declaration10.Type = _0024_00245326_002422882);
												Declaration declaration12 = (declarationStatement8.Declaration = _0024_00245327_002422883);
												Expression expression58 = (_0024_00245328_002422884.Initializer = new NullLiteralExpression(LexicalInfo.Empty));
												array[5] = Statement.Lift(_0024_00245328_002422884);
												TryStatement tryStatement = (_0024_00245386_002422942 = new TryStatement(LexicalInfo.Empty));
												TryStatement tryStatement2 = _0024_00245386_002422942;
												Block block15 = (_0024_00245372_002422928 = new Block(LexicalInfo.Empty));
												Block block16 = _0024_00245372_002422928;
												Statement[] array10 = new Statement[3];
												BinaryExpression binaryExpression8 = (_0024_00245335_002422891 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType6 = (_0024_00245335_002422891.Operator = BinaryOperatorType.Assign);
												BinaryExpression binaryExpression9 = _0024_00245335_002422891;
												ReferenceExpression referenceExpression8 = (_0024_00245329_002422885 = new ReferenceExpression(LexicalInfo.Empty));
												string text50 = (_0024_00245329_002422885.Name = "enumerator");
												Expression expression60 = (binaryExpression9.Left = _0024_00245329_002422885);
												BinaryExpression binaryExpression10 = _0024_00245335_002422891;
												CastExpression castExpression = (_0024_00245334_002422890 = new CastExpression(LexicalInfo.Empty));
												CastExpression castExpression2 = _0024_00245334_002422890;
												MethodInvocationExpression methodInvocationExpression17 = (_0024_00245332_002422888 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression18 = _0024_00245332_002422888;
												MemberReferenceExpression memberReferenceExpression10 = (_0024_00245331_002422887 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text52 = (_0024_00245331_002422887.Name = "Invoke");
												MemberReferenceExpression memberReferenceExpression11 = _0024_00245331_002422887;
												ReferenceExpression referenceExpression9 = (_0024_00245330_002422886 = new ReferenceExpression(LexicalInfo.Empty));
												string text54 = (_0024_00245330_002422886.Name = "method");
												Expression expression62 = (memberReferenceExpression11.Target = _0024_00245330_002422886);
												Expression expression64 = (methodInvocationExpression18.Target = _0024_00245331_002422887);
												ExpressionCollection expressionCollection10 = (_0024_00245332_002422888.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024enumerable_002422833), new NullLiteralExpression(LexicalInfo.Empty)));
												Expression expression66 = (castExpression2.Target = _0024_00245332_002422888);
												CastExpression castExpression3 = _0024_00245334_002422890;
												SimpleTypeReference simpleTypeReference5 = (_0024_00245333_002422889 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag10 = (_0024_00245333_002422889.IsPointer = false);
												string text56 = (_0024_00245333_002422889.Name = "IEnumerator");
												TypeReference typeReference11 = (castExpression3.Type = _0024_00245333_002422889);
												Expression expression68 = (binaryExpression10.Right = _0024_00245334_002422890);
												array10[0] = Statement.Lift(_0024_00245335_002422891);
												BinaryExpression binaryExpression11 = (_0024_00245341_002422897 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType8 = (_0024_00245341_002422897.Operator = BinaryOperatorType.Assign);
												BinaryExpression binaryExpression12 = _0024_00245341_002422897;
												ReferenceExpression referenceExpression10 = (_0024_00245336_002422892 = new ReferenceExpression(LexicalInfo.Empty));
												string text58 = (_0024_00245336_002422892.Name = "_hogemage");
												Expression expression70 = (binaryExpression12.Left = _0024_00245336_002422892);
												BinaryExpression binaryExpression13 = _0024_00245341_002422897;
												BlockExpression blockExpression4 = (_0024_00245340_002422896 = new BlockExpression(LexicalInfo.Empty));
												BlockExpression blockExpression5 = _0024_00245340_002422896;
												ParameterDeclaration[] array11 = new ParameterDeclaration[1];
												ParameterDeclaration parameterDeclaration2 = (_0024_00245337_002422893 = new ParameterDeclaration(LexicalInfo.Empty));
												string text60 = (_0024_00245337_002422893.Name = "$");
												TypeReference typeReference13 = (_0024_00245337_002422893.Type = TypeReference.Lift(_0024t_002422832));
												string text62 = (_0024_00245337_002422893.Name = CodeSerializer.LiftName(_0024v_002422831.ToCodeString()));
												array11[0] = _0024_00245337_002422893;
												ParameterDeclarationCollection parameterDeclarationCollection4 = (blockExpression5.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array11));
												BlockExpression blockExpression6 = _0024_00245340_002422896;
												Block block17 = (_0024_00245339_002422895 = new Block(LexicalInfo.Empty));
												Block block18 = _0024_00245339_002422895;
												Statement[] array12 = new Statement[1];
												MethodInvocationExpression methodInvocationExpression19 = (_0024_00245338_002422894 = new MethodInvocationExpression(LexicalInfo.Empty));
												Expression expression72 = (_0024_00245338_002422894.Target = Expression.Lift(_0024safe_for2_002423062.Body));
												ExpressionCollection expressionCollection12 = (_0024_00245338_002422894.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024v_002422831.ToCodeString())));
												array12[0] = Statement.Lift(_0024_00245338_002422894);
												StatementCollection statementCollection8 = (block18.Statements = StatementCollection.FromArray(array12));
												Block block20 = (blockExpression6.Body = _0024_00245339_002422895);
												Expression expression74 = (binaryExpression13.Right = _0024_00245340_002422896);
												array10[1] = Statement.Lift(_0024_00245341_002422897);
												IfStatement ifStatement7 = (_0024_00245371_002422927 = new IfStatement(LexicalInfo.Empty));
												IfStatement ifStatement8 = _0024_00245371_002422927;
												BinaryExpression binaryExpression14 = (_0024_00245345_002422901 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType10 = (_0024_00245345_002422901.Operator = BinaryOperatorType.TypeTest);
												BinaryExpression binaryExpression15 = _0024_00245345_002422901;
												ReferenceExpression referenceExpression11 = (_0024_00245342_002422898 = new ReferenceExpression(LexicalInfo.Empty));
												string text64 = (_0024_00245342_002422898.Name = "enumerator");
												Expression expression76 = (binaryExpression15.Left = _0024_00245342_002422898);
												BinaryExpression binaryExpression16 = _0024_00245345_002422901;
												TypeofExpression typeofExpression3 = (_0024_00245344_002422900 = new TypeofExpression(LexicalInfo.Empty));
												TypeofExpression typeofExpression4 = _0024_00245344_002422900;
												SimpleTypeReference simpleTypeReference6 = (_0024_00245343_002422899 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag12 = (_0024_00245343_002422899.IsPointer = false);
												string text66 = (_0024_00245343_002422899.Name = "IEnumerator");
												TypeReference typeReference15 = (typeofExpression4.Type = _0024_00245343_002422899);
												Expression expression78 = (binaryExpression16.Right = _0024_00245344_002422900);
												Expression expression80 = (ifStatement8.Condition = _0024_00245345_002422901);
												IfStatement ifStatement9 = _0024_00245371_002422927;
												Block block21 = (_0024_00245355_002422911 = new Block(LexicalInfo.Empty));
												Block block22 = _0024_00245355_002422911;
												Statement[] array13 = new Statement[1];
												WhileStatement whileStatement = (_0024_00245354_002422910 = new WhileStatement(LexicalInfo.Empty));
												WhileStatement whileStatement2 = _0024_00245354_002422910;
												MethodInvocationExpression methodInvocationExpression20 = (_0024_00245348_002422904 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression21 = _0024_00245348_002422904;
												MemberReferenceExpression memberReferenceExpression12 = (_0024_00245347_002422903 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text68 = (_0024_00245347_002422903.Name = "MoveNext");
												MemberReferenceExpression memberReferenceExpression13 = _0024_00245347_002422903;
												ReferenceExpression referenceExpression12 = (_0024_00245346_002422902 = new ReferenceExpression(LexicalInfo.Empty));
												string text70 = (_0024_00245346_002422902.Name = "enumerator");
												Expression expression82 = (memberReferenceExpression13.Target = _0024_00245346_002422902);
												Expression expression84 = (methodInvocationExpression21.Target = _0024_00245347_002422903);
												Expression expression86 = (whileStatement2.Condition = _0024_00245348_002422904);
												WhileStatement whileStatement3 = _0024_00245354_002422910;
												Block block23 = (_0024_00245353_002422909 = new Block(LexicalInfo.Empty));
												Block block24 = _0024_00245353_002422909;
												Statement[] array14 = new Statement[1];
												MethodInvocationExpression methodInvocationExpression22 = (_0024_00245352_002422908 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression23 = _0024_00245352_002422908;
												ReferenceExpression referenceExpression13 = (_0024_00245349_002422905 = new ReferenceExpression(LexicalInfo.Empty));
												string text72 = (_0024_00245349_002422905.Name = "_hogemage");
												Expression expression88 = (methodInvocationExpression23.Target = _0024_00245349_002422905);
												MethodInvocationExpression methodInvocationExpression24 = _0024_00245352_002422908;
												Expression[] array15 = new Expression[1];
												MemberReferenceExpression memberReferenceExpression14 = (_0024_00245351_002422907 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text74 = (_0024_00245351_002422907.Name = "Current");
												MemberReferenceExpression memberReferenceExpression15 = _0024_00245351_002422907;
												ReferenceExpression referenceExpression14 = (_0024_00245350_002422906 = new ReferenceExpression(LexicalInfo.Empty));
												string text76 = (_0024_00245350_002422906.Name = "enumerator");
												Expression expression90 = (memberReferenceExpression15.Target = _0024_00245350_002422906);
												array15[0] = _0024_00245351_002422907;
												ExpressionCollection expressionCollection14 = (methodInvocationExpression24.Arguments = ExpressionCollection.FromArray(array15));
												array14[0] = Statement.Lift(_0024_00245352_002422908);
												StatementCollection statementCollection10 = (block24.Statements = StatementCollection.FromArray(array14));
												Block block26 = (whileStatement3.Block = _0024_00245353_002422909);
												array13[0] = Statement.Lift(_0024_00245354_002422910);
												StatementCollection statementCollection12 = (block22.Statements = StatementCollection.FromArray(array13));
												Block block28 = (ifStatement9.TrueBlock = _0024_00245355_002422911);
												IfStatement ifStatement10 = _0024_00245371_002422927;
												Block block29 = (_0024_00245370_002422926 = new Block(LexicalInfo.Empty));
												Block block30 = _0024_00245370_002422926;
												Statement[] array16 = new Statement[1];
												MethodInvocationExpression methodInvocationExpression25 = (_0024_00245369_002422925 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression26 = _0024_00245369_002422925;
												MemberReferenceExpression memberReferenceExpression16 = (_0024_00245358_002422914 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text78 = (_0024_00245358_002422914.Name = "Log");
												MemberReferenceExpression memberReferenceExpression17 = _0024_00245358_002422914;
												MemberReferenceExpression memberReferenceExpression18 = (_0024_00245357_002422913 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text80 = (_0024_00245357_002422913.Name = "Debug");
												MemberReferenceExpression memberReferenceExpression19 = _0024_00245357_002422913;
												ReferenceExpression referenceExpression15 = (_0024_00245356_002422912 = new ReferenceExpression(LexicalInfo.Empty));
												string text82 = (_0024_00245356_002422912.Name = "UnityEngine");
												Expression expression92 = (memberReferenceExpression19.Target = _0024_00245356_002422912);
												Expression expression94 = (memberReferenceExpression17.Target = _0024_00245357_002422913);
												Expression expression96 = (methodInvocationExpression26.Target = _0024_00245358_002422914);
												MethodInvocationExpression methodInvocationExpression27 = _0024_00245369_002422925;
												Expression[] array17 = new Expression[1];
												MethodInvocationExpression methodInvocationExpression28 = (_0024_00245368_002422924 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression29 = _0024_00245368_002422924;
												MemberReferenceExpression memberReferenceExpression20 = (_0024_00245360_002422916 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text84 = (_0024_00245360_002422916.Name = "Format");
												MemberReferenceExpression memberReferenceExpression21 = _0024_00245360_002422916;
												ReferenceExpression referenceExpression16 = (_0024_00245359_002422915 = new ReferenceExpression(LexicalInfo.Empty));
												string text86 = (_0024_00245359_002422915.Name = "string");
												Expression expression98 = (memberReferenceExpression21.Target = _0024_00245359_002422915);
												Expression expression100 = (methodInvocationExpression29.Target = _0024_00245360_002422916);
												MethodInvocationExpression methodInvocationExpression30 = _0024_00245368_002422924;
												Expression[] array18 = new Expression[3];
												StringLiteralExpression stringLiteralExpression5 = (_0024_00245361_002422917 = new StringLiteralExpression(LexicalInfo.Empty));
												string text88 = (_0024_00245361_002422917.Value = "{0}.GetEnumerator() returned'{1}' instead of IEnumerator.");
												array18[0] = _0024_00245361_002422917;
												MethodInvocationExpression methodInvocationExpression31 = (_0024_00245363_002422919 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression32 = _0024_00245363_002422919;
												MemberReferenceExpression memberReferenceExpression22 = (_0024_00245362_002422918 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text90 = (_0024_00245362_002422918.Name = "ToString");
												Expression expression102 = (_0024_00245362_002422918.Target = Expression.Lift(_0024enumerable_002422833));
												Expression expression104 = (methodInvocationExpression32.Target = _0024_00245362_002422918);
												array18[1] = _0024_00245363_002422919;
												MemberReferenceExpression memberReferenceExpression23 = (_0024_00245367_002422923 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text92 = (_0024_00245367_002422923.Name = "Name");
												MemberReferenceExpression memberReferenceExpression24 = _0024_00245367_002422923;
												MethodInvocationExpression methodInvocationExpression33 = (_0024_00245366_002422922 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression34 = _0024_00245366_002422922;
												MemberReferenceExpression memberReferenceExpression25 = (_0024_00245365_002422921 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text94 = (_0024_00245365_002422921.Name = "GetType");
												MemberReferenceExpression memberReferenceExpression26 = _0024_00245365_002422921;
												ReferenceExpression referenceExpression17 = (_0024_00245364_002422920 = new ReferenceExpression(LexicalInfo.Empty));
												string text96 = (_0024_00245364_002422920.Name = "enumerator");
												Expression expression106 = (memberReferenceExpression26.Target = _0024_00245364_002422920);
												Expression expression108 = (methodInvocationExpression34.Target = _0024_00245365_002422921);
												Expression expression110 = (memberReferenceExpression24.Target = _0024_00245366_002422922);
												array18[2] = _0024_00245367_002422923;
												ExpressionCollection expressionCollection16 = (methodInvocationExpression30.Arguments = ExpressionCollection.FromArray(array18));
												array17[0] = _0024_00245368_002422924;
												ExpressionCollection expressionCollection18 = (methodInvocationExpression27.Arguments = ExpressionCollection.FromArray(array17));
												array16[0] = Statement.Lift(_0024_00245369_002422925);
												StatementCollection statementCollection14 = (block30.Statements = StatementCollection.FromArray(array16));
												Block block32 = (ifStatement10.FalseBlock = _0024_00245370_002422926);
												array10[2] = Statement.Lift(_0024_00245371_002422927);
												StatementCollection statementCollection16 = (block16.Statements = StatementCollection.FromArray(array10));
												Block block34 = (tryStatement2.ProtectedBlock = _0024_00245372_002422928);
												TryStatement tryStatement3 = _0024_00245386_002422942;
												Block block35 = (_0024_00245385_002422941 = new Block(LexicalInfo.Empty));
												Block block36 = _0024_00245385_002422941;
												Statement[] array19 = new Statement[2];
												DeclarationStatement declarationStatement9 = (_0024_00245378_002422934 = new DeclarationStatement(LexicalInfo.Empty));
												DeclarationStatement declarationStatement10 = _0024_00245378_002422934;
												Declaration declaration13 = (_0024_00245374_002422930 = new Declaration(LexicalInfo.Empty));
												string text98 = (_0024_00245374_002422930.Name = "disposable");
												Declaration declaration14 = _0024_00245374_002422930;
												SimpleTypeReference simpleTypeReference7 = (_0024_00245373_002422929 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag14 = (_0024_00245373_002422929.IsPointer = false);
												string text100 = (_0024_00245373_002422929.Name = "IDisposable");
												TypeReference typeReference17 = (declaration14.Type = _0024_00245373_002422929);
												Declaration declaration16 = (declarationStatement10.Declaration = _0024_00245374_002422930);
												DeclarationStatement declarationStatement11 = _0024_00245378_002422934;
												TryCastExpression tryCastExpression2 = (_0024_00245377_002422933 = new TryCastExpression(LexicalInfo.Empty));
												TryCastExpression tryCastExpression3 = _0024_00245377_002422933;
												ReferenceExpression referenceExpression18 = (_0024_00245375_002422931 = new ReferenceExpression(LexicalInfo.Empty));
												string text102 = (_0024_00245375_002422931.Name = "enumerator");
												Expression expression112 = (tryCastExpression3.Target = _0024_00245375_002422931);
												TryCastExpression tryCastExpression4 = _0024_00245377_002422933;
												SimpleTypeReference simpleTypeReference8 = (_0024_00245376_002422932 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag16 = (_0024_00245376_002422932.IsPointer = false);
												string text104 = (_0024_00245376_002422932.Name = "IDisposable");
												TypeReference typeReference19 = (tryCastExpression4.Type = _0024_00245376_002422932);
												Expression expression114 = (declarationStatement11.Initializer = _0024_00245377_002422933);
												array19[0] = Statement.Lift(_0024_00245378_002422934);
												IfStatement ifStatement11 = (_0024_00245384_002422940 = new IfStatement(LexicalInfo.Empty));
												IfStatement ifStatement12 = _0024_00245384_002422940;
												ReferenceExpression referenceExpression19 = (_0024_00245379_002422935 = new ReferenceExpression(LexicalInfo.Empty));
												string text106 = (_0024_00245379_002422935.Name = "disposable");
												Expression expression116 = (ifStatement12.Condition = _0024_00245379_002422935);
												IfStatement ifStatement13 = _0024_00245384_002422940;
												Block block37 = (_0024_00245383_002422939 = new Block(LexicalInfo.Empty));
												Block block38 = _0024_00245383_002422939;
												Statement[] array20 = new Statement[1];
												MethodInvocationExpression methodInvocationExpression35 = (_0024_00245382_002422938 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression36 = _0024_00245382_002422938;
												MemberReferenceExpression memberReferenceExpression27 = (_0024_00245381_002422937 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text108 = (_0024_00245381_002422937.Name = "Dispose");
												MemberReferenceExpression memberReferenceExpression28 = _0024_00245381_002422937;
												ReferenceExpression referenceExpression20 = (_0024_00245380_002422936 = new ReferenceExpression(LexicalInfo.Empty));
												string text110 = (_0024_00245380_002422936.Name = "disposable");
												Expression expression118 = (memberReferenceExpression28.Target = _0024_00245380_002422936);
												Expression expression120 = (methodInvocationExpression36.Target = _0024_00245381_002422937);
												array20[0] = Statement.Lift(_0024_00245382_002422938);
												StatementCollection statementCollection18 = (block38.Statements = StatementCollection.FromArray(array20));
												Block block40 = (ifStatement13.TrueBlock = _0024_00245383_002422939);
												array19[1] = Statement.Lift(_0024_00245384_002422940);
												StatementCollection statementCollection20 = (block36.Statements = StatementCollection.FromArray(array19));
												Block block42 = (tryStatement3.EnsureBlock = _0024_00245385_002422941);
												array[6] = Statement.Lift(_0024_00245386_002422942);
												StatementCollection statementCollection22 = (block2.Statements = StatementCollection.FromArray(array));
												_0024z_002422944 = _0024_00245387_002422943;
												_0024z_002422944.LexicalInfo = _0024safe_for2_002423062.LexicalInfo;
												result = (Yield(2, _0024z_002422944) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
						}
					}
					if (_0024_0024match_002466_002422827 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002470_002422945 = _0024_0024match_002466_002422827);
						if (true && _0024_0024match_002470_002422945.Name == "safe_for2" && 1 == ((ICollection)_0024_0024match_002470_002422945.Arguments).Count && _0024_0024match_002470_002422945.Arguments[0] is BinaryExpression)
						{
							BinaryExpression binaryExpression17 = (_0024_0024match_002471_002422946 = (BinaryExpression)_0024_0024match_002470_002422945.Arguments[0]);
							if (true && _0024_0024match_002471_002422946.Operator == BinaryOperatorType.Member)
							{
								Expression expression121 = (_0024x_002422947 = _0024_0024match_002471_002422946.Left);
								if (true)
								{
									Expression expression122 = (_0024enumerable_002422833 = _0024_0024match_002471_002422946.Right);
									if (true)
									{
										Block block43 = (_0024_00245501_002423061 = new Block(LexicalInfo.Empty));
										Block block44 = _0024_00245501_002423061;
										Statement[] array21 = new Statement[7];
										ReturnStatement returnStatement5 = (_0024_00245390_002422950 = new ReturnStatement(LexicalInfo.Empty));
										ReturnStatement returnStatement6 = _0024_00245390_002422950;
										StatementModifier statementModifier5 = (_0024_00245389_002422949 = new StatementModifier(LexicalInfo.Empty));
										StatementModifierType statementModifierType4 = (_0024_00245389_002422949.Type = StatementModifierType.If);
										StatementModifier statementModifier6 = _0024_00245389_002422949;
										UnaryExpression unaryExpression8 = (_0024_00245388_002422948 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType10 = (_0024_00245388_002422948.Operator = UnaryOperatorType.LogicalNot);
										Expression expression124 = (_0024_00245388_002422948.Operand = Expression.Lift(_0024enumerable_002422833));
										Expression expression126 = (statementModifier6.Condition = _0024_00245388_002422948);
										StatementModifier statementModifier8 = (returnStatement6.Modifier = _0024_00245389_002422949);
										array21[0] = Statement.Lift(_0024_00245390_002422950);
										DeclarationStatement declarationStatement12 = (_0024_00245411_002422971 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement13 = _0024_00245411_002422971;
										Declaration declaration17 = (_0024_00245392_002422952 = new Declaration(LexicalInfo.Empty));
										string text112 = (_0024_00245392_002422952.Name = "listType");
										Declaration declaration18 = _0024_00245392_002422952;
										SimpleTypeReference simpleTypeReference9 = (_0024_00245391_002422951 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag18 = (_0024_00245391_002422951.IsPointer = false);
										string text114 = (_0024_00245391_002422951.Name = "Type");
										TypeReference typeReference21 = (declaration18.Type = _0024_00245391_002422951);
										Declaration declaration20 = (declarationStatement13.Declaration = _0024_00245392_002422952);
										DeclarationStatement declarationStatement14 = _0024_00245411_002422971;
										MethodInvocationExpression methodInvocationExpression37 = (_0024_00245410_002422970 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression38 = _0024_00245410_002422970;
										MemberReferenceExpression memberReferenceExpression29 = (_0024_00245397_002422957 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text116 = (_0024_00245397_002422957.Name = "First");
										MemberReferenceExpression memberReferenceExpression30 = _0024_00245397_002422957;
										MethodInvocationExpression methodInvocationExpression39 = (_0024_00245396_002422956 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression40 = _0024_00245396_002422956;
										MemberReferenceExpression memberReferenceExpression31 = (_0024_00245395_002422955 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text118 = (_0024_00245395_002422955.Name = "GetInterfaces");
										MemberReferenceExpression memberReferenceExpression32 = _0024_00245395_002422955;
										MethodInvocationExpression methodInvocationExpression41 = (_0024_00245394_002422954 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression42 = _0024_00245394_002422954;
										MemberReferenceExpression memberReferenceExpression33 = (_0024_00245393_002422953 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text120 = (_0024_00245393_002422953.Name = "GetType");
										Expression expression128 = (_0024_00245393_002422953.Target = Expression.Lift(_0024enumerable_002422833));
										Expression expression130 = (methodInvocationExpression42.Target = _0024_00245393_002422953);
										Expression expression132 = (memberReferenceExpression32.Target = _0024_00245394_002422954);
										Expression expression134 = (methodInvocationExpression40.Target = _0024_00245395_002422955);
										Expression expression136 = (memberReferenceExpression30.Target = _0024_00245396_002422956);
										Expression expression138 = (methodInvocationExpression38.Target = _0024_00245397_002422957);
										MethodInvocationExpression methodInvocationExpression43 = _0024_00245410_002422970;
										Expression[] array22 = new Expression[1];
										BlockExpression blockExpression7 = (_0024_00245409_002422969 = new BlockExpression(LexicalInfo.Empty));
										BlockExpression blockExpression8 = _0024_00245409_002422969;
										ParameterDeclaration[] array23 = new ParameterDeclaration[1];
										ParameterDeclaration parameterDeclaration3 = (_0024_00245398_002422958 = new ParameterDeclaration(LexicalInfo.Empty));
										string text122 = (_0024_00245398_002422958.Name = "x");
										array23[0] = _0024_00245398_002422958;
										ParameterDeclarationCollection parameterDeclarationCollection6 = (blockExpression8.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array23));
										BlockExpression blockExpression9 = _0024_00245409_002422969;
										Block block45 = (_0024_00245408_002422968 = new Block(LexicalInfo.Empty));
										Block block46 = _0024_00245408_002422968;
										Statement[] array24 = new Statement[1];
										ReturnStatement returnStatement7 = (_0024_00245407_002422967 = new ReturnStatement(LexicalInfo.Empty));
										ReturnStatement returnStatement8 = _0024_00245407_002422967;
										BinaryExpression binaryExpression18 = (_0024_00245406_002422966 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType12 = (_0024_00245406_002422966.Operator = BinaryOperatorType.And);
										BinaryExpression binaryExpression19 = _0024_00245406_002422966;
										UnaryExpression unaryExpression9 = (_0024_00245401_002422961 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType12 = (_0024_00245401_002422961.Operator = UnaryOperatorType.LogicalNot);
										UnaryExpression unaryExpression10 = _0024_00245401_002422961;
										MemberReferenceExpression memberReferenceExpression34 = (_0024_00245400_002422960 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text124 = (_0024_00245400_002422960.Name = "IsGenericType");
										MemberReferenceExpression memberReferenceExpression35 = _0024_00245400_002422960;
										ReferenceExpression referenceExpression21 = (_0024_00245399_002422959 = new ReferenceExpression(LexicalInfo.Empty));
										string text126 = (_0024_00245399_002422959.Name = "x");
										Expression expression140 = (memberReferenceExpression35.Target = _0024_00245399_002422959);
										Expression expression142 = (unaryExpression10.Operand = _0024_00245400_002422960);
										Expression expression144 = (binaryExpression19.Left = _0024_00245401_002422961);
										BinaryExpression binaryExpression20 = _0024_00245406_002422966;
										BinaryExpression binaryExpression21 = (_0024_00245405_002422965 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType14 = (_0024_00245405_002422965.Operator = BinaryOperatorType.ReferenceEquality);
										BinaryExpression binaryExpression22 = _0024_00245405_002422965;
										ReferenceExpression referenceExpression22 = (_0024_00245402_002422962 = new ReferenceExpression(LexicalInfo.Empty));
										string text128 = (_0024_00245402_002422962.Name = "x");
										Expression expression146 = (binaryExpression22.Left = _0024_00245402_002422962);
										BinaryExpression binaryExpression23 = _0024_00245405_002422965;
										TypeofExpression typeofExpression5 = (_0024_00245404_002422964 = new TypeofExpression(LexicalInfo.Empty));
										TypeofExpression typeofExpression6 = _0024_00245404_002422964;
										SimpleTypeReference simpleTypeReference10 = (_0024_00245403_002422963 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag20 = (_0024_00245403_002422963.IsPointer = false);
										string text130 = (_0024_00245403_002422963.Name = "IEnumerable");
										TypeReference typeReference23 = (typeofExpression6.Type = _0024_00245403_002422963);
										Expression expression148 = (binaryExpression23.Right = _0024_00245404_002422964);
										Expression expression150 = (binaryExpression20.Right = _0024_00245405_002422965);
										Expression expression152 = (returnStatement8.Expression = _0024_00245406_002422966);
										array24[0] = Statement.Lift(_0024_00245407_002422967);
										StatementCollection statementCollection24 = (block46.Statements = StatementCollection.FromArray(array24));
										Block block48 = (blockExpression9.Body = _0024_00245408_002422968);
										array22[0] = _0024_00245409_002422969;
										ExpressionCollection expressionCollection20 = (methodInvocationExpression43.Arguments = ExpressionCollection.FromArray(array22));
										Expression expression154 = (declarationStatement14.Initializer = _0024_00245410_002422970);
										array21[1] = Statement.Lift(_0024_00245411_002422971);
										IfStatement ifStatement14 = (_0024_00245420_002422980 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement15 = _0024_00245420_002422980;
										UnaryExpression unaryExpression11 = (_0024_00245413_002422973 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType14 = (_0024_00245413_002422973.Operator = UnaryOperatorType.LogicalNot);
										UnaryExpression unaryExpression12 = _0024_00245413_002422973;
										ReferenceExpression referenceExpression23 = (_0024_00245412_002422972 = new ReferenceExpression(LexicalInfo.Empty));
										string text132 = (_0024_00245412_002422972.Name = "listType");
										Expression expression156 = (unaryExpression12.Operand = _0024_00245412_002422972);
										Expression expression158 = (ifStatement15.Condition = _0024_00245413_002422973);
										IfStatement ifStatement16 = _0024_00245420_002422980;
										Block block49 = (_0024_00245419_002422979 = new Block(LexicalInfo.Empty));
										Block block50 = _0024_00245419_002422979;
										Statement[] array25 = new Statement[1];
										RaiseStatement raiseStatement5 = (_0024_00245418_002422978 = new RaiseStatement(LexicalInfo.Empty));
										RaiseStatement raiseStatement6 = _0024_00245418_002422978;
										MethodInvocationExpression methodInvocationExpression44 = (_0024_00245417_002422977 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression45 = _0024_00245417_002422977;
										ReferenceExpression referenceExpression24 = (_0024_00245414_002422974 = new ReferenceExpression(LexicalInfo.Empty));
										string text134 = (_0024_00245414_002422974.Name = "ArgumentException");
										Expression expression160 = (methodInvocationExpression45.Target = _0024_00245414_002422974);
										MethodInvocationExpression methodInvocationExpression46 = _0024_00245417_002422977;
										Expression[] array26 = new Expression[2];
										StringLiteralExpression stringLiteralExpression6 = (_0024_00245415_002422975 = new StringLiteralExpression(LexicalInfo.Empty));
										string text136 = (_0024_00245415_002422975.Value = "Object does not implement IEnumerableinterface");
										array26[0] = _0024_00245415_002422975;
										StringLiteralExpression stringLiteralExpression7 = (_0024_00245416_002422976 = new StringLiteralExpression(LexicalInfo.Empty));
										string text138 = (_0024_00245416_002422976.Value = "enumerable");
										array26[1] = _0024_00245416_002422976;
										ExpressionCollection expressionCollection22 = (methodInvocationExpression46.Arguments = ExpressionCollection.FromArray(array26));
										Expression expression162 = (raiseStatement6.Exception = _0024_00245417_002422977);
										array25[0] = Statement.Lift(_0024_00245418_002422978);
										StatementCollection statementCollection26 = (block50.Statements = StatementCollection.FromArray(array25));
										Block block52 = (ifStatement16.TrueBlock = _0024_00245419_002422979);
										array21[2] = Statement.Lift(_0024_00245420_002422980);
										DeclarationStatement declarationStatement15 = (_0024_00245427_002422987 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement16 = _0024_00245427_002422987;
										Declaration declaration21 = (_0024_00245422_002422982 = new Declaration(LexicalInfo.Empty));
										string text140 = (_0024_00245422_002422982.Name = "method");
										Declaration declaration22 = _0024_00245422_002422982;
										SimpleTypeReference simpleTypeReference11 = (_0024_00245421_002422981 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag22 = (_0024_00245421_002422981.IsPointer = false);
										string text142 = (_0024_00245421_002422981.Name = "MethodInfo");
										TypeReference typeReference25 = (declaration22.Type = _0024_00245421_002422981);
										Declaration declaration24 = (declarationStatement16.Declaration = _0024_00245422_002422982);
										DeclarationStatement declarationStatement17 = _0024_00245427_002422987;
										MethodInvocationExpression methodInvocationExpression47 = (_0024_00245426_002422986 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression48 = _0024_00245426_002422986;
										MemberReferenceExpression memberReferenceExpression36 = (_0024_00245424_002422984 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text144 = (_0024_00245424_002422984.Name = "GetMethod");
										MemberReferenceExpression memberReferenceExpression37 = _0024_00245424_002422984;
										ReferenceExpression referenceExpression25 = (_0024_00245423_002422983 = new ReferenceExpression(LexicalInfo.Empty));
										string text146 = (_0024_00245423_002422983.Name = "listType");
										Expression expression164 = (memberReferenceExpression37.Target = _0024_00245423_002422983);
										Expression expression166 = (methodInvocationExpression48.Target = _0024_00245424_002422984);
										MethodInvocationExpression methodInvocationExpression49 = _0024_00245426_002422986;
										Expression[] array27 = new Expression[1];
										StringLiteralExpression stringLiteralExpression8 = (_0024_00245425_002422985 = new StringLiteralExpression(LexicalInfo.Empty));
										string text148 = (_0024_00245425_002422985.Value = "GetEnumerator");
										array27[0] = _0024_00245425_002422985;
										ExpressionCollection expressionCollection24 = (methodInvocationExpression49.Arguments = ExpressionCollection.FromArray(array27));
										Expression expression168 = (declarationStatement17.Initializer = _0024_00245426_002422986);
										array21[3] = Statement.Lift(_0024_00245427_002422987);
										IfStatement ifStatement17 = (_0024_00245435_002422995 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement18 = _0024_00245435_002422995;
										UnaryExpression unaryExpression13 = (_0024_00245429_002422989 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType16 = (_0024_00245429_002422989.Operator = UnaryOperatorType.LogicalNot);
										UnaryExpression unaryExpression14 = _0024_00245429_002422989;
										ReferenceExpression referenceExpression26 = (_0024_00245428_002422988 = new ReferenceExpression(LexicalInfo.Empty));
										string text150 = (_0024_00245428_002422988.Name = "method");
										Expression expression170 = (unaryExpression14.Operand = _0024_00245428_002422988);
										Expression expression172 = (ifStatement18.Condition = _0024_00245429_002422989);
										IfStatement ifStatement19 = _0024_00245435_002422995;
										Block block53 = (_0024_00245434_002422994 = new Block(LexicalInfo.Empty));
										Block block54 = _0024_00245434_002422994;
										Statement[] array28 = new Statement[1];
										RaiseStatement raiseStatement7 = (_0024_00245433_002422993 = new RaiseStatement(LexicalInfo.Empty));
										RaiseStatement raiseStatement8 = _0024_00245433_002422993;
										MethodInvocationExpression methodInvocationExpression50 = (_0024_00245432_002422992 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression51 = _0024_00245432_002422992;
										ReferenceExpression referenceExpression27 = (_0024_00245430_002422990 = new ReferenceExpression(LexicalInfo.Empty));
										string text152 = (_0024_00245430_002422990.Name = "InvalidOperationException");
										Expression expression174 = (methodInvocationExpression51.Target = _0024_00245430_002422990);
										MethodInvocationExpression methodInvocationExpression52 = _0024_00245432_002422992;
										Expression[] array29 = new Expression[1];
										StringLiteralExpression stringLiteralExpression9 = (_0024_00245431_002422991 = new StringLiteralExpression(LexicalInfo.Empty));
										string text154 = (_0024_00245431_002422991.Value = "Failed to get 'GetEnumberator()'method info from IEnumerable type");
										array29[0] = _0024_00245431_002422991;
										ExpressionCollection expressionCollection26 = (methodInvocationExpression52.Arguments = ExpressionCollection.FromArray(array29));
										Expression expression176 = (raiseStatement8.Exception = _0024_00245432_002422992);
										array28[0] = Statement.Lift(_0024_00245433_002422993);
										StatementCollection statementCollection28 = (block54.Statements = StatementCollection.FromArray(array28));
										Block block56 = (ifStatement19.TrueBlock = _0024_00245434_002422994);
										array21[4] = Statement.Lift(_0024_00245435_002422995);
										DeclarationStatement declarationStatement18 = (_0024_00245438_002422998 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement19 = _0024_00245438_002422998;
										Declaration declaration25 = (_0024_00245437_002422997 = new Declaration(LexicalInfo.Empty));
										string text156 = (_0024_00245437_002422997.Name = "enumerator");
										Declaration declaration26 = _0024_00245437_002422997;
										SimpleTypeReference simpleTypeReference12 = (_0024_00245436_002422996 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag24 = (_0024_00245436_002422996.IsPointer = false);
										string text158 = (_0024_00245436_002422996.Name = "IEnumerator");
										TypeReference typeReference27 = (declaration26.Type = _0024_00245436_002422996);
										Declaration declaration28 = (declarationStatement19.Declaration = _0024_00245437_002422997);
										Expression expression178 = (_0024_00245438_002422998.Initializer = new NullLiteralExpression(LexicalInfo.Empty));
										array21[5] = Statement.Lift(_0024_00245438_002422998);
										TryStatement tryStatement4 = (_0024_00245500_002423060 = new TryStatement(LexicalInfo.Empty));
										TryStatement tryStatement5 = _0024_00245500_002423060;
										Block block57 = (_0024_00245486_002423046 = new Block(LexicalInfo.Empty));
										Block block58 = _0024_00245486_002423046;
										Statement[] array30 = new Statement[4];
										BinaryExpression binaryExpression24 = (_0024_00245445_002423005 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType16 = (_0024_00245445_002423005.Operator = BinaryOperatorType.Assign);
										BinaryExpression binaryExpression25 = _0024_00245445_002423005;
										ReferenceExpression referenceExpression28 = (_0024_00245439_002422999 = new ReferenceExpression(LexicalInfo.Empty));
										string text160 = (_0024_00245439_002422999.Name = "enumerator");
										Expression expression180 = (binaryExpression25.Left = _0024_00245439_002422999);
										BinaryExpression binaryExpression26 = _0024_00245445_002423005;
										CastExpression castExpression4 = (_0024_00245444_002423004 = new CastExpression(LexicalInfo.Empty));
										CastExpression castExpression5 = _0024_00245444_002423004;
										MethodInvocationExpression methodInvocationExpression53 = (_0024_00245442_002423002 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression54 = _0024_00245442_002423002;
										MemberReferenceExpression memberReferenceExpression38 = (_0024_00245441_002423001 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text162 = (_0024_00245441_002423001.Name = "Invoke");
										MemberReferenceExpression memberReferenceExpression39 = _0024_00245441_002423001;
										ReferenceExpression referenceExpression29 = (_0024_00245440_002423000 = new ReferenceExpression(LexicalInfo.Empty));
										string text164 = (_0024_00245440_002423000.Name = "method");
										Expression expression182 = (memberReferenceExpression39.Target = _0024_00245440_002423000);
										Expression expression184 = (methodInvocationExpression54.Target = _0024_00245441_002423001);
										ExpressionCollection expressionCollection28 = (_0024_00245442_002423002.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024enumerable_002422833), new NullLiteralExpression(LexicalInfo.Empty)));
										Expression expression186 = (castExpression5.Target = _0024_00245442_002423002);
										CastExpression castExpression6 = _0024_00245444_002423004;
										SimpleTypeReference simpleTypeReference13 = (_0024_00245443_002423003 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag26 = (_0024_00245443_002423003.IsPointer = false);
										string text166 = (_0024_00245443_002423003.Name = "IEnumerator");
										TypeReference typeReference29 = (castExpression6.Type = _0024_00245443_002423003);
										Expression expression188 = (binaryExpression26.Right = _0024_00245444_002423004);
										array30[0] = Statement.Lift(_0024_00245445_002423005);
										DeclarationStatement declarationStatement20 = (_0024_00245451_002423011 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement21 = _0024_00245451_002423011;
										Declaration declaration29 = (_0024_00245446_002423006 = new Declaration(LexicalInfo.Empty));
										string text168 = (_0024_00245446_002423006.Name = "_hogemage");
										Declaration declaration31 = (declarationStatement21.Declaration = _0024_00245446_002423006);
										DeclarationStatement declarationStatement22 = _0024_00245451_002423011;
										BlockExpression blockExpression10 = (_0024_00245450_002423010 = new BlockExpression(LexicalInfo.Empty));
										BlockExpression blockExpression11 = _0024_00245450_002423010;
										ParameterDeclaration[] array31 = new ParameterDeclaration[1];
										ParameterDeclaration parameterDeclaration4 = (_0024_00245447_002423007 = new ParameterDeclaration(LexicalInfo.Empty));
										string text170 = (_0024_00245447_002423007.Name = "$");
										string text172 = (_0024_00245447_002423007.Name = CodeSerializer.LiftName((ReferenceExpression)_0024x_002422947));
										array31[0] = _0024_00245447_002423007;
										ParameterDeclarationCollection parameterDeclarationCollection8 = (blockExpression11.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array31));
										BlockExpression blockExpression12 = _0024_00245450_002423010;
										Block block59 = (_0024_00245449_002423009 = new Block(LexicalInfo.Empty));
										Block block60 = _0024_00245449_002423009;
										Statement[] array32 = new Statement[1];
										MethodInvocationExpression methodInvocationExpression55 = (_0024_00245448_002423008 = new MethodInvocationExpression(LexicalInfo.Empty));
										Expression expression190 = (_0024_00245448_002423008.Target = Expression.Lift(_0024safe_for2_002423062.Body));
										ExpressionCollection expressionCollection30 = (_0024_00245448_002423008.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024x_002422947)));
										array32[0] = Statement.Lift(_0024_00245448_002423008);
										StatementCollection statementCollection30 = (block60.Statements = StatementCollection.FromArray(array32));
										Block block62 = (blockExpression12.Body = _0024_00245449_002423009);
										Expression expression192 = (declarationStatement22.Initializer = _0024_00245450_002423010);
										array30[1] = Statement.Lift(_0024_00245451_002423011);
										MemberReferenceExpression memberReferenceExpression40 = (_0024_00245455_002423015 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text174 = (_0024_00245455_002423015.Name = "LexicalInfo");
										MemberReferenceExpression memberReferenceExpression41 = _0024_00245455_002423015;
										MethodInvocationExpression methodInvocationExpression56 = (_0024_00245454_002423014 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression57 = _0024_00245454_002423014;
										ReferenceExpression referenceExpression30 = (_0024_00245452_002423012 = new ReferenceExpression(LexicalInfo.Empty));
										string text176 = (_0024_00245452_002423012.Name = "ReferenceExpression");
										Expression expression194 = (methodInvocationExpression57.Target = _0024_00245452_002423012);
										MethodInvocationExpression methodInvocationExpression58 = _0024_00245454_002423014;
										Expression[] array33 = new Expression[1];
										ReferenceExpression referenceExpression31 = (_0024_00245453_002423013 = new ReferenceExpression(LexicalInfo.Empty));
										string text178 = (_0024_00245453_002423013.Name = "_hogemage");
										array33[0] = _0024_00245453_002423013;
										ExpressionCollection expressionCollection32 = (methodInvocationExpression58.Arguments = ExpressionCollection.FromArray(array33));
										Expression expression196 = (memberReferenceExpression41.Target = _0024_00245454_002423014);
										array30[2] = Statement.Lift(_0024_00245455_002423015);
										IfStatement ifStatement20 = (_0024_00245485_002423045 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement21 = _0024_00245485_002423045;
										BinaryExpression binaryExpression27 = (_0024_00245459_002423019 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType18 = (_0024_00245459_002423019.Operator = BinaryOperatorType.TypeTest);
										BinaryExpression binaryExpression28 = _0024_00245459_002423019;
										ReferenceExpression referenceExpression32 = (_0024_00245456_002423016 = new ReferenceExpression(LexicalInfo.Empty));
										string text180 = (_0024_00245456_002423016.Name = "enumerator");
										Expression expression198 = (binaryExpression28.Left = _0024_00245456_002423016);
										BinaryExpression binaryExpression29 = _0024_00245459_002423019;
										TypeofExpression typeofExpression7 = (_0024_00245458_002423018 = new TypeofExpression(LexicalInfo.Empty));
										TypeofExpression typeofExpression8 = _0024_00245458_002423018;
										SimpleTypeReference simpleTypeReference14 = (_0024_00245457_002423017 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag28 = (_0024_00245457_002423017.IsPointer = false);
										string text182 = (_0024_00245457_002423017.Name = "IEnumerator");
										TypeReference typeReference31 = (typeofExpression8.Type = _0024_00245457_002423017);
										Expression expression200 = (binaryExpression29.Right = _0024_00245458_002423018);
										Expression expression202 = (ifStatement21.Condition = _0024_00245459_002423019);
										IfStatement ifStatement22 = _0024_00245485_002423045;
										Block block63 = (_0024_00245469_002423029 = new Block(LexicalInfo.Empty));
										Block block64 = _0024_00245469_002423029;
										Statement[] array34 = new Statement[1];
										WhileStatement whileStatement4 = (_0024_00245468_002423028 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement5 = _0024_00245468_002423028;
										MethodInvocationExpression methodInvocationExpression59 = (_0024_00245462_002423022 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression60 = _0024_00245462_002423022;
										MemberReferenceExpression memberReferenceExpression42 = (_0024_00245461_002423021 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text184 = (_0024_00245461_002423021.Name = "MoveNext");
										MemberReferenceExpression memberReferenceExpression43 = _0024_00245461_002423021;
										ReferenceExpression referenceExpression33 = (_0024_00245460_002423020 = new ReferenceExpression(LexicalInfo.Empty));
										string text186 = (_0024_00245460_002423020.Name = "enumerator");
										Expression expression204 = (memberReferenceExpression43.Target = _0024_00245460_002423020);
										Expression expression206 = (methodInvocationExpression60.Target = _0024_00245461_002423021);
										Expression expression208 = (whileStatement5.Condition = _0024_00245462_002423022);
										WhileStatement whileStatement6 = _0024_00245468_002423028;
										Block block65 = (_0024_00245467_002423027 = new Block(LexicalInfo.Empty));
										Block block66 = _0024_00245467_002423027;
										Statement[] array35 = new Statement[1];
										MethodInvocationExpression methodInvocationExpression61 = (_0024_00245466_002423026 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression62 = _0024_00245466_002423026;
										ReferenceExpression referenceExpression34 = (_0024_00245463_002423023 = new ReferenceExpression(LexicalInfo.Empty));
										string text188 = (_0024_00245463_002423023.Name = "_hogemage");
										Expression expression210 = (methodInvocationExpression62.Target = _0024_00245463_002423023);
										MethodInvocationExpression methodInvocationExpression63 = _0024_00245466_002423026;
										Expression[] array36 = new Expression[1];
										MemberReferenceExpression memberReferenceExpression44 = (_0024_00245465_002423025 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text190 = (_0024_00245465_002423025.Name = "Current");
										MemberReferenceExpression memberReferenceExpression45 = _0024_00245465_002423025;
										ReferenceExpression referenceExpression35 = (_0024_00245464_002423024 = new ReferenceExpression(LexicalInfo.Empty));
										string text192 = (_0024_00245464_002423024.Name = "enumerator");
										Expression expression212 = (memberReferenceExpression45.Target = _0024_00245464_002423024);
										array36[0] = _0024_00245465_002423025;
										ExpressionCollection expressionCollection34 = (methodInvocationExpression63.Arguments = ExpressionCollection.FromArray(array36));
										array35[0] = Statement.Lift(_0024_00245466_002423026);
										StatementCollection statementCollection32 = (block66.Statements = StatementCollection.FromArray(array35));
										Block block68 = (whileStatement6.Block = _0024_00245467_002423027);
										array34[0] = Statement.Lift(_0024_00245468_002423028);
										StatementCollection statementCollection34 = (block64.Statements = StatementCollection.FromArray(array34));
										Block block70 = (ifStatement22.TrueBlock = _0024_00245469_002423029);
										IfStatement ifStatement23 = _0024_00245485_002423045;
										Block block71 = (_0024_00245484_002423044 = new Block(LexicalInfo.Empty));
										Block block72 = _0024_00245484_002423044;
										Statement[] array37 = new Statement[1];
										MethodInvocationExpression methodInvocationExpression64 = (_0024_00245483_002423043 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression65 = _0024_00245483_002423043;
										MemberReferenceExpression memberReferenceExpression46 = (_0024_00245472_002423032 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text194 = (_0024_00245472_002423032.Name = "Log");
										MemberReferenceExpression memberReferenceExpression47 = _0024_00245472_002423032;
										MemberReferenceExpression memberReferenceExpression48 = (_0024_00245471_002423031 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text196 = (_0024_00245471_002423031.Name = "Debug");
										MemberReferenceExpression memberReferenceExpression49 = _0024_00245471_002423031;
										ReferenceExpression referenceExpression36 = (_0024_00245470_002423030 = new ReferenceExpression(LexicalInfo.Empty));
										string text198 = (_0024_00245470_002423030.Name = "UnityEngine");
										Expression expression214 = (memberReferenceExpression49.Target = _0024_00245470_002423030);
										Expression expression216 = (memberReferenceExpression47.Target = _0024_00245471_002423031);
										Expression expression218 = (methodInvocationExpression65.Target = _0024_00245472_002423032);
										MethodInvocationExpression methodInvocationExpression66 = _0024_00245483_002423043;
										Expression[] array38 = new Expression[1];
										MethodInvocationExpression methodInvocationExpression67 = (_0024_00245482_002423042 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression68 = _0024_00245482_002423042;
										MemberReferenceExpression memberReferenceExpression50 = (_0024_00245474_002423034 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text200 = (_0024_00245474_002423034.Name = "Format");
										MemberReferenceExpression memberReferenceExpression51 = _0024_00245474_002423034;
										ReferenceExpression referenceExpression37 = (_0024_00245473_002423033 = new ReferenceExpression(LexicalInfo.Empty));
										string text202 = (_0024_00245473_002423033.Name = "string");
										Expression expression220 = (memberReferenceExpression51.Target = _0024_00245473_002423033);
										Expression expression222 = (methodInvocationExpression68.Target = _0024_00245474_002423034);
										MethodInvocationExpression methodInvocationExpression69 = _0024_00245482_002423042;
										Expression[] array39 = new Expression[3];
										StringLiteralExpression stringLiteralExpression10 = (_0024_00245475_002423035 = new StringLiteralExpression(LexicalInfo.Empty));
										string text204 = (_0024_00245475_002423035.Value = "{0}.GetEnumerator() returned'{1}' instead of IEnumerator.");
										array39[0] = _0024_00245475_002423035;
										MethodInvocationExpression methodInvocationExpression70 = (_0024_00245477_002423037 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression71 = _0024_00245477_002423037;
										MemberReferenceExpression memberReferenceExpression52 = (_0024_00245476_002423036 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text206 = (_0024_00245476_002423036.Name = "ToString");
										Expression expression224 = (_0024_00245476_002423036.Target = Expression.Lift(_0024enumerable_002422833));
										Expression expression226 = (methodInvocationExpression71.Target = _0024_00245476_002423036);
										array39[1] = _0024_00245477_002423037;
										MemberReferenceExpression memberReferenceExpression53 = (_0024_00245481_002423041 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text208 = (_0024_00245481_002423041.Name = "Name");
										MemberReferenceExpression memberReferenceExpression54 = _0024_00245481_002423041;
										MethodInvocationExpression methodInvocationExpression72 = (_0024_00245480_002423040 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression73 = _0024_00245480_002423040;
										MemberReferenceExpression memberReferenceExpression55 = (_0024_00245479_002423039 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text210 = (_0024_00245479_002423039.Name = "GetType");
										MemberReferenceExpression memberReferenceExpression56 = _0024_00245479_002423039;
										ReferenceExpression referenceExpression38 = (_0024_00245478_002423038 = new ReferenceExpression(LexicalInfo.Empty));
										string text212 = (_0024_00245478_002423038.Name = "enumerator");
										Expression expression228 = (memberReferenceExpression56.Target = _0024_00245478_002423038);
										Expression expression230 = (methodInvocationExpression73.Target = _0024_00245479_002423039);
										Expression expression232 = (memberReferenceExpression54.Target = _0024_00245480_002423040);
										array39[2] = _0024_00245481_002423041;
										ExpressionCollection expressionCollection36 = (methodInvocationExpression69.Arguments = ExpressionCollection.FromArray(array39));
										array38[0] = _0024_00245482_002423042;
										ExpressionCollection expressionCollection38 = (methodInvocationExpression66.Arguments = ExpressionCollection.FromArray(array38));
										array37[0] = Statement.Lift(_0024_00245483_002423043);
										StatementCollection statementCollection36 = (block72.Statements = StatementCollection.FromArray(array37));
										Block block74 = (ifStatement23.FalseBlock = _0024_00245484_002423044);
										array30[3] = Statement.Lift(_0024_00245485_002423045);
										StatementCollection statementCollection38 = (block58.Statements = StatementCollection.FromArray(array30));
										Block block76 = (tryStatement5.ProtectedBlock = _0024_00245486_002423046);
										TryStatement tryStatement6 = _0024_00245500_002423060;
										Block block77 = (_0024_00245499_002423059 = new Block(LexicalInfo.Empty));
										Block block78 = _0024_00245499_002423059;
										Statement[] array40 = new Statement[2];
										DeclarationStatement declarationStatement23 = (_0024_00245492_002423052 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement24 = _0024_00245492_002423052;
										Declaration declaration32 = (_0024_00245488_002423048 = new Declaration(LexicalInfo.Empty));
										string text214 = (_0024_00245488_002423048.Name = "disposable");
										Declaration declaration33 = _0024_00245488_002423048;
										SimpleTypeReference simpleTypeReference15 = (_0024_00245487_002423047 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag30 = (_0024_00245487_002423047.IsPointer = false);
										string text216 = (_0024_00245487_002423047.Name = "IDisposable");
										TypeReference typeReference33 = (declaration33.Type = _0024_00245487_002423047);
										Declaration declaration35 = (declarationStatement24.Declaration = _0024_00245488_002423048);
										DeclarationStatement declarationStatement25 = _0024_00245492_002423052;
										TryCastExpression tryCastExpression5 = (_0024_00245491_002423051 = new TryCastExpression(LexicalInfo.Empty));
										TryCastExpression tryCastExpression6 = _0024_00245491_002423051;
										ReferenceExpression referenceExpression39 = (_0024_00245489_002423049 = new ReferenceExpression(LexicalInfo.Empty));
										string text218 = (_0024_00245489_002423049.Name = "enumerator");
										Expression expression234 = (tryCastExpression6.Target = _0024_00245489_002423049);
										TryCastExpression tryCastExpression7 = _0024_00245491_002423051;
										SimpleTypeReference simpleTypeReference16 = (_0024_00245490_002423050 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag32 = (_0024_00245490_002423050.IsPointer = false);
										string text220 = (_0024_00245490_002423050.Name = "IDisposable");
										TypeReference typeReference35 = (tryCastExpression7.Type = _0024_00245490_002423050);
										Expression expression236 = (declarationStatement25.Initializer = _0024_00245491_002423051);
										array40[0] = Statement.Lift(_0024_00245492_002423052);
										IfStatement ifStatement24 = (_0024_00245498_002423058 = new IfStatement(LexicalInfo.Empty));
										IfStatement ifStatement25 = _0024_00245498_002423058;
										ReferenceExpression referenceExpression40 = (_0024_00245493_002423053 = new ReferenceExpression(LexicalInfo.Empty));
										string text222 = (_0024_00245493_002423053.Name = "disposable");
										Expression expression238 = (ifStatement25.Condition = _0024_00245493_002423053);
										IfStatement ifStatement26 = _0024_00245498_002423058;
										Block block79 = (_0024_00245497_002423057 = new Block(LexicalInfo.Empty));
										Block block80 = _0024_00245497_002423057;
										Statement[] array41 = new Statement[1];
										MethodInvocationExpression methodInvocationExpression74 = (_0024_00245496_002423056 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression75 = _0024_00245496_002423056;
										MemberReferenceExpression memberReferenceExpression57 = (_0024_00245495_002423055 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text224 = (_0024_00245495_002423055.Name = "Dispose");
										MemberReferenceExpression memberReferenceExpression58 = _0024_00245495_002423055;
										ReferenceExpression referenceExpression41 = (_0024_00245494_002423054 = new ReferenceExpression(LexicalInfo.Empty));
										string text226 = (_0024_00245494_002423054.Name = "disposable");
										Expression expression240 = (memberReferenceExpression58.Target = _0024_00245494_002423054);
										Expression expression242 = (methodInvocationExpression75.Target = _0024_00245495_002423055);
										array41[0] = Statement.Lift(_0024_00245496_002423056);
										StatementCollection statementCollection40 = (block80.Statements = StatementCollection.FromArray(array41));
										Block block82 = (ifStatement26.TrueBlock = _0024_00245497_002423057);
										array40[1] = Statement.Lift(_0024_00245498_002423058);
										StatementCollection statementCollection42 = (block78.Statements = StatementCollection.FromArray(array40));
										Block block84 = (tryStatement6.EnsureBlock = _0024_00245499_002423059);
										array21[6] = Statement.Lift(_0024_00245500_002423060);
										StatementCollection statementCollection44 = (block44.Statements = StatementCollection.FromArray(array21));
										_0024z_002422944 = _0024_00245501_002423061;
										_0024z_002422944.LexicalInfo = _0024safe_for2_002423062.LexicalInfo;
										result = (Yield(3, _0024z_002422944) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new Exception("safe_for2 macro error: must be a form \"safe_for2 x in enumerable\" or \"safe_for2 x as t in enumerable\"");
				case 2:
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024safe_for2_002423064;

		internal Safe_for2Macro _0024self__002423065;

		public _0024ExpandGeneratorImpl_002422826(MacroStatement safe_for2, Safe_for2Macro self_)
		{
			_0024safe_for2_002423064 = safe_for2;
			_0024self__002423065 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024safe_for2_002423064, _0024self__002423065);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Safe_for2Macro()
	{
	}

	public Safe_for2Macro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement safe_for2)
	{
		return new _0024ExpandGeneratorImpl_002422826(safe_for2, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement safe_for2)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'safe_for2' is using. Read BOO-1077 for more info.");
	}
}
