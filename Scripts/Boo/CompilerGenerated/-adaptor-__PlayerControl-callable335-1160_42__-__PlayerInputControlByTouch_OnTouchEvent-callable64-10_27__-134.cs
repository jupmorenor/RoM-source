using System;
using UnityEngine;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__PlayerControl_0024callable335_00241160_42___0024__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27___0024134
{
	protected __PlayerControl_0024callable335_00241160_42__ _0024from;

	public _0024adaptor_0024__PlayerControl_0024callable335_00241160_42___0024__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27___0024134(__PlayerControl_0024callable335_00241160_42__ from)
	{
		_0024from = from;
	}

	public void Invoke(PlayerInputControlByTouch arg0, Vector3 arg1)
	{
		_0024from(arg0, arg1);
	}

	public static __PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27__ Adapt(__PlayerControl_0024callable335_00241160_42__ from)
	{
		return new _0024adaptor_0024__PlayerControl_0024callable335_00241160_42___0024__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27___0024134(from).Invoke;
	}
}