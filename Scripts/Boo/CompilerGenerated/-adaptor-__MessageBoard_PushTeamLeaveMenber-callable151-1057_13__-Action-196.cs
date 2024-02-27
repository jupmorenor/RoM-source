using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13___0024Action_0024196
{
	protected __MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13___0024Action_0024196(__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyMemberKick)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushTeamLeaveMenber_0024callable151_00241057_13___0024Action_0024196(from).Invoke;
	}
}
