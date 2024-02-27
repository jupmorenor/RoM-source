using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitFromEmitterName : MonoBehaviour
{
	public bool ignoreEP;

	public bool setNoSetPM;

	public bool destroy;

	public Ef_EmitFromEmitterNameObj[] emitDatas;

	private bool end;

	private Transform targetObj;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitFromEmitterName()
	{
		setNoSetPM = true;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (end || emtr == null)
		{
			return;
		}
		MerlinMotionPackControl component = emtr.GetComponent<MerlinMotionPackControl>();
		if (component == null)
		{
			return;
		}
		GameObject gameObject = component.motionTarget.gameObject;
		if (!(gameObject == null))
		{
			if ((bool)gameObject.transform.parent)
			{
				EmitFromEmitterName(gameObject.transform.parent.name);
			}
			else
			{
				EmitFromEmitterName(gameObject.name);
			}
			end = true;
			if (destroy)
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	public void Start()
	{
		if (!end)
		{
			if (setNoSetPM)
			{
				EmitFromEmitterName(string.Empty);
			}
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void EmitFromEmitterName(string name)
	{
		int length = name.Length;
		int length2 = emitDatas.Length;
		if (length2 == 0)
		{
			return;
		}
		Ef_EmitFromEmitterNameObj ef_EmitFromEmitterNameObj = null;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length2).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Ef_EmitFromEmitterNameObj[] array = emitDatas;
				string emitterName = array[RuntimeServices.NormalizeArrayIndex(array, num)].emitterName;
				string text = string.Empty;
				int length3 = emitterName.Length;
				if (length3 < length)
				{
					text = ((!ignoreEP) ? name.Substring(0, length3) : name.Substring(1, length3));
				}
				if (emitterName == text || length == 0)
				{
					Ef_EmitFromEmitterNameObj[] array2 = emitDatas;
					ef_EmitFromEmitterNameObj = array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					break;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (ef_EmitFromEmitterNameObj == null || !ef_EmitFromEmitterNameObj.emitObj)
		{
			return;
		}
		Vector3 position = transform.position;
		Quaternion quaternion = default(Quaternion);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(rotation: (!ef_EmitFromEmitterNameObj.ajustRot) ? Quaternion.identity : (transform.rotation * Quaternion.Euler(ef_EmitFromEmitterNameObj.offsetRot)), original: ef_EmitFromEmitterNameObj.emitObj, position: position);
		if (!gameObject)
		{
			return;
		}
		if (ef_EmitFromEmitterNameObj.parent)
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
		if (targetObj != null)
		{
			gameObject.SendMessage("setTarget", targetObj, SendMessageOptions.DontRequireReceiver);
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
		targetObj = trgObj;
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
