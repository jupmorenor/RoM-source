using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveAroundTarget : MonoBehaviour
{
	public Transform target;

	public Transform emitter;

	public bool ajustRot;

	public Vector3 errOffset;

	public bool reFind;

	public bool spine;

	public bool fromEffectMessage;

	public bool targetToPlayerSide;

	public bool targetToEnemySide;

	public bool playerOnly;

	public bool randomChoice;

	public bool ignoreAlive;

	public int maxCandidatesNum;

	public BaseControl[] candidates;

	public string playerLayer;

	public string enemyLayer;

	private bool ready;

	public Ef_MoveAroundTarget()
	{
		errOffset = new Vector3(0f, 0f, 10f);
		fromEffectMessage = true;
		maxCandidatesNum = 10;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			emitter = emtr.transform;
			if (spine && (bool)emitter)
			{
				emitter = FindSpine(emitter);
			}
			SetTargetSideFromEmitter(emtr);
		}
	}

	public void Start()
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
		if (!target)
		{
			target = FindTarget(vector);
		}
		if (!target)
		{
			vector2 = vector + quaternion * errOffset;
			quaternion2 = Quaternion.Euler(0f, 180f, 0f) * quaternion;
		}
		else
		{
			vector2 = target.position;
			quaternion2 = target.rotation;
		}
		Vector3 vector3 = Quaternion.Inverse(quaternion) * (transform.position - vector);
		Quaternion quaternion3 = default(Quaternion);
		if (ajustRot)
		{
			quaternion3 = Quaternion.RotateTowards(quaternion, quaternion2, 1f);
			vector3 = quaternion3 * vector3;
		}
		else
		{
			vector3[0] *= -1f;
			vector3[2] *= -1f;
			quaternion3 = Quaternion.Euler(0f, 180f, 0f);
		}
		transform.position = vector2 + vector3;
		transform.rotation = quaternion3 * transform.rotation;
	}

	public Transform FindTarget(Vector3 pos)
	{
		Transform transform = null;
		object result;
		if (playerOnly)
		{
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if (!currentPlayer || !currentPlayer.IsReady)
			{
				result = null;
			}
			else
			{
				GameObject gameObject = null;
				gameObject = ((!currentPlayer.IsTensi) ? currentPlayer.akumaModel : currentPlayer.tensiModel);
				if ((bool)gameObject)
				{
					transform = gameObject.transform;
				}
				if ((bool)transform)
				{
					transform = FindSpine(transform);
				}
				result = transform;
			}
		}
		else
		{
			if (!ready)
			{
				int i = 0;
				BaseControl[] array = candidates;
				for (int length = array.Length; i < length; i = checked(i + 1))
				{
					if (array[i] != null)
					{
						ready = true;
						break;
					}
				}
			}
			if (!targetToPlayerSide && !targetToEnemySide)
			{
				if (this.gameObject.layer == LayerMask.NameToLayer(playerLayer))
				{
					targetToEnemySide = true;
				}
				else if (this.gameObject.layer == LayerMask.NameToLayer(enemyLayer))
				{
					targetToPlayerSide = true;
				}
			}
			BaseControl baseControl = null;
			if (!ready)
			{
				if (!targetToPlayerSide && !targetToEnemySide)
				{
					result = null;
					goto IL_032f;
				}
				candidates = new BaseControl[maxCandidatesNum];
				if (targetToPlayerSide)
				{
					BaseControl.CollectPlayerSideChars(candidates, maxCandidatesNum);
				}
				else if (targetToEnemySide)
				{
					BaseControl.CollectEnemySideChars(candidates, maxCandidatesNum);
				}
				ready = true;
			}
			float num = default(float);
			if (!randomChoice)
			{
				float num2 = 99999f;
				IEnumerator enumerator = candidates.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is BaseControl))
					{
						obj = RuntimeServices.Coerce(obj, typeof(BaseControl));
					}
					baseControl = (BaseControl)obj;
					if (baseControl != null && (ignoreAlive || baseControl.IsAlive))
					{
						num = (baseControl.transform.position - pos).sqrMagnitude;
						if (!(num >= num2))
						{
							transform = baseControl.transform;
							num2 = num;
						}
					}
				}
			}
			else
			{
				IEnumerator enumerator2 = candidates.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object obj2 = enumerator2.Current;
					if (!(obj2 is BaseControl))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(BaseControl));
					}
					baseControl = (BaseControl)obj2;
					if (baseControl != null && (ignoreAlive || baseControl.IsAlive))
					{
						num = (baseControl.transform.position - pos).sqrMagnitude;
						if (transform == null || UnityEngine.Random.Range(0, 3) < 1)
						{
							transform = baseControl.transform;
							float num2 = num;
						}
					}
				}
			}
			if (spine && (bool)transform)
			{
				transform = FindSpine(transform);
			}
			result = transform;
		}
		goto IL_032f;
		IL_032f:
		return (Transform)result;
	}

	public Transform FindSpine(Transform trg)
	{
		MerlinMotionPackControl component = trg.GetComponent<MerlinMotionPackControl>();
		if (component == null && trg.childCount >= 1)
		{
			Transform child = trg.GetChild(0);
			if (child != null)
			{
				component = child.GetComponent<MerlinMotionPackControl>();
			}
		}
		if (component != null)
		{
			Animation motionTarget = component.motionTarget;
			if (motionTarget != null)
			{
				Transform transform = motionTarget.transform;
				if (transform != null)
				{
					trg = transform;
					Transform transform2 = transform.Find("y_ang");
					if (transform2 != null)
					{
						trg = transform2;
						Transform transform3 = transform2.Find("cog");
						if (transform3 != null)
						{
							trg = transform3;
							Transform transform4 = transform3.Find("c_spine_a");
							if (transform4 != null)
							{
								trg = transform4;
							}
						}
					}
				}
			}
		}
		return trg;
	}

	public void SetTargetSideFromEmitter(MerlinActionControl emtr)
	{
		if (!reFind)
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
		if (fromEffectMessage)
		{
			targetToEnemySide = emtr.IsSidePlayer;
			targetToPlayerSide = emtr.IsSideEnemy;
		}
	}

	public void setTarget(Transform trgObj)
	{
		target = trgObj;
	}
}
