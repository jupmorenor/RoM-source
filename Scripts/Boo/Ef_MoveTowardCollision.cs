using System;
using GameAsset;
using UnityEngine;

[Serializable]
public class Ef_MoveTowardCollision
{
	public bool active;

	public float radius;

	public GameObject hitObj;

	public bool ajustRot;

	private GameObject thisGameObj;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public GameObject ThisGameObj
	{
		set
		{
			thisGameObj = value;
		}
	}

	public Ef_MoveTowardCollision()
	{
		radius = 0.5f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Update(Vector3 pos, float ang, Vector3 trgVec)
	{
		if (radius <= 0f)
		{
			return;
		}
		float sqrMagnitude = trgVec.sqrMagnitude;
		if (sqrMagnitude > radius * radius)
		{
			return;
		}
		Emit(pos, ang);
		if (!thisGameObj)
		{
			return;
		}
		Ef_DestroyReleaseV2 component = thisGameObj.GetComponent<Ef_DestroyReleaseV2>();
		if (component != null)
		{
			component.Release();
		}
		else
		{
			Ef_DestroyRelease component2 = thisGameObj.GetComponent<Ef_DestroyRelease>();
			if (component2 != null)
			{
				component2.Release();
			}
		}
		UnityEngine.Object.Destroy(thisGameObj);
	}

	public void Emit(Vector3 pos, float ang)
	{
		if (!hitObj)
		{
			return;
		}
		GameObject gameObject = null;
		gameObject = ((!ajustRot) ? GameAssetModule.Instantiate(hitObj, pos, Quaternion.Euler(0f, ang, 0f)) : GameAssetModule.Instantiate(hitObj, pos, Quaternion.Euler(0f, ang, 0f)));
		if (!gameObject)
		{
			return;
		}
		MerlinAttackCommandHolder component = thisGameObj.GetComponent<MerlinAttackCommandHolder>();
		if (component != null)
		{
			if (!(component.Command.parent != null))
			{
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
			gameObject.layer = thisGameObj.layer;
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
