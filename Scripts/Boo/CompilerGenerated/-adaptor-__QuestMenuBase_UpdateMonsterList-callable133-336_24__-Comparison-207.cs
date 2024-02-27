using System;
using System.Collections.Generic;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24___0024Comparison_0024207
{
	protected __QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24__ _0024from;

	public _0024adaptor_0024__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24___0024Comparison_0024207(__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24__ from)
	{
		_0024from = from;
	}

	public int Invoke(KeyValuePair<object, int[]> p1, KeyValuePair<object, int[]> p2)
	{
		return _0024from(p1, p2);
	}

	public static Comparison<KeyValuePair<object, int[]>> Adapt(__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24__ from)
	{
		return new _0024adaptor_0024__QuestMenuBase_UpdateMonsterList_0024callable133_0024336_24___0024Comparison_0024207(from).Invoke;
	}
}
