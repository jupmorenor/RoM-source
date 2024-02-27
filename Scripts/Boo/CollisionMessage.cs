using System;
using UnityEngine;

[Serializable]
public class CollisionMessage : MonoBehaviour
{
	[Serializable]
	public enum Trigger
	{
		Enter,
		Exit,
		Stay,
		EnterExit
	}

	public Trigger trigger;

	public Transform target;

	public Transform sentTarget;

	public string functionName;

	public bool isIn;

	protected bool detectsEnter
	{
		get
		{
			bool num = trigger == Trigger.Enter;
			if (!num)
			{
				num = trigger == Trigger.EnterExit;
			}
			return num;
		}
	}

	protected bool detectsExit
	{
		get
		{
			bool num = trigger == Trigger.Exit;
			if (!num)
			{
				num = trigger == Trigger.EnterExit;
			}
			return num;
		}
	}

	protected bool detectsStay => trigger == Trigger.Stay;

	public CollisionMessage()
	{
		trigger = Trigger.Enter;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (detectsEnter && !(other.transform.root != target))
		{
			sentMessage();
			isIn = true;
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (detectsExit && !(other.transform.root != target))
		{
			sentMessage();
			isIn = false;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if (detectsStay && !(other.transform.root != target))
		{
			sentMessage();
			isIn = true;
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (detectsEnter && !(collision.gameObject.transform.root != target))
		{
			sentMessage();
			isIn = true;
		}
	}

	public void OnCollisionExit(Collision collision)
	{
		if (detectsExit && !(collision.gameObject.transform.root != target))
		{
			sentMessage();
			isIn = false;
		}
	}

	public void OnCollisionStay(Collision collision)
	{
		if (detectsStay && !(collision.gameObject.transform.root != target))
		{
			sentMessage();
			isIn = true;
		}
	}

	private void sentMessage()
	{
		if (!(sentTarget == null) && !string.IsNullOrEmpty(functionName))
		{
			sentTarget.gameObject.SendMessage(functionName, gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}
}
