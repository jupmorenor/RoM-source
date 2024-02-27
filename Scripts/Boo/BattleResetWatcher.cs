using System;

[Serializable]
public class BattleResetWatcher
{
	private float noDamageTime;

	private int lastDamageCount;

	public bool NeedReset
	{
		get
		{
			float num = 60f;
			if (GameParameter.shortenBattleResetTime)
			{
				num *= 0.1f;
			}
			return noDamageTime > num;
		}
	}

	private bool IsInActualPlay
	{
		get
		{
			bool num = IPauseWindow.IsPaused;
			if (!num)
			{
				num = ChainSkillRoutine.IsPlaying;
			}
			if (!num)
			{
				num = BattleContinue.IsRunning;
			}
			return !num;
		}
	}

	public BattleResetWatcher()
	{
		reset();
	}

	public void update(float dt)
	{
		if (IsInActualPlay && lastDamageCount == QuestEventHandler.BattleTotalDamageCount)
		{
			noDamageTime += dt;
		}
		else
		{
			reset();
		}
	}

	public void reset()
	{
		noDamageTime = 0f;
		lastDamageCount = QuestEventHandler.BattleTotalDamageCount;
	}
}
