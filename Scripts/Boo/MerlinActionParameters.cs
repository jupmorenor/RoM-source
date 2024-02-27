using System;

[Serializable]
public class MerlinActionParameters
{
	public bool guard;

	private int noAttackHitCount;

	private int hitCancelCount;

	public bool noAttackHit => noAttackHitCount > 0;

	public bool IsHitCancel => hitCancelCount > 0;

	public int HitCancelCount => hitCancelCount;

	public void reset()
	{
		noAttackHitCount = 0;
		guard = false;
		int num = 0;
	}

	public void setNoAttackHit()
	{
		checked
		{
			noAttackHitCount++;
		}
	}

	public void resetNoAttackHit()
	{
		checked
		{
			noAttackHitCount--;
			if (noAttackHitCount < 0)
			{
				noAttackHitCount = 0;
			}
		}
	}

	public void setHitCancelCount(int n)
	{
		hitCancelCount = n;
	}

	public void decHitCancelCount()
	{
		checked
		{
			if (hitCancelCount > 0)
			{
				hitCancelCount--;
			}
		}
	}

	public void resetHitCancelCount()
	{
		hitCancelCount = 0;
	}

	public void initAtMotionChange()
	{
		guard = false;
	}
}
