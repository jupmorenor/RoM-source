using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveParabolic : Ef_Base
{
	public float life;

	public float delay;

	public float speed;

	public float accel;

	public float targetSpd;

	public float gravity;

	public float upSpeed;

	public Vector3 rotOffset;

	public bool groundHit;

	public bool collisionHit;

	public float upLength;

	public GameObject hitObj;

	public bool ajustRot;

	public float boundForGravity;

	private int destroyCount;

	private Vector2 velocity;

	private Vector3 nrmVel;

	private Quaternion ofsRot;

	private Ef_HeightBuffer hBuf;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_MoveParabolic()
	{
		life = 1f;
		speed = 5f;
		targetSpd = 20f;
		gravity = 9.8f;
		upSpeed = 5f;
		rotOffset = Vector3.zero;
		groundHit = true;
		collisionHit = true;
		upLength = 0.1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		if (groundHit)
		{
			hBuf = Ef_HeightBuffer.Current;
			if (hBuf == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		ofsRot = Quaternion.Euler(rotOffset);
		Vector3 vector = Quaternion.Inverse(ofsRot) * transform.forward;
		nrmVel = new Vector2(vector[0], vector[2]);
		if (nrmVel == (Vector3)Vector2.zero)
		{
			nrmVel = new Vector2(0f, 0.001f);
		}
		velocity = nrmVel * speed;
		if (gravity != 0f)
		{
			upSpeed += vector[1] * speed;
		}
		transform.parent = null;
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		checked
		{
			if (destroyCount > 0)
			{
				destroyCount--;
				if (destroyCount <= 0)
				{
					Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
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
			Vector3 position = transform.position;
			velocity = nrmVel * speed;
			position += new Vector3(velocity[0], upSpeed, velocity[1]) * deltaTime;
			if (!(speed >= targetSpd))
			{
				speed += accel * deltaTime;
				if (!(speed <= targetSpd))
				{
					speed = targetSpd;
				}
			}
			else if (!(speed <= targetSpd))
			{
				speed -= accel * deltaTime;
				if (!(speed >= targetSpd))
				{
					speed = targetSpd;
				}
			}
			upSpeed -= gravity * deltaTime;
			if (groundHit)
			{
				if (hBuf == null)
				{
					Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
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
				object[] height = hBuf.GetHeight(position);
				float num = RuntimeServices.UnboxSingle(height[0]);
				Vector3 vector = (Vector3)height[1];
				num += upLength;
				if (!(position[1] > num))
				{
					position[1] = num;
					if (boundForGravity <= 0f)
					{
						transform.position = position;
						Emit();
						Ef_DestroyReleaseV2 component = gameObject.GetComponent<Ef_DestroyReleaseV2>();
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
					upSpeed = Mathf.Abs(upSpeed) * boundForGravity;
					if (!(upSpeed >= 1f))
					{
						boundForGravity = 0f;
					}
				}
			}
			transform.position = position;
			life -= deltaTime;
			if (!(life > 0f))
			{
				Emit();
				Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
				if ((bool)component2)
				{
					component2.Release();
				}
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void Landing()
	{
		velocity.y = 0f;
	}

	public void Emit()
	{
		if (ajustRot)
		{
			Emit(transform.position, transform.rotation);
		}
		else
		{
			Emit(transform.position, Quaternion.identity);
		}
	}

	public void Emit(Vector3 pos)
	{
		if (ajustRot)
		{
			Emit(pos, transform.rotation);
		}
		else
		{
			Emit(pos, Quaternion.identity);
		}
	}

	public void Emit(Vector3 pos, Quaternion rot)
	{
		if (!hitObj)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(hitObj, pos, rot);
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

	public void OnCollisionEnter(Collision coli)
	{
		if (collisionHit)
		{
			ContactPoint[] contacts = coli.contacts;
			if (contacts.Length > 0)
			{
				Emit(contacts[0].point);
			}
			else
			{
				Emit();
			}
			destroyCount = 2;
			collisionHit = false;
		}
	}
}
