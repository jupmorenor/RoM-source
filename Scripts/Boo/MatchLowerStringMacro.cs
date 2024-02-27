using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Runtime;

[Serializable]
public sealed class MatchLowerStringMacro : LexicalInfoPreservingMacro
{
	[Serializable]
	public sealed class CaseMacro : LexicalInfoPreservingMacro
	{
		[CompilerGenerated]
		private MacroStatement __macro;

		[CompilerGenerated]
		private MacroStatement _0024matchLowerString;

		[CompilerGenerated]
		private MacroStatement matchLowerString
		{
			get
			{
				if (_0024matchLowerString == null)
				{
					_0024matchLowerString = __macro.GetParentMacroByName("matchLowerString");
				}
				return _0024matchLowerString;
			}
		}

		public CaseMacro()
		{
		}

		public CaseMacro(CompilerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			base._002Ector(context);
		}

		protected override Statement ExpandImpl(MacroStatement @case)
		{
			if (@case == null)
			{
				throw new ArgumentNullException("case");
			}
			__macro = @case;
			if (!(@case.Arguments[0] is StringLiteralExpression))
			{
				throw new AssertionFailedException("matchLowerString macro only accept StringLiteral case");
			}
			string value = (@case.Arguments[0] as StringLiteralExpression).Value.ToLower();
			@case.Arguments[0] = new StringLiteralExpression(value);
			caseListFor(matchLowerString).Add(@case);
			return null;
		}
	}

	[Serializable]
	public sealed class OtherwiseMacro : LexicalInfoPreservingMacro
	{
		[CompilerGenerated]
		private MacroStatement __macro;

		[CompilerGenerated]
		private MacroStatement _0024matchLowerString;

		[CompilerGenerated]
		private MacroStatement matchLowerString
		{
			get
			{
				if (_0024matchLowerString == null)
				{
					_0024matchLowerString = __macro.GetParentMacroByName("matchLowerString");
				}
				return _0024matchLowerString;
			}
		}

		public OtherwiseMacro()
		{
		}

		public OtherwiseMacro(CompilerContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			base._002Ector(context);
		}

		protected override Statement ExpandImpl(MacroStatement otherwise)
		{
			if (otherwise == null)
			{
				throw new ArgumentNullException("otherwise");
			}
			__macro = otherwise;
			if (matchLowerString["otherwise"] is Boo.Lang.Compiler.Ast.Node node)
			{
				throw new AssertionFailedException(new StringBuilder("`otherwise' is already defined at: ").Append(node.LexicalInfo).ToString());
			}
			matchLowerString["otherwise"] = otherwise;
			return null;
		}
	}

	[CompilerGenerated]
	private MacroStatement __macro;

	public MatchLowerStringMacro()
	{
	}

	public MatchLowerStringMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement matchLowerString)
	{
		if (matchLowerString == null)
		{
			throw new ArgumentNullException("matchLowerString");
		}
		__macro = matchLowerString;
		Expression e = matchLowerString.Arguments[0];
		ReferenceExpression referenceExpression = new ReferenceExpression(Context.GetUniqueName("matchLowerString", "exp"));
		BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
		BinaryOperatorType binaryOperatorType2 = (binaryExpression.Operator = BinaryOperatorType.Assign);
		Expression expression2 = (binaryExpression.Left = Expression.Lift(referenceExpression));
		MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
		MemberReferenceExpression memberReferenceExpression = new MemberReferenceExpression(LexicalInfo.Empty);
		string text2 = (memberReferenceExpression.Name = "ToLower");
		Expression expression4 = (memberReferenceExpression.Target = Expression.Lift(e));
		Expression expression6 = (methodInvocationExpression.Target = memberReferenceExpression);
		Expression expression8 = (binaryExpression.Right = methodInvocationExpression);
		BinaryExpression expression9 = binaryExpression;
		matchLowerString.Arguments[0] = referenceExpression;
		if (((ICollection)matchLowerString.Body.Statements).Count != 0)
		{
			throw new AssertionFailedException(new StringBuilder("Only `case' or `otherwise' are allowed in `matchLowerString'. Offending statement at: ").Append(matchLowerString.Body.Statements[0].LexicalInfo).ToString());
		}
		if (((ICollection)caseListFor(matchLowerString)).Count == 0)
		{
			throw new AssertionFailedException("`matchLowerString' must contain at least one `case'");
		}
		Assembly assembly = Assembly.Load("Boo.Lang.PatternMatching");
		Type type = assembly.GetType("Boo.Lang.PatternMatching.Impl.MatchExpansion", throwOnError: true);
		object obj = Activator.CreateInstance(type, matchLowerString);
		FieldInfo field = type.GetField("Value");
		Statement statement = field.GetValue(obj) as Statement;
		Block block = statement.ToBlock();
		block.Insert(0, expression9);
		return block;
	}

	public static List caseListFor(MacroStatement node)
	{
		object obj = node["caseList"];
		if (!(obj is List))
		{
			obj = RuntimeServices.Coerce(obj, typeof(List));
		}
		List list = (List)obj;
		if (list == null)
		{
			list = (List)(node["caseList"] = new List());
		}
		return list;
	}
}
