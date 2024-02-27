using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitFromRareElementV2 : MonoBehaviour
{
	[Serializable]
	public class RareElementObj
	{
		public int rareNo;

		public int elementNo;

		public Side side;

		public GameObject gameObj;

		public RareElementObj()
		{
			side = Side.None;
		}
	}

	[Serializable]
	public enum Side
	{
		None,
		PlayerSide,
		EnemySide
	}

	public RareElementObj[] emitObjs;

	public bool emitNoSetPM;

	public int testRare;

	public int testElem;

	public Side testSide;

	private Side emitterSide;

	private bool end;

	public bool child;

	public Transform parentObj;

	public Vector3 offsetRot;

	public bool destroy;

	private Transform targetObj;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	public Ef_EmitFromRareElementV2()
	{
		emitObjs = new RareElementObj[1];
		emitNoSetPM = true;
		testSide = Side.None;
		emitterSide = Side.None;
		child = true;
		offsetRot = Vector3.zero;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		if (testRare > 0 && testElem > 0)
		{
			EmitFromRareElem(testRare, testElem);
		}
		else if (!end)
		{
			if (emitNoSetPM)
			{
				EmitFromRareElem(0, 0);
			}
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			end = true;
		}
	}

	public void emitEffectMessage(MerlinActionControl emtr)
	{
		if (!(emtr == null))
		{
			if (emtr.IsSidePlayer)
			{
				emitterSide = Side.PlayerSide;
			}
			else if (emtr.IsSideEnemy)
			{
				emitterSide = Side.EnemySide;
			}
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (mpets != null)
		{
			EmitFromRareElem(mpets.Rare, mpets.MElementId);
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void EmitFromRareElem(int inRare, int inElem)
	{
		if (end)
		{
			return;
		}
		int length = emitObjs.Length;
		if (length == 0)
		{
			return;
		}
		GameObject gameObject = null;
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				RareElementObj[] array = emitObjs;
				int rareNo = array[RuntimeServices.NormalizeArrayIndex(array, num)].rareNo;
				RareElementObj[] array2 = emitObjs;
				int elementNo = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].elementNo;
				RareElementObj[] array3 = emitObjs;
				Side side = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].side;
				if (emitterSide == Side.None)
				{
				}
				if ((side == emitterSide || side == Side.None) && ((rareNo == inRare && elementNo == inElem) || (rareNo <= 0 && elementNo == inElem) || (rareNo == inRare && elementNo <= 0) || (rareNo <= 0 && elementNo <= 0)))
				{
					RareElementObj[] array4 = emitObjs;
					if (array4[RuntimeServices.NormalizeArrayIndex(array4, num)].gameObj != null)
					{
						RareElementObj[] array5 = emitObjs;
						gameObject = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].gameObj;
						break;
					}
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		if (gameObject == null)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		if ((bool)parentObj)
		{
			vector = parentObj.position;
			quaternion = parentObj.rotation * Quaternion.Euler(offsetRot);
		}
		else
		{
			vector = transform.position;
			quaternion = transform.rotation * Quaternion.Euler(offsetRot);
		}
		GameObject gameObject2 = ((GameObject)UnityEngine.Object.Instantiate(gameObject, vector, quaternion)) as GameObject;
		if (!gameObject2)
		{
			return;
		}
		MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component != null)
		{
			if (!(component.Command.parent != null))
			{
				UnityEngine.Object.Destroy(gameObject2);
				return;
			}
			gameObject2.layer = this.gameObject.layer;
			MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject2.AddComponent<MerlinAttackCommandHolder>();
			merlinAttackCommandHolder.Command = component.Command;
		}
		if ((bool)targetObj)
		{
			gameObject2.SendMessage("setTarget", targetObj, SendMessageOptions.DontRequireReceiver);
		}
		if (sendColor != new Color(0f, 0f, 0f, 0f))
		{
			gameObject2.SendMessage("setColor", sendColor, SendMessageOptions.DontRequireReceiver);
		}
		if (sendTime != 0f)
		{
			gameObject2.SendMessage("setTime", sendTime, SendMessageOptions.DontRequireReceiver);
		}
		if (sendRank != 0)
		{
			gameObject2.SendMessage("setRank", sendRank, SendMessageOptions.DontRequireReceiver);
		}
		if (child)
		{
			Vector3 localScale = gameObject2.transform.localScale;
			if ((bool)parentObj)
			{
				gameObject2.transform.parent = parentObj;
			}
			else
			{
				gameObject2.transform.parent = transform;
			}
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localRotation = Quaternion.identity;
			gameObject2.transform.localScale = localScale;
		}
		else if (destroy)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		end = true;
	}

	public void setTarget(Transform trgObj)
	{
		targetObj = trgObj;
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
}
