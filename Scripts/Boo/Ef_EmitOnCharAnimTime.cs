using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitOnCharAnimTime : Ef_Base
{
	public Transform target;

	public bool findOfType;

	public Ef_EmitOnCharAnimTimeMotion[] mots;

	private string[] paths;

	private BaseControl[] bcs;

	private MerlinMotionPackControl mmpc;

	private Animation anim;

	private Transform[] bones;

	private int mNum;

	private int bNum;

	private bool ready;

	private Transform sendTarget;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private MerlinActionControl sendEmtr;

	private MPoppets sendPetM;

	public Ef_EmitOnCharAnimTime()
	{
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		FindNearChar();
	}

	public void FindNearChar()
	{
		Vector3 position = this.transform.position;
		BaseControl[] array = BaseControl.AllControls;
		if (array.Length == 0 || findOfType)
		{
			array = (BaseControl[])UnityEngine.Object.FindObjectsOfType(typeof(BaseControl));
		}
		float num = 99999f;
		int i = 0;
		BaseControl[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				if (!(array2[i] == null))
				{
					float sqrMagnitude = (array2[i].transform.position - position).sqrMagnitude;
					if (!(sqrMagnitude >= num))
					{
						target = array2[i].transform;
						num = sqrMagnitude;
					}
				}
			}
			if (target == null)
			{
				return;
			}
			mmpc = target.GetComponent<MerlinMotionPackControl>();
			if (mmpc == null)
			{
				return;
			}
			anim = mmpc.motionTarget;
			if (anim == null)
			{
				return;
			}
			string[] array3 = new string[10];
			mNum = mots.Length;
			bNum = 0;
			int num2 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			IEnumerator<int> enumerator = Builtins.range(mNum).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num2 = enumerator.Current;
					Ef_EmitOnCharAnimTimeMotion[] array4 = mots;
					Ef_EmitOnCharAnimTimeEmit[] emits = array4[RuntimeServices.NormalizeArrayIndex(array4, num2)].emits;
					IEnumerator<int> enumerator2 = Builtins.range(emits.Length).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							num3 = enumerator2.Current;
							Ef_EmitOnCharAnimTimeEmit ef_EmitOnCharAnimTimeEmit = emits[RuntimeServices.NormalizeArrayIndex(emits, num3)];
							if (ef_EmitOnCharAnimTimeEmit.attachPath.Length == 0)
							{
								ef_EmitOnCharAnimTimeEmit.attachPath = "y_ang";
							}
							bool flag = false;
							IEnumerator<int> enumerator3 = Builtins.range(bNum).GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									num4 = enumerator3.Current;
									if (array3[RuntimeServices.NormalizeArrayIndex(array3, num4)] == ef_EmitOnCharAnimTimeEmit.attachPath)
									{
										flag = true;
										break;
									}
								}
							}
							finally
							{
								enumerator3.Dispose();
							}
							if (!flag)
							{
								array3[RuntimeServices.NormalizeArrayIndex(array3, bNum)] = ef_EmitOnCharAnimTimeEmit.attachPath;
								ef_EmitOnCharAnimTimeEmit.pathId = bNum;
								bNum++;
								if (bNum >= 10)
								{
									break;
								}
							}
						}
					}
					finally
					{
						enumerator2.Dispose();
					}
					if (bNum >= 10)
					{
						break;
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			bones = new Transform[bNum];
			paths = new string[bNum];
			Transform transform = null;
			int num5 = 0;
			IEnumerator<int> enumerator4 = Builtins.range(bNum).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					num2 = enumerator4.Current;
					Transform[] array5 = bones;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num2)] = anim.transform.Find(array3[RuntimeServices.NormalizeArrayIndex(array3, num2)]);
					string[] array6 = paths;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num2)] = array3[RuntimeServices.NormalizeArrayIndex(array3, num2)];
					Transform[] array7 = bones;
					if (!(array7[RuntimeServices.NormalizeArrayIndex(array7, num2)] == null))
					{
					}
				}
			}
			finally
			{
				enumerator4.Dispose();
			}
			ready = true;
		}
	}

	public void Update()
	{
		if (!ready)
		{
			return;
		}
		if (!target || anim == null)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		int num = default(int);
		int num2 = default(int);
		IEnumerator<int> enumerator = Builtins.range(mNum).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Animation obj = anim;
				Ef_EmitOnCharAnimTimeMotion[] array = mots;
				AnimationState animationState = obj[array[RuntimeServices.NormalizeArrayIndex(array, num)].motionName];
				if (!animationState)
				{
					Animation obj2 = anim;
					Ef_EmitOnCharAnimTimeMotion[] array2 = mots;
					animationState = obj2[array2[RuntimeServices.NormalizeArrayIndex(array2, num)].motionName + " - Queued Clone"];
				}
				if (!animationState)
				{
					continue;
				}
				float time = animationState.time;
				float num3 = time % animationState.length;
				Ef_EmitOnCharAnimTimeMotion[] array3 = mots;
				float lastTime = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].lastTime;
				Ef_EmitOnCharAnimTimeMotion[] array4 = mots;
				Ef_EmitOnCharAnimTimeEmit[] emits = array4[RuntimeServices.NormalizeArrayIndex(array4, num)].emits;
				IEnumerator<int> enumerator2 = Builtins.range(emits.Length).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						num2 = enumerator2.Current;
						Ef_EmitOnCharAnimTimeEmit ef_EmitOnCharAnimTimeEmit = emits[RuntimeServices.NormalizeArrayIndex(emits, num2)];
						float num4 = ef_EmitOnCharAnimTimeEmit.emitTime;
						if (num4 == 0f)
						{
							num4 = 0.01f;
						}
						if (!(num3 < num4) && !(lastTime >= num4))
						{
							Emit(ef_EmitOnCharAnimTimeEmit);
						}
					}
				}
				finally
				{
					enumerator2.Dispose();
				}
				if (!(num3 <= lastTime))
				{
					Ef_EmitOnCharAnimTimeMotion[] array5 = mots;
					array5[RuntimeServices.NormalizeArrayIndex(array5, num)].lastTime = num3;
				}
				else
				{
					Ef_EmitOnCharAnimTimeMotion[] array6 = mots;
					array6[RuntimeServices.NormalizeArrayIndex(array6, num)].lastTime = 0f;
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Emit(Ef_EmitOnCharAnimTimeEmit emit)
	{
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		if (emit.pathId == -1)
		{
			return;
		}
		Transform[] array = bones;
		Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, emit.pathId)];
		Transform[] array2 = bones;
		Vector3 vector2 = array2[RuntimeServices.NormalizeArrayIndex(array2, emit.pathId)].rotation * emit.offsetPos;
		vector = transform.position + vector2;
		quaternion = Quaternion.identity;
		if (emit.ajustRot)
		{
			quaternion = transform.rotation * Quaternion.Euler(emit.offsetRot);
		}
		if (!emit.emitObj)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(emit.emitObj, vector, quaternion);
		if (!gameObject)
		{
			return;
		}
		if (emit.attach)
		{
			Ef_Attachment ef_Attachment = gameObject.AddComponent<Ef_Attachment>();
			ef_Attachment.target = transform;
			ef_Attachment.offsetPos = vector2;
			if (emit.ajustRot)
			{
				ef_Attachment.posOnly = false;
				ef_Attachment.offsetRot = emit.offsetRot;
			}
			else
			{
				ef_Attachment.posOnly = true;
			}
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

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		sendEmtr = emtr;
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		sendPetM = mpets;
	}
}
