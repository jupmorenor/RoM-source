using System;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36___0024155
{
	protected __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _0024from;

	public _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36___0024155(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		_0024from = from;
	}

	public void Invoke(MScenes arg0)
	{
		_0024from();
	}

	public static __QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36__ Adapt(__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ from)
	{
		return new _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__QuestLinkRoutine_JumpStartEvent_0024callable78_002412_36___0024155(from).Invoke;
	}
}
