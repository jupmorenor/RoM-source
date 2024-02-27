using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__QuestBattleEnemyAIPool_0024callable351_002455_28___0024Predicate_0024154
{
	protected __QuestBattleEnemyAIPool_0024callable351_002455_28__ _0024from;

	public _0024adaptor_0024__QuestBattleEnemyAIPool_0024callable351_002455_28___0024Predicate_0024154(__QuestBattleEnemyAIPool_0024callable351_002455_28__ from)
	{
		_0024from = from;
	}

	public bool Invoke(QuestBattleEnemyAIPool.PopInfo obj)
	{
		return _0024from(obj);
	}

	public static Predicate<QuestBattleEnemyAIPool.PopInfo> Adapt(__QuestBattleEnemyAIPool_0024callable351_002455_28__ from)
	{
		return new _0024adaptor_0024__QuestBattleEnemyAIPool_0024callable351_002455_28___0024Predicate_0024154(from).Invoke;
	}
}
