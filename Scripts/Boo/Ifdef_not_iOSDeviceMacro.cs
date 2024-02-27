using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_not_iOSDeviceMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_not_iOSDeviceMacro()
	{
	}

	public Ifdef_not_iOSDeviceMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_not_iOSDevice)
	{
		if (ifdef_not_iOSDevice == null)
		{
			throw new ArgumentNullException("ifdef_not_iOSDevice");
		}
		__macro = ifdef_not_iOSDevice;
		return (Context.Parameters.Defines.ContainsKey("UNITY_IPHONE") && !Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_not_iOSDevice.Block);
	}
}
