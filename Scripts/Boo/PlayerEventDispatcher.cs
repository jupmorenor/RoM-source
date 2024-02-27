using System;
using System.Collections.Generic;
using Boo.Lang;

[Serializable]
public class PlayerEventDispatcher
{
	[NonSerialized]
	private static Boo.Lang.List<PlayerEventHandlers> Handlers = new Boo.Lang.List<PlayerEventHandlers>();

	public static void Add(PlayerEventHandlers h)
	{
		if (h != null && !Handlers.Contains(h))
		{
			Handlers.Add(h);
		}
	}

	public static void Remove(PlayerEventHandlers h)
	{
		if (h != null)
		{
			Handlers.Remove(h);
		}
	}

	public static void InvokePlayerEnabled(PlayerControl p)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventPlayerEnabled(p);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePlayerDisabled(PlayerControl p)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventPlayerDisabled(p);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePoppetSet(PlayerControl p, MerlinActionControl[] ppts)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventPoppetSet(p, ppts);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBattleStart()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBattleStart();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBattleEnd()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBattleEnd();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBattleComplete()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBattleComplete();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePlayerDamage(MerlinActionControl player)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPlayerDamage(player);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPoppetDamage(attacker, poppet, damage);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeMonsterDamage(MerlinActionControl monster)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventMonsterDamage(monster);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePlayerDown(MerlinActionControl player)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPlayerDown(player);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPoppetDown(attacker, poppet, damage);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeMonsterDown(MerlinActionControl monster)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventMonsterDown(monster);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventDead(attacker, poppet, damage);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeRevive(MerlinActionControl poppet)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventRevive(poppet);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeChain(MerlinActionControl poppet)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventChain(poppet);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeMagicCharge(MerlinActionControl poppet)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventMagicCharge(poppet);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBossStart(MerlinActionControl boss)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBossStart(boss);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBossEnd(MerlinActionControl boss)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBossEnd(boss);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPoppetFinish(poppet, monster, damage);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePlayerDead(PlayerControl player)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventPlayerDead(player);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBox()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBox();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeBoxGet()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventBoxGet();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeCandy()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventCandy();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeCandyGet()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventCandyGet();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeToDemon()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventToDemon();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeToAngel()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current?.eventToAngel();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventResistAbnormalStateAttack(state, resister, attacker);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventInfectAbnormalState(state, patient, attacker);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeQuestStart(PlayerControl pl)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventQuestStart(pl);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeQuestRestart(PlayerControl pl)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventQuestRestart(pl);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeQuestEnd(PlayerControl pl)
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventQuestEnd(pl);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokePause()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventPause();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeUnpause()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventUnpause();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeJumpStart()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventJumpStart();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public static void InvokeJumpEnd()
	{
		IEnumerator<PlayerEventHandlers> enumerator = Handlers.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlayerEventHandlers current = enumerator.Current;
				current.eventJumpEnd();
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
