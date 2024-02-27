using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;

namespace S540;

[Serializable]
public class S540Macro : S540MacroBase
{
	[Serializable]
	public class IdentifierExpander : DepthFirstTransformer
	{
		protected CompilerContext ctxt;

		public IdentifierExpander(CompilerContext ctxt)
		{
			this.ctxt = ctxt;
		}

		public override void OnReferenceExpression(ReferenceExpression node)
		{
			Boo.Lang.Compiler.Ast.Node node2 = null;
			string name = node.Name;
			if (name.StartsWith("rand"))
			{
				int i = int.Parse(name.Substring(4));
				MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
				MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
				string text2 = (memberReferenceExpression.Name = "Range");
				MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
				string text4 = (memberReferenceExpression2.Name = "Random");
				ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
				string text6 = (referenceExpression.Name = "UnityEngine");
				Expression expression2 = (memberReferenceExpression2.Target = referenceExpression);
				Expression expression4 = (memberReferenceExpression.Target = memberReferenceExpression2);
				Expression expression6 = (methodInvocationExpression.Target = memberReferenceExpression);
				Expression[] array = new Expression[2];
				IntegerLiteralExpression integerLiteralExpression = new IntegerLiteralExpression(LexicalInfo.Empty);
				long num2 = (integerLiteralExpression.Value = 0L);
				bool flag2 = (integerLiteralExpression.IsLong = false);
				array[0] = integerLiteralExpression;
				array[1] = Expression.Lift(i);
				ExpressionCollection expressionCollection2 = (methodInvocationExpression.Arguments = ExpressionCollection.FromArray(array));
				node2 = GlobalsModule.withLexicalInfoFrom(methodInvocationExpression, node);
			}
			else if (name == "scene_name")
			{
				MemberReferenceExpression memberReferenceExpression3 = new MemberReferenceExpression(LexicalInfo.Empty);
				string text8 = (memberReferenceExpression3.Name = "CurrentSceneName");
				ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
				string text10 = (referenceExpression2.Name = "SceneChanger");
				Expression expression8 = (memberReferenceExpression3.Target = referenceExpression2);
				node2 = GlobalsModule.withLexicalInfoFrom(memberReferenceExpression3, node);
			}
			if (node2 != null)
			{
				ReplaceCurrentNode(node2);
			}
		}
	}

	[Serializable]
	public class StateBodyExpander : IdentifierExpander
	{
		public StateBodyExpander(CompilerContext ctxt)
			: base(ctxt)
		{
		}

		public override void OnYieldStatement(YieldStatement node)
		{
			Block block = new Block();
			block.Add(node);
			ReferenceExpression e = new ReferenceExpression("$CUR_EXEC$");
			ReturnStatement returnStatement = new ReturnStatement(LexicalInfo.Empty);
			StatementModifier statementModifier = new StatementModifier(LexicalInfo.Empty);
			StatementModifierType statementModifierType2 = (statementModifier.Type = StatementModifierType.If);
			MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
			string text2 = (memberReferenceExpression.Name = "NotExecuting");
			Expression expression2 = (memberReferenceExpression.Target = Expression.Lift(e));
			Expression expression4 = (statementModifier.Condition = memberReferenceExpression);
			StatementModifier statementModifier3 = (returnStatement.Modifier = statementModifier);
			ReturnStatement stmt = returnStatement;
			block.Add(stmt);
			ReplaceCurrentNode(block);
		}

		public override void OnReturnStatement(ReturnStatement node)
		{
			if (node.Expression != null)
			{
				S540MacroBase.MError("RETURN_WITH_VALUE", "State(s) cannot return any value(s).");
			}
			ReplaceCurrentNode(S540MacroBase.StateEndCode());
		}

