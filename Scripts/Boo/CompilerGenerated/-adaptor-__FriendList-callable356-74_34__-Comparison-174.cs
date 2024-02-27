using System;
using Boo.Lang.Runtime;
using MerlinAPI;

namespace CompilerGenerated;

[Serializable]
internal sealed class _0024adaptor_0024__FriendList_0024callable356_002474_34___0024Comparison_0024174
{
	protected __FriendList_0024callable356_002474_34__ _0024from;

	public _0024adaptor_0024__FriendList_0024callable356_002474_34___0024Comparison_0024174(__FriendList_0024callable356_002474_34__ from)
	{
		_0024from = from;
	}

	public int Invoke(object x, object y)
	{
		__FriendList_0024callable356_002474_34__ _FriendList_0024callable356_002474_34__ = _0024from;
		object obj = x;
		if (!(obj is RespFriend))
		{
			obj = RuntimeServices.Coerce(obj, typeof(RespFriend));
		}
		RespFriend a = (RespFriend)obj;
		object obj2 = y;
		if (!(obj2 is RespFriend))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(RespFriend));
		}
		return _FriendList_0024callable356_002474_34__(a, (RespFriend)obj2);
	}

	public static Comparison<object> Adapt(__FriendList_0024callable356_002474_34__ from)
	{
		return new _0024adaptor_0024__FriendList_0024callable356_002474_34___0024Comparison_0024174(from).Invoke;
	}
}
