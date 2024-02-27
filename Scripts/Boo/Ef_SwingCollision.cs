using System;
using UnityEngine;

[Serializable]
public class Ef_SwingCollision : MonoBehaviour
{
	public Ef_Swing swing;

	public bool enterOnly;

	public float power;

	public Ef_SwingCollision()
	{
		power = 5f;
	}

	public void OnTriggerEnter(Collider coli)
	{
		if (enterOnly)
		{
			TriggerSwing(coli);
		}
	}

	public void OnTriggerStay(Collider coli)
	{
		if (!enterOnly)
		{
			TriggerSwing(coli);
		}
	}

	public void TriggerSwing(Collider coli)
	{
		if (!swing)
		{
			Transform parent = transform;
			int num = 0;
			while (num < 20)
			{
				int num2 = num;
				num++;
				swing = parent.gameObject.GetComponent<Ef_Swing>();
				if ((bool)swing)
				{
					break;
				}
				parent = parent.parent;
				if (!parent)
				{
					break;
				}
			}
		}
		if ((bool)swing)
		{
			Vector3 vector = transform.position - coli.attachedRigidbody.position;
			swing.AddForce(transform, vector * power, horizontal: true);
		}
	}

	public void OnCollisionEnter(Collision coli)
	{
		if (enterOnly)
		{
			CollisionSwing(coli);
		}
	}

	public void OnCollisionStay(Collision coli)
	{
		if (!enterOnly)
		{
			CollisionSwing(coli);
		}
	}

	public void CollisionSwing(Collision coli)
	{
		if (!swing)
		{
			Transform parent = transform;
			int num = 0;
			while (num < 20)
			{
				int num2 = num;
				num++;
				swing = parent.gameObject.GetComponent<Ef_Swing>();
				if ((bool)swing)
				{
					break;
				}
				parent = parent.parent;
				if (!parent)
				{
					break;
				}
			}
		}
		if ((bool)swing)
		{
			Vector3 vector = transform.position - coli.contacts[0].point;
			swing.AddForce(transform, vector * power, horizontal: true);
		}
	}
}
