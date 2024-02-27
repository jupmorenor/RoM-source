using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveToward : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float targetSpd;

	public float angSpd;

	public float angAccel;

	public float trgAngSpd;

	public float angOffset;

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

	public bool updateTarget;

	public float interval;

	public bool returnToSelf;

	public float verticalForce;

	public Ef_MoveTowardCollision quickCollision;

	private float ang;

	private bool lstLeft;

	private float timer;

	private float vSpd;

	public Ef_MoveToward()
	{
		speed = 6f;
		accel = 6f;
		targetSpd = 6f;
		angSpd = 180f;
		angAccel = 180f;
		trgAngSpd = 180f;
		fromEffectMessage = true;
		maxCandidatesNum = 10;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		updateTarget = true;
		interval = 1f;
	}

	public void Start()
	{
		ang = transform.eulerAngles[1] - angOffset;
		if (quickCollision.active)
		{
			quickCollision.ThisGameObj = gameObject;
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
			if (target != null)
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
		if (updateTarget || target == null)
		{
			timer -= deltaTime;
			if (!(timer > 0f))
			{
				target = FindTarget(position);
				timer = interval;
			}
		}
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
			float sqrMagnitude = new Vector2(trgVec[0], trgVec[2]).sqrMagnitude;
			if (!(num * num <= sqrMagnitude))
			{
				num = Mathf.Sqrt(sqrMagnitude);
			}
		}
		Vector3 vector2 = AngToVec(ang, num);
		position += vector2;
		if ((bool)target)
		{
			if (VecToTurn(vector2, trgVec))
			{
				ang += angSpd * deltaTime;
				if (!(ang <= 360f))
				{
					ang -= 360f;
				}
			}
			else
			{
				ang -= angSpd * deltaTime;
				if (!(ang >= -360f))
				{
					ang += 360f;
				}
			}
			if (!(angSpd >= trgAngSpd))
			{
				angSpd += angAccel * deltaTime;
				if (!(angSpd <= trgAngSpd))
				{
					angSpd = trgAngSpd;
				}
			}
			else if (!(angSpd <= trgAngSpd))
			{
				angSpd -= angAccel * deltaTime;
				if (!(angSpd >= trgAngSpd))
				{
					angSpd = trgAngSpd;
				}
			}
			if (!(verticalForce <= 0f))
			{
				float num2 = vector[1] - position[1];
				if (!(num2 <= 0f))
				{
					vSpd += verticalForce * deltaTime;
					if (!(vSpd <= num2))
					{
						vSpd = num2;
					}
				}
				else if (!(num2 >= 0f))
				{
					vSpd -= verticalForce * deltaTime;
					if (!(vSpd >= num2))
					{
						vSpd = num2;
					}
				}
				position[1] += vSpd * deltaTime;
			}
			if (quickCollision.active)
			{
				quickCollision.setTarget(target);
				quickCollision.Update(position, ang, trgVec);
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
			Vector3 vec = new Vector3(position2[0] - position[0], 0f, position2[2] - position[2]);
			ang = VecToAng(vec);
		}
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
		if (target == null && !reFind)
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
}
