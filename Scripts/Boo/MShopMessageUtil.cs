using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MShopMessageUtil
{
	[Serializable]
	internal class _0024GetRandomMessage_0024locals_002414325
	{
		internal EnumShopMessageTypes _0024type;
	}

	[Serializable]
	internal class _0024GetRandomMessage_0024closure_00242942
	{
		internal _0024GetRandomMessage_0024locals_002414325 _0024_0024locals_002414753;

		public _0024GetRandomMessage_0024closure_00242942(_0024GetRandomMessage_0024locals_002414325 _0024_0024locals_002414753)
		{
			this._0024_0024locals_002414753 = _0024_0024locals_002414753;
		}

		public bool Invoke(MShopMessage m)
		{
			return m.ShopMessageType == _0024_0024locals_002414753._0024type;
		}
	}

	public static string GetRandomMessage(EnumShopMessageTypes type)
	{
		_0024GetRandomMessage_0024locals_002414325 _0024GetRandomMessage_0024locals_0024 = new _0024GetRandomMessage_0024locals_002414325();
		_0024GetRandomMessage_0024locals_0024._0024type = type;
		MShopMessage[] array = ArrayMap.FilterAllMShopMessages(new _0024GetRandomMessage_0024closure_00242942(_0024GetRandomMessage_0024locals_0024).Invoke);
		object result;
		if (array.Length == 0)
		{
			result = null;
		}
		else
		{
			int index = UnityEngine.Random.Range(0, array.Length);
			MTexts message = MasterExtensionsModule.GetMessage(array[RuntimeServices.NormalizeArrayIndex(array, index)]);
			result = ((message == null) ? string.Empty : TextTagCheck.ReplaceMultiLine(message.ToString()));
		}
		return (string)result;
	}
}
