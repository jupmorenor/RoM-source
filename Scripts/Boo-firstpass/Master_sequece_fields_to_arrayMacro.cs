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
public sealed class Master_sequece_fields_to_arrayMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_00242391 : GenericGenerator<Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024160_00242392;

			internal MacroStatement _0024_0024match_0024161_00242393;

			internal Expression _0024_name_00242394;

			internal Expression _0024_type_00242395;

			internal Expression _0024_n_00242396;

			internal ReferenceExpression _0024name_00242397;

			internal ReferenceExpression _0024type_00242398;

			internal IntegerLiteralExpression _0024n_00242399;

			internal ReferenceExpression _0024ary_00242400;

			internal ReferenceExpression _0024_00241085_00242401;

			internal GenericReferenceExpression _0024_00241086_00242402;

			internal MethodInvocationExpression _0024_00241087_00242403;

			internal BinaryExpression _0024_00241088_00242404;

			internal int _0024i_00242405;

			internal ReferenceExpression _0024vn_00242406;

			internal MemberReferenceExpression _0024_00241089_00242407;

			internal MethodInvocationExpression _0024_00241090_00242408;

			internal MemberReferenceExpression _0024_00241091_00242409;

			internal MethodInvocationExpression _0024_00241092_00242410;

			internal ReturnStatement _0024_00241093_00242411;

			internal int _0024_00241992_00242412;

			internal int _0024_00241993_00242413;

			internal MacroStatement _0024master_sequece_fields_to_array_00242414;

			internal Master_sequece_fields_to_arrayMacro _0024self__00242415;

			public _0024(MacroStatement master_sequece_fields_to_array, Master_sequece_fields_to_arrayMacro self_)
			{
				_0024master_sequece_fields_to_array_00242414 = master_sequece_fields_to_array;
				_0024self__00242415 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024master_sequece_fields_to_array_00242414 == null)
					{
						throw new ArgumentNullException("master_sequece_fields_to_array");
					}
					_0024self__00242415.__macro = _0024master_sequece_fields_to_array_00242414;
					_0024_0024match_0024160_00242392 = _0024master_sequece_fields_to_array_00242414;
					if (_0024_0024match_0024160_00242392 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024161_00242393 = _0024_0024match_0024160_00242392);
						if (true && _0024_0024match_0024161_00242393.Name == "master_sequece_fields_to_array" && 3 == ((ICollection)_0024_0024match_0024161_00242393.Arguments).Count)
						{
							Expression expression = (_0024_name_00242394 = _0024_0024match_0024161_00242393.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024_type_00242395 = _0024_0024match_0024161_00242393.Arguments[1]);
								if (true)
								{
									Expression expression3 = (_0024_n_00242396 = _0024_0024match_0024161_00242393.Arguments[2]);
									if (true)
									{
										_0024name_00242397 = _0024_name_00242394 as ReferenceExpression;
										_0024type_00242398 = _0024_type_00242395 as ReferenceExpression;
										_0024n_00242399 = _0024_n_00242396 as IntegerLiteralExpression;
										if (_0024name_00242397 == null || _0024type_00242398 == null || _0024n_00242399 == null)
										{
											throw new AssertionFailedException("((name != null) and (type != null)) and (n != null)");
										}
										_0024ary_00242400 = new ReferenceExpression(_0024self__00242415.Context.GetUniqueName("msftnna1"));
										BinaryExpression binaryExpression = (_0024_00241088_00242404 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00241088_00242404.Operator = BinaryOperatorType.Assign);
										Expression expression5 = (_0024_00241088_00242404.Left = Expression.Lift(_0024ary_00242400));
										BinaryExpression binaryExpression2 = _0024_00241088_00242404;
										MethodInvocationExpression methodInvocationExpression = (_0024_00241087_00242403 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00241087_00242403;
										GenericReferenceExpression genericReferenceExpression = (_0024_00241086_00242402 = new GenericReferenceExpression(LexicalInfo.Empty));
										GenericReferenceExpression genericReferenceExpression2 = _0024_00241086_00242402;
										ReferenceExpression referenceExpression = (_0024_00241085_00242401 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00241085_00242401.Name = "List");
										Expression expression7 = (genericReferenceExpression2.Target = _0024_00241085_00242401);
										TypeReferenceCollection typeReferenceCollection2 = (_0024_00241086_00242402.GenericArguments = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024type_00242398)));
										Expression expression9 = (methodInvocationExpression2.Target = _0024_00241086_00242402);
										Expression expression11 = (binaryExpression2.Right = _0024_00241087_00242403);
										result = (Yield(2, _0024_00241088_00242404) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new MatchError(new StringBuilder("`master_sequece_fields_to_array` failed to match `").Append(_0024_0024match_0024160_00242392).Append("`").ToString());
				case 2:
					_0024_00241992_00242412 = 0;
					_0024_00241993_00242413 = checked((int)_0024n_00242399.Value);
					if (_0024_00241993_00242413 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					goto case 3;
				case 3:
					if (_0024_00241992_00242412 < _0024_00241993_00242413)
					{
						_0024i_00242405 = _0024_00241992_00242412;
						_0024_00241992_00242412++;
						_0024vn_00242406 = new ReferenceExpression(_0024name_00242397.Name + "_" + checked(_0024i_00242405 + 1));
						MethodInvocationExpression methodInvocationExpression3 = (_0024_00241090_00242408 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression4 = _0024_00241090_00242408;
						MemberReferenceExpression memberReferenceExpression = (_0024_00241089_00242407 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text4 = (_0024_00241089_00242407.Name = "Add");
						Expression expression13 = (_0024_00241089_00242407.Target = Expression.Lift(_0024ary_00242400));
						Expression expression15 = (methodInvocationExpression4.Target = _0024_00241089_00242407);
						ExpressionCollection expressionCollection2 = (_0024_00241090_00242408.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024vn_00242406)));
						result = (Yield(3, _0024_00241090_00242408) ? 1 : 0);
					}
					else
					{
						ReturnStatement returnStatement = (_0024_00241093_00242411 = new ReturnStatement(LexicalInfo.Empty));
						ReturnStatement returnStatement2 = _0024_00241093_00242411;
						MethodInvocationExpression methodInvocationExpression5 = (_0024_00241092_00242410 = new MethodInvocationExpression(LexicalInfo.Empty));
						MethodInvocationExpression methodInvocationExpression6 = _0024_00241092_00242410;
						MemberReferenceExpression memberReferenceExpression2 = (_0024_00241091_00242409 = new MemberReferenceExpression(LexicalInfo.Empty));
						string text6 = (_0024_00241091_00242409.Name = "ToArray");
						Expression expression17 = (_0024_00241091_00242409.Target = Expression.Lift(_0024ary_00242400));
						Expression expression19 = (methodInvocationExpression6.Target = _0024_00241091_00242409);
						Expression expression21 = (returnStatement2.Expression = _0024_00241092_00242410);
						result = (Yield(4, _0024_00241093_00242411) ? 1 : 0);
					}
					break;
				case 4:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MacroStatement _0024master_sequece_fields_to_array_00242416;

		internal Master_sequece_fields_to_arrayMacro _0024self__00242417;

		public _0024ExpandGeneratorImpl_00242391(MacroStatement master_sequece_fields_to_array, Master_sequece_fields_to_arrayMacro self_)
		{
			_0024master_sequece_fields_to_array_00242416 = master_sequece_fields_to_array;
			_0024self__00242417 = self_;
		}

		public override IEnumerator<Node> GetEnumerator()
		{
			return new _0024(_0024master_sequece_fields_to_array_00242416, _0024self__00242417);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Master_sequece_fields_to_arrayMacro()
	{
	}

	public Master_sequece_fields_to_arrayMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement master_sequece_fields_to_array)
	{
		return new _0024ExpandGeneratorImpl_00242391(master_sequece_fields_to_array, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement master_sequece_fields_to_array)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'master_sequece_fields_to_array' is using. Read BOO-1077 for more info.");
	}
}
