using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public abstract class HudMacroBase : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024yieldAltNamedMethod_002423961 : GenericGenerator<Method>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Method>, IEnumerator
		{
			internal ReferenceExpression _0024_00246217_002423962;

			internal Method _0024_00246218_002423963;

			internal Method _0024m_002423964;

			internal string _0024altName_002423965;

			public _0024(Method m, string altName)
			{
				_0024m_002423964 = m;
				_0024altName_002423965 = altName;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024m_002423964 != null)
					{
						_0024m_002423964.Name = _0024altName_002423965;
						goto case 2;
					}
					Method method = (_0024_00246218_002423963 = new Method(LexicalInfo.Empty));
					string text2 = (_0024_00246218_002423963.Name = "$");
					Block block2 = (_0024_00246218_002423963.Body = new Block(LexicalInfo.Empty));
					Method method2 = _0024_00246218_002423963;
					ReferenceExpression referenceExpression = (_0024_00246217_002423962 = new ReferenceExpression());
					string text4 = (_0024_00246217_002423962.Name = _0024altName_002423965);
					string text6 = (method2.Name = CodeSerializer.LiftName(_0024_00246217_002423962));
					result = (Yield(2, _0024_00246218_002423963) ? 1 : 0);
					break;
				}
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Method _0024m_002423966;

		internal string _0024altName_002423967;

		public _0024yieldAltNamedMethod_002423961(Method m, string altName)
		{
			_0024m_002423966 = m;
			_0024altName_002423967 = altName;
		}

		public override IEnumerator<Method> GetEnumerator()
		{
			return new _0024(_0024m_002423966, _0024altName_002423967);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InstanceManagingCode_002423968 : GenericGenerator<TypeMember>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<TypeMember>, IEnumerator
		{
			internal ClassDefinition _0024cdef_002423969;

			internal string _0024orgOnEnableName_002423970;

			internal string _0024orgOnDisableName_002423971;

			internal Method _0024onEnableMethod_002423972;

			internal Method _0024___item_002423973;

			internal Method _0024onDisableMethod_002423974;

			internal Method _0024___item_002423975;

			internal ReferenceExpression _0024cref_002423976;

			internal ReferenceExpression _0024_00246219_002423977;

			internal ReferenceExpression _0024_00246220_002423978;

			internal MemberReferenceExpression _0024_00246221_002423979;

			internal BinaryExpression _0024_00246222_002423980;

			internal ReferenceExpression _0024_00246223_002423981;

			internal IntegerLiteralExpression _0024_00246224_002423982;

			internal BinaryExpression _0024_00246225_002423983;

			internal StringLiteralExpression _0024_00246226_002423984;

			internal BinaryExpression _0024_00246227_002423985;

			internal StringLiteralExpression _0024_00246228_002423986;

			internal BinaryExpression _0024_00246229_002423987;

			internal ReferenceExpression _0024_00246230_002423988;

			internal BinaryExpression _0024_00246231_002423989;

			internal StringLiteralExpression _0024_00246232_002423990;

			internal BinaryExpression _0024_00246233_002423991;

			internal MacroStatement _0024_00246234_002423992;

			internal Block _0024_00246235_002423993;

			internal IfStatement _0024_00246236_002423994;

			internal ReferenceExpression _0024_00246237_002423995;

			internal IntegerLiteralExpression _0024_00246238_002423996;

			internal Slice _0024_00246239_002423997;

			internal SlicingExpression _0024_00246240_002423998;

			internal ReturnStatement _0024_00246241_002423999;

			internal Block _0024_00246242_002424000;

			internal Method _0024_00246243_002424001;

			internal Property _0024_00246244_002424002;

			internal ReferenceExpression _0024_00246245_002424003;

			internal MemberReferenceExpression _0024_00246246_002424004;

			internal ReturnStatement _0024_00246247_002424005;

			internal Block _0024_00246248_002424006;

			internal Method _0024_00246249_002424007;

			internal SimpleTypeReference _0024_00246250_002424008;

			internal Property _0024_00246251_002424009;

			internal ReferenceExpression _0024_00246252_002424010;

			internal MemberReferenceExpression _0024_00246253_002424011;

			internal IntegerLiteralExpression _0024_00246254_002424012;

			internal BinaryExpression _0024_00246255_002424013;

			internal ReturnStatement _0024_00246256_002424014;

			internal Block _0024_00246257_002424015;

			internal Method _0024_00246258_002424016;

			internal SimpleTypeReference _0024_00246259_002424017;

			internal Property _0024_00246260_002424018;

			internal ReferenceExpression _0024_00246261_002424019;

			internal MemberReferenceExpression _0024_00246262_002424020;

			internal IntegerLiteralExpression _0024_00246263_002424021;

			internal BinaryExpression _0024_00246264_002424022;

			internal ReturnStatement _0024_00246265_002424023;

			internal Block _0024_00246266_002424024;

			internal Method _0024_00246267_002424025;

			internal SimpleTypeReference _0024_00246268_002424026;

			internal Property _0024_00246269_002424027;

			internal ReferenceExpression _0024_00246270_002424028;

			internal GenericReferenceExpression _0024_00246271_002424029;

			internal MethodInvocationExpression _0024_00246272_002424030;

			internal Field _0024_00246273_002424031;

			internal ReferenceExpression _0024_00246274_002424032;

			internal MemberReferenceExpression _0024_00246275_002424033;

			internal IntegerLiteralExpression _0024_00246276_002424034;

			internal BinaryExpression _0024_00246277_002424035;

			internal StringLiteralExpression _0024_00246278_002424036;

			internal BinaryExpression _0024_00246279_002424037;

			internal StringLiteralExpression _0024_00246280_002424038;

			internal BinaryExpression _0024_00246281_002424039;

			internal MacroStatement _0024_00246282_002424040;

			internal Block _0024_00246283_002424041;

			internal IfStatement _0024_00246284_002424042;

			internal ReferenceExpression _0024_00246285_002424043;

			internal MemberReferenceExpression _0024_00246286_002424044;

			internal MethodInvocationExpression _0024_00246287_002424045;

			internal ReferenceExpression _0024_00246288_002424046;

			internal MethodInvocationExpression _0024_00246289_002424047;

			internal Block _0024_00246290_002424048;

			internal Method _0024_00246291_002424049;

			internal ReferenceExpression _0024_00246292_002424050;

			internal MethodInvocationExpression _0024_00246293_002424051;

			internal ReferenceExpression _0024_00246294_002424052;

			internal MemberReferenceExpression _0024_00246295_002424053;

			internal MethodInvocationExpression _0024_00246296_002424054;

			internal Block _0024_00246297_002424055;

			internal Method _0024_00246298_002424056;

			internal Module _0024_00246299_002424057;

			internal Module _0024module_002424058;

			internal TypeMember _0024___item_002424059;

			internal TypeMember _0024m_002424060;

			internal Property _0024prop_002424061;

			internal string _0024ipname_002424062;

			internal ReferenceExpression _0024ipref_002424063;

			internal string _0024spname_002424064;

			internal Property _0024sprop_002424065;

			internal ReferenceExpression _0024_00246300_002424066;

			internal ReferenceExpression _0024_00246301_002424067;

			internal MemberReferenceExpression _0024_00246302_002424068;

			internal BinaryExpression _0024_00246303_002424069;

			internal ReferenceExpression _0024_00246304_002424070;

			internal IntegerLiteralExpression _0024_00246305_002424071;

			internal BinaryExpression _0024_00246306_002424072;

			internal StringLiteralExpression _0024_00246307_002424073;

			internal BinaryExpression _0024_00246308_002424074;

			internal StringLiteralExpression _0024_00246309_002424075;

			internal BinaryExpression _0024_00246310_002424076;

			internal ReferenceExpression _0024_00246311_002424077;

			internal BinaryExpression _0024_00246312_002424078;

			internal StringLiteralExpression _0024_00246313_002424079;

			internal BinaryExpression _0024_00246314_002424080;

			internal BinaryExpression _0024_00246315_002424081;

			internal StringLiteralExpression _0024_00246316_002424082;

			internal BinaryExpression _0024_00246317_002424083;

			internal MacroStatement _0024_00246318_002424084;

			internal Block _0024_00246319_002424085;

			internal IfStatement _0024_00246320_002424086;

			internal ReferenceExpression _0024_00246321_002424087;

			internal IntegerLiteralExpression _0024_00246322_002424088;

			internal Slice _0024_00246323_002424089;

			internal SlicingExpression _0024_00246324_002424090;

			internal ReturnStatement _0024_00246325_002424091;

			internal Block _0024_00246326_002424092;

			internal Declaration _0024_00246327_002424093;

			internal ReferenceExpression _0024_00246328_002424094;

			internal ReferenceExpression _0024_00246329_002424095;

			internal ReferenceExpression _0024_00246330_002424096;

			internal BinaryExpression _0024_00246331_002424097;

			internal Block _0024_00246332_002424098;

			internal ForStatement _0024_00246333_002424099;

			internal IEnumerator<Method> _0024_0024iterator_002414229_002424100;

			internal IEnumerator<Method> _0024_0024iterator_002414230_002424101;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414231_002424102;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414232_002424103;

			internal Boo.Lang.Compiler.Ast.Node _0024mdef_002424104;

			internal HudMacroBase _0024self__002424105;

			public _0024(Boo.Lang.Compiler.Ast.Node mdef, HudMacroBase self_)
			{
				_0024mdef_002424104 = mdef;
				_0024self__002424105 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024cdef_002423969 = _0024mdef_002424104.GetAncestor<ClassDefinition>();
						if (_0024cdef_002423969 == null)
						{
							throw new AssertionFailedException("hud_method must be placed in a class definition");
						}
						_0024self__002424105.parentClass = _0024cdef_002423969;
						if (!RuntimeServices.ToBool(_0024cdef_002423969["hud_class_mark"]))
						{
							_0024orgOnEnableName_002423970 = "$hud$OnEnable";
							_0024orgOnDisableName_002423971 = "$hud$OnDisable";
							_0024onEnableMethod_002423972 = FindMethodNode(_0024cdef_002423969, "OnEnable");
							_0024_0024iterator_002414229_002424100 = _0024self__002424105.yieldAltNamedMethod(_0024onEnableMethod_002423972, _0024orgOnEnableName_002423970).GetEnumerator();
							_state = 2;
							goto case 3;
						}
						goto end_IL_0000;
					case 3:
						if (_0024_0024iterator_002414229_002424100.MoveNext())
						{
							_0024___item_002423973 = _0024_0024iterator_002414229_002424100.Current;
							flag = Yield(3, _0024___item_002423973);
							goto IL_2352;
						}
						_state = 1;
						_0024ensure2();
						_0024onDisableMethod_002423974 = FindMethodNode(_0024cdef_002423969, "OnDisable");
						_0024_0024iterator_002414230_002424101 = _0024self__002424105.yieldAltNamedMethod(_0024onDisableMethod_002423974, _0024orgOnDisableName_002423971).GetEnumerator();
						_state = 4;
						goto case 5;
					case 5:
					{
						if (_0024_0024iterator_002414230_002424101.MoveNext())
						{
							_0024___item_002423975 = _0024_0024iterator_002414230_002424101.Current;
							flag = Yield(5, _0024___item_002423975);
							goto IL_2352;
						}
						_state = 1;
						_0024ensure4();
						_0024cdef_002423969["hud_class_mark"] = true;
						_0024cref_002423976 = new ReferenceExpression(_0024cdef_002423969.Name);
						Module module = (_0024_00246299_002424057 = new Module(LexicalInfo.Empty));
						string text2 = (_0024_00246299_002424057.Name = "hudmacros$50");
						Module module2 = _0024_00246299_002424057;
						TypeMember[] array = new TypeMember[7];
						Property property = (_0024_00246244_002424002 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00246244_002424002.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
						string text4 = (_0024_00246244_002424002.Name = "Instance");
						Property property2 = _0024_00246244_002424002;
						Method method = (_0024_00246243_002424001 = new Method(LexicalInfo.Empty));
						string text6 = (_0024_00246243_002424001.Name = "get");
						Method method2 = _0024_00246243_002424001;
						Block block = (_0024_00246242_002424000 = new Block(LexicalInfo.Empty));
						Block block2 = _0024_00246242_002424000;
						Statement[] array2 = new Statement[3];
						BinaryExpression binaryExpression = (_0024_00246222_002423980 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00246222_002423980.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression2 = _0024_00246222_002423980;
						ReferenceExpression referenceExpression = (_0024_00246219_002423977 = new ReferenceExpression(LexicalInfo.Empty));
						string text8 = (_0024_00246219_002423977.Name = "n");
						Expression expression2 = (binaryExpression2.Left = _0024_00246219_002423977);
						BinaryExpression binaryExpression3 = _0024_00246222_002423980;
						MemberReferenceExpression memberReferenceExpression = (_0024_00246221_002423979 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text10 = (_0024_00246221_002423979.Name = "Count");
						MemberReferenceExpression memberReferenceExpression2 = _0024_00246221_002423979;
						ReferenceExpression referenceExpression2 = (_0024_00246220_002423978 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00246220_002423978.Name = "_InstanceList");
						Expression expression4 = (memberReferenceExpression2.Target = _0024_00246220_002423978);
						Expression expression6 = (binaryExpression3.Right = _0024_00246221_002423979);
						array2[0] = Statement.Lift(_0024_00246222_002423980);
						IfStatement ifStatement = (_0024_00246236_002423994 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement2 = _0024_00246236_002423994;
						BinaryExpression binaryExpression4 = (_0024_00246225_002423983 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00246225_002423983.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression5 = _0024_00246225_002423983;
						ReferenceExpression referenceExpression3 = (_0024_00246223_002423981 = new ReferenceExpression(LexicalInfo.Empty));
						string text14 = (_0024_00246223_002423981.Name = "n");
						Expression expression8 = (binaryExpression5.Left = _0024_00246223_002423981);
						BinaryExpression binaryExpression6 = _0024_00246225_002423983;
						IntegerLiteralExpression integerLiteralExpression = (_0024_00246224_002423982 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num2 = (_0024_00246224_002423982.Value = 1L);
						bool flag3 = (_0024_00246224_002423982.IsLong = false);
						Expression expression10 = (binaryExpression6.Right = _0024_00246224_002423982);
						Expression expression12 = (ifStatement2.Condition = _0024_00246225_002423983);
						IfStatement ifStatement3 = _0024_00246236_002423994;
						Block block3 = (_0024_00246235_002423993 = new Block(LexicalInfo.Empty));
						Block block4 = _0024_00246235_002423993;
						Statement[] array3 = new Statement[1];
						MacroStatement macroStatement = (_0024_00246234_002423992 = new MacroStatement(LexicalInfo.Empty));
						string text16 = (_0024_00246234_002423992.Name = "logerr");
						MacroStatement macroStatement2 = _0024_00246234_002423992;
						Expression[] array4 = new Expression[1];
						BinaryExpression binaryExpression7 = (_0024_00246233_002423991 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType6 = (_0024_00246233_002423991.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression8 = _0024_00246233_002423991;
						BinaryExpression binaryExpression9 = (_0024_00246231_002423989 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType8 = (_0024_00246231_002423989.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression10 = _0024_00246231_002423989;
						BinaryExpression binaryExpression11 = (_0024_00246229_002423987 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType10 = (_0024_00246229_002423987.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression12 = _0024_00246229_002423987;
						BinaryExpression binaryExpression13 = (_0024_00246227_002423985 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType12 = (_0024_00246227_002423985.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression14 = _0024_00246227_002423985;
						StringLiteralExpression stringLiteralExpression = (_0024_00246226_002423984 = new StringLiteralExpression(LexicalInfo.Empty));
						string text18 = (_0024_00246226_002423984.Value = "HUDM0:");
						Expression expression14 = (binaryExpression14.Left = _0024_00246226_002423984);
						Expression expression16 = (_0024_00246227_002423985.Right = Expression.Lift(_0024cref_002423976.Name));
						Expression expression18 = (binaryExpression12.Left = _0024_00246227_002423985);
						BinaryExpression binaryExpression15 = _0024_00246229_002423987;
						StringLiteralExpression stringLiteralExpression2 = (_0024_00246228_002423986 = new StringLiteralExpression(LexicalInfo.Empty));
						string text20 = (_0024_00246228_002423986.Value = "が");
						Expression expression20 = (binaryExpression15.Right = _0024_00246228_002423986);
						Expression expression22 = (binaryExpression10.Left = _0024_00246229_002423987);
						BinaryExpression binaryExpression16 = _0024_00246231_002423989;
						ReferenceExpression referenceExpression4 = (_0024_00246230_002423988 = new ReferenceExpression(LexicalInfo.Empty));
						string text22 = (_0024_00246230_002423988.Name = "n");
						Expression expression24 = (binaryExpression16.Right = _0024_00246230_002423988);
						Expression expression26 = (binaryExpression8.Left = _0024_00246231_002423989);
						BinaryExpression binaryExpression17 = _0024_00246233_002423991;
						StringLiteralExpression stringLiteralExpression3 = (_0024_00246232_002423990 = new StringLiteralExpression(LexicalInfo.Empty));
						string text24 = (_0024_00246232_002423990.Value = "個存在する(1個でない)！");
						Expression expression28 = (binaryExpression17.Right = _0024_00246232_002423990);
						array4[0] = _0024_00246233_002423991;
						ExpressionCollection expressionCollection2 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array4));
						Block block6 = (_0024_00246234_002423992.Body = new Block(LexicalInfo.Empty));
						array3[0] = Statement.Lift(_0024_00246234_002423992);
						StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array3));
						Block block8 = (ifStatement3.TrueBlock = _0024_00246235_002423993);
						array2[1] = Statement.Lift(_0024_00246236_002423994);
						ReturnStatement returnStatement = (_0024_00246241_002423999 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00246241_002423999;
						SlicingExpression slicingExpression = (_0024_00246240_002423998 = new SlicingExpression(LexicalInfo.Empty));
						SlicingExpression slicingExpression2 = _0024_00246240_002423998;
						ReferenceExpression referenceExpression5 = (_0024_00246237_002423995 = new ReferenceExpression(LexicalInfo.Empty));
						string text26 = (_0024_00246237_002423995.Name = "_InstanceList");
						Expression expression30 = (slicingExpression2.Target = _0024_00246237_002423995);
						SlicingExpression slicingExpression3 = _0024_00246240_002423998;
						Slice[] array5 = new Slice[1];
						Slice slice = (_0024_00246239_002423997 = new Slice(LexicalInfo.Empty));
						Slice slice2 = _0024_00246239_002423997;
						IntegerLiteralExpression integerLiteralExpression2 = (_0024_00246238_002423996 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num4 = (_0024_00246238_002423996.Value = 0L);
						bool flag5 = (_0024_00246238_002423996.IsLong = false);
						Expression expression32 = (slice2.Begin = _0024_00246238_002423996);
						array5[0] = _0024_00246239_002423997;
						SliceCollection sliceCollection2 = (slicingExpression3.Indices = SliceCollection.FromArray(array5));
						Expression expression34 = (returnStatement2.Expression = _0024_00246240_002423998);
						array2[2] = Statement.Lift(_0024_00246241_002423999);
						StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array2));
						Block block10 = (method2.Body = _0024_00246242_002424000);
						Method method4 = (property2.Getter = _0024_00246243_002424001);
						TypeReference typeReference2 = (_0024_00246244_002424002.Type = TypeReference.Lift(_0024cref_002423976));
						array[0] = _0024_00246244_002424002;
						Property property3 = (_0024_00246251_002424009 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers4 = (_0024_00246251_002424009.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
						string text28 = (_0024_00246251_002424009.Name = "EnabledInstanceNum");
						Property property4 = _0024_00246251_002424009;
						Method method5 = (_0024_00246249_002424007 = new Method(LexicalInfo.Empty));
						string text30 = (_0024_00246249_002424007.Name = "get");
						Method method6 = _0024_00246249_002424007;
						Block block11 = (_0024_00246248_002424006 = new Block(LexicalInfo.Empty));
						Block block12 = _0024_00246248_002424006;
						Statement[] array6 = new Statement[1];
						ReturnStatement returnStatement3 = (_0024_00246247_002424005 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement4 = _0024_00246247_002424005;
						MemberReferenceExpression memberReferenceExpression3 = (_0024_00246246_002424004 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text32 = (_0024_00246246_002424004.Name = "Count");
						MemberReferenceExpression memberReferenceExpression4 = _0024_00246246_002424004;
						ReferenceExpression referenceExpression6 = (_0024_00246245_002424003 = new ReferenceExpression(LexicalInfo.Empty));
						string text34 = (_0024_00246245_002424003.Name = "_InstanceList");
						Expression expression36 = (memberReferenceExpression4.Target = _0024_00246245_002424003);
						Expression expression38 = (returnStatement4.Expression = _0024_00246246_002424004);
						array6[0] = Statement.Lift(_0024_00246247_002424005);
						StatementCollection statementCollection6 = (block12.Statements = StatementCollection.FromArray(array6));
						Block block14 = (method6.Body = _0024_00246248_002424006);
						Method method8 = (property4.Getter = _0024_00246249_002424007);
						Property property5 = _0024_00246251_002424009;
						SimpleTypeReference simpleTypeReference = (_0024_00246250_002424008 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag7 = (_0024_00246250_002424008.IsPointer = false);
						string text36 = (_0024_00246250_002424008.Name = "int");
						TypeReference typeReference4 = (property5.Type = _0024_00246250_002424008);
						array[1] = _0024_00246251_002424009;
						Property property6 = (_0024_00246260_002424018 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers6 = (_0024_00246260_002424018.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
						string text38 = (_0024_00246260_002424018.Name = "Exists");
						Property property7 = _0024_00246260_002424018;
						Method method9 = (_0024_00246258_002424016 = new Method(LexicalInfo.Empty));
						string text40 = (_0024_00246258_002424016.Name = "get");
						Method method10 = _0024_00246258_002424016;
						Block block15 = (_0024_00246257_002424015 = new Block(LexicalInfo.Empty));
						Block block16 = _0024_00246257_002424015;
						Statement[] array7 = new Statement[1];
						ReturnStatement returnStatement5 = (_0024_00246256_002424014 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement6 = _0024_00246256_002424014;
						BinaryExpression binaryExpression18 = (_0024_00246255_002424013 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType14 = (_0024_00246255_002424013.Operator = BinaryOperatorType.GreaterThan);
						BinaryExpression binaryExpression19 = _0024_00246255_002424013;
						MemberReferenceExpression memberReferenceExpression5 = (_0024_00246253_002424011 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text42 = (_0024_00246253_002424011.Name = "Count");
						MemberReferenceExpression memberReferenceExpression6 = _0024_00246253_002424011;
						ReferenceExpression referenceExpression7 = (_0024_00246252_002424010 = new ReferenceExpression(LexicalInfo.Empty));
						string text44 = (_0024_00246252_002424010.Name = "_InstanceList");
						Expression expression40 = (memberReferenceExpression6.Target = _0024_00246252_002424010);
						Expression expression42 = (binaryExpression19.Left = _0024_00246253_002424011);
						BinaryExpression binaryExpression20 = _0024_00246255_002424013;
						IntegerLiteralExpression integerLiteralExpression3 = (_0024_00246254_002424012 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num6 = (_0024_00246254_002424012.Value = 0L);
						bool flag9 = (_0024_00246254_002424012.IsLong = false);
						Expression expression44 = (binaryExpression20.Right = _0024_00246254_002424012);
						Expression expression46 = (returnStatement6.Expression = _0024_00246255_002424013);
						array7[0] = Statement.Lift(_0024_00246256_002424014);
						StatementCollection statementCollection8 = (block16.Statements = StatementCollection.FromArray(array7));
						Block block18 = (method10.Body = _0024_00246257_002424015);
						Method method12 = (property7.Getter = _0024_00246258_002424016);
						Property property8 = _0024_00246260_002424018;
						SimpleTypeReference simpleTypeReference2 = (_0024_00246259_002424017 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag11 = (_0024_00246259_002424017.IsPointer = false);
						string text46 = (_0024_00246259_002424017.Name = "bool");
						TypeReference typeReference6 = (property8.Type = _0024_00246259_002424017);
						array[2] = _0024_00246260_002424018;
						Property property9 = (_0024_00246269_002424027 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers8 = (_0024_00246269_002424027.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
						string text48 = (_0024_00246269_002424027.Name = "ExistsOne");
						Property property10 = _0024_00246269_002424027;
						Method method13 = (_0024_00246267_002424025 = new Method(LexicalInfo.Empty));
						string text50 = (_0024_00246267_002424025.Name = "get");
						Method method14 = _0024_00246267_002424025;
						Block block19 = (_0024_00246266_002424024 = new Block(LexicalInfo.Empty));
						Block block20 = _0024_00246266_002424024;
						Statement[] array8 = new Statement[1];
						ReturnStatement returnStatement7 = (_0024_00246265_002424023 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement8 = _0024_00246265_002424023;
						BinaryExpression binaryExpression21 = (_0024_00246264_002424022 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType16 = (_0024_00246264_002424022.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression22 = _0024_00246264_002424022;
						MemberReferenceExpression memberReferenceExpression7 = (_0024_00246262_002424020 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text52 = (_0024_00246262_002424020.Name = "Count");
						MemberReferenceExpression memberReferenceExpression8 = _0024_00246262_002424020;
						ReferenceExpression referenceExpression8 = (_0024_00246261_002424019 = new ReferenceExpression(LexicalInfo.Empty));
						string text54 = (_0024_00246261_002424019.Name = "_InstanceList");
						Expression expression48 = (memberReferenceExpression8.Target = _0024_00246261_002424019);
						Expression expression50 = (binaryExpression22.Left = _0024_00246262_002424020);
						BinaryExpression binaryExpression23 = _0024_00246264_002424022;
						IntegerLiteralExpression integerLiteralExpression4 = (_0024_00246263_002424021 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num8 = (_0024_00246263_002424021.Value = 1L);
						bool flag13 = (_0024_00246263_002424021.IsLong = false);
						Expression expression52 = (binaryExpression23.Right = _0024_00246263_002424021);
						Expression expression54 = (returnStatement8.Expression = _0024_00246264_002424022);
						array8[0] = Statement.Lift(_0024_00246265_002424023);
						StatementCollection statementCollection10 = (block20.Statements = StatementCollection.FromArray(array8));
						Block block22 = (method14.Body = _0024_00246266_002424024);
						Method method16 = (property10.Getter = _0024_00246267_002424025);
						Property property11 = _0024_00246269_002424027;
						SimpleTypeReference simpleTypeReference3 = (_0024_00246268_002424026 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag15 = (_0024_00246268_002424026.IsPointer = false);
						string text56 = (_0024_00246268_002424026.Name = "bool");
						TypeReference typeReference8 = (property11.Type = _0024_00246268_002424026);
						array[3] = _0024_00246269_002424027;
						Field field = (_0024_00246273_002424031 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers10 = (_0024_00246273_002424031.Modifiers = TypeMemberModifiers.Private | TypeMemberModifiers.Static);
						string text58 = (_0024_00246273_002424031.Name = "_InstanceList");
						Field field2 = _0024_00246273_002424031;
						MethodInvocationExpression methodInvocationExpression = (_0024_00246272_002424030 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00246272_002424030;
						GenericReferenceExpression genericReferenceExpression = (_0024_00246271_002424029 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression2 = _0024_00246271_002424029;
						ReferenceExpression referenceExpression9 = (_0024_00246270_002424028 = new ReferenceExpression(LexicalInfo.Empty));
						string text60 = (_0024_00246270_002424028.Name = "List");
						Expression expression56 = (genericReferenceExpression2.Target = _0024_00246270_002424028);
						TypeReferenceCollection typeReferenceCollection2 = (_0024_00246271_002424029.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024cref_002423976)));
						Expression expression58 = (methodInvocationExpression2.Target = _0024_00246271_002424029);
						Expression expression60 = (field2.Initializer = _0024_00246272_002424030);
						bool flag17 = (_0024_00246273_002424031.IsVolatile = false);
						array[4] = _0024_00246273_002424031;
						Method method17 = (_0024_00246291_002424049 = new Method(LexicalInfo.Empty));
						string text62 = (_0024_00246291_002424049.Name = "OnEnable");
						Method method18 = _0024_00246291_002424049;
						Block block23 = (_0024_00246290_002424048 = new Block(LexicalInfo.Empty));
						Block block24 = _0024_00246290_002424048;
						Statement[] array9 = new Statement[3];
						IfStatement ifStatement4 = (_0024_00246284_002424042 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement5 = _0024_00246284_002424042;
						BinaryExpression binaryExpression24 = (_0024_00246277_002424035 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType18 = (_0024_00246277_002424035.Operator = BinaryOperatorType.GreaterThan);
						BinaryExpression binaryExpression25 = _0024_00246277_002424035;
						MemberReferenceExpression memberReferenceExpression9 = (_0024_00246275_002424033 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text64 = (_0024_00246275_002424033.Name = "Count");
						MemberReferenceExpression memberReferenceExpression10 = _0024_00246275_002424033;
						ReferenceExpression referenceExpression10 = (_0024_00246274_002424032 = new ReferenceExpression(LexicalInfo.Empty));
						string text66 = (_0024_00246274_002424032.Name = "_InstanceList");
						Expression expression62 = (memberReferenceExpression10.Target = _0024_00246274_002424032);
						Expression expression64 = (binaryExpression25.Left = _0024_00246275_002424033);
						BinaryExpression binaryExpression26 = _0024_00246277_002424035;
						IntegerLiteralExpression integerLiteralExpression5 = (_0024_00246276_002424034 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num10 = (_0024_00246276_002424034.Value = 2L);
						bool flag19 = (_0024_00246276_002424034.IsLong = false);
						Expression expression66 = (binaryExpression26.Right = _0024_00246276_002424034);
						Expression expression68 = (ifStatement5.Condition = _0024_00246277_002424035);
						IfStatement ifStatement6 = _0024_00246284_002424042;
						Block block25 = (_0024_00246283_002424041 = new Block(LexicalInfo.Empty));
						Block block26 = _0024_00246283_002424041;
						Statement[] array10 = new Statement[1];
						MacroStatement macroStatement3 = (_0024_00246282_002424040 = new MacroStatement(LexicalInfo.Empty));
						string text68 = (_0024_00246282_002424040.Name = "logerr");
						MacroStatement macroStatement4 = _0024_00246282_002424040;
						Expression[] array11 = new Expression[1];
						BinaryExpression binaryExpression27 = (_0024_00246281_002424039 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType20 = (_0024_00246281_002424039.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression28 = _0024_00246281_002424039;
						BinaryExpression binaryExpression29 = (_0024_00246279_002424037 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType22 = (_0024_00246279_002424037.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression30 = _0024_00246279_002424037;
						StringLiteralExpression stringLiteralExpression4 = (_0024_00246278_002424036 = new StringLiteralExpression(LexicalInfo.Empty));
						string text70 = (_0024_00246278_002424036.Value = "HUDM1:");
						Expression expression70 = (binaryExpression30.Left = _0024_00246278_002424036);
						Expression expression72 = (_0024_00246279_002424037.Right = Expression.Lift(_0024cref_002423976.Name));
						Expression expression74 = (binaryExpression28.Left = _0024_00246279_002424037);
						BinaryExpression binaryExpression31 = _0024_00246281_002424039;
						StringLiteralExpression stringLiteralExpression5 = (_0024_00246280_002424038 = new StringLiteralExpression(LexicalInfo.Empty));
						string text72 = (_0024_00246280_002424038.Value = "が二つ以上現れた！！！");
						Expression expression76 = (binaryExpression31.Right = _0024_00246280_002424038);
						array11[0] = _0024_00246281_002424039;
						ExpressionCollection expressionCollection4 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array11));
						Block block28 = (_0024_00246282_002424040.Body = new Block(LexicalInfo.Empty));
						array10[0] = Statement.Lift(_0024_00246282_002424040);
						StatementCollection statementCollection12 = (block26.Statements = StatementCollection.FromArray(array10));
						Block block30 = (ifStatement6.TrueBlock = _0024_00246283_002424041);
						array9[0] = Statement.Lift(_0024_00246284_002424042);
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00246287_002424045 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00246287_002424045;
						MemberReferenceExpression memberReferenceExpression11 = (_0024_00246286_002424044 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text74 = (_0024_00246286_002424044.Name = "Add");
						MemberReferenceExpression memberReferenceExpression12 = _0024_00246286_002424044;
						ReferenceExpression referenceExpression11 = (_0024_00246285_002424043 = new ReferenceExpression(LexicalInfo.Empty));
						string text76 = (_0024_00246285_002424043.Name = "_InstanceList");
						Expression expression78 = (memberReferenceExpression12.Target = _0024_00246285_002424043);
						Expression expression80 = (methodInvocationExpression4.Target = _0024_00246286_002424044);
						ExpressionCollection expressionCollection6 = (_0024_00246287_002424045.Arguments = ExpressionCollection.FromArray(new SelfLiteralExpression(LexicalInfo.Empty)));
						array9[1] = Statement.Lift(_0024_00246287_002424045);
						MethodInvocationExpression methodInvocationExpression5 = (_0024_00246289_002424047 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression6 = _0024_00246289_002424047;
						ReferenceExpression referenceExpression12 = (_0024_00246288_002424046 = new ReferenceExpression());
						string text78 = (_0024_00246288_002424046.Name = _0024orgOnEnableName_002423970);
						Expression expression82 = (methodInvocationExpression6.Target = Expression.Lift(_0024_00246288_002424046));
						array9[2] = Statement.Lift(_0024_00246289_002424047);
						StatementCollection statementCollection14 = (block24.Statements = StatementCollection.FromArray(array9));
						Block block32 = (method18.Body = _0024_00246290_002424048);
						array[5] = _0024_00246291_002424049;
						Method method19 = (_0024_00246298_002424056 = new Method(LexicalInfo.Empty));
						string text80 = (_0024_00246298_002424056.Name = "OnDisable");
						Method method20 = _0024_00246298_002424056;
						Block block33 = (_0024_00246297_002424055 = new Block(LexicalInfo.Empty));
						Block block34 = _0024_00246297_002424055;
						Statement[] array12 = new Statement[2];
						MethodInvocationExpression methodInvocationExpression7 = (_0024_00246293_002424051 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression8 = _0024_00246293_002424051;
						ReferenceExpression referenceExpression13 = (_0024_00246292_002424050 = new ReferenceExpression());
						string text82 = (_0024_00246292_002424050.Name = _0024orgOnDisableName_002423971);
						Expression expression84 = (methodInvocationExpression8.Target = Expression.Lift(_0024_00246292_002424050));
						array12[0] = Statement.Lift(_0024_00246293_002424051);
						MethodInvocationExpression methodInvocationExpression9 = (_0024_00246296_002424054 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression10 = _0024_00246296_002424054;
						MemberReferenceExpression memberReferenceExpression13 = (_0024_00246295_002424053 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text84 = (_0024_00246295_002424053.Name = "Remove");
						MemberReferenceExpression memberReferenceExpression14 = _0024_00246295_002424053;
						ReferenceExpression referenceExpression14 = (_0024_00246294_002424052 = new ReferenceExpression(LexicalInfo.Empty));
						string text86 = (_0024_00246294_002424052.Name = "_InstanceList");
						Expression expression86 = (memberReferenceExpression14.Target = _0024_00246294_002424052);
						Expression expression88 = (methodInvocationExpression10.Target = _0024_00246295_002424053);
						ExpressionCollection expressionCollection8 = (_0024_00246296_002424054.Arguments = ExpressionCollection.FromArray(new SelfLiteralExpression(LexicalInfo.Empty)));
						array12[1] = Statement.Lift(_0024_00246296_002424054);
						StatementCollection statementCollection16 = (block34.Statements = StatementCollection.FromArray(array12));
						Block block36 = (method20.Body = _0024_00246297_002424055);
						array[6] = _0024_00246298_002424056;
						TypeMemberCollection typeMemberCollection2 = (module2.Members = TypeMemberCollection.FromArray(array));
						Block block38 = (_0024_00246299_002424057.Globals = new Block(LexicalInfo.Empty));
						_0024module_002424058 = _0024_00246299_002424057;
						_0024_0024iterator_002414231_002424102 = _0024module_002424058.Members.GetEnumerator();
						_state = 6;
						goto case 7;
					}
					case 7:
						if (_0024_0024iterator_002414231_002424102.MoveNext())
						{
							_0024___item_002424059 = _0024_0024iterator_002414231_002424102.Current;
							flag = Yield(7, _0024___item_002424059);
							goto IL_2352;
						}
						_state = 1;
						_0024ensure6();
						_0024_0024iterator_002414232_002424103 = _0024cdef_002423969.Members.GetEnumerator();
						_state = 8;
						break;
					case 9:
						break;
					case 1:
					case 2:
					case 4:
					case 6:
					case 8:
						goto end_IL_0000;
					}
					while (true)
					{
						if (_0024_0024iterator_002414232_002424103.MoveNext())
						{
							_0024m_002424060 = _0024_0024iterator_002414232_002424103.Current;
							_0024prop_002424061 = _0024m_002424060 as Property;
							if (_0024prop_002424061 == null || (_0024prop_002424061.Modifiers & TypeMemberModifiers.Static) != 0)
							{
								continue;
							}
							_0024ipname_002424062 = "__" + _0024prop_002424061.Name;
							_0024ipref_002424063 = new ReferenceExpression(_0024ipname_002424062);
							_0024spname_002424064 = _0024prop_002424061.Name;
							_0024prop_002424061.Name = _0024ipname_002424062;
							_0024sprop_002424065 = new Property();
							_0024sprop_002424065.Name = _0024spname_002424064;
							_0024sprop_002424065.Visibility = TypeMemberModifiers.Public | TypeMemberModifiers.Static;
							if (_0024prop_002424061.Getter != null)
							{
								_0024sprop_002424065.Getter = new Method();
								Method getter = _0024sprop_002424065.Getter;
								Block block39 = (_0024_00246326_002424092 = new Block(LexicalInfo.Empty));
								Block block40 = _0024_00246326_002424092;
								Statement[] array13 = new Statement[3];
								BinaryExpression binaryExpression32 = (_0024_00246303_002424069 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType24 = (_0024_00246303_002424069.Operator = BinaryOperatorType.Assign);
								BinaryExpression binaryExpression33 = _0024_00246303_002424069;
								ReferenceExpression referenceExpression15 = (_0024_00246300_002424066 = new ReferenceExpression(LexicalInfo.Empty));
								string text88 = (_0024_00246300_002424066.Name = "n");
								Expression expression90 = (binaryExpression33.Left = _0024_00246300_002424066);
								BinaryExpression binaryExpression34 = _0024_00246303_002424069;
								MemberReferenceExpression memberReferenceExpression15 = (_0024_00246302_002424068 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text90 = (_0024_00246302_002424068.Name = "Count");
								MemberReferenceExpression memberReferenceExpression16 = _0024_00246302_002424068;
								ReferenceExpression referenceExpression16 = (_0024_00246301_002424067 = new ReferenceExpression(LexicalInfo.Empty));
								string text92 = (_0024_00246301_002424067.Name = "_InstanceList");
								Expression expression92 = (memberReferenceExpression16.Target = _0024_00246301_002424067);
								Expression expression94 = (binaryExpression34.Right = _0024_00246302_002424068);
								array13[0] = Statement.Lift(_0024_00246303_002424069);
								IfStatement ifStatement7 = (_0024_00246320_002424086 = new IfStatement(LexicalInfo.Empty));
								IfStatement ifStatement8 = _0024_00246320_002424086;
								BinaryExpression binaryExpression35 = (_0024_00246306_002424072 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType26 = (_0024_00246306_002424072.Operator = BinaryOperatorType.Inequality);
								BinaryExpression binaryExpression36 = _0024_00246306_002424072;
								ReferenceExpression referenceExpression17 = (_0024_00246304_002424070 = new ReferenceExpression(LexicalInfo.Empty));
								string text94 = (_0024_00246304_002424070.Name = "n");
								Expression expression96 = (binaryExpression36.Left = _0024_00246304_002424070);
								BinaryExpression binaryExpression37 = _0024_00246306_002424072;
								IntegerLiteralExpression integerLiteralExpression6 = (_0024_00246305_002424071 = new IntegerLiteralExpression(LexicalInfo.Empty));
								long num12 = (_0024_00246305_002424071.Value = 1L);
								bool flag21 = (_0024_00246305_002424071.IsLong = false);
								Expression expression98 = (binaryExpression37.Right = _0024_00246305_002424071);
								Expression expression100 = (ifStatement8.Condition = _0024_00246306_002424072);
								IfStatement ifStatement9 = _0024_00246320_002424086;
								Block block41 = (_0024_00246319_002424085 = new Block(LexicalInfo.Empty));
								Block block42 = _0024_00246319_002424085;
								Statement[] array14 = new Statement[1];
								MacroStatement macroStatement5 = (_0024_00246318_002424084 = new MacroStatement(LexicalInfo.Empty));
								string text96 = (_0024_00246318_002424084.Name = "logerr");
								MacroStatement macroStatement6 = _0024_00246318_002424084;
								Expression[] array15 = new Expression[1];
								BinaryExpression binaryExpression38 = (_0024_00246317_002424083 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType28 = (_0024_00246317_002424083.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression39 = _0024_00246317_002424083;
								BinaryExpression binaryExpression40 = (_0024_00246315_002424081 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType30 = (_0024_00246315_002424081.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression41 = _0024_00246315_002424081;
								BinaryExpression binaryExpression42 = (_0024_00246314_002424080 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType32 = (_0024_00246314_002424080.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression43 = _0024_00246314_002424080;
								BinaryExpression binaryExpression44 = (_0024_00246312_002424078 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType34 = (_0024_00246312_002424078.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression45 = _0024_00246312_002424078;
								BinaryExpression binaryExpression46 = (_0024_00246310_002424076 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType36 = (_0024_00246310_002424076.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression47 = _0024_00246310_002424076;
								BinaryExpression binaryExpression48 = (_0024_00246308_002424074 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType38 = (_0024_00246308_002424074.Operator = BinaryOperatorType.Addition);
								BinaryExpression binaryExpression49 = _0024_00246308_002424074;
								StringLiteralExpression stringLiteralExpression6 = (_0024_00246307_002424073 = new StringLiteralExpression(LexicalInfo.Empty));
								string text98 = (_0024_00246307_002424073.Value = "HUDM2:");
								Expression expression102 = (binaryExpression49.Left = _0024_00246307_002424073);
								Expression expression104 = (_0024_00246308_002424074.Right = Expression.Lift(_0024cref_002423976.Name));
								Expression expression106 = (binaryExpression47.Left = _0024_00246308_002424074);
								BinaryExpression binaryExpression50 = _0024_00246310_002424076;
								StringLiteralExpression stringLiteralExpression7 = (_0024_00246309_002424075 = new StringLiteralExpression(LexicalInfo.Empty));
								string text100 = (_0024_00246309_002424075.Value = "が");
								Expression expression108 = (binaryExpression50.Right = _0024_00246309_002424075);
								Expression expression110 = (binaryExpression45.Left = _0024_00246310_002424076);
								BinaryExpression binaryExpression51 = _0024_00246312_002424078;
								ReferenceExpression referenceExpression18 = (_0024_00246311_002424077 = new ReferenceExpression(LexicalInfo.Empty));
								string text102 = (_0024_00246311_002424077.Name = "n");
								Expression expression112 = (binaryExpression51.Right = _0024_00246311_002424077);
								Expression expression114 = (binaryExpression43.Left = _0024_00246312_002424078);
								BinaryExpression binaryExpression52 = _0024_00246314_002424080;
								StringLiteralExpression stringLiteralExpression8 = (_0024_00246313_002424079 = new StringLiteralExpression(LexicalInfo.Empty));
								string text104 = (_0024_00246313_002424079.Value = "個存在する(1個でない)！ -- ");
								Expression expression116 = (binaryExpression52.Right = _0024_00246313_002424079);
								Expression expression118 = (binaryExpression41.Left = _0024_00246314_002424080);
								Expression expression120 = (_0024_00246315_002424081.Right = Expression.Lift(_0024sprop_002424065.Name));
								Expression expression122 = (binaryExpression39.Left = _0024_00246315_002424081);
								BinaryExpression binaryExpression53 = _0024_00246317_002424083;
								StringLiteralExpression stringLiteralExpression9 = (_0024_00246316_002424082 = new StringLiteralExpression(LexicalInfo.Empty));
								string text106 = (_0024_00246316_002424082.Value = "プロパティ設定時");
								Expression expression124 = (binaryExpression53.Right = _0024_00246316_002424082);
								array15[0] = _0024_00246317_002424083;
								ExpressionCollection expressionCollection10 = (macroStatement6.Arguments = ExpressionCollection.FromArray(array15));
								Block block44 = (_0024_00246318_002424084.Body = new Block(LexicalInfo.Empty));
								array14[0] = Statement.Lift(_0024_00246318_002424084);
								StatementCollection statementCollection18 = (block42.Statements = StatementCollection.FromArray(array14));
								Block block46 = (ifStatement9.TrueBlock = _0024_00246319_002424085);
								array13[1] = Statement.Lift(_0024_00246320_002424086);
								ReturnStatement returnStatement9 = (_0024_00246325_002424091 = new ReturnStatement(LexicalInfo.Empty));
								ReturnStatement returnStatement10 = _0024_00246325_002424091;
								SlicingExpression slicingExpression4 = (_0024_00246324_002424090 = new SlicingExpression(LexicalInfo.Empty));
								SlicingExpression slicingExpression5 = _0024_00246324_002424090;
								ReferenceExpression referenceExpression19 = (_0024_00246321_002424087 = new ReferenceExpression(LexicalInfo.Empty));
								string text108 = (_0024_00246321_002424087.Name = "_InstanceList");
								Expression expression126 = (slicingExpression5.Target = _0024_00246321_002424087);
								SlicingExpression slicingExpression6 = _0024_00246324_002424090;
								Slice[] array16 = new Slice[1];
								Slice slice3 = (_0024_00246323_002424089 = new Slice(LexicalInfo.Empty));
								Slice slice4 = _0024_00246323_002424089;
								IntegerLiteralExpression integerLiteralExpression7 = (_0024_00246322_002424088 = new IntegerLiteralExpression(LexicalInfo.Empty));
								long num14 = (_0024_00246322_002424088.Value = 0L);
								bool flag23 = (_0024_00246322_002424088.IsLong = false);
								Expression expression128 = (slice4.Begin = _0024_00246322_002424088);
								array16[0] = _0024_00246323_002424089;
								SliceCollection sliceCollection4 = (slicingExpression6.Indices = SliceCollection.FromArray(array16));
								Expression expression130 = (returnStatement10.Expression = new MemberReferenceExpression(_0024_00246324_002424090, CodeSerializer.LiftName(_0024ipref_002424063)));
								array13[2] = Statement.Lift(_0024_00246325_002424091);
								StatementCollection statementCollection20 = (block40.Statements = StatementCollection.FromArray(array13));
								getter.Body = _0024_00246326_002424092.ToBlock();
							}
							if (_0024prop_002424061.Setter != null)
							{
								_0024sprop_002424065.Setter = new Method();
								Method setter = _0024sprop_002424065.Setter;
								ForStatement forStatement = (_0024_00246333_002424099 = new ForStatement(LexicalInfo.Empty));
								ForStatement forStatement2 = _0024_00246333_002424099;
								Declaration[] array17 = new Declaration[1];
								Declaration declaration = (_0024_00246327_002424093 = new Declaration(LexicalInfo.Empty));
								string text110 = (_0024_00246327_002424093.Name = "i");
								array17[0] = _0024_00246327_002424093;
								DeclarationCollection declarationCollection2 = (forStatement2.Declarations = DeclarationCollection.FromArray(array17));
								ForStatement forStatement3 = _0024_00246333_002424099;
								ReferenceExpression referenceExpression20 = (_0024_00246328_002424094 = new ReferenceExpression(LexicalInfo.Empty));
								string text112 = (_0024_00246328_002424094.Name = "_InstanceList");
								Expression expression132 = (forStatement3.Iterator = _0024_00246328_002424094);
								ForStatement forStatement4 = _0024_00246333_002424099;
								Block block47 = (_0024_00246332_002424098 = new Block(LexicalInfo.Empty));
								Block block48 = _0024_00246332_002424098;
								Statement[] array18 = new Statement[1];
								BinaryExpression binaryExpression54 = (_0024_00246331_002424097 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType40 = (_0024_00246331_002424097.Operator = BinaryOperatorType.Assign);
								BinaryExpression binaryExpression55 = _0024_00246331_002424097;
								ReferenceExpression referenceExpression21 = (_0024_00246329_002424095 = new ReferenceExpression(LexicalInfo.Empty));
								string text114 = (_0024_00246329_002424095.Name = "i");
								Expression expression134 = (binaryExpression55.Left = new MemberReferenceExpression(_0024_00246329_002424095, CodeSerializer.LiftName(_0024ipref_002424063)));
								BinaryExpression binaryExpression56 = _0024_00246331_002424097;
								ReferenceExpression referenceExpression22 = (_0024_00246330_002424096 = new ReferenceExpression(LexicalInfo.Empty));
								string text116 = (_0024_00246330_002424096.Name = "value");
								Expression expression136 = (binaryExpression56.Right = _0024_00246330_002424096);
								array18[0] = Statement.Lift(_0024_00246331_002424097);
								StatementCollection statementCollection22 = (block48.Statements = StatementCollection.FromArray(array18));
								Block block50 = (forStatement4.Block = _0024_00246332_002424098);
								setter.Body = _0024_00246333_002424099.ToBlock();
							}
							flag = Yield(9, _0024sprop_002424065);
							goto IL_2352;
						}
						_state = 1;
						_0024ensure8();
						YieldDefault(1);
						break;
					}
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_2353;
				IL_2352:
				result = (flag ? 1 : 0);
				goto IL_2353;
				IL_2353:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414229_002424100.Dispose();
			}

			private void _0024ensure4()
			{
				_0024_0024iterator_002414230_002424101.Dispose();
			}

			private void _0024ensure6()
			{
				_0024_0024iterator_002414231_002424102.Dispose();
			}

			private void _0024ensure8()
			{
				_0024_0024iterator_002414232_002424103.Dispose();
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
				case 6:
				case 7:
					_state = 1;
					_0024ensure6();
					break;
				case 8:
				case 9:
					_state = 1;
					_0024ensure8();
					break;
				}
			}
		}

		internal Boo.Lang.Compiler.Ast.Node _0024mdef_002424106;

		internal HudMacroBase _0024self__002424107;

		public _0024InstanceManagingCode_002423968(Boo.Lang.Compiler.Ast.Node mdef, HudMacroBase self_)
		{
			_0024mdef_002424106 = mdef;
			_0024self__002424107 = self_;
		}

		public override IEnumerator<TypeMember> GetEnumerator()
		{
			return new _0024(_0024mdef_002424106, _0024self__002424107);
		}
	}

	[NonSerialized]
	public const bool WARN_0_OR_2_OBJECTS_TO_INVOKE_METHOD = false;

	protected ClassDefinition parentClass;

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

	private IEnumerable<Method> yieldAltNamedMethod(Method m, string altName)
	{
		return new _0024yieldAltNamedMethod_002423961(m, altName);
	}

	protected IEnumerable<TypeMember> InstanceManagingCode(Boo.Lang.Compiler.Ast.Node mdef)
	{
		return new _0024InstanceManagingCode_002423968(mdef, this);
	}
}
