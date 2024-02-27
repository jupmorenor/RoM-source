using System;

[Serializable]
public class PassiveSkillPlayerEventHandlers : PlayerEventAdapter
{
	private PlayerControl player;

	public PlayerControl Player
	{
		get
		{
			return player;
		}
		set
		{
			player = value;
		}
	}

	public override void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		if (!(player == null))
		{
			player.SkillEffectControl?.doEffectsPoppetDied(player);
		}
	}
}
