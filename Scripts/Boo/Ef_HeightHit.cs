using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_HeightHit : MonoBehaviour
{
	public float upLength;

	public GameObject hitObj;

	public bool ajustRot;

	public float boundForGravity;

	private Ef_Gravity grav;

	private Ef_HeightBuffer hBuf;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_HeightHit()
	{
		upLength = 0.1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		hBuf = Ef_HeightBuffer.Current;
		if (hBuf == null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			grav = gameObject.GetComponent<Ef_Gravity>();
		}
	}

	public void Update()
	{
		Vector3 position = transform.position;
		object[] height = hBuf.GetHeight(position);
		float num = RuntimeServices.UnboxSingle(height[0]);
		Vector3 vector = (Vector3)height[1];
		num += upLength;
		if (transform.position.y > num)
		{
			return;
		}
		position.y = num;
		if (!(boundForGravity <= 0f))
		{
			if ((bool)grav)
			{
				grav.upSpeed = Mathf.Abs(grav.upSpeed) * boundForGravity;
				if (!(grav.upSpeed >= 1f))
				{
					boundForGravity = 0f;
				}
			}
			return;
		}
		transform.position = position;
		Ef_DestroyReleaseV2 component = this.gameObject.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = this.gameObject.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(this.gameObject);
		GameObject gameObject = null;
		Emit();
	}

	public void Emit()
	{
		if (!hitObj)
		{
			return;
		}
		GameObject gameObject = ((!ajustRot) ? ((GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, Quaternion.identity)) : ((GameObject)UnityEngine.Object.Instantiate(hitObj, transform.position, transform.rotation)));
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
}
