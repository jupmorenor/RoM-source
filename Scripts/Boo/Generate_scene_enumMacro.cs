using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public class Generate_scene_enumMacro : SceneIDBaseMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002415489 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal string _0024enumName_002415490;

			internal string[] _0024paths_002415491;

			internal EnumDefinition _0024___item_002415492;

			internal TypeMember _0024___item_002415493;

			internal IEnumerator<EnumDefinition> _0024_0024iterator_002413290_002415494;

			internal IEnumerator<TypeMember> _0024_0024iterator_002413291_002415495;

			internal MacroStatement _0024mc_002415496;

			public _0024(MacroStatement mc)
			{
				_0024mc_002415496 = mc;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024enumName_002415490 = Path.GetFileNameWithoutExtension(_0024mc_002415496.LexicalInfo.FileName);
						Console.WriteLine(new StringBuilder("enumName=").Append(_0024enumName_002415490).ToString());
						_0024paths_002415491 = SceneIDBaseMacro.ScenePathList(forceUpdate: false);
						if (_0024paths_002415491 == null)
						{
							Console.WriteLine("paths get : null");
							throw new Exception("!!! DO \"Tool>Scene>Reimport Scene(enum)s. \"!!!");
						}
						Console.WriteLine(new StringBuilder("paths get : ").Append((object)_0024paths_002415491.Length).ToString());
						_0024_0024iterator_002413290_002415494 = GenEnum(_0024enumName_002415490, _0024paths_002415491).GetEnumerator();
						_state = 2;
						goto case 3;
					case 3:
						if (_0024_0024iterator_002413290_002415494.MoveNext())
						{
							_0024___item_002415492 = _0024_0024iterator_002413290_002415494.Current;
							flag = Yield(3, _0024___item_002415492);
							goto IL_01a1;
						}
						_state = 1;
						_0024ensure2();
						_0024_0024iterator_002413291_002415495 = GenEnumTableCode(_0024enumName_002415490, _0024paths_002415491).GetEnumerator();
						_state = 4;
						break;
					case 5:
						break;
					case 1:
					case 2:
					case 4:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002413291_002415495.MoveNext())
					{
						_0024___item_002415493 = _0024_0024iterator_002413291_002415495.Current;
						flag = Yield(5, _0024___item_002415493);
						goto IL_01a1;
					}
					_state = 1;
					_0024ensure4();
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
				goto IL_01a2;
				IL_01a1:
				result = (flag ? 1 : 0);
				goto IL_01a2;
				IL_01a2:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413290_002415494.Dispose();
			}

			private void _0024ensure4()
			{
				_0024_0024iterator_002413291_002415495.Dispose();
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

		internal MacroStatement _0024mc_002415497;

		public _0024ExpandGeneratorImpl_002415489(MacroStatement mc)
		{
			_0024mc_002415497 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002415497);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GenEnum_002415498 : GenericGenerator<EnumDefinition>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<EnumDefinition>, IEnumerator
		{
			internal EnumDefinition _0024_00244129_002415499;

			internal EnumDefinition _0024enumDef_002415500;

			internal string _0024path_002415501;

			internal string _0024memName_002415502;

			internal EnumMember _0024_00244130_002415503;

			internal EnumMember _0024_00244131_002415504;

			internal int _0024_00248092_002415505;

			internal string[] _0024_00248093_002415506;

			internal int _0024_00248094_002415507;

			internal string _0024enumName_002415508;

			internal string[] _0024paths_002415509;

			public _0024(string enumName, string[] paths)
			{
				_0024enumName_002415508 = enumName;
				_0024paths_002415509 = paths;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						EnumDefinition enumDefinition = (_0024_00244129_002415499 = new EnumDefinition());
						string text2 = (_0024_00244129_002415499.Name = _0024enumName_002415508);
						_0024enumDef_002415500 = _0024_00244129_002415499;
						_0024_00248092_002415505 = 0;
						_0024_00248093_002415506 = _0024paths_002415509;
						for (_0024_00248094_002415507 = _0024_00248093_002415506.Length; _0024_00248092_002415505 < _0024_00248094_002415507; _0024_00248092_002415505++)
						{
							_0024memName_002415502 = Path.GetFileNameWithoutExtension(_0024_00248093_002415506[_0024_00248092_002415505]);
							_0024memName_002415502 = _0024memName_002415502.Replace(" ", "_").Replace("-", "_");
							TypeMemberCollection members = _0024enumDef_002415500.Members;
							EnumMember enumMember = (_0024_00244130_002415503 = new EnumMember());
							string text4 = (_0024_00244130_002415503.Name = _0024memName_002415502);
							members.Add(_0024_00244130_002415503);
						}
						TypeMemberCollection members2 = _0024enumDef_002415500.Members;
						EnumMember enumMember2 = (_0024_00244131_002415504 = new EnumMember());
						string text6 = (_0024_00244131_002415504.Name = "__NONE__");
						members2.Add(_0024_00244131_002415504);
						result = (Yield(2, _0024enumDef_002415500) ? 1 : 0);
						break;
					}
					case 2:
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

		internal string _0024enumName_002415510;

		internal string[] _0024paths_002415511;

		public _0024GenEnum_002415498(string enumName, string[] paths)
		{
			_0024enumName_002415510 = enumName;
			_0024paths_002415511 = paths;
		}

		public override IEnumerator<EnumDefinition> GetEnumerator()
		{
			return new _0024(_0024enumName_002415510, _0024paths_002415511);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GenEnumTableCode_002415512 : GenericGenerator<TypeMember>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<TypeMember>, IEnumerator
		{
			internal ArrayLiteralExpression _0024pathlits_002415513;

			internal ArrayLiteralExpression _0024namelits_002415514;

			internal string _0024path_002415515;

			internal string _0024sn_002415516;

			internal ReferenceExpression _0024pathTbl_002415517;

			internal ReferenceExpression _0024nameTbl_002415518;

			internal ReferenceExpression _0024enumRef_002415519;

			internal ReferenceExpression _0024toPathMethod_002415520;

			internal ReferenceExpression _0024toNameMethod_002415521;

			internal ReferenceExpression _0024validatorMethod_002415522;

			internal ReferenceExpression _0024toEnumMethod_002415523;

			internal int _0024enumNum_002415524;

			internal SimpleTypeReference _0024_00244132_002415525;

			internal ArrayTypeReference _0024_00244133_002415526;

			internal Field _0024_00244134_002415527;

			internal SimpleTypeReference _0024_00244135_002415528;

			internal ArrayTypeReference _0024_00244136_002415529;

			internal Field _0024_00244137_002415530;

			internal ParameterDeclaration _0024_00244138_002415531;

			internal SimpleTypeReference _0024_00244139_002415532;

			internal ReferenceExpression _0024_00244140_002415533;

			internal MemberReferenceExpression _0024_00244141_002415534;

			internal BinaryExpression _0024_00244142_002415535;

			internal StringLiteralExpression _0024_00244143_002415536;

			internal ReturnStatement _0024_00244144_002415537;

			internal Block _0024_00244145_002415538;

			internal IfStatement _0024_00244146_002415539;

			internal IntegerLiteralExpression _0024_00244147_002415540;

			internal ReferenceExpression _0024_00244148_002415541;

			internal BinaryExpression _0024_00244149_002415542;

			internal ReferenceExpression _0024_00244150_002415543;

			internal BinaryExpression _0024_00244151_002415544;

			internal BinaryExpression _0024_00244152_002415545;

			internal StringLiteralExpression _0024_00244153_002415546;

			internal ReferenceExpression _0024_00244154_002415547;

			internal StringLiteralExpression _0024_00244155_002415548;

			internal ExpressionInterpolationExpression _0024_00244156_002415549;

			internal BinaryExpression _0024_00244157_002415550;

			internal MacroStatement _0024_00244158_002415551;

			internal ReferenceExpression _0024_00244159_002415552;

			internal Slice _0024_00244160_002415553;

			internal SlicingExpression _0024_00244161_002415554;

			internal ReturnStatement _0024_00244162_002415555;

			internal Block _0024_00244163_002415556;

			internal Method _0024_00244164_002415557;

			internal ParameterDeclaration _0024_00244165_002415558;

			internal SimpleTypeReference _0024_00244166_002415559;

			internal ReferenceExpression _0024_00244167_002415560;

			internal MemberReferenceExpression _0024_00244168_002415561;

			internal BinaryExpression _0024_00244169_002415562;

			internal StringLiteralExpression _0024_00244170_002415563;

			internal ReturnStatement _0024_00244171_002415564;

			internal Block _0024_00244172_002415565;

			internal IfStatement _0024_00244173_002415566;

			internal IntegerLiteralExpression _0024_00244174_002415567;

			internal ReferenceExpression _0024_00244175_002415568;

			internal BinaryExpression _0024_00244176_002415569;

			internal ReferenceExpression _0024_00244177_002415570;

			internal BinaryExpression _0024_00244178_002415571;

			internal BinaryExpression _0024_00244179_002415572;

			internal StringLiteralExpression _0024_00244180_002415573;

			internal ReferenceExpression _0024_00244181_002415574;

			internal StringLiteralExpression _0024_00244182_002415575;

			internal ExpressionInterpolationExpression _0024_00244183_002415576;

			internal BinaryExpression _0024_00244184_002415577;

			internal MacroStatement _0024_00244185_002415578;

			internal ReferenceExpression _0024_00244186_002415579;

			internal Slice _0024_00244187_002415580;

			internal SlicingExpression _0024_00244188_002415581;

			internal ReturnStatement _0024_00244189_002415582;

			internal Block _0024_00244190_002415583;

			internal Method _0024_00244191_002415584;

			internal ParameterDeclaration _0024_00244192_002415585;

			internal SimpleTypeReference _0024_00244193_002415586;

			internal IntegerLiteralExpression _0024_00244194_002415587;

			internal ReferenceExpression _0024_00244195_002415588;

			internal BinaryExpression _0024_00244196_002415589;

			internal ReferenceExpression _0024_00244197_002415590;

			internal BinaryExpression _0024_00244198_002415591;

			internal BinaryExpression _0024_00244199_002415592;

			internal ReturnStatement _0024_00244200_002415593;

			internal Block _0024_00244201_002415594;

			internal Method _0024_00244202_002415595;

			internal SimpleTypeReference _0024_00244203_002415596;

			internal ParameterDeclaration _0024_00244204_002415597;

			internal ReferenceExpression _0024_00244205_002415598;

			internal MemberReferenceExpression _0024_00244206_002415599;

			internal ReferenceExpression _0024_00244207_002415600;

			internal MethodInvocationExpression _0024_00244208_002415601;

			internal StatementModifier _0024_00244209_002415602;

			internal MemberReferenceExpression _0024_00244210_002415603;

			internal ReturnStatement _0024_00244211_002415604;

			internal Declaration _0024_00244212_002415605;

			internal ReferenceExpression _0024_00244213_002415606;

			internal MemberReferenceExpression _0024_00244214_002415607;

			internal MethodInvocationExpression _0024_00244215_002415608;

			internal ReferenceExpression _0024_00244216_002415609;

			internal ReferenceExpression _0024_00244217_002415610;

			internal Slice _0024_00244218_002415611;

			internal SlicingExpression _0024_00244219_002415612;

			internal BinaryExpression _0024_00244220_002415613;

			internal StatementModifier _0024_00244221_002415614;

			internal ReferenceExpression _0024_00244222_002415615;

			internal CastExpression _0024_00244223_002415616;

			internal ReturnStatement _0024_00244224_002415617;

			internal Block _0024_00244225_002415618;

			internal ForStatement _0024_00244226_002415619;

			internal MemberReferenceExpression _0024_00244227_002415620;

			internal ReturnStatement _0024_00244228_002415621;

			internal Block _0024_00244229_002415622;

			internal Method _0024_00244230_002415623;

			internal int _0024_00248096_002415624;

			internal string[] _0024_00248097_002415625;

			internal int _0024_00248098_002415626;

			internal string _0024enumName_002415627;

			internal string[] _0024paths_002415628;

			public _0024(string enumName, string[] paths)
			{
				_0024enumName_002415627 = enumName;
				_0024paths_002415628 = paths;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
					{
						_0024pathlits_002415513 = new ArrayLiteralExpression();
						_0024namelits_002415514 = new ArrayLiteralExpression();
						_0024_00248096_002415624 = 0;
						_0024_00248097_002415625 = _0024paths_002415628;
						for (_0024_00248098_002415626 = _0024_00248097_002415625.Length; _0024_00248096_002415624 < _0024_00248098_002415626; _0024_00248096_002415624++)
						{
							_0024pathlits_002415513.Items.Add(new StringLiteralExpression(_0024_00248097_002415625[_0024_00248096_002415624]));
							_0024sn_002415516 = Path.GetFileNameWithoutExtension(_0024_00248097_002415625[_0024_00248096_002415624]);
							_0024namelits_002415514.Items.Add(new StringLiteralExpression(_0024sn_002415516));
						}
						_0024pathTbl_002415517 = new ReferenceExpression(CompilerContext.Current.GetUniqueName("genenum", _0024enumName_002415627));
						_0024nameTbl_002415518 = new ReferenceExpression(CompilerContext.Current.GetUniqueName("genenum", _0024enumName_002415627));
						_0024enumRef_002415519 = new ReferenceExpression(_0024enumName_002415627);
						_0024toPathMethod_002415520 = new ReferenceExpression(_0024enumName_002415627 + "ToPath");
						_0024toNameMethod_002415521 = new ReferenceExpression(_0024enumName_002415627 + "ToName");
						_0024validatorMethod_002415522 = new ReferenceExpression("IsValid" + _0024enumName_002415627);
						_0024toEnumMethod_002415523 = new ReferenceExpression("StrTo" + _0024enumName_002415627);
						_0024enumNum_002415524 = _0024paths_002415628.Length;
						Field field3 = (_0024_00244134_002415527 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers4 = (_0024_00244134_002415527.Modifiers = TypeMemberModifiers.Static);
						string text104 = (_0024_00244134_002415527.Name = "$");
						Field field4 = _0024_00244134_002415527;
						ArrayTypeReference arrayTypeReference3 = (_0024_00244133_002415526 = new ArrayTypeReference(LexicalInfo.Empty));
						bool flag22 = (_0024_00244133_002415526.IsPointer = false);
						ArrayTypeReference arrayTypeReference4 = _0024_00244133_002415526;
						SimpleTypeReference simpleTypeReference6 = (_0024_00244132_002415525 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag24 = (_0024_00244132_002415525.IsPointer = false);
						string text106 = (_0024_00244132_002415525.Name = "string");
						TypeReference typeReference24 = (arrayTypeReference4.ElementType = _0024_00244132_002415525);
						TypeReference typeReference26 = (field4.Type = _0024_00244133_002415526);
						Expression expression116 = (_0024_00244134_002415527.Initializer = Expression.Lift(_0024pathlits_002415513));
						bool flag26 = (_0024_00244134_002415527.IsVolatile = false);
						string text108 = (_0024_00244134_002415527.Name = CodeSerializer.LiftName(_0024pathTbl_002415517));
						result = (Yield(2, _0024_00244134_002415527) ? 1 : 0);
						break;
					}
					case 2:
					{
						Field field = (_0024_00244137_002415530 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00244137_002415530.Modifiers = TypeMemberModifiers.Static);
						string text98 = (_0024_00244137_002415530.Name = "$");
						Field field2 = _0024_00244137_002415530;
						ArrayTypeReference arrayTypeReference = (_0024_00244136_002415529 = new ArrayTypeReference(LexicalInfo.Empty));
						bool flag16 = (_0024_00244136_002415529.IsPointer = false);
						ArrayTypeReference arrayTypeReference2 = _0024_00244136_002415529;
						SimpleTypeReference simpleTypeReference5 = (_0024_00244135_002415528 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag18 = (_0024_00244135_002415528.IsPointer = false);
						string text100 = (_0024_00244135_002415528.Name = "string");
						TypeReference typeReference20 = (arrayTypeReference2.ElementType = _0024_00244135_002415528);
						TypeReference typeReference22 = (field2.Type = _0024_00244136_002415529);
						Expression expression114 = (_0024_00244137_002415530.Initializer = Expression.Lift(_0024namelits_002415514));
						bool flag20 = (_0024_00244137_002415530.IsVolatile = false);
						string text102 = (_0024_00244137_002415530.Name = CodeSerializer.LiftName(_0024nameTbl_002415518));
						result = (Yield(3, _0024_00244137_002415530) ? 1 : 0);
						break;
					}
					case 3:
					{
						Method method12 = (_0024_00244164_002415557 = new Method(LexicalInfo.Empty));
						string text71 = (_0024_00244164_002415557.Name = "$");
						Method method13 = _0024_00244164_002415557;
						ParameterDeclaration[] array16 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration5 = (_0024_00244138_002415531 = new ParameterDeclaration(LexicalInfo.Empty));
						string text73 = (_0024_00244138_002415531.Name = "e");
						TypeReference typeReference16 = (_0024_00244138_002415531.Type = TypeReference.Lift(_0024enumRef_002415519));
						array16[0] = _0024_00244138_002415531;
						ParameterDeclarationCollection parameterDeclarationCollection8 = (method13.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array16));
						Method method14 = _0024_00244164_002415557;
						SimpleTypeReference simpleTypeReference4 = (_0024_00244139_002415532 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag12 = (_0024_00244139_002415532.IsPointer = false);
						string text75 = (_0024_00244139_002415532.Name = "string");
						TypeReference typeReference18 = (method14.ReturnType = _0024_00244139_002415532);
						Method method15 = _0024_00244164_002415557;
						Block block23 = (_0024_00244163_002415556 = new Block(LexicalInfo.Empty));
						Block block24 = _0024_00244163_002415556;
						Statement[] array17 = new Statement[3];
						IfStatement ifStatement4 = (_0024_00244146_002415539 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement5 = _0024_00244146_002415539;
						BinaryExpression binaryExpression25 = (_0024_00244142_002415535 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType20 = (_0024_00244142_002415535.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression26 = _0024_00244142_002415535;
						ReferenceExpression referenceExpression14 = (_0024_00244140_002415533 = new ReferenceExpression(LexicalInfo.Empty));
						string text77 = (_0024_00244140_002415533.Name = "e");
						Expression expression82 = (binaryExpression26.Left = _0024_00244140_002415533);
						BinaryExpression binaryExpression27 = _0024_00244142_002415535;
						MemberReferenceExpression memberReferenceExpression7 = (_0024_00244141_002415534 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text79 = (_0024_00244141_002415534.Name = "__NONE__");
						Expression expression84 = (_0024_00244141_002415534.Target = Expression.Lift(_0024enumRef_002415519));
						Expression expression86 = (binaryExpression27.Right = _0024_00244141_002415534);
						Expression expression88 = (ifStatement5.Condition = _0024_00244142_002415535);
						IfStatement ifStatement6 = _0024_00244146_002415539;
						Block block25 = (_0024_00244145_002415538 = new Block(LexicalInfo.Empty));
						Block block26 = _0024_00244145_002415538;
						Statement[] array18 = new Statement[1];
						ReturnStatement returnStatement15 = (_0024_00244144_002415537 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement16 = _0024_00244144_002415537;
						StringLiteralExpression stringLiteralExpression4 = (_0024_00244143_002415536 = new StringLiteralExpression(LexicalInfo.Empty));
						string text81 = (_0024_00244143_002415536.Value = "<NONE>");
						Expression expression90 = (returnStatement16.Expression = _0024_00244143_002415536);
						array18[0] = Statement.Lift(_0024_00244144_002415537);
						StatementCollection statementCollection12 = (block26.Statements = StatementCollection.FromArray(array18));
						Block block28 = (ifStatement6.TrueBlock = _0024_00244145_002415538);
						array17[0] = Statement.Lift(_0024_00244146_002415539);
						MacroStatement macroStatement3 = (_0024_00244158_002415551 = new MacroStatement(LexicalInfo.Empty));
						string text83 = (_0024_00244158_002415551.Name = "assert");
						MacroStatement macroStatement4 = _0024_00244158_002415551;
						Expression[] array19 = new Expression[2];
						BinaryExpression binaryExpression28 = (_0024_00244152_002415545 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType22 = (_0024_00244152_002415545.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression29 = _0024_00244152_002415545;
						BinaryExpression binaryExpression30 = (_0024_00244149_002415542 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType24 = (_0024_00244149_002415542.Operator = BinaryOperatorType.LessThanOrEqual);
						BinaryExpression binaryExpression31 = _0024_00244149_002415542;
						IntegerLiteralExpression integerLiteralExpression3 = (_0024_00244147_002415540 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num6 = (_0024_00244147_002415540.Value = 0L);
						bool flag14 = (_0024_00244147_002415540.IsLong = false);
						Expression expression92 = (binaryExpression31.Left = _0024_00244147_002415540);
						BinaryExpression binaryExpression32 = _0024_00244149_002415542;
						ReferenceExpression referenceExpression15 = (_0024_00244148_002415541 = new ReferenceExpression(LexicalInfo.Empty));
						string text85 = (_0024_00244148_002415541.Name = "e");
						Expression expression94 = (binaryExpression32.Right = _0024_00244148_002415541);
						Expression expression96 = (binaryExpression29.Left = _0024_00244149_002415542);
						BinaryExpression binaryExpression33 = _0024_00244152_002415545;
						BinaryExpression binaryExpression34 = (_0024_00244151_002415544 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType26 = (_0024_00244151_002415544.Operator = BinaryOperatorType.LessThan);
						BinaryExpression binaryExpression35 = _0024_00244151_002415544;
						ReferenceExpression referenceExpression16 = (_0024_00244150_002415543 = new ReferenceExpression(LexicalInfo.Empty));
						string text87 = (_0024_00244150_002415543.Name = "e");
						Expression expression98 = (binaryExpression35.Left = _0024_00244150_002415543);
						Expression expression100 = (_0024_00244151_002415544.Right = Expression.Lift(_0024enumNum_002415524));
						Expression expression102 = (binaryExpression33.Right = _0024_00244151_002415544);
						array19[0] = _0024_00244152_002415545;
						BinaryExpression binaryExpression36 = (_0024_00244157_002415550 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType28 = (_0024_00244157_002415550.Operator = BinaryOperatorType.Addition);
						Expression expression104 = (_0024_00244157_002415550.Left = Expression.Lift(_0024enumName_002415627));
						BinaryExpression binaryExpression37 = _0024_00244157_002415550;
						ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00244156_002415549 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
						ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00244156_002415549;
						Expression[] array20 = new Expression[3];
						StringLiteralExpression stringLiteralExpression5 = (_0024_00244153_002415546 = new StringLiteralExpression(LexicalInfo.Empty));
						string text89 = (_0024_00244153_002415546.Value = "エラー: ");
						array20[0] = _0024_00244153_002415546;
						ReferenceExpression referenceExpression17 = (_0024_00244154_002415547 = new ReferenceExpression(LexicalInfo.Empty));
						string text91 = (_0024_00244154_002415547.Name = "e");
						array20[1] = _0024_00244154_002415547;
						StringLiteralExpression stringLiteralExpression6 = (_0024_00244155_002415548 = new StringLiteralExpression(LexicalInfo.Empty));
						string text92 = (_0024_00244155_002415548.Value = string.Empty);
						array20[2] = _0024_00244155_002415548;
						ExpressionCollection expressionCollection10 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array20));
						Expression expression106 = (binaryExpression37.Right = _0024_00244156_002415549);
						array19[1] = _0024_00244157_002415550;
						ExpressionCollection expressionCollection12 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array19));
						Block block30 = (_0024_00244158_002415551.Body = new Block(LexicalInfo.Empty));
						array17[1] = Statement.Lift(_0024_00244158_002415551);
						ReturnStatement returnStatement17 = (_0024_00244162_002415555 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement18 = _0024_00244162_002415555;
						SlicingExpression slicingExpression5 = (_0024_00244161_002415554 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression108 = (_0024_00244161_002415554.Target = Expression.Lift(_0024pathTbl_002415517));
						SlicingExpression slicingExpression6 = _0024_00244161_002415554;
						Slice[] array21 = new Slice[1];
						Slice slice5 = (_0024_00244160_002415553 = new Slice(LexicalInfo.Empty));
						Slice slice6 = _0024_00244160_002415553;
						ReferenceExpression referenceExpression18 = (_0024_00244159_002415552 = new ReferenceExpression(LexicalInfo.Empty));
						string text94 = (_0024_00244159_002415552.Name = "e");
						Expression expression110 = (slice6.Begin = _0024_00244159_002415552);
						array21[0] = _0024_00244160_002415553;
						SliceCollection sliceCollection6 = (slicingExpression6.Indices = SliceCollection.FromArray(array21));
						Expression expression112 = (returnStatement18.Expression = _0024_00244161_002415554);
						array17[2] = Statement.Lift(_0024_00244162_002415555);
						StatementCollection statementCollection14 = (block24.Statements = StatementCollection.FromArray(array17));
						Block block32 = (method15.Body = _0024_00244163_002415556);
						string text96 = (_0024_00244164_002415557.Name = CodeSerializer.LiftName(_0024toPathMethod_002415520));
						result = (Yield(4, _0024_00244164_002415557) ? 1 : 0);
						break;
					}
					case 4:
					{
						Method method8 = (_0024_00244191_002415584 = new Method(LexicalInfo.Empty));
						string text44 = (_0024_00244191_002415584.Name = "$");
						Method method9 = _0024_00244191_002415584;
						ParameterDeclaration[] array10 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration4 = (_0024_00244165_002415558 = new ParameterDeclaration(LexicalInfo.Empty));
						string text46 = (_0024_00244165_002415558.Name = "e");
						TypeReference typeReference12 = (_0024_00244165_002415558.Type = TypeReference.Lift(_0024enumRef_002415519));
						array10[0] = _0024_00244165_002415558;
						ParameterDeclarationCollection parameterDeclarationCollection6 = (method9.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array10));
						Method method10 = _0024_00244191_002415584;
						SimpleTypeReference simpleTypeReference3 = (_0024_00244166_002415559 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag8 = (_0024_00244166_002415559.IsPointer = false);
						string text48 = (_0024_00244166_002415559.Name = "string");
						TypeReference typeReference14 = (method10.ReturnType = _0024_00244166_002415559);
						Method method11 = _0024_00244191_002415584;
						Block block13 = (_0024_00244190_002415583 = new Block(LexicalInfo.Empty));
						Block block14 = _0024_00244190_002415583;
						Statement[] array11 = new Statement[3];
						IfStatement ifStatement = (_0024_00244173_002415566 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement2 = _0024_00244173_002415566;
						BinaryExpression binaryExpression12 = (_0024_00244169_002415562 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType10 = (_0024_00244169_002415562.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression13 = _0024_00244169_002415562;
						ReferenceExpression referenceExpression9 = (_0024_00244167_002415560 = new ReferenceExpression(LexicalInfo.Empty));
						string text50 = (_0024_00244167_002415560.Name = "e");
						Expression expression50 = (binaryExpression13.Left = _0024_00244167_002415560);
						BinaryExpression binaryExpression14 = _0024_00244169_002415562;
						MemberReferenceExpression memberReferenceExpression6 = (_0024_00244168_002415561 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text52 = (_0024_00244168_002415561.Name = "__NONE__");
						Expression expression52 = (_0024_00244168_002415561.Target = Expression.Lift(_0024enumRef_002415519));
						Expression expression54 = (binaryExpression14.Right = _0024_00244168_002415561);
						Expression expression56 = (ifStatement2.Condition = _0024_00244169_002415562);
						IfStatement ifStatement3 = _0024_00244173_002415566;
						Block block15 = (_0024_00244172_002415565 = new Block(LexicalInfo.Empty));
						Block block16 = _0024_00244172_002415565;
						Statement[] array12 = new Statement[1];
						ReturnStatement returnStatement11 = (_0024_00244171_002415564 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement12 = _0024_00244171_002415564;
						StringLiteralExpression stringLiteralExpression = (_0024_00244170_002415563 = new StringLiteralExpression(LexicalInfo.Empty));
						string text54 = (_0024_00244170_002415563.Value = "<NONE>");
						Expression expression58 = (returnStatement12.Expression = _0024_00244170_002415563);
						array12[0] = Statement.Lift(_0024_00244171_002415564);
						StatementCollection statementCollection8 = (block16.Statements = StatementCollection.FromArray(array12));
						Block block18 = (ifStatement3.TrueBlock = _0024_00244172_002415565);
						array11[0] = Statement.Lift(_0024_00244173_002415566);
						MacroStatement macroStatement = (_0024_00244185_002415578 = new MacroStatement(LexicalInfo.Empty));
						string text56 = (_0024_00244185_002415578.Name = "assert");
						MacroStatement macroStatement2 = _0024_00244185_002415578;
						Expression[] array13 = new Expression[2];
						BinaryExpression binaryExpression15 = (_0024_00244179_002415572 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType12 = (_0024_00244179_002415572.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression16 = _0024_00244179_002415572;
						BinaryExpression binaryExpression17 = (_0024_00244176_002415569 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType14 = (_0024_00244176_002415569.Operator = BinaryOperatorType.LessThanOrEqual);
						BinaryExpression binaryExpression18 = _0024_00244176_002415569;
						IntegerLiteralExpression integerLiteralExpression2 = (_0024_00244174_002415567 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num4 = (_0024_00244174_002415567.Value = 0L);
						bool flag10 = (_0024_00244174_002415567.IsLong = false);
						Expression expression60 = (binaryExpression18.Left = _0024_00244174_002415567);
						BinaryExpression binaryExpression19 = _0024_00244176_002415569;
						ReferenceExpression referenceExpression10 = (_0024_00244175_002415568 = new ReferenceExpression(LexicalInfo.Empty));
						string text58 = (_0024_00244175_002415568.Name = "e");
						Expression expression62 = (binaryExpression19.Right = _0024_00244175_002415568);
						Expression expression64 = (binaryExpression16.Left = _0024_00244176_002415569);
						BinaryExpression binaryExpression20 = _0024_00244179_002415572;
						BinaryExpression binaryExpression21 = (_0024_00244178_002415571 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType16 = (_0024_00244178_002415571.Operator = BinaryOperatorType.LessThan);
						BinaryExpression binaryExpression22 = _0024_00244178_002415571;
						ReferenceExpression referenceExpression11 = (_0024_00244177_002415570 = new ReferenceExpression(LexicalInfo.Empty));
						string text60 = (_0024_00244177_002415570.Name = "e");
						Expression expression66 = (binaryExpression22.Left = _0024_00244177_002415570);
						Expression expression68 = (_0024_00244178_002415571.Right = Expression.Lift(_0024enumNum_002415524));
						Expression expression70 = (binaryExpression20.Right = _0024_00244178_002415571);
						array13[0] = _0024_00244179_002415572;
						BinaryExpression binaryExpression23 = (_0024_00244184_002415577 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType18 = (_0024_00244184_002415577.Operator = BinaryOperatorType.Addition);
						Expression expression72 = (_0024_00244184_002415577.Left = Expression.Lift(_0024enumNum_002415524));
						BinaryExpression binaryExpression24 = _0024_00244184_002415577;
						ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00244183_002415576 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
						ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00244183_002415576;
						Expression[] array14 = new Expression[3];
						StringLiteralExpression stringLiteralExpression2 = (_0024_00244180_002415573 = new StringLiteralExpression(LexicalInfo.Empty));
						string text62 = (_0024_00244180_002415573.Value = "エラー: ");
						array14[0] = _0024_00244180_002415573;
						ReferenceExpression referenceExpression12 = (_0024_00244181_002415574 = new ReferenceExpression(LexicalInfo.Empty));
						string text64 = (_0024_00244181_002415574.Name = "e");
						array14[1] = _0024_00244181_002415574;
						StringLiteralExpression stringLiteralExpression3 = (_0024_00244182_002415575 = new StringLiteralExpression(LexicalInfo.Empty));
						string text65 = (_0024_00244182_002415575.Value = string.Empty);
						array14[2] = _0024_00244182_002415575;
						ExpressionCollection expressionCollection6 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array14));
						Expression expression74 = (binaryExpression24.Right = _0024_00244183_002415576);
						array13[1] = _0024_00244184_002415577;
						ExpressionCollection expressionCollection8 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array13));
						Block block20 = (_0024_00244185_002415578.Body = new Block(LexicalInfo.Empty));
						array11[1] = Statement.Lift(_0024_00244185_002415578);
						ReturnStatement returnStatement13 = (_0024_00244189_002415582 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement14 = _0024_00244189_002415582;
						SlicingExpression slicingExpression3 = (_0024_00244188_002415581 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression76 = (_0024_00244188_002415581.Target = Expression.Lift(_0024nameTbl_002415518));
						SlicingExpression slicingExpression4 = _0024_00244188_002415581;
						Slice[] array15 = new Slice[1];
						Slice slice3 = (_0024_00244187_002415580 = new Slice(LexicalInfo.Empty));
						Slice slice4 = _0024_00244187_002415580;
						ReferenceExpression referenceExpression13 = (_0024_00244186_002415579 = new ReferenceExpression(LexicalInfo.Empty));
						string text67 = (_0024_00244186_002415579.Name = "e");
						Expression expression78 = (slice4.Begin = _0024_00244186_002415579);
						array15[0] = _0024_00244187_002415580;
						SliceCollection sliceCollection4 = (slicingExpression4.Indices = SliceCollection.FromArray(array15));
						Expression expression80 = (returnStatement14.Expression = _0024_00244188_002415581);
						array11[2] = Statement.Lift(_0024_00244189_002415582);
						StatementCollection statementCollection10 = (block14.Statements = StatementCollection.FromArray(array11));
						Block block22 = (method11.Body = _0024_00244190_002415583);
						string text69 = (_0024_00244191_002415584.Name = CodeSerializer.LiftName(_0024toNameMethod_002415521));
						result = (Yield(5, _0024_00244191_002415584) ? 1 : 0);
						break;
					}
					case 5:
					{
						Method method4 = (_0024_00244202_002415595 = new Method(LexicalInfo.Empty));
						string text32 = (_0024_00244202_002415595.Name = "$");
						Method method5 = _0024_00244202_002415595;
						ParameterDeclaration[] array8 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration3 = (_0024_00244192_002415585 = new ParameterDeclaration(LexicalInfo.Empty));
						string text34 = (_0024_00244192_002415585.Name = "e");
						TypeReference typeReference8 = (_0024_00244192_002415585.Type = TypeReference.Lift(_0024enumRef_002415519));
						array8[0] = _0024_00244192_002415585;
						ParameterDeclarationCollection parameterDeclarationCollection4 = (method5.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array8));
						Method method6 = _0024_00244202_002415595;
						SimpleTypeReference simpleTypeReference2 = (_0024_00244193_002415586 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag4 = (_0024_00244193_002415586.IsPointer = false);
						string text36 = (_0024_00244193_002415586.Name = "bool");
						TypeReference typeReference10 = (method6.ReturnType = _0024_00244193_002415586);
						Method method7 = _0024_00244202_002415595;
						Block block9 = (_0024_00244201_002415594 = new Block(LexicalInfo.Empty));
						Block block10 = _0024_00244201_002415594;
						Statement[] array9 = new Statement[1];
						ReturnStatement returnStatement9 = (_0024_00244200_002415593 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement10 = _0024_00244200_002415593;
						BinaryExpression binaryExpression4 = (_0024_00244199_002415592 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00244199_002415592.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression5 = _0024_00244199_002415592;
						BinaryExpression binaryExpression6 = (_0024_00244196_002415589 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType6 = (_0024_00244196_002415589.Operator = BinaryOperatorType.LessThanOrEqual);
						BinaryExpression binaryExpression7 = _0024_00244196_002415589;
						IntegerLiteralExpression integerLiteralExpression = (_0024_00244194_002415587 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num2 = (_0024_00244194_002415587.Value = 0L);
						bool flag6 = (_0024_00244194_002415587.IsLong = false);
						Expression expression36 = (binaryExpression7.Left = _0024_00244194_002415587);
						BinaryExpression binaryExpression8 = _0024_00244196_002415589;
						ReferenceExpression referenceExpression7 = (_0024_00244195_002415588 = new ReferenceExpression(LexicalInfo.Empty));
						string text38 = (_0024_00244195_002415588.Name = "e");
						Expression expression38 = (binaryExpression8.Right = _0024_00244195_002415588);
						Expression expression40 = (binaryExpression5.Left = _0024_00244196_002415589);
						BinaryExpression binaryExpression9 = _0024_00244199_002415592;
						BinaryExpression binaryExpression10 = (_0024_00244198_002415591 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType8 = (_0024_00244198_002415591.Operator = BinaryOperatorType.LessThan);
						BinaryExpression binaryExpression11 = _0024_00244198_002415591;
						ReferenceExpression referenceExpression8 = (_0024_00244197_002415590 = new ReferenceExpression(LexicalInfo.Empty));
						string text40 = (_0024_00244197_002415590.Name = "e");
						Expression expression42 = (binaryExpression11.Left = _0024_00244197_002415590);
						Expression expression44 = (_0024_00244198_002415591.Right = Expression.Lift(_0024enumNum_002415524));
						Expression expression46 = (binaryExpression9.Right = _0024_00244198_002415591);
						Expression expression48 = (returnStatement10.Expression = _0024_00244199_002415592);
						array9[0] = Statement.Lift(_0024_00244200_002415593);
						StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(array9));
						Block block12 = (method7.Body = _0024_00244201_002415594);
						string text42 = (_0024_00244202_002415595.Name = CodeSerializer.LiftName(_0024validatorMethod_002415522));
						result = (Yield(6, _0024_00244202_002415595) ? 1 : 0);
						break;
					}
					case 6:
					{
						Method method = (_0024_00244230_002415623 = new Method(LexicalInfo.Empty));
						string text2 = (_0024_00244230_002415623.Name = "$");
						Method method2 = _0024_00244230_002415623;
						ParameterDeclaration[] array = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration = (_0024_00244204_002415597 = new ParameterDeclaration(LexicalInfo.Empty));
						string text4 = (_0024_00244204_002415597.Name = "s");
						ParameterDeclaration parameterDeclaration2 = _0024_00244204_002415597;
						SimpleTypeReference simpleTypeReference = (_0024_00244203_002415596 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag2 = (_0024_00244203_002415596.IsPointer = false);
						string text6 = (_0024_00244203_002415596.Name = "string");
						TypeReference typeReference2 = (parameterDeclaration2.Type = _0024_00244203_002415596);
						array[0] = _0024_00244204_002415597;
						ParameterDeclarationCollection parameterDeclarationCollection2 = (method2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array));
						TypeReference typeReference4 = (_0024_00244230_002415623.ReturnType = TypeReference.Lift(_0024enumRef_002415519));
						Method method3 = _0024_00244230_002415623;
						Block block = (_0024_00244229_002415622 = new Block(LexicalInfo.Empty));
						Block block2 = _0024_00244229_002415622;
						Statement[] array2 = new Statement[3];
						ReturnStatement returnStatement = (_0024_00244211_002415604 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00244211_002415604;
						StatementModifier statementModifier = (_0024_00244209_002415602 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType2 = (_0024_00244209_002415602.Type = StatementModifierType.If);
						StatementModifier statementModifier2 = _0024_00244209_002415602;
						MethodInvocationExpression methodInvocationExpression = (_0024_00244208_002415601 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00244208_002415601;
						MemberReferenceExpression memberReferenceExpression = (_0024_00244206_002415599 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text8 = (_0024_00244206_002415599.Name = "IsNullOrEmpty");
						MemberReferenceExpression memberReferenceExpression2 = _0024_00244206_002415599;
						ReferenceExpression referenceExpression = (_0024_00244205_002415598 = new ReferenceExpression(LexicalInfo.Empty));
						string text10 = (_0024_00244205_002415598.Name = "string");
						Expression expression2 = (memberReferenceExpression2.Target = _0024_00244205_002415598);
						Expression expression4 = (methodInvocationExpression2.Target = _0024_00244206_002415599);
						MethodInvocationExpression methodInvocationExpression3 = _0024_00244208_002415601;
						Expression[] array3 = new Expression[1];
						ReferenceExpression referenceExpression2 = (_0024_00244207_002415600 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00244207_002415600.Name = "s");
						array3[0] = _0024_00244207_002415600;
						ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(array3));
						Expression expression6 = (statementModifier2.Condition = _0024_00244208_002415601);
						StatementModifier statementModifier4 = (returnStatement2.Modifier = _0024_00244209_002415602);
						ReturnStatement returnStatement3 = _0024_00244211_002415604;
						MemberReferenceExpression memberReferenceExpression3 = (_0024_00244210_002415603 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text14 = (_0024_00244210_002415603.Name = "__NONE__");
						Expression expression8 = (_0024_00244210_002415603.Target = Expression.Lift(_0024enumRef_002415519));
						Expression expression10 = (returnStatement3.Expression = _0024_00244210_002415603);
						array2[0] = Statement.Lift(_0024_00244211_002415604);
						ForStatement forStatement = (_0024_00244226_002415619 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement2 = _0024_00244226_002415619;
						Declaration[] array4 = new Declaration[1];
						Declaration declaration = (_0024_00244212_002415605 = new Declaration(LexicalInfo.Empty));
						string text16 = (_0024_00244212_002415605.Name = "i");
						array4[0] = _0024_00244212_002415605;
						DeclarationCollection declarationCollection2 = (forStatement2.Declarations = DeclarationCollection.FromArray(array4));
						ForStatement forStatement3 = _0024_00244226_002415619;
						MethodInvocationExpression methodInvocationExpression4 = (_0024_00244215_002415608 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression5 = _0024_00244215_002415608;
						ReferenceExpression referenceExpression3 = (_0024_00244213_002415606 = new ReferenceExpression(LexicalInfo.Empty));
						string text18 = (_0024_00244213_002415606.Name = "range");
						Expression expression12 = (methodInvocationExpression5.Target = _0024_00244213_002415606);
						MethodInvocationExpression methodInvocationExpression6 = _0024_00244215_002415608;
						Expression[] array5 = new Expression[1];
						MemberReferenceExpression memberReferenceExpression4 = (_0024_00244214_002415607 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text20 = (_0024_00244214_002415607.Name = "Length");
						Expression expression14 = (_0024_00244214_002415607.Target = Expression.Lift(_0024nameTbl_002415518));
						array5[0] = _0024_00244214_002415607;
						ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array5));
						Expression expression16 = (forStatement3.Iterator = _0024_00244215_002415608);
						ForStatement forStatement4 = _0024_00244226_002415619;
						Block block3 = (_0024_00244225_002415618 = new Block(LexicalInfo.Empty));
						Block block4 = _0024_00244225_002415618;
						Statement[] array6 = new Statement[1];
						ReturnStatement returnStatement4 = (_0024_00244224_002415617 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement5 = _0024_00244224_002415617;
						StatementModifier statementModifier5 = (_0024_00244221_002415614 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType4 = (_0024_00244221_002415614.Type = StatementModifierType.If);
						StatementModifier statementModifier6 = _0024_00244221_002415614;
						BinaryExpression binaryExpression = (_0024_00244220_002415613 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00244220_002415613.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression2 = _0024_00244220_002415613;
						ReferenceExpression referenceExpression4 = (_0024_00244216_002415609 = new ReferenceExpression(LexicalInfo.Empty));
						string text22 = (_0024_00244216_002415609.Name = "s");
						Expression expression18 = (binaryExpression2.Left = _0024_00244216_002415609);
						BinaryExpression binaryExpression3 = _0024_00244220_002415613;
						SlicingExpression slicingExpression = (_0024_00244219_002415612 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression20 = (_0024_00244219_002415612.Target = Expression.Lift(_0024nameTbl_002415518));
						SlicingExpression slicingExpression2 = _0024_00244219_002415612;
						Slice[] array7 = new Slice[1];
						Slice slice = (_0024_00244218_002415611 = new Slice(LexicalInfo.Empty));
						Slice slice2 = _0024_00244218_002415611;
						ReferenceExpression referenceExpression5 = (_0024_00244217_002415610 = new ReferenceExpression(LexicalInfo.Empty));
						string text24 = (_0024_00244217_002415610.Name = "i");
						Expression expression22 = (slice2.Begin = _0024_00244217_002415610);
						array7[0] = _0024_00244218_002415611;
						SliceCollection sliceCollection2 = (slicingExpression2.Indices = SliceCollection.FromArray(array7));
						Expression expression24 = (binaryExpression3.Right = _0024_00244219_002415612);
						Expression expression26 = (statementModifier6.Condition = _0024_00244220_002415613);
						StatementModifier statementModifier8 = (returnStatement5.Modifier = _0024_00244221_002415614);
						ReturnStatement returnStatement6 = _0024_00244224_002415617;
						CastExpression castExpression = (_0024_00244223_002415616 = new CastExpression(LexicalInfo.Empty));
						CastExpression castExpression2 = _0024_00244223_002415616;
						ReferenceExpression referenceExpression6 = (_0024_00244222_002415615 = new ReferenceExpression(LexicalInfo.Empty));
						string text26 = (_0024_00244222_002415615.Name = "i");
						Expression expression28 = (castExpression2.Target = _0024_00244222_002415615);
						TypeReference typeReference6 = (_0024_00244223_002415616.Type = TypeReference.Lift(_0024enumRef_002415519));
						Expression expression30 = (returnStatement6.Expression = _0024_00244223_002415616);
						array6[0] = Statement.Lift(_0024_00244224_002415617);
						StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array6));
						Block block6 = (forStatement4.Block = _0024_00244225_002415618);
						array2[1] = Statement.Lift(_0024_00244226_002415619);
						ReturnStatement returnStatement7 = (_0024_00244228_002415621 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement8 = _0024_00244228_002415621;
						MemberReferenceExpression memberReferenceExpression5 = (_0024_00244227_002415620 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text28 = (_0024_00244227_002415620.Name = "__NONE__");
						Expression expression32 = (_0024_00244227_002415620.Target = Expression.Lift(_0024enumRef_002415519));
						Expression expression34 = (returnStatement8.Expression = _0024_00244227_002415620);
						array2[2] = Statement.Lift(_0024_00244228_002415621);
						StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array2));
						Block block8 = (method3.Body = _0024_00244229_002415622);
						string text30 = (_0024_00244230_002415623.Name = CodeSerializer.LiftName(_0024toEnumMethod_002415523));
						result = (Yield(7, _0024_00244230_002415623) ? 1 : 0);
						break;
					}
					case 7:
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

		internal string _0024enumName_002415629;

		internal string[] _0024paths_002415630;

		public _0024GenEnumTableCode_002415512(string enumName, string[] paths)
		{
			_0024enumName_002415629 = enumName;
			_0024paths_002415630 = paths;
		}

		public override IEnumerator<TypeMember> GetEnumerator()
		{
			return new _0024(_0024enumName_002415629, _0024paths_002415630);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002415489(mc);
	}

	private static IEnumerable<EnumDefinition> GenEnum(string enumName, string[] paths)
	{
		return new _0024GenEnum_002415498(enumName, paths);
	}

	private static IEnumerable<TypeMember> GenEnumTableCode(string enumName, string[] paths)
	{
		return new _0024GenEnumTableCode_002415512(enumName, paths);
	}
}
