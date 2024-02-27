using System;
using System.Runtime.CompilerServices;
using CompilerGenerated;

[Serializable]
public class RaidBattleEventListener : PlayerEventAdapter
{
	private __RaidBattleEventListener_AbnormalStateInfection_0024callable85_00243_37__ _0024event_0024AbnormalStateInfection;

	public event __RaidBattleEventListener_AbnormalStateInfection_0024callable85_00243_37__ AbnormalStateInfection
	{
		add
		{
			_0024event_0024AbnormalStateInfection = (__RaidBattleEventListener_AbnormalStateInfection_0024callable85_00243_37__)Delegate.Combine(_0024event_0024AbnormalStateInfection, value);
		}
		remove
		{
			_0024event_0024AbnormalStateInfection = (__RaidBattleEventListener_AbnormalStateInfection_0024callable85_00243_37__)Delegate.Remove(_0024event_0024AbnormalStateInfection, value);
		}
	}

	[SpecialName]
	protected internal void raise_AbnormalStateInfection(EnumAbnormalStates arg0, MerlinActionControl arg1, MerlinActionControl arg2)
	{
		_0024event_0024AbnormalStateInfection?.Invoke(arg0, arg1, arg2);
	}

	public override void eventInfectAbnormalState(EnumAbnormalStates state, MerlinActionControl patient, MerlinActionControl attacker)
	{
		raise_AbnormalStateInfection(state, patient, attacker);
	}
}
