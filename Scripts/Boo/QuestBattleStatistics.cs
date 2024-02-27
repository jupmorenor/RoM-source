using System;
using MerlinAPI;

[Serializable]
public class QuestBattleStatistics : JsonBase
{
	public int battleTotalDamageCount;

	public int playerAbnormalStateCount;

	public int playerDamageCount;

	public float playerCurrentPlayTime;

	public float playerTotalAttack;

	public float playerTotalHP;

	public float playerLastHp;

	public void reset()
	{
		battleTotalDamageCount = 0;
		playerAbnormalStateCount = 0;
		playerDamageCount = 0;
		playerCurrentPlayTime = 0f;
		playerTotalAttack = 0f;
		playerTotalHP = 0f;
		playerLastHp = 0f;
	}
}
