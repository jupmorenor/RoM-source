using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class MapJumpInput : PlayerInputControl
{
	public MapJumpInput(PlayerControl player)
	{
		if (!(player != null))
		{
			throw new AssertionFailedException("player != null");
		}
		base._002Ector(player);
	}

	protected override void doUpdate(float dt)
	{
		Vector3 forward = Player.transform.forward;
		ActionInput.move(Player.MYPOS + forward * 50f);
	}
}
