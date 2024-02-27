using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitDistance : Ef_Base
{
	public GameObject[] gameObjs;

	public float distance;

	public float delay;

	public bool loop;

	public bool ajustRot;

	public bool parent;

	public Vector3 offsetRot;

	public Vector3 randomRot;

	public Vector3 randomBox;

	public Vector3 boxPos;

	public float maxMove;

	private Vector3 lstPos;

	private float dist;

	private float oneDist;

	private float nextDist;

	private int pt;

	private int leng;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitDistance()
	{
		gameObjs = new GameObject[0];
		distance = 2f;
		delay = 1f;
		offsetRot = Vector3.zero;
		randomRot = Vector3.zero;
		randomBox = Vector3.zero;
		boxPos = Vector3.zero;
		maxMove = 1f;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		leng = gameObjs.Length;
		lstPos = transform.position;
		oneDist = distance / (float)leng * 0.99999f;
		nextDist = oneDist;
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay = Mathf.Max(delay - deltaTime, 0f);
			return;
		}
		Vector3 position = transform.position;
		dist = (position - lstPos).magnitude;
		if (!(dist <= maxMove))
		{
			lstPos = position;
			return;
		}
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(10).GetEnumerator();
		checked
		{
			try
			{
				while (enumerator.MoveNext())
				{
					num = enumerator.Current;
					if (!(dist < nextDist))
					{
						if (pt < leng)
						{
							GameObject[] array = gameObjs;
							if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, pt)])
							{
								Emit(lstPos + (position - lstPos) * nextDist / dist);
							}
							pt++;
							if (pt >= leng && loop)
							{
								pt = 0;
							}
							dist -= nextDist;
							nextDist = oneDist;
							continue;
						}
						UnityEngine.Object.Destroy(gameObject);
						return;
					}
					break;
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			nextDist -= dist;
			lstPos = position;
		}
	}

	public void Emit(Vector3 pos)
	{
		Quaternion quaternion = default(Quaternion);
		quaternion = ((!ajustRot) ? Quaternion.identity : transform.rotation);
		if (randomBox != Vector3.zero)
		{
			float x = UnityEngine.Random.Range(0f - randomBox.x, randomBox.x) / 2f;
			float y = UnityEngine.Random.Range(0f - randomBox.y, randomBox.y) / 2f;
			float z = UnityEngine.Random.Range(0f - randomBox.z, randomBox.z) / 2f;
			pos += quaternion * (boxPos + new Vector3(x, y, z));
		}
		else if (boxPos != Vector3.zero)
		{
			pos += quaternion * boxPos;
		}
		if (randomRot != Vector3.zero)
		{
			float x2 = UnityEngine.Random.Range(0f - randomRot.x, randomRot.x);
			float y2 = UnityEngine.Random.Range(0f - randomRot.y, randomRot.y);
			float z2 = UnityEngine.Random.Range(0f - randomRot.z, randomRot.z);
			quaternion = quaternion * Quaternion.Euler(offsetRot) * Quaternion.Euler(x2, y2, z2);
		}
		else
		{
			quaternion *= Quaternion.Euler(offsetRot);
		}
		GameObject[] array = gameObjs;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(array[RuntimeServices.NormalizeArrayIndex(array, pt)], pos, quaternion);
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

	public void emitEffectMessage(MerlinActionControl emitter)
	{
		sendEmtr = emitter;
		PlayerControl playerControl = emitter as PlayerControl;
		if (playerControl == null)
		{
			return;
		}
		GameObject gameObject = null;
		gameObject = playerControl.TargetChar;
		if (gameObject == null)
		{
			gameObject = playerControl.searchTargetEnemy();
			if (gameObject == null)
			{
				return;
			}
		}
		sendTarget = gameObject.transform;
	}
}
