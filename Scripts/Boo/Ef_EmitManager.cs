using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitManager : MonoBehaviour
{
	[Serializable]
	public class Ef_EmitManagerOpt
	{
		public bool ajustRot;

		public Vector3 offsetPos;

		public Vector3 offsetRot;

		public Vector3 randomPos;

		public Vector3 randomRot;

		public Ef_EmitManagerOpt()
		{
			offsetPos = Vector3.zero;
			offsetRot = Vector3.zero;
			randomPos = Vector3.zero;
			randomRot = Vector3.zero;
		}
	}

	public GameObject[] emitObjs;

	public int hitObjIndex;

	public int endObjIndex;

	public int bulletObjIndex;

	public int maxIndex;

	public Ef_EmitManagerOpt options;

	private int leng;

	private bool ofsPos;

	private bool ofsRot;

	private bool rndPos;

	private bool rndRot;

	private bool ready;

	private int pt;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitManager()
	{
		maxIndex = 99;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void PtReset()
	{
		pt = 0;
	}

	public void Init()
	{
		if (!ready)
		{
			leng = emitObjs.Length;
			ofsPos = options.offsetPos != Vector3.zero;
			ofsRot = options.offsetRot != Vector3.zero;
			rndPos = options.randomPos != Vector3.zero;
			rndRot = options.randomRot != Vector3.zero;
			ready = true;
		}
	}

	public GameObject EmitOnHit()
	{
		return (!options.ajustRot) ? Emit(transform.position, Quaternion.identity, hitObjIndex) : Emit(transform.position, transform.rotation, hitObjIndex);
	}

	public GameObject EmitOnHit(Vector3 pos)
	{
		return (!options.ajustRot) ? Emit(pos, Quaternion.identity, hitObjIndex) : Emit(pos, transform.rotation, hitObjIndex);
	}

	public GameObject EmitOnHit(Vector3 pos, Quaternion rot)
	{
		return Emit(pos, rot, hitObjIndex);
	}

	public GameObject EmitOnEnd()
	{
		return (!options.ajustRot) ? Emit(transform.position, Quaternion.identity, endObjIndex) : Emit(transform.position, transform.rotation, endObjIndex);
	}

	public GameObject EmitOnEnd(Vector3 pos)
	{
		return (!options.ajustRot) ? Emit(pos, Quaternion.identity, endObjIndex) : Emit(pos, transform.rotation, endObjIndex);
	}

	public GameObject EmitOnEnd(Vector3 pos, Quaternion rot)
	{
		return Emit(pos, rot, endObjIndex);
	}

	public GameObject EmitOnShot()
	{
		return (!options.ajustRot) ? Emit(transform.position, Quaternion.identity, bulletObjIndex) : Emit(transform.position, transform.rotation, bulletObjIndex);
	}

	public GameObject EmitOnShot(Vector3 pos)
	{
		return (!options.ajustRot) ? Emit(pos, Quaternion.identity, bulletObjIndex) : Emit(pos, transform.rotation, bulletObjIndex);
	}

	public GameObject EmitOnShot(Vector3 pos, Quaternion rot)
	{
		return Emit(pos, rot, bulletObjIndex);
	}

	public GameObject Emit(int index)
	{
		return (!options.ajustRot) ? Emit(transform.position, Quaternion.identity, index) : Emit(transform.position, transform.rotation, index);
	}

	public GameObject Emit(Vector3 pos, int index)
	{
		return (!options.ajustRot) ? Emit(pos, Quaternion.identity, index) : Emit(pos, transform.rotation, index);
	}

	public GameObject Emit()
	{
		return (!options.ajustRot) ? Emit(transform.position, Quaternion.identity, -1) : Emit(transform.position, transform.rotation, -1);
	}

	public GameObject Emit(Vector3 pos)
	{
		return (!options.ajustRot) ? Emit(pos, Quaternion.identity, -1) : Emit(pos, transform.rotation, -1);
	}

	public GameObject Emit(Vector3 pos, Quaternion rot)
	{
		return Emit(pos, rot, -1);
	}

	public GameObject Emit(Vector3 pos, Quaternion rot, int index)
	{
		if (!ready)
		{
			Init();
		}
		if (options.ajustRot)
		{
			if (rndPos)
			{
				options.offsetPos += new Vector3(UnityEngine.Random.Range(0f - options.randomPos[0], options.randomPos[0]), UnityEngine.Random.Range(0f - options.randomPos[1], options.randomPos[1]), UnityEngine.Random.Range(0f - options.randomPos[2], options.randomPos[2]));
			}
			if (ofsPos)
			{
				pos += options.offsetPos;
			}
			if (rndRot)
			{
				ofsRot = true;
				options.offsetRot += new Vector3(UnityEngine.Random.Range(0f - options.randomRot[0], options.randomRot[0]), UnityEngine.Random.Range(0f - options.randomRot[1], options.randomRot[1]), UnityEngine.Random.Range(0f - options.randomRot[2], options.randomRot[2]));
			}
			if (ofsRot)
			{
				rot *= Quaternion.Euler(options.offsetRot);
			}
		}
		GameObject gameObject = null;
		checked
		{
			if (index == -1)
			{
				if (endObjIndex != 0 && pt == endObjIndex)
				{
					pt++;
					if (pt >= leng)
					{
						pt = 0;
					}
				}
				if (hitObjIndex != 0 && pt == hitObjIndex)
				{
					pt++;
					if (pt >= leng)
					{
						pt = 0;
					}
				}
				if (bulletObjIndex != 0 && pt == bulletObjIndex)
				{
					pt++;
					if (pt >= leng)
					{
						pt = 0;
					}
				}
				GameObject[] array = emitObjs;
				gameObject = (GameObject)UnityEngine.Object.Instantiate(array[RuntimeServices.NormalizeArrayIndex(array, pt)], pos, rot);
				pt++;
				if (pt >= leng)
				{
					pt = 0;
				}
			}
			else
			{
				GameObject[] array2 = emitObjs;
				gameObject = (GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, index)], pos, rot);
			}
			if ((bool)gameObject)
			{
				Ef_ActiveOn component = gameObject.GetComponent<Ef_ActiveOn>();
				if (component != null)
				{
					component.ActiveOn();
				}
				else
				{
					gameObject.SendMessage("OnActive", SendMessageOptions.DontRequireReceiver);
				}
				MerlinAttackCommandHolder component2 = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
				if (component2 != null && component2.Command.parent != null)
				{
					gameObject.layer = this.gameObject.layer;
					MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject.AddComponent<MerlinAttackCommandHolder>();
					merlinAttackCommandHolder.Command = component2.Command;
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
			return gameObject;
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
