using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Singleton_behaviourMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_00242466 : GenericGenerator<Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_00242467;

			internal TypeMember _0024___item_00242468;

			internal StringLiteralExpression _0024path_00242469;

			internal string _0024_0024assert2_0024167_00242470;

			internal TypeMember _0024___item_00242471;

			internal IEnumerator<TypeMember> _0024_0024iterator_00242303_00242472;

			internal IEnumerator<TypeMember> _0024_0024iterator_00242304_00242473;

			internal MacroStatement _0024singleton_behaviour_00242474;

			internal Singleton_behaviourMacro _0024self__00242475;

			public _0024(MacroStatement singleton_behaviour, Singleton_behaviourMacro self_)
			{
				_0024singleton_behaviour_00242474 = singleton_behaviour;
				_0024self__00242475 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (_0024singleton_behaviour_00242474 == null)
						{
							throw new ArgumentNullException("singleton_behaviour");
						}
						_0024self__00242475.__macro = _0024singleton_behaviour_00242474;
						_0024args_00242467 = _0024singleton_behaviour_00242474.Arguments;
						if (_0024args_00242467.Count == 0)
						{
							_0024_0024iterator_00242303_00242472 = SingletonCode(_0024singleton_behaviour_00242474, null, _0024self__00242475.Context).GetEnumerator();
							_state = 2;
							goto case 3;
						}
						if (_0024args_00242467.Count == 1)
						{
							_0024path_00242469 = _0024args_00242467[0] as StringLiteralExpression;
							if (_0024path_00242469 == null)
							{
								_0024_0024assert2_0024167_00242470 = "ASSERT at " + "basic_macros" + "(" + 279 + "):" + "path != null" + " -- message: " + "singleton_behaviour takes 1 arguments as prefab path.";
								throw new Exception(_0024_0024assert2_0024167_00242470);
							}
							_0024_0024iterator_00242304_00242473 = SingletonCode(_0024singleton_behaviour_00242474, _0024path_00242469.Value, _0024self__00242475.Context).GetEnumerator();
							_state = 4;
							goto case 5;
						}
						throw new Exception("singleton_behaviour macro error (argument error)");
					case 3:
						if (_0024_0024iterator_00242303_00242472.MoveNext())
						{
							_0024___item_00242468 = _0024_0024iterator_00242303_00242472.Current;
							flag = Yield(3, _0024___item_00242468);
							goto IL_0214;
						}
						_state = 1;
						_0024ensure2();
						break;
					case 5:
						if (_0024_0024iterator_00242304_00242473.MoveNext())
						{
							_0024___item_00242471 = _0024_0024iterator_00242304_00242473.Current;
							flag = Yield(5, _0024___item_00242471);
							goto IL_0214;
						}
						_state = 1;
						_0024ensure4();
						break;
					case 1:
					case 2:
					case 4:
						goto end_IL_0000;
					}
					YieldDefault(1);
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_0215;
				IL_0214:
				result = (flag ? 1 : 0);
				goto IL_0215;
				IL_0215:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_00242303_00242472.Dispose();
			}

			private void _0024ensure4()
			{
				_0024_0024iterator_00242304_00242473.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				case 4:
				case 5:
					_state = 1;
					_0024ensure4();
					break;
				}
			}
		}

		internal MacroStatement _0024singleton_behaviour_00242476;

		internal Singleton_behaviourMacro _0024self__00242477;

		public _0024ExpandGeneratorImpl_00242466(MacroStatement singleton_behaviour, Singleton_behaviourMacro self_)
		{
			_0024singleton_behaviour_00242476 = singleton_behaviour;
			_0024self__00242477 = self_;
		}

		public override IEnumerator<Node> GetEnumerator()
		{
			return new _0024(_0024singleton_behaviour_00242476, _0024self__00242477);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SingletonCode_00242478 : GenericGenerator<TypeMember>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<TypeMember>, IEnumerator
		{
			internal ClassDefinition _0024sc_00242479;

			internal string _0024_0024assert2_0024168_00242480;

			internal ReferenceExpression _0024cref_00242481;

			internal string _0024newName_00242482;

			internal Method _0024awakeMethod_00242483;

			internal ReferenceExpression _0024_00241214_00242484;

			internal Method _0024_00241215_00242485;

			internal ReferenceExpression _0024_00241216_00242486;

			internal BinaryExpression _0024_00241217_00242487;

			internal ReferenceExpression _0024_00241218_00242488;

			internal BinaryExpression _0024_00241219_00242489;

			internal BinaryExpression _0024_00241220_00242490;

			internal ReferenceExpression _0024_00241221_00242491;

			internal BinaryExpression _0024_00241222_00242492;

			internal ReferenceExpression _0024_00241223_00242493;

			internal MemberReferenceExpression _0024_00241224_00242494;

			internal ReferenceExpression _0024_00241225_00242495;

			internal MethodInvocationExpression _0024_00241226_00242496;

			internal MethodInvocationExpression _0024_00241227_00242497;

			internal Block _0024_00241228_00242498;

			internal MemberReferenceExpression _0024_00241229_00242499;

			internal StatementModifier _0024_00241230_00242500;

			internal ReferenceExpression _0024_00241231_00242501;

			internal MemberReferenceExpression _0024_00241232_00242502;

			internal MethodInvocationExpression _0024_00241233_00242503;

			internal ExpressionStatement _0024_00241234_00242504;

			internal ReferenceExpression _0024_00241235_00242505;

			internal MethodInvocationExpression _0024_00241236_00242506;

			internal Block _0024_00241237_00242507;

			internal IfStatement _0024_00241238_00242508;

			internal Block _0024_00241239_00242509;

			internal Method _0024_00241240_00242510;

			internal Field _0024_00241241_00242511;

			internal SimpleTypeReference _0024_00241242_00242512;

			internal Declaration _0024_00241243_00242513;

			internal ReferenceExpression _0024_00241244_00242514;

			internal MemberReferenceExpression _0024_00241245_00242515;

			internal ReferenceExpression _0024_00241246_00242516;

			internal MethodInvocationExpression _0024_00241247_00242517;

			internal DeclarationStatement _0024_00241248_00242518;

			internal ReferenceExpression _0024_00241249_00242519;

			internal BinaryExpression _0024_00241250_00242520;

			internal StringLiteralExpression _0024_00241251_00242521;

			internal ReferenceExpression _0024_00241252_00242522;

			internal StringLiteralExpression _0024_00241253_00242523;

			internal ExpressionInterpolationExpression _0024_00241254_00242524;

			internal BinaryExpression _0024_00241255_00242525;

			internal MacroStatement _0024_00241256_00242526;

			internal ReferenceExpression _0024_00241257_00242527;

			internal ReferenceExpression _0024_00241258_00242528;

			internal MethodInvocationExpression _0024_00241259_00242529;

			internal BinaryExpression _0024_00241260_00242530;

			internal Block _0024_00241261_00242531;

			internal ReferenceExpression _0024_00241262_00242532;

			internal ReferenceExpression _0024_00241263_00242533;

			internal MemberReferenceExpression _0024_00241264_00242534;

			internal MemberReferenceExpression _0024_00241265_00242535;

			internal ReferenceExpression _0024_00241266_00242536;

			internal MethodInvocationExpression _0024_00241267_00242537;

			internal SimpleTypeReference _0024_00241268_00242538;

			internal TryCastExpression _0024_00241269_00242539;

			internal BinaryExpression _0024_00241270_00242540;

			internal ReferenceExpression _0024_00241271_00242541;

			internal BinaryExpression _0024_00241272_00242542;

			internal StringLiteralExpression _0024_00241273_00242543;

			internal ReferenceExpression _0024_00241274_00242544;

			internal StringLiteralExpression _0024_00241275_00242545;

			internal ExpressionInterpolationExpression _0024_00241276_00242546;

			internal BinaryExpression _0024_00241277_00242547;

			internal MacroStatement _0024_00241278_00242548;

			internal ReferenceExpression _0024_00241279_00242549;

			internal ReferenceExpression _0024_00241280_00242550;

			internal MethodInvocationExpression _0024_00241281_00242551;

			internal BinaryExpression _0024_00241282_00242552;

			internal Block _0024_00241283_00242553;

			internal IfStatement _0024_00241284_00242554;

			internal Block _0024_00241285_00242555;

			internal IfStatement _0024_00241286_00242556;

			internal ReferenceExpression _0024_00241287_00242557;

			internal MemberReferenceExpression _0024_00241288_00242558;

			internal StringLiteralExpression _0024_00241289_00242559;

			internal BinaryExpression _0024_00241290_00242560;

			internal StringLiteralExpression _0024_00241291_00242561;

			internal BinaryExpression _0024_00241292_00242562;

			internal BinaryExpression _0024_00241293_00242563;

			internal ReferenceExpression _0024_00241294_00242564;

			internal MemberReferenceExpression _0024_00241295_00242565;

			internal ReferenceExpression _0024_00241296_00242566;

			internal MethodInvocationExpression _0024_00241297_00242567;

			internal ReferenceExpression _0024_00241298_00242568;

			internal ReferenceExpression _0024_00241299_00242569;

			internal MemberReferenceExpression _0024_00241300_00242570;

			internal GenericReferenceExpression _0024_00241301_00242571;

			internal MethodInvocationExpression _0024_00241302_00242572;

			internal BinaryExpression _0024_00241303_00242573;

			internal ReferenceExpression _0024_00241304_00242574;

			internal StatementModifier _0024_00241305_00242575;

			internal ReferenceExpression _0024_00241306_00242576;

			internal MemberReferenceExpression _0024_00241307_00242577;

			internal MethodInvocationExpression _0024_00241308_00242578;

			internal ExpressionStatement _0024_00241309_00242579;

			internal ReferenceExpression _0024_00241310_00242580;

			internal ReturnStatement _0024_00241311_00242581;

			internal Block _0024_00241312_00242582;

			internal Method _0024_00241313_00242583;

			internal ReferenceExpression _0024_00241314_00242584;

			internal StringLiteralExpression _0024_00241315_00242585;

			internal BinaryExpression _0024_00241316_00242586;

			internal StringLiteralExpression _0024_00241317_00242587;

			internal BinaryExpression _0024_00241318_00242588;

			internal BinaryExpression _0024_00241319_00242589;

			internal ReferenceExpression _0024_00241320_00242590;

			internal ReferenceExpression _0024_00241321_00242591;

			internal ReferenceExpression _0024_00241322_00242592;

			internal MethodInvocationExpression _0024_00241323_00242593;

			internal BinaryExpression _0024_00241324_00242594;

			internal ReferenceExpression _0024_00241325_00242595;

			internal MemberReferenceExpression _0024_00241326_00242596;

			internal ReferenceExpression _0024_00241327_00242597;

			internal MethodInvocationExpression _0024_00241328_00242598;

			internal ReferenceExpression _0024_00241329_00242599;

			internal ReferenceExpression _0024_00241330_00242600;

			internal MemberReferenceExpression _0024_00241331_00242601;

			internal GenericReferenceExpression _0024_00241332_00242602;

			internal MethodInvocationExpression _0024_00241333_00242603;

			internal BinaryExpression _0024_00241334_00242604;

			internal ReferenceExpression _0024_00241335_00242605;

			internal StatementModifier _0024_00241336_00242606;

			internal ReferenceExpression _0024_00241337_00242607;

			internal MemberReferenceExpression _0024_00241338_00242608;

			internal MethodInvocationExpression _0024_00241339_00242609;

			internal ExpressionStatement _0024_00241340_00242610;

			internal ReferenceExpression _0024_00241341_00242611;

			internal ReturnStatement _0024_00241342_00242612;

			internal Block _0024_00241343_00242613;

			internal Method _0024_00241344_00242614;

			internal Method _0024_createInstance_callback_Method_00242615;

			internal Method _0024_00241345_00242616;

			internal Field _0024_00241346_00242617;

			internal ReferenceExpression _0024_00241347_00242618;

			internal StatementModifier _0024_00241348_00242619;

			internal ReferenceExpression _0024_00241349_00242620;

			internal ReturnStatement _0024_00241350_00242621;

			internal ReferenceExpression _0024_00241351_00242622;

			internal BinaryExpression _0024_00241352_00242623;

			internal StatementModifier _0024_00241353_00242624;

			internal ReferenceExpression _0024_00241354_00242625;

			internal ReturnStatement _0024_00241355_00242626;

			internal ReferenceExpression _0024_00241356_00242627;

			internal ReferenceExpression _0024_00241357_00242628;

			internal MethodInvocationExpression _0024_00241358_00242629;

			internal TryCastExpression _0024_00241359_00242630;

			internal BinaryExpression _0024_00241360_00242631;

			internal ReferenceExpression _0024_00241361_00242632;

			internal BinaryExpression _0024_00241362_00242633;

			internal ReferenceExpression _0024_00241363_00242634;

			internal ReferenceExpression _0024_00241364_00242635;

			internal MethodInvocationExpression _0024_00241365_00242636;

			internal BinaryExpression _0024_00241366_00242637;

			internal Block _0024_00241367_00242638;

			internal IfStatement _0024_00241368_00242639;

			internal ReferenceExpression _0024_00241369_00242640;

			internal ReturnStatement _0024_00241370_00242641;

			internal Block _0024_00241371_00242642;

			internal Method _0024_00241372_00242643;

			internal Property _0024_00241373_00242644;

			internal ReferenceExpression _0024_00241374_00242645;

			internal ReturnStatement _0024_00241375_00242646;

			internal Block _0024_00241376_00242647;

			internal Method _0024_00241377_00242648;

			internal Property _0024_00241378_00242649;

			internal ReferenceExpression _0024_00241379_00242650;

			internal StatementModifier _0024_00241380_00242651;

			internal ReferenceExpression _0024_00241381_00242652;

			internal ReferenceExpression _0024_00241382_00242653;

			internal MemberReferenceExpression _0024_00241383_00242654;

			internal MethodInvocationExpression _0024_00241384_00242655;

			internal ExpressionStatement _0024_00241385_00242656;

			internal ReferenceExpression _0024_00241386_00242657;

			internal BinaryExpression _0024_00241387_00242658;

			internal Block _0024_00241388_00242659;

			internal Method _0024_00241389_00242660;

			internal SimpleTypeReference _0024_00241390_00242661;

			internal Field _0024_00241391_00242662;

			internal string _0024newNameAppQuit_00242663;

			internal Method _0024appQuitMethod_00242664;

			internal ReferenceExpression _0024_00241392_00242665;

			internal Method _0024_00241393_00242666;

			internal MethodInvocationExpression _0024_00241394_00242667;

			internal ReferenceExpression _0024_00241395_00242668;

			internal BoolLiteralExpression _0024_00241396_00242669;

			internal BinaryExpression _0024_00241397_00242670;

			internal Block _0024_00241398_00242671;

			internal Method _0024_00241399_00242672;

			internal MacroStatement _0024mcr_00242673;

			internal string _0024prefabPath_00242674;

			internal CompilerContext _0024ctxt_00242675;

			public _0024(MacroStatement mcr, string prefabPath, CompilerContext ctxt)
			{
				_0024mcr_00242673 = mcr;
				_0024prefabPath_00242674 = prefabPath;
				_0024ctxt_00242675 = ctxt;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024sc_00242479 = _0024mcr_00242673.GetAncestor<ClassDefinition>();
					if (_0024sc_00242479 == null)
					{
						_0024_0024assert2_0024168_00242480 = "ASSERT at " + "basic_macros" + "(" + 293 + "):" + "sc != null" + " -- message: " + "singleton_behaviour must be placed in a class definition";
						throw new Exception(_0024_0024assert2_0024168_00242480);
					}
					_0024cref_00242481 = new ReferenceExpression(_0024sc_00242479.Name);
					_0024newName_00242482 = _0024ctxt_00242675.GetUniqueName("singleton", "awake");
					_0024awakeMethod_00242483 = FindMethodNode(_0024sc_00242479, "Awake");
					if (_0024awakeMethod_00242483 != null)
					{
						_0024awakeMethod_00242483.Name = _0024newName_00242482;
						goto case 2;
					}
					Method method7 = (_0024_00241215_00242485 = new Method(LexicalInfo.Empty));
					string text48 = (_0024_00241215_00242485.Name = "$");
					Block block12 = (_0024_00241215_00242485.Body = new Block(LexicalInfo.Empty));
					Method method8 = _0024_00241215_00242485;
					ReferenceExpression referenceExpression14 = (_0024_00241214_00242484 = new ReferenceExpression());
					string text50 = (_0024_00241214_00242484.Name = _0024newName_00242482);
					string text52 = (method8.Name = CodeSerializer.LiftName(_0024_00241214_00242484));
					result = (Yield(2, _0024_00241215_00242485) ? 1 : 0);
					break;
				}
				case 2:
				{
					Method method20 = (_0024_00241240_00242510 = new Method(LexicalInfo.Empty));
					string text102 = (_0024_00241240_00242510.Name = "Awake");
					Method method21 = _0024_00241240_00242510;
					Block block31 = (_0024_00241239_00242509 = new Block(LexicalInfo.Empty));
					Block block32 = _0024_00241239_00242509;
					Statement[] array10 = new Statement[1];
					IfStatement ifStatement4 = (_0024_00241238_00242508 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement5 = _0024_00241238_00242508;
					BinaryExpression binaryExpression30 = (_0024_00241220_00242490 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType24 = (_0024_00241220_00242490.Operator = BinaryOperatorType.Or);
					BinaryExpression binaryExpression31 = _0024_00241220_00242490;
					BinaryExpression binaryExpression32 = (_0024_00241217_00242487 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType26 = (_0024_00241217_00242487.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression33 = _0024_00241217_00242487;
					ReferenceExpression referenceExpression30 = (_0024_00241216_00242486 = new ReferenceExpression(LexicalInfo.Empty));
					string text104 = (_0024_00241216_00242486.Name = "__instance");
					Expression expression100 = (binaryExpression33.Left = _0024_00241216_00242486);
					Expression expression102 = (_0024_00241217_00242487.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression104 = (binaryExpression31.Left = _0024_00241217_00242487);
					BinaryExpression binaryExpression34 = _0024_00241220_00242490;
					BinaryExpression binaryExpression35 = (_0024_00241219_00242489 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType28 = (_0024_00241219_00242489.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression36 = _0024_00241219_00242489;
					ReferenceExpression referenceExpression31 = (_0024_00241218_00242488 = new ReferenceExpression(LexicalInfo.Empty));
					string text106 = (_0024_00241218_00242488.Name = "__instance");
					Expression expression106 = (binaryExpression36.Left = _0024_00241218_00242488);
					Expression expression108 = (_0024_00241219_00242489.Right = new SelfLiteralExpression(LexicalInfo.Empty));
					Expression expression110 = (binaryExpression34.Right = _0024_00241219_00242489);
					Expression expression112 = (ifStatement5.Condition = _0024_00241220_00242490);
					IfStatement ifStatement6 = _0024_00241238_00242508;
					Block block33 = (_0024_00241228_00242498 = new Block(LexicalInfo.Empty));
					Block block34 = _0024_00241228_00242498;
					Statement[] array11 = new Statement[3];
					BinaryExpression binaryExpression37 = (_0024_00241222_00242492 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType30 = (_0024_00241222_00242492.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression38 = _0024_00241222_00242492;
					ReferenceExpression referenceExpression32 = (_0024_00241221_00242491 = new ReferenceExpression(LexicalInfo.Empty));
					string text108 = (_0024_00241221_00242491.Name = "__instance");
					Expression expression114 = (binaryExpression38.Left = _0024_00241221_00242491);
					Expression expression116 = (_0024_00241222_00242492.Right = new SelfLiteralExpression(LexicalInfo.Empty));
					array11[0] = Statement.Lift(_0024_00241222_00242492);
					MethodInvocationExpression methodInvocationExpression19 = (_0024_00241226_00242496 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression20 = _0024_00241226_00242496;
					MemberReferenceExpression memberReferenceExpression9 = (_0024_00241224_00242494 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text110 = (_0024_00241224_00242494.Name = "dontDestroyOnLoad");
					MemberReferenceExpression memberReferenceExpression10 = _0024_00241224_00242494;
					ReferenceExpression referenceExpression33 = (_0024_00241223_00242493 = new ReferenceExpression(LexicalInfo.Empty));
					string text112 = (_0024_00241223_00242493.Name = "SceneDontDestroyObject");
					Expression expression118 = (memberReferenceExpression10.Target = _0024_00241223_00242493);
					Expression expression120 = (methodInvocationExpression20.Target = _0024_00241224_00242494);
					MethodInvocationExpression methodInvocationExpression21 = _0024_00241226_00242496;
					Expression[] array12 = new Expression[1];
					ReferenceExpression referenceExpression34 = (_0024_00241225_00242495 = new ReferenceExpression(LexicalInfo.Empty));
					string text114 = (_0024_00241225_00242495.Name = "gameObject");
					array12[0] = _0024_00241225_00242495;
					ExpressionCollection expressionCollection10 = (methodInvocationExpression21.Arguments = ExpressionCollection.FromArray(array12));
					array11[1] = Statement.Lift(_0024_00241226_00242496);
					MethodInvocationExpression methodInvocationExpression22 = (_0024_00241227_00242497 = new MethodInvocationExpression(LexicalInfo.Empty));
					Expression expression122 = (_0024_00241227_00242497.Target = Expression.Lift(new ReferenceExpression(_0024newName_00242482)));
					array11[2] = Statement.Lift(_0024_00241227_00242497);
					StatementCollection statementCollection14 = (block34.Statements = StatementCollection.FromArray(array11));
					Block block36 = (ifStatement6.TrueBlock = _0024_00241228_00242498);
					IfStatement ifStatement7 = _0024_00241238_00242508;
					Block block37 = (_0024_00241237_00242507 = new Block(LexicalInfo.Empty));
					Block block38 = _0024_00241237_00242507;
					Statement[] array13 = new Statement[2];
					ExpressionStatement expressionStatement7 = (_0024_00241234_00242504 = new ExpressionStatement());
					ExpressionStatement expressionStatement8 = _0024_00241234_00242504;
					StatementModifier statementModifier17 = (_0024_00241230_00242500 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType10 = (_0024_00241230_00242500.Type = StatementModifierType.If);
					StatementModifier statementModifier18 = _0024_00241230_00242500;
					MemberReferenceExpression memberReferenceExpression11 = (_0024_00241229_00242499 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text116 = (_0024_00241229_00242499.Name = "gameObject");
					Expression expression124 = (_0024_00241229_00242499.Target = new SelfLiteralExpression(LexicalInfo.Empty));
					Expression expression126 = (statementModifier18.Condition = _0024_00241229_00242499);
					StatementModifier statementModifier20 = (expressionStatement8.Modifier = _0024_00241230_00242500);
					ExpressionStatement expressionStatement9 = _0024_00241234_00242504;
					MethodInvocationExpression methodInvocationExpression23 = (_0024_00241233_00242503 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression24 = _0024_00241233_00242503;
					ReferenceExpression referenceExpression35 = (_0024_00241231_00242501 = new ReferenceExpression(LexicalInfo.Empty));
					string text118 = (_0024_00241231_00242501.Name = "DestroyObject");
					Expression expression128 = (methodInvocationExpression24.Target = _0024_00241231_00242501);
					MethodInvocationExpression methodInvocationExpression25 = _0024_00241233_00242503;
					Expression[] array14 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression12 = (_0024_00241232_00242502 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text120 = (_0024_00241232_00242502.Name = "gameObject");
					Expression expression130 = (_0024_00241232_00242502.Target = new SelfLiteralExpression(LexicalInfo.Empty));
					array14[0] = _0024_00241232_00242502;
					ExpressionCollection expressionCollection12 = (methodInvocationExpression25.Arguments = ExpressionCollection.FromArray(array14));
					Expression expression132 = (expressionStatement9.Expression = _0024_00241233_00242503);
					array13[0] = Statement.Lift(_0024_00241234_00242504);
					MethodInvocationExpression methodInvocationExpression26 = (_0024_00241236_00242506 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression27 = _0024_00241236_00242506;
					ReferenceExpression referenceExpression36 = (_0024_00241235_00242505 = new ReferenceExpression(LexicalInfo.Empty));
					string text122 = (_0024_00241235_00242505.Name = "Destroy");
					Expression expression134 = (methodInvocationExpression27.Target = _0024_00241235_00242505);
					ExpressionCollection expressionCollection14 = (_0024_00241236_00242506.Arguments = ExpressionCollection.FromArray(new SelfLiteralExpression(LexicalInfo.Empty)));
					array13[1] = Statement.Lift(_0024_00241236_00242506);
					StatementCollection statementCollection16 = (block38.Statements = StatementCollection.FromArray(array13));
					Block block40 = (ifStatement7.FalseBlock = _0024_00241237_00242507);
					array10[0] = Statement.Lift(_0024_00241238_00242508);
					StatementCollection statementCollection18 = (block32.Statements = StatementCollection.FromArray(array10));
					Block block42 = (method21.Body = _0024_00241239_00242509);
					result = (Yield(3, _0024_00241240_00242510) ? 1 : 0);
					break;
				}
				case 3:
				{
					if (!string.IsNullOrEmpty(_0024prefabPath_00242674))
					{
						Field field = (_0024_00241241_00242511 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00241241_00242511.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static | TypeMemberModifiers.Final);
						string text8 = (_0024_00241241_00242511.Name = "DEFAULT_PREFAB_PATH");
						Expression expression2 = (_0024_00241241_00242511.Initializer = Expression.Lift(_0024prefabPath_00242674));
						bool flag2 = (_0024_00241241_00242511.IsVolatile = false);
						result = (Yield(4, _0024_00241241_00242511) ? 1 : 0);
						break;
					}
					Method method3 = (_0024_00241344_00242614 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers4 = (_0024_00241344_00242614.Modifiers = TypeMemberModifiers.Private | TypeMemberModifiers.Static);
					string text10 = (_0024_00241344_00242614.Name = "_createInstance");
					TypeReference typeReference2 = (_0024_00241344_00242614.ReturnType = TypeReference.Lift(_0024cref_00242481));
					Method method4 = _0024_00241344_00242614;
					Block block3 = (_0024_00241343_00242613 = new Block(LexicalInfo.Empty));
					Block block4 = _0024_00241343_00242613;
					Statement[] array = new Statement[6];
					BinaryExpression binaryExpression = (_0024_00241319_00242589 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType2 = (_0024_00241319_00242589.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression2 = _0024_00241319_00242589;
					ReferenceExpression referenceExpression2 = (_0024_00241314_00242584 = new ReferenceExpression(LexicalInfo.Empty));
					string text12 = (_0024_00241314_00242584.Name = "n");
					Expression expression4 = (binaryExpression2.Left = _0024_00241314_00242584);
					BinaryExpression binaryExpression3 = _0024_00241319_00242589;
					BinaryExpression binaryExpression4 = (_0024_00241318_00242588 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType4 = (_0024_00241318_00242588.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression5 = _0024_00241318_00242588;
					BinaryExpression binaryExpression6 = (_0024_00241316_00242586 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType6 = (_0024_00241316_00242586.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression7 = _0024_00241316_00242586;
					StringLiteralExpression stringLiteralExpression = (_0024_00241315_00242585 = new StringLiteralExpression(LexicalInfo.Empty));
					string text14 = (_0024_00241315_00242585.Value = "__");
					Expression expression6 = (binaryExpression7.Left = _0024_00241315_00242585);
					Expression expression8 = (_0024_00241316_00242586.Right = Expression.Lift(_0024sc_00242479.Name));
					Expression expression10 = (binaryExpression5.Left = _0024_00241316_00242586);
					BinaryExpression binaryExpression8 = _0024_00241318_00242588;
					StringLiteralExpression stringLiteralExpression2 = (_0024_00241317_00242587 = new StringLiteralExpression(LexicalInfo.Empty));
					string text16 = (_0024_00241317_00242587.Value = "__");
					Expression expression12 = (binaryExpression8.Right = _0024_00241317_00242587);
					Expression expression14 = (binaryExpression3.Right = _0024_00241318_00242588);
					array[0] = Statement.Lift(_0024_00241319_00242589);
					BinaryExpression binaryExpression9 = (_0024_00241324_00242594 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00241324_00242594.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression10 = _0024_00241324_00242594;
					ReferenceExpression referenceExpression3 = (_0024_00241320_00242590 = new ReferenceExpression(LexicalInfo.Empty));
					string text18 = (_0024_00241320_00242590.Name = "obj");
					Expression expression16 = (binaryExpression10.Left = _0024_00241320_00242590);
					BinaryExpression binaryExpression11 = _0024_00241324_00242594;
					MethodInvocationExpression methodInvocationExpression = (_0024_00241323_00242593 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression2 = _0024_00241323_00242593;
					ReferenceExpression referenceExpression4 = (_0024_00241321_00242591 = new ReferenceExpression(LexicalInfo.Empty));
					string text20 = (_0024_00241321_00242591.Name = "GameObject");
					Expression expression18 = (methodInvocationExpression2.Target = _0024_00241321_00242591);
					MethodInvocationExpression methodInvocationExpression3 = _0024_00241323_00242593;
					Expression[] array2 = new Expression[1];
					ReferenceExpression referenceExpression5 = (_0024_00241322_00242592 = new ReferenceExpression(LexicalInfo.Empty));
					string text22 = (_0024_00241322_00242592.Name = "n");
					array2[0] = _0024_00241322_00242592;
					ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array2));
					Expression expression20 = (binaryExpression11.Right = _0024_00241323_00242593);
					array[1] = Statement.Lift(_0024_00241324_00242594);
					MethodInvocationExpression methodInvocationExpression4 = (_0024_00241328_00242598 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression5 = _0024_00241328_00242598;
					MemberReferenceExpression memberReferenceExpression = (_0024_00241326_00242596 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text24 = (_0024_00241326_00242596.Name = "dontDestroyOnLoad");
					MemberReferenceExpression memberReferenceExpression2 = _0024_00241326_00242596;
					ReferenceExpression referenceExpression6 = (_0024_00241325_00242595 = new ReferenceExpression(LexicalInfo.Empty));
					string text26 = (_0024_00241325_00242595.Name = "SceneDontDestroyObject");
					Expression expression22 = (memberReferenceExpression2.Target = _0024_00241325_00242595);
					Expression expression24 = (methodInvocationExpression5.Target = _0024_00241326_00242596);
					MethodInvocationExpression methodInvocationExpression6 = _0024_00241328_00242598;
					Expression[] array3 = new Expression[1];
					ReferenceExpression referenceExpression7 = (_0024_00241327_00242597 = new ReferenceExpression(LexicalInfo.Empty));
					string text28 = (_0024_00241327_00242597.Name = "obj");
					array3[0] = _0024_00241327_00242597;
					ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array3));
					array[2] = Statement.Lift(_0024_00241328_00242598);
					BinaryExpression binaryExpression12 = (_0024_00241334_00242604 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00241334_00242604.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression13 = _0024_00241334_00242604;
					ReferenceExpression referenceExpression8 = (_0024_00241329_00242599 = new ReferenceExpression(LexicalInfo.Empty));
					string text30 = (_0024_00241329_00242599.Name = "c");
					Expression expression26 = (binaryExpression13.Left = _0024_00241329_00242599);
					BinaryExpression binaryExpression14 = _0024_00241334_00242604;
					MethodInvocationExpression methodInvocationExpression7 = (_0024_00241333_00242603 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression8 = _0024_00241333_00242603;
					GenericReferenceExpression genericReferenceExpression = (_0024_00241332_00242602 = new GenericReferenceExpression(LexicalInfo.Empty));
					GenericReferenceExpression genericReferenceExpression2 = _0024_00241332_00242602;
					MemberReferenceExpression memberReferenceExpression3 = (_0024_00241331_00242601 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text32 = (_0024_00241331_00242601.Name = "SetComponent");
					MemberReferenceExpression memberReferenceExpression4 = _0024_00241331_00242601;
					ReferenceExpression referenceExpression9 = (_0024_00241330_00242600 = new ReferenceExpression(LexicalInfo.Empty));
					string text34 = (_0024_00241330_00242600.Name = "obj");
					Expression expression28 = (memberReferenceExpression4.Target = _0024_00241330_00242600);
					Expression expression30 = (genericReferenceExpression2.Target = _0024_00241331_00242601);
					TypeReferenceCollection typeReferenceCollection2 = (_0024_00241332_00242602.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024cref_00242481)));
					Expression expression32 = (methodInvocationExpression8.Target = _0024_00241332_00242602);
					Expression expression34 = (binaryExpression14.Right = _0024_00241333_00242603);
					array[3] = Statement.Lift(_0024_00241334_00242604);
					ExpressionStatement expressionStatement = (_0024_00241340_00242610 = new ExpressionStatement());
					ExpressionStatement expressionStatement2 = _0024_00241340_00242610;
					StatementModifier statementModifier = (_0024_00241336_00242606 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType2 = (_0024_00241336_00242606.Type = StatementModifierType.If);
					StatementModifier statementModifier2 = _0024_00241336_00242606;
					ReferenceExpression referenceExpression10 = (_0024_00241335_00242605 = new ReferenceExpression(LexicalInfo.Empty));
					string text36 = (_0024_00241335_00242605.Name = "c");
					Expression expression36 = (statementModifier2.Condition = _0024_00241335_00242605);
					StatementModifier statementModifier4 = (expressionStatement2.Modifier = _0024_00241336_00242606);
					ExpressionStatement expressionStatement3 = _0024_00241340_00242610;
					MethodInvocationExpression methodInvocationExpression9 = (_0024_00241339_00242609 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression10 = _0024_00241339_00242609;
					MemberReferenceExpression memberReferenceExpression5 = (_0024_00241338_00242608 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text38 = (_0024_00241338_00242608.Name = "_createInstance_callback");
					MemberReferenceExpression memberReferenceExpression6 = _0024_00241338_00242608;
					ReferenceExpression referenceExpression11 = (_0024_00241337_00242607 = new ReferenceExpression(LexicalInfo.Empty));
					string text40 = (_0024_00241337_00242607.Name = "c");
					Expression expression38 = (memberReferenceExpression6.Target = _0024_00241337_00242607);
					Expression expression40 = (methodInvocationExpression10.Target = _0024_00241338_00242608);
					Expression expression42 = (expressionStatement3.Expression = _0024_00241339_00242609);
					array[4] = Statement.Lift(_0024_00241340_00242610);
					ReturnStatement returnStatement = (_0024_00241342_00242612 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement2 = _0024_00241342_00242612;
					ReferenceExpression referenceExpression12 = (_0024_00241341_00242611 = new ReferenceExpression(LexicalInfo.Empty));
					string text42 = (_0024_00241341_00242611.Name = "c");
					Expression expression44 = (returnStatement2.Expression = _0024_00241341_00242611);
					array[5] = Statement.Lift(_0024_00241342_00242612);
					StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array));
					Block block6 = (method4.Body = _0024_00241343_00242613);
					result = (Yield(6, _0024_00241344_00242614) ? 1 : 0);
					break;
				}
				case 4:
				{
					Method method22 = (_0024_00241313_00242583 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers16 = (_0024_00241313_00242583.Modifiers = TypeMemberModifiers.Private | TypeMemberModifiers.Static);
					string text126 = (_0024_00241313_00242583.Name = "_createInstance");
					TypeReference typeReference14 = (_0024_00241313_00242583.ReturnType = TypeReference.Lift(_0024cref_00242481));
					Method method23 = _0024_00241313_00242583;
					Block block43 = (_0024_00241312_00242582 = new Block(LexicalInfo.Empty));
					Block block44 = _0024_00241312_00242582;
					Statement[] array15 = new Statement[7];
					DeclarationStatement declarationStatement = (_0024_00241248_00242518 = new DeclarationStatement(LexicalInfo.Empty));
					DeclarationStatement declarationStatement2 = _0024_00241248_00242518;
					Declaration declaration = (_0024_00241243_00242513 = new Declaration(LexicalInfo.Empty));
					string text128 = (_0024_00241243_00242513.Name = "prefab");
					Declaration declaration2 = _0024_00241243_00242513;
					SimpleTypeReference simpleTypeReference2 = (_0024_00241242_00242512 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag12 = (_0024_00241242_00242512.IsPointer = false);
					string text130 = (_0024_00241242_00242512.Name = "GameObject");
					TypeReference typeReference16 = (declaration2.Type = _0024_00241242_00242512);
					Declaration declaration4 = (declarationStatement2.Declaration = _0024_00241243_00242513);
					DeclarationStatement declarationStatement3 = _0024_00241248_00242518;
					MethodInvocationExpression methodInvocationExpression28 = (_0024_00241247_00242517 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression29 = _0024_00241247_00242517;
					MemberReferenceExpression memberReferenceExpression13 = (_0024_00241245_00242515 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text132 = (_0024_00241245_00242515.Name = "LoadPrefab");
					MemberReferenceExpression memberReferenceExpression14 = _0024_00241245_00242515;
					ReferenceExpression referenceExpression37 = (_0024_00241244_00242514 = new ReferenceExpression(LexicalInfo.Empty));
					string text134 = (_0024_00241244_00242514.Name = "GameAsset");
					Expression expression136 = (memberReferenceExpression14.Target = _0024_00241244_00242514);
					Expression expression138 = (methodInvocationExpression29.Target = _0024_00241245_00242515);
					MethodInvocationExpression methodInvocationExpression30 = _0024_00241247_00242517;
					Expression[] array16 = new Expression[1];
					ReferenceExpression referenceExpression38 = (_0024_00241246_00242516 = new ReferenceExpression(LexicalInfo.Empty));
					string text136 = (_0024_00241246_00242516.Name = "DEFAULT_PREFAB_PATH");
					array16[0] = _0024_00241246_00242516;
					ExpressionCollection expressionCollection16 = (methodInvocationExpression30.Arguments = ExpressionCollection.FromArray(array16));
					Expression expression140 = (declarationStatement3.Initializer = _0024_00241247_00242517);
					array15[0] = Statement.Lift(_0024_00241248_00242518);
					IfStatement ifStatement8 = (_0024_00241286_00242556 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement9 = _0024_00241286_00242556;
					BinaryExpression binaryExpression39 = (_0024_00241250_00242520 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType32 = (_0024_00241250_00242520.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression40 = _0024_00241250_00242520;
					ReferenceExpression referenceExpression39 = (_0024_00241249_00242519 = new ReferenceExpression(LexicalInfo.Empty));
					string text138 = (_0024_00241249_00242519.Name = "prefab");
					Expression expression142 = (binaryExpression40.Left = _0024_00241249_00242519);
					Expression expression144 = (_0024_00241250_00242520.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression146 = (ifStatement9.Condition = _0024_00241250_00242520);
					IfStatement ifStatement10 = _0024_00241286_00242556;
					Block block45 = (_0024_00241261_00242531 = new Block(LexicalInfo.Empty));
					Block block46 = _0024_00241261_00242531;
					Statement[] array17 = new Statement[2];
					MacroStatement macroStatement = (_0024_00241256_00242526 = new MacroStatement(LexicalInfo.Empty));
					string text140 = (_0024_00241256_00242526.Name = "logerr");
					MacroStatement macroStatement2 = _0024_00241256_00242526;
					Expression[] array18 = new Expression[1];
					BinaryExpression binaryExpression41 = (_0024_00241255_00242525 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType34 = (_0024_00241255_00242525.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression42 = _0024_00241255_00242525;
					ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00241254_00242524 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
					ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00241254_00242524;
					Expression[] array19 = new Expression[3];
					StringLiteralExpression stringLiteralExpression3 = (_0024_00241251_00242521 = new StringLiteralExpression(LexicalInfo.Empty));
					string text142 = (_0024_00241251_00242521.Value = "prefab ");
					array19[0] = _0024_00241251_00242521;
					ReferenceExpression referenceExpression40 = (_0024_00241252_00242522 = new ReferenceExpression(LexicalInfo.Empty));
					string text144 = (_0024_00241252_00242522.Name = "prefab");
					array19[1] = _0024_00241252_00242522;
					StringLiteralExpression stringLiteralExpression4 = (_0024_00241253_00242523 = new StringLiteralExpression(LexicalInfo.Empty));
					string text146 = (_0024_00241253_00242523.Value = "が作れない? from singleton_behaviour ");
					array19[2] = _0024_00241253_00242523;
					ExpressionCollection expressionCollection18 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array19));
					Expression expression148 = (binaryExpression42.Left = _0024_00241254_00242524);
					Expression expression150 = (_0024_00241255_00242525.Right = Expression.Lift(_0024sc_00242479.Name));
					array18[0] = _0024_00241255_00242525;
					ExpressionCollection expressionCollection20 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array18));
					Block block48 = (_0024_00241256_00242526.Body = new Block(LexicalInfo.Empty));
					array17[0] = Statement.Lift(_0024_00241256_00242526);
					BinaryExpression binaryExpression43 = (_0024_00241260_00242530 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType36 = (_0024_00241260_00242530.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression44 = _0024_00241260_00242530;
					ReferenceExpression referenceExpression41 = (_0024_00241257_00242527 = new ReferenceExpression(LexicalInfo.Empty));
					string text148 = (_0024_00241257_00242527.Name = "obj");
					Expression expression152 = (binaryExpression44.Left = _0024_00241257_00242527);
					BinaryExpression binaryExpression45 = _0024_00241260_00242530;
					MethodInvocationExpression methodInvocationExpression31 = (_0024_00241259_00242529 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression32 = _0024_00241259_00242529;
					ReferenceExpression referenceExpression42 = (_0024_00241258_00242528 = new ReferenceExpression(LexicalInfo.Empty));
					string text150 = (_0024_00241258_00242528.Name = "GameObject");
					Expression expression154 = (methodInvocationExpression32.Target = _0024_00241258_00242528);
					Expression expression156 = (binaryExpression45.Right = _0024_00241259_00242529);
					array17[1] = Statement.Lift(_0024_00241260_00242530);
					StatementCollection statementCollection20 = (block46.Statements = StatementCollection.FromArray(array17));
					Block block50 = (ifStatement10.TrueBlock = _0024_00241261_00242531);
					IfStatement ifStatement11 = _0024_00241286_00242556;
					Block block51 = (_0024_00241285_00242555 = new Block(LexicalInfo.Empty));
					Block block52 = _0024_00241285_00242555;
					Statement[] array20 = new Statement[2];
					BinaryExpression binaryExpression46 = (_0024_00241270_00242540 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType38 = (_0024_00241270_00242540.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression47 = _0024_00241270_00242540;
					ReferenceExpression referenceExpression43 = (_0024_00241262_00242532 = new ReferenceExpression(LexicalInfo.Empty));
					string text152 = (_0024_00241262_00242532.Name = "obj");
					Expression expression158 = (binaryExpression47.Left = _0024_00241262_00242532);
					BinaryExpression binaryExpression48 = _0024_00241270_00242540;
					TryCastExpression tryCastExpression3 = (_0024_00241269_00242539 = new TryCastExpression(LexicalInfo.Empty));
					TryCastExpression tryCastExpression4 = _0024_00241269_00242539;
					MethodInvocationExpression methodInvocationExpression33 = (_0024_00241267_00242537 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression34 = _0024_00241267_00242537;
					MemberReferenceExpression memberReferenceExpression15 = (_0024_00241265_00242535 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text154 = (_0024_00241265_00242535.Name = "Instantiate");
					MemberReferenceExpression memberReferenceExpression16 = _0024_00241265_00242535;
					MemberReferenceExpression memberReferenceExpression17 = (_0024_00241264_00242534 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text156 = (_0024_00241264_00242534.Name = "Object");
					MemberReferenceExpression memberReferenceExpression18 = _0024_00241264_00242534;
					ReferenceExpression referenceExpression44 = (_0024_00241263_00242533 = new ReferenceExpression(LexicalInfo.Empty));
					string text158 = (_0024_00241263_00242533.Name = "UnityEngine");
					Expression expression160 = (memberReferenceExpression18.Target = _0024_00241263_00242533);
					Expression expression162 = (memberReferenceExpression16.Target = _0024_00241264_00242534);
					Expression expression164 = (methodInvocationExpression34.Target = _0024_00241265_00242535);
					MethodInvocationExpression methodInvocationExpression35 = _0024_00241267_00242537;
					Expression[] array21 = new Expression[1];
					ReferenceExpression referenceExpression45 = (_0024_00241266_00242536 = new ReferenceExpression(LexicalInfo.Empty));
					string text160 = (_0024_00241266_00242536.Name = "prefab");
					array21[0] = _0024_00241266_00242536;
					ExpressionCollection expressionCollection22 = (methodInvocationExpression35.Arguments = ExpressionCollection.FromArray(array21));
					Expression expression166 = (tryCastExpression4.Target = _0024_00241267_00242537);
					TryCastExpression tryCastExpression5 = _0024_00241269_00242539;
					SimpleTypeReference simpleTypeReference3 = (_0024_00241268_00242538 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag14 = (_0024_00241268_00242538.IsPointer = false);
					string text162 = (_0024_00241268_00242538.Name = "GameObject");
					TypeReference typeReference18 = (tryCastExpression5.Type = _0024_00241268_00242538);
					Expression expression168 = (binaryExpression48.Right = _0024_00241269_00242539);
					array20[0] = Statement.Lift(_0024_00241270_00242540);
					IfStatement ifStatement12 = (_0024_00241284_00242554 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement13 = _0024_00241284_00242554;
					BinaryExpression binaryExpression49 = (_0024_00241272_00242542 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType40 = (_0024_00241272_00242542.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression50 = _0024_00241272_00242542;
					ReferenceExpression referenceExpression46 = (_0024_00241271_00242541 = new ReferenceExpression(LexicalInfo.Empty));
					string text164 = (_0024_00241271_00242541.Name = "obj");
					Expression expression170 = (binaryExpression50.Left = _0024_00241271_00242541);
					Expression expression172 = (_0024_00241272_00242542.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression174 = (ifStatement13.Condition = _0024_00241272_00242542);
					IfStatement ifStatement14 = _0024_00241284_00242554;
					Block block53 = (_0024_00241283_00242553 = new Block(LexicalInfo.Empty));
					Block block54 = _0024_00241283_00242553;
					Statement[] array22 = new Statement[2];
					MacroStatement macroStatement3 = (_0024_00241278_00242548 = new MacroStatement(LexicalInfo.Empty));
					string text166 = (_0024_00241278_00242548.Name = "logerr");
					MacroStatement macroStatement4 = _0024_00241278_00242548;
					Expression[] array23 = new Expression[1];
					BinaryExpression binaryExpression51 = (_0024_00241277_00242547 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType42 = (_0024_00241277_00242547.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression52 = _0024_00241277_00242547;
					ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00241276_00242546 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
					ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00241276_00242546;
					Expression[] array24 = new Expression[3];
					StringLiteralExpression stringLiteralExpression5 = (_0024_00241273_00242543 = new StringLiteralExpression(LexicalInfo.Empty));
					string text168 = (_0024_00241273_00242543.Value = "prefab ");
					array24[0] = _0024_00241273_00242543;
					ReferenceExpression referenceExpression47 = (_0024_00241274_00242544 = new ReferenceExpression(LexicalInfo.Empty));
					string text170 = (_0024_00241274_00242544.Name = "prefab");
					array24[1] = _0024_00241274_00242544;
					StringLiteralExpression stringLiteralExpression6 = (_0024_00241275_00242545 = new StringLiteralExpression(LexicalInfo.Empty));
					string text172 = (_0024_00241275_00242545.Value = "をInstantiateできない? from singleton_behaviour ");
					array24[2] = _0024_00241275_00242545;
					ExpressionCollection expressionCollection24 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array24));
					Expression expression176 = (binaryExpression52.Left = _0024_00241276_00242546);
					Expression expression178 = (_0024_00241277_00242547.Right = Expression.Lift(_0024sc_00242479.Name));
					array23[0] = _0024_00241277_00242547;
					ExpressionCollection expressionCollection26 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array23));
					Block block56 = (_0024_00241278_00242548.Body = new Block(LexicalInfo.Empty));
					array22[0] = Statement.Lift(_0024_00241278_00242548);
					BinaryExpression binaryExpression53 = (_0024_00241282_00242552 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType44 = (_0024_00241282_00242552.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression54 = _0024_00241282_00242552;
					ReferenceExpression referenceExpression48 = (_0024_00241279_00242549 = new ReferenceExpression(LexicalInfo.Empty));
					string text174 = (_0024_00241279_00242549.Name = "obj");
					Expression expression180 = (binaryExpression54.Left = _0024_00241279_00242549);
					BinaryExpression binaryExpression55 = _0024_00241282_00242552;
					MethodInvocationExpression methodInvocationExpression36 = (_0024_00241281_00242551 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression37 = _0024_00241281_00242551;
					ReferenceExpression referenceExpression49 = (_0024_00241280_00242550 = new ReferenceExpression(LexicalInfo.Empty));
					string text176 = (_0024_00241280_00242550.Name = "GameObject");
					Expression expression182 = (methodInvocationExpression37.Target = _0024_00241280_00242550);
					Expression expression184 = (binaryExpression55.Right = _0024_00241281_00242551);
					array22[1] = Statement.Lift(_0024_00241282_00242552);
					StatementCollection statementCollection22 = (block54.Statements = StatementCollection.FromArray(array22));
					Block block58 = (ifStatement14.TrueBlock = _0024_00241283_00242553);
					array20[1] = Statement.Lift(_0024_00241284_00242554);
					StatementCollection statementCollection24 = (block52.Statements = StatementCollection.FromArray(array20));
					Block block60 = (ifStatement11.FalseBlock = _0024_00241285_00242555);
					array15[1] = Statement.Lift(_0024_00241286_00242556);
					BinaryExpression binaryExpression56 = (_0024_00241293_00242563 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType46 = (_0024_00241293_00242563.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression57 = _0024_00241293_00242563;
					MemberReferenceExpression memberReferenceExpression19 = (_0024_00241288_00242558 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text178 = (_0024_00241288_00242558.Name = "name");
					MemberReferenceExpression memberReferenceExpression20 = _0024_00241288_00242558;
					ReferenceExpression referenceExpression50 = (_0024_00241287_00242557 = new ReferenceExpression(LexicalInfo.Empty));
					string text180 = (_0024_00241287_00242557.Name = "obj");
					Expression expression186 = (memberReferenceExpression20.Target = _0024_00241287_00242557);
					Expression expression188 = (binaryExpression57.Left = _0024_00241288_00242558);
					BinaryExpression binaryExpression58 = _0024_00241293_00242563;
					BinaryExpression binaryExpression59 = (_0024_00241292_00242562 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType48 = (_0024_00241292_00242562.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression60 = _0024_00241292_00242562;
					BinaryExpression binaryExpression61 = (_0024_00241290_00242560 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType50 = (_0024_00241290_00242560.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression62 = _0024_00241290_00242560;
					StringLiteralExpression stringLiteralExpression7 = (_0024_00241289_00242559 = new StringLiteralExpression(LexicalInfo.Empty));
					string text182 = (_0024_00241289_00242559.Value = "__");
					Expression expression190 = (binaryExpression62.Left = _0024_00241289_00242559);
					Expression expression192 = (_0024_00241290_00242560.Right = Expression.Lift(_0024sc_00242479.Name));
					Expression expression194 = (binaryExpression60.Left = _0024_00241290_00242560);
					BinaryExpression binaryExpression63 = _0024_00241292_00242562;
					StringLiteralExpression stringLiteralExpression8 = (_0024_00241291_00242561 = new StringLiteralExpression(LexicalInfo.Empty));
					string text184 = (_0024_00241291_00242561.Value = "__");
					Expression expression196 = (binaryExpression63.Right = _0024_00241291_00242561);
					Expression expression198 = (binaryExpression58.Right = _0024_00241292_00242562);
					array15[2] = Statement.Lift(_0024_00241293_00242563);
					MethodInvocationExpression methodInvocationExpression38 = (_0024_00241297_00242567 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression39 = _0024_00241297_00242567;
					MemberReferenceExpression memberReferenceExpression21 = (_0024_00241295_00242565 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text186 = (_0024_00241295_00242565.Name = "dontDestroyOnLoad");
					MemberReferenceExpression memberReferenceExpression22 = _0024_00241295_00242565;
					ReferenceExpression referenceExpression51 = (_0024_00241294_00242564 = new ReferenceExpression(LexicalInfo.Empty));
					string text188 = (_0024_00241294_00242564.Name = "SceneDontDestroyObject");
					Expression expression200 = (memberReferenceExpression22.Target = _0024_00241294_00242564);
					Expression expression202 = (methodInvocationExpression39.Target = _0024_00241295_00242565);
					MethodInvocationExpression methodInvocationExpression40 = _0024_00241297_00242567;
					Expression[] array25 = new Expression[1];
					ReferenceExpression referenceExpression52 = (_0024_00241296_00242566 = new ReferenceExpression(LexicalInfo.Empty));
					string text190 = (_0024_00241296_00242566.Name = "obj");
					array25[0] = _0024_00241296_00242566;
					ExpressionCollection expressionCollection28 = (methodInvocationExpression40.Arguments = ExpressionCollection.FromArray(array25));
					array15[3] = Statement.Lift(_0024_00241297_00242567);
					BinaryExpression binaryExpression64 = (_0024_00241303_00242573 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType52 = (_0024_00241303_00242573.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression65 = _0024_00241303_00242573;
					ReferenceExpression referenceExpression53 = (_0024_00241298_00242568 = new ReferenceExpression(LexicalInfo.Empty));
					string text192 = (_0024_00241298_00242568.Name = "c");
					Expression expression204 = (binaryExpression65.Left = _0024_00241298_00242568);
					BinaryExpression binaryExpression66 = _0024_00241303_00242573;
					MethodInvocationExpression methodInvocationExpression41 = (_0024_00241302_00242572 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression42 = _0024_00241302_00242572;
					GenericReferenceExpression genericReferenceExpression3 = (_0024_00241301_00242571 = new GenericReferenceExpression(LexicalInfo.Empty));
					GenericReferenceExpression genericReferenceExpression4 = _0024_00241301_00242571;
					MemberReferenceExpression memberReferenceExpression23 = (_0024_00241300_00242570 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text194 = (_0024_00241300_00242570.Name = "SetComponent");
					MemberReferenceExpression memberReferenceExpression24 = _0024_00241300_00242570;
					ReferenceExpression referenceExpression54 = (_0024_00241299_00242569 = new ReferenceExpression(LexicalInfo.Empty));
					string text196 = (_0024_00241299_00242569.Name = "obj");
					Expression expression206 = (memberReferenceExpression24.Target = _0024_00241299_00242569);
					Expression expression208 = (genericReferenceExpression4.Target = _0024_00241300_00242570);
					TypeReferenceCollection typeReferenceCollection4 = (_0024_00241301_00242571.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024cref_00242481)));
					Expression expression210 = (methodInvocationExpression42.Target = _0024_00241301_00242571);
					Expression expression212 = (binaryExpression66.Right = _0024_00241302_00242572);
					array15[4] = Statement.Lift(_0024_00241303_00242573);
					ExpressionStatement expressionStatement10 = (_0024_00241309_00242579 = new ExpressionStatement());
					ExpressionStatement expressionStatement11 = _0024_00241309_00242579;
					StatementModifier statementModifier21 = (_0024_00241305_00242575 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType12 = (_0024_00241305_00242575.Type = StatementModifierType.If);
					StatementModifier statementModifier22 = _0024_00241305_00242575;
					ReferenceExpression referenceExpression55 = (_0024_00241304_00242574 = new ReferenceExpression(LexicalInfo.Empty));
					string text198 = (_0024_00241304_00242574.Name = "c");
					Expression expression214 = (statementModifier22.Condition = _0024_00241304_00242574);
					StatementModifier statementModifier24 = (expressionStatement11.Modifier = _0024_00241305_00242575);
					ExpressionStatement expressionStatement12 = _0024_00241309_00242579;
					MethodInvocationExpression methodInvocationExpression43 = (_0024_00241308_00242578 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression44 = _0024_00241308_00242578;
					MemberReferenceExpression memberReferenceExpression25 = (_0024_00241307_00242577 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text200 = (_0024_00241307_00242577.Name = "_createInstance_callback");
					MemberReferenceExpression memberReferenceExpression26 = _0024_00241307_00242577;
					ReferenceExpression referenceExpression56 = (_0024_00241306_00242576 = new ReferenceExpression(LexicalInfo.Empty));
					string text202 = (_0024_00241306_00242576.Name = "c");
					Expression expression216 = (memberReferenceExpression26.Target = _0024_00241306_00242576);
					Expression expression218 = (methodInvocationExpression44.Target = _0024_00241307_00242577);
					Expression expression220 = (expressionStatement12.Expression = _0024_00241308_00242578);
					array15[5] = Statement.Lift(_0024_00241309_00242579);
					ReturnStatement returnStatement13 = (_0024_00241311_00242581 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement14 = _0024_00241311_00242581;
					ReferenceExpression referenceExpression57 = (_0024_00241310_00242580 = new ReferenceExpression(LexicalInfo.Empty));
					string text204 = (_0024_00241310_00242580.Name = "c");
					Expression expression222 = (returnStatement14.Expression = _0024_00241310_00242580);
					array15[6] = Statement.Lift(_0024_00241311_00242581);
					StatementCollection statementCollection26 = (block44.Statements = StatementCollection.FromArray(array15));
					Block block62 = (method23.Body = _0024_00241312_00242582);
					result = (Yield(5, _0024_00241313_00242583) ? 1 : 0);
					break;
				}
				case 5:
				case 6:
					_0024_createInstance_callback_Method_00242615 = FindMethodNode(_0024sc_00242479, "_createInstance_callback");
					if (_0024_createInstance_callback_Method_00242615 == null)
					{
						Method method19 = (_0024_00241345_00242616 = new Method(LexicalInfo.Empty));
						string text100 = (_0024_00241345_00242616.Name = "_createInstance_callback");
						Block block30 = (_0024_00241345_00242616.Body = new Block(LexicalInfo.Empty));
						result = (Yield(7, _0024_00241345_00242616) ? 1 : 0);
						break;
					}
					goto case 7;
				case 7:
				{
					Field field4 = (_0024_00241346_00242617 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers14 = (_0024_00241346_00242617.Modifiers = TypeMemberModifiers.Private | TypeMemberModifiers.Static);
					string text124 = (_0024_00241346_00242617.Name = "__instance");
					TypeReference typeReference12 = (_0024_00241346_00242617.Type = TypeReference.Lift(_0024cref_00242481));
					bool flag10 = (_0024_00241346_00242617.IsVolatile = false);
					result = (Yield(8, _0024_00241346_00242617) ? 1 : 0);
					break;
				}
				case 8:
				{
					Property property3 = (_0024_00241373_00242644 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers12 = (_0024_00241373_00242644.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
					string text76 = (_0024_00241373_00242644.Name = "Instance");
					Property property4 = _0024_00241373_00242644;
					Method method15 = (_0024_00241372_00242643 = new Method(LexicalInfo.Empty));
					string text78 = (_0024_00241372_00242643.Name = "get");
					Method method16 = _0024_00241372_00242643;
					Block block21 = (_0024_00241371_00242642 = new Block(LexicalInfo.Empty));
					Block block22 = _0024_00241371_00242642;
					Statement[] array8 = new Statement[5];
					ReturnStatement returnStatement5 = (_0024_00241350_00242621 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement6 = _0024_00241350_00242621;
					StatementModifier statementModifier9 = (_0024_00241348_00242619 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType6 = (_0024_00241348_00242619.Type = StatementModifierType.If);
					StatementModifier statementModifier10 = _0024_00241348_00242619;
					ReferenceExpression referenceExpression20 = (_0024_00241347_00242618 = new ReferenceExpression(LexicalInfo.Empty));
					string text80 = (_0024_00241347_00242618.Name = "quitApp");
					Expression expression66 = (statementModifier10.Condition = _0024_00241347_00242618);
					StatementModifier statementModifier12 = (returnStatement6.Modifier = _0024_00241348_00242619);
					ReturnStatement returnStatement7 = _0024_00241350_00242621;
					ReferenceExpression referenceExpression21 = (_0024_00241349_00242620 = new ReferenceExpression(LexicalInfo.Empty));
					string text82 = (_0024_00241349_00242620.Name = "__instance");
					Expression expression68 = (returnStatement7.Expression = _0024_00241349_00242620);
					array8[0] = Statement.Lift(_0024_00241350_00242621);
					ReturnStatement returnStatement8 = (_0024_00241355_00242626 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement9 = _0024_00241355_00242626;
					StatementModifier statementModifier13 = (_0024_00241353_00242624 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType8 = (_0024_00241353_00242624.Type = StatementModifierType.If);
					StatementModifier statementModifier14 = _0024_00241353_00242624;
					BinaryExpression binaryExpression20 = (_0024_00241352_00242623 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType16 = (_0024_00241352_00242623.Operator = BinaryOperatorType.Inequality);
					BinaryExpression binaryExpression21 = _0024_00241352_00242623;
					ReferenceExpression referenceExpression22 = (_0024_00241351_00242622 = new ReferenceExpression(LexicalInfo.Empty));
					string text84 = (_0024_00241351_00242622.Name = "__instance");
					Expression expression70 = (binaryExpression21.Left = _0024_00241351_00242622);
					Expression expression72 = (_0024_00241352_00242623.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression74 = (statementModifier14.Condition = _0024_00241352_00242623);
					StatementModifier statementModifier16 = (returnStatement9.Modifier = _0024_00241353_00242624);
					ReturnStatement returnStatement10 = _0024_00241355_00242626;
					ReferenceExpression referenceExpression23 = (_0024_00241354_00242625 = new ReferenceExpression(LexicalInfo.Empty));
					string text86 = (_0024_00241354_00242625.Name = "__instance");
					Expression expression76 = (returnStatement10.Expression = _0024_00241354_00242625);
					array8[1] = Statement.Lift(_0024_00241355_00242626);
					BinaryExpression binaryExpression22 = (_0024_00241360_00242631 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType18 = (_0024_00241360_00242631.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression23 = _0024_00241360_00242631;
					ReferenceExpression referenceExpression24 = (_0024_00241356_00242627 = new ReferenceExpression(LexicalInfo.Empty));
					string text88 = (_0024_00241356_00242627.Name = "__instance");
					Expression expression78 = (binaryExpression23.Left = _0024_00241356_00242627);
					BinaryExpression binaryExpression24 = _0024_00241360_00242631;
					TryCastExpression tryCastExpression = (_0024_00241359_00242630 = new TryCastExpression(LexicalInfo.Empty));
					TryCastExpression tryCastExpression2 = _0024_00241359_00242630;
					MethodInvocationExpression methodInvocationExpression15 = (_0024_00241358_00242629 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression16 = _0024_00241358_00242629;
					ReferenceExpression referenceExpression25 = (_0024_00241357_00242628 = new ReferenceExpression(LexicalInfo.Empty));
					string text90 = (_0024_00241357_00242628.Name = "FindObjectOfType");
					Expression expression80 = (methodInvocationExpression16.Target = _0024_00241357_00242628);
					ExpressionCollection expressionCollection8 = (_0024_00241358_00242629.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024cref_00242481)));
					Expression expression82 = (tryCastExpression2.Target = _0024_00241358_00242629);
					TypeReference typeReference8 = (_0024_00241359_00242630.Type = TypeReference.Lift(_0024cref_00242481));
					Expression expression84 = (binaryExpression24.Right = _0024_00241359_00242630);
					array8[2] = Statement.Lift(_0024_00241360_00242631);
					IfStatement ifStatement = (_0024_00241368_00242639 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement2 = _0024_00241368_00242639;
					BinaryExpression binaryExpression25 = (_0024_00241362_00242633 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType20 = (_0024_00241362_00242633.Operator = BinaryOperatorType.Equality);
					BinaryExpression binaryExpression26 = _0024_00241362_00242633;
					ReferenceExpression referenceExpression26 = (_0024_00241361_00242632 = new ReferenceExpression(LexicalInfo.Empty));
					string text92 = (_0024_00241361_00242632.Name = "__instance");
					Expression expression86 = (binaryExpression26.Left = _0024_00241361_00242632);
					Expression expression88 = (_0024_00241362_00242633.Right = new NullLiteralExpression(LexicalInfo.Empty));
					Expression expression90 = (ifStatement2.Condition = _0024_00241362_00242633);
					IfStatement ifStatement3 = _0024_00241368_00242639;
					Block block23 = (_0024_00241367_00242638 = new Block(LexicalInfo.Empty));
					Block block24 = _0024_00241367_00242638;
					Statement[] array9 = new Statement[1];
					BinaryExpression binaryExpression27 = (_0024_00241366_00242637 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType22 = (_0024_00241366_00242637.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression28 = _0024_00241366_00242637;
					ReferenceExpression referenceExpression27 = (_0024_00241363_00242634 = new ReferenceExpression(LexicalInfo.Empty));
					string text94 = (_0024_00241363_00242634.Name = "__instance");
					Expression expression92 = (binaryExpression28.Left = _0024_00241363_00242634);
					BinaryExpression binaryExpression29 = _0024_00241366_00242637;
					MethodInvocationExpression methodInvocationExpression17 = (_0024_00241365_00242636 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression18 = _0024_00241365_00242636;
					ReferenceExpression referenceExpression28 = (_0024_00241364_00242635 = new ReferenceExpression(LexicalInfo.Empty));
					string text96 = (_0024_00241364_00242635.Name = "_createInstance");
					Expression expression94 = (methodInvocationExpression18.Target = _0024_00241364_00242635);
					Expression expression96 = (binaryExpression29.Right = _0024_00241365_00242636);
					array9[0] = Statement.Lift(_0024_00241366_00242637);
					StatementCollection statementCollection10 = (block24.Statements = StatementCollection.FromArray(array9));
					Block block26 = (ifStatement3.TrueBlock = _0024_00241367_00242638);
					array8[3] = Statement.Lift(_0024_00241368_00242639);
					ReturnStatement returnStatement11 = (_0024_00241370_00242641 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement12 = _0024_00241370_00242641;
					ReferenceExpression referenceExpression29 = (_0024_00241369_00242640 = new ReferenceExpression(LexicalInfo.Empty));
					string text98 = (_0024_00241369_00242640.Name = "__instance");
					Expression expression98 = (returnStatement12.Expression = _0024_00241369_00242640);
					array8[4] = Statement.Lift(_0024_00241370_00242641);
					StatementCollection statementCollection12 = (block22.Statements = StatementCollection.FromArray(array8));
					Block block28 = (method16.Body = _0024_00241371_00242642);
					Method method18 = (property4.Getter = _0024_00241372_00242643);
					TypeReference typeReference10 = (_0024_00241373_00242644.Type = TypeReference.Lift(_0024cref_00242481));
					result = (Yield(9, _0024_00241373_00242644) ? 1 : 0);
					break;
				}
				case 9:
				{
					Property property = (_0024_00241378_00242649 = new Property(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers10 = (_0024_00241378_00242649.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
					string text70 = (_0024_00241378_00242649.Name = "CurrentInstance");
					Property property2 = _0024_00241378_00242649;
					Method method11 = (_0024_00241377_00242648 = new Method(LexicalInfo.Empty));
					string text72 = (_0024_00241377_00242648.Name = "get");
					Method method12 = _0024_00241377_00242648;
					Block block17 = (_0024_00241376_00242647 = new Block(LexicalInfo.Empty));
					Block block18 = _0024_00241376_00242647;
					Statement[] array7 = new Statement[1];
					ReturnStatement returnStatement3 = (_0024_00241375_00242646 = new ReturnStatement(LexicalInfo.Empty));
					ReturnStatement returnStatement4 = _0024_00241375_00242646;
					ReferenceExpression referenceExpression19 = (_0024_00241374_00242645 = new ReferenceExpression(LexicalInfo.Empty));
					string text74 = (_0024_00241374_00242645.Name = "__instance");
					Expression expression64 = (returnStatement4.Expression = _0024_00241374_00242645);
					array7[0] = Statement.Lift(_0024_00241375_00242646);
					StatementCollection statementCollection8 = (block18.Statements = StatementCollection.FromArray(array7));
					Block block20 = (method12.Body = _0024_00241376_00242647);
					Method method14 = (property2.Getter = _0024_00241377_00242648);
					TypeReference typeReference6 = (_0024_00241378_00242649.Type = TypeReference.Lift(_0024cref_00242481));
					result = (Yield(10, _0024_00241378_00242649) ? 1 : 0);
					break;
				}
				case 10:
				{
					Method method9 = (_0024_00241389_00242660 = new Method(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers8 = (_0024_00241389_00242660.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
					string text58 = (_0024_00241389_00242660.Name = "DestroyInstance");
					Method method10 = _0024_00241389_00242660;
					Block block13 = (_0024_00241388_00242659 = new Block(LexicalInfo.Empty));
					Block block14 = _0024_00241388_00242659;
					Statement[] array5 = new Statement[2];
					ExpressionStatement expressionStatement4 = (_0024_00241385_00242656 = new ExpressionStatement());
					ExpressionStatement expressionStatement5 = _0024_00241385_00242656;
					StatementModifier statementModifier5 = (_0024_00241380_00242651 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType4 = (_0024_00241380_00242651.Type = StatementModifierType.If);
					StatementModifier statementModifier6 = _0024_00241380_00242651;
					ReferenceExpression referenceExpression15 = (_0024_00241379_00242650 = new ReferenceExpression(LexicalInfo.Empty));
					string text60 = (_0024_00241379_00242650.Name = "__instance");
					Expression expression52 = (statementModifier6.Condition = _0024_00241379_00242650);
					StatementModifier statementModifier8 = (expressionStatement5.Modifier = _0024_00241380_00242651);
					ExpressionStatement expressionStatement6 = _0024_00241385_00242656;
					MethodInvocationExpression methodInvocationExpression12 = (_0024_00241384_00242655 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression13 = _0024_00241384_00242655;
					ReferenceExpression referenceExpression16 = (_0024_00241381_00242652 = new ReferenceExpression(LexicalInfo.Empty));
					string text62 = (_0024_00241381_00242652.Name = "DestroyObject");
					Expression expression54 = (methodInvocationExpression13.Target = _0024_00241381_00242652);
					MethodInvocationExpression methodInvocationExpression14 = _0024_00241384_00242655;
					Expression[] array6 = new Expression[1];
					MemberReferenceExpression memberReferenceExpression7 = (_0024_00241383_00242654 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text64 = (_0024_00241383_00242654.Name = "gameObject");
					MemberReferenceExpression memberReferenceExpression8 = _0024_00241383_00242654;
					ReferenceExpression referenceExpression17 = (_0024_00241382_00242653 = new ReferenceExpression(LexicalInfo.Empty));
					string text66 = (_0024_00241382_00242653.Name = "__instance");
					Expression expression56 = (memberReferenceExpression8.Target = _0024_00241382_00242653);
					array6[0] = _0024_00241383_00242654;
					ExpressionCollection expressionCollection6 = (methodInvocationExpression14.Arguments = ExpressionCollection.FromArray(array6));
					Expression expression58 = (expressionStatement6.Expression = _0024_00241384_00242655);
					array5[0] = Statement.Lift(_0024_00241385_00242656);
					BinaryExpression binaryExpression18 = (_0024_00241387_00242658 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType14 = (_0024_00241387_00242658.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression19 = _0024_00241387_00242658;
					ReferenceExpression referenceExpression18 = (_0024_00241386_00242657 = new ReferenceExpression(LexicalInfo.Empty));
					string text68 = (_0024_00241386_00242657.Name = "__instance");
					Expression expression60 = (binaryExpression19.Left = _0024_00241386_00242657);
					Expression expression62 = (_0024_00241387_00242658.Right = new NullLiteralExpression(LexicalInfo.Empty));
					array5[1] = Statement.Lift(_0024_00241387_00242658);
					StatementCollection statementCollection6 = (block14.Statements = StatementCollection.FromArray(array5));
					Block block16 = (method10.Body = _0024_00241388_00242659);
					result = (Yield(11, _0024_00241389_00242660) ? 1 : 0);
					break;
				}
				case 11:
				{
					Field field2 = (_0024_00241391_00242662 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers6 = (_0024_00241391_00242662.Modifiers = TypeMemberModifiers.Static);
					string text54 = (_0024_00241391_00242662.Name = "quitApp");
					Field field3 = _0024_00241391_00242662;
					SimpleTypeReference simpleTypeReference = (_0024_00241390_00242661 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag6 = (_0024_00241390_00242661.IsPointer = false);
					string text56 = (_0024_00241390_00242661.Name = "bool");
					TypeReference typeReference4 = (field3.Type = _0024_00241390_00242661);
					bool flag8 = (_0024_00241391_00242662.IsVolatile = false);
					result = (Yield(12, _0024_00241391_00242662) ? 1 : 0);
					break;
				}
				case 12:
				{
					_0024newNameAppQuit_00242663 = _0024ctxt_00242675.GetUniqueName("singleton", "appQuit");
					_0024appQuitMethod_00242664 = FindMethodNode(_0024sc_00242479, "OnApplicationQuit");
					if (_0024appQuitMethod_00242664 != null)
					{
						_0024appQuitMethod_00242664.Name = _0024newNameAppQuit_00242663;
						goto case 13;
					}
					Method method = (_0024_00241393_00242666 = new Method(LexicalInfo.Empty));
					string text2 = (_0024_00241393_00242666.Name = "$");
					Block block2 = (_0024_00241393_00242666.Body = new Block(LexicalInfo.Empty));
					Method method2 = _0024_00241393_00242666;
					ReferenceExpression referenceExpression = (_0024_00241392_00242665 = new ReferenceExpression());
					string text4 = (_0024_00241392_00242665.Name = _0024newNameAppQuit_00242663);
					string text6 = (method2.Name = CodeSerializer.LiftName(_0024_00241392_00242665));
					result = (Yield(13, _0024_00241393_00242666) ? 1 : 0);
					break;
				}
				case 13:
				{
					Method method5 = (_0024_00241399_00242672 = new Method(LexicalInfo.Empty));
					string text44 = (_0024_00241399_00242672.Name = "OnApplicationQuit");
					Method method6 = _0024_00241399_00242672;
					Block block7 = (_0024_00241398_00242671 = new Block(LexicalInfo.Empty));
					Block block8 = _0024_00241398_00242671;
					Statement[] array4 = new Statement[2];
					MethodInvocationExpression methodInvocationExpression11 = (_0024_00241394_00242667 = new MethodInvocationExpression(LexicalInfo.Empty));
					Expression expression46 = (_0024_00241394_00242667.Target = Expression.Lift(new ReferenceExpression(_0024newNameAppQuit_00242663)));
					array4[0] = Statement.Lift(_0024_00241394_00242667);
					BinaryExpression binaryExpression15 = (_0024_00241397_00242670 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType12 = (_0024_00241397_00242670.Operator = BinaryOperatorType.Assign);
					BinaryExpression binaryExpression16 = _0024_00241397_00242670;
					ReferenceExpression referenceExpression13 = (_0024_00241395_00242668 = new ReferenceExpression(LexicalInfo.Empty));
					string text46 = (_0024_00241395_00242668.Name = "quitApp");
					Expression expression48 = (binaryExpression16.Left = _0024_00241395_00242668);
					BinaryExpression binaryExpression17 = _0024_00241397_00242670;
					BoolLiteralExpression boolLiteralExpression = (_0024_00241396_00242669 = new BoolLiteralExpression(LexicalInfo.Empty));
					bool flag4 = (_0024_00241396_00242669.Value = true);
					Expression expression50 = (binaryExpression17.Right = _0024_00241396_00242669);
					array4[1] = Statement.Lift(_0024_00241397_00242670);
					StatementCollection statementCollection4 = (block8.Statements = StatementCollection.FromArray(array4));
					Block block10 = (method6.Body = _0024_00241398_00242671);
					result = (Yield(14, _0024_00241399_00242672) ? 1 : 0);
					break;
				}
				case 14:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024mcr_00242676;

		internal string _0024prefabPath_00242677;

		internal CompilerContext _0024ctxt_00242678;

		public _0024SingletonCode_00242478(MacroStatement mcr, string prefabPath, CompilerContext ctxt)
		{
			_0024mcr_00242676 = mcr;
			_0024prefabPath_00242677 = prefabPath;
			_0024ctxt_00242678 = ctxt;
		}

		public override IEnumerator<TypeMember> GetEnumerator()
		{
			return new _0024(_0024mcr_00242676, _0024prefabPath_00242677, _0024ctxt_00242678);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Singleton_behaviourMacro()
	{
	}

	public Singleton_behaviourMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement singleton_behaviour)
	{
		return new _0024ExpandGeneratorImpl_00242466(singleton_behaviour, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement singleton_behaviour)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'singleton_behaviour' is using. Read BOO-1077 for more info.");
	}

	private static Method FindMethodNode(ClassDefinition cls, string methodName)
	{
		object result;
		Method method2;
		if (cls == null || string.IsNullOrEmpty(methodName))
		{
			result = null;
		}
		else
		{
			IEnumerator<TypeMember> enumerator = cls.Members.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					TypeMember current = enumerator.Current;
					if (!(current is Method method) || !(method.Name == methodName))
					{
						continue;
					}
					method2 = method;
					goto IL_006e;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = null;
		}
		goto IL_006f;
		IL_006f:
		return (Method)result;
		IL_006e:
		result = method2;
		goto IL_006f;
	}

	private static IEnumerable<TypeMember> SingletonCode(MacroStatement mcr, string prefabPath, CompilerContext ctxt)
	{
		return new _0024SingletonCode_00242478(mcr, prefabPath, ctxt);
	}
}
