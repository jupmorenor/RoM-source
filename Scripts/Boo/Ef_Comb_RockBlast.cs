using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Ef_Comb_RockBlast : Ef_Base
{
	public GameObject rockObj;

	public float life;

	public int num;

	public float maxSize;

	public float minSize;

	public float radius;

	private float nextLife;

	private float oneTime;

	private Transform[] trgs;

	private int trgNum;

	public Ef_Comb_RockBlast()
	{
		life = 3f;
		num = 16;
		maxSize = 1f;
		minSize = 0.3f;
		radius = 6f;
		trgs = new Transform[3];
	}

	public void Start()
	{
		if ((bool)rockObj)
		{
			oneTime = life / (float)num;
			nextLife = life - oneTime;
			FindTargets();
		}
	}

	public void Update()
	{
		life -= deltaTime;
		if (!(life > 0f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		checked
		{
			if ((bool)rockObj && !(life > nextLife))
			{
				Emit();
				num--;
				nextLife -= oneTime;
			}
		}
	}

	public void Emit()
	{
		Vector3 vector = default(Vector3);
		Quaternion quaternion = default(Quaternion);
		int num = this.num % 3;
		if (num < trgNum && num < 3 && num >= 0)
		{
			Transform[] array = trgs;
			if ((bool)array[RuntimeServices.NormalizeArrayIndex(array, num)])
			{
				Transform[] array2 = trgs;
				vector = array2[RuntimeServices.NormalizeArrayIndex(array2, num)].position - transform.position;
				quaternion = Quaternion.Euler(90f, 0f, 0f);
				quaternion = Quaternion.Euler(UnityEngine.Random.Range(80, 90), UnityEngine.Random.Range(0, 360), 0f);
				goto IL_00f9;
			}
		}
		vector = Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f) * new Vector3(0f, 0f, Mathf.Sin(UnityEngine.Random.Range(0f, 1.57f)) * radius);
		quaternion = Quaternion.Euler(UnityEngine.Random.Range(30, 80), UnityEngine.Random.Range(0, 360), 0f);
		goto IL_00f9;
		IL_00f9:
		vector += quaternion * new Vector3(0f, 0f, -10f);
		vector += transform.position;
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(rockObj, vector, quaternion);
		float num2 = UnityEngine.Random.Range(minSize, maxSize);
		gameObject.transform.localScale = new Vector3(num2, num2, num2);
		MerlinAttackCommandHolder component = this.gameObject.GetComponent<MerlinAttackCommandHolder>();
		if (component != null)
		{
			if (component.Command.parent != null)
			{
				gameObject.layer = this.gameObject.layer;
				MerlinAttackCommandHolder merlinAttackCommandHolder = gameObject.AddComponent<MerlinAttackCommandHolder>();
				merlinAttackCommandHolder.Command = component.Command;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
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
