using System;
using UnityEngine;

[Serializable]
public class PlayerEventAdapter : MonoBehaviour, PlayerEventHandlers
{
	public void OnEnable()
	{
		PlayerEventDispatcher.Add(this);
	}

	public void OnDisable()
	{
		PlayerEventDispatcher.Remove(this);
	}

	public virtual void eventPlayerEnabled(PlayerControl player)
	{
	}

	public virtual void eventPlayerDisabled(PlayerControl player)
	{
	}

	public virtual void eventPoppetSet(PlayerControl player, MerlinActionControl[] poppets)
	{
	}

	public virtual void eventBattleStart()
	{
	}

	public virtual void eventBattleEnd()
	{
	}

	public virtual void eventBattleComplete()
	{
	}

	public virtual void eventPlayerDamage(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDamage(MerlinActionControl monster)
	{
	}

	public virtual void eventPlayerDown(MerlinActionControl player)
	{
	}

	public virtual void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventMonsterDown(MerlinActionControl monster)
	{
	}

	public virtual void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
	}

	public virtual void eventRevive(MerlinActionControl poppet)
	{
	}

	public virtual void eventChain(MerlinActionControl poppet)
	{
	}

	public virtual void eventMagicCharge(MerlinActionControl poppet)
	{
	}

	public virtual void eventBossStart(MerlinActionControl boss)
	{
	}

	public virtual void eventBossEnd(MerlinActionControl boss)
	{
	}

	public virtual void eventPoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage)
	{
	}

	public virtual void eventPlayerDead(PlayerControl player)
	{
	}

	public virtual void eventBox()
	{
	}

	public virtual void eventBoxGet()
	{
	}

	public virtual void eventCandy()
	{
	}

	public virtual void eventCandyGet()
	{
	}

	public virtual void eventToDemon()
	{
	}

	public virtual void eventToAngel()
	{
	}

	public virtual void eventResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker)
	{
	}

	public virtual void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
	}

	public virtual void eventQuestStart(PlayerControl player)
	{
	}

	public virtual void eventQuestRestart(PlayerControl player)
	{
	}

	public virtual void eventQuestEnd(PlayerControl player)
	{
	}

	public virtual void eventPause()
	{
	}

	public virtual void eventUnpause()
	{
	}

	public virtual void eventJumpStart()
	{
	}

	public virtual void eventJumpEnd()
	{
	}
}
