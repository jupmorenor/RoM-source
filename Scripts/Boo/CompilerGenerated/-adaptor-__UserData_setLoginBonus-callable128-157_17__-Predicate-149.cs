using System;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__UserData_setLoginBonus_0024callable128_0024157_17___0024Predicate_0024149
{
	protected __UserData_setLoginBonus_0024callable128_0024157_17__ _0024from;

	public _0024adaptor_0024__UserData_setLoginBonus_0024callable128_0024157_17___0024Predicate_0024149(__UserData_setLoginBonus_0024callable128_0024157_17__ from)
	{
		_0024from = from;
	}

	public bool Invoke(RespPlayerLogin obj)
	{
		return _0024from(obj);
	}

	public static Predicate<RespPlayerLogin> Adapt(__UserData_setLoginBonus_0024callable128_0024157_17__ from)
	{
		return new _0024adaptor_0024__UserData_setLoginBonus_0024callable128_0024157_17___0024Predicate_0024149(from).Invoke;
	}
}
