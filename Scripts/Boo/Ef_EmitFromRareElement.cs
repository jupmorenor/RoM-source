using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_EmitFromRareElement : MonoBehaviour
{
	public Ef_EmitFromRareElementObj[] emitObjs;

	public int testRare;

	public int testElem;

	public string testPName;

	public bool emitNoSetPM;

	public bool child;

	public Transform parentObj;

	public Vector3 offsetRot;

	public bool destroy;

	private Transform targetObj;

	private Color sendColor;

	private float sendTime;

	private int sendRank;

	private bool end;

	public Ef_EmitFromRareElement()
	{
		emitObjs = new Ef_EmitFromRareElementObj[1];
		testPName = string.Empty;
		emitNoSetPM = true;
		child = true;
		offsetRot = Vector3.zero;
		sendColor = new Color(0f, 0f, 0f, 0f);
	}

	public void Start()
	{
		if (testRare > 0 && testElem > 0)
		{
			EmitFromRareElem(testRare, testElem, testPName);
		}
		else if (!end)
		{
			if (emitNoSetPM)
			{
				EmitFromRareElem(0, 0, string.Empty);
			}
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		if (mpets != null)
		{
			EmitFromRareElem(mpets.Rare, mpets.MElementId, mpets.PrefabName);
			if (destroy)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}

	public void EmitFromRareElem(int rare, int elem, string pName)
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
				Ef_EmitFromRareElementObj[] array = emitObjs;
				int rareNo = array[RuntimeServices.NormalizeArrayIndex(array, num)].rareNo;
				Ef_EmitFromRareElementObj[] array2 = emitObjs;
				int elementNo = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].elementNo;
				Ef_EmitFromRareElementObj[] array3 = emitObjs;
				if (array3[RuntimeServices.NormalizeArrayIndex(array3, num)].prefabName.Length > 0)
				{
					Ef_EmitFromRareElementObj[] array4 = emitObjs;
					if (array4[RuntimeServices.NormalizeArrayIndex(array4, num)].prefabName != pName)
					{
						continue;
					}
				}
				if ((rareNo == rare && elementNo == elem) || (rareNo == 0 && elementNo == elem) || (elementNo == 0 && rareNo == rare) || (elem == 0 && rare == 0))
				{
					Ef_EmitFromRareElementObj[] array5 = emitObjs;
					if (array5[RuntimeServices.NormalizeArrayIndex(array5, num)].gameObj == null)
					{
						return;
					}
					Ef_EmitFromRareElementObj[] array6 = emitObjs;
					gameObject = array6[RuntimeServices.NormalizeArrayIndex(array6, num)].gameObj;
					break;
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
