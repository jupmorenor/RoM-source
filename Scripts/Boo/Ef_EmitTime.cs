using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitTime : Ef_Base
{
	public GameObject[] gameObjs;

	public int number;

	public float life;

	public float delay;

	public float timer;

	public bool loop;

	public bool ajustRot;

	public bool parent;

	public Vector3 offsetRot;

	public Vector3 randomRot;

	public Vector3 randomBox;

	public Vector3 boxPos;

	public bool emitForEnemy;

	private float fstLife;

	private float fstTime;

	private int fstNum;

	private float oneTime;

	private float nextTime;

	private int pt;

	private int leng;

	private Transform[] trgs;

	private int trgNum;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	private bool ready;

	public Ef_EmitTime()
	{
		gameObjs = new GameObject[0];
		number = 1;
		life = 2f;
		delay = 1f;
		timer = 1f;
		offsetRot = Vector3.zero;
		randomRot = Vector3.zero;
		randomBox = Vector3.zero;
		boxPos = Vector3.zero;
		trgs = new Transform[3];
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void OnActive()
	{
		if (!ready)
		{
			Init();
		}
		life = fstLife;
		timer = fstTime;
		number = fstNum;
	}

	public void Start()
	{
		if (!ready)
		{
			Init();
		}
	}

	public void Init()
	{
		leng = gameObjs.Length;
		fstLife = life;
		fstTime = timer;
		fstNum = number;
		if (number < 1)
		{
			number = 1;
		}
		oneTime = timer / (float)leng / (float)number;
		nextTime = timer;
		if (emitForEnemy)
		{
			FindTargets();
		}
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		checked
		{
			if (timer > 0f || pt < leng)
			{
				if (!(timer > nextTime))
				{
					GameObject[] array = gameObjs;
					if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, pt)])
					{
						Emit();
					}
					pt++;
					if (pt >= leng && number > 1)
					{
						pt = 0;
						number--;
					}
					nextTime -= oneTime;
				}
				timer -= deltaTime;
			}
			else if (loop)
			{
				timer += fstTime;
				nextTime = timer;
				number = fstNum;
				pt = 0;
			}
			if (life != -1f)
			{
				if (!(life > 0f))
				{
					UnityEngine.Object.Destroy(gameObject);
				}
				life -= deltaTime;
			}
		}
	}

	public void Emit()
	{
		Vector3 position = transform.position;
		Quaternion quaternion = default(Quaternion);
		quaternion = ((!ajustRot) ? Quaternion.identity : transform.rotation);
		checked
		{
			if (emitForEnemy && trgNum > 0)
			{
				trgNum--;
				Transform[] array = trgs;
				position = array[RuntimeServices.NormalizeArrayIndex(array, trgNum)].position;
			}
			else if (randomBox != Vector3.zero)
			{
				float x = UnityEngine.Random.Range(0f - randomBox.x, randomBox.x) / 2f;
				float y = UnityEngine.Random.Range(0f - randomBox.y, randomBox.y) / 2f;
				float z = UnityEngine.Random.Range(0f - randomBox.z, randomBox.z) / 2f;
				position += quaternion * (boxPos + new Vector3(x, y, z));
			}
			else if (boxPos != Vector3.zero)
			{
				position += quaternion * boxPos;
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
			GameObject[] array2 = gameObjs;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(array2[RuntimeServices.NormalizeArrayIndex(array2, pt)], position, quaternion);
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

	public void FindTargets()
	{
		int num = 0;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		int i = 0;
		GameObject[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				BaseControl component = array2[i].GetComponent<BaseControl>();
				if ((bool)component && !(component.HitPoint <= 0f))
				{
					Transform[] array3 = trgs;
					array3[RuntimeServices.NormalizeArrayIndex(array3, num)] = array2[i].transform;
					num++;
				}
			}
			trgNum = num;
		}
	}
}
