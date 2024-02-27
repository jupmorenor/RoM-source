using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitHeight : Ef_GroundHeight
{
	public GameObject emitObj;

	public float emitHeight;

	public float emitUnder;

	public bool ajustRot;

	public float distance;

	public float height;

	private bool ready;

	private Vector3 landPos;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitHeight()
	{
		emitUnder = -0.5f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Update()
	{
		object[] groundHeight = GetGroundHeight(transform.position);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		Vector3 vector = (Vector3)groundHeight[2];
		Vector3 position = transform.position;
		height = position.y - num;
		if (!(height > emitHeight))
		{
			if (ready)
			{
				landPos = position;
				position.y = num;
				Emit(position);
				ready = false;
			}
			else
			{
				if (distance <= 0f)
				{
					return;
				}
				if (!(position.y > emitUnder))
				{
					landPos = position;
					return;
				}
				float magnitude = (position - landPos).magnitude;
				if (!(magnitude < distance) && !(magnitude >= distance * 2f))
				{
					position = (landPos = Vector3.Lerp(landPos, transform.position, distance / magnitude));
					position.y = num;
					Emit(position);
				}
			}
		}
		else
		{
			ready = true;
		}
	}

	public void Emit(Vector3 pos)
	{
		Quaternion rotation = Quaternion.identity;
		if (ajustRot)
		{
			rotation = transform.rotation;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(emitObj, pos, rotation);
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
		if ((bool)sendTarget)
		{
			gameObject.SendMessage("setTarget", sendTarget, SendMessageOptions.DontRequireReceiver);
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
		sendTarget = trgObj;
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
				Transform transform = gameObject.transform;
			}
		}
	}
}
