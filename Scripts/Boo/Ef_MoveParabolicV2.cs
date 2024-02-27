using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveParabolicV2 : Ef_Base
{
	public Transform target;

	public bool findTarget;

	public float life;

	public float speed;

	public float accel;

	public float targetSpd;

	public Vector3 targetOffset;

	public float gravity;

	public float upSpeed;

	public bool autoUp;

	public int autoUpQuality;

	public float autoUpCorrection;

	public bool rotToVec;

	public Vector3 rotOffset;

	public float radius;

	public bool groundHit;

	public float upLength;

	public float boundForGravity;

	public bool collisionHit;

	public Ef_HomingBuffer.Side targetSide;

	public bool randomChoice;

	public bool ignoreAlive;

	public string playerLayer;

	public string enemyLayer;

	private Ef_HomingBuffer hmBuf;

	private Ef_HeightBuffer hiBuf;

	private Vector3 nrmVec;

	private Quaternion ofsRot;

	private Quaternion invOfsRot;

	private float sqrRad;

	private int destroyCount;

	private bool activeMode;

	private Ef_EmitActiveManager emitActive;

	private Ef_EmitManager emitManager;

	private float lstY;

	private Transform fstTrg;

	private float fstLife;

	private Ef_HomingBuffer.Side fstTrgSide;

	private float fstSpd;

	private float fstUp;

	private bool fstColi;

	private bool restart;

	private bool ready;

	public Ef_MoveParabolicV2()
	{
		findTarget = true;
		speed = 10f;
		targetSpd = 10f;
		targetOffset = Vector3.zero;
		gravity = 9.8f;
		upSpeed = 5f;
		autoUp = true;
		autoUpQuality = 8;
		autoUpCorrection = 1f;
		rotOffset = Vector3.zero;
		groundHit = true;
		upLength = 0.1f;
		collisionHit = true;
		targetSide = Ef_HomingBuffer.Side.FromEffectMessage;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		nrmVec = Vector3.forward;
		lstY = -1f;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		target = fstTrg;
		if (activeMode && emitActive != null)
		{
			emitActive.setTarget(target);
		}
		else if (emitManager != null)
		{
			emitManager.setTarget(target);
		}
		life = fstLife;
		targetSide = fstTrgSide;
		speed = fstSpd;
		upSpeed = fstUp;
		collisionHit = fstColi;
		destroyCount = 0;
		restart = true;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		restart = true;
	}

	public void Restart()
	{
		if (findTarget && target == null)
		{
			FindTarget();
		}
		if (target != null)
		{
			nrmVec = (target.position - transform.position).normalized;
		}
		else
		{
			nrmVec = transform.rotation * invOfsRot * Vector3.forward;
		}
		if (autoUp && target != null)
		{
			AutoUp((target.position - transform.position).magnitude);
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		if (restart)
		{
			Restart();
			restart = false;
		}
		checked
		{
			if (destroyCount > 0)
			{
				destroyCount--;
				if (destroyCount <= 0)
				{
					HitEnd();
					return;
				}
			}
			if (!(life <= 0f))
			{
				life -= deltaTime;
				if (!(life > 0f))
				{
					LifeEnd();
					return;
				}
			}
			UpdateMove();
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!ready)
		{
			Init();
		}
		if (emtr == null)
		{
			return;
		}
		if (hmBuf == null)
		{
			hmBuf = Ef_HomingBuffer.Current;
			if (hmBuf == null)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
		}
		if (targetSide == Ef_HomingBuffer.Side.ReturnToSelf)
		{
			target = emtr.transform;
			if (target != null)
			{
				target = Ef_HomingBuffer.FindSpine(target);
			}
			if (activeMode && emitActive != null)
			{
				emitActive.setTarget(target);
			}
			else if (emitManager != null)
			{
				emitManager.setTarget(target);
			}
			return;
		}
		if (targetSide == Ef_HomingBuffer.Side.TargetToPlayerTarget)
		{
			PlayerControl playerControl = emtr as PlayerControl;
			if (playerControl != null)
			{
				GameObject gameObject = playerControl.TargetChar;
				if (!gameObject)
				{
					gameObject = playerControl.searchTargetEnemy();
				}
				if ((bool)gameObject)
				{
					target = gameObject.transform;
					target = Ef_HomingBuffer.FindSpine(target);
					return;
				}
			}
		}
		if (targetSide != 0)
		{
			return;
		}
		string text = emtr.gameObject.name;
		if (text.Length > 0)
		{
			switch (text.Substring(0, 1))
			{
			case "P":
			case "C":
				targetSide = Ef_HomingBuffer.Side.TargetToEnemySide;
				break;
			case "E":
				targetSide = Ef_HomingBuffer.Side.TargetToPlayerSide;
				break;
			}
		}
	}

	public void OnCollisionEnter(Collision coli)
	{
		if (!ready)
		{
			Init();
		}
		if (collisionHit)
		{
			ContactPoint[] contacts = coli.contacts;
			if (contacts.Length > 0)
			{
				transform.position = contacts[0].point;
			}
			destroyCount = 2;
			speed = 0f;
			accel = 0f;
			targetSpd = 0f;
			collisionHit = false;
		}
	}

	public void Initialize()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		if (!ready)
		{
			fstTrg = target;
			fstLife = life;
			fstTrgSide = targetSide;
			fstSpd = speed;
			fstUp = upSpeed;
			fstColi = collisionHit;
			ofsRot = Quaternion.Euler(rotOffset);
			invOfsRot = Quaternion.Inverse(ofsRot);
			sqrRad = radius * radius;
			Ef_ActiveOn component = gameObject.GetComponent<Ef_ActiveOn>();
			bool num = component != null;
			if (num)
			{
				num = component.enable;
			}
			activeMode = num;
			emitActive = gameObject.GetComponent<Ef_EmitActiveManager>();
			emitManager = gameObject.GetComponent<Ef_EmitManager>();
			ready = true;
		}
	}

	public void FindTarget()
	{
		if (targetSide == Ef_HomingBuffer.Side.FromEffectMessage)
		{
			if (gameObject.layer == LayerMask.NameToLayer("PlayerAttackColi"))
			{
				targetSide = Ef_HomingBuffer.Side.TargetToEnemySide;
			}
			else if (gameObject.layer == LayerMask.NameToLayer("EnemyAttackColi"))
			{
				targetSide = Ef_HomingBuffer.Side.TargetToPlayerSide;
			}
		}
		if (hmBuf == null)
		{
			hmBuf = Ef_HomingBuffer.Current;
			if (hmBuf == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		Vector3 position = transform.position;
		target = hmBuf.FindTarget(position, targetSide, randomChoice, ignoreAlive);
		if (activeMode && emitActive != null)
		{
			emitActive.setTarget(target);
		}
		else if (emitManager != null)
		{
			emitManager.setTarget(target);
		}
	}

	public void AutoUp(float dist)
	{
		float num = 0f;
		if (accel == 0f || fstSpd == targetSpd)
		{
			num = ((fstSpd == 0f) ? gravity : (dist / fstSpd));
		}
		else
		{
			if (autoUpQuality <= 0)
			{
				autoUpQuality = 1;
			}
			float num2 = dist;
			float num3 = fstSpd;
			float num4 = accel / (float)autoUpQuality;
			bool num5 = num4 == 0f;
			if (!num5)
			{
				num5 = num3 == targetSpd;
			}
			bool flag = num5;
			float num6 = 1f / (float)autoUpQuality;
			int num7 = 0;
			int num8 = checked(autoUpQuality * 4);
			if (num8 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num7 < num8)
			{
				int num9 = num7;
				num7++;
				num2 -= num3 * num6;
				if (!(num2 > 0f))
				{
					break;
				}
				if (!flag)
				{
					if (!(num3 >= targetSpd))
					{
						num3 += num4;
						if (!(num3 <= targetSpd))
						{
							num3 = targetSpd;
							flag = true;
						}
					}
					else if (!(num3 <= targetSpd))
					{
						num3 -= num4;
						if (!(num3 >= targetSpd))
						{
							num3 = targetSpd;
							flag = true;
						}
					}
				}
				num += num6;
			}
		}
		upSpeed = gravity * num / 2f * autoUpCorrection;
	}

	public void UpdateMove()
	{
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		float num = deltaTime;
		float num2 = speed * num;
		if (!(radius <= 0f) && (bool)target)
		{
			Vector3 position2 = target.position;
			float sqrMagnitude = (position2 - position).sqrMagnitude;
			if (!(sqrMagnitude > sqrRad))
			{
				HitEnd();
				return;
			}
			if (!(num2 * num2 <= sqrMagnitude))
			{
				num2 = Mathf.Sqrt(sqrMagnitude);
			}
		}
		if (groundHit)
		{
			hiBuf = Ef_HeightBuffer.Current;
			if (!(hiBuf == null))
			{
				object[] height = hiBuf.GetHeight(position);
				float num3 = RuntimeServices.UnboxSingle(height[0]);
				Vector3 vector = (Vector3)height[1];
				num3 += upLength;
				if (!(position.y > num3))
				{
					position.y = num3;
					if (boundForGravity <= 0f)
					{
						HitEnd();
						return;
					}
					float num4 = Mathf.Abs(upSpeed);
					if (num4 <= 5f)
					{
						transform.position = position;
						HitEnd();
						return;
					}
					upSpeed = num4 * boundForGravity;
				}
			}
		}
		position += nrmVec * num2;
		if (rotToVec)
		{
			Vector3 forward = nrmVec * speed;
			forward.y += upSpeed;
			transform.rotation = Quaternion.LookRotation(forward, Vector3.up) * ofsRot;
		}
		if (!(speed >= targetSpd))
		{
			speed += accel * num;
			if (!(speed <= targetSpd))
			{
				speed = targetSpd;
			}
		}
		else if (!(speed <= targetSpd))
		{
			speed -= accel * num;
			if (!(speed >= targetSpd))
			{
				speed = targetSpd;
			}
		}
		position.y += upSpeed * num;
		lstY = position.y;
		upSpeed -= gravity * num;
		if (!(upSpeed >= -20f))
		{
			upSpeed = -20f;
		}
		transform.position = position;
	}

	public void HitEnd()
	{
		if (activeMode)
		{
			if (emitActive != null)
			{
				emitActive.EmitOnHit();
			}
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(value: false);
			return;
		}
		if (emitManager != null)
		{
			emitManager.EmitOnHit();
		}
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
	}

	public void LifeEnd()
	{
		if (activeMode)
		{
			if (emitActive != null)
			{
				emitActive.EmitOnEnd();
			}
			gameObject.SendMessage("OnDeactive", SendMessageOptions.DontRequireReceiver);
			gameObject.SetActive(value: false);
			return;
		}
		if (emitManager != null)
		{
			emitManager.EmitOnEnd();
		}
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
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