		public override void OnExpressionStatement(ExpressionStatement node)
		{
			Expression expression = node.Expression;
			if (!(expression is MethodInvocationExpression))
			{
				return;
			}
			MethodInvocationExpression methodInvocationExpression = (MethodInvocationExpression)expression;
			if (1 == 0 || !(methodInvocationExpression.Target is ReferenceExpression))
			{
				return;
			}
			ReferenceExpression referenceExpression = (ReferenceExpression)methodInvocationExpression.Target;
			if (1 == 0)
			{
				return;
			}
			string name = referenceExpression.Name;
			if (1 == 0)
			{
				return;
			}
			ExpressionCollection arguments = methodInvocationExpression.Arguments;
			if (1 == 0)
			{
				return;
			}
			if (name.StartsWith("@"))
			{
				ReferenceExpression referenceExpression2 = new ReferenceExpression(name.Substring(1));
				if (arguments.Last is BlockExpression)
				{
					Block body = (arguments.Last as BlockExpression).Body;
					body = Expand(body, ctxt);
					arguments.RemoveAt(checked(arguments.Count - 1));
					ReferenceExpression referenceExpression3 = new ReferenceExpression(ctxt.GetUniqueName("s540", "atcall"));
					ReferenceExpression sid = S540MacroBase.FullStateRef(referenceExpression2);
					Block block = S540MacroBase.CallInstructionMain(ctxt, sid, arguments, body, node);
					block.LexicalInfo = node.LexicalInfo;
					ReplaceCurrentNode(block);
				}
				else
				{
					Block block = S540MacroBase.CallInstruction(ctxt, referenceExpression2, arguments, node);
					block.LexicalInfo = node.LexicalInfo;
					ReplaceCurrentNode(block);
				}
			}
			else if (name == "__inner_block__")
			{
				ReferenceExpression referenceExpression4 = new ReferenceExpression();
				string text2 = (referenceExpression4.Name = "$INNER_BLOCK$");
				ReferenceExpression referenceExpression5 = referenceExpression4;
				Block node2 = S540MacroBase.CallInstructionMain(ctxt, referenceExpression5, new ExpressionCollection(), null, node);
				IfStatement ifStatement = new IfStatement(LexicalInfo.Empty);
				BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
				BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Inequality);
				Expression expression3 = (binaryExpression.Left = Expression.Lift(referenceExpression5));
				Expression expression5 = (binaryExpression.Right = new NullLiteralExpression(LexicalInfo.Empty));
				Expression expression7 = (ifStatement.Condition = binaryExpression);
				Block block2 = new Block(LexicalInfo.Empty);
				StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(node2))));
				Block block4 = (ifStatement.TrueBlock = block2);
				IfStatement stmt = ifStatement;
				Block block5 = new Block();
				block5.Add(stmt);
				ReplaceCurrentNode(block5);
			}
		}

		public static Block Expand(Block b, CompilerContext cc)
		{
			b = (Block)new StateBodyExpander(cc).Visit(b);
			b.Add(S540MacroBase.StateEndCode());
			return b;
		}
	}

	[Serializable]
	public class SMacro : S540MacroBase
	{
		[Serializable]
		public class GoMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419259 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241795_002419260;

					internal MacroStatement _0024_0024match_00241796_002419261;

					internal ReferenceExpression _0024_0024match_00241797_002419262;

					internal string _0024stateName_002419263;

					internal MacroStatement _0024_0024match_00241798_002419264;

					internal MethodInvocationExpression _0024_0024match_00241799_002419265;

					internal Expression _0024sref_002419266;

					internal ExpressionCollection _0024args_002419267;

					internal string _0024ipos_002419268;

					internal MacroStatement _0024mc_002419269;

					internal GoMacro _0024self__002419270;

					public _0024(MacroStatement mc, GoMacro self_)
					{
						_0024mc_002419269 = mc;
						_0024self__002419270 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024match_00241795_002419260 = _0024mc_002419269;
							if (_0024_0024match_00241795_002419260 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241796_002419261 = _0024_0024match_00241795_002419260);
								if (true && _0024_0024match_00241796_002419261.Name == "go" && 1 == ((ICollection)_0024_0024match_00241796_002419261.Arguments).Count && _0024_0024match_00241796_002419261.Arguments[0] is ReferenceExpression)
								{
									ReferenceExpression referenceExpression = (_0024_0024match_00241797_002419262 = (ReferenceExpression)_0024_0024match_00241796_002419261.Arguments[0]);
									if (true)
									{
										string text = (_0024stateName_002419263 = _0024_0024match_00241797_002419262.Name);
										if (true)
										{
											result = (Yield(2, S540MacroBase.GoInstruction(_0024self__002419270.CC, new ReferenceExpression(_0024stateName_002419263), _0024mc_002419269)) ? 1 : 0);
											break;
										}
									}
								}
							}
							if (_0024_0024match_00241795_002419260 is MacroStatement)
							{
								MacroStatement macroStatement2 = (_0024_0024match_00241798_002419264 = _0024_0024match_00241795_002419260);
								if (true && _0024_0024match_00241798_002419264.Name == "go" && 1 == ((ICollection)_0024_0024match_00241798_002419264.Arguments).Count && _0024_0024match_00241798_002419264.Arguments[0] is MethodInvocationExpression)
								{
									MethodInvocationExpression methodInvocationExpression = (_0024_0024match_00241799_002419265 = (MethodInvocationExpression)_0024_0024match_00241798_002419264.Arguments[0]);
									if (true)
									{
										Expression expression = (_0024sref_002419266 = _0024_0024match_00241799_002419265.Target);
										if (true)
										{
											ExpressionCollection expressionCollection = (_0024args_002419267 = _0024_0024match_00241799_002419265.Arguments);
											if (true)
											{
												result = (Yield(3, S540MacroBase.GoInstruction(_0024self__002419270.CC, _0024sref_002419266, _0024args_002419267, _0024mc_002419269)) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
							_0024ipos_002419268 = S540MacroBase.SrcPosInfo(_0024mc_002419269);
							S540MacroBase.MError("INVALID_go", "invalid go usage", _0024ipos_002419268);
							goto case 2;
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

				internal MacroStatement _0024mc_002419271;

				internal GoMacro _0024self__002419272;

				public _0024ExpandGeneratorImpl_002419259(MacroStatement mc, GoMacro self_)
				{
					_0024mc_002419271 = mc;
					_0024self__002419272 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419271, _0024self__002419272);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419259(mc, this);
			}
		}

		[Serializable]
		public class CallMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419273 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241800_002419274;

					internal MacroStatement _0024_0024match_00241801_002419275;

					internal ReferenceExpression _0024_0024match_00241802_002419276;

					internal string _0024stateName_002419277;

					internal Block _0024inblk_002419278;

					internal MacroStatement _0024_0024match_00241803_002419279;

					internal MethodInvocationExpression _0024_0024match_00241804_002419280;

					internal Expression _0024sref_002419281;

					internal ExpressionCollection _0024args_002419282;

					internal string _0024ipos_002419283;

					internal MacroStatement _0024mc_002419284;

					internal CallMacro _0024self__002419285;

					public _0024(MacroStatement mc, CallMacro self_)
					{
						_0024mc_002419284 = mc;
						_0024self__002419285 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024match_00241800_002419274 = _0024mc_002419284;
							if (_0024_0024match_00241800_002419274 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241801_002419275 = _0024_0024match_00241800_002419274);
								if (true && _0024_0024match_00241801_002419275.Name == "call" && 1 == ((ICollection)_0024_0024match_00241801_002419275.Arguments).Count && _0024_0024match_00241801_002419275.Arguments[0] is ReferenceExpression)
								{
									ReferenceExpression referenceExpression = (_0024_0024match_00241802_002419276 = (ReferenceExpression)_0024_0024match_00241801_002419275.Arguments[0]);
									if (true)
									{
										string text = (_0024stateName_002419277 = _0024_0024match_00241802_002419276.Name);
										if (true)
										{
											_0024inblk_002419278 = StateBodyExpander.Expand(_0024mc_002419284.Body, _0024self__002419285.CC);
											result = (Yield(2, S540MacroBase.CallInstructionMain(_0024self__002419285.CC, S540MacroBase.FullStateRef(_0024stateName_002419277), new ExpressionCollection(), _0024inblk_002419278, _0024mc_002419284)) ? 1 : 0);
											break;
										}
									}
								}
							}
							if (_0024_0024match_00241800_002419274 is MacroStatement)
							{
								MacroStatement macroStatement2 = (_0024_0024match_00241803_002419279 = _0024_0024match_00241800_002419274);
								if (true && _0024_0024match_00241803_002419279.Name == "call" && 1 == ((ICollection)_0024_0024match_00241803_002419279.Arguments).Count && _0024_0024match_00241803_002419279.Arguments[0] is MethodInvocationExpression)
								{
									MethodInvocationExpression methodInvocationExpression = (_0024_0024match_00241804_002419280 = (MethodInvocationExpression)_0024_0024match_00241803_002419279.Arguments[0]);
									if (true)
									{
										Expression expression = (_0024sref_002419281 = _0024_0024match_00241804_002419280.Target);
										if (true)
										{
											ExpressionCollection expressionCollection = (_0024args_002419282 = _0024_0024match_00241804_002419280.Arguments);
											if (true)
											{
												_0024inblk_002419278 = StateBodyExpander.Expand(_0024mc_002419284.Body, _0024self__002419285.CC);
												result = (Yield(3, S540MacroBase.CallInstructionMain(_0024self__002419285.CC, S540MacroBase.FullStateRef(_0024sref_002419281), _0024args_002419282, _0024inblk_002419278, _0024mc_002419284)) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
							_0024ipos_002419283 = S540MacroBase.SrcPosInfo(_0024mc_002419284);
							S540MacroBase.MError("INVALID_call", "invalid call usage", _0024ipos_002419283);
							goto case 2;
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

				internal MacroStatement _0024mc_002419286;

				internal CallMacro _0024self__002419287;

				public _0024ExpandGeneratorImpl_002419273(MacroStatement mc, CallMacro self_)
				{
					_0024mc_002419286 = mc;
					_0024self__002419287 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419286, _0024self__002419287);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419273(mc, this);
			}
		}

		[Serializable]
		public class CurrMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419288 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241805_002419289;

					internal MacroStatement _0024_0024match_00241806_002419290;

					internal ReferenceExpression _0024_0024match_00241807_002419291;

					internal string _0024stateName_002419292;

					internal MacroStatement _0024_0024match_00241808_002419293;

					internal MethodInvocationExpression _0024_0024match_00241809_002419294;

					internal Expression _0024sref_002419295;

					internal ExpressionCollection _0024args_002419296;

					internal MacroStatement _0024mc_002419297;

					internal CurrMacro _0024self__002419298;

					public _0024(MacroStatement mc, CurrMacro self_)
					{
						_0024mc_002419297 = mc;
						_0024self__002419298 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024match_00241805_002419289 = _0024mc_002419297;
							if (_0024_0024match_00241805_002419289 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241806_002419290 = _0024_0024match_00241805_002419289);
								if (true && _0024_0024match_00241806_002419290.Name == "curr" && 1 == ((ICollection)_0024_0024match_00241806_002419290.Arguments).Count && _0024_0024match_00241806_002419290.Arguments[0] is ReferenceExpression)
								{
									ReferenceExpression referenceExpression = (_0024_0024match_00241807_002419291 = (ReferenceExpression)_0024_0024match_00241806_002419290.Arguments[0]);
									if (true)
									{
										string text = (_0024stateName_002419292 = _0024_0024match_00241807_002419291.Name);
										if (true)
										{
											result = (Yield(2, S540MacroBase.CurrInstruction(_0024self__002419298.CC, _0024stateName_002419292, _0024mc_002419297)) ? 1 : 0);
											break;
										}
									}
								}
							}
							if (_0024_0024match_00241805_002419289 is MacroStatement)
							{
								MacroStatement macroStatement2 = (_0024_0024match_00241808_002419293 = _0024_0024match_00241805_002419289);
								if (true && _0024_0024match_00241808_002419293.Name == "curr" && 1 == ((ICollection)_0024_0024match_00241808_002419293.Arguments).Count && _0024_0024match_00241808_002419293.Arguments[0] is MethodInvocationExpression)
								{
									MethodInvocationExpression methodInvocationExpression = (_0024_0024match_00241809_002419294 = (MethodInvocationExpression)_0024_0024match_00241808_002419293.Arguments[0]);
									if (true)
									{
										Expression expression = (_0024sref_002419295 = _0024_0024match_00241809_002419294.Target);
										if (true)
										{
											ExpressionCollection expressionCollection = (_0024args_002419296 = _0024_0024match_00241809_002419294.Arguments);
											if (true)
											{
												result = (Yield(3, S540MacroBase.CurrInstruction(_0024self__002419298.CC, _0024sref_002419295, _0024args_002419296, _0024mc_002419297)) ? 1 : 0);
												break;
											}
										}
									}
								}
							}
							throw new MatchError(new StringBuilder("`mc` failed to match `").Append(_0024_0024match_00241805_002419289).Append("`").ToString());
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

				internal MacroStatement _0024mc_002419299;

				internal CurrMacro _0024self__002419300;

				public _0024ExpandGeneratorImpl_002419288(MacroStatement mc, CurrMacro self_)
				{
					_0024mc_002419299 = mc;
					_0024self__002419300 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419299, _0024self__002419300);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419288(mc, this);
			}
		}

		[Serializable]
		public class PMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419301 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal string _0024ipos_002419302;

					internal ReferenceExpression _0024ev_002419303;

					internal ReferenceExpression _0024_00244752_002419304;

					internal StringLiteralExpression _0024_00244753_002419305;

					internal MethodInvocationExpression _0024_00244754_002419306;

					internal MacroStatement _0024mc_002419307;

					public _0024(MacroStatement mc)
					{
						_0024mc_002419307 = mc;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
						{
							_0024ipos_002419302 = S540MacroBase.SrcPosInfo(_0024mc_002419307);
							_0024ev_002419303 = new ReferenceExpression("$CUR_EXEC$");
							MethodInvocationExpression methodInvocationExpression = (_0024_00244754_002419306 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression2 = _0024_00244754_002419306;
							ReferenceExpression referenceExpression = (_0024_00244752_002419304 = new ReferenceExpression(LexicalInfo.Empty));
							string text2 = (_0024_00244752_002419304.Name = "dtrace");
							Expression expression2 = (methodInvocationExpression2.Target = _0024_00244752_002419304);
							MethodInvocationExpression methodInvocationExpression3 = _0024_00244754_002419306;
							Expression[] obj = new Expression[3]
							{
								Expression.Lift(_0024ev_002419303),
								Expression.Lift(_0024ipos_002419302),
								null
							};
							StringLiteralExpression stringLiteralExpression = (_0024_00244753_002419305 = new StringLiteralExpression(LexicalInfo.Empty));
							string text4 = (_0024_00244753_002419305.Value = "p命令");
							obj[2] = _0024_00244753_002419305;
							ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
							result = (Yield(2, _0024_00244754_002419306) ? 1 : 0);
							break;
						}
						case 2:
							result = (Yield(3, S540MacroBase.PrintSub(_0024mc_002419307.Arguments, _0024mc_002419307)) ? 1 : 0);
							break;
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

				internal MacroStatement _0024mc_002419308;

				public _0024ExpandGeneratorImpl_002419301(MacroStatement mc)
				{
					_0024mc_002419308 = mc;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419308);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419301(mc);
			}
		}

		[Serializable]
		public class Wait_UntilMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419309 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241810_002419310;

					internal MacroStatement _0024_0024match_00241811_002419311;

					internal Expression _0024cond_002419312;

					internal ReferenceExpression _0024f1_002419313;

					internal string _0024ipos_002419314;

					internal string _0024ecode_002419315;

					internal ReferenceExpression _0024ev_002419316;

					internal ReferenceExpression _0024_00244755_002419317;

					internal StringLiteralExpression _0024_00244756_002419318;

					internal BinaryExpression _0024_00244757_002419319;

					internal StringLiteralExpression _0024_00244758_002419320;

					internal BinaryExpression _0024_00244759_002419321;

					internal StringLiteralExpression _0024_00244760_002419322;

					internal BinaryExpression _0024_00244761_002419323;

					internal ReferenceExpression _0024_00244762_002419324;

					internal BinaryExpression _0024_00244763_002419325;

					internal MethodInvocationExpression _0024_00244764_002419326;

					internal UnaryExpression _0024_00244765_002419327;

					internal ReferenceExpression _0024_00244766_002419328;

					internal MemberReferenceExpression _0024_00244767_002419329;

					internal BinaryExpression _0024_00244768_002419330;

					internal ReferenceExpression _0024_00244769_002419331;

					internal MemberReferenceExpression _0024_00244770_002419332;

					internal BinaryExpression _0024_00244771_002419333;

					internal StatementModifier _0024_00244772_002419334;

					internal YieldStatement _0024_00244773_002419335;

					internal Block _0024_00244774_002419336;

					internal WhileStatement _0024_00244775_002419337;

					internal Block _0024_00244776_002419338;

					internal Block _0024b_002419339;

					internal MacroStatement _0024mc_002419340;

					internal Wait_UntilMacro _0024self__002419341;

					public _0024(MacroStatement mc, Wait_UntilMacro self_)
					{
						_0024mc_002419340 = mc;
						_0024self__002419341 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024match_00241810_002419310 = _0024mc_002419340;
							if (_0024_0024match_00241810_002419310 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241811_002419311 = _0024_0024match_00241810_002419310);
								if (true && _0024_0024match_00241811_002419311.Name == "wait_until" && 1 == ((ICollection)_0024_0024match_00241811_002419311.Arguments).Count)
								{
									Expression expression = (_0024cond_002419312 = _0024_0024match_00241811_002419311.Arguments[0]);
									if (true)
									{
										_0024f1_002419313 = new ReferenceExpression(_0024self__002419341.CC.GetUniqueName("s540", "wait_until"));
										_0024ipos_002419314 = S540MacroBase.SrcPosInfo(_0024mc_002419340);
										_0024ecode_002419315 = _0024cond_002419312.ToCodeString();
										_0024ev_002419316 = new ReferenceExpression("$CUR_EXEC$");
										Block block = (_0024_00244776_002419338 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00244776_002419338;
										Statement[] array = new Statement[2];
										MethodInvocationExpression methodInvocationExpression = (_0024_00244764_002419326 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00244764_002419326;
										ReferenceExpression referenceExpression = (_0024_00244755_002419317 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00244755_002419317.Name = "dtrace");
										Expression expression3 = (methodInvocationExpression2.Target = _0024_00244755_002419317);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00244764_002419326;
										Expression[] obj = new Expression[3]
										{
											Expression.Lift(_0024ev_002419316),
											Expression.Lift(_0024ipos_002419314),
											null
										};
										BinaryExpression binaryExpression = (_0024_00244763_002419325 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00244763_002419325.Operator = BinaryOperatorType.Addition);
										BinaryExpression binaryExpression2 = _0024_00244763_002419325;
										BinaryExpression binaryExpression3 = (_0024_00244761_002419323 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType4 = (_0024_00244761_002419323.Operator = BinaryOperatorType.Addition);
										BinaryExpression binaryExpression4 = _0024_00244761_002419323;
										BinaryExpression binaryExpression5 = (_0024_00244759_002419321 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType6 = (_0024_00244759_002419321.Operator = BinaryOperatorType.Addition);
										BinaryExpression binaryExpression6 = _0024_00244759_002419321;
										BinaryExpression binaryExpression7 = (_0024_00244757_002419319 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType8 = (_0024_00244757_002419319.Operator = BinaryOperatorType.Addition);
										BinaryExpression binaryExpression8 = _0024_00244757_002419319;
										StringLiteralExpression stringLiteralExpression = (_0024_00244756_002419318 = new StringLiteralExpression(LexicalInfo.Empty));
										string text4 = (_0024_00244756_002419318.Value = "wait_until命令 (");
										Expression expression5 = (binaryExpression8.Left = _0024_00244756_002419318);
										Expression expression7 = (_0024_00244757_002419319.Right = Expression.Lift(_0024ecode_002419315));
										Expression expression9 = (binaryExpression6.Left = _0024_00244757_002419319);
										BinaryExpression binaryExpression9 = _0024_00244759_002419321;
										StringLiteralExpression stringLiteralExpression2 = (_0024_00244758_002419320 = new StringLiteralExpression(LexicalInfo.Empty));
										string text6 = (_0024_00244758_002419320.Value = ")");
										Expression expression11 = (binaryExpression9.Right = _0024_00244758_002419320);
										Expression expression13 = (binaryExpression4.Left = _0024_00244759_002419321);
										BinaryExpression binaryExpression10 = _0024_00244761_002419323;
										StringLiteralExpression stringLiteralExpression3 = (_0024_00244760_002419322 = new StringLiteralExpression(LexicalInfo.Empty));
										string text8 = (_0024_00244760_002419322.Value = " @");
										Expression expression15 = (binaryExpression10.Right = _0024_00244760_002419322);
										Expression expression17 = (binaryExpression2.Left = _0024_00244761_002419323);
										BinaryExpression binaryExpression11 = _0024_00244763_002419325;
										ReferenceExpression referenceExpression2 = (_0024_00244762_002419324 = new ReferenceExpression(LexicalInfo.Empty));
										string text10 = (_0024_00244762_002419324.Name = "CurrentStateName");
										Expression expression19 = (binaryExpression11.Right = _0024_00244762_002419324);
										obj[2] = _0024_00244763_002419325;
										ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
										array[0] = Statement.Lift(_0024_00244764_002419326);
										WhileStatement whileStatement = (_0024_00244775_002419337 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement2 = _0024_00244775_002419337;
										UnaryExpression unaryExpression = (_0024_00244765_002419327 = new UnaryExpression(LexicalInfo.Empty));
										UnaryOperatorType unaryOperatorType2 = (_0024_00244765_002419327.Operator = UnaryOperatorType.LogicalNot);
										Expression expression21 = (_0024_00244765_002419327.Operand = Expression.Lift(_0024cond_002419312));
										Expression expression23 = (whileStatement2.Condition = _0024_00244765_002419327);
										WhileStatement whileStatement3 = _0024_00244775_002419337;
										Block block3 = (_0024_00244774_002419336 = new Block(LexicalInfo.Empty));
										Block block4 = _0024_00244774_002419336;
										Statement[] array2 = new Statement[3];
										BinaryExpression binaryExpression12 = (_0024_00244768_002419330 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType10 = (_0024_00244768_002419330.Operator = BinaryOperatorType.Assign);
										Expression expression25 = (_0024_00244768_002419330.Left = Expression.Lift(_0024f1_002419313));
										BinaryExpression binaryExpression13 = _0024_00244768_002419330;
										MemberReferenceExpression memberReferenceExpression = (_0024_00244767_002419329 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text12 = (_0024_00244767_002419329.Name = "frameCount");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00244767_002419329;
										ReferenceExpression referenceExpression3 = (_0024_00244766_002419328 = new ReferenceExpression(LexicalInfo.Empty));
										string text14 = (_0024_00244766_002419328.Name = "Time");
										Expression expression27 = (memberReferenceExpression2.Target = _0024_00244766_002419328);
										Expression expression29 = (binaryExpression13.Right = _0024_00244767_002419329);
										array2[0] = Statement.Lift(_0024_00244768_002419330);
										array2[1] = Statement.Lift(Statement.Lift(_0024mc_002419340.Body));
										YieldStatement yieldStatement = (_0024_00244773_002419335 = new YieldStatement(LexicalInfo.Empty));
										YieldStatement yieldStatement2 = _0024_00244773_002419335;
										StatementModifier statementModifier = (_0024_00244772_002419334 = new StatementModifier(LexicalInfo.Empty));
										StatementModifierType statementModifierType2 = (_0024_00244772_002419334.Type = StatementModifierType.If);
										StatementModifier statementModifier2 = _0024_00244772_002419334;
										BinaryExpression binaryExpression14 = (_0024_00244771_002419333 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType12 = (_0024_00244771_002419333.Operator = BinaryOperatorType.Equality);
										Expression expression31 = (_0024_00244771_002419333.Left = Expression.Lift(_0024f1_002419313));
										BinaryExpression binaryExpression15 = _0024_00244771_002419333;
										MemberReferenceExpression memberReferenceExpression3 = (_0024_00244770_002419332 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text16 = (_0024_00244770_002419332.Name = "frameCount");
										MemberReferenceExpression memberReferenceExpression4 = _0024_00244770_002419332;
										ReferenceExpression referenceExpression4 = (_0024_00244769_002419331 = new ReferenceExpression(LexicalInfo.Empty));
										string text18 = (_0024_00244769_002419331.Name = "Time");
										Expression expression33 = (memberReferenceExpression4.Target = _0024_00244769_002419331);
										Expression expression35 = (binaryExpression15.Right = _0024_00244770_002419332);
										Expression expression37 = (statementModifier2.Condition = _0024_00244771_002419333);
										StatementModifier statementModifier4 = (yieldStatement2.Modifier = _0024_00244772_002419334);
										array2[2] = Statement.Lift(_0024_00244773_002419335);
										StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
										Block block6 = (whileStatement3.Block = _0024_00244774_002419336);
										array[1] = Statement.Lift(_0024_00244775_002419337);
										StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
										_0024b_002419339 = _0024_00244776_002419338;
										_0024b_002419339.LexicalInfo = _0024mc_002419340.LexicalInfo;
										result = (Yield(2, _0024b_002419339) ? 1 : 0);
										break;
									}
								}
							}
							_0024ipos_002419314 = S540MacroBase.SrcPosInfo(_0024mc_002419340);
							S540MacroBase.MError("INVALID_wait", "invalid wait", _0024ipos_002419314);
							goto case 2;
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

				internal MacroStatement _0024mc_002419342;

				internal Wait_UntilMacro _0024self__002419343;

				public _0024ExpandGeneratorImpl_002419309(MacroStatement mc, Wait_UntilMacro self_)
				{
					_0024mc_002419342 = mc;
					_0024self__002419343 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419342, _0024self__002419343);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419309(mc, this);
			}
		}

		[Serializable]
		public class Wait_SecMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419344 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241812_002419345;

					internal MacroStatement _0024_0024match_00241813_002419346;

					internal Expression _0024expression_002419347;

					internal Block _0024___item_002419348;

					internal string _0024ipos_002419349;

					internal IEnumerator<Block> _0024_0024iterator_002413753_002419350;

					internal MacroStatement _0024mc_002419351;

					internal Wait_SecMacro _0024self__002419352;

					public _0024(MacroStatement mc, Wait_SecMacro self_)
					{
						_0024mc_002419351 = mc;
						_0024self__002419352 = self_;
					}

					public override bool MoveNext()
					{
						bool flag;
						try
						{
							switch (_state)
							{
							default:
								_0024_0024match_00241812_002419345 = _0024mc_002419351;
								if (_0024_0024match_00241812_002419345 is MacroStatement)
								{
									MacroStatement macroStatement = (_0024_0024match_00241813_002419346 = _0024_0024match_00241812_002419345);
									if (true && _0024_0024match_00241813_002419346.Name == "wait_sec" && 1 == ((ICollection)_0024_0024match_00241813_002419346.Arguments).Count)
									{
										Expression expression = (_0024expression_002419347 = _0024_0024match_00241813_002419346.Arguments[0]);
										if (true)
										{
											_0024_0024iterator_002413753_002419350 = S540MacroBase.PauseInstruction(_0024self__002419352.CC, _0024expression_002419347, _0024mc_002419351.Body).GetEnumerator();
											_state = 2;
											goto case 3;
										}
									}
								}
								_0024ipos_002419349 = S540MacroBase.SrcPosInfo(_0024mc_002419351);
								S540MacroBase.MError("INVALID_wait_sec", "invalid wait_sec", _0024ipos_002419349);
								break;
							case 3:
								if (_0024_0024iterator_002413753_002419350.MoveNext())
								{
									_0024___item_002419348 = _0024_0024iterator_002413753_002419350.Current;
									flag = Yield(3, _0024___item_002419348);
									goto IL_0159;
								}
								_state = 1;
								_0024ensure2();
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
						goto IL_015a;
						IL_0159:
						result = (flag ? 1 : 0);
						goto IL_015a;
						IL_015a:
						return (byte)result != 0;
					}

					private void _0024ensure2()
					{
						_0024_0024iterator_002413753_002419350.Dispose();
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

				internal MacroStatement _0024mc_002419353;

				internal Wait_SecMacro _0024self__002419354;

				public _0024ExpandGeneratorImpl_002419344(MacroStatement mc, Wait_SecMacro self_)
				{
					_0024mc_002419353 = mc;
					_0024self__002419354 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419353, _0024self__002419354);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419344(mc, this);
			}
		}

		[Serializable]
		public class PauseMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419355 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241814_002419356;

					internal MacroStatement _0024_0024match_00241815_002419357;

					internal Expression _0024expression_002419358;

					internal Block _0024___item_002419359;

					internal string _0024ipos_002419360;

					internal IEnumerator<Block> _0024_0024iterator_002413754_002419361;

					internal MacroStatement _0024mc_002419362;

					internal PauseMacro _0024self__002419363;

					public _0024(MacroStatement mc, PauseMacro self_)
					{
						_0024mc_002419362 = mc;
						_0024self__002419363 = self_;
					}

					public override bool MoveNext()
					{
						bool flag;
						try
						{
							switch (_state)
							{
							default:
								_0024_0024match_00241814_002419356 = _0024mc_002419362;
								if (_0024_0024match_00241814_002419356 is MacroStatement)
								{
									MacroStatement macroStatement = (_0024_0024match_00241815_002419357 = _0024_0024match_00241814_002419356);
									if (true && _0024_0024match_00241815_002419357.Name == "pause" && 1 == ((ICollection)_0024_0024match_00241815_002419357.Arguments).Count)
									{
										Expression expression = (_0024expression_002419358 = _0024_0024match_00241815_002419357.Arguments[0]);
										if (true)
										{
											_0024_0024iterator_002413754_002419361 = S540MacroBase.PauseInstruction(_0024self__002419363.CC, _0024expression_002419358, _0024mc_002419362.Body).GetEnumerator();
											_state = 2;
											goto case 3;
										}
									}
								}
								_0024ipos_002419360 = S540MacroBase.SrcPosInfo(_0024mc_002419362);
								S540MacroBase.MError("INVALID_pause", "invalid pause", _0024ipos_002419360);
								break;
							case 3:
								if (_0024_0024iterator_002413754_002419361.MoveNext())
								{
									_0024___item_002419359 = _0024_0024iterator_002413754_002419361.Current;
									flag = Yield(3, _0024___item_002419359);
									goto IL_0159;
								}
								_state = 1;
								_0024ensure2();
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
						goto IL_015a;
						IL_0159:
						result = (flag ? 1 : 0);
						goto IL_015a;
						IL_015a:
						return (byte)result != 0;
					}

					private void _0024ensure2()
					{
						_0024_0024iterator_002413754_002419361.Dispose();
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

				internal MacroStatement _0024mc_002419364;

				internal PauseMacro _0024self__002419365;

				public _0024ExpandGeneratorImpl_002419355(MacroStatement mc, PauseMacro self_)
				{
					_0024mc_002419364 = mc;
					_0024self__002419365 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419364, _0024self__002419365);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419355(mc, this);
			}
		}

		[Serializable]
		public class LoopMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419366 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241816_002419367;

					internal MacroStatement _0024_0024match_00241817_002419368;

					internal BinaryExpression _0024_0024match_00241818_002419369;

					internal ReferenceExpression _0024_0024match_00241819_002419370;

					internal string _0024lvar_002419371;

					internal Expression _0024expr_002419372;

					internal ReferenceExpression _0024t1_002419373;

					internal ReferenceExpression _0024t2_002419374;

					internal ReferenceExpression _0024f1_002419375;

					internal string _0024ipos_002419376;

					internal ReferenceExpression _0024ev_002419377;

					internal ReferenceExpression _0024_00244777_002419378;

					internal StringLiteralExpression _0024_00244778_002419379;

					internal MethodInvocationExpression _0024_00244779_002419380;

					internal IntegerLiteralExpression _0024_00244780_002419381;

					internal BinaryExpression _0024_00244781_002419382;

					internal BinaryExpression _0024_00244782_002419383;

					internal BinaryExpression _0024_00244783_002419384;

					internal ReferenceExpression _0024_00244784_002419385;

					internal MemberReferenceExpression _0024_00244785_002419386;

					internal BinaryExpression _0024_00244786_002419387;

					internal UnaryExpression _0024_00244787_002419388;

					internal ReferenceExpression _0024_00244788_002419389;

					internal MemberReferenceExpression _0024_00244789_002419390;

					internal BinaryExpression _0024_00244790_002419391;

					internal StatementModifier _0024_00244791_002419392;

					internal YieldStatement _0024_00244792_002419393;

					internal Block _0024_00244793_002419394;

					internal WhileStatement _0024_00244794_002419395;

					internal Block _0024_00244795_002419396;

					internal ReferenceExpression _0024_00244796_002419397;

					internal StringLiteralExpression _0024_00244797_002419398;

					internal MethodInvocationExpression _0024_00244798_002419399;

					internal BoolLiteralExpression _0024_00244799_002419400;

					internal ReferenceExpression _0024_00244800_002419401;

					internal MemberReferenceExpression _0024_00244801_002419402;

					internal BinaryExpression _0024_00244802_002419403;

					internal ReferenceExpression _0024_00244803_002419404;

					internal MemberReferenceExpression _0024_00244804_002419405;

					internal BinaryExpression _0024_00244805_002419406;

					internal StatementModifier _0024_00244806_002419407;

					internal YieldStatement _0024_00244807_002419408;

					internal Block _0024_00244808_002419409;

					internal WhileStatement _0024_00244809_002419410;

					internal Block _0024_00244810_002419411;

					internal MacroStatement _0024mc_002419412;

					internal LoopMacro _0024self__002419413;

					public _0024(MacroStatement mc, LoopMacro self_)
					{
						_0024mc_002419412 = mc;
						_0024self__002419413 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
						{
							_0024_0024match_00241816_002419367 = _0024mc_002419412;
							if (_0024_0024match_00241816_002419367 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241817_002419368 = _0024_0024match_00241816_002419367);
								if (true && _0024_0024match_00241817_002419368.Name == "loop" && 1 == ((ICollection)_0024_0024match_00241817_002419368.Arguments).Count && _0024_0024match_00241817_002419368.Arguments[0] is BinaryExpression)
								{
									BinaryExpression binaryExpression = (_0024_0024match_00241818_002419369 = (BinaryExpression)_0024_0024match_00241817_002419368.Arguments[0]);
									if (true && _0024_0024match_00241818_002419369.Operator == BinaryOperatorType.Assign && _0024_0024match_00241818_002419369.Left is ReferenceExpression)
									{
										ReferenceExpression referenceExpression = (_0024_0024match_00241819_002419370 = (ReferenceExpression)_0024_0024match_00241818_002419369.Left);
										if (true)
										{
											string text = (_0024lvar_002419371 = _0024_0024match_00241819_002419370.Name);
											if (true)
											{
												Expression expression = (_0024expr_002419372 = _0024_0024match_00241818_002419369.Right);
												if (true)
												{
													_0024t1_002419373 = new ReferenceExpression(_0024lvar_002419371);
													_0024t2_002419374 = new ReferenceExpression(_0024self__002419413.CC.GetUniqueName("s540", "loop"));
													_0024f1_002419375 = new ReferenceExpression(_0024self__002419413.CC.GetUniqueName("s540", "loop"));
													_0024ipos_002419376 = S540MacroBase.SrcPosInfo(_0024mc_002419412);
													_0024ev_002419377 = new ReferenceExpression("$CUR_EXEC$");
													Block block = (_0024_00244795_002419396 = new Block(LexicalInfo.Empty));
													Block block2 = _0024_00244795_002419396;
													Statement[] array = new Statement[4];
													MethodInvocationExpression methodInvocationExpression = (_0024_00244779_002419380 = new MethodInvocationExpression(LexicalInfo.Empty));
													MethodInvocationExpression methodInvocationExpression2 = _0024_00244779_002419380;
													ReferenceExpression referenceExpression2 = (_0024_00244777_002419378 = new ReferenceExpression(LexicalInfo.Empty));
													string text3 = (_0024_00244777_002419378.Name = "dtrace");
													Expression expression3 = (methodInvocationExpression2.Target = _0024_00244777_002419378);
													MethodInvocationExpression methodInvocationExpression3 = _0024_00244779_002419380;
													Expression[] obj = new Expression[3]
													{
														Expression.Lift(_0024ev_002419377),
														Expression.Lift(_0024ipos_002419376),
														null
													};
													StringLiteralExpression stringLiteralExpression = (_0024_00244778_002419379 = new StringLiteralExpression(LexicalInfo.Empty));
													string text5 = (_0024_00244778_002419379.Value = "loop命令");
													obj[2] = _0024_00244778_002419379;
													ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
													array[0] = Statement.Lift(_0024_00244779_002419380);
													BinaryExpression binaryExpression2 = (_0024_00244781_002419382 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType2 = (_0024_00244781_002419382.Operator = BinaryOperatorType.Assign);
													Expression expression5 = (_0024_00244781_002419382.Left = Expression.Lift(_0024t1_002419373));
													BinaryExpression binaryExpression3 = _0024_00244781_002419382;
													IntegerLiteralExpression integerLiteralExpression = (_0024_00244780_002419381 = new IntegerLiteralExpression(LexicalInfo.Empty));
													long num2 = (_0024_00244780_002419381.Value = 0L);
													bool flag2 = (_0024_00244780_002419381.IsLong = false);
													Expression expression7 = (binaryExpression3.Right = _0024_00244780_002419381);
													array[1] = Statement.Lift(_0024_00244781_002419382);
													BinaryExpression binaryExpression4 = (_0024_00244782_002419383 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType4 = (_0024_00244782_002419383.Operator = BinaryOperatorType.Assign);
													Expression expression9 = (_0024_00244782_002419383.Left = Expression.Lift(_0024t2_002419374));
													Expression expression11 = (_0024_00244782_002419383.Right = Expression.Lift(_0024expr_002419372));
													array[2] = Statement.Lift(_0024_00244782_002419383);
													WhileStatement whileStatement = (_0024_00244794_002419395 = new WhileStatement(LexicalInfo.Empty));
													WhileStatement whileStatement2 = _0024_00244794_002419395;
													BinaryExpression binaryExpression5 = (_0024_00244783_002419384 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType6 = (_0024_00244783_002419384.Operator = BinaryOperatorType.LessThan);
													Expression expression13 = (_0024_00244783_002419384.Left = Expression.Lift(_0024t1_002419373));
													Expression expression15 = (_0024_00244783_002419384.Right = Expression.Lift(_0024t2_002419374));
													Expression expression17 = (whileStatement2.Condition = _0024_00244783_002419384);
													WhileStatement whileStatement3 = _0024_00244794_002419395;
													Block block3 = (_0024_00244793_002419394 = new Block(LexicalInfo.Empty));
													Block block4 = _0024_00244793_002419394;
													Statement[] array2 = new Statement[4];
													BinaryExpression binaryExpression6 = (_0024_00244786_002419387 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType8 = (_0024_00244786_002419387.Operator = BinaryOperatorType.Assign);
													Expression expression19 = (_0024_00244786_002419387.Left = Expression.Lift(_0024f1_002419375));
													BinaryExpression binaryExpression7 = _0024_00244786_002419387;
													MemberReferenceExpression memberReferenceExpression = (_0024_00244785_002419386 = new MemberReferenceExpression(LexicalInfo.Empty));
													string text7 = (_0024_00244785_002419386.Name = "frameCount");
													MemberReferenceExpression memberReferenceExpression2 = _0024_00244785_002419386;
													ReferenceExpression referenceExpression3 = (_0024_00244784_002419385 = new ReferenceExpression(LexicalInfo.Empty));
													string text9 = (_0024_00244784_002419385.Name = "Time");
													Expression expression21 = (memberReferenceExpression2.Target = _0024_00244784_002419385);
													Expression expression23 = (binaryExpression7.Right = _0024_00244785_002419386);
													array2[0] = Statement.Lift(_0024_00244786_002419387);
													array2[1] = Statement.Lift(Statement.Lift(_0024mc_002419412.Body));
													UnaryExpression unaryExpression = (_0024_00244787_002419388 = new UnaryExpression(LexicalInfo.Empty));
													UnaryOperatorType unaryOperatorType2 = (_0024_00244787_002419388.Operator = UnaryOperatorType.Increment);
													Expression expression25 = (_0024_00244787_002419388.Operand = Expression.Lift(_0024t1_002419373));
													array2[2] = Statement.Lift(_0024_00244787_002419388);
													YieldStatement yieldStatement = (_0024_00244792_002419393 = new YieldStatement(LexicalInfo.Empty));
													YieldStatement yieldStatement2 = _0024_00244792_002419393;
													StatementModifier statementModifier = (_0024_00244791_002419392 = new StatementModifier(LexicalInfo.Empty));
													StatementModifierType statementModifierType2 = (_0024_00244791_002419392.Type = StatementModifierType.If);
													StatementModifier statementModifier2 = _0024_00244791_002419392;
													BinaryExpression binaryExpression8 = (_0024_00244790_002419391 = new BinaryExpression(LexicalInfo.Empty));
													BinaryOperatorType binaryOperatorType10 = (_0024_00244790_002419391.Operator = BinaryOperatorType.Equality);
													Expression expression27 = (_0024_00244790_002419391.Left = Expression.Lift(_0024f1_002419375));
													BinaryExpression binaryExpression9 = _0024_00244790_002419391;
													MemberReferenceExpression memberReferenceExpression3 = (_0024_00244789_002419390 = new MemberReferenceExpression(LexicalInfo.Empty));
													string text11 = (_0024_00244789_002419390.Name = "frameCount");
													MemberReferenceExpression memberReferenceExpression4 = _0024_00244789_002419390;
													ReferenceExpression referenceExpression4 = (_0024_00244788_002419389 = new ReferenceExpression(LexicalInfo.Empty));
													string text13 = (_0024_00244788_002419389.Name = "Time");
													Expression expression29 = (memberReferenceExpression4.Target = _0024_00244788_002419389);
													Expression expression31 = (binaryExpression9.Right = _0024_00244789_002419390);
													Expression expression33 = (statementModifier2.Condition = _0024_00244790_002419391);
													StatementModifier statementModifier4 = (yieldStatement2.Modifier = _0024_00244791_002419392);
													array2[3] = Statement.Lift(_0024_00244792_002419393);
													StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(array2));
													Block block6 = (whileStatement3.Block = _0024_00244793_002419394);
													array[3] = Statement.Lift(_0024_00244794_002419395);
													StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
													result = (Yield(2, _0024_00244795_002419396) ? 1 : 0);
													break;
												}
											}
										}
									}
								}
							}
							_0024f1_002419375 = new ReferenceExpression(_0024self__002419413.CC.GetUniqueName("s540", "loop"));
							_0024ipos_002419376 = S540MacroBase.SrcPosInfo(_0024mc_002419412);
							_0024ev_002419377 = new ReferenceExpression("$CUR_EXEC$");
							Block block7 = (_0024_00244810_002419411 = new Block(LexicalInfo.Empty));
							Block block8 = _0024_00244810_002419411;
							Statement[] array3 = new Statement[2];
							MethodInvocationExpression methodInvocationExpression4 = (_0024_00244798_002419399 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression5 = _0024_00244798_002419399;
							ReferenceExpression referenceExpression5 = (_0024_00244796_002419397 = new ReferenceExpression(LexicalInfo.Empty));
							string text15 = (_0024_00244796_002419397.Name = "dtrace");
							Expression expression35 = (methodInvocationExpression5.Target = _0024_00244796_002419397);
							MethodInvocationExpression methodInvocationExpression6 = _0024_00244798_002419399;
							Expression[] obj2 = new Expression[3]
							{
								Expression.Lift(_0024ev_002419377),
								Expression.Lift(_0024ipos_002419376),
								null
							};
							StringLiteralExpression stringLiteralExpression2 = (_0024_00244797_002419398 = new StringLiteralExpression(LexicalInfo.Empty));
							string text17 = (_0024_00244797_002419398.Value = "loop命令");
							obj2[2] = _0024_00244797_002419398;
							ExpressionCollection expressionCollection4 = (methodInvocationExpression6.Arguments = ExpressionCollection.FromArray(obj2));
							array3[0] = Statement.Lift(_0024_00244798_002419399);
							WhileStatement whileStatement4 = (_0024_00244809_002419410 = new WhileStatement(LexicalInfo.Empty));
							WhileStatement whileStatement5 = _0024_00244809_002419410;
							BoolLiteralExpression boolLiteralExpression = (_0024_00244799_002419400 = new BoolLiteralExpression(LexicalInfo.Empty));
							bool flag4 = (_0024_00244799_002419400.Value = true);
							Expression expression37 = (whileStatement5.Condition = _0024_00244799_002419400);
							WhileStatement whileStatement6 = _0024_00244809_002419410;
							Block block9 = (_0024_00244808_002419409 = new Block(LexicalInfo.Empty));
							Block block10 = _0024_00244808_002419409;
							Statement[] array4 = new Statement[3];
							BinaryExpression binaryExpression10 = (_0024_00244802_002419403 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType12 = (_0024_00244802_002419403.Operator = BinaryOperatorType.Assign);
							Expression expression39 = (_0024_00244802_002419403.Left = Expression.Lift(_0024f1_002419375));
							BinaryExpression binaryExpression11 = _0024_00244802_002419403;
							MemberReferenceExpression memberReferenceExpression5 = (_0024_00244801_002419402 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text19 = (_0024_00244801_002419402.Name = "frameCount");
							MemberReferenceExpression memberReferenceExpression6 = _0024_00244801_002419402;
							ReferenceExpression referenceExpression6 = (_0024_00244800_002419401 = new ReferenceExpression(LexicalInfo.Empty));
							string text21 = (_0024_00244800_002419401.Name = "Time");
							Expression expression41 = (memberReferenceExpression6.Target = _0024_00244800_002419401);
							Expression expression43 = (binaryExpression11.Right = _0024_00244801_002419402);
							array4[0] = Statement.Lift(_0024_00244802_002419403);
							array4[1] = Statement.Lift(Statement.Lift(_0024mc_002419412.Body));
							YieldStatement yieldStatement3 = (_0024_00244807_002419408 = new YieldStatement(LexicalInfo.Empty));
							YieldStatement yieldStatement4 = _0024_00244807_002419408;
							StatementModifier statementModifier5 = (_0024_00244806_002419407 = new StatementModifier(LexicalInfo.Empty));
							StatementModifierType statementModifierType4 = (_0024_00244806_002419407.Type = StatementModifierType.If);
							StatementModifier statementModifier6 = _0024_00244806_002419407;
							BinaryExpression binaryExpression12 = (_0024_00244805_002419406 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType14 = (_0024_00244805_002419406.Operator = BinaryOperatorType.Equality);
							Expression expression45 = (_0024_00244805_002419406.Left = Expression.Lift(_0024f1_002419375));
							BinaryExpression binaryExpression13 = _0024_00244805_002419406;
							MemberReferenceExpression memberReferenceExpression7 = (_0024_00244804_002419405 = new MemberReferenceExpression(LexicalInfo.Empty));
							string text23 = (_0024_00244804_002419405.Name = "frameCount");
							MemberReferenceExpression memberReferenceExpression8 = _0024_00244804_002419405;
							ReferenceExpression referenceExpression7 = (_0024_00244803_002419404 = new ReferenceExpression(LexicalInfo.Empty));
							string text25 = (_0024_00244803_002419404.Name = "Time");
							Expression expression47 = (memberReferenceExpression8.Target = _0024_00244803_002419404);
							Expression expression49 = (binaryExpression13.Right = _0024_00244804_002419405);
							Expression expression51 = (statementModifier6.Condition = _0024_00244805_002419406);
							StatementModifier statementModifier8 = (yieldStatement4.Modifier = _0024_00244806_002419407);
							array4[2] = Statement.Lift(_0024_00244807_002419408);
							StatementCollection statementCollection6 = (block10.Statements = StatementCollection.FromArray(array4));
							Block block12 = (whileStatement6.Block = _0024_00244808_002419409);
							array3[1] = Statement.Lift(_0024_00244809_002419410);
							StatementCollection statementCollection8 = (block8.Statements = StatementCollection.FromArray(array3));
							result = (Yield(3, _0024_00244810_002419411) ? 1 : 0);
							break;
						}
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

				internal MacroStatement _0024mc_002419414;

				internal LoopMacro _0024self__002419415;

				public _0024ExpandGeneratorImpl_002419366(MacroStatement mc, LoopMacro self_)
				{
					_0024mc_002419414 = mc;
					_0024self__002419415 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419414, _0024self__002419415);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419366(mc, this);
			}
		}

		[Serializable]
		public class RepsecMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419416 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241820_002419417;

					internal MacroStatement _0024_0024match_00241821_002419418;

					internal Expression _0024expression_002419419;

					internal ReferenceExpression _0024t1_002419420;

					internal string _0024ipos_002419421;

					internal ReferenceExpression _0024ev_002419422;

					internal ReferenceExpression _0024_00244811_002419423;

					internal StringLiteralExpression _0024_00244812_002419424;

					internal MethodInvocationExpression _0024_00244813_002419425;

					internal BinaryExpression _0024_00244814_002419426;

					internal BoolLiteralExpression _0024_00244815_002419427;

					internal ReferenceExpression _0024_00244816_002419428;

					internal MethodInvocationExpression _0024_00244817_002419429;

					internal YieldStatement _0024_00244818_002419430;

					internal Block _0024_00244819_002419431;

					internal WhileStatement _0024_00244820_002419432;

					internal Block _0024_00244821_002419433;

					internal MacroStatement _0024mc_002419434;

					internal RepsecMacro _0024self__002419435;

					public _0024(MacroStatement mc, RepsecMacro self_)
					{
						_0024mc_002419434 = mc;
						_0024self__002419435 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
							_0024_0024match_00241820_002419417 = _0024mc_002419434;
							if (_0024_0024match_00241820_002419417 is MacroStatement)
							{
								MacroStatement macroStatement = (_0024_0024match_00241821_002419418 = _0024_0024match_00241820_002419417);
								if (true && _0024_0024match_00241821_002419418.Name == "repsec" && 1 == ((ICollection)_0024_0024match_00241821_002419418.Arguments).Count)
								{
									Expression expression = (_0024expression_002419419 = _0024_0024match_00241821_002419418.Arguments[0]);
									if (true)
									{
										_0024t1_002419420 = new ReferenceExpression(_0024self__002419435.CC.GetUniqueName("s540", "repsec"));
										_0024ipos_002419421 = S540MacroBase.SrcPosInfo(_0024mc_002419434);
										_0024ev_002419422 = new ReferenceExpression("$CUR_EXEC$");
										Block block = (_0024_00244821_002419433 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00244821_002419433;
										Statement[] array = new Statement[3];
										MethodInvocationExpression methodInvocationExpression = (_0024_00244813_002419425 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression2 = _0024_00244813_002419425;
										ReferenceExpression referenceExpression = (_0024_00244811_002419423 = new ReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00244811_002419423.Name = "dtrace");
										Expression expression3 = (methodInvocationExpression2.Target = _0024_00244811_002419423);
										MethodInvocationExpression methodInvocationExpression3 = _0024_00244813_002419425;
										Expression[] obj = new Expression[3]
										{
											Expression.Lift(_0024ev_002419422),
											Expression.Lift(_0024ipos_002419421),
											null
										};
										StringLiteralExpression stringLiteralExpression = (_0024_00244812_002419424 = new StringLiteralExpression(LexicalInfo.Empty));
										string text4 = (_0024_00244812_002419424.Value = "repsec命令");
										obj[2] = _0024_00244812_002419424;
										ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
										array[0] = Statement.Lift(_0024_00244813_002419425);
										BinaryExpression binaryExpression = (_0024_00244814_002419426 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00244814_002419426.Operator = BinaryOperatorType.Assign);
										Expression expression5 = (_0024_00244814_002419426.Left = Expression.Lift(_0024t1_002419420));
										Expression expression7 = (_0024_00244814_002419426.Right = Expression.Lift(_0024expression_002419419));
										array[1] = Statement.Lift(_0024_00244814_002419426);
										WhileStatement whileStatement = (_0024_00244820_002419432 = new WhileStatement(LexicalInfo.Empty));
										WhileStatement whileStatement2 = _0024_00244820_002419432;
										BoolLiteralExpression boolLiteralExpression = (_0024_00244815_002419427 = new BoolLiteralExpression(LexicalInfo.Empty));
										bool flag2 = (_0024_00244815_002419427.Value = true);
										Expression expression9 = (whileStatement2.Condition = _0024_00244815_002419427);
										WhileStatement whileStatement3 = _0024_00244820_002419432;
										Block block3 = (_0024_00244819_002419431 = new Block(LexicalInfo.Empty));
										Block block4 = _0024_00244819_002419431;
										Statement[] obj2 = new Statement[2]
										{
											Statement.Lift(Statement.Lift(_0024mc_002419434.Body)),
											null
										};
										YieldStatement yieldStatement = (_0024_00244818_002419430 = new YieldStatement(LexicalInfo.Empty));
										YieldStatement yieldStatement2 = _0024_00244818_002419430;
										MethodInvocationExpression methodInvocationExpression4 = (_0024_00244817_002419429 = new MethodInvocationExpression(LexicalInfo.Empty));
										MethodInvocationExpression methodInvocationExpression5 = _0024_00244817_002419429;
										ReferenceExpression referenceExpression2 = (_0024_00244816_002419428 = new ReferenceExpression(LexicalInfo.Empty));
										string text6 = (_0024_00244816_002419428.Name = "WaitForSeconds");
										Expression expression11 = (methodInvocationExpression5.Target = _0024_00244816_002419428);
										ExpressionCollection expressionCollection4 = (_0024_00244817_002419429.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024t1_002419420)));
										Expression expression13 = (yieldStatement2.Expression = _0024_00244817_002419429);
										obj2[1] = Statement.Lift(_0024_00244818_002419430);
										StatementCollection statementCollection2 = (block4.Statements = StatementCollection.FromArray(obj2));
										Block block6 = (whileStatement3.Block = _0024_00244819_002419431);
										array[2] = Statement.Lift(_0024_00244820_002419432);
										StatementCollection statementCollection4 = (block2.Statements = StatementCollection.FromArray(array));
										result = (Yield(2, _0024_00244821_002419433) ? 1 : 0);
										break;
									}
								}
							}
							S540MacroBase.MError("INVALID_timerep", "invalid timerep", _0024ipos_002419421);
							goto case 2;
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

				internal MacroStatement _0024mc_002419436;

				internal RepsecMacro _0024self__002419437;

				public _0024ExpandGeneratorImpl_002419416(MacroStatement mc, RepsecMacro self_)
				{
					_0024mc_002419436 = mc;
					_0024self__002419437 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419436, _0024self__002419437);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419416(mc, this);
			}
		}

		[Serializable]
		public class SceneMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419438 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal MacroStatement _0024_0024match_00241822_002419439;

					internal MacroStatement _0024_0024match_00241823_002419440;

					internal ReferenceExpression _0024_0024match_00241824_002419441;

					internal string _0024sname_002419442;

					internal Block _0024___item_002419443;

					internal MacroStatement _0024_0024match_00241825_002419444;

					internal StringLiteralExpression _0024_0024match_00241826_002419445;

					internal string _0024ipos_002419446;

					internal Block _0024___item_002419447;

					internal IEnumerator<Block> _0024_0024iterator_002413755_002419448;

					internal IEnumerator<Block> _0024_0024iterator_002413756_002419449;

					internal MacroStatement _0024mc_002419450;

					public _0024(MacroStatement mc)
					{
						_0024mc_002419450 = mc;
					}

					public override bool MoveNext()
					{
						bool flag;
						try
						{
							switch (_state)
							{
							default:
								_0024_0024match_00241822_002419439 = _0024mc_002419450;
								if (_0024_0024match_00241822_002419439 is MacroStatement)
								{
									MacroStatement macroStatement = (_0024_0024match_00241823_002419440 = _0024_0024match_00241822_002419439);
									if (true && _0024_0024match_00241823_002419440.Name == "scene" && 1 == ((ICollection)_0024_0024match_00241823_002419440.Arguments).Count && _0024_0024match_00241823_002419440.Arguments[0] is ReferenceExpression)
									{
										ReferenceExpression referenceExpression = (_0024_0024match_00241824_002419441 = (ReferenceExpression)_0024_0024match_00241823_002419440.Arguments[0]);
										if (true)
										{
											string text = (_0024sname_002419442 = _0024_0024match_00241824_002419441.Name);
											if (true)
											{
												_0024_0024iterator_002413755_002419448 = S540MacroBase.SceneInstruction(_0024sname_002419442, _0024mc_002419450).GetEnumerator();
												_state = 2;
												goto case 3;
											}
										}
									}
								}
								if (_0024_0024match_00241822_002419439 is MacroStatement)
								{
									MacroStatement macroStatement2 = (_0024_0024match_00241825_002419444 = _0024_0024match_00241822_002419439);
									if (true && _0024_0024match_00241825_002419444.Name == "scene" && 1 == ((ICollection)_0024_0024match_00241825_002419444.Arguments).Count && _0024_0024match_00241825_002419444.Arguments[0] is StringLiteralExpression)
									{
										StringLiteralExpression stringLiteralExpression = (_0024_0024match_00241826_002419445 = (StringLiteralExpression)_0024_0024match_00241825_002419444.Arguments[0]);
										if (true)
										{
											string text2 = (_0024sname_002419442 = _0024_0024match_00241826_002419445.Value);
											if (true)
											{
												_0024ipos_002419446 = S540MacroBase.SrcPosInfo(_0024mc_002419450);
												_0024_0024iterator_002413756_002419449 = S540MacroBase.SceneInstruction(_0024sname_002419442, _0024mc_002419450).GetEnumerator();
												_state = 4;
												goto case 5;
											}
										}
									}
								}
								S540MacroBase.MError("INVALID_scene", "invalid loop usage", _0024ipos_002419446);
								break;
							case 3:
								if (_0024_0024iterator_002413755_002419448.MoveNext())
								{
									_0024___item_002419443 = _0024_0024iterator_002413755_002419448.Current;
									flag = Yield(3, _0024___item_002419443);
									goto IL_02b2;
								}
								_state = 1;
								_0024ensure2();
								break;
							case 5:
								if (_0024_0024iterator_002413756_002419449.MoveNext())
								{
									_0024___item_002419447 = _0024_0024iterator_002413756_002419449.Current;
									flag = Yield(5, _0024___item_002419447);
									goto IL_02b2;
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
						goto IL_02b3;
						IL_02b2:
						result = (flag ? 1 : 0);
						goto IL_02b3;
						IL_02b3:
						return (byte)result != 0;
					}

					private void _0024ensure2()
					{
						_0024_0024iterator_002413755_002419448.Dispose();
					}

					private void _0024ensure4()
					{
						_0024_0024iterator_002413756_002419449.Dispose();
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

				internal MacroStatement _0024mc_002419451;

				public _0024ExpandGeneratorImpl_002419438(MacroStatement mc)
				{
					_0024mc_002419451 = mc;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419451);
				}
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419438(mc);
			}
		}

		[Serializable]
		public class CaseloopMacro : S540MacroBase
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024ExpandGeneratorImpl_002419452 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
			{
				[Serializable]
				[CompilerGenerated]
				internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
				{
					internal string _0024ipos_002419453;

					internal Block _0024owBlock_002419454;

					internal Block _0024etBlock_002419455;

					internal Block _0024whileBody_002419456;

					internal ReferenceExpression _0024t1_002419457;

					internal Statement _0024s_002419458;

					internal ExpressionStatement _0024es_002419459;

					internal MethodInvocationExpression _0024minv_002419460;

					internal ReferenceExpression _0024target_002419461;

					internal ExpressionCollection _0024args_002419462;

					internal Expression _0024condexp_002419463;

					internal Block _0024block_002419464;

					internal BoolLiteralExpression _0024_00244822_002419465;

					internal BinaryExpression _0024_00244823_002419466;

					internal Block _0024_00244824_002419467;

					internal IfStatement _0024_00244825_002419468;

					internal IfStatement _0024b_002419469;

					internal string _0024kw_002419470;

					internal Block _0024_00244826_002419471;

					internal IfStatement _0024_00244827_002419472;

					internal ReferenceExpression _0024ev_002419473;

					internal ReferenceExpression _0024_00244828_002419474;

					internal StringLiteralExpression _0024_00244829_002419475;

					internal MethodInvocationExpression _0024_00244830_002419476;

					internal BoolLiteralExpression _0024_00244831_002419477;

					internal BoolLiteralExpression _0024_00244832_002419478;

					internal BinaryExpression _0024_00244833_002419479;

					internal Block _0024_00244834_002419480;

					internal WhileStatement _0024_00244835_002419481;

					internal Block _0024_00244836_002419482;

					internal IEnumerator<Statement> _0024_0024iterator_002413757_002419483;

					internal MacroStatement _0024mc_002419484;

					internal CaseloopMacro _0024self__002419485;

					public _0024(MacroStatement mc, CaseloopMacro self_)
					{
						_0024mc_002419484 = mc;
						_0024self__002419485 = self_;
					}

					public override bool MoveNext()
					{
						int result;
						switch (_state)
						{
						default:
						{
							_0024ipos_002419453 = S540MacroBase.SrcPosInfo(_0024mc_002419484);
							_0024owBlock_002419454 = null;
							_0024etBlock_002419455 = null;
							_0024whileBody_002419456 = new Block();
							_0024t1_002419457 = new ReferenceExpression(_0024self__002419485.CC.GetUniqueName("s540", "caseloop"));
							_0024_0024iterator_002413757_002419483 = _0024mc_002419484.Body.Statements.GetEnumerator();
							try
							{
								while (_0024_0024iterator_002413757_002419483.MoveNext())
								{
									_0024s_002419458 = _0024_0024iterator_002413757_002419483.Current;
									_0024es_002419459 = _0024s_002419458 as ExpressionStatement;
									if (_0024es_002419459 == null)
									{
										throw new AssertionFailedException(new StringBuilder("not allowed(1) '").Append(_0024s_002419458.ToCodeString()).Append("' in caseloop.").ToString());
									}
									_0024minv_002419460 = _0024es_002419459.Expression as MethodInvocationExpression;
									if (_0024minv_002419460 == null)
									{
										throw new AssertionFailedException(new StringBuilder("not allowed(2) '").Append(_0024es_002419459.ToCodeString()).ToString());
									}
									_0024target_002419461 = _0024minv_002419460.Target as ReferenceExpression;
									if (_0024target_002419461 == null)
									{
										throw new AssertionFailedException(new StringBuilder("not allowed(3) '").Append(_0024target_002419461.ToCodeString()).ToString());
									}
									_0024args_002419462 = _0024minv_002419460.Arguments;
									if (((ICollection)_0024args_002419462).Count == 2)
									{
										if (!(_0024target_002419461.Name == "when"))
										{
											throw new AssertionFailedException(new StringBuilder("not allowed(4) '").Append(_0024target_002419461.ToCodeString()).ToString());
										}
										_0024condexp_002419463 = _0024args_002419462[0];
										_0024block_002419464 = toBlock(_0024args_002419462[1]);
										IfStatement ifStatement = (_0024_00244825_002419468 = new IfStatement(LexicalInfo.Empty));
										Expression expression2 = (_0024_00244825_002419468.Condition = Expression.Lift(_0024condexp_002419463));
										IfStatement ifStatement2 = _0024_00244825_002419468;
										Block block = (_0024_00244824_002419467 = new Block(LexicalInfo.Empty));
										Block block2 = _0024_00244824_002419467;
										Statement[] array = new Statement[2];
										BinaryExpression binaryExpression = (_0024_00244823_002419466 = new BinaryExpression(LexicalInfo.Empty));
										BinaryOperatorType binaryOperatorType2 = (_0024_00244823_002419466.Operator = BinaryOperatorType.Assign);
										Expression expression4 = (_0024_00244823_002419466.Left = Expression.Lift(_0024t1_002419457));
										BinaryExpression binaryExpression2 = _0024_00244823_002419466;
										BoolLiteralExpression boolLiteralExpression = (_0024_00244822_002419465 = new BoolLiteralExpression(LexicalInfo.Empty));
										bool flag2 = (_0024_00244822_002419465.Value = false);
										Expression expression6 = (binaryExpression2.Right = _0024_00244822_002419465);
										array[0] = Statement.Lift(_0024_00244823_002419466);
										array[1] = Statement.Lift(Statement.Lift(_0024block_002419464));
										StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
										Block block4 = (ifStatement2.TrueBlock = _0024_00244824_002419467);
										_0024b_002419469 = _0024_00244825_002419468;
										_0024whileBody_002419456.Add(_0024b_002419469);
										continue;
									}
									if (((ICollection)_0024args_002419462).Count == 1)
									{
										_0024kw_002419470 = _0024target_002419461.Name;
										if (_0024kw_002419470 == "otherwise")
										{
											if (_0024owBlock_002419454 != null)
											{
												throw new AssertionFailedException("not allowed 2 or more otherwise");
											}
											_0024owBlock_002419454 = toBlock(_0024args_002419462[0]);
											continue;
										}
										if (_0024kw_002419470 == "everytime")
										{
											if (_0024etBlock_002419455 != null)
											{
												throw new AssertionFailedException("not allowed 2 or more everytime");
											}
											_0024etBlock_002419455 = toBlock(_0024args_002419462[0]);
											continue;
										}
										throw new Exception(new StringBuilder("invalid '").Append(_0024kw_002419470).Append("' -- may be otherwise/everytime ?").ToString());
									}
									throw new Exception(new StringBuilder("not allowed(7) '").Append(_0024target_002419461).Append("'").ToString());
								}
							}
							finally
							{
								_0024_0024iterator_002413757_002419483.Dispose();
							}
							if (_0024owBlock_002419454 != null)
							{
								IfStatement ifStatement3 = (_0024_00244827_002419472 = new IfStatement(LexicalInfo.Empty));
								Expression expression8 = (_0024_00244827_002419472.Condition = Expression.Lift(_0024t1_002419457));
								IfStatement ifStatement4 = _0024_00244827_002419472;
								Block block5 = (_0024_00244826_002419471 = new Block(LexicalInfo.Empty));
								StatementCollection statementCollection4 = (_0024_00244826_002419471.Statements = StatementCollection.FromArray(Statement.Lift(Statement.Lift(_0024owBlock_002419454))));
								Block block7 = (ifStatement4.TrueBlock = _0024_00244826_002419471);
								_0024b_002419469 = _0024_00244827_002419472;
								_0024whileBody_002419456.Add(_0024b_002419469);
							}
							if (_0024etBlock_002419455 != null)
							{
								_0024whileBody_002419456.Add(_0024etBlock_002419455);
							}
							_0024ev_002419473 = new ReferenceExpression("$CUR_EXEC$");
							Block block8 = (_0024_00244836_002419482 = new Block(LexicalInfo.Empty));
							Block block9 = _0024_00244836_002419482;
							Statement[] array2 = new Statement[2];
							MethodInvocationExpression methodInvocationExpression = (_0024_00244830_002419476 = new MethodInvocationExpression(LexicalInfo.Empty));
							MethodInvocationExpression methodInvocationExpression2 = _0024_00244830_002419476;
							ReferenceExpression referenceExpression = (_0024_00244828_002419474 = new ReferenceExpression(LexicalInfo.Empty));
							string text2 = (_0024_00244828_002419474.Name = "dtrace");
							Expression expression10 = (methodInvocationExpression2.Target = _0024_00244828_002419474);
							MethodInvocationExpression methodInvocationExpression3 = _0024_00244830_002419476;
							Expression[] obj = new Expression[3]
							{
								Expression.Lift(_0024ev_002419473),
								Expression.Lift(_0024ipos_002419453),
								null
							};
							StringLiteralExpression stringLiteralExpression = (_0024_00244829_002419475 = new StringLiteralExpression(LexicalInfo.Empty));
							string text4 = (_0024_00244829_002419475.Value = "repsec命令");
							obj[2] = _0024_00244829_002419475;
							ExpressionCollection expressionCollection2 = (methodInvocationExpression3.Arguments = ExpressionCollection.FromArray(obj));
							array2[0] = Statement.Lift(_0024_00244830_002419476);
							WhileStatement whileStatement = (_0024_00244835_002419481 = new WhileStatement(LexicalInfo.Empty));
							WhileStatement whileStatement2 = _0024_00244835_002419481;
							BoolLiteralExpression boolLiteralExpression2 = (_0024_00244831_002419477 = new BoolLiteralExpression(LexicalInfo.Empty));
							bool flag4 = (_0024_00244831_002419477.Value = true);
							Expression expression12 = (whileStatement2.Condition = _0024_00244831_002419477);
							WhileStatement whileStatement3 = _0024_00244835_002419481;
							Block block10 = (_0024_00244834_002419480 = new Block(LexicalInfo.Empty));
							Block block11 = _0024_00244834_002419480;
							Statement[] array3 = new Statement[3];
							BinaryExpression binaryExpression3 = (_0024_00244833_002419479 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType4 = (_0024_00244833_002419479.Operator = BinaryOperatorType.Assign);
							Expression expression14 = (_0024_00244833_002419479.Left = Expression.Lift(_0024t1_002419457));
							BinaryExpression binaryExpression4 = _0024_00244833_002419479;
							BoolLiteralExpression boolLiteralExpression3 = (_0024_00244832_002419478 = new BoolLiteralExpression(LexicalInfo.Empty));
							bool flag6 = (_0024_00244832_002419478.Value = true);
							Expression expression16 = (binaryExpression4.Right = _0024_00244832_002419478);
							array3[0] = Statement.Lift(_0024_00244833_002419479);
							array3[1] = Statement.Lift(Statement.Lift(_0024whileBody_002419456));
							array3[2] = Statement.Lift(new YieldStatement(LexicalInfo.Empty));
							StatementCollection statementCollection6 = (block11.Statements = StatementCollection.FromArray(array3));
							Block block13 = (whileStatement3.Block = _0024_00244834_002419480);
							array2[1] = Statement.Lift(_0024_00244835_002419481);
							StatementCollection statementCollection8 = (block9.Statements = StatementCollection.FromArray(array2));
							result = (Yield(2, _0024_00244836_002419482) ? 1 : 0);
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

				internal MacroStatement _0024mc_002419486;

				internal CaseloopMacro _0024self__002419487;

				public _0024ExpandGeneratorImpl_002419452(MacroStatement mc, CaseloopMacro self_)
				{
					_0024mc_002419486 = mc;
					_0024self__002419487 = self_;
				}

				public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
				{
					return new _0024(_0024mc_002419486, _0024self__002419487);
				}
			}

			public static Block toBlock(Expression blockExp)
			{
				if (!(blockExp is BlockExpression { Body: var body }))
				{
					throw new AssertionFailedException(new StringBuilder("not allowed(5-a) '").Append(blockExp.ToCodeString()).Append("'").ToString());
				}
				if (body == null)
				{
					throw new AssertionFailedException("no block");
				}
				return body;
			}

			protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
			{
				return new _0024ExpandGeneratorImpl_002419452(mc, this);
			}
		}

		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024ExpandGeneratorImpl_002419232 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
			{
				internal MacroStatement _0024_0024match_00241790_002419233;

				internal MacroStatement _0024_0024match_00241791_002419234;

				internal ReferenceExpression _0024_0024match_00241792_002419235;

				internal string _0024stateName_002419236;

				internal Block _0024sbody_002419237;

				internal Method _0024b_002419238;

				internal Method _0024b2_002419239;

				internal MacroStatement _0024_0024match_00241793_002419240;

				internal MethodInvocationExpression _0024_0024match_00241794_002419241;

				internal Expression _0024sref_002419242;

				internal ExpressionCollection _0024args_002419243;

				internal Method _0024idf_002419244;

				internal Method _0024idf2_002419245;

				internal string _0024s_002419246;

				internal Expression _0024a_002419247;

				internal string _0024ipos_002419248;

				internal Block _0024goinst_002419249;

				internal ReferenceExpression _0024ev_002419250;

				internal BinaryExpression _0024_00244749_002419251;

				internal Block _0024_00244750_002419252;

				internal Method _0024_00244751_002419253;

				internal IEnumerator<Expression> _0024_0024iterator_002413752_002419254;

				internal MacroStatement _0024mc_002419255;

				internal SMacro _0024self__002419256;

				public _0024(MacroStatement mc, SMacro self_)
				{
					_0024mc_002419255 = mc;
					_0024self__002419256 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024_0024match_00241790_002419233 = _0024mc_002419255;
						if (_0024_0024match_00241790_002419233 is MacroStatement)
						{
							MacroStatement macroStatement = (_0024_0024match_00241791_002419234 = _0024_0024match_00241790_002419233);
							if (true && _0024_0024match_00241791_002419234.Name == "S" && 1 == ((ICollection)_0024_0024match_00241791_002419234.Arguments).Count && _0024_0024match_00241791_002419234.Arguments[0] is ReferenceExpression)
							{
								ReferenceExpression referenceExpression = (_0024_0024match_00241792_002419235 = (ReferenceExpression)_0024_0024match_00241791_002419234.Arguments[0]);
								if (true)
								{
									string text = (_0024stateName_002419236 = _0024_0024match_00241792_002419235.Name);
									if (true)
									{
										_0024sbody_002419237 = StateBodyExpander.Expand(_0024mc_002419255.Body, _0024self__002419256.CC);
										_0024sbody_002419237 = S540MacroBase.InsertFullTraceCode(_0024sbody_002419237);
										_0024b_002419238 = S540MacroBase.InvocationToDefinition(new ReferenceExpression(_0024stateName_002419236));
										_0024b_002419238.Body = _0024self__002419256.stateYieldingCode(_0024stateName_002419236, new ExpressionCollection());
										result = (Yield(2, _0024b_002419238) ? 1 : 0);
										break;
									}
								}
							}
						}
						if (_0024_0024match_00241790_002419233 is MacroStatement)
						{
							MacroStatement macroStatement2 = (_0024_0024match_00241793_002419240 = _0024_0024match_00241790_002419233);
							if (true && _0024_0024match_00241793_002419240.Name == "S" && 1 == ((ICollection)_0024_0024match_00241793_002419240.Arguments).Count && _0024_0024match_00241793_002419240.Arguments[0] is MethodInvocationExpression)
							{
								MethodInvocationExpression methodInvocationExpression = (_0024_0024match_00241794_002419241 = (MethodInvocationExpression)_0024_0024match_00241793_002419240.Arguments[0]);
								if (true)
								{
									Expression expression = (_0024sref_002419242 = _0024_0024match_00241794_002419241.Target);
									if (true)
									{
										ExpressionCollection expressionCollection = (_0024args_002419243 = _0024_0024match_00241794_002419241.Arguments);
										if (true)
										{
											_0024sbody_002419237 = StateBodyExpander.Expand(_0024mc_002419255.Body, _0024self__002419256.CC);
											_0024sbody_002419237 = S540MacroBase.InsertFullTraceCode(_0024sbody_002419237);
											_0024idf_002419244 = S540MacroBase.InvocationToDefinition(_0024sref_002419242, _0024args_002419243);
											_0024idf_002419244.Body = _0024self__002419256.stateYieldingCode((ReferenceExpression)_0024sref_002419242, _0024args_002419243);
											result = (Yield(4, _0024idf_002419244) ? 1 : 0);
											break;
										}
									}
								}
							}
						}
						_0024s_002419246 = string.Empty;
						_0024_0024iterator_002413752_002419254 = _0024mc_002419255.Arguments.GetEnumerator();
						try
						{
							while (_0024_0024iterator_002413752_002419254.MoveNext())
							{
								_0024a_002419247 = _0024_0024iterator_002413752_002419254.Current;
								_0024s_002419246 += ":" + _0024a_002419247.GetType();
							}
						}
						finally
						{
							_0024_0024iterator_002413752_002419254.Dispose();
						}
						_0024ipos_002419248 = S540MacroBase.SrcPosInfo(_0024mc_002419255);
						S540MacroBase.MError("S_DECLARATION", "S definition error:" + _0024s_002419246, _0024ipos_002419248);
						goto case 3;
					case 2:
						_0024b2_002419239 = S540MacroBase.InvocationToDefinition(new ReferenceExpression(_0024stateName_002419236), withBlockArgType: true);
						_0024b2_002419239.Body.Add(S540MacroBase.StateHeaderCode(_0024self__002419256.CC, _0024stateName_002419236, withDummyBlockArg: false));
						_0024b2_002419239.Body.Add(_0024sbody_002419237 as Block);
						result = (Yield(3, _0024b2_002419239) ? 1 : 0);
						break;
					case 4:
						_0024idf2_002419245 = S540MacroBase.InvocationToDefinition(_0024sref_002419242, _0024args_002419243, withBlockArgType: true);
						_0024idf2_002419245.Body.Add(S540MacroBase.StateHeaderCode(_0024self__002419256.CC, (ReferenceExpression)_0024sref_002419242, withDummyBlockArg: false));
						_0024idf2_002419245.Body.Add(_0024sbody_002419237 as Block);
						result = (Yield(5, _0024idf2_002419245) ? 1 : 0);
						break;
					case 3:
					case 5:
						if (_0024stateName_002419236 == "init")
						{
							_0024ipos_002419248 = S540MacroBase.SrcPosInfo(_0024mc_002419255);
							if (string.IsNullOrEmpty(_0024stateName_002419236))
							{
								S540MacroBase.MError("INIT_S_WITH_ARGS", "initial state cannot have arguments", _0024ipos_002419248);
							}
							_0024goinst_002419249 = S540MacroBase.GoInstruction(_0024self__002419256.CC, _0024stateName_002419236, _0024mc_002419255);
							_0024ev_002419250 = new ReferenceExpression("$CUR_EXEC$");
							Method method = (_0024_00244751_002419253 = new Method(LexicalInfo.Empty));
							TypeMemberModifiers typeMemberModifiers2 = (_0024_00244751_002419253.Modifiers = TypeMemberModifiers.Protected | TypeMemberModifiers.Override);
							string text3 = (_0024_00244751_002419253.Name = "startInitialState");
							Method method2 = _0024_00244751_002419253;
							Block block = (_0024_00244750_002419252 = new Block(LexicalInfo.Empty));
							Block block2 = _0024_00244750_002419252;
							Statement[] array = new Statement[2];
							BinaryExpression binaryExpression = (_0024_00244749_002419251 = new BinaryExpression(LexicalInfo.Empty));
							BinaryOperatorType binaryOperatorType2 = (_0024_00244749_002419251.Operator = BinaryOperatorType.Assign);
							Expression expression3 = (_0024_00244749_002419251.Left = Expression.Lift(_0024ev_002419250));
							Expression expression5 = (_0024_00244749_002419251.Right = new NullLiteralExpression(LexicalInfo.Empty));
							array[0] = Statement.Lift(_0024_00244749_002419251);
							array[1] = Statement.Lift(Statement.Lift(_0024goinst_002419249));
							StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array));
							Block block4 = (method2.Body = _0024_00244750_002419252);
							result = (Yield(6, _0024_00244751_002419253) ? 1 : 0);
							break;
						}
						goto case 6;
					case 6:
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal MacroStatement _0024mc_002419257;

			internal SMacro _0024self__002419258;

			public _0024ExpandGeneratorImpl_002419232(MacroStatement mc, SMacro self_)
			{
				_0024mc_002419257 = mc;
				_0024self__002419258 = self_;
			}

			public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
			{
				return new _0024(_0024mc_002419257, _0024self__002419258);
			}
		}

		private Block stateYieldingCode(ReferenceExpression sname, ExpressionCollection fargs)
		{
			return stateYieldingCode(sname.Name, fargs);
		}

		private Block stateYieldingCode(string sname, ExpressionCollection fargs)
		{
			ExpressionCollection expressionCollection = new ExpressionCollection();
			IEnumerator<Expression> enumerator = fargs.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Expression current = enumerator.Current;
					Expression expression = current;
					if (expression is ReferenceExpression)
					{
						expressionCollection.Add(current);
						continue;
					}
					if (expression is TryCastExpression)
					{
						TryCastExpression tryCastExpression = (TryCastExpression)expression;
						if (true)
						{
							Expression target = tryCastExpression.Target;
							if (true)
							{
								expressionCollection.Add(target);
								continue;
							}
						}
					}
					throw new Exception("CALL_NISTAKE: formal argument type=" + current.GetType());
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			expressionCollection.Add(new NullLiteralExpression());
			MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression();
			Expression expression3 = (methodInvocationExpression.Target = S540MacroBase.FullStateRef(sname));
			ExpressionCollection expressionCollection3 = (methodInvocationExpression.Arguments = expressionCollection);
			MethodInvocationExpression e = methodInvocationExpression;
			ReferenceExpression e2 = new ReferenceExpression(CC.GetUniqueName("s540", "ycode"));
			Block block = new Block(LexicalInfo.Empty);
			Statement[] array = new Statement[2];
			BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
			BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
			Expression expression5 = (binaryExpression.Left = Expression.Lift(e2));
			Expression expression7 = (binaryExpression.Right = Expression.Lift(e));
			array[0] = Statement.Lift(binaryExpression);
			IfStatement ifStatement = new IfStatement(LexicalInfo.Empty);
			BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
			BinaryOperatorType binaryOperatorType4 = (binaryExpression2.Operator = BinaryOperatorType.Inequality);
			Expression expression9 = (binaryExpression2.Left = Expression.Lift(e2));
			Expression expression11 = (binaryExpression2.Right = new NullLiteralExpression(LexicalInfo.Empty));
			Expression expression13 = (ifStatement.Condition = binaryExpression2);
			Block block2 = new Block(LexicalInfo.Empty);
			Statement[] array2 = new Statement[1];
			MacroStatement macroStatement = new MacroStatement(LexicalInfo.Empty);
			string text2 = (macroStatement.Name = "yieldAll");
			ExpressionCollection expressionCollection5 = (macroStatement.Arguments = ExpressionCollection.FromArray(Expression.Lift(e2)));
			Block block4 = (macroStatement.Body = new Block(LexicalInfo.Empty));
			array2[0] = Statement.Lift(macroStatement);
			StatementCollection statementCollection2 = (block2.Statements = StatementCollection.FromArray(array2));
			Block block6 = (ifStatement.TrueBlock = block2);
			array[1] = Statement.Lift(ifStatement);
			StatementCollection statementCollection4 = (block.Statements = StatementCollection.FromArray(array));
			return block.ToBlock();
		}

		protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
		{
			return new _0024ExpandGeneratorImpl_002419232(mc, this);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002419221 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal ExpressionCollection _0024args_002419222;

			internal int _0024nargs_002419223;

			internal string _0024className_002419224;

			internal SimpleTypeReference _0024_00244725_002419225;

			internal ClassDefinition _0024_00244726_002419226;

			internal ClassDefinition _0024decl_002419227;

			internal ReferenceExpression _0024r_002419228;

			internal ClassDefinition _0024_00244727_002419229;

			internal MacroStatement _0024mc_002419230;

			public _0024(MacroStatement mc)
			{
				_0024mc_002419230 = mc;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024args_002419222 = _0024mc_002419230.Arguments;
					_0024nargs_002419223 = ((ICollection)_0024args_002419222).Count;
					_0024className_002419224 = Path.GetFileNameWithoutExtension(_0024mc_002419230.Body.LexicalInfo.FileName);
					if (_0024nargs_002419223 == 0)
					{
						ClassDefinition classDefinition = (_0024_00244726_002419226 = new ClassDefinition(LexicalInfo.Empty));
						string text2 = (_0024_00244726_002419226.Name = "$");
						TypeMemberCollection typeMemberCollection2 = (_0024_00244726_002419226.Members = TypeMemberCollection.FromArray(TypeMember.Lift(_0024mc_002419230.Body)));
						ClassDefinition classDefinition2 = _0024_00244726_002419226;
						TypeReference[] array = new TypeReference[1];
						SimpleTypeReference simpleTypeReference = (_0024_00244725_002419225 = new SimpleTypeReference(LexicalInfo.Empty));
						bool flag2 = (_0024_00244725_002419225.IsPointer = false);
						string text4 = (_0024_00244725_002419225.Name = "S540.S540Base");
						array[0] = _0024_00244725_002419225;
						TypeReferenceCollection typeReferenceCollection2 = (classDefinition2.BaseTypes = TypeReferenceCollection.FromArray(array));
						string text6 = (_0024_00244726_002419226.Name = CodeSerializer.LiftName(_0024className_002419224));
						_0024decl_002419227 = _0024_00244726_002419226;
						S540MacroBase.WriteCodeToFile(new StringBuilder("../").Append(_0024className_002419224).Append(".s540").ToString(), _0024decl_002419227);
						result = (Yield(2, _0024decl_002419227) ? 1 : 0);
						break;
					}
					if (_0024nargs_002419223 == 1)
					{
						_0024r_002419228 = _0024args_002419222[0] as ReferenceExpression;
						if (_0024r_002419228 == null)
						{
							S540MacroBase.MError("INVALID_CLASSNAME", "mc class must inherits 'S540Base' class." + _0024args_002419222[0].ToCodeString() + " is not valid usage.");
						}
						ClassDefinition classDefinition3 = (_0024_00244727_002419229 = new ClassDefinition(LexicalInfo.Empty));
						string text8 = (_0024_00244727_002419229.Name = "$");
						TypeMemberCollection typeMemberCollection4 = (_0024_00244727_002419229.Members = TypeMemberCollection.FromArray(TypeMember.Lift(_0024mc_002419230.Body)));
						TypeReferenceCollection typeReferenceCollection4 = (_0024_00244727_002419229.BaseTypes = TypeReferenceCollection.FromArray(TypeReference.Lift(_0024r_002419228)));
						string text10 = (_0024_00244727_002419229.Name = CodeSerializer.LiftName(_0024className_002419224));
						_0024decl_002419227 = _0024_00244727_002419229;
						S540MacroBase.WriteCodeToFile(new StringBuilder("../").Append(_0024className_002419224).Append(".s540").ToString(), _0024decl_002419227);
						result = (Yield(3, _0024decl_002419227) ? 1 : 0);
						break;
					}
					S540MacroBase.MError("INVALID_CLASSNAME", "must be \"mc:\" or \"mc baseclass\".");
					goto case 2;
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

		internal MacroStatement _0024mc_002419231;

		public _0024ExpandGeneratorImpl_002419221(MacroStatement mc)
		{
			_0024mc_002419231 = mc;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024mc_002419231);
		}
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement mc)
	{
		return new _0024ExpandGeneratorImpl_002419221(mc);
	}
}
