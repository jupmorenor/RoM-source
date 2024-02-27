using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_RandomStart : Ef_Base
{
	public Transform[] effectObjs;

	public float randomTime;

	public Vector3 randomPos;

	public Vector3 randomRot;

	public float randomSize;

	public int loop;

	public float life;

	public float delay;

	public bool onWorld;

	private float timer;

	private int count;

	private int no;

	private Vector3[] fstPos;

	private Quaternion[] fstRot;

	private Vector3[] fstSiz;

	public Ef_RandomStart()
	{
		randomTime = 1f;
		randomPos = Vector3.zero;
		randomRot = Vector3.zero;
		randomSize = 1f;
		loop = 1;
		life = 1f;
		onWorld = true;
	}

	public void Start()
	{
		timer = 0f;
		count = effectObjs.Length;
		int num = default(int);
		if (count == 0)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		fstPos = new Vector3[count];
		fstRot = new Quaternion[count];
		fstSiz = new Vector3[count];
		no = 0;
		IEnumerator<int> enumerator = Builtins.range(count).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = effectObjs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Vector3[] array2 = fstPos;
					ref Vector3 reference = ref array2[RuntimeServices.NormalizeArrayIndex(array2, num)];
					Transform[] array3 = effectObjs;
					reference = array3[RuntimeServices.NormalizeArrayIndex(array3, num)].localPosition;
					Quaternion[] array4 = fstRot;
					ref Quaternion reference2 = ref array4[RuntimeServices.NormalizeArrayIndex(array4, num)];
					Transform[] array5 = effectObjs;
					reference2 = array5[RuntimeServices.NormalizeArrayIndex(array5, num)].localRotation;
					Vector3[] array6 = fstSiz;
					ref Vector3 reference3 = ref array6[RuntimeServices.NormalizeArrayIndex(array6, num)];
					Transform[] array7 = effectObjs;
					reference3 = array7[RuntimeServices.NormalizeArrayIndex(array7, num)].localScale;
					Transform[] array8 = effectObjs;
					array8[RuntimeServices.NormalizeArrayIndex(array8, num)].gameObject.SetActive(value: false);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	public void Update()
	{
		if (!(delay <= 0f))
		{
			delay -= deltaTime;
			return;
		}
		timer += deltaTime;
		checked
		{
			if (no < count)
			{
				if (timer <= randomTime / (float)count * (float)(no + 1))
				{
					return;
				}
				Transform[] array = effectObjs;
				Transform transform = array[RuntimeServices.NormalizeArrayIndex(array, no)];
				if ((bool)transform)
				{
					transform.gameObject.SetActive(value: true);
					transform.parent = this.transform;
					Vector3[] array2 = fstPos;
					transform.localPosition = array2[RuntimeServices.NormalizeArrayIndex(array2, no)] + new Vector3(UnityEngine.Random.Range((0f - randomPos.x) / 2f, randomPos.x / 2f), UnityEngine.Random.Range((0f - randomPos.y) / 2f, randomPos.y / 2f), UnityEngine.Random.Range((0f - randomPos.z) / 2f, randomPos.z / 2f));
					Quaternion quaternion = Quaternion.Euler(new Vector3(UnityEngine.Random.Range((0f - randomRot.x) / 2f, randomRot.x / 2f), UnityEngine.Random.Range((0f - randomRot.y) / 2f, randomRot.y / 2f), UnityEngine.Random.Range((0f - randomRot.z) / 2f, randomRot.z / 2f)));
					Quaternion[] array3 = fstRot;
					transform.localRotation = quaternion * array3[RuntimeServices.NormalizeArrayIndex(array3, no)];
					Vector3[] array4 = fstSiz;
					transform.localScale = array4[RuntimeServices.NormalizeArrayIndex(array4, no)] * UnityEngine.Random.Range(1f, randomSize);
					if (onWorld)
					{
						transform.parent = null;
					}
					Animation componentInChildren = transform.gameObject.GetComponentInChildren<Animation>();
					if ((bool)componentInChildren)
					{
						componentInChildren.Play();
					}
					else
					{
						Ef_QuickAnimTransform componentInChildren2 = transform.gameObject.GetComponentInChildren<Ef_QuickAnimTransform>();
						if ((bool)componentInChildren2)
						{
							componentInChildren2.Clear();
							componentInChildren2.Play();
						}
						else
						{
							Ef_QuickAnimColor componentInChildren3 = transform.gameObject.GetComponentInChildren<Ef_QuickAnimColor>();
							if ((bool)componentInChildren3)
							{
								componentInChildren3.Clear();
								componentInChildren3.Play();
							}
							else
							{
								Ef_QuickAnimTexture componentInChildren4 = transform.gameObject.GetComponentInChildren<Ef_QuickAnimTexture>();
								if ((bool)componentInChildren4)
								{
									componentInChildren4.Clear();
									componentInChildren4.Play();
								}
								else
								{
									Ef_QuickAnimMatFloat componentInChildren5 = transform.gameObject.GetComponentInChildren<Ef_QuickAnimMatFloat>();
									if ((bool)componentInChildren5)
									{
										componentInChildren5.Clear();
										componentInChildren5.Play();
									}
								}
							}
						}
					}
				}
				no++;
			}
			else if (loop > 1)
			{
				no = 0;
				timer = 0f;
				loop--;
			}
			else
			{
				life -= deltaTime;
				if (!(life > 0f))
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
	}

	public void OnDestroy()
	{
		int num = default(int);
		IEnumerator<int> enumerator = Builtins.range(count).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				num = enumerator.Current;
				Transform[] array = effectObjs;
				if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
				{
					Transform[] array2 = effectObjs;
					UnityEngine.Object.Destroy(array2[RuntimeServices.NormalizeArrayIndex(array2, num)].gameObject);
				}
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
