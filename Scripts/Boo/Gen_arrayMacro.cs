using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public class Gen_arrayMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	public class ReferenceReplacer : DepthFirstTransformer
	{
		protected CompilerContext ctxt;

		private string oldName;

		private string freshName;

		public ReferenceReplacer(CompilerContext ctxt, string oldName, string freshName)
		{
			this.ctxt = ctxt;
			this.oldName = oldName;
			this.freshName = freshName;
		}

		public override void OnReferenceExpression(ReferenceExpression node)
		{
			if (node.Name == oldName)
			{
				node.Name = freshName;
			}
		}

		public override void OnParameterDeclaration(ParameterDeclaration node)
		{
			if (node.Name == oldName)
			{
				node.Name = freshName;
			}
		}

		public static void Replace(CompilerContext ctxt, Boo.Lang.Compiler.Ast.Node node, string name, string freshName)
		{
			new ReferenceReplacer(ctxt, name, freshName).Visit(node);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002423900 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_00242743_002423901;

			internal MacroStatement _0024_0024match_00242744_002423902;

			internal Expression _0024_varDecl_002423903;

			internal Expression _0024_elmDecl_002423904;

			internal Expression _0024_elmVar_002423905;

			internal Expression _0024_func_002423906;

			internal Block _0024___item_002423907;

			internal MacroStatement _0024_0024match_00242745_002423908;

			internal Expression _0024_cond_002423909;

			internal Block _0024___item_002423910;

			internal IEnumerator<Block> _0024_0024iterator_002414226_002423911;

			internal IEnumerator<Block> _0024_0024iterator_002414227_002423912;

			internal MacroStatement _0024mc_002423913;

			public _0024(MacroStatement mc)
			{
				_0024mc_002423913 = mc;
			}

			public override bool MoveNext()
			{
				bool flag;
				try
				{
					switch (_state)
					{
					default:
						_0024_0024match_00242743_002423901 = _0024mc_002423913;
						if (_0024_0024match_00242743_002423901 is MacroStatement)
						{
							MacroStatement macroStatement = (_0024_0024match_00242744_002423902 = _0024_0024match_00242743_002423901);
							if (true && _0024_0024match_00242744_002423902.Name == "gen_array" && 4 == ((ICollection)_0024_0024match_00242744_002423902.Arguments).Count)
							{
								Expression expression = (_0024_varDecl_002423903 = _0024_0024match_00242744_002423902.Arguments[0]);
								if (true)
								{
									Expression expression2 = (_0024_elmDecl_002423904 = _0024_0024match_00242744_002423902.Arguments[1]);
									if (true)
									{
										Expression expression3 = (_0024_elmVar_002423905 = _0024_0024match_00242744_002423902.Arguments[2]);
										if (true)
										{
											Expression expression4 = (_0024_func_002423906 = _0024_0024match_00242744_002423902.Arguments[3]);
											if (true)
											{
												_0024_0024iterator_002414226_002423911 = emit(_0024_varDecl_002423903, _0024_elmDecl_002423904, _0024_elmVar_002423905, _0024_func_002423906, null).GetEnumerator();
												_state = 2;
												goto case 3;
											}
										}
									}
								}
							}
						}
						if (_0024_0024match_00242743_002423901 is MacroStatement)
						{
							MacroStatement macroStatement2 = (_0024_0024match_00242745_002423908 = _0024_0024match_00242743_002423901);
							if (true && _0024_0024match_00242745_002423908.Name == "gen_array" && 5 == ((ICollection)_0024_0024match_00242745_002423908.Arguments).Count)
							{
								Expression expression5 = (_0024_varDecl_002423903 = _0024_0024match_00242745_002423908.Arguments[0]);
								if (true)
								{
									Expression expression6 = (_0024_elmDecl_002423904 = _0024_0024match_00242745_002423908.Arguments[1]);
									if (true)
									{
										Expression expression7 = (_0024_elmVar_002423905 = _0024_0024match_00242745_002423908.Arguments[2]);
										if (true)
										{
											Expression expression8 = (_0024_func_002423906 = _0024_0024match_00242745_002423908.Arguments[3]);
											if (true)
											{
												Expression expression9 = (_0024_cond_002423909 = _0024_0024match_00242745_002423908.Arguments[4]);
												if (true)
												{
													_0024_0024iterator_002414227_002423912 = emit(_0024_varDecl_002423903, _0024_elmDecl_002423904, _0024_elmVar_002423905, _0024_func_002423906, _0024_cond_002423909).GetEnumerator();
													_state = 4;
													goto case 5;
												}
											}
										}
									}
								}
							}
						}
						throw new Exception("gen_array macro 引数エラー");
					case 3:
						if (_0024_0024iterator_002414226_002423911.MoveNext())
						{
							_0024___item_002423907 = _0024_0024iterator_002414226_002423911.Current;
							flag = Yield(3, _0024___item_002423907);
							goto IL_0331;
						}
						_state = 1;
						_0024ensure2();
						break;
					case 5:
						if (_0024_0024iterator_002414227_002423912.MoveNext())
						{
							_0024___item_002423910 = _0024_0024iterator_002414227_002423912.Current;
							flag = Yield(5, _0024___item_002423910);
							goto IL_0331;
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
				goto IL_0333;
				IL_0331:
				result = (flag ? 1 : 0);
				goto IL_0333;
				IL_0333:
				return (byte)result != 0;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002414226_002423911.Dispose();
			}

			private void _0024ensure4()
			{
				_0024_0024iterator_002414227_002423912.Dispose();
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

		internal MacroStatement _0024mc_002423914;

		public _0024ExpandGeneratorImpl_002423900(MacroStatement mc)
		{
			_0024mc_002423914 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002423914);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024emit_002423915 : GenericGenerator<Block>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Block>, IEnumerator
		{
			internal TryCastExpression _0024varDecl_002423916;

			internal TryCastExpression _0024elmDecl_002423917;

			internal ReferenceExpression _0024elmVar_002423918;

			internal Expression _0024func_002423919;

			internal Expression _0024cond_002423920;

			internal CompilerContext _0024ctxt_002423921;

			internal string _0024oldName_002423922;

			internal string _0024newName_002423923;

			internal Expression _0024var_002423924;

			internal TypeReference _0024T_002423925;

			internal Expression _0024src_002423926;

			internal TypeReference _0024S_002423927;

			internal ParameterDeclaration _0024_00246197_002423928;

			internal ReturnStatement _0024_00246198_002423929;

			internal Block _0024_00246199_002423930;

			internal BlockExpression _0024_00246200_002423931;

			internal BlockExpression _0024funcExpr_002423932;

			internal ReferenceExpression _0024_00246201_002423933;

			internal GenericReferenceExpression _0024_00246202_002423934;

			internal MethodInvocationExpression _0024_00246203_002423935;

			internal BinaryExpression _0024_00246204_002423936;

			internal Block _0024_00246205_002423937;

			internal MacroStatement _0024_00246206_002423938;

			internal Block _0024code_002423939;

			internal ParameterDeclaration _0024_00246207_002423940;

			internal ReturnStatement _0024_00246208_002423941;

			internal Block _0024_00246209_002423942;

			internal BlockExpression _0024_00246210_002423943;

			internal BlockExpression _0024condExpr_002423944;

			internal ReferenceExpression _0024_00246211_002423945;

			internal GenericReferenceExpression _0024_00246212_002423946;

			internal MethodInvocationExpression _0024_00246213_002423947;

			internal BinaryExpression _0024_00246214_002423948;

			internal Block _0024_00246215_002423949;

			internal MacroStatement _0024_00246216_002423950;

			internal object _0024_varDecl_002423951;

			internal object _0024_elmDecl_002423952;

			internal object _0024_elmVar_002423953;

			internal object _0024_func_002423954;

			internal object _0024_cond_002423955;

			public _0024(object _varDecl, object _elmDecl, object _elmVar, object _func, object _cond)
			{
				_0024_varDecl_002423951 = _varDecl;
				_0024_elmDecl_002423952 = _elmDecl;
				_0024_elmVar_002423953 = _elmVar;
				_0024_func_002423954 = _func;
				_0024_cond_002423955 = _cond;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (!(_0024_varDecl_002423951 is TryCastExpression))
					{
						throw new AssertionFailedException("_varDecl isa TryCastExpression");
					}
					if (!(_0024_elmDecl_002423952 is TryCastExpression))
					{
						throw new AssertionFailedException("_elmDecl isa TryCastExpression");
					}
					if (!(_0024_elmVar_002423953 is ReferenceExpression))
					{
						throw new AssertionFailedException("_elmVar isa ReferenceExpression");
					}
					if (!(_0024_func_002423954 is Expression))
					{
						throw new AssertionFailedException("_func isa Expression");
					}
					if (!(_0024_cond_002423955 is Expression) && _0024_cond_002423955 != null)
					{
						throw new AssertionFailedException("(_cond isa Expression) or (_cond == null)");
					}
					_0024varDecl_002423916 = _0024_varDecl_002423951 as TryCastExpression;
					_0024elmDecl_002423917 = _0024_elmDecl_002423952 as TryCastExpression;
					_0024elmVar_002423918 = _0024_elmVar_002423953 as ReferenceExpression;
					_0024func_002423919 = _0024_func_002423954 as Expression;
					_0024cond_002423920 = _0024_cond_002423955 as Expression;
					_0024ctxt_002423921 = CompilerContext.Current;
					_0024oldName_002423922 = _0024elmVar_002423918.Name;
					_0024newName_002423923 = _0024ctxt_002423921.GetUniqueName("genarray");
					_0024var_002423924 = _0024varDecl_002423916.Target;
					if (!(_0024varDecl_002423916.Type is ArrayTypeReference))
					{
						throw new AssertionFailedException("varDecl.Type isa ArrayTypeReference");
					}
					_0024T_002423925 = (_0024varDecl_002423916.Type as ArrayTypeReference).ElementType;
					_0024src_002423926 = _0024elmDecl_002423917.Target;
					if (!(_0024elmDecl_002423917.Type is ArrayTypeReference))
					{
						throw new AssertionFailedException("elmDecl.Type isa ArrayTypeReference");
					}
					_0024S_002423927 = (_0024elmDecl_002423917.Type as ArrayTypeReference).ElementType;
					BlockExpression blockExpression = (_0024_00246200_002423931 = new BlockExpression(LexicalInfo.Empty));
					BlockExpression blockExpression2 = _0024_00246200_002423931;
					ParameterDeclaration[] array = new ParameterDeclaration[1];
					ParameterDeclaration parameterDeclaration = (_0024_00246197_002423928 = new ParameterDeclaration(LexicalInfo.Empty));
					string text2 = (_0024_00246197_002423928.Name = "s");
					TypeReference typeReference2 = (_0024_00246197_002423928.Type = TypeReference.Lift(_0024S_002423927));
					array[0] = _0024_00246197_002423928;
					ParameterDeclarationCollection parameterDeclarationCollection2 = (blockExpression2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array));
					BlockExpression blockExpression3 = _0024_00246200_002423931;
					Block block = (_0024_00246199_002423930 = new Block(LexicalInfo.Empty));
					Block block2 = _0024_00246199_002423930;
					Statement[] array2 = new Statement[1];
					ReturnStatement returnStatement = (_0024_00246198_002423929 = new ReturnStatement(LexicalInfo.Empty));
					Expression expression2 = (_0024_00246198_002423929.Expression = Expression.Lift(_0024func_002423919));
					array2[0] = Statement.Lift(_0024_00246198_002423929);
					StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
					Block block4 = (blockExpression3.Body = _0024_00246199_002423930);
					_0024funcExpr_002423932 = _0024_00246200_002423931;
					_0024funcExpr_002423932.Parameters[0].Name = _0024oldName_002423922;
					ReferenceReplacer.Replace(_0024ctxt_002423921, _0024funcExpr_002423932, _0024oldName_002423922, _0024newName_002423923);
					if (_0024cond_002423920 == null)
					{
						MacroStatement macroStatement = (_0024_00246206_002423938 = new MacroStatement(LexicalInfo.Empty));
						string text4 = (_0024_00246206_002423938.Name = "b");
						MacroStatement macroStatement2 = _0024_00246206_002423938;
						Block block5 = (_0024_00246205_002423937 = new Block(LexicalInfo.Empty));
						Block block6 = _0024_00246205_002423937;
						Statement[] array3 = new Statement[1];
						BinaryExpression binaryExpression = (_0024_00246204_002423936 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType2 = (_0024_00246204_002423936.Operator = BinaryOperatorType.Assign);
						Expression expression4 = (_0024_00246204_002423936.Left = Expression.Lift(_0024var_002423924));
						BinaryExpression binaryExpression2 = _0024_00246204_002423936;
						MethodInvocationExpression methodInvocationExpression = (_0024_00246203_002423935 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression2 = _0024_00246203_002423935;
						GenericReferenceExpression genericReferenceExpression = (_0024_00246202_002423934 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression2 = _0024_00246202_002423934;
						ReferenceExpression referenceExpression = (_0024_00246201_002423933 = new ReferenceExpression(LexicalInfo.Empty));
						string text6 = (_0024_00246201_002423933.Name = "GenArray");
						Expression expression6 = (genericReferenceExpression2.Target = _0024_00246201_002423933);
						TypeReferenceCollection typeReferenceCollection2 = (_0024_00246202_002423934.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024T_002423925), TypeReference.Lift(_0024S_002423927)));
						Expression expression8 = (methodInvocationExpression2.Target = _0024_00246202_002423934);
						ExpressionCollection expressionCollection2 = (_0024_00246203_002423935.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024src_002423926), Expression.Lift(_0024funcExpr_002423932)));
						Expression expression10 = (binaryExpression2.Right = _0024_00246203_002423935);
						array3[0] = Statement.Lift(_0024_00246204_002423936);
						StatementCollection statementCollection4 = (block6.Statements = StatementCollection.FromArray(array3));
						Block block8 = (macroStatement2.Body = _0024_00246205_002423937);
						_0024code_002423939 = _0024_00246206_002423938.Body;
					}
					else
					{
						BlockExpression blockExpression4 = (_0024_00246210_002423943 = new BlockExpression(LexicalInfo.Empty));
						BlockExpression blockExpression5 = _0024_00246210_002423943;
						ParameterDeclaration[] array4 = new ParameterDeclaration[1];
						ParameterDeclaration parameterDeclaration2 = (_0024_00246207_002423940 = new ParameterDeclaration(LexicalInfo.Empty));
						string text8 = (_0024_00246207_002423940.Name = "s");
						TypeReference typeReference4 = (_0024_00246207_002423940.Type = TypeReference.Lift(_0024S_002423927));
						array4[0] = _0024_00246207_002423940;
						ParameterDeclarationCollection parameterDeclarationCollection4 = (blockExpression5.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array4));
						BlockExpression blockExpression6 = _0024_00246210_002423943;
						Block block9 = (_0024_00246209_002423942 = new Block(LexicalInfo.Empty));
						Block block10 = _0024_00246209_002423942;
						Statement[] array5 = new Statement[1];
						ReturnStatement returnStatement2 = (_0024_00246208_002423941 = new ReturnStatement(LexicalInfo.Empty));
						Expression expression12 = (_0024_00246208_002423941.Expression = Expression.Lift(_0024cond_002423920));
						array5[0] = Statement.Lift(_0024_00246208_002423941);
						StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(array5));
						Block block12 = (blockExpression6.Body = _0024_00246209_002423942);
						_0024condExpr_002423944 = _0024_00246210_002423943;
						_0024condExpr_002423944.Parameters[0].Name = _0024oldName_002423922;
						ReferenceReplacer.Replace(_0024ctxt_002423921, _0024condExpr_002423944, _0024oldName_002423922, _0024newName_002423923);
						MacroStatement macroStatement3 = (_0024_00246216_002423950 = new MacroStatement(LexicalInfo.Empty));
						string text10 = (_0024_00246216_002423950.Name = "b");
						MacroStatement macroStatement4 = _0024_00246216_002423950;
						Block block13 = (_0024_00246215_002423949 = new Block(LexicalInfo.Empty));
						Block block14 = _0024_00246215_002423949;
						Statement[] array6 = new Statement[1];
						BinaryExpression binaryExpression3 = (_0024_00246214_002423948 = new BinaryExpression(LexicalInfo.Empty));
						BinaryOperatorType binaryOperatorType4 = (_0024_00246214_002423948.Operator = BinaryOperatorType.Assign);
						Expression expression14 = (_0024_00246214_002423948.Left = Expression.Lift(_0024var_002423924));
						BinaryExpression binaryExpression4 = _0024_00246214_002423948;
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00246213_002423947 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00246213_002423947;
						GenericReferenceExpression genericReferenceExpression3 = (_0024_00246212_002423946 = new GenericReferenceExpression(LexicalInfo.Empty));
						GenericReferenceExpression genericReferenceExpression4 = _0024_00246212_002423946;
						ReferenceExpression referenceExpression2 = (_0024_00246211_002423945 = new ReferenceExpression(LexicalInfo.Empty));
						string text12 = (_0024_00246211_002423945.Name = "GenArray");
						Expression expression16 = (genericReferenceExpression4.Target = _0024_00246211_002423945);
						TypeReferenceCollection typeReferenceCollection4 = (_0024_00246212_002423946.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024T_002423925), TypeReference.Lift(_0024S_002423927)));
						Expression expression18 = (methodInvocationExpression4.Target = _0024_00246212_002423946);
						ExpressionCollection expressionCollection4 = (_0024_00246213_002423947.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024src_002423926), Expression.Lift(_0024funcExpr_002423932), Expression.Lift(_0024condExpr_002423944)));
						Expression expression20 = (binaryExpression4.Right = _0024_00246213_002423947);
						array6[0] = Statement.Lift(_0024_00246214_002423948);
						StatementCollection statementCollection8 = (block14.Statements = StatementCollection.FromArray(array6));
						Block block16 = (macroStatement4.Body = _0024_00246215_002423949);
						_0024code_002423939 = _0024_00246216_002423950.Body;
					}
					Console.WriteLine(_0024code_002423939.ToString());
					result = (Yield(2, _0024code_002423939) ? 1 : 0);
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

		internal object _0024_varDecl_002423956;

		internal object _0024_elmDecl_002423957;

		internal object _0024_elmVar_002423958;

		internal object _0024_func_002423959;

		internal object _0024_cond_002423960;

		public _0024emit_002423915(object _varDecl, object _elmDecl, object _elmVar, object _func, object _cond)
		{
			_0024_varDecl_002423956 = _varDecl;
			_0024_elmDecl_002423957 = _elmDecl;
			_0024_elmVar_002423958 = _elmVar;
			_0024_func_002423959 = _func;
			_0024_cond_002423960 = _cond;
		}

		public override IEnumerator<Block> GetEnumerator()
		{
			return new _0024(_0024_varDecl_002423956, _0024_elmDecl_002423957, _0024_elmVar_002423958, _0024_func_002423959, _0024_cond_002423960);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002423900(mc);
	}

	public static IEnumerable<Block> emit(object _varDecl, object _elmDecl, object _elmVar, object _func, object _cond)
	{
		return new _0024emit_002423915(_varDecl, _elmDecl, _elmVar, _func, _cond);
	}
}
