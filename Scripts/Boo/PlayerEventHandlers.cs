public interface PlayerEventHandlers
{
	virtual void eventPlayerEnabled(PlayerControl player);

	virtual void eventPlayerDisabled(PlayerControl player);

	virtual void eventPoppetSet(PlayerControl player, MerlinActionControl[] poppets);

	virtual void eventBattleStart();

	virtual void eventBattleEnd();

	virtual void eventBattleComplete();

	virtual void eventPlayerDamage(MerlinActionControl player);

	virtual void eventPoppetDamage(MerlinActionControl attacker, MerlinActionControl poppet, float damage);

	virtual void eventMonsterDamage(MerlinActionControl monster);

	virtual void eventPlayerDown(MerlinActionControl player);

	virtual void eventPoppetDown(MerlinActionControl attacker, MerlinActionControl poppet, float damage);

	virtual void eventDead(MerlinActionControl attacker, MerlinActionControl poppet, float damage);

	virtual void eventMonsterDown(MerlinActionControl monster);

	virtual void eventRevive(MerlinActionControl poppet);

	virtual void eventChain(MerlinActionControl poppet);

	virtual void eventMagicCharge(MerlinActionControl poppet);

	virtual void eventBossStart(MerlinActionControl boss);

	virtual void eventBossEnd(MerlinActionControl boss);

	virtual void eventPoppetFinish(MerlinActionControl poppet, MerlinActionControl monster, float damage);

	virtual void eventPlayerDead(PlayerControl player);

	virtual void eventBox();

	virtual void eventBoxGet();

	virtual void eventCandy();

	virtual void eventCandyGet();

	virtual void eventToDemon();

	virtual void eventToAngel();

	virtual void eventResistAbnormalStateAttack(EnumAbnormalStates state, MerlinActionControl resister, MerlinActionControl attacker);

	virtual void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker);

	virtual void eventQuestStart(PlayerControl player);

	virtual void eventQuestRestart(PlayerControl player);

	virtual void eventQuestEnd(PlayerControl player);

	virtual void eventPause();

	virtual void eventUnpause();

	virtual void eventJumpStart();

	virtual void eventJumpEnd();
}
