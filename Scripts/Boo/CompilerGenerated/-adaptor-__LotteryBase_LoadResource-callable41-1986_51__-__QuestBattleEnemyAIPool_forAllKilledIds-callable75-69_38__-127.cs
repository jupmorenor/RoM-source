using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___0024127
{
	protected __LotteryBase_LoadResource_0024callable41_00241986_51__ _0024from;

	public _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___0024127(__LotteryBase_LoadResource_0024callable41_00241986_51__ from)
	{
		_0024from = from;
	}

	public void Invoke(int arg0)
	{
		_0024from(arg0);
	}

	public static __QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38__ Adapt(__LotteryBase_LoadResource_0024callable41_00241986_51__ from)
	{
		return new _0024adaptor_0024__LotteryBase_LoadResource_0024callable41_00241986_51___0024__QuestBattleEnemyAIPool_forAllKilledIds_0024callable75_002469_38___0024127(from).Invoke;
	}
}
