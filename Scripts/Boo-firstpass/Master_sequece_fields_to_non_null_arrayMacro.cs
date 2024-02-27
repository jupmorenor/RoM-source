using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;

[Serializable]
public sealed class Master_sequece_fields_to_non_null_arrayMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_00242339 : GenericGenerator<Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024157_00242340;

			internal MacroStatement _0024_0024match_0024158_00242341;

			internal Expression _0024_name_00242342;

			internal Expression _0024_type_00242343;

			internal Expression _0024_n_00242344;

			internal ReferenceExpression _0024name_00242345;

			internal ReferenceExpression _0024type_00242346;

			internal IntegerLiteralExpression _0024n_00242347;

			internal ReferenceExpression _0024ary_00242348;

			internal ReferenceExpression _0024_00241057_00242349;

			internal GenericReferenceExpression _0024_00241058_00242350;

			internal MethodInvocationExpression _0024_00241059_00242351;

			internal BinaryExpression _0024_00241060_00242352;

			internal int _0024i_00242353;

			internal ReferenceExpression _0024vn_00242354;

			internal BinaryExpression _0024_00241061_00242355;

			internal MemberReferenceExpression _0024_00241062_00242356;

			internal MethodInvocationExpression _0024_00241063_00242357;

			internal Block _0024_00241064_00242358;

			internal IfStatement _0024_00241065_00242359;

			internal MemberReferenceExpression _0024_00241066_00242360;

			internal MethodInvocationExpression _0024_00241067_00242361;

			internal ReturnStatement _0024_00241068_00242362;

			internal MacroStatement _0024_0024match_0024159_00242363;

			internal Expression _0024_func_00242364;

			internal ReferenceExpression _0024val_00242365;

			internal ReferenceExpression _0024_00241069_00242366;

			internal GenericReferenceExpression _0024_00241070_00242367;

			internal MethodInvocationExpression _0024_00241071_00242368;

			internal BinaryExpression _0024_00241072_00242369;

			internal int _0024i_00242370;

			internal MethodInvocationExpression _0024_00241073_00242371;

			internal TryCastExpression _0024_00241074_00242372;

			internal BinaryExpression _0024_00241075_00242373;

			internal BinaryExpression _0024_00241076_00242374;

			internal MemberReferenceExpression _0024_00241077_00242375;

			internal MethodInvocationExpression _0024_00241078_00242376;

			internal Block _0024_00241079_00242377;

			internal IfStatement _0024_00241080_00242378;

			internal Block _0024_00241081_00242379;

			internal MemberReferenceExpression _0024_00241082_00242380;

			internal MethodInvocationExpression _0024_00241083_00242381;

			internal ReturnStatement _0024_00241084_00242382;

			internal int _0024_00241988_00242383;

			internal int _0024_00241989_00242384;

			internal int _0024_00241990_00242385;

			internal int _0024_00241991_00242386;

			internal MacroStatement _0024master_sequece_fields_to_non_null_array_00242387;

			internal Master_sequece_fields_to_non_null_arrayMacro _0024self__00242388;

			public _0024(MacroStatement master_sequece_fields_to_non_null_array, Master_sequece_fields_to_non_null_arrayMacro self_)
			{
				_0024master_sequece_fields_to_non_null_array_00242387 = master_sequece_fields_to_non_null_array;
				_0024self__00242388 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024master_sequece_fields_to_non_null_array_00242387 == null)
						{
							throw new ArgumentNullException("master_sequece_fields_to_non_null_array");
						}
						_0024self__00242388.__macro = _0024master_sequece_fields_to_non_null_array_00242387;
						_0024_0024match_0024157_00242340 = _0024master_sequece_fields_to_non_null_array_00242387;
						if (_0024_0024match_0024157_00242340 is MacroStatement)
						{
							MacroStatement macroStatement = (_0024_0024match_0024158_00242341 = _0024_0024match_0024157_00242340);
							if (true && _0024_0024match_0024158_00242341.Name == "master_sequece_fields_to_non_null_array" && 3 == ((ICollection)_0024_0024match_0024158_00242341.Arguments).Count)
							{
								Expression expression25 = (_0024_name_00242342 = _0024_0024match_0024158_00242341.Arguments[0]);
								if (true)
								{
									Expression expression26 = (_0024_type_00242343 = _0024_0024match_0024158_00242341.Arguments[1]);
									if (true)
									{
										Expression expression27 = (_0024_n_00242344 = _0024_0024match_0024158_00242341.Arguments[2]);
										if (true)
										{
											_0024name_00242345 = _0024_name_00242342 as ReferenceExpression;
											_0024type_00242346 = _0024_type_00242343 as ReferenceExpression;
											_0024n_00242347 = _0024_n_00242344 as IntegerLiteralExpression;
											if (_0024name_00242345 == null || _0024type_00242346 == null || _0024n_00242347 == null)
											{
												throw new AssertionFailedException("((name != null) and (type != null)) and (n != null)");
											}
											_0024ary_00242348 = new ReferenceExpression(_0024self__00242388.Context.GetUniqueName("msftnna1"));
											BinaryExpression binaryExpression4 = (_0024_00241060_00242352 = new BinaryExpression(LexicalInfo.Empty));
											BinaryOperatorType binaryOperatorType6 = (_0024_00241060_00242352.Operator = BinaryOperatorType.Assign);
											Expression expression29 = (_0024_00241060_00242352.Left = Expression.Lift(_0024ary_00242348));
											BinaryExpression binaryExpression5 = _0024_00241060_00242352;
											MethodInvocationExpression methodInvocationExpression6 = (_0024_00241059_00242351 = new MethodInvocationExpression(LexicalInfo.Empty));
											MethodInvocationExpression methodInvocationExpression7 = _0024_00241059_00242351;
											GenericReferenceExpression genericReferenceExpression = (_0024_00241058_00242350 = new GenericReferenceExpression(LexicalInfo.Empty));
											GenericReferenceExpression genericReferenceExpression2 = _0024_00241058_00242350;
											ReferenceExpression referenceExpression = (_0024_00241057_00242349 = new ReferenceExpression(LexicalInfo.Empty));
											string text6 = (_0024_00241057_00242349.Name = "List");
											Expression expression31 = (genericReferenceExpression2.Target = _0024_00241057_00242349);
											TypeReferenceCollection typeReferenceCollection2 = (_0024_00241058_00242350.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024type_00242346)));
											Expression expression33 = (methodInvocationExpression7.Target = _0024_00241058_00242350);
											Expression expression35 = (binaryExpression5.Right = _0024_00241059_00242351);
											result = (Yield(2, _0024_00241060_00242352) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
						if (_0024_0024match_0024157_00242340 is MacroStatement)
						{
							MacroStatement macroStatement2 = (_0024_0024match_0024159_00242363 = _0024_0024match_0024157_00242340);
							if (true && _0024_0024match_0024159_00242363.Name == "master_sequece_fields_to_non_null_array" && 4 == ((ICollection)_0024_0024match_0024159_00242363.Arguments).Count)
							{
								Expression expression36 = (_0024_name_00242342 = _0024_0024match_0024159_00242363.Arguments[0]);
								if (true)
								{
									Expression expression37 = (_0024_type_00242343 = _0024_0024match_0024159_00242363.Arguments[1]);
									if (true)
									{
										Expression expression38 = (_0024_n_00242344 = _0024_0024match_0024159_00242363.Arguments[2]);
										if (true)
										{
											Expression expression39 = (_0024_func_00242364 = _0024_0024match_0024159_00242363.Arguments[3]);
											if (true)
											{
												_0024name_00242345 = _0024_name_00242342 as ReferenceExpression;
												_0024type_00242346 = _0024_type_00242343 as ReferenceExpression;
												_0024n_00242347 = _0024_n_00242344 as IntegerLiteralExpression;
												if (_0024name_00242345 == null || _0024type_00242346 == null || _0024n_00242347 == null)
												{
													throw new AssertionFailedException("((name != null) and (type != null)) and (n != null)");
												}
												_0024ary_00242348 = new ReferenceExpression(_0024self__00242388.Context.GetUniqueName("msftnna2"));
												_0024val_00242365 = new ReferenceExpression(_0024self__00242388.Context.GetUniqueName("msftnna3"));
												BinaryExpression binaryExpression6 = (_0024_00241072_00242369 = new BinaryExpression(LexicalInfo.Empty));
												BinaryOperatorType binaryOperatorType8 = (_0024_00241072_00242369.Operator = BinaryOperatorType.Assign);
												Expression expression41 = (_0024_00241072_00242369.Left = Expression.Lift(_0024ary_00242348));
												BinaryExpression binaryExpression7 = _0024_00241072_00242369;
												MethodInvocationExpression methodInvocationExpression8 = (_0024_00241071_00242368 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression9 = _0024_00241071_00242368;
												GenericReferenceExpression genericReferenceExpression3 = (_0024_00241070_00242367 = new GenericReferenceExpression(LexicalInfo.Empty));
												GenericReferenceExpression genericReferenceExpression4 = _0024_00241070_00242367;
												ReferenceExpression referenceExpression2 = (_0024_00241069_00242366 = new ReferenceExpression(LexicalInfo.Empty));
												string text8 = (_0024_00241069_00242366.Name = "List");
												Expression expression43 = (genericReferenceExpression4.Target = _0024_00241069_00242366);
												TypeReferenceCollection typeReferenceCollection4 = (_0024_00241070_00242367.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024type_00242346)));
												Expression expression45 = (methodInvocationExpression9.Target = _0024_00241070_00242367);
												Expression expression47 = (binaryExpression7.Right = _0024_00241071_00242368);
												result = (Yield(5, _0024_00241072_00242369) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
						}
						throw new MatchError(new StringBuilder("`master_sequece_fields_to_non_null_array` failed to match `").Append(_0024_0024match_0024157_00242340).Append("`").ToString());
					case 2:
						_0024_00241988_00242383 = 0;
						_0024_00241989_00242384 = (int)_0024n_00242347.Value;
						if (_0024_00241989_00242384 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						goto case 3;
					case 3:
						if (_0024_00241988_00242383 < _0024_00241989_00242384)
						{
							_0024i_00242353 = _0024_00241988_00242383;
							unchecked
							{
								_0024_00241988_00242383++;
							}
							_0024vn_00242354 = new ReferenceExpression(_0024name_00242345.Name + "_" + (_0024i_00242353 + 1));
							IfStatement ifStatement4 = (_0024_00241065_00242359 = new IfStatement(LexicalInfo.Empty));
							IfStatement ifStatement5 = _0024_00241065_00242359;
							BinaryExpression binaryExpression8 = (_0024_00241061_00242355 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType10 = (_0024_00241061_00242355.Operator = BinaryOperatorType.Inequality);
							Expression expression49 = (_0024_00241061_00242355.Left = Expression.Lift(_0024vn_00242354));
							Expression expression51 = (_0024_00241061_00242355.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression53 = (ifStatement5.Condition = _0024_00241061_00242355);
							IfStatement ifStatement6 = _0024_00241065_00242359;
							Block block7 = (_0024_00241064_00242358 = new Block(LexicalInfo.Empty));
							Block block8 = _0024_00241064_00242358;
							Statement[] array3 = new Statement[1];
							MethodInvocationExpression methodInvocationExpression10 = (_0024_00241063_00242357 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression11 = _0024_00241063_00242357;
							MemberReferenceExpression memberReferenceExpression3 = (_0024_00241062_00242356 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text10 = (_0024_00241062_00242356.Name = "Add");
							Expression expression55 = (_0024_00241062_00242356.Target = Expression.Lift(_0024ary_00242348));
							Expression expression57 = (methodInvocationExpression11.Target = _0024_00241062_00242356);
							ExpressionCollection expressionCollection6 = (_0024_00241063_00242357.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vn_00242354)));
							array3[0] = Statement.Lift(_0024_00241063_00242357);
							StatementCollection statementCollection6 = (block8.Statements = StatementCollection.FromArray(array3));
							Block block10 = (ifStatement6.TrueBlock = _0024_00241064_00242358);
							result = (Yield(3, _0024_00241065_00242359) ? 1 : 0);
						}
						else
						{
							ReturnStatement returnStatement3 = (_0024_00241068_00242362 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement4 = _0024_00241068_00242362;
							MethodInvocationExpression methodInvocationExpression12 = (_0024_00241067_00242361 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression13 = _0024_00241067_00242361;
							MemberReferenceExpression memberReferenceExpression4 = (_0024_00241066_00242360 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text12 = (_0024_00241066_00242360.Name = "ToArray");
							Expression expression59 = (_0024_00241066_00242360.Target = Expression.Lift(_0024ary_00242348));
							Expression expression61 = (methodInvocationExpression13.Target = _0024_00241066_00242360);
							Expression expression63 = (returnStatement4.Expression = _0024_00241067_00242361);
							result = (Yield(4, _0024_00241068_00242362) ? 1 : 0);
						}
						break;
					case 5:
						_0024_00241990_00242385 = 0;
						_0024_00241991_00242386 = (int)_0024n_00242347.Value;
						if (_0024_00241991_00242386 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						goto case 6;
					case 6:
						if (_0024_00241990_00242385 < _0024_00241991_00242386)
						{
							_0024i_00242370 = _0024_00241990_00242385;
							unchecked
							{
								_0024_00241990_00242385++;
							}
							_0024vn_00242354 = new ReferenceExpression(_0024name_00242345.Name + "_" + (_0024i_00242370 + 1));
							Block block = (_0024_00241081_00242379 = new Block(LexicalInfo.Empty));
							Block block2 = _0024_00241081_00242379;
							Statement[] array = new Statement[2];
							BinaryExpression binaryExpression = (_0024_00241075_00242373 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType2 = (_0024_00241075_00242373.Operator = BinaryOperatorType.Assign);
							Expression expression2 = (_0024_00241075_00242373.Left = Expression.Lift(_0024val_00242365));
							BinaryExpression binaryExpression2 = _0024_00241075_00242373;
							TryCastExpression tryCastExpression = (_0024_00241074_00242372 = new TryCastExpression(LexicalInfo.Empty));
							TryCastExpression tryCastExpression2 = _0024_00241074_00242372;
							MethodInvocationExpression methodInvocationExpression = (_0024_00241073_00242371 = new MethodInvocationExpression(LexicalInfo.Empty));
							Expression expression4 = (_0024_00241073_00242371.Target = Expression.Lift(_0024_func_00242364));
							ExpressionCollection expressionCollection2 = (_0024_00241073_00242371.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vn_00242354)));
							Expression expression6 = (tryCastExpression2.Target = _0024_00241073_00242371);
							TypeReference typeReference2 = (_0024_00241074_00242372.Type = TypeReference.Lift(_0024type_00242346));
							Expression expression8 = (binaryExpression2.Right = _0024_00241074_00242372);
							array[0] = Statement.Lift(_0024_00241075_00242373);
							IfStatement ifStatement = (_0024_00241080_00242378 = new IfStatement(LexicalInfo.Empty));
							IfStatement ifStatement2 = _0024_00241080_00242378;
							BinaryExpression binaryExpression3 = (_0024_00241076_00242374 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType4 = (_0024_00241076_00242374.Operator = BinaryOperatorType.Inequality);
							Expression expression10 = (_0024_00241076_00242374.Left = Expression.Lift(_0024val_00242365));
							Expression expression12 = (_0024_00241076_00242374.Right = new NullLiteralExpression(LexicalInfo.Empty));
							Expression expression14 = (ifStatement2.Condition = _0024_00241076_00242374);
							IfStatement ifStatement3 = _0024_00241080_00242378;
							Block block3 = (_0024_00241079_00242377 = new Block(LexicalInfo.Empty));
							Block block4 = _0024_00241079_00242377;
							Statement[] array2 = new Statement[1];
							MethodInvocationExpression methodInvocationExpression2 = (_0024_00241078_00242376 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression3 = _0024_00241078_00242376;
							MemberReferenceExpression memberReferenceExpression = (_0024_00241077_00242375 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text2 = (_0024_00241077_00242375.Name = "Add");
							Expression expression16 = (_0024_00241077_00242375.Target = Expression.Lift(_0024ary_00242348));
							Expression expression18 = (methodInvocationExpression3.Target = _0024_00241077_00242375);
							ExpressionCollection expressionCollection4 = (_0024_00241078_00242376.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024val_00242365)));
							array2[0] = Statement.Lift(_0024_00241078_00242376);
							StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
							Block block6 = (ifStatement3.TrueBlock = _0024_00241079_00242377);
							array[1] = Statement.Lift(_0024_00241080_00242378);
							StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
							result = (Yield(6, _0024_00241081_00242379) ? 1 : 0);
						}
						else
						{
							ReturnStatement returnStatement = (_0024_00241084_00242382 = new ReturnStatement(LexicalInfo.Empty));
							ReturnStatement returnStatement2 = _0024_00241084_00242382;
							MethodInvocationExpression methodInvocationExpression4 = (_0024_00241083_00242381 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression5 = _0024_00241083_00242381;
							MemberReferenceExpression memberReferenceExpression2 = (_0024_00241082_00242380 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text4 = (_0024_00241082_00242380.Name = "ToArray");
							Expression expression20 = (_0024_00241082_00242380.Target = Expression.Lift(_0024ary_00242348));
							Expression expression22 = (methodInvocationExpression5.Target = _0024_00241082_00242380);
							Expression expression24 = (returnStatement2.Expression = _0024_00241083_00242381);
							result = (Yield(7, _0024_00241084_00242382) ? 1 : 0);
						}
						break;
					case 4:
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

		internal MacroStatement _0024master_sequece_fields_to_non_null_array_00242389;

		internal Master_sequece_fields_to_non_null_arrayMacro _0024self__00242390;

		public _0024ExpandGeneratorImpl_00242339(MacroStatement master_sequece_fields_to_non_null_array, Master_sequece_fields_to_non_null_arrayMacro self_)
		{
			_0024master_sequece_fields_to_non_null_array_00242389 = master_sequece_fields_to_non_null_array;
			_0024self__00242390 = self_;
		}

		public override IEnumerator<Node> GetEnumerator()
		{
			return new _0024(_0024master_sequece_fields_to_non_null_array_00242389, _0024self__00242390);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Master_sequece_fields_to_non_null_arrayMacro()
	{
	}

	public Master_sequece_fields_to_non_null_arrayMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement master_sequece_fields_to_non_null_array)
	{
		return new _0024ExpandGeneratorImpl_00242339(master_sequece_fields_to_non_null_array, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement master_sequece_fields_to_non_null_array)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'master_sequece_fields_to_non_null_array' is using. Read BOO-1077 for more info.");
	}
}
