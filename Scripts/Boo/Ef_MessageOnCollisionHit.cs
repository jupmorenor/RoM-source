using System;
using UnityEngine;

[Serializable]
public class Ef_MessageOnCollisionHit : MonoBehaviour
{
	public GameObject target;

	public string message;

	public bool sendCollision;

	public Ef_MessageOnCollisionHit()
	{
		message = "Hit";
	}

	public void OnCollisionEnter(Collision collision)
	{
		if ((bool)target)
		{
			if (sendCollision)
			{
				target.SendMessage(message, collision, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				target.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
