using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17___0024Action_0024202
{
	protected __MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17__ _0024from;

	public _0024adaptor_0024__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17___0024Action_0024202(__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiPartyAccept)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17__ from)
	{
		return new _0024adaptor_0024__MessageBoard__0024PushTeamAgree_0024Accept_00243195_0024callable143_0024861_17___0024Action_0024202(from).Invoke;
	}
}
