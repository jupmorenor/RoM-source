using System;
using UnityEngine;

[Serializable]
public class QuestKeyItem : DropBase
{
	public PlayerControl player;

	public float delay;

	public float speed;

	public float maxSpd;

	public float accel;

	public float accel2nd;

	public bool move;

	[NonSerialized]
	private const float MAX_SPEED = 1f;

	public QuestKeyItem()
	{
		delay = 1f;
		maxSpd = 12f;
		accel = 2f;
		accel2nd = 2f;
	}

	protected override void doPickMeUp(PlayerControl p)
	{
		int keyItemPoint = QuestSession.KeyItemPoint;
		if (keyItemPoint > 0)
		{
			BattleHUDQuestCondition.dispChallengeRankingPoint(keyItemPoint);
		}
	}

	public void Move(bool flg)
	{
		move = flg;
	}

	public void Start()
	{
		if (player == null)
		{
			player = (PlayerControl)UnityEngine.Object.FindObjectOfType(typeof(PlayerControl));
		}
	}

	public void Update()
	{
		if (!move || !player)
		{
			return;
		}
		Vector3 forward = player.transform.position - transform.position;
		forward.y = 0f;
		if (!(forward.magnitude >= 0.5f))
		{
			OnTriggerEnter(player.collider);
		}
		if (!(delay <= 0f))
		{
			delay -= Time.deltaTime;
			return;
		}
		Quaternion quaternion = Quaternion.LookRotation(forward, transform.up);
		transform.position += forward.normalized * speed * Time.deltaTime;
		accel += accel2nd * Time.deltaTime;
		speed += accel * Time.deltaTime;
		if (!(speed <= maxSpd))
		{
			speed = maxSpd;
		}
	}
}
