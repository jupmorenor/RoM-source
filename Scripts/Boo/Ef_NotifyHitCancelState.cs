using System;

[Serializable]
public class Ef_NotifyHitCancelState
{
	public int durability;

	public Ef_NotifyHitCancelObj[] objects;

	public Ef_NotifyHitCancelState()
	{
		durability = 1;
	}
}
