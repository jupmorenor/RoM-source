using System;
using UnityEngine;

[Serializable]
public class DelayAttack : MonoBehaviour
{
	public GameObject effAttack;

	public float effStartTime;

	public float coliAttackStartTime;

	public float destroyTime;

	public float atkInterval;

	private float atkIntervalTime;

	private int rank;

	public DelayAttack()
	{
		effStartTime = 1.5f;
		coliAttackStartTime = 1.5f;
		destroyTime = 1.5f;
		atkInterval = 0.1f;
		rank = -1;
	}

	public void Start()
	{
		UnityEngine.Object.Destroy(gameObject, destroyTime);
	}

	public void Update()
	{
		if (!(coliAttackStartTime < 0f))
		{
			coliAttackStartTime -= Time.deltaTime;
			if (!(coliAttackStartTime >= 0f))
			{
				collider.enabled = true;
			}
		}
		else
		{
			atkIntervalTime -= Time.deltaTime;
			if (!(coliAttackStartTime >= 0f))
			{
				collider.enabled = !collider.enabled;
				coliAttackStartTime = atkInterval;
			}
		}
		if (!(effStartTime < 0f))
		{
			effStartTime -= Time.deltaTime;
			GameObject gameObject = default(GameObject);
			if ((bool)effAttack && !(effStartTime >= 0f))
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(effAttack, transform.position, transform.rotation);
			}
			if (gameObject != null && rank >= 0)
			{
				gameObject.SendMessage("setRank", rank, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void setRank(int inRank)
	{
		rank = inRank;
	}
}
