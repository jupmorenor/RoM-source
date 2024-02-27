using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveLinearly : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float targetSpd;

	public bool reFind;

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

	public bool returnToSelf;

	public Ef_MoveLinearlyCollision quickCollision;

	private Vector3 nrmVec;

	private bool lstLeft;

	private float timer;

	private float vSpd;

	public Ef_MoveLinearly()
	{
		speed = 6f;
		accel = 6f;
		targetSpd = 6f;
		fromEffectMessage = true;
		maxCandidatesNum = 10;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		nrmVec = Vector3.one;
	}

	public void Start()
	{
		Vector3 position = transform.position;
		if (quickCollision.active)
		{
			quickCollision.ThisGameObj = gameObject;
		}
		int num = default(int);
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
		if (target == null)
		{
			target = FindTarget(position);
		}
		if (target == null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			nrmVec = (target.position - position).normalized;
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (quickCollision.active)
		{
			quickCollision.setEmtr(emtr);
		}
		if (emtr == null)
		{
			return;
		}
		if (returnToSelf)
		{
			target = emtr.transform;
			if ((bool)target)
			{
				target = FindSpine(target);
			}
		}
		else
		{
			SetcandidatesideFromEmitter(emtr);
		}
	}

	public void Update()
	{
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
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
		float num = speed * deltaTime;
		Vector3 vector = default(Vector3);
		Vector3 trgVec = default(Vector3);
		if ((bool)target)
		{
			vector = target.position;
			trgVec = vector - position;
			float sqrMagnitude = trgVec.sqrMagnitude;
			if (!(num * num <= sqrMagnitude))
			{
				num = Mathf.Sqrt(sqrMagnitude);
			}
		}
		Vector3 vector2 = nrmVec * num;
		position += vector2;
		if ((bool)target && quickCollision.active)
		{
			quickCollision.setTarget(target);
			quickCollision.Update(position, rotation, trgVec);
		}
		transform.position = position;
	}

	public Transform FindTarget(Vector3 pos)
	{
		Transform transform = null;
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
			BaseControl baseControl = null;
			if (!ready)
			{
				if (!targetToPlayerSide && !targetToEnemySide)
				{
					result = null;
					goto IL_038e;
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
				IEnumerator enumerator = candidates.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					if (!(obj is BaseControl))
					{
						obj = RuntimeServices.Coerce(obj, typeof(BaseControl));
					}
					baseControl = (BaseControl)obj;
					if (baseControl != null)
					{
						ready = true;
					}
				}
			}
			float num = default(float);
			bool flag = false;
			if (!randomChoice)
			{
				float num2 = 99999f;
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
						flag = true;
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
				IEnumerator enumerator3 = candidates.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					object obj3 = enumerator3.Current;
					if (!(obj3 is BaseControl))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(BaseControl));
					}
					baseControl = (BaseControl)obj3;
					if (baseControl != null && (ignoreAlive || baseControl.IsAlive))
					{
						flag = true;
						num = (baseControl.transform.position - pos).sqrMagnitude;
						if (transform == null || UnityEngine.Random.Range(0, 3) < 1)
						{
							transform = baseControl.transform;
							float num2 = num;
						}
					}
				}
			}
			if (!flag)
			{
				ready = false;
			}
			if ((bool)transform)
			{
				transform = FindSpine(transform);
			}
			result = transform;
		}
		goto IL_038e;
		IL_038e:
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

	public void SetcandidatesideFromEmitter(MerlinActionControl emtr)
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
					target = FindSpine(target);
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
		if (quickCollision.active)
		{
			quickCollision.setTarget(trgObj);
		}
	}

	public void setColor(Color color)
	{
		if (quickCollision.active)
		{
			quickCollision.setColor(color);
		}
	}

	public void setTime(float time)
	{
		if (quickCollision.active)
		{
			quickCollision.setTime(time);
		}
	}

	public void setRank(int rank)
	{
		if (quickCollision.active)
		{
			quickCollision.setRank(rank);
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (quickCollision.active)
		{
			quickCollision.setPoppetMaster(mpets);
		}
	}
}
