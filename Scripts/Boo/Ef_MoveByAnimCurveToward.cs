using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_MoveByAnimCurveToward
{
	public bool active;

	public Transform target;

	public Ef_MoveByAnimCurveMinMaxAnim angleSpeedAnim;

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

	public Ef_MoveByAnimCurveCollision quickCollision;

	private bool lstLeft;

	private float timer;

	private float vSpd;

	private GameObject thisGameObj;

	public Ef_MoveByAnimCurveToward()
	{
		fromEffectMessage = true;
		maxCandidatesNum = 10;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		updateTarget = true;
		interval = 1f;
	}

	public void Initialize(GameObject gameObj)
	{
		thisGameObj = gameObj;
		angleSpeedAnim.Initialize();
		if (quickCollision.active)
		{
			quickCollision.ThisGameObj = gameObj;
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
			}
		}
		if (returnToSelf)
		{
			target = emtr.transform;
			if ((bool)target)
			{
				target = FindSpine(target);
			}
		}
		else if (fromEffectMessage)
		{
			targetToEnemySide = emtr.IsSidePlayer;
			targetToPlayerSide = emtr.IsSideEnemy;
		}
	}

	public object[] Update(Vector3 pos, float ang, float animTime, float deltaTime)
	{
		if (updateTarget || (target == null && reFind))
		{
			timer -= deltaTime;
			if (!(timer > 0f))
			{
				target = FindTarget(pos);
				timer = interval;
			}
		}
		if (target != null)
		{
			float value = angleSpeedAnim.GetValue(animTime);
			Vector3 position = target.position;
			Vector3 trgVec = position - pos;
			if (VecToTurn(AngToVec(ang, 1f), trgVec))
			{
				ang += value * deltaTime;
				if (!(ang <= 360f))
				{
					ang -= 360f;
				}
			}
			else
			{
				ang -= value * deltaTime;
				if (!(ang >= -360f))
				{
					ang += 360f;
				}
			}
			if (!(verticalForce <= 0f))
			{
				float num = position[1] - pos[1];
				float num2 = default(float);
				if (!(num <= 0f))
				{
					vSpd += verticalForce * deltaTime;
					num2 = num * verticalForce;
					if (!(vSpd <= num2))
					{
						vSpd = num2;
					}
				}
				else if (!(num >= 0f))
				{
					vSpd -= verticalForce * deltaTime;
					num2 = num * verticalForce;
					if (!(vSpd >= num2))
					{
						vSpd = num2;
					}
				}
				pos[1] += vSpd * deltaTime;
			}
			if (quickCollision.active)
			{
				quickCollision.setTarget(target);
				quickCollision.Update(pos, ang, trgVec);
			}
		}
		else if (quickCollision.active)
		{
			quickCollision.setTarget(null);
		}
		return new object[2] { pos, ang };
	}

	public void LookTarget(Vector3 pos)
	{
		if ((bool)target)
		{
			Vector3 position = target.position;
			Vector3 vec = new Vector3(position[0] - pos[0], 0f, position[2] - pos[2]);
			float num = VecToAng(vec);
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
				if (thisGameObj.layer == LayerMask.NameToLayer(playerLayer))
				{
					targetToEnemySide = true;
				}
				else if (thisGameObj.layer == LayerMask.NameToLayer(enemyLayer))
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
					goto IL_0324;
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
			if ((bool)transform)
			{
				transform = FindSpine(transform);
			}
			result = transform;
		}
		goto IL_0324;
		IL_0324:
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
