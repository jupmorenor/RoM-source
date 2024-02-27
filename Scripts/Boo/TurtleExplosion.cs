using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class TurtleExplosion : MonoBehaviour
{
	public Transform weaponJoint;

	public float radius;

	public float power;

	public bool done;

	public TurtleExplosion()
	{
		radius = 5f;
		power = 1000f;
	}

	public void Start()
	{
		weaponJoint = gameObject.transform.Find("y_ang/cog/r_weapon");
	}

	public void Update()
	{
		if (animation.isPlaying && RuntimeServices.op_Member("dead", animation.clip.name) && !done && !((double)animation[animation.clip.name].time <= 0.3))
		{
			doExplode();
		}
	}

	public void doExplode()
	{
		done = true;
		weaponJoint.parent = gameObject.transform;
		Rigidbody rigidbody = weaponJoint.gameObject.rigidbody;
		rigidbody.velocity = new Vector3(0f, -9.8f, 0f);
		rigidbody.AddExplosionForce(power, transform.position, radius, 3f);
	}
}
