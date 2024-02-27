using System;
using System.Runtime.CompilerServices;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;

[Serializable]
public sealed class Ifdef_MobileDeviceMacro : LexicalInfoPreservingMacro
{
	[CompilerGenerated]
	private MacroStatement __macro;

	public Ifdef_MobileDeviceMacro()
	{
	}

	public Ifdef_MobileDeviceMacro(CompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base._002Ector(context);
	}

	protected override Statement ExpandImpl(MacroStatement ifdef_MobileDevice)
	{
		if (ifdef_MobileDevice == null)
		{
			throw new ArgumentNullException("ifdef_MobileDevice");
		}
		__macro = ifdef_MobileDevice;
		bool flag = false;
		if (Context.Parameters.Defines.ContainsKey("UNITY_IPHONE"))
		{
			flag = true;
		}
		if (Context.Parameters.Defines.ContainsKey("UNITY_ANDROID"))
		{
			flag = true;
		}
		return (!flag || Context.Parameters.Defines.ContainsKey("UNITY_EDITOR")) ? null : Statement.Lift(ifdef_MobileDevice.Block);
	}
}
