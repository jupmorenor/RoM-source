using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_iOSDeviceMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_iOSDeviceMacro()
	{
	}

	public Ifdef_iOSDeviceMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_iOSDevice)
	{
		if (ifdef_iOSDevice == null)
		{
			throw new ArgumentNullException("ifdef_iOSDevice");
		}
		__macro = ifdef_iOSDevice;
		return (!Context.Parameters.Defines.ContainsKey("UNITY_IPHONE") || Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_iOSDevice.Block);
	}
}
