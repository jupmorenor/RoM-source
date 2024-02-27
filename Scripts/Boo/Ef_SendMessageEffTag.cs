using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SendMessageEffTag : Ef_Base
{
	public GameObject[] targets;

	public string effTag;

	public string message;

	public float delay;

	public int integer;

	public float @float;

	public GameObject gameObj;

	public Transform transfor;

	public string text;

	public bool send;

	public bool destroy;

	private Ef_TagDatas tagDats;

	public Ef_SendMessageEffTag()
	{
		message = "setTarget";
		integer = -1;
		@float = -1f;
		text = string.Empty;
	}

	public void Start()
	{
		if (delay == 0f)
		{
			Send();
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			if (!(delay > 0f))
			{
				Send();
				if (destroy)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		if (send)
		{
			Send();
			send = false;
		}
	}

	public void Send()
	{
		tagDats = Ef_TagDatas.Current;
		if (tagDats == null)
		{
			return;
		}
		if (effTag.Length > 0)
		{
			targets = tagDats.SearchTag(effTag);
		}
		int length = targets.Length;
		if (length == 0)
		{
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				if (message.Length == 0)
				{
					break;
				}
				if (integer != -1)
				{
					GameObject[] array = targets;
					array[RuntimeServices.NormalizeArrayIndex(array, num)].SendMessage(message, integer, SendMessageOptions.DontRequireReceiver);
				}
				else if (@float != -1f)
				{
					GameObject[] array2 = targets;
					array2[RuntimeServices.NormalizeArrayIndex(array2, num)].SendMessage(message, @float, SendMessageOptions.DontRequireReceiver);
				}
				else if ((bool)gameObj)
				{
					GameObject[] array3 = targets;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num)].SendMessage(message, gameObj, SendMessageOptions.DontRequireReceiver);
				}
				else if ((bool)transfor)
				{
					GameObject[] array4 = targets;
					array4[RuntimeServices.NormalizeArrayIndex(array4, num)].SendMessage(message, transfor, SendMessageOptions.DontRequireReceiver);
				}
				else if (text.Length > 0)
				{
					GameObject[] array5 = targets;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)].SendMessage(message, text, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					GameObject[] array6 = targets;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)].SendMessage(message, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
