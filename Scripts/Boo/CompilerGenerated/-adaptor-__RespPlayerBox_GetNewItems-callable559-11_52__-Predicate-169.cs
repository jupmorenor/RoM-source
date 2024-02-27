using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__RespPlayerBox_GetNewItems_0024callable559_002411_52___0024Predicate_0024169
{
	protected __RespPlayerBox_GetNewItems_0024callable559_002411_52__ _0024from;

	public _0024adaptor_0024__RespPlayerBox_GetNewItems_0024callable559_002411_52___0024Predicate_0024169(__RespPlayerBox_GetNewItems_0024callable559_002411_52__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespPlayerBox obj)
	{
		return _0024from(obj);
	}

	public static Predicate<RespPlayerBox> Adapt(__RespPlayerBox_GetNewItems_0024callable559_002411_52__ from)
	{
		return new _0024adaptor_0024__RespPlayerBox_GetNewItems_0024callable559_002411_52___0024Predicate_0024169(from).Invoke;
	}
}
