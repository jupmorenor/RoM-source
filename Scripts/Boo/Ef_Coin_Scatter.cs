using System;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class Ef_Coin_Scatter : Ef_Base
{
	public Transform target;

	public GameObject coinPrefab;

	public float maxSpeed;

	public float minSpeed;

	public int money;

	private RespSimpleReward[] rewards;

	public RespSimpleReward[] Rewards
	{
		get
		{
			return rewards;
		}
		set
		{
			rewards = value;
		}
	}

	public Ef_Coin_Scatter()
	{
		maxSpeed = 10f;
		minSpeed = 1f;
		money = 1;
	}

	public void Start()
	{
		if (!target)
		{
			PlayerControl currentPlayer = PlayerControl.CurrentPlayer;
			if ((bool)currentPlayer)
			{
				target = currentPlayer.transform;
				Transform transform = target.Find("y_ang");
				if ((bool)transform)
				{
					target = transform;
				}
			}
		}
		if ((bool)coinPrefab)
		{
			int num = Mathf.Clamp(money / 2, 1, 10);
			int num2 = money / num;
			int num3 = money % num;
			int num4 = 0;
			int num5 = num;
			if (num5 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num4 < num5)
			{
				int num6 = num4;
				num4++;
				Quaternion quaternion = Quaternion.Euler(0f, 360f / (float)num * (float)num6, 0f);
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(coinPrefab, this.transform.position, quaternion);
				int num7 = checked(num2 + ((num6 < num3) ? 1 : 0));
				if (gameObject == null)
				{
					QuestParam.EarnMoney(num7);
					continue;
				}
				gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				Ef_Coin_Scatter_Coin component = gameObject.GetComponent<Ef_Coin_Scatter_Coin>();
				component.velocity = quaternion * new Vector3(0f, 0f, UnityEngine.Random.Range(minSpeed, maxSpeed));
				if (target != null)
				{
					component.target = target;
				}
				component.money = num7;
			}
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public void OnDestroy()
	{
		if (Ef_Base.isShuttingDown || rewards == null)
		{
			return;
		}
		int i = 0;
		RespSimpleReward[] array = rewards;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null && array[i].IsCoin)
			{
				QuestSession.GotMonsterReward(array[i]);
			}
		}
	}
}
