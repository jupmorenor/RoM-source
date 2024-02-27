using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_DestroyCollision : MonoBehaviour
{
	public bool groundHit;

	public bool groundOnly;

	public float upLength;

	public GameObject hitObj;

	public bool ajustRot;

	private Ef_HeightBuffer hBuf;

	private int destroyCount;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_DestroyCollision()
	{
		groundHit = true;
		upLength = 0.1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void OnCollisionEnter(Collision coli)
	{
		if (!groundOnly)
		{
			ContactPoint[] contacts = coli.contacts;
			if (contacts.Length > 0)
			{
				Emit(contacts[0].point);
			}
			else
			{
				Emit();
			}
			destroyCount = 2;
			groundOnly = true;
		}
	}

	public void Update()
	{
		if (groundHit)
		{
			if (hBuf == null)
			{
				hBuf = Ef_HeightBuffer.Current;
				if (hBuf == null)
				{
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
					return;
				}
			}
			object[] height = hBuf.GetHeight(transform.position);
			float num = RuntimeServices.UnboxSingle(height[0]);
			object obj = height[1];
			num += upLength;
			if (!(transform.position.y >= num))
			{
				float y = num;
				Vector3 position = transform.position;
				float num2 = (position.y = y);
				Vector3 vector2 = (transform.position = position);
				Emit();
				Ef_DestroyRelease component2 = gameObject.GetComponent<Ef_DestroyRelease>();
				if ((bool)component2)
				{
					component2.Release();
				}
				UnityEngine.Object.Destroy(gameObject);
				return;
			}
		}
		if (destroyCount <= 0)
		{
			return;
		}
		checked
		{
			destroyCount--;
			if (destroyCount > 0)
			{
				return;
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
	}

	public void Emit()
	{
		if (ajustRot)
		{
			Emit(transform.position, transform.rotation);
		}
		else
		{
			Emit(transform.position, Quaternion.identity);
		}
	}

	public void Emit(Vector3 pos)
	{
		if (ajustRot)
		{
			Emit(pos, transform.rotation);
		}
		else
		{
			Emit(pos, Quaternion.identity);
		}
	}

	public void Emit(Vector3 pos, Quaternion rot)
	{
		if (!hitObj)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(hitObj, pos, rot);
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
