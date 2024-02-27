using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;

namespace MerlinAPI;

[Serializable]
public sealed class Api_defMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002419549 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002436_002419550;

			internal MacroStatement _0024_0024match_002437_002419551;

			internal ReferenceExpression _0024_0024match_002438_002419552;

			internal string _0024n_002419553;

			internal TryCastExpression _0024_0024match_002439_002419554;

			internal Expression _0024path_002419555;

			internal TypeReference _0024rtype_002419556;

			internal ReferenceExpression _0024_00244837_002419557;

			internal ReferenceExpression _0024stype_002419558;

			internal ReferenceExpression _0024_00244838_002419559;

			internal ReferenceExpression _0024_00244839_002419560;

			internal SimpleTypeReference _0024_00244840_002419561;

			internal TryCastExpression _0024_00244841_002419562;

			internal BinaryExpression _0024_00244842_002419563;

			internal ReferenceExpression _0024_00244843_002419564;

			internal BinaryExpression _0024_00244844_002419565;

			internal MemberReferenceExpression _0024_00244845_002419566;

			internal ReturnStatement _0024_00244846_002419567;

			internal Block _0024_00244847_002419568;

			internal MemberReferenceExpression _0024_00244848_002419569;

			internal ReferenceExpression _0024_00244849_002419570;

			internal MemberReferenceExpression _0024_00244850_002419571;

			internal BinaryExpression _0024_00244851_002419572;

			internal ReturnStatement _0024_00244852_002419573;

			internal Block _0024_00244853_002419574;

			internal IfStatement _0024_00244854_002419575;

			internal Block _0024_00244855_002419576;

			internal Method _0024_00244856_002419577;

			internal SimpleTypeReference _0024_00244857_002419578;

			internal Property _0024_00244858_002419579;

			internal ReferenceExpression _0024_00244859_002419580;

			internal ReferenceExpression _0024_00244860_002419581;

			internal SimpleTypeReference _0024_00244861_002419582;

			internal TryCastExpression _0024_00244862_002419583;

			internal BinaryExpression _0024_00244863_002419584;

			internal ReferenceExpression _0024_00244864_002419585;

			internal BinaryExpression _0024_00244865_002419586;

			internal ReferenceExpression _0024_00244866_002419587;

			internal MemberReferenceExpression _0024_00244867_002419588;

			internal ReferenceExpression _0024_00244868_002419589;

			internal MemberReferenceExpression _0024_00244869_002419590;

			internal MethodInvocationExpression _0024_00244870_002419591;

			internal UnaryExpression _0024_00244871_002419592;

			internal BinaryExpression _0024_00244872_002419593;

			internal ReturnStatement _0024_00244873_002419594;

			internal Block _0024_00244874_002419595;

			internal Method _0024_00244875_002419596;

			internal SimpleTypeReference _0024_00244876_002419597;

			internal Property _0024_00244877_002419598;

			internal ReturnStatement _0024_00244878_002419599;

			internal Block _0024_00244879_002419600;

			internal Method _0024_00244880_002419601;

			internal SimpleTypeReference _0024_00244881_002419602;

			internal Property _0024_00244882_002419603;

			internal ReferenceExpression _0024_00244883_002419604;

			internal ReturnStatement _0024_00244884_002419605;

			internal Block _0024_00244885_002419606;

			internal Method _0024_00244886_002419607;

			internal SimpleTypeReference _0024_00244887_002419608;

			internal Property _0024_00244888_002419609;

			internal ReferenceExpression _0024_00244889_002419610;

			internal TryCastExpression _0024_00244890_002419611;

			internal ReturnStatement _0024_00244891_002419612;

			internal Block _0024_00244892_002419613;

			internal Method _0024_00244893_002419614;

			internal SimpleTypeReference _0024_00244894_002419615;

			internal TypeofExpression _0024_00244895_002419616;

			internal ReturnStatement _0024_00244896_002419617;

			internal Block _0024_00244897_002419618;

			internal Method _0024_00244898_002419619;

			internal MacroStatement _0024_0024match_002440_002419620;

			internal ReferenceExpression _0024_0024match_002441_002419621;

			internal string _0024sn_002419622;

			internal StringLiteralExpression _0024_0024match_002442_002419623;

			internal string _0024spath_002419624;

			internal ReferenceExpression _0024_00244899_002419625;

			internal ReferenceExpression _0024_00244900_002419626;

			internal ReferenceExpression _0024_00244901_002419627;

			internal SimpleTypeReference _0024_00244902_002419628;

			internal TryCastExpression _0024_00244903_002419629;

			internal BinaryExpression _0024_00244904_002419630;

			internal ReferenceExpression _0024_00244905_002419631;

			internal BinaryExpression _0024_00244906_002419632;

			internal MemberReferenceExpression _0024_00244907_002419633;

			internal ReturnStatement _0024_00244908_002419634;

			internal Block _0024_00244909_002419635;

			internal MemberReferenceExpression _0024_00244910_002419636;

			internal ReferenceExpression _0024_00244911_002419637;

			internal MemberReferenceExpression _0024_00244912_002419638;

			internal BinaryExpression _0024_00244913_002419639;

			internal ReturnStatement _0024_00244914_002419640;

			internal Block _0024_00244915_002419641;

			internal IfStatement _0024_00244916_002419642;

			internal Block _0024_00244917_002419643;

			internal Method _0024_00244918_002419644;

			internal SimpleTypeReference _0024_00244919_002419645;

			internal Property _0024_00244920_002419646;

			internal ReferenceExpression _0024_00244921_002419647;

			internal ReferenceExpression _0024_00244922_002419648;

			internal SimpleTypeReference _0024_00244923_002419649;

			internal TryCastExpression _0024_00244924_002419650;

			internal BinaryExpression _0024_00244925_002419651;

			internal ReferenceExpression _0024_00244926_002419652;

			internal BinaryExpression _0024_00244927_002419653;

			internal ReferenceExpression _0024_00244928_002419654;

			internal MemberReferenceExpression _0024_00244929_002419655;

			internal ReferenceExpression _0024_00244930_002419656;

			internal MemberReferenceExpression _0024_00244931_002419657;

			internal MethodInvocationExpression _0024_00244932_002419658;

			internal UnaryExpression _0024_00244933_002419659;

			internal BinaryExpression _0024_00244934_002419660;

			internal ReturnStatement _0024_00244935_002419661;

			internal Block _0024_00244936_002419662;

			internal Method _0024_00244937_002419663;

			internal SimpleTypeReference _0024_00244938_002419664;

			internal Property _0024_00244939_002419665;

			internal SimpleTypeReference _0024_00244940_002419666;

			internal ReferenceExpression _0024_00244941_002419667;

			internal SimpleTypeReference _0024_00244942_002419668;

			internal TryCastExpression _0024_00244943_002419669;

			internal ReturnStatement _0024_00244944_002419670;

			internal Block _0024_00244945_002419671;

			internal Method _0024_00244946_002419672;

			internal SimpleTypeReference _0024_00244947_002419673;

			internal ReferenceExpression _0024_00244948_002419674;

			internal ReturnStatement _0024_00244949_002419675;

			internal Block _0024_00244950_002419676;

			internal Method _0024_00244951_002419677;

			internal SimpleTypeReference _0024_00244952_002419678;

			internal ReferenceExpression _0024_00244953_002419679;

			internal ReturnStatement _0024_00244954_002419680;

			internal Block _0024_00244955_002419681;

			internal Method _0024_00244956_002419682;

			internal SimpleTypeReference _0024_00244957_002419683;

			internal ReferenceExpression _0024_00244958_002419684;

			internal ReturnStatement _0024_00244959_002419685;

			internal Block _0024_00244960_002419686;

			internal Method _0024_00244961_002419687;

			internal ReturnStatement _0024_00244962_002419688;

			internal Block _0024_00244963_002419689;

			internal Method _0024_00244964_002419690;

			internal SimpleTypeReference _0024_00244965_002419691;

			internal Property _0024_00244966_002419692;

			internal ReferenceExpression _0024_00244967_002419693;

			internal ReturnStatement _0024_00244968_002419694;

			internal Block _0024_00244969_002419695;

			internal Method _0024_00244970_002419696;

			internal SimpleTypeReference _0024_00244971_002419697;

			internal Property _0024_00244972_002419698;

			internal MacroStatement _0024api_def_002419699;

			internal Api_defMacro _0024self__002419700;

			public _0024(MacroStatement api_def, Api_defMacro self_)
			{
				_0024api_def_002419699 = api_def;
				_0024self__002419700 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024api_def_002419699 == null)
					{
						throw new ArgumentNullException("api_def");
					}
					_0024self__002419700.__macro = _0024api_def_002419699;
					_0024_0024match_002436_002419550 = _0024api_def_002419699;
					if (_0024_0024match_002436_002419550 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002437_002419551 = _0024_0024match_002436_002419550);
						if (true && _0024_0024match_002437_002419551.Name == "api_def" && 2 == ((ICollection)_0024_0024match_002437_002419551.Arguments).Count && _0024_0024match_002437_002419551.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression16 = (_0024_0024match_002438_002419552 = (ReferenceExpression)_0024_0024match_002437_002419551.Arguments[0]);
							if (true)
							{
								string text87 = (_0024n_002419553 = _0024_0024match_002438_002419552.Name);
								if (true && _0024_0024match_002437_002419551.Arguments[1] is TryCastExpression)
								{
									TryCastExpression tryCastExpression9 = (_0024_0024match_002439_002419554 = (TryCastExpression)_0024_0024match_002437_002419551.Arguments[1]);
									if (true)
									{
										Expression expression65 = (_0024path_002419555 = _0024_0024match_002439_002419554.Target);
										if (true)
										{
											TypeReference typeReference27 = (_0024rtype_002419556 = _0024_0024match_002439_002419554.Type);
											if (true)
											{
												ReferenceExpression referenceExpression17 = (_0024_00244837_002419557 = new ReferenceExpression());
												string text89 = (_0024_00244837_002419557.Name = _0024n_002419553);
												_0024stype_002419558 = _0024_00244837_002419557;
												if (_0024n_002419553 == "Game")
												{
													Property property16 = (_0024_00244858_002419579 = new Property(LexicalInfo.Empty));
													TypeMemberModifiers typeMemberModifiers20 = (_0024_00244858_002419579.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
													string text91 = (_0024_00244858_002419579.Name = "IsOk");
													Property property17 = _0024_00244858_002419579;
													Method method32 = (_0024_00244856_002419577 = new Method(LexicalInfo.Empty));
													string text93 = (_0024_00244856_002419577.Name = "get");
													Method method33 = _0024_00244856_002419577;
													Block block37 = (_0024_00244855_002419576 = new Block(LexicalInfo.Empty));
													Block block38 = _0024_00244855_002419576;
													Statement[] array12 = new Statement[2];
													BinaryExpression binaryExpression17 = (_0024_00244842_002419563 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType14 = (_0024_00244842_002419563.Operator = BinaryOperatorType.Assign);
													BinaryExpression binaryExpression18 = _0024_00244842_002419563;
													ReferenceExpression referenceExpression18 = (_0024_00244838_002419559 = new ReferenceExpression(LexicalInfo.Empty));
													string text95 = (_0024_00244838_002419559.Name = "rsp");
													Expression expression67 = (binaryExpression18.Left = _0024_00244838_002419559);
													BinaryExpression binaryExpression19 = _0024_00244842_002419563;
													TryCastExpression tryCastExpression10 = (_0024_00244841_002419562 = new TryCastExpression(LexicalInfo.Empty));
													TryCastExpression tryCastExpression11 = _0024_00244841_002419562;
													ReferenceExpression referenceExpression19 = (_0024_00244839_002419560 = new ReferenceExpression(LexicalInfo.Empty));
													string text97 = (_0024_00244839_002419560.Name = "ResponseObj");
													Expression expression69 = (tryCastExpression11.Target = _0024_00244839_002419560);
													TryCastExpression tryCastExpression12 = _0024_00244841_002419562;
													SimpleTypeReference simpleTypeReference11 = (_0024_00244840_002419561 = new SimpleTypeReference(LexicalInfo.Empty));
													bool flag22 = (_0024_00244840_002419561.IsPointer = false);
													string text99 = (_0024_00244840_002419561.Name = "GameApiResponseBase");
													TypeReference typeReference29 = (tryCastExpression12.Type = _0024_00244840_002419561);
													Expression expression71 = (binaryExpression19.Right = _0024_00244841_002419562);
													array12[0] = Statement.Lift(_0024_00244842_002419563);
													IfStatement ifStatement = (_0024_00244854_002419575 = new IfStatement(LexicalInfo.Empty));
													IfStatement ifStatement2 = _0024_00244854_002419575;
													BinaryExpression binaryExpression20 = (_0024_00244844_002419565 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType16 = (_0024_00244844_002419565.Operator = BinaryOperatorType.Equality);
													BinaryExpression binaryExpression21 = _0024_00244844_002419565;
													ReferenceExpression referenceExpression20 = (_0024_00244843_002419564 = new ReferenceExpression(LexicalInfo.Empty));
													string text101 = (_0024_00244843_002419564.Name = "rsp");
													Expression expression73 = (binaryExpression21.Left = _0024_00244843_002419564);
													Expression expression75 = (_0024_00244844_002419565.Right = new NullLiteralExpression(LexicalInfo.Empty));
													Expression expression77 = (ifStatement2.Condition = _0024_00244844_002419565);
													IfStatement ifStatement3 = _0024_00244854_002419575;
													Block block39 = (_0024_00244847_002419568 = new Block(LexicalInfo.Empty));
													Block block40 = _0024_00244847_002419568;
													Statement[] array13 = new Statement[1];
													ReturnStatement returnStatement18 = (_0024_00244846_002419567 = new ReturnStatement(LexicalInfo.Empty));
													ReturnStatement returnStatement19 = _0024_00244846_002419567;
													MemberReferenceExpression memberReferenceExpression9 = (_0024_00244845_002419566 = new MemberReferenceExpression(LexicalInfo.Empty));
													string text103 = (_0024_00244845_002419566.Name = "IsOk");
													Expression expression79 = (_0024_00244845_002419566.Target = new SuperLiteralExpression(LexicalInfo.Empty));
													Expression expression81 = (returnStatement19.Expression = _0024_00244845_002419566);
													array13[0] = Statement.Lift(_0024_00244846_002419567);
													StatementCollection statementCollection20 = (block40.Statements = StatementCollection.FromArray(array13));
													Block block42 = (ifStatement3.TrueBlock = _0024_00244847_002419568);
													IfStatement ifStatement4 = _0024_00244854_002419575;
													Block block43 = (_0024_00244853_002419574 = new Block(LexicalInfo.Empty));
													Block block44 = _0024_00244853_002419574;
													Statement[] array14 = new Statement[1];
													ReturnStatement returnStatement20 = (_0024_00244852_002419573 = new ReturnStatement(LexicalInfo.Empty));
													ReturnStatement returnStatement21 = _0024_00244852_002419573;
													BinaryExpression binaryExpression22 = (_0024_00244851_002419572 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType18 = (_0024_00244851_002419572.Operator = BinaryOperatorType.And);
													BinaryExpression binaryExpression23 = _0024_00244851_002419572;
													MemberReferenceExpression memberReferenceExpression10 = (_0024_00244848_002419569 = new MemberReferenceExpression(LexicalInfo.Empty));
													string text105 = (_0024_00244848_002419569.Name = "IsOk");
													Expression expression83 = (_0024_00244848_002419569.Target = new SuperLiteralExpression(LexicalInfo.Empty));
													Expression expression85 = (binaryExpression23.Left = _0024_00244848_002419569);
													BinaryExpression binaryExpression24 = _0024_00244851_002419572;
													MemberReferenceExpression memberReferenceExpression11 = (_0024_00244850_002419571 = new MemberReferenceExpression(LexicalInfo.Empty));
													string text107 = (_0024_00244850_002419571.Name = "IsOkStatusCode");
													MemberReferenceExpression memberReferenceExpression12 = _0024_00244850_002419571;
													ReferenceExpression referenceExpression21 = (_0024_00244849_002419570 = new ReferenceExpression(LexicalInfo.Empty));
													string text109 = (_0024_00244849_002419570.Name = "rsp");
													Expression expression87 = (memberReferenceExpression12.Target = _0024_00244849_002419570);
													Expression expression89 = (binaryExpression24.Right = _0024_00244850_002419571);
													Expression expression91 = (returnStatement21.Expression = _0024_00244851_002419572);
													array14[0] = Statement.Lift(_0024_00244852_002419573);
													StatementCollection statementCollection22 = (block44.Statements = StatementCollection.FromArray(array14));
													Block block46 = (ifStatement4.FalseBlock = _0024_00244853_002419574);
													array12[1] = Statement.Lift(_0024_00244854_002419575);
													StatementCollection statementCollection24 = (block38.Statements = StatementCollection.FromArray(array12));
													Block block48 = (method33.Body = _0024_00244855_002419576);
													Method method35 = (property17.Getter = _0024_00244856_002419577);
													Property property18 = _0024_00244858_002419579;
													SimpleTypeReference simpleTypeReference12 = (_0024_00244857_002419578 = new SimpleTypeReference(LexicalInfo.Empty));
													bool flag24 = (_0024_00244857_002419578.IsPointer = false);
													string text111 = (_0024_00244857_002419578.Name = "bool");
													TypeReference typeReference31 = (property18.Type = _0024_00244857_002419578);
													result = (Yield(2, _0024_00244858_002419579) ? 1 : 0);
													break;
												}
												goto case 3;
											}
										}
									}
								}
							}
						}
					}
					if (_0024_0024match_002436_002419550 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002440_002419620 = _0024_0024match_002436_002419550);
						if (true && _0024_0024match_002440_002419620.Name == "api_def" && 2 == ((ICollection)_0024_0024match_002440_002419620.Arguments).Count && _0024_0024match_002440_002419620.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression22 = (_0024_0024match_002441_002419621 = (ReferenceExpression)_0024_0024match_002440_002419620.Arguments[0]);
							if (true)
							{
								string text112 = (_0024sn_002419622 = _0024_0024match_002441_002419621.Name);
								if (true && _0024_0024match_002440_002419620.Arguments[1] is StringLiteralExpression)
								{
									StringLiteralExpression stringLiteralExpression = (_0024_0024match_002442_002419623 = (StringLiteralExpression)_0024_0024match_002440_002419620.Arguments[1]);
									if (true)
									{
										string text113 = (_0024spath_002419624 = _0024_0024match_002442_002419623.Value);
										if (true)
										{
											ReferenceExpression referenceExpression23 = (_0024_00244899_002419625 = new ReferenceExpression());
											string text115 = (_0024_00244899_002419625.Name = _0024sn_002419622);
											_0024stype_002419558 = _0024_00244899_002419625;
											if (_0024n_002419553 == "Game")
											{
												Property property19 = (_0024_00244920_002419646 = new Property(LexicalInfo.Empty));
												TypeMemberModifiers typeMemberModifiers22 = (_0024_00244920_002419646.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
												string text117 = (_0024_00244920_002419646.Name = "IsOk");
												Property property20 = _0024_00244920_002419646;
												Method method36 = (_0024_00244918_002419644 = new Method(LexicalInfo.Empty));
												string text119 = (_0024_00244918_002419644.Name = "get");
												Method method37 = _0024_00244918_002419644;
												Block block49 = (_0024_00244917_002419643 = new Block(LexicalInfo.Empty));
												Block block50 = _0024_00244917_002419643;
												Statement[] array15 = new Statement[2];
												BinaryExpression binaryExpression25 = (_0024_00244904_002419630 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType20 = (_0024_00244904_002419630.Operator = BinaryOperatorType.Assign);
												BinaryExpression binaryExpression26 = _0024_00244904_002419630;
												ReferenceExpression referenceExpression24 = (_0024_00244900_002419626 = new ReferenceExpression(LexicalInfo.Empty));
												string text121 = (_0024_00244900_002419626.Name = "rsp");
												Expression expression93 = (binaryExpression26.Left = _0024_00244900_002419626);
												BinaryExpression binaryExpression27 = _0024_00244904_002419630;
												TryCastExpression tryCastExpression13 = (_0024_00244903_002419629 = new TryCastExpression(LexicalInfo.Empty));
												TryCastExpression tryCastExpression14 = _0024_00244903_002419629;
												ReferenceExpression referenceExpression25 = (_0024_00244901_002419627 = new ReferenceExpression(LexicalInfo.Empty));
												string text123 = (_0024_00244901_002419627.Name = "ResponseObj");
												Expression expression95 = (tryCastExpression14.Target = _0024_00244901_002419627);
												TryCastExpression tryCastExpression15 = _0024_00244903_002419629;
												SimpleTypeReference simpleTypeReference13 = (_0024_00244902_002419628 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag26 = (_0024_00244902_002419628.IsPointer = false);
												string text125 = (_0024_00244902_002419628.Name = "GameApiResponseBase");
												TypeReference typeReference33 = (tryCastExpression15.Type = _0024_00244902_002419628);
												Expression expression97 = (binaryExpression27.Right = _0024_00244903_002419629);
												array15[0] = Statement.Lift(_0024_00244904_002419630);
												IfStatement ifStatement5 = (_0024_00244916_002419642 = new IfStatement(LexicalInfo.Empty));
												IfStatement ifStatement6 = _0024_00244916_002419642;
												BinaryExpression binaryExpression28 = (_0024_00244906_002419632 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType22 = (_0024_00244906_002419632.Operator = BinaryOperatorType.Equality);
												BinaryExpression binaryExpression29 = _0024_00244906_002419632;
												ReferenceExpression referenceExpression26 = (_0024_00244905_002419631 = new ReferenceExpression(LexicalInfo.Empty));
												string text127 = (_0024_00244905_002419631.Name = "rsp");
												Expression expression99 = (binaryExpression29.Left = _0024_00244905_002419631);
												Expression expression101 = (_0024_00244906_002419632.Right = new NullLiteralExpression(LexicalInfo.Empty));
												Expression expression103 = (ifStatement6.Condition = _0024_00244906_002419632);
												IfStatement ifStatement7 = _0024_00244916_002419642;
												Block block51 = (_0024_00244909_002419635 = new Block(LexicalInfo.Empty));
												Block block52 = _0024_00244909_002419635;
												Statement[] array16 = new Statement[1];
												ReturnStatement returnStatement22 = (_0024_00244908_002419634 = new ReturnStatement(LexicalInfo.Empty));
												ReturnStatement returnStatement23 = _0024_00244908_002419634;
												MemberReferenceExpression memberReferenceExpression13 = (_0024_00244907_002419633 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text129 = (_0024_00244907_002419633.Name = "IsOk");
												Expression expression105 = (_0024_00244907_002419633.Target = new SuperLiteralExpression(LexicalInfo.Empty));
												Expression expression107 = (returnStatement23.Expression = _0024_00244907_002419633);
												array16[0] = Statement.Lift(_0024_00244908_002419634);
												StatementCollection statementCollection26 = (block52.Statements = StatementCollection.FromArray(array16));
												Block block54 = (ifStatement7.TrueBlock = _0024_00244909_002419635);
												IfStatement ifStatement8 = _0024_00244916_002419642;
												Block block55 = (_0024_00244915_002419641 = new Block(LexicalInfo.Empty));
												Block block56 = _0024_00244915_002419641;
												Statement[] array17 = new Statement[1];
												ReturnStatement returnStatement24 = (_0024_00244914_002419640 = new ReturnStatement(LexicalInfo.Empty));
												ReturnStatement returnStatement25 = _0024_00244914_002419640;
												BinaryExpression binaryExpression30 = (_0024_00244913_002419639 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType24 = (_0024_00244913_002419639.Operator = BinaryOperatorType.And);
												BinaryExpression binaryExpression31 = _0024_00244913_002419639;
												MemberReferenceExpression memberReferenceExpression14 = (_0024_00244910_002419636 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text131 = (_0024_00244910_002419636.Name = "IsOk");
												Expression expression109 = (_0024_00244910_002419636.Target = new SuperLiteralExpression(LexicalInfo.Empty));
												Expression expression111 = (binaryExpression31.Left = _0024_00244910_002419636);
												BinaryExpression binaryExpression32 = _0024_00244913_002419639;
												MemberReferenceExpression memberReferenceExpression15 = (_0024_00244912_002419638 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text133 = (_0024_00244912_002419638.Name = "IsOkStatusCode");
												MemberReferenceExpression memberReferenceExpression16 = _0024_00244912_002419638;
												ReferenceExpression referenceExpression27 = (_0024_00244911_002419637 = new ReferenceExpression(LexicalInfo.Empty));
												string text135 = (_0024_00244911_002419637.Name = "rsp");
												Expression expression113 = (memberReferenceExpression16.Target = _0024_00244911_002419637);
												Expression expression115 = (binaryExpression32.Right = _0024_00244912_002419638);
												Expression expression117 = (returnStatement25.Expression = _0024_00244913_002419639);
												array17[0] = Statement.Lift(_0024_00244914_002419640);
												StatementCollection statementCollection28 = (block56.Statements = StatementCollection.FromArray(array17));
												Block block58 = (ifStatement8.FalseBlock = _0024_00244915_002419641);
												array15[1] = Statement.Lift(_0024_00244916_002419642);
												StatementCollection statementCollection30 = (block50.Statements = StatementCollection.FromArray(array15));
												Block block60 = (method37.Body = _0024_00244917_002419643);
												Method method39 = (property20.Getter = _0024_00244918_002419644);
												Property property21 = _0024_00244920_002419646;
												SimpleTypeReference simpleTypeReference14 = (_0024_00244919_002419645 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag28 = (_0024_00244919_002419645.IsPointer = false);
												string text137 = (_0024_00244919_002419645.Name = "bool");
												TypeReference typeReference35 = (property21.Type = _0024_00244919_002419645);
												result = (Yield(8, _0024_00244920_002419646) ? 1 : 0);
												break;
											}
											goto case 9;
										}
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`api_def` failed to match `").Append(_0024_0024match_002436_002419550).Append("`").ToString());
				case 2:
				{
					Property property13 = (_0024_00244877_002419598 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers18 = (_0024_00244877_002419598.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text66 = (_0024_00244877_002419598.Name = "HasValidStatus");
					Property property14 = _0024_00244877_002419598;
					Method method28 = (_0024_00244875_002419596 = new Method(LexicalInfo.Empty));
					string text68 = (_0024_00244875_002419596.Name = "get");
					Method method29 = _0024_00244875_002419596;
					Block block33 = (_0024_00244874_002419595 = new Block(LexicalInfo.Empty));
					Block block34 = _0024_00244874_002419595;
					Statement[] array10 = new Statement[2];
					BinaryExpression binaryExpression9 = (_0024_00244863_002419584 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00244863_002419584.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression10 = _0024_00244863_002419584;
					ReferenceExpression referenceExpression11 = (_0024_00244859_002419580 = new ReferenceExpression(LexicalInfo.Empty));
					string text70 = (_0024_00244859_002419580.Name = "rsp");
					Expression expression42 = (binaryExpression10.Left = _0024_00244859_002419580);
					BinaryExpression binaryExpression11 = _0024_00244863_002419584;
					TryCastExpression tryCastExpression6 = (_0024_00244862_002419583 = new TryCastExpression(LexicalInfo.Empty));
					TryCastExpression tryCastExpression7 = _0024_00244862_002419583;
					ReferenceExpression referenceExpression12 = (_0024_00244860_002419581 = new ReferenceExpression(LexicalInfo.Empty));
					string text72 = (_0024_00244860_002419581.Name = "ResponseObj");
					Expression expression44 = (tryCastExpression7.Target = _0024_00244860_002419581);
					TryCastExpression tryCastExpression8 = _0024_00244862_002419583;
					SimpleTypeReference simpleTypeReference9 = (_0024_00244861_002419582 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag18 = (_0024_00244861_002419582.IsPointer = false);
					string text74 = (_0024_00244861_002419582.Name = "GameApiResponseBase");
					TypeReference typeReference24 = (tryCastExpression8.Type = _0024_00244861_002419582);
					Expression expression46 = (binaryExpression11.Right = _0024_00244862_002419583);
					array10[0] = Statement.Lift(_0024_00244863_002419584);
					ReturnStatement returnStatement16 = (_0024_00244873_002419594 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement17 = _0024_00244873_002419594;
					BinaryExpression binaryExpression12 = (_0024_00244872_002419593 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00244872_002419593.Operator = BinaryOperatorType.And);
					BinaryExpression binaryExpression13 = _0024_00244872_002419593;
					BinaryExpression binaryExpression14 = (_0024_00244865_002419586 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType12 = (_0024_00244865_002419586.Operator = BinaryOperatorType.Inequality);
					BinaryExpression binaryExpression15 = _0024_00244865_002419586;
					ReferenceExpression referenceExpression13 = (_0024_00244864_002419585 = new ReferenceExpression(LexicalInfo.Empty));
					string text76 = (_0024_00244864_002419585.Name = "rsp");
					Expression expression48 = (binaryExpression15.Left = _0024_00244864_002419585);
					Expression expression50 = (_0024_00244865_002419586.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression52 = (binaryExpression13.Left = _0024_00244865_002419586);
					BinaryExpression binaryExpression16 = _0024_00244872_002419593;
					UnaryExpression unaryExpression3 = (_0024_00244871_002419592 = new UnaryExpression(LexicalInfo.Empty));
					UnaryOperatorType unaryOperatorType4 = (_0024_00244871_002419592.Operator = UnaryOperatorType.LogicalNot);
					UnaryExpression unaryExpression4 = _0024_00244871_002419592;
					MethodInvocationExpression methodInvocationExpression4 = (_0024_00244870_002419591 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression5 = _0024_00244870_002419591;
					MemberReferenceExpression memberReferenceExpression5 = (_0024_00244867_002419588 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text78 = (_0024_00244867_002419588.Name = "IsNullOrEmpty");
					MemberReferenceExpression memberReferenceExpression6 = _0024_00244867_002419588;
					ReferenceExpression referenceExpression14 = (_0024_00244866_002419587 = new ReferenceExpression(LexicalInfo.Empty));
					string text80 = (_0024_00244866_002419587.Name = "string");
					Expression expression54 = (memberReferenceExpression6.Target = _0024_00244866_002419587);
					Expression expression56 = (methodInvocationExpression5.Target = _0024_00244867_002419588);
					MethodInvocationExpression methodInvocationExpression6 = _0024_00244870_002419591;
					Expression[] array11 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression7 = (_0024_00244869_002419590 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text82 = (_0024_00244869_002419590.Name = "StatusCode");
					MemberReferenceExpression memberReferenceExpression8 = _0024_00244869_002419590;
					ReferenceExpression referenceExpression15 = (_0024_00244868_002419589 = new ReferenceExpression(LexicalInfo.Empty));
					string text84 = (_0024_00244868_002419589.Name = "rsp");
					Expression expression58 = (memberReferenceExpression8.Target = _0024_00244868_002419589);
					array11[0] = _0024_00244869_002419590;
					ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array11));
					Expression expression60 = (unaryExpression4.Operand = _0024_00244870_002419591);
					Expression expression62 = (binaryExpression16.Right = _0024_00244871_002419592);
					Expression expression64 = (returnStatement17.Expression = _0024_00244872_002419593);
					array10[1] = Statement.Lift(_0024_00244873_002419594);
					StatementCollection statementCollection18 = (block34.Statements = StatementCollection.FromArray(array10));
					Block block36 = (method29.Body = _0024_00244874_002419595);
					Method method31 = (property14.Getter = _0024_00244875_002419596);
					Property property15 = _0024_00244877_002419598;
					SimpleTypeReference simpleTypeReference10 = (_0024_00244876_002419597 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag20 = (_0024_00244876_002419597.IsPointer = false);
					string text86 = (_0024_00244876_002419597.Name = "bool");
					TypeReference typeReference26 = (property15.Type = _0024_00244876_002419597);
					result = (Yield(3, _0024_00244877_002419598) ? 1 : 0);
					break;
				}
				case 3:
				{
					Property property22 = (_0024_00244882_002419603 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers24 = (_0024_00244882_002419603.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text139 = (_0024_00244882_002419603.Name = "ApiPath");
					Property property23 = _0024_00244882_002419603;
					Method method40 = (_0024_00244880_002419601 = new Method(LexicalInfo.Empty));
					string text141 = (_0024_00244880_002419601.Name = "get");
					Method method41 = _0024_00244880_002419601;
					Block block61 = (_0024_00244879_002419600 = new Block(LexicalInfo.Empty));
					Block block62 = _0024_00244879_002419600;
					Statement[] array18 = new Statement[1];
					ReturnStatement returnStatement26 = (_0024_00244878_002419599 = new ReturnStatement(LexicalInfo.Empty));
					Expression expression119 = (_0024_00244878_002419599.Expression = Expression.Lift(_0024path_002419555));
					array18[0] = Statement.Lift(_0024_00244878_002419599);
					StatementCollection statementCollection32 = (block62.Statements = StatementCollection.FromArray(array18));
					Block block64 = (method41.Body = _0024_00244879_002419600);
					Method method43 = (property23.Getter = _0024_00244880_002419601);
					Property property24 = _0024_00244882_002419603;
					SimpleTypeReference simpleTypeReference15 = (_0024_00244881_002419602 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag30 = (_0024_00244881_002419602.IsPointer = false);
					string text143 = (_0024_00244881_002419602.Name = "string");
					TypeReference typeReference37 = (property24.Type = _0024_00244881_002419602);
					result = (Yield(4, _0024_00244882_002419603) ? 1 : 0);
					break;
				}
				case 4:
				{
					Property property10 = (_0024_00244888_002419609 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers16 = (_0024_00244888_002419609.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text58 = (_0024_00244888_002419609.Name = "Server");
					Property property11 = _0024_00244888_002419609;
					Method method24 = (_0024_00244886_002419607 = new Method(LexicalInfo.Empty));
					string text60 = (_0024_00244886_002419607.Name = "get");
					Method method25 = _0024_00244886_002419607;
					Block block29 = (_0024_00244885_002419606 = new Block(LexicalInfo.Empty));
					Block block30 = _0024_00244885_002419606;
					Statement[] array9 = new Statement[1];
					ReturnStatement returnStatement14 = (_0024_00244884_002419605 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement15 = _0024_00244884_002419605;
					ReferenceExpression referenceExpression10 = (_0024_00244883_002419604 = new ReferenceExpression(LexicalInfo.Empty));
					string text62 = (_0024_00244883_002419604.Name = "ServerType");
					Expression expression40 = (returnStatement15.Expression = new MemberReferenceExpression(_0024_00244883_002419604, CodeSerializer.LiftName(_0024stype_002419558)));
					array9[0] = Statement.Lift(_0024_00244884_002419605);
					StatementCollection statementCollection16 = (block30.Statements = StatementCollection.FromArray(array9));
					Block block32 = (method25.Body = _0024_00244885_002419606);
					Method method27 = (property11.Getter = _0024_00244886_002419607);
					Property property12 = _0024_00244888_002419609;
					SimpleTypeReference simpleTypeReference8 = (_0024_00244887_002419608 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag16 = (_0024_00244887_002419608.IsPointer = false);
					string text64 = (_0024_00244887_002419608.Name = "ServerType");
					TypeReference typeReference22 = (property12.Type = _0024_00244887_002419608);
					result = (Yield(5, _0024_00244888_002419609) ? 1 : 0);
					break;
				}
				case 5:
				{
					Method method22 = (_0024_00244893_002419614 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers14 = (_0024_00244893_002419614.Modifiers = TypeMemberModifiers.Public);
					string text54 = (_0024_00244893_002419614.Name = "GetResponse");
					TypeReference typeReference18 = (_0024_00244893_002419614.ReturnType = TypeReference.Lift(_0024rtype_002419556));
					Method method23 = _0024_00244893_002419614;
					Block block25 = (_0024_00244892_002419613 = new Block(LexicalInfo.Empty));
					Block block26 = _0024_00244892_002419613;
					Statement[] array8 = new Statement[1];
					ReturnStatement returnStatement12 = (_0024_00244891_002419612 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement13 = _0024_00244891_002419612;
					TryCastExpression tryCastExpression4 = (_0024_00244890_002419611 = new TryCastExpression(LexicalInfo.Empty));
					TryCastExpression tryCastExpression5 = _0024_00244890_002419611;
					ReferenceExpression referenceExpression9 = (_0024_00244889_002419610 = new ReferenceExpression(LexicalInfo.Empty));
					string text56 = (_0024_00244889_002419610.Name = "ResponseObj");
					Expression expression36 = (tryCastExpression5.Target = _0024_00244889_002419610);
					TypeReference typeReference20 = (_0024_00244890_002419611.Type = TypeReference.Lift(_0024rtype_002419556));
					Expression expression38 = (returnStatement13.Expression = _0024_00244890_002419611);
					array8[0] = Statement.Lift(_0024_00244891_002419612);
					StatementCollection statementCollection14 = (block26.Statements = StatementCollection.FromArray(array8));
					Block block28 = (method23.Body = _0024_00244892_002419613);
					result = (Yield(6, _0024_00244893_002419614) ? 1 : 0);
					break;
				}
				case 6:
				{
					Method method19 = (_0024_00244898_002419619 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers12 = (_0024_00244898_002419619.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text50 = (_0024_00244898_002419619.Name = "responseType");
					Method method20 = _0024_00244898_002419619;
					SimpleTypeReference simpleTypeReference7 = (_0024_00244894_002419615 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag14 = (_0024_00244894_002419615.IsPointer = false);
					string text52 = (_0024_00244894_002419615.Name = "Type");
					TypeReference typeReference14 = (method20.ReturnType = _0024_00244894_002419615);
					Method method21 = _0024_00244898_002419619;
					Block block21 = (_0024_00244897_002419618 = new Block(LexicalInfo.Empty));
					Block block22 = _0024_00244897_002419618;
					Statement[] array7 = new Statement[1];
					ReturnStatement returnStatement10 = (_0024_00244896_002419617 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement11 = _0024_00244896_002419617;
					TypeofExpression typeofExpression = (_0024_00244895_002419616 = new TypeofExpression(LexicalInfo.Empty));
					TypeReference typeReference16 = (_0024_00244895_002419616.Type = TypeReference.Lift(_0024rtype_002419556));
					Expression expression34 = (returnStatement11.Expression = _0024_00244895_002419616);
					array7[0] = Statement.Lift(_0024_00244896_002419617);
					StatementCollection statementCollection12 = (block22.Statements = StatementCollection.FromArray(array7));
					Block block24 = (method21.Body = _0024_00244897_002419618);
					result = (Yield(7, _0024_00244898_002419619) ? 1 : 0);
					break;
				}
				case 8:
				{
					Property property7 = (_0024_00244939_002419665 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers10 = (_0024_00244939_002419665.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text28 = (_0024_00244939_002419665.Name = "HasValidStatus");
					Property property8 = _0024_00244939_002419665;
					Method method15 = (_0024_00244937_002419663 = new Method(LexicalInfo.Empty));
					string text30 = (_0024_00244937_002419663.Name = "get");
					Method method16 = _0024_00244937_002419663;
					Block block17 = (_0024_00244936_002419662 = new Block(LexicalInfo.Empty));
					Block block18 = _0024_00244936_002419662;
					Statement[] array5 = new Statement[2];
					BinaryExpression binaryExpression = (_0024_00244925_002419651 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType2 = (_0024_00244925_002419651.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression2 = _0024_00244925_002419651;
					ReferenceExpression referenceExpression4 = (_0024_00244921_002419647 = new ReferenceExpression(LexicalInfo.Empty));
					string text32 = (_0024_00244921_002419647.Name = "rsp");
					Expression expression10 = (binaryExpression2.Left = _0024_00244921_002419647);
					BinaryExpression binaryExpression3 = _0024_00244925_002419651;
					TryCastExpression tryCastExpression = (_0024_00244924_002419650 = new TryCastExpression(LexicalInfo.Empty));
					TryCastExpression tryCastExpression2 = _0024_00244924_002419650;
					ReferenceExpression referenceExpression5 = (_0024_00244922_002419648 = new ReferenceExpression(LexicalInfo.Empty));
					string text34 = (_0024_00244922_002419648.Name = "ResponseObj");
					Expression expression12 = (tryCastExpression2.Target = _0024_00244922_002419648);
					TryCastExpression tryCastExpression3 = _0024_00244924_002419650;
					SimpleTypeReference simpleTypeReference5 = (_0024_00244923_002419649 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag10 = (_0024_00244923_002419649.IsPointer = false);
					string text36 = (_0024_00244923_002419649.Name = "GameApiResponseBase");
					TypeReference typeReference10 = (tryCastExpression3.Type = _0024_00244923_002419649);
					Expression expression14 = (binaryExpression3.Right = _0024_00244924_002419650);
					array5[0] = Statement.Lift(_0024_00244925_002419651);
					ReturnStatement returnStatement8 = (_0024_00244935_002419661 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement9 = _0024_00244935_002419661;
					BinaryExpression binaryExpression4 = (_0024_00244934_002419660 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType4 = (_0024_00244934_002419660.Operator = BinaryOperatorType.And);
					BinaryExpression binaryExpression5 = _0024_00244934_002419660;
					BinaryExpression binaryExpression6 = (_0024_00244927_002419653 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType6 = (_0024_00244927_002419653.Operator = BinaryOperatorType.Inequality);
					BinaryExpression binaryExpression7 = _0024_00244927_002419653;
					ReferenceExpression referenceExpression6 = (_0024_00244926_002419652 = new ReferenceExpression(LexicalInfo.Empty));
					string text38 = (_0024_00244926_002419652.Name = "rsp");
					Expression expression16 = (binaryExpression7.Left = _0024_00244926_002419652);
					Expression expression18 = (_0024_00244927_002419653.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression20 = (binaryExpression5.Left = _0024_00244927_002419653);
					BinaryExpression binaryExpression8 = _0024_00244934_002419660;
					UnaryExpression unaryExpression = (_0024_00244933_002419659 = new UnaryExpression(LexicalInfo.Empty));
					UnaryOperatorType unaryOperatorType2 = (_0024_00244933_002419659.Operator = UnaryOperatorType.LogicalNot);
					UnaryExpression unaryExpression2 = _0024_00244933_002419659;
					MethodInvocationExpression methodInvocationExpression = (_0024_00244932_002419658 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression2 = _0024_00244932_002419658;
					MemberReferenceExpression memberReferenceExpression = (_0024_00244929_002419655 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text40 = (_0024_00244929_002419655.Name = "IsNullOrEmpty");
					MemberReferenceExpression memberReferenceExpression2 = _0024_00244929_002419655;
					ReferenceExpression referenceExpression7 = (_0024_00244928_002419654 = new ReferenceExpression(LexicalInfo.Empty));
					string text42 = (_0024_00244928_002419654.Name = "string");
					Expression expression22 = (memberReferenceExpression2.Target = _0024_00244928_002419654);
					Expression expression24 = (methodInvocationExpression2.Target = _0024_00244929_002419655);
					MethodInvocationExpression methodInvocationExpression3 = _0024_00244932_002419658;
					Expression[] array6 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression3 = (_0024_00244931_002419657 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text44 = (_0024_00244931_002419657.Name = "StatusCode");
					MemberReferenceExpression memberReferenceExpression4 = _0024_00244931_002419657;
					ReferenceExpression referenceExpression8 = (_0024_00244930_002419656 = new ReferenceExpression(LexicalInfo.Empty));
					string text46 = (_0024_00244930_002419656.Name = "rsp");
					Expression expression26 = (memberReferenceExpression4.Target = _0024_00244930_002419656);
					array6[0] = _0024_00244931_002419657;
					ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array6));
					Expression expression28 = (unaryExpression2.Operand = _0024_00244932_002419658);
					Expression expression30 = (binaryExpression8.Right = _0024_00244933_002419659);
					Expression expression32 = (returnStatement9.Expression = _0024_00244934_002419660);
					array5[1] = Statement.Lift(_0024_00244935_002419661);
					StatementCollection statementCollection10 = (block18.Statements = StatementCollection.FromArray(array5));
					Block block20 = (method16.Body = _0024_00244936_002419662);
					Method method18 = (property8.Getter = _0024_00244937_002419663);
					Property property9 = _0024_00244939_002419665;
					SimpleTypeReference simpleTypeReference6 = (_0024_00244938_002419664 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag12 = (_0024_00244938_002419664.IsPointer = false);
					string text48 = (_0024_00244938_002419664.Name = "bool");
					TypeReference typeReference12 = (property9.Type = _0024_00244938_002419664);
					result = (Yield(9, _0024_00244939_002419665) ? 1 : 0);
					break;
				}
				case 9:
					if (_0024n_002419553 == "Game")
					{
						Method method44 = (_0024_00244946_002419672 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers26 = (_0024_00244946_002419672.Modifiers = TypeMemberModifiers.Public);
						string text145 = (_0024_00244946_002419672.Name = "GetResponse");
						Method method45 = _0024_00244946_002419672;
						SimpleTypeReference simpleTypeReference16 = (_0024_00244940_002419666 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag32 = (_0024_00244940_002419666.IsPointer = false);
						string text147 = (_0024_00244940_002419666.Name = "GameApiResponseBase");
						TypeReference typeReference39 = (method45.ReturnType = _0024_00244940_002419666);
						Method method46 = _0024_00244946_002419672;
						Block block65 = (_0024_00244945_002419671 = new Block(LexicalInfo.Empty));
						Block block66 = _0024_00244945_002419671;
						Statement[] array19 = new Statement[1];
						ReturnStatement returnStatement27 = (_0024_00244944_002419670 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement28 = _0024_00244944_002419670;
						TryCastExpression tryCastExpression16 = (_0024_00244943_002419669 = new TryCastExpression(LexicalInfo.Empty));
						TryCastExpression tryCastExpression17 = _0024_00244943_002419669;
						ReferenceExpression referenceExpression28 = (_0024_00244941_002419667 = new ReferenceExpression(LexicalInfo.Empty));
						string text149 = (_0024_00244941_002419667.Name = "ResponseObj");
						Expression expression121 = (tryCastExpression17.Target = _0024_00244941_002419667);
						TryCastExpression tryCastExpression18 = _0024_00244943_002419669;
						SimpleTypeReference simpleTypeReference17 = (_0024_00244942_002419668 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag34 = (_0024_00244942_002419668.IsPointer = false);
						string text151 = (_0024_00244942_002419668.Name = "GameApiResponseBase");
						TypeReference typeReference41 = (tryCastExpression18.Type = _0024_00244942_002419668);
						Expression expression123 = (returnStatement28.Expression = _0024_00244943_002419669);
						array19[0] = Statement.Lift(_0024_00244944_002419670);
						StatementCollection statementCollection34 = (block66.Statements = StatementCollection.FromArray(array19));
						Block block68 = (method46.Body = _0024_00244945_002419671);
						result = (Yield(10, _0024_00244946_002419672) ? 1 : 0);
					}
					else
					{
						Method method47 = (_0024_00244956_002419682 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers28 = (_0024_00244956_002419682.Modifiers = TypeMemberModifiers.Public);
						string text153 = (_0024_00244956_002419682.Name = "GetResponse");
						Method method48 = _0024_00244956_002419682;
						SimpleTypeReference simpleTypeReference18 = (_0024_00244952_002419678 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag36 = (_0024_00244952_002419678.IsPointer = false);
						string text155 = (_0024_00244952_002419678.Name = "JsonBase");
						TypeReference typeReference43 = (method48.ReturnType = _0024_00244952_002419678);
						Method method49 = _0024_00244956_002419682;
						Block block69 = (_0024_00244955_002419681 = new Block(LexicalInfo.Empty));
						Block block70 = _0024_00244955_002419681;
						Statement[] array20 = new Statement[1];
						ReturnStatement returnStatement29 = (_0024_00244954_002419680 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement30 = _0024_00244954_002419680;
						ReferenceExpression referenceExpression29 = (_0024_00244953_002419679 = new ReferenceExpression(LexicalInfo.Empty));
						string text157 = (_0024_00244953_002419679.Name = "ResponseObj");
						Expression expression125 = (returnStatement30.Expression = _0024_00244953_002419679);
						array20[0] = Statement.Lift(_0024_00244954_002419680);
						StatementCollection statementCollection36 = (block70.Statements = StatementCollection.FromArray(array20));
						Block block72 = (method49.Body = _0024_00244955_002419681);
						result = (Yield(12, _0024_00244956_002419682) ? 1 : 0);
					}
					break;
				case 10:
				{
					Method method12 = (_0024_00244951_002419677 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers8 = (_0024_00244951_002419677.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text22 = (_0024_00244951_002419677.Name = "responseType");
					Method method13 = _0024_00244951_002419677;
					SimpleTypeReference simpleTypeReference4 = (_0024_00244947_002419673 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag8 = (_0024_00244947_002419673.IsPointer = false);
					string text24 = (_0024_00244947_002419673.Name = "Type");
					TypeReference typeReference8 = (method13.ReturnType = _0024_00244947_002419673);
					Method method14 = _0024_00244951_002419677;
					Block block13 = (_0024_00244950_002419676 = new Block(LexicalInfo.Empty));
					Block block14 = _0024_00244950_002419676;
					Statement[] array4 = new Statement[1];
					ReturnStatement returnStatement6 = (_0024_00244949_002419675 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement7 = _0024_00244949_002419675;
					ReferenceExpression referenceExpression3 = (_0024_00244948_002419674 = new ReferenceExpression(LexicalInfo.Empty));
					string text26 = (_0024_00244948_002419674.Name = "GameApiResponseBase");
					Expression expression8 = (returnStatement7.Expression = _0024_00244948_002419674);
					array4[0] = Statement.Lift(_0024_00244949_002419675);
					StatementCollection statementCollection8 = (block14.Statements = StatementCollection.FromArray(array4));
					Block block16 = (method14.Body = _0024_00244950_002419676);
					result = (Yield(11, _0024_00244951_002419677) ? 1 : 0);
					break;
				}
				case 12:
				{
					Method method9 = (_0024_00244961_002419687 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers6 = (_0024_00244961_002419687.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text16 = (_0024_00244961_002419687.Name = "responseType");
					Method method10 = _0024_00244961_002419687;
					SimpleTypeReference simpleTypeReference3 = (_0024_00244957_002419683 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag6 = (_0024_00244957_002419683.IsPointer = false);
					string text18 = (_0024_00244957_002419683.Name = "Type");
					TypeReference typeReference6 = (method10.ReturnType = _0024_00244957_002419683);
					Method method11 = _0024_00244961_002419687;
					Block block9 = (_0024_00244960_002419686 = new Block(LexicalInfo.Empty));
					Block block10 = _0024_00244960_002419686;
					Statement[] array3 = new Statement[1];
					ReturnStatement returnStatement4 = (_0024_00244959_002419685 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement5 = _0024_00244959_002419685;
					ReferenceExpression referenceExpression2 = (_0024_00244958_002419684 = new ReferenceExpression(LexicalInfo.Empty));
					string text20 = (_0024_00244958_002419684.Name = "JsonBase");
					Expression expression6 = (returnStatement5.Expression = _0024_00244958_002419684);
					array3[0] = Statement.Lift(_0024_00244959_002419685);
					StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(array3));
					Block block12 = (method11.Body = _0024_00244960_002419686);
					result = (Yield(13, _0024_00244961_002419687) ? 1 : 0);
					break;
				}
				case 11:
				case 13:
				{
					Property property4 = (_0024_00244966_002419692 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers4 = (_0024_00244966_002419692.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text10 = (_0024_00244966_002419692.Name = "ApiPath");
					Property property5 = _0024_00244966_002419692;
					Method method5 = (_0024_00244964_002419690 = new Method(LexicalInfo.Empty));
					string text12 = (_0024_00244964_002419690.Name = "get");
					Method method6 = _0024_00244964_002419690;
					Block block5 = (_0024_00244963_002419689 = new Block(LexicalInfo.Empty));
					Block block6 = _0024_00244963_002419689;
					Statement[] array2 = new Statement[1];
					ReturnStatement returnStatement3 = (_0024_00244962_002419688 = new ReturnStatement(LexicalInfo.Empty));
					Expression expression4 = (_0024_00244962_002419688.Expression = Expression.Lift(_0024spath_002419624));
					array2[0] = Statement.Lift(_0024_00244962_002419688);
					StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
					Block block8 = (method6.Body = _0024_00244963_002419689);
					Method method8 = (property5.Getter = _0024_00244964_002419690);
					Property property6 = _0024_00244966_002419692;
					SimpleTypeReference simpleTypeReference2 = (_0024_00244965_002419691 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag4 = (_0024_00244965_002419691.IsPointer = false);
					string text14 = (_0024_00244965_002419691.Name = "string");
					TypeReference typeReference4 = (property6.Type = _0024_00244965_002419691);
					result = (Yield(14, _0024_00244966_002419692) ? 1 : 0);
					break;
				}
				case 14:
				{
					Property property = (_0024_00244972_002419698 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers2 = (_0024_00244972_002419698.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Override);
					string text2 = (_0024_00244972_002419698.Name = "Server");
					Property property2 = _0024_00244972_002419698;
					Method method = (_0024_00244970_002419696 = new Method(LexicalInfo.Empty));
					string text4 = (_0024_00244970_002419696.Name = "get");
					Method method2 = _0024_00244970_002419696;
					Block block = (_0024_00244969_002419695 = new Block(LexicalInfo.Empty));
					Block block2 = _0024_00244969_002419695;
					Statement[] array = new Statement[1];
					ReturnStatement returnStatement = (_0024_00244968_002419694 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement2 = _0024_00244968_002419694;
					ReferenceExpression referenceExpression = (_0024_00244967_002419693 = new ReferenceExpression(LexicalInfo.Empty));
					string text6 = (_0024_00244967_002419693.Name = "ServerType");
					Expression expression2 = (returnStatement2.Expression = new MemberReferenceExpression(_0024_00244967_002419693, CodeSerializer.LiftName(_0024stype_002419558)));
					array[0] = Statement.Lift(_0024_00244968_002419694);
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
					Block block4 = (method2.Body = _0024_00244969_002419695);
					Method method4 = (property2.Getter = _0024_00244970_002419696);
					Property property3 = _0024_00244972_002419698;
					SimpleTypeReference simpleTypeReference = (_0024_00244971_002419697 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag2 = (_0024_00244971_002419697.IsPointer = false);
					string text8 = (_0024_00244971_002419697.Name = "ServerType");
					TypeReference typeReference2 = (property3.Type = _0024_00244971_002419697);
					result = (Yield(15, _0024_00244972_002419698) ? 1 : 0);
					break;
				}
				case 7:
				case 15:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024api_def_002419701;

		internal Api_defMacro _0024self__002419702;

		public _0024ExpandGeneratorImpl_002419549(MacroStatement api_def, Api_defMacro self_)
		{
			_0024api_def_002419701 = api_def;
			_0024self__002419702 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024api_def_002419701, _0024self__002419702);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Api_defMacro()
	{
	}

	public Api_defMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement api_def)
	{
		return new _0024ExpandGeneratorImpl_002419549(api_def, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement api_def)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'api_def' is using. Read BOO-1077 for more info.");
	}
}
