using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Safe_forMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002422793 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002460_002422794;

			internal MacroStatement _0024_0024match_002461_002422795;

			internal BinaryExpression _0024_0024match_002462_002422796;

			internal TryCastExpression _0024_0024match_002463_002422797;

			internal Expression _0024v_002422798;

			internal TypeReference _0024t_002422799;

			internal Expression _0024enumerable_002422800;

			internal ReferenceExpression _0024_00245261_002422801;

			internal MemberReferenceExpression _0024_00245262_002422802;

			internal SimpleTypeReference _0024_00245263_002422803;

			internal GenericReferenceExpression _0024_00245264_002422804;

			internal ParameterDeclaration _0024_00245265_002422805;

			internal Block _0024_00245266_002422806;

			internal BlockExpression _0024_00245267_002422807;

			internal MethodInvocationExpression _0024_00245268_002422808;

			internal MethodInvocationExpression _0024z_002422809;

			internal MacroStatement _0024_0024match_002464_002422810;

			internal BinaryExpression _0024_0024match_002465_002422811;

			internal Expression _0024x_002422812;

			internal ReferenceExpression _0024_00245269_002422813;

			internal MemberReferenceExpression _0024_00245270_002422814;

			internal SimpleTypeReference _0024_00245271_002422815;

			internal GenericReferenceExpression _0024_00245272_002422816;

			internal SimpleTypeReference _0024_00245273_002422817;

			internal ParameterDeclaration _0024_00245274_002422818;

			internal Block _0024_00245275_002422819;

			internal BlockExpression _0024_00245276_002422820;

			internal MethodInvocationExpression _0024_00245277_002422821;

			internal MacroStatement _0024safe_for_002422822;

			internal Safe_forMacro _0024self__002422823;

			public _0024(MacroStatement safe_for, Safe_forMacro self_)
			{
				_0024safe_for_002422822 = safe_for;
				_0024self__002422823 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024safe_for_002422822 == null)
					{
						throw new ArgumentNullException("safe_for");
					}
					_0024self__002422823.__macro = _0024safe_for_002422822;
					_0024_0024match_002460_002422794 = _0024safe_for_002422822;
					if (_0024_0024match_002460_002422794 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002461_002422795 = _0024_0024match_002460_002422794);
						if (true && _0024_0024match_002461_002422795.Name == "safe_for" && 1 == ((ICollection)_0024_0024match_002461_002422795.Arguments).Count && _0024_0024match_002461_002422795.Arguments[0] is BinaryExpression)
						{
							BinaryExpression binaryExpression = (_0024_0024match_002462_002422796 = (BinaryExpression)_0024_0024match_002461_002422795.Arguments[0]);
							if (true && _0024_0024match_002462_002422796.Operator == BinaryOperatorType.Member && _0024_0024match_002462_002422796.Left is TryCastExpression)
							{
								TryCastExpression tryCastExpression = (_0024_0024match_002463_002422797 = (TryCastExpression)_0024_0024match_002462_002422796.Left);
								if (true)
								{
									Expression expression = (_0024v_002422798 = _0024_0024match_002463_002422797.Target);
									if (true)
									{
										TypeReference typeReference = (_0024t_002422799 = _0024_0024match_002463_002422797.Type);
										if (true)
										{
											Expression expression2 = (_0024enumerable_002422800 = _0024_0024match_002462_002422796.Right);
											if (true)
											{
												MethodInvocationExpression methodInvocationExpression = (_0024_00245268_002422808 = new MethodInvocationExpression(LexicalInfo.Empty));
												MethodInvocationExpression methodInvocationExpression2 = _0024_00245268_002422808;
												GenericReferenceExpression genericReferenceExpression = (_0024_00245264_002422804 = new GenericReferenceExpression(LexicalInfo.Empty));
												GenericReferenceExpression genericReferenceExpression2 = _0024_00245264_002422804;
												MemberReferenceExpression memberReferenceExpression = (_0024_00245262_002422802 = new MemberReferenceExpression(LexicalInfo.Empty));
												string text2 = (_0024_00245262_002422802.Name = "ForEach");
												MemberReferenceExpression memberReferenceExpression2 = _0024_00245262_002422802;
												ReferenceExpression referenceExpression = (_0024_00245261_002422801 = new ReferenceExpression(LexicalInfo.Empty));
												string text4 = (_0024_00245261_002422801.Name = "AOTSafe");
												Expression expression4 = (memberReferenceExpression2.Target = _0024_00245261_002422801);
												Expression expression6 = (genericReferenceExpression2.Target = _0024_00245262_002422802);
												GenericReferenceExpression genericReferenceExpression3 = _0024_00245264_002422804;
												TypeReference[] array = new TypeReference[1];
												SimpleTypeReference simpleTypeReference = (_0024_00245263_002422803 = new SimpleTypeReference(LexicalInfo.Empty));
												bool flag2 = (_0024_00245263_002422803.IsPointer = false);
												string text6 = (_0024_00245263_002422803.Name = "object");
												array[0] = _0024_00245263_002422803;
												TypeReferenceCollection typeReferenceCollection2 = (genericReferenceExpression3.GenericArguments = TypeReferenceCollection.FromArray(array));
												Expression expression8 = (methodInvocationExpression2.Target = _0024_00245264_002422804);
												MethodInvocationExpression methodInvocationExpression3 = _0024_00245268_002422808;
												Expression[] obj = new Expression[2]
												{
													Expression.Lift(_0024enumerable_002422800),
													null
												};
												BlockExpression blockExpression = (_0024_00245267_002422807 = new BlockExpression(LexicalInfo.Empty));
												BlockExpression blockExpression2 = _0024_00245267_002422807;
												ParameterDeclaration[] array2 = new ParameterDeclaration[1];
												ParameterDeclaration parameterDeclaration = (_0024_00245265_002422805 = new ParameterDeclaration(LexicalInfo.Empty));
												string text8 = (_0024_00245265_002422805.Name = "$");
												TypeReference typeReference3 = (_0024_00245265_002422805.Type = TypeReference.Lift(_0024t_002422799));
												string text10 = (_0024_00245265_002422805.Name = CodeSerializer.LiftName(_0024v_002422798.ToCodeString()));
												array2[0] = _0024_00245265_002422805;
												ParameterDeclarationCollection parameterDeclarationCollection2 = (blockExpression2.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array2));
												BlockExpression blockExpression3 = _0024_00245267_002422807;
												Block block = (_0024_00245266_002422806 = new Block(LexicalInfo.Empty));
												StatementCollection statementCollection2 = (_0024_00245266_002422806.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024safe_for_002422822.Body))));
												Block block3 = (blockExpression3.Body = _0024_00245266_002422806);
												obj[1] = _0024_00245267_002422807;
												ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
												_0024z_002422809 = _0024_00245268_002422808;
												_0024z_002422809.LexicalInfo = _0024safe_for_002422822.LexicalInfo;
												result = (Yield(2, _0024z_002422809) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
						}
					}
					if (_0024_0024match_002460_002422794 is MacroStatement)
					{
						MacroStatement macroStatement2 = (_0024_0024match_002464_002422810 = _0024_0024match_002460_002422794);
						if (true && _0024_0024match_002464_002422810.Name == "safe_for" && 1 == ((ICollection)_0024_0024match_002464_002422810.Arguments).Count && _0024_0024match_002464_002422810.Arguments[0] is BinaryExpression)
						{
							BinaryExpression binaryExpression2 = (_0024_0024match_002465_002422811 = (BinaryExpression)_0024_0024match_002464_002422810.Arguments[0]);
							if (true && _0024_0024match_002465_002422811.Operator == BinaryOperatorType.Member)
							{
								Expression expression9 = (_0024x_002422812 = _0024_0024match_002465_002422811.Left);
								if (true)
								{
									Expression expression10 = (_0024enumerable_002422800 = _0024_0024match_002465_002422811.Right);
									if (true)
									{
										MethodInvocationExpression methodInvocationExpression4 = (_0024_00245277_002422821 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression5 = _0024_00245277_002422821;
										GenericReferenceExpression genericReferenceExpression4 = (_0024_00245272_002422816 = new GenericReferenceExpression(LexicalInfo.Empty));
										GenericReferenceExpression genericReferenceExpression5 = _0024_00245272_002422816;
										MemberReferenceExpression memberReferenceExpression3 = (_0024_00245270_002422814 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text12 = (_0024_00245270_002422814.Name = "ForEach");
										MemberReferenceExpression memberReferenceExpression4 = _0024_00245270_002422814;
										ReferenceExpression referenceExpression2 = (_0024_00245269_002422813 = new ReferenceExpression(LexicalInfo.Empty));
										string text14 = (_0024_00245269_002422813.Name = "AOTSafe");
										Expression expression12 = (memberReferenceExpression4.Target = _0024_00245269_002422813);
										Expression expression14 = (genericReferenceExpression5.Target = _0024_00245270_002422814);
										GenericReferenceExpression genericReferenceExpression6 = _0024_00245272_002422816;
										TypeReference[] array3 = new TypeReference[1];
										SimpleTypeReference simpleTypeReference2 = (_0024_00245271_002422815 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag4 = (_0024_00245271_002422815.IsPointer = false);
										string text16 = (_0024_00245271_002422815.Name = "object");
										array3[0] = _0024_00245271_002422815;
										TypeReferenceCollection typeReferenceCollection4 = (genericReferenceExpression6.GenericArguments = TypeReferenceCollection.FromArray(array3));
										Expression expression16 = (methodInvocationExpression5.Target = _0024_00245272_002422816);
										MethodInvocationExpression methodInvocationExpression6 = _0024_00245277_002422821;
										Expression[] obj2 = new Expression[2]
										{
											Expression.Lift(_0024enumerable_002422800),
											null
										};
										BlockExpression blockExpression4 = (_0024_00245276_002422820 = new BlockExpression(LexicalInfo.Empty));
										BlockExpression blockExpression5 = _0024_00245276_002422820;
										ParameterDeclaration[] array4 = new ParameterDeclaration[1];
										ParameterDeclaration parameterDeclaration2 = (_0024_00245274_002422818 = new ParameterDeclaration(LexicalInfo.Empty));
										string text18 = (_0024_00245274_002422818.Name = "$");
										ParameterDeclaration parameterDeclaration3 = _0024_00245274_002422818;
										SimpleTypeReference simpleTypeReference3 = (_0024_00245273_002422817 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag6 = (_0024_00245273_002422817.IsPointer = false);
										string text20 = (_0024_00245273_002422817.Name = "duck");
										TypeReference typeReference5 = (parameterDeclaration3.Type = _0024_00245273_002422817);
										string text22 = (_0024_00245274_002422818.Name = CodeSerializer.LiftName((ReferenceExpression)_0024x_002422812));
										array4[0] = _0024_00245274_002422818;
										ParameterDeclarationCollection parameterDeclarationCollection4 = (blockExpression5.Parameters = ParameterDeclarationCollection.FromArray(hasParamArray: false, array4));
										BlockExpression blockExpression6 = _0024_00245276_002422820;
										Block block4 = (_0024_00245275_002422819 = new Block(LexicalInfo.Empty));
										StatementCollection statementCollection4 = (_0024_00245275_002422819.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024safe_for_002422822.Body))));
										Block block6 = (blockExpression6.Body = _0024_00245275_002422819);
										obj2[1] = _0024_00245276_002422820;
										ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(obj2));
										_0024z_002422809 = _0024_00245277_002422821;
										_0024z_002422809.LexicalInfo = _0024safe_for_002422822.LexicalInfo;
										result = (Yield(3, _0024z_002422809) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new Exception("safe_for macro error: must be a form \"safe_for x in enumerable\"");
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

		internal MacroStatement _0024safe_for_002422824;

		internal Safe_forMacro _0024self__002422825;

		public _0024ExpandGeneratorImpl_002422793(MacroStatement safe_for, Safe_forMacro self_)
		{
			_0024safe_for_002422824 = safe_for;
			_0024self__002422825 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024safe_for_002422824, _0024self__002422825);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Safe_forMacro()
	{
	}

	public Safe_forMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement safe_for)
	{
		return new _0024ExpandGeneratorImpl_002422793(safe_for, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement safe_for)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'safe_for' is using. Read BOO-1077 for more info.");
	}
}
