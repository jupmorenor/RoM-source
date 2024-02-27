using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubQuest_sortQuestArray_0024callable18_0024342_16___0024Comparison_002422
{
	protected __DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ _0024from;

	public _0024adaptor_0024__DebugSubQuest_sortQuestArray_0024callable18_0024342_16___0024Comparison_002422(__DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ from)
	{
		_0024from = from;
	}

	public int Invoke(MQuests arg0, MQuests arg1)
	{
		return _0024from(arg0, arg1);
	}

	public static Comparison<MQuests> Adapt(__DebugSubQuest_sortQuestArray_0024callable18_0024342_16__ from)
	{
		return new _0024adaptor_0024__DebugSubQuest_sortQuestArray_0024callable18_0024342_16___0024Comparison_002422(from).Invoke;
	}
}
