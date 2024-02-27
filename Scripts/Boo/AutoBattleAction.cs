using System;

[Serializable]
public abstract class AutoBattleAction
{
	protected AutoBattleType autoBattleType;

	protected PlayerControl player;

	protected PlayerAutoBattle autoBattle;

	protected float playerRadius;

	protected ActionStep actionNextStep;

	public AutoBattleAction(PlayerControl p, AutoBattleType type)
	{
		autoBattleType = AutoBattleType.NONE;
		actionNextStep = ActionStep.NONE;
		player = p;
		autoBattle = player.AutoBattle;
		autoBattleType = type;
		playerRadius = player.CharControl.radius;
	}

	public virtual void Init()
	{
	}

	public virtual int Apply(float frameTime)
	{
		return 0;
	}

	public virtual void RequireEnd()
	{
	}

	public override string ToString()
	{
		return "AutoBattleAction";
	}

	public new AutoBattleType GetType()
	{
		return autoBattleType;
	}
}
