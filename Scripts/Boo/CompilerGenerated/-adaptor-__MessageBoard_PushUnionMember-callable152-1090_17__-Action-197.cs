using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__MessageBoard_PushUnionMember_0024callable152_00241090_17___0024Action_0024197
{
	protected __MessageBoard_PushUnionMember_0024callable152_00241090_17__ _0024from;

	public _0024adaptor_0024__MessageBoard_PushUnionMember_0024callable152_00241090_17___0024Action_0024197(__MessageBoard_PushUnionMember_0024callable152_00241090_17__ from)
	{
		_0024from = from;
	}

	public void Invoke(RequestBase obj)
	{
		_0024from((ApiGuild)obj);
	}

	public static Action<RequestBase> Adapt(__MessageBoard_PushUnionMember_0024callable152_00241090_17__ from)
	{
		return new _0024adaptor_0024__MessageBoard_PushUnionMember_0024callable152_00241090_17___0024Action_0024197(from).Invoke;
	}
}
