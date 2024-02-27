using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_CollisionEmit : Ef_GroundHeight
{
	public GameObject[] emitObjs;

	public bool ajustRot;

	public bool groundHit;

	public float upLength;

	public bool oneShot;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	private bool end;

	public Ef_CollisionEmit()
	{
		emitObjs = new GameObject[0];
		groundHit = true;
		upLength = 0.1f;
		oneShot = true;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void OnCollisionEnter()
	{
		if (!oneShot || !end)
		{
			Emit(transform.position);
			end = true;
		}
	}

	public void Update()
	{
		if (!groundHit)
		{
			return;
		}
		Vector3 position = transform.position;
		object[] groundHeight = GetGroundHeight(position);
		bool flag = RuntimeServices.UnboxBoolean(groundHeight[0]);
		float num = RuntimeServices.UnboxSingle(groundHeight[1]);
		Vector3 vector = (Vector3)groundHeight[2];
		if (flag)
		{
			num += upLength;
		}
		if (!oneShot || !end)
		{
			if (!(transform.position.y >= num))
			{
				position.y = num;
			}
			Emit(position);
			end = true;
		}
	}

	public void Emit(Vector3 pos)
	{
		GameObject gameObject = null;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(emitObjs.Length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				if (ajustRot)
				{
					GameObject[] array = emitObjs;
					gameObject = (GameObject)UnityEngine.Object.Instantiate(array[RuntimeServices.NormalizeArrayIndex(array, num)], pos, transform.rotation);
				}
				else
				{
					GameObject[] array2 = emitObjs;
					gameObject = (GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, num)], pos, Quaternion.identity);
				}
				if (!gameObject)
				{
					break;
				}
				MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
				if (component != null)
				{
					if (!(component.Command.parent != null))
					{
						UnityEngine.Object.Destroy(gameObject);
						break;
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
		}
		finally
		{
			enumerator.Dispose();
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

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		sendPetM = mpets;
	}
}
