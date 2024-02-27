using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17___0024Action_0024200
{
	protected __MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17__ _0024from;

	public _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17___0024Action_0024200(__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyReject)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17__ from)
	{
		return new _0024adaptor_0024__MessageBoard__0024PushTeamReject_0024Reject_00243190_0024callable140_0024811_17___0024Action_0024200(from).Invoke;
	}
}
