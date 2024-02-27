using System;
using Boo.Lang.Runtime;

[Serializable]
public class WarpInput : PlayerInputControl
{
	public WarpInput(PlayerControl player)
	{
		if (!(player != null))
		{
			throw new AssertionFailedException("player != null");
		}
		base._002Ector(player);
	}

	protected override void doUpdate(float dt)
	{
	}
}
