using System;
using UnityEngine;

[Serializable]
public class TreasureGet : DropBase
{
	public PlayerControl player;

	public float delay;

	public float speed;

	public float maxSpd;

	public float accel;

	public float accel2nd;

	public float rotSpeed;

	public Transform rotObj;

	public bool move;

	[NonSerialized]
	private const float MAX_SPEED = 1f;

	private bool earned;

	public TreasureGet()
	{
		delay = 1f;
		maxSpd = 12f;
		accel = 2f;
		accel2nd = 2f;
		rotSpeed = 30f;
		move = true;
	}

	protected override void doPickMeUp(PlayerControl p)
	{
		earned = true;
		QuestParam.EarnTreasure();
		PlayerEventDispatcher.InvokeBoxGet();
	}

	protected override void doOnDestroy()
	{
		if (!earned)
		{
			QuestParam.EarnTreasure();
		}
	}

	public void Move(bool flg)
	{
		move = flg;
	}

	public void Start()
	{
		player = PlayerControl.CurrentPlayer;
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
		Quaternion to = Quaternion.LookRotation(forward, transform.up);
		if ((bool)rotObj)
		{
			rotObj.rotation = Quaternion.RotateTowards(rotObj.rotation, to, rotSpeed * Time.deltaTime);
		}
		transform.position += forward.normalized * speed * Time.deltaTime;
		accel += accel2nd * Time.deltaTime;
		speed += accel * Time.deltaTime;
		if (!(speed <= maxSpd))
		{
			speed = maxSpd;
		}
	}
}
