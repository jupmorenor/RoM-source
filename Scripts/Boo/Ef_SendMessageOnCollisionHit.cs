using System;
using UnityEngine;

[Serializable]
public class Ef_SendMessageOnCollisionHit : MonoBehaviour
{
	public GameObject target;

	public string message;

	public bool sendCollision;

	public bool sendCollidedGameObject;

	public bool sendCollidedTransform;

	public bool sendToCollidedObj;

	public Ef_SendMessageOnCollisionHit()
	{
		message = "Hit";
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (!target)
		{
			return;
		}
		if (sendCollision)
		{
			target.SendMessage(message, collision, SendMessageOptions.DontRequireReceiver);
		}
		else if (sendCollidedGameObject)
		{
			target.SendMessage(message, collision.gameObject, SendMessageOptions.DontRequireReceiver);
		}
		else if (sendCollidedTransform)
		{
			target.SendMessage(message, collision.transform, SendMessageOptions.DontRequireReceiver);
		}
		else if (sendToCollidedObj && collision != null)
		{
			GameObject gameObject = collision.gameObject;
			if (gameObject != null)
			{
				gameObject.SendMessage(message, collision.transform, SendMessageOptions.DontRequireReceiver);
			}
		}
		else
		{
			target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
		}
	}
}
