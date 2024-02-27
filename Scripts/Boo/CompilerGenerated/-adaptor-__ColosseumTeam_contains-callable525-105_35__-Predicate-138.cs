using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ColosseumTeam_contains_0024callable525_0024105_35___0024Predicate_0024138
{
	protected __ColosseumTeam_contains_0024callable525_0024105_35__ _0024from;

	public _0024adaptor_0024__ColosseumTeam_contains_0024callable525_0024105_35___0024Predicate_0024138(__ColosseumTeam_contains_0024callable525_0024105_35__ from)
	{
		_0024from = from;
	}

	public bool Invoke(ColosseumTeamMember obj)
	{
		return _0024from(obj);
	}

	public static Predicate<ColosseumTeamMember> Adapt(__ColosseumTeam_contains_0024callable525_0024105_35__ from)
	{
		return new _0024adaptor_0024__ColosseumTeam_contains_0024callable525_0024105_35___0024Predicate_0024138(from).Invoke;
	}
}
