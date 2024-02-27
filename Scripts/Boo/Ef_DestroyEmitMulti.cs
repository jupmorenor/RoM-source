using System;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Ef_DestroyEmitMulti : Ef_Base
{
	public float life;

	public GameObject emitObj;

	public int numOfEmit;

	public bool ajustUpVector;

	public float angleH;

	public float angleV;

	public bool random;

	public bool onDestroy;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_DestroyEmitMulti()
	{
		life = -1f;
		numOfEmit = 3;
		ajustUpVector = true;
		angleH = 45f;
		angleV = 10f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Update()
	{
		if (life == -1f)
		{
			return;
		}
		if (!(life > 0f))
		{
			if ((bool)emitObj)
			{
				EmitMulti();
			}
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
		life -= deltaTime;
	}

	public void EmitMulti()
	{
		if (ajustUpVector)
		{
			transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
		}
		Quaternion quaternion = default(Quaternion);
		int num = default(int);
		checked
		{
			if (!random)
			{
				float num2 = angleH / (float)(numOfEmit - 1);
				float num3 = angleV / (float)(numOfEmit - 1);
				IEnumerator<int> enumerator = Builtins.range(numOfEmit).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						num = enumerator.Current;
						quaternion = transform.rotation * Quaternion.Euler(new Vector3((0f - angleV) / 2f + num3 * (float)num, (0f - angleH) / 2f + num2 * (float)num, 0f));
						Emit(quaternion);
					}
					return;
				}
				finally
				{
					enumerator.Dispose();
				}
			}
			IEnumerator<int> enumerator2 = Builtins.range(numOfEmit).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					num = enumerator2.Current;
					quaternion = transform.rotation * Quaternion.Euler(new Vector3(UnityEngine.Random.Range((0f - angleV) / 2f, angleV / 2f), UnityEngine.Random.Range((0f - angleH) / 2f, angleH / 2f), 0f));
					Emit(quaternion);
				}
			}
			finally
			{
				enumerator2.Dispose();
			}
		}
	}

	public void Emit(Quaternion rot)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(emitObj, transform.position, rot);
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

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		sendPetM = mpets;
	}

	public void OnDestroy()
	{
		if (onDestroy && !Ef_Base.isShuttingDown)
		{
			EmitMulti();
		}
	}
}
