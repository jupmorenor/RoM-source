using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440
{
	protected __DebugSubModeQuest_0024callable208_0024179_45__ _0024from;

	public _0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440(__DebugSubModeQuest_0024callable208_0024179_45__ from)
	{
		_0024from = from;
	}

	public int Invoke(RespMonster x, RespMonster y)
	{
		return _0024from(x, y);
	}

	public static Comparison<RespMonster> Adapt(__DebugSubModeQuest_0024callable208_0024179_45__ from)
	{
		return new _0024adaptor_0024__DebugSubModeQuest_0024callable208_0024179_45___0024Comparison_002440(from).Invoke;
	}
}
