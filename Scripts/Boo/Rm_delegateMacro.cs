using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Rm_delegateMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424403 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024132_002424404;

			internal MacroStatement _0024_0024match_0024133_002424405;

			internal Expression _0024expose_002424406;

			internal Expression _0024callback_002424407;

			internal ReferenceExpression _0024_00246510_002424408;

			internal MemberReferenceExpression _0024_00246511_002424409;

			internal MemberReferenceExpression _0024_00246512_002424410;

			internal MethodInvocationExpression _0024_00246513_002424411;

			internal BinaryExpression _0024_00246514_002424412;

			internal MacroStatement _0024rm_delegate_002424413;

			internal Rm_delegateMacro _0024self__002424414;

			public _0024(MacroStatement rm_delegate, Rm_delegateMacro self_)
			{
				_0024rm_delegate_002424413 = rm_delegate;
				_0024self__002424414 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024rm_delegate_002424413 == null)
					{
						throw new ArgumentNullException("rm_delegate");
					}
					_0024self__002424414.__macro = _0024rm_delegate_002424413;
					_0024_0024match_0024132_002424404 = _0024rm_delegate_002424413;
					if (_0024_0024match_0024132_002424404 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024133_002424405 = _0024_0024match_0024132_002424404);
						if (true && _0024_0024match_0024133_002424405.Name == "rm_delegate" && 2 == ((ICollection)_0024_0024match_0024133_002424405.Arguments).Count)
						{
							Expression expression = (_0024expose_002424406 = _0024_0024match_0024133_002424405.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024callback_002424407 = _0024_0024match_0024133_002424405.Arguments[1]);
								if (true)
								{
									BinaryExpression binaryExpression = (_0024_00246514_002424412 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00246514_002424412.Operator = BinaryOperatorType.Assign);
									Expression expression4 = (_0024_00246514_002424412.Left = Expression.Lift(_0024expose_002424406));
									BinaryExpression binaryExpression2 = _0024_00246514_002424412;
									MethodInvocationExpression methodInvocationExpression = (_0024_00246513_002424411 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression2 = _0024_00246513_002424411;
									MemberReferenceExpression memberReferenceExpression = (_0024_00246512_002424410 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text2 = (_0024_00246512_002424410.Name = "Remove");
									MemberReferenceExpression memberReferenceExpression2 = _0024_00246512_002424410;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00246511_002424409 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00246511_002424409.Name = "Delegate");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00246511_002424409;
									ReferenceExpression referenceExpression = (_0024_00246510_002424408 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00246510_002424408.Name = "System");
									Expression expression6 = (memberReferenceExpression4.Target = _0024_00246510_002424408);
									Expression expression8 = (memberReferenceExpression2.Target = _0024_00246511_002424409);
									Expression expression10 = (methodInvocationExpression2.Target = _0024_00246512_002424410);
									ExpressionCollection expressionCollection2 = (_0024_00246513_002424411.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024callback_002424407), Expression.Lift(_0024expose_002424406)));
									Expression expression12 = (binaryExpression2.Right = _0024_00246513_002424411);
									result = (Yield(2, _0024_00246514_002424412) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new Exception("rm_delegate macro error: ");
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

		internal MacroStatement _0024rm_delegate_002424415;

		internal Rm_delegateMacro _0024self__002424416;

		public _0024ExpandGeneratorImpl_002424403(MacroStatement rm_delegate, Rm_delegateMacro self_)
		{
			_0024rm_delegate_002424415 = rm_delegate;
			_0024self__002424416 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024rm_delegate_002424415, _0024self__002424416);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Rm_delegateMacro()
	{
	}

	public Rm_delegateMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement rm_delegate)
	{
		return new _0024ExpandGeneratorImpl_002424403(rm_delegate, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement rm_delegate)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'rm_delegate' is using. Read BOO-1077 for more info.");
	}
}
