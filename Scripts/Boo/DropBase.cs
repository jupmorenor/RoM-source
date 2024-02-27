using System;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DropBase : MonoBehaviour
{
	private Boo.Lang.List<RespSimpleReward> rewards;

	private Boo.Lang.List<QuestDropManager.DropData> stageDrops;

	public string pickUpMethod;

	public float destroyDelay;

	public GameObject getEffect;

	public GameObject getPoppetEffect;

	public SQEX_SoundPlayerData.SE get_4SQEX_SE;

	private bool picked;

	public Boo.Lang.List<RespSimpleReward> Rewards => rewards;

	public Boo.Lang.List<QuestDropManager.DropData> StageDrops => stageDrops;

	public DropBase()
	{
		rewards = new Boo.Lang.List<RespSimpleReward>();
		stageDrops = new Boo.Lang.List<QuestDropManager.DropData>();
		pickUpMethod = string.Empty;
		get_4SQEX_SE = SQEX_SoundPlayerData.SE.treasure_get;
	}

	public void add(RespSimpleReward r)
	{
		if (r != null && !rewards.Contains(r))
		{
			rewards.Add(r);
			QuestSession.GotMonsterReward(r);
		}
	}

	public void add(QuestDropManager.DropData d)
	{
		if (d != null && !stageDrops.Contains(d))
		{
			stageDrops.Add(d);
		}
	}

	public void addData(object d)
	{
		if (d is RespSimpleReward)
		{
			add(d as RespSimpleReward);
			return;
		}
		if (d is QuestDropManager.DropData)
		{
			add(d as QuestDropManager.DropData);
			return;
		}
		throw new Exception(new StringBuilder().Append(d).Append(" はドロップデータとして正しいデータではありません。").ToString());
	}

	protected virtual void doPickMeUp(PlayerControl p)
	{
	}

	protected virtual void doOnDestroy()
	{
	}

	public void OnTriggerEnter(Collider other)
	{
		OnTriggerStay(other);
	}

	public void OnTriggerStay(Collider other)
	{
		if (!picked)
		{
			GameObject gameObject = other.transform.root.gameObject;
			PlayerControl component = gameObject.GetComponent<PlayerControl>();
			if (!(component == null))
			{
				pickMeUp(component);
			}
		}
	}

	private void pickMeUp(PlayerControl p)
	{
		getQuestReward();
		getStageDrops();
		doPickMeUp(p);
		if (!string.IsNullOrEmpty(pickUpMethod))
		{
			gameObject.SendMessage(pickUpMethod, null, SendMessageOptions.DontRequireReceiver);
		}
		if ((bool)getEffect)
		{
			UnityEngine.Object.Instantiate(getEffect, transform.position, transform.rotation);
		}
		if ((bool)getPoppetEffect)
		{
			int i = 0;
			AIControl[] poppets = p.Poppets;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				if (!(poppets[i] == null))
				{
					UnityEngine.Object.Instantiate(getEffect, poppets[i].transform.position, transform.rotation);
				}
			}
		}
		SQEX_SoundPlayer instance = SQEX_SoundPlayer.Instance;
		if ((bool)instance)
		{
			instance.PlaySe((int)get_4SQEX_SE, 0, gameObject.GetInstanceID());
		}
		UnityEngine.Object.Destroy(gameObject, destroyDelay);
		picked = true;
	}

	public void OnEnable()
	{
		ShadowSelector.Setup(gameObject);
	}

	public void OnDestroy()
	{
		getQuestReward();
		doOnDestroy();
	}

	private void getQuestReward()
	{
		IEnumerator<RespSimpleReward> enumerator = rewards.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RespSimpleReward current = enumerator.Current;
				QuestSession.GotMonsterReward(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private void getStageDrops()
	{
		IEnumerator<QuestDropManager.DropData> enumerator = stageDrops.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				QuestDropManager.DropData current = enumerator.Current;
				QuestSession.PickedKusamushiUp(current);
			}
		}
		finally
		{
			enumerator.Dispose();
		}
	}
}
