using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class For_all_objsMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424372 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024120_002424373;

			internal MacroStatement _0024_0024match_0024121_002424374;

			internal TryCastExpression _0024_0024match_0024122_002424375;

			internal Expression _0024v_002424376;

			internal TypeReference _0024t_002424377;

			internal ReferenceExpression _0024rv_002424378;

			internal ForStatement _0024forstmt_002424379;

			internal MethodInvocationExpression _0024iterexp_002424380;

			internal ReferenceExpression _0024_00246471_002424381;

			internal MemberReferenceExpression _0024_00246472_002424382;

			internal MemberReferenceExpression _0024_00246473_002424383;

			internal TypeofExpression _0024_00246474_002424384;

			internal MacroStatement _0024for_all_objs_002424385;

			internal For_all_objsMacro _0024self__002424386;

			public _0024(MacroStatement for_all_objs, For_all_objsMacro self_)
			{
				_0024for_all_objs_002424385 = for_all_objs;
				_0024self__002424386 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024for_all_objs_002424385 == null)
					{
						throw new ArgumentNullException("for_all_objs");
					}
					_0024self__002424386.__macro = _0024for_all_objs_002424385;
					_0024_0024match_0024120_002424373 = _0024for_all_objs_002424385;
					if (_0024_0024match_0024120_002424373 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024121_002424374 = _0024_0024match_0024120_002424373);
						if (true && _0024_0024match_0024121_002424374.Name == "for_all_objs" && 1 == ((ICollection)_0024_0024match_0024121_002424374.Arguments).Count && _0024_0024match_0024121_002424374.Arguments[0] is TryCastExpression)
						{
							TryCastExpression tryCastExpression = (_0024_0024match_0024122_002424375 = (TryCastExpression)_0024_0024match_0024121_002424374.Arguments[0]);
							if (true)
							{
								Expression expression = (_0024v_002424376 = _0024_0024match_0024122_002424375.Target);
								if (true)
								{
									TypeReference typeReference = (_0024t_002424377 = _0024_0024match_0024122_002424375.Type);
									if (true)
									{
										_0024rv_002424378 = _0024v_002424376 as ReferenceExpression;
										if (_0024rv_002424378 == null)
										{
											throw new Exception(new StringBuilder("for_all_objs: '").Append(_0024v_002424376.ToCodeString()).Append("' is not variable name.").ToString());
										}
										_0024forstmt_002424379 = new ForStatement();
										_0024iterexp_002424380 = new MethodInvocationExpression();
										MethodInvocationExpression methodInvocationExpression = _0024iterexp_002424380;
										MemberReferenceExpression memberReferenceExpression = (_0024_00246473_002424383 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text2 = (_0024_00246473_002424383.Name = "FindObjectsOfType");
										MemberReferenceExpression memberReferenceExpression2 = _0024_00246473_002424383;
										MemberReferenceExpression memberReferenceExpression3 = (_0024_00246472_002424382 = new MemberReferenceExpression(LexicalInfo.Empty));
										string text4 = (_0024_00246472_002424382.Name = "Object");
										MemberReferenceExpression memberReferenceExpression4 = _0024_00246472_002424382;
										ReferenceExpression referenceExpression = (_0024_00246471_002424381 = new ReferenceExpression(LexicalInfo.Empty));
										string text6 = (_0024_00246471_002424381.Name = "UnityEngine");
										Expression expression3 = (memberReferenceExpression4.Target = _0024_00246471_002424381);
										Expression expression5 = (memberReferenceExpression2.Target = _0024_00246472_002424382);
										methodInvocationExpression.Target = Expression.Lift(_0024_00246473_002424383);
										ExpressionCollection arguments = _0024iterexp_002424380.Arguments;
										TypeofExpression typeofExpression = (_0024_00246474_002424384 = new TypeofExpression());
										TypeReference typeReference3 = (_0024_00246474_002424384.Type = _0024t_002424377);
										arguments.Add(_0024_00246474_002424384);
										_0024forstmt_002424379.Iterator = _0024iterexp_002424380;
										_0024forstmt_002424379.Declarations.Add(new Declaration(_0024rv_002424378.Name, _0024t_002424377));
										_0024forstmt_002424379.Block = _0024for_all_objs_002424385.Body;
										result = (Yield(2, _0024forstmt_002424379) ? 1 : 0);
										break;
									}
								}
							}
						}
					}
					throw new Exception("for_all_objs macro error: must be a form \"for_all_objs var as type\"");
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

		internal MacroStatement _0024for_all_objs_002424387;

		internal For_all_objsMacro _0024self__002424388;

		public _0024ExpandGeneratorImpl_002424372(MacroStatement for_all_objs, For_all_objsMacro self_)
		{
			_0024for_all_objs_002424387 = for_all_objs;
			_0024self__002424388 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024for_all_objs_002424387, _0024self__002424388);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public For_all_objsMacro()
	{
	}

	public For_all_objsMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement for_all_objs)
	{
		return new _0024ExpandGeneratorImpl_002424372(for_all_objs, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement for_all_objs)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'for_all_objs' is using. Read BOO-1077 for more info.");
	}
}
