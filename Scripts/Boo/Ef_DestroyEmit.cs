using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyEmit : Ef_Base
{
	public float life;

	public GameObject[] emitObjs;

	public bool ajustRot;

	public bool onDestroy;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_DestroyEmit()
	{
		life = -1f;
		emitObjs = new GameObject[0];
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
			Emit();
			onDestroy = false;
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

	public void Emit()
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
					gameObject = (GameObject)UnityEngine.Object.Instantiate(array[RuntimeServices.NormalizeArrayIndex(array, num)], transform.position, transform.rotation);
				}
				else
				{
					GameObject[] array2 = emitObjs;
					gameObject = (GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, num)], transform.position, Quaternion.identity);
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

	public void OnDestroy()
	{
		if (onDestroy && !Ef_Base.isShuttingDown)
		{
			Emit();
		}
	}
}
