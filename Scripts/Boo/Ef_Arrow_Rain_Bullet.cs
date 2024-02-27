using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Arrow_Rain_Bullet : Ef_GroundHeight
{
	public float speed;

	public float life;

	public Transform flareObj;

	public Transform trailObj;

	public GameObject hitObj;

	public float pHeight;

	private bool hitArrow;

	private int sendRank;

	public Ef_Arrow_Rain_Bullet()
	{
		speed = 40f;
		life = 1f;
	}

	public override void Start()
	{
		base.Start();
		if (!flareObj)
		{
			flareObj = transform.Find("Flare");
		}
		if (!trailObj)
		{
			trailObj = transform.Find("Trail");
		}
		flareObj.particleSystem.Stop();
		trailObj.gameObject.SetActive(value: false);
	}

	public void Update()
	{
		if (!hitArrow)
		{
			if (!(transform.position.y - pHeight >= 10f))
			{
				flareObj.particleSystem.Play();
				trailObj.gameObject.SetActive(value: true);
			}
			transform.Translate(Vector3.forward * speed * deltaTime);
			if (!(transform.position.y - pHeight >= 2f))
			{
				object[] groundHeight = GetGroundHeight(transform.position);
				bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
				float num = RuntimeServices.UnboxSingle(groundHeight[1]);
				Vector3 vector = (Vector3)groundHeight[2];
				if (flag)
				{
					num += 0.3f;
				}
				if (!(transform.position.y > num))
				{
					transform.Translate(Vector3.forward * (transform.position.y - num));
					Hit();
					hitArrow = true;
				}
			}
		}
		else if (!(life <= 0f))
		{
			life -= deltaTime;
			if (!(life > 0f))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void OnCollisionEnter(Collision contact)
	{
		if (!hitArrow && contact.gameObject.tag == "Enemy")
		{
			Stick(contact);
			Hit();
			hitArrow = true;
		}
	}

	public void Stick(Collision contact)
	{
		Transform transform = null;
		Transform transform2 = contact.transform;
		if ((bool)transform2)
		{
			Transform parent = transform2.parent;
			if ((bool)parent)
			{
				Transform transform3 = parent.Find("c_spine_a");
				if (!transform3)
				{
					transform3 = parent.Find("c_spine");
				}
				if ((bool)transform3)
				{
					Transform transform4 = parent.Find("c_spine_b");
					transform = ((!transform4) ? transform3 : transform4);
				}
				else
				{
					transform = parent;
				}
			}
			else
			{
				transform = transform2;
			}
		}
		if ((bool)transform)
		{
			this.transform.parent = transform;
			this.transform.localPosition = this.transform.localRotation * new Vector3(0f, 0f, -0.4f);
		}
	}

	public void Hit()
	{
		flareObj.particleSystem.Stop();
		flareObj.particleSystem.Clear();
		trailObj.gameObject.SetActive(value: false);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, Quaternion.identity);
		if (sendRank != 0)
		{
			gameObject.SendMessage("setRank", sendRank, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void setRank(int rank)
	{
		sendRank = rank;
	}
}
