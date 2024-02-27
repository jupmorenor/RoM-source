using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_AndroidDeviceMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_AndroidDeviceMacro()
	{
	}

	public Ifdef_AndroidDeviceMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_AndroidDevice)
	{
		if (ifdef_AndroidDevice == null)
		{
			throw new ArgumentNullException("ifdef_AndroidDevice");
		}
		__macro = ifdef_AndroidDevice;
		return (!Context.Parameters.Defines.ContainsKey("UNITY_ANDROID") || Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_AndroidDevice.Block);
	}
}
