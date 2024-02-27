using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__DeckColosseum_SetLimitIcon_0024callable92_0024194_113___0024__ArrayMap_SingleToStr_0024callable7_002488_59___002448
{
	protected __DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ _0024from;

	public _0024adaptor_0024__DeckColosseum_SetLimitIcon_0024callable92_0024194_113___0024__ArrayMap_SingleToStr_0024callable7_002488_59___002448(__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ from)
	{
		_0024from = from;
	}

	public string Invoke(float sec)
	{
		return _0024from(checked((int)sec));
	}

	public static __ArrayMap_SingleToStr_0024callable7_002488_59__ Adapt(__DeckColosseum_SetLimitIcon_0024callable92_0024194_113__ from)
	{
		return new _0024adaptor_0024__DeckColosseum_SetLimitIcon_0024callable92_0024194_113___0024__ArrayMap_SingleToStr_0024callable7_002488_59___002448(from).Invoke;
	}
}
