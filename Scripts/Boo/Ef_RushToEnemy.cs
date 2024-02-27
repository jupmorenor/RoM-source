using System;
using UnityEngine;

[Serializable]
public class Ef_RushToEnemy : Ef_Base
{
	public string targetTag;

	public Transform target;

	[HideInInspector]
	public bool reFind;

	public float speed;

	public float accel;

	public float distanceSpeed;

	public Vector3 targetOffset;

	public Vector3 rotOffset;

	public bool findSpine;

	public float radius;

	public GameObject hitObj;

	public bool ajustRot;

	private Quaternion rot;

	private Quaternion ofsRot;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_RushToEnemy()
	{
		targetTag = "Enemy";
		speed = 6f;
		accel = 6f;
		targetOffset = Vector3.zero;
		rotOffset = Vector3.zero;
		findSpine = true;
		radius = 0.5f;
		sendColor = new Color(0f, 0f, 0f, 0f);
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
				target = gameObject.transform;
			}
		}
	}

	public void Start()
	{
		ofsRot = Quaternion.Euler(rotOffset);
		rot = transform.rotation * ofsRot;
		if (!target)
		{
			target = FindTarget();
		}
		if ((bool)target && findSpine)
		{
			target = FindSpine(target);
		}
	}

	public void Update()
	{
		Quaternion quaternion = default(Quaternion);
		float num = speed * deltaTime;
		if ((bool)target)
		{
			Vector3 forward = target.position + targetOffset - transform.position;
			float magnitude = forward.magnitude;
			quaternion = Quaternion.LookRotation(forward, Vector3.up);
			if (!(distanceSpeed <= 0f))
			{
				distanceSpeed *= magnitude;
				speed *= distanceSpeed;
				accel *= distanceSpeed;
				distanceSpeed = 0f;
			}
			if (!(radius <= 0f) && !(magnitude > radius))
			{
				Emit();
				UnityEngine.Object.Destroy(gameObject);
			}
			if (!(num <= magnitude))
			{
				num = magnitude;
			}
		}
		else
		{
			Vector3 eulerAngles = quaternion.eulerAngles;
			eulerAngles.x = 0f;
			quaternion = Quaternion.Euler(eulerAngles);
		}
		transform.rotation = quaternion * ofsRot;
		transform.position += quaternion * new Vector3(0f, 0f, num);
		speed += accel * deltaTime;
	}

	public Transform FindTarget()
	{
		Transform result = null;
		GameObject[] array = GameObject.FindGameObjectsWithTag(targetTag);
		float num = 999f;
		int i = 0;
		GameObject[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			BaseControl component = array2[i].GetComponent<BaseControl>();
			if ((bool)component && !(component.HitPoint <= 0f))
			{
				float magnitude = (array2[i].transform.position - transform.position).magnitude;
				if (!(magnitude >= num))
				{
					result = array2[i].transform;
					num = magnitude;
				}
			}
		}
		return result;
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
