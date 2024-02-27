using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SendMessage : Ef_Base
{
	public GameObject target;

	public string[] findNames;

	public string message;

	public float delay;

	public int integer;

	public float @float;

	public Color color;

	public GameObject gameObj;

	public Transform transfor;

	public string text;

	public bool send;

	public bool destroy;

	public Ef_SendMessage()
	{
		message = "setTarget";
		integer = -1;
		@float = -1f;
		color = new Color(0f, 0f, 0f, 0f);
		text = string.Empty;
	}

	public void Start()
	{
		if (delay == 0f && send)
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
		if (target == null)
		{
			int length = findNames.Length;
			if (length > 0)
			{
				int num = default(int);
				IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						string[] array = findNames;
						string text = array[RuntimeServices.NormalizeArrayIndex(array, num)];
						if (text != "MainCamera")
						{
							target = GameObject.Find(text);
							if (!target)
							{
								target = GameObject.Find(text + "(Clone)");
							}
							if ((bool)target)
							{
								break;
							}
						}
						else if ((bool)Camera.main)
						{
							target = Camera.main.gameObject;
							break;
						}
					}
				}
				finally
				{
					enumerator.Dispose();
				}
			}
		}
		if (target == null)
		{
			return;
		}
		if (!target.gameObject.activeSelf)
		{
			target.gameObject.SetActive(value: true);
		}
		if (message.Length != 0)
		{
			if (integer != -1)
			{
				target.SendMessage(message, integer, SendMessageOptions.DontRequireReceiver);
			}
			else if (@float != -1f)
			{
				target.SendMessage(message, @float, SendMessageOptions.DontRequireReceiver);
			}
			else if ((bool)gameObj)
			{
				target.SendMessage(message, gameObj, SendMessageOptions.DontRequireReceiver);
			}
			else if ((bool)transfor)
			{
				target.SendMessage(message, transfor, SendMessageOptions.DontRequireReceiver);
			}
			else if (this.text.Length > 0)
			{
				target.SendMessage(message, this.text, SendMessageOptions.DontRequireReceiver);
			}
			else if (color != new Color(0f, 0f, 0f, 0f))
			{
				target.SendMessage(message, color, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
