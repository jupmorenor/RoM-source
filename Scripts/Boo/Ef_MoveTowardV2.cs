using System;
using UnityEngine;

[Serializable]
public class Ef_MoveTowardV2 : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float targetSpd;

	public float angSpd;

	public float angAccel;

	public float trgAngSpd;

	public Vector3 targetOffset;

	public float angOffset;

	public float radius;

	public Ef_HomingBuffer.Side targetSide;

	public bool randomChoice;

	public bool ignoreAlive;

	private Ef_HomingBuffer hmBuf;

	public bool updateTarget;

	public float interval;

	public float verticalForce;

	private float ang;

	private bool lstLeft;

	private float sqrRad;

	private float timer;

	private float vSpd;

	private bool activeMode;

	private Ef_EmitActiveManager emitActive;

	private Ef_EmitManager emitManager;

	private Transform fstTrg;

	private Ef_HomingBuffer.Side fstTrgSide;

	private float fstSpd;

	private float fstAngSpd;

	private bool ready;

	public Ef_MoveTowardV2()
	{
		speed = 6f;
		targetSpd = 6f;
		angSpd = 180f;
		angAccel = 180f;
		trgAngSpd = 180f;
		targetOffset = Vector3.zero;
		radius = 0.5f;
		targetSide = Ef_HomingBuffer.Side.FromEffectMessage;
		updateTarget = true;
		interval = 1f;
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
		targetSide = fstTrgSide;
		ang = transform.eulerAngles.y - angOffset;
		lstLeft = false;
		timer = 0f;
		speed = fstSpd;
		angSpd = fstAngSpd;
		vSpd = 0f;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Update()
	{
		if (!ready)
		{
			Init();
		}
		MoveUpdate();
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
			fstTrgSide = targetSide;
			fstSpd = speed;
			fstAngSpd = angSpd;
			sqrRad = radius * radius;
			ang = transform.eulerAngles.y - angOffset;
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

	public void MoveUpdate()
	{
		float num = deltaTime;
		Vector3 position = transform.position;
		if (updateTarget)
		{
			timer -= num;
			if (!(timer > 0f))
			{
				FindTarget();
				timer = interval;
			}
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
		float num2 = speed * num;
		Vector3 vector = default(Vector3);
		Vector3 trgVec = default(Vector3);
		float sqrMagnitude = default(float);
		if ((bool)target)
		{
			vector = target.position + target.rotation * targetOffset;
			trgVec = vector - position;
			sqrMagnitude = trgVec.sqrMagnitude;
			if (!(num2 * num2 <= sqrMagnitude))
			{
				num2 = Mathf.Sqrt(sqrMagnitude);
			}
		}
		Vector3 vector2 = AngToVec(ang, num2);
		position += vector2;
		if ((bool)target)
		{
			if (VecToTurn(vector2, trgVec))
			{
				if (lstLeft)
				{
					ang += angSpd * num;
				}
				else
				{
					ang += angSpd * num / 2f;
					lstLeft = true;
				}
				if (!(ang <= 360f))
				{
					ang -= 360f;
				}
			}
			else
			{
				if (lstLeft)
				{
					ang -= angSpd * num / 2f;
					lstLeft = false;
				}
				else
				{
					ang -= angSpd * num;
				}
				if (!(ang >= -360f))
				{
					ang += 360f;
				}
			}
			if (!(angSpd >= trgAngSpd))
			{
				angSpd += angAccel * num;
				if (!(angSpd <= trgAngSpd))
				{
					angSpd = trgAngSpd;
				}
			}
			else if (!(angSpd <= trgAngSpd))
			{
				angSpd -= angAccel * num;
				if (!(angSpd >= trgAngSpd))
				{
					angSpd = trgAngSpd;
				}
			}
			if (!(verticalForce <= 0f))
			{
				float num3 = vector.y - position.y;
				if (!(num3 <= 0f))
				{
					vSpd += verticalForce * num;
					if (!(vSpd <= num3))
					{
						vSpd = num3;
					}
				}
				else if (!(num3 >= 0f))
				{
					vSpd -= verticalForce * num;
					if (!(vSpd >= num3))
					{
						vSpd = num3;
					}
				}
				position.y += vSpd * num;
			}
		}
		if (!(radius <= 0f) && (bool)target)
		{
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
		transform.position = position;
		transform.eulerAngles = new Vector3(0f, ang + angOffset, 0f);
	}

	public void LookTarget()
	{
		if ((bool)target)
		{
			Vector3 position = transform.position;
			Vector3 position2 = target.position;
			Vector3 vec = new Vector3(position2.x - position.x, 0f, position2.z - position.z);
			ang = VecToAng(vec);
		}
	}

	public void FindTarget()
	{
		if (hmBuf == null)
		{
			hmBuf = Ef_HomingBuffer.Current;
			if (hmBuf == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
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
		Vector3 position = transform.position;
		target = hmBuf.FindTargetRoot(position, targetSide, randomChoice, ignoreAlive);
		if (activeMode && emitActive != null)
		{
			emitActive.setTarget(target);
		}
		else if (emitManager != null)
		{
			emitManager.setTarget(target);
		}
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

	public float VecToAng(Vector3 vec)
	{
		float num = 57.29578f;
		float num2 = vec[2];
		float num3 = vec[0];
		float num4 = 0f;
		if (!(Mathf.Abs(num2) <= Mathf.Abs(num3)))
		{
			if (!(num2 <= 0f))
			{
				num4 = Mathf.Atan(num3 / num2) * num;
			}
			else if (!(num2 >= 0f))
			{
				num4 = Mathf.Atan(num3 / num2) * num + 180f;
				if (!(num4 <= 180f))
				{
					num4 -= 360f;
				}
			}
		}
		else if (!(num3 <= 0f))
		{
			num4 = (0f - Mathf.Atan(num2 / num3)) * num + 90f;
		}
		else if (!(num3 >= 0f))
		{
			num4 = (0f - Mathf.Atan(num2 / num3)) * num - 90f;
		}
		return num4;
	}

	public bool VecToTurn(Vector3 vec, Vector3 trgVec)
	{
		return vec[0] * trgVec[2] - vec[2] * trgVec[0] < 0f;
	}

	public Vector3 AngToVec(float angle, float scala)
	{
		float f = angle * 0.01745329f;
		return new Vector3(scala * Mathf.Sin(f), 0f, scala * Mathf.Cos(f));
	}

	public Vector3 VecRotate(Vector3 vec, int angle)
	{
		float f = (float)angle * 0.01745329f;
		float num = Mathf.Sin(f);
		float num2 = Mathf.Cos(f);
		float num3 = vec[0];
		float num4 = vec[2];
		vec[0] = num3 * num2 - num4 * num;
		vec[2] = num3 * num + num4 * num2;
		return vec;
	}

	public Vector3 VecRotate90(Vector3 vec, int angle)
	{
		Vector3 result = vec;
		switch (angle)
		{
		case -270:
		case 90:
			result[0] = 0f - vec[2];
			result[2] = vec[0];
			break;
		case -90:
		case 270:
			result[0] = vec[2];
			result[2] = 0f - vec[0];
			break;
		case -180:
		case 180:
			result[0] = 0f - vec[0];
			result[2] = 0f - vec[2];
			break;
		}
		return result;
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
