using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class SforMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_00242679 : GenericGenerator<Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024170_00242680;

			internal MacroStatement _0024_0024match_0024171_00242681;

			internal Expression _0024v_00242682;

			internal Expression _0024collection_00242683;

			internal ReferenceExpression _0024c_00242684;

			internal ReferenceExpression _0024i_00242685;

			internal ReferenceExpression _0024n_00242686;

			internal ReferenceExpression _0024vname_00242687;

			internal BinaryExpression _0024_00241400_00242688;

			internal ReferenceExpression _0024_00241401_00242689;

			internal MethodInvocationExpression _0024_00241402_00242690;

			internal BinaryExpression _0024_00241403_00242691;

			internal IntegerLiteralExpression _0024_00241404_00242692;

			internal BinaryExpression _0024_00241405_00242693;

			internal BinaryExpression _0024_00241406_00242694;

			internal UnaryExpression _0024_00241407_00242695;

			internal Slice _0024_00241408_00242696;

			internal SlicingExpression _0024_00241409_00242697;

			internal BinaryExpression _0024_00241410_00242698;

			internal Block _0024_00241411_00242699;

			internal WhileStatement _0024_00241412_00242700;

			internal Block _0024_00241413_00242701;

			internal TryCastExpression _0024tc_00242702;

			internal string _0024_0024assert2_0024169_00242703;

			internal SimpleTypeReference _0024_00241414_00242704;

			internal Declaration _0024_00241415_00242705;

			internal UnaryExpression _0024_00241416_00242706;

			internal Slice _0024_00241417_00242707;

			internal SlicingExpression _0024_00241418_00242708;

			internal DeclarationStatement _0024_00241419_00242709;

			internal DeclarationStatement _0024decl_00242710;

			internal BinaryExpression _0024_00241420_00242711;

			internal ReferenceExpression _0024_00241421_00242712;

			internal MethodInvocationExpression _0024_00241422_00242713;

			internal BinaryExpression _0024_00241423_00242714;

			internal IntegerLiteralExpression _0024_00241424_00242715;

			internal BinaryExpression _0024_00241425_00242716;

			internal BinaryExpression _0024_00241426_00242717;

			internal Block _0024_00241427_00242718;

			internal WhileStatement _0024_00241428_00242719;

			internal Block _0024_00241429_00242720;

			internal MacroStatement _0024sfor_00242721;

			internal SforMacro _0024self__00242722;

			public _0024(MacroStatement sfor, SforMacro self_)
			{
				_0024sfor_00242721 = sfor;
				_0024self__00242722 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024sfor_00242721 == null)
					{
						throw new ArgumentNullException("sfor");
					}
					_0024self__00242722.__macro = _0024sfor_00242721;
					_0024_0024match_0024170_00242680 = _0024sfor_00242721;
					if (_0024_0024match_0024170_00242680 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024171_00242681 = _0024_0024match_0024170_00242680);
						if (true && _0024_0024match_0024171_00242681.Name == "sfor" && 2 == ((ICollection)_0024_0024match_0024171_00242681.Arguments).Count && _0024_0024match_0024171_00242681.Arguments[0] is Expression)
						{
							Expression expression = (_0024v_00242682 = _0024_0024match_0024171_00242681.Arguments[0]);
							if (true && _0024_0024match_0024171_00242681.Arguments[1] is Expression)
							{
								Expression expression2 = (_0024collection_00242683 = _0024_0024match_0024171_00242681.Arguments[1]);
								if (true)
								{
									_0024c_00242684 = new ReferenceExpression(_0024self__00242722.Context.GetUniqueName("sfor"));
									_0024i_00242685 = new ReferenceExpression(_0024self__00242722.Context.GetUniqueName("sfor"));
									_0024n_00242686 = new ReferenceExpression(_0024self__00242722.Context.GetUniqueName("sfor"));
									if (_0024v_00242682 is ReferenceExpression)
									{
										_0024vname_00242687 = _0024v_00242682 as ReferenceExpression;
										Block block = (_0024_00241413_00242701 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00241413_00242701;
										Statement[] array = new Statement[4];
										BinaryExpression binaryExpression = (_0024_00241400_00242688 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00241400_00242688.Operator = BinaryOperatorType.Assign);
										Expression expression4 = (_0024_00241400_00242688.Left = Expression.Lift(_0024c_00242684));
										Expression expression6 = (_0024_00241400_00242688.Right = Expression.Lift(_0024collection_00242683));
										array[0] = Statement.Lift(_0024_00241400_00242688);
										BinaryExpression binaryExpression2 = (_0024_00241403_00242691 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00241403_00242691.Operator = BinaryOperatorType.Assign);
										Expression expression8 = (_0024_00241403_00242691.Left = Expression.Lift(_0024n_00242686));
										BinaryExpression binaryExpression3 = _0024_00241403_00242691;
										MethodInvocationExpression methodInvocationExpression = (_0024_00241402_00242690 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00241402_00242690;
										ReferenceExpression referenceExpression = (_0024_00241401_00242689 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00241401_00242689.Name = "len");
										Expression expression10 = (methodInvocationExpression2.Target = _0024_00241401_00242689);
										ExpressionCollection expressionCollection2 = (_0024_00241402_00242690.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024c_00242684)));
										Expression expression12 = (binaryExpression3.Right = _0024_00241402_00242690);
										array[1] = Statement.Lift(_0024_00241403_00242691);
										BinaryExpression binaryExpression4 = (_0024_00241405_00242693 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType6 = (_0024_00241405_00242693.Operator = BinaryOperatorType.Assign);
										Expression expression14 = (_0024_00241405_00242693.Left = Expression.Lift(_0024i_00242685));
										BinaryExpression binaryExpression5 = _0024_00241405_00242693;
										IntegerLiteralExpression integerLiteralExpression = (_0024_00241404_00242692 = new IntegerLiteralExpression(LexicalInfo.Empty));
										long num2 = (_0024_00241404_00242692.Value = 0L);
										bool flag2 = (_0024_00241404_00242692.IsLong = false);
										Expression expression16 = (binaryExpression5.Right = _0024_00241404_00242692);
										array[2] = Statement.Lift(_0024_00241405_00242693);
										WhileStatement whileStatement = (_0024_00241412_00242700 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement2 = _0024_00241412_00242700;
										BinaryExpression binaryExpression6 = (_0024_00241406_00242694 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType8 = (_0024_00241406_00242694.Operator = BinaryOperatorType.LessThan);
										Expression expression18 = (_0024_00241406_00242694.Left = Expression.Lift(_0024i_00242685));
										Expression expression20 = (_0024_00241406_00242694.Right = Expression.Lift(_0024n_00242686));
										Expression expression22 = (whileStatement2.Condition = _0024_00241406_00242694);
										WhileStatement whileStatement3 = _0024_00241412_00242700;
										Block block3 = (_0024_00241411_00242699 = new Block(LexicalInfo.Empty));
										Block block4 = _0024_00241411_00242699;
										Statement[] array2 = new Statement[2];
										BinaryExpression binaryExpression7 = (_0024_00241410_00242698 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType10 = (_0024_00241410_00242698.Operator = BinaryOperatorType.Assign);
										Expression expression24 = (_0024_00241410_00242698.Left = Expression.Lift(_0024vname_00242687));
										BinaryExpression binaryExpression8 = _0024_00241410_00242698;
										SlicingExpression slicingExpression = (_0024_00241409_00242697 = new SlicingExpression(LexicalInfo.Empty));
										Expression expression26 = (_0024_00241409_00242697.Target = Expression.Lift(_0024c_00242684));
										SlicingExpression slicingExpression2 = _0024_00241409_00242697;
										Slice[] array3 = new Slice[1];
										Slice slice = (_0024_00241408_00242696 = new Slice(LexicalInfo.Empty));
										Slice slice2 = _0024_00241408_00242696;
										UnaryExpression unaryExpression = (_0024_00241407_00242695 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType2 = (_0024_00241407_00242695.Operator = UnaryOperatorType.PostIncrement);
										Expression expression28 = (_0024_00241407_00242695.Operand = Expression.Lift(_0024i_00242685));
										Expression expression30 = (slice2.Begin = _0024_00241407_00242695);
										array3[0] = _0024_00241408_00242696;
										SliceCollection sliceCollection2 = (slicingExpression2.Indices = SliceCollection.FromArray(array3));
										Expression expression32 = (binaryExpression8.Right = _0024_00241409_00242697);
										array2[0] = Statement.Lift(_0024_00241410_00242698);
										array2[1] = Statement.Lift(Statement.Lift(_0024sfor_00242721.Body));
										StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
										Block block6 = (whileStatement3.Block = _0024_00241411_00242699);
										array[3] = Statement.Lift(_0024_00241412_00242700);
										StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
										result = (Yield(2, _0024_00241413_00242701) ? 1 : 0);
										break;
									}
									if (_0024v_00242682 is TryCastExpression)
									{
										_0024tc_00242702 = _0024v_00242682 as TryCastExpression;
										if (!(_0024tc_00242702.Target is ReferenceExpression))
										{
											_0024_0024assert2_0024169_00242703 = "ASSERT at " + "basic_macros" + "(" + 424 + "):" + "tc.Target isa ReferenceExpression" + " -- message: " + new StringBuilder("sfor のループ変数 ").Append(_0024tc_00242702.Target.ToCodeString()).Append(" は、これじゃ変数として使えないよ。").ToString();
											throw new Exception(_0024_0024assert2_0024169_00242703);
										}
										DeclarationStatement declarationStatement = (_0024_00241419_00242709 = new DeclarationStatement(LexicalInfo.Empty));
										DeclarationStatement declarationStatement2 = _0024_00241419_00242709;
										Declaration declaration = (_0024_00241415_00242705 = new Declaration(LexicalInfo.Empty));
										string text4 = (_0024_00241415_00242705.Name = "a");
										Declaration declaration2 = _0024_00241415_00242705;
										SimpleTypeReference simpleTypeReference = (_0024_00241414_00242704 = new SimpleTypeReference(LexicalInfo.Empty));
										bool flag4 = (_0024_00241414_00242704.IsPointer = false);
										string text6 = (_0024_00241414_00242704.Name = "int");
										TypeReference typeReference2 = (declaration2.Type = _0024_00241414_00242704);
										Declaration declaration4 = (declarationStatement2.Declaration = _0024_00241415_00242705);
										DeclarationStatement declarationStatement3 = _0024_00241419_00242709;
										SlicingExpression slicingExpression3 = (_0024_00241418_00242708 = new SlicingExpression(LexicalInfo.Empty));
										Expression expression34 = (_0024_00241418_00242708.Target = Expression.Lift(_0024c_00242684));
										SlicingExpression slicingExpression4 = _0024_00241418_00242708;
										Slice[] array4 = new Slice[1];
										Slice slice3 = (_0024_00241417_00242707 = new Slice(LexicalInfo.Empty));
										Slice slice4 = _0024_00241417_00242707;
										UnaryExpression unaryExpression2 = (_0024_00241416_00242706 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType4 = (_0024_00241416_00242706.Operator = UnaryOperatorType.PostIncrement);
										Expression expression36 = (_0024_00241416_00242706.Operand = Expression.Lift(_0024i_00242685));
										Expression expression38 = (slice4.Begin = _0024_00241416_00242706);
										array4[0] = _0024_00241417_00242707;
										SliceCollection sliceCollection4 = (slicingExpression4.Indices = SliceCollection.FromArray(array4));
										Expression expression40 = (declarationStatement3.Initializer = _0024_00241418_00242708);
										_0024decl_00242710 = _0024_00241419_00242709;
										_0024decl_00242710.Declaration.Name = (_0024tc_00242702.Target as ReferenceExpression).Name;
										_0024decl_00242710.Declaration.Type = _0024tc_00242702.Type;
										Block block7 = (_0024_00241429_00242720 = new Block(LexicalInfo.Empty));
										Block block8 = _0024_00241429_00242720;
										Statement[] array5 = new Statement[4];
										BinaryExpression binaryExpression9 = (_0024_00241420_00242711 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType12 = (_0024_00241420_00242711.Operator = BinaryOperatorType.Assign);
										Expression expression42 = (_0024_00241420_00242711.Left = Expression.Lift(_0024c_00242684));
										Expression expression44 = (_0024_00241420_00242711.Right = Expression.Lift(_0024collection_00242683));
										array5[0] = Statement.Lift(_0024_00241420_00242711);
										BinaryExpression binaryExpression10 = (_0024_00241423_00242714 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType14 = (_0024_00241423_00242714.Operator = BinaryOperatorType.Assign);
										Expression expression46 = (_0024_00241423_00242714.Left = Expression.Lift(_0024n_00242686));
										BinaryExpression binaryExpression11 = _0024_00241423_00242714;
										MethodInvocationExpression methodInvocationExpression3 = (_0024_00241422_00242713 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression4 = _0024_00241422_00242713;
										ReferenceExpression referenceExpression2 = (_0024_00241421_00242712 = new ReferenceExpression(LexicalInfo.Empty));
										string text8 = (_0024_00241421_00242712.Name = "len");
										Expression expression48 = (methodInvocationExpression4.Target = _0024_00241421_00242712);
										ExpressionCollection expressionCollection4 = (_0024_00241422_00242713.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024c_00242684)));
										Expression expression50 = (binaryExpression11.Right = _0024_00241422_00242713);
										array5[1] = Statement.Lift(_0024_00241423_00242714);
										BinaryExpression binaryExpression12 = (_0024_00241425_00242716 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType16 = (_0024_00241425_00242716.Operator = BinaryOperatorType.Assign);
										Expression expression52 = (_0024_00241425_00242716.Left = Expression.Lift(_0024i_00242685));
										BinaryExpression binaryExpression13 = _0024_00241425_00242716;
										IntegerLiteralExpression integerLiteralExpression2 = (_0024_00241424_00242715 = new IntegerLiteralExpression(LexicalInfo.Empty));
										long num4 = (_0024_00241424_00242715.Value = 0L);
										bool flag6 = (_0024_00241424_00242715.IsLong = false);
										Expression expression54 = (binaryExpression13.Right = _0024_00241424_00242715);
										array5[2] = Statement.Lift(_0024_00241425_00242716);
										WhileStatement whileStatement4 = (_0024_00241428_00242719 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement5 = _0024_00241428_00242719;
										BinaryExpression binaryExpression14 = (_0024_00241426_00242717 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType18 = (_0024_00241426_00242717.Operator = BinaryOperatorType.LessThan);
										Expression expression56 = (_0024_00241426_00242717.Left = Expression.Lift(_0024i_00242685));
										Expression expression58 = (_0024_00241426_00242717.Right = Expression.Lift(_0024n_00242686));
										Expression expression60 = (whileStatement5.Condition = _0024_00241426_00242717);
										WhileStatement whileStatement6 = _0024_00241428_00242719;
										Block block9 = (_0024_00241427_00242718 = new Block(LexicalInfo.Empty));
										StatementCollection statementCollection6 = (_0024_00241427_00242718.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024decl_00242710)), Statement.Lift(Statement.Lift(_0024sfor_00242721.Body))));
										Block block11 = (whileStatement6.Block = _0024_00241427_00242718);
										array5[3] = Statement.Lift(_0024_00241428_00242719);
										StatementCollection statementCollection8 = (block8.Statements = StatementCollection.FromArray(array5));
										result = (Yield(3, _0024_00241429_00242720) ? 1 : 0);
										break;
									}
									throw new Exception("sfor syntax error: 'sfor 名前, 式' / 'sfor 名前 as 型, 式'");
								}
							}
						}
					}
					throw new Exception("`sfor` macro invocation argument(s) did not match definition: `sfor(v, collection)`");
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

		internal MacroStatement _0024sfor_00242723;

		internal SforMacro _0024self__00242724;

		public _0024ExpandGeneratorImpl_00242679(MacroStatement sfor, SforMacro self_)
		{
			_0024sfor_00242723 = sfor;
			_0024self__00242724 = self_;
		}

		public override IEnumerator<Node> GetEnumerator()
		{
			return new _0024(_0024sfor_00242723, _0024self__00242724);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public SforMacro()
	{
	}

	public SforMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Node> ExpandGeneratorImpl(MacroStatement sfor)
	{
		return new _0024ExpandGeneratorImpl_00242679(sfor, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement sfor)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'sfor' is using. Read BOO-1077 for more info.");
	}
}
