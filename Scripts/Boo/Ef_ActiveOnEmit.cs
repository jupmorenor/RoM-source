using System;
using UnityEngine;

[Serializable]
public class Ef_ActiveOnEmit : MonoBehaviour
{
	public string effectName;

	public GameObject prefab;

	public GameObject emitterObj;

	public int maxNum;

	public bool dontEmitExist;

	private Ef_ActiveOnBuffer actOnBuf;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_ActiveOnEmit()
	{
		maxNum = 1;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			emitterObj = emtr.gameObject;
		}
	}

	public void Start()
	{
		if (string.IsNullOrEmpty(effectName))
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (prefab == null)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (emitterObj == null)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		actOnBuf = Ef_ActiveOnBuffer.Current;
		if (actOnBuf == null)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		if (maxNum == 0)
		{
			maxNum = 1;
		}
		Vector3 position = transform.position;
		Quaternion rotation = transform.rotation;
		GameObject gameObject = actOnBuf.Emit(effectName, prefab, emitterObj, position, rotation, maxNum, dontEmitExist);
		if (gameObject != null)
		{
			MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
			if (component != null && component.Command.parent != null)
			{
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
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public void sendInit()
	{
		sendTarget = null;
		sendColor = new Color(0f, 0f, 0f, 0f);
		sendTime = 0f;
		sendRank = 0;
		sendEmtr = null;
		sendPetM = null;
	}

	public void setEmtr(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
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
}
