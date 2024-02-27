using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151
{
	protected __UserData_0024callable348_00242490_20__ _0024from;

	public _0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151(__UserData_0024callable348_00242490_20__ from)
	{
		_0024from = from;
	}

	public int Invoke(RespQuestMission x, RespQuestMission y)
	{
		return _0024from(x, y);
	}

	public static Comparison<RespQuestMission> Adapt(__UserData_0024callable348_00242490_20__ from)
	{
		return new _0024adaptor_0024__UserData_0024callable348_00242490_20___0024Comparison_0024151(from).Invoke;
	}
}
