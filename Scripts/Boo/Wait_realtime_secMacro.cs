using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Wait_realtime_secMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424154 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_002479_002424155;

			internal MacroStatement _0024_0024match_002480_002424156;

			internal Expression _0024time_002424157;

			internal ReferenceExpression _0024t1_002424158;

			internal ReferenceExpression _0024t2_002424159;

			internal SimpleTypeReference _0024_00246380_002424160;

			internal CastExpression _0024_00246381_002424161;

			internal BinaryExpression _0024_00246382_002424162;

			internal ReferenceExpression _0024_00246383_002424163;

			internal MemberReferenceExpression _0024_00246384_002424164;

			internal BinaryExpression _0024_00246385_002424165;

			internal ReferenceExpression _0024_00246386_002424166;

			internal MemberReferenceExpression _0024_00246387_002424167;

			internal BinaryExpression _0024_00246388_002424168;

			internal BinaryExpression _0024_00246389_002424169;

			internal Block _0024_00246390_002424170;

			internal WhileStatement _0024_00246391_002424171;

			internal Block _0024_00246392_002424172;

			internal MacroStatement _0024wait_realtime_sec_002424173;

			internal Wait_realtime_secMacro _0024self__002424174;

			public _0024(MacroStatement wait_realtime_sec, Wait_realtime_secMacro self_)
			{
				_0024wait_realtime_sec_002424173 = wait_realtime_sec;
				_0024self__002424174 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024wait_realtime_sec_002424173 == null)
					{
						throw new ArgumentNullException("wait_realtime_sec");
					}
					_0024self__002424174.__macro = _0024wait_realtime_sec_002424173;
					_0024_0024match_002479_002424155 = _0024wait_realtime_sec_002424173;
					if (_0024_0024match_002479_002424155 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_002480_002424156 = _0024_0024match_002479_002424155);
						if (true && _0024_0024match_002480_002424156.Name == "wait_realtime_sec" && 1 == ((ICollection)_0024_0024match_002480_002424156.Arguments).Count && _0024_0024match_002480_002424156.Arguments[0] is Expression)
						{
							Expression expression = (_0024time_002424157 = _0024_0024match_002480_002424156.Arguments[0]);
							if (true)
							{
								_0024t1_002424158 = new ReferenceExpression(_0024self__002424174.Context.GetUniqueName("wait_realtime_sec", "temp"));
								_0024t2_002424159 = new ReferenceExpression(_0024self__002424174.Context.GetUniqueName("wait_realtime_sec", "temp"));
								Block block = (_0024_00246392_002424172 = new Block(LexicalInfo.Empty));
								Block block2 = _0024_00246392_002424172;
								Statement[] array = new Statement[3];
								BinaryExpression binaryExpression = (_0024_00246382_002424162 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType2 = (_0024_00246382_002424162.Operator = BinaryOperatorType.Assign);
								Expression expression3 = (_0024_00246382_002424162.Left = Expression.Lift(_0024t1_002424158));
								BinaryExpression binaryExpression2 = _0024_00246382_002424162;
								CastExpression castExpression = (_0024_00246381_002424161 = new CastExpression(LexicalInfo.Empty));
								Expression expression5 = (_0024_00246381_002424161.Target = Expression.Lift(_0024time_002424157));
								CastExpression castExpression2 = _0024_00246381_002424161;
								SimpleTypeReference simpleTypeReference = (_0024_00246380_002424160 = new SimpleTypeReference(LexicalInfo.Empty));
								bool flag2 = (_0024_00246380_002424160.IsPointer = false);
								string text2 = (_0024_00246380_002424160.Name = "single");
								TypeReference typeReference2 = (castExpression2.Type = _0024_00246380_002424160);
								Expression expression7 = (binaryExpression2.Right = _0024_00246381_002424161);
								array[0] = Statement.Lift(_0024_00246382_002424162);
								BinaryExpression binaryExpression3 = (_0024_00246385_002424165 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType4 = (_0024_00246385_002424165.Operator = BinaryOperatorType.Assign);
								Expression expression9 = (_0024_00246385_002424165.Left = Expression.Lift(_0024t2_002424159));
								BinaryExpression binaryExpression4 = _0024_00246385_002424165;
								MemberReferenceExpression memberReferenceExpression = (_0024_00246384_002424164 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text4 = (_0024_00246384_002424164.Name = "realtimeSinceStartup");
								MemberReferenceExpression memberReferenceExpression2 = _0024_00246384_002424164;
								ReferenceExpression referenceExpression = (_0024_00246383_002424163 = new ReferenceExpression(LexicalInfo.Empty));
								string text6 = (_0024_00246383_002424163.Name = "Time");
								Expression expression11 = (memberReferenceExpression2.Target = _0024_00246383_002424163);
								Expression expression13 = (binaryExpression4.Right = _0024_00246384_002424164);
								array[1] = Statement.Lift(_0024_00246385_002424165);
								WhileStatement whileStatement = (_0024_00246391_002424171 = new WhileStatement(LexicalInfo.Empty));
								WhileStatement whileStatement2 = _0024_00246391_002424171;
								BinaryExpression binaryExpression5 = (_0024_00246389_002424169 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType6 = (_0024_00246389_002424169.Operator = BinaryOperatorType.LessThan);
								BinaryExpression binaryExpression6 = _0024_00246389_002424169;
								BinaryExpression binaryExpression7 = (_0024_00246388_002424168 = new BinaryExpression(LexicalInfo.Empty));
								BinaryOperatorType binaryOperatorType8 = (_0024_00246388_002424168.Operator = BinaryOperatorType.Subtraction);
								BinaryExpression binaryExpression8 = _0024_00246388_002424168;
								MemberReferenceExpression memberReferenceExpression3 = (_0024_00246387_002424167 = new MemberReferenceExpression(LexicalInfo.Empty));
								string text8 = (_0024_00246387_002424167.Name = "realtimeSinceStartup");
								MemberReferenceExpression memberReferenceExpression4 = _0024_00246387_002424167;
								ReferenceExpression referenceExpression2 = (_0024_00246386_002424166 = new ReferenceExpression(LexicalInfo.Empty));
								string text10 = (_0024_00246386_002424166.Name = "Time");
								Expression expression15 = (memberReferenceExpression4.Target = _0024_00246386_002424166);
								Expression expression17 = (binaryExpression8.Left = _0024_00246387_002424167);
								Expression expression19 = (_0024_00246388_002424168.Right = Expression.Lift(_0024t2_002424159));
								Expression expression21 = (binaryExpression6.Left = _0024_00246388_002424168);
								Expression expression23 = (_0024_00246389_002424169.Right = Expression.Lift(_0024t1_002424158));
								Expression expression25 = (whileStatement2.Condition = _0024_00246389_002424169);
								WhileStatement whileStatement3 = _0024_00246391_002424171;
								Block block3 = (_0024_00246390_002424170 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection2 = (_0024_00246390_002424170.Statements = StatementCollection.FromArray(Statement.Lift(new YieldStatement(LexicalInfo.Empty))));
								Block block5 = (whileStatement3.Block = _0024_00246390_002424170);
								array[2] = Statement.Lift(_0024_00246391_002424171);
								StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
								result = (Yield(2, _0024_00246392_002424172) ? 1 : 0);
								break;
							}
						}
					}
					throw new Exception("`wait_realtime_sec` macro invocation argument(s) did not match definition: `wait_realtime_sec((time as Boo.Lang.Compiler.Ast.Expression))`");
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

		internal MacroStatement _0024wait_realtime_sec_002424175;

		internal Wait_realtime_secMacro _0024self__002424176;

		public _0024ExpandGeneratorImpl_002424154(MacroStatement wait_realtime_sec, Wait_realtime_secMacro self_)
		{
			_0024wait_realtime_sec_002424175 = wait_realtime_sec;
			_0024self__002424176 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024wait_realtime_sec_002424175, _0024self__002424176);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Wait_realtime_secMacro()
	{
	}

	public Wait_realtime_secMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement wait_realtime_sec)
	{
		return new _0024ExpandGeneratorImpl_002424154(wait_realtime_sec, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement wait_realtime_sec)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'wait_realtime_sec' is using. Read BOO-1077 for more info.");
	}
}
