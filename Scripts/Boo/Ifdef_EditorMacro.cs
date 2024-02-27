using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_EditorMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_EditorMacro()
	{
	}

	public Ifdef_EditorMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_Editor)
	{
		if (ifdef_Editor == null)
		{
			throw new ArgumentNullException("ifdef_Editor");
		}
		__macro = ifdef_Editor;
		return (!Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_Editor.Block);
	}
}
