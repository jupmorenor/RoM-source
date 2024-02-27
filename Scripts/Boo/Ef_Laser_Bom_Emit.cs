using System;
using UnityEngine;

[Serializable]
public class Ef_Laser_Bom_Emit : Ef_Base
{
	public GameObject ef_laser_bom;

	public int emitNum;

	public float emitTime;

	public float radius;

	private float oneTime;

	private float nextTime;

	private float oneAngle;

	private int no;

	public Ef_Laser_Bom_Emit()
	{
		emitNum = 8;
		emitTime = 1f;
		radius = 14f;
	}

	public void Start()
	{
		oneTime = emitTime / (float)emitNum;
		nextTime = emitTime;
		oneAngle = 360f / (float)emitNum;
	}

	public void Update()
	{
		emitTime -= deltaTime;
		checked
		{
			if (!(emitTime > nextTime))
			{
				Vector3 vector = Quaternion.Euler(0f, oneAngle * (float)no, 0f) * new Vector3(0f, 0f, radius);
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(ef_laser_bom, transform.position + vector, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));
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
				no++;
				nextTime -= oneTime;
			}
			if (!(emitTime > 0f))
			{
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}
}
