using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_not_AndroidDeviceMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_not_AndroidDeviceMacro()
	{
	}

	public Ifdef_not_AndroidDeviceMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_not_AndroidDevice)
	{
		if (ifdef_not_AndroidDevice == null)
		{
			throw new ArgumentNullException("ifdef_not_AndroidDevice");
		}
		__macro = ifdef_not_AndroidDevice;
		return (Context.Parameters.Defines.ContainsKey("UNITY_ANDROID") && !Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_not_AndroidDevice.Block);
	}
}
