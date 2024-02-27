using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class PoppetSpeakEventHandler : MonoBehaviour, PlayerEventHandlers
{
	protected PlayerControl curPlayer;

	protected MerlinActionControl[] curPoppets;

	public void OnEnable()
	{
		PlayerEventDispatcher.Add(this);
	}

	public void OnDisable()
	{
		PlayerEventDispatcher.Remove(this);
	}

	private void speak(EnumPoppetChatTimings speakType)
	{
		speak(choosePoppetRandomly(curPoppets), speakType);
	}

	private void speak(MerlinActionControl poppet, EnumPoppetChatTimings speakType)
	{
		if (!(poppet == null) && poppet.gameObject.active && !CutSceneManager.Instance.isBusy)
		{
			MapetSpeak component = poppet.gameObject.GetComponent<MapetSpeak>();
			if (component != null)
			{
				component.Speak(speakType, overwrite: true);
			}
		}
	}

	private MerlinActionControl choosePoppetRandomly(MerlinActionControl[] poppets)
	{
		object result;
		if (poppets == null || poppets.Length <= 0)
		{
			result = null;
		}
		else
		{
			result = poppets[RuntimeServices.NormalizeArrayIndex(poppets, UnityEngine.Random.Range(0, poppets.Length))];
		}
		return (MerlinActionControl)result;
	}

	public virtual void eventPlayerEnabled(PlayerControl player)
	{
		curPlayer = player;
	}

	public virtual void eventPlayerDisabled(PlayerControl player)
	{
		curPlayer = null;
		curPoppets = null;
	}

	public virtual void eventPoppetSet(PlayerControl player, MerlinActionControl[] poppets)
	{
		curPoppets = poppets;
	}

	public virtual void eventBattleStart()
	{
		speak(EnumPoppetChatTimings.BattleStart);
	}

	public virtual void eventBattleEnd()
	{
		speak(EnumPoppetChatTimings.BattleEnd);
	}

	public virtual void eventBattleComplete()
	{
	}

	public virtual void eventPlayerDamage(MerlinActionControl player)
	{
		speak(EnumPoppetChatTimings.Damage);
	}

	public virtual void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		speak(poppet, EnumPoppetChatTimings.Damage);
	}

	public virtual void eventMonsterDamage(MerlinActionControl monster)
	{
	}

	public virtual void eventPlayerDown(MerlinActionControl player)
	{
		speak(EnumPoppetChatTimings.Down);
	}

	public virtual void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		speak(poppet, EnumPoppetChatTimings.Down);
	}

	public virtual void eventMonsterDown(MerlinActionControl monster)
	{
	}

	public virtual void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		speak(poppet, EnumPoppetChatTimings.Dead);
	}

	public virtual void eventRevive(MerlinActionControl poppet)
	{
		speak(EnumPoppetChatTimings.Revive);
	}

	public virtual void eventChain(MerlinActionControl poppet)
	{
		speak(poppet, EnumPoppetChatTimings.Chain);
	}

	public virtual void eventMagicCharge(MerlinActionControl poppet)
	{
		speak(poppet, EnumPoppetChatTimings.MagicCharge);
	}

	public virtual void eventBossStart(MerlinActionControl boss)
	{
		speak(EnumPoppetChatTimings.BossStart);
	}

	public virtual void eventBossEnd(MerlinActionControl boss)
	{
		speak(EnumPoppetChatTimings.BossEnd);
	}

	public virtual void eventPoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage)
	{
		speak(poppet, EnumPoppetChatTimings.PoppetFinish);
	}

	public virtual void eventPlayerDead(PlayerControl player)
	{
		speak(EnumPoppetChatTimings.PlayerDead);
	}

	public virtual void eventBox()
	{
		speak(EnumPoppetChatTimings.Box);
	}

	public virtual void eventBoxGet()
	{
		speak(EnumPoppetChatTimings.BoxGet);
	}

	public virtual void eventCandy()
	{
		speak(EnumPoppetChatTimings.Candy);
	}

	public virtual void eventCandyGet()
	{
		speak(EnumPoppetChatTimings.CandyGet);
	}

	public virtual void eventToDemon()
	{
		speak(EnumPoppetChatTimings.ToDemon);
	}

	public virtual void eventToAngel()
	{
		speak(EnumPoppetChatTimings.ToAngel);
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
