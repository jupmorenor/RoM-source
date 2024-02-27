using System;
using UnityEngine;

[Serializable]
public class Ef_MoveAroundTargetV2 : MonoBehaviour
{
	public Transform target;

	public Transform emitter;

	public bool ajustRot;

	public Vector3 errOffset;

	[HideInInspector]
	public bool reFind;

	public Ef_HomingBuffer.Side targetSide;

	public bool randomChoice;

	public bool ignoreAlive;

	private Ef_HomingBuffer hmBuf;

	private Transform fstTrg;

	private Ef_HomingBuffer.Side fstTrgSide;

	private bool ready;

	public Ef_MoveAroundTargetV2()
	{
		errOffset = new Vector3(0f, 0f, 10f);
		targetSide = Ef_HomingBuffer.Side.FromEffectMessage;
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		target = fstTrg;
		targetSide = fstTrgSide;
		Move();
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
		Move();
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
		emitter = emtr.transform;
		if (hmBuf == null)
		{
			hmBuf = Ef_HomingBuffer.Current;
			if (hmBuf == null)
			{
				UnityEngine.Object.Destroy(this.gameObject);
				return;
			}
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

	public void Init()
	{
		if (ready)
		{
			return;
		}
		fstTrg = target;
		fstTrgSide = targetSide;
		if (hmBuf == null)
		{
			hmBuf = Ef_HomingBuffer.Current;
			if (hmBuf == null)
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		ready = true;
	}

	public void Move()
	{
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		if (!emitter)
		{
			vector = Vector3.zero;
			quaternion = Quaternion.identity;
		}
		else
		{
			vector = emitter.position;
			quaternion = emitter.rotation;
		}
		Vector3 vector2 = default(Vector3);
		Quaternion quaternion2 = default(Quaternion);
		if (target == null)
		{
			FindTarget(vector);
		}
		if (target == null)
		{
			vector2 = vector + quaternion * errOffset;
			quaternion2 = quaternion;
		}
		else
		{
			vector2 = target.position;
			quaternion2 = target.rotation;
		}
		Vector3 vector3 = Quaternion.Inverse(quaternion) * (transform.position - vector);
		Quaternion quaternion3 = Quaternion.identity;
		if (ajustRot)
		{
			quaternion3 = Quaternion.RotateTowards(quaternion, quaternion2, 1f);
			vector3 = quaternion3 * vector3;
		}
		transform.position = vector2 + vector3;
		transform.rotation = quaternion3 * transform.rotation;
	}

	public void FindTarget(Vector3 emtPos)
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
		target = hmBuf.FindTargetRoot(emtPos, targetSide, randomChoice, ignoreAlive);
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
