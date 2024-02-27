using System;
using UnityEngine;

[Serializable]
public class Ef_Peddle_Emit : MonoBehaviour
{
	public GameObject ef_Pebble;

	public int emitNum;

	public float rndAngle;

	public Ef_Peddle_Emit()
	{
		emitNum = 3;
		rndAngle = 45f;
	}

	public void Start()
	{
		if (!ef_Pebble)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		int num = 0;
		int num2 = emitNum;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int num3 = num;
			num++;
			Quaternion rotation = transform.rotation * Quaternion.Euler(new Vector3(0f, UnityEngine.Random.Range((0f - rndAngle) / 2f, rndAngle / 2f), 0f));
			UnityEngine.Object.Instantiate(ef_Pebble, transform.position, rotation);
		}
		UnityEngine.Object.Destroy(gameObject);
	}
}
