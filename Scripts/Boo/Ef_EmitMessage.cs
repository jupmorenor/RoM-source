using System;
using UnityEngine;

[Serializable]
public class Ef_EmitMessage : MonoBehaviour
{
	public GameObject emitObj;

	public bool ajustRot;

	public bool parent;

	public Vector3 offsetRot;

	public Vector3 randomRot;

	public Vector3 randomBox;

	public Vector3 boxPos;

	public bool destroy;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitMessage()
	{
		offsetRot = Vector3.zero;
		randomRot = Vector3.zero;
		randomBox = Vector3.zero;
		boxPos = Vector3.zero;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Emit()
	{
		Vector3 position = transform.position;
		Quaternion quaternion = default(Quaternion);
		quaternion = ((!ajustRot) ? Quaternion.identity : (transform.rotation * Quaternion.Euler(offsetRot)));
		if (randomBox != Vector3.zero)
		{
			float x = UnityEngine.Random.Range(0f - randomBox.x, randomBox.x) / 2f;
			float y = UnityEngine.Random.Range(0f - randomBox.y, randomBox.y) / 2f;
			float z = UnityEngine.Random.Range(0f - randomBox.z, randomBox.z) / 2f;
			position += quaternion * (boxPos + new Vector3(x, y, z));
		}
		else if (boxPos != Vector3.zero)
		{
			position += quaternion * boxPos;
		}
		if (randomRot != Vector3.zero)
		{
			float x2 = UnityEngine.Random.Range(0f - randomRot.x, randomRot.x);
			float y2 = UnityEngine.Random.Range(0f - randomRot.y, randomRot.y);
			float z2 = UnityEngine.Random.Range(0f - randomRot.z, randomRot.z);
			quaternion *= Quaternion.Euler(x2, y2, z2);
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(emitObj, position, quaternion);
		if (!gameObject)
		{
			return;
		}
		if (parent)
		{
			gameObject.transform.parent = transform;
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
		if (sendTarget != null)
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
		if (destroy)
		{
			UnityEngine.Object.Destroy(this.gameObject);
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
