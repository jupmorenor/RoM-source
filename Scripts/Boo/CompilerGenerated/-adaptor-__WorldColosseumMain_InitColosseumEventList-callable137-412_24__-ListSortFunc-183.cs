using System;
using Boo.Lang;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183
{
	protected __WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ _0024from;

	public _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183(__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ from)
	{
		_0024from = from;
	}

	public List<UIListBase.Container> Invoke(List<UIListBase.Container> container)
	{
		return _0024from(container);
	}

	public static UIListBase.ListSortFunc Adapt(__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24__ from)
	{
		return new _0024adaptor_0024__WorldColosseumMain_InitColosseumEventList_0024callable137_0024412_24___0024ListSortFunc_0024183(from).Invoke;
	}
}
