using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Homing : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float rotSpd;

	public float rotAccel;

	public Vector3 targetOffset;

	public Vector3 rotOffset;

	public float radius;

	public GameObject hitObj;

	public bool ajustRot;

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

	private Quaternion rot;

	private Quaternion ofsRot;

	private float timer;

	private float vSpd;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_Homing()
	{
		speed = 6f;
		accel = 6f;
		rotSpd = 180f;
		rotAccel = 180f;
		targetOffset = Vector3.zero;
		rotOffset = Vector3.zero;
		radius = 0.5f;
		fromEffectMessage = true;
		maxCandidatesNum = 10;
		playerLayer = "PlayerAttackColi";
		enemyLayer = "EnemyAttackColi";
		updateTarget = true;
		interval = 1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		ofsRot = Quaternion.Euler(rotOffset);
		rot = transform.rotation * ofsRot;
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
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
		if (updateTarget || target == null)
		{
			timer -= deltaTime;
			if (!(timer > 0f))
			{
				target = FindTarget(transform.position);
				if ((bool)target)
				{
					target = FindSpine(target);
				}
				timer = interval;
			}
		}
		Quaternion quaternion = default(Quaternion);
		float num = speed * deltaTime;
		if (target != null)
		{
			Vector3 forward = target.position + targetOffset - transform.position;
			float sqrMagnitude = forward.sqrMagnitude;
			quaternion = Quaternion.LookRotation(forward, Vector3.up);
			if (!(radius <= 0f) && !(sqrMagnitude > radius * radius))
			{
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
			}
			if (!(num * num <= sqrMagnitude))
			{
				num = Mathf.Sqrt(sqrMagnitude);
			}
		}
		else
		{
			Vector3 eulerAngles = rot.eulerAngles;
			eulerAngles.y = 0f;
			quaternion = Quaternion.Euler(eulerAngles);
		}
		rot = Quaternion.RotateTowards(rot, quaternion, rotSpd * deltaTime);
		transform.rotation = rot * ofsRot;
		transform.position += rot * new Vector3(0f, 0f, num);
		rotSpd += rotAccel * deltaTime;
		speed += accel * deltaTime;
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
		if (targetToPlayerSide && playerOnly)
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
					goto IL_0399;
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
		goto IL_0399;
		IL_0399:
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
		if (target != null)
		{
			gameObject.SendMessage("setTarget", target, SendMessageOptions.DontRequireReceiver);
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
		target = trgObj;
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
}
