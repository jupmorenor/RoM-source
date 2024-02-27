using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159
{
	protected __QuestSessionData_findMonster_0024callable82_0024170_37__ _0024from;

	public _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159(__QuestSessionData_findMonster_0024callable82_0024170_37__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespMonster obj)
	{
		return _0024from(obj);
	}

	public static Predicate<RespMonster> Adapt(__QuestSessionData_findMonster_0024callable82_0024170_37__ from)
	{
		return new _0024adaptor_0024__QuestSessionData_findMonster_0024callable82_0024170_37___0024Predicate_0024159(from).Invoke;
	}
}
