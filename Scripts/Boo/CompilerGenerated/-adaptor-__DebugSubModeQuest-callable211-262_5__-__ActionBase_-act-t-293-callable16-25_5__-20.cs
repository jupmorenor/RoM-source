using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420
{
	protected __DebugSubModeQuest_0024callable211_0024262_5__ _0024from;

	public _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420(__DebugSubModeQuest_0024callable211_0024262_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(DebugSubQuest.ActionBase arg0)
	{
		_0024from((DebugSubQuest.ActionClassv3ChallengeMaster)arg0);
	}

	public static __ActionBase__0024act_0024t_0024293_0024callable16_002425_5__ Adapt(__DebugSubModeQuest_0024callable211_0024262_5__ from)
	{
		return new _0024adaptor_0024__DebugSubModeQuest_0024callable211_0024262_5___0024__ActionBase__0024act_0024t_0024293_0024callable16_002425_5___002420(from).Invoke;
	}
}
