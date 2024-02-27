using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushTeamLeave_0024callable150_00241037_13___0024Action_0024195
{
	protected __MessageBoard_PushTeamLeave_0024callable150_00241037_13__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushTeamLeave_0024callable150_00241037_13___0024Action_0024195(__MessageBoard_PushTeamLeave_0024callable150_00241037_13__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyRemove)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushTeamLeave_0024callable150_00241037_13__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushTeamLeave_0024callable150_00241037_13___0024Action_0024195(from).Invoke;
	}
}
