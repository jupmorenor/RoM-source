using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class Act_methodMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	public class IdentifierExpander : DepthFirstTransformer
	{
		public Dictionary<string, Boo.Lang.Compiler.Ast.Node> replaceMap;

		public IdentifierExpander()
		{
			replaceMap = new Dictionary<string, Boo.Lang.Compiler.Ast.Node>();
		}

		public void addMap(string n, Boo.Lang.Compiler.Ast.Node node)
		{
			if (string.IsNullOrEmpty(n) || node == null)
			{
				throw new AssertionFailedException("(not string.IsNullOrEmpty(n)) and (node != null)");
			}
			if (replaceMap.ContainsKey(n))
			{
				throw new Exception(new StringBuilder("'").Append(n).Append("' is declared twice or more.").ToString());
			}
			replaceMap[n] = node;
		}

		public override void OnReferenceExpression(ReferenceExpression node)
		{
			Boo.Lang.Compiler.Ast.Node node2 = null;
			string name = node.Name;
			if (replaceMap.ContainsKey(name))
			{
				object obj = replaceMap[name].Clone();
				if (!(obj is Boo.Lang.Compiler.Ast.Node))
				{
					obj = RuntimeServices.Coerce(obj, typeof(Boo.Lang.Compiler.Ast.Node));
				}
				node2 = (Boo.Lang.Compiler.Ast.Node)obj;
			}
			if (node2 != null)
			{
				ReplaceCurrentNode(node2);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002423095 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MethodInvocationExpression _0024mdef_002423096;

			internal string _0024mname_002423097;

			internal string _0024groupName_002423098;

			internal string _0024actName_002423099;

			internal string _0024actClassName_002423100;

			internal string _0024testPropName_002423101;

			internal string _0024createMethodName_002423102;

			internal string _0024createDataMethodName_002423103;

			internal string _0024changeMethodName_002423104;

			internal string _0024actParamName_002423105;

			internal string _0024enumName_002423106;

			internal string _0024enumNumName_002423107;

			internal string _0024actDataPropName_002423108;

			internal string _0024groupTimePropName_002423109;

			internal bool _0024isDefaultGroup_002423110;

			internal string _0024groupNamePart_002423111;

			internal Block _0024varBlock_002423112;

			internal string _0024blkname_002423113;

			internal Block _0024block_002423114;

			internal TypeMember _0024___item_002423115;

			internal bool _0024firstGroupDef_002423116;

			internal IdentifierExpander _0024varMapper_002423117;

			internal ReferenceExpression _0024memInitBaseVar_002423118;

			internal ParameterDeclarationCollection _0024actParamDecl_002423119;

			internal ExpressionCollection _0024actArgList_002423120;

			internal System.Collections.Generic.List<Field> _0024decls_002423121;

			internal Block _0024memInit_002423122;

			internal ParameterDeclaration _0024a_002423123;

			internal ClassDefinition _0024_00246112_002423124;

			internal ClassDefinition _0024actcls_002423125;

			internal Field _0024f_002423126;

			internal Field _0024f_002423127;

			internal ReferenceExpression _0024actClassRef_002423128;

			internal ReferenceExpression _0024actionEnum_002423129;

			internal EnumMember _0024_00246133_002423130;

			internal ReferenceExpression _0024myEnum_002423131;

			internal ReferenceExpression _0024cdmname_002423132;

			internal ReferenceExpression _0024_00246134_002423133;

			internal BinaryExpression _0024_00246135_002423134;

			internal MethodInvocationExpression _0024_00246136_002423135;

			internal ReturnStatement _0024_00246137_002423136;

			internal Block _0024_00246138_002423137;

			internal IfStatement _0024_00246139_002423138;

			internal IfStatement _0024cstmt_002423139;

			internal ReferenceExpression _0024testEnumRef_002423140;

			internal ReferenceExpression _0024_00246140_002423141;

			internal MethodInvocationExpression _0024_00246141_002423142;

			internal ReferenceExpression _0024_00246142_002423143;

			internal BinaryExpression _0024_00246143_002423144;

			internal ReturnStatement _0024_00246144_002423145;

			internal Block _0024_00246145_002423146;

			internal Method _0024_00246146_002423147;

			internal SimpleTypeReference _0024_00246147_002423148;

			internal Property _0024_00246148_002423149;

			internal string _0024testTimeMethodName_002423150;

			internal ReferenceExpression _0024actTimeVar_002423151;

			internal ReferenceExpression _0024realActTimeProp_002423152;

			internal Expression _0024nowTimeVar_002423153;

			internal Expression _0024deltaTimeVar_002423154;

			internal SimpleTypeReference _0024_00246149_002423155;

			internal ParameterDeclaration _0024_00246150_002423156;

			internal SimpleTypeReference _0024_00246151_002423157;

			internal MemberReferenceExpression _0024_00246152_002423158;

			internal MethodInvocationExpression _0024_00246153_002423159;

			internal ReferenceExpression _0024_00246154_002423160;

			internal Slice _0024_00246155_002423161;

			internal SlicingExpression _0024_00246156_002423162;

			internal BinaryExpression _0024_00246157_002423163;

			internal ReferenceExpression _0024_00246158_002423164;

			internal ReferenceExpression _0024_00246159_002423165;

			internal BinaryExpression _0024_00246160_002423166;

			internal ReferenceExpression _0024_00246161_002423167;

			internal ReferenceExpression _0024_00246162_002423168;

			internal ReferenceExpression _0024_00246163_002423169;

			internal BinaryExpression _0024_00246164_002423170;

			internal BinaryExpression _0024_00246165_002423171;

			internal ReferenceExpression _0024_00246166_002423172;

			internal IntegerLiteralExpression _0024_00246167_002423173;

			internal BinaryExpression _0024_00246168_002423174;

			internal ReferenceExpression _0024_00246169_002423175;

			internal BinaryExpression _0024_00246170_002423176;

			internal BinaryExpression _0024_00246171_002423177;

			internal ReturnStatement _0024_00246172_002423178;

			internal Block _0024_00246173_002423179;

			internal BoolLiteralExpression _0024_00246174_002423180;

			internal ReturnStatement _0024_00246175_002423181;

			internal Block _0024_00246176_002423182;

			internal IfStatement _0024_00246177_002423183;

			internal Block _0024_00246178_002423184;

			internal Method _0024_00246179_002423185;

			internal ReferenceExpression _0024groupTimePropRef_002423186;

			internal ReferenceExpression _0024_00246180_002423187;

			internal MethodInvocationExpression _0024_00246181_002423188;

			internal ReturnStatement _0024_00246182_002423189;

			internal Block _0024_00246183_002423190;

			internal Method _0024_00246184_002423191;

			internal SimpleTypeReference _0024_00246185_002423192;

			internal Property _0024_00246186_002423193;

			internal ReferenceExpression _0024actDataPropRef_002423194;

			internal ReferenceExpression _0024_00246187_002423195;

			internal MethodInvocationExpression _0024_00246188_002423196;

			internal TryCastExpression _0024_00246189_002423197;

			internal ReturnStatement _0024_00246190_002423198;

			internal Block _0024_00246191_002423199;

			internal Method _0024_00246192_002423200;

			internal Property _0024_00246193_002423201;

			internal object[] _0024_002414207_002423202;

			internal IEnumerator<object[]> _0024_0024iterator_002414208_002423203;

			internal object[] _0024_002414209_002423204;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414210_002423205;

			internal object[] _0024_002414211_002423206;

			internal IEnumerator<ParameterDeclaration> _0024_0024iterator_002414212_002423207;

			internal System.Collections.Generic.List<Field>.Enumerator _0024_0024iterator_002414213_002423208;

			internal IEnumerator<Field> _0024_0024iterator_002414214_002423209;

			internal Expression[] _0024_002414215_002423210;

			internal MacroStatement _0024mc_002423211;

			internal Act_methodMacro _0024self__002423212;

			public _0024(MacroStatement mc, Act_methodMacro self_)
			{
				_0024mc_002423211 = mc;
				_0024self__002423212 = self_;
			}

			public override bool MoveNext()
			{
				bool flag9;
				try
				{
					switch (_state)
					{
					default:
					{
						if (((ICollection)_0024mc_002423211.Arguments).Count != 1)
						{
							throw new AssertionFailedException("len(mc.Arguments) == 1");
						}
						_0024mdef_002423096 = _0024mc_002423211.Arguments[0] as MethodInvocationExpression;
						if (_0024mdef_002423096 == null)
						{
							throw new AssertionFailedException("mdef != null");
						}
						_0024mname_002423097 = _0024self__002423212.methodName(_0024mdef_002423096);
						_0024_002414207_002423202 = _0024self__002423212.groupAndStateName(_0024mname_002423097);
						object obj = _0024_002414207_002423202[0];
						if (!(obj is string))
						{
							obj = RuntimeServices.Coerce(obj, typeof(string));
						}
						_0024groupName_002423098 = (string)obj;
						object obj2 = _0024_002414207_002423202[1];
						if (!(obj2 is string))
						{
							obj2 = RuntimeServices.Coerce(obj2, typeof(string));
						}
						_0024actName_002423099 = (string)obj2;
						_0024actClassName_002423100 = $"ActionClass{_0024actName_002423099}";
						_0024testPropName_002423101 = $"Is{_0024actName_002423099}";
						_0024createMethodName_002423102 = $"create{_0024actName_002423099}";
						_0024createDataMethodName_002423103 = $"createData{_0024actName_002423099}";
						_0024changeMethodName_002423104 = _0024actName_002423099;
						_0024actParamName_002423105 = _0024self__002423212.tmpVarName();
						_0024enumName_002423106 = "ActionEnum";
						_0024enumNumName_002423107 = "NUM";
						_0024actDataPropName_002423108 = $"{_0024actName_002423099}Data";
						_0024groupTimePropName_002423109 = $"actionTime{_0024groupName_002423098}";
						_0024isDefaultGroup_002423110 = _0024groupName_002423098 == "$default$";
						_0024groupNamePart_002423111 = ((!_0024isDefaultGroup_002423110) ? _0024groupName_002423098 : string.Empty);
						_0024varBlock_002423112 = new Block();
						_0024_0024iterator_002414208_002423203 = _0024self__002423212.forAllInnerBlocks(_0024mc_002423211).GetEnumerator();
						try
						{
							while (_0024_0024iterator_002414208_002423203.MoveNext())
							{
								_0024_002414209_002423204 = _0024_0024iterator_002414208_002423203.Current;
								object obj3 = _0024_002414209_002423204[0];
								if (!(obj3 is string))
								{
									obj3 = RuntimeServices.Coerce(obj3, typeof(string));
								}
								_0024blkname_002423113 = (string)obj3;
								object obj4 = _0024_002414209_002423204[1];
								if (!(obj4 is Block))
								{
									obj4 = RuntimeServices.Coerce(obj4, typeof(Block));
								}
								_0024block_002423114 = (Block)obj4;
								if (_0024blkname_002423113 == "var")
								{
									_0024varBlock_002423112.Add(_0024block_002423114);
								}
								else if (_0024blkname_002423113 == "leadingDecls")
								{
									_0024varBlock_002423112.Add(_0024block_002423114);
								}
							}
						}
						finally
						{
							_0024_0024iterator_002414208_002423203.Dispose();
						}
						_0024_0024iterator_002414210_002423205 = _0024self__002423212.emitActionSystemCode(_0024mc_002423211, _0024enumName_002423106, _0024enumNumName_002423107).GetEnumerator();
						_state = 2;
						goto case 3;
					}
					case 3:
						if (_0024_0024iterator_002414210_002423205.MoveNext())
						{
							_0024___item_002423115 = _0024_0024iterator_002414210_002423205.Current;
							flag9 = Yield(3, _0024___item_002423115);
						}
						else
						{
							_state = 1;
							_0024ensure2();
							if (_0024self__002423212.actionNameSet.Contains(_0024mname_002423097))
							{
								throw new Exception(new StringBuilder("action '").Append(_0024mname_002423097).Append("' is already defined").ToString());
							}
							_0024self__002423212.actionNameSet.Add(_0024mname_002423097);
							_0024firstGroupDef_002423116 = false;
							if (!_0024self__002423212.actionGroupSet.Contains(_0024groupName_002423098))
							{
								_0024self__002423212.actionGroupSet.Add(_0024groupName_002423098);
								_0024firstGroupDef_002423116 = true;
							}
							_0024varMapper_002423117 = new IdentifierExpander();
							_0024varMapper_002423117.addMap("actionTime", _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append("actionTime")
								.ToString()));
							_0024varMapper_002423117.addMap("preActionTime", _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append("preActionTime")
								.ToString()));
							_0024varMapper_002423117.addMap("realActionTime", _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append("realActionTime")
								.ToString()));
							_0024varMapper_002423117.addMap("actionFrame", _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append("actionFrame")
								.ToString()));
							_0024memInitBaseVar_002423118 = _0024self__002423212.tmpVar();
							_0024actParamDecl_002423119 = null;
							_0024actArgList_002423120 = null;
							_0024decls_002423121 = null;
							_0024memInit_002423122 = null;
							_0024_002414211_002423206 = _0024self__002423212.tryCastsToParameters(_0024mdef_002423096.Arguments, _0024memInitBaseVar_002423118);
							object obj5 = _0024_002414211_002423206[0];
							if (!(obj5 is ParameterDeclarationCollection))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(ParameterDeclarationCollection));
							}
							_0024actParamDecl_002423119 = (ParameterDeclarationCollection)obj5;
							object obj6 = _0024_002414211_002423206[1];
							if (!(obj6 is ExpressionCollection))
							{
								obj6 = RuntimeServices.Coerce(obj6, typeof(ExpressionCollection));
							}
							_0024actArgList_002423120 = (ExpressionCollection)obj6;
							object obj7 = _0024_002414211_002423206[2];
							if (!(obj7 is System.Collections.Generic.List<Field>))
							{
								obj7 = RuntimeServices.Coerce(obj7, typeof(System.Collections.Generic.List<Field>));
							}
							_0024decls_002423121 = (System.Collections.Generic.List<Field>)obj7;
							object obj8 = _0024_002414211_002423206[3];
							if (!(obj8 is Block))
							{
								obj8 = RuntimeServices.Coerce(obj8, typeof(Block));
							}
							_0024memInit_002423122 = (Block)obj8;
							_0024_0024iterator_002414212_002423207 = _0024actParamDecl_002423119.GetEnumerator();
							try
							{
								while (_0024_0024iterator_002414212_002423207.MoveNext())
								{
									_0024a_002423123 = _0024_0024iterator_002414212_002423207.Current;
									_0024varMapper_002423117.addMap(_0024a_002423123.Name, _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append(_0024a_002423123.Name)
										.ToString()));
								}
							}
							finally
							{
								_0024_0024iterator_002414212_002423207.Dispose();
							}
							ClassDefinition classDefinition = (_0024_00246112_002423124 = new ClassDefinition());
							string text40 = (_0024_00246112_002423124.Name = _0024actClassName_002423100);
							_0024actcls_002423125 = _0024_00246112_002423124;
							_0024actcls_002423125.BaseTypes.Add(TypeReference.Lift(new ReferenceExpression("ActionBase")));
							_0024_0024iterator_002414213_002423208 = _0024decls_002423121.GetEnumerator();
							try
							{
								while (_0024_0024iterator_002414213_002423208.MoveNext())
								{
									_0024f_002423126 = _0024_0024iterator_002414213_002423208.Current;
									_0024actcls_002423125.Members.Add(_0024f_002423126);
								}
							}
							finally
							{
								((IDisposable)_0024_0024iterator_002414213_002423208).Dispose();
							}
							if (_0024varBlock_002423112 != null)
							{
								_0024_0024iterator_002414214_002423209 = _0024self__002423212.variableDeclarations(_0024varBlock_002423112).GetEnumerator();
								try
								{
									while (_0024_0024iterator_002414214_002423209.MoveNext())
									{
										_0024f_002423127 = _0024_0024iterator_002414214_002423209.Current;
										_0024actcls_002423125.Members.Add(_0024f_002423127);
										_0024varMapper_002423117.addMap(_0024f_002423127.Name, _0024self__002423212.refLift(new StringBuilder().Append(_0024actParamName_002423105).Append(".").Append(_0024f_002423127.Name)
											.ToString()));
									}
								}
								finally
								{
									_0024_0024iterator_002414214_002423209.Dispose();
								}
							}
							flag9 = Yield(4, _0024actcls_002423125);
						}
						goto IL_1bc5;
					case 4:
						_0024actClassRef_002423128 = new ReferenceExpression(_0024actClassName_002423100);
						flag9 = Yield(5, _0024self__002423212.changerMethod(_0024changeMethodName_002423104, _0024createMethodName_002423102, _0024actClassName_002423100, _0024actParamDecl_002423119, _0024actArgList_002423120));
						goto IL_1bc5;
					case 5:
						_0024actionEnum_002423129 = _0024self__002423212.refLift(new StringBuilder().Append(_0024enumName_002423106).Append(".").Append(_0024actName_002423099)
							.ToString());
						flag9 = Yield(6, _0024self__002423212.generateCreateDataMethod(_0024createDataMethodName_002423103, _0024actionEnum_002423129, _0024actClassName_002423100, _0024memInitBaseVar_002423118, _0024groupName_002423098, _0024actParamName_002423105, _0024varMapper_002423117, _0024mc_002423211));
						goto IL_1bc5;
					case 6:
						flag9 = Yield(7, _0024self__002423212.generateCreateMethod(_0024createMethodName_002423102, _0024createDataMethodName_002423103, _0024actClassName_002423100, _0024actParamDecl_002423119, _0024actArgList_002423120, _0024memInitBaseVar_002423118, _0024memInit_002423122, _0024varBlock_002423112));
						goto IL_1bc5;
					case 7:
					{
						TypeMemberCollection members = _0024self__002423212.actionEnumDef.Members;
						EnumMember enumMember = (_0024_00246133_002423130 = new EnumMember());
						string text50 = (_0024_00246133_002423130.Name = _0024actName_002423099);
						members.Insert(0, _0024_00246133_002423130);
						_0024myEnum_002423131 = _0024self__002423212.refLift(new StringBuilder().Append(_0024enumName_002423106).Append(".").Append(_0024actName_002423099)
							.ToString());
						_0024cdmname_002423132 = new ReferenceExpression(_0024createDataMethodName_002423103);
						IfStatement ifStatement5 = (_0024_00246139_002423138 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement6 = _0024_00246139_002423138;
						BinaryExpression binaryExpression21 = (_0024_00246135_002423134 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType16 = (_0024_00246135_002423134.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression22 = _0024_00246135_002423134;
						ReferenceExpression referenceExpression11 = (_0024_00246134_002423133 = new ReferenceExpression(LexicalInfo.Empty));
						string text52 = (_0024_00246134_002423133.Name = "actID");
						Expression expression54 = (binaryExpression22.Left = _0024_00246134_002423133);
						Expression expression56 = (_0024_00246135_002423134.Right = Expression.Lift(_0024myEnum_002423131));
						Expression expression58 = (ifStatement6.Condition = _0024_00246135_002423134);
						IfStatement ifStatement7 = _0024_00246139_002423138;
						Block block21 = (_0024_00246138_002423137 = new Block(LexicalInfo.Empty));
						Block block22 = _0024_00246138_002423137;
						Statement[] array8 = new Statement[1];
						ReturnStatement returnStatement9 = (_0024_00246137_002423136 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement10 = _0024_00246137_002423136;
						MethodInvocationExpression methodInvocationExpression7 = (_0024_00246136_002423135 = new MethodInvocationExpression(LexicalInfo.Empty));
						Expression expression60 = (_0024_00246136_002423135.Target = Expression.Lift(_0024cdmname_002423132));
						Expression expression62 = (returnStatement10.Expression = _0024_00246136_002423135);
						array8[0] = Statement.Lift(_0024_00246137_002423136);
						StatementCollection statementCollection12 = (block22.Statements = StatementCollection.FromArray(array8));
						Block block24 = (ifStatement7.TrueBlock = _0024_00246138_002423137);
						_0024cstmt_002423139 = _0024_00246139_002423138;
						_0024self__002423212.createDispatchBlock.Add(_0024cstmt_002423139);
						_0024testEnumRef_002423140 = new ReferenceExpression(_0024actName_002423099);
						Property property6 = (_0024_00246148_002423149 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers8 = (_0024_00246148_002423149.Modifiers = TypeMemberModifiers.Public);
						string text54 = (_0024_00246148_002423149.Name = "$");
						Property property7 = _0024_00246148_002423149;
						Method method13 = (_0024_00246146_002423147 = new Method(LexicalInfo.Empty));
						string text56 = (_0024_00246146_002423147.Name = "get");
						Method method14 = _0024_00246146_002423147;
						Block block25 = (_0024_00246145_002423146 = new Block(LexicalInfo.Empty));
						Block block26 = _0024_00246145_002423146;
						Statement[] array9 = new Statement[1];
						ReturnStatement returnStatement11 = (_0024_00246144_002423145 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement12 = _0024_00246144_002423145;
						BinaryExpression binaryExpression23 = (_0024_00246143_002423144 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType18 = (_0024_00246143_002423144.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression24 = _0024_00246143_002423144;
						MethodInvocationExpression methodInvocationExpression8 = (_0024_00246141_002423142 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression9 = _0024_00246141_002423142;
						ReferenceExpression referenceExpression12 = (_0024_00246140_002423141 = new ReferenceExpression(LexicalInfo.Empty));
						string text58 = (_0024_00246140_002423141.Name = "currActionID");
						Expression expression64 = (methodInvocationExpression9.Target = _0024_00246140_002423141);
						ExpressionCollection expressionCollection8 = (_0024_00246141_002423142.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024groupName_002423098)));
						Expression expression66 = (binaryExpression24.Left = _0024_00246141_002423142);
						BinaryExpression binaryExpression25 = _0024_00246143_002423144;
						ReferenceExpression referenceExpression13 = (_0024_00246142_002423143 = new ReferenceExpression(LexicalInfo.Empty));
						string text60 = (_0024_00246142_002423143.Name = "ActionEnum");
						Expression expression68 = (binaryExpression25.Right = new MemberReferenceExpression(_0024_00246142_002423143, CodeSerializer.LiftName(_0024testEnumRef_002423140)));
						Expression expression70 = (returnStatement12.Expression = _0024_00246143_002423144);
						array9[0] = Statement.Lift(_0024_00246144_002423145);
						StatementCollection statementCollection14 = (block26.Statements = StatementCollection.FromArray(array9));
						Block block28 = (method14.Body = _0024_00246145_002423146);
						Method method16 = (property7.Getter = _0024_00246146_002423147);
						Property property8 = _0024_00246148_002423149;
						SimpleTypeReference simpleTypeReference4 = (_0024_00246147_002423148 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag13 = (_0024_00246147_002423148.IsPointer = false);
						string text62 = (_0024_00246147_002423148.Name = "bool");
						TypeReference typeReference12 = (property8.Type = _0024_00246147_002423148);
						string text64 = (_0024_00246148_002423149.Name = CodeSerializer.LiftName(_0024testPropName_002423101));
						flag9 = Yield(8, _0024_00246148_002423149);
						goto IL_1bc5;
					}
					case 8:
					{
						if (!_0024firstGroupDef_002423116)
						{
							goto case 9;
						}
						_0024testTimeMethodName_002423150 = $"Is{_0024groupNamePart_002423111}AtTime";
						_0024actTimeVar_002423151 = new ReferenceExpression("actionTime");
						_0024realActTimeProp_002423152 = new ReferenceExpression("realActionTime");
						_0024_002414215_002423210 = _0024self__002423212.timeVars();
						_0024nowTimeVar_002423153 = _0024_002414215_002423210[0];
						_0024deltaTimeVar_002423154 = _0024_002414215_002423210[1];
						Method method = (_0024_00246179_002423185 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00246179_002423185.Modifiers = TypeMemberModifiers.Public);
						string text2 = (_0024_00246179_002423185.Name = "$");
						Method method2 = _0024_00246179_002423185;
						ParameterDeclaration[] array = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration = (_0024_00246150_002423156 = new ParameterDeclaration(LexicalInfo.Empty));
						string text4 = (_0024_00246150_002423156.Name = "t");
						ParameterDeclaration parameterDeclaration2 = _0024_00246150_002423156;
						SimpleTypeReference simpleTypeReference = (_0024_00246149_002423155 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag2 = (_0024_00246149_002423155.IsPointer = false);
						string text6 = (_0024_00246149_002423155.Name = "single");
						TypeReference typeReference2 = (parameterDeclaration2.Type = _0024_00246149_002423155);
						array[0] = _0024_00246150_002423156;
						ParameterDeclarationCollection parameterDeclarationCollection2 = (method2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array));
						Method method3 = _0024_00246179_002423185;
						SimpleTypeReference simpleTypeReference2 = (_0024_00246151_002423157 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag4 = (_0024_00246151_002423157.IsPointer = false);
						string text8 = (_0024_00246151_002423157.Name = "bool");
						TypeReference typeReference4 = (method3.ReturnType = _0024_00246151_002423157);
						Method method4 = _0024_00246179_002423185;
						Block block = (_0024_00246178_002423184 = new Block(LexicalInfo.Empty));
						Block block2 = _0024_00246178_002423184;
						Statement[] array2 = new Statement[1];
						IfStatement ifStatement = (_0024_00246177_002423183 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement2 = _0024_00246177_002423183;
						MethodInvocationExpression methodInvocationExpression = (_0024_00246153_002423159 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00246153_002423159;
						MemberReferenceExpression memberReferenceExpression = (_0024_00246152_002423158 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text10 = (_0024_00246152_002423158.Name = "ContainsKey");
						Expression expression2 = (_0024_00246152_002423158.Target = Expression.Lift(_0024self__002423212.currentActionDic));
						Expression expression4 = (methodInvocationExpression2.Target = _0024_00246152_002423158);
						ExpressionCollection expressionCollection2 = (_0024_00246153_002423159.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024groupName_002423098)));
						Expression expression6 = (ifStatement2.Condition = _0024_00246153_002423159);
						IfStatement ifStatement3 = _0024_00246177_002423183;
						Block block3 = (_0024_00246173_002423179 = new Block(LexicalInfo.Empty));
						Block block4 = _0024_00246173_002423179;
						Statement[] array3 = new Statement[4];
						BinaryExpression binaryExpression = (_0024_00246157_002423163 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00246157_002423163.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression2 = _0024_00246157_002423163;
						ReferenceExpression referenceExpression = (_0024_00246154_002423160 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00246154_002423160.Name = "act");
						Expression expression8 = (binaryExpression2.Left = _0024_00246154_002423160);
						BinaryExpression binaryExpression3 = _0024_00246157_002423163;
						SlicingExpression slicingExpression = (_0024_00246156_002423162 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression10 = (_0024_00246156_002423162.Target = Expression.Lift(_0024self__002423212.currentActionDic));
						SlicingExpression slicingExpression2 = _0024_00246156_002423162;
						Slice[] array4 = new Slice[1];
						Slice slice = (_0024_00246155_002423161 = new Slice(LexicalInfo.Empty));
						Expression expression12 = (_0024_00246155_002423161.Begin = Expression.Lift(_0024groupName_002423098));
						array4[0] = _0024_00246155_002423161;
						SliceCollection sliceCollection2 = (slicingExpression2.Indices = SliceCollection.FromArray(array4));
						Expression expression14 = (binaryExpression3.Right = _0024_00246156_002423162);
						array3[0] = Statement.Lift(_0024_00246157_002423163);
						BinaryExpression binaryExpression4 = (_0024_00246160_002423166 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00246160_002423166.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression5 = _0024_00246160_002423166;
						ReferenceExpression referenceExpression2 = (_0024_00246158_002423164 = new ReferenceExpression(LexicalInfo.Empty));
						string text14 = (_0024_00246158_002423164.Name = "rt");
						Expression expression16 = (binaryExpression5.Left = _0024_00246158_002423164);
						BinaryExpression binaryExpression6 = _0024_00246160_002423166;
						ReferenceExpression referenceExpression3 = (_0024_00246159_002423165 = new ReferenceExpression(LexicalInfo.Empty));
						string text16 = (_0024_00246159_002423165.Name = "act");
						Expression expression18 = (binaryExpression6.Right = new MemberReferenceExpression(_0024_00246159_002423165, CodeSerializer.LiftName(_0024realActTimeProp_002423152)));
						array3[1] = Statement.Lift(_0024_00246160_002423166);
						BinaryExpression binaryExpression7 = (_0024_00246165_002423171 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType6 = (_0024_00246165_002423171.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression8 = _0024_00246165_002423171;
						ReferenceExpression referenceExpression4 = (_0024_00246161_002423167 = new ReferenceExpression(LexicalInfo.Empty));
						string text18 = (_0024_00246161_002423167.Name = "dt");
						Expression expression20 = (binaryExpression8.Left = _0024_00246161_002423167);
						BinaryExpression binaryExpression9 = _0024_00246165_002423171;
						BinaryExpression binaryExpression10 = (_0024_00246164_002423170 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType8 = (_0024_00246164_002423170.Operator = BinaryOperatorType.Subtraction);
						BinaryExpression binaryExpression11 = _0024_00246164_002423170;
						ReferenceExpression referenceExpression5 = (_0024_00246162_002423168 = new ReferenceExpression(LexicalInfo.Empty));
						string text20 = (_0024_00246162_002423168.Name = "act");
						Expression expression22 = (binaryExpression11.Left = new MemberReferenceExpression(_0024_00246162_002423168, CodeSerializer.LiftName(_0024realActTimeProp_002423152)));
						BinaryExpression binaryExpression12 = _0024_00246164_002423170;
						ReferenceExpression referenceExpression6 = (_0024_00246163_002423169 = new ReferenceExpression(LexicalInfo.Empty));
						string text22 = (_0024_00246163_002423169.Name = "t");
						Expression expression24 = (binaryExpression12.Right = _0024_00246163_002423169);
						Expression expression26 = (binaryExpression9.Right = _0024_00246164_002423170);
						array3[2] = Statement.Lift(_0024_00246165_002423171);
						ReturnStatement returnStatement = (_0024_00246172_002423178 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00246172_002423178;
						BinaryExpression binaryExpression13 = (_0024_00246171_002423177 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType10 = (_0024_00246171_002423177.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression14 = _0024_00246171_002423177;
						BinaryExpression binaryExpression15 = (_0024_00246168_002423174 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType12 = (_0024_00246168_002423174.Operator = BinaryOperatorType.GreaterThan);
						BinaryExpression binaryExpression16 = _0024_00246168_002423174;
						ReferenceExpression referenceExpression7 = (_0024_00246166_002423172 = new ReferenceExpression(LexicalInfo.Empty));
						string text24 = (_0024_00246166_002423172.Name = "dt");
						Expression expression28 = (binaryExpression16.Left = _0024_00246166_002423172);
						BinaryExpression binaryExpression17 = _0024_00246168_002423174;
						IntegerLiteralExpression integerLiteralExpression = (_0024_00246167_002423173 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num2 = (_0024_00246167_002423173.Value = 0L);
						bool flag6 = (_0024_00246167_002423173.IsLong = false);
						Expression expression30 = (binaryExpression17.Right = _0024_00246167_002423173);
						Expression expression32 = (binaryExpression14.Left = _0024_00246168_002423174);
						BinaryExpression binaryExpression18 = _0024_00246171_002423177;
						BinaryExpression binaryExpression19 = (_0024_00246170_002423176 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType14 = (_0024_00246170_002423176.Operator = BinaryOperatorType.LessThanOrEqual);
						BinaryExpression binaryExpression20 = _0024_00246170_002423176;
						ReferenceExpression referenceExpression8 = (_0024_00246169_002423175 = new ReferenceExpression(LexicalInfo.Empty));
						string text26 = (_0024_00246169_002423175.Name = "dt");
						Expression expression34 = (binaryExpression20.Left = _0024_00246169_002423175);
						Expression expression36 = (_0024_00246170_002423176.Right = Expression.Lift(_0024deltaTimeVar_002423154));
						Expression expression38 = (binaryExpression18.Right = _0024_00246170_002423176);
						Expression expression40 = (returnStatement2.Expression = _0024_00246171_002423177);
						array3[3] = Statement.Lift(_0024_00246172_002423178);
						StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array3));
						Block block6 = (ifStatement3.TrueBlock = _0024_00246173_002423179);
						IfStatement ifStatement4 = _0024_00246177_002423183;
						Block block7 = (_0024_00246176_002423182 = new Block(LexicalInfo.Empty));
						Block block8 = _0024_00246176_002423182;
						Statement[] array5 = new Statement[1];
						ReturnStatement returnStatement3 = (_0024_00246175_002423181 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement4 = _0024_00246175_002423181;
						BoolLiteralExpression boolLiteralExpression = (_0024_00246174_002423180 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag8 = (_0024_00246174_002423180.Value = false);
						Expression expression42 = (returnStatement4.Expression = _0024_00246174_002423180);
						array5[0] = Statement.Lift(_0024_00246175_002423181);
						StatementCollection statementCollection4 = (block8.Statements = StatementCollection.FromArray(array5));
						Block block10 = (ifStatement4.FalseBlock = _0024_00246176_002423182);
						array2[0] = Statement.Lift(_0024_00246177_002423183);
						StatementCollection statementCollection6 = (block2.Statements = StatementCollection.FromArray(array2));
						Block block12 = (method4.Body = _0024_00246178_002423184);
						string text28 = (_0024_00246179_002423185.Name = CodeSerializer.LiftName(_0024testTimeMethodName_002423150));
						flag9 = Yield(9, _0024_00246179_002423185);
						goto IL_1bc5;
					}
					case 9:
					{
						if (!_0024firstGroupDef_002423116)
						{
							goto case 10;
						}
						_0024groupTimePropName_002423109 = $"actionTime{_0024groupNamePart_002423111}";
						_0024groupTimePropRef_002423186 = new ReferenceExpression(_0024groupTimePropName_002423109);
						Property property = (_0024_00246186_002423193 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers4 = (_0024_00246186_002423193.Modifiers = TypeMemberModifiers.Public);
						string text30 = (_0024_00246186_002423193.Name = "$");
						Property property2 = _0024_00246186_002423193;
						Method method5 = (_0024_00246184_002423191 = new Method(LexicalInfo.Empty));
						string text32 = (_0024_00246184_002423191.Name = "get");
						Method method6 = _0024_00246184_002423191;
						Block block13 = (_0024_00246183_002423190 = new Block(LexicalInfo.Empty));
						Block block14 = _0024_00246183_002423190;
						Statement[] array6 = new Statement[1];
						ReturnStatement returnStatement5 = (_0024_00246182_002423189 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement6 = _0024_00246182_002423189;
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00246181_002423188 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00246181_002423188;
						ReferenceExpression referenceExpression9 = (_0024_00246180_002423187 = new ReferenceExpression(LexicalInfo.Empty));
						string text34 = (_0024_00246180_002423187.Name = "currActionTime");
						Expression expression44 = (methodInvocationExpression4.Target = _0024_00246180_002423187);
						ExpressionCollection expressionCollection4 = (_0024_00246181_002423188.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024groupName_002423098)));
						Expression expression46 = (returnStatement6.Expression = _0024_00246181_002423188);
						array6[0] = Statement.Lift(_0024_00246182_002423189);
						StatementCollection statementCollection8 = (block14.Statements = StatementCollection.FromArray(array6));
						Block block16 = (method6.Body = _0024_00246183_002423190);
						Method method8 = (property2.Getter = _0024_00246184_002423191);
						Property property3 = _0024_00246186_002423193;
						SimpleTypeReference simpleTypeReference3 = (_0024_00246185_002423192 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag11 = (_0024_00246185_002423192.IsPointer = false);
						string text36 = (_0024_00246185_002423192.Name = "single");
						TypeReference typeReference6 = (property3.Type = _0024_00246185_002423192);
						string text38 = (_0024_00246186_002423193.Name = CodeSerializer.LiftName(_0024groupTimePropRef_002423186));
						flag9 = Yield(10, _0024_00246186_002423193);
						goto IL_1bc5;
					}
					case 10:
					{
						_0024actDataPropRef_002423194 = new ReferenceExpression(_0024actDataPropName_002423108);
						Property property4 = (_0024_00246193_002423201 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers6 = (_0024_00246193_002423201.Modifiers = TypeMemberModifiers.Public);
						string text42 = (_0024_00246193_002423201.Name = "$");
						Property property5 = _0024_00246193_002423201;
						Method method9 = (_0024_00246192_002423200 = new Method(LexicalInfo.Empty));
						string text44 = (_0024_00246192_002423200.Name = "get");
						Method method10 = _0024_00246192_002423200;
						Block block17 = (_0024_00246191_002423199 = new Block(LexicalInfo.Empty));
						Block block18 = _0024_00246191_002423199;
						Statement[] array7 = new Statement[1];
						ReturnStatement returnStatement7 = (_0024_00246190_002423198 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement8 = _0024_00246190_002423198;
						TryCastExpression tryCastExpression = (_0024_00246189_002423197 = new TryCastExpression(LexicalInfo.Empty));
						TryCastExpression tryCastExpression2 = _0024_00246189_002423197;
						MethodInvocationExpression methodInvocationExpression5 = (_0024_00246188_002423196 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression6 = _0024_00246188_002423196;
						ReferenceExpression referenceExpression10 = (_0024_00246187_002423195 = new ReferenceExpression(LexicalInfo.Empty));
						string text46 = (_0024_00246187_002423195.Name = "currAction");
						Expression expression48 = (methodInvocationExpression6.Target = _0024_00246187_002423195);
						ExpressionCollection expressionCollection6 = (_0024_00246188_002423196.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024groupName_002423098)));
						Expression expression50 = (tryCastExpression2.Target = _0024_00246188_002423196);
						TypeReference typeReference8 = (_0024_00246189_002423197.Type = TypeReference.Lift(_0024actClassRef_002423128));
						Expression expression52 = (returnStatement8.Expression = _0024_00246189_002423197);
						array7[0] = Statement.Lift(_0024_00246190_002423198);
						StatementCollection statementCollection10 = (block18.Statements = StatementCollection.FromArray(array7));
						Block block20 = (method10.Body = _0024_00246191_002423199);
						Method method12 = (property5.Getter = _0024_00246192_002423200);
						TypeReference typeReference10 = (_0024_00246193_002423201.Type = TypeReference.Lift(_0024actClassRef_002423128));
						string text48 = (_0024_00246193_002423201.Name = CodeSerializer.LiftName(_0024actDataPropRef_002423194));
						flag9 = Yield(11, _0024_00246193_002423201);
						goto IL_1bc5;
					}
					case 11:
						YieldDefault(1);
						break;
					case 1:
					case 2:
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_1bc6;
				IL_1bc6:
				return (byte)result != 0;
				IL_1bc5:
				result = (flag9 ? 1 : 0);
				goto IL_1bc6;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414210_002423205.Dispose();
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
				}
			}
		}

		internal MacroStatement _0024mc_002423213;

		internal Act_methodMacro _0024self__002423214;

		public _0024ExpandGeneratorImpl_002423095(MacroStatement mc, Act_methodMacro self_)
		{
			_0024mc_002423213 = mc;
			_0024self__002423214 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002423213, _0024self__002423214);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024forAllInnerBlocks_002423215 : GenericGenerator<object[]>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object[]>, IEnumerator
		{
			internal Block _0024leadingDecls_002423216;

			internal Block _0024anonymBlock_002423217;

			internal bool _0024leadingPart_002423218;

			internal Statement _0024s_002423219;

			internal ExpressionStatement _0024stmt_002423220;

			internal MethodInvocationExpression _0024minv_002423221;

			internal ReferenceExpression _0024target_002423222;

			internal BlockExpression _0024block_002423223;

			internal IEnumerator<Statement> _0024_0024iterator_002414216_002423224;

			internal MacroStatement _0024mc_002423225;

			public _0024(MacroStatement mc)
			{
				_0024mc_002423225 = mc;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024leadingDecls_002423216 = new Block();
						_0024anonymBlock_002423217 = new Block();
						_0024leadingPart_002423218 = true;
						_0024_0024iterator_002414216_002423224 = _0024mc_002423225.Body.Statements.GetEnumerator();
						_state = 2;
						goto case 3;
					case 3:
						while (true)
						{
							if (_0024_0024iterator_002414216_002423224.MoveNext())
							{
								_0024s_002423219 = _0024_0024iterator_002414216_002423224.Current;
								if (_0024leadingPart_002423218)
								{
									if (_0024s_002423219 is DeclarationStatement)
									{
										_0024leadingDecls_002423216.Add(_0024s_002423219);
										continue;
									}
									_0024leadingPart_002423218 = false;
								}
								_0024stmt_002423220 = _0024s_002423219 as ExpressionStatement;
								if (_0024stmt_002423220 == null || _0024stmt_002423220.Expression == null)
								{
									_0024anonymBlock_002423217.Add(_0024s_002423219);
									continue;
								}
								_0024minv_002423221 = _0024stmt_002423220.Expression as MethodInvocationExpression;
								if (_0024minv_002423221 == null || ((ICollection)_0024minv_002423221.Arguments).Count == 0)
								{
									_0024anonymBlock_002423217.Add(_0024stmt_002423220);
									continue;
								}
								_0024target_002423222 = _0024minv_002423221.Target as ReferenceExpression;
								if (_0024target_002423222 == null)
								{
									_0024anonymBlock_002423217.Add(_0024stmt_002423220);
									continue;
								}
								_0024block_002423223 = _0024minv_002423221.Arguments.Last as BlockExpression;
								if (_0024block_002423223 == null)
								{
									_0024anonymBlock_002423217.Add(_0024stmt_002423220);
									continue;
								}
								if (string.IsNullOrEmpty(_0024target_002423222.Name) || _0024block_002423223.Body == null)
								{
									throw new AssertionFailedException("(not string.IsNullOrEmpty(target.Name)) and (block.Body != null)");
								}
								if (_0024block_002423223.Body.IsEmpty)
								{
									continue;
								}
								flag = Yield(3, new object[2] { _0024target_002423222.Name, _0024block_002423223.Body });
							}
							else
							{
								_state = 1;
								_0024ensure2();
								if (_0024leadingDecls_002423216.IsEmpty)
								{
									break;
								}
								flag = Yield(4, new object[2] { "leadingDecls", _0024leadingDecls_002423216 });
							}
							goto IL_02c6;
						}
						goto case 4;
					case 4:
						if (_0024anonymBlock_002423217.IsEmpty)
						{
							break;
						}
						flag = Yield(5, new object[2] { "$", _0024anonymBlock_002423217 });
						goto IL_02c6;
					case 5:
						break;
					case 1:
					case 2:
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
				goto IL_02c7;
				IL_02c7:
				return (byte)result != 0;
				IL_02c6:
				result = (flag ? 1 : 0);
				goto IL_02c7;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414216_002423224.Dispose();
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
				}
			}
		}

		internal MacroStatement _0024mc_002423226;

		public _0024forAllInnerBlocks_002423215(MacroStatement mc)
		{
			_0024mc_002423226 = mc;
		}

		public override IEnumerator<object[]> GetEnumerator()
		{
			return new _0024(_0024mc_002423226);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024emitActionSystemCode_002423227 : GenericGenerator<TypeMember>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<TypeMember>, IEnumerator
		{
			internal ClassDefinition _0024parentClass_002423228;

			internal EnumDefinition _0024_00245504_002423229;

			internal EnumMember _0024_00245505_002423230;

			internal EnumMember _0024_00245506_002423231;

			internal ReferenceExpression _0024enumRef_002423232;

			internal ReferenceExpression _0024noactEnum_002423233;

			internal ReferenceExpression _0024changeNumVar_002423234;

			internal ReferenceExpression _0024debugFlagVar_002423235;

			internal ReferenceExpression _0024currentActionIdDic_002423236;

			internal ReferenceExpression _0024coIteratorVar_002423237;

			internal ReferenceExpression _0024actTimeVar_002423238;

			internal ReferenceExpression _0024preActTimeVar_002423239;

			internal ReferenceExpression _0024realActTimeProp_002423240;

			internal ReferenceExpression _0024realActInitTimeVar_002423241;

			internal ReferenceExpression _0024actFrameVar_002423242;

			internal Block _0024progressActTimeCode_002423243;

			internal Expression _0024nowTimeVar_002423244;

			internal Expression _0024deltaTimeVar_002423245;

			internal Declaration _0024_00245507_002423246;

			internal MemberReferenceExpression _0024_00245508_002423247;

			internal ReferenceExpression _0024_00245509_002423248;

			internal ReferenceExpression _0024_00245510_002423249;

			internal BinaryExpression _0024_00245511_002423250;

			internal ReferenceExpression _0024_00245512_002423251;

			internal BinaryExpression _0024_00245513_002423252;

			internal StatementModifier _0024_00245514_002423253;

			internal ReferenceExpression _0024_00245515_002423254;

			internal BinaryExpression _0024_00245516_002423255;

			internal ExpressionStatement _0024_00245517_002423256;

			internal ReferenceExpression _0024_00245518_002423257;

			internal UnaryExpression _0024_00245519_002423258;

			internal Block _0024_00245520_002423259;

			internal ForStatement _0024_00245521_002423260;

			internal ForStatement _0024b_002423261;

			internal Field _0024_00245522_002423262;

			internal SimpleTypeReference _0024_00245523_002423263;

			internal Field _0024_00245524_002423264;

			internal SimpleTypeReference _0024_00245525_002423265;

			internal ParameterDeclaration _0024_00245526_002423266;

			internal CallableTypeReference _0024_00245527_002423267;

			internal Field _0024_00245528_002423268;

			internal SimpleTypeReference _0024_00245529_002423269;

			internal ParameterDeclaration _0024_00245530_002423270;

			internal CallableTypeReference _0024_00245531_002423271;

			internal Field _0024_00245532_002423272;

			internal SimpleTypeReference _0024_00245533_002423273;

			internal ParameterDeclaration _0024_00245534_002423274;

			internal CallableTypeReference _0024_00245535_002423275;

			internal Field _0024_00245536_002423276;

			internal SimpleTypeReference _0024_00245537_002423277;

			internal ParameterDeclaration _0024_00245538_002423278;

			internal CallableTypeReference _0024_00245539_002423279;

			internal Field _0024_00245540_002423280;

			internal SimpleTypeReference _0024_00245541_002423281;

			internal ParameterDeclaration _0024_00245542_002423282;

			internal CallableTypeReference _0024_00245543_002423283;

			internal Field _0024_00245544_002423284;

			internal SimpleTypeReference _0024_00245545_002423285;

			internal ParameterDeclaration _0024_00245546_002423286;

			internal CallableTypeReference _0024_00245547_002423287;

			internal Field _0024_00245548_002423288;

			internal SimpleTypeReference _0024_00245549_002423289;

			internal ParameterDeclaration _0024_00245550_002423290;

			internal SimpleTypeReference _0024_00245551_002423291;

			internal CallableTypeReference _0024_00245552_002423292;

			internal Field _0024_00245553_002423293;

			internal SimpleTypeReference _0024_00245554_002423294;

			internal Field _0024_00245555_002423295;

			internal SimpleTypeReference _0024_00245556_002423296;

			internal Field _0024_00245557_002423297;

			internal SimpleTypeReference _0024_00245558_002423298;

			internal Field _0024_00245559_002423299;

			internal SimpleTypeReference _0024_00245560_002423300;

			internal Field _0024_00245561_002423301;

			internal SimpleTypeReference _0024_00245562_002423302;

			internal Field _0024_00245563_002423303;

			internal MemberReferenceExpression _0024_00245564_002423304;

			internal MethodInvocationExpression _0024_00245565_002423305;

			internal ReturnStatement _0024_00245566_002423306;

			internal Block _0024_00245567_002423307;

			internal Method _0024_00245568_002423308;

			internal SimpleTypeReference _0024_00245569_002423309;

			internal Property _0024_00245570_002423310;

			internal BinaryExpression _0024_00245571_002423311;

			internal ReturnStatement _0024_00245572_002423312;

			internal Block _0024_00245573_002423313;

			internal Method _0024_00245574_002423314;

			internal SimpleTypeReference _0024_00245575_002423315;

			internal Property _0024_00245576_002423316;

			internal ClassDefinition _0024_00245577_002423317;

			internal ReferenceExpression _0024_00245578_002423318;

			internal MemberReferenceExpression _0024_00245579_002423319;

			internal MemberReferenceExpression _0024_00245580_002423320;

			internal MemberReferenceExpression _0024_00245581_002423321;

			internal SimpleTypeReference _0024_00245582_002423322;

			internal SimpleTypeReference _0024_00245583_002423323;

			internal GenericReferenceExpression _0024_00245584_002423324;

			internal MethodInvocationExpression _0024_00245585_002423325;

			internal Field _0024_00245586_002423326;

			internal ReferenceExpression _0024_00245587_002423327;

			internal MemberReferenceExpression _0024_00245588_002423328;

			internal MemberReferenceExpression _0024_00245589_002423329;

			internal MemberReferenceExpression _0024_00245590_002423330;

			internal SimpleTypeReference _0024_00245591_002423331;

			internal GenericReferenceExpression _0024_00245592_002423332;

			internal MethodInvocationExpression _0024_00245593_002423333;

			internal Field _0024_00245594_002423334;

			internal ReferenceExpression _0024_00245595_002423335;

			internal ReferenceExpression _0024_00245596_002423336;

			internal IntegerLiteralExpression _0024_00245597_002423337;

			internal MethodInvocationExpression _0024_00245598_002423338;

			internal Field _0024_00245599_002423339;

			internal SimpleTypeReference _0024_00245600_002423340;

			internal IntegerLiteralExpression _0024_00245601_002423341;

			internal Field _0024_00245602_002423342;

			internal SimpleTypeReference _0024_00245603_002423343;

			internal BoolLiteralExpression _0024_00245604_002423344;

			internal Field _0024_00245605_002423345;

			internal SimpleTypeReference _0024_00245606_002423346;

			internal ParameterDeclaration _0024_00245607_002423347;

			internal ReferenceExpression _0024_00245608_002423348;

			internal BinaryExpression _0024_00245609_002423349;

			internal Block _0024_00245610_002423350;

			internal Method _0024_00245611_002423351;

			internal SimpleTypeReference _0024_00245612_002423352;

			internal ReferenceExpression _0024_00245613_002423353;

			internal MethodInvocationExpression _0024_00245614_002423354;

			internal ReturnStatement _0024_00245615_002423355;

			internal Block _0024_00245616_002423356;

			internal Method _0024_00245617_002423357;

			internal SimpleTypeReference _0024_00245618_002423358;

			internal ReferenceExpression _0024_00245619_002423359;

			internal MethodInvocationExpression _0024_00245620_002423360;

			internal ReturnStatement _0024_00245621_002423361;

			internal Block _0024_00245622_002423362;

			internal Method _0024_00245623_002423363;

			internal SimpleTypeReference _0024_00245624_002423364;

			internal ParameterDeclaration _0024_00245625_002423365;

			internal SimpleTypeReference _0024_00245626_002423366;

			internal ReferenceExpression _0024_00245627_002423367;

			internal MemberReferenceExpression _0024_00245628_002423368;

			internal ReferenceExpression _0024_00245629_002423369;

			internal MethodInvocationExpression _0024_00245630_002423370;

			internal UnaryExpression _0024_00245631_002423371;

			internal MemberReferenceExpression _0024_00245632_002423372;

			internal ReferenceExpression _0024_00245633_002423373;

			internal MethodInvocationExpression _0024_00245634_002423374;

			internal BinaryExpression _0024_00245635_002423375;

			internal ReferenceExpression _0024_00245636_002423376;

			internal Slice _0024_00245637_002423377;

			internal SlicingExpression _0024_00245638_002423378;

			internal ReturnStatement _0024_00245639_002423379;

			internal Block _0024_00245640_002423380;

			internal ReturnStatement _0024_00245641_002423381;

			internal Block _0024_00245642_002423382;

			internal IfStatement _0024_00245643_002423383;

			internal Block _0024_00245644_002423384;

			internal Method _0024_00245645_002423385;

			internal SimpleTypeReference _0024_00245646_002423386;

			internal ParameterDeclaration _0024_00245647_002423387;

			internal SimpleTypeReference _0024_00245648_002423388;

			internal MemberReferenceExpression _0024_00245649_002423389;

			internal ReferenceExpression _0024_00245650_002423390;

			internal MethodInvocationExpression _0024_00245651_002423391;

			internal ReferenceExpression _0024_00245652_002423392;

			internal Slice _0024_00245653_002423393;

			internal SlicingExpression _0024_00245654_002423394;

			internal ReturnStatement _0024_00245655_002423395;

			internal Block _0024_00245656_002423396;

			internal ReturnStatement _0024_00245657_002423397;

			internal Block _0024_00245658_002423398;

			internal IfStatement _0024_00245659_002423399;

			internal Block _0024_00245660_002423400;

			internal Method _0024_00245661_002423401;

			internal SimpleTypeReference _0024_00245662_002423402;

			internal ParameterDeclaration _0024_00245663_002423403;

			internal SimpleTypeReference _0024_00245664_002423404;

			internal MemberReferenceExpression _0024_00245665_002423405;

			internal ReferenceExpression _0024_00245666_002423406;

			internal MethodInvocationExpression _0024_00245667_002423407;

			internal ReferenceExpression _0024_00245668_002423408;

			internal Slice _0024_00245669_002423409;

			internal SlicingExpression _0024_00245670_002423410;

			internal ReturnStatement _0024_00245671_002423411;

			internal Block _0024_00245672_002423412;

			internal DoubleLiteralExpression _0024_00245673_002423413;

			internal ReturnStatement _0024_00245674_002423414;

			internal Block _0024_00245675_002423415;

			internal IfStatement _0024_00245676_002423416;

			internal Block _0024_00245677_002423417;

			internal Method _0024_00245678_002423418;

			internal SimpleTypeReference _0024_00245679_002423419;

			internal ParameterDeclaration _0024_00245680_002423420;

			internal SimpleTypeReference _0024_00245681_002423421;

			internal MemberReferenceExpression _0024_00245682_002423422;

			internal ReferenceExpression _0024_00245683_002423423;

			internal MethodInvocationExpression _0024_00245684_002423424;

			internal ReferenceExpression _0024_00245685_002423425;

			internal Slice _0024_00245686_002423426;

			internal SlicingExpression _0024_00245687_002423427;

			internal ReturnStatement _0024_00245688_002423428;

			internal Block _0024_00245689_002423429;

			internal DoubleLiteralExpression _0024_00245690_002423430;

			internal ReturnStatement _0024_00245691_002423431;

			internal Block _0024_00245692_002423432;

			internal IfStatement _0024_00245693_002423433;

			internal Block _0024_00245694_002423434;

			internal Method _0024_00245695_002423435;

			internal SimpleTypeReference _0024_00245696_002423436;

			internal ParameterDeclaration _0024_00245697_002423437;

			internal SimpleTypeReference _0024_00245698_002423438;

			internal MemberReferenceExpression _0024_00245699_002423439;

			internal ReferenceExpression _0024_00245700_002423440;

			internal MethodInvocationExpression _0024_00245701_002423441;

			internal ReferenceExpression _0024_00245702_002423442;

			internal Slice _0024_00245703_002423443;

			internal SlicingExpression _0024_00245704_002423444;

			internal ReturnStatement _0024_00245705_002423445;

			internal Block _0024_00245706_002423446;

			internal DoubleLiteralExpression _0024_00245707_002423447;

			internal ReturnStatement _0024_00245708_002423448;

			internal Block _0024_00245709_002423449;

			internal IfStatement _0024_00245710_002423450;

			internal Block _0024_00245711_002423451;

			internal Method _0024_00245712_002423452;

			internal SimpleTypeReference _0024_00245713_002423453;

			internal ParameterDeclaration _0024_00245714_002423454;

			internal SimpleTypeReference _0024_00245715_002423455;

			internal Declaration _0024_00245716_002423456;

			internal MemberReferenceExpression _0024_00245717_002423457;

			internal ReferenceExpression _0024_00245718_002423458;

			internal ReferenceExpression _0024_00245719_002423459;

			internal BinaryExpression _0024_00245720_002423460;

			internal StatementModifier _0024_00245721_002423461;

			internal BoolLiteralExpression _0024_00245722_002423462;

			internal ReturnStatement _0024_00245723_002423463;

			internal Block _0024_00245724_002423464;

			internal ForStatement _0024_00245725_002423465;

			internal BoolLiteralExpression _0024_00245726_002423466;

			internal ReturnStatement _0024_00245727_002423467;

			internal Block _0024_00245728_002423468;

			internal Method _0024_00245729_002423469;

			internal SimpleTypeReference _0024_00245730_002423470;

			internal ParameterDeclaration _0024_00245731_002423471;

			internal SimpleTypeReference _0024_00245732_002423472;

			internal ReferenceExpression _0024_00245733_002423473;

			internal BinaryExpression _0024_00245734_002423474;

			internal StatementModifier _0024_00245735_002423475;

			internal BoolLiteralExpression _0024_00245736_002423476;

			internal ReturnStatement _0024_00245737_002423477;

			internal ReferenceExpression _0024_00245738_002423478;

			internal MemberReferenceExpression _0024_00245739_002423479;

			internal ReferenceExpression _0024_00245740_002423480;

			internal MethodInvocationExpression _0024_00245741_002423481;

			internal StatementModifier _0024_00245742_002423482;

			internal BoolLiteralExpression _0024_00245743_002423483;

			internal ReturnStatement _0024_00245744_002423484;

			internal MemberReferenceExpression _0024_00245745_002423485;

			internal ReferenceExpression _0024_00245746_002423486;

			internal MethodInvocationExpression _0024_00245747_002423487;

			internal UnaryExpression _0024_00245748_002423488;

			internal StatementModifier _0024_00245749_002423489;

			internal BoolLiteralExpression _0024_00245750_002423490;

			internal ReturnStatement _0024_00245751_002423491;

			internal ReferenceExpression _0024_00245752_002423492;

			internal ReferenceExpression _0024_00245753_002423493;

			internal Slice _0024_00245754_002423494;

			internal SlicingExpression _0024_00245755_002423495;

			internal BinaryExpression _0024_00245756_002423496;

			internal ReturnStatement _0024_00245757_002423497;

			internal Block _0024_00245758_002423498;

			internal Method _0024_00245759_002423499;

			internal SimpleTypeReference _0024_00245760_002423500;

			internal ParameterDeclaration _0024_00245761_002423501;

			internal SimpleTypeReference _0024_00245762_002423502;

			internal IntegerLiteralExpression _0024_00245763_002423503;

			internal ReferenceExpression _0024_00245764_002423504;

			internal BinaryExpression _0024_00245765_002423505;

			internal ReferenceExpression _0024_00245766_002423506;

			internal ReferenceExpression _0024_00245767_002423507;

			internal MemberReferenceExpression _0024_00245768_002423508;

			internal BinaryExpression _0024_00245769_002423509;

			internal BinaryExpression _0024_00245770_002423510;

			internal ReturnStatement _0024_00245771_002423511;

			internal Block _0024_00245772_002423512;

			internal Method _0024_00245773_002423513;

			internal SimpleTypeReference _0024_00245774_002423514;

			internal ParameterDeclaration _0024_00245775_002423515;

			internal ReferenceExpression _0024_00245776_002423516;

			internal BinaryExpression _0024_00245777_002423517;

			internal StatementModifier _0024_00245778_002423518;

			internal ReturnStatement _0024_00245779_002423519;

			internal ReferenceExpression _0024_00245780_002423520;

			internal MemberReferenceExpression _0024_00245781_002423521;

			internal ReferenceExpression _0024_00245782_002423522;

			internal MethodInvocationExpression _0024_00245783_002423523;

			internal UnaryExpression _0024_00245784_002423524;

			internal MacroStatement _0024_00245785_002423525;

			internal ReferenceExpression _0024_00245786_002423526;

			internal Slice _0024_00245787_002423527;

			internal SlicingExpression _0024_00245788_002423528;

			internal ReferenceExpression _0024_00245789_002423529;

			internal BinaryExpression _0024_00245790_002423530;

			internal ReferenceExpression _0024_00245791_002423531;

			internal Slice _0024_00245792_002423532;

			internal SlicingExpression _0024_00245793_002423533;

			internal ReferenceExpression _0024_00245794_002423534;

			internal BinaryExpression _0024_00245795_002423535;

			internal ReferenceExpression _0024_00245796_002423536;

			internal BinaryExpression _0024_00245797_002423537;

			internal Block _0024_00245798_002423538;

			internal Method _0024_00245799_002423539;

			internal SimpleTypeReference _0024_00245800_002423540;

			internal ParameterDeclaration _0024_00245801_002423541;

			internal UnaryExpression _0024_00245802_002423542;

			internal BinaryExpression _0024_00245803_002423543;

			internal StringLiteralExpression _0024_00245804_002423544;

			internal BinaryExpression _0024_00245805_002423545;

			internal StringLiteralExpression _0024_00245806_002423546;

			internal BinaryExpression _0024_00245807_002423547;

			internal RaiseStatement _0024_00245808_002423548;

			internal Block _0024_00245809_002423549;

			internal IfStatement _0024_00245810_002423550;

			internal ReferenceExpression _0024_00245811_002423551;

			internal ReferenceExpression _0024_00245812_002423552;

			internal ReferenceExpression _0024_00245813_002423553;

			internal MethodInvocationExpression _0024_00245814_002423554;

			internal BinaryExpression _0024_00245815_002423555;

			internal ReferenceExpression _0024_00245816_002423556;

			internal BinaryExpression _0024_00245817_002423557;

			internal ReferenceExpression _0024_00245818_002423558;

			internal ReferenceExpression _0024_00245819_002423559;

			internal BinaryExpression _0024_00245820_002423560;

			internal BinaryExpression _0024_00245821_002423561;

			internal StatementModifier _0024_00245822_002423562;

			internal ReturnStatement _0024_00245823_002423563;

			internal ReferenceExpression _0024_00245824_002423564;

			internal BinaryExpression _0024_00245825_002423565;

			internal ReferenceExpression _0024_00245826_002423566;

			internal StringLiteralExpression _0024_00245827_002423567;

			internal ReferenceExpression _0024_00245828_002423568;

			internal MemberReferenceExpression _0024_00245829_002423569;

			internal StringLiteralExpression _0024_00245830_002423570;

			internal ReferenceExpression _0024_00245831_002423571;

			internal StringLiteralExpression _0024_00245832_002423572;

			internal ExpressionInterpolationExpression _0024_00245833_002423573;

			internal MethodInvocationExpression _0024_00245834_002423574;

			internal Block _0024_00245835_002423575;

			internal ReferenceExpression _0024_00245836_002423576;

			internal StringLiteralExpression _0024_00245837_002423577;

			internal ReferenceExpression _0024_00245838_002423578;

			internal MemberReferenceExpression _0024_00245839_002423579;

			internal StringLiteralExpression _0024_00245840_002423580;

			internal ReferenceExpression _0024_00245841_002423581;

			internal MemberReferenceExpression _0024_00245842_002423582;

			internal StringLiteralExpression _0024_00245843_002423583;

			internal ReferenceExpression _0024_00245844_002423584;

			internal StringLiteralExpression _0024_00245845_002423585;

			internal ExpressionInterpolationExpression _0024_00245846_002423586;

			internal MethodInvocationExpression _0024_00245847_002423587;

			internal Block _0024_00245848_002423588;

			internal IfStatement _0024_00245849_002423589;

			internal Block _0024_00245850_002423590;

			internal IfStatement _0024_00245851_002423591;

			internal ReferenceExpression _0024_00245852_002423592;

			internal BinaryExpression _0024_00245853_002423593;

			internal ReferenceExpression _0024_00245854_002423594;

			internal BinaryExpression _0024_00245855_002423595;

			internal BinaryExpression _0024_00245856_002423596;

			internal ReferenceExpression _0024_00245857_002423597;

			internal ReferenceExpression _0024_00245858_002423598;

			internal MethodInvocationExpression _0024_00245859_002423599;

			internal Block _0024_00245860_002423600;

			internal IfStatement _0024_00245861_002423601;

			internal ReferenceExpression _0024_00245862_002423602;

			internal BinaryExpression _0024_00245863_002423603;

			internal ReferenceExpression _0024_00245864_002423604;

			internal ReferenceExpression _0024_00245865_002423605;

			internal MethodInvocationExpression _0024_00245866_002423606;

			internal UnaryExpression _0024_00245867_002423607;

			internal BinaryExpression _0024_00245868_002423608;

			internal StatementModifier _0024_00245869_002423609;

			internal ReturnStatement _0024_00245870_002423610;

			internal ReferenceExpression _0024_00245871_002423611;

			internal ReferenceExpression _0024_00245872_002423612;

			internal MethodInvocationExpression _0024_00245873_002423613;

			internal ReferenceExpression _0024_00245874_002423614;

			internal BinaryExpression _0024_00245875_002423615;

			internal ReferenceExpression _0024_00245876_002423616;

			internal ReferenceExpression _0024_00245877_002423617;

			internal MethodInvocationExpression _0024_00245878_002423618;

			internal Block _0024_00245879_002423619;

			internal IfStatement _0024_00245880_002423620;

			internal ReferenceExpression _0024_00245881_002423621;

			internal ReferenceExpression _0024_00245882_002423622;

			internal MethodInvocationExpression _0024_00245883_002423623;

			internal UnaryExpression _0024_00245884_002423624;

			internal StatementModifier _0024_00245885_002423625;

			internal ReturnStatement _0024_00245886_002423626;

			internal ReferenceExpression _0024_00245887_002423627;

			internal BinaryExpression _0024_00245888_002423628;

			internal ReferenceExpression _0024_00245889_002423629;

			internal ReferenceExpression _0024_00245890_002423630;

			internal ReferenceExpression _0024_00245891_002423631;

			internal MethodInvocationExpression _0024_00245892_002423632;

			internal BinaryExpression _0024_00245893_002423633;

			internal Block _0024_00245894_002423634;

			internal IfStatement _0024_00245895_002423635;

			internal Block _0024_00245896_002423636;

			internal Method _0024_00245897_002423637;

			internal SimpleTypeReference _0024_00245898_002423638;

			internal ParameterDeclaration _0024_00245899_002423639;

			internal ReferenceExpression _0024_00245900_002423640;

			internal ReferenceExpression _0024_00245901_002423641;

			internal ReferenceExpression _0024_00245902_002423642;

			internal MethodInvocationExpression _0024_00245903_002423643;

			internal BinaryExpression _0024_00245904_002423644;

			internal ReferenceExpression _0024_00245905_002423645;

			internal BinaryExpression _0024_00245906_002423646;

			internal StatementModifier _0024_00245907_002423647;

			internal ReferenceExpression _0024_00245908_002423648;

			internal ReferenceExpression _0024_00245909_002423649;

			internal MethodInvocationExpression _0024_00245910_002423650;

			internal ExpressionStatement _0024_00245911_002423651;

			internal Block _0024_00245912_002423652;

			internal Method _0024_00245913_002423653;

			internal SimpleTypeReference _0024_00245914_002423654;

			internal SimpleTypeReference _0024_00245915_002423655;

			internal Declaration _0024_00245916_002423656;

			internal IntegerLiteralExpression _0024_00245917_002423657;

			internal DeclarationStatement _0024_00245918_002423658;

			internal Declaration _0024_00245919_002423659;

			internal MemberReferenceExpression _0024_00245920_002423660;

			internal ReferenceExpression _0024_00245921_002423661;

			internal ReferenceExpression _0024_00245922_002423662;

			internal UnaryExpression _0024_00245923_002423663;

			internal Slice _0024_00245924_002423664;

			internal SlicingExpression _0024_00245925_002423665;

			internal ReferenceExpression _0024_00245926_002423666;

			internal BinaryExpression _0024_00245927_002423667;

			internal Block _0024_00245928_002423668;

			internal ForStatement _0024_00245929_002423669;

			internal ReferenceExpression _0024_00245930_002423670;

			internal ReturnStatement _0024_00245931_002423671;

			internal Block _0024_00245932_002423672;

			internal Method _0024_00245933_002423673;

			internal SimpleTypeReference _0024_00245934_002423674;

			internal Declaration _0024_00245935_002423675;

			internal ReferenceExpression _0024_00245936_002423676;

			internal MethodInvocationExpression _0024_00245937_002423677;

			internal DeclarationStatement _0024_00245938_002423678;

			internal IntegerLiteralExpression _0024_00245939_002423679;

			internal BinaryExpression _0024_00245940_002423680;

			internal Declaration _0024_00245941_002423681;

			internal ReferenceExpression _0024_00245942_002423682;

			internal ReferenceExpression _0024_00245943_002423683;

			internal MethodInvocationExpression _0024_00245944_002423684;

			internal ReferenceExpression _0024_00245945_002423685;

			internal ReferenceExpression _0024_00245946_002423686;

			internal ReferenceExpression _0024_00245947_002423687;

			internal Slice _0024_00245948_002423688;

			internal SlicingExpression _0024_00245949_002423689;

			internal BinaryExpression _0024_00245950_002423690;

			internal ReferenceExpression _0024_00245951_002423691;

			internal BinaryExpression _0024_00245952_002423692;

			internal ReferenceExpression _0024_00245953_002423693;

			internal ReferenceExpression _0024_00245954_002423694;

			internal MethodInvocationExpression _0024_00245955_002423695;

			internal Block _0024_00245956_002423696;

			internal IfStatement _0024_00245957_002423697;

			internal ReferenceExpression _0024_00245958_002423698;

			internal ReferenceExpression _0024_00245959_002423699;

			internal MethodInvocationExpression _0024_00245960_002423700;

			internal ReferenceExpression _0024_00245961_002423701;

			internal BinaryExpression _0024_00245962_002423702;

			internal BinaryExpression _0024_00245963_002423703;

			internal ReferenceExpression _0024_00245964_002423704;

			internal MemberReferenceExpression _0024_00245965_002423705;

			internal MethodInvocationExpression _0024_00245966_002423706;

			internal UnaryExpression _0024_00245967_002423707;

			internal ReferenceExpression _0024_00245968_002423708;

			internal BinaryExpression _0024_00245969_002423709;

			internal Block _0024_00245970_002423710;

			internal IfStatement _0024_00245971_002423711;

			internal Block _0024_00245972_002423712;

			internal IfStatement _0024_00245973_002423713;

			internal Block _0024_00245974_002423714;

			internal ForStatement _0024_00245975_002423715;

			internal Block _0024_00245976_002423716;

			internal Method _0024_00245977_002423717;

			internal SimpleTypeReference _0024_00245978_002423718;

			internal Declaration _0024_00245979_002423719;

			internal ReferenceExpression _0024_00245980_002423720;

			internal MethodInvocationExpression _0024_00245981_002423721;

			internal DeclarationStatement _0024_00245982_002423722;

			internal IntegerLiteralExpression _0024_00245983_002423723;

			internal BinaryExpression _0024_00245984_002423724;

			internal Declaration _0024_00245985_002423725;

			internal ReferenceExpression _0024_00245986_002423726;

			internal ReferenceExpression _0024_00245987_002423727;

			internal MethodInvocationExpression _0024_00245988_002423728;

			internal ReferenceExpression _0024_00245989_002423729;

			internal ReferenceExpression _0024_00245990_002423730;

			internal ReferenceExpression _0024_00245991_002423731;

			internal Slice _0024_00245992_002423732;

			internal SlicingExpression _0024_00245993_002423733;

			internal BinaryExpression _0024_00245994_002423734;

			internal ReferenceExpression _0024_00245995_002423735;

			internal BinaryExpression _0024_00245996_002423736;

			internal ReferenceExpression _0024_00245997_002423737;

			internal ReferenceExpression _0024_00245998_002423738;

			internal MethodInvocationExpression _0024_00245999_002423739;

			internal Block _0024_00246000_002423740;

			internal IfStatement _0024_00246001_002423741;

			internal Block _0024_00246002_002423742;

			internal ForStatement _0024_00246003_002423743;

			internal Block _0024_00246004_002423744;

			internal Method _0024_00246005_002423745;

			internal IntegerLiteralExpression _0024_00246006_002423746;

			internal BinaryExpression _0024_00246007_002423747;

			internal ReferenceExpression _0024_00246008_002423748;

			internal ReferenceExpression _0024_00246009_002423749;

			internal MemberReferenceExpression _0024_00246010_002423750;

			internal MethodInvocationExpression _0024_00246011_002423751;

			internal BinaryExpression _0024_00246012_002423752;

			internal Declaration _0024_00246013_002423753;

			internal ReferenceExpression _0024_00246014_002423754;

			internal ReferenceExpression _0024_00246015_002423755;

			internal ReferenceExpression _0024_00246016_002423756;

			internal Slice _0024_00246017_002423757;

			internal SlicingExpression _0024_00246018_002423758;

			internal BinaryExpression _0024_00246019_002423759;

			internal ReferenceExpression _0024_00246020_002423760;

			internal BinaryExpression _0024_00246021_002423761;

			internal ReferenceExpression _0024_00246022_002423762;

			internal ReferenceExpression _0024_00246023_002423763;

			internal MethodInvocationExpression _0024_00246024_002423764;

			internal Block _0024_00246025_002423765;

			internal IfStatement _0024_00246026_002423766;

			internal Block _0024_00246027_002423767;

			internal ForStatement _0024_00246028_002423768;

			internal ReferenceExpression _0024_00246029_002423769;

			internal IntegerLiteralExpression _0024_00246030_002423770;

			internal BinaryExpression _0024_00246031_002423771;

			internal Declaration _0024_00246032_002423772;

			internal MemberReferenceExpression _0024_00246033_002423773;

			internal ReferenceExpression _0024_00246034_002423774;

			internal MemberReferenceExpression _0024_00246035_002423775;

			internal ReferenceExpression _0024_00246036_002423776;

			internal IntegerLiteralExpression _0024_00246037_002423777;

			internal ReferenceExpression _0024_00246038_002423778;

			internal IntegerLiteralExpression _0024_00246039_002423779;

			internal IntegerLiteralExpression _0024_00246040_002423780;

			internal MethodInvocationExpression _0024_00246041_002423781;

			internal StringLiteralExpression _0024_00246042_002423782;

			internal ReferenceExpression _0024_00246043_002423783;

			internal BinaryExpression _0024_00246044_002423784;

			internal StringLiteralExpression _0024_00246045_002423785;

			internal BinaryExpression _0024_00246046_002423786;

			internal ReferenceExpression _0024_00246047_002423787;

			internal BinaryExpression _0024_00246048_002423788;

			internal StringLiteralExpression _0024_00246049_002423789;

			internal BinaryExpression _0024_00246050_002423790;

			internal ReferenceExpression _0024_00246051_002423791;

			internal BinaryExpression _0024_00246052_002423792;

			internal StringLiteralExpression _0024_00246053_002423793;

			internal BinaryExpression _0024_00246054_002423794;

			internal ReferenceExpression _0024_00246055_002423795;

			internal BinaryExpression _0024_00246056_002423796;

			internal MethodInvocationExpression _0024_00246057_002423797;

			internal ReferenceExpression _0024_00246058_002423798;

			internal IntegerLiteralExpression _0024_00246059_002423799;

			internal BinaryExpression _0024_00246060_002423800;

			internal Block _0024_00246061_002423801;

			internal ForStatement _0024_00246062_002423802;

			internal Block _0024_00246063_002423803;

			internal IfStatement _0024_00246064_002423804;

			internal Block _0024_00246065_002423805;

			internal Method _0024_00246066_002423806;

			internal IntegerLiteralExpression _0024_00246067_002423807;

			internal BinaryExpression _0024_00246068_002423808;

			internal ReferenceExpression _0024_00246069_002423809;

			internal ReferenceExpression _0024_00246070_002423810;

			internal MemberReferenceExpression _0024_00246071_002423811;

			internal MethodInvocationExpression _0024_00246072_002423812;

			internal BinaryExpression _0024_00246073_002423813;

			internal Declaration _0024_00246074_002423814;

			internal ReferenceExpression _0024_00246075_002423815;

			internal ReferenceExpression _0024_00246076_002423816;

			internal ReferenceExpression _0024_00246077_002423817;

			internal Slice _0024_00246078_002423818;

			internal SlicingExpression _0024_00246079_002423819;

			internal BinaryExpression _0024_00246080_002423820;

			internal ReferenceExpression _0024_00246081_002423821;

			internal BinaryExpression _0024_00246082_002423822;

			internal ReferenceExpression _0024_00246083_002423823;

			internal ReferenceExpression _0024_00246084_002423824;

			internal MethodInvocationExpression _0024_00246085_002423825;

			internal Block _0024_00246086_002423826;

			internal IfStatement _0024_00246087_002423827;

			internal Block _0024_00246088_002423828;

			internal ForStatement _0024_00246089_002423829;

			internal Block _0024_00246090_002423830;

			internal Method _0024_00246091_002423831;

			internal Module _0024_00246092_002423832;

			internal Module _0024module_002423833;

			internal TypeMember _0024___item_002423834;

			internal SimpleTypeReference _0024_00246093_002423835;

			internal ParameterDeclaration _0024_00246094_002423836;

			internal SimpleTypeReference _0024_00246095_002423837;

			internal ReferenceExpression _0024_00246096_002423838;

			internal ReferenceExpression _0024_00246097_002423839;

			internal MethodInvocationExpression _0024_00246098_002423840;

			internal UnaryExpression _0024_00246099_002423841;

			internal StringLiteralExpression _0024_00246100_002423842;

			internal BinaryExpression _0024_00246101_002423843;

			internal StringLiteralExpression _0024_00246102_002423844;

			internal BinaryExpression _0024_00246103_002423845;

			internal ReferenceExpression _0024_00246104_002423846;

			internal BinaryExpression _0024_00246105_002423847;

			internal RaiseStatement _0024_00246106_002423848;

			internal Block _0024_00246107_002423849;

			internal IfStatement _0024_00246108_002423850;

			internal Block _0024_00246109_002423851;

			internal Method _0024_00246110_002423852;

			internal Method _0024enumDispatchMethod_002423853;

			internal Expression[] _0024_002414217_002423854;

			internal IEnumerator<TypeMember> _0024_0024iterator_002414218_002423855;

			internal Boo.Lang.Compiler.Ast.Node _0024mc_002423856;

			internal string _0024enumName_002423857;

			internal string _0024enumNumName_002423858;

			internal Act_methodMacro _0024self__002423859;

			public _0024(Boo.Lang.Compiler.Ast.Node mc, string enumName, string enumNumName, Act_methodMacro self_)
			{
				_0024mc_002423856 = mc;
				_0024enumName_002423857 = enumName;
				_0024enumNumName_002423858 = enumNumName;
				_0024self__002423859 = self_;
			}

			public override bool MoveNext()
			{
				bool flag191;
				try
				{
					switch (_state)
					{
					default:
					{
						if (_0024mc_002423856 == null || string.IsNullOrEmpty(_0024enumName_002423857))
						{
							throw new AssertionFailedException("(mc != null) and (not string.IsNullOrEmpty(enumName))");
						}
						_0024parentClass_002423228 = _0024self__002423859.enclosingClass(_0024mc_002423856);
						if (_0024parentClass_002423228 == null)
						{
							throw new AssertionFailedException("parentClass != null");
						}
						if (RuntimeServices.ToBool(_0024parentClass_002423228["emit_system_code"]))
						{
							Act_methodMacro act_methodMacro = _0024self__002423859;
							object obj = _0024parentClass_002423228["actionEnumDef"];
							if (!(obj is EnumDefinition))
							{
								obj = RuntimeServices.Coerce(obj, typeof(EnumDefinition));
							}
							act_methodMacro.actionEnumDef = (EnumDefinition)obj;
							Act_methodMacro act_methodMacro2 = _0024self__002423859;
							object obj2 = _0024parentClass_002423228["actionIdName"];
							if (!(obj2 is ReferenceExpression))
							{
								obj2 = RuntimeServices.Coerce(obj2, typeof(ReferenceExpression));
							}
							act_methodMacro2.actionIdName = (ReferenceExpression)obj2;
							Act_methodMacro act_methodMacro3 = _0024self__002423859;
							object obj3 = _0024parentClass_002423228["actionGroupName"];
							if (!(obj3 is ReferenceExpression))
							{
								obj3 = RuntimeServices.Coerce(obj3, typeof(ReferenceExpression));
							}
							act_methodMacro3.actionGroupName = (ReferenceExpression)obj3;
							Act_methodMacro act_methodMacro4 = _0024self__002423859;
							object obj4 = _0024parentClass_002423228["actionInit"];
							if (!(obj4 is ReferenceExpression))
							{
								obj4 = RuntimeServices.Coerce(obj4, typeof(ReferenceExpression));
							}
							act_methodMacro4.actionInit = (ReferenceExpression)obj4;
							Act_methodMacro act_methodMacro5 = _0024self__002423859;
							object obj5 = _0024parentClass_002423228["actionExit"];
							if (!(obj5 is ReferenceExpression))
							{
								obj5 = RuntimeServices.Coerce(obj5, typeof(ReferenceExpression));
							}
							act_methodMacro5.actionExit = (ReferenceExpression)obj5;
							Act_methodMacro act_methodMacro6 = _0024self__002423859;
							object obj6 = _0024parentClass_002423228["actionUpdate"];
							if (!(obj6 is ReferenceExpression))
							{
								obj6 = RuntimeServices.Coerce(obj6, typeof(ReferenceExpression));
							}
							act_methodMacro6.actionUpdate = (ReferenceExpression)obj6;
							Act_methodMacro act_methodMacro7 = _0024self__002423859;
							object obj7 = _0024parentClass_002423228["actionFixedUpdate"];
							if (!(obj7 is ReferenceExpression))
							{
								obj7 = RuntimeServices.Coerce(obj7, typeof(ReferenceExpression));
							}
							act_methodMacro7.actionFixedUpdate = (ReferenceExpression)obj7;
							Act_methodMacro act_methodMacro8 = _0024self__002423859;
							object obj8 = _0024parentClass_002423228["actionOnGUI"];
							if (!(obj8 is ReferenceExpression))
							{
								obj8 = RuntimeServices.Coerce(obj8, typeof(ReferenceExpression));
							}
							act_methodMacro8.actionOnGUI = (ReferenceExpression)obj8;
							Act_methodMacro act_methodMacro9 = _0024self__002423859;
							object obj9 = _0024parentClass_002423228["actionLateUpdate"];
							if (!(obj9 is ReferenceExpression))
							{
								obj9 = RuntimeServices.Coerce(obj9, typeof(ReferenceExpression));
							}
							act_methodMacro9.actionLateUpdate = (ReferenceExpression)obj9;
							Act_methodMacro act_methodMacro10 = _0024self__002423859;
							object obj10 = _0024parentClass_002423228["actionCoroutine"];
							if (!(obj10 is ReferenceExpression))
							{
								obj10 = RuntimeServices.Coerce(obj10, typeof(ReferenceExpression));
							}
							act_methodMacro10.actionCoroutine = (ReferenceExpression)obj10;
							Act_methodMacro act_methodMacro11 = _0024self__002423859;
							object obj11 = _0024parentClass_002423228["actionNameSet"];
							if (!(obj11 is HashSet<string>))
							{
								obj11 = RuntimeServices.Coerce(obj11, typeof(HashSet<string>));
							}
							act_methodMacro11.actionNameSet = (HashSet<string>)obj11;
							Act_methodMacro act_methodMacro12 = _0024self__002423859;
							object obj12 = _0024parentClass_002423228["actionGroupSet"];
							if (!(obj12 is HashSet<string>))
							{
								obj12 = RuntimeServices.Coerce(obj12, typeof(HashSet<string>));
							}
							act_methodMacro12.actionGroupSet = (HashSet<string>)obj12;
							Act_methodMacro act_methodMacro13 = _0024self__002423859;
							object obj13 = _0024parentClass_002423228["createDispatchBlock"];
							if (!(obj13 is Block))
							{
								obj13 = RuntimeServices.Coerce(obj13, typeof(Block));
							}
							act_methodMacro13.createDispatchBlock = (Block)obj13;
							Act_methodMacro act_methodMacro14 = _0024self__002423859;
							object obj14 = _0024parentClass_002423228["currentActionDic"];
							if (!(obj14 is ReferenceExpression))
							{
								obj14 = RuntimeServices.Coerce(obj14, typeof(ReferenceExpression));
							}
							act_methodMacro14.currentActionDic = (ReferenceExpression)obj14;
							break;
						}
						_0024parentClass_002423228["emit_system_code"] = true;
						_0024self__002423859.actionIdName = _0024self__002423859.tmpVar();
						_0024self__002423859.actionGroupName = _0024self__002423859.tmpVar();
						_0024self__002423859.actionInit = _0024self__002423859.tmpVar();
						_0024self__002423859.actionExit = _0024self__002423859.tmpVar();
						_0024self__002423859.actionUpdate = _0024self__002423859.tmpVar();
						_0024self__002423859.actionFixedUpdate = _0024self__002423859.tmpVar();
						_0024self__002423859.actionOnGUI = _0024self__002423859.tmpVar();
						_0024self__002423859.actionLateUpdate = _0024self__002423859.tmpVar();
						_0024self__002423859.actionCoroutine = _0024self__002423859.tmpVar();
						_0024self__002423859.actionNameSet = new HashSet<string>();
						_0024self__002423859.actionGroupSet = new HashSet<string>();
						_0024self__002423859.currentActionDic = _0024self__002423859.tmpVar();
						_0024parentClass_002423228["actionIdName"] = _0024self__002423859.actionIdName;
						_0024parentClass_002423228["actionGroupName"] = _0024self__002423859.actionGroupName;
						_0024parentClass_002423228["actionInit"] = _0024self__002423859.actionInit;
						_0024parentClass_002423228["actionExit"] = _0024self__002423859.actionExit;
						_0024parentClass_002423228["actionUpdate"] = _0024self__002423859.actionUpdate;
						_0024parentClass_002423228["actionFixedUpdate"] = _0024self__002423859.actionFixedUpdate;
						_0024parentClass_002423228["actionOnGUI"] = _0024self__002423859.actionOnGUI;
						_0024parentClass_002423228["actionLateUpdate"] = _0024self__002423859.actionLateUpdate;
						_0024parentClass_002423228["actionCoroutine"] = _0024self__002423859.actionCoroutine;
						_0024parentClass_002423228["actionNameSet"] = _0024self__002423859.actionNameSet;
						_0024parentClass_002423228["actionGroupSet"] = _0024self__002423859.actionGroupSet;
						_0024parentClass_002423228["currentActionDic"] = _0024self__002423859.currentActionDic;
						_0024parentClass_002423228 = _0024self__002423859.enclosingClass(_0024mc_002423856);
						Act_methodMacro act_methodMacro15 = _0024self__002423859;
						EnumDefinition enumDefinition = (_0024_00245504_002423229 = new EnumDefinition());
						string text2 = (_0024_00245504_002423229.Name = _0024enumName_002423857);
						act_methodMacro15.actionEnumDef = _0024_00245504_002423229;
						TypeMemberCollection members = _0024self__002423859.actionEnumDef.Members;
						EnumMember enumMember = (_0024_00245505_002423230 = new EnumMember());
						string text4 = (_0024_00245505_002423230.Name = _0024enumNumName_002423858);
						members.Add(_0024_00245505_002423230);
						TypeMemberCollection members2 = _0024self__002423859.actionEnumDef.Members;
						EnumMember enumMember2 = (_0024_00245506_002423231 = new EnumMember());
						string text6 = (_0024_00245506_002423231.Name = "_noaction_");
						members2.Add(_0024_00245506_002423231);
						_0024parentClass_002423228.Members.Add(_0024self__002423859.actionEnumDef);
						_0024parentClass_002423228["actionEnumDef"] = _0024self__002423859.actionEnumDef;
						_0024enumRef_002423232 = new ReferenceExpression(_0024enumName_002423857);
						_0024noactEnum_002423233 = _0024self__002423859.refLift("ActionEnum." + "_noaction_");
						_0024changeNumVar_002423234 = _0024self__002423859.tmpVar();
						_0024debugFlagVar_002423235 = new ReferenceExpression("actionDebugFlag");
						_0024currentActionIdDic_002423236 = _0024self__002423859.tmpVar();
						_0024coIteratorVar_002423237 = _0024self__002423859.tmpVar();
						_0024actTimeVar_002423238 = new ReferenceExpression("actionTime");
						_0024preActTimeVar_002423239 = new ReferenceExpression("preActionTime");
						_0024realActTimeProp_002423240 = new ReferenceExpression("realActionTime");
						_0024realActInitTimeVar_002423241 = new ReferenceExpression("realActionTimeInit");
						_0024actFrameVar_002423242 = new ReferenceExpression("actionFrame");
						_0024progressActTimeCode_002423243 = new Block();
						_0024_002414217_002423854 = _0024self__002423859.timeVars();
						_0024nowTimeVar_002423244 = _0024_002414217_002423854[0];
						_0024deltaTimeVar_002423245 = _0024_002414217_002423854[1];
						ForStatement forStatement = (_0024_00245521_002423260 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement2 = _0024_00245521_002423260;
						Declaration[] array = new Declaration[1];
						Declaration declaration = (_0024_00245507_002423246 = new Declaration(LexicalInfo.Empty));
						string text8 = (_0024_00245507_002423246.Name = "act");
						array[0] = _0024_00245507_002423246;
						DeclarationCollection declarationCollection2 = (forStatement2.Declarations = DeclarationCollection.FromArray(array));
						ForStatement forStatement3 = _0024_00245521_002423260;
						MemberReferenceExpression memberReferenceExpression = (_0024_00245508_002423247 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text10 = (_0024_00245508_002423247.Name = "Values");
						Expression expression2 = (_0024_00245508_002423247.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression4 = (forStatement3.Iterator = _0024_00245508_002423247);
						ForStatement forStatement4 = _0024_00245521_002423260;
						Block block = (_0024_00245520_002423259 = new Block(LexicalInfo.Empty));
						Block block2 = _0024_00245520_002423259;
						Statement[] array2 = new Statement[3];
						BinaryExpression binaryExpression = (_0024_00245511_002423250 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00245511_002423250.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression2 = _0024_00245511_002423250;
						ReferenceExpression referenceExpression = (_0024_00245509_002423248 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00245509_002423248.Name = "act");
						Expression expression6 = (binaryExpression2.Left = new MemberReferenceExpression(_0024_00245509_002423248, CodeSerializer.LiftName(_0024preActTimeVar_002423239)));
						BinaryExpression binaryExpression3 = _0024_00245511_002423250;
						ReferenceExpression referenceExpression2 = (_0024_00245510_002423249 = new ReferenceExpression(LexicalInfo.Empty));
						string text14 = (_0024_00245510_002423249.Name = "act");
						Expression expression8 = (binaryExpression3.Right = new MemberReferenceExpression(_0024_00245510_002423249, CodeSerializer.LiftName(_0024actTimeVar_002423238)));
						array2[0] = Statement.Lift(_0024_00245511_002423250);
						ExpressionStatement expressionStatement = (_0024_00245517_002423256 = new ExpressionStatement());
						ExpressionStatement expressionStatement2 = _0024_00245517_002423256;
						StatementModifier statementModifier = (_0024_00245514_002423253 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType2 = (_0024_00245514_002423253.Type = StatementModifierType.If);
						StatementModifier statementModifier2 = _0024_00245514_002423253;
						BinaryExpression binaryExpression4 = (_0024_00245513_002423252 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00245513_002423252.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression5 = _0024_00245513_002423252;
						ReferenceExpression referenceExpression3 = (_0024_00245512_002423251 = new ReferenceExpression(LexicalInfo.Empty));
						string text16 = (_0024_00245512_002423251.Name = "act");
						Expression expression10 = (binaryExpression5.Left = _0024_00245512_002423251);
						Expression expression12 = (_0024_00245513_002423252.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression14 = (statementModifier2.Condition = _0024_00245513_002423252);
						StatementModifier statementModifier4 = (expressionStatement2.Modifier = _0024_00245514_002423253);
						ExpressionStatement expressionStatement3 = _0024_00245517_002423256;
						BinaryExpression binaryExpression6 = (_0024_00245516_002423255 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType6 = (_0024_00245516_002423255.Operator = BinaryOperatorType.InPlaceAddition);
						BinaryExpression binaryExpression7 = _0024_00245516_002423255;
						ReferenceExpression referenceExpression4 = (_0024_00245515_002423254 = new ReferenceExpression(LexicalInfo.Empty));
						string text18 = (_0024_00245515_002423254.Name = "act");
						Expression expression16 = (binaryExpression7.Left = new MemberReferenceExpression(_0024_00245515_002423254, CodeSerializer.LiftName(_0024actTimeVar_002423238)));
						Expression expression18 = (_0024_00245516_002423255.Right = Expression.Lift(_0024deltaTimeVar_002423245));
						Expression expression20 = (expressionStatement3.Expression = _0024_00245516_002423255);
						array2[1] = Statement.Lift(_0024_00245517_002423256);
						UnaryExpression unaryExpression = (_0024_00245519_002423258 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType2 = (_0024_00245519_002423258.Operator = UnaryOperatorType.Increment);
						UnaryExpression unaryExpression2 = _0024_00245519_002423258;
						ReferenceExpression referenceExpression5 = (_0024_00245518_002423257 = new ReferenceExpression(LexicalInfo.Empty));
						string text20 = (_0024_00245518_002423257.Name = "act");
						Expression expression22 = (unaryExpression2.Operand = new MemberReferenceExpression(_0024_00245518_002423257, CodeSerializer.LiftName(_0024actFrameVar_002423242)));
						array2[2] = Statement.Lift(_0024_00245519_002423258);
						StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
						Block block4 = (forStatement4.Block = _0024_00245520_002423259);
						_0024b_002423261 = _0024_00245521_002423260;
						_0024progressActTimeCode_002423243.Add(_0024b_002423261);
						Module module = (_0024_00246092_002423832 = new Module(LexicalInfo.Empty));
						string text22 = (_0024_00246092_002423832.Name = "actmacros$388");
						Module module2 = _0024_00246092_002423832;
						TypeMember[] array3 = new TypeMember[25];
						ClassDefinition classDefinition = (_0024_00245577_002423317 = new ClassDefinition(LexicalInfo.Empty));
						string text24 = (_0024_00245577_002423317.Name = "ActionBase");
						ClassDefinition classDefinition2 = _0024_00245577_002423317;
						TypeMember[] array4 = new TypeMember[16];
						Field field = (_0024_00245522_002423262 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers2 = (_0024_00245522_002423262.Modifiers = TypeMemberModifiers.Public);
						string text26 = (_0024_00245522_002423262.Name = "$");
						TypeReference typeReference2 = (_0024_00245522_002423262.Type = TypeReference.Lift(_0024enumRef_002423232));
						bool flag2 = (_0024_00245522_002423262.IsVolatile = false);
						string text28 = (_0024_00245522_002423262.Name = CodeSerializer.LiftName(_0024self__002423859.actionIdName));
						array4[0] = _0024_00245522_002423262;
						Field field2 = (_0024_00245524_002423264 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers4 = (_0024_00245524_002423264.Modifiers = TypeMemberModifiers.Public);
						string text30 = (_0024_00245524_002423264.Name = "$");
						Field field3 = _0024_00245524_002423264;
						SimpleTypeReference simpleTypeReference = (_0024_00245523_002423263 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag4 = (_0024_00245523_002423263.IsPointer = false);
						string text32 = (_0024_00245523_002423263.Name = "string");
						TypeReference typeReference4 = (field3.Type = _0024_00245523_002423263);
						bool flag6 = (_0024_00245524_002423264.IsVolatile = false);
						string text34 = (_0024_00245524_002423264.Name = CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						array4[1] = _0024_00245524_002423264;
						Field field4 = (_0024_00245528_002423268 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers6 = (_0024_00245528_002423268.Modifiers = TypeMemberModifiers.Public);
						string text36 = (_0024_00245528_002423268.Name = "$");
						Field field5 = _0024_00245528_002423268;
						CallableTypeReference callableTypeReference = (_0024_00245527_002423267 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag8 = (_0024_00245527_002423267.IsPointer = false);
						CallableTypeReference callableTypeReference2 = _0024_00245527_002423267;
						ParameterDeclaration[] array5 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration = (_0024_00245526_002423266 = new ParameterDeclaration(LexicalInfo.Empty));
						string text38 = (_0024_00245526_002423266.Name = "arg0");
						ParameterDeclaration parameterDeclaration2 = _0024_00245526_002423266;
						SimpleTypeReference simpleTypeReference2 = (_0024_00245525_002423265 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag10 = (_0024_00245525_002423265.IsPointer = false);
						string text40 = (_0024_00245525_002423265.Name = "ActionBase");
						TypeReference typeReference6 = (parameterDeclaration2.Type = _0024_00245525_002423265);
						array5[0] = _0024_00245526_002423266;
						ParameterDeclarationCollection parameterDeclarationCollection2 = (callableTypeReference2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array5));
						TypeReference typeReference8 = (field5.Type = _0024_00245527_002423267);
						bool flag12 = (_0024_00245528_002423268.IsVolatile = false);
						string text42 = (_0024_00245528_002423268.Name = CodeSerializer.LiftName(_0024self__002423859.actionInit));
						array4[2] = _0024_00245528_002423268;
						Field field6 = (_0024_00245532_002423272 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers8 = (_0024_00245532_002423272.Modifiers = TypeMemberModifiers.Public);
						string text44 = (_0024_00245532_002423272.Name = "$");
						Field field7 = _0024_00245532_002423272;
						CallableTypeReference callableTypeReference3 = (_0024_00245531_002423271 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag14 = (_0024_00245531_002423271.IsPointer = false);
						CallableTypeReference callableTypeReference4 = _0024_00245531_002423271;
						ParameterDeclaration[] array6 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration3 = (_0024_00245530_002423270 = new ParameterDeclaration(LexicalInfo.Empty));
						string text46 = (_0024_00245530_002423270.Name = "arg0");
						ParameterDeclaration parameterDeclaration4 = _0024_00245530_002423270;
						SimpleTypeReference simpleTypeReference3 = (_0024_00245529_002423269 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag16 = (_0024_00245529_002423269.IsPointer = false);
						string text48 = (_0024_00245529_002423269.Name = "ActionBase");
						TypeReference typeReference10 = (parameterDeclaration4.Type = _0024_00245529_002423269);
						array6[0] = _0024_00245530_002423270;
						ParameterDeclarationCollection parameterDeclarationCollection4 = (callableTypeReference4.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array6));
						TypeReference typeReference12 = (field7.Type = _0024_00245531_002423271);
						bool flag18 = (_0024_00245532_002423272.IsVolatile = false);
						string text50 = (_0024_00245532_002423272.Name = CodeSerializer.LiftName(_0024self__002423859.actionExit));
						array4[3] = _0024_00245532_002423272;
						Field field8 = (_0024_00245536_002423276 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers10 = (_0024_00245536_002423276.Modifiers = TypeMemberModifiers.Public);
						string text52 = (_0024_00245536_002423276.Name = "$");
						Field field9 = _0024_00245536_002423276;
						CallableTypeReference callableTypeReference5 = (_0024_00245535_002423275 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag20 = (_0024_00245535_002423275.IsPointer = false);
						CallableTypeReference callableTypeReference6 = _0024_00245535_002423275;
						ParameterDeclaration[] array7 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration5 = (_0024_00245534_002423274 = new ParameterDeclaration(LexicalInfo.Empty));
						string text54 = (_0024_00245534_002423274.Name = "arg0");
						ParameterDeclaration parameterDeclaration6 = _0024_00245534_002423274;
						SimpleTypeReference simpleTypeReference4 = (_0024_00245533_002423273 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag22 = (_0024_00245533_002423273.IsPointer = false);
						string text56 = (_0024_00245533_002423273.Name = "ActionBase");
						TypeReference typeReference14 = (parameterDeclaration6.Type = _0024_00245533_002423273);
						array7[0] = _0024_00245534_002423274;
						ParameterDeclarationCollection parameterDeclarationCollection6 = (callableTypeReference6.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array7));
						TypeReference typeReference16 = (field9.Type = _0024_00245535_002423275);
						bool flag24 = (_0024_00245536_002423276.IsVolatile = false);
						string text58 = (_0024_00245536_002423276.Name = CodeSerializer.LiftName(_0024self__002423859.actionUpdate));
						array4[4] = _0024_00245536_002423276;
						Field field10 = (_0024_00245540_002423280 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers12 = (_0024_00245540_002423280.Modifiers = TypeMemberModifiers.Public);
						string text60 = (_0024_00245540_002423280.Name = "$");
						Field field11 = _0024_00245540_002423280;
						CallableTypeReference callableTypeReference7 = (_0024_00245539_002423279 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag26 = (_0024_00245539_002423279.IsPointer = false);
						CallableTypeReference callableTypeReference8 = _0024_00245539_002423279;
						ParameterDeclaration[] array8 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration7 = (_0024_00245538_002423278 = new ParameterDeclaration(LexicalInfo.Empty));
						string text62 = (_0024_00245538_002423278.Name = "arg0");
						ParameterDeclaration parameterDeclaration8 = _0024_00245538_002423278;
						SimpleTypeReference simpleTypeReference5 = (_0024_00245537_002423277 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag28 = (_0024_00245537_002423277.IsPointer = false);
						string text64 = (_0024_00245537_002423277.Name = "ActionBase");
						TypeReference typeReference18 = (parameterDeclaration8.Type = _0024_00245537_002423277);
						array8[0] = _0024_00245538_002423278;
						ParameterDeclarationCollection parameterDeclarationCollection8 = (callableTypeReference8.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array8));
						TypeReference typeReference20 = (field11.Type = _0024_00245539_002423279);
						bool flag30 = (_0024_00245540_002423280.IsVolatile = false);
						string text66 = (_0024_00245540_002423280.Name = CodeSerializer.LiftName(_0024self__002423859.actionFixedUpdate));
						array4[5] = _0024_00245540_002423280;
						Field field12 = (_0024_00245544_002423284 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers14 = (_0024_00245544_002423284.Modifiers = TypeMemberModifiers.Public);
						string text68 = (_0024_00245544_002423284.Name = "$");
						Field field13 = _0024_00245544_002423284;
						CallableTypeReference callableTypeReference9 = (_0024_00245543_002423283 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag32 = (_0024_00245543_002423283.IsPointer = false);
						CallableTypeReference callableTypeReference10 = _0024_00245543_002423283;
						ParameterDeclaration[] array9 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration9 = (_0024_00245542_002423282 = new ParameterDeclaration(LexicalInfo.Empty));
						string text70 = (_0024_00245542_002423282.Name = "arg0");
						ParameterDeclaration parameterDeclaration10 = _0024_00245542_002423282;
						SimpleTypeReference simpleTypeReference6 = (_0024_00245541_002423281 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag34 = (_0024_00245541_002423281.IsPointer = false);
						string text72 = (_0024_00245541_002423281.Name = "ActionBase");
						TypeReference typeReference22 = (parameterDeclaration10.Type = _0024_00245541_002423281);
						array9[0] = _0024_00245542_002423282;
						ParameterDeclarationCollection parameterDeclarationCollection10 = (callableTypeReference10.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array9));
						TypeReference typeReference24 = (field13.Type = _0024_00245543_002423283);
						bool flag36 = (_0024_00245544_002423284.IsVolatile = false);
						string text74 = (_0024_00245544_002423284.Name = CodeSerializer.LiftName(_0024self__002423859.actionOnGUI));
						array4[6] = _0024_00245544_002423284;
						Field field14 = (_0024_00245548_002423288 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers16 = (_0024_00245548_002423288.Modifiers = TypeMemberModifiers.Public);
						string text76 = (_0024_00245548_002423288.Name = "$");
						Field field15 = _0024_00245548_002423288;
						CallableTypeReference callableTypeReference11 = (_0024_00245547_002423287 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag38 = (_0024_00245547_002423287.IsPointer = false);
						CallableTypeReference callableTypeReference12 = _0024_00245547_002423287;
						ParameterDeclaration[] array10 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration11 = (_0024_00245546_002423286 = new ParameterDeclaration(LexicalInfo.Empty));
						string text78 = (_0024_00245546_002423286.Name = "arg0");
						ParameterDeclaration parameterDeclaration12 = _0024_00245546_002423286;
						SimpleTypeReference simpleTypeReference7 = (_0024_00245545_002423285 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag40 = (_0024_00245545_002423285.IsPointer = false);
						string text80 = (_0024_00245545_002423285.Name = "ActionBase");
						TypeReference typeReference26 = (parameterDeclaration12.Type = _0024_00245545_002423285);
						array10[0] = _0024_00245546_002423286;
						ParameterDeclarationCollection parameterDeclarationCollection12 = (callableTypeReference12.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array10));
						TypeReference typeReference28 = (field15.Type = _0024_00245547_002423287);
						bool flag42 = (_0024_00245548_002423288.IsVolatile = false);
						string text82 = (_0024_00245548_002423288.Name = CodeSerializer.LiftName(_0024self__002423859.actionLateUpdate));
						array4[7] = _0024_00245548_002423288;
						Field field16 = (_0024_00245553_002423293 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers18 = (_0024_00245553_002423293.Modifiers = TypeMemberModifiers.Public);
						string text84 = (_0024_00245553_002423293.Name = "$");
						Field field17 = _0024_00245553_002423293;
						CallableTypeReference callableTypeReference13 = (_0024_00245552_002423292 = new CallableTypeReference(LexicalInfo.Empty));
						bool flag44 = (_0024_00245552_002423292.IsPointer = false);
						CallableTypeReference callableTypeReference14 = _0024_00245552_002423292;
						ParameterDeclaration[] array11 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration13 = (_0024_00245550_002423290 = new ParameterDeclaration(LexicalInfo.Empty));
						string text86 = (_0024_00245550_002423290.Name = "arg0");
						ParameterDeclaration parameterDeclaration14 = _0024_00245550_002423290;
						SimpleTypeReference simpleTypeReference8 = (_0024_00245549_002423289 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag46 = (_0024_00245549_002423289.IsPointer = false);
						string text88 = (_0024_00245549_002423289.Name = "ActionBase");
						TypeReference typeReference30 = (parameterDeclaration14.Type = _0024_00245549_002423289);
						array11[0] = _0024_00245550_002423290;
						ParameterDeclarationCollection parameterDeclarationCollection14 = (callableTypeReference14.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array11));
						CallableTypeReference callableTypeReference15 = _0024_00245552_002423292;
						SimpleTypeReference simpleTypeReference9 = (_0024_00245551_002423291 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag48 = (_0024_00245551_002423291.IsPointer = false);
						string text90 = (_0024_00245551_002423291.Name = "System.Collections.IEnumerator");
						TypeReference typeReference32 = (callableTypeReference15.ReturnType = _0024_00245551_002423291);
						TypeReference typeReference34 = (field17.Type = _0024_00245552_002423292);
						bool flag50 = (_0024_00245553_002423293.IsVolatile = false);
						string text92 = (_0024_00245553_002423293.Name = CodeSerializer.LiftName(_0024self__002423859.actionCoroutine));
						array4[8] = _0024_00245553_002423293;
						Field field18 = (_0024_00245555_002423295 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers20 = (_0024_00245555_002423295.Modifiers = TypeMemberModifiers.Public);
						string text94 = (_0024_00245555_002423295.Name = "$");
						Field field19 = _0024_00245555_002423295;
						SimpleTypeReference simpleTypeReference10 = (_0024_00245554_002423294 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag52 = (_0024_00245554_002423294.IsPointer = false);
						string text96 = (_0024_00245554_002423294.Name = "System.Collections.IEnumerator");
						TypeReference typeReference36 = (field19.Type = _0024_00245554_002423294);
						bool flag54 = (_0024_00245555_002423295.IsVolatile = false);
						string text98 = (_0024_00245555_002423295.Name = CodeSerializer.LiftName(_0024coIteratorVar_002423237));
						array4[9] = _0024_00245555_002423295;
						Field field20 = (_0024_00245557_002423297 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers22 = (_0024_00245557_002423297.Modifiers = TypeMemberModifiers.Public);
						string text100 = (_0024_00245557_002423297.Name = "$");
						Field field21 = _0024_00245557_002423297;
						SimpleTypeReference simpleTypeReference11 = (_0024_00245556_002423296 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag56 = (_0024_00245556_002423296.IsPointer = false);
						string text102 = (_0024_00245556_002423296.Name = "single");
						TypeReference typeReference38 = (field21.Type = _0024_00245556_002423296);
						bool flag58 = (_0024_00245557_002423297.IsVolatile = false);
						string text104 = (_0024_00245557_002423297.Name = CodeSerializer.LiftName(_0024actTimeVar_002423238));
						array4[10] = _0024_00245557_002423297;
						Field field22 = (_0024_00245559_002423299 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers24 = (_0024_00245559_002423299.Modifiers = TypeMemberModifiers.Public);
						string text106 = (_0024_00245559_002423299.Name = "$");
						Field field23 = _0024_00245559_002423299;
						SimpleTypeReference simpleTypeReference12 = (_0024_00245558_002423298 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag60 = (_0024_00245558_002423298.IsPointer = false);
						string text108 = (_0024_00245558_002423298.Name = "single");
						TypeReference typeReference40 = (field23.Type = _0024_00245558_002423298);
						bool flag62 = (_0024_00245559_002423299.IsVolatile = false);
						string text110 = (_0024_00245559_002423299.Name = CodeSerializer.LiftName(_0024preActTimeVar_002423239));
						array4[11] = _0024_00245559_002423299;
						Field field24 = (_0024_00245561_002423301 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers26 = (_0024_00245561_002423301.Modifiers = TypeMemberModifiers.Public);
						string text112 = (_0024_00245561_002423301.Name = "$");
						Field field25 = _0024_00245561_002423301;
						SimpleTypeReference simpleTypeReference13 = (_0024_00245560_002423300 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag64 = (_0024_00245560_002423300.IsPointer = false);
						string text114 = (_0024_00245560_002423300.Name = "single");
						TypeReference typeReference42 = (field25.Type = _0024_00245560_002423300);
						bool flag66 = (_0024_00245561_002423301.IsVolatile = false);
						string text116 = (_0024_00245561_002423301.Name = CodeSerializer.LiftName(_0024realActInitTimeVar_002423241));
						array4[12] = _0024_00245561_002423301;
						Field field26 = (_0024_00245563_002423303 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers28 = (_0024_00245563_002423303.Modifiers = TypeMemberModifiers.Public);
						string text118 = (_0024_00245563_002423303.Name = "$");
						Field field27 = _0024_00245563_002423303;
						SimpleTypeReference simpleTypeReference14 = (_0024_00245562_002423302 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag68 = (_0024_00245562_002423302.IsPointer = false);
						string text120 = (_0024_00245562_002423302.Name = "single");
						TypeReference typeReference44 = (field27.Type = _0024_00245562_002423302);
						bool flag70 = (_0024_00245563_002423303.IsVolatile = false);
						string text122 = (_0024_00245563_002423303.Name = CodeSerializer.LiftName(_0024actFrameVar_002423242));
						array4[13] = _0024_00245563_002423303;
						Property property = (_0024_00245570_002423310 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers30 = (_0024_00245570_002423310.Modifiers = TypeMemberModifiers.Public);
						string text124 = (_0024_00245570_002423310.Name = "myName");
						Property property2 = _0024_00245570_002423310;
						Method method = (_0024_00245568_002423308 = new Method(LexicalInfo.Empty));
						string text126 = (_0024_00245568_002423308.Name = "get");
						Method method2 = _0024_00245568_002423308;
						Block block5 = (_0024_00245567_002423307 = new Block(LexicalInfo.Empty));
						Block block6 = _0024_00245567_002423307;
						Statement[] array12 = new Statement[1];
						ReturnStatement returnStatement = (_0024_00245566_002423306 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00245566_002423306;
						MethodInvocationExpression methodInvocationExpression = (_0024_00245565_002423305 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00245565_002423305;
						MemberReferenceExpression memberReferenceExpression2 = (_0024_00245564_002423304 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text128 = (_0024_00245564_002423304.Name = "ToString");
						Expression expression24 = (_0024_00245564_002423304.Target = Expression.Lift(_0024self__002423859.actionIdName));
						Expression expression26 = (methodInvocationExpression2.Target = _0024_00245564_002423304);
						Expression expression28 = (returnStatement2.Expression = _0024_00245565_002423305);
						array12[0] = Statement.Lift(_0024_00245566_002423306);
						StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array12));
						Block block8 = (method2.Body = _0024_00245567_002423307);
						Method method4 = (property2.Getter = _0024_00245568_002423308);
						Property property3 = _0024_00245570_002423310;
						SimpleTypeReference simpleTypeReference15 = (_0024_00245569_002423309 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag72 = (_0024_00245569_002423309.IsPointer = false);
						string text130 = (_0024_00245569_002423309.Name = "string");
						TypeReference typeReference46 = (property3.Type = _0024_00245569_002423309);
						array4[14] = _0024_00245570_002423310;
						Property property4 = (_0024_00245576_002423316 = new Property(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers32 = (_0024_00245576_002423316.Modifiers = TypeMemberModifiers.Public);
						string text132 = (_0024_00245576_002423316.Name = "$");
						Property property5 = _0024_00245576_002423316;
						Method method5 = (_0024_00245574_002423314 = new Method(LexicalInfo.Empty));
						string text134 = (_0024_00245574_002423314.Name = "get");
						Method method6 = _0024_00245574_002423314;
						Block block9 = (_0024_00245573_002423313 = new Block(LexicalInfo.Empty));
						Block block10 = _0024_00245573_002423313;
						Statement[] array13 = new Statement[1];
						ReturnStatement returnStatement3 = (_0024_00245572_002423312 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement4 = _0024_00245572_002423312;
						BinaryExpression binaryExpression8 = (_0024_00245571_002423311 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType8 = (_0024_00245571_002423311.Operator = BinaryOperatorType.Subtraction);
						Expression expression30 = (_0024_00245571_002423311.Left = Expression.Lift(_0024nowTimeVar_002423244));
						Expression expression32 = (_0024_00245571_002423311.Right = Expression.Lift(_0024realActInitTimeVar_002423241));
						Expression expression34 = (returnStatement4.Expression = _0024_00245571_002423311);
						array13[0] = Statement.Lift(_0024_00245572_002423312);
						StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(array13));
						Block block12 = (method6.Body = _0024_00245573_002423313);
						Method method8 = (property5.Getter = _0024_00245574_002423314);
						Property property6 = _0024_00245576_002423316;
						SimpleTypeReference simpleTypeReference16 = (_0024_00245575_002423315 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag74 = (_0024_00245575_002423315.IsPointer = false);
						string text136 = (_0024_00245575_002423315.Name = "single");
						TypeReference typeReference48 = (property6.Type = _0024_00245575_002423315);
						string text138 = (_0024_00245576_002423316.Name = CodeSerializer.LiftName(_0024realActTimeProp_002423240));
						array4[15] = _0024_00245576_002423316;
						TypeMemberCollection typeMemberCollection2 = (classDefinition2.Members = TypeMemberCollection.FromArray(array4));
						array3[0] = _0024_00245577_002423317;
						Field field28 = (_0024_00245586_002423326 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers34 = (_0024_00245586_002423326.Modifiers = TypeMemberModifiers.Private);
						string text140 = (_0024_00245586_002423326.Name = "$");
						Field field29 = _0024_00245586_002423326;
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00245585_002423325 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00245585_002423325;
						GenericReferenceExpression genericReferenceExpression = (_0024_00245584_002423324 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression2 = _0024_00245584_002423324;
						MemberReferenceExpression memberReferenceExpression3 = (_0024_00245581_002423321 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text142 = (_0024_00245581_002423321.Name = "Dictionary");
						MemberReferenceExpression memberReferenceExpression4 = _0024_00245581_002423321;
						MemberReferenceExpression memberReferenceExpression5 = (_0024_00245580_002423320 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text144 = (_0024_00245580_002423320.Name = "Generic");
						MemberReferenceExpression memberReferenceExpression6 = _0024_00245580_002423320;
						MemberReferenceExpression memberReferenceExpression7 = (_0024_00245579_002423319 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text146 = (_0024_00245579_002423319.Name = "Collections");
						MemberReferenceExpression memberReferenceExpression8 = _0024_00245579_002423319;
						ReferenceExpression referenceExpression6 = (_0024_00245578_002423318 = new ReferenceExpression(LexicalInfo.Empty));
						string text148 = (_0024_00245578_002423318.Name = "System");
						Expression expression36 = (memberReferenceExpression8.Target = _0024_00245578_002423318);
						Expression expression38 = (memberReferenceExpression6.Target = _0024_00245579_002423319);
						Expression expression40 = (memberReferenceExpression4.Target = _0024_00245580_002423320);
						Expression expression42 = (genericReferenceExpression2.Target = _0024_00245581_002423321);
						GenericReferenceExpression genericReferenceExpression3 = _0024_00245584_002423324;
						TypeReference[] array14 = new TypeReference[2];
						SimpleTypeReference simpleTypeReference17 = (_0024_00245582_002423322 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag76 = (_0024_00245582_002423322.IsPointer = false);
						string text150 = (_0024_00245582_002423322.Name = "string");
						array14[0] = _0024_00245582_002423322;
						SimpleTypeReference simpleTypeReference18 = (_0024_00245583_002423323 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag78 = (_0024_00245583_002423323.IsPointer = false);
						string text152 = (_0024_00245583_002423323.Name = "ActionBase");
						array14[1] = _0024_00245583_002423323;
						TypeReferenceCollection typeReferenceCollection2 = (genericReferenceExpression3.GenericArguments = TypeReferenceCollection.FromArray(array14));
						Expression expression44 = (methodInvocationExpression4.Target = _0024_00245584_002423324);
						Expression expression46 = (field29.Initializer = _0024_00245585_002423325);
						bool flag80 = (_0024_00245586_002423326.IsVolatile = false);
						string text154 = (_0024_00245586_002423326.Name = CodeSerializer.LiftName(_0024self__002423859.currentActionDic));
						array3[1] = _0024_00245586_002423326;
						Field field30 = (_0024_00245594_002423334 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers36 = (_0024_00245594_002423334.Modifiers = TypeMemberModifiers.Private);
						string text156 = (_0024_00245594_002423334.Name = "$");
						Field field31 = _0024_00245594_002423334;
						MethodInvocationExpression methodInvocationExpression5 = (_0024_00245593_002423333 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression6 = _0024_00245593_002423333;
						GenericReferenceExpression genericReferenceExpression4 = (_0024_00245592_002423332 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression5 = _0024_00245592_002423332;
						MemberReferenceExpression memberReferenceExpression9 = (_0024_00245590_002423330 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text158 = (_0024_00245590_002423330.Name = "Dictionary");
						MemberReferenceExpression memberReferenceExpression10 = _0024_00245590_002423330;
						MemberReferenceExpression memberReferenceExpression11 = (_0024_00245589_002423329 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text160 = (_0024_00245589_002423329.Name = "Generic");
						MemberReferenceExpression memberReferenceExpression12 = _0024_00245589_002423329;
						MemberReferenceExpression memberReferenceExpression13 = (_0024_00245588_002423328 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text162 = (_0024_00245588_002423328.Name = "Collections");
						MemberReferenceExpression memberReferenceExpression14 = _0024_00245588_002423328;
						ReferenceExpression referenceExpression7 = (_0024_00245587_002423327 = new ReferenceExpression(LexicalInfo.Empty));
						string text164 = (_0024_00245587_002423327.Name = "System");
						Expression expression48 = (memberReferenceExpression14.Target = _0024_00245587_002423327);
						Expression expression50 = (memberReferenceExpression12.Target = _0024_00245588_002423328);
						Expression expression52 = (memberReferenceExpression10.Target = _0024_00245589_002423329);
						Expression expression54 = (genericReferenceExpression5.Target = _0024_00245590_002423330);
						GenericReferenceExpression genericReferenceExpression6 = _0024_00245592_002423332;
						TypeReference[] array15 = new TypeReference[2];
						SimpleTypeReference simpleTypeReference19 = (_0024_00245591_002423331 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag82 = (_0024_00245591_002423331.IsPointer = false);
						string text166 = (_0024_00245591_002423331.Name = "string");
						array15[0] = _0024_00245591_002423331;
						array15[1] = TypeReference.Lift(_0024enumRef_002423232);
						TypeReferenceCollection typeReferenceCollection4 = (genericReferenceExpression6.GenericArguments = TypeReferenceCollection.FromArray(array15));
						Expression expression56 = (methodInvocationExpression6.Target = _0024_00245592_002423332);
						Expression expression58 = (field31.Initializer = _0024_00245593_002423333);
						bool flag84 = (_0024_00245594_002423334.IsVolatile = false);
						string text168 = (_0024_00245594_002423334.Name = CodeSerializer.LiftName(_0024currentActionIdDic_002423236));
						array3[2] = _0024_00245594_002423334;
						Field field32 = (_0024_00245599_002423339 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers38 = (_0024_00245599_002423339.Modifiers = TypeMemberModifiers.Private);
						string text170 = (_0024_00245599_002423339.Name = "tmpActBuf");
						Field field33 = _0024_00245599_002423339;
						MethodInvocationExpression methodInvocationExpression7 = (_0024_00245598_002423338 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression8 = _0024_00245598_002423338;
						ReferenceExpression referenceExpression8 = (_0024_00245595_002423335 = new ReferenceExpression(LexicalInfo.Empty));
						string text172 = (_0024_00245595_002423335.Name = "array");
						Expression expression60 = (methodInvocationExpression8.Target = _0024_00245595_002423335);
						MethodInvocationExpression methodInvocationExpression9 = _0024_00245598_002423338;
						Expression[] array16 = new Expression[2];
						ReferenceExpression referenceExpression9 = (_0024_00245596_002423336 = new ReferenceExpression(LexicalInfo.Empty));
						string text174 = (_0024_00245596_002423336.Name = "ActionBase");
						array16[0] = _0024_00245596_002423336;
						IntegerLiteralExpression integerLiteralExpression = (_0024_00245597_002423337 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num2 = (_0024_00245597_002423337.Value = 32L);
						bool flag86 = (_0024_00245597_002423337.IsLong = false);
						array16[1] = _0024_00245597_002423337;
						ExpressionCollection expressionCollection2 = (methodInvocationExpression9.Arguments = ExpressionCollection.FromArray(array16));
						Expression expression62 = (field33.Initializer = _0024_00245598_002423338);
						bool flag88 = (_0024_00245599_002423339.IsVolatile = false);
						array3[3] = _0024_00245599_002423339;
						Field field34 = (_0024_00245602_002423342 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers40 = (_0024_00245602_002423342.Modifiers = TypeMemberModifiers.Private);
						string text176 = (_0024_00245602_002423342.Name = "$");
						Field field35 = _0024_00245602_002423342;
						SimpleTypeReference simpleTypeReference20 = (_0024_00245600_002423340 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag90 = (_0024_00245600_002423340.IsPointer = false);
						string text178 = (_0024_00245600_002423340.Name = "int");
						TypeReference typeReference50 = (field35.Type = _0024_00245600_002423340);
						Field field36 = _0024_00245602_002423342;
						IntegerLiteralExpression integerLiteralExpression2 = (_0024_00245601_002423341 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num4 = (_0024_00245601_002423341.Value = 0L);
						bool flag92 = (_0024_00245601_002423341.IsLong = false);
						Expression expression64 = (field36.Initializer = _0024_00245601_002423341);
						bool flag94 = (_0024_00245602_002423342.IsVolatile = false);
						string text180 = (_0024_00245602_002423342.Name = CodeSerializer.LiftName(_0024changeNumVar_002423234));
						array3[4] = _0024_00245602_002423342;
						Field field37 = (_0024_00245605_002423345 = new Field(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers42 = (_0024_00245605_002423345.Modifiers = TypeMemberModifiers.Public);
						string text182 = (_0024_00245605_002423345.Name = "$");
						Field field38 = _0024_00245605_002423345;
						SimpleTypeReference simpleTypeReference21 = (_0024_00245603_002423343 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag96 = (_0024_00245603_002423343.IsPointer = false);
						string text184 = (_0024_00245603_002423343.Name = "bool");
						TypeReference typeReference52 = (field38.Type = _0024_00245603_002423343);
						Field field39 = _0024_00245605_002423345;
						BoolLiteralExpression boolLiteralExpression = (_0024_00245604_002423344 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag98 = (_0024_00245604_002423344.Value = false);
						Expression expression66 = (field39.Initializer = _0024_00245604_002423344);
						bool flag100 = (_0024_00245605_002423345.IsVolatile = false);
						string text186 = (_0024_00245605_002423345.Name = CodeSerializer.LiftName(_0024debugFlagVar_002423235));
						array3[5] = _0024_00245605_002423345;
						Method method9 = (_0024_00245611_002423351 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers44 = (_0024_00245611_002423351.Modifiers = TypeMemberModifiers.Public);
						string text188 = (_0024_00245611_002423351.Name = "setActionDebugMode");
						Method method10 = _0024_00245611_002423351;
						ParameterDeclaration[] array17 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration15 = (_0024_00245607_002423347 = new ParameterDeclaration(LexicalInfo.Empty));
						string text190 = (_0024_00245607_002423347.Name = "b");
						ParameterDeclaration parameterDeclaration16 = _0024_00245607_002423347;
						SimpleTypeReference simpleTypeReference22 = (_0024_00245606_002423346 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag102 = (_0024_00245606_002423346.IsPointer = false);
						string text192 = (_0024_00245606_002423346.Name = "bool");
						TypeReference typeReference54 = (parameterDeclaration16.Type = _0024_00245606_002423346);
						array17[0] = _0024_00245607_002423347;
						ParameterDeclarationCollection parameterDeclarationCollection16 = (method10.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array17));
						Method method11 = _0024_00245611_002423351;
						Block block13 = (_0024_00245610_002423350 = new Block(LexicalInfo.Empty));
						Block block14 = _0024_00245610_002423350;
						Statement[] array18 = new Statement[1];
						BinaryExpression binaryExpression9 = (_0024_00245609_002423349 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType10 = (_0024_00245609_002423349.Operator = BinaryOperatorType.Assign);
						Expression expression68 = (_0024_00245609_002423349.Left = Expression.Lift(_0024debugFlagVar_002423235));
						BinaryExpression binaryExpression10 = _0024_00245609_002423349;
						ReferenceExpression referenceExpression10 = (_0024_00245608_002423348 = new ReferenceExpression(LexicalInfo.Empty));
						string text194 = (_0024_00245608_002423348.Name = "b");
						Expression expression70 = (binaryExpression10.Right = _0024_00245608_002423348);
						array18[0] = Statement.Lift(_0024_00245609_002423349);
						StatementCollection statementCollection8 = (block14.Statements = StatementCollection.FromArray(array18));
						Block block16 = (method11.Body = _0024_00245610_002423350);
						array3[6] = _0024_00245611_002423351;
						Method method12 = (_0024_00245617_002423357 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers46 = (_0024_00245617_002423357.Modifiers = TypeMemberModifiers.Public);
						string text196 = (_0024_00245617_002423357.Name = "currAction");
						Method method13 = _0024_00245617_002423357;
						SimpleTypeReference simpleTypeReference23 = (_0024_00245612_002423352 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag104 = (_0024_00245612_002423352.IsPointer = false);
						string text198 = (_0024_00245612_002423352.Name = "ActionBase");
						TypeReference typeReference56 = (method13.ReturnType = _0024_00245612_002423352);
						Method method14 = _0024_00245617_002423357;
						Block block17 = (_0024_00245616_002423356 = new Block(LexicalInfo.Empty));
						Block block18 = _0024_00245616_002423356;
						Statement[] array19 = new Statement[1];
						ReturnStatement returnStatement5 = (_0024_00245615_002423355 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement6 = _0024_00245615_002423355;
						MethodInvocationExpression methodInvocationExpression10 = (_0024_00245614_002423354 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression11 = _0024_00245614_002423354;
						ReferenceExpression referenceExpression11 = (_0024_00245613_002423353 = new ReferenceExpression(LexicalInfo.Empty));
						string text200 = (_0024_00245613_002423353.Name = "currAction");
						Expression expression72 = (methodInvocationExpression11.Target = _0024_00245613_002423353);
						ExpressionCollection expressionCollection4 = (_0024_00245614_002423354.Arguments = ExpressionCollection.FromArray(Expression.Lift("$default$")));
						Expression expression74 = (returnStatement6.Expression = _0024_00245614_002423354);
						array19[0] = Statement.Lift(_0024_00245615_002423355);
						StatementCollection statementCollection10 = (block18.Statements = StatementCollection.FromArray(array19));
						Block block20 = (method14.Body = _0024_00245616_002423356);
						array3[7] = _0024_00245617_002423357;
						Method method15 = (_0024_00245623_002423363 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers48 = (_0024_00245623_002423363.Modifiers = TypeMemberModifiers.Public);
						string text202 = (_0024_00245623_002423363.Name = "currActionID");
						Method method16 = _0024_00245623_002423363;
						SimpleTypeReference simpleTypeReference24 = (_0024_00245618_002423358 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag106 = (_0024_00245618_002423358.IsPointer = false);
						string text204 = (_0024_00245618_002423358.Name = "ActionEnum");
						TypeReference typeReference58 = (method16.ReturnType = _0024_00245618_002423358);
						Method method17 = _0024_00245623_002423363;
						Block block21 = (_0024_00245622_002423362 = new Block(LexicalInfo.Empty));
						Block block22 = _0024_00245622_002423362;
						Statement[] array20 = new Statement[1];
						ReturnStatement returnStatement7 = (_0024_00245621_002423361 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement8 = _0024_00245621_002423361;
						MethodInvocationExpression methodInvocationExpression12 = (_0024_00245620_002423360 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression13 = _0024_00245620_002423360;
						ReferenceExpression referenceExpression12 = (_0024_00245619_002423359 = new ReferenceExpression(LexicalInfo.Empty));
						string text206 = (_0024_00245619_002423359.Name = "currActionID");
						Expression expression76 = (methodInvocationExpression13.Target = _0024_00245619_002423359);
						ExpressionCollection expressionCollection6 = (_0024_00245620_002423360.Arguments = ExpressionCollection.FromArray(Expression.Lift("$default$")));
						Expression expression78 = (returnStatement8.Expression = _0024_00245620_002423360);
						array20[0] = Statement.Lift(_0024_00245621_002423361);
						StatementCollection statementCollection12 = (block22.Statements = StatementCollection.FromArray(array20));
						Block block24 = (method17.Body = _0024_00245622_002423362);
						array3[8] = _0024_00245623_002423363;
						Method method18 = (_0024_00245645_002423385 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers50 = (_0024_00245645_002423385.Modifiers = TypeMemberModifiers.Public);
						string text208 = (_0024_00245645_002423385.Name = "currAction");
						Method method19 = _0024_00245645_002423385;
						ParameterDeclaration[] array21 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration17 = (_0024_00245625_002423365 = new ParameterDeclaration(LexicalInfo.Empty));
						string text210 = (_0024_00245625_002423365.Name = "grp");
						ParameterDeclaration parameterDeclaration18 = _0024_00245625_002423365;
						SimpleTypeReference simpleTypeReference25 = (_0024_00245624_002423364 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag108 = (_0024_00245624_002423364.IsPointer = false);
						string text212 = (_0024_00245624_002423364.Name = "string");
						TypeReference typeReference60 = (parameterDeclaration18.Type = _0024_00245624_002423364);
						array21[0] = _0024_00245625_002423365;
						ParameterDeclarationCollection parameterDeclarationCollection18 = (method19.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array21));
						Method method20 = _0024_00245645_002423385;
						SimpleTypeReference simpleTypeReference26 = (_0024_00245626_002423366 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag110 = (_0024_00245626_002423366.IsPointer = false);
						string text214 = (_0024_00245626_002423366.Name = "ActionBase");
						TypeReference typeReference62 = (method20.ReturnType = _0024_00245626_002423366);
						Method method21 = _0024_00245645_002423385;
						Block block25 = (_0024_00245644_002423384 = new Block(LexicalInfo.Empty));
						Block block26 = _0024_00245644_002423384;
						Statement[] array22 = new Statement[1];
						IfStatement ifStatement = (_0024_00245643_002423383 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement2 = _0024_00245643_002423383;
						BinaryExpression binaryExpression11 = (_0024_00245635_002423375 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType12 = (_0024_00245635_002423375.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression12 = _0024_00245635_002423375;
						UnaryExpression unaryExpression3 = (_0024_00245631_002423371 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType4 = (_0024_00245631_002423371.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression4 = _0024_00245631_002423371;
						MethodInvocationExpression methodInvocationExpression14 = (_0024_00245630_002423370 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression15 = _0024_00245630_002423370;
						MemberReferenceExpression memberReferenceExpression15 = (_0024_00245628_002423368 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text216 = (_0024_00245628_002423368.Name = "IsNullOrEmpty");
						MemberReferenceExpression memberReferenceExpression16 = _0024_00245628_002423368;
						ReferenceExpression referenceExpression13 = (_0024_00245627_002423367 = new ReferenceExpression(LexicalInfo.Empty));
						string text218 = (_0024_00245627_002423367.Name = "string");
						Expression expression80 = (memberReferenceExpression16.Target = _0024_00245627_002423367);
						Expression expression82 = (methodInvocationExpression15.Target = _0024_00245628_002423368);
						MethodInvocationExpression methodInvocationExpression16 = _0024_00245630_002423370;
						Expression[] array23 = new Expression[1];
						ReferenceExpression referenceExpression14 = (_0024_00245629_002423369 = new ReferenceExpression(LexicalInfo.Empty));
						string text220 = (_0024_00245629_002423369.Name = "grp");
						array23[0] = _0024_00245629_002423369;
						ExpressionCollection expressionCollection8 = (methodInvocationExpression16.Arguments = ExpressionCollection.FromArray(array23));
						Expression expression84 = (unaryExpression4.Operand = _0024_00245630_002423370);
						Expression expression86 = (binaryExpression12.Left = _0024_00245631_002423371);
						BinaryExpression binaryExpression13 = _0024_00245635_002423375;
						MethodInvocationExpression methodInvocationExpression17 = (_0024_00245634_002423374 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression18 = _0024_00245634_002423374;
						MemberReferenceExpression memberReferenceExpression17 = (_0024_00245632_002423372 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text222 = (_0024_00245632_002423372.Name = "ContainsKey");
						Expression expression88 = (_0024_00245632_002423372.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression90 = (methodInvocationExpression18.Target = _0024_00245632_002423372);
						MethodInvocationExpression methodInvocationExpression19 = _0024_00245634_002423374;
						Expression[] array24 = new Expression[1];
						ReferenceExpression referenceExpression15 = (_0024_00245633_002423373 = new ReferenceExpression(LexicalInfo.Empty));
						string text224 = (_0024_00245633_002423373.Name = "grp");
						array24[0] = _0024_00245633_002423373;
						ExpressionCollection expressionCollection10 = (methodInvocationExpression19.Arguments = ExpressionCollection.FromArray(array24));
						Expression expression92 = (binaryExpression13.Right = _0024_00245634_002423374);
						Expression expression94 = (ifStatement2.Condition = _0024_00245635_002423375);
						IfStatement ifStatement3 = _0024_00245643_002423383;
						Block block27 = (_0024_00245640_002423380 = new Block(LexicalInfo.Empty));
						Block block28 = _0024_00245640_002423380;
						Statement[] array25 = new Statement[1];
						ReturnStatement returnStatement9 = (_0024_00245639_002423379 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement10 = _0024_00245639_002423379;
						SlicingExpression slicingExpression = (_0024_00245638_002423378 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression96 = (_0024_00245638_002423378.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression2 = _0024_00245638_002423378;
						Slice[] array26 = new Slice[1];
						Slice slice = (_0024_00245637_002423377 = new Slice(LexicalInfo.Empty));
						Slice slice2 = _0024_00245637_002423377;
						ReferenceExpression referenceExpression16 = (_0024_00245636_002423376 = new ReferenceExpression(LexicalInfo.Empty));
						string text226 = (_0024_00245636_002423376.Name = "grp");
						Expression expression98 = (slice2.Begin = _0024_00245636_002423376);
						array26[0] = _0024_00245637_002423377;
						SliceCollection sliceCollection2 = (slicingExpression2.Indices = SliceCollection.FromArray(array26));
						Expression expression100 = (returnStatement10.Expression = _0024_00245638_002423378);
						array25[0] = Statement.Lift(_0024_00245639_002423379);
						StatementCollection statementCollection14 = (block28.Statements = StatementCollection.FromArray(array25));
						Block block30 = (ifStatement3.TrueBlock = _0024_00245640_002423380);
						IfStatement ifStatement4 = _0024_00245643_002423383;
						Block block31 = (_0024_00245642_002423382 = new Block(LexicalInfo.Empty));
						Block block32 = _0024_00245642_002423382;
						Statement[] array27 = new Statement[1];
						ReturnStatement returnStatement11 = (_0024_00245641_002423381 = new ReturnStatement(LexicalInfo.Empty));
						Expression expression102 = (_0024_00245641_002423381.Expression = new NullLiteralExpression(LexicalInfo.Empty));
						array27[0] = Statement.Lift(_0024_00245641_002423381);
						StatementCollection statementCollection16 = (block32.Statements = StatementCollection.FromArray(array27));
						Block block34 = (ifStatement4.FalseBlock = _0024_00245642_002423382);
						array22[0] = Statement.Lift(_0024_00245643_002423383);
						StatementCollection statementCollection18 = (block26.Statements = StatementCollection.FromArray(array22));
						Block block36 = (method21.Body = _0024_00245644_002423384);
						array3[9] = _0024_00245645_002423385;
						Method method22 = (_0024_00245661_002423401 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers52 = (_0024_00245661_002423401.Modifiers = TypeMemberModifiers.Public);
						string text228 = (_0024_00245661_002423401.Name = "currActionID");
						Method method23 = _0024_00245661_002423401;
						ParameterDeclaration[] array28 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration19 = (_0024_00245647_002423387 = new ParameterDeclaration(LexicalInfo.Empty));
						string text230 = (_0024_00245647_002423387.Name = "grp");
						ParameterDeclaration parameterDeclaration20 = _0024_00245647_002423387;
						SimpleTypeReference simpleTypeReference27 = (_0024_00245646_002423386 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag112 = (_0024_00245646_002423386.IsPointer = false);
						string text232 = (_0024_00245646_002423386.Name = "string");
						TypeReference typeReference64 = (parameterDeclaration20.Type = _0024_00245646_002423386);
						array28[0] = _0024_00245647_002423387;
						ParameterDeclarationCollection parameterDeclarationCollection20 = (method23.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array28));
						Method method24 = _0024_00245661_002423401;
						SimpleTypeReference simpleTypeReference28 = (_0024_00245648_002423388 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag114 = (_0024_00245648_002423388.IsPointer = false);
						string text234 = (_0024_00245648_002423388.Name = "ActionEnum");
						TypeReference typeReference66 = (method24.ReturnType = _0024_00245648_002423388);
						Method method25 = _0024_00245661_002423401;
						Block block37 = (_0024_00245660_002423400 = new Block(LexicalInfo.Empty));
						Block block38 = _0024_00245660_002423400;
						Statement[] array29 = new Statement[1];
						IfStatement ifStatement5 = (_0024_00245659_002423399 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement6 = _0024_00245659_002423399;
						MethodInvocationExpression methodInvocationExpression20 = (_0024_00245651_002423391 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression21 = _0024_00245651_002423391;
						MemberReferenceExpression memberReferenceExpression18 = (_0024_00245649_002423389 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text236 = (_0024_00245649_002423389.Name = "ContainsKey");
						Expression expression104 = (_0024_00245649_002423389.Target = Expression.Lift(_0024currentActionIdDic_002423236));
						Expression expression106 = (methodInvocationExpression21.Target = _0024_00245649_002423389);
						MethodInvocationExpression methodInvocationExpression22 = _0024_00245651_002423391;
						Expression[] array30 = new Expression[1];
						ReferenceExpression referenceExpression17 = (_0024_00245650_002423390 = new ReferenceExpression(LexicalInfo.Empty));
						string text238 = (_0024_00245650_002423390.Name = "grp");
						array30[0] = _0024_00245650_002423390;
						ExpressionCollection expressionCollection12 = (methodInvocationExpression22.Arguments = ExpressionCollection.FromArray(array30));
						Expression expression108 = (ifStatement6.Condition = _0024_00245651_002423391);
						IfStatement ifStatement7 = _0024_00245659_002423399;
						Block block39 = (_0024_00245656_002423396 = new Block(LexicalInfo.Empty));
						Block block40 = _0024_00245656_002423396;
						Statement[] array31 = new Statement[1];
						ReturnStatement returnStatement12 = (_0024_00245655_002423395 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement13 = _0024_00245655_002423395;
						SlicingExpression slicingExpression3 = (_0024_00245654_002423394 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression110 = (_0024_00245654_002423394.Target = Expression.Lift(_0024currentActionIdDic_002423236));
						SlicingExpression slicingExpression4 = _0024_00245654_002423394;
						Slice[] array32 = new Slice[1];
						Slice slice3 = (_0024_00245653_002423393 = new Slice(LexicalInfo.Empty));
						Slice slice4 = _0024_00245653_002423393;
						ReferenceExpression referenceExpression18 = (_0024_00245652_002423392 = new ReferenceExpression(LexicalInfo.Empty));
						string text240 = (_0024_00245652_002423392.Name = "grp");
						Expression expression112 = (slice4.Begin = _0024_00245652_002423392);
						array32[0] = _0024_00245653_002423393;
						SliceCollection sliceCollection4 = (slicingExpression4.Indices = SliceCollection.FromArray(array32));
						Expression expression114 = (returnStatement13.Expression = _0024_00245654_002423394);
						array31[0] = Statement.Lift(_0024_00245655_002423395);
						StatementCollection statementCollection20 = (block40.Statements = StatementCollection.FromArray(array31));
						Block block42 = (ifStatement7.TrueBlock = _0024_00245656_002423396);
						IfStatement ifStatement8 = _0024_00245659_002423399;
						Block block43 = (_0024_00245658_002423398 = new Block(LexicalInfo.Empty));
						Block block44 = _0024_00245658_002423398;
						Statement[] array33 = new Statement[1];
						ReturnStatement returnStatement14 = (_0024_00245657_002423397 = new ReturnStatement(LexicalInfo.Empty));
						Expression expression116 = (_0024_00245657_002423397.Expression = Expression.Lift(_0024noactEnum_002423233));
						array33[0] = Statement.Lift(_0024_00245657_002423397);
						StatementCollection statementCollection22 = (block44.Statements = StatementCollection.FromArray(array33));
						Block block46 = (ifStatement8.FalseBlock = _0024_00245658_002423398);
						array29[0] = Statement.Lift(_0024_00245659_002423399);
						StatementCollection statementCollection24 = (block38.Statements = StatementCollection.FromArray(array29));
						Block block48 = (method25.Body = _0024_00245660_002423400);
						array3[10] = _0024_00245661_002423401;
						Method method26 = (_0024_00245678_002423418 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers54 = (_0024_00245678_002423418.Modifiers = TypeMemberModifiers.Public);
						string text242 = (_0024_00245678_002423418.Name = "currActionTime");
						Method method27 = _0024_00245678_002423418;
						ParameterDeclaration[] array34 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration21 = (_0024_00245663_002423403 = new ParameterDeclaration(LexicalInfo.Empty));
						string text244 = (_0024_00245663_002423403.Name = "grp");
						ParameterDeclaration parameterDeclaration22 = _0024_00245663_002423403;
						SimpleTypeReference simpleTypeReference29 = (_0024_00245662_002423402 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag116 = (_0024_00245662_002423402.IsPointer = false);
						string text246 = (_0024_00245662_002423402.Name = "string");
						TypeReference typeReference68 = (parameterDeclaration22.Type = _0024_00245662_002423402);
						array34[0] = _0024_00245663_002423403;
						ParameterDeclarationCollection parameterDeclarationCollection22 = (method27.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array34));
						Method method28 = _0024_00245678_002423418;
						SimpleTypeReference simpleTypeReference30 = (_0024_00245664_002423404 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag118 = (_0024_00245664_002423404.IsPointer = false);
						string text248 = (_0024_00245664_002423404.Name = "single");
						TypeReference typeReference70 = (method28.ReturnType = _0024_00245664_002423404);
						Method method29 = _0024_00245678_002423418;
						Block block49 = (_0024_00245677_002423417 = new Block(LexicalInfo.Empty));
						Block block50 = _0024_00245677_002423417;
						Statement[] array35 = new Statement[1];
						IfStatement ifStatement9 = (_0024_00245676_002423416 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement10 = _0024_00245676_002423416;
						MethodInvocationExpression methodInvocationExpression23 = (_0024_00245667_002423407 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression24 = _0024_00245667_002423407;
						MemberReferenceExpression memberReferenceExpression19 = (_0024_00245665_002423405 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text250 = (_0024_00245665_002423405.Name = "ContainsKey");
						Expression expression118 = (_0024_00245665_002423405.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression120 = (methodInvocationExpression24.Target = _0024_00245665_002423405);
						MethodInvocationExpression methodInvocationExpression25 = _0024_00245667_002423407;
						Expression[] array36 = new Expression[1];
						ReferenceExpression referenceExpression19 = (_0024_00245666_002423406 = new ReferenceExpression(LexicalInfo.Empty));
						string text252 = (_0024_00245666_002423406.Name = "grp");
						array36[0] = _0024_00245666_002423406;
						ExpressionCollection expressionCollection14 = (methodInvocationExpression25.Arguments = ExpressionCollection.FromArray(array36));
						Expression expression122 = (ifStatement10.Condition = _0024_00245667_002423407);
						IfStatement ifStatement11 = _0024_00245676_002423416;
						Block block51 = (_0024_00245672_002423412 = new Block(LexicalInfo.Empty));
						Block block52 = _0024_00245672_002423412;
						Statement[] array37 = new Statement[1];
						ReturnStatement returnStatement15 = (_0024_00245671_002423411 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement16 = _0024_00245671_002423411;
						SlicingExpression slicingExpression5 = (_0024_00245670_002423410 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression124 = (_0024_00245670_002423410.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression6 = _0024_00245670_002423410;
						Slice[] array38 = new Slice[1];
						Slice slice5 = (_0024_00245669_002423409 = new Slice(LexicalInfo.Empty));
						Slice slice6 = _0024_00245669_002423409;
						ReferenceExpression referenceExpression20 = (_0024_00245668_002423408 = new ReferenceExpression(LexicalInfo.Empty));
						string text254 = (_0024_00245668_002423408.Name = "grp");
						Expression expression126 = (slice6.Begin = _0024_00245668_002423408);
						array38[0] = _0024_00245669_002423409;
						SliceCollection sliceCollection6 = (slicingExpression6.Indices = SliceCollection.FromArray(array38));
						Expression expression128 = (returnStatement16.Expression = new MemberReferenceExpression(_0024_00245670_002423410, CodeSerializer.LiftName(_0024actTimeVar_002423238)));
						array37[0] = Statement.Lift(_0024_00245671_002423411);
						StatementCollection statementCollection26 = (block52.Statements = StatementCollection.FromArray(array37));
						Block block54 = (ifStatement11.TrueBlock = _0024_00245672_002423412);
						IfStatement ifStatement12 = _0024_00245676_002423416;
						Block block55 = (_0024_00245675_002423415 = new Block(LexicalInfo.Empty));
						Block block56 = _0024_00245675_002423415;
						Statement[] array39 = new Statement[1];
						ReturnStatement returnStatement17 = (_0024_00245674_002423414 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement18 = _0024_00245674_002423414;
						DoubleLiteralExpression doubleLiteralExpression = (_0024_00245673_002423413 = new DoubleLiteralExpression(LexicalInfo.Empty));
						double num6 = (_0024_00245673_002423413.Value = 0.0);
						bool flag120 = (_0024_00245673_002423413.IsSingle = true);
						Expression expression130 = (returnStatement18.Expression = _0024_00245673_002423413);
						array39[0] = Statement.Lift(_0024_00245674_002423414);
						StatementCollection statementCollection28 = (block56.Statements = StatementCollection.FromArray(array39));
						Block block58 = (ifStatement12.FalseBlock = _0024_00245675_002423415);
						array35[0] = Statement.Lift(_0024_00245676_002423416);
						StatementCollection statementCollection30 = (block50.Statements = StatementCollection.FromArray(array35));
						Block block60 = (method29.Body = _0024_00245677_002423417);
						array3[11] = _0024_00245678_002423418;
						Method method30 = (_0024_00245695_002423435 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers56 = (_0024_00245695_002423435.Modifiers = TypeMemberModifiers.Public);
						string text256 = (_0024_00245695_002423435.Name = "currPreActionTime");
						Method method31 = _0024_00245695_002423435;
						ParameterDeclaration[] array40 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration23 = (_0024_00245680_002423420 = new ParameterDeclaration(LexicalInfo.Empty));
						string text258 = (_0024_00245680_002423420.Name = "grp");
						ParameterDeclaration parameterDeclaration24 = _0024_00245680_002423420;
						SimpleTypeReference simpleTypeReference31 = (_0024_00245679_002423419 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag122 = (_0024_00245679_002423419.IsPointer = false);
						string text260 = (_0024_00245679_002423419.Name = "string");
						TypeReference typeReference72 = (parameterDeclaration24.Type = _0024_00245679_002423419);
						array40[0] = _0024_00245680_002423420;
						ParameterDeclarationCollection parameterDeclarationCollection24 = (method31.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array40));
						Method method32 = _0024_00245695_002423435;
						SimpleTypeReference simpleTypeReference32 = (_0024_00245681_002423421 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag124 = (_0024_00245681_002423421.IsPointer = false);
						string text262 = (_0024_00245681_002423421.Name = "single");
						TypeReference typeReference74 = (method32.ReturnType = _0024_00245681_002423421);
						Method method33 = _0024_00245695_002423435;
						Block block61 = (_0024_00245694_002423434 = new Block(LexicalInfo.Empty));
						Block block62 = _0024_00245694_002423434;
						Statement[] array41 = new Statement[1];
						IfStatement ifStatement13 = (_0024_00245693_002423433 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement14 = _0024_00245693_002423433;
						MethodInvocationExpression methodInvocationExpression26 = (_0024_00245684_002423424 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression27 = _0024_00245684_002423424;
						MemberReferenceExpression memberReferenceExpression20 = (_0024_00245682_002423422 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text264 = (_0024_00245682_002423422.Name = "ContainsKey");
						Expression expression132 = (_0024_00245682_002423422.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression134 = (methodInvocationExpression27.Target = _0024_00245682_002423422);
						MethodInvocationExpression methodInvocationExpression28 = _0024_00245684_002423424;
						Expression[] array42 = new Expression[1];
						ReferenceExpression referenceExpression21 = (_0024_00245683_002423423 = new ReferenceExpression(LexicalInfo.Empty));
						string text266 = (_0024_00245683_002423423.Name = "grp");
						array42[0] = _0024_00245683_002423423;
						ExpressionCollection expressionCollection16 = (methodInvocationExpression28.Arguments = ExpressionCollection.FromArray(array42));
						Expression expression136 = (ifStatement14.Condition = _0024_00245684_002423424);
						IfStatement ifStatement15 = _0024_00245693_002423433;
						Block block63 = (_0024_00245689_002423429 = new Block(LexicalInfo.Empty));
						Block block64 = _0024_00245689_002423429;
						Statement[] array43 = new Statement[1];
						ReturnStatement returnStatement19 = (_0024_00245688_002423428 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement20 = _0024_00245688_002423428;
						SlicingExpression slicingExpression7 = (_0024_00245687_002423427 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression138 = (_0024_00245687_002423427.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression8 = _0024_00245687_002423427;
						Slice[] array44 = new Slice[1];
						Slice slice7 = (_0024_00245686_002423426 = new Slice(LexicalInfo.Empty));
						Slice slice8 = _0024_00245686_002423426;
						ReferenceExpression referenceExpression22 = (_0024_00245685_002423425 = new ReferenceExpression(LexicalInfo.Empty));
						string text268 = (_0024_00245685_002423425.Name = "grp");
						Expression expression140 = (slice8.Begin = _0024_00245685_002423425);
						array44[0] = _0024_00245686_002423426;
						SliceCollection sliceCollection8 = (slicingExpression8.Indices = SliceCollection.FromArray(array44));
						Expression expression142 = (returnStatement20.Expression = new MemberReferenceExpression(_0024_00245687_002423427, CodeSerializer.LiftName(_0024preActTimeVar_002423239)));
						array43[0] = Statement.Lift(_0024_00245688_002423428);
						StatementCollection statementCollection32 = (block64.Statements = StatementCollection.FromArray(array43));
						Block block66 = (ifStatement15.TrueBlock = _0024_00245689_002423429);
						IfStatement ifStatement16 = _0024_00245693_002423433;
						Block block67 = (_0024_00245692_002423432 = new Block(LexicalInfo.Empty));
						Block block68 = _0024_00245692_002423432;
						Statement[] array45 = new Statement[1];
						ReturnStatement returnStatement21 = (_0024_00245691_002423431 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement22 = _0024_00245691_002423431;
						DoubleLiteralExpression doubleLiteralExpression2 = (_0024_00245690_002423430 = new DoubleLiteralExpression(LexicalInfo.Empty));
						double num8 = (_0024_00245690_002423430.Value = 0.0);
						bool flag126 = (_0024_00245690_002423430.IsSingle = true);
						Expression expression144 = (returnStatement22.Expression = _0024_00245690_002423430);
						array45[0] = Statement.Lift(_0024_00245691_002423431);
						StatementCollection statementCollection34 = (block68.Statements = StatementCollection.FromArray(array45));
						Block block70 = (ifStatement16.FalseBlock = _0024_00245692_002423432);
						array41[0] = Statement.Lift(_0024_00245693_002423433);
						StatementCollection statementCollection36 = (block62.Statements = StatementCollection.FromArray(array41));
						Block block72 = (method33.Body = _0024_00245694_002423434);
						array3[12] = _0024_00245695_002423435;
						Method method34 = (_0024_00245712_002423452 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers58 = (_0024_00245712_002423452.Modifiers = TypeMemberModifiers.Public);
						string text270 = (_0024_00245712_002423452.Name = "currActionFrame");
						Method method35 = _0024_00245712_002423452;
						ParameterDeclaration[] array46 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration25 = (_0024_00245697_002423437 = new ParameterDeclaration(LexicalInfo.Empty));
						string text272 = (_0024_00245697_002423437.Name = "grp");
						ParameterDeclaration parameterDeclaration26 = _0024_00245697_002423437;
						SimpleTypeReference simpleTypeReference33 = (_0024_00245696_002423436 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag128 = (_0024_00245696_002423436.IsPointer = false);
						string text274 = (_0024_00245696_002423436.Name = "string");
						TypeReference typeReference76 = (parameterDeclaration26.Type = _0024_00245696_002423436);
						array46[0] = _0024_00245697_002423437;
						ParameterDeclarationCollection parameterDeclarationCollection26 = (method35.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array46));
						Method method36 = _0024_00245712_002423452;
						SimpleTypeReference simpleTypeReference34 = (_0024_00245698_002423438 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag130 = (_0024_00245698_002423438.IsPointer = false);
						string text276 = (_0024_00245698_002423438.Name = "single");
						TypeReference typeReference78 = (method36.ReturnType = _0024_00245698_002423438);
						Method method37 = _0024_00245712_002423452;
						Block block73 = (_0024_00245711_002423451 = new Block(LexicalInfo.Empty));
						Block block74 = _0024_00245711_002423451;
						Statement[] array47 = new Statement[1];
						IfStatement ifStatement17 = (_0024_00245710_002423450 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement18 = _0024_00245710_002423450;
						MethodInvocationExpression methodInvocationExpression29 = (_0024_00245701_002423441 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression30 = _0024_00245701_002423441;
						MemberReferenceExpression memberReferenceExpression21 = (_0024_00245699_002423439 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text278 = (_0024_00245699_002423439.Name = "ContainsKey");
						Expression expression146 = (_0024_00245699_002423439.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression148 = (methodInvocationExpression30.Target = _0024_00245699_002423439);
						MethodInvocationExpression methodInvocationExpression31 = _0024_00245701_002423441;
						Expression[] array48 = new Expression[1];
						ReferenceExpression referenceExpression23 = (_0024_00245700_002423440 = new ReferenceExpression(LexicalInfo.Empty));
						string text280 = (_0024_00245700_002423440.Name = "grp");
						array48[0] = _0024_00245700_002423440;
						ExpressionCollection expressionCollection18 = (methodInvocationExpression31.Arguments = ExpressionCollection.FromArray(array48));
						Expression expression150 = (ifStatement18.Condition = _0024_00245701_002423441);
						IfStatement ifStatement19 = _0024_00245710_002423450;
						Block block75 = (_0024_00245706_002423446 = new Block(LexicalInfo.Empty));
						Block block76 = _0024_00245706_002423446;
						Statement[] array49 = new Statement[1];
						ReturnStatement returnStatement23 = (_0024_00245705_002423445 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement24 = _0024_00245705_002423445;
						SlicingExpression slicingExpression9 = (_0024_00245704_002423444 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression152 = (_0024_00245704_002423444.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression10 = _0024_00245704_002423444;
						Slice[] array50 = new Slice[1];
						Slice slice9 = (_0024_00245703_002423443 = new Slice(LexicalInfo.Empty));
						Slice slice10 = _0024_00245703_002423443;
						ReferenceExpression referenceExpression24 = (_0024_00245702_002423442 = new ReferenceExpression(LexicalInfo.Empty));
						string text282 = (_0024_00245702_002423442.Name = "grp");
						Expression expression154 = (slice10.Begin = _0024_00245702_002423442);
						array50[0] = _0024_00245703_002423443;
						SliceCollection sliceCollection10 = (slicingExpression10.Indices = SliceCollection.FromArray(array50));
						Expression expression156 = (returnStatement24.Expression = new MemberReferenceExpression(_0024_00245704_002423444, CodeSerializer.LiftName(_0024actFrameVar_002423242)));
						array49[0] = Statement.Lift(_0024_00245705_002423445);
						StatementCollection statementCollection38 = (block76.Statements = StatementCollection.FromArray(array49));
						Block block78 = (ifStatement19.TrueBlock = _0024_00245706_002423446);
						IfStatement ifStatement20 = _0024_00245710_002423450;
						Block block79 = (_0024_00245709_002423449 = new Block(LexicalInfo.Empty));
						Block block80 = _0024_00245709_002423449;
						Statement[] array51 = new Statement[1];
						ReturnStatement returnStatement25 = (_0024_00245708_002423448 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement26 = _0024_00245708_002423448;
						DoubleLiteralExpression doubleLiteralExpression3 = (_0024_00245707_002423447 = new DoubleLiteralExpression(LexicalInfo.Empty));
						double num10 = (_0024_00245707_002423447.Value = 0.0);
						bool flag132 = (_0024_00245707_002423447.IsSingle = true);
						Expression expression158 = (returnStatement26.Expression = _0024_00245707_002423447);
						array51[0] = Statement.Lift(_0024_00245708_002423448);
						StatementCollection statementCollection40 = (block80.Statements = StatementCollection.FromArray(array51));
						Block block82 = (ifStatement20.FalseBlock = _0024_00245709_002423449);
						array47[0] = Statement.Lift(_0024_00245710_002423450);
						StatementCollection statementCollection42 = (block74.Statements = StatementCollection.FromArray(array47));
						Block block84 = (method37.Body = _0024_00245711_002423451);
						array3[13] = _0024_00245712_002423452;
						Method method38 = (_0024_00245729_002423469 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers60 = (_0024_00245729_002423469.Modifiers = TypeMemberModifiers.Public);
						string text284 = (_0024_00245729_002423469.Name = "isExecuting");
						Method method39 = _0024_00245729_002423469;
						ParameterDeclaration[] array52 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration27 = (_0024_00245714_002423454 = new ParameterDeclaration(LexicalInfo.Empty));
						string text286 = (_0024_00245714_002423454.Name = "aid");
						ParameterDeclaration parameterDeclaration28 = _0024_00245714_002423454;
						SimpleTypeReference simpleTypeReference35 = (_0024_00245713_002423453 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag134 = (_0024_00245713_002423453.IsPointer = false);
						string text288 = (_0024_00245713_002423453.Name = "ActionEnum");
						TypeReference typeReference80 = (parameterDeclaration28.Type = _0024_00245713_002423453);
						array52[0] = _0024_00245714_002423454;
						ParameterDeclarationCollection parameterDeclarationCollection28 = (method39.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array52));
						Method method40 = _0024_00245729_002423469;
						SimpleTypeReference simpleTypeReference36 = (_0024_00245715_002423455 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag136 = (_0024_00245715_002423455.IsPointer = false);
						string text290 = (_0024_00245715_002423455.Name = "bool");
						TypeReference typeReference82 = (method40.ReturnType = _0024_00245715_002423455);
						Method method41 = _0024_00245729_002423469;
						Block block85 = (_0024_00245728_002423468 = new Block(LexicalInfo.Empty));
						Block block86 = _0024_00245728_002423468;
						Statement[] array53 = new Statement[2];
						ForStatement forStatement5 = (_0024_00245725_002423465 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement6 = _0024_00245725_002423465;
						Declaration[] array54 = new Declaration[1];
						Declaration declaration2 = (_0024_00245716_002423456 = new Declaration(LexicalInfo.Empty));
						string text292 = (_0024_00245716_002423456.Name = "a");
						array54[0] = _0024_00245716_002423456;
						DeclarationCollection declarationCollection4 = (forStatement6.Declarations = DeclarationCollection.FromArray(array54));
						ForStatement forStatement7 = _0024_00245725_002423465;
						MemberReferenceExpression memberReferenceExpression22 = (_0024_00245717_002423457 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text294 = (_0024_00245717_002423457.Name = "Values");
						Expression expression160 = (_0024_00245717_002423457.Target = Expression.Lift(_0024currentActionIdDic_002423236));
						Expression expression162 = (forStatement7.Iterator = _0024_00245717_002423457);
						ForStatement forStatement8 = _0024_00245725_002423465;
						Block block87 = (_0024_00245724_002423464 = new Block(LexicalInfo.Empty));
						Block block88 = _0024_00245724_002423464;
						Statement[] array55 = new Statement[1];
						ReturnStatement returnStatement27 = (_0024_00245723_002423463 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement28 = _0024_00245723_002423463;
						StatementModifier statementModifier5 = (_0024_00245721_002423461 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType4 = (_0024_00245721_002423461.Type = StatementModifierType.If);
						StatementModifier statementModifier6 = _0024_00245721_002423461;
						BinaryExpression binaryExpression14 = (_0024_00245720_002423460 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType14 = (_0024_00245720_002423460.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression15 = _0024_00245720_002423460;
						ReferenceExpression referenceExpression25 = (_0024_00245718_002423458 = new ReferenceExpression(LexicalInfo.Empty));
						string text296 = (_0024_00245718_002423458.Name = "a");
						Expression expression164 = (binaryExpression15.Left = _0024_00245718_002423458);
						BinaryExpression binaryExpression16 = _0024_00245720_002423460;
						ReferenceExpression referenceExpression26 = (_0024_00245719_002423459 = new ReferenceExpression(LexicalInfo.Empty));
						string text298 = (_0024_00245719_002423459.Name = "aid");
						Expression expression166 = (binaryExpression16.Right = _0024_00245719_002423459);
						Expression expression168 = (statementModifier6.Condition = _0024_00245720_002423460);
						StatementModifier statementModifier8 = (returnStatement28.Modifier = _0024_00245721_002423461);
						ReturnStatement returnStatement29 = _0024_00245723_002423463;
						BoolLiteralExpression boolLiteralExpression2 = (_0024_00245722_002423462 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag138 = (_0024_00245722_002423462.Value = true);
						Expression expression170 = (returnStatement29.Expression = _0024_00245722_002423462);
						array55[0] = Statement.Lift(_0024_00245723_002423463);
						StatementCollection statementCollection44 = (block88.Statements = StatementCollection.FromArray(array55));
						Block block90 = (forStatement8.Block = _0024_00245724_002423464);
						array53[0] = Statement.Lift(_0024_00245725_002423465);
						ReturnStatement returnStatement30 = (_0024_00245727_002423467 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement31 = _0024_00245727_002423467;
						BoolLiteralExpression boolLiteralExpression3 = (_0024_00245726_002423466 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag140 = (_0024_00245726_002423466.Value = false);
						Expression expression172 = (returnStatement31.Expression = _0024_00245726_002423466);
						array53[1] = Statement.Lift(_0024_00245727_002423467);
						StatementCollection statementCollection46 = (block86.Statements = StatementCollection.FromArray(array53));
						Block block92 = (method41.Body = _0024_00245728_002423468);
						array3[14] = _0024_00245729_002423469;
						Method method42 = (_0024_00245759_002423499 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers62 = (_0024_00245759_002423499.Modifiers = TypeMemberModifiers.Public);
						string text300 = (_0024_00245759_002423499.Name = "isExecuting");
						Method method43 = _0024_00245759_002423499;
						ParameterDeclaration[] array56 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration29 = (_0024_00245731_002423471 = new ParameterDeclaration(LexicalInfo.Empty));
						string text302 = (_0024_00245731_002423471.Name = "act");
						ParameterDeclaration parameterDeclaration30 = _0024_00245731_002423471;
						SimpleTypeReference simpleTypeReference37 = (_0024_00245730_002423470 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag142 = (_0024_00245730_002423470.IsPointer = false);
						string text304 = (_0024_00245730_002423470.Name = "ActionBase");
						TypeReference typeReference84 = (parameterDeclaration30.Type = _0024_00245730_002423470);
						array56[0] = _0024_00245731_002423471;
						ParameterDeclarationCollection parameterDeclarationCollection30 = (method43.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array56));
						Method method44 = _0024_00245759_002423499;
						SimpleTypeReference simpleTypeReference38 = (_0024_00245732_002423472 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag144 = (_0024_00245732_002423472.IsPointer = false);
						string text306 = (_0024_00245732_002423472.Name = "bool");
						TypeReference typeReference86 = (method44.ReturnType = _0024_00245732_002423472);
						Method method45 = _0024_00245759_002423499;
						Block block93 = (_0024_00245758_002423498 = new Block(LexicalInfo.Empty));
						Block block94 = _0024_00245758_002423498;
						Statement[] array57 = new Statement[4];
						ReturnStatement returnStatement32 = (_0024_00245737_002423477 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement33 = _0024_00245737_002423477;
						StatementModifier statementModifier9 = (_0024_00245735_002423475 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType6 = (_0024_00245735_002423475.Type = StatementModifierType.If);
						StatementModifier statementModifier10 = _0024_00245735_002423475;
						BinaryExpression binaryExpression17 = (_0024_00245734_002423474 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType16 = (_0024_00245734_002423474.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression18 = _0024_00245734_002423474;
						ReferenceExpression referenceExpression27 = (_0024_00245733_002423473 = new ReferenceExpression(LexicalInfo.Empty));
						string text308 = (_0024_00245733_002423473.Name = "act");
						Expression expression174 = (binaryExpression18.Left = _0024_00245733_002423473);
						Expression expression176 = (_0024_00245734_002423474.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression178 = (statementModifier10.Condition = _0024_00245734_002423474);
						StatementModifier statementModifier12 = (returnStatement33.Modifier = _0024_00245735_002423475);
						ReturnStatement returnStatement34 = _0024_00245737_002423477;
						BoolLiteralExpression boolLiteralExpression4 = (_0024_00245736_002423476 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag146 = (_0024_00245736_002423476.Value = false);
						Expression expression180 = (returnStatement34.Expression = _0024_00245736_002423476);
						array57[0] = Statement.Lift(_0024_00245737_002423477);
						ReturnStatement returnStatement35 = (_0024_00245744_002423484 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement36 = _0024_00245744_002423484;
						StatementModifier statementModifier13 = (_0024_00245742_002423482 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType8 = (_0024_00245742_002423482.Type = StatementModifierType.If);
						StatementModifier statementModifier14 = _0024_00245742_002423482;
						MethodInvocationExpression methodInvocationExpression32 = (_0024_00245741_002423481 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression33 = _0024_00245741_002423481;
						MemberReferenceExpression memberReferenceExpression23 = (_0024_00245739_002423479 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text310 = (_0024_00245739_002423479.Name = "IsNullOrEmpty");
						MemberReferenceExpression memberReferenceExpression24 = _0024_00245739_002423479;
						ReferenceExpression referenceExpression28 = (_0024_00245738_002423478 = new ReferenceExpression(LexicalInfo.Empty));
						string text312 = (_0024_00245738_002423478.Name = "string");
						Expression expression182 = (memberReferenceExpression24.Target = _0024_00245738_002423478);
						Expression expression184 = (methodInvocationExpression33.Target = _0024_00245739_002423479);
						MethodInvocationExpression methodInvocationExpression34 = _0024_00245741_002423481;
						Expression[] array58 = new Expression[1];
						ReferenceExpression referenceExpression29 = (_0024_00245740_002423480 = new ReferenceExpression(LexicalInfo.Empty));
						string text314 = (_0024_00245740_002423480.Name = "act");
						array58[0] = new MemberReferenceExpression(_0024_00245740_002423480, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						ExpressionCollection expressionCollection20 = (methodInvocationExpression34.Arguments = ExpressionCollection.FromArray(array58));
						Expression expression186 = (statementModifier14.Condition = _0024_00245741_002423481);
						StatementModifier statementModifier16 = (returnStatement36.Modifier = _0024_00245742_002423482);
						ReturnStatement returnStatement37 = _0024_00245744_002423484;
						BoolLiteralExpression boolLiteralExpression5 = (_0024_00245743_002423483 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag148 = (_0024_00245743_002423483.Value = false);
						Expression expression188 = (returnStatement37.Expression = _0024_00245743_002423483);
						array57[1] = Statement.Lift(_0024_00245744_002423484);
						ReturnStatement returnStatement38 = (_0024_00245751_002423491 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement39 = _0024_00245751_002423491;
						StatementModifier statementModifier17 = (_0024_00245749_002423489 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType10 = (_0024_00245749_002423489.Type = StatementModifierType.If);
						StatementModifier statementModifier18 = _0024_00245749_002423489;
						UnaryExpression unaryExpression5 = (_0024_00245748_002423488 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType6 = (_0024_00245748_002423488.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression6 = _0024_00245748_002423488;
						MethodInvocationExpression methodInvocationExpression35 = (_0024_00245747_002423487 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression36 = _0024_00245747_002423487;
						MemberReferenceExpression memberReferenceExpression25 = (_0024_00245745_002423485 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text316 = (_0024_00245745_002423485.Name = "ContainsKey");
						Expression expression190 = (_0024_00245745_002423485.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression192 = (methodInvocationExpression36.Target = _0024_00245745_002423485);
						MethodInvocationExpression methodInvocationExpression37 = _0024_00245747_002423487;
						Expression[] array59 = new Expression[1];
						ReferenceExpression referenceExpression30 = (_0024_00245746_002423486 = new ReferenceExpression(LexicalInfo.Empty));
						string text318 = (_0024_00245746_002423486.Name = "act");
						array59[0] = new MemberReferenceExpression(_0024_00245746_002423486, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						ExpressionCollection expressionCollection22 = (methodInvocationExpression37.Arguments = ExpressionCollection.FromArray(array59));
						Expression expression194 = (unaryExpression6.Operand = _0024_00245747_002423487);
						Expression expression196 = (statementModifier18.Condition = _0024_00245748_002423488);
						StatementModifier statementModifier20 = (returnStatement39.Modifier = _0024_00245749_002423489);
						ReturnStatement returnStatement40 = _0024_00245751_002423491;
						BoolLiteralExpression boolLiteralExpression6 = (_0024_00245750_002423490 = new BoolLiteralExpression(LexicalInfo.Empty));
						bool flag150 = (_0024_00245750_002423490.Value = false);
						Expression expression198 = (returnStatement40.Expression = _0024_00245750_002423490);
						array57[2] = Statement.Lift(_0024_00245751_002423491);
						ReturnStatement returnStatement41 = (_0024_00245757_002423497 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement42 = _0024_00245757_002423497;
						BinaryExpression binaryExpression19 = (_0024_00245756_002423496 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType18 = (_0024_00245756_002423496.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression20 = _0024_00245756_002423496;
						ReferenceExpression referenceExpression31 = (_0024_00245752_002423492 = new ReferenceExpression(LexicalInfo.Empty));
						string text320 = (_0024_00245752_002423492.Name = "act");
						Expression expression200 = (binaryExpression20.Left = _0024_00245752_002423492);
						BinaryExpression binaryExpression21 = _0024_00245756_002423496;
						SlicingExpression slicingExpression11 = (_0024_00245755_002423495 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression202 = (_0024_00245755_002423495.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression12 = _0024_00245755_002423495;
						Slice[] array60 = new Slice[1];
						Slice slice11 = (_0024_00245754_002423494 = new Slice(LexicalInfo.Empty));
						Slice slice12 = _0024_00245754_002423494;
						ReferenceExpression referenceExpression32 = (_0024_00245753_002423493 = new ReferenceExpression(LexicalInfo.Empty));
						string text322 = (_0024_00245753_002423493.Name = "act");
						Expression expression204 = (slice12.Begin = new MemberReferenceExpression(_0024_00245753_002423493, CodeSerializer.LiftName(_0024self__002423859.actionGroupName)));
						array60[0] = _0024_00245754_002423494;
						SliceCollection sliceCollection12 = (slicingExpression12.Indices = SliceCollection.FromArray(array60));
						Expression expression206 = (binaryExpression21.Right = _0024_00245755_002423495);
						Expression expression208 = (returnStatement42.Expression = _0024_00245756_002423496);
						array57[3] = Statement.Lift(_0024_00245757_002423497);
						StatementCollection statementCollection48 = (block94.Statements = StatementCollection.FromArray(array57));
						Block block96 = (method45.Body = _0024_00245758_002423498);
						array3[15] = _0024_00245759_002423499;
						Method method46 = (_0024_00245773_002423513 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers64 = (_0024_00245773_002423513.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
						string text324 = (_0024_00245773_002423513.Name = "IsValidActionID");
						Method method47 = _0024_00245773_002423513;
						ParameterDeclaration[] array61 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration31 = (_0024_00245761_002423501 = new ParameterDeclaration(LexicalInfo.Empty));
						string text326 = (_0024_00245761_002423501.Name = "aid");
						ParameterDeclaration parameterDeclaration32 = _0024_00245761_002423501;
						SimpleTypeReference simpleTypeReference39 = (_0024_00245760_002423500 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag152 = (_0024_00245760_002423500.IsPointer = false);
						string text328 = (_0024_00245760_002423500.Name = "ActionEnum");
						TypeReference typeReference88 = (parameterDeclaration32.Type = _0024_00245760_002423500);
						array61[0] = _0024_00245761_002423501;
						ParameterDeclarationCollection parameterDeclarationCollection32 = (method47.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array61));
						Method method48 = _0024_00245773_002423513;
						SimpleTypeReference simpleTypeReference40 = (_0024_00245762_002423502 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag154 = (_0024_00245762_002423502.IsPointer = false);
						string text330 = (_0024_00245762_002423502.Name = "bool");
						TypeReference typeReference90 = (method48.ReturnType = _0024_00245762_002423502);
						Method method49 = _0024_00245773_002423513;
						Block block97 = (_0024_00245772_002423512 = new Block(LexicalInfo.Empty));
						Block block98 = _0024_00245772_002423512;
						Statement[] array62 = new Statement[1];
						ReturnStatement returnStatement43 = (_0024_00245771_002423511 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement44 = _0024_00245771_002423511;
						BinaryExpression binaryExpression22 = (_0024_00245770_002423510 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType20 = (_0024_00245770_002423510.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression23 = _0024_00245770_002423510;
						BinaryExpression binaryExpression24 = (_0024_00245765_002423505 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType22 = (_0024_00245765_002423505.Operator = BinaryOperatorType.LessThanOrEqual);
						BinaryExpression binaryExpression25 = _0024_00245765_002423505;
						IntegerLiteralExpression integerLiteralExpression3 = (_0024_00245763_002423503 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num12 = (_0024_00245763_002423503.Value = 0L);
						bool flag156 = (_0024_00245763_002423503.IsLong = false);
						Expression expression210 = (binaryExpression25.Left = _0024_00245763_002423503);
						BinaryExpression binaryExpression26 = _0024_00245765_002423505;
						ReferenceExpression referenceExpression33 = (_0024_00245764_002423504 = new ReferenceExpression(LexicalInfo.Empty));
						string text332 = (_0024_00245764_002423504.Name = "aid");
						Expression expression212 = (binaryExpression26.Right = _0024_00245764_002423504);
						Expression expression214 = (binaryExpression23.Left = _0024_00245765_002423505);
						BinaryExpression binaryExpression27 = _0024_00245770_002423510;
						BinaryExpression binaryExpression28 = (_0024_00245769_002423509 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType24 = (_0024_00245769_002423509.Operator = BinaryOperatorType.LessThan);
						BinaryExpression binaryExpression29 = _0024_00245769_002423509;
						ReferenceExpression referenceExpression34 = (_0024_00245766_002423506 = new ReferenceExpression(LexicalInfo.Empty));
						string text334 = (_0024_00245766_002423506.Name = "aid");
						Expression expression216 = (binaryExpression29.Left = _0024_00245766_002423506);
						BinaryExpression binaryExpression30 = _0024_00245769_002423509;
						MemberReferenceExpression memberReferenceExpression26 = (_0024_00245768_002423508 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text336 = (_0024_00245768_002423508.Name = "NUM");
						MemberReferenceExpression memberReferenceExpression27 = _0024_00245768_002423508;
						ReferenceExpression referenceExpression35 = (_0024_00245767_002423507 = new ReferenceExpression(LexicalInfo.Empty));
						string text338 = (_0024_00245767_002423507.Name = "ActionEnum");
						Expression expression218 = (memberReferenceExpression27.Target = _0024_00245767_002423507);
						Expression expression220 = (binaryExpression30.Right = _0024_00245768_002423508);
						Expression expression222 = (binaryExpression27.Right = _0024_00245769_002423509);
						Expression expression224 = (returnStatement44.Expression = _0024_00245770_002423510);
						array62[0] = Statement.Lift(_0024_00245771_002423511);
						StatementCollection statementCollection50 = (block98.Statements = StatementCollection.FromArray(array62));
						Block block100 = (method49.Body = _0024_00245772_002423512);
						array3[16] = _0024_00245773_002423513;
						Method method50 = (_0024_00245799_002423539 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers66 = (_0024_00245799_002423539.Modifiers = TypeMemberModifiers.Protected);
						string text340 = (_0024_00245799_002423539.Name = "setCurrAction");
						Method method51 = _0024_00245799_002423539;
						ParameterDeclaration[] array63 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration33 = (_0024_00245775_002423515 = new ParameterDeclaration(LexicalInfo.Empty));
						string text342 = (_0024_00245775_002423515.Name = "act");
						ParameterDeclaration parameterDeclaration34 = _0024_00245775_002423515;
						SimpleTypeReference simpleTypeReference41 = (_0024_00245774_002423514 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag158 = (_0024_00245774_002423514.IsPointer = false);
						string text344 = (_0024_00245774_002423514.Name = "ActionBase");
						TypeReference typeReference92 = (parameterDeclaration34.Type = _0024_00245774_002423514);
						array63[0] = _0024_00245775_002423515;
						ParameterDeclarationCollection parameterDeclarationCollection34 = (method51.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array63));
						Method method52 = _0024_00245799_002423539;
						Block block101 = (_0024_00245798_002423538 = new Block(LexicalInfo.Empty));
						Block block102 = _0024_00245798_002423538;
						Statement[] array64 = new Statement[5];
						ReturnStatement returnStatement45 = (_0024_00245779_002423519 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement46 = _0024_00245779_002423519;
						StatementModifier statementModifier21 = (_0024_00245778_002423518 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType12 = (_0024_00245778_002423518.Type = StatementModifierType.If);
						StatementModifier statementModifier22 = _0024_00245778_002423518;
						BinaryExpression binaryExpression31 = (_0024_00245777_002423517 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType26 = (_0024_00245777_002423517.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression32 = _0024_00245777_002423517;
						ReferenceExpression referenceExpression36 = (_0024_00245776_002423516 = new ReferenceExpression(LexicalInfo.Empty));
						string text346 = (_0024_00245776_002423516.Name = "act");
						Expression expression226 = (binaryExpression32.Left = _0024_00245776_002423516);
						Expression expression228 = (_0024_00245777_002423517.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression230 = (statementModifier22.Condition = _0024_00245777_002423517);
						StatementModifier statementModifier24 = (returnStatement46.Modifier = _0024_00245778_002423518);
						array64[0] = Statement.Lift(_0024_00245779_002423519);
						MacroStatement macroStatement = (_0024_00245785_002423525 = new MacroStatement(LexicalInfo.Empty));
						string text348 = (_0024_00245785_002423525.Name = "assert");
						MacroStatement macroStatement2 = _0024_00245785_002423525;
						Expression[] array65 = new Expression[1];
						UnaryExpression unaryExpression7 = (_0024_00245784_002423524 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType8 = (_0024_00245784_002423524.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression8 = _0024_00245784_002423524;
						MethodInvocationExpression methodInvocationExpression38 = (_0024_00245783_002423523 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression39 = _0024_00245783_002423523;
						MemberReferenceExpression memberReferenceExpression28 = (_0024_00245781_002423521 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text350 = (_0024_00245781_002423521.Name = "IsNullOrEmpty");
						MemberReferenceExpression memberReferenceExpression29 = _0024_00245781_002423521;
						ReferenceExpression referenceExpression37 = (_0024_00245780_002423520 = new ReferenceExpression(LexicalInfo.Empty));
						string text352 = (_0024_00245780_002423520.Name = "string");
						Expression expression232 = (memberReferenceExpression29.Target = _0024_00245780_002423520);
						Expression expression234 = (methodInvocationExpression39.Target = _0024_00245781_002423521);
						MethodInvocationExpression methodInvocationExpression40 = _0024_00245783_002423523;
						Expression[] array66 = new Expression[1];
						ReferenceExpression referenceExpression38 = (_0024_00245782_002423522 = new ReferenceExpression(LexicalInfo.Empty));
						string text354 = (_0024_00245782_002423522.Name = "act");
						array66[0] = new MemberReferenceExpression(_0024_00245782_002423522, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						ExpressionCollection expressionCollection24 = (methodInvocationExpression40.Arguments = ExpressionCollection.FromArray(array66));
						Expression expression236 = (unaryExpression8.Operand = _0024_00245783_002423523);
						array65[0] = _0024_00245784_002423524;
						ExpressionCollection expressionCollection26 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array65));
						Block block104 = (_0024_00245785_002423525.Body = new Block(LexicalInfo.Empty));
						array64[1] = Statement.Lift(_0024_00245785_002423525);
						BinaryExpression binaryExpression33 = (_0024_00245790_002423530 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType28 = (_0024_00245790_002423530.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression34 = _0024_00245790_002423530;
						SlicingExpression slicingExpression13 = (_0024_00245788_002423528 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression238 = (_0024_00245788_002423528.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression14 = _0024_00245788_002423528;
						Slice[] array67 = new Slice[1];
						Slice slice13 = (_0024_00245787_002423527 = new Slice(LexicalInfo.Empty));
						Slice slice14 = _0024_00245787_002423527;
						ReferenceExpression referenceExpression39 = (_0024_00245786_002423526 = new ReferenceExpression(LexicalInfo.Empty));
						string text356 = (_0024_00245786_002423526.Name = "act");
						Expression expression240 = (slice14.Begin = new MemberReferenceExpression(_0024_00245786_002423526, CodeSerializer.LiftName(_0024self__002423859.actionGroupName)));
						array67[0] = _0024_00245787_002423527;
						SliceCollection sliceCollection14 = (slicingExpression14.Indices = SliceCollection.FromArray(array67));
						Expression expression242 = (binaryExpression34.Left = _0024_00245788_002423528);
						BinaryExpression binaryExpression35 = _0024_00245790_002423530;
						ReferenceExpression referenceExpression40 = (_0024_00245789_002423529 = new ReferenceExpression(LexicalInfo.Empty));
						string text358 = (_0024_00245789_002423529.Name = "act");
						Expression expression244 = (binaryExpression35.Right = _0024_00245789_002423529);
						array64[2] = Statement.Lift(_0024_00245790_002423530);
						BinaryExpression binaryExpression36 = (_0024_00245795_002423535 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType30 = (_0024_00245795_002423535.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression37 = _0024_00245795_002423535;
						SlicingExpression slicingExpression15 = (_0024_00245793_002423533 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression246 = (_0024_00245793_002423533.Target = Expression.Lift(_0024currentActionIdDic_002423236));
						SlicingExpression slicingExpression16 = _0024_00245793_002423533;
						Slice[] array68 = new Slice[1];
						Slice slice15 = (_0024_00245792_002423532 = new Slice(LexicalInfo.Empty));
						Slice slice16 = _0024_00245792_002423532;
						ReferenceExpression referenceExpression41 = (_0024_00245791_002423531 = new ReferenceExpression(LexicalInfo.Empty));
						string text360 = (_0024_00245791_002423531.Name = "act");
						Expression expression248 = (slice16.Begin = new MemberReferenceExpression(_0024_00245791_002423531, CodeSerializer.LiftName(_0024self__002423859.actionGroupName)));
						array68[0] = _0024_00245792_002423532;
						SliceCollection sliceCollection16 = (slicingExpression16.Indices = SliceCollection.FromArray(array68));
						Expression expression250 = (binaryExpression37.Left = _0024_00245793_002423533);
						BinaryExpression binaryExpression38 = _0024_00245795_002423535;
						ReferenceExpression referenceExpression42 = (_0024_00245794_002423534 = new ReferenceExpression(LexicalInfo.Empty));
						string text362 = (_0024_00245794_002423534.Name = "act");
						Expression expression252 = (binaryExpression38.Right = new MemberReferenceExpression(_0024_00245794_002423534, CodeSerializer.LiftName(_0024self__002423859.actionIdName)));
						array64[3] = Statement.Lift(_0024_00245795_002423535);
						BinaryExpression binaryExpression39 = (_0024_00245797_002423537 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType32 = (_0024_00245797_002423537.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression40 = _0024_00245797_002423537;
						ReferenceExpression referenceExpression43 = (_0024_00245796_002423536 = new ReferenceExpression(LexicalInfo.Empty));
						string text364 = (_0024_00245796_002423536.Name = "act");
						Expression expression254 = (binaryExpression40.Left = new MemberReferenceExpression(_0024_00245796_002423536, CodeSerializer.LiftName(_0024realActInitTimeVar_002423241)));
						Expression expression256 = (_0024_00245797_002423537.Right = Expression.Lift(_0024nowTimeVar_002423244));
						array64[4] = Statement.Lift(_0024_00245797_002423537);
						StatementCollection statementCollection52 = (block102.Statements = StatementCollection.FromArray(array64));
						Block block106 = (method52.Body = _0024_00245798_002423538);
						array3[17] = _0024_00245799_002423539;
						Method method53 = (_0024_00245897_002423637 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers68 = (_0024_00245897_002423637.Modifiers = TypeMemberModifiers.Protected);
						string text366 = (_0024_00245897_002423637.Name = "changeAction");
						Method method54 = _0024_00245897_002423637;
						ParameterDeclaration[] array69 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration35 = (_0024_00245801_002423541 = new ParameterDeclaration(LexicalInfo.Empty));
						string text368 = (_0024_00245801_002423541.Name = "act");
						ParameterDeclaration parameterDeclaration36 = _0024_00245801_002423541;
						SimpleTypeReference simpleTypeReference42 = (_0024_00245800_002423540 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag160 = (_0024_00245800_002423540.IsPointer = false);
						string text370 = (_0024_00245800_002423540.Name = "ActionBase");
						TypeReference typeReference94 = (parameterDeclaration36.Type = _0024_00245800_002423540);
						array69[0] = _0024_00245801_002423541;
						ParameterDeclarationCollection parameterDeclarationCollection36 = (method54.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array69));
						Method method55 = _0024_00245897_002423637;
						Block block107 = (_0024_00245896_002423636 = new Block(LexicalInfo.Empty));
						Block block108 = _0024_00245896_002423636;
						Statement[] array70 = new Statement[10];
						IfStatement ifStatement21 = (_0024_00245810_002423550 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement22 = _0024_00245810_002423550;
						BinaryExpression binaryExpression41 = (_0024_00245803_002423543 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType34 = (_0024_00245803_002423543.Operator = BinaryOperatorType.GreaterThan);
						BinaryExpression binaryExpression42 = _0024_00245803_002423543;
						UnaryExpression unaryExpression9 = (_0024_00245802_002423542 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType10 = (_0024_00245802_002423542.Operator = UnaryOperatorType.Increment);
						Expression expression258 = (_0024_00245802_002423542.Operand = Expression.Lift(_0024changeNumVar_002423234));
						Expression expression260 = (binaryExpression42.Left = _0024_00245802_002423542);
						Expression expression262 = (_0024_00245803_002423543.Right = Expression.Lift(100));
						Expression expression264 = (ifStatement22.Condition = _0024_00245803_002423543);
						IfStatement ifStatement23 = _0024_00245810_002423550;
						Block block109 = (_0024_00245809_002423549 = new Block(LexicalInfo.Empty));
						Block block110 = _0024_00245809_002423549;
						Statement[] array71 = new Statement[1];
						RaiseStatement raiseStatement = (_0024_00245808_002423548 = new RaiseStatement(LexicalInfo.Empty));
						RaiseStatement raiseStatement2 = _0024_00245808_002423548;
						BinaryExpression binaryExpression43 = (_0024_00245807_002423547 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType36 = (_0024_00245807_002423547.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression44 = _0024_00245807_002423547;
						BinaryExpression binaryExpression45 = (_0024_00245805_002423545 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType38 = (_0024_00245805_002423545.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression46 = _0024_00245805_002423545;
						StringLiteralExpression stringLiteralExpression = (_0024_00245804_002423544 = new StringLiteralExpression(LexicalInfo.Empty));
						string text372 = (_0024_00245804_002423544.Value = "update無しに");
						Expression expression266 = (binaryExpression46.Left = _0024_00245804_002423544);
						Expression expression268 = (_0024_00245805_002423545.Right = Expression.Lift(100));
						Expression expression270 = (binaryExpression44.Left = _0024_00245805_002423545);
						BinaryExpression binaryExpression47 = _0024_00245807_002423547;
						StringLiteralExpression stringLiteralExpression2 = (_0024_00245806_002423546 = new StringLiteralExpression(LexicalInfo.Empty));
						string text374 = (_0024_00245806_002423546.Value = "回以上action遷移しました");
						Expression expression272 = (binaryExpression47.Right = _0024_00245806_002423546);
						Expression expression274 = (raiseStatement2.Exception = _0024_00245807_002423547);
						array71[0] = Statement.Lift(_0024_00245808_002423548);
						StatementCollection statementCollection54 = (block110.Statements = StatementCollection.FromArray(array71));
						Block block112 = (ifStatement23.TrueBlock = _0024_00245809_002423549);
						array70[0] = Statement.Lift(_0024_00245810_002423550);
						BinaryExpression binaryExpression48 = (_0024_00245815_002423555 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType40 = (_0024_00245815_002423555.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression49 = _0024_00245815_002423555;
						ReferenceExpression referenceExpression44 = (_0024_00245811_002423551 = new ReferenceExpression(LexicalInfo.Empty));
						string text376 = (_0024_00245811_002423551.Name = "curr");
						Expression expression276 = (binaryExpression49.Left = _0024_00245811_002423551);
						BinaryExpression binaryExpression50 = _0024_00245815_002423555;
						MethodInvocationExpression methodInvocationExpression41 = (_0024_00245814_002423554 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression42 = _0024_00245814_002423554;
						ReferenceExpression referenceExpression45 = (_0024_00245812_002423552 = new ReferenceExpression(LexicalInfo.Empty));
						string text378 = (_0024_00245812_002423552.Name = "currAction");
						Expression expression278 = (methodInvocationExpression42.Target = _0024_00245812_002423552);
						MethodInvocationExpression methodInvocationExpression43 = _0024_00245814_002423554;
						Expression[] array72 = new Expression[1];
						ReferenceExpression referenceExpression46 = (_0024_00245813_002423553 = new ReferenceExpression(LexicalInfo.Empty));
						string text380 = (_0024_00245813_002423553.Name = "act");
						array72[0] = new MemberReferenceExpression(_0024_00245813_002423553, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						ExpressionCollection expressionCollection28 = (methodInvocationExpression43.Arguments = ExpressionCollection.FromArray(array72));
						Expression expression280 = (binaryExpression50.Right = _0024_00245814_002423554);
						array70[1] = Statement.Lift(_0024_00245815_002423555);
						ReturnStatement returnStatement47 = (_0024_00245823_002423563 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement48 = _0024_00245823_002423563;
						StatementModifier statementModifier25 = (_0024_00245822_002423562 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType14 = (_0024_00245822_002423562.Type = StatementModifierType.If);
						StatementModifier statementModifier26 = _0024_00245822_002423562;
						BinaryExpression binaryExpression51 = (_0024_00245821_002423561 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType42 = (_0024_00245821_002423561.Operator = BinaryOperatorType.Or);
						BinaryExpression binaryExpression52 = _0024_00245821_002423561;
						BinaryExpression binaryExpression53 = (_0024_00245817_002423557 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType44 = (_0024_00245817_002423557.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression54 = _0024_00245817_002423557;
						ReferenceExpression referenceExpression47 = (_0024_00245816_002423556 = new ReferenceExpression(LexicalInfo.Empty));
						string text382 = (_0024_00245816_002423556.Name = "act");
						Expression expression282 = (binaryExpression54.Left = _0024_00245816_002423556);
						Expression expression284 = (_0024_00245817_002423557.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression286 = (binaryExpression52.Left = _0024_00245817_002423557);
						BinaryExpression binaryExpression55 = _0024_00245821_002423561;
						BinaryExpression binaryExpression56 = (_0024_00245820_002423560 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType46 = (_0024_00245820_002423560.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression57 = _0024_00245820_002423560;
						ReferenceExpression referenceExpression48 = (_0024_00245818_002423558 = new ReferenceExpression(LexicalInfo.Empty));
						string text384 = (_0024_00245818_002423558.Name = "curr");
						Expression expression288 = (binaryExpression57.Left = _0024_00245818_002423558);
						BinaryExpression binaryExpression58 = _0024_00245820_002423560;
						ReferenceExpression referenceExpression49 = (_0024_00245819_002423559 = new ReferenceExpression(LexicalInfo.Empty));
						string text386 = (_0024_00245819_002423559.Name = "act");
						Expression expression290 = (binaryExpression58.Right = _0024_00245819_002423559);
						Expression expression292 = (binaryExpression55.Right = _0024_00245820_002423560);
						Expression expression294 = (statementModifier26.Condition = _0024_00245821_002423561);
						StatementModifier statementModifier28 = (returnStatement48.Modifier = _0024_00245822_002423562);
						array70[2] = Statement.Lift(_0024_00245823_002423563);
						IfStatement ifStatement24 = (_0024_00245851_002423591 = new IfStatement(LexicalInfo.Empty));
						Expression expression296 = (_0024_00245851_002423591.Condition = Expression.Lift(_0024debugFlagVar_002423235));
						IfStatement ifStatement25 = _0024_00245851_002423591;
						Block block113 = (_0024_00245850_002423590 = new Block(LexicalInfo.Empty));
						Block block114 = _0024_00245850_002423590;
						Statement[] array73 = new Statement[1];
						IfStatement ifStatement26 = (_0024_00245849_002423589 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement27 = _0024_00245849_002423589;
						BinaryExpression binaryExpression59 = (_0024_00245825_002423565 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType48 = (_0024_00245825_002423565.Operator = BinaryOperatorType.Equality);
						BinaryExpression binaryExpression60 = _0024_00245825_002423565;
						ReferenceExpression referenceExpression50 = (_0024_00245824_002423564 = new ReferenceExpression(LexicalInfo.Empty));
						string text388 = (_0024_00245824_002423564.Name = "curr");
						Expression expression298 = (binaryExpression60.Left = _0024_00245824_002423564);
						Expression expression300 = (_0024_00245825_002423565.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression302 = (ifStatement27.Condition = _0024_00245825_002423565);
						IfStatement ifStatement28 = _0024_00245849_002423589;
						Block block115 = (_0024_00245835_002423575 = new Block(LexicalInfo.Empty));
						Block block116 = _0024_00245835_002423575;
						Statement[] array74 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression44 = (_0024_00245834_002423574 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression45 = _0024_00245834_002423574;
						ReferenceExpression referenceExpression51 = (_0024_00245826_002423566 = new ReferenceExpression(LexicalInfo.Empty));
						string text390 = (_0024_00245826_002423566.Name = "print");
						Expression expression304 = (methodInvocationExpression45.Target = _0024_00245826_002423566);
						MethodInvocationExpression methodInvocationExpression46 = _0024_00245834_002423574;
						Expression[] array75 = new Expression[1];
						ExpressionInterpolationExpression expressionInterpolationExpression = (_0024_00245833_002423573 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
						ExpressionInterpolationExpression expressionInterpolationExpression2 = _0024_00245833_002423573;
						Expression[] array76 = new Expression[5];
						StringLiteralExpression stringLiteralExpression3 = (_0024_00245827_002423567 = new StringLiteralExpression(LexicalInfo.Empty));
						string text392 = (_0024_00245827_002423567.Value = "act_method: change <no action> -> ");
						array76[0] = _0024_00245827_002423567;
						MemberReferenceExpression memberReferenceExpression30 = (_0024_00245829_002423569 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text394 = (_0024_00245829_002423569.Name = "myName");
						MemberReferenceExpression memberReferenceExpression31 = _0024_00245829_002423569;
						ReferenceExpression referenceExpression52 = (_0024_00245828_002423568 = new ReferenceExpression(LexicalInfo.Empty));
						string text396 = (_0024_00245828_002423568.Name = "act");
						Expression expression306 = (memberReferenceExpression31.Target = _0024_00245828_002423568);
						array76[1] = _0024_00245829_002423569;
						StringLiteralExpression stringLiteralExpression4 = (_0024_00245830_002423570 = new StringLiteralExpression(LexicalInfo.Empty));
						string text398 = (_0024_00245830_002423570.Value = " (group: ");
						array76[2] = _0024_00245830_002423570;
						ReferenceExpression referenceExpression53 = (_0024_00245831_002423571 = new ReferenceExpression(LexicalInfo.Empty));
						string text400 = (_0024_00245831_002423571.Name = "act");
						array76[3] = new MemberReferenceExpression(_0024_00245831_002423571, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						StringLiteralExpression stringLiteralExpression5 = (_0024_00245832_002423572 = new StringLiteralExpression(LexicalInfo.Empty));
						string text402 = (_0024_00245832_002423572.Value = ")");
						array76[4] = _0024_00245832_002423572;
						ExpressionCollection expressionCollection30 = (expressionInterpolationExpression2.Expressions = ExpressionCollection.FromArray(array76));
						array75[0] = _0024_00245833_002423573;
						ExpressionCollection expressionCollection32 = (methodInvocationExpression46.Arguments = ExpressionCollection.FromArray(array75));
						array74[0] = Statement.Lift(_0024_00245834_002423574);
						StatementCollection statementCollection56 = (block116.Statements = StatementCollection.FromArray(array74));
						Block block118 = (ifStatement28.TrueBlock = _0024_00245835_002423575);
						IfStatement ifStatement29 = _0024_00245849_002423589;
						Block block119 = (_0024_00245848_002423588 = new Block(LexicalInfo.Empty));
						Block block120 = _0024_00245848_002423588;
						Statement[] array77 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression47 = (_0024_00245847_002423587 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression48 = _0024_00245847_002423587;
						ReferenceExpression referenceExpression54 = (_0024_00245836_002423576 = new ReferenceExpression(LexicalInfo.Empty));
						string text404 = (_0024_00245836_002423576.Name = "print");
						Expression expression308 = (methodInvocationExpression48.Target = _0024_00245836_002423576);
						MethodInvocationExpression methodInvocationExpression49 = _0024_00245847_002423587;
						Expression[] array78 = new Expression[1];
						ExpressionInterpolationExpression expressionInterpolationExpression3 = (_0024_00245846_002423586 = new ExpressionInterpolationExpression(LexicalInfo.Empty));
						ExpressionInterpolationExpression expressionInterpolationExpression4 = _0024_00245846_002423586;
						Expression[] array79 = new Expression[7];
						StringLiteralExpression stringLiteralExpression6 = (_0024_00245837_002423577 = new StringLiteralExpression(LexicalInfo.Empty));
						string text406 = (_0024_00245837_002423577.Value = "act_method: change ");
						array79[0] = _0024_00245837_002423577;
						MemberReferenceExpression memberReferenceExpression32 = (_0024_00245839_002423579 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text408 = (_0024_00245839_002423579.Name = "myName");
						MemberReferenceExpression memberReferenceExpression33 = _0024_00245839_002423579;
						ReferenceExpression referenceExpression55 = (_0024_00245838_002423578 = new ReferenceExpression(LexicalInfo.Empty));
						string text410 = (_0024_00245838_002423578.Name = "curr");
						Expression expression310 = (memberReferenceExpression33.Target = _0024_00245838_002423578);
						array79[1] = _0024_00245839_002423579;
						StringLiteralExpression stringLiteralExpression7 = (_0024_00245840_002423580 = new StringLiteralExpression(LexicalInfo.Empty));
						string text412 = (_0024_00245840_002423580.Value = " -> ");
						array79[2] = _0024_00245840_002423580;
						MemberReferenceExpression memberReferenceExpression34 = (_0024_00245842_002423582 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text414 = (_0024_00245842_002423582.Name = "myName");
						MemberReferenceExpression memberReferenceExpression35 = _0024_00245842_002423582;
						ReferenceExpression referenceExpression56 = (_0024_00245841_002423581 = new ReferenceExpression(LexicalInfo.Empty));
						string text416 = (_0024_00245841_002423581.Name = "act");
						Expression expression312 = (memberReferenceExpression35.Target = _0024_00245841_002423581);
						array79[3] = _0024_00245842_002423582;
						StringLiteralExpression stringLiteralExpression8 = (_0024_00245843_002423583 = new StringLiteralExpression(LexicalInfo.Empty));
						string text418 = (_0024_00245843_002423583.Value = " (group: ");
						array79[4] = _0024_00245843_002423583;
						ReferenceExpression referenceExpression57 = (_0024_00245844_002423584 = new ReferenceExpression(LexicalInfo.Empty));
						string text420 = (_0024_00245844_002423584.Name = "act");
						array79[5] = new MemberReferenceExpression(_0024_00245844_002423584, CodeSerializer.LiftName(_0024self__002423859.actionGroupName));
						StringLiteralExpression stringLiteralExpression9 = (_0024_00245845_002423585 = new StringLiteralExpression(LexicalInfo.Empty));
						string text422 = (_0024_00245845_002423585.Value = ")");
						array79[6] = _0024_00245845_002423585;
						ExpressionCollection expressionCollection34 = (expressionInterpolationExpression4.Expressions = ExpressionCollection.FromArray(array79));
						array78[0] = _0024_00245846_002423586;
						ExpressionCollection expressionCollection36 = (methodInvocationExpression49.Arguments = ExpressionCollection.FromArray(array78));
						array77[0] = Statement.Lift(_0024_00245847_002423587);
						StatementCollection statementCollection58 = (block120.Statements = StatementCollection.FromArray(array77));
						Block block122 = (ifStatement29.FalseBlock = _0024_00245848_002423588);
						array73[0] = Statement.Lift(_0024_00245849_002423589);
						StatementCollection statementCollection60 = (block114.Statements = StatementCollection.FromArray(array73));
						Block block124 = (ifStatement25.TrueBlock = _0024_00245850_002423590);
						array70[3] = Statement.Lift(_0024_00245851_002423591);
						IfStatement ifStatement30 = (_0024_00245861_002423601 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement31 = _0024_00245861_002423601;
						BinaryExpression binaryExpression61 = (_0024_00245856_002423596 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType50 = (_0024_00245856_002423596.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression62 = _0024_00245856_002423596;
						BinaryExpression binaryExpression63 = (_0024_00245853_002423593 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType52 = (_0024_00245853_002423593.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression64 = _0024_00245853_002423593;
						ReferenceExpression referenceExpression58 = (_0024_00245852_002423592 = new ReferenceExpression(LexicalInfo.Empty));
						string text424 = (_0024_00245852_002423592.Name = "curr");
						Expression expression314 = (binaryExpression64.Left = _0024_00245852_002423592);
						Expression expression316 = (_0024_00245853_002423593.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression318 = (binaryExpression62.Left = _0024_00245853_002423593);
						BinaryExpression binaryExpression65 = _0024_00245856_002423596;
						BinaryExpression binaryExpression66 = (_0024_00245855_002423595 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType54 = (_0024_00245855_002423595.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression67 = _0024_00245855_002423595;
						ReferenceExpression referenceExpression59 = (_0024_00245854_002423594 = new ReferenceExpression(LexicalInfo.Empty));
						string text426 = (_0024_00245854_002423594.Name = "curr");
						Expression expression320 = (binaryExpression67.Left = new MemberReferenceExpression(_0024_00245854_002423594, CodeSerializer.LiftName(_0024self__002423859.actionExit)));
						Expression expression322 = (_0024_00245855_002423595.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression324 = (binaryExpression65.Right = _0024_00245855_002423595);
						Expression expression326 = (ifStatement31.Condition = _0024_00245856_002423596);
						IfStatement ifStatement32 = _0024_00245861_002423601;
						Block block125 = (_0024_00245860_002423600 = new Block(LexicalInfo.Empty));
						Block block126 = _0024_00245860_002423600;
						Statement[] array80 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression50 = (_0024_00245859_002423599 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression51 = _0024_00245859_002423599;
						ReferenceExpression referenceExpression60 = (_0024_00245857_002423597 = new ReferenceExpression(LexicalInfo.Empty));
						string text428 = (_0024_00245857_002423597.Name = "curr");
						Expression expression328 = (methodInvocationExpression51.Target = new MemberReferenceExpression(_0024_00245857_002423597, CodeSerializer.LiftName(_0024self__002423859.actionExit)));
						MethodInvocationExpression methodInvocationExpression52 = _0024_00245859_002423599;
						Expression[] array81 = new Expression[1];
						ReferenceExpression referenceExpression61 = (_0024_00245858_002423598 = new ReferenceExpression(LexicalInfo.Empty));
						string text430 = (_0024_00245858_002423598.Name = "curr");
						array81[0] = _0024_00245858_002423598;
						ExpressionCollection expressionCollection38 = (methodInvocationExpression52.Arguments = ExpressionCollection.FromArray(array81));
						array80[0] = Statement.Lift(_0024_00245859_002423599);
						StatementCollection statementCollection62 = (block126.Statements = StatementCollection.FromArray(array80));
						Block block128 = (ifStatement32.TrueBlock = _0024_00245860_002423600);
						array70[4] = Statement.Lift(_0024_00245861_002423601);
						ReturnStatement returnStatement49 = (_0024_00245870_002423610 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement50 = _0024_00245870_002423610;
						StatementModifier statementModifier29 = (_0024_00245869_002423609 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType16 = (_0024_00245869_002423609.Type = StatementModifierType.If);
						StatementModifier statementModifier30 = _0024_00245869_002423609;
						BinaryExpression binaryExpression68 = (_0024_00245868_002423608 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType56 = (_0024_00245868_002423608.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression69 = _0024_00245868_002423608;
						BinaryExpression binaryExpression70 = (_0024_00245863_002423603 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType58 = (_0024_00245863_002423603.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression71 = _0024_00245863_002423603;
						ReferenceExpression referenceExpression62 = (_0024_00245862_002423602 = new ReferenceExpression(LexicalInfo.Empty));
						string text432 = (_0024_00245862_002423602.Name = "curr");
						Expression expression330 = (binaryExpression71.Left = _0024_00245862_002423602);
						Expression expression332 = (_0024_00245863_002423603.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression334 = (binaryExpression69.Left = _0024_00245863_002423603);
						BinaryExpression binaryExpression72 = _0024_00245868_002423608;
						UnaryExpression unaryExpression10 = (_0024_00245867_002423607 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType12 = (_0024_00245867_002423607.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression11 = _0024_00245867_002423607;
						MethodInvocationExpression methodInvocationExpression53 = (_0024_00245866_002423606 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression54 = _0024_00245866_002423606;
						ReferenceExpression referenceExpression63 = (_0024_00245864_002423604 = new ReferenceExpression(LexicalInfo.Empty));
						string text434 = (_0024_00245864_002423604.Name = "isExecuting");
						Expression expression336 = (methodInvocationExpression54.Target = _0024_00245864_002423604);
						MethodInvocationExpression methodInvocationExpression55 = _0024_00245866_002423606;
						Expression[] array82 = new Expression[1];
						ReferenceExpression referenceExpression64 = (_0024_00245865_002423605 = new ReferenceExpression(LexicalInfo.Empty));
						string text436 = (_0024_00245865_002423605.Name = "curr");
						array82[0] = _0024_00245865_002423605;
						ExpressionCollection expressionCollection40 = (methodInvocationExpression55.Arguments = ExpressionCollection.FromArray(array82));
						Expression expression338 = (unaryExpression11.Operand = _0024_00245866_002423606);
						Expression expression340 = (binaryExpression72.Right = _0024_00245867_002423607);
						Expression expression342 = (statementModifier30.Condition = _0024_00245868_002423608);
						StatementModifier statementModifier32 = (returnStatement50.Modifier = _0024_00245869_002423609);
						array70[5] = Statement.Lift(_0024_00245870_002423610);
						MethodInvocationExpression methodInvocationExpression56 = (_0024_00245873_002423613 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression57 = _0024_00245873_002423613;
						ReferenceExpression referenceExpression65 = (_0024_00245871_002423611 = new ReferenceExpression(LexicalInfo.Empty));
						string text438 = (_0024_00245871_002423611.Name = "setCurrAction");
						Expression expression344 = (methodInvocationExpression57.Target = _0024_00245871_002423611);
						MethodInvocationExpression methodInvocationExpression58 = _0024_00245873_002423613;
						Expression[] array83 = new Expression[1];
						ReferenceExpression referenceExpression66 = (_0024_00245872_002423612 = new ReferenceExpression(LexicalInfo.Empty));
						string text440 = (_0024_00245872_002423612.Name = "act");
						array83[0] = _0024_00245872_002423612;
						ExpressionCollection expressionCollection42 = (methodInvocationExpression58.Arguments = ExpressionCollection.FromArray(array83));
						array70[6] = Statement.Lift(_0024_00245873_002423613);
						IfStatement ifStatement33 = (_0024_00245880_002423620 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement34 = _0024_00245880_002423620;
						BinaryExpression binaryExpression73 = (_0024_00245875_002423615 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType60 = (_0024_00245875_002423615.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression74 = _0024_00245875_002423615;
						ReferenceExpression referenceExpression67 = (_0024_00245874_002423614 = new ReferenceExpression(LexicalInfo.Empty));
						string text442 = (_0024_00245874_002423614.Name = "act");
						Expression expression346 = (binaryExpression74.Left = new MemberReferenceExpression(_0024_00245874_002423614, CodeSerializer.LiftName(_0024self__002423859.actionInit)));
						Expression expression348 = (_0024_00245875_002423615.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression350 = (ifStatement34.Condition = _0024_00245875_002423615);
						IfStatement ifStatement35 = _0024_00245880_002423620;
						Block block129 = (_0024_00245879_002423619 = new Block(LexicalInfo.Empty));
						Block block130 = _0024_00245879_002423619;
						Statement[] array84 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression59 = (_0024_00245878_002423618 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression60 = _0024_00245878_002423618;
						ReferenceExpression referenceExpression68 = (_0024_00245876_002423616 = new ReferenceExpression(LexicalInfo.Empty));
						string text444 = (_0024_00245876_002423616.Name = "act");
						Expression expression352 = (methodInvocationExpression60.Target = new MemberReferenceExpression(_0024_00245876_002423616, CodeSerializer.LiftName(_0024self__002423859.actionInit)));
						MethodInvocationExpression methodInvocationExpression61 = _0024_00245878_002423618;
						Expression[] array85 = new Expression[1];
						ReferenceExpression referenceExpression69 = (_0024_00245877_002423617 = new ReferenceExpression(LexicalInfo.Empty));
						string text446 = (_0024_00245877_002423617.Name = "act");
						array85[0] = _0024_00245877_002423617;
						ExpressionCollection expressionCollection44 = (methodInvocationExpression61.Arguments = ExpressionCollection.FromArray(array85));
						array84[0] = Statement.Lift(_0024_00245878_002423618);
						StatementCollection statementCollection64 = (block130.Statements = StatementCollection.FromArray(array84));
						Block block132 = (ifStatement35.TrueBlock = _0024_00245879_002423619);
						array70[7] = Statement.Lift(_0024_00245880_002423620);
						ReturnStatement returnStatement51 = (_0024_00245886_002423626 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement52 = _0024_00245886_002423626;
						StatementModifier statementModifier33 = (_0024_00245885_002423625 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType18 = (_0024_00245885_002423625.Type = StatementModifierType.If);
						StatementModifier statementModifier34 = _0024_00245885_002423625;
						UnaryExpression unaryExpression12 = (_0024_00245884_002423624 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType14 = (_0024_00245884_002423624.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression13 = _0024_00245884_002423624;
						MethodInvocationExpression methodInvocationExpression62 = (_0024_00245883_002423623 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression63 = _0024_00245883_002423623;
						ReferenceExpression referenceExpression70 = (_0024_00245881_002423621 = new ReferenceExpression(LexicalInfo.Empty));
						string text448 = (_0024_00245881_002423621.Name = "isExecuting");
						Expression expression354 = (methodInvocationExpression63.Target = _0024_00245881_002423621);
						MethodInvocationExpression methodInvocationExpression64 = _0024_00245883_002423623;
						Expression[] array86 = new Expression[1];
						ReferenceExpression referenceExpression71 = (_0024_00245882_002423622 = new ReferenceExpression(LexicalInfo.Empty));
						string text450 = (_0024_00245882_002423622.Name = "act");
						array86[0] = _0024_00245882_002423622;
						ExpressionCollection expressionCollection46 = (methodInvocationExpression64.Arguments = ExpressionCollection.FromArray(array86));
						Expression expression356 = (unaryExpression13.Operand = _0024_00245883_002423623);
						Expression expression358 = (statementModifier34.Condition = _0024_00245884_002423624);
						StatementModifier statementModifier36 = (returnStatement52.Modifier = _0024_00245885_002423625);
						array70[8] = Statement.Lift(_0024_00245886_002423626);
						IfStatement ifStatement36 = (_0024_00245895_002423635 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement37 = _0024_00245895_002423635;
						BinaryExpression binaryExpression75 = (_0024_00245888_002423628 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType62 = (_0024_00245888_002423628.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression76 = _0024_00245888_002423628;
						ReferenceExpression referenceExpression72 = (_0024_00245887_002423627 = new ReferenceExpression(LexicalInfo.Empty));
						string text452 = (_0024_00245887_002423627.Name = "act");
						Expression expression360 = (binaryExpression76.Left = new MemberReferenceExpression(_0024_00245887_002423627, CodeSerializer.LiftName(_0024self__002423859.actionCoroutine)));
						Expression expression362 = (_0024_00245888_002423628.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression364 = (ifStatement37.Condition = _0024_00245888_002423628);
						IfStatement ifStatement38 = _0024_00245895_002423635;
						Block block133 = (_0024_00245894_002423634 = new Block(LexicalInfo.Empty));
						Block block134 = _0024_00245894_002423634;
						Statement[] array87 = new Statement[1];
						BinaryExpression binaryExpression77 = (_0024_00245893_002423633 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType64 = (_0024_00245893_002423633.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression78 = _0024_00245893_002423633;
						ReferenceExpression referenceExpression73 = (_0024_00245889_002423629 = new ReferenceExpression(LexicalInfo.Empty));
						string text454 = (_0024_00245889_002423629.Name = "act");
						Expression expression366 = (binaryExpression78.Left = new MemberReferenceExpression(_0024_00245889_002423629, CodeSerializer.LiftName(_0024coIteratorVar_002423237)));
						BinaryExpression binaryExpression79 = _0024_00245893_002423633;
						MethodInvocationExpression methodInvocationExpression65 = (_0024_00245892_002423632 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression66 = _0024_00245892_002423632;
						ReferenceExpression referenceExpression74 = (_0024_00245890_002423630 = new ReferenceExpression(LexicalInfo.Empty));
						string text456 = (_0024_00245890_002423630.Name = "act");
						Expression expression368 = (methodInvocationExpression66.Target = new MemberReferenceExpression(_0024_00245890_002423630, CodeSerializer.LiftName(_0024self__002423859.actionCoroutine)));
						MethodInvocationExpression methodInvocationExpression67 = _0024_00245892_002423632;
						Expression[] array88 = new Expression[1];
						ReferenceExpression referenceExpression75 = (_0024_00245891_002423631 = new ReferenceExpression(LexicalInfo.Empty));
						string text458 = (_0024_00245891_002423631.Name = "act");
						array88[0] = _0024_00245891_002423631;
						ExpressionCollection expressionCollection48 = (methodInvocationExpression67.Arguments = ExpressionCollection.FromArray(array88));
						Expression expression370 = (binaryExpression79.Right = _0024_00245892_002423632);
						array87[0] = Statement.Lift(_0024_00245893_002423633);
						StatementCollection statementCollection66 = (block134.Statements = StatementCollection.FromArray(array87));
						Block block136 = (ifStatement38.TrueBlock = _0024_00245894_002423634);
						array70[9] = Statement.Lift(_0024_00245895_002423635);
						StatementCollection statementCollection68 = (block108.Statements = StatementCollection.FromArray(array70));
						Block block138 = (method55.Body = _0024_00245896_002423636);
						array3[18] = _0024_00245897_002423637;
						Method method56 = (_0024_00245913_002423653 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers70 = (_0024_00245913_002423653.Modifiers = TypeMemberModifiers.Public);
						string text460 = (_0024_00245913_002423653.Name = "changeAction");
						Method method57 = _0024_00245913_002423653;
						ParameterDeclaration[] array89 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration37 = (_0024_00245899_002423639 = new ParameterDeclaration(LexicalInfo.Empty));
						string text462 = (_0024_00245899_002423639.Name = "actID");
						ParameterDeclaration parameterDeclaration38 = _0024_00245899_002423639;
						SimpleTypeReference simpleTypeReference43 = (_0024_00245898_002423638 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag162 = (_0024_00245898_002423638.IsPointer = false);
						string text464 = (_0024_00245898_002423638.Name = "ActionEnum");
						TypeReference typeReference96 = (parameterDeclaration38.Type = _0024_00245898_002423638);
						array89[0] = _0024_00245899_002423639;
						ParameterDeclarationCollection parameterDeclarationCollection38 = (method57.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array89));
						Method method58 = _0024_00245913_002423653;
						Block block139 = (_0024_00245912_002423652 = new Block(LexicalInfo.Empty));
						Block block140 = _0024_00245912_002423652;
						Statement[] array90 = new Statement[2];
						BinaryExpression binaryExpression80 = (_0024_00245904_002423644 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType66 = (_0024_00245904_002423644.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression81 = _0024_00245904_002423644;
						ReferenceExpression referenceExpression76 = (_0024_00245900_002423640 = new ReferenceExpression(LexicalInfo.Empty));
						string text466 = (_0024_00245900_002423640.Name = "d");
						Expression expression372 = (binaryExpression81.Left = _0024_00245900_002423640);
						BinaryExpression binaryExpression82 = _0024_00245904_002423644;
						MethodInvocationExpression methodInvocationExpression68 = (_0024_00245903_002423643 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression69 = _0024_00245903_002423643;
						ReferenceExpression referenceExpression77 = (_0024_00245901_002423641 = new ReferenceExpression(LexicalInfo.Empty));
						string text468 = (_0024_00245901_002423641.Name = "createActionData");
						Expression expression374 = (methodInvocationExpression69.Target = _0024_00245901_002423641);
						MethodInvocationExpression methodInvocationExpression70 = _0024_00245903_002423643;
						Expression[] array91 = new Expression[1];
						ReferenceExpression referenceExpression78 = (_0024_00245902_002423642 = new ReferenceExpression(LexicalInfo.Empty));
						string text470 = (_0024_00245902_002423642.Name = "actID");
						array91[0] = _0024_00245902_002423642;
						ExpressionCollection expressionCollection50 = (methodInvocationExpression70.Arguments = ExpressionCollection.FromArray(array91));
						Expression expression376 = (binaryExpression82.Right = _0024_00245903_002423643);
						array90[0] = Statement.Lift(_0024_00245904_002423644);
						ExpressionStatement expressionStatement4 = (_0024_00245911_002423651 = new ExpressionStatement());
						ExpressionStatement expressionStatement5 = _0024_00245911_002423651;
						StatementModifier statementModifier37 = (_0024_00245907_002423647 = new StatementModifier(LexicalInfo.Empty));
						StatementModifierType statementModifierType20 = (_0024_00245907_002423647.Type = StatementModifierType.If);
						StatementModifier statementModifier38 = _0024_00245907_002423647;
						BinaryExpression binaryExpression83 = (_0024_00245906_002423646 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType68 = (_0024_00245906_002423646.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression84 = _0024_00245906_002423646;
						ReferenceExpression referenceExpression79 = (_0024_00245905_002423645 = new ReferenceExpression(LexicalInfo.Empty));
						string text472 = (_0024_00245905_002423645.Name = "d");
						Expression expression378 = (binaryExpression84.Left = _0024_00245905_002423645);
						Expression expression380 = (_0024_00245906_002423646.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression382 = (statementModifier38.Condition = _0024_00245906_002423646);
						StatementModifier statementModifier40 = (expressionStatement5.Modifier = _0024_00245907_002423647);
						ExpressionStatement expressionStatement6 = _0024_00245911_002423651;
						MethodInvocationExpression methodInvocationExpression71 = (_0024_00245910_002423650 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression72 = _0024_00245910_002423650;
						ReferenceExpression referenceExpression80 = (_0024_00245908_002423648 = new ReferenceExpression(LexicalInfo.Empty));
						string text474 = (_0024_00245908_002423648.Name = "changeAction");
						Expression expression384 = (methodInvocationExpression72.Target = _0024_00245908_002423648);
						MethodInvocationExpression methodInvocationExpression73 = _0024_00245910_002423650;
						Expression[] array92 = new Expression[1];
						ReferenceExpression referenceExpression81 = (_0024_00245909_002423649 = new ReferenceExpression(LexicalInfo.Empty));
						string text476 = (_0024_00245909_002423649.Name = "d");
						array92[0] = _0024_00245909_002423649;
						ExpressionCollection expressionCollection52 = (methodInvocationExpression73.Arguments = ExpressionCollection.FromArray(array92));
						Expression expression386 = (expressionStatement6.Expression = _0024_00245910_002423650);
						array90[1] = Statement.Lift(_0024_00245911_002423651);
						StatementCollection statementCollection70 = (block140.Statements = StatementCollection.FromArray(array90));
						Block block142 = (method58.Body = _0024_00245912_002423652);
						array3[19] = _0024_00245913_002423653;
						Method method59 = (_0024_00245933_002423673 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers72 = (_0024_00245933_002423673.Modifiers = TypeMemberModifiers.Private);
						string text478 = (_0024_00245933_002423673.Name = "copyActsToTmpActBuf");
						Method method60 = _0024_00245933_002423673;
						SimpleTypeReference simpleTypeReference44 = (_0024_00245914_002423654 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag164 = (_0024_00245914_002423654.IsPointer = false);
						string text480 = (_0024_00245914_002423654.Name = "int");
						TypeReference typeReference98 = (method60.ReturnType = _0024_00245914_002423654);
						Method method61 = _0024_00245933_002423673;
						Block block143 = (_0024_00245932_002423672 = new Block(LexicalInfo.Empty));
						Block block144 = _0024_00245932_002423672;
						Statement[] array93 = new Statement[3];
						DeclarationStatement declarationStatement = (_0024_00245918_002423658 = new DeclarationStatement(LexicalInfo.Empty));
						DeclarationStatement declarationStatement2 = _0024_00245918_002423658;
						Declaration declaration3 = (_0024_00245916_002423656 = new Declaration(LexicalInfo.Empty));
						string text482 = (_0024_00245916_002423656.Name = "_n");
						Declaration declaration4 = _0024_00245916_002423656;
						SimpleTypeReference simpleTypeReference45 = (_0024_00245915_002423655 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag166 = (_0024_00245915_002423655.IsPointer = false);
						string text484 = (_0024_00245915_002423655.Name = "int");
						TypeReference typeReference100 = (declaration4.Type = _0024_00245915_002423655);
						Declaration declaration6 = (declarationStatement2.Declaration = _0024_00245916_002423656);
						DeclarationStatement declarationStatement3 = _0024_00245918_002423658;
						IntegerLiteralExpression integerLiteralExpression4 = (_0024_00245917_002423657 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num14 = (_0024_00245917_002423657.Value = 0L);
						bool flag168 = (_0024_00245917_002423657.IsLong = false);
						Expression expression388 = (declarationStatement3.Initializer = _0024_00245917_002423657);
						array93[0] = Statement.Lift(_0024_00245918_002423658);
						ForStatement forStatement9 = (_0024_00245929_002423669 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement10 = _0024_00245929_002423669;
						Declaration[] array94 = new Declaration[1];
						Declaration declaration7 = (_0024_00245919_002423659 = new Declaration(LexicalInfo.Empty));
						string text486 = (_0024_00245919_002423659.Name = "v");
						array94[0] = _0024_00245919_002423659;
						DeclarationCollection declarationCollection6 = (forStatement10.Declarations = DeclarationCollection.FromArray(array94));
						ForStatement forStatement11 = _0024_00245929_002423669;
						MemberReferenceExpression memberReferenceExpression36 = (_0024_00245920_002423660 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text488 = (_0024_00245920_002423660.Name = "Values");
						Expression expression390 = (_0024_00245920_002423660.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression392 = (forStatement11.Iterator = _0024_00245920_002423660);
						ForStatement forStatement12 = _0024_00245929_002423669;
						Block block145 = (_0024_00245928_002423668 = new Block(LexicalInfo.Empty));
						Block block146 = _0024_00245928_002423668;
						Statement[] array95 = new Statement[1];
						BinaryExpression binaryExpression85 = (_0024_00245927_002423667 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType70 = (_0024_00245927_002423667.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression86 = _0024_00245927_002423667;
						SlicingExpression slicingExpression17 = (_0024_00245925_002423665 = new SlicingExpression(LexicalInfo.Empty));
						SlicingExpression slicingExpression18 = _0024_00245925_002423665;
						ReferenceExpression referenceExpression82 = (_0024_00245921_002423661 = new ReferenceExpression(LexicalInfo.Empty));
						string text490 = (_0024_00245921_002423661.Name = "tmpActBuf");
						Expression expression394 = (slicingExpression18.Target = _0024_00245921_002423661);
						SlicingExpression slicingExpression19 = _0024_00245925_002423665;
						Slice[] array96 = new Slice[1];
						Slice slice17 = (_0024_00245924_002423664 = new Slice(LexicalInfo.Empty));
						Slice slice18 = _0024_00245924_002423664;
						UnaryExpression unaryExpression14 = (_0024_00245923_002423663 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType16 = (_0024_00245923_002423663.Operator = UnaryOperatorType.PostIncrement);
						UnaryExpression unaryExpression15 = _0024_00245923_002423663;
						ReferenceExpression referenceExpression83 = (_0024_00245922_002423662 = new ReferenceExpression(LexicalInfo.Empty));
						string text492 = (_0024_00245922_002423662.Name = "_n");
						Expression expression396 = (unaryExpression15.Operand = _0024_00245922_002423662);
						Expression expression398 = (slice18.Begin = _0024_00245923_002423663);
						array96[0] = _0024_00245924_002423664;
						SliceCollection sliceCollection18 = (slicingExpression19.Indices = SliceCollection.FromArray(array96));
						Expression expression400 = (binaryExpression86.Left = _0024_00245925_002423665);
						BinaryExpression binaryExpression87 = _0024_00245927_002423667;
						ReferenceExpression referenceExpression84 = (_0024_00245926_002423666 = new ReferenceExpression(LexicalInfo.Empty));
						string text494 = (_0024_00245926_002423666.Name = "v");
						Expression expression402 = (binaryExpression87.Right = _0024_00245926_002423666);
						array95[0] = Statement.Lift(_0024_00245927_002423667);
						StatementCollection statementCollection72 = (block146.Statements = StatementCollection.FromArray(array95));
						Block block148 = (forStatement12.Block = _0024_00245928_002423668);
						array93[1] = Statement.Lift(_0024_00245929_002423669);
						ReturnStatement returnStatement53 = (_0024_00245931_002423671 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement54 = _0024_00245931_002423671;
						ReferenceExpression referenceExpression85 = (_0024_00245930_002423670 = new ReferenceExpression(LexicalInfo.Empty));
						string text496 = (_0024_00245930_002423670.Name = "_n");
						Expression expression404 = (returnStatement54.Expression = _0024_00245930_002423670);
						array93[2] = Statement.Lift(_0024_00245931_002423671);
						StatementCollection statementCollection74 = (block144.Statements = StatementCollection.FromArray(array93));
						Block block150 = (method61.Body = _0024_00245932_002423672);
						array3[20] = _0024_00245933_002423673;
						Method method62 = (_0024_00245977_002423717 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers74 = (_0024_00245977_002423717.Modifiers = TypeMemberModifiers.Public);
						string text498 = (_0024_00245977_002423717.Name = "actUpdate");
						Method method63 = _0024_00245977_002423717;
						Block block151 = (_0024_00245976_002423716 = new Block(LexicalInfo.Empty));
						Block block152 = _0024_00245976_002423716;
						Statement[] array97 = new Statement[4];
						DeclarationStatement declarationStatement4 = (_0024_00245938_002423678 = new DeclarationStatement(LexicalInfo.Empty));
						DeclarationStatement declarationStatement5 = _0024_00245938_002423678;
						Declaration declaration8 = (_0024_00245935_002423675 = new Declaration(LexicalInfo.Empty));
						string text500 = (_0024_00245935_002423675.Name = "_an");
						Declaration declaration9 = _0024_00245935_002423675;
						SimpleTypeReference simpleTypeReference46 = (_0024_00245934_002423674 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag170 = (_0024_00245934_002423674.IsPointer = false);
						string text502 = (_0024_00245934_002423674.Name = "int");
						TypeReference typeReference102 = (declaration9.Type = _0024_00245934_002423674);
						Declaration declaration11 = (declarationStatement5.Declaration = _0024_00245935_002423675);
						DeclarationStatement declarationStatement6 = _0024_00245938_002423678;
						MethodInvocationExpression methodInvocationExpression74 = (_0024_00245937_002423677 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression75 = _0024_00245937_002423677;
						ReferenceExpression referenceExpression86 = (_0024_00245936_002423676 = new ReferenceExpression(LexicalInfo.Empty));
						string text504 = (_0024_00245936_002423676.Name = "copyActsToTmpActBuf");
						Expression expression406 = (methodInvocationExpression75.Target = _0024_00245936_002423676);
						Expression expression408 = (declarationStatement6.Initializer = _0024_00245937_002423677);
						array97[0] = Statement.Lift(_0024_00245938_002423678);
						BinaryExpression binaryExpression88 = (_0024_00245940_002423680 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType72 = (_0024_00245940_002423680.Operator = BinaryOperatorType.Assign);
						Expression expression410 = (_0024_00245940_002423680.Left = Expression.Lift(_0024changeNumVar_002423234));
						BinaryExpression binaryExpression89 = _0024_00245940_002423680;
						IntegerLiteralExpression integerLiteralExpression5 = (_0024_00245939_002423679 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num16 = (_0024_00245939_002423679.Value = 0L);
						bool flag172 = (_0024_00245939_002423679.IsLong = false);
						Expression expression412 = (binaryExpression89.Right = _0024_00245939_002423679);
						array97[1] = Statement.Lift(_0024_00245940_002423680);
						ForStatement forStatement13 = (_0024_00245975_002423715 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement14 = _0024_00245975_002423715;
						Declaration[] array98 = new Declaration[1];
						Declaration declaration12 = (_0024_00245941_002423681 = new Declaration(LexicalInfo.Empty));
						string text506 = (_0024_00245941_002423681.Name = "i");
						array98[0] = _0024_00245941_002423681;
						DeclarationCollection declarationCollection8 = (forStatement14.Declarations = DeclarationCollection.FromArray(array98));
						ForStatement forStatement15 = _0024_00245975_002423715;
						MethodInvocationExpression methodInvocationExpression76 = (_0024_00245944_002423684 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression77 = _0024_00245944_002423684;
						ReferenceExpression referenceExpression87 = (_0024_00245942_002423682 = new ReferenceExpression(LexicalInfo.Empty));
						string text508 = (_0024_00245942_002423682.Name = "range");
						Expression expression414 = (methodInvocationExpression77.Target = _0024_00245942_002423682);
						MethodInvocationExpression methodInvocationExpression78 = _0024_00245944_002423684;
						Expression[] array99 = new Expression[1];
						ReferenceExpression referenceExpression88 = (_0024_00245943_002423683 = new ReferenceExpression(LexicalInfo.Empty));
						string text510 = (_0024_00245943_002423683.Name = "_an");
						array99[0] = _0024_00245943_002423683;
						ExpressionCollection expressionCollection54 = (methodInvocationExpression78.Arguments = ExpressionCollection.FromArray(array99));
						Expression expression416 = (forStatement15.Iterator = _0024_00245944_002423684);
						ForStatement forStatement16 = _0024_00245975_002423715;
						Block block153 = (_0024_00245974_002423714 = new Block(LexicalInfo.Empty));
						Block block154 = _0024_00245974_002423714;
						Statement[] array100 = new Statement[3];
						BinaryExpression binaryExpression90 = (_0024_00245950_002423690 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType74 = (_0024_00245950_002423690.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression91 = _0024_00245950_002423690;
						ReferenceExpression referenceExpression89 = (_0024_00245945_002423685 = new ReferenceExpression(LexicalInfo.Empty));
						string text512 = (_0024_00245945_002423685.Name = "act");
						Expression expression418 = (binaryExpression91.Left = _0024_00245945_002423685);
						BinaryExpression binaryExpression92 = _0024_00245950_002423690;
						SlicingExpression slicingExpression20 = (_0024_00245949_002423689 = new SlicingExpression(LexicalInfo.Empty));
						SlicingExpression slicingExpression21 = _0024_00245949_002423689;
						ReferenceExpression referenceExpression90 = (_0024_00245946_002423686 = new ReferenceExpression(LexicalInfo.Empty));
						string text514 = (_0024_00245946_002423686.Name = "tmpActBuf");
						Expression expression420 = (slicingExpression21.Target = _0024_00245946_002423686);
						SlicingExpression slicingExpression22 = _0024_00245949_002423689;
						Slice[] array101 = new Slice[1];
						Slice slice19 = (_0024_00245948_002423688 = new Slice(LexicalInfo.Empty));
						Slice slice20 = _0024_00245948_002423688;
						ReferenceExpression referenceExpression91 = (_0024_00245947_002423687 = new ReferenceExpression(LexicalInfo.Empty));
						string text516 = (_0024_00245947_002423687.Name = "i");
						Expression expression422 = (slice20.Begin = _0024_00245947_002423687);
						array101[0] = _0024_00245948_002423688;
						SliceCollection sliceCollection20 = (slicingExpression22.Indices = SliceCollection.FromArray(array101));
						Expression expression424 = (binaryExpression92.Right = _0024_00245949_002423689);
						array100[0] = Statement.Lift(_0024_00245950_002423690);
						IfStatement ifStatement39 = (_0024_00245957_002423697 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement40 = _0024_00245957_002423697;
						BinaryExpression binaryExpression93 = (_0024_00245952_002423692 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType76 = (_0024_00245952_002423692.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression94 = _0024_00245952_002423692;
						ReferenceExpression referenceExpression92 = (_0024_00245951_002423691 = new ReferenceExpression(LexicalInfo.Empty));
						string text518 = (_0024_00245951_002423691.Name = "act");
						Expression expression426 = (binaryExpression94.Left = new MemberReferenceExpression(_0024_00245951_002423691, CodeSerializer.LiftName(_0024self__002423859.actionUpdate)));
						Expression expression428 = (_0024_00245952_002423692.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression430 = (ifStatement40.Condition = _0024_00245952_002423692);
						IfStatement ifStatement41 = _0024_00245957_002423697;
						Block block155 = (_0024_00245956_002423696 = new Block(LexicalInfo.Empty));
						Block block156 = _0024_00245956_002423696;
						Statement[] array102 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression79 = (_0024_00245955_002423695 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression80 = _0024_00245955_002423695;
						ReferenceExpression referenceExpression93 = (_0024_00245953_002423693 = new ReferenceExpression(LexicalInfo.Empty));
						string text520 = (_0024_00245953_002423693.Name = "act");
						Expression expression432 = (methodInvocationExpression80.Target = new MemberReferenceExpression(_0024_00245953_002423693, CodeSerializer.LiftName(_0024self__002423859.actionUpdate)));
						MethodInvocationExpression methodInvocationExpression81 = _0024_00245955_002423695;
						Expression[] array103 = new Expression[1];
						ReferenceExpression referenceExpression94 = (_0024_00245954_002423694 = new ReferenceExpression(LexicalInfo.Empty));
						string text522 = (_0024_00245954_002423694.Name = "act");
						array103[0] = _0024_00245954_002423694;
						ExpressionCollection expressionCollection56 = (methodInvocationExpression81.Arguments = ExpressionCollection.FromArray(array103));
						array102[0] = Statement.Lift(_0024_00245955_002423695);
						StatementCollection statementCollection76 = (block156.Statements = StatementCollection.FromArray(array102));
						Block block158 = (ifStatement41.TrueBlock = _0024_00245956_002423696);
						array100[1] = Statement.Lift(_0024_00245957_002423697);
						IfStatement ifStatement42 = (_0024_00245973_002423713 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement43 = _0024_00245973_002423713;
						BinaryExpression binaryExpression95 = (_0024_00245963_002423703 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType78 = (_0024_00245963_002423703.Operator = BinaryOperatorType.And);
						BinaryExpression binaryExpression96 = _0024_00245963_002423703;
						MethodInvocationExpression methodInvocationExpression82 = (_0024_00245960_002423700 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression83 = _0024_00245960_002423700;
						ReferenceExpression referenceExpression95 = (_0024_00245958_002423698 = new ReferenceExpression(LexicalInfo.Empty));
						string text524 = (_0024_00245958_002423698.Name = "isExecuting");
						Expression expression434 = (methodInvocationExpression83.Target = _0024_00245958_002423698);
						MethodInvocationExpression methodInvocationExpression84 = _0024_00245960_002423700;
						Expression[] array104 = new Expression[1];
						ReferenceExpression referenceExpression96 = (_0024_00245959_002423699 = new ReferenceExpression(LexicalInfo.Empty));
						string text526 = (_0024_00245959_002423699.Name = "act");
						array104[0] = _0024_00245959_002423699;
						ExpressionCollection expressionCollection58 = (methodInvocationExpression84.Arguments = ExpressionCollection.FromArray(array104));
						Expression expression436 = (binaryExpression96.Left = _0024_00245960_002423700);
						BinaryExpression binaryExpression97 = _0024_00245963_002423703;
						BinaryExpression binaryExpression98 = (_0024_00245962_002423702 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType80 = (_0024_00245962_002423702.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression99 = _0024_00245962_002423702;
						ReferenceExpression referenceExpression97 = (_0024_00245961_002423701 = new ReferenceExpression(LexicalInfo.Empty));
						string text528 = (_0024_00245961_002423701.Name = "act");
						Expression expression438 = (binaryExpression99.Left = new MemberReferenceExpression(_0024_00245961_002423701, CodeSerializer.LiftName(_0024coIteratorVar_002423237)));
						Expression expression440 = (_0024_00245962_002423702.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression442 = (binaryExpression97.Right = _0024_00245962_002423702);
						Expression expression444 = (ifStatement43.Condition = _0024_00245963_002423703);
						IfStatement ifStatement44 = _0024_00245973_002423713;
						Block block159 = (_0024_00245972_002423712 = new Block(LexicalInfo.Empty));
						Block block160 = _0024_00245972_002423712;
						Statement[] array105 = new Statement[1];
						IfStatement ifStatement45 = (_0024_00245971_002423711 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement46 = _0024_00245971_002423711;
						UnaryExpression unaryExpression16 = (_0024_00245967_002423707 = new UnaryExpression(LexicalInfo.Empty));
						UnaryOperatorType unaryOperatorType18 = (_0024_00245967_002423707.Operator = UnaryOperatorType.LogicalNot);
						UnaryExpression unaryExpression17 = _0024_00245967_002423707;
						MethodInvocationExpression methodInvocationExpression85 = (_0024_00245966_002423706 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression86 = _0024_00245966_002423706;
						MemberReferenceExpression memberReferenceExpression37 = (_0024_00245965_002423705 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text530 = (_0024_00245965_002423705.Name = "MoveNext");
						MemberReferenceExpression memberReferenceExpression38 = _0024_00245965_002423705;
						ReferenceExpression referenceExpression98 = (_0024_00245964_002423704 = new ReferenceExpression(LexicalInfo.Empty));
						string text532 = (_0024_00245964_002423704.Name = "act");
						Expression expression446 = (memberReferenceExpression38.Target = new MemberReferenceExpression(_0024_00245964_002423704, CodeSerializer.LiftName(_0024coIteratorVar_002423237)));
						Expression expression448 = (methodInvocationExpression86.Target = _0024_00245965_002423705);
						Expression expression450 = (unaryExpression17.Operand = _0024_00245966_002423706);
						Expression expression452 = (ifStatement46.Condition = _0024_00245967_002423707);
						IfStatement ifStatement47 = _0024_00245971_002423711;
						Block block161 = (_0024_00245970_002423710 = new Block(LexicalInfo.Empty));
						Block block162 = _0024_00245970_002423710;
						Statement[] array106 = new Statement[1];
						BinaryExpression binaryExpression100 = (_0024_00245969_002423709 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType82 = (_0024_00245969_002423709.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression101 = _0024_00245969_002423709;
						ReferenceExpression referenceExpression99 = (_0024_00245968_002423708 = new ReferenceExpression(LexicalInfo.Empty));
						string text534 = (_0024_00245968_002423708.Name = "act");
						Expression expression454 = (binaryExpression101.Left = new MemberReferenceExpression(_0024_00245968_002423708, CodeSerializer.LiftName(_0024coIteratorVar_002423237)));
						Expression expression456 = (_0024_00245969_002423709.Right = new NullLiteralExpression(LexicalInfo.Empty));
						array106[0] = Statement.Lift(_0024_00245969_002423709);
						StatementCollection statementCollection78 = (block162.Statements = StatementCollection.FromArray(array106));
						Block block164 = (ifStatement47.TrueBlock = _0024_00245970_002423710);
						array105[0] = Statement.Lift(_0024_00245971_002423711);
						StatementCollection statementCollection80 = (block160.Statements = StatementCollection.FromArray(array105));
						Block block166 = (ifStatement44.TrueBlock = _0024_00245972_002423712);
						array100[2] = Statement.Lift(_0024_00245973_002423713);
						StatementCollection statementCollection82 = (block154.Statements = StatementCollection.FromArray(array100));
						Block block168 = (forStatement16.Block = _0024_00245974_002423714);
						array97[2] = Statement.Lift(_0024_00245975_002423715);
						array97[3] = Statement.Lift(Statement.Lift(_0024progressActTimeCode_002423243));
						StatementCollection statementCollection84 = (block152.Statements = StatementCollection.FromArray(array97));
						Block block170 = (method63.Body = _0024_00245976_002423716);
						array3[21] = _0024_00245977_002423717;
						Method method64 = (_0024_00246005_002423745 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers76 = (_0024_00246005_002423745.Modifiers = TypeMemberModifiers.Public);
						string text536 = (_0024_00246005_002423745.Name = "actFixedUpdate");
						Method method65 = _0024_00246005_002423745;
						Block block171 = (_0024_00246004_002423744 = new Block(LexicalInfo.Empty));
						Block block172 = _0024_00246004_002423744;
						Statement[] array107 = new Statement[3];
						DeclarationStatement declarationStatement7 = (_0024_00245982_002423722 = new DeclarationStatement(LexicalInfo.Empty));
						DeclarationStatement declarationStatement8 = _0024_00245982_002423722;
						Declaration declaration13 = (_0024_00245979_002423719 = new Declaration(LexicalInfo.Empty));
						string text538 = (_0024_00245979_002423719.Name = "_an");
						Declaration declaration14 = _0024_00245979_002423719;
						SimpleTypeReference simpleTypeReference47 = (_0024_00245978_002423718 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag174 = (_0024_00245978_002423718.IsPointer = false);
						string text540 = (_0024_00245978_002423718.Name = "int");
						TypeReference typeReference104 = (declaration14.Type = _0024_00245978_002423718);
						Declaration declaration16 = (declarationStatement8.Declaration = _0024_00245979_002423719);
						DeclarationStatement declarationStatement9 = _0024_00245982_002423722;
						MethodInvocationExpression methodInvocationExpression87 = (_0024_00245981_002423721 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression88 = _0024_00245981_002423721;
						ReferenceExpression referenceExpression100 = (_0024_00245980_002423720 = new ReferenceExpression(LexicalInfo.Empty));
						string text542 = (_0024_00245980_002423720.Name = "copyActsToTmpActBuf");
						Expression expression458 = (methodInvocationExpression88.Target = _0024_00245980_002423720);
						Expression expression460 = (declarationStatement9.Initializer = _0024_00245981_002423721);
						array107[0] = Statement.Lift(_0024_00245982_002423722);
						BinaryExpression binaryExpression102 = (_0024_00245984_002423724 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType84 = (_0024_00245984_002423724.Operator = BinaryOperatorType.Assign);
						Expression expression462 = (_0024_00245984_002423724.Left = Expression.Lift(_0024changeNumVar_002423234));
						BinaryExpression binaryExpression103 = _0024_00245984_002423724;
						IntegerLiteralExpression integerLiteralExpression6 = (_0024_00245983_002423723 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num18 = (_0024_00245983_002423723.Value = 0L);
						bool flag176 = (_0024_00245983_002423723.IsLong = false);
						Expression expression464 = (binaryExpression103.Right = _0024_00245983_002423723);
						array107[1] = Statement.Lift(_0024_00245984_002423724);
						ForStatement forStatement17 = (_0024_00246003_002423743 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement18 = _0024_00246003_002423743;
						Declaration[] array108 = new Declaration[1];
						Declaration declaration17 = (_0024_00245985_002423725 = new Declaration(LexicalInfo.Empty));
						string text544 = (_0024_00245985_002423725.Name = "i");
						array108[0] = _0024_00245985_002423725;
						DeclarationCollection declarationCollection10 = (forStatement18.Declarations = DeclarationCollection.FromArray(array108));
						ForStatement forStatement19 = _0024_00246003_002423743;
						MethodInvocationExpression methodInvocationExpression89 = (_0024_00245988_002423728 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression90 = _0024_00245988_002423728;
						ReferenceExpression referenceExpression101 = (_0024_00245986_002423726 = new ReferenceExpression(LexicalInfo.Empty));
						string text546 = (_0024_00245986_002423726.Name = "range");
						Expression expression466 = (methodInvocationExpression90.Target = _0024_00245986_002423726);
						MethodInvocationExpression methodInvocationExpression91 = _0024_00245988_002423728;
						Expression[] array109 = new Expression[1];
						ReferenceExpression referenceExpression102 = (_0024_00245987_002423727 = new ReferenceExpression(LexicalInfo.Empty));
						string text548 = (_0024_00245987_002423727.Name = "_an");
						array109[0] = _0024_00245987_002423727;
						ExpressionCollection expressionCollection60 = (methodInvocationExpression91.Arguments = ExpressionCollection.FromArray(array109));
						Expression expression468 = (forStatement19.Iterator = _0024_00245988_002423728);
						ForStatement forStatement20 = _0024_00246003_002423743;
						Block block173 = (_0024_00246002_002423742 = new Block(LexicalInfo.Empty));
						Block block174 = _0024_00246002_002423742;
						Statement[] array110 = new Statement[2];
						BinaryExpression binaryExpression104 = (_0024_00245994_002423734 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType86 = (_0024_00245994_002423734.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression105 = _0024_00245994_002423734;
						ReferenceExpression referenceExpression103 = (_0024_00245989_002423729 = new ReferenceExpression(LexicalInfo.Empty));
						string text550 = (_0024_00245989_002423729.Name = "act");
						Expression expression470 = (binaryExpression105.Left = _0024_00245989_002423729);
						BinaryExpression binaryExpression106 = _0024_00245994_002423734;
						SlicingExpression slicingExpression23 = (_0024_00245993_002423733 = new SlicingExpression(LexicalInfo.Empty));
						SlicingExpression slicingExpression24 = _0024_00245993_002423733;
						ReferenceExpression referenceExpression104 = (_0024_00245990_002423730 = new ReferenceExpression(LexicalInfo.Empty));
						string text552 = (_0024_00245990_002423730.Name = "tmpActBuf");
						Expression expression472 = (slicingExpression24.Target = _0024_00245990_002423730);
						SlicingExpression slicingExpression25 = _0024_00245993_002423733;
						Slice[] array111 = new Slice[1];
						Slice slice21 = (_0024_00245992_002423732 = new Slice(LexicalInfo.Empty));
						Slice slice22 = _0024_00245992_002423732;
						ReferenceExpression referenceExpression105 = (_0024_00245991_002423731 = new ReferenceExpression(LexicalInfo.Empty));
						string text554 = (_0024_00245991_002423731.Name = "i");
						Expression expression474 = (slice22.Begin = _0024_00245991_002423731);
						array111[0] = _0024_00245992_002423732;
						SliceCollection sliceCollection22 = (slicingExpression25.Indices = SliceCollection.FromArray(array111));
						Expression expression476 = (binaryExpression106.Right = _0024_00245993_002423733);
						array110[0] = Statement.Lift(_0024_00245994_002423734);
						IfStatement ifStatement48 = (_0024_00246001_002423741 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement49 = _0024_00246001_002423741;
						BinaryExpression binaryExpression107 = (_0024_00245996_002423736 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType88 = (_0024_00245996_002423736.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression108 = _0024_00245996_002423736;
						ReferenceExpression referenceExpression106 = (_0024_00245995_002423735 = new ReferenceExpression(LexicalInfo.Empty));
						string text556 = (_0024_00245995_002423735.Name = "act");
						Expression expression478 = (binaryExpression108.Left = new MemberReferenceExpression(_0024_00245995_002423735, CodeSerializer.LiftName(_0024self__002423859.actionFixedUpdate)));
						Expression expression480 = (_0024_00245996_002423736.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression482 = (ifStatement49.Condition = _0024_00245996_002423736);
						IfStatement ifStatement50 = _0024_00246001_002423741;
						Block block175 = (_0024_00246000_002423740 = new Block(LexicalInfo.Empty));
						Block block176 = _0024_00246000_002423740;
						Statement[] array112 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression92 = (_0024_00245999_002423739 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression93 = _0024_00245999_002423739;
						ReferenceExpression referenceExpression107 = (_0024_00245997_002423737 = new ReferenceExpression(LexicalInfo.Empty));
						string text558 = (_0024_00245997_002423737.Name = "act");
						Expression expression484 = (methodInvocationExpression93.Target = new MemberReferenceExpression(_0024_00245997_002423737, CodeSerializer.LiftName(_0024self__002423859.actionFixedUpdate)));
						MethodInvocationExpression methodInvocationExpression94 = _0024_00245999_002423739;
						Expression[] array113 = new Expression[1];
						ReferenceExpression referenceExpression108 = (_0024_00245998_002423738 = new ReferenceExpression(LexicalInfo.Empty));
						string text560 = (_0024_00245998_002423738.Name = "act");
						array113[0] = _0024_00245998_002423738;
						ExpressionCollection expressionCollection62 = (methodInvocationExpression94.Arguments = ExpressionCollection.FromArray(array113));
						array112[0] = Statement.Lift(_0024_00245999_002423739);
						StatementCollection statementCollection86 = (block176.Statements = StatementCollection.FromArray(array112));
						Block block178 = (ifStatement50.TrueBlock = _0024_00246000_002423740);
						array110[1] = Statement.Lift(_0024_00246001_002423741);
						StatementCollection statementCollection88 = (block174.Statements = StatementCollection.FromArray(array110));
						Block block180 = (forStatement20.Block = _0024_00246002_002423742);
						array107[2] = Statement.Lift(_0024_00246003_002423743);
						StatementCollection statementCollection90 = (block172.Statements = StatementCollection.FromArray(array107));
						Block block182 = (method65.Body = _0024_00246004_002423744);
						array3[22] = _0024_00246005_002423745;
						Method method66 = (_0024_00246066_002423806 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers78 = (_0024_00246066_002423806.Modifiers = TypeMemberModifiers.Public);
						string text562 = (_0024_00246066_002423806.Name = "actOnGUI");
						Method method67 = _0024_00246066_002423806;
						Block block183 = (_0024_00246065_002423805 = new Block(LexicalInfo.Empty));
						Block block184 = _0024_00246065_002423805;
						Statement[] array114 = new Statement[4];
						BinaryExpression binaryExpression109 = (_0024_00246007_002423747 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType90 = (_0024_00246007_002423747.Operator = BinaryOperatorType.Assign);
						Expression expression486 = (_0024_00246007_002423747.Left = Expression.Lift(_0024changeNumVar_002423234));
						BinaryExpression binaryExpression110 = _0024_00246007_002423747;
						IntegerLiteralExpression integerLiteralExpression7 = (_0024_00246006_002423746 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num20 = (_0024_00246006_002423746.Value = 0L);
						bool flag178 = (_0024_00246006_002423746.IsLong = false);
						Expression expression488 = (binaryExpression110.Right = _0024_00246006_002423746);
						array114[0] = Statement.Lift(_0024_00246007_002423747);
						BinaryExpression binaryExpression111 = (_0024_00246012_002423752 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType92 = (_0024_00246012_002423752.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression112 = _0024_00246012_002423752;
						ReferenceExpression referenceExpression109 = (_0024_00246008_002423748 = new ReferenceExpression(LexicalInfo.Empty));
						string text564 = (_0024_00246008_002423748.Name = "groups");
						Expression expression490 = (binaryExpression112.Left = _0024_00246008_002423748);
						BinaryExpression binaryExpression113 = _0024_00246012_002423752;
						MethodInvocationExpression methodInvocationExpression95 = (_0024_00246011_002423751 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression96 = _0024_00246011_002423751;
						ReferenceExpression referenceExpression110 = (_0024_00246009_002423749 = new ReferenceExpression(LexicalInfo.Empty));
						string text566 = (_0024_00246009_002423749.Name = "array");
						Expression expression492 = (methodInvocationExpression96.Target = _0024_00246009_002423749);
						MethodInvocationExpression methodInvocationExpression97 = _0024_00246011_002423751;
						Expression[] array115 = new Expression[1];
						MemberReferenceExpression memberReferenceExpression39 = (_0024_00246010_002423750 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text568 = (_0024_00246010_002423750.Name = "Keys");
						Expression expression494 = (_0024_00246010_002423750.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						array115[0] = _0024_00246010_002423750;
						ExpressionCollection expressionCollection64 = (methodInvocationExpression97.Arguments = ExpressionCollection.FromArray(array115));
						Expression expression496 = (binaryExpression113.Right = _0024_00246011_002423751);
						array114[1] = Statement.Lift(_0024_00246012_002423752);
						ForStatement forStatement21 = (_0024_00246028_002423768 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement22 = _0024_00246028_002423768;
						Declaration[] array116 = new Declaration[1];
						Declaration declaration18 = (_0024_00246013_002423753 = new Declaration(LexicalInfo.Empty));
						string text570 = (_0024_00246013_002423753.Name = "grp");
						array116[0] = _0024_00246013_002423753;
						DeclarationCollection declarationCollection12 = (forStatement22.Declarations = DeclarationCollection.FromArray(array116));
						ForStatement forStatement23 = _0024_00246028_002423768;
						ReferenceExpression referenceExpression111 = (_0024_00246014_002423754 = new ReferenceExpression(LexicalInfo.Empty));
						string text572 = (_0024_00246014_002423754.Name = "groups");
						Expression expression498 = (forStatement23.Iterator = _0024_00246014_002423754);
						ForStatement forStatement24 = _0024_00246028_002423768;
						Block block185 = (_0024_00246027_002423767 = new Block(LexicalInfo.Empty));
						Block block186 = _0024_00246027_002423767;
						Statement[] array117 = new Statement[2];
						BinaryExpression binaryExpression114 = (_0024_00246019_002423759 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType94 = (_0024_00246019_002423759.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression115 = _0024_00246019_002423759;
						ReferenceExpression referenceExpression112 = (_0024_00246015_002423755 = new ReferenceExpression(LexicalInfo.Empty));
						string text574 = (_0024_00246015_002423755.Name = "act");
						Expression expression500 = (binaryExpression115.Left = _0024_00246015_002423755);
						BinaryExpression binaryExpression116 = _0024_00246019_002423759;
						SlicingExpression slicingExpression26 = (_0024_00246018_002423758 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression502 = (_0024_00246018_002423758.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression27 = _0024_00246018_002423758;
						Slice[] array118 = new Slice[1];
						Slice slice23 = (_0024_00246017_002423757 = new Slice(LexicalInfo.Empty));
						Slice slice24 = _0024_00246017_002423757;
						ReferenceExpression referenceExpression113 = (_0024_00246016_002423756 = new ReferenceExpression(LexicalInfo.Empty));
						string text576 = (_0024_00246016_002423756.Name = "grp");
						Expression expression504 = (slice24.Begin = _0024_00246016_002423756);
						array118[0] = _0024_00246017_002423757;
						SliceCollection sliceCollection24 = (slicingExpression27.Indices = SliceCollection.FromArray(array118));
						Expression expression506 = (binaryExpression116.Right = _0024_00246018_002423758);
						array117[0] = Statement.Lift(_0024_00246019_002423759);
						IfStatement ifStatement51 = (_0024_00246026_002423766 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement52 = _0024_00246026_002423766;
						BinaryExpression binaryExpression117 = (_0024_00246021_002423761 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType96 = (_0024_00246021_002423761.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression118 = _0024_00246021_002423761;
						ReferenceExpression referenceExpression114 = (_0024_00246020_002423760 = new ReferenceExpression(LexicalInfo.Empty));
						string text578 = (_0024_00246020_002423760.Name = "act");
						Expression expression508 = (binaryExpression118.Left = new MemberReferenceExpression(_0024_00246020_002423760, CodeSerializer.LiftName(_0024self__002423859.actionOnGUI)));
						Expression expression510 = (_0024_00246021_002423761.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression512 = (ifStatement52.Condition = _0024_00246021_002423761);
						IfStatement ifStatement53 = _0024_00246026_002423766;
						Block block187 = (_0024_00246025_002423765 = new Block(LexicalInfo.Empty));
						Block block188 = _0024_00246025_002423765;
						Statement[] array119 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression98 = (_0024_00246024_002423764 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression99 = _0024_00246024_002423764;
						ReferenceExpression referenceExpression115 = (_0024_00246022_002423762 = new ReferenceExpression(LexicalInfo.Empty));
						string text580 = (_0024_00246022_002423762.Name = "act");
						Expression expression514 = (methodInvocationExpression99.Target = new MemberReferenceExpression(_0024_00246022_002423762, CodeSerializer.LiftName(_0024self__002423859.actionOnGUI)));
						MethodInvocationExpression methodInvocationExpression100 = _0024_00246024_002423764;
						Expression[] array120 = new Expression[1];
						ReferenceExpression referenceExpression116 = (_0024_00246023_002423763 = new ReferenceExpression(LexicalInfo.Empty));
						string text582 = (_0024_00246023_002423763.Name = "act");
						array120[0] = _0024_00246023_002423763;
						ExpressionCollection expressionCollection66 = (methodInvocationExpression100.Arguments = ExpressionCollection.FromArray(array120));
						array119[0] = Statement.Lift(_0024_00246024_002423764);
						StatementCollection statementCollection92 = (block188.Statements = StatementCollection.FromArray(array119));
						Block block190 = (ifStatement53.TrueBlock = _0024_00246025_002423765);
						array117[1] = Statement.Lift(_0024_00246026_002423766);
						StatementCollection statementCollection94 = (block186.Statements = StatementCollection.FromArray(array117));
						Block block192 = (forStatement24.Block = _0024_00246027_002423767);
						array114[2] = Statement.Lift(_0024_00246028_002423768);
						IfStatement ifStatement54 = (_0024_00246064_002423804 = new IfStatement(LexicalInfo.Empty));
						Expression expression516 = (_0024_00246064_002423804.Condition = Expression.Lift(_0024debugFlagVar_002423235));
						IfStatement ifStatement55 = _0024_00246064_002423804;
						Block block193 = (_0024_00246063_002423803 = new Block(LexicalInfo.Empty));
						Block block194 = _0024_00246063_002423803;
						Statement[] array121 = new Statement[2];
						BinaryExpression binaryExpression119 = (_0024_00246031_002423771 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType98 = (_0024_00246031_002423771.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression120 = _0024_00246031_002423771;
						ReferenceExpression referenceExpression117 = (_0024_00246029_002423769 = new ReferenceExpression(LexicalInfo.Empty));
						string text584 = (_0024_00246029_002423769.Name = "y");
						Expression expression518 = (binaryExpression120.Left = _0024_00246029_002423769);
						BinaryExpression binaryExpression121 = _0024_00246031_002423771;
						IntegerLiteralExpression integerLiteralExpression8 = (_0024_00246030_002423770 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num22 = (_0024_00246030_002423770.Value = 100L);
						bool flag180 = (_0024_00246030_002423770.IsLong = false);
						Expression expression520 = (binaryExpression121.Right = _0024_00246030_002423770);
						array121[0] = Statement.Lift(_0024_00246031_002423771);
						ForStatement forStatement25 = (_0024_00246062_002423802 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement26 = _0024_00246062_002423802;
						Declaration[] array122 = new Declaration[1];
						Declaration declaration19 = (_0024_00246032_002423772 = new Declaration(LexicalInfo.Empty));
						string text586 = (_0024_00246032_002423772.Name = "act");
						array122[0] = _0024_00246032_002423772;
						DeclarationCollection declarationCollection14 = (forStatement26.Declarations = DeclarationCollection.FromArray(array122));
						ForStatement forStatement27 = _0024_00246062_002423802;
						MemberReferenceExpression memberReferenceExpression40 = (_0024_00246033_002423773 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text588 = (_0024_00246033_002423773.Name = "Values");
						Expression expression522 = (_0024_00246033_002423773.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						Expression expression524 = (forStatement27.Iterator = _0024_00246033_002423773);
						ForStatement forStatement28 = _0024_00246062_002423802;
						Block block195 = (_0024_00246061_002423801 = new Block(LexicalInfo.Empty));
						Block block196 = _0024_00246061_002423801;
						Statement[] array123 = new Statement[2];
						MethodInvocationExpression methodInvocationExpression101 = (_0024_00246057_002423797 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression102 = _0024_00246057_002423797;
						MemberReferenceExpression memberReferenceExpression41 = (_0024_00246035_002423775 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text590 = (_0024_00246035_002423775.Name = "Label");
						MemberReferenceExpression memberReferenceExpression42 = _0024_00246035_002423775;
						ReferenceExpression referenceExpression118 = (_0024_00246034_002423774 = new ReferenceExpression(LexicalInfo.Empty));
						string text592 = (_0024_00246034_002423774.Name = "GUI");
						Expression expression526 = (memberReferenceExpression42.Target = _0024_00246034_002423774);
						Expression expression528 = (methodInvocationExpression102.Target = _0024_00246035_002423775);
						MethodInvocationExpression methodInvocationExpression103 = _0024_00246057_002423797;
						Expression[] array124 = new Expression[2];
						MethodInvocationExpression methodInvocationExpression104 = (_0024_00246041_002423781 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression105 = _0024_00246041_002423781;
						ReferenceExpression referenceExpression119 = (_0024_00246036_002423776 = new ReferenceExpression(LexicalInfo.Empty));
						string text594 = (_0024_00246036_002423776.Name = "Rect");
						Expression expression530 = (methodInvocationExpression105.Target = _0024_00246036_002423776);
						MethodInvocationExpression methodInvocationExpression106 = _0024_00246041_002423781;
						Expression[] array125 = new Expression[4];
						IntegerLiteralExpression integerLiteralExpression9 = (_0024_00246037_002423777 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num24 = (_0024_00246037_002423777.Value = 200L);
						bool flag182 = (_0024_00246037_002423777.IsLong = false);
						array125[0] = _0024_00246037_002423777;
						ReferenceExpression referenceExpression120 = (_0024_00246038_002423778 = new ReferenceExpression(LexicalInfo.Empty));
						string text596 = (_0024_00246038_002423778.Name = "y");
						array125[1] = _0024_00246038_002423778;
						IntegerLiteralExpression integerLiteralExpression10 = (_0024_00246039_002423779 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num26 = (_0024_00246039_002423779.Value = 400L);
						bool flag184 = (_0024_00246039_002423779.IsLong = false);
						array125[2] = _0024_00246039_002423779;
						IntegerLiteralExpression integerLiteralExpression11 = (_0024_00246040_002423780 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num28 = (_0024_00246040_002423780.Value = 20L);
						bool flag186 = (_0024_00246040_002423780.IsLong = false);
						array125[3] = _0024_00246040_002423780;
						ExpressionCollection expressionCollection68 = (methodInvocationExpression106.Arguments = ExpressionCollection.FromArray(array125));
						array124[0] = _0024_00246041_002423781;
						BinaryExpression binaryExpression122 = (_0024_00246056_002423796 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType100 = (_0024_00246056_002423796.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression123 = _0024_00246056_002423796;
						BinaryExpression binaryExpression124 = (_0024_00246054_002423794 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType102 = (_0024_00246054_002423794.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression125 = _0024_00246054_002423794;
						BinaryExpression binaryExpression126 = (_0024_00246052_002423792 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType104 = (_0024_00246052_002423792.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression127 = _0024_00246052_002423792;
						BinaryExpression binaryExpression128 = (_0024_00246050_002423790 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType106 = (_0024_00246050_002423790.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression129 = _0024_00246050_002423790;
						BinaryExpression binaryExpression130 = (_0024_00246048_002423788 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType108 = (_0024_00246048_002423788.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression131 = _0024_00246048_002423788;
						BinaryExpression binaryExpression132 = (_0024_00246046_002423786 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType110 = (_0024_00246046_002423786.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression133 = _0024_00246046_002423786;
						BinaryExpression binaryExpression134 = (_0024_00246044_002423784 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType112 = (_0024_00246044_002423784.Operator = BinaryOperatorType.Addition);
						BinaryExpression binaryExpression135 = _0024_00246044_002423784;
						StringLiteralExpression stringLiteralExpression10 = (_0024_00246042_002423782 = new StringLiteralExpression(LexicalInfo.Empty));
						string text598 = (_0024_00246042_002423782.Value = "act:");
						Expression expression532 = (binaryExpression135.Left = _0024_00246042_002423782);
						BinaryExpression binaryExpression136 = _0024_00246044_002423784;
						ReferenceExpression referenceExpression121 = (_0024_00246043_002423783 = new ReferenceExpression(LexicalInfo.Empty));
						string text600 = (_0024_00246043_002423783.Name = "act");
						Expression expression534 = (binaryExpression136.Right = new MemberReferenceExpression(_0024_00246043_002423783, CodeSerializer.LiftName(_0024self__002423859.actionGroupName)));
						Expression expression536 = (binaryExpression133.Left = _0024_00246044_002423784);
						BinaryExpression binaryExpression137 = _0024_00246046_002423786;
						StringLiteralExpression stringLiteralExpression11 = (_0024_00246045_002423785 = new StringLiteralExpression(LexicalInfo.Empty));
						string text602 = (_0024_00246045_002423785.Value = " - ");
						Expression expression538 = (binaryExpression137.Right = _0024_00246045_002423785);
						Expression expression540 = (binaryExpression131.Left = _0024_00246046_002423786);
						BinaryExpression binaryExpression138 = _0024_00246048_002423788;
						ReferenceExpression referenceExpression122 = (_0024_00246047_002423787 = new ReferenceExpression(LexicalInfo.Empty));
						string text604 = (_0024_00246047_002423787.Name = "act");
						Expression expression542 = (binaryExpression138.Right = new MemberReferenceExpression(_0024_00246047_002423787, CodeSerializer.LiftName(_0024self__002423859.actionIdName)));
						Expression expression544 = (binaryExpression129.Left = _0024_00246048_002423788);
						BinaryExpression binaryExpression139 = _0024_00246050_002423790;
						StringLiteralExpression stringLiteralExpression12 = (_0024_00246049_002423789 = new StringLiteralExpression(LexicalInfo.Empty));
						string text606 = (_0024_00246049_002423789.Value = " tm:");
						Expression expression546 = (binaryExpression139.Right = _0024_00246049_002423789);
						Expression expression548 = (binaryExpression127.Left = _0024_00246050_002423790);
						BinaryExpression binaryExpression140 = _0024_00246052_002423792;
						ReferenceExpression referenceExpression123 = (_0024_00246051_002423791 = new ReferenceExpression(LexicalInfo.Empty));
						string text608 = (_0024_00246051_002423791.Name = "act");
						Expression expression550 = (binaryExpression140.Right = new MemberReferenceExpression(_0024_00246051_002423791, CodeSerializer.LiftName(_0024actTimeVar_002423238)));
						Expression expression552 = (binaryExpression125.Left = _0024_00246052_002423792);
						BinaryExpression binaryExpression141 = _0024_00246054_002423794;
						StringLiteralExpression stringLiteralExpression13 = (_0024_00246053_002423793 = new StringLiteralExpression(LexicalInfo.Empty));
						string text610 = (_0024_00246053_002423793.Value = " fr:");
						Expression expression554 = (binaryExpression141.Right = _0024_00246053_002423793);
						Expression expression556 = (binaryExpression123.Left = _0024_00246054_002423794);
						BinaryExpression binaryExpression142 = _0024_00246056_002423796;
						ReferenceExpression referenceExpression124 = (_0024_00246055_002423795 = new ReferenceExpression(LexicalInfo.Empty));
						string text612 = (_0024_00246055_002423795.Name = "act");
						Expression expression558 = (binaryExpression142.Right = new MemberReferenceExpression(_0024_00246055_002423795, CodeSerializer.LiftName(_0024actFrameVar_002423242)));
						array124[1] = _0024_00246056_002423796;
						ExpressionCollection expressionCollection70 = (methodInvocationExpression103.Arguments = ExpressionCollection.FromArray(array124));
						array123[0] = Statement.Lift(_0024_00246057_002423797);
						BinaryExpression binaryExpression143 = (_0024_00246060_002423800 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType114 = (_0024_00246060_002423800.Operator = BinaryOperatorType.InPlaceAddition);
						BinaryExpression binaryExpression144 = _0024_00246060_002423800;
						ReferenceExpression referenceExpression125 = (_0024_00246058_002423798 = new ReferenceExpression(LexicalInfo.Empty));
						string text614 = (_0024_00246058_002423798.Name = "y");
						Expression expression560 = (binaryExpression144.Left = _0024_00246058_002423798);
						BinaryExpression binaryExpression145 = _0024_00246060_002423800;
						IntegerLiteralExpression integerLiteralExpression12 = (_0024_00246059_002423799 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num30 = (_0024_00246059_002423799.Value = 20L);
						bool flag188 = (_0024_00246059_002423799.IsLong = false);
						Expression expression562 = (binaryExpression145.Right = _0024_00246059_002423799);
						array123[1] = Statement.Lift(_0024_00246060_002423800);
						StatementCollection statementCollection96 = (block196.Statements = StatementCollection.FromArray(array123));
						Block block198 = (forStatement28.Block = _0024_00246061_002423801);
						array121[1] = Statement.Lift(_0024_00246062_002423802);
						StatementCollection statementCollection98 = (block194.Statements = StatementCollection.FromArray(array121));
						Block block200 = (ifStatement55.TrueBlock = _0024_00246063_002423803);
						array114[3] = Statement.Lift(_0024_00246064_002423804);
						StatementCollection statementCollection100 = (block184.Statements = StatementCollection.FromArray(array114));
						Block block202 = (method67.Body = _0024_00246065_002423805);
						array3[23] = _0024_00246066_002423806;
						Method method68 = (_0024_00246091_002423831 = new Method(LexicalInfo.Empty));
						TypeMemberModifiers typeMemberModifiers80 = (_0024_00246091_002423831.Modifiers = TypeMemberModifiers.Public);
						string text616 = (_0024_00246091_002423831.Name = "actLateUpdate");
						Method method69 = _0024_00246091_002423831;
						Block block203 = (_0024_00246090_002423830 = new Block(LexicalInfo.Empty));
						Block block204 = _0024_00246090_002423830;
						Statement[] array126 = new Statement[3];
						BinaryExpression binaryExpression146 = (_0024_00246068_002423808 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType116 = (_0024_00246068_002423808.Operator = BinaryOperatorType.Assign);
						Expression expression564 = (_0024_00246068_002423808.Left = Expression.Lift(_0024changeNumVar_002423234));
						BinaryExpression binaryExpression147 = _0024_00246068_002423808;
						IntegerLiteralExpression integerLiteralExpression13 = (_0024_00246067_002423807 = new IntegerLiteralExpression(LexicalInfo.Empty));
						long num32 = (_0024_00246067_002423807.Value = 0L);
						bool flag190 = (_0024_00246067_002423807.IsLong = false);
						Expression expression566 = (binaryExpression147.Right = _0024_00246067_002423807);
						array126[0] = Statement.Lift(_0024_00246068_002423808);
						BinaryExpression binaryExpression148 = (_0024_00246073_002423813 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType118 = (_0024_00246073_002423813.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression149 = _0024_00246073_002423813;
						ReferenceExpression referenceExpression126 = (_0024_00246069_002423809 = new ReferenceExpression(LexicalInfo.Empty));
						string text618 = (_0024_00246069_002423809.Name = "groups");
						Expression expression568 = (binaryExpression149.Left = _0024_00246069_002423809);
						BinaryExpression binaryExpression150 = _0024_00246073_002423813;
						MethodInvocationExpression methodInvocationExpression107 = (_0024_00246072_002423812 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression108 = _0024_00246072_002423812;
						ReferenceExpression referenceExpression127 = (_0024_00246070_002423810 = new ReferenceExpression(LexicalInfo.Empty));
						string text620 = (_0024_00246070_002423810.Name = "array");
						Expression expression570 = (methodInvocationExpression108.Target = _0024_00246070_002423810);
						MethodInvocationExpression methodInvocationExpression109 = _0024_00246072_002423812;
						Expression[] array127 = new Expression[1];
						MemberReferenceExpression memberReferenceExpression43 = (_0024_00246071_002423811 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text622 = (_0024_00246071_002423811.Name = "Keys");
						Expression expression572 = (_0024_00246071_002423811.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						array127[0] = _0024_00246071_002423811;
						ExpressionCollection expressionCollection72 = (methodInvocationExpression109.Arguments = ExpressionCollection.FromArray(array127));
						Expression expression574 = (binaryExpression150.Right = _0024_00246072_002423812);
						array126[1] = Statement.Lift(_0024_00246073_002423813);
						ForStatement forStatement29 = (_0024_00246089_002423829 = new ForStatement(LexicalInfo.Empty));
						ForStatement forStatement30 = _0024_00246089_002423829;
						Declaration[] array128 = new Declaration[1];
						Declaration declaration20 = (_0024_00246074_002423814 = new Declaration(LexicalInfo.Empty));
						string text624 = (_0024_00246074_002423814.Name = "grp");
						array128[0] = _0024_00246074_002423814;
						DeclarationCollection declarationCollection16 = (forStatement30.Declarations = DeclarationCollection.FromArray(array128));
						ForStatement forStatement31 = _0024_00246089_002423829;
						ReferenceExpression referenceExpression128 = (_0024_00246075_002423815 = new ReferenceExpression(LexicalInfo.Empty));
						string text626 = (_0024_00246075_002423815.Name = "groups");
						Expression expression576 = (forStatement31.Iterator = _0024_00246075_002423815);
						ForStatement forStatement32 = _0024_00246089_002423829;
						Block block205 = (_0024_00246088_002423828 = new Block(LexicalInfo.Empty));
						Block block206 = _0024_00246088_002423828;
						Statement[] array129 = new Statement[2];
						BinaryExpression binaryExpression151 = (_0024_00246080_002423820 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType120 = (_0024_00246080_002423820.Operator = BinaryOperatorType.Assign);
						BinaryExpression binaryExpression152 = _0024_00246080_002423820;
						ReferenceExpression referenceExpression129 = (_0024_00246076_002423816 = new ReferenceExpression(LexicalInfo.Empty));
						string text628 = (_0024_00246076_002423816.Name = "act");
						Expression expression578 = (binaryExpression152.Left = _0024_00246076_002423816);
						BinaryExpression binaryExpression153 = _0024_00246080_002423820;
						SlicingExpression slicingExpression28 = (_0024_00246079_002423819 = new SlicingExpression(LexicalInfo.Empty));
						Expression expression580 = (_0024_00246079_002423819.Target = Expression.Lift(_0024self__002423859.currentActionDic));
						SlicingExpression slicingExpression29 = _0024_00246079_002423819;
						Slice[] array130 = new Slice[1];
						Slice slice25 = (_0024_00246078_002423818 = new Slice(LexicalInfo.Empty));
						Slice slice26 = _0024_00246078_002423818;
						ReferenceExpression referenceExpression130 = (_0024_00246077_002423817 = new ReferenceExpression(LexicalInfo.Empty));
						string text630 = (_0024_00246077_002423817.Name = "grp");
						Expression expression582 = (slice26.Begin = _0024_00246077_002423817);
						array130[0] = _0024_00246078_002423818;
						SliceCollection sliceCollection26 = (slicingExpression29.Indices = SliceCollection.FromArray(array130));
						Expression expression584 = (binaryExpression153.Right = _0024_00246079_002423819);
						array129[0] = Statement.Lift(_0024_00246080_002423820);
						IfStatement ifStatement56 = (_0024_00246087_002423827 = new IfStatement(LexicalInfo.Empty));
						IfStatement ifStatement57 = _0024_00246087_002423827;
						BinaryExpression binaryExpression154 = (_0024_00246082_002423822 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType122 = (_0024_00246082_002423822.Operator = BinaryOperatorType.Inequality);
						BinaryExpression binaryExpression155 = _0024_00246082_002423822;
						ReferenceExpression referenceExpression131 = (_0024_00246081_002423821 = new ReferenceExpression(LexicalInfo.Empty));
						string text632 = (_0024_00246081_002423821.Name = "act");
						Expression expression586 = (binaryExpression155.Left = new MemberReferenceExpression(_0024_00246081_002423821, CodeSerializer.LiftName(_0024self__002423859.actionLateUpdate)));
						Expression expression588 = (_0024_00246082_002423822.Right = new NullLiteralExpression(LexicalInfo.Empty));
						Expression expression590 = (ifStatement57.Condition = _0024_00246082_002423822);
						IfStatement ifStatement58 = _0024_00246087_002423827;
						Block block207 = (_0024_00246086_002423826 = new Block(LexicalInfo.Empty));
						Block block208 = _0024_00246086_002423826;
						Statement[] array131 = new Statement[1];
						MethodInvocationExpression methodInvocationExpression110 = (_0024_00246085_002423825 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression111 = _0024_00246085_002423825;
						ReferenceExpression referenceExpression132 = (_0024_00246083_002423823 = new ReferenceExpression(LexicalInfo.Empty));
						string text634 = (_0024_00246083_002423823.Name = "act");
						Expression expression592 = (methodInvocationExpression111.Target = new MemberReferenceExpression(_0024_00246083_002423823, CodeSerializer.LiftName(_0024self__002423859.actionLateUpdate)));
						MethodInvocationExpression methodInvocationExpression112 = _0024_00246085_002423825;
						Expression[] array132 = new Expression[1];
						ReferenceExpression referenceExpression133 = (_0024_00246084_002423824 = new ReferenceExpression(LexicalInfo.Empty));
						string text636 = (_0024_00246084_002423824.Name = "act");
						array132[0] = _0024_00246084_002423824;
						ExpressionCollection expressionCollection74 = (methodInvocationExpression112.Arguments = ExpressionCollection.FromArray(array132));
						array131[0] = Statement.Lift(_0024_00246085_002423825);
						StatementCollection statementCollection102 = (block208.Statements = StatementCollection.FromArray(array131));
						Block block210 = (ifStatement58.TrueBlock = _0024_00246086_002423826);
						array129[1] = Statement.Lift(_0024_00246087_002423827);
						StatementCollection statementCollection104 = (block206.Statements = StatementCollection.FromArray(array129));
						Block block212 = (forStatement32.Block = _0024_00246088_002423828);
						array126[2] = Statement.Lift(_0024_00246089_002423829);
						StatementCollection statementCollection106 = (block204.Statements = StatementCollection.FromArray(array126));
						Block block214 = (method69.Body = _0024_00246090_002423830);
						array3[24] = _0024_00246091_002423831;
						TypeMemberCollection typeMemberCollection4 = (module2.Members = TypeMemberCollection.FromArray(array3));
						Block block216 = (_0024_00246092_002423832.Globals = new Block(LexicalInfo.Empty));
						_0024module_002423833 = _0024_00246092_002423832;
						_0024_0024iterator_002414218_002423855 = _0024module_002423833.Members.GetEnumerator();
						_state = 2;
						goto case 3;
					}
					case 3:
						if (_0024_0024iterator_002414218_002423855.MoveNext())
						{
							_0024___item_002423834 = _0024_0024iterator_002414218_002423855.Current;
							flag191 = Yield(3, _0024___item_002423834);
						}
						else
						{
							_state = 1;
							_0024ensure2();
							Method method70 = (_0024_00246110_002423852 = new Method(LexicalInfo.Empty));
							TypeMemberModifiers typeMemberModifiers82 = (_0024_00246110_002423852.Modifiers = TypeMemberModifiers.Protected);
							string text638 = (_0024_00246110_002423852.Name = "createActionData");
							Method method71 = _0024_00246110_002423852;
							ParameterDeclaration[] array133 = new ParameterDeclaration[1];
							ParameterDeclaration parameterDeclaration39 = (_0024_00246094_002423836 = new ParameterDeclaration(LexicalInfo.Empty));
							string text640 = (_0024_00246094_002423836.Name = "actID");
							ParameterDeclaration parameterDeclaration40 = _0024_00246094_002423836;
							SimpleTypeReference simpleTypeReference48 = (_0024_00246093_002423835 = new SimpleTypeReference(LexicalInfo.Empty));
							bool flag193 = (_0024_00246093_002423835.IsPointer = false);
							string text642 = (_0024_00246093_002423835.Name = "ActionEnum");
							TypeReference typeReference106 = (parameterDeclaration40.Type = _0024_00246093_002423835);
							array133[0] = _0024_00246094_002423836;
							ParameterDeclarationCollection parameterDeclarationCollection40 = (method71.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array133));
							Method method72 = _0024_00246110_002423852;
							SimpleTypeReference simpleTypeReference49 = (_0024_00246095_002423837 = new SimpleTypeReference(LexicalInfo.Empty));
							bool flag195 = (_0024_00246095_002423837.IsPointer = false);
							string text644 = (_0024_00246095_002423837.Name = "ActionBase");
							TypeReference typeReference108 = (method72.ReturnType = _0024_00246095_002423837);
							Method method73 = _0024_00246110_002423852;
							Block block217 = (_0024_00246109_002423851 = new Block(LexicalInfo.Empty));
							Block block218 = _0024_00246109_002423851;
							Statement[] array134 = new Statement[1];
							IfStatement ifStatement59 = (_0024_00246108_002423850 = new IfStatement(LexicalInfo.Empty));
							IfStatement ifStatement60 = _0024_00246108_002423850;
							UnaryExpression unaryExpression18 = (_0024_00246099_002423841 = new UnaryExpression(LexicalInfo.Empty));
							UnaryOperatorType unaryOperatorType20 = (_0024_00246099_002423841.Operator = UnaryOperatorType.LogicalNot);
							UnaryExpression unaryExpression19 = _0024_00246099_002423841;
							MethodInvocationExpression methodInvocationExpression113 = (_0024_00246098_002423840 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression114 = _0024_00246098_002423840;
							ReferenceExpression referenceExpression134 = (_0024_00246096_002423838 = new ReferenceExpression(LexicalInfo.Empty));
							string text646 = (_0024_00246096_002423838.Name = "IsValidActionID");
							Expression expression594 = (methodInvocationExpression114.Target = _0024_00246096_002423838);
							MethodInvocationExpression methodInvocationExpression115 = _0024_00246098_002423840;
							Expression[] array135 = new Expression[1];
							ReferenceExpression referenceExpression135 = (_0024_00246097_002423839 = new ReferenceExpression(LexicalInfo.Empty));
							string text648 = (_0024_00246097_002423839.Name = "actID");
							array135[0] = _0024_00246097_002423839;
							ExpressionCollection expressionCollection76 = (methodInvocationExpression115.Arguments = ExpressionCollection.FromArray(array135));
							Expression expression596 = (unaryExpression19.Operand = _0024_00246098_002423840);
							Expression expression598 = (ifStatement60.Condition = _0024_00246099_002423841);
							IfStatement ifStatement61 = _0024_00246108_002423850;
							Block block219 = (_0024_00246107_002423849 = new Block(LexicalInfo.Empty));
							Block block220 = _0024_00246107_002423849;
							Statement[] array136 = new Statement[1];
							RaiseStatement raiseStatement3 = (_0024_00246106_002423848 = new RaiseStatement(LexicalInfo.Empty));
							RaiseStatement raiseStatement4 = _0024_00246106_002423848;
							BinaryExpression binaryExpression156 = (_0024_00246105_002423847 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType124 = (_0024_00246105_002423847.Operator = BinaryOperatorType.Addition);
							BinaryExpression binaryExpression157 = _0024_00246105_002423847;
							BinaryExpression binaryExpression158 = (_0024_00246103_002423845 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType126 = (_0024_00246103_002423845.Operator = BinaryOperatorType.Addition);
							BinaryExpression binaryExpression159 = _0024_00246103_002423845;
							BinaryExpression binaryExpression160 = (_0024_00246101_002423843 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType128 = (_0024_00246101_002423843.Operator = BinaryOperatorType.Addition);
							BinaryExpression binaryExpression161 = _0024_00246101_002423843;
							StringLiteralExpression stringLiteralExpression14 = (_0024_00246100_002423842 = new StringLiteralExpression(LexicalInfo.Empty));
							string text650 = (_0024_00246100_002423842.Value = "invalid ");
							Expression expression600 = (binaryExpression161.Left = _0024_00246100_002423842);
							Expression expression602 = (_0024_00246101_002423843.Right = Expression.Lift(_0024parentClass_002423228.Name));
							Expression expression604 = (binaryExpression159.Left = _0024_00246101_002423843);
							BinaryExpression binaryExpression162 = _0024_00246103_002423845;
							StringLiteralExpression stringLiteralExpression15 = (_0024_00246102_002423844 = new StringLiteralExpression(LexicalInfo.Empty));
							string text652 = (_0024_00246102_002423844.Value = " enum: ");
							Expression expression606 = (binaryExpression162.Right = _0024_00246102_002423844);
							Expression expression608 = (binaryExpression157.Left = _0024_00246103_002423845);
							BinaryExpression binaryExpression163 = _0024_00246105_002423847;
							ReferenceExpression referenceExpression136 = (_0024_00246104_002423846 = new ReferenceExpression(LexicalInfo.Empty));
							string text654 = (_0024_00246104_002423846.Name = "actID");
							Expression expression610 = (binaryExpression163.Right = _0024_00246104_002423846);
							Expression expression612 = (raiseStatement4.Exception = _0024_00246105_002423847);
							array136[0] = Statement.Lift(_0024_00246106_002423848);
							StatementCollection statementCollection108 = (block220.Statements = StatementCollection.FromArray(array136));
							Block block222 = (ifStatement61.TrueBlock = _0024_00246107_002423849);
							array134[0] = Statement.Lift(_0024_00246108_002423850);
							StatementCollection statementCollection110 = (block218.Statements = StatementCollection.FromArray(array134));
							Block block224 = (method73.Body = _0024_00246109_002423851);
							_0024enumDispatchMethod_002423853 = _0024_00246110_002423852;
							_0024self__002423859.createDispatchBlock = _0024enumDispatchMethod_002423853.Body;
							_0024parentClass_002423228["createDispatchBlock"] = _0024self__002423859.createDispatchBlock;
							flag191 = Yield(4, _0024enumDispatchMethod_002423853);
						}
						goto IL_c66b;
					case 4:
						YieldDefault(1);
						break;
					case 1:
					case 2:
						break;
					}
				}
				catch
				{
					//try-fault
					Dispose();
					throw;
				}
				int result = 0;
				goto IL_c66f;
				IL_c66b:
				result = (flag191 ? 1 : 0);
				goto IL_c66f;
				IL_c66f:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414218_002423855.Dispose();
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
				}
			}
		}

		internal Boo.Lang.Compiler.Ast.Node _0024mc_002423860;

		internal string _0024enumName_002423861;

		internal string _0024enumNumName_002423862;

		internal Act_methodMacro _0024self__002423863;

		public _0024emitActionSystemCode_002423227(Boo.Lang.Compiler.Ast.Node mc, string enumName, string enumNumName, Act_methodMacro self_)
		{
			_0024mc_002423860 = mc;
			_0024enumName_002423861 = enumName;
			_0024enumNumName_002423862 = enumNumName;
			_0024self__002423863 = self_;
		}

		public override IEnumerator<TypeMember> GetEnumerator()
		{
			return new _0024(_0024mc_002423860, _0024enumName_002423861, _0024enumNumName_002423862, _0024self__002423863);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024variableDeclarations_002423864 : GenericGenerator<Field>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Field>, IEnumerator
		{
			internal Statement _0024s_002423865;

			internal Statement _0024_0024match_00242735_002423866;

			internal DeclarationStatement _0024_0024match_00242736_002423867;

			internal Declaration _0024decl_002423868;

			internal ExpressionStatement _0024_0024match_00242737_002423869;

			internal Expression _0024expr_002423870;

			internal BinaryExpression _0024bexpr_002423871;

			internal ReferenceExpression _0024left_002423872;

			internal TypeMemberStatement _0024_0024match_00242738_002423873;

			internal TypeMember _0024tmem_002423874;

			internal IEnumerator<Statement> _0024_0024iterator_002414220_002423875;

			internal Block _0024varBlock_002423876;

			internal Act_methodMacro _0024self__002423877;

			public _0024(Block varBlock, Act_methodMacro self_)
			{
				_0024varBlock_002423876 = varBlock;
				_0024self__002423877 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (_0024varBlock_002423876 != null)
						{
							_0024_0024iterator_002414220_002423875 = _0024varBlock_002423876.Statements.GetEnumerator();
							_state = 2;
							break;
						}
						goto end_IL_0000;
					case 3:
					case 4:
					case 5:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					if (_0024_0024iterator_002414220_002423875.MoveNext())
					{
						_0024s_002423865 = _0024_0024iterator_002414220_002423875.Current;
						_0024_0024match_00242735_002423866 = _0024s_002423865;
						if (_0024_0024match_00242735_002423866 is DeclarationStatement)
						{
							DeclarationStatement declarationStatement = (_0024_0024match_00242736_002423867 = (DeclarationStatement)_0024_0024match_00242735_002423866);
							if (true)
							{
								Declaration declaration = (_0024decl_002423868 = _0024_0024match_00242736_002423867.Declaration);
								if (true)
								{
									flag = Yield(3, _0024self__002423877.publicField(_0024decl_002423868.Name, _0024decl_002423868.Type));
									goto IL_0330;
								}
							}
						}
						if (_0024_0024match_00242735_002423866 is ExpressionStatement)
						{
							ExpressionStatement expressionStatement = (_0024_0024match_00242737_002423869 = (ExpressionStatement)_0024_0024match_00242735_002423866);
							if (true)
							{
								Expression expression = (_0024expr_002423870 = _0024_0024match_00242737_002423869.Expression);
								if (true)
								{
									_0024bexpr_002423871 = _0024expr_002423870 as BinaryExpression;
									if (_0024bexpr_002423871 == null || _0024bexpr_002423871.Operator != BinaryOperatorType.Assign)
									{
										throw new Exception(new StringBuilder("var block does not supported '").Append(_0024s_002423865.ToString().Trim()).Append("' -- ").Append(_0024s_002423865.GetType())
											.ToString());
									}
									_0024left_002423872 = _0024bexpr_002423871.Left as ReferenceExpression;
									if (_0024left_002423872 == null)
									{
										throw new Exception(new StringBuilder("var block does not supported '").Append(_0024s_002423865.ToString().Trim()).Append("' -- ").Append(_0024s_002423865.GetType())
											.ToString());
									}
									flag = Yield(4, _0024self__002423877.publicField(_0024left_002423872.Name, new SimpleTypeReference("duck")));
									goto IL_0330;
								}
							}
						}
						if (_0024_0024match_00242735_002423866 is TypeMemberStatement)
						{
							TypeMemberStatement typeMemberStatement = (_0024_0024match_00242738_002423873 = (TypeMemberStatement)_0024_0024match_00242735_002423866);
							if (true)
							{
								TypeMember typeMember = (_0024tmem_002423874 = _0024_0024match_00242738_002423873.TypeMember);
								if (true)
								{
									flag = Yield(5, _0024self__002423877.publicField(_0024tmem_002423874.Name, new SimpleTypeReference("duck")));
									goto IL_0330;
								}
							}
						}
						throw new Exception(new StringBuilder("var block does not supported '").Append(_0024s_002423865.ToString().Trim()).Append("' -- ").Append(_0024s_002423865.GetType())
							.ToString());
					}
					_state = 1;
					_0024ensure2();
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
				goto IL_0331;
				IL_0330:
				result = (flag ? 1 : 0);
				goto IL_0331;
				IL_0331:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414220_002423875.Dispose();
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
				case 4:
				case 5:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal Block _0024varBlock_002423878;

		internal Act_methodMacro _0024self__002423879;

		public _0024variableDeclarations_002423864(Block varBlock, Act_methodMacro self_)
		{
			_0024varBlock_002423878 = varBlock;
			_0024self__002423879 = self_;
		}

		public override IEnumerator<Field> GetEnumerator()
		{
			return new _0024(_0024varBlock_002423878, _0024self__002423879);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024variableInitializeStatements_002423880 : GenericGenerator<ExpressionStatement>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<ExpressionStatement>, IEnumerator
		{
			internal Statement _0024s_002423881;

			internal Statement _0024_0024match_00242739_002423882;

			internal DeclarationStatement _0024_0024match_00242740_002423883;

			internal Declaration _0024decl_002423884;

			internal Expression _0024init_002423885;

			internal ExpressionStatement _0024_0024match_00242741_002423886;

			internal Expression _0024expr_002423887;

			internal BinaryExpression _0024bexpr_002423888;

			internal ReferenceExpression _0024left_002423889;

			internal Expression _0024right_002423890;

			internal TypeMemberStatement _0024_0024match_00242742_002423891;

			internal TypeMember _0024tmem_002423892;

			internal IEnumerator<Statement> _0024_0024iterator_002414221_002423893;

			internal Block _0024varBlock_002423894;

			internal string _0024baseVarName_002423895;

			internal Act_methodMacro _0024self__002423896;

			public _0024(Block varBlock, string baseVarName, Act_methodMacro self_)
			{
				_0024varBlock_002423894 = varBlock;
				_0024baseVarName_002423895 = baseVarName;
				_0024self__002423896 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						if (_0024varBlock_002423894 != null)
						{
							_0024_0024iterator_002414221_002423893 = _0024varBlock_002423894.Statements.GetEnumerator();
							_state = 2;
							break;
						}
						goto end_IL_0000;
					case 3:
					case 4:
					case 5:
						break;
					case 1:
					case 2:
						goto end_IL_0000;
					}
					while (true)
					{
						if (_0024_0024iterator_002414221_002423893.MoveNext())
						{
							_0024s_002423881 = _0024_0024iterator_002414221_002423893.Current;
							_0024_0024match_00242739_002423882 = _0024s_002423881;
							if (_0024_0024match_00242739_002423882 is DeclarationStatement)
							{
								DeclarationStatement declarationStatement = (_0024_0024match_00242740_002423883 = (DeclarationStatement)_0024_0024match_00242739_002423882);
								if (true)
								{
									Declaration declaration = (_0024decl_002423884 = _0024_0024match_00242740_002423883.Declaration);
									if (true)
									{
										Expression expression = (_0024init_002423885 = _0024_0024match_00242740_002423883.Initializer);
										if (true)
										{
											if (_0024init_002423885 != null)
											{
												flag = Yield(3, _0024self__002423896.assignStatement(_0024baseVarName_002423895 + "." + _0024decl_002423884.Name, _0024init_002423885));
												goto IL_0304;
											}
											continue;
										}
									}
								}
							}
							if (_0024_0024match_00242739_002423882 is ExpressionStatement)
							{
								ExpressionStatement expressionStatement = (_0024_0024match_00242741_002423886 = (ExpressionStatement)_0024_0024match_00242739_002423882);
								if (true)
								{
									Expression expression2 = (_0024expr_002423887 = _0024_0024match_00242741_002423886.Expression);
									if (true)
									{
										_0024bexpr_002423888 = _0024expr_002423887 as BinaryExpression;
										if (_0024bexpr_002423888 == null || _0024bexpr_002423888.Operator != BinaryOperatorType.Assign)
										{
											continue;
										}
										_0024left_002423889 = _0024bexpr_002423888.Left as ReferenceExpression;
										if (_0024left_002423889 == null)
										{
											continue;
										}
										_0024right_002423890 = _0024bexpr_002423888.Right;
										flag = Yield(4, _0024self__002423896.assignStatement(_0024baseVarName_002423895 + "." + _0024left_002423889.Name, _0024right_002423890));
										goto IL_0304;
									}
								}
							}
							if (_0024_0024match_00242739_002423882 is TypeMemberStatement)
							{
								TypeMemberStatement typeMemberStatement = (_0024_0024match_00242742_002423891 = (TypeMemberStatement)_0024_0024match_00242739_002423882);
								if (true)
								{
									TypeMember typeMember = (_0024tmem_002423892 = _0024_0024match_00242742_002423891.TypeMember);
									if (true)
									{
										flag = Yield(5, _0024self__002423896.assignStatement(_0024baseVarName_002423895 + "." + _0024tmem_002423892.Name, new IntegerLiteralExpression(0L)));
										goto IL_0304;
									}
								}
							}
							throw new Exception(new StringBuilder("var block does not supported '").Append(_0024s_002423881).Append("'").ToString());
						}
						_state = 1;
						_0024ensure2();
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
				goto IL_0305;
				IL_0304:
				result = (flag ? 1 : 0);
				goto IL_0305;
				IL_0305:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414221_002423893.Dispose();
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
				case 4:
				case 5:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal Block _0024varBlock_002423897;

		internal string _0024baseVarName_002423898;

		internal Act_methodMacro _0024self__002423899;

		public _0024variableInitializeStatements_002423880(Block varBlock, string baseVarName, Act_methodMacro self_)
		{
			_0024varBlock_002423897 = varBlock;
			_0024baseVarName_002423898 = baseVarName;
			_0024self__002423899 = self_;
		}

		public override IEnumerator<ExpressionStatement> GetEnumerator()
		{
			return new _0024(_0024varBlock_002423897, _0024baseVarName_002423898, _0024self__002423899);
		}
	}

	[NonSerialized]
	private const bool ENABLE_ACTION_TIME = true;

	[NonSerialized]
	private const int CHANGE_LIMIT_WITHOUT_UPDATE = 100;

	[NonSerialized]
	private const string DEFAULT_GROUP_NAME = "$default$";

	[NonSerialized]
	private const string ACTION_ENUM_NAME = "ActionEnum";

	[NonSerialized]
	private const string NOACTION_ENUM_NAME = "_noaction_";

	[NonSerialized]
	private const string ACTION_ENUM_NUM_NAME = "NUM";

	[NonSerialized]
	private const string ACTION_TIME_VARNAME = "actionTime";

	[NonSerialized]
	private const string GROUP_TIME_PROPNAME = "actionTime{0}";

	[NonSerialized]
	private const string PREACTION_TIME_VARNAME = "preActionTime";

	[NonSerialized]
	private const string REAL_ACTION_TIME_VARNAME = "realActionTime";

	[NonSerialized]
	private const string REAL_ACTION_INIT_TIME_VARNAME = "realActionTimeInit";

	[NonSerialized]
	private const string ACTION_FRAME_VARNAME = "actionFrame";

	[NonSerialized]
	private const string ACTION_DATA_CLASS_NAME = "ActionClass{0}";

	[NonSerialized]
	private const string TEST_PROP_NAME = "Is{0}";

	[NonSerialized]
	private const string TEST_TIME_NAME = "Is{0}AtTime";

	[NonSerialized]
	private const string ACTION_DATA_PROP_NAME = "{0}Data";

	[NonSerialized]
	private const string ACTION_CREATOR_NAME = "create{0}";

	[NonSerialized]
	private const string ACTION_DATA_CREATOR_NAME = "createData{0}";

	[NonSerialized]
	private const string TIME_NOW = "UnityEngine.Time.time";

	[NonSerialized]
	private const string DELTA_TIME_NOW = "UnityEngine.Time.deltaTime";

	private EnumDefinition actionEnumDef;

	private ReferenceExpression actionIdName;

	private ReferenceExpression actionGroupName;

	private ReferenceExpression actionInit;

	private ReferenceExpression actionExit;

	private ReferenceExpression actionUpdate;

	private ReferenceExpression actionFixedUpdate;

	private ReferenceExpression actionOnGUI;

	private ReferenceExpression actionLateUpdate;

	private ReferenceExpression actionCoroutine;

	private HashSet<string> actionNameSet;

	private HashSet<string> actionGroupSet;

	private Block createDispatchBlock;

	private ReferenceExpression currentActionDic;

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002423095(mc, this);
	}

	protected IEnumerable<object[]> forAllInnerBlocks(MacroStatement mc)
	{
		return new _0024forAllInnerBlocks_002423215(mc);
	}

	protected IEnumerable<TypeMember> emitActionSystemCode(Boo.Lang.Compiler.Ast.Node mc, string enumName, string enumNumName)
	{
		return new _0024emitActionSystemCode_002423227(mc, enumName, enumNumName, this);
	}

	protected Expression[] timeVars()
	{
		Expression expression = null;
		Expression expression2 = null;
		if (true)
		{
			expression = refLift("UnityEngine.Time.time");
			expression2 = refLift("UnityEngine.Time.deltaTime");
		}
		else
		{
			expression = new IntegerLiteralExpression(0L);
			expression2 = new IntegerLiteralExpression(0L);
		}
		return new Expression[2] { expression, expression2 };
	}

	protected ClassDefinition enclosingClass(Boo.Lang.Compiler.Ast.Node node)
	{
		ClassDefinition ancestor = node.GetAncestor<ClassDefinition>();
		if (ancestor == null)
		{
			throw new AssertionFailedException("parentClass != null");
		}
		return ancestor;
	}

	protected string methodName(MethodInvocationExpression miexpr)
	{
		if (!(miexpr.Target is ReferenceExpression referenceExpression))
		{
			throw new AssertionFailedException("r != null");
		}
		return referenceExpression.Name;
	}

	protected ParameterDeclaration paramDecl(string argName, string typeName)
	{
		return new ParameterDeclaration(argName, TypeReference.Lift(typeName));
	}

	protected Field publicField(string fname, TypeReference type)
	{
		Field field = new Field();
		string text2 = (field.Name = fname);
		TypeReference typeReference2 = (field.Type = type);
		Field field2 = field;
		field2.Modifiers = TypeMemberModifiers.Public;
		return field2;
	}

	protected ExpressionStatement assignStatement(string leftExpr, Expression expr)
	{
		if (string.IsNullOrEmpty(leftExpr) || expr == null)
		{
			throw new AssertionFailedException("(not string.IsNullOrEmpty(leftExpr)) and (expr != null)");
		}
		BinaryExpression binaryExpression = new BinaryExpression();
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		BinaryExpression binaryExpression2 = binaryExpression;
		binaryExpression2.Left = refLift(leftExpr);
		binaryExpression2.Right = expr;
		ExpressionStatement expressionStatement = new ExpressionStatement();
		Expression expression2 = (expressionStatement.Expression = binaryExpression2);
		return expressionStatement;
	}

	protected object[] tryCastsToParameters(ExpressionCollection casts, Expression memInitBaseVar)
	{
		ParameterDeclarationCollection parameterDeclarationCollection = new ParameterDeclarationCollection();
		ExpressionCollection expressionCollection = new ExpressionCollection();
		System.Collections.Generic.List<Field> list = new System.Collections.Generic.List<Field>();
		Block block = new Block();
		IEnumerator<Expression> enumerator = casts.GetEnumerator();
		try
		{
			string text = default(string);
			while (enumerator.MoveNext())
			{
				Expression current = enumerator.Current;
				Expression expression = current;
				if (expression is TryCastExpression)
				{
					TryCastExpression tryCastExpression = (TryCastExpression)expression;
					if (true)
					{
						Expression target = tryCastExpression.Target;
						if (true)
						{
							TypeReference type = tryCastExpression.Type;
							if (true)
							{
								text = target.ToCodeString();
								parameterDeclarationCollection.Add(new ParameterDeclaration(text, type));
								expressionCollection.Add(new ReferenceExpression(text));
								list.Add(publicField(text, type));
								BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
								BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
								Expression expression3 = (binaryExpression.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName((ReferenceExpression)target)));
								Expression expression5 = (binaryExpression.Right = Expression.Lift(target));
								block.Add(binaryExpression);
								continue;
							}
						}
					}
				}
				if (expression is ReferenceExpression)
				{
					ReferenceExpression referenceExpression = (ReferenceExpression)expression;
					if (true)
					{
						string name = referenceExpression.Name;
						if (true)
						{
							parameterDeclarationCollection.Add(new ParameterDeclaration(name, null));
							expressionCollection.Add(new ReferenceExpression(name));
							list.Add(publicField(text, null));
							continue;
						}
					}
				}
				throw new Exception(new StringBuilder("'").Append(current.ToCodeString()).Append(" is not a parameter declaration.").ToString());
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		return new object[4] { parameterDeclarationCollection, expressionCollection, list, block };
	}

	protected Method actionCreateChangeMethod(string methodName, ParameterDeclarationCollection paramDecl, string returnType)
	{
		Method method = new Method(methodName);
		if (paramDecl != null)
		{
			object obj = paramDecl.Clone();
			if (!(obj is ParameterDeclarationCollection))
			{
				obj = RuntimeServices.Coerce(obj, typeof(ParameterDeclarationCollection));
			}
			method.Parameters = (ParameterDeclarationCollection)obj;
		}
		method.ReturnType = TypeReference.Lift(returnType);
		return method;
	}

	protected ReferenceExpression tmpVar()
	{
		return new ReferenceExpression(tmpVarName());
	}

	protected string tmpVarName()
	{
		return CompilerContext.Current.GetUniqueName("act", "t");
	}

	protected IEnumerable<Field> variableDeclarations(Block varBlock)
	{
		return new _0024variableDeclarations_002423864(varBlock, this);
	}

	protected IEnumerable<ExpressionStatement> variableInitializeStatements(Block varBlock, string baseVarName)
	{
		return new _0024variableInitializeStatements_002423880(varBlock, baseVarName, this);
	}

	protected BlockExpression subMethodDefinition(string actParamName, object actClassName)
	{
		BlockExpression blockExpression = new BlockExpression();
		ParameterDeclarationCollection parameters = blockExpression.Parameters;
		object obj = actClassName;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		parameters.Add(paramDecl(actParamName, (string)obj));
		return blockExpression;
	}

	protected BlockExpression subCoroutineDefinition(string actParamName, object actClassName)
	{
		BlockExpression blockExpression = new BlockExpression();
		ParameterDeclarationCollection parameters = blockExpression.Parameters;
		object obj = actClassName;
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		parameters.Add(paramDecl(actParamName, (string)obj));
		blockExpression.ReturnType = TypeReference.Lift("System.Collections.IEnumerator");
		return blockExpression;
	}

	protected object[] groupAndStateName(string n)
	{
		object result;
		if (string.IsNullOrEmpty(n))
		{
			result = new object[2];
		}
		else
		{
			int num = n.IndexOf('_');
			result = ((num > 0 && num != checked(n.Length - 1)) ? new string[2]
			{
				n.Substring(0, num),
				n
			} : new string[2] { "$default$", n });
		}
		return (object[])result;
	}

	protected Method changerMethod(string changeMethodName, string createMethodName, string actClassName, ParameterDeclarationCollection actParamDecl, ExpressionCollection actArgList)
	{
		Method method = actionCreateChangeMethod(changeMethodName, actParamDecl, actClassName);
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression();
		methodInvocationExpression.Target = new ReferenceExpression(createMethodName);
		object obj = actArgList.Clone();
		if (!(obj is ExpressionCollection))
		{
			obj = RuntimeServices.Coerce(obj, typeof(ExpressionCollection));
		}
		methodInvocationExpression.Arguments = (ExpressionCollection)obj;
		ReferenceExpression e = tmpVar();
		Block block = new Block(LexicalInfo.Empty);
		Statement[] array = new Statement[3];
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression2 = (binaryExpression.Left = Expression.Lift(e));
		Expression expression4 = (binaryExpression.Right = Expression.Lift(methodInvocationExpression));
		array[0] = Statement.Lift(binaryExpression);
		MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
		string text2 = (referenceExpression.Name = "changeAction");
		Expression expression6 = (methodInvocationExpression2.Target = referenceExpression);
		ExpressionCollection expressionCollection2 = (methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(Expression.Lift(e)));
		array[1] = Statement.Lift(methodInvocationExpression2);
		ReturnStatement returnStatement = new ReturnStatement(LexicalInfo.Empty);
		Expression expression8 = (returnStatement.Expression = Expression.Lift(e));
		array[2] = Statement.Lift(returnStatement);
		StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
		method.Body = block;
		return method;
	}

	protected Method generateCreateMethod(string createMethodName, string createDataMethodName, string actClassName, ParameterDeclarationCollection actParamDecl, ExpressionCollection actArgList, ReferenceExpression memInitBaseVar, Block memInit, Block varBlock)
	{
		Method method = actionCreateChangeMethod(createMethodName, actParamDecl, actClassName);
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression();
		methodInvocationExpression.Target = new ReferenceExpression(createDataMethodName);
		Block body = method.Body;
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression2 = (binaryExpression.Left = Expression.Lift(memInitBaseVar));
		Expression expression4 = (binaryExpression.Right = Expression.Lift(methodInvocationExpression));
		body.Add(binaryExpression);
		method.Body.Add(memInit);
		IEnumerator<ExpressionStatement> enumerator = variableInitializeStatements(varBlock, memInitBaseVar.Name).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ExpressionStatement current = enumerator.Current;
				method.Body.Add(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		Block body2 = method.Body;
		ReturnStatement returnStatement = new ReturnStatement(LexicalInfo.Empty);
		Expression expression6 = (returnStatement.Expression = Expression.Lift(memInitBaseVar));
		body2.Add(returnStatement);
		return method;
	}

	protected Method generateCreateDataMethod(string createDataMethodName, Expression actionEnum, string actClassName, ReferenceExpression memInitBaseVar, string groupName, string actParamName, IdentifierExpander varMapper, MacroStatement mc)
	{
		ReferenceExpression e = new ReferenceExpression(actClassName);
		Method method = actionCreateChangeMethod(createDataMethodName, null, actClassName);
		Expression[] array = timeVars();
		Expression expression = array[0];
		Expression expression2 = array[1];
		Block block = new Block(LexicalInfo.Empty);
		Statement[] array2 = new Statement[3];
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression4 = (binaryExpression.Left = Expression.Lift(memInitBaseVar));
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
		Expression expression6 = (methodInvocationExpression.Target = Expression.Lift(e));
		Expression expression8 = (binaryExpression.Right = methodInvocationExpression);
		array2[0] = Statement.Lift(binaryExpression);
		BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Assign);
		Expression expression10 = (binaryExpression2.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionIdName)));
		Expression expression12 = (binaryExpression2.Right = Expression.Lift(actionEnum));
		array2[1] = Statement.Lift(binaryExpression2);
		BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Assign);
		Expression expression14 = (binaryExpression3.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionGroupName)));
		Expression expression16 = (binaryExpression3.Right = Expression.Lift(groupName));
		array2[2] = Statement.Lift(binaryExpression3);
		StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array2));
		Block block2 = block.ToBlock();
		IEnumerator<object[]> enumerator = forAllInnerBlocks(mc).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object[] current = enumerator.Current;
				object obj = current[0];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				object obj2 = current[1];
				if (!(obj2 is Block))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(Block));
				}
				Block block3 = (Block)obj2;
				switch (text)
				{
				case "init":
				{
					BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.Assign);
					Expression expression22 = (binaryExpression5.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionInit)));
					Expression expression24 = (binaryExpression5.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression5);
					break;
				}
				case "exit":
				{
					BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression10 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType20 = (binaryExpression10.Operator = BinaryOperatorType.Assign);
					Expression expression42 = (binaryExpression10.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionExit)));
					Expression expression44 = (binaryExpression10.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression10);
					break;
				}
				case "coroutine":
				{
					BlockExpression blockExpression = subCoroutineDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression9 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType18 = (binaryExpression9.Operator = BinaryOperatorType.Assign);
					Expression expression38 = (binaryExpression9.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionCoroutine)));
					Expression expression40 = (binaryExpression9.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression9);
					break;
				}
				case "fixedUpdate":
				{
					BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression8 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType16 = (binaryExpression8.Operator = BinaryOperatorType.Assign);
					Expression expression34 = (binaryExpression8.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionFixedUpdate)));
					Expression expression36 = (binaryExpression8.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression8);
					break;
				}
				case "gui":
				{
					BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression7 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType14 = (binaryExpression7.Operator = BinaryOperatorType.Assign);
					Expression expression30 = (binaryExpression7.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionOnGUI)));
					Expression expression32 = (binaryExpression7.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression7);
					break;
				}
				case "lateUpdate":
				{
					BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
					blockExpression.Body = (Block)varMapper.Visit(block3);
					BinaryExpression binaryExpression6 = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType12 = (binaryExpression6.Operator = BinaryOperatorType.Assign);
					Expression expression26 = (binaryExpression6.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionLateUpdate)));
					Expression expression28 = (binaryExpression6.Right = Expression.Lift(blockExpression));
					block2.Add(binaryExpression6);
					break;
				}
				case "$":
					if (!block3.IsEmpty)
					{
						BlockExpression blockExpression = subMethodDefinition(actParamName, actClassName);
						blockExpression.Body = (Block)varMapper.Visit(block3);
						BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
						BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Assign);
						Expression expression18 = (binaryExpression4.Left = new MemberReferenceExpression(Expression.Lift(memInitBaseVar), CodeSerializer.LiftName(actionUpdate)));
						Expression expression20 = (binaryExpression4.Right = Expression.Lift(blockExpression));
						block2.Add(binaryExpression4);
					}
					break;
				default:
					throw new Exception("unknown block \"" + text + "\" in act_method");
				case "var":
				case "leadingDecls":
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		method.Body.Add(block2);
		Block body = method.Body;
		ReturnStatement returnStatement = new ReturnStatement(LexicalInfo.Empty);
		Expression expression46 = (returnStatement.Expression = Expression.Lift(memInitBaseVar));
		body.Add(returnStatement);
		return method;
	}

	protected ReferenceExpression refLift(string s)
	{
		return ReferenceExpression.Lift(s);
	}
}
