using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Add_delegateMacro : LexicalInfoPreservingGeneratorMacro
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ExpandGeneratorImpl_002424389 : GenericGenerator<Boo.Lang.Compiler.Ast.Node>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Boo.Lang.Compiler.Ast.Node>, IEnumerator
		{
			internal MacroStatement _0024_0024match_0024130_002424390;

			internal MacroStatement _0024_0024match_0024131_002424391;

			internal Expression _0024expose_002424392;

			internal Expression _0024callback_002424393;

			internal ReferenceExpression _0024_00246505_002424394;

			internal MemberReferenceExpression _0024_00246506_002424395;

			internal MemberReferenceExpression _0024_00246507_002424396;

			internal MethodInvocationExpression _0024_00246508_002424397;

			internal BinaryExpression _0024_00246509_002424398;

			internal MacroStatement _0024add_delegate_002424399;

			internal Add_delegateMacro _0024self__002424400;

			public _0024(MacroStatement add_delegate, Add_delegateMacro self_)
			{
				_0024add_delegate_002424399 = add_delegate;
				_0024self__002424400 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024add_delegate_002424399 == null)
					{
						throw new ArgumentNullException("add_delegate");
					}
					_0024self__002424400.__macro = _0024add_delegate_002424399;
					_0024_0024match_0024130_002424390 = _0024add_delegate_002424399;
					if (_0024_0024match_0024130_002424390 is MacroStatement)
					{
						MacroStatement macroStatement = (_0024_0024match_0024131_002424391 = _0024_0024match_0024130_002424390);
						if (true && _0024_0024match_0024131_002424391.Name == "add_delegate" && 2 == ((ICollection)_0024_0024match_0024131_002424391.Arguments).Count)
						{
							Expression expression = (_0024expose_002424392 = _0024_0024match_0024131_002424391.Arguments[0]);
							if (true)
							{
								Expression expression2 = (_0024callback_002424393 = _0024_0024match_0024131_002424391.Arguments[1]);
								if (true)
								{
									BinaryExpression binaryExpression = (_0024_00246509_002424398 = new BinaryExpression(LexicalInfo.Empty));
									BinaryOperatorType binaryOperatorType2 = (_0024_00246509_002424398.Operator = BinaryOperatorType.Assign);
									Expression expression4 = (_0024_00246509_002424398.Left = Expression.Lift(_0024expose_002424392));
									BinaryExpression binaryExpression2 = _0024_00246509_002424398;
									MethodInvocationExpression methodInvocationExpression = (_0024_00246508_002424397 = new MethodInvocationExpression(LexicalInfo.Empty));
									MethodInvocationExpression methodInvocationExpression2 = _0024_00246508_002424397;
									MemberReferenceExpression memberReferenceExpression = (_0024_00246507_002424396 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text2 = (_0024_00246507_002424396.Name = "Combine");
									MemberReferenceExpression memberReferenceExpression2 = _0024_00246507_002424396;
									MemberReferenceExpression memberReferenceExpression3 = (_0024_00246506_002424395 = new MemberReferenceExpression(LexicalInfo.Empty));
									string text4 = (_0024_00246506_002424395.Name = "Delegate");
									MemberReferenceExpression memberReferenceExpression4 = _0024_00246506_002424395;
									ReferenceExpression referenceExpression = (_0024_00246505_002424394 = new ReferenceExpression(LexicalInfo.Empty));
									string text6 = (_0024_00246505_002424394.Name = "System");
									Expression expression6 = (memberReferenceExpression4.Target = _0024_00246505_002424394);
									Expression expression8 = (memberReferenceExpression2.Target = _0024_00246506_002424395);
									Expression expression10 = (methodInvocationExpression2.Target = _0024_00246507_002424396);
									ExpressionCollection expressionCollection2 = (_0024_00246508_002424397.Arguments = ExpressionCollection.FromArray(Expression.Lift(_0024callback_002424393), Expression.Lift(_0024expose_002424392)));
									Expression expression12 = (binaryExpression2.Right = _0024_00246508_002424397);
									result = (Yield(2, _0024_00246509_002424398) ? 1 : 0);
									break;
								}
							}
						}
					}
					throw new Exception("add_delegate macro error: ");
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

		internal MacroStatement _0024add_delegate_002424401;

		internal Add_delegateMacro _0024self__002424402;

		public _0024ExpandGeneratorImpl_002424389(MacroStatement add_delegate, Add_delegateMacro self_)
		{
			_0024add_delegate_002424401 = add_delegate;
			_0024self__002424402 = self_;
		}

		public override IEnumerator<Boo.Lang.Compiler.Ast.Node> GetEnumerator()
		{
			return new _0024(_0024add_delegate_002424401, _0024self__002424402);
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public Add_delegateMacro()
	{
	}

	public Add_delegateMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override IEnumerable<Boo.Lang.Compiler.Ast.Node> ExpandGeneratorImpl(MacroStatement add_delegate)
	{
		return new _0024ExpandGeneratorImpl_002424389(add_delegate, this);
	}

	[CompilerGenerated]
	protected override Statement ExpandImpl(MacroStatement add_delegate)
	{
		throw new NotImplementedException("Boo installed version is older than the new macro syntax 'add_delegate' is using. Read BOO-1077 for more info.");
	}
}
