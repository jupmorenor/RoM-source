using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ColosseumTestSelect_0024callable339_0024166_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024142
{
	protected __ColosseumTestSelect_0024callable339_0024166_5__ _0024from;

	public _0024adaptor_0024__ColosseumTestSelect_0024callable339_0024166_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024142(__ColosseumTestSelect_0024callable339_0024166_5__ from)
	{
		_0024from = from;
	}

	public void Invoke(ColosseumTestSelect.ActionBase arg0)
	{
		_0024from((ColosseumTestSelect.ActionClassselectFromBox)arg0);
	}

	public static __ActionBase__0024act_0024t_00241458_0024callable71_002474_5__ Adapt(__ColosseumTestSelect_0024callable339_0024166_5__ from)
	{
		return new _0024adaptor_0024__ColosseumTestSelect_0024callable339_0024166_5___0024__ActionBase__0024act_0024t_00241458_0024callable71_002474_5___0024142(from).Invoke;
	}
}
