using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17___0024Action_0024201
{
	protected __MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17__ _0024from;

	public _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17___0024Action_0024201(__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyLeaderChangeReject)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17__ from)
	{
		return new _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024RejectLeader_00243192_0024callable142_0024821_17___0024Action_0024201(from).Invoke;
	}
}