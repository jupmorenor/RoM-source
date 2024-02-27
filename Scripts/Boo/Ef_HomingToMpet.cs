using System;
using UnityEngine;

[Serializable]
public class Ef_HomingToMpet : Ef_Base
{
	public Transform target;

	public float speed;

	public float accel;

	public float rotSpd;

	public float rotAccel;

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

	public Ef_HomingToMpet()
	{
		speed = 6f;
		accel = 6f;
		rotSpd = 180f;
		rotAccel = 180f;
		targetOffset = Vector3.zero;
		rotOffset = Vector3.zero;
		findSpine = true;
		radius = 0.5f;
		sendColor = new Color(0f, 0f, 0f, 0f);
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

	public Transform FindTarget()
	{
		Transform transform = null;
		object result;
		if (sendPetM == null)
		{
			result = null;
		}
		else
		{
			BaseControl[] allControls = BaseControl.AllControls;
			float num = 99999f;
			int num2 = default(int);
			int i = 0;
			BaseControl[] array = allControls;
			for (int length = array.Length; i < length; i = checked(i + 1))
			{
				if ((!(array[i].HitPoint <= 0f) && array[i].gameObject.name == sendPetM.PrefabName) || array[i].gameObject.name == sendPetM.PrefabName + "(Clone)")
				{
					float sqrMagnitude = (array[i].transform.position - this.transform.position).sqrMagnitude;
					if (!(sqrMagnitude >= num))
					{
						transform = array[i].transform;
						num = sqrMagnitude;
					}
				}
			}
			result = transform;
		}
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

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		sendPetM = mpets;
	}
}
