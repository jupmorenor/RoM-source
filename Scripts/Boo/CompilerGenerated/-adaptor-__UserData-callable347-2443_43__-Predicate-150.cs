using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__UserData_0024callable347_00242443_43___0024Predicate_0024150
{
	protected __UserData_0024callable347_00242443_43__ _0024from;

	public _0024adaptor_0024__UserData_0024callable347_00242443_43___0024Predicate_0024150(__UserData_0024callable347_00242443_43__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespColosseumEvent obj)
	{
		return _0024from(obj);
	}

	public static Predicate<RespColosseumEvent> Adapt(__UserData_0024callable347_00242443_43__ from)
	{
		return new _0024adaptor_0024__UserData_0024callable347_00242443_43___0024Predicate_0024150(from).Invoke;
	}
}
