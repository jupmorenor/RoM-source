using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Debug_mode_input_propMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002415344 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_00241_002415345;

			internal MacroStatement _0024_0024match_00242_002415346;

			internal ReferenceExpression _0024name_002415347;

			internal ReferenceExpression _0024vname_002415348;

			internal ReturnStatement _0024_00244060_002415349;

			internal Block _0024_00244061_002415350;

			internal Method _0024_00244062_002415351;

			internal ReferenceExpression _0024_00244063_002415352;

			internal BinaryExpression _0024_00244064_002415353;

			internal Block _0024_00244065_002415354;

			internal Method _0024_00244066_002415355;

			internal SimpleTypeReference _0024_00244067_002415356;

			internal Property _0024_00244068_002415357;

			internal SimpleTypeReference _0024_00244069_002415358;

			internal Field _0024_00244070_002415359;

			internal MacroStatement _0024debug_mode_input_prop_002415360;

			internal Debug_mode_input_propMacro _0024self__002415361;

			public _0024(MacroStatement debug_mode_input_prop, Debug_mode_input_propMacro self_)
			{
				_0024debug_mode_input_prop_002415360 = debug_mode_input_prop;
				_0024self__002415361 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024debug_mode_input_prop_002415360 == null)
					{
						throw new ArgumentNullException("debug_mode_input_prop");
					}
					_0024self__002415361.__macro = _0024debug_mode_input_prop_002415360;
					_0024_0024match_00241_002415345 = _0024debug_mode_input_prop_002415360;
					if (_0024_0024match_00241_002415345 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_00242_002415346 = _0024_0024match_00241_002415345);
						if (true && _0024_0024match_00242_002415346.Name == "debug_mode_input_prop" && 1 == ((ICollection)_0024_0024match_00242_002415346.Arguments).Count && _0024_0024match_00242_002415346.Arguments[0] is ReferenceExpression)
						{
							ReferenceExpression referenceExpression = (_0024name_002415347 = (ReferenceExpression)_0024_0024match_00242_002415346.Arguments[0]);
							if (true)
							{
								_0024vname_002415348 = new ReferenceExpression(_0024self__002415361.Context.GetUniqueName("dmode", "input"));
								Property property = (_0024_00244068_002415357 = new Property(LexicalInfo.Empty));
								TypeMemberModifiers typeMemberModifiers4 = (_0024_00244068_002415357.Modifiers = TypeMemberModifiers.Public | TypeMemberModifiers.Static);
								string text8 = (_0024_00244068_002415357.Name = "$");
								Property property2 = _0024_00244068_002415357;
								Method method = (_0024_00244062_002415351 = new Method(LexicalInfo.Empty));
								string text10 = (_0024_00244062_002415351.Name = "get");
								Method method2 = _0024_00244062_002415351;
								Block block = (_0024_00244061_002415350 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00244061_002415350;
								Statement[] array = new Statement[1];
								ReturnStatement returnStatement = (_0024_00244060_002415349 = new ReturnStatement(LexicalInfo.Empty));
								Expression expression2 = (_0024_00244060_002415349.Expression = Expression.Lift(_0024vname_002415348));
								array[0] = Statement.Lift(_0024_00244060_002415349);
								StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
								Block block4 = (method2.Body = _0024_00244061_002415350);
								Method method4 = (property2.Getter = _0024_00244062_002415351);
								Property property3 = _0024_00244068_002415357;
								Method method5 = (_0024_00244066_002415355 = new Method(LexicalInfo.Empty));
								string text12 = (_0024_00244066_002415355.Name = "set");
								Method method6 = _0024_00244066_002415355;
								Block block5 = (_0024_00244065_002415354 = new Block(LexicalInfo.Empty));
								Block block6 = _0024_00244065_002415354;
								Statement[] array2 = new Statement[1];
								BinaryExpression binaryExpression = (_0024_00244064_002415353 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00244064_002415353.Operator = BinaryOperatorType.Assign);
								Expression expression4 = (_0024_00244064_002415353.Left = Expression.Lift(_0024vname_002415348));
								BinaryExpression binaryExpression2 = _0024_00244064_002415353;
								ReferenceExpression referenceExpression2 = (_0024_00244063_002415352 = new ReferenceExpression(LexicalInfo.Empty));
								string text14 = (_0024_00244063_002415352.Name = "value");
								Expression expression6 = (binaryExpression2.Right = _0024_00244063_002415352);
								array2[0] = Statement.Lift(_0024_00244064_002415353);
								StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array2));
								Block block8 = (method6.Body = _0024_00244065_002415354);
								Method method8 = (property3.Setter = _0024_00244066_002415355);
								Property property4 = _0024_00244068_002415357;
								SimpleTypeReference simpleTypeReference2 = (_0024_00244067_002415356 = new SimpleTypeReference(LexicalInfo.Empty));
								bool flag6 = (_0024_00244067_002415356.IsPointer = false);
								string text16 = (_0024_00244067_002415356.Name = "bool");
								TypeReference typeReference4 = (property4.Type = _0024_00244067_002415356);
								string text18 = (_0024_00244068_002415357.Name = CodeSerializer.LiftName(_0024name_002415347));
								result = (Yield(2, _0024_00244068_002415357) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`debug_mode_input_prop` macro invocation argument(s) did not match definition: `debug_mode_input_prop((name as Boo.Lang.Compiler.Ast.ReferenceExpression))`");
				case 2:
				{
					Field field = (_0024_00244070_002415359 = new Field(LexicalInfo.Empty));
					TypeMemberModifiers typeMemberModifiers2 = (_0024_00244070_002415359.Modifiers = TypeMemberModifiers.Private | TypeMemberModifiers.Static);
					string text2 = (_0024_00244070_002415359.Name = "$");
					Field field2 = _0024_00244070_002415359;
					SimpleTypeReference simpleTypeReference = (_0024_00244069_002415358 = new SimpleTypeReference(LexicalInfo.Empty));
					bool flag2 = (_0024_00244069_002415358.IsPointer = false);
					string text4 = (_0024_00244069_002415358.Name = "bool");
					TypeReference typeReference2 = (field2.Type = _0024_00244069_002415358);
					bool flag4 = (_0024_00244070_002415359.IsVolatile = false);
					string text6 = (_0024_00244070_002415359.Name = CodeSerializer.LiftName(_0024vname_002415348));
					result = (Yield(3, _0024_00244070_002415359) ? 1 : 0);
					break;
				}
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

		internal MacroStatement _0024debug_mode_input_prop_002415362;

		internal Debug_mode_input_propMacro _0024self__002415363;

		public _0024ExpandGeneratorImpl_002415344(MacroStatement debug_mode_input_prop, Debug_mode_input_propMacro self_)
		{
			_0024debug_mode_input_prop_002415362 = debug_mode_input_prop;
			_0024self__002415363 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024debug_mode_input_prop_002415362, _0024self__002415363);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Debug_mode_input_propMacro()
	{
	}

	public Debug_mode_input_propMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement debug_mode_input_prop)
	{
		return new _0024ExpandGeneratorImpl_002415344(debug_mode_input_prop, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement debug_mode_input_prop)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'debug_mode_input_prop' is using. Read BOO-1077 for more info.");
	}
}
