using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

namespace S540;

[Serializable]
public abstract class S540MacroBase : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	internal class _0024GoInstruction_0024locals_002414441
	{
		internal ExpressionCollection _0024args;
	}

	[Serializable]
	internal class _0024CurrInstruction_0024locals_002414442
	{
		internal ExpressionCollection _0024args;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GoInstruction_002419130 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			internal _0024GoInstruction_0024locals_002414441 _0024_0024locals_002419131;

			protected IEnumerator<Expression> _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator(_0024GoInstruction_0024locals_002414441 _0024_0024locals_002419131)
			{
				this._0024_0024locals_002419131 = _0024_0024locals_002419131;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Expression>)_0024_0024locals_002419131._0024args).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					Expression current = _0024_0024enumerator.Current;
					_0024_0024current = current.ToCodeString();
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal _0024GoInstruction_0024locals_002414441 _0024_0024locals_002419132;

		public _0024GoInstruction_002419130(_0024GoInstruction_0024locals_002414441 _0024_0024locals_002419132)
		{
			this._0024_0024locals_002419132 = _0024_0024locals_002419132;
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002419132);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024CurrInstruction_002419133 : GenericGenerator<string>
	{
		[Serializable]
		internal class Enumerator : IDisposable, IEnumerator<string>, ICloneable
		{
			internal _0024CurrInstruction_0024locals_002414442 _0024_0024locals_002419134;

			protected IEnumerator<Expression> _0024_0024enumerator;

			protected string _0024_0024current;

			public override object System_002ECollections_002EIEnumerator_002ECurrent => _0024_0024current;

			public override string Current => _0024_0024current;

			public Enumerator(_0024CurrInstruction_0024locals_002414442 _0024_0024locals_002419134)
			{
				this._0024_0024locals_002419134 = _0024_0024locals_002419134;
				Reset();
			}

			public virtual void Reset()
			{
				_0024_0024enumerator = ((IEnumerable<Expression>)_0024_0024locals_002419134._0024args).GetEnumerator();
			}

			public virtual bool MoveNext()
			{
				int result;
				if (_0024_0024enumerator.MoveNext())
				{
					Expression current = _0024_0024enumerator.Current;
					_0024_0024current = current.ToCodeString();
					result = 1;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}

			public virtual object Clone()
			{
				return MemberwiseClone();
			}

			public virtual void Dispose()
			{
				_0024_0024enumerator.Dispose();
			}
		}

		internal _0024CurrInstruction_0024locals_002414442 _0024_0024locals_002419135;

		public _0024CurrInstruction_002419133(_0024CurrInstruction_0024locals_002414442 _0024_0024locals_002419135)
		{
			this._0024_0024locals_002419135 = _0024_0024locals_002419135;
		}

		public override IEnumerator<string> GetEnumerator()
		{
			return new Enumerator(_0024_0024locals_002419135);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PauseInstruction_002419136 : GenericGenerator<Block>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Block>, IEnumerator
		{
			internal ReferenceExpression _0024t1_002419137;

			internal ReferenceExpression _0024t2_002419138;

			internal string _0024ecode_002419139;

			internal string _0024ipos_002419140;

			internal ReferenceExpression _0024ev_002419141;

			internal BinaryExpression _0024_00244658_002419142;

			internal ReferenceExpression _0024_00244659_002419143;

			internal StringLiteralExpression _0024_00244660_002419144;

			internal BinaryExpression _0024_00244661_002419145;

			internal StringLiteralExpression _0024_00244662_002419146;

			internal BinaryExpression _0024_00244663_002419147;

			internal BinaryExpression _0024_00244664_002419148;

			internal StringLiteralExpression _0024_00244665_002419149;

			internal BinaryExpression _0024_00244666_002419150;

			internal StringLiteralExpression _0024_00244667_002419151;

			internal BinaryExpression _0024_00244668_002419152;

			internal ReferenceExpression _0024_00244669_002419153;

			internal BinaryExpression _0024_00244670_002419154;

			internal MethodInvocationExpression _0024_00244671_002419155;

			internal IntegerLiteralExpression _0024_00244672_002419156;

			internal BinaryExpression _0024_00244673_002419157;

			internal ReferenceExpression _0024_00244674_002419158;

			internal MemberReferenceExpression _0024_00244675_002419159;

			internal StringLiteralExpression _0024_00244676_002419160;

			internal StringLiteralExpression _0024_00244677_002419161;

			internal BinaryExpression _0024_00244678_002419162;

			internal MethodInvocationExpression _0024_00244679_002419163;

			internal Block _0024_00244680_002419164;

			internal DoubleLiteralExpression _0024_00244681_002419165;

			internal BinaryExpression _0024_00244682_002419166;

			internal BinaryExpression _0024_00244683_002419167;

			internal ReferenceExpression _0024_00244684_002419168;

			internal MemberReferenceExpression _0024_00244685_002419169;

			internal BinaryExpression _0024_00244686_002419170;

			internal Block _0024_00244687_002419171;

			internal WhileStatement _0024_00244688_002419172;

			internal Block _0024_00244689_002419173;

			internal IfStatement _0024_00244690_002419174;

			internal Block _0024_00244691_002419175;

			internal CompilerContext _0024ctxt_002419176;

			internal Expression _0024expre_002419177;

			internal Block _0024body_002419178;

			public _0024(CompilerContext ctxt, Expression expre, Block body)
			{
				_0024ctxt_002419176 = ctxt;
				_0024expre_002419177 = expre;
				_0024body_002419178 = body;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024t1_002419137 = new ReferenceExpression(_0024ctxt_002419176.GetUniqueName("s540", "pause"));
					_0024t2_002419138 = new ReferenceExpression(_0024ctxt_002419176.GetUniqueName("s540", "pause"));
					_0024ecode_002419139 = _0024expre_002419177.ToCodeString();
					_0024ipos_002419140 = SrcPosInfo(_0024expre_002419177);
					_0024ev_002419141 = new ReferenceExpression("$CUR_EXEC$");
					Block block = (_0024_00244691_002419175 = new Block(LexicalInfo.Empty));
					Block block2 = _0024_00244691_002419175;
					Statement[] array = new Statement[3];
					BinaryExpression binaryExpression = (_0024_00244658_002419142 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType2 = (_0024_00244658_002419142.Operator = BinaryOperatorType.Assign);
					Expression expression2 = (_0024_00244658_002419142.Left = Expression.Lift(_0024t1_002419137));
					Expression expression4 = (_0024_00244658_002419142.Right = Expression.Lift(_0024expre_002419177));
					array[0] = Statement.Lift(_0024_00244658_002419142);
					MethodInvocationExpression methodInvocationExpression = (_0024_00244671_002419155 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression2 = _0024_00244671_002419155;
					ReferenceExpression referenceExpression = (_0024_00244659_002419143 = new ReferenceExpression(LexicalInfo.Empty));
					string text2 = (_0024_00244659_002419143.Name = "dtrace");
					Expression expression6 = (methodInvocationExpression2.Target = _0024_00244659_002419143);
					MethodInvocationExpression methodInvocationExpression3 = _0024_00244671_002419155;
					Expression[] obj = new Expression[3]
					{
						Expression.Lift(_0024ev_002419141),
						Expression.Lift(_0024ipos_002419140),
						null
					};
					BinaryExpression binaryExpression2 = (_0024_00244670_002419154 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType4 = (_0024_00244670_002419154.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression3 = _0024_00244670_002419154;
					BinaryExpression binaryExpression4 = (_0024_00244668_002419152 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType6 = (_0024_00244668_002419152.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression5 = _0024_00244668_002419152;
					BinaryExpression binaryExpression6 = (_0024_00244666_002419150 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00244666_002419150.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression7 = _0024_00244666_002419150;
					BinaryExpression binaryExpression8 = (_0024_00244664_002419148 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00244664_002419148.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression9 = _0024_00244664_002419148;
					BinaryExpression binaryExpression10 = (_0024_00244663_002419147 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType12 = (_0024_00244663_002419147.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression11 = _0024_00244663_002419147;
					BinaryExpression binaryExpression12 = (_0024_00244661_002419145 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType14 = (_0024_00244661_002419145.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression13 = _0024_00244661_002419145;
					StringLiteralExpression stringLiteralExpression = (_0024_00244660_002419144 = new StringLiteralExpression(LexicalInfo.Empty));
					string text4 = (_0024_00244660_002419144.Value = "pause命令 ");
					Expression expression8 = (binaryExpression13.Left = _0024_00244660_002419144);
					Expression expression10 = (_0024_00244661_002419145.Right = Expression.Lift(_0024t1_002419137));
					Expression expression12 = (binaryExpression11.Left = _0024_00244661_002419145);
					BinaryExpression binaryExpression14 = _0024_00244663_002419147;
					StringLiteralExpression stringLiteralExpression2 = (_0024_00244662_002419146 = new StringLiteralExpression(LexicalInfo.Empty));
					string text6 = (_0024_00244662_002419146.Value = "秒(code:");
					Expression expression14 = (binaryExpression14.Right = _0024_00244662_002419146);
					Expression expression16 = (binaryExpression9.Left = _0024_00244663_002419147);
					Expression expression18 = (_0024_00244664_002419148.Right = Expression.Lift(_0024ecode_002419139));
					Expression expression20 = (binaryExpression7.Left = _0024_00244664_002419148);
					BinaryExpression binaryExpression15 = _0024_00244666_002419150;
					StringLiteralExpression stringLiteralExpression3 = (_0024_00244665_002419149 = new StringLiteralExpression(LexicalInfo.Empty));
					string text8 = (_0024_00244665_002419149.Value = ")");
					Expression expression22 = (binaryExpression15.Right = _0024_00244665_002419149);
					Expression expression24 = (binaryExpression5.Left = _0024_00244666_002419150);
					BinaryExpression binaryExpression16 = _0024_00244668_002419152;
					StringLiteralExpression stringLiteralExpression4 = (_0024_00244667_002419151 = new StringLiteralExpression(LexicalInfo.Empty));
					string text10 = (_0024_00244667_002419151.Value = " @");
					Expression expression26 = (binaryExpression16.Right = _0024_00244667_002419151);
					Expression expression28 = (binaryExpression3.Left = _0024_00244668_002419152);
					BinaryExpression binaryExpression17 = _0024_00244670_002419154;
					ReferenceExpression referenceExpression2 = (_0024_00244669_002419153 = new ReferenceExpression(LexicalInfo.Empty));
					string text12 = (_0024_00244669_002419153.Name = "CurrentStateName");
					Expression expression30 = (binaryExpression17.Right = _0024_00244669_002419153);
					obj[2] = _0024_00244670_002419154;
					ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
					array[1] = Statement.Lift(_0024_00244671_002419155);
					IfStatement ifStatement = (_0024_00244690_002419174 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement2 = _0024_00244690_002419174;
					BinaryExpression binaryExpression18 = (_0024_00244673_002419157 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType16 = (_0024_00244673_002419157.Operator = BinaryOperatorType.LessThan);
					Expression expression32 = (_0024_00244673_002419157.Left = Expression.Lift(_0024t1_002419137));
					BinaryExpression binaryExpression19 = _0024_00244673_002419157;
					IntegerLiteralExpression integerLiteralExpression = (_0024_00244672_002419156 = new IntegerLiteralExpression(LexicalInfo.Empty));
					long num2 = (_0024_00244672_002419156.Value = 0L);
					bool flag2 = (_0024_00244672_002419156.IsLong = false);
					Expression expression34 = (binaryExpression19.Right = _0024_00244672_002419156);
					Expression expression36 = (ifStatement2.Condition = _0024_00244673_002419157);
					IfStatement ifStatement3 = _0024_00244690_002419174;
					Block block3 = (_0024_00244680_002419164 = new Block(LexicalInfo.Empty));
					Block block4 = _0024_00244680_002419164;
					Statement[] array2 = new Statement[1];
					MethodInvocationExpression methodInvocationExpression4 = (_0024_00244679_002419163 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression5 = _0024_00244679_002419163;
					MemberReferenceExpression memberReferenceExpression = (_0024_00244675_002419159 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text14 = (_0024_00244675_002419159.Name = "Err");
					MemberReferenceExpression memberReferenceExpression2 = _0024_00244675_002419159;
					ReferenceExpression referenceExpression3 = (_0024_00244674_002419158 = new ReferenceExpression(LexicalInfo.Empty));
					string text16 = (_0024_00244674_002419158.Name = "S540Expception");
					Expression expression38 = (memberReferenceExpression2.Target = _0024_00244674_002419158);
					Expression expression40 = (methodInvocationExpression5.Target = _0024_00244675_002419159);
					MethodInvocationExpression methodInvocationExpression6 = _0024_00244679_002419163;
					Expression[] array3 = new Expression[3];
					StringLiteralExpression stringLiteralExpression5 = (_0024_00244676_002419160 = new StringLiteralExpression(LexicalInfo.Empty));
					string text18 = (_0024_00244676_002419160.Value = "PAUSE_LESS_0_SEC");
					array3[0] = _0024_00244676_002419160;
					BinaryExpression binaryExpression20 = (_0024_00244678_002419162 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType18 = (_0024_00244678_002419162.Operator = BinaryOperatorType.Addition);
					Expression expression42 = (_0024_00244678_002419162.Left = Expression.Lift(_0024ecode_002419139));
					BinaryExpression binaryExpression21 = _0024_00244678_002419162;
					StringLiteralExpression stringLiteralExpression6 = (_0024_00244677_002419161 = new StringLiteralExpression(LexicalInfo.Empty));
					string text20 = (_0024_00244677_002419161.Value = "が0未満です");
					Expression expression44 = (binaryExpression21.Right = _0024_00244677_002419161);
					array3[1] = _0024_00244678_002419162;
					array3[2] = Expression.Lift(_0024ipos_002419140);
					ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(array3));
					array2[0] = Statement.Lift(_0024_00244679_002419163);
					StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
					Block block6 = (ifStatement3.TrueBlock = _0024_00244680_002419164);
					IfStatement ifStatement4 = _0024_00244690_002419174;
					Block block7 = (_0024_00244689_002419173 = new Block(LexicalInfo.Empty));
					Block block8 = _0024_00244689_002419173;
					Statement[] array4 = new Statement[2];
					BinaryExpression binaryExpression22 = (_0024_00244682_002419166 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType20 = (_0024_00244682_002419166.Operator = BinaryOperatorType.Assign);
					Expression expression46 = (_0024_00244682_002419166.Left = Expression.Lift(_0024t2_002419138));
					BinaryExpression binaryExpression23 = _0024_00244682_002419166;
					DoubleLiteralExpression doubleLiteralExpression = (_0024_00244681_002419165 = new DoubleLiteralExpression(LexicalInfo.Empty));
					double num4 = (_0024_00244681_002419165.Value = 0.0);
					bool flag4 = (_0024_00244681_002419165.IsSingle = true);
					Expression expression48 = (binaryExpression23.Right = _0024_00244681_002419165);
					array4[0] = Statement.Lift(_0024_00244682_002419166);
					WhileStatement whileStatement = (_0024_00244688_002419172 = new WhileStatement(LexicalInfo.Empty));
					WhileStatement whileStatement2 = _0024_00244688_002419172;
					BinaryExpression binaryExpression24 = (_0024_00244683_002419167 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType22 = (_0024_00244683_002419167.Operator = BinaryOperatorType.LessThan);
					Expression expression50 = (_0024_00244683_002419167.Left = Expression.Lift(_0024t2_002419138));
					Expression expression52 = (_0024_00244683_002419167.Right = Expression.Lift(_0024t1_002419137));
					Expression expression54 = (whileStatement2.Condition = _0024_00244683_002419167);
					WhileStatement whileStatement3 = _0024_00244688_002419172;
					Block block9 = (_0024_00244687_002419171 = new Block(LexicalInfo.Empty));
					Block block10 = _0024_00244687_002419171;
					Statement[] obj2 = new Statement[3]
					{
						Statement.Lift(Statement.Lift(_0024body_002419178)),
						null,
						null
					};
					BinaryExpression binaryExpression25 = (_0024_00244686_002419170 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType24 = (_0024_00244686_002419170.Operator = BinaryOperatorType.InPlaceAddition);
					Expression expression56 = (_0024_00244686_002419170.Left = Expression.Lift(_0024t2_002419138));
					BinaryExpression binaryExpression26 = _0024_00244686_002419170;
					MemberReferenceExpression memberReferenceExpression3 = (_0024_00244685_002419169 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text22 = (_0024_00244685_002419169.Name = "deltaTime");
					MemberReferenceExpression memberReferenceExpression4 = _0024_00244685_002419169;
					ReferenceExpression referenceExpression4 = (_0024_00244684_002419168 = new ReferenceExpression(LexicalInfo.Empty));
					string text24 = (_0024_00244684_002419168.Name = "Time");
					Expression expression58 = (memberReferenceExpression4.Target = _0024_00244684_002419168);
					Expression expression60 = (binaryExpression26.Right = _0024_00244685_002419169);
					obj2[1] = Statement.Lift(_0024_00244686_002419170);
					obj2[2] = Statement.Lift(new YieldStatement(LexicalInfo.Empty));
					StatementCollection statementCollection4 = (block10.Statements = StatementCollection.FromArray(obj2));
					Block block12 = (whileStatement3.Block = _0024_00244687_002419171);
					array4[1] = Statement.Lift(_0024_00244688_002419172);
					StatementCollection statementCollection6 = (block8.Statements = StatementCollection.FromArray(array4));
					Block block14 = (ifStatement4.FalseBlock = _0024_00244689_002419173);
					array[2] = Statement.Lift(_0024_00244690_002419174);
					StatementCollection statementCollection8 = (block2.Statements = StatementCollection.FromArray(array));
					result = (Yield(2, _0024_00244691_002419175) ? 1 : 0);
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

		internal CompilerContext _0024ctxt_002419179;

		internal Expression _0024expre_002419180;

		internal Block _0024body_002419181;

		public _0024PauseInstruction_002419136(CompilerContext ctxt, Expression expre, Block body)
		{
			_0024ctxt_002419179 = ctxt;
			_0024expre_002419180 = expre;
			_0024body_002419181 = body;
		}

		public override IEnumerator<Block> GetEnumerator()
		{
			return new _0024(_0024ctxt_002419179, _0024expre_002419180, _0024body_002419181);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024SceneInstruction_002419182 : GenericGenerator<Block>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Block>, IEnumerator
		{
			internal string _0024ipos_002419183;

			internal ReferenceExpression _0024ev_002419184;

			internal ReferenceExpression _0024sceneid_002419185;

			internal ReferenceExpression _0024_00244692_002419186;

			internal StringLiteralExpression _0024_00244693_002419187;

			internal MethodInvocationExpression _0024_00244694_002419188;

			internal ReferenceExpression _0024_00244695_002419189;

			internal MemberReferenceExpression _0024_00244696_002419190;

			internal BinaryExpression _0024_00244697_002419191;

			internal ReferenceExpression _0024_00244698_002419192;

			internal MemberReferenceExpression _0024_00244699_002419193;

			internal MethodInvocationExpression _0024_00244700_002419194;

			internal Block _0024_00244701_002419195;

			internal StringLiteralExpression _0024_00244702_002419196;

			internal BinaryExpression _0024_00244703_002419197;

			internal BinaryExpression _0024_00244704_002419198;

			internal StringLiteralExpression _0024_00244705_002419199;

			internal BinaryExpression _0024_00244706_002419200;

			internal MacroStatement _0024_00244707_002419201;

			internal Block _0024_00244708_002419202;

			internal IfStatement _0024_00244709_002419203;

			internal ReferenceExpression _0024_00244710_002419204;

			internal MemberReferenceExpression _0024_00244711_002419205;

			internal UnaryExpression _0024_00244712_002419206;

			internal StatementModifier _0024_00244713_002419207;

			internal YieldStatement _0024_00244714_002419208;

			internal StringLiteralExpression _0024_00244715_002419209;

			internal BinaryExpression _0024_00244716_002419210;

			internal BinaryExpression _0024_00244717_002419211;

			internal StringLiteralExpression _0024_00244718_002419212;

			internal BinaryExpression _0024_00244719_002419213;

			internal MacroStatement _0024_00244720_002419214;

			internal Block _0024_00244721_002419215;

			internal Block _0024b_002419216;

			internal string _0024sname_002419217;

			internal Boo.Lang.Compiler.Ast.Node _0024srcPosNode_002419218;

			public _0024(string sname, Boo.Lang.Compiler.Ast.Node srcPosNode)
			{
				_0024sname_002419217 = sname;
				_0024srcPosNode_002419218 = srcPosNode;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024ipos_002419183 = SrcPosInfo(_0024srcPosNode_002419218);
					_0024ev_002419184 = new ReferenceExpression("$CUR_EXEC$");
					_0024sceneid_002419185 = ReferenceExpression.Lift("SceneID." + _0024sname_002419217);
					Block block = (_0024_00244721_002419215 = new Block(LexicalInfo.Empty));
					Block block2 = _0024_00244721_002419215;
					Statement[] array = new Statement[4];
					MethodInvocationExpression methodInvocationExpression = (_0024_00244694_002419188 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression2 = _0024_00244694_002419188;
					ReferenceExpression referenceExpression = (_0024_00244692_002419186 = new ReferenceExpression(LexicalInfo.Empty));
					string text2 = (_0024_00244692_002419186.Name = "dtrace");
					Expression expression2 = (methodInvocationExpression2.Target = _0024_00244692_002419186);
					MethodInvocationExpression methodInvocationExpression3 = _0024_00244694_002419188;
					Expression[] obj = new Expression[3]
					{
						Expression.Lift(_0024ev_002419184),
						Expression.Lift(_0024ipos_002419183),
						null
					};
					StringLiteralExpression stringLiteralExpression = (_0024_00244693_002419187 = new StringLiteralExpression(LexicalInfo.Empty));
					string text4 = (_0024_00244693_002419187.Value = "scene命令");
					obj[2] = _0024_00244693_002419187;
					ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
					array[0] = Statement.Lift(_0024_00244694_002419188);
					IfStatement ifStatement = (_0024_00244709_002419203 = new IfStatement(LexicalInfo.Empty));
					IfStatement ifStatement2 = _0024_00244709_002419203;
					BinaryExpression binaryExpression = (_0024_00244697_002419191 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType2 = (_0024_00244697_002419191.Operator = BinaryOperatorType.Inequality);
					Expression expression4 = (_0024_00244697_002419191.Left = Expression.Lift(_0024sname_002419217));
					BinaryExpression binaryExpression2 = _0024_00244697_002419191;
					MemberReferenceExpression memberReferenceExpression = (_0024_00244696_002419190 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text6 = (_0024_00244696_002419190.Name = "CurrentSceneName");
					MemberReferenceExpression memberReferenceExpression2 = _0024_00244696_002419190;
					ReferenceExpression referenceExpression2 = (_0024_00244695_002419189 = new ReferenceExpression(LexicalInfo.Empty));
					string text8 = (_0024_00244695_002419189.Name = "SceneChanger");
					Expression expression6 = (memberReferenceExpression2.Target = _0024_00244695_002419189);
					Expression expression8 = (binaryExpression2.Right = _0024_00244696_002419190);
					Expression expression10 = (ifStatement2.Condition = _0024_00244697_002419191);
					IfStatement ifStatement3 = _0024_00244709_002419203;
					Block block3 = (_0024_00244701_002419195 = new Block(LexicalInfo.Empty));
					Block block4 = _0024_00244701_002419195;
					Statement[] array2 = new Statement[1];
					MethodInvocationExpression methodInvocationExpression4 = (_0024_00244700_002419194 = new MethodInvocationExpression(LexicalInfo.Empty));
					MethodInvocationExpression methodInvocationExpression5 = _0024_00244700_002419194;
					MemberReferenceExpression memberReferenceExpression3 = (_0024_00244699_002419193 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text10 = (_0024_00244699_002419193.Name = "ChangeTo");
					MemberReferenceExpression memberReferenceExpression4 = _0024_00244699_002419193;
					ReferenceExpression referenceExpression3 = (_0024_00244698_002419192 = new ReferenceExpression(LexicalInfo.Empty));
					string text12 = (_0024_00244698_002419192.Name = "SceneChanger");
					Expression expression12 = (memberReferenceExpression4.Target = _0024_00244698_002419192);
					Expression expression14 = (methodInvocationExpression5.Target = _0024_00244699_002419193);
					ExpressionCollection expressionCollection4 = (_0024_00244700_002419194.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024sceneid_002419185)));
					array2[0] = Statement.Lift(_0024_00244700_002419194);
					StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
					Block block6 = (ifStatement3.TrueBlock = _0024_00244701_002419195);
					IfStatement ifStatement4 = _0024_00244709_002419203;
					Block block7 = (_0024_00244708_002419202 = new Block(LexicalInfo.Empty));
					Block block8 = _0024_00244708_002419202;
					Statement[] array3 = new Statement[1];
					MacroStatement macroStatement = (_0024_00244707_002419201 = new MacroStatement(LexicalInfo.Empty));
					string text14 = (_0024_00244707_002419201.Name = "logwarn");
					MacroStatement macroStatement2 = _0024_00244707_002419201;
					Expression[] array4 = new Expression[1];
					BinaryExpression binaryExpression3 = (_0024_00244706_002419200 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType4 = (_0024_00244706_002419200.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression4 = _0024_00244706_002419200;
					BinaryExpression binaryExpression5 = (_0024_00244704_002419198 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType6 = (_0024_00244704_002419198.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression6 = _0024_00244704_002419198;
					BinaryExpression binaryExpression7 = (_0024_00244703_002419197 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType8 = (_0024_00244703_002419197.Operator = BinaryOperatorType.Addition);
					Expression expression16 = (_0024_00244703_002419197.Left = Expression.Lift(_0024ipos_002419183));
					BinaryExpression binaryExpression8 = _0024_00244703_002419197;
					StringLiteralExpression stringLiteralExpression2 = (_0024_00244702_002419196 = new StringLiteralExpression(LexicalInfo.Empty));
					string text16 = (_0024_00244702_002419196.Value = " -- ");
					Expression expression18 = (binaryExpression8.Right = _0024_00244702_002419196);
					Expression expression20 = (binaryExpression6.Left = _0024_00244703_002419197);
					Expression expression22 = (_0024_00244704_002419198.Right = Expression.Lift(_0024sname_002419217));
					Expression expression24 = (binaryExpression4.Left = _0024_00244704_002419198);
					BinaryExpression binaryExpression9 = _0024_00244706_002419200;
					StringLiteralExpression stringLiteralExpression3 = (_0024_00244705_002419199 = new StringLiteralExpression(LexicalInfo.Empty));
					string text18 = (_0024_00244705_002419199.Value = "は既にロード済みです");
					Expression expression26 = (binaryExpression9.Right = _0024_00244705_002419199);
					array4[0] = _0024_00244706_002419200;
					ExpressionCollection expressionCollection6 = (macroStatement2.Arguments = ExpressionCollection.FromArray(array4));
					Block block10 = (_0024_00244707_002419201.Body = new Block(LexicalInfo.Empty));
					array3[0] = Statement.Lift(_0024_00244707_002419201);
					StatementCollection statementCollection4 = (block8.Statements = StatementCollection.FromArray(array3));
					Block block12 = (ifStatement4.FalseBlock = _0024_00244708_002419202);
					array[1] = Statement.Lift(_0024_00244709_002419203);
					YieldStatement yieldStatement = (_0024_00244714_002419208 = new YieldStatement(LexicalInfo.Empty));
					YieldStatement yieldStatement2 = _0024_00244714_002419208;
					StatementModifier statementModifier = (_0024_00244713_002419207 = new StatementModifier(LexicalInfo.Empty));
					StatementModifierType statementModifierType2 = (_0024_00244713_002419207.Type = StatementModifierType.While);
					StatementModifier statementModifier2 = _0024_00244713_002419207;
					UnaryExpression unaryExpression = (_0024_00244712_002419206 = new UnaryExpression(LexicalInfo.Empty));
					UnaryOperatorType unaryOperatorType2 = (_0024_00244712_002419206.Operator = UnaryOperatorType.LogicalNot);
					UnaryExpression unaryExpression2 = _0024_00244712_002419206;
					MemberReferenceExpression memberReferenceExpression5 = (_0024_00244711_002419205 = new MemberReferenceExpression(LexicalInfo.Empty));
					string text20 = (_0024_00244711_002419205.Name = "isFadeOut");
					MemberReferenceExpression memberReferenceExpression6 = _0024_00244711_002419205;
					ReferenceExpression referenceExpression4 = (_0024_00244710_002419204 = new ReferenceExpression(LexicalInfo.Empty));
					string text22 = (_0024_00244710_002419204.Name = "SceneChanger");
					Expression expression28 = (memberReferenceExpression6.Target = _0024_00244710_002419204);
					Expression expression30 = (unaryExpression2.Operand = _0024_00244711_002419205);
					Expression expression32 = (statementModifier2.Condition = _0024_00244712_002419206);
					StatementModifier statementModifier4 = (yieldStatement2.Modifier = _0024_00244713_002419207);
					array[2] = Statement.Lift(_0024_00244714_002419208);
					MacroStatement macroStatement3 = (_0024_00244720_002419214 = new MacroStatement(LexicalInfo.Empty));
					string text24 = (_0024_00244720_002419214.Name = "log");
					MacroStatement macroStatement4 = _0024_00244720_002419214;
					Expression[] array5 = new Expression[1];
					BinaryExpression binaryExpression10 = (_0024_00244719_002419213 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType10 = (_0024_00244719_002419213.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression11 = _0024_00244719_002419213;
					BinaryExpression binaryExpression12 = (_0024_00244717_002419211 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType12 = (_0024_00244717_002419211.Operator = BinaryOperatorType.Addition);
					BinaryExpression binaryExpression13 = _0024_00244717_002419211;
					BinaryExpression binaryExpression14 = (_0024_00244716_002419210 = new BinaryExpression(LexicalInfo.Empty));
					BinaryOperatorType binaryOperatorType14 = (_0024_00244716_002419210.Operator = BinaryOperatorType.Addition);
					Expression expression34 = (_0024_00244716_002419210.Left = Expression.Lift(_0024ipos_002419183));
					BinaryExpression binaryExpression15 = _0024_00244716_002419210;
					StringLiteralExpression stringLiteralExpression4 = (_0024_00244715_002419209 = new StringLiteralExpression(LexicalInfo.Empty));
					string text26 = (_0024_00244715_002419209.Value = " -- ");
					Expression expression36 = (binaryExpression15.Right = _0024_00244715_002419209);
					Expression expression38 = (binaryExpression13.Left = _0024_00244716_002419210);
					Expression expression40 = (_0024_00244717_002419211.Right = Expression.Lift(_0024sname_002419217));
					Expression expression42 = (binaryExpression11.Left = _0024_00244717_002419211);
					BinaryExpression binaryExpression16 = _0024_00244719_002419213;
					StringLiteralExpression stringLiteralExpression5 = (_0024_00244718_002419212 = new StringLiteralExpression(LexicalInfo.Empty));
					string text28 = (_0024_00244718_002419212.Value = "切替完了");
					Expression expression44 = (binaryExpression16.Right = _0024_00244718_002419212);
					array5[0] = _0024_00244719_002419213;
					ExpressionCollection expressionCollection8 = (macroStatement4.Arguments = ExpressionCollection.FromArray(array5));
					Block block14 = (_0024_00244720_002419214.Body = new Block(LexicalInfo.Empty));
					array[3] = Statement.Lift(_0024_00244720_002419214);
					StatementCollection statementCollection6 = (block2.Statements = StatementCollection.FromArray(array));
					_0024b_002419216 = _0024_00244721_002419215;
					_0024b_002419216.LexicalInfo = _0024srcPosNode_002419218.LexicalInfo;
					result = (Yield(2, _0024b_002419216) ? 1 : 0);
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

		internal string _0024sname_002419219;

		internal Boo.Lang.Compiler.Ast.Node _0024srcPosNode_002419220;

		public _0024SceneInstruction_002419182(string sname, Boo.Lang.Compiler.Ast.Node srcPosNode)
		{
			_0024sname_002419219 = sname;
			_0024srcPosNode_002419220 = srcPosNode;
		}

		public override IEnumerator<Block> GetEnumerator()
		{
			return new _0024(_0024sname_002419219, _0024srcPosNode_002419220);
		}
	}

	[NonSerialized]
	public const string BLOCK_ARG_NAME = "$INNER_BLOCK$";

	[NonSerialized]
	public const string STATE_NAME = "$STATE_NAME$";

	[NonSerialized]
	public const string CURRENT_EXEC_VAR = "$CUR_EXEC$";

	[NonSerialized]
	public const string EXPAND_INNER_BLOCK_CODE = "__inner_block__";

	[NonSerialized]
	public static bool DebugWriteExpandedCodeToFile;

	[NonSerialized]
	public static bool DebugFullTrace;

	public CompilerContext CC => CompilerContext.Current;

	public static void MError(string eid, string msg)
	{
		MError(eid, msg, null);
	}

	public static void MError(string eid, string msg, string sinfo)
	{
		if (string.IsNullOrEmpty(sinfo))
		{
			throw new Exception(new StringBuilder("[").Append(eid).Append(" error] ").Append(msg)
				.ToString());
		}
		throw new Exception(sinfo + new StringBuilder(" -- [").Append(eid).Append(" error] ").Append(msg)
			.ToString());
	}

	public static string FullStateName(string s)
	{
		return FullStateName(s, withBlockArg: false);
	}

	public static string FullStateName(string s, bool withBlockArg)
	{
		if (s[0] == '@')
		{
			s = s.Substring(1);
		}
		return (!withBlockArg) ? ("S540_" + s) : ("S540_" + s);
	}

	public static ReferenceExpression FullStateRef(string s)
	{
		return FullStateRef(s, withBlockArg: false);
	}

	public static ReferenceExpression FullStateRef(string s, bool withBlockArg)
	{
		return new ReferenceExpression(FullStateName(s, withBlockArg));
	}

	public static ReferenceExpression FullStateRef(Expression e)
	{
		return FullStateRef(e, withBlockArg: false);
	}

	public static ReferenceExpression FullStateRef(Expression e, bool withBlockArg)
	{
		ReferenceExpression referenceExpression = e as ReferenceExpression;
		if (referenceExpression == null)
		{
			MError("NON_NAME", e.ToCodeString() + "is not a valid 'name'.");
		}
		return new ReferenceExpression(FullStateName(referenceExpression.Name, withBlockArg));
	}

	public static string SrcPosInfo(Boo.Lang.Compiler.Ast.Node node)
	{
		string fileName = Path.GetFileName(node.LexicalInfo.FileName);
		return fileName + ":" + node.LexicalInfo.Line;
	}

	public static MethodInvocationExpression PrintSub(ExpressionCollection args, Boo.Lang.Compiler.Ast.Node srcNode)
	{
		int count = ((ICollection)args).Count;
		string s = SrcPosInfo(srcNode);
		object result;
		switch (count)
		{
		case 0:
		{
			MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
			ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
			string text4 = (referenceExpression2.Name = "dlog");
			Expression expression4 = (methodInvocationExpression2.Target = referenceExpression2);
			ExpressionCollection expressionCollection4 = (methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(Expression.Lift(s)));
			result = methodInvocationExpression2;
			break;
		}
		case 1:
		{
			MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
			ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
			string text2 = (referenceExpression.Name = "dlog");
			Expression expression2 = (methodInvocationExpression.Target = referenceExpression);
			ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(Expression.Lift(s), Expression.Lift(args[0])));
			result = methodInvocationExpression;
			break;
		}
		default:
			MError("INVALID_p_ARGS", "p error -- \"p\" or \"p expression\"");
			result = null;
			break;
		}
		return (MethodInvocationExpression)result;
	}

	public static Block GoInstruction(CompilerContext ctxt, Expression sid, Boo.Lang.Compiler.Ast.Node node)
	{
		return GoInstruction(ctxt, sid, new ExpressionCollection(), node);
	}

	public static Block GoInstruction(CompilerContext ctxt, string sname, Boo.Lang.Compiler.Ast.Node node)
	{
		return GoInstruction(ctxt, new ReferenceExpression(sname), new ExpressionCollection(), node);
	}

	public static Block GoInstruction(CompilerContext ctxt, Expression sexp, ExpressionCollection args, Boo.Lang.Compiler.Ast.Node node)
	{
		_0024GoInstruction_0024locals_002414441 _0024GoInstruction_0024locals_0024 = new _0024GoInstruction_0024locals_002414441();
		_0024GoInstruction_0024locals_0024._0024args = args;
		ReferenceExpression referenceExpression = FullStateRef(sexp);
		string s = SrcPosInfo(node);
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression();
		object obj = referenceExpression.Clone();
		if (!(obj is Expression))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Expression));
		}
		Expression expression2 = (methodInvocationExpression.Target = (Expression)obj);
		object obj2 = _0024GoInstruction_0024locals_0024._0024args.Clone();
		if (!(obj2 is ExpressionCollection))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(ExpressionCollection));
		}
		ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = (ExpressionCollection)obj2);
		MethodInvocationExpression methodInvocationExpression2 = methodInvocationExpression;
		methodInvocationExpression2.LexicalInfo = node.LexicalInfo;
		string s2 = new List(new _0024GoInstruction_002419130(_0024GoInstruction_0024locals_0024)).Join(",");
		ReferenceExpression e = new ReferenceExpression(ctxt.GetUniqueName("s540", "go"));
		ReferenceExpression e2 = new ReferenceExpression(ctxt.GetUniqueName("s540", "tmp"));
		ReferenceExpression e3 = new ReferenceExpression("$CUR_EXEC$");
		Block block = new Block(LexicalInfo.Empty);
		Statement[] array = new Statement[5];
		MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
		string text2 = (referenceExpression2.Name = "dtrace");
		Expression expression4 = (methodInvocationExpression3.Target = referenceExpression2);
		Expression[] obj3 = new Expression[3]
		{
			Expression.Lift(e3),
			Expression.Lift(s),
			null
		};
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression6 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType12 = (binaryExpression6.Operator = BinaryOperatorType.Addition);
		StringLiteralExpression stringLiteralExpression = new StringLiteralExpression(LexicalInfo.Empty);
		string text4 = (stringLiteralExpression.Value = "go命令 ");
		Expression expression6 = (binaryExpression6.Left = stringLiteralExpression);
		ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
		string text6 = (referenceExpression3.Name = "CurrentStateName");
		Expression expression8 = (binaryExpression6.Right = referenceExpression3);
		Expression expression10 = (binaryExpression5.Left = binaryExpression6);
		StringLiteralExpression stringLiteralExpression2 = new StringLiteralExpression(LexicalInfo.Empty);
		string text8 = (stringLiteralExpression2.Value = "->");
		Expression expression12 = (binaryExpression5.Right = stringLiteralExpression2);
		Expression expression14 = (binaryExpression4.Left = binaryExpression5);
		Expression expression16 = (binaryExpression4.Right = Expression.Lift(referenceExpression.Name));
		Expression expression18 = (binaryExpression3.Left = binaryExpression4);
		StringLiteralExpression stringLiteralExpression3 = new StringLiteralExpression(LexicalInfo.Empty);
		string text10 = (stringLiteralExpression3.Value = "(");
		Expression expression20 = (binaryExpression3.Right = stringLiteralExpression3);
		Expression expression22 = (binaryExpression2.Left = binaryExpression3);
		Expression expression24 = (binaryExpression2.Right = Expression.Lift(s2));
		Expression expression26 = (binaryExpression.Left = binaryExpression2);
		StringLiteralExpression stringLiteralExpression4 = new StringLiteralExpression(LexicalInfo.Empty);
		string text12 = (stringLiteralExpression4.Value = ")");
		Expression expression28 = (binaryExpression.Right = stringLiteralExpression4);
		obj3[2] = binaryExpression;
		ExpressionCollection expressionCollection4 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj3));
		array[0] = Statement.Lift(methodInvocationExpression3);
		BinaryExpression binaryExpression7 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType14 = (binaryExpression7.Operator = BinaryOperatorType.Assign);
		Expression expression30 = (binaryExpression7.Left = Expression.Lift(e));
		MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
		string text14 = (referenceExpression4.Name = "createExecAsCurrent");
		Expression expression32 = (methodInvocationExpression4.Target = referenceExpression4);
		ExpressionCollection expressionCollection6 = (methodInvocationExpression4.Arguments = ExpressionCollection.FromArray(Expression.Lift(referenceExpression.Name)));
		Expression expression34 = (binaryExpression7.Right = methodInvocationExpression4);
		array[1] = Statement.Lift(binaryExpression7);
		BinaryExpression binaryExpression8 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType16 = (binaryExpression8.Operator = BinaryOperatorType.Assign);
		Expression expression36 = (binaryExpression8.Left = Expression.Lift(e2));
		Expression expression38 = (binaryExpression8.Right = Expression.Lift(methodInvocationExpression2));
		array[2] = Statement.Lift(binaryExpression8);
		MethodInvocationExpression methodInvocationExpression5 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression5 = new ReferenceExpression(LexicalInfo.Empty);
		string text16 = (referenceExpression5.Name = "entryCoroutine");
		Expression expression40 = (methodInvocationExpression5.Target = referenceExpression5);
		ExpressionCollection expressionCollection8 = (methodInvocationExpression5.Arguments = ExpressionCollection.FromArray(Expression.Lift(e), Expression.Lift(e2)));
		array[3] = Statement.Lift(methodInvocationExpression5);
		array[4] = Statement.Lift(new ReturnStatement(LexicalInfo.Empty));
		StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
		Block block2 = block;
		block2.LexicalInfo = node.LexicalInfo;
		return block2;
	}

	public static Block CurrInstruction(CompilerContext ctxt, string sname, Boo.Lang.Compiler.Ast.Node node)
	{
		return CurrInstruction(ctxt, new ReferenceExpression(sname), new ExpressionCollection(), node);
	}

	public static Block CurrInstruction(CompilerContext ctxt, Expression sexp, ExpressionCollection args, Boo.Lang.Compiler.Ast.Node node)
	{
		_0024CurrInstruction_0024locals_002414442 _0024CurrInstruction_0024locals_0024 = new _0024CurrInstruction_0024locals_002414442();
		_0024CurrInstruction_0024locals_0024._0024args = args;
		ReferenceExpression referenceExpression = FullStateRef(sexp);
		string s = SrcPosInfo(node);
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression();
		object obj = referenceExpression.Clone();
		if (!(obj is Expression))
		{
			obj = RuntimeServices.Coerce(obj, typeof(Expression));
		}
		Expression expression2 = (methodInvocationExpression.Target = (Expression)obj);
		object obj2 = _0024CurrInstruction_0024locals_0024._0024args.Clone();
		if (!(obj2 is ExpressionCollection))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(ExpressionCollection));
		}
		ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = (ExpressionCollection)obj2);
		MethodInvocationExpression methodInvocationExpression2 = methodInvocationExpression;
		methodInvocationExpression2.LexicalInfo = node.LexicalInfo;
		string s2 = new List(new _0024CurrInstruction_002419133(_0024CurrInstruction_0024locals_0024)).Join(",");
		ReferenceExpression e = new ReferenceExpression(ctxt.GetUniqueName("s540", "curr"));
		ReferenceExpression e2 = new ReferenceExpression(ctxt.GetUniqueName("s540", "tmp"));
		ReferenceExpression e3 = new ReferenceExpression("$CUR_EXEC$");
		Block block = new Block(LexicalInfo.Empty);
		Statement[] array = new Statement[4];
		MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
		string text2 = (referenceExpression2.Name = "dtrace");
		Expression expression4 = (methodInvocationExpression3.Target = referenceExpression2);
		Expression[] obj3 = new Expression[3]
		{
			Expression.Lift(e3),
			Expression.Lift(s),
			null
		};
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.Addition);
		BinaryExpression binaryExpression6 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType12 = (binaryExpression6.Operator = BinaryOperatorType.Addition);
		StringLiteralExpression stringLiteralExpression = new StringLiteralExpression(LexicalInfo.Empty);
		string text4 = (stringLiteralExpression.Value = "curr命令 ");
		Expression expression6 = (binaryExpression6.Left = stringLiteralExpression);
		ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
		string text6 = (referenceExpression3.Name = "CurrentStateName");
		Expression expression8 = (binaryExpression6.Right = referenceExpression3);
		Expression expression10 = (binaryExpression5.Left = binaryExpression6);
		StringLiteralExpression stringLiteralExpression2 = new StringLiteralExpression(LexicalInfo.Empty);
		string text8 = (stringLiteralExpression2.Value = "->");
		Expression expression12 = (binaryExpression5.Right = stringLiteralExpression2);
		Expression expression14 = (binaryExpression4.Left = binaryExpression5);
		Expression expression16 = (binaryExpression4.Right = Expression.Lift(referenceExpression.Name));
		Expression expression18 = (binaryExpression3.Left = binaryExpression4);
		StringLiteralExpression stringLiteralExpression3 = new StringLiteralExpression(LexicalInfo.Empty);
		string text10 = (stringLiteralExpression3.Value = "(");
		Expression expression20 = (binaryExpression3.Right = stringLiteralExpression3);
		Expression expression22 = (binaryExpression2.Left = binaryExpression3);
		Expression expression24 = (binaryExpression2.Right = Expression.Lift(s2));
		Expression expression26 = (binaryExpression.Left = binaryExpression2);
		StringLiteralExpression stringLiteralExpression4 = new StringLiteralExpression(LexicalInfo.Empty);
		string text12 = (stringLiteralExpression4.Value = ")");
		Expression expression28 = (binaryExpression.Right = stringLiteralExpression4);
		obj3[2] = binaryExpression;
		ExpressionCollection expressionCollection4 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj3));
		array[0] = Statement.Lift(methodInvocationExpression3);
		BinaryExpression binaryExpression7 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType14 = (binaryExpression7.Operator = BinaryOperatorType.Assign);
		Expression expression30 = (binaryExpression7.Left = Expression.Lift(e));
		MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
		string text14 = (referenceExpression4.Name = "createExec");
		Expression expression32 = (methodInvocationExpression4.Target = referenceExpression4);
		ExpressionCollection expressionCollection6 = (methodInvocationExpression4.Arguments = ExpressionCollection.FromArray(Expression.Lift(referenceExpression.Name), Expression.Lift(e3)));
		Expression expression34 = (binaryExpression7.Right = methodInvocationExpression4);
		array[1] = Statement.Lift(binaryExpression7);
		BinaryExpression binaryExpression8 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType16 = (binaryExpression8.Operator = BinaryOperatorType.Assign);
		Expression expression36 = (binaryExpression8.Left = Expression.Lift(e2));
		Expression expression38 = (binaryExpression8.Right = Expression.Lift(methodInvocationExpression2));
		array[2] = Statement.Lift(binaryExpression8);
		MethodInvocationExpression methodInvocationExpression5 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression5 = new ReferenceExpression(LexicalInfo.Empty);
		string text16 = (referenceExpression5.Name = "entryCoroutine");
		Expression expression40 = (methodInvocationExpression5.Target = referenceExpression5);
		ExpressionCollection expressionCollection8 = (methodInvocationExpression5.Arguments = ExpressionCollection.FromArray(Expression.Lift(e), Expression.Lift(e2)));
		array[3] = Statement.Lift(methodInvocationExpression5);
		StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
		Block block2 = block;
		block2.LexicalInfo = node.LexicalInfo;
		return block2;
	}

	public static Method InvocationToDefinition(Expression sref)
	{
		return InvocationToDefinition(sref, new ExpressionCollection(), withBlockArgType: false);
	}

	public static Method InvocationToDefinition(Expression sref, bool withBlockArgType)
	{
		return InvocationToDefinition(sref, new ExpressionCollection(), withBlockArgType);
	}

	public static Method InvocationToDefinition(Expression sref, ExpressionCollection args)
	{
		return InvocationToDefinition(sref, args, withBlockArgType: false);
	}

	public static Method InvocationToDefinition(Expression sref, ExpressionCollection args, bool withBlockArgType)
	{
		ReferenceExpression referenceExpression = FullStateRef(sref, withBlockArgType);
		Method method = new Method(referenceExpression.Name);
		method.ReturnType = TypeReference.Lift("System.Collections.IEnumerator");
		IEnumerator<Expression> enumerator = args.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Expression current = enumerator.Current;
				TryCastExpression tryCastExpression = current as TryCastExpression;
				ReferenceExpression referenceExpression2 = current as ReferenceExpression;
				if (tryCastExpression != null)
				{
					ReferenceExpression referenceExpression3 = tryCastExpression.Target as ReferenceExpression;
					TypeReference type = tryCastExpression.Type as TypeReference;
					if (referenceExpression3 == null)
					{
						MError("INVALID_NAME", referenceExpression3.ToCodeString() + "is not a valid 'name'.");
					}
					method.Parameters.Add(new ParameterDeclaration(referenceExpression3.Name, type));
				}
				else if (referenceExpression2 != null)
				{
					ParameterDeclaration item = new ParameterDeclaration(referenceExpression2.Name, TypeReference.Lift("duck"));
					method.Parameters.Add(item);
				}
				else if (tryCastExpression == null)
				{
					MError("S_ARGUMENT", current.ToCodeString() + " is not a valid argument.");
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (withBlockArgType)
		{
			CallableTypeReference type2 = CallableTypeNoArgs("System.Collections.IEnumerator");
			method.Parameters.Add(new ParameterDeclaration("$INNER_BLOCK$", type2));
		}
		return method;
	}

	public static CallableTypeReference CallableTypeNoArgs(string retType)
	{
		CallableTypeReference callableTypeReference = new CallableTypeReference();
		callableTypeReference.ReturnType = TypeReference.Lift(retType);
		return callableTypeReference;
	}

	public static Block CallInstruction(CompilerContext ctxt, string mname, Boo.Lang.Compiler.Ast.Node srcPosNode)
	{
		return CallInstruction(ctxt, new ReferenceExpression(mname), new ExpressionCollection(), srcPosNode);
	}

	public static Block CallInstruction(CompilerContext ctxt, ReferenceExpression mref, ExpressionCollection args, Boo.Lang.Compiler.Ast.Node srcPosNode)
	{
		ReferenceExpression sid = FullStateRef(mref);
		return CallInstructionMain(ctxt, sid, args, null, srcPosNode);
	}

	public static Block CallInstructionMain(CompilerContext ctxt, ReferenceExpression sid, ExpressionCollection args, Block innerBlock, Boo.Lang.Compiler.Ast.Node srcPosNode)
	{
		if (ctxt == null || sid == null || args == null || srcPosNode == null)
		{
			throw new AssertionFailedException("CALL nistake!!");
		}
		ReferenceExpression referenceExpression = new ReferenceExpression(ctxt.GetUniqueName("s540", "call"));
		ReferenceExpression e = new ReferenceExpression(ctxt.GetUniqueName("s540", "call"));
		string s = SrcPosInfo(srcPosNode);
		Block block = new Block();
		ReferenceExpression e2 = new ReferenceExpression("$CUR_EXEC$");
		Block block2 = new Block(LexicalInfo.Empty);
		Statement[] array = new Statement[2];
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
		string text2 = (referenceExpression2.Name = "dtrace");
		Expression expression2 = (methodInvocationExpression.Target = referenceExpression2);
		Expression[] obj = new Expression[3]
		{
			Expression.Lift(e2),
			Expression.Lift(s),
			null
		};
		StringLiteralExpression stringLiteralExpression = new StringLiteralExpression(LexicalInfo.Empty);
		string text4 = (stringLiteralExpression.Value = "call命令");
		obj[2] = stringLiteralExpression;
		ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(obj));
		array[0] = Statement.Lift(methodInvocationExpression);
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression4 = (binaryExpression.Left = Expression.Lift(e));
		MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
		string text6 = (referenceExpression3.Name = "createExec");
		Expression expression6 = (methodInvocationExpression2.Target = referenceExpression3);
		ExpressionCollection expressionCollection4 = (methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(Expression.Lift(sid.Name), Expression.Lift(e2)));
		Expression expression8 = (binaryExpression.Right = methodInvocationExpression2);
		array[1] = Statement.Lift(binaryExpression);
		StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
		Block block3 = block2;
		Block block4;
		if (innerBlock == null || innerBlock.IsEmpty)
		{
			MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression();
			Expression expression10 = (methodInvocationExpression3.Target = sid);
			object obj2 = args.Clone();
			if (!(obj2 is ExpressionCollection))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(ExpressionCollection));
			}
			ExpressionCollection expressionCollection6 = (methodInvocationExpression3.Arguments = (ExpressionCollection)obj2);
			MethodInvocationExpression e3 = methodInvocationExpression3;
			BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
			BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Assign);
			Expression expression12 = (binaryExpression2.Left = Expression.Lift(referenceExpression));
			Expression expression14 = (binaryExpression2.Right = Expression.Lift(e3));
			block4 = Statement.Lift(binaryExpression2).ToBlock();
		}
		else
		{
			ExpressionCollection expressionCollection7 = args.Clone() as ExpressionCollection;
			ReferenceExpression referenceExpression4 = new ReferenceExpression(ctxt.GetUniqueName("s540", "call"));
			expressionCollection7.Add(referenceExpression4);
			MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression();
			Expression expression16 = (methodInvocationExpression4.Target = sid);
			object obj3 = expressionCollection7.Clone();
			if (!(obj3 is ExpressionCollection))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(ExpressionCollection));
			}
			ExpressionCollection expressionCollection9 = (methodInvocationExpression4.Arguments = (ExpressionCollection)obj3);
			MethodInvocationExpression e3 = methodInvocationExpression4;
			Block block5 = StateEndCode();
			string uniqueName = ctxt.GetUniqueName("s540", "innerblock");
			Block node = StateHeaderCode(ctxt, uniqueName, withDummyBlockArg: true);
			Block block6 = new Block(LexicalInfo.Empty);
			Statement[] array2 = new Statement[2];
			BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
			BinaryOperatorType binaryOperatorType6 = (binaryExpression3.Operator = BinaryOperatorType.Assign);
			Expression expression18 = (binaryExpression3.Left = Expression.Lift(referenceExpression4));
			BlockExpression blockExpression = new BlockExpression(LexicalInfo.Empty);
			SimpleTypeReference simpleTypeReference = new SimpleTypeReference(LexicalInfo.Empty);
			bool flag2 = (simpleTypeReference.IsPointer = false);
			string text8 = (simpleTypeReference.Name = "System.Collections.IEnumerator");
			TypeReference typeReference2 = (blockExpression.ReturnType = simpleTypeReference);
			Block block7 = new Block(LexicalInfo.Empty);
			StatementCollection statementCollection4 = (block7.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(node)), Statement.Lift(Statement.Lift(innerBlock))));
			Block block9 = (blockExpression.Body = block7);
			Expression expression20 = (binaryExpression3.Right = blockExpression);
			array2[0] = Statement.Lift(binaryExpression3);
			BinaryExpression binaryExpression4 = new BinaryExpression(LexicalInfo.Empty);
			BinaryOperatorType binaryOperatorType8 = (binaryExpression4.Operator = BinaryOperatorType.Assign);
			Expression expression22 = (binaryExpression4.Left = Expression.Lift(referenceExpression));
			Expression expression24 = (binaryExpression4.Right = Expression.Lift(e3));
			array2[1] = Statement.Lift(binaryExpression4);
			StatementCollection statementCollection6 = (block6.Statements = StatementCollection.FromArray(array2));
			block4 = block6.ToBlock();
		}
		ReferenceExpression referenceExpression5 = new ReferenceExpression(ctxt.GetUniqueName("s540", "call"));
		ForStatement forStatement = new ForStatement();
		forStatement.Iterator = referenceExpression;
		forStatement.Declarations.Add(new Declaration(referenceExpression5.Name, null));
		YieldStatement yieldStatement = new YieldStatement(LexicalInfo.Empty);
		Expression expression26 = (yieldStatement.Expression = Expression.Lift(referenceExpression5));
		forStatement.Block = yieldStatement.ToBlock();
		Block block10 = new Block(LexicalInfo.Empty);
		Statement[] array3 = new Statement[2];
		IfStatement ifStatement = new IfStatement(LexicalInfo.Empty);
		BinaryExpression binaryExpression5 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType10 = (binaryExpression5.Operator = BinaryOperatorType.Inequality);
		Expression expression28 = (binaryExpression5.Left = Expression.Lift(referenceExpression));
		Expression expression30 = (binaryExpression5.Right = new NullLiteralExpression(LexicalInfo.Empty));
		Expression expression32 = (ifStatement.Condition = binaryExpression5);
		Block block11 = new Block(LexicalInfo.Empty);
		StatementCollection statementCollection8 = (block11.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(forStatement))));
		Block block13 = (ifStatement.TrueBlock = block11);
		array3[0] = Statement.Lift(ifStatement);
		IfStatement ifStatement2 = new IfStatement(LexicalInfo.Empty);
		UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
		UnaryOperatorType unaryOperatorType2 = (unaryExpression.Operator = UnaryOperatorType.LogicalNot);
		MethodInvocationExpression methodInvocationExpression5 = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression6 = new ReferenceExpression(LexicalInfo.Empty);
		string text10 = (referenceExpression6.Name = "isExecuting");
		Expression expression34 = (methodInvocationExpression5.Target = referenceExpression6);
		ExpressionCollection expressionCollection11 = (methodInvocationExpression5.Arguments = ExpressionCollection.FromArray(Expression.Lift(e2)));
		Expression expression36 = (unaryExpression.Operand = methodInvocationExpression5);
		Expression expression38 = (ifStatement2.Condition = unaryExpression);
		Block block14 = new Block(LexicalInfo.Empty);
		StatementCollection statementCollection10 = (block14.Statements = StatementCollection.FromArray(Statement.Lift(new ReturnStatement(LexicalInfo.Empty))));
		Block block16 = (ifStatement2.TrueBlock = block14);
		array3[1] = Statement.Lift(ifStatement2);
		StatementCollection statementCollection12 = (block10.Statements = StatementCollection.FromArray(array3));
		Block block17 = block10;
		block.Add(block3);
		block.Add(block4);
		block.Add(block17);
		return block;
	}

	public static IEnumerable<Block> PauseInstruction(CompilerContext ctxt, Expression expre, Block body)
	{
		return new _0024PauseInstruction_002419136(ctxt, expre, body);
	}

	public static IEnumerable<Block> SceneInstruction(string sname, Boo.Lang.Compiler.Ast.Node srcPosNode)
	{
		return new _0024SceneInstruction_002419182(sname, srcPosNode);
	}

	public static Block StateEndCode()
	{
		ReferenceExpression e = new ReferenceExpression("$CUR_EXEC$");
		Block block = new Block(LexicalInfo.Empty);
		Statement[] array = new Statement[2];
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
		ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
		string text2 = (referenceExpression.Name = "stop");
		Expression expression2 = (methodInvocationExpression.Target = referenceExpression);
		ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(Expression.Lift(e)));
		array[0] = Statement.Lift(methodInvocationExpression);
		array[1] = Statement.Lift(new ReturnStatement(LexicalInfo.Empty));
		StatementCollection statementCollection2 = (block.Statements = StatementCollection.FromArray(array));
		return block;
	}

	public static void WriteCodeToFile(string file, object node)
	{
		if (!DebugWriteExpandedCodeToFile)
		{
			return;
		}
		StreamWriter streamWriter;
		IDisposable disposable = (streamWriter = new StreamWriter(file)) as IDisposable;
		try
		{
			streamWriter.Write("#" + DateTime.Now + "\n");
			streamWriter.Write(RuntimeServices.Invoke(node, "ToCodeString", new object[0]));
			streamWriter.Write("# vim:filetype=boo");
		}
		finally
		{
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
		}
	}

	public static Block InsertFullTraceCode(Block blk)
	{
		Block result;
		if (!DebugFullTrace)
		{
			result = blk;
		}
		else
		{
			Block block = new Block();
			IEnumerator<Statement> enumerator = blk.Statements.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Statement current = enumerator.Current;
					if (current is Block)
					{
						block.Add(InsertFullTraceCode(current as Block));
						continue;
					}
					string s = SrcPosInfo(current);
					string s2 = RuntimeServices.Mid(current.ToCodeString().Trim(), 0, 32) + "...";
					MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
					ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
					string text2 = (referenceExpression.Name = "dumpExecInfo");
					Expression expression2 = (methodInvocationExpression.Target = referenceExpression);
					Expression[] array = new Expression[1];
					BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
					BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Addition);
					Expression expression4 = (binaryExpression.Left = Expression.Lift(s));
					Expression expression6 = (binaryExpression.Right = Expression.Lift(s2));
					array[0] = binaryExpression;
					ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(array));
					MethodInvocationExpression expression7 = methodInvocationExpression;
					block.Add(expression7);
					block.Add(current);
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			result = block;
		}
		return result;
	}

	public static Block StateHeaderCode(CompilerContext ctxt, ReferenceExpression sref, bool withDummyBlockArg)
	{
		return StateHeaderCode(ctxt, sref.Name, withDummyBlockArg);
	}

	public static Block StateHeaderCode(CompilerContext ctxt, string sname, bool withDummyBlockArg)
	{
		if (string.IsNullOrEmpty(sname))
		{
			throw new AssertionFailedException("CALL NISTAKE!");
		}
		Block block = new Block();
		if (withDummyBlockArg)
		{
			CallableTypeReference callableTypeReference = CallableTypeNoArgs("System.Collections.IEnumerator");
			Declaration declaration = new Declaration();
			string text2 = (declaration.Name = "$INNER_BLOCK$");
			TypeReference typeReference2 = (declaration.Type = callableTypeReference);
			Declaration declaration2 = declaration;
			DeclarationStatement declarationStatement = new DeclarationStatement();
			Declaration declaration4 = (declarationStatement.Declaration = declaration2);
			DeclarationStatement stmt = declarationStatement;
			block.Add(stmt);
		}
		ReferenceExpression referenceExpression = new ReferenceExpression();
		string text4 = (referenceExpression.Name = "$STATE_NAME$");
		ReferenceExpression e = referenceExpression;
		string s = FullStateName(sname);
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression2 = (binaryExpression.Left = Expression.Lift(e));
		Expression expression4 = (binaryExpression.Right = Expression.Lift(s));
		ExpressionStatement stmt2 = new ExpressionStatement(binaryExpression);
		block.Add(stmt2);
		ReferenceExpression e2 = new ReferenceExpression("$CUR_EXEC$");
		BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Assign);
		Expression expression6 = (binaryExpression2.Left = Expression.Lift(e2));
		ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
		string text6 = (referenceExpression2.Name = "lastCreatedExec");
		Expression expression8 = (binaryExpression2.Right = referenceExpression2);
		block.Add(Statement.Lift(binaryExpression2));
		return block;
	}
}
