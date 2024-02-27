using System;
using UnityEngine;

[Serializable]
public class Ef_TestEmitter : MonoBehaviour
{
	public GameObject emitObj;

	public bool emit;

	public int number;

	public Ef_TestEmitter()
	{
		number = 1;
	}

	public void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			emit = true;
		}
		if (emit && (bool)emitObj)
		{
			int num = 0;
			int num2 = number;
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				UnityEngine.Object.Instantiate(emitObj, transform.position, transform.rotation);
			}
			emit = false;
		}
	}
}
