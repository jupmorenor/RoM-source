using System;
using UnityEngine;

[Serializable]
public class PotionGet : DropBase
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

	public PotionGet()
	{
		delay = 1f;
		maxSpd = 12f;
		accel = 2f;
		accel2nd = 2f;
	}

	protected override void doPickMeUp(PlayerControl pc)
	{
		int recover = checked((int)pc.RecoverByCandy());
		DamageDisplay.Heal(transform.root.position, recover);
		PlayerEventDispatcher.InvokeCandyGet();
	}

	public void Update()
	{
		float y = transform.eulerAngles.y + Time.deltaTime * 30f;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector2 = (transform.eulerAngles = eulerAngles);
	}
}
