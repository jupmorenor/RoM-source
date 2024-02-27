using System;
using UnityEngine;

[Serializable]
public class AndroidCipher
{
	[NonSerialized]
	protected static AndroidJavaObject _Plugin;

	public static AndroidJavaObject Plugin
	{
		get
		{
			if (_Plugin == null)
			{
				_Plugin = new AndroidJavaObject("jp.co.goshow.merlin.AndroidCipherPlugin");
			}
			return _Plugin;
		}
	}

	public static byte[] Encode(byte[] src, byte[] key)
	{
		return Plugin.Call<byte[]>("encode", new object[2] { src, key });
	}

	public static byte[] Decode(byte[] src, byte[] key)
	{
		return Plugin.Call<byte[]>("decode", new object[2] { src, key });
	}

	public static byte[] GenKey()
	{
		return Plugin.Call<byte[]>("genKey", new object[0]);
	}
}
