using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_FlyingObject : Ef_GroundHeight
{
	public float life;

	public float delay;

	public float speed;

	public float accel;

	public float brake;

	public float gravity;

	public float fstUp;

	public Vector3 rotOffset;

	public bool groundHit;

	public bool collisionHit;

	public bool destroyOnHit;

	public float destroyOnHitDelayTime;

	public float upLength;

	public GameObject hitObj;

	public bool ajustRot;

	private Vector3 velocity;

	private Quaternion ofsRot;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_FlyingObject()
	{
		life = 1f;
		speed = 5f;
		gravity = 9.8f;
		fstUp = 5f;
		rotOffset = Vector3.zero;
		groundHit = true;
		collisionHit = true;
		destroyOnHit = true;
		upLength = 0.1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public override void Start()
	{
		base.Start();
		ofsRot = Quaternion.Euler(rotOffset);
		velocity = ofsRot * transform.forward;
		Vector2 vector = new Vector2(velocity.x, velocity.z).normalized * speed;
		velocity = new Vector3(vector.x, velocity.y * speed + fstUp, vector.y);
		transform.parent = null;
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		transform.position += velocity * deltaTime;
		velocity.y -= gravity * deltaTime;
		if (!(accel <= 0f))
		{
			if (velocity == Vector3.zero)
			{
				velocity = ofsRot * transform.forward * 0.001f;
			}
			velocity += velocity.normalized * accel * deltaTime;
		}
		if (!(brake <= 0f) && velocity != Vector3.zero)
		{
			float magnitude = velocity.magnitude;
			magnitude -= brake * deltaTime;
			if (!(magnitude >= 0f))
			{
				magnitude = 0f;
			}
			velocity = velocity.normalized * magnitude;
		}
		Ef_DestroyReleaseV2 component;
		if (groundHit)
		{
			object[] groundHeight = GetGroundHeight(transform.position);
			bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
			float num = RuntimeServices.UnboxSingle(groundHeight[1]);
			Vector3 vector = (Vector3)groundHeight[2];
			if (flag)
			{
				num += upLength;
				if (!(transform.position.y > num))
				{
					Vector3 position = transform.position;
					position.y = num;
					transform.position = position;
					Emit();
					component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
					if (component != null)
					{
						component.Release();
					}
					else
					{
						Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
						if (component2 != null)
						{
							component2.Release();
						}
					}
					UnityEngine.Object.Destroy(gameObject);
					return;
				}
			}
		}
		life -= deltaTime;
		if (life > 0f)
		{
			return;
		}
		Emit();
		component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public void Landing()
	{
		velocity.y = 0f;
	}

	public void Emit()
	{
		if (!hitObj)
		{
			return;
		}
		GameObject gameObject = null;
		gameObject = ((!ajustRot) ? ((GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, Quaternion.identity)) : ((GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, transform.rotation)));
		if (!gameObject)
		{
			return;
		}
		MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component != null)
		{
			if (!(component.Command.parent != null))
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			gameObject.layer = this.gameObject.layer;
			MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject.AddComponent<MerlinAttackCommandHolder>();
			merlinAttackCommandHolder.Command = component.Command;
		}
		if ((bool)sendTarget)
		{
			gameObject.SendMessage("setTarget", sendTarget, SendMessageOptions.DontRequireReceiver);
		}
		if (sendColor != new Color(0f, 0f, 0f, 0f))
		{
			gameObject.SendMessage("setColor", sendColor, SendMessageOptions.DontRequireReceiver);
		}
		if (sendTime != 0f)
		{
			gameObject.SendMessage("setTime", sendTime, SendMessageOptions.DontRequireReceiver);
		}
		if (sendRank != 0)
		{
			gameObject.SendMessage("setRank", sendRank, SendMessageOptions.DontRequireReceiver);
		}
		if (sendEmtr != null)
		{
			gameObject.SendMessage("emitEffectMessage", sendEmtr, SendMessageOptions.DontRequireReceiver);
		}
		if (sendPetM != null)
		{
			gameObject.SendMessage("setPoppetMaster", sendPetM, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void setTarget(Transform trgObj)
	{
		sendTarget = trgObj;
	}

	public void setColor(Color color)
	{
		sendColor = color;
	}

	public void setTime(float time)
	{
		sendTime = time;
	}

	public void setRank(int rank)
	{
		sendRank = rank;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		sendPetM = mpets;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
		PlayerControl playerControl = emtr as PlayerControl;
		if (!(playerControl == null))
		{
			GameObject gameObject = playerControl.TargetChar;
			if (!gameObject)
			{
				gameObject = playerControl.searchTargetEnemy();
			}
			if ((bool)gameObject)
			{
				Transform transform = gameObject.transform;
			}
		}
	}

	public void OnCollisionEnter()
	{
		if (collisionHit)
		{
			Emit();
			if (destroyOnHit)
			{
				UnityEngine.Object.Destroy(gameObject, destroyOnHitDelayTime);
			}
		}
	}
}
