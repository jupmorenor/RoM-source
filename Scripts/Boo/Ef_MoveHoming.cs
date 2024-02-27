using System;
using UnityEngine;

[Serializable]
public class Ef_MoveHoming : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float targetSpd;

	public float rotSpd;

	public float rotAccel;

	public float targetRotSpd;

	public Vector3 targetOffset;

	public Vector3 rotOffset;

	public float radius;

	public Ef_HomingBuffer.Side targetSide;

	public bool randomChoice;

	public bool ignoreAlive;

	private Ef_HomingBuffer hmBuf;

	public bool updateTarget;

	public float interval;

	private Quaternion rot;

	private Quaternion ofsRot;

	private float sqrRad;

	private float timer;

	private bool activeMode;

	private Ef_EmitActiveManager emitActive;

	private Ef_EmitManager emitManager;

	private Transform fstTrg;

	private Ef_HomingBuffer.Side fstTrgSide;

	private float fstSpd;

	private float fstRotSpd;

	private bool ready;

	public Ef_MoveHoming()
	{
		speed = 6f;
		targetSpd = 6f;
		rotSpd = 180f;
		targetRotSpd = 180f;
		targetOffset = Vector3.zero;
		rotOffset = Vector3.zero;
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
		timer = 0f;
		speed = fstSpd;
		rotSpd = fstRotSpd;
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
			fstRotSpd = rotSpd;
			rot = transform.rotation;
			ofsRot = Quaternion.Euler(rotOffset);
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

	public void MoveUpdate()
	{
		float num = deltaTime;
		Vector3 position = transform.position;
		if (updateTarget || target == null)
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
		if (!(rotSpd >= targetRotSpd))
		{
			rotSpd += rotAccel * num;
			if (!(rotSpd <= targetRotSpd))
			{
				rotSpd = targetRotSpd;
			}
		}
		else if (!(rotSpd <= targetRotSpd))
		{
			rotSpd -= rotAccel * num;
			if (!(rotSpd >= targetRotSpd))
			{
				rotSpd = targetRotSpd;
			}
		}
		Quaternion quaternion = default(Quaternion);
		float num2 = speed * num;
		if ((bool)target)
		{
			Vector3 forward = target.position + targetOffset - position;
			float sqrMagnitude = forward.sqrMagnitude;
			quaternion = Quaternion.LookRotation(forward, Vector3.up);
			if (!(sqrRad <= 0f))
			{
				if (!(sqrMagnitude >= sqrRad))
				{
					HitEnd();
					return;
				}
				if (!(num2 * num2 <= sqrMagnitude))
				{
					num2 = Mathf.Sqrt(sqrMagnitude);
				}
			}
		}
		else
		{
			Vector3 eulerAngles = rot.eulerAngles;
			eulerAngles.y = 0f;
			quaternion = Quaternion.Euler(eulerAngles);
		}
		rot = Quaternion.RotateTowards(rot, quaternion, rotSpd * num);
		position += rot * new Vector3(0f, 0f, num2);
		transform.rotation = rot * ofsRot;
		transform.position = position;
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

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
