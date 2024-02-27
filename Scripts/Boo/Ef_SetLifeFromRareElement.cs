using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_SetLifeFromRareElement : MonoBehaviour
{
	public GameObject[] gameObjs;

	public int elementNum;

	public float[] lifes;

	public float[] minuss;

	public float minusderay;

	public bool setNoSetPM;

	public int testRare;

	public int testElem;

	private bool end;

	public Ef_SetLifeFromRareElement()
	{
		elementNum = 1;
		minusderay = 1f;
		setNoSetPM = true;
	}

	public void Start()
	{
		if (testRare > 0 && testElem > 0)
		{
			SetLife(testRare, testElem);
		}
	}

	public void Awake()
	{
		if (!end && setNoSetPM)
		{
			SetLife(0, 0);
		}
	}

	public void setPoppetMaster(MPoppets mpets)
	{
		SetLife(mpets.Rare, mpets.MElementId);
	}

	public void SetLife(int rare, int elem)
	{
		Debug.Log(rare + "  " + elem);
		int length = gameObjs.Length;
		int length2 = lifes.Length;
		int length3 = minuss.Length;
		if (length == 0 || length2 == 0)
		{
			return;
		}
		checked
		{
			int num = elementNum * (rare - 1) + (elem - 1);
			if (num >= length2)
			{
				num = length2 - 1;
			}
			float[] array = lifes;
			float num2 = array[RuntimeServices.NormalizeArrayIndex(array, num)];
			int num3 = default(int);
			IEnumerator<int> enumerator = Builtins.range(length).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					num3 = enumerator.Current;
					GameObject[] array2 = gameObjs;
					GameObject gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num3)];
					if ((bool)gameObject)
					{
						float num4 = default(float);
						if (length3 >= length)
						{
							float[] array3 = minuss;
							num4 = num2 - array3[RuntimeServices.NormalizeArrayIndex(array3, num3)];
						}
						else if (length3 > 0)
						{
							float[] array4 = minuss;
							num4 = num2 - array4[RuntimeServices.NormalizeArrayIndex(array4, length3 - 1)];
						}
						else
						{
							num4 = num2;
						}
						if ((bool)gameObject.particleSystem)
						{
							gameObject.particleSystem.startLifetime = num4;
						}
						else if ((bool)gameObject.GetComponent<Ef_DestroyTimer>())
						{
							gameObject.GetComponent<Ef_DestroyTimer>().life = num4;
						}
						else if ((bool)gameObject.GetComponent<Ef_DestroyParticle>())
						{
							gameObject.GetComponent<Ef_DestroyParticle>().life = num4;
							gameObject.GetComponent<Ef_DestroyParticle>().fadeDelay = num4 - minusderay;
						}
						else if ((bool)gameObject.GetComponent<Ef_DestroyTrail>())
						{
							gameObject.GetComponent<Ef_DestroyTrail>().life = num4;
							gameObject.GetComponent<Ef_DestroyTrail>().fadeDelay = num4 - minusderay;
						}
						else if ((bool)gameObject.GetComponent<Ef_DestroyAlpha>())
						{
							gameObject.GetComponent<Ef_DestroyAlpha>().life = num4;
							gameObject.GetComponent<Ef_DestroyAlpha>().fadeDelay = num4 - minusderay;
						}
						else if ((bool)gameObject.GetComponent<Ef_SwordTrail>())
						{
							gameObject.GetComponent<Ef_SwordTrail>().slashTime = num4;
						}
						else if ((bool)gameObject.GetComponent<Ef_RingMesh>())
						{
							gameObject.GetComponent<Ef_RingMesh>().life = num4;
						}
						else
						{
							gameObject.SendMessage("setTime", num4);
						}
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
			end = true;
		}
	}
}
